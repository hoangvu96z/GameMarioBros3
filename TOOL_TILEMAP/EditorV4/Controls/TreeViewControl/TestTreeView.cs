using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Controls.TreeViewControl
{
    public partial class TestTreeView : Form, ITreeViewContainer
    {
        TreeViewObject category1;
        TreeViewObject item2;
        public TestTreeView()
        {
            InitializeComponent();
            customTreeView1.AddImage("Root", Directory.GetCurrentDirectory() + "/root.png");
            customTreeView1.AddImage("EnemyCategory1", Directory.GetCurrentDirectory() + "/enemy.png");
            customTreeView1.AddImage("Enemy1", Directory.GetCurrentDirectory() + "/icon.png");
            customTreeView1.AddImage("Enemy2", Directory.GetCurrentDirectory() + "/icon1.png");
            customTreeView1.RootObject = new TreeViewObject(null, customTreeView1, this, "Demo Root", "Root");
            category1 = new TreeViewObject(customTreeView1.RootObject, customTreeView1, this,
                "enemy1", "EnemyCategory1");
            TreeViewObject item1 = new TreeViewObject(category1, customTreeView1, this,
                "item1", "Enemy1");
            item2 = new TreeViewObject(category1, customTreeView1, this,
                "item2", "Enemy2");

            TreeViewObject category2 = new TreeViewObject(customTreeView1.RootObject, customTreeView1, this,
                "enemy2", "EnemyCategory1");
            TreeViewObject item3 = new TreeViewObject(category2, customTreeView1, this,
                "item3", "Enemy1");
            TreeViewObject item4 = new TreeViewObject(category2, customTreeView1, this,
                "item4", "Enemy2");

            customTreeView1.TreeViewContainer = this;

        }

        public void OnSelectTreeViewObject(TreeViewObject obj,CustomTreeView treeView)
        {
            //MessageBox.Show(obj.Name);
        }

        private void customTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if()
        }

        private void button1_Click(object sender, EventArgs e)
        {
            category1.Name = "ten moi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            category1.Node.Remove();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        public void OnDelete(TreeViewObject obj, CustomTreeView treeView)
        {
        }

        public void OnProperty(TreeViewObject obj, CustomTreeView treeView)
        {
          //  MessageBox.Show(obj.Name);
        }

        public void OnFocus(TreeViewObject obj, CustomTreeView treeView)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TreeViewObject viewObject = new TreeViewObject(customTreeView1.RootObject,customTreeView1,
                this,"new", "EnemyCategory1"
                );
        }

        public void OnDoubleClick(TreeViewObject obj, CustomTreeView treeView)
        {
            throw new NotImplementedException();
        }
    }
}
