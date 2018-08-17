using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissCalcEdit.
    /// </summary>
    public class KissCalcEdit : DevExpress.XtraEditors.CalcEdit, IKissBindableEdit, IKissEditable, IKissUserModified
    {
        #region Fields

        #region Private Fields

        private string dataMember = string.Empty;
        private SqlQuery dataSource;
        private EditModeType editMode = EditModeType.Normal;

        /// <summary>
        /// Store the created popup form to handle events.
        /// </summary>
        private DevExpress.XtraEditors.Popup.PopupBaseForm popupForm = null;

        private object saveEditValue;
        private bool userHasChanged;
        private bool userModified;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissCalcEdit"/> class.
        /// </summary>
        public KissCalcEdit()
        {
            base.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.OnFormatEditValue);
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Properties.ButtonsStyle = GuiConfig.EditButtonBorderStyle;
            GuiConfig.SetEditMode(this, EditModeType.Normal);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.FormatEditValue -= new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.OnFormatEditValue);
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
        /// Required designer variable.
        /// </summary>
        private event KeyEventHandler onEnterKey;

        #endregion

        #region Properties

        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
        {
            get { return dataMember; }
            set
            {
                dataMember = value;

                if (DesignMode)
                {
                    this.OnEditValueChanged();
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return editMode; }
            set
            {
                editMode = value;
                GuiConfig.SetEditMode(this, editMode);
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
                if (DesignMode && dataSource != null && dataMember != "")
                {
                    return null;
                }

                return base.EditValue;
            }
            set
            {
                saveEditValue = value;
                userModified = false;

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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get
            {
                return userModified || EditValue == null ? saveEditValue != null : !EditValue.Equals(saveEditValue);
            }
            set
            {
                if (value)
                {
                    userModified = true;
                }
                else
                {
                    saveEditValue = EditValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the editor's decimal value.
        /// </summary>
        /// <value>The editor's decimal value.</value>
        public override decimal Value
        {
            get
            {
                try
                {
                    if (this.EditValue == null)
                    {
                        return (decimal)0;
                    }

                    return base.Value.Equals((decimal)0) ? decimal.Parse(this.EditValue.ToString(), System.Globalization.NumberStyles.Any) : base.Value;
                }
                catch
                {
                    return (decimal)0;
                }
            }
            set
            {
                base.Value = value;
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
            this.EditValue = saveEditValue;
            userModified = false;
        }

        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (editMode != EditModeType.ReadOnly)
            {
                if (value)
                {
                    GuiConfig.SetEditMode(this, editMode);
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
        /// Informs registered instance about the Loaded event.
        /// </summary>
        public void Loaded()
        {
            OnLoaded();
        }

        public void SetEditModeIfDifferent(EditModeType mode)
        {
            if (EditMode == mode)
            {
                return;
            }

            EditMode = mode;
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
                popupForm = frm;
                popupForm.KeyPress += new KeyPressEventHandler(popupForm_KeyPress);
                popupForm.MouseWheel += new MouseEventHandler(popupForm_MouseWheel);
            }

            // return form
            return frm;
        }

        /// <summary>
        /// Called when [edit value changed].
        /// </summary>
        protected override void OnEditValueChanged()
        {
            string numberToParse = this.EditValue == null ? String.Empty : this.EditValue.ToString();

            try
            {
                if (numberToParse != String.Empty && numberToParse != "." && numberToParse != "-")
                {
                    decimal.Parse(numberToParse, System.Globalization.NumberStyles.Any).ToString();
                }
            }
            catch (Exception ex)
            {
                if (userHasChanged)
                {
                    KissMsg.ShowError("KissCalcEdit", "UngueltigeZahl", "Ihre Eingabe: \"{0}\" ist keine gültige Zahl.", ex.ToString(), null, 0, 0, numberToParse);
                    userHasChanged = false;
                }

                this.EditValue = this.fOldEditValue;
            }

            base.OnEditValueChanged();
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
        /// Called when [format edit value].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs"/> instance containing the event data.</param>
        protected virtual void OnFormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (DesignMode && this.dataMember != "")
            {
                e.Value = "[" + this.dataMember + "]";
            }
        }

        /// <summary>
        /// Raises the <see cref="E:GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            SelectAll();
        }

        /// <summary>
        /// Raises the <see cref="E:KeyDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                OnEnterKey(this, e);
            }

            // open/close popup with F12 (only if not disabled)
            if (e.Modifiers == Keys.None &&
                e.KeyCode == Keys.F12 &&
                this.Properties.ShowDropDown != DevExpress.XtraEditors.Controls.ShowDropDown.Never)
            {
                if (this.IsPopupOpen)
                {
                    this.ClosePopup();
                }
                else
                {
                    this.ShowPopup();
                }

                e.Handled = true;
            }

            // handle select all, copy, cut and paste  (otherwise it would be filtered out by OnKeyPress)
            if (UtilsGui.IsControlModifier(e) && e.KeyCode == Keys.A)
            {
                this.SelectAll();
                e.Handled = true;
            }
            else if (UtilsGui.IsControlModifier(e) && (e.KeyCode == Keys.C || (this.Properties.ReadOnly && e.KeyCode == Keys.X)))
            {
                this.Copy();
                e.Handled = true;
            }
            else if (UtilsGui.IsControlModifier(e) && !this.Properties.ReadOnly && e.KeyCode == Keys.V)
            {
                this.Paste();
                e.Handled = true;
            }
            else if (UtilsGui.IsControlModifier(e) && !this.Properties.ReadOnly && e.KeyCode == Keys.X)
            {
                bool selectedAll = this.SelectedText == this.Text;

                // cut the desired text (does not really work and will change the selected text...)
                this.Cut();
                this.DeleteSelectedText(e, true, selectedAll);
                e.Handled = true;
            }

            if (!e.Handled && e.KeyCode == Keys.Delete)
            {
                // handle delete editvalue
                e.Handled = this.DeleteSelectedText(e, false, false);
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:KeyPress"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            userHasChanged = true;

            // allowed Keys: 0..9, - (minus), . (dot) and backspace
            e.Handled = !((e.KeyChar >= '0' && e.KeyChar <= '9') ||
                           e.KeyChar == '-' ||
                           e.KeyChar == '.' ||
                           e.KeyChar == (char)Keys.Back);

            // handle backspace
            if (!e.Handled && e.KeyChar == (char)Keys.Back)
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

            // Remove Button for Calculator
            this.Properties.Buttons.Clear();

            GuiConfig.SetEditMode(this, EditMode);
        }

        /// <summary>
        /// Occures when the popup form is closed. Unregister the special topmost-eventhandling methods again.
        /// </summary>
        /// <param name="closeMode">The close mode</param>
        protected override void OnPopupClosed(DevExpress.XtraEditors.PopupCloseMode closeMode)
        {
            // check if form is registered
            if (popupForm != null)
            {
                // unregister events
                popupForm.KeyPress -= new KeyPressEventHandler(popupForm_KeyPress);
                popupForm.MouseWheel -= new MouseEventHandler(popupForm_MouseWheel);

                // destroy reference
                popupForm = null;
            }

            // let base do stuff
            base.OnPopupClosed(closeMode);
        }

        protected override void OnSpin(DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            //Mantis #6748 - Betragsfelder sollen nicht mit Scrollen verändert werden
            //do nothing
        }

        /// <summary>
        /// Parses the editor value.
        /// </summary>
        protected override void ParseEditorValue()
        {
            if (!IsModified)
            {
                return;
            }

            if (EditValue is string && EditValue.ToString() == "")
            {
                EditValue = null;
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
            // Get the currently set thousands separator character
            char thousandsSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator[0];

            // check if any text is marked
            if (this.SelectedText.Length < 1 || this.Properties.ReadOnly)
            {
                if (e.KeyCode == Keys.Delete && this.SelectionStart < this.Text.Length)
                {
                    // Delete the next character on the right
                    this.SelectionLength = 1;

                    // Check if we hit a thousands-separator charachter
                    if (this.SelectionStart + 1 < this.Text.Length && this.Text[this.SelectionStart + 1] == thousandsSeparator)
                    {
                        // Yes, thousands-character, so let's expand the selection one to the right
                        this.SelectionLength++;
                    }
                }
                else if (e.KeyCode == Keys.Back && this.SelectionStart > 0)
                {
                    // Delete the previous character on the left
                    int selectionStartBefore = this.SelectionStart;
                    this.SelectionStart--;
                    this.SelectionLength = 1;

                    // Check if we hit a thousands-separator charachter
                    if (this.SelectionStart == selectionStartBefore && this.SelectionStart > 1) // Note: This kind of test is only necessary for Back, not for Delete as the underlying CalcEdit handle the Delete correctly
                    {
                        // The selectionstart was not changed. This is the behavior of CalcEdit in case we are just left of at a thousands-separator.
                        // In this case, increase the selection one character to the left
                        this.SelectionStart = this.SelectionStart - 2;
                        this.SelectionLength = 2;
                    }
                    // Check if the next character on the left is a thounds-separator charachter
                    else if (this.SelectionStart > 0 && this.Text[this.SelectionStart - 1] == thousandsSeparator)
                    {
                        // Yes, thounds-character, so let's expand the selection one to the left
                        this.SelectionStart--;
                        this.SelectionLength = 2;
                    }
                }
                else
                {
                    return false;
                }
            }

            // handle delete selection
            if (!Properties.ReadOnly && (forceHandle || forceClear || (e.Modifiers == Keys.None && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back))))
            {
                if ((forceClear || SelectedText == Text))
                {
                    // delete content
                    base.EditValue = null;
                }
                else
                {
                    // delete only selected text
                    SelectedText = string.Empty;
                }
                // handled
                return true;
            }

            // not handled
            return false;
        }

        #endregion

        #endregion
    }
}