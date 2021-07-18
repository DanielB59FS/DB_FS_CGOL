using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	class GridDataModel : IDataModel<CellPoint> {
		private CellPoint[,] _universe = null;
		private CellPoint[,] _sketch = null;

		public BigInteger Generation { get; private set; } = 0;
		public BigInteger Alive { get; private set; } = 0;

		public GridDataModel(int n, int m) {
			_universe = new CellPoint[n, m];
			_sketch = new CellPoint[n, m];
		}

		public CellPoint this[uint i, uint j] {
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

		public void NextGeneration() {
			// Generating the next generation data
			for (int i = 0; i < _universe.GetLength(0); ++i) {
				for (int j = 0; j < _universe.GetLength(1); ++j) {
					CellPoint cell = _universe[i, j];
					if (!cell._isAlive && 3 == cell._neighbors)
						cell._isAlive = true;
					else if ((cell._isAlive && cell._neighbors < 2) || (cell._isAlive && 3 < cell._neighbors))
						cell._isAlive = false;
					_sketch[i, j] = cell;
				}
			}

			// Swapping the universe and sketch grids
			var temp = _universe;
			_universe = _sketch;
			_sketch = temp;

			// Increment generation count
			++Generation;
		}
	}
}
