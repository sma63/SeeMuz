using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeeMuzic
{
	public partial class Panel : Form
	{
		const double LEAK = 10.0;
		const double BRIGHT = 1.0;
		const int INTERVAL = 10, INTERVAL2 = 0; //1-10,2-20,3-30,4-40,5-50,6-60,7-70,8-80,9-90,10-100
		//const int RESAMPLE = Form1.MIN_RESAMPLE - 1;

		int iFnames = 0;
		bool bUpdate = false;

		//
		// После загрузки новой мелодии обновлять панель (если она активна)
		// 

		public Panel ()
		{
			InitializeComponent ();
			Reload ();
		}

		public void Reload ()
		{
			bUpdate = false;
			trk_Front.Value = Ranger10 (Form1.Leak / LEAK);
			trk_Bright.Value = Ranger10 (Form1.Bright / BRIGHT);
			trk_Interval.Value = Ranger10 ((Form1.Interval - INTERVAL2) / INTERVAL);
			trk_Resample.Value = Ranger10 (Form1.ResToIdx (Form1.Resample) - Form1.ResToIdx (Form1.MIN_RESAMPLE), 0.0, 9.0);
			bUpdate = true;

			num_Palitra.Value = Form1.Palitra;
			num_Filter.Value = Form1.iFilter;
			chk_Rotate.Checked = Form1.bRotate;
			chk_Stretch.Checked = Form1.bStretch;
			chk_Inside.Checked = Form1.bInside;
			chk_Eros.Checked = Form1.bEros;
			chk_Transparency.Checked = Form1.bTrnsparency;

			lab_Front.Text = String.Format ("Норма = {0}", Form1.Leak);
			lab_Level.Text = String.Format ("Ярк = {0}", Form1.Bright);
			lab_Interval.Text = String.Format ("Интер = {0} ms", Form1.Interval);

			lab_Resample.Text = String.Format ("Fs = {0} / {1} = {2} Hz", Form1.SAMPLERATE, Form1.Resample, Form1.SAMPLERATE / Form1.Resample);

			for (int i = 0; i < Form1.Fnames.Length; i++)
			{
				int p1 = Form1.Fnames [i].LastIndexOf ('\\');
				dataGridView1.Rows.Add (Form1.Fnames [i].Substring (p1 + 1), Form1.Fnames [i]);
			}
			iFnames = Form1.iFnames;
			dataGridView1.Rows [iFnames].Selected = true;
			dataGridView1.CurrentCell = dataGridView1.Rows [iFnames].Cells [0];

			Panel_Timer.Enabled = true;
			//Form1.bPanel = true;

			this.tabControl1.SelectedTab = (Form1.bLastPage0 ? this.tabPage0 : this.tabPage1);
		}

		private void Panel_FormClosed (object sender, FormClosedEventArgs e)
		{
			Form1.bLastPage0 = (this.tabControl1.SelectedTab == this.tabPage0);
			Form1.bPanel = false;
		}

		private void trk_Front_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Leak = trk_Front.Value * LEAK;
				lab_Front.Text = String.Format ("Норма = {0}", Form1.Leak);
			}
		}

		private void trk_Level_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Bright = trk_Bright.Value * BRIGHT;
				lab_Level.Text = String.Format ("Ярк = {0}", Form1.Bright);
			}
		}

		private void trk_Interval_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Interval = INTERVAL2 + trk_Interval.Value * INTERVAL;
				lab_Interval.Text = String.Format ("Интер = {0} ms", Form1.Interval);
			}
		}

		private void trk_Krat_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Resample = Form1.IdxToRes (trk_Resample.Value + Form1.ResToIdx (Form1.MIN_RESAMPLE));
				lab_Resample.Text = String.Format ("Fs = {0} / {1} = {2} Hz", Form1.SAMPLERATE, Form1.Resample, Form1.SAMPLERATE / Form1.Resample);
			}
		}

		private void num_Palitra_ValueChanged (object sender, EventArgs e)
		{
			Form1.Palitra = (int)num_Palitra.Value;
		}

		private void num_Filter_ValueChanged (object sender, EventArgs e)
		{
			Form1.iFilter = (int)num_Filter.Value;
		}

		private void chk_Rotate_CheckedChanged (object sender, EventArgs e)
		{
			Form1.bRotate = chk_Rotate.Checked;
		}

		private void chk_Stretch_CheckedChanged (object sender, EventArgs e)
		{
			Form1.bStretch = chk_Stretch.Checked;
		}

		private void chk_Inside_CheckedChanged (object sender, EventArgs e)
		{
			Form1.bInside = chk_Inside.Checked;
		}

		private void Panel_Timer_Tick (object sender, EventArgs e)
		{
			num_Palitra.Value = Form1.Palitra;
			progress_Pos.Value = (int)(Form1.pct * 100.0);
			if (iFnames != Form1.iFnames)
			{
				iFnames = Form1.iFnames;
				dataGridView1.Rows [iFnames].Selected = true;
				dataGridView1.CurrentCell = dataGridView1.Rows [iFnames].Cells [0];
			}
		}

		private void btn_Prev_Click (object sender, EventArgs e)
		{
			Form1.Audio_Next (-2);
		}

		private void btn_Next_Click (object sender, EventArgs e)
		{
			Form1.Audio_Next (-1);
		}

		private void dataGridView1_SelectionChanged (object sender, EventArgs e)
		{
			if (0 < dataGridView1.SelectedRows.Count)
			{
				Form1.Audio_Next (dataGridView1.SelectedRows [0].Index);
			}
		}

		private void chk_Eros_CheckedChanged (object sender, EventArgs e)
		{
			Form1.bEros = chk_Eros.Checked;
		}

		private void btn_Play_Click(object sender, EventArgs e)
		{
			btn_Play.Text = (Form1.btn_Panel_Play_Click () ? "| |" : ">");
		}

		private void chk_Transparency_Click (object sender, EventArgs e)
		{
			Form1.bTrnsparency = chk_Transparency.Checked;
		}

		private int Ranger10 (double v, double vmin = 1.0, double vmax = 10.0)
		{
			if (v < vmin) return (int)vmin;
			if (vmax < v) return (int)vmax;
			return (int)v;
		}

	}
}
