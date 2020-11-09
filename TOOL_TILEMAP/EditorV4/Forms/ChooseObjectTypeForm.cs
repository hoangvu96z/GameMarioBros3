using EditorV4.Controls.TreeViewControl;
using EditorV4.EditorObjects;
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
    public enum ChooseObjectTypeEnum
    {
        Rectangle,
        ObjectFromFile
    }
    public interface ChooseObjectTypeFormInterface
    {
        DataTable CollisionTypeTable { get; }
        void AddGameObjectCategory(GameObjectCategory gameObjectCategory, TreeViewObjectType treeViewObjectType = TreeViewObjectType.CategoryObjectFromTile);
    }
    public partial class ChooseObjectTypeForm : Form
    {
        public ChooseObjectTypeForm()
        {
            InitializeComponent();
        }

        public ChooseObjectTypeFormInterface Interface;

        public ChooseObjectTypeEnum ChooseObjectTypeEnum { get; set; }

        public CreateObjectCategoryForm CreateObjectCategoryForm { get; set; }

        private void picRect_Click(object sender, EventArgs e)
        {
            CreateObjectCategoryForm = new CreateObjectCategoryForm();
            CreateObjectCategoryForm.CollisionTypeDataSource = Interface.CollisionTypeTable;
            CreateObjectCategoryForm.ObjCategoryImage = picRect.BackgroundImage;
            if(CreateObjectCategoryForm.ShowDialog() == DialogResult.OK)
            {
                ChooseObjectTypeEnum = ChooseObjectTypeEnum.Rectangle;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        static string GetFileName(string path)
        {
            int indexOfDot = path.IndexOf(".");
            int indexOfSlash = path.LastIndexOf("\\");
            return path.Substring(indexOfSlash + 1, indexOfDot - indexOfSlash - 1);
        }

        private void picObject_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String[] fileNames = openFileDialog1.FileNames;
                foreach(var fileName in fileNames)
                {
                    var name = GetFileName(fileName);
                    int id=0;
                    int.TryParse(name, out id);
                    var image = Image.FromFile(fileName);
                    GameObjectCategory objectCategory = new GameObjectCategory();
                    objectCategory.Id = id;
                    objectCategory.Name = name;
                    objectCategory.ObjectCategoryImage = (Image)image.Clone();
                    image.Dispose();
                    Interface.AddGameObjectCategory(objectCategory, TreeViewObjectType.CategoryObjectFromFile);
                    ChooseObjectTypeEnum = ChooseObjectTypeEnum.ObjectFromFile;
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
