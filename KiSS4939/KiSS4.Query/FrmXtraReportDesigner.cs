using System.ComponentModel;

namespace KiSS4.Query
{
	public class FrmXtraReportDesigner : DevExpress.XtraReports.UserDesigner.XRDesignFormEx
	{
		private System.ComponentModel.IContainer components = null;

		public FrmXtraReportDesigner()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		/// <summary>
		/// Gets the ReportState of the report being designed
		/// </summary>
		[Browsable(false)]
		public DevExpress.XtraReports.UserDesigner.ReportState ReportState 
		{
			get { return xrDesignPanel.ReportState; }
		}

		/// <summary>
		/// Gets the Report being designed
		/// </summary>
		[Browsable(false)]
		public DevExpress.XtraReports.UI.XtraReport Report 
		{
			get { return xrDesignPanel.Report; }
		}

		protected override void OnClosing(CancelEventArgs e) 
		{
			//suppress english save dialog
			e.Cancel = false;
		}

	}
}

