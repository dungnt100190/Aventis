using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for KissHelpDialog.
	/// </summary>
	public class KissHelpDialog : KissDialog
	{
		private KiSS4.Gui.KissLabel lblFrage;
		private KiSS4.Gui.KissMemoEdit txtHilfe;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissHelpDialog"/> class.
		/// </summary>
		/// <param name="BfsFrage">The BFS frage.</param>
		public KissHelpDialog(string BfsFrage)
		{
			InitializeComponent();

			SqlQuery qryFrage = DBUtil.OpenSQL("SELECT HilfeText, HilfeTitel FROM BFSFrage WHERE Variable = {0}", BfsFrage);
			if (qryFrage.Count == 0) return;
			this.lblFrage.Text = qryFrage["HilfeTitel"].ToString() + ":";
			this.txtHilfe.Text = qryFrage["HilfeText"].ToString();
			this.txtHilfe.GotFocus += new EventHandler(txtHilfe_GotFocus);
			this.txtHilfe.EditMode = EditModeType.ReadOnly;

			this.ShowDialog();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KissHelpDialog));
			this.lblFrage = new KiSS4.Gui.KissLabel();
			this.txtHilfe = new KiSS4.Gui.KissMemoEdit();
			((System.ComponentModel.ISupportInitialize)(this.lblFrage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHilfe.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lblFrage
			// 
			this.lblFrage.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblFrage.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblFrage.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
			this.lblFrage.Location = new System.Drawing.Point(0, 0);
			this.lblFrage.Name = "lblFrage";
			this.lblFrage.Size = new System.Drawing.Size(318, 24);
			this.lblFrage.TabIndex = 0;
			this.lblFrage.Text = "";
			// 
			// txtHilfe
			// 
			this.txtHilfe.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtHilfe.EditValue = null;
			this.txtHilfe.Location = new System.Drawing.Point(0, 24);
			this.txtHilfe.Name = "txtHilfe";
			// 
			// txtHilfe.Properties
			// 
			this.txtHilfe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.txtHilfe.Properties.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.AliceBlue, System.Drawing.SystemColors.WindowText);
			this.txtHilfe.Properties.StyleBorder = new DevExpress.Utils.ViewStyle("ControlStyleBorder", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis)
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect)
				| DevExpress.Utils.StyleOptions.UseFont)
				| DevExpress.Utils.StyleOptions.UseForeColor)
				| DevExpress.Utils.StyleOptions.UseHorzAlignment)
				| DevExpress.Utils.StyleOptions.UseImage)
				| DevExpress.Utils.StyleOptions.UseWordWrap)
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), false, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.Linen, System.Drawing.SystemColors.Control);
			this.txtHilfe.Size = new System.Drawing.Size(318, 132);
			this.txtHilfe.TabIndex = 1;
			// 
			// KissHelpDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(318, 156);
			this.Controls.Add(this.txtHilfe);
			this.Controls.Add(this.lblFrage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "KissHelpDialog";
			this.Text = "Hilfe";
			((System.ComponentModel.ISupportInitialize)(this.lblFrage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHilfe.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void txtHilfe_GotFocus(object sender, EventArgs e)
		{
			this.txtHilfe.Select(0, 0);
		}
	}
}
