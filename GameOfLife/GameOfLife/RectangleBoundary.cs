using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	class CellPoint {
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
		public CellPoint(CellPoint p) : this(p._x, p._y, p._isAlive) {
			_neighbors = p._neighbors;
		}
	}
	class RectangleBoundary : IBoundary<CellPoint> {
		public int _x, _y, _w, _h;

		public IBoundary<CellPoint> GetNEReigon() {
			return new RectangleBoundary() { _x = _x + _w / 2, _y = _y, _w = _w / 2, _h = _h / 2 };
		}

		public IBoundary<CellPoint> GetNWReigon() {
			return new RectangleBoundary() { _x = _x, _y = _y, _w = _w / 2, _h = _h / 2 };
		}

		public IBoundary<CellPoint> GetSEReigon() {
			return new RectangleBoundary() { _x = _x + _w / 2, _y = _y + _h / 2, _w = _w / 2, _h = _h / 2 };
		}

		public IBoundary<CellPoint> GetSWReigon() {
			return new RectangleBoundary() { _x = _x, _y = _y + _h / 2, _w = _w / 2, _h = _h / 2 };
		}

		public bool Contains(CellPoint point) {
			return point._x >= _x && point._x <= _x + _w && point._y <= _y + _h && point._y >= _y;
		}

		public bool Intersects(IBoundary<CellPoint> boundary) { // TODO: find a better generic solution
			RectangleBoundary rect = (RectangleBoundary)boundary;
			if (rect._x - rect._w > _x + _w || rect._x + rect._w < _x - _w || rect._y - rect._h > _y + _h || rect._y + rect._h < _y - _h) return false;
			else
				return true;
		}
	}
}
