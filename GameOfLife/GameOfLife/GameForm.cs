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
	public partial class GameForm : Form {

		// Local runtime properties
		int seed;

		bool isQuadTree;
		bool Toroidal {
			get => Program.ModelInstance.IsToroidal;
			set => Program.ModelInstance.IsToroidal = value;
		}
		bool displayHUD;
		bool displayNeighborCount;
		bool displayGrid;

		// Drawing colors
		Color cellColor;
		Color gridColor;
		Color grid10Color;

		// Pen & Brush
		Pen gridPen;
		SolidBrush cellBrush;

		// Cell string formating
		StringFormat format = new StringFormat(StringFormat.GenericDefault);

		// The Timer class
		GraphicsTimer timer = new GraphicsTimer();

		private void ReadProperties() {
			cellColor = Properties.Settings.Default.CellColor;
			gridColor = Properties.Settings.Default.GridColor;
			grid10Color = Properties.Settings.Default.Grid10Color;
			graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;

			displayHUD = Properties.Settings.Default.DisplayHUD;
			displayNeighborCount = Properties.Settings.Default.DisplayNeighborCount;
			displayGrid = Properties.Settings.Default.DisplayGrid;
			timer.Interval = Properties.Settings.Default.Inverval;
			seed = DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.Now.Minute;

			isQuadTree = Properties.Settings.Default.QuadTreeModel;
			Program.ModelInstance.GridWidth = Properties.Settings.Default.UniverseWidthCellCount;
			Program.ModelInstance.GridHeight = Properties.Settings.Default.UniverseHeightCellCount;
			Toroidal = Properties.Settings.Default.ToroidalMode;

			WindowState = Properties.Settings.Default.WindowState;

			graphicsPanel1.Invalidate();
		}

		public GameForm() {
			InitializeComponent();

			ReadProperties();
			Program.ModelInstance.Reset();

			hUDContextMenuItem.Checked = hUDToolStripMenuItem.Checked = displayHUD;
			neighborCountContextMenuItem.Checked = neighborCountToolStripMenuItem.Checked = displayNeighborCount;
			gridContextMenuItem.Checked = gridToolStripMenuItem.Checked = displayGrid;
			toroidalToolStripMenuItem.Checked = Toroidal;
			finiteToolStripMenuItem.Checked = !Toroidal;

			// Setting up timer interval and speed
			timer.Tick += Timer_Tick;

			// A Pen for drawing the grid lines (color, width)
			gridPen = new Pen(gridColor, 1);

			// A Brush for filling living cells interiors (color)
			cellBrush = new SolidBrush(cellColor);
		}

		// The event called by the timer every Interval milliseconds.
		private void Timer_Tick(object sender, EventArgs e) {
			Program.ModelInstance.NextGeneration();
			graphicsPanel1.Invalidate();
		}

		private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {

			// Translating panel scroll position
			e.Graphics.TranslateTransform(graphicsPanel1.AutoScrollPosition.X, graphicsPanel1.AutoScrollPosition.Y);

			// A string format for aligning cells text
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;

			// Calculate the width and height of each cell in pixels
			// CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
			float cellWidth = (float)graphicsPanel1.ClientSize.Width / Program.ModelInstance.GridWidth;
			cellWidth = Math.Max(cellWidth, graphicsPanel1.ClientSize.Width * 0.066f);
			// CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
			float cellHeight = (float)graphicsPanel1.ClientSize.Height / Program.ModelInstance.GridHeight;
			cellHeight = Math.Max(cellHeight, graphicsPanel1.ClientSize.Height * 0.041f);

			graphicsPanel1.AutoScrollMinSize = new SizeF(cellWidth * Program.ModelInstance.GridWidth, cellHeight * Program.ModelInstance.GridHeight).ToSize();

			// Iterate through the universe
			foreach (CellPoint cell in Program.ModelInstance) {
				RectangleF cellRect = RectangleF.Empty;
				cellRect.X = cell._x * cellWidth;
				cellRect.Y = cell._y * cellHeight;
				cellRect.Width = cellWidth;
				cellRect.Height = cellHeight;

				if (e.Graphics.IsVisible(cellRect)) {
					if (cell._isAlive == true) {
						cellBrush.Color = cellColor;
						e.Graphics.FillRectangle(cellBrush, cellRect);
					}

					if (0 != cell._neighbors && displayNeighborCount) {
						if (!cell._isAlive && 3 == cell._neighbors)
							cellBrush.Color = Color.Green;
						else if ((cell._isAlive && cell._neighbors < 2) || (cell._isAlive && 3 < cell._neighbors))
							cellBrush.Color = Color.Red;
						else
							cellBrush.Color = cell._isAlive ? Color.Green : Color.Red;
						graphicsPanel1.Font = new Font(Font.FontFamily, cellHeight, GraphicsUnit.Pixel);
						e.Graphics.DrawString(cell._neighbors.ToString(), graphicsPanel1.Font, cellBrush, cellRect, format);
					}
				}
			}

			if (displayGrid) {
				gridPen.Color = gridColor;
				// Drawing the X-axis grid lines
				for (int y = 1; y < Program.ModelInstance.GridHeight; ++y) {
					gridPen.Width = (0 == y % 10) ? 2 : 1;
					gridPen.Color = (0 == y % 10) ? grid10Color : gridColor;
					e.Graphics.DrawLine(gridPen, 0, y * cellHeight, cellWidth * Program.ModelInstance.GridWidth, y * cellHeight);
				}

				// Drawing the Y-axis grid lines
				for (int x = 1; x < Program.ModelInstance.GridWidth; ++x) {
					gridPen.Width = (0 == x % 10) ? 2 : 1;
					gridPen.Color = (0 == x % 10) ? grid10Color : gridColor;
					e.Graphics.DrawLine(gridPen, x * cellWidth, 0, x * cellWidth, cellHeight * Program.ModelInstance.GridHeight);
				}

				// Drawing enclosing rectangle
				gridPen.Color = grid10Color;
				gridPen.Width = 4;
				e.Graphics.DrawRectangle(gridPen, 0, 0, cellWidth * Program.ModelInstance.GridWidth, cellHeight * Program.ModelInstance.GridHeight);
			}

			if (displayHUD) {
				//cellBrush.Color = Color.FromArgb(0xFFFFFFF - BackColor.ToArgb());
				cellBrush.Color = Color.FromArgb(127, 255, 0, 0);

				// A string format for aligning cells text
				format.Alignment = StringAlignment.Near;
				format.LineAlignment = StringAlignment.Far;
				hudLabel.Font = graphicsPanel1.Font;
				hudLabel.ForeColor = Color.Transparent;

				e.Graphics.DrawString(
					$"Generations: {Program.ModelInstance.Generation}\n" +
					$"Alive : {Program.ModelInstance.Alive}\n" +
					$"Boundary Type: {(Toroidal ? "Toroidal" : "Finite")}\n" +
					$"Universe Size: (Width: {Program.ModelInstance.GridWidth}, Height: {Program.ModelInstance.GridHeight})",
					graphicsPanel1.Font, cellBrush, new RectangleF(-graphicsPanel1.AutoScrollPosition.X, -graphicsPanel1.AutoScrollPosition.Y, graphicsPanel1.Width, graphicsPanel1.Height - cellHeight), format);
			}

			// Update status strip generations
			toolStripStatusLabelGenerations.Text = $"Generations: {Program.ModelInstance.Generation} Interval: {timer.Interval} Alive: {Program.ModelInstance.Alive} Seed: {seed}";
		}

		private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e) {
			// If the left mouse button was clicked
			if (e.Button == MouseButtons.Left) {
				// Calculate the width and height of each cell in pixels
				float cellWidth = (float)graphicsPanel1.ClientSize.Width / Program.ModelInstance.GridWidth;
				cellWidth = Math.Max(cellWidth, graphicsPanel1.ClientSize.Width * 0.066f);
				float cellHeight = (float)graphicsPanel1.ClientSize.Height / Program.ModelInstance.GridHeight;
				cellHeight = Math.Max(cellHeight, graphicsPanel1.ClientSize.Height * 0.041f);

				// Calculate the cell that was clicked in
				// CELL X = MOUSE X / CELL WIDTH
				float x = (e.X - graphicsPanel1.AutoScrollPosition.X) / cellWidth;
				// CELL Y = MOUSE Y / CELL HEIGHT
				float y = (e.Y - graphicsPanel1.AutoScrollPosition.Y) / cellHeight;

				if (0 != graphicsPanel1.AutoScrollPosition.X || 0 != graphicsPanel1.AutoScrollPosition.Y) {
					int h = 0;
					++h;
				}
				// Toggle the cell's state
				Program.ModelInstance.ToggleCell((int)x, (int)y);

				// Tell Windows you need to repaint
				graphicsPanel1.Invalidate();
			}
		}

		private void playToolStripButton_Click(object sender, EventArgs e) {
			playToolStripButton.Enabled = playToolStripMenuItem.Enabled = false;
			stepToolStripButton.Enabled = stepToolStripMenuItem.Enabled = false;
			pauseToolStripButton.Enabled = pauseToolStripMenuItem.Enabled = true;
			timer.Enabled = true;
		}

		private void stepToolStripButton_Click(object sender, EventArgs e) {
			timer.Step();
		}

		private void pauseToolStripButton_Click(object sender, EventArgs e) {
			timer.Enabled = false;
			pauseToolStripButton.Enabled = pauseToolStripMenuItem.Enabled = false;
			playToolStripButton.Enabled = playToolStripMenuItem.Enabled = true;
			stepToolStripButton.Enabled = stepToolStripMenuItem.Enabled = true;
		}

		private void newToolStripButton_Click(object sender, EventArgs e) {
			pauseToolStripButton_Click(sender, e);
			Program.ModelInstance.Reset();
			graphicsPanel1.Invalidate();
		}

		private void toToolStripMenuItem_Click(object sender, EventArgs e) {
			// TODO: modal dialog box
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void hUDToolStripMenuItem_Click(object sender, EventArgs e) {
			hUDToolStripMenuItem.Checked = !hUDToolStripMenuItem.Checked;
			hUDContextMenuItem.Checked = !hUDContextMenuItem.Checked;
			displayHUD = !displayHUD;
			// TODO: add drawing in paint method
		}

		private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e) {
			neighborCountToolStripMenuItem.Checked = !neighborCountToolStripMenuItem.Checked;
			neighborCountContextMenuItem.Checked = !neighborCountContextMenuItem.Checked;
			displayNeighborCount = !displayNeighborCount;
			graphicsPanel1.Invalidate();
		}

		private void gridToolStripMenuItem_Click(object sender, EventArgs e) {
			gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;
			gridContextMenuItem.Checked = !gridContextMenuItem.Checked;
			displayGrid = !displayGrid;
			graphicsPanel1.Invalidate();
		}

		private void toroidalToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!toroidalToolStripMenuItem.Checked) {
				bool timerState = timer.Enabled;
				if (timerState) pauseToolStripButton_Click(sender, e);
				toroidalToolStripMenuItem.Checked = true;
				finiteToolStripMenuItem.Checked = false;
				Toroidal = true;
				if (timerState) playToolStripButton_Click(sender, e);
				graphicsPanel1.Invalidate();
			}
		}

		private void finiteToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!finiteToolStripMenuItem.Checked) {
				bool timerState = timer.Enabled;
				if (timerState) pauseToolStripButton_Click(sender, e);
				finiteToolStripMenuItem.Checked = true;
				toroidalToolStripMenuItem.Checked = false;
				Toroidal = false;
				if (timerState) playToolStripButton_Click(sender, e);
				graphicsPanel1.Invalidate();
			}
		}

		private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e) {
			using (SeedDialog sdlg = new SeedDialog()) {
				sdlg.Seed = seed;

				if (DialogResult.OK == sdlg.ShowDialog()) {
					seed = (int)sdlg.Seed;
					Program.ModelInstance.Reset();
					Program.ModelInstance.GenerateCells(seed);
					graphicsPanel1.Invalidate();
				}
			}
		}

		private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e) {
			Program.ModelInstance.Reset();
			Program.ModelInstance.GenerateCells(seed);
			graphicsPanel1.Invalidate();
		}

		private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e) {
			seed = DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.Now.Minute;
			Program.ModelInstance.Reset();
			Program.ModelInstance.GenerateCells(seed);
			graphicsPanel1.Invalidate();
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
			Properties.Settings.Default.Reset();
			ReadProperties();
		}

		private void reloadToolStripMenuItem_Click(object sender, EventArgs e) {
			Properties.Settings.Default.Reload();
			ReadProperties();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			//
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			Properties.Settings.Default.CellColor = cellColor;
			Properties.Settings.Default.GridColor = gridColor;
			Properties.Settings.Default.Grid10Color = grid10Color;
			Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;

			Properties.Settings.Default.DisplayHUD = displayHUD;
			Properties.Settings.Default.DisplayNeighborCount = displayNeighborCount;
			Properties.Settings.Default.DisplayGrid = displayGrid;
			Properties.Settings.Default.Inverval = timer.Interval;

			Properties.Settings.Default.QuadTreeModel = isQuadTree;
			Properties.Settings.Default.UniverseWidthCellCount = Program.ModelInstance.GridWidth;
			Properties.Settings.Default.UniverseHeightCellCount = Program.ModelInstance.GridHeight;
			Properties.Settings.Default.ToroidalMode = Toroidal;

			if (FormWindowState.Minimized != WindowState) Properties.Settings.Default.WindowState = WindowState;

			Properties.Settings.Default.Save();
		}

		private void backColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = graphicsPanel1.BackColor;

				if (DialogResult.OK == cdlg.ShowDialog())
					graphicsPanel1.BackColor = cdlg.Color;
			}
		}

		private void cellColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = cellColor;

				if (DialogResult.OK == cdlg.ShowDialog())
					cellColor = cdlg.Color;

				graphicsPanel1.Invalidate();
			}
		}

		private void gridColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = gridColor;

				if (DialogResult.OK == cdlg.ShowDialog())
					gridColor = cdlg.Color;

				graphicsPanel1.Invalidate();
			}
		}

		private void gridX10ColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = grid10Color;

				if (DialogResult.OK == cdlg.ShowDialog())
					grid10Color = cdlg.Color;

				graphicsPanel1.Invalidate();
			}
		}
	}
}
