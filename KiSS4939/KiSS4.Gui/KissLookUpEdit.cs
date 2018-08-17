using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissLookUpEdit.
    /// </summary>
    public class KissLookUpEdit : DevExpress.XtraEditors.LookUpEdit, IKissBindableEdit, IKissEditable, ISupportInitialize, IKissUserModified
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string DEFAULT_DISPLAY_MEMBER = "Text";
        private const string DEFAULT_VALUE_MEMBER = "Code";

        #endregion

        #region Private Fields

        private bool _allowNull = true;
        private string _dataMember = string.Empty;
        private SqlQuery _dataSource;
        private string _displayMember;
        private EditModeType _editMode = EditModeType.Normal;
        private bool _inInit;
        private bool _isLovFilterWhereAppend;
        private string _lovFilter = string.Empty;
        private string _lovName = string.Empty;
        private DBUtil.LOVOrderByColumnEnum _lovOrderbyColumn;

        /// <summary>
        /// Store the created popup form to handle events.
        /// </summary>
        private DevExpress.XtraEditors.Popup.PopupBaseForm _popupForm;

        private object _saveEditValue;
        private bool? _showSelectedItemInTooltip = null;
        private bool _userModified;
        private string _valueMember;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit fProperties;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissLookUpEdit"/> class.
        /// </summary>
        public KissLookUpEdit()
        {
            Properties.ButtonsStyle = GuiConfig.EditButtonBorderStyle;
            Properties.NullText = "";
            Properties.ShowFooter = false;
            Properties.ShowHeader = false;
            GuiConfig.SetEditMode(this, EditModeType.Normal);
            DisplayMember = DEFAULT_DISPLAY_MEMBER;
            ValueMember = DEFAULT_VALUE_MEMBER;
            QueryPopUp += OnQueryPopUp;
            FilterOnIsActive = true;
            MouseWheel += OnMouseWheel;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            QueryPopUp -= OnQueryPopUp;
            base.Dispose(disposing);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [enter key].
        /// </summary>
        public event KeyEventHandler EnterKey
        {
            add { onEnterKey += value; }
            remove { onEnterKey -= value; }
        }

        /// <summary>
        /// Occurs when Field was modified and loses focus.
        /// </summary>
        [Description("Fired when the User changed the EditValue and leaves the Control")]
        public event UserModifiedFldEventHandler UserModifiedFld
        {
            add { onUserModifiedFld += value; }
            remove { onUserModifiedFld -= value; }
        }

        private event KeyEventHandler onEnterKey;

        private event UserModifiedFldEventHandler onUserModifiedFld;

        #endregion

        #region Properties

        /// <summary>
        /// Set if an empty item at the top of the list is displayed to the user
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Set if an empty item at the top of the list is displayed to the user")]
        public bool AllowNull
        {
            get { return _allowNull; }
            set
            {
                _allowNull = value;

                if (!DesignMode && !_inInit)
                {
                    ReadLOV();
                }
            }
        }

        [Browsable(true)]
        [DefaultValue("")]
        [Description("The datamember to use for databinding")]
        public string DataMember
        {
            get { return _dataMember; }
            set
            {
                _dataMember = value;

                if (DesignMode)
                {
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        [Description("The datasource to use for databinding")]
        public SqlQuery DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        /// <summary>
        /// Gets or set the display member.
        /// </summary>
        [DefaultValue(DEFAULT_DISPLAY_MEMBER)]
        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                ReadLOV();
            }
        }

        /// <summary>
        /// The EditMode to use for KissLookUpEdit
        /// </summary>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        [Description("The EditMode to use for KissLookUpEdit")]
        public EditModeType EditMode
        {
            get { return _editMode; }
            set { _editMode = value; GuiConfig.SetEditMode(this, _editMode); }
        }

        /// <summary>
        /// Gets or sets the editor's value.
        /// </summary>
        /// <value>An object representing the editor's value.</value>
        [Browsable(true)]
        [DefaultValue(null)]
        public new object EditValue
        {
            get
            {
                if (DesignMode && _dataSource != null && _dataMember != "")
                    return null;
                return base.EditValue;
            }
            set
            {
                _saveEditValue = value;
                _userModified = false;

                base.EditValue = value;
            }
        }

        /// <summary>
        /// Gets the enter key event.
        /// </summary>
        /// <value>The enter key event.</value>
        public KeyEventHandler EnterKeyEvent
        {
            get { return onEnterKey; }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Set if the filter on column IsActive has to be done.")]
        public bool FilterOnIsActive
        {
            get;
            set;
        }

        /// <summary>
        /// If LOVFilterWhereAppend = false: Check if Value3 for current LOVName contains a value
        /// If LOVFilterWhereAppend = true: Append your own additional filter as sql statement in where clause (e.g. 'Value1 = 3')
        /// </summary>
        [Browsable(true)]
        [DefaultValue("")]
        [Description("If LOVFilterWhereAppend = false: Check if Value3 for current LOVName contains a value. If LOVFilterWhereAppend = true: Append your own additional filter as sql statement in where clause (e.g. 'Value1 = 3')")]
        public string LOVFilter
        {
            get { return _lovFilter; }
            set { _lovFilter = value; }
        }

        /// <summary>
        /// Set if defined LOVFilter is used as a part of the WHERE clause in the sql-statement
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Set if defined LOVFilter is used as a part of the WHERE clause in the sql-statement")]
        public bool LOVFilterWhereAppend
        {
            get { return _isLovFilterWhereAppend; }
            set { _isLovFilterWhereAppend = value; }
        }

        /// <summary>
        /// Set the name of the LOV used in XLovCode as LOVName
        /// </summary>
        [Browsable(true)]
        [DefaultValue("")]
        [Description("Set the name of the LOV used in XLovCode as LOVName")]
        public string LOVName
        {
            get { return _lovName; }
            set
            {
                _lovName = value;

                if (!DesignMode && !_inInit)
                {
                    ReadLOV();
                }
            }
        }

        /// <summary>
        /// Set the name of the LOV used in XLovCode as LOVName
        /// </summary>
        [Browsable(true)]
        [DefaultValue(DBUtil.LOVOrderByColumnEnum.SortKeyCode)]
        [Description("Defines by which column the LOV is ordered")]
        public DBUtil.LOVOrderByColumnEnum LOVOrderByColumn
        {
            get { return _lovOrderbyColumn; }
            set
            {
                _lovOrderbyColumn = value;

                if (!DesignMode && !_inInit)
                {
                    ReadLOV();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get { return _userModified || EditValue == null ? _saveEditValue != null : !EditValue.Equals(_saveEditValue); }
            set { if (value) _userModified = true; else _saveEditValue = EditValue; }
        }

        /// <summary>
        /// Gets or sets the value member.
        /// </summary>
        [DefaultValue(DEFAULT_VALUE_MEMBER)]
        public string ValueMember
        {
            get { return _valueMember; }
            set
            {
                _valueMember = value;
                ReadLOV();
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the System.ComponentModel.Component is currently in design mode.
        /// </summary>
        /// <Returns>
        /// true if the System.ComponentModel.Component is in design mode; otherwise, false.
        /// </Returns>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get { return base.DesignMode || (Parent is KissComplexControl && ((KissComplexControl)Parent).DesignerMode); }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handle the mouseWheel event event.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            bool isScrollAktiviert = !Session.IsKiss5Mode && DBUtil.GetConfigBool(@"System\GUI\InFeldernScrollen", false);

            if (!isScrollAktiviert && !IsPopupOpen)
            {
                //Stop the Scroll
                ((DXMouseEventArgs)e).Handled = true;
            }
        }

        /// <summary>
        /// Handle the KeyPress event.
        /// Call manually the base.OnEditorKeyPress method due to PopupForm.TopMost event-order problem (TopMost = true means different event-order).
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void popupForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnEditorKeyPress(e);
        }

        /// <summary>
        /// Handle the MouseWheel event (scrolling).
        /// Call manually the base.OnMouseWheel method due to PopupForm.TopMost event-order problem (TopMost = true means different event-order).
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void popupForm_MouseWheel(object sender, MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Fill the dropdown with new datarows created from code-text-dictionary
        /// </summary>
        /// <param name="codeTexts">The dictionary containing the codes with its corresponding texts</param>
        /// <param name="allowNullDisplayText">The text to be displayed for the null/empty row</param>
        /// <param name="valueMember">Sets the field name whose values identify dropdown rows</param>
        /// <param name="displayMember">Sets the field whose values are displayed in the edit box</param>
        public void ApplyCodeTextPairsAsPopupDataSource(Dictionary<int, string> codeTexts, string allowNullDisplayText = "", string valueMember = "Code", string displayMember = "Text")
        {
            var qry = new SqlQuery();
            var dt = qry.DataTable;
            dt.Columns.Add(valueMember, typeof(int));
            dt.Columns.Add(displayMember, typeof(string));

            if (AllowNull)
            {
                var rowNull = dt.NewRow();
                rowNull[displayMember] = allowNullDisplayText;
                dt.Rows.Add(rowNull);
            }

            foreach (var codeText in codeTexts)
            {
                var row = dt.NewRow();
                row[valueMember] = codeText.Key;
                row[displayMember] = codeText.Value;
                dt.Rows.Add(row);
            }

            LoadQuery(qry, valueMember, displayMember);
        }

        public void CancelEdit()
        {
            EditValue = _saveEditValue;
            _userModified = false;
        }

        /// <summary>
        /// Get the text that is displayed for the desired value
        /// </summary>
        /// <param name="value">The value to get text from</param>
        /// <returns>The text that is displayed for the value or "" if value was not found</returns>
        public string GetDisplayText(object value)
        {
            var qry = Properties.DataSource as SqlQuery;

            if (qry != null && Properties.ValueMember != null && Properties.DisplayMember != null && !DBUtil.IsEmpty(value))
            {
                foreach (DataRow row in qry.DataTable.Rows)
                {
                    try
                    {
                        if ((int)row[Properties.ValueMember] == (int)value)
                        {
                            return row[Properties.DisplayMember].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in GetDisplayText: {0}", ex.Message);
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets a value indicating whether editing is allowed.
        /// </summary>
        /// <param name="value"></param>
        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (_editMode != EditModeType.ReadOnly)
            {
                if (value)
                    GuiConfig.SetEditMode(this, _editMode);
                else
                    GuiConfig.SetEditMode(this, EditModeType.ReadOnly);
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

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        void ISupportInitialize.BeginInit()
        {
            _inInit = true;
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        void ISupportInitialize.EndInit()
        {
            _inInit = false;
            ReadLOV();
        }

        /// <summary>
        /// Handles the loaded event.
        /// </summary>
        public void Loaded()
        {
            OnLoaded();
        }

        /// <summary>
        /// Fill the SqlQuery into the dropdown window.
        /// Set ValueMember to Code and DisplayMember to Text
        /// </summary>
        /// <param name="qry">Sets the source of data displayed in the dropdown window.</param>
        public void LoadQuery(SqlQuery qry)
        {
            LoadQuery(qry, ValueMember, DisplayMember);
        }

        /// <summary>
        /// Fill the SqlQuery into the dropdown window.
        /// </summary>
        /// <param name="qry">Sets the source of data displayed in the dropdown window.</param>
        /// <param name="valueMember">Sets the field name whose values identify dropdown rows.</param>
        /// <param name="displayMember">Sets the field whose values are displayed in the edit box.</param>
        public void LoadQuery(SqlQuery qry, string valueMember, string displayMember)
        {
            Properties.ValueMember = valueMember;
            Properties.DisplayMember = displayMember;

            Properties.Columns.Clear();
            Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember));

            Properties.DropDownRows = Math.Min(qry.Count, 7);
            Properties.DataSource = qry;
        }

        /// <summary>
        /// Read the defines lov-values and apply items to list
        /// </summary>
        public void ReadLOV()
        {
            if (IsDesignMode || Session.User == null)
            {
                return;
            }

            ReadLOV(Session.User.LanguageCode);
        }

        public void SelectFirstItem()
        {
            if (Properties.DataSource == null
                || Properties.ValueMember == null)
            {
                EditValue = null;
            }

            EditValue = Properties.GetDataSourceValue(Properties.ValueMember, 0);
        }

        /// <summary>
        /// Sort items by column index ascending
        /// </summary>
        /// <param name="columnIndex">The column index to use</param>
        /// <returns>True if successfully applied sorting, otherwise false</returns>
        public bool SortByColumn(int columnIndex)
        {
            return SortByColumn(columnIndex, true);
        }

        /// <summary>
        /// Sort items by column index
        /// </summary>
        /// <param name="columnIndex">The column index to use</param>
        /// <param name="ascending">True if sorting ascending, otherwise sorting descending</param>
        /// <returns>True if successfully applied sorting, otherwise false</returns>
        public bool SortByColumn(int columnIndex, bool ascending)
        {
            // validate if possible
            if (Properties.Columns == null || columnIndex < 0 || columnIndex >= Properties.Columns.Count)
            {
                // invalid values
                return false;
            }

            // setup properties
            Properties.SortColumnIndex = columnIndex;
            Properties.Columns[columnIndex].SortOrder = ascending ? DevExpress.Data.ColumnSortOrder.Ascending : DevExpress.Data.ColumnSortOrder.Descending;

            // ok
            return true;
        }

        /// <summary>
        /// Sort items by first column ascending
        /// </summary>
        /// <returns>True if successfully applied sorting, otherwise false</returns>
        public bool SortByFirstColumn()
        {
            return SortByColumn(0, true);
        }

        /// <summary>
        /// Update the KissLookUpEdit with translated items to defined languagecode
        /// </summary>
        /// <param name="languageCode">The languagecode to use</param>
        public void Translate(int languageCode)
        {
            ReadLOV(languageCode);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates the popup form.
        /// </summary>
        /// <remarks>Workaround Devexpress Popup below Taskbar</remarks>
        /// <returns>Popup form to show</returns>
        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            // create new form
            DevExpress.XtraEditors.Popup.PopupBaseForm frm = base.CreatePopupForm();

            // check if we have a form
            if (frm != null)
            {
                // make form topmost
                frm.TopMost = true;

                // apply form to field and attach events
                _popupForm = frm;
                _popupForm.KeyPress += popupForm_KeyPress;
                _popupForm.MouseWheel += popupForm_MouseWheel;
            }

            // return form
            return frm;
        }

        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();
            ApplyIsActiveFilter();
        }

        /// <summary>
        /// Called when [enter key].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEnterKey(object sender, KeyEventArgs e)
        {
            if (onEnterKey != null)
            {
                onEnterKey(sender, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SelectAll();
        }

        /// <summary>
        /// Raises the <see cref="E:KeyDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                OnEnterKey(this, e);

            //open/close popup with F12
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.F12)
            {
                if (IsPopupOpen)
                {
                    ClosePopup();
                }
                else
                {
                    ShowPopup();
                }

                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Called when the control has lost the focus
        /// </summary>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (UserModified)
            {
                OnUserModifiedFld(this, new UserModifiedFldEventArgs(false, false));
            }
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            Properties.NullText = "";
            Properties.AppearanceDropDown.BackColor = GuiConfig.GridReadOnly;
            Properties.AppearanceDropDown.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            Properties.AppearanceDropDown.Options.UseBackColor = true;
            Properties.AppearanceDropDown.Options.UseFont = true;

            GuiConfig.SetEditMode(this, EditMode);

            foreach (DevExpress.XtraEditors.Controls.EditorButton btn in Properties.Buttons)
            {
                btn.Style.BackColor = GuiConfig.EditButtonColor;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DesignMode && _dataMember != "")
            {
                e.Graphics.DrawString("[" + _dataMember + "]", Font, Brushes.Black, new RectangleF(2, 4, Width - 15, Height - 6));
            }
        }

        /// <summary>
        /// Occures when the popup form is closed. Unregister the special topmost-eventhandling methods again.
        /// </summary>
        /// <param name="closeMode">The close mode</param>
        protected override void OnPopupClosed(DevExpress.XtraEditors.PopupCloseMode closeMode)
        {
            // check if form is registered
            if (_popupForm != null)
            {
                // unregister events
                _popupForm.KeyPress -= popupForm_KeyPress;
                _popupForm.MouseWheel -= popupForm_MouseWheel;

                // destroy reference
                _popupForm = null;
            }

            if (UserModified)
            {
                OnUserModifiedFld(this, new UserModifiedFldEventArgs(false, false));
            }

            // let base do stuff
            base.OnPopupClosed(closeMode);
        }

        /// <summary>
        /// Called when [query pop up].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        protected virtual void OnQueryPopUp(object sender, CancelEventArgs e)
        {
            ApplyIsActiveFilter();
        }

        /// <summary>
        /// Called when [user modified FLD].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KiSS4.Gui.UserModifiedFldEventArgs"/> instance containing the event data.</param>
        protected virtual void OnUserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (onUserModifiedFld != null)
            {
                onUserModifiedFld(sender, e);

                if (e.Cancel)
                {
                    CancelEdit();
                    Focus();
                }
                else
                {
                    if (_dataSource != null)
                    {
                        _dataSource.RefreshDisplay();
                    }
                }
            }
        }

        /// <summary>
        /// Read the defines lov-values and apply items to list
        /// </summary>
        /// <param name="languageCode">The languagecode to use for displaying items</param>
        protected void ReadLOV(int languageCode)
        {
            if (_lovName == "")
            { return; }
            if (IsDesignMode)
            { return; }

            var filter = string.Empty;

            if (!DBUtil.IsEmpty(_lovFilter))
            {
                // check if user defines filter as own sql statement
                if (_isLovFilterWhereAppend)
                {
                    // combine string here directly due to problems with lovFilter as parameter in OpenSQL()
                    filter += string.Format("AND {0}", _lovFilter);
                }
                else
                {
                    filter += string.Format("AND ',' + IsNull(LOV.Value3,'') + ',' LIKE '%,' + {0} + ',%'", DBUtil.SqlLiteral(_lovFilter));
                }
            }

            LoadQuery(DBUtil.GetLOVQuery(_lovName, languageCode, _allowNull, filter, FilterOnIsActive, _lovOrderbyColumn));

            Properties.ShowFooter = false;
            Properties.ShowHeader = false;

            ApplyIsActiveFilter();
        }

        #endregion

        #region Private Methods

        private void ApplyIsActiveFilter()
        {
            bool setDataViewAsDataSource = false;

            var dataView = Properties.DataSource as DataView;

            if (dataView == null)
            {
                var itemsSource = Properties.DataSource as SqlQuery;

                if (itemsSource != null)
                {
                    if (itemsSource.DataTable.DefaultView != null)
                    {
                        dataView = itemsSource.DataTable.DefaultView;
                    }
                    else
                    {
                        dataView = new DataView(itemsSource.DataTable);
                        setDataViewAsDataSource = true;
                    }
                }
            }

            if (!FilterOnIsActive)
            {
                //make sure, there is no filter established
                if (dataView != null)
                {
                    dataView.RowFilter = null;
                    Properties.DropDownRows = Math.Min(dataView.Count, Properties.DropDownRows);
                }
            }
            else
            {
                if (setDataViewAsDataSource)
                {
                    Properties.DataSource = dataView;
                }

                if (dataView != null && DataSource != null && DataMember != null && !string.IsNullOrEmpty(DataMember) && dataView.Table.Columns.Contains("IsActive"))
                {
                    //only display active elements or the Null-element or the one representing the current EditValue
                    string rowFilter = string.Format("(IsActive = 1 OR Code IS NULL OR Code = {0})", DBUtil.SqlLiteral(DataSource[DataMember]));
                    dataView.RowFilter = rowFilter;
                    Properties.DropDownRows = Math.Min(dataView.Count, Properties.DropDownRows);
                }
            }
        }

        #endregion

        protected override void OnMouseEnter(EventArgs e)
        {
            //determine if we should show the selected item in a tooltip
            if (!_showSelectedItemInTooltip.HasValue)
            {
                //only if there was no ToolTip set
                _showSelectedItemInTooltip = string.IsNullOrEmpty(ToolTip);
            }

            if (_showSelectedItemInTooltip.Value)
            {
                this.ToolTip = this.Text;
            }

            base.OnMouseEnter(e);
        }

        #endregion
    }
}