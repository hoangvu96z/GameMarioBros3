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
    public interface IConvertWorldView
    {
        Matrix GetWorldToViewMatrix();
    }

    public static class ConvertWorldViewHelper
    {
        public static PointF GetViewPointF(this IConvertWorldView t,PointF worldLocation)
        {
            Matrix matrix = t.GetWorldToViewMatrix();
            return matrix.TransformPoint(worldLocation);
        }
        public static Point GetViewPoint(this IConvertWorldView t, PointF worldLocation)
        {
            PointF p = t.GetViewPoint(worldLocation);
            return new Point((int)p.X, (int)p.Y);
        }

        public static PointF GetWorldPointF(this IConvertWorldView t, PointF viewLocation)
        {
            Matrix matrix = t.GetWorldToViewMatrix();
            matrix.Invert();
            return matrix.TransformPoint(viewLocation);
        }
        public static Point GetWorldPoint(this IConvertWorldView t, PointF viewLocation)
        {
            PointF p = t.GetWorldPointF(viewLocation);
            return new Point((int)p.X, (int)p.Y);
        }

        public static Rectangle GetViewRect(this IConvertWorldView t, RectangleF worldRect)
        {
            PointF pt = worldRect.Location ;
            PointF ptRB = new PointF(worldRect.Right, worldRect.Bottom);
            PointF[] pts = new PointF[] { pt, ptRB };
            Matrix matrix = t.GetWorldToViewMatrix();
            matrix.TransformPoints(pts);
            return Rectangle.FromLTRB((int)pts[0].X, (int)pts[0].Y, (int)pts[1].X, (int)pts[1].Y).NormalizeRect();
        }
    }

}
