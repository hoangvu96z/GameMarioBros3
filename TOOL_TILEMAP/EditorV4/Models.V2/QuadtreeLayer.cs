using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface QuadTreeLayerInterface
    {
        QuadNode RootNode { get; }
        Color QuadtreeBorderColor { get; }
    }
    [Serializable]
    public class QuadtreeLayer : IDrawableObject
    {
        QuadTreeLayerInterface @interface;

        public QuadtreeLayer(QuadTreeLayerInterface @interface)
        {
            this.@interface = @interface;
        }

        private void DrawQuadnode(QuadNode node, Graphics viewGraphics, IConvertWorldView convertWorldView)
        {
            Rectangle locationRect = new Rectangle(node.X, node.Y, node.Width, node.Height);
            locationRect = convertWorldView.GetViewRect(locationRect);
            viewGraphics.DrawRectangle(new Pen(@interface.QuadtreeBorderColor, 2), locationRect);
            if(node.TL!=null)
            {
                DrawQuadnode(node.TL,viewGraphics, convertWorldView);
                DrawQuadnode(node.TR,viewGraphics, convertWorldView);
                DrawQuadnode(node.BL,viewGraphics, convertWorldView);
                DrawQuadnode(node.BR,viewGraphics, convertWorldView);
            }
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
        }

        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            if (@interface.RootNode == null)
                return;
            DrawQuadnode(@interface.RootNode, viewGraphics, convertWorldView);
        }
    }
}
