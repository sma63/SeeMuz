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
		const double LEAK = 16.0;
		const double LEVEL = 16.0;
		const int INTERVAL = 10, INTERVAL2 = 30;
		const int KRAT = 7;

		public Panel ()
		{
			InitializeComponent ();
			trk_Front.Value = Ranger10 (Form1.Leak / LEAK);
			trk_Level.Value = Ranger10 (Form1.Level / LEVEL);
			trk_Interval.Value = Ranger10 ((Form1.Interval - INTERVAL2) / INTERVAL);
			trk_Krat.Value = Ranger10 (Form1.Krat - KRAT);

			lab_Front.Text = String.Format ("Front = {0}", Form1.Leak);
			lab_Level.Text = String.Format ("Level = {0}", Form1.Level);
			lab_Interval.Text = String.Format ("Interval = {0} ms", Form1.Interval);
			lab_Krat.Text = String.Format ("Fs = {0} Hz", 44100 / Form1.Krat);
		}

		private void trk_Front_ValueChanged (object sender, EventArgs e)
		{
			Form1.Leak = trk_Front.Value * LEAK;
			lab_Front.Text = String.Format ("Front = {0}", Form1.Leak);
		}

		private void trk_Level_ValueChanged (object sender, EventArgs e)
		{
			Form1.Level = trk_Level.Value * LEVEL;
			lab_Level.Text = String.Format ("Level = {0}", Form1.Level);
		}

		private void trk_Interval_ValueChanged (object sender, EventArgs e)
		{
			Form1.Interval = INTERVAL2 + trk_Interval.Value * INTERVAL;
			lab_Interval.Text = String.Format ("Interval = {0} ms", Form1.Interval);
		}

		private void trk_Krat_ValueChanged (object sender, EventArgs e)
		{
			Form1.Krat = trk_Krat.Value + KRAT;
			lab_Krat.Text = String.Format ("Fs = {0} Hz", 44100 / Form1.Krat);
		}

		private void Panel_FormClosed (object sender, FormClosedEventArgs e)
		{
			Form1.bKnopka = true;
		}

		private int Ranger10 (double v)
		{
			if (v < 1.0) return 1;
			if (10.0 < v) return 10;
			return (int)v;
		}

	}
}
