using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife {
	public partial class Form1 : Form {
		
		// Drawing colors
		Color gridColor = Color.Black;
		Color cellColor = Color.LightGray;

		// Pen & Brush
		Pen gridPen;
		SolidBrush cellBrush;

		// Cell string formating
		StringFormat format = new StringFormat(StringFormat.GenericDefault);

		// The Timer class
		GameTimer timer = new GameTimer();

		public Form1() {
			InitializeComponent();

			// Setting up timer interval and speed
			timer.Interval = 100;
			timer.Tick += Timer_Tick;

			// A Pen for drawing the grid lines (color, width)
			gridPen = new Pen(gridColor, 1);

			// A Brush for filling living cells interiors (color)
			cellBrush = new SolidBrush(cellColor);

			// A string format for aligning cells text
			format.Alignment = StringAlignment.Center;
		}

		// The event called by the timer every Interval milliseconds.
		private void Timer_Tick(object sender, EventArgs e) {
			Program.ModelInstance.NextGeneration();
			graphicsPanel1.Invalidate();
		}

		private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {
			
			// Calculate the width and height of each cell in pixels
			// CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
			float cellWidth = (float)graphicsPanel1.ClientSize.Width / Program.ModelInstance.GridWidth;
			// CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
			float cellHeight = (float)graphicsPanel1.ClientSize.Height / Program.ModelInstance.GridHeight;

			// Iterate through the universe
			foreach (CellPoint cell in Program.ModelInstance) {
				RectangleF cellRect = RectangleF.Empty;
				cellRect.X = cell._x * cellWidth;
				cellRect.Y = cell._y * cellHeight;
				cellRect.Width = cellWidth;
				cellRect.Height = cellHeight;

				if (cell._isAlive == true)
					e.Graphics.FillRectangle(cellBrush, cellRect);

				if (0 != cell._neighbors) {
					if (!cell._isAlive && 3 == cell._neighbors)
						cellBrush.Color = Color.Green;
					else if ((cell._isAlive && cell._neighbors < 2) || (cell._isAlive && 3 < cell._neighbors))
						cellBrush.Color = Color.Red;
					else
						cellBrush.Color = cell._isAlive ? Color.Green : Color.Red;
					graphicsPanel1.Font = new Font(Font.FontFamily, cellHeight, GraphicsUnit.Pixel);
					e.Graphics.DrawString(cell._neighbors.ToString(), graphicsPanel1.Font, cellBrush, cellRect, format);
					cellBrush.Color = cellColor;
				}
			}

			// Drawing the Y-axis grid lines
			for (int y = 1; y < Properties.Settings.Default.UniverseHeightCellCount; ++y) {
				gridPen.Width = (0 == y % 10) ? 2 : 1;
				e.Graphics.DrawLine(gridPen, 0, y * cellHeight, graphicsPanel1.Width, y * cellHeight);
			}

			// Drawing the X-axis grid lines
			for (int x = 1; x < Properties.Settings.Default.UniverseWidthCellCount; ++x) {
				gridPen.Width = (0 == x % 10) ? 2 : 1;
				e.Graphics.DrawLine(gridPen, x * cellWidth, 0, x * cellWidth, graphicsPanel1.Height);
			}

			// Drawing enclosing rectangle
			gridPen.Width = 4;
			e.Graphics.DrawRectangle(gridPen, 0, 0, graphicsPanel1.Width, graphicsPanel1.Height);

			// Update status strip generations
			toolStripStatusLabelGenerations.Text = $"Generations: {Program.ModelInstance.Generation} Interval: {timer.Interval} Alive: {Program.ModelInstance.Alive} Seed: {Properties.Settings.Default.Seed}";
		}

		private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e) {
			// If the left mouse button was clicked
			if (e.Button == MouseButtons.Left) {
				// Calculate the width and height of each cell in pixels
				float cellWidth = (float)graphicsPanel1.ClientSize.Width / Program.ModelInstance.GridWidth;
				float cellHeight = (float)graphicsPanel1.ClientSize.Height / Program.ModelInstance.GridHeight;

				// Calculate the cell that was clicked in
				// CELL X = MOUSE X / CELL WIDTH
				float x = e.X / cellWidth;
				// CELL Y = MOUSE Y / CELL HEIGHT
				float y = e.Y / cellHeight;

				// Toggle the cell's state
				Program.ModelInstance.ToggleCell((int)x, (int)y);

				// Tell Windows you need to repaint
				graphicsPanel1.Invalidate();
			}
		}

		private void playToolStripButton_Click(object sender, EventArgs e) {
			timer.Enabled = true;
		}

		private void stepToolStripButton_Click(object sender, EventArgs e) {
			timer.Step();
		}

		private void pauseToolStripButton_Click(object sender, EventArgs e) {
			timer.Enabled = false;
		}

		private void newToolStripButton_Click(object sender, EventArgs e) {
			Program.ModelInstance.Reset();
			graphicsPanel1.Invalidate();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}
	}
}
