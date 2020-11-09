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
    public interface IPaddingCanvasGroupParent
    {
        bool IsControlDown { get; }
        int TileWidth { get; }
        int TileHeight { get; }
        bool CanRenderGrid { get; }
        TilesModel TilesModel { get;set;}
    }
    [Serializable]
    public class PaddingCanvasGroup : CanvasViewGroup, ITilesModelParent, IGridInterface, IConvertWorldView
    {
        public PaddingCanvasGroup(IEditorCanvasScrollbar scrollbar, int vpWidth, int vpHeight, IPaddingCanvasGroupParent @interface)
            : base(scrollbar, vpWidth, vpHeight)
        {
            WorldViewGroup = new CanvasViewGroup(scrollbar, vpWidth, vpHeight);
            PaddingTop = PaddingLeft = PaddingRight = PaddingBottom = 500;
            InvalidateCanvasSize();
            EditorCanvasScrollHandling.InvalidateScrollMaxValue();
            PaddingCanvasGroupParent = @interface;
            TilesModel = new TilesModel();
            TilesModel.ITilesModelParent = this;

            WorldViewGroup.EditorCanvasRender.TilesModelParent = this;

            WorldViewGroup.EditorCanvasRender.RenderGrid = new RenderGrid();
            WorldViewGroup.EditorCanvasRender.RenderGrid.GridInterface = this;
        }

        public int TileWidth
        {
            get { return PaddingCanvasGroupParent.TileWidth; }
        }
        public int TileHeight
        {
            get { return PaddingCanvasGroupParent.TileHeight; }
        }

        public void InvalidateCanvasSize()
        {
            PointF canvasWorldSize = new PointF(WorldViewGroup.EditorCanvas.Width, WorldViewGroup.EditorCanvas.Height);
            var canvasViewSize = WorldViewGroup.EditorCanvasScrollHandling.ViewportToScrollTransformPoint(canvasWorldSize);
            EditorCanvas.Width = (int)canvasViewSize.X + PaddingLeft + PaddingRight;
            EditorCanvas.Height = (int)canvasViewSize.Y + PaddingTop + PaddingBottom;

        }

        public TilesModel TilesModel
        {
            get
            {
                return PaddingCanvasGroupParent.TilesModel;
            }
            set
            {
                PaddingCanvasGroupParent.TilesModel = value;
            }
        }

        public TestInterface TestInterface { get; set; }

        public IPaddingCanvasGroupParent PaddingCanvasGroupParent { get; set; }

        public CanvasViewGroup WorldViewGroup { get; set; }

        public TileRender TileRender { get; set; }

        public void LoadTileMapFromExisitingFile(string imagePath, ILoaderInterface loaderInterface)
        {
            TilesModel.LoadFromExistingFile(imagePath, loaderInterface);
        }

        public void LoadTileRender()
        {
            TileRender = new TileRender();
            TileRender.TileRenderParent = TilesModel;
            WorldViewGroup.EditorCanvas.Width = TilesModel.TileColumns * TileWidth;
            WorldViewGroup.EditorCanvas.Height = TilesModel.TileRows * TileHeight;
            WorldViewGroup.EditorCanvas.CanvasState = CanvasState.DRAWABLE;
        }

        public Matrix WorldToPaddingCanvasTransform()
        {
            var matrix = new Matrix();
            matrix.Scale(WorldViewGroup.CanvasViewport.Scale, WorldViewGroup.CanvasViewport.Scale, MatrixOrder.Append);
            matrix.Translate(PaddingLeft, PaddingTop, MatrixOrder.Append);
            return matrix;
        }
        /// <summary>
        /// bien doi 1 diem tren world game thanh 1 diem tren world cua padding control
        /// </summary>
        /// <param name="worldPoint"></param>
        /// <returns></returns>
        public PointF WorldToPaddingCanvasPoint(PointF worldPoint)
        {
            Matrix matrix = WorldToPaddingCanvasTransform();
            return matrix.TransformPoint(worldPoint);
        }
        /// <summary>
        /// bien doi 1 diem tren world của padding control thanh 1 diem tren world game
        /// </summary>
        /// <param name="paddingCanvasPoint"></param>
        /// <returns></returns>
        public PointF PaddingCanvasToWorldPoint(PointF paddingCanvasPoint)
        {
            Matrix matrix = WorldToPaddingCanvasTransform();
            matrix.Invert();
            return matrix.TransformPoint(paddingCanvasPoint);
        }

        public PointF GetWorldPointFromPaddingCanvasViewPoint(PointF viewPoint)
        {
            // Padding Canvas View to Padding Canvas World Matrix
            Matrix matrix = CanvasViewport.GetWorldToViewMatrix();
            matrix.Invert();

            // Padding Canvas World Matrix to World matrix
            var paddingCanvasWorldToWorldTransform = WorldToPaddingCanvasTransform();
            paddingCanvasWorldToWorldTransform.Invert();

            matrix.Multiply(paddingCanvasWorldToWorldTransform, MatrixOrder.Append);
            return matrix.TransformPoint(viewPoint);
        }

        public PointF GetPaddingCanvasViewPointFromWorldPoint(PointF worldPoint)
        {
            // Padding Canvas View to Padding Canvas World Matrix
            Matrix matrix = CanvasViewport.GetWorldToViewMatrix();
            matrix.Invert();
            // Padding Canvas World Matrix to World matrix
            var paddingCanvasWorldToWorldTransform = WorldToPaddingCanvasTransform();
            paddingCanvasWorldToWorldTransform.Invert();
            matrix.Multiply(paddingCanvasWorldToWorldTransform, MatrixOrder.Append);

            matrix.Invert();
            return matrix.TransformPoint(worldPoint);
        }


        protected RectangleF GetInterserctRect()
        {
            PointF worldSize = new PointF(WorldViewGroup.EditorCanvas.Width, WorldViewGroup.EditorCanvas.Height);
            var worldViewSize = WorldViewGroup.EditorCanvasScrollHandling.ViewportToScrollTransformPoint(worldSize);
            RectangleF interserctRect = new RectangleF(PaddingLeft, PaddingTop, worldViewSize.X, worldViewSize.Y);
            RectangleF viewportRect = CanvasViewport.BoudingRect;
            interserctRect.Intersect(viewportRect);
            return interserctRect;
        }

        public void InvalidateWorldViewport()
        {
            RectangleF interserctRect = GetInterserctRect();

            PointF viewSize = WorldViewGroup.EditorCanvasScrollHandling.ScrollToViewportTransformPoint(new PointF(interserctRect.Width, interserctRect.Height));

            WorldViewGroup.CanvasViewport.Width = (int)viewSize.X;
            WorldViewGroup.CanvasViewport.Height = (int)viewSize.Y;

            PointF origin = new PointF(CanvasViewport.X, CanvasViewport.Y);
            PointF worldPoint = PaddingCanvasToWorldPoint(origin);
            WorldViewGroup.CanvasViewport.X = (worldPoint.X).GreaterOrEqualThan(0);
            WorldViewGroup.CanvasViewport.Y = (worldPoint.Y).GreaterOrEqualThan(0);

            if (TestInterface != null)
            {
                TestInterface.ViewportiX = WorldViewGroup.CanvasViewport.X;
                TestInterface.ViewportiY = WorldViewGroup.CanvasViewport.Y;
                TestInterface.ViewportiWidth = WorldViewGroup.CanvasViewport.Width;
                TestInterface.ViewportiHeight = WorldViewGroup.CanvasViewport.Height;
            }
        }

        public override void OnPaint(Graphics graphics, IConvertWorldView convertWorldView)
        {
            InvalidateWorldViewport();
            if (WorldViewGroup.CanvasViewport.Width * WorldViewGroup.CanvasViewport.Height == 0)
            {
                graphics.Clear(Color.FromArgb(207, 207, 207));
                return;
            }
            Color borderColor = Color.FromArgb(194, 194, 194);
            var realSize = WorldViewGroup.CanvasViewport.RealSize;
            Image worldBitmap = new Bitmap((int)realSize.Width, (int)realSize.Height);
            graphics.Clear(Color.FromArgb(207, 207, 207));

            RectangleF interserctRect = GetInterserctRect();
            PointF renderLocation = new PointF(PaddingLeft, PaddingTop);
            renderLocation = CanvasViewport.GetWorldToViewLocation(renderLocation);
            renderLocation.X = (renderLocation.X).GreaterOrEqualThan(0);
            renderLocation.Y = (renderLocation.Y).GreaterOrEqualThan(0);

            if (TileRender != null)
            {
                Image tileImage = TileRender.GetImage(Graphics.FromImage(worldBitmap), graphics, WorldViewGroup.CanvasViewport);
                int cBegin = (int)WorldViewGroup.CanvasViewport.X / TileWidth;
                int rBegin = (int)WorldViewGroup.CanvasViewport.Y / TileHeight;

                RectangleF rectCrop = new RectangleF(WorldViewGroup.CanvasViewport.X - cBegin * TileWidth - 0.5f,
                    WorldViewGroup.CanvasViewport.Y - rBegin * TileHeight - 0.5f,
                    WorldViewGroup.CanvasViewport.Width, WorldViewGroup.CanvasViewport.Height);
                graphics.DrawImageFromOtherImage(tileImage, rectCrop,
        new RectangleF(renderLocation, interserctRect.Size));
            }


            WorldViewGroup.OnPaint(Graphics.FromImage(worldBitmap), convertWorldView);

            graphics.DrawImageFromOtherImage(worldBitmap, new RectangleF(0, 0, worldBitmap.Width, worldBitmap.Height),
                new RectangleF(renderLocation, interserctRect.Size));

            PointF firstCorner = new PointF(PaddingLeft, PaddingTop);
            PointF lastCorner = new PointF(PaddingLeft + WorldViewGroup.EditorCanvas.Width * WorldViewGroup.CanvasViewport.Scale,
                PaddingTop + WorldViewGroup.EditorCanvas.Height * WorldViewGroup.CanvasViewport.Scale);

            firstCorner = CanvasViewport.GetWorldToViewLocation(firstCorner);
            lastCorner = CanvasViewport.GetWorldToViewLocation(lastCorner);

            RectangleF r = RectangleF.FromLTRB(firstCorner.X, firstCorner.Y, lastCorner.X, lastCorner.Y);

            graphics.DrawRectangle(new Pen(borderColor, 1), r.X, r.Y, r.Width, r.Height);
        }

        bool _isControlEnter;
        PointF _anchorPointWorld;

        public bool IsControlEnter { set { _isControlEnter = value; } }

        internal void OnZoom(float zoomValue, PointF anchorPoint)
        {
            if (!_isControlEnter && PaddingCanvasGroupParent.IsControlDown)
            {
                _isControlEnter = true;
                _anchorPointWorld = GetWorldPointFromPaddingCanvasViewPoint(anchorPoint);
            }
            //anchorPoint = _anchorPointView;

            //anchorPointWorld.X = (int)anchorPointWorld.X;
            //anchorPointWorld.Y = (int)anchorPointWorld.Y;

            if (TestInterface != null)
            {
                TestInterface.WorldMouseX = _anchorPointWorld.X;
                TestInterface.WorldMouseY = _anchorPointWorld.Y;
            }

            WorldViewGroup.CanvasViewport.Scale = zoomValue;
            InvalidateCanvasSize();
            EditorCanvasScrollHandling.InvalidateScrollMaxValue();

            PointF anchorPointNew = GetPaddingCanvasViewPointFromWorldPoint(_anchorPointWorld);
            PointF expectedViewportInView = new PointF(anchorPointNew.X - anchorPoint.X, anchorPointNew.Y - anchorPoint.Y);
            PointF expectedViewportInWorld = CanvasViewport.GetViewToWorldLocation(expectedViewportInView);

            EditorCanvasScrollHandling.CanvasScrollbar.HValue = expectedViewportInWorld.X;
            EditorCanvasScrollHandling.CanvasScrollbar.VValue = expectedViewportInWorld.Y;
        }

        public Matrix GetWorldToViewMatrix()
        {
            Matrix matrix = new Matrix();
            matrix.Scale(WorldViewGroup.CanvasViewport.Scale, WorldViewGroup.CanvasViewport.Scale, MatrixOrder.Append);
            matrix.Translate(PaddingLeft, PaddingTop, MatrixOrder.Append);
            var wtvMatrix = CanvasViewport.GetWorldToViewMatrix();
            matrix.Multiply(wtvMatrix, MatrixOrder.Append);
            return matrix;
        }

        public int PaddingLeft { get; set; }
        public int PaddingRight { get; set; }
        public int PaddingTop { get; set; }
        public int PaddingBottom { get; set; }

        public Color GridColor { get { return Color.Red; } }

        public bool CanRenderGrid
        {
            get { return PaddingCanvasGroupParent.CanRenderGrid; }
        }
    }
}
