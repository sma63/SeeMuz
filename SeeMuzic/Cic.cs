using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace audio_sma
{
	class Cic
	{
		int Cnt, Shift;
		public int X, Y;
		int RRR, NNN, NNN2, MMM;
		int [] XXX;
		int [] YYY;

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

/*

	function Comb1 (S : access Long_Float; X : Long_Float) return Long_Float is
		E : Long_Float := X - S.all;
	begin
		S.all := X;
		return E;
	end Comb1;

	procedure Decimate (X : Float) is
		E : Long_Float := Long_Float (X);
	begin
		for I in 1 .. NNN loop
			E := Inter (A (I)'Access, E);
		end loop;
		Cnt := (Cnt + 1) mod RRR;
		if Cnt = 0 then
			for I in 1 .. NNN loop
				E := Comb1 (B (I)'Access, E);
			end loop;
			Res (Float (E / Long_Float (Gain)));
		end if;
	end Decimate;
 
const int RRR = 16; 
const int NNN = 4;
const int NNN2 = NNN * 2;
const int MMM = 1;

struct CICFLT
{
	int Cnt;
	int Shift;
	int XXX [NNN2];
	int YYY [NNN2];
};

double Bin = 16.0;
double Gain;
double Bout;
double Gnorm;
double Scale;

CFile Fout;

void Calc_Parm (CICFLT *cicflt)
{
	Gain = pow (double (RRR * MMM), double (NNN));
	Bout = //Bin +
		double (NNN) * log (double (RRR * MMM)) / log (2.0);
	Gnorm = Gain / pow (2.0, floor (Bout + 0.49999));
	Scale = 1.0 / Gnorm;
	cicflt->Shift = int (Bout + 0.49999);
//
//	if 32.0 < Bin + Bout then
//		raise Exp with "32.0 < Bout for Long_Float !!!";
//	end if;
//
	_tprintf (_T("%f : Gain\n"), Gain);
	_tprintf (_T("%f : Bout\n"), Bout);
	_tprintf (_T("%f : Gnorm\n"), Gnorm);
	_tprintf (_T("%f : Scale\n"), Scale);
}

void Reset (CICFLT *cicflt)
{
	cicflt->Cnt = 0;
	for (int i = 0; i < NNN2; i++)
		cicflt->XXX [i] = cicflt->YYY [i] = 0;
}

void Decimate (CICFLT *cicflt, int X, int Y)
{
	int i;
	for (i = 0; i < NNN; i++)
	{
		X = (cicflt->XXX [i] += X);
		Y = (cicflt->YYY [i] += Y);
	}

	if (RRR <= ++cicflt->Cnt)
	{
		int e;
		cicflt->Cnt = 0;
		for (; i < NNN2; i++)
		{
			e = X - cicflt->XXX [i]; cicflt->XXX [i] = X; X = e;
			e = Y - cicflt->YYY [i]; cicflt->YYY [i] = Y; Y = e;
		}
		X >>= cicflt->Shift;
		Y >>= cicflt->Shift;
		//_tprintf (_T("%d\t%d\n"), X, Y);
		Fout.Write (&X, sizeof (INT16));
		Fout.Write (&Y, sizeof (INT16));
	}
}
*/