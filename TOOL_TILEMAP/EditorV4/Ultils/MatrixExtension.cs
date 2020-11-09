using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Ultils
{
    public static class MatrixExtension
    {
        public static PointF TransformPoint(this Matrix matrix, PointF pt)
        {
            PointF[] pts = new PointF[] { pt };
            matrix.TransformPoints(pts);
            return pts[0];
        }
    }
}
