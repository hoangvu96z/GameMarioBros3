using System.Drawing;

namespace EditorV4.Models.V2
{
    public interface ITilesModel
    {
        int TileWidth { get; }
        int TileHeight { get; }
        int TileRows { get; set; }
        int TileColumns { get; set; }
        int TilesheetColumns { get; set; }
        Image Tilesheet { get; set; }
        int[,] Matrix { get; set; }
    }
}
