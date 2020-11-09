using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EditorV4.EditorObjects;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class GroupAction : BaseAction
    {
        List<BaseAction> actions;

        public override IObjectsManager ObjectManager
        {
            get { return base.ObjectManager; }
            set
            {
                base.ObjectManager = value;
                foreach(var action in actions)
                {
                    action.ObjectManager = value;
                }
            }
        }

        public GroupAction(List<BaseAction> actions)
        {
            this.actions = actions;
        }

        public override void PerformAction()
        {
            foreach (var action in actions)
            {
                action.PerformAction();
            }
        }

        public override void PerformRevertAction()
        {
            foreach (var action in actions)
            {
                action.PerformRevertAction();
            }
        }
    }
}
