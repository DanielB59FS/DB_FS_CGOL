﻿using System;
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
	public struct CellPoint {
		public int _x, _y;
		public int _neighbors;
		public bool _isAlive;
		public CellPoint(int x, int y, bool isAlive = false) {
			_x = x;
			_y = y;
			_neighbors = 0;
			_isAlive = isAlive;
		}
		public CellPoint(Point p, bool isAlive = false) : this(p.X, p.Y, isAlive) { }
	}
	public partial class Form1 : Form {
		// The universe array
		CellPoint[,] universe = new CellPoint[10, 10];
		CellPoint[,] sketch = new CellPoint[10, 10];

		// Drawing colors
		Color gridColor = Color.Black;
		Color cellColor = Color.Gray;

		// The Timer class
		Timer timer = new Timer();

		// Generation count
		BigInteger generations = 0;
		BigInteger _alive = 0;

		// Pesudo Random Number Generator
		Random _prng = new Random(Properties.Settings.Default.Seed);

		private void CountNeighborsFinite(int x, int y) {
			int count = 0;
			int xLen = universe.GetLength(0);
			int yLen = universe.GetLength(1);

			for (int yOffset = -1; yOffset <= 1; ++yOffset)
				for (int xOffset = -1; xOffset <= 1; ++xOffset) {
					int xCheck = x + xOffset;
					int yCheck = y + yOffset;

					// if xOffset and yOffset are both equal to 0 then continue
					if (0 == xOffset && 0 == yOffset) continue;

					// if xCheck is less than 0 then continue
					if (xCheck < 0) continue;

					// if yCheck is less than 0 then continue
					if (yCheck < 0) continue;

					// if xCheck is greater than or equal too xLen then continue
					if (xLen <= xCheck) continue;

					// if yCheck is greater than or equal too yLen then continue
					if (yLen <= yCheck) continue;

					if (universe[xCheck, yCheck]._isAlive == true) ++count;
				}

			universe[x, y]._neighbors = count;
		}

		private void CountNeighborsToroidal(int x, int y) {
			int count = 0;
			int xLen = universe.GetLength(0);
			int yLen = universe.GetLength(1);

			for (int yOffset = -1; yOffset <= 1; ++yOffset)
				for (int xOffset = -1; xOffset <= 1; ++xOffset) {
					int xCheck = x + xOffset;
					int yCheck = y + yOffset;

					// if xOffset and yOffset are both equal to 0 then continue
					if (0 == xOffset && 0 == yOffset) continue;

					// if xCheck is less than 0 then set to xLen - 1
					if (xCheck < 0) xCheck = xLen - 1;

					// if yCheck is less than 0 then set to yLen - 1
					if (yCheck < 0) yCheck = yLen - 1;

					// if xCheck is greater than or equal too xLen then set to 0
					if (xLen <= xCheck) xCheck = 0;

					// if yCheck is greater than or equal too yLen then set to 0
					if (yLen <= yCheck) yCheck = 0;

					if (universe[xCheck, yCheck]._isAlive == true) ++count;
				}

			universe[x, y]._neighbors = count;
		}

		public Form1() {
			InitializeComponent();

			// Temporary
			for (int i = 0; i < universe.GetLength(0); ++i) {
				for (int j = 0; j < universe.GetLength(1); ++j) {
					universe[i, j] = new CellPoint(i, j);
				}
			}

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
			toolStripStatusLabelGenerations.Text = $"Generations: {generations} Interval: {timer.Interval} Alive: {_alive} Seed: {Properties.Settings.Default.Seed}";
		}

		// The event called by the timer every Interval milliseconds.
		private void Timer_Tick(object sender, EventArgs e) {
			NextGeneration();
		}

		private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {
			_alive = 0;
			
			// Checking for neighbors
			foreach (CellPoint p in universe)
				CountNeighborsToroidal(p._x, p._y);

			// Calculate the width and height of each cell in pixels
			// CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
			float cellWidth = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
			// CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
			float cellHeight = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);

			// A Pen for drawing the grid lines (color, width)
			Pen gridPen = new Pen(gridColor, 1);

			// A Brush for filling living cells interiors (color)
			SolidBrush cellBrush = new SolidBrush(cellColor);

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
					if (universe[(int)x, (int)y]._isAlive == true) {
						++_alive;
						e.Graphics.FillRectangle(cellBrush, cellRect);
					}

					// Drawing the number of neighbors
					if (0 != universe[(int)x, (int)y]._neighbors) {
						cellBrush.Color = (universe[(int)x, (int)y]._neighbors < 2 || 3 < universe[(int)x, (int)y]._neighbors) ? Color.Red : Color.Green;
						e.Graphics.DrawString(universe[(int)x, (int)y]._neighbors.ToString(), graphicsPanel1.Font, cellBrush, cellRect);
						cellBrush.Color = Color.LightGray;
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
				universe[(int)x, (int)y]._isAlive = !universe[(int)x, (int)y]._isAlive;

				// Tell Windows you need to repaint
				graphicsPanel1.Invalidate();
			}
		}
	}
}
