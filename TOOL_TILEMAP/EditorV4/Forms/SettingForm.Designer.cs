namespace EditorV4.Forms
{
    partial class SettingForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.colorSelectingBackColor = new EditorV4.Controls.ColorPickerControl();
            this.colorSelectingColorBorder = new EditorV4.Controls.ColorPickerControl();
            this.colorTileObjectColor = new EditorV4.Controls.ColorPickerControl();
            this.colorQuadtreeBorderColor = new EditorV4.Controls.ColorPickerControl();
            this.colorSelectedTileInWorldColor = new EditorV4.Controls.ColorPickerControl();
            this.colorSelectedTileColor = new EditorV4.Controls.ColorPickerControl();
            this.colorCurrentTileColor = new EditorV4.Controls.ColorPickerControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(498, 443);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.colorSelectingBackColor);
            this.tabPage1.Controls.Add(this.colorSelectingColorBorder);
            this.tabPage1.Controls.Add(this.colorTileObjectColor);
            this.tabPage1.Controls.Add(this.colorQuadtreeBorderColor);
            this.tabPage1.Controls.Add(this.colorSelectedTileInWorldColor);
            this.tabPage1.Controls.Add(this.colorSelectedTileColor);
            this.tabPage1.Controls.Add(this.colorCurrentTileColor);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(490, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Appearance";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // colorSelectingBackColor
            // 
            this.colorSelectingBackColor.Display = "(255,255,255)";
            this.colorSelectingBackColor.Label = "Selecting Back Color";
            this.colorSelectingBackColor.Location = new System.Drawing.Point(8, 306);
            this.colorSelectingBackColor.Name = "colorSelectingBackColor";
            this.colorSelectingBackColor.SelectedColor = System.Drawing.Color.Transparent;
            this.colorSelectingBackColor.Size = new System.Drawing.Size(349, 42);
            this.colorSelectingBackColor.TabIndex = 0;
            // 
            // colorSelectingColorBorder
            // 
            this.colorSelectingColorBorder.Display = "(255,255,255)";
            this.colorSelectingColorBorder.Label = "Selecting Border Color";
            this.colorSelectingColorBorder.Location = new System.Drawing.Point(8, 258);
            this.colorSelectingColorBorder.Name = "colorSelectingColorBorder";
            this.colorSelectingColorBorder.SelectedColor = System.Drawing.Color.Transparent;
            this.colorSelectingColorBorder.Size = new System.Drawing.Size(349, 42);
            this.colorSelectingColorBorder.TabIndex = 0;
            // 
            // colorTileObjectColor
            // 
            this.colorTileObjectColor.Display = "(255,255,255)";
            this.colorTileObjectColor.Label = "Tile Object Color";
            this.colorTileObjectColor.Location = new System.Drawing.Point(8, 210);
            this.colorTileObjectColor.Name = "colorTileObjectColor";
            this.colorTileObjectColor.SelectedColor = System.Drawing.Color.Transparent;
            this.colorTileObjectColor.Size = new System.Drawing.Size(349, 42);
            this.colorTileObjectColor.TabIndex = 0;
            // 
            // colorQuadtreeBorderColor
            // 
            this.colorQuadtreeBorderColor.Display = "(255,255,255)";
            this.colorQuadtreeBorderColor.Label = "Quadtree Border Color";
            this.colorQuadtreeBorderColor.Location = new System.Drawing.Point(8, 162);
            this.colorQuadtreeBorderColor.Name = "colorQuadtreeBorderColor";
            this.colorQuadtreeBorderColor.SelectedColor = System.Drawing.Color.Transparent;
            this.colorQuadtreeBorderColor.Size = new System.Drawing.Size(349, 42);
            this.colorQuadtreeBorderColor.TabIndex = 0;
            // 
            // colorSelectedTileInWorldColor
            // 
            this.colorSelectedTileInWorldColor.Display = "(255,255,255)";
            this.colorSelectedTileInWorldColor.Label = "Tile In World Color";
            this.colorSelectedTileInWorldColor.Location = new System.Drawing.Point(8, 114);
            this.colorSelectedTileInWorldColor.Name = "colorSelectedTileInWorldColor";
            this.colorSelectedTileInWorldColor.SelectedColor = System.Drawing.Color.Transparent;
            this.colorSelectedTileInWorldColor.Size = new System.Drawing.Size(349, 42);
            this.colorSelectedTileInWorldColor.TabIndex = 0;
            // 
            // colorSelectedTileColor
            // 
            this.colorSelectedTileColor.Display = "(255,255,255)";
            this.colorSelectedTileColor.Label = "Selected Tile Color";
            this.colorSelectedTileColor.Location = new System.Drawing.Point(8, 66);
            this.colorSelectedTileColor.Name = "colorSelectedTileColor";
            this.colorSelectedTileColor.SelectedColor = System.Drawing.Color.Transparent;
            this.colorSelectedTileColor.Size = new System.Drawing.Size(349, 42);
            this.colorSelectedTileColor.TabIndex = 0;
            // 
            // colorCurrentTileColor
            // 
            this.colorCurrentTileColor.Display = "(255,255,255)";
            this.colorCurrentTileColor.Label = "Current Tile Color";
            this.colorCurrentTileColor.Location = new System.Drawing.Point(8, 18);
            this.colorCurrentTileColor.Name = "colorCurrentTileColor";
            this.colorCurrentTileColor.SelectedColor = System.Drawing.Color.Transparent;
            this.colorCurrentTileColor.Size = new System.Drawing.Size(349, 42);
            this.colorCurrentTileColor.TabIndex = 0;
            this.colorCurrentTileColor.OnSelectColorEvent += new EditorV4.Controls.OnSelectColor(this.colorCurrentTileColor_OnSelectColorEvent);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(490, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Values";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(282, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(392, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 443);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingForm";
            this.Text = "Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.ColorPickerControl colorSelectedTileInWorldColor;
        private Controls.ColorPickerControl colorSelectedTileColor;
        private Controls.ColorPickerControl colorCurrentTileColor;
        private Controls.ColorPickerControl colorQuadtreeBorderColor;
        private Controls.ColorPickerControl colorTileObjectColor;
        private Controls.ColorPickerControl colorSelectingColorBorder;
        private Controls.ColorPickerControl colorSelectingBackColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}