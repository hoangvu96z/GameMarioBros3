using EditorV4.EditorObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class UnGroupAction : BaseAction
    {
        GameObject @object;

        List<GameObject> objsIsGrouped;

        public UnGroupAction(GameObject @object)
        {
            this.@object = @object;
            objsIsGrouped = new List<GameObject>();
            List<List<GameObject>> stackClone = @object.ObjectsGrouped.ToList();
            foreach(var collection in stackClone)
            {
                foreach(var o in collection)
                {
                    objsIsGrouped.Add(o);
                }
            }
        }

        public override void PerformAction()
        {
            @object.Resizeable = true;
            foreach (var o in objsIsGrouped)
            {
                o.Active = true;
                @object.Width -= o.Width;
            }
            @object.Resizeable = false;
            @object.IsGrouped = false;

        }

        public override void PerformRevertAction()
        {
            foreach (var o in objsIsGrouped)
            {
                o.Active = false;
                @object.Width += o.Width;
            }
            @object.IsGrouped = true;
        }
    }
}
