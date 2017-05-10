using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace audio_sma
{
	class Cic
	{
		int Cnt, Shift;
		int RRR, NNN, NNN2, MMM;
		int [] XXX;
		int [] YYY;

		public int X, Y;

		public Cic (int rrr, int nnn) // rrr - кратность, nnn - стадий
		{
			RRR = rrr;
			NNN = nnn;
			NNN2 = NNN * 2;
			MMM = 1;
			XXX = new int [NNN2];
			YYY = new int [NNN2];
			double Gain = Math.Pow ((double)(RRR * MMM), (double)NNN);
			double Bout = (double)NNN * Math.Log ((double)(RRR * MMM)) / Math.Log (2.0); //+ Bin
			Shift = (int)(Bout + 0.49999);
			double Gnorm = Gain / Math.Pow (2.0, Math.Floor (Bout + 0.49999));
			double Scale = 1.0 / Gnorm;
			Reset ();
		}

		public void Reset ()
		{
			Cnt = 0;
			for (int i = 0; i < NNN2; i++)
			{
				XXX [i] = YYY [i] = 0;
			}
		}

		public bool Decimate (int x, int y)
		{
			int i;
			for (i = 0; i < NNN; i++)
			{
				x = (XXX [i] += x);
				y = (YYY [i] += y);
			}
			if ((Cnt = (Cnt + 1) % RRR) == 0)
			{
				int a, b;
				for (; i < NNN2; i++)
				{
					a = x - XXX [i]; XXX [i] = x; x = a;
					b = y - YYY [i]; YYY [i] = y; y = b;
				}
				X = x >> Shift;
				Y = y >> Shift;
				return true;
			}
			return false;
		}
	}

}

