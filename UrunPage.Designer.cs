namespace yemeksepeti
{
	partial class UrunPage
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
			label2 = new Label();
			numericUpDown1 = new NumericUpDown();
			label1 = new Label();
			button1 = new Button();
			pictureBox1 = new PictureBox();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(label2);
			panel1.Controls.Add(numericUpDown1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(pictureBox1);
			panel1.Location = new Point(1, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(460, 462);
			panel1.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
			label2.Location = new Point(233, 69);
			label2.Name = "label2";
			label2.Size = new Size(62, 25);
			label2.TabIndex = 5;
			label2.Text = "label2";
			// 
			// numericUpDown1
			// 
			numericUpDown1.Location = new Point(233, 160);
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new Size(158, 27);
			numericUpDown1.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
			label1.Location = new Point(233, 24);
			label1.Name = "label1";
			label1.Size = new Size(59, 25);
			label1.TabIndex = 3;
			label1.Text = "label1";
			// 
			// button1
			// 
			button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
			button1.Location = new Point(233, 203);
			button1.Name = "button1";
			button1.Size = new Size(158, 36);
			button1.TabIndex = 2;
			button1.Text = "Sepete Ekle";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(11, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(189, 220);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// UrunPage
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(462, 450);
			Controls.Add(panel1);
			Name = "UrunPage";
			Text = "UrunPage";
			Load += UrunPage_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private PictureBox pictureBox1;
		private Button button1;
		private NumericUpDown numericUpDown1;
		private Label label1;
		private Label label2;
	}
}