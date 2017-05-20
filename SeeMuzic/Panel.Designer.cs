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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel));
			this.trk_Bright = new System.Windows.Forms.TrackBar();
			this.lab_Level = new System.Windows.Forms.Label();
			this.lab_Interval = new System.Windows.Forms.Label();
			this.trk_Interval = new System.Windows.Forms.TrackBar();
			this.lab_Resample = new System.Windows.Forms.Label();
			this.trk_Resample = new System.Windows.Forms.TrackBar();
			this.lab_Leak = new System.Windows.Forms.Label();
			this.trk_Front = new System.Windows.Forms.TrackBar();
			this.lab_Palitra = new System.Windows.Forms.Label();
			this.lab_Filter = new System.Windows.Forms.Label();
			this.chk_Stretch = new System.Windows.Forms.CheckBox();
			this.chk_Inside = new System.Windows.Forms.CheckBox();
			this.chk_Eros = new System.Windows.Forms.CheckBox();
			this.chk_Rotate = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage0 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.progress_Pos = new System.Windows.Forms.ProgressBar();
			this.trk_Volume = new System.Windows.Forms.TrackBar();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.trk_Palitra = new System.Windows.Forms.TrackBar();
			this.trk_Gamma = new System.Windows.Forms.TrackBar();
			this.trk_Filter = new System.Windows.Forms.TrackBar();
			this.lab_Gamma = new System.Windows.Forms.Label();
			this.chk_Transparency = new System.Windows.Forms.CheckBox();
			this.Panel_Timer = new System.Windows.Forms.Timer(this.components);
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btn_Next = new System.Windows.Forms.Button();
			this.btn_Play = new System.Windows.Forms.Button();
			this.btn_Prev = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trk_Bright)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Resample)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Front)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage0.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trk_Volume)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trk_Palitra)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Gamma)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Filter)).BeginInit();
			this.SuspendLayout();
			// 
			// trk_Bright
			// 
			this.trk_Bright.Location = new System.Drawing.Point(6, 111);
			this.trk_Bright.Minimum = 1;
			this.trk_Bright.Name = "trk_Bright";
			this.trk_Bright.Size = new System.Drawing.Size(104, 45);
			this.trk_Bright.TabIndex = 1;
			this.trk_Bright.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Bright.Value = 1;
			this.trk_Bright.ValueChanged += new System.EventHandler(this.trk_Level_ValueChanged);
			// 
			// lab_Level
			// 
			this.lab_Level.AutoSize = true;
			this.lab_Level.Location = new System.Drawing.Point(111, 115);
			this.lab_Level.Name = "lab_Level";
			this.lab_Level.Size = new System.Drawing.Size(50, 13);
			this.lab_Level.TabIndex = 6;
			this.lab_Level.Text = "Яркость";
			// 
			// lab_Interval
			// 
			this.lab_Interval.AutoSize = true;
			this.lab_Interval.Location = new System.Drawing.Point(111, 45);
			this.lab_Interval.Name = "lab_Interval";
			this.lab_Interval.Size = new System.Drawing.Size(56, 13);
			this.lab_Interval.TabIndex = 7;
			this.lab_Interval.Text = "Интервал";
			// 
			// trk_Interval
			// 
			this.trk_Interval.Location = new System.Drawing.Point(7, 42);
			this.trk_Interval.Minimum = 1;
			this.trk_Interval.Name = "trk_Interval";
			this.trk_Interval.Size = new System.Drawing.Size(104, 45);
			this.trk_Interval.TabIndex = 2;
			this.trk_Interval.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Interval.Value = 1;
			this.trk_Interval.ValueChanged += new System.EventHandler(this.trk_Interval_ValueChanged);
			// 
			// lab_Resample
			// 
			this.lab_Resample.AutoSize = true;
			this.lab_Resample.Location = new System.Drawing.Point(111, 19);
			this.lab_Resample.Name = "lab_Resample";
			this.lab_Resample.Size = new System.Drawing.Size(49, 13);
			this.lab_Resample.TabIndex = 8;
			this.lab_Resample.Text = "Частота";
			// 
			// trk_Resample
			// 
			this.trk_Resample.Location = new System.Drawing.Point(6, 19);
			this.trk_Resample.Maximum = 9;
			this.trk_Resample.Name = "trk_Resample";
			this.trk_Resample.Size = new System.Drawing.Size(104, 45);
			this.trk_Resample.TabIndex = 3;
			this.trk_Resample.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Resample.Value = 1;
			this.trk_Resample.ValueChanged += new System.EventHandler(this.trk_Resample_ValueChanged);
			// 
			// lab_Leak
			// 
			this.lab_Leak.AutoSize = true;
			this.lab_Leak.Location = new System.Drawing.Point(111, 92);
			this.lab_Leak.Name = "lab_Leak";
			this.lab_Leak.Size = new System.Drawing.Size(69, 13);
			this.lab_Leak.TabIndex = 5;
			this.lab_Leak.Text = "Накопление";
			// 
			// trk_Front
			// 
			this.trk_Front.Location = new System.Drawing.Point(7, 88);
			this.trk_Front.Minimum = 1;
			this.trk_Front.Name = "trk_Front";
			this.trk_Front.Size = new System.Drawing.Size(104, 45);
			this.trk_Front.TabIndex = 0;
			this.trk_Front.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Front.Value = 1;
			this.trk_Front.ValueChanged += new System.EventHandler(this.trk_Front_ValueChanged);
			// 
			// lab_Palitra
			// 
			this.lab_Palitra.AutoSize = true;
			this.lab_Palitra.Location = new System.Drawing.Point(111, 160);
			this.lab_Palitra.Name = "lab_Palitra";
			this.lab_Palitra.Size = new System.Drawing.Size(50, 13);
			this.lab_Palitra.TabIndex = 9;
			this.lab_Palitra.Text = "Палитра";
			// 
			// lab_Filter
			// 
			this.lab_Filter.AutoSize = true;
			this.lab_Filter.Location = new System.Drawing.Point(112, 68);
			this.lab_Filter.Name = "lab_Filter";
			this.lab_Filter.Size = new System.Drawing.Size(47, 13);
			this.lab_Filter.TabIndex = 11;
			this.lab_Filter.Text = "Фильтр";
			// 
			// chk_Stretch
			// 
			this.chk_Stretch.AutoSize = true;
			this.chk_Stretch.Location = new System.Drawing.Point(207, 113);
			this.chk_Stretch.Name = "chk_Stretch";
			this.chk_Stretch.Size = new System.Drawing.Size(61, 17);
			this.chk_Stretch.TabIndex = 12;
			this.chk_Stretch.Text = "Тянуть";
			this.chk_Stretch.UseVisualStyleBackColor = true;
			this.chk_Stretch.CheckedChanged += new System.EventHandler(this.chk_Stretch_CheckedChanged);
			// 
			// chk_Inside
			// 
			this.chk_Inside.AutoSize = true;
			this.chk_Inside.Location = new System.Drawing.Point(207, 92);
			this.chk_Inside.Name = "chk_Inside";
			this.chk_Inside.Size = new System.Drawing.Size(68, 17);
			this.chk_Inside.TabIndex = 13;
			this.chk_Inside.Text = "Вписать";
			this.chk_Inside.UseVisualStyleBackColor = true;
			this.chk_Inside.CheckedChanged += new System.EventHandler(this.chk_Inside_CheckedChanged);
			// 
			// chk_Eros
			// 
			this.chk_Eros.AutoSize = true;
			this.chk_Eros.Location = new System.Drawing.Point(207, 136);
			this.chk_Eros.Name = "chk_Eros";
			this.chk_Eros.Size = new System.Drawing.Size(54, 17);
			this.chk_Eros.TabIndex = 14;
			this.chk_Eros.Text = "Гнуть";
			this.chk_Eros.UseVisualStyleBackColor = true;
			this.chk_Eros.CheckedChanged += new System.EventHandler(this.chk_Eros_CheckedChanged);
			// 
			// chk_Rotate
			// 
			this.chk_Rotate.AutoSize = true;
			this.chk_Rotate.Location = new System.Drawing.Point(207, 70);
			this.chk_Rotate.Name = "chk_Rotate";
			this.chk_Rotate.Size = new System.Drawing.Size(66, 17);
			this.chk_Rotate.TabIndex = 15;
			this.chk_Rotate.Text = "Крутить";
			this.chk_Rotate.UseVisualStyleBackColor = true;
			this.chk_Rotate.CheckedChanged += new System.EventHandler(this.chk_Rotate_CheckedChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage0);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(333, 236);
			this.tabControl1.TabIndex = 16;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage0
			// 
			this.tabPage0.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage0.Controls.Add(this.splitContainer1);
			this.tabPage0.Location = new System.Drawing.Point(4, 22);
			this.tabPage0.Name = "tabPage0";
			this.tabPage0.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage0.Size = new System.Drawing.Size(325, 210);
			this.tabPage0.TabIndex = 1;
			this.tabPage0.Text = "Play List";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.button2);
			this.splitContainer1.Panel1.Controls.Add(this.button1);
			this.splitContainer1.Panel1.Controls.Add(this.progress_Pos);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Next);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Play);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Prev);
			this.splitContainer1.Panel1.Controls.Add(this.trk_Volume);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(319, 204);
			this.splitContainer1.SplitterDistance = 63;
			this.splitContainer1.TabIndex = 0;
			// 
			// progress_Pos
			// 
			this.progress_Pos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.progress_Pos.Location = new System.Drawing.Point(4, 39);
			this.progress_Pos.Name = "progress_Pos";
			this.progress_Pos.Size = new System.Drawing.Size(309, 23);
			this.progress_Pos.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progress_Pos.TabIndex = 3;
			// 
			// trk_Volume
			// 
			this.trk_Volume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trk_Volume.Location = new System.Drawing.Point(195, 4);
			this.trk_Volume.Name = "trk_Volume";
			this.trk_Volume.Size = new System.Drawing.Size(119, 45);
			this.trk_Volume.TabIndex = 4;
			this.trk_Volume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Volume.ValueChanged += new System.EventHandler(this.trk_Volume_ValueChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(319, 137);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(325, 210);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "View";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.trk_Palitra);
			this.groupBox1.Controls.Add(this.trk_Gamma);
			this.groupBox1.Controls.Add(this.trk_Bright);
			this.groupBox1.Controls.Add(this.trk_Front);
			this.groupBox1.Controls.Add(this.trk_Filter);
			this.groupBox1.Controls.Add(this.trk_Interval);
			this.groupBox1.Controls.Add(this.trk_Resample);
			this.groupBox1.Controls.Add(this.lab_Filter);
			this.groupBox1.Controls.Add(this.lab_Interval);
			this.groupBox1.Controls.Add(this.lab_Gamma);
			this.groupBox1.Controls.Add(this.lab_Resample);
			this.groupBox1.Controls.Add(this.lab_Leak);
			this.groupBox1.Controls.Add(this.lab_Palitra);
			this.groupBox1.Controls.Add(this.lab_Level);
			this.groupBox1.Controls.Add(this.chk_Transparency);
			this.groupBox1.Controls.Add(this.chk_Rotate);
			this.groupBox1.Controls.Add(this.chk_Inside);
			this.groupBox1.Controls.Add(this.chk_Stretch);
			this.groupBox1.Controls.Add(this.chk_Eros);
			this.groupBox1.Location = new System.Drawing.Point(6, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 196);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// trk_Palitra
			// 
			this.trk_Palitra.Location = new System.Drawing.Point(6, 156);
			this.trk_Palitra.Maximum = 6;
			this.trk_Palitra.Name = "trk_Palitra";
			this.trk_Palitra.Size = new System.Drawing.Size(104, 45);
			this.trk_Palitra.TabIndex = 20;
			this.trk_Palitra.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Palitra.Value = 1;
			this.trk_Palitra.ValueChanged += new System.EventHandler(this.trk_Palitra_ValueChanged);
			// 
			// trk_Gamma
			// 
			this.trk_Gamma.Location = new System.Drawing.Point(6, 134);
			this.trk_Gamma.Maximum = 7;
			this.trk_Gamma.Minimum = -7;
			this.trk_Gamma.Name = "trk_Gamma";
			this.trk_Gamma.Size = new System.Drawing.Size(104, 45);
			this.trk_Gamma.TabIndex = 17;
			this.trk_Gamma.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Gamma.Value = 1;
			this.trk_Gamma.ValueChanged += new System.EventHandler(this.trk_Gamma_ValueChanged);
			// 
			// trk_Filter
			// 
			this.trk_Filter.Location = new System.Drawing.Point(7, 65);
			this.trk_Filter.Maximum = 7;
			this.trk_Filter.Minimum = 1;
			this.trk_Filter.Name = "trk_Filter";
			this.trk_Filter.Size = new System.Drawing.Size(104, 45);
			this.trk_Filter.TabIndex = 19;
			this.trk_Filter.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Filter.Value = 1;
			this.trk_Filter.ValueChanged += new System.EventHandler(this.trk_Filter_ValueChanged);
			// 
			// lab_Gamma
			// 
			this.lab_Gamma.AutoSize = true;
			this.lab_Gamma.Location = new System.Drawing.Point(111, 138);
			this.lab_Gamma.Name = "lab_Gamma";
			this.lab_Gamma.Size = new System.Drawing.Size(41, 13);
			this.lab_Gamma.TabIndex = 18;
			this.lab_Gamma.Text = "Гамма";
			// 
			// chk_Transparency
			// 
			this.chk_Transparency.AutoSize = true;
			this.chk_Transparency.Location = new System.Drawing.Point(207, 159);
			this.chk_Transparency.Name = "chk_Transparency";
			this.chk_Transparency.Size = new System.Drawing.Size(98, 17);
			this.chk_Transparency.TabIndex = 16;
			this.chk_Transparency.Text = "Прозрачность";
			this.chk_Transparency.UseVisualStyleBackColor = true;
			this.chk_Transparency.Click += new System.EventHandler(this.chk_Transparency_Click);
			// 
			// Panel_Timer
			// 
			this.Panel_Timer.Interval = 1000;
			this.Panel_Timer.Tick += new System.EventHandler(this.Panel_Timer_Tick);
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.Column1.FillWeight = 66F;
			this.Column1.HeaderText = "Song";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 57;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column2.FillWeight = 17F;
			this.Column2.HeaderText = "Time";
			this.Column2.Name = "Column2";
			this.Column2.Width = 55;
			// 
			// Column3
			// 
			this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.Column3.FillWeight = 17F;
			this.Column3.HeaderText = "Path";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 54;
			// 
			// button2
			// 
			this.button2.BackgroundImage = global::SeeMuz.Properties.Resources.kde_folder_saved_search_2702;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button2.Location = new System.Drawing.Point(5, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(32, 32);
			this.button2.TabIndex = 6;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.BackgroundImage = global::SeeMuz.Properties.Resources.arrow_switch_2894;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button1.Location = new System.Drawing.Point(43, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 32);
			this.button1.TabIndex = 5;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btn_Next
			// 
			this.btn_Next.BackgroundImage = global::SeeMuz.Properties.Resources.player_fwd_3377;
			this.btn_Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Next.Location = new System.Drawing.Point(157, 4);
			this.btn_Next.Name = "btn_Next";
			this.btn_Next.Size = new System.Drawing.Size(32, 32);
			this.btn_Next.TabIndex = 2;
			this.btn_Next.UseVisualStyleBackColor = true;
			this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
			// 
			// btn_Play
			// 
			this.btn_Play.BackgroundImage = global::SeeMuz.Properties.Resources.player_pause_6166;
			this.btn_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Play.Location = new System.Drawing.Point(119, 4);
			this.btn_Play.Name = "btn_Play";
			this.btn_Play.Size = new System.Drawing.Size(32, 32);
			this.btn_Play.TabIndex = 1;
			this.btn_Play.UseVisualStyleBackColor = true;
			this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
			// 
			// btn_Prev
			// 
			this.btn_Prev.BackgroundImage = global::SeeMuz.Properties.Resources.player_rew_9310;
			this.btn_Prev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Prev.Location = new System.Drawing.Point(81, 4);
			this.btn_Prev.Name = "btn_Prev";
			this.btn_Prev.Size = new System.Drawing.Size(32, 32);
			this.btn_Prev.TabIndex = 0;
			this.btn_Prev.UseVisualStyleBackColor = true;
			this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
			// 
			// Panel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(333, 236);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(349, 274);
			this.Name = "Panel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SeeMuz - Control";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Panel_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.trk_Bright)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Resample)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Front)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage0.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trk_Volume)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trk_Palitra)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Gamma)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Filter)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TrackBar trk_Resample;//1
		private System.Windows.Forms.TrackBar trk_Interval;//2
		private System.Windows.Forms.TrackBar trk_Bright;//3
		public System.Windows.Forms.TrackBar trk_Front;//4

		private System.Windows.Forms.Label lab_Interval;
		private System.Windows.Forms.Label lab_Resample;
		public System.Windows.Forms.Label lab_Level;
		public System.Windows.Forms.Label lab_Leak;

		private System.Windows.Forms.Label lab_Palitra;
		private System.Windows.Forms.Label lab_Filter;

		private System.Windows.Forms.CheckBox chk_Stretch;
		private System.Windows.Forms.CheckBox chk_Inside;
		private System.Windows.Forms.CheckBox chk_Eros;
		private System.Windows.Forms.CheckBox chk_Rotate;

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage0;
		private System.Windows.Forms.TabPage tabPage1;

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btn_Next;
		private System.Windows.Forms.Button btn_Play;
		private System.Windows.Forms.Button btn_Prev;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Timer Panel_Timer;
		public System.Windows.Forms.ProgressBar progress_Pos;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chk_Transparency;
		private System.Windows.Forms.TrackBar trk_Volume;
		private System.Windows.Forms.TrackBar trk_Gamma;
		private System.Windows.Forms.Label lab_Gamma;
		private System.Windows.Forms.TrackBar trk_Filter;
		private System.Windows.Forms.TrackBar trk_Palitra;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.Button button2;
	}
}