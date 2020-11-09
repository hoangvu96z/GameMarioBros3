using EditorV4.Ultils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EditorV4.Controls
{
    public abstract class GridComboBox : UITypeEditor
    {
        #region Constants

        private const string StrAddNew = "<Add New...>";

        #endregion

        #region Data Members

        private IList _dataList;
        private readonly ListBox _listBox;
        private Boolean _escKeyPressed;
        private ListAttribute _listAttribute;
        private IWindowsFormsEditorService _editorService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public GridComboBox()
        {
            _listBox = new ListBox();

            // Properties
            _listBox.BorderStyle = BorderStyle.None;

            // Events
            _listBox.Click += myListBox_Click;
            _listBox.PreviewKeyDown += myListBox_PreviewKeyDown;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get/Set for ListBox
        /// </summary>
        protected ListBox ListBox
        {
            get { return (_listBox); }
        }

        /// <summary>
        /// Get/Set for DataList
        /// </summary>
        protected IList DataList
        {
            get { return (_dataList); }
            set { _dataList = value; }
        }

        /// <summary>
        /// Get/Set for ListAttribute
        /// </summary>
        protected ListAttribute ListAttribute
        {
            get { return (_listAttribute); }
            set { _listAttribute = value; }
        }

        #endregion

        #region Methods - Public

        /// <summary>
        /// Close DropDown window to finish editing
        /// </summary>
        public void CloseDropDownWindow()
        {
            if (_editorService != null)
                _editorService.CloseDropDown();
        }

        #endregion

        #region Methods - Private

        /// <summary>
        /// Populate the ListBox with data items
        /// </summary>
        /// <param name="context"></param>
        /// <param name="currentValue"></param>
        private void PopulateListBox(ITypeDescriptorContext context, Object currentValue)
        {
            // Clear List
            _listBox.Items.Clear();

            // Retrieve the reference to the items to be displayed in the list
            if (_dataList == null)
                RetrieveDataList(context);

            if (_dataList != null)
            {
                if ((_listAttribute is IAddNew) && (((IAddNew)_listAttribute).AddNew))
                    _listBox.Items.Add(StrAddNew);

                // Add Items to the ListBox
                foreach (object obj in _dataList)
                {
                    _listBox.Items.Add(obj);
                }

                // Select current item 
                if (currentValue != null)
                    _listBox.SelectedItem = currentValue;
            }

            // Set the height based on the Items in the ListBox
            _listBox.Height = _listBox.PreferredHeight;
        }

        #endregion

        #region Methods - Protected

        /// <summary>
        /// Get the object selected in the ComboBox
        /// </summary>
        /// <returns>Selected Object</returns>
        protected abstract object GetDataObjectSelected(ITypeDescriptorContext context);

        /// <summary>
        /// Find the list of data items to populate the ListBox
        /// </summary>
        /// <param name="context"></param>
        protected abstract void RetrieveDataList(ITypeDescriptorContext context);

        #endregion

        #region Event Handlers

        /// <summary>
        /// Preview Key Pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                _escKeyPressed = true;
        }

        /// <summary>
        /// ListBox Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListBox_Click(object sender, EventArgs e)
        {
            //when user clicks on an item, the edit process is done.
            this.CloseDropDownWindow();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                //Uses the IWindowsFormsEditorService to display a 
                // drop-down UI in the Properties window:
                _editorService = provider.GetService(
                                     typeof(IWindowsFormsEditorService))
                                 as IWindowsFormsEditorService;

                if (_editorService != null)
                {
                    // Add Values to the ListBox
                    PopulateListBox(context, value);

                    // Set to false before showing the control
                    _escKeyPressed = false;

                    // Attach the ListBox to the DropDown Control
                    _editorService.DropDownControl(_listBox);

                    // User pressed the ESC key --> Return the Old Value
                    if (!_escKeyPressed)
                    {
                        // Get the Selected Object
                        object obj = GetDataObjectSelected(context);

                        // If an Object is Selected --> Return it
                        if (obj != null)
                            return (obj);
                    }
                }
            }

            return (value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return (UITypeEditorEditStyle.DropDown);
        }

        #endregion
    }

    public class ListGridComboBox : GridComboBox
    {
        #region Methods - Private

        /// <summary>
        /// Create a new object and send notification if requested
        /// </summary>
        /// <param name="context"></param>
        /// <returns>An instantiated object</returns>
        private object CreateNewObject(ITypeDescriptorContext context)
        {
            object obj = null;

            DataListAttribute attribute = base.ListAttribute as DataListAttribute;
            if ((attribute != null) && (attribute.AddNew))
            {
                obj = Reflect.CreateInstance(context.PropertyDescriptor.PropertyType, null);
                SendOnAddNotification(context, obj);
            }

            return (obj);
        }

        /// <summary>
        /// Send notification of object creation
        /// </summary>
        /// <param name="context"></param>
        /// <param name="obj"></param>
        private void SendOnAddNotification(ITypeDescriptorContext context, object obj)
        {
            DataListAttribute attribute = base.ListAttribute as DataListAttribute;
            if ((obj != null) && (attribute != null) && (attribute.EventHandler != null))
            {
                ObjectCreatedEventArgs arg = new ObjectCreatedEventArgs(obj);
                Reflect.CallMethod(context.Instance, attribute.EventHandler, this, arg);
            }
        }


        /// <summary>
        /// Get the class instance of a field/property/method
        /// </summary>
        /// <param name="path"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private static object GetLocalProperty(IEnumerable<string> path, object property)
        {
            foreach (string segment in path)
            {
                Property propertyInfo = PathParser.BreakVariable(segment);
                property = Reflect.CallGeneric(property, propertyInfo.Name);

                // If there was a subscript get the data object
                if ((property is IList) && (propertyInfo.Index != null))
                {
                    if (property is IDictionary)
                    {
                        property = ((IDictionary)property)[propertyInfo.Index];
                    }
                    else
                    {
                        property = ((IList)property)[(int)propertyInfo.Index];
                    }
                }
            }

            return property;
        }

        /// <summary>
        /// Get the static field/property/method of the class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static object GetStaticProperty(DataListAttribute attribute, IList<string> path)
        {
            Type type;
            object property;
            string segment;
            int count = 0;

            type = ClassType.GetType(attribute.DllName, attribute.ClassName);

            segment = path[count++];
            property = Reflect.GetStaticDataMember(type, segment);


            for (; count < path.Count; count++)
            {
                segment = path[count];

                Property propertyInfo = PathParser.BreakVariable(segment);
                property = Reflect.GetDataMember(property, propertyInfo.Name);

                // If there was a subscript get the data object
                if (propertyInfo.Index != null)
                {
                    if (property is IDictionary)
                    {
                        property = ((IDictionary)property)[propertyInfo.Index];
                    }
                    else if (property is IList)
                    {
                        property = ((IList)property)[(int)propertyInfo.Index];
                    }
                }
            }

            return property;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Get the object selected and create a new object if <Add New...> was selected
        /// </summary>
        /// <returns></returns>
        protected override object GetDataObjectSelected(ITypeDescriptorContext context)
        {
            object dataObject = base.ListBox.SelectedItem;

            if ((dataObject is string) && (dataObject.Equals("<Add New...>")))
            {
                return (CreateNewObject(context));
            }

            return (dataObject);
        }


        /// <summary>
        /// Find the list of data to populate the ListBox with
        /// </summary>
        /// <param name="context"></param>
        protected override void RetrieveDataList(ITypeDescriptorContext context)
        {
            DataListAttribute dataListAttribute = null;
            object property = null;

            // Find the Attribute that has the path to the List of Items
            foreach (Attribute attribute in context.PropertyDescriptor.Attributes)
            {
                if (attribute is DataListAttribute)
                {
                    dataListAttribute = attribute as DataListAttribute;
                    base.ListAttribute = dataListAttribute;
                    break;
                }
            }

            // If we found the Attribute, find the Data List
            if (dataListAttribute != null)
            {
                // Split the path 
                List<string> path = PathParser.GetPathParts(dataListAttribute.Path);

                // The path has 1 or more parts
                if ((path != null) && (path.Count > 0))
                {
                    if (dataListAttribute.IsStatic)
                    {
                        property = GetStaticProperty(dataListAttribute, path);
                    }
                    else
                    {
                        // Set the property to the current object
                        property = GetLocalProperty(path, context.Instance);
                    }
                }
            }

            // We don't have List of items
            if ((property == null) || (!(property is IList)))
            {
                base.DataList = null;
            }
            else
            {
                // Save the DataList
                base.DataList = property as IList;
            }
        }

        #endregion
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public abstract class ListAttribute : Attribute
    {
    }
}
