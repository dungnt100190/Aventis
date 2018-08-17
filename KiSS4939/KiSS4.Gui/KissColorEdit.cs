using System.ComponentModel;
using System.Windows.Forms;
using KiSS4.DB;
using Kiss.Interfaces.UI;


namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissComboBox.
	/// </summary>
	public class KissColorEdit : DevExpress.XtraEditors.ColorEdit, IKissBindableEdit, IKissEditable, IKissUserModified
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private event KeyEventHandler onEnterKey;
		private EditModeType editMode = EditModeType.Normal;
		private SqlQuery dataSource;
		private string dataMember = string.Empty;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissColorEdit"/> class.
		/// </summary>
		public KissColorEdit()
		{
			GuiConfig.SetEditMode(this, EditModeType.Normal);
			this.Properties.StoreColorAsInteger = true;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
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
		/// Inform registered instances about the loaded event.
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
		/// Gets or sets the selected color.
		/// </summary>
		/// <value>An object representing the currently selected color.</value>
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

		/// <summary>
		/// Gets the name of the bindable property.
		/// </summary>
		/// <returns></returns>
		string IKissBindableEdit.GetBindablePropertyName()
		{
			return "EditValue";
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
