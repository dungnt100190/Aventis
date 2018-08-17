using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Component property descriptor for translating a known component
    /// </summary>
    public class KissCompPropDescriptor
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// The component the property descriptor is from
        /// </summary>
        public Component Component;

        /// <summary>
        /// The type of the component
        /// </summary>
        public Type Type;

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The hasthtable containing the property info
        /// </summary>
        private static Hashtable _htPropertyInfo = new Hashtable();

        #endregion

        #region Private Fields

        /// <summary>
        /// The property information to access value property for text
        /// </summary>
        private PropertyInfo _propInfo;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, use <see cref="Create"/> to get an instance
        /// </summary>
        /// <param name="cmp">The component to get property info from</param>
        /// <param name="type">The type of the component</param>
        private KissCompPropDescriptor(Component cmp, Type type)
        {
            this.Component = cmp;
            this.Type = type;

            _propInfo = (PropertyInfo)_htPropertyInfo[Type];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Set BackColor or depending on control type other color to mark control
        /// </summary>
        public Color BackColor
        {
            set
            {
                if (this.Component is Label                     // (Label, KissLabel)
                     || this.Component is KissVerticalLabel      // (VerticalLabel)
                     || this.Component is Button                 // (Button, KissButton, KissDocumentButton)
                     || this.Component is KissSearchTitel        // (KissSearchTitle)
                     || Type == typeof(KissCheckEdit) || Type == typeof(CheckBox))
                {
                    ((Control)this.Component).BackColor = value;
                }
                else if (Type == typeof(KissGroupBox))
                {
                    ((KissGroupBox)this.Component).TextForeColor = value;
                }
                else if (Type == typeof(GroupBox))
                {
                    ((GroupBox)this.Component).ForeColor = value;
                }
                else if (Type == typeof(KissRadioGroup))
                {
                    ((KissRadioGroup)this.Component).ForeColor = value;
                }
                else if (this.Component is SharpLibrary.WinControls.TabPageEx)
                {
                    ((SharpLibrary.WinControls.TabPageEx)this.Component).TextColor = value;
                    //// BackColor is ugly: ((SharpLibrary.WinControls.TabPageEx)this.Component).BackColor = value;
                }
                else if (Type == typeof(DevExpress.XtraGrid.Columns.GridColumn))
                {
                    if (value != Color.Empty)
                    {
                        ((DevExpress.XtraGrid.Columns.GridColumn)this.Component).AppearanceHeader.ForeColor = Color.Red;
                    }
                    else
                    {
                        ((DevExpress.XtraGrid.Columns.GridColumn)this.Component).AppearanceHeader.ForeColor = value;
                    }
                }
                else if (Type == typeof(DevExpress.XtraTreeList.Columns.TreeListColumn))
                {
                    // TODO: Handle single column - at the moment all columns will change color
                    if (value != Color.Empty)
                    {
                        ((DevExpress.XtraTreeList.Columns.TreeListColumn)this.Component).TreeList.Appearance.HeaderPanel.ForeColor = Color.Red;
                    }
                    else
                    {
                        ((DevExpress.XtraTreeList.Columns.TreeListColumn)this.Component).TreeList.Appearance.HeaderPanel.ForeColor = value;
                    }
                }
            }
        }

        /// <summary>
        /// The name of the property to set for translated text
        /// </summary>
        public string PropertyName
        {
            get { return _propInfo.Name; }
        }

        /// <summary>
        /// Get and set the text to display for control
        /// </summary>
        public object Value
        {
            get
            {
                return _propInfo == null ? null : _propInfo.GetValue(Component, null);
            }
            set
            {
                if (_propInfo != null)
                {
                    _propInfo.SetValue(Component, value, null);
                }
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Create a new property descriptor
        /// </summary>
        /// <param name="cmp">The component to handle</param>
        /// <returns>The component if type is not explicit checked or valid bindable, otherwise new instance of <see cref="KissCompPropDescriptor"/></returns>
        public static object Create(Component cmp)
        {
            Type Type = cmp.GetType();

            if (_htPropertyInfo[Type] == null)
            {
                PropertyInfo propInfo;

                //TODO weitere?
                if (cmp is Label                    // (Label, KissLabel)
                     || cmp is KissVerticalLabel     // (VerticalLabel)
                     || cmp is Button                // (Button, KissButton, KissDocumentButton)
                     || cmp is KissSearchTitel       // (KissSearchTitle)
                     || cmp is KissRadioGroup        // (KissRadioGroup)
                     || Type == typeof(KissCheckEdit)
                     || Type == typeof(CheckBox)
                     || Type == typeof(KissGroupBox)
                     || Type == typeof(GroupBox)
                     || cmp is KissForm)
                {
                    propInfo = Type.GetProperty("Text");
                }
                else if (Type == typeof(DevExpress.XtraGrid.Columns.GridColumn)
                     || Type == typeof(DevExpress.XtraTreeList.Columns.TreeListColumn)
                     || Type == typeof(DevExpress.XtraBars.BarButtonItem))
                {
                    propInfo = Type.GetProperty("Caption");
                }
                else if (cmp is SharpLibrary.WinControls.TabPageEx)
                {
                    propInfo = Type.GetProperty("Title");
                }
                else if (cmp is SqlQuery)
                {
                    propInfo = Type.GetProperty("DeleteQuestion");
                }
                else
                {
                    return cmp;
                }

                // check if component is valid as bindable control
                IKissBindableEdit ikbe = cmp as IKissBindableEdit;

                if (ikbe != null &&
                    ikbe.DataSource != null &&
                    !DBUtil.IsEmpty(ikbe.DataMember) &&
                    propInfo.Name.Equals(ikbe.GetBindablePropertyName()))
                {
                    return cmp;
                }

                _htPropertyInfo[Type] = propInfo;
            }

            return new KissCompPropDescriptor(cmp, Type);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>true if the specified System.Object is equal to the current System.Object;
        /// otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is KissCompPropDescriptor)
            {
                obj = ((KissCompPropDescriptor)obj).Component;
            }

            return this.Component.Equals(obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current System.Object.</returns>
        public override int GetHashCode()
        {
            return this.Component.GetHashCode();
        }

        #endregion

        #endregion
    }
}