using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
	public static class Utility {
		
		// Transforming the model's data into string to use for saving
		public static string ModelToString(IDataModel<CellPoint> model) {
			StringBuilder builder = new StringBuilder();

			if (null != model) {
				builder.Append("!" + DateTime.Now.ToString() + "\n");
				for (int x = 0; x < model.GridWidth; ++x) {
					for (int y = 0; y < model.GridHeight; ++y) {
						if (model[x, y]._isAlive)
							builder.Append('O');
						else
							builder.Append('.');
					}
					builder.Append('\n');
				}
			}

			return builder.ToString();
		}

		// Transforming string into model's data type for loading into the model
		public static List<CellPoint> PatternToList(string pattern) {
			int x = 0, y = 0;
			List<CellPoint> result = new List<CellPoint>();

			if (null != pattern && string.Empty != pattern) {

				// Splitting & cleaning up the lines
				string[] lines = pattern.Trim().Split(new char[] { '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

				for (int i = 0; i < lines.Length; ++i) {
					lines[i] = lines[i].Trim();

					if ('!' == lines[i][0]) continue;

					// Checking alive/dead state
					foreach (char symbol in lines[i])
						switch (symbol) {
							case '.':
								result.Add(new CellPoint(x++, y));
								break;
							case 'O':
							case '*':
								result.Add(new CellPoint(x++, y, true));
								break;
						}

					// Preparing next row indices
					x = 0;
					++y;
				}
			}

			return result;
		}
	}
}
