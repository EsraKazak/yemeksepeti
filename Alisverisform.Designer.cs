namespace yemeksepeti
{
	partial class Alisverisform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alisverisform));
			panel1 = new Panel();
			label1 = new Label();
			button1 = new Button();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Location = new Point(1, -1);
			panel1.Name = "panel1";
			panel1.Size = new Size(510, 544);
			panel1.TabIndex = 0;
			panel1.Paint += panel1_Paint;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
			label1.Location = new Point(549, 78);
			label1.Name = "label1";
			label1.Size = new Size(78, 20);
			label1.TabIndex = 1;
			label1.Text = "Sepete Git";
			// 
			// button1
			// 
			button1.BackColor = Color.Transparent;
			button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
			button1.BackgroundImageLayout = ImageLayout.Stretch;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
			button1.Location = new Point(549, 12);
			button1.Name = "button1";
			button1.Size = new Size(78, 63);
			button1.TabIndex = 0;
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// Alisverisform
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(653, 539);
			Controls.Add(label1);
			Controls.Add(button1);
			Controls.Add(panel1);
			Name = "Alisverisform";
			Text = "Alisverisform";
			Load += Alisverisform_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panel1;
		private Button button1;
		private Label label1;
	}
}