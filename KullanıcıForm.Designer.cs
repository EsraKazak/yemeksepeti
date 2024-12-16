namespace yemeksepeti
{
	partial class KullanıcıForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullanıcıForm));
			panel1 = new Panel();
			button1 = new Button();
			textBox2 = new TextBox();
			textBox1 = new TextBox();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
			panel1.BackgroundImageLayout = ImageLayout.Stretch;
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(textBox1);
			panel1.Location = new Point(1, -1);
			panel1.Name = "panel1";
			panel1.Size = new Size(544, 549);
			panel1.TabIndex = 0;
			// 
			// button1
			// 
			button1.BackColor = Color.Transparent;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
			button1.Location = new Point(189, 195);
			button1.Name = "button1";
			button1.Size = new Size(134, 39);
			button1.TabIndex = 2;
			button1.Text = "Giriş";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// textBox2
			// 
			textBox2.BorderStyle = BorderStyle.None;
			textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
			textBox2.Location = new Point(155, 146);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(214, 27);
			textBox2.TabIndex = 1;
			textBox2.Text = "Şifre";
			textBox2.UseSystemPasswordChar = true;
			textBox2.TextChanged += textBox2_TextChanged;
			// 
			// textBox1
			// 
			textBox1.BackColor = SystemColors.Window;
			textBox1.BorderStyle = BorderStyle.None;
			textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
			textBox1.ForeColor = SystemColors.WindowText;
			textBox1.Location = new Point(155, 97);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(214, 27);
			textBox1.TabIndex = 0;
			textBox1.Text = "Kullanıcı Adı";
			textBox1.TextChanged += textBox1_TextChanged;
			textBox1.Enter += TextBox_Enter;
			textBox1.Leave += TextBox_Leave;
			// 
			// KullanıcıForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(545, 548);
			Controls.Add(panel1);
			Name = "KullanıcıForm";
			Text = "KullanıcıForm";
			Load += KullanıcıForm_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Button button1;
		private TextBox textBox2;
		private TextBox textBox1;
	}
}