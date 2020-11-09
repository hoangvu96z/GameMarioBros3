using EditorV4.Models.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class ModifiledTileAction : BaseAction
    {
        int oldTileIndex;
        int newTileIndex;
        int rIndex;
        int cIndex;
        TilesModel matrixObject;

        public ModifiledTileAction(int newTileIndex, int rIndex, int cIndex, TilesModel matrixObject)
        {
            this.oldTileIndex = matrixObject.Matrix[rIndex, cIndex];
            this.newTileIndex = newTileIndex;
            this.rIndex = rIndex;
            this.cIndex = cIndex;
            this.matrixObject = matrixObject;
        }

        public override void PerformAction()
        {
            matrixObject.Matrix[rIndex, cIndex] = newTileIndex;
        }

        public override void PerformRevertAction()
        {
            matrixObject.Matrix[rIndex, cIndex] = oldTileIndex;
        }
    }
}
