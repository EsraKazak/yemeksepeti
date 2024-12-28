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
	public partial class Uyeol : Form
	{
		public Uyeol()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			YeniUyeOlustur(textBox1.Text, textBox2.Text);
			Form1 form = new Form1();
			form.Show();
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form1 form = new Form1();
			form.Show();
			this.Close();
		}

		public void YeniUyeOlustur(string username, string password)
		{
			
			Random random = new Random();
			double budget = random.Next(500, 3001); 

			
			string[] customerTypes = { "Premium", "Standart" };
			string customerType = customerTypes[random.Next(customerTypes.Length)];

			
			string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					
					string query = "INSERT INTO yemeksiparis.dbo.Custemers (CustomerName, CustomerPassword, Budget, CustomerType) " +
								   "VALUES (@Username, @Password, @Budget, @CustomerType)";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@Username", username);
					command.Parameters.AddWithValue("@Password", password);
					command.Parameters.AddWithValue("@Budget", budget);
					command.Parameters.AddWithValue("@CustomerType", customerType);

					connection.Open();
					command.ExecuteNonQuery();
					MessageBox.Show("Yeni kullanıcı başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Kullanıcı oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void Uyeol_Load(object sender, EventArgs e)
		{

		}
	}
}
