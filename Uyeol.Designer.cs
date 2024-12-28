namespace yemeksepeti
{
	partial class Uyeol
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uyeol));
			panel1 = new Panel();
			button2 = new Button();
			button1 = new Button();
			textBox2 = new TextBox();
			textBox1 = new TextBox();
			label2 = new Label();
			label1 = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
			panel1.BackgroundImageLayout = ImageLayout.Stretch;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(1, 1);
			panel1.Name = "panel1";
			panel1.Size = new Size(485, 450);
			panel1.TabIndex = 0;
			// 
			// button2
			// 
			button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
			button2.BackgroundImageLayout = ImageLayout.Stretch;
			button2.Location = new Point(0, 0);
			button2.Name = "button2";
			button2.Size = new Size(85, 45);
			button2.TabIndex = 5;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
			button1.Location = new Point(159, 206);
			button1.Name = "button1";
			button1.Size = new Size(126, 39);
			button1.TabIndex = 4;
			button1.Text = "Kayıt Ol";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(220, 142);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(150, 27);
			textBox2.TabIndex = 3;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(220, 91);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(150, 27);
			textBox1.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.Transparent;
			label2.FlatStyle = FlatStyle.Flat;
			label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
			label2.Location = new Point(75, 141);
			label2.Name = "label2";
			label2.Size = new Size(129, 25);
			label2.TabIndex = 1;
			label2.Text = "Kullanıcı Şifre:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.Transparent;
			label1.FlatStyle = FlatStyle.Flat;
			label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
			label1.Location = new Point(75, 90);
			label1.Name = "label1";
			label1.Size = new Size(119, 25);
			label1.TabIndex = 0;
			label1.Text = "Kullanıcı Adı:";
			// 
			// Uyeol
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(487, 450);
			Controls.Add(panel1);
			Name = "Uyeol";
			Text = "Üyeol";
			Load += Uyeol_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label1;
		private Button button1;
		private TextBox textBox2;
		private TextBox textBox1;
		private Label label2;
		private Button button2;
	}
}