using System;
using System.ComponentModel;
using System.Drawing.Design;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.DB.Designer;

namespace KiSS4.Gui
{
    [Designer(typeof(Designer.KissControlDesigner))]
    public partial class KissMultiCheckEdit : KissComplexControl, IKissBindableEdit, IKissEditable, IKissUserModified
    {
        #region Fields

        #region Private Fields

        private EditModeType _editMode;

        #endregion

        #endregion

        #region Constructors

        public KissMultiCheckEdit()
        {
            InitializeComponent();
            edtCheckedLookup.BackColor = base.BackColor;
            Load += new EventHandler(KissMultiCheckEdit_Load);
        }

        void KissMultiCheckEdit_Load(object sender, EventArgs e)
        {
            edtCheckedLookup.Width = this.Width - edtCheckedLookup.Left;
            edtCheckedLookup.Height = this.Height - edtCheckedLookup.Top;
            edtCheckedLookup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left 
                                        | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Binding DataMember.
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
        {
            get { return edtCheckedLookup.DataMember; }
            set { edtCheckedLookup.DataMember = value; }
        }

        /// <summary>
        /// Gets or sets the data source whose data is displayed by a list box control.
        /// </summary>
        /// <value>
        /// A data source object whose data is displayed by the list box control.
        /// </value>
        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return edtCheckedLookup.DataSource; }
            set { edtCheckedLookup.DataSource = value; }
        }

        /// <summary>
        /// Gets or sets the edit mode
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                GuiConfig.SetEditMode(chkEnableCheckedLookup, _editMode);
                GuiConfig.SetEditMode(edtCheckedLookup, _editMode);
            }
        }

        /// <summary>
        /// Gets or sets the edit value.
        /// </summary>
        /// <value>The edit value.</value>
        [Browsable(true)]
        [DefaultValue("")]
        public string EditValue
        {
            get { return edtCheckedLookup.EditValue; }

            set { edtCheckedLookup.EditValue = value; }
        }

        /// <summary>
        /// Enables or disables the checked lookup edit
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        public bool EnableCheckedLookup
        {
            get { return chkEnableCheckedLookup.Checked; }

            set
            {
                chkEnableCheckedLookup.Checked = value;
                edtCheckedLookup.EditValue = null;
            }
        }

        /// <summary>
        /// Gets or sets the LOV filter.
        /// </summary>
        /// <value>The LOV filter.</value>
        [Browsable(true)]
        [DefaultValue("")]
        public string LOVFilter
        {
            get { return edtCheckedLookup.LOVFilter; }
            set { edtCheckedLookup.LOVFilter = value; }
        }

        /// <summary>
        /// Gets or sets the name of the LOV.
        /// </summary>
        /// <value>The name of the LOV.</value>
        [Browsable(true)]
        [DefaultValue("")]
        public string LOVName
        {
            get { return edtCheckedLookup.LOVName; }
            set { edtCheckedLookup.LOVName = value; }
        }

        /// <summary>
        /// Gets or sets the lookup SQL.
        /// </summary>
        /// <value>The lookup SQL.</value>
        [Browsable(true)]
        [DefaultValue("")]
        [Editor(typeof(SqlStatementEditor), typeof(UITypeEditor))]
        public string LookupSQL
        {
            get { return edtCheckedLookup.LookupSQL; }
            set { edtCheckedLookup.LookupSQL = value; }
        }

        /// <summary>
        /// Gets or sets the text of the Checkbox.
        /// </summary>
        /// <value>The text of the Checkbox</value>
        [Browsable(true)]
        [DefaultValue("")]
        public string TextCheckbox
        {
            get { return chkEnableCheckedLookup.Text; }
            set { chkEnableCheckedLookup.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get { return edtCheckedLookup.UserModified; }

            set { edtCheckedLookup.UserModified = value; }
        }

        #endregion

        #region EventHandlers

        private void chkEnableCheckedLookup_CheckedChanged(object sender, EventArgs e)
        {
            ////edtCheckedLookup.Enabled = !chkEnableCheckedLookup.Checked;
            if (chkEnableCheckedLookup.Checked)
            {
                edtCheckedLookup.EditValue = null;
            }
        }

        private void edtCheckedLookup_EditValueChanged(object sender, EventArgs e)
        {
            chkEnableCheckedLookup.CheckedChanged -= chkEnableCheckedLookup_CheckedChanged;

            chkEnableCheckedLookup.Checked = string.IsNullOrEmpty(EditValue);

            chkEnableCheckedLookup.CheckedChanged += chkEnableCheckedLookup_CheckedChanged;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void CancelEdit()
        {
            edtCheckedLookup.CancelEdit();
        }

        /// <summary>
        /// Gets a value indicating whether editing is allowed.
        /// </summary>
        /// <param name="value"></param>
        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (EditMode != EditModeType.ReadOnly)
            {
                if (value)
                {
                    GuiConfig.SetEditMode(chkEnableCheckedLookup, EditMode);
                    GuiConfig.SetEditMode(edtCheckedLookup, EditMode);
                }
                else
                {
                    GuiConfig.SetEditMode(chkEnableCheckedLookup, EditModeType.ReadOnly);
                    GuiConfig.SetEditMode(edtCheckedLookup, EditModeType.ReadOnly);
                }
            }
        }

        /// <summary>
        /// Gets the name of the bindable property.
        /// </summary>
        /// <returns></returns>
        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "EditValue";
        }

        #endregion

        #endregion
    }
}