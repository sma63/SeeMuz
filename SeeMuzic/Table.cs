using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeeMuzic
{
	public partial class Table : Form
	{
		public Table ()
		{
			InitializeComponent ();

			for (int i = 0; i < Form1.Fnames.Length; i++)
			{
				int p1 = Form1.Fnames [i].LastIndexOf ('\\');
				dataGridView1.Rows.Add (Form1.Fnames [i].Substring (p1 + 1), Form1.Fnames [i]);
			}
		}

		private void Table_FormClosed (object sender, FormClosedEventArgs e)
		{
			Form1.bKnopka = true;
		}
	}
}
