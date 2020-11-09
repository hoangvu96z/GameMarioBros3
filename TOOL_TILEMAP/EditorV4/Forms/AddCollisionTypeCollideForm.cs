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
    public partial class AddCollisionTypeCollideForm : Form
    {
        public AddCollisionTypeCollideForm()
        {
            InitializeComponent();
        }

        public object CollisionType1ComboboxDataSource
        {
            get { return cmbCollisionType1.DataSource; }
            set { cmbCollisionType1.DataSource = value; }
        }

        public object CollisionType2ComboboxDataSource
        {
            get { return cmbCollisionType2.DataSource; }
            set { cmbCollisionType2.DataSource = value; }
        }

        public string CollisionType1
        {
            get { return cmbCollisionType1.Text; }
        }

        public string CollisionType2
        {
            get { return cmbCollisionType2.Text; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CollisionType1.Equals(CollisionType2))
            {
                MessageBox.Show("Value not valid!");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
