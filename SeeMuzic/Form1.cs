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
using System.Xml;
using System.Xml.Linq;
using Un4seen.Bass;
using audio_sma;

namespace SeeMuzic
{
	public partial class Form1 : Form
	{
		private int _syncer = 0;
		SYNCPROC _syncProcEndStream;
		public event EventHandler EndStream;
		static int stream1 = 0;

		const string fname = "Gangnam-Style-PSY.mp3";

		public static int Krat = 14; // (44100 / 14 = 3150) / 25 = 126
		public static int Interval = 40; // 1000 / 40 = 25 кадров в сек.

		static int len = 0;
		static short [] buf;
		static int [] Xbuf, Ybuf;
		static audio_sma.Cic cic = new Cic (Krat, 4);
		static int ibuf = 0;
		//BinaryWriter bw = new BinaryWriter (File.Open ("test.pcm", FileMode.Create));

		static double alpha = 0.0, alpha_plus = 0.5; // угол
		static double x0 = 1.0, y0 = 0.0;
		static double kf = 1.0;

		public static double Level = 0.7 / 16.0;
		public static bool bKnopka = false;

		static int palitra = 0, palitra_cnt = 0;
		static long pos = 0, flen = 0;

		static int iFnames = 0;
		static string [] Fnames;

		static int [,] Ref1 = new int [6, 3] { { 0, 1, 2}, { 0, 2, 1 }, { 1, 0, 2 }, { 1, 2, 0 }, { 2, 0, 1 }, { 2, 1, 0 } }; // порядок цветов

		public Form1 ()
		{
			InitializeComponent ();

			iFnames = 0;
			Fnames = Directory.GetFiles (Directory.GetCurrentDirectory (), "*.mp3", SearchOption.AllDirectories);
			if (Fnames.Length <= 0)
			{
				MessageBox.Show (Directory.GetCurrentDirectory (), "Чёта не нашел файлов *.mp3 в диретории");
				Environment.Exit (0);
			}

			// Перетасовка
			Random rnd1 = new Random ();
			for (int i = 0; i < Fnames.Length; i++)
			{
				int j = rnd1.Next (Fnames.Length);
				int k = rnd1.Next (Fnames.Length);
				string swap = Fnames [j]; Fnames [j] = Fnames [k]; Fnames [k] = swap;
			}
			Load_Parms_Xml ();
		}
		// Form1

		private void Form1_Load (object sender, EventArgs e)
		{
			if (!Bass.BASS_Init (-1, 44100, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
			{
				MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
				this.Close ();
			}

			stream1 = Bass.BASS_StreamCreateFile (Fnames [iFnames], 0, 0, BASSFlag.BASS_DEFAULT);
			if (stream1 == 0)
			{
				MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
				this.Close ();
			}

			flen = Bass.BASS_ChannelGetLength (stream1);

			len = (int)Bass.BASS_ChannelSeconds2Bytes (stream1, Interval / 1000.0);
			//MessageBox.Show (String.Format ("len = {0}\nlen4 = {1}\nlencic = {2}", len, len / 4, len / 4 / Krat));

			buf = new short [len];
			Xbuf = new int [len / 4 / Krat + 1];
			Ybuf = new int [len / 4 / Krat + 1];

			_syncProcEndStream = new SYNCPROC (SyncMethodEndStream);
			_syncer = Bass.BASS_ChannelSetSync (stream1, BASSSync.BASS_SYNC_END, 0, _syncProcEndStream, IntPtr.Zero);
			Bass.BASS_ChannelPlay (stream1, false);

			timer1.Interval = Interval;
			timer1.Enabled = true;
			timer2.Enabled = true;
		}
		// Form1_Load

		private void Form1_FormClosed (object sender, FormClosedEventArgs e)
		{
			Bass.BASS_StreamFree (stream1);
			Bass.BASS_Free ();
			Save_Parms_Xml ();
		}
		// Form1_FormClosed

		private void SyncMethodEndStream (int handle, int channel, int data, IntPtr user)
		{
			//Bass.BASS_ChannelSetPosition (stream1, 0L);
			//Form1_FormClosed (null, null);
			//MessageBox.Show ("SyncMethodEndStream");
			//Form1_Load (null, null);
			Bass.BASS_StreamFree (stream1);
			stream1 = Bass.BASS_StreamCreateFile (Fnames [iFnames = (iFnames + 1) % Fnames.Length], 0, 0, BASSFlag.BASS_DEFAULT);
			Bass.BASS_ChannelPlay (stream1, false);
			len = (int)Bass.BASS_ChannelSeconds2Bytes (stream1, Interval / 1000.0);
			EventHandler handler = EndStream;
			if (handler != null) handler (this, new EventArgs ());
		}
		// SyncMethodEndStream

		//private void OnEndStream ()
		//{
		//	EventHandler handler = EndStream;
		//	if (handler != null) handler (this, new EventArgs ());
		//}
		// OnEndStream

		private void timer1_Tick (object sender, EventArgs e)
		{
			ibuf = 0;
			int len4 = Bass.BASS_ChannelGetData (stream1, buf, len) / 4;
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
			if (32 < ++palitra_cnt)
			{
				palitra_cnt = 0;
				palitra = (palitra + 1) % 6;
			}
			pos = Bass.BASS_ChannelGetPosition (stream1);
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
					double x1 = (x - okno2) * kf;
					double y1 = (y - okno2) * kf;
					int x2 = (int)(x0 * x1 + y0 * y1) + okno2;
					if ((0 <= x2) && (x2 < OKNO))
					{
						int y2 = (int)(x0 * y1 - y0 * x1) + okno2;
						if ((0 <= y2) && (y2 < OKNO))
						{
							int v = (int)(Math.Abs ((Xbuf [x2] + Ybuf [y2]) * Level));

							int [] ccc = new int [3];
							if (v < 256)
							{
								ccc [0] = v;
								ccc [1] = 0;
								ccc [2] = 0;
							}
							else if (v < 512)
							{
								ccc [0] = 255;
								ccc [1] = v - 256;
								ccc [2] = 0;
							}
							else if (v < 512 + 256)
							{
								ccc [0] = 255;
								ccc [1] = 255;
								ccc [2] = v - 512;
							}
							else
							{
								ccc [0] = 255;
								ccc [1] = 255;
								ccc [2] = 255;
							}

							bmp1.SetPixel (x, y, Color.FromArgb (ccc [Ref1 [palitra, 0]], ccc [Ref1 [palitra, 1]], ccc [Ref1 [palitra, 2]]));
							continue;
						}
					}
					bmp1.SetPixel (x, y, Color.FromArgb (0, 0, 0));
				}
			}
			Image img1 = bmp1;
			g.DrawImage (img1, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
			g.DrawLine (Pens.Yellow, 0, 0, (int)(this.ClientSize.Width * pos / flen), (int)(this.ClientSize.Height * pos / flen));
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

		private void Save_Parms_Xml ()
		{
			XElement parms1 = new XElement ("PARMS");
			parms1.Add (new XElement ("LEVEL", Level));
			parms1.Add (new XElement ("INTERVAL", Interval));
			parms1.Add (new XElement ("KRAT", Krat));
			new XDocument (parms1).Save ("parms.xml");
		}
		// Save_Parms_Xml

		private void Load_Parms_Xml ()
		{
			try 
			{
				XDocument xdoc = XDocument.Load ("parms.xml");
				IEnumerable<XElement> parms = from f in (from p in xdoc.Elements () where p.Name.ToString ().ToUpper () == "PARMS" select p).Elements () select f;
				foreach (XElement parm in parms)
				{
					try
					{
						switch (parm.Name.ToString ().ToUpper ())
						{
							case "LEVEL": Level = double.Parse (parm.Value); break;
							case "INTERVAL": Interval = int.Parse (parm.Value); break;
							case "KRAT": Krat = int.Parse (parm.Value); break;
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}
		// Load_Parms_Xml

	}
}
