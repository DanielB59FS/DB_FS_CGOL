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
		private QuadTree<RectangleBoundary, CellPoint> _universe = null;

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
			_universe = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = GridWidth, _h = GridHeight }, (list) => list.Count < 10);

			Generation = Alive = 0;

			for (int x = 0; x < GridWidth; ++x)
				for (int y = 0; y < GridHeight; ++y)
					_universe.Insert(new CellPoint(x, y));
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
				if (this[x,y]._isAlive != cell._isAlive)
					ToggleCell(x, y);
			}
		}

		public CellPoint this[int i, int j] {
			get => _universe.Query((data) => i == data._x && j == data._y)[0];
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

		// Updating the neighbor count of cells around a given cell & state
		public void UpdateNeighbors(CellPoint cell) {
			if (IsToroidal)
				UpdateNeighborsToroidal(cell);
			else
				UpdateNeighborsFinite(cell);
		}

		// Updating the neighbor count of cells around a given cell & state
		public void UpdateNeighbors(int x, int y) {
			UpdateNeighbors(this[x, y]);
		}

		public void UpdateNeighborsToroidal(CellPoint cell) {
			int xLen = GridWidth;
			int yLen = GridHeight;

			for (int yOffset = -1; yOffset <= 1; ++yOffset) {
				for (int xOffset = -1; xOffset <= 1; ++xOffset) {
					int xCheck = cell._x + xOffset;
					int yCheck = cell._y + yOffset;

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

					if (cell._isAlive == true)
						++this[xCheck, yCheck]._neighbors;
					else
						--this[xCheck, yCheck]._neighbors;
				}
			}
		}

		public void UpdateNeighborsToroidal(int x, int y) {
			UpdateNeighborsToroidal(this[x, y]);
		}

		public void UpdateNeighborsFinite(CellPoint cell) {
			foreach (CellPoint neighbor in _universe.Query(new RectangleBoundary() { _x = cell._x - 1, _y = cell._y - 1, _w = 3, _h = 3 })) {
				if (cell == neighbor) continue;
				if (cell._isAlive == true)
					++neighbor._neighbors;
				else
					--neighbor._neighbors;
			}
		}

		public void UpdateNeighborsFinite(int x, int y) {
			UpdateNeighborsFinite(this[x, y]);

			//int xLen = GridWidth;
			//int yLen = GridHeight;

			//for (int yOffset = -1; yOffset <= 1; ++yOffset)
			//	for (int xOffset = -1; xOffset <= 1; ++xOffset) {
			//		int xCheck = x + xOffset;
			//		int yCheck = y + yOffset;

			//		// if xOffset and yOffset are both equal to 0 then continue
			//		if (0 == xOffset && 0 == yOffset) continue;

			//		// if xCheck is less than 0 then continue
			//		if (xCheck < 0) continue;

			//		// if yCheck is less than 0 then continue
			//		if (yCheck < 0) continue;

			//		// if xCheck is greater than or equal too xLen then continue
			//		if (xLen <= xCheck) continue;

			//		// if yCheck is greater than or equal too yLen then continue
			//		if (yLen <= yCheck) continue;

			//		if (this[x, y]._isAlive == true)
			//			++this[xCheck, yCheck]._neighbors;
			//		else
			//			--this[xCheck, yCheck]._neighbors;
			//	}
		}

		// Toggle cell state
		public void ToggleCell(int x, int y) {
			CellPoint cell = this[x, y];
			if (cell._isAlive = !cell._isAlive)
				++Program.ModelInstance.Alive;
			else
				--Program.ModelInstance.Alive;
			UpdateNeighbors(cell);
		}

		// Calculating the next generation of the universe
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
