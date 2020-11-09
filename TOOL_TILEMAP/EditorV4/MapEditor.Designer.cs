namespace EditorV4
{
    partial class MapEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImportImage = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnOpen = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnSave = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnImportObject = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnDrawRectangle = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnGroup = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnQuadtree = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnUndo = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnRedo = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnSelectTile = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnGrid = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnHorizontalScroll = new EditorV4.Controls.ToolStripButtonCustom();
            this.btnSetting = new EditorV4.Controls.ToolStripButtonCustom();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBarTilesheetZoom = new System.Windows.Forms.TrackBar();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.openTileExisting = new System.Windows.Forms.OpenFileDialog();
            this.progressWaiting = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.cmbRows = new System.Windows.Forms.ComboBox();
            this.cmbTileHeight = new System.Windows.Forms.ComboBox();
            this.cmbTileWidth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveOut = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new EditorV4.Controls.CustomSpliter();
            this.splitContainer2 = new EditorV4.Controls.CustomSpliter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddObject = new System.Windows.Forms.Button();
            this.treeViewObject = new EditorV4.Controls.TreeViewControl.CustomTreeView();
            this.btnRemoveObject = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddCollisionType = new System.Windows.Forms.Button();
            this.collisionTypeTree = new EditorV4.Controls.TreeViewControl.CustomTreeView();
            this.btnRemoveCollisionType = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCollisionTypeCollideAdd = new System.Windows.Forms.Button();
            this.treeViewCollisionTypeCollide = new EditorV4.Controls.TreeViewControl.CustomTreeView();
            this.btnCollisionTypeCollideRemove = new System.Windows.Forms.Button();
            this.canvasScrollTile = new EditorV4.Controls.CanvasScrollControl();
            this.splitContainer3 = new EditorV4.Controls.CustomSpliter();
            this.panelMain = new System.Windows.Forms.Panel();
            this.canvasScrollControl1 = new EditorV4.Controls.CanvasScrollControl();
            this.btnRemoveProperty = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.openDatFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTilesheetZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importFromImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // importFromImageToolStripMenuItem
            // 
            this.importFromImageToolStripMenuItem.Name = "importFromImageToolStripMenuItem";
            this.importFromImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importFromImageToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.importFromImageToolStripMenuItem.Text = "Import From Image";
            this.importFromImageToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportImage,
            this.btnOpen,
            this.btnSave,
            this.btnImportObject,
            this.btnDrawRectangle,
            this.btnGroup,
            this.btnQuadtree,
            this.btnUndo,
            this.btnRedo,
            this.btnSelectTile,
            this.btnGrid,
            this.btnHorizontalScroll,
            this.btnSetting});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(883, 49);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnImportImage
            // 
            this.btnImportImage.AutoSize = false;
            this.btnImportImage.CheckedImage = null;
            this.btnImportImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportImage.Image = global::EditorV4.Properties.Resources.new1;
            this.btnImportImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportImage.IsCheckBox = false;
            this.btnImportImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Padding = new System.Windows.Forms.Padding(5);
            this.btnImportImage.Size = new System.Drawing.Size(28, 28);
            this.btnImportImage.Text = "Import Image";
            this.btnImportImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSize = false;
            this.btnOpen.CheckedImage = null;
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::EditorV4.Properties.Resources.open1;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.IsCheckBox = false;
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(5);
            this.btnOpen.Size = new System.Drawing.Size(28, 28);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.CheckedImage = null;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.IsCheckBox = false;
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(28, 28);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImportObject
            // 
            this.btnImportObject.AutoSize = false;
            this.btnImportObject.CheckedImage = null;
            this.btnImportObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportObject.Enabled = false;
            this.btnImportObject.Image = global::EditorV4.Properties.Resources.object2;
            this.btnImportObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportObject.IsCheckBox = false;
            this.btnImportObject.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportObject.Name = "btnImportObject";
            this.btnImportObject.Padding = new System.Windows.Forms.Padding(5);
            this.btnImportObject.Size = new System.Drawing.Size(28, 28);
            this.btnImportObject.Text = "Import Object";
            // 
            // btnDrawRectangle
            // 
            this.btnDrawRectangle.AutoSize = false;
            this.btnDrawRectangle.CheckedImage = global::EditorV4.Properties.Resources.rectcancel;
            this.btnDrawRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDrawRectangle.Enabled = false;
            this.btnDrawRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawRectangle.Image")));
            this.btnDrawRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDrawRectangle.IsCheckBox = true;
            this.btnDrawRectangle.Margin = new System.Windows.Forms.Padding(2);
            this.btnDrawRectangle.Name = "btnDrawRectangle";
            this.btnDrawRectangle.Padding = new System.Windows.Forms.Padding(5);
            this.btnDrawRectangle.Size = new System.Drawing.Size(28, 28);
            this.btnDrawRectangle.Text = "Draw a rectangle";
            this.btnDrawRectangle.Click += new System.EventHandler(this.btnDrawRectangle_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.AutoSize = false;
            this.btnGroup.CheckedImage = null;
            this.btnGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGroup.Enabled = false;
            this.btnGroup.Image = global::EditorV4.Properties.Resources.group12;
            this.btnGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroup.IsCheckBox = false;
            this.btnGroup.Margin = new System.Windows.Forms.Padding(2);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Padding = new System.Windows.Forms.Padding(5);
            this.btnGroup.Size = new System.Drawing.Size(28, 28);
            this.btnGroup.Text = "Group Objects";
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnQuadtree
            // 
            this.btnQuadtree.AutoSize = false;
            this.btnQuadtree.CheckedImage = null;
            this.btnQuadtree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuadtree.Enabled = false;
            this.btnQuadtree.Image = global::EditorV4.Properties.Resources.quadtree;
            this.btnQuadtree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuadtree.IsCheckBox = false;
            this.btnQuadtree.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuadtree.Name = "btnQuadtree";
            this.btnQuadtree.Padding = new System.Windows.Forms.Padding(5);
            this.btnQuadtree.Size = new System.Drawing.Size(28, 28);
            this.btnQuadtree.Text = "Buid Quadtree";
            this.btnQuadtree.Click += new System.EventHandler(this.btnQuadtree_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.AutoSize = false;
            this.btnUndo.CheckedImage = null;
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = global::EditorV4.Properties.Resources.undo;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.IsCheckBox = false;
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Padding = new System.Windows.Forms.Padding(5);
            this.btnUndo.Size = new System.Drawing.Size(28, 28);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.AutoSize = false;
            this.btnRedo.CheckedImage = null;
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Enabled = false;
            this.btnRedo.Image = global::EditorV4.Properties.Resources.redo;
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.IsCheckBox = false;
            this.btnRedo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Padding = new System.Windows.Forms.Padding(5);
            this.btnRedo.Size = new System.Drawing.Size(28, 28);
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnSelectTile
            // 
            this.btnSelectTile.AutoSize = false;
            this.btnSelectTile.CheckedImage = null;
            this.btnSelectTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectTile.Enabled = false;
            this.btnSelectTile.Image = global::EditorV4.Properties.Resources.itile3;
            this.btnSelectTile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectTile.IsCheckBox = true;
            this.btnSelectTile.Margin = new System.Windows.Forms.Padding(3);
            this.btnSelectTile.Name = "btnSelectTile";
            this.btnSelectTile.Padding = new System.Windows.Forms.Padding(5);
            this.btnSelectTile.Size = new System.Drawing.Size(28, 28);
            this.btnSelectTile.Text = "Select Tile From Map";
            // 
            // btnGrid
            // 
            this.btnGrid.AutoSize = false;
            this.btnGrid.CheckedImage = null;
            this.btnGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGrid.Enabled = false;
            this.btnGrid.Image = global::EditorV4.Properties.Resources.grid;
            this.btnGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGrid.IsCheckBox = true;
            this.btnGrid.Margin = new System.Windows.Forms.Padding(3);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Padding = new System.Windows.Forms.Padding(5);
            this.btnGrid.Size = new System.Drawing.Size(28, 28);
            this.btnGrid.Text = "Grid";
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // btnHorizontalScroll
            // 
            this.btnHorizontalScroll.AutoSize = false;
            this.btnHorizontalScroll.CheckedImage = null;
            this.btnHorizontalScroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHorizontalScroll.Enabled = false;
            this.btnHorizontalScroll.Image = global::EditorV4.Properties.Resources.hor1;
            this.btnHorizontalScroll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHorizontalScroll.IsCheckBox = true;
            this.btnHorizontalScroll.Margin = new System.Windows.Forms.Padding(3);
            this.btnHorizontalScroll.Name = "btnHorizontalScroll";
            this.btnHorizontalScroll.Padding = new System.Windows.Forms.Padding(5);
            this.btnHorizontalScroll.Size = new System.Drawing.Size(28, 28);
            this.btnHorizontalScroll.Text = "Horizontal Scroll";
            // 
            // btnSetting
            // 
            this.btnSetting.AutoSize = false;
            this.btnSetting.CheckedImage = null;
            this.btnSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetting.Image = global::EditorV4.Properties.Resources.setting;
            this.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetting.IsCheckBox = false;
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(5);
            this.btnSetting.Size = new System.Drawing.Size(28, 28);
            this.btnSetting.Text = "Setting";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panel1.Location = new System.Drawing.Point(135, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 24);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trackBarTilesheetZoom);
            this.panel2.Controls.Add(this.trackBarZoom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(883, 42);
            this.panel2.TabIndex = 4;
            // 
            // trackBarTilesheetZoom
            // 
            this.trackBarTilesheetZoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBarTilesheetZoom.Location = new System.Drawing.Point(0, 0);
            this.trackBarTilesheetZoom.Maximum = 20;
            this.trackBarTilesheetZoom.Minimum = 1;
            this.trackBarTilesheetZoom.Name = "trackBarTilesheetZoom";
            this.trackBarTilesheetZoom.Size = new System.Drawing.Size(140, 42);
            this.trackBarTilesheetZoom.TabIndex = 1;
            this.trackBarTilesheetZoom.Value = 10;
            this.trackBarTilesheetZoom.Scroll += new System.EventHandler(this.trackBarTilesheetZoom_Scroll);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBarZoom.Location = new System.Drawing.Point(755, 0);
            this.trackBarZoom.Maximum = 20;
            this.trackBarZoom.Minimum = 1;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(128, 42);
            this.trackBarZoom.TabIndex = 0;
            this.trackBarZoom.Value = 10;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // progressWaiting
            // 
            this.progressWaiting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressWaiting.Location = new System.Drawing.Point(712, 34);
            this.progressWaiting.Name = "progressWaiting";
            this.progressWaiting.Size = new System.Drawing.Size(166, 23);
            this.progressWaiting.TabIndex = 6;
            this.progressWaiting.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 24);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.cmbUnit);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.cmbColumns);
            this.panel4.Controls.Add(this.cmbRows);
            this.panel4.Controls.Add(this.cmbTileHeight);
            this.panel4.Controls.Add(this.cmbTileWidth);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(883, 36);
            this.panel4.TabIndex = 8;
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnit.Items.AddRange(new object[] {
            "Pixel",
            "Tile"});
            this.cmbUnit.Location = new System.Drawing.Point(529, 6);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(76, 21);
            this.cmbUnit.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Unit";
            // 
            // cmbColumns
            // 
            this.cmbColumns.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbColumns.Enabled = false;
            this.cmbColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbColumns.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
            this.cmbColumns.Location = new System.Drawing.Point(414, 7);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(53, 21);
            this.cmbColumns.TabIndex = 7;
            // 
            // cmbRows
            // 
            this.cmbRows.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbRows.Enabled = false;
            this.cmbRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRows.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
            this.cmbRows.Location = new System.Drawing.Point(302, 7);
            this.cmbRows.Name = "cmbRows";
            this.cmbRows.Size = new System.Drawing.Size(53, 21);
            this.cmbRows.TabIndex = 7;
            // 
            // cmbTileHeight
            // 
            this.cmbTileHeight.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbTileHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTileHeight.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
            this.cmbTileHeight.Location = new System.Drawing.Point(199, 7);
            this.cmbTileHeight.Name = "cmbTileHeight";
            this.cmbTileHeight.Size = new System.Drawing.Size(53, 21);
            this.cmbTileHeight.TabIndex = 7;
            this.cmbTileHeight.Text = "16";
            this.cmbTileHeight.Leave += new System.EventHandler(this.cmbTileHeight_Leave);
            // 
            // cmbTileWidth
            // 
            this.cmbTileWidth.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbTileWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTileWidth.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
            this.cmbTileWidth.Location = new System.Drawing.Point(70, 8);
            this.cmbTileWidth.Name = "cmbTileWidth";
            this.cmbTileWidth.Size = new System.Drawing.Size(53, 21);
            this.cmbTileWidth.TabIndex = 7;
            this.cmbTileWidth.Text = "16";
            this.cmbTileWidth.Enter += new System.EventHandler(this.cmbTileWidth_Leave);
            this.cmbTileWidth.Leave += new System.EventHandler(this.cmbTileWidth_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Columns";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tile height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tile width";
            // 
            // saveOut
            // 
            this.saveOut.AddExtension = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 109);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(883, 339);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.canvasScrollTile);
            this.splitContainer2.Size = new System.Drawing.Size(258, 339);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(254, 198);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddObject);
            this.tabPage1.Controls.Add(this.treeViewObject);
            this.tabPage1.Controls.Add(this.btnRemoveObject);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(246, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Categories";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddObject
            // 
            this.btnAddObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddObject.BackgroundImage = global::EditorV4.Properties.Resources.object2;
            this.btnAddObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddObject.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddObject.Location = new System.Drawing.Point(204, 142);
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Padding = new System.Windows.Forms.Padding(10);
            this.btnAddObject.Size = new System.Drawing.Size(31, 24);
            this.btnAddObject.TabIndex = 2;
            this.btnAddObject.UseVisualStyleBackColor = true;
            this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
            // 
            // treeViewObject
            // 
            this.treeViewObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewObject.HideSelection = false;
            this.treeViewObject.ImageIndex = 0;
            this.treeViewObject.ImageSize = 32;
            this.treeViewObject.ItemHeight = 38;
            this.treeViewObject.ItemMargin = 3;
            this.treeViewObject.Location = new System.Drawing.Point(0, 0);
            this.treeViewObject.Name = "treeViewObject";
            this.treeViewObject.RootObject = null;
            this.treeViewObject.SelectedImageIndex = 0;
            this.treeViewObject.Size = new System.Drawing.Size(246, 136);
            this.treeViewObject.TabIndex = 0;
            this.treeViewObject.TreeViewContainer = null;
            // 
            // btnRemoveObject
            // 
            this.btnRemoveObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveObject.BackgroundImage = global::EditorV4.Properties.Resources.object_remove;
            this.btnRemoveObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveObject.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemoveObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemoveObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveObject.Location = new System.Drawing.Point(161, 142);
            this.btnRemoveObject.Name = "btnRemoveObject";
            this.btnRemoveObject.Padding = new System.Windows.Forms.Padding(10);
            this.btnRemoveObject.Size = new System.Drawing.Size(31, 24);
            this.btnRemoveObject.TabIndex = 1;
            this.btnRemoveObject.UseVisualStyleBackColor = true;
            this.btnRemoveObject.Click += new System.EventHandler(this.btnRemoveObject_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddCollisionType);
            this.tabPage2.Controls.Add(this.collisionTypeTree);
            this.tabPage2.Controls.Add(this.btnRemoveCollisionType);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(246, 172);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CollisionType";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddCollisionType
            // 
            this.btnAddCollisionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCollisionType.BackgroundImage = global::EditorV4.Properties.Resources.collision1_add;
            this.btnAddCollisionType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddCollisionType.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddCollisionType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddCollisionType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddCollisionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCollisionType.Location = new System.Drawing.Point(204, 140);
            this.btnAddCollisionType.Name = "btnAddCollisionType";
            this.btnAddCollisionType.Padding = new System.Windows.Forms.Padding(10);
            this.btnAddCollisionType.Size = new System.Drawing.Size(31, 24);
            this.btnAddCollisionType.TabIndex = 4;
            this.btnAddCollisionType.UseVisualStyleBackColor = true;
            this.btnAddCollisionType.Click += new System.EventHandler(this.btnAddCollisionType_Click);
            // 
            // collisionTypeTree
            // 
            this.collisionTypeTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collisionTypeTree.HideSelection = false;
            this.collisionTypeTree.ImageIndex = 0;
            this.collisionTypeTree.ImageSize = 32;
            this.collisionTypeTree.ItemHeight = 38;
            this.collisionTypeTree.ItemMargin = 3;
            this.collisionTypeTree.Location = new System.Drawing.Point(0, 0);
            this.collisionTypeTree.Name = "collisionTypeTree";
            this.collisionTypeTree.RootObject = null;
            this.collisionTypeTree.SelectedImageIndex = 0;
            this.collisionTypeTree.Size = new System.Drawing.Size(247, 136);
            this.collisionTypeTree.TabIndex = 0;
            this.collisionTypeTree.Tag = "2";
            this.collisionTypeTree.TreeViewContainer = null;
            // 
            // btnRemoveCollisionType
            // 
            this.btnRemoveCollisionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCollisionType.BackgroundImage = global::EditorV4.Properties.Resources.collision1_remove;
            this.btnRemoveCollisionType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveCollisionType.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemoveCollisionType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveCollisionType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemoveCollisionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCollisionType.Location = new System.Drawing.Point(161, 140);
            this.btnRemoveCollisionType.Name = "btnRemoveCollisionType";
            this.btnRemoveCollisionType.Padding = new System.Windows.Forms.Padding(10);
            this.btnRemoveCollisionType.Size = new System.Drawing.Size(31, 24);
            this.btnRemoveCollisionType.TabIndex = 3;
            this.btnRemoveCollisionType.UseVisualStyleBackColor = true;
            this.btnRemoveCollisionType.Click += new System.EventHandler(this.btnRemoveCollisionType_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCollisionTypeCollideAdd);
            this.tabPage3.Controls.Add(this.treeViewCollisionTypeCollide);
            this.tabPage3.Controls.Add(this.btnCollisionTypeCollideRemove);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(246, 172);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CollisionType Collide";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCollisionTypeCollideAdd
            // 
            this.btnCollisionTypeCollideAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollisionTypeCollideAdd.BackgroundImage = global::EditorV4.Properties.Resources.collision1_add;
            this.btnCollisionTypeCollideAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCollisionTypeCollideAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCollisionTypeCollideAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCollisionTypeCollideAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCollisionTypeCollideAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollisionTypeCollideAdd.Location = new System.Drawing.Point(204, 144);
            this.btnCollisionTypeCollideAdd.Name = "btnCollisionTypeCollideAdd";
            this.btnCollisionTypeCollideAdd.Padding = new System.Windows.Forms.Padding(10);
            this.btnCollisionTypeCollideAdd.Size = new System.Drawing.Size(31, 24);
            this.btnCollisionTypeCollideAdd.TabIndex = 7;
            this.btnCollisionTypeCollideAdd.UseVisualStyleBackColor = true;
            this.btnCollisionTypeCollideAdd.Click += new System.EventHandler(this.btnCollisionTypeCollideAdd_Click);
            // 
            // treeViewCollisionTypeCollide
            // 
            this.treeViewCollisionTypeCollide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewCollisionTypeCollide.HideSelection = false;
            this.treeViewCollisionTypeCollide.ImageIndex = 0;
            this.treeViewCollisionTypeCollide.ImageSize = 32;
            this.treeViewCollisionTypeCollide.ItemHeight = 38;
            this.treeViewCollisionTypeCollide.ItemMargin = 3;
            this.treeViewCollisionTypeCollide.Location = new System.Drawing.Point(0, 4);
            this.treeViewCollisionTypeCollide.Name = "treeViewCollisionTypeCollide";
            this.treeViewCollisionTypeCollide.RootObject = null;
            this.treeViewCollisionTypeCollide.SelectedImageIndex = 0;
            this.treeViewCollisionTypeCollide.Size = new System.Drawing.Size(247, 136);
            this.treeViewCollisionTypeCollide.TabIndex = 5;
            this.treeViewCollisionTypeCollide.Tag = "2";
            this.treeViewCollisionTypeCollide.TreeViewContainer = null;
            // 
            // btnCollisionTypeCollideRemove
            // 
            this.btnCollisionTypeCollideRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollisionTypeCollideRemove.BackgroundImage = global::EditorV4.Properties.Resources.collision1_remove;
            this.btnCollisionTypeCollideRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCollisionTypeCollideRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCollisionTypeCollideRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCollisionTypeCollideRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCollisionTypeCollideRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollisionTypeCollideRemove.Location = new System.Drawing.Point(161, 144);
            this.btnCollisionTypeCollideRemove.Name = "btnCollisionTypeCollideRemove";
            this.btnCollisionTypeCollideRemove.Padding = new System.Windows.Forms.Padding(10);
            this.btnCollisionTypeCollideRemove.Size = new System.Drawing.Size(31, 24);
            this.btnCollisionTypeCollideRemove.TabIndex = 6;
            this.btnCollisionTypeCollideRemove.UseVisualStyleBackColor = true;
            // 
            // canvasScrollTile
            // 
            this.canvasScrollTile.CanvasScrollParent = null;
            this.canvasScrollTile.ConvertWorldView = null;
            this.canvasScrollTile.CurrentMovePoint = ((System.Drawing.PointF)(resources.GetObject("canvasScrollTile.CurrentMovePoint")));
            this.canvasScrollTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasScrollTile.HValue = 0F;
            this.canvasScrollTile.Location = new System.Drawing.Point(0, 0);
            this.canvasScrollTile.MaxHValue = 780F;
            this.canvasScrollTile.MaxVValue = 905F;
            this.canvasScrollTile.Name = "canvasScrollTile";
            this.canvasScrollTile.Size = new System.Drawing.Size(254, 129);
            this.canvasScrollTile.TabIndex = 0;
            this.canvasScrollTile.TestInterface = null;
            this.canvasScrollTile.VValue = 0F;
            this.canvasScrollTile.WorldHeight = 0;
            this.canvasScrollTile.WorldWidth = 0;
            this.canvasScrollTile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.canvasScrollTile_MouseDoubleClick);
            this.canvasScrollTile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasScrollTile_MouseDown);
            this.canvasScrollTile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasScrollTile_MouseMove);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panelMain);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnRemoveProperty);
            this.splitContainer3.Panel2.Controls.Add(this.btnAddProperty);
            this.splitContainer3.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer3.Size = new System.Drawing.Size(621, 339);
            this.splitContainer3.SplitterDistance = 449;
            this.splitContainer3.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.canvasScrollControl1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(445, 335);
            this.panelMain.TabIndex = 0;
            // 
            // canvasScrollControl1
            // 
            this.canvasScrollControl1.CanvasScrollParent = null;
            this.canvasScrollControl1.ConvertWorldView = null;
            this.canvasScrollControl1.CurrentMovePoint = ((System.Drawing.PointF)(resources.GetObject("canvasScrollControl1.CurrentMovePoint")));
            this.canvasScrollControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasScrollControl1.HValue = 0F;
            this.canvasScrollControl1.Location = new System.Drawing.Point(0, 0);
            this.canvasScrollControl1.MaxHValue = 589F;
            this.canvasScrollControl1.MaxVValue = 699F;
            this.canvasScrollControl1.Name = "canvasScrollControl1";
            this.canvasScrollControl1.Size = new System.Drawing.Size(445, 335);
            this.canvasScrollControl1.TabIndex = 0;
            this.canvasScrollControl1.TestInterface = null;
            this.canvasScrollControl1.VValue = 0F;
            this.canvasScrollControl1.WorldHeight = 0;
            this.canvasScrollControl1.WorldWidth = 0;
            this.canvasScrollControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasScrollControl1_MouseDown);
            this.canvasScrollControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasScrollControl1_MouseMove);
            this.canvasScrollControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasScrollControl1_MouseUp);
            // 
            // btnRemoveProperty
            // 
            this.btnRemoveProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveProperty.Location = new System.Drawing.Point(85, 1);
            this.btnRemoveProperty.Name = "btnRemoveProperty";
            this.btnRemoveProperty.Size = new System.Drawing.Size(35, 23);
            this.btnRemoveProperty.TabIndex = 1;
            this.btnRemoveProperty.Text = "-";
            this.btnRemoveProperty.UseVisualStyleBackColor = true;
            this.btnRemoveProperty.Click += new System.EventHandler(this.btnRemoveProperty_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProperty.Enabled = false;
            this.btnAddProperty.Location = new System.Drawing.Point(126, 1);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(35, 23);
            this.btnAddProperty.TabIndex = 1;
            this.btnAddProperty.Text = "+";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(164, 335);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            this.propertyGrid1.SelectedObjectsChanged += new System.EventHandler(this.propertyGrid1_SelectedObjectsChanged);
            // 
            // openDatFile
            // 
            this.openDatFile.FileName = "openFileDialog1";
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 490);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.progressWaiting);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTilesheetZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private EditorV4.Controls.ToolStripButtonCustom btnImportImage;
        private EditorV4.Controls.ToolStripButtonCustom btnOpen;
        private EditorV4.Controls.ToolStripButtonCustom btnSave;
        private EditorV4.Controls.ToolStripButtonCustom btnImportObject;
        private EditorV4.Controls.ToolStripButtonCustom btnDrawRectangle;
        private EditorV4.Controls.ToolStripButtonCustom btnGroup;
        private EditorV4.Controls.ToolStripButtonCustom btnQuadtree;
        private EditorV4.Controls.ToolStripButtonCustom btnUndo;
        private EditorV4.Controls.ToolStripButtonCustom btnSetting;
        private EditorV4.Controls.ToolStripButtonCustom btnRedo;
        private EditorV4.Controls.ToolStripButtonCustom btnSelectTile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private Controls.CustomSpliter splitContainer1;
        private Controls.CustomSpliter splitContainer2;
        private Controls.CustomSpliter splitContainer3;
        private System.Windows.Forms.Panel panelMain;
        private Controls.CanvasScrollControl canvasScrollControl1;
        private System.Windows.Forms.OpenFileDialog openTileExisting;
        private System.Windows.Forms.ProgressBar progressWaiting;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.ComboBox cmbRows;
        private System.Windows.Forms.ComboBox cmbTileHeight;
        private System.Windows.Forms.ComboBox cmbTileWidth;
        private Controls.CanvasScrollControl canvasScrollTile;
        private System.Windows.Forms.TrackBar trackBarTilesheetZoom;
        private Controls.ToolStripButtonCustom btnGrid;
        private Controls.ToolStripButtonCustom btnHorizontalScroll;
        private System.Windows.Forms.ToolStripMenuItem importFromImageToolStripMenuItem;
        private Controls.TreeViewControl.CustomTreeView treeViewObject;
        private System.Windows.Forms.Button btnRemoveObject;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.Button btnAddCollisionType;
        private Controls.TreeViewControl.CustomTreeView collisionTypeTree;
        private System.Windows.Forms.Button btnRemoveCollisionType;
        private System.Windows.Forms.SaveFileDialog saveOut;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCollisionTypeCollideAdd;
        private Controls.TreeViewControl.CustomTreeView treeViewCollisionTypeCollide;
        private System.Windows.Forms.Button btnCollisionTypeCollideRemove;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.Button btnRemoveProperty;
        private System.Windows.Forms.OpenFileDialog openDatFile;
    }
}