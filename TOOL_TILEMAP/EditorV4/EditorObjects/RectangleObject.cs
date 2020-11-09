using EditorV4.Models.V2;
using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.EditorObjects
{
    [Serializable]
    public class RectangleObject : GameObject
    {
        private Color _backColor;
        public bool Active { get; set; }
        public int Id { get; set; }
        public Color BackColor
        {
            get => _backColor; set
            {
                _backColor = Color.FromArgb(100, value.R, value.G, value.B);
            }
        }
        public RectangleObject()
        {
            BackColor = Color.FromArgb(100, 255, 0, 0);
            Resizeable = true;
            Movable = true;
        }
        public override void OnPaint(Graphics g, CanvasViewport viewport)
        {
        }

        public override void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            if (Size == Size.Empty)
                return;
            viewGraphics.FillRectangle(new SolidBrush(BackColor), convertWorldView.GetViewRect(_border.NormalizeRect()));
            base.OnPaintInView(viewGraphics, viewViewport, convertWorldView);
        }

        public new string Name {  get; set; }

        internal override string GetImageKey()
        {
            return "ObjectsRectangle";
        }
        public override string Display
        {
            get
            {
                return String.Format("Rectangle (Id : {0}) (Location: {1},{2})", Id, Location.X, Location.Y);
            }
        }

        public override Image ObjectImage
        {
            get
            {
                return global::EditorV4.Properties.Resources.rect2;
            }
            set
            {
            }
        }
    }
}
