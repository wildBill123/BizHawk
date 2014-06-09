﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using BizHawk.Common;
using BizHawk.Emulation.Common;

namespace BizHawk.Client.Common
{
	public class Movie2 : IMovie
	{
		private enum Moviemode { Inactive, Play, Record, Finished }

		private readonly MovieLog _log = new MovieLog();
		private readonly PlatformFrameRates _frameRates = new PlatformFrameRates();
		private Moviemode _mode = Moviemode.Inactive;
		private bool MakeBackup { get; set; }

		public Movie2(string filename, bool startsFromSavestate = false)
			: this(startsFromSavestate)
		{
			Header.Rerecords = 0;
			Filename = filename;
		}

		public Movie2(bool startsFromSavestate = false)
		{
			Header = new MovieHeader2();
			Filename = string.Empty;
			Header.StartsFromSavestate = startsFromSavestate;
			
			IsCountingRerecords = true;
			_mode = Moviemode.Inactive;
			MakeBackup = true;
		}

		#region Implementation

		public string PreferredExtension { get { return "bk2"; } }

		public bool IsCountingRerecords { get; set; }
		public IMovieHeader Header { get; private set; }
		public SubtitleList Subtitles
		{
			get { throw new NotImplementedException(); }
		}

		public IList<string> Comments
		{
			get { throw new NotImplementedException(); }
		}

		public string SyncSettingsJson
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsActive
		{
			get { return _mode != Moviemode.Inactive; }
		}

		public bool IsPlaying
		{
			get { return _mode == Moviemode.Play || _mode == Moviemode.Finished; }
		}

		public bool IsRecording
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsFinished
		{
			get { return _mode == Moviemode.Finished; }
		}

		public bool Changes
		{
			get { throw new NotImplementedException(); }
			private set { throw new NotImplementedException(); }
		}

		public double FrameCount
		{
			get { throw new NotImplementedException(); }
		}

		public double Fps
		{
			get { throw new NotImplementedException(); }
		}

		public TimeSpan Time
		{
			get { throw new NotImplementedException(); }
		}

		public int InputLogLength
		{
			get { throw new NotImplementedException(); }
		}

		public string Filename
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool Load()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public string GetInputLog()
		{
			throw new NotImplementedException();
		}

		public bool CheckTimeLines(TextReader reader, out string errorMessage)
		{
			throw new NotImplementedException();
		}

		public bool ExtractInputLog(TextReader reader, out string errorMessage)
		{
			throw new NotImplementedException();
		}

		public void StartNewRecording()
		{
			throw new NotImplementedException();
		}

		public void StartNewPlayback()
		{
			throw new NotImplementedException();
		}

		public void Stop(bool saveChanges = true)
		{
			throw new NotImplementedException();
		}

		public void SwitchToRecord()
		{
			throw new NotImplementedException();
		}

		public void SwitchToPlay()
		{
			throw new NotImplementedException();
		}

		public void AppendFrame(IController source)
		{
			throw new NotImplementedException();
		}

		public void RecordFrame(int frame, IController source)
		{
			throw new NotImplementedException();
		}

		public void Truncate(int frame)
		{
			throw new NotImplementedException();
		}

		public string GetInput(int frame)
		{
			throw new NotImplementedException();
		}

		// Probably won't support
		public void PokeFrame(int frame, IController source)
		{
			throw new NotImplementedException();
		}

		public void ClearFrame(int frame)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}