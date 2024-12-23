using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemeksepeti
{
	public class Sorgu
	{
		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";

		public static string ConnectionString
		{
			get { return connectionString; }
		}

		private int userıd;

		public static string ResimleriGetirSorgusu()
		{
			return "SELECT ProductID, ProductName, Stok, Price, image FROM yemeksiparis.dbo.Products WHERE Stok > 0";

		}

		public bool ValidateUser(string username, string password, out int userId)
		{
			userId = 0; // Varsayılan değer, kullanıcı bulunamazsa 0 dönecek
			string query = "SELECT CustomerID FROM yemeksiparis.dbo.Custemers WHERE CustomerName = @Username AND CustomerPassword = @Password";

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand(query, con);

					// Parametreleri ekleyelim
					cmd.Parameters.AddWithValue("@Username", username);
					cmd.Parameters.AddWithValue("@Password", password);

					// Sorguyu çalıştırıp sonucu alalım
					var result = cmd.ExecuteScalar();

					// Eğer sorgu bir sonuç döndürdüyse
					if (result != null)
					{
						userId = Convert.ToInt32(result); // Kullanıcı ID'sini döndür
						return true; // Kullanıcı doğrulandı
					}

					return false; // Kullanıcı bulunamadı
				}
				catch (Exception ex)
				{
					throw new Exception("Veritabanı hatası: " + ex.Message);
				}
			}
		}



		public bool SiparisEkleme(int customerId, int productId, int quantity, decimal totalPrice)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        INSERT INTO yemeksiparis.dbo.Orders (CustemerID, ProductID, Quantity, TotalPrice, OrderDate, OrderStatus) 
                        VALUES (@CustomerID, @ProductID, @Quantity, @TotalPrice, @OrderDate, @OrderStatus)";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@CustomerID", customerId);
						cmd.Parameters.AddWithValue("@ProductID", productId);
						cmd.Parameters.AddWithValue("@Quantity", quantity);
						cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
						cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now); 
						cmd.Parameters.AddWithValue("@OrderStatus", "Bekliyor"); 

						int rowsAffected = cmd.ExecuteNonQuery(); // Veritabanına veri ekle
						return rowsAffected > 0; 
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Veritabanı hatası: {ex.Message}");
				return false; 
			}
		}

		public bool ValidateAdmin(string username, string password)
		{
			string query = "SELECT COUNT(1) FROM yemeksiparis.dbo.Admin WHERE adminname = @Username AND adminpassword = @Password";



			using (SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand(query, con);

					// Parametreleri ekleyelim
					cmd.Parameters.AddWithValue("@Username", username);
					cmd.Parameters.AddWithValue("@Password", password);

					// Sorguyu çalıştırıp sonucu alalım
					int result = Convert.ToInt32(cmd.ExecuteScalar());

					return result == 1;
				}
				catch (Exception ex)
				{
					// Hata durumunda false döndür
					throw new Exception("Veritabanı hatası: " + ex.Message);
				}
			}
		}


		public void getorder(int userdID)
		{
			this.userıd=userdID;
			// SQL Sorgusu
			string query = @"
            SELECT 
                p.ProductName,
                p.Price AS UnitPrice,
                o.Quantity,
                (p.Price * o.Quantity) AS TotalPrice
            FROM 
               yemeksiparis.dbo.Orders AS o
            INNER JOIN 
               yemeksiparis.dbo.Products AS p ON o.ProductID = p.ProductID
            WHERE 
                o.CustemerID = @CustomerID";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open(); // Bağlantıyı açıyoruz

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						// Parametreyi ekliyoruz
						command.Parameters.AddWithValue("@CustomerID", userdID);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							DataTable dt = new DataTable();
							dt.Load(reader);

							// Veriyi başka bir forma gönderiyoruz
							SepetForm detayForm = new SepetForm(userdID);
							detayForm.SiparisVerisiniYolla(dt);
							detayForm.Show();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Veri alınırken bir hata oluştu: " + ex.Message);
			}



		}
}
}
