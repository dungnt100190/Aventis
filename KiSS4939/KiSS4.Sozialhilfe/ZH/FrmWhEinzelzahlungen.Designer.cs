namespace KiSS4.Sozialhilfe.ZH
{
    public partial class FrmWhEinzelzahlungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWhEinzelzahlungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject27 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject26 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject25 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject24 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject28 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject29 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject30 = new DevExpress.Utils.SerializableAppearanceObject();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdEinzelzahlung = new KiSS4.Gui.KissGrid();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.grvEinzelzahlung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechnungsnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.edtSucheErfassungMA = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheErfassungVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheErfassung = new KiSS4.Gui.KissLabel();
            this.edtSucheErfassungBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheKontrolle = new KiSS4.Gui.KissLabel();
            this.edtSucheKontrolleMA = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheValutaVon = new KiSS4.Gui.KissLabel();
            this.edtSucheKontrolleVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheKontrolleBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheValutaBis = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheStatus = new KiSS4.Gui.KissImageComboBoxEdit();
            this.edtSucheBelegID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheStatus = new KiSS4.Gui.KissLabel();
            this.edtSucheFallNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSucheBelegID = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtSucheSelectTop = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.btnEinzelzahlungen = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.tabBgPosition = new KiSS4.Gui.KissTabControlEx();
            this.tpgVerlauf = new SharpLibrary.WinControls.TabPageEx();
            this.edtBgBewilligungBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryBgBewilligung = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.grdBewilligung = new KiSS4.Gui.KissGrid();
            this.grvBewilligung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgBewilligungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHerkunft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.qryBgDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtDokumentTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblDokumentTyp = new KiSS4.Gui.KissLabel();
            this.grdDoc = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgEinzelzahlung = new SharpLibrary.WinControls.TabPageEx();
            this.grdSollHaben = new KiSS4.Gui.KissGrid();
            this.qryLetzte10Buchungen = new KiSS4.DB.SqlQuery(this.components);
            this.grvSollHaben = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdBuchungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblKontrolle = new KiSS4.Gui.KissLabel();
            this.lblKontrolleText = new KiSS4.Gui.KissLabel();
            this.edtRechnungsnummer = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsnummer = new KiSS4.Gui.KissLabel();
            this.btnDocument = new KiSS4.Gui.KissButton();
            this.edtBuchungstext = new KiSS4.Gui.KissComboBox();
            this.edtTeamZustaendig = new KiSS4.Gui.KissTextEdit();
            this.lblTeamZustaendig = new KiSS4.Gui.KissLabel();
            this.btnPositionGruen = new KiSS4.Gui.KissButton();
            this.btnPositionGrau = new KiSS4.Gui.KissButton();
            this.edtAdresse = new KiSS4.Gui.KissTextEdit();
            this.edtKlientID = new KiSS4.Gui.KissTextEdit();
            this.btnWeitereKOA = new KiSS4.Gui.KissButton();
            this.btnPositionBewilligung = new KiSS4.Gui.KissButton();
            this.edtFallNr = new KiSS4.Gui.KissCalcEdit();
            this.lblFallNr = new KiSS4.Gui.KissLabel();
            this.ctlErfassungMutation1 = new KiSS4.Common.CtlErfassungMutation();
            this.edtBgSplittingCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSplittingCode = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriodeStrich = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriode = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtMitteilungZeile2 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilungZeile1 = new KiSS4.Gui.KissTextEdit();
            this.lblZahlungsgrund = new KiSS4.Gui.KissLabel();
            this.edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit(this.components);
            this.lblReferenzNummer = new KiSS4.Gui.KissLabel();
            this.edtZusatzInfo = new KiSS4.Gui.KissMemoEdit();
            this.edtKreditor = new KiSS4.Gui.KissButtonEdit();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.grdMonatsbudget = new KiSS4.Gui.KissGrid();
            this.qryMonatsbudget = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzEZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzZL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMonatsbudget = new KiSS4.Gui.KissLabel();
            this.edtBgSpezkontoID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSpezkontoID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtKostenart = new KiSS4.Gui.KissButtonEdit();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.label1 = new KiSS4.Gui.KissLabel();
            this.edtKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtKategorie = new KiSS4.Gui.KissLookUpEdit();
            this.lblKategorie = new KiSS4.Gui.KissLabel();
            this.btnZusatzleistung = new KiSS4.Gui.KissButton();
            this.edtAutomAnfrage = new KiSS4.Gui.KissCheckEdit();
            this.lblFortschritt = new KiSS4.Gui.KissLabel();
            this.qryBgAuszahlungPersonTermin = new KiSS4.DB.SqlQuery(this.components);
            this.edtSucheMutationBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheMutationVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheMutationMA = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheMutation = new KiSS4.Gui.KissLabel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.panDetail = new System.Windows.Forms.Panel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKontrolle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontrolleMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontrolleVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontrolleBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSelectTop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            this.tabBgPosition.SuspendLayout();
            this.tpgVerlauf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBewilligung)).BeginInit();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpgEinzelzahlung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSollHaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLetzte10Buchungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSollHaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontrolle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontrolleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsnummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeamZustaendig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeamZustaendig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutomAnfrage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFortschritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPersonTermin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMutation)).BeginInit();
            this.panDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(912, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(936, 258);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdEinzelzahlung);
            this.tpgListe.Size = new System.Drawing.Size(924, 220);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheMutationBis);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationVon);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationMA);
            this.tpgSuchen.Controls.Add(this.lblSucheMutation);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.edtSucheSelectTop);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.lblSucheBelegID);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheFallNr);
            this.tpgSuchen.Controls.Add(this.lblSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheBelegID);
            this.tpgSuchen.Controls.Add(this.edtSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaBis);
            this.tpgSuchen.Controls.Add(this.lblSucheValutaBis);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaVon);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheKontrolleBis);
            this.tpgSuchen.Controls.Add(this.edtSucheKontrolleVon);
            this.tpgSuchen.Controls.Add(this.lblSucheValutaVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKontrolleMA);
            this.tpgSuchen.Controls.Add(this.lblSucheKontrolle);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungBis);
            this.tpgSuchen.Controls.Add(this.lblSucheErfassung);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungVon);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungMA);
            this.tpgSuchen.Size = new System.Drawing.Size(924, 220);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheErfassung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKontrolle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKontrolleMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKontrolleVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKontrolleBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBelegID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSelectTop, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMutation, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationBis, 0);
            // 
            // grdEinzelzahlung
            // 
            this.grdEinzelzahlung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEinzelzahlung.DataSource = this.qryBgPosition;
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
            this.grdEinzelzahlung.Size = new System.Drawing.Size(924, 217);
            this.grdEinzelzahlung.TabIndex = 0;
            this.grdEinzelzahlung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinzelzahlung});
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.DeleteQuestion = "Soll die Position gelöscht werden ?";
            this.qryBgPosition.FillTimeOut = 120;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.IsIdentityInsert = false;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterDelete += new System.EventHandler(this.qryBgPosition_AfterDelete);
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforeDelete += new System.EventHandler(this.qryBgPosition_BeforeDelete);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.BeforeInsert += new System.EventHandler(this.qryBgPosition_BeforeInsert);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgPosition_ColumnChanged);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
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
            this.colKat,
            this.colValuta,
            this.colKlient,
            this.colKOA,
            this.colBuchungstext,
            this.colBetrag,
            this.colTyp,
            this.colKreditor,
            this.colDoc,
            this.colRechnungsnummer,
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
            // colKat
            // 
            this.colKat.AppearanceCell.Options.UseTextOptions = true;
            this.colKat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKat.Caption = "Kat.";
            this.colKat.FieldName = "BgKategorieCode";
            this.colKat.Name = "colKat";
            this.colKat.OptionsColumn.AllowEdit = false;
            this.colKat.Visible = true;
            this.colKat.VisibleIndex = 0;
            this.colKat.Width = 34;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 1;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 119;
            // 
            // colKOA
            // 
            this.colKOA.Caption = "LA";
            this.colKOA.FieldName = "KOA";
            this.colKOA.Name = "colKOA";
            this.colKOA.OptionsColumn.AllowEdit = false;
            this.colKOA.Visible = true;
            this.colKOA.VisibleIndex = 3;
            this.colKOA.Width = 48;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 156;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "BetragSpezial";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            // 
            // colTyp
            // 
            this.colTyp.AppearanceCell.Options.UseTextOptions = true;
            this.colTyp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTyp.AppearanceHeader.Options.UseTextOptions = true;
            this.colTyp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTyp.Caption = "*";
            this.colTyp.FieldName = "HauptPos";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 6;
            this.colTyp.Width = 20;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.OptionsColumn.AllowEdit = false;
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 7;
            this.colKreditor.Width = 124;
            // 
            // colDoc
            // 
            this.colDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.Caption = "Dok";
            this.colDoc.FieldName = "Doc";
            this.colDoc.Name = "colDoc";
            this.colDoc.Visible = true;
            this.colDoc.VisibleIndex = 8;
            this.colDoc.Width = 32;
            // 
            // colRechnungsnummer
            // 
            this.colRechnungsnummer.Caption = "Rg.Nr.";
            this.colRechnungsnummer.FieldName = "Rechnungsnummer";
            this.colRechnungsnummer.Name = "colRechnungsnummer";
            this.colRechnungsnummer.Visible = true;
            this.colRechnungsnummer.VisibleIndex = 9;
            // 
            // colMA
            // 
            this.colMA.Caption = "erfasst";
            this.colMA.FieldName = "MA";
            this.colMA.Name = "colMA";
            this.colMA.OptionsColumn.AllowEdit = false;
            this.colMA.Visible = true;
            this.colMA.VisibleIndex = 10;
            this.colMA.Width = 62;
            // 
            // colPosStatus
            // 
            this.colPosStatus.Caption = "Stat.";
            this.colPosStatus.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colPosStatus.FieldName = "Status";
            this.colPosStatus.Name = "colPosStatus";
            this.colPosStatus.OptionsColumn.AllowEdit = false;
            this.colPosStatus.Visible = true;
            this.colPosStatus.VisibleIndex = 11;
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
            serializableAppearanceObject27.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject27.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject27)});
            this.edtSucheErfassungMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheErfassungMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungMA.TabIndex = 5;
            this.edtSucheErfassungMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMitarbeiter_UserModifiedFld);
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
            serializableAppearanceObject26.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject26.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject26)});
            this.edtSucheErfassungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungVon.Properties.ShowToday = false;
            this.edtSucheErfassungVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungVon.TabIndex = 6;
            // 
            // lblSucheErfassung
            // 
            this.lblSucheErfassung.Location = new System.Drawing.Point(8, 54);
            this.lblSucheErfassung.Name = "lblSucheErfassung";
            this.lblSucheErfassung.Size = new System.Drawing.Size(93, 24);
            this.lblSucheErfassung.TabIndex = 4;
            this.lblSucheErfassung.Text = "Erfassung";
            this.lblSucheErfassung.UseCompatibleTextRendering = true;
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
            serializableAppearanceObject25.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject25.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject25)});
            this.edtSucheErfassungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungBis.Properties.ShowToday = false;
            this.edtSucheErfassungBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungBis.TabIndex = 7;
            // 
            // lblSucheKontrolle
            // 
            this.lblSucheKontrolle.Location = new System.Drawing.Point(8, 115);
            this.lblSucheKontrolle.Name = "lblSucheKontrolle";
            this.lblSucheKontrolle.Size = new System.Drawing.Size(82, 24);
            this.lblSucheKontrolle.TabIndex = 12;
            this.lblSucheKontrolle.Text = "Kontrolle";
            this.lblSucheKontrolle.UseCompatibleTextRendering = true;
            // 
            // edtSucheKontrolleMA
            // 
            this.edtSucheKontrolleMA.Location = new System.Drawing.Point(107, 115);
            this.edtSucheKontrolleMA.Name = "edtSucheKontrolleMA";
            this.edtSucheKontrolleMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKontrolleMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKontrolleMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKontrolleMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKontrolleMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKontrolleMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKontrolleMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject24.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject24.Options.UseBackColor = true;
            this.edtSucheKontrolleMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject24)});
            this.edtSucheKontrolleMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKontrolleMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheKontrolleMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheKontrolleMA.TabIndex = 13;
            this.edtSucheKontrolleMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMitarbeiter_UserModifiedFld);
            // 
            // lblSucheValutaVon
            // 
            this.lblSucheValutaVon.Location = new System.Drawing.Point(8, 153);
            this.lblSucheValutaVon.Name = "lblSucheValutaVon";
            this.lblSucheValutaVon.Size = new System.Drawing.Size(72, 24);
            this.lblSucheValutaVon.TabIndex = 16;
            this.lblSucheValutaVon.Text = "Valuta von";
            this.lblSucheValutaVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheKontrolleVon
            // 
            this.edtSucheKontrolleVon.EditValue = null;
            this.edtSucheKontrolleVon.Location = new System.Drawing.Point(213, 115);
            this.edtSucheKontrolleVon.Name = "edtSucheKontrolleVon";
            this.edtSucheKontrolleVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheKontrolleVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKontrolleVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKontrolleVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKontrolleVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKontrolleVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKontrolleVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKontrolleVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.edtSucheKontrolleVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheKontrolleVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.edtSucheKontrolleVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKontrolleVon.Properties.ShowToday = false;
            this.edtSucheKontrolleVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheKontrolleVon.TabIndex = 14;
            // 
            // edtSucheKontrolleBis
            // 
            this.edtSucheKontrolleBis.EditValue = null;
            this.edtSucheKontrolleBis.Location = new System.Drawing.Point(319, 115);
            this.edtSucheKontrolleBis.Name = "edtSucheKontrolleBis";
            this.edtSucheKontrolleBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheKontrolleBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKontrolleBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKontrolleBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKontrolleBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKontrolleBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKontrolleBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKontrolleBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtSucheKontrolleBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheKontrolleBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtSucheKontrolleBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKontrolleBis.Properties.ShowToday = false;
            this.edtSucheKontrolleBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheKontrolleBis.TabIndex = 15;
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(107, 26);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(90, 24);
            this.lblSucheMitarbeiter.TabIndex = 1;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaVon
            // 
            this.edtSucheValutaVon.EditValue = null;
            this.edtSucheValutaVon.Location = new System.Drawing.Point(107, 153);
            this.edtSucheValutaVon.Name = "edtSucheValutaVon";
            this.edtSucheValutaVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.edtSucheValutaVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaVon.Properties.ShowToday = false;
            this.edtSucheValutaVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaVon.TabIndex = 17;
            // 
            // lblSucheValutaBis
            // 
            this.lblSucheValutaBis.Location = new System.Drawing.Point(224, 153);
            this.lblSucheValutaBis.Name = "lblSucheValutaBis";
            this.lblSucheValutaBis.Size = new System.Drawing.Size(27, 24);
            this.lblSucheValutaBis.TabIndex = 18;
            this.lblSucheValutaBis.Text = "bis";
            this.lblSucheValutaBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaBis
            // 
            this.edtSucheValutaBis.EditValue = null;
            this.edtSucheValutaBis.Location = new System.Drawing.Point(263, 153);
            this.edtSucheValutaBis.Name = "edtSucheValutaBis";
            this.edtSucheValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtSucheValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaBis.Properties.ShowToday = false;
            this.edtSucheValutaBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaBis.TabIndex = 19;
            // 
            // edtSucheStatus
            // 
            this.edtSucheStatus.Location = new System.Drawing.Point(107, 182);
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
            this.edtSucheStatus.TabIndex = 21;
            // 
            // edtSucheBelegID
            // 
            this.edtSucheBelegID.Location = new System.Drawing.Point(558, 54);
            this.edtSucheBelegID.Name = "edtSucheBelegID";
            this.edtSucheBelegID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBelegID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBelegID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBelegID.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBelegID.TabIndex = 23;
            // 
            // lblSucheStatus
            // 
            this.lblSucheStatus.Location = new System.Drawing.Point(8, 183);
            this.lblSucheStatus.Name = "lblSucheStatus";
            this.lblSucheStatus.Size = new System.Drawing.Size(72, 24);
            this.lblSucheStatus.TabIndex = 20;
            this.lblSucheStatus.Text = "Status";
            this.lblSucheStatus.UseCompatibleTextRendering = true;
            // 
            // edtSucheFallNr
            // 
            this.edtSucheFallNr.Location = new System.Drawing.Point(558, 85);
            this.edtSucheFallNr.Name = "edtSucheFallNr";
            this.edtSucheFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFallNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheFallNr.TabIndex = 25;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(213, 27);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(82, 24);
            this.lblSucheDatumVon.TabIndex = 2;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(319, 27);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(82, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "Datum bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheBelegID
            // 
            this.lblSucheBelegID.Location = new System.Drawing.Point(464, 54);
            this.lblSucheBelegID.Name = "lblSucheBelegID";
            this.lblSucheBelegID.Size = new System.Drawing.Size(51, 24);
            this.lblSucheBelegID.TabIndex = 22;
            this.lblSucheBelegID.Text = "Beleg-ID";
            this.lblSucheBelegID.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(464, 85);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(51, 24);
            this.kissLabel1.TabIndex = 24;
            this.kissLabel1.Text = "Fall-Nr.";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtSucheSelectTop
            // 
            this.edtSucheSelectTop.Location = new System.Drawing.Point(558, 159);
            this.edtSucheSelectTop.Name = "edtSucheSelectTop";
            this.edtSucheSelectTop.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheSelectTop.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSelectTop.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSelectTop.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSelectTop.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSelectTop.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSelectTop.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSelectTop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheSelectTop.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSelectTop.Size = new System.Drawing.Size(99, 24);
            this.edtSucheSelectTop.TabIndex = 27;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(464, 159);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(88, 24);
            this.kissLabel2.TabIndex = 26;
            this.kissLabel2.Text = "max. Datensätze";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // btnEinzelzahlungen
            // 
            this.btnEinzelzahlungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEinzelzahlungen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinzelzahlungen.Location = new System.Drawing.Point(797, 6);
            this.btnEinzelzahlungen.Name = "btnEinzelzahlungen";
            this.btnEinzelzahlungen.Size = new System.Drawing.Size(124, 24);
            this.btnEinzelzahlungen.TabIndex = 29;
            this.btnEinzelzahlungen.Text = "Positionen anfragen";
            this.btnEinzelzahlungen.UseCompatibleTextRendering = true;
            this.btnEinzelzahlungen.UseVisualStyleBackColor = false;
            this.btnEinzelzahlungen.Visible = false;
            this.btnEinzelzahlungen.Click += new System.EventHandler(this.btnEinzelzahlungen_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(743, 6);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(48, 24);
            this.btnKeine.TabIndex = 28;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseCompatibleTextRendering = true;
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Visible = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(689, 6);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(48, 24);
            this.btnAlle.TabIndex = 27;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseCompatibleTextRendering = true;
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Visible = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // tabBgPosition
            // 
            this.tabBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBgPosition.Controls.Add(this.tpgVerlauf);
            this.tabBgPosition.Controls.Add(this.tpgDokumente);
            this.tabBgPosition.Controls.Add(this.tpgEinzelzahlung);
            this.tabBgPosition.Location = new System.Drawing.Point(0, 36);
            this.tabBgPosition.Name = "tabBgPosition";
            this.tabBgPosition.ShowFixedWidthTooltip = true;
            this.tabBgPosition.Size = new System.Drawing.Size(936, 594);
            this.tabBgPosition.TabIndex = 4;
            this.tabBgPosition.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgEinzelzahlung,
            this.tpgDokumente,
            this.tpgVerlauf});
            this.tabBgPosition.TabsLineColor = System.Drawing.Color.Black;
            this.tabBgPosition.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBgPosition.Text = "kissTabControlEx1";
            // 
            // tpgVerlauf
            // 
            this.tpgVerlauf.Controls.Add(this.edtBgBewilligungBemerkung);
            this.tpgVerlauf.Controls.Add(this.kissLabel5);
            this.tpgVerlauf.Controls.Add(this.kissTextEdit1);
            this.tpgVerlauf.Controls.Add(this.kissLabel8);
            this.tpgVerlauf.Controls.Add(this.kissTextEdit2);
            this.tpgVerlauf.Controls.Add(this.kissLabel7);
            this.tpgVerlauf.Controls.Add(this.grdBewilligung);
            this.tpgVerlauf.Location = new System.Drawing.Point(6, 6);
            this.tpgVerlauf.Margin = new System.Windows.Forms.Padding(9);
            this.tpgVerlauf.Name = "tpgVerlauf";
            this.tpgVerlauf.Size = new System.Drawing.Size(924, 556);
            this.tpgVerlauf.TabIndex = 2;
            this.tpgVerlauf.Title = "Verlauf";
            // 
            // edtBgBewilligungBemerkung
            // 
            this.edtBgBewilligungBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBgBewilligungBemerkung.DataMember = "Bemerkung";
            this.edtBgBewilligungBemerkung.DataSource = this.qryBgBewilligung;
            this.edtBgBewilligungBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgBewilligungBemerkung.Location = new System.Drawing.Point(81, 496);
            this.edtBgBewilligungBemerkung.Name = "edtBgBewilligungBemerkung";
            this.edtBgBewilligungBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgBewilligungBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgBewilligungBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgBewilligungBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgBewilligungBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgBewilligungBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBgBewilligungBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgBewilligungBemerkung.Properties.ReadOnly = true;
            this.edtBgBewilligungBemerkung.Size = new System.Drawing.Size(840, 54);
            this.edtBgBewilligungBemerkung.TabIndex = 6;
            // 
            // qryBgBewilligung
            // 
            this.qryBgBewilligung.HostControl = this;
            this.qryBgBewilligung.IsIdentityInsert = false;
            this.qryBgBewilligung.SelectStatement = resources.GetString("qryBgBewilligung.SelectStatement");
            this.qryBgBewilligung.TableName = "BgBewilligung";
            // 
            // kissLabel5
            // 
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.Location = new System.Drawing.Point(3, 496);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(72, 24);
            this.kissLabel5.TabIndex = 5;
            this.kissLabel5.Text = "Bemerkung";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit1.DataMember = "EmpfaengerText";
            this.kissTextEdit1.DataSource = this.qryBgBewilligung;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(81, 466);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(383, 24);
            this.kissTextEdit1.TabIndex = 4;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel8.Location = new System.Drawing.Point(3, 466);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(72, 24);
            this.kissLabel8.TabIndex = 3;
            this.kissLabel8.Text = "Empfänger";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit2
            // 
            this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit2.DataMember = "AbsenderText";
            this.kissTextEdit2.DataSource = this.qryBgBewilligung;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(81, 436);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(383, 24);
            this.kissTextEdit2.TabIndex = 2;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel7.Location = new System.Drawing.Point(3, 436);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(72, 24);
            this.kissLabel7.TabIndex = 1;
            this.kissLabel7.Text = "Absender";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // grdBewilligung
            // 
            this.grdBewilligung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBewilligung.DataSource = this.qryBgBewilligung;
            // 
            // 
            // 
            this.grdBewilligung.EmbeddedNavigator.Name = "";
            this.grdBewilligung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBewilligung.Location = new System.Drawing.Point(3, 3);
            this.grdBewilligung.MainView = this.grvBewilligung;
            this.grdBewilligung.Name = "grdBewilligung";
            this.grdBewilligung.Size = new System.Drawing.Size(918, 427);
            this.grdBewilligung.TabIndex = 0;
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
            this.grvBewilligung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBewilligung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBewilligung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBewilligung.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.colAbsender,
            this.colEmpfaenger,
            this.colBgBewilligungCode,
            this.colBemerkungen,
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
            this.colDatum.Width = 80;
            // 
            // colAbsender
            // 
            this.colAbsender.Caption = "Absender";
            this.colAbsender.FieldName = "Absender";
            this.colAbsender.Name = "colAbsender";
            this.colAbsender.Visible = true;
            this.colAbsender.VisibleIndex = 1;
            this.colAbsender.Width = 137;
            // 
            // colEmpfaenger
            // 
            this.colEmpfaenger.Caption = "Empfänger";
            this.colEmpfaenger.FieldName = "Empfaenger";
            this.colEmpfaenger.Name = "colEmpfaenger";
            this.colEmpfaenger.Visible = true;
            this.colEmpfaenger.VisibleIndex = 2;
            this.colEmpfaenger.Width = 127;
            // 
            // colBgBewilligungCode
            // 
            this.colBgBewilligungCode.Caption = "Typ";
            this.colBgBewilligungCode.FieldName = "BgBewilligungCode";
            this.colBgBewilligungCode.Name = "colBgBewilligungCode";
            this.colBgBewilligungCode.Visible = true;
            this.colBgBewilligungCode.VisibleIndex = 3;
            this.colBgBewilligungCode.Width = 150;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkung";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 4;
            this.colBemerkungen.Width = 180;
            // 
            // colHerkunft
            // 
            this.colHerkunft.Caption = "Herkunft";
            this.colHerkunft.FieldName = "Herkunft";
            this.colHerkunft.Name = "colHerkunft";
            this.colHerkunft.Visible = true;
            this.colHerkunft.VisibleIndex = 5;
            this.colHerkunft.Width = 160;
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.edtDocument);
            this.tpgDokumente.Controls.Add(this.lblDokument);
            this.tpgDokumente.Controls.Add(this.edtStichwort);
            this.tpgDokumente.Controls.Add(this.lblStichwort);
            this.tpgDokumente.Controls.Add(this.edtDokumentTyp);
            this.tpgDokumente.Controls.Add(this.lblDokumentTyp);
            this.tpgDokumente.Controls.Add(this.grdDoc);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Margin = new System.Windows.Forms.Padding(9);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(924, 556);
            this.tpgDokumente.TabIndex = 1;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDocument.CanDeleteDocument = false;
            this.edtDocument.Context = "FaDokumente";
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryBgDokumente;
            this.edtDocument.Location = new System.Drawing.Point(804, 526);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            serializableAppearanceObject28.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject28.Options.UseBackColor = true;
            serializableAppearanceObject29.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject29.Options.UseBackColor = true;
            serializableAppearanceObject30.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject30.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject28, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject29, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject30, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(117, 24);
            this.edtDocument.TabIndex = 6;
            this.edtDocument.DocumentImported += new System.EventHandler(this.edtDocument_DocumentImported);
            this.edtDocument.DocumentImporting += new System.ComponentModel.CancelEventHandler(this.edtDocument_DocumentImporting);
            // 
            // qryBgDokumente
            // 
            this.qryBgDokumente.CanDelete = true;
            this.qryBgDokumente.CanInsert = true;
            this.qryBgDokumente.CanUpdate = true;
            this.qryBgDokumente.DeleteQuestion = "Soll das Dokument gelöscht werden ?";
            this.qryBgDokumente.HostControl = this;
            this.qryBgDokumente.IsIdentityInsert = false;
            this.qryBgDokumente.SelectStatement = resources.GetString("qryBgDokumente.SelectStatement");
            this.qryBgDokumente.TableName = "BgDokument";
            this.qryBgDokumente.AfterDelete += new System.EventHandler(this.qryBgDokumente_AfterDelete);
            this.qryBgDokumente.AfterInsert += new System.EventHandler(this.qryBgDokumente_AfterInsert);
            this.qryBgDokumente.AfterPost += new System.EventHandler(this.qryBgDokumente_AfterPost);
            this.qryBgDokumente.BeforeDelete += new System.EventHandler(this.qryBgDokumente_BeforeDelete);
            this.qryBgDokumente.BeforePost += new System.EventHandler(this.qryBgDokumente_BeforePost);
            this.qryBgDokumente.PostCompleted += new System.EventHandler(this.qryBgDokumente_PostCompleted);
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDokument.Location = new System.Drawing.Point(739, 526);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(59, 24);
            this.lblDokument.TabIndex = 5;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryBgDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(240, 526);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(493, 24);
            this.edtStichwort.TabIndex = 4;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(179, 526);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(55, 24);
            this.lblStichwort.TabIndex = 3;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtDokumentTyp
            // 
            this.edtDokumentTyp.AllowNull = false;
            this.edtDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokumentTyp.DataMember = "BgDokumentTypCode";
            this.edtDokumentTyp.DataSource = this.qryBgDokumente;
            this.edtDokumentTyp.Location = new System.Drawing.Point(39, 526);
            this.edtDokumentTyp.LOVName = "BgDokumentTyp";
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDokumentTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentTyp.Properties.NullText = "";
            this.edtDokumentTyp.Properties.ShowFooter = false;
            this.edtDokumentTyp.Properties.ShowHeader = false;
            this.edtDokumentTyp.Size = new System.Drawing.Size(134, 24);
            this.edtDokumentTyp.TabIndex = 2;
            // 
            // lblDokumentTyp
            // 
            this.lblDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumentTyp.Location = new System.Drawing.Point(3, 526);
            this.lblDokumentTyp.Name = "lblDokumentTyp";
            this.lblDokumentTyp.Size = new System.Drawing.Size(30, 24);
            this.lblDokumentTyp.TabIndex = 1;
            this.lblDokumentTyp.Text = "Typ";
            this.lblDokumentTyp.UseCompatibleTextRendering = true;
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDoc.DataSource = this.qryBgDokumente;
            // 
            // 
            // 
            this.grdDoc.EmbeddedNavigator.Name = "";
            this.grdDoc.Location = new System.Drawing.Point(3, 3);
            this.grdDoc.MainView = this.gridView1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.Size = new System.Drawing.Size(918, 517);
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
            this.colDocTyp.FieldName = "BgDokumentTypCode";
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
            // tpgEinzelzahlung
            // 
            this.tpgEinzelzahlung.AutoScroll = true;
            this.tpgEinzelzahlung.AutoScrollMinSize = new System.Drawing.Size(810, 500);
            this.tpgEinzelzahlung.Controls.Add(this.grdSollHaben);
            this.tpgEinzelzahlung.Controls.Add(this.lblKontrolle);
            this.tpgEinzelzahlung.Controls.Add(this.lblKontrolleText);
            this.tpgEinzelzahlung.Controls.Add(this.edtRechnungsnummer);
            this.tpgEinzelzahlung.Controls.Add(this.lblRechnungsnummer);
            this.tpgEinzelzahlung.Controls.Add(this.btnDocument);
            this.tpgEinzelzahlung.Controls.Add(this.edtBuchungstext);
            this.tpgEinzelzahlung.Controls.Add(this.edtTeamZustaendig);
            this.tpgEinzelzahlung.Controls.Add(this.lblTeamZustaendig);
            this.tpgEinzelzahlung.Controls.Add(this.btnPositionGruen);
            this.tpgEinzelzahlung.Controls.Add(this.btnPositionGrau);
            this.tpgEinzelzahlung.Controls.Add(this.edtAdresse);
            this.tpgEinzelzahlung.Controls.Add(this.edtKlientID);
            this.tpgEinzelzahlung.Controls.Add(this.btnWeitereKOA);
            this.tpgEinzelzahlung.Controls.Add(this.btnPositionBewilligung);
            this.tpgEinzelzahlung.Controls.Add(this.edtFallNr);
            this.tpgEinzelzahlung.Controls.Add(this.lblFallNr);
            this.tpgEinzelzahlung.Controls.Add(this.ctlErfassungMutation1);
            this.tpgEinzelzahlung.Controls.Add(this.edtBgSplittingCode);
            this.tpgEinzelzahlung.Controls.Add(this.lblBgSplittingCode);
            this.tpgEinzelzahlung.Controls.Add(this.edtVerwPeriodeBis);
            this.tpgEinzelzahlung.Controls.Add(this.lblVerwPeriodeStrich);
            this.tpgEinzelzahlung.Controls.Add(this.edtVerwPeriodeVon);
            this.tpgEinzelzahlung.Controls.Add(this.lblVerwPeriode);
            this.tpgEinzelzahlung.Controls.Add(this.edtBemerkung);
            this.tpgEinzelzahlung.Controls.Add(this.lblBemerkung);
            this.tpgEinzelzahlung.Controls.Add(this.edtMitteilungZeile2);
            this.tpgEinzelzahlung.Controls.Add(this.edtMitteilungZeile1);
            this.tpgEinzelzahlung.Controls.Add(this.lblZahlungsgrund);
            this.tpgEinzelzahlung.Controls.Add(this.edtReferenzNummer);
            this.tpgEinzelzahlung.Controls.Add(this.lblReferenzNummer);
            this.tpgEinzelzahlung.Controls.Add(this.edtZusatzInfo);
            this.tpgEinzelzahlung.Controls.Add(this.edtKreditor);
            this.tpgEinzelzahlung.Controls.Add(this.lblKreditor);
            this.tpgEinzelzahlung.Controls.Add(this.edtValutaDatum);
            this.tpgEinzelzahlung.Controls.Add(this.lblValutaDatum);
            this.tpgEinzelzahlung.Controls.Add(this.btnMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.grdMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.lblMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.edtBgSpezkontoID);
            this.tpgEinzelzahlung.Controls.Add(this.lblBgSpezkontoID);
            this.tpgEinzelzahlung.Controls.Add(this.edtBaPersonID);
            this.tpgEinzelzahlung.Controls.Add(this.lblBaPersonID);
            this.tpgEinzelzahlung.Controls.Add(this.edtBetrag);
            this.tpgEinzelzahlung.Controls.Add(this.lblBetrag);
            this.tpgEinzelzahlung.Controls.Add(this.lblBuchungstext);
            this.tpgEinzelzahlung.Controls.Add(this.edtKostenart);
            this.tpgEinzelzahlung.Controls.Add(this.lblKostenart);
            this.tpgEinzelzahlung.Controls.Add(this.label1);
            this.tpgEinzelzahlung.Controls.Add(this.edtKlient);
            this.tpgEinzelzahlung.Controls.Add(this.lblKlient);
            this.tpgEinzelzahlung.Controls.Add(this.edtKategorie);
            this.tpgEinzelzahlung.Controls.Add(this.lblKategorie);
            this.tpgEinzelzahlung.Location = new System.Drawing.Point(6, 6);
            this.tpgEinzelzahlung.Margin = new System.Windows.Forms.Padding(9);
            this.tpgEinzelzahlung.Name = "tpgEinzelzahlung";
            this.tpgEinzelzahlung.Size = new System.Drawing.Size(924, 556);
            this.tpgEinzelzahlung.TabIndex = 0;
            this.tpgEinzelzahlung.Title = "Einzelzahlung";
            // 
            // grdSollHaben
            // 
            this.grdSollHaben.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdSollHaben.DataSource = this.qryLetzte10Buchungen;
            // 
            // 
            // 
            this.grdSollHaben.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdSollHaben.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdSollHaben.Location = new System.Drawing.Point(6, 416);
            this.grdSollHaben.MainView = this.grvSollHaben;
            this.grdSollHaben.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.grdSollHaben.Name = "grdSollHaben";
            this.grdSollHaben.Size = new System.Drawing.Size(787, 140);
            this.grdSollHaben.TabIndex = 585;
            this.grdSollHaben.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSollHaben});
            // 
            // qryLetzte10Buchungen
            // 
            this.qryLetzte10Buchungen.HostControl = this;
            this.qryLetzte10Buchungen.IsIdentityInsert = false;
            this.qryLetzte10Buchungen.SelectStatement = resources.GetString("qryLetzte10Buchungen.SelectStatement");
            this.qryLetzte10Buchungen.TableName = "BgBudget";
            // 
            // grvSollHaben
            // 
            this.grvSollHaben.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSollHaben.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.Empty.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.Empty.Options.UseFont = true;
            this.grvSollHaben.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvSollHaben.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.EvenRow.Options.UseFont = true;
            this.grvSollHaben.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSollHaben.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSollHaben.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSollHaben.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSollHaben.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSollHaben.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSollHaben.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSollHaben.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSollHaben.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSollHaben.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSollHaben.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvSollHaben.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSollHaben.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSollHaben.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSollHaben.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSollHaben.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.GroupRow.Options.UseFont = true;
            this.grvSollHaben.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSollHaben.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSollHaben.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSollHaben.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSollHaben.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSollHaben.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSollHaben.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSollHaben.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSollHaben.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSollHaben.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSollHaben.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSollHaben.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.OddRow.Options.UseFont = true;
            this.grvSollHaben.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSollHaben.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.Row.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.Row.Options.UseFont = true;
            this.grvSollHaben.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvSollHaben.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollHaben.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvSollHaben.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvSollHaben.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSollHaben.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvSollHaben.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSollHaben.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSollHaben.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSollHaben.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdBuchungsdatum,
            this.grdBuchungstext,
            this.grdBetrag,
            this.grdKreditor});
            this.grvSollHaben.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSollHaben.GridControl = this.grdSollHaben;
            this.grvSollHaben.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvSollHaben.Name = "grvSollHaben";
            this.grvSollHaben.OptionsBehavior.Editable = false;
            this.grvSollHaben.OptionsCustomization.AllowFilter = false;
            this.grvSollHaben.OptionsFilter.AllowFilterEditor = false;
            this.grvSollHaben.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSollHaben.OptionsMenu.EnableColumnMenu = false;
            this.grvSollHaben.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSollHaben.OptionsNavigation.UseTabKey = false;
            this.grvSollHaben.OptionsView.ColumnAutoWidth = false;
            this.grvSollHaben.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSollHaben.OptionsView.ShowGroupPanel = false;
            this.grvSollHaben.OptionsView.ShowIndicator = false;
            // 
            // grdBuchungsdatum
            // 
            this.grdBuchungsdatum.Caption = "Buchungsdatum";
            this.grdBuchungsdatum.FieldName = "Buchungsdatum";
            this.grdBuchungsdatum.Name = "grdBuchungsdatum";
            this.grdBuchungsdatum.Visible = true;
            this.grdBuchungsdatum.VisibleIndex = 0;
            this.grdBuchungsdatum.Width = 100;
            // 
            // grdBuchungstext
            // 
            this.grdBuchungstext.Caption = "Buchungstext";
            this.grdBuchungstext.FieldName = "Buchungstext";
            this.grdBuchungstext.Name = "grdBuchungstext";
            this.grdBuchungstext.Visible = true;
            this.grdBuchungstext.VisibleIndex = 1;
            this.grdBuchungstext.Width = 325;
            // 
            // grdBetrag
            // 
            this.grdBetrag.Caption = "Betrag";
            this.grdBetrag.DisplayFormat.FormatString = "n2";
            this.grdBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grdBetrag.FieldName = "Betrag";
            this.grdBetrag.Name = "grdBetrag";
            this.grdBetrag.Visible = true;
            this.grdBetrag.VisibleIndex = 2;
            this.grdBetrag.Width = 82;
            // 
            // grdKreditor
            // 
            this.grdKreditor.Caption = "Kreditor";
            this.grdKreditor.FieldName = "Kreditor";
            this.grdKreditor.Name = "grdKreditor";
            this.grdKreditor.Visible = true;
            this.grdKreditor.VisibleIndex = 3;
            this.grdKreditor.Width = 233;
            // 
            // lblKontrolle
            // 
            this.lblKontrolle.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKontrolle.Location = new System.Drawing.Point(590, 392);
            this.lblKontrolle.Name = "lblKontrolle";
            this.lblKontrolle.Size = new System.Drawing.Size(204, 18);
            this.lblKontrolle.TabIndex = 584;
            this.lblKontrolle.Text = "---";
            this.lblKontrolle.UseCompatibleTextRendering = true;
            // 
            // lblKontrolleText
            // 
            this.lblKontrolleText.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblKontrolleText.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKontrolleText.Location = new System.Drawing.Point(528, 394);
            this.lblKontrolleText.Name = "lblKontrolleText";
            this.lblKontrolleText.Size = new System.Drawing.Size(50, 18);
            this.lblKontrolleText.TabIndex = 583;
            this.lblKontrolleText.Text = "Kontrolle";
            this.lblKontrolleText.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsnummer
            // 
            this.edtRechnungsnummer.DataMember = "Rechnungsnummer";
            this.edtRechnungsnummer.DataSource = this.qryBgPosition;
            this.edtRechnungsnummer.Location = new System.Drawing.Point(528, 172);
            this.edtRechnungsnummer.Name = "edtRechnungsnummer";
            this.edtRechnungsnummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsnummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsnummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsnummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsnummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsnummer.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsnummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsnummer.Properties.MaxLength = 100;
            this.edtRechnungsnummer.Size = new System.Drawing.Size(265, 24);
            this.edtRechnungsnummer.TabIndex = 18;
            // 
            // lblRechnungsnummer
            // 
            this.lblRechnungsnummer.Location = new System.Drawing.Point(436, 173);
            this.lblRechnungsnummer.Name = "lblRechnungsnummer";
            this.lblRechnungsnummer.Size = new System.Drawing.Size(86, 24);
            this.lblRechnungsnummer.TabIndex = 582;
            this.lblRechnungsnummer.Text = "Rechn-Nr.";
            this.lblRechnungsnummer.UseCompatibleTextRendering = true;
            // 
            // btnDocument
            // 
            this.btnDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocument.Location = new System.Drawing.Point(769, 2);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(24, 24);
            this.btnDocument.TabIndex = 581;
            this.btnDocument.UseCompatibleTextRendering = true;
            this.btnDocument.UseVisualStyleBackColor = false;
            this.btnDocument.Click += new System.EventHandler(this.btnDocument_Click);
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.Location = new System.Drawing.Point(99, 107);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBuchungstext.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(317, 24);
            this.edtBuchungstext.TabIndex = 8;
            this.edtBuchungstext.TextChanged += new System.EventHandler(this.edtBuchungstext_TextChanged);
            // 
            // edtTeamZustaendig
            // 
            this.edtTeamZustaendig.DataMember = "TeamZustaendig";
            this.edtTeamZustaendig.DataSource = this.qryBgPosition;
            this.edtTeamZustaendig.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTeamZustaendig.Location = new System.Drawing.Point(650, 323);
            this.edtTeamZustaendig.Name = "edtTeamZustaendig";
            this.edtTeamZustaendig.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTeamZustaendig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTeamZustaendig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeamZustaendig.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeamZustaendig.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTeamZustaendig.Properties.Appearance.Options.UseFont = true;
            this.edtTeamZustaendig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTeamZustaendig.Properties.Name = "editPlzOrt.Properties";
            this.edtTeamZustaendig.Properties.ReadOnly = true;
            this.edtTeamZustaendig.Size = new System.Drawing.Size(143, 24);
            this.edtTeamZustaendig.TabIndex = 26;
            // 
            // lblTeamZustaendig
            // 
            this.lblTeamZustaendig.Location = new System.Drawing.Point(624, 323);
            this.lblTeamZustaendig.Name = "lblTeamZustaendig";
            this.lblTeamZustaendig.Size = new System.Drawing.Size(20, 24);
            this.lblTeamZustaendig.TabIndex = 24;
            this.lblTeamZustaendig.Text = "QT";
            this.lblTeamZustaendig.UseCompatibleTextRendering = true;
            // 
            // btnPositionGruen
            // 
            this.btnPositionGruen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionGruen.IconID = 1352;
            this.btnPositionGruen.Location = new System.Drawing.Point(235, 137);
            this.btnPositionGruen.Name = "btnPositionGruen";
            this.btnPositionGruen.Size = new System.Drawing.Size(25, 24);
            this.btnPositionGruen.TabIndex = 408;
            this.btnPositionGruen.UseCompatibleTextRendering = true;
            this.btnPositionGruen.UseVisualStyleBackColor = false;
            this.btnPositionGruen.Click += new System.EventHandler(this.btnPositionGruen_Click);
            // 
            // btnPositionGrau
            // 
            this.btnPositionGrau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionGrau.IconID = 1351;
            this.btnPositionGrau.Location = new System.Drawing.Point(266, 137);
            this.btnPositionGrau.Name = "btnPositionGrau";
            this.btnPositionGrau.Size = new System.Drawing.Size(25, 24);
            this.btnPositionGrau.TabIndex = 407;
            this.btnPositionGrau.UseCompatibleTextRendering = true;
            this.btnPositionGrau.UseVisualStyleBackColor = false;
            this.btnPositionGrau.Click += new System.EventHandler(this.btnPositionGrau_Click);
            // 
            // edtAdresse
            // 
            this.edtAdresse.DataMember = "Adresse";
            this.edtAdresse.DataSource = this.qryBgPosition;
            this.edtAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresse.Location = new System.Drawing.Point(99, 55);
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
            this.edtAdresse.Size = new System.Drawing.Size(317, 24);
            this.edtAdresse.TabIndex = 406;
            // 
            // edtKlientID
            // 
            this.edtKlientID.DataMember = "KlientID";
            this.edtKlientID.DataSource = this.qryBgPosition;
            this.edtKlientID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientID.Location = new System.Drawing.Point(350, 32);
            this.edtKlientID.Name = "edtKlientID";
            this.edtKlientID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientID.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientID.Properties.Appearance.Options.UseFont = true;
            this.edtKlientID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientID.Properties.Name = "editMandantNr.Properties";
            this.edtKlientID.Properties.ReadOnly = true;
            this.edtKlientID.Size = new System.Drawing.Size(66, 24);
            this.edtKlientID.TabIndex = 404;
            // 
            // btnWeitereKOA
            // 
            this.btnWeitereKOA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeitereKOA.Location = new System.Drawing.Point(307, 137);
            this.btnWeitereKOA.Name = "btnWeitereKOA";
            this.btnWeitereKOA.Size = new System.Drawing.Size(109, 24);
            this.btnWeitereKOA.TabIndex = 51;
            this.btnWeitereKOA.Text = "weitere LA ...";
            this.btnWeitereKOA.UseCompatibleTextRendering = true;
            this.btnWeitereKOA.UseVisualStyleBackColor = false;
            this.btnWeitereKOA.Click += new System.EventHandler(this.btnWeitereKOA_Click);
            // 
            // btnPositionBewilligung
            // 
            this.btnPositionBewilligung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionBewilligung.Image = ((System.Drawing.Image)(resources.GetObject("btnPositionBewilligung.Image")));
            this.btnPositionBewilligung.Location = new System.Drawing.Point(205, 137);
            this.btnPositionBewilligung.Name = "btnPositionBewilligung";
            this.btnPositionBewilligung.Size = new System.Drawing.Size(24, 24);
            this.btnPositionBewilligung.TabIndex = 50;
            this.btnPositionBewilligung.UseCompatibleTextRendering = true;
            this.btnPositionBewilligung.UseVisualStyleBackColor = false;
            this.btnPositionBewilligung.Click += new System.EventHandler(this.btnPositionBewilligung_Click);
            // 
            // edtFallNr
            // 
            this.edtFallNr.DataMember = "FaFallID";
            this.edtFallNr.DataSource = this.qryBgPosition;
            this.edtFallNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFallNr.Location = new System.Drawing.Point(528, 323);
            this.edtFallNr.Name = "edtFallNr";
            this.edtFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallNr.Properties.ReadOnly = true;
            this.edtFallNr.Size = new System.Drawing.Size(90, 24);
            this.edtFallNr.TabIndex = 25;
            // 
            // lblFallNr
            // 
            this.lblFallNr.Location = new System.Drawing.Point(436, 323);
            this.lblFallNr.Name = "lblFallNr";
            this.lblFallNr.Size = new System.Drawing.Size(58, 24);
            this.lblFallNr.TabIndex = 48;
            this.lblFallNr.Text = "Fall-Nr.";
            this.lblFallNr.UseCompatibleTextRendering = true;
            // 
            // ctlErfassungMutation1
            // 
            this.ctlErfassungMutation1.ActiveSQLQuery = this.qryBgPosition;
            this.ctlErfassungMutation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation1.LabelLength = 60;
            this.ctlErfassungMutation1.Location = new System.Drawing.Point(528, 354);
            this.ctlErfassungMutation1.Name = "ctlErfassungMutation1";
            this.ctlErfassungMutation1.Size = new System.Drawing.Size(265, 38);
            this.ctlErfassungMutation1.TabIndex = 47;
            // 
            // edtBgSplittingCode
            // 
            this.edtBgSplittingCode.AllowNull = false;
            this.edtBgSplittingCode.DataMember = "BgSplittingartCode";
            this.edtBgSplittingCode.DataSource = this.qryBgPosition;
            this.edtBgSplittingCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgSplittingCode.Location = new System.Drawing.Point(771, 293);
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
            this.edtBgSplittingCode.Size = new System.Drawing.Size(22, 24);
            this.edtBgSplittingCode.TabIndex = 24;
            this.edtBgSplittingCode.TabStop = false;
            // 
            // lblBgSplittingCode
            // 
            this.lblBgSplittingCode.Location = new System.Drawing.Point(728, 293);
            this.lblBgSplittingCode.Name = "lblBgSplittingCode";
            this.lblBgSplittingCode.Size = new System.Drawing.Size(37, 24);
            this.lblBgSplittingCode.TabIndex = 41;
            this.lblBgSplittingCode.Text = "Split.";
            this.lblBgSplittingCode.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeBis
            // 
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(632, 293);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeBis.TabIndex = 23;
            // 
            // lblVerwPeriodeStrich
            // 
            this.lblVerwPeriodeStrich.Location = new System.Drawing.Point(621, 293);
            this.lblVerwPeriodeStrich.Name = "lblVerwPeriodeStrich";
            this.lblVerwPeriodeStrich.Size = new System.Drawing.Size(7, 24);
            this.lblVerwPeriodeStrich.TabIndex = 39;
            this.lblVerwPeriodeStrich.Text = "-";
            this.lblVerwPeriodeStrich.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeVon
            // 
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(528, 293);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeVon.TabIndex = 22;
            // 
            // lblVerwPeriode
            // 
            this.lblVerwPeriode.Location = new System.Drawing.Point(436, 293);
            this.lblVerwPeriode.Name = "lblVerwPeriode";
            this.lblVerwPeriode.Size = new System.Drawing.Size(86, 24);
            this.lblVerwPeriode.TabIndex = 37;
            this.lblVerwPeriode.Text = "Verwendungsp.";
            this.lblVerwPeriode.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(528, 252);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(265, 35);
            this.edtBemerkung.TabIndex = 21;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(436, 252);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(86, 24);
            this.lblBemerkung.TabIndex = 35;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtMitteilungZeile2
            // 
            this.edtMitteilungZeile2.DataMember = "MitteilungZeile2";
            this.edtMitteilungZeile2.DataSource = this.qryBgPosition;
            this.edtMitteilungZeile2.Location = new System.Drawing.Point(528, 223);
            this.edtMitteilungZeile2.Name = "edtMitteilungZeile2";
            this.edtMitteilungZeile2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile2.Size = new System.Drawing.Size(265, 24);
            this.edtMitteilungZeile2.TabIndex = 20;
            // 
            // edtMitteilungZeile1
            // 
            this.edtMitteilungZeile1.DataMember = "MitteilungZeile1";
            this.edtMitteilungZeile1.DataSource = this.qryBgPosition;
            this.edtMitteilungZeile1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMitteilungZeile1.Location = new System.Drawing.Point(528, 200);
            this.edtMitteilungZeile1.Name = "edtMitteilungZeile1";
            this.edtMitteilungZeile1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMitteilungZeile1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile1.Properties.ReadOnly = true;
            this.edtMitteilungZeile1.Size = new System.Drawing.Size(265, 24);
            this.edtMitteilungZeile1.TabIndex = 19;
            // 
            // lblZahlungsgrund
            // 
            this.lblZahlungsgrund.Location = new System.Drawing.Point(436, 200);
            this.lblZahlungsgrund.Name = "lblZahlungsgrund";
            this.lblZahlungsgrund.Size = new System.Drawing.Size(86, 24);
            this.lblZahlungsgrund.TabIndex = 31;
            this.lblZahlungsgrund.Text = "Mitteilung";
            this.lblZahlungsgrund.UseCompatibleTextRendering = true;
            // 
            // edtReferenzNummer
            // 
            this.edtReferenzNummer.DataMember = "ReferenzNummer";
            this.edtReferenzNummer.DataSource = this.qryBgPosition;
            this.edtReferenzNummer.Location = new System.Drawing.Point(528, 143);
            this.edtReferenzNummer.Name = "edtReferenzNummer";
            this.edtReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenzNummer.Size = new System.Drawing.Size(265, 24);
            this.edtReferenzNummer.TabIndex = 17;
            // 
            // lblReferenzNummer
            // 
            this.lblReferenzNummer.Location = new System.Drawing.Point(436, 143);
            this.lblReferenzNummer.Name = "lblReferenzNummer";
            this.lblReferenzNummer.Size = new System.Drawing.Size(86, 24);
            this.lblReferenzNummer.TabIndex = 29;
            this.lblReferenzNummer.Text = "Ref-Nr.:";
            this.lblReferenzNummer.UseCompatibleTextRendering = true;
            // 
            // edtZusatzInfo
            // 
            this.edtZusatzInfo.DataMember = "ZusatzInfo";
            this.edtZusatzInfo.DataSource = this.qryBgPosition;
            this.edtZusatzInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZusatzInfo.Location = new System.Drawing.Point(528, 56);
            this.edtZusatzInfo.Name = "edtZusatzInfo";
            this.edtZusatzInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZusatzInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzInfo.Properties.ReadOnly = true;
            this.edtZusatzInfo.Size = new System.Drawing.Size(265, 88);
            this.edtZusatzInfo.TabIndex = 16;
            // 
            // edtKreditor
            // 
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryBgPosition;
            this.edtKreditor.Location = new System.Drawing.Point(528, 33);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKreditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKreditor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKreditor.Size = new System.Drawing.Size(265, 24);
            this.edtKreditor.TabIndex = 15;
            this.edtKreditor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKreditor_UserModifiedFld);
            // 
            // lblKreditor
            // 
            this.lblKreditor.Location = new System.Drawing.Point(436, 34);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(86, 24);
            this.lblKreditor.TabIndex = 26;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.DataMember = "ValutaDatum";
            this.edtValutaDatum.DataSource = this.qryBgPosition;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(528, 3);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(90, 24);
            this.edtValutaDatum.TabIndex = 14;
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Location = new System.Drawing.Point(436, 2);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(86, 24);
            this.lblValutaDatum.TabIndex = 22;
            this.lblValutaDatum.Text = "Valuta";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(4, 256);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(90, 24);
            this.btnMonatsbudget.TabIndex = 12;
            this.btnMonatsbudget.Text = "> Budget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // grdMonatsbudget
            // 
            this.grdMonatsbudget.DataSource = this.qryMonatsbudget;
            // 
            // 
            // 
            this.grdMonatsbudget.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdMonatsbudget.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMonatsbudget.Location = new System.Drawing.Point(100, 227);
            this.grdMonatsbudget.MainView = this.gridView2;
            this.grdMonatsbudget.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.grdMonatsbudget.Name = "grdMonatsbudget";
            this.grdMonatsbudget.Size = new System.Drawing.Size(316, 180);
            this.grdMonatsbudget.TabIndex = 13;
            this.grdMonatsbudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryMonatsbudget
            // 
            this.qryMonatsbudget.BatchUpdate = true;
            this.qryMonatsbudget.HostControl = this;
            this.qryMonatsbudget.IsIdentityInsert = false;
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
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.colAnzEZ,
            this.colAnzZL,
            this.colAktiv});
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
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 35;
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
            // colAnzZL
            // 
            this.colAnzZL.Caption = "ZL";
            this.colAnzZL.FieldName = "ZL";
            this.colAnzZL.Name = "colAnzZL";
            this.colAnzZL.Visible = true;
            this.colAnzZL.VisibleIndex = 4;
            this.colAnzZL.Width = 31;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "L aktiv";
            this.colAktiv.FieldName = "aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 5;
            this.colAktiv.Width = 46;
            // 
            // lblMonatsbudget
            // 
            this.lblMonatsbudget.Location = new System.Drawing.Point(4, 226);
            this.lblMonatsbudget.Name = "lblMonatsbudget";
            this.lblMonatsbudget.Size = new System.Drawing.Size(90, 24);
            this.lblMonatsbudget.TabIndex = 19;
            this.lblMonatsbudget.Text = "Monatsbudgets";
            this.lblMonatsbudget.UseCompatibleTextRendering = true;
            // 
            // edtBgSpezkontoID
            // 
            this.edtBgSpezkontoID.DataMember = "BgSpezkontoID";
            this.edtBgSpezkontoID.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID.Location = new System.Drawing.Point(99, 197);
            this.edtBgSpezkontoID.Name = "edtBgSpezkontoID";
            this.edtBgSpezkontoID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgSpezkontoID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSpezkontoID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBgSpezkontoID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Typ", "Typ", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOA", "KOA", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 300),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "Saldo Budget", 50, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SaldoTotal", "Saldo total", 50, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgSpezkontoID.Properties.DisplayMember = "Text";
            this.edtBgSpezkontoID.Properties.NullText = "";
            this.edtBgSpezkontoID.Properties.PopupWidth = 600;
            this.edtBgSpezkontoID.Properties.ShowFooter = false;
            this.edtBgSpezkontoID.Properties.ShowHeader = false;
            this.edtBgSpezkontoID.Properties.ValueMember = "Code";
            this.edtBgSpezkontoID.Size = new System.Drawing.Size(317, 24);
            this.edtBgSpezkontoID.TabIndex = 11;
            this.edtBgSpezkontoID.EditValueChanged += new System.EventHandler(this.edtBgSpezkontoID_EditValueChanged);
            // 
            // lblBgSpezkontoID
            // 
            this.lblBgSpezkontoID.Location = new System.Drawing.Point(4, 197);
            this.lblBgSpezkontoID.Name = "lblBgSpezkontoID";
            this.lblBgSpezkontoID.Size = new System.Drawing.Size(90, 24);
            this.lblBgSpezkontoID.TabIndex = 17;
            this.lblBgSpezkontoID.Text = "Spezialkonto";
            this.lblBgSpezkontoID.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(99, 167);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname")});
            this.edtBaPersonID.Properties.DisplayMember = "NameVorname";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(317, 24);
            this.edtBaPersonID.TabIndex = 10;
            this.edtBaPersonID.EditValueChanged += new System.EventHandler(this.edtBaPersonID_EditValueChanged);
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(4, 167);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(90, 24);
            this.lblBaPersonID.TabIndex = 15;
            this.lblBaPersonID.Text = "Betrifft Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "BetragSpezial";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(99, 137);
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
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 9;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(4, 137);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(90, 24);
            this.lblBetrag.TabIndex = 11;
            this.lblBetrag.Text = "Betrag CHF";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(4, 109);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(90, 24);
            this.lblBuchungstext.TabIndex = 9;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtKostenart
            // 
            this.edtKostenart.DataMember = "Kostenart";
            this.edtKostenart.DataSource = this.qryBgPosition;
            this.edtKostenart.Location = new System.Drawing.Point(99, 85);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKostenart.Size = new System.Drawing.Size(317, 24);
            this.edtKostenart.TabIndex = 7;
            this.edtKostenart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenart_UserModifiedFld);
            // 
            // lblKostenart
            // 
            this.lblKostenart.Location = new System.Drawing.Point(4, 84);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(90, 24);
            this.lblKostenart.TabIndex = 7;
            this.lblKostenart.Text = "LA/Positionsart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Adresse";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // edtKlient
            // 
            this.edtKlient.DataMember = "Klient";
            this.edtKlient.DataSource = this.qryBgPosition;
            this.edtKlient.Location = new System.Drawing.Point(99, 32);
            this.edtKlient.LookupSQL = "select null";
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlient.Properties.Name = "editMandant.Properties";
            this.edtKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKlient.Size = new System.Drawing.Size(253, 24);
            this.edtKlient.TabIndex = 6;
            this.edtKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKlient_UserModifiedFld);
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(4, 31);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(90, 24);
            this.lblKlient.TabIndex = 2;
            this.lblKlient.Text = "Klient/in";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // edtKategorie
            // 
            this.edtKategorie.AllowNull = false;
            this.edtKategorie.DataMember = "BgKategorieCode";
            this.edtKategorie.DataSource = this.qryBgPosition;
            this.edtKategorie.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKategorie.Location = new System.Drawing.Point(99, 3);
            this.edtKategorie.LOVFilter = "Code in (100,101)";
            this.edtKategorie.LOVFilterWhereAppend = true;
            this.edtKategorie.LOVName = "BgKategorie";
            this.edtKategorie.Name = "edtKategorie";
            this.edtKategorie.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtKategorie.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKategorie.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtKategorie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtKategorie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKategorie.Properties.NullText = "";
            this.edtKategorie.Properties.ReadOnly = true;
            this.edtKategorie.Properties.ShowFooter = false;
            this.edtKategorie.Properties.ShowHeader = false;
            this.edtKategorie.Size = new System.Drawing.Size(317, 24);
            this.edtKategorie.TabIndex = 5;
            this.edtKategorie.EditValueChanged += new System.EventHandler(this.edtKategorie_EditValueChanged);
            // 
            // lblKategorie
            // 
            this.lblKategorie.Location = new System.Drawing.Point(4, 3);
            this.lblKategorie.Name = "lblKategorie";
            this.lblKategorie.Size = new System.Drawing.Size(90, 24);
            this.lblKategorie.TabIndex = 0;
            this.lblKategorie.Text = "Kategorie";
            this.lblKategorie.UseCompatibleTextRendering = true;
            // 
            // btnZusatzleistung
            // 
            this.btnZusatzleistung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZusatzleistung.IconID = 1388;
            this.btnZusatzleistung.Location = new System.Drawing.Point(105, 6);
            this.btnZusatzleistung.Name = "btnZusatzleistung";
            this.btnZusatzleistung.Size = new System.Drawing.Size(24, 24);
            this.btnZusatzleistung.TabIndex = 2;
            this.btnZusatzleistung.UseCompatibleTextRendering = true;
            this.btnZusatzleistung.UseVisualStyleBackColor = false;
            this.btnZusatzleistung.Click += new System.EventHandler(this.btnZusatzleistung_Click);
            // 
            // edtAutomAnfrage
            // 
            this.edtAutomAnfrage.EditValue = false;
            this.edtAutomAnfrage.Location = new System.Drawing.Point(144, 9);
            this.edtAutomAnfrage.Name = "edtAutomAnfrage";
            this.edtAutomAnfrage.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAutomAnfrage.Properties.Appearance.Options.UseBackColor = true;
            this.edtAutomAnfrage.Properties.Caption = "automat. Anfrage";
            this.edtAutomAnfrage.Size = new System.Drawing.Size(124, 19);
            this.edtAutomAnfrage.TabIndex = 3;
            // 
            // lblFortschritt
            // 
            this.lblFortschritt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFortschritt.Location = new System.Drawing.Point(617, 6);
            this.lblFortschritt.Name = "lblFortschritt";
            this.lblFortschritt.Size = new System.Drawing.Size(66, 24);
            this.lblFortschritt.TabIndex = 11;
            this.lblFortschritt.Text = "Fortschritt";
            this.lblFortschritt.UseCompatibleTextRendering = true;
            this.lblFortschritt.Visible = false;
            // 
            // qryBgAuszahlungPersonTermin
            // 
            this.qryBgAuszahlungPersonTermin.BatchUpdate = true;
            this.qryBgAuszahlungPersonTermin.CanInsert = true;
            this.qryBgAuszahlungPersonTermin.CanUpdate = true;
            this.qryBgAuszahlungPersonTermin.HostControl = this;
            this.qryBgAuszahlungPersonTermin.IsIdentityInsert = false;
            this.qryBgAuszahlungPersonTermin.SelectStatement = "SELECT *\r\nFROM   dbo.BgAuszahlungPersonTermin WITH (READUNCOMMITTED)\r\nWHERE  BgAu" +
    "szahlungPersonID = {0}\r\nORDER BY Datum";
            this.qryBgAuszahlungPersonTermin.TableName = "BgAuszahlungPersonTermin";
            // 
            // edtSucheMutationBis
            // 
            this.edtSucheMutationBis.EditValue = null;
            this.edtSucheMutationBis.Location = new System.Drawing.Point(319, 85);
            this.edtSucheMutationBis.Name = "edtSucheMutationBis";
            this.edtSucheMutationBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtSucheMutationBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationBis.Properties.ShowToday = false;
            this.edtSucheMutationBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationBis.TabIndex = 11;
            // 
            // edtSucheMutationVon
            // 
            this.edtSucheMutationVon.EditValue = null;
            this.edtSucheMutationVon.Location = new System.Drawing.Point(213, 85);
            this.edtSucheMutationVon.Name = "edtSucheMutationVon";
            this.edtSucheMutationVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtSucheMutationVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationVon.Properties.ShowToday = false;
            this.edtSucheMutationVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationVon.TabIndex = 10;
            // 
            // edtSucheMutationMA
            // 
            this.edtSucheMutationMA.Location = new System.Drawing.Point(107, 85);
            this.edtSucheMutationMA.Name = "edtSucheMutationMA";
            this.edtSucheMutationMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtSucheMutationMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheMutationMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationMA.TabIndex = 9;
            this.edtSucheMutationMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMitarbeiter_UserModifiedFld);
            // 
            // lblSucheMutation
            // 
            this.lblSucheMutation.Location = new System.Drawing.Point(8, 85);
            this.lblSucheMutation.Name = "lblSucheMutation";
            this.lblSucheMutation.Size = new System.Drawing.Size(82, 24);
            this.lblSucheMutation.TabIndex = 8;
            this.lblSucheMutation.Text = "Mutation";
            this.lblSucheMutation.UseCompatibleTextRendering = true;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panDetail;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 258);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 14;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.btnEinzelzahlungen);
            this.panDetail.Controls.Add(this.btnKeine);
            this.panDetail.Controls.Add(this.lblFortschritt);
            this.panDetail.Controls.Add(this.edtAutomAnfrage);
            this.panDetail.Controls.Add(this.btnAlle);
            this.panDetail.Controls.Add(this.btnZusatzleistung);
            this.panDetail.Controls.Add(this.tabBgPosition);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetail.Location = new System.Drawing.Point(0, 266);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(936, 630);
            this.panDetail.TabIndex = 4;
            // 
            // FrmWhEinzelzahlungen
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.ClientSize = new System.Drawing.Size(936, 896);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panDetail);
            this.Name = "FrmWhEinzelzahlungen";
            this.Text = "WH Einzelzahlungen";
            this.Load += new System.EventHandler(this.FrmWhEinzelzahlungen_Load);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKontrolle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontrolleMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontrolleVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontrolleBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSelectTop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            this.tabBgPosition.ResumeLayout(false);
            this.tpgVerlauf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBewilligung)).EndInit();
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpgEinzelzahlung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSollHaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLetzte10Buchungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSollHaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontrolle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontrolleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsnummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeamZustaendig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeamZustaendig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutomAnfrage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFortschritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPersonTermin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMutation)).EndInit();
            this.panDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissButton btnDocument;
        private Gui.KissTextEdit edtRechnungsnummer;
        private Gui.KissLabel lblRechnungsnummer;
        private DevExpress.XtraGrid.Columns.GridColumn colRechnungsnummer;
        private DevExpress.XtraGrid.Columns.GridColumn colHerkunft;
        private Gui.KissLabel lblKontrolle;
        private Gui.KissLabel lblKontrolleText;
        private Gui.KissDateEdit edtSucheMutationBis;
        private Gui.KissDateEdit edtSucheMutationVon;
        private Gui.KissButtonEdit edtSucheMutationMA;
        private Gui.KissLabel lblSucheMutation;
        private Gui.KissGrid grdSollHaben;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSollHaben;
        private DevExpress.XtraGrid.Columns.GridColumn grdBuchungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn grdBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn grdBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn grdKreditor;
        private DB.SqlQuery qryLetzte10Buchungen;
        private Gui.KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnEinzelzahlungen;
        private KiSS4.Gui.KissButton btnKeine;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private KiSS4.Gui.KissButton btnPositionBewilligung;
        private KiSS4.Gui.KissButton btnPositionGrau;
        private KiSS4.Gui.KissButton btnPositionGruen;
        private KiSS4.Gui.KissButton btnWeitereKOA;
        private KiSS4.Gui.KissButton btnZusatzleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsender;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzEZ;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzZL;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBgBewilligungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpfaenger;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA;
        private DevExpress.XtraGrid.Columns.GridColumn colKat;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colPosStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation1;
        private KiSS4.Gui.KissTextEdit edtAdresse;
        private KiSS4.Gui.KissCheckEdit edtAutomAnfrage;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissMemoEdit edtBgBewilligungBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID;
        private KiSS4.Gui.KissLookUpEdit edtBgSplittingCode;
        private KiSS4.Gui.KissComboBox edtBuchungstext;
        private KiSS4.Dokument.XDokument edtDocument;
        private KiSS4.Gui.KissLookUpEdit edtDokumentTyp;
        private KiSS4.Gui.KissCalcEdit edtFallNr;
        private KiSS4.Gui.KissLookUpEdit edtKategorie;
        private KiSS4.Gui.KissButtonEdit edtKlient;
        private KiSS4.Gui.KissTextEdit edtKlientID;
        private KiSS4.Gui.KissButtonEdit edtKostenart;
        private KiSS4.Gui.KissButtonEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile1;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile2;
        private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissCalcEdit edtSucheBelegID;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungBis;
        private KiSS4.Gui.KissButtonEdit edtSucheErfassungMA;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungVon;
        private KiSS4.Gui.KissCalcEdit edtSucheFallNr;
        private KiSS4.Gui.KissDateEdit edtSucheKontrolleBis;
        private KiSS4.Gui.KissButtonEdit edtSucheKontrolleMA;
        private KiSS4.Gui.KissDateEdit edtSucheKontrolleVon;
        private KiSS4.Gui.KissCalcEdit edtSucheSelectTop;
        private KiSS4.Gui.KissImageComboBoxEdit edtSucheStatus;
        private KiSS4.Gui.KissDateEdit edtSucheValutaBis;
        private KiSS4.Gui.KissDateEdit edtSucheValutaVon;
        private KiSS4.Gui.KissTextEdit edtTeamZustaendig;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissMemoEdit edtZusatzInfo;
        private KiSS4.Gui.KissGrid grdBewilligung;
        private KiSS4.Gui.KissGrid grdDoc;
        private KiSS4.Gui.KissGrid grdEinzelzahlung;
        private KiSS4.Gui.KissGrid grdMonatsbudget;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBewilligung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinzelzahlung;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissLabel label1;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBgSpezkontoID;
        private KiSS4.Gui.KissLabel lblBgSplittingCode;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblDokumentTyp;
        private KiSS4.Gui.KissLabel lblFallNr;
        private KiSS4.Gui.KissLabel lblFortschritt;
        private KiSS4.Gui.KissLabel lblKategorie;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblMonatsbudget;
        private KiSS4.Gui.KissLabel lblReferenzNummer;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblSucheBelegID;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheErfassung;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheKontrolle;
        private KiSS4.Gui.KissLabel lblSucheStatus;
        private KiSS4.Gui.KissLabel lblSucheValutaBis;
        private KiSS4.Gui.KissLabel lblSucheValutaVon;
        private KiSS4.Gui.KissLabel lblTeamZustaendig;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblVerwPeriode;
        private KiSS4.Gui.KissLabel lblVerwPeriodeStrich;
        private KiSS4.Gui.KissLabel lblZahlungsgrund;
        private KiSS4.DB.SqlQuery qryBgAuszahlungPersonTermin;
        private KiSS4.DB.SqlQuery qryBgBewilligung;
        private KiSS4.DB.SqlQuery qryBgDokumente;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private KiSS4.DB.SqlQuery qryMonatsbudget;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private KiSS4.Gui.KissTabControlEx tabBgPosition;
        private System.Windows.Forms.ToolTip toolTip1;
        private SharpLibrary.WinControls.TabPageEx tpgVerlauf;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private SharpLibrary.WinControls.TabPageEx tpgEinzelzahlung;
        private System.Windows.Forms.Panel panDetail;
    }
}
