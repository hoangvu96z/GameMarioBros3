using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface SelectTileFromWorldLayerInterface
    {
        Point SelectTileFromWorldLocation { get; }
        int TileWidth { get; }
        int TileHeight { get; }
        bool ActiveSelectTileFromWorld { get; }
        TilesModel TilesModel { get; }
    }
    [Serializable]
    public class SelectTileFromWorldLayer : IDrawableObject
    {
        SelectTileFromWorldLayerInterface @interface;

        public SelectTileFromWorldLayer(SelectTileFromWorldLayerInterface @interface)
        {
            this.@interface = @interface;
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
        }

        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            if (!@interface.ActiveSelectTileFromWorld)
                return;
            var tileRenderParent = @interface.TilesModel;
            int tileWidth = tileRenderParent.TileWidth;
            int tileHeight = tileRenderParent.TileHeight;
            int tileRows = tileRenderParent.TileRows;
            int tileColumns = tileRenderParent.TileColumns;
            int tileSheetColumns = tileRenderParent.TilesheetColumns;
            viewGraphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 30, 30, 30)),
                viewGraphics.ClipBounds);

            int rowIndex = @interface.SelectTileFromWorldLocation.Y / @interface.TileHeight;
            int colIndex = @interface.SelectTileFromWorldLocation.X / @interface.TileWidth;

            if (rowIndex < 0 || rowIndex >= tileRenderParent.TileRows
                || colIndex < 0 || colIndex >= tileRenderParent.TileColumns
                )
                return;

            int tileIndex = @interface.TilesModel.Matrix[rowIndex, colIndex];
            RectangleF cropedRect = new RectangleF((tileIndex % tileSheetColumns) * tileWidth,
                (tileIndex / tileSheetColumns) * tileHeight, tileWidth, tileHeight
                );

            var viewRect = new Rectangle(@interface.TileWidth*(@interface.SelectTileFromWorldLocation.X / @interface.TileWidth),
                @interface.TileHeight*( @interface.SelectTileFromWorldLocation.Y / @interface.TileHeight),
                @interface.TileWidth,
                @interface.TileHeight);

            viewRect = convertWorldView.GetViewRect(viewRect);

            viewGraphics.DrawImageFromOtherImage(tileRenderParent.Tilesheet
                , cropedRect, viewRect);
        }
    }
}
