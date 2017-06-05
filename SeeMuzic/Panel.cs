using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Un4seen.Bass;

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
		bool bPlay = false;

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
			trk_Bright.Value = Ranger10 (Form1.Bright / BRIGHT, -10.0, +10.0);
			trk_Interval.Value = Ranger10 ((Form1.Interval - INTERVAL2) / INTERVAL);
			trk_Resample.Value = Ranger10 (Form1.ResToIdx (Form1.Resample) - Form1.ResToIdx (Form1.MIN_RESAMPLE), 0.0, 9.0);
			trk_Gamma.Value = Ranger10 (Form1.Gamma, -7.0, +7.0);
			trk_Filter.Value = Ranger10 (Form1.iFilter, 1.0, 7.0);
			trk_Palitra.Value = Ranger10 (Form1.Palitra * 20.0, 0.0, 20.0);
			trk_Volume.Value = Ranger10 (Form1.Volume, 0.0, 10.0);

			chk_Rotate.Checked = Form1.bRotate;
			chk_Stretch.Checked = Form1.bStretch;
			chk_Inside.Checked = Form1.bInside;
			chk_Distortion.Checked = Form1.bDistortion;
			chk_Topmost.Checked = Form1.bTopmost;
			chk_Flex.Checked = Form1.bFlex;
			chk_Spiral.Checked = Form1.bSpiral;

			lab_Leak.Text = String.Format ("Норма = {0}", Form1.Leak);
			lab_Level.Text = String.Format ("Ярк = {0}{1}", (0.0 < Form1.Bright ? "+" : ""), Form1.Bright);
			lab_Gamma.Text = String.Format ("Гамма = {0}{1}", (0.0 < Form1.Gamma ? "+" : ""), Form1.Gamma);
			lab_Interval.Text = String.Format ("Инт = {0} ms", Form1.Interval);
			lab_Filter.Text = String.Format ("Фильтр = {0}", Form1.iFilter);
			lab_Palitra.Text = String.Format ("Палитра = {0}", Form1.Palitra);
			lab_Resample.Text = String.Format ("Fs = {0} / {1} = {2} Hz", Form1.SAMPLERATE, Form1.Resample, Form1.SAMPLERATE / Form1.Resample);

			dataGridView1.Rows.Clear ();
			for (int i = 0; i < Form1.ListParam.Count; i++)
			{
				int p1 = Form1.ListParam [i].Fname.LastIndexOf ('\\');
				int sec = Form1.ListParam [i].Length;
				dataGridView1.Rows.Add (Form1.ListParam [i].Fname.Substring (p1 + 1), String.Format ("{0}:{1:00}", sec / 60, sec % 60), Form1.ListParam [i].Fname);
				dataGridView1.Rows [i].HeaderCell.Value = i.ToString ();

			}
			iFnames = Form1.iFnames;
			dataGridView1.Rows [iFnames].Selected = true;
			dataGridView1.CurrentCell = dataGridView1.Rows [iFnames].Cells [0];
			bUpdate = true;

			Panel_Timer.Enabled = true;

			this.tabControl1.SelectedTab = (Form1.bLastPage0 ? this.tabPage0 : this.tabPage1);
		}

		private void Panel_FormClosed (object sender, FormClosedEventArgs e)
		{
			Form1.bLastPage0 = (this.tabControl1.SelectedTab == this.tabPage0);
			Form1.bPanel = false;
		}

		private void tabControl1_SelectedIndexChanged (object sender, EventArgs e)
		{
			Form1.bLastPage0 = (this.tabControl1.SelectedTab == this.tabPage0);
		}

		private void trk_Front_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Leak = trk_Front.Value * LEAK;
				lab_Leak.Text = String.Format ("Норма = {0}", Form1.Leak);
			}
		}

		private void trk_Level_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Bright = trk_Bright.Value * BRIGHT;
				lab_Level.Text = String.Format ("Ярк = {0}{1}", (0.0 < Form1.Bright ? "+" : ""), Form1.Bright);
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

		private void trk_Resample_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Resample = Form1.IdxToRes (trk_Resample.Value + Form1.ResToIdx (Form1.MIN_RESAMPLE));
				lab_Resample.Text = String.Format ("Fs = {0} / {1} = {2} Hz", Form1.SAMPLERATE, Form1.Resample, Form1.SAMPLERATE / Form1.Resample);
			}
		}

		private void trk_Gamma_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Gamma = trk_Gamma.Value;
				lab_Gamma.Text = String.Format ("Гамма = {0}{1}", (0.0 < Form1.Gamma ? "+" : ""), Form1.Gamma);
			}
		}

		private void trk_Filter_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.iFilter = trk_Filter.Value;
				lab_Filter.Text = String.Format ("Фильтр = {0}", Form1.iFilter);
			}
		}

		private void trk_Palitra_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Palitra = trk_Palitra.Value / 20.0;
				lab_Palitra.Text = String.Format ("Палитра = {0}", Form1.Palitra);
			}
		}

		private void trk_Volume_ValueChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				Form1.Volume = trk_Volume.Value;
				Bass.BASS_ChannelSetAttribute (Form1.Audio_Stream, BASSAttribute.BASS_ATTRIB_VOL, (float)Form1.Volume / 10.0f);
			}
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
			progress_Pos.Value = (int)(Form1.pct * 100.0);
			if (iFnames != Form1.iFnames)
			{
				iFnames = Form1.iFnames;
				dataGridView1.Rows [iFnames].Selected = true;
				dataGridView1.CurrentCell = dataGridView1.Rows [iFnames].Cells [0];
			}
			if (Form1.bFlex)
			{
				trk_Palitra.Value = Ranger10 (Form1.Palitra * 20.0, 0.0, 20.0);
			}
		}

		private void btn_Play_Click (object sender, EventArgs e)
		{
			bPlay = Form1.btn_Panel_Play_Click ();
			btn_Play.BackgroundImage = (bPlay ? SeeMuz.Properties.Resources.player_pause_6166 : SeeMuz.Properties.Resources.player_play_8474);
		}

		private void btn_Prev_Click (object sender, EventArgs e)
		{
			Form1.Audio_Next (-2);
			btn_Play.BackgroundImage = SeeMuz.Properties.Resources.player_pause_6166;
		}

		private void btn_Next_Click (object sender, EventArgs e)
		{
			Form1.Audio_Next (-1);
			btn_Play.BackgroundImage = SeeMuz.Properties.Resources.player_pause_6166;
		}

		private void dataGridView1_SelectionChanged (object sender, EventArgs e)
		{
			if (bUpdate)
			{
				if (0 < dataGridView1.SelectedRows.Count)
				{
					Form1.Audio_Next (dataGridView1.SelectedRows [0].Index);
				}
			}
		}

		private void chk_Eros_CheckedChanged (object sender, EventArgs e)
		{
			Form1.bDistortion = chk_Distortion.Checked;
		}

		private void chk_Topmost_Click (object sender, EventArgs e)
		{
			Form1.himself.TopMost = Form1.bTopmost = chk_Topmost.Checked;
		}

		private void chk_Flex_Click (object sender, EventArgs e)
		{
			Form1.bFlex = chk_Flex.Checked;
		}

		private void chk_Spiral_Click (object sender, EventArgs e)
		{
			Form1.bSpiral = chk_Spiral.Checked;
		}

		private void btn_Load_Click (object sender, EventArgs e)
		{
			// запускать только в режиме Pause
			DialogResult dr1 = MessageBox.Show ("Предварительно очистить плейлист?", "Вопрос", MessageBoxButtons.YesNoCancel);
			if (dr1 == DialogResult.Cancel) return;

			OpenFileDialog openFileDialog1 = new OpenFileDialog ();
			openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory (); ;
			openFileDialog1.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 0;
			openFileDialog1.RestoreDirectory = true;
			openFileDialog1.Multiselect = true;
			if (openFileDialog1.ShowDialog () == DialogResult.OK)
			{
				if (bPlay)
				{
					btn_Play_Click (null, null);
					Form1.himself.Audio_Stop ();
				}
				if (Bass.BASS_Init (-1, Form1.SAMPLERATE, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
				{
					bUpdate = false;
					if (dr1 == DialogResult.Yes)
					{
						Form1.ListParam.Clear ();
						dataGridView1.Rows.Clear ();
					}
					foreach (string fnam in openFileDialog1.FileNames)
					{
						Un4seen.Bass.AddOn.Tags.TAG_INFO tags = Un4seen.Bass.AddOn.Tags.BassTags.BASS_TAG_GetFromFile (fnam);
						if (tags != null)
						{
							int stream = Bass.BASS_StreamCreateFile (fnam, 0, 0, BASSFlag.BASS_DEFAULT);
							if (stream != 0)
							{
								Param prm1 = new Param ();
								prm1.Bright = 0.0;
								prm1.iFilter = 0;
								prm1.Gamma = 0.0;
								prm1.Interval = 0;
								prm1.Leak = 0.0;
								prm1.Length = (int)Bass.BASS_ChannelBytes2Seconds (stream, Bass.BASS_ChannelGetLength (stream));
								prm1.Palitra = 0.0;
								prm1.Resample = 0;
								prm1.Fname = fnam;
								Form1.ListParam.Add (prm1);
								Bass.BASS_StreamFree (stream);
							}
						}
					}
					Reload ();
					dataGridView1.Refresh ();
					Bass.BASS_Free ();
				}
				//this.Cursor = Cursors.Default;
			}
		}

		private void btn_Random_Click (object sender, EventArgs e)
		{
			int ifnames = -1;
			try { ifnames = int.Parse (dataGridView1.SelectedRows [0].HeaderCell.Value.ToString ()); } catch { }
			for (int i = 0; i < Form1.ListParam.Count; i++)
			{
				int j = Form1.rnd1.Next (i, Form1.ListParam.Count);
				Param swap = Form1.ListParam [j]; Form1.ListParam [j] = Form1.ListParam [i]; Form1.ListParam [i] = swap;
				if (j == ifnames) ifnames = i; else if (i == ifnames) ifnames = j;
			}
			Form1.iFnames = ifnames;
			Reload ();
			dataGridView1.Refresh ();
		}

		private void dataGridView1_ColumnHeaderMouseClick (object sender, DataGridViewCellMouseEventArgs e)
		{
			int ifnames = -1;
			try { ifnames = int.Parse (dataGridView1.SelectedRows [0].HeaderCell.Value.ToString ()); } catch { }
			List<Param> Lprm1 = new List<Param> ();
			for (int i = 0; i < Form1.ListParam.Count; i++)
			{
				int j = int.Parse (dataGridView1.Rows [i].HeaderCell.Value.ToString ());
				Lprm1.Add (Form1.ListParam [j]);
				if (j == ifnames) Form1.iFnames = i;
			}
			Form1.ListParam = Lprm1;
			Reload ();
			dataGridView1.Refresh ();
		}

		private int Ranger10 (double v, double vmin = 1.0, double vmax = 10.0)
		{
			if (v < vmin) return (int)vmin;
			if (vmax < v) return (int)vmax;
			return (int)v;
		}

	}
}
