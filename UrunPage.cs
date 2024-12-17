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
		public UrunPage()
		{
			InitializeComponent();
		}

		private void UrunPage_Load(object sender, EventArgs e)
		{

		}

		public void Goster(Image resim, string urunAd, decimal fiyat,int ID)
		{
			pictureBox1.Image = resim;
			label1.Text = urunAd;
			label2.Text = $"Fiyat: {fiyat:C}";

			//TarifID = tarifID;

			// Malzemeleri veritabanından çek ve listbox'a ekle
			/*List<string> malzemeler = sorgu.GetTarifMalzemeler(tarifID);
			listBox1.Items.Clear(); // ListBox'ı temizle
			foreach (string malzeme in malzemeler)
			{
				listBox1.Items.Add(malzeme); // Malzemeleri listbox'a ekle
			}*/
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
