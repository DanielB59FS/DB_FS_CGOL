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
	public partial class SeedDialog : Form {
		public decimal Seed { get => seedNumericUpDown.Value; set => seedNumericUpDown.Value = value; }
		public SeedDialog() {
			InitializeComponent();

			seedNumericUpDown.Minimum = decimal.MinValue;
			seedNumericUpDown.Maximum = decimal.MaxValue;
		}

		private void randomizeButton_Click(object sender, EventArgs e) {
			Seed = DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.Now.Minute;
		}
	}
}
