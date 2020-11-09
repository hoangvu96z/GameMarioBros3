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
    [Serializable]
    public class CanvasViewport
    {
        #region PRIVATE_MEMBER

        private float _x;
        private float _y;
        private float _width;
        private float _height;
        private IViewportLimit _viewportLimit;

        #endregion

        #region CONSTRUCTOR


        public CanvasViewport(float x, float y, float width, float height, IViewportLimit viewportLimit)
        {
            _viewportLimit = viewportLimit;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Scale = 1.0f;
        }

        #endregion

        #region PROPERTY


        public float X
        {
            get { return _x; }
            set
            {
                _x = value.SmallerOrEqualThan(_viewportLimit.Right - Width).GreaterOrEqualThan(_viewportLimit.Left);
            }
        }

        public float Y
        {
            get { return _y; }
            set {
                _y = value.SmallerOrEqualThan(_viewportLimit.Bottom - Height).GreaterOrEqualThan(_viewportLimit.Top);
            }
        }

        public float Width
        {
            get { return _width; }
            set
            {
                _width = Math.Min(value, _viewportLimit.Right);
                X = X;
            }
        }

        public float Height
        {
            get { return _height; }
            set
            {
                _height = Math.Min(value, _viewportLimit.Bottom);
                Y = Y;
            }
        }

        public int Left
        {
            get
            {
                return (int)X;
            }
        }
        public int Right
        {
            get
            {
                return (int)(X + Width);
            }
        }
        public int Top
        {
            get
            {
                return (int)Y;
            }
        }
        public int Bottom
        {
            get
            {
                return (int)(Y + Height);
            }
        }

        public RectangleF BoudingRect
        {
            get
            {
                return new RectangleF(X, Y, Width, Height);
            }
        }

        public float Scale { get; set; }

        public Size RealSize
        {
            get { return new Size((int)(Width * Scale), (int)(Height * Scale)); }
        }

        #endregion

        #region METHOD

        /// <summary>
        /// Ma tran bien doi world to view
        /// </summary>
        /// <returns></returns>
        public Matrix GetWorldToViewMatrix()
        {
            Matrix worldToViewMatrix = new Matrix();
            worldToViewMatrix.Translate(-X, -Y, MatrixOrder.Append);
            if(Scale>1)
            {
                Scale = (int)Scale;
            }
            worldToViewMatrix.Scale(Scale, Scale, MatrixOrder.Append);
            return worldToViewMatrix;
        }
        /// <summary>
        /// tinh toa do view tu toa do world
        /// </summary>
        /// <param name="worldLocation"></param>
        /// <returns></returns>
        public PointF GetWorldToViewLocation(PointF worldLocation)
        {
            var matrix = GetWorldToViewMatrix();
            var pts = new PointF[] { worldLocation };
            matrix.TransformPoints(pts);
            return pts[0];
        }

        /// <summary>
        /// tinh toa do world tu toa do view
        /// </summary>
        /// <param name="viewLocation"></param>
        /// <returns></returns>
        public PointF GetViewToWorldLocation(PointF viewLocation)
        {
            var matrix = GetWorldToViewMatrix();
            matrix.Invert();
            var pts = new PointF[] { viewLocation };
            matrix.TransformPoints(pts);
            return pts[0];
        }

        #endregion
    }
}
