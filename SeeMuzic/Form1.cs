//#define SPIRAL
//#define KORELAT

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
		const int MIN_RESAMPLE = 5;
		const int MAX_INTERVAL = 250; // [ms] 
		const int SAMPLE_BYTES = 4; // число байт в сампле
		const int AUDIO_SAMPLES = MAX_INTERVAL * 44100 / 1000; // Длина аудиобуффера в самплах
		const int AUDIO_BYTES = AUDIO_SAMPLES * SAMPLE_BYTES; // .. в байтах

		private int _syncer = 0;
		SYNCPROC _syncProcEndStream;
		//public event EventHandler EndStream;
		static int stream1 = 0;

		public static int Palitra = 0;
		public static int Resample = 14; // (44100 / 14 = 3150) / 25 = 126
		public static int Interval = 40; // 1000 / 40 = 25 кадров в сек.
		public static double Bright = 30.0, Leak = 1.0;

		static double Power = 1.0;
		static int Resample2 = Resample; // контроль изменений Resample 

		static int audio_bytes = 0;
		static short [] audiobuf = new short [AUDIO_BYTES];
		static int [] Xbuf = new int [AUDIO_SAMPLES / MIN_RESAMPLE];
		static int [] Ybuf = new int [AUDIO_SAMPLES / MIN_RESAMPLE];
		static double [] Xrot = new double [AUDIO_SAMPLES / MIN_RESAMPLE / 2];
		static double [] Yrot = new double [AUDIO_SAMPLES / MIN_RESAMPLE / 2];
		static audio_sma.Cic cic = new Cic (Resample, 4);

		static double alpha = 0.0; // угол
		static double x0 = 1.0, y0 = 0.0;
		static double kf = 1.0;

		static long fpos = 0, flen = 0;
		static int iFnames = 0;
		static string [] Fnames;

		const int PENW = 4;
		static Pen pen2 = new Pen (Color.Yellow, PENW);

		static Random rnd1 = new Random ();

		static Font fnt1 = new Font ("Arial", 10.0f);

		static double pct = 0.0;

		public static int iFilter = 1, iFilter2 = 1;
		static Fir Xfir = null;
		static Fir Yfir = null;
		static Fir [] Mfir = new Fir [] 
		{
			null, null, //0
			null, null, //1
			new Fir (33, Fir.coef2), new Fir (33, Fir.coef2),
			new Fir (33, Fir.coef3), new Fir (33, Fir.coef3),
			new Fir (33, Fir.coef4), new Fir (33, Fir.coef4),
		};

		static bool bRestart = false;
		public static bool bKnopka = false;

		public static bool bRotate = true; // крутить
		public static bool bStretch = false; // растянуть
		public static bool bInside = true; // вписать

		public Form1 ()
		{
			InitializeComponent ();

			pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

			iFnames = 0;
			string curdir = Directory.GetCurrentDirectory ();
			Fnames = Directory.GetFiles (curdir, "*.mp3", SearchOption.AllDirectories);
			//Fnames = Fnames.Union (Directory.GetFiles (curdir, "*.wma", SearchOption.AllDirectories)).ToArray ();
			//Fnames = Fnames.Union (Directory.GetFiles (curdir, "*.wav", SearchOption.AllDirectories)).ToArray ();
			if (Fnames.Length <= 0)
			{
				MessageBox.Show (curdir, "Не нашел *.mp3, *.wma, *.wav в текущей диретории");
				Environment.Exit (0);
			}

			// Перетасовка
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

			_syncProcEndStream = new SYNCPROC (SyncMethodEndStream);
			_syncer = Bass.BASS_ChannelSetSync (stream1, BASSSync.BASS_SYNC_END, 0, _syncProcEndStream, IntPtr.Zero);
			Bass.BASS_ChannelPlay (stream1, false);
			Palitra = rnd1.Next (14);

			audio_bytes = (int)Bass.BASS_ChannelSeconds2Bytes (stream1, Interval / 1000.0); // текущая длина аудиобуффера в байтах

			//MessageBox.Show (String.Format ("Interval = {0}\nbuflen = {1}\nlen4 = {2}\nlencic = {3}", Interval, audio_bytes, audio_bytes / 4, audio_bytes / 4 / Resample));

			for (int i = 0; i < Xrot.Length; i++)
			{
				Xrot [i] = 1.0;
				Yrot [i] = 0.0;
			}

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
		}
		// SyncMethodEndStream

		private void timer1_Tick (object sender, EventArgs e)
		{
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
				Palitra = rnd1.Next (14);
			}
			fpos = Bass.BASS_ChannelGetPosition (stream1);
			audio_bytes = (int)Bass.BASS_ChannelSeconds2Bytes (stream1, Interval / 1000.0); // текущая длина аудиобуффера в байтах

			// перезапуск ресамплера
			if (Resample != Resample2)
			{
				Resample2 = Resample;
				cic = new Cic (Resample, 4);
			}

			pct = (double)fpos / flen;
#if SPIRAL
			alpha = 1.0 * Math.PI * pct;
			double a = 0.0;
			int nnn = (int)(audio_bytes / SAMPLE_BYTES / Resample / 1.4142);
			for (int i = 0; i < nnn; i++)
			{
				a = alpha * i / nnn; //внутрь
				//a = alpha * (nnn - 1 - i) / nnn; //вширь
				Xrot [i] = Math.Cos (a);
				Yrot [i] = Math.Sin (a);
			}
			x0 = Math.Cos (alpha); // внутрь
			y0 = Math.Sin (alpha);
			//x0 = 1.0; // вширь
			//y0 = 0.0; 
#else
			if (bRotate)
			{
				alpha = 4.0 * 2.0 * Math.PI * pct * pct;
				x0 = Math.Cos (alpha);
				y0 = Math.Sin (alpha);
			}
			else
			{
				alpha = 0.0;
				x0 = 1.0;
				y0 = 0.0;
			}
#endif
			if (bKnopka)
			{
				bKnopka = false;
				btn_M.Visible = true;
				btn_M.Enabled = true;
			}

			if (iFilter != iFilter2)
			{
				iFilter2 = iFilter;
				Xfir = Mfir [iFilter * 2];
				Yfir = Mfir [iFilter * 2 + 1];
			}

			timer1.Interval = Interval;
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

		static double [] kor0 = new double [AUDIO_SAMPLES / MIN_RESAMPLE];
		static double [] kor1 = new double [AUDIO_SAMPLES / MIN_RESAMPLE];

		private void Form1_Paint (object sender, PaintEventArgs e)
		{
			int Okno = 0;
			int samples = Bass.BASS_ChannelGetData (stream1, audiobuf, audio_bytes) / SAMPLE_BYTES; // число самплов в аудиобуффере
			for (int i = 0, j = 0; i < samples; i++, j += 2)
			{
				if (cic.Decimate ((int)audiobuf [j], (int)audiobuf [j + 1]))
				{
					if (iFilter2 < 2)
					{
						Xbuf [Okno] = cic.X;
						Ybuf [Okno] = cic.Y;
					}
					else
					{
						Xbuf [Okno] = (int)Xfir.Go ((double)cic.X);
						Ybuf [Okno] = (int)Yfir.Go ((double)cic.Y);
					}
					Okno++;
				}
			}
			if (Okno == 0) return;

			int Okno2 = Okno / 2; // центр окна

#if KORELAT
			// кореляция
			for (int i = 0; i < Okno; i++)
			{
				kor0 [i] = Math.Abs (Xbuf [i]);
			}
			int imax = 0;
			double si = double.MinValue;
			for (int i = 0; i < Okno / 2; i++)
			{
				double sj = 0.0;
				for (int j = 0; j < Okno; j++)
				{
					sj += Math.Abs (kor0 [j] + kor1 [(i + j) % Okno]);
				}
				if (si < sj)
				{
					si = sj;
					imax = i;
				}
			}
			for (int i = 0, j = imax; j < Okno; i++, j++)
			{
				Xbuf [i] = Xbuf [j];
				Ybuf [i] = Ybuf [j];
			}
			double [] swap = kor0; kor0 = kor1; kor1 = swap;
#endif
			int vcnt = 0;
			double vsum2 = 0.0;
			Graphics g = e.Graphics;
			Bitmap bmp1 = new Bitmap (Okno, Okno, g);

#if SPIRAL
			// Спираль
			int rrr = (int)(Okno2 * 1.4142);
			kf = (Math.Abs (Xrot [rrr]) + Math.Abs (Yrot [rrr])); // внутрь
			//kf = 0.7071 / (Math.Abs (Xrot [rrr]) + Math.Abs (Yrot [rrr])); // вширь
			for (int x = 0; x < Okno; x++)
			{
				for (int y = 0; y < Okno; y++)
				{
					double x1 = (x - Okno2) * kf;
					double y1 = (y - Okno2) * kf;
					int r = (int)Math.Sqrt (x1 * x1 + y1 * y1);
					double x0 = Xrot [r];
					double y0 = Yrot [r];
					int x2 = (int)(x0 * x1 + y0 * y1) + Okno2;
					if ((0 <= x2) && (x2 < Okno))
					{
						int y2 = (int)(x0 * y1 - y0 * x1) + Okno2;
						if ((0 <= y2) && (y2 < Okno))
						{
							int v = Math.Abs (Xbuf [x2] + Ybuf [y2]);
							vsum2 += v * v;
							vcnt++;
							v = (int)(v * Bright / Power);
							if (v < 0) v = 0;

							if (Palitra < 6)
								bmp1.SetPixel (x, y, ColorFromHSV (Palitra * 60.0 + v, 1.0, (v < Bright ? v / Bright : 1.0)));
							else if (Palitra < 12)
								bmp1.SetPixel (x, y, ColorFromHSV (720.0 - (Palitra * 60.0 + v), 1.0, (v < Bright ? v / Bright : 1.0)));
							else if (Palitra < 13)
								bmp1.SetPixel (x, y, ColorFromHSV (720.0 * pct + v, 1.0, (v < Bright ? v / Bright : 1.0)));
							else
								bmp1.SetPixel (x, y, ColorFromHSV (720.0 - (720.0 * (1.0 - pct) + v), 1.0, (v < Bright ? v / Bright : 1.0)));
							continue;
						}
					}
					bmp1.SetPixel (x, y, Color.Black);
				}
			}
#else
			// Решетка
			if (bInside)
				kf = 1.0 * (Math.Abs (x0) + Math.Abs (y0));
			else
				kf = 1.0 / (Math.Abs (x0) + Math.Abs (y0));
			for (int x = 0; x < Okno; x++)
			{
				for (int y = 0; y < Okno; y++)
				{
					double x1 = (x - Okno2) * kf;
					double y1 = (y - Okno2) * kf;
					int x2 = Okno2 + (int)(x0 * x1 + y0 * y1);
					if ((0 <= x2) && (x2 < Okno))
					{
						int y2 = Okno2 + (int)(x0 * y1 - y0 * x1);
						if ((0 <= y2) && (y2 < Okno))
						{
							int v = Math.Abs (Xbuf [x2] + Ybuf [y2]);
							vsum2 += v * v;
							vcnt++;
							v = (int)(v / Power * Bright);
							if (v < 0) v = 0;

							if (Palitra < 6)
								bmp1.SetPixel (x, y, ColorFromHSV (Palitra * 60.0 + v, 1.0, (v < Bright ? v / Bright : 1.0)));
							else if (Palitra < 12)
								bmp1.SetPixel (x, y, ColorFromHSV (720.0 - (Palitra * 60.0 + v), 1.0, (v < Bright ? v / Bright : 1.0)));
							else if (Palitra < 13)
								bmp1.SetPixel (x, y, ColorFromHSV (720.0 * pct + v, 1.0, (v < Bright ? v / Bright : 1.0)));
							else
								bmp1.SetPixel (x, y, ColorFromHSV (720.0 - (720.0 * (1.0 - pct) + v), 1.0, (v < Bright ? v / Bright : 1.0)));
							continue;
						}
					}
					bmp1.SetPixel (x, y, Color.Black);
				}
			}
#endif
			if (0 < vcnt) Power += (Math.Sqrt (vsum2 / vcnt) - Power) / Leak;

			Image img1 = bmp1;
			if (bStretch)
			{
				g.DrawImage (img1, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
			}
			else
			{
				int side = Math.Min (this.ClientSize.Width, this.ClientSize.Height);
				g.DrawImage (img1, (this.ClientSize.Width - side) / 2, (this.ClientSize.Height - side) / 2, side, side);
			}
			g.DrawLine (pen2, (int)(this.ClientSize.Width * fpos / flen), this.ClientSize.Height - PENW, 0, this.ClientSize.Height - PENW);
			//g.DrawString (kf.ToString (), fnt1, Brushes.Yellow, 0.0f, 0.0f);
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
			parms1.Add (new XElement ("BRIGHT", Bright));
			parms1.Add (new XElement ("INTERVAL", Interval));
			parms1.Add (new XElement ("RESAMPLE", Resample));
			parms1.Add (new XElement ("LEAK", Leak));
			parms1.Add (new XElement ("FILTER", iFilter));
			parms1.Add (new XElement ("ROTATE", bRotate));
			parms1.Add (new XElement ("STRETCH", bStretch));
			parms1.Add (new XElement ("INSIDE", bInside));
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
							case "BRIGHT": Bright = double.Parse (parm.Value); break;
							case "INTERVAL": Interval = int.Parse (parm.Value); break;
							case "RESAMPLE": Resample = int.Parse (parm.Value); break;
							case "LEAK": Leak = int.Parse (parm.Value); break;
							case "FILTER": iFilter = int.Parse (parm.Value); break;
							case "ROTATE": bRotate = bool.Parse (parm.Value); break;
							case "STRETCH": bStretch = bool.Parse (parm.Value); break;
							case "INSIDE": bInside = bool.Parse (parm.Value); break;
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

		public static Color ColorFromHSV (double hue, double saturation, double value) //угол, насыщ, яркость
		{
			if (hue < 0.0) hue = (hue / 360.0 + Math.Floor (hue / 360.0)) * 360.0;
			if (saturation < 0.0) saturation = 0.0; else if (1.0 < saturation) saturation = 1.0;
			if (value < 0.0) value = 0.0; else if (1.0 < value) value = 1.0;

			double h = hue / 60.0;
			double f = h - Math.Floor (h);

			value = value * 255.0;
			int v = Convert.ToInt32 (value);
			int p = Convert.ToInt32 (value * (1 - saturation));
			int q = Convert.ToInt32 (value * (1 - f * saturation));
			int t = Convert.ToInt32 (value * (1 - (1 - f) * saturation));

			int hi = Convert.ToInt32 (Math.Floor (h)) % 6;
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
