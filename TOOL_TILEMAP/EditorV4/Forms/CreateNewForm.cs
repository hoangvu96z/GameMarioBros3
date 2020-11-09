using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Forms
{
    public partial class CreateNewForm : Form
    {
        public CreateNewForm()
        {
            InitializeComponent();

        }
        String _errorMessage;

        public int RowsNumber
        {
            get { return (int)numRows.Value; }
            set { numRows.Value = value; }
        }

        public int ColumnsNumber
        {
            get { return (int)numColumns.Value; }
            set { numColumns.Value = value; }
        }

        public int TileSize
        {
            get { return (int)numTileSize.Value; }
            set { numTileSize.Value = value; }
        }

        public Image Tilesheet
        {
            get { return picTilesheet.BackgroundImage; }
            set { picTilesheet.BackgroundImage = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(_errorMessage);
            }
        }

        public override bool ValidateChildren()
        {
            if (Tilesheet == null)
            {
                _errorMessage = "Please choose tilesheet";
                return false;
            }
            return base.ValidateChildren();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Tilesheet = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
