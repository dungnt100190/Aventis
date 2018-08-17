using System;
using System.ComponentModel;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissDateEdit.
	/// </summary>
	public class KissTimeEdit : DevExpress.XtraEditors.TimeEdit, IKissBindableEdit, IKissEditable, IKissUserModified
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private event KeyEventHandler onEnterKey;
		private EditModeType editMode = EditModeType.Normal;
		private SqlQuery dataSource;
		private string dataMember = String.Empty;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissTimeEdit"/> class.
		/// </summary>
		public KissTimeEdit()
		{
			base.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.OnFormatEditValue);
			this.Properties.ButtonsStyle = GuiConfig.EditButtonBorderStyle;
			this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.Properties.DisplayFormat.FormatString = "t";
			this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.Properties.EditFormat.FormatString = "t";
			GuiConfig.SetEditMode(this, EditModeType.Normal);

			base.EditValue = null;
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
		/// Informas regsitered instances about the loaded event.
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
		/// Handle the OnKeyPress event.
		/// Back: Delete selected text
		/// </summary>
		/// <param name="e">The event arguments</param>
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			// handle backspace
			if (e.KeyChar == (char)Keys.Back)
			{
				e.Handled = this.DeleteSelectedText(new System.Windows.Forms.KeyEventArgs((Keys)e.KeyChar), false, false);
			}

			if (!e.Handled)
			{
				base.OnKeyPress(e);
			}
		}

		/// <summary>
		/// Handle the OnKeyDown event.
		/// Back: Delete selected text
		/// CTRL+A: Select whole text
		/// CTRL+C: Copy selected text to clipboard
		/// CTRL+V: Paste content from clipboard
		/// CTRL+X: Cut selected text
		/// </summary>
		/// <param name="e">The event arguments</param>
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				OnEnterKey(this, e);
			}

			//handle select all, copy, cut and paste  (otherwise it would be filtered out by OnKeyPress)
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
		/// Called when [enter key].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnterKey(object sender, KeyEventArgs e)
		{
			if (onEnterKey != null) onEnterKey(sender, e);
		}

		/// <summary>
		/// Parses the editor value.
		/// </summary>
		protected override void ParseEditorValue()
		{
			if (!IsModified) return;
			if (EditValue is string && EditValue.ToString() == "")
			{
				EditValue = null;
			}
		}

		/// <summary>
		/// Delete selected text depending on keys or mode
		/// </summary>
		/// <param name="e">KeyEventArgs received from event</param>
		/// <param name="forceHandle">Do not check keys</param>
		/// <param name="forceClear">Do delete the editvalue anyway</param>
		/// <returns>True if input was handled, false if nothing was done</returns>
		private bool DeleteSelectedText(System.Windows.Forms.KeyEventArgs e, bool forceHandle, bool forceClear)
		{
			// check if any text is marked
			if (this.SelectedText.Length < 1)
			{
				return false;
			}

			// handle delete selection
			if (forceHandle || forceClear || (e.Modifiers == Keys.None && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)))
			{
				if (forceClear || this.SelectedText == this.Text)
				{
					// delete content
					base.EditValue = null;

					// handled
					return true;
				}
				else
				{
					// delete only selected text
					this.SelectedText = "";

					// handled
					return true;
				}
			}

			// not handled
			return false;
		}

		/// <summary>
		/// Called when [format edit value].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs"/> instance containing the event data.</param>
		protected virtual void OnFormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
		{
			if (DesignMode && this.dataMember != "")
				e.Value = "[" + this.dataMember + "]";
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
		/// Gets or sets the editor's value.
		/// </summary>
		/// <value>An object representing the editor's value.</value>
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
	}
}
