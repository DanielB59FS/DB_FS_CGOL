using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public interface IDataModel<T> {
		T this[uint i, uint j] { get; set; }
		void CountNeighborsFinite(int x, int y);
		void CountNeighborsToroidal(int x, int y);
		void NextGeneration();
	}
}
