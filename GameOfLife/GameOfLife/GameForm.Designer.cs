
namespace GameOfLife {
	partial class GameForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.neighborCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toroidalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.finiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromSeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromCurrentSeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cellColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridX10ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.playToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.stepToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pauseToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelGenerations = new System.Windows.Forms.ToolStripStatusLabel();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.colorContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cellColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.gridColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.gridX10ColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.viewContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hUDContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.neighborCountContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.graphicsPanel1 = new GameOfLife.GraphicsPanel();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.runToolStripMenuItem,
            this.randomizeToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(584, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "&Open";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.importToolStripMenuItem.Text = "Import";
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hUDToolStripMenuItem,
            this.neighborCountToolStripMenuItem,
            this.gridToolStripMenuItem,
            this.toolStripSeparator4,
            this.toroidalToolStripMenuItem,
            this.finiteToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// hUDToolStripMenuItem
			// 
			this.hUDToolStripMenuItem.Name = "hUDToolStripMenuItem";
			this.hUDToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.hUDToolStripMenuItem.Text = "&HUD";
			this.hUDToolStripMenuItem.Click += new System.EventHandler(this.hUDToolStripMenuItem_Click);
			// 
			// neighborCountToolStripMenuItem
			// 
			this.neighborCountToolStripMenuItem.Name = "neighborCountToolStripMenuItem";
			this.neighborCountToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.neighborCountToolStripMenuItem.Text = "&Neighbor Count";
			this.neighborCountToolStripMenuItem.Click += new System.EventHandler(this.neighborCountToolStripMenuItem_Click);
			// 
			// gridToolStripMenuItem
			// 
			this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
			this.gridToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.gridToolStripMenuItem.Text = "&Grid";
			this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
			// 
			// toroidalToolStripMenuItem
			// 
			this.toroidalToolStripMenuItem.Name = "toroidalToolStripMenuItem";
			this.toroidalToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.toroidalToolStripMenuItem.Text = "&Toroidal";
			this.toroidalToolStripMenuItem.Click += new System.EventHandler(this.toroidalToolStripMenuItem_Click);
			// 
			// finiteToolStripMenuItem
			// 
			this.finiteToolStripMenuItem.Name = "finiteToolStripMenuItem";
			this.finiteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.finiteToolStripMenuItem.Text = "&Finite";
			this.finiteToolStripMenuItem.Click += new System.EventHandler(this.finiteToolStripMenuItem_Click);
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.toolStripSeparator5,
            this.toToolStripMenuItem});
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.runToolStripMenuItem.Text = "&Run";
			// 
			// playToolStripMenuItem
			// 
			this.playToolStripMenuItem.Name = "playToolStripMenuItem";
			this.playToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.playToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.playToolStripMenuItem.Text = "&Play";
			this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripButton_Click);
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Enabled = false;
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.pauseToolStripMenuItem.Text = "P&ause";
			this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripButton_Click);
			// 
			// stepToolStripMenuItem
			// 
			this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
			this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.stepToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.stepToolStripMenuItem.Text = "&Step";
			this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripButton_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(121, 6);
			// 
			// toToolStripMenuItem
			// 
			this.toToolStripMenuItem.Name = "toToolStripMenuItem";
			this.toToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.toToolStripMenuItem.Text = "&To";
			this.toToolStripMenuItem.Click += new System.EventHandler(this.toToolStripMenuItem_Click);
			// 
			// randomizeToolStripMenuItem
			// 
			this.randomizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromSeedToolStripMenuItem,
            this.fromCurrentSeedToolStripMenuItem,
            this.fromTimeToolStripMenuItem});
			this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
			this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
			this.randomizeToolStripMenuItem.Text = "&Randomize";
			// 
			// fromSeedToolStripMenuItem
			// 
			this.fromSeedToolStripMenuItem.Name = "fromSeedToolStripMenuItem";
			this.fromSeedToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.fromSeedToolStripMenuItem.Text = "From &Seed";
			this.fromSeedToolStripMenuItem.Click += new System.EventHandler(this.fromSeedToolStripMenuItem_Click);
			// 
			// fromCurrentSeedToolStripMenuItem
			// 
			this.fromCurrentSeedToolStripMenuItem.Name = "fromCurrentSeedToolStripMenuItem";
			this.fromCurrentSeedToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.fromCurrentSeedToolStripMenuItem.Text = "From &Current Seed";
			this.fromCurrentSeedToolStripMenuItem.Click += new System.EventHandler(this.fromCurrentSeedToolStripMenuItem_Click);
			// 
			// fromTimeToolStripMenuItem
			// 
			this.fromTimeToolStripMenuItem.Name = "fromTimeToolStripMenuItem";
			this.fromTimeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.fromTimeToolStripMenuItem.Text = "From &Time";
			this.fromTimeToolStripMenuItem.Click += new System.EventHandler(this.fromTimeToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backColorToolStripMenuItem,
            this.cellColorToolStripMenuItem,
            this.gridColorToolStripMenuItem,
            this.gridX10ColorToolStripMenuItem,
            this.toolStripSeparator7,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator8,
            this.resetToolStripMenuItem,
            this.reloadToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "&Settings";
			// 
			// backColorToolStripMenuItem
			// 
			this.backColorToolStripMenuItem.Name = "backColorToolStripMenuItem";
			this.backColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.backColorToolStripMenuItem.Text = "&Back Color";
			this.backColorToolStripMenuItem.Click += new System.EventHandler(this.backColorToolStripMenuItem_Click);
			// 
			// cellColorToolStripMenuItem
			// 
			this.cellColorToolStripMenuItem.Name = "cellColorToolStripMenuItem";
			this.cellColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cellColorToolStripMenuItem.Text = "&Cell Color";
			this.cellColorToolStripMenuItem.Click += new System.EventHandler(this.cellColorToolStripMenuItem_Click);
			// 
			// gridColorToolStripMenuItem
			// 
			this.gridColorToolStripMenuItem.Name = "gridColorToolStripMenuItem";
			this.gridColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.gridColorToolStripMenuItem.Text = "&Grid Color";
			this.gridColorToolStripMenuItem.Click += new System.EventHandler(this.gridColorToolStripMenuItem_Click);
			// 
			// gridX10ColorToolStripMenuItem
			// 
			this.gridX10ColorToolStripMenuItem.Name = "gridX10ColorToolStripMenuItem";
			this.gridX10ColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.gridX10ColorToolStripMenuItem.Text = "G&rid x10 Color";
			this.gridX10ColorToolStripMenuItem.Click += new System.EventHandler(this.gridX10ColorToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.resetToolStripMenuItem.Text = "&Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// reloadToolStripMenuItem
			// 
			this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
			this.reloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.reloadToolStripMenuItem.Text = "Re&load";
			this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator6,
            this.playToolStripButton,
            this.stepToolStripButton,
            this.pauseToolStripButton,
            this.toolStripSeparator3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(584, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "&New";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "&Open";
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "&Save";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// playToolStripButton
			// 
			this.playToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.playToolStripButton.Image = global::GameOfLife.Properties.Resources.playbtn;
			this.playToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.playToolStripButton.Name = "playToolStripButton";
			this.playToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.playToolStripButton.Text = "Play";
			this.playToolStripButton.Click += new System.EventHandler(this.playToolStripButton_Click);
			// 
			// stepToolStripButton
			// 
			this.stepToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.stepToolStripButton.Image = global::GameOfLife.Properties.Resources.stepbtn;
			this.stepToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.stepToolStripButton.Name = "stepToolStripButton";
			this.stepToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.stepToolStripButton.Text = "Step";
			this.stepToolStripButton.Click += new System.EventHandler(this.stepToolStripButton_Click);
			// 
			// pauseToolStripButton
			// 
			this.pauseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pauseToolStripButton.Enabled = false;
			this.pauseToolStripButton.Image = global::GameOfLife.Properties.Resources.pausebtn;
			this.pauseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pauseToolStripButton.Name = "pauseToolStripButton";
			this.pauseToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.pauseToolStripButton.Text = "Pause";
			this.pauseToolStripButton.Click += new System.EventHandler(this.pauseToolStripButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGenerations});
			this.statusStrip1.Location = new System.Drawing.Point(0, 539);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(584, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabelGenerations
			// 
			this.toolStripStatusLabelGenerations.Name = "toolStripStatusLabelGenerations";
			this.toolStripStatusLabelGenerations.Size = new System.Drawing.Size(90, 17);
			this.toolStripStatusLabelGenerations.Text = "Generations = 0";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorContextMenuItem,
            this.viewContextMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
			// 
			// colorContextMenuItem
			// 
			this.colorContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backColorToolStripMenuItem1,
            this.cellColorToolStripMenuItem1,
            this.gridColorToolStripMenuItem1,
            this.gridX10ColorToolStripMenuItem1});
			this.colorContextMenuItem.Name = "colorContextMenuItem";
			this.colorContextMenuItem.Size = new System.Drawing.Size(103, 22);
			this.colorContextMenuItem.Text = "&Color";
			// 
			// backColorToolStripMenuItem1
			// 
			this.backColorToolStripMenuItem1.Name = "backColorToolStripMenuItem1";
			this.backColorToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
			this.backColorToolStripMenuItem1.Text = "&Back Color";
			this.backColorToolStripMenuItem1.Click += new System.EventHandler(this.backColorToolStripMenuItem_Click);
			// 
			// cellColorToolStripMenuItem1
			// 
			this.cellColorToolStripMenuItem1.Name = "cellColorToolStripMenuItem1";
			this.cellColorToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
			this.cellColorToolStripMenuItem1.Text = "&Cell Color";
			this.cellColorToolStripMenuItem1.Click += new System.EventHandler(this.cellColorToolStripMenuItem_Click);
			// 
			// gridColorToolStripMenuItem1
			// 
			this.gridColorToolStripMenuItem1.Name = "gridColorToolStripMenuItem1";
			this.gridColorToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
			this.gridColorToolStripMenuItem1.Text = "&Grid Color";
			this.gridColorToolStripMenuItem1.Click += new System.EventHandler(this.gridColorToolStripMenuItem_Click);
			// 
			// gridX10ColorToolStripMenuItem1
			// 
			this.gridX10ColorToolStripMenuItem1.Name = "gridX10ColorToolStripMenuItem1";
			this.gridX10ColorToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
			this.gridX10ColorToolStripMenuItem1.Text = "G&rid x10 Color";
			this.gridX10ColorToolStripMenuItem1.Click += new System.EventHandler(this.gridX10ColorToolStripMenuItem_Click);
			// 
			// viewContextMenuItem
			// 
			this.viewContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hUDContextMenuItem,
            this.neighborCountContextMenuItem,
            this.gridContextMenuItem});
			this.viewContextMenuItem.Name = "viewContextMenuItem";
			this.viewContextMenuItem.Size = new System.Drawing.Size(103, 22);
			this.viewContextMenuItem.Text = "&View";
			// 
			// hUDContextMenuItem
			// 
			this.hUDContextMenuItem.Name = "hUDContextMenuItem";
			this.hUDContextMenuItem.Size = new System.Drawing.Size(160, 22);
			this.hUDContextMenuItem.Text = "&HUD";
			this.hUDContextMenuItem.Click += new System.EventHandler(this.hUDToolStripMenuItem_Click);
			// 
			// neighborCountContextMenuItem
			// 
			this.neighborCountContextMenuItem.Name = "neighborCountContextMenuItem";
			this.neighborCountContextMenuItem.Size = new System.Drawing.Size(160, 22);
			this.neighborCountContextMenuItem.Text = "&Neighbor Count";
			this.neighborCountContextMenuItem.Click += new System.EventHandler(this.neighborCountToolStripMenuItem_Click);
			// 
			// gridContextMenuItem
			// 
			this.gridContextMenuItem.Name = "gridContextMenuItem";
			this.gridContextMenuItem.Size = new System.Drawing.Size(160, 22);
			this.gridContextMenuItem.Text = "&Grid";
			this.gridContextMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
			// 
			// graphicsPanel1
			// 
			this.graphicsPanel1.AutoScroll = true;
			this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.graphicsPanel1.ContextMenuStrip = this.contextMenuStrip1;
			this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.graphicsPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.graphicsPanel1.Location = new System.Drawing.Point(0, 49);
			this.graphicsPanel1.Name = "graphicsPanel1";
			this.graphicsPanel1.Size = new System.Drawing.Size(584, 490);
			this.graphicsPanel1.TabIndex = 3;
			this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
			this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 561);
			this.Controls.Add(this.graphicsPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "GameForm";
			this.Text = "Conway\'s Game of Life";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private GraphicsPanel graphicsPanel1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGenerations;
		private System.Windows.Forms.ToolStripButton playToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton stepToolStripButton;
		private System.Windows.Forms.ToolStripButton pauseToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hUDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem neighborCountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem toroidalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem finiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem toToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromSeedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromCurrentSeedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromTimeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cellColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gridColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gridX10ColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem colorContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backColorToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cellColorToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem gridColorToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem gridX10ColorToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem viewContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hUDContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem neighborCountContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gridContextMenuItem;
	}
}

