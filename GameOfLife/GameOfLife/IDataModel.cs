using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public interface IDataModel<T> : IEnumerable<T> {
		int GridWidth { get; set; }
		int GridHeight { get; set; }
		BigInteger Generation { get; set; }
		BigInteger Alive { get; set; }
		void Reset();
		T this[int i, int j] { get; set; }
		void CountNeighbors(bool toroidal);
		void CountNeighbors(int i, int j, bool toroidal);
		void UpdateNeighbors(int i, int j, bool toroidal);
		void ToggleCell(int x, int y);
		void NextGeneration();
	}
}
