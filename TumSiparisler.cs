using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemeksepeti
{
	public partial class TumSiparisler : Form
	{

		private int userıd;
		public TumSiparisler(int id)
		{
			InitializeComponent();
			this.userıd = id;	
		}

		private void TumSiparisler_Load(object sender, EventArgs e)
		{
			SiparisleriGetir();
		}
		public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";


		
		public static string ConnectionString
		{
			get { return connectionString; }
		}
		private void SiparisleriGetir()
		{
			
			string query = @"
			SELECT 
			o.OrderID,
			p.ProductName,
			o.Quantity,
			o.TotalPrice,
			o.OrderDate,
			o.OrderStatus
			FROM yemeksiparis.dbo.Orders o
			JOIN yemeksiparis.dbo.Products p ON o.ProductID = p.ProductID
            WHERE o.CustemerID = @userıd";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				
				command.Parameters.AddWithValue("@userıd", userıd);

				connection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable malzemeTable = new DataTable();
				adapter.Fill(malzemeTable);

				
				dataGridView1.DataSource = malzemeTable;
			}
			
			dataGridView1.Columns[0].HeaderText = "Sipariş No";  
			dataGridView1.Columns[1].HeaderText = "Ürün Adı";    
			dataGridView1.Columns[2].HeaderText = "Adet";         
			dataGridView1.Columns[3].HeaderText = "Toplam Fiyat"; 
			dataGridView1.Columns[4].HeaderText = "Tarih";       
			dataGridView1.Columns[5].HeaderText = "Durum";       
		}

	}
}
