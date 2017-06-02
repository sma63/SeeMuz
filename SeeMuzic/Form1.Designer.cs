namespace SeeMuzic
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.btn_M = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 50;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 333;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// btn_M
			// 
			this.btn_M.BackColor = System.Drawing.Color.Transparent;
			this.btn_M.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_M.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.btn_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_M.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_M.ForeColor = System.Drawing.Color.Red;
			this.btn_M.Location = new System.Drawing.Point(11, 12);
			this.btn_M.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btn_M.Name = "btn_M";
			this.btn_M.Size = new System.Drawing.Size(24, 24);
			this.btn_M.TabIndex = 0;
			this.btn_M.Text = "P";
			this.btn_M.UseVisualStyleBackColor = false;
			this.btn_M.Click += new System.EventHandler(this.btn_M_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(284, 276);
			this.Controls.Add(this.btn_M);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "Form1";
			this.Text = "See Muz";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.Timer timer2;
		public System.Windows.Forms.Button btn_M;
	}
}

