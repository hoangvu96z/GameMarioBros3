using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Controls.TreeViewControl
{
    public interface ITreeViewContainer
    {
        void OnSelectTreeViewObject(TreeViewObject obj,CustomTreeView treeView);
        void OnDelete(TreeViewObject obj, CustomTreeView treeView);
        void OnProperty(TreeViewObject obj, CustomTreeView treeView);
        void OnFocus(TreeViewObject obj, CustomTreeView treeView);
        void OnDoubleClick(TreeViewObject obj, CustomTreeView treeView);
    }
}
