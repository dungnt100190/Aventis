using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissButton.
	/// </summary>
	public class KissButton : Button
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private ButtonStyleType buttonStyle = ButtonStyleType.Standard;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissButton"/> class.
		/// </summary>
		public KissButton()
		{
			this.Size = new Size(90, 24);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region Override Event Methode
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnFontChanged(System.EventArgs e)
		{
			SetAppearance();
			base.OnFontChanged(e);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnSizeChanged(System.EventArgs e)
		{
			SetAppearance();
			base.OnSizeChanged(e);
		}

		/// <summary>
		/// Gets or sets a value indicating whether the control can respond to user interaction.
		/// </summary>
		/// <value></value>
		/// <returns>true if the control can respond to user interaction; otherwise, false. The default is true.</returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
		public new bool Enabled
		{
			get { return base.Enabled; }
			set
			{
				base.Enabled = value;
				SetAppearance();
			}
		}
		#endregion

		/// <summary>
		/// Sets the appearance.
		/// </summary>
		private void SetAppearance()
		{
			if (buttonStyle == ButtonStyleType.Standard)
			{
			    this.Height = 24;
			    this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			    try
			    {
			        this.Font = new System.Drawing.Font(GuiConfig.ButtonFontName, GuiConfig.ButtonFontSize,
			                                            GuiConfig.ButtonFontStyle, GuiConfig.ButtonFontGraphicUnit);
			    }
			    catch
			    {
			    }
			}
		    if (this.Enabled)
			{
				this.BackColor = GuiConfig.ButtonBackColorEnabled;
				this.ForeColor = GuiConfig.ButtonForeColorEnabled;
			}
			else
			{
				this.BackColor = GuiConfig.ButtonBackColorDisabled;
				this.ForeColor = GuiConfig.ButtonForeColorDisabled;
			}
			this.Invalidate();
		}

		#region ShouldSerialize - Font
		/// <summary>
		/// Indicates whether the font should be serialized.
		/// </summary>
		/// <returns></returns>
		bool ShouldSerializeFont()
		{
			return (buttonStyle == ButtonStyleType.Custom);
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

		#region ShouldSerialize - ForeColor
		bool ShouldSerializeForeColor()
		{
			return (buttonStyle == ButtonStyleType.Custom);
		}

		/// <summary>
		/// Gets or sets the foreground color of the control.
		/// </summary>
		/// <value></value>
		/// <returns>The foreground <see cref="T:System.Drawing.Color"></see> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColor"></see> property.</returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
		public override Color ForeColor
		{
			get { return base.ForeColor; }
			set { base.ForeColor = value; }
		}
		#endregion

		#region ShouldSerialize - BackColor
		/// <summary>
		/// Indicates whether the backcolor should be serialized.
		/// </summary>
		/// <returns></returns>
		bool ShouldSerializeBackColor()
		{
			return (buttonStyle == ButtonStyleType.Custom);
		}

		/// <summary>
		/// Gets or sets the background color of the control.
		/// </summary>
		/// <value></value>
		/// <returns>A <see cref="T:System.Drawing.Color"></see> value representing the background color.</returns>
		public override Color BackColor
		{
			get { return base.BackColor; }
			set { base.BackColor = value; }
		}
		#endregion

		#region IconID
		/// <summary>
		/// Gets or sets the image that is displayed on a button control.
		/// </summary>
		[Category("Appearance"), DefaultValue(null)]
		public new Image Image
		{
			get { return IconID > 0 ? null : base.Image; }
			set { base.Image = value; }
		}

		private int iconID = -1;

		/// <summary>
		/// Liest oder setzt die ID des Icon.
		/// </summary>
		[Category("Appearance"), DefaultValue(-1)]
		[TypeConverter(typeof(Designer.KissImageListConverter)), Editor(typeof(Designer.KissImageListEditor), typeof(UITypeEditor))]
		public int IconID
		{
			get { return iconID; }
			set
			{
				iconID = value;
				if (iconID == -1)
					base.Image = null;
				else
					base.Image = KissImageList.GetSmallImage(iconID);
			}
		}
		#endregion

		/// <summary>
		/// Gets or sets the button style.
		/// </summary>
		/// <value>The button style.</value>
		[Browsable(true)]
		[DefaultValue(ButtonStyleType.Standard)]
		public ButtonStyleType ButtonStyle
		{
			get { return buttonStyle; }
			set
			{
				buttonStyle = value;
				SetAppearance();
			}
		}
	}
}
