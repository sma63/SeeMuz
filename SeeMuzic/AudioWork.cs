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

using Un4seen.Bass;

namespace SeeMuzic
{
	public partial class Form1 : Form
	{
		private void Search_Audio_Files ()
		{
			// Поиск аудиофайлов в текущей директории
			string curdir = Directory.GetCurrentDirectory ();
			string [] Fnames = Directory.GetFiles (curdir, "*.mp3", SearchOption.AllDirectories);
			//Fnames = Fnames.Union (Directory.GetFiles (curdir, "*.wma", SearchOption.AllDirectories)).ToArray ();
			//Fnames = Fnames.Union (Directory.GetFiles (curdir, "*.wav", SearchOption.AllDirectories)).ToArray ();
			if (Fnames.Length <= 0)
			{
				MessageBox.Show (curdir, "Не нашел *.mp3, *.wma, *.wav в текущей диретории");
				Environment.Exit (0);
			}

			// Перетасовка
			for (int i = 0; i < Fnames.Length; i++)
			{
				int j = rnd1.Next (Fnames.Length);
				int k = rnd1.Next (Fnames.Length);
				string swap = Fnames [j]; Fnames [j] = Fnames [k]; Fnames [k] = swap;
			}

			// чтение атрибутов аудиофайлов
			//if (Bass.BASS_Init (-1, SAMPLERATE, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
			//{
			//	for (int i = 0; i < Fnames.Length; i++)
			//	{
			//		int stream = Bass.BASS_StreamCreateFile (Fnames [i], 0, 0, BASSFlag.BASS_DEFAULT);
			//		if (stream != 0)
			//		{
			//			Un4seen.Bass.AddOn.Tags.TAG_INFO tags = Un4seen.Bass.AddOn.Tags.BassTags.BASS_TAG_GetFromFile (Fnames [i]);
			//			if (tags != null)
			//			{
			//				StringBuilder sb1 = new StringBuilder ();
			//				sb1.Append ("Artist = " + tags.artist);
			//				sb1.Append ("\nTitle = " + tags.title);
			//				sb1.Append ("\nAlbum = " + tags.album);
			//				sb1.Append (String.Format ("\nBitrate = {0}", (uint)tags.bitrate));
			//				double sec = Bass.BASS_ChannelBytes2Seconds (stream, Bass.BASS_ChannelGetLength (stream));
			//				double min = Math.Floor (sec / 60.0); 
			//				sb1.Append (String.Format ("\nLength = {0}:{1:00}", min, sec - min * 60.0));
			//				MessageBox.Show (sb1.ToString ());
			//			}
			//			Bass.BASS_StreamFree (stream);
			//		}
			//	}
			//	Bass.BASS_Free ();
			//}

			// инициализация параметров просмотра
			//parm1 = new Param [Fnames.Length];
			//if (Bass.BASS_Init (-1, SAMPLERATE, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
			//{
			//	for (int i = 0; i < Fnames.Length; i++)
			//	{
			//		if ((parm1 [i] = ListParam.Find (x => x.Fname.Contains (Fnames [i]))) == null)
			//		{
			//			Parm_To_Tab (parm1 [i] = new Param ());
			//		}
			//		Un4seen.Bass.AddOn.Tags.TAG_INFO tags = Un4seen.Bass.AddOn.Tags.BassTags.BASS_TAG_GetFromFile (Fnames [i]);
			//		if (tags != null)
			//		{
			//			int stream = Bass.BASS_StreamCreateFile (Fnames [i], 0, 0, BASSFlag.BASS_DEFAULT);
			//			if (stream != 0)
			//			{
			//				parm1 [i].Length = (int)Bass.BASS_ChannelBytes2Seconds (stream, Bass.BASS_ChannelGetLength (stream));
			//				Bass.BASS_StreamFree (stream);
			//			}
			//		}
			//	}
			//	Bass.BASS_Free ();
			//}
		}
		// Search_Audio_Files

		private void Audio_Start ()
		{
			if (!Bass.BASS_Init (-1, SAMPLERATE, BASSInit.BASS_DEVICE_DEFAULT | BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero))
			{
				MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
				this.Close ();
			}

			Form1_Next_Title (ListParam [iFnames].Fname);
			Audio_Stream = Bass.BASS_StreamCreateFile (ListParam [iFnames].Fname, 0, 0, BASSFlag.BASS_DEFAULT);
			if (Audio_Stream == 0)
			{
				MessageBox.Show (String.Format ("Stream error: {0}", Bass.BASS_ErrorGetCode ()), "Error");
				this.Close ();
			}

			flen = Bass.BASS_ChannelGetLength (Audio_Stream);
			_syncer = Bass.BASS_ChannelSetSync (Audio_Stream, BASSSync.BASS_SYNC_END, 0, _syncProcEndStream, IntPtr.Zero);
			Bass.BASS_ChannelPlay (Audio_Stream, false);
			Bass.BASS_ChannelSetAttribute (Form1.Audio_Stream, BASSAttribute.BASS_ATTRIB_VOL, (float)Volume / 10.0f);

			if (0 < ListParam [iFnames].Resample) // если уже есть данные
			{
				Tab_To_Parm (ListParam [iFnames]);
				if (bPanel) Panel1.Reload ();
			}

			timer1.Interval = Interval;
			timer1.Enabled = true;
			timer2.Enabled = true;
		}
		//Audio_Start

		private void Audio_Stop ()
		{
			Bass.BASS_StreamFree (Audio_Stream);
			Bass.BASS_Free ();
			timer1.Enabled = false;
			timer2.Enabled = false;
		}
		// Audio_Stop

		public static void Audio_Next (int idx = -1)
		{
			if (0 <= idx) // select
			{
				idx %= ListParam.Count;
				if (idx != iFnames)
				{
					if (0 < ListParam [iFnames].Resample) Tab_To_Parm (ListParam [iFnames]);
					iFnames = idx;
					if (bPanel) Panel1.Reload ();
				}
			}
			else
			{
				Parm_To_Tab (ListParam [iFnames]);
				if (idx == -1)
					iFnames = (iFnames + 1) % ListParam.Count; // next
				else
					iFnames = (iFnames - 1 + ListParam.Count) % ListParam.Count; // prev
			}
			if (Audio_Stream == 0) himself.Audio_Start (); else bRestart = true;
		}
		// Audio_Next
	}
}