using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemeksepeti
{
	public partial class AdminLogin : Form
	{
		public AdminLogin()
		{
			InitializeComponent();
			textBox1.Enter += TextBox_Enter;
			textBox1.Leave += TextBox_Leave;

			textBox2.Enter += TextBox_Enter;
			textBox2.Leave += TextBox_Leave;
		}

		private void AdminLogin_Load(object sender, EventArgs e)
		{

		}

		private void TextBox_Enter(object sender, EventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (textBox != null && (textBox.Text == "Admin " || textBox.Text == "Şifre"))
			{
				textBox.Text = string.Empty;
				textBox.ForeColor = Color.Black;
			}
		}

		private void TextBox_Leave(object sender, EventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
			{
				textBox.Text = textBox == textBox1 ? "Admin " : "Şifre";
				textBox.ForeColor = Color.Silver;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string username = textBox1.Text;
			string password = textBox2.Text;

			Sorgu userService = new Sorgu();
			bool isValidUser = userService.ValidateAdmin(username, password);

			if (isValidUser)
			{
				Adminİslem avm = new Adminİslem();
				this.Close();
				avm.Show();

			}
			else
			{
				MessageBox.Show("Geçersiz kullanıcı adı veya şifre!");
			}
		}
	}
}
