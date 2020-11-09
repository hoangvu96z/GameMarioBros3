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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            var createNewForm = new CreateNewForm();
            if(createNewForm.ShowDialog() == DialogResult.OK)
            {
                var testForm = new TestForm(createNewForm.RowsNumber, createNewForm.ColumnsNumber, createNewForm.TileSize, createNewForm.Tilesheet);
                this.Hide();
                testForm.ShowDialog();
                this.Show();
            }

        }
    }
}
