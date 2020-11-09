namespace EditorV4.Forms
{
    partial class AddCollisionTypeCollideForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCollisionType1 = new System.Windows.Forms.ComboBox();
            this.cmbCollisionType2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Collision Type 1";
            // 
            // cmbCollisionType1
            // 
            this.cmbCollisionType1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCollisionType1.DisplayMember = "Name";
            this.cmbCollisionType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollisionType1.FormattingEnabled = true;
            this.cmbCollisionType1.Location = new System.Drawing.Point(117, 79);
            this.cmbCollisionType1.Name = "cmbCollisionType1";
            this.cmbCollisionType1.Size = new System.Drawing.Size(121, 21);
            this.cmbCollisionType1.TabIndex = 1;
            this.cmbCollisionType1.ValueMember = "Name";
            // 
            // cmbCollisionType2
            // 
            this.cmbCollisionType2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCollisionType2.DisplayMember = "Name";
            this.cmbCollisionType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollisionType2.FormattingEnabled = true;
            this.cmbCollisionType2.Location = new System.Drawing.Point(117, 118);
            this.cmbCollisionType2.Name = "cmbCollisionType2";
            this.cmbCollisionType2.Size = new System.Drawing.Size(121, 21);
            this.cmbCollisionType2.TabIndex = 3;
            this.cmbCollisionType2.ValueMember = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collision Type 2";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(163, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(60, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddCollisionTypeCollideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 224);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCollisionType2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCollisionType1);
            this.Controls.Add(this.label1);
            this.Name = "AddCollisionTypeCollideForm";
            this.Text = "Add Collision Type Collide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCollisionType1;
        private System.Windows.Forms.ComboBox cmbCollisionType2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}