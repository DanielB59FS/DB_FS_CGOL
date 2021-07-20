using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife {
	static class Program {

		// Application's main data model representing the universe
		private static IDataModel<CellPoint> _model = null;
		public static IDataModel<CellPoint> ModelInstance {
			get {
				if (null == _model)
					if (Properties.Settings.Default.QuadTreeModel)
						_model = new QuadTreeDataModel(Properties.Settings.Default.UniverseWidthCellCount, Properties.Settings.Default.UniverseHeightCellCount);
					else
						_model = new GridDataModel(Properties.Settings.Default.UniverseWidthCellCount, Properties.Settings.Default.UniverseHeightCellCount);
				return _model;
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			//Properties.Settings.Default.Seed = DateTime.Now.Millisecond * DateTime.Now.Second;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
