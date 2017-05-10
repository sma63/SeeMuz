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
	}

	public partial class Form1 : Form
	{
		static Param [] parm1;

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
			parms1.Add (new XElement ("EROS", bEros));
			new XDocument (parms1).Save ("SeeMuz.xml");

			XElement list1 = new XElement ("LIST");
			for (int i = 0; i < Fnames.Length; i++)
			{
				XElement item1 = new XElement
				("ITEM",
					new XAttribute ("BRIGHT", parm1 [i].Bright),
					new XAttribute ("INTERVAL", parm1 [i].Interval),
					new XAttribute ("RESAMPLE", parm1 [i].Resample),
					new XAttribute ("LEAK", parm1 [i].Leak),
					new XAttribute ("FILTER", parm1 [i].iFilter),
					new XAttribute ("ROTATE", parm1 [i].bRotate),
					new XAttribute ("STRETCH", parm1 [i].bStretch),
					new XAttribute ("INSIDE", parm1 [i].bInside),
					new XAttribute ("EROS", parm1 [i].bEros),
					new XAttribute ("FILE", Fnames [i])
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
							case "BRIGHT": Bright = double.Parse (parm.Value); break;
							case "INTERVAL": Interval = int.Parse (parm.Value); break;
							case "RESAMPLE": Resample = int.Parse (parm.Value); break;
							case "LEAK": Leak = int.Parse (parm.Value); break;
							case "FILTER": iFilter = int.Parse (parm.Value); break;
							case "ROTATE": bRotate = bool.Parse (parm.Value); break;
							case "STRETCH": bStretch = bool.Parse (parm.Value); break;
							case "INSIDE": bInside = bool.Parse (parm.Value); break;
							case "EROS": bEros = bool.Parse (parm.Value); break;
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

	}
}