using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {

	/// <summary>
	/// Grid data model for the game of life functionality
	/// </summary>
	public class GridDataModel : IDataModel<CellPoint> {

		// Data
		private CellPoint[,] _universe = null;

		private bool _isToroidal;
		public bool IsToroidal {
			get => _isToroidal;
			set {
				_isToroidal = value;
				if (0 != Alive) {
					foreach (CellPoint cell in _universe) cell._neighbors = 0;
					foreach (CellPoint cell in _universe) if (cell._isAlive) UpdateNeighbors(cell._x, cell._y);
				}
			}
		}
		public int GridWidth { get; set; }
		public int GridHeight { get; set; }

		public BigInteger Generation { get; set; } = 0;
		public BigInteger Alive { get; set; } = 0;

		// Resetting the model to a clean universe
		public void Reset() {
			_universe = new CellPoint[GridWidth, GridHeight];

			Generation = Alive = 0;

			for (int i = 0; i < _universe.GetLength(0); ++i)
				for (int j = 0; j < _universe.GetLength(1); ++j)
					_universe[i, j] = new CellPoint(i, j);
		}

		// Loading a grid pattern into the universe with selected offset
		public void Load(List<CellPoint> data, int offsetX = 0, int offsetY = 0) {
			foreach (CellPoint cell in data) {
				int x = cell._x + offsetX, y = cell._y + offsetY;
				if (IsToroidal) {
					x %= GridWidth;
					y %= GridHeight;
				}
				if (x < 0 || x >= GridWidth || y < 0 || y >= GridHeight) continue;
				if (_universe[x, y]._isAlive != cell._isAlive)
					ToggleCell(x, y);
			}
		}

		public CellPoint this[int i, int j] {
			get => _universe [i, j];
			set => _universe[i, j] = value;
		}

		// Randomly changing cell's state
		public void GenerateCells(int seed) {
			Random prng = new Random(seed);

			foreach (CellPoint cell in _universe) {
				if (0 == prng.Next(2)) {
					cell._isAlive = true;
					++Alive;
					UpdateNeighbors(cell._x, cell._y);
				}
				else
					cell._isAlive = false;
			}
		}

		// Updating the neighbor count of cells around a given cell & state
		public void UpdateNeighbors(int x, int y) {
			if (IsToroidal)
				UpdateNeighborsToroidal(x, y);
			else
				UpdateNeighborsFinite(x, y);
		}

		public void UpdateNeighborsToroidal(int x, int y) {
			int xLen = _universe.GetLength(0);
			int yLen = _universe.GetLength(1);

			for (int yOffset = -1; yOffset <= 1; ++yOffset) {
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

					if (_universe[x, y]._isAlive == true)
						++_universe[xCheck, yCheck]._neighbors;
					else
						--_universe[xCheck, yCheck]._neighbors;
				}
			}
		}

		public void UpdateNeighborsFinite(int x, int y) {
			int xLen = _universe.GetLength(0);
			int yLen = _universe.GetLength(1);

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

					if (_universe[x, y]._isAlive == true)
						++_universe[xCheck, yCheck]._neighbors;
					else
						--_universe[xCheck, yCheck]._neighbors;
				}
		}

		// Toggle cell state
		public void ToggleCell(int x, int y) {
			if (_universe[x,y]._isAlive = !_universe[x, y]._isAlive)
				++Program.ModelInstance.Alive;
			else
				--Program.ModelInstance.Alive;
			UpdateNeighbors(x, y);
		}

		// Calculate the next generation of cells
		public void NextGeneration() {

			// Generating the next generation data
			List<CellPoint> delta = new List<CellPoint>();
			foreach (CellPoint cell in _universe)
				if (!cell._isAlive && 3 == cell._neighbors) {
					cell._isAlive = true;
					++Alive;
					delta.Add(cell);
				}
				else if ((cell._isAlive && cell._neighbors < 2) || (cell._isAlive && 3 < cell._neighbors)) {
					cell._isAlive = false;
					--Alive;
					delta.Add(cell);
				}
			// Since I'm only updating the neighbor count after updating the cell's state I avoid having to maintain a sketch universe
			foreach (CellPoint cell in delta) UpdateNeighbors(cell._x, cell._y);

			// Increment generation count
			++Generation;
		}

		public IEnumerator<CellPoint> GetEnumerator() {
			for (int i = 0; i < _universe.GetLength(0); ++i)
				for (int j = 0; j < _universe.GetLength(1); ++j)
					yield return _universe[i, j];
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public IEnumerable<CellPoint> Query(RectangleBoundary rect) {
			List<CellPoint> points = new List<CellPoint>();
			for (int x = (int)rect._x; x < rect._x + rect._w; ++x)
				for (int y = (int)rect._y; y < rect._y + rect._h; ++y)
					if (x < GridWidth && y < GridWidth)
						points.Add(_universe[x, y]);
			return points;
		}
	}
}
