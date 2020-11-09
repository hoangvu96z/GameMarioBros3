using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    [Serializable]
    public class MouseMovingBase
    {
        public PointF FirstCorner { get; set; }
        public PointF SecondCorner { get; set; }
        public Point Delta
        {
            get
            {
                return new Point((int)(SecondCorner.X - FirstCorner.X), (int)(SecondCorner.Y - FirstCorner.Y));
            }
        }

        public Rectangle BoudingRect
        {
            get
            {
                int left = (int)Math.Min(FirstCorner.X, SecondCorner.X);
                int right = (int)Math.Max(FirstCorner.X, SecondCorner.X);
                int top = (int)Math.Min(FirstCorner.Y, SecondCorner.Y);
                int bottom = (int)Math.Max(FirstCorner.Y, SecondCorner.Y);
                return Rectangle.FromLTRB(left, top, right, bottom);
            }
        }

        public int SizingValue { get; set; }
        public bool Active { get; set; }
    }
}
