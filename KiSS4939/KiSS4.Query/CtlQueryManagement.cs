using KiSS4.Common;

namespace KiSS4.Query
{
	/// <summary>
	/// Summary description for CtlQueryManagement.
	/// </summary>
	public class CtlQueryManagement : KissNavBarUserControl
	{
		private System.ComponentModel.IContainer components = null;

		public CtlQueryManagement()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
			this.SuspendLayout();
			// 
			// navBar
			// 
			this.navBar.Appearance.Background.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.navBar.Appearance.Background.Options.UseBackColor = true;
			this.navBar.Appearance.GroupBackground.BackColor = System.Drawing.Color.Lavender;
			this.navBar.Appearance.GroupBackground.Options.UseBackColor = true;
			this.navBar.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.navBar.Appearance.GroupHeaderActive.Options.UseFont = true;
			this.navBar.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
			this.navBar.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.navBar.Appearance.GroupHeaderHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.navBar.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
			this.navBar.Appearance.GroupHeaderHotTracked.Options.UseTextOptions = true;
			this.navBar.Appearance.GroupHeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.navBar.Appearance.GroupHeaderPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.navBar.Appearance.GroupHeaderPressed.Options.UseFont = true;
			this.navBar.Appearance.ItemDisabled.Options.UseTextOptions = true;
			this.navBar.Appearance.ItemDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBar.Appearance.ItemDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.navBar.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
			this.navBar.Appearance.ItemHotTracked.Options.UseFont = true;
			this.navBar.Appearance.ItemHotTracked.Options.UseTextOptions = true;
			this.navBar.Appearance.ItemHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBar.Appearance.ItemHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.navBar.Appearance.ItemPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
			this.navBar.Appearance.ItemPressed.Options.UseFont = true;
			this.navBar.Appearance.ItemPressed.Options.UseTextOptions = true;
			this.navBar.Appearance.ItemPressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBar.Appearance.ItemPressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.navBar.Name = "navBar";
			this.navBar.Size = new System.Drawing.Size(170, 641);
			// 
			// picTitle
			// 
			this.picTitle.Name = "picTitle";
			// 
			// lblTitle
			// 
			this.lblTitle.Name = "lblTitle";
			// 
			// panDetail
			// 
			this.panDetail.Name = "panDetail";
			this.panDetail.Size = new System.Drawing.Size(817, 612);
			// 
			// CtlQueryManagement
			// 
			this.ClientSize = new System.Drawing.Size(990, 641);
			this.Name = "CtlQueryManagement";
			((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
	}
}
