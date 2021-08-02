using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife {
	public partial class GameForm : Form {

		// Local runtime properties
		int seed;

		bool Toroidal {
			get => Program.ModelInstance.IsToroidal;
			set => Program.ModelInstance.IsToroidal = value;
		}

		bool _scrollable;
		bool _displayHUD;
		bool _displayNeighborCount;
		bool _displayGrid;

		decimal _runTo = -1;

		decimal _cellWidth, _cellHeight;

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

		// Reading settings values
		private void ReadProperties() {
			// Grid settings
			cellColor = Properties.Settings.Default.CellColor;
			gridColor = Properties.Settings.Default.GridColor;
			grid10Color = Properties.Settings.Default.Grid10Color;
			graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;

			// Display states
			_scrollable = Properties.Settings.Default.Scrollable;
			_displayHUD = Properties.Settings.Default.DisplayHUD;
			_displayNeighborCount = Properties.Settings.Default.DisplayNeighborCount;
			_displayGrid = Properties.Settings.Default.DisplayGrid;
			timer.Interval = Properties.Settings.Default.Inverval;
			seed = DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.Now.Minute;

			// Model settings
			Program.ModelInstance.GridWidth = Properties.Settings.Default.UniverseWidthCellCount;
			Program.ModelInstance.GridHeight = Properties.Settings.Default.UniverseHeightCellCount;
			Toroidal = Properties.Settings.Default.ToroidalMode;

			// UI settings
			WindowState = Properties.Settings.Default.WindowState;

			hUDContextMenuItem.Checked = hUDToolStripMenuItem.Checked = _displayHUD;
			neighborCountContextMenuItem.Checked = neighborCountToolStripMenuItem.Checked = _displayNeighborCount;
			gridContextMenuItem.Checked = gridToolStripMenuItem.Checked = _displayGrid;
			toroidalToolStripMenuItem.Checked = Toroidal;
			finiteToolStripMenuItem.Checked = !Toroidal;

			// Cell width & height
			_cellWidth = Properties.Settings.Default.CellWidth;
			_cellHeight = Properties.Settings.Default.CellHeight;

			graphicsPanel1.Invalidate();
		}

		public GameForm() {
			InitializeComponent();

			ReadProperties();
			Program.ModelInstance.Reset();

			// Invalidating so HUD remains in correct location during scrolling. TODO: find a better solution
			graphicsPanel1.Scroll += (o, e) => { if (_displayHUD) graphicsPanel1.Invalidate(); };
			graphicsPanel1.MouseWheel += (o, e) => { if (_displayHUD) graphicsPanel1.Invalidate(); };

			// Setting up timer interval and speed
			timer.Tick += Timer_Tick;

			// A Pen for drawing the grid lines (color, width)
			gridPen = new Pen(gridColor, 1);

			// A Brush for filling living cells interiors (color)
			cellBrush = new SolidBrush(cellColor);
		}

		// The event called by the timer every Interval milliseconds.
		private void Timer_Tick(object sender, EventArgs e) {
			if (-1 != _runTo && _runTo <= (decimal)Program.ModelInstance.Generation) {
				pauseToolStripButton_Click(this, EventArgs.Empty);
			}
			else
				Program.ModelInstance.NextGeneration();
			graphicsPanel1.Invalidate();
		}

		private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {

			// Translating panel scroll position
			e.Graphics.TranslateTransform(graphicsPanel1.AutoScrollPosition.X, graphicsPanel1.AutoScrollPosition.Y);

			// A string format for aligning cells text
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;

			// Calculate the width and height of each cell in pixels: scrollable & non-scrollable values
			// CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
			// CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
			if (!_scrollable) {
				_cellWidth = (decimal)graphicsPanel1.ClientSize.Width / Program.ModelInstance.GridWidth;
				_cellHeight = (decimal)graphicsPanel1.ClientSize.Height / Program.ModelInstance.GridHeight;
			} else {
				_cellWidth = Math.Max((decimal)graphicsPanel1.ClientSize.Width / Program.ModelInstance.GridWidth, _cellWidth);
				_cellHeight = Math.Max((decimal)graphicsPanel1.ClientSize.Height / Program.ModelInstance.GridHeight, _cellHeight);
			}

			// Updating scrolling size base on grid size
			graphicsPanel1.AutoScrollMinSize = new SizeF((float)(_cellWidth * Program.ModelInstance.GridWidth), (float)(_cellHeight * Program.ModelInstance.GridHeight)).ToSize();

			graphicsPanel1.Font = new Font(Font.FontFamily, (float)_cellHeight, GraphicsUnit.Pixel);

			HashSet<RectangleBoundary> boundaries = new HashSet<RectangleBoundary>();
			// Iterate through the universe
			foreach (CellPoint cell in Program.ModelInstance.Query(new RectangleBoundary() { _x = -graphicsPanel1.AutoScrollPosition.X / _cellWidth, _y = -graphicsPanel1.AutoScrollPosition.Y / _cellHeight, _w = graphicsPanel1.Bounds.Width/_cellWidth, _h = graphicsPanel1.Bounds.Height / _cellHeight }, cell => cell._isAlive || 0 != cell._neighbors)) {
				if (null != cell.Boundary) boundaries.Add(cell.Boundary);

				// Calculating cell rectangle
				RectangleF cellRect = RectangleF.Empty;
				cellRect.X = (float)(cell._x * _cellWidth);
				cellRect.Y = (float)(cell._y * _cellHeight);
				cellRect.Width = (float)_cellWidth;
				cellRect.Height = (float)_cellHeight;

				// Cell coloring
				if (cell._isAlive == true) {
					cellBrush.Color = cellColor;
					e.Graphics.FillRectangle(cellBrush, cellRect);
				}

				// Neighbor count drawing
				if (0 != cell._neighbors && _displayNeighborCount) {
					if (!cell._isAlive && 3 == cell._neighbors)
						cellBrush.Color = Color.Green;
					else if ((cell._isAlive && cell._neighbors < 2) || (cell._isAlive && 3 < cell._neighbors))
						cellBrush.Color = Color.Red;
					else
						cellBrush.Color = cell._isAlive ? Color.Green : Color.Red;
					e.Graphics.DrawString(cell._neighbors.ToString(), graphicsPanel1.Font, cellBrush, cellRect, format);
				}
			}

			#region Previous Version
			//foreach (CellPoint cell in Program.ModelInstance) {
			//	RectangleF cellRect = RectangleF.Empty;
			//	cellRect.X = (float)(cell._x * _cellWidth);
			//	cellRect.Y = (float)(cell._y * _cellHeight);
			//	cellRect.Width = (float)_cellWidth;
			//	cellRect.Height = (float)_cellHeight;

			//	if (e.Graphics.IsVisible(cellRect)) {
			//		if (cell._isAlive == true) {
			//			cellBrush.Color = cellColor;
			//			e.Graphics.FillRectangle(cellBrush, cellRect);
			//		}

			//		if (0 != cell._neighbors && _displayNeighborCount) {
			//			if (!cell._isAlive && 3 == cell._neighbors)
			//				cellBrush.Color = Color.Green;
			//			else if ((cell._isAlive && cell._neighbors < 2) || (cell._isAlive && 3 < cell._neighbors))
			//				cellBrush.Color = Color.Red;
			//			else
			//				cellBrush.Color = cell._isAlive ? Color.Green : Color.Red;
			//			e.Graphics.DrawString(cell._neighbors.ToString(), graphicsPanel1.Font, cellBrush, cellRect, format);
			//		}
			//	}
			//}
			#endregion

			// TODO: change method to draw only the visible lines
			if (_displayGrid) {
				gridPen.Color = gridColor;
				// Drawing the X-axis grid lines
				for (int y = 1; y < Program.ModelInstance.GridHeight; ++y) {
					gridPen.Width = (0 == y % 10) ? 2 : 1;
					gridPen.Color = (0 == y % 10) ? grid10Color : gridColor;
					e.Graphics.DrawLine(gridPen, 0, (float)(y * _cellHeight), (float)(_cellWidth * Program.ModelInstance.GridWidth), (float)(y * _cellHeight));
				}

				// Drawing the Y-axis grid lines
				for (int x = 1; x < Program.ModelInstance.GridWidth; ++x) {
					gridPen.Width = (0 == x % 10) ? 2 : 1;
					gridPen.Color = (0 == x % 10) ? grid10Color : gridColor;
					e.Graphics.DrawLine(gridPen, (float)(x * _cellWidth), 0, (float)(x * _cellWidth), (float)(_cellHeight * Program.ModelInstance.GridHeight));
				}

				// Drawing enclosing rectangle
				gridPen.Color = grid10Color;
				gridPen.Width = 4;
				e.Graphics.DrawRectangle(gridPen, 0, 0, (float)(_cellWidth * Program.ModelInstance.GridWidth), (float)(_cellHeight * Program.ModelInstance.GridHeight));
			}

			foreach (RectangleBoundary rect in boundaries) {
				if (null != rect) {
					// Calculating boundary rectangle
					gridPen.Color = Color.FromArgb(160, 0, 255, 0);
					gridPen.Width = 2;
					RectangleF bRect = RectangleF.Empty;
					bRect.X = (float)(rect._x * _cellWidth);
					bRect.Y = (float)(rect._y * _cellHeight);
					bRect.Width = (float)(_cellWidth * rect._w);
					bRect.Height = (float)(_cellHeight * rect._h);
					if (1 <= bRect.Width && 1 <= bRect.Height)
						e.Graphics.DrawRectangle(gridPen, bRect.X, bRect.Y, bRect.Width, bRect.Height);
				}
			}

			// Drawing of HUD
			if (_displayHUD) {
				// HUD color
				cellBrush.Color = Color.FromArgb(127, 255, 0, 0);

				// A string format for aligning cells text
				format.Alignment = StringAlignment.Near;
				format.LineAlignment = StringAlignment.Far;

				// Current client rectangle values
				RectangleF clientRectangle = graphicsPanel1.ClientRectangle;
				clientRectangle.X -= graphicsPanel1.AutoScrollPosition.X;
				clientRectangle.Y -= graphicsPanel1.AutoScrollPosition.Y;

				// Drawing HUD
				e.Graphics.DrawString(
					$"Generations: {Program.ModelInstance.Generation}\n" +
					$"Alive : {Program.ModelInstance.Alive}\n" +
					$"Boundary Type: {(Toroidal ? "Toroidal" : "Finite")}\n" +
					$"Universe Size: (Width: {Program.ModelInstance.GridWidth}, Height: {Program.ModelInstance.GridHeight})",
					graphicsPanel1.Font, cellBrush, clientRectangle, format);
			}

			// Update status strip generations
			toolStripStatusLabelGenerations.Text = $"Generations: {Program.ModelInstance.Generation} Interval: {timer.Interval} Alive: {Program.ModelInstance.Alive} Seed: {seed}";
		}

		private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e) {
			// If the left mouse button was clicked
			if (e.Button == MouseButtons.Left) {

				// Calculate the cell that was clicked in
				// CELL X = MOUSE X / CELL WIDTH
				decimal x = (e.X - graphicsPanel1.AutoScrollPosition.X) / _cellWidth;
				// CELL Y = MOUSE Y / CELL HEIGHT
				decimal y = (e.Y - graphicsPanel1.AutoScrollPosition.Y) / _cellHeight;

				// Toggle the cell's state
				Program.ModelInstance.ToggleCell((int)x, (int)y);

				// Tell Windows you need to repaint
				graphicsPanel1.Invalidate();
			}
		}

		// Play button event
		private void playToolStripButton_Click(object sender, EventArgs e) {
			// Updating button states and starting timer
			toToolStripMenuItem.Enabled = false;
			playToolStripButton.Enabled = playToolStripMenuItem.Enabled = false;
			stepToolStripButton.Enabled = stepToolStripMenuItem.Enabled = false;
			pauseToolStripButton.Enabled = pauseToolStripMenuItem.Enabled = true;
			timer.Enabled = true;
		}

		// Step button event
		private void stepToolStripButton_Click(object sender, EventArgs e) {
			// Performing a single timer tick event
			timer.Step();
		}

		// Pause button event
		private void pauseToolStripButton_Click(object sender, EventArgs e) {
			// Updating button states and stoping timer
			timer.Enabled = false;
			pauseToolStripButton.Enabled = pauseToolStripMenuItem.Enabled = false;
			playToolStripButton.Enabled = playToolStripMenuItem.Enabled = true;
			stepToolStripButton.Enabled = stepToolStripMenuItem.Enabled = true;
			toToolStripMenuItem.Enabled = true;

			// Resetting value for run to generation option
			_runTo = -1;
		}

		// New button event
		private void newToolStripButton_Click(object sender, EventArgs e) {
			// Creating a new clean universe
			pauseToolStripButton_Click(sender, e);
			Program.ModelInstance.Reset();
			graphicsPanel1.Invalidate();
		}

		// To button event
		private void toToolStripMenuItem_Click(object sender, EventArgs e) {
			// Setting run to generation value via dialog and starting timer
			using (RunToDialog rdlg = new RunToDialog((decimal)Program.ModelInstance.Generation)) {
				rdlg.Generation = (decimal)Program.ModelInstance.Generation;

				if (DialogResult.OK == rdlg.ShowDialog()) {
					_runTo = rdlg.Generation;
					playToolStripButton_Click(this, EventArgs.Empty);
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		// HUD button event
		private void hUDToolStripMenuItem_Click(object sender, EventArgs e) {
			hUDToolStripMenuItem.Checked = !hUDToolStripMenuItem.Checked;
			hUDContextMenuItem.Checked = !hUDContextMenuItem.Checked;
			_displayHUD = !_displayHUD;
			graphicsPanel1.Invalidate();
		}

		// Neighbor count button event
		private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e) {
			neighborCountToolStripMenuItem.Checked = !neighborCountToolStripMenuItem.Checked;
			neighborCountContextMenuItem.Checked = !neighborCountContextMenuItem.Checked;
			_displayNeighborCount = !_displayNeighborCount;
			graphicsPanel1.Invalidate();
		}

		// Grid button event
		private void gridToolStripMenuItem_Click(object sender, EventArgs e) {
			gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;
			gridContextMenuItem.Checked = !gridContextMenuItem.Checked;
			_displayGrid = !_displayGrid;
			graphicsPanel1.Invalidate();
		}

		// Toroidal button event
		private void toroidalToolStripMenuItem_Click(object sender, EventArgs e) {
			// temporarily pausing timer to re-evaluate neighbor count
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

		// Finite button event
		private void finiteToolStripMenuItem_Click(object sender, EventArgs e) {
			// temporarily pausing timer to re-evaluate neighbor count
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

		// FromSeed button event
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

		// FromCurrentSeed button event
		private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e) {
			Program.ModelInstance.Reset();
			Program.ModelInstance.GenerateCells(seed);
			graphicsPanel1.Invalidate();
		}

		// FromTime button event
		private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e) {
			seed = DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.Now.Minute;
			Program.ModelInstance.Reset();
			Program.ModelInstance.GenerateCells(seed);
			graphicsPanel1.Invalidate();
		}

		// Settings reset button event
		private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
			Properties.Settings.Default.Reset();
			ReadProperties();
			Program.ModelInstance.Reset();
		}

		// Settings reload button event
		private void reloadToolStripMenuItem_Click(object sender, EventArgs e) {
			Properties.Settings.Default.Reload();
			ReadProperties();
			Program.ModelInstance.Reset();
		}

		// Form closing event handling
		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			// Grid settings
			Properties.Settings.Default.CellColor = cellColor;
			Properties.Settings.Default.GridColor = gridColor;
			Properties.Settings.Default.Grid10Color = grid10Color;
			Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;

			// Display & UI states
			Properties.Settings.Default.Scrollable = _scrollable;
			Properties.Settings.Default.DisplayHUD = _displayHUD;
			Properties.Settings.Default.DisplayNeighborCount = _displayNeighborCount;
			Properties.Settings.Default.DisplayGrid = _displayGrid;
			Properties.Settings.Default.Inverval = timer.Interval;

			// Model settings
			Properties.Settings.Default.UniverseWidthCellCount = Program.ModelInstance.GridWidth;
			Properties.Settings.Default.UniverseHeightCellCount = Program.ModelInstance.GridHeight;
			Properties.Settings.Default.ToroidalMode = Toroidal;

			// Cell width & height
			Properties.Settings.Default.CellWidth = _cellWidth;
			Properties.Settings.Default.CellHeight = _cellHeight;

			
			// Window state
			if (FormWindowState.Minimized != WindowState) Properties.Settings.Default.WindowState = WindowState;

			Properties.Settings.Default.Save();
		}

		// Back color button event
		private void backColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = graphicsPanel1.BackColor;

				if (DialogResult.OK == cdlg.ShowDialog())
					graphicsPanel1.BackColor = cdlg.Color;
			}
		}

		// Cell color button event
		private void cellColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = cellColor;

				if (DialogResult.OK == cdlg.ShowDialog())
					cellColor = cdlg.Color;

				graphicsPanel1.Invalidate();
			}
		}

		// Grid color button event
		private void gridColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = gridColor;

				if (DialogResult.OK == cdlg.ShowDialog())
					gridColor = cdlg.Color;

				graphicsPanel1.Invalidate();
			}
		}

		// Grid X10 color button event
		private void gridX10ColorToolStripMenuItem_Click(object sender, EventArgs e) {
			using (ColorDialog cdlg = new ColorDialog()) {
				cdlg.Color = grid10Color;

				if (DialogResult.OK == cdlg.ShowDialog())
					grid10Color = cdlg.Color;

				graphicsPanel1.Invalidate();
			}
		}

		// Options button event
		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			using (OptionsDialog odlg = new OptionsDialog(timer.Interval, Program.ModelInstance.GridWidth, Program.ModelInstance.GridHeight, _scrollable, _cellWidth, _cellHeight, graphicsPanel1)) {

				odlg.Apply += OptionsApplyHandler;

				if (DialogResult.OK == odlg.ShowDialog()) {
					SaveOptions(this, odlg.Interval, odlg.UWidth, odlg.UHeight, odlg.Scrollable, odlg.CWidth, odlg.CHeight);
				}
			}
		}

		// Saving software options dialog data
		private void SaveOptions(object sender, decimal interval, decimal uWidth, decimal uHeight, bool scrollable, decimal cWidth, decimal cHeight) {
			timer.Interval = (int)interval;
			
			if (Program.ModelInstance.GridWidth != uWidth || Program.ModelInstance.GridHeight != uHeight) {
				// Pausing universe
				pauseToolStripButton_Click(sender, EventArgs.Empty);
				Program.ModelInstance.GridWidth = (int)uWidth;
				Program.ModelInstance.GridHeight = (int)uHeight;
				Program.ModelInstance.Reset();
			}
			if (_scrollable = scrollable) {
				_cellWidth = cWidth;
				_cellHeight = cHeight;
			}
			graphicsPanel1.Invalidate();
		}

		public void OptionsApplyHandler(object sender, OptionsDialog.OptionsApplyEventArgs e) {
			SaveOptions(sender, e.Interval, e.UWidth, e.UHeight, e.Scrollable, e.CWidth, e.CHeight);
		}

		// Save button event
		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			using (SaveFileDialog sdlg = new SaveFileDialog()) {
				// Pausing universe
				pauseToolStripButton_Click(sender, e);

				sdlg.Filter = "All Files|*.*|Cells|*.cells";
				sdlg.FilterIndex = 2;

				if (DialogResult.OK == sdlg.ShowDialog()) {
					try {
						File.WriteAllText(sdlg.FileName, Utility.ModelToString(Program.ModelInstance));
					}
					catch (IOException err) {
						MessageBox.Show(err.Message, "Error saving!", MessageBoxButtons.OK);
					}
				}
			}
		}

		// Open handler
		private string OpenFileDialogAndPattern() {
			using (OpenFileDialog odlg = new OpenFileDialog()) {
				string pattern = null;

				odlg.Filter = "All Files|*.*|Cells|*.cells";
				odlg.FilterIndex = 2;

				if (DialogResult.OK == odlg.ShowDialog()) {
					try {
						pattern = File.ReadAllText(odlg.FileName);
					}
					catch (IOException err) {
						MessageBox.Show(err.Message, "Error importing!", MessageBoxButtons.OK);
					}
				}

				return pattern;
			}
		}

		// Open button event
		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			// Pausing universe
			pauseToolStripButton_Click(sender, e);

			string pattern = OpenFileDialogAndPattern();
			if (null != pattern && string.Empty != pattern) {
				List<CellPoint> data = Utility.PatternToList(pattern);
				Program.ModelInstance.GridWidth = data.Max(cell => cell._x) + 1;
				Program.ModelInstance.GridHeight = data.Max(cell => cell._y) + 1;
				Program.ModelInstance.Reset();
				Program.ModelInstance.Load(data);
				graphicsPanel1.Invalidate();
			}
		}

		// Import button event
		private void importToolStripMenuItem_Click(object sender, EventArgs e) {
			// Pausing universe
			pauseToolStripButton_Click(sender, e);

			DialogResult res = MessageBox.Show("Would you like to import a Lexicon pattern?", "Import", MessageBoxButtons.YesNoCancel);

			string pattern = null;
			if (DialogResult.Yes == res)
				// Importing from Life Lexicon patterns menu
				using (LexiconDialog ldlg = new LexiconDialog()) {
					if (!ldlg.IsDisposed && DialogResult.OK == ldlg.ShowDialog()) {
						pattern = ldlg.SelectedPattern;
					}
				}
			else if (DialogResult.No == res) {
				// Importing from file
				pattern = OpenFileDialogAndPattern();
			}

			// Loading pattern into universe
			if (null != pattern) {
				using (PositionDialog pdlg = new PositionDialog(Program.ModelInstance.GridWidth, Program.ModelInstance.GridHeight)) {
					if (DialogResult.OK == pdlg.ShowDialog()) {
						Program.ModelInstance.Load(Utility.PatternToList(pattern), (int)pdlg.X, (int)pdlg.Y);
						graphicsPanel1.Invalidate();
					}
				}
			}
		}
	}
}
