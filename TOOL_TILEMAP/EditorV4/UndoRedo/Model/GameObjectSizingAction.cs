using EditorV4.EditorObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class GameObjectSizingAction : BaseAction
    {
        Point ptBegin;
        Point ptEnd;
        int sizingValue;
        ISelectableObject shape;

        public GameObjectSizingAction(Point ptBegin, Point ptEnd, int sizingValue, ISelectableObject shape)
        {
            this.ptBegin = ptBegin;
            this.ptEnd = ptEnd;
            this.sizingValue = sizingValue;
            this.shape = shape;
        }

        public override void PerformAction()
        {
            shape.SetSizing(sizingValue, ptBegin, ptEnd);
        }

        public override void PerformRevertAction()
        {
            shape.SetSizing(sizingValue, ptEnd, ptBegin);
        }
    }
}
