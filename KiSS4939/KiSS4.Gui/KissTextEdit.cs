using System;
using System.ComponentModel;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissTextEdit.
	/// </summary>
	public class KissTextEdit : DevExpress.XtraEditors.TextEdit, IKissBindableEdit, IKissEditable, IKissUserModified
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private event KeyEventHandler onEnterKey;
		private event UserModifiedFldEventHandler onUserModifiedFld;
		private EditModeType editMode = EditModeType.Normal;
		private SqlQuery dataSource;
		private string dataMember = string.Empty;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissTextEdit"/> class.
		/// </summary>
		public KissTextEdit()
		{
			GuiConfig.SetEditMode(this, EditModeType.Normal);
			base.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.OnFormatEditValue);
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
		/// Raises the <see cref="E:KeyDown"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return) OnEnterKey(this, e);
			base.OnKeyDown(e);
		}

		/// <summary>
		/// Called when [enter key] is pressed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnterKey(object sender, KeyEventArgs e)
		{
			if (onEnterKey != null) onEnterKey(sender, e);
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

		/// <summary>
		/// Informs regisred instance of the Loaded event.
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

			if (!DesignMode && this.dataMember != "")
				this.EditValue = null;
		}

		/// <summary>
		/// Raises the <see cref="E:Leave"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			if (UserModified) OnUserModifiedFld(this, new UserModifiedFldEventArgs(false, false));
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
					this.CancelEdit();
					this.Focus();
				}
				else
					if (dataSource != null) dataSource.RefreshDisplay();
			}
		}

		/// <summary>
		/// Called when [format edit value].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs"/> instance containing the event data.</param>
		protected virtual void OnFormatEditValue(
			object sender,
			DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
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
			if (SelectionStart == 0) SelectAll();
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

		/// <summary>
		/// Gets a value that indicates whether the System.ComponentModel.Component is currently in design mode.
		/// </summary>
		/// <Returns>
		/// true if the System.ComponentModel.Component is in design mode; otherwise, false.
		/// </Returns>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected new bool DesignMode
		{
			get { return base.DesignMode || (this.Parent is KissComplexControl && ((KissComplexControl)this.Parent).DesignerMode); }
		}
	}
}
