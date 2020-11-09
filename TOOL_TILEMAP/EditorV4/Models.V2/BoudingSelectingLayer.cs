using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface BoudingSelectingLayerInterface
    {
        Rectangle SelectingRect { get; }
        Color SelectingColorBorder { get; }
        Color SelectingBackColor { get; }
        bool CanSelectObject { get; }
    }
    [Serializable]
    public class BoudingSelectingLayer : IDrawableObject
    {
        BoudingSelectingLayerInterface @interface;

        public BoudingSelectingLayer(BoudingSelectingLayerInterface @interface)
        {
            this.@interface = @interface;
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
        }
        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            if (!@interface.CanSelectObject)
                return;
            Rectangle locationRect = convertWorldView.GetViewRect(@interface.SelectingRect);
            viewGraphics.DrawRectangle(new Pen(@interface.SelectingColorBorder, 1), locationRect);
            viewGraphics.FillRectangle(new SolidBrush(@interface.SelectingBackColor), locationRect);
        }
    }
}
