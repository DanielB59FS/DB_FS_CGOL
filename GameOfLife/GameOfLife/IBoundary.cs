using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public interface IBoundary<T> {
		IBoundary<T> GetNWReigon();
		IBoundary<T> GetNEReigon();
		IBoundary<T> GetSWReigon();
		IBoundary<T> GetSEReigon();
		bool Contains(T element);
		bool Intersects(IBoundary<T> boundary);
	}
}
