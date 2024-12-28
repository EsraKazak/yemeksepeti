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
	public partial class KullaniciForm : Form
	{
		
		public KullaniciForm()
		{
			InitializeComponent();
			textBox1.Enter += TextBox_Enter;
			textBox1.Leave += TextBox_Leave;

			textBox2.Enter += TextBox_Enter;
			textBox2.Leave += TextBox_Leave;


		}


		private void TextBox_Enter(object sender, EventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (textBox != null && (textBox.Text == "Kullanıcı Adı" || textBox.Text == "Şifre"))
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
				textBox.Text = textBox == textBox1 ? "Kullanıcı Adı" : "Şifre";
				textBox.ForeColor = Color.Silver;
			}
		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			string username = textBox1.Text.Trim();
			string password = textBox2.Text.Trim();

			
			Sorgu sorgu = new Sorgu();
			int userId;

			bool isValid = sorgu.ValidateUser(username, password, out userId);

			if (isValid)
			{

				
				Task.Run(() =>
				{
					
					Alisverisform avm = new Alisverisform(userId);

					
					avm.FormClosed += (s, args) => Application.ExitThread();

					
					Application.Run(avm);
				});

				
			}
			else
			{
				
				MessageBox.Show("Geçersiz kullanıcı adı veya şifre!");
			}
		}


		private void KullanıcıForm_Load(object sender, EventArgs e)
		{

		}
	}
}
