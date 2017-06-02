//#define SPIRAL
#define KORELAT

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
//using System.Runtime.InteropServices;

using Un4seen.Bass;
using audio_sma;

namespace SeeMuzic
{
	public partial class Form1 : Form
	{
		public const int SAMPLERATE = 44100; //11025 и 22050 - под сомнением
		public const int MIN_RESAMPLE = 10;
		const int MAX_RESAMPLE = 42;
		const int MAX_INTERVAL = 100; // [ms] 
		const int SAMPLE_BYTES = sizeof (Int32); // число байт в сампле
		const int AUDIO_SAMPLES = (MAX_INTERVAL * SAMPLERATE + 999) / 1000; // Длина аудиобуффера в самплах
		const int AUDIO_BYTES = AUDIO_SAMPLES * SAMPLE_BYTES; // .. в байтах
		const int DDD = 200; // таблица искажений

		private int _syncer = 0;
		static SYNCPROC _syncProcEndStream;
		public static int Audio_Stream = 0;

		public static double Bright = 30.0;
		public static int Interval = 40; // 1000 / 40 = 25 кадров в сек.
		public static int Resample = (MIN_RESAMPLE + MAX_RESAMPLE) / 2; // (44100 / 14 = 3150) / 25 = 126
		public static int Volume = 5; // 0 .. 10
		public static double Leak = 1.0;
		public static int iFilter = 1, iFilter2 = 1;
		public static double Palitra = 0.0;
		public static double Gamma = 2.0; // ширина цветовой гаммы

		public static bool bRotate = true; // крутить
		public static bool bStretch = false; // растянуть
		public static bool bInside = true; // вписать
		public static bool bDistortion = false; // гнуть
		public static bool bTrnsparency = false; // прозрачность
		public static bool bFlex = false; // дрейф палитры

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

		// Resample = 2 ^ (i / 5.0); i = log2 (Resample) * 5.0;
		static audio_sma.Cic [] Mcic = new audio_sma.Cic []
		{
			new Cic (1, 1), //2^0=1
			new Cic (1, 1), //2^0.2=1.14
			new Cic (1, 1), //2^0.4=1.32
			new Cic (2, 1), //2^0.6=1.52
			new Cic (2, 1), //2^0.8=1.74

			new Cic (2, 1), //2^1=2
			new Cic (2, 1), //2^1.2=2.30
			new Cic (3, 2), //2^1.4=2.64
			new Cic (3, 2), //2^1.6=3.03
			new Cic (3, 2), //2^1.8=3.48

			new Cic (4, 3), //2^2=4
			new Cic (5, 3), //2^2.2=4.59
			new Cic (5, 3), //2^2.4=5.28
			new Cic (6, 3), //2^2.6=6.06
			new Cic (7, 3), //2^2.8=6.96

			new Cic (8, 3), //2^3=8
			new Cic (9, 3), //2^3.2=9.19
			new Cic (10, 3), //2^3.4=10.56
			new Cic (12, 3), //2^3.6=12.13 
			new Cic (14, 3), //2^3.8=13.99

			new Cic (16, 3), //2^4=16
			new Cic (18, 3), //2^4.2=18.38
			new Cic (21, 3), //2^4.4=21.11
			new Cic (24, 3), //2^4.6=24.25
			new Cic (28, 3), //2^4.8=27.86

			new Cic (32, 3),  //2^5=32
			new Cic (37, 3),  //2^5.2=36.77
			new Cic (42, 3),  //2^5.4=42.22
		};
		static audio_sma.Cic cic = Mcic [ResToIdx (Resample)];

		static double alpha = 0.0; // угол
		static double x0 = 1.0, y0 = 0.0;
		static double kf = 1.0;

		static long fpos = 0, flen = long.MaxValue;
		public static int iFnames = 0;

		const int PENW = 4;
		static Pen pen2 = new Pen (Color.Yellow, PENW);

		public static Random rnd1 = new Random ();

		static Font fnt1 = new Font ("Arial", 10.0f);

		public static double pct = 0.0;

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
		public static bool bPanel = false;

		public static bool bLastPage0 = true; // последняя открытая страница в диалоге параметров

		static Panel Panel1;
		int btn_M_Visible_Cnt = 5; // видимость кнопки параметов [сек]

		static Form1 himself = null;

		static double [] DistortionTab = new double [200];

		public Form1 ()
		{
			himself = this;

			InitializeComponent ();

			for (int i = 0; i < 200; i++)
			{
				DistortionTab [i] = 1.0;
			}

			pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

			iFnames = 0;

			Load_Parms_Xml ();

			btn_M.Enabled = false;
			btn_M.Visible = false;
		}
		// Form1

		static bool bTransparencyOn = false;

		private void Form1_Load (object sender, EventArgs e)
		{
			// Прозрачность
			TransparencyCtrl (false);

			_syncProcEndStream = new SYNCPROC (SyncMethodEndStream);

			btn_M_Click (null, null);

			for (int i = 0; i < Xrot.Length; i++)
			{
				Xrot [i] = 1.0;
				Yrot [i] = 0.0;
			}
		}
		// Form1_Load

		//BinaryWriter bw = new BinaryWriter (File.Open ("test.pcm", FileMode.Create));

		private void Form1_FormClosed (object sender, FormClosedEventArgs e)
		{
			Bass.BASS_StreamFree (Audio_Stream);
			Bass.BASS_Free ();
			Parm_To_Tab (ListParam [iFnames]);
			Save_Parms_Xml ();
			//bw.Close ();
		}
		// Form1_FormClosed

		public void TransparencyCtrl (bool b)
		{
			if (bTransparencyOn != b)
			{
				bTransparencyOn = b;
				if (bTransparencyOn)
				{
					this.FormBorderStyle = FormBorderStyle.None;
					this.AllowTransparency = bTrnsparency;
					//this.BackColor = Color.Black; // AliceBlue;//цвет фона  
					this.TransparencyKey = this.BackColor; //он же будет заменен на прозрачный цвет
				}
				else
				{
					this.FormBorderStyle = FormBorderStyle.Sizable;
					this.AllowTransparency = false;
					//this.BackColor = Color.Black; // AliceBlue;//цвет фона  
					//this.TransparencyKey = this.BackColor; //он же будет заменен на прозрачный цвет
				}
			}
		}
		// TransparencyCtrl

		private void Form1_Next_Title (string s1)
		{
			int p1 = 0, p2 = s1.IndexOf ('\\');
			while (0 <= p2) p2 = s1.IndexOf ('\\', p1 = p2 + 1); // удаление полного пути
			this.Text = s1.Substring (p1);
		}
		// Form1_Next_Title

		private void SyncMethodEndStream (int handle, int channel, int data, IntPtr user)
		{
			Audio_Next (-1);
		}
		// SyncMethodEndStream

		private static void Parm_To_Tab (Param tab1)
		{
			tab1.Bright = Bright;
			tab1.iFilter = iFilter;
			tab1.Gamma = Gamma;
			tab1.Interval = Interval;
			tab1.Leak = Leak;
			tab1.Palitra = Palitra;
			tab1.Resample = Resample;
		}
		// Parm_To_Tab

		private static void Tab_To_Parm (Param tab1)
		{
			Bright = tab1.Bright;
			iFilter = tab1.iFilter;
			Gamma = tab1.Gamma;
			Interval = tab1.Interval;
			Leak = tab1.Leak;
			Palitra = tab1.Palitra;
			Resample = tab1.Resample;
		}
		// Tab_To_Parm

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
				Audio_Stop ();
				Audio_Start ();
			}

			pct = (double)(fpos = Bass.BASS_ChannelGetPosition (Audio_Stream)) / flen;

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
				kf = (bInside ? (Math.Abs (x0) + Math.Abs (y0)) : 1.0 / (Math.Abs (x0) + Math.Abs (y0)));
			}
			else
			{
				alpha = 0.0;
				x0 = 1.0;
				y0 = 0.0;
				kf = 1.0;
			}
#endif
			if (iFilter != iFilter2)
			{
				iFilter2 = iFilter;
				Xfir = Mfir [iFilter, 0];
				Yfir = Mfir [iFilter, 1];
			}

			if (!bPanel && (this.WindowState == FormWindowState.Normal))
			{
				if (0 < btn_M_Visible_Cnt)
				{
					if (--btn_M_Visible_Cnt <= 0)
					{
						btn_M.Visible = false;
						btn_M.Enabled = false;
						TransparencyCtrl (true);
					}
				}
			}

			if (bFlex)
			{
				Palitra = DateTime.Now.Ticks / 10000000 % 100 / 100.0; // дрейф палитры
			}

			if (bDistortion)
			{
				double e1 = Math.Abs ((DateTime.Now.Ticks / 10000000 & 127) / 64.0 - 1.0); // дрейф искажения
				for (int i = 0; i < DDD; i++)
				{
					DistortionTab [i] = (e1 - 0.5) * ((double)i / DDD - 0.5) + 0.75;
				}
			}

			timer1.Interval = Interval;

			if (this.AllowTransparency != bTrnsparency)
			{
				TransparencyCtrl (bTrnsparency);
			}
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
			this.FormBorderStyle = FormBorderStyle.Sizable;
			this.AllowTransparency = false;

			if (this.WindowState == FormWindowState.Maximized)
			{
				this.WindowState = FormWindowState.Normal;
				this.FormBorderStyle = FormBorderStyle.Sizable; // возвращаю заголовок в полноэкранном режиме
			}
		}
		// Form1_MouseDown

		static double [] kor0 = new double [AUDIO_SAMPLES / MIN_RESAMPLE];
		static double [] kor1 = new double [AUDIO_SAMPLES / MIN_RESAMPLE];

		static Image img0 = null;
		static float Xnorm = 0.0f, Ynorm = 0.0f;

		private void Form1_Paint (object sender, PaintEventArgs e)
		{
			int Okno = 0;
			cic = Mcic [ResToIdx (Resample)];
			audio_bytes = (int)Bass.BASS_ChannelSeconds2Bytes (Audio_Stream, Interval / 1000.0); // текущая длина аудиобуффера в байтах
			int samples = Bass.BASS_ChannelGetData (Audio_Stream, audiobuf, audio_bytes) / SAMPLE_BYTES; // число самплов в аудиобуффере
			for (int i = 0, j = 0; i < samples; i++)
			{
				// нормализатор нуля
				float x = (float)audiobuf [j++];
				float y = (float)audiobuf [j++];
				x -= (Xnorm += (x - Xnorm) * 0.0001f);
				y -= (Ynorm += (y - Ynorm) * 0.0001f);

				if (cic.Decimate ((int)x, (int)y))
				{
					if (iFilter2 < 2)
					{
						Xbuf [Okno] = cic.X;
						Ybuf [Okno] = cic.Y;
					}
					else
					{
						Xbuf [Okno] = (int)Xfir.Sim ((double)cic.X);
						Ybuf [Okno] = (int)Yfir.Sim ((double)cic.Y);
					}
					Okno++;
				}
			}
			if (Okno == 0) return;

			int Okno2 = Okno / 2; // центр окна

			{
				//int cnt = 0;
				//byte [] OutBytes = new byte [Okno * 2 * sizeof (short)];
				//for (int i = 0; i < Okno; i++)
				//{
				//	Array.Copy (BitConverter.GetBytes ((short)Xbuf [i]), 0, OutBytes, cnt, sizeof (short)); cnt += sizeof (short);
				//	Array.Copy (BitConverter.GetBytes ((short)Ybuf [i]), 0, OutBytes, cnt, sizeof (short)); cnt += sizeof (short);
				//}
				//bw.Write (OutBytes, 0, cnt);
			}


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

			double kf1 = Palitra; // pct;
			double kf2 = Gamma * 0.1;
			double kf3 = Bright * 0.2;

			for (int x = 0; x < Okno; x++)
			{
				double x1 = (double)(x - Okno2) / Okno2;
				for (int y = 0; y < Okno; y++)
				{
					double y1 = (double)(y - Okno2) / Okno2;

					// поворот
					double x2 = (x0 * x1 + y0 * y1);
					double y2 = (x0 * y1 - y0 * x1);

					if (bDistortion)
					{
						double r = (x2 * x2 + y2 * y2);
						if (2.0 <= r) continue;
						double r2 = DistortionTab [(int)(r * DDD / 2.0)] * 1.35;
						x2 *= r2;
						y2 *= r2;
					}

					x2 = Okno2 + Okno2 * x2 * kf;
					if ((0.0 <= x2) && (x2 < Okno))
					{
						y2 = Okno2 + Okno2 * y2 * kf;
						if ((0.0 <= y2) && (y2 < Okno))
						{
							double v = Math.Abs (Xbuf [(int)x2] + Ybuf [(int)y2]);
							vsum2 += v * v; vcnt++;
							if (0.0 < Power) v /= Power;
							bmp1.SetPixel (x, y, TriColor (kf1 + v * kf2, v * kf3));
							continue;
						}
					}
					//Skip: bmp1.SetPixel (x, y, Color.Black);
				}
			}

			double pwr1 = 0.0;
			if (0 < vcnt)
			{
				pwr1 = Math.Sqrt (vsum2 / vcnt);
				Power += (pwr1 - Power) / Leak;
				//bw.Write (BitConverter.GetBytes ((short)1000.0 * Power3), 0, sizeof (short));
			}
			//if (Power < pwr1)
			{
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
				img0 = img1;
			}
			//else if (img0 != null)
			//{
			//	if (bStretch)
			//	{
			//		g.DrawImage (img0, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
			//	}
			//	else
			//	{
			//		int side = Math.Min (this.ClientSize.Width, this.ClientSize.Height);
			//		g.DrawImage (img0, (this.ClientSize.Width - side) / 2, (this.ClientSize.Height - side) / 2, side, side);
			//	}
			//	g.DrawLine (pen2, (int)(this.ClientSize.Width * fpos / flen), this.ClientSize.Height - PENW, 0, this.ClientSize.Height - PENW);
			//}
			//g.DrawString (String.Format ("{0}", palitra0), fnt1, Brushes.Yellow, 0.0f, 0.0f);
			//g.DrawString (String.Format ("{0}", Power), fnt1, Brushes.Yellow, 0.0f, 0.0f);

			// кривая искажений
			//if (0 < DistortionTab.Length)
			//{
			//	int x0 = 0;
			//	int y0 = (int)(DistortionTab [0] * this.ClientSize.Height * 0.99);
			//	for (int i = 1; i < DistortionTab.Length; i++)
			//	{
			//		int x1 = this.ClientSize.Width * i / DistortionTab.Length;
			//		int y1 = (int)(DistortionTab [i] * this.ClientSize.Height * 0.99);
			//		g.DrawLine (Pens.Yellow, x0, y0, x1, y1);
			//		x0 = x1;
			//		y0 = y1;
			//	}
			//}
		}
		// Form1_Paint

		private void Form1_MouseMove (object sender, MouseEventArgs e)
		{
			if (!bPanel)
			{
				btn_M.Visible = true;
				btn_M.Enabled = true;
				btn_M_Visible_Cnt = 5;
				TransparencyCtrl (false);
			}
		}
		// Form1_MouseMove

		private void btn_M_Click (object sender, EventArgs e)
		{
			btn_M.Enabled = false;
			btn_M.Visible = false;
			TransparencyCtrl (true);
			Panel1 = new Panel ();
			Panel1.Show (this);
			bPanel = true;
		}
		// btn_M_Click

		public static bool btn_Panel_Play_Click ()
		{
			if (Audio_Stream == 0)
			{
				himself.Audio_Start ();
				return true;
			}
			else if (Bass.BASS_ChannelIsActive (Audio_Stream) == BASSActive.BASS_ACTIVE_PAUSED)
			{
				Bass.BASS_ChannelPlay (Audio_Stream, false);
				//timer1.Enabled = true;
				return true;
			}
			else
			{
				Bass.BASS_ChannelPause (Audio_Stream);
				//timer1.Enabled = false;
				return false;
			}
		}
		// btn_Panel_Play_Click

		// i = log2 (Resample) * 5.0;
		public static int ResToIdx (int r)
		{
			r = (r < MIN_RESAMPLE ? MIN_RESAMPLE : (MAX_RESAMPLE < r ? MAX_RESAMPLE : r));
			int i = (int)(Math.Log (r) / Math.Log (2.0) * 5.0 + 0.5);
			return (i < 0 ? 0 : i);
		}
		// Resample = 2 ^ (i / 5.0);
		public static int IdxToRes (int i)
		{
			int r = (int)(Math.Pow (2.0, i / 5.0) + 0.5);
			return (r < MIN_RESAMPLE ? MIN_RESAMPLE : (MAX_RESAMPLE < r ? MAX_RESAMPLE : r));
		}
	}

	//[StructLayout (LayoutKind.Explicit)]
	//public unsafe struct GetData
	//{
	//	public const int GET_DATA_LENGTH = 1024;
	//	[FieldOffset (0)]
	//	public fixed short w [GET_DATA_LENGTH];
	//	[FieldOffset (0)]
	//	public fixed byte b [GET_DATA_LENGTH * 2];
	//}
}
