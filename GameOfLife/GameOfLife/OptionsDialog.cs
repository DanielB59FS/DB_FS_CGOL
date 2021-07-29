using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife {
	public partial class OptionsDialog : Form {
		public class OptionsApplyEventArgs : EventArgs {
			public decimal Interval { get; set; }
			public decimal UWidth { get; set; }
			public decimal UHeight { get; set; }
			public bool Scrollable { get; set; }
			public decimal CWidth { get; set; }
			public decimal CHeight { get; set; }

			public OptionsApplyEventArgs(decimal interval, decimal uWidth, decimal uHeight, bool scrollable, decimal cWidth, decimal cHeight) {
				Interval = interval;
				UWidth = uWidth;
				UHeight = uHeight;
				Scrollable = scrollable;
				CWidth = cWidth;
				CHeight = cHeight;
			}
		}

		public decimal Interval { get => timerIntervalUpDown.Value; set => timerIntervalUpDown.Value = value; }
		public decimal UWidth { get => uWidthUpDown.Value; set => uWidthUpDown.Value = value; }
		public decimal UHeight { get => uHeightUpDown.Value; set => uHeightUpDown.Value = value; }
		public bool Scrollable { get => scrollableCheckBox.Checked; set => scrollableCheckBox.Checked = value; }
		public decimal CWidth { get => cellWidthUpDown.Value; set => cellWidthUpDown.Value = value; }
		public decimal CHeight { get => cellHeightUpDown.Value; set => cellHeightUpDown.Value = value; }

		public event Action<object, OptionsApplyEventArgs> Apply;

		private GraphicsPanel _panel;

		public OptionsDialog(decimal interval, decimal width, decimal height, bool scrollable, decimal cellWidth, decimal cellHeight, GraphicsPanel panel) {
			InitializeComponent();
			_panel = panel;

			//  Events to update cell width & height option values based on selected universe size
			uWidthUpDown.ValueChanged += UWidthHeightUpDown_ValueChanged;
			uHeightUpDown.ValueChanged += UWidthHeightUpDown_ValueChanged;
			scrollableCheckBox.CheckedChanged += options_ValueChanged;

			uWidthUpDown.Minimum = uHeightUpDown.Minimum = timerIntervalUpDown.Minimum = 1;
			cellWidthUpDown.Maximum = cellHeightUpDown.Maximum = uWidthUpDown.Maximum = uHeightUpDown.Maximum = timerIntervalUpDown.Maximum = decimal.MaxValue;

			Interval = interval;
			UWidth = width;
			UHeight = height;
			Scrollable = scrollable;
			CWidth = cellWidth;
			CHeight = cellHeight;

			buttonApply.Enabled = false;
			scrollableCheckBox_CheckedChanged(this, EventArgs.Empty);
		}

		private void buttonApply_Click(object sender, EventArgs e) {
			if (null != Apply) Apply(this, new OptionsApplyEventArgs(Interval, UWidth, UHeight, Scrollable, CWidth, CHeight));
			buttonApply.Enabled = false;
		}

		private void options_ValueChanged(object sender, EventArgs e) {
			buttonApply.Enabled = true;
		}

		// Calculating the minimal cell width & height to avoid whitespace
		private void UWidthHeightUpDown_ValueChanged(object sender, EventArgs e) {
			if (0 != UWidth && 0 != UHeight) {
				cellWidthUpDown.Minimum = _panel.ClientSize.Width / UWidth;
				cellHeightUpDown.Minimum = _panel.ClientSize.Height / UHeight;
			}
		}

		private void scrollableCheckBox_CheckedChanged(object sender, EventArgs e) {
			cellWidthUpDown.Enabled = cellHeightUpDown.Enabled = Scrollable;
		}
	}
}
