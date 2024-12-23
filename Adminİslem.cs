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
		private static SemaphoreSlim semaphore = new SemaphoreSlim(5);  // Aynı anda 5 siparişin onaylanmasına izin veriyoruz.
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
					Thread.Sleep(3000);  // 3 saniyede bir siparişleri güncelle
				}
			});

			refreshThread.Start();
		}

		private void RefreshOrders()
		{
			List<Siparis> orders = GetOrdersFromDatabase();

			// Siparişleri öncelik skorlarına göre sırala
			var orderedByPriority = orders.OrderByDescending(o => o.PrioritizationScore).ToList();

			// UI thread'ine dönüyoruz ve sıralanmış siparişleri DataGridView'e yansıtıyoruz
			Invoke((MethodInvoker)delegate
			{
				dataGridView1.DataSource = orderedByPriority;
			});
		}

		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";

		// Sipariş sınıfı, her siparişin öncelik skoru ile birlikte hesaplanmasını sağlar
		public class Siparis
		{
			public int OrderID { get; set; }
			public int CustemerID { get; set; }  // Bu doğru şekilde güncellenecek
			public DateTime OrderDate { get; set; }
			public double PrioritizationScore { get; set; }
		}

		private List<Siparis> GetOrdersFromDatabase()
		{
			List<Siparis> orders = new List<Siparis>();

			// CustemerID'yi doğru kullanıyoruz
			string query = "SELECT OrderID, CustemerID, OrderDate FROM yemeksiparis.dbo.Orders WHERE OrderStatus = 'Bekliyor'";

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
						CustemerID = reader.GetInt32(reader.GetOrdinal("CustemerID")), // CustemerID doğru şekilde alınıyor
						OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"))
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

			// Her siparişin öncelik skorunu hesapla
			foreach (var order in orders)
			{
				// Öncelik skorunu hesapla
				order.PrioritizationScore = CalculatePrioritizationScore(order.CustemerID, order.OrderDate);
			}

			// Siparişleri öncelik sırasına göre sıralıyoruz
			var sortedOrders = orders.OrderByDescending(o => o.PrioritizationScore).ToList();

			// Siparişleri sırayla işliyoruz
			foreach (var order in sortedOrders)
			{
				int customerId = order.CustemerID;

				// Bütçe kontrolü ile siparişi onaylıyoruz
				await ApproveOrderAsync(order.OrderID, customerId);
			}
		}

		private double CalculatePrioritizationScore(int customerId, DateTime orderDate)
		{
			// Müşteri türünü kontrol et (Premium veya Normal)
			int basicPriorityScore = GetCustomerPriority(customerId);

			// Bekleme süresi hesaplama (sipariş verildiği zamandan bugüne kadar geçen süre)
			TimeSpan waitingTime = DateTime.Now - orderDate;

			// Bekleme süresi ağırlığı
			double waitingTimeWeight = 0.5;

			// Öncelik skoru hesapla
			double prioritizationScore = basicPriorityScore + (waitingTime.TotalSeconds * waitingTimeWeight);

			return prioritizationScore;
		}

		private int GetCustomerPriority(int customerId)
		{
			// CustomerID'yi doğru kullanarak müşteri türünü alıyoruz
			string query = "SELECT CustomerType FROM yemeksiparis.dbo.Custemers WHERE CustomerID = @CustomerID";
			int priorityScore = 10;  // Default normal müşteriler için temel öncelik skoru

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@CustomerID", customerId); // CustomerID burada doğru şekilde kullanılıyor
				connection.Open();

				object result = command.ExecuteScalar();
				if (result != DBNull.Value)
				{
					string customerType = result.ToString();
					if (customerType == "Premium")
					{
						priorityScore = 15;  // Premium müşteriler için temel öncelik skoru
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
				// Müşterinin bütçesini al
				double customerBudget = GetCustomerBudget(customerId);

				// Siparişin toplam fiyatını al
				double totalOrderPrice = GetOrderTotalPrice(orderId);

				// Bütçeyi kontrol et
				if (totalOrderPrice <= customerBudget)
				{
					// Bütçeyi aşmıyorsa siparişi onayla
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						string query = "UPDATE yemeksiparis.dbo.Orders SET OrderStatus = 'Onaylandı' WHERE OrderID = @OrderID";
						SqlCommand command = new SqlCommand(query, connection);
						command.Parameters.AddWithValue("@OrderID", orderId);

						connection.Open();
						command.ExecuteNonQuery();
					}

					// Sipariş onaylandığında müşterinin bütçesini güncelle
					UpdateCustomerBudget(customerId, totalOrderPrice);

					MessageBox.Show($"Sipariş {orderId} onaylandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					// Bütçeyi aşıyorsa siparişi reddet
					MessageBox.Show($"Sipariş {orderId} bütçeyi aşıyor ve onaylanmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Sipariş onaylanırken hata oluştu: {ex.Message}");
			}
			finally
			{
				semaphore.Release();  // Semafor iznini serbest bırak
			}

			// Siparişler güncelleniyor
			RefreshOrders();
		}

		// Müşterinin bütçesini güncelleyen fonksiyon
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


		// Müşterinin bütçesini almak için
		private double GetCustomerBudget(int customerId)
		{
			string query = "SELECT Budget FROM yemeksiparis.dbo.Custemers WHERE CustomerID = @CustomerID";
			double budget = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@CustomerID", customerId); // Müşteri ID'sini alıyoruz

					connection.Open();
					object result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						budget = Convert.ToDouble(result); // Bütçeyi alıyoruz
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Bütçe alınırken hata oluştu: {ex.Message}");
				}
			}

			return budget;
		}

		// Siparişin toplam fiyatını almak için
		private double GetOrderTotalPrice(int orderId)
		{
			string query = "SELECT TotalPrice FROM yemeksiparis.dbo.Orders WHERE OrderID = @OrderID";
			double totalPrice = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@OrderID", orderId); // Sipariş ID'sini alıyoruz

					connection.Open();
					object result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						totalPrice = Convert.ToDouble(result); // Toplam fiyatı alıyoruz
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

	}
}
