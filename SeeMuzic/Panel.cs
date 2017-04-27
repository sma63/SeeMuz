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
		const double DELITEL = 32.0;
		const double POWER = 0.9;

		public Panel ()
		{
			InitializeComponent ();
			trk_Level.Value = (int)(1 + trk_Level.Maximum - Math.Log (Form1.Level * DELITEL) / Math.Log (POWER));
			trk_Interval.Value = (Form1.Interval - 40) / 10;
			trk_Krat.Value = Form1.Krat - 8;
		}

		private void trackBar1_ValueChanged (object sender, EventArgs e)
		{
			Form1.Level = Math.Pow (POWER, trk_Level.Maximum - trk_Level.Value + 1) / DELITEL;
			lab_Level.Text = String.Format ("Level = {0:0.000}", Form1.Level);
		}

		private void Panel_FormClosed (object sender, FormClosedEventArgs e)
		{
			Form1.bKnopka = true;
		}

		private void trk_Interval_ValueChanged (object sender, EventArgs e)
		{
			Form1.Interval = 40 + trk_Interval.Value * 10;
			lab_Interval.Text = String.Format ("Interval = {0} ms", Form1.Interval);
		}

		private void trk_Krat_ValueChanged (object sender, EventArgs e)
		{
			Form1.Krat = 8 + trk_Krat.Value;
			lab_Krat.Text = String.Format ("Fs = {0} Hz", 44100 / Form1.Krat);
		}
	}
}
