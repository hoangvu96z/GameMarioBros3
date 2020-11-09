using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Controls.PropertyGridModel
{
    /// <summary>
    /// CustomClass (Which is binding to property grid)
    /// </summary>
    [Serializable]
    public class CustomClass : CollectionBase, ICustomTypeDescriptor
    {
        /// <summary>
        /// Add CustomProperty to Collectionbase List
        /// </summary>
        /// <param name="Value"></param>
        public void Add(CustomProperty Value)
        {
            base.List.Add(Value);
        }

        /// <summary>
        /// Remove item from List
        /// </summary>
        /// <param name="Name"></param>
        public void Remove(string Name)
        {
            foreach (CustomProperty prop in base.List)
            {
                if (prop.Name == Name)
                {
                    base.List.Remove(prop);
                    return;
                }
            }
        }

        public object GetValue(string name)
        {
            PropertyDescriptorCollection properties;
            properties = TypeDescriptor.GetProperties(this);
            PropertyDescriptor[] newProps = new PropertyDescriptor[this.Count + properties.Count];
            var propertyInfo = this.GetType().GetProperty(name);
            if(propertyInfo==null)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    CustomProperty prop = (CustomProperty)this[i];
                    if (prop.Name == name)
                        return prop.Value;
                }
            }
            return null;
        }

        public void SetValue(string name,object value)
        {
            PropertyDescriptorCollection properties;
            properties = TypeDescriptor.GetProperties(this);
            PropertyDescriptor[] newProps = new PropertyDescriptor[this.Count + properties.Count];
            var propertyInfo = this.GetType().GetProperty(name);
            if(propertyInfo!=null)
            {
                propertyInfo.SetValue(this, value);
            }
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    CustomProperty prop = (CustomProperty)this[i];
                    if (prop.Name == name)
                        prop.Value = value;
                }
            }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        public CustomProperty this[int index]
        {
            get
            {
                return (CustomProperty)base.List[index];
            }
            set
            {
                base.List[index] = (CustomProperty)value;
            }
        }


        #region "TypeDescriptor Implementation"
        /// <summary>
        /// Get Class Name
        /// </summary>
        /// <returns>String</returns>
        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        /// <summary>
        /// GetAttributes
        /// </summary>
        /// <returns>AttributeCollection</returns>
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        /// <summary>
        /// GetComponentName
        /// </summary>
        /// <returns>String</returns>
        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        /// <summary>
        /// GetConverter
        /// </summary>
        /// <returns>TypeConverter</returns>
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        /// <summary>
        /// GetDefaultEvent
        /// </summary>
        /// <returns>EventDescriptor</returns>
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        /// <summary>
        /// GetDefaultProperty
        /// </summary>
        /// <returns>PropertyDescriptor</returns>
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        /// <summary>
        /// GetEditor
        /// </summary>
        /// <param name="editorBaseType">editorBaseType</param>
        /// <returns>object</returns>
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public String[] GetCustomProperties()
        {
            String[] strs = new string[this.Count];

            PropertyDescriptorCollection properties;
            properties = TypeDescriptor.GetProperties(this);
            PropertyDescriptor[] newProps = new PropertyDescriptor[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                CustomProperty prop = (CustomProperty)this[i];
                strs[i] = prop.Name;
            }

            return strs;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection properties;
            properties = TypeDescriptor.GetProperties(this);
            PropertyDescriptor[] newProps = new PropertyDescriptor[this.Count + properties.Count];
            int currentIndex = 0;

            for (int i = 0; i < properties.Count; i++)
            {
                var prop = properties[i];
                newProps[currentIndex++] = TypeDescriptor.CreateProperty(prop.ComponentType, prop, new CategoryAttribute("Default Properties"));
            }

            for (int i = 0; i < this.Count; i++)
            {
                CustomProperty prop = (CustomProperty)this[i];
                newProps[currentIndex++] = new CustomPropertyDescriptor(ref prop, attributes);
            }
            return new PropertyDescriptorCollection(newProps);
        }



        public PropertyDescriptorCollection GetProperties()
        {

            return TypeDescriptor.GetProperties(this, true);

        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion

    }

    /// <summary>
    /// Custom property class 
    /// </summary>
    [Serializable]
    public class CustomProperty
    {
        private string sName = string.Empty;
        private bool bReadOnly = false;
        private bool bVisible = true;
        private object objValue = null;

        public CustomProperty(string sName, object value, bool bReadOnly, bool bVisible)
        {
            this.sName = sName;
            this.objValue = value;
            this.bReadOnly = bReadOnly;
            this.bVisible = bVisible;
        }

        public bool ReadOnly
        {
            get
            {
                return bReadOnly;
            }
        }

        public string Name
        {
            get
            {
                return sName;
            }
        }

        public bool Visible
        {
            get
            {
                return bVisible;
            }
        }

        public object Value
        {
            get
            {
                return objValue;
            }
            set
            {
                objValue = value;
            }
        }

    }


    /// <summary>
    /// Custom PropertyDescriptor
    /// </summary>
    public class CustomPropertyDescriptor : PropertyDescriptor
    {
        CustomProperty m_Property;
        public CustomPropertyDescriptor(ref CustomProperty myProperty, Attribute[] attrs) : base(myProperty.Name, attrs)
        {
            m_Property = myProperty;
        }

        #region PropertyDescriptor specific

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get
            {
                return null;
            }
        }

        public override object GetValue(object component)
        {
            return m_Property.Value;
        }

        public override string Description
        {
            get
            {
                return m_Property.Name;
            }
        }

        public override string Category
        {
            get
            {
                return "Custom Properties";
            }
        }

        public override string DisplayName
        {
            get
            {
                return m_Property.Name;
            }

        }



        public override bool IsReadOnly
        {
            get
            {
                return m_Property.ReadOnly;
            }
        }

        public override void ResetValue(object component)
        {
            //Have to implement
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override void SetValue(object component, object value)
        {
            m_Property.Value = value;
        }

        public override Type PropertyType
        {
            get { return m_Property.Value.GetType(); }
        }

        #endregion
    }
}
