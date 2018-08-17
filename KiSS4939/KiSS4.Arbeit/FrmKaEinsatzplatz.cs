
namespace KiSS4.Arbeit
{
	public class FrmKaEinsatzplatz : KiSS4.Gui.KissChildForm
	{
		private System.ComponentModel.IContainer components = null;
		private DevExpress.XtraGrid.Columns.GridColumn colNr;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colProjekt;
		private DevExpress.XtraGrid.Columns.GridColumn colProfil;
		private DevExpress.XtraGrid.Columns.GridColumn colAPV;
		private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
		private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
		private KiSS4.Gui.KissGrid grdEinsatzplatz;
		private DevExpress.XtraGrid.Views.Grid.GridView gvEinsatzplatz;
		private KiSS4.DB.SqlQuery qryEinsatzplatz;

		public FrmKaEinsatzplatz()
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
            this.components = new System.ComponentModel.Container();
            this.qryEinsatzplatz = new KiSS4.DB.SqlQuery(this.components);
            this.grdEinsatzplatz = new KiSS4.Gui.KissGrid();
            this.gvEinsatzplatz = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjekt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAPV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEinsatzplatz)).BeginInit();
            this.SuspendLayout();
            // 
            // qryEinsatzplatz
            // 
            this.qryEinsatzplatz.CanDelete = true;
            this.qryEinsatzplatz.CanInsert = true;
            this.qryEinsatzplatz.CanUpdate = true;
            this.qryEinsatzplatz.HostControl = this;
            this.qryEinsatzplatz.TableName = "KaEinsatzplatz2";
            // 
            // grdEinsatzplatz
            // 
            this.grdEinsatzplatz.DataSource = this.qryEinsatzplatz;
            this.grdEinsatzplatz.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdEinsatzplatz.EmbeddedNavigator.Name = "";
            this.grdEinsatzplatz.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdEinsatzplatz.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdEinsatzplatz.Location = new System.Drawing.Point(0, 0);
            this.grdEinsatzplatz.MainView = this.gvEinsatzplatz;
            this.grdEinsatzplatz.Name = "grdEinsatzplatz";
            this.grdEinsatzplatz.Size = new System.Drawing.Size(864, 506);
            this.grdEinsatzplatz.TabIndex = 1;
            this.grdEinsatzplatz.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEinsatzplatz});
            // 
            // gvEinsatzplatz
            // 
            this.gvEinsatzplatz.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvEinsatzplatz.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.Empty.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.Empty.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvEinsatzplatz.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.EvenRow.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gvEinsatzplatz.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvEinsatzplatz.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.FocusedCell.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvEinsatzplatz.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvEinsatzplatz.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvEinsatzplatz.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.FocusedRow.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvEinsatzplatz.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvEinsatzplatz.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvEinsatzplatz.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvEinsatzplatz.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvEinsatzplatz.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.GroupRow.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvEinsatzplatz.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvEinsatzplatz.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvEinsatzplatz.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvEinsatzplatz.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvEinsatzplatz.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvEinsatzplatz.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvEinsatzplatz.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvEinsatzplatz.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvEinsatzplatz.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gvEinsatzplatz.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.OddRow.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.OddRow.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gvEinsatzplatz.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.Row.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.Row.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvEinsatzplatz.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvEinsatzplatz.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvEinsatzplatz.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvEinsatzplatz.Appearance.SelectedRow.Options.UseFont = true;
            this.gvEinsatzplatz.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvEinsatzplatz.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gvEinsatzplatz.Appearance.VertLine.Options.UseBackColor = true;
            this.gvEinsatzplatz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvEinsatzplatz.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNr,
            this.colName,
            this.colProjekt,
            this.colProfil,
            this.colAPV,
            this.colDatumVon,
            this.colDatumBis});
            this.gvEinsatzplatz.GridControl = this.grdEinsatzplatz;
            this.gvEinsatzplatz.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvEinsatzplatz.Name = "gvEinsatzplatz";
            this.gvEinsatzplatz.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvEinsatzplatz.OptionsCustomization.AllowFilter = false;
            this.gvEinsatzplatz.OptionsCustomization.AllowGroup = false;
            this.gvEinsatzplatz.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvEinsatzplatz.OptionsNavigation.AutoFocusNewRow = true;
            this.gvEinsatzplatz.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvEinsatzplatz.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvEinsatzplatz.OptionsPrint.AutoWidth = false;
            this.gvEinsatzplatz.OptionsPrint.UsePrintStyles = true;
            this.gvEinsatzplatz.OptionsView.ColumnAutoWidth = false;
            this.gvEinsatzplatz.OptionsView.ShowDetailButtons = false;
            this.gvEinsatzplatz.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvEinsatzplatz.OptionsView.ShowGroupPanel = false;
            // 
            // colNr
            // 
            this.colNr.AppearanceCell.Options.UseTextOptions = true;
            this.colNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNr.Caption = "Nr";
            this.colNr.FieldName = "KaEinsatzplatzID";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 0;
            this.colNr.Width = 46;
            // 
            // colName
            // 
            this.colName.Caption = "Einsatzplatz-Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 246;
            // 
            // colProjekt
            // 
            this.colProjekt.Caption = "Projekt";
            this.colProjekt.FieldName = "ProjektCode";
            this.colProjekt.Name = "colProjekt";
            this.colProjekt.Visible = true;
            this.colProjekt.VisibleIndex = 2;
            this.colProjekt.Width = 203;
            // 
            // colProfil
            // 
            this.colProfil.Caption = "Profil";
            this.colProfil.FieldName = "ProfilCode";
            this.colProfil.Name = "colProfil";
            this.colProfil.Visible = true;
            this.colProfil.VisibleIndex = 3;
            // 
            // colAPV
            // 
            this.colAPV.Caption = "APV-Nr";
            this.colAPV.FieldName = "APVCode";
            this.colAPV.Name = "colAPV";
            this.colAPV.Visible = true;
            this.colAPV.VisibleIndex = 4;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 5;
            this.colDatumVon.Width = 85;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 6;
            this.colDatumBis.Width = 85;
            // 
            // FrmKaEinsatzplatz
            // 
            this.ActiveSQLQuery = this.qryEinsatzplatz;
            this.ClientSize = new System.Drawing.Size(864, 506);
            this.Controls.Add(this.grdEinsatzplatz);
            this.Name = "FrmKaEinsatzplatz";
            this.Text = "KA Einsatzplatz";
            this.Load += new System.EventHandler(this.FrmKaPraesenzzeit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEinsatzplatz)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void FrmKaPraesenzzeit_Load(object sender, System.EventArgs e)
		{
			colProjekt.ColumnEdit = grdEinsatzplatz.GetLOVLookUpEdit("KaProjekt");
			colProfil.ColumnEdit  = grdEinsatzplatz.GetLOVLookUpEdit("KaProfil");
			colAPV.ColumnEdit     = grdEinsatzplatz.GetLOVLookUpEdit("KaAPV");
			
			qryEinsatzplatz.Fill("select * from KaEinsatzplatz2 order by KaEinsatzplatzID");
		}
	}
}

