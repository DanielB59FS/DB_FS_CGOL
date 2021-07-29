using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public class QuadTree <TBoundary, TData> : IEnumerable<TData> where TBoundary : IBoundary<TData> {
		private TBoundary _boundary;
		private Predicate<List<TData>> _isSatisfy;
		private List<TData> _elements;
		private bool _isDivided;
		private QuadTree<TBoundary, TData> _nw, _ne, _sw, _se;
		public QuadTree(TBoundary boundary, Predicate<List<TData>> condition) {
			_boundary = boundary;
			_isSatisfy = condition;
			_elements = new List<TData>();
			_isDivided = false;
		}
		public bool Contains(TData element) {
			return _boundary.Contains(element);
		}
		public bool Insert(TData element) {
			if (!Contains(element)) return false;
			if (_isSatisfy(_elements)) {
				_elements.Add(element);
				return true;
			}
			else {
				if (!_isDivided)
					Subdivide();
				if (_nw.Insert(element)) return true;
				if (_ne.Insert(element)) return true;
				if (_sw.Insert(element)) return true;
				if (_se.Insert(element)) return true;
				return false;
			}
		}
		public void Subdivide() {
			_nw = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetNWReigon(), _isSatisfy);
			_ne = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetNEReigon(), _isSatisfy);
			_sw = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetSWReigon(), _isSatisfy);
			_se = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetSEReigon(), _isSatisfy);
			_isDivided = true;
		}
		public List<TData> Query(Predicate<TData> match) {
			List<TData> found = new List<TData>();
			found.AddRange(_elements.FindAll(match));
			if (_isDivided) {
				found.AddRange(_nw.Query(match));
				found.AddRange(_ne.Query(match));
				found.AddRange(_sw.Query(match));
				found.AddRange(_se.Query(match));
			}
			return found;
		}
		public List<TData> Query(TBoundary boundary) {
			List<TData> found = new List<TData>();
			if (!_boundary.Intersects(boundary))
				return found;
			else {
				foreach (TData element in _elements) {
					if (boundary.Contains(element))
						found.Add(element);
				}
				if (_isDivided) {
					found.AddRange(_nw.Query(boundary));
					found.AddRange(_ne.Query(boundary));
					found.AddRange(_sw.Query(boundary));
					found.AddRange(_se.Query(boundary));
				}
			}
			return found;
		}

		public IEnumerator<TData> GetEnumerator() {
			foreach (TData element in _elements) yield return element;
			if (_isDivided) {
				foreach (TData element in _nw) yield return element;
				foreach (TData element in _ne) yield return element;
				foreach (TData element in _sw) yield return element;
				foreach (TData element in _se) yield return element;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
