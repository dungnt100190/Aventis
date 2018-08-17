namespace KiSS4.Vormundschaft.ZH
{
    partial class CtlKgEinzelzahlungen
    {
        #region Dispose

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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKgEinzelzahlungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdEinzelzahlung = new KiSS4.Gui.KissGrid();
            this.qryKgPosition = new KiSS4.DB.SqlQuery();
            this.grvEinzelzahlung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.edtSucheErfassungMA = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheErfassungVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtSucheErfassungBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtSucheMutationMA = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.edtSucheMutationVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheMutationBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheStatus = new KiSS4.Gui.KissImageComboBoxEdit();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.tabKgPosition = new KiSS4.Gui.KissTabControlEx();
            this.tpgEinzelzahlung = new SharpLibrary.WinControls.TabPageEx();
            this.splitterTreeControl = new KiSS4.Gui.KissSplitterCollapsible();
            this.grbAusgaben = new KiSS4.Gui.KissGroupBox();
            this.grdBetragsgleicheAusgaben = new KiSS4.Gui.KissGrid();
            this.qryKgBuchung = new KiSS4.DB.SqlQuery();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchungsdatum2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosStatus2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.panPickerButton = new System.Windows.Forms.Panel();
            this.edtBuchungstext = new KiSS4.Gui.KissComboBox();
            this.lblFreigabeInhalt = new KiSS4.Gui.KissLabel();
            this.lblFreigabeAnzeige = new KiSS4.Gui.KissLabel();
            this.btnDocument = new KiSS4.Gui.KissButton();
            this.edtZusatzInfo = new KiSS4.Gui.KissMemoEdit();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.edtErfassungDatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtMandant = new KiSS4.Gui.KissButtonEdit();
            this.lblZahlungsgrund = new KiSS4.Gui.KissLabel();
            this.edtKonto = new KiSS4.Gui.KissButtonEdit();
            this.lblReferenzNummer = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.grdMonatsbudget = new KiSS4.Gui.KissGrid();
            this.qryMonatsbudget = new KiSS4.DB.SqlQuery();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colAnzEZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtKreditor = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtMitteilungZeile1 = new KiSS4.Gui.KissTextEdit();
            this.lblKonto = new KiSS4.Gui.KissLabel();
            this.edtMitteilungZeile2 = new KiSS4.Gui.KissTextEdit();
            this.label10 = new KiSS4.Gui.KissLabel();
            this.edtMitteilungZeile3 = new KiSS4.Gui.KissTextEdit();
            this.label1 = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.lblErfassungDatum = new KiSS4.Gui.KissLabel();
            this.edtAdresse = new KiSS4.Gui.KissTextEdit();
            this.ctlErfassungMutation1 = new KiSS4.Common.CtlErfassungMutation();
            this.edtMT = new KiSS4.Gui.KissTextEdit();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.lblDokumentTyp = new KiSS4.Gui.KissLabel();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.qryKgDokumente = new KiSS4.DB.SqlQuery();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtDokumentTyp = new KiSS4.Gui.KissLookUpEdit();
            this.grdDoc = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgVerlauf = new SharpLibrary.WinControls.TabPageEx();
            this.edtSAR = new KiSS4.Gui.KissTextEdit();
            this.qryKgBewilligung = new KiSS4.DB.SqlQuery();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.grdBewilligung = new KiSS4.Gui.KissGrid();
            this.grvBewilligung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKgBewilligungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHerkunft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEinzelzahlungenGruenstellen = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.lblFortschritt = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryBaZahlwegCheck = new KiSS4.DB.SqlQuery();
            this.btnPositionenLoeschen = new KiSS4.Gui.KissButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            this.tabKgPosition.SuspendLayout();
            this.tpgEinzelzahlung.SuspendLayout();
            this.grbAusgaben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetragsgleicheAusgaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            this.panPickerButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFreigabeInhalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFreigabeAnzeige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMT.Properties)).BeginInit();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpgVerlauf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFortschritt)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlwegCheck)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(855, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(3, 30);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(879, 254);
            this.tabControlSearch.TabIndex = 1;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdEinzelzahlung);
            this.tpgListe.Size = new System.Drawing.Size(867, 216);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Controls.Add(this.edtSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaBis);
            this.tpgSuchen.Controls.Add(this.kissLabel9);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaVon);
            this.tpgSuchen.Controls.Add(this.kissLabel8);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationBis);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationVon);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationMA);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungBis);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungVon);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungMA);
            this.tpgSuchen.Size = new System.Drawing.Size(867, 216);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel6, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel8, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel9, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel7, 0);
            // 
            // grdEinzelzahlung
            // 
            this.grdEinzelzahlung.DataSource = this.qryKgPosition;
            this.grdEinzelzahlung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdEinzelzahlung.EmbeddedNavigator.Name = "";
            this.grdEinzelzahlung.Location = new System.Drawing.Point(0, 0);
            this.grdEinzelzahlung.MainView = this.grvEinzelzahlung;
            this.grdEinzelzahlung.Name = "grdEinzelzahlung";
            this.grdEinzelzahlung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1});
            this.grdEinzelzahlung.Size = new System.Drawing.Size(867, 216);
            this.grdEinzelzahlung.TabIndex = 0;
            this.grdEinzelzahlung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinzelzahlung});
            // 
            // qryKgPosition
            // 
            this.qryKgPosition.CanDelete = true;
            this.qryKgPosition.CanInsert = true;
            this.qryKgPosition.CanUpdate = true;
            this.qryKgPosition.DeleteQuestion = "Soll die Position gelöscht werden ?";
            this.qryKgPosition.HostControl = this;
            this.qryKgPosition.SelectStatement = resources.GetString("qryKgPosition.SelectStatement");
            this.qryKgPosition.TableName = "KgPosition";
            this.qryKgPosition.AfterInsert += new System.EventHandler(this.qryKgPosition_AfterInsert);
            this.qryKgPosition.AfterPost += new System.EventHandler(this.qryKgPosition_AfterPost);
            this.qryKgPosition.BeforeDelete += new System.EventHandler(this.qryKgPosition_BeforeDelete);
            this.qryKgPosition.BeforePost += new System.EventHandler(this.qryKgPosition_BeforePost);
            this.qryKgPosition.PositionChanged += new System.EventHandler(this.qryKgPosition_PositionChanged);
            this.qryKgPosition.PositionChanging += new System.EventHandler(this.qryKgPosition_PositionChanging);
            this.qryKgPosition.PostCompleted += new System.EventHandler(this.qryKgPosition_PostCompleted);
            // 
            // grvEinzelzahlung
            // 
            this.grvEinzelzahlung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEinzelzahlung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.Empty.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.Empty.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.EvenRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinzelzahlung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEinzelzahlung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinzelzahlung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEinzelzahlung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinzelzahlung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinzelzahlung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinzelzahlung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.GroupRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEinzelzahlung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEinzelzahlung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEinzelzahlung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinzelzahlung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.OddRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinzelzahlung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.Row.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.Row.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinzelzahlung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEinzelzahlung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEinzelzahlung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchung,
            this.colValuta,
            this.colMandant,
            this.colKonto,
            this.colBuchungstext,
            this.colBetrag,
            this.colKreditor,
            this.colDoc,
            this.colMA,
            this.colPosStatus,
            this.colSelektion});
            this.grvEinzelzahlung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEinzelzahlung.GridControl = this.grdEinzelzahlung;
            this.grvEinzelzahlung.Name = "grvEinzelzahlung";
            this.grvEinzelzahlung.OptionsCustomization.AllowFilter = false;
            this.grvEinzelzahlung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEinzelzahlung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEinzelzahlung.OptionsNavigation.UseTabKey = false;
            this.grvEinzelzahlung.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvEinzelzahlung.OptionsView.ColumnAutoWidth = false;
            this.grvEinzelzahlung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEinzelzahlung.OptionsView.ShowGroupPanel = false;
            this.grvEinzelzahlung.OptionsView.ShowIndicator = false;
            // 
            // colBuchung
            // 
            this.colBuchung.Caption = "Buchung";
            this.colBuchung.FieldName = "BuchungDatum";
            this.colBuchung.Name = "colBuchung";
            this.colBuchung.OptionsColumn.AllowEdit = false;
            this.colBuchung.OptionsColumn.ReadOnly = true;
            this.colBuchung.Visible = true;
            this.colBuchung.VisibleIndex = 0;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.OptionsColumn.ReadOnly = true;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 1;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Person m. zivilr. Massn.";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.OptionsColumn.AllowEdit = false;
            this.colMandant.OptionsColumn.ReadOnly = true;
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 2;
            this.colMandant.Width = 119;
            // 
            // colKonto
            // 
            this.colKonto.Caption = "Konto";
            this.colKonto.FieldName = "KontoNr";
            this.colKonto.Name = "colKonto";
            this.colKonto.OptionsColumn.AllowEdit = false;
            this.colKonto.OptionsColumn.ReadOnly = true;
            this.colKonto.Visible = true;
            this.colKonto.VisibleIndex = 3;
            this.colKonto.Width = 48;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.OptionsColumn.ReadOnly = true;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 124;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.OptionsColumn.ReadOnly = true;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.OptionsColumn.AllowEdit = false;
            this.colKreditor.OptionsColumn.ReadOnly = true;
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 6;
            this.colKreditor.Width = 93;
            // 
            // colDoc
            // 
            this.colDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.Caption = "Dok";
            this.colDoc.FieldName = "Doc";
            this.colDoc.Name = "colDoc";
            this.colDoc.OptionsColumn.ReadOnly = true;
            this.colDoc.Visible = true;
            this.colDoc.VisibleIndex = 7;
            this.colDoc.Width = 32;
            // 
            // colMA
            // 
            this.colMA.Caption = "erfasst";
            this.colMA.FieldName = "MA";
            this.colMA.Name = "colMA";
            this.colMA.OptionsColumn.AllowEdit = false;
            this.colMA.OptionsColumn.ReadOnly = true;
            this.colMA.Visible = true;
            this.colMA.VisibleIndex = 8;
            this.colMA.Width = 62;
            // 
            // colPosStatus
            // 
            this.colPosStatus.Caption = "Stat.";
            this.colPosStatus.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colPosStatus.FieldName = "Status";
            this.colPosStatus.Name = "colPosStatus";
            this.colPosStatus.OptionsColumn.AllowEdit = false;
            this.colPosStatus.OptionsColumn.ReadOnly = true;
            this.colPosStatus.Visible = true;
            this.colPosStatus.VisibleIndex = 9;
            this.colPosStatus.Width = 40;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // colSelektion
            // 
            this.colSelektion.Caption = "Sel.";
            this.colSelektion.FieldName = "Sel";
            this.colSelektion.Name = "colSelektion";
            this.colSelektion.Visible = true;
            this.colSelektion.VisibleIndex = 10;
            this.colSelektion.Width = 35;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AllowFocused = false;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // edtSucheErfassungMA
            // 
            this.edtSucheErfassungMA.Location = new System.Drawing.Point(107, 54);
            this.edtSucheErfassungMA.Name = "edtSucheErfassungMA";
            this.edtSucheErfassungMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtSucheErfassungMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheErfassungMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungMA.TabIndex = 5;
            this.edtSucheErfassungMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheErfassungMA_UserModifiedFld);
            // 
            // edtSucheErfassungVon
            // 
            this.edtSucheErfassungVon.EditValue = null;
            this.edtSucheErfassungVon.Location = new System.Drawing.Point(213, 54);
            this.edtSucheErfassungVon.Name = "edtSucheErfassungVon";
            this.edtSucheErfassungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtSucheErfassungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungVon.Properties.ShowToday = false;
            this.edtSucheErfassungVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungVon.TabIndex = 6;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(8, 54);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(93, 24);
            this.kissLabel4.TabIndex = 4;
            this.kissLabel4.Text = "Erfassung";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // edtSucheErfassungBis
            // 
            this.edtSucheErfassungBis.EditValue = null;
            this.edtSucheErfassungBis.Location = new System.Drawing.Point(319, 54);
            this.edtSucheErfassungBis.Name = "edtSucheErfassungBis";
            this.edtSucheErfassungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtSucheErfassungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungBis.Properties.ShowToday = false;
            this.edtSucheErfassungBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungBis.TabIndex = 7;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(8, 84);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(82, 24);
            this.kissLabel5.TabIndex = 8;
            this.kissLabel5.Text = "Mutation";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // edtSucheMutationMA
            // 
            this.edtSucheMutationMA.Location = new System.Drawing.Point(107, 84);
            this.edtSucheMutationMA.Name = "edtSucheMutationMA";
            this.edtSucheMutationMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtSucheMutationMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheMutationMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationMA.TabIndex = 9;
            this.edtSucheMutationMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMutationMA_UserModifiedFld);
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(8, 125);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(72, 24);
            this.kissLabel6.TabIndex = 12;
            this.kissLabel6.Text = "Valuta von";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // edtSucheMutationVon
            // 
            this.edtSucheMutationVon.EditValue = null;
            this.edtSucheMutationVon.Location = new System.Drawing.Point(213, 84);
            this.edtSucheMutationVon.Name = "edtSucheMutationVon";
            this.edtSucheMutationVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSucheMutationVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationVon.Properties.ShowToday = false;
            this.edtSucheMutationVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationVon.TabIndex = 10;
            // 
            // edtSucheMutationBis
            // 
            this.edtSucheMutationBis.EditValue = null;
            this.edtSucheMutationBis.Location = new System.Drawing.Point(319, 84);
            this.edtSucheMutationBis.Name = "edtSucheMutationBis";
            this.edtSucheMutationBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtSucheMutationBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationBis.Properties.ShowToday = false;
            this.edtSucheMutationBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationBis.TabIndex = 11;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Location = new System.Drawing.Point(107, 26);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(90, 24);
            this.kissLabel8.TabIndex = 1;
            this.kissLabel8.Text = "Mitarbeiter/in";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaVon
            // 
            this.edtSucheValutaVon.EditValue = null;
            this.edtSucheValutaVon.Location = new System.Drawing.Point(107, 125);
            this.edtSucheValutaVon.Name = "edtSucheValutaVon";
            this.edtSucheValutaVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSucheValutaVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaVon.Properties.ShowToday = false;
            this.edtSucheValutaVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaVon.TabIndex = 13;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(224, 125);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(27, 24);
            this.kissLabel9.TabIndex = 14;
            this.kissLabel9.Text = "bis";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaBis
            // 
            this.edtSucheValutaBis.EditValue = null;
            this.edtSucheValutaBis.Location = new System.Drawing.Point(263, 125);
            this.edtSucheValutaBis.Name = "edtSucheValutaBis";
            this.edtSucheValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaBis.Properties.ShowToday = false;
            this.edtSucheValutaBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaBis.TabIndex = 15;
            // 
            // edtSucheStatus
            // 
            this.edtSucheStatus.Location = new System.Drawing.Point(107, 154);
            this.edtSucheStatus.Name = "edtSucheStatus";
            this.edtSucheStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStatus.Size = new System.Drawing.Size(256, 24);
            this.edtSucheStatus.TabIndex = 17;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(8, 155);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(72, 24);
            this.kissLabel10.TabIndex = 16;
            this.kissLabel10.Text = "Status";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(213, 27);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(82, 24);
            this.kissLabel3.TabIndex = 2;
            this.kissLabel3.Text = "Datum von";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(319, 27);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(82, 24);
            this.kissLabel7.TabIndex = 3;
            this.kissLabel7.Text = "Datum bis";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // tabKgPosition
            // 
            this.tabKgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKgPosition.Controls.Add(this.tpgEinzelzahlung);
            this.tabKgPosition.Controls.Add(this.tpgDokumente);
            this.tabKgPosition.Controls.Add(this.tpgVerlauf);
            this.tabKgPosition.Location = new System.Drawing.Point(3, 290);
            this.tabKgPosition.Name = "tabKgPosition";
            this.tabKgPosition.ShowFixedWidthTooltip = true;
            this.tabKgPosition.Size = new System.Drawing.Size(879, 535);
            this.tabKgPosition.TabIndex = 2;
            this.tabKgPosition.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgEinzelzahlung,
            this.tpgDokumente,
            this.tpgVerlauf});
            this.tabKgPosition.TabsLineColor = System.Drawing.Color.Black;
            this.tabKgPosition.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabKgPosition.Text = "kissTabControlEx1";
            this.tabKgPosition.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabKgPosition_SelectedTabChanged);
            // 
            // tpgEinzelzahlung
            // 
            this.tpgEinzelzahlung.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tpgEinzelzahlung.Controls.Add(this.splitterTreeControl);
            this.tpgEinzelzahlung.Controls.Add(this.grbAusgaben);
            this.tpgEinzelzahlung.Controls.Add(this.panPickerButton);
            this.tpgEinzelzahlung.Location = new System.Drawing.Point(6, 6);
            this.tpgEinzelzahlung.Name = "tpgEinzelzahlung";
            this.tpgEinzelzahlung.Size = new System.Drawing.Size(867, 497);
            this.tpgEinzelzahlung.TabIndex = 0;
            this.tpgEinzelzahlung.Title = "Einzelzahlung";
            // 
            // splitterTreeControl
            // 
            this.splitterTreeControl.AnimationDelay = 20;
            this.splitterTreeControl.AnimationStep = 20;
            this.splitterTreeControl.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterTreeControl.ControlToHide = this.grbAusgaben;
            this.splitterTreeControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterTreeControl.ExpandParentForm = false;
            this.splitterTreeControl.Location = new System.Drawing.Point(0, 347);
            this.splitterTreeControl.Name = "splitterTreeControl";
            this.splitterTreeControl.TabIndex = 413;
            this.splitterTreeControl.TabStop = false;
            this.splitterTreeControl.UseAnimations = false;
            this.splitterTreeControl.Visible = false;
            this.splitterTreeControl.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            this.splitterTreeControl.SplitterCollapsed += new System.EventHandler(this.splitterTreeControl_SplitterCollapsed);
            this.splitterTreeControl.SplitterExpanded += new System.EventHandler(this.splitterTreeControl_SplitterExpanded);
            // 
            // grbAusgaben
            // 
            this.grbAusgaben.Controls.Add(this.grdBetragsgleicheAusgaben);
            this.grbAusgaben.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbAusgaben.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grbAusgaben.Location = new System.Drawing.Point(0, 355);
            this.grbAusgaben.Name = "grbAusgaben";
            this.grbAusgaben.Size = new System.Drawing.Size(867, 142);
            this.grbAusgaben.TabIndex = 411;
            this.grbAusgaben.TabStop = false;
            this.grbAusgaben.Text = "Ausgaben des Mandanten";
            this.grbAusgaben.UseCompatibleTextRendering = true;
            this.grbAusgaben.Visible = false;
            // 
            // grdBetragsgleicheAusgaben
            // 
            this.grdBetragsgleicheAusgaben.DataSource = this.qryKgBuchung;
            this.grdBetragsgleicheAusgaben.Dock = System.Windows.Forms.DockStyle.Bottom;
            // 
            // 
            // 
            this.grdBetragsgleicheAusgaben.EmbeddedNavigator.Name = "";
            this.grdBetragsgleicheAusgaben.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBetragsgleicheAusgaben.Location = new System.Drawing.Point(3, 23);
            this.grdBetragsgleicheAusgaben.MainView = this.gridView4;
            this.grdBetragsgleicheAusgaben.Name = "grdBetragsgleicheAusgaben";
            this.grdBetragsgleicheAusgaben.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox3});
            this.grdBetragsgleicheAusgaben.Size = new System.Drawing.Size(861, 116);
            this.grdBetragsgleicheAusgaben.TabIndex = 24;
            this.grdBetragsgleicheAusgaben.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // qryKgBuchung
            // 
            this.qryKgBuchung.SelectStatement = resources.GetString("qryKgBuchung.SelectStatement");
            // 
            // gridView4
            // 
            this.gridView4.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView4.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Empty.Options.UseBackColor = true;
            this.gridView4.Appearance.Empty.Options.UseFont = true;
            this.gridView4.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.EvenRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView4.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView4.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.OddRow.Options.UseFont = true;
            this.gridView4.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Row.Options.UseBackColor = true;
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView4.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchungsdatum2,
            this.colBuchungstext2,
            this.colSoll,
            this.colHaben,
            this.colSaldo2,
            this.colKreditor2,
            this.colPosStatus2});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView4.GridControl = this.grdBetragsgleicheAusgaben;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsNavigation.UseTabKey = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // colBuchungsdatum2
            // 
            this.colBuchungsdatum2.Caption = "Buchung";
            this.colBuchungsdatum2.FieldName = "BuchungsDatum";
            this.colBuchungsdatum2.Name = "colBuchungsdatum2";
            this.colBuchungsdatum2.Visible = true;
            this.colBuchungsdatum2.VisibleIndex = 0;
            // 
            // colBuchungstext2
            // 
            this.colBuchungstext2.Caption = "Buchungstext";
            this.colBuchungstext2.FieldName = "Buchungstext";
            this.colBuchungstext2.Name = "colBuchungstext2";
            this.colBuchungstext2.Visible = true;
            this.colBuchungstext2.VisibleIndex = 1;
            this.colBuchungstext2.Width = 297;
            // 
            // colSoll
            // 
            this.colSoll.Caption = "Soll";
            this.colSoll.DisplayFormat.FormatString = "n2";
            this.colSoll.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoll.FieldName = "BetragSoll";
            this.colSoll.Name = "colSoll";
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 2;
            this.colSoll.Width = 80;
            // 
            // colHaben
            // 
            this.colHaben.Caption = "Haben";
            this.colHaben.DisplayFormat.FormatString = "n2";
            this.colHaben.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHaben.FieldName = "BetragHaben";
            this.colHaben.Name = "colHaben";
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 3;
            this.colHaben.Width = 80;
            // 
            // colSaldo2
            // 
            this.colSaldo2.Caption = "Saldo";
            this.colSaldo2.DisplayFormat.FormatString = "n2";
            this.colSaldo2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo2.FieldName = "Saldo";
            this.colSaldo2.Name = "colSaldo2";
            this.colSaldo2.Visible = true;
            this.colSaldo2.VisibleIndex = 4;
            this.colSaldo2.Width = 80;
            // 
            // colKreditor2
            // 
            this.colKreditor2.Caption = "Kreditor";
            this.colKreditor2.FieldName = "Kreditor";
            this.colKreditor2.Name = "colKreditor2";
            this.colKreditor2.Visible = true;
            this.colKreditor2.VisibleIndex = 5;
            this.colKreditor2.Width = 279;
            // 
            // colPosStatus2
            // 
            this.colPosStatus2.Caption = "Stat.";
            this.colPosStatus2.ColumnEdit = this.repositoryItemImageComboBox3;
            this.colPosStatus2.FieldName = "Status";
            this.colPosStatus2.Name = "colPosStatus2";
            this.colPosStatus2.Width = 35;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // panPickerButton
            // 
            this.panPickerButton.Controls.Add(this.edtBuchungstext);
            this.panPickerButton.Controls.Add(this.lblFreigabeInhalt);
            this.panPickerButton.Controls.Add(this.lblFreigabeAnzeige);
            this.panPickerButton.Controls.Add(this.btnDocument);
            this.panPickerButton.Controls.Add(this.edtZusatzInfo);
            this.panPickerButton.Controls.Add(this.btnMonatsbudget);
            this.panPickerButton.Controls.Add(this.edtErfassungDatum);
            this.panPickerButton.Controls.Add(this.kissLabel2);
            this.panPickerButton.Controls.Add(this.edtMandant);
            this.panPickerButton.Controls.Add(this.lblZahlungsgrund);
            this.panPickerButton.Controls.Add(this.edtKonto);
            this.panPickerButton.Controls.Add(this.lblReferenzNummer);
            this.panPickerButton.Controls.Add(this.edtBetrag);
            this.panPickerButton.Controls.Add(this.lblKreditor);
            this.panPickerButton.Controls.Add(this.grdMonatsbudget);
            this.panPickerButton.Controls.Add(this.lblValutaDatum);
            this.panPickerButton.Controls.Add(this.edtValutaDatum);
            this.panPickerButton.Controls.Add(this.lblBetrag);
            this.panPickerButton.Controls.Add(this.edtKreditor);
            this.panPickerButton.Controls.Add(this.kissLabel1);
            this.panPickerButton.Controls.Add(this.edtReferenzNummer);
            this.panPickerButton.Controls.Add(this.lblBuchungstext);
            this.panPickerButton.Controls.Add(this.edtMitteilungZeile1);
            this.panPickerButton.Controls.Add(this.lblKonto);
            this.panPickerButton.Controls.Add(this.edtMitteilungZeile2);
            this.panPickerButton.Controls.Add(this.label10);
            this.panPickerButton.Controls.Add(this.edtMitteilungZeile3);
            this.panPickerButton.Controls.Add(this.label1);
            this.panPickerButton.Controls.Add(this.edtBemerkung);
            this.panPickerButton.Controls.Add(this.lblMandant);
            this.panPickerButton.Controls.Add(this.edtBaPersonID);
            this.panPickerButton.Controls.Add(this.lblErfassungDatum);
            this.panPickerButton.Controls.Add(this.edtAdresse);
            this.panPickerButton.Controls.Add(this.ctlErfassungMutation1);
            this.panPickerButton.Controls.Add(this.edtMT);
            this.panPickerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPickerButton.Location = new System.Drawing.Point(0, 0);
            this.panPickerButton.Margin = new System.Windows.Forms.Padding(0);
            this.panPickerButton.Name = "panPickerButton";
            this.panPickerButton.Size = new System.Drawing.Size(867, 363);
            this.panPickerButton.TabIndex = 0;
            this.panPickerButton.TabStop = true;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryKgPosition;
            this.edtBuchungstext.Location = new System.Drawing.Point(107, 140);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBuchungstext.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBuchungstext.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(317, 24);
            this.edtBuchungstext.TabIndex = 7;
            this.edtBuchungstext.TextChanged += new System.EventHandler(this.edtBuchungstext_TextChanged);
            this.edtBuchungstext.Enter += new System.EventHandler(this.edtBuchungstext_Enter);
            // 
            // lblFreigabeInhalt
            // 
            this.lblFreigabeInhalt.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblFreigabeInhalt.Location = new System.Drawing.Point(596, 340);
            this.lblFreigabeInhalt.Name = "lblFreigabeInhalt";
            this.lblFreigabeInhalt.Size = new System.Drawing.Size(238, 16);
            this.lblFreigabeInhalt.TabIndex = 34;
            this.lblFreigabeInhalt.Text = "---";
            this.lblFreigabeInhalt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFreigabeInhalt.UseCompatibleTextRendering = true;
            // 
            // lblFreigabeAnzeige
            // 
            this.lblFreigabeAnzeige.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFreigabeAnzeige.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblFreigabeAnzeige.Location = new System.Drawing.Point(534, 337);
            this.lblFreigabeAnzeige.Name = "lblFreigabeAnzeige";
            this.lblFreigabeAnzeige.Size = new System.Drawing.Size(56, 24);
            this.lblFreigabeAnzeige.TabIndex = 33;
            this.lblFreigabeAnzeige.Text = "Freigabe";
            this.lblFreigabeAnzeige.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFreigabeAnzeige.UseCompatibleTextRendering = true;
            // 
            // btnDocument
            // 
            this.btnDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocument.Location = new System.Drawing.Point(810, 4);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(24, 24);
            this.btnDocument.TabIndex = 24;
            this.btnDocument.UseCompatibleTextRendering = true;
            this.btnDocument.UseVisualStyleBackColor = false;
            this.btnDocument.Click += new System.EventHandler(this.btnDocument_Click);
            // 
            // edtZusatzInfo
            // 
            this.edtZusatzInfo.DataMember = "ZusatzInfo";
            this.edtZusatzInfo.DataSource = this.qryKgPosition;
            this.edtZusatzInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZusatzInfo.Location = new System.Drawing.Point(534, 57);
            this.edtZusatzInfo.Name = "edtZusatzInfo";
            this.edtZusatzInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZusatzInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzInfo.Properties.ReadOnly = true;
            this.edtZusatzInfo.Size = new System.Drawing.Size(300, 90);
            this.edtZusatzInfo.TabIndex = 30;
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(5, 232);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(86, 24);
            this.btnMonatsbudget.TabIndex = 31;
            this.btnMonatsbudget.Text = "> Budget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // edtErfassungDatum
            // 
            this.edtErfassungDatum.DataMember = "BuchungDatum";
            this.edtErfassungDatum.DataSource = this.qryKgPosition;
            this.edtErfassungDatum.EditValue = null;
            this.edtErfassungDatum.Location = new System.Drawing.Point(107, 4);
            this.edtErfassungDatum.Name = "edtErfassungDatum";
            this.edtErfassungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtErfassungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErfassungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtErfassungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungDatum.Properties.ShowToday = false;
            this.edtErfassungDatum.Size = new System.Drawing.Size(100, 24);
            this.edtErfassungDatum.TabIndex = 1;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(448, 262);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(80, 24);
            this.kissLabel2.TabIndex = 22;
            this.kissLabel2.Text = "Bemerkung";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtMandant
            // 
            this.edtMandant.DataMember = "Mandant";
            this.edtMandant.DataSource = this.qryKgPosition;
            this.edtMandant.Location = new System.Drawing.Point(107, 34);
            this.edtMandant.LookupSQL = "select null";
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandant.Properties.Name = "editMandant.Properties";
            this.edtMandant.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMandant.Size = new System.Drawing.Size(253, 24);
            this.edtMandant.TabIndex = 3;
            this.edtMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandant_UserModifiedFld);
            // 
            // lblZahlungsgrund
            // 
            this.lblZahlungsgrund.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblZahlungsgrund.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZahlungsgrund.Location = new System.Drawing.Point(447, 186);
            this.lblZahlungsgrund.Name = "lblZahlungsgrund";
            this.lblZahlungsgrund.Size = new System.Drawing.Size(81, 24);
            this.lblZahlungsgrund.TabIndex = 18;
            this.lblZahlungsgrund.Text = "Mitteilung";
            this.lblZahlungsgrund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblZahlungsgrund.UseCompatibleTextRendering = true;
            this.lblZahlungsgrund.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_Click);
            // 
            // edtKonto
            // 
            this.edtKonto.DataMember = "Konto";
            this.edtKonto.DataSource = this.qryKgPosition;
            this.edtKonto.Location = new System.Drawing.Point(107, 110);
            this.edtKonto.Name = "edtKonto";
            this.edtKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKonto.Properties.Appearance.Options.UseFont = true;
            this.edtKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKonto.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKonto.Size = new System.Drawing.Size(317, 24);
            this.edtKonto.TabIndex = 5;
            this.edtKonto.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKonto_UserModifiedFld);
            // 
            // lblReferenzNummer
            // 
            this.lblReferenzNummer.Location = new System.Drawing.Point(448, 158);
            this.lblReferenzNummer.Name = "lblReferenzNummer";
            this.lblReferenzNummer.Size = new System.Drawing.Size(80, 24);
            this.lblReferenzNummer.TabIndex = 16;
            this.lblReferenzNummer.Text = "Ref-Nr.:";
            this.lblReferenzNummer.UseCompatibleTextRendering = true;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryKgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(107, 170);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 9;
            // 
            // lblKreditor
            // 
            this.lblKreditor.Location = new System.Drawing.Point(447, 34);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(81, 24);
            this.lblKreditor.TabIndex = 14;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            // 
            // grdMonatsbudget
            // 
            this.grdMonatsbudget.DataSource = this.qryMonatsbudget;
            // 
            // 
            // 
            this.grdMonatsbudget.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdMonatsbudget.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMonatsbudget.Location = new System.Drawing.Point(107, 200);
            this.grdMonatsbudget.MainView = this.gridView2;
            this.grdMonatsbudget.Name = "grdMonatsbudget";
            this.grdMonatsbudget.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdMonatsbudget.Size = new System.Drawing.Size(317, 135);
            this.grdMonatsbudget.TabIndex = 11;
            this.grdMonatsbudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryMonatsbudget
            // 
            this.qryMonatsbudget.BatchUpdate = true;
            this.qryMonatsbudget.HostControl = this;
            this.qryMonatsbudget.SelectStatement = resources.GetString("qryMonatsbudget.SelectStatement");
            this.qryMonatsbudget.PositionChanged += new System.EventHandler(this.qryMonatsbudget_PositionChanged);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonat,
            this.colJahr,
            this.colStatus,
            this.colAnzEZ});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdMonatsbudget;
            this.gridView2.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colMonat
            // 
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "MonatText";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 0;
            this.colMonat.Width = 90;
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 1;
            this.colJahr.Width = 46;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Stat.";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "KgBewilligungCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 35;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colAnzEZ
            // 
            this.colAnzEZ.Caption = "EZ";
            this.colAnzEZ.FieldName = "EZ";
            this.colAnzEZ.Name = "colAnzEZ";
            this.colAnzEZ.Visible = true;
            this.colAnzEZ.VisibleIndex = 3;
            this.colAnzEZ.Width = 31;
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblValutaDatum.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblValutaDatum.Location = new System.Drawing.Point(448, 5);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(80, 24);
            this.lblValutaDatum.TabIndex = 12;
            this.lblValutaDatum.Text = "Valuta";
            this.lblValutaDatum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            this.lblValutaDatum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_Click);
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.DataMember = "ValutaDatum";
            this.edtValutaDatum.DataSource = this.qryKgPosition;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(534, 4);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(100, 24);
            this.edtValutaDatum.TabIndex = 13;
            this.edtValutaDatum.Validated += new System.EventHandler(this.edtValutaDatum_Validated);
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(5, 170);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(96, 24);
            this.lblBetrag.TabIndex = 8;
            this.lblBetrag.Text = "Betrag CHF";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // edtKreditor
            // 
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryKgPosition;
            this.edtKreditor.Location = new System.Drawing.Point(534, 34);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKreditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKreditor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKreditor.Size = new System.Drawing.Size(300, 24);
            this.edtKreditor.TabIndex = 15;
            this.edtKreditor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKreditor_UserModifiedFld);
            // 
            // kissLabel1
            // 
            this.kissLabel1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel1.Location = new System.Drawing.Point(5, 199);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(96, 24);
            this.kissLabel1.TabIndex = 10;
            this.kissLabel1.Text = "Monatsbudgets";
            this.kissLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kissLabel1.UseCompatibleTextRendering = true;
            this.kissLabel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_Click);
            // 
            // edtReferenzNummer
            // 
            this.edtReferenzNummer.DataMember = "ReferenzNummer";
            this.edtReferenzNummer.DataSource = this.qryKgPosition;
            this.edtReferenzNummer.Location = new System.Drawing.Point(534, 158);
            this.edtReferenzNummer.Name = "edtReferenzNummer";
            this.edtReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenzNummer.Size = new System.Drawing.Size(300, 24);
            this.edtReferenzNummer.TabIndex = 17;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBuchungstext.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBuchungstext.Location = new System.Drawing.Point(5, 140);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(96, 24);
            this.lblBuchungstext.TabIndex = 6;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            this.lblBuchungstext.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_Click);
            // 
            // edtMitteilungZeile1
            // 
            this.edtMitteilungZeile1.DataMember = "MitteilungZeile1";
            this.edtMitteilungZeile1.DataSource = this.qryKgPosition;
            this.edtMitteilungZeile1.Location = new System.Drawing.Point(534, 186);
            this.edtMitteilungZeile1.Name = "edtMitteilungZeile1";
            this.edtMitteilungZeile1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile1.Size = new System.Drawing.Size(300, 24);
            this.edtMitteilungZeile1.TabIndex = 19;
            // 
            // lblKonto
            // 
            this.lblKonto.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblKonto.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKonto.Location = new System.Drawing.Point(5, 110);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(96, 24);
            this.lblKonto.TabIndex = 4;
            this.lblKonto.Text = "Konto";
            this.lblKonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKonto.UseCompatibleTextRendering = true;
            this.lblKonto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_Click);
            // 
            // edtMitteilungZeile2
            // 
            this.edtMitteilungZeile2.DataMember = "MitteilungZeile2";
            this.edtMitteilungZeile2.DataSource = this.qryKgPosition;
            this.edtMitteilungZeile2.Location = new System.Drawing.Point(534, 209);
            this.edtMitteilungZeile2.Name = "edtMitteilungZeile2";
            this.edtMitteilungZeile2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile2.Size = new System.Drawing.Size(300, 24);
            this.edtMitteilungZeile2.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 24);
            this.label10.TabIndex = 28;
            this.label10.Text = "Beist. oder Vorm.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.UseCompatibleTextRendering = true;
            // 
            // edtMitteilungZeile3
            // 
            this.edtMitteilungZeile3.DataMember = "MitteilungZeile3";
            this.edtMitteilungZeile3.DataSource = this.qryKgPosition;
            this.edtMitteilungZeile3.Location = new System.Drawing.Point(534, 232);
            this.edtMitteilungZeile3.Name = "edtMitteilungZeile3";
            this.edtMitteilungZeile3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile3.Size = new System.Drawing.Size(300, 24);
            this.edtMitteilungZeile3.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Adresse";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryKgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(534, 262);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(300, 35);
            this.edtBemerkung.TabIndex = 23;
            // 
            // lblMandant
            // 
            this.lblMandant.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMandant.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMandant.Location = new System.Drawing.Point(5, 32);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(96, 23);
            this.lblMandant.TabIndex = 2;
            this.lblMandant.Text = "Person m. zivilr. Massn.";
            this.lblMandant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMandant.UseCompatibleTextRendering = true;
            this.lblMandant.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_Click);
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryKgPosition;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(359, 34);
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
            this.edtBaPersonID.Size = new System.Drawing.Size(66, 24);
            this.edtBaPersonID.TabIndex = 25;
            // 
            // lblErfassungDatum
            // 
            this.lblErfassungDatum.Location = new System.Drawing.Point(5, 4);
            this.lblErfassungDatum.Name = "lblErfassungDatum";
            this.lblErfassungDatum.Size = new System.Drawing.Size(96, 24);
            this.lblErfassungDatum.TabIndex = 0;
            this.lblErfassungDatum.Text = "Buchung";
            this.lblErfassungDatum.UseCompatibleTextRendering = true;
            // 
            // edtAdresse
            // 
            this.edtAdresse.DataMember = "Adresse";
            this.edtAdresse.DataSource = this.qryKgPosition;
            this.edtAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresse.Location = new System.Drawing.Point(107, 57);
            this.edtAdresse.Name = "edtAdresse";
            this.edtAdresse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresse.Properties.Name = "editPlzOrt.Properties";
            this.edtAdresse.Properties.ReadOnly = true;
            this.edtAdresse.Size = new System.Drawing.Size(318, 24);
            this.edtAdresse.TabIndex = 27;
            // 
            // ctlErfassungMutation1
            // 
            this.ctlErfassungMutation1.ActiveSQLQuery = this.qryKgPosition;
            this.ctlErfassungMutation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation1.LabelLength = 60;
            this.ctlErfassungMutation1.Location = new System.Drawing.Point(534, 303);
            this.ctlErfassungMutation1.Name = "ctlErfassungMutation1";
            this.ctlErfassungMutation1.Size = new System.Drawing.Size(300, 38);
            this.ctlErfassungMutation1.TabIndex = 32;
            // 
            // edtMT
            // 
            this.edtMT.DataMember = "MT";
            this.edtMT.DataSource = this.qryKgPosition;
            this.edtMT.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMT.Location = new System.Drawing.Point(107, 80);
            this.edtMT.Name = "edtMT";
            this.edtMT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMT.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMT.Properties.Appearance.Options.UseBackColor = true;
            this.edtMT.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMT.Properties.Appearance.Options.UseFont = true;
            this.edtMT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMT.Properties.Name = "editMT.Properties";
            this.edtMT.Properties.ReadOnly = true;
            this.edtMT.Size = new System.Drawing.Size(318, 24);
            this.edtMT.TabIndex = 29;
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.lblDokument);
            this.tpgDokumente.Controls.Add(this.lblDokumentTyp);
            this.tpgDokumente.Controls.Add(this.lblStichwort);
            this.tpgDokumente.Controls.Add(this.edtDocument);
            this.tpgDokumente.Controls.Add(this.edtStichwort);
            this.tpgDokumente.Controls.Add(this.edtDokumentTyp);
            this.tpgDokumente.Controls.Add(this.grdDoc);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(867, 497);
            this.tpgDokumente.TabIndex = 1;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokument.Location = new System.Drawing.Point(578, 466);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(59, 24);
            this.lblDokument.TabIndex = 18;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // lblDokumentTyp
            // 
            this.lblDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumentTyp.Location = new System.Drawing.Point(5, 466);
            this.lblDokumentTyp.Name = "lblDokumentTyp";
            this.lblDokumentTyp.Size = new System.Drawing.Size(28, 24);
            this.lblDokumentTyp.TabIndex = 16;
            this.lblDokumentTyp.Text = "Typ";
            this.lblDokumentTyp.UseCompatibleTextRendering = true;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(179, 466);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(55, 24);
            this.lblStichwort.TabIndex = 14;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocument.CanCreateDocument = false;
            this.edtDocument.CanDeleteDocument = false;
            this.edtDocument.Context = "KgBudget";
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryKgDokumente;
            this.edtDocument.Location = new System.Drawing.Point(644, 466);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(120, 24);
            this.edtDocument.TabIndex = 3;
            // 
            // qryKgDokumente
            // 
            this.qryKgDokumente.CanDelete = true;
            this.qryKgDokumente.CanInsert = true;
            this.qryKgDokumente.CanUpdate = true;
            this.qryKgDokumente.DeleteQuestion = "Soll das Dokument gelöscht werden ?";
            this.qryKgDokumente.HostControl = this;
            this.qryKgDokumente.SelectStatement = resources.GetString("qryKgDokumente.SelectStatement");
            this.qryKgDokumente.TableName = "KgDokument";
            this.qryKgDokumente.AfterDelete += new System.EventHandler(this.qryKgDokumente_AfterDelete);
            this.qryKgDokumente.AfterInsert += new System.EventHandler(this.qryKgDokumente_AfterInsert);
            this.qryKgDokumente.BeforePost += new System.EventHandler(this.qryKgDokumente_BeforePost);
            this.qryKgDokumente.PostCompleted += new System.EventHandler(this.qryKgDokumente_PostCompleted);
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryKgDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(240, 466);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(326, 24);
            this.edtStichwort.TabIndex = 2;
            // 
            // edtDokumentTyp
            // 
            this.edtDokumentTyp.AllowNull = false;
            this.edtDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokumentTyp.DataMember = "KgDokumentTypCode";
            this.edtDokumentTyp.DataSource = this.qryKgDokumente;
            this.edtDokumentTyp.Location = new System.Drawing.Point(39, 466);
            this.edtDokumentTyp.LOVFilter = "Code IN (1,2,3)";
            this.edtDokumentTyp.LOVName = "KgDokumentTyp";
            this.edtDokumentTyp.Name = "edtDokumentTyp";
            this.edtDokumentTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtDokumentTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentTyp.Properties.NullText = "";
            this.edtDokumentTyp.Properties.ShowFooter = false;
            this.edtDokumentTyp.Properties.ShowHeader = false;
            this.edtDokumentTyp.Size = new System.Drawing.Size(134, 24);
            this.edtDokumentTyp.TabIndex = 1;
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDoc.DataSource = this.qryKgDokumente;
            // 
            // 
            // 
            this.grdDoc.EmbeddedNavigator.Name = "";
            this.grdDoc.Location = new System.Drawing.Point(5, 5);
            this.grdDoc.MainView = this.gridView1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.Size = new System.Drawing.Size(768, 455);
            this.grdDoc.TabIndex = 0;
            this.grdDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.colDocTyp,
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
            // colDocTyp
            // 
            this.colDocTyp.Caption = "Typ";
            this.colDocTyp.FieldName = "KgDokumentTypCode";
            this.colDocTyp.Name = "colDocTyp";
            this.colDocTyp.Visible = true;
            this.colDocTyp.VisibleIndex = 0;
            this.colDocTyp.Width = 123;
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
            // tpgVerlauf
            // 
            this.tpgVerlauf.Controls.Add(this.edtSAR);
            this.tpgVerlauf.Controls.Add(this.lblSAR);
            this.tpgVerlauf.Controls.Add(this.grdBewilligung);
            this.tpgVerlauf.Location = new System.Drawing.Point(6, 6);
            this.tpgVerlauf.Name = "tpgVerlauf";
            this.tpgVerlauf.Size = new System.Drawing.Size(867, 497);
            this.tpgVerlauf.TabIndex = 2;
            this.tpgVerlauf.Title = "Verlauf";
            // 
            // edtSAR
            // 
            this.edtSAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSAR.DataMember = "SARText";
            this.edtSAR.DataSource = this.qryKgBewilligung;
            this.edtSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSAR.Location = new System.Drawing.Point(78, 468);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSAR.Properties.ReadOnly = true;
            this.edtSAR.Size = new System.Drawing.Size(383, 24);
            this.edtSAR.TabIndex = 9;
            // 
            // qryKgBewilligung
            // 
            this.qryKgBewilligung.HostControl = this;
            this.qryKgBewilligung.SelectStatement = resources.GetString("qryKgBewilligung.SelectStatement");
            this.qryKgBewilligung.TableName = "KgBewilligung";
            // 
            // lblSAR
            // 
            this.lblSAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSAR.Location = new System.Drawing.Point(0, 468);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(72, 24);
            this.lblSAR.TabIndex = 8;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // grdBewilligung
            // 
            this.grdBewilligung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBewilligung.DataSource = this.qryKgBewilligung;
            // 
            // 
            // 
            this.grdBewilligung.EmbeddedNavigator.Name = "";
            this.grdBewilligung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBewilligung.Location = new System.Drawing.Point(0, 3);
            this.grdBewilligung.MainView = this.grvBewilligung;
            this.grdBewilligung.Name = "grdBewilligung";
            this.grdBewilligung.Size = new System.Drawing.Size(867, 459);
            this.grdBewilligung.TabIndex = 7;
            this.grdBewilligung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBewilligung});
            // 
            // grvBewilligung
            // 
            this.grvBewilligung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBewilligung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.Empty.Options.UseFont = true;
            this.grvBewilligung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBewilligung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBewilligung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBewilligung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBewilligung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBewilligung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBewilligung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBewilligung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBewilligung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBewilligung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBewilligung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBewilligung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBewilligung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBewilligung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBewilligung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBewilligung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBewilligung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBewilligung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBewilligung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBewilligung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBewilligung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBewilligung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBewilligung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBewilligung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBewilligung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBewilligung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.OddRow.Options.UseFont = true;
            this.grvBewilligung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBewilligung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.Row.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.Row.Options.UseFont = true;
            this.grvBewilligung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBewilligung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBewilligung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBewilligung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBewilligung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBewilligung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colSAR,
            this.colKgBewilligungCode,
            this.colHerkunft});
            this.grvBewilligung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBewilligung.GridControl = this.grdBewilligung;
            this.grvBewilligung.Name = "grvBewilligung";
            this.grvBewilligung.OptionsBehavior.Editable = false;
            this.grvBewilligung.OptionsCustomization.AllowFilter = false;
            this.grvBewilligung.OptionsFilter.AllowFilterEditor = false;
            this.grvBewilligung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBewilligung.OptionsMenu.EnableColumnMenu = false;
            this.grvBewilligung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBewilligung.OptionsNavigation.UseTabKey = false;
            this.grvBewilligung.OptionsView.ColumnAutoWidth = false;
            this.grvBewilligung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBewilligung.OptionsView.ShowGroupPanel = false;
            this.grvBewilligung.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 97;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 1;
            this.colSAR.Width = 244;
            // 
            // colKgBewilligungCode
            // 
            this.colKgBewilligungCode.Caption = "Typ";
            this.colKgBewilligungCode.FieldName = "KgBewilligungCode";
            this.colKgBewilligungCode.Name = "colKgBewilligungCode";
            this.colKgBewilligungCode.Visible = true;
            this.colKgBewilligungCode.VisibleIndex = 2;
            this.colKgBewilligungCode.Width = 163;
            // 
            // colHerkunft
            // 
            this.colHerkunft.Caption = "Herkunft";
            this.colHerkunft.FieldName = "Herkunft";
            this.colHerkunft.Name = "colHerkunft";
            this.colHerkunft.Visible = true;
            this.colHerkunft.VisibleIndex = 3;
            this.colHerkunft.Width = 160;
            // 
            // btnEinzelzahlungenGruenstellen
            // 
            this.btnEinzelzahlungenGruenstellen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEinzelzahlungenGruenstellen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinzelzahlungenGruenstellen.Location = new System.Drawing.Point(560, 1);
            this.btnEinzelzahlungenGruenstellen.Name = "btnEinzelzahlungenGruenstellen";
            this.btnEinzelzahlungenGruenstellen.Size = new System.Drawing.Size(170, 24);
            this.btnEinzelzahlungenGruenstellen.TabIndex = 1;
            this.btnEinzelzahlungenGruenstellen.Text = "Einzelzahlungen freigeben";
            this.btnEinzelzahlungenGruenstellen.UseVisualStyleBackColor = false;
            this.btnEinzelzahlungenGruenstellen.Visible = false;
            this.btnEinzelzahlungenGruenstellen.Click += new System.EventHandler(this.btnEinzelzahlungenGruenstellen_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(507, 1);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(50, 24);
            this.btnKeine.TabIndex = 2;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Visible = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(451, 1);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(50, 24);
            this.btnAlle.TabIndex = 3;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Visible = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // lblFortschritt
            // 
            this.lblFortschritt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFortschritt.Location = new System.Drawing.Point(391, 1);
            this.lblFortschritt.Name = "lblFortschritt";
            this.lblFortschritt.Size = new System.Drawing.Size(54, 24);
            this.lblFortschritt.TabIndex = 11;
            this.lblFortschritt.Text = "Fortschritt";
            this.lblFortschritt.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 24);
            this.panel1.TabIndex = 0;
            // 
            // picTitel
            // 
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Kreditoren";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // qryBaZahlwegCheck
            // 
            this.qryBaZahlwegCheck.BatchUpdate = true;
            this.qryBaZahlwegCheck.HostControl = this;
            this.qryBaZahlwegCheck.SelectStatement = resources.GetString("qryBaZahlwegCheck.SelectStatement");
            // 
            // btnPositionenLoeschen
            // 
            this.btnPositionenLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPositionenLoeschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionenLoeschen.Location = new System.Drawing.Point(3, 1);
            this.btnPositionenLoeschen.Name = "btnPositionenLoeschen";
            this.btnPositionenLoeschen.Size = new System.Drawing.Size(138, 24);
            this.btnPositionenLoeschen.TabIndex = 13;
            this.btnPositionenLoeschen.Text = "Positionen löschen";
            this.btnPositionenLoeschen.UseVisualStyleBackColor = false;
            this.btnPositionenLoeschen.Visible = false;
            this.btnPositionenLoeschen.Click += new System.EventHandler(this.btnPositionenLoeschen_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnPositionenLoeschen);
            this.panel2.Controls.Add(this.lblFortschritt);
            this.panel2.Controls.Add(this.btnKeine);
            this.panel2.Controls.Add(this.btnAlle);
            this.panel2.Controls.Add(this.btnEinzelzahlungenGruenstellen);
            this.panel2.Location = new System.Drawing.Point(103, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 28);
            this.panel2.TabIndex = 14;
            // 
            // CtlKgEinzelzahlungen
            // 
            this.ActiveSQLQuery = this.qryKgPosition;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(845, 790);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabKgPosition);
            this.Controls.Add(this.panel1);
            this.Name = "CtlKgEinzelzahlungen";
            this.Size = new System.Drawing.Size(885, 825);
            this.Load += new System.EventHandler(this.CtlKgEinzelzahlungen_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.tabKgPosition, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            this.tabKgPosition.ResumeLayout(false);
            this.tpgEinzelzahlung.ResumeLayout(false);
            this.grbAusgaben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBetragsgleicheAusgaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            this.panPickerButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFreigabeInhalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFreigabeAnzeige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMT.Properties)).EndInit();
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpgVerlauf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFortschritt)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlwegCheck)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SharpLibrary.WinControls.TabPageEx tpgVerlauf;
        private KiSS4.Gui.KissTextEdit edtSAR;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissGrid grdBewilligung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBewilligung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colKgBewilligungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colHerkunft;
        private KiSS4.DB.SqlQuery qryKgBewilligung;
        private KiSS4.Gui.KissLabel lblFreigabeAnzeige;
        private KiSS4.Gui.KissLabel lblFreigabeInhalt;
        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnDocument;
        private KiSS4.Gui.KissButton btnEinzelzahlungenGruenstellen;
        private KiSS4.Gui.KissButton btnKeine;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private KiSS4.Gui.KissButton btnPositionenLoeschen;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzEZ;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungsdatum2;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext2;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor2;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colPosStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPosStatus2;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo2;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation1;
        private KiSS4.Gui.KissTextEdit edtAdresse;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Dokument.XDokument edtDocument;
        private KiSS4.Gui.KissLookUpEdit edtDokumentTyp;
        private KiSS4.Gui.KissDateEdit edtErfassungDatum;
        private KiSS4.Gui.KissButtonEdit edtKonto;
        private KiSS4.Gui.KissButtonEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtMT;
        private KiSS4.Gui.KissButtonEdit edtMandant;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile1;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile2;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile3;
        private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungBis;
        private KiSS4.Gui.KissButtonEdit edtSucheErfassungMA;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungVon;
        private KiSS4.Gui.KissDateEdit edtSucheMutationBis;
        private KiSS4.Gui.KissButtonEdit edtSucheMutationMA;
        private KiSS4.Gui.KissDateEdit edtSucheMutationVon;
        private KiSS4.Gui.KissImageComboBoxEdit edtSucheStatus;
        private KiSS4.Gui.KissDateEdit edtSucheValutaBis;
        private KiSS4.Gui.KissDateEdit edtSucheValutaVon;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissMemoEdit edtZusatzInfo;
        private KiSS4.Gui.KissGroupBox grbAusgaben;
        private KiSS4.Gui.KissGrid grdBetragsgleicheAusgaben;
        private KiSS4.Gui.KissGrid grdDoc;
        private KiSS4.Gui.KissGrid grdEinzelzahlung;
        private KiSS4.Gui.KissGrid grdMonatsbudget;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinzelzahlung;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel label1;
        private KiSS4.Gui.KissLabel label10;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblDokumentTyp;
        private KiSS4.Gui.KissLabel lblErfassungDatum;
        private KiSS4.Gui.KissLabel lblFortschritt;
        private KiSS4.Gui.KissLabel lblKonto;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissLabel lblReferenzNummer;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblZahlungsgrund;
        private System.Windows.Forms.Panel panPickerButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBaZahlwegCheck;
        private KiSS4.DB.SqlQuery qryKgBuchung;
        private KiSS4.DB.SqlQuery qryKgDokumente;
        private KiSS4.DB.SqlQuery qryKgPosition;
        private KiSS4.DB.SqlQuery qryMonatsbudget;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private KiSS4.Gui.KissSplitterCollapsible splitterTreeControl;
        private KiSS4.Gui.KissTabControlEx tabKgPosition;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private SharpLibrary.WinControls.TabPageEx tpgEinzelzahlung;
        private Gui.KissComboBox edtBuchungstext;
    }
}