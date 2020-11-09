using EditorV4.Controls.PropertyGridModel;
using EditorV4.Models.V2;
using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.EditorObjects
{
    [Serializable]
    public abstract class BaseObject : CustomClass, ISelectableObject
    {
        public BaseObject()
        {
            _border = new Rectangle(-1, -1, 0, 0);
        }

        protected Rectangle _border;
        [Browsable(false)]
        public Rectangle BoudingRect
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
            }
        }
        [Category("BoudingBox")]
        public int X
        {
            get
            {
                return _border.X;
            }
            set
            {
                if (!Resizeable && _border.X >= 0)
                    return;
                _border.X = value;
            }
        }
        [Category("BoudingBox")]
        public int Y
        {
            get
            {
                return _border.Y;
            }
            set
            {
                if (!Resizeable && _border.Y >= 0)
                    return;
                _border.Y = value;
            }
        }
        [Category("BoudingBox")]
        public int Width
        {
            get
            {
                return _border.Width;
            }
            set
            {
                if (!Resizeable && _border.Width > 0)
                    return;
                _border.Width = value;
            }
        }
        [Category("BoudingBox")]
        public int Height
        {
            get
            {
                return _border.Height;
            }
            set
            {
                if (!Resizeable && _border.Height > 0)
                    return;
                _border.Height = value;
            }
        }
        [Category("Properties")]
        public bool Resizeable
        {
            get;
            internal set;
        }
        [Category("Properties")]
        public bool Movable
        {
            get;
            internal set;
        }

        [Browsable(false)]
        public Point Location
        {
            get => _border.Location; set
            {
                _border.Location = value;
            }
        }
        [Browsable(false)]
        public Size Size
        {
            get => _border.Size; set
            {
                _border.Size = value;
            }
        }
        
        public void DrawBorder(Graphics g, IConvertWorldView convertWorldView)
        {
            //var border = convertWorldView.GetViewRect(_border);
            //g.DrawRectangle(new Pen(Color.LightYellow, 1), border);
        }

        public void DrawSelected(Graphics g, CanvasViewport viewport,IConvertWorldView convertWorldView)
        {
            var border = convertWorldView.GetViewRect(_border);
            PointF leftTop = new PointF((float)border.Location.X, (float)border.Location.Y);
            var widthHeight = new PointF((float)border.Width, (float)border.Height);
            PointF[] array = new PointF[]
            {
                leftTop,widthHeight
            };
            var selectPen = new Pen(Color.LightBlue, 3);
            selectPen.DashPattern = new float[] { 4.0F, 2.0F, 4.0F, 2.0F };
            var nR = RectangleExtension.NormalizeRect(border);
            g.DrawRectangle(selectPen, nR.X, nR.Y, nR.Width, nR.Height);
            selectPen = new Pen(Color.White, 1);
            g.DrawRectangle(selectPen, nR.X, nR.Y, nR.Width, nR.Height);
            if (Resizeable)
            {
                PointF tl = new PointF(border.Left, border.Top);
                ShapeHelper.RenderSizeCorner(g, tl);
                PointF tr = new PointF(border.Right, border.Top);
                ShapeHelper.RenderSizeCorner(g, tr);
                PointF bl = new PointF(border.Left, border.Bottom);
                ShapeHelper.RenderSizeCorner(g, bl);
                PointF br = new PointF(border.Right, border.Bottom);
                ShapeHelper.RenderSizeCorner(g, br);
            }
        }
        public void SetSizing(int sizingValue, Point ptBegin, Point ptEnd)
        {
            int v = 0, h = 0;
            PointSizeValueHelper.ToHV(sizingValue, ref h, ref v);
            Point oldPtEnd = ptEnd;
            if (v == -1)
            {
                ptEnd.Y = _border.Top + (ptEnd.Y - ptBegin.Y);
            }
            if (v == 1)
            {
                ptEnd.Y = _border.Bottom + (ptEnd.Y - ptBegin.Y);
            }
            if (h == -1)
            {
                ptEnd.X = _border.Left + (ptEnd.X - ptBegin.X);
            }
            if (h == 1)
            {
                ptEnd.X = _border.Right + (ptEnd.X - ptBegin.X);
            }

            float top = 0, left = 0, right = 0, bottom = 0;
            top = v == -1 ? ptEnd.Y : _border.Top;
            bottom = v == 1 ? ptEnd.Y : _border.Bottom;
            left = h == -1 ? ptEnd.X : _border.Left;
            right = h == 1 ? ptEnd.X : _border.Right;
            _border = Rectangle.FromLTRB((int)left, (int)top, (int)right, (int)bottom);
        }
        public int SizingPointValue(Point p)
        {
            PointF tl = new PointF(_border.Left, _border.Top);
            PointF tr = new PointF(_border.Right, _border.Top);
            PointF bl = new PointF(_border.Left, _border.Bottom);
            PointF br = new PointF(_border.Right, _border.Bottom);

            Rectangle rtl = ShapeHelper.GetRectCorner(tl);
            Rectangle rtr = ShapeHelper.GetRectCorner(tr);
            Rectangle rbl = ShapeHelper.GetRectCorner(bl);
            Rectangle rbr = ShapeHelper.GetRectCorner(br);

            Rectangle hl = Rectangle.FromLTRB(rtl.Left, rtl.Bottom,
                rtl.Right, rbl.Top);
            Rectangle hr = Rectangle.FromLTRB(rtr.Left, rtr.Bottom,
                rtr.Right, rbr.Top);

            Rectangle vt = Rectangle.FromLTRB(rtl.Right, rtl.Top,
                rtr.Left, rtr.Bottom);
            Rectangle vb = Rectangle.FromLTRB(rbl.Right, rbl.Top,
                rbr.Left, rbr.Bottom);



            if (rtl.Contains(p))
            {
                return PointSizeValueHelper.FromHV(-1, -1);
            }
            if (rtr.Contains(p))
            {
                return PointSizeValueHelper.FromHV(1, -1);
            }
            if (rbl.Contains(p))
            {
                return PointSizeValueHelper.FromHV(-1, 1);
            }
            if (rbr.Contains(p))
            {
                return PointSizeValueHelper.FromHV(1, 1);
            }
            if (hl.Contains(p))
            {
                return PointSizeValueHelper.FromHV(-1, 0);
            }
            if (hr.Contains(p))
            {
                return PointSizeValueHelper.FromHV(1, 0);
            }
            if (vt.Contains(p))
            {
                return PointSizeValueHelper.FromHV(0, -1);
            }
            if (vb.Contains(p))
            {
                return PointSizeValueHelper.FromHV(0, 1);
            }

            return -1;
        }
        public bool CanSelectByPoint(Point p)
        {
            return _border.NormalizeRect().Contains(p);
        }
        public abstract void OnPaint(Graphics g, CanvasViewport camera);
        public void Move(Point delta)
        {
            _border.X += delta.X;
            _border.Y += delta.Y;
        }
        public virtual void OnPaintInView(Graphics viewGraphics, CanvasViewport viewport, IConvertWorldView convertWorldView)
        {
            DrawBorder(viewGraphics, convertWorldView);
        }
    }
}
