using EditorV4.Controls;
using EditorV4.Models.V2;
using EditorV4.Services;
using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4
{
    public partial class TestForm : Form, TestInterface,
        IControlScrollInterface, ICanvasScrollParent, IPaddingCanvasGroupParent
    {
        public TestForm(int rowsNumber, int columnsNumber, int tileSize, Image tileSheet)
        {
            InitializeComponent();
            canvasScrollControl1.TestInterface = this;
            RowsNumber = rowsNumber;
            ColumnsNumber = columnsNumber;
            TileSize = tileSize;
            TileSheet = tileSheet;
            canvasScrollControl1.WorldWidth = columnsNumber * tileSize;
            canvasScrollControl1.canvasWorldViewGroup.PaddingCanvasGroupParent = this;

            canvasScrollControl1.WorldHeight = rowsNumber * tileSize;
            canvasScrollControl1.canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateScrollMaxValue();
            controlScrollService = new ControlScrollService(this);

            canvasScrollControl1.CanvasScrollParent = this;
        }

        ControlScrollService controlScrollService;

        public float ViewportX
        {
            get
            {
                return float.Parse(txtViewportX.Text);
            }
            set
            {
                txtViewportX.Text = value.ToString();
            }
        }
        public float ViewportY
        {
            get
            {
                return float.Parse(txtViewportY.Text);
            }
            set
            {
                txtViewportY.Text = value.ToString();
            }
        }
        public float ViewportWidth
        {
            get
            {
                return float.Parse(txtViewportWidth.Text);
            }
            set
            {
                txtViewportWidth.Text = value.ToString();
            }
        }
        public float ViewportHeight
        {
            get
            {
                return float.Parse(txtViewportHeight.Text);
            }
            set
            {
                txtViewportHeight.Text = value.ToString();
            }
        }



        public float ViewportiX
        {
            get
            {
                return float.Parse(txtViewportiX.Text);
            }
            set
            {
                txtViewportiX.Text = value.ToString();
            }
        }
        public float ViewportiY
        {
            get
            {
                return float.Parse(txtViewportiY.Text);
            }
            set
            {
                txtViewportiY.Text = value.ToString();
            }
        }
        public float ViewportiWidth
        {
            get
            {
                return float.Parse(txtViewportiWidth.Text);
            }
            set
            {
                txtViewportiWidth.Text = value.ToString();
            }
        }
        public float ViewportiHeight
        {
            get
            {
                return float.Parse(txtViewportiHeight.Text);
            }
            set
            {
                txtViewportiHeight.Text = value.ToString();
            }
        }



        public float HValue
        {
            get { return int.Parse(txtHValue.Text); }
            set { txtHValue.Text = value.ToString(); }
        }

        public float VValue
        {
            get { return int.Parse(txtVValue.Text); }
            set { txtVValue.Text = value.ToString(); }
        }
        public float MaxHValue
        {
            get { return int.Parse(txtMaxHValue.Text); }
            set { txtMaxHValue.Text = value.ToString(); }
        }
        public float MaxVValue
        {
            get { return int.Parse(txtMaxVValue.Text); }
            set { txtMaxVValue.Text = value.ToString(); }
        }

        public int MouseX
        {
            get { return int.Parse(txtMouseX.Text); }
            set { txtMouseX.Text = value.ToString(); }
        }
        public int MouseY
        {
            get { return int.Parse(txtMouseY.Text); }
            set { txtMouseY.Text = value.ToString(); }
        }

        public float WorldMouseX
        {
            get { return int.Parse(txtWorldMouseX.Text); }
            set { txtWorldMouseX.Text = value.ToString(); }
        }
        public float WorldMouseY
        {
            get { return int.Parse(txtWorldMouseY.Text); }
            set { txtWorldMouseY.Text = value.ToString(); }
        }

        public int RowsNumber { get; set; }
        public int ColumnsNumber { get; set; }
        public int TileSize { get; set; }
        public Image TileSheet { get; set; }

        public float ZoomValue
        {
            get
            {
                if (trackBarZoom.Value == 10)
                {
                    return 1.0f;
                }
                if (trackBarZoom.Value < 10)
                {
                    return trackBarZoom.Value * 0.1f;
                }
                return (trackBarZoom.Value - 9);
            }
        }

        public bool CanScroll
        {
            get
            {
                return !controlScrollService.IsControlDown;
            }
        }

        private void trackBar1_SizeChanged(object sender, EventArgs e)
        {
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            controlScrollService.OnKeyDown(e);
            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            canvasScrollControl1.canvasWorldViewGroup.IsControlEnter = false;
            controlScrollService.OnKeyUp(e);
            base.OnKeyUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            controlScrollService.OnMouseWheel(e);
            base.OnMouseWheel(e);
        }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public bool IsControlDown
        {
            get
            {
                return controlScrollService.IsControlDown;
            }
        }

        public bool IsHorizontalScroll => throw new NotImplementedException();

        public bool CanRenderGrid => throw new NotImplementedException();

        public TilesModel TilesModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            canvasScrollControl1.OnZoom(ZoomValue, canvasScrollControl1.CurrentMovePoint);
            canvasScrollControl1.UpdateScroll();
            canvasScrollControl1.Refresh();
        }

        public void OnControlScroll(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                trackBarZoom.Value = (trackBarZoom.Value + 1).SmallerOrEqualThan(trackBarZoom.Maximum);
            }
            else
            {
                trackBarZoom.Value = (trackBarZoom.Value - 1).GreaterOrEqualThan(trackBarZoom.Minimum);
            }
            trackBar1_Scroll(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openTileExisting.ShowDialog() == DialogResult.OK)
            {
                canvasScrollControl1.LoadTileMapFromExisitingFile(openTileExisting.FileName,null);
            }
        }
    }
}
