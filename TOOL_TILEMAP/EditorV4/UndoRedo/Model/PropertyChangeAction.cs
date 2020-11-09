using EditorV4.Controls.PropertyGridModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    [Serializable]
    public class PropertyChangeAction : BaseAction
    {
        CustomClass currentObject;
        object oldValue;
        object newValue;
        string propertyName;

        public PropertyChangeAction(CustomClass currentObject, object oldValue, string propertyName)
        {
            this.propertyName = propertyName;
            this.currentObject = currentObject;
            this.oldValue = oldValue;
            this.newValue = currentObject.GetValue(propertyName);
        }

        public override void PerformAction()
        {
            currentObject.SetValue(propertyName, newValue);
        }

        public override void PerformRevertAction()
        {
            currentObject.SetValue(propertyName, oldValue);
        }
    }
}
