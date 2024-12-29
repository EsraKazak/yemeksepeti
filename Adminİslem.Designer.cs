namespace yemeksepeti
{
	partial class Adminİslem
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
			progressBar1 = new ProgressBar();
			button3 = new Button();
			button2 = new Button();
			button1 = new Button();
			dataGridView1 = new DataGridView();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(progressBar1);
			panel1.Controls.Add(button3);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(dataGridView1);
			panel1.Location = new Point(0, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(959, 520);
			panel1.TabIndex = 0;
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(804, 26);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(155, 29);
			progressBar1.TabIndex = 4;
			// 
			// button3
			// 
			button3.Location = new Point(809, 399);
			button3.Name = "button3";
			button3.Size = new Size(140, 60);
			button3.TabIndex = 3;
			button3.Text = "Fiyat ve Stok Güncelle";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// button2
			// 
			button2.Location = new Point(809, 334);
			button2.Name = "button2";
			button2.Size = new Size(140, 59);
			button2.TabIndex = 2;
			button2.Text = "Ürün Ekle\r\n Sil";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.Location = new Point(809, 299);
			button1.Name = "button1";
			button1.Size = new Size(140, 29);
			button1.TabIndex = 1;
			button1.Text = "Siparişleri Onayla";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(3, 0);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(800, 520);
			dataGridView1.TabIndex = 0;
			dataGridView1.CellContentClick += dataGridView1_CellContentClick;
			// 
			// Adminİslem
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(961, 524);
			Controls.Add(panel1);
			Name = "Adminİslem";
			Text = "Adminİslem";
			FormClosing += AdminForm_FormClosing;
			Load += Adminİslem_Load;
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Button button3;
		private Button button2;
		private Button button1;
		private DataGridView dataGridView1;
		private ProgressBar progressBar1;
	}
}