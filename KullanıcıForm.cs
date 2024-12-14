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
	public partial class KullanıcıForm : Form
	{
		public KullanıcıForm()
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
			Alisverisform avm =new Alisverisform();
			this.Hide();
			avm.Show();
		}

		private void KullanıcıForm_Load(object sender, EventArgs e)
		{

		}
	}
}
