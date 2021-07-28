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
	public partial class RunToDialog : Form {
		public decimal Generation { get => generationUpDown.Value; set => generationUpDown.Value = value; }
		public RunToDialog(decimal minimum) {
			InitializeComponent();

			generationUpDown.Minimum = minimum;
			generationUpDown.Maximum = decimal.MaxValue;
		}
	}
}
