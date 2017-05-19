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
		public int Palitra;
		public int Resample;
	}

	public partial class Form1 : Form
	{

		const string _BRIGHT_ = "BRI";
		const string _EROS_ = "ERO";
		const string _FILE_ = "NAM";
		const string _FILTER_ = "FIL";
		const string _GAMMA_ = "GAM";
		const string _INSIDE_ = "INS";
		const string _INTERVAL_ = "INT";
		const string _LEAK_ = "LEA";
		const string _LENGTH_ = "LEN";
		const string _PALITRA_ = "PAL";
		const string _PAGE0_ = "PAGE0";
		const string _RESAMPLE_ = "RES";
		const string _ROTATE_ = "ROT";
		const string _STRETCH_ = "STR";
		const string _TRANSPARENCY_ = "TRA";
		const string _VOLUME_ = "VOL";

		public static Param [] parm1;
		static List<Param> ListParam = new List<Param> ();

		private void Save_Parms_Xml ()
		{
			XElement parms1 = new XElement ("PARMS");
			parms1.Add (new XElement (_BRIGHT_, Bright));
			parms1.Add (new XElement (_EROS_, bEros));
			parms1.Add (new XElement (_FILTER_, iFilter));
			parms1.Add (new XElement (_GAMMA_, Gamma));
			parms1.Add (new XElement (_INSIDE_, bInside));
			parms1.Add (new XElement (_INTERVAL_, Interval));
			parms1.Add (new XElement (_LEAK_, Leak));
			parms1.Add (new XElement (_PAGE0_, bLastPage0));
			parms1.Add (new XElement (_PALITRA_, Palitra));
			parms1.Add (new XElement (_RESAMPLE_, Resample));
			parms1.Add (new XElement (_ROTATE_, bRotate));
			parms1.Add (new XElement (_STRETCH_, bStretch));
			parms1.Add (new XElement (_TRANSPARENCY_, bTrnsparency));
			parms1.Add (new XElement (_VOLUME_, Volume));
			new XDocument (parms1).Save ("SeeMuz.xml");

			XElement list1 = new XElement ("LIST");
			for (int i = 0; i < Fnames.Length; i++)
			{
				Param prm1 = parm1 [i];
				XElement item1 = new XElement
				("L",
					new XAttribute (_BRIGHT_, prm1.Bright),
					new XAttribute (_FILTER_, prm1.iFilter),
					new XAttribute (_GAMMA_, prm1.Gamma),
					new XAttribute (_INTERVAL_, prm1.Interval),
					new XAttribute (_LEAK_, prm1.Leak),
					new XAttribute (_LENGTH_, prm1.Length),
					new XAttribute (_PALITRA_, prm1.Palitra),
					new XAttribute (_RESAMPLE_, prm1.Resample),
					new XAttribute (_FILE_, Fnames [i])
				);
				list1.Add (item1);
			}
			new XDocument (list1).Save ("SeeMuzList.xml");
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
							case _BRIGHT_: Bright = double.Parse (parm.Value); break;
							case _EROS_: bEros = bool.Parse (parm.Value); break;
							case _FILTER_: iFilter = int.Parse (parm.Value); break;
							case _GAMMA_: Gamma = double.Parse (parm.Value); break;
							case _INTERVAL_: Interval = int.Parse (parm.Value); break;
							case _INSIDE_: bInside = bool.Parse (parm.Value); break;
							case _LEAK_: Leak = int.Parse (parm.Value); break;
							case _PAGE0_: bLastPage0 = bool.Parse (parm.Value); break;
							case _PALITRA_: Palitra = int.Parse (parm.Value); break;
							case _RESAMPLE_: Resample = int.Parse (parm.Value); break;
							case _ROTATE_: bRotate = bool.Parse (parm.Value); break;
							case _STRETCH_: bStretch = bool.Parse (parm.Value); break;
							case _TRANSPARENCY_: bTrnsparency = bool.Parse (parm.Value); break;
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
				XDocument xdoc2 = XDocument.Load ("SeeMuzList.xml");
				IEnumerable<XElement> parms2 = from f in (from p in xdoc2.Elements () where p.Name.ToString ().ToUpper () == "LIST" select p).Elements () select f;
				foreach (XElement parm in parms2)
				{
					if (parm.Name.ToString ().ToUpper () == "L")
					{
						Param prm1 = new Param ();
						try { prm1.Bright = double.Parse (parm.Attribute (_BRIGHT_).Value); } catch { }
						try { prm1.iFilter = int.Parse (parm.Attribute (_FILTER_).Value); } catch { }
						try { prm1.Gamma = double.Parse (parm.Attribute (_GAMMA_).Value); } catch { }
						try { prm1.Interval = int.Parse (parm.Attribute (_INTERVAL_).Value); } catch { }
						try { prm1.Leak = int.Parse (parm.Attribute (_LEAK_).Value); } catch { }
						try { prm1.Length = int.Parse (parm.Attribute (_LENGTH_).Value); } catch { }
						try { prm1.Palitra = int.Parse (parm.Attribute (_PALITRA_).Value); } catch { }
						try { prm1.Resample = int.Parse (parm.Attribute (_RESAMPLE_).Value); } catch { }
						try { prm1.Fname = parm.Attribute (_FILE_).Value; } catch { prm1.Fname = string.Empty; }
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