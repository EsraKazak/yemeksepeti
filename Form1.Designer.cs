namespace yemeksepeti
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			panel1 = new Panel();
			label1 = new Label();
			button2 = new Button();
			button1 = new Button();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new Point(1, -1);
			panel1.Name = "panel1";
			panel1.Size = new Size(963, 504);
			panel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.Transparent;
			label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
			label1.Location = new Point(399, 10);
			label1.Name = "label1";
			label1.Size = new Size(142, 31);
			label1.TabIndex = 2;
			label1.Text = "Hoşgeldiniz";
			// 
			// button2
			// 
			button2.BackColor = Color.Transparent;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button2.FlatStyle = FlatStyle.Flat;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
			button2.Location = new Point(628, 45);
			button2.Name = "button2";
			button2.Size = new Size(191, 48);
			button2.TabIndex = 1;
			button2.Text = "Admin Girişi";
			button2.UseVisualStyleBackColor = false;
			// 
			// button1
			// 
			button1.BackColor = Color.Transparent;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
			button1.ForeColor = Color.Black;
			button1.Location = new Point(136, 45);
			button1.Name = "button1";
			button1.Size = new Size(191, 48);
			button1.TabIndex = 0;
			button1.Text = "Kullanıcı Girişi";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(962, 505);
			Controls.Add(panel1);
			Name = "Form1";
			Text = "Form1";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label1;
		private Button button2;
		private Button button1;
	}
}
