﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Numerics;

namespace audio_sma
{
	class Fir
	{
		int n, idata;
		double [] coef;
		double [] data;

		public Fir (int n_, double [] coef_)
		{
			n = n_;
			idata = 0;
			coef = coef_;
			data = new double [n];
			for (int i = 0; i < n; i++)
			{
				data [i] = 0.0;
			}
		}

		public double Go (double v)
		{
			data [idata] = v;
			idata = (idata + 1) % n;
			v = 0.0;
			for (int i = 0, j = idata; i < n; i++, j = (j + 1) % n)
			{
				v += coef [i] * data [j];
			}
			return v;
		}

 
		public double Halfband (double v)
		{
			data [idata] = v;
			idata = (idata + 1) % n;
			int j = (idata + HALFBAND / 2) % n;
			v = data [j] * coef [0];
			for (int i = 1; i < HALFBAND / 2; i += 2)
			{
				v += coef [i] * (data [(HALFBAND + j - i) % n] + data [(j + i) % n]);
			}
			return v;
		}

		public void Load (double v)
		{
			data [idata] = v;
			idata = (idata + 1) % n;
		}

		public double Go ()
		{
			double v = 0.0;
			for (int i = 0, j = idata; i < n; i++, j = (j + 1) % n)
			{
				v += coef [i] * data [j];
			}
			return v;
		}

		const int HALFBAND = 32;
		public static double [] hb_coef32 = new double []
		{
			0.5,
			0.3154964179881562, 0,
			-0.097877745820535586, 0,
			0.050647069490689985, 0,
			-0.028636137215663268, 0,
			0.015924635174316786, 0,
			-0.0082308481477312741, 0,
			0.0038570338166836345, 0,
			-0.0018852172726891872,
		};

		public static double [] coef2 = new double [] //33
		{
 0,
-0.0018852172726891872,
 0,
 0.0038570338166836345,
 0,
-0.0082308481477312741,
 0,
 0.015924635174316786,
 0,
-0.028636137215663268,
 0,
 0.050647069490689985,
 0,
-0.097877745820535586,
 0,
 0.3154964179881562,
 0.5,
 0.3154964179881562,
 0,
-0.097877745820535586,
 0,
 0.050647069490689985,
 0,
-0.028636137215663268,
 0,
 0.015924635174316786,
 0,
-0.0082308481477312741,
 0,
 0.0038570338166836345,
 0,
-0.0018852172726891872,
 0
			};
		public static double [] coef3 = new double [] //33
		{
-0.0013786526014400433,
 0.0000000000000000011546393325250097,
 0.0022652328736747353,
 0.0033410898850579889,
-0.0000000000000000027908616686126,
-0.0071298320934812028,
-0.010035643007617619,
 0.0000000000000000058520183518631143,
 0.018611810119440617,
 0.024805566387449907,
-0.0000000000000000093063135370148265,
-0.043872161776551309,
-0.05964527611659199,
 0.000000000000000011989439810517597,
 0.13303785083980171,
 0.27329340135747043,
 0.33341322826557379,
 0.27329340135747043,
 0.13303785083980171,
 0.000000000000000011989439810517597,
-0.05964527611659199,
-0.043872161776551309,
-0.0000000000000000093063135370148265,
 0.024805566387449907,
 0.018611810119440617,
 0.0000000000000000058520183518631143,
-0.010035643007617619,
-0.0071298320934812028,
-0.0000000000000000027908616686126,
 0.0033410898850579889,
 0.0022652328736747353,
 0.0000000000000000011546393325250097,
-0.0013786526014400433
		};

		public static double [] coef4 = new double [] //33
		{
-0.00000000000000000078147284000169877,
-0.0013361934128000967,
-0.0026212054161720995,
-0.0027337661570691397,
 0.0000000000000000020975793892611778,
 0.0058338130230836411,
 0.011612705303743637,
 0.01128697096585265,
-0.0000000000000000052749416700114659,
-0.020296555983187914,
-0.038076381151828174,
-0.035897337464213849,
 0.0000000000000000084523039507617541,
 0.06937322351103016,
 0.15394423206099803,
 0.22361572938298782,
 0.25058953067515094,
 0.22361572938298782,
 0.15394423206099803,
 0.06937322351103016,
 0.0000000000000000084523039507617541,
-0.035897337464213849,
-0.038076381151828174,
-0.020296555983187914,
-0.0000000000000000052749416700114659,
 0.01128697096585265,
 0.011612705303743637,
 0.0058338130230836411,
 0.0000000000000000020975793892611778,
-0.0027337661570691397,
-0.0026212054161720995,
-0.0013361934128000967,
-0.00000000000000000078147284000169877,
		};

	}
}
