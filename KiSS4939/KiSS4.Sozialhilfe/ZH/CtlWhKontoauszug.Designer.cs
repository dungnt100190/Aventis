namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlWhKontoauszug
    {
        private System.ComponentModel.IContainer components;

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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhKontoauszug));
            this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerwPeriodeVonDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBisDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlientDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungsDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKontoauszug = new KiSS4.Gui.KissGrid();
            this.qryKontoauszug = new KiSS4.DB.SqlQuery(this.components);
            this.grvKbBuchungKostenartBrutto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPerioedBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEffektivesZahldatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAnzahlAuszahlbelege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBudgetId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSplitting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgabe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDritte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colMahnstufe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBruttoBeleg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechnungsnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panTitel = new System.Windows.Forms.Panel();
            this.lblSuchkriterien = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblKonto = new KiSS4.Gui.KissLabel();
            this.edtPerson = new KiSS4.Gui.KissLookUpEdit();
            this.lblZeitraum = new KiSS4.Gui.KissLabel();
            this.edtZeitraum = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.edtVerdichtet = new KiSS4.Gui.KissCheckEdit();
            this.lblVon = new KiSS4.Gui.KissLabel();
            this.edtInklProLeist = new KiSS4.Gui.KissCheckEdit();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtInklVermittlungsfall = new KiSS4.Gui.KissCheckEdit();
            this.edtInklGruen = new KiSS4.Gui.KissCheckEdit();
            this.edtInklRot = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.edtExklWV = new KiSS4.Gui.KissCheckEdit();
            this.edtInklStorno = new KiSS4.Gui.KissCheckEdit();
            this.edtStichtag = new KiSS4.Gui.KissCheckEdit();
            this.kissTabControlEx1 = new KiSS4.Gui.KissTabControlEx();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.grdDoc = new KiSS4.Gui.KissGrid();
            this.qryBgDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtDokumentTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblDokumentTyp = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.tpgBuchung = new SharpLibrary.WinControls.TabPageEx();
            this.btnBudgetPosition = new KiSS4.Gui.KissButton();
            this.kissDateEdit1 = new KiSS4.Gui.KissDateEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.edtBetrag100 = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit7 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit4 = new KiSS4.Gui.KissTextEdit();
            this.edtBgSplittingCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSplittingCode = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriodeStrich = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriode = new KiSS4.Gui.KissLabel();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.lblErfassungDatum = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.edtKreditor = new KiSS4.Gui.KissMemoEdit();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext2 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.btnWordDrucken = new KiSS4.Dokument.KissDocumentButton();
            this.btnAuswahlKlientenkontoabrechnung = new KiSS4.Gui.KissButton();
            this.multiSelectListboxes = new KiSS4.Gui.KissDoubleListSelector();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoauszug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoauszug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenartBrutto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchkriterien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerdichtet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklProLeist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklVermittlungsfall.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklGruen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklRot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExklWV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklStorno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).BeginInit();
            this.kissTabControlEx1.SuspendLayout();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            this.tpgBuchung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag100.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Location = new System.Drawing.Point(5, -1);
            this.searchTitle.Size = new System.Drawing.Size(868, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(5, 31);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(892, 514);
            this.tabControlSearch.TabIndex = 1;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKontoauszug);
            this.tpgListe.Size = new System.Drawing.Size(880, 476);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.multiSelectListboxes);
            this.tpgSuchen.Controls.Add(this.btnAuswahlKlientenkontoabrechnung);
            this.tpgSuchen.Controls.Add(this.edtStichtag);
            this.tpgSuchen.Controls.Add(this.edtInklStorno);
            this.tpgSuchen.Controls.Add(this.edtExklWV);
            this.tpgSuchen.Controls.Add(this.kissLabel11);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.edtInklRot);
            this.tpgSuchen.Controls.Add(this.edtInklGruen);
            this.tpgSuchen.Controls.Add(this.edtInklVermittlungsfall);
            this.tpgSuchen.Controls.Add(this.lblLeistungsart);
            this.tpgSuchen.Controls.Add(this.edtInklProLeist);
            this.tpgSuchen.Controls.Add(this.lblVon);
            this.tpgSuchen.Controls.Add(this.edtVerdichtet);
            this.tpgSuchen.Controls.Add(this.lblBis);
            this.tpgSuchen.Controls.Add(this.edtBuchungstext);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtZeitraum);
            this.tpgSuchen.Controls.Add(this.lblZeitraum);
            this.tpgSuchen.Controls.Add(this.edtPerson);
            this.tpgSuchen.Controls.Add(this.lblKonto);
            this.tpgSuchen.Size = new System.Drawing.Size(880, 476);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKonto, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBuchungstext, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVerdichtet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklProLeist, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklVermittlungsfall, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklGruen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklRot, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel11, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtExklWV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklStorno, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStichtag, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnAuswahlKlientenkontoabrechnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.multiSelectListboxes, 0);
            // 
            // grvDetail
            // 
            this.grvDetail.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDetail.Appearance.Empty.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetail.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDetail.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDetail.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetail.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDetail.Appearance.HeaderPanel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.grvDetail.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDetail.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetail.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.Row.BackColor = System.Drawing.Color.LightCyan;
            this.grvDetail.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.Row.Options.UseBackColor = true;
            this.grvDetail.Appearance.Row.Options.UseFont = true;
            this.grvDetail.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetail.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerwPeriodeVonDetail,
            this.colVerwPeriodeBisDetail,
            this.colBetragDetail,
            this.colKlientDetail,
            this.colErfassungsDatum});
            this.grvDetail.GridControl = this.grdKontoauszug;
            this.grvDetail.Name = "grvDetail";
            this.grvDetail.OptionsBehavior.Editable = false;
            this.grvDetail.OptionsCustomization.AllowFilter = false;
            this.grvDetail.OptionsView.ColumnAutoWidth = false;
            this.grvDetail.OptionsView.ShowGroupPanel = false;
            this.grvDetail.OptionsView.ShowIndicator = false;
            // 
            // colVerwPeriodeVonDetail
            // 
            this.colVerwPeriodeVonDetail.Caption = "Verw. von";
            this.colVerwPeriodeVonDetail.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVonDetail.Name = "colVerwPeriodeVonDetail";
            this.colVerwPeriodeVonDetail.Visible = true;
            this.colVerwPeriodeVonDetail.VisibleIndex = 0;
            this.colVerwPeriodeVonDetail.Width = 70;
            // 
            // colVerwPeriodeBisDetail
            // 
            this.colVerwPeriodeBisDetail.Caption = "Verw. bis";
            this.colVerwPeriodeBisDetail.FieldName = "VerwPeriodeBis";
            this.colVerwPeriodeBisDetail.Name = "colVerwPeriodeBisDetail";
            this.colVerwPeriodeBisDetail.Visible = true;
            this.colVerwPeriodeBisDetail.VisibleIndex = 1;
            // 
            // colBetragDetail
            // 
            this.colBetragDetail.Caption = "Betrag";
            this.colBetragDetail.DisplayFormat.FormatString = "n2";
            this.colBetragDetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragDetail.FieldName = "Betrag";
            this.colBetragDetail.Name = "colBetragDetail";
            this.colBetragDetail.Visible = true;
            this.colBetragDetail.VisibleIndex = 3;
            this.colBetragDetail.Width = 70;
            // 
            // colKlientDetail
            // 
            this.colKlientDetail.Caption = "Klient/in";
            this.colKlientDetail.FieldName = "Klient";
            this.colKlientDetail.Name = "colKlientDetail";
            this.colKlientDetail.Visible = true;
            this.colKlientDetail.VisibleIndex = 2;
            this.colKlientDetail.Width = 300;
            // 
            // colErfassungsDatum
            // 
            this.colErfassungsDatum.Caption = "Erfassung";
            this.colErfassungsDatum.FieldName = "ErfassungsDatum";
            this.colErfassungsDatum.Name = "colErfassungsDatum";
            this.colErfassungsDatum.Visible = true;
            this.colErfassungsDatum.VisibleIndex = 4;
            // 
            // grdKontoauszug
            // 
            this.grdKontoauszug.DataSource = this.qryKontoauszug;
            this.grdKontoauszug.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKontoauszug.EmbeddedNavigator.Name = "";
            this.grdKontoauszug.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            gridLevelNode1.LevelTemplate = this.grvDetail;
            gridLevelNode1.RelationName = "BelegDetail";
            this.grdKontoauszug.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdKontoauszug.Location = new System.Drawing.Point(0, 0);
            this.grdKontoauszug.MainView = this.grvKbBuchungKostenartBrutto;
            this.grdKontoauszug.Name = "grdKontoauszug";
            this.grdKontoauszug.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdKontoauszug.Size = new System.Drawing.Size(880, 476);
            this.grdKontoauszug.TabIndex = 0;
            this.grdKontoauszug.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchungKostenartBrutto,
            this.grvDetail});
            // 
            // qryKontoauszug
            // 
            this.qryKontoauszug.BatchUpdate = true;
            this.qryKontoauszug.HostControl = this;
            this.qryKontoauszug.AfterFill += new System.EventHandler(this.qryKontoauszug_AfterFill);
            this.qryKontoauszug.PositionChanged += new System.EventHandler(this.qryKontoauszug_PositionChanged);
            // 
            // grvKbBuchungKostenartBrutto
            // 
            this.grvKbBuchungKostenartBrutto.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchungKostenartBrutto.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKbBuchungKostenartBrutto.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grvKbBuchungKostenartBrutto.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grvKbBuchungKostenartBrutto.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvKbBuchungKostenartBrutto.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.grvKbBuchungKostenartBrutto.Appearance.FooterPanel.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvKbBuchungKostenartBrutto.Appearance.GroupFooter.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenartBrutto.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenartBrutto.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenartBrutto.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenartBrutto.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungKostenartBrutto.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenartBrutto.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungKostenartBrutto.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungKostenartBrutto.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchungKostenartBrutto.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenartBrutto.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchungKostenartBrutto.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungKostenartBrutto.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenartBrutto.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungKostenartBrutto.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchungKostenartBrutto.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungKostenartBrutto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerwPeriodeVon,
            this.colVerwPerioedBis,
            this.gridColumnEffektivesZahldatum,
            this.gridColumnAnzahlAuszahlbelege,
            this.gridColumnBudgetId,
            this.colLA,
            this.colSplitting,
            this.colBuchungstext,
            this.colKlient,
            this.colEinnahme,
            this.colAusgabe,
            this.colSaldo,
            this.colSD,
            this.colDritte,
            this.colBar,
            this.colDoc,
            this.colValuta,
            this.colStatus,
            this.colMahnstufe,
            this.gridColumnBruttoBeleg,
            this.colRechnungsnummer});
            this.grvKbBuchungKostenartBrutto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Brown;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.Column = this.colSaldo;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Tag = "";
            styleFormatCondition1.Value1 = "Saldo";
            this.grvKbBuchungKostenartBrutto.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grvKbBuchungKostenartBrutto.GridControl = this.grdKontoauszug;
            this.grvKbBuchungKostenartBrutto.Name = "grvKbBuchungKostenartBrutto";
            this.grvKbBuchungKostenartBrutto.OptionsBehavior.Editable = false;
            this.grvKbBuchungKostenartBrutto.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungKostenartBrutto.OptionsDetail.ShowDetailTabs = false;
            this.grvKbBuchungKostenartBrutto.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungKostenartBrutto.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungKostenartBrutto.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungKostenartBrutto.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungKostenartBrutto.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvKbBuchungKostenartBrutto.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchungKostenartBrutto.OptionsView.ShowFooter = true;
            this.grvKbBuchungKostenartBrutto.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungKostenartBrutto.OptionsView.ShowIndicator = false;
            // 
            // colVerwPeriodeVon
            // 
            this.colVerwPeriodeVon.Caption = "Verw. von";
            this.colVerwPeriodeVon.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colVerwPeriodeVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVon.Name = "colVerwPeriodeVon";
            this.colVerwPeriodeVon.Visible = true;
            this.colVerwPeriodeVon.VisibleIndex = 0;
            this.colVerwPeriodeVon.Width = 83;
            // 
            // colVerwPerioedBis
            // 
            this.colVerwPerioedBis.Caption = "Verw. bis";
            this.colVerwPerioedBis.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colVerwPerioedBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVerwPerioedBis.FieldName = "VerwPeriodeBis";
            this.colVerwPerioedBis.Name = "colVerwPerioedBis";
            this.colVerwPerioedBis.Visible = true;
            this.colVerwPerioedBis.VisibleIndex = 1;
            this.colVerwPerioedBis.Width = 70;
            // 
            // gridColumnEffektivesZahldatum
            // 
            this.gridColumnEffektivesZahldatum.Caption = "Eff. Zahldatum";
            this.gridColumnEffektivesZahldatum.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumnEffektivesZahldatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnEffektivesZahldatum.FieldName = "DatumEffektiv";
            this.gridColumnEffektivesZahldatum.Name = "gridColumnEffektivesZahldatum";
            this.gridColumnEffektivesZahldatum.Visible = true;
            this.gridColumnEffektivesZahldatum.VisibleIndex = 2;
            // 
            // gridColumnAnzahlAuszahlbelege
            // 
            this.gridColumnAnzahlAuszahlbelege.Caption = "Bel.";
            this.gridColumnAnzahlAuszahlbelege.FieldName = "AnzahlBelege";
            this.gridColumnAnzahlAuszahlbelege.Name = "gridColumnAnzahlAuszahlbelege";
            this.gridColumnAnzahlAuszahlbelege.Width = 30;
            // 
            // gridColumnBudgetId
            // 
            this.gridColumnBudgetId.Caption = "Budget";
            this.gridColumnBudgetId.FieldName = "BgBudgetName";
            this.gridColumnBudgetId.Name = "gridColumnBudgetId";
            this.gridColumnBudgetId.Visible = true;
            this.gridColumnBudgetId.VisibleIndex = 3;
            this.gridColumnBudgetId.Width = 49;
            // 
            // colLA
            // 
            this.colLA.Caption = "LA";
            this.colLA.FieldName = "LA";
            this.colLA.Name = "colLA";
            this.colLA.Visible = true;
            this.colLA.VisibleIndex = 4;
            this.colLA.Width = 35;
            // 
            // colSplitting
            // 
            this.colSplitting.AppearanceCell.Options.UseTextOptions = true;
            this.colSplitting.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSplitting.AppearanceHeader.Options.UseTextOptions = true;
            this.colSplitting.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSplitting.Caption = "s";
            this.colSplitting.FieldName = "Splitting";
            this.colSplitting.Name = "colSplitting";
            this.colSplitting.Visible = true;
            this.colSplitting.VisibleIndex = 5;
            this.colSplitting.Width = 20;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 6;
            this.colBuchungstext.Width = 123;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 7;
            this.colKlient.Width = 134;
            // 
            // colEinnahme
            // 
            this.colEinnahme.Caption = "Einnahme";
            this.colEinnahme.DisplayFormat.FormatString = "n2";
            this.colEinnahme.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinnahme.FieldName = "Einnahme";
            this.colEinnahme.Name = "colEinnahme";
            this.colEinnahme.SummaryItem.DisplayFormat = "{0:n2}";
            this.colEinnahme.SummaryItem.FieldName = "BetragEinnahme";
            this.colEinnahme.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colEinnahme.Visible = true;
            this.colEinnahme.VisibleIndex = 8;
            this.colEinnahme.Width = 90;
            // 
            // colAusgabe
            // 
            this.colAusgabe.Caption = "Ausgabe";
            this.colAusgabe.DisplayFormat.FormatString = "n2";
            this.colAusgabe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAusgabe.FieldName = "Ausgabe";
            this.colAusgabe.Name = "colAusgabe";
            this.colAusgabe.SummaryItem.DisplayFormat = "{0:n2}";
            this.colAusgabe.SummaryItem.FieldName = "BetragAusgabe";
            this.colAusgabe.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAusgabe.Visible = true;
            this.colAusgabe.VisibleIndex = 9;
            this.colAusgabe.Width = 90;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.SummaryItem.DisplayFormat = "{0:n2}";
            this.colSaldo.SummaryItem.FieldName = "BetragSaldo";
            this.colSaldo.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 10;
            this.colSaldo.Width = 90;
            // 
            // colSD
            // 
            this.colSD.AppearanceCell.Options.UseTextOptions = true;
            this.colSD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSD.AppearanceHeader.Options.UseTextOptions = true;
            this.colSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSD.Caption = "S";
            this.colSD.FieldName = "S";
            this.colSD.Name = "colSD";
            this.colSD.Visible = true;
            this.colSD.VisibleIndex = 11;
            this.colSD.Width = 20;
            // 
            // colDritte
            // 
            this.colDritte.AppearanceCell.Options.UseTextOptions = true;
            this.colDritte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDritte.AppearanceHeader.Options.UseTextOptions = true;
            this.colDritte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDritte.Caption = "D";
            this.colDritte.FieldName = "D";
            this.colDritte.Name = "colDritte";
            this.colDritte.Visible = true;
            this.colDritte.VisibleIndex = 12;
            this.colDritte.Width = 20;
            // 
            // colBar
            // 
            this.colBar.AppearanceCell.Options.UseTextOptions = true;
            this.colBar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBar.AppearanceHeader.Options.UseTextOptions = true;
            this.colBar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBar.Caption = "b";
            this.colBar.FieldName = "Bar";
            this.colBar.Name = "colBar";
            this.colBar.Visible = true;
            this.colBar.VisibleIndex = 13;
            this.colBar.Width = 20;
            // 
            // colDoc
            // 
            this.colDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.Caption = "Dok";
            this.colDoc.FieldName = "Doc";
            this.colDoc.Name = "colDoc";
            this.colDoc.Visible = true;
            this.colDoc.VisibleIndex = 14;
            this.colDoc.Width = 31;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colValuta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 15;
            this.colValuta.Width = 70;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Sta.";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "KbBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 16;
            this.colStatus.Width = 31;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colMahnstufe
            // 
            this.colMahnstufe.Caption = "Ma";
            this.colMahnstufe.FieldName = "Mahnstufe";
            this.colMahnstufe.Name = "colMahnstufe";
            this.colMahnstufe.Visible = true;
            this.colMahnstufe.VisibleIndex = 17;
            this.colMahnstufe.Width = 31;
            // 
            // gridColumnBruttoBeleg
            // 
            this.gridColumnBruttoBeleg.Caption = "Brutto Beleg";
            this.gridColumnBruttoBeleg.FieldName = "BelegNr";
            this.gridColumnBruttoBeleg.Name = "gridColumnBruttoBeleg";
            this.gridColumnBruttoBeleg.Visible = true;
            this.gridColumnBruttoBeleg.VisibleIndex = 18;
            this.gridColumnBruttoBeleg.Width = 90;
            // 
            // colRechnungsnummer
            // 
            this.colRechnungsnummer.Caption = "Rg.Nr.";
            this.colRechnungsnummer.FieldName = "Rechnungsnummer";
            this.colRechnungsnummer.Name = "colRechnungsnummer";
            this.colRechnungsnummer.Visible = true;
            this.colRechnungsnummer.VisibleIndex = 19;
            this.colRechnungsnummer.Width = 100;
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.lblSuchkriterien);
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(902, 30);
            this.panTitel.TabIndex = 0;
            // 
            // lblSuchkriterien
            // 
            this.lblSuchkriterien.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblSuchkriterien.Location = new System.Drawing.Point(223, 6);
            this.lblSuchkriterien.Name = "lblSuchkriterien";
            this.lblSuchkriterien.Size = new System.Drawing.Size(668, 20);
            this.lblSuchkriterien.TabIndex = 2;
            this.lblSuchkriterien.Text = "Suchkriterien";
            this.lblSuchkriterien.UseCompatibleTextRendering = true;
            this.lblSuchkriterien.Visible = false;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 6);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(112, 20);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Kontoauszug";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblKonto
            // 
            this.lblKonto.Location = new System.Drawing.Point(5, 37);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(91, 24);
            this.lblKonto.TabIndex = 1;
            this.lblKonto.Text = "Klient/in";
            this.lblKonto.UseCompatibleTextRendering = true;
            // 
            // edtPerson
            // 
            this.edtPerson.Location = new System.Drawing.Point(101, 36);
            this.edtPerson.Name = "edtPerson";
            this.edtPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPerson.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPerson.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPerson.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NamePerson", "Person", 150),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Beziehung", "Beziehung", 80)});
            this.edtPerson.Properties.DisplayMember = "NamePerson";
            this.edtPerson.Properties.NullText = "";
            this.edtPerson.Properties.ShowFooter = false;
            this.edtPerson.Properties.ShowHeader = false;
            this.edtPerson.Properties.ValueMember = "BaPersonID";
            this.edtPerson.Size = new System.Drawing.Size(255, 24);
            this.edtPerson.TabIndex = 3;
            // 
            // lblZeitraum
            // 
            this.lblZeitraum.Location = new System.Drawing.Point(5, 68);
            this.lblZeitraum.Name = "lblZeitraum";
            this.lblZeitraum.Size = new System.Drawing.Size(93, 24);
            this.lblZeitraum.TabIndex = 4;
            this.lblZeitraum.Text = "Zeitraum";
            this.lblZeitraum.UseCompatibleTextRendering = true;
            // 
            // edtZeitraum
            // 
            this.edtZeitraum.AllowNull = false;
            this.edtZeitraum.Location = new System.Drawing.Point(101, 66);
            this.edtZeitraum.LOVName = "KbKontoZeitraum";
            this.edtZeitraum.Name = "edtZeitraum";
            this.edtZeitraum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraum.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraum.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraum.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZeitraum.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraum.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZeitraum.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZeitraum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtZeitraum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtZeitraum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraum.Properties.NullText = "";
            this.edtZeitraum.Properties.ShowFooter = false;
            this.edtZeitraum.Properties.ShowHeader = false;
            this.edtZeitraum.Size = new System.Drawing.Size(255, 24);
            this.edtZeitraum.TabIndex = 5;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(99, 121);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 6;
            this.edtDatumVon.EditValueChanged += new System.EventHandler(this.edtDatumVon_EditValueChanged);
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(253, 121);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 7;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.Location = new System.Drawing.Point(99, 151);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(254, 24);
            this.edtBuchungstext.TabIndex = 8;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(212, 121);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(22, 24);
            this.lblBis.TabIndex = 8;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // edtVerdichtet
            // 
            this.edtVerdichtet.EditValue = false;
            this.edtVerdichtet.Location = new System.Drawing.Point(471, 40);
            this.edtVerdichtet.Name = "edtVerdichtet";
            this.edtVerdichtet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerdichtet.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerdichtet.Properties.Caption = "verdichtet";
            this.edtVerdichtet.Size = new System.Drawing.Size(73, 19);
            this.edtVerdichtet.TabIndex = 9;
            // 
            // lblVon
            // 
            this.lblVon.Location = new System.Drawing.Point(5, 121);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(68, 24);
            this.lblVon.TabIndex = 9;
            this.lblVon.Text = "Datum von";
            this.lblVon.UseCompatibleTextRendering = true;
            // 
            // edtInklProLeist
            // 
            this.edtInklProLeist.EditValue = false;
            this.edtInklProLeist.Location = new System.Drawing.Point(471, 64);
            this.edtInklProLeist.Name = "edtInklProLeist";
            this.edtInklProLeist.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklProLeist.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklProLeist.Properties.Caption = "inkl. ProLeist-Buchungen";
            this.edtInklProLeist.Size = new System.Drawing.Size(156, 19);
            this.edtInklProLeist.TabIndex = 10;
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Location = new System.Drawing.Point(5, 229);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(93, 24);
            this.lblLeistungsart.TabIndex = 10;
            this.lblLeistungsart.Text = "Leistungsarten";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            // 
            // edtInklVermittlungsfall
            // 
            this.edtInklVermittlungsfall.EditValue = false;
            this.edtInklVermittlungsfall.Location = new System.Drawing.Point(471, 88);
            this.edtInklVermittlungsfall.Name = "edtInklVermittlungsfall";
            this.edtInklVermittlungsfall.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklVermittlungsfall.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklVermittlungsfall.Properties.Caption = "inkl. Vermittlungsfall";
            this.edtInklVermittlungsfall.Size = new System.Drawing.Size(201, 19);
            this.edtInklVermittlungsfall.TabIndex = 11;
            // 
            // edtInklGruen
            // 
            this.edtInklGruen.EditValue = false;
            this.edtInklGruen.Location = new System.Drawing.Point(471, 112);
            this.edtInklGruen.Name = "edtInklGruen";
            this.edtInklGruen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklGruen.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklGruen.Properties.Caption = "inkl. freigegebene Positionen (grün, Zahlauftrag erstellt/fehlerhaft)";
            this.edtInklGruen.Size = new System.Drawing.Size(409, 19);
            this.edtInklGruen.TabIndex = 12;
            // 
            // edtInklRot
            // 
            this.edtInklRot.EditValue = false;
            this.edtInklRot.Location = new System.Drawing.Point(471, 136);
            this.edtInklRot.Name = "edtInklRot";
            this.edtInklRot.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklRot.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklRot.Properties.Caption = "inkl. gesperrte Positionen (rot)";
            this.edtInklRot.Size = new System.Drawing.Size(201, 19);
            this.edtInklRot.TabIndex = 13;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(360, 35);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(92, 24);
            this.kissLabel2.TabIndex = 24;
            this.kissLabel2.Text = "(leer = ganze UE)";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(417, 206);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(144, 24);
            this.kissLabel4.TabIndex = 27;
            this.kissLabel4.Text = "(leer = alle Leistungsarten)";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(5, 151);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(84, 24);
            this.kissLabel11.TabIndex = 34;
            this.kissLabel11.Text = "Buchungstext";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // edtExklWV
            // 
            this.edtExklWV.EditValue = true;
            this.edtExklWV.Location = new System.Drawing.Point(99, 181);
            this.edtExklWV.Name = "edtExklWV";
            this.edtExklWV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtExklWV.Properties.Appearance.Options.UseBackColor = true;
            this.edtExklWV.Properties.Caption = "exkl. Leistungsarten WV, VU/UB";
            this.edtExklWV.Size = new System.Drawing.Size(201, 19);
            this.edtExklWV.TabIndex = 35;
            this.edtExklWV.EditValueChanged += new System.EventHandler(this.edtExklWV_EditValueChanged);
            // 
            // edtInklStorno
            // 
            this.edtInklStorno.EditValue = false;
            this.edtInklStorno.Location = new System.Drawing.Point(471, 161);
            this.edtInklStorno.Name = "edtInklStorno";
            this.edtInklStorno.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklStorno.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklStorno.Properties.Caption = "inkl. stornierter Positionen";
            this.edtInklStorno.Size = new System.Drawing.Size(201, 19);
            this.edtInklStorno.TabIndex = 35;
            // 
            // edtStichtag
            // 
            this.edtStichtag.EditValue = false;
            this.edtStichtag.Location = new System.Drawing.Point(99, 96);
            this.edtStichtag.Name = "edtStichtag";
            this.edtStichtag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStichtag.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichtag.Properties.Caption = "Stichtag";
            this.edtStichtag.Size = new System.Drawing.Size(201, 19);
            this.edtStichtag.TabIndex = 36;
            this.edtStichtag.Click += new System.EventHandler(this.edtStichtag_Click);
            // 
            // kissTabControlEx1
            // 
            this.kissTabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTabControlEx1.Controls.Add(this.tpgDokumente);
            this.kissTabControlEx1.Controls.Add(this.tpgBuchung);
            this.kissTabControlEx1.Location = new System.Drawing.Point(3, 568);
            this.kissTabControlEx1.Name = "kissTabControlEx1";
            this.kissTabControlEx1.SelectedTabIndex = 1;
            this.kissTabControlEx1.ShowFixedWidthTooltip = true;
            this.kissTabControlEx1.Size = new System.Drawing.Size(844, 215);
            this.kissTabControlEx1.TabIndex = 12;
            this.kissTabControlEx1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBuchung,
            this.tpgDokumente});
            this.kissTabControlEx1.TabsLineColor = System.Drawing.Color.Black;
            this.kissTabControlEx1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.kissTabControlEx1.Text = "kissTabControlEx1";
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.grdDoc);
            this.tpgDokumente.Controls.Add(this.edtDocument);
            this.tpgDokumente.Controls.Add(this.lblDokument);
            this.tpgDokumente.Controls.Add(this.edtDokumentTyp);
            this.tpgDokumente.Controls.Add(this.lblDokumentTyp);
            this.tpgDokumente.Controls.Add(this.edtStichwort);
            this.tpgDokumente.Controls.Add(this.lblStichwort);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(832, 177);
            this.tpgDokumente.TabIndex = 1;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDoc.DataSource = this.qryBgDokumente;
            // 
            // 
            // 
            this.grdDoc.EmbeddedNavigator.Name = "";
            this.grdDoc.Location = new System.Drawing.Point(0, 0);
            this.grdDoc.MainView = this.gridView1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.Size = new System.Drawing.Size(773, 145);
            this.grdDoc.TabIndex = 20;
            this.grdDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryBgDokumente
            // 
            this.qryBgDokumente.HostControl = this;
            this.qryBgDokumente.SelectStatement = resources.GetString("qryBgDokumente.SelectStatement");
            this.qryBgDokumente.TableName = "BgDokument";
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTyp,
            this.colStichwort,
            this.colDateCreation,
            this.colDateLastSave});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdDoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "BgDokumentTypCode";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 0;
            this.colTyp.Width = 150;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 1;
            this.colStichwort.Width = 382;
            // 
            // colDateCreation
            // 
            this.colDateCreation.Caption = "Erstellungsdatum";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 2;
            this.colDateCreation.Width = 110;
            // 
            // colDateLastSave
            // 
            this.colDateLastSave.Caption = "Letzte Speicherung";
            this.colDateLastSave.FieldName = "DateLastSave";
            this.colDateLastSave.Name = "colDateLastSave";
            this.colDateLastSave.Visible = true;
            this.colDateLastSave.VisibleIndex = 3;
            this.colDateLastSave.Width = 121;
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocument.Context = null;
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryBgDokumente;
            this.edtDocument.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDocument.Location = new System.Drawing.Point(652, 151);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(120, 24);
            this.edtDocument.TabIndex = 19;
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokument.Location = new System.Drawing.Point(587, 151);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(59, 24);
            this.lblDokument.TabIndex = 18;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // edtDokumentTyp
            // 
            this.edtDokumentTyp.AllowNull = false;
            this.edtDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokumentTyp.DataMember = "BgDokumentTypCode";
            this.edtDokumentTyp.DataSource = this.qryBgDokumente;
            this.edtDokumentTyp.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDokumentTyp.Location = new System.Drawing.Point(39, 151);
            this.edtDokumentTyp.LOVName = "BgDokumentTyp";
            this.edtDokumentTyp.Name = "edtDokumentTyp";
            this.edtDokumentTyp.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDokumentTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentTyp.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDokumentTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDokumentTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDokumentTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentTyp.Properties.NullText = "";
            this.edtDokumentTyp.Properties.ReadOnly = true;
            this.edtDokumentTyp.Properties.ShowFooter = false;
            this.edtDokumentTyp.Properties.ShowHeader = false;
            this.edtDokumentTyp.Size = new System.Drawing.Size(162, 24);
            this.edtDokumentTyp.TabIndex = 17;
            // 
            // lblDokumentTyp
            // 
            this.lblDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumentTyp.Location = new System.Drawing.Point(5, 151);
            this.lblDokumentTyp.Name = "lblDokumentTyp";
            this.lblDokumentTyp.Size = new System.Drawing.Size(28, 24);
            this.lblDokumentTyp.TabIndex = 16;
            this.lblDokumentTyp.Text = "Typ";
            this.lblDokumentTyp.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryBgDokumente;
            this.edtStichwort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStichwort.Location = new System.Drawing.Point(267, 151);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Properties.ReadOnly = true;
            this.edtStichwort.Size = new System.Drawing.Size(317, 24);
            this.edtStichwort.TabIndex = 15;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(206, 151);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(66, 24);
            this.lblStichwort.TabIndex = 14;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // tpgBuchung
            // 
            this.tpgBuchung.Controls.Add(this.btnBudgetPosition);
            this.tpgBuchung.Controls.Add(this.kissDateEdit1);
            this.tpgBuchung.Controls.Add(this.kissLabel9);
            this.tpgBuchung.Controls.Add(this.lblKreditor);
            this.tpgBuchung.Controls.Add(this.kissLabel7);
            this.tpgBuchung.Controls.Add(this.edtBetrag100);
            this.tpgBuchung.Controls.Add(this.kissLabel5);
            this.tpgBuchung.Controls.Add(this.kissTextEdit7);
            this.tpgBuchung.Controls.Add(this.kissTextEdit4);
            this.tpgBuchung.Controls.Add(this.edtBgSplittingCode);
            this.tpgBuchung.Controls.Add(this.lblBgSplittingCode);
            this.tpgBuchung.Controls.Add(this.edtVerwPeriodeBis);
            this.tpgBuchung.Controls.Add(this.lblVerwPeriodeStrich);
            this.tpgBuchung.Controls.Add(this.edtVerwPeriodeVon);
            this.tpgBuchung.Controls.Add(this.lblVerwPeriode);
            this.tpgBuchung.Controls.Add(this.kissTextEdit1);
            this.tpgBuchung.Controls.Add(this.kissTextEdit2);
            this.tpgBuchung.Controls.Add(this.lblMandant);
            this.tpgBuchung.Controls.Add(this.lblErfassungDatum);
            this.tpgBuchung.Controls.Add(this.lblBuchungstext);
            this.tpgBuchung.Controls.Add(this.edtBaPersonID);
            this.tpgBuchung.Controls.Add(this.edtKreditor);
            this.tpgBuchung.Controls.Add(this.kissTextEdit3);
            this.tpgBuchung.Controls.Add(this.kissLabel6);
            this.tpgBuchung.Controls.Add(this.kissLabel3);
            this.tpgBuchung.Controls.Add(this.edtBuchungstext2);
            this.tpgBuchung.Location = new System.Drawing.Point(6, 6);
            this.tpgBuchung.Name = "tpgBuchung";
            this.tpgBuchung.Size = new System.Drawing.Size(832, 177);
            this.tpgBuchung.TabIndex = 0;
            this.tpgBuchung.Title = "Buchung";
            // 
            // btnBudgetPosition
            // 
            this.btnBudgetPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudgetPosition.Location = new System.Drawing.Point(695, 5);
            this.btnBudgetPosition.Name = "btnBudgetPosition";
            this.btnBudgetPosition.Size = new System.Drawing.Size(129, 24);
            this.btnBudgetPosition.TabIndex = 418;
            this.btnBudgetPosition.Text = "> Budgetposition";
            this.btnBudgetPosition.UseCompatibleTextRendering = true;
            this.btnBudgetPosition.UseVisualStyleBackColor = false;
            this.btnBudgetPosition.Click += new System.EventHandler(this.btnBudgetPosition_Click);
            // 
            // kissDateEdit1
            // 
            this.kissDateEdit1.DataMember = "ValutaDatum";
            this.kissDateEdit1.DataSource = this.qryKontoauszug;
            this.kissDateEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit1.EditValue = null;
            this.kissDateEdit1.Location = new System.Drawing.Point(93, 88);
            this.kissDateEdit1.Name = "kissDateEdit1";
            this.kissDateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.kissDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit1.Properties.ReadOnly = true;
            this.kissDateEdit1.Properties.ShowToday = false;
            this.kissDateEdit1.Size = new System.Drawing.Size(90, 24);
            this.kissDateEdit1.TabIndex = 417;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(5, 88);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(86, 24);
            this.kissLabel9.TabIndex = 416;
            this.kissLabel9.Text = "Valuta";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // lblKreditor
            // 
            this.lblKreditor.Location = new System.Drawing.Point(473, 59);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(49, 24);
            this.lblKreditor.TabIndex = 415;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(473, 35);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(73, 24);
            this.kissLabel7.TabIndex = 414;
            this.kissLabel7.Text = "Auszahlart";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // edtBetrag100
            // 
            this.edtBetrag100.DataMember = "Betrag100";
            this.edtBetrag100.DataSource = this.qryKontoauszug;
            this.edtBetrag100.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag100.Location = new System.Drawing.Point(552, 5);
            this.edtBetrag100.Name = "edtBetrag100";
            this.edtBetrag100.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag100.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrag100.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag100.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag100.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag100.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag100.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag100.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag100.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag100.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag100.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag100.Properties.ReadOnly = true;
            this.edtBetrag100.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag100.TabIndex = 413;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(473, 5);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(73, 24);
            this.kissLabel5.TabIndex = 412;
            this.kissLabel5.Text = "Betrag 100%";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit7
            // 
            this.kissTextEdit7.DataMember = "ProLeistText";
            this.kissTextEdit7.DataSource = this.qryKontoauszug;
            this.kissTextEdit7.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit7.Location = new System.Drawing.Point(93, 148);
            this.kissTextEdit7.Name = "kissTextEdit7";
            this.kissTextEdit7.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit7.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit7.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit7.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit7.Properties.ReadOnly = true;
            this.kissTextEdit7.Size = new System.Drawing.Size(374, 24);
            this.kissTextEdit7.TabIndex = 411;
            // 
            // kissTextEdit4
            // 
            this.kissTextEdit4.DataMember = "BelegNr";
            this.kissTextEdit4.DataSource = this.qryKontoauszug;
            this.kissTextEdit4.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit4.Location = new System.Drawing.Point(354, 88);
            this.kissTextEdit4.Name = "kissTextEdit4";
            this.kissTextEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit4.Properties.ReadOnly = true;
            this.kissTextEdit4.Size = new System.Drawing.Size(113, 24);
            this.kissTextEdit4.TabIndex = 408;
            // 
            // edtBgSplittingCode
            // 
            this.edtBgSplittingCode.AllowNull = false;
            this.edtBgSplittingCode.DataMember = "BgSplittingArtCode";
            this.edtBgSplittingCode.DataSource = this.qryKontoauszug;
            this.edtBgSplittingCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgSplittingCode.Location = new System.Drawing.Point(354, 118);
            this.edtBgSplittingCode.LOVName = "BgSplittingArt";
            this.edtBgSplittingCode.Name = "edtBgSplittingCode";
            this.edtBgSplittingCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgSplittingCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSplittingCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgSplittingCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSplittingCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgSplittingCode.Properties.DisplayMember = "Text";
            this.edtBgSplittingCode.Properties.NullText = "";
            this.edtBgSplittingCode.Properties.ReadOnly = true;
            this.edtBgSplittingCode.Properties.ShowFooter = false;
            this.edtBgSplittingCode.Properties.ShowHeader = false;
            this.edtBgSplittingCode.Properties.ValueMember = "Code";
            this.edtBgSplittingCode.Size = new System.Drawing.Size(113, 24);
            this.edtBgSplittingCode.TabIndex = 407;
            this.edtBgSplittingCode.TabStop = false;
            // 
            // lblBgSplittingCode
            // 
            this.lblBgSplittingCode.Location = new System.Drawing.Point(300, 118);
            this.lblBgSplittingCode.Name = "lblBgSplittingCode";
            this.lblBgSplittingCode.Size = new System.Drawing.Size(49, 24);
            this.lblBgSplittingCode.TabIndex = 406;
            this.lblBgSplittingCode.Text = "Splitting";
            this.lblBgSplittingCode.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeBis
            // 
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryKontoauszug;
            this.edtVerwPeriodeBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(199, 118);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ReadOnly = true;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeBis.TabIndex = 405;
            // 
            // lblVerwPeriodeStrich
            // 
            this.lblVerwPeriodeStrich.Location = new System.Drawing.Point(188, 118);
            this.lblVerwPeriodeStrich.Name = "lblVerwPeriodeStrich";
            this.lblVerwPeriodeStrich.Size = new System.Drawing.Size(7, 24);
            this.lblVerwPeriodeStrich.TabIndex = 404;
            this.lblVerwPeriodeStrich.Text = "-";
            this.lblVerwPeriodeStrich.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeVon
            // 
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryKontoauszug;
            this.edtVerwPeriodeVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(93, 118);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ReadOnly = true;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeVon.TabIndex = 403;
            // 
            // lblVerwPeriode
            // 
            this.lblVerwPeriode.Location = new System.Drawing.Point(5, 118);
            this.lblVerwPeriode.Name = "lblVerwPeriode";
            this.lblVerwPeriode.Size = new System.Drawing.Size(86, 24);
            this.lblVerwPeriode.TabIndex = 402;
            this.lblVerwPeriode.Text = "Verwendungsp.";
            this.lblVerwPeriode.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.DataMember = "LAText";
            this.kissTextEdit1.DataSource = this.qryKontoauszug;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(93, 35);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(374, 24);
            this.kissTextEdit1.TabIndex = 401;
            // 
            // kissTextEdit2
            // 
            this.kissTextEdit2.DataMember = "Klient";
            this.kissTextEdit2.DataSource = this.qryKontoauszug;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(93, 5);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(305, 24);
            this.kissTextEdit2.TabIndex = 394;
            // 
            // lblMandant
            // 
            this.lblMandant.Location = new System.Drawing.Point(5, 5);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(52, 24);
            this.lblMandant.TabIndex = 383;
            this.lblMandant.Text = "Klient/in";
            this.lblMandant.UseCompatibleTextRendering = true;
            // 
            // lblErfassungDatum
            // 
            this.lblErfassungDatum.Location = new System.Drawing.Point(299, 88);
            this.lblErfassungDatum.Name = "lblErfassungDatum";
            this.lblErfassungDatum.Size = new System.Drawing.Size(50, 24);
            this.lblErfassungDatum.TabIndex = 61;
            this.lblErfassungDatum.Text = "Beleg-Nr";
            this.lblErfassungDatum.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(5, 58);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(75, 24);
            this.lblBuchungstext.TabIndex = 53;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryKontoauszug;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(397, 5);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Name = "editMandantNr.Properties";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(70, 24);
            this.edtBaPersonID.TabIndex = 10;
            // 
            // edtKreditor
            // 
            this.edtKreditor.DataMember = "KreditorDebitor";
            this.edtKreditor.DataSource = this.qryKontoauszug;
            this.edtKreditor.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditor.Location = new System.Drawing.Point(552, 58);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditor.Properties.ReadOnly = true;
            this.edtKreditor.Size = new System.Drawing.Size(272, 114);
            this.edtKreditor.TabIndex = 9;
            // 
            // kissTextEdit3
            // 
            this.kissTextEdit3.DataMember = "Auszahlart";
            this.kissTextEdit3.DataSource = this.qryKontoauszug;
            this.kissTextEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit3.Location = new System.Drawing.Point(552, 35);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Properties.ReadOnly = true;
            this.kissTextEdit3.Size = new System.Drawing.Size(272, 24);
            this.kissTextEdit3.TabIndex = 8;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(5, 148);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(52, 24);
            this.kissLabel6.TabIndex = 7;
            this.kissLabel6.Text = "ProLeist";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(5, 35);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(76, 24);
            this.kissLabel3.TabIndex = 4;
            this.kissLabel3.Text = "LA";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // edtBuchungstext2
            // 
            this.edtBuchungstext2.DataMember = "Buchungstext";
            this.edtBuchungstext2.DataSource = this.qryKontoauszug;
            this.edtBuchungstext2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchungstext2.Location = new System.Drawing.Point(93, 58);
            this.edtBuchungstext2.Name = "edtBuchungstext2";
            this.edtBuchungstext2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchungstext2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext2.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext2.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext2.Properties.ReadOnly = true;
            this.edtBuchungstext2.Size = new System.Drawing.Size(374, 24);
            this.edtBuchungstext2.TabIndex = 2;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel10.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel10.Location = new System.Drawing.Point(112, 533);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(309, 16);
            this.kissLabel10.TabIndex = 13;
            this.kissLabel10.Text = "s = splitting, S = abgetreten an SoD, D = Dritte, b = bar";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // btnWordDrucken
            // 
            this.btnWordDrucken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWordDrucken.Context = "WhKontoauszug";
            this.btnWordDrucken.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnWordDrucken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWordDrucken.Image = ((System.Drawing.Image)(resources.GetObject("btnWordDrucken.Image")));
            this.btnWordDrucken.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWordDrucken.Location = new System.Drawing.Point(699, 533);
            this.btnWordDrucken.Name = "btnWordDrucken";
            this.btnWordDrucken.Size = new System.Drawing.Size(129, 24);
            this.btnWordDrucken.TabIndex = 39;
            this.btnWordDrucken.Text = "Drucken";
            this.btnWordDrucken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWordDrucken.UseCompatibleTextRendering = true;
            this.btnWordDrucken.UseVisualStyleBackColor = false;
            // 
            // btnAuswahlKlientenkontoabrechnung
            // 
            this.btnAuswahlKlientenkontoabrechnung.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAuswahlKlientenkontoabrechnung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuswahlKlientenkontoabrechnung.Location = new System.Drawing.Point(99, 449);
            this.btnAuswahlKlientenkontoabrechnung.Name = "btnAuswahlKlientenkontoabrechnung";
            this.btnAuswahlKlientenkontoabrechnung.Size = new System.Drawing.Size(211, 24);
            this.btnAuswahlKlientenkontoabrechnung.TabIndex = 37;
            this.btnAuswahlKlientenkontoabrechnung.Text = "Auswahl Klientenkontoabrechnung";
            this.btnAuswahlKlientenkontoabrechnung.UseCompatibleTextRendering = true;
            this.btnAuswahlKlientenkontoabrechnung.UseVisualStyleBackColor = false;
            this.btnAuswahlKlientenkontoabrechnung.Click += new System.EventHandler(this.btnAuswahlKlientenkontoabrechnung_Click);
            // 
            // multiSelectListboxes
            // 
            this.multiSelectListboxes.ButtonRemoveAllVisible = true;
            this.multiSelectListboxes.Location = new System.Drawing.Point(99, 229);
            this.multiSelectListboxes.MaximumSize = new System.Drawing.Size(580, 210);
            this.multiSelectListboxes.MinimumSize = new System.Drawing.Size(580, 210);
            this.multiSelectListboxes.Name = "multiSelectListboxes";
            this.multiSelectListboxes.Size = new System.Drawing.Size(580, 210);
            this.multiSelectListboxes.TabIndex = 38;
            // 
            // CtlWhKontoauszug
            // 
            this.ActiveSQLQuery = this.qryKontoauszug;
            this.AutoRefresh = false;
            this.Controls.Add(this.btnWordDrucken);
            this.Controls.Add(this.kissLabel10);
            this.Controls.Add(this.kissTabControlEx1);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlWhKontoauszug";
            this.Size = new System.Drawing.Size(902, 783);
            this.Load += new System.EventHandler(this.CtlWhKontoauszug_Load);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.kissTabControlEx1, 0);
            this.Controls.SetChildIndex(this.kissLabel10, 0);
            this.Controls.SetChildIndex(this.btnWordDrucken, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoauszug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoauszug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenartBrutto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchkriterien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerdichtet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklProLeist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklVermittlungsfall.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklGruen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklRot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExklWV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklStorno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).EndInit();
            this.kissTabControlEx1.ResumeLayout(false);
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            this.tpgBuchung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag100.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnBudgetPosition;
        private KiSS4.Dokument.KissDocumentButton btnWordDrucken;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgabe;
        private DevExpress.XtraGrid.Columns.GridColumn colBar;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDritte;
        private DevExpress.XtraGrid.Columns.GridColumn colEinnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungsDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKlientDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colLA;
        private DevExpress.XtraGrid.Columns.GridColumn colMahnstufe;
        private DevExpress.XtraGrid.Columns.GridColumn colSD;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colSplitting;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBisDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVonDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPerioedBis;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissCalcEdit edtBetrag100;
        private KiSS4.Gui.KissLookUpEdit edtBgSplittingCode;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissTextEdit edtBuchungstext2;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Dokument.XDokument edtDocument;
        private KiSS4.Gui.KissLookUpEdit edtDokumentTyp;
        private KiSS4.Gui.KissCheckEdit edtExklWV;
        private KiSS4.Gui.KissCheckEdit edtInklGruen;
        private KiSS4.Gui.KissCheckEdit edtInklProLeist;
        private KiSS4.Gui.KissCheckEdit edtInklRot;
        private KiSS4.Gui.KissCheckEdit edtInklStorno;
        private KiSS4.Gui.KissCheckEdit edtInklVermittlungsfall;
        private KiSS4.Gui.KissMemoEdit edtKreditor;
        private KiSS4.Gui.KissLookUpEdit edtPerson;
        private KiSS4.Gui.KissCheckEdit edtStichtag;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissCheckEdit edtVerdichtet;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissLookUpEdit edtZeitraum;
        private KiSS4.Gui.KissGrid grdDoc;
        private KiSS4.Gui.KissGrid grdKontoauszug;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAnzahlAuszahlbelege;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBruttoBeleg;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBudgetId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEffektivesZahldatum;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungKostenartBrutto;
        private KiSS4.Gui.KissDateEdit kissDateEdit1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissTabControlEx kissTabControlEx1;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissTextEdit kissTextEdit4;
        private KiSS4.Gui.KissTextEdit kissTextEdit7;
        private KiSS4.Gui.KissLabel lblBgSplittingCode;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblDokumentTyp;
        private KiSS4.Gui.KissLabel lblErfassungDatum;
        private KiSS4.Gui.KissLabel lblKonto;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblLeistungsart;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblSuchkriterien;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVerwPeriode;
        private KiSS4.Gui.KissLabel lblVerwPeriodeStrich;
        private KiSS4.Gui.KissLabel lblVon;
        private KiSS4.Gui.KissLabel lblZeitraum;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgDokumente;
        private KiSS4.DB.SqlQuery qryKontoauszug;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private SharpLibrary.WinControls.TabPageEx tpgBuchung;
        private KiSS4.Gui.KissButton btnAuswahlKlientenkontoabrechnung;
        private KiSS4.Gui.KissDoubleListSelector multiSelectListboxes;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private DevExpress.XtraGrid.Columns.GridColumn colRechnungsnummer;
    }
}
