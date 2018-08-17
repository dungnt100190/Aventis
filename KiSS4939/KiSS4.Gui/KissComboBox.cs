using System.ComponentModel;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissComboBox.
	/// </summary>
	public class KissComboBox : DevExpress.XtraEditors.ComboBoxEdit, IKissBindableEdit, IKissEditable, IKissUserModified
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private event KeyEventHandler onEnterKey;
		private EditModeType editMode = EditModeType.Normal;
		private SqlQuery dataSource;
		private string dataMember = string.Empty;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissComboBox"/> class.
		/// </summary>
		public KissComboBox()
		{
			base.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.OnFormatEditValue);
			this.Properties.ButtonsStyle = GuiConfig.EditButtonBorderStyle;
			GuiConfig.SetEditMode(this, EditModeType.Normal);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			base.FormatEditValue -= new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.OnFormatEditValue);
			base.Dispose(disposing);
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
		/// Occurs when [enter key].
		/// </summary>
		public event KeyEventHandler EnterKey
		{
			add { onEnterKey += value; }
			remove { onEnterKey -= value; }
		}

		/// <summary>
		/// Occurs when instance is loaded.
		/// </summary>
		public void Loaded()
		{
			OnLoaded();
		}

		/// <summary>
		/// Called when [loaded].
		/// </summary>
		protected override void OnLoaded()
		{
			base.OnLoaded();
			this.Properties.NullText = "";

			this.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Properties.AppearanceDropDown.Options.UseBackColor = true;
			this.Properties.AppearanceDropDown.Options.UseFont = true;

			GuiConfig.SetEditMode(this, EditMode);
			foreach (DevExpress.XtraEditors.Controls.EditorButton btn in this.Properties.Buttons)
			{
				btn.Style.BackColor = GuiConfig.EditButtonColor;
			}
		}

		/// <summary>
		/// Raises the <see cref="E:KeyDown"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return) OnEnterKey(this, e);

			//open/close popup with F12
			if (e.Modifiers == Keys.None && e.KeyCode == Keys.F12)
			{
				if (this.IsPopupOpen)
					this.ClosePopup();
				else
					this.ShowPopup();

				e.Handled = true;
			}

			base.OnKeyDown(e);
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

		#region IKissUserModified

		private object saveEditValue;

		private bool userModified;

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

		/// <summary>
		/// Specifies the edit value of the editor.
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
		#endregion

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

		#region IKissBindableEdit

		[Browsable(true)]
		[DefaultValue(null)]
		public SqlQuery DataSource
		{
			get { return dataSource; }
			set { dataSource = value; }
		}

		[Browsable(true)]
		[DefaultValue("")]
		public string DataMember
		{
			get { return dataMember; }
			set
			{
				dataMember = value;
				if (DesignMode)
					this.OnEditValueChanged();
			}
		}

		string IKissBindableEdit.GetBindablePropertyName()
		{
			return "EditValue";
		}

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
		#endregion

		#region Workaround: TopMost popup form handling

		/// <summary>
		/// Store the created popup form to handle events.
		/// </summary>
		DevExpress.XtraEditors.Popup.PopupBaseForm popupForm = null;

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
