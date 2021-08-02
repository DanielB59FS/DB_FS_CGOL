using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {

	/// <summary>
	/// Basic generic implementation of a QuadTree
	/// </summary>
	/// <typeparam name="TBoundary"></typeparam>
	/// <typeparam name="TData"></typeparam>
	public class QuadTree <TBoundary, TData> : IDisposable, IEnumerable<TData> where TBoundary : IBoundary<TData> {

		// Data
		private TBoundary _boundary;
		private Predicate<List<TData>> _isSatisfy;
		private List<TData> _elements;
		private bool _isDivided;
		private QuadTree<TBoundary, TData> _nw, _ne, _sw, _se;
		private bool disposedValue;

		public int Count {
			get {
				int count = 0;
				count += _elements.Count;
				if (_isDivided) count += _nw.Count + _ne.Count + _sw.Count + _se.Count;
				return count;
			}
		}

		public QuadTree(TBoundary boundary, Predicate<List<TData>> condition) {
			_boundary = boundary;
			_isSatisfy = condition;
			_elements = new List<TData>();
			_isDivided = false;
		}

		// Is this region responsible for this element
		public bool Contains(TData element) {
			return _boundary.Contains(element);
		}

		// Insertion of new element
		public bool Insert(TData element, Action<TData, TBoundary> action = null) {
			// Does the element belong in this region
			if (!Contains(element)) return false;

			#region New Version
			// Insert & Subdivide
			if (!_isDivided) {
				_elements.Add(element);
				if (null != action) action(element, _boundary);
				if (!_isSatisfy(_elements))
					Subdivide();
				return true;
			}
			else {
				// Insert & Merge
				if (_nw.Insert(element, action)) return true;
				if (_ne.Insert(element, action)) return true;
				if (_sw.Insert(element, action)) return true;
				if (_se.Insert(element, action)) return true;
				return false;
			}
			#endregion

			#region Old Version
			//// Can we still add without subdividing?
			//if (_isSatisfy(_elements)) {
			//	_elements.Add(element);
			//	if (null != action) action(element, _boundary);
			//	return true;
			//}
			//else {
			//	// Subdivide & Insert
			//	if (!_isDivided)
			//		Subdivide();
			//	if (_nw.Insert(element, action)) return true;
			//	if (_ne.Insert(element, action)) return true;
			//	if (_sw.Insert(element, action)) return true;
			//	if (_se.Insert(element, action)) return true;
			//	return false;
			//}
			#endregion
		}

		public void Merge() {
			if (_isDivided && 0 == Count - _elements.Count && _isSatisfy(_elements)) {
				_nw.Dispose();
				_ne.Dispose();
				_sw.Dispose();
				_se.Dispose();
				_isDivided = false;
			}
		}

		// Removal of element
		public int Remove(Predicate<TData> match) {
			int removed = _elements.RemoveAll(match);
			if (_isDivided) {
				removed += _nw.Remove(match);
				removed += _ne.Remove(match);
				removed += _sw.Remove(match);
				removed += _se.Remove(match);
			}
			if (0 < removed) Merge();
			return removed;
		}

		// Removal of element
		public int Remove(Predicate<TBoundary> verify, Predicate<TData> match) {
			int removed = 0;
			if (!verify(_boundary)) return removed;

			removed = _elements.RemoveAll(match);
			if (_isDivided) {
				removed += _nw.Remove(verify, match);
				removed += _ne.Remove(verify, match);
				removed += _sw.Remove(verify, match);
				removed += _se.Remove(verify, match);
			}
			if (0 < removed) Merge();
			return removed;
		}

		// Subdivide region into sub-regions
		public void Subdivide() {
			_nw = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetNWReigon(), _isSatisfy);
			_ne = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetNEReigon(), _isSatisfy);
			_sw = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetSWReigon(), _isSatisfy);
			_se = new QuadTree<TBoundary, TData>((TBoundary)_boundary.GetSEReigon(), _isSatisfy);
			_isDivided = true;
		}

		// Returning all elements that meet the predicate
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

		// Returning all elements contained within a given boundary/region and optional predicate
		public List<TData> Query(TBoundary boundary, Predicate<TData> match = null) {
			List<TData> found = new List<TData>();
			if (!_boundary.Intersects(boundary))
				return found;
			else {
				foreach (TData element in _elements) {
					if (boundary.Contains(element))
						if (null != match) {
							if (match(element))
								found.Add(element);
						}
						else
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

		// Iterating over all elements
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

		protected virtual void Dispose(bool disposing) {
			if (!disposedValue) {
				if (disposing && _isDivided) {
					_nw.Dispose();
					_ne.Dispose();
					_sw.Dispose();
					_se.Dispose();
				}

				_elements = null; _nw = _ne = _sw = _se = null;
				disposedValue = true;
			}
		}

		~QuadTree() {
			Dispose(disposing: false);
		}

		public void Dispose() {
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
