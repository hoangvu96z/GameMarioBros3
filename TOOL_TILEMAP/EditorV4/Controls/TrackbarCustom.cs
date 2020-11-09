using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Controls
{
    public class TrackbarCustom : TrackBar
    {
        public TrackbarCustom() : base()
        {
            this.SetStyle(
    ControlStyles.AllPaintingInWmPaint |
    ControlStyles.UserPaint |
    ControlStyles.DoubleBuffer,
    true);
            AutoSize = false;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;
                path.AddArc(d + Height / 2, d + 3, r, r - 6, 90, 180);
                path.AddArc(this.Width - r - d - Height / 2, d + 3, r, r - 6, -90, 180);
                path.CloseFigure();
                e.Graphics.FillPath(new SolidBrush(Color.FromArgb(247, 215, 168)), path);

                var x = Width * (Value - Minimum) / (Maximum - Minimum);
                var rect = new Rectangle(x, 0, Height, Height);
                e.Graphics.FillEllipse(Brushes.OrangeRed, rect);
            }
        }
    }
}
