namespace yemeksepeti
{
	partial class AdminUrunEkleSil
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
			panel1 = new Panel();
			button1 = new Button();
			textBox3 = new TextBox();
			textBox2 = new TextBox();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			textBox1 = new TextBox();
			label2 = new Label();
			label1 = new Label();
			panel2 = new Panel();
			pictureBox1 = new PictureBox();
			panel3 = new Panel();
			button2 = new Button();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(pictureBox1);
			panel1.Location = new Point(1, -3);
			panel1.Name = "panel1";
			panel1.Size = new Size(801, 211);
			panel1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Location = new Point(291, 152);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 10;
			button1.Text = "Ürün Ekle";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(277, 119);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(125, 27);
			textBox3.TabIndex = 9;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(277, 73);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(125, 27);
			textBox2.TabIndex = 8;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(188, 119);
			label5.Name = "label5";
			label5.Size = new Size(83, 20);
			label5.TabIndex = 7;
			label5.Text = "Ürün Stoğu";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(188, 76);
			label4.Name = "label4";
			label4.Size = new Size(83, 20);
			label4.TabIndex = 6;
			label4.Text = "Ürün Fiyatı ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(188, 36);
			label3.Name = "label3";
			label3.Size = new Size(67, 20);
			label3.TabIndex = 5;
			label3.Text = "Ürün Adı";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(277, 33);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(125, 27);
			textBox1.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(737, 12);
			label2.Name = "label2";
			label2.Size = new Size(50, 20);
			label2.TabIndex = 3;
			label2.Text = "label2";
			// 
			// label1
			// 
			label1.Location = new Point(42, 23);
			label1.Name = "label1";
			label1.Size = new Size(59, 88);
			label1.TabIndex = 2;
			label1.Text = "Resim seçmek için tıklayın";
			// 
			// panel2
			// 
			panel2.BackColor = Color.SeaGreen;
			panel2.Location = new Point(0, 197);
			panel2.Name = "panel2";
			panel2.Size = new Size(798, 10);
			panel2.TabIndex = 1;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(149, 188);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.Click += pictureBox1_Click;
			// 
			// panel3
			// 
			panel3.AutoScroll = true;
			panel3.Location = new Point(1, 210);
			panel3.Name = "panel3";
			panel3.Size = new Size(798, 280);
			panel3.TabIndex = 1;
			// 
			// button2
			// 
			button2.Location = new Point(410, 152);
			button2.Name = "button2";
			button2.Size = new Size(94, 29);
			button2.TabIndex = 11;
			button2.Text = "Ürün Sil";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// AdminUrunEkleSil
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 492);
			Controls.Add(panel3);
			Controls.Add(panel1);
			Name = "AdminUrunEkleSil";
			Text = "AdminUrunEkleSil";
			Load += AdminUrunEkleSil_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label1;
		private Panel panel2;
		private PictureBox pictureBox1;
		private Label label2;
		private TextBox textBox3;
		private TextBox textBox2;
		private Label label5;
		private Label label4;
		private Label label3;
		private TextBox textBox1;
		private Button button1;
		private Panel panel3;
		private Button button2;
	}
}