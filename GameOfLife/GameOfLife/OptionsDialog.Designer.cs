
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
			this.optionsTabControl = new System.Windows.Forms.TabControl();
			this.tabUniversePage = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabMiscPage = new System.Windows.Forms.TabPage();
			this.optionsTabControl.SuspendLayout();
			this.tabUniversePage.SuspendLayout();
			this.SuspendLayout();
			// 
			// optionsTabControl
			// 
			this.optionsTabControl.Controls.Add(this.tabUniversePage);
			this.optionsTabControl.Controls.Add(this.tabMiscPage);
			this.optionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.optionsTabControl.Location = new System.Drawing.Point(0, 0);
			this.optionsTabControl.Name = "optionsTabControl";
			this.optionsTabControl.SelectedIndex = 0;
			this.optionsTabControl.Size = new System.Drawing.Size(800, 450);
			this.optionsTabControl.TabIndex = 0;
			// 
			// tabUniversePage
			// 
			this.tabUniversePage.Controls.Add(this.label3);
			this.tabUniversePage.Controls.Add(this.label2);
			this.tabUniversePage.Controls.Add(this.label1);
			this.tabUniversePage.Location = new System.Drawing.Point(4, 22);
			this.tabUniversePage.Name = "tabUniversePage";
			this.tabUniversePage.Padding = new System.Windows.Forms.Padding(3);
			this.tabUniversePage.Size = new System.Drawing.Size(792, 424);
			this.tabUniversePage.TabIndex = 0;
			this.tabUniversePage.Text = "Universe";
			this.tabUniversePage.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(208, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(207, 195);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(211, 262);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "label3";
			// 
			// tabMiscPage
			// 
			this.tabMiscPage.Location = new System.Drawing.Point(4, 22);
			this.tabMiscPage.Name = "tabMiscPage";
			this.tabMiscPage.Size = new System.Drawing.Size(792, 424);
			this.tabMiscPage.TabIndex = 1;
			this.tabMiscPage.Text = "Misc.";
			this.tabMiscPage.UseVisualStyleBackColor = true;
			// 
			// OptionsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.optionsTabControl);
			this.Name = "OptionsDialog";
			this.Text = "OptionsDialog";
			this.optionsTabControl.ResumeLayout(false);
			this.tabUniversePage.ResumeLayout(false);
			this.tabUniversePage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl optionsTabControl;
		private System.Windows.Forms.TabPage tabUniversePage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabMiscPage;
	}
}