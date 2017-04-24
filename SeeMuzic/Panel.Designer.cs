namespace SeeMuzic
{
	partial class Panel
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.trk_Level = new System.Windows.Forms.TrackBar();
			this.lab_Level = new System.Windows.Forms.Label();
			this.lab_Interval = new System.Windows.Forms.Label();
			this.trk_Interval = new System.Windows.Forms.TrackBar();
			this.lab_Krat = new System.Windows.Forms.Label();
			this.trk_Krat = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trk_Level)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Krat)).BeginInit();
			this.SuspendLayout();
			// 
			// trk_Level
			// 
			this.trk_Level.Location = new System.Drawing.Point(12, 25);
			this.trk_Level.Minimum = 1;
			this.trk_Level.Name = "trk_Level";
			this.trk_Level.Size = new System.Drawing.Size(104, 45);
			this.trk_Level.TabIndex = 0;
			this.trk_Level.Value = 1;
			this.trk_Level.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			// 
			// lab_Level
			// 
			this.lab_Level.AutoSize = true;
			this.lab_Level.Location = new System.Drawing.Point(12, 9);
			this.lab_Level.Name = "lab_Level";
			this.lab_Level.Size = new System.Drawing.Size(33, 13);
			this.lab_Level.TabIndex = 1;
			this.lab_Level.Text = "Level";
			// 
			// lab_Interval
			// 
			this.lab_Interval.AutoSize = true;
			this.lab_Interval.Location = new System.Drawing.Point(122, 9);
			this.lab_Interval.Name = "lab_Interval";
			this.lab_Interval.Size = new System.Drawing.Size(42, 13);
			this.lab_Interval.TabIndex = 3;
			this.lab_Interval.Text = "Interval";
			// 
			// trk_Interval
			// 
			this.trk_Interval.Location = new System.Drawing.Point(122, 25);
			this.trk_Interval.Maximum = 9;
			this.trk_Interval.Name = "trk_Interval";
			this.trk_Interval.Size = new System.Drawing.Size(104, 45);
			this.trk_Interval.TabIndex = 2;
			this.trk_Interval.Value = 1;
			this.trk_Interval.ValueChanged += new System.EventHandler(this.trk_Interval_ValueChanged);
			// 
			// lab_Krat
			// 
			this.lab_Krat.AutoSize = true;
			this.lab_Krat.Location = new System.Drawing.Point(232, 9);
			this.lab_Krat.Name = "lab_Krat";
			this.lab_Krat.Size = new System.Drawing.Size(26, 13);
			this.lab_Krat.TabIndex = 5;
			this.lab_Krat.Text = "Krat";
			// 
			// trk_Krat
			// 
			this.trk_Krat.Location = new System.Drawing.Point(232, 25);
			this.trk_Krat.Maximum = 9;
			this.trk_Krat.Name = "trk_Krat";
			this.trk_Krat.Size = new System.Drawing.Size(104, 45);
			this.trk_Krat.TabIndex = 4;
			this.trk_Krat.Value = 1;
			this.trk_Krat.ValueChanged += new System.EventHandler(this.trk_Krat_ValueChanged);
			// 
			// Panel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 75);
			this.Controls.Add(this.lab_Krat);
			this.Controls.Add(this.trk_Krat);
			this.Controls.Add(this.lab_Interval);
			this.Controls.Add(this.trk_Interval);
			this.Controls.Add(this.lab_Level);
			this.Controls.Add(this.trk_Level);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Panel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Panel";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Panel_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.trk_Level)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Krat)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar trk_Level;
		private System.Windows.Forms.Label lab_Interval;
		private System.Windows.Forms.TrackBar trk_Interval;
		private System.Windows.Forms.Label lab_Krat;
		private System.Windows.Forms.TrackBar trk_Krat;
		public System.Windows.Forms.Label lab_Level;
	}
}