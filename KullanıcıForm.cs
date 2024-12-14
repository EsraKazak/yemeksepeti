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
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			textBox2.BackColor = Color.Transparent;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			textBox2.BackColor = Color.Transparent;
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
