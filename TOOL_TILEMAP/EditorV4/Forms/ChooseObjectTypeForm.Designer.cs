namespace EditorV4.Forms
{
    partial class ChooseObjectTypeForm
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
            this.picObject = new System.Windows.Forms.PictureBox();
            this.picRect = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRect)).BeginInit();
            this.SuspendLayout();
            // 
            // picObject
            // 
            this.picObject.BackgroundImage = global::EditorV4.Properties.Resources.object2;
            this.picObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picObject.Location = new System.Drawing.Point(174, 24);
            this.picObject.Name = "picObject";
            this.picObject.Size = new System.Drawing.Size(56, 55);
            this.picObject.TabIndex = 0;
            this.picObject.TabStop = false;
            this.picObject.Click += new System.EventHandler(this.picObject_Click);
            // 
            // picRect
            // 
            this.picRect.BackgroundImage = global::EditorV4.Properties.Resources.rect2;
            this.picRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picRect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRect.Location = new System.Drawing.Point(52, 24);
            this.picRect.Name = "picRect";
            this.picRect.Size = new System.Drawing.Size(56, 55);
            this.picRect.TabIndex = 0;
            this.picRect.TabStop = false;
            this.picRect.Click += new System.EventHandler(this.picRect_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // ChooseObjectTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 98);
            this.Controls.Add(this.picObject);
            this.Controls.Add(this.picRect);
            this.Name = "ChooseObjectTypeForm";
            this.Text = "ChooseObjectTypeForm";
            ((System.ComponentModel.ISupportInitialize)(this.picObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRect;
        private System.Windows.Forms.PictureBox picObject;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}