using System;
using System.Data;
using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaEinsatzplaetzeDetail : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Public Fields

        public bool IsReadOnly;

        #endregion

        #region Internal Fields

        protected internal KiSS4.Dokument.KissDocumentButton docKaEinsatzplatz;

        #endregion

        #region Protected Fields

        protected DevExpress.XtraGrid.Columns.GridColumn colVermDatumBis;
        protected DevExpress.XtraGrid.Columns.GridColumn colVermDatumVon;
        protected DevExpress.XtraGrid.Columns.GridColumn colVermName;
        protected DevExpress.XtraGrid.Columns.GridColumn colVermPensum;
        protected DevExpress.XtraGrid.Columns.GridColumn colVermVorname;
        protected DevExpress.XtraGrid.Columns.GridColumn colVermZustaendig;
        protected DevExpress.XtraGrid.Columns.GridColumn colVorschlag;
        protected KiSS4.Gui.KissGrid grdPersonen;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvVermittlung;
        protected KiSS4.DB.SqlQuery qryKaEinsatzplatz;
        protected KiSS4.DB.SqlQuery qryKaKontaktperson;
        protected KiSS4.DB.SqlQuery qryKaVermittlung;
        protected KiSS4.Gui.KissTabControlEx tabBottom;

        #endregion

        #region Private Fields

        private KiSS4.Gui.KissButton btnInfoBetrieb;
        private KiSS4.Gui.KissButton btnInformationenPerson;
        private KiSS4.Gui.KissButton btnKontaktdatenAendern;
        private KiSS4.Gui.KissButton btnKopieren;
        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private KiSS4.Gui.KissCheckEdit chkAufteilbar;
        private KiSS4.Gui.KissCheckEdit chkFuehrerausweis;
        private KiSS4.Gui.KissCheckEdit chkNeuGeschaffeneLehrstelle;
        private KiSS4.Gui.KissCheckEdit chkPensumUnbestimmt;
        private KiSS4.Gui.KissCheckEdit chkUnbefristeteStelle;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAdresseBetrieb;
        private KiSS4.Gui.KissLookUpEdit edtAusbildung;
        private KiSS4.Gui.KissButtonEdit edtBetrieb;
        private KiSS4.Gui.KissTextEdit edtBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtBranche;
        private KiSS4.Gui.KissMemoEdit edtDetails;
        private KiSS4.Gui.KissLookUpEdit edtDeutschMuendlich;
        private KiSS4.Gui.KissLookUpEdit edtDeutschSchriftlich;
        private KiSS4.Gui.KissDateEdit edtEinsatzAb;
        private KiSS4.Gui.KissLookUpEdit edtEinsatzplatzGeschlecht;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatzNummer;
        private KiSS4.Gui.KissCalcEdit edtEinzelpensumBis;
        private KiSS4.Gui.KissCalcEdit edtEinzelpensumVon;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissDateEdit edtErfassungsdatum;
        private KiSS4.Gui.KissTextEdit edtFax;
        private KiSS4.Gui.KissLookUpEdit edtFuehrerausweisKategorie;
        private KiSS4.Gui.KissLookUpEdit edtKaProgramm;
        private KiSS4.Gui.KissLookUpEdit edtKontaktFunktion;
        private KiSS4.Gui.KissLookUpEdit edtKontaktperson;
        private KiSS4.Gui.KissMemoEdit edtKontaktpersonBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtLehrberuf;
        private KiSS4.Gui.KissCalcEdit edtPensum;
        private KiSS4.Gui.KissTextEdit edtTelefon;
        private KiSS4.Gui.KissTextEdit edtTelefonMobil;
        private KiSS4.Gui.KissLookUpEdit edtTypAusbildung;
        private KiSS4.Gui.KissDateEdit edtVerEinsatzBis;
        private KiSS4.Gui.KissDateEdit edtVerEinsatzVon;
        private KiSS4.Gui.KissTextEdit edtVerNameVorname;
        private KiSS4.Gui.KissCalcEdit edtVerPensum;
        private KiSS4.Gui.KissDateEdit edtVerVorschlag;
        private KissTextEdit edtVerZustaendig;
        private KiSS4.Gui.KissMemoEdit edtWeitereAnforderungen;
        private KiSS4.Gui.KissButtonEdit edtZustaendigKA;
        private KiSS4.Gui.KissLabel lblAdresseBetrieb;
        private KiSS4.Gui.KissLabel lblAnforderungen;
        private KiSS4.Gui.KissLabel lblAusbildung;
        private KiSS4.Gui.KissLabel lblAusbildungTyp;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissLabel lblBezeichnung;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblBranche;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblDetails;
        private KiSS4.Gui.KissLabel lblDeutschMuendlich;
        private KiSS4.Gui.KissLabel lblDeutschSchriftlich;
        private KiSS4.Gui.KissLabel lblEinsatz;
        private KiSS4.Gui.KissLabel lblEinsatzplatzNummer;
        private KiSS4.Gui.KissLabel lblEinzelpensumVon;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblGesamtpensum;
        private KiSS4.Gui.KissLabel lblGesamtpensumProzent;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblGrundinformationen;
        private KiSS4.Gui.KissLabel lblKaProgramm;
        private KiSS4.Gui.KissLabel lblKontaktBemerkung;
        private KiSS4.Gui.KissLabel lblKontaktFunktion;
        private KiSS4.Gui.KissLabel lblKontaktperson;
        private KiSS4.Gui.KissLabel lblKontaktpersonen;
        private KiSS4.Gui.KissLabel lblLehrberuf;
        private KiSS4.Gui.KissCheckEdit lblPCKentnisse;
        private KiSS4.Gui.KissLabel lblPensum;
        private KiSS4.Gui.KissLabel lblProzent;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblTelefonMobil;
        private KiSS4.Gui.KissLabel lblVerEinsatzBis;
        private KiSS4.Gui.KissLabel lblVerEinsatzVon;
        private KiSS4.Gui.KissLabel lblVerName;
        private KiSS4.Gui.KissLabel lblVerPensum;
        private KiSS4.Gui.KissLabel lblVerPensumProz;
        private KiSS4.Gui.KissLabel lblVerVorschlag;
        private KissLabel lblVerZustaendig;
        private KiSS4.Gui.KissLabel lblWeitereAnforderungen;
        private KiSS4.Gui.KissLabel lblZustaendig;
        private KiSS4.Gui.KissLabel lbProzent;
        private SharpLibrary.WinControls.TabPageEx tpgAnforderungen;
        private SharpLibrary.WinControls.TabPageEx tpgDauerPensum;
        private SharpLibrary.WinControls.TabPageEx tpgGrundinformationen;
        private SharpLibrary.WinControls.TabPageEx tpgKontakt;
        private SharpLibrary.WinControls.TabPageEx tpgVermittlung;

        #endregion

        #endregion

        #region Constructors

        public CtlKaEinsatzplaetzeDetail()
        {
            InitializeComponent();

            qryKaEinsatzplatz_PositionChanged(null, null);
            qryKaEinsatzplatz.EnableBoundFields(false);

            btnInfoBetrieb.Enabled = false;
            btnKopieren.Enabled = false;
            btnKontaktdatenAendern.Enabled = false;
            btnInformationenPerson.Enabled = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaEinsatzplaetzeDetail));
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
            this.tabBottom = new KiSS4.Gui.KissTabControlEx();
            this.tpgVermittlung = new SharpLibrary.WinControls.TabPageEx();
            this.edtVerZustaendig = new KiSS4.Gui.KissTextEdit();
            this.qryKaVermittlung = new KiSS4.DB.SqlQuery(this.components);
            this.lblVerZustaendig = new KiSS4.Gui.KissLabel();
            this.lblVerPensumProz = new KiSS4.Gui.KissLabel();
            this.edtVerPensum = new KiSS4.Gui.KissCalcEdit();
            this.edtVerNameVorname = new KiSS4.Gui.KissTextEdit();
            this.edtVerVorschlag = new KiSS4.Gui.KissDateEdit();
            this.edtVerEinsatzBis = new KiSS4.Gui.KissDateEdit();
            this.edtVerEinsatzVon = new KiSS4.Gui.KissDateEdit();
            this.btnInformationenPerson = new KiSS4.Gui.KissButton();
            this.lblVerPensum = new KiSS4.Gui.KissLabel();
            this.lblVerEinsatzBis = new KiSS4.Gui.KissLabel();
            this.lblVerEinsatzVon = new KiSS4.Gui.KissLabel();
            this.lblVerVorschlag = new KiSS4.Gui.KissLabel();
            this.lblVerName = new KiSS4.Gui.KissLabel();
            this.grdPersonen = new KiSS4.Gui.KissGrid();
            this.grvVermittlung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVermName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermZustaendig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgKontakt = new SharpLibrary.WinControls.TabPageEx();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.qryKaEinsatzplatz = new KiSS4.DB.SqlQuery(this.components);
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.edtTelefonMobil = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktpersonBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.btnKontaktdatenAendern = new KiSS4.Gui.KissButton();
            this.edtKontaktperson = new KiSS4.Gui.KissLookUpEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.lblTelefonMobil = new KiSS4.Gui.KissLabel();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtKontaktFunktion = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktBemerkung = new KiSS4.Gui.KissLabel();
            this.lblKontaktFunktion = new KiSS4.Gui.KissLabel();
            this.lblKontaktperson = new KiSS4.Gui.KissLabel();
            this.lblKontaktpersonen = new KiSS4.Gui.KissLabel();
            this.tpgDauerPensum = new SharpLibrary.WinControls.TabPageEx();
            this.lblPensum = new KiSS4.Gui.KissLabel();
            this.lblProzent = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.edtEinzelpensumBis = new KiSS4.Gui.KissCalcEdit();
            this.lbProzent = new KiSS4.Gui.KissLabel();
            this.lblGesamtpensumProzent = new KiSS4.Gui.KissLabel();
            this.edtEinzelpensumVon = new KiSS4.Gui.KissCalcEdit();
            this.lblEinzelpensumVon = new KiSS4.Gui.KissLabel();
            this.chkPensumUnbestimmt = new KiSS4.Gui.KissCheckEdit();
            this.chkAufteilbar = new KiSS4.Gui.KissCheckEdit();
            this.edtPensum = new KiSS4.Gui.KissCalcEdit();
            this.lblGesamtpensum = new KiSS4.Gui.KissLabel();
            this.chkUnbefristeteStelle = new KiSS4.Gui.KissCheckEdit();
            this.edtEinsatzAb = new KiSS4.Gui.KissDateEdit();
            this.lblEinsatz = new KiSS4.Gui.KissLabel();
            this.edtErfassungsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.tpgGrundinformationen = new SharpLibrary.WinControls.TabPageEx();
            this.docKaEinsatzplatz = new KiSS4.Dokument.KissDocumentButton();
            this.btnKopieren = new KiSS4.Gui.KissButton();
            this.edtDetails = new KiSS4.Gui.KissMemoEdit();
            this.lblDetails = new KiSS4.Gui.KissLabel();
            this.chkNeuGeschaffeneLehrstelle = new KiSS4.Gui.KissCheckEdit();
            this.edtTypAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.lblAusbildungTyp = new KiSS4.Gui.KissLabel();
            this.edtLehrberuf = new KiSS4.Gui.KissLookUpEdit();
            this.lblLehrberuf = new KiSS4.Gui.KissLabel();
            this.edtZustaendigKA = new KiSS4.Gui.KissButtonEdit();
            this.lblZustaendig = new KiSS4.Gui.KissLabel();
            this.edtKaProgramm = new KiSS4.Gui.KissLookUpEdit();
            this.lblKaProgramm = new KiSS4.Gui.KissLabel();
            this.edtEinsatzplatzNummer = new KiSS4.Gui.KissTextEdit();
            this.lblEinsatzplatzNummer = new KiSS4.Gui.KissLabel();
            this.btnInfoBetrieb = new KiSS4.Gui.KissButton();
            this.edtAdresseBetrieb = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseBetrieb = new KiSS4.Gui.KissLabel();
            this.edtBetrieb = new KiSS4.Gui.KissButtonEdit();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.edtBranche = new KiSS4.Gui.KissLookUpEdit();
            this.lblBranche = new KiSS4.Gui.KissLabel();
            this.edtBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.lblBezeichnung = new KiSS4.Gui.KissLabel();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            this.lblGrundinformationen = new KiSS4.Gui.KissLabel();
            this.tpgAnforderungen = new SharpLibrary.WinControls.TabPageEx();
            this.lblWeitereAnforderungen = new KiSS4.Gui.KissLabel();
            this.lblAusbildung = new KiSS4.Gui.KissLabel();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.lblDeutschSchriftlich = new KiSS4.Gui.KissLabel();
            this.lblDeutschMuendlich = new KiSS4.Gui.KissLabel();
            this.lblAnforderungen = new KiSS4.Gui.KissLabel();
            this.edtWeitereAnforderungen = new KiSS4.Gui.KissMemoEdit();
            this.edtAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.edtEinsatzplatzGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.edtDeutschSchriftlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblPCKentnisse = new KiSS4.Gui.KissCheckEdit();
            this.edtDeutschMuendlich = new KiSS4.Gui.KissLookUpEdit();
            this.edtFuehrerausweisKategorie = new KiSS4.Gui.KissLookUpEdit();
            this.chkFuehrerausweis = new KiSS4.Gui.KissCheckEdit();
            this.qryKaKontaktperson = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tabBottom.SuspendLayout();
            this.tpgVermittlung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerZustaendig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaVermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerZustaendig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerPensumProz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerPensum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerNameVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerVorschlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerEinsatzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerEinsatzVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerPensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerEinsatzBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerEinsatzVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerVorschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlung)).BeginInit();
            this.tpgKontakt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonMobil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktpersonBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFunktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFunktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFunktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpersonen)).BeginInit();
            this.tpgDauerPensum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelpensumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesamtpensumProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelpensumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelpensumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPensumUnbestimmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAufteilbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesamtpensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnbefristeteStelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            this.tpgGrundinformationen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDetails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNeuGeschaffeneLehrstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildungTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundinformationen)).BeginInit();
            this.tpgAnforderungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeitereAnforderungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschSchriftlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschMuendlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnforderungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeitereAnforderungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKentnisse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFuehrerausweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKontaktperson)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(779, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(803, 261);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            //
            // tpgListe
            //
            this.tpgListe.Size = new System.Drawing.Size(791, 223);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Size = new System.Drawing.Size(791, 223);
            this.tpgSuchen.Title = "Suche";
            //
            // tabBottom
            //
            this.tabBottom.Controls.Add(this.tpgVermittlung);
            this.tabBottom.Controls.Add(this.tpgKontakt);
            this.tabBottom.Controls.Add(this.tpgDauerPensum);
            this.tabBottom.Controls.Add(this.tpgGrundinformationen);
            this.tabBottom.Controls.Add(this.tpgAnforderungen);
            this.tabBottom.Location = new System.Drawing.Point(3, 270);
            this.tabBottom.Name = "tabBottom";
            this.tabBottom.ShowFixedWidthTooltip = true;
            this.tabBottom.Size = new System.Drawing.Size(803, 306);
            this.tabBottom.TabIndex = 31;
            this.tabBottom.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgGrundinformationen,
            this.tpgDauerPensum,
            this.tpgAnforderungen,
            this.tpgKontakt,
            this.tpgVermittlung});
            this.tabBottom.TabsLineColor = System.Drawing.Color.Black;
            this.tabBottom.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBottom.Text = "kissTabControlEx1";
            this.tabBottom.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabBottom_SelectedTabChanged);
            this.tabBottom.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabBottom_SelectedTabChanging);
            //
            // tpgVermittlung
            //
            this.tpgVermittlung.Controls.Add(this.edtVerZustaendig);
            this.tpgVermittlung.Controls.Add(this.lblVerZustaendig);
            this.tpgVermittlung.Controls.Add(this.lblVerPensumProz);
            this.tpgVermittlung.Controls.Add(this.edtVerPensum);
            this.tpgVermittlung.Controls.Add(this.edtVerNameVorname);
            this.tpgVermittlung.Controls.Add(this.edtVerVorschlag);
            this.tpgVermittlung.Controls.Add(this.edtVerEinsatzBis);
            this.tpgVermittlung.Controls.Add(this.edtVerEinsatzVon);
            this.tpgVermittlung.Controls.Add(this.btnInformationenPerson);
            this.tpgVermittlung.Controls.Add(this.lblVerPensum);
            this.tpgVermittlung.Controls.Add(this.lblVerEinsatzBis);
            this.tpgVermittlung.Controls.Add(this.lblVerEinsatzVon);
            this.tpgVermittlung.Controls.Add(this.lblVerVorschlag);
            this.tpgVermittlung.Controls.Add(this.lblVerName);
            this.tpgVermittlung.Controls.Add(this.grdPersonen);
            this.tpgVermittlung.Location = new System.Drawing.Point(6, 6);
            this.tpgVermittlung.Name = "tpgVermittlung";
            this.tpgVermittlung.Size = new System.Drawing.Size(791, 268);
            this.tpgVermittlung.TabIndex = 4;
            this.tpgVermittlung.Title = "Vermittlung";
            //
            // edtVerZustaendig
            //
            this.edtVerZustaendig.DataMember = "Zustaendig";
            this.edtVerZustaendig.DataSource = this.qryKaVermittlung;
            this.edtVerZustaendig.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerZustaendig.Location = new System.Drawing.Point(107, 240);
            this.edtVerZustaendig.Name = "edtVerZustaendig";
            this.edtVerZustaendig.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerZustaendig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerZustaendig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerZustaendig.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerZustaendig.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerZustaendig.Properties.Appearance.Options.UseFont = true;
            this.edtVerZustaendig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerZustaendig.Properties.ReadOnly = true;
            this.edtVerZustaendig.Size = new System.Drawing.Size(263, 24);
            this.edtVerZustaendig.TabIndex = 19;
            //
            // qryKaVermittlung
            //
            this.qryKaVermittlung.HostControl = this;
            this.qryKaVermittlung.SelectStatement = resources.GetString("qryKaVermittlung.SelectStatement");
            this.qryKaVermittlung.TableName = "KaVermittlungVorschlag";
            this.qryKaVermittlung.AfterFill += new System.EventHandler(this.qryKaVermittlung_AfterFill);
            this.qryKaVermittlung.PositionChanged += new System.EventHandler(this.qryKaVermittlung_PositionChanged);
            //
            // lblVerZustaendig
            //
            this.lblVerZustaendig.Location = new System.Drawing.Point(3, 240);
            this.lblVerZustaendig.Name = "lblVerZustaendig";
            this.lblVerZustaendig.Size = new System.Drawing.Size(98, 24);
            this.lblVerZustaendig.TabIndex = 18;
            this.lblVerZustaendig.Text = "zuständig KA";
            this.lblVerZustaendig.UseCompatibleTextRendering = true;
            //
            // lblVerPensumProz
            //
            this.lblVerPensumProz.Location = new System.Drawing.Point(214, 210);
            this.lblVerPensumProz.Name = "lblVerPensumProz";
            this.lblVerPensumProz.Size = new System.Drawing.Size(15, 24);
            this.lblVerPensumProz.TabIndex = 16;
            this.lblVerPensumProz.Text = "%";
            this.lblVerPensumProz.UseCompatibleTextRendering = true;
            //
            // edtVerPensum
            //
            this.edtVerPensum.DataMember = "Pensum";
            this.edtVerPensum.DataSource = this.qryKaVermittlung;
            this.edtVerPensum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerPensum.Location = new System.Drawing.Point(107, 210);
            this.edtVerPensum.Name = "edtVerPensum";
            this.edtVerPensum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerPensum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerPensum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerPensum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerPensum.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerPensum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerPensum.Properties.Appearance.Options.UseFont = true;
            this.edtVerPensum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerPensum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerPensum.Properties.ReadOnly = true;
            this.edtVerPensum.Size = new System.Drawing.Size(101, 24);
            this.edtVerPensum.TabIndex = 15;
            //
            // edtVerNameVorname
            //
            this.edtVerNameVorname.DataMember = "NameVorname";
            this.edtVerNameVorname.DataSource = this.qryKaVermittlung;
            this.edtVerNameVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerNameVorname.Location = new System.Drawing.Point(107, 150);
            this.edtVerNameVorname.Name = "edtVerNameVorname";
            this.edtVerNameVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerNameVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerNameVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerNameVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerNameVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerNameVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVerNameVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerNameVorname.Properties.ReadOnly = true;
            this.edtVerNameVorname.Size = new System.Drawing.Size(263, 24);
            this.edtVerNameVorname.TabIndex = 10;
            //
            // edtVerVorschlag
            //
            this.edtVerVorschlag.DataMember = "Vorschlag";
            this.edtVerVorschlag.DataSource = this.qryKaVermittlung;
            this.edtVerVorschlag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerVorschlag.EditValue = null;
            this.edtVerVorschlag.Location = new System.Drawing.Point(107, 180);
            this.edtVerVorschlag.Name = "edtVerVorschlag";
            this.edtVerVorschlag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerVorschlag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerVorschlag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerVorschlag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerVorschlag.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerVorschlag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerVorschlag.Properties.Appearance.Options.UseFont = true;
            this.edtVerVorschlag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtVerVorschlag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerVorschlag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtVerVorschlag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerVorschlag.Properties.ReadOnly = true;
            this.edtVerVorschlag.Properties.ShowToday = false;
            this.edtVerVorschlag.Size = new System.Drawing.Size(101, 24);
            this.edtVerVorschlag.TabIndex = 9;
            //
            // edtVerEinsatzBis
            //
            this.edtVerEinsatzBis.DataMember = "EinsatzBis";
            this.edtVerEinsatzBis.DataSource = this.qryKaVermittlung;
            this.edtVerEinsatzBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerEinsatzBis.EditValue = null;
            this.edtVerEinsatzBis.Location = new System.Drawing.Point(445, 180);
            this.edtVerEinsatzBis.Name = "edtVerEinsatzBis";
            this.edtVerEinsatzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerEinsatzBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerEinsatzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerEinsatzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerEinsatzBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerEinsatzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerEinsatzBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerEinsatzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVerEinsatzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerEinsatzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVerEinsatzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerEinsatzBis.Properties.ReadOnly = true;
            this.edtVerEinsatzBis.Properties.ShowToday = false;
            this.edtVerEinsatzBis.Size = new System.Drawing.Size(101, 24);
            this.edtVerEinsatzBis.TabIndex = 8;
            //
            // edtVerEinsatzVon
            //
            this.edtVerEinsatzVon.DataMember = "EinsatzVon";
            this.edtVerEinsatzVon.DataSource = this.qryKaVermittlung;
            this.edtVerEinsatzVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerEinsatzVon.EditValue = null;
            this.edtVerEinsatzVon.Location = new System.Drawing.Point(306, 180);
            this.edtVerEinsatzVon.Name = "edtVerEinsatzVon";
            this.edtVerEinsatzVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerEinsatzVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerEinsatzVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerEinsatzVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerEinsatzVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerEinsatzVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerEinsatzVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerEinsatzVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtVerEinsatzVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerEinsatzVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtVerEinsatzVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerEinsatzVon.Properties.ReadOnly = true;
            this.edtVerEinsatzVon.Properties.ShowToday = false;
            this.edtVerEinsatzVon.Size = new System.Drawing.Size(101, 24);
            this.edtVerEinsatzVon.TabIndex = 7;
            //
            // btnInformationenPerson
            //
            this.btnInformationenPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformationenPerson.Location = new System.Drawing.Point(523, 150);
            this.btnInformationenPerson.Name = "btnInformationenPerson";
            this.btnInformationenPerson.Size = new System.Drawing.Size(106, 24);
            this.btnInformationenPerson.TabIndex = 6;
            this.btnInformationenPerson.Text = "Info zur Person";
            this.btnInformationenPerson.UseCompatibleTextRendering = true;
            this.btnInformationenPerson.UseVisualStyleBackColor = false;
            this.btnInformationenPerson.Click += new System.EventHandler(this.btnInformationenPerson_Click);
            //
            // lblVerPensum
            //
            this.lblVerPensum.Location = new System.Drawing.Point(3, 210);
            this.lblVerPensum.Name = "lblVerPensum";
            this.lblVerPensum.Size = new System.Drawing.Size(98, 24);
            this.lblVerPensum.TabIndex = 5;
            this.lblVerPensum.Text = "Pensum";
            this.lblVerPensum.UseCompatibleTextRendering = true;
            //
            // lblVerEinsatzBis
            //
            this.lblVerEinsatzBis.Location = new System.Drawing.Point(413, 180);
            this.lblVerEinsatzBis.Name = "lblVerEinsatzBis";
            this.lblVerEinsatzBis.Size = new System.Drawing.Size(26, 24);
            this.lblVerEinsatzBis.TabIndex = 4;
            this.lblVerEinsatzBis.Text = "bis";
            this.lblVerEinsatzBis.UseCompatibleTextRendering = true;
            //
            // lblVerEinsatzVon
            //
            this.lblVerEinsatzVon.Location = new System.Drawing.Point(230, 180);
            this.lblVerEinsatzVon.Name = "lblVerEinsatzVon";
            this.lblVerEinsatzVon.Size = new System.Drawing.Size(70, 24);
            this.lblVerEinsatzVon.TabIndex = 3;
            this.lblVerEinsatzVon.Text = "Einsatz von";
            this.lblVerEinsatzVon.UseCompatibleTextRendering = true;
            //
            // lblVerVorschlag
            //
            this.lblVerVorschlag.Location = new System.Drawing.Point(3, 180);
            this.lblVerVorschlag.Name = "lblVerVorschlag";
            this.lblVerVorschlag.Size = new System.Drawing.Size(98, 24);
            this.lblVerVorschlag.TabIndex = 2;
            this.lblVerVorschlag.Text = "Vorschlag erfasst";
            this.lblVerVorschlag.UseCompatibleTextRendering = true;
            //
            // lblVerName
            //
            this.lblVerName.Location = new System.Drawing.Point(3, 150);
            this.lblVerName.Name = "lblVerName";
            this.lblVerName.Size = new System.Drawing.Size(98, 24);
            this.lblVerName.TabIndex = 1;
            this.lblVerName.Text = "Name / Vorname";
            this.lblVerName.UseCompatibleTextRendering = true;
            //
            // grdPersonen
            //
            this.grdPersonen.DataSource = this.qryKaVermittlung;
            //
            //
            //
            this.grdPersonen.EmbeddedNavigator.Name = "";
            this.grdPersonen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPersonen.Location = new System.Drawing.Point(2, 0);
            this.grdPersonen.MainView = this.grvVermittlung;
            this.grdPersonen.Name = "grdPersonen";
            this.grdPersonen.Size = new System.Drawing.Size(746, 141);
            this.grdPersonen.TabIndex = 0;
            this.grdPersonen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVermittlung});
            //
            // grvVermittlung
            //
            this.grvVermittlung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVermittlung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.Empty.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.Empty.Options.UseFont = true;
            this.grvVermittlung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.EvenRow.Options.UseFont = true;
            this.grvVermittlung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVermittlung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVermittlung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVermittlung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVermittlung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVermittlung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVermittlung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVermittlung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVermittlung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVermittlung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVermittlung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.GroupRow.Options.UseFont = true;
            this.grvVermittlung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVermittlung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVermittlung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVermittlung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVermittlung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVermittlung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVermittlung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVermittlung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVermittlung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVermittlung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVermittlung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVermittlung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.OddRow.Options.UseFont = true;
            this.grvVermittlung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVermittlung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.Row.Options.UseBackColor = true;
            this.grvVermittlung.Appearance.Row.Options.UseFont = true;
            this.grvVermittlung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVermittlung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVermittlung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVermittlung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVermittlung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVermName,
            this.colVermVorname,
            this.colVorschlag,
            this.colVermDatumVon,
            this.colVermDatumBis,
            this.colVermPensum,
            this.colVermZustaendig});
            this.grvVermittlung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVermittlung.GridControl = this.grdPersonen;
            this.grvVermittlung.Name = "grvVermittlung";
            this.grvVermittlung.OptionsBehavior.Editable = false;
            this.grvVermittlung.OptionsCustomization.AllowFilter = false;
            this.grvVermittlung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVermittlung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVermittlung.OptionsNavigation.UseTabKey = false;
            this.grvVermittlung.OptionsView.ColumnAutoWidth = false;
            this.grvVermittlung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVermittlung.OptionsView.ShowGroupPanel = false;
            this.grvVermittlung.OptionsView.ShowIndicator = false;
            //
            // colVermName
            //
            this.colVermName.Caption = "Name";
            this.colVermName.FieldName = "Name";
            this.colVermName.Name = "colVermName";
            this.colVermName.Visible = true;
            this.colVermName.VisibleIndex = 0;
            this.colVermName.Width = 150;
            //
            // colVermVorname
            //
            this.colVermVorname.Caption = "Vorname";
            this.colVermVorname.FieldName = "Vorname";
            this.colVermVorname.Name = "colVermVorname";
            this.colVermVorname.Visible = true;
            this.colVermVorname.VisibleIndex = 1;
            this.colVermVorname.Width = 150;
            //
            // colVorschlag
            //
            this.colVorschlag.Caption = "Vorschlag";
            this.colVorschlag.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colVorschlag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVorschlag.FieldName = "Vorschlag";
            this.colVorschlag.Name = "colVorschlag";
            this.colVorschlag.Visible = true;
            this.colVorschlag.VisibleIndex = 2;
            //
            // colVermDatumVon
            //
            this.colVermDatumVon.Caption = "Einsatz von";
            this.colVermDatumVon.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colVermDatumVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVermDatumVon.FieldName = "EinsatzVon";
            this.colVermDatumVon.Name = "colVermDatumVon";
            this.colVermDatumVon.Visible = true;
            this.colVermDatumVon.VisibleIndex = 3;
            //
            // colVermDatumBis
            //
            this.colVermDatumBis.Caption = "bis";
            this.colVermDatumBis.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colVermDatumBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVermDatumBis.FieldName = "EinsatzBis";
            this.colVermDatumBis.Name = "colVermDatumBis";
            this.colVermDatumBis.Visible = true;
            this.colVermDatumBis.VisibleIndex = 4;
            //
            // colVermPensum
            //
            this.colVermPensum.Caption = "Pensum";
            this.colVermPensum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVermPensum.FieldName = "Pensum";
            this.colVermPensum.Name = "colVermPensum";
            this.colVermPensum.Visible = true;
            this.colVermPensum.VisibleIndex = 5;
            this.colVermPensum.Width = 70;
            //
            // colVermZustaendig
            //
            this.colVermZustaendig.Caption = "zuständig KA";
            this.colVermZustaendig.FieldName = "Zustaendig";
            this.colVermZustaendig.Name = "colVermZustaendig";
            this.colVermZustaendig.Visible = true;
            this.colVermZustaendig.VisibleIndex = 6;
            this.colVermZustaendig.Width = 136;
            //
            // tpgKontakt
            //
            this.tpgKontakt.Controls.Add(this.edtEMail);
            this.tpgKontakt.Controls.Add(this.edtFax);
            this.tpgKontakt.Controls.Add(this.edtTelefonMobil);
            this.tpgKontakt.Controls.Add(this.edtTelefon);
            this.tpgKontakt.Controls.Add(this.edtKontaktpersonBemerkung);
            this.tpgKontakt.Controls.Add(this.btnKontaktdatenAendern);
            this.tpgKontakt.Controls.Add(this.edtKontaktperson);
            this.tpgKontakt.Controls.Add(this.lblEmail);
            this.tpgKontakt.Controls.Add(this.lblFax);
            this.tpgKontakt.Controls.Add(this.lblTelefonMobil);
            this.tpgKontakt.Controls.Add(this.lblTelefon);
            this.tpgKontakt.Controls.Add(this.edtKontaktFunktion);
            this.tpgKontakt.Controls.Add(this.lblKontaktBemerkung);
            this.tpgKontakt.Controls.Add(this.lblKontaktFunktion);
            this.tpgKontakt.Controls.Add(this.lblKontaktperson);
            this.tpgKontakt.Controls.Add(this.lblKontaktpersonen);
            this.tpgKontakt.Location = new System.Drawing.Point(6, 6);
            this.tpgKontakt.Name = "tpgKontakt";
            this.tpgKontakt.Size = new System.Drawing.Size(791, 268);
            this.tpgKontakt.TabIndex = 3;
            this.tpgKontakt.Title = "Kontaktperson";
            //
            // edtEMail
            //
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryKaEinsatzplatz;
            this.edtEMail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEMail.Location = new System.Drawing.Point(584, 104);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Properties.ReadOnly = true;
            this.edtEMail.Size = new System.Drawing.Size(194, 24);
            this.edtEMail.TabIndex = 33;
            //
            // qryKaEinsatzplatz
            //
            this.qryKaEinsatzplatz.CanDelete = true;
            this.qryKaEinsatzplatz.CanInsert = true;
            this.qryKaEinsatzplatz.CanUpdate = true;
            this.qryKaEinsatzplatz.HostControl = this;
            this.qryKaEinsatzplatz.SelectStatement = resources.GetString("qryKaEinsatzplatz.SelectStatement");
            this.qryKaEinsatzplatz.TableName = "KaEinsatzplatz";
            this.qryKaEinsatzplatz.AfterFill += new System.EventHandler(this.qryKaEinsatzplatz_AfterFill);
            this.qryKaEinsatzplatz.BeforeInsert += new System.EventHandler(this.qryKaEinsatzplatz_BeforeInsert);
            this.qryKaEinsatzplatz.AfterInsert += new System.EventHandler(this.qryKaEinsatzplatz_AfterInsert);
            this.qryKaEinsatzplatz.BeforePost += new System.EventHandler(this.qryKaEinsatzplatz_BeforePost);
            this.qryKaEinsatzplatz.AfterPost += new System.EventHandler(this.qryKaEinsatzplatz_AfterPost);
            this.qryKaEinsatzplatz.PositionChanged += new System.EventHandler(this.qryKaEinsatzplatz_PositionChanged);
            //
            // edtFax
            //
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryKaEinsatzplatz;
            this.edtFax.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFax.Location = new System.Drawing.Point(584, 81);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Properties.ReadOnly = true;
            this.edtFax.Size = new System.Drawing.Size(194, 24);
            this.edtFax.TabIndex = 32;
            //
            // edtTelefonMobil
            //
            this.edtTelefonMobil.DataMember = "TelefonMobil";
            this.edtTelefonMobil.DataSource = this.qryKaEinsatzplatz;
            this.edtTelefonMobil.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefonMobil.Location = new System.Drawing.Point(584, 58);
            this.edtTelefonMobil.Name = "edtTelefonMobil";
            this.edtTelefonMobil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefonMobil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonMobil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonMobil.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonMobil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonMobil.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonMobil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefonMobil.Properties.ReadOnly = true;
            this.edtTelefonMobil.Size = new System.Drawing.Size(194, 24);
            this.edtTelefonMobil.TabIndex = 31;
            //
            // edtTelefon
            //
            this.edtTelefon.DataMember = "Telefon";
            this.edtTelefon.DataSource = this.qryKaEinsatzplatz;
            this.edtTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon.Location = new System.Drawing.Point(584, 35);
            this.edtTelefon.Name = "edtTelefon";
            this.edtTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon.Properties.ReadOnly = true;
            this.edtTelefon.Size = new System.Drawing.Size(194, 24);
            this.edtTelefon.TabIndex = 30;
            //
            // edtKontaktpersonBemerkung
            //
            this.edtKontaktpersonBemerkung.DataMember = "Bemerkung";
            this.edtKontaktpersonBemerkung.DataSource = this.qryKaEinsatzplatz;
            this.edtKontaktpersonBemerkung.Location = new System.Drawing.Point(98, 93);
            this.edtKontaktpersonBemerkung.Name = "edtKontaktpersonBemerkung";
            this.edtKontaktpersonBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktpersonBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktpersonBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktpersonBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktpersonBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktpersonBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktpersonBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktpersonBemerkung.Size = new System.Drawing.Size(375, 142);
            this.edtKontaktpersonBemerkung.TabIndex = 19;
            //
            // btnKontaktdatenAendern
            //
            this.btnKontaktdatenAendern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKontaktdatenAendern.Location = new System.Drawing.Point(584, 144);
            this.btnKontaktdatenAendern.Name = "btnKontaktdatenAendern";
            this.btnKontaktdatenAendern.Size = new System.Drawing.Size(129, 24);
            this.btnKontaktdatenAendern.TabIndex = 18;
            this.btnKontaktdatenAendern.Text = "Kontaktdaten ändern";
            this.btnKontaktdatenAendern.UseCompatibleTextRendering = true;
            this.btnKontaktdatenAendern.UseVisualStyleBackColor = false;
            this.btnKontaktdatenAendern.Click += new System.EventHandler(this.btnKontaktdatenAendern_Click);
            //
            // edtKontaktperson
            //
            this.edtKontaktperson.DataMember = "KaKontaktpersonID";
            this.edtKontaktperson.DataSource = this.qryKaEinsatzplatz;
            this.edtKontaktperson.Location = new System.Drawing.Point(98, 33);
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
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKontaktperson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktperson.Properties.NullText = "";
            this.edtKontaktperson.Properties.ShowFooter = false;
            this.edtKontaktperson.Properties.ShowHeader = false;
            this.edtKontaktperson.Size = new System.Drawing.Size(375, 24);
            this.edtKontaktperson.TabIndex = 17;
            this.edtKontaktperson.EditValueChanged += new System.EventHandler(this.edtKontaktperson_EditValueChanged);
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(495, 105);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(83, 24);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.UseCompatibleTextRendering = true;
            //
            // lblFax
            //
            this.lblFax.Location = new System.Drawing.Point(495, 81);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(83, 24);
            this.lblFax.TabIndex = 15;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            //
            // lblTelefonMobil
            //
            this.lblTelefonMobil.Location = new System.Drawing.Point(495, 57);
            this.lblTelefonMobil.Name = "lblTelefonMobil";
            this.lblTelefonMobil.Size = new System.Drawing.Size(83, 24);
            this.lblTelefonMobil.TabIndex = 14;
            this.lblTelefonMobil.Text = "Telefon mobil";
            this.lblTelefonMobil.UseCompatibleTextRendering = true;
            //
            // lblTelefon
            //
            this.lblTelefon.Location = new System.Drawing.Point(495, 33);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(83, 24);
            this.lblTelefon.TabIndex = 13;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            //
            // edtKontaktFunktion
            //
            this.edtKontaktFunktion.DataMember = "FunktionCode";
            this.edtKontaktFunktion.DataSource = this.qryKaEinsatzplatz;
            this.edtKontaktFunktion.Location = new System.Drawing.Point(98, 63);
            this.edtKontaktFunktion.LOVName = "KaEinsatzplatzKontaktFunktion";
            this.edtKontaktFunktion.Name = "edtKontaktFunktion";
            this.edtKontaktFunktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktFunktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktFunktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktFunktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktFunktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktFunktion.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktFunktion.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktFunktion.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktFunktion.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktFunktion.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktFunktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKontaktFunktion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKontaktFunktion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktFunktion.Properties.NullText = "";
            this.edtKontaktFunktion.Properties.ShowFooter = false;
            this.edtKontaktFunktion.Properties.ShowHeader = false;
            this.edtKontaktFunktion.Size = new System.Drawing.Size(375, 24);
            this.edtKontaktFunktion.TabIndex = 11;
            //
            // lblKontaktBemerkung
            //
            this.lblKontaktBemerkung.Location = new System.Drawing.Point(4, 85);
            this.lblKontaktBemerkung.Name = "lblKontaktBemerkung";
            this.lblKontaktBemerkung.Size = new System.Drawing.Size(75, 24);
            this.lblKontaktBemerkung.TabIndex = 4;
            this.lblKontaktBemerkung.Text = "Bemerkung";
            this.lblKontaktBemerkung.UseCompatibleTextRendering = true;
            //
            // lblKontaktFunktion
            //
            this.lblKontaktFunktion.Location = new System.Drawing.Point(4, 61);
            this.lblKontaktFunktion.Name = "lblKontaktFunktion";
            this.lblKontaktFunktion.Size = new System.Drawing.Size(75, 24);
            this.lblKontaktFunktion.TabIndex = 2;
            this.lblKontaktFunktion.Text = "Funktion";
            this.lblKontaktFunktion.UseCompatibleTextRendering = true;
            //
            // lblKontaktperson
            //
            this.lblKontaktperson.Location = new System.Drawing.Point(4, 32);
            this.lblKontaktperson.Name = "lblKontaktperson";
            this.lblKontaktperson.Size = new System.Drawing.Size(88, 24);
            this.lblKontaktperson.TabIndex = 1;
            this.lblKontaktperson.Text = "Kontaktperson";
            this.lblKontaktperson.UseCompatibleTextRendering = true;
            //
            // lblKontaktpersonen
            //
            this.lblKontaktpersonen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKontaktpersonen.Location = new System.Drawing.Point(4, 4);
            this.lblKontaktpersonen.Name = "lblKontaktpersonen";
            this.lblKontaktpersonen.Size = new System.Drawing.Size(119, 16);
            this.lblKontaktpersonen.TabIndex = 0;
            this.lblKontaktpersonen.Text = "Kontaktperson";
            this.lblKontaktpersonen.UseCompatibleTextRendering = true;
            //
            // tpgDauerPensum
            //
            this.tpgDauerPensum.Controls.Add(this.lblPensum);
            this.tpgDauerPensum.Controls.Add(this.lblProzent);
            this.tpgDauerPensum.Controls.Add(this.lblBis);
            this.tpgDauerPensum.Controls.Add(this.edtEinzelpensumBis);
            this.tpgDauerPensum.Controls.Add(this.lbProzent);
            this.tpgDauerPensum.Controls.Add(this.lblGesamtpensumProzent);
            this.tpgDauerPensum.Controls.Add(this.edtEinzelpensumVon);
            this.tpgDauerPensum.Controls.Add(this.lblEinzelpensumVon);
            this.tpgDauerPensum.Controls.Add(this.chkPensumUnbestimmt);
            this.tpgDauerPensum.Controls.Add(this.chkAufteilbar);
            this.tpgDauerPensum.Controls.Add(this.edtPensum);
            this.tpgDauerPensum.Controls.Add(this.lblGesamtpensum);
            this.tpgDauerPensum.Controls.Add(this.chkUnbefristeteStelle);
            this.tpgDauerPensum.Controls.Add(this.edtEinsatzAb);
            this.tpgDauerPensum.Controls.Add(this.lblEinsatz);
            this.tpgDauerPensum.Controls.Add(this.edtErfassungsdatum);
            this.tpgDauerPensum.Controls.Add(this.lblDatumVon);
            this.tpgDauerPensum.Location = new System.Drawing.Point(6, 6);
            this.tpgDauerPensum.Name = "tpgDauerPensum";
            this.tpgDauerPensum.Size = new System.Drawing.Size(791, 268);
            this.tpgDauerPensum.TabIndex = 1;
            this.tpgDauerPensum.Title = "Dauer/Pensum";
            //
            // lblPensum
            //
            this.lblPensum.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblPensum.Location = new System.Drawing.Point(4, 82);
            this.lblPensum.Name = "lblPensum";
            this.lblPensum.Size = new System.Drawing.Size(100, 16);
            this.lblPensum.TabIndex = 19;
            this.lblPensum.Text = "Pensum";
            this.lblPensum.UseCompatibleTextRendering = true;
            //
            // lblProzent
            //
            this.lblProzent.Location = new System.Drawing.Point(264, 173);
            this.lblProzent.Name = "lblProzent";
            this.lblProzent.Size = new System.Drawing.Size(20, 24);
            this.lblProzent.TabIndex = 18;
            this.lblProzent.Text = "%";
            this.lblProzent.UseCompatibleTextRendering = true;
            //
            // lblBis
            //
            this.lblBis.Location = new System.Drawing.Point(187, 172);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(20, 24);
            this.lblBis.TabIndex = 17;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            //
            // edtEinzelpensumBis
            //
            this.edtEinzelpensumBis.DataMember = "EinzelpensumMaximum";
            this.edtEinzelpensumBis.DataSource = this.qryKaEinsatzplatz;
            this.edtEinzelpensumBis.Location = new System.Drawing.Point(213, 172);
            this.edtEinzelpensumBis.Name = "edtEinzelpensumBis";
            this.edtEinzelpensumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinzelpensumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzelpensumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzelpensumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelpensumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzelpensumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzelpensumBis.Properties.Appearance.Options.UseFont = true;
            this.edtEinzelpensumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinzelpensumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzelpensumBis.Size = new System.Drawing.Size(45, 24);
            this.edtEinzelpensumBis.TabIndex = 16;
            //
            // lbProzent
            //
            this.lbProzent.Location = new System.Drawing.Point(162, 172);
            this.lbProzent.Name = "lbProzent";
            this.lbProzent.Size = new System.Drawing.Size(19, 24);
            this.lbProzent.TabIndex = 15;
            this.lbProzent.Text = "%";
            this.lbProzent.UseCompatibleTextRendering = true;
            //
            // lblGesamtpensumProzent
            //
            this.lblGesamtpensumProzent.Location = new System.Drawing.Point(196, 104);
            this.lblGesamtpensumProzent.Name = "lblGesamtpensumProzent";
            this.lblGesamtpensumProzent.Size = new System.Drawing.Size(15, 24);
            this.lblGesamtpensumProzent.TabIndex = 14;
            this.lblGesamtpensumProzent.Text = "%";
            this.lblGesamtpensumProzent.UseCompatibleTextRendering = true;
            //
            // edtEinzelpensumVon
            //
            this.edtEinzelpensumVon.DataMember = "EinzelpensumMinimum";
            this.edtEinzelpensumVon.DataSource = this.qryKaEinsatzplatz;
            this.edtEinzelpensumVon.Location = new System.Drawing.Point(111, 172);
            this.edtEinzelpensumVon.Name = "edtEinzelpensumVon";
            this.edtEinzelpensumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinzelpensumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzelpensumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzelpensumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelpensumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzelpensumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzelpensumVon.Properties.Appearance.Options.UseFont = true;
            this.edtEinzelpensumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinzelpensumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzelpensumVon.Size = new System.Drawing.Size(45, 24);
            this.edtEinzelpensumVon.TabIndex = 13;
            //
            // lblEinzelpensumVon
            //
            this.lblEinzelpensumVon.Location = new System.Drawing.Point(4, 173);
            this.lblEinzelpensumVon.Name = "lblEinzelpensumVon";
            this.lblEinzelpensumVon.Size = new System.Drawing.Size(96, 24);
            this.lblEinzelpensumVon.TabIndex = 12;
            this.lblEinzelpensumVon.Text = "Einzelpensum von";
            this.lblEinzelpensumVon.UseCompatibleTextRendering = true;
            //
            // chkPensumUnbestimmt
            //
            this.chkPensumUnbestimmt.DataMember = "PensumUnbestimmt";
            this.chkPensumUnbestimmt.DataSource = this.qryKaEinsatzplatz;
            this.chkPensumUnbestimmt.Location = new System.Drawing.Point(111, 134);
            this.chkPensumUnbestimmt.Name = "chkPensumUnbestimmt";
            this.chkPensumUnbestimmt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkPensumUnbestimmt.Properties.Appearance.Options.UseBackColor = true;
            this.chkPensumUnbestimmt.Properties.Caption = "Pensum unbestimmt";
            this.chkPensumUnbestimmt.Size = new System.Drawing.Size(126, 19);
            this.chkPensumUnbestimmt.TabIndex = 11;
            this.chkPensumUnbestimmt.CheckedChanged += new System.EventHandler(this.chkPensumUnbestimmt_CheckedChanged);
            //
            // chkAufteilbar
            //
            this.chkAufteilbar.DataMember = "PensumAufteilbar";
            this.chkAufteilbar.DataSource = this.qryKaEinsatzplatz;
            this.chkAufteilbar.Location = new System.Drawing.Point(216, 110);
            this.chkAufteilbar.Name = "chkAufteilbar";
            this.chkAufteilbar.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAufteilbar.Properties.Appearance.Options.UseBackColor = true;
            this.chkAufteilbar.Properties.Caption = "aufteilbar";
            this.chkAufteilbar.Size = new System.Drawing.Size(75, 19);
            this.chkAufteilbar.TabIndex = 10;
            this.chkAufteilbar.CheckedChanged += new System.EventHandler(this.chkAufteilbar_CheckedChanged);
            //
            // edtPensum
            //
            this.edtPensum.DataMember = "GesamtPensum";
            this.edtPensum.DataSource = this.qryKaEinsatzplatz;
            this.edtPensum.Location = new System.Drawing.Point(111, 105);
            this.edtPensum.Name = "edtPensum";
            this.edtPensum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensum.Properties.Appearance.Options.UseFont = true;
            this.edtPensum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensum.Size = new System.Drawing.Size(79, 24);
            this.edtPensum.TabIndex = 9;
            //
            // lblGesamtpensum
            //
            this.lblGesamtpensum.Location = new System.Drawing.Point(4, 105);
            this.lblGesamtpensum.Name = "lblGesamtpensum";
            this.lblGesamtpensum.Size = new System.Drawing.Size(96, 24);
            this.lblGesamtpensum.TabIndex = 8;
            this.lblGesamtpensum.Text = "Gesamtpensum";
            this.lblGesamtpensum.UseCompatibleTextRendering = true;
            //
            // chkUnbefristeteStelle
            //
            this.chkUnbefristeteStelle.DataMember = "DauerUnbefristet";
            this.chkUnbefristeteStelle.DataSource = this.qryKaEinsatzplatz;
            this.chkUnbefristeteStelle.Location = new System.Drawing.Point(216, 45);
            this.chkUnbefristeteStelle.Name = "chkUnbefristeteStelle";
            this.chkUnbefristeteStelle.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkUnbefristeteStelle.Properties.Appearance.Options.UseBackColor = true;
            this.chkUnbefristeteStelle.Properties.Caption = "unbefristet";
            this.chkUnbefristeteStelle.Size = new System.Drawing.Size(117, 19);
            this.chkUnbefristeteStelle.TabIndex = 7;
            //
            // edtEinsatzAb
            //
            this.edtEinsatzAb.DataMember = "EinsatzAb";
            this.edtEinsatzAb.DataSource = this.qryKaEinsatzplatz;
            this.edtEinsatzAb.EditValue = null;
            this.edtEinsatzAb.Location = new System.Drawing.Point(109, 41);
            this.edtEinsatzAb.Name = "edtEinsatzAb";
            this.edtEinsatzAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzAb.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtEinsatzAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtEinsatzAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzAb.Properties.ShowToday = false;
            this.edtEinsatzAb.Size = new System.Drawing.Size(101, 24);
            this.edtEinsatzAb.TabIndex = 3;
            //
            // lblEinsatz
            //
            this.lblEinsatz.Location = new System.Drawing.Point(3, 42);
            this.lblEinsatz.Name = "lblEinsatz";
            this.lblEinsatz.Size = new System.Drawing.Size(100, 23);
            this.lblEinsatz.TabIndex = 2;
            this.lblEinsatz.Text = "Einsatz ab";
            this.lblEinsatz.UseCompatibleTextRendering = true;
            //
            // edtErfassungsdatum
            //
            this.edtErfassungsdatum.DataMember = "ErfassungsDatum";
            this.edtErfassungsdatum.DataSource = this.qryKaEinsatzplatz;
            this.edtErfassungsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErfassungsdatum.EditValue = null;
            this.edtErfassungsdatum.Location = new System.Drawing.Point(110, 6);
            this.edtErfassungsdatum.Name = "edtErfassungsdatum";
            this.edtErfassungsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErfassungsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtErfassungsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErfassungsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtErfassungsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungsdatum.Properties.ReadOnly = true;
            this.edtErfassungsdatum.Properties.ShowToday = false;
            this.edtErfassungsdatum.Size = new System.Drawing.Size(101, 24);
            this.edtErfassungsdatum.TabIndex = 1;
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(3, 6);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(100, 23);
            this.lblDatumVon.TabIndex = 0;
            this.lblDatumVon.Text = "Erfasst am";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            //
            // tpgGrundinformationen
            //
            this.tpgGrundinformationen.Controls.Add(this.docKaEinsatzplatz);
            this.tpgGrundinformationen.Controls.Add(this.btnKopieren);
            this.tpgGrundinformationen.Controls.Add(this.edtDetails);
            this.tpgGrundinformationen.Controls.Add(this.lblDetails);
            this.tpgGrundinformationen.Controls.Add(this.chkNeuGeschaffeneLehrstelle);
            this.tpgGrundinformationen.Controls.Add(this.edtTypAusbildung);
            this.tpgGrundinformationen.Controls.Add(this.lblAusbildungTyp);
            this.tpgGrundinformationen.Controls.Add(this.edtLehrberuf);
            this.tpgGrundinformationen.Controls.Add(this.lblLehrberuf);
            this.tpgGrundinformationen.Controls.Add(this.edtZustaendigKA);
            this.tpgGrundinformationen.Controls.Add(this.lblZustaendig);
            this.tpgGrundinformationen.Controls.Add(this.edtKaProgramm);
            this.tpgGrundinformationen.Controls.Add(this.lblKaProgramm);
            this.tpgGrundinformationen.Controls.Add(this.edtEinsatzplatzNummer);
            this.tpgGrundinformationen.Controls.Add(this.lblEinsatzplatzNummer);
            this.tpgGrundinformationen.Controls.Add(this.btnInfoBetrieb);
            this.tpgGrundinformationen.Controls.Add(this.edtAdresseBetrieb);
            this.tpgGrundinformationen.Controls.Add(this.lblAdresseBetrieb);
            this.tpgGrundinformationen.Controls.Add(this.edtBetrieb);
            this.tpgGrundinformationen.Controls.Add(this.lblBetrieb);
            this.tpgGrundinformationen.Controls.Add(this.edtBranche);
            this.tpgGrundinformationen.Controls.Add(this.lblBranche);
            this.tpgGrundinformationen.Controls.Add(this.edtBezeichnung);
            this.tpgGrundinformationen.Controls.Add(this.lblBezeichnung);
            this.tpgGrundinformationen.Controls.Add(this.chkAktiv);
            this.tpgGrundinformationen.Controls.Add(this.lblGrundinformationen);
            this.tpgGrundinformationen.Location = new System.Drawing.Point(6, 6);
            this.tpgGrundinformationen.Name = "tpgGrundinformationen";
            this.tpgGrundinformationen.Size = new System.Drawing.Size(791, 268);
            this.tpgGrundinformationen.TabIndex = 0;
            this.tpgGrundinformationen.Title = "Grundinformationen";
            //
            // docKaEinsatzplatz
            //
            this.docKaEinsatzplatz.Context = "KaEinsatzplatz";
            this.docKaEinsatzplatz.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.docKaEinsatzplatz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docKaEinsatzplatz.Image = ((System.Drawing.Image)(resources.GetObject("docKaEinsatzplatz.Image")));
            this.docKaEinsatzplatz.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docKaEinsatzplatz.Location = new System.Drawing.Point(698, 182);
            this.docKaEinsatzplatz.Name = "docKaEinsatzplatz";
            this.docKaEinsatzplatz.Size = new System.Drawing.Size(90, 24);
            this.docKaEinsatzplatz.TabIndex = 47;
            this.docKaEinsatzplatz.Text = "Dokument";
            this.docKaEinsatzplatz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docKaEinsatzplatz.UseVisualStyleBackColor = false;
            //
            // btnKopieren
            //
            this.btnKopieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKopieren.Location = new System.Drawing.Point(698, 236);
            this.btnKopieren.Name = "btnKopieren";
            this.btnKopieren.Size = new System.Drawing.Size(90, 24);
            this.btnKopieren.TabIndex = 36;
            this.btnKopieren.Text = "Duplizieren";
            this.btnKopieren.UseCompatibleTextRendering = true;
            this.btnKopieren.UseVisualStyleBackColor = true;
            this.btnKopieren.Click += new System.EventHandler(this.btnKopieren_Click);
            //
            // edtDetails
            //
            this.edtDetails.DataMember = "Details";
            this.edtDetails.DataSource = this.qryKaEinsatzplatz;
            this.edtDetails.Location = new System.Drawing.Point(110, 182);
            this.edtDetails.Name = "edtDetails";
            this.edtDetails.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDetails.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDetails.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDetails.Properties.Appearance.Options.UseBackColor = true;
            this.edtDetails.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDetails.Properties.Appearance.Options.UseFont = true;
            this.edtDetails.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDetails.Size = new System.Drawing.Size(574, 78);
            this.edtDetails.TabIndex = 23;
            //
            // lblDetails
            //
            this.lblDetails.Location = new System.Drawing.Point(3, 182);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(112, 24);
            this.lblDetails.TabIndex = 22;
            this.lblDetails.Text = "Stellenbeschreibung";
            this.lblDetails.UseCompatibleTextRendering = true;
            //
            // chkNeuGeschaffeneLehrstelle
            //
            this.chkNeuGeschaffeneLehrstelle.DataMember = "NeuGeschaffeneLehrstelle";
            this.chkNeuGeschaffeneLehrstelle.DataSource = this.qryKaEinsatzplatz;
            this.chkNeuGeschaffeneLehrstelle.Location = new System.Drawing.Point(541, 155);
            this.chkNeuGeschaffeneLehrstelle.Name = "chkNeuGeschaffeneLehrstelle";
            this.chkNeuGeschaffeneLehrstelle.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkNeuGeschaffeneLehrstelle.Properties.Appearance.Options.UseBackColor = true;
            this.chkNeuGeschaffeneLehrstelle.Properties.Caption = "Neu geschaffene Lehrstelle";
            this.chkNeuGeschaffeneLehrstelle.Size = new System.Drawing.Size(156, 19);
            this.chkNeuGeschaffeneLehrstelle.TabIndex = 21;
            //
            // edtTypAusbildung
            //
            this.edtTypAusbildung.DataMember = "BerufsAusbildungTyp";
            this.edtTypAusbildung.DataSource = this.qryKaEinsatzplatz;
            this.edtTypAusbildung.Location = new System.Drawing.Point(541, 124);
            this.edtTypAusbildung.LOVName = "KaBerufsausbildungTyp";
            this.edtTypAusbildung.Name = "edtTypAusbildung";
            this.edtTypAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTypAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTypAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.edtTypAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTypAusbildung.Properties.Appearance.Options.UseFont = true;
            this.edtTypAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTypAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTypAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTypAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtTypAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtTypAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTypAusbildung.Properties.NullText = "";
            this.edtTypAusbildung.Properties.ShowFooter = false;
            this.edtTypAusbildung.Properties.ShowHeader = false;
            this.edtTypAusbildung.Size = new System.Drawing.Size(247, 24);
            this.edtTypAusbildung.TabIndex = 20;
            //
            // lblAusbildungTyp
            //
            this.lblAusbildungTyp.Location = new System.Drawing.Point(439, 124);
            this.lblAusbildungTyp.Name = "lblAusbildungTyp";
            this.lblAusbildungTyp.Size = new System.Drawing.Size(100, 23);
            this.lblAusbildungTyp.TabIndex = 19;
            this.lblAusbildungTyp.Text = "Typ Ausbildung";
            this.lblAusbildungTyp.UseCompatibleTextRendering = true;
            //
            // edtLehrberuf
            //
            this.edtLehrberuf.DataMember = "LehrberufCode";
            this.edtLehrberuf.DataSource = this.qryKaEinsatzplatz;
            this.edtLehrberuf.Location = new System.Drawing.Point(541, 93);
            this.edtLehrberuf.LOVFilter = "Value1 = \'1\'";
            this.edtLehrberuf.LOVFilterWhereAppend = true;
            this.edtLehrberuf.LOVName = "KaLehrberuf";
            this.edtLehrberuf.Name = "edtLehrberuf";
            this.edtLehrberuf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLehrberuf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLehrberuf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehrberuf.Properties.Appearance.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLehrberuf.Properties.Appearance.Options.UseFont = true;
            this.edtLehrberuf.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLehrberuf.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehrberuf.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLehrberuf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtLehrberuf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLehrberuf.Properties.NullText = "";
            this.edtLehrberuf.Properties.ShowFooter = false;
            this.edtLehrberuf.Properties.ShowHeader = false;
            this.edtLehrberuf.Size = new System.Drawing.Size(247, 24);
            this.edtLehrberuf.TabIndex = 18;
            this.edtLehrberuf.EditValueChanged += new System.EventHandler(this.edtLehrberuf_EditValueChanged);
            //
            // lblLehrberuf
            //
            this.lblLehrberuf.Location = new System.Drawing.Point(439, 93);
            this.lblLehrberuf.Name = "lblLehrberuf";
            this.lblLehrberuf.Size = new System.Drawing.Size(100, 23);
            this.lblLehrberuf.TabIndex = 17;
            this.lblLehrberuf.Text = "Lehrberuf";
            this.lblLehrberuf.UseCompatibleTextRendering = true;
            //
            // edtZustaendigKA
            //
            this.edtZustaendigKA.DataMember = "Zustaendig";
            this.edtZustaendigKA.DataSource = this.qryKaEinsatzplatz;
            this.edtZustaendigKA.Location = new System.Drawing.Point(541, 63);
            this.edtZustaendigKA.Name = "edtZustaendigKA";
            this.edtZustaendigKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtZustaendigKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigKA.SearchStringWhitelist = new string[] {
            ".",
            "*",
            "%"};
            this.edtZustaendigKA.Size = new System.Drawing.Size(247, 24);
            this.edtZustaendigKA.TabIndex = 16;
            this.edtZustaendigKA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustaendigKA_UserModifiedFld);
            //
            // lblZustaendig
            //
            this.lblZustaendig.Location = new System.Drawing.Point(439, 62);
            this.lblZustaendig.Name = "lblZustaendig";
            this.lblZustaendig.Size = new System.Drawing.Size(96, 24);
            this.lblZustaendig.TabIndex = 15;
            this.lblZustaendig.Text = "Zuständig KA";
            this.lblZustaendig.UseCompatibleTextRendering = true;
            //
            // edtKaProgramm
            //
            this.edtKaProgramm.DataMember = "KaProgrammCode";
            this.edtKaProgramm.DataSource = this.qryKaEinsatzplatz;
            this.edtKaProgramm.Location = new System.Drawing.Point(541, 33);
            this.edtKaProgramm.LOVFilter = "\',\' + Value2 + \',\' like \'%,3,%\'";
            this.edtKaProgramm.LOVFilterWhereAppend = true;
            this.edtKaProgramm.LOVName = "KaVermittlungProgramm";
            this.edtKaProgramm.Name = "edtKaProgramm";
            this.edtKaProgramm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKaProgramm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaProgramm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaProgramm.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaProgramm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKaProgramm.Properties.Appearance.Options.UseFont = true;
            this.edtKaProgramm.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKaProgramm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaProgramm.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKaProgramm.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKaProgramm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtKaProgramm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtKaProgramm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKaProgramm.Properties.NullText = "";
            this.edtKaProgramm.Properties.ShowFooter = false;
            this.edtKaProgramm.Properties.ShowHeader = false;
            this.edtKaProgramm.Size = new System.Drawing.Size(247, 24);
            this.edtKaProgramm.TabIndex = 14;
            this.edtKaProgramm.EditValueChanged += new System.EventHandler(this.edtKaProgramm_EditValueChanged);
            //
            // lblKaProgramm
            //
            this.lblKaProgramm.Location = new System.Drawing.Point(439, 32);
            this.lblKaProgramm.Name = "lblKaProgramm";
            this.lblKaProgramm.Size = new System.Drawing.Size(96, 24);
            this.lblKaProgramm.TabIndex = 13;
            this.lblKaProgramm.Text = "KA-Programm";
            this.lblKaProgramm.UseCompatibleTextRendering = true;
            //
            // edtEinsatzplatzNummer
            //
            this.edtEinsatzplatzNummer.DataMember = "KaEinsatzplatzID";
            this.edtEinsatzplatzNummer.DataSource = this.qryKaEinsatzplatz;
            this.edtEinsatzplatzNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatzNummer.Location = new System.Drawing.Point(541, 5);
            this.edtEinsatzplatzNummer.Name = "edtEinsatzplatzNummer";
            this.edtEinsatzplatzNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinsatzplatzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatzNummer.Properties.ReadOnly = true;
            this.edtEinsatzplatzNummer.Size = new System.Drawing.Size(247, 24);
            this.edtEinsatzplatzNummer.TabIndex = 12;
            //
            // lblEinsatzplatzNummer
            //
            this.lblEinsatzplatzNummer.Location = new System.Drawing.Point(439, 5);
            this.lblEinsatzplatzNummer.Name = "lblEinsatzplatzNummer";
            this.lblEinsatzplatzNummer.Size = new System.Drawing.Size(96, 24);
            this.lblEinsatzplatzNummer.TabIndex = 11;
            this.lblEinsatzplatzNummer.Text = "Einsatzplatz-Nr.";
            this.lblEinsatzplatzNummer.UseCompatibleTextRendering = true;
            //
            // btnInfoBetrieb
            //
            this.btnInfoBetrieb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoBetrieb.Location = new System.Drawing.Point(110, 152);
            this.btnInfoBetrieb.Name = "btnInfoBetrieb";
            this.btnInfoBetrieb.Size = new System.Drawing.Size(111, 24);
            this.btnInfoBetrieb.TabIndex = 10;
            this.btnInfoBetrieb.Text = "Info zum Betrieb";
            this.btnInfoBetrieb.UseCompatibleTextRendering = true;
            this.btnInfoBetrieb.UseVisualStyleBackColor = false;
            this.btnInfoBetrieb.Click += new System.EventHandler(this.btnInfoBetrieb_Click);
            //
            // edtAdresseBetrieb
            //
            this.edtAdresseBetrieb.DataMember = "BetAdresse";
            this.edtAdresseBetrieb.DataSource = this.qryKaEinsatzplatz;
            this.edtAdresseBetrieb.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseBetrieb.Location = new System.Drawing.Point(110, 123);
            this.edtAdresseBetrieb.Name = "edtAdresseBetrieb";
            this.edtAdresseBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseBetrieb.Properties.ReadOnly = true;
            this.edtAdresseBetrieb.Size = new System.Drawing.Size(304, 24);
            this.edtAdresseBetrieb.TabIndex = 9;
            //
            // lblAdresseBetrieb
            //
            this.lblAdresseBetrieb.Location = new System.Drawing.Point(3, 121);
            this.lblAdresseBetrieb.Name = "lblAdresseBetrieb";
            this.lblAdresseBetrieb.Size = new System.Drawing.Size(96, 24);
            this.lblAdresseBetrieb.TabIndex = 8;
            this.lblAdresseBetrieb.Text = "Adresse";
            this.lblAdresseBetrieb.UseCompatibleTextRendering = true;
            //
            // edtBetrieb
            //
            this.edtBetrieb.DataMember = "BetName";
            this.edtBetrieb.DataSource = this.qryKaEinsatzplatz;
            this.edtBetrieb.Location = new System.Drawing.Point(110, 93);
            this.edtBetrieb.Name = "edtBetrieb";
            this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtBetrieb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrieb.SearchStringWhitelist = new string[] {
            ".",
            "*",
            "%"};
            this.edtBetrieb.Size = new System.Drawing.Size(304, 24);
            this.edtBetrieb.TabIndex = 7;
            this.edtBetrieb.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBetrieb_UserModifiedFld);
            //
            // lblBetrieb
            //
            this.lblBetrieb.Location = new System.Drawing.Point(3, 92);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(96, 24);
            this.lblBetrieb.TabIndex = 6;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            //
            // edtBranche
            //
            this.edtBranche.DataMember = "BrancheCode";
            this.edtBranche.DataSource = this.qryKaEinsatzplatz;
            this.edtBranche.Location = new System.Drawing.Point(110, 63);
            this.edtBranche.LOVName = "KaBranche";
            this.edtBranche.Name = "edtBranche";
            this.edtBranche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBranche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBranche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBranche.Properties.Appearance.Options.UseBackColor = true;
            this.edtBranche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBranche.Properties.Appearance.Options.UseFont = true;
            this.edtBranche.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBranche.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBranche.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBranche.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBranche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtBranche.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtBranche.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBranche.Properties.NullText = "";
            this.edtBranche.Properties.ShowFooter = false;
            this.edtBranche.Properties.ShowHeader = false;
            this.edtBranche.Size = new System.Drawing.Size(304, 24);
            this.edtBranche.TabIndex = 5;
            //
            // lblBranche
            //
            this.lblBranche.Location = new System.Drawing.Point(3, 61);
            this.lblBranche.Name = "lblBranche";
            this.lblBranche.Size = new System.Drawing.Size(96, 24);
            this.lblBranche.TabIndex = 4;
            this.lblBranche.Text = "Branche";
            this.lblBranche.UseCompatibleTextRendering = true;
            //
            // edtBezeichnung
            //
            this.edtBezeichnung.DataMember = "Bezeichnung";
            this.edtBezeichnung.DataSource = this.qryKaEinsatzplatz;
            this.edtBezeichnung.Location = new System.Drawing.Point(110, 33);
            this.edtBezeichnung.Name = "edtBezeichnung";
            this.edtBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezeichnung.Size = new System.Drawing.Size(304, 24);
            this.edtBezeichnung.TabIndex = 3;
            //
            // lblBezeichnung
            //
            this.lblBezeichnung.Location = new System.Drawing.Point(3, 32);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(96, 24);
            this.lblBezeichnung.TabIndex = 2;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.UseCompatibleTextRendering = true;
            //
            // chkAktiv
            //
            this.chkAktiv.DataMember = "Aktiv";
            this.chkAktiv.DataSource = this.qryKaEinsatzplatz;
            this.chkAktiv.Location = new System.Drawing.Point(356, 9);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = " Aktiv";
            this.chkAktiv.Size = new System.Drawing.Size(58, 19);
            this.chkAktiv.TabIndex = 1;
            //
            // lblGrundinformationen
            //
            this.lblGrundinformationen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblGrundinformationen.Location = new System.Drawing.Point(3, 5);
            this.lblGrundinformationen.Name = "lblGrundinformationen";
            this.lblGrundinformationen.Size = new System.Drawing.Size(143, 16);
            this.lblGrundinformationen.TabIndex = 0;
            this.lblGrundinformationen.Text = "Grundinformationen";
            this.lblGrundinformationen.UseCompatibleTextRendering = true;
            //
            // tpgAnforderungen
            //
            this.tpgAnforderungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tpgAnforderungen.Controls.Add(this.lblWeitereAnforderungen);
            this.tpgAnforderungen.Controls.Add(this.lblAusbildung);
            this.tpgAnforderungen.Controls.Add(this.lblGeschlecht);
            this.tpgAnforderungen.Controls.Add(this.lblDeutschSchriftlich);
            this.tpgAnforderungen.Controls.Add(this.lblDeutschMuendlich);
            this.tpgAnforderungen.Controls.Add(this.lblAnforderungen);
            this.tpgAnforderungen.Controls.Add(this.edtWeitereAnforderungen);
            this.tpgAnforderungen.Controls.Add(this.edtAusbildung);
            this.tpgAnforderungen.Controls.Add(this.edtEinsatzplatzGeschlecht);
            this.tpgAnforderungen.Controls.Add(this.edtDeutschSchriftlich);
            this.tpgAnforderungen.Controls.Add(this.lblPCKentnisse);
            this.tpgAnforderungen.Controls.Add(this.edtDeutschMuendlich);
            this.tpgAnforderungen.Controls.Add(this.edtFuehrerausweisKategorie);
            this.tpgAnforderungen.Controls.Add(this.chkFuehrerausweis);
            this.tpgAnforderungen.Location = new System.Drawing.Point(6, 6);
            this.tpgAnforderungen.Name = "tpgAnforderungen";
            this.tpgAnforderungen.Size = new System.Drawing.Size(791, 268);
            this.tpgAnforderungen.TabIndex = 0;
            this.tpgAnforderungen.Title = "Anforderungen";
            //
            // lblWeitereAnforderungen
            //
            this.lblWeitereAnforderungen.Location = new System.Drawing.Point(7, 137);
            this.lblWeitereAnforderungen.Name = "lblWeitereAnforderungen";
            this.lblWeitereAnforderungen.Size = new System.Drawing.Size(128, 24);
            this.lblWeitereAnforderungen.TabIndex = 13;
            this.lblWeitereAnforderungen.Text = "Weitere Anforderungen";
            this.lblWeitereAnforderungen.UseCompatibleTextRendering = true;
            //
            // lblAusbildung
            //
            this.lblAusbildung.Location = new System.Drawing.Point(397, 97);
            this.lblAusbildung.Name = "lblAusbildung";
            this.lblAusbildung.Size = new System.Drawing.Size(100, 23);
            this.lblAusbildung.TabIndex = 12;
            this.lblAusbildung.Text = "Ausbildung";
            this.lblAusbildung.UseCompatibleTextRendering = true;
            //
            // lblGeschlecht
            //
            this.lblGeschlecht.Location = new System.Drawing.Point(7, 97);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(100, 23);
            this.lblGeschlecht.TabIndex = 11;
            this.lblGeschlecht.Text = "Geschlecht";
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            //
            // lblDeutschSchriftlich
            //
            this.lblDeutschSchriftlich.Location = new System.Drawing.Point(397, 67);
            this.lblDeutschSchriftlich.Name = "lblDeutschSchriftlich";
            this.lblDeutschSchriftlich.Size = new System.Drawing.Size(100, 23);
            this.lblDeutschSchriftlich.TabIndex = 10;
            this.lblDeutschSchriftlich.Text = "Deutsch schriftlich";
            this.lblDeutschSchriftlich.UseCompatibleTextRendering = true;
            //
            // lblDeutschMuendlich
            //
            this.lblDeutschMuendlich.Location = new System.Drawing.Point(397, 36);
            this.lblDeutschMuendlich.Name = "lblDeutschMuendlich";
            this.lblDeutschMuendlich.Size = new System.Drawing.Size(100, 23);
            this.lblDeutschMuendlich.TabIndex = 9;
            this.lblDeutschMuendlich.Text = "Deutsch mündlich";
            this.lblDeutschMuendlich.UseCompatibleTextRendering = true;
            //
            // lblAnforderungen
            //
            this.lblAnforderungen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblAnforderungen.Location = new System.Drawing.Point(7, 7);
            this.lblAnforderungen.Name = "lblAnforderungen";
            this.lblAnforderungen.Size = new System.Drawing.Size(114, 16);
            this.lblAnforderungen.TabIndex = 8;
            this.lblAnforderungen.Text = "Anforderungen";
            this.lblAnforderungen.UseCompatibleTextRendering = true;
            //
            // edtWeitereAnforderungen
            //
            this.edtWeitereAnforderungen.DataMember = "WeitereAnforderungen";
            this.edtWeitereAnforderungen.DataSource = this.qryKaEinsatzplatz;
            this.edtWeitereAnforderungen.Location = new System.Drawing.Point(135, 138);
            this.edtWeitereAnforderungen.Name = "edtWeitereAnforderungen";
            this.edtWeitereAnforderungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeitereAnforderungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeitereAnforderungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeitereAnforderungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeitereAnforderungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeitereAnforderungen.Properties.Appearance.Options.UseFont = true;
            this.edtWeitereAnforderungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWeitereAnforderungen.Size = new System.Drawing.Size(597, 107);
            this.edtWeitereAnforderungen.TabIndex = 7;
            //
            // edtAusbildung
            //
            this.edtAusbildung.DataMember = "AusbildungCode";
            this.edtAusbildung.DataSource = this.qryKaEinsatzplatz;
            this.edtAusbildung.Location = new System.Drawing.Point(531, 97);
            this.edtAusbildung.LOVName = "KaAusbildung";
            this.edtAusbildung.Name = "edtAusbildung";
            this.edtAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbildung.Properties.Appearance.Options.UseFont = true;
            this.edtAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbildung.Properties.NullText = "";
            this.edtAusbildung.Properties.ShowFooter = false;
            this.edtAusbildung.Properties.ShowHeader = false;
            this.edtAusbildung.Size = new System.Drawing.Size(201, 24);
            this.edtAusbildung.TabIndex = 6;
            //
            // edtEinsatzplatzGeschlecht
            //
            this.edtEinsatzplatzGeschlecht.DataMember = "GeschlechtCode";
            this.edtEinsatzplatzGeschlecht.DataSource = this.qryKaEinsatzplatz;
            this.edtEinsatzplatzGeschlecht.Location = new System.Drawing.Point(135, 96);
            this.edtEinsatzplatzGeschlecht.LOVName = "KaEinsatzplatzGeschlecht";
            this.edtEinsatzplatzGeschlecht.Name = "edtEinsatzplatzGeschlecht";
            this.edtEinsatzplatzGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzplatzGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatzGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatzGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatzGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatzGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatzGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinsatzplatzGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatzGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinsatzplatzGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinsatzplatzGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtEinsatzplatzGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtEinsatzplatzGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzplatzGeschlecht.Properties.NullText = "";
            this.edtEinsatzplatzGeschlecht.Properties.ShowFooter = false;
            this.edtEinsatzplatzGeschlecht.Properties.ShowHeader = false;
            this.edtEinsatzplatzGeschlecht.Size = new System.Drawing.Size(201, 24);
            this.edtEinsatzplatzGeschlecht.TabIndex = 5;
            //
            // edtDeutschSchriftlich
            //
            this.edtDeutschSchriftlich.DataMember = "DeutschSchriftlichCode";
            this.edtDeutschSchriftlich.DataSource = this.qryKaEinsatzplatz;
            this.edtDeutschSchriftlich.Location = new System.Drawing.Point(531, 67);
            this.edtDeutschSchriftlich.LOVName = "KaDeutschkenntnisse";
            this.edtDeutschSchriftlich.Name = "edtDeutschSchriftlich";
            this.edtDeutschSchriftlich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDeutschSchriftlich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDeutschSchriftlich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschSchriftlich.Properties.Appearance.Options.UseBackColor = true;
            this.edtDeutschSchriftlich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDeutschSchriftlich.Properties.Appearance.Options.UseFont = true;
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDeutschSchriftlich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtDeutschSchriftlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtDeutschSchriftlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschSchriftlich.Properties.NullText = "";
            this.edtDeutschSchriftlich.Properties.ShowFooter = false;
            this.edtDeutschSchriftlich.Properties.ShowHeader = false;
            this.edtDeutschSchriftlich.Size = new System.Drawing.Size(201, 24);
            this.edtDeutschSchriftlich.TabIndex = 4;
            //
            // lblPCKentnisse
            //
            this.lblPCKentnisse.DataMember = "PCKenntnisse";
            this.lblPCKentnisse.DataSource = this.qryKaEinsatzplatz;
            this.lblPCKentnisse.Location = new System.Drawing.Point(7, 67);
            this.lblPCKentnisse.Name = "lblPCKentnisse";
            this.lblPCKentnisse.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPCKentnisse.Properties.Appearance.Options.UseBackColor = true;
            this.lblPCKentnisse.Properties.Caption = "PC-Kenntnisse";
            this.lblPCKentnisse.Size = new System.Drawing.Size(99, 19);
            this.lblPCKentnisse.TabIndex = 3;
            //
            // edtDeutschMuendlich
            //
            this.edtDeutschMuendlich.DataMember = "DeutschMuendlichCode";
            this.edtDeutschMuendlich.DataSource = this.qryKaEinsatzplatz;
            this.edtDeutschMuendlich.Location = new System.Drawing.Point(531, 35);
            this.edtDeutschMuendlich.LOVName = "KaDeutschkenntnisse";
            this.edtDeutschMuendlich.Name = "edtDeutschMuendlich";
            this.edtDeutschMuendlich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDeutschMuendlich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDeutschMuendlich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschMuendlich.Properties.Appearance.Options.UseBackColor = true;
            this.edtDeutschMuendlich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDeutschMuendlich.Properties.Appearance.Options.UseFont = true;
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDeutschMuendlich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtDeutschMuendlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtDeutschMuendlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschMuendlich.Properties.NullText = "";
            this.edtDeutschMuendlich.Properties.ShowFooter = false;
            this.edtDeutschMuendlich.Properties.ShowHeader = false;
            this.edtDeutschMuendlich.Size = new System.Drawing.Size(201, 24);
            this.edtDeutschMuendlich.TabIndex = 2;
            //
            // edtFuehrerausweisKategorie
            //
            this.edtFuehrerausweisKategorie.DataMember = "FuehrerausweisKategorieCode";
            this.edtFuehrerausweisKategorie.DataSource = this.qryKaEinsatzplatz;
            this.edtFuehrerausweisKategorie.Location = new System.Drawing.Point(135, 40);
            this.edtFuehrerausweisKategorie.LOVName = "KaFuehrerausweisKategorie";
            this.edtFuehrerausweisKategorie.LOVFilter = "706";
            this.edtFuehrerausweisKategorie.Name = "edtFuehrerausweisKategorie";
            this.edtFuehrerausweisKategorie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFuehrerausweisKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFuehrerausweisKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweisKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtFuehrerausweisKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFuehrerausweisKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFuehrerausweisKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtFuehrerausweisKategorie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtFuehrerausweisKategorie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFuehrerausweisKategorie.Properties.NullText = "";
            this.edtFuehrerausweisKategorie.Properties.ShowFooter = false;
            this.edtFuehrerausweisKategorie.Properties.ShowHeader = false;
            this.edtFuehrerausweisKategorie.Size = new System.Drawing.Size(201, 24);
            this.edtFuehrerausweisKategorie.TabIndex = 1;
            //
            // chkFuehrerausweis
            //
            this.chkFuehrerausweis.DataMember = "Fuehrerausweis";
            this.chkFuehrerausweis.DataSource = this.qryKaEinsatzplatz;
            this.chkFuehrerausweis.Location = new System.Drawing.Point(7, 40);
            this.chkFuehrerausweis.Name = "chkFuehrerausweis";
            this.chkFuehrerausweis.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkFuehrerausweis.Properties.Appearance.Options.UseBackColor = true;
            this.chkFuehrerausweis.Properties.Caption = "Führerausweis Kat.";
            this.chkFuehrerausweis.Size = new System.Drawing.Size(129, 19);
            this.chkFuehrerausweis.TabIndex = 0;
            //
            // qryKaKontaktperson
            //
            this.qryKaKontaktperson.HostControl = this;
            this.qryKaKontaktperson.SelectStatement = "SELECT *,\r\n       Kontaktperson = IsNull(Name + \', \', \'\') + IsNull(Vorname, \'\')\r\n" +
                "FROM   KaBetriebKontakt\r\nWHERE  Aktiv = 1\r\nAND    KaBetriebID = {0}\r\nORDER BY Na" +
                "me ASC";
            this.qryKaKontaktperson.TableName = "KaBetriebKontakt";
            //
            // CtlKaEinsatzplaetzeDetail
            //
            this.ActiveSQLQuery = this.qryKaEinsatzplatz;
            this.Controls.Add(this.tabBottom);
            this.Name = "CtlKaEinsatzplaetzeDetail";
            this.Size = new System.Drawing.Size(809, 579);
            this.Load += new System.EventHandler(this.CtlKaEinsatzplaetzeDetail_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.tabBottom, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tabBottom.ResumeLayout(false);
            this.tpgVermittlung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVerZustaendig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaVermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerZustaendig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerPensumProz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerPensum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerNameVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerVorschlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerEinsatzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerEinsatzVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerPensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerEinsatzBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerEinsatzVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerVorschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlung)).EndInit();
            this.tpgKontakt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonMobil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktpersonBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFunktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFunktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFunktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpersonen)).EndInit();
            this.tpgDauerPensum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblPensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelpensumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesamtpensumProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelpensumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelpensumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPensumUnbestimmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAufteilbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesamtpensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnbefristeteStelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            this.tpgGrundinformationen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDetails.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNeuGeschaffeneLehrstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildungTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundinformationen)).EndInit();
            this.tpgAnforderungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblWeitereAnforderungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschSchriftlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschMuendlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnforderungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeitereAnforderungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKentnisse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFuehrerausweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKontaktperson)).EndInit();
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

        #region EventHandlers

        private void btnInfoBetrieb_Click(object sender, System.EventArgs e)
        {
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToBetrieb", "KaBetriebID", qryKaEinsatzplatz["KaBetriebID"]);
        }

        private void btnInformationenPerson_Click(object sender, System.EventArgs e)
        {
            CtlKaVerlauf.JumpToPath(qryKaVermittlung["BaPersonID"] as int?);
        }

        private void btnKontaktdatenAendern_Click(object sender, System.EventArgs e)
        {
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToBetriebKontakt", "KaBetriebID", qryKaEinsatzplatz["KaBetriebID"], "KaBetriebKontaktID", qryKaEinsatzplatz["KaKontaktpersonID"]);
        }

        private void btnKopieren_Click(object sender, System.EventArgs e)
        {
            if (qryKaEinsatzplatz.Count == 0) return;
            if (!qryKaEinsatzplatz.Post()) return;

            DataRow r1 = qryKaEinsatzplatz.Row;
            qryKaEinsatzplatz.Insert();
            qryKaEinsatzplatz.Row.ItemArray = r1.ItemArray;
            qryKaEinsatzplatz.Post();
            qryKaEinsatzplatz.Refresh();
        }

        private void chkAufteilbar_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAufteilbar.Checked)
            {
                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtEinzelpensumVon.EditMode = EditModeType.Normal;
                    edtEinzelpensumBis.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtEinzelpensumVon.EditMode = EditModeType.ReadOnly;
                    edtEinzelpensumBis.EditMode = EditModeType.ReadOnly;
                }
            }
            else
            {
                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtEinzelpensumVon.EditValue = DBNull.Value;
                    edtEinzelpensumBis.EditValue = DBNull.Value;
                }

                edtEinzelpensumVon.EditMode = EditModeType.ReadOnly;
                edtEinzelpensumBis.EditMode = EditModeType.ReadOnly;
            }
        }

        private void chkPensumUnbestimmt_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkPensumUnbestimmt.Checked)
            {
                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtPensum.EditValue = DBNull.Value;
                }

                edtPensum.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtPensum.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtPensum.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        private void CtlKaEinsatzplaetzeDetail_Load(object sender, EventArgs e)
        {
            tabBottom.SelectedTabIndex = 0;
        }

        private void edtBetrieb_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtBetrieb.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKaEinsatzplatz["KaBetriebID"] = DBNull.Value;
                    qryKaEinsatzplatz["BetName"] = DBNull.Value;
                    qryKaEinsatzplatz["BetAdresse"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$      = BET.KaBetriebID,
                       Betrieb  = BET.BetriebName,
                       Adresse  = ISNULL(ADR.PLZ, '') + ISNULL(' ' + ADR.Ort, '') + ISNULL(', ' + ADR.Strasse, '') + ISNULL(' ' + ADR.HausNr, ''),
                       Zusatz   = ADR.Zusatz
                FROM dbo.KaBetrieb         BET
                  INNER JOIN dbo.BaAdresse ADR ON ADR.KaBetriebID = BET.KaBetriebID
                                              AND GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())
                WHERE BET.BetriebName LIKE '%' + {0} + '%'
                  AND BET.Aktiv = 1
                ORDER BY BET.BetriebName",
                searchString,
                e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKaEinsatzplatz["KaBetriebID"] = dlg[0];
                qryKaEinsatzplatz["BetName"] = dlg[1];
                qryKaEinsatzplatz["BetAdresse"] = dlg[2];
            }
        }

        private void edtKaProgramm_EditValueChanged(object sender, System.EventArgs e)
        {
            edtLehrberuf.EditMode = EditModeType.ReadOnly;

            if (!DBUtil.IsEmpty(edtKaProgramm.EditValue))
            {
                // 1 = Inizio, 2 = QJ
                if (Convert.ToInt32(edtKaProgramm.EditValue) == 1)
                {
                    if (qryKaEinsatzplatz.CanUpdate)
                    {
                        edtLehrberuf.EditMode = EditModeType.Normal;
                        chkNeuGeschaffeneLehrstelle.EditMode = EditModeType.Normal;
                    }
                    else
                    {
                        edtLehrberuf.EditMode = EditModeType.ReadOnly;
                        chkNeuGeschaffeneLehrstelle.EditMode = EditModeType.ReadOnly;
                    }
                }
                else if (Convert.ToInt32(edtKaProgramm.EditValue) == 2)
                {
                    if (qryKaEinsatzplatz.CanUpdate)
                    {
                        chkNeuGeschaffeneLehrstelle.EditValue = 0;
                        edtLehrberuf.EditMode = EditModeType.Normal;
                    }
                    else
                    {
                        edtLehrberuf.EditMode = EditModeType.ReadOnly;
                    }

                    chkNeuGeschaffeneLehrstelle.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    if (qryKaEinsatzplatz.CanUpdate)
                    {
                        edtLehrberuf.EditValue = null;
                        edtTypAusbildung.EditValue = null;
                        chkNeuGeschaffeneLehrstelle.EditValue = 0;
                    }

                    edtTypAusbildung.EditMode = EditModeType.ReadOnly;
                    chkNeuGeschaffeneLehrstelle.EditMode = EditModeType.ReadOnly;
                }
            }
            else
            {
                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtLehrberuf.EditValue = null;
                    edtTypAusbildung.EditValue = null;
                }

                edtTypAusbildung.EditMode = EditModeType.ReadOnly;
            }
        }

        private void edtKontaktperson_EditValueChanged(object sender, System.EventArgs e)
        {
            if (!qryKaEinsatzplatz.CanUpdate)
            {
                return;
            }

            if (!DBUtil.IsEmpty(edtKontaktperson.EditValue))
            {
                qryKaKontaktperson.Find(string.Format("KaBetriebKontaktID = {0}", edtKontaktperson.EditValue));

                edtTelefon.EditValue = qryKaKontaktperson["Telefon"];
                edtTelefonMobil.EditValue = qryKaKontaktperson["TelefonMobil"];
                edtFax.EditValue = qryKaKontaktperson["Fax"];
                edtEMail.EditValue = qryKaKontaktperson["Email"];
            }
            else
            {
                edtTelefon.EditValue = DBNull.Value;
                edtTelefonMobil.EditValue = DBNull.Value;
                edtFax.EditValue = DBNull.Value;
                edtEMail.EditValue = DBNull.Value;
            }
        }

        private void edtLehrberuf_EditValueChanged(object sender, System.EventArgs e)
        {
            edtTypAusbildung.EditMode = EditModeType.ReadOnly;

            if (!DBUtil.IsEmpty(edtLehrberuf.EditValue))
            {
                string value3 = DBUtil.ExecuteScalarSQL(@"SELECT Value3 FROM XLOVCode WHERE LOVName = 'KaLehrberuf' AND Code = {0}", edtLehrberuf.EditValue).ToString();

                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtTypAusbildung.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtTypAusbildung.EditMode = EditModeType.ReadOnly;
                }

                edtTypAusbildung.LOVFilterWhereAppend = true;
                edtTypAusbildung.LOVFilter = string.Format("',' + '{0}' + ',' like '%,' + convert(varchar, Code) + ',%'", value3);
                edtTypAusbildung.LOVName = "KaBerufsausbildungTyp";
            }
            else
            {
                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtTypAusbildung.EditValue = null;
                }
            }
        }

        private void edtZustaendigKA_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtZustaendigKA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKaEinsatzplatz["ZustaendigKA"] = DBNull.Value;
                    qryKaEinsatzplatz["Zustaendig"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                     [Kürzel] = LogonName,
                     [Mitarbeiter/in] = NameVorname,
                     [Org.Einheit] = OrgUnit
              FROM   vwUser
              WHERE  NameVorname like {0} + '%'
              AND    LogonName like 'KA%'
              ORDER BY NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKaEinsatzplatz["ZustaendigKA"] = dlg[0];
                qryKaEinsatzplatz["Zustaendig"] = dlg[2];
            }
        }

        private void qryKaEinsatzplatz_AfterFill(object sender, System.EventArgs e)
        {
            qryKaEinsatzplatz_PositionChanged(sender, null);
            SetEditMode();
        }

        private void qryKaEinsatzplatz_AfterInsert(object sender, System.EventArgs e)
        {
            if (!qryKaEinsatzplatz.CanUpdate)
            {
                return;
            }

            qryKaEinsatzplatz["ErfassungsDatum"] = DateTime.Today;
            qryKaEinsatzplatz["GeschlechtCode"] = 1;
        }

        private void qryKaEinsatzplatz_AfterPost(object sender, System.EventArgs e)
        {
            btnKontaktdatenAendern.Enabled = (!DBUtil.IsEmpty(qryKaEinsatzplatz["KaKontaktpersonID"]));
        }

        private void qryKaEinsatzplatz_BeforeInsert(object sender, System.EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 1)
            {
                throw new KissCancelException();
            }

            tabBottom.SelectedTabIndex = 0;
        }

        private void qryKaEinsatzplatz_BeforePost(object sender, System.EventArgs e)
        {
            if (!qryKaEinsatzplatz.CanUpdate)
            {
                return;
            }

            DBUtil.CheckNotNullField(edtBezeichnung, lblBezeichnung.Text);
            DBUtil.CheckNotNullField(edtBetrieb, lblBetrieb.Text);
            DBUtil.CheckNotNullField(edtKaProgramm, lblKaProgramm.Text);

            if (DBUtil.IsEmpty(edtEinsatzplatzGeschlecht.EditValue))
            {
                qryKaEinsatzplatz["GeschlechtCode"] = 1;
            }
        }

        private void qryKaEinsatzplatz_PositionChanged(object sender, System.EventArgs e)
        {
            if (IsReadOnly)
            {
                btnKopieren.Enabled = false;
            }
            else
            {
                btnKopieren.Enabled = (qryKaEinsatzplatz.Count > 0 && DBUtil.UserHasRight("CtlKaEinsatzplaetze", "UI"));
            }

            btnInfoBetrieb.Enabled = qryKaEinsatzplatz.Count > 0;
            btnKontaktdatenAendern.Enabled = (!DBUtil.IsEmpty(qryKaEinsatzplatz["KaKontaktpersonID"]));

            if (qryKaEinsatzplatz.Count == 0)
            {
                qryKaKontaktperson.Fill(DBNull.Value);
                qryKaVermittlung.Fill(DBNull.Value);
            }
            else
            {
                qryKaKontaktperson.Fill(qryKaEinsatzplatz["KaBetriebID"]);
                qryKaVermittlung.Fill(qryKaEinsatzplatz["KaEinsatzplatzID"]);
            }

            if (IsReadOnly)
            {
                qryKaEinsatzplatz.CanUpdate = false;
                qryKaEinsatzplatz.CanInsert = false;
                qryKaEinsatzplatz.CanDelete = false;
            }

            edtKontaktperson.LoadQuery(qryKaKontaktperson, "KaBetriebKontaktID", "Kontaktperson");

            // #5567 Problem mit Anzeige ReadOnlyfelder in Kontaktperson
            if (qryKaEinsatzplatz.Count > 0)
            {
                qryKaEinsatzplatz.RefreshDisplay();
            }
        }

        private void qryKaVermittlung_AfterFill(object sender, System.EventArgs e)
        {
            qryKaVermittlung_PositionChanged(sender, null);
        }

        private void qryKaVermittlung_PositionChanged(object sender, System.EventArgs e)
        {
            btnInformationenPerson.Enabled = qryKaVermittlung.Count > 0;
        }

        private void tabBottom_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (DesignMode) return;

            switch (tabBottom.SelectedTabIndex)
            {
                case 3:
                    // Tab Kontaktperson
                    ActiveSQLQuery = qryKaEinsatzplatz;

                    if (ActiveSQLQuery.CanUpdate)
                    {
                        ActiveSQLQuery.Post();
                    }

                    if (qryKaEinsatzplatz.Count == 0)
                    {
                        qryKaKontaktperson.Fill(DBNull.Value);
                    }
                    else
                    {
                        qryKaKontaktperson.Fill(qryKaEinsatzplatz["KaBetriebID"]);
                    }

                    edtKontaktperson.Properties.DropDownRows = 7;

                    break;

                case 4:
                    // Tab Vermittlung
                    ActiveSQLQuery = qryKaEinsatzplatz;
                    btnInformationenPerson.Enabled = qryKaVermittlung.Count > 0;
                    break;

                default:
                    ActiveSQLQuery = qryKaEinsatzplatz;
                    break;
            }

            btnKontaktdatenAendern.Enabled = (!DBUtil.IsEmpty(qryKaEinsatzplatz["KaKontaktpersonID"]));
        }

        private void tabBottom_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ActiveSQLQuery.Row != null && ActiveSQLQuery.CanUpdate && ActiveSQLQuery.Row.RowState != DataRowState.Added)
            {
                e.Cancel = !ActiveSQLQuery.Post();
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            tabBottom.SelectedTabIndex = 0;

            tpgKontakt.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgVermittlung.Enabled = tabControlSearch.SelectedTabIndex == 0;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "KAEINSATZPLATZID":
                    return qryKaEinsatzplatz["KaEinsatzplatzID"];

                case "OWNERUSERID":
                    return Session.User.UserID;
            }

            return base.GetContextValue(fieldName);
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "LoadEP":
                    if (!param.Contains("KaEinsatzplatzID")) param["KaEinsatzplatzID"] = -1;

                    ActiveSQLQuery = qryKaEinsatzplatz;
                    tabControlSearch.SelectedTabIndex = 0;
                    tabBottom.SelectedTabIndex = 0;
                    qryKaEinsatzplatz.Find(string.Format("KaEinsatzplatzID = {0}", param["KaEinsatzplatzID"]));

                    return true;
            }

            // did not understand message
            return false;
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // do sorting of LOVs
            edtLehrberuf.SortByFirstColumn();
        }

        #endregion

        #region Private Methods

        private void SetEditMode()
        {
            if (!chkAufteilbar.Checked)
            {
                if (qryKaEinsatzplatz.CanUpdate)
                {
                    edtEinzelpensumVon.EditValue = DBNull.Value;
                    edtEinzelpensumBis.EditValue = DBNull.Value;
                }

                edtEinzelpensumVon.EditMode = EditModeType.ReadOnly;
                edtEinzelpensumBis.EditMode = EditModeType.ReadOnly;
            }

            if (!IsReadOnly)
            {
                qryKaEinsatzplatz.CanInsert = DBUtil.UserHasRight("CtlKaEinsatzplaetze", "I");
                qryKaEinsatzplatz.CanUpdate = DBUtil.UserHasRight("CtlKaEinsatzplaetze", "U");
                qryKaEinsatzplatz.CanDelete = DBUtil.UserHasRight("CtlKaEinsatzplaetze", "D");
            }
            else
            {
                qryKaEinsatzplatz.CanInsert = false;
                qryKaEinsatzplatz.CanUpdate = false;
                qryKaEinsatzplatz.CanDelete = false;
            }

            qryKaEinsatzplatz.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}