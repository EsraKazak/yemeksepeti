using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace yemeksepeti
{
	public partial class UrunPage : Form
	{
		private int UserID;
		private int urunID;
		private decimal urunFiyat;
		public UrunPage()
		{
			InitializeComponent();
		}

		private void UrunPage_Load(object sender, EventArgs e)
		{

		}

		public void Goster(Image resim, string urunAd, decimal fiyat,int urunID, int userıd)
		{
			this.urunID= urunID;
			this.urunFiyat= fiyat;
			this.UserID = userıd;
			pictureBox1.Image = resim;
			label1.Text = urunAd;
			label2.Text = $"Fiyat: {fiyat:C}";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int adet=(int)numericUpDown1.Value;
			if(adet>5)
			{
				MessageBox.Show("en fazla 5 adet sipariş verebilirsiniz!");
				return;
			}
			decimal toplamFiyat = adet * urunFiyat;

			try
			{
				Sorgu sorgu = new Sorgu();
				bool isSuccess = sorgu.SiparisEkleme(UserID, urunID, adet, toplamFiyat);

				if (isSuccess)
				{
					MessageBox.Show("Ürün başarıyla sepete eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Sepete eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
	}
}
