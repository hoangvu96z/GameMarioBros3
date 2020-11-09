using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditorV4.Ultils
{
    public static class ShapeHelper
    {
        static int SIZE_CORNER_SIZE = 5;
        public static Rectangle GetRectCorner(PointF p)
        {
            return new Rectangle((int)p.X - SIZE_CORNER_SIZE, (int)p.Y - SIZE_CORNER_SIZE, 2 * SIZE_CORNER_SIZE, 2 * SIZE_CORNER_SIZE);
        }

        public static Point ToPoint(this PointF pt)
        {
            return new Point((int)pt.X, (int)pt.Y);
        }

        public static void RenderSizeCorner(Graphics g, PointF p)
        {
            var r = ShapeHelper.GetRectCorner(p);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(new Pen(Color.Black, 1), r);
        }
    }

    public class PointSizeValueHelper
    {
        public static int FromHV(int h, int v)
        {
            return (h + 1) * 10 + (v + 1);
        }
        public static void ToHV(int val, ref int h, ref int v)
        {
            h = val / 10 - 1;
            v = val % 10 - 1;
        }

        public static Cursor GetCursor(int sizingValue)
        {
            int h = 0, v = 0;
            ToHV(sizingValue, ref h, ref v);

            if (h * v == 1)
            {
                return Cursors.SizeNWSE;
            }
            if (h * v == -1)
            {
                return Cursors.SizeNESW;
            }
            if (h == 0)
            {
                return Cursors.SizeNS;
            }
            if (v == 0)
            {
                return Cursors.SizeWE;
            }
            return Cursors.Arrow;
        }
    }
}
