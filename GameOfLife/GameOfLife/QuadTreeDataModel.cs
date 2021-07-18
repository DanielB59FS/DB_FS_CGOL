﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	class QuadTreeDataModel : IDataModel<CellPoint> {
		private QuadTree<RectangleBoundary, CellPoint> _universe = null;
		private QuadTree<RectangleBoundary, CellPoint> _sketch = null;

		public BigInteger Generation { get; private set; } = 0;
		public BigInteger Alive { get; private set; } = 0;

		public QuadTreeDataModel(int n, int m) {
			_universe = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = n, _h = m }, (list) => list.Count < 4);
			_sketch = new QuadTree<RectangleBoundary, CellPoint>(new RectangleBoundary() { _x = 0, _y = 0, _w = n, _h = m }, (list) => list.Count < 4);
		}

		public CellPoint this[uint i, uint j] {
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

		public void CountNeighborsToroidal(int x, int y) {
			//
		}

		public void NextGeneration() {
			//
		}
	}
}
