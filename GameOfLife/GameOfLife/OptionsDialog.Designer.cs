
namespace GameOfLife {
	partial class OptionsDialog {
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
			this.uHeightLabel = new System.Windows.Forms.Label();
			this.uWidthLabel = new System.Windows.Forms.Label();
			this.timerLabel = new System.Windows.Forms.Label();
			this.timerIntervalUpDown = new System.Windows.Forms.NumericUpDown();
			this.uWidthUpDown = new System.Windows.Forms.NumericUpDown();
			this.uHeightUpDown = new System.Windows.Forms.NumericUpDown();
			this.optionsGroupBox = new System.Windows.Forms.GroupBox();
			this.cellHeightUpDown = new System.Windows.Forms.NumericUpDown();
			this.cellWidthUpDown = new System.Windows.Forms.NumericUpDown();
			this.cellHeightLabel = new System.Windows.Forms.Label();
			this.cellWidthLabel = new System.Windows.Forms.Label();
			this.scrollableCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.timerIntervalUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uWidthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uHeightUpDown)).BeginInit();
			this.optionsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cellHeightUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cellWidthUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// uHeightLabel
			// 
			this.uHeightLabel.AutoSize = true;
			this.uHeightLabel.Location = new System.Drawing.Point(105, 88);
			this.uHeightLabel.Name = "uHeightLabel";
			this.uHeightLabel.Size = new System.Drawing.Size(117, 13);
			this.uHeightLabel.TabIndex = 2;
			this.uHeightLabel.Text = "Universe Height (Cells):";
			// 
			// uWidthLabel
			// 
			this.uWidthLabel.AutoSize = true;
			this.uWidthLabel.Location = new System.Drawing.Point(108, 61);
			this.uWidthLabel.Name = "uWidthLabel";
			this.uWidthLabel.Size = new System.Drawing.Size(114, 13);
			this.uWidthLabel.TabIndex = 1;
			this.uWidthLabel.Text = "Universe Width (Cells):";
			// 
			// timerLabel
			// 
			this.timerLabel.AutoSize = true;
			this.timerLabel.Location = new System.Drawing.Point(79, 34);
			this.timerLabel.Name = "timerLabel";
			this.timerLabel.Size = new System.Drawing.Size(143, 13);
			this.timerLabel.TabIndex = 0;
			this.timerLabel.Text = "Timer Interval in Miliseconds:";
			// 
			// timerIntervalUpDown
			// 
			this.timerIntervalUpDown.Location = new System.Drawing.Point(228, 32);
			this.timerIntervalUpDown.Name = "timerIntervalUpDown";
			this.timerIntervalUpDown.Size = new System.Drawing.Size(120, 20);
			this.timerIntervalUpDown.TabIndex = 0;
			this.timerIntervalUpDown.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
			// 
			// uWidthUpDown
			// 
			this.uWidthUpDown.Location = new System.Drawing.Point(228, 59);
			this.uWidthUpDown.Name = "uWidthUpDown";
			this.uWidthUpDown.Size = new System.Drawing.Size(120, 20);
			this.uWidthUpDown.TabIndex = 1;
			this.uWidthUpDown.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
			// 
			// uHeightUpDown
			// 
			this.uHeightUpDown.Location = new System.Drawing.Point(228, 86);
			this.uHeightUpDown.Name = "uHeightUpDown";
			this.uHeightUpDown.Size = new System.Drawing.Size(120, 20);
			this.uHeightUpDown.TabIndex = 2;
			this.uHeightUpDown.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
			// 
			// optionsGroupBox
			// 
			this.optionsGroupBox.Controls.Add(this.cellHeightUpDown);
			this.optionsGroupBox.Controls.Add(this.cellWidthUpDown);
			this.optionsGroupBox.Controls.Add(this.cellHeightLabel);
			this.optionsGroupBox.Controls.Add(this.cellWidthLabel);
			this.optionsGroupBox.Controls.Add(this.scrollableCheckBox);
			this.optionsGroupBox.Controls.Add(this.label1);
			this.optionsGroupBox.Controls.Add(this.buttonCancel);
			this.optionsGroupBox.Controls.Add(this.buttonApply);
			this.optionsGroupBox.Controls.Add(this.buttonOk);
			this.optionsGroupBox.Controls.Add(this.timerLabel);
			this.optionsGroupBox.Controls.Add(this.uHeightUpDown);
			this.optionsGroupBox.Controls.Add(this.uWidthLabel);
			this.optionsGroupBox.Controls.Add(this.uWidthUpDown);
			this.optionsGroupBox.Controls.Add(this.uHeightLabel);
			this.optionsGroupBox.Controls.Add(this.timerIntervalUpDown);
			this.optionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.optionsGroupBox.Location = new System.Drawing.Point(0, 0);
			this.optionsGroupBox.Name = "optionsGroupBox";
			this.optionsGroupBox.Size = new System.Drawing.Size(444, 260);
			this.optionsGroupBox.TabIndex = 6;
			this.optionsGroupBox.TabStop = false;
			this.optionsGroupBox.Text = "Options";
			// 
			// cellHeightUpDown
			// 
			this.cellHeightUpDown.DecimalPlaces = 2;
			this.cellHeightUpDown.Location = new System.Drawing.Point(228, 171);
			this.cellHeightUpDown.Name = "cellHeightUpDown";
			this.cellHeightUpDown.Size = new System.Drawing.Size(120, 20);
			this.cellHeightUpDown.TabIndex = 12;
			this.cellHeightUpDown.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
			// 
			// cellWidthUpDown
			// 
			this.cellWidthUpDown.DecimalPlaces = 2;
			this.cellWidthUpDown.Location = new System.Drawing.Point(228, 148);
			this.cellWidthUpDown.Name = "cellWidthUpDown";
			this.cellWidthUpDown.Size = new System.Drawing.Size(120, 20);
			this.cellWidthUpDown.TabIndex = 11;
			this.cellWidthUpDown.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
			// 
			// cellHeightLabel
			// 
			this.cellHeightLabel.AutoSize = true;
			this.cellHeightLabel.Location = new System.Drawing.Point(161, 173);
			this.cellHeightLabel.Name = "cellHeightLabel";
			this.cellHeightLabel.Size = new System.Drawing.Size(61, 13);
			this.cellHeightLabel.TabIndex = 10;
			this.cellHeightLabel.Text = "Cell Height:";
			// 
			// cellWidthLabel
			// 
			this.cellWidthLabel.AutoSize = true;
			this.cellWidthLabel.Location = new System.Drawing.Point(164, 150);
			this.cellWidthLabel.Name = "cellWidthLabel";
			this.cellWidthLabel.Size = new System.Drawing.Size(58, 13);
			this.cellWidthLabel.TabIndex = 9;
			this.cellWidthLabel.Text = "Cell Width:";
			// 
			// scrollableCheckBox
			// 
			this.scrollableCheckBox.AutoSize = true;
			this.scrollableCheckBox.Location = new System.Drawing.Point(179, 121);
			this.scrollableCheckBox.Name = "scrollableCheckBox";
			this.scrollableCheckBox.Size = new System.Drawing.Size(72, 17);
			this.scrollableCheckBox.TabIndex = 8;
			this.scrollableCheckBox.Text = "Scrollable";
			this.scrollableCheckBox.UseVisualStyleBackColor = true;
			this.scrollableCheckBox.CheckedChanged += new System.EventHandler(this.scrollableCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "label1";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(273, 214);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonApply
			// 
			this.buttonApply.Enabled = false;
			this.buttonApply.Location = new System.Drawing.Point(179, 214);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 4;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(82, 214);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 3;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			// 
			// OptionsDialog
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(444, 260);
			this.Controls.Add(this.optionsGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OptionsDialog";
			((System.ComponentModel.ISupportInitialize)(this.timerIntervalUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uWidthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uHeightUpDown)).EndInit();
			this.optionsGroupBox.ResumeLayout(false);
			this.optionsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cellHeightUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cellWidthUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label uHeightLabel;
		private System.Windows.Forms.Label uWidthLabel;
		private System.Windows.Forms.Label timerLabel;
		private System.Windows.Forms.NumericUpDown timerIntervalUpDown;
		private System.Windows.Forms.NumericUpDown uWidthUpDown;
		private System.Windows.Forms.NumericUpDown uHeightUpDown;
		private System.Windows.Forms.GroupBox optionsGroupBox;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.CheckBox scrollableCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown cellHeightUpDown;
		private System.Windows.Forms.NumericUpDown cellWidthUpDown;
		private System.Windows.Forms.Label cellHeightLabel;
		private System.Windows.Forms.Label cellWidthLabel;
	}
}