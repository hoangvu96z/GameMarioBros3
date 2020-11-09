using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace EditorV4.Controls.TreeViewControl
{
    public interface ICustomTreeView
    {
        ImageList.ImageCollection Images { get; }
        int ImageSize { get; set; }
        int ItemMargin { get; set; }
        TreeViewObject RootObject { get; set; }
        ITreeViewContainer TreeViewContainer { get; set; }

        void AddImage(string key, Image image);
        void AddImage(string key, string path);
        void GetObjectData(SerializationInfo info, StreamingContext context);
        void OpenPropertyNode(TreeNode node);
        void RemoveNode(TreeNode node);
    }
}