using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface IGridInterface
    {
        Color GridColor { get; }
        bool CanRenderGrid { get; }
    }
    [Serializable]
    public class RenderGrid 
    {
        public IGridInterface GridInterface { get; set; }
        public void OnPaint(Graphics g, RectangleF viewport,float tileWidth, float tileHeight)
        {
            if (!GridInterface.CanRenderGrid)
                return;
            Color gridColor = GridInterface.GridColor;

            float yBegin = tileHeight * ((int)(viewport.Y / tileHeight) + 1) - viewport.Y;
            float yEnd = tileHeight * ((int)(viewport.Height / tileHeight));

            float[] dashValues = new float[] { 5, 1, 5, 5 }; ;
            Pen pen = new Pen(gridColor, 1);
            pen.DashPattern = dashValues;

            for (float y = yBegin; y <= yEnd; y += tileHeight)
            {
                g.DrawLine(pen, 0, y, viewport.Width, y);
            }

            float xBegin = (tileWidth * ((int)(viewport.X / tileWidth) + 1) - viewport.X);
            float xEnd = (tileWidth * ((int)(viewport.Width / tileWidth)));

            for (float x = xBegin; x <= xEnd; x += tileWidth)
            {
                g.DrawLine(pen, x, 0, x, viewport.Height);
            }
        }
    }
}
