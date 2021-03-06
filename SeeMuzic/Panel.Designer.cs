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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage0 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btn_Load = new System.Windows.Forms.Button();
			this.btn_Random = new System.Windows.Forms.Button();
			this.progress_Pos = new System.Windows.Forms.ProgressBar();
			this.btn_Next = new System.Windows.Forms.Button();
			this.btn_Play = new System.Windows.Forms.Button();
			this.btn_Prev = new System.Windows.Forms.Button();
			this.trk_Volume = new System.Windows.Forms.TrackBar();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.trk_Screen = new System.Windows.Forms.TrackBar();
			this.lab_Screen = new System.Windows.Forms.Label();
			this.trk_Palitra = new System.Windows.Forms.TrackBar();
			this.trk_Gamma = new System.Windows.Forms.TrackBar();
			this.trk_Filter = new System.Windows.Forms.TrackBar();
			this.lab_Gamma = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.chk_Isobar = new System.Windows.Forms.CheckBox();
			this.chk_Spiral = new System.Windows.Forms.CheckBox();
			this.chk_Flex = new System.Windows.Forms.CheckBox();
			this.chk_Topmost = new System.Windows.Forms.CheckBox();
			this.chk_Rotate = new System.Windows.Forms.CheckBox();
			this.chk_Inside = new System.Windows.Forms.CheckBox();
			this.chk_Stretch = new System.Windows.Forms.CheckBox();
			this.chk_Distortion = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btn_Help = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Panel_Timer = new System.Windows.Forms.Timer(this.components);
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
			((System.ComponentModel.ISupportInitialize)(this.trk_Screen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Palitra)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Gamma)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Filter)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// trk_Bright
			// 
			this.trk_Bright.Location = new System.Drawing.Point(6, 111);
			this.trk_Bright.Minimum = -10;
			this.trk_Bright.Name = "trk_Bright";
			this.trk_Bright.Size = new System.Drawing.Size(104, 45);
			this.trk_Bright.TabIndex = 4;
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
			this.lab_Level.TabIndex = 18;
			this.lab_Level.Text = "Яркость";
			// 
			// lab_Interval
			// 
			this.lab_Interval.AutoSize = true;
			this.lab_Interval.Location = new System.Drawing.Point(111, 45);
			this.lab_Interval.Name = "lab_Interval";
			this.lab_Interval.Size = new System.Drawing.Size(56, 13);
			this.lab_Interval.TabIndex = 15;
			this.lab_Interval.Text = "Интервал";
			// 
			// trk_Interval
			// 
			this.trk_Interval.Location = new System.Drawing.Point(7, 42);
			this.trk_Interval.Minimum = 1;
			this.trk_Interval.Name = "trk_Interval";
			this.trk_Interval.Size = new System.Drawing.Size(104, 45);
			this.trk_Interval.TabIndex = 1;
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
			this.lab_Resample.TabIndex = 14;
			this.lab_Resample.Text = "Частота";
			// 
			// trk_Resample
			// 
			this.trk_Resample.Location = new System.Drawing.Point(6, 19);
			this.trk_Resample.Maximum = 9;
			this.trk_Resample.Name = "trk_Resample";
			this.trk_Resample.Size = new System.Drawing.Size(104, 45);
			this.trk_Resample.TabIndex = 0;
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
			this.lab_Leak.TabIndex = 17;
			this.lab_Leak.Text = "Накопление";
			// 
			// trk_Front
			// 
			this.trk_Front.Location = new System.Drawing.Point(7, 88);
			this.trk_Front.Minimum = 1;
			this.trk_Front.Name = "trk_Front";
			this.trk_Front.Size = new System.Drawing.Size(104, 45);
			this.trk_Front.TabIndex = 3;
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
			this.lab_Palitra.TabIndex = 20;
			this.lab_Palitra.Text = "Палитра";
			// 
			// lab_Filter
			// 
			this.lab_Filter.AutoSize = true;
			this.lab_Filter.Location = new System.Drawing.Point(112, 68);
			this.lab_Filter.Name = "lab_Filter";
			this.lab_Filter.Size = new System.Drawing.Size(47, 13);
			this.lab_Filter.TabIndex = 16;
			this.lab_Filter.Text = "Фильтр";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage0);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(333, 256);
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
			this.tabPage0.Size = new System.Drawing.Size(325, 230);
			this.tabPage0.TabIndex = 1;
			this.tabPage0.Text = "List";
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
			this.splitContainer1.Panel1.Controls.Add(this.btn_Load);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Random);
			this.splitContainer1.Panel1.Controls.Add(this.progress_Pos);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Next);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Play);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Prev);
			this.splitContainer1.Panel1.Controls.Add(this.trk_Volume);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(319, 224);
			this.splitContainer1.SplitterDistance = 63;
			this.splitContainer1.TabIndex = 0;
			// 
			// btn_Load
			// 
			this.btn_Load.BackgroundImage = global::SeeMuz.Properties.Resources.kde_folder_saved_search_2702;
			this.btn_Load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Load.Location = new System.Drawing.Point(5, 4);
			this.btn_Load.Name = "btn_Load";
			this.btn_Load.Size = new System.Drawing.Size(32, 32);
			this.btn_Load.TabIndex = 6;
			this.btn_Load.UseVisualStyleBackColor = true;
			this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
			// 
			// btn_Random
			// 
			this.btn_Random.BackgroundImage = global::SeeMuz.Properties.Resources.arrow_switch_2894;
			this.btn_Random.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Random.Location = new System.Drawing.Point(43, 4);
			this.btn_Random.Name = "btn_Random";
			this.btn_Random.Size = new System.Drawing.Size(32, 32);
			this.btn_Random.TabIndex = 5;
			this.btn_Random.UseVisualStyleBackColor = true;
			this.btn_Random.Click += new System.EventHandler(this.btn_Random_Click);
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
			this.btn_Play.BackgroundImage = global::SeeMuz.Properties.Resources.player_play_8474;
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
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
			this.dataGridView1.Size = new System.Drawing.Size(319, 157);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
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
			this.Column2.ReadOnly = true;
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
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(325, 230);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "View";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.trk_Screen);
			this.groupBox1.Controls.Add(this.lab_Screen);
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
			this.groupBox1.Location = new System.Drawing.Point(6, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 217);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// trk_Screen
			// 
			this.trk_Screen.Location = new System.Drawing.Point(7, 180);
			this.trk_Screen.Minimum = 1;
			this.trk_Screen.Name = "trk_Screen";
			this.trk_Screen.Size = new System.Drawing.Size(104, 45);
			this.trk_Screen.TabIndex = 22;
			this.trk_Screen.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trk_Screen.Value = 1;
			this.trk_Screen.ValueChanged += new System.EventHandler(this.trk_Screen_ValueChanged);
			// 
			// lab_Screen
			// 
			this.lab_Screen.AutoSize = true;
			this.lab_Screen.Location = new System.Drawing.Point(112, 183);
			this.lab_Screen.Name = "lab_Screen";
			this.lab_Screen.Size = new System.Drawing.Size(51, 13);
			this.lab_Screen.TabIndex = 23;
			this.lab_Screen.Text = "Инерция";
			// 
			// trk_Palitra
			// 
			this.trk_Palitra.Location = new System.Drawing.Point(6, 156);
			this.trk_Palitra.Maximum = 20;
			this.trk_Palitra.Name = "trk_Palitra";
			this.trk_Palitra.Size = new System.Drawing.Size(104, 45);
			this.trk_Palitra.TabIndex = 6;
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
			this.trk_Gamma.TabIndex = 5;
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
			this.trk_Filter.TabIndex = 2;
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
			this.lab_Gamma.TabIndex = 19;
			this.lab_Gamma.Text = "Гамма";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.chk_Isobar);
			this.tabPage2.Controls.Add(this.chk_Spiral);
			this.tabPage2.Controls.Add(this.chk_Flex);
			this.tabPage2.Controls.Add(this.chk_Topmost);
			this.tabPage2.Controls.Add(this.chk_Rotate);
			this.tabPage2.Controls.Add(this.chk_Inside);
			this.tabPage2.Controls.Add(this.chk_Stretch);
			this.tabPage2.Controls.Add(this.chk_Distortion);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(325, 230);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Text = "Mode";
			// 
			// chk_Isobar
			// 
			this.chk_Isobar.AutoSize = true;
			this.chk_Isobar.Location = new System.Drawing.Point(25, 156);
			this.chk_Isobar.Name = "chk_Isobar";
			this.chk_Isobar.Size = new System.Drawing.Size(72, 17);
			this.chk_Isobar.TabIndex = 29;
			this.chk_Isobar.Text = "Изобары";
			this.chk_Isobar.UseVisualStyleBackColor = true;
			this.chk_Isobar.Click += new System.EventHandler(this.chk_Isobar_Click);
			// 
			// chk_Spiral
			// 
			this.chk_Spiral.AutoSize = true;
			this.chk_Spiral.Location = new System.Drawing.Point(25, 111);
			this.chk_Spiral.Name = "chk_Spiral";
			this.chk_Spiral.Size = new System.Drawing.Size(84, 17);
			this.chk_Spiral.TabIndex = 26;
			this.chk_Spiral.Text = "Скручивать";
			this.chk_Spiral.UseVisualStyleBackColor = true;
			this.chk_Spiral.Click += new System.EventHandler(this.chk_Spiral_Click);
			// 
			// chk_Flex
			// 
			this.chk_Flex.AutoSize = true;
			this.chk_Flex.Location = new System.Drawing.Point(25, 133);
			this.chk_Flex.Name = "chk_Flex";
			this.chk_Flex.Size = new System.Drawing.Size(109, 17);
			this.chk_Flex.TabIndex = 27;
			this.chk_Flex.Text = "Дрейф Палитры";
			this.chk_Flex.UseVisualStyleBackColor = true;
			this.chk_Flex.Click += new System.EventHandler(this.chk_Flex_Click);
			// 
			// chk_Topmost
			// 
			this.chk_Topmost.AutoSize = true;
			this.chk_Topmost.Location = new System.Drawing.Point(25, 179);
			this.chk_Topmost.Name = "chk_Topmost";
			this.chk_Topmost.Size = new System.Drawing.Size(87, 17);
			this.chk_Topmost.TabIndex = 28;
			this.chk_Topmost.Text = "ПоверхВсех";
			this.chk_Topmost.UseVisualStyleBackColor = true;
			this.chk_Topmost.Click += new System.EventHandler(this.chk_Topmost_Click);
			// 
			// chk_Rotate
			// 
			this.chk_Rotate.AutoSize = true;
			this.chk_Rotate.Location = new System.Drawing.Point(25, 19);
			this.chk_Rotate.Name = "chk_Rotate";
			this.chk_Rotate.Size = new System.Drawing.Size(71, 17);
			this.chk_Rotate.TabIndex = 22;
			this.chk_Rotate.Text = "Вращать";
			this.chk_Rotate.UseVisualStyleBackColor = true;
			this.chk_Rotate.Click += new System.EventHandler(this.chk_Rotate_Click);
			// 
			// chk_Inside
			// 
			this.chk_Inside.AutoSize = true;
			this.chk_Inside.Location = new System.Drawing.Point(25, 42);
			this.chk_Inside.Name = "chk_Inside";
			this.chk_Inside.Size = new System.Drawing.Size(68, 17);
			this.chk_Inside.TabIndex = 23;
			this.chk_Inside.Text = "Вписать";
			this.chk_Inside.UseVisualStyleBackColor = true;
			this.chk_Inside.Click += new System.EventHandler(this.chk_Inside_Click);
			// 
			// chk_Stretch
			// 
			this.chk_Stretch.AutoSize = true;
			this.chk_Stretch.Location = new System.Drawing.Point(25, 65);
			this.chk_Stretch.Name = "chk_Stretch";
			this.chk_Stretch.Size = new System.Drawing.Size(78, 17);
			this.chk_Stretch.TabIndex = 24;
			this.chk_Stretch.Text = "Растянуть";
			this.chk_Stretch.UseVisualStyleBackColor = true;
			this.chk_Stretch.Click += new System.EventHandler(this.chk_Stretch_Click);
			// 
			// chk_Distortion
			// 
			this.chk_Distortion.AutoSize = true;
			this.chk_Distortion.Location = new System.Drawing.Point(25, 89);
			this.chk_Distortion.Name = "chk_Distortion";
			this.chk_Distortion.Size = new System.Drawing.Size(61, 17);
			this.chk_Distortion.TabIndex = 25;
			this.chk_Distortion.Text = "Пучить";
			this.chk_Distortion.UseVisualStyleBackColor = true;
			this.chk_Distortion.Click += new System.EventHandler(this.chk_Distortion_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage3.Controls.Add(this.btn_Help);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(325, 230);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "About";
			// 
			// btn_Help
			// 
			this.btn_Help.Location = new System.Drawing.Point(121, 125);
			this.btn_Help.Name = "btn_Help";
			this.btn_Help.Size = new System.Drawing.Size(75, 23);
			this.btn_Help.TabIndex = 2;
			this.btn_Help.Text = "Help";
			this.btn_Help.UseVisualStyleBackColor = true;
			this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label2.Location = new System.Drawing.Point(118, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "sma63@mail.ru";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(74, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Визуализатор Аудио v2017.06.15";
			// 
			// Panel_Timer
			// 
			this.Panel_Timer.Interval = 1000;
			this.Panel_Timer.Tick += new System.EventHandler(this.Panel_Timer_Tick);
			// 
			// Panel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(333, 256);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(349, 294);
			this.Name = "Panel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
			((System.ComponentModel.ISupportInitialize)(this.trk_Screen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Palitra)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Gamma)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Filter)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
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
		private System.Windows.Forms.TrackBar trk_Volume;
		private System.Windows.Forms.TrackBar trk_Gamma;
		private System.Windows.Forms.Label lab_Gamma;
		private System.Windows.Forms.TrackBar trk_Filter;
		private System.Windows.Forms.TrackBar trk_Palitra;
		private System.Windows.Forms.Button btn_Random;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.Button btn_Load;
		private System.Windows.Forms.TrackBar trk_Screen;
		private System.Windows.Forms.Label lab_Screen;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox chk_Isobar;
		private System.Windows.Forms.CheckBox chk_Spiral;
		private System.Windows.Forms.CheckBox chk_Flex;
		private System.Windows.Forms.CheckBox chk_Topmost;
		private System.Windows.Forms.CheckBox chk_Rotate;
		private System.Windows.Forms.CheckBox chk_Inside;
		private System.Windows.Forms.CheckBox chk_Stretch;
		private System.Windows.Forms.CheckBox chk_Distortion;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button btn_Help;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}