using EditorV4.Models.V2;
using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Services
{
    public interface SelectTileFromWorldServiceInterface
    {
        Point SelectTileFromWorldLocation { get; set; }
        void RefreshCanvas();
        void SelectTile(int rowIndex, int colIndex);
        TilesModel TilesModel { get; }
        int TileWidth { get; }
        int TileHeight { get; }
    }
    [Serializable]
    public class SelectTileFromWorldService
    {
        IConvertWorldView _convertWorldView;
        SelectTileFromWorldServiceInterface @interface;

        public SelectTileFromWorldService(IConvertWorldView convertWorldView, SelectTileFromWorldServiceInterface @interface)
        {
            _convertWorldView = convertWorldView;
            this.@interface = @interface;
        }

        public void OnMouseDown(Point screenLocation)
        {
            var pt = _convertWorldView.GetWorldPointF(screenLocation).ToPoint();
            int rowIndex = pt.Y / @interface.TileHeight;
            int colIndex = pt.X / @interface.TileWidth;

            int tileIndex = @interface.TilesModel.Matrix[rowIndex, colIndex];

            int rowTilesheetIndex = tileIndex / @interface.TilesModel.TilesheetColumns;
            int colTilesheetIndex = tileIndex % @interface.TilesModel.TilesheetColumns;

            @interface.SelectTile(rowTilesheetIndex, colTilesheetIndex);
        }

        public void OnMouseMove(Point screenLocation)
        {
            @interface.SelectTileFromWorldLocation = _convertWorldView.GetWorldPointF(screenLocation).ToPoint();
            @interface.RefreshCanvas();
        }
    }
}
