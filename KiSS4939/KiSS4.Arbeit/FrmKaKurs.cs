
namespace KiSS4.Arbeit
{
	/// <summary>
	/// Summary description for FrmKaKurs.
	/// </summary>
	public class FrmKaKurs : KiSS4.Gui.KissChildForm
	{
		private KiSS4.DB.SqlQuery qryKurs;
		private DevExpress.XtraGrid.Columns.GridColumn colNr;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colAnzLektionen;
		private DevExpress.XtraGrid.Columns.GridColumn colPlaetze;
		private DevExpress.XtraGrid.Columns.GridColumn colSektion;
		private DevExpress.XtraGrid.Columns.GridColumn colClosed;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private KiSS4.Gui.KissGrid grdKurs;
		private DevExpress.XtraGrid.Views.Grid.GridView gvKurs;
		private System.ComponentModel.IContainer components;

		public FrmKaKurs()
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
            this.components = new System.ComponentModel.Container();
            this.qryKurs = new KiSS4.DB.SqlQuery(this.components);
            this.grdKurs = new KiSS4.Gui.KissGrid();
            this.gvKurs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaetze = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzLektionen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryKurs
            // 
            this.qryKurs.CanDelete = true;
            this.qryKurs.CanInsert = true;
            this.qryKurs.CanUpdate = true;
            this.qryKurs.HostControl = this;
            this.qryKurs.TableName = "KaKurs";
            // 
            // grdKurs
            // 
            this.grdKurs.DataSource = this.qryKurs;
            this.grdKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKurs.EmbeddedNavigator.Name = "";
            this.grdKurs.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdKurs.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdKurs.Location = new System.Drawing.Point(0, 0);
            this.grdKurs.MainView = this.gvKurs;
            this.grdKurs.Name = "grdKurs";
            this.grdKurs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdKurs.Size = new System.Drawing.Size(847, 506);
            this.grdKurs.TabIndex = 2;
            this.grdKurs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvKurs});
            // 
            // gvKurs
            // 
            this.gvKurs.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvKurs.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.Empty.Options.UseBackColor = true;
            this.gvKurs.Appearance.Empty.Options.UseFont = true;
            this.gvKurs.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvKurs.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvKurs.Appearance.EvenRow.Options.UseFont = true;
            this.gvKurs.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gvKurs.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvKurs.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvKurs.Appearance.FocusedCell.Options.UseFont = true;
            this.gvKurs.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvKurs.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvKurs.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvKurs.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvKurs.Appearance.FocusedRow.Options.UseFont = true;
            this.gvKurs.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvKurs.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvKurs.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvKurs.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvKurs.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvKurs.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvKurs.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvKurs.Appearance.GroupRow.Options.UseFont = true;
            this.gvKurs.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvKurs.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvKurs.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvKurs.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvKurs.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvKurs.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvKurs.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvKurs.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvKurs.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvKurs.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvKurs.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvKurs.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvKurs.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvKurs.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvKurs.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gvKurs.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.OddRow.Options.UseBackColor = true;
            this.gvKurs.Appearance.OddRow.Options.UseFont = true;
            this.gvKurs.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gvKurs.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.Row.Options.UseBackColor = true;
            this.gvKurs.Appearance.Row.Options.UseFont = true;
            this.gvKurs.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvKurs.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurs.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvKurs.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvKurs.Appearance.SelectedRow.Options.UseFont = true;
            this.gvKurs.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvKurs.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gvKurs.Appearance.VertLine.Options.UseBackColor = true;
            this.gvKurs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvKurs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNr,
            this.colName,
            this.colSektion,
            this.colPlaetze,
            this.colAnzLektionen,
            this.colClosed});
            this.gvKurs.GridControl = this.grdKurs;
            this.gvKurs.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvKurs.Name = "gvKurs";
            this.gvKurs.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvKurs.OptionsCustomization.AllowFilter = false;
            this.gvKurs.OptionsCustomization.AllowGroup = false;
            this.gvKurs.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvKurs.OptionsNavigation.AutoFocusNewRow = true;
            this.gvKurs.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvKurs.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvKurs.OptionsPrint.AutoWidth = false;
            this.gvKurs.OptionsPrint.UsePrintStyles = true;
            this.gvKurs.OptionsView.ColumnAutoWidth = false;
            this.gvKurs.OptionsView.ShowDetailButtons = false;
            this.gvKurs.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvKurs.OptionsView.ShowGroupPanel = false;
            // 
            // colNr
            // 
            this.colNr.AppearanceCell.Options.UseTextOptions = true;
            this.colNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNr.Caption = "Nr.";
            this.colNr.FieldName = "Nr";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 0;
            this.colNr.Width = 100;
            // 
            // colName
            // 
            this.colName.Caption = "Kursname";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 246;
            // 
            // colSektion
            // 
            this.colSektion.Caption = "Sektion";
            this.colSektion.FieldName = "SektionCode";
            this.colSektion.Name = "colSektion";
            this.colSektion.Visible = true;
            this.colSektion.VisibleIndex = 2;
            this.colSektion.Width = 200;
            // 
            // colPlaetze
            // 
            this.colPlaetze.AppearanceCell.Options.UseTextOptions = true;
            this.colPlaetze.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlaetze.Caption = "Plätze";
            this.colPlaetze.FieldName = "Plaetze";
            this.colPlaetze.Name = "colPlaetze";
            this.colPlaetze.Visible = true;
            this.colPlaetze.VisibleIndex = 3;
            // 
            // colAnzLektionen
            // 
            this.colAnzLektionen.AppearanceCell.Options.UseTextOptions = true;
            this.colAnzLektionen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAnzLektionen.Caption = "Lektionen";
            this.colAnzLektionen.FieldName = "AnzLektionen";
            this.colAnzLektionen.Name = "colAnzLektionen";
            this.colAnzLektionen.Visible = true;
            this.colAnzLektionen.VisibleIndex = 4;
            this.colAnzLektionen.Width = 100;
            // 
            // colClosed
            // 
            this.colClosed.Caption = "geschlossen";
            this.colClosed.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colClosed.FieldName = "ClosedFlag";
            this.colClosed.Name = "colClosed";
            this.colClosed.Visible = true;
            this.colClosed.VisibleIndex = 5;
            this.colClosed.Width = 85;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // FrmKaKurs
            // 
            this.ActiveSQLQuery = this.qryKurs;
            this.ClientSize = new System.Drawing.Size(847, 506);
            this.Controls.Add(this.grdKurs);
            this.Name = "FrmKaKurs";
            this.Text = "Kurs";
            this.Load += new System.EventHandler(this.FrmKaKurs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void FrmKaKurs_Load(object sender, System.EventArgs e)
		{
			colSektion.ColumnEdit = grdKurs.GetLOVLookUpEdit("KaKursSekt");

			qryKurs.Fill("select * from KaKurs order by KaKursID");
		}
	}
}
