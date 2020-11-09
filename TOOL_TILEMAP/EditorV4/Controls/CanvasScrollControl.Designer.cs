namespace EditorV4.Controls
{
    partial class CanvasScrollControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelH = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.button1 = new System.Windows.Forms.Button();
            this.panelV = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panelH.SuspendLayout();
            this.panelV.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelH
            // 
            this.panelH.Controls.Add(this.hScrollBar1);
            this.panelH.Controls.Add(this.button1);
            this.panelH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelH.Location = new System.Drawing.Point(0, 327);
            this.panelH.Name = "panelH";
            this.panelH.Size = new System.Drawing.Size(413, 17);
            this.panelH.TabIndex = 0;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(396, 17);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CanvasScroll);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(396, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(17, 17);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelV
            // 
            this.panelV.Controls.Add(this.vScrollBar1);
            this.panelV.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelV.Location = new System.Drawing.Point(396, 0);
            this.panelV.Name = "panelV";
            this.panelV.Size = new System.Drawing.Size(17, 327);
            this.panelV.TabIndex = 1;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 327);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CanvasScroll);
            // 
            // CanvasScrollControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelV);
            this.Controls.Add(this.panelH);
            this.Name = "CanvasScrollControl";
            this.Size = new System.Drawing.Size(413, 344);
            this.SizeChanged += new System.EventHandler(this.CanvasScrollControl_SizeChanged);
            this.panelH.ResumeLayout(false);
            this.panelV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelV;
        public System.Windows.Forms.HScrollBar hScrollBar1;
        public System.Windows.Forms.VScrollBar vScrollBar1;
    }
}
