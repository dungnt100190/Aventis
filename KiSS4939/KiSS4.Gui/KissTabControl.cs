using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;

using SharpLibrary;
using SharpLibrary.WinControls;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissTextEdit.
	/// </summary>
	[Obsolete]
    public class KissTabControl : TabControlEx
	{
		private TabControlStyleType tabControlStyle = TabControlStyleType.Standard;

		/// <summary> 
		/// Required designer variable.
		/// </summary>

		public KissTabControl()
		{
		}

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Override Event Methode

		/// <summary>
		/// Raises the <see cref="E:FontChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnFontChanged(System.EventArgs e)
		{
			SetAppearance();
			base.OnFontChanged(e);
		}

		#endregion 

		/// <summary>
		/// Sets the appearance.
		/// </summary>
		private void SetAppearance()
		{
			if (tabControlStyle == TabControlStyleType.Standard)
			{
                this.BorderStyleEx = SharpLibrary.WinControls.BorderStyleEx.FixedSingle;
				//this.TabPosition = SpringSys.WinFormCtrls.TabPosition.Bottom; too restrictive!

				foreach (SharpLibrary.WinControls.TabPageEx tabPage in this.TabPages)
				{
					tabPage.Font = new System.Drawing.Font(GuiConfig.TabFontName, GuiConfig.TabFontSize, GuiConfig.TabFontStyle, GuiConfig.TabFontGraphicUnit);
				}
				this.Invalidate();
			}
		}

		#region ShouldSerialize - Font
		/// <summary>
		/// Indicates whethher the font should be serialized.
		/// </summary>
		/// <returns></returns>
		bool ShouldSerializeFont()
		{
			return (tabControlStyle == TabControlStyleType.Custom);
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

		/// <summary>
		/// Gets or sets the tab control style.
		/// </summary>
		/// <value>The tab control style.</value>
		[Browsable(true)]
		[DefaultValue(TabControlStyleType.Standard)]
		public TabControlStyleType TabControlStyle 
		{
			get {return tabControlStyle;}
			set 
			{
				tabControlStyle = value;
				SetAppearance();
			}
		}

	}
}
