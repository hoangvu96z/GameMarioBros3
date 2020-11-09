using System.Drawing;
using System.Runtime.Serialization;
using EditorV4.Models.V2;

namespace EditorV4.Controls
{
    public interface ICanvasScrollControl1
    {
        ICanvasScrollParent CanvasScrollParent { get; set; }
        IConvertWorldView ConvertWorldView { get; set; }
        PointF CurrentMovePoint { get; set; }
        float HValue { get; set; }
        float MaxHValue { get; set; }
        float MaxVValue { get; set; }
        TestInterface TestInterface { get; set; }
        float VValue { get; set; }
        int WorldHeight { get; set; }
        int WorldWidth { get; set; }

        void GetObjectData(SerializationInfo info, StreamingContext context);
        void LoadTileMapFromExisitingFile(string imagePath, ILoaderInterface loaderInterface);
        void SetVisibleHScrollbar(bool visible);
        void SetVisibleVScrollbar(bool visible);
        void UpdateScroll();
    }
}