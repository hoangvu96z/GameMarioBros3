using EditorV4.Controls;
using EditorV4.Controls.PropertyGridModel;
using EditorV4.Controls.TreeViewControl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.EditorObjects
{

    [Serializable]
    [DefaultProperty("Name")]
    public class GameObjectCategory : CustomClass, ICloneable
    {
        static int currentIndex = -1;
        public GameObjectCategory()
        {
            TileIndex = -1;
            Index = currentIndex++;
        }

        [Browsable(false)]
        public List<String> CollisionTypeList { get; set; }
        [NonSerialized]
        private DataTable _collisionTypeDataTable;
        [Browsable(false)]
        public DataTable CollisionTypeDataTable
        {
            get
            {
                return _collisionTypeDataTable;
            }
            set
            {
                _collisionTypeDataTable = value;
            }
        }

        private List<String> GetCollisionTypeList()
        {
            return CollisionTypeList;
        }

        private Image _objectImage;
        private string _name;
        private int _id;

        public bool Active;
        private TreeViewObject _treeViewObject;

        [Browsable(false)]
        internal int Index { get; set; }
        [Category("Properties")]
        public int Id
        {
            get => _id; set
            {
                _id = value;
                if (TreeViewObject != null)
                    TreeViewObject.Name = Display;
            }
        }


        [Category("Properties")]
        public String Name
        {
            get => _name; set
            {
                _name = value;
                if (TreeViewObject != null)
                    TreeViewObject.Name = Display;
            }
        }
        [Browsable(false)]
        public int TileIndex { get; set; }
        [Browsable(false)]
        public TreeViewObject TreeViewObject
        {
            get => _treeViewObject; set
            {
                _treeViewObject = value;
            }
        }
        [Browsable(false)]
        public int TreeViewObjectIndex { get; set; }
        [Category("Properties")]
        public String Display
        {
            get
            {
                return Name + "(Id : " + Id + ")";
            }
        }

        private void OnAddedEventHandler(object sender, ObjectCreatedEventArgs arg)
        {
            if (arg != null)
            {
                CollisionTypeList.Add((string)arg.DataValue);
            }
        }

        [DataList("GetCollisionTypeList", false, "OnAddedEventHandler")]
        [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
        [Category("Properties")]
        public string CollisionType { get; set; }
        [Browsable(false)]
        public int CollisionTypeIndex { get; set; }
        [Browsable(false)]
        public Image ObjectCategoryImage
        {
            get { return _objectImage; }
            set
            {
                _objectImage = value;
            }
        }

        internal string GetImageKey()
        {
            return "ObjectCategory" + Index;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
