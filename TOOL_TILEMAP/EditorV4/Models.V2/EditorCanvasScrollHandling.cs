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
    public interface IEditorCanvasScrollbar
    {
        float HValue { get; set; }
        float VValue { get; set; }
        float MaxHValue { get; set; }
        float MaxVValue { get; set; }
    }
    [Serializable]
    public class EditorCanvasScrollHandling
    {
        public IEditorCanvasScrollbar CanvasScrollbar { get; set; }
        public CanvasViewport Viewport { get; set; }
        public EditorCanvas Canvas { get; set; }

        public TestInterface TestInterface { get; set; }


        public Matrix ViewportToScrollTransform()
        {
            Matrix matrix = new Matrix();
            matrix.Scale(Viewport.Scale, Viewport.Scale);
            return matrix;
        }

        public PointF ViewportToScrollTransformPoint(PointF vpLocation)
        {
            var matrix = ViewportToScrollTransform();
            return matrix.TransformPoint(vpLocation);
        }

        public PointF ScrollToViewportTransformPoint(PointF scrollLocation)
        {
            var matrix = ViewportToScrollTransform();
            matrix.Invert();
            return matrix.TransformPoint(scrollLocation);
        }

        public void InvalidateViewport()
        {
            PointF viewportLocation = ScrollToViewportTransformPoint(new PointF(CanvasScrollbar.HValue, CanvasScrollbar.VValue));
            Viewport.X = CanvasScrollbar.HValue;
            Viewport.Y = CanvasScrollbar.VValue;

            if (TestInterface != null)
            {
                TestInterface.ViewportX = Viewport.X;
                TestInterface.ViewportY = Viewport.Y;
                TestInterface.ViewportWidth = Viewport.Width;
                TestInterface.ViewportHeight = Viewport.Height;
            }
        }

        public void InvalidateScrollValue()
        {
            CanvasScrollbar.HValue = Viewport.X;
            CanvasScrollbar.VValue = Viewport.Y;
        }

        public void InvalidateScrollMaxValue()
        {
            PointF scrollLocation = ViewportToScrollTransformPoint(new PointF(Canvas.Width, Canvas.Height));
            scrollLocation.X = (scrollLocation.X - Viewport.Width + 17).GreaterOrEqualThan(0);
            scrollLocation.Y = (scrollLocation.Y - Viewport.Height + 17).GreaterOrEqualThan(0);


            CanvasScrollbar.MaxHValue = (int)scrollLocation.X;
            CanvasScrollbar.MaxVValue = (int)scrollLocation.Y;

            if (TestInterface != null)
            {
                TestInterface.MaxHValue = CanvasScrollbar.MaxHValue;
                TestInterface.MaxVValue = CanvasScrollbar.MaxVValue;
            }
        }

    }
}
