using System;
using System.ComponentModel;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissMemoEdit.
	/// </summary>
	public class KissMemoEdit : DevExpress.XtraEditors.MemoEdit, IKissBindableEdit, IKissEditable, IKissUserModified
	{
		#region Fields

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private event KeyEventHandler onEnterKey;
		private EditModeType editMode = EditModeType.Normal;
		private SqlQuery dataSource;
		private string dataMember = string.Empty;
		private bool proportionalFont = true;

		/// <summary>
		/// Set and get if double click within memoedit will open the editor dialog
		/// </summary>
		private bool doubleClickOpenDialog = true;

		#endregion

		/// <summary>
		/// Constructor to init a new KissMemoEdit
		/// </summary>
		public KissMemoEdit()
		{
			GuiConfig.SetEditMode(this, EditModeType.Normal);
			this.TextChanged += new EventHandler(KissMemoEdit_TextChanged);
			base.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.OnFormatEditValue);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			this.TextChanged -= new EventHandler(KissMemoEdit_TextChanged);
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
		/// Loadeds this instance.
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
		/// Raises the <see cref="E:KeyDown"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F12)
			{
				OpenEditorDialog();
				e.Handled = true;
			}

			if (e.KeyCode == Keys.Return)
			{
				OnEnterKey(this, e);
			}

			if (UtilsGui.IsControlModifier(e) && (e.KeyCode == Keys.C || (this.Properties.ReadOnly && e.KeyCode == Keys.X)))
			{
				this.Copy();
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
		/// Raises the <see cref="E:System.Windows.Forms.Control.DoubleClick"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnDoubleClick(System.EventArgs e)
		{
			// only if allowed
			if (this.DoubleClickOpenDialog)
			{
				OpenEditorDialog();
			}
			else
			{
				base.OnDoubleClick(e);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the font is proportional.
		/// </summary>
		/// <value><c>true</c> if font is proportional; otherwise, <c>false</c>.</value>
		[Browsable(true)]
		[DefaultValue(true)]
		public bool ProportionalFont
		{
			get { return proportionalFont; }
			set { proportionalFont = value; }
		}

		/// <summary>
		/// Set and get if double click within memoedit will open the editor dialog. If false, only F12 will open the editor.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(true)]
		[Description("Set and get if double click within memoedit will open the editor dialog. If false, only F12 will open the editor.")]
		public bool DoubleClickOpenDialog
		{
			get { return this.doubleClickOpenDialog; }
			set { this.doubleClickOpenDialog = value; }
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

		#endregion

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
				// MemoEdit does not work with \n so we must replace by <CR><LF>.
				// (Second replace just corrects <CR><LF> that was already correct in the beginning).
				if (value != System.DBNull.Value && value != null)
					value = value.ToString().Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");

				saveEditValue = value;
				userModified = false;

				try
				{
					base.EditValue = value;
				}
				catch { };
			}
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
			set { dataMember = value; }
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

		private static System.Text.RegularExpressions.Regex regExNewLine = new System.Text.RegularExpressions.Regex(@"(?<!Environment\.)NewLine");

		private void KissMemoEdit_TextChanged(object sender, EventArgs e)
		{
			if (this.Text.IndexOf("NewLine") >= 0)
				this.Text = regExNewLine.Replace(this.Text, Environment.NewLine);
		}

		/// <summary>
		/// Opens the editor dialog.
		/// </summary>
		public void OpenEditorDialog()
		{
			if (this.Parent is DlgMemoEdit) return;

			DlgMemoEdit dlg = new DlgMemoEdit(Properties.ReadOnly, Font);
			dlg.MemoEditor.EditValue = this.EditValue;
			dlg.RestoreLayout();
			if (dlg.ShowDialog() == DialogResult.OK)
				base.EditValue = dlg.MemoEditor.EditValue;
		}
	}
}
