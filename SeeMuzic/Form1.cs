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
using System.Threading;

using Un4seen.Bass;
using audio_sma;

namespace SeeMuzic
{
	public partial class Form1 : Form
	{
		private int _syncer = 0;
		SYNCPROC _syncProcEndStream;
		//public event EventHandler EndStream;
		static int stream1 = 0;

		//const string fname = "Gangnam-Style-PSY.mp3";

		public static int Krat = 14; // (44100 / 14 = 3150) / 25 = 126
		public static int Interval = 40; // 1000 / 40 = 25 кадров в сек.
		public static double Level = 0.7 / 16.0, Leak = 1.0;
		static double level = 1.0;

		static int len = 0;
		static short [] buf;
		static int [] Xbuf, Ybuf;
		static audio_sma.Cic cic = new Cic (Krat, 4);
		static int ibuf = 0;
		//BinaryWriter bw = new BinaryWriter (File.Open ("test.pcm", FileMode.Create));

		static double alpha = 0.0, alpha_plus = 0.5; // угол
		static double x0 = 1.0, y0 = 0.0;
		static double kf = 1.0;

		public static bool bKnopka = false;

		static int palitra = 0; //, palitra_cnt = 0;
		static long fpos = 0, flen = 0;

		static int iFnames = 0;
		static string [] Fnames;

		static int [,] Ref1 = new int [6, 3] { { 0, 1, 2 }, { 0, 2, 1 }, { 1, 0, 2 }, { 1, 2, 0 }, { 2, 0, 1 }, { 2, 1, 0 } }; // порядок цветов

		const int PENW = 4;
		static bool bRestart = false;
		static Pen pen2 = new Pen (Color.Yellow, PENW);

		Random rnd1 = new Random ();

		public Form1 ()
		{
			InitializeComponent ();

			pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

			iFnames = 0;
			string curdir = Directory.GetCurrentDirectory ();
			Fnames = Directory.GetFiles (curdir, "*.mp3", SearchOption.AllDirectories);
			Fnames = Fnames.Union (Directory.GetFiles (curdir, "*.wma", SearchOption.AllDirectories)).ToArray ();
			Fnames = Fnames.Union (Directory.GetFiles (curdir, "*.wav", SearchOption.AllDirectories)).ToArray ();
			if (Fnames.Length <= 0)
			{
				MessageBox.Show (curdir, "Не нашел *.mp3; *.wma в текущей диретории");
				Environment.Exit (0);
			}

			// Перетасовка
			palitra = rnd1.Next (6);
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

			Form1_Next_Title (Fnames [iFnames]);

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

		private void Form1_Next_Title (string s1)
		{
			int p1 = 0, p2 = s1.IndexOf ('\\');
			while (0 <= p2) p2 = s1.IndexOf ('\\', p1 = p2 + 1); // удаление полного пути
			this.Text = s1.Substring (p1);
		}
		// Form1_Next_Title

		private void Form1_FormClosed (object sender, FormClosedEventArgs e)
		{
			Bass.BASS_StreamFree (stream1);
			Bass.BASS_Free ();
			Save_Parms_Xml ();
		}
		// Form1_FormClosed

		private void SyncMethodEndStream (int handle, int channel, int data, IntPtr user)
		{
			bRestart = true;
			//Bass.BASS_ChannelSetPosition (stream1, 0L);
			//Form1_FormClosed (null, null);
			//MessageBox.Show ("SyncMethodEndStream");
			//Form1_Load (null, null);
			/*
						Bass.BASS_StreamFree (stream1);
						stream1 = Bass.BASS_StreamCreateFile (Fnames [iFnames = (iFnames + 1) % Fnames.Length], 0, 0, BASSFlag.BASS_DEFAULT);
						Bass.BASS_ChannelPlay (stream1, false);
						len = (int)Bass.BASS_ChannelSeconds2Bytes (stream1, Interval / 1000.0);
						EventHandler handler = EndStream;
						if (handler != null) handler (this, new EventArgs ());
			*/
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
			// сдесь бы сделать корреляционное выравнивание ...
			Invalidate ();
		}
		// timer1_Tick

		private void timer2_Tick (object sender, EventArgs e)
		{
			if (bRestart)
			{
				bRestart = false;

				Bass.BASS_StreamFree (stream1);
				Bass.BASS_Free ();

				if (!Bass.BASS_Init (-1, 44100, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
				{
					MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
					this.Close ();
				}

				Form1_Next_Title (Fnames [iFnames = (iFnames + 1) % Fnames.Length]);
				stream1 = Bass.BASS_StreamCreateFile (Fnames [iFnames], 0, 0, BASSFlag.BASS_DEFAULT);
				if (stream1 == 0)
				{
					MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
					this.Close ();
				}

				flen = Bass.BASS_ChannelGetLength (stream1);
				_syncer = Bass.BASS_ChannelSetSync (stream1, BASSSync.BASS_SYNC_END, 0, _syncProcEndStream, IntPtr.Zero);
				Bass.BASS_ChannelPlay (stream1, false);
				palitra = rnd1.Next (6);
				alpha_plus = 0.0;
				alpha = 0.0;
			}
			else
			{
				alpha_plus = 30.0 * fpos / flen; //if (360.0 <= (alpha_plus += 0.1)) alpha_plus -= 360.0;
				if (Math.PI < (alpha = alpha + alpha_plus / 180.0 * Math.PI)) alpha -= 2.0 * Math.PI;
				x0 = Math.Cos (alpha);
				y0 = Math.Sin (alpha);
				kf = 1.0 / (Math.Abs (x0) + Math.Abs (y0)); // 0.75; // Math.Abs (x0) + Math.Abs (y0);
				if (bKnopka)
				{
					bKnopka = false;
					btn_M.Visible = true;
					btn_M.Enabled = true;
				}
				timer1.Interval = Interval;
			}
			fpos = Bass.BASS_ChannelGetPosition (stream1);
		}
		// timer2_Tick

		private void Form1_SizeChanged (object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				this.FormBorderStyle = FormBorderStyle.None; // убираю заголовок в полноэкранном режиме
			}
		}
		// Form1_SizeChanged

		private void Form1_MouseDown (object sender, MouseEventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				this.WindowState = FormWindowState.Normal;
				this.FormBorderStyle = FormBorderStyle.Sizable; // возвращаю заголовок в полноэкранном режиме
			}
		}

		// Form1_MouseDown

		static double [] mass0 = null;

		private void Form1_Paint (object sender, PaintEventArgs e)
		{
			if (ibuf <= 0) return;

			int OKNO = ibuf, okno2 = ibuf / 2;

			// кореляция
			double [] mass = new double [256]; // !!!!!!!!!!!!!
			for (int i = 0; i < OKNO; i++)
			{
				mass [i] = Math.Abs (Xbuf [i] + Ybuf [i]);
			}
			if (mass0 != null)
			{
				int imax = 0;
				double si = double.MinValue;
				for (int i = 0; i < OKNO / 2; i++)
				{
					double sj = 0.0;
					for (int j = 0; j < OKNO; j++)
					{
						//sj += Math.Abs (mass0 [j] * mass [(i + j) % OKNO]);
						sj += Math.Abs (mass0 [j] + mass [(i + j) % OKNO]);
					}
					if (si < sj)
					{
						si = sj;
						imax = i;
					}
				}
				for (int i = 0, j = imax; j < OKNO; i++, j++)
				{
					Xbuf [i] = Xbuf [j];
					Ybuf [i] = Ybuf [j];
				}
			}
			mass0 = mass;

			int vsum = 0, vcnt = 0;
			Graphics g = e.Graphics;
			Bitmap bmp1 = new Bitmap (OKNO, OKNO, g);
			for (int x = 0; x < OKNO; x++)
			{
				//int ppp = (palitra + (x < xrange ? 0 : 1)) % 6;
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
							int v = Xbuf [x2] + Ybuf [y2]; if (v < 0) v = -v;
							vsum += v;
							vcnt++;
							v = (int)(v * Level / level);
							if (v < 0) v = 0;
							/*
								int [] ccc = new int [3];

								//if (v < 256) { ccc [0] = v; ccc [1] = 0; ccc [2] = 0; }
								//else if ((v -= 256) < 256) { ccc [0] = 0; ccc [1] = v; ccc [2] = 0; }
								//else if ((v -= 256) < 256) { ccc [0] = 0; ccc [1] = 0; ccc [2] = v; }
								//else { ccc [0] = 255; ccc [1] = 255; ccc [2] = 255; }

								if (v < 256) { ccc [0] = v; ccc [1] = 0; ccc [2] = 0; }
								else if ((v -= 256) < 256) { ccc [0] = 255; ccc [1] = v; ccc [2] = 0; }
								else if ((v -= 256) < 256) { ccc [0] = 255; ccc [1] = 255; ccc [2] = v; }
								else { ccc [0] = 255; ccc [1] = 255; ccc [2] = 255; }

								//ccc [0] = (v < 256 ? v : 255);
								//v >>= 3; ccc [1] = (v < 256 ? v : 255);
								//v >>= 3; ccc [2] = (v < 256 ? v : 255);

								bmp1.SetPixel (x, y, Color.FromArgb (ccc [Ref1 [palitra, 0]], ccc [Ref1 [palitra, 1]], ccc [Ref1 [palitra, 2]]));
							*/
							//bmp1.SetPixel (x, y, ColorFromHSV (v / Level * 60.0 + 360.0 * fpos / flen, 1.0, (v < Level * 2 ? v / Level / 2 : 1.0)));
							bmp1.SetPixel (x, y, ColorFromHSV (v / Level * 45.0 + 225.0, 1.0, (v < Level ? v / Level : 1.0)));
							continue;
						}
					}
					bmp1.SetPixel (x, y, Color.FromArgb (0, 0, 0));
				}
			}
			if (0 < vcnt)
			{
				vsum /= vcnt;
				level += (vsum - level) / Leak;
			}
			Image img1 = bmp1;
			g.DrawImage (img1, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
			g.DrawLine (pen2, (int)(this.ClientSize.Width * fpos / flen), this.ClientSize.Height - PENW, 0, this.ClientSize.Height - PENW);
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
			parms1.Add (new XElement ("LEAK", Leak));
			new XDocument (parms1).Save ("SeeMuz.xml");
		}
		// Save_Parms_Xml

		private void Load_Parms_Xml ()
		{
			try 
			{
				XDocument xdoc = XDocument.Load ("SeeMuz.xml");
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
							case "LEAK": Leak = int.Parse (parm.Value); break;
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

		public static Color ColorFromHSV (double hue, double saturation, double value) //угол, насыщ
		{
			double f = hue / 60 - Math.Floor (hue / 60);

			value = value * 255;
			int v = Convert.ToInt32 (value);
			int p = Convert.ToInt32 (value * (1 - saturation));
			int q = Convert.ToInt32 (value * (1 - f * saturation));
			int t = Convert.ToInt32 (value * (1 - (1 - f) * saturation));

			int hi = Convert.ToInt32 (Math.Floor (hue / 60)) % 6;
			switch (hi)
			{
				case 0: return Color.FromArgb (255, v, t, p);
				case 1: return Color.FromArgb (255, q, v, p);
				case 2: return Color.FromArgb (255, p, v, t);
				case 3: return Color.FromArgb (255, p, q, v);
				case 4: return Color.FromArgb (255, t, p, v);
				default: return Color.FromArgb (255, v, p, q);
			}
		}

		static void Test (double a)
		{
			double x = Math.Cos (a) * 0.7071;
			double y = Math.Sin (a) * 0.7071;
			double z = 0.7071;

			double x1 = (x + z) * 0.7071;
			double y1 = y;
			double z1 = (z - x) * 0.7071;

			double x2 = (x1 - y1) * 0.7071;
			double y2 = (x1 + y1) * 0.7071;
			double z2 = z1;
		}
	}
}
