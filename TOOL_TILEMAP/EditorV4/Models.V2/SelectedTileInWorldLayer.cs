using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface SelectedTileInWorldLayerInterface
    {
        int SelectedTileIndex { get; }
        Color SelectedTileInWorldColor { get; }
        bool CanAddTile { get; }
        Point TilePrepareAddLocation { get; }
        TilesModel TilesModel { get; }
    }
    [Serializable]
    public class SelectedTileInWorldLayer : IDrawableObject
    {
        SelectedTileInWorldLayerInterface @interface;

        public SelectedTileInWorldLayer(SelectedTileInWorldLayerInterface @interface)
        {
            this.@interface = @interface;
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
        }

        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            int selectedTileIndex = @interface.SelectedTileIndex;
            if (@interface.SelectedTileIndex == -1)
                return;
            int nRows = @interface.TilesModel.TileRows;
            int nColumns = @interface.TilesModel.TileColumns;
            int tileWidth = @interface.TilesModel.TileWidth;
            int tileHeight = @interface.TilesModel.TileHeight;
            var worldMatrix = @interface.TilesModel.Matrix;
            Point prepareLocation = @interface.TilePrepareAddLocation;
            for (int rIndex = 0; rIndex < nRows; rIndex++)
            {
                for (int cIndex = 0; cIndex < nColumns; cIndex++)
                {
                    if(worldMatrix[rIndex,cIndex] == @interface.SelectedTileIndex)
                    {
                        Rectangle locationRect = new Rectangle(cIndex * tileWidth, rIndex * tileHeight, tileWidth, tileHeight);
                        locationRect = convertWorldView.GetViewRect(locationRect);
                        viewGraphics.DrawRectangle(new Pen(@interface.SelectedTileInWorldColor, 2),
                            locationRect);
                        viewGraphics.FillRectangle(new SolidBrush(Color.FromArgb(50, @interface.SelectedTileInWorldColor.R, @interface.SelectedTileInWorldColor.G, @interface.SelectedTileInWorldColor.B)), locationRect);
                    }
                }
            }

            if(@interface.CanAddTile)
            {
                int rIndex = prepareLocation.Y / tileHeight;
                int cIndex = prepareLocation.X / tileWidth;

                Rectangle locationRect = new Rectangle(cIndex * tileWidth, rIndex * tileHeight, tileWidth, tileHeight);
                locationRect = convertWorldView.GetViewRect(locationRect);
                viewGraphics.DrawRectangle(new Pen(@interface.SelectedTileInWorldColor, 2),
                    locationRect);

                var cropRect = new Rectangle(tileWidth * (selectedTileIndex % @interface.TilesModel.TilesheetColumns),
                    tileHeight * (selectedTileIndex / @interface.TilesModel.TilesheetColumns), tileWidth, tileHeight
                    );

                viewGraphics.DrawImageFromOtherImage(@interface.TilesModel.Tilesheet, cropRect, locationRect);


            }
        }
    }
}
