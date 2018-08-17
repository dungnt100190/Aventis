namespace KiSS4.Arbeit
{
    partial class CtlKaBetriebe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaBetriebe));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdKaBetrieb = new KiSS4.Gui.KissGrid();
            this.qryKaBetrieb = new KiSS4.DB.SqlQuery(this.components);
            this.grvKaBetrieb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBetriebAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseHausNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCharakter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheOrt = new KiSS4.Gui.KissLabel();
            this.edtSucheOrt = new KiSS4.Gui.KissTextEdit();
            this.lblSucheTeilbetriebVon = new KiSS4.Gui.KissLabel();
            this.edtSucheUnterbetriebVon = new KiSS4.Gui.KissTextEdit();
            this.lblSucheKontaktperson = new KiSS4.Gui.KissLabel();
            this.edtSucheKontaktName = new KiSS4.Gui.KissTextEdit();
            this.chkInaktiveAnzeigen = new KiSS4.Gui.KissCheckEdit();
            this.tabBetrieb = new KiSS4.Gui.KissTabControlEx();
            this.tpgEinsatzplaetze = new SharpLibrary.WinControls.TabPageEx();
            this.btnJumpToEP = new KiSS4.Gui.KissButton();
            this.grdEinsatzplaetze = new KiSS4.Gui.KissGrid();
            this.qryKaEinsatzplatz = new KiSS4.DB.SqlQuery(this.components);
            this.grvEinsatzplaetze = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEinsatzAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzProgramm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.edtBetriebDokumentXDokument = new KiSS4.Dokument.XDokument();
            this.qryKaBetriebDokument = new KiSS4.DB.SqlQuery(this.components);
            this.lblBetriebDokumentDok = new KiSS4.Gui.KissLabel();
            this.edtBetriebDokumentStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblBetriebDokumentStichwort = new KiSS4.Gui.KissLabel();
            this.edtBetriebDokumentAdressat = new KiSS4.Gui.KissButtonEdit();
            this.lblBetriebDokumentAdressat = new KiSS4.Gui.KissLabel();
            this.edtBetriebDokumentAbsender = new KiSS4.Gui.KissButtonEdit();
            this.lblBetriebDokumentAbsender = new KiSS4.Gui.KissLabel();
            this.edtBetriebDokumentDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBetriebDokumentDatum = new KiSS4.Gui.KissLabel();
            this.grdBetriebDokumente = new KiSS4.Gui.KissGrid();
            this.grvBetriebDokument = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDokDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokAdressat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgVerlauf = new SharpLibrary.WinControls.TabPageEx();
            this.edtBesprechungAutor = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.qryKaBetriebVerlauf = new KiSS4.DB.SqlQuery(this.components);
            this.DocKaBetriebVerlauf = new KiSS4.Dokument.KissDocumentButton();
            this.edtBesprechungInhalt = new KiSS4.Gui.KissRTFEdit();
            this.lblInhalt = new KiSS4.Gui.KissLabel();
            this.edtKontaktGeplant = new KiSS4.Gui.KissDateEdit();
            this.lblKontaktGeplant = new KiSS4.Gui.KissLabel();
            this.lblAutor = new KiSS4.Gui.KissLabel();
            this.edtBesprechungStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblStichworte = new KiSS4.Gui.KissLabel();
            this.edtKontaktart = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktart = new KiSS4.Gui.KissLabel();
            this.edtKontaktperson = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktpartner = new KiSS4.Gui.KissLabel();
            this.edtBesprechungDatum = new KiSS4.Gui.KissDateEdit();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.grdBetriebVerlauf = new KiSS4.Gui.KissGrid();
            this.grvBetriebVerlauf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerlKontaktperson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktGeplant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgKontakt = new SharpLibrary.WinControls.TabPageEx();
            this.edtUseZusatzadresse = new KiSS4.Gui.KissRadioGroup(this.components);
            this.qryKaBetriebKontakt = new KiSS4.DB.SqlQuery(this.components);
            this.lblKorrespondenz = new KiSS4.Gui.KissLabel();
            this.lblKontaktLand = new KiSS4.Gui.KissLabel();
            this.lblKontaktPLZOrtKt = new KiSS4.Gui.KissLabel();
            this.lblKontaktPostfach = new KiSS4.Gui.KissLabel();
            this.lblKontaktStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtKontaktPLZOrtLand = new KiSS4.Common.KissPLZOrt();
            this.qryZusatzadresse = new KiSS4.DB.SqlQuery(this.components);
            this.edtKontaktPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktStrasse = new KiSS4.Gui.KissTextEdit();
            this.grdProgKontakt = new KiSS4.Gui.KissGrid();
            this.qryProgKontakt = new KiSS4.DB.SqlQuery(this.components);
            this.grvProgKontakt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProgKontakt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtKontaktEMail = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktEmail = new KiSS4.Gui.KissLabel();
            this.edtKontaktFax = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktFax = new KiSS4.Gui.KissLabel();
            this.edtKontaktTelefonMobil = new KiSS4.Gui.KissTextEdit();
            this.lblKontakTelefontMobil = new KiSS4.Gui.KissLabel();
            this.edtKontaktTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktTelefon = new KiSS4.Gui.KissLabel();
            this.edtKontaktBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblKontaktBemerkung = new KiSS4.Gui.KissLabel();
            this.edtKontaktGeschlechtCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtKontaktFunktion = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktFunktion = new KiSS4.Gui.KissLabel();
            this.edtKontaktVorname = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktName = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktlNameVorname = new KiSS4.Gui.KissLabel();
            this.chkKontakAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtKontaktAnrede = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktAnrede = new KiSS4.Gui.KissLabel();
            this.grdBetriebKontakt = new KiSS4.Gui.KissGrid();
            this.grvBetriebKontakt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktperson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgUebersicht = new SharpLibrary.WinControls.TabPageEx();
            this.grdLehrberufe = new KiSS4.Gui.KissGrid();
            this.qryKaLehrberuf = new KiSS4.DB.SqlQuery(this.components);
            this.grvKaLehrberufe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLehrberuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBranche = new KiSS4.Gui.KissGrid();
            this.qryKaBranche = new KiSS4.DB.SqlQuery(this.components);
            this.grvBranche = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBranche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKaProgramm = new KiSS4.Gui.KissGrid();
            this.qryKaProgramm = new KiSS4.DB.SqlQuery(this.components);
            this.grvKaProgramm = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProgramm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtUeberPLZOrt = new KiSS4.Gui.KissTextEdit();
            this.grdTeilbetriebe = new KiSS4.Gui.KissGrid();
            this.qryTeilbetriebe = new KiSS4.DB.SqlQuery(this.components);
            this.grvTeilbetriebe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTeilbetriebName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtUeberCharakter = new KiSS4.Gui.KissTextEdit();
            this.edtUeberTeilbetriebVon = new KiSS4.Gui.KissTextEdit();
            this.edtUeberHomepage = new KiSS4.Gui.KissTextEdit();
            this.edtUeberEmail = new KiSS4.Gui.KissTextEdit();
            this.edtUeberFax = new KiSS4.Gui.KissTextEdit();
            this.edtUeberTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtUeberHausNr = new KiSS4.Gui.KissTextEdit();
            this.qryBaAdresse = new KiSS4.DB.SqlQuery(this.components);
            this.edtUeberStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtUeberName = new KiSS4.Gui.KissTextEdit();
            this.lblUebersichtTeilbetriebe = new KiSS4.Gui.KissLabel();
            this.lblUebersichtTeilbetriebVon = new KiSS4.Gui.KissLabel();
            this.lblUebersichtInternet = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.lblUebersichtEmail = new KiSS4.Gui.KissLabel();
            this.lblUebersichtFax = new KiSS4.Gui.KissLabel();
            this.lblUebersichtTelefon = new KiSS4.Gui.KissLabel();
            this.lblUebersichtPLZOrt = new KiSS4.Gui.KissLabel();
            this.lblUebersichtAdresse = new KiSS4.Gui.KissLabel();
            this.lblUebersichtCharakter = new KiSS4.Gui.KissLabel();
            this.lblUebersichtName = new KiSS4.Gui.KissLabel();
            this.tpgGrunddaten = new SharpLibrary.WinControls.TabPageEx();
            this.DocBetriebGrunddaten = new KiSS4.Dokument.KissDocumentButton();
            this.chkInAusbildungsverbund = new KiSS4.Gui.KissCheckEdit();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            this.lblCharakter = new KiSS4.Gui.KissLabel();
            this.lblInternet = new KiSS4.Gui.KissLabel();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTeilbetriebVon = new KiSS4.Gui.KissLabel();
            this.lblLand = new KiSS4.Gui.KissLabel();
            this.lblPLZOrtKt = new KiSS4.Gui.KissLabel();
            this.lblPostfach = new KiSS4.Gui.KissLabel();
            this.lblStrasseNr = new KiSS4.Gui.KissLabel();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.edtCharakterCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtHomepage = new KiSS4.Gui.KissTextEdit();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtUnterbetriebVon = new KiSS4.Gui.KissButtonEdit();
            this.edtPLZOrtLand = new KiSS4.Common.KissPLZOrt();
            this.edtPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtAdressZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.qryKontaktperson = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKaBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKaBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeilbetriebVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUnterbetriebVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontaktName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInaktiveAnzeigen.Properties)).BeginInit();
            this.tabBetrieb.SuspendLayout();
            this.tpgEinsatzplaetze.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsatzplaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsatzplaetze)).BeginInit();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentXDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetriebDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentDok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetriebDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetriebDokument)).BeginInit();
            this.tpgVerlauf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesprechungAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetriebVerlauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeplant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeplant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesprechungStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesprechungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetriebVerlauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetriebVerlauf)).BeginInit();
            this.tpgKontakt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUseZusatzadresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUseZusatzadresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetriebKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrespondenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZusatzadresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProgKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProgKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefonMobil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontakTelefontMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlechtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlechtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFunktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFunktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktlNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontakAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetriebKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetriebKontakt)).BeginInit();
            this.tpgUebersicht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLehrberufe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKaLehrberufe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberPLZOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTeilbetriebe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTeilbetriebe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTeilbetriebe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberCharakter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberTeilbetriebVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberHomepage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtTeilbetriebe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtTeilbetriebVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtInternet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtCharakter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtName)).BeginInit();
            this.tpgGrunddaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInAusbildungsverbund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCharakter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInternet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilbetriebVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCharakterCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCharakterCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomepage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterbetriebVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontaktperson)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(763, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Size = new System.Drawing.Size(787, 276);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKaBetrieb);
            this.tpgListe.Size = new System.Drawing.Size(775, 238);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.chkInaktiveAnzeigen);
            this.tpgSuchen.Controls.Add(this.edtSucheKontaktName);
            this.tpgSuchen.Controls.Add(this.lblSucheKontaktperson);
            this.tpgSuchen.Controls.Add(this.edtSucheUnterbetriebVon);
            this.tpgSuchen.Controls.Add(this.lblSucheTeilbetriebVon);
            this.tpgSuchen.Controls.Add(this.edtSucheOrt);
            this.tpgSuchen.Controls.Add(this.lblSucheOrt);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(775, 238);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTeilbetriebVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheUnterbetriebVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKontaktperson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKontaktName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkInaktiveAnzeigen, 0);
            // 
            // grdKaBetrieb
            // 
            this.grdKaBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdKaBetrieb.DataSource = this.qryKaBetrieb;
            // 
            // 
            // 
            this.grdKaBetrieb.EmbeddedNavigator.Name = "";
            this.grdKaBetrieb.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKaBetrieb.Location = new System.Drawing.Point(0, 20);
            this.grdKaBetrieb.MainView = this.grvKaBetrieb;
            this.grdKaBetrieb.Name = "grdKaBetrieb";
            this.grdKaBetrieb.Size = new System.Drawing.Size(775, 198);
            this.grdKaBetrieb.TabIndex = 1;
            this.grdKaBetrieb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKaBetrieb});
            // 
            // qryKaBetrieb
            // 
            this.qryKaBetrieb.CanDelete = true;
            this.qryKaBetrieb.CanInsert = true;
            this.qryKaBetrieb.CanUpdate = true;
            this.qryKaBetrieb.HostControl = this;
            this.qryKaBetrieb.SelectStatement = resources.GetString("qryKaBetrieb.SelectStatement");
            this.qryKaBetrieb.TableName = "KaBetrieb";
            this.qryKaBetrieb.AfterFill += new System.EventHandler(this.qryKaBetrieb_AfterFill);
            this.qryKaBetrieb.BeforeInsert += new System.EventHandler(this.qryKaBetrieb_BeforeInsert);
            this.qryKaBetrieb.BeforePost += new System.EventHandler(this.qryKaBetrieb_BeforePost);
            this.qryKaBetrieb.AfterPost += new System.EventHandler(this.qryKaBetrieb_AfterPost);
            this.qryKaBetrieb.BeforeDelete += new System.EventHandler(this.qryKaBetrieb_BeforeDelete);
            this.qryKaBetrieb.PositionChanged += new System.EventHandler(this.qryKaBetrieb_PositionChanged);
            // 
            // grvKaBetrieb
            // 
            this.grvKaBetrieb.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKaBetrieb.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.Empty.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.Empty.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.EvenRow.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKaBetrieb.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKaBetrieb.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKaBetrieb.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKaBetrieb.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKaBetrieb.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKaBetrieb.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKaBetrieb.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKaBetrieb.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKaBetrieb.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKaBetrieb.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.GroupRow.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKaBetrieb.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKaBetrieb.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKaBetrieb.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKaBetrieb.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKaBetrieb.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKaBetrieb.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKaBetrieb.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKaBetrieb.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKaBetrieb.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.OddRow.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKaBetrieb.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.Row.Options.UseBackColor = true;
            this.grvKaBetrieb.Appearance.Row.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaBetrieb.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKaBetrieb.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKaBetrieb.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKaBetrieb.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKaBetrieb.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBetriebAktiv,
            this.colName,
            this.colStrasseHausNr,
            this.colPLZOrt,
            this.colCharakter});
            this.grvKaBetrieb.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKaBetrieb.GridControl = this.grdKaBetrieb;
            this.grvKaBetrieb.Name = "grvKaBetrieb";
            this.grvKaBetrieb.OptionsBehavior.Editable = false;
            this.grvKaBetrieb.OptionsCustomization.AllowFilter = false;
            this.grvKaBetrieb.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKaBetrieb.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKaBetrieb.OptionsNavigation.UseTabKey = false;
            this.grvKaBetrieb.OptionsView.ColumnAutoWidth = false;
            this.grvKaBetrieb.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKaBetrieb.OptionsView.ShowGroupPanel = false;
            this.grvKaBetrieb.OptionsView.ShowIndicator = false;
            // 
            // colBetriebAktiv
            // 
            this.colBetriebAktiv.Caption = "Aktiv";
            this.colBetriebAktiv.FieldName = "Aktiv";
            this.colBetriebAktiv.Name = "colBetriebAktiv";
            this.colBetriebAktiv.Visible = true;
            this.colBetriebAktiv.VisibleIndex = 0;
            this.colBetriebAktiv.Width = 41;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "BetriebName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 205;
            // 
            // colStrasseHausNr
            // 
            this.colStrasseHausNr.Caption = "Strasse";
            this.colStrasseHausNr.FieldName = "StrasseNr";
            this.colStrasseHausNr.Name = "colStrasseHausNr";
            this.colStrasseHausNr.Visible = true;
            this.colStrasseHausNr.VisibleIndex = 2;
            this.colStrasseHausNr.Width = 190;
            // 
            // colPLZOrt
            // 
            this.colPLZOrt.Caption = "Ort";
            this.colPLZOrt.FieldName = "PLZOrt";
            this.colPLZOrt.Name = "colPLZOrt";
            this.colPLZOrt.Visible = true;
            this.colPLZOrt.VisibleIndex = 3;
            this.colPLZOrt.Width = 184;
            // 
            // colCharakter
            // 
            this.colCharakter.Caption = "Charakter";
            this.colCharakter.FieldName = "CharakterCode";
            this.colCharakter.Name = "colCharakter";
            this.colCharakter.Visible = true;
            this.colCharakter.VisibleIndex = 4;
            this.colCharakter.Width = 184;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(8, 38);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(82, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(105, 38);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(270, 24);
            this.edtSucheName.TabIndex = 2;
            // 
            // lblSucheOrt
            // 
            this.lblSucheOrt.Location = new System.Drawing.Point(8, 69);
            this.lblSucheOrt.Name = "lblSucheOrt";
            this.lblSucheOrt.Size = new System.Drawing.Size(82, 24);
            this.lblSucheOrt.TabIndex = 3;
            this.lblSucheOrt.Text = "Ort";
            this.lblSucheOrt.UseCompatibleTextRendering = true;
            // 
            // edtSucheOrt
            // 
            this.edtSucheOrt.Location = new System.Drawing.Point(105, 69);
            this.edtSucheOrt.Name = "edtSucheOrt";
            this.edtSucheOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheOrt.Size = new System.Drawing.Size(270, 24);
            this.edtSucheOrt.TabIndex = 4;
            // 
            // lblSucheTeilbetriebVon
            // 
            this.lblSucheTeilbetriebVon.Location = new System.Drawing.Point(8, 99);
            this.lblSucheTeilbetriebVon.Name = "lblSucheTeilbetriebVon";
            this.lblSucheTeilbetriebVon.Size = new System.Drawing.Size(83, 24);
            this.lblSucheTeilbetriebVon.TabIndex = 5;
            this.lblSucheTeilbetriebVon.Text = "Teilbetrieb von";
            this.lblSucheTeilbetriebVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheUnterbetriebVon
            // 
            this.edtSucheUnterbetriebVon.Location = new System.Drawing.Point(105, 99);
            this.edtSucheUnterbetriebVon.Name = "edtSucheUnterbetriebVon";
            this.edtSucheUnterbetriebVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheUnterbetriebVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheUnterbetriebVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheUnterbetriebVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheUnterbetriebVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheUnterbetriebVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheUnterbetriebVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheUnterbetriebVon.Size = new System.Drawing.Size(270, 24);
            this.edtSucheUnterbetriebVon.TabIndex = 6;
            // 
            // lblSucheKontaktperson
            // 
            this.lblSucheKontaktperson.Location = new System.Drawing.Point(8, 129);
            this.lblSucheKontaktperson.Name = "lblSucheKontaktperson";
            this.lblSucheKontaktperson.Size = new System.Drawing.Size(86, 24);
            this.lblSucheKontaktperson.TabIndex = 7;
            this.lblSucheKontaktperson.Text = "Kontaktperson";
            this.lblSucheKontaktperson.UseCompatibleTextRendering = true;
            // 
            // edtSucheKontaktName
            // 
            this.edtSucheKontaktName.Location = new System.Drawing.Point(105, 129);
            this.edtSucheKontaktName.Name = "edtSucheKontaktName";
            this.edtSucheKontaktName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKontaktName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKontaktName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKontaktName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKontaktName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKontaktName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKontaktName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheKontaktName.Size = new System.Drawing.Size(270, 24);
            this.edtSucheKontaktName.TabIndex = 8;
            // 
            // chkInaktiveAnzeigen
            // 
            this.chkInaktiveAnzeigen.EditValue = false;
            this.chkInaktiveAnzeigen.Location = new System.Drawing.Point(105, 159);
            this.chkInaktiveAnzeigen.Name = "chkInaktiveAnzeigen";
            this.chkInaktiveAnzeigen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkInaktiveAnzeigen.Properties.Appearance.Options.UseBackColor = true;
            this.chkInaktiveAnzeigen.Properties.Caption = "Auch inaktive Betriebe anzeigen";
            this.chkInaktiveAnzeigen.Size = new System.Drawing.Size(270, 19);
            this.chkInaktiveAnzeigen.TabIndex = 10;
            // 
            // tabBetrieb
            // 
            this.tabBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBetrieb.Controls.Add(this.tpgEinsatzplaetze);
            this.tabBetrieb.Controls.Add(this.tpgDokumente);
            this.tabBetrieb.Controls.Add(this.tpgVerlauf);
            this.tabBetrieb.Controls.Add(this.tpgKontakt);
            this.tabBetrieb.Controls.Add(this.tpgUebersicht);
            this.tabBetrieb.Controls.Add(this.tpgGrunddaten);
            this.tabBetrieb.Location = new System.Drawing.Point(3, 279);
            this.tabBetrieb.Name = "tabBetrieb";
            this.tabBetrieb.SelectedTabIndex = 3;
            this.tabBetrieb.ShowFixedWidthTooltip = true;
            this.tabBetrieb.Size = new System.Drawing.Size(782, 353);
            this.tabBetrieb.TabIndex = 1;
            this.tabBetrieb.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgUebersicht,
            this.tpgGrunddaten,
            this.tpgKontakt,
            this.tpgVerlauf,
            this.tpgDokumente,
            this.tpgEinsatzplaetze});
            this.tabBetrieb.TabsLineColor = System.Drawing.Color.Black;
            this.tabBetrieb.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBetrieb.Text = "kissTabControlEx1";
            this.tabBetrieb.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabBetrieb_SelectedTabChanged);
            this.tabBetrieb.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabBetrieb_SelectedTabChanging);
            // 
            // tpgEinsatzplaetze
            // 
            this.tpgEinsatzplaetze.Controls.Add(this.btnJumpToEP);
            this.tpgEinsatzplaetze.Controls.Add(this.grdEinsatzplaetze);
            this.tpgEinsatzplaetze.Location = new System.Drawing.Point(6, 6);
            this.tpgEinsatzplaetze.Name = "tpgEinsatzplaetze";
            this.tpgEinsatzplaetze.Size = new System.Drawing.Size(770, 315);
            this.tpgEinsatzplaetze.TabIndex = 5;
            this.tpgEinsatzplaetze.Title = "Einsatzplätze";
            // 
            // btnJumpToEP
            // 
            this.btnJumpToEP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpToEP.Location = new System.Drawing.Point(615, 276);
            this.btnJumpToEP.Name = "btnJumpToEP";
            this.btnJumpToEP.Size = new System.Drawing.Size(155, 24);
            this.btnJumpToEP.TabIndex = 1;
            this.btnJumpToEP.Text = "Details zum Einsatzplatz";
            this.btnJumpToEP.UseCompatibleTextRendering = true;
            this.btnJumpToEP.UseVisualStyleBackColor = false;
            this.btnJumpToEP.Click += new System.EventHandler(this.btnJumpToEP_Click);
            // 
            // grdEinsatzplaetze
            // 
            this.grdEinsatzplaetze.DataSource = this.qryKaEinsatzplatz;
            // 
            // 
            // 
            this.grdEinsatzplaetze.EmbeddedNavigator.Name = "";
            this.grdEinsatzplaetze.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEinsatzplaetze.Location = new System.Drawing.Point(0, -2);
            this.grdEinsatzplaetze.MainView = this.grvEinsatzplaetze;
            this.grdEinsatzplaetze.Name = "grdEinsatzplaetze";
            this.grdEinsatzplaetze.Size = new System.Drawing.Size(775, 272);
            this.grdEinsatzplaetze.TabIndex = 0;
            this.grdEinsatzplaetze.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinsatzplaetze});
            // 
            // qryKaEinsatzplatz
            // 
            this.qryKaEinsatzplatz.HostControl = this;
            this.qryKaEinsatzplatz.SelectStatement = "SELECT *,\r\n       KaProgramm = dbo.fnLOVText(\'KaVermittlungProgramm\', KaProgrammC" +
    "ode)\r\nFROM KaEinsatzplatz\r\nWHERE KaBetriebID = {0}\r\nORDER BY Bezeichnung ASC";
            this.qryKaEinsatzplatz.TableName = "KaEinsatzplatz";
            this.qryKaEinsatzplatz.AfterFill += new System.EventHandler(this.qryKaEinsatzplatz_AfterFill);
            // 
            // grvEinsatzplaetze
            // 
            this.grvEinsatzplaetze.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEinsatzplaetze.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.Empty.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.Empty.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.EvenRow.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsatzplaetze.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEinsatzplaetze.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEinsatzplaetze.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsatzplaetze.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEinsatzplaetze.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEinsatzplaetze.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsatzplaetze.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsatzplaetze.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsatzplaetze.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsatzplaetze.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.GroupRow.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEinsatzplaetze.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEinsatzplaetze.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEinsatzplaetze.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsatzplaetze.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEinsatzplaetze.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEinsatzplaetze.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsatzplaetze.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEinsatzplaetze.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsatzplaetze.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.OddRow.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinsatzplaetze.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.Row.Options.UseBackColor = true;
            this.grvEinsatzplaetze.Appearance.Row.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplaetze.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEinsatzplaetze.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsatzplaetze.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEinsatzplaetze.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEinsatzplaetze.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEinsatzAktiv,
            this.colEinsatzBezeichnung,
            this.colEinsatzProgramm,
            this.colEinsatzPensum});
            this.grvEinsatzplaetze.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEinsatzplaetze.GridControl = this.grdEinsatzplaetze;
            this.grvEinsatzplaetze.Name = "grvEinsatzplaetze";
            this.grvEinsatzplaetze.OptionsBehavior.Editable = false;
            this.grvEinsatzplaetze.OptionsCustomization.AllowFilter = false;
            this.grvEinsatzplaetze.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEinsatzplaetze.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEinsatzplaetze.OptionsNavigation.UseTabKey = false;
            this.grvEinsatzplaetze.OptionsView.ColumnAutoWidth = false;
            this.grvEinsatzplaetze.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEinsatzplaetze.OptionsView.ShowGroupPanel = false;
            this.grvEinsatzplaetze.OptionsView.ShowIndicator = false;
            // 
            // colEinsatzAktiv
            // 
            this.colEinsatzAktiv.Caption = "Aktiv";
            this.colEinsatzAktiv.FieldName = "Aktiv";
            this.colEinsatzAktiv.Name = "colEinsatzAktiv";
            this.colEinsatzAktiv.Visible = true;
            this.colEinsatzAktiv.VisibleIndex = 0;
            this.colEinsatzAktiv.Width = 57;
            // 
            // colEinsatzBezeichnung
            // 
            this.colEinsatzBezeichnung.Caption = "Bezeichnung";
            this.colEinsatzBezeichnung.FieldName = "Bezeichnung";
            this.colEinsatzBezeichnung.Name = "colEinsatzBezeichnung";
            this.colEinsatzBezeichnung.Visible = true;
            this.colEinsatzBezeichnung.VisibleIndex = 1;
            this.colEinsatzBezeichnung.Width = 359;
            // 
            // colEinsatzProgramm
            // 
            this.colEinsatzProgramm.Caption = "KA-Programm";
            this.colEinsatzProgramm.FieldName = "KaProgramm";
            this.colEinsatzProgramm.Name = "colEinsatzProgramm";
            this.colEinsatzProgramm.Visible = true;
            this.colEinsatzProgramm.VisibleIndex = 2;
            this.colEinsatzProgramm.Width = 190;
            // 
            // colEinsatzPensum
            // 
            this.colEinsatzPensum.Caption = "Pensum";
            this.colEinsatzPensum.FieldName = "GesamtPensum";
            this.colEinsatzPensum.Name = "colEinsatzPensum";
            this.colEinsatzPensum.Visible = true;
            this.colEinsatzPensum.VisibleIndex = 3;
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.edtBetriebDokumentXDokument);
            this.tpgDokumente.Controls.Add(this.lblBetriebDokumentDok);
            this.tpgDokumente.Controls.Add(this.edtBetriebDokumentStichwort);
            this.tpgDokumente.Controls.Add(this.lblBetriebDokumentStichwort);
            this.tpgDokumente.Controls.Add(this.edtBetriebDokumentAdressat);
            this.tpgDokumente.Controls.Add(this.lblBetriebDokumentAdressat);
            this.tpgDokumente.Controls.Add(this.edtBetriebDokumentAbsender);
            this.tpgDokumente.Controls.Add(this.lblBetriebDokumentAbsender);
            this.tpgDokumente.Controls.Add(this.edtBetriebDokumentDatum);
            this.tpgDokumente.Controls.Add(this.lblBetriebDokumentDatum);
            this.tpgDokumente.Controls.Add(this.grdBetriebDokumente);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(770, 315);
            this.tpgDokumente.TabIndex = 4;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // edtBetriebDokumentXDokument
            // 
            this.edtBetriebDokumentXDokument.Context = "KaBetriebBetriebDokument";
            this.edtBetriebDokumentXDokument.DataMember = "DokumentDocID";
            this.edtBetriebDokumentXDokument.DataSource = this.qryKaBetriebDokument;
            this.edtBetriebDokumentXDokument.Location = new System.Drawing.Point(101, 269);
            this.edtBetriebDokumentXDokument.Name = "edtBetriebDokumentXDokument";
            this.edtBetriebDokumentXDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetriebDokumentXDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebDokumentXDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebDokumentXDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebDokumentXDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebDokumentXDokument.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebDokumentXDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBetriebDokumentXDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBetriebDokumentXDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBetriebDokumentXDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBetriebDokumentXDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBetriebDokumentXDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtBetriebDokumentXDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetriebDokumentXDokument.Properties.ReadOnly = true;
            this.edtBetriebDokumentXDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBetriebDokumentXDokument.Size = new System.Drawing.Size(144, 24);
            this.edtBetriebDokumentXDokument.TabIndex = 10;
            // 
            // qryKaBetriebDokument
            // 
            this.qryKaBetriebDokument.CanDelete = true;
            this.qryKaBetriebDokument.CanInsert = true;
            this.qryKaBetriebDokument.CanUpdate = true;
            this.qryKaBetriebDokument.HostControl = this;
            this.qryKaBetriebDokument.SelectStatement = resources.GetString("qryKaBetriebDokument.SelectStatement");
            this.qryKaBetriebDokument.TableName = "KaBetriebDokument";
            this.qryKaBetriebDokument.AfterInsert += new System.EventHandler(this.qryKaBetriebDokument_AfterInsert);
            this.qryKaBetriebDokument.BeforePost += new System.EventHandler(this.qryKaBetriebDokument_BeforePost);
            // 
            // lblBetriebDokumentDok
            // 
            this.lblBetriebDokumentDok.Location = new System.Drawing.Point(4, 269);
            this.lblBetriebDokumentDok.Name = "lblBetriebDokumentDok";
            this.lblBetriebDokumentDok.Size = new System.Drawing.Size(91, 24);
            this.lblBetriebDokumentDok.TabIndex = 9;
            this.lblBetriebDokumentDok.Text = "Dokument";
            this.lblBetriebDokumentDok.UseCompatibleTextRendering = true;
            // 
            // edtBetriebDokumentStichwort
            // 
            this.edtBetriebDokumentStichwort.DataMember = "Stichwort";
            this.edtBetriebDokumentStichwort.DataSource = this.qryKaBetriebDokument;
            this.edtBetriebDokumentStichwort.Location = new System.Drawing.Point(101, 240);
            this.edtBetriebDokumentStichwort.Name = "edtBetriebDokumentStichwort";
            this.edtBetriebDokumentStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetriebDokumentStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebDokumentStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebDokumentStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebDokumentStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebDokumentStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebDokumentStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetriebDokumentStichwort.Size = new System.Drawing.Size(666, 24);
            this.edtBetriebDokumentStichwort.TabIndex = 8;
            // 
            // lblBetriebDokumentStichwort
            // 
            this.lblBetriebDokumentStichwort.Location = new System.Drawing.Point(4, 240);
            this.lblBetriebDokumentStichwort.Name = "lblBetriebDokumentStichwort";
            this.lblBetriebDokumentStichwort.Size = new System.Drawing.Size(91, 24);
            this.lblBetriebDokumentStichwort.TabIndex = 7;
            this.lblBetriebDokumentStichwort.Text = "Stichworte";
            this.lblBetriebDokumentStichwort.UseCompatibleTextRendering = true;
            // 
            // edtBetriebDokumentAdressat
            // 
            this.edtBetriebDokumentAdressat.DataMember = "Adressat";
            this.edtBetriebDokumentAdressat.DataSource = this.qryKaBetriebDokument;
            this.edtBetriebDokumentAdressat.Location = new System.Drawing.Point(101, 211);
            this.edtBetriebDokumentAdressat.Name = "edtBetriebDokumentAdressat";
            this.edtBetriebDokumentAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetriebDokumentAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebDokumentAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebDokumentAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebDokumentAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebDokumentAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebDokumentAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBetriebDokumentAdressat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBetriebDokumentAdressat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetriebDokumentAdressat.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBetriebDokumentAdressat.Size = new System.Drawing.Size(329, 24);
            this.edtBetriebDokumentAdressat.TabIndex = 6;
            this.edtBetriebDokumentAdressat.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBetriebDokumentAdressat_UserModifiedFld);
            // 
            // lblBetriebDokumentAdressat
            // 
            this.lblBetriebDokumentAdressat.Location = new System.Drawing.Point(4, 211);
            this.lblBetriebDokumentAdressat.Name = "lblBetriebDokumentAdressat";
            this.lblBetriebDokumentAdressat.Size = new System.Drawing.Size(91, 24);
            this.lblBetriebDokumentAdressat.TabIndex = 5;
            this.lblBetriebDokumentAdressat.Text = "Adressat";
            this.lblBetriebDokumentAdressat.UseCompatibleTextRendering = true;
            // 
            // edtBetriebDokumentAbsender
            // 
            this.edtBetriebDokumentAbsender.DataMember = "Absender";
            this.edtBetriebDokumentAbsender.DataSource = this.qryKaBetriebDokument;
            this.edtBetriebDokumentAbsender.Location = new System.Drawing.Point(101, 182);
            this.edtBetriebDokumentAbsender.Name = "edtBetriebDokumentAbsender";
            this.edtBetriebDokumentAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetriebDokumentAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebDokumentAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebDokumentAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebDokumentAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebDokumentAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebDokumentAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBetriebDokumentAbsender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBetriebDokumentAbsender.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetriebDokumentAbsender.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBetriebDokumentAbsender.Size = new System.Drawing.Size(329, 24);
            this.edtBetriebDokumentAbsender.TabIndex = 4;
            this.edtBetriebDokumentAbsender.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBetriebDokumentAbsender_UserModifiedFld);
            // 
            // lblBetriebDokumentAbsender
            // 
            this.lblBetriebDokumentAbsender.Location = new System.Drawing.Point(4, 183);
            this.lblBetriebDokumentAbsender.Name = "lblBetriebDokumentAbsender";
            this.lblBetriebDokumentAbsender.Size = new System.Drawing.Size(91, 24);
            this.lblBetriebDokumentAbsender.TabIndex = 3;
            this.lblBetriebDokumentAbsender.Text = "Absender";
            this.lblBetriebDokumentAbsender.UseCompatibleTextRendering = true;
            // 
            // edtBetriebDokumentDatum
            // 
            this.edtBetriebDokumentDatum.DataMember = "Datum";
            this.edtBetriebDokumentDatum.DataSource = this.qryKaBetriebDokument;
            this.edtBetriebDokumentDatum.EditValue = null;
            this.edtBetriebDokumentDatum.Location = new System.Drawing.Point(101, 153);
            this.edtBetriebDokumentDatum.Name = "edtBetriebDokumentDatum";
            this.edtBetriebDokumentDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetriebDokumentDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetriebDokumentDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebDokumentDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebDokumentDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebDokumentDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebDokumentDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebDokumentDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBetriebDokumentDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBetriebDokumentDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBetriebDokumentDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetriebDokumentDatum.Properties.ShowToday = false;
            this.edtBetriebDokumentDatum.Size = new System.Drawing.Size(100, 24);
            this.edtBetriebDokumentDatum.TabIndex = 2;
            // 
            // lblBetriebDokumentDatum
            // 
            this.lblBetriebDokumentDatum.Location = new System.Drawing.Point(4, 154);
            this.lblBetriebDokumentDatum.Name = "lblBetriebDokumentDatum";
            this.lblBetriebDokumentDatum.Size = new System.Drawing.Size(91, 24);
            this.lblBetriebDokumentDatum.TabIndex = 1;
            this.lblBetriebDokumentDatum.Text = "Datum";
            this.lblBetriebDokumentDatum.UseCompatibleTextRendering = true;
            // 
            // grdBetriebDokumente
            // 
            this.grdBetriebDokumente.DataSource = this.qryKaBetriebDokument;
            // 
            // 
            // 
            this.grdBetriebDokumente.EmbeddedNavigator.Name = "";
            this.grdBetriebDokumente.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBetriebDokumente.Location = new System.Drawing.Point(0, -2);
            this.grdBetriebDokumente.MainView = this.grvBetriebDokument;
            this.grdBetriebDokumente.Name = "grdBetriebDokumente";
            this.grdBetriebDokumente.Size = new System.Drawing.Size(775, 148);
            this.grdBetriebDokumente.TabIndex = 0;
            this.grdBetriebDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBetriebDokument});
            // 
            // grvBetriebDokument
            // 
            this.grvBetriebDokument.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBetriebDokument.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.Empty.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.Empty.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.EvenRow.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBetriebDokument.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBetriebDokument.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBetriebDokument.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBetriebDokument.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBetriebDokument.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBetriebDokument.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetriebDokument.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetriebDokument.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetriebDokument.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.GroupRow.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBetriebDokument.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBetriebDokument.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBetriebDokument.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBetriebDokument.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBetriebDokument.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetriebDokument.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBetriebDokument.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBetriebDokument.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.OddRow.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBetriebDokument.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.Row.Options.UseBackColor = true;
            this.grvBetriebDokument.Appearance.Row.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebDokument.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBetriebDokument.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBetriebDokument.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBetriebDokument.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBetriebDokument.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDokDatum,
            this.colDokAbsender,
            this.colDokAdressat,
            this.colDokStichworte});
            this.grvBetriebDokument.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBetriebDokument.GridControl = this.grdBetriebDokumente;
            this.grvBetriebDokument.Name = "grvBetriebDokument";
            this.grvBetriebDokument.OptionsBehavior.Editable = false;
            this.grvBetriebDokument.OptionsCustomization.AllowFilter = false;
            this.grvBetriebDokument.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBetriebDokument.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBetriebDokument.OptionsNavigation.UseTabKey = false;
            this.grvBetriebDokument.OptionsView.ColumnAutoWidth = false;
            this.grvBetriebDokument.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBetriebDokument.OptionsView.ShowGroupPanel = false;
            this.grvBetriebDokument.OptionsView.ShowIndicator = false;
            // 
            // colDokDatum
            // 
            this.colDokDatum.Caption = "Datum";
            this.colDokDatum.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDokDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDokDatum.FieldName = "Datum";
            this.colDokDatum.Name = "colDokDatum";
            this.colDokDatum.Visible = true;
            this.colDokDatum.VisibleIndex = 0;
            this.colDokDatum.Width = 90;
            // 
            // colDokAbsender
            // 
            this.colDokAbsender.Caption = "Absender";
            this.colDokAbsender.FieldName = "Absender";
            this.colDokAbsender.Name = "colDokAbsender";
            this.colDokAbsender.Visible = true;
            this.colDokAbsender.VisibleIndex = 1;
            this.colDokAbsender.Width = 152;
            // 
            // colDokAdressat
            // 
            this.colDokAdressat.Caption = "Adressat";
            this.colDokAdressat.FieldName = "Adressat";
            this.colDokAdressat.Name = "colDokAdressat";
            this.colDokAdressat.Visible = true;
            this.colDokAdressat.VisibleIndex = 2;
            this.colDokAdressat.Width = 170;
            // 
            // colDokStichworte
            // 
            this.colDokStichworte.Caption = "Stichworte";
            this.colDokStichworte.FieldName = "Stichwort";
            this.colDokStichworte.Name = "colDokStichworte";
            this.colDokStichworte.Visible = true;
            this.colDokStichworte.VisibleIndex = 3;
            this.colDokStichworte.Width = 332;
            // 
            // tpgVerlauf
            // 
            this.tpgVerlauf.Controls.Add(this.edtBesprechungAutor);
            this.tpgVerlauf.Controls.Add(this.DocKaBetriebVerlauf);
            this.tpgVerlauf.Controls.Add(this.edtBesprechungInhalt);
            this.tpgVerlauf.Controls.Add(this.lblInhalt);
            this.tpgVerlauf.Controls.Add(this.edtKontaktGeplant);
            this.tpgVerlauf.Controls.Add(this.lblKontaktGeplant);
            this.tpgVerlauf.Controls.Add(this.lblAutor);
            this.tpgVerlauf.Controls.Add(this.edtBesprechungStichwort);
            this.tpgVerlauf.Controls.Add(this.lblStichworte);
            this.tpgVerlauf.Controls.Add(this.edtKontaktart);
            this.tpgVerlauf.Controls.Add(this.lblKontaktart);
            this.tpgVerlauf.Controls.Add(this.edtKontaktperson);
            this.tpgVerlauf.Controls.Add(this.lblKontaktpartner);
            this.tpgVerlauf.Controls.Add(this.edtBesprechungDatum);
            this.tpgVerlauf.Controls.Add(this.lblDatum);
            this.tpgVerlauf.Controls.Add(this.grdBetriebVerlauf);
            this.tpgVerlauf.Location = new System.Drawing.Point(6, 6);
            this.tpgVerlauf.Name = "tpgVerlauf";
            this.tpgVerlauf.Size = new System.Drawing.Size(770, 315);
            this.tpgVerlauf.TabIndex = 3;
            this.tpgVerlauf.Title = "Verlauf";
            // 
            // edtBesprechungAutor
            // 
            this.edtBesprechungAutor.DataMember = "Autor";
            this.edtBesprechungAutor.DataMemberUserId = "AutorID";
            this.edtBesprechungAutor.DataSource = this.qryKaBetriebVerlauf;
            this.edtBesprechungAutor.Location = new System.Drawing.Point(491, 142);
            this.edtBesprechungAutor.Name = "edtBesprechungAutor";
            this.edtBesprechungAutor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBesprechungAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBesprechungAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBesprechungAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtBesprechungAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBesprechungAutor.Properties.Appearance.Options.UseFont = true;
            this.edtBesprechungAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBesprechungAutor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBesprechungAutor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBesprechungAutor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBesprechungAutor.Size = new System.Drawing.Size(276, 24);
            this.edtBesprechungAutor.TabIndex = 5;
            // 
            // qryKaBetriebVerlauf
            // 
            this.qryKaBetriebVerlauf.CanDelete = true;
            this.qryKaBetriebVerlauf.CanInsert = true;
            this.qryKaBetriebVerlauf.CanUpdate = true;
            this.qryKaBetriebVerlauf.HostControl = this;
            this.qryKaBetriebVerlauf.SelectStatement = resources.GetString("qryKaBetriebVerlauf.SelectStatement");
            this.qryKaBetriebVerlauf.TableName = "KaBetriebBesprechung";
            this.qryKaBetriebVerlauf.AfterInsert += new System.EventHandler(this.qryKaBetriebVerlauf_AfterInsert);
            this.qryKaBetriebVerlauf.BeforePost += new System.EventHandler(this.qryKaBetriebVerlauf_BeforePost);
            // 
            // DocKaBetriebVerlauf
            // 
            this.DocKaBetriebVerlauf.Context = "KaBetriebVerlauf";
            this.DocKaBetriebVerlauf.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.DocKaBetriebVerlauf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DocKaBetriebVerlauf.Image = ((System.Drawing.Image)(resources.GetObject("DocKaBetriebVerlauf.Image")));
            this.DocKaBetriebVerlauf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DocKaBetriebVerlauf.Location = new System.Drawing.Point(667, 113);
            this.DocKaBetriebVerlauf.Name = "DocKaBetriebVerlauf";
            this.DocKaBetriebVerlauf.Size = new System.Drawing.Size(100, 24);
            this.DocKaBetriebVerlauf.TabIndex = 46;
            this.DocKaBetriebVerlauf.Text = "Dokument";
            this.DocKaBetriebVerlauf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DocKaBetriebVerlauf.UseVisualStyleBackColor = false;
            // 
            // edtBesprechungInhalt
            // 
            this.edtBesprechungInhalt.BackColor = System.Drawing.Color.White;
            this.edtBesprechungInhalt.DataMember = "Inhalt";
            this.edtBesprechungInhalt.DataSource = this.qryKaBetriebVerlauf;
            this.edtBesprechungInhalt.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBesprechungInhalt.Location = new System.Drawing.Point(101, 232);
            this.edtBesprechungInhalt.Name = "edtBesprechungInhalt";
            this.edtBesprechungInhalt.Size = new System.Drawing.Size(666, 73);
            this.edtBesprechungInhalt.TabIndex = 14;
            // 
            // lblInhalt
            // 
            this.lblInhalt.Location = new System.Drawing.Point(4, 232);
            this.lblInhalt.Name = "lblInhalt";
            this.lblInhalt.Size = new System.Drawing.Size(72, 24);
            this.lblInhalt.TabIndex = 13;
            this.lblInhalt.Text = "Inhalt";
            this.lblInhalt.UseCompatibleTextRendering = true;
            // 
            // edtKontaktGeplant
            // 
            this.edtKontaktGeplant.DataMember = "KontaktGeplant";
            this.edtKontaktGeplant.DataSource = this.qryKaBetriebVerlauf;
            this.edtKontaktGeplant.EditValue = null;
            this.edtKontaktGeplant.Location = new System.Drawing.Point(491, 170);
            this.edtKontaktGeplant.Name = "edtKontaktGeplant";
            this.edtKontaktGeplant.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKontaktGeplant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktGeplant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktGeplant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktGeplant.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktGeplant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktGeplant.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktGeplant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtKontaktGeplant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKontaktGeplant.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtKontaktGeplant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktGeplant.Properties.ShowToday = false;
            this.edtKontaktGeplant.Size = new System.Drawing.Size(100, 24);
            this.edtKontaktGeplant.TabIndex = 12;
            // 
            // lblKontaktGeplant
            // 
            this.lblKontaktGeplant.Location = new System.Drawing.Point(398, 170);
            this.lblKontaktGeplant.Name = "lblKontaktGeplant";
            this.lblKontaktGeplant.Size = new System.Drawing.Size(87, 24);
            this.lblKontaktGeplant.TabIndex = 11;
            this.lblKontaktGeplant.Text = "Kontakt geplant";
            this.lblKontaktGeplant.UseCompatibleTextRendering = true;
            // 
            // lblAutor
            // 
            this.lblAutor.Location = new System.Drawing.Point(398, 142);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(87, 24);
            this.lblAutor.TabIndex = 9;
            this.lblAutor.Text = "AutorIn";
            this.lblAutor.UseCompatibleTextRendering = true;
            // 
            // edtBesprechungStichwort
            // 
            this.edtBesprechungStichwort.DataMember = "Stichwort";
            this.edtBesprechungStichwort.DataSource = this.qryKaBetriebVerlauf;
            this.edtBesprechungStichwort.Location = new System.Drawing.Point(101, 200);
            this.edtBesprechungStichwort.Name = "edtBesprechungStichwort";
            this.edtBesprechungStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBesprechungStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBesprechungStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBesprechungStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtBesprechungStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBesprechungStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtBesprechungStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBesprechungStichwort.Size = new System.Drawing.Size(666, 24);
            this.edtBesprechungStichwort.TabIndex = 8;
            // 
            // lblStichworte
            // 
            this.lblStichworte.Location = new System.Drawing.Point(4, 200);
            this.lblStichworte.Name = "lblStichworte";
            this.lblStichworte.Size = new System.Drawing.Size(72, 24);
            this.lblStichworte.TabIndex = 7;
            this.lblStichworte.Text = "Stichworte";
            this.lblStichworte.UseCompatibleTextRendering = true;
            // 
            // edtKontaktart
            // 
            this.edtKontaktart.DataMember = "KontaktArtCode";
            this.edtKontaktart.DataSource = this.qryKaBetriebVerlauf;
            this.edtKontaktart.Location = new System.Drawing.Point(101, 170);
            this.edtKontaktart.LOVName = "KaBetriebKontaktart";
            this.edtKontaktart.Name = "edtKontaktart";
            this.edtKontaktart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktart.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtKontaktart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtKontaktart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktart.Properties.NullText = "";
            this.edtKontaktart.Properties.ShowFooter = false;
            this.edtKontaktart.Properties.ShowHeader = false;
            this.edtKontaktart.Size = new System.Drawing.Size(276, 24);
            this.edtKontaktart.TabIndex = 6;
            // 
            // lblKontaktart
            // 
            this.lblKontaktart.Location = new System.Drawing.Point(4, 170);
            this.lblKontaktart.Name = "lblKontaktart";
            this.lblKontaktart.Size = new System.Drawing.Size(87, 24);
            this.lblKontaktart.TabIndex = 5;
            this.lblKontaktart.Text = "Kontaktart";
            this.lblKontaktart.UseCompatibleTextRendering = true;
            // 
            // edtKontaktperson
            // 
            this.edtKontaktperson.DataMember = "KontaktPersonID";
            this.edtKontaktperson.DataSource = this.qryKaBetriebVerlauf;
            this.edtKontaktperson.Location = new System.Drawing.Point(101, 142);
            this.edtKontaktperson.Name = "edtKontaktperson";
            this.edtKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktperson.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktperson.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtKontaktperson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktperson.Properties.NullText = "";
            this.edtKontaktperson.Properties.ShowFooter = false;
            this.edtKontaktperson.Properties.ShowHeader = false;
            this.edtKontaktperson.Size = new System.Drawing.Size(276, 24);
            this.edtKontaktperson.TabIndex = 4;
            // 
            // lblKontaktpartner
            // 
            this.lblKontaktpartner.Location = new System.Drawing.Point(4, 142);
            this.lblKontaktpartner.Name = "lblKontaktpartner";
            this.lblKontaktpartner.Size = new System.Drawing.Size(72, 24);
            this.lblKontaktpartner.TabIndex = 3;
            this.lblKontaktpartner.Text = "Kontaktperson";
            this.lblKontaktpartner.UseCompatibleTextRendering = true;
            // 
            // edtBesprechungDatum
            // 
            this.edtBesprechungDatum.DataMember = "Datum";
            this.edtBesprechungDatum.DataSource = this.qryKaBetriebVerlauf;
            this.edtBesprechungDatum.EditValue = null;
            this.edtBesprechungDatum.Location = new System.Drawing.Point(101, 113);
            this.edtBesprechungDatum.Name = "edtBesprechungDatum";
            this.edtBesprechungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBesprechungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBesprechungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBesprechungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBesprechungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBesprechungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBesprechungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBesprechungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtBesprechungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBesprechungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtBesprechungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBesprechungDatum.Properties.ShowToday = false;
            this.edtBesprechungDatum.Size = new System.Drawing.Size(100, 24);
            this.edtBesprechungDatum.TabIndex = 2;
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(4, 113);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(72, 24);
            this.lblDatum.TabIndex = 1;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            // 
            // grdBetriebVerlauf
            // 
            this.grdBetriebVerlauf.DataSource = this.qryKaBetriebVerlauf;
            // 
            // 
            // 
            this.grdBetriebVerlauf.EmbeddedNavigator.Name = "";
            this.grdBetriebVerlauf.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBetriebVerlauf.Location = new System.Drawing.Point(0, -2);
            this.grdBetriebVerlauf.MainView = this.grvBetriebVerlauf;
            this.grdBetriebVerlauf.Name = "grdBetriebVerlauf";
            this.grdBetriebVerlauf.Size = new System.Drawing.Size(775, 106);
            this.grdBetriebVerlauf.TabIndex = 0;
            this.grdBetriebVerlauf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBetriebVerlauf});
            // 
            // grvBetriebVerlauf
            // 
            this.grvBetriebVerlauf.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBetriebVerlauf.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.Empty.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.Empty.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.EvenRow.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBetriebVerlauf.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBetriebVerlauf.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBetriebVerlauf.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBetriebVerlauf.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBetriebVerlauf.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBetriebVerlauf.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetriebVerlauf.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetriebVerlauf.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBetriebVerlauf.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetriebVerlauf.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.GroupRow.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBetriebVerlauf.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBetriebVerlauf.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBetriebVerlauf.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBetriebVerlauf.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBetriebVerlauf.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBetriebVerlauf.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetriebVerlauf.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBetriebVerlauf.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBetriebVerlauf.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.OddRow.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBetriebVerlauf.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.Row.Options.UseBackColor = true;
            this.grvBetriebVerlauf.Appearance.Row.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebVerlauf.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBetriebVerlauf.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBetriebVerlauf.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBetriebVerlauf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBetriebVerlauf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colVerlKontaktperson,
            this.colAutor,
            this.colStichwort,
            this.colKontaktGeplant});
            this.grvBetriebVerlauf.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBetriebVerlauf.GridControl = this.grdBetriebVerlauf;
            this.grvBetriebVerlauf.Name = "grvBetriebVerlauf";
            this.grvBetriebVerlauf.OptionsBehavior.Editable = false;
            this.grvBetriebVerlauf.OptionsCustomization.AllowFilter = false;
            this.grvBetriebVerlauf.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBetriebVerlauf.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBetriebVerlauf.OptionsNavigation.UseTabKey = false;
            this.grvBetriebVerlauf.OptionsView.ColumnAutoWidth = false;
            this.grvBetriebVerlauf.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBetriebVerlauf.OptionsView.ShowGroupPanel = false;
            this.grvBetriebVerlauf.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 100;
            // 
            // colVerlKontaktperson
            // 
            this.colVerlKontaktperson.Caption = "Kontaktperson";
            this.colVerlKontaktperson.FieldName = "Kontaktperson";
            this.colVerlKontaktperson.Name = "colVerlKontaktperson";
            this.colVerlKontaktperson.Visible = true;
            this.colVerlKontaktperson.VisibleIndex = 1;
            this.colVerlKontaktperson.Width = 150;
            // 
            // colAutor
            // 
            this.colAutor.Caption = "AutorIn";
            this.colAutor.FieldName = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 2;
            this.colAutor.Width = 150;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichworte";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 3;
            this.colStichwort.Width = 240;
            // 
            // colKontaktGeplant
            // 
            this.colKontaktGeplant.Caption = "Kontakt geplant";
            this.colKontaktGeplant.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colKontaktGeplant.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colKontaktGeplant.FieldName = "KontaktGeplant";
            this.colKontaktGeplant.Name = "colKontaktGeplant";
            this.colKontaktGeplant.Visible = true;
            this.colKontaktGeplant.VisibleIndex = 4;
            this.colKontaktGeplant.Width = 100;
            // 
            // tpgKontakt
            // 
            this.tpgKontakt.Controls.Add(this.edtUseZusatzadresse);
            this.tpgKontakt.Controls.Add(this.lblKorrespondenz);
            this.tpgKontakt.Controls.Add(this.lblKontaktLand);
            this.tpgKontakt.Controls.Add(this.lblKontaktPLZOrtKt);
            this.tpgKontakt.Controls.Add(this.lblKontaktPostfach);
            this.tpgKontakt.Controls.Add(this.lblKontaktStrasseNr);
            this.tpgKontakt.Controls.Add(this.edtKontaktPLZOrtLand);
            this.tpgKontakt.Controls.Add(this.edtKontaktPostfach);
            this.tpgKontakt.Controls.Add(this.edtKontaktHausNr);
            this.tpgKontakt.Controls.Add(this.edtKontaktStrasse);
            this.tpgKontakt.Controls.Add(this.grdProgKontakt);
            this.tpgKontakt.Controls.Add(this.edtKontaktEMail);
            this.tpgKontakt.Controls.Add(this.lblKontaktEmail);
            this.tpgKontakt.Controls.Add(this.edtKontaktFax);
            this.tpgKontakt.Controls.Add(this.lblKontaktFax);
            this.tpgKontakt.Controls.Add(this.edtKontaktTelefonMobil);
            this.tpgKontakt.Controls.Add(this.lblKontakTelefontMobil);
            this.tpgKontakt.Controls.Add(this.edtKontaktTelefon);
            this.tpgKontakt.Controls.Add(this.lblKontaktTelefon);
            this.tpgKontakt.Controls.Add(this.edtKontaktBemerkung);
            this.tpgKontakt.Controls.Add(this.lblKontaktBemerkung);
            this.tpgKontakt.Controls.Add(this.edtKontaktGeschlechtCode);
            this.tpgKontakt.Controls.Add(this.lblKontaktGeschlecht);
            this.tpgKontakt.Controls.Add(this.edtKontaktFunktion);
            this.tpgKontakt.Controls.Add(this.lblKontaktFunktion);
            this.tpgKontakt.Controls.Add(this.edtKontaktVorname);
            this.tpgKontakt.Controls.Add(this.edtKontaktName);
            this.tpgKontakt.Controls.Add(this.lblKontaktlNameVorname);
            this.tpgKontakt.Controls.Add(this.chkKontakAktiv);
            this.tpgKontakt.Controls.Add(this.edtKontaktAnrede);
            this.tpgKontakt.Controls.Add(this.lblKontaktAnrede);
            this.tpgKontakt.Controls.Add(this.grdBetriebKontakt);
            this.tpgKontakt.Location = new System.Drawing.Point(6, 6);
            this.tpgKontakt.Name = "tpgKontakt";
            this.tpgKontakt.Size = new System.Drawing.Size(770, 315);
            this.tpgKontakt.TabIndex = 2;
            this.tpgKontakt.Title = "Kontakt";
            // 
            // edtUseZusatzadresse
            // 
            this.edtUseZusatzadresse.DataMember = "UseZusatzadresse";
            this.edtUseZusatzadresse.DataSource = this.qryKaBetriebKontakt;
            this.edtUseZusatzadresse.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtUseZusatzadresse.Location = new System.Drawing.Point(94, 260);
            this.edtUseZusatzadresse.LookupSQL = null;
            this.edtUseZusatzadresse.LOVFilter = null;
            this.edtUseZusatzadresse.LOVName = null;
            this.edtUseZusatzadresse.Name = "edtUseZusatzadresse";
            this.edtUseZusatzadresse.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtUseZusatzadresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtUseZusatzadresse.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtUseZusatzadresse.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtUseZusatzadresse.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Betriebsadresse"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Zusatzadresse")});
            this.edtUseZusatzadresse.Size = new System.Drawing.Size(306, 34);
            this.edtUseZusatzadresse.TabIndex = 22;
            this.edtUseZusatzadresse.SelectedIndexChanged += new System.EventHandler(this.edtUseZusatzadresse_SelectedIndexChanged);
            // 
            // qryKaBetriebKontakt
            // 
            this.qryKaBetriebKontakt.CanDelete = true;
            this.qryKaBetriebKontakt.CanInsert = true;
            this.qryKaBetriebKontakt.CanUpdate = true;
            this.qryKaBetriebKontakt.HostControl = this;
            this.qryKaBetriebKontakt.SelectStatement = resources.GetString("qryKaBetriebKontakt.SelectStatement");
            this.qryKaBetriebKontakt.TableName = "KaBetriebKontakt";
            this.qryKaBetriebKontakt.AfterFill += new System.EventHandler(this.qryKaBetriebKontakt_AfterFill);
            this.qryKaBetriebKontakt.AfterInsert += new System.EventHandler(this.qryKaBetriebKontakt_AfterInsert);
            this.qryKaBetriebKontakt.BeforePost += new System.EventHandler(this.qryKaBetriebKontakt_BeforePost);
            this.qryKaBetriebKontakt.AfterPost += new System.EventHandler(this.qryKaBetriebKontakt_AfterPost);
            this.qryKaBetriebKontakt.AfterDelete += new System.EventHandler(this.qryKaBetriebKontakt_AfterDelete);
            this.qryKaBetriebKontakt.PositionChanged += new System.EventHandler(this.qryKaBetriebKontakt_PositionChanged);
            // 
            // lblKorrespondenz
            // 
            this.lblKorrespondenz.Location = new System.Drawing.Point(0, 263);
            this.lblKorrespondenz.Name = "lblKorrespondenz";
            this.lblKorrespondenz.Size = new System.Drawing.Size(85, 24);
            this.lblKorrespondenz.TabIndex = 21;
            this.lblKorrespondenz.Text = "Korrespondenz";
            // 
            // lblKontaktLand
            // 
            this.lblKontaktLand.Location = new System.Drawing.Point(3, 206);
            this.lblKontaktLand.Name = "lblKontaktLand";
            this.lblKontaktLand.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktLand.TabIndex = 29;
            this.lblKontaktLand.Text = "Land";
            this.lblKontaktLand.UseCompatibleTextRendering = true;
            // 
            // lblKontaktPLZOrtKt
            // 
            this.lblKontaktPLZOrtKt.Location = new System.Drawing.Point(3, 184);
            this.lblKontaktPLZOrtKt.Name = "lblKontaktPLZOrtKt";
            this.lblKontaktPLZOrtKt.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktPLZOrtKt.TabIndex = 28;
            this.lblKontaktPLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblKontaktPLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // lblKontaktPostfach
            // 
            this.lblKontaktPostfach.Location = new System.Drawing.Point(3, 162);
            this.lblKontaktPostfach.Name = "lblKontaktPostfach";
            this.lblKontaktPostfach.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktPostfach.TabIndex = 26;
            this.lblKontaktPostfach.Text = "Postfach";
            this.lblKontaktPostfach.UseCompatibleTextRendering = true;
            // 
            // lblKontaktStrasseNr
            // 
            this.lblKontaktStrasseNr.Location = new System.Drawing.Point(3, 139);
            this.lblKontaktStrasseNr.Name = "lblKontaktStrasseNr";
            this.lblKontaktStrasseNr.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktStrasseNr.TabIndex = 23;
            this.lblKontaktStrasseNr.Text = "Strasse / Nr.";
            this.lblKontaktStrasseNr.UseCompatibleTextRendering = true;
            // 
            // edtKontaktPLZOrtLand
            // 
            this.edtKontaktPLZOrtLand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontaktPLZOrtLand.DataMember = "OrtschaftCode";
            this.edtKontaktPLZOrtLand.DataSource = this.qryZusatzadresse;
            this.edtKontaktPLZOrtLand.Location = new System.Drawing.Point(94, 184);
            this.edtKontaktPLZOrtLand.Name = "edtKontaktPLZOrtLand";
            this.edtKontaktPLZOrtLand.Size = new System.Drawing.Size(279, 47);
            this.edtKontaktPLZOrtLand.TabIndex = 30;
            // 
            // qryZusatzadresse
            // 
            this.qryZusatzadresse.CanDelete = true;
            this.qryZusatzadresse.CanInsert = true;
            this.qryZusatzadresse.CanUpdate = true;
            this.qryZusatzadresse.HostControl = this;
            this.qryZusatzadresse.SelectStatement = "SELECT * \r\nFROM BaAdresse\r\nWHERE KaBetriebKontaktID = {0}";
            this.qryZusatzadresse.TableName = "BaAdresse";
            this.qryZusatzadresse.AfterInsert += new System.EventHandler(this.qryZusatzadresse_AfterInsert);
            this.qryZusatzadresse.BeforePost += new System.EventHandler(this.qryZusatzadresse_BeforePost);
            this.qryZusatzadresse.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryZusatzadresse_ColumnChanging);
            // 
            // edtKontaktPostfach
            // 
            this.edtKontaktPostfach.DataMember = "Postfach";
            this.edtKontaktPostfach.DataSource = this.qryZusatzadresse;
            this.edtKontaktPostfach.Location = new System.Drawing.Point(94, 162);
            this.edtKontaktPostfach.Name = "edtKontaktPostfach";
            this.edtKontaktPostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktPostfach.Size = new System.Drawing.Size(279, 24);
            this.edtKontaktPostfach.TabIndex = 27;
            // 
            // edtKontaktHausNr
            // 
            this.edtKontaktHausNr.DataMember = "HausNr";
            this.edtKontaktHausNr.DataSource = this.qryZusatzadresse;
            this.edtKontaktHausNr.Location = new System.Drawing.Point(313, 139);
            this.edtKontaktHausNr.Name = "edtKontaktHausNr";
            this.edtKontaktHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktHausNr.Size = new System.Drawing.Size(60, 24);
            this.edtKontaktHausNr.TabIndex = 25;
            // 
            // edtKontaktStrasse
            // 
            this.edtKontaktStrasse.DataMember = "Strasse";
            this.edtKontaktStrasse.DataSource = this.qryZusatzadresse;
            this.edtKontaktStrasse.Location = new System.Drawing.Point(94, 139);
            this.edtKontaktStrasse.Name = "edtKontaktStrasse";
            this.edtKontaktStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktStrasse.Size = new System.Drawing.Size(221, 24);
            this.edtKontaktStrasse.TabIndex = 24;
            // 
            // grdProgKontakt
            // 
            this.grdProgKontakt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdProgKontakt.DataSource = this.qryProgKontakt;
            // 
            // 
            // 
            this.grdProgKontakt.EmbeddedNavigator.Name = "";
            this.grdProgKontakt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProgKontakt.Location = new System.Drawing.Point(513, 242);
            this.grdProgKontakt.MainView = this.grvProgKontakt;
            this.grdProgKontakt.Name = "grdProgKontakt";
            this.grdProgKontakt.Size = new System.Drawing.Size(231, 67);
            this.grdProgKontakt.TabIndex = 35;
            this.grdProgKontakt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProgKontakt});
            // 
            // qryProgKontakt
            // 
            this.qryProgKontakt.HostControl = this;
            this.qryProgKontakt.SelectStatement = resources.GetString("qryProgKontakt.SelectStatement");
            this.qryProgKontakt.TableName = "KaEinsatzplatz";
            // 
            // grvProgKontakt
            // 
            this.grvProgKontakt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProgKontakt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.Empty.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.Empty.Options.UseFont = true;
            this.grvProgKontakt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.EvenRow.Options.UseFont = true;
            this.grvProgKontakt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProgKontakt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProgKontakt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProgKontakt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProgKontakt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProgKontakt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProgKontakt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProgKontakt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProgKontakt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProgKontakt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProgKontakt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProgKontakt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProgKontakt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.GroupRow.Options.UseFont = true;
            this.grvProgKontakt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProgKontakt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProgKontakt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProgKontakt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProgKontakt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProgKontakt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProgKontakt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProgKontakt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProgKontakt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProgKontakt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProgKontakt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProgKontakt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.OddRow.Options.UseFont = true;
            this.grvProgKontakt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProgKontakt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.Row.Options.UseBackColor = true;
            this.grvProgKontakt.Appearance.Row.Options.UseFont = true;
            this.grvProgKontakt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProgKontakt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProgKontakt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProgKontakt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProgKontakt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProgKontakt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProgKontakt});
            this.grvProgKontakt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProgKontakt.GridControl = this.grdProgKontakt;
            this.grvProgKontakt.Name = "grvProgKontakt";
            this.grvProgKontakt.OptionsBehavior.Editable = false;
            this.grvProgKontakt.OptionsCustomization.AllowFilter = false;
            this.grvProgKontakt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProgKontakt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProgKontakt.OptionsNavigation.UseTabKey = false;
            this.grvProgKontakt.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvProgKontakt.OptionsView.ColumnAutoWidth = false;
            this.grvProgKontakt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProgKontakt.OptionsView.ShowGroupPanel = false;
            this.grvProgKontakt.OptionsView.ShowIndicator = false;
            // 
            // colProgKontakt
            // 
            this.colProgKontakt.Caption = "KA-Programme";
            this.colProgKontakt.FieldName = "Programm";
            this.colProgKontakt.Name = "colProgKontakt";
            this.colProgKontakt.Visible = true;
            this.colProgKontakt.VisibleIndex = 0;
            this.colProgKontakt.Width = 205;
            // 
            // edtKontaktEMail
            // 
            this.edtKontaktEMail.DataMember = "EMail";
            this.edtKontaktEMail.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktEMail.Location = new System.Drawing.Point(513, 139);
            this.edtKontaktEMail.Name = "edtKontaktEMail";
            this.edtKontaktEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktEMail.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktEMail.Size = new System.Drawing.Size(250, 24);
            this.edtKontaktEMail.TabIndex = 18;
            // 
            // lblKontaktEmail
            // 
            this.lblKontaktEmail.Location = new System.Drawing.Point(423, 139);
            this.lblKontaktEmail.Name = "lblKontaktEmail";
            this.lblKontaktEmail.Size = new System.Drawing.Size(69, 24);
            this.lblKontaktEmail.TabIndex = 17;
            this.lblKontaktEmail.Text = "E-Mail";
            this.lblKontaktEmail.UseCompatibleTextRendering = true;
            // 
            // edtKontaktFax
            // 
            this.edtKontaktFax.DataMember = "Fax";
            this.edtKontaktFax.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktFax.Location = new System.Drawing.Point(513, 116);
            this.edtKontaktFax.Name = "edtKontaktFax";
            this.edtKontaktFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktFax.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktFax.Size = new System.Drawing.Size(250, 24);
            this.edtKontaktFax.TabIndex = 16;
            // 
            // lblKontaktFax
            // 
            this.lblKontaktFax.Location = new System.Drawing.Point(423, 116);
            this.lblKontaktFax.Name = "lblKontaktFax";
            this.lblKontaktFax.Size = new System.Drawing.Size(69, 24);
            this.lblKontaktFax.TabIndex = 15;
            this.lblKontaktFax.Text = "Fax";
            this.lblKontaktFax.UseCompatibleTextRendering = true;
            // 
            // edtKontaktTelefonMobil
            // 
            this.edtKontaktTelefonMobil.DataMember = "TelefonMobil";
            this.edtKontaktTelefonMobil.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktTelefonMobil.Location = new System.Drawing.Point(513, 93);
            this.edtKontaktTelefonMobil.Name = "edtKontaktTelefonMobil";
            this.edtKontaktTelefonMobil.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktTelefonMobil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktTelefonMobil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktTelefonMobil.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktTelefonMobil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktTelefonMobil.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktTelefonMobil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktTelefonMobil.Size = new System.Drawing.Size(250, 24);
            this.edtKontaktTelefonMobil.TabIndex = 14;
            // 
            // lblKontakTelefontMobil
            // 
            this.lblKontakTelefontMobil.Location = new System.Drawing.Point(423, 94);
            this.lblKontakTelefontMobil.Name = "lblKontakTelefontMobil";
            this.lblKontakTelefontMobil.Size = new System.Drawing.Size(84, 24);
            this.lblKontakTelefontMobil.TabIndex = 13;
            this.lblKontakTelefontMobil.Text = "Telefon mobil";
            this.lblKontakTelefontMobil.UseCompatibleTextRendering = true;
            // 
            // edtKontaktTelefon
            // 
            this.edtKontaktTelefon.DataMember = "Telefon";
            this.edtKontaktTelefon.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktTelefon.Location = new System.Drawing.Point(513, 70);
            this.edtKontaktTelefon.Name = "edtKontaktTelefon";
            this.edtKontaktTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktTelefon.Size = new System.Drawing.Size(250, 24);
            this.edtKontaktTelefon.TabIndex = 12;
            // 
            // lblKontaktTelefon
            // 
            this.lblKontaktTelefon.Location = new System.Drawing.Point(423, 70);
            this.lblKontaktTelefon.Name = "lblKontaktTelefon";
            this.lblKontaktTelefon.Size = new System.Drawing.Size(69, 24);
            this.lblKontaktTelefon.TabIndex = 11;
            this.lblKontaktTelefon.Text = "Telefon";
            this.lblKontaktTelefon.UseCompatibleTextRendering = true;
            // 
            // edtKontaktBemerkung
            // 
            this.edtKontaktBemerkung.DataMember = "Bemerkung";
            this.edtKontaktBemerkung.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktBemerkung.Location = new System.Drawing.Point(513, 169);
            this.edtKontaktBemerkung.Name = "edtKontaktBemerkung";
            this.edtKontaktBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktBemerkung.Size = new System.Drawing.Size(250, 59);
            this.edtKontaktBemerkung.TabIndex = 20;
            // 
            // lblKontaktBemerkung
            // 
            this.lblKontaktBemerkung.Location = new System.Drawing.Point(422, 167);
            this.lblKontaktBemerkung.Name = "lblKontaktBemerkung";
            this.lblKontaktBemerkung.Size = new System.Drawing.Size(85, 24);
            this.lblKontaktBemerkung.TabIndex = 19;
            this.lblKontaktBemerkung.Text = "Bemerkung";
            this.lblKontaktBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtKontaktGeschlechtCode
            // 
            this.edtKontaktGeschlechtCode.DataMember = "GeschlechtCode";
            this.edtKontaktGeschlechtCode.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktGeschlechtCode.Location = new System.Drawing.Point(94, 230);
            this.edtKontaktGeschlechtCode.LOVName = "Geschlecht";
            this.edtKontaktGeschlechtCode.Name = "edtKontaktGeschlechtCode";
            this.edtKontaktGeschlechtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktGeschlechtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktGeschlechtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktGeschlechtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktGeschlechtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktGeschlechtCode.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktGeschlechtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktGeschlechtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktGeschlechtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktGeschlechtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktGeschlechtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtKontaktGeschlechtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtKontaktGeschlechtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktGeschlechtCode.Properties.NullText = "";
            this.edtKontaktGeschlechtCode.Properties.ShowFooter = false;
            this.edtKontaktGeschlechtCode.Properties.ShowHeader = false;
            this.edtKontaktGeschlechtCode.Size = new System.Drawing.Size(306, 24);
            this.edtKontaktGeschlechtCode.TabIndex = 10;
            // 
            // lblKontaktGeschlecht
            // 
            this.lblKontaktGeschlecht.Location = new System.Drawing.Point(3, 230);
            this.lblKontaktGeschlecht.Name = "lblKontaktGeschlecht";
            this.lblKontaktGeschlecht.Size = new System.Drawing.Size(77, 24);
            this.lblKontaktGeschlecht.TabIndex = 9;
            this.lblKontaktGeschlecht.Text = "Geschlecht";
            this.lblKontaktGeschlecht.UseCompatibleTextRendering = true;
            // 
            // edtKontaktFunktion
            // 
            this.edtKontaktFunktion.DataMember = "Funktion";
            this.edtKontaktFunktion.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktFunktion.Location = new System.Drawing.Point(94, 116);
            this.edtKontaktFunktion.Name = "edtKontaktFunktion";
            this.edtKontaktFunktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktFunktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktFunktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktFunktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktFunktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktFunktion.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktFunktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktFunktion.Size = new System.Drawing.Size(306, 24);
            this.edtKontaktFunktion.TabIndex = 8;
            // 
            // lblKontaktFunktion
            // 
            this.lblKontaktFunktion.Location = new System.Drawing.Point(3, 116);
            this.lblKontaktFunktion.Name = "lblKontaktFunktion";
            this.lblKontaktFunktion.Size = new System.Drawing.Size(77, 24);
            this.lblKontaktFunktion.TabIndex = 7;
            this.lblKontaktFunktion.Text = "Funktion";
            this.lblKontaktFunktion.UseCompatibleTextRendering = true;
            // 
            // edtKontaktVorname
            // 
            this.edtKontaktVorname.DataMember = "Vorname";
            this.edtKontaktVorname.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktVorname.Location = new System.Drawing.Point(272, 93);
            this.edtKontaktVorname.Name = "edtKontaktVorname";
            this.edtKontaktVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktVorname.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktVorname.Size = new System.Drawing.Size(128, 24);
            this.edtKontaktVorname.TabIndex = 6;
            // 
            // edtKontaktName
            // 
            this.edtKontaktName.DataMember = "Name";
            this.edtKontaktName.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktName.Location = new System.Drawing.Point(94, 93);
            this.edtKontaktName.Name = "edtKontaktName";
            this.edtKontaktName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktName.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktName.Size = new System.Drawing.Size(178, 24);
            this.edtKontaktName.TabIndex = 5;
            // 
            // lblKontaktlNameVorname
            // 
            this.lblKontaktlNameVorname.Location = new System.Drawing.Point(3, 93);
            this.lblKontaktlNameVorname.Name = "lblKontaktlNameVorname";
            this.lblKontaktlNameVorname.Size = new System.Drawing.Size(85, 24);
            this.lblKontaktlNameVorname.TabIndex = 4;
            this.lblKontaktlNameVorname.Text = "Name/Vorname";
            this.lblKontaktlNameVorname.UseCompatibleTextRendering = true;
            // 
            // chkKontakAktiv
            // 
            this.chkKontakAktiv.DataMember = "Aktiv";
            this.chkKontakAktiv.DataSource = this.qryKaBetriebKontakt;
            this.chkKontakAktiv.Location = new System.Drawing.Point(343, 71);
            this.chkKontakAktiv.Name = "chkKontakAktiv";
            this.chkKontakAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkKontakAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkKontakAktiv.Properties.Caption = "Aktiv";
            this.chkKontakAktiv.Size = new System.Drawing.Size(57, 19);
            this.chkKontakAktiv.TabIndex = 3;
            // 
            // edtKontaktAnrede
            // 
            this.edtKontaktAnrede.DataMember = "Titel";
            this.edtKontaktAnrede.DataSource = this.qryKaBetriebKontakt;
            this.edtKontaktAnrede.Location = new System.Drawing.Point(94, 70);
            this.edtKontaktAnrede.Name = "edtKontaktAnrede";
            this.edtKontaktAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktAnrede.Size = new System.Drawing.Size(100, 24);
            this.edtKontaktAnrede.TabIndex = 2;
            // 
            // lblKontaktAnrede
            // 
            this.lblKontaktAnrede.Location = new System.Drawing.Point(3, 70);
            this.lblKontaktAnrede.Name = "lblKontaktAnrede";
            this.lblKontaktAnrede.Size = new System.Drawing.Size(77, 24);
            this.lblKontaktAnrede.TabIndex = 1;
            this.lblKontaktAnrede.Text = "Titel";
            this.lblKontaktAnrede.UseCompatibleTextRendering = true;
            // 
            // grdBetriebKontakt
            // 
            this.grdBetriebKontakt.DataSource = this.qryKaBetriebKontakt;
            // 
            // 
            // 
            this.grdBetriebKontakt.EmbeddedNavigator.Name = "";
            this.grdBetriebKontakt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBetriebKontakt.Location = new System.Drawing.Point(0, -2);
            this.grdBetriebKontakt.MainView = this.grvBetriebKontakt;
            this.grdBetriebKontakt.Name = "grdBetriebKontakt";
            this.grdBetriebKontakt.Size = new System.Drawing.Size(775, 66);
            this.grdBetriebKontakt.TabIndex = 0;
            this.grdBetriebKontakt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBetriebKontakt});
            // 
            // grvBetriebKontakt
            // 
            this.grvBetriebKontakt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBetriebKontakt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.Empty.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.Empty.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.EvenRow.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBetriebKontakt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBetriebKontakt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBetriebKontakt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBetriebKontakt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBetriebKontakt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBetriebKontakt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetriebKontakt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetriebKontakt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBetriebKontakt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetriebKontakt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.GroupRow.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBetriebKontakt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBetriebKontakt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBetriebKontakt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBetriebKontakt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBetriebKontakt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBetriebKontakt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetriebKontakt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBetriebKontakt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBetriebKontakt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.OddRow.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBetriebKontakt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.Row.Options.UseBackColor = true;
            this.grvBetriebKontakt.Appearance.Row.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetriebKontakt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBetriebKontakt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBetriebKontakt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBetriebKontakt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBetriebKontakt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAktiv,
            this.colKontaktperson,
            this.colFunktion,
            this.colTelefon,
            this.colEmail});
            this.grvBetriebKontakt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBetriebKontakt.GridControl = this.grdBetriebKontakt;
            this.grvBetriebKontakt.Name = "grvBetriebKontakt";
            this.grvBetriebKontakt.OptionsBehavior.Editable = false;
            this.grvBetriebKontakt.OptionsCustomization.AllowFilter = false;
            this.grvBetriebKontakt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBetriebKontakt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBetriebKontakt.OptionsNavigation.UseTabKey = false;
            this.grvBetriebKontakt.OptionsView.ColumnAutoWidth = false;
            this.grvBetriebKontakt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBetriebKontakt.OptionsView.ShowGroupPanel = false;
            this.grvBetriebKontakt.OptionsView.ShowIndicator = false;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 0;
            this.colAktiv.Width = 48;
            // 
            // colKontaktperson
            // 
            this.colKontaktperson.Caption = "Kontaktperson";
            this.colKontaktperson.FieldName = "Kontaktperson";
            this.colKontaktperson.Name = "colKontaktperson";
            this.colKontaktperson.Visible = true;
            this.colKontaktperson.VisibleIndex = 1;
            this.colKontaktperson.Width = 203;
            // 
            // colFunktion
            // 
            this.colFunktion.Caption = "Funktion";
            this.colFunktion.FieldName = "Funktion";
            this.colFunktion.Name = "colFunktion";
            this.colFunktion.Visible = true;
            this.colFunktion.VisibleIndex = 2;
            this.colFunktion.Width = 147;
            // 
            // colTelefon
            // 
            this.colTelefon.Caption = "Telefon";
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 3;
            this.colTelefon.Width = 113;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "E-Mail";
            this.colEmail.FieldName = "EMail";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            this.colEmail.Width = 192;
            // 
            // tpgUebersicht
            // 
            this.tpgUebersicht.Controls.Add(this.grdLehrberufe);
            this.tpgUebersicht.Controls.Add(this.grdBranche);
            this.tpgUebersicht.Controls.Add(this.grdKaProgramm);
            this.tpgUebersicht.Controls.Add(this.edtUeberPLZOrt);
            this.tpgUebersicht.Controls.Add(this.grdTeilbetriebe);
            this.tpgUebersicht.Controls.Add(this.edtUeberCharakter);
            this.tpgUebersicht.Controls.Add(this.edtUeberTeilbetriebVon);
            this.tpgUebersicht.Controls.Add(this.edtUeberHomepage);
            this.tpgUebersicht.Controls.Add(this.edtUeberEmail);
            this.tpgUebersicht.Controls.Add(this.edtUeberFax);
            this.tpgUebersicht.Controls.Add(this.edtUeberTelefon);
            this.tpgUebersicht.Controls.Add(this.edtUeberHausNr);
            this.tpgUebersicht.Controls.Add(this.edtUeberStrasse);
            this.tpgUebersicht.Controls.Add(this.edtUeberName);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtTeilbetriebe);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtTeilbetriebVon);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtInternet);
            this.tpgUebersicht.Controls.Add(this.kissLabel6);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtEmail);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtFax);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtTelefon);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtPLZOrt);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtAdresse);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtCharakter);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtName);
            this.tpgUebersicht.Location = new System.Drawing.Point(6, 6);
            this.tpgUebersicht.Name = "tpgUebersicht";
            this.tpgUebersicht.Size = new System.Drawing.Size(770, 315);
            this.tpgUebersicht.TabIndex = 0;
            this.tpgUebersicht.Title = "Übersicht";
            // 
            // grdLehrberufe
            // 
            this.grdLehrberufe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdLehrberufe.DataSource = this.qryKaLehrberuf;
            // 
            // 
            // 
            this.grdLehrberufe.EmbeddedNavigator.Name = "";
            this.grdLehrberufe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdLehrberufe.Location = new System.Drawing.Point(497, 218);
            this.grdLehrberufe.MainView = this.grvKaLehrberufe;
            this.grdLehrberufe.Name = "grdLehrberufe";
            this.grdLehrberufe.Size = new System.Drawing.Size(231, 81);
            this.grdLehrberufe.TabIndex = 36;
            this.grdLehrberufe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKaLehrberufe});
            // 
            // qryKaLehrberuf
            // 
            this.qryKaLehrberuf.HostControl = this;
            this.qryKaLehrberuf.SelectStatement = "SELECT Lehrberuf = dbo.fnLOVText(\'KaLehrberuf\', LehrberufCode)\r\nFROM KaEinsatzpla" +
    "tz\r\nWHERE KaBetriebID = {0}\r\nAND Aktiv = 1\r\nAND LehrberufCode is not null\r\nORDER" +
    " BY Lehrberuf ASC";
            this.qryKaLehrberuf.TableName = "KaEinsatzplatz";
            // 
            // grvKaLehrberufe
            // 
            this.grvKaLehrberufe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKaLehrberufe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.Empty.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.Empty.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.EvenRow.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKaLehrberufe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKaLehrberufe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKaLehrberufe.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKaLehrberufe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKaLehrberufe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKaLehrberufe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKaLehrberufe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKaLehrberufe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKaLehrberufe.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.GroupRow.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKaLehrberufe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKaLehrberufe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKaLehrberufe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKaLehrberufe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKaLehrberufe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKaLehrberufe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKaLehrberufe.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKaLehrberufe.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.OddRow.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKaLehrberufe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.Row.Options.UseBackColor = true;
            this.grvKaLehrberufe.Appearance.Row.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaLehrberufe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKaLehrberufe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKaLehrberufe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKaLehrberufe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKaLehrberufe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLehrberuf});
            this.grvKaLehrberufe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKaLehrberufe.GridControl = this.grdLehrberufe;
            this.grvKaLehrberufe.Name = "grvKaLehrberufe";
            this.grvKaLehrberufe.OptionsBehavior.Editable = false;
            this.grvKaLehrberufe.OptionsCustomization.AllowFilter = false;
            this.grvKaLehrberufe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKaLehrberufe.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKaLehrberufe.OptionsNavigation.UseTabKey = false;
            this.grvKaLehrberufe.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvKaLehrberufe.OptionsView.ColumnAutoWidth = false;
            this.grvKaLehrberufe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKaLehrberufe.OptionsView.ShowGroupPanel = false;
            this.grvKaLehrberufe.OptionsView.ShowIndicator = false;
            // 
            // colLehrberuf
            // 
            this.colLehrberuf.Caption = "Lehrberufe";
            this.colLehrberuf.FieldName = "Lehrberuf";
            this.colLehrberuf.Name = "colLehrberuf";
            this.colLehrberuf.Visible = true;
            this.colLehrberuf.VisibleIndex = 0;
            this.colLehrberuf.Width = 205;
            // 
            // grdBranche
            // 
            this.grdBranche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBranche.DataSource = this.qryKaBranche;
            // 
            // 
            // 
            this.grdBranche.EmbeddedNavigator.Name = "";
            this.grdBranche.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBranche.Location = new System.Drawing.Point(497, 34);
            this.grdBranche.MainView = this.grvBranche;
            this.grdBranche.Name = "grdBranche";
            this.grdBranche.Size = new System.Drawing.Size(231, 81);
            this.grdBranche.TabIndex = 35;
            this.grdBranche.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBranche});
            // 
            // qryKaBranche
            // 
            this.qryKaBranche.HostControl = this;
            this.qryKaBranche.SelectStatement = "SELECT Branche = dbo.fnLOVText(\'KaBranche\', BrancheCode)\r\nFROM KaEinsatzplatz\r\nWH" +
    "ERE KaBetriebID = {0}\r\nAND Aktiv = 1\r\nAND BrancheCode is not null\r\nORDER BY Bran" +
    "che ASC";
            this.qryKaBranche.TableName = "KaEinsatzplatz";
            // 
            // grvBranche
            // 
            this.grvBranche.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBranche.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.Empty.Options.UseBackColor = true;
            this.grvBranche.Appearance.Empty.Options.UseFont = true;
            this.grvBranche.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.EvenRow.Options.UseFont = true;
            this.grvBranche.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBranche.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBranche.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBranche.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBranche.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBranche.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBranche.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBranche.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBranche.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBranche.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBranche.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBranche.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBranche.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBranche.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBranche.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBranche.Appearance.GroupRow.Options.UseFont = true;
            this.grvBranche.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBranche.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBranche.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBranche.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBranche.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBranche.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBranche.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBranche.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBranche.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBranche.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBranche.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBranche.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBranche.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBranche.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.OddRow.Options.UseFont = true;
            this.grvBranche.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBranche.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.Row.Options.UseBackColor = true;
            this.grvBranche.Appearance.Row.Options.UseFont = true;
            this.grvBranche.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBranche.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBranche.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBranche.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBranche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBranche.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBranche});
            this.grvBranche.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBranche.GridControl = this.grdBranche;
            this.grvBranche.Name = "grvBranche";
            this.grvBranche.OptionsBehavior.Editable = false;
            this.grvBranche.OptionsCustomization.AllowFilter = false;
            this.grvBranche.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBranche.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBranche.OptionsNavigation.UseTabKey = false;
            this.grvBranche.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvBranche.OptionsView.ColumnAutoWidth = false;
            this.grvBranche.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBranche.OptionsView.ShowGroupPanel = false;
            this.grvBranche.OptionsView.ShowIndicator = false;
            // 
            // colBranche
            // 
            this.colBranche.Caption = "Branche";
            this.colBranche.FieldName = "Branche";
            this.colBranche.Name = "colBranche";
            this.colBranche.Visible = true;
            this.colBranche.VisibleIndex = 0;
            this.colBranche.Width = 205;
            // 
            // grdKaProgramm
            // 
            this.grdKaProgramm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdKaProgramm.DataSource = this.qryKaProgramm;
            // 
            // 
            // 
            this.grdKaProgramm.EmbeddedNavigator.Name = "";
            this.grdKaProgramm.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKaProgramm.Location = new System.Drawing.Point(497, 125);
            this.grdKaProgramm.MainView = this.grvKaProgramm;
            this.grdKaProgramm.Name = "grdKaProgramm";
            this.grdKaProgramm.Size = new System.Drawing.Size(231, 81);
            this.grdKaProgramm.TabIndex = 34;
            this.grdKaProgramm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKaProgramm});
            // 
            // qryKaProgramm
            // 
            this.qryKaProgramm.HostControl = this;
            this.qryKaProgramm.SelectStatement = "SELECT Programm = dbo.fnLOVText(\'KaVermittlungProgramm\', KaProgrammCode)\r\nFROM Ka" +
    "Einsatzplatz\r\nWHERE KaBetriebID = {0}\r\nAND Aktiv = 1\r\nAND KaProgrammCode is not " +
    "null\r\nORDER BY Programm ASC";
            this.qryKaProgramm.TableName = "KaEinsatzplatz";
            // 
            // grvKaProgramm
            // 
            this.grvKaProgramm.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKaProgramm.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.Empty.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.Empty.Options.UseFont = true;
            this.grvKaProgramm.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.EvenRow.Options.UseFont = true;
            this.grvKaProgramm.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKaProgramm.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKaProgramm.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKaProgramm.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKaProgramm.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKaProgramm.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKaProgramm.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKaProgramm.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKaProgramm.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKaProgramm.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKaProgramm.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKaProgramm.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.GroupRow.Options.UseFont = true;
            this.grvKaProgramm.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKaProgramm.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKaProgramm.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKaProgramm.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKaProgramm.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKaProgramm.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKaProgramm.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKaProgramm.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKaProgramm.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKaProgramm.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKaProgramm.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.OddRow.Options.UseFont = true;
            this.grvKaProgramm.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKaProgramm.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.Row.Options.UseBackColor = true;
            this.grvKaProgramm.Appearance.Row.Options.UseFont = true;
            this.grvKaProgramm.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKaProgramm.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKaProgramm.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKaProgramm.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKaProgramm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKaProgramm.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProgramm});
            this.grvKaProgramm.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKaProgramm.GridControl = this.grdKaProgramm;
            this.grvKaProgramm.Name = "grvKaProgramm";
            this.grvKaProgramm.OptionsBehavior.Editable = false;
            this.grvKaProgramm.OptionsCustomization.AllowFilter = false;
            this.grvKaProgramm.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKaProgramm.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKaProgramm.OptionsNavigation.UseTabKey = false;
            this.grvKaProgramm.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvKaProgramm.OptionsView.ColumnAutoWidth = false;
            this.grvKaProgramm.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKaProgramm.OptionsView.ShowGroupPanel = false;
            this.grvKaProgramm.OptionsView.ShowIndicator = false;
            // 
            // colProgramm
            // 
            this.colProgramm.Caption = "KA-Programme";
            this.colProgramm.FieldName = "Programm";
            this.colProgramm.Name = "colProgramm";
            this.colProgramm.Visible = true;
            this.colProgramm.VisibleIndex = 0;
            this.colProgramm.Width = 205;
            // 
            // edtUeberPLZOrt
            // 
            this.edtUeberPLZOrt.DataMember = "PLZOrt";
            this.edtUeberPLZOrt.DataSource = this.qryKaBetrieb;
            this.edtUeberPLZOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberPLZOrt.Location = new System.Drawing.Point(93, 49);
            this.edtUeberPLZOrt.Name = "edtUeberPLZOrt";
            this.edtUeberPLZOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberPLZOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberPLZOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberPLZOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberPLZOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberPLZOrt.Properties.Appearance.Options.UseFont = true;
            this.edtUeberPLZOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberPLZOrt.Properties.ReadOnly = true;
            this.edtUeberPLZOrt.Size = new System.Drawing.Size(279, 24);
            this.edtUeberPLZOrt.TabIndex = 33;
            // 
            // grdTeilbetriebe
            // 
            this.grdTeilbetriebe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdTeilbetriebe.DataSource = this.qryTeilbetriebe;
            // 
            // 
            // 
            this.grdTeilbetriebe.EmbeddedNavigator.Name = "";
            this.grdTeilbetriebe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdTeilbetriebe.Location = new System.Drawing.Point(93, 212);
            this.grdTeilbetriebe.MainView = this.grvTeilbetriebe;
            this.grdTeilbetriebe.Name = "grdTeilbetriebe";
            this.grdTeilbetriebe.Size = new System.Drawing.Size(231, 97);
            this.grdTeilbetriebe.TabIndex = 32;
            this.grdTeilbetriebe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTeilbetriebe});
            // 
            // qryTeilbetriebe
            // 
            this.qryTeilbetriebe.HostControl = this;
            this.qryTeilbetriebe.SelectStatement = "SELECT BetriebName \r\nFROM KaBetrieb\r\nWHERE TeilbetriebID = {0}\r\nORDER BY BetriebN" +
    "ame ASC";
            this.qryTeilbetriebe.TableName = "KaBetrieb";
            // 
            // grvTeilbetriebe
            // 
            this.grvTeilbetriebe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvTeilbetriebe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.Empty.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.Empty.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.EvenRow.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTeilbetriebe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvTeilbetriebe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.FocusedCell.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvTeilbetriebe.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTeilbetriebe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvTeilbetriebe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.FocusedRow.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvTeilbetriebe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTeilbetriebe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTeilbetriebe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTeilbetriebe.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.GroupRow.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvTeilbetriebe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvTeilbetriebe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvTeilbetriebe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvTeilbetriebe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvTeilbetriebe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTeilbetriebe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvTeilbetriebe.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvTeilbetriebe.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.OddRow.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvTeilbetriebe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.Row.Options.UseBackColor = true;
            this.grvTeilbetriebe.Appearance.Row.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTeilbetriebe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvTeilbetriebe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvTeilbetriebe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvTeilbetriebe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvTeilbetriebe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTeilbetriebName});
            this.grvTeilbetriebe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTeilbetriebe.GridControl = this.grdTeilbetriebe;
            this.grvTeilbetriebe.Name = "grvTeilbetriebe";
            this.grvTeilbetriebe.OptionsBehavior.Editable = false;
            this.grvTeilbetriebe.OptionsCustomization.AllowFilter = false;
            this.grvTeilbetriebe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvTeilbetriebe.OptionsNavigation.AutoFocusNewRow = true;
            this.grvTeilbetriebe.OptionsNavigation.UseTabKey = false;
            this.grvTeilbetriebe.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvTeilbetriebe.OptionsView.ColumnAutoWidth = false;
            this.grvTeilbetriebe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTeilbetriebe.OptionsView.ShowGroupPanel = false;
            this.grvTeilbetriebe.OptionsView.ShowIndicator = false;
            // 
            // colTeilbetriebName
            // 
            this.colTeilbetriebName.Caption = "Name";
            this.colTeilbetriebName.FieldName = "BetriebName";
            this.colTeilbetriebName.Name = "colTeilbetriebName";
            this.colTeilbetriebName.Visible = true;
            this.colTeilbetriebName.VisibleIndex = 0;
            this.colTeilbetriebName.Width = 205;
            // 
            // edtUeberCharakter
            // 
            this.edtUeberCharakter.DataMember = "Charakter";
            this.edtUeberCharakter.DataSource = this.qryKaBetrieb;
            this.edtUeberCharakter.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberCharakter.Location = new System.Drawing.Point(497, 4);
            this.edtUeberCharakter.Name = "edtUeberCharakter";
            this.edtUeberCharakter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberCharakter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberCharakter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberCharakter.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberCharakter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberCharakter.Properties.Appearance.Options.UseFont = true;
            this.edtUeberCharakter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberCharakter.Properties.ReadOnly = true;
            this.edtUeberCharakter.Size = new System.Drawing.Size(270, 24);
            this.edtUeberCharakter.TabIndex = 31;
            // 
            // edtUeberTeilbetriebVon
            // 
            this.edtUeberTeilbetriebVon.DataMember = "TeilbetriebName";
            this.edtUeberTeilbetriebVon.DataSource = this.qryKaBetrieb;
            this.edtUeberTeilbetriebVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberTeilbetriebVon.Location = new System.Drawing.Point(93, 182);
            this.edtUeberTeilbetriebVon.Name = "edtUeberTeilbetriebVon";
            this.edtUeberTeilbetriebVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberTeilbetriebVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberTeilbetriebVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberTeilbetriebVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberTeilbetriebVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberTeilbetriebVon.Properties.Appearance.Options.UseFont = true;
            this.edtUeberTeilbetriebVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberTeilbetriebVon.Properties.ReadOnly = true;
            this.edtUeberTeilbetriebVon.Size = new System.Drawing.Size(231, 24);
            this.edtUeberTeilbetriebVon.TabIndex = 30;
            // 
            // edtUeberHomepage
            // 
            this.edtUeberHomepage.DataMember = "Homepage";
            this.edtUeberHomepage.DataSource = this.qryKaBetrieb;
            this.edtUeberHomepage.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberHomepage.Location = new System.Drawing.Point(93, 141);
            this.edtUeberHomepage.Name = "edtUeberHomepage";
            this.edtUeberHomepage.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberHomepage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberHomepage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberHomepage.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberHomepage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberHomepage.Properties.Appearance.Options.UseFont = true;
            this.edtUeberHomepage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberHomepage.Properties.ReadOnly = true;
            this.edtUeberHomepage.Size = new System.Drawing.Size(231, 24);
            this.edtUeberHomepage.TabIndex = 29;
            // 
            // edtUeberEmail
            // 
            this.edtUeberEmail.DataMember = "EMail";
            this.edtUeberEmail.DataSource = this.qryKaBetrieb;
            this.edtUeberEmail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberEmail.Location = new System.Drawing.Point(93, 118);
            this.edtUeberEmail.Name = "edtUeberEmail";
            this.edtUeberEmail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberEmail.Properties.Appearance.Options.UseFont = true;
            this.edtUeberEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberEmail.Properties.ReadOnly = true;
            this.edtUeberEmail.Size = new System.Drawing.Size(231, 24);
            this.edtUeberEmail.TabIndex = 28;
            // 
            // edtUeberFax
            // 
            this.edtUeberFax.DataMember = "Fax";
            this.edtUeberFax.DataSource = this.qryKaBetrieb;
            this.edtUeberFax.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberFax.Location = new System.Drawing.Point(93, 95);
            this.edtUeberFax.Name = "edtUeberFax";
            this.edtUeberFax.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberFax.Properties.Appearance.Options.UseFont = true;
            this.edtUeberFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberFax.Properties.ReadOnly = true;
            this.edtUeberFax.Size = new System.Drawing.Size(231, 24);
            this.edtUeberFax.TabIndex = 27;
            // 
            // edtUeberTelefon
            // 
            this.edtUeberTelefon.DataMember = "Telefon";
            this.edtUeberTelefon.DataSource = this.qryKaBetrieb;
            this.edtUeberTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberTelefon.Location = new System.Drawing.Point(93, 72);
            this.edtUeberTelefon.Name = "edtUeberTelefon";
            this.edtUeberTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtUeberTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberTelefon.Properties.ReadOnly = true;
            this.edtUeberTelefon.Size = new System.Drawing.Size(231, 24);
            this.edtUeberTelefon.TabIndex = 26;
            // 
            // edtUeberHausNr
            // 
            this.edtUeberHausNr.DataMember = "HausNr";
            this.edtUeberHausNr.DataSource = this.qryBaAdresse;
            this.edtUeberHausNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberHausNr.Location = new System.Drawing.Point(312, 26);
            this.edtUeberHausNr.Name = "edtUeberHausNr";
            this.edtUeberHausNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtUeberHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberHausNr.Properties.ReadOnly = true;
            this.edtUeberHausNr.Size = new System.Drawing.Size(60, 24);
            this.edtUeberHausNr.TabIndex = 16;
            // 
            // qryBaAdresse
            // 
            this.qryBaAdresse.CanDelete = true;
            this.qryBaAdresse.CanInsert = true;
            this.qryBaAdresse.CanUpdate = true;
            this.qryBaAdresse.HostControl = this;
            this.qryBaAdresse.SelectStatement = "SELECT * \r\nFROM BaAdresse\r\nWHERE KaBetriebID = {0}";
            this.qryBaAdresse.TableName = "BaAdresse";
            this.qryBaAdresse.AfterInsert += new System.EventHandler(this.qryBaAdresse_AfterInsert);
            this.qryBaAdresse.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryBaAdresse_ColumnChanging);
            this.qryBaAdresse.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBaAdresse_ColumnChanged);
            // 
            // edtUeberStrasse
            // 
            this.edtUeberStrasse.DataMember = "Strasse";
            this.edtUeberStrasse.DataSource = this.qryBaAdresse;
            this.edtUeberStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberStrasse.Location = new System.Drawing.Point(93, 26);
            this.edtUeberStrasse.Name = "edtUeberStrasse";
            this.edtUeberStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtUeberStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberStrasse.Properties.ReadOnly = true;
            this.edtUeberStrasse.Size = new System.Drawing.Size(221, 24);
            this.edtUeberStrasse.TabIndex = 15;
            // 
            // edtUeberName
            // 
            this.edtUeberName.DataMember = "BetriebName";
            this.edtUeberName.DataSource = this.qryKaBetrieb;
            this.edtUeberName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUeberName.Location = new System.Drawing.Point(93, 4);
            this.edtUeberName.Name = "edtUeberName";
            this.edtUeberName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUeberName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberName.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberName.Properties.Appearance.Options.UseFont = true;
            this.edtUeberName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUeberName.Properties.ReadOnly = true;
            this.edtUeberName.Size = new System.Drawing.Size(279, 24);
            this.edtUeberName.TabIndex = 14;
            // 
            // lblUebersichtTeilbetriebe
            // 
            this.lblUebersichtTeilbetriebe.Location = new System.Drawing.Point(7, 206);
            this.lblUebersichtTeilbetriebe.Name = "lblUebersichtTeilbetriebe";
            this.lblUebersichtTeilbetriebe.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtTeilbetriebe.TabIndex = 13;
            this.lblUebersichtTeilbetriebe.Text = "Teilbetriebe";
            this.lblUebersichtTeilbetriebe.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtTeilbetriebVon
            // 
            this.lblUebersichtTeilbetriebVon.Location = new System.Drawing.Point(7, 182);
            this.lblUebersichtTeilbetriebVon.Name = "lblUebersichtTeilbetriebVon";
            this.lblUebersichtTeilbetriebVon.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtTeilbetriebVon.TabIndex = 12;
            this.lblUebersichtTeilbetriebVon.Text = "Teilbetrieb von";
            this.lblUebersichtTeilbetriebVon.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtInternet
            // 
            this.lblUebersichtInternet.Location = new System.Drawing.Point(7, 146);
            this.lblUebersichtInternet.Name = "lblUebersichtInternet";
            this.lblUebersichtInternet.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtInternet.TabIndex = 11;
            this.lblUebersichtInternet.Text = "Internet";
            this.lblUebersichtInternet.UseCompatibleTextRendering = true;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(161, 104);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(66, 24);
            this.kissLabel6.TabIndex = 10;
            this.kissLabel6.Text = "";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtEmail
            // 
            this.lblUebersichtEmail.Location = new System.Drawing.Point(7, 122);
            this.lblUebersichtEmail.Name = "lblUebersichtEmail";
            this.lblUebersichtEmail.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtEmail.TabIndex = 9;
            this.lblUebersichtEmail.Text = "E-Mail";
            this.lblUebersichtEmail.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtFax
            // 
            this.lblUebersichtFax.Location = new System.Drawing.Point(7, 98);
            this.lblUebersichtFax.Name = "lblUebersichtFax";
            this.lblUebersichtFax.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtFax.TabIndex = 8;
            this.lblUebersichtFax.Text = "Fax";
            this.lblUebersichtFax.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtTelefon
            // 
            this.lblUebersichtTelefon.Location = new System.Drawing.Point(7, 74);
            this.lblUebersichtTelefon.Name = "lblUebersichtTelefon";
            this.lblUebersichtTelefon.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtTelefon.TabIndex = 6;
            this.lblUebersichtTelefon.Text = "Telefon";
            this.lblUebersichtTelefon.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtPLZOrt
            // 
            this.lblUebersichtPLZOrt.Location = new System.Drawing.Point(7, 48);
            this.lblUebersichtPLZOrt.Name = "lblUebersichtPLZOrt";
            this.lblUebersichtPLZOrt.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtPLZOrt.TabIndex = 4;
            this.lblUebersichtPLZOrt.Text = "PLZ / Ort";
            this.lblUebersichtPLZOrt.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtAdresse
            // 
            this.lblUebersichtAdresse.Location = new System.Drawing.Point(7, 24);
            this.lblUebersichtAdresse.Name = "lblUebersichtAdresse";
            this.lblUebersichtAdresse.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtAdresse.TabIndex = 2;
            this.lblUebersichtAdresse.Text = "Adresse";
            this.lblUebersichtAdresse.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtCharakter
            // 
            this.lblUebersichtCharakter.Location = new System.Drawing.Point(390, 3);
            this.lblUebersichtCharakter.Name = "lblUebersichtCharakter";
            this.lblUebersichtCharakter.Size = new System.Drawing.Size(101, 24);
            this.lblUebersichtCharakter.TabIndex = 1;
            this.lblUebersichtCharakter.Text = "Charakter";
            this.lblUebersichtCharakter.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtName
            // 
            this.lblUebersichtName.Location = new System.Drawing.Point(7, 0);
            this.lblUebersichtName.Name = "lblUebersichtName";
            this.lblUebersichtName.Size = new System.Drawing.Size(80, 24);
            this.lblUebersichtName.TabIndex = 0;
            this.lblUebersichtName.Text = "Name";
            this.lblUebersichtName.UseCompatibleTextRendering = true;
            // 
            // tpgGrunddaten
            // 
            this.tpgGrunddaten.Controls.Add(this.DocBetriebGrunddaten);
            this.tpgGrunddaten.Controls.Add(this.chkInAusbildungsverbund);
            this.tpgGrunddaten.Controls.Add(this.chkAktiv);
            this.tpgGrunddaten.Controls.Add(this.lblCharakter);
            this.tpgGrunddaten.Controls.Add(this.lblInternet);
            this.tpgGrunddaten.Controls.Add(this.lblEmail);
            this.tpgGrunddaten.Controls.Add(this.lblFax);
            this.tpgGrunddaten.Controls.Add(this.lblTelefon);
            this.tpgGrunddaten.Controls.Add(this.lblBemerkung);
            this.tpgGrunddaten.Controls.Add(this.lblTeilbetriebVon);
            this.tpgGrunddaten.Controls.Add(this.lblLand);
            this.tpgGrunddaten.Controls.Add(this.lblPLZOrtKt);
            this.tpgGrunddaten.Controls.Add(this.lblPostfach);
            this.tpgGrunddaten.Controls.Add(this.lblStrasseNr);
            this.tpgGrunddaten.Controls.Add(this.lblZusatz);
            this.tpgGrunddaten.Controls.Add(this.lblName);
            this.tpgGrunddaten.Controls.Add(this.edtBemerkung);
            this.tpgGrunddaten.Controls.Add(this.edtCharakterCode);
            this.tpgGrunddaten.Controls.Add(this.edtHomepage);
            this.tpgGrunddaten.Controls.Add(this.edtEMail);
            this.tpgGrunddaten.Controls.Add(this.edtFax);
            this.tpgGrunddaten.Controls.Add(this.edtTelefon);
            this.tpgGrunddaten.Controls.Add(this.edtUnterbetriebVon);
            this.tpgGrunddaten.Controls.Add(this.edtPLZOrtLand);
            this.tpgGrunddaten.Controls.Add(this.edtPostfach);
            this.tpgGrunddaten.Controls.Add(this.edtHausNr);
            this.tpgGrunddaten.Controls.Add(this.edtStrasse);
            this.tpgGrunddaten.Controls.Add(this.edtAdressZusatz);
            this.tpgGrunddaten.Controls.Add(this.edtName);
            this.tpgGrunddaten.Location = new System.Drawing.Point(6, 6);
            this.tpgGrunddaten.Name = "tpgGrunddaten";
            this.tpgGrunddaten.Size = new System.Drawing.Size(770, 315);
            this.tpgGrunddaten.TabIndex = 0;
            this.tpgGrunddaten.Title = "Grunddaten";
            // 
            // DocBetriebGrunddaten
            // 
            this.DocBetriebGrunddaten.Context = "KaBetriebGrunddaten";
            this.DocBetriebGrunddaten.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.DocBetriebGrunddaten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DocBetriebGrunddaten.Image = ((System.Drawing.Image)(resources.GetObject("DocBetriebGrunddaten.Image")));
            this.DocBetriebGrunddaten.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DocBetriebGrunddaten.Location = new System.Drawing.Point(642, 1);
            this.DocBetriebGrunddaten.Name = "DocBetriebGrunddaten";
            this.DocBetriebGrunddaten.Size = new System.Drawing.Size(100, 24);
            this.DocBetriebGrunddaten.TabIndex = 45;
            this.DocBetriebGrunddaten.Text = "Dokument";
            this.DocBetriebGrunddaten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DocBetriebGrunddaten.UseVisualStyleBackColor = false;
            // 
            // chkInAusbildungsverbund
            // 
            this.chkInAusbildungsverbund.DataMember = "InAusbildungsverbund";
            this.chkInAusbildungsverbund.DataSource = this.qryKaBetrieb;
            this.chkInAusbildungsverbund.Location = new System.Drawing.Point(511, 131);
            this.chkInAusbildungsverbund.Name = "chkInAusbildungsverbund";
            this.chkInAusbildungsverbund.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkInAusbildungsverbund.Properties.Appearance.Options.UseBackColor = true;
            this.chkInAusbildungsverbund.Properties.Caption = " in Ausbildungsverbund";
            this.chkInAusbildungsverbund.Size = new System.Drawing.Size(204, 19);
            this.chkInAusbildungsverbund.TabIndex = 27;
            // 
            // chkAktiv
            // 
            this.chkAktiv.DataMember = "Aktiv";
            this.chkAktiv.DataSource = this.qryKaBetrieb;
            this.chkAktiv.Location = new System.Drawing.Point(511, 5);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = " Aktiv";
            this.chkAktiv.Size = new System.Drawing.Size(86, 19);
            this.chkAktiv.TabIndex = 26;
            // 
            // lblCharakter
            // 
            this.lblCharakter.Location = new System.Drawing.Point(394, 156);
            this.lblCharakter.Name = "lblCharakter";
            this.lblCharakter.Size = new System.Drawing.Size(86, 24);
            this.lblCharakter.TabIndex = 25;
            this.lblCharakter.Text = "Charakter";
            this.lblCharakter.UseCompatibleTextRendering = true;
            // 
            // lblInternet
            // 
            this.lblInternet.Location = new System.Drawing.Point(394, 100);
            this.lblInternet.Name = "lblInternet";
            this.lblInternet.Size = new System.Drawing.Size(70, 24);
            this.lblInternet.TabIndex = 24;
            this.lblInternet.Text = "Internet";
            this.lblInternet.UseCompatibleTextRendering = true;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(394, 77);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 24);
            this.lblEmail.TabIndex = 23;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.UseCompatibleTextRendering = true;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(394, 53);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(70, 24);
            this.lblFax.TabIndex = 22;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            // 
            // lblTelefon
            // 
            this.lblTelefon.Location = new System.Drawing.Point(394, 30);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(70, 24);
            this.lblTelefon.TabIndex = 21;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(3, 190);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(86, 24);
            this.lblBemerkung.TabIndex = 20;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblTeilbetriebVon
            // 
            this.lblTeilbetriebVon.Location = new System.Drawing.Point(4, 156);
            this.lblTeilbetriebVon.Name = "lblTeilbetriebVon";
            this.lblTeilbetriebVon.Size = new System.Drawing.Size(86, 24);
            this.lblTeilbetriebVon.TabIndex = 19;
            this.lblTeilbetriebVon.Text = "Teilbetrieb von";
            this.lblTeilbetriebVon.UseCompatibleTextRendering = true;
            // 
            // lblLand
            // 
            this.lblLand.Location = new System.Drawing.Point(4, 121);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(70, 24);
            this.lblLand.TabIndex = 18;
            this.lblLand.Text = "Land";
            this.lblLand.UseCompatibleTextRendering = true;
            // 
            // lblPLZOrtKt
            // 
            this.lblPLZOrtKt.Location = new System.Drawing.Point(4, 99);
            this.lblPLZOrtKt.Name = "lblPLZOrtKt";
            this.lblPLZOrtKt.Size = new System.Drawing.Size(70, 24);
            this.lblPLZOrtKt.TabIndex = 17;
            this.lblPLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblPLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // lblPostfach
            // 
            this.lblPostfach.Location = new System.Drawing.Point(4, 77);
            this.lblPostfach.Name = "lblPostfach";
            this.lblPostfach.Size = new System.Drawing.Size(70, 24);
            this.lblPostfach.TabIndex = 16;
            this.lblPostfach.Text = "Postfach";
            this.lblPostfach.UseCompatibleTextRendering = true;
            // 
            // lblStrasseNr
            // 
            this.lblStrasseNr.Location = new System.Drawing.Point(4, 54);
            this.lblStrasseNr.Name = "lblStrasseNr";
            this.lblStrasseNr.Size = new System.Drawing.Size(70, 24);
            this.lblStrasseNr.TabIndex = 15;
            this.lblStrasseNr.Text = "Strasse / Nr.";
            this.lblStrasseNr.UseCompatibleTextRendering = true;
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(4, 30);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(70, 24);
            this.lblZusatz.TabIndex = 14;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(4, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 24);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryKaBetrieb;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(92, 197);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(650, 91);
            this.edtBemerkung.TabIndex = 12;
            // 
            // edtCharakterCode
            // 
            this.edtCharakterCode.DataMember = "CharakterCode";
            this.edtCharakterCode.DataSource = this.qryKaBetrieb;
            this.edtCharakterCode.Location = new System.Drawing.Point(511, 156);
            this.edtCharakterCode.LOVName = "KaBetriebCharakter";
            this.edtCharakterCode.Name = "edtCharakterCode";
            this.edtCharakterCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtCharakterCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCharakterCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCharakterCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtCharakterCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCharakterCode.Properties.Appearance.Options.UseFont = true;
            this.edtCharakterCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtCharakterCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtCharakterCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtCharakterCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtCharakterCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtCharakterCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtCharakterCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCharakterCode.Properties.NullText = "";
            this.edtCharakterCode.Properties.ShowFooter = false;
            this.edtCharakterCode.Properties.ShowHeader = false;
            this.edtCharakterCode.Size = new System.Drawing.Size(231, 24);
            this.edtCharakterCode.TabIndex = 11;
            // 
            // edtHomepage
            // 
            this.edtHomepage.DataMember = "Homepage";
            this.edtHomepage.DataSource = this.qryKaBetrieb;
            this.edtHomepage.Location = new System.Drawing.Point(511, 99);
            this.edtHomepage.Name = "edtHomepage";
            this.edtHomepage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHomepage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHomepage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHomepage.Properties.Appearance.Options.UseBackColor = true;
            this.edtHomepage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHomepage.Properties.Appearance.Options.UseFont = true;
            this.edtHomepage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHomepage.Size = new System.Drawing.Size(231, 24);
            this.edtHomepage.TabIndex = 10;
            // 
            // edtEMail
            // 
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryKaBetrieb;
            this.edtEMail.Location = new System.Drawing.Point(511, 76);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Size = new System.Drawing.Size(231, 24);
            this.edtEMail.TabIndex = 9;
            // 
            // edtFax
            // 
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryKaBetrieb;
            this.edtFax.Location = new System.Drawing.Point(511, 53);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Size = new System.Drawing.Size(231, 24);
            this.edtFax.TabIndex = 8;
            // 
            // edtTelefon
            // 
            this.edtTelefon.DataMember = "Telefon";
            this.edtTelefon.DataSource = this.qryKaBetrieb;
            this.edtTelefon.Location = new System.Drawing.Point(511, 30);
            this.edtTelefon.Name = "edtTelefon";
            this.edtTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon.Size = new System.Drawing.Size(231, 24);
            this.edtTelefon.TabIndex = 7;
            // 
            // edtUnterbetriebVon
            // 
            this.edtUnterbetriebVon.DataMember = "TeilbetriebName";
            this.edtUnterbetriebVon.DataSource = this.qryKaBetrieb;
            this.edtUnterbetriebVon.Location = new System.Drawing.Point(92, 156);
            this.edtUnterbetriebVon.Name = "edtUnterbetriebVon";
            this.edtUnterbetriebVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterbetriebVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterbetriebVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterbetriebVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterbetriebVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterbetriebVon.Properties.Appearance.Options.UseFont = true;
            this.edtUnterbetriebVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtUnterbetriebVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtUnterbetriebVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterbetriebVon.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUnterbetriebVon.Size = new System.Drawing.Size(279, 24);
            this.edtUnterbetriebVon.TabIndex = 6;
            this.edtUnterbetriebVon.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUnterbetriebVon_UserModifiedFld);
            // 
            // edtPLZOrtLand
            // 
            this.edtPLZOrtLand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZOrtLand.DataMember = "OrtschaftCode";
            this.edtPLZOrtLand.DataSource = this.qryBaAdresse;
            this.edtPLZOrtLand.Location = new System.Drawing.Point(92, 99);
            this.edtPLZOrtLand.Name = "edtPLZOrtLand";
            this.edtPLZOrtLand.Size = new System.Drawing.Size(279, 47);
            this.edtPLZOrtLand.TabIndex = 5;
            // 
            // edtPostfach
            // 
            this.edtPostfach.DataMember = "Postfach";
            this.edtPostfach.DataSource = this.qryBaAdresse;
            this.edtPostfach.Location = new System.Drawing.Point(92, 77);
            this.edtPostfach.Name = "edtPostfach";
            this.edtPostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfach.Size = new System.Drawing.Size(279, 24);
            this.edtPostfach.TabIndex = 4;
            // 
            // edtHausNr
            // 
            this.edtHausNr.DataMember = "HausNr";
            this.edtHausNr.DataSource = this.qryBaAdresse;
            this.edtHausNr.Location = new System.Drawing.Point(311, 54);
            this.edtHausNr.Name = "edtHausNr";
            this.edtHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNr.Size = new System.Drawing.Size(60, 24);
            this.edtHausNr.TabIndex = 3;
            // 
            // edtStrasse
            // 
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryBaAdresse;
            this.edtStrasse.Location = new System.Drawing.Point(92, 54);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(221, 24);
            this.edtStrasse.TabIndex = 2;
            // 
            // edtAdressZusatz
            // 
            this.edtAdressZusatz.DataMember = "Zusatz";
            this.edtAdressZusatz.DataSource = this.qryBaAdresse;
            this.edtAdressZusatz.Location = new System.Drawing.Point(92, 31);
            this.edtAdressZusatz.Name = "edtAdressZusatz";
            this.edtAdressZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdressZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressZusatz.Size = new System.Drawing.Size(279, 24);
            this.edtAdressZusatz.TabIndex = 1;
            // 
            // edtName
            // 
            this.edtName.DataMember = "BetriebName";
            this.edtName.DataSource = this.qryKaBetrieb;
            this.edtName.Location = new System.Drawing.Point(92, 8);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(279, 24);
            this.edtName.TabIndex = 0;
            // 
            // qryKontaktperson
            // 
            this.qryKontaktperson.HostControl = this;
            this.qryKontaktperson.SelectStatement = "SELECT KaBetriebKontaktID, \r\n       NameVorname = Name + IsNull(\', \' + Vorname, \'" +
    "\')\r\nFROM KaBetriebKontakt\r\nWHERE KaBetriebID = {0}\r\nORDER BY Name ASC";
            this.qryKontaktperson.TableName = "KaBetriebKontakt";
            // 
            // CtlKaBetriebe
            // 
            this.ActiveSQLQuery = this.qryKaBetriebKontakt;
            this.Controls.Add(this.tabBetrieb);
            this.Name = "CtlKaBetriebe";
            this.Size = new System.Drawing.Size(793, 635);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.tabBetrieb, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKaBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKaBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeilbetriebVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUnterbetriebVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontaktName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInaktiveAnzeigen.Properties)).EndInit();
            this.tabBetrieb.ResumeLayout(false);
            this.tpgEinsatzplaetze.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsatzplaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsatzplaetze)).EndInit();
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentXDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetriebDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentDok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebDokumentDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebDokumentDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetriebDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetriebDokument)).EndInit();
            this.tpgVerlauf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBesprechungAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetriebVerlauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeplant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeplant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesprechungStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesprechungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetriebVerlauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetriebVerlauf)).EndInit();
            this.tpgKontakt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUseZusatzadresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUseZusatzadresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBetriebKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrespondenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZusatzadresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProgKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProgKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefonMobil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontakTelefontMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlechtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlechtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFunktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFunktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktlNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontakAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetriebKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetriebKontakt)).EndInit();
            this.tpgUebersicht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLehrberufe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKaLehrberufe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberPLZOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTeilbetriebe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTeilbetriebe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTeilbetriebe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberCharakter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberTeilbetriebVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberHomepage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtTeilbetriebe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtTeilbetriebVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtInternet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtCharakter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtName)).EndInit();
            this.tpgGrunddaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkInAusbildungsverbund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCharakter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInternet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilbetriebVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCharakterCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCharakterCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomepage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterbetriebVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontaktperson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnJumpToEP;
        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private KiSS4.Gui.KissCheckEdit chkInAusbildungsverbund;
        private KiSS4.Gui.KissCheckEdit chkInaktiveAnzeigen;
        private KiSS4.Gui.KissCheckEdit chkKontakAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colBetriebAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBranche;
        private DevExpress.XtraGrid.Columns.GridColumn colCharakter;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDokAbsender;
        private DevExpress.XtraGrid.Columns.GridColumn colDokAdressat;
        private DevExpress.XtraGrid.Columns.GridColumn colDokDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDokStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzProgramm;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colFunktion;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktGeplant;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktperson;
        private DevExpress.XtraGrid.Columns.GridColumn colLehrberuf;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colProgKontakt;
        private DevExpress.XtraGrid.Columns.GridColumn colProgramm;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseHausNr;
        private DevExpress.XtraGrid.Columns.GridColumn colTeilbetriebName;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colVerlKontaktperson;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAdressZusatz;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtBesprechungDatum;
        private KiSS4.Gui.KissRTFEdit edtBesprechungInhalt;
        private KiSS4.Gui.KissTextEdit edtBesprechungStichwort;
        private KiSS4.Gui.KissButtonEdit edtBetriebDokumentAbsender;
        private KiSS4.Gui.KissButtonEdit edtBetriebDokumentAdressat;
        private KiSS4.Gui.KissDateEdit edtBetriebDokumentDatum;
        private KiSS4.Gui.KissTextEdit edtBetriebDokumentStichwort;
        private KiSS4.Dokument.XDokument edtBetriebDokumentXDokument;
        private KiSS4.Gui.KissLookUpEdit edtCharakterCode;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissTextEdit edtFax;
        private KiSS4.Gui.KissTextEdit edtHausNr;
        private KiSS4.Gui.KissTextEdit edtHomepage;
        private KiSS4.Gui.KissTextEdit edtKontaktAnrede;
        private KiSS4.Gui.KissMemoEdit edtKontaktBemerkung;
        private KiSS4.Gui.KissTextEdit edtKontaktEMail;
        private KiSS4.Gui.KissTextEdit edtKontaktFax;
        private KiSS4.Gui.KissTextEdit edtKontaktFunktion;
        private KiSS4.Gui.KissDateEdit edtKontaktGeplant;
        private KiSS4.Gui.KissLookUpEdit edtKontaktGeschlechtCode;
        private KiSS4.Gui.KissTextEdit edtKontaktHausNr;
        private KiSS4.Gui.KissTextEdit edtKontaktName;
        private KiSS4.Common.KissPLZOrt edtKontaktPLZOrtLand;
        private KiSS4.Gui.KissTextEdit edtKontaktPostfach;
        private KiSS4.Gui.KissTextEdit edtKontaktStrasse;
        private KiSS4.Gui.KissTextEdit edtKontaktTelefon;
        private KiSS4.Gui.KissTextEdit edtKontaktTelefonMobil;
        private KiSS4.Gui.KissTextEdit edtKontaktVorname;
        private KiSS4.Gui.KissLookUpEdit edtKontaktart;
        private KiSS4.Gui.KissLookUpEdit edtKontaktperson;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Common.KissPLZOrt edtPLZOrtLand;
        private KiSS4.Gui.KissTextEdit edtPostfach;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissTextEdit edtSucheKontaktName;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissTextEdit edtSucheOrt;
        private KiSS4.Gui.KissTextEdit edtSucheUnterbetriebVon;
        private KiSS4.Gui.KissTextEdit edtTelefon;
        private KiSS4.Gui.KissTextEdit edtUeberCharakter;
        private KiSS4.Gui.KissTextEdit edtUeberEmail;
        private KiSS4.Gui.KissTextEdit edtUeberFax;
        private KiSS4.Gui.KissTextEdit edtUeberHausNr;
        private KiSS4.Gui.KissTextEdit edtUeberHomepage;
        private KiSS4.Gui.KissTextEdit edtUeberName;
        private KiSS4.Gui.KissTextEdit edtUeberPLZOrt;
        private KiSS4.Gui.KissTextEdit edtUeberStrasse;
        private KiSS4.Gui.KissTextEdit edtUeberTeilbetriebVon;
        private KiSS4.Gui.KissTextEdit edtUeberTelefon;
        private KiSS4.Gui.KissButtonEdit edtUnterbetriebVon;
        private KiSS4.Gui.KissRadioGroup edtUseZusatzadresse;
        private KiSS4.Gui.KissGrid grdBetriebDokumente;
        private KiSS4.Gui.KissGrid grdBetriebKontakt;
        private KiSS4.Gui.KissGrid grdBetriebVerlauf;
        private KiSS4.Gui.KissGrid grdBranche;
        private KiSS4.Gui.KissGrid grdEinsatzplaetze;
        private KiSS4.Gui.KissGrid grdKaBetrieb;
        private KiSS4.Gui.KissGrid grdKaProgramm;
        private KiSS4.Gui.KissGrid grdLehrberufe;
        private KiSS4.Gui.KissGrid grdProgKontakt;
        private KiSS4.Gui.KissGrid grdTeilbetriebe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBetriebDokument;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBetriebKontakt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBetriebVerlauf;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBranche;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinsatzplaetze;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKaBetrieb;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKaLehrberufe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKaProgramm;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProgKontakt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTeilbetriebe;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel lblAutor;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetriebDokumentAbsender;
        private KiSS4.Gui.KissLabel lblBetriebDokumentAdressat;
        private KiSS4.Gui.KissLabel lblBetriebDokumentDatum;
        private KiSS4.Gui.KissLabel lblBetriebDokumentDok;
        private KiSS4.Gui.KissLabel lblBetriebDokumentStichwort;
        private KiSS4.Gui.KissLabel lblCharakter;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblInhalt;
        private KiSS4.Gui.KissLabel lblInternet;
        private KiSS4.Gui.KissLabel lblKontakTelefontMobil;
        private KiSS4.Gui.KissLabel lblKontaktAnrede;
        private KiSS4.Gui.KissLabel lblKontaktBemerkung;
        private KiSS4.Gui.KissLabel lblKontaktEmail;
        private KiSS4.Gui.KissLabel lblKontaktFax;
        private KiSS4.Gui.KissLabel lblKontaktFunktion;
        private KiSS4.Gui.KissLabel lblKontaktGeplant;
        private KiSS4.Gui.KissLabel lblKontaktGeschlecht;
        private KiSS4.Gui.KissLabel lblKontaktLand;
        private KiSS4.Gui.KissLabel lblKontaktPLZOrtKt;
        private KiSS4.Gui.KissLabel lblKontaktPostfach;
        private KiSS4.Gui.KissLabel lblKontaktStrasseNr;
        private KiSS4.Gui.KissLabel lblKontaktTelefon;
        private KiSS4.Gui.KissLabel lblKontaktart;
        private KiSS4.Gui.KissLabel lblKontaktlNameVorname;
        private KiSS4.Gui.KissLabel lblKontaktpartner;
        private KiSS4.Gui.KissLabel lblKorrespondenz;
        private KiSS4.Gui.KissLabel lblLand;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPLZOrtKt;
        private KiSS4.Gui.KissLabel lblPostfach;
        private KiSS4.Gui.KissLabel lblStichworte;
        private KiSS4.Gui.KissLabel lblStrasseNr;
        private KiSS4.Gui.KissLabel lblSucheKontaktperson;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheOrt;
        private KiSS4.Gui.KissLabel lblSucheTeilbetriebVon;
        private KiSS4.Gui.KissLabel lblTeilbetriebVon;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblUebersichtAdresse;
        private KiSS4.Gui.KissLabel lblUebersichtCharakter;
        private KiSS4.Gui.KissLabel lblUebersichtEmail;
        private KiSS4.Gui.KissLabel lblUebersichtFax;
        private KiSS4.Gui.KissLabel lblUebersichtInternet;
        private KiSS4.Gui.KissLabel lblUebersichtName;
        private KiSS4.Gui.KissLabel lblUebersichtPLZOrt;
        private KiSS4.Gui.KissLabel lblUebersichtTeilbetriebVon;
        private KiSS4.Gui.KissLabel lblUebersichtTeilbetriebe;
        private KiSS4.Gui.KissLabel lblUebersichtTelefon;
        private KiSS4.Gui.KissLabel lblZusatz;
        private KiSS4.DB.SqlQuery qryBaAdresse;
        private KiSS4.DB.SqlQuery qryKaBetrieb;
        private KiSS4.DB.SqlQuery qryKaBetriebDokument;
        private KiSS4.DB.SqlQuery qryKaBetriebKontakt;
        private KiSS4.DB.SqlQuery qryKaBetriebVerlauf;
        private KiSS4.DB.SqlQuery qryKaBranche;
        private KiSS4.DB.SqlQuery qryKaEinsatzplatz;
        private KiSS4.DB.SqlQuery qryKaLehrberuf;
        private KiSS4.DB.SqlQuery qryKaProgramm;
        private KiSS4.DB.SqlQuery qryKontaktperson;
        private KiSS4.DB.SqlQuery qryProgKontakt;
        private KiSS4.DB.SqlQuery qryTeilbetriebe;
        private KiSS4.DB.SqlQuery qryZusatzadresse;
        private KiSS4.Gui.KissTabControlEx tabBetrieb;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private SharpLibrary.WinControls.TabPageEx tpgEinsatzplaetze;
        private SharpLibrary.WinControls.TabPageEx tpgGrunddaten;
        private SharpLibrary.WinControls.TabPageEx tpgKontakt;
        private SharpLibrary.WinControls.TabPageEx tpgUebersicht;
        private KiSS4.Common.KissMitarbeiterButtonEdit edtBesprechungAutor;
        private SharpLibrary.WinControls.TabPageEx tpgVerlauf;
        protected internal Dokument.KissDocumentButton DocBetriebGrunddaten;
        protected internal Dokument.KissDocumentButton DocKaBetriebVerlauf;
    }
}
