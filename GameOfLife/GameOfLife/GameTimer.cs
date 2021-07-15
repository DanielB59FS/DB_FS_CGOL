using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife {
	class GameTimer : Timer {
		public void Step() {
			OnTick(EventArgs.Empty);
		}
		protected override void OnTick(EventArgs e) {
			base.OnTick(e);
		}
	}
}
