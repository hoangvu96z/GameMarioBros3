using EditorV4.Models.V2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.EditorObjects
{
    public interface ISelectableObject : IDrawableObject
    {
        bool Resizeable { get; }
        int SizingPointValue(Point p);
        bool CanSelectByPoint(Point p);
        void Move(Point delta);
        void SetSizing(int sizingValue, Point ptBegin, Point ptEnd);
        void DrawSelected(Graphics g, CanvasViewport viewport, IConvertWorldView convertWorldView);
        bool Movable { get; }
        Rectangle BoudingRect { get; }
    }
}
