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
			this.num_Filter = new System.Windows.Forms.NumericUpDown();
			this.lab_Filter = new System.Windows.Forms.Label();
			this.chk_Stretch = new System.Windows.Forms.CheckBox();
			this.chk_Inside = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.chk_Rotate = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage0 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btn_Next = new System.Windows.Forms.Button();
			this.btn_Play = new System.Windows.Forms.Button();
			this.btn_Prev = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Panel_Timer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.trk_Level)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Krat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Front)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Palitra)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Filter)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage0.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// trk_Level
			// 
			this.trk_Level.Location = new System.Drawing.Point(6, 49);
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
			this.lab_Level.Location = new System.Drawing.Point(116, 50);
			this.lab_Level.Name = "lab_Level";
			this.lab_Level.Size = new System.Drawing.Size(50, 13);
			this.lab_Level.TabIndex = 6;
			this.lab_Level.Text = "Яркость";
			// 
			// lab_Interval
			// 
			this.lab_Interval.AutoSize = true;
			this.lab_Interval.Location = new System.Drawing.Point(116, 80);
			this.lab_Interval.Name = "lab_Interval";
			this.lab_Interval.Size = new System.Drawing.Size(56, 13);
			this.lab_Interval.TabIndex = 7;
			this.lab_Interval.Text = "Интервал";
			// 
			// trk_Interval
			// 
			this.trk_Interval.Location = new System.Drawing.Point(6, 79);
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
			this.lab_Krat.Location = new System.Drawing.Point(116, 111);
			this.lab_Krat.Name = "lab_Krat";
			this.lab_Krat.Size = new System.Drawing.Size(49, 13);
			this.lab_Krat.TabIndex = 8;
			this.lab_Krat.Text = "Частота";
			// 
			// trk_Krat
			// 
			this.trk_Krat.Location = new System.Drawing.Point(6, 111);
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
			this.lab_Front.Location = new System.Drawing.Point(116, 21);
			this.lab_Front.Name = "lab_Front";
			this.lab_Front.Size = new System.Drawing.Size(69, 13);
			this.lab_Front.TabIndex = 5;
			this.lab_Front.Text = "Накопление";
			// 
			// trk_Front
			// 
			this.trk_Front.Location = new System.Drawing.Point(6, 19);
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
			this.num_Palitra.Location = new System.Drawing.Point(202, 48);
			this.num_Palitra.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
			this.num_Palitra.Name = "num_Palitra";
			this.num_Palitra.ReadOnly = true;
			this.num_Palitra.Size = new System.Drawing.Size(35, 20);
			this.num_Palitra.TabIndex = 4;
			this.num_Palitra.ValueChanged += new System.EventHandler(this.num_Palitra_ValueChanged);
			// 
			// lab_Palitra
			// 
			this.lab_Palitra.AutoSize = true;
			this.lab_Palitra.Location = new System.Drawing.Point(243, 50);
			this.lab_Palitra.Name = "lab_Palitra";
			this.lab_Palitra.Size = new System.Drawing.Size(50, 13);
			this.lab_Palitra.TabIndex = 9;
			this.lab_Palitra.Text = "Палитра";
			// 
			// num_Filter
			// 
			this.num_Filter.Location = new System.Drawing.Point(202, 109);
			this.num_Filter.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.num_Filter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Filter.Name = "num_Filter";
			this.num_Filter.ReadOnly = true;
			this.num_Filter.Size = new System.Drawing.Size(35, 20);
			this.num_Filter.TabIndex = 10;
			this.num_Filter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Filter.ValueChanged += new System.EventHandler(this.num_Filter_ValueChanged);
			// 
			// lab_Filter
			// 
			this.lab_Filter.AutoSize = true;
			this.lab_Filter.Location = new System.Drawing.Point(244, 111);
			this.lab_Filter.Name = "lab_Filter";
			this.lab_Filter.Size = new System.Drawing.Size(47, 13);
			this.lab_Filter.TabIndex = 11;
			this.lab_Filter.Text = "Фильтр";
			// 
			// chk_Stretch
			// 
			this.chk_Stretch.AutoSize = true;
			this.chk_Stretch.Location = new System.Drawing.Point(77, 155);
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
			this.chk_Inside.Location = new System.Drawing.Point(144, 155);
			this.chk_Inside.Name = "chk_Inside";
			this.chk_Inside.Size = new System.Drawing.Size(68, 17);
			this.chk_Inside.TabIndex = 13;
			this.chk_Inside.Text = "Вписать";
			this.chk_Inside.UseVisualStyleBackColor = true;
			this.chk_Inside.CheckedChanged += new System.EventHandler(this.chk_Inside_CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(17, 155);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(54, 17);
			this.checkBox3.TabIndex = 14;
			this.checkBox3.Text = "Гнуть";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// chk_Rotate
			// 
			this.chk_Rotate.AutoSize = true;
			this.chk_Rotate.Location = new System.Drawing.Point(218, 155);
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
			this.tabControl1.Size = new System.Drawing.Size(333, 221);
			this.tabControl1.TabIndex = 16;
			// 
			// tabPage0
			// 
			this.tabPage0.Controls.Add(this.splitContainer1);
			this.tabPage0.Location = new System.Drawing.Point(4, 22);
			this.tabPage0.Name = "tabPage0";
			this.tabPage0.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage0.Size = new System.Drawing.Size(325, 195);
			this.tabPage0.TabIndex = 1;
			this.tabPage0.Text = "Play List";
			this.tabPage0.UseVisualStyleBackColor = true;
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
			this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Next);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Play);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Prev);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(319, 189);
			this.splitContainer1.SplitterDistance = 63;
			this.splitContainer1.TabIndex = 0;
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(5, 33);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(309, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 3;
			// 
			// btn_Next
			// 
			this.btn_Next.Location = new System.Drawing.Point(113, 4);
			this.btn_Next.Name = "btn_Next";
			this.btn_Next.Size = new System.Drawing.Size(48, 23);
			this.btn_Next.TabIndex = 2;
			this.btn_Next.Text = ">>";
			this.btn_Next.UseVisualStyleBackColor = true;
			this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
			// 
			// btn_Play
			// 
			this.btn_Play.Location = new System.Drawing.Point(59, 4);
			this.btn_Play.Name = "btn_Play";
			this.btn_Play.Size = new System.Drawing.Size(48, 23);
			this.btn_Play.TabIndex = 1;
			this.btn_Play.Text = ">";
			this.btn_Play.UseVisualStyleBackColor = true;
			// 
			// btn_Prev
			// 
			this.btn_Prev.Location = new System.Drawing.Point(5, 4);
			this.btn_Prev.Name = "btn_Prev";
			this.btn_Prev.Size = new System.Drawing.Size(48, 23);
			this.btn_Prev.TabIndex = 0;
			this.btn_Prev.Text = "<<";
			this.btn_Prev.UseVisualStyleBackColor = true;
			this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(319, 122);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1.FillWeight = 50F;
			this.Column1.HeaderText = "Файл";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column2.FillWeight = 50F;
			this.Column2.HeaderText = "Путь";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(325, 195);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "View";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.trk_Krat);
			this.groupBox1.Controls.Add(this.trk_Interval);
			this.groupBox1.Controls.Add(this.trk_Level);
			this.groupBox1.Controls.Add(this.trk_Front);
			this.groupBox1.Controls.Add(this.lab_Krat);
			this.groupBox1.Controls.Add(this.lab_Front);
			this.groupBox1.Controls.Add(this.lab_Palitra);
			this.groupBox1.Controls.Add(this.lab_Interval);
			this.groupBox1.Controls.Add(this.chk_Rotate);
			this.groupBox1.Controls.Add(this.num_Filter);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.lab_Level);
			this.groupBox1.Controls.Add(this.chk_Inside);
			this.groupBox1.Controls.Add(this.lab_Filter);
			this.groupBox1.Controls.Add(this.chk_Stretch);
			this.groupBox1.Controls.Add(this.num_Palitra);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 181);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
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
			this.ClientSize = new System.Drawing.Size(333, 221);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Panel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SeeMuz - Настройки";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Panel_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.trk_Level)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Interval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Krat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trk_Front)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Palitra)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Filter)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage0.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TrackBar trk_Krat;//1
		private System.Windows.Forms.TrackBar trk_Interval;//2
		private System.Windows.Forms.TrackBar trk_Level;//3
		public System.Windows.Forms.TrackBar trk_Front;//4

		private System.Windows.Forms.Label lab_Interval;
		private System.Windows.Forms.Label lab_Krat;
		public System.Windows.Forms.Label lab_Level;
		public System.Windows.Forms.Label lab_Front;

		public System.Windows.Forms.NumericUpDown num_Palitra;
		public System.Windows.Forms.NumericUpDown num_Filter;

		private System.Windows.Forms.Label lab_Palitra;
		private System.Windows.Forms.Label lab_Filter;

		private System.Windows.Forms.CheckBox chk_Stretch;
		private System.Windows.Forms.CheckBox chk_Inside;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox chk_Rotate;

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage0;
		private System.Windows.Forms.TabPage tabPage1;

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btn_Next;
		private System.Windows.Forms.Button btn_Play;
		private System.Windows.Forms.Button btn_Prev;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.Timer Panel_Timer;
		public System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}