using EditorV4.Controls.PropertyGridModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class RemovePropertyAction : BaseAction
    {
        CustomClass obj;
        string propertyName;
        object value;

        public RemovePropertyAction(CustomClass obj, string propertyName)
        {
            this.obj = obj;
            this.propertyName = propertyName;
            this.value = obj.GetValue(propertyName);
        }

        public override void PerformAction()
        {
            obj.Remove(propertyName);
        }

        public override void PerformRevertAction()
        {
            obj.Add(new CustomProperty(propertyName, value, false, true));
        }
    }
}
