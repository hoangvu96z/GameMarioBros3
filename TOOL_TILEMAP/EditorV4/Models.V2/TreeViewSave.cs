using EditorV4.Controls.TreeViewControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Models.V2
{
    [Serializable]
    public class TreeViewSave
    {
        [NonSerialized]
        private CustomTreeView treeView;
        public CustomTreeView TreeView
        {
            get { return treeView; }
            set { treeView = value; }
        }

        public Dictionary<string, Image> ImagesKey { get; set; }
        public TreeViewObject RootObject { get; set; }

        public TreeViewSave()
        {
        }

        public void Store()
        {
            ImagesKey = new Dictionary<string, Image>();
            for (int i = 0; i < treeView.Images.Count; i++)
            {

                var key = treeView.Images.Keys[i];
                Image image = treeView.Images[i];
                if (!ImagesKey.Keys.Contains(key))
                    ImagesKey.Add(key, image);
            }
            RootObject = treeView.RootObject;
        }
        public void Load()
        {
            foreach (var k in ImagesKey.Keys)
            {
                treeView.AddImage(k, ImagesKey[k]);
            }
            treeView.Nodes.Clear();
            treeView.Nodes.Add(RootObject.Node);
            treeView.RootObject = RootObject;
            treeView.Refresh();
        }
    }
}
