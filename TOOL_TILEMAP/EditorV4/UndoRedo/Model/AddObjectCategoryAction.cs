using EditorV4.EditorObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    internal class AddObjectCategoryAction : BaseAction
    {
        GameObjectCategory objectCategory;
        IObjectsManager objectManager;
        public override IObjectsManager ObjectManager
        {
            get { return objectManager; }
            set
            {
                objectManager = value;
            }
        }

        public AddObjectCategoryAction(GameObjectCategory objectCategory, IObjectsManager objectManager)
        {
            this.objectCategory = objectCategory;
            this.objectManager = objectManager;
        }

        public override void PerformAction()
        {
            objectManager.AddObjectCategory(objectCategory);
        }

        public override void PerformRevertAction()
        {
            objectManager.RemoveObjectCategory(objectCategory);
        }
    }
}
