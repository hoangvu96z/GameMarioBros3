using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Ultils
{
    public static class RectangleExtension
    {
        public static Rectangle FromTwoCorner(Point FirstCorner,Point SecondCorner)
        {
            int left = Math.Min(FirstCorner.X, SecondCorner.X);
            int right = Math.Max(FirstCorner.X, SecondCorner.X);
            int top = Math.Min(FirstCorner.Y, SecondCorner.Y);
            int bottom = Math.Max(FirstCorner.Y, SecondCorner.Y);
            return Rectangle.FromLTRB(left, top, right, bottom);
        }
        public static Rectangle NormalizeRect(this Rectangle r)
        {
            if(r.Width<0)
            {
                r.X = r.X + r.Width;
                r.Width = -r.Width;
            }
            if(r.Height<0)
            {
                r.Y = r.Y + r.Height;
                r.Height = -r.Height;
            }
            return r;
        }
        public static RectangleF NormalizeRect(RectangleF r)
        {
            if (r.Width < 0)
            {
                r.X = r.X + r.Width;
                r.Width = -r.Width;
            }
            if (r.Height < 0)
            {
                r.Y = r.Y + r.Height;
                r.Height = -r.Height;
            }
            return r;
        }
    }
}
