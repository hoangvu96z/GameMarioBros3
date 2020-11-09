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
    public class EditorCanvasRender
    {
        public EditorCanvas Canvas { get; set; }
        public CanvasViewport Viewport { get; set; }
        public ITilesModelParent TilesModelParent { get; set; }
        public bool IsRenderGrid { get; set; }
        public RenderGrid RenderGrid { get; set; }

        public RenderPixelRuler RenderPixelRuler { get; set; }


        public EditorCanvasRender()
        {
            IsRenderGrid = true;
            RenderPixelRuler = new RenderPixelRuler();
        }

        public virtual void RenderViewport(Graphics g, IConvertWorldView convertWorldView)
        {
            switch (Canvas.CanvasState)
            {
                case CanvasState.NONE:
                    RenderNoneCanvas(g);
                    break;
                case CanvasState.DRAWABLE:
                    OnPaint(g, convertWorldView);
                    break;
            }


        }

        public virtual void OnPaint(Graphics g, IConvertWorldView convertWorldView)
        {
            Image backBuffer = new Bitmap((int)Viewport.Width, (int)Viewport.Height);
            Canvas.OnPaint(Graphics.FromImage(backBuffer), Viewport);
            var realRect = new RectangleF(PointF.Empty, Viewport.RealSize);
            var viewRect = new RectangleF(PointF.Empty, new SizeF(Viewport.Width, Viewport.Height));
            g.DrawImageFromOtherImage(backBuffer, viewRect, realRect);
            var gridRect = new RectangleF((Viewport.X * Viewport.Scale), (Viewport.Y * Viewport.Scale), Viewport.Width * Viewport.Scale, Viewport.Height * Viewport.Scale);
            RenderPixelRuler.OnPaint(g, gridRect, Viewport.Scale, Viewport.Scale);
            if (IsRenderGrid && TilesModelParent != null && convertWorldView!=null)
            {
                RenderGrid.OnPaint(g, gridRect, (TilesModelParent.TileWidth * Viewport.Scale),
                   (TilesModelParent.TileHeight * Viewport.Scale)
                    );
            }
            Canvas.OnPaintInView(g, Viewport,convertWorldView);
            backBuffer.Dispose();
        }

        public virtual void RenderNoneCanvas(Graphics g)
        {
            g.Clear(Color.White);
            int tileWidth = 10;
            int tileHeight = 10;

            int cBegin = (int)(Viewport.X) / tileWidth;
            int cEnd = (int)(Viewport.X + Canvas.Width) / tileWidth;
            int rBegin = (int)(Viewport.Y) / tileHeight;
            int rEnd = (int)(Viewport.Y + Canvas.Height) / tileHeight;
            var currentPos = new PointF(cBegin * tileWidth - Viewport.X, rBegin * tileHeight - Viewport.Y);
            Color oddColor = Color.White;
            Color evenColor = Color.DarkGray;
            int startX = (int)currentPos.X;
            currentPos.X = (int)(currentPos.X);
            currentPos.Y = (int)(currentPos.Y);
            for (int rI = rBegin; rI <= rEnd; rI++)
            {
                currentPos.X = startX;
                for (int cI = cBegin; cI < cEnd; cI++)
                {
                    if ((cI + rI) % 2 != 0)
                    {
                        g.FillRectangle(new SolidBrush(oddColor), new RectangleF(currentPos, new SizeF(tileWidth, tileHeight)));
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(evenColor), new RectangleF(currentPos, new SizeF(tileWidth, tileHeight)));
                    }
                    currentPos.X += tileWidth;
                }
                currentPos.Y += tileHeight;
            }
        }
    }
}
