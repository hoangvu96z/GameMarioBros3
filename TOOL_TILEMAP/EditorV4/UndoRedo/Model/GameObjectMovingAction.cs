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
    public class GameObjectMovingAction : BaseAction
    {
        int moveX, moveY;
        ISelectableObject shape;

        public GameObjectMovingAction(int moveX, int moveY, ISelectableObject shape)
        {
            this.moveX = moveX;
            this.moveY = moveY;
            this.shape = shape;
        }

        public override void PerformAction()
        {
            shape.Move(new Point(moveX, moveY));
        }

        public override void PerformRevertAction()
        {
            shape.Move(new Point(-moveX, -moveY));
        }
    }
}
