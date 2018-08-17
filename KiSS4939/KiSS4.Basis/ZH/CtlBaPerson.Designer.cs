namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPerson
    {
        #region Fields

        #region Public Fields

        public KiSS4.DB.SqlQuery qryBaPerson;
        public KiSS4.Gui.KissTabControlEx tabStammdaten;

        #endregion

        #region Private Fields

        private KiSS4.Gui.KissButton btnOmegaImport;
        private KiSS4.Gui.KissButton btnAnonymisieren;
        private KiSS4.Dokument.KissDocumentButton btnDatenblatt;
        private KiSS4.Gui.KissButton btnHeimatorte;
        private KiSS4.Gui.KissHyperlinkButton btnKIS;
        private KiSS4.Gui.KissButton btnSendToPscd;
        private KiSS4.Gui.KissLookUpEdit cboAuslaenderStatus;
        private KiSS4.Gui.KissButtonEdit edtErlernterBeruf;
        private KiSS4.Gui.KissLookUpEdit edtErwerbssituation;
        private KiSS4.Gui.KissLookUpEdit edtHoechsteAusbildung;
        private KiSS4.Gui.KissLookUpEdit edtLetzteAbgebrocheneAusbildung;
        private KiSS4.Gui.KissButtonEdit edtJetzigeTaetigkeit;
        private KiSS4.Gui.KissLookUpEdit edtGrundNichtErwerbstaetig;
        private KiSS4.Gui.KissLookUpEdit cboWichitgerHinweis;
        private KiSS4.Gui.KissCheckEdit edtIKAuszug;
        private KiSS4.Gui.KissComboBox edtIKAuszugJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colGesetz;
        private DevExpress.XtraGrid.Columns.GridColumn colGesetz1;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr1;
        private DevExpress.XtraGrid.Columns.GridColumn colKrankenkasse;
        private DevExpress.XtraGrid.Columns.GridColumn colKrankenkasse1;
        private System.ComponentModel.IContainer components;
        private KiSS4.Basis.ZH.CtlBaPersonAdresse ctlAdressen;
        private KiSS4.Basis.ZH.CtlBaPersonAlteFallnr ctlAlteFallNr;
        private KiSS4.Basis.ZH.CtlBaPersonArbeit ctlArbeit;
        private KiSS4.Basis.ZH.CtlBaPersonErsatzeinkommen ctlBaPersonErsatzeinkommen;
        private KiSS4.Basis.ZH.CtlBaPersonVermoegen ctlBaPersonVermoegen;
        private KiSS4.Basis.ZH.CtlBaPersonKrankenkasse ctlKrankenversicherung;
        private KiSS4.Basis.ZH.CtlBaPersonWVCode ctlWVCode;
        private KiSS4.Basis.ZH.CtlBaZahlungsweg ctlZahlungsweg;
        private KiSS4.Common.KissBfsDtpSeitGeburt datZuzugKantonSeit;
        private KiSS4.Common.KissBfsDtpSeitGeburt datZuzugSeit;
        private KiSS4.Gui.KissDateEdit dtpAuslaenderStatusGueltigBis;
        private KiSS4.Gui.KissDateEdit editInCHSeit;
        private KiSS4.Gui.KissCheckEdit editInCHSeitGeburt;
        private KiSS4.Gui.KissTextEdit edtAHVNr;
        private KiSS4.Gui.KissCheckEdit edtEinwohnerregisterAktiv;
        private KiSS4.Gui.KissTextEdit edtZemisNummer;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtDeutschVerstehenCode;
        private KiSS4.Gui.KissTextEdit edtEmail;
        private KiSS4.Gui.KissDateEdit edtGeburtstag;
        private KiSS4.Gui.KissLookUpEdit edtGeschlecht;
        private KiSS4.Gui.KissButtonEdit edtHeimatort;
        private KiSS4.Gui.KissTextEdit edtHeimtortLand;
        private KiSS4.Gui.KissDateEdit edtInCHseit2;
        private KiSS4.Gui.KissTextEdit edtKantRefNummer;
        private KiSS4.Gui.KissTextEdit edtMobil1;
        private KiSS4.Gui.KissTextEdit edtMobil2;
        private KiSS4.Gui.KissDateEdit edtNEAnmeldung;
        private KiSS4.Gui.KissTextEdit edtZarNummer;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaet;
        private KiSS4.Gui.KissCheckEdit edtPersonOhneLeistung;
        private KiSS4.Gui.KissLookUpEdit edtReligion;
        private KiSS4.Gui.KissButtonEdit edtSozialRaum;
        private KiSS4.Gui.KissLookUpEdit edtSprache;
        private KiSS4.Gui.KissDateEdit edtSterbeDatum;
        private KiSS4.Gui.KissTextEdit edtTelG;
        private KiSS4.Gui.KissTextEdit edtTelP;
        private KiSS4.Gui.KissVersichertenNrEdit edtVersichertennummer;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissDateEdit edtWegzugDatum;
        private KiSS4.Gui.KissTextEdit edtWegzugKanton;
        private KiSS4.Gui.KissLookUpEdit edtWegzugLand;
        private KiSS4.Gui.KissTextEdit edtWegzugOrt;
        private KiSS4.Gui.KissTextEdit edtWegzugPLZ;
        private KiSS4.Gui.KissTextEdit edtPID;
        private KiSS4.Gui.KissLookUpEdit edtZivilstand;
        private KiSS4.Gui.KissDateEdit edtZivilstandSeit;
        private KiSS4.Common.KissPLZOrt edtZuzugGdeOrtCode;
        private KiSS4.Common.KissPLZOrt edtZuzugKtOrtCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel lblZarNummer;
        private KiSS4.Gui.KissLabel kissLabel103;
        private KiSS4.Gui.KissLabel kissLabel104;
        private KiSS4.Gui.KissLabel kissLabel108;
        private KiSS4.Gui.KissLabel kissLabel109;
        private KiSS4.Gui.KissLabel lblAnstellungsverhaeltnis;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel lblStellensuche;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel lblLetzteAbgebrAusbildung;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel lblHoechsteAusbildung;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel lblJetzigeTaetigkeit;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel lblErlernterBeruf;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel kissLabel23;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel33;
        private KiSS4.Gui.KissLabel kissLabel35;
        private KiSS4.Gui.KissLabel kissLabel39;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblZemisNr;
        private KiSS4.Gui.KissLabel lblPID;
        private KiSS4.Gui.KissLabel kissLabel48;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel lblSpezielleFaehigkeiten;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel72;
        private KiSS4.Gui.KissLabel kissLabel73;
        private KiSS4.Gui.KissLabel kissLabel75;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel81;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel lblGrundNichtErwerbstaetig;
        private KiSS4.Gui.KissLookUpEdit edtStellensuche;
        private KiSS4.Gui.KissLabel label9;

        // Letzte Bearbeitung
        // 31.07.2007 : sozheo : alles neu
        // 11.11.2007 : sozheo : Heimatort oder Land anzeigen, Seite WVCode
        // 11.12.2007 : sozksc : Tabwechsel für fiktive Personen unterbinden
        // 08.02.2008 : sozheo : Tabwechsel korrigiert
        // TODO: für sozmim: neue funktion einbinden, siehe z.B. ctlArbeit.CtlBaPersonArbeit_CanSaveData()
        // ------------------------------------------------------------------------------
        private SharpLibrary.WinControls.TabPageEx lastSelectedTab;
        private KiSS4.Gui.KissLabel lblDatumGemeinde;
        private KiSS4.Gui.KissLabel lblDatumKanton;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblIKAuszugBemerkung;
        private KiSS4.Gui.KissLabel lblInCHseit;
        private KiSS4.Gui.KissLabel lblLandGemeinde;
        private KiSS4.Gui.KissLabel lblLandKanton;
        private KiSS4.Gui.KissLabel lblNEAnmeldung;
        private KiSS4.Gui.KissLabel lblPlzZuzugGemeinde;
        private KiSS4.Gui.KissLabel lblPlzZuzugKanton;
        private KiSS4.Gui.KissLabel lblSozialraum;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissMemoEdit memSpezFaehigkeiten;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panArbeitTop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picTitel;
        private System.Windows.Forms.Panel pnlAdressenBottom;
        private KiSS4.DB.SqlQuery qryPraemienuebernahme;
        private KiSS4.DB.SqlQuery qryPraemienverbilligung;
        private SharpLibrary.WinControls.TabPageEx tbpAdressen;
        private SharpLibrary.WinControls.TabPageEx tbpAlteFallNr;
        private SharpLibrary.WinControls.TabPageEx tbpArbeit;
        private SharpLibrary.WinControls.TabPageEx tbpErsatzeinkommen;
        private SharpLibrary.WinControls.TabPageEx tbpPersonalien;
        private SharpLibrary.WinControls.TabPageEx tbpVermoegen;
        private SharpLibrary.WinControls.TabPageEx tbpVersicherungen;
        private SharpLibrary.WinControls.TabPageEx tbpWVCode;
        private SharpLibrary.WinControls.TabPageEx tbpZahlweg;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPerson));
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject24 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject25 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject26 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tabStammdaten = new KiSS4.Gui.KissTabControlEx();
            this.tbpPersonalien = new SharpLibrary.WinControls.TabPageEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSozialraum = new KiSS4.Gui.KissLabel();
            this.edtSozialRaum = new KiSS4.Gui.KissButtonEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel48 = new KiSS4.Gui.KissLabel();
            this.kissLabel35 = new KiSS4.Gui.KissLabel();
            this.edtEinwohnerregisterAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtPersonOhneLeistung = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel104 = new KiSS4.Gui.KissLabel();
            this.kissLabel103 = new KiSS4.Gui.KissLabel();
            this.lblZemisNr = new KiSS4.Gui.KissLabel();
            this.kissLabel81 = new KiSS4.Gui.KissLabel();
            this.lblZarNummer = new KiSS4.Gui.KissLabel();
            this.lblPID = new KiSS4.Gui.KissLabel();
            this.kissLabel39 = new KiSS4.Gui.KissLabel();
            this.kissLabel23 = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.label9 = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.edtPID = new KiSS4.Gui.KissTextEdit();
            this.btnDatenblatt = new KiSS4.Dokument.KissDocumentButton();
            this.btnAnonymisieren = new KiSS4.Gui.KissButton();
            this.btnKIS = new KiSS4.Gui.KissHyperlinkButton();
            this.btnSendToPscd = new KiSS4.Gui.KissButton();
            this.btnOmegaImport = new KiSS4.Gui.KissButton();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.edtZarNummer = new KiSS4.Gui.KissTextEdit();
            this.edtKantRefNummer = new KiSS4.Gui.KissTextEdit();
            this.edtZemisNummer = new KiSS4.Gui.KissTextEdit();
            this.dtpAuslaenderStatusGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.cboAuslaenderStatus = new KiSS4.Gui.KissLookUpEdit();
            this.editInCHSeitGeburt = new KiSS4.Gui.KissCheckEdit();
            this.editInCHSeit = new KiSS4.Gui.KissDateEdit();
            this.edtDeutschVerstehenCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSprache = new KiSS4.Gui.KissLookUpEdit();
            this.edtReligion = new KiSS4.Gui.KissLookUpEdit();
            this.edtHeimatort = new KiSS4.Gui.KissButtonEdit();
            this.btnHeimatorte = new KiSS4.Gui.KissButton();
            this.edtNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.cboWichitgerHinweis = new KiSS4.Gui.KissLookUpEdit();
            this.edtSterbeDatum = new KiSS4.Gui.KissDateEdit();
            this.edtVersichertennummer = new KiSS4.Gui.KissVersichertenNrEdit();
            this.edtGeburtstag = new KiSS4.Gui.KissDateEdit();
            this.edtAHVNr = new KiSS4.Gui.KissTextEdit();
            this.edtZivilstandSeit = new KiSS4.Gui.KissDateEdit();
            this.edtZivilstand = new KiSS4.Gui.KissLookUpEdit();
            this.edtGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.edtEmail = new KiSS4.Gui.KissTextEdit();
            this.edtMobil2 = new KiSS4.Gui.KissTextEdit();
            this.edtMobil1 = new KiSS4.Gui.KissTextEdit();
            this.edtTelG = new KiSS4.Gui.KissTextEdit();
            this.edtTelP = new KiSS4.Gui.KissTextEdit();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.tbpAdressen = new SharpLibrary.WinControls.TabPageEx();
            this.ctlAdressen = new KiSS4.Basis.ZH.CtlBaPersonAdresse();
            this.pnlAdressenBottom = new System.Windows.Forms.Panel();
            this.kissLabel75 = new KiSS4.Gui.KissLabel();
            this.kissLabel73 = new KiSS4.Gui.KissLabel();
            this.kissLabel72 = new KiSS4.Gui.KissLabel();
            this.edtWegzugDatum = new KiSS4.Gui.KissDateEdit();
            this.edtWegzugLand = new KiSS4.Gui.KissLookUpEdit();
            this.edtWegzugKanton = new KiSS4.Gui.KissTextEdit();
            this.edtWegzugOrt = new KiSS4.Gui.KissTextEdit();
            this.edtWegzugPLZ = new KiSS4.Gui.KissTextEdit();
            this.kissLabel33 = new KiSS4.Gui.KissLabel();
            this.tbpVersicherungen = new SharpLibrary.WinControls.TabPageEx();
            this.ctlKrankenversicherung = new KiSS4.Basis.ZH.CtlBaPersonKrankenkasse();
            this.tbpArbeit = new SharpLibrary.WinControls.TabPageEx();
            this.ctlArbeit = new KiSS4.Basis.ZH.CtlBaPersonArbeit();
            this.panArbeitTop = new System.Windows.Forms.Panel();
            this.grpNichtErwerbstaetig = new KiSS4.Gui.KissGroupBox();
            this.lblGrundNichtErwerbstaetig = new KiSS4.Gui.KissLabel();
            this.edtGrundNichtErwerbstaetig = new KiSS4.Gui.KissLookUpEdit();
            this.edtNEAnmeldung = new KiSS4.Gui.KissDateEdit();
            this.lblNEAnmeldung = new KiSS4.Gui.KissLabel();
            this.grpErwerbslose = new KiSS4.Gui.KissGroupBox();
            this.lblStellensuche = new KiSS4.Gui.KissLabel();
            this.edtStellensuche = new KiSS4.Gui.KissLookUpEdit();
            this.grpAusbildung = new KiSS4.Gui.KissGroupBox();
            this.lblErlernterBeruf = new KiSS4.Gui.KissLabel();
            this.edtErlernterBeruf = new KiSS4.Gui.KissButtonEdit();
            this.edtHoechsteAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.edtLetzteAbgebrocheneAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.lblLetzteAbgebrAusbildung = new KiSS4.Gui.KissLabel();
            this.lblHoechsteAusbildung = new KiSS4.Gui.KissLabel();
            this.grpErwerbstaetig = new KiSS4.Gui.KissGroupBox();
            this.lblAnstellungsverhaeltnis = new KiSS4.Gui.KissLabel();
            this.edtErwerbssituation = new KiSS4.Gui.KissLookUpEdit();
            this.edtJetzigeTaetigkeit = new KiSS4.Gui.KissButtonEdit();
            this.lblJetzigeTaetigkeit = new KiSS4.Gui.KissLabel();
            this.lblIKAuszugBemerkung = new KiSS4.Gui.KissLabel();
            this.edtIKAuszugJahr = new KiSS4.Gui.KissComboBox();
            this.edtIKAuszug = new KiSS4.Gui.KissCheckEdit();
            this.lblSpezielleFaehigkeiten = new KiSS4.Gui.KissLabel();
            this.memSpezFaehigkeiten = new KiSS4.Gui.KissMemoEdit();
            this.tbpErsatzeinkommen = new SharpLibrary.WinControls.TabPageEx();
            this.ctlBaPersonErsatzeinkommen = new KiSS4.Basis.ZH.CtlBaPersonErsatzeinkommen();
            this.tbpVermoegen = new SharpLibrary.WinControls.TabPageEx();
            this.ctlBaPersonVermoegen = new KiSS4.Basis.ZH.CtlBaPersonVermoegen();
            this.tbpZahlweg = new SharpLibrary.WinControls.TabPageEx();
            this.ctlZahlungsweg = new KiSS4.Basis.ZH.CtlBaZahlungsweg();
            this.tbpWVCode = new SharpLibrary.WinControls.TabPageEx();
            this.ctlWVCode = new KiSS4.Basis.ZH.CtlBaPersonWVCode();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kissLabel108 = new KiSS4.Gui.KissLabel();
            this.edtHeimtortLand = new KiSS4.Gui.KissTextEdit();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.edtInCHseit2 = new KiSS4.Gui.KissDateEdit();
            this.lblInCHseit = new KiSS4.Gui.KissLabel();
            this.datZuzugKantonSeit = new KiSS4.Common.KissBfsDtpSeitGeburt();
            this.lblDatumKanton = new KiSS4.Gui.KissLabel();
            this.edtZuzugKtOrtCode = new KiSS4.Common.KissPLZOrt();
            this.lblLandKanton = new KiSS4.Gui.KissLabel();
            this.lblPlzZuzugKanton = new KiSS4.Gui.KissLabel();
            this.kissLabel109 = new KiSS4.Gui.KissLabel();
            this.datZuzugSeit = new KiSS4.Common.KissBfsDtpSeitGeburt();
            this.lblDatumGemeinde = new KiSS4.Gui.KissLabel();
            this.edtZuzugGdeOrtCode = new KiSS4.Common.KissPLZOrt();
            this.lblLandGemeinde = new KiSS4.Gui.KissLabel();
            this.lblPlzZuzugGemeinde = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.tbpAlteFallNr = new SharpLibrary.WinControls.TabPageEx();
            this.ctlAlteFallNr = new KiSS4.Basis.ZH.CtlBaPersonAlteFallnr();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGesetz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKrankenkasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGesetz1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKrankenkasse1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryPraemienuebernahme = new KiSS4.DB.SqlQuery(this.components);
            this.qryPraemienverbilligung = new KiSS4.DB.SqlQuery(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tabStammdaten.SuspendLayout();
            this.tbpPersonalien.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialraum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSozialRaum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinwohnerregisterAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonOhneLeistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZarNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZarNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantRefNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAuslaenderStatusGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeitGeburt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschVerstehenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschVerstehenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReligion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReligion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWichitgerHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWichitgerHinweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSterbeDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobil2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobil1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            this.tbpAdressen.SuspendLayout();
            this.pnlAdressenBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).BeginInit();
            this.tbpVersicherungen.SuspendLayout();
            this.tbpArbeit.SuspendLayout();
            this.panArbeitTop.SuspendLayout();
            this.grpNichtErwerbstaetig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundNichtErwerbstaetig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundNichtErwerbstaetig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundNichtErwerbstaetig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNEAnmeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNEAnmeldung)).BeginInit();
            this.grpErwerbslose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStellensuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStellensuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStellensuche.Properties)).BeginInit();
            this.grpAusbildung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErlernterBeruf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErlernterBeruf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHoechsteAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHoechsteAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzteAbgebrocheneAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzteAbgebrocheneAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAbgebrAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoechsteAusbildung)).BeginInit();
            this.grpErwerbstaetig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnstellungsverhaeltnis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJetzigeTaetigkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJetzigeTaetigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIKAuszugBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIKAuszugJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIKAuszug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSpezielleFaehigkeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSpezFaehigkeiten.Properties)).BeginInit();
            this.tbpErsatzeinkommen.SuspendLayout();
            this.tbpVermoegen.SuspendLayout();
            this.tbpZahlweg.SuspendLayout();
            this.tbpWVCode.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimtortLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInCHseit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInCHseit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzZuzugKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzZuzugGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            this.tbpAlteFallNr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienuebernahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienverbilligung)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 24);
            this.panel1.TabIndex = 0;
            // 
            // picTitel
            // 
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
            this.lblTitel.Text = "Person";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // tabStammdaten
            // 
            this.tabStammdaten.Controls.Add(this.tbpPersonalien);
            this.tabStammdaten.Controls.Add(this.tbpAdressen);
            this.tabStammdaten.Controls.Add(this.tbpVersicherungen);
            this.tabStammdaten.Controls.Add(this.tbpArbeit);
            this.tabStammdaten.Controls.Add(this.tbpErsatzeinkommen);
            this.tabStammdaten.Controls.Add(this.tbpVermoegen);
            this.tabStammdaten.Controls.Add(this.tbpZahlweg);
            this.tabStammdaten.Controls.Add(this.tbpWVCode);
            this.tabStammdaten.Controls.Add(this.tbpAlteFallNr);
            this.tabStammdaten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStammdaten.Location = new System.Drawing.Point(0, 24);
            this.tabStammdaten.Name = "tabStammdaten";
            this.tabStammdaten.ShowFixedWidthTooltip = true;
            this.tabStammdaten.Size = new System.Drawing.Size(908, 649);
            this.tabStammdaten.TabIndex = 0;
            this.tabStammdaten.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpPersonalien,
            this.tbpAdressen,
            this.tbpVersicherungen,
            this.tbpArbeit,
            this.tbpErsatzeinkommen,
            this.tbpVermoegen,
            this.tbpZahlweg,
            this.tbpWVCode,
            this.tbpAlteFallNr});
            this.tabStammdaten.TabsLineColor = System.Drawing.Color.Black;
            this.tabStammdaten.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabStammdaten.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabStammdaten.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabStammdaten_SelectedTabChanged_1);
            // 
            // tbpPersonalien
            // 
            this.tbpPersonalien.AutoScroll = true;
            this.tbpPersonalien.Controls.Add(this.panel2);
            this.tbpPersonalien.Location = new System.Drawing.Point(6, 32);
            this.tbpPersonalien.Name = "tbpPersonalien";
            this.tbpPersonalien.Size = new System.Drawing.Size(896, 611);
            this.tbpPersonalien.TabIndex = 0;
            this.tbpPersonalien.Title = "Personalien";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.lblSozialraum);
            this.panel2.Controls.Add(this.edtSozialRaum);
            this.panel2.Controls.Add(this.kissLabel12);
            this.panel2.Controls.Add(this.kissLabel5);
            this.panel2.Controls.Add(this.kissLabel48);
            this.panel2.Controls.Add(this.kissLabel35);
            this.panel2.Controls.Add(this.edtEinwohnerregisterAktiv);
            this.panel2.Controls.Add(this.edtPersonOhneLeistung);
            this.panel2.Controls.Add(this.kissLabel9);
            this.panel2.Controls.Add(this.kissLabel104);
            this.panel2.Controls.Add(this.kissLabel103);
            this.panel2.Controls.Add(this.lblZemisNr);
            this.panel2.Controls.Add(this.kissLabel81);
            this.panel2.Controls.Add(this.lblZarNummer);
            this.panel2.Controls.Add(this.lblPID);
            this.panel2.Controls.Add(this.kissLabel39);
            this.panel2.Controls.Add(this.kissLabel23);
            this.panel2.Controls.Add(this.kissLabel22);
            this.panel2.Controls.Add(this.kissLabel20);
            this.panel2.Controls.Add(this.kissLabel19);
            this.panel2.Controls.Add(this.kissLabel18);
            this.panel2.Controls.Add(this.kissLabel16);
            this.panel2.Controls.Add(this.kissLabel15);
            this.panel2.Controls.Add(this.kissLabel13);
            this.panel2.Controls.Add(this.kissLabel11);
            this.panel2.Controls.Add(this.kissLabel8);
            this.panel2.Controls.Add(this.kissLabel7);
            this.panel2.Controls.Add(this.kissLabel4);
            this.panel2.Controls.Add(this.kissLabel3);
            this.panel2.Controls.Add(this.kissLabel2);
            this.panel2.Controls.Add(this.kissLabel1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.edtBaPersonID);
            this.panel2.Controls.Add(this.edtPID);
            this.panel2.Controls.Add(this.btnDatenblatt);
            this.panel2.Controls.Add(this.btnAnonymisieren);
            this.panel2.Controls.Add(this.btnKIS);
            this.panel2.Controls.Add(this.btnSendToPscd);
            this.panel2.Controls.Add(this.btnOmegaImport);
            this.panel2.Controls.Add(this.edtBemerkung);
            this.panel2.Controls.Add(this.edtZarNummer);
            this.panel2.Controls.Add(this.edtKantRefNummer);
            this.panel2.Controls.Add(this.edtZemisNummer);
            this.panel2.Controls.Add(this.dtpAuslaenderStatusGueltigBis);
            this.panel2.Controls.Add(this.cboAuslaenderStatus);
            this.panel2.Controls.Add(this.editInCHSeitGeburt);
            this.panel2.Controls.Add(this.editInCHSeit);
            this.panel2.Controls.Add(this.edtDeutschVerstehenCode);
            this.panel2.Controls.Add(this.edtSprache);
            this.panel2.Controls.Add(this.edtReligion);
            this.panel2.Controls.Add(this.edtHeimatort);
            this.panel2.Controls.Add(this.btnHeimatorte);
            this.panel2.Controls.Add(this.edtNationalitaet);
            this.panel2.Controls.Add(this.cboWichitgerHinweis);
            this.panel2.Controls.Add(this.edtSterbeDatum);
            this.panel2.Controls.Add(this.edtVersichertennummer);
            this.panel2.Controls.Add(this.edtGeburtstag);
            this.panel2.Controls.Add(this.edtAHVNr);
            this.panel2.Controls.Add(this.edtZivilstandSeit);
            this.panel2.Controls.Add(this.edtZivilstand);
            this.panel2.Controls.Add(this.edtGeschlecht);
            this.panel2.Controls.Add(this.edtEmail);
            this.panel2.Controls.Add(this.edtMobil2);
            this.panel2.Controls.Add(this.edtMobil1);
            this.panel2.Controls.Add(this.edtTelG);
            this.panel2.Controls.Add(this.edtTelP);
            this.panel2.Controls.Add(this.edtVorname);
            this.panel2.Controls.Add(this.edtName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(896, 611);
            this.panel2.TabIndex = 0;
            // 
            // lblSozialraum
            // 
            this.lblSozialraum.Location = new System.Drawing.Point(520, 9);
            this.lblSozialraum.Name = "lblSozialraum";
            this.lblSozialraum.Size = new System.Drawing.Size(117, 24);
            this.lblSozialraum.TabIndex = 611;
            this.lblSozialraum.Text = "Sozialraum";
            this.lblSozialraum.UseCompatibleTextRendering = true;
            // 
            // edtSozialRaum
            // 
            this.edtSozialRaum.DataMember = "OrgUnitID";
            this.edtSozialRaum.DataSource = this.qryBaPerson;
            this.edtSozialRaum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSozialRaum.Location = new System.Drawing.Point(643, 10);
            this.edtSozialRaum.LookupSQL = "/*\r\nSELECT OrgUnitID, ItemName\r\nFROM XOrgUnit\r\nWHERE ItemName LIKE isNull({0},\'\')" +
    " + \'%\'\r\n*/\r\n----\r\nSELECT ItemName\r\nFROM XOrgUnit\r\nWHERE OrgUnitID = {0}";
            this.edtSozialRaum.Name = "edtSozialRaum";
            this.edtSozialRaum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSozialRaum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSozialRaum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSozialRaum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSozialRaum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSozialRaum.Properties.Appearance.Options.UseFont = true;
            this.edtSozialRaum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSozialRaum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSozialRaum.Properties.ReadOnly = true;
            this.edtSozialRaum.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSozialRaum.Size = new System.Drawing.Size(132, 24);
            this.edtSozialRaum.TabIndex = 610;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.CanUpdate = true;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = resources.GetString("qryBaPerson.SelectStatement");
            this.qryBaPerson.TableName = "BaPerson";
            this.qryBaPerson.AfterPost += new System.EventHandler(this.qryBaPerson_AfterPost);
            this.qryBaPerson.BeforePost += new System.EventHandler(this.qryBaPerson_BeforePost);
            this.qryBaPerson.PositionChanged += new System.EventHandler(this.qryBaPerson_PositionChanged);
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(344, 222);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(38, 24);
            this.kissLabel12.TabIndex = 609;
            this.kissLabel12.Text = "seit";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(520, 92);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(117, 24);
            this.kissLabel5.TabIndex = 606;
            this.kissLabel5.Text = "Religion";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissLabel48
            // 
            this.kissLabel48.Location = new System.Drawing.Point(5, 123);
            this.kissLabel48.Name = "kissLabel48";
            this.kissLabel48.Size = new System.Drawing.Size(108, 24);
            this.kissLabel48.TabIndex = 602;
            this.kissLabel48.Text = "Telefon mobil 1";
            this.kissLabel48.UseCompatibleTextRendering = true;
            // 
            // kissLabel35
            // 
            this.kissLabel35.Location = new System.Drawing.Point(520, 205);
            this.kissLabel35.Name = "kissLabel35";
            this.kissLabel35.Size = new System.Drawing.Size(117, 24);
            this.kissLabel35.TabIndex = 601;
            this.kissLabel35.Text = "Aufenthaltsstatus";
            this.kissLabel35.UseCompatibleTextRendering = true;
            // 
            // edtEinwohnerregisterAktiv
            // 
            this.edtEinwohnerregisterAktiv.DataMember = "EinwohnerregisterAktiv";
            this.edtEinwohnerregisterAktiv.DataSource = this.qryBaPerson;
            this.edtEinwohnerregisterAktiv.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinwohnerregisterAktiv.Location = new System.Drawing.Point(119, 491);
            this.edtEinwohnerregisterAktiv.Name = "edtEinwohnerregisterAktiv";
            this.edtEinwohnerregisterAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinwohnerregisterAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinwohnerregisterAktiv.Properties.Caption = "Einwohnerregister aktiv";
            this.edtEinwohnerregisterAktiv.Properties.Name = "edtEinwohnerregisterAktiv.Properties";
            this.edtEinwohnerregisterAktiv.Properties.ReadOnly = true;
            this.edtEinwohnerregisterAktiv.Size = new System.Drawing.Size(761, 19);
            this.edtEinwohnerregisterAktiv.TabIndex = 601;
            // 
            // edtPersonOhneLeistung
            // 
            this.edtPersonOhneLeistung.DataMember = "PersonOhneLeistung";
            this.edtPersonOhneLeistung.DataSource = this.qryBaPerson;
            this.edtPersonOhneLeistung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersonOhneLeistung.Location = new System.Drawing.Point(119, 466);
            this.edtPersonOhneLeistung.Name = "edtPersonOhneLeistung";
            this.edtPersonOhneLeistung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersonOhneLeistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonOhneLeistung.Properties.Caption = "Person ohne finanzielle Leistung";
            this.edtPersonOhneLeistung.Properties.Name = "edtEinwohnerregisterAktiv.Properties";
            this.edtPersonOhneLeistung.Properties.ReadOnly = true;
            this.edtPersonOhneLeistung.Size = new System.Drawing.Size(761, 19);
            this.edtPersonOhneLeistung.TabIndex = 600;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(5, 144);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(108, 24);
            this.kissLabel9.TabIndex = 599;
            this.kissLabel9.Text = "Telefon mobil 2";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // kissLabel104
            // 
            this.kissLabel104.Location = new System.Drawing.Point(273, 9);
            this.kissLabel104.Name = "kissLabel104";
            this.kissLabel104.Size = new System.Drawing.Size(78, 24);
            this.kissLabel104.TabIndex = 598;
            this.kissLabel104.Text = "Personen-Nr.";
            this.kissLabel104.UseCompatibleTextRendering = true;
            // 
            // kissLabel103
            // 
            this.kissLabel103.Location = new System.Drawing.Point(520, 304);
            this.kissLabel103.Name = "kissLabel103";
            this.kissLabel103.Size = new System.Drawing.Size(117, 24);
            this.kissLabel103.TabIndex = 595;
            this.kissLabel103.Text = "ZH-Nummer";
            this.kissLabel103.UseCompatibleTextRendering = true;
            // 
            // lblZemisNr
            // 
            this.lblZemisNr.Location = new System.Drawing.Point(520, 258);
            this.lblZemisNr.Name = "lblZemisNr";
            this.lblZemisNr.Size = new System.Drawing.Size(117, 24);
            this.lblZemisNr.TabIndex = 594;
            this.lblZemisNr.Text = "ZEMIS-Nummer";
            this.lblZemisNr.UseCompatibleTextRendering = true;
            // 
            // kissLabel81
            // 
            this.kissLabel81.Location = new System.Drawing.Point(5, 305);
            this.kissLabel81.Name = "kissLabel81";
            this.kissLabel81.Size = new System.Drawing.Size(108, 24);
            this.kissLabel81.TabIndex = 590;
            this.kissLabel81.Text = "Wichtiger Hinweis";
            this.kissLabel81.UseCompatibleTextRendering = true;
            // 
            // lblZarNummer
            // 
            this.lblZarNummer.Location = new System.Drawing.Point(520, 281);
            this.lblZarNummer.Name = "lblZarNummer";
            this.lblZarNummer.Size = new System.Drawing.Size(117, 24);
            this.lblZarNummer.TabIndex = 588;
            this.lblZarNummer.Text = "ZAR-Nummer";
            this.lblZarNummer.UseCompatibleTextRendering = true;
            // 
            // lblPID
            // 
            this.lblPID.Location = new System.Drawing.Point(5, 10);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(108, 24);
            this.lblPID.TabIndex = 581;
            this.lblPID.Text = "PID";
            this.lblPID.UseCompatibleTextRendering = true;
            // 
            // kissLabel39
            // 
            this.kissLabel39.Location = new System.Drawing.Point(5, 276);
            this.kissLabel39.Name = "kissLabel39";
            this.kissLabel39.Size = new System.Drawing.Size(108, 24);
            this.kissLabel39.TabIndex = 579;
            this.kissLabel39.Text = "Versichertennummer";
            this.kissLabel39.UseCompatibleTextRendering = true;
            // 
            // kissLabel23
            // 
            this.kissLabel23.Location = new System.Drawing.Point(344, 252);
            this.kissLabel23.Name = "kissLabel23";
            this.kissLabel23.Size = new System.Drawing.Size(38, 24);
            this.kissLabel23.TabIndex = 426;
            this.kissLabel23.Text = "Geburt";
            this.kissLabel23.UseCompatibleTextRendering = true;
            // 
            // kissLabel22
            // 
            this.kissLabel22.Location = new System.Drawing.Point(344, 275);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(38, 24);
            this.kissLabel22.TabIndex = 425;
            this.kissLabel22.Text = "Tod";
            this.kissLabel22.UseCompatibleTextRendering = true;
            // 
            // kissLabel20
            // 
            this.kissLabel20.Location = new System.Drawing.Point(5, 222);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(108, 24);
            this.kissLabel20.TabIndex = 423;
            this.kissLabel20.Text = "Zivilstand";
            this.kissLabel20.UseCompatibleTextRendering = true;
            // 
            // kissLabel19
            // 
            this.kissLabel19.Location = new System.Drawing.Point(5, 199);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(108, 24);
            this.kissLabel19.TabIndex = 422;
            this.kissLabel19.Text = "Geschlecht";
            this.kissLabel19.UseCompatibleTextRendering = true;
            // 
            // kissLabel18
            // 
            this.kissLabel18.Location = new System.Drawing.Point(520, 145);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(117, 24);
            this.kissLabel18.TabIndex = 421;
            this.kissLabel18.Text = "Deutschkenntnisse";
            this.kissLabel18.UseCompatibleTextRendering = true;
            // 
            // kissLabel16
            // 
            this.kissLabel16.Location = new System.Drawing.Point(5, 252);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(108, 24);
            this.kissLabel16.TabIndex = 419;
            this.kissLabel16.Text = "AHV-Nummer";
            this.kissLabel16.UseCompatibleTextRendering = true;
            // 
            // kissLabel15
            // 
            this.kissLabel15.Location = new System.Drawing.Point(520, 122);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(117, 24);
            this.kissLabel15.TabIndex = 418;
            this.kissLabel15.Text = "Sprache";
            this.kissLabel15.UseCompatibleTextRendering = true;
            // 
            // kissLabel13
            // 
            this.kissLabel13.Location = new System.Drawing.Point(520, 175);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(117, 24);
            this.kissLabel13.TabIndex = 416;
            this.kissLabel13.Text = "in Schweiz seit";
            this.kissLabel13.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(520, 228);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(117, 24);
            this.kissLabel11.TabIndex = 414;
            this.kissLabel11.Text = "Status gültig bis";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Location = new System.Drawing.Point(5, 70);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(108, 24);
            this.kissLabel8.TabIndex = 411;
            this.kissLabel8.Text = "Telefon privat";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(5, 93);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(108, 24);
            this.kissLabel7.TabIndex = 410;
            this.kissLabel7.Text = "Telefon gesch.";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(5, 169);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(108, 24);
            this.kissLabel4.TabIndex = 407;
            this.kissLabel4.Text = "EMail";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(5, 346);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(108, 24);
            this.kissLabel3.TabIndex = 406;
            this.kissLabel3.Text = "Bemerkung";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(520, 39);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(94, 24);
            this.kissLabel2.TabIndex = 405;
            this.kissLabel2.Text = "Nation";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(520, 62);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(94, 24);
            this.kissLabel1.TabIndex = 404;
            this.kissLabel1.Text = "Heimatort";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 24);
            this.label9.TabIndex = 403;
            this.label9.Text = "Name / Vorname";
            this.label9.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBaPerson;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(357, 9);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Name = "kissTextEdit34.Properties";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(132, 24);
            this.edtBaPersonID.TabIndex = 35;
            // 
            // edtPID
            // 
            this.edtPID.DataMember = "EinwohnerregisterIDOhne0er";
            this.edtPID.DataSource = this.qryBaPerson;
            this.edtPID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPID.Location = new System.Drawing.Point(119, 10);
            this.edtPID.Name = "edtPID";
            this.edtPID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPID.Properties.Appearance.Options.UseFont = true;
            this.edtPID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPID.Properties.Name = "edtPID.Properties";
            this.edtPID.Properties.ReadOnly = true;
            this.edtPID.Size = new System.Drawing.Size(132, 24);
            this.edtPID.TabIndex = 34;
            // 
            // btnDatenblatt
            // 
            this.btnDatenblatt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDatenblatt.Context = "BaPersonDatenblatt";
            this.btnDatenblatt.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnDatenblatt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenblatt.Image = ((System.Drawing.Image)(resources.GetObject("btnDatenblatt.Image")));
            this.btnDatenblatt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatenblatt.Location = new System.Drawing.Point(720, 584);
            this.btnDatenblatt.Name = "btnDatenblatt";
            this.btnDatenblatt.Size = new System.Drawing.Size(135, 24);
            this.btnDatenblatt.TabIndex = 33;
            this.btnDatenblatt.Text = "Datenblatt";
            this.btnDatenblatt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatenblatt.UseCompatibleTextRendering = true;
            this.btnDatenblatt.UseVisualStyleBackColor = false;
            // 
            // btnAnonymisieren
            // 
            this.btnAnonymisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnonymisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnonymisieren.Location = new System.Drawing.Point(579, 584);
            this.btnAnonymisieren.Name = "btnAnonymisieren";
            this.btnAnonymisieren.Size = new System.Drawing.Size(135, 24);
            this.btnAnonymisieren.TabIndex = 32;
            this.btnAnonymisieren.Text = "anonymisieren";
            this.btnAnonymisieren.UseCompatibleTextRendering = true;
            this.btnAnonymisieren.UseVisualStyleBackColor = false;
            this.btnAnonymisieren.Click += new System.EventHandler(this.btnAnonymisieren_Click);
            // 
            // btnKIS
            // 
            this.btnKIS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKIS.BackColor = System.Drawing.Color.Bisque;
            this.btnKIS.ButtonStyle = KiSS4.Gui.ButtonStyleType.Custom;
            this.btnKIS.Context = null;
            this.btnKIS.Enabled = false;
            this.btnKIS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnKIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKIS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel);
            this.btnKIS.ForeColor = System.Drawing.Color.Black;
            this.btnKIS.Location = new System.Drawing.Point(438, 584);
            this.btnKIS.Name = "btnKIS";
            this.btnKIS.Size = new System.Drawing.Size(135, 24);
            this.btnKIS.TabIndex = 31;
            this.btnKIS.Text = "KIS";
            this.btnKIS.URL = "http://www.kis.integ.sd.stzh.ch";
            this.btnKIS.UseCompatibleTextRendering = true;
            this.btnKIS.UseVisualStyleBackColor = true;
            // 
            // btnSendToPscd
            // 
            this.btnSendToPscd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendToPscd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToPscd.Location = new System.Drawing.Point(156, 584);
            this.btnSendToPscd.Name = "btnSendToPscd";
            this.btnSendToPscd.Size = new System.Drawing.Size(135, 24);
            this.btnSendToPscd.TabIndex = 30;
            this.btnSendToPscd.Text = "An PSCD senden";
            this.btnSendToPscd.UseCompatibleTextRendering = true;
            this.btnSendToPscd.UseVisualStyleBackColor = false;
            this.btnSendToPscd.Click += new System.EventHandler(this.btnSendToPscd_Click);
            // 
            // btnOmegaImport
            // 
            this.btnOmegaImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOmegaImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOmegaImport.Location = new System.Drawing.Point(297, 584);
            this.btnOmegaImport.Name = "btnOmegaImport";
            this.btnOmegaImport.Size = new System.Drawing.Size(135, 24);
            this.btnOmegaImport.TabIndex = 30;
            this.btnOmegaImport.Text = "Omega-Import";
            this.btnOmegaImport.UseCompatibleTextRendering = true;
            this.btnOmegaImport.UseVisualStyleBackColor = false;
            this.btnOmegaImport.Click += new System.EventHandler(this.btnOmegaImport_Click);
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBaPerson;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(119, 346);
            this.edtBemerkung.MaxLength = 300;
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(761, 114);
            this.edtBemerkung.TabIndex = 29;
            // 
            // edtZarNummer
            // 
            this.edtZarNummer.DataMember = "ZARNummer";
            this.edtZarNummer.DataSource = this.qryBaPerson;
            this.edtZarNummer.Location = new System.Drawing.Point(643, 282);
            this.edtZarNummer.Name = "edtZarNummer";
            this.edtZarNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZarNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZarNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZarNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtZarNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZarNummer.Properties.Appearance.Options.UseFont = true;
            this.edtZarNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZarNummer.Properties.MaxLength = 20;
            this.edtZarNummer.Properties.Name = "kissTextEdit12.Properties";
            this.edtZarNummer.Size = new System.Drawing.Size(237, 24);
            this.edtZarNummer.TabIndex = 28;
            // 
            // edtKantRefNummer
            // 
            this.edtKantRefNummer.DataMember = "KantonaleReferenznummer";
            this.edtKantRefNummer.DataSource = this.qryBaPerson;
            this.edtKantRefNummer.Location = new System.Drawing.Point(643, 305);
            this.edtKantRefNummer.Name = "edtKantRefNummer";
            this.edtKantRefNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKantRefNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKantRefNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKantRefNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtKantRefNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKantRefNummer.Properties.Appearance.Options.UseFont = true;
            this.edtKantRefNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKantRefNummer.Properties.MaxLength = 50;
            this.edtKantRefNummer.Properties.Name = "kissTextEdit3.Properties";
            this.edtKantRefNummer.Size = new System.Drawing.Size(237, 24);
            this.edtKantRefNummer.TabIndex = 27;
            // 
            // edtZemisNummer
            // 
            this.edtZemisNummer.DataMember = "ZEMISNummer";
            this.edtZemisNummer.DataSource = this.qryBaPerson;
            this.edtZemisNummer.Location = new System.Drawing.Point(643, 259);
            this.edtZemisNummer.Name = "edtZemisNummer";
            this.edtZemisNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZemisNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZemisNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZemisNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtZemisNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZemisNummer.Properties.Appearance.Options.UseFont = true;
            this.edtZemisNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZemisNummer.Properties.MaxLength = 20;
            this.edtZemisNummer.Properties.Name = "kissTextEdit4.Properties";
            this.edtZemisNummer.Size = new System.Drawing.Size(237, 24);
            this.edtZemisNummer.TabIndex = 26;
            // 
            // dtpAuslaenderStatusGueltigBis
            // 
            this.dtpAuslaenderStatusGueltigBis.DataMember = "AuslaenderStatusGueltigBis";
            this.dtpAuslaenderStatusGueltigBis.DataSource = this.qryBaPerson;
            this.dtpAuslaenderStatusGueltigBis.EditValue = null;
            this.dtpAuslaenderStatusGueltigBis.Location = new System.Drawing.Point(643, 229);
            this.dtpAuslaenderStatusGueltigBis.Name = "dtpAuslaenderStatusGueltigBis";
            this.dtpAuslaenderStatusGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpAuslaenderStatusGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.dtpAuslaenderStatusGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpAuslaenderStatusGueltigBis.Properties.Name = "dtpAuslaenderStatusGueltigBis.Properties";
            this.dtpAuslaenderStatusGueltigBis.Properties.ShowToday = false;
            this.dtpAuslaenderStatusGueltigBis.Size = new System.Drawing.Size(104, 24);
            this.dtpAuslaenderStatusGueltigBis.TabIndex = 25;
            // 
            // cboAuslaenderStatus
            // 
            this.cboAuslaenderStatus.DataMember = "AuslaenderStatusCode";
            this.cboAuslaenderStatus.DataSource = this.qryBaPerson;
            this.cboAuslaenderStatus.Location = new System.Drawing.Point(643, 206);
            this.cboAuslaenderStatus.LOVName = "BaAufenthaltsstatus";
            this.cboAuslaenderStatus.Name = "cboAuslaenderStatus";
            this.cboAuslaenderStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboAuslaenderStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboAuslaenderStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAuslaenderStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboAuslaenderStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.cboAuslaenderStatus.Properties.Appearance.Options.UseFont = true;
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAuslaenderStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.cboAuslaenderStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.cboAuslaenderStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboAuslaenderStatus.Properties.Name = "cboAuslaenderStatus.Properties";
            this.cboAuslaenderStatus.Properties.NullText = "";
            this.cboAuslaenderStatus.Properties.ShowFooter = false;
            this.cboAuslaenderStatus.Properties.ShowHeader = false;
            this.cboAuslaenderStatus.Size = new System.Drawing.Size(237, 24);
            this.cboAuslaenderStatus.TabIndex = 24;
            // 
            // editInCHSeitGeburt
            // 
            this.editInCHSeitGeburt.DataMember = "InCHSeitGeburt";
            this.editInCHSeitGeburt.DataSource = this.qryBaPerson;
            this.editInCHSeitGeburt.Location = new System.Drawing.Point(738, 207);
            this.editInCHSeitGeburt.Name = "editInCHSeitGeburt";
            this.editInCHSeitGeburt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editInCHSeitGeburt.Properties.Appearance.Options.UseBackColor = true;
            this.editInCHSeitGeburt.Properties.Caption = "seit Geburt";
            this.editInCHSeitGeburt.Properties.Name = "editInCHSeitGeburt.Properties";
            this.editInCHSeitGeburt.Size = new System.Drawing.Size(80, 19);
            this.editInCHSeitGeburt.TabIndex = 23;
            this.editInCHSeitGeburt.EditValueChanged += new System.EventHandler(this.editInCHSeitGeburt_EditValueChanged);
            // 
            // editInCHSeit
            // 
            this.editInCHSeit.DataMember = "InCHSeit";
            this.editInCHSeit.DataSource = this.qryBaPerson;
            this.editInCHSeit.EditValue = null;
            this.editInCHSeit.Location = new System.Drawing.Point(643, 176);
            this.editInCHSeit.Name = "editInCHSeit";
            this.editInCHSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editInCHSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editInCHSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editInCHSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editInCHSeit.Properties.Appearance.Options.UseBackColor = true;
            this.editInCHSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.editInCHSeit.Properties.Appearance.Options.UseFont = true;
            this.editInCHSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editInCHSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editInCHSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editInCHSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editInCHSeit.Properties.Name = "editInCHSeit.Properties";
            this.editInCHSeit.Properties.ShowToday = false;
            this.editInCHSeit.Size = new System.Drawing.Size(104, 24);
            this.editInCHSeit.TabIndex = 22;
            // 
            // edtDeutschVerstehenCode
            // 
            this.edtDeutschVerstehenCode.DataMember = "DeutschVerstehenCode";
            this.edtDeutschVerstehenCode.DataSource = this.qryBaPerson;
            this.edtDeutschVerstehenCode.Location = new System.Drawing.Point(643, 146);
            this.edtDeutschVerstehenCode.LOVName = "BaDeutschkenntnis";
            this.edtDeutschVerstehenCode.Name = "edtDeutschVerstehenCode";
            this.edtDeutschVerstehenCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDeutschVerstehenCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDeutschVerstehenCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschVerstehenCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtDeutschVerstehenCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDeutschVerstehenCode.Properties.Appearance.Options.UseFont = true;
            this.edtDeutschVerstehenCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDeutschVerstehenCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschVerstehenCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDeutschVerstehenCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDeutschVerstehenCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDeutschVerstehenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDeutschVerstehenCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschVerstehenCode.Properties.Name = "edtDeutschVerstehenCode.Properties";
            this.edtDeutschVerstehenCode.Properties.NullText = "";
            this.edtDeutschVerstehenCode.Properties.ShowFooter = false;
            this.edtDeutschVerstehenCode.Properties.ShowHeader = false;
            this.edtDeutschVerstehenCode.Size = new System.Drawing.Size(237, 24);
            this.edtDeutschVerstehenCode.TabIndex = 21;
            // 
            // edtSprache
            // 
            this.edtSprache.DataMember = "SprachCode";
            this.edtSprache.DataSource = this.qryBaPerson;
            this.edtSprache.Location = new System.Drawing.Point(643, 123);
            this.edtSprache.LOVName = "BaPersonSprache";
            this.edtSprache.Name = "edtSprache";
            this.edtSprache.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSprache.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSprache.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprache.Properties.Appearance.Options.UseBackColor = true;
            this.edtSprache.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSprache.Properties.Appearance.Options.UseFont = true;
            this.edtSprache.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSprache.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprache.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSprache.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSprache.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSprache.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSprache.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSprache.Properties.Name = "kissLookUpEdit2.Properties";
            this.edtSprache.Properties.NullText = "";
            this.edtSprache.Properties.ShowFooter = false;
            this.edtSprache.Properties.ShowHeader = false;
            this.edtSprache.Size = new System.Drawing.Size(237, 24);
            this.edtSprache.TabIndex = 20;
            // 
            // edtReligion
            // 
            this.edtReligion.DataMember = "ReligionCode";
            this.edtReligion.DataSource = this.qryBaPerson;
            this.edtReligion.Location = new System.Drawing.Point(643, 93);
            this.edtReligion.LOVName = "BaReligion";
            this.edtReligion.Name = "edtReligion";
            this.edtReligion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReligion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReligion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReligion.Properties.Appearance.Options.UseBackColor = true;
            this.edtReligion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReligion.Properties.Appearance.Options.UseFont = true;
            this.edtReligion.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtReligion.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtReligion.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtReligion.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtReligion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtReligion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtReligion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReligion.Properties.Name = "cboAuslaenderStatus.Properties";
            this.edtReligion.Properties.NullText = "";
            this.edtReligion.Properties.ShowFooter = false;
            this.edtReligion.Properties.ShowHeader = false;
            this.edtReligion.Size = new System.Drawing.Size(237, 24);
            this.edtReligion.TabIndex = 19;
            // 
            // edtHeimatort
            // 
            this.edtHeimatort.DataMember = "Heimatort";
            this.edtHeimatort.DataSource = this.qryBaPerson;
            this.edtHeimatort.Location = new System.Drawing.Point(643, 63);
            this.edtHeimatort.Name = "edtHeimatort";
            this.edtHeimatort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeimatort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatort.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtHeimatort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtHeimatort.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHeimatort.Properties.Name = "editHeimatort.Properties";
            this.edtHeimatort.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtHeimatort.Size = new System.Drawing.Size(237, 24);
            this.edtHeimatort.TabIndex = 18;
            this.edtHeimatort.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtHeimatort_UserModifiedFld);
            // 
            // btnHeimatorte
            // 
            this.btnHeimatorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeimatorte.Image = ((System.Drawing.Image)(resources.GetObject("btnHeimatorte.Image")));
            this.btnHeimatorte.Location = new System.Drawing.Point(620, 63);
            this.btnHeimatorte.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnHeimatorte.Name = "btnHeimatorte";
            this.btnHeimatorte.Size = new System.Drawing.Size(20, 24);
            this.btnHeimatorte.TabIndex = 17;
            this.btnHeimatorte.UseCompatibleTextRendering = true;
            this.btnHeimatorte.UseVisualStyleBackColor = false;
            this.btnHeimatorte.Click += new System.EventHandler(this.btnHeimatorte_Click);
            // 
            // edtNationalitaet
            // 
            this.edtNationalitaet.DataMember = "NationalitaetCode";
            this.edtNationalitaet.DataSource = this.qryBaPerson;
            this.edtNationalitaet.Location = new System.Drawing.Point(643, 40);
            this.edtNationalitaet.LOVName = "BaLand";
            this.edtNationalitaet.Name = "edtNationalitaet";
            this.edtNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaet.Properties.Name = "cboNationalitaet.Properties";
            this.edtNationalitaet.Properties.NullText = "";
            this.edtNationalitaet.Properties.ShowFooter = false;
            this.edtNationalitaet.Properties.ShowHeader = false;
            this.edtNationalitaet.Size = new System.Drawing.Size(237, 24);
            this.edtNationalitaet.TabIndex = 16;
            this.edtNationalitaet.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.cboNationalitaet_CloseUp);
            // 
            // cboWichitgerHinweis
            // 
            this.cboWichitgerHinweis.DataMember = "WichtigerHinweisCode";
            this.cboWichitgerHinweis.DataSource = this.qryBaPerson;
            this.cboWichitgerHinweis.Location = new System.Drawing.Point(119, 305);
            this.cboWichitgerHinweis.LOVName = "BaPersonWichtigerHinweis";
            this.cboWichitgerHinweis.Name = "cboWichitgerHinweis";
            this.cboWichitgerHinweis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboWichitgerHinweis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboWichitgerHinweis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboWichitgerHinweis.Properties.Appearance.Options.UseBackColor = true;
            this.cboWichitgerHinweis.Properties.Appearance.Options.UseBorderColor = true;
            this.cboWichitgerHinweis.Properties.Appearance.Options.UseFont = true;
            this.cboWichitgerHinweis.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboWichitgerHinweis.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboWichitgerHinweis.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboWichitgerHinweis.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboWichitgerHinweis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.cboWichitgerHinweis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.cboWichitgerHinweis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboWichitgerHinweis.Properties.Name = "kissLookUpEdit8.Properties";
            this.cboWichitgerHinweis.Properties.NullText = "";
            this.cboWichitgerHinweis.Properties.ShowFooter = false;
            this.cboWichitgerHinweis.Properties.ShowHeader = false;
            this.cboWichitgerHinweis.Size = new System.Drawing.Size(212, 24);
            this.cboWichitgerHinweis.TabIndex = 15;
            // 
            // edtSterbeDatum
            // 
            this.edtSterbeDatum.DataMember = "Sterbedatum";
            this.edtSterbeDatum.DataSource = this.qryBaPerson;
            this.edtSterbeDatum.EditValue = null;
            this.edtSterbeDatum.Location = new System.Drawing.Point(385, 275);
            this.edtSterbeDatum.Name = "edtSterbeDatum";
            this.edtSterbeDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSterbeDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSterbeDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSterbeDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSterbeDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSterbeDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSterbeDatum.Properties.Appearance.Options.UseFont = true;
            this.edtSterbeDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSterbeDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSterbeDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSterbeDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSterbeDatum.Properties.Name = "dtpSterbeDatum.Properties";
            this.edtSterbeDatum.Properties.ShowToday = false;
            this.edtSterbeDatum.Size = new System.Drawing.Size(104, 24);
            this.edtSterbeDatum.TabIndex = 14;
            // 
            // edtVersichertennummer
            // 
            this.edtVersichertennummer.DataMember = "Versichertennummer";
            this.edtVersichertennummer.DataSource = this.qryBaPerson;
            this.edtVersichertennummer.Location = new System.Drawing.Point(119, 275);
            this.edtVersichertennummer.Name = "edtVersichertennummer";
            this.edtVersichertennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersichertennummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersichertennummer.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersichertennummer.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersichertennummer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersichertennummer.Properties.MaxLength = 18;
            this.edtVersichertennummer.Properties.Name = "dtpVersichertennummer.Properties";
            this.edtVersichertennummer.Properties.Precision = 0;
            this.edtVersichertennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersichertennummer.Size = new System.Drawing.Size(212, 24);
            this.edtVersichertennummer.TabIndex = 13;
            // 
            // edtGeburtstag
            // 
            this.edtGeburtstag.DataMember = "Geburtsdatum";
            this.edtGeburtstag.DataSource = this.qryBaPerson;
            this.edtGeburtstag.EditValue = null;
            this.edtGeburtstag.Location = new System.Drawing.Point(385, 252);
            this.edtGeburtstag.Name = "edtGeburtstag";
            this.edtGeburtstag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtstag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtstag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtstag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtstag.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtstag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtstag.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtstag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtGeburtstag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtstag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtGeburtstag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtstag.Properties.Name = "dtpGeburtstag.Properties";
            this.edtGeburtstag.Properties.ShowToday = false;
            this.edtGeburtstag.Size = new System.Drawing.Size(104, 24);
            this.edtGeburtstag.TabIndex = 12;
            // 
            // edtAHVNr
            // 
            this.edtAHVNr.DataMember = "AHVNummer";
            this.edtAHVNr.DataSource = this.qryBaPerson;
            this.edtAHVNr.Location = new System.Drawing.Point(119, 252);
            this.edtAHVNr.Name = "edtAHVNr";
            this.edtAHVNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNr.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNr.Properties.MaxLength = 16;
            this.edtAHVNr.Properties.Name = "editAHVNr.Properties";
            this.edtAHVNr.Size = new System.Drawing.Size(212, 24);
            this.edtAHVNr.TabIndex = 11;
            // 
            // edtZivilstandSeit
            // 
            this.edtZivilstandSeit.DataMember = "ZivilstandDatum";
            this.edtZivilstandSeit.DataSource = this.qryBaPerson;
            this.edtZivilstandSeit.EditValue = null;
            this.edtZivilstandSeit.Location = new System.Drawing.Point(385, 222);
            this.edtZivilstandSeit.Name = "edtZivilstandSeit";
            this.edtZivilstandSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZivilstandSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZivilstandSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandSeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandSeit.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtZivilstandSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZivilstandSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtZivilstandSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZivilstandSeit.Properties.Name = "dtpGeburtstag.Properties";
            this.edtZivilstandSeit.Properties.ShowToday = false;
            this.edtZivilstandSeit.Size = new System.Drawing.Size(104, 24);
            this.edtZivilstandSeit.TabIndex = 10;
            // 
            // edtZivilstand
            // 
            this.edtZivilstand.DataMember = "ZivilstandCode";
            this.edtZivilstand.DataSource = this.qryBaPerson;
            this.edtZivilstand.Location = new System.Drawing.Point(119, 222);
            this.edtZivilstand.LOVName = "BaZivilstand";
            this.edtZivilstand.Name = "edtZivilstand";
            this.edtZivilstand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZivilstand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstand.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstand.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZivilstand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZivilstand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZivilstand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtZivilstand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtZivilstand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZivilstand.Properties.Name = "cboZivilstand.Properties";
            this.edtZivilstand.Properties.NullText = "";
            this.edtZivilstand.Properties.ShowFooter = false;
            this.edtZivilstand.Properties.ShowHeader = false;
            this.edtZivilstand.Size = new System.Drawing.Size(212, 24);
            this.edtZivilstand.TabIndex = 9;
            // 
            // edtGeschlecht
            // 
            this.edtGeschlecht.DataMember = "GeschlechtCode";
            this.edtGeschlecht.DataSource = this.qryBaPerson;
            this.edtGeschlecht.Location = new System.Drawing.Point(119, 199);
            this.edtGeschlecht.LOVName = "BaGeschlecht";
            this.edtGeschlecht.Name = "edtGeschlecht";
            this.edtGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlecht.Properties.Name = "cboGeschlecht.Properties";
            this.edtGeschlecht.Properties.NullText = "";
            this.edtGeschlecht.Properties.ShowFooter = false;
            this.edtGeschlecht.Properties.ShowHeader = false;
            this.edtGeschlecht.Size = new System.Drawing.Size(212, 24);
            this.edtGeschlecht.TabIndex = 8;
            // 
            // edtEmail
            // 
            this.edtEmail.DataMember = "EMail";
            this.edtEmail.DataSource = this.qryBaPerson;
            this.edtEmail.Location = new System.Drawing.Point(119, 169);
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmail.Properties.Appearance.Options.UseFont = true;
            this.edtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmail.Properties.MaxLength = 100;
            this.edtEmail.Properties.Name = "kissTextEdit8.Properties";
            this.edtEmail.Size = new System.Drawing.Size(370, 24);
            this.edtEmail.TabIndex = 7;
            // 
            // edtMobil2
            // 
            this.edtMobil2.DataMember = "MobilTel2";
            this.edtMobil2.DataSource = this.qryBaPerson;
            this.edtMobil2.Location = new System.Drawing.Point(119, 146);
            this.edtMobil2.Name = "edtMobil2";
            this.edtMobil2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMobil2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMobil2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMobil2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMobil2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMobil2.Properties.Appearance.Options.UseFont = true;
            this.edtMobil2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMobil2.Properties.MaxLength = 45;
            this.edtMobil2.Properties.Name = "kissTextEdit7.Properties";
            this.edtMobil2.Size = new System.Drawing.Size(370, 24);
            this.edtMobil2.TabIndex = 6;
            // 
            // edtMobil1
            // 
            this.edtMobil1.DataMember = "MobilTel1";
            this.edtMobil1.DataSource = this.qryBaPerson;
            this.edtMobil1.Location = new System.Drawing.Point(119, 123);
            this.edtMobil1.Name = "edtMobil1";
            this.edtMobil1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMobil1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMobil1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMobil1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMobil1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMobil1.Properties.Appearance.Options.UseFont = true;
            this.edtMobil1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMobil1.Properties.MaxLength = 45;
            this.edtMobil1.Properties.Name = "kissTextEdit9.Properties";
            this.edtMobil1.Size = new System.Drawing.Size(370, 24);
            this.edtMobil1.TabIndex = 5;
            // 
            // edtTelG
            // 
            this.edtTelG.DataMember = "Telefon_G";
            this.edtTelG.DataSource = this.qryBaPerson;
            this.edtTelG.Location = new System.Drawing.Point(119, 93);
            this.edtTelG.Name = "edtTelG";
            this.edtTelG.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelG.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelG.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelG.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelG.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelG.Properties.Appearance.Options.UseFont = true;
            this.edtTelG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelG.Properties.MaxLength = 45;
            this.edtTelG.Properties.Name = "kissTextEdit6.Properties";
            this.edtTelG.Size = new System.Drawing.Size(370, 24);
            this.edtTelG.TabIndex = 4;
            // 
            // edtTelP
            // 
            this.edtTelP.DataMember = "Telefon_P";
            this.edtTelP.DataSource = this.qryBaPerson;
            this.edtTelP.Location = new System.Drawing.Point(119, 70);
            this.edtTelP.Name = "edtTelP";
            this.edtTelP.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelP.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelP.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelP.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelP.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelP.Properties.Appearance.Options.UseFont = true;
            this.edtTelP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelP.Properties.MaxLength = 45;
            this.edtTelP.Properties.Name = "kissTextEdit5.Properties";
            this.edtTelP.Size = new System.Drawing.Size(370, 24);
            this.edtTelP.TabIndex = 3;
            // 
            // edtVorname
            // 
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryBaPerson;
            this.edtVorname.Location = new System.Drawing.Point(329, 40);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Properties.MaxLength = 100;
            this.edtVorname.Size = new System.Drawing.Size(160, 24);
            this.edtVorname.TabIndex = 2;
            // 
            // edtName
            // 
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBaPerson;
            this.edtName.Location = new System.Drawing.Point(119, 40);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.MaxLength = 100;
            this.edtName.Properties.Name = "editName.Properties";
            this.edtName.Size = new System.Drawing.Size(212, 24);
            this.edtName.TabIndex = 1;
            // 
            // tbpAdressen
            // 
            this.tbpAdressen.AutoScroll = true;
            this.tbpAdressen.Controls.Add(this.ctlAdressen);
            this.tbpAdressen.Controls.Add(this.pnlAdressenBottom);
            this.tbpAdressen.Location = new System.Drawing.Point(6, 32);
            this.tbpAdressen.Name = "tbpAdressen";
            this.tbpAdressen.Size = new System.Drawing.Size(896, 611);
            this.tbpAdressen.TabIndex = 1;
            this.tbpAdressen.Title = "Adressen";
            // 
            // ctlAdressen
            // 
            this.ctlAdressen.AutoScroll = true;
            this.ctlAdressen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlAdressen.BaPersonID = 1;
            this.ctlAdressen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlAdressen.Location = new System.Drawing.Point(0, 0);
            this.ctlAdressen.Name = "ctlAdressen";
            this.ctlAdressen.Size = new System.Drawing.Size(896, 558);
            this.ctlAdressen.TabIndex = 1;
            // 
            // pnlAdressenBottom
            // 
            this.pnlAdressenBottom.Controls.Add(this.kissLabel75);
            this.pnlAdressenBottom.Controls.Add(this.kissLabel73);
            this.pnlAdressenBottom.Controls.Add(this.kissLabel72);
            this.pnlAdressenBottom.Controls.Add(this.edtWegzugDatum);
            this.pnlAdressenBottom.Controls.Add(this.edtWegzugLand);
            this.pnlAdressenBottom.Controls.Add(this.edtWegzugKanton);
            this.pnlAdressenBottom.Controls.Add(this.edtWegzugOrt);
            this.pnlAdressenBottom.Controls.Add(this.edtWegzugPLZ);
            this.pnlAdressenBottom.Controls.Add(this.kissLabel33);
            this.pnlAdressenBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAdressenBottom.Location = new System.Drawing.Point(0, 558);
            this.pnlAdressenBottom.Name = "pnlAdressenBottom";
            this.pnlAdressenBottom.Size = new System.Drawing.Size(896, 53);
            this.pnlAdressenBottom.TabIndex = 0;
            // 
            // kissLabel75
            // 
            this.kissLabel75.Location = new System.Drawing.Point(551, 17);
            this.kissLabel75.Name = "kissLabel75";
            this.kissLabel75.Size = new System.Drawing.Size(44, 24);
            this.kissLabel75.TabIndex = 74;
            this.kissLabel75.Text = "Datum";
            this.kissLabel75.UseCompatibleTextRendering = true;
            // 
            // kissLabel73
            // 
            this.kissLabel73.Location = new System.Drawing.Point(348, 17);
            this.kissLabel73.Name = "kissLabel73";
            this.kissLabel73.Size = new System.Drawing.Size(36, 24);
            this.kissLabel73.TabIndex = 73;
            this.kissLabel73.Text = "Land";
            this.kissLabel73.UseCompatibleTextRendering = true;
            // 
            // kissLabel72
            // 
            this.kissLabel72.Location = new System.Drawing.Point(10, 17);
            this.kissLabel72.Name = "kissLabel72";
            this.kissLabel72.Size = new System.Drawing.Size(67, 24);
            this.kissLabel72.TabIndex = 72;
            this.kissLabel72.Text = "PLZ/Ort/Kt";
            this.kissLabel72.UseCompatibleTextRendering = true;
            // 
            // edtWegzugDatum
            // 
            this.edtWegzugDatum.DataMember = "WegzugDatum";
            this.edtWegzugDatum.DataSource = this.qryBaPerson;
            this.edtWegzugDatum.EditValue = null;
            this.edtWegzugDatum.Location = new System.Drawing.Point(597, 17);
            this.edtWegzugDatum.Name = "edtWegzugDatum";
            this.edtWegzugDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWegzugDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWegzugDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWegzugDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWegzugDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtWegzugDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWegzugDatum.Properties.Appearance.Options.UseFont = true;
            this.edtWegzugDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtWegzugDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtWegzugDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtWegzugDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWegzugDatum.Properties.Name = "kissDateEdit7.Properties";
            this.edtWegzugDatum.Properties.ShowToday = false;
            this.edtWegzugDatum.Size = new System.Drawing.Size(93, 24);
            this.edtWegzugDatum.TabIndex = 6;
            // 
            // edtWegzugLand
            // 
            this.edtWegzugLand.DataMember = "WegzugLandCode";
            this.edtWegzugLand.DataSource = this.qryBaPerson;
            this.edtWegzugLand.Location = new System.Drawing.Point(386, 17);
            this.edtWegzugLand.LOVName = "BaLand";
            this.edtWegzugLand.Name = "edtWegzugLand";
            this.edtWegzugLand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWegzugLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWegzugLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWegzugLand.Properties.Appearance.Options.UseBackColor = true;
            this.edtWegzugLand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWegzugLand.Properties.Appearance.Options.UseFont = true;
            this.edtWegzugLand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWegzugLand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWegzugLand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWegzugLand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWegzugLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtWegzugLand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtWegzugLand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWegzugLand.Properties.Name = "kissLookUpEdit13.Properties";
            this.edtWegzugLand.Properties.NullText = "";
            this.edtWegzugLand.Properties.ShowFooter = false;
            this.edtWegzugLand.Properties.ShowHeader = false;
            this.edtWegzugLand.Size = new System.Drawing.Size(159, 24);
            this.edtWegzugLand.TabIndex = 5;
            // 
            // edtWegzugKanton
            // 
            this.edtWegzugKanton.DataMember = "WegzugKanton";
            this.edtWegzugKanton.DataSource = this.qryBaPerson;
            this.edtWegzugKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWegzugKanton.Location = new System.Drawing.Point(307, 17);
            this.edtWegzugKanton.Name = "edtWegzugKanton";
            this.edtWegzugKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWegzugKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWegzugKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWegzugKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtWegzugKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWegzugKanton.Properties.Appearance.Options.UseFont = true;
            this.edtWegzugKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWegzugKanton.Properties.Name = "editKantonWegzug.Properties";
            this.edtWegzugKanton.Properties.ReadOnly = true;
            this.edtWegzugKanton.Size = new System.Drawing.Size(31, 24);
            this.edtWegzugKanton.TabIndex = 3;
            // 
            // edtWegzugOrt
            // 
            this.edtWegzugOrt.DataMember = "WegzugOrt";
            this.edtWegzugOrt.DataSource = this.qryBaPerson;
            this.edtWegzugOrt.Location = new System.Drawing.Point(127, 17);
            this.edtWegzugOrt.Name = "edtWegzugOrt";
            this.edtWegzugOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWegzugOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWegzugOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWegzugOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtWegzugOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWegzugOrt.Properties.Appearance.Options.UseFont = true;
            this.edtWegzugOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWegzugOrt.Properties.MaxLength = 50;
            this.edtWegzugOrt.Properties.Name = "editOrtWegzug.Properties";
            this.edtWegzugOrt.Size = new System.Drawing.Size(182, 24);
            this.edtWegzugOrt.TabIndex = 2;
            this.edtWegzugOrt.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtWegzug_UserModifiedFld);
            // 
            // edtWegzugPLZ
            // 
            this.edtWegzugPLZ.DataMember = "WegzugPLZ";
            this.edtWegzugPLZ.DataSource = this.qryBaPerson;
            this.edtWegzugPLZ.Location = new System.Drawing.Point(85, 17);
            this.edtWegzugPLZ.Name = "edtWegzugPLZ";
            this.edtWegzugPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWegzugPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWegzugPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWegzugPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtWegzugPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWegzugPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtWegzugPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWegzugPLZ.Properties.MaxLength = 10;
            this.edtWegzugPLZ.Properties.Name = "editPLZWegzug.Properties";
            this.edtWegzugPLZ.Size = new System.Drawing.Size(43, 24);
            this.edtWegzugPLZ.TabIndex = 1;
            this.edtWegzugPLZ.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtWegzug_UserModifiedFld);
            // 
            // kissLabel33
            // 
            this.kissLabel33.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel33.Location = new System.Drawing.Point(10, 1);
            this.kissLabel33.Name = "kissLabel33";
            this.kissLabel33.Size = new System.Drawing.Size(79, 16);
            this.kissLabel33.TabIndex = 0;
            this.kissLabel33.Text = "Wegzug";
            this.kissLabel33.UseCompatibleTextRendering = true;
            // 
            // tbpVersicherungen
            // 
            this.tbpVersicherungen.AutoScroll = true;
            this.tbpVersicherungen.Controls.Add(this.ctlKrankenversicherung);
            this.tbpVersicherungen.Location = new System.Drawing.Point(6, 32);
            this.tbpVersicherungen.Name = "tbpVersicherungen";
            this.tbpVersicherungen.Size = new System.Drawing.Size(896, 611);
            this.tbpVersicherungen.TabIndex = 2;
            this.tbpVersicherungen.Title = "Krankenkasse";
            // 
            // ctlKrankenversicherung
            // 
            this.ctlKrankenversicherung.AutoScroll = true;
            this.ctlKrankenversicherung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlKrankenversicherung.BaPersonID = 1;
            this.ctlKrankenversicherung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlKrankenversicherung.Location = new System.Drawing.Point(0, 0);
            this.ctlKrankenversicherung.Name = "ctlKrankenversicherung";
            this.ctlKrankenversicherung.Size = new System.Drawing.Size(896, 611);
            this.ctlKrankenversicherung.TabIndex = 0;
            // 
            // tbpArbeit
            // 
            this.tbpArbeit.AutoScroll = true;
            this.tbpArbeit.Controls.Add(this.ctlArbeit);
            this.tbpArbeit.Controls.Add(this.panArbeitTop);
            this.tbpArbeit.Location = new System.Drawing.Point(6, 32);
            this.tbpArbeit.Name = "tbpArbeit";
            this.tbpArbeit.Size = new System.Drawing.Size(896, 611);
            this.tbpArbeit.TabIndex = 3;
            this.tbpArbeit.Title = "Arbeit";
            // 
            // ctlArbeit
            // 
            this.ctlArbeit.AutoScroll = true;
            this.ctlArbeit.AutoScrollMinSize = new System.Drawing.Size(706, 287);
            this.ctlArbeit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlArbeit.BaPersonID = 1;
            this.ctlArbeit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlArbeit.Location = new System.Drawing.Point(0, 256);
            this.ctlArbeit.Name = "ctlArbeit";
            this.ctlArbeit.Size = new System.Drawing.Size(896, 355);
            this.ctlArbeit.TabIndex = 1;
            // 
            // panArbeitTop
            // 
            this.panArbeitTop.AutoScroll = true;
            this.panArbeitTop.Controls.Add(this.grpNichtErwerbstaetig);
            this.panArbeitTop.Controls.Add(this.grpErwerbslose);
            this.panArbeitTop.Controls.Add(this.grpAusbildung);
            this.panArbeitTop.Controls.Add(this.grpErwerbstaetig);
            this.panArbeitTop.Controls.Add(this.lblIKAuszugBemerkung);
            this.panArbeitTop.Controls.Add(this.edtIKAuszugJahr);
            this.panArbeitTop.Controls.Add(this.edtIKAuszug);
            this.panArbeitTop.Controls.Add(this.lblSpezielleFaehigkeiten);
            this.panArbeitTop.Controls.Add(this.memSpezFaehigkeiten);
            this.panArbeitTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panArbeitTop.Location = new System.Drawing.Point(0, 0);
            this.panArbeitTop.Name = "panArbeitTop";
            this.panArbeitTop.Size = new System.Drawing.Size(896, 256);
            this.panArbeitTop.TabIndex = 0;
            // 
            // grpNichtErwerbstaetig
            // 
            this.grpNichtErwerbstaetig.Controls.Add(this.lblGrundNichtErwerbstaetig);
            this.grpNichtErwerbstaetig.Controls.Add(this.edtGrundNichtErwerbstaetig);
            this.grpNichtErwerbstaetig.Controls.Add(this.edtNEAnmeldung);
            this.grpNichtErwerbstaetig.Controls.Add(this.lblNEAnmeldung);
            this.grpNichtErwerbstaetig.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpNichtErwerbstaetig.Location = new System.Drawing.Point(425, 81);
            this.grpNichtErwerbstaetig.Name = "grpNichtErwerbstaetig";
            this.grpNichtErwerbstaetig.Size = new System.Drawing.Size(416, 93);
            this.grpNichtErwerbstaetig.TabIndex = 3;
            this.grpNichtErwerbstaetig.TabStop = false;
            this.grpNichtErwerbstaetig.Text = "Nicht-Erwerbstätige";
            // 
            // lblGrundNichtErwerbstaetig
            // 
            this.lblGrundNichtErwerbstaetig.Location = new System.Drawing.Point(6, 17);
            this.lblGrundNichtErwerbstaetig.Name = "lblGrundNichtErwerbstaetig";
            this.lblGrundNichtErwerbstaetig.Size = new System.Drawing.Size(81, 24);
            this.lblGrundNichtErwerbstaetig.TabIndex = 0;
            this.lblGrundNichtErwerbstaetig.Text = "NE-Grund";
            this.lblGrundNichtErwerbstaetig.UseCompatibleTextRendering = true;
            // 
            // edtGrundNichtErwerbstaetig
            // 
            this.edtGrundNichtErwerbstaetig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundNichtErwerbstaetig.DataMember = "BaGrundNichtErwerbstaetigCode";
            this.edtGrundNichtErwerbstaetig.DataSource = this.qryBaPerson;
            this.edtGrundNichtErwerbstaetig.Location = new System.Drawing.Point(97, 17);
            this.edtGrundNichtErwerbstaetig.LOVName = "BaGrundNichtErwerbstaetig";
            this.edtGrundNichtErwerbstaetig.Name = "edtGrundNichtErwerbstaetig";
            this.edtGrundNichtErwerbstaetig.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundNichtErwerbstaetig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundNichtErwerbstaetig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundNichtErwerbstaetig.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundNichtErwerbstaetig.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundNichtErwerbstaetig.Properties.Appearance.Options.UseFont = true;
            this.edtGrundNichtErwerbstaetig.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrundNichtErwerbstaetig.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundNichtErwerbstaetig.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrundNichtErwerbstaetig.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrundNichtErwerbstaetig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtGrundNichtErwerbstaetig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtGrundNichtErwerbstaetig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundNichtErwerbstaetig.Properties.Name = "cboTeilZeitArbeitGrund1.Properties";
            this.edtGrundNichtErwerbstaetig.Properties.NullText = "";
            this.edtGrundNichtErwerbstaetig.Properties.ShowFooter = false;
            this.edtGrundNichtErwerbstaetig.Properties.ShowHeader = false;
            this.edtGrundNichtErwerbstaetig.Size = new System.Drawing.Size(313, 24);
            this.edtGrundNichtErwerbstaetig.TabIndex = 1;
            // 
            // edtNEAnmeldung
            // 
            this.edtNEAnmeldung.DataMember = "NEAnmeldung";
            this.edtNEAnmeldung.DataSource = this.qryBaPerson;
            this.edtNEAnmeldung.EditValue = null;
            this.edtNEAnmeldung.Location = new System.Drawing.Point(97, 40);
            this.edtNEAnmeldung.Name = "edtNEAnmeldung";
            this.edtNEAnmeldung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNEAnmeldung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNEAnmeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNEAnmeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNEAnmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.edtNEAnmeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNEAnmeldung.Properties.Appearance.Options.UseFont = true;
            this.edtNEAnmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtNEAnmeldung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNEAnmeldung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtNEAnmeldung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNEAnmeldung.Properties.ShowToday = false;
            this.edtNEAnmeldung.Size = new System.Drawing.Size(100, 24);
            this.edtNEAnmeldung.TabIndex = 3;
            // 
            // lblNEAnmeldung
            // 
            this.lblNEAnmeldung.Location = new System.Drawing.Point(6, 40);
            this.lblNEAnmeldung.Name = "lblNEAnmeldung";
            this.lblNEAnmeldung.Size = new System.Drawing.Size(85, 24);
            this.lblNEAnmeldung.TabIndex = 2;
            this.lblNEAnmeldung.Text = "NE-Anmeldung";
            this.lblNEAnmeldung.UseCompatibleTextRendering = true;
            // 
            // grpErwerbslose
            // 
            this.grpErwerbslose.Controls.Add(this.lblStellensuche);
            this.grpErwerbslose.Controls.Add(this.edtStellensuche);
            this.grpErwerbslose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpErwerbslose.Location = new System.Drawing.Point(425, 3);
            this.grpErwerbslose.Name = "grpErwerbslose";
            this.grpErwerbslose.Size = new System.Drawing.Size(416, 69);
            this.grpErwerbslose.TabIndex = 2;
            this.grpErwerbslose.TabStop = false;
            this.grpErwerbslose.Text = "Erwerbslose";
            // 
            // lblStellensuche
            // 
            this.lblStellensuche.Location = new System.Drawing.Point(6, 17);
            this.lblStellensuche.Name = "lblStellensuche";
            this.lblStellensuche.Size = new System.Drawing.Size(81, 24);
            this.lblStellensuche.TabIndex = 0;
            this.lblStellensuche.Text = "Stellensuche";
            this.lblStellensuche.UseCompatibleTextRendering = true;
            // 
            // edtStellensuche
            // 
            this.edtStellensuche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStellensuche.DataMember = "StellensuchendCode";
            this.edtStellensuche.DataSource = this.qryBaPerson;
            this.edtStellensuche.Location = new System.Drawing.Point(97, 17);
            this.edtStellensuche.LOVName = "BaStellensuchend";
            this.edtStellensuche.Name = "edtStellensuche";
            this.edtStellensuche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStellensuche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStellensuche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStellensuche.Properties.Appearance.Options.UseBackColor = true;
            this.edtStellensuche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStellensuche.Properties.Appearance.Options.UseFont = true;
            this.edtStellensuche.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStellensuche.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStellensuche.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStellensuche.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStellensuche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtStellensuche.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtStellensuche.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStellensuche.Properties.Name = "cboTeilZeitArbeitGrund2.Properties";
            this.edtStellensuche.Properties.NullText = "";
            this.edtStellensuche.Properties.ShowFooter = false;
            this.edtStellensuche.Properties.ShowHeader = false;
            this.edtStellensuche.Size = new System.Drawing.Size(313, 24);
            this.edtStellensuche.TabIndex = 1;
            // 
            // grpAusbildung
            // 
            this.grpAusbildung.Controls.Add(this.lblErlernterBeruf);
            this.grpAusbildung.Controls.Add(this.edtErlernterBeruf);
            this.grpAusbildung.Controls.Add(this.edtHoechsteAusbildung);
            this.grpAusbildung.Controls.Add(this.edtLetzteAbgebrocheneAusbildung);
            this.grpAusbildung.Controls.Add(this.lblLetzteAbgebrAusbildung);
            this.grpAusbildung.Controls.Add(this.lblHoechsteAusbildung);
            this.grpAusbildung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpAusbildung.Location = new System.Drawing.Point(3, 78);
            this.grpAusbildung.Name = "grpAusbildung";
            this.grpAusbildung.Size = new System.Drawing.Size(416, 93);
            this.grpAusbildung.TabIndex = 1;
            this.grpAusbildung.TabStop = false;
            this.grpAusbildung.Text = "Ausbildung";
            // 
            // lblErlernterBeruf
            // 
            this.lblErlernterBeruf.Location = new System.Drawing.Point(6, 17);
            this.lblErlernterBeruf.Name = "lblErlernterBeruf";
            this.lblErlernterBeruf.Size = new System.Drawing.Size(115, 24);
            this.lblErlernterBeruf.TabIndex = 0;
            this.lblErlernterBeruf.Text = "Erlernter Beruf";
            this.lblErlernterBeruf.UseCompatibleTextRendering = true;
            // 
            // edtErlernterBeruf
            // 
            this.edtErlernterBeruf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErlernterBeruf.DataMember = "ErlernterBerufCode";
            this.edtErlernterBeruf.DataSource = this.qryBaPerson;
            this.edtErlernterBeruf.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtErlernterBeruf.Location = new System.Drawing.Point(127, 17);
            this.edtErlernterBeruf.Name = "edtErlernterBeruf";
            this.edtErlernterBeruf.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.edtErlernterBeruf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErlernterBeruf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErlernterBeruf.Properties.Appearance.Options.UseBackColor = true;
            this.edtErlernterBeruf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErlernterBeruf.Properties.Appearance.Options.UseFont = true;
            this.edtErlernterBeruf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtErlernterBeruf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtErlernterBeruf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErlernterBeruf.Properties.Name = "cboErlernterBeruf.Properties";
            this.edtErlernterBeruf.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtErlernterBeruf.Size = new System.Drawing.Size(281, 24);
            this.edtErlernterBeruf.TabIndex = 1;
            // 
            // edtHoechsteAusbildung
            // 
            this.edtHoechsteAusbildung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHoechsteAusbildung.DataMember = "HoechsteAusbildungCode";
            this.edtHoechsteAusbildung.DataSource = this.qryBaPerson;
            this.edtHoechsteAusbildung.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtHoechsteAusbildung.Location = new System.Drawing.Point(127, 40);
            this.edtHoechsteAusbildung.LOVName = "BaAusbildungstyp";
            this.edtHoechsteAusbildung.Name = "edtHoechsteAusbildung";
            this.edtHoechsteAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.edtHoechsteAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHoechsteAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHoechsteAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.edtHoechsteAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHoechsteAusbildung.Properties.Appearance.Options.UseFont = true;
            this.edtHoechsteAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtHoechsteAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtHoechsteAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtHoechsteAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtHoechsteAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtHoechsteAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.edtHoechsteAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHoechsteAusbildung.Properties.Name = "cboHoechsteAusbildung.Properties";
            this.edtHoechsteAusbildung.Properties.NullText = "";
            this.edtHoechsteAusbildung.Properties.ShowFooter = false;
            this.edtHoechsteAusbildung.Properties.ShowHeader = false;
            this.edtHoechsteAusbildung.Size = new System.Drawing.Size(281, 24);
            this.edtHoechsteAusbildung.TabIndex = 3;
            // 
            // edtLetzteAbgebrocheneAusbildung
            // 
            this.edtLetzteAbgebrocheneAusbildung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLetzteAbgebrocheneAusbildung.DataMember = "AbgebrocheneAusbildungCode";
            this.edtLetzteAbgebrocheneAusbildung.DataSource = this.qryBaPerson;
            this.edtLetzteAbgebrocheneAusbildung.Location = new System.Drawing.Point(127, 63);
            this.edtLetzteAbgebrocheneAusbildung.LOVName = "BaAusbildungstyp";
            this.edtLetzteAbgebrocheneAusbildung.Name = "edtLetzteAbgebrocheneAusbildung";
            this.edtLetzteAbgebrocheneAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLetzteAbgebrocheneAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLetzteAbgebrocheneAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.edtLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseFont = true;
            this.edtLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLetzteAbgebrocheneAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtLetzteAbgebrocheneAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtLetzteAbgebrocheneAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLetzteAbgebrocheneAusbildung.Properties.Name = "cboLetzteAbgebrocheneAusbildung.Properties";
            this.edtLetzteAbgebrocheneAusbildung.Properties.NullText = "";
            this.edtLetzteAbgebrocheneAusbildung.Properties.ShowFooter = false;
            this.edtLetzteAbgebrocheneAusbildung.Properties.ShowHeader = false;
            this.edtLetzteAbgebrocheneAusbildung.Size = new System.Drawing.Size(281, 24);
            this.edtLetzteAbgebrocheneAusbildung.TabIndex = 5;
            // 
            // lblLetzteAbgebrAusbildung
            // 
            this.lblLetzteAbgebrAusbildung.Location = new System.Drawing.Point(6, 63);
            this.lblLetzteAbgebrAusbildung.Name = "lblLetzteAbgebrAusbildung";
            this.lblLetzteAbgebrAusbildung.Size = new System.Drawing.Size(115, 24);
            this.lblLetzteAbgebrAusbildung.TabIndex = 4;
            this.lblLetzteAbgebrAusbildung.Text = "Letzte abgebr. Ausb.";
            this.lblLetzteAbgebrAusbildung.UseCompatibleTextRendering = true;
            // 
            // lblHoechsteAusbildung
            // 
            this.lblHoechsteAusbildung.Location = new System.Drawing.Point(6, 40);
            this.lblHoechsteAusbildung.Name = "lblHoechsteAusbildung";
            this.lblHoechsteAusbildung.Size = new System.Drawing.Size(115, 24);
            this.lblHoechsteAusbildung.TabIndex = 2;
            this.lblHoechsteAusbildung.Text = "Höchste Ausbildung";
            this.lblHoechsteAusbildung.UseCompatibleTextRendering = true;
            // 
            // grpErwerbstaetig
            // 
            this.grpErwerbstaetig.Controls.Add(this.lblAnstellungsverhaeltnis);
            this.grpErwerbstaetig.Controls.Add(this.edtErwerbssituation);
            this.grpErwerbstaetig.Controls.Add(this.edtJetzigeTaetigkeit);
            this.grpErwerbstaetig.Controls.Add(this.lblJetzigeTaetigkeit);
            this.grpErwerbstaetig.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpErwerbstaetig.Location = new System.Drawing.Point(3, 3);
            this.grpErwerbstaetig.Name = "grpErwerbstaetig";
            this.grpErwerbstaetig.Size = new System.Drawing.Size(416, 69);
            this.grpErwerbstaetig.TabIndex = 0;
            this.grpErwerbstaetig.TabStop = false;
            this.grpErwerbstaetig.Text = "Erwerbstätig, 1. Arbeitsmarkt";
            // 
            // lblAnstellungsverhaeltnis
            // 
            this.lblAnstellungsverhaeltnis.Location = new System.Drawing.Point(6, 17);
            this.lblAnstellungsverhaeltnis.Name = "lblAnstellungsverhaeltnis";
            this.lblAnstellungsverhaeltnis.Size = new System.Drawing.Size(115, 24);
            this.lblAnstellungsverhaeltnis.TabIndex = 0;
            this.lblAnstellungsverhaeltnis.Text = "Anstellungsverhältnis";
            this.lblAnstellungsverhaeltnis.UseCompatibleTextRendering = true;
            // 
            // edtErwerbssituation
            // 
            this.edtErwerbssituation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErwerbssituation.DataMember = "ErwerbssituationCode";
            this.edtErwerbssituation.DataSource = this.qryBaPerson;
            this.edtErwerbssituation.Location = new System.Drawing.Point(127, 17);
            this.edtErwerbssituation.LOVName = "BaErwerbssituation";
            this.edtErwerbssituation.Name = "edtErwerbssituation";
            this.edtErwerbssituation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErwerbssituation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErwerbssituation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErwerbssituation.Properties.Appearance.Options.UseBackColor = true;
            this.edtErwerbssituation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErwerbssituation.Properties.Appearance.Options.UseFont = true;
            this.edtErwerbssituation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErwerbssituation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErwerbssituation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErwerbssituation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErwerbssituation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.edtErwerbssituation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.edtErwerbssituation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErwerbssituation.Properties.Name = "cboErwerbssituation1.Properties";
            this.edtErwerbssituation.Properties.NullText = "";
            this.edtErwerbssituation.Properties.ShowFooter = false;
            this.edtErwerbssituation.Properties.ShowHeader = false;
            this.edtErwerbssituation.Size = new System.Drawing.Size(283, 24);
            this.edtErwerbssituation.TabIndex = 1;
            // 
            // edtJetzigeTaetigkeit
            // 
            this.edtJetzigeTaetigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtJetzigeTaetigkeit.DataMember = "BerufCode";
            this.edtJetzigeTaetigkeit.DataSource = this.qryBaPerson;
            this.edtJetzigeTaetigkeit.Location = new System.Drawing.Point(127, 40);
            this.edtJetzigeTaetigkeit.Name = "edtJetzigeTaetigkeit";
            this.edtJetzigeTaetigkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJetzigeTaetigkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJetzigeTaetigkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJetzigeTaetigkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtJetzigeTaetigkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJetzigeTaetigkeit.Properties.Appearance.Options.UseFont = true;
            this.edtJetzigeTaetigkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject24.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject24.Options.UseBackColor = true;
            this.edtJetzigeTaetigkeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject24)});
            this.edtJetzigeTaetigkeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJetzigeTaetigkeit.Properties.Name = "cboLetzteTaetigkeit.Properties";
            this.edtJetzigeTaetigkeit.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtJetzigeTaetigkeit.Size = new System.Drawing.Size(283, 24);
            this.edtJetzigeTaetigkeit.TabIndex = 3;
            // 
            // lblJetzigeTaetigkeit
            // 
            this.lblJetzigeTaetigkeit.Location = new System.Drawing.Point(6, 40);
            this.lblJetzigeTaetigkeit.Name = "lblJetzigeTaetigkeit";
            this.lblJetzigeTaetigkeit.Size = new System.Drawing.Size(115, 24);
            this.lblJetzigeTaetigkeit.TabIndex = 2;
            this.lblJetzigeTaetigkeit.Text = "Jetzige Tätigkeit";
            this.lblJetzigeTaetigkeit.UseCompatibleTextRendering = true;
            // 
            // lblIKAuszugBemerkung
            // 
            this.lblIKAuszugBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIKAuszugBemerkung.DataMember = "IKAuszugBemerkung";
            this.lblIKAuszugBemerkung.DataSource = this.qryBaPerson;
            this.lblIKAuszugBemerkung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIKAuszugBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblIKAuszugBemerkung.Location = new System.Drawing.Point(256, 176);
            this.lblIKAuszugBemerkung.Name = "lblIKAuszugBemerkung";
            this.lblIKAuszugBemerkung.Size = new System.Drawing.Size(585, 24);
            this.lblIKAuszugBemerkung.TabIndex = 6;
            this.lblIKAuszugBemerkung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIKAuszugBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtIKAuszugJahr
            // 
            this.edtIKAuszugJahr.EditValue = "1985";
            this.edtIKAuszugJahr.Location = new System.Drawing.Point(184, 176);
            this.edtIKAuszugJahr.Name = "edtIKAuszugJahr";
            this.edtIKAuszugJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIKAuszugJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIKAuszugJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIKAuszugJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtIKAuszugJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIKAuszugJahr.Properties.Appearance.Options.UseFont = true;
            this.edtIKAuszugJahr.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIKAuszugJahr.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIKAuszugJahr.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIKAuszugJahr.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIKAuszugJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject25.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject25.Options.UseBackColor = true;
            this.edtIKAuszugJahr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject25)});
            this.edtIKAuszugJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIKAuszugJahr.Properties.ImmediatePopup = true;
            this.edtIKAuszugJahr.Properties.Name = "cboGeschlecht.Properties";
            this.edtIKAuszugJahr.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edtIKAuszugJahr.Size = new System.Drawing.Size(66, 24);
            this.edtIKAuszugJahr.TabIndex = 5;
            this.edtIKAuszugJahr.SelectedIndexChanged += new System.EventHandler(this.cmbIKAuszugJahr_SelectedIndexChanged);
            // 
            // edtIKAuszug
            // 
            this.edtIKAuszug.EditValue = false;
            this.edtIKAuszug.Location = new System.Drawing.Point(9, 181);
            this.edtIKAuszug.Name = "edtIKAuszug";
            this.edtIKAuszug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIKAuszug.Properties.Appearance.Options.UseBackColor = true;
            this.edtIKAuszug.Properties.Caption = "IK Auszug anfordern, ab Jahr";
            this.edtIKAuszug.Properties.Name = "edtEinwohnerregisterAktiv.Properties";
            this.edtIKAuszug.Size = new System.Drawing.Size(169, 19);
            this.edtIKAuszug.TabIndex = 4;
            this.edtIKAuszug.CheckedChanged += new System.EventHandler(this.chkIKAuszug_CheckedChanged);
            // 
            // lblSpezielleFaehigkeiten
            // 
            this.lblSpezielleFaehigkeiten.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSpezielleFaehigkeiten.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSpezielleFaehigkeiten.Location = new System.Drawing.Point(9, 207);
            this.lblSpezielleFaehigkeiten.Name = "lblSpezielleFaehigkeiten";
            this.lblSpezielleFaehigkeiten.Size = new System.Drawing.Size(115, 31);
            this.lblSpezielleFaehigkeiten.TabIndex = 7;
            this.lblSpezielleFaehigkeiten.Text = "Spezielle Fähigkeiten";
            this.lblSpezielleFaehigkeiten.UseCompatibleTextRendering = true;
            // 
            // memSpezFaehigkeiten
            // 
            this.memSpezFaehigkeiten.DataMember = "ArbeitSpezFaehigkeiten";
            this.memSpezFaehigkeiten.DataSource = this.qryBaPerson;
            this.memSpezFaehigkeiten.Location = new System.Drawing.Point(130, 207);
            this.memSpezFaehigkeiten.Name = "memSpezFaehigkeiten";
            this.memSpezFaehigkeiten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memSpezFaehigkeiten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memSpezFaehigkeiten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memSpezFaehigkeiten.Properties.Appearance.Options.UseBackColor = true;
            this.memSpezFaehigkeiten.Properties.Appearance.Options.UseBorderColor = true;
            this.memSpezFaehigkeiten.Properties.Appearance.Options.UseFont = true;
            this.memSpezFaehigkeiten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memSpezFaehigkeiten.Properties.Name = "kissMemoEdit3.Properties";
            this.memSpezFaehigkeiten.Size = new System.Drawing.Size(711, 43);
            this.memSpezFaehigkeiten.TabIndex = 8;
            // 
            // tbpErsatzeinkommen
            // 
            this.tbpErsatzeinkommen.AutoScroll = true;
            this.tbpErsatzeinkommen.Controls.Add(this.ctlBaPersonErsatzeinkommen);
            this.tbpErsatzeinkommen.Location = new System.Drawing.Point(6, 32);
            this.tbpErsatzeinkommen.Name = "tbpErsatzeinkommen";
            this.tbpErsatzeinkommen.Size = new System.Drawing.Size(896, 611);
            this.tbpErsatzeinkommen.TabIndex = 4;
            this.tbpErsatzeinkommen.Title = "Ersatzeinkommen";
            // 
            // ctlBaPersonErsatzeinkommen
            // 
            this.ctlBaPersonErsatzeinkommen.AutoScroll = true;
            this.ctlBaPersonErsatzeinkommen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlBaPersonErsatzeinkommen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlBaPersonErsatzeinkommen.Location = new System.Drawing.Point(0, 0);
            this.ctlBaPersonErsatzeinkommen.Name = "ctlBaPersonErsatzeinkommen";
            this.ctlBaPersonErsatzeinkommen.Size = new System.Drawing.Size(896, 611);
            this.ctlBaPersonErsatzeinkommen.TabIndex = 0;
            // 
            // tbpVermoegen
            // 
            this.tbpVermoegen.AutoScroll = true;
            this.tbpVermoegen.Controls.Add(this.ctlBaPersonVermoegen);
            this.tbpVermoegen.Location = new System.Drawing.Point(6, 32);
            this.tbpVermoegen.Name = "tbpVermoegen";
            this.tbpVermoegen.Size = new System.Drawing.Size(896, 611);
            this.tbpVermoegen.TabIndex = 9;
            this.tbpVermoegen.Title = "Vermögen";
            // 
            // ctlBaPersonVermoegen
            // 
            this.ctlBaPersonVermoegen.AutoScroll = true;
            this.ctlBaPersonVermoegen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlBaPersonVermoegen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlBaPersonVermoegen.Location = new System.Drawing.Point(0, 0);
            this.ctlBaPersonVermoegen.Name = "ctlBaPersonVermoegen";
            this.ctlBaPersonVermoegen.Size = new System.Drawing.Size(896, 611);
            this.ctlBaPersonVermoegen.TabIndex = 0;
            // 
            // tbpZahlweg
            // 
            this.tbpZahlweg.AutoScroll = true;
            this.tbpZahlweg.Controls.Add(this.ctlZahlungsweg);
            this.tbpZahlweg.Location = new System.Drawing.Point(6, 32);
            this.tbpZahlweg.Name = "tbpZahlweg";
            this.tbpZahlweg.Size = new System.Drawing.Size(896, 611);
            this.tbpZahlweg.TabIndex = 6;
            this.tbpZahlweg.Title = "Zahlinfo";
            // 
            // ctlZahlungsweg
            // 
            this.ctlZahlungsweg.AutoScroll = true;
            this.ctlZahlungsweg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlZahlungsweg.BaInstitutionID = 0;
            this.ctlZahlungsweg.BaPersonID = 1;
            this.ctlZahlungsweg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlZahlungsweg.Location = new System.Drawing.Point(0, 0);
            this.ctlZahlungsweg.MinimumSize = new System.Drawing.Size(615, 466);
            this.ctlZahlungsweg.Name = "ctlZahlungsweg";
            this.ctlZahlungsweg.Size = new System.Drawing.Size(896, 611);
            this.ctlZahlungsweg.TabIndex = 0;
            // 
            // tbpWVCode
            // 
            this.tbpWVCode.AutoScroll = true;
            this.tbpWVCode.Controls.Add(this.ctlWVCode);
            this.tbpWVCode.Controls.Add(this.panel4);
            this.tbpWVCode.Location = new System.Drawing.Point(6, 32);
            this.tbpWVCode.Name = "tbpWVCode";
            this.tbpWVCode.Size = new System.Drawing.Size(896, 611);
            this.tbpWVCode.TabIndex = 7;
            this.tbpWVCode.Title = "WV-Code";
            // 
            // ctlWVCode
            // 
            this.ctlWVCode.AutoScroll = true;
            this.ctlWVCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlWVCode.BaPersonID = 0;
            this.ctlWVCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlWVCode.Location = new System.Drawing.Point(0, 0);
            this.ctlWVCode.MinimumSize = new System.Drawing.Size(708, 264);
            this.ctlWVCode.Name = "ctlWVCode";
            this.ctlWVCode.Size = new System.Drawing.Size(896, 443);
            this.ctlWVCode.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.kissLabel108);
            this.panel4.Controls.Add(this.edtHeimtortLand);
            this.panel4.Controls.Add(this.lblHeimatort);
            this.panel4.Controls.Add(this.edtInCHseit2);
            this.panel4.Controls.Add(this.lblInCHseit);
            this.panel4.Controls.Add(this.datZuzugKantonSeit);
            this.panel4.Controls.Add(this.lblDatumKanton);
            this.panel4.Controls.Add(this.edtZuzugKtOrtCode);
            this.panel4.Controls.Add(this.lblLandKanton);
            this.panel4.Controls.Add(this.lblPlzZuzugKanton);
            this.panel4.Controls.Add(this.kissLabel109);
            this.panel4.Controls.Add(this.datZuzugSeit);
            this.panel4.Controls.Add(this.lblDatumGemeinde);
            this.panel4.Controls.Add(this.edtZuzugGdeOrtCode);
            this.panel4.Controls.Add(this.lblLandGemeinde);
            this.panel4.Controls.Add(this.lblPlzZuzugGemeinde);
            this.panel4.Controls.Add(this.kissLabel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 443);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(896, 168);
            this.panel4.TabIndex = 0;
            // 
            // kissLabel108
            // 
            this.kissLabel108.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel108.Location = new System.Drawing.Point(99, 11);
            this.kissLabel108.Name = "kissLabel108";
            this.kissLabel108.Size = new System.Drawing.Size(203, 16);
            this.kissLabel108.TabIndex = 89;
            this.kissLabel108.Text = "Zuzug in die Stadt Zürich von";
            this.kissLabel108.UseCompatibleTextRendering = true;
            // 
            // edtHeimtortLand
            // 
            this.edtHeimtortLand.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHeimtortLand.Location = new System.Drawing.Point(458, 129);
            this.edtHeimtortLand.Name = "edtHeimtortLand";
            this.edtHeimtortLand.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHeimtortLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimtortLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimtortLand.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimtortLand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimtortLand.Properties.Appearance.Options.UseFont = true;
            this.edtHeimtortLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimtortLand.Properties.ReadOnly = true;
            this.edtHeimtortLand.Size = new System.Drawing.Size(253, 24);
            this.edtHeimtortLand.TabIndex = 15;
            // 
            // lblHeimatort
            // 
            this.lblHeimatort.Location = new System.Drawing.Point(366, 130);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(86, 24);
            this.lblHeimatort.TabIndex = 14;
            this.lblHeimatort.Text = "Heimatland/-ort";
            this.lblHeimatort.UseCompatibleTextRendering = true;
            // 
            // edtInCHseit2
            // 
            this.edtInCHseit2.DataMember = "InCHSeit";
            this.edtInCHseit2.DataSource = this.qryBaPerson;
            this.edtInCHseit2.EditValue = null;
            this.edtInCHseit2.Location = new System.Drawing.Point(98, 130);
            this.edtInCHseit2.Name = "edtInCHseit2";
            this.edtInCHseit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtInCHseit2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInCHseit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInCHseit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInCHseit2.Properties.Appearance.Options.UseBackColor = true;
            this.edtInCHseit2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInCHseit2.Properties.Appearance.Options.UseFont = true;
            this.edtInCHseit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject26.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject26.Options.UseBackColor = true;
            this.edtInCHseit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtInCHseit2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject26)});
            this.edtInCHseit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInCHseit2.Properties.ShowToday = false;
            this.edtInCHseit2.Size = new System.Drawing.Size(100, 24);
            this.edtInCHseit2.TabIndex = 13;
            // 
            // lblInCHseit
            // 
            this.lblInCHseit.Location = new System.Drawing.Point(3, 129);
            this.lblInCHseit.Name = "lblInCHseit";
            this.lblInCHseit.Size = new System.Drawing.Size(100, 24);
            this.lblInCHseit.TabIndex = 12;
            this.lblInCHseit.Text = "in CH seit";
            this.lblInCHseit.UseCompatibleTextRendering = true;
            // 
            // datZuzugKantonSeit
            // 
            this.datZuzugKantonSeit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datZuzugKantonSeit.DataMember = "ZuzugKtDatum";
            this.datZuzugKantonSeit.DataSource = this.qryBaPerson;
            this.datZuzugKantonSeit.Location = new System.Drawing.Point(458, 85);
            this.datZuzugKantonSeit.Name = "datZuzugKantonSeit";
            this.datZuzugKantonSeit.Size = new System.Drawing.Size(194, 24);
            this.datZuzugKantonSeit.TabIndex = 11;
            // 
            // lblDatumKanton
            // 
            this.lblDatumKanton.Location = new System.Drawing.Point(366, 85);
            this.lblDatumKanton.Name = "lblDatumKanton";
            this.lblDatumKanton.Size = new System.Drawing.Size(66, 24);
            this.lblDatumKanton.TabIndex = 10;
            this.lblDatumKanton.Text = "Zuzug am";
            this.lblDatumKanton.UseCompatibleTextRendering = true;
            // 
            // edtZuzugKtOrtCode
            // 
            this.edtZuzugKtOrtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZuzugKtOrtCode.DataMember = "ZuzugKtOrtCode";
            this.edtZuzugKtOrtCode.DataMemberBaGemeindeID = null;
            this.edtZuzugKtOrtCode.DataMemberKanton = "ZuzugKtKanton";
            this.edtZuzugKtOrtCode.DataMemberLand = "ZuzugKtLandCode";
            this.edtZuzugKtOrtCode.DataMemberOrt = "ZuzugKtOrt";
            this.edtZuzugKtOrtCode.DataMemberPLZ = "ZuzugKtPLZ";
            this.edtZuzugKtOrtCode.DataSource = this.qryBaPerson;
            this.edtZuzugKtOrtCode.Location = new System.Drawing.Point(458, 32);
            this.edtZuzugKtOrtCode.Name = "edtZuzugKtOrtCode";
            this.edtZuzugKtOrtCode.Size = new System.Drawing.Size(250, 47);
            this.edtZuzugKtOrtCode.TabIndex = 9;
            // 
            // lblLandKanton
            // 
            this.lblLandKanton.Location = new System.Drawing.Point(366, 55);
            this.lblLandKanton.Name = "lblLandKanton";
            this.lblLandKanton.Size = new System.Drawing.Size(66, 24);
            this.lblLandKanton.TabIndex = 8;
            this.lblLandKanton.Text = "Land";
            this.lblLandKanton.UseCompatibleTextRendering = true;
            // 
            // lblPlzZuzugKanton
            // 
            this.lblPlzZuzugKanton.Location = new System.Drawing.Point(366, 32);
            this.lblPlzZuzugKanton.Name = "lblPlzZuzugKanton";
            this.lblPlzZuzugKanton.Size = new System.Drawing.Size(66, 24);
            this.lblPlzZuzugKanton.TabIndex = 7;
            this.lblPlzZuzugKanton.Text = "PLZ / Ort / Kt";
            this.lblPlzZuzugKanton.UseCompatibleTextRendering = true;
            // 
            // kissLabel109
            // 
            this.kissLabel109.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel109.Location = new System.Drawing.Point(458, 11);
            this.kissLabel109.Name = "kissLabel109";
            this.kissLabel109.Size = new System.Drawing.Size(211, 16);
            this.kissLabel109.TabIndex = 6;
            this.kissLabel109.Text = "Zuzug in den Kanton Zürich von";
            this.kissLabel109.UseCompatibleTextRendering = true;
            // 
            // datZuzugSeit
            // 
            this.datZuzugSeit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datZuzugSeit.DataMember = "ZuzugGdeDatum";
            this.datZuzugSeit.DataSource = this.qryBaPerson;
            this.datZuzugSeit.Location = new System.Drawing.Point(98, 85);
            this.datZuzugSeit.Name = "datZuzugSeit";
            this.datZuzugSeit.Size = new System.Drawing.Size(204, 24);
            this.datZuzugSeit.TabIndex = 5;
            // 
            // lblDatumGemeinde
            // 
            this.lblDatumGemeinde.Location = new System.Drawing.Point(3, 82);
            this.lblDatumGemeinde.Name = "lblDatumGemeinde";
            this.lblDatumGemeinde.Size = new System.Drawing.Size(72, 24);
            this.lblDatumGemeinde.TabIndex = 4;
            this.lblDatumGemeinde.Text = "Zuzug am";
            this.lblDatumGemeinde.UseCompatibleTextRendering = true;
            // 
            // edtZuzugGdeOrtCode
            // 
            this.edtZuzugGdeOrtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZuzugGdeOrtCode.DataMemberBaGemeindeID = "ZuzugGdeOrtCode";
            this.edtZuzugGdeOrtCode.DataMemberKanton = "ZuzugGdeKanton";
            this.edtZuzugGdeOrtCode.DataMemberLand = "ZuzugGdeLandCode";
            this.edtZuzugGdeOrtCode.DataMemberOrt = "ZuzugGdeOrt";
            this.edtZuzugGdeOrtCode.DataMemberPLZ = "ZuzugGdePLZ";
            this.edtZuzugGdeOrtCode.DataSource = this.qryBaPerson;
            this.edtZuzugGdeOrtCode.Location = new System.Drawing.Point(99, 32);
            this.edtZuzugGdeOrtCode.Name = "edtZuzugGdeOrtCode";
            this.edtZuzugGdeOrtCode.Size = new System.Drawing.Size(250, 47);
            this.edtZuzugGdeOrtCode.TabIndex = 3;
            // 
            // lblLandGemeinde
            // 
            this.lblLandGemeinde.Location = new System.Drawing.Point(3, 55);
            this.lblLandGemeinde.Name = "lblLandGemeinde";
            this.lblLandGemeinde.Size = new System.Drawing.Size(75, 24);
            this.lblLandGemeinde.TabIndex = 2;
            this.lblLandGemeinde.Text = "Land";
            this.lblLandGemeinde.UseCompatibleTextRendering = true;
            // 
            // lblPlzZuzugGemeinde
            // 
            this.lblPlzZuzugGemeinde.Location = new System.Drawing.Point(3, 32);
            this.lblPlzZuzugGemeinde.Name = "lblPlzZuzugGemeinde";
            this.lblPlzZuzugGemeinde.Size = new System.Drawing.Size(85, 24);
            this.lblPlzZuzugGemeinde.TabIndex = 1;
            this.lblPlzZuzugGemeinde.Text = "PLZ / Ort / Kt";
            this.lblPlzZuzugGemeinde.UseCompatibleTextRendering = true;
            // 
            // kissLabel6
            // 
            this.kissLabel6.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel6.Location = new System.Drawing.Point(98, 11);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(203, 16);
            this.kissLabel6.TabIndex = 0;
            this.kissLabel6.Text = "Zuzug in die Stadt Zürich von";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // tbpAlteFallNr
            // 
            this.tbpAlteFallNr.AutoScroll = true;
            this.tbpAlteFallNr.Controls.Add(this.ctlAlteFallNr);
            this.tbpAlteFallNr.Location = new System.Drawing.Point(6, 32);
            this.tbpAlteFallNr.Name = "tbpAlteFallNr";
            this.tbpAlteFallNr.Size = new System.Drawing.Size(896, 611);
            this.tbpAlteFallNr.TabIndex = 8;
            this.tbpAlteFallNr.Title = "alte Fall-Nr.";
            // 
            // ctlAlteFallNr
            // 
            this.ctlAlteFallNr.AutoScroll = true;
            this.ctlAlteFallNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlAlteFallNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlAlteFallNr.Location = new System.Drawing.Point(0, 0);
            this.ctlAlteFallNr.Name = "ctlAlteFallNr";
            this.ctlAlteFallNr.Size = new System.Drawing.Size(896, 611);
            this.ctlAlteFallNr.TabIndex = 0;
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGesetz,
            this.colJahr,
            this.colKrankenkasse});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colGesetz
            // 
            this.colGesetz.Caption = "Gesetz";
            this.colGesetz.Name = "colGesetz";
            this.colGesetz.Visible = true;
            this.colGesetz.VisibleIndex = 0;
            this.colGesetz.Width = 63;
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 1;
            // 
            // colKrankenkasse
            // 
            this.colKrankenkasse.Caption = "Krankenkasse";
            this.colKrankenkasse.Name = "colKrankenkasse";
            this.colKrankenkasse.Visible = true;
            this.colKrankenkasse.VisibleIndex = 2;
            this.colKrankenkasse.Width = 514;
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
            this.gridView4.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.colGesetz1,
            this.colJahr1,
            this.colKrankenkasse1});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView4.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsNavigation.UseTabKey = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // colGesetz1
            // 
            this.colGesetz1.Caption = "Gesetz";
            this.colGesetz1.Name = "colGesetz1";
            this.colGesetz1.Visible = true;
            this.colGesetz1.VisibleIndex = 0;
            this.colGesetz1.Width = 65;
            // 
            // colJahr1
            // 
            this.colJahr1.Caption = "Jahr";
            this.colJahr1.Name = "colJahr1";
            this.colJahr1.Visible = true;
            this.colJahr1.VisibleIndex = 1;
            this.colJahr1.Width = 54;
            // 
            // colKrankenkasse1
            // 
            this.colKrankenkasse1.Caption = "Krankenkasse";
            this.colKrankenkasse1.Name = "colKrankenkasse1";
            this.colKrankenkasse1.Visible = true;
            this.colKrankenkasse1.VisibleIndex = 2;
            this.colKrankenkasse1.Width = 628;
            // 
            // gridView5
            // 
            this.gridView5.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView5.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.Empty.Options.UseBackColor = true;
            this.gridView5.Appearance.Empty.Options.UseFont = true;
            this.gridView5.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.EvenRow.Options.UseFont = true;
            this.gridView5.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView5.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView5.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView5.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView5.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView5.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView5.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView5.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView5.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView5.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupRow.Options.UseFont = true;
            this.gridView5.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView5.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView5.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView5.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView5.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView5.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView5.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView5.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView5.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView5.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView5.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView5.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.OddRow.Options.UseFont = true;
            this.gridView5.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView5.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.Row.Options.UseBackColor = true;
            this.gridView5.Appearance.Row.Options.UseFont = true;
            this.gridView5.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView5.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView5.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView5.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsCustomization.AllowFilter = false;
            this.gridView5.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView5.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView5.OptionsNavigation.UseTabKey = false;
            this.gridView5.OptionsView.ColumnAutoWidth = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            // 
            // qryPraemienuebernahme
            // 
            this.qryPraemienuebernahme.CanInsert = true;
            this.qryPraemienuebernahme.SelectStatement = resources.GetString("qryPraemienuebernahme.SelectStatement");
            this.qryPraemienuebernahme.TableName = "BaPraemienuebernahme";
            // 
            // qryPraemienverbilligung
            // 
            this.qryPraemienverbilligung.CanInsert = true;
            this.qryPraemienverbilligung.SelectStatement = resources.GetString("qryPraemienverbilligung.SelectStatement");
            this.qryPraemienverbilligung.TableName = "BaPraemienverbilligung";
            // 
            // CtlBaPerson
            // 
            this.ActiveSQLQuery = this.qryBaPerson;
            this.AutoScroll = true;
            this.Controls.Add(this.tabStammdaten);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(712, 496);
            this.Name = "CtlBaPerson";
            this.Size = new System.Drawing.Size(908, 673);
            this.Load += new System.EventHandler(this.CtlBaPerson_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tabStammdaten.ResumeLayout(false);
            this.tbpPersonalien.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialraum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSozialRaum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinwohnerregisterAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonOhneLeistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZarNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZarNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantRefNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAuslaenderStatusGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeitGeburt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschVerstehenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschVerstehenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReligion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReligion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWichitgerHinweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWichitgerHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSterbeDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobil2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobil1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            this.tbpAdressen.ResumeLayout(false);
            this.pnlAdressenBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWegzugPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).EndInit();
            this.tbpVersicherungen.ResumeLayout(false);
            this.tbpArbeit.ResumeLayout(false);
            this.panArbeitTop.ResumeLayout(false);
            this.grpNichtErwerbstaetig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundNichtErwerbstaetig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundNichtErwerbstaetig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundNichtErwerbstaetig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNEAnmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNEAnmeldung)).EndInit();
            this.grpErwerbslose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblStellensuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStellensuche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStellensuche)).EndInit();
            this.grpAusbildung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErlernterBeruf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErlernterBeruf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHoechsteAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHoechsteAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzteAbgebrocheneAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzteAbgebrocheneAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAbgebrAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoechsteAusbildung)).EndInit();
            this.grpErwerbstaetig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAnstellungsverhaeltnis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJetzigeTaetigkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJetzigeTaetigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIKAuszugBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIKAuszugJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIKAuszug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSpezielleFaehigkeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSpezFaehigkeiten.Properties)).EndInit();
            this.tbpErsatzeinkommen.ResumeLayout(false);
            this.tbpVermoegen.ResumeLayout(false);
            this.tbpZahlweg.ResumeLayout(false);
            this.tbpWVCode.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimtortLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInCHseit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInCHseit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzZuzugKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzZuzugGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            this.tbpAlteFallNr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienuebernahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienverbilligung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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

        private Gui.KissGroupBox grpErwerbslose;
        private Gui.KissGroupBox grpAusbildung;
        private Gui.KissGroupBox grpErwerbstaetig;
        private Gui.KissGroupBox grpNichtErwerbstaetig;

    }
}