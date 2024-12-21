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
	public partial class Adminİslem : Form
	{

		private Thread refreshThread;
		private bool isThreadRunning;
		public Adminİslem()
		{
			InitializeComponent();
		
		}

		private void Adminİslem_Load(object sender, EventArgs e)
		{
			StartOrderUpdateThread();
		}

		private void StartOrderUpdateThread()
		{
			isThreadRunning = true;

			// Thread başlatıyoruz
			refreshThread = new Thread(() =>
			{
				while (isThreadRunning)
				{
					// Yeni siparişleri veritabanından çekiyoruz
					RefreshOrders();

					// 3 saniye bekliyoruz
					Thread.Sleep(3000);
				}
			});

			refreshThread.Start();
		}

		private void RefreshOrders()
		{
			// Siparişleri veritabanından çekiyoruz
			DataTable orders = GetOrdersFromDatabase();

			// UI thread'ine dönüyoruz (UI thread'inde işlem yapılabilir)
			Invoke((MethodInvoker)delegate
			{
				dataGridView1.DataSource = orders; // Siparişleri DataGridView'e yansıtıyoruz
			});
		}
		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";



		// Bağlantı dizesini döndüren bir özellik ekliyoruz
		public static string ConnectionString
		{
			get { return connectionString; }
		}


		private DataTable GetOrdersFromDatabase()
		{
			string query = "SELECT o.OrderID, p.ProductName, o.Quantity, o.TotalPrice, o.OrderDate,o.OrderStatus FROM yemeksiparis.dbo.Orders o INNER JOIN yemeksiparis.dbo.Products p ON o.ProductID = p.ProductID";

			using (SqlConnection connection = new SqlConnection(Sorgu.connectionString))
			{
				try
				{
					SqlDataAdapter da = new SqlDataAdapter(query, connection);
					DataTable dt = new DataTable();
					da.Fill(dt); // Veriyi çekiyoruz ve DataTable'a yüklüyoruz
					return dt;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Veritabanı hatası: " + ex.Message);
					return null;
				}
			}
		}

		private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			isThreadRunning = false; // Thread'i durduruyoruz
			if (refreshThread != null && refreshThread.IsAlive)
			{
				refreshThread.Join(); // Thread'in bitmesini bekliyoruz
			}
		}

	}
}
