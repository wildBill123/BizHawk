﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BizHawk.Client.Common;
using BizHawk.Emulation.Cores.Atari.Atari2600;

namespace BizHawk.Client.EmuHawk
{
	public partial class Atari2600Debugger : Form, IToolForm
	{
		private Atari2600 _core = Global.Emulator as Atari2600;

		public Atari2600Debugger()
		{
			InitializeComponent();

			//TODO: add to Closing a Mainform.ResumeControl() call
		}

		private void Atari2600Debugger_Load(object sender, EventArgs e)
		{
			// TODO: some kind of method like PauseAndRelinquishControl() which will set a flag preventing unpausing by the user, and then a ResumeControl() method that is done on close
			GlobalWin.MainForm.PauseEmulator();

		}

		public void Restart()
		{
			// TODO
		}

		public bool AskSave()
		{
			return false;
		}

		public bool UpdateBefore
		{
			get { return false; } // TODO: think about this
		}

		public void UpdateValues()
		{
			var flags = _core.GetCpuFlagsAndRegisters2();
			PCRegisterBox.Text = flags["PC"].ToString();

			SPRegisterBox.Text = flags["S"].ToString();
			SPRegisterHexBox.Text = string.Format("{0:X2}", flags["S"]);
			SPRegisterBinaryBox.Text = ToBinStr(flags["S"]);

			ARegisterBox.Text = flags["A"].ToString();
			ARegisterHexBox.Text = string.Format("{0:X2}", flags["A"]);
			ARegisterBinaryBox.Text = ToBinStr(flags["A"]);

			XRegisterBox.Text = flags["X"].ToString();
			XRegisterHexBox.Text = string.Format("{0:X2}", flags["X"]);
			XRegisterBinaryBox.Text = ToBinStr(flags["X"]);

			YRegisterBox.Text = flags["Y"].ToString();
			YRegisterHexBox.Text = string.Format("{0:X2}", flags["Y"]);
			YRegisterBinaryBox.Text = ToBinStr(flags["Y"]);

			NFlagCheckbox.Checked = flags["Flag N"] == 1;
			VFlagCheckbox.Checked = flags["Flag V"] == 1;
			TFlagCheckbox.Checked = flags["Flag T"] == 1;
			BFlagCheckbox.Checked = flags["Flag B"] == 1;

			DFlagCheckbox.Checked = flags["Flag D"] == 1;
			IFlagCheckbox.Checked = flags["Flag I"] == 1;
			ZFlagCheckbox.Checked = flags["Flag Z"] == 1;
			CFlagCheckbox.Checked = flags["Flag C"] == 1;

			FrameCountBox.Text = _core.Frame.ToString();
		}

		private string ToBinStr(int val)
		{
			return Convert.ToString((uint)val, 2).PadLeft(8, '0');
		}

		#region Events

		private void ExitMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void StepBtn_Click(object sender, EventArgs e)
		{
			_core.CycleAdvance();
			UpdateValues();

		}

		private void ScanlineAdvanceBtn_Click(object sender, EventArgs e)
		{
			_core.ScanlineAdvance();
			UpdateValues();
		}

		private void FrameAdvButton_Click(object sender, EventArgs e)
		{
			_core.FrameAdvance(true, true);
			UpdateValues();
		}

		#endregion
	}
}