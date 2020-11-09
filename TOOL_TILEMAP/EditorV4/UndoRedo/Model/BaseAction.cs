using EditorV4.EditorObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public abstract class BaseAction
    {
        public abstract void PerformAction();
        public abstract void PerformRevertAction();
        public virtual IObjectsManager ObjectManager { get; set; }
        
    }
}
