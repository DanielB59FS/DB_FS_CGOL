using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public interface IDataModel<T> : IEnumerable<T> {
		bool IsToroidal { get; set; }
		int GridWidth { get; set; }
		int GridHeight { get; set; }
		BigInteger Generation { get; set; }
		BigInteger Alive { get; set; }
		void Reset();
		void Load(List<T> data, int offsetX = 0, int offsetY = 0);
		T this[int i, int j] { get; }
		void UpdateNeighbors(int x, int y);
		void ToggleCell(int x, int y);
		void NextGeneration();
		void GenerateCells(int seed);
		IEnumerable<T> Query(RectangleBoundary rect);
	}
}
