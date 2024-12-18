using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemeksepeti
{
	public class Sorgu
	{
		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";

		public static string ConnectionString
		{
			get { return connectionString; }
		}

		public static string ResimleriGetirSorgusu()
		{
			return "SELECT ProductID, ProductName, Stok, Price, image FROM yemeksiparis.dbo.Products WHERE Stok > 0";

		}

		public bool ValidateUser(string username, string password, out int userId)
		{
			userId = 0; // Varsayılan değer, kullanıcı bulunamazsa 0 dönecek
			string query = "SELECT CustomerID FROM yemeksiparis.dbo.Custemurs WHERE CustomerName = @Username AND CustomerPassword = @Password";

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
	}
}
