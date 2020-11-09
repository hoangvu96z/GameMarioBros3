using EditorV4.EditorObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class AddObjectAction : BaseAction
    {
        GameObject gameObject;
        IObjectsManager objectManager;
        public override IObjectsManager ObjectManager
        {
            get { return objectManager; }
            set
            {
                objectManager = value;
            }
        }

        public AddObjectAction(GameObject gameObject, IObjectsManager objectManager)
        {
            this.gameObject = gameObject;
            this.objectManager = objectManager;
        }

        public override void PerformAction()
        {
            objectManager.AddGameObject(gameObject);
        }

        public override void PerformRevertAction()
        {
            objectManager.RemoveGameObject(gameObject);
        }
    }
}
