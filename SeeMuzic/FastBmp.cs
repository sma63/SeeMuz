using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Threading;

namespace FastBmp
{

	unsafe class FastBitmap
	{
		Bitmap _bmp;
		BitmapData _bd;
		bool _locked;
		byte* pStart;
		byte* pNextPixel;


		public FastBitmap (Bitmap bmp, bool @lock)
		{
			_bmp = bmp;
			if (@lock) Lock ();
		}

		public FastBitmap (Bitmap bmp) : this (bmp, true)
		{
			ResetFirstPixel ();
		}

		public void Lock ()
		{
			if (!_locked)
			{
				_bd = _bmp.LockBits (new Rectangle (0, 0, _bmp.Width, _bmp.Height), ImageLockMode.ReadWrite, _bmp.PixelFormat);
				pStart = (byte*)_bd.Scan0;
				_locked = true;
			}
		}

		public void Unlock ()
		{
			if (!_locked) return;
			_bmp.UnlockBits (_bd);
			_locked = false;
		}

		public Bitmap Bitmap
		{
			get
			{
				return (_locked ? null : _bmp);
			}
			set
			{
				if (_locked) throw new Exception ("Image locked!");
				if (value == null) throw new NullReferenceException ();
				_bmp = value;
			}
		}

		public int Width
		{
			get
			{
				return _bmp.Width;
			}
		}

		public int Height
		{
			get
			{
				return _bmp.Height;
			}
		}

		public void SetPixel (int x, int y, Color clr)
		{
			if (!_locked) throw new Exception ();
			switch (_bd.PixelFormat)
			{
				// формат 24 бита на пиксель; 
				case PixelFormat.Format24bppRgb:  //8 бит, используются для красного, зеленого и синего компонентов.
					SetPixel24 (x, y, clr); break;

				//формат 32 бита на пиксель; 8 бит, используются для красного, зеленого и синего компонентов.
				case PixelFormat.Format32bppRgb: // Оставшиеся 8 бит не используются
				case PixelFormat.Format32bppArgb: // ???
				case PixelFormat.Format32bppPArgb: // 8 бит для красного, зеленого и синего компонентов умножаются в соответствии с альфа-компонентой.
					SetPixel32 (x, y, clr); break;
			}
		}

		void SetPixel24 (int x, int y, Color clr)
		{
			var pMem = pStart + x * 3 + y * _bd.Stride;
			*pMem++ = clr.B;
			*pMem++ = clr.G;
			*pMem = clr.R;
		}

		void SetPixel32 (int x, int y, Color clr)
		{
			var pMem = pStart + x * 4 + y * _bd.Stride;
			*pMem++ = clr.B;
			*pMem++ = clr.G;
			*pMem++ = clr.R;
			*pMem = clr.A;
		}

		public void ResetFirstPixel ()
		{
			pNextPixel = pStart;
		}
		public void SetNextPixel (Color clr)
		{
			*pNextPixel++ = clr.B;
			*pNextPixel++ = clr.G;
			*pNextPixel++ = clr.R;
			if (_bd.PixelFormat != PixelFormat.Format24bppRgb) *pNextPixel++ = clr.A;
		}

		public Color GetPixel (int x, int y)
		{
			if (!_locked) throw new Exception ();
			switch (_bd.PixelFormat)
			{
				case PixelFormat.Format24bppRgb: return GetPixel24 (x, y);
				case PixelFormat.Format32bppArgb: return GetPixel32 (x, y);
				default: throw new NotImplementedException ();
			}
		}

		Color GetPixel24 (int x, int y)
		{
			var pMem = pStart + x * 3 + y * _bd.Stride;
			return Color.FromArgb (*(pMem + 2), *(pMem + 1), *pMem);
		}

		Color GetPixel32 (int x, int y)
		{
			var pMem = pStart + x * 4 + y * _bd.Stride;
			return Color.FromArgb (*(pMem + 3), *(pMem + 2), *(pMem + 1), *pMem);
		}

		public bool IsLocked
		{
			get
			{
				return _locked;
			}
		}
	}

}

/*
public Form1 ()
{
	InitializeComponent ();

	using (var bmp = (Bitmap)Image.FromFile (@"i:\0.png"))
	{
		var clr = Color.Empty;
		var bb = new BufferedBitmap (bmp);
		for (int y = 0; y < bb.Height; ++y)
		{
			for (int x = 0; x < bb.Width; ++x)
			{
				clr = bb.GetPixel (x, y);
				if (clr.R == 0 && clr.G == 0 && clr.B == 128)
					bb.SetPixel (x, y, Color.FromArgb (127, 255, 0, 0));
				else
					bb.SetPixel (x, y, Color.White);
			}
		}
		bb.Unlock ();
		bmp.Save (@"i:\some0.png", ImageFormat.Png);
	}
}
*/
