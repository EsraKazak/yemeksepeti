namespace yemeksepeti
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Kullan�c�Form kullan�c� = new Kullan�c�Form();
			this.Hide();
			kullan�c�.Show();
			
		}
	}
}
