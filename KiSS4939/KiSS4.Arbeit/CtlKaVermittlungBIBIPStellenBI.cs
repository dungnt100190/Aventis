using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaVermittlungBIBIPStellenBI : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        bool MayClose = false;
        bool MayDel = false;
        bool MayIns = false;
        bool MayRead = false;
        bool MayReopen = false;
        bool MayUpd = false;
        private int baPersonID = -1;
        private KiSS4.Gui.KissButton btnDetailsEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzBis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colResultat;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlag;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtAblehnungsgrund;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussDurch;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrund;
        private KiSS4.Gui.KissCalcEdit edtBeteiligungEAZ;
        private KiSS4.Gui.KissTextEdit edtBetrieb;
        private KiSS4.Gui.KissCalcEdit edtBruttolohn;
        private KiSS4.Gui.KissMemoEdit edtEAZBemerkung;
        private KiSS4.Gui.KissDateEdit edtEAZDatumBis;
        private KiSS4.Gui.KissDateEdit edtEAZDatumVon;
        private KiSS4.Gui.KissCheckEdit edtEAZUnterschrieben;
        private KiSS4.Gui.KissCheckEdit edtEAZVerlaengert;
        private KiSS4.Gui.KissDateEdit edtEinsatzAb;
        private KiSS4.Gui.KissDateEdit edtEinsatzBis;
        private KiSS4.Gui.KissDateEdit edtEinsatzende;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatz;
        private KissTextEdit edtEinsatzplatzNr;
        private KiSS4.Dokument.XDokument edtEinsatzvereinbarungDokument;
        private KiSS4.Gui.KissCalcEdit edtFinanzierungsgrad;
        private KiSS4.Gui.KissTextEdit edtKontaktperson;
        private KiSS4.Gui.KissCalcEdit edtPensum;
        private KiSS4.Gui.KissLookUpEdit edtResultat;
        private KiSS4.Gui.KissDateEdit edtResultatDatum;
        private KiSS4.Gui.KissCheckEdit edtUnbefristet;
        private KiSS4.Gui.KissTextEdit edtVerantwortlicherEinsatzplatz;
        private KiSS4.Gui.KissCheckEdit edtVerlaengert;
        private KiSS4.Gui.KissMemoEdit edtVorschlagBemerkungen;
        private KiSS4.Gui.KissDateEdit edtVorschlagDatum;
        private int faLeistungID = -1;
        private KiSS4.Gui.KissGrid grdVermittlungSiEinsaetze;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVermittlungSiEinsaetze;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lbKontaktperson;
        private KiSS4.Gui.KissLabel lblAblehnungsgrund;
        private KiSS4.Gui.KissLabel lblAbschlussDurch;
        private KiSS4.Gui.KissLabel lblArbeitspensum;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBeteiligungEAZ;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissLabel lblBruttolohn;
        private KiSS4.Gui.KissLabel lblCHF;
        private KiSS4.Gui.KissLabel lblCHF2;
        private KiSS4.Gui.KissLabel lblEAZBemerkung;
        private KiSS4.Gui.KissLabel lblEAZBis;
        private KiSS4.Gui.KissLabel lblEAZVon;
        private KiSS4.Gui.KissMemoEdit lblEinsatzBemerkungen;
        private KiSS4.Gui.KissLabel lblEinsatzende;
        private KiSS4.Gui.KissLabel lblEinsatzendeDatum;
        private KiSS4.Gui.KissLabel lblEinsatzplatz;
        private KissLabel lblEinsatzplatzNr;
        private KiSS4.Gui.KissLabel lblFinanzierungsgrad;
        private KiSS4.Gui.KissLabel lblGrund;
        private KiSS4.Gui.KissLabel lblProzent;
        private KiSS4.Gui.KissLabel lblProzentEAZ;
        private KiSS4.Gui.KissLabel lblResultat;
        private KiSS4.Gui.KissLabel lblResultatDatum;
        private KiSS4.Gui.KissLabel lblStelleBis;
        private KiSS4.Gui.KissLabel lblStelleab;
        private KiSS4.Gui.KissLabel lblTitelResultat;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblVerantwortlicherEinsatzplatz;
        private KiSS4.Gui.KissLabel lblVereinbarungEAZ;
        private KiSS4.Gui.KissLabel lblVorschlagBemerkungen;
        private KiSS4.Gui.KissLabel lblVorschlagDatum;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryBIBewerbung;
        private KiSS4.DB.SqlQuery qryBIStelle;
        private KiSS4.Gui.KissTabControlEx tabEinsaetze;
        private SharpLibrary.WinControls.TabPageEx tpgBewerbung;
        private SharpLibrary.WinControls.TabPageEx tpgEAZ;
        private SharpLibrary.WinControls.TabPageEx tpgStelle;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungBIBIPStellenBI()
        {
            this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaVermittlungBIBIPStellenBI));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabEinsaetze = new KiSS4.Gui.KissTabControlEx();
            this.tpgEAZ = new SharpLibrary.WinControls.TabPageEx();
            this.lblEAZBemerkung = new KiSS4.Gui.KissLabel();
            this.edtEAZBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryBIStelle = new KiSS4.DB.SqlQuery(this.components);
            this.lblCHF2 = new KiSS4.Gui.KissLabel();
            this.lblProzentEAZ = new KiSS4.Gui.KissLabel();
            this.lblCHF = new KiSS4.Gui.KissLabel();
            this.lblBeteiligungEAZ = new KiSS4.Gui.KissLabel();
            this.lblFinanzierungsgrad = new KiSS4.Gui.KissLabel();
            this.lblBruttolohn = new KiSS4.Gui.KissLabel();
            this.edtEAZVerlaengert = new KiSS4.Gui.KissCheckEdit();
            this.edtBeteiligungEAZ = new KiSS4.Gui.KissCalcEdit();
            this.edtFinanzierungsgrad = new KiSS4.Gui.KissCalcEdit();
            this.edtBruttolohn = new KiSS4.Gui.KissCalcEdit();
            this.edtEAZUnterschrieben = new KiSS4.Gui.KissCheckEdit();
            this.edtEinsatzvereinbarungDokument = new KiSS4.Dokument.XDokument();
            this.lblVereinbarungEAZ = new KiSS4.Gui.KissLabel();
            this.edtEAZDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtEAZDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblEAZBis = new KiSS4.Gui.KissLabel();
            this.lblEAZVon = new KiSS4.Gui.KissLabel();
            this.tpgStelle = new SharpLibrary.WinControls.TabPageEx();
            this.edtVerlaengert = new KiSS4.Gui.KissCheckEdit();
            this.edtUnbefristet = new KiSS4.Gui.KissCheckEdit();
            this.edtEinsatzBis = new KiSS4.Gui.KissDateEdit();
            this.lblStelleBis = new KiSS4.Gui.KissLabel();
            this.lblEinsatzende = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.lblAbschlussDurch = new KiSS4.Gui.KissLabel();
            this.lblProzent = new KiSS4.Gui.KissLabel();
            this.lblArbeitspensum = new KiSS4.Gui.KissLabel();
            this.lblStelleab = new KiSS4.Gui.KissLabel();
            this.lblEinsatzBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.edtAbschlussGrund = new KiSS4.Gui.KissLookUpEdit();
            this.edtAbschlussDurch = new KiSS4.Gui.KissLookUpEdit();
            this.edtEinsatzende = new KiSS4.Gui.KissDateEdit();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.edtPensum = new KiSS4.Gui.KissCalcEdit();
            this.lblEinsatzendeDatum = new KiSS4.Gui.KissLabel();
            this.edtEinsatzAb = new KiSS4.Gui.KissDateEdit();
            this.tpgBewerbung = new SharpLibrary.WinControls.TabPageEx();
            this.lblVorschlagBemerkungen = new KiSS4.Gui.KissLabel();
            this.lblAblehnungsgrund = new KiSS4.Gui.KissLabel();
            this.edtVorschlagBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.qryBIBewerbung = new KiSS4.DB.SqlQuery(this.components);
            this.lblResultat = new KiSS4.Gui.KissLabel();
            this.edtAblehnungsgrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblResultatDatum = new KiSS4.Gui.KissLabel();
            this.edtResultat = new KiSS4.Gui.KissLookUpEdit();
            this.lblTitelResultat = new KiSS4.Gui.KissLabel();
            this.edtResultatDatum = new KiSS4.Gui.KissDateEdit();
            this.lblVorschlagDatum = new KiSS4.Gui.KissLabel();
            this.edtVorschlagDatum = new KiSS4.Gui.KissDateEdit();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.lbKontaktperson = new KiSS4.Gui.KissLabel();
            this.grdVermittlungSiEinsaetze = new KiSS4.Gui.KissGrid();
            this.grvVermittlungSiEinsaetze = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVorschlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDetailsEinsatzplatz = new KiSS4.Gui.KissButton();
            this.edtEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.edtBetrieb = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktperson = new KiSS4.Gui.KissTextEdit();
            this.edtVerantwortlicherEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.lblVerantwortlicherEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.lblEinsatzplatzNr = new KiSS4.Gui.KissLabel();
            this.edtEinsatzplatzNr = new KiSS4.Gui.KissTextEdit();
            this.tabEinsaetze.SuspendLayout();
            this.tpgEAZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEAZBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIStelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzentEAZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeteiligungEAZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierungsgrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBruttolohn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZVerlaengert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeteiligungEAZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzierungsgrad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBruttolohn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZUnterschrieben.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzvereinbarungDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarungEAZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEAZBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEAZVon)).BeginInit();
            this.tpgStelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerlaengert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnbefristet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStelleBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzende)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitspensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStelleab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzende.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzendeDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzAb.Properties)).BeginInit();
            this.tpgBewerbung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAblehnungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIBewerbung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultatDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagDatum.Properties)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVermittlungSiEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlungSiEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlicherEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerantwortlicherEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEinsaetze
            // 
            this.tabEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabEinsaetze.Controls.Add(this.tpgEAZ);
            this.tabEinsaetze.Controls.Add(this.tpgStelle);
            this.tabEinsaetze.Controls.Add(this.tpgBewerbung);
            this.tabEinsaetze.Location = new System.Drawing.Point(3, 302);
            this.tabEinsaetze.Name = "tabEinsaetze";
            this.tabEinsaetze.SelectedTabIndex = 1;
            this.tabEinsaetze.ShowFixedWidthTooltip = true;
            this.tabEinsaetze.Size = new System.Drawing.Size(707, 252);
            this.tabEinsaetze.TabIndex = 0;
            this.tabEinsaetze.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBewerbung,
            this.tpgStelle,
            this.tpgEAZ});
            this.tabEinsaetze.TabsLineColor = System.Drawing.Color.Black;
            this.tabEinsaetze.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabEinsaetze.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgEAZ
            // 
            this.tpgEAZ.Controls.Add(this.lblEAZBemerkung);
            this.tpgEAZ.Controls.Add(this.edtEAZBemerkung);
            this.tpgEAZ.Controls.Add(this.lblCHF2);
            this.tpgEAZ.Controls.Add(this.lblProzentEAZ);
            this.tpgEAZ.Controls.Add(this.lblCHF);
            this.tpgEAZ.Controls.Add(this.lblBeteiligungEAZ);
            this.tpgEAZ.Controls.Add(this.lblFinanzierungsgrad);
            this.tpgEAZ.Controls.Add(this.lblBruttolohn);
            this.tpgEAZ.Controls.Add(this.edtEAZVerlaengert);
            this.tpgEAZ.Controls.Add(this.edtBeteiligungEAZ);
            this.tpgEAZ.Controls.Add(this.edtFinanzierungsgrad);
            this.tpgEAZ.Controls.Add(this.edtBruttolohn);
            this.tpgEAZ.Controls.Add(this.edtEAZUnterschrieben);
            this.tpgEAZ.Controls.Add(this.edtEinsatzvereinbarungDokument);
            this.tpgEAZ.Controls.Add(this.lblVereinbarungEAZ);
            this.tpgEAZ.Controls.Add(this.edtEAZDatumBis);
            this.tpgEAZ.Controls.Add(this.edtEAZDatumVon);
            this.tpgEAZ.Controls.Add(this.lblEAZBis);
            this.tpgEAZ.Controls.Add(this.lblEAZVon);
            this.tpgEAZ.Location = new System.Drawing.Point(6, 32);
            this.tpgEAZ.Name = "tpgEAZ";
            this.tpgEAZ.Size = new System.Drawing.Size(695, 214);
            this.tpgEAZ.TabIndex = 1;
            this.tpgEAZ.Title = "EAZ";
            // 
            // lblEAZBemerkung
            // 
            this.lblEAZBemerkung.Location = new System.Drawing.Point(373, 3);
            this.lblEAZBemerkung.Name = "lblEAZBemerkung";
            this.lblEAZBemerkung.Size = new System.Drawing.Size(76, 24);
            this.lblEAZBemerkung.TabIndex = 66;
            this.lblEAZBemerkung.Text = "Bemerkungen";
            this.lblEAZBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtEAZBemerkung
            // 
            this.edtEAZBemerkung.DataMember = "BIEAZBemerkung";
            this.edtEAZBemerkung.DataSource = this.qryBIStelle;
            this.edtEAZBemerkung.Location = new System.Drawing.Point(373, 30);
            this.edtEAZBemerkung.Name = "edtEAZBemerkung";
            this.edtEAZBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEAZBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEAZBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEAZBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtEAZBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEAZBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtEAZBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEAZBemerkung.Size = new System.Drawing.Size(319, 76);
            this.edtEAZBemerkung.TabIndex = 65;
            // 
            // qryBIStelle
            // 
            this.qryBIStelle.CanDelete = true;
            this.qryBIStelle.CanUpdate = true;
            this.qryBIStelle.HostControl = this;
            this.qryBIStelle.IsIdentityInsert = false;
            this.qryBIStelle.SelectStatement = "SELECT\tVEI.*\r\nFROM KaVermittlungEinsatz VEI\r\nWHERE VEI.KaVermittlungVorschlagID =" +
    " {0}";
            this.qryBIStelle.TableName = "KaVermittlungEinsatz";
            this.qryBIStelle.BeforePost += new System.EventHandler(this.qryBIStelle_BeforePost);
            this.qryBIStelle.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryBIStelle_ColumnChanging);
            // 
            // lblCHF2
            // 
            this.lblCHF2.Location = new System.Drawing.Point(201, 177);
            this.lblCHF2.Name = "lblCHF2";
            this.lblCHF2.Size = new System.Drawing.Size(22, 24);
            this.lblCHF2.TabIndex = 16;
            this.lblCHF2.Text = "CHF";
            this.lblCHF2.UseCompatibleTextRendering = true;
            // 
            // lblProzentEAZ
            // 
            this.lblProzentEAZ.Location = new System.Drawing.Point(182, 146);
            this.lblProzentEAZ.Name = "lblProzentEAZ";
            this.lblProzentEAZ.Size = new System.Drawing.Size(18, 24);
            this.lblProzentEAZ.TabIndex = 15;
            this.lblProzentEAZ.Text = "%";
            this.lblProzentEAZ.UseCompatibleTextRendering = true;
            // 
            // lblCHF
            // 
            this.lblCHF.Location = new System.Drawing.Point(201, 114);
            this.lblCHF.Name = "lblCHF";
            this.lblCHF.Size = new System.Drawing.Size(22, 24);
            this.lblCHF.TabIndex = 14;
            this.lblCHF.Text = "CHF";
            this.lblCHF.UseCompatibleTextRendering = true;
            // 
            // lblBeteiligungEAZ
            // 
            this.lblBeteiligungEAZ.Location = new System.Drawing.Point(4, 178);
            this.lblBeteiligungEAZ.Name = "lblBeteiligungEAZ";
            this.lblBeteiligungEAZ.Size = new System.Drawing.Size(100, 23);
            this.lblBeteiligungEAZ.TabIndex = 13;
            this.lblBeteiligungEAZ.Text = "Beteiligung EAZ";
            this.lblBeteiligungEAZ.UseCompatibleTextRendering = true;
            // 
            // lblFinanzierungsgrad
            // 
            this.lblFinanzierungsgrad.Location = new System.Drawing.Point(4, 147);
            this.lblFinanzierungsgrad.Name = "lblFinanzierungsgrad";
            this.lblFinanzierungsgrad.Size = new System.Drawing.Size(100, 23);
            this.lblFinanzierungsgrad.TabIndex = 12;
            this.lblFinanzierungsgrad.Text = "Finanzierungsgrad";
            this.lblFinanzierungsgrad.UseCompatibleTextRendering = true;
            // 
            // lblBruttolohn
            // 
            this.lblBruttolohn.Location = new System.Drawing.Point(4, 116);
            this.lblBruttolohn.Name = "lblBruttolohn";
            this.lblBruttolohn.Size = new System.Drawing.Size(100, 23);
            this.lblBruttolohn.TabIndex = 11;
            this.lblBruttolohn.Text = "Bruttolohn";
            this.lblBruttolohn.UseCompatibleTextRendering = true;
            // 
            // edtEAZVerlaengert
            // 
            this.edtEAZVerlaengert.DataMember = "BIEAZVerlaengert";
            this.edtEAZVerlaengert.DataSource = this.qryBIStelle;
            this.edtEAZVerlaengert.Location = new System.Drawing.Point(225, 38);
            this.edtEAZVerlaengert.Name = "edtEAZVerlaengert";
            this.edtEAZVerlaengert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEAZVerlaengert.Properties.Appearance.Options.UseBackColor = true;
            this.edtEAZVerlaengert.Properties.Caption = "verlängert";
            this.edtEAZVerlaengert.Size = new System.Drawing.Size(75, 19);
            this.edtEAZVerlaengert.TabIndex = 10;
            // 
            // edtBeteiligungEAZ
            // 
            this.edtBeteiligungEAZ.DataMember = "BIBeteilungEAZ";
            this.edtBeteiligungEAZ.DataSource = this.qryBIStelle;
            this.edtBeteiligungEAZ.Location = new System.Drawing.Point(118, 177);
            this.edtBeteiligungEAZ.Name = "edtBeteiligungEAZ";
            this.edtBeteiligungEAZ.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBeteiligungEAZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeteiligungEAZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeteiligungEAZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeteiligungEAZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeteiligungEAZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeteiligungEAZ.Properties.Appearance.Options.UseFont = true;
            this.edtBeteiligungEAZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeteiligungEAZ.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeteiligungEAZ.Properties.DisplayFormat.FormatString = "n2";
            this.edtBeteiligungEAZ.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBeteiligungEAZ.Properties.EditFormat.FormatString = "n2";
            this.edtBeteiligungEAZ.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBeteiligungEAZ.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtBeteiligungEAZ.Size = new System.Drawing.Size(77, 24);
            this.edtBeteiligungEAZ.TabIndex = 9;
            // 
            // edtFinanzierungsgrad
            // 
            this.edtFinanzierungsgrad.DataMember = "BIFinanzierungsgradEAZ";
            this.edtFinanzierungsgrad.DataSource = this.qryBIStelle;
            this.edtFinanzierungsgrad.Location = new System.Drawing.Point(118, 146);
            this.edtFinanzierungsgrad.Name = "edtFinanzierungsgrad";
            this.edtFinanzierungsgrad.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFinanzierungsgrad.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFinanzierungsgrad.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFinanzierungsgrad.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFinanzierungsgrad.Properties.Appearance.Options.UseBackColor = true;
            this.edtFinanzierungsgrad.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFinanzierungsgrad.Properties.Appearance.Options.UseFont = true;
            this.edtFinanzierungsgrad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFinanzierungsgrad.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFinanzierungsgrad.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtFinanzierungsgrad.Size = new System.Drawing.Size(58, 24);
            this.edtFinanzierungsgrad.TabIndex = 8;
            // 
            // edtBruttolohn
            // 
            this.edtBruttolohn.DataMember = "BIBruttolohn";
            this.edtBruttolohn.DataSource = this.qryBIStelle;
            this.edtBruttolohn.Location = new System.Drawing.Point(118, 115);
            this.edtBruttolohn.Name = "edtBruttolohn";
            this.edtBruttolohn.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBruttolohn.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBruttolohn.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBruttolohn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBruttolohn.Properties.Appearance.Options.UseBackColor = true;
            this.edtBruttolohn.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBruttolohn.Properties.Appearance.Options.UseFont = true;
            this.edtBruttolohn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBruttolohn.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBruttolohn.Properties.DisplayFormat.FormatString = "n2";
            this.edtBruttolohn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBruttolohn.Properties.EditFormat.FormatString = "n2";
            this.edtBruttolohn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBruttolohn.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtBruttolohn.Size = new System.Drawing.Size(77, 24);
            this.edtBruttolohn.TabIndex = 7;
            // 
            // edtEAZUnterschrieben
            // 
            this.edtEAZUnterschrieben.DataMember = "BIEAZVereinbarungUnterschrieben";
            this.edtEAZUnterschrieben.DataSource = this.qryBIStelle;
            this.edtEAZUnterschrieben.Location = new System.Drawing.Point(241, 87);
            this.edtEAZUnterschrieben.Name = "edtEAZUnterschrieben";
            this.edtEAZUnterschrieben.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEAZUnterschrieben.Properties.Appearance.Options.UseBackColor = true;
            this.edtEAZUnterschrieben.Properties.Caption = "unterschrieben";
            this.edtEAZUnterschrieben.Size = new System.Drawing.Size(99, 19);
            this.edtEAZUnterschrieben.TabIndex = 6;
            // 
            // edtEinsatzvereinbarungDokument
            // 
            this.edtEinsatzvereinbarungDokument.Context = "KaVermBIEAZVereinbarung";
            this.edtEinsatzvereinbarungDokument.DataMember = "BIEAZVereinbarungDokID";
            this.edtEinsatzvereinbarungDokument.DataSource = this.qryBIStelle;
            this.edtEinsatzvereinbarungDokument.Location = new System.Drawing.Point(118, 84);
            this.edtEinsatzvereinbarungDokument.Name = "edtEinsatzvereinbarungDokument";
            this.edtEinsatzvereinbarungDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzvereinbarungDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzvereinbarungDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzvereinbarungDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzvereinbarungDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzvereinbarungDokument.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzvereinbarungDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEinsatzvereinbarungDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzvereinbarungDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzvereinbarungDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzvereinbarungDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzvereinbarungDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtEinsatzvereinbarungDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzvereinbarungDokument.Properties.ReadOnly = true;
            this.edtEinsatzvereinbarungDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtEinsatzvereinbarungDokument.Size = new System.Drawing.Size(116, 24);
            this.edtEinsatzvereinbarungDokument.TabIndex = 5;
            // 
            // lblVereinbarungEAZ
            // 
            this.lblVereinbarungEAZ.Location = new System.Drawing.Point(4, 85);
            this.lblVereinbarungEAZ.Name = "lblVereinbarungEAZ";
            this.lblVereinbarungEAZ.Size = new System.Drawing.Size(100, 23);
            this.lblVereinbarungEAZ.TabIndex = 4;
            this.lblVereinbarungEAZ.Text = "Vereinbarung EAZ";
            this.lblVereinbarungEAZ.UseCompatibleTextRendering = true;
            // 
            // edtEAZDatumBis
            // 
            this.edtEAZDatumBis.DataMember = "BIEAZDatumBis";
            this.edtEAZDatumBis.DataSource = this.qryBIStelle;
            this.edtEAZDatumBis.EditValue = null;
            this.edtEAZDatumBis.Location = new System.Drawing.Point(118, 35);
            this.edtEAZDatumBis.Name = "edtEAZDatumBis";
            this.edtEAZDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEAZDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEAZDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEAZDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEAZDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEAZDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEAZDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtEAZDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtEAZDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEAZDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtEAZDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEAZDatumBis.Properties.ShowToday = false;
            this.edtEAZDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtEAZDatumBis.TabIndex = 3;
            this.edtEAZDatumBis.Leave += new System.EventHandler(this.datLeaveEAZDatum);
            // 
            // edtEAZDatumVon
            // 
            this.edtEAZDatumVon.DataMember = "BIEAZDatumVon";
            this.edtEAZDatumVon.DataSource = this.qryBIStelle;
            this.edtEAZDatumVon.EditValue = null;
            this.edtEAZDatumVon.Location = new System.Drawing.Point(118, 5);
            this.edtEAZDatumVon.Name = "edtEAZDatumVon";
            this.edtEAZDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEAZDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEAZDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEAZDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEAZDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEAZDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEAZDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtEAZDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtEAZDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEAZDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtEAZDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEAZDatumVon.Properties.ShowToday = false;
            this.edtEAZDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtEAZDatumVon.TabIndex = 2;
            this.edtEAZDatumVon.Leave += new System.EventHandler(this.datLeaveEAZDatum);
            // 
            // lblEAZBis
            // 
            this.lblEAZBis.Location = new System.Drawing.Point(4, 35);
            this.lblEAZBis.Name = "lblEAZBis";
            this.lblEAZBis.Size = new System.Drawing.Size(23, 24);
            this.lblEAZBis.TabIndex = 1;
            this.lblEAZBis.Text = "bis";
            this.lblEAZBis.UseCompatibleTextRendering = true;
            // 
            // lblEAZVon
            // 
            this.lblEAZVon.Location = new System.Drawing.Point(4, 4);
            this.lblEAZVon.Name = "lblEAZVon";
            this.lblEAZVon.Size = new System.Drawing.Size(100, 23);
            this.lblEAZVon.TabIndex = 0;
            this.lblEAZVon.Text = "EAZ von";
            this.lblEAZVon.UseCompatibleTextRendering = true;
            // 
            // tpgStelle
            // 
            this.tpgStelle.Controls.Add(this.edtVerlaengert);
            this.tpgStelle.Controls.Add(this.edtUnbefristet);
            this.tpgStelle.Controls.Add(this.edtEinsatzBis);
            this.tpgStelle.Controls.Add(this.lblStelleBis);
            this.tpgStelle.Controls.Add(this.lblEinsatzende);
            this.tpgStelle.Controls.Add(this.lblBemerkungen);
            this.tpgStelle.Controls.Add(this.lblAbschlussDurch);
            this.tpgStelle.Controls.Add(this.lblProzent);
            this.tpgStelle.Controls.Add(this.lblArbeitspensum);
            this.tpgStelle.Controls.Add(this.lblStelleab);
            this.tpgStelle.Controls.Add(this.lblEinsatzBemerkungen);
            this.tpgStelle.Controls.Add(this.edtAbschlussGrund);
            this.tpgStelle.Controls.Add(this.edtAbschlussDurch);
            this.tpgStelle.Controls.Add(this.edtEinsatzende);
            this.tpgStelle.Controls.Add(this.lblGrund);
            this.tpgStelle.Controls.Add(this.edtPensum);
            this.tpgStelle.Controls.Add(this.lblEinsatzendeDatum);
            this.tpgStelle.Controls.Add(this.edtEinsatzAb);
            this.tpgStelle.Location = new System.Drawing.Point(6, 32);
            this.tpgStelle.Name = "tpgStelle";
            this.tpgStelle.Size = new System.Drawing.Size(695, 214);
            this.tpgStelle.TabIndex = 0;
            this.tpgStelle.Title = "Stelle";
            // 
            // edtVerlaengert
            // 
            this.edtVerlaengert.DataMember = "Verlaengerung";
            this.edtVerlaengert.DataSource = this.qryBIStelle;
            this.edtVerlaengert.Location = new System.Drawing.Point(428, 9);
            this.edtVerlaengert.Name = "edtVerlaengert";
            this.edtVerlaengert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerlaengert.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerlaengert.Properties.Caption = "verlängert";
            this.edtVerlaengert.Size = new System.Drawing.Size(75, 19);
            this.edtVerlaengert.TabIndex = 70;
            // 
            // edtUnbefristet
            // 
            this.edtUnbefristet.DataMember = "Unbefristet";
            this.edtUnbefristet.DataSource = this.qryBIStelle;
            this.edtUnbefristet.Location = new System.Drawing.Point(332, 9);
            this.edtUnbefristet.Name = "edtUnbefristet";
            this.edtUnbefristet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUnbefristet.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnbefristet.Properties.Caption = "unbefristet";
            this.edtUnbefristet.Size = new System.Drawing.Size(79, 19);
            this.edtUnbefristet.TabIndex = 69;
            // 
            // edtEinsatzBis
            // 
            this.edtEinsatzBis.DataMember = "EinsatzBis";
            this.edtEinsatzBis.DataSource = this.qryBIStelle;
            this.edtEinsatzBis.EditValue = null;
            this.edtEinsatzBis.Location = new System.Drawing.Point(226, 4);
            this.edtEinsatzBis.Name = "edtEinsatzBis";
            this.edtEinsatzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtEinsatzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzBis.Properties.ShowToday = false;
            this.edtEinsatzBis.Size = new System.Drawing.Size(100, 24);
            this.edtEinsatzBis.TabIndex = 68;
            this.edtEinsatzBis.Leave += new System.EventHandler(this.datLeaveEinsatz);
            // 
            // lblStelleBis
            // 
            this.lblStelleBis.Location = new System.Drawing.Point(194, 4);
            this.lblStelleBis.Name = "lblStelleBis";
            this.lblStelleBis.Size = new System.Drawing.Size(25, 24);
            this.lblStelleBis.TabIndex = 67;
            this.lblStelleBis.Text = "bis";
            this.lblStelleBis.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzende
            // 
            this.lblEinsatzende.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblEinsatzende.Location = new System.Drawing.Point(5, 62);
            this.lblEinsatzende.Name = "lblEinsatzende";
            this.lblEinsatzende.Size = new System.Drawing.Size(89, 16);
            this.lblEinsatzende.TabIndex = 66;
            this.lblEinsatzende.Text = "Stellenende";
            this.lblEinsatzende.UseCompatibleTextRendering = true;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(4, 133);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(76, 24);
            this.lblBemerkungen.TabIndex = 64;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // lblAbschlussDurch
            // 
            this.lblAbschlussDurch.Location = new System.Drawing.Point(203, 77);
            this.lblAbschlussDurch.Name = "lblAbschlussDurch";
            this.lblAbschlussDurch.Size = new System.Drawing.Size(35, 24);
            this.lblAbschlussDurch.TabIndex = 61;
            this.lblAbschlussDurch.Text = "durch";
            this.lblAbschlussDurch.UseCompatibleTextRendering = true;
            // 
            // lblProzent
            // 
            this.lblProzent.Location = new System.Drawing.Point(134, 32);
            this.lblProzent.Name = "lblProzent";
            this.lblProzent.Size = new System.Drawing.Size(19, 24);
            this.lblProzent.TabIndex = 20;
            this.lblProzent.Text = "%";
            this.lblProzent.UseCompatibleTextRendering = true;
            // 
            // lblArbeitspensum
            // 
            this.lblArbeitspensum.Location = new System.Drawing.Point(5, 31);
            this.lblArbeitspensum.Name = "lblArbeitspensum";
            this.lblArbeitspensum.Size = new System.Drawing.Size(80, 24);
            this.lblArbeitspensum.TabIndex = 18;
            this.lblArbeitspensum.Text = "Arbeitspensum";
            this.lblArbeitspensum.UseCompatibleTextRendering = true;
            // 
            // lblStelleab
            // 
            this.lblStelleab.Location = new System.Drawing.Point(5, 4);
            this.lblStelleab.Name = "lblStelleab";
            this.lblStelleab.Size = new System.Drawing.Size(80, 24);
            this.lblStelleab.TabIndex = 16;
            this.lblStelleab.Text = "Stelle ab";
            this.lblStelleab.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzBemerkungen
            // 
            this.lblEinsatzBemerkungen.DataMember = "EinsatzBemerkungen";
            this.lblEinsatzBemerkungen.DataSource = this.qryBIStelle;
            this.lblEinsatzBemerkungen.Location = new System.Drawing.Point(91, 133);
            this.lblEinsatzBemerkungen.Name = "lblEinsatzBemerkungen";
            this.lblEinsatzBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.lblEinsatzBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.lblEinsatzBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblEinsatzBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.lblEinsatzBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.lblEinsatzBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.lblEinsatzBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblEinsatzBemerkungen.Size = new System.Drawing.Size(604, 81);
            this.lblEinsatzBemerkungen.TabIndex = 9;
            // 
            // edtAbschlussGrund
            // 
            this.edtAbschlussGrund.DataMember = "BIAbschlussGrundCode";
            this.edtAbschlussGrund.DataSource = this.qryBIStelle;
            this.edtAbschlussGrund.Location = new System.Drawing.Point(91, 105);
            this.edtAbschlussGrund.LOVName = "KaVermittlungBIStellenendeGrund";
            this.edtAbschlussGrund.Name = "edtAbschlussGrund";
            this.edtAbschlussGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtAbschlussGrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrund.Properties.NullText = "";
            this.edtAbschlussGrund.Properties.ShowFooter = false;
            this.edtAbschlussGrund.Properties.ShowHeader = false;
            this.edtAbschlussGrund.Size = new System.Drawing.Size(303, 24);
            this.edtAbschlussGrund.TabIndex = 7;
            // 
            // edtAbschlussDurch
            // 
            this.edtAbschlussDurch.DataMember = "BIBIPSIAbschlussDurchCode";
            this.edtAbschlussDurch.DataSource = this.qryBIStelle;
            this.edtAbschlussDurch.Location = new System.Drawing.Point(244, 77);
            this.edtAbschlussDurch.LOVName = "KaVermittlungEinsatzAbschlussDurch";
            this.edtAbschlussDurch.Name = "edtAbschlussDurch";
            this.edtAbschlussDurch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussDurch.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussDurch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussDurch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussDurch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussDurch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtAbschlussDurch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtAbschlussDurch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussDurch.Properties.NullText = "";
            this.edtAbschlussDurch.Properties.ShowFooter = false;
            this.edtAbschlussDurch.Properties.ShowHeader = false;
            this.edtAbschlussDurch.Size = new System.Drawing.Size(150, 24);
            this.edtAbschlussDurch.TabIndex = 6;
            // 
            // edtEinsatzende
            // 
            this.edtEinsatzende.DataMember = "Abschluss";
            this.edtEinsatzende.DataSource = this.qryBIStelle;
            this.edtEinsatzende.EditValue = null;
            this.edtEinsatzende.Location = new System.Drawing.Point(91, 77);
            this.edtEinsatzende.Name = "edtEinsatzende";
            this.edtEinsatzende.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzende.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzende.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzende.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzende.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzende.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzende.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzende.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtEinsatzende.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzende.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtEinsatzende.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzende.Properties.ShowToday = false;
            this.edtEinsatzende.Size = new System.Drawing.Size(96, 24);
            this.edtEinsatzende.TabIndex = 5;
            // 
            // lblGrund
            // 
            this.lblGrund.Location = new System.Drawing.Point(5, 106);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(74, 24);
            this.lblGrund.TabIndex = 4;
            this.lblGrund.Text = "Grund";
            this.lblGrund.UseCompatibleTextRendering = true;
            // 
            // edtPensum
            // 
            this.edtPensum.DataMember = "Arbeitspensum";
            this.edtPensum.DataSource = this.qryBIStelle;
            this.edtPensum.Location = new System.Drawing.Point(91, 32);
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
            this.edtPensum.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtPensum.Size = new System.Drawing.Size(40, 24);
            this.edtPensum.TabIndex = 3;
            this.edtPensum.Leave += new System.EventHandler(this.checkPensum);
            // 
            // lblEinsatzendeDatum
            // 
            this.lblEinsatzendeDatum.Location = new System.Drawing.Point(5, 77);
            this.lblEinsatzendeDatum.Name = "lblEinsatzendeDatum";
            this.lblEinsatzendeDatum.Size = new System.Drawing.Size(66, 24);
            this.lblEinsatzendeDatum.TabIndex = 1;
            this.lblEinsatzendeDatum.Text = "Datum";
            this.lblEinsatzendeDatum.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzAb
            // 
            this.edtEinsatzAb.DataMember = "EinsatzVon";
            this.edtEinsatzAb.DataSource = this.qryBIStelle;
            this.edtEinsatzAb.EditValue = null;
            this.edtEinsatzAb.Location = new System.Drawing.Point(91, 4);
            this.edtEinsatzAb.Name = "edtEinsatzAb";
            this.edtEinsatzAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzAb.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtEinsatzAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtEinsatzAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzAb.Properties.ShowToday = false;
            this.edtEinsatzAb.Size = new System.Drawing.Size(96, 24);
            this.edtEinsatzAb.TabIndex = 0;
            this.edtEinsatzAb.Leave += new System.EventHandler(this.datLeaveEinsatz);
            // 
            // tpgBewerbung
            // 
            this.tpgBewerbung.Controls.Add(this.lblVorschlagBemerkungen);
            this.tpgBewerbung.Controls.Add(this.lblAblehnungsgrund);
            this.tpgBewerbung.Controls.Add(this.edtVorschlagBemerkungen);
            this.tpgBewerbung.Controls.Add(this.lblResultat);
            this.tpgBewerbung.Controls.Add(this.edtAblehnungsgrund);
            this.tpgBewerbung.Controls.Add(this.lblResultatDatum);
            this.tpgBewerbung.Controls.Add(this.edtResultat);
            this.tpgBewerbung.Controls.Add(this.lblTitelResultat);
            this.tpgBewerbung.Controls.Add(this.edtResultatDatum);
            this.tpgBewerbung.Controls.Add(this.lblVorschlagDatum);
            this.tpgBewerbung.Controls.Add(this.edtVorschlagDatum);
            this.tpgBewerbung.Location = new System.Drawing.Point(6, 32);
            this.tpgBewerbung.Name = "tpgBewerbung";
            this.tpgBewerbung.Size = new System.Drawing.Size(695, 214);
            this.tpgBewerbung.TabIndex = 0;
            this.tpgBewerbung.Title = "Bewerbung";
            // 
            // lblVorschlagBemerkungen
            // 
            this.lblVorschlagBemerkungen.Location = new System.Drawing.Point(4, 151);
            this.lblVorschlagBemerkungen.Name = "lblVorschlagBemerkungen";
            this.lblVorschlagBemerkungen.Size = new System.Drawing.Size(90, 24);
            this.lblVorschlagBemerkungen.TabIndex = 5;
            this.lblVorschlagBemerkungen.Text = "Bemerkungen";
            this.lblVorschlagBemerkungen.UseCompatibleTextRendering = true;
            // 
            // lblAblehnungsgrund
            // 
            this.lblAblehnungsgrund.Location = new System.Drawing.Point(4, 121);
            this.lblAblehnungsgrund.Name = "lblAblehnungsgrund";
            this.lblAblehnungsgrund.Size = new System.Drawing.Size(90, 24);
            this.lblAblehnungsgrund.TabIndex = 4;
            this.lblAblehnungsgrund.Text = "Ablehnungsgrund";
            this.lblAblehnungsgrund.UseCompatibleTextRendering = true;
            // 
            // edtVorschlagBemerkungen
            // 
            this.edtVorschlagBemerkungen.DataMember = "VorschlagBemerkungen";
            this.edtVorschlagBemerkungen.DataSource = this.qryBIBewerbung;
            this.edtVorschlagBemerkungen.Location = new System.Drawing.Point(98, 158);
            this.edtVorschlagBemerkungen.Name = "edtVorschlagBemerkungen";
            this.edtVorschlagBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorschlagBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorschlagBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorschlagBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorschlagBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorschlagBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtVorschlagBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorschlagBemerkungen.Size = new System.Drawing.Size(597, 55);
            this.edtVorschlagBemerkungen.TabIndex = 4;
            // 
            // qryBIBewerbung
            // 
            this.qryBIBewerbung.CanDelete = true;
            this.qryBIBewerbung.CanUpdate = true;
            this.qryBIBewerbung.HostControl = this;
            this.qryBIBewerbung.IsIdentityInsert = false;
            this.qryBIBewerbung.SelectStatement = resources.GetString("qryBIBewerbung.SelectStatement");
            this.qryBIBewerbung.TableName = "KaVermittlungVorschlag";
            this.qryBIBewerbung.AfterFill += new System.EventHandler(this.qryBIBewerbung_AfterFill);
            this.qryBIBewerbung.AfterPost += new System.EventHandler(this.qryBIBewerbung_AfterPost);
            this.qryBIBewerbung.BeforeDelete += new System.EventHandler(this.qryBIBewerbung_BeforeDelete);
            this.qryBIBewerbung.PositionChanged += new System.EventHandler(this.qryBIBewerbung_PositionChanged);
            // 
            // lblResultat
            // 
            this.lblResultat.Location = new System.Drawing.Point(4, 91);
            this.lblResultat.Name = "lblResultat";
            this.lblResultat.Size = new System.Drawing.Size(90, 24);
            this.lblResultat.TabIndex = 3;
            this.lblResultat.Text = "Resultat";
            this.lblResultat.UseCompatibleTextRendering = true;
            // 
            // edtAblehnungsgrund
            // 
            this.edtAblehnungsgrund.DataMember = "VorschlagAblehnungsgrundBICode";
            this.edtAblehnungsgrund.DataSource = this.qryBIBewerbung;
            this.edtAblehnungsgrund.Location = new System.Drawing.Point(99, 121);
            this.edtAblehnungsgrund.LOVName = "KaVermittlungVorschlagAblehnungsgrund";
            this.edtAblehnungsgrund.Name = "edtAblehnungsgrund";
            this.edtAblehnungsgrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAblehnungsgrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAblehnungsgrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAblehnungsgrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtAblehnungsgrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAblehnungsgrund.Properties.Appearance.Options.UseFont = true;
            this.edtAblehnungsgrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAblehnungsgrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAblehnungsgrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAblehnungsgrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAblehnungsgrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtAblehnungsgrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtAblehnungsgrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAblehnungsgrund.Properties.NullText = "";
            this.edtAblehnungsgrund.Properties.ShowFooter = false;
            this.edtAblehnungsgrund.Properties.ShowHeader = false;
            this.edtAblehnungsgrund.Size = new System.Drawing.Size(351, 24);
            this.edtAblehnungsgrund.TabIndex = 3;
            // 
            // lblResultatDatum
            // 
            this.lblResultatDatum.Location = new System.Drawing.Point(4, 61);
            this.lblResultatDatum.Name = "lblResultatDatum";
            this.lblResultatDatum.Size = new System.Drawing.Size(90, 24);
            this.lblResultatDatum.TabIndex = 2;
            this.lblResultatDatum.Text = "Datum";
            this.lblResultatDatum.UseCompatibleTextRendering = true;
            // 
            // edtResultat
            // 
            this.edtResultat.DataMember = "VorschlagResultat";
            this.edtResultat.DataSource = this.qryBIBewerbung;
            this.edtResultat.Location = new System.Drawing.Point(99, 91);
            this.edtResultat.LOVName = "KaVorschlagResultat";
            this.edtResultat.Name = "edtResultat";
            this.edtResultat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtResultat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtResultat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtResultat.Properties.Appearance.Options.UseBackColor = true;
            this.edtResultat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtResultat.Properties.Appearance.Options.UseFont = true;
            this.edtResultat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtResultat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtResultat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtResultat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtResultat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtResultat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtResultat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtResultat.Properties.NullText = "";
            this.edtResultat.Properties.ShowFooter = false;
            this.edtResultat.Properties.ShowHeader = false;
            this.edtResultat.Size = new System.Drawing.Size(351, 24);
            this.edtResultat.TabIndex = 2;
            // 
            // lblTitelResultat
            // 
            this.lblTitelResultat.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelResultat.Location = new System.Drawing.Point(2, 44);
            this.lblTitelResultat.Name = "lblTitelResultat";
            this.lblTitelResultat.Size = new System.Drawing.Size(90, 16);
            this.lblTitelResultat.TabIndex = 1;
            this.lblTitelResultat.Text = "Resultat";
            this.lblTitelResultat.UseCompatibleTextRendering = true;
            // 
            // edtResultatDatum
            // 
            this.edtResultatDatum.DataMember = "VorschlagResultatDatum";
            this.edtResultatDatum.DataSource = this.qryBIBewerbung;
            this.edtResultatDatum.EditValue = null;
            this.edtResultatDatum.Location = new System.Drawing.Point(99, 61);
            this.edtResultatDatum.Name = "edtResultatDatum";
            this.edtResultatDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtResultatDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtResultatDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtResultatDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtResultatDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtResultatDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtResultatDatum.Properties.Appearance.Options.UseFont = true;
            this.edtResultatDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtResultatDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtResultatDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtResultatDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtResultatDatum.Properties.ShowToday = false;
            this.edtResultatDatum.Size = new System.Drawing.Size(100, 24);
            this.edtResultatDatum.TabIndex = 1;
            // 
            // lblVorschlagDatum
            // 
            this.lblVorschlagDatum.Location = new System.Drawing.Point(4, 9);
            this.lblVorschlagDatum.Name = "lblVorschlagDatum";
            this.lblVorschlagDatum.Size = new System.Drawing.Size(90, 24);
            this.lblVorschlagDatum.TabIndex = 0;
            this.lblVorschlagDatum.Text = "Bewerbung";
            this.lblVorschlagDatum.UseCompatibleTextRendering = true;
            // 
            // edtVorschlagDatum
            // 
            this.edtVorschlagDatum.DataMember = "Vorschlag";
            this.edtVorschlagDatum.DataSource = this.qryBIBewerbung;
            this.edtVorschlagDatum.EditValue = null;
            this.edtVorschlagDatum.Location = new System.Drawing.Point(99, 9);
            this.edtVorschlagDatum.Name = "edtVorschlagDatum";
            this.edtVorschlagDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVorschlagDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorschlagDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorschlagDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorschlagDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorschlagDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorschlagDatum.Properties.Appearance.Options.UseFont = true;
            this.edtVorschlagDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtVorschlagDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVorschlagDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtVorschlagDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVorschlagDatum.Properties.ShowToday = false;
            this.edtVorschlagDatum.Size = new System.Drawing.Size(100, 24);
            this.edtVorschlagDatum.TabIndex = 0;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(722, 40);
            this.pnTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Stellen BI";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // lblEinsatzplatz
            // 
            this.lblEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinsatzplatz.Location = new System.Drawing.Point(6, 202);
            this.lblEinsatzplatz.Name = "lblEinsatzplatz";
            this.lblEinsatzplatz.Size = new System.Drawing.Size(75, 24);
            this.lblEinsatzplatz.TabIndex = 10;
            this.lblEinsatzplatz.Text = "Bezeichnung";
            this.lblEinsatzplatz.UseCompatibleTextRendering = true;
            // 
            // lblBetrieb
            // 
            this.lblBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrieb.Location = new System.Drawing.Point(6, 227);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(75, 24);
            this.lblBetrieb.TabIndex = 12;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            // 
            // lbKontaktperson
            // 
            this.lbKontaktperson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbKontaktperson.Location = new System.Drawing.Point(6, 252);
            this.lbKontaktperson.Name = "lbKontaktperson";
            this.lbKontaktperson.Size = new System.Drawing.Size(99, 24);
            this.lbKontaktperson.TabIndex = 14;
            this.lbKontaktperson.Text = "Kontaktperson";
            this.lbKontaktperson.UseCompatibleTextRendering = true;
            // 
            // grdVermittlungSiEinsaetze
            // 
            this.grdVermittlungSiEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVermittlungSiEinsaetze.DataSource = this.qryBIBewerbung;
            // 
            // 
            // 
            this.grdVermittlungSiEinsaetze.EmbeddedNavigator.Name = "";
            this.grdVermittlungSiEinsaetze.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVermittlungSiEinsaetze.Location = new System.Drawing.Point(0, 35);
            this.grdVermittlungSiEinsaetze.MainView = this.grvVermittlungSiEinsaetze;
            this.grdVermittlungSiEinsaetze.Name = "grdVermittlungSiEinsaetze";
            this.grdVermittlungSiEinsaetze.Size = new System.Drawing.Size(722, 161);
            this.grdVermittlungSiEinsaetze.TabIndex = 15;
            this.grdVermittlungSiEinsaetze.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVermittlungSiEinsaetze});
            // 
            // grvVermittlungSiEinsaetze
            // 
            this.grvVermittlungSiEinsaetze.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVermittlungSiEinsaetze.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.Empty.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.Empty.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.EvenRow.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlungSiEinsaetze.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVermittlungSiEinsaetze.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlungSiEinsaetze.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlungSiEinsaetze.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVermittlungSiEinsaetze.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVermittlungSiEinsaetze.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.GroupRow.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVermittlungSiEinsaetze.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVermittlungSiEinsaetze.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVermittlungSiEinsaetze.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVermittlungSiEinsaetze.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVermittlungSiEinsaetze.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVermittlungSiEinsaetze.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.OddRow.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVermittlungSiEinsaetze.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.Row.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.Appearance.Row.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungSiEinsaetze.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVermittlungSiEinsaetze.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVermittlungSiEinsaetze.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVermittlungSiEinsaetze.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVermittlungSiEinsaetze.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVorschlag,
            this.colEinsatzplatz,
            this.colBetrieb,
            this.colResultat,
            this.colEinsatzVon,
            this.colEinsatzBis,
            this.colPensum,
            this.colAbschlussgrund});
            this.grvVermittlungSiEinsaetze.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVermittlungSiEinsaetze.GridControl = this.grdVermittlungSiEinsaetze;
            this.grvVermittlungSiEinsaetze.Name = "grvVermittlungSiEinsaetze";
            this.grvVermittlungSiEinsaetze.OptionsBehavior.Editable = false;
            this.grvVermittlungSiEinsaetze.OptionsCustomization.AllowFilter = false;
            this.grvVermittlungSiEinsaetze.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVermittlungSiEinsaetze.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVermittlungSiEinsaetze.OptionsNavigation.UseTabKey = false;
            this.grvVermittlungSiEinsaetze.OptionsView.ColumnAutoWidth = false;
            this.grvVermittlungSiEinsaetze.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVermittlungSiEinsaetze.OptionsView.ShowGroupPanel = false;
            this.grvVermittlungSiEinsaetze.OptionsView.ShowIndicator = false;
            // 
            // colVorschlag
            // 
            this.colVorschlag.Caption = "Vorschlag";
            this.colVorschlag.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colVorschlag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVorschlag.FieldName = "Vorschlag";
            this.colVorschlag.Name = "colVorschlag";
            this.colVorschlag.Visible = true;
            this.colVorschlag.VisibleIndex = 0;
            // 
            // colEinsatzplatz
            // 
            this.colEinsatzplatz.Caption = "Bezeichnung";
            this.colEinsatzplatz.FieldName = "Einsatzplatz";
            this.colEinsatzplatz.Name = "colEinsatzplatz";
            this.colEinsatzplatz.Visible = true;
            this.colEinsatzplatz.VisibleIndex = 1;
            this.colEinsatzplatz.Width = 99;
            // 
            // colBetrieb
            // 
            this.colBetrieb.Caption = "Betrieb";
            this.colBetrieb.FieldName = "Betrieb";
            this.colBetrieb.Name = "colBetrieb";
            this.colBetrieb.Visible = true;
            this.colBetrieb.VisibleIndex = 2;
            this.colBetrieb.Width = 103;
            // 
            // colResultat
            // 
            this.colResultat.Caption = "Resultat";
            this.colResultat.FieldName = "VorschlagResultat";
            this.colResultat.Name = "colResultat";
            this.colResultat.Visible = true;
            this.colResultat.VisibleIndex = 3;
            this.colResultat.Width = 78;
            // 
            // colEinsatzVon
            // 
            this.colEinsatzVon.Caption = "Stelle von";
            this.colEinsatzVon.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colEinsatzVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEinsatzVon.FieldName = "EinsatzVon";
            this.colEinsatzVon.Name = "colEinsatzVon";
            this.colEinsatzVon.Visible = true;
            this.colEinsatzVon.VisibleIndex = 4;
            this.colEinsatzVon.Width = 82;
            // 
            // colEinsatzBis
            // 
            this.colEinsatzBis.Caption = "bis";
            this.colEinsatzBis.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colEinsatzBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEinsatzBis.FieldName = "EinsatzBis";
            this.colEinsatzBis.Name = "colEinsatzBis";
            this.colEinsatzBis.Visible = true;
            this.colEinsatzBis.VisibleIndex = 5;
            // 
            // colPensum
            // 
            this.colPensum.Caption = "Pensum";
            this.colPensum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPensum.FieldName = "Arbeitspensum";
            this.colPensum.Name = "colPensum";
            this.colPensum.Visible = true;
            this.colPensum.VisibleIndex = 6;
            this.colPensum.Width = 56;
            // 
            // colAbschlussgrund
            // 
            this.colAbschlussgrund.Caption = "Abschlussgrund";
            this.colAbschlussgrund.FieldName = "BIAbschlussGrundCode";
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            this.colAbschlussgrund.Visible = true;
            this.colAbschlussgrund.VisibleIndex = 7;
            this.colAbschlussgrund.Width = 116;
            // 
            // btnDetailsEinsatzplatz
            // 
            this.btnDetailsEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetailsEinsatzplatz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailsEinsatzplatz.Location = new System.Drawing.Point(595, 202);
            this.btnDetailsEinsatzplatz.Name = "btnDetailsEinsatzplatz";
            this.btnDetailsEinsatzplatz.Size = new System.Drawing.Size(124, 24);
            this.btnDetailsEinsatzplatz.TabIndex = 16;
            this.btnDetailsEinsatzplatz.Text = "Details Einsatzplatz";
            this.btnDetailsEinsatzplatz.UseCompatibleTextRendering = true;
            this.btnDetailsEinsatzplatz.UseVisualStyleBackColor = false;
            this.btnDetailsEinsatzplatz.Click += new System.EventHandler(this.btnDetailsEinsatzplatz_Click);
            // 
            // edtEinsatzplatz
            // 
            this.edtEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinsatzplatz.DataMember = "Einsatzplatz";
            this.edtEinsatzplatz.DataSource = this.qryBIBewerbung;
            this.edtEinsatzplatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatz.Location = new System.Drawing.Point(111, 202);
            this.edtEinsatzplatz.Name = "edtEinsatzplatz";
            this.edtEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatz.Properties.ReadOnly = true;
            this.edtEinsatzplatz.Size = new System.Drawing.Size(367, 24);
            this.edtEinsatzplatz.TabIndex = 17;
            // 
            // edtBetrieb
            // 
            this.edtBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrieb.DataMember = "Betrieb";
            this.edtBetrieb.DataSource = this.qryBIBewerbung;
            this.edtBetrieb.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrieb.Location = new System.Drawing.Point(111, 227);
            this.edtBetrieb.Name = "edtBetrieb";
            this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrieb.Properties.ReadOnly = true;
            this.edtBetrieb.Size = new System.Drawing.Size(475, 24);
            this.edtBetrieb.TabIndex = 18;
            // 
            // edtKontaktperson
            // 
            this.edtKontaktperson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktperson.DataMember = "Kontaktperson";
            this.edtKontaktperson.DataSource = this.qryBIBewerbung;
            this.edtKontaktperson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontaktperson.Location = new System.Drawing.Point(111, 252);
            this.edtKontaktperson.Name = "edtKontaktperson";
            this.edtKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktperson.Properties.ReadOnly = true;
            this.edtKontaktperson.Size = new System.Drawing.Size(475, 24);
            this.edtKontaktperson.TabIndex = 19;
            // 
            // edtVerantwortlicherEinsatzplatz
            // 
            this.edtVerantwortlicherEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerantwortlicherEinsatzplatz.DataMember = "VerantwEP";
            this.edtVerantwortlicherEinsatzplatz.DataSource = this.qryBIBewerbung;
            this.edtVerantwortlicherEinsatzplatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerantwortlicherEinsatzplatz.Location = new System.Drawing.Point(111, 277);
            this.edtVerantwortlicherEinsatzplatz.Name = "edtVerantwortlicherEinsatzplatz";
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtVerantwortlicherEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerantwortlicherEinsatzplatz.Properties.ReadOnly = true;
            this.edtVerantwortlicherEinsatzplatz.Size = new System.Drawing.Size(475, 24);
            this.edtVerantwortlicherEinsatzplatz.TabIndex = 20;
            // 
            // lblVerantwortlicherEinsatzplatz
            // 
            this.lblVerantwortlicherEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerantwortlicherEinsatzplatz.Location = new System.Drawing.Point(6, 276);
            this.lblVerantwortlicherEinsatzplatz.Name = "lblVerantwortlicherEinsatzplatz";
            this.lblVerantwortlicherEinsatzplatz.Size = new System.Drawing.Size(100, 24);
            this.lblVerantwortlicherEinsatzplatz.TabIndex = 21;
            this.lblVerantwortlicherEinsatzplatz.Text = "Verantw. Einsatzpl.";
            this.lblVerantwortlicherEinsatzplatz.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzplatzNr
            // 
            this.lblEinsatzplatzNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinsatzplatzNr.Location = new System.Drawing.Point(484, 202);
            this.lblEinsatzplatzNr.Name = "lblEinsatzplatzNr";
            this.lblEinsatzplatzNr.Size = new System.Drawing.Size(22, 24);
            this.lblEinsatzplatzNr.TabIndex = 23;
            this.lblEinsatzplatzNr.Text = "Nr.";
            this.lblEinsatzplatzNr.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzplatzNr
            // 
            this.edtEinsatzplatzNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinsatzplatzNr.DataMember = "KaEinsatzplatzID";
            this.edtEinsatzplatzNr.DataSource = this.qryBIBewerbung;
            this.edtEinsatzplatzNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatzNr.Location = new System.Drawing.Point(512, 202);
            this.edtEinsatzplatzNr.Name = "edtEinsatzplatzNr";
            this.edtEinsatzplatzNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinsatzplatzNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatzNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatzNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatzNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatzNr.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatzNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatzNr.Properties.ReadOnly = true;
            this.edtEinsatzplatzNr.Size = new System.Drawing.Size(74, 24);
            this.edtEinsatzplatzNr.TabIndex = 22;
            // 
            // CtlKaVermittlungBIBIPStellenBI
            // 
            this.ActiveSQLQuery = this.qryBIBewerbung;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(722, 550);
            this.Controls.Add(this.lblEinsatzplatzNr);
            this.Controls.Add(this.edtEinsatzplatzNr);
            this.Controls.Add(this.lblVerantwortlicherEinsatzplatz);
            this.Controls.Add(this.edtVerantwortlicherEinsatzplatz);
            this.Controls.Add(this.edtKontaktperson);
            this.Controls.Add(this.edtBetrieb);
            this.Controls.Add(this.edtEinsatzplatz);
            this.Controls.Add(this.btnDetailsEinsatzplatz);
            this.Controls.Add(this.grdVermittlungSiEinsaetze);
            this.Controls.Add(this.lbKontaktperson);
            this.Controls.Add(this.lblBetrieb);
            this.Controls.Add(this.lblEinsatzplatz);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.tabEinsaetze);
            this.Name = "CtlKaVermittlungBIBIPStellenBI";
            this.Size = new System.Drawing.Size(722, 557);
            this.Load += new System.EventHandler(this.CtlKaVermittlungBIBIPStellenBI_Load);
            this.tabEinsaetze.ResumeLayout(false);
            this.tpgEAZ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblEAZBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIStelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzentEAZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeteiligungEAZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierungsgrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBruttolohn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZVerlaengert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeteiligungEAZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzierungsgrad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBruttolohn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZUnterschrieben.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzvereinbarungDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarungEAZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEAZDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEAZBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEAZVon)).EndInit();
            this.tpgStelle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVerlaengert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnbefristet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStelleBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzende)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitspensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStelleab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzende.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzendeDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzAb.Properties)).EndInit();
            this.tpgBewerbung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAblehnungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIBewerbung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultatDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagDatum.Properties)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVermittlungSiEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlungSiEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlicherEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerantwortlicherEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNr.Properties)).EndInit();
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

        private void CtlKaVermittlungBIBIPStellenBI_Load(object sender, EventArgs e)
        {
        }

        private void btnDetailsEinsatzplatz_Click(object sender, System.EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", qryBIBewerbung["KaEinsatzplatzID"]);
        }

        private void qryBIBewerbung_AfterFill(object sender, System.EventArgs e)
        {
            qryBIBewerbung_PositionChanged(sender, null);
        }

        private void qryBIBewerbung_AfterPost(object sender, System.EventArgs e)
        {
            if (!qryBIStelle.Post())
                throw new KissCancelException();
        }

        private void qryBIBewerbung_BeforeDelete(object sender, System.EventArgs e)
        {
            DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz WHERE KaVermittlungVorschlagID = {0}", qryBIBewerbung["KaVermittlungVorschlagID"]);
        }

        private void qryBIBewerbung_PositionChanged(object sender, System.EventArgs e)
        {
            if (qryBIBewerbung.Count == 0)
            {
                qryBIStelle.Fill(DBNull.Value);
            }
            else
            {
                qryBIStelle.Fill(qryBIBewerbung["KaVermittlungVorschlagID"]);
            }
        }

        private void qryBIStelle_BeforePost(object sender, System.EventArgs e)
        {
            qryBIBewerbung["Arbeitspensum"] = edtPensum.EditValue;

            qryBIBewerbung["BIAbschlussGrundCode"] = edtAbschlussGrund.EditValue;

            qryBIBewerbung["EinsatzBis"] = edtEinsatzBis.EditValue;

            qryBIBewerbung["EinsatzVon"] = edtEinsatzAb.EditValue;
        }

        private void qryBIStelle_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryBIBewerbung.RowModified = true;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return faLeistungID;
                case "BAPERSONID":
                    return (int)DBUtil.ExecuteScalarSQL("select BaPersonID from FaLeistung where FaLeistungID = {0}", faLeistungID);
                case "KAVERMITTLUNGVORSCHLAGID":
                    return qryBIBewerbung["KaVermittlungVorschlagID"];
                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", faLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            this.faLeistungID = FaLeistungID;
            this.baPersonID = BaPersonID;

            tabEinsaetze.SelectedTabIndex = 0;
            qryBIBewerbung.Fill(faLeistungID, Session.User.IsUserKA ? 0 : 1);

            DBUtil.GetFallRights(this.faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);
            qryBIStelle.CanUpdate = qryBIBewerbung.CanUpdate && DBUtil.UserHasRight("CtlKaVermittlungBIBIPStellenBI", "U") && MayUpd;
            qryBIStelle.CanInsert = qryBIBewerbung.CanInsert && DBUtil.UserHasRight("CtlKaVermittlungBIBIPStellenBI", "I") && MayIns;
            qryBIStelle.CanDelete = qryBIBewerbung.CanDelete && DBUtil.UserHasRight("CtlKaVermittlungBIBIPStellenBI", "D") && MayDel;
            qryBIStelle.EnableBoundFields();

            btnDetailsEinsatzplatz.Enabled = !qryBIBewerbung.IsEmpty &&
                                             ((DBUtil.UserHasRight("CtlKaVermittlungBIBIPStellenBI", "U") && MayUpd) ||
                                              (DBUtil.UserHasRight("CtlKaVermittlungBIBIPStellenBI", "I") && MayIns) ||
                                              (DBUtil.UserHasRight("CtlKaVermittlungBIBIPStellenBI", "D") && MayDel));

            this.colResultat.ColumnEdit = this.grdVermittlungSiEinsaetze.GetLOVLookUpEdit("KaVorschlagResultat");
            this.colAbschlussgrund.ColumnEdit = this.grdVermittlungSiEinsaetze.GetLOVLookUpEdit("KaVermittlungBIStellenendeGrund");
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
                case "SelectRow":
                    if (!param.Contains("KaVermittlungVorschlagID")) param["KaVermittlungVorschlagID"] = -1;

                    tabEinsaetze.SelectedTabIndex = 0;
                    qryBIBewerbung.Find(string.Format("KaVermittlungVorschlagID = {0}", param["KaVermittlungVorschlagID"]));

                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Private Methods

        private bool CheckDate(KiSS4.Gui.KissDateEdit dateFrom, KiSS4.Gui.KissDateEdit dateTo)
        {
            bool rslt = true;

            if (DBUtil.IsEmpty(dateFrom.EditValue) || DBUtil.IsEmpty(dateTo.EditValue))
            {
                rslt = true;
            }
            else
            {
                if (Convert.ToDateTime(dateFrom.EditValue) > Convert.ToDateTime(dateTo.EditValue))
                    rslt = false;
            }

            return rslt;
        }

        private void checkPensum(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtPensum.EditValue))
            {
                if (Convert.ToInt32(edtPensum.EditValue) > 100)
                {
                    KissMsg.ShowInfo("CtlKaVermittlungBIBIPStellenBI", "PensumZuGross", "Pensum darf nicht höher sein als 100%!");
                    ((KiSS4.Gui.KissCalcEdit)sender).Focus();
                }
            }
        }

        private void datLeaveEAZDatum(object sender, System.EventArgs e)
        {
            if (!CheckDate(edtEAZDatumVon, edtEAZDatumBis))
            {
                KissMsg.ShowInfo("CtlKaVermittlungBIBIPStellenBI", "EAZDatumVonVorBis", "'bis' darf nicht vor 'EAZ von' liegen!");
                ((KiSS4.Gui.KissDateEdit)sender).Focus();
            }
        }

        private void datLeaveEinsatz(object sender, System.EventArgs e)
        {
            if (!CheckDate(edtEinsatzAb, edtEinsatzBis))
            {
                KissMsg.ShowInfo("CtlKaVermittlungBIBIPStellenBI", "StelleAbVorBis", "'bis' darf nicht vor 'Stelle ab' liegen!");
                ((KiSS4.Gui.KissDateEdit)sender).Focus();
            }
        }

        #endregion

        #endregion
    }
}