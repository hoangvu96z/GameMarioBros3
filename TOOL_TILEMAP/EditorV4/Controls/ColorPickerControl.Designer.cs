namespace EditorV4.Controls
{
    partial class ColorPickerControl
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
            this.label = new System.Windows.Forms.Label();
            this.txtColorDisplay = new System.Windows.Forms.TextBox();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 14);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 0;
            this.label.Text = "label1";
            // 
            // txtColorDisplay
            // 
            this.txtColorDisplay.Location = new System.Drawing.Point(139, 11);
            this.txtColorDisplay.Name = "txtColorDisplay";
            this.txtColorDisplay.Size = new System.Drawing.Size(169, 20);
            this.txtColorDisplay.TabIndex = 1;
            this.txtColorDisplay.TextChanged += new System.EventHandler(this.txtColorDisplay_TextChanged);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(318, 9);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(24, 23);
            this.btnSelectColor.TabIndex = 2;
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.BackColorChanged += new System.EventHandler(this.btnSelectColor_BackColorChanged);
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // ColorPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.txtColorDisplay);
            this.Controls.Add(this.label);
            this.Name = "ColorPickerControl";
            this.Size = new System.Drawing.Size(349, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtColorDisplay;
        private System.Windows.Forms.Button btnSelectColor;
    }
}
