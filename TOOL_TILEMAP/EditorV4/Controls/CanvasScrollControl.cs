using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditorV4.Models;
using EditorV4.Models.V2;
using EditorV4.Services;
using EditorV4.Ultils;
using System.Runtime.Serialization;
using System.Drawing.Drawing2D;

namespace EditorV4.Controls
{
    public interface ICanvasScrollControl
    {
        void SetVisibleHScrollbar(bool visible);
        void SetVisibleVScrollbar(bool visible);
    }
    enum ScrollDirection
    {
        Horizontal,
        Vertical
    }

    public interface ICanvasScrollParent
    {
        bool CanScroll { get; }
        bool IsHorizontalScroll { get; }
    }

    [Serializable]
    public partial class CanvasScrollControl : UserControl, ICanvasScrollControl, IEditorCanvasScrollbar, ISerializable, ICanvasScrollControl1
    {
        protected CanvasScrollControl(SerializationInfo info, StreamingContext context)
            :
            this()
        {

        }
        public CanvasScrollControl()
        {
            InitializeComponent();
            canvasScrollControlService = new CanvasScrollControlService(this);
            this.SetStyle(
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.DoubleBuffer, true);
            ScrollDirection = ScrollDirection.Vertical;

        }
        public void LoadTileMapFromExisitingFile(string imagePath, ILoaderInterface loaderInterface)
        {
            canvasWorldViewGroup.LoadTileMapFromExisitingFile(imagePath, loaderInterface);
        }
        public PointF CurrentMovePoint { get; set; }
        public ICanvasScrollParent CanvasScrollParent { get; set; }
        ScrollDirection ScrollDirection { get; set; }
        private int _worldWidth;
        public int WorldWidth
        {
            get { return _worldWidth; }
            set
            {
                _worldWidth = value;
                if (canvasWorldViewGroup == null)
                    return;
                canvasWorldViewGroup.WorldViewGroup.EditorCanvas.Width = _worldWidth;
                canvasWorldViewGroup.InvalidateCanvasSize();
            }
        }

        private int _worldHeight;
        public int WorldHeight
        {
            get { return _worldHeight; }
            set
            {
                _worldHeight = value;
                if (canvasWorldViewGroup == null)
                    return;
                canvasWorldViewGroup.WorldViewGroup.EditorCanvas.Height = _worldHeight;
                canvasWorldViewGroup.InvalidateCanvasSize();
            }
        }

        public TestInterface TestInterface
        {
            get
            {
                if (canvasWorldViewGroup == null)
                    return null;
                return canvasWorldViewGroup.TestInterface;
            }
            set
            {
                if (canvasWorldViewGroup == null)
                    return;
                canvasWorldViewGroup.TestInterface = value;
                canvasWorldViewGroup.EditorCanvasScrollHandling.TestInterface = value;
            }
        }
        public IConvertWorldView ConvertWorldView
        {
            get { return _convertWorldView; }
            set
            {
                _convertWorldView = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ConvertWorldView != null)
            {

                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                canvasWorldViewGroup.OnPaint(e.Graphics, ConvertWorldView);
            }
            base.OnPaint(e);
        }

        public void Init(IPaddingCanvasGroupParent @interface)
        {

            canvasWorldViewGroup = new PaddingCanvasGroup(this,
    Width - vScrollBar1.Width,
    Height - vScrollBar1.Height, @interface);

            canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateScrollMaxValue();
            canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateScrollValue();
        }

        CanvasScrollControlService canvasScrollControlService;
        public PaddingCanvasGroup canvasWorldViewGroup;

        float _hValue;
        public float HValue
        {
            get
            {
                return _hValue;
            }
            set
            {
                _hValue = value.Beetween(hScrollBar1.Minimum, hScrollBar1.Maximum);
                hScrollBar1.Value = ((int)(_hValue));
            }
        }

        float _vValue;

        public float VValue
        {
            get
            {
                return _vValue;
            }
            set
            {
                _vValue = value.Beetween(vScrollBar1.Minimum, vScrollBar1.Maximum);
                vScrollBar1.Value = (int)(_vValue);
            }

        }

        float _maxHValue;
        public float MaxHValue
        {
            get
            {
                return _maxHValue;
            }
            set
            {
                _maxHValue = value;
                hScrollBar1.Maximum = (int)value;
                hScrollBar1.Visible = value > 0;
            }
        }

        float _maxVValue;
        private IConvertWorldView _convertWorldView;

        public float MaxVValue
        {
            get
            {
                return _maxVValue;
            }
            set
            {
                _maxVValue = value;
                vScrollBar1.Maximum = (int)value;
                vScrollBar1.Visible = value > 0;
            }
        }

        public void SetVisibleHScrollbar(bool visible)
        {
            panelH.Visible = visible;
        }

        public void SetVisibleVScrollbar(bool visible)
        {
            panelV.Visible = visible;
        }

        public void UpdateScroll()
        {
            HValue = hScrollBar1.Value;
            VValue = vScrollBar1.Value;
            canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateViewport();
            Refresh();
            if (TestInterface != null)
            {
                TestInterface.HValue = hScrollBar1.Value;
                TestInterface.VValue = vScrollBar1.Value;
            }
        }

        private void CanvasScroll(object sender, ScrollEventArgs e)
        {
            UpdateScroll();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (TestInterface != null)
            {
                TestInterface.MouseX = e.Location.X;
                TestInterface.MouseY = e.Location.Y;

                PointF worldLocation = canvasWorldViewGroup.GetWorldPointFromPaddingCanvasViewPoint(e.Location);
                TestInterface.WorldMouseX = worldLocation.X;
                TestInterface.WorldMouseY = worldLocation.Y;
            }
            CurrentMovePoint = e.Location;
            canvasWorldViewGroup.IsControlEnter = false;
            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (CanvasScrollParent != null && !CanvasScrollParent.CanScroll)
            {
                return;
            }

            if (CanvasScrollParent.IsHorizontalScroll)
                hScrollBar1.Value = (hScrollBar1.Value - e.Delta).Beetween(hScrollBar1.Minimum, hScrollBar1.Maximum);
            else
                vScrollBar1.Value = (vScrollBar1.Value - e.Delta).Beetween(vScrollBar1.Minimum, vScrollBar1.Maximum);

            CanvasScroll(null, null);
            base.OnMouseWheel(e);
        }

        internal void OnZoom(float zoomValue, PointF currentMovePoint)
        {
            canvasWorldViewGroup.OnZoom(zoomValue, currentMovePoint);
            if (zoomValue > 1)
                hScrollBar1.SmallChange = vScrollBar1.SmallChange = (int)zoomValue;
        }

        private void CanvasScrollControl_SizeChanged(object sender, EventArgs e)
        {
            if (canvasWorldViewGroup == null)
                return;
            var newViewportSize = canvasWorldViewGroup.EditorCanvasScrollHandling.ScrollToViewportTransformPoint(new PointF(Width - 17, Height - 17));
            canvasWorldViewGroup.CanvasViewport.Width = Width - 17;
            canvasWorldViewGroup.CanvasViewport.Height = Height - 17;
            canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateScrollMaxValue();
            Refresh();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CanvasScrollParent", CanvasScrollParent);
            info.AddValue("ConvertWorldView", ConvertWorldView);
            info.AddValue("CurrentMovePoint", CurrentMovePoint);
            info.AddValue("HValue", HValue);
            info.AddValue("MaxHValue", MaxHValue);
            info.AddValue("MaxVValue", MaxVValue);
            info.AddValue("VValue", VValue);
            info.AddValue("WorldHeight", WorldHeight);
            info.AddValue("WorldWidth", WorldWidth);
        }
    }
}
