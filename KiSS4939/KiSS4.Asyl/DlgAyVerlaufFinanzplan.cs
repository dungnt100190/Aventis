
namespace KiSS4.Asyl
{
	public class DlgAyVerlaufFinanzplan : KiSS4.Gui.KissDialog
	{
		private KiSS4.Gui.KissButton btnClose;
		private DevExpress.XtraGrid.Views.Grid.GridView grvBgBewilligung;
		private KiSS4.DB.SqlQuery qryBgBewilligung;
		private KiSS4.Gui.KissLabel lblBgBewilligung;
		private KiSS4.Gui.KissLabel lblSchluessel;
		private DevExpress.XtraGrid.Columns.GridColumn colDatum;
		private DevExpress.XtraGrid.Columns.GridColumn colAbsender;
		private DevExpress.XtraGrid.Columns.GridColumn colEmpfaenger;
		private DevExpress.XtraGrid.Columns.GridColumn colPerDatum;
		private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
		private KiSS4.Gui.KissGrid grdBgBewilligung;
		private DevExpress.XtraGrid.Columns.GridColumn colBewilligungCode;
		private KiSS4.Gui.KissMemoEdit edtBemerkung;
		private KiSS4.Gui.KissLabel kissLabel1;
		private System.ComponentModel.IContainer components = null;

		public DlgAyVerlaufFinanzplan()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		public DlgAyVerlaufFinanzplan(int bgFinanzplanID) : this()
		{
			this.colBewilligungCode.ColumnEdit = this.grdBgBewilligung.GetLOVLookUpEdit("BgBewilligung");

			this.qryBgBewilligung.Fill(bgFinanzplanID);

			this.lblSchluessel.Text = string.Format(this.lblSchluessel.Text, bgFinanzplanID);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAyVerlaufFinanzplan));
			this.btnClose = new KiSS4.Gui.KissButton();
			this.grdBgBewilligung = new KiSS4.Gui.KissGrid();
			this.qryBgBewilligung = new KiSS4.DB.SqlQuery(this.components);
			this.grvBgBewilligung = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEmpfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBewilligungCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPerDatum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lblBgBewilligung = new KiSS4.Gui.KissLabel();
			this.lblSchluessel = new KiSS4.Gui.KissLabel();
			this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
			this.kissLabel1 = new KiSS4.Gui.KissLabel();
			((System.ComponentModel.ISupportInitialize)(this.grdBgBewilligung)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvBgBewilligung)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblBgBewilligung)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSchluessel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(672, 296);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(120, 24);
			this.btnClose.TabIndex = 20;
			this.btnClose.Text = "Schliessen";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// grdBgBewilligung
			// 
			this.grdBgBewilligung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdBgBewilligung.DataSource = this.qryBgBewilligung;
			this.grdBgBewilligung.EmbeddedNavigator.Name = "";
			this.grdBgBewilligung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.grdBgBewilligung.Location = new System.Drawing.Point(8, 24);
			this.grdBgBewilligung.MainView = this.grvBgBewilligung;
			this.grdBgBewilligung.Name = "grdBgBewilligung";
			this.grdBgBewilligung.Size = new System.Drawing.Size(784, 160);
			this.grdBgBewilligung.TabIndex = 21;
			this.grdBgBewilligung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgBewilligung});
			// 
			// qryBgBewilligung
			// 
			this.qryBgBewilligung.HostControl = this;
			this.qryBgBewilligung.SelectStatement = resources.GetString("qryBgBewilligung.SelectStatement");
			// 
			// grvBgBewilligung
			// 
			this.grvBgBewilligung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grvBgBewilligung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.Empty.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.Empty.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.EvenRow.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvBgBewilligung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.grvBgBewilligung.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.FocusedCell.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grvBgBewilligung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvBgBewilligung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.grvBgBewilligung.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.FocusedRow.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grvBgBewilligung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grvBgBewilligung.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grvBgBewilligung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvBgBewilligung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvBgBewilligung.Appearance.GroupRow.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.GroupRow.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.GroupRow.Options.UseForeColor = true;
			this.grvBgBewilligung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grvBgBewilligung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grvBgBewilligung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvBgBewilligung.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grvBgBewilligung.Appearance.HeaderPanel.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.grvBgBewilligung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvBgBewilligung.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grvBgBewilligung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.grvBgBewilligung.Appearance.HorzLine.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.OddRow.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.grvBgBewilligung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.Row.Options.UseBackColor = true;
			this.grvBgBewilligung.Appearance.Row.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvBgBewilligung.Appearance.SelectedRow.Options.UseFont = true;
			this.grvBgBewilligung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.grvBgBewilligung.Appearance.VertLine.Options.UseBackColor = true;
			this.grvBgBewilligung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grvBgBewilligung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colAbsender,
            this.colEmpfaenger,
            this.colBewilligungCode,
            this.colPerDatum,
            this.colBemerkung});
			this.grvBgBewilligung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grvBgBewilligung.GridControl = this.grdBgBewilligung;
			this.grvBgBewilligung.Name = "grvBgBewilligung";
			this.grvBgBewilligung.OptionsBehavior.Editable = false;
			this.grvBgBewilligung.OptionsCustomization.AllowFilter = false;
			this.grvBgBewilligung.OptionsFilter.AllowFilterEditor = false;
			this.grvBgBewilligung.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grvBgBewilligung.OptionsNavigation.AutoFocusNewRow = true;
			this.grvBgBewilligung.OptionsNavigation.UseTabKey = false;
			this.grvBgBewilligung.OptionsView.ColumnAutoWidth = false;
			this.grvBgBewilligung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grvBgBewilligung.OptionsView.ShowGroupPanel = false;
			this.grvBgBewilligung.OptionsView.ShowIndicator = false;
			// 
			// colDatum
			// 
			this.colDatum.Caption = "Datum";
			this.colDatum.FieldName = "Datum";
			this.colDatum.Name = "colDatum";
			this.colDatum.Visible = true;
			this.colDatum.VisibleIndex = 0;
			this.colDatum.Width = 110;
			// 
			// colAbsender
			// 
			this.colAbsender.Caption = "Absender";
			this.colAbsender.FieldName = "Absender";
			this.colAbsender.Name = "colAbsender";
			this.colAbsender.Visible = true;
			this.colAbsender.VisibleIndex = 1;
			this.colAbsender.Width = 110;
			// 
			// colEmpfaenger
			// 
			this.colEmpfaenger.Caption = "Empfänger";
			this.colEmpfaenger.FieldName = "Empfaenger";
			this.colEmpfaenger.Name = "colEmpfaenger";
			this.colEmpfaenger.Visible = true;
			this.colEmpfaenger.VisibleIndex = 2;
			this.colEmpfaenger.Width = 133;
			// 
			// colBewilligungCode
			// 
			this.colBewilligungCode.Caption = "Typ";
			this.colBewilligungCode.FieldName = "BgBewilligungCode";
			this.colBewilligungCode.Name = "colBewilligungCode";
			this.colBewilligungCode.Visible = true;
			this.colBewilligungCode.VisibleIndex = 3;
			this.colBewilligungCode.Width = 152;
			// 
			// colPerDatum
			// 
			this.colPerDatum.Caption = "per Datum";
			this.colPerDatum.FieldName = "PerDatum";
			this.colPerDatum.Name = "colPerDatum";
			this.colPerDatum.Visible = true;
			this.colPerDatum.VisibleIndex = 4;
			this.colPerDatum.Width = 84;
			// 
			// colBemerkung
			// 
			this.colBemerkung.Caption = "Bemerkung";
			this.colBemerkung.FieldName = "Bemerkung";
			this.colBemerkung.Name = "colBemerkung";
			this.colBemerkung.Visible = true;
			this.colBemerkung.VisibleIndex = 5;
			this.colBemerkung.Width = 227;
			// 
			// lblBgBewilligung
			// 
			this.lblBgBewilligung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
			this.lblBgBewilligung.Location = new System.Drawing.Point(8, 8);
			this.lblBgBewilligung.Name = "lblBgBewilligung";
			this.lblBgBewilligung.Size = new System.Drawing.Size(448, 16);
			this.lblBgBewilligung.TabIndex = 22;
			this.lblBgBewilligung.Text = "Die Bewilligung des Masterbudgets hat folgenden Verlauf genommen:";
			// 
			// lblSchluessel
			// 
			this.lblSchluessel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSchluessel.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
			this.lblSchluessel.Location = new System.Drawing.Point(8, 296);
			this.lblSchluessel.Name = "lblSchluessel";
			this.lblSchluessel.Size = new System.Drawing.Size(192, 16);
			this.lblSchluessel.TabIndex = 23;
			this.lblSchluessel.Text = "Schlüssel: {0}";
			// 
			// edtBemerkung
			// 
			this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.edtBemerkung.DataMember = "Bemerkung";
			this.edtBemerkung.DataSource = this.qryBgBewilligung;
			this.edtBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
			this.edtBemerkung.Location = new System.Drawing.Point(8, 208);
			this.edtBemerkung.Name = "edtBemerkung";
			this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
			this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
			this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
			this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtBemerkung.Properties.ReadOnly = true;
			this.edtBemerkung.Size = new System.Drawing.Size(784, 80);
			this.edtBemerkung.TabIndex = 24;
			// 
			// kissLabel1
			// 
			this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
			this.kissLabel1.Location = new System.Drawing.Point(8, 192);
			this.kissLabel1.Name = "kissLabel1";
			this.kissLabel1.Size = new System.Drawing.Size(264, 16);
			this.kissLabel1.TabIndex = 25;
			this.kissLabel1.Text = "Bemerkung";
			// 
			// DlgAyVerlaufFinanzplan
			// 
			this.AcceptButton = this.btnClose;
			this.ActiveSQLQuery = this.qryBgBewilligung;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(800, 328);
			this.Controls.Add(this.kissLabel1);
			this.Controls.Add(this.edtBemerkung);
			this.Controls.Add(this.lblSchluessel);
			this.Controls.Add(this.lblBgBewilligung);
			this.Controls.Add(this.grdBgBewilligung);
			this.Controls.Add(this.btnClose);
			this.Name = "DlgAyVerlaufFinanzplan";
			this.Text = "Bewilligung Masterbudget";
			((System.ComponentModel.ISupportInitialize)(this.grdBgBewilligung)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvBgBewilligung)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblBgBewilligung)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSchluessel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}

