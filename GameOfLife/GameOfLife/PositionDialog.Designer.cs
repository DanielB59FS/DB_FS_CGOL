
namespace GameOfLife {
	partial class PositionDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.labelX = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.xUpDown = new System.Windows.Forms.NumericUpDown();
			this.yUpDown = new System.Windows.Forms.NumericUpDown();
			this.buttonInsert = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(18, 15);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(14, 13);
			this.labelX.TabIndex = 0;
			this.labelX.Text = "X";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(100, 15);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(14, 13);
			this.labelY.TabIndex = 1;
			this.labelY.Text = "Y";
			// 
			// xUpDown
			// 
			this.xUpDown.Location = new System.Drawing.Point(38, 13);
			this.xUpDown.Name = "xUpDown";
			this.xUpDown.Size = new System.Drawing.Size(54, 20);
			this.xUpDown.TabIndex = 0;
			// 
			// yUpDown
			// 
			this.yUpDown.Location = new System.Drawing.Point(120, 13);
			this.yUpDown.Name = "yUpDown";
			this.yUpDown.Size = new System.Drawing.Size(53, 20);
			this.yUpDown.TabIndex = 1;
			// 
			// buttonInsert
			// 
			this.buttonInsert.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonInsert.Location = new System.Drawing.Point(17, 39);
			this.buttonInsert.Name = "buttonInsert";
			this.buttonInsert.Size = new System.Drawing.Size(75, 23);
			this.buttonInsert.TabIndex = 2;
			this.buttonInsert.Text = "Insert";
			this.buttonInsert.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(98, 39);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// PositionDialog
			// 
			this.AcceptButton = this.buttonInsert;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(193, 75);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonInsert);
			this.Controls.Add(this.yUpDown);
			this.Controls.Add(this.xUpDown);
			this.Controls.Add(this.labelY);
			this.Controls.Add(this.labelX);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PositionDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Position";
			((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.NumericUpDown xUpDown;
		private System.Windows.Forms.NumericUpDown yUpDown;
		private System.Windows.Forms.Button buttonInsert;
		private System.Windows.Forms.Button buttonCancel;
	}
}