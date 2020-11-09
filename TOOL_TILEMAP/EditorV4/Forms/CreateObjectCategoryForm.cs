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
    public partial class CreateObjectCategoryForm : Form
    {
        public CreateObjectCategoryForm()
        {
            InitializeComponent();
            cmbCollisionType.DisplayMember = "Name";
        }

        public object CollisionTypeDataSource
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
        public string CollisionTypeName
        {
            get
            {
                return cmbCollisionType.Text;
            }
            set
            {
                cmbCollisionType.Text = value;
            }
        }

        public Image ObjCategoryImage
        {
            get
            {
                return picObjCategoryImage.BackgroundImage;
            }
            set
            {
                picObjCategoryImage.BackgroundImage = value;
            }
        }

        public int ObjectCategoryId
        {
            get { return (int)txtId.Value; }
            set { txtId.Value = value; }
        }

        public string ObjectCategoryName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
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
