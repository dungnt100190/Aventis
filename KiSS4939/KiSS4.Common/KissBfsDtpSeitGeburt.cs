using System;
using System.ComponentModel;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
	/// <summary>
	/// Summary description for KissBfsDtpSeitGeburt.
	/// </summary>
	public class KissBfsDtpSeitGeburt
		:
		KissComplexControl,
		IKissBindableEdit,
		IKissEditable
	{
		private KiSS4.Gui.KissDateEdit dtp;
		private KiSS4.Gui.KissCheckEdit chkbx;

		/// <summary>
		/// Occurs when [edit value changed].
		/// </summary>
		public event System.EventHandler EditValueChanged;

		private System.ComponentModel.Container components = null;
		private string dataMember;
		private SqlQuery dataSource;
		private EditModeType editMode;
		private bool allowEdit = false;

		/// <summary>
		/// Datum der Geburt.
		/// </summary>
		public static readonly DateTime SeitGeburtValue = new DateTime(9999, 1, 11);

		/// <summary>
		/// Initializes a new instance of the <see cref="KissBfsDtpSeitGeburt"/> class.
		/// </summary>
		public KissBfsDtpSeitGeburt()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KissBfsDtpSeitGeburt));
			this.dtp = new KiSS4.Gui.KissDateEdit();
			this.chkbx = new KiSS4.Gui.KissCheckEdit();
			((System.ComponentModel.ISupportInitialize)(this.dtp.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkbx.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// dtp
			// 
			this.dtp.Location = new System.Drawing.Point(1, 0);
			this.dtp.Name = "dtp";
			// 
			// dtp.Properties
			// 
			this.dtp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.dtp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Bitmap)(resources.GetObject("resource"))), new DevExpress.Utils.ViewStyle("EditorButtonStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
																										| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
																										| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
																										| DevExpress.Utils.StyleOptions.UseFont) 
																										| DevExpress.Utils.StyleOptions.UseForeColor) 
																										| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
																										| DevExpress.Utils.StyleOptions.UseImage) 
																										| DevExpress.Utils.StyleOptions.UseWordWrap) 
																										| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.Bisque, System.Drawing.SystemColors.ControlText))});
			this.dtp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.dtp.Properties.ShowClear = false;
			this.dtp.Properties.ShowToday = false;
			this.dtp.Properties.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.AliceBlue, System.Drawing.SystemColors.WindowText);
			this.dtp.Properties.StyleBorder = new DevExpress.Utils.ViewStyle("ControlStyleBorder", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
				 | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis)
				 | DevExpress.Utils.StyleOptions.UseDrawFocusRect)
				 | DevExpress.Utils.StyleOptions.UseFont)
				 | DevExpress.Utils.StyleOptions.UseForeColor)
				 | DevExpress.Utils.StyleOptions.UseHorzAlignment)
				 | DevExpress.Utils.StyleOptions.UseImage)
				 | DevExpress.Utils.StyleOptions.UseWordWrap)
				 | DevExpress.Utils.StyleOptions.UseVertAlignment))), false, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.Linen, System.Drawing.SystemColors.Control);
			this.dtp.Size = new System.Drawing.Size(90, 24);
			this.dtp.TabIndex = 21;
			this.dtp.EditValueChanged += new System.EventHandler(this.dtp_EditValueChanged);
			// 
			// chkbx
			// 
			this.chkbx.EditValue = false;
			this.chkbx.Location = new System.Drawing.Point(92, 3);
			this.chkbx.Name = "chkbx";
			// 
			// chkbx.Properties
			// 
			this.chkbx.Properties.Caption = "seit Geburt";
			this.chkbx.Properties.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlText);
			this.chkbx.Size = new System.Drawing.Size(100, 22);
			this.chkbx.TabIndex = 22;
			this.chkbx.EditValueChanged += new System.EventHandler(this.chkbx_EditValueChanged);
			// 
			// KissBfsDtpSeitGeburt
			// 
			this.Controls.Add(this.dtp);
			this.Controls.Add(this.chkbx);
			this.Name = "KissBfsDtpSeitGeburt";
			this.Size = new System.Drawing.Size(180, 24);
			((System.ComponentModel.ISupportInitialize)(this.dtp.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkbx.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

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
			get { return this.dataMember; }
			set { this.dataMember = value; }
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
			allowEdit = value;
			((IKissBindableEdit)this.chkbx).AllowEdit(value);
			((IKissBindableEdit)this.dtp).AllowEdit(value);
		}
		#endregion

		/// <summary>
		/// Raises the <see cref="E:EditValueChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected virtual void OnEditValueChanged(EventArgs e)
		{
			if (EditValueChanged != null)
				EditValueChanged(this, e);
		}

		/// <summary>
		/// Handles the EditValueChanged event of the dtp control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void dtp_EditValueChanged(object sender, EventArgs e)
		{
			OnEditValueChanged(e);
		}

		/// <summary>
		/// Handles the EditValueChanged event of the chkbx control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void chkbx_EditValueChanged(object sender, EventArgs e)
		{
			if (chkbx.Checked)
				dtp.EditValue = DBNull.Value;

			((IKissBindableEdit)dtp).AllowEdit(allowEdit && !chkbx.Checked);

			OnEditValueChanged(e);
		}

		/// <summary>
		/// Gets or sets the edit value.
		/// </summary>
		/// <value>The edit value.</value>
		[DefaultValue(null)]
		[Browsable(false)]
		public object EditValue
		{
			get
			{
				if (DesignMode && DataSource != null && DataMember != "") return null;

				if (chkbx.Checked)
					return SeitGeburtValue;
				else
					return dtp.EditValue;
			}

			set
			{
				if (value.Equals(SeitGeburtValue))
				{
					this.chkbx.Checked = true;
					this.dtp.EditValue = DBNull.Value;
				}
				else
				{
					this.chkbx.Checked = false;
					this.dtp.EditValue = value;
				}

				((IKissBindableEdit)dtp).AllowEdit(allowEdit && !chkbx.Checked);
			}
		}

		/// <summary>
		/// Liest oder setzt den EditMode.
		/// </summary>
		/// <value></value>
		[Browsable(true)]
		[DefaultValue(EditModeType.Normal)]
		public EditModeType EditMode
		{
			get
			{
				return editMode;
			}
			set
			{
				this.editMode = value;
				this.dtp.EditMode = value;
				this.chkbx.EditMode = value;
			}
		}
	}
}
