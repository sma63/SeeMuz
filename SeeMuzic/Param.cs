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
	class Param
	{
		public double Bright;
		public int Interval;
		public int Resample;
		public double Leak;
		public int iFilter;
		public int Palitra;
		public bool bRotate;
		public bool bStretch;
		public bool bInside;
		public bool bEros;
		public string Fname;
	}

	public partial class Form1 : Form
	{

		const string _BRIGHT_ = "BRI";
		const string _EROS_ = "ERO";
		const string _FILE_ = "NAM";
		const string _FILTER_ = "FIL";
		const string _INTERVAL_ = "INT";
		const string _INSIDE_ = "INS";
		const string _LEAK_ = "LEA";
		const string _PALITRA_ = "PAL";
		const string _RESAMPLE_ = "RES";
		const string _ROTATE_ = "ROT";
		const string _STRETCH_ = "STR";

		static Param [] parm1;
		static List<Param> ListParam = new List<Param> ();

		private void Save_Parms_Xml ()
		{
			XElement parms1 = new XElement ("PARMS");
			parms1.Add (new XElement (_BRIGHT_, Bright));
			parms1.Add (new XElement (_INTERVAL_, Interval));
			parms1.Add (new XElement (_RESAMPLE_, Resample));
			parms1.Add (new XElement (_LEAK_, Leak));
			parms1.Add (new XElement (_FILTER_, iFilter));
			parms1.Add (new XElement (_PALITRA_, Palitra));
			parms1.Add (new XElement (_ROTATE_, bRotate));
			parms1.Add (new XElement (_STRETCH_, bStretch));
			parms1.Add (new XElement (_INSIDE_, bInside));
			parms1.Add (new XElement (_EROS_, bEros));
			new XDocument (parms1).Save ("SeeMuz.xml");

			XElement list1 = new XElement ("LIST");
			for (int i = 0; i < Fnames.Length; i++)
			{
				XElement item1 = new XElement
				("L",
					new XAttribute (_BRIGHT_, parm1 [i].Bright),
					new XAttribute (_INTERVAL_, parm1 [i].Interval),
					new XAttribute (_RESAMPLE_, parm1 [i].Resample),
					new XAttribute (_LEAK_, parm1 [i].Leak),
					new XAttribute (_FILTER_, parm1 [i].iFilter),
					new XAttribute (_PALITRA_, parm1 [i].Palitra),
					new XAttribute (_ROTATE_, parm1 [i].bRotate),
					new XAttribute (_STRETCH_, parm1 [i].bStretch),
					new XAttribute (_INSIDE_, parm1 [i].bInside),
					new XAttribute (_EROS_, parm1 [i].bEros),
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
							case _INTERVAL_: Interval = int.Parse (parm.Value); break;
							case _RESAMPLE_: Resample = int.Parse (parm.Value); break;
							case _LEAK_: Leak = int.Parse (parm.Value); break;
							case _FILTER_: iFilter = int.Parse (parm.Value); break;
							case _PALITRA_: Palitra = int.Parse (parm.Value); break;
							case _ROTATE_: bRotate = bool.Parse (parm.Value); break;
							case _STRETCH_: bStretch = bool.Parse (parm.Value); break;
							case _INSIDE_: bInside = bool.Parse (parm.Value); break;
							case _EROS_: bEros = bool.Parse (parm.Value); break;
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
						Param p1 = new Param ();
						try { p1.Bright = double.Parse (parm.Attribute (_BRIGHT_).Value); } catch { }
						try { p1.Interval = int.Parse (parm.Attribute (_INTERVAL_).Value); } catch { }
						try { p1.Resample = int.Parse (parm.Attribute (_RESAMPLE_).Value); } catch { }
						try { p1.Leak = int.Parse (parm.Attribute (_LEAK_).Value); } catch { }
						try { p1.iFilter = int.Parse (parm.Attribute (_FILTER_).Value); } catch { }
						try { p1.Palitra = int.Parse (parm.Attribute (_PALITRA_).Value); } catch { }
						try { p1.bRotate = bool.Parse (parm.Attribute (_ROTATE_).Value); } catch { }
						try { p1.bStretch = bool.Parse (parm.Attribute (_STRETCH_).Value); } catch { }
						try { p1.bInside = bool.Parse (parm.Attribute (_INSIDE_).Value); } catch { }
						try { p1.bEros = bool.Parse (parm.Attribute (_EROS_).Value); } catch { }
						try { p1.Fname = parm.Attribute (_FILE_).Value; } catch { p1.Fname = string.Empty; }
						ListParam.Add (p1);
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