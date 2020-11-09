using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Controls.TreeViewControl
{
    [Serializable]
    public class CustomTreeView : TreeView, ISerializable, ICustomTreeView
    {
        private ContextMenuStrip nodeContextMenuStrip;
        private ToolStripMenuItem nodeContextMenuStripDelete;
        private ToolStripMenuItem nodeContextMenuStripProperties;
        private System.ComponentModel.IContainer components;

        protected CustomTreeView(SerializationInfo info, StreamingContext context) :
            this()
        {
        }

        public CustomTreeView()
        {
            ImageList = new ImageList();
            InitializeComponent();
            ItemMargin = 3;
            ImageSize = 32;
            this.SetStyle(
      ControlStyles.AllPaintingInWmPaint |
      ControlStyles.DoubleBuffer, true);
            nodeContextMenuStripDelete.Click += NodeContextMenuStripDelete_Click;
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            if (TreeViewContainer != null)
                TreeViewContainer.OnSelectTreeViewObject((TreeViewObject)e.Node.Tag, this);
            OpenPropertyNode(SelectedNode);
        }

        public ITreeViewContainer TreeViewContainer { get; set; }

        public TreeViewObject RootObject { get; set; }

        public ImageList.ImageCollection Images
        {
            get
            {
                return ImageList.Images;
            }
        }
        public int ItemMargin { get; set; }
        public int ImageSize
        {
            get
            {
                return ItemHeight - 2 * ItemMargin;
            }
            set
            {
                ImageList.ImageSize = new Size(value, value);
                ItemHeight = value + 2 * ItemMargin;
            }
        }

        Image GetFixImage(Image image)
        {
            Image i = new Bitmap(ItemHeight, ItemHeight);
            image = image.ResizeImage(ImageSize, ImageSize);
            Graphics.FromImage(i).Clear(Color.Transparent);
            Graphics.FromImage(i).DrawImage(image,
                new Rectangle(0, ItemMargin, ImageSize, ImageSize),
                new Rectangle(0, 0, ImageSize, ImageSize),
                 GraphicsUnit.Pixel);
            return i;
        }

        public void AddImage(string key, Image image)
        {
            Images.Add(key, GetFixImage(image));
        }

        public void AddImage(string key, string path)
        {
            Image image = Image.FromFile(path);
            Images.Add(key, GetFixImage(image));
            image.Dispose();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nodeContextMenuStripDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeContextMenuStripProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeContextMenuStrip
            // 
            this.nodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nodeContextMenuStripDelete,
            this.nodeContextMenuStripProperties});
            this.nodeContextMenuStrip.Name = "nodeContextMenuStrip";
            this.nodeContextMenuStrip.Size = new System.Drawing.Size(128, 48);
            // 
            // nodeContextMenuStripDelete
            // 
            this.nodeContextMenuStripDelete.Name = "nodeContextMenuStripDelete";
            this.nodeContextMenuStripDelete.Size = new System.Drawing.Size(127, 22);
            this.nodeContextMenuStripDelete.Text = "Delete";
            // 
            // nodeContextMenuStripProperties
            // 
            this.nodeContextMenuStripProperties.Name = "nodeContextMenuStripProperties";
            this.nodeContextMenuStripProperties.Size = new System.Drawing.Size(127, 22);
            this.nodeContextMenuStripProperties.Text = "Properties";
            // 
            // CustomTreeView
            // 
            this.ContextMenuStrip = this.nodeContextMenuStrip;
            this.HideSelection = false;
            this.LineColor = System.Drawing.Color.Black;
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CustomTreeView_NodeMouseClick);
            this.DoubleClick += new System.EventHandler(this.CustomTreeView_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomTreeView_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CustomTreeView_MouseClick);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CustomTreeView_PreviewKeyDown);
            this.nodeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        public void OpenPropertyNode(TreeNode node)
        {
            if (TreeViewContainer != null)
            {
                TreeViewContainer.OnProperty((TreeViewObject)node.Tag, this);
            }
        }

        private void NodeContextMenuStripProperties_Click(object sender, EventArgs e)
        {
            OpenPropertyNode(SelectedNode);
        }

        public void RemoveNode(TreeNode node)
        {
            if (TreeViewContainer != null)
            {
                TreeViewContainer.OnDelete((TreeViewObject)node.Tag, this);
            }
        }

        private void NodeContextMenuStripDelete_Click(object sender, EventArgs e)
        {
            RemoveNode(SelectedNode);
        }

        private void CustomTreeView_MouseClick(object sender, MouseEventArgs e)
        {
        }


        private void CustomTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = e.Node;
            OpenPropertyNode(SelectedNode);
            if (TreeViewContainer != null)
            {
                TreeViewContainer.OnFocus((TreeViewObject)SelectedNode.Tag, this);
            }
        }

        private void CustomTreeView_DoubleClick(object sender, EventArgs e)
        {
            //  OpenPropertyNode(SelectedNode);
            TreeViewContainer.OnDoubleClick((TreeViewObject)SelectedNode.Tag, this);
        }

        private void CustomTreeView_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("ImageSize", ImageSize);
            //info.AddValue("ItemMargin", ItemMargin);
            //info.AddValue("RootObject", RootObject);
        }

        private void CustomTreeView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveNode(SelectedNode);
            }
        }
    }
}
