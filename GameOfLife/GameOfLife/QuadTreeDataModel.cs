using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public class QuadTreeDataModel : IDataModel<CellPoint> {
		private QuadTree<RectangleBoundary, CellPoint> _universe = null;
		private QuadTree<RectangleBoundary, CellPoint> _sketch = null;

		public int GridWidth { get; set; }
		public int GridHeight { get; set; }

		public BigInteger Generation { get; set; } = 0;
		public BigInteger Alive { get; set; } = 0;

		public QuadTreeDataModel(int n, int m) {
			_universe = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = n, _h = m }, (list) => list.Count < 4);
			_sketch = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = n, _h = m }, (list) => list.Count < 4);
		}

		public bool Toroidal { get; set; }

		public void Reset() {
			// TODO: Implement
		}

		public CellPoint this[int i, int j] {
			get => _universe.Query((data) => i == data._x && j == data._y)[0];
			set => _universe.Query((data) => i == data._x && j == data._y)[0] = value;
		}

		public void GenerateCells(int seed) {
			Random prng = new Random(seed);
			// TODO: implement
		}

		public void CountNeighborsFinite(int x, int y) {
			int count = 0;
			RectangleBoundary boundaryCheck = new RectangleBoundary() { _x = x - 1, _y = y - 1, _w = 3, _h = 3 };
			List<CellPoint> cells = _universe.Query(boundaryCheck);
			CellPoint selectedCell = cells.Find((cell) => x == cell._x && y == cell._y);
			cells.Remove(selectedCell);
			foreach (CellPoint cell in cells) if (cell._isAlive) ++selectedCell._neighbors;
		}

		public void UpdateNeighbors(int x, int y, bool toroidal) {
			//
		}

		public void ToggleCell(int x, int y) {
			//
		}

		public void NextGeneration() {
			//
		}

		public IEnumerator<CellPoint> GetEnumerator() {
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			throw new NotImplementedException();
		}
	}
}
