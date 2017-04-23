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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SeeMuzic
{
	public partial class Form1 : Form
	{
		const string fname = "Зодиак - Космическая музыка.mp3";
		const int TIMER_INTERVAL_MS = 40; // 1000 / 40 = 25 кадров в сек.
		const int CICKRAT = 14; // (44100 / 14 = 3150) / 25 = 126

		static int stream = 0;
		static int len = 0;
		static short [] buf;
		static int [] Xbuf, Ybuf;
		static audio_sma.Cic cic = new Cic (CICKRAT, 4);
		static int ibuf = 0;
		//static BinaryFormatter formatter = new BinaryFormatter ();
		//static FileStream fs = new FileStream ("test.pcm", FileMode.Append);
		BinaryWriter bw = new BinaryWriter (File.Open ("test.pcm", FileMode.Create));

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

			len = (int)Bass.BASS_ChannelSeconds2Bytes (stream, TIMER_INTERVAL_MS / 1000.0);
			//MessageBox.Show (String.Format ("len = {0}\nlen4 = {1}\nlencic = {2}", len, len / 4, len / 4 / CICKRAT));
			buf = new short [len];
			Xbuf = new int [len / 4 / CICKRAT + 1];
			Ybuf = new int [len / 4 / CICKRAT + 1];

			Bass.BASS_ChannelPlay (stream, false);

			timer1.Interval = TIMER_INTERVAL_MS;
			timer1.Enabled = true;
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
//
			//int len4 = Bass.BASS_ChannelGetData (stream, buf, len);
			//bw.Write ((short)len4);
			//int nnn = len4 / 2 / CICKRAT;
			//byte [] bbb = new byte [nnn];
			//for (int i = 0, j = 0; i < len4 / 4; i += 2)
			//{
			//	if (cic.Decimate ((int)buf [i], (int)buf [i + 1]))
			//	{
			//		if (j <= nnn - 4)
			//		{
			//			bbb [j++] = (byte)cic.X;
			//			bbb [j++] = (byte)(cic.X >> 8);
			//			bbb [j++] = (byte)cic.Y;
			//			bbb [j++] = (byte)(cic.Y >> 8);
			//		}
			//	}
			//}
			//bw.Write (bbb);
			//formatter.Serialize (fs, test);
			
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

		const int OKNO = 64;

		private void Form1_Paint (object sender, PaintEventArgs e)
		{
			if (ibuf <= 0) return;

			int OKNO = ibuf;
			Graphics g = e.Graphics;
			Bitmap bmp1 = new Bitmap (OKNO, OKNO, g);
			for (int x = 0; x < OKNO; x++)
			{
				for (int y = 0; y < OKNO; y++)
				{
					//int eee = (Xbuf [x] + Ybuf [y]) / 64;
					//if (0 < eee)
					//{
					//	bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (0, eee & 255, 0));
					//}
					//else
					//{
					//	bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (-eee & 255, 0, 0));
					//}
					int eee = (int)(Math.Abs ((Xbuf [x] + Ybuf [y]) / 64));
					//int eee = (int)((Math.Abs (Xbuf [x]) + Math.Abs (Ybuf [y])) / 64);
					if (eee < 256)
						bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (0, 0, eee));
					else if (eee < 512)
						bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (eee - 256, 0, 255));
					else if (eee < 512 + 256)
						bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (255, eee - 512, 255));
					else
						bmp1.SetPixel (x, OKNO - y - 1, Color.FromArgb (255, 255, 255));
				}
			}
			Image img1 = bmp1;
			//g.DrawImage (img1, 0, 0, OKNO, OKNO);
			g.DrawImage (img1, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
		}
		// Form1_Paint

	}
}
