using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Controls.TreeViewControl
{
    public enum TreeViewObjectType
    {
        Root,
        CategoryRectangle,
        CategoryObjectFromFile,
        CategoryObjectFromTile,
        GameObject
    }
    [Serializable]
    public class TreeViewObject
    {
        delegate void AccessTreeViewDelegate(TreeViewObject parent, CustomTreeView treeView, object owner, string name, string imageKey);
        public TreeViewObject()
        {

        }
        void AccessTreeView(TreeViewObject parent, CustomTreeView treeView, object owner, string name, string imageKey)
        {
            Owner = owner;
            if (parent != null)
            {
                parent.Childs.Add(this);
                this.Parent = parent;
            }
            Id = DateTime.Now.Millisecond; 
            TreeNodeCollection nodes = null;
            if (parent == null)
            {
                nodes = treeView.Nodes;
            }
            else
            {
                Parent = parent;
                nodes = parent.Node.Nodes;
            }
            nodes.Add(Id.ToString(), name);
            nodes[Id.ToString()].ImageKey = imageKey;
            nodes[Id.ToString()].SelectedImageKey = imageKey;
            Node = nodes[Id.ToString()];
            Node.Tag = this;
            this.Name = name;
            this.ImageKey = imageKey;
        }

        static int treeNodeId = 0;
        public TreeViewObject(TreeViewObject parent, CustomTreeView treeView, object owner, string name, string imageKey)
        {
                AccessTreeView(parent, treeView, owner, name, imageKey);
            //if (treeView.Created)
            //{
            //    AccessTreeViewDelegate d = new AccessTreeViewDelegate(AccessTreeView);
            //    treeView.BeginInvoke(d, parent, treeView, owner, name, imageKey);
            //}
            //else
            //{
            //}
            //d.Invoke(parent, treeView, owner, name, imageKey);


        }

        [Browsable(false)]
        public int NodeIndex { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public TreeNode Node { get; set; }
        [Browsable(false)]
        public object Owner { get; set; }
        [Browsable(false)]
        public TreeViewObjectType TreeViewObjectType { get; set; }
        private string _Name;
        public virtual string Name
        {
            get { return _Name; }
            set
            {
                Node.Text = value;
                _Name = value;
            }
        }

        private string _Image;

        [Browsable(false)]
        public string ImageKey
        {
            get { return _Image; }
            set
            {
                Node.ImageKey = value;
                _Image = value;
            }
        }
        [Browsable(false)]
        public List<TreeViewObject> Childs { get; set; } = new List<TreeViewObject>();
        [Browsable(false)]
        public TreeViewObject Parent { get; set; }
    }
}
