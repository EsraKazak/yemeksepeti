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
		public Adminİslem()
		{
			InitializeComponent();
			musterisiparisbilgi();
		}

		private void Adminİslem_Load(object sender, EventArgs e)
		{

		}

		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";



		// Bağlantı dizesini döndüren bir özellik ekliyoruz
		public static string ConnectionString
		{
			get { return connectionString; }
		}
		private void musterisiparisbilgi()
		{
			// Veritabanından sipariş bilgilerini çekme
			string query = "SELECT OrderID, CustemerID, ProductID, Quantity, TotalPrice, OrderDate, OrderStatus FROM yemeksiparis.dbo.Orders";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable ordersTable = new DataTable();
				adapter.Fill(ordersTable);

				// DataGridView'ı doldurma
				dataGridView1.DataSource = ordersTable;
			}
		}

	}
}
