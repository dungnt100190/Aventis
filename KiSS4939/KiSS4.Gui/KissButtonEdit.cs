using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.DB.Designer;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissButtonEdit.
    /// </summary>
    public class KissButtonEdit : ButtonEdit, IKissBindableEdit, IKissEditable, IKissUserModified
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// The context value #1.
        /// </summary>
        public object ContextValue1;

        /// <summary>
        /// The context value #2.
        /// </summary>
        public object ContextValue2;

        /// <summary>
        /// The context value #3.
        /// </summary>
        public object ContextValue3;

        #endregion

        #region Protected Fields

        /// <summary>
        /// The data source.
        /// </summary>
        protected SqlQuery _dataSource;

        /// <summary>
        /// The editMode.
        /// </summary>
        protected EditModeType _editMode = EditModeType.Normal;

        protected bool _inUserModifiedFldEvent;

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The SQL Delimiter.
        /// </summary>
        private const string SQL_DELIMITER = "----";

        #endregion

        #region Private Fields

        /// <summary>
        /// The data member.
        /// </summary>
        private string _dataMember = string.Empty;

        private string _dtoTextSQL;
        private object _lookupID;
        private string _lookupSQL = string.Empty;
        private object _saveEditValue;
        private String[] _searchStringWhitelist = new string[] { ".", "*", "%" };
        private bool _userModified;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissButtonEdit"/> class.
        /// </summary>
        public KissButtonEdit()
        {
            FormatEditValue += OnFormatEditValue;
            ButtonClick += OnButtonClicked;
            Properties.ButtonsStyle = GuiConfig.EditButtonBorderStyle;
            GuiConfig.SetEditMode(this, EditModeType.Normal);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [enter key].
        /// </summary>
        public event KeyEventHandler EnterKey
        {
            add { _onEnterKey += value; }
            remove { _onEnterKey -= value; }
        }

        /// <summary>
        /// Occurs when [lookup ID changed].
        /// </summary>
        public event EventHandler LookupIDChanged;

        /// <summary>
        /// Occurs when [user modified FLD].
        /// </summary>
        [Description("Raised when the User changed the EditValue and leaves the Control or presses the Button")]
        public event UserModifiedFldEventHandler UserModifiedFld
        {
            add { _onUserModifiedFld += value; }
            remove { _onUserModifiedFld -= value; }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private event KeyEventHandler _onEnterKey;

        private event UserModifiedFldEventHandler _onUserModifiedFld;

        #endregion

        #region Properties

        [Browsable(true)]
        [DefaultValue("")]
        public virtual string DataMember
        {
            get { return _dataMember; }
            set
            {
                _dataMember = value;
                if (DesignMode)
                {
                    OnEditValueChanged();
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public virtual SqlQuery DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public virtual EditModeType EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                GuiConfig.SetEditMode(this, _editMode);
            }
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
                {
                    return null;
                }

                if (UserModified)
                {
                    OnUserModifiedFld(this, new UserModifiedFldEventArgs(false, false));
                }

                return base.EditValue;
            }
            set
            {
                _saveEditValue = value;
                _userModified = false;

                if (_dtoTextSQL == null)
                {
                    _lookupID = null;
                }

                base.EditValue = value;
            }
        }

        /// <summary>
        /// Gets the enter key event.
        /// </summary>
        /// <value>The enter key event.</value>
        public KeyEventHandler EnterKeyEvent
        {
            get { return _onEnterKey; }
        }

        /// <summary>
        /// Gets or sets the lookup ID.
        /// </summary>
        /// <value>The lookup ID.</value>
        [Browsable(false)]
        [DefaultValue(null)]
        public object LookupID
        {
            get
            {
                if (UserModified)
                {
                    OnUserModifiedFld(this, new UserModifiedFldEventArgs(false, false));
                }

                return _lookupID;
            }
            set
            {
                _lookupID = value;

                if (!DBUtil.IsEmpty(_dtoTextSQL))
                {
                    try
                    {
                        EditValue = DBUtil.ExecuteScalarSQLThrowingException(_dtoTextSQL, _lookupID);
                    }
                    catch (Exception ex)
                    {
                        EditValue = DBNull.Value;

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                            Debugger.Break();
                        }
                    }
                }
                else if (_dtoTextSQL != null && DBUtil.IsEmpty(_lookupID))
                {
                    EditValue = DBNull.Value;
                }

                if (LookupIDChanged != null)
                {
                    LookupIDChanged(this, EventArgs.Empty);
                }
            }
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
            get
            {
                if (_dtoTextSQL == null)
                {
                    return _lookupSQL;
                }

                return _lookupSQL + SQL_DELIMITER + _dtoTextSQL;
            }

            set
            {
                if (value != null && value.IndexOf(SQL_DELIMITER) != -1)
                {
                    int p = value.IndexOf(SQL_DELIMITER);
                    _lookupSQL = value.Substring(0, p);
                    _dtoTextSQL = value.Substring(p + SQL_DELIMITER.Length);
                }
                else
                {
                    _lookupSQL = value;
                    _dtoTextSQL = null;
                }
            }
        }

        [Browsable(true), DefaultValue(0), Description("The minimum length a searchstring must have such that the event UserModifiedFld is triggered on Tab or on ButtonClick.")]
        public int SearchStringMinLength { get; set; }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("The list of searchstrings which are allowed to trigger UserModifiedFld even though they are shorter than the minimum length.")]
        public string[] SearchStringWhitelist
        {
            get { return _searchStringWhitelist; }
            set { _searchStringWhitelist = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get { return _userModified || base.EditValue == null ? _saveEditValue != null : !base.EditValue.Equals(_saveEditValue); }
            set
            {
                if (value)
                {
                    _userModified = true;
                }
                else
                {
                    _saveEditValue = EditValue;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void CancelEdit()
        {
            EditValue = _saveEditValue;
            _userModified = false;
        }

        /// <summary>
        /// Checks the pending search value.
        /// </summary>
        public void CheckPendingSearchValue()
        {
            UserModifiedFldEventArgs e = new UserModifiedFldEventArgs(false, false);

            if (UserModified)
            {
                OnUserModifiedFld(this, e);

                if (e.Cancel)
                {
                    throw new KissCancelException();
                }
            }
        }

        /// <summary>
        /// Gets the display text.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string GetDisplayText(object value)
        {
            if (DBUtil.IsEmpty(value))
            {
                return string.Empty;
            }

            if (_dtoTextSQL == null)
            {
                return value.ToString();
            }

            object text = DBNull.Value;

            try
            {
                text = DBUtil.ExecuteScalarSQL(_dtoTextSQL, value);
            }
            catch { }

            if (DBUtil.IsEmpty(text))
            {
                return string.Empty;
            }

            return text.ToString();
        }

        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (_editMode != EditModeType.ReadOnly)
            {
                if (value)
                {
                    GuiConfig.SetEditMode(this, _editMode);
                }
                else
                {
                    GuiConfig.SetEditMode(this, EditModeType.ReadOnly);
                }
            }
        }

        string IKissBindableEdit.GetBindablePropertyName()
        {
            return _dtoTextSQL == null ? "EditValue" : "LookupID";
        }

        /// <summary>
        /// Handles the loaded event.
        /// </summary>
        public void Loaded()
        {
            OnLoaded();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Called when [button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnButtonClicked(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button == Properties.Buttons[0] && EditMode != EditModeType.ReadOnly)
            {
                OnUserModifiedFld(sender, new UserModifiedFldEventArgs(true, false));
            }
        }

        /// <summary>
        /// Called when [enter key].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEnterKey(object sender, KeyEventArgs e)
        {
            if (_onEnterKey != null)
            {
                _onEnterKey(sender, e);
            }
        }

        /// <summary>
        /// Called when [format edit value].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ConvertEditValueEventArgs"/> instance containing the event data.</param>
        protected virtual void OnFormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (DesignMode && _dataMember != "")
            {
                e.Value = "[" + _dataMember + "]";
            }
        }

        /// <summary>
        /// Raises the <see cref="Control.GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SelectAll();
        }

        /// <summary>
        /// Raises the <see cref="Control.KeyDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                OnEnterKey(this, e);
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="Control.Leave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
            GuiConfig.SetEditMode(this, EditMode);

            foreach (EditorButton btn in Properties.Buttons)
            {
                btn.Style.BackColor = GuiConfig.EditButtonColor;
            }
        }

        /// <summary>
        /// Called when [user modified FLD].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UserModifiedFldEventArgs"/> instance containing the event data.</param>
        protected virtual void OnUserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (_inUserModifiedFldEvent)
            {
                return;
            }

            _inUserModifiedFldEvent = true;

            try
            {
                if (_onUserModifiedFld != null)
                {
                    //check MinLengthSearchString
                    if (!CheckSearchString(EditValue))
                    {
                        //don't trigger event
                        CancelEdit();
                        Focus();
                        return;
                    }

                    _onUserModifiedFld(sender, e);

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
                else if (_lookupSQL != null && _lookupSQL.Trim() != "")
                {
                    //check MinLengthSearchString
                    if (!CheckSearchString(Text))
                    {
                        //don't trigger event
                        CancelEdit();
                        Focus();
                        return;
                    }

                    if (DBUtil.IsEmpty(EditValue) && !e.ButtonClicked)
                    {
                        EditValue = DBNull.Value;
                        _lookupID = null;

                        if (LookupIDChanged != null)
                        {
                            LookupIDChanged(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        KissLookupDialog dlg = new KissLookupDialog();

                        string searchString = Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

                        if (dlg.SearchData(_lookupSQL, searchString, e.ButtonClicked, ContextValue1, ContextValue2, ContextValue3))
                        {
                            EditValue = dlg[1]; //set EditValue first, because lookupID is reset setting EditValue
                            _lookupID = dlg[0];

                            if (LookupIDChanged != null)
                            {
                                LookupIDChanged(this, EventArgs.Empty);
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            CancelEdit();
                            Focus();
                        }
                    }
                }
            }
            finally
            {
                _inUserModifiedFldEvent = false;
            }
        }

        private bool CheckSearchString(object searchStringObject)
        {
            if (SearchStringMinLength == 0)
            {
                return true;
            }

            if (searchStringObject == null)
            {
                return false;
            }

            var searchString = searchStringObject.ToString();
            if (searchString.Length < SearchStringMinLength)
            {
                //does the searchstring match any entry of the whitelist?
                if (SearchStringWhitelist.Any(wl => wl.Equals(searchString)))
                {
                    return true;
                }

                KissMsg.ShowInfo("KissButtonEdit", "SuchbegriffZuKurz", "Der eingegebene Suchbegriff ist zu kurz. Bitte geben Sie einen längeren Suchbegriff ein (mind. {0} Zeichen).", SearchStringMinLength);
                return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}