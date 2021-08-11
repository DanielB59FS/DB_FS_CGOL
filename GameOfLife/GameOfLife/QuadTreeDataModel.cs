using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {

	/// <summary>
	/// QuadTree data model for the game of life functionality
	/// </summary>
	public class QuadTreeDataModel : IDataModel<CellPoint> {

		// Data
		private QuadTree<RectangleBoundary, CellPoint> _universe = null, _sketch = null;
		private CellPoint[,] _grid = null;

		private bool _isToroidal;
		public bool IsToroidal {
			get => _isToroidal;
			set {
				_isToroidal = value;
				if (0 != Alive) {
					foreach (CellPoint cell in _grid) cell._neighbors = 0;
					foreach (CellPoint cell in _grid) if (cell._isAlive) UpdateNeighbors(cell._x, cell._y);
				}
			}
		}
		public int GridWidth { get; set; }
		public int GridHeight { get; set; }

		public BigInteger Generation { get; set; } = 0;
		public BigInteger Alive { get; set; } = 0;

		private int _regionRatio = 0;

		// Resetting the model to a clean universe
		public void Reset() {
			_grid = new CellPoint[GridWidth, GridHeight];

			for (int i = 0; i < _grid.GetLength(0); ++i)
				for (int j = 0; j < _grid.GetLength(1); ++j)
					_grid[i, j] = new CellPoint(i, j);

			_regionRatio = Math.Max(10, Math.Max(GridWidth, GridHeight) / 10);

			_universe = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = GridWidth, _h = GridHeight }, (list) => list.Count(cell => cell._isAlive) < _regionRatio);
			_sketch = null;

			Generation = Alive = 0;
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
				if (_grid[x, y]._isAlive != cell._isAlive)
					ToggleCell(x, y);
			}
		}

		public CellPoint this[int i, int j] {
			get => _grid[i, j];
		}

		// Randomly changing cell's state
		public void GenerateCells(int seed) {
			Random prng = new Random(seed);
			if (0 != _universe.Count)
				_universe = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = GridWidth, _h = GridHeight }, (list) => list.Count(cell => cell._isAlive) < _regionRatio);

			foreach (CellPoint cell in _grid) {
				if (0 == prng.Next(2))
					if (!cell._isAlive) ToggleCell(cell);
			}
		}

		#region Previous Version
		//public void CountNeighborsFinite(int x, int y) {
		//	int count = 0;
		//	RectangleBoundary boundaryCheck = new RectangleBoundary() { _x = x - 1, _y = y - 1, _w = 3, _h = 3 };
		//	List<CellPoint> cells = _universe.Query(boundaryCheck);
		//	CellPoint selectedCell = cells.Find((cell) => x == cell._x && y == cell._y);
		//	cells.Remove(selectedCell);
		//	foreach (CellPoint cell in cells) if (cell._isAlive) ++selectedCell._neighbors;
		//}
		#endregion

		public void UpdateNeighbors(int x, int y) {
			if (0 == _grid[x, y]._neighbors) {
				if (_grid[x, y]._isAlive)
					_universe.Insert(_grid[x, y], (c, b) => c.Boundary = b);
				else
					_universe.Remove(b => b.Contains(_grid[x, y]), cell => cell._x == x && cell._y == y);
			}

			if (IsToroidal)
				UpdateNeighborsToroidal(x, y);
			else
				UpdateNeighborsFinite(x, y);
		}

		public void UpdateNeighborsToroidal(int x, int y) {
			int xLen = GridWidth;
			int yLen = GridHeight;

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

					if (0 == _grid[xCheck,yCheck]._neighbors)
						_universe.Insert(_grid[xCheck, yCheck], (c, b) => c.Boundary = b);

					if (_grid[x, y]._isAlive == true)
						++_grid[xCheck, yCheck]._neighbors;
					else
						--_grid[xCheck, yCheck]._neighbors;

					if (!_grid[xCheck, yCheck]._isAlive && 0 == _grid[xCheck, yCheck]._neighbors) _universe.Remove(b => b.Contains(_grid[xCheck, yCheck]), cell => cell._x == xCheck && cell._y == yCheck);
				}
			}
		}

		public void UpdateNeighborsFinite(int x, int y) {
			int xLen = GridWidth;
			int yLen = GridHeight;

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

					if (0 == _grid[xCheck, yCheck]._neighbors)
						_universe.Insert(_grid[xCheck, yCheck], (c, b) => c.Boundary = b);

					if (_grid[x, y]._isAlive == true)
						++_grid[xCheck, yCheck]._neighbors;
					else
						--_grid[xCheck, yCheck]._neighbors;

					if (!_grid[xCheck, yCheck]._isAlive && 0 == _grid[xCheck, yCheck]._neighbors) _universe.Remove(b => b.Contains(_grid[xCheck, yCheck]), cell => cell._x == xCheck && cell._y == yCheck);
				}
		}

		// Toggle cell state
		public void ToggleCell(int x, int y) {
			if (_grid[x, y]._isAlive = !_grid[x, y]._isAlive)
				++Program.ModelInstance.Alive;
			else
				--Program.ModelInstance.Alive;

			UpdateNeighbors(x, y);
		}

		// Toggle cell state
		public void ToggleCell(CellPoint cell) {
			ToggleCell(cell._x, cell._y);
		}

		// Calculating the next generation of the universe
		public void NextGeneration() {

			// Generating the next generation data
			//_sketch = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = GridWidth, _h = GridHeight }, (list) => list.Count(cell => cell._isAlive) < _regionRatio);

			List<CellPoint> delta = new List<CellPoint>();
			foreach (CellPoint cell in _universe.ToList()) {
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
				//if (cell._isAlive || 0 != cell._neighbors)
				//	_sketch.Insert(cell, (c, b) => c.Boundary = b);
			}

			//_universe.Dispose();
			//_universe = _sketch;
			//_sketch = null;

			foreach (CellPoint cell in delta) {
				UpdateNeighbors(cell._x, cell._y);
			}

			// Increment generation count
			++Generation;
		}

		public IEnumerator<CellPoint> GetEnumerator() {
			foreach (CellPoint cell in _universe) yield return cell;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public IEnumerable<CellPoint> Query(RectangleBoundary rect, Predicate<CellPoint> match = null) {
			return _universe.Query(rect, match);
		}
	}
}
