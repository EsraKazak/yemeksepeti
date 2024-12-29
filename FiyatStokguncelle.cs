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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace yemeksepeti
{
	public partial class FiyatStokguncelle : Form
	{
		public FiyatStokguncelle()
		{
			InitializeComponent();
			urungoruntuleme();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Adminİslem admn = new Adminİslem();
			this.Close();
			admn.Show();
		}

		private void FiyatStokguncelle_Load(object sender, EventArgs e)
		{

		}
		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";



		
		public static string ConnectionString
		{
			get { return connectionString; }
		}

		private void urungoruntuleme()
		{
			
			string query = "SELECT  ProductID ,ProductName ,Stok,Price FROM yemeksiparis.dbo.Products";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable malzemeTable = new DataTable();
				adapter.Fill(malzemeTable);

				
				dataGridView1.DataSource = malzemeTable;

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			if (dataGridView1.SelectedCells.Count > 0)
			{
				
				DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];

				
				int productId = Convert.ToInt32(dataGridView1.Rows[selectedCell.RowIndex].Cells["ProductID"].Value);

				
				string yeniStok = textBox2.Text; 
				string yeniFiyat = textBox3.Text; 

				
				string query = "UPDATE yemeksiparis.dbo.Products SET ";

				
				if (!string.IsNullOrEmpty(yeniStok))
				{
					query += "Stok = @yeniStok ";
				}

				if (!string.IsNullOrEmpty(yeniFiyat))
				{
					if (!string.IsNullOrEmpty(yeniStok))
					{
						query += ", "; 
					}
					query += "Price = @yeniFiyat ";
				}

				query += "WHERE ProductID = @productId";

			
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						
						if (!string.IsNullOrEmpty(yeniStok))
						{
							command.Parameters.AddWithValue("@yeniStok", yeniStok);
						}

						if (!string.IsNullOrEmpty(yeniFiyat))
						{
							command.Parameters.AddWithValue("@yeniFiyat", yeniFiyat);
						}

						command.Parameters.AddWithValue("@productId", productId);

						try
						{
							connection.Open();
							int rowsAffected = command.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								MessageBox.Show("Güncelleme başarılı!");
								urungoruntuleme(); 
							}
							else
							{
								MessageBox.Show("Güncelleme başarısız, ürün bulunamadı.");
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Hata: " + ex.Message);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Lütfen bir hücre seçin.");
			}


		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
			textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
			textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			
			if (dataGridView1.Columns[e.ColumnIndex].Name == "Stok" && e.Value != null)
			{
				int stokMiktar;

				
				if (int.TryParse(e.Value.ToString(), out stokMiktar))
				{
					
					if (stokMiktar == 0)
					{
						e.CellStyle.ForeColor = Color.Red; 
					}
					else if (stokMiktar < 3)
					{
						e.CellStyle.ForeColor = Color.Blue; 
					}
					else
					{
						e.CellStyle.ForeColor = Color.Black; 
					}
				}
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Adminİslem admn = new Adminİslem();
			this.Close();
			admn.Show();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			
			if (dataGridView1.SelectedCells.Count > 0)
			{
				
				DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];

				
				int productId = Convert.ToInt32(dataGridView1.Rows[selectedCell.RowIndex].Cells["ProductID"].Value);

				
				string yeniStok = textBox2.Text; 
				string yeniFiyat = textBox3.Text;

				
				string query = "UPDATE yemeksiparis.dbo.Products SET ";

				
				if (!string.IsNullOrEmpty(yeniStok))
				{
					query += "Stok = @yeniStok ";
				}

				if (!string.IsNullOrEmpty(yeniFiyat))
				{
					if (!string.IsNullOrEmpty(yeniStok))
					{
						query += ", "; 
					}
					query += "Price = @yeniFiyat ";
				}

				query += "WHERE ProductID = @productId";

				
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						
						if (!string.IsNullOrEmpty(yeniStok))
						{
							command.Parameters.AddWithValue("@yeniStok", yeniStok);
						}

						if (!string.IsNullOrEmpty(yeniFiyat))
						{
							command.Parameters.AddWithValue("@yeniFiyat", yeniFiyat);
						}

						command.Parameters.AddWithValue("@productId", productId);

						try
						{
							connection.Open();
							int rowsAffected = command.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								MessageBox.Show("Güncelleme başarılı!");
								urungoruntuleme();
							}
							else
							{
								MessageBox.Show("Güncelleme başarısız, ürün bulunamadı.");
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Hata: " + ex.Message);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Lütfen bir hücre seçin.");
			}
		}
	}
}
