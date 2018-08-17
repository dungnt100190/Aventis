namespace KiSS4.Query
{
    partial class CtlQueryKaKurseBIBIPSI
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaKurseBIBIPSI));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgGAExtBildung = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallExtBildung = new KiSS4.Common.CtlGotoFall();
            this.grdExtBildung = new KiSS4.Gui.KissGrid();
            this.qryExtBildung = new KiSS4.DB.SqlQuery(this.components);
            this.grvExtBildung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtZustaendigKA = new KiSS4.Gui.KissButtonEdit();
            this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
            this.colAbschlussGrundCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEroeffnungsGrundCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaFallID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungIDMigrationtmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaProzessCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlKostenstelleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGemeindeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkAbklaerungMigrationtmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkAufenthaltsartCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkDatumForderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkDatumRechtskraft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkEinnahmenQuoteCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkErreichungsGradCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkForderungTitelCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkHatUnterstuetzung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkInkassoBemuehungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkIstRentenbezueger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkLeistungStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkRueckerstattungTypCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkSchuldnerMahnen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkSchuldnerStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkVerjaehrungAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKaEpqJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKaProzessCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungsartCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmigAiInkassoFallID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMigrationKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVmAuftragCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVmProzessCodeOBSOLETE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblStatusHeute = new KiSS4.Gui.KissLabel();
            this.edtStatusHeute = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinsatz = new KiSS4.Gui.KissLabel();
            this.edtEinsatz = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgGAExtBildung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExtBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryExtBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExtBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgGAExtBildung);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgGAExtBildung});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgGAExtBildung, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Kurse";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtEinsatz);
            this.tpgSuchen.Controls.Add(this.edtStatusHeute);
            this.tpgSuchen.Controls.Add(this.lblBis);
            this.tpgSuchen.Controls.Add(this.lblDatumVon);
            this.tpgSuchen.Controls.Add(this.lblEinsatz);
            this.tpgSuchen.Controls.Add(this.lblStatusHeute);
            this.tpgSuchen.Controls.Add(this.lblZustaendigKA);
            this.tpgSuchen.Controls.Add(this.edtZustaendigKA);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustaendigKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustaendigKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            // 
            // tpgGAExtBildung
            // 
            this.tpgGAExtBildung.Controls.Add(this.ctlGotoFallExtBildung);
            this.tpgGAExtBildung.Controls.Add(this.grdExtBildung);
            this.tpgGAExtBildung.Location = new System.Drawing.Point(6, 6);
            this.tpgGAExtBildung.Name = "tpgGAExtBildung";
            this.tpgGAExtBildung.Size = new System.Drawing.Size(772, 424);
            this.tpgGAExtBildung.TabIndex = 1;
            this.tpgGAExtBildung.Title = "Gesamtaufwand externe Bildung";
            // 
            // ctlGotoFallExtBildung
            // 
            this.ctlGotoFallExtBildung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallExtBildung.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFallExtBildung.Name = "ctlGotoFallExtBildung";
            this.ctlGotoFallExtBildung.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallExtBildung.TabIndex = 5;
            this.ctlGotoFallExtBildung.Visible = false;
            // 
            // grdExtBildung
            // 
            this.grdExtBildung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdExtBildung.DataSource = this.qryExtBildung;
            // 
            // 
            // 
            this.grdExtBildung.EmbeddedNavigator.Name = "";
            this.grdExtBildung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdExtBildung.Location = new System.Drawing.Point(3, 1);
            this.grdExtBildung.MainView = this.grvExtBildung;
            this.grdExtBildung.Name = "grdExtBildung";
            this.grdExtBildung.Size = new System.Drawing.Size(766, 392);
            this.grdExtBildung.TabIndex = 4;
            this.grdExtBildung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvExtBildung});
            // 
            // qryExtBildung
            // 
            this.qryExtBildung.SelectStatement = resources.GetString("qryExtBildung.SelectStatement");
            // 
            // grvExtBildung
            // 
            this.grvExtBildung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvExtBildung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.Empty.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.Empty.Options.UseFont = true;
            this.grvExtBildung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.EvenRow.Options.UseFont = true;
            this.grvExtBildung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvExtBildung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvExtBildung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvExtBildung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvExtBildung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvExtBildung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvExtBildung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvExtBildung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvExtBildung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvExtBildung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvExtBildung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvExtBildung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvExtBildung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.GroupRow.Options.UseFont = true;
            this.grvExtBildung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvExtBildung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvExtBildung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvExtBildung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvExtBildung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvExtBildung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvExtBildung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvExtBildung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvExtBildung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvExtBildung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvExtBildung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvExtBildung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.OddRow.Options.UseFont = true;
            this.grvExtBildung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvExtBildung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.Row.Options.UseBackColor = true;
            this.grvExtBildung.Appearance.Row.Options.UseFont = true;
            this.grvExtBildung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExtBildung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvExtBildung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvExtBildung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvExtBildung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvExtBildung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvExtBildung.GridControl = this.grdExtBildung;
            this.grvExtBildung.Name = "grvExtBildung";
            this.grvExtBildung.OptionsBehavior.Editable = false;
            this.grvExtBildung.OptionsCustomization.AllowFilter = false;
            this.grvExtBildung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvExtBildung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvExtBildung.OptionsNavigation.UseTabKey = false;
            this.grvExtBildung.OptionsView.ColumnAutoWidth = false;
            this.grvExtBildung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvExtBildung.OptionsView.ShowGroupPanel = false;
            this.grvExtBildung.OptionsView.ShowIndicator = false;
            // 
            // edtZustaendigKA
            // 
            this.edtZustaendigKA.Location = new System.Drawing.Point(116, 51);
            this.edtZustaendigKA.Name = "edtZustaendigKA";
            this.edtZustaendigKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtZustaendigKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigKA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZustaendigKA.Size = new System.Drawing.Size(250, 24);
            this.edtZustaendigKA.TabIndex = 2;
            this.edtZustaendigKA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustaendigKA_UserModifiedFld);
            // 
            // lblZustaendigKA
            // 
            this.lblZustaendigKA.Location = new System.Drawing.Point(14, 51);
            this.lblZustaendigKA.Name = "lblZustaendigKA";
            this.lblZustaendigKA.Size = new System.Drawing.Size(96, 24);
            this.lblZustaendigKA.TabIndex = 1;
            this.lblZustaendigKA.Text = "Zuständig KA";
            // 
            // colAbschlussGrundCode
            // 
            this.colAbschlussGrundCode.Name = "colAbschlussGrundCode";
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Name = "colBaPersonID";
            // 
            // colBemerkung
            // 
            this.colBemerkung.Name = "colBemerkung";
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Name = "colBezeichnung";
            // 
            // colDatumBis
            // 
            this.colDatumBis.Name = "colDatumBis";
            // 
            // colDatumVon
            // 
            this.colDatumVon.Name = "colDatumVon";
            // 
            // colEroeffnungsGrundCode
            // 
            this.colEroeffnungsGrundCode.Name = "colEroeffnungsGrundCode";
            // 
            // colFaFallID
            // 
            this.colFaFallID.Name = "colFaFallID";
            // 
            // colFaLeistungID
            // 
            this.colFaLeistungID.Name = "colFaLeistungID";
            // 
            // colFaLeistungIDMigrationtmp
            // 
            this.colFaLeistungIDMigrationtmp.Name = "colFaLeistungIDMigrationtmp";
            // 
            // colFaLeistungTS
            // 
            this.colFaLeistungTS.Name = "colFaLeistungTS";
            // 
            // colFaProzessCode
            // 
            this.colFaProzessCode.Name = "colFaProzessCode";
            // 
            // colFlKostenstelleID
            // 
            this.colFlKostenstelleID.Name = "colFlKostenstelleID";
            // 
            // colGemeindeCode
            // 
            this.colGemeindeCode.Name = "colGemeindeCode";
            // 
            // colIkAbklaerungMigrationtmp
            // 
            this.colIkAbklaerungMigrationtmp.Name = "colIkAbklaerungMigrationtmp";
            // 
            // colIkAufenthaltsartCode
            // 
            this.colIkAufenthaltsartCode.Name = "colIkAufenthaltsartCode";
            // 
            // colIkDatumForderungstitel
            // 
            this.colIkDatumForderungstitel.Name = "colIkDatumForderungstitel";
            // 
            // colIkDatumRechtskraft
            // 
            this.colIkDatumRechtskraft.Name = "colIkDatumRechtskraft";
            // 
            // colIkEinnahmenQuoteCode
            // 
            this.colIkEinnahmenQuoteCode.Name = "colIkEinnahmenQuoteCode";
            // 
            // colIkErreichungsGradCode
            // 
            this.colIkErreichungsGradCode.Name = "colIkErreichungsGradCode";
            // 
            // colIkForderungTitelCode
            // 
            this.colIkForderungTitelCode.Name = "colIkForderungTitelCode";
            // 
            // colIkHatUnterstuetzung
            // 
            this.colIkHatUnterstuetzung.Name = "colIkHatUnterstuetzung";
            // 
            // colIkInkassoBemuehungCode
            // 
            this.colIkInkassoBemuehungCode.Name = "colIkInkassoBemuehungCode";
            // 
            // colIkIstRentenbezueger
            // 
            this.colIkIstRentenbezueger.Name = "colIkIstRentenbezueger";
            // 
            // colIkLeistungStatusCode
            // 
            this.colIkLeistungStatusCode.Name = "colIkLeistungStatusCode";
            // 
            // colIkRueckerstattungTypCode
            // 
            this.colIkRueckerstattungTypCode.Name = "colIkRueckerstattungTypCode";
            // 
            // colIkSchuldnerMahnen
            // 
            this.colIkSchuldnerMahnen.Name = "colIkSchuldnerMahnen";
            // 
            // colIkSchuldnerStatusCode
            // 
            this.colIkSchuldnerStatusCode.Name = "colIkSchuldnerStatusCode";
            // 
            // colIkVerjaehrungAm
            // 
            this.colIkVerjaehrungAm.Name = "colIkVerjaehrungAm";
            // 
            // colKaEpqJob
            // 
            this.colKaEpqJob.Name = "colKaEpqJob";
            // 
            // colKaProzessCode
            // 
            this.colKaProzessCode.Name = "colKaProzessCode";
            // 
            // colLeistungsartCode
            // 
            this.colLeistungsartCode.Name = "colLeistungsartCode";
            // 
            // colmigAiInkassoFallID
            // 
            this.colmigAiInkassoFallID.Name = "colmigAiInkassoFallID";
            // 
            // colMigrationKA
            // 
            this.colMigrationKA.Name = "colMigrationKA";
            // 
            // colModulID
            // 
            this.colModulID.Name = "colModulID";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colOldUnitID
            // 
            this.colOldUnitID.Name = "colOldUnitID";
            // 
            // colSchuldnerBaPersonID
            // 
            this.colSchuldnerBaPersonID.Name = "colSchuldnerBaPersonID";
            // 
            // colUserID
            // 
            this.colUserID.Name = "colUserID";
            // 
            // colVmAuftragCode
            // 
            this.colVmAuftragCode.Name = "colVmAuftragCode";
            // 
            // colVmProzessCodeOBSOLETE
            // 
            this.colVmProzessCodeOBSOLETE.Name = "colVmProzessCodeOBSOLETE";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // lblStatusHeute
            // 
            this.lblStatusHeute.Location = new System.Drawing.Point(14, 81);
            this.lblStatusHeute.Name = "lblStatusHeute";
            this.lblStatusHeute.Size = new System.Drawing.Size(96, 24);
            this.lblStatusHeute.TabIndex = 3;
            this.lblStatusHeute.Text = "Status heute";
            // 
            // edtStatusHeute
            // 
            this.edtStatusHeute.Location = new System.Drawing.Point(116, 81);
            this.edtStatusHeute.LOVName = "FaLeistungStatusAbfrage";
            this.edtStatusHeute.Name = "edtStatusHeute";
            this.edtStatusHeute.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusHeute.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusHeute.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusHeute.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusHeute.Properties.Appearance.Options.UseFont = true;
            this.edtStatusHeute.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatusHeute.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusHeute.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusHeute.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtStatusHeute.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusHeute.Properties.NullText = "";
            this.edtStatusHeute.Properties.ShowFooter = false;
            this.edtStatusHeute.Properties.ShowHeader = false;
            this.edtStatusHeute.Size = new System.Drawing.Size(250, 24);
            this.edtStatusHeute.TabIndex = 4;
            // 
            // lblEinsatz
            // 
            this.lblEinsatz.Location = new System.Drawing.Point(14, 111);
            this.lblEinsatz.Name = "lblEinsatz";
            this.lblEinsatz.Size = new System.Drawing.Size(96, 24);
            this.lblEinsatz.TabIndex = 5;
            this.lblEinsatz.Text = "Einsatz";
            // 
            // edtEinsatz
            // 
            this.edtEinsatz.Location = new System.Drawing.Point(116, 111);
            this.edtEinsatz.LOVName = "JaNein";
            this.edtEinsatz.Name = "edtEinsatz";
            this.edtEinsatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinsatz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinsatz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinsatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEinsatz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEinsatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatz.Properties.NullText = "";
            this.edtEinsatz.Properties.ShowFooter = false;
            this.edtEinsatz.Properties.ShowHeader = false;
            this.edtEinsatz.Size = new System.Drawing.Size(250, 24);
            this.edtEinsatz.TabIndex = 6;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(116, 141);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 8;
            this.edtDatumVon.EditValueChanged += new System.EventHandler(this.edtDatumVon_EditValueChanged);
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(266, 141);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 10;
            this.edtDatumBis.EditValueChanged += new System.EventHandler(this.edtDatumBis_EditValueChanged);
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(232, 141);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(28, 24);
            this.lblBis.TabIndex = 9;
            this.lblBis.Text = "bis";
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(14, 141);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(96, 24);
            this.lblDatumVon.TabIndex = 7;
            this.lblDatumVon.Text = "Zeitraum von";
            // 
            // CtlQueryKaKurseBIBIPSI
            // 
            this.Name = "CtlQueryKaKurseBIBIPSI";
            this.Load += new System.EventHandler(this.CtlQueryKaKurseBIBIPSI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            this.tpgGAExtBildung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExtBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryExtBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExtBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussGrundCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEroeffnungsGrundCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFaFallID;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungIDMigrationtmp;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungTS;
        private DevExpress.XtraGrid.Columns.GridColumn colFaProzessCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFlKostenstelleID;
        private DevExpress.XtraGrid.Columns.GridColumn colGemeindeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkAbklaerungMigrationtmp;
        private DevExpress.XtraGrid.Columns.GridColumn colIkAufenthaltsartCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkDatumForderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colIkDatumRechtskraft;
        private DevExpress.XtraGrid.Columns.GridColumn colIkEinnahmenQuoteCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkErreichungsGradCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkForderungTitelCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkHatUnterstuetzung;
        private DevExpress.XtraGrid.Columns.GridColumn colIkInkassoBemuehungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkIstRentenbezueger;
        private DevExpress.XtraGrid.Columns.GridColumn colIkLeistungStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkRueckerstattungTypCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkSchuldnerMahnen;
        private DevExpress.XtraGrid.Columns.GridColumn colIkSchuldnerStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIkVerjaehrungAm;
        private DevExpress.XtraGrid.Columns.GridColumn colKaEpqJob;
        private DevExpress.XtraGrid.Columns.GridColumn colKaProzessCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsartCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMigrationKA;
        private DevExpress.XtraGrid.Columns.GridColumn colModulID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOldUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colVmAuftragCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVmProzessCodeOBSOLETE;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colmigAiInkassoFallID;
        private KiSS4.Common.CtlGotoFall ctlGotoFallExtBildung;
        private KiSS4.Gui.KissButtonEdit edtZustaendigKA;
        private KiSS4.Gui.KissGrid grdExtBildung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvExtBildung;
        private KiSS4.Gui.KissLabel lblZustaendigKA;
        private KiSS4.DB.SqlQuery qryExtBildung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtEinsatz;
        private KiSS4.Gui.KissLookUpEdit edtStatusHeute;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEinsatz;
        private KiSS4.Gui.KissLabel lblStatusHeute;
        private SharpLibrary.WinControls.TabPageEx tpgGAExtBildung;
    }
}
