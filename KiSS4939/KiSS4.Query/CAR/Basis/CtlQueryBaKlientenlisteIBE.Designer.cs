namespace KiSS4.Query.CAR
{
    public partial class CtlQueryBaKlientenlisteIBE
    {
        #region Fields

        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtNNr;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissTextEdit edtZemisNr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblNNr;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblZemisNr;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaKlientenlisteIBE));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtNNr = new KiSS4.Gui.KissTextEdit();
            this.edtZemisNr = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblNNr = new KiSS4.Gui.KissLabel();
            this.lblZemisNr = new KiSS4.Gui.KissLabel();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.edtDatumWohnstatusVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumWohnstatusBis = new KiSS4.Gui.KissDateEdit();
            this.lblDatumWohnstatusBis = new KiSS4.Gui.KissLabel();
            this.lblDatumWohnstatusVon = new KiSS4.Gui.KissLabel();
            this.edtStichdatum = new KiSS4.Gui.KissDateEdit();
            this.lblStichdatum = new KiSS4.Gui.KissLabel();
            this.lblBestandesliste = new KiSS4.Gui.KissLabel();
            this.lblKlientenzahlen = new KiSS4.Gui.KissLabel();
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.tpgWohnstatus = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallWohnstatus = new KiSS4.Common.CtlGotoFall();
            this.grdWohnstatus = new KiSS4.Gui.KissGrid();
            this.grvWohnstatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgKlientenzahlen = new SharpLibrary.WinControls.TabPageEx();
            this.grdKlientenzahlen = new KiSS4.Gui.KissGrid();
            this.grvKlientenzahlen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKProzent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAnzahlKlienten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAbwSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKPersProDossier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKFAZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAKQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKFinanziellSelbstaendige = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKPKQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAbgaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZemisNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinreiseDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntscheiddatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDossierZahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBFluechtling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFFluechtling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAusweis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinanziellSelbstaendig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErwerbstaetig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiveKopfquote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOhneJeglichenKontakt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassiveKopfquote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKantonswechsel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKantonswechselEffektiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtFT = new KiSS4.Gui.KissCheckEdit();
            this.colNAusweis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinbezugFazGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAsylgesuch = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumWohnstatusVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumWohnstatusBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumWohnstatusBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumWohnstatusVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBestandesliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenzahlen)).BeginInit();
            this.tpgWohnstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWohnstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWohnstatus)).BeginInit();
            this.tpgKlientenzahlen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientenzahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientenzahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.FillTimeOut = 1800;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSAR,
            this.colName,
            this.colVorname,
            this.colNameFT,
            this.colZemisNr,
            this.colNNr,
            this.colBaPersonID,
            this.colGeschlecht,
            this.colGeburtsdatum,
            this.colEinreiseDatum,
            this.colEntscheiddatum,
            this.colDossierZahl,
            this.colBFluechtling,
            this.colFFluechtling,
            this.colNAusweis,
            this.colFAZ,
            this.colEinbezugFazGeburt,
            this.colAsylgesuch,
            this.colCAusweis,
            this.colFinanziellSelbstaendig,
            this.colErwerbstaetig,
            this.colAktiveKopfquote,
            this.colOhneJeglichenKontakt,
            this.colPassiveKopfquote,
            this.colKantonswechsel,
            this.colKantonswechselEffektiv,
            this.colBemerkungen});
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowFooter = true;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            this.grvQuery1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grvQuery1_CustomSummaryCalculate);
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
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgWohnstatus);
            this.tabControlSearch.Controls.Add(this.tpgKlientenzahlen);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgWohnstatus,
            this.tpgKlientenzahlen});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgKlientenzahlen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgWohnstatus, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Bestandesliste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtFT);
            this.tpgSuchen.Controls.Add(this.edtStichdatum);
            this.tpgSuchen.Controls.Add(this.lblStichdatum);
            this.tpgSuchen.Controls.Add(this.lblBestandesliste);
            this.tpgSuchen.Controls.Add(this.edtDatumWohnstatusVon);
            this.tpgSuchen.Controls.Add(this.edtDatumWohnstatusBis);
            this.tpgSuchen.Controls.Add(this.lblDatumWohnstatusBis);
            this.tpgSuchen.Controls.Add(this.lblDatumWohnstatusVon);
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.lblZemisNr);
            this.tpgSuchen.Controls.Add(this.lblNNr);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtZemisNr);
            this.tpgSuchen.Controls.Add(this.edtNNr);
            this.tpgSuchen.Controls.Add(this.lblKlientenzahlen);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlientenzahlen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZemisNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZemisNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumWohnstatusVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumWohnstatusBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumWohnstatusBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumWohnstatusVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBestandesliste, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStichdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStichdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFT, 0);
            // 
            // edtNNr
            // 
            this.edtNNr.Location = new System.Drawing.Point(161, 48);
            this.edtNNr.Name = "edtNNr";
            this.edtNNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNNr.Properties.Appearance.Options.UseFont = true;
            this.edtNNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNNr.Size = new System.Drawing.Size(111, 24);
            this.edtNNr.TabIndex = 1;
            // 
            // edtZemisNr
            // 
            this.edtZemisNr.Location = new System.Drawing.Point(161, 79);
            this.edtZemisNr.Name = "edtZemisNr";
            this.edtZemisNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZemisNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZemisNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZemisNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtZemisNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZemisNr.Properties.Appearance.Options.UseFont = true;
            this.edtZemisNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZemisNr.Size = new System.Drawing.Size(111, 24);
            this.edtZemisNr.TabIndex = 2;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Location = new System.Drawing.Point(161, 109);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPersonID.Size = new System.Drawing.Size(235, 24);
            this.edtBaPersonID.TabIndex = 3;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(161, 139);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(235, 24);
            this.edtUserID.TabIndex = 5;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // lblNNr
            // 
            this.lblNNr.Location = new System.Drawing.Point(21, 48);
            this.lblNNr.Name = "lblNNr";
            this.lblNNr.Size = new System.Drawing.Size(130, 24);
            this.lblNNr.TabIndex = 6;
            this.lblNNr.Text = "N-Nr.";
            this.lblNNr.UseCompatibleTextRendering = true;
            // 
            // lblZemisNr
            // 
            this.lblZemisNr.Location = new System.Drawing.Point(21, 79);
            this.lblZemisNr.Name = "lblZemisNr";
            this.lblZemisNr.Size = new System.Drawing.Size(130, 24);
            this.lblZemisNr.TabIndex = 7;
            this.lblZemisNr.Text = "Zemis-Nr.";
            this.lblZemisNr.UseCompatibleTextRendering = true;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(21, 109);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(130, 24);
            this.lblKlient.TabIndex = 8;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(21, 139);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 10;
            this.lblSAR.Text = "zuständiger SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
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
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            // edtOrgUnitID
            // 
            this.edtOrgUnitID.Location = new System.Drawing.Point(161, 169);
            this.edtOrgUnitID.Name = "edtOrgUnitID";
            this.edtOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(235, 24);
            this.edtOrgUnitID.TabIndex = 26;
            // 
            // lblSektion
            // 
            this.lblSektion.Location = new System.Drawing.Point(21, 169);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(130, 24);
            this.lblSektion.TabIndex = 25;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            // 
            // edtDatumWohnstatusVon
            // 
            this.edtDatumWohnstatusVon.EditValue = null;
            this.edtDatumWohnstatusVon.Location = new System.Drawing.Point(161, 199);
            this.edtDatumWohnstatusVon.Name = "edtDatumWohnstatusVon";
            this.edtDatumWohnstatusVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumWohnstatusVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumWohnstatusVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumWohnstatusVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumWohnstatusVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumWohnstatusVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumWohnstatusVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumWohnstatusVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumWohnstatusVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumWohnstatusVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumWohnstatusVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumWohnstatusVon.Properties.ShowToday = false;
            this.edtDatumWohnstatusVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumWohnstatusVon.TabIndex = 29;
            // 
            // edtDatumWohnstatusBis
            // 
            this.edtDatumWohnstatusBis.EditValue = null;
            this.edtDatumWohnstatusBis.Location = new System.Drawing.Point(296, 199);
            this.edtDatumWohnstatusBis.Name = "edtDatumWohnstatusBis";
            this.edtDatumWohnstatusBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumWohnstatusBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumWohnstatusBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumWohnstatusBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumWohnstatusBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumWohnstatusBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumWohnstatusBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumWohnstatusBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumWohnstatusBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumWohnstatusBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumWohnstatusBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumWohnstatusBis.Properties.ShowToday = false;
            this.edtDatumWohnstatusBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumWohnstatusBis.TabIndex = 30;
            // 
            // lblDatumWohnstatusBis
            // 
            this.lblDatumWohnstatusBis.Location = new System.Drawing.Point(267, 199);
            this.lblDatumWohnstatusBis.Name = "lblDatumWohnstatusBis";
            this.lblDatumWohnstatusBis.Size = new System.Drawing.Size(23, 24);
            this.lblDatumWohnstatusBis.TabIndex = 27;
            this.lblDatumWohnstatusBis.Text = "bis";
            this.lblDatumWohnstatusBis.UseCompatibleTextRendering = true;
            // 
            // lblDatumWohnstatusVon
            // 
            this.lblDatumWohnstatusVon.Location = new System.Drawing.Point(21, 199);
            this.lblDatumWohnstatusVon.Name = "lblDatumWohnstatusVon";
            this.lblDatumWohnstatusVon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumWohnstatusVon.TabIndex = 28;
            this.lblDatumWohnstatusVon.Text = "Wohnstatus von";
            this.lblDatumWohnstatusVon.UseCompatibleTextRendering = true;
            // 
            // edtStichdatum
            // 
            this.edtStichdatum.EditValue = null;
            this.edtStichdatum.Location = new System.Drawing.Point(161, 229);
            this.edtStichdatum.Name = "edtStichdatum";
            this.edtStichdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStichdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichdatum.Properties.Appearance.Options.UseFont = true;
            this.edtStichdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtStichdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtStichdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtStichdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStichdatum.Properties.ShowToday = false;
            this.edtStichdatum.Size = new System.Drawing.Size(100, 24);
            this.edtStichdatum.TabIndex = 33;
            // 
            // lblStichdatum
            // 
            this.lblStichdatum.Location = new System.Drawing.Point(267, 229);
            this.lblStichdatum.Name = "lblStichdatum";
            this.lblStichdatum.Size = new System.Drawing.Size(129, 24);
            this.lblStichdatum.TabIndex = 31;
            this.lblStichdatum.Text = "Stichdatum";
            this.lblStichdatum.UseCompatibleTextRendering = true;
            // 
            // lblBestandesliste
            // 
            this.lblBestandesliste.Location = new System.Drawing.Point(21, 223);
            this.lblBestandesliste.Name = "lblBestandesliste";
            this.lblBestandesliste.Size = new System.Drawing.Size(130, 24);
            this.lblBestandesliste.TabIndex = 32;
            this.lblBestandesliste.Text = "Bestandesliste";
            this.lblBestandesliste.UseCompatibleTextRendering = true;
            // 
            // lblKlientenzahlen
            // 
            this.lblKlientenzahlen.Location = new System.Drawing.Point(21, 238);
            this.lblKlientenzahlen.Name = "lblKlientenzahlen";
            this.lblKlientenzahlen.Size = new System.Drawing.Size(130, 24);
            this.lblKlientenzahlen.TabIndex = 34;
            this.lblKlientenzahlen.Text = "Klientenzahlen";
            this.lblKlientenzahlen.UseCompatibleTextRendering = true;
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Title = "tabPageEx1";
            // 
            // tpgWohnstatus
            // 
            this.tpgWohnstatus.Controls.Add(this.ctlGotoFallWohnstatus);
            this.tpgWohnstatus.Controls.Add(this.grdWohnstatus);
            this.tpgWohnstatus.Location = new System.Drawing.Point(6, 6);
            this.tpgWohnstatus.Name = "tpgWohnstatus";
            this.tpgWohnstatus.Size = new System.Drawing.Size(772, 424);
            this.tpgWohnstatus.TabIndex = 1;
            this.tpgWohnstatus.Title = "Wohnstatus";
            // 
            // ctlGotoFallWohnstatus
            // 
            this.ctlGotoFallWohnstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallWohnstatus.DataMember = "BaPersonID$";
            this.ctlGotoFallWohnstatus.Location = new System.Drawing.Point(3, 398);
            this.ctlGotoFallWohnstatus.Name = "ctlGotoFallWohnstatus";
            this.ctlGotoFallWohnstatus.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallWohnstatus.TabIndex = 0;
            // 
            // grdWohnstatus
            // 
            this.grdWohnstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWohnstatus.ColumnFilterActivated = true;
            // 
            // 
            // 
            this.grdWohnstatus.EmbeddedNavigator.Name = "";
            this.grdWohnstatus.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdWohnstatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdWohnstatus.Location = new System.Drawing.Point(3, 0);
            this.grdWohnstatus.MainView = this.grvWohnstatus;
            this.grdWohnstatus.Name = "grdWohnstatus";
            this.grdWohnstatus.Size = new System.Drawing.Size(766, 392);
            this.grdWohnstatus.TabIndex = 1;
            this.grdWohnstatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWohnstatus});
            // 
            // grvWohnstatus
            // 
            this.grvWohnstatus.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvWohnstatus.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.Empty.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.Empty.Options.UseFont = true;
            this.grvWohnstatus.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvWohnstatus.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.EvenRow.Options.UseFont = true;
            this.grvWohnstatus.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWohnstatus.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvWohnstatus.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.FocusedCell.Options.UseFont = true;
            this.grvWohnstatus.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvWohnstatus.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWohnstatus.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvWohnstatus.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.FocusedRow.Options.UseFont = true;
            this.grvWohnstatus.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvWohnstatus.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWohnstatus.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvWohnstatus.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvWohnstatus.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWohnstatus.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWohnstatus.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWohnstatus.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWohnstatus.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.GroupRow.Options.UseFont = true;
            this.grvWohnstatus.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvWohnstatus.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvWohnstatus.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvWohnstatus.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWohnstatus.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvWohnstatus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWohnstatus.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvWohnstatus.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWohnstatus.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvWohnstatus.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvWohnstatus.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvWohnstatus.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvWohnstatus.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.OddRow.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.OddRow.Options.UseFont = true;
            this.grvWohnstatus.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvWohnstatus.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.Row.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.Row.Options.UseFont = true;
            this.grvWohnstatus.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvWohnstatus.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWohnstatus.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvWohnstatus.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvWohnstatus.Appearance.SelectedRow.Options.UseFont = true;
            this.grvWohnstatus.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvWohnstatus.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvWohnstatus.Appearance.VertLine.Options.UseBackColor = true;
            this.grvWohnstatus.BestFitMaxRowCount = 50;
            this.grvWohnstatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvWohnstatus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvWohnstatus.GridControl = this.grdWohnstatus;
            this.grvWohnstatus.Name = "grvWohnstatus";
            this.grvWohnstatus.OptionsBehavior.Editable = false;
            this.grvWohnstatus.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvWohnstatus.OptionsNavigation.AutoFocusNewRow = true;
            this.grvWohnstatus.OptionsNavigation.UseTabKey = false;
            this.grvWohnstatus.OptionsPrint.AutoWidth = false;
            this.grvWohnstatus.OptionsPrint.ExpandAllDetails = true;
            this.grvWohnstatus.OptionsPrint.UsePrintStyles = true;
            this.grvWohnstatus.OptionsView.ColumnAutoWidth = false;
            this.grvWohnstatus.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvWohnstatus.OptionsView.ShowGroupPanel = false;
            this.grvWohnstatus.OptionsView.ShowIndicator = false;
            // 
            // tpgKlientenzahlen
            // 
            this.tpgKlientenzahlen.Controls.Add(this.grdKlientenzahlen);
            this.tpgKlientenzahlen.Location = new System.Drawing.Point(6, 6);
            this.tpgKlientenzahlen.Name = "tpgKlientenzahlen";
            this.tpgKlientenzahlen.Size = new System.Drawing.Size(772, 424);
            this.tpgKlientenzahlen.TabIndex = 2;
            this.tpgKlientenzahlen.Title = "Klientenzahlen";
            // 
            // grdKlientenzahlen
            // 
            this.grdKlientenzahlen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKlientenzahlen.ColumnFilterActivated = true;
            // 
            // 
            // 
            this.grdKlientenzahlen.EmbeddedNavigator.Name = "";
            this.grdKlientenzahlen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKlientenzahlen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdKlientenzahlen.Location = new System.Drawing.Point(3, 0);
            this.grdKlientenzahlen.MainView = this.grvKlientenzahlen;
            this.grdKlientenzahlen.Name = "grdKlientenzahlen";
            this.grdKlientenzahlen.Size = new System.Drawing.Size(766, 424);
            this.grdKlientenzahlen.TabIndex = 2;
            this.grdKlientenzahlen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKlientenzahlen});
            // 
            // grvKlientenzahlen
            // 
            this.grvKlientenzahlen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKlientenzahlen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.Empty.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.Empty.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKlientenzahlen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.EvenRow.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKlientenzahlen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKlientenzahlen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKlientenzahlen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKlientenzahlen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKlientenzahlen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKlientenzahlen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientenzahlen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKlientenzahlen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvKlientenzahlen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientenzahlen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientenzahlen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientenzahlen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientenzahlen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.GroupRow.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKlientenzahlen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKlientenzahlen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKlientenzahlen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientenzahlen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKlientenzahlen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKlientenzahlen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientenzahlen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKlientenzahlen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKlientenzahlen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvKlientenzahlen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.OddRow.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.OddRow.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKlientenzahlen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.Row.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.Row.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvKlientenzahlen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenzahlen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKlientenzahlen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKlientenzahlen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKlientenzahlen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKlientenzahlen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKlientenzahlen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKlientenzahlen.BestFitMaxRowCount = 50;
            this.grvKlientenzahlen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKlientenzahlen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKSAR,
            this.colKProzent,
            this.colKSoll,
            this.colKAnzahlKlienten,
            this.colKAbwSoll,
            this.colKPersProDossier,
            this.colKAnzahlDossiers,
            this.colKFAZ,
            this.colKAKQ,
            this.colKFinanziellSelbstaendige,
            this.colKPKQ,
            this.colKAbgaben});
            this.grvKlientenzahlen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKlientenzahlen.GridControl = this.grdKlientenzahlen;
            this.grvKlientenzahlen.Name = "grvKlientenzahlen";
            this.grvKlientenzahlen.OptionsBehavior.Editable = false;
            this.grvKlientenzahlen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKlientenzahlen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKlientenzahlen.OptionsNavigation.UseTabKey = false;
            this.grvKlientenzahlen.OptionsPrint.AutoWidth = false;
            this.grvKlientenzahlen.OptionsPrint.ExpandAllDetails = true;
            this.grvKlientenzahlen.OptionsPrint.UsePrintStyles = true;
            this.grvKlientenzahlen.OptionsView.ColumnAutoWidth = false;
            this.grvKlientenzahlen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKlientenzahlen.OptionsView.ShowFooter = true;
            this.grvKlientenzahlen.OptionsView.ShowGroupPanel = false;
            this.grvKlientenzahlen.OptionsView.ShowIndicator = false;
            // 
            // colKSAR
            // 
            this.colKSAR.Caption = "SAR";
            this.colKSAR.FieldName = "SAR";
            this.colKSAR.Name = "colKSAR";
            this.colKSAR.Visible = true;
            this.colKSAR.VisibleIndex = 0;
            // 
            // colKProzent
            // 
            this.colKProzent.Caption = "%";
            this.colKProzent.FieldName = "Prozent";
            this.colKProzent.Name = "colKProzent";
            this.colKProzent.Visible = true;
            this.colKProzent.VisibleIndex = 1;
            // 
            // colKSoll
            // 
            this.colKSoll.Caption = "Soll";
            this.colKSoll.FieldName = "Soll";
            this.colKSoll.Name = "colKSoll";
            this.colKSoll.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKSoll.Visible = true;
            this.colKSoll.VisibleIndex = 2;
            // 
            // colKAnzahlKlienten
            // 
            this.colKAnzahlKlienten.Caption = "Anzahl Klienten";
            this.colKAnzahlKlienten.FieldName = "AnzahlKlienten";
            this.colKAnzahlKlienten.Name = "colKAnzahlKlienten";
            this.colKAnzahlKlienten.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKAnzahlKlienten.Visible = true;
            this.colKAnzahlKlienten.VisibleIndex = 3;
            // 
            // colKAbwSoll
            // 
            this.colKAbwSoll.Caption = "Abw. Soll";
            this.colKAbwSoll.FieldName = "AbwSoll";
            this.colKAbwSoll.Name = "colKAbwSoll";
            this.colKAbwSoll.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKAbwSoll.Visible = true;
            this.colKAbwSoll.VisibleIndex = 4;
            // 
            // colKPersProDossier
            // 
            this.colKPersProDossier.Caption = "Pers. / Doss.";
            this.colKPersProDossier.FieldName = "PersProDossier";
            this.colKPersProDossier.Name = "colKPersProDossier";
            this.colKPersProDossier.Visible = true;
            this.colKPersProDossier.VisibleIndex = 5;
            // 
            // colKAnzahlDossiers
            // 
            this.colKAnzahlDossiers.Caption = "Dossiers";
            this.colKAnzahlDossiers.FieldName = "AnzahlDossiers";
            this.colKAnzahlDossiers.Name = "colKAnzahlDossiers";
            this.colKAnzahlDossiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKAnzahlDossiers.Visible = true;
            this.colKAnzahlDossiers.VisibleIndex = 6;
            // 
            // colKFAZ
            // 
            this.colKFAZ.Caption = "FAZ";
            this.colKFAZ.FieldName = "FAZ";
            this.colKFAZ.Name = "colKFAZ";
            this.colKFAZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKFAZ.Visible = true;
            this.colKFAZ.VisibleIndex = 7;
            // 
            // colKAKQ
            // 
            this.colKAKQ.Caption = "AKQ";
            this.colKAKQ.FieldName = "AKQ";
            this.colKAKQ.Name = "colKAKQ";
            this.colKAKQ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKAKQ.Visible = true;
            this.colKAKQ.VisibleIndex = 8;
            // 
            // colKFinanziellSelbstaendige
            // 
            this.colKFinanziellSelbstaendige.Caption = "finanziell Selbständige";
            this.colKFinanziellSelbstaendige.FieldName = "FinanziellSelbstaendige";
            this.colKFinanziellSelbstaendige.Name = "colKFinanziellSelbstaendige";
            this.colKFinanziellSelbstaendige.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKFinanziellSelbstaendige.Visible = true;
            this.colKFinanziellSelbstaendige.VisibleIndex = 9;
            // 
            // colKPKQ
            // 
            this.colKPKQ.Caption = "PKQ";
            this.colKPKQ.FieldName = "PKQ";
            this.colKPKQ.Name = "colKPKQ";
            this.colKPKQ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKPKQ.Visible = true;
            this.colKPKQ.VisibleIndex = 10;
            // 
            // colKAbgaben
            // 
            this.colKAbgaben.Caption = "Abgaben in diesem Monat";
            this.colKAbgaben.FieldName = "Abgaben";
            this.colKAbgaben.Name = "colKAbgaben";
            this.colKAbgaben.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKAbgaben.Visible = true;
            this.colKAbgaben.VisibleIndex = 11;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "Zust. SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 2;
            // 
            // colNameFT
            // 
            this.colNameFT.Caption = "Name Dossierträger";
            this.colNameFT.FieldName = "NameFT";
            this.colNameFT.Name = "colNameFT";
            this.colNameFT.Visible = true;
            this.colNameFT.VisibleIndex = 3;
            // 
            // colZemisNr
            // 
            this.colZemisNr.Caption = "ZEMIS-Nummer";
            this.colZemisNr.FieldName = "ZemisNr";
            this.colZemisNr.Name = "colZemisNr";
            this.colZemisNr.Visible = true;
            this.colZemisNr.VisibleIndex = 4;
            // 
            // colNNr
            // 
            this.colNNr.Caption = "N-Nummer";
            this.colNNr.FieldName = "NNr";
            this.colNNr.Name = "colNNr";
            this.colNNr.Visible = true;
            this.colNNr.VisibleIndex = 5;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Personen-Nummer";
            this.colBaPersonID.FieldName = "BFFNummer";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 6;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Caption = "Geschlecht";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 7;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geburtsdatum";
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 8;
            // 
            // colEinreiseDatum
            // 
            this.colEinreiseDatum.Caption = "Einreisedatum";
            this.colEinreiseDatum.FieldName = "Einreisedatum";
            this.colEinreiseDatum.Name = "colEinreiseDatum";
            this.colEinreiseDatum.Visible = true;
            this.colEinreiseDatum.VisibleIndex = 9;
            // 
            // colEntscheiddatum
            // 
            this.colEntscheiddatum.Caption = "Entscheiddatum";
            this.colEntscheiddatum.FieldName = "Entscheiddatum";
            this.colEntscheiddatum.Name = "colEntscheiddatum";
            this.colEntscheiddatum.Visible = true;
            this.colEntscheiddatum.VisibleIndex = 10;
            // 
            // colDossierZahl
            // 
            this.colDossierZahl.Caption = "Dossier Zahl";
            this.colDossierZahl.FieldName = "DossierZahl";
            this.colDossierZahl.Name = "colDossierZahl";
            this.colDossierZahl.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colDossierZahl.Visible = true;
            this.colDossierZahl.VisibleIndex = 11;
            // 
            // colBFluechtling
            // 
            this.colBFluechtling.Caption = "B-Flüchtling";
            this.colBFluechtling.FieldName = "BFluechtling";
            this.colBFluechtling.Name = "colBFluechtling";
            this.colBFluechtling.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBFluechtling.Visible = true;
            this.colBFluechtling.VisibleIndex = 12;
            // 
            // colFFluechtling
            // 
            this.colFFluechtling.Caption = "F-Flüchtling";
            this.colFFluechtling.FieldName = "FFluechtling";
            this.colFFluechtling.Name = "colFFluechtling";
            this.colFFluechtling.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colFFluechtling.Visible = true;
            this.colFFluechtling.VisibleIndex = 13;
            // 
            // colFAZ
            // 
            this.colFAZ.Caption = "FAZ";
            this.colFAZ.FieldName = "FAZ";
            this.colFAZ.Name = "colFAZ";
            this.colFAZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colFAZ.Visible = true;
            this.colFAZ.VisibleIndex = 15;
            // 
            // colCAusweis
            // 
            this.colCAusweis.Caption = "C-Ausweis; bzw. voraussichtliches Abgabedatum an die Gemeinde";
            this.colCAusweis.FieldName = "CAusweis";
            this.colCAusweis.Name = "colCAusweis";
            this.colCAusweis.Visible = true;
            this.colCAusweis.VisibleIndex = 18;
            // 
            // colFinanziellSelbstaendig
            // 
            this.colFinanziellSelbstaendig.Caption = "Finanziell selbständig";
            this.colFinanziellSelbstaendig.FieldName = "FinanziellSelbstaendig";
            this.colFinanziellSelbstaendig.Name = "colFinanziellSelbstaendig";
            this.colFinanziellSelbstaendig.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colFinanziellSelbstaendig.Visible = true;
            this.colFinanziellSelbstaendig.VisibleIndex = 19;
            // 
            // colErwerbstaetig
            // 
            this.colErwerbstaetig.Caption = "Erwerbstätig";
            this.colErwerbstaetig.FieldName = "Erwerbstaetig";
            this.colErwerbstaetig.Name = "colErwerbstaetig";
            this.colErwerbstaetig.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colErwerbstaetig.Visible = true;
            this.colErwerbstaetig.VisibleIndex = 20;
            // 
            // colAktiveKopfquote
            // 
            this.colAktiveKopfquote.Caption = "Aktive Kopfquote (C-Ausweis im Dos.)";
            this.colAktiveKopfquote.FieldName = "AktiveKopfquote";
            this.colAktiveKopfquote.Name = "colAktiveKopfquote";
            this.colAktiveKopfquote.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAktiveKopfquote.Visible = true;
            this.colAktiveKopfquote.VisibleIndex = 21;
            // 
            // colOhneJeglichenKontakt
            // 
            this.colOhneJeglichenKontakt.Caption = "Ohne jeglichen Kontakt";
            this.colOhneJeglichenKontakt.FieldName = "OhneJeglichenKontakt";
            this.colOhneJeglichenKontakt.Name = "colOhneJeglichenKontakt";
            this.colOhneJeglichenKontakt.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colOhneJeglichenKontakt.Visible = true;
            this.colOhneJeglichenKontakt.VisibleIndex = 22;
            // 
            // colPassiveKopfquote
            // 
            this.colPassiveKopfquote.Caption = "Passive Kopfquote";
            this.colPassiveKopfquote.FieldName = "PassiveKopfquote";
            this.colPassiveKopfquote.Name = "colPassiveKopfquote";
            this.colPassiveKopfquote.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colPassiveKopfquote.Visible = true;
            this.colPassiveKopfquote.VisibleIndex = 23;
            // 
            // colKantonswechsel
            // 
            this.colKantonswechsel.Caption = "Kantonswechsel";
            this.colKantonswechsel.FieldName = "Kantonswechsel";
            this.colKantonswechsel.Name = "colKantonswechsel";
            this.colKantonswechsel.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colKantonswechsel.Visible = true;
            this.colKantonswechsel.VisibleIndex = 24;
            // 
            // colKantonswechselEffektiv
            // 
            this.colKantonswechselEffektiv.Caption = "Kantonswechsel: effektiver Unterstützungsbeginn, resp. -ende";
            this.colKantonswechselEffektiv.FieldName = "KantonswechselEffektiv";
            this.colKantonswechselEffektiv.Name = "colKantonswechselEffektiv";
            this.colKantonswechselEffektiv.Visible = true;
            this.colKantonswechselEffektiv.VisibleIndex = 25;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 26;
            // 
            // edtFT
            // 
            this.edtFT.EditValue = false;
            this.edtFT.Location = new System.Drawing.Point(161, 263);
            this.edtFT.Name = "edtFT";
            this.edtFT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtFT.Properties.Caption = "nur Fallträger";
            this.edtFT.Size = new System.Drawing.Size(150, 19);
            this.edtFT.TabIndex = 35;
            // 
            // colNAusweis
            // 
            this.colNAusweis.Caption = "N-Ausweis (Asyl suchende/r)";
            this.colNAusweis.FieldName = "NAusweis";
            this.colNAusweis.Name = "colNAusweis";
            this.colNAusweis.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colNAusweis.Visible = true;
            this.colNAusweis.VisibleIndex = 14;
            // 
            // colEinbezugFazGeburt
            // 
            this.colEinbezugFazGeburt.Caption = "Einbezug FAZ/Geburt";
            this.colEinbezugFazGeburt.FieldName = "EinbezungFazGeburt";
            this.colEinbezugFazGeburt.Name = "colEinbezugFazGeburt";
            this.colEinbezugFazGeburt.Visible = true;
            this.colEinbezugFazGeburt.VisibleIndex = 16;
            // 
            // colAsylgesuch
            // 
            this.colAsylgesuch.Caption = "Asylgesuch";
            this.colAsylgesuch.FieldName = "Asylgesuch";
            this.colAsylgesuch.Name = "colAsylgesuch";
            this.colAsylgesuch.Visible = true;
            this.colAsylgesuch.VisibleIndex = 17;
            // 
            // CtlQueryBaKlientenlisteIBE
            // 
            this.Name = "CtlQueryBaKlientenlisteIBE";
            this.Load += new System.EventHandler(this.CtlQueryBaKlientenlisteIBE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumWohnstatusVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumWohnstatusBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumWohnstatusBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumWohnstatusVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBestandesliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenzahlen)).EndInit();
            this.tpgWohnstatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWohnstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWohnstatus)).EndInit();
            this.tpgKlientenzahlen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientenzahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientenzahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLookUpEdit edtOrgUnitID;
        private Gui.KissLabel lblSektion;
        private Gui.KissDateEdit edtDatumWohnstatusVon;
        private Gui.KissDateEdit edtDatumWohnstatusBis;
        private Gui.KissLabel lblDatumWohnstatusBis;
        private Gui.KissLabel lblDatumWohnstatusVon;
        private Gui.KissDateEdit edtStichdatum;
        private Gui.KissLabel lblStichdatum;
        private Gui.KissLabel lblBestandesliste;
        private Gui.KissLabel lblKlientenzahlen;
        private SharpLibrary.WinControls.TabPageEx tpgWohnstatus;
        private SharpLibrary.WinControls.TabPageEx tpgKlientenzahlen;
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private Common.CtlGotoFall ctlGotoFallWohnstatus;
        protected Gui.KissGrid grdWohnstatus;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvWohnstatus;
        protected Gui.KissGrid grdKlientenzahlen;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvKlientenzahlen;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colNameFT;
        private DevExpress.XtraGrid.Columns.GridColumn colZemisNr;
        private DevExpress.XtraGrid.Columns.GridColumn colNNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colEinreiseDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colEntscheiddatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDossierZahl;
        private DevExpress.XtraGrid.Columns.GridColumn colBFluechtling;
        private DevExpress.XtraGrid.Columns.GridColumn colFFluechtling;
        private DevExpress.XtraGrid.Columns.GridColumn colFAZ;
        private DevExpress.XtraGrid.Columns.GridColumn colCAusweis;
        private DevExpress.XtraGrid.Columns.GridColumn colFinanziellSelbstaendig;
        private DevExpress.XtraGrid.Columns.GridColumn colErwerbstaetig;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiveKopfquote;
        private DevExpress.XtraGrid.Columns.GridColumn colOhneJeglichenKontakt;
        private DevExpress.XtraGrid.Columns.GridColumn colPassiveKopfquote;
        private DevExpress.XtraGrid.Columns.GridColumn colKantonswechsel;
        private DevExpress.XtraGrid.Columns.GridColumn colKantonswechselEffektiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colKSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colKProzent;
        private DevExpress.XtraGrid.Columns.GridColumn colKSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colKAnzahlKlienten;
        private DevExpress.XtraGrid.Columns.GridColumn colKAbwSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colKPersProDossier;
        private DevExpress.XtraGrid.Columns.GridColumn colKAnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn colKFAZ;
        private DevExpress.XtraGrid.Columns.GridColumn colKAKQ;
        private DevExpress.XtraGrid.Columns.GridColumn colKFinanziellSelbstaendige;
        private DevExpress.XtraGrid.Columns.GridColumn colKPKQ;
        private DevExpress.XtraGrid.Columns.GridColumn colKAbgaben;
        private Gui.KissCheckEdit edtFT;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraGrid.Columns.GridColumn colNAusweis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinbezugFazGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colAsylgesuch;
    }
}