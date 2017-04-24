using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Un4seen.Bass;
using audio_sma;

namespace SeeMuzic
{
	public partial class Form1 : Form
	{
		const string fname = "space-symphony.mp3";

		public static int Krat = 14; // (44100 / 14 = 3150) / 25 = 126
		public static int Interval = 40; // 1000 / 40 = 25 кадров в сек.

		static int stream = 0;
		static int len = 0;
		static short [] buf;
		static int [] Xbuf, Ybuf;
		static audio_sma.Cic cic = new Cic (Krat, 4);
		static int ibuf = 0;
		BinaryWriter bw = new BinaryWriter (File.Open ("test.pcm", FileMode.Create));

		static double alpha = 0.0, alpha_plus = 0.5; // угол
		static double x0 = 1.0, y0 = 0.0;
		static double kf = 1.0;

		public static double Level = 0.7 / 16.0;
		public static bool bKnopka = false;

		static int palitra = 0, palitra_cnt = 0;

		public Form1 ()
		{
			InitializeComponent ();
		}
		// Form1

		private void Form1_Load (object sender, EventArgs e)
		{
			if (!Bass.BASS_Init (-1, 44100, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
			{
				MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
				this.Close ();
			}

			stream = Bass.BASS_StreamCreateFile (fname, 0, 0, BASSFlag.BASS_DEFAULT);
			if (stream == 0)
			{
				MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
				this.Close ();
			}

			len = (int)Bass.BASS_ChannelSeconds2Bytes (stream, Interval / 1000.0);
			//MessageBox.Show (String.Format ("len = {0}\nlen4 = {1}\nlencic = {2}", len, len / 4, len / 4 / Krat));

			buf = new short [len];
			Xbuf = new int [len / 4 / Krat + 1];
			Ybuf = new int [len / 4 / Krat + 1];

			Bass.BASS_ChannelPlay (stream, false);

			timer1.Interval = Interval;
			timer1.Enabled = true;
			timer2.Enabled = true;
		}
		// Form1_Load

		private void Form1_FormClosed (object sender, FormClosedEventArgs e)
		{
			Bass.BASS_StreamFree (stream);
			Bass.BASS_Free ();
		}
		// Form1_FormClosed

		private void timer1_Tick (object sender, EventArgs e)
		{
			ibuf = 0;
			int len4 = Bass.BASS_ChannelGetData (stream, buf, len) / 4;
			for (int i = 0; i < len4; i += 2)
			{
				if (cic.Decimate ((int)buf [i], (int)buf [i + 1]))
				{
					Xbuf [ibuf] = cic.X;
					Ybuf [ibuf] = cic.Y;
					ibuf++;
				}
			}
			Invalidate ();
		}
		// timer1_Tick

		private void timer2_Tick (object sender, EventArgs e)
		{
			if (Math.PI < (alpha = alpha + alpha_plus / 180.0 * Math.PI)) alpha -= 2.0 * Math.PI;
			//if (360.0 <= (alpha_plus += 0.1)) alpha_plus -= 360.0;
			x0 = Math.Cos (alpha);
			y0 = Math.Sin (alpha);
			kf = 0.75; // 1.0 / (Math.Abs (x0) < Math.Abs (y0) ? Math.Abs (y0) : Math.Abs (x0));
			if (bKnopka)
			{
				bKnopka = false;
				btn_M.Visible = true;
				btn_M.Enabled = true;
			}
			timer1.Interval = Interval;
			if (100 < ++palitra_cnt)
			{
				palitra_cnt = 0;
				palitra = (palitra + 1) % 3;
			}
		}
		// timer2_Tick

		private void Form1_Paint (object sender, PaintEventArgs e)
		{
			if (ibuf <= 0) return;

			Graphics g = e.Graphics;
			int OKNO = ibuf, okno2 = ibuf / 2;
			Bitmap bmp1 = new Bitmap (OKNO, OKNO, g);
			for (int x = 0; x < OKNO; x++)
			{
				for (int y = 0; y < OKNO; y++)
				{
					double x1 = (x - okno2) * kf; // 1.4142; // 0.7071;
					double y1 = (y - okno2) * kf; // 1.4142; // 0.7071;
					int x2 = (int)(x0 * x1 + y0 * y1) + okno2;
					if ((0 <= x2) && (x2 < OKNO))
					{
						int y2 = (int)(x0 * y1 - y0 * x1) + okno2;
						if ((0 <= y2) && (y2 < OKNO))
						{
							int v = (int)(Math.Abs ((Xbuf [x2] + Ybuf [y2]) * Level));
							switch (palitra)
							{
								case 0: bmp1.SetPixel (x, y, (v < 256 ? Color.FromArgb (0, 0, v) : (v < 512 ? Color.FromArgb (v - 256, 0, 255) : (v < 512 + 256 ? Color.FromArgb (255, v - 512, 255) : Color.FromArgb (255, 255, 255))))); break; //blue
								case 1: bmp1.SetPixel (x, y, (v < 256 ? Color.FromArgb (0, v, 0) : (v < 512 ? Color.FromArgb (v - 256, 255, 0) : (v < 512 + 256 ? Color.FromArgb (255, 255, v - 512) : Color.FromArgb (255, 255, 255))))); break; //green
								case 2: bmp1.SetPixel (x, y, (v < 256 ? Color.FromArgb (v, 0, 0) : (v < 512 ? Color.FromArgb (255, v - 256, 0) : (v < 512 + 256 ? Color.FromArgb (255, 255, v - 512) : Color.FromArgb (255, 255, 255))))); break; //red
							}
							continue;
						}
					}
					bmp1.SetPixel (x, y, Color.FromArgb (0, 0, 0));
				}
			}
			Image img1 = bmp1;
			g.DrawImage (img1, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

			//int OKNO = ibuf;
			//Graphics g = e.Graphics;
			//Bitmap bmp1 = new Bitmap (OKNO, OKNO, g);
			//for (int x = 0; x < OKNO; x++)
			//{
			//	for (int y = 0; y < OKNO; y++)
			//	{
			//		int eee = (int)(Math.Abs ((Xbuf [x] + Ybuf [y]) / 64));
			//		if (eee < 256)
			//			bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (0, 0, eee));
			//		else if (eee < 512)
			//			bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (eee - 256, 0, 255));
			//		else if (eee < 512 + 256)
			//			bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (255, eee - 512, 255));
			//		else
			//			bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (255, 255, 255));
			//	}
			//}
			//Image img1 = bmp1;
			//g.DrawImage (img1, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
		}
		// Form1_Paint

		private void button1_Click (object sender, EventArgs e)
		{
			btn_M.Enabled = false;
			btn_M.Visible = false;
			Panel panel1 = new Panel ();
			panel1.Show (this);
		}
		// button1_Click
	}
}
