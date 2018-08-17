namespace KiSS4.BDE
{
    partial class CtlBDEZeiterfassung
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBDEZeiterfassung));
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblAngezeigterMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtAngezeigterMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.lblAngezeigterMAFilter = new KiSS4.Gui.KissLabel();
            this.edtAngezeigterMAFilter = new KiSS4.Gui.KissTextEdit();
            this.btnAngezeigterMAFilter = new KiSS4.Gui.KissButton();
            this.lblTagessollC = new KiSS4.Gui.KissLabel();
            this.lblTagessoll = new KiSS4.Gui.KissLabel();
            this.panZeitrechner = new System.Windows.Forms.Panel();
            this.grdZeitrechner = new KiSS4.Gui.KissGrid();
            this.qryZeitrechner = new KiSS4.DB.SqlQuery(this.components);
            this.grvZeitrechner = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPraesenzDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPraesenzZeitVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPraesenzZeitBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlZeitrechnerBottom = new System.Windows.Forms.Panel();
            this.edtZeitrechnerZeitBis = new KiSS4.Gui.KissTimeEdit();
            this.lblZeitrechnerZeitBis = new KiSS4.Gui.KissLabel();
            this.edtZeitrechnerZeitVon = new KiSS4.Gui.KissTimeEdit();
            this.lblZeitrechnerZeitVon = new KiSS4.Gui.KissLabel();
            this.edtZeitrechnerDatum = new KiSS4.Gui.KissDateEdit();
            this.lblZeitrechnerDatum = new KiSS4.Gui.KissLabel();
            this.tabZeiterfassung = new KiSS4.Gui.KissTabControlEx();
            this.tpgUebersicht = new SharpLibrary.WinControls.TabPageEx();
            this.docUebersicht = new KiSS4.Dokument.KissDocumentButton();
            this.grpUebersichtFerien = new KiSS4.Gui.KissGroupBox();
            this.lblUebersichtFerienSaldo = new KiSS4.Gui.KissLabel();
            this.panUebersichtFerienLinie = new System.Windows.Forms.Panel();
            this.lblUebersichtFerienKorrekturen = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienKorrekturenLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienZugabenKuerzungen = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienZugabenKuerzungenLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienBezogen = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienBezogenLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienAnspruch = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienAnspruchLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienUebertrag = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienUebertragLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFerienSaldoLbl = new KiSS4.Gui.KissLabel();
            this.grpUebersichtStundenlohn = new KiSS4.Gui.KissGroupBox();
            this.lblUebersichtStundenlohnIstArbeitszeit = new KiSS4.Gui.KissLabel();
            this.lblUebersichtStundenlohnIstArbeitszeitLbl = new KiSS4.Gui.KissLabel();
            this.grpUebersichtGleitzeit = new KiSS4.Gui.KissGroupBox();
            this.lblUebersichtGleitzeitSaldo = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitSaldoLbl = new KiSS4.Gui.KissLabel();
            this.panUebersichtGleitzeitLinie = new System.Windows.Forms.Panel();
            this.lblUebersichtGleitzeitBezUeberstunden = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitBezUeberstundenLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitKorrekturen = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitKorrekturenLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitSaldoUebertragMonate = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitUebertragJahr = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitUebertragJahrLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitMonatSaldo = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitMonatSaldoLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitSollMonat = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitSollMonatLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitIstArbeitszeit = new KiSS4.Gui.KissLabel();
            this.lblUebersichtGleitzeitIstArbeitszeitLbl = new KiSS4.Gui.KissLabel();
            this.grpUebersichtAllgemein = new KiSS4.Gui.KissGroupBox();
            this.lblUebersichtSollProTag = new KiSS4.Gui.KissLabel();
            this.lblUebersichtSollProTagLbl = new KiSS4.Gui.KissLabel();
            this.lblUebersichtBeschaeftigungsgrad = new KiSS4.Gui.KissLabel();
            this.lblUebersichtBeschaeftigungsgradLbl = new KiSS4.Gui.KissLabel();
            this.edtUebersichtMonat = new KiSS4.Gui.KissDateEdit();
            this.btnUebersichtNachmonat = new KiSS4.Gui.KissButton();
            this.btnUebersichtHeute = new KiSS4.Gui.KissButton();
            this.btnUebersichtVormonat = new KiSS4.Gui.KissButton();
            this.lblAktuellerMonat = new KiSS4.Gui.KissLabel();
            this.lblAktuellerMonatC = new KiSS4.Gui.KissLabel();
            this.tpgWoche = new SharpLibrary.WinControls.TabPageEx();
            this.btnWocheZuklappen = new KiSS4.Gui.KissButton();
            this.btnWocheAufklappen = new KiSS4.Gui.KissButton();
            this.grdWoche = new KiSS4.Gui.KissGrid();
            this.grvWoche = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWocheWoche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWocheTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWocheDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWocheTagesIst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWocheZeitrechnertotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWocheDifferenz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgMonat = new SharpLibrary.WinControls.TabPageEx();
            this.btnMonatFakturiertEntfernen = new KiSS4.Gui.KissButton();
            this.btnMonatFakturiertSetzen = new KiSS4.Gui.KissButton();
            this.btnMonatVisumAufheben = new KiSS4.Gui.KissButton();
            this.btnMonatVisieren = new KiSS4.Gui.KissButton();
            this.btnMonatFreigabeAufheben = new KiSS4.Gui.KissButton();
            this.btnMonatFreigeben = new KiSS4.Gui.KissButton();
            this.grdMonat = new KiSS4.Gui.KissGrid();
            this.qryMonat = new KiSS4.DB.SqlQuery(this.components);
            this.grvMonat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonatJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFreigegeben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatVisiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatVerbucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatVerbuchtLD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFakturiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatSpacer1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatBeschaeftigungsgrad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatGZIstArbeitszeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatGZSollArbeitszeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatGZMonatssaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collMonatGZSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatGZUebertragVorjahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatGZKorrekturen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatGZBezUeberstunden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatSpacer2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatSLIstArbeitszeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatSpacer3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFerienBezogenMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFerienSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFerienUebertragVorjahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFerienAnspruchProJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFerienBisherBezogen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFerienZugabenKuerzungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatFerienKorrekturen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgErfassung = new SharpLibrary.WinControls.TabPageEx();
            this.edtFakturiert = new KiSS4.Gui.KissCheckEdit();
            this.qryData = new KiSS4.DB.SqlQuery(this.components);
            this.edtErfassungKostentraeger = new KiSS4.Gui.KissLookUpEdit();
            this.lblErfassungKostentraeger = new KiSS4.Gui.KissLabel();
            this.btnKeinExportUmschalten = new KiSS4.Gui.KissButton();
            this.edtKeinExport = new KiSS4.Gui.KissCheckEdit();
            this.lblKeinExport = new KiSS4.Gui.KissLabel();
            this.panErfassungZeitInfo = new System.Windows.Forms.Panel();
            this.lblErfassungDifferenz = new KiSS4.Gui.KissLabel();
            this.lblErfassungDifferenzC = new KiSS4.Gui.KissLabel();
            this.panErfassungLineDifferenz = new System.Windows.Forms.Panel();
            this.lblErfassungTagesIst = new KiSS4.Gui.KissLabel();
            this.lblErfassungTagesIstC = new KiSS4.Gui.KissLabel();
            this.lblErfassungZeitrechnerTotal = new KiSS4.Gui.KissLabel();
            this.lblErfassungZeitrechnerTotalC = new KiSS4.Gui.KissLabel();
            this.btnErfassungKopie = new KiSS4.Gui.KissButton();
            this.memErfassungBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblErfassungBemerkungen = new KiSS4.Gui.KissLabel();
            this.btnErfassungTag1 = new KiSS4.Gui.KissButton();
            this.btnErfassungTag05 = new KiSS4.Gui.KissButton();
            this.lblErfassungMin = new KiSS4.Gui.KissLabel();
            this.edtErfassungMinuten = new KiSS4.Gui.KissCalcEdit();
            this.lblErfassungStd = new KiSS4.Gui.KissLabel();
            this.edtErfassungStunden = new KiSS4.Gui.KissCalcEdit();
            this.lblErfassungDauer = new KiSS4.Gui.KissLabel();
            this.edtErfassungLohnart = new KiSS4.Gui.KissLookUpEdit();
            this.lblErfassungLohnart = new KiSS4.Gui.KissLabel();
            this.edtErfassungKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblErfassungKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtErfassungAnzahl = new KiSS4.Gui.KissCalcEdit();
            this.lblErfassungAnzahl = new KiSS4.Gui.KissLabel();
            this.edtErfassungLeistungsart = new KiSS4.Gui.KissButtonEdit();
            this.lblErfassungLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtErfassungKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblErfassungKlient = new KiSS4.Gui.KissLabel();
            this.edtErfassungDatum = new KiSS4.Gui.KissDateEdit();
            this.tabErfassung = new KiSS4.Gui.KissTabControlEx();
            this.tpgErfassungSuche = new SharpLibrary.WinControls.TabPageEx();
            this.chkSucheVerbucht = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheBemerkung = new KiSS4.Gui.KissTextEdit();
            this.lblSucheBemerkung = new KiSS4.Gui.KissLabel();
            this.edtSucheLeistungsart = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtSucheKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheKlient = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.ttlSuche = new KiSS4.Gui.KissSearchTitel();
            this.tpgErfassungListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdBDELeistung = new KiSS4.Gui.KissGrid();
            this.grvBDELeistung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErfassungTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungLeistungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungDauer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLohnart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungFreigegeben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungVisiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repErfassungVisum = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colErfassungVerbucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKeinExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblErfassungDatum = new KiSS4.Gui.KissLabel();
            this.btnZeitrechner = new KiSS4.Gui.KissButton();
            this.qryUebersicht = new KiSS4.DB.SqlQuery(this.components);
            this.qryLohnArt = new KiSS4.DB.SqlQuery(this.components);
            this.btnStundenimport = new KiSS4.Gui.KissButton();
            this.ofdExcelImport = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngezeigterMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngezeigterMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngezeigterMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngezeigterMAFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngezeigterMAFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagessollC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagessoll)).BeginInit();
            this.panZeitrechner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZeitrechner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZeitrechner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZeitrechner)).BeginInit();
            this.pnlZeitrechnerBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitrechnerZeitBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitrechnerZeitBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitrechnerZeitVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitrechnerZeitVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitrechnerDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitrechnerDatum)).BeginInit();
            this.tabZeiterfassung.SuspendLayout();
            this.tpgUebersicht.SuspendLayout();
            this.grpUebersichtFerien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienKorrekturen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienKorrekturenLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienZugabenKuerzungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienZugabenKuerzungenLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienBezogen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienBezogenLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienAnspruch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienAnspruchLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienUebertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienUebertragLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienSaldoLbl)).BeginInit();
            this.grpUebersichtStundenlohn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtStundenlohnIstArbeitszeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtStundenlohnIstArbeitszeitLbl)).BeginInit();
            this.grpUebersichtGleitzeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldoLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitBezUeberstunden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitBezUeberstundenLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitKorrekturen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitKorrekturenLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldoUebertragMonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldoUebertragMonateLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitUebertragJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitUebertragJahrLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitMonatSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitMonatSaldoLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSollMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSollMonatLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitIstArbeitszeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitIstArbeitszeitLbl)).BeginInit();
            this.grpUebersichtAllgemein.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtSollProTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtSollProTagLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBeschaeftigungsgrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBeschaeftigungsgradLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUebersichtMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuellerMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuellerMonatC)).BeginInit();
            this.tpgWoche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWoche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWoche)).BeginInit();
            this.tpgMonat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMonat)).BeginInit();
            this.tpgErfassung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFakturiert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostentraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostentraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungKostentraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeinExport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKeinExport)).BeginInit();
            this.panErfassungZeitInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDifferenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDifferenzC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungTagesIst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungTagesIstC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungZeitrechnerTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungZeitrechnerTotalC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErfassungBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungMinuten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungStunden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungLohnart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungLohnart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungLohnart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungAnzahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungAnzahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungLeistungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungDatum.Properties)).BeginInit();
            this.tabErfassung.SuspendLayout();
            this.tpgErfassungSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheVerbucht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            this.tpgErfassungListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDELeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDELeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repErfassungVisum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUebersicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLohnArt)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAngezeigterMitarbeiter
            // 
            this.lblAngezeigterMitarbeiter.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAngezeigterMitarbeiter.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAngezeigterMitarbeiter.Location = new System.Drawing.Point(11, 10);
            this.lblAngezeigterMitarbeiter.Name = "lblAngezeigterMitarbeiter";
            this.lblAngezeigterMitarbeiter.Size = new System.Drawing.Size(187, 24);
            this.lblAngezeigterMitarbeiter.TabIndex = 0;
            this.lblAngezeigterMitarbeiter.Text = "angezeigte/r Mitarbeiter/in";
            this.lblAngezeigterMitarbeiter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAngezeigterMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtAngezeigterMitarbeiter
            // 
            this.edtAngezeigterMitarbeiter.Location = new System.Drawing.Point(204, 10);
            this.edtAngezeigterMitarbeiter.Name = "edtAngezeigterMitarbeiter";
            this.edtAngezeigterMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAngezeigterMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAngezeigterMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngezeigterMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtAngezeigterMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAngezeigterMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtAngezeigterMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAngezeigterMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngezeigterMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAngezeigterMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAngezeigterMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAngezeigterMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAngezeigterMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAngezeigterMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtAngezeigterMitarbeiter.Properties.DisplayMember = "Text";
            this.edtAngezeigterMitarbeiter.Properties.NullText = "";
            this.edtAngezeigterMitarbeiter.Properties.ShowFooter = false;
            this.edtAngezeigterMitarbeiter.Properties.ShowHeader = false;
            this.edtAngezeigterMitarbeiter.Properties.ValueMember = "Code";
            this.edtAngezeigterMitarbeiter.Size = new System.Drawing.Size(231, 24);
            this.edtAngezeigterMitarbeiter.TabIndex = 1;
            this.edtAngezeigterMitarbeiter.EditValueChanged += new System.EventHandler(this.edtAngezeigterMitarbeiter_EditValueChanged);
            this.edtAngezeigterMitarbeiter.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edtAngezeigterMitarbeiter_EditValueChanging);
            // 
            // lblAngezeigterMAFilter
            // 
            this.lblAngezeigterMAFilter.Location = new System.Drawing.Point(467, 10);
            this.lblAngezeigterMAFilter.Name = "lblAngezeigterMAFilter";
            this.lblAngezeigterMAFilter.Size = new System.Drawing.Size(38, 24);
            this.lblAngezeigterMAFilter.TabIndex = 2;
            this.lblAngezeigterMAFilter.Text = "Filter:";
            this.lblAngezeigterMAFilter.UseCompatibleTextRendering = true;
            this.lblAngezeigterMAFilter.Visible = false;
            // 
            // edtAngezeigterMAFilter
            // 
            this.edtAngezeigterMAFilter.Location = new System.Drawing.Point(511, 10);
            this.edtAngezeigterMAFilter.Name = "edtAngezeigterMAFilter";
            this.edtAngezeigterMAFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAngezeigterMAFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAngezeigterMAFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngezeigterMAFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtAngezeigterMAFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAngezeigterMAFilter.Properties.Appearance.Options.UseFont = true;
            this.edtAngezeigterMAFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAngezeigterMAFilter.Size = new System.Drawing.Size(80, 24);
            this.edtAngezeigterMAFilter.TabIndex = 3;
            this.edtAngezeigterMAFilter.Visible = false;
            // 
            // btnAngezeigterMAFilter
            // 
            this.btnAngezeigterMAFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAngezeigterMAFilter.IconID = 23;
            this.btnAngezeigterMAFilter.Location = new System.Drawing.Point(597, 10);
            this.btnAngezeigterMAFilter.Name = "btnAngezeigterMAFilter";
            this.btnAngezeigterMAFilter.Size = new System.Drawing.Size(24, 24);
            this.btnAngezeigterMAFilter.TabIndex = 4;
            this.btnAngezeigterMAFilter.UseCompatibleTextRendering = true;
            this.btnAngezeigterMAFilter.UseVisualStyleBackColor = false;
            this.btnAngezeigterMAFilter.Visible = false;
            this.btnAngezeigterMAFilter.Click += new System.EventHandler(this.btnAngezeigterMAFilter_Click);
            // 
            // lblTagessollC
            // 
            this.lblTagessollC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTagessollC.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTagessollC.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTagessollC.Location = new System.Drawing.Point(774, 9);
            this.lblTagessollC.Name = "lblTagessollC";
            this.lblTagessollC.Size = new System.Drawing.Size(141, 24);
            this.lblTagessollC.TabIndex = 5;
            this.lblTagessollC.Text = "Tages-Soll";
            this.lblTagessollC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTagessollC.UseCompatibleTextRendering = true;
            // 
            // lblTagessoll
            // 
            this.lblTagessoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTagessoll.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTagessoll.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTagessoll.Location = new System.Drawing.Point(921, 9);
            this.lblTagessoll.Name = "lblTagessoll";
            this.lblTagessoll.Size = new System.Drawing.Size(49, 24);
            this.lblTagessoll.TabIndex = 6;
            this.lblTagessoll.Text = "8:24";
            this.lblTagessoll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTagessoll.UseCompatibleTextRendering = true;
            // 
            // panZeitrechner
            // 
            this.panZeitrechner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panZeitrechner.Controls.Add(this.grdZeitrechner);
            this.panZeitrechner.Controls.Add(this.pnlZeitrechnerBottom);
            this.panZeitrechner.Location = new System.Drawing.Point(500, 260);
            this.panZeitrechner.Name = "panZeitrechner";
            this.panZeitrechner.Size = new System.Drawing.Size(235, 170);
            this.panZeitrechner.TabIndex = 7;
            // 
            // grdZeitrechner
            // 
            this.grdZeitrechner.DataSource = this.qryZeitrechner;
            this.grdZeitrechner.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdZeitrechner.EmbeddedNavigator.Name = "";
            this.grdZeitrechner.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZeitrechner.Location = new System.Drawing.Point(0, 0);
            this.grdZeitrechner.MainView = this.grvZeitrechner;
            this.grdZeitrechner.Name = "grdZeitrechner";
            this.grdZeitrechner.Size = new System.Drawing.Size(235, 70);
            this.grdZeitrechner.TabIndex = 1;
            this.grdZeitrechner.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZeitrechner});
            // 
            // qryZeitrechner
            // 
            this.qryZeitrechner.CanDelete = true;
            this.qryZeitrechner.CanInsert = true;
            this.qryZeitrechner.CanUpdate = true;
            this.qryZeitrechner.HostControl = this;
            this.qryZeitrechner.IsIdentityInsert = false;
            this.qryZeitrechner.TableName = "BDEZeitrechner";
            this.qryZeitrechner.AfterInsert += new System.EventHandler(this.qryZeitrechner_AfterInsert);
            this.qryZeitrechner.BeforeDeleteQuestion += new System.EventHandler(this.qryZeitrechner_BeforeDeleteQuestion);
            this.qryZeitrechner.BeforePost += new System.EventHandler(this.qryZeitrechner_BeforePost);
            this.qryZeitrechner.PositionChanged += new System.EventHandler(this.qryZeitrechner_PositionChanged);
            // 
            // grvZeitrechner
            // 
            this.grvZeitrechner.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZeitrechner.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.Empty.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.Empty.Options.UseFont = true;
            this.grvZeitrechner.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.EvenRow.Options.UseFont = true;
            this.grvZeitrechner.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZeitrechner.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZeitrechner.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZeitrechner.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZeitrechner.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZeitrechner.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZeitrechner.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZeitrechner.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZeitrechner.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZeitrechner.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZeitrechner.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvZeitrechner.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZeitrechner.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZeitrechner.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZeitrechner.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZeitrechner.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.GroupRow.Options.UseFont = true;
            this.grvZeitrechner.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZeitrechner.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZeitrechner.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZeitrechner.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZeitrechner.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZeitrechner.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZeitrechner.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZeitrechner.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZeitrechner.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZeitrechner.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZeitrechner.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZeitrechner.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.OddRow.Options.UseFont = true;
            this.grvZeitrechner.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZeitrechner.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.Row.Options.UseBackColor = true;
            this.grvZeitrechner.Appearance.Row.Options.UseFont = true;
            this.grvZeitrechner.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZeitrechner.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZeitrechner.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZeitrechner.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZeitrechner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZeitrechner.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPraesenzDatum,
            this.colPraesenzZeitVon,
            this.colPraesenzZeitBis});
            this.grvZeitrechner.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZeitrechner.GridControl = this.grdZeitrechner;
            this.grvZeitrechner.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvZeitrechner.Name = "grvZeitrechner";
            this.grvZeitrechner.OptionsBehavior.Editable = false;
            this.grvZeitrechner.OptionsCustomization.AllowFilter = false;
            this.grvZeitrechner.OptionsFilter.AllowFilterEditor = false;
            this.grvZeitrechner.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZeitrechner.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZeitrechner.OptionsNavigation.UseTabKey = false;
            this.grvZeitrechner.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvZeitrechner.OptionsView.ColumnAutoWidth = false;
            this.grvZeitrechner.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZeitrechner.OptionsView.ShowGroupPanel = false;
            this.grvZeitrechner.OptionsView.ShowIndicator = false;
            // 
            // colPraesenzDatum
            // 
            this.colPraesenzDatum.Caption = "Datum";
            this.colPraesenzDatum.FieldName = "Datum";
            this.colPraesenzDatum.Name = "colPraesenzDatum";
            this.colPraesenzDatum.Visible = true;
            this.colPraesenzDatum.VisibleIndex = 0;
            this.colPraesenzDatum.Width = 86;
            // 
            // colPraesenzZeitVon
            // 
            this.colPraesenzZeitVon.AppearanceCell.Options.UseTextOptions = true;
            this.colPraesenzZeitVon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPraesenzZeitVon.Caption = "Zeit von";
            this.colPraesenzZeitVon.DisplayFormat.FormatString = "t";
            this.colPraesenzZeitVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPraesenzZeitVon.FieldName = "ZeitVon";
            this.colPraesenzZeitVon.Name = "colPraesenzZeitVon";
            this.colPraesenzZeitVon.Visible = true;
            this.colPraesenzZeitVon.VisibleIndex = 1;
            this.colPraesenzZeitVon.Width = 70;
            // 
            // colPraesenzZeitBis
            // 
            this.colPraesenzZeitBis.AppearanceCell.Options.UseTextOptions = true;
            this.colPraesenzZeitBis.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPraesenzZeitBis.Caption = "Zeit bis";
            this.colPraesenzZeitBis.DisplayFormat.FormatString = "t";
            this.colPraesenzZeitBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPraesenzZeitBis.FieldName = "ZeitBis";
            this.colPraesenzZeitBis.Name = "colPraesenzZeitBis";
            this.colPraesenzZeitBis.Visible = true;
            this.colPraesenzZeitBis.VisibleIndex = 2;
            this.colPraesenzZeitBis.Width = 69;
            // 
            // pnlZeitrechnerBottom
            // 
            this.pnlZeitrechnerBottom.Controls.Add(this.edtZeitrechnerZeitBis);
            this.pnlZeitrechnerBottom.Controls.Add(this.lblZeitrechnerZeitBis);
            this.pnlZeitrechnerBottom.Controls.Add(this.edtZeitrechnerZeitVon);
            this.pnlZeitrechnerBottom.Controls.Add(this.lblZeitrechnerZeitVon);
            this.pnlZeitrechnerBottom.Controls.Add(this.edtZeitrechnerDatum);
            this.pnlZeitrechnerBottom.Controls.Add(this.lblZeitrechnerDatum);
            this.pnlZeitrechnerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlZeitrechnerBottom.Location = new System.Drawing.Point(0, 70);
            this.pnlZeitrechnerBottom.Name = "pnlZeitrechnerBottom";
            this.pnlZeitrechnerBottom.Size = new System.Drawing.Size(235, 100);
            this.pnlZeitrechnerBottom.TabIndex = 0;
            // 
            // edtZeitrechnerZeitBis
            // 
            this.edtZeitrechnerZeitBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZeitrechnerZeitBis.DataMember = "ZeitBis";
            this.edtZeitrechnerZeitBis.DataSource = this.qryZeitrechner;
            this.edtZeitrechnerZeitBis.EditValue = null;
            this.edtZeitrechnerZeitBis.Location = new System.Drawing.Point(91, 66);
            this.edtZeitrechnerZeitBis.Name = "edtZeitrechnerZeitBis";
            this.edtZeitrechnerZeitBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitrechnerZeitBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitrechnerZeitBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitrechnerZeitBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitrechnerZeitBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitrechnerZeitBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitrechnerZeitBis.Properties.Appearance.Options.UseFont = true;
            this.edtZeitrechnerZeitBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtZeitrechnerZeitBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtZeitrechnerZeitBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitrechnerZeitBis.Properties.DisplayFormat.FormatString = "t";
            this.edtZeitrechnerZeitBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitrechnerZeitBis.Properties.EditFormat.FormatString = "t";
            this.edtZeitrechnerZeitBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitrechnerZeitBis.Properties.Mask.EditMask = "t";
            this.edtZeitrechnerZeitBis.Size = new System.Drawing.Size(74, 24);
            this.edtZeitrechnerZeitBis.TabIndex = 6;
            // 
            // lblZeitrechnerZeitBis
            // 
            this.lblZeitrechnerZeitBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZeitrechnerZeitBis.Location = new System.Drawing.Point(11, 66);
            this.lblZeitrechnerZeitBis.Name = "lblZeitrechnerZeitBis";
            this.lblZeitrechnerZeitBis.Size = new System.Drawing.Size(80, 24);
            this.lblZeitrechnerZeitBis.TabIndex = 5;
            this.lblZeitrechnerZeitBis.Text = "Zeit bis";
            this.lblZeitrechnerZeitBis.UseCompatibleTextRendering = true;
            // 
            // edtZeitrechnerZeitVon
            // 
            this.edtZeitrechnerZeitVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZeitrechnerZeitVon.DataMember = "ZeitVon";
            this.edtZeitrechnerZeitVon.DataSource = this.qryZeitrechner;
            this.edtZeitrechnerZeitVon.EditValue = null;
            this.edtZeitrechnerZeitVon.Location = new System.Drawing.Point(91, 36);
            this.edtZeitrechnerZeitVon.Name = "edtZeitrechnerZeitVon";
            this.edtZeitrechnerZeitVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitrechnerZeitVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitrechnerZeitVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitrechnerZeitVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitrechnerZeitVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitrechnerZeitVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitrechnerZeitVon.Properties.Appearance.Options.UseFont = true;
            this.edtZeitrechnerZeitVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtZeitrechnerZeitVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtZeitrechnerZeitVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitrechnerZeitVon.Properties.DisplayFormat.FormatString = "t";
            this.edtZeitrechnerZeitVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitrechnerZeitVon.Properties.EditFormat.FormatString = "t";
            this.edtZeitrechnerZeitVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitrechnerZeitVon.Properties.Mask.EditMask = "t";
            this.edtZeitrechnerZeitVon.Size = new System.Drawing.Size(74, 24);
            this.edtZeitrechnerZeitVon.TabIndex = 4;
            // 
            // lblZeitrechnerZeitVon
            // 
            this.lblZeitrechnerZeitVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZeitrechnerZeitVon.Location = new System.Drawing.Point(11, 36);
            this.lblZeitrechnerZeitVon.Name = "lblZeitrechnerZeitVon";
            this.lblZeitrechnerZeitVon.Size = new System.Drawing.Size(80, 24);
            this.lblZeitrechnerZeitVon.TabIndex = 3;
            this.lblZeitrechnerZeitVon.Text = "Zeit von";
            this.lblZeitrechnerZeitVon.UseCompatibleTextRendering = true;
            // 
            // edtZeitrechnerDatum
            // 
            this.edtZeitrechnerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZeitrechnerDatum.DataMember = "Datum";
            this.edtZeitrechnerDatum.DataSource = this.qryZeitrechner;
            this.edtZeitrechnerDatum.EditValue = null;
            this.edtZeitrechnerDatum.Location = new System.Drawing.Point(91, 6);
            this.edtZeitrechnerDatum.Name = "edtZeitrechnerDatum";
            this.edtZeitrechnerDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitrechnerDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitrechnerDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitrechnerDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitrechnerDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitrechnerDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitrechnerDatum.Properties.Appearance.Options.UseFont = true;
            this.edtZeitrechnerDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtZeitrechnerDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitrechnerDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtZeitrechnerDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitrechnerDatum.Properties.ShowToday = false;
            this.edtZeitrechnerDatum.Size = new System.Drawing.Size(95, 24);
            this.edtZeitrechnerDatum.TabIndex = 2;
            // 
            // lblZeitrechnerDatum
            // 
            this.lblZeitrechnerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZeitrechnerDatum.Location = new System.Drawing.Point(11, 6);
            this.lblZeitrechnerDatum.Name = "lblZeitrechnerDatum";
            this.lblZeitrechnerDatum.Size = new System.Drawing.Size(80, 24);
            this.lblZeitrechnerDatum.TabIndex = 1;
            this.lblZeitrechnerDatum.Text = "Datum";
            this.lblZeitrechnerDatum.UseCompatibleTextRendering = true;
            // 
            // tabZeiterfassung
            // 
            this.tabZeiterfassung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabZeiterfassung.Controls.Add(this.tpgUebersicht);
            this.tabZeiterfassung.Controls.Add(this.tpgWoche);
            this.tabZeiterfassung.Controls.Add(this.tpgMonat);
            this.tabZeiterfassung.Controls.Add(this.tpgErfassung);
            this.tabZeiterfassung.Location = new System.Drawing.Point(11, 40);
            this.tabZeiterfassung.Name = "tabZeiterfassung";
            this.tabZeiterfassung.ShowFixedWidthTooltip = true;
            this.tabZeiterfassung.Size = new System.Drawing.Size(959, 555);
            this.tabZeiterfassung.TabIndex = 7;
            this.tabZeiterfassung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgErfassung,
            this.tpgWoche,
            this.tpgMonat,
            this.tpgUebersicht});
            this.tabZeiterfassung.TabsLineColor = System.Drawing.Color.Black;
            this.tabZeiterfassung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabZeiterfassung.VerticalMargin = 5;
            this.tabZeiterfassung.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabZeiterfassung_SelectedTabChanged);
            this.tabZeiterfassung.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabZeiterfassung_SelectedTabChanging);
            // 
            // tpgUebersicht
            // 
            this.tpgUebersicht.Controls.Add(this.docUebersicht);
            this.tpgUebersicht.Controls.Add(this.grpUebersichtFerien);
            this.tpgUebersicht.Controls.Add(this.grpUebersichtStundenlohn);
            this.tpgUebersicht.Controls.Add(this.grpUebersichtGleitzeit);
            this.tpgUebersicht.Controls.Add(this.grpUebersichtAllgemein);
            this.tpgUebersicht.Controls.Add(this.edtUebersichtMonat);
            this.tpgUebersicht.Controls.Add(this.btnUebersichtNachmonat);
            this.tpgUebersicht.Controls.Add(this.btnUebersichtHeute);
            this.tpgUebersicht.Controls.Add(this.btnUebersichtVormonat);
            this.tpgUebersicht.Controls.Add(this.lblAktuellerMonat);
            this.tpgUebersicht.Controls.Add(this.lblAktuellerMonatC);
            this.tpgUebersicht.Location = new System.Drawing.Point(6, 6);
            this.tpgUebersicht.Name = "tpgUebersicht";
            this.tpgUebersicht.Size = new System.Drawing.Size(947, 515);
            this.tpgUebersicht.TabIndex = 4;
            this.tpgUebersicht.Title = "Ü&bersicht";
            // 
            // docUebersicht
            // 
            this.docUebersicht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.docUebersicht.Context = "BDE_ZLEUebersicht";
            this.docUebersicht.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.docUebersicht.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docUebersicht.Image = ((System.Drawing.Image)(resources.GetObject("docUebersicht.Image")));
            this.docUebersicht.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docUebersicht.Location = new System.Drawing.Point(841, 485);
            this.docUebersicht.Name = "docUebersicht";
            this.docUebersicht.Size = new System.Drawing.Size(100, 24);
            this.docUebersicht.TabIndex = 10;
            this.docUebersicht.Text = "Übersicht";
            this.docUebersicht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docUebersicht.UseCompatibleTextRendering = true;
            this.docUebersicht.UseVisualStyleBackColor = false;
            // 
            // grpUebersichtFerien
            // 
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienSaldo);
            this.grpUebersichtFerien.Controls.Add(this.panUebersichtFerienLinie);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienKorrekturen);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienKorrekturenLbl);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienZugabenKuerzungen);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienZugabenKuerzungenLbl);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienBezogen);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienBezogenLbl);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienAnspruch);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienAnspruchLbl);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienUebertrag);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienUebertragLbl);
            this.grpUebersichtFerien.Controls.Add(this.lblUebersichtFerienSaldoLbl);
            this.grpUebersichtFerien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpUebersichtFerien.Location = new System.Drawing.Point(348, 47);
            this.grpUebersichtFerien.Name = "grpUebersichtFerien";
            this.grpUebersichtFerien.Size = new System.Drawing.Size(280, 177);
            this.grpUebersichtFerien.TabIndex = 9;
            this.grpUebersichtFerien.TabStop = false;
            this.grpUebersichtFerien.Text = "Ferien";
            this.grpUebersichtFerien.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienSaldo
            // 
            this.lblUebersichtFerienSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienSaldo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtFerienSaldo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienSaldo.Location = new System.Drawing.Point(180, 144);
            this.lblUebersichtFerienSaldo.Name = "lblUebersichtFerienSaldo";
            this.lblUebersichtFerienSaldo.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtFerienSaldo.TabIndex = 12;
            this.lblUebersichtFerienSaldo.Text = "0.00 Std.";
            this.lblUebersichtFerienSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtFerienSaldo.UseCompatibleTextRendering = true;
            // 
            // panUebersichtFerienLinie
            // 
            this.panUebersichtFerienLinie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panUebersichtFerienLinie.BackColor = System.Drawing.Color.Black;
            this.panUebersichtFerienLinie.Location = new System.Drawing.Point(12, 140);
            this.panUebersichtFerienLinie.Name = "panUebersichtFerienLinie";
            this.panUebersichtFerienLinie.Size = new System.Drawing.Size(255, 1);
            this.panUebersichtFerienLinie.TabIndex = 11;
            // 
            // lblUebersichtFerienKorrekturen
            // 
            this.lblUebersichtFerienKorrekturen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienKorrekturen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtFerienKorrekturen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienKorrekturen.Location = new System.Drawing.Point(180, 113);
            this.lblUebersichtFerienKorrekturen.Name = "lblUebersichtFerienKorrekturen";
            this.lblUebersichtFerienKorrekturen.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtFerienKorrekturen.TabIndex = 9;
            this.lblUebersichtFerienKorrekturen.Text = "0.00 Std.";
            this.lblUebersichtFerienKorrekturen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtFerienKorrekturen.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienKorrekturenLbl
            // 
            this.lblUebersichtFerienKorrekturenLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienKorrekturenLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtFerienKorrekturenLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienKorrekturenLbl.Location = new System.Drawing.Point(12, 113);
            this.lblUebersichtFerienKorrekturenLbl.Name = "lblUebersichtFerienKorrekturenLbl";
            this.lblUebersichtFerienKorrekturenLbl.Size = new System.Drawing.Size(162, 24);
            this.lblUebersichtFerienKorrekturenLbl.TabIndex = 8;
            this.lblUebersichtFerienKorrekturenLbl.Text = "Korrekturen";
            this.lblUebersichtFerienKorrekturenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtFerienKorrekturenLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienZugabenKuerzungen
            // 
            this.lblUebersichtFerienZugabenKuerzungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienZugabenKuerzungen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtFerienZugabenKuerzungen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienZugabenKuerzungen.Location = new System.Drawing.Point(180, 89);
            this.lblUebersichtFerienZugabenKuerzungen.Name = "lblUebersichtFerienZugabenKuerzungen";
            this.lblUebersichtFerienZugabenKuerzungen.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtFerienZugabenKuerzungen.TabIndex = 7;
            this.lblUebersichtFerienZugabenKuerzungen.Text = "0.00 Std.";
            this.lblUebersichtFerienZugabenKuerzungen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtFerienZugabenKuerzungen.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienZugabenKuerzungenLbl
            // 
            this.lblUebersichtFerienZugabenKuerzungenLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienZugabenKuerzungenLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtFerienZugabenKuerzungenLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienZugabenKuerzungenLbl.Location = new System.Drawing.Point(12, 89);
            this.lblUebersichtFerienZugabenKuerzungenLbl.Name = "lblUebersichtFerienZugabenKuerzungenLbl";
            this.lblUebersichtFerienZugabenKuerzungenLbl.Size = new System.Drawing.Size(162, 24);
            this.lblUebersichtFerienZugabenKuerzungenLbl.TabIndex = 6;
            this.lblUebersichtFerienZugabenKuerzungenLbl.Text = "Zugaben/Kürzungen";
            this.lblUebersichtFerienZugabenKuerzungenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtFerienZugabenKuerzungenLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienBezogen
            // 
            this.lblUebersichtFerienBezogen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienBezogen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtFerienBezogen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienBezogen.Location = new System.Drawing.Point(180, 65);
            this.lblUebersichtFerienBezogen.Name = "lblUebersichtFerienBezogen";
            this.lblUebersichtFerienBezogen.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtFerienBezogen.TabIndex = 5;
            this.lblUebersichtFerienBezogen.Text = "0.00 Std.";
            this.lblUebersichtFerienBezogen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtFerienBezogen.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienBezogenLbl
            // 
            this.lblUebersichtFerienBezogenLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienBezogenLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtFerienBezogenLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienBezogenLbl.Location = new System.Drawing.Point(12, 65);
            this.lblUebersichtFerienBezogenLbl.Name = "lblUebersichtFerienBezogenLbl";
            this.lblUebersichtFerienBezogenLbl.Size = new System.Drawing.Size(162, 24);
            this.lblUebersichtFerienBezogenLbl.TabIndex = 4;
            this.lblUebersichtFerienBezogenLbl.Text = "bisher bezogen";
            this.lblUebersichtFerienBezogenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtFerienBezogenLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienAnspruch
            // 
            this.lblUebersichtFerienAnspruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienAnspruch.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtFerienAnspruch.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienAnspruch.Location = new System.Drawing.Point(180, 41);
            this.lblUebersichtFerienAnspruch.Name = "lblUebersichtFerienAnspruch";
            this.lblUebersichtFerienAnspruch.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtFerienAnspruch.TabIndex = 3;
            this.lblUebersichtFerienAnspruch.Text = "0.00 Std.";
            this.lblUebersichtFerienAnspruch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtFerienAnspruch.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienAnspruchLbl
            // 
            this.lblUebersichtFerienAnspruchLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienAnspruchLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtFerienAnspruchLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienAnspruchLbl.Location = new System.Drawing.Point(12, 41);
            this.lblUebersichtFerienAnspruchLbl.Name = "lblUebersichtFerienAnspruchLbl";
            this.lblUebersichtFerienAnspruchLbl.Size = new System.Drawing.Size(162, 24);
            this.lblUebersichtFerienAnspruchLbl.TabIndex = 2;
            this.lblUebersichtFerienAnspruchLbl.Text = "Anspruch pro Jahr";
            this.lblUebersichtFerienAnspruchLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtFerienAnspruchLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienUebertrag
            // 
            this.lblUebersichtFerienUebertrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienUebertrag.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtFerienUebertrag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienUebertrag.Location = new System.Drawing.Point(180, 17);
            this.lblUebersichtFerienUebertrag.Name = "lblUebersichtFerienUebertrag";
            this.lblUebersichtFerienUebertrag.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtFerienUebertrag.TabIndex = 1;
            this.lblUebersichtFerienUebertrag.Text = "0.00 Std.";
            this.lblUebersichtFerienUebertrag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtFerienUebertrag.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienUebertragLbl
            // 
            this.lblUebersichtFerienUebertragLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienUebertragLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtFerienUebertragLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienUebertragLbl.Location = new System.Drawing.Point(12, 17);
            this.lblUebersichtFerienUebertragLbl.Name = "lblUebersichtFerienUebertragLbl";
            this.lblUebersichtFerienUebertragLbl.Size = new System.Drawing.Size(162, 24);
            this.lblUebersichtFerienUebertragLbl.TabIndex = 0;
            this.lblUebersichtFerienUebertragLbl.Text = "Übertrag Vorjahr";
            this.lblUebersichtFerienUebertragLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtFerienUebertragLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFerienSaldoLbl
            // 
            this.lblUebersichtFerienSaldoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtFerienSaldoLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtFerienSaldoLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtFerienSaldoLbl.Location = new System.Drawing.Point(12, 144);
            this.lblUebersichtFerienSaldoLbl.Name = "lblUebersichtFerienSaldoLbl";
            this.lblUebersichtFerienSaldoLbl.Size = new System.Drawing.Size(162, 24);
            this.lblUebersichtFerienSaldoLbl.TabIndex = 0;
            this.lblUebersichtFerienSaldoLbl.Text = "Feriensaldo";
            this.lblUebersichtFerienSaldoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtFerienSaldoLbl.UseCompatibleTextRendering = true;
            // 
            // grpUebersichtStundenlohn
            // 
            this.grpUebersichtStundenlohn.Controls.Add(this.lblUebersichtStundenlohnIstArbeitszeit);
            this.grpUebersichtStundenlohn.Controls.Add(this.lblUebersichtStundenlohnIstArbeitszeitLbl);
            this.grpUebersichtStundenlohn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpUebersichtStundenlohn.Location = new System.Drawing.Point(23, 395);
            this.grpUebersichtStundenlohn.Name = "grpUebersichtStundenlohn";
            this.grpUebersichtStundenlohn.Size = new System.Drawing.Size(302, 49);
            this.grpUebersichtStundenlohn.TabIndex = 8;
            this.grpUebersichtStundenlohn.TabStop = false;
            this.grpUebersichtStundenlohn.Text = "Stundenlohn";
            this.grpUebersichtStundenlohn.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtStundenlohnIstArbeitszeit
            // 
            this.lblUebersichtStundenlohnIstArbeitszeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtStundenlohnIstArbeitszeit.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtStundenlohnIstArbeitszeit.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtStundenlohnIstArbeitszeit.Location = new System.Drawing.Point(202, 17);
            this.lblUebersichtStundenlohnIstArbeitszeit.Name = "lblUebersichtStundenlohnIstArbeitszeit";
            this.lblUebersichtStundenlohnIstArbeitszeit.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtStundenlohnIstArbeitszeit.TabIndex = 1;
            this.lblUebersichtStundenlohnIstArbeitszeit.Text = "0.00 Std.";
            this.lblUebersichtStundenlohnIstArbeitszeit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtStundenlohnIstArbeitszeit.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtStundenlohnIstArbeitszeitLbl
            // 
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.Location = new System.Drawing.Point(12, 17);
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.Name = "lblUebersichtStundenlohnIstArbeitszeitLbl";
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.TabIndex = 0;
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.Text = "Stunden auf Stundenlohn";
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtStundenlohnIstArbeitszeitLbl.UseCompatibleTextRendering = true;
            // 
            // grpUebersichtGleitzeit
            // 
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitSaldo);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitSaldoLbl);
            this.grpUebersichtGleitzeit.Controls.Add(this.panUebersichtGleitzeitLinie);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitBezUeberstunden);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitBezUeberstundenLbl);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitKorrekturen);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitKorrekturenLbl);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitSaldoUebertragMonate);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitSaldoUebertragMonateLbl);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitUebertragJahr);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitUebertragJahrLbl);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitMonatSaldo);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitMonatSaldoLbl);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitSollMonat);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitSollMonatLbl);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitIstArbeitszeit);
            this.grpUebersichtGleitzeit.Controls.Add(this.lblUebersichtGleitzeitIstArbeitszeitLbl);
            this.grpUebersichtGleitzeit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpUebersichtGleitzeit.Location = new System.Drawing.Point(23, 134);
            this.grpUebersichtGleitzeit.Name = "grpUebersichtGleitzeit";
            this.grpUebersichtGleitzeit.Size = new System.Drawing.Size(302, 249);
            this.grpUebersichtGleitzeit.TabIndex = 7;
            this.grpUebersichtGleitzeit.TabStop = false;
            this.grpUebersichtGleitzeit.Text = "Gleitzeit";
            this.grpUebersichtGleitzeit.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitSaldo
            // 
            this.lblUebersichtGleitzeitSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitSaldo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitSaldo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitSaldo.Location = new System.Drawing.Point(202, 216);
            this.lblUebersichtGleitzeitSaldo.Name = "lblUebersichtGleitzeitSaldo";
            this.lblUebersichtGleitzeitSaldo.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitSaldo.TabIndex = 16;
            this.lblUebersichtGleitzeitSaldo.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitSaldo.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitSaldoLbl
            // 
            this.lblUebersichtGleitzeitSaldoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitSaldoLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitSaldoLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitSaldoLbl.Location = new System.Drawing.Point(12, 216);
            this.lblUebersichtGleitzeitSaldoLbl.Name = "lblUebersichtGleitzeitSaldoLbl";
            this.lblUebersichtGleitzeitSaldoLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitSaldoLbl.TabIndex = 15;
            this.lblUebersichtGleitzeitSaldoLbl.Text = "Gleitzeitsaldo";
            this.lblUebersichtGleitzeitSaldoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitSaldoLbl.UseCompatibleTextRendering = true;
            // 
            // panUebersichtGleitzeitLinie
            // 
            this.panUebersichtGleitzeitLinie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panUebersichtGleitzeitLinie.BackColor = System.Drawing.Color.Black;
            this.panUebersichtGleitzeitLinie.Location = new System.Drawing.Point(12, 212);
            this.panUebersichtGleitzeitLinie.Name = "panUebersichtGleitzeitLinie";
            this.panUebersichtGleitzeitLinie.Size = new System.Drawing.Size(277, 1);
            this.panUebersichtGleitzeitLinie.TabIndex = 14;
            // 
            // lblUebersichtGleitzeitBezUeberstunden
            // 
            this.lblUebersichtGleitzeitBezUeberstunden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitBezUeberstunden.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitBezUeberstunden.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitBezUeberstunden.Location = new System.Drawing.Point(202, 185);
            this.lblUebersichtGleitzeitBezUeberstunden.Name = "lblUebersichtGleitzeitBezUeberstunden";
            this.lblUebersichtGleitzeitBezUeberstunden.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitBezUeberstunden.TabIndex = 13;
            this.lblUebersichtGleitzeitBezUeberstunden.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitBezUeberstunden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitBezUeberstunden.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitBezUeberstundenLbl
            // 
            this.lblUebersichtGleitzeitBezUeberstundenLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitBezUeberstundenLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitBezUeberstundenLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitBezUeberstundenLbl.Location = new System.Drawing.Point(12, 185);
            this.lblUebersichtGleitzeitBezUeberstundenLbl.Name = "lblUebersichtGleitzeitBezUeberstundenLbl";
            this.lblUebersichtGleitzeitBezUeberstundenLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitBezUeberstundenLbl.TabIndex = 12;
            this.lblUebersichtGleitzeitBezUeberstundenLbl.Text = "ausbezahlte Überstunden";
            this.lblUebersichtGleitzeitBezUeberstundenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitBezUeberstundenLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitKorrekturen
            // 
            this.lblUebersichtGleitzeitKorrekturen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitKorrekturen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitKorrekturen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitKorrekturen.Location = new System.Drawing.Point(202, 161);
            this.lblUebersichtGleitzeitKorrekturen.Name = "lblUebersichtGleitzeitKorrekturen";
            this.lblUebersichtGleitzeitKorrekturen.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitKorrekturen.TabIndex = 11;
            this.lblUebersichtGleitzeitKorrekturen.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitKorrekturen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitKorrekturen.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitKorrekturenLbl
            // 
            this.lblUebersichtGleitzeitKorrekturenLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitKorrekturenLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitKorrekturenLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitKorrekturenLbl.Location = new System.Drawing.Point(12, 161);
            this.lblUebersichtGleitzeitKorrekturenLbl.Name = "lblUebersichtGleitzeitKorrekturenLbl";
            this.lblUebersichtGleitzeitKorrekturenLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitKorrekturenLbl.TabIndex = 10;
            this.lblUebersichtGleitzeitKorrekturenLbl.Text = "Korrekturen";
            this.lblUebersichtGleitzeitKorrekturenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitKorrekturenLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitSaldoUebertragMonate
            // 
            this.lblUebersichtGleitzeitSaldoUebertragMonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitSaldoUebertragMonate.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitSaldoUebertragMonate.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitSaldoUebertragMonate.Location = new System.Drawing.Point(202, 137);
            this.lblUebersichtGleitzeitSaldoUebertragMonate.Name = "lblUebersichtGleitzeitSaldoUebertragMonate";
            this.lblUebersichtGleitzeitSaldoUebertragMonate.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitSaldoUebertragMonate.TabIndex = 9;
            this.lblUebersichtGleitzeitSaldoUebertragMonate.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitSaldoUebertragMonate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitSaldoUebertragMonate.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitSaldoUebertragMonateLbl
            // 
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.Location = new System.Drawing.Point(12, 137);
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.Name = "lblUebersichtGleitzeitSaldoUebertragMonateLbl";
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.TabIndex = 8;
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.Text = "Gleitzeitsaldo Vormonat (Jahr)";
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitSaldoUebertragMonateLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitUebertragJahr
            // 
            this.lblUebersichtGleitzeitUebertragJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitUebertragJahr.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitUebertragJahr.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitUebertragJahr.Location = new System.Drawing.Point(202, 113);
            this.lblUebersichtGleitzeitUebertragJahr.Name = "lblUebersichtGleitzeitUebertragJahr";
            this.lblUebersichtGleitzeitUebertragJahr.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitUebertragJahr.TabIndex = 7;
            this.lblUebersichtGleitzeitUebertragJahr.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitUebertragJahr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitUebertragJahr.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitUebertragJahrLbl
            // 
            this.lblUebersichtGleitzeitUebertragJahrLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitUebertragJahrLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitUebertragJahrLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitUebertragJahrLbl.Location = new System.Drawing.Point(12, 113);
            this.lblUebersichtGleitzeitUebertragJahrLbl.Name = "lblUebersichtGleitzeitUebertragJahrLbl";
            this.lblUebersichtGleitzeitUebertragJahrLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitUebertragJahrLbl.TabIndex = 6;
            this.lblUebersichtGleitzeitUebertragJahrLbl.Text = "Übertrag Vorjahr";
            this.lblUebersichtGleitzeitUebertragJahrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitUebertragJahrLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitMonatSaldo
            // 
            this.lblUebersichtGleitzeitMonatSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitMonatSaldo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitMonatSaldo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitMonatSaldo.Location = new System.Drawing.Point(202, 65);
            this.lblUebersichtGleitzeitMonatSaldo.Name = "lblUebersichtGleitzeitMonatSaldo";
            this.lblUebersichtGleitzeitMonatSaldo.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitMonatSaldo.TabIndex = 5;
            this.lblUebersichtGleitzeitMonatSaldo.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitMonatSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitMonatSaldo.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitMonatSaldoLbl
            // 
            this.lblUebersichtGleitzeitMonatSaldoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitMonatSaldoLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitMonatSaldoLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitMonatSaldoLbl.Location = new System.Drawing.Point(12, 65);
            this.lblUebersichtGleitzeitMonatSaldoLbl.Name = "lblUebersichtGleitzeitMonatSaldoLbl";
            this.lblUebersichtGleitzeitMonatSaldoLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitMonatSaldoLbl.TabIndex = 4;
            this.lblUebersichtGleitzeitMonatSaldoLbl.Text = "Monatssaldo";
            this.lblUebersichtGleitzeitMonatSaldoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitMonatSaldoLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitSollMonat
            // 
            this.lblUebersichtGleitzeitSollMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitSollMonat.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitSollMonat.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitSollMonat.Location = new System.Drawing.Point(202, 41);
            this.lblUebersichtGleitzeitSollMonat.Name = "lblUebersichtGleitzeitSollMonat";
            this.lblUebersichtGleitzeitSollMonat.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitSollMonat.TabIndex = 3;
            this.lblUebersichtGleitzeitSollMonat.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitSollMonat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitSollMonat.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitSollMonatLbl
            // 
            this.lblUebersichtGleitzeitSollMonatLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitSollMonatLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitSollMonatLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitSollMonatLbl.Location = new System.Drawing.Point(12, 41);
            this.lblUebersichtGleitzeitSollMonatLbl.Name = "lblUebersichtGleitzeitSollMonatLbl";
            this.lblUebersichtGleitzeitSollMonatLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitSollMonatLbl.TabIndex = 2;
            this.lblUebersichtGleitzeitSollMonatLbl.Text = "SOLL-Arbeitszeit";
            this.lblUebersichtGleitzeitSollMonatLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitSollMonatLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitIstArbeitszeit
            // 
            this.lblUebersichtGleitzeitIstArbeitszeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitIstArbeitszeit.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtGleitzeitIstArbeitszeit.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitIstArbeitszeit.Location = new System.Drawing.Point(202, 17);
            this.lblUebersichtGleitzeitIstArbeitszeit.Name = "lblUebersichtGleitzeitIstArbeitszeit";
            this.lblUebersichtGleitzeitIstArbeitszeit.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtGleitzeitIstArbeitszeit.TabIndex = 1;
            this.lblUebersichtGleitzeitIstArbeitszeit.Text = "0.00 Std.";
            this.lblUebersichtGleitzeitIstArbeitszeit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtGleitzeitIstArbeitszeit.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtGleitzeitIstArbeitszeitLbl
            // 
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.Location = new System.Drawing.Point(12, 17);
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.Name = "lblUebersichtGleitzeitIstArbeitszeitLbl";
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.TabIndex = 0;
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.Text = "IST-Arbeitszeit";
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtGleitzeitIstArbeitszeitLbl.UseCompatibleTextRendering = true;
            // 
            // grpUebersichtAllgemein
            // 
            this.grpUebersichtAllgemein.Controls.Add(this.lblUebersichtSollProTag);
            this.grpUebersichtAllgemein.Controls.Add(this.lblUebersichtSollProTagLbl);
            this.grpUebersichtAllgemein.Controls.Add(this.lblUebersichtBeschaeftigungsgrad);
            this.grpUebersichtAllgemein.Controls.Add(this.lblUebersichtBeschaeftigungsgradLbl);
            this.grpUebersichtAllgemein.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpUebersichtAllgemein.Location = new System.Drawing.Point(23, 47);
            this.grpUebersichtAllgemein.Name = "grpUebersichtAllgemein";
            this.grpUebersichtAllgemein.Size = new System.Drawing.Size(302, 75);
            this.grpUebersichtAllgemein.TabIndex = 6;
            this.grpUebersichtAllgemein.TabStop = false;
            this.grpUebersichtAllgemein.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtSollProTag
            // 
            this.lblUebersichtSollProTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtSollProTag.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtSollProTag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtSollProTag.Location = new System.Drawing.Point(202, 41);
            this.lblUebersichtSollProTag.Name = "lblUebersichtSollProTag";
            this.lblUebersichtSollProTag.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtSollProTag.TabIndex = 3;
            this.lblUebersichtSollProTag.Text = "8.40 Std.";
            this.lblUebersichtSollProTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtSollProTag.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtSollProTagLbl
            // 
            this.lblUebersichtSollProTagLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtSollProTagLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtSollProTagLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtSollProTagLbl.Location = new System.Drawing.Point(12, 41);
            this.lblUebersichtSollProTagLbl.Name = "lblUebersichtSollProTagLbl";
            this.lblUebersichtSollProTagLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtSollProTagLbl.TabIndex = 2;
            this.lblUebersichtSollProTagLbl.Text = "SOLL-Arbeitszeit pro Tag";
            this.lblUebersichtSollProTagLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtSollProTagLbl.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtBeschaeftigungsgrad
            // 
            this.lblUebersichtBeschaeftigungsgrad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtBeschaeftigungsgrad.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblUebersichtBeschaeftigungsgrad.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtBeschaeftigungsgrad.Location = new System.Drawing.Point(202, 17);
            this.lblUebersichtBeschaeftigungsgrad.Name = "lblUebersichtBeschaeftigungsgrad";
            this.lblUebersichtBeschaeftigungsgrad.Size = new System.Drawing.Size(87, 24);
            this.lblUebersichtBeschaeftigungsgrad.TabIndex = 1;
            this.lblUebersichtBeschaeftigungsgrad.Text = "100 %";
            this.lblUebersichtBeschaeftigungsgrad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUebersichtBeschaeftigungsgrad.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtBeschaeftigungsgradLbl
            // 
            this.lblUebersichtBeschaeftigungsgradLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtBeschaeftigungsgradLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtBeschaeftigungsgradLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtBeschaeftigungsgradLbl.Location = new System.Drawing.Point(12, 17);
            this.lblUebersichtBeschaeftigungsgradLbl.Name = "lblUebersichtBeschaeftigungsgradLbl";
            this.lblUebersichtBeschaeftigungsgradLbl.Size = new System.Drawing.Size(184, 24);
            this.lblUebersichtBeschaeftigungsgradLbl.TabIndex = 0;
            this.lblUebersichtBeschaeftigungsgradLbl.Text = "Beschäftigungsgrad";
            this.lblUebersichtBeschaeftigungsgradLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUebersichtBeschaeftigungsgradLbl.UseCompatibleTextRendering = true;
            // 
            // edtUebersichtMonat
            // 
            this.edtUebersichtMonat.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUebersichtMonat.EditValue = null;
            this.edtUebersichtMonat.Location = new System.Drawing.Point(438, 13);
            this.edtUebersichtMonat.Name = "edtUebersichtMonat";
            this.edtUebersichtMonat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUebersichtMonat.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUebersichtMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUebersichtMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUebersichtMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtUebersichtMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUebersichtMonat.Properties.Appearance.Options.UseFont = true;
            this.edtUebersichtMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUebersichtMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUebersichtMonat.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUebersichtMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUebersichtMonat.Properties.ReadOnly = true;
            this.edtUebersichtMonat.Properties.ShowToday = false;
            this.edtUebersichtMonat.Size = new System.Drawing.Size(84, 24);
            this.edtUebersichtMonat.TabIndex = 5;
            this.edtUebersichtMonat.Visible = false;
            // 
            // btnUebersichtNachmonat
            // 
            this.btnUebersichtNachmonat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersichtNachmonat.IconID = 13;
            this.btnUebersichtNachmonat.Location = new System.Drawing.Point(408, 13);
            this.btnUebersichtNachmonat.Name = "btnUebersichtNachmonat";
            this.btnUebersichtNachmonat.Size = new System.Drawing.Size(24, 24);
            this.btnUebersichtNachmonat.TabIndex = 4;
            this.btnUebersichtNachmonat.UseCompatibleTextRendering = true;
            this.btnUebersichtNachmonat.UseVisualStyleBackColor = false;
            this.btnUebersichtNachmonat.Click += new System.EventHandler(this.btnUebersichtNachmonat_Click);
            // 
            // btnUebersichtHeute
            // 
            this.btnUebersichtHeute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersichtHeute.IconID = 16;
            this.btnUebersichtHeute.Location = new System.Drawing.Point(378, 13);
            this.btnUebersichtHeute.Name = "btnUebersichtHeute";
            this.btnUebersichtHeute.Size = new System.Drawing.Size(24, 24);
            this.btnUebersichtHeute.TabIndex = 3;
            this.btnUebersichtHeute.UseCompatibleTextRendering = true;
            this.btnUebersichtHeute.UseVisualStyleBackColor = false;
            this.btnUebersichtHeute.Click += new System.EventHandler(this.btnUebersichtHeute_Click);
            // 
            // btnUebersichtVormonat
            // 
            this.btnUebersichtVormonat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersichtVormonat.IconID = 11;
            this.btnUebersichtVormonat.Location = new System.Drawing.Point(348, 13);
            this.btnUebersichtVormonat.Name = "btnUebersichtVormonat";
            this.btnUebersichtVormonat.Size = new System.Drawing.Size(24, 24);
            this.btnUebersichtVormonat.TabIndex = 2;
            this.btnUebersichtVormonat.UseCompatibleTextRendering = true;
            this.btnUebersichtVormonat.UseVisualStyleBackColor = false;
            this.btnUebersichtVormonat.Click += new System.EventHandler(this.btnUebersichtVormonat_Click);
            // 
            // lblAktuellerMonat
            // 
            this.lblAktuellerMonat.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAktuellerMonat.Location = new System.Drawing.Point(170, 17);
            this.lblAktuellerMonat.Name = "lblAktuellerMonat";
            this.lblAktuellerMonat.Size = new System.Drawing.Size(144, 23);
            this.lblAktuellerMonat.TabIndex = 1;
            this.lblAktuellerMonat.Text = "Monat Jahr";
            this.lblAktuellerMonat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblAktuellerMonat.UseCompatibleTextRendering = true;
            // 
            // lblAktuellerMonatC
            // 
            this.lblAktuellerMonatC.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAktuellerMonatC.Location = new System.Drawing.Point(23, 17);
            this.lblAktuellerMonatC.Name = "lblAktuellerMonatC";
            this.lblAktuellerMonatC.Size = new System.Drawing.Size(141, 23);
            this.lblAktuellerMonatC.TabIndex = 0;
            this.lblAktuellerMonatC.Text = "Aktueller Monat";
            this.lblAktuellerMonatC.UseCompatibleTextRendering = true;
            // 
            // tpgWoche
            // 
            this.tpgWoche.Controls.Add(this.btnWocheZuklappen);
            this.tpgWoche.Controls.Add(this.btnWocheAufklappen);
            this.tpgWoche.Controls.Add(this.grdWoche);
            this.tpgWoche.Location = new System.Drawing.Point(6, 6);
            this.tpgWoche.Name = "tpgWoche";
            this.tpgWoche.Size = new System.Drawing.Size(947, 515);
            this.tpgWoche.TabIndex = 3;
            this.tpgWoche.Title = "&Woche";
            // 
            // btnWocheZuklappen
            // 
            this.btnWocheZuklappen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWocheZuklappen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWocheZuklappen.IconID = 71;
            this.btnWocheZuklappen.Location = new System.Drawing.Point(920, 32);
            this.btnWocheZuklappen.Name = "btnWocheZuklappen";
            this.btnWocheZuklappen.Size = new System.Drawing.Size(24, 24);
            this.btnWocheZuklappen.TabIndex = 2;
            this.btnWocheZuklappen.UseCompatibleTextRendering = true;
            this.btnWocheZuklappen.UseVisualStyleBackColor = false;
            this.btnWocheZuklappen.Click += new System.EventHandler(this.btnWocheZuklappen_Click);
            // 
            // btnWocheAufklappen
            // 
            this.btnWocheAufklappen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWocheAufklappen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWocheAufklappen.IconID = 70;
            this.btnWocheAufklappen.Location = new System.Drawing.Point(920, 2);
            this.btnWocheAufklappen.Name = "btnWocheAufklappen";
            this.btnWocheAufklappen.Size = new System.Drawing.Size(24, 24);
            this.btnWocheAufklappen.TabIndex = 1;
            this.btnWocheAufklappen.UseCompatibleTextRendering = true;
            this.btnWocheAufklappen.UseVisualStyleBackColor = false;
            this.btnWocheAufklappen.Click += new System.EventHandler(this.btnWocheAufklappen_Click);
            // 
            // grdWoche
            // 
            this.grdWoche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdWoche.EmbeddedNavigator.Name = "";
            this.grdWoche.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdWoche.Location = new System.Drawing.Point(0, 0);
            this.grdWoche.MainView = this.grvWoche;
            this.grdWoche.Name = "grdWoche";
            this.grdWoche.Size = new System.Drawing.Size(917, 515);
            this.grdWoche.TabIndex = 0;
            this.grdWoche.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWoche});
            // 
            // grvWoche
            // 
            this.grvWoche.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvWoche.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.Empty.Options.UseBackColor = true;
            this.grvWoche.Appearance.Empty.Options.UseFont = true;
            this.grvWoche.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.EvenRow.Options.UseFont = true;
            this.grvWoche.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWoche.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvWoche.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvWoche.Appearance.FocusedCell.Options.UseFont = true;
            this.grvWoche.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvWoche.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWoche.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvWoche.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvWoche.Appearance.FocusedRow.Options.UseFont = true;
            this.grvWoche.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvWoche.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWoche.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvWoche.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWoche.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWoche.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvWoche.Appearance.GroupRow.Options.UseFont = true;
            this.grvWoche.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvWoche.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvWoche.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvWoche.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvWoche.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvWoche.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWoche.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvWoche.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWoche.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvWoche.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvWoche.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvWoche.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvWoche.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvWoche.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.OddRow.Options.UseFont = true;
            this.grvWoche.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvWoche.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.Row.Options.UseBackColor = true;
            this.grvWoche.Appearance.Row.Options.UseFont = true;
            this.grvWoche.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWoche.Appearance.SelectedRow.Options.UseFont = true;
            this.grvWoche.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvWoche.Appearance.VertLine.Options.UseBackColor = true;
            this.grvWoche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvWoche.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWocheWoche,
            this.colWocheTag,
            this.colWocheDatum,
            this.colWocheTagesIst,
            this.colWocheZeitrechnertotal,
            this.colWocheDifferenz});
            this.grvWoche.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvWoche.GridControl = this.grdWoche;
            this.grvWoche.GroupCount = 1;
            this.grvWoche.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.grvWoche.GroupFormat = "{1}";
            this.grvWoche.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvWoche.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TagesIst", this.colWocheTagesIst, "{0:0.00;-0.00;#.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Zeitrechnertotal", this.colWocheZeitrechnertotal, "{0:0.00;-0.00;#.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Differenz", this.colWocheDifferenz, "{0:0.00;-0.00;#.##}")});
            this.grvWoche.Name = "grvWoche";
            this.grvWoche.OptionsBehavior.Editable = false;
            this.grvWoche.OptionsCustomization.AllowFilter = false;
            this.grvWoche.OptionsFilter.AllowFilterEditor = false;
            this.grvWoche.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvWoche.OptionsNavigation.AutoFocusNewRow = true;
            this.grvWoche.OptionsNavigation.UseTabKey = false;
            this.grvWoche.OptionsView.ColumnAutoWidth = false;
            this.grvWoche.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvWoche.OptionsView.ShowGroupPanel = false;
            this.grvWoche.OptionsView.ShowIndicator = false;
            this.grvWoche.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWocheWoche, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvWoche.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvWoche_CustomDrawCell);
            this.grvWoche.CustomDrawRowFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.grvWoche_CustomDrawFooterCell);
            // 
            // colWocheWoche
            // 
            this.colWocheWoche.Caption = "Woche";
            this.colWocheWoche.FieldName = "Woche";
            this.colWocheWoche.Name = "colWocheWoche";
            // 
            // colWocheTag
            // 
            this.colWocheTag.Caption = "Tag";
            this.colWocheTag.FieldName = "WT";
            this.colWocheTag.Name = "colWocheTag";
            this.colWocheTag.Visible = true;
            this.colWocheTag.VisibleIndex = 0;
            this.colWocheTag.Width = 55;
            // 
            // colWocheDatum
            // 
            this.colWocheDatum.Caption = "Datum";
            this.colWocheDatum.FieldName = "Datum";
            this.colWocheDatum.Name = "colWocheDatum";
            this.colWocheDatum.Visible = true;
            this.colWocheDatum.VisibleIndex = 1;
            this.colWocheDatum.Width = 80;
            // 
            // colWocheTagesIst
            // 
            this.colWocheTagesIst.AppearanceCell.Options.UseTextOptions = true;
            this.colWocheTagesIst.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colWocheTagesIst.Caption = "Tages-Ist";
            this.colWocheTagesIst.DisplayFormat.FormatString = "0.00";
            this.colWocheTagesIst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWocheTagesIst.FieldName = "TagesIst";
            this.colWocheTagesIst.Name = "colWocheTagesIst";
            this.colWocheTagesIst.Visible = true;
            this.colWocheTagesIst.VisibleIndex = 3;
            this.colWocheTagesIst.Width = 80;
            // 
            // colWocheZeitrechnertotal
            // 
            this.colWocheZeitrechnertotal.AppearanceCell.Options.UseTextOptions = true;
            this.colWocheZeitrechnertotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colWocheZeitrechnertotal.Caption = "Zeitrechnertotal";
            this.colWocheZeitrechnertotal.DisplayFormat.FormatString = "0.00";
            this.colWocheZeitrechnertotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWocheZeitrechnertotal.FieldName = "Zeitrechnertotal";
            this.colWocheZeitrechnertotal.Name = "colWocheZeitrechnertotal";
            this.colWocheZeitrechnertotal.Visible = true;
            this.colWocheZeitrechnertotal.VisibleIndex = 2;
            this.colWocheZeitrechnertotal.Width = 105;
            // 
            // colWocheDifferenz
            // 
            this.colWocheDifferenz.AppearanceCell.Options.UseTextOptions = true;
            this.colWocheDifferenz.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colWocheDifferenz.Caption = "Differenz";
            this.colWocheDifferenz.DisplayFormat.FormatString = "0.00";
            this.colWocheDifferenz.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWocheDifferenz.FieldName = "Differenz";
            this.colWocheDifferenz.Name = "colWocheDifferenz";
            this.colWocheDifferenz.Visible = true;
            this.colWocheDifferenz.VisibleIndex = 4;
            this.colWocheDifferenz.Width = 80;
            // 
            // tpgMonat
            // 
            this.tpgMonat.Controls.Add(this.btnMonatFakturiertEntfernen);
            this.tpgMonat.Controls.Add(this.btnMonatFakturiertSetzen);
            this.tpgMonat.Controls.Add(this.btnMonatVisumAufheben);
            this.tpgMonat.Controls.Add(this.btnMonatVisieren);
            this.tpgMonat.Controls.Add(this.btnMonatFreigabeAufheben);
            this.tpgMonat.Controls.Add(this.btnMonatFreigeben);
            this.tpgMonat.Controls.Add(this.grdMonat);
            this.tpgMonat.Location = new System.Drawing.Point(6, 6);
            this.tpgMonat.Name = "tpgMonat";
            this.tpgMonat.Size = new System.Drawing.Size(947, 515);
            this.tpgMonat.TabIndex = 1;
            this.tpgMonat.Title = "&Monat";
            // 
            // btnMonatFakturiertEntfernen
            // 
            this.btnMonatFakturiertEntfernen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatFakturiertEntfernen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatFakturiertEntfernen.Location = new System.Drawing.Point(819, 172);
            this.btnMonatFakturiertEntfernen.Name = "btnMonatFakturiertEntfernen";
            this.btnMonatFakturiertEntfernen.Size = new System.Drawing.Size(125, 24);
            this.btnMonatFakturiertEntfernen.TabIndex = 6;
            this.btnMonatFakturiertEntfernen.Text = "Fakturiert entfernen";
            this.btnMonatFakturiertEntfernen.UseVisualStyleBackColor = false;
            this.btnMonatFakturiertEntfernen.Click += new System.EventHandler(this.btnMonatFakturiertEntfernen_Click);
            // 
            // btnMonatFakturiertSetzen
            // 
            this.btnMonatFakturiertSetzen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatFakturiertSetzen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatFakturiertSetzen.Location = new System.Drawing.Point(819, 142);
            this.btnMonatFakturiertSetzen.Name = "btnMonatFakturiertSetzen";
            this.btnMonatFakturiertSetzen.Size = new System.Drawing.Size(125, 24);
            this.btnMonatFakturiertSetzen.TabIndex = 5;
            this.btnMonatFakturiertSetzen.Text = "Fakturiert setzen";
            this.btnMonatFakturiertSetzen.UseVisualStyleBackColor = false;
            this.btnMonatFakturiertSetzen.Click += new System.EventHandler(this.btnMonatFakturiertSetzen_Click);
            // 
            // btnMonatVisumAufheben
            // 
            this.btnMonatVisumAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatVisumAufheben.Enabled = false;
            this.btnMonatVisumAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatVisumAufheben.Location = new System.Drawing.Point(819, 102);
            this.btnMonatVisumAufheben.Name = "btnMonatVisumAufheben";
            this.btnMonatVisumAufheben.Size = new System.Drawing.Size(125, 24);
            this.btnMonatVisumAufheben.TabIndex = 4;
            this.btnMonatVisumAufheben.Text = "Visum aufheben";
            this.btnMonatVisumAufheben.UseCompatibleTextRendering = true;
            this.btnMonatVisumAufheben.UseVisualStyleBackColor = false;
            this.btnMonatVisumAufheben.Click += new System.EventHandler(this.btnMonatVisumAufheben_Click);
            // 
            // btnMonatVisieren
            // 
            this.btnMonatVisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatVisieren.Enabled = false;
            this.btnMonatVisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatVisieren.Location = new System.Drawing.Point(819, 72);
            this.btnMonatVisieren.Name = "btnMonatVisieren";
            this.btnMonatVisieren.Size = new System.Drawing.Size(125, 24);
            this.btnMonatVisieren.TabIndex = 3;
            this.btnMonatVisieren.Text = "Monat visieren";
            this.btnMonatVisieren.UseCompatibleTextRendering = true;
            this.btnMonatVisieren.UseVisualStyleBackColor = false;
            this.btnMonatVisieren.Click += new System.EventHandler(this.btnMonatVisieren_Click);
            // 
            // btnMonatFreigabeAufheben
            // 
            this.btnMonatFreigabeAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatFreigabeAufheben.Enabled = false;
            this.btnMonatFreigabeAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatFreigabeAufheben.Location = new System.Drawing.Point(819, 32);
            this.btnMonatFreigabeAufheben.Name = "btnMonatFreigabeAufheben";
            this.btnMonatFreigabeAufheben.Size = new System.Drawing.Size(125, 24);
            this.btnMonatFreigabeAufheben.TabIndex = 2;
            this.btnMonatFreigabeAufheben.Text = "Freig. aufheben";
            this.btnMonatFreigabeAufheben.UseCompatibleTextRendering = true;
            this.btnMonatFreigabeAufheben.UseVisualStyleBackColor = false;
            this.btnMonatFreigabeAufheben.Click += new System.EventHandler(this.btnMonatFreigabeAufheben_Click);
            // 
            // btnMonatFreigeben
            // 
            this.btnMonatFreigeben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatFreigeben.Enabled = false;
            this.btnMonatFreigeben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatFreigeben.Location = new System.Drawing.Point(819, 2);
            this.btnMonatFreigeben.Name = "btnMonatFreigeben";
            this.btnMonatFreigeben.Size = new System.Drawing.Size(125, 24);
            this.btnMonatFreigeben.TabIndex = 1;
            this.btnMonatFreigeben.Text = "Monat freigeben";
            this.btnMonatFreigeben.UseCompatibleTextRendering = true;
            this.btnMonatFreigeben.UseVisualStyleBackColor = false;
            this.btnMonatFreigeben.Click += new System.EventHandler(this.btnMonatFreigeben_Click);
            // 
            // grdMonat
            // 
            this.grdMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMonat.DataSource = this.qryMonat;
            // 
            // 
            // 
            this.grdMonat.EmbeddedNavigator.Name = "";
            this.grdMonat.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMonat.Location = new System.Drawing.Point(0, 0);
            this.grdMonat.MainView = this.grvMonat;
            this.grdMonat.Name = "grdMonat";
            this.grdMonat.Size = new System.Drawing.Size(813, 515);
            this.grdMonat.TabIndex = 0;
            this.grdMonat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMonat});
            // 
            // qryMonat
            // 
            this.qryMonat.HostControl = this;
            this.qryMonat.IsIdentityInsert = false;
            this.qryMonat.PositionChanged += new System.EventHandler(this.qryMonat_PositionChanged);
            // 
            // grvMonat
            // 
            this.grvMonat.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvMonat.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.Empty.Options.UseBackColor = true;
            this.grvMonat.Appearance.Empty.Options.UseFont = true;
            this.grvMonat.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.EvenRow.Options.UseFont = true;
            this.grvMonat.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMonat.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvMonat.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMonat.Appearance.FocusedCell.Options.UseFont = true;
            this.grvMonat.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMonat.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMonat.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMonat.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMonat.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMonat.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMonat.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMonat.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMonat.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMonat.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMonat.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMonat.Appearance.GroupRow.Options.UseFont = true;
            this.grvMonat.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMonat.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvMonat.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvMonat.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMonat.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMonat.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMonat.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvMonat.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMonat.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMonat.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvMonat.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMonat.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvMonat.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMonat.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.OddRow.Options.UseFont = true;
            this.grvMonat.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvMonat.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.Row.Options.UseBackColor = true;
            this.grvMonat.Appearance.Row.Options.UseFont = true;
            this.grvMonat.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMonat.Appearance.SelectedRow.Options.UseFont = true;
            this.grvMonat.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvMonat.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMonat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvMonat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonatJahr,
            this.colMonatMonat,
            this.colMonatFreigegeben,
            this.colMonatVisiert,
            this.colMonatVerbucht,
            this.colMonatVerbuchtLD,
            this.colMonatFakturiert,
            this.colMonatSpacer1,
            this.colMonatBeschaeftigungsgrad,
            this.colMonatGZIstArbeitszeit,
            this.colMonatGZSollArbeitszeit,
            this.colMonatGZMonatssaldo,
            this.collMonatGZSaldo,
            this.colMonatGZUebertragVorjahr,
            this.colMonatGZKorrekturen,
            this.colMonatGZBezUeberstunden,
            this.colMonatSpacer2,
            this.colMonatSLIstArbeitszeit,
            this.colMonatSpacer3,
            this.colMonatFerienBezogenMonat,
            this.colMonatFerienSaldo,
            this.colMonatFerienUebertragVorjahr,
            this.colMonatFerienAnspruchProJahr,
            this.colMonatFerienBisherBezogen,
            this.colMonatFerienZugabenKuerzungen,
            this.colMonatFerienKorrekturen});
            this.grvMonat.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMonat.GridControl = this.grdMonat;
            this.grvMonat.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvMonat.Name = "grvMonat";
            this.grvMonat.OptionsBehavior.Editable = false;
            this.grvMonat.OptionsCustomization.AllowFilter = false;
            this.grvMonat.OptionsFilter.AllowFilterEditor = false;
            this.grvMonat.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvMonat.OptionsNavigation.AutoFocusNewRow = true;
            this.grvMonat.OptionsNavigation.UseTabKey = false;
            this.grvMonat.OptionsView.ColumnAutoWidth = false;
            this.grvMonat.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMonat.OptionsView.ShowGroupPanel = false;
            this.grvMonat.OptionsView.ShowIndicator = false;
            this.grvMonat.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvMonat_CustomDrawCell);
            // 
            // colMonatJahr
            // 
            this.colMonatJahr.Caption = "Jahr";
            this.colMonatJahr.FieldName = "Jahr";
            this.colMonatJahr.Name = "colMonatJahr";
            this.colMonatJahr.Visible = true;
            this.colMonatJahr.VisibleIndex = 0;
            this.colMonatJahr.Width = 50;
            // 
            // colMonatMonat
            // 
            this.colMonatMonat.Caption = "Monat";
            this.colMonatMonat.FieldName = "MonatText";
            this.colMonatMonat.Name = "colMonatMonat";
            this.colMonatMonat.Visible = true;
            this.colMonatMonat.VisibleIndex = 1;
            this.colMonatMonat.Width = 90;
            // 
            // colMonatFreigegeben
            // 
            this.colMonatFreigegeben.Caption = "Freig.";
            this.colMonatFreigegeben.FieldName = "Freigegeben";
            this.colMonatFreigegeben.Name = "colMonatFreigegeben";
            this.colMonatFreigegeben.Visible = true;
            this.colMonatFreigegeben.VisibleIndex = 2;
            this.colMonatFreigegeben.Width = 45;
            // 
            // colMonatVisiert
            // 
            this.colMonatVisiert.Caption = "Visiert";
            this.colMonatVisiert.FieldName = "Visiert";
            this.colMonatVisiert.Name = "colMonatVisiert";
            this.colMonatVisiert.Visible = true;
            this.colMonatVisiert.VisibleIndex = 3;
            this.colMonatVisiert.Width = 55;
            // 
            // colMonatVerbucht
            // 
            this.colMonatVerbucht.Caption = "Verbucht";
            this.colMonatVerbucht.FieldName = "Verbucht";
            this.colMonatVerbucht.Name = "colMonatVerbucht";
            this.colMonatVerbucht.Visible = true;
            this.colMonatVerbucht.VisibleIndex = 4;
            this.colMonatVerbucht.Width = 80;
            // 
            // colMonatVerbuchtLD
            // 
            this.colMonatVerbuchtLD.Caption = "Verbucht LD";
            this.colMonatVerbuchtLD.FieldName = "VerbuchtLD";
            this.colMonatVerbuchtLD.Name = "colMonatVerbuchtLD";
            this.colMonatVerbuchtLD.Visible = true;
            this.colMonatVerbuchtLD.VisibleIndex = 5;
            this.colMonatVerbuchtLD.Width = 80;
            // 
            // colMonatFakturiert
            // 
            this.colMonatFakturiert.Caption = "Fakturiert";
            this.colMonatFakturiert.FieldName = "Fakturiert";
            this.colMonatFakturiert.Name = "colMonatFakturiert";
            this.colMonatFakturiert.Visible = true;
            this.colMonatFakturiert.VisibleIndex = 6;
            // 
            // colMonatSpacer1
            // 
            this.colMonatSpacer1.MinWidth = 10;
            this.colMonatSpacer1.Name = "colMonatSpacer1";
            this.colMonatSpacer1.Visible = true;
            this.colMonatSpacer1.VisibleIndex = 7;
            this.colMonatSpacer1.Width = 10;
            // 
            // colMonatBeschaeftigungsgrad
            // 
            this.colMonatBeschaeftigungsgrad.Caption = "BG (%)";
            this.colMonatBeschaeftigungsgrad.FieldName = "PensumProzent";
            this.colMonatBeschaeftigungsgrad.Name = "colMonatBeschaeftigungsgrad";
            this.colMonatBeschaeftigungsgrad.Visible = true;
            this.colMonatBeschaeftigungsgrad.VisibleIndex = 8;
            this.colMonatBeschaeftigungsgrad.Width = 55;
            // 
            // colMonatGZIstArbeitszeit
            // 
            this.colMonatGZIstArbeitszeit.AppearanceCell.Options.UseTextOptions = true;
            this.colMonatGZIstArbeitszeit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMonatGZIstArbeitszeit.Caption = "Ist-Arbeitszeit";
            this.colMonatGZIstArbeitszeit.DisplayFormat.FormatString = "0.00";
            this.colMonatGZIstArbeitszeit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatGZIstArbeitszeit.FieldName = "GZIstArbeitszeitProMonat";
            this.colMonatGZIstArbeitszeit.Name = "colMonatGZIstArbeitszeit";
            this.colMonatGZIstArbeitszeit.Visible = true;
            this.colMonatGZIstArbeitszeit.VisibleIndex = 9;
            this.colMonatGZIstArbeitszeit.Width = 100;
            // 
            // colMonatGZSollArbeitszeit
            // 
            this.colMonatGZSollArbeitszeit.AppearanceCell.Options.UseTextOptions = true;
            this.colMonatGZSollArbeitszeit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMonatGZSollArbeitszeit.Caption = "Soll-Arbeitszeit";
            this.colMonatGZSollArbeitszeit.DisplayFormat.FormatString = "0.00";
            this.colMonatGZSollArbeitszeit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatGZSollArbeitszeit.FieldName = "GZSollArbeitszeitProMonat";
            this.colMonatGZSollArbeitszeit.Name = "colMonatGZSollArbeitszeit";
            this.colMonatGZSollArbeitszeit.Visible = true;
            this.colMonatGZSollArbeitszeit.VisibleIndex = 10;
            this.colMonatGZSollArbeitszeit.Width = 100;
            // 
            // colMonatGZMonatssaldo
            // 
            this.colMonatGZMonatssaldo.Caption = "Monatssaldo";
            this.colMonatGZMonatssaldo.DisplayFormat.FormatString = "0.00";
            this.colMonatGZMonatssaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatGZMonatssaldo.FieldName = "GZMonatsSaldo";
            this.colMonatGZMonatssaldo.Name = "colMonatGZMonatssaldo";
            this.colMonatGZMonatssaldo.Visible = true;
            this.colMonatGZMonatssaldo.VisibleIndex = 11;
            this.colMonatGZMonatssaldo.Width = 100;
            // 
            // collMonatGZSaldo
            // 
            this.collMonatGZSaldo.AppearanceCell.Options.UseTextOptions = true;
            this.collMonatGZSaldo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.collMonatGZSaldo.Caption = "Gleitzeitsaldo";
            this.collMonatGZSaldo.DisplayFormat.FormatString = "0.00";
            this.collMonatGZSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.collMonatGZSaldo.FieldName = "GZSaldo";
            this.collMonatGZSaldo.Name = "collMonatGZSaldo";
            this.collMonatGZSaldo.Visible = true;
            this.collMonatGZSaldo.VisibleIndex = 12;
            this.collMonatGZSaldo.Width = 100;
            // 
            // colMonatGZUebertragVorjahr
            // 
            this.colMonatGZUebertragVorjahr.Caption = "GZ-Übertrag J.";
            this.colMonatGZUebertragVorjahr.DisplayFormat.FormatString = "0.00";
            this.colMonatGZUebertragVorjahr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatGZUebertragVorjahr.FieldName = "GZUebertragVorjahr";
            this.colMonatGZUebertragVorjahr.Name = "colMonatGZUebertragVorjahr";
            this.colMonatGZUebertragVorjahr.Visible = true;
            this.colMonatGZUebertragVorjahr.VisibleIndex = 13;
            this.colMonatGZUebertragVorjahr.Width = 120;
            // 
            // colMonatGZKorrekturen
            // 
            this.colMonatGZKorrekturen.Caption = "GZ-Korrekturen";
            this.colMonatGZKorrekturen.DisplayFormat.FormatString = "0.00";
            this.colMonatGZKorrekturen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatGZKorrekturen.FieldName = "GZKorrekturen";
            this.colMonatGZKorrekturen.Name = "colMonatGZKorrekturen";
            this.colMonatGZKorrekturen.Visible = true;
            this.colMonatGZKorrekturen.VisibleIndex = 14;
            this.colMonatGZKorrekturen.Width = 120;
            // 
            // colMonatGZBezUeberstunden
            // 
            this.colMonatGZBezUeberstunden.Caption = "Bez. Überstunden";
            this.colMonatGZBezUeberstunden.DisplayFormat.FormatString = "0.00";
            this.colMonatGZBezUeberstunden.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatGZBezUeberstunden.FieldName = "GZAusbezahlteUeberstunden";
            this.colMonatGZBezUeberstunden.Name = "colMonatGZBezUeberstunden";
            this.colMonatGZBezUeberstunden.Visible = true;
            this.colMonatGZBezUeberstunden.VisibleIndex = 15;
            this.colMonatGZBezUeberstunden.Width = 120;
            // 
            // colMonatSpacer2
            // 
            this.colMonatSpacer2.MinWidth = 10;
            this.colMonatSpacer2.Name = "colMonatSpacer2";
            this.colMonatSpacer2.Visible = true;
            this.colMonatSpacer2.VisibleIndex = 16;
            this.colMonatSpacer2.Width = 10;
            // 
            // colMonatSLIstArbeitszeit
            // 
            this.colMonatSLIstArbeitszeit.Caption = "Std. auf Stundenl.";
            this.colMonatSLIstArbeitszeit.DisplayFormat.FormatString = "0.00";
            this.colMonatSLIstArbeitszeit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatSLIstArbeitszeit.FieldName = "SLIstArbeitszeitProMonat";
            this.colMonatSLIstArbeitszeit.Name = "colMonatSLIstArbeitszeit";
            this.colMonatSLIstArbeitszeit.Visible = true;
            this.colMonatSLIstArbeitszeit.VisibleIndex = 17;
            this.colMonatSLIstArbeitszeit.Width = 120;
            // 
            // colMonatSpacer3
            // 
            this.colMonatSpacer3.MinWidth = 10;
            this.colMonatSpacer3.Name = "colMonatSpacer3";
            this.colMonatSpacer3.Visible = true;
            this.colMonatSpacer3.VisibleIndex = 18;
            this.colMonatSpacer3.Width = 10;
            // 
            // colMonatFerienBezogenMonat
            // 
            this.colMonatFerienBezogenMonat.Caption = "Bezog. Ferien M.";
            this.colMonatFerienBezogenMonat.DisplayFormat.FormatString = "0.00";
            this.colMonatFerienBezogenMonat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatFerienBezogenMonat.FieldName = "FerienBezogenMonat";
            this.colMonatFerienBezogenMonat.Name = "colMonatFerienBezogenMonat";
            this.colMonatFerienBezogenMonat.Visible = true;
            this.colMonatFerienBezogenMonat.VisibleIndex = 19;
            this.colMonatFerienBezogenMonat.Width = 120;
            // 
            // colMonatFerienSaldo
            // 
            this.colMonatFerienSaldo.Caption = "Feriensaldo";
            this.colMonatFerienSaldo.DisplayFormat.FormatString = "0.00";
            this.colMonatFerienSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatFerienSaldo.FieldName = "FerienSaldo";
            this.colMonatFerienSaldo.Name = "colMonatFerienSaldo";
            this.colMonatFerienSaldo.Visible = true;
            this.colMonatFerienSaldo.VisibleIndex = 20;
            this.colMonatFerienSaldo.Width = 100;
            // 
            // colMonatFerienUebertragVorjahr
            // 
            this.colMonatFerienUebertragVorjahr.Caption = "Ferien-Übertrag J.";
            this.colMonatFerienUebertragVorjahr.DisplayFormat.FormatString = "0.00";
            this.colMonatFerienUebertragVorjahr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatFerienUebertragVorjahr.FieldName = "FerienUebertragVorjahr";
            this.colMonatFerienUebertragVorjahr.Name = "colMonatFerienUebertragVorjahr";
            this.colMonatFerienUebertragVorjahr.Visible = true;
            this.colMonatFerienUebertragVorjahr.VisibleIndex = 21;
            this.colMonatFerienUebertragVorjahr.Width = 120;
            // 
            // colMonatFerienAnspruchProJahr
            // 
            this.colMonatFerienAnspruchProJahr.Caption = "Ferienanspruch";
            this.colMonatFerienAnspruchProJahr.DisplayFormat.FormatString = "0.00";
            this.colMonatFerienAnspruchProJahr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatFerienAnspruchProJahr.FieldName = "FerienAnspruchProJahr";
            this.colMonatFerienAnspruchProJahr.Name = "colMonatFerienAnspruchProJahr";
            this.colMonatFerienAnspruchProJahr.Visible = true;
            this.colMonatFerienAnspruchProJahr.VisibleIndex = 22;
            this.colMonatFerienAnspruchProJahr.Width = 120;
            // 
            // colMonatFerienBisherBezogen
            // 
            this.colMonatFerienBisherBezogen.Caption = "Bezogene Ferien";
            this.colMonatFerienBisherBezogen.DisplayFormat.FormatString = "0.00";
            this.colMonatFerienBisherBezogen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatFerienBisherBezogen.FieldName = "FerienBisherBezogen";
            this.colMonatFerienBisherBezogen.Name = "colMonatFerienBisherBezogen";
            this.colMonatFerienBisherBezogen.Visible = true;
            this.colMonatFerienBisherBezogen.VisibleIndex = 23;
            this.colMonatFerienBisherBezogen.Width = 120;
            // 
            // colMonatFerienZugabenKuerzungen
            // 
            this.colMonatFerienZugabenKuerzungen.Caption = "Ferien Zugab./Kürz.";
            this.colMonatFerienZugabenKuerzungen.DisplayFormat.FormatString = "0.00";
            this.colMonatFerienZugabenKuerzungen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatFerienZugabenKuerzungen.FieldName = "FerienZugabenKuerzungen";
            this.colMonatFerienZugabenKuerzungen.Name = "colMonatFerienZugabenKuerzungen";
            this.colMonatFerienZugabenKuerzungen.Visible = true;
            this.colMonatFerienZugabenKuerzungen.VisibleIndex = 24;
            this.colMonatFerienZugabenKuerzungen.Width = 120;
            // 
            // colMonatFerienKorrekturen
            // 
            this.colMonatFerienKorrekturen.Caption = "Ferienkorrekturen";
            this.colMonatFerienKorrekturen.DisplayFormat.FormatString = "0.00";
            this.colMonatFerienKorrekturen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatFerienKorrekturen.FieldName = "FerienKorrekturen";
            this.colMonatFerienKorrekturen.Name = "colMonatFerienKorrekturen";
            this.colMonatFerienKorrekturen.Visible = true;
            this.colMonatFerienKorrekturen.VisibleIndex = 25;
            this.colMonatFerienKorrekturen.Width = 120;
            // 
            // tpgErfassung
            // 
            this.tpgErfassung.Controls.Add(this.edtFakturiert);
            this.tpgErfassung.Controls.Add(this.edtErfassungKostentraeger);
            this.tpgErfassung.Controls.Add(this.lblErfassungKostentraeger);
            this.tpgErfassung.Controls.Add(this.btnKeinExportUmschalten);
            this.tpgErfassung.Controls.Add(this.edtKeinExport);
            this.tpgErfassung.Controls.Add(this.lblKeinExport);
            this.tpgErfassung.Controls.Add(this.panErfassungZeitInfo);
            this.tpgErfassung.Controls.Add(this.btnErfassungKopie);
            this.tpgErfassung.Controls.Add(this.memErfassungBemerkungen);
            this.tpgErfassung.Controls.Add(this.lblErfassungBemerkungen);
            this.tpgErfassung.Controls.Add(this.btnErfassungTag1);
            this.tpgErfassung.Controls.Add(this.btnErfassungTag05);
            this.tpgErfassung.Controls.Add(this.lblErfassungMin);
            this.tpgErfassung.Controls.Add(this.edtErfassungMinuten);
            this.tpgErfassung.Controls.Add(this.lblErfassungStd);
            this.tpgErfassung.Controls.Add(this.edtErfassungStunden);
            this.tpgErfassung.Controls.Add(this.lblErfassungDauer);
            this.tpgErfassung.Controls.Add(this.edtErfassungLohnart);
            this.tpgErfassung.Controls.Add(this.lblErfassungLohnart);
            this.tpgErfassung.Controls.Add(this.edtErfassungKostenstelle);
            this.tpgErfassung.Controls.Add(this.lblErfassungKostenstelle);
            this.tpgErfassung.Controls.Add(this.edtErfassungAnzahl);
            this.tpgErfassung.Controls.Add(this.lblErfassungAnzahl);
            this.tpgErfassung.Controls.Add(this.edtErfassungLeistungsart);
            this.tpgErfassung.Controls.Add(this.lblErfassungLeistungsart);
            this.tpgErfassung.Controls.Add(this.edtErfassungKlient);
            this.tpgErfassung.Controls.Add(this.lblErfassungKlient);
            this.tpgErfassung.Controls.Add(this.edtErfassungDatum);
            this.tpgErfassung.Controls.Add(this.tabErfassung);
            this.tpgErfassung.Controls.Add(this.lblErfassungDatum);
            this.tpgErfassung.Location = new System.Drawing.Point(6, 6);
            this.tpgErfassung.Name = "tpgErfassung";
            this.tpgErfassung.Size = new System.Drawing.Size(947, 515);
            this.tpgErfassung.TabIndex = 0;
            this.tpgErfassung.Title = "&Erfassung";
            // 
            // edtFakturiert
            // 
            this.edtFakturiert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFakturiert.DataMember = "Fakturiert";
            this.edtFakturiert.DataSource = this.qryData;
            this.edtFakturiert.Location = new System.Drawing.Point(219, 400);
            this.edtFakturiert.Name = "edtFakturiert";
            this.edtFakturiert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFakturiert.Properties.Appearance.Options.UseBackColor = true;
            this.edtFakturiert.Properties.Caption = "Fakturiert";
            this.edtFakturiert.Size = new System.Drawing.Size(75, 19);
            this.edtFakturiert.TabIndex = 28;
            // 
            // qryData
            // 
            this.qryData.CanDelete = true;
            this.qryData.CanInsert = true;
            this.qryData.CanUpdate = true;
            this.qryData.HostControl = this;
            this.qryData.IsIdentityInsert = false;
            this.qryData.TableName = "BDELeistung";
            this.qryData.AfterFill += new System.EventHandler(this.qryData_AfterFill);
            this.qryData.AfterInsert += new System.EventHandler(this.qryData_AfterInsert);
            this.qryData.AfterPost += new System.EventHandler(this.qryData_AfterPost);
            this.qryData.BeforeDelete += new System.EventHandler(this.qryData_BeforeDelete);
            this.qryData.BeforeDeleteQuestion += new System.EventHandler(this.qryData_BeforeDeleteQuestion);
            this.qryData.BeforePost += new System.EventHandler(this.qryData_BeforePost);
            this.qryData.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryData_ColumnChanged);
            this.qryData.PositionChanged += new System.EventHandler(this.qryData_PositionChanged);
            // 
            // edtErfassungKostentraeger
            // 
            this.edtErfassungKostentraeger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErfassungKostentraeger.DataMember = "HistKostentraeger";
            this.edtErfassungKostentraeger.DataSource = this.qryData;
            this.edtErfassungKostentraeger.Location = new System.Drawing.Point(568, 395);
            this.edtErfassungKostentraeger.Name = "edtErfassungKostentraeger";
            this.edtErfassungKostentraeger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungKostentraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungKostentraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungKostentraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungKostentraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungKostentraeger.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungKostentraeger.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErfassungKostentraeger.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungKostentraeger.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErfassungKostentraeger.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErfassungKostentraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtErfassungKostentraeger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtErfassungKostentraeger.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungKostentraeger.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtErfassungKostentraeger.Properties.DisplayMember = "Text";
            this.edtErfassungKostentraeger.Properties.NullText = "";
            this.edtErfassungKostentraeger.Properties.ShowFooter = false;
            this.edtErfassungKostentraeger.Properties.ShowHeader = false;
            this.edtErfassungKostentraeger.Properties.ValueMember = "Code";
            this.edtErfassungKostentraeger.Size = new System.Drawing.Size(190, 24);
            this.edtErfassungKostentraeger.TabIndex = 27;
            // 
            // lblErfassungKostentraeger
            // 
            this.lblErfassungKostentraeger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungKostentraeger.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungKostentraeger.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungKostentraeger.Location = new System.Drawing.Point(464, 395);
            this.lblErfassungKostentraeger.Name = "lblErfassungKostentraeger";
            this.lblErfassungKostentraeger.Size = new System.Drawing.Size(98, 24);
            this.lblErfassungKostentraeger.TabIndex = 26;
            this.lblErfassungKostentraeger.Text = "Kostenträger";
            this.lblErfassungKostentraeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungKostentraeger.UseCompatibleTextRendering = true;
            // 
            // btnKeinExportUmschalten
            // 
            this.btnKeinExportUmschalten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKeinExportUmschalten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeinExportUmschalten.Location = new System.Drawing.Point(309, 395);
            this.btnKeinExportUmschalten.Name = "btnKeinExportUmschalten";
            this.btnKeinExportUmschalten.Size = new System.Drawing.Size(137, 24);
            this.btnKeinExportUmschalten.TabIndex = 25;
            this.btnKeinExportUmschalten.Text = "Unverb. Leist. umsch.";
            this.btnKeinExportUmschalten.UseVisualStyleBackColor = false;
            this.btnKeinExportUmschalten.Click += new System.EventHandler(this.btnKeinExportUmschalten_Click);
            // 
            // edtKeinExport
            // 
            this.edtKeinExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKeinExport.DataMember = "KeinExport";
            this.edtKeinExport.DataSource = this.qryData;
            this.edtKeinExport.Location = new System.Drawing.Point(219, 372);
            this.edtKeinExport.Name = "edtKeinExport";
            this.edtKeinExport.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKeinExport.Properties.Appearance.Options.UseBackColor = true;
            this.edtKeinExport.Properties.Caption = "Kein Export";
            this.edtKeinExport.Size = new System.Drawing.Size(82, 19);
            this.edtKeinExport.TabIndex = 24;
            // 
            // lblKeinExport
            // 
            this.lblKeinExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKeinExport.Location = new System.Drawing.Point(216, 369);
            this.lblKeinExport.Name = "lblKeinExport";
            this.lblKeinExport.Size = new System.Drawing.Size(228, 24);
            this.lblKeinExport.TabIndex = 23;
            this.lblKeinExport.Text = "Stunden werden nicht exportiert";
            // 
            // panErfassungZeitInfo
            // 
            this.panErfassungZeitInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panErfassungZeitInfo.Controls.Add(this.lblErfassungDifferenz);
            this.panErfassungZeitInfo.Controls.Add(this.lblErfassungDifferenzC);
            this.panErfassungZeitInfo.Controls.Add(this.panErfassungLineDifferenz);
            this.panErfassungZeitInfo.Controls.Add(this.lblErfassungTagesIst);
            this.panErfassungZeitInfo.Controls.Add(this.lblErfassungTagesIstC);
            this.panErfassungZeitInfo.Controls.Add(this.lblErfassungZeitrechnerTotal);
            this.panErfassungZeitInfo.Controls.Add(this.lblErfassungZeitrechnerTotalC);
            this.panErfassungZeitInfo.Location = new System.Drawing.Point(772, 394);
            this.panErfassungZeitInfo.Name = "panErfassungZeitInfo";
            this.panErfassungZeitInfo.Size = new System.Drawing.Size(170, 85);
            this.panErfassungZeitInfo.TabIndex = 22;
            // 
            // lblErfassungDifferenz
            // 
            this.lblErfassungDifferenz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErfassungDifferenz.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblErfassungDifferenz.Location = new System.Drawing.Point(100, 59);
            this.lblErfassungDifferenz.Name = "lblErfassungDifferenz";
            this.lblErfassungDifferenz.Size = new System.Drawing.Size(57, 24);
            this.lblErfassungDifferenz.TabIndex = 6;
            this.lblErfassungDifferenz.Text = "0:00";
            this.lblErfassungDifferenz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErfassungDifferenz.UseCompatibleTextRendering = true;
            // 
            // lblErfassungDifferenzC
            // 
            this.lblErfassungDifferenzC.Location = new System.Drawing.Point(4, 59);
            this.lblErfassungDifferenzC.Name = "lblErfassungDifferenzC";
            this.lblErfassungDifferenzC.Size = new System.Drawing.Size(90, 24);
            this.lblErfassungDifferenzC.TabIndex = 5;
            this.lblErfassungDifferenzC.Text = "Differenz";
            this.lblErfassungDifferenzC.UseCompatibleTextRendering = true;
            // 
            // panErfassungLineDifferenz
            // 
            this.panErfassungLineDifferenz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panErfassungLineDifferenz.BackColor = System.Drawing.Color.Black;
            this.panErfassungLineDifferenz.Location = new System.Drawing.Point(6, 57);
            this.panErfassungLineDifferenz.Name = "panErfassungLineDifferenz";
            this.panErfassungLineDifferenz.Size = new System.Drawing.Size(151, 1);
            this.panErfassungLineDifferenz.TabIndex = 4;
            // 
            // lblErfassungTagesIst
            // 
            this.lblErfassungTagesIst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErfassungTagesIst.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblErfassungTagesIst.Location = new System.Drawing.Point(100, 30);
            this.lblErfassungTagesIst.Name = "lblErfassungTagesIst";
            this.lblErfassungTagesIst.Size = new System.Drawing.Size(57, 24);
            this.lblErfassungTagesIst.TabIndex = 3;
            this.lblErfassungTagesIst.Text = "8:24";
            this.lblErfassungTagesIst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErfassungTagesIst.UseCompatibleTextRendering = true;
            // 
            // lblErfassungTagesIstC
            // 
            this.lblErfassungTagesIstC.Location = new System.Drawing.Point(4, 30);
            this.lblErfassungTagesIstC.Name = "lblErfassungTagesIstC";
            this.lblErfassungTagesIstC.Size = new System.Drawing.Size(90, 24);
            this.lblErfassungTagesIstC.TabIndex = 2;
            this.lblErfassungTagesIstC.Text = "Tages-Ist";
            this.lblErfassungTagesIstC.UseCompatibleTextRendering = true;
            // 
            // lblErfassungZeitrechnerTotal
            // 
            this.lblErfassungZeitrechnerTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErfassungZeitrechnerTotal.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblErfassungZeitrechnerTotal.Location = new System.Drawing.Point(100, 4);
            this.lblErfassungZeitrechnerTotal.Name = "lblErfassungZeitrechnerTotal";
            this.lblErfassungZeitrechnerTotal.Size = new System.Drawing.Size(57, 24);
            this.lblErfassungZeitrechnerTotal.TabIndex = 1;
            this.lblErfassungZeitrechnerTotal.Text = "8:24";
            this.lblErfassungZeitrechnerTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErfassungZeitrechnerTotal.UseCompatibleTextRendering = true;
            // 
            // lblErfassungZeitrechnerTotalC
            // 
            this.lblErfassungZeitrechnerTotalC.Location = new System.Drawing.Point(4, 4);
            this.lblErfassungZeitrechnerTotalC.Name = "lblErfassungZeitrechnerTotalC";
            this.lblErfassungZeitrechnerTotalC.Size = new System.Drawing.Size(90, 24);
            this.lblErfassungZeitrechnerTotalC.TabIndex = 0;
            this.lblErfassungZeitrechnerTotalC.Text = "Zeitrechnertotal";
            this.lblErfassungZeitrechnerTotalC.UseCompatibleTextRendering = true;
            // 
            // btnErfassungKopie
            // 
            this.btnErfassungKopie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErfassungKopie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfassungKopie.Location = new System.Drawing.Point(772, 368);
            this.btnErfassungKopie.Name = "btnErfassungKopie";
            this.btnErfassungKopie.Size = new System.Drawing.Size(98, 24);
            this.btnErfassungKopie.TabIndex = 21;
            this.btnErfassungKopie.Text = "&Kopie";
            this.btnErfassungKopie.UseCompatibleTextRendering = true;
            this.btnErfassungKopie.UseVisualStyleBackColor = false;
            this.btnErfassungKopie.Click += new System.EventHandler(this.btnErfassungKopie_Click);
            // 
            // memErfassungBemerkungen
            // 
            this.memErfassungBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memErfassungBemerkungen.DataMember = "Bemerkung";
            this.memErfassungBemerkungen.DataSource = this.qryData;
            this.memErfassungBemerkungen.Location = new System.Drawing.Point(568, 485);
            this.memErfassungBemerkungen.Name = "memErfassungBemerkungen";
            this.memErfassungBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memErfassungBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memErfassungBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memErfassungBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memErfassungBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memErfassungBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memErfassungBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memErfassungBemerkungen.Size = new System.Drawing.Size(374, 24);
            this.memErfassungBemerkungen.TabIndex = 20;
            // 
            // lblErfassungBemerkungen
            // 
            this.lblErfassungBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungBemerkungen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungBemerkungen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungBemerkungen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungBemerkungen.Location = new System.Drawing.Point(464, 485);
            this.lblErfassungBemerkungen.Name = "lblErfassungBemerkungen";
            this.lblErfassungBemerkungen.Size = new System.Drawing.Size(98, 24);
            this.lblErfassungBemerkungen.TabIndex = 19;
            this.lblErfassungBemerkungen.Text = "Bemerkungen";
            this.lblErfassungBemerkungen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungBemerkungen.UseCompatibleTextRendering = true;
            this.lblErfassungBemerkungen.Click += new System.EventHandler(this.Label_Click);
            // 
            // btnErfassungTag1
            // 
            this.btnErfassungTag1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnErfassungTag1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfassungTag1.Location = new System.Drawing.Point(364, 485);
            this.btnErfassungTag1.Name = "btnErfassungTag1";
            this.btnErfassungTag1.Size = new System.Drawing.Size(82, 24);
            this.btnErfassungTag1.TabIndex = 18;
            this.btnErfassungTag1.Text = "1 Tag";
            this.btnErfassungTag1.UseCompatibleTextRendering = true;
            this.btnErfassungTag1.UseVisualStyleBackColor = false;
            this.btnErfassungTag1.Click += new System.EventHandler(this.btnErfassungTag1_Click);
            // 
            // btnErfassungTag05
            // 
            this.btnErfassungTag05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnErfassungTag05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfassungTag05.Location = new System.Drawing.Point(276, 485);
            this.btnErfassungTag05.Name = "btnErfassungTag05";
            this.btnErfassungTag05.Size = new System.Drawing.Size(82, 24);
            this.btnErfassungTag05.TabIndex = 17;
            this.btnErfassungTag05.Text = "½ Tag";
            this.btnErfassungTag05.UseCompatibleTextRendering = true;
            this.btnErfassungTag05.UseVisualStyleBackColor = false;
            this.btnErfassungTag05.Click += new System.EventHandler(this.btnErfassungTag05_Click);
            // 
            // lblErfassungMin
            // 
            this.lblErfassungMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungMin.Location = new System.Drawing.Point(231, 485);
            this.lblErfassungMin.Name = "lblErfassungMin";
            this.lblErfassungMin.Size = new System.Drawing.Size(37, 24);
            this.lblErfassungMin.TabIndex = 16;
            this.lblErfassungMin.Text = "Min.";
            this.lblErfassungMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungMin.UseCompatibleTextRendering = true;
            // 
            // edtErfassungMinuten
            // 
            this.edtErfassungMinuten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErfassungMinuten.DataMember = "Minuten";
            this.edtErfassungMinuten.DataSource = this.qryData;
            this.edtErfassungMinuten.Location = new System.Drawing.Point(187, 485);
            this.edtErfassungMinuten.Name = "edtErfassungMinuten";
            this.edtErfassungMinuten.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungMinuten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungMinuten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungMinuten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungMinuten.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungMinuten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungMinuten.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungMinuten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassungMinuten.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungMinuten.Properties.DisplayFormat.FormatString = "##";
            this.edtErfassungMinuten.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtErfassungMinuten.Properties.EditFormat.FormatString = "##";
            this.edtErfassungMinuten.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtErfassungMinuten.Properties.Mask.EditMask = "##";
            this.edtErfassungMinuten.Properties.Precision = 0;
            this.edtErfassungMinuten.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtErfassungMinuten.Size = new System.Drawing.Size(38, 24);
            this.edtErfassungMinuten.TabIndex = 15;
            // 
            // lblErfassungStd
            // 
            this.lblErfassungStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungStd.Location = new System.Drawing.Point(148, 485);
            this.lblErfassungStd.Name = "lblErfassungStd";
            this.lblErfassungStd.Size = new System.Drawing.Size(33, 24);
            this.lblErfassungStd.TabIndex = 14;
            this.lblErfassungStd.Text = "Std.";
            this.lblErfassungStd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungStd.UseCompatibleTextRendering = true;
            // 
            // edtErfassungStunden
            // 
            this.edtErfassungStunden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErfassungStunden.DataMember = "Stunden";
            this.edtErfassungStunden.DataSource = this.qryData;
            this.edtErfassungStunden.Location = new System.Drawing.Point(99, 485);
            this.edtErfassungStunden.Name = "edtErfassungStunden";
            this.edtErfassungStunden.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungStunden.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungStunden.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungStunden.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungStunden.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungStunden.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungStunden.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungStunden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassungStunden.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungStunden.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtErfassungStunden.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtErfassungStunden.Properties.Precision = 2;
            this.edtErfassungStunden.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtErfassungStunden.Size = new System.Drawing.Size(43, 24);
            this.edtErfassungStunden.TabIndex = 13;
            this.edtErfassungStunden.Leave += new System.EventHandler(this.edtErfassungStunden_Leave);
            // 
            // lblErfassungDauer
            // 
            this.lblErfassungDauer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungDauer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungDauer.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungDauer.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungDauer.Location = new System.Drawing.Point(7, 485);
            this.lblErfassungDauer.Name = "lblErfassungDauer";
            this.lblErfassungDauer.Size = new System.Drawing.Size(86, 24);
            this.lblErfassungDauer.TabIndex = 12;
            this.lblErfassungDauer.Text = "Dauer";
            this.lblErfassungDauer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungDauer.UseCompatibleTextRendering = true;
            this.lblErfassungDauer.Click += new System.EventHandler(this.Label_Click);
            // 
            // edtErfassungLohnart
            // 
            this.edtErfassungLohnart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErfassungLohnart.DataMember = "LohnartCode";
            this.edtErfassungLohnart.DataSource = this.qryData;
            this.edtErfassungLohnart.Location = new System.Drawing.Point(568, 455);
            this.edtErfassungLohnart.Name = "edtErfassungLohnart";
            this.edtErfassungLohnart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungLohnart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungLohnart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungLohnart.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungLohnart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungLohnart.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungLohnart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErfassungLohnart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungLohnart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErfassungLohnart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErfassungLohnart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtErfassungLohnart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtErfassungLohnart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungLohnart.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtErfassungLohnart.Properties.DisplayMember = "Text";
            this.edtErfassungLohnart.Properties.NullText = "";
            this.edtErfassungLohnart.Properties.ShowFooter = false;
            this.edtErfassungLohnart.Properties.ShowHeader = false;
            this.edtErfassungLohnart.Properties.ValueMember = "Code";
            this.edtErfassungLohnart.Size = new System.Drawing.Size(190, 24);
            this.edtErfassungLohnart.TabIndex = 11;
            // 
            // lblErfassungLohnart
            // 
            this.lblErfassungLohnart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungLohnart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungLohnart.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungLohnart.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungLohnart.Location = new System.Drawing.Point(464, 455);
            this.lblErfassungLohnart.Name = "lblErfassungLohnart";
            this.lblErfassungLohnart.Size = new System.Drawing.Size(98, 24);
            this.lblErfassungLohnart.TabIndex = 10;
            this.lblErfassungLohnart.Text = "Lohnart";
            this.lblErfassungLohnart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungLohnart.UseCompatibleTextRendering = true;
            this.lblErfassungLohnart.Click += new System.EventHandler(this.Label_Click);
            // 
            // edtErfassungKostenstelle
            // 
            this.edtErfassungKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErfassungKostenstelle.DataMember = "KostenstelleOrgUnitID";
            this.edtErfassungKostenstelle.DataSource = this.qryData;
            this.edtErfassungKostenstelle.Location = new System.Drawing.Point(568, 425);
            this.edtErfassungKostenstelle.Name = "edtErfassungKostenstelle";
            this.edtErfassungKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungKostenstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErfassungKostenstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungKostenstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErfassungKostenstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErfassungKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtErfassungKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtErfassungKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtErfassungKostenstelle.Properties.DisplayMember = "Text";
            this.edtErfassungKostenstelle.Properties.NullText = "";
            this.edtErfassungKostenstelle.Properties.ShowFooter = false;
            this.edtErfassungKostenstelle.Properties.ShowHeader = false;
            this.edtErfassungKostenstelle.Properties.ValueMember = "Code";
            this.edtErfassungKostenstelle.Size = new System.Drawing.Size(190, 24);
            this.edtErfassungKostenstelle.TabIndex = 9;
            // 
            // lblErfassungKostenstelle
            // 
            this.lblErfassungKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungKostenstelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungKostenstelle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungKostenstelle.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungKostenstelle.Location = new System.Drawing.Point(464, 425);
            this.lblErfassungKostenstelle.Name = "lblErfassungKostenstelle";
            this.lblErfassungKostenstelle.Size = new System.Drawing.Size(98, 24);
            this.lblErfassungKostenstelle.TabIndex = 8;
            this.lblErfassungKostenstelle.Text = "Kostenstelle";
            this.lblErfassungKostenstelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungKostenstelle.UseCompatibleTextRendering = true;
            this.lblErfassungKostenstelle.Click += new System.EventHandler(this.Label_Click);
            // 
            // edtErfassungAnzahl
            // 
            this.edtErfassungAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErfassungAnzahl.DataMember = "Anzahl";
            this.edtErfassungAnzahl.DataSource = this.qryData;
            this.edtErfassungAnzahl.Location = new System.Drawing.Point(394, 455);
            this.edtErfassungAnzahl.Name = "edtErfassungAnzahl";
            this.edtErfassungAnzahl.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungAnzahl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungAnzahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungAnzahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungAnzahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungAnzahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungAnzahl.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungAnzahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassungAnzahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungAnzahl.Properties.DisplayFormat.FormatString = "D";
            this.edtErfassungAnzahl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtErfassungAnzahl.Properties.EditFormat.FormatString = "D";
            this.edtErfassungAnzahl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtErfassungAnzahl.Properties.Mask.EditMask = "D";
            this.edtErfassungAnzahl.Properties.MaxLength = 9;
            this.edtErfassungAnzahl.Properties.Precision = 0;
            this.edtErfassungAnzahl.Size = new System.Drawing.Size(52, 24);
            this.edtErfassungAnzahl.TabIndex = 7;
            // 
            // lblErfassungAnzahl
            // 
            this.lblErfassungAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungAnzahl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungAnzahl.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungAnzahl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungAnzahl.Location = new System.Drawing.Point(340, 455);
            this.lblErfassungAnzahl.Name = "lblErfassungAnzahl";
            this.lblErfassungAnzahl.Size = new System.Drawing.Size(48, 24);
            this.lblErfassungAnzahl.TabIndex = 6;
            this.lblErfassungAnzahl.Text = "Anzahl";
            this.lblErfassungAnzahl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungAnzahl.UseCompatibleTextRendering = true;
            this.lblErfassungAnzahl.Click += new System.EventHandler(this.Label_Click);
            // 
            // edtErfassungLeistungsart
            // 
            this.edtErfassungLeistungsart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErfassungLeistungsart.DataMember = "BDELeistungsart";
            this.edtErfassungLeistungsart.DataSource = this.qryData;
            this.edtErfassungLeistungsart.Location = new System.Drawing.Point(99, 455);
            this.edtErfassungLeistungsart.Name = "edtErfassungLeistungsart";
            this.edtErfassungLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtErfassungLeistungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtErfassungLeistungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungLeistungsart.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtErfassungLeistungsart.Size = new System.Drawing.Size(227, 24);
            this.edtErfassungLeistungsart.TabIndex = 5;
            this.edtErfassungLeistungsart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtErfassungLeistungsart_UserModifiedFld);
            this.edtErfassungLeistungsart.EditValueChanged += new System.EventHandler(this.edtErfassungLeistungsart_EditValueChanged);
            // 
            // lblErfassungLeistungsart
            // 
            this.lblErfassungLeistungsart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungLeistungsart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungLeistungsart.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungLeistungsart.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungLeistungsart.Location = new System.Drawing.Point(7, 455);
            this.lblErfassungLeistungsart.Name = "lblErfassungLeistungsart";
            this.lblErfassungLeistungsart.Size = new System.Drawing.Size(86, 24);
            this.lblErfassungLeistungsart.TabIndex = 4;
            this.lblErfassungLeistungsart.Text = "Leistungsart";
            this.lblErfassungLeistungsart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungLeistungsart.UseCompatibleTextRendering = true;
            this.lblErfassungLeistungsart.Click += new System.EventHandler(this.Label_Click);
            // 
            // edtErfassungKlient
            // 
            this.edtErfassungKlient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErfassungKlient.DataMember = "Klient";
            this.edtErfassungKlient.DataSource = this.qryData;
            this.edtErfassungKlient.Location = new System.Drawing.Point(99, 425);
            this.edtErfassungKlient.Name = "edtErfassungKlient";
            this.edtErfassungKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungKlient.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtErfassungKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtErfassungKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtErfassungKlient.Size = new System.Drawing.Size(347, 24);
            this.edtErfassungKlient.TabIndex = 3;
            this.edtErfassungKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtErfassungKlient_UserModifiedFld);
            this.edtErfassungKlient.EditValueChanged += new System.EventHandler(this.edtErfassungKlient_EditValueChanged);
            // 
            // lblErfassungKlient
            // 
            this.lblErfassungKlient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungKlient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungKlient.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungKlient.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungKlient.Location = new System.Drawing.Point(7, 425);
            this.lblErfassungKlient.Name = "lblErfassungKlient";
            this.lblErfassungKlient.Size = new System.Drawing.Size(86, 24);
            this.lblErfassungKlient.TabIndex = 2;
            this.lblErfassungKlient.Text = "Klient/in";
            this.lblErfassungKlient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungKlient.UseCompatibleTextRendering = true;
            this.lblErfassungKlient.Click += new System.EventHandler(this.Label_Click);
            // 
            // edtErfassungDatum
            // 
            this.edtErfassungDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErfassungDatum.DataMember = "Datum";
            this.edtErfassungDatum.DataSource = this.qryData;
            this.edtErfassungDatum.EditValue = null;
            this.edtErfassungDatum.Location = new System.Drawing.Point(99, 396);
            this.edtErfassungDatum.Name = "edtErfassungDatum";
            this.edtErfassungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtErfassungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErfassungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtErfassungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungDatum.Properties.ShowToday = false;
            this.edtErfassungDatum.Size = new System.Drawing.Size(103, 24);
            this.edtErfassungDatum.TabIndex = 1;
            // 
            // tabErfassung
            // 
            this.tabErfassung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabErfassung.Controls.Add(this.tpgErfassungSuche);
            this.tabErfassung.Controls.Add(this.tpgErfassungListe);
            this.tabErfassung.Location = new System.Drawing.Point(0, 0);
            this.tabErfassung.Name = "tabErfassung";
            this.tabErfassung.ShowFixedWidthTooltip = true;
            this.tabErfassung.Size = new System.Drawing.Size(948, 392);
            this.tabErfassung.TabIndex = 0;
            this.tabErfassung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgErfassungListe,
            this.tpgErfassungSuche});
            this.tabErfassung.TabsLineColor = System.Drawing.Color.Black;
            this.tabErfassung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabErfassung.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabErfassung_SelectedTabChanged);
            // 
            // tpgErfassungSuche
            // 
            this.tpgErfassungSuche.Controls.Add(this.chkSucheVerbucht);
            this.tpgErfassungSuche.Controls.Add(this.edtSucheBemerkung);
            this.tpgErfassungSuche.Controls.Add(this.lblSucheBemerkung);
            this.tpgErfassungSuche.Controls.Add(this.edtSucheLeistungsart);
            this.tpgErfassungSuche.Controls.Add(this.lblSucheLeistungsart);
            this.tpgErfassungSuche.Controls.Add(this.edtSucheKlient);
            this.tpgErfassungSuche.Controls.Add(this.lblSucheKlient);
            this.tpgErfassungSuche.Controls.Add(this.edtSucheDatumBis);
            this.tpgErfassungSuche.Controls.Add(this.lblSucheDatumBis);
            this.tpgErfassungSuche.Controls.Add(this.edtSucheDatumVon);
            this.tpgErfassungSuche.Controls.Add(this.lblSucheDatumVon);
            this.tpgErfassungSuche.Controls.Add(this.ttlSuche);
            this.tpgErfassungSuche.Location = new System.Drawing.Point(6, 6);
            this.tpgErfassungSuche.Name = "tpgErfassungSuche";
            this.tpgErfassungSuche.Size = new System.Drawing.Size(936, 354);
            this.tpgErfassungSuche.TabIndex = 1;
            this.tpgErfassungSuche.Title = "Suche";
            // 
            // chkSucheVerbucht
            // 
            this.chkSucheVerbucht.EditValue = "False";
            this.chkSucheVerbucht.Location = new System.Drawing.Point(99, 176);
            this.chkSucheVerbucht.Name = "chkSucheVerbucht";
            this.chkSucheVerbucht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheVerbucht.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheVerbucht.Properties.Caption = "inkl. verbuchte";
            this.chkSucheVerbucht.Size = new System.Drawing.Size(117, 19);
            this.chkSucheVerbucht.TabIndex = 11;
            // 
            // edtSucheBemerkung
            // 
            this.edtSucheBemerkung.Location = new System.Drawing.Point(101, 144);
            this.edtSucheBemerkung.Name = "edtSucheBemerkung";
            this.edtSucheBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkung.Size = new System.Drawing.Size(351, 24);
            this.edtSucheBemerkung.TabIndex = 10;
            // 
            // lblSucheBemerkung
            // 
            this.lblSucheBemerkung.Location = new System.Drawing.Point(8, 144);
            this.lblSucheBemerkung.Name = "lblSucheBemerkung";
            this.lblSucheBemerkung.Size = new System.Drawing.Size(80, 24);
            this.lblSucheBemerkung.TabIndex = 9;
            this.lblSucheBemerkung.Text = "Bemerkung";
            this.lblSucheBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtSucheLeistungsart
            // 
            this.edtSucheLeistungsart.Location = new System.Drawing.Point(101, 114);
            this.edtSucheLeistungsart.Name = "edtSucheLeistungsart";
            this.edtSucheLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheLeistungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheLeistungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLeistungsart.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheLeistungsart.Size = new System.Drawing.Size(351, 24);
            this.edtSucheLeistungsart.TabIndex = 8;
            this.edtSucheLeistungsart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheLeistungsart_UserModifiedFld);
            // 
            // lblSucheLeistungsart
            // 
            this.lblSucheLeistungsart.Location = new System.Drawing.Point(8, 114);
            this.lblSucheLeistungsart.Name = "lblSucheLeistungsart";
            this.lblSucheLeistungsart.Size = new System.Drawing.Size(80, 24);
            this.lblSucheLeistungsart.TabIndex = 7;
            this.lblSucheLeistungsart.Text = "Leistungsart";
            this.lblSucheLeistungsart.UseCompatibleTextRendering = true;
            // 
            // edtSucheKlient
            // 
            this.edtSucheKlient.Location = new System.Drawing.Point(101, 84);
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheKlient.Size = new System.Drawing.Size(351, 24);
            this.edtSucheKlient.TabIndex = 6;
            this.edtSucheKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheKlient_UserModifiedFld);
            // 
            // lblSucheKlient
            // 
            this.lblSucheKlient.Location = new System.Drawing.Point(8, 84);
            this.lblSucheKlient.Name = "lblSucheKlient";
            this.lblSucheKlient.Size = new System.Drawing.Size(90, 24);
            this.lblSucheKlient.TabIndex = 5;
            this.lblSucheKlient.Text = "Klient/in";
            this.lblSucheKlient.UseCompatibleTextRendering = true;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(229, 54);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(86, 24);
            this.edtSucheDatumBis.TabIndex = 4;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(200, 54);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(25, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(101, 54);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(86, 24);
            this.edtSucheDatumVon.TabIndex = 2;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(8, 54);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(80, 24);
            this.lblSucheDatumVon.TabIndex = 1;
            this.lblSucheDatumVon.Text = "Datum";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // ttlSuche
            // 
            this.ttlSuche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ttlSuche.Location = new System.Drawing.Point(8, 8);
            this.ttlSuche.Name = "ttlSuche";
            this.ttlSuche.Size = new System.Drawing.Size(200, 24);
            this.ttlSuche.TabIndex = 0;
            // 
            // tpgErfassungListe
            // 
            this.tpgErfassungListe.Controls.Add(this.grdBDELeistung);
            this.tpgErfassungListe.Location = new System.Drawing.Point(6, 6);
            this.tpgErfassungListe.Name = "tpgErfassungListe";
            this.tpgErfassungListe.Size = new System.Drawing.Size(936, 354);
            this.tpgErfassungListe.TabIndex = 0;
            this.tpgErfassungListe.Title = "Liste";
            // 
            // grdBDELeistung
            // 
            this.grdBDELeistung.DataSource = this.qryData;
            this.grdBDELeistung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBDELeistung.EmbeddedNavigator.Name = "";
            this.grdBDELeistung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDELeistung.Location = new System.Drawing.Point(0, 0);
            this.grdBDELeistung.MainView = this.grvBDELeistung;
            this.grdBDELeistung.Name = "grdBDELeistung";
            this.grdBDELeistung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repErfassungVisum});
            this.grdBDELeistung.Size = new System.Drawing.Size(936, 354);
            this.grdBDELeistung.TabIndex = 0;
            this.grdBDELeistung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDELeistung});
            // 
            // grvBDELeistung
            // 
            this.grvBDELeistung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDELeistung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.Empty.Options.UseFont = true;
            this.grvBDELeistung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDELeistung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDELeistung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDELeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDELeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDELeistung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDELeistung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDELeistung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDELeistung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDELeistung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDELeistung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDELeistung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBDELeistung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDELeistung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDELeistung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDELeistung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDELeistung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDELeistung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDELeistung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDELeistung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDELeistung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDELeistung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDELeistung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDELeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDELeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDELeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDELeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDELeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDELeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.OddRow.Options.UseFont = true;
            this.grvBDELeistung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDELeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.Row.Options.UseBackColor = true;
            this.grvBDELeistung.Appearance.Row.Options.UseFont = true;
            this.grvBDELeistung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDELeistung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDELeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDELeistung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDELeistung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErfassungTag,
            this.colErfassungDatum,
            this.colErfassungLeistungsart,
            this.colErfassungDauer,
            this.colErfassungKlient,
            this.colErfassungAnzahl,
            this.colErfassungKostenstelle,
            this.colLohnart,
            this.colErfassungBemerkungen,
            this.colErfassungFreigegeben,
            this.colErfassungVisiert,
            this.colErfassungVerbucht,
            this.colKeinExport});
            this.grvBDELeistung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDELeistung.GridControl = this.grdBDELeistung;
            this.grvBDELeistung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBDELeistung.Name = "grvBDELeistung";
            this.grvBDELeistung.OptionsBehavior.Editable = false;
            this.grvBDELeistung.OptionsCustomization.AllowFilter = false;
            this.grvBDELeistung.OptionsFilter.AllowFilterEditor = false;
            this.grvBDELeistung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDELeistung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDELeistung.OptionsNavigation.UseTabKey = false;
            this.grvBDELeistung.OptionsView.ColumnAutoWidth = false;
            this.grvBDELeistung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDELeistung.OptionsView.ShowGroupPanel = false;
            this.grvBDELeistung.OptionsView.ShowIndicator = false;
            this.grvBDELeistung.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvBDELeistung_CustomDrawCell);
            // 
            // colErfassungTag
            // 
            this.colErfassungTag.Caption = "Tag";
            this.colErfassungTag.FieldName = "WT";
            this.colErfassungTag.Name = "colErfassungTag";
            this.colErfassungTag.Visible = true;
            this.colErfassungTag.VisibleIndex = 0;
            this.colErfassungTag.Width = 50;
            // 
            // colErfassungDatum
            // 
            this.colErfassungDatum.Caption = "Datum";
            this.colErfassungDatum.FieldName = "Datum";
            this.colErfassungDatum.Name = "colErfassungDatum";
            this.colErfassungDatum.Visible = true;
            this.colErfassungDatum.VisibleIndex = 1;
            // 
            // colErfassungLeistungsart
            // 
            this.colErfassungLeistungsart.Caption = "Leistungsart";
            this.colErfassungLeistungsart.FieldName = "BDELeistungsart";
            this.colErfassungLeistungsart.Name = "colErfassungLeistungsart";
            this.colErfassungLeistungsart.Visible = true;
            this.colErfassungLeistungsart.VisibleIndex = 2;
            this.colErfassungLeistungsart.Width = 220;
            // 
            // colErfassungDauer
            // 
            this.colErfassungDauer.AppearanceCell.Options.UseTextOptions = true;
            this.colErfassungDauer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colErfassungDauer.Caption = "Dauer";
            this.colErfassungDauer.FieldName = "StdMin";
            this.colErfassungDauer.Name = "colErfassungDauer";
            this.colErfassungDauer.Visible = true;
            this.colErfassungDauer.VisibleIndex = 3;
            this.colErfassungDauer.Width = 60;
            // 
            // colErfassungKlient
            // 
            this.colErfassungKlient.Caption = "Klient/in";
            this.colErfassungKlient.FieldName = "Klient";
            this.colErfassungKlient.Name = "colErfassungKlient";
            this.colErfassungKlient.Visible = true;
            this.colErfassungKlient.VisibleIndex = 4;
            this.colErfassungKlient.Width = 160;
            // 
            // colErfassungAnzahl
            // 
            this.colErfassungAnzahl.Caption = "Anzahl";
            this.colErfassungAnzahl.FieldName = "Anzahl";
            this.colErfassungAnzahl.Name = "colErfassungAnzahl";
            this.colErfassungAnzahl.Visible = true;
            this.colErfassungAnzahl.VisibleIndex = 5;
            this.colErfassungAnzahl.Width = 50;
            // 
            // colErfassungKostenstelle
            // 
            this.colErfassungKostenstelle.Caption = "Kostenstelle";
            this.colErfassungKostenstelle.FieldName = "KostenstelleName";
            this.colErfassungKostenstelle.Name = "colErfassungKostenstelle";
            this.colErfassungKostenstelle.Visible = true;
            this.colErfassungKostenstelle.VisibleIndex = 6;
            this.colErfassungKostenstelle.Width = 130;
            // 
            // colLohnart
            // 
            this.colLohnart.Caption = "Lohnart";
            this.colLohnart.FieldName = "Lohnart";
            this.colLohnart.Name = "colLohnart";
            this.colLohnart.Visible = true;
            this.colLohnart.VisibleIndex = 7;
            this.colLohnart.Width = 130;
            // 
            // colErfassungBemerkungen
            // 
            this.colErfassungBemerkungen.Caption = "Bemerkungen";
            this.colErfassungBemerkungen.FieldName = "Bemerkung";
            this.colErfassungBemerkungen.Name = "colErfassungBemerkungen";
            this.colErfassungBemerkungen.Visible = true;
            this.colErfassungBemerkungen.VisibleIndex = 8;
            this.colErfassungBemerkungen.Width = 160;
            // 
            // colErfassungFreigegeben
            // 
            this.colErfassungFreigegeben.Caption = "Freig.";
            this.colErfassungFreigegeben.FieldName = "Freigegeben";
            this.colErfassungFreigegeben.Name = "colErfassungFreigegeben";
            this.colErfassungFreigegeben.Visible = true;
            this.colErfassungFreigegeben.VisibleIndex = 9;
            this.colErfassungFreigegeben.Width = 45;
            // 
            // colErfassungVisiert
            // 
            this.colErfassungVisiert.Caption = "Visiert";
            this.colErfassungVisiert.ColumnEdit = this.repErfassungVisum;
            this.colErfassungVisiert.FieldName = "Visiert";
            this.colErfassungVisiert.Name = "colErfassungVisiert";
            this.colErfassungVisiert.Visible = true;
            this.colErfassungVisiert.VisibleIndex = 10;
            this.colErfassungVisiert.Width = 48;
            // 
            // repErfassungVisum
            // 
            this.repErfassungVisum.AutoHeight = false;
            this.repErfassungVisum.Name = "repErfassungVisum";
            // 
            // colErfassungVerbucht
            // 
            this.colErfassungVerbucht.Caption = "Verbucht";
            this.colErfassungVerbucht.FieldName = "Verbucht";
            this.colErfassungVerbucht.Name = "colErfassungVerbucht";
            this.colErfassungVerbucht.Visible = true;
            this.colErfassungVerbucht.VisibleIndex = 11;
            this.colErfassungVerbucht.Width = 80;
            // 
            // colKeinExport
            // 
            this.colKeinExport.Caption = "Kein Export";
            this.colKeinExport.FieldName = "KeinExport";
            this.colKeinExport.Name = "colKeinExport";
            this.colKeinExport.Visible = true;
            this.colKeinExport.VisibleIndex = 12;
            // 
            // lblErfassungDatum
            // 
            this.lblErfassungDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungDatum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErfassungDatum.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblErfassungDatum.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassungDatum.Location = new System.Drawing.Point(7, 396);
            this.lblErfassungDatum.Name = "lblErfassungDatum";
            this.lblErfassungDatum.Size = new System.Drawing.Size(86, 24);
            this.lblErfassungDatum.TabIndex = 0;
            this.lblErfassungDatum.Text = "Datum";
            this.lblErfassungDatum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErfassungDatum.UseCompatibleTextRendering = true;
            this.lblErfassungDatum.Click += new System.EventHandler(this.Label_Click);
            // 
            // btnZeitrechner
            // 
            this.btnZeitrechner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZeitrechner.BackColor = System.Drawing.Color.Bisque;
            this.btnZeitrechner.ButtonStyle = KiSS4.Gui.ButtonStyleType.Custom;
            this.btnZeitrechner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btnZeitrechner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btnZeitrechner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeitrechner.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnZeitrechner.ForeColor = System.Drawing.Color.Black;
            this.btnZeitrechner.Location = new System.Drawing.Point(881, 566);
            this.btnZeitrechner.Name = "btnZeitrechner";
            this.btnZeitrechner.Size = new System.Drawing.Size(89, 24);
            this.btnZeitrechner.TabIndex = 8;
            this.btnZeitrechner.TabStop = false;
            this.btnZeitrechner.Text = "&Zeitrechner";
            this.btnZeitrechner.UseCompatibleTextRendering = true;
            this.btnZeitrechner.UseVisualStyleBackColor = false;
            this.btnZeitrechner.Click += new System.EventHandler(this.btnZeitrechner_Click);
            // 
            // qryUebersicht
            // 
            this.qryUebersicht.HostControl = this;
            this.qryUebersicht.IsIdentityInsert = false;
            // 
            // qryLohnArt
            // 
            this.qryLohnArt.HostControl = this;
            this.qryLohnArt.IsIdentityInsert = false;
            this.qryLohnArt.SelectStatement = "SELECT Code,\r\n       Text\r\nFROM dbo.fnBDEGetLohnartDropDown({0}, {1});";
            // 
            // btnStundenimport
            // 
            this.btnStundenimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStundenimport.Location = new System.Drawing.Point(647, 10);
            this.btnStundenimport.Name = "btnStundenimport";
            this.btnStundenimport.Size = new System.Drawing.Size(125, 24);
            this.btnStundenimport.TabIndex = 9;
            this.btnStundenimport.Text = "Stunden-Import";
            this.btnStundenimport.UseVisualStyleBackColor = false;
            this.btnStundenimport.Click += new System.EventHandler(this.btnStundenimport_Click);
            // 
            // ofdExcelImport
            // 
            this.ofdExcelImport.Filter = "Excel files|*.xlsx|All files|*.*";
            // 
            // CtlBDEZeiterfassung
            // 
            this.ActiveSQLQuery = this.qryData;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(850, 520);
            this.Controls.Add(this.btnStundenimport);
            this.Controls.Add(this.btnZeitrechner);
            this.Controls.Add(this.tabZeiterfassung);
            this.Controls.Add(this.panZeitrechner);
            this.Controls.Add(this.lblTagessoll);
            this.Controls.Add(this.lblTagessollC);
            this.Controls.Add(this.btnAngezeigterMAFilter);
            this.Controls.Add(this.edtAngezeigterMAFilter);
            this.Controls.Add(this.lblAngezeigterMAFilter);
            this.Controls.Add(this.edtAngezeigterMitarbeiter);
            this.Controls.Add(this.lblAngezeigterMitarbeiter);
            this.Name = "CtlBDEZeiterfassung";
            this.Size = new System.Drawing.Size(982, 601);
            this.Text = "Zeiterfassung";
            this.Load += new System.EventHandler(this.CtlBDEZeiterfassung_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CtlBDEZeiterfassung_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lblAngezeigterMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngezeigterMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngezeigterMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngezeigterMAFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngezeigterMAFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagessollC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagessoll)).EndInit();
            this.panZeitrechner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZeitrechner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZeitrechner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZeitrechner)).EndInit();
            this.pnlZeitrechnerBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitrechnerZeitBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitrechnerZeitBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitrechnerZeitVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitrechnerZeitVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitrechnerDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitrechnerDatum)).EndInit();
            this.tabZeiterfassung.ResumeLayout(false);
            this.tpgUebersicht.ResumeLayout(false);
            this.grpUebersichtFerien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienKorrekturen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienKorrekturenLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienZugabenKuerzungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienZugabenKuerzungenLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienBezogen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienBezogenLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienAnspruch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienAnspruchLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienUebertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienUebertragLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFerienSaldoLbl)).EndInit();
            this.grpUebersichtStundenlohn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtStundenlohnIstArbeitszeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtStundenlohnIstArbeitszeitLbl)).EndInit();
            this.grpUebersichtGleitzeit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldoLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitBezUeberstunden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitBezUeberstundenLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitKorrekturen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitKorrekturenLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldoUebertragMonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSaldoUebertragMonateLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitUebertragJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitUebertragJahrLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitMonatSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitMonatSaldoLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSollMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitSollMonatLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitIstArbeitszeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtGleitzeitIstArbeitszeitLbl)).EndInit();
            this.grpUebersichtAllgemein.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtSollProTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtSollProTagLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBeschaeftigungsgrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBeschaeftigungsgradLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUebersichtMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuellerMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuellerMonatC)).EndInit();
            this.tpgWoche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWoche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWoche)).EndInit();
            this.tpgMonat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMonat)).EndInit();
            this.tpgErfassung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFakturiert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostentraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostentraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungKostentraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeinExport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKeinExport)).EndInit();
            this.panErfassungZeitInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDifferenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDifferenzC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungTagesIst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungTagesIstC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungZeitrechnerTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungZeitrechnerTotalC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErfassungBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungMinuten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungStunden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungLohnart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungLohnart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungLohnart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungAnzahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungAnzahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungDatum.Properties)).EndInit();
            this.tabErfassung.ResumeLayout(false);
            this.tpgErfassungSuche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheVerbucht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            this.tpgErfassungListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBDELeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDELeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repErfassungVisum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUebersicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLohnArt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAngezeigterMAFilter;
        private KiSS4.Gui.KissButton btnErfassungKopie;
        private KiSS4.Gui.KissButton btnErfassungTag05;
        private KiSS4.Gui.KissButton btnErfassungTag1;
        private KiSS4.Gui.KissButton btnMonatFreigabeAufheben;
        private KiSS4.Gui.KissButton btnMonatFreigeben;
        private KiSS4.Gui.KissButton btnMonatVisieren;
        private KiSS4.Gui.KissButton btnMonatVisumAufheben;
        private KiSS4.Gui.KissButton btnUebersichtHeute;
        private KiSS4.Gui.KissButton btnUebersichtNachmonat;
        private KiSS4.Gui.KissButton btnUebersichtVormonat;
        private KiSS4.Gui.KissButton btnWocheAufklappen;
        private KiSS4.Gui.KissButton btnWocheZuklappen;
        private KiSS4.Gui.KissButton btnZeitrechner;
        private KiSS4.Gui.KissCheckEdit chkSucheVerbucht;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungDauer;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungFreigegeben;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungLeistungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungTag;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungVerbucht;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungVisiert;
        private DevExpress.XtraGrid.Columns.GridColumn colLohnart;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatBeschaeftigungsgrad;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFerienAnspruchProJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFerienBezogenMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFerienBisherBezogen;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFerienKorrekturen;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFerienSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFerienUebertragVorjahr;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFerienZugabenKuerzungen;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFreigegeben;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatGZBezUeberstunden;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatGZIstArbeitszeit;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatGZKorrekturen;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatGZMonatssaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatGZSollArbeitszeit;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatGZUebertragVorjahr;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatSLIstArbeitszeit;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatSpacer1;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatSpacer2;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatSpacer3;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatVerbucht;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatVerbuchtLD;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatVisiert;
        private DevExpress.XtraGrid.Columns.GridColumn colPraesenzDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPraesenzZeitBis;
        private DevExpress.XtraGrid.Columns.GridColumn colPraesenzZeitVon;
        private DevExpress.XtraGrid.Columns.GridColumn colWocheDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colWocheDifferenz;
        private DevExpress.XtraGrid.Columns.GridColumn colWocheTag;
        private DevExpress.XtraGrid.Columns.GridColumn colWocheTagesIst;
        private DevExpress.XtraGrid.Columns.GridColumn colWocheWoche;
        private DevExpress.XtraGrid.Columns.GridColumn colWocheZeitrechnertotal;
        private DevExpress.XtraGrid.Columns.GridColumn collMonatGZSaldo;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Dokument.KissDocumentButton docUebersicht;
        private KiSS4.Gui.KissTextEdit edtAngezeigterMAFilter;
        private KiSS4.Gui.KissLookUpEdit edtAngezeigterMitarbeiter;
        private KiSS4.Gui.KissCalcEdit edtErfassungAnzahl;
        private KiSS4.Gui.KissDateEdit edtErfassungDatum;
        private KiSS4.Gui.KissButtonEdit edtErfassungKlient;
        private KiSS4.Gui.KissLookUpEdit edtErfassungKostenstelle;
        private KiSS4.Gui.KissButtonEdit edtErfassungLeistungsart;
        private KiSS4.Gui.KissLookUpEdit edtErfassungLohnart;
        private KiSS4.Gui.KissCalcEdit edtErfassungMinuten;
        private KiSS4.Gui.KissCalcEdit edtErfassungStunden;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkung;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissButtonEdit edtSucheKlient;
        private KiSS4.Gui.KissButtonEdit edtSucheLeistungsart;
        private KiSS4.Gui.KissDateEdit edtUebersichtMonat;
        private KiSS4.Gui.KissDateEdit edtZeitrechnerDatum;
        private KiSS4.Gui.KissTimeEdit edtZeitrechnerZeitBis;
        private KiSS4.Gui.KissTimeEdit edtZeitrechnerZeitVon;
        private KiSS4.Gui.KissGrid grdBDELeistung;
        private KiSS4.Gui.KissGrid grdMonat;
        private KiSS4.Gui.KissGrid grdWoche;
        private KiSS4.Gui.KissGrid grdZeitrechner;
        private KiSS4.Gui.KissGroupBox grpUebersichtAllgemein;
        private KiSS4.Gui.KissGroupBox grpUebersichtFerien;
        private KiSS4.Gui.KissGroupBox grpUebersichtGleitzeit;
        private KiSS4.Gui.KissGroupBox grpUebersichtStundenlohn;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDELeistung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMonat;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWoche;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZeitrechner;
        private KiSS4.Gui.KissLabel lblAktuellerMonat;
        private KiSS4.Gui.KissLabel lblAktuellerMonatC;
        private KiSS4.Gui.KissLabel lblAngezeigterMAFilter;
        private KiSS4.Gui.KissLabel lblAngezeigterMitarbeiter;
        private KiSS4.Gui.KissLabel lblErfassungAnzahl;
        private KiSS4.Gui.KissLabel lblErfassungBemerkungen;
        private KiSS4.Gui.KissLabel lblErfassungDatum;
        private KiSS4.Gui.KissLabel lblErfassungDauer;
        private KiSS4.Gui.KissLabel lblErfassungDifferenz;
        private KiSS4.Gui.KissLabel lblErfassungDifferenzC;
        private KiSS4.Gui.KissLabel lblErfassungKlient;
        private KiSS4.Gui.KissLabel lblErfassungKostenstelle;
        private KiSS4.Gui.KissLabel lblErfassungLeistungsart;
        private KiSS4.Gui.KissLabel lblErfassungLohnart;
        private KiSS4.Gui.KissLabel lblErfassungMin;
        private KiSS4.Gui.KissLabel lblErfassungStd;
        private KiSS4.Gui.KissLabel lblErfassungTagesIst;
        private KiSS4.Gui.KissLabel lblErfassungTagesIstC;
        private KiSS4.Gui.KissLabel lblErfassungZeitrechnerTotal;
        private KiSS4.Gui.KissLabel lblErfassungZeitrechnerTotalC;
        private KiSS4.Gui.KissLabel lblSucheBemerkung;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheKlient;
        private KiSS4.Gui.KissLabel lblSucheLeistungsart;
        private KiSS4.Gui.KissLabel lblTagessoll;
        private KiSS4.Gui.KissLabel lblTagessollC;
        private KiSS4.Gui.KissLabel lblUebersichtBeschaeftigungsgrad;
        private KiSS4.Gui.KissLabel lblUebersichtBeschaeftigungsgradLbl;
        private KiSS4.Gui.KissLabel lblUebersichtFerienAnspruch;
        private KiSS4.Gui.KissLabel lblUebersichtFerienAnspruchLbl;
        private KiSS4.Gui.KissLabel lblUebersichtFerienBezogen;
        private KiSS4.Gui.KissLabel lblUebersichtFerienBezogenLbl;
        private KiSS4.Gui.KissLabel lblUebersichtFerienKorrekturen;
        private KiSS4.Gui.KissLabel lblUebersichtFerienKorrekturenLbl;
        private KiSS4.Gui.KissLabel lblUebersichtFerienSaldo;
        private KiSS4.Gui.KissLabel lblUebersichtFerienSaldoLbl;
        private KiSS4.Gui.KissLabel lblUebersichtFerienUebertrag;
        private KiSS4.Gui.KissLabel lblUebersichtFerienUebertragLbl;
        private KiSS4.Gui.KissLabel lblUebersichtFerienZugabenKuerzungen;
        private KiSS4.Gui.KissLabel lblUebersichtFerienZugabenKuerzungenLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitBezUeberstunden;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitBezUeberstundenLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitIstArbeitszeit;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitIstArbeitszeitLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitKorrekturen;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitKorrekturenLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitMonatSaldo;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitMonatSaldoLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitSaldo;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitSaldoLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitSaldoUebertragMonate;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitSaldoUebertragMonateLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitSollMonat;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitSollMonatLbl;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitUebertragJahr;
        private KiSS4.Gui.KissLabel lblUebersichtGleitzeitUebertragJahrLbl;
        private KiSS4.Gui.KissLabel lblUebersichtSollProTag;
        private KiSS4.Gui.KissLabel lblUebersichtSollProTagLbl;
        private KiSS4.Gui.KissLabel lblUebersichtStundenlohnIstArbeitszeit;
        private KiSS4.Gui.KissLabel lblUebersichtStundenlohnIstArbeitszeitLbl;
        private KiSS4.Gui.KissLabel lblZeitrechnerDatum;
        private KiSS4.Gui.KissLabel lblZeitrechnerZeitBis;
        private KiSS4.Gui.KissLabel lblZeitrechnerZeitVon;
        private KiSS4.Gui.KissMemoEdit memErfassungBemerkungen;
        private System.Windows.Forms.Panel panErfassungLineDifferenz;
        private System.Windows.Forms.Panel panErfassungZeitInfo;
        private System.Windows.Forms.Panel panUebersichtFerienLinie;
        private System.Windows.Forms.Panel panUebersichtGleitzeitLinie;
        private System.Windows.Forms.Panel panZeitrechner;
        private System.Windows.Forms.Panel pnlZeitrechnerBottom;
        private KiSS4.DB.SqlQuery qryData;
        private KiSS4.DB.SqlQuery qryMonat;
        private KiSS4.DB.SqlQuery qryUebersicht;
        private KiSS4.DB.SqlQuery qryZeitrechner;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repErfassungVisum;
        private KiSS4.Gui.KissTabControlEx tabErfassung;
        private KiSS4.Gui.KissTabControlEx tabZeiterfassung;
        private SharpLibrary.WinControls.TabPageEx tpgErfassung;
        private SharpLibrary.WinControls.TabPageEx tpgErfassungListe;
        private SharpLibrary.WinControls.TabPageEx tpgErfassungSuche;
        private SharpLibrary.WinControls.TabPageEx tpgMonat;
        private SharpLibrary.WinControls.TabPageEx tpgUebersicht;
        private SharpLibrary.WinControls.TabPageEx tpgWoche;
        private DevExpress.XtraGrid.Columns.GridColumn colKeinExport;
        private KiSS4.Gui.KissCheckEdit edtKeinExport;
        private KiSS4.Gui.KissLabel lblKeinExport;
        private KiSS4.Gui.KissSearchTitel ttlSuche;
        private DB.SqlQuery qryLohnArt;
        private Gui.KissButton btnKeinExportUmschalten;
        private Gui.KissButton btnStundenimport;
        private System.Windows.Forms.OpenFileDialog ofdExcelImport;
        private Gui.KissLookUpEdit edtErfassungKostentraeger;
        private Gui.KissLabel lblErfassungKostentraeger;
        private Gui.KissButton btnMonatFakturiertEntfernen;
        private Gui.KissButton btnMonatFakturiertSetzen;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatFakturiert;
        private Gui.KissCheckEdit edtFakturiert;
    }
}
