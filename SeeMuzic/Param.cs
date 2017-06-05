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

namespace SeeMuzic
{
	public class Param
	{
		public double Bright;
		public int iFilter;
		public string Fname;
		public double Gamma;
		public int Interval;
		public double Leak;
		public int Length;
		public double Palitra;
		public int Resample;
	}

	public partial class Form1 : Form
	{
		const string SeeMuzXml = "SeeMuz.xml";
		const string SeeMuzListXml = "SeeMuz.List.xml";
		const string _BRIGHT_ = "BRI";
		const string _DISTORTION_ = "DST";
		const string _FILE_ = "NAM";
		const string _FILTER_ = "FLT";
		const string _FLEX_ = "FLX";
		const string _GAMMA_ = "GAM";
		const string _INSIDE_ = "INS";
		const string _INTERVAL_ = "INT";
		const string _LEAK_ = "LEA";
		const string _LENGTH_ = "LEN";
		const string _PALITRA_ = "PAL";
		const string _RESAMPLE_ = "RES";
		const string _ROTATE_ = "ROT";
		const string _SPIRAL_ = "SPI";
		const string _STRETCH_ = "STR";
		const string _TOPMOST_ = "TOP";
		const string _VOLUME_ = "VOL";

		public static List<Param> ListParam = new List<Param> ();

		private void Save_Parms_Xml ()
		{
			XElement parms1 = new XElement ("PARMS");
			parms1.Add (new XElement (_BRIGHT_, Bright));
			parms1.Add (new XElement (_DISTORTION_, bDistortion));
			parms1.Add (new XElement (_FILTER_, iFilter));
			parms1.Add (new XElement (_FLEX_, bFlex));
			parms1.Add (new XElement (_GAMMA_, Gamma));
			parms1.Add (new XElement (_INSIDE_, bInside));
			parms1.Add (new XElement (_INTERVAL_, Interval));
			parms1.Add (new XElement (_LEAK_, Leak));
			parms1.Add (new XElement (_PALITRA_, Palitra));
			parms1.Add (new XElement (_RESAMPLE_, Resample));
			parms1.Add (new XElement (_ROTATE_, bRotate));
			parms1.Add (new XElement (_SPIRAL_, bSpiral));
			parms1.Add (new XElement (_STRETCH_, bStretch));
			parms1.Add (new XElement (_TOPMOST_, bTopmost));
			parms1.Add (new XElement (_VOLUME_, Volume));
			new XDocument (parms1).Save (SeeMuzXml);

			XElement list1 = new XElement ("LIST");
			foreach (Param prm1 in ListParam)
			{
				if (prm1.Resample <= 0)
				{
					list1.Add (new XElement ("L", new XAttribute (_FILE_, prm1.Fname)));
				}
				else
				{
					list1.Add (new XElement
					("L",
						new XAttribute (_BRIGHT_, prm1.Bright),
						new XAttribute (_FILTER_, prm1.iFilter),
						new XAttribute (_GAMMA_, prm1.Gamma),
						new XAttribute (_INTERVAL_, prm1.Interval),
						new XAttribute (_LEAK_, prm1.Leak),
						new XAttribute (_LENGTH_, prm1.Length),
						new XAttribute (_PALITRA_, prm1.Palitra),
						new XAttribute (_RESAMPLE_, prm1.Resample),
						new XAttribute (_FILE_, prm1.Fname)
					));
				}
			}
			new XDocument (list1).Save (SeeMuzListXml);
		}
		// Save_Parms_Xml

		private void Load_Parms_Xml ()
		{
			try
			{
				XDocument xdoc = XDocument.Load (SeeMuzXml);
				IEnumerable<XElement> parms = from f in (from p in xdoc.Elements () where p.Name.ToString ().ToUpper () == "PARMS" select p).Elements () select f;
				foreach (XElement parm in parms)
				{
					try
					{
						switch (parm.Name.ToString ().ToUpper ())
						{
							case _BRIGHT_: Bright = double.Parse (parm.Value); break;
							case _DISTORTION_: bDistortion = bool.Parse (parm.Value); break;
							case _FILTER_: iFilter = int.Parse (parm.Value); break;
							case _FLEX_: bFlex = bool.Parse (parm.Value); break;
							case _GAMMA_: Gamma = double.Parse (parm.Value); break;
							case _INTERVAL_: Interval = int.Parse (parm.Value); break;
							case _INSIDE_: bInside = bool.Parse (parm.Value); break;
							case _LEAK_: Leak = int.Parse (parm.Value); break;
							case _PALITRA_: Palitra = double.Parse (parm.Value); break;
							case _RESAMPLE_: Resample = int.Parse (parm.Value); break;
							case _ROTATE_: bRotate = bool.Parse (parm.Value); break;
							case _SPIRAL_: bSpiral = bool.Parse (parm.Value); break;
							case _STRETCH_: bStretch = bool.Parse (parm.Value); break;
							case _TOPMOST_: bTopmost = bool.Parse (parm.Value); break;
							case _VOLUME_: Volume = int.Parse (parm.Value); break;
						}
					}
					catch
					{
						// если что-то с xdoc ...
					}
				}
			}
			catch
			{
			}

			ListParam.Clear ();
			try
			{
				XDocument xdoc2 = XDocument.Load (SeeMuzListXml);
				IEnumerable<XElement> parms2 = from f in (from p in xdoc2.Elements () where p.Name.ToString ().ToUpper () == "LIST" select p).Elements () select f;
				foreach (XElement parm in parms2)
				{
					if (parm.Name.ToString ().ToUpper () == "L")
					{
						Param prm1 = new Param ();

						prm1.Bright = 0.0;
						prm1.iFilter = 0;
						prm1.Gamma = 0.0;
						prm1.Interval = 0;
						prm1.Leak = 0.0;
						prm1.Length = 0;
						prm1.Palitra = 0.0;
						prm1.Resample = 0;

						try { prm1.Bright = double.Parse (parm.Attribute (_BRIGHT_).Value); } catch { }
						try { prm1.iFilter = int.Parse (parm.Attribute (_FILTER_).Value); } catch { }
						try { prm1.Gamma = double.Parse (parm.Attribute (_GAMMA_).Value); } catch { }
						try { prm1.Interval = int.Parse (parm.Attribute (_INTERVAL_).Value); } catch { }
						try { prm1.Leak = int.Parse (parm.Attribute (_LEAK_).Value); } catch { }
						try { prm1.Length = int.Parse (parm.Attribute (_LENGTH_).Value); } catch { }
						try { prm1.Palitra = double.Parse (parm.Attribute (_PALITRA_).Value); } catch { }
						try { prm1.Resample = int.Parse (parm.Attribute (_RESAMPLE_).Value); } catch { }
						try { prm1.Fname = parm.Attribute (_FILE_).Value; } catch { continue; }

						ListParam.Add (prm1);
					}
				}
			}
			catch
			{
				// если что-то с xdoc2 ...
			}
		}
		// Load_Parms_Xml

	}
}