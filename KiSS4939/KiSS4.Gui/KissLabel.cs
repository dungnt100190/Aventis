using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissTextEdit.
	/// </summary>
	public class KissLabel : Label, IKissBindableEdit, ISupportInitialize
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private bool InInit;

		private LabelStyleType labelStyle = LabelStyleType.EditFieldLabel;

		private SqlQuery dataSource;

		private String dataMember = "";

		/// <summary>
		/// Initializes a new instance of the <see cref="KissLabel"/> class.
		/// </summary>
		public KissLabel()
		{
			this.AutoSize = false;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region ISupportInitialize
		void ISupportInitialize.BeginInit()
		{
			InInit = true;
		}

		void ISupportInitialize.EndInit()
		{
			if (!this.DesignMode && dataMember != "")
				this.Text = "";
			InInit = false;
		}
		#endregion

		/// <summary>
		/// </summary>
		/// <value></value>
		public override string Text
		{
			get { return base.Text; }
			set
			{
				if (!DesignMode || dataMember == "")
				{
					// Designer: don't set Designer-Default value if Text != ""
					if (base.Text != string.Empty && this.Site != null && this.Site.Name == value) return;

					base.Text = value;
				}
			}
		}

		bool ShouldSerializeText()
		{
			return (dataMember == "");
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
				if (DesignMode && dataMember != "")
				{
					base.Text = "[" + dataMember + "]";
				}
			}
		}

		string IKissBindableEdit.GetBindablePropertyName()
		{
			return "Text";
		}

		void IKissBindableEdit.AllowEdit(bool value) { }
		#endregion

		#region Override Event Methode
		/// <summary>
		/// Raises the <see cref="E:FontChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnFontChanged(System.EventArgs e)
		{
			if (labelStyle == LabelStyleType.EditFieldLabel && (!InInit))
				this.Font = new System.Drawing.Font(GuiConfig.LabelFontName, GuiConfig.LabelFontSize,
																					GuiConfig.LabelFontStyle, GuiConfig.LabelFontGraphicUnit);
			base.OnFontChanged(e);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.AutoSizeChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnAutoSizeChanged(System.EventArgs e)
		{
			if (labelStyle == LabelStyleType.EditFieldLabel && (!InInit))
				this.AutoSize = false;
			base.OnAutoSizeChanged(e);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnSizeChanged(System.EventArgs e)
		{
			if (labelStyle == LabelStyleType.EditFieldLabel && (!InInit))
				this.Height = 24;
			base.OnSizeChanged(e);
		}

		/// <summary>
		/// Raises the <see cref="E:Paint"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			int LeftPoint = 0;

			if (this.TextAlign == ContentAlignment.MiddleRight || 
                this.TextAlign == ContentAlignment.TopRight || 
                this.TextAlign == ContentAlignment.BottomRight)
				LeftPoint = (int)(this.Width - e.Graphics.MeasureString(this.Text, GetFont()).Width);


			switch (labelStyle)
			{
				case LabelStyleType.EditFieldLabel:
					e.Graphics.DrawString(this.Text, GetFont(), Brushes.Black, new Point(LeftPoint, 6));
					break;

				case LabelStyleType.DataViewLabel:
					e.Graphics.DrawString(this.Text, GetFont(), Brushes.Black, new Point(LeftPoint, 2));
					break;

				default:
					base.OnPaint(e);
					break;
			}
		}
		#endregion

		#region ShouldSerialize - Font
		bool ShouldSerializeFont()
		{
			return (labelStyle == LabelStyleType.Custom);
		}

		/// <summary>
		/// Gets or sets the font of the text displayed by the control.
		/// </summary>
		/// <value></value>
		/// <returns>The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"></see> property.</returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
		public override System.Drawing.Font Font
		{
			get { return base.Font; }
			set { base.Font = value; }
		}
		#endregion

		private Font GetFont()
		{
			switch (labelStyle)
			{
				case LabelStyleType.EditFieldLabel:
					return new System.Drawing.Font(GuiConfig.LabelFontName, GuiConfig.LabelFontSize, GuiConfig.LabelFontStyle, GuiConfig.LabelFontGraphicUnit);
				case LabelStyleType.TitleLabel:
					return new System.Drawing.Font(GuiConfig.LabelFontName, GuiConfig.TLabelFontSize, GuiConfig.TLabelFontStyle, GuiConfig.LabelFontGraphicUnit);
				case LabelStyleType.DataView:
					return new System.Drawing.Font(GuiConfig.LabelFontName, GuiConfig.BLabelFontSize, GuiConfig.BLabelFontStyle, GuiConfig.LabelFontGraphicUnit);
				case LabelStyleType.DataViewLabel:
					return new System.Drawing.Font(GuiConfig.LabelFontName, GuiConfig.LabelFontSize, GuiConfig.LabelFontStyle, GuiConfig.LabelFontGraphicUnit);
			}
			return this.Font;
		}

		/// <summary>
		/// Gets or sets the label style.
		/// </summary>
		/// <value>The label style.</value>
		[Browsable(true)]
		[DefaultValue(LabelStyleType.EditFieldLabel)]
		public LabelStyleType LabelStyle
		{
			get { return labelStyle; }
			set
			{
				labelStyle = value;
				switch (labelStyle)
				{
					case LabelStyleType.EditFieldLabel:
						this.AutoSize = false;
						this.Height = 24;
						this.Font = GetFont();
						break;
					case LabelStyleType.TitleLabel:
						this.AutoSize = false;
						this.Height = 16;
						this.Font = GetFont();
						break;
					case LabelStyleType.DataView:
						this.AutoSize = false;
						this.Height = 16;
						this.Font = GetFont();
						break;
					case LabelStyleType.DataViewLabel:
						this.AutoSize = false;
						this.Height = 16;
						this.Font = GetFont();
						break;
					case LabelStyleType.Custom:
						break;
				}
				this.Invalidate();
			}
		}
	}
}
