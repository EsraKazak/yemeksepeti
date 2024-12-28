using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemeksepeti
{
	public partial class Adminİslem : Form
	{
		private static SemaphoreSlim semaphore = new SemaphoreSlim(2);  
		private Thread refreshThread;
		private bool isThreadRunning;

		public Adminİslem()
		{
			InitializeComponent();
		}

		private void Adminİslem_Load(object sender, EventArgs e)
		{
			StartOrderUpdateThread();
		}

		private void StartOrderUpdateThread()
		{
			isThreadRunning = true;
			refreshThread = new Thread(() =>
			{
				while (isThreadRunning)
				{
					RefreshOrders();
					Thread.Sleep(3000);
				}
			});

			refreshThread.Start();
		}

		private void RefreshOrders()
		{
			List<Siparis> orders = GetOrdersFromDatabase();

			
			foreach (var order in orders)
			{
				order.PrioritizationScore = oncelikhesapla(order.CustemerID, order.OrderDate);
			}

			
			var orderedByPriority = orders.OrderByDescending(o => o.PrioritizationScore).ToList();

			
			Invoke((MethodInvoker)delegate
			{
				dataGridView1.DataSource = orderedByPriority;
			});
		}


		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";




		private List<Siparis> GetOrdersFromDatabase()
		{
			List<Siparis> orders = new List<Siparis>();

			
			string query = @"
        SELECT o.OrderID, o.CustemerID, o.OrderDate, c.CustomerType 
        FROM yemeksiparis.dbo.Orders o
        INNER JOIN yemeksiparis.dbo.Custemers c ON o.CustemerID = c.CustomerID
        WHERE o.OrderStatus = 'Bekliyor'";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					orders.Add(new Siparis
					{
						OrderID = reader.GetInt32(reader.GetOrdinal("OrderID")),
						CustemerID = reader.GetInt32(reader.GetOrdinal("CustemerID")),
						OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
						CustomerType = reader.GetString(reader.GetOrdinal("CustomerType")) 
					});
				}
			}

			return orders;
		}


		private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			isThreadRunning = false;
			if (refreshThread != null && refreshThread.IsAlive)
			{
				refreshThread.Join();
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			var orders = GetOrdersFromDatabase();

			
			foreach (var order in orders)
			{
				
				order.PrioritizationScore = oncelikhesapla(order.CustemerID, order.OrderDate);
			}

			progressBar1.Minimum = 0;
			progressBar1.Maximum = 100;
			progressBar1.Value = 0;

			
			var sortedOrders = orders.OrderByDescending(o => o.PrioritizationScore).ToList();




			
			foreach (var order in sortedOrders)
			{
				int orderId = order.OrderID;
				int customerId = order.CustemerID;
				progressBar1.Value = 0;
				await ApproveOrderAsync(order.OrderID, customerId);


			}
		}

		private double oncelikhesapla(int customerId, DateTime orderDate)
		{
			
			int basicPriorityScore = GetCustomerPriority(customerId);

			
			TimeSpan waitingTime = DateTime.Now - orderDate;

			
			double waitingTimeWeight = 0.5;

			
			double prioritizationScore = basicPriorityScore + (waitingTime.TotalSeconds * waitingTimeWeight);

			return prioritizationScore;
		}

		private int GetCustomerPriority(int customerId)
		{
			
			string query = "SELECT CustomerType FROM yemeksiparis.dbo.Custemers WHERE CustomerID = @CustomerID";
			int priorityScore = 10;  

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@CustomerID", customerId); 
				connection.Open();

				object result = command.ExecuteScalar();
				if (result != DBNull.Value)
				{
					string customerType = result.ToString();
					if (customerType == "Premium")
					{
						priorityScore = 15; 
					}
				}
			}

			return priorityScore;
		}



		private async Task ApproveOrderAsync(int orderId, int customerId)
		{
			await semaphore.WaitAsync();

			try
			{
				for (int i = 0; i <= 100; i += 20)
				{
				
					progressBar1.Value = i;
					progressBar1.Refresh();

					
					await Task.Delay(500); 
				}

				
				if (!IsOrderProcessable(orderId, customerId, out string failureReason))
				{
					MessageBox.Show($"Sipariş {orderId} onaylanmadı: {failureReason}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					
					AddLog(customerId, DateTime.Now, "Hata", failureReason, orderId);
					return;
				}

				
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = "UPDATE yemeksiparis.dbo.Orders SET OrderStatus = 'Onaylandı' WHERE OrderID = @OrderID";
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@OrderID", orderId);

					connection.Open();
					command.ExecuteNonQuery();
				}

				
				UpdateStock(orderId);

				
				double totalOrderPrice = GetOrderTotalPrice(orderId);
				UpdateCustomerBudget(customerId, totalOrderPrice);

				
				AddLog(customerId, DateTime.Now, "Bilgi", $"Sipariş {orderId} başarıyla onaylandı.", orderId);

				MessageBox.Show($"Sipariş {orderId} onaylandı ve işlemler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				
				AddLog(customerId, DateTime.Now, "Hata", $"Sipariş {orderId} onaylanırken hata oluştu: {ex.Message}", orderId);

				MessageBox.Show($"Sipariş onaylanırken hata oluştu: {ex.Message}");
			}
			finally
			{
				semaphore.Release(); 
			}

			
			RefreshOrders();
		}

		
		private void AddLog(int customerId, DateTime logDate, string logType, string logDetails, int orderId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = @"
                INSERT INTO yemeksiparis.dbo.Log (CustemerID, LogDate, LogType, LogDetails, OrderID) 
                VALUES (@CustomerID, @LogDate, @LogType, @LogDetails, @OrderID)";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@CustomerID", customerId);
					command.Parameters.AddWithValue("@LogDate", logDate);
					command.Parameters.AddWithValue("@LogType", logType);
					command.Parameters.AddWithValue("@LogDetails", logDetails);
					command.Parameters.AddWithValue("@OrderID", orderId);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				
				MessageBox.Show($"Log kaydedilirken hata oluştu: {ex.Message}");
			}
		}


		private void UpdateStock(int orderId)
		{
			string query = @"
        UPDATE p
        SET p.Stok = p.Stok - od.Quantity
        FROM yemeksiparis.dbo.Products p
        INNER JOIN yemeksiparis.dbo.Orders od ON p.ProductID = od.ProductID
        WHERE od.OrderID = @OrderID";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@OrderID", orderId);

					connection.Open();
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Stok güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}



		
		private void UpdateCustomerBudget(int customerId, double totalOrderPrice)
		{
			string query = "UPDATE yemeksiparis.dbo.Custemers SET Budget = Budget - @TotalOrderPrice WHERE CustomerID = @CustomerID";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@TotalOrderPrice", totalOrderPrice);
					command.Parameters.AddWithValue("@CustomerID", customerId);

					connection.Open();
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Bütçe güncellenirken hata oluştu: {ex.Message}");
				}
			}
		}



		private double GetCustomerBudget(int customerId)
		{
			string query = "SELECT Budget FROM yemeksiparis.dbo.Custemers WHERE CustomerID = @CustomerID";
			double budget = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@CustomerID", customerId);

					connection.Open();
					object result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						budget = Convert.ToDouble(result); 
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Bütçe alınırken hata oluştu: {ex.Message}");
				}
			}

			return budget;
		}

		
		private double GetOrderTotalPrice(int orderId)
		{
			string query = "SELECT TotalPrice FROM yemeksiparis.dbo.Orders WHERE OrderID = @OrderID";
			double totalPrice = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@OrderID", orderId); 

					connection.Open();
					object result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						totalPrice = Convert.ToDouble(result); 
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Sipariş fiyatı hesaplanırken hata oluştu: {ex.Message}");
				}
			}

			return totalPrice;
		}


		private int GetCustomerIdForOrder(int orderId)
		{
			string query = "SELECT CustomerID FROM yemeksiparis.dbo.Orders WHERE OrderID = @OrderID";
			int customerId = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@OrderID", orderId);

					connection.Open();
					object result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						customerId = Convert.ToInt32(result);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Müşteri ID'si alınırken hata oluştu: {ex.Message}");
				}
			}

			return customerId;
		}

		private bool IsOrderProcessable(int orderId, int customerId, out string failureReason)
		{
			failureReason = string.Empty;

			
			double customerBudget = GetCustomerBudget(customerId);
			double totalOrderPrice = GetOrderTotalPrice(orderId);

			if (totalOrderPrice > customerBudget)
			{
				failureReason = "Sipariş, müşteri bütçesini aşıyor.";
				return false;
			}

			
			if (!IsStockSufficient(orderId, out string stockIssue))
			{
				failureReason = stockIssue;
				return false;
			}

			return true; 
		}

		private bool IsStockSufficient(int orderId, out string failureReason)
		{
			failureReason = string.Empty;

			string query = @"
        SELECT od.ProductID, od.Quantity, p.Stok
        FROM yemeksiparis.dbo.Orders od
        INNER JOIN yemeksiparis.dbo.Products p ON od.ProductID = p.ProductID
        WHERE od.OrderID = @OrderID";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@OrderID", orderId);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					int productId = reader.GetInt32(reader.GetOrdinal("ProductID"));
					int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
					int stock = reader.GetInt32(reader.GetOrdinal("Stok"));

					if (quantity > stock)
					{
						failureReason = $"Ürün {productId} için yeterli stok yok!";
						return false;
					}
				}
			}

			return true; 
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FiyatStokguncelle fs = new FiyatStokguncelle();
			this.Close();
			fs.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			AdminUrunEkleSil admn= new AdminUrunEkleSil();
			this.Close();
			admn.Show();
		}
	}
}
