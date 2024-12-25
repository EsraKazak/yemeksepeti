namespace yemeksepeti
{
	partial class FiyatStok_güncelle
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiyatStok_güncelle));
			panel1 = new Panel();
			textBox3 = new TextBox();
			textBox2 = new TextBox();
			button2 = new Button();
			textBox1 = new TextBox();
			dataGridView1 = new DataGridView();
			button1 = new Button();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(dataGridView1);
			panel1.Controls.Add(button1);
			panel1.Location = new Point(2, -2);
			panel1.Name = "panel1";
			panel1.Size = new Size(801, 452);
			panel1.TabIndex = 0;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(27, 205);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(125, 27);
			textBox3.TabIndex = 6;
			textBox3.TextChanged += textBox3_TextChanged;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(27, 161);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(125, 27);
			textBox2.TabIndex = 4;
			// 
			// button2
			// 
			button2.Location = new Point(27, 251);
			button2.Name = "button2";
			button2.Size = new Size(125, 60);
			button2.TabIndex = 3;
			button2.Text = "Fiyat ve Stok Güncelle\r\n";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(27, 116);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new Size(125, 27);
			textBox1.TabIndex = 2;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(185, 5);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(613, 444);
			dataGridView1.TabIndex = 1;
			dataGridView1.CellClick += dataGridView1_CellClick;
			dataGridView1.CellFormatting += dataGridView1_CellFormatting;
			// 
			// button1
			// 
			button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
			button1.BackgroundImageLayout = ImageLayout.Stretch;
			button1.Location = new Point(3, 14);
			button1.Name = "button1";
			button1.Size = new Size(85, 45);
			button1.TabIndex = 0;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// FiyatStok_güncelle
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel1);
			Name = "FiyatStok_güncelle";
			Text = "FiyatStok_güncelle";
			Load += FiyatStok_güncelle_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private DataGridView dataGridView1;
		private TextBox textBox2;
		private Button button2;
		private TextBox textBox1;
		private TextBox textBox3;
		private Button button1;
	}
}