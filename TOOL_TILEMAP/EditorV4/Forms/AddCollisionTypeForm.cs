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
    public partial class AddCollisionTypeForm : Form
    {
        public AddCollisionTypeForm()
        {
            InitializeComponent();
        }

        public object ComboboxDataSource
        {
            get
            {
                return cmbCollisionType.DataSource;
            }
            set
            {
                cmbCollisionType.DataSource = value;
            }
        }

        public String CollisionTypeName
        {
            get { return cmbCollisionType.Text; }
            set { cmbCollisionType.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
