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
	public partial class AdminUrunEkleSil : Form
	{
		public AdminUrunEkleSil()
		{
			InitializeComponent();
		}

		private void AdminUrunEkleSil_Load(object sender, EventArgs e)
		{
			UrunleriGoster();
		}


		private void UrunleriGoster()
		{
			string query = "SELECT ProductID, ProductName, Stok, Price, image FROM yemeksiparis.dbo.Products";
			using (SqlConnection connection = new SqlConnection(Sorgu.ConnectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();


				panel3.Controls.Clear();

				int xPos = 10;
				int yPos = 10;
				int padding = 20;

				while (reader.Read())
				{

					int urunID = Convert.ToInt32(reader["ProductID"]);
					string resimYolu = reader["image"].ToString();
					string productName = reader["ProductName"].ToString();
					int stok = Convert.ToInt32(reader["Stok"]);
					decimal price = Convert.ToDecimal(reader["Price"]);


					Image resim = Image.FromFile(resimYolu);


					PictureBox pictureBox = new PictureBox();
					pictureBox.Image = resim;
					pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					pictureBox.Size = new Size(150, 150);
					pictureBox.Location = new Point(xPos, yPos);


					Label label = new Label();
					label.Text = $"Ürün Adı: {productName}\nStok: {stok}\nFiyat: {price:C}";
					label.AutoSize = false;
					label.Size = new Size(300, 150);
					label.Font = new Font("Arial", 10, FontStyle.Regular);
					label.TextAlign = ContentAlignment.MiddleLeft;
					label.Location = new Point(xPos + pictureBox.Width + 20, yPos);


					ProgressBar stokGrafik = new ProgressBar();
					stokGrafik.Minimum = 0;
					stokGrafik.Maximum = 10;
					stokGrafik.Value = stok <= 10 ? stok : 10;
					stokGrafik.Size = new Size(200, 20);


					stokGrafik.Location = new Point(xPos + pictureBox.Width + 400, yPos + (pictureBox.Height / 2) - (stokGrafik.Height / 2));


					stokGrafik.ForeColor = Color.Green;


					CheckBox checkBox = new CheckBox();
					checkBox.Text = "Sil";
					checkBox.Tag = urunID;
					checkBox.Location = new Point(xPos + pictureBox.Width + 350, yPos + (pictureBox.Height / 2) - (checkBox.Height / 2));


					panel3.Controls.Add(pictureBox);
					panel3.Controls.Add(label);
					panel3.Controls.Add(stokGrafik);
					panel3.Controls.Add(checkBox);


					yPos = Math.Max(yPos + Math.Max(pictureBox.Height, stokGrafik.Height) + padding, label.Bottom + padding);
				}

				reader.Close();
			}

		}


		private void pictureBox1_Click(object sender, EventArgs e)
		{

			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Resim Seç";
			openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";


			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{

				pictureBox1.ImageLocation = openFileDialog.FileName;


				label1.Visible = false;
				label2.Text = openFileDialog.FileName;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{

			string siparisAdi = textBox1.Text.Trim();
			string siparisfiyat = textBox2.Text.Trim();
			string siparisstok = textBox3.Text.Trim();
			string resimYolu = label2.Text.Trim();



			if (string.IsNullOrEmpty(siparisAdi) || string.IsNullOrEmpty(siparisfiyat) ||
				string.IsNullOrEmpty(siparisstok) || string.IsNullOrEmpty(resimYolu))
			{
				MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			bool tarifBasari = Sorgu.UrunEkle(siparisAdi, siparisfiyat, siparisstok, resimYolu);
			if (tarifBasari)
			{
				MessageBox.Show("Tarif başarıyla eklendi.");
				this.Close();
				Form1 frm = new Form1();
				frm.ShowDialog();

				AddLog(0, DateTime.Now, "Bilgi", $"Ürün '{siparisAdi}' eklendi", 0);
			}
			else
			{
				MessageBox.Show("Tarif eklenirken bir hata oluştu.");

				AddLog(0, DateTime.Now, "Hata", $"Ürün '{siparisAdi}' eklenirken hata oluştu.", 0);
			}

			UrunleriGoster();
		}

		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";

		public static string ConnectionString
		{
			get { return connectionString; }
		}


		private void AddLog(int customerId, DateTime logDate, string logType, string logDetails, int orderId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = @"
                INSERT INTO yemeksiparis.dbo.Log (CustomerID, LogDate, LogType, LogDetails, OrderID) 
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
		private void button2_Click(object sender, EventArgs e)
		{
			foreach (Control control in panel3.Controls)
			{
				if (control is CheckBox checkBox && checkBox.Checked)
				{

					int urunID = (int)checkBox.Tag;

					bool silindiMi = Sorgu.UrunSil(urunID);
					if (silindiMi)
					{
						MessageBox.Show($"Ürün {urunID} başarıyla silindi.");
					}
					else
					{
						MessageBox.Show($"Ürün {urunID} silinirken bir hata oluştu.");
					}
				}
			}
			UrunleriGoster();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Adminİslem adm=new Adminİslem();
			adm.Show();
			this.Close();
		}
	}
}
