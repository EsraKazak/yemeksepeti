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
			KullaniciForm kullan�c� = new KullaniciForm();
			
			kullan�c�.Show();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			AdminLogin adm = new AdminLogin();
			
			adm.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Uyeol uye = new Uyeol();
			
			uye.Show();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
