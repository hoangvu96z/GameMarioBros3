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
    public partial class RemovePropertyForm : Form
    {
        public RemovePropertyForm()
        {
            InitializeComponent();
        }

        public object ComboboxDataSource
        {
            get { return cmbProperty.DataSource; }
            set { cmbProperty.DataSource = value; }
        }

        public string PropertyName
        {
            get
            {
                return cmbProperty.Text;
            }
            
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
