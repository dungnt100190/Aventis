using System.ComponentModel;

namespace KiSS4.Gui
{
	/// <summary>
	/// 
	/// </summary>
	public class KissSearchTitel
		:
		KissComplexControl
	{
		private System.Windows.Forms.PictureBox picSearch;
		private KiSS4.Gui.KissLabel lblSearch;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissSearchTitel"/> class.
		/// </summary>
		public KissSearchTitel()
		{
			// This call is required by the Windows Form Designer.
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

		/// <summary>
		/// List oder setzt den Search text.
		/// </summary>
		/// <value></value>
		[Browsable(true)]
		[DefaultValue("Suchen")]
		public override string Text
		{
			get { return this.lblSearch.Text; }
			set { this.lblSearch.Text = value; }
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissSearchTitel));
			this.picSearch = new System.Windows.Forms.PictureBox();
			this.lblSearch = new KiSS4.Gui.KissLabel();
			((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearch)).BeginInit();
			this.SuspendLayout();
			// 
			// picSearch
			// 
			this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
			this.picSearch.Location = new System.Drawing.Point(4, 4);
			this.picSearch.Name = "picSearch";
			this.picSearch.Size = new System.Drawing.Size(16, 16);
			this.picSearch.TabIndex = 0;
			this.picSearch.TabStop = false;
			// 
			// lblSearch
			// 
			this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblSearch.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
			this.lblSearch.Location = new System.Drawing.Point(26, 4);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(168, 16);
			this.lblSearch.TabIndex = 1;
			this.lblSearch.Text = "Suchen";
			// 
			// KissSearchTitel
			// 
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.picSearch);
			this.Name = "KissSearchTitel";
			this.Size = new System.Drawing.Size(200, 24);
			((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearch)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
