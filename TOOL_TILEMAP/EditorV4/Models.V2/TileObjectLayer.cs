using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface TileObjectLayerInterface
    {
        List<int> TilesIndex { get; set; }
        int TileWidth { get; }
        int TileHeight { get; }
        Color TileObjectColor { get; }
        int TilesheetColumns { get; }
    }
    [Serializable]
    public class TileObjectLayer : IDrawableObject
    {
        TileObjectLayerInterface @interface;

        public TileObjectLayer(TileObjectLayerInterface @interface)
        {
            this.@interface = @interface;
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
        }

        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            foreach (var index in @interface.TilesIndex)
            {
                int col = index % @interface.TilesheetColumns;
                int row = index / @interface.TilesheetColumns;


                Rectangle rect = new Rectangle(col * @interface.TileWidth, row * @interface.TileHeight, @interface.TileWidth, @interface.TileHeight);

                Point viewLocation = viewViewport.GetWorldToViewLocation(new Point(col * @interface.TileWidth, row * @interface.TileHeight)).ToPoint();
                Size sizeValue = new Size((int)(@interface.TileWidth * viewViewport.Scale), (int)(@interface.TileHeight * viewViewport.Scale));

                var viewRect = new Rectangle(viewLocation, sizeValue);
                viewGraphics.DrawRectangle(new Pen(@interface.TileObjectColor, 2), viewRect);
            }
        }
    }
}
