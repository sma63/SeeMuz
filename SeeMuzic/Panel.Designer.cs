﻿namespace SeeMuzic
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
			this.lab_Front = new System.Windows.Forms.Label();
			this.trk_Front = new System.Windows.Forms.TrackBar();
			this.num_Palitra = new System.Windows.Forms.NumericUpDown();
			this.lab_Palitra = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trk_Level)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Krat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Front)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Palitra)).BeginInit();
			this.SuspendLayout();
			// 
			// trk_Level
			// 
			this.trk_Level.Location = new System.Drawing.Point(12, 46);
			this.trk_Level.Minimum = 1;
			this.trk_Level.Name = "trk_Level";
			this.trk_Level.Size = new System.Drawing.Size(104, 45);
			this.trk_Level.TabIndex = 1;
			this.trk_Level.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Level.Value = 1;
			this.trk_Level.ValueChanged += new System.EventHandler(this.trk_Level_ValueChanged);
			// 
			// lab_Level
			// 
			this.lab_Level.AutoSize = true;
			this.lab_Level.Location = new System.Drawing.Point(122, 48);
			this.lab_Level.Name = "lab_Level";
			this.lab_Level.Size = new System.Drawing.Size(50, 13);
			this.lab_Level.TabIndex = 6;
			this.lab_Level.Text = "Яркость";
			// 
			// lab_Interval
			// 
			this.lab_Interval.AutoSize = true;
			this.lab_Interval.Location = new System.Drawing.Point(122, 79);
			this.lab_Interval.Name = "lab_Interval";
			this.lab_Interval.Size = new System.Drawing.Size(56, 13);
			this.lab_Interval.TabIndex = 7;
			this.lab_Interval.Text = "Интервал";
			// 
			// trk_Interval
			// 
			this.trk_Interval.Location = new System.Drawing.Point(12, 76);
			this.trk_Interval.Minimum = 1;
			this.trk_Interval.Name = "trk_Interval";
			this.trk_Interval.Size = new System.Drawing.Size(104, 45);
			this.trk_Interval.TabIndex = 2;
			this.trk_Interval.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Interval.Value = 1;
			this.trk_Interval.ValueChanged += new System.EventHandler(this.trk_Interval_ValueChanged);
			// 
			// lab_Krat
			// 
			this.lab_Krat.AutoSize = true;
			this.lab_Krat.Location = new System.Drawing.Point(122, 110);
			this.lab_Krat.Name = "lab_Krat";
			this.lab_Krat.Size = new System.Drawing.Size(49, 13);
			this.lab_Krat.TabIndex = 8;
			this.lab_Krat.Text = "Частота";
			// 
			// trk_Krat
			// 
			this.trk_Krat.Location = new System.Drawing.Point(12, 106);
			this.trk_Krat.Minimum = 1;
			this.trk_Krat.Name = "trk_Krat";
			this.trk_Krat.Size = new System.Drawing.Size(104, 45);
			this.trk_Krat.TabIndex = 3;
			this.trk_Krat.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Krat.Value = 1;
			this.trk_Krat.ValueChanged += new System.EventHandler(this.trk_Krat_ValueChanged);
			// 
			// lab_Front
			// 
			this.lab_Front.AutoSize = true;
			this.lab_Front.Location = new System.Drawing.Point(122, 19);
			this.lab_Front.Name = "lab_Front";
			this.lab_Front.Size = new System.Drawing.Size(69, 13);
			this.lab_Front.TabIndex = 5;
			this.lab_Front.Text = "Накопление";
			// 
			// trk_Front
			// 
			this.trk_Front.Location = new System.Drawing.Point(12, 16);
			this.trk_Front.Minimum = 1;
			this.trk_Front.Name = "trk_Front";
			this.trk_Front.Size = new System.Drawing.Size(104, 45);
			this.trk_Front.TabIndex = 0;
			this.trk_Front.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Front.Value = 1;
			this.trk_Front.ValueChanged += new System.EventHandler(this.trk_Front_ValueChanged);
			// 
			// num_Palitra
			// 
			this.num_Palitra.Location = new System.Drawing.Point(24, 140);
			this.num_Palitra.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
			this.num_Palitra.Name = "num_Palitra";
			this.num_Palitra.ReadOnly = true;
			this.num_Palitra.Size = new System.Drawing.Size(81, 20);
			this.num_Palitra.TabIndex = 4;
			this.num_Palitra.ValueChanged += new System.EventHandler(this.num_Palitra_ValueChanged);
			// 
			// lab_Palitra
			// 
			this.lab_Palitra.AutoSize = true;
			this.lab_Palitra.Location = new System.Drawing.Point(122, 141);
			this.lab_Palitra.Name = "lab_Palitra";
			this.lab_Palitra.Size = new System.Drawing.Size(50, 13);
			this.lab_Palitra.TabIndex = 9;
			this.lab_Palitra.Text = "Палитра";
			// 
			// Panel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(219, 179);
			this.Controls.Add(this.lab_Palitra);
			this.Controls.Add(this.lab_Front);
			this.Controls.Add(this.lab_Krat);
			this.Controls.Add(this.lab_Interval);
			this.Controls.Add(this.lab_Level);
			this.Controls.Add(this.num_Palitra);
			this.Controls.Add(this.trk_Krat);
			this.Controls.Add(this.trk_Interval);
			this.Controls.Add(this.trk_Level);
			this.Controls.Add(this.trk_Front);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Panel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Настройки";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Panel_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.trk_Level)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Krat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Front)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Palitra)).EndInit();
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
		public System.Windows.Forms.Label lab_Front;
		public System.Windows.Forms.TrackBar trk_Front;
		public System.Windows.Forms.NumericUpDown num_Palitra;
		private System.Windows.Forms.Label lab_Palitra;
	}
}