using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public class GridDataModel : IDataModel<CellPoint> {
		private CellPoint[,] _universe = null;
		private CellPoint[,] _sketch = null;
		private CellPoint[,] _temp = null;

		public int GridWidth { get; set; }
		public int GridHeight { get; set; }

		public BigInteger Generation { get; set; } = 0;
		public BigInteger Alive { get; set; } = 0;

		public GridDataModel(int n, int m) {
			GridWidth = n;
			GridHeight = m;
			Reset();
		}

		public void Reset() {
			_universe = new CellPoint[GridWidth, GridHeight];
			_sketch = new CellPoint[GridWidth, GridHeight];
			_temp = new CellPoint[GridWidth, GridHeight];

			Generation = Alive = 0;

			for (int i = 0; i < _universe.GetLength(0); ++i)
				for (int j = 0; j < _universe.GetLength(1); ++j)
					_temp[i,j] = _sketch[i,j] = _universe[i, j] = new CellPoint(i, j);
		}

		public CellPoint this[int i, int j] {
			get => _universe [i, j];
			set => _universe[i, j] = value;
		}

		public void GenerateCells(int seed) {
			Random prng = new Random(seed);
			// TODO: implement
		}

		public void CountNeighborsFinite(int x, int y) {
			int count = 0;
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

					if (_universe[xCheck, yCheck]._isAlive == true) ++count;
				}

			_universe[x, y]._neighbors = count;
		}

		public void CountNeighborsToroidal(int x, int y) {
			int count = 0;
			int xLen = _universe.GetLength(0);
			int yLen = _universe.GetLength(1);

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

					if (_universe[xCheck, yCheck]._isAlive == true) ++count;
				}

			_universe[x, y]._neighbors = count;
		}

		public void CountNeighbors(bool toroidal) {
			foreach (CellPoint p in _universe)
				CountNeighbors(p._x, p._y, toroidal);
		}

		public void CountNeighbors(int i, int j, bool toroidal) {
			if (toroidal)
				CountNeighborsToroidal(i, j);
			else
				CountNeighborsFinite(i, j);
		}

		public void UpdateNeighbors(int i, int j, bool toroidal) {
			if (toroidal)
				UpdateNeighborsToroidal(i, j, _sketch);
			else
				UpdateNeighborsFinite(i, j);
		}

		public void UpdateNeighborsToroidal(int x, int y, CellPoint[,] destination) {
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
						++destination[xCheck, yCheck]._neighbors;
					else
						--destination[xCheck, yCheck]._neighbors;
				}
			}
		}

		public void UpdateNeighborsFinite(int i, int j) {
			//
		}

		public void ToggleCell(int x, int y) {
			if (_universe[x,y]._isAlive = !_universe[x, y]._isAlive)
				++Program.ModelInstance.Alive;
			else
				--Program.ModelInstance.Alive;
			UpdateNeighborsToroidal(x, y, _universe);
		}

		// Calculate the next generation of cells
		public void NextGeneration() {
			// Checking for neighbors
			//CountNeighbors(true);

			// Generating the next generation data
			for (int i = 0; i < _universe.GetLength(0); ++i) {
				for (int j = 0; j < _universe.GetLength(1); ++j) {
					CellPoint cell = _universe[i, j];
					if (!cell._isAlive && 3 == cell._neighbors) {
						cell._isAlive = true;
						++Alive;
					}
					else if ((cell._isAlive && cell._neighbors < 2) || (cell._isAlive && 3 < cell._neighbors)) {
						cell._isAlive = false;
						--Alive;
					}
					_sketch[i, j] = cell;
					UpdateNeighborsToroidal(i, j, _sketch);
					//UpdateNeighborsToroidal(i, j, _sketch);
					//_sketch[i, j] = cell;
					//_sketch[i, j] = new CellPoint(cell);
				}
			}

			// Swapping the universe and sketch grids
			//var temp = _universe;
			_universe = _sketch;
			_sketch = _temp.Clone() as CellPoint[,];

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
	}
}
