using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    [Serializable]
    public class RenderPixelRuler
    {
        public bool IsRenderPixelRuler = false;
        public void OnPaint(Graphics g, RectangleF viewport, float tileWidth, float tileHeight)
        {
            if (!IsRenderPixelRuler)
                return;
            Color gridColor = Color.Black;

            int yBegin = (int)(tileHeight * ((int)(viewport.Y / tileHeight) + 1) - viewport.Y);
            int yEnd = (int)(tileHeight * ((int)(viewport.Height / tileHeight)));

            Pen pen = new Pen(gridColor, 1);

            for (float y = yBegin; y <= yEnd; y += tileHeight)
            {
                g.DrawLine(pen, 0, y, viewport.Width, y);
            }

            int xBegin = (int)(tileWidth * ((int)(viewport.X / tileWidth) + 1) - viewport.X);
            int xEnd = (int)(tileWidth * ((int)(viewport.Width / tileWidth)));

            for (float x = xBegin; x <= xEnd; x += tileWidth)
            {
                g.DrawLine(pen, x, 0, x, viewport.Height);
            }
        }
    }
}
