using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameOfLife {
	public partial class LexiconDialog : Form {
		public class LexiconPattern {
			public string Pattern { get; set; } = string.Empty;
			public string Description { get; set; } = string.Empty;
		}

		private static List<LexiconPattern> _patterns = new List<LexiconPattern>();
		public string SelectedPattern { get => dataGridView1.SelectedRows[0].Cells[0].Value as string; }

		public static bool Loaded = false;
		static LexiconDialog() {
			try {
				string text = File.ReadAllText("lexicon.txt");
				List<string> lines = text.Trim().Split(new char[] { '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
				LexiconPattern pattern = null;
				for (int i = 0; i < lines.Count; ++i) {
					lines[i] = lines[i].Trim();
					if (':' == lines[i][0]) {
						if (null != pattern && string.Empty != pattern.Pattern)
							_patterns.Add(pattern);
						pattern = new LexiconPattern();
					}
					if ('.' == lines[i][0] || 'O' == lines[i][0])
						pattern.Pattern += lines[i] + "\n";
					else
						pattern.Description += lines[i] + "\n";
				}
				Loaded = true;
			}
			catch (IOException e) {
				MessageBox.Show("Error loading LexiconPatterns!", e.Message, MessageBoxButtons.OK);
			}
		}
		public LexiconDialog() {
			InitializeComponent();

			foreach (LexiconPattern pattern in _patterns)
				dataGridView1.Rows.Add(pattern.Pattern, pattern.Description);
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			Console.WriteLine(e.RowIndex);
		}
	}
}
