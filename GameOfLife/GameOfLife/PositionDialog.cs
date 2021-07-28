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
	public partial class PositionDialog : Form {
		public decimal X { get => xUpDown.Value; set => xUpDown.Value = value; }
		public decimal Y { get => yUpDown.Value; set => yUpDown.Value = value; }
		public PositionDialog(int maxX, int maxY) {
			InitializeComponent();

			xUpDown.Minimum = yUpDown.Minimum = 0;
			xUpDown.Maximum = maxX;
			yUpDown.Maximum = maxY;
		}
	}
}
