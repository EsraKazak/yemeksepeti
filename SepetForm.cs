using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemeksepeti
{
	public partial class SepetForm : Form
	{
		private int userıd;
		public SepetForm(int userID)
		{
			InitializeComponent();
			this.userıd = userID;
		}

		private void SepetForm_Load(object sender, EventArgs e)
		{
			Sorgu sorgu = new Sorgu();
			
			List<Sepet> sepet = SepetManager.GetSepet(userıd);
			dataGridView1.DataSource = sepet.Select(item => new
			{
				item.ProductID,
				item.ProductName,
				item.Quantity,
				item.UnitPrice,
				item.TotalPrice
			}).ToList();

		}
		public void SiparisVerisiniYolla(DataTable orderData)
		{
			
			dataGridView1.DataSource = orderData;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				List<Sepet> sepet = SepetManager.GetSepet(userıd); 

				using (SqlConnection connection = new SqlConnection(Sorgu.ConnectionString))
				{
					connection.Open();

					foreach (var item in sepet)
					{
						
						string query = "INSERT INTO yemeksiparis.dbo.Orders (CustemerID, ProductID, Quantity, TotalPrice, OrderDate, OrderStatus) VALUES (@UserID, @ProductID, @Quantity, @TotalPrice, @OrderDate, @OrderStatus); SELECT SCOPE_IDENTITY();";
						SqlCommand command = new SqlCommand(query, connection);

						command.Parameters.AddWithValue("@UserID", userıd); 
						command.Parameters.AddWithValue("@ProductID", item.ProductID);
						command.Parameters.AddWithValue("@Quantity", item.Quantity);
						command.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);
						command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
						command.Parameters.AddWithValue("@OrderStatus", "Bekliyor");

						int orderID = Convert.ToInt32(command.ExecuteScalar());
					}
				}

				MessageBox.Show("Siparişler başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

				SepetManager.SepetiTemizle(userıd); 
				this.Close(); 
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
	}
}
