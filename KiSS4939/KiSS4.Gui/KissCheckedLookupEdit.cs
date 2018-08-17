using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.DB.Designer;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissCheckedLookupEdit.
    /// </summary>
    public class KissCheckedLookupEdit : CheckedListBoxControl, IKissBindableEdit, IKissEditable, IKissUserModified, ISupportInitialize
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ArrayList _codeList;

        #endregion

        #region Private Fields

        private string _dataMember = string.Empty;
        private EditModeType _editMode = EditModeType.Normal;
        private bool _inInit;
        private int _lastSelectedIndex = -1;
        private string _lookupSql = string.Empty;
        private string _lovFilter = string.Empty;
        private string _lovName = string.Empty;
        private string _saveEditValue;
        private int _shortedTextMaxLength;
        private SortOrder _sortOrder = SortOrder.None;
        private Dictionary<CheckedListBoxItem, string> _toolTipItemToLongText;
        private string _toolTipTextFieldName;
        private bool _userModified;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissCheckedLookupEdit"/> class.
        /// </summary>
        public KissCheckedLookupEdit()
        {
            MouseMove += KissCheckedLookupEdit_MouseMove;

            _codeList = new ArrayList();
            CheckOnClick = true;
            HandleToolTip = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [edit value changed].
        /// </summary>
        public event EventHandler EditValueChanged;

        /// <summary>
        /// Occurs when [enter key].
        /// </summary>
        public event KeyEventHandler EnterKey
        {
            add { onEnterKey += value; }
            remove { onEnterKey -= value; }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private event KeyEventHandler onEnterKey;

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
            get { return _dataMember; }
            set { _dataMember = value; }
        }

        /// <summary>
        /// Gets or sets the data source whose data is displayed by a list box control.
        /// </summary>
        /// <value>
        /// A data source object whose data is displayed by the list box control.
        /// </value>
        [Browsable(true)]
        [DefaultValue(null)]
        public new SqlQuery DataSource
        {
            get;
            set;
        }

        /// <summary>
        /// Liest oder setzt den EditMode
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
                GuiConfig.SetEditMode(this, _editMode);
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
            get
            {
                string editValue = "";
                foreach (int idx in CheckedIndices)
                {
                    if (editValue != "")
                    {
                        editValue += ",";
                    }
                    editValue += _codeList[idx];
                }
                return editValue;
            }
            set
            {
                foreach (CheckedListBoxItem item in Items)
                {
                    item.CheckState = CheckState.Unchecked;
                }

                if (!DBUtil.IsEmpty(value))
                {
                    foreach (string val in value.Split(new[] { ',' }))
                    {
                        int i = _codeList.IndexOf(val);

                        if (i != -1)
                        {
                            SetItemChecked(i, true);
                        }
                    }
                }
                _saveEditValue = EditValue;
                _userModified = false;

                // do not select any item by default
                ResetSelectedIndex();
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

        /// <summary>
        /// Gets or sets the lookup SQL.
        /// </summary>
        /// <value>The lookup SQL.</value>
        [Browsable(true)]
        [DefaultValue("")]
        [Editor(typeof(SqlStatementEditor), typeof(UITypeEditor))]
        public string LookupSQL
        {
            get { return _lookupSql; }
            set
            {
                _lookupSql = value;
                ReadLookup();
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
            get { return _lovFilter; }
            set { _lovFilter = value; }
        }

        /// <summary>
        /// Gets or sets the name of the LOV.
        /// </summary>
        /// <value>The name of the LOV.</value>
        [Browsable(true)]
        [DefaultValue("")]
        public string LOVName
        {
            get { return _lovName; }
            set
            {
                _lovName = value;
                if (!DesignMode && !_inInit)
                {
                    ReadLookup();
                }
            }
        }

        /// <summary>
        /// Get and set the max text length of a single checkboxitem.
        /// If the text is longer than the given amount, the text will be shorted and "..." will be added.
        /// The default is 0 which means no shortening.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(0)]
        [Description("Get and set the max text length of a single checkboxitem. If the text is longer than the given amount, the text will be shorted and \"...\" will be added. The default is 0 which means no shortening.")]
        public int ShortedTextMaxLength
        {
            get { return _shortedTextMaxLength; }
            set
            {
                _shortedTextMaxLength = value < 0 ? 0 : value;
            }
        }

        /// <summary>
        /// Get and set the max text length of a single checkboxitem.
        /// If the text is longer than the given amount, the text will be shorted and "..." will be added.
        /// The default is 0 which means no shortening.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("Get and set the tooltip-text fieldname to use for tooltip on single checkbox-item")]
        public string ToolTipTextFieldName
        {
            get { return _toolTipTextFieldName; }
            set
            {
                _toolTipTextFieldName = value;

                if (string.IsNullOrEmpty(_toolTipTextFieldName))
                {
                    // clear dictionary instance
                    _toolTipItemToLongText = null;
                    HandleToolTip = false;
                    return;
                }

                // init dictionary only if required
                if (_toolTipItemToLongText == null)
                {
                    _toolTipItemToLongText = new Dictionary<CheckedListBoxItem, string>();
                }
                else
                {
                    _toolTipItemToLongText.Clear();
                }

                HandleToolTip = true;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get { return _userModified || EditValue == null ? _saveEditValue != null : !EditValue.Equals(_saveEditValue); }
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

        [Browsable(false)]
        private bool HandleToolTip
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void KissCheckedLookupEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (!HandleToolTip)
            {
                return;
            }

            SetupToolTipController();
            var itemIndexUnderCursor = IndexFromPoint(e.Location);

            if (itemIndexUnderCursor >= 0 && itemIndexUnderCursor < Items.Count)
            {
                var itemUnderCursor = Items[itemIndexUnderCursor];

                if (_toolTipItemToLongText.ContainsKey(itemUnderCursor))
                {
                    var toolTipText = _toolTipItemToLongText[itemUnderCursor];

                    if (!string.IsNullOrEmpty(toolTipText))
                    {
                        ToolTipController.ShowHint(toolTipText);
                        return;
                    }
                }
            }

            ToolTipController.HideHint();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Sets a value indicating whether editing is allowed.
        /// </summary>
        /// <param name="value"></param>
        public void AllowEdit(bool value)
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

        public void CancelEdit()
        {
            EditValue = _saveEditValue;
            _userModified = false;
        }

        /// <summary>
        /// Gets the Code of an item as string.
        /// </summary>
        public string GetCodeFromItem(int index)
        {
            return (index < _codeList.Count) ? _codeList[index].ToString() : string.Empty;
        }

        /// <summary>
        /// Get the text depending corresponding to the given ids
        /// </summary>
        /// <param name="value">String containing the ids to get the text from (e.g. "2,4,5,9")</param>
        /// <returns>The text corresponding to the given ids</returns>
        public string GetDisplayText(string value)
        {
            string displayText = "";

            foreach (string val in value.Split(new[] { ',' }))
            {
                int i = _codeList.IndexOf(val);

                if (i != -1)
                {
                    if (displayText != "")
                    {
                        displayText += ";";
                    }
                    displayText += GetDisplayItemValue(i);
                }
            }

            return displayText;
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
            if (Items.Count == 0)
            {
                ReadLookup();
            }
        }

        /// <summary>
        /// Inform registered instnaces about the loaded event.
        /// </summary>
        public void Loaded()
        {
            OnLoaded();
        }

        /// <summary>
        /// Sets the lookup data source.
        /// </summary>
        /// <param name="qry">The qry.</param>
        public void SetLookupDataSource(SqlQuery qry)
        {
            SetLookupDataSource(qry, "Code", "Text");
        }

        /// <summary>
        /// Sets the lookup data source.
        /// </summary>
        /// <param name="qry">The qry.</param>
        /// <param name="valueMember">The value member.</param>
        /// <param name="displayMember">The display member.</param>
        public void SetLookupDataSource(SqlQuery qry, string valueMember, string displayMember)
        {
            // apply sorting if necessary
            switch (_sortOrder)
            {
                case SortOrder.Ascending:
                    qry.DataTable.DefaultView.Sort = string.Format("[{0}] ASC", displayMember);
                    break;

                case SortOrder.Descending:
                    qry.DataTable.DefaultView.Sort = string.Format("[{0}] DESC", displayMember);
                    break;
            }

            Items.Clear();
            _codeList.Clear();

            if (HandleToolTip)
            {
                _toolTipItemToLongText.Clear();
            }

            foreach (var row in
                qry.DataTable.DefaultView.Cast<DataRowView>()
                .Where(row => !DBUtil.IsEmpty(row[displayMember])))
            {
                CheckedListBoxItem checkBox;
                var displayTextObj = row[displayMember];
                var isShortedText = false;

                if (displayTextObj is string)
                {
                    var displayTextDefault = Convert.ToString(row[displayMember]);
                    var displayTextCheckBox = GetCheckBoxText(displayTextDefault);
                    isShortedText = displayTextCheckBox != displayTextDefault;

                    checkBox = new CheckedListBoxItem(displayTextCheckBox, false);
                }
                else
                {
                    checkBox = new CheckedListBoxItem(displayTextObj, false);
                }

                Items.Add(checkBox);
                _codeList.Add(row[valueMember].ToString());

                if (HandleToolTip && !DBUtil.IsEmpty(row[ToolTipTextFieldName]))
                {
                    // if we have another text than displayMember or text was shorted, we add checkbox to list in order to get tooltip-text available
                    // in case of same text as displayed and text was not shorted, we do not enable tooltip-text for this checkbox
                    if (ToolTipTextFieldName != displayMember || isShortedText)
                    {
                        _toolTipItemToLongText.Add(checkBox, row[ToolTipTextFieldName].ToString());
                    }
                }
            }

            // do not select any item by default
            ResetSelectedIndex();
        }

        /// <summary>
        /// Sort items alphabetically A-Z
        /// </summary>
        public void SortAZ()
        {
            // A-Z sorting
            SortItems(SortOrder.Ascending);
        }

        /// <summary>
        /// Sort items alphabetically A-Z, Z-A or by default from LOV
        /// </summary>
        /// <param name="newSortOrder">The sort order to apply</param>
        public void SortItems(SortOrder newSortOrder)
        {
            // setup field
            _sortOrder = newSortOrder;

            // refresh view (already done in Translate())
            Translate(Session.User.LanguageCode);
        }

        /// <summary>
        /// Translates to the specified language.
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        public void Translate(int languageCode)
        {
            if (DBUtil.IsEmpty(_lovName) && DBUtil.IsEmpty(_lookupSql))
            {
                return;
            }

            // get current editvalue
            string currentEditValue = EditValue;

            // translate list (this will reset selection)
            ReadLookup(languageCode);

            // reapply editvalue and recheck items
            EditValue = currentEditValue;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates the painter.
        /// </summary>
        /// <returns></returns>
        protected override BaseControlPainter CreatePainter()
        {
            return new KissPainterCheckedListBox();
        }

        /// <summary>
        /// Called when [change check].
        /// </summary>
        /// <param name="index">The index.</param>
        protected override void OnChangeCheck(int index)
        {
            base.OnChangeCheck(index);

            if (EditValueChanged != null)
            {
                EditValueChanged(this, null);
            }
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
        /// Raises the <see cref="GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            try
            {
                SelectedIndex = _lastSelectedIndex;
                base.OnGotFocus(e);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Raises the <see cref="KeyDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                OnEnterKey(this, e);
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            SetAppearance();
            GuiConfig.SetEditMode(this, EditMode);

            // do not select any item by default
            ResetSelectedIndex();
        }

        /// <summary>
        /// Raises the <see cref="LostFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            try
            {
                _lastSelectedIndex = SelectedIndex;
                SelectedIndex = -1; // HACK: Remove selected index in order to prevent having a blue selected item
                base.OnLostFocus(e);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Reads the lookup.
        /// </summary>
        protected void ReadLookup()
        {
            if (IsDesignMode || Session.User == null)
            {
                return;
            }

            ReadLookup(Session.User.LanguageCode);
        }

        /// <summary>
        /// Reads the lookup.
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        protected void ReadLookup(int languageCode)
        {
            _codeList.Clear();
            Items.Clear();

            if (DBUtil.IsEmpty(_lovName) && DBUtil.IsEmpty(_lookupSql))
            {
                return;
            }

            SqlQuery qry;

            if (DBUtil.IsEmpty(_lookupSql))
            {
                ////qry = DBUtil.GetLOVQuery(_lovName, languageCode, false);

                if (DBUtil.IsEmpty(_lovFilter))
                {
                    qry = DBUtil.GetLOVQuery(_lovName, languageCode, false);
                }
                else
                {
                    qry = DBUtil.GetLOVQuery(
                        _lovName,
                        languageCode,
                        false
                        ,
                        string.Format("AND ',' + ISNULL(Value3, '') + ',' LIKE '%,' + {0} + ',%'", DBUtil.SqlLiteral(_lovFilter)));
                }
            }
            else
            {
                qry = DBUtil.OpenSQL(_lookupSql);
            }

            // apply LOV
            SetLookupDataSource(qry);
        }

        #endregion

        #region Private Methods

        private string GetCheckBoxText(string textValue)
        {
            if (ShortedTextMaxLength < 1 || string.IsNullOrEmpty(textValue))
            {
                return textValue;
            }

            if (ShortedTextMaxLength < 4)
            {
                return "...";
            }

            // remove new-lines as those cannot be displayed properly
            textValue = textValue.Replace(Environment.NewLine, " ").Trim();

            if ((textValue.Length + 3) > ShortedTextMaxLength)
            {
                // shorted
                return string.Format("{0}...", textValue.Substring(0, ShortedTextMaxLength - 3).Trim());
            }

            // default without newlines
            return textValue;
        }

        /// <summary>
        /// Resets the index of the selected.
        /// </summary>
        private void ResetSelectedIndex()
        {
            try
            {
                _lastSelectedIndex = -1;
                SelectedIndex = -1;
            }
            catch
            {
            }
        }

        private void SetAppearance()
        {
            Appearance.BorderColor = GuiConfig.EditBorderColor;
            Appearance.Options.UseBorderColor = true;
        }

        private void SetupToolTipController()
        {
            if (ToolTipController != null)
            {
                return;
            }

            ToolTipController = new DevExpress.Utils.ToolTipController
            {
                Rounded = true,
                RoundRadius = 5,
                ToolTipLocation = DevExpress.Utils.ToolTipLocation.BottomCenter
            };
        }

        #endregion

        #endregion

        #region Nested Types

        /// <summary>
        /// Implements a CheckedListBox.
        /// </summary>
        public class KissPainterCheckedListBox : PainterCheckedListBox
        {
            #region Methods

            #region Protected Methods

            /// <summary>
            /// Draws the item core.
            /// </summary>
            /// <param name="info">The info.</param>
            /// <param name="itemInfo">The item info.</param>
            /// <param name="e">The <see cref="DevExpress.XtraEditors.ListBoxDrawItemEventArgs"/> instance containing the event data.</param>
            protected override void DrawItemCore(
                ControlGraphicsInfoArgs info,
                BaseListBoxViewInfo.ItemInfo itemInfo,
                ListBoxDrawItemEventArgs e)
            {
                //suppress highlighting of selected index
                itemInfo.State &= ~DrawItemState.Selected;
                base.DrawItemCore(info, itemInfo, e);
            }

            #endregion

            #endregion
        }

        #endregion
    }
}