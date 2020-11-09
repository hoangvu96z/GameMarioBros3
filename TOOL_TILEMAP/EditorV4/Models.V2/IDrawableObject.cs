using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface IDrawableObject
    {
        void OnPaint(Graphics g, CanvasViewport viewport);
        void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView);
    }
}
