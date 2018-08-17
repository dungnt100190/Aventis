using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissDateEdit.
    /// </summary>
    public class KissDateEdit : DateEdit, IKissBindableEdit, IKissEditable, IKissUserModified
    {
        #region Fields

        #region Private Fields

        private string _dataMember = string.Empty;
        private SqlQuery _dataSource;
        private EditModeType _editMode = EditModeType.Normal;

        /// <summary>
        /// Store the created popup form to handle events.
        /// </summary>
        private PopupBaseForm _popupForm;

        private object _saveEditValue;
        private bool _showingInfo;
        private bool _userModified;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissDateEdit"/> class.
        /// </summary>
        public KissDateEdit()
        {
            // Any initialization after the InitializeComponent call
            FormatEditValue += OnFormatEditValue;
            Properties.ButtonsStyle = GuiConfig.EditButtonBorderStyle;
            Properties.ShowToday = false;
            Properties.ShowClear = false;
            ParseEditValue += OnParseEditValue;

            GuiConfig.SetEditMode(this, EditModeType.Normal);

            base.EditValue = null;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            FormatEditValue -= OnFormatEditValue;
            base.Dispose(disposing);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [enter key].
        /// </summary>
        public event KeyEventHandler EnterKey
        {
            add { _enterKey += value; }
            remove { _enterKey -= value; }
        }

        private event KeyEventHandler _enterKey;

        #endregion

        #region Properties

        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
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
        public SqlQuery DataSource
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
        public EditModeType EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                GuiConfig.SetEditMode(this, _editMode);
            }
        }

        // TODO: EditValue Feldinhalt löschen, Speichern (Feld NICHT verlassen), alter wert wieder drinn
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

                ParseEditorValue();
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
            get { return _enterKey; }
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

        #endregion

        #region EventHandlers

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

        public void CancelEdit()
        {
            EditValue = _saveEditValue;
            _userModified = false;
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
            return "EditValue";
        }

        /// <summary>
        /// Determines whether [is needed key] [the specified e].
        /// </summary>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        /// <returns>
        /// 	<c>true</c> if [is needed key] [the specified e]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsNeededKey(KeyEventArgs e)
        {
            if (base.IsNeededKey(e))
            {
                return true;
            }

            if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ||
                 e.KeyCode == Keys.Right || e.KeyCode == Keys.Left ||
                 e.KeyCode == Keys.Enter) && IsPopupOpen)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Informs registered instnaces about the loaded event.
        /// </summary>
        public void Loaded()
        {
            OnLoaded();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates the popup form.
        /// </summary>
        /// <remarks>Workaround Devexpress Popup below Taskbar</remarks>
        /// <returns>Popup form to show</returns>
        protected override PopupBaseForm CreatePopupForm()
        {
            // create new form
            PopupBaseForm frm = base.CreatePopupForm();

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

        /// <summary>
        /// Called when [enter key].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEnterKey(object sender, KeyEventArgs e)
        {
            if (_enterKey != null)
                _enterKey(sender, e);
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
            if (Properties.ReadOnly)
            {
                base.OnKeyDown(e);
                return;
            }

            // Taste        Normal      Shift         Control
            // ---------------------------------------------------
            // +            + 1 Tag     + 1 Monat     + 1 Jahr
            // -            - 1 Tag     - 1 Monat     - 1 Jahr
            // space        heute       Jahresende    Jahresanfang

            // to prevent ArgumentOutOfRangeException
            if (e.KeyCode == Keys.Subtract && DateTime == DateTime.MinValue)
            {
                DateTime = DateTime.Today;
            }

            if (e.Modifiers == Keys.None)
            {
                switch (e.KeyCode)
                {
                    case Keys.Add:
                        DateTime = DateTime.AddDays(1);
                        e.Handled = true;
                        break;

                    case Keys.Subtract:
                        DateTime = DateTime.AddDays(-1);
                        e.Handled = true;
                        break;

                    case Keys.Space:
                        DateTime = DateTime.Today;
                        e.Handled = true;
                        break;
                }
            }
            else if (e.Modifiers == Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Add:
                        DateTime = DateTime.AddMonths(1);
                        e.Handled = true;
                        break;

                    case Keys.Subtract:
                        DateTime = DateTime.AddMonths(-1);
                        e.Handled = true;
                        break;

                    case Keys.Space:
                        DateTime = new DateTime(DateTime.Today.Year, 12, 31);
                        e.Handled = true;
                        break;
                }
            }
            else if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Add:
                        DateTime = DateTime.AddYears(1);
                        e.Handled = true;
                        break;

                    case Keys.Subtract:
                        DateTime = DateTime.AddYears(-1);
                        e.Handled = true;
                        break;

                    case Keys.Space:
                        DateTime = new DateTime(DateTime.Today.Year, 1, 1);
                        e.Handled = true;
                        break;
                }
            }

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

            //handle select all, copy, cut and paste  (otherwise it would be filtered out by OnKeyPress)
            if (UtilsGui.IsControlModifier(e) && e.KeyCode == Keys.A)
            {
                SelectAll();
                e.Handled = true;
            }
            else if (UtilsGui.IsControlModifier(e) && (e.KeyCode == Keys.C || (Properties.ReadOnly && e.KeyCode == Keys.X)))
            {
                Copy();
                e.Handled = true;
            }
            else if (UtilsGui.IsControlModifier(e) && !Properties.ReadOnly && e.KeyCode == Keys.V)
            {
                Paste();
                e.Handled = true;
            }
            else if (UtilsGui.IsControlModifier(e) && !Properties.ReadOnly && e.KeyCode == Keys.X)
            {
                bool selectedAll = SelectedText == Text;
                // cut the desired text (does not really work and will change the selected text...)
                Cut();
                DeleteSelectedText(e, true, selectedAll);
                e.Handled = true;
            }

            if (!e.Handled && e.KeyCode == Keys.Delete)
            {
                // handle delete editvalue
                e.Handled = DeleteSelectedText(e, false, false);
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="Control.KeyPress"/> event.
        /// </summary>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // allowed Keys: 0..9, dot and backspace
            e.Handled = !((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back);

            // handle backspace
            if (!Properties.ReadOnly && e.KeyChar == (char)Keys.Back)
            {
                e.Handled = DeleteSelectedText(new KeyEventArgs((Keys)e.KeyChar), false, false);
            }

            if (!e.Handled)
            {
                base.OnKeyPress(e);
            }
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            GuiConfig.SetEditMode(this, EditMode);

            if (Properties.Buttons.Count > 0)
            {
                EditorButton btn = Properties.Buttons[0];
                btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btn.Image = new Bitmap(typeof(KissDateEdit), "Calendar.bmp");
                btn.Style.BackColor = GuiConfig.EditButtonColor;
                btn.Width = 8;
            }

            // User can always delete content to null
            Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
        }

        /// <summary>
        /// Occures when the popup form is closed. Unregister the special topmost-eventhandling methods again.
        /// </summary>
        /// <param name="closeMode">The close mode</param>
        protected override void OnPopupClosed(PopupCloseMode closeMode)
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

            // let base do stuff
            base.OnPopupClosed(closeMode);
        }

        /// <summary>
        /// Raises the OnSpinEvent (depending on config value!)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSpin(SpinEventArgs e)
        {
            //auslöser: Mantis 0003099
            if (!Session.IsKiss5Mode && DBUtil.GetConfigBool(@"System\GUI\InFeldernScrollen", false))
            {
                base.OnSpin(e);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Delete selected text depending on keys or mode
        /// </summary>
        /// <param name="e">KeyEventArgs received from event</param>
        /// <param name="forceHandle">Do not check keys</param>
        /// <param name="forceClear">Do delete the editvalue anyway</param>
        /// <returns>True if input was handled, false if nothing was done</returns>
        private bool DeleteSelectedText(KeyEventArgs e, bool forceHandle, bool forceClear)
        {
            // check if any text is marked
            if (SelectedText.Length < 1)
            {
                return false;
            }

            // handle delete selection
            if (forceHandle || forceClear || (e.Modifiers == Keys.None && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)))
            {
                if (forceClear || SelectedText == Text)
                {
                    // delete content
                    base.EditValue = null;

                    // handled
                    return true;
                }

                // delete only selected text
                SelectedText = "";
                // handled
                return true;
            }

            // not handled
            return false;
        }

        /// <summary>
        /// Called when [parse edit value].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ConvertEditValueEventArgs"/> instance containing the event data.</param>
        private void OnParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            if (_showingInfo)
            {
                e.Value = EditValue;
                return;
            }

            if (e.Value is DateTime || e.Value == null || e.Value == DBNull.Value)
            {
                return;
            }

            if (e.Value is String && e.Value.ToString() == "")
            {
                e.Value = null;
            }
            else
            {
                string input = e.Value.ToString();

                try
                {
                    e.Value = System.DateTime.Parse(input);
                }
                catch
                {
                    e.Value = EditValue;
                    _showingInfo = true;
                    KissMsg.ShowInfo(
                        "KissDateEdit",
                        "UngueltigesDatum",
                        "Die Eingabe '{0}' kann nicht in ein gültiges Datum umgewandelt werden!\r\n\r\ngültige Beispiele:\r\n\r\n23.04.2001 - 7.11.01 - 3.4 - 2.12.4",
                        0,
                        0,
                        input);
                    _showingInfo = false;
                }
            }

            e.Value = DBUtil.Normalized(e.Value);
        }

        #endregion

        #endregion
    }
}