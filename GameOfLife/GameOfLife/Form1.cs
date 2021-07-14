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
	public partial class Form1 : Form {
		// The universe array
		bool[,] universe = new bool[30, 30];

		// Drawing colors
		Color gridColor = Color.Black;
		Color cellColor = Color.Gray;

		// The Timer class
		Timer timer = new Timer();

		// Generation count
		int generations = 0;

		public Form1() {
			InitializeComponent();

			//// Turn on panel double buffering.
			//typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(panel1, true);

			//// Allow panel repainting when the window is resized.
			//typeof(Panel).GetProperty("ResizeRedraw", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(panel1, true);

			// Setup the timer
			timer.Interval = 100; // milliseconds
			timer.Tick += Timer_Tick;
			timer.Enabled = true; // start timer running
		}

		// Calculate the next generation of cells
		private void NextGeneration() {


			// Increment generation count
			generations++;

			// Update status strip generations
			toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
		}

		// The event called by the timer every Interval milliseconds.
		private void Timer_Tick(object sender, EventArgs e) {
			NextGeneration();
		}

		private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {
			// Calculate the width and height of each cell in pixels
			// CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
			float cellWidth = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
			// CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
			float cellHeight = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);

			// A Pen for drawing the grid lines (color, width)
			Pen gridPen = new Pen(gridColor, 1);

			// A Brush for filling living cells interiors (color)
			Brush cellBrush = new SolidBrush(cellColor);

			// Iterate through the universe in the y, top to bottom
			for (float y = 0; y < universe.GetLength(1); ++y) {
				// Iterate through the universe in the x, left to right
				for (float x = 0; x < universe.GetLength(0); ++x) {
					// A rectangle to represent each cell in pixels
					RectangleF cellRect = RectangleF.Empty;
					cellRect.X = x * cellWidth;
					cellRect.Y = y * cellHeight;
					cellRect.Width = cellWidth;
					cellRect.Height = cellHeight;

					// Fill the cell with a brush if alive
					if (universe[(int)x, (int)y] == true) {
						e.Graphics.FillRectangle(cellBrush, cellRect);
					}
				}
			}

			// Drawing the Y-axis grid lines
			for (float y = 1; y < universe.GetLength(1); ++y) {
				gridPen.Width = (0 == y % 10) ? 2 : 1;
				e.Graphics.DrawLine(gridPen, 0, y * cellHeight, graphicsPanel1.Width, y * cellHeight);
			}

			// Drawing the X-axis grid lines
			for (float x = 1; x < universe.GetLength(0); ++x) {
				gridPen.Width = (0 == x % 10) ? 2 : 1;
				e.Graphics.DrawLine(gridPen, x * cellWidth, 0, x * cellWidth, graphicsPanel1.Height);
			}

			// Drawing enclosing rectangle
			gridPen.Width = 4;
			e.Graphics.DrawRectangle(gridPen, 0, 0, graphicsPanel1.Width, graphicsPanel1.Height);

			// Cleaning up pens and brushes
			gridPen.Dispose();
			cellBrush.Dispose();
		}

		private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e) {
			// If the left mouse button was clicked
			if (e.Button == MouseButtons.Left) {
				// Calculate the width and height of each cell in pixels
				float cellWidth = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
				float cellHeight = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);

				// Calculate the cell that was clicked in
				// CELL X = MOUSE X / CELL WIDTH
				float x = e.X / cellWidth;
				// CELL Y = MOUSE Y / CELL HEIGHT
				float y = e.Y / cellHeight;

				// Toggle the cell's state
				universe[(int)x, (int)y] = !universe[(int)x, (int)y];

				// Tell Windows you need to repaint
				graphicsPanel1.Invalidate();
			}
		}
	}
}
