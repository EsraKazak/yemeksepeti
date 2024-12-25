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
	public partial class FiyatStok_güncelle : Form
	{
		public FiyatStok_güncelle()
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

		private void FiyatStok_güncelle_Load(object sender, EventArgs e)
		{

		}
		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";



		// Bağlantı dizesini döndüren bir özellik ekliyoruz
		public static string ConnectionString
		{
			get { return connectionString; }
		}

		private void urungoruntuleme()
		{
			// Veritabanından malzeme bilgilerini çekme
			string query = "SELECT  ProductID ,ProductName ,Stok,Price FROM yemeksiparis.dbo.Products";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable malzemeTable = new DataTable();
				adapter.Fill(malzemeTable);

				// DataGridView'ı doldurma
				dataGridView1.DataSource = malzemeTable;

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// Seçilen hücreyi kontrol et
			if (dataGridView1.SelectedCells.Count > 0)
			{
				// Seçilen hücreyi al
				DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];

				// ProductID'yi al
				int productId = Convert.ToInt32(dataGridView1.Rows[selectedCell.RowIndex].Cells["ProductID"].Value);

				// Yeni değerleri al
				string yeniStok = textBox2.Text; // Yeni stok miktarı
				string yeniFiyat = textBox3.Text; // Yeni fiyat

				// Güncelleme sorgusu oluştur
				string query = "UPDATE yemeksiparis.dbo.Products SET ";

				// Güncellenecek alanları kontrol et
				if (!string.IsNullOrEmpty(yeniStok))
				{
					query += "Stok = @yeniStok ";
				}

				if (!string.IsNullOrEmpty(yeniFiyat))
				{
					if (!string.IsNullOrEmpty(yeniStok))
					{
						query += ", "; // Eğer hem stok hem de fiyat güncelleniyorsa araya virgül ekle
					}
					query += "Price = @yeniFiyat ";
				}

				query += "WHERE ProductID = @productId";

				// Veritabanı işlemleri
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						// Parametreleri ekle
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
								urungoruntuleme(); // Güncellenen ürün listesini tekrar yükle
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
			// Stok sütunu kontrolü (2. sütun - Stok)
			if (dataGridView1.Columns[e.ColumnIndex].Name == "Stok" && e.Value != null)
			{
				int stokMiktar;

				// Stok değeri bir sayı mı kontrol et
				if (int.TryParse(e.Value.ToString(), out stokMiktar))
				{
					// Stok miktarına göre renk belirleme
					if (stokMiktar == 0)
					{
						e.CellStyle.ForeColor = Color.Red; // Stok 0 ise kırmızı
					}
					else if (stokMiktar < 3)
					{
						e.CellStyle.ForeColor = Color.Blue; // Stok 3'ün altındaysa mavi
					}
					else
					{
						e.CellStyle.ForeColor = Color.Black; // Diğer durumlarda siyah
					}
				}
			}
		}

	}
}
