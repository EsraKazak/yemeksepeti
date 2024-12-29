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
		private int userid = 0;
		public Alisverisform(int id)
		{
			InitializeComponent();
			this.userid = id;
		}

		private void Alisverisform_Load(object sender, EventArgs e)
		{
			
			ResimleriGetir();
			
		}
		

		private void ResimleriGetir()
		{
			string query = Sorgu.ResimleriGetirSorgusu(); 
			using (SqlConnection connection = new SqlConnection(Sorgu.ConnectionString)) 
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				
				panel1.Controls.Clear();

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


					pictureBox.Click += (s, ev) =>
					{
						
						UrunPage urun = new UrunPage();
						urun.Goster(resim, productName, price, urunID, userid); 

						
						urun.ShowDialog(); 
										   
					};




					
					panel1.Controls.Add(pictureBox);
					panel1.Controls.Add(label);

					
					yPos += pictureBox.Height + padding; 
				}
				reader.Close();
			}


		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Sorgu sorgu = new Sorgu();
			sorgu.getorder(userid);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			TumSiparisler tm= new TumSiparisler(userid);
			tm.Show();
			
	
		}
	}
}
