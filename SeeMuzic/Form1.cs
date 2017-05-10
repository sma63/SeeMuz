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
		public const int SAMPLERATE = 44100;//11025;//22050;//
		public const int MIN_RESAMPLE = 10;
		const int MAX_RESAMPLE = 20;
		const int MAX_INTERVAL = 100; // [ms] 
		const int SAMPLE_BYTES = sizeof (Int32); // число байт в сампле
		const int AUDIO_SAMPLES = (MAX_INTERVAL * SAMPLERATE + 999) / 1000; // Длина аудиобуффера в самплах
		const int AUDIO_BYTES = AUDIO_SAMPLES * SAMPLE_BYTES; // .. в байтах

		private int _syncer = 0;
		SYNCPROC _syncProcEndStream;
		static int stream1 = 0;

		public static int Palitra = 0;
		public static int Interval = 40; // 1000 / 40 = 25 кадров в сек.
		public static double Bright = 30.0, Leak = 1.0;
		public static int Resample = MAX_RESAMPLE; // (44100 / 14 = 3150) / 25 = 126

		static int Resample2 = Resample; // контроль изменений Resample 
		static double Power = 1.0;

		static int audio_bytes = 0;
		static short [] audiobuf = new short [AUDIO_BYTES];
		const int XYBUF = (AUDIO_SAMPLES + MIN_RESAMPLE - 1) / MIN_RESAMPLE;
		static int [] Xbuf = new int [XYBUF];
		static int [] Ybuf = new int [XYBUF];
		const int XYROT = (AUDIO_SAMPLES + MIN_RESAMPLE * 2 - 1) / (MIN_RESAMPLE * 2);
		static double [] Xrot = new double [XYROT];
		static double [] Yrot = new double [XYROT];

		static audio_sma.Cic [] Mcic = new audio_sma.Cic [] 
		{
			new Cic (0, 0), new Cic (1, 1), new Cic (2, 3), new Cic (3, 3), new Cic (4, 3), new Cic (5, 3),
			new Cic (6, 3),	new Cic (7, 3), new Cic (8, 3), new Cic (9, 3), new Cic (10, 3), new Cic (11, 3),
			new Cic (12, 3), new Cic (13, 3), new Cic (14, 3), new Cic (15, 3), new Cic (16, 3), new Cic (17, 3),
			new Cic (18, 3), new Cic (19, 3), new Cic (20, 3)
		};
		static audio_sma.Cic cic = Mcic [Resample];

		static double alpha = 0.0; // угол
		static double x0 = 1.0, y0 = 0.0;
		static double kf = 1.0;

		static long fpos = 0, flen = 0;
		public static int iFnames = 0;
		public static string [] Fnames;

		const int PENW = 4;
		static Pen pen2 = new Pen (Color.Yellow, PENW);

		static Random rnd1 = new Random ();

		static Font fnt1 = new Font ("Arial", 10.0f);

		public static double pct = 0.0;

		public static int iFilter = 1, iFilter2 = 1;
		static Fir Xfir = null, Yfir = null;
		static Fir [,] Mfir = new Fir [8, 2]
		{
			{ null, null }, //0
			{ new Fir (33, Fir.coef2), new Fir (33, Fir.coef2) },
			{ new Fir (33, Fir.coef2), new Fir (33, Fir.coef2) },
			{ new Fir (33, Fir.coef3), new Fir (33, Fir.coef3) },
			{ new Fir (33, Fir.coef4), new Fir (33, Fir.coef4) },
			{ new Fir (33, Fir.coef5), new Fir (33, Fir.coef5) },
			{ new Fir (33, Fir.coef6), new Fir (33, Fir.coef6) },
			{ new Fir (33, Fir.coef7), new Fir (33, Fir.coef7) },
		};

		static bool bRestart = false;
		//public static bool bKnopka = false;

		public static bool bEros = false; // гнуть
		public static bool bRotate = true; // крутить
		public static bool bStretch = false; // растянуть
		public static bool bInside = true; // вписать

		public static bool bPanel = false;

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

			parm1 = new Param [Fnames.Length];
			for (int i = 0; i < parm1.Length; i++)
			{
				parm1 [i] = new Param ();
				parm1 [i].bInside = bInside;
				parm1 [i].Bright = Bright;
				parm1 [i].bRotate = bRotate;
				parm1 [i].bStretch = bStretch;
				parm1 [i].bEros = bEros;
				parm1 [i].iFilter = iFilter;
				parm1 [i].Interval = Interval;
				parm1 [i].Leak = Leak;
				parm1 [i].Palitra = -1;
				parm1 [i].Resample = Resample;
			}

			Palitra = rnd1.Next (14);
			Load_Parms_Xml ();
		}
		// Form1

		private void Form1_Load (object sender, EventArgs e)
		{
			//this.FormBorderStyle = FormBorderStyle.None;
			//this.AllowTransparency = true;
			//this.BackColor = Color.White; // AliceBlue;//цвет фона  
			//this.TransparencyKey = Color.White; // this.BackColor;//он же будет заменен на прозрачный цвет

			if (!Bass.BASS_Init (-1, SAMPLERATE, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
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
			audio_bytes = (int)Bass.BASS_ChannelSeconds2Bytes (stream1, Interval / 1000.0); // текущая длина аудиобуффера в байтах

			_syncProcEndStream = new SYNCPROC (SyncMethodEndStream);
			_syncer = Bass.BASS_ChannelSetSync (stream1, BASSSync.BASS_SYNC_END, 0, _syncProcEndStream, IntPtr.Zero);
			Bass.BASS_ChannelPlay (stream1, false);

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
			Audio_Next (-1);
		}
		// SyncMethodEndStream

		public static void Audio_Next (int idx = -1)
		{
			if (idx < 0)
			{
				parm1 [iFnames].bInside = bInside;
				parm1 [iFnames].Bright = Bright;
				parm1 [iFnames].bRotate = bRotate;
				parm1 [iFnames].bStretch = bStretch;
				parm1 [iFnames].bEros = bEros;
				parm1 [iFnames].iFilter = iFilter;
				parm1 [iFnames].Interval = Interval;
				parm1 [iFnames].Leak = Leak;
				parm1 [iFnames].Palitra = Palitra;
				parm1 [iFnames].Resample = Resample;
				if (idx == -1)
					iFnames = (iFnames + 1) % Fnames.Length;
				else
					iFnames = (iFnames - 1 + Fnames.Length) % Fnames.Length;
				bRestart = true;
			}
			else if (idx != iFnames)
			{
				parm1 [iFnames].bInside = bInside;
				parm1 [iFnames].Bright = Bright;
				parm1 [iFnames].bRotate = bRotate;
				parm1 [iFnames].bStretch = bStretch;
				parm1 [iFnames].bEros = bEros;
				parm1 [iFnames].iFilter = iFilter;
				parm1 [iFnames].Interval = Interval;
				parm1 [iFnames].Leak = Leak;
				parm1 [iFnames].Palitra = Palitra;
				parm1 [iFnames].Resample = Resample;
				iFnames = idx;
				bRestart = true;
			}
		}
		// Audio_Next

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

				if (!Bass.BASS_Init (-1, SAMPLERATE, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
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
				_syncer = Bass.BASS_ChannelSetSync (stream1, BASSSync.BASS_SYNC_END, 0, _syncProcEndStream, IntPtr.Zero);
				Bass.BASS_ChannelPlay (stream1, false);

				if (parm1 [iFnames].Palitra < 0)
				{
					Palitra = rnd1.Next (14);
				}
				else
				{
					bInside = parm1 [iFnames].bInside;
					Bright = parm1 [iFnames].Bright;
					bRotate = parm1 [iFnames].bRotate;
					bStretch = parm1 [iFnames].bStretch;
					bEros = parm1 [iFnames].bEros;
					iFilter = parm1 [iFnames].iFilter;
					Interval = parm1 [iFnames].Interval;
					Leak = parm1 [iFnames].Leak;
					Palitra = parm1 [iFnames].Palitra;
					Resample = parm1 [iFnames].Resample;
				}
			}
			fpos = Bass.BASS_ChannelGetPosition (stream1);
			audio_bytes = (int)Bass.BASS_ChannelSeconds2Bytes (stream1, Interval / 1000.0); // текущая длина аудиобуффера в байтах

			// перезапуск ресамплера
			if (Resample != Resample2)
			{
				Resample2 = Resample;
				cic = Mcic [Resample];
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
			if (iFilter != iFilter2)
			{
				iFilter2 = iFilter;
				Xfir = Mfir [iFilter, 0];
				Yfir = Mfir [iFilter, 1];
			}

			if (!bPanel)
			{
				if (0 < btn_M_Visible_Cnt)
				{
					if (--btn_M_Visible_Cnt <= 0)
					{
						btn_M.Visible = false;
						btn_M.Enabled = false;
					}
				}
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
								bmp1.SetPixel (x, y, H2Color (Palitra * 60.0 + v, 1.0, (v < Bright ? v / Bright : 1.0)));
							else if (Palitra < 12)
								bmp1.SetPixel (x, y, H2Color (720.0 - (Palitra * 60.0 + v), 1.0, (v < Bright ? v / Bright : 1.0)));
							else if (Palitra < 13)
								bmp1.SetPixel (x, y, H2Color (720.0 * pct + v, 1.0, (v < Bright ? v / Bright : 1.0)));
							else
								bmp1.SetPixel (x, y, H2Color (720.0 - (720.0 * (1.0 - pct) + v), 1.0, (v < Bright ? v / Bright : 1.0)));
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
					double x1 = (double)(x - Okno2) / Okno2; //if (0.0 < x1) x1 = 0.9 - x1; else x1 = -0.9 - x1;
					double y1 = (double)(y - Okno2) / Okno2; //if (0.0 < y1) y1 = 0.9 - y1; else y1 = -0.9 - y1;

					double x2 = (x0 * x1 + y0 * y1);
					if (bEros)
					{
						x2 *= Math.Abs (x2); // x2 = (x2 < 0.0 ? -Math.Sqrt (-x2) : Math.Sqrt (x2)); // 
						x2 = Okno2 + x2 * Okno2 * kf * kf;
					}
					else
					{
						x2 = Okno2 + x2 * Okno2 * kf;
					}

					if ((0 <= x2) && (x2 < Okno))
					{
						double y2 = (x0 * y1 - y0 * x1);
						if (bEros)
						{
							y2 *= Math.Abs (y2); // y2 = (y2 < 0.0 ? -Math.Sqrt (-y2) : Math.Sqrt (y2)); // 
							y2 = Okno2 + y2 * Okno2 * kf * kf;
						}
						else
						{
							y2 = Okno2 + y2 * Okno2 * kf;
						}
						if ((0 <= y2) && (y2 < Okno))
						{
							double v = Math.Abs (Xbuf [(int)x2] + Ybuf [(int)y2]);
							//double v = Xbuf [x2] + Ybuf [y2];
							vsum2 += v * v;
							vcnt++;
							v = v / Power * (Bright / 16.0);

							if (Palitra < 12)
								bmp1.SetPixel (x, y, H2Color (Palitra / 12.0 - v / 16.0, Math.Abs (v)));
							else
								bmp1.SetPixel (x, y, H2Color (pct + v / 16.0, Math.Abs (v)));
							continue;
						}
					}
					bmp1.SetPixel (x, y, Color.Black); // Color.White - для прозрачности
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

		int btn_M_Visible_Cnt = 3;

		private void Form1_MouseMove (object sender, MouseEventArgs e)
		{
			if (!bPanel)
			{
				btn_M.Visible = true;
				btn_M.Enabled = true;
				btn_M_Visible_Cnt = 3;
			}
		}
		// Form1_MouseMove

		private void button1_Click (object sender, EventArgs e)
		{
			btn_M.Enabled = false;
			btn_M.Visible = false;
			Panel panel1 = new Panel ();
			panel1.Show (this);
		}
		// button1_Click

		public static Color H2Color (double h, double v) //цвет, яркость
		{
			if (v < 0.0) v = 0.0; else if (1.0 <= v) v = 255.0; else v *= 256.0;
			double h6 = (h - Math.Floor (h)) * 6.0;
			int a = (int)((h6 - Math.Floor (h6)) * v);
			int b = (int)v;
			int c = b - a;
			switch ((int)h6)
			{
				case 0: return Color.FromArgb (b, a, 0);
				case 1: return Color.FromArgb (c, b, 0);
				case 2: return Color.FromArgb (0, b, a);
				case 3: return Color.FromArgb (0, c, b);
				case 4: return Color.FromArgb (a, 0, b);
				default: return Color.FromArgb (b, 0, c);
			}
		}
		// H2Color
	}
}
