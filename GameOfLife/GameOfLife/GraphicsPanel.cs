using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// I'm no longer using this, I'm using reflection instead to enable these two properties

// Change the namespace to your project's namespace.
namespace GameOfLife {
	public class GraphicsPanel : Panel {

		// Default constructor
		public GraphicsPanel() {
			// Turn on double buffering.
			DoubleBuffered = true;

			// Allow repainting when the window is resized.
			ResizeRedraw = true;
		}
	}
}
