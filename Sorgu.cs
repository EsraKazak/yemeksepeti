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
			userId = 0; 
			string query = "SELECT CustomerID FROM yemeksiparis.dbo.Custemers WHERE CustomerName = @Username AND CustomerPassword = @Password";

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand(query, con);

					
					cmd.Parameters.AddWithValue("@Username", username);
					cmd.Parameters.AddWithValue("@Password", password);

					
					var result = cmd.ExecuteScalar();

					
					if (result != null)
					{
						userId = Convert.ToInt32(result); 
						return true; 
					}

					return false; 
				}
				catch (Exception ex)
				{
					throw new Exception("Veritabanı hatası: " + ex.Message);
				}
			}
		}



		public static bool UrunEkle(string urunAdi, string urunfiyat, string urunstok, string resimyolu)
		{

			string query = "INSERT INTO yemeksiparis.dbo.Products (ProductName, Price, Stok, image) " +
						   "VALUES (@urunAdi, @urunfiyat, @urunstok, @resim);"; 

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
					cmd.Parameters.AddWithValue("@urunfiyat", urunfiyat);
					cmd.Parameters.AddWithValue("@urunstok", urunstok);
					cmd.Parameters.AddWithValue("@resim", resimyolu);
					

					conn.Open();
					
					object result = cmd.ExecuteScalar();
					

					return true;
				}
			}
		}

		public static bool UrunSil(int urunID)
		{
			try
			{
				string query = "DELETE FROM yemeksiparis.dbo.Products WHERE ProductID = @ProductID";
				using (SqlConnection connection = new SqlConnection(ConnectionString))
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@ProductID", urunID);
					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();
					return rowsAffected > 0; 
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message);
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

					
					cmd.Parameters.AddWithValue("@Username", username);
					cmd.Parameters.AddWithValue("@Password", password);

					
					int result = Convert.ToInt32(cmd.ExecuteScalar());

					return result == 1;
				}
				catch (Exception ex)
				{
					
					throw new Exception("Veritabanı hatası: " + ex.Message);
				}
			}
		}


		public void getorder(int userdID)
		{
			this.userıd=userdID;
			
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
					connection.Open(); 

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						
						command.Parameters.AddWithValue("@CustomerID", userdID);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							DataTable dt = new DataTable();
							dt.Load(reader);

							
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
