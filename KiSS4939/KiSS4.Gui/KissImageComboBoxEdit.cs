using System;
using System.ComponentModel;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissLookUpEdit.
    /// </summary>
    public class KissImageComboBoxEdit : DevExpress.XtraEditors.ImageComboBoxEdit, IKissBindableEdit, IKissEditable, IKissUserModified
    {
        private string dataMember = String.Empty;

        private SqlQuery dataSource;

        private EditModeType editMode = EditModeType.Normal;

        /// <summary>
        /// Initializes a new instance of the <see cref="KissImageComboBoxEdit"/> class.
        /// </summary>
        public KissImageComboBoxEdit()
        {
            this.Properties.ButtonsStyle = GuiConfig.EditButtonBorderStyle;
            GuiConfig.SetEditMode(this, EditModeType.Normal);
        }

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

        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return editMode; }
            set { editMode = value; GuiConfig.SetEditMode(this, editMode); }
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
        /// Occurs when loaded.
        /// </summary>
        public void Loaded()
        {
            OnLoaded();
        }

        /// <summary>
        /// Called when [enter key].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEnterKey(object sender, KeyEventArgs e)
        {
            if (onEnterKey != null) onEnterKey(sender, e);
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
            if (e.KeyCode == Keys.Return) OnEnterKey(this, e);
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.Properties.NullText = "";

            this.Properties.AppearanceDropDown.BackColor = GuiConfig.GridReadOnly;
            this.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.Properties.AppearanceDropDown.Options.UseFont = true;

            GuiConfig.SetEditMode(this, EditMode);
        }

        #region IKissUserModified

        private object saveEditValue;
        private bool userModified;

        /// <summary>
        /// Gets or sets the editor's value.
        /// </summary>
        /// <value>The object representing the edit value.</value>
        [Browsable(true)]
        [DefaultValue(null)]
        new public object EditValue
        {
            get
            {
                if (DesignMode && dataSource != null && dataMember != "") return null;
                return base.EditValue;
            }
            set
            {
                saveEditValue = value;
                userModified = false;

                base.EditValue = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get { return userModified || EditValue == null ? saveEditValue != null : !EditValue.Equals(saveEditValue); }
            set { if (value) userModified = true; else saveEditValue = EditValue; }
        }

        public void CancelEdit()
        {
            this.EditValue = saveEditValue;
            userModified = false;
        }

        #endregion

        #region IKissBindableEdit

        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
        {
            get { return dataMember; }
            set { dataMember = value; }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        /// <summary>
        /// Gets a value indicating whether editing is allowed.
        /// </summary>
        /// <param name="value"></param>
        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (editMode != EditModeType.ReadOnly)
            {
                if (value)
                    GuiConfig.SetEditMode(this, editMode);
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

        #endregion

        #region Workaround: TopMost popup form handling

        /// <summary>
        /// Store the created popup form to handle events.
        /// </summary>
        private DevExpress.XtraEditors.Popup.PopupBaseForm popupForm = null;

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
    }
}