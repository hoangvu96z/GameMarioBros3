using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    [Serializable]
    public class TileRender 
    {
        public int[,] Matrix
        {
            get
            {
                return TileRenderParent.Matrix;
            }
        }
        ITilesModel _tileRenderParent;
        public ITilesModel TileRenderParent
        {
            get
            {
                return _tileRenderParent;
            }
            set
            {
                _tileRenderParent = value;
            }
        }

        public Image Tilesheet { get { return TileRenderParent.Tilesheet; } }

        public Bitmap GetImage(Graphics g,Graphics viewGraphics, CanvasViewport viewport)
        {
            if (TileRenderParent == null)
            {
                return null;
            }
            int tileWidth = TileRenderParent.TileWidth;
            int tileHeight = TileRenderParent.TileHeight;
            int tileRows = TileRenderParent.TileRows;
            int tileColumns = TileRenderParent.TileColumns;
            int tileSheetColumns = TileRenderParent.TilesheetColumns;

            int cBegin = (int)viewport.X / tileWidth;
            int cEnd = viewport.Right / tileWidth + 1;

            int rBegin = (int)viewport.Y / tileHeight;
            int rEnd = (int)viewport.Bottom / tileHeight + 1;

            if (cEnd > tileColumns)
            {
                cEnd = tileColumns;
            }
            if (rEnd > tileRows)
            {
                rEnd = tileRows;
            }

            int xWorld = cBegin * tileWidth;
            int yWorld = rBegin * tileHeight;

            float xRender = 0;
            float yRender = 0;
            float xBegin = xRender;

            Bitmap tileBitmap = new Bitmap((cEnd - cBegin) * tileWidth, (rEnd - rBegin) * tileHeight);

            for (int rIndex = rBegin; rIndex < rEnd; rIndex++)
            {
                xRender = xBegin;
                for (int cIndex = cBegin; cIndex < cEnd; cIndex++)
                {

                    int index = Matrix[rIndex, cIndex];
                    RectangleF cropedRect = new RectangleF((index % tileSheetColumns) * tileWidth,
                        (index / tileSheetColumns) * tileHeight, tileWidth, tileHeight
                        );
                    RectangleF locationRect = new RectangleF(xRender, yRender, tileWidth, tileHeight);
                    Graphics.FromImage(tileBitmap).DrawImageFromOtherImage(Tilesheet, cropedRect, locationRect);
                    xRender += tileWidth;
                }
                yRender += tileHeight;
            }

            return tileBitmap;


        }

        public Bitmap World
        {
            get
            {
                if (TileRenderParent == null)
                {
                    return null;
                }
                Bitmap result = new Bitmap(TileRenderParent.TileColumns * TileRenderParent.TileWidth,
                    TileRenderParent.TileRows * TileRenderParent.TileHeight);
                CanvasViewport viewport = new CanvasViewport(0, 0, result.Width, result.Height,
                    new SimpleViewportLimit(0, 0, result.Width, result.Height));
         //       OnPaint(Graphics.FromImage(result), viewport);
                return result;
            }
        }
    }
}
