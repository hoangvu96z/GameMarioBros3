using EditorV4.Controls.PropertyGridModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class AddPropertyAction : BaseAction
    {
        CustomClass obj;
        string propertyName;

        public AddPropertyAction(CustomClass obj, string propertyName)
        {
            this.obj = obj;
            this.propertyName = propertyName;
        }

        public override void PerformAction()
        {
            obj.Add(new CustomProperty(propertyName, "", false, true));
        }

        public override void PerformRevertAction()
        {
            obj.Remove(propertyName);
        }
    }
}
