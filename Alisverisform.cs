using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace yemeksepeti
{
	public partial class Alisverisform : Form
	{
		 int userıd=0;
		public Alisverisform()
		{
			InitializeComponent();
			

		}

		private void Alisverisform_Load(object sender, EventArgs e)
		{
			MessageBox.Show($"avm Kullanıcı ID: {userıd}");
			ResimleriGetir();
		}
		public void SetUserId(int id)
		{
			this.userıd = id;
		}

		private void ResimleriGetir()
		{
			string query = Sorgu.ResimleriGetirSorgusu(); // Sorguyu Sorgu sınıfından çekiyoruz
			using (SqlConnection connection = new SqlConnection(Sorgu.ConnectionString)) // connectionString'i Sorgu sınıfından alıyoruz
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Paneldeki önceki kontrolleri temizleyelim
				panel1.Controls.Clear();

				int xPos = 10; // Resmin başlangıç yatay pozisyonu
				int yPos = 10; // Resmin başlangıç dikey pozisyonu
				int padding = 20; // Resimler arasındaki boşluk

				while (reader.Read())
				{
					// Verileri tablodan çekiyoruz
					int urunID = Convert.ToInt32(reader["ProductID"]);
					string resimYolu = reader["image"].ToString(); // Resim yolu
					string productName = reader["ProductName"].ToString(); // Ürün adı
					int stok = Convert.ToInt32(reader["Stok"]); // Stok miktarı
					decimal price = Convert.ToDecimal(reader["Price"]); // Ürün fiyatı

					// Resmi dosya yolundan yükle
					Image resim = Image.FromFile(resimYolu);

					// Resim için PictureBox oluştur
					PictureBox pictureBox = new PictureBox();
					pictureBox.Image = resim;
					pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					pictureBox.Size = new Size(150, 150); // Resim boyutu
					pictureBox.Location = new Point(xPos, yPos); // Resmin konumu

					// Açıklamalar için Label oluştur
					Label label = new Label();
					label.Text = $"Ürün Adı: {productName}\nStok: {stok}\nFiyat: {price:C}\nId: {userıd}";
					label.AutoSize = false;
					label.Size = new Size(300, 150); // Açıklama alanı genişliği
					label.Font = new Font("Arial", 10, FontStyle.Regular);
					label.TextAlign = ContentAlignment.MiddleLeft;
					label.Location = new Point(xPos + pictureBox.Width + 20, yPos); // Resmin sağına konumlandırıldı


					pictureBox.Click += (s, ev) =>
					{
						// Detay formunu gösterelim
						UrunPage urun = new UrunPage();
						urun.Goster(resim, productName, price, urunID); // Bilgileri geçiriyoruz

						this.Hide();
						urun.ShowDialog(); // UrunPage'i modal olarak göster
						this.Show(); // UrunPage kapandıktan sonra AlisverisForm'u yeniden göster
					};




					// Panel'e PictureBox ve Label ekle
					panel1.Controls.Add(pictureBox);
					panel1.Controls.Add(label);

					// Dikey pozisyonu güncelle (Bir sonraki ürün için)
					yPos += pictureBox.Height + padding; // Bir sonraki resim altına eklenir
				}
				reader.Close();
			}


		}

		private void label1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
