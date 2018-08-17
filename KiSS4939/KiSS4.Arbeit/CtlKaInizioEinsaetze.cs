using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaInizioEinsaetze : KiSS4.Gui.KissUserControl
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
        private DevExpress.XtraGrid.Columns.GridColumn colAbbruchDurch;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbildungsbeginn;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colResultat;
        private DevExpress.XtraGrid.Columns.GridColumn colSchnuppernAb;
        private DevExpress.XtraGrid.Columns.GridColumn colVorstellungsgespraech;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtAbbruchDurch;
        private KiSS4.Gui.KissDateEdit edtAbschlussDatum;
        private KiSS4.Gui.KissTextEdit edtAbschlussGrund;
        private KiSS4.Gui.KissLookUpEdit edtAnschlussloesung;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissTextEdit edtBetrieb;
        private KiSS4.Gui.KissDateEdit edtDossierGesendet;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatz;
        private KiSS4.Gui.KissTextEdit edtKontaktperson;
        private KiSS4.Gui.KissTextEdit edtLehrberuf;
        private KiSS4.Gui.KissDateEdit edtLehreBis;
        private KiSS4.Gui.KissDateEdit edtLehreVon;
        private KiSS4.Gui.KissDateEdit edtLehrvertragDatum;
        private KiSS4.Gui.KissTextEdit edtLoesung;
        private KiSS4.Gui.KissLookUpEdit edtResultat;
        private KiSS4.Gui.KissDateEdit edtResultatDatum;
        private KiSS4.Gui.KissDateEdit edtSchnuppernBis;
        private KiSS4.Gui.KissDateEdit edtSchnuppernVon;
        private KiSS4.Gui.KissDateEdit edtVorstellungsgespraech;
        private int faLeistungID = -1;
        private KiSS4.Gui.KissGrid grdInizioEinsaetze;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinsaetze;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lblAbbruchDurch;
        private KiSS4.Gui.KissLabel lblAbschluss;
        private KiSS4.Gui.KissLabel lblAbschlussGrund;
        private KiSS4.Gui.KissLabel lblAbschlussLehre;
        private KiSS4.Gui.KissLabel lblAnschlussloesung;
        private KiSS4.Gui.KissLabel lblAusbildungsbeginn;
        private KiSS4.Gui.KissLabel lblAusbildungsende;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissLabel lblDossierGesendet;
        private KiSS4.Gui.KissLabel lblEinsatzplatzBezeichnung;
        private KiSS4.Gui.KissLabel lblKontaktPerson;
        private KiSS4.Gui.KissLabel lblLehrberuf;
        private KiSS4.Gui.KissLabel lblLehrvertrag;
        private KiSS4.Gui.KissLabel lblLehrvertragDatum;
        private KiSS4.Gui.KissLabel lblLoesung;
        private KiSS4.Gui.KissLabel lblResultat;
        private KiSS4.Gui.KissLabel lblSchnuppernBis;
        private KiSS4.Gui.KissLabel lblSchnuppernVon;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblVorstellungsgespraech;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryInizioLehre;
        private KiSS4.DB.SqlQuery qryInizioVorschlag;
        private KiSS4.Gui.KissTabControlEx tabInizioEinsaetze;
        private SharpLibrary.WinControls.TabPageEx tpgLehre;
        private SharpLibrary.WinControls.TabPageEx tpgVorschlag;

        #endregion

        #endregion

        #region Constructors

        public CtlKaInizioEinsaetze()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaInizioEinsaetze));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnDetailsEinsatzplatz = new KiSS4.Gui.KissButton();
            this.tabInizioEinsaetze = new KiSS4.Gui.KissTabControlEx();
            this.tpgLehre = new SharpLibrary.WinControls.TabPageEx();
            this.lblLehrvertrag = new KiSS4.Gui.KissLabel();
            this.lblAbschlussLehre = new KiSS4.Gui.KissLabel();
            this.lblAusbildungsende = new KiSS4.Gui.KissLabel();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblAnschlussloesung = new KiSS4.Gui.KissLabel();
            this.lblLoesung = new KiSS4.Gui.KissLabel();
            this.lblAbschlussGrund = new KiSS4.Gui.KissLabel();
            this.lblAbbruchDurch = new KiSS4.Gui.KissLabel();
            this.lblAusbildungsbeginn = new KiSS4.Gui.KissLabel();
            this.lblLehrvertragDatum = new KiSS4.Gui.KissLabel();
            this.edtAnschlussloesung = new KiSS4.Gui.KissLookUpEdit();
            this.qryInizioLehre = new KiSS4.DB.SqlQuery(this.components);
            this.edtLoesung = new KiSS4.Gui.KissTextEdit();
            this.edtAbschlussGrund = new KiSS4.Gui.KissTextEdit();
            this.edtAbschlussDatum = new KiSS4.Gui.KissDateEdit();
            this.edtAbbruchDurch = new KiSS4.Gui.KissLookUpEdit();
            this.edtLehreBis = new KiSS4.Gui.KissDateEdit();
            this.edtLehreVon = new KiSS4.Gui.KissDateEdit();
            this.edtLehrvertragDatum = new KiSS4.Gui.KissDateEdit();
            this.tpgVorschlag = new SharpLibrary.WinControls.TabPageEx();
            this.lblSchnuppernBis = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.lblResultat = new KiSS4.Gui.KissLabel();
            this.lblSchnuppernVon = new KiSS4.Gui.KissLabel();
            this.lblVorstellungsgespraech = new KiSS4.Gui.KissLabel();
            this.lblDossierGesendet = new KiSS4.Gui.KissLabel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.qryInizioVorschlag = new KiSS4.DB.SqlQuery(this.components);
            this.edtResultat = new KiSS4.Gui.KissLookUpEdit();
            this.edtResultatDatum = new KiSS4.Gui.KissDateEdit();
            this.edtSchnuppernBis = new KiSS4.Gui.KissDateEdit();
            this.edtSchnuppernVon = new KiSS4.Gui.KissDateEdit();
            this.edtVorstellungsgespraech = new KiSS4.Gui.KissDateEdit();
            this.edtDossierGesendet = new KiSS4.Gui.KissDateEdit();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.grdInizioEinsaetze = new KiSS4.Gui.KissGrid();
            this.grvEinsaetze = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorstellungsgespraech = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchnuppernAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbildungsbeginn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbbruchDurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblEinsatzplatzBezeichnung = new KiSS4.Gui.KissLabel();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.lblKontaktPerson = new KiSS4.Gui.KissLabel();
            this.edtEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.edtBetrieb = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktperson = new KiSS4.Gui.KissTextEdit();
            this.lblLehrberuf = new KiSS4.Gui.KissLabel();
            this.edtLehrberuf = new KiSS4.Gui.KissTextEdit();
            this.tabInizioEinsaetze.SuspendLayout();
            this.tpgLehre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrvertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussLehre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildungsende)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnschlussloesung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLoesung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbbruchDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildungsbeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrvertragDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschlussloesung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschlussloesung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioLehre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLoesung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbbruchDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbbruchDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehreBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehreVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrvertragDatum.Properties)).BeginInit();
            this.tpgVorschlag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchnuppernBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchnuppernVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorstellungsgespraech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDossierGesendet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioVorschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchnuppernBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchnuppernVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorstellungsgespraech.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDossierGesendet.Properties)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInizioEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetailsEinsatzplatz
            // 
            this.btnDetailsEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetailsEinsatzplatz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailsEinsatzplatz.Location = new System.Drawing.Point(607, 166);
            this.btnDetailsEinsatzplatz.Name = "btnDetailsEinsatzplatz";
            this.btnDetailsEinsatzplatz.Size = new System.Drawing.Size(125, 24);
            this.btnDetailsEinsatzplatz.TabIndex = 0;
            this.btnDetailsEinsatzplatz.Text = "Info Einsatzplatz";
            this.btnDetailsEinsatzplatz.UseCompatibleTextRendering = true;
            this.btnDetailsEinsatzplatz.UseVisualStyleBackColor = false;
            this.btnDetailsEinsatzplatz.Click += new System.EventHandler(this.btnDetailsEinsatzplatz_Click);
            // 
            // tabInizioEinsaetze
            // 
            this.tabInizioEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabInizioEinsaetze.Controls.Add(this.tpgLehre);
            this.tabInizioEinsaetze.Controls.Add(this.tpgVorschlag);
            this.tabInizioEinsaetze.Location = new System.Drawing.Point(3, 265);
            this.tabInizioEinsaetze.Name = "tabInizioEinsaetze";
            this.tabInizioEinsaetze.ShowFixedWidthTooltip = true;
            this.tabInizioEinsaetze.Size = new System.Drawing.Size(650, 290);
            this.tabInizioEinsaetze.TabIndex = 0;
            this.tabInizioEinsaetze.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgVorschlag,
            this.tpgLehre});
            this.tabInizioEinsaetze.TabsLineColor = System.Drawing.Color.Black;
            this.tabInizioEinsaetze.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabInizioEinsaetze.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabInizioEinsaetze.Text = "kissTabControlEx1";
            // 
            // tpgLehre
            // 
            this.tpgLehre.Controls.Add(this.lblLehrvertrag);
            this.tpgLehre.Controls.Add(this.lblAbschlussLehre);
            this.tpgLehre.Controls.Add(this.lblAusbildungsende);
            this.tpgLehre.Controls.Add(this.lblAbschluss);
            this.tpgLehre.Controls.Add(this.lblAnschlussloesung);
            this.tpgLehre.Controls.Add(this.lblLoesung);
            this.tpgLehre.Controls.Add(this.lblAbschlussGrund);
            this.tpgLehre.Controls.Add(this.lblAbbruchDurch);
            this.tpgLehre.Controls.Add(this.lblAusbildungsbeginn);
            this.tpgLehre.Controls.Add(this.lblLehrvertragDatum);
            this.tpgLehre.Controls.Add(this.edtAnschlussloesung);
            this.tpgLehre.Controls.Add(this.edtLoesung);
            this.tpgLehre.Controls.Add(this.edtAbschlussGrund);
            this.tpgLehre.Controls.Add(this.edtAbschlussDatum);
            this.tpgLehre.Controls.Add(this.edtAbbruchDurch);
            this.tpgLehre.Controls.Add(this.edtLehreBis);
            this.tpgLehre.Controls.Add(this.edtLehreVon);
            this.tpgLehre.Controls.Add(this.edtLehrvertragDatum);
            this.tpgLehre.Location = new System.Drawing.Point(6, 32);
            this.tpgLehre.Name = "tpgLehre";
            this.tpgLehre.Size = new System.Drawing.Size(638, 252);
            this.tpgLehre.TabIndex = 1;
            this.tpgLehre.Title = "Lehre";
            // 
            // lblLehrvertrag
            // 
            this.lblLehrvertrag.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblLehrvertrag.Location = new System.Drawing.Point(2, 1);
            this.lblLehrvertrag.Name = "lblLehrvertrag";
            this.lblLehrvertrag.Size = new System.Drawing.Size(100, 16);
            this.lblLehrvertrag.TabIndex = 31;
            this.lblLehrvertrag.Text = "Lehrvertrag";
            this.lblLehrvertrag.UseCompatibleTextRendering = true;
            // 
            // lblAbschlussLehre
            // 
            this.lblAbschlussLehre.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblAbschlussLehre.Location = new System.Drawing.Point(2, 86);
            this.lblAbschlussLehre.Name = "lblAbschlussLehre";
            this.lblAbschlussLehre.Size = new System.Drawing.Size(100, 16);
            this.lblAbschlussLehre.TabIndex = 30;
            this.lblAbschlussLehre.Text = "Abschluss";
            this.lblAbschlussLehre.UseCompatibleTextRendering = true;
            // 
            // lblAusbildungsende
            // 
            this.lblAusbildungsende.Location = new System.Drawing.Point(219, 50);
            this.lblAusbildungsende.Name = "lblAusbildungsende";
            this.lblAusbildungsende.Size = new System.Drawing.Size(24, 24);
            this.lblAusbildungsende.TabIndex = 28;
            this.lblAusbildungsende.Text = "bis";
            this.lblAusbildungsende.UseCompatibleTextRendering = true;
            // 
            // lblAbschluss
            // 
            this.lblAbschluss.Location = new System.Drawing.Point(2, 138);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(93, 24);
            this.lblAbschluss.TabIndex = 26;
            this.lblAbschluss.Text = "Abschluss";
            this.lblAbschluss.UseCompatibleTextRendering = true;
            // 
            // lblAnschlussloesung
            // 
            this.lblAnschlussloesung.Location = new System.Drawing.Point(2, 228);
            this.lblAnschlussloesung.Name = "lblAnschlussloesung";
            this.lblAnschlussloesung.Size = new System.Drawing.Size(93, 24);
            this.lblAnschlussloesung.TabIndex = 22;
            this.lblAnschlussloesung.Text = "Anschlusslösung";
            this.lblAnschlussloesung.UseCompatibleTextRendering = true;
            // 
            // lblLoesung
            // 
            this.lblLoesung.Location = new System.Drawing.Point(2, 198);
            this.lblLoesung.Name = "lblLoesung";
            this.lblLoesung.Size = new System.Drawing.Size(93, 24);
            this.lblLoesung.TabIndex = 20;
            this.lblLoesung.Text = "Lösung";
            this.lblLoesung.UseCompatibleTextRendering = true;
            // 
            // lblAbschlussGrund
            // 
            this.lblAbschlussGrund.Location = new System.Drawing.Point(2, 168);
            this.lblAbschlussGrund.Name = "lblAbschlussGrund";
            this.lblAbschlussGrund.Size = new System.Drawing.Size(93, 24);
            this.lblAbschlussGrund.TabIndex = 19;
            this.lblAbschlussGrund.Text = "Grund";
            this.lblAbschlussGrund.UseCompatibleTextRendering = true;
            // 
            // lblAbbruchDurch
            // 
            this.lblAbbruchDurch.Location = new System.Drawing.Point(2, 109);
            this.lblAbbruchDurch.Name = "lblAbbruchDurch";
            this.lblAbbruchDurch.Size = new System.Drawing.Size(93, 24);
            this.lblAbbruchDurch.TabIndex = 18;
            this.lblAbbruchDurch.Text = "Abbruch durch";
            this.lblAbbruchDurch.UseCompatibleTextRendering = true;
            // 
            // lblAusbildungsbeginn
            // 
            this.lblAusbildungsbeginn.Location = new System.Drawing.Point(2, 50);
            this.lblAusbildungsbeginn.Name = "lblAusbildungsbeginn";
            this.lblAusbildungsbeginn.Size = new System.Drawing.Size(93, 24);
            this.lblAusbildungsbeginn.TabIndex = 16;
            this.lblAusbildungsbeginn.Text = "Ausbildung von";
            this.lblAusbildungsbeginn.UseCompatibleTextRendering = true;
            // 
            // lblLehrvertragDatum
            // 
            this.lblLehrvertragDatum.Location = new System.Drawing.Point(2, 21);
            this.lblLehrvertragDatum.Name = "lblLehrvertragDatum";
            this.lblLehrvertragDatum.Size = new System.Drawing.Size(93, 24);
            this.lblLehrvertragDatum.TabIndex = 8;
            this.lblLehrvertragDatum.Text = "Lehrvertrag";
            this.lblLehrvertragDatum.UseCompatibleTextRendering = true;
            // 
            // edtAnschlussloesung
            // 
            this.edtAnschlussloesung.DataMember = "InizioAnschlussloesungCode";
            this.edtAnschlussloesung.DataSource = this.qryInizioLehre;
            this.edtAnschlussloesung.Location = new System.Drawing.Point(112, 228);
            this.edtAnschlussloesung.LOVName = "KaInizioAnschlussLoesung";
            this.edtAnschlussloesung.Name = "edtAnschlussloesung";
            this.edtAnschlussloesung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnschlussloesung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnschlussloesung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnschlussloesung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnschlussloesung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnschlussloesung.Properties.Appearance.Options.UseFont = true;
            this.edtAnschlussloesung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAnschlussloesung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnschlussloesung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAnschlussloesung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAnschlussloesung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAnschlussloesung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAnschlussloesung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnschlussloesung.Properties.NullText = "";
            this.edtAnschlussloesung.Properties.ShowFooter = false;
            this.edtAnschlussloesung.Properties.ShowHeader = false;
            this.edtAnschlussloesung.Size = new System.Drawing.Size(250, 24);
            this.edtAnschlussloesung.TabIndex = 7;
            // 
            // qryInizioLehre
            // 
            this.qryInizioLehre.CanDelete = true;
            this.qryInizioLehre.CanUpdate = true;
            this.qryInizioLehre.HostControl = this;
            this.qryInizioLehre.IsIdentityInsert = false;
            this.qryInizioLehre.SelectStatement = "SELECT\tVEI.*\r\nFROM KaVermittlungEinsatz VEI\r\nWHERE VEI.KaVermittlungVorschlagID =" +
    " {0}";
            this.qryInizioLehre.TableName = "KaVermittlungEinsatz";
            this.qryInizioLehre.BeforePost += new System.EventHandler(this.qryInizioLehre_BeforePost);
            this.qryInizioLehre.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryInizioLehre_ColumnChanging);
            // 
            // edtLoesung
            // 
            this.edtLoesung.DataMember = "InizioLoesung";
            this.edtLoesung.DataSource = this.qryInizioLehre;
            this.edtLoesung.Location = new System.Drawing.Point(112, 198);
            this.edtLoesung.Name = "edtLoesung";
            this.edtLoesung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLoesung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLoesung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLoesung.Properties.Appearance.Options.UseBackColor = true;
            this.edtLoesung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLoesung.Properties.Appearance.Options.UseFont = true;
            this.edtLoesung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLoesung.Size = new System.Drawing.Size(400, 24);
            this.edtLoesung.TabIndex = 6;
            // 
            // edtAbschlussGrund
            // 
            this.edtAbschlussGrund.DataMember = "InizioAbschlussGrund";
            this.edtAbschlussGrund.DataSource = this.qryInizioLehre;
            this.edtAbschlussGrund.Location = new System.Drawing.Point(112, 168);
            this.edtAbschlussGrund.Name = "edtAbschlussGrund";
            this.edtAbschlussGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbschlussGrund.Size = new System.Drawing.Size(400, 24);
            this.edtAbschlussGrund.TabIndex = 5;
            // 
            // edtAbschlussDatum
            // 
            this.edtAbschlussDatum.DataMember = "Abschluss";
            this.edtAbschlussDatum.DataSource = this.qryInizioLehre;
            this.edtAbschlussDatum.EditValue = null;
            this.edtAbschlussDatum.Location = new System.Drawing.Point(112, 139);
            this.edtAbschlussDatum.Name = "edtAbschlussDatum";
            this.edtAbschlussDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAbschlussDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussDatum.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbschlussDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAbschlussDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbschlussDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussDatum.Properties.ShowToday = false;
            this.edtAbschlussDatum.Size = new System.Drawing.Size(94, 24);
            this.edtAbschlussDatum.TabIndex = 4;
            // 
            // edtAbbruchDurch
            // 
            this.edtAbbruchDurch.DataMember = "InizioEinsatzAbbruchDurchCode";
            this.edtAbbruchDurch.DataSource = this.qryInizioLehre;
            this.edtAbbruchDurch.Location = new System.Drawing.Point(112, 109);
            this.edtAbbruchDurch.LOVName = "KaInizioAbbruchDurch";
            this.edtAbbruchDurch.Name = "edtAbbruchDurch";
            this.edtAbbruchDurch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbbruchDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbbruchDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbbruchDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbbruchDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbbruchDurch.Properties.Appearance.Options.UseFont = true;
            this.edtAbbruchDurch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbbruchDurch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbbruchDurch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbbruchDurch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbbruchDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAbbruchDurch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAbbruchDurch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbbruchDurch.Properties.NullText = "";
            this.edtAbbruchDurch.Properties.ShowFooter = false;
            this.edtAbbruchDurch.Properties.ShowHeader = false;
            this.edtAbbruchDurch.Size = new System.Drawing.Size(238, 24);
            this.edtAbbruchDurch.TabIndex = 3;
            // 
            // edtLehreBis
            // 
            this.edtLehreBis.DataMember = "EinsatzBis";
            this.edtLehreBis.DataSource = this.qryInizioLehre;
            this.edtLehreBis.EditValue = null;
            this.edtLehreBis.Location = new System.Drawing.Point(252, 50);
            this.edtLehreBis.Name = "edtLehreBis";
            this.edtLehreBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLehreBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLehreBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLehreBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehreBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtLehreBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLehreBis.Properties.Appearance.Options.UseFont = true;
            this.edtLehreBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtLehreBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtLehreBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtLehreBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLehreBis.Properties.ShowToday = false;
            this.edtLehreBis.Size = new System.Drawing.Size(94, 24);
            this.edtLehreBis.TabIndex = 2;
            this.edtLehreBis.Leave += new System.EventHandler(this.datLeaveEinsatz);
            // 
            // edtLehreVon
            // 
            this.edtLehreVon.DataMember = "EinsatzVon";
            this.edtLehreVon.DataSource = this.qryInizioLehre;
            this.edtLehreVon.EditValue = null;
            this.edtLehreVon.Location = new System.Drawing.Point(112, 50);
            this.edtLehreVon.Name = "edtLehreVon";
            this.edtLehreVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLehreVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLehreVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLehreVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehreVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtLehreVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLehreVon.Properties.Appearance.Options.UseFont = true;
            this.edtLehreVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtLehreVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtLehreVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtLehreVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLehreVon.Properties.ShowToday = false;
            this.edtLehreVon.Size = new System.Drawing.Size(94, 24);
            this.edtLehreVon.TabIndex = 1;
            this.edtLehreVon.Leave += new System.EventHandler(this.datLeaveEinsatz);
            // 
            // edtLehrvertragDatum
            // 
            this.edtLehrvertragDatum.DataMember = "Lehrvertrag";
            this.edtLehrvertragDatum.DataSource = this.qryInizioLehre;
            this.edtLehrvertragDatum.EditValue = null;
            this.edtLehrvertragDatum.Location = new System.Drawing.Point(112, 21);
            this.edtLehrvertragDatum.Name = "edtLehrvertragDatum";
            this.edtLehrvertragDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLehrvertragDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLehrvertragDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLehrvertragDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehrvertragDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtLehrvertragDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLehrvertragDatum.Properties.Appearance.Options.UseFont = true;
            this.edtLehrvertragDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtLehrvertragDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtLehrvertragDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtLehrvertragDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLehrvertragDatum.Properties.ShowToday = false;
            this.edtLehrvertragDatum.Size = new System.Drawing.Size(94, 24);
            this.edtLehrvertragDatum.TabIndex = 0;
            // 
            // tpgVorschlag
            // 
            this.tpgVorschlag.Controls.Add(this.lblSchnuppernBis);
            this.tpgVorschlag.Controls.Add(this.lblBemerkungen);
            this.tpgVorschlag.Controls.Add(this.lblResultat);
            this.tpgVorschlag.Controls.Add(this.lblSchnuppernVon);
            this.tpgVorschlag.Controls.Add(this.lblVorstellungsgespraech);
            this.tpgVorschlag.Controls.Add(this.lblDossierGesendet);
            this.tpgVorschlag.Controls.Add(this.edtBemerkungen);
            this.tpgVorschlag.Controls.Add(this.edtResultat);
            this.tpgVorschlag.Controls.Add(this.edtResultatDatum);
            this.tpgVorschlag.Controls.Add(this.edtSchnuppernBis);
            this.tpgVorschlag.Controls.Add(this.edtSchnuppernVon);
            this.tpgVorschlag.Controls.Add(this.edtVorstellungsgespraech);
            this.tpgVorschlag.Controls.Add(this.edtDossierGesendet);
            this.tpgVorschlag.Location = new System.Drawing.Point(6, 32);
            this.tpgVorschlag.Name = "tpgVorschlag";
            this.tpgVorschlag.Size = new System.Drawing.Size(638, 252);
            this.tpgVorschlag.TabIndex = 0;
            this.tpgVorschlag.Title = "Vorschlag";
            // 
            // lblSchnuppernBis
            // 
            this.lblSchnuppernBis.Location = new System.Drawing.Point(225, 69);
            this.lblSchnuppernBis.Name = "lblSchnuppernBis";
            this.lblSchnuppernBis.Size = new System.Drawing.Size(18, 24);
            this.lblSchnuppernBis.TabIndex = 14;
            this.lblSchnuppernBis.Text = "bis";
            this.lblSchnuppernBis.UseCompatibleTextRendering = true;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(3, 126);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(111, 24);
            this.lblBemerkungen.TabIndex = 13;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // lblResultat
            // 
            this.lblResultat.Location = new System.Drawing.Point(3, 99);
            this.lblResultat.Name = "lblResultat";
            this.lblResultat.Size = new System.Drawing.Size(111, 24);
            this.lblResultat.TabIndex = 12;
            this.lblResultat.Text = "Resultat";
            this.lblResultat.UseCompatibleTextRendering = true;
            // 
            // lblSchnuppernVon
            // 
            this.lblSchnuppernVon.Location = new System.Drawing.Point(3, 69);
            this.lblSchnuppernVon.Name = "lblSchnuppernVon";
            this.lblSchnuppernVon.Size = new System.Drawing.Size(111, 24);
            this.lblSchnuppernVon.TabIndex = 11;
            this.lblSchnuppernVon.Text = "Schnuppen von";
            this.lblSchnuppernVon.UseCompatibleTextRendering = true;
            // 
            // lblVorstellungsgespraech
            // 
            this.lblVorstellungsgespraech.Location = new System.Drawing.Point(3, 39);
            this.lblVorstellungsgespraech.Name = "lblVorstellungsgespraech";
            this.lblVorstellungsgespraech.Size = new System.Drawing.Size(111, 24);
            this.lblVorstellungsgespraech.TabIndex = 10;
            this.lblVorstellungsgespraech.Text = "Vostellungsgespräch";
            this.lblVorstellungsgespraech.UseCompatibleTextRendering = true;
            // 
            // lblDossierGesendet
            // 
            this.lblDossierGesendet.Location = new System.Drawing.Point(3, 9);
            this.lblDossierGesendet.Name = "lblDossierGesendet";
            this.lblDossierGesendet.Size = new System.Drawing.Size(111, 24);
            this.lblDossierGesendet.TabIndex = 9;
            this.lblDossierGesendet.Text = "Dossier Gesendet";
            this.lblDossierGesendet.UseCompatibleTextRendering = true;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.DataMember = "VorschlagBemerkungen";
            this.edtBemerkungen.DataSource = this.qryInizioVorschlag;
            this.edtBemerkungen.Location = new System.Drawing.Point(119, 131);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(515, 86);
            this.edtBemerkungen.TabIndex = 7;
            // 
            // qryInizioVorschlag
            // 
            this.qryInizioVorschlag.CanDelete = true;
            this.qryInizioVorschlag.CanUpdate = true;
            this.qryInizioVorschlag.HostControl = this;
            this.qryInizioVorschlag.IsIdentityInsert = false;
            this.qryInizioVorschlag.SelectStatement = resources.GetString("qryInizioVorschlag.SelectStatement");
            this.qryInizioVorschlag.TableName = "KaVermittlungVorschlag";
            this.qryInizioVorschlag.AfterFill += new System.EventHandler(this.qryInizioVorschlag_AfterFill);
            this.qryInizioVorschlag.AfterPost += new System.EventHandler(this.qryInizioVorschlag_AfterPost);
            this.qryInizioVorschlag.BeforeDelete += new System.EventHandler(this.qryInizioVorschlag_BeforeDelete);
            this.qryInizioVorschlag.BeforePost += new System.EventHandler(this.qryInizioVorschlag_BeforePost);
            this.qryInizioVorschlag.PositionChanged += new System.EventHandler(this.qryInizioVorschlag_PositionChanged);
            // 
            // edtResultat
            // 
            this.edtResultat.DataMember = "VorschlagResultat";
            this.edtResultat.DataSource = this.qryInizioVorschlag;
            this.edtResultat.Location = new System.Drawing.Point(226, 99);
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
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtResultat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtResultat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtResultat.Properties.NullText = "";
            this.edtResultat.Properties.ShowFooter = false;
            this.edtResultat.Properties.ShowHeader = false;
            this.edtResultat.Size = new System.Drawing.Size(245, 24);
            this.edtResultat.TabIndex = 6;
            // 
            // edtResultatDatum
            // 
            this.edtResultatDatum.DataMember = "VorschlagResultatDatum";
            this.edtResultatDatum.DataSource = this.qryInizioVorschlag;
            this.edtResultatDatum.EditValue = null;
            this.edtResultatDatum.Location = new System.Drawing.Point(119, 99);
            this.edtResultatDatum.Name = "edtResultatDatum";
            this.edtResultatDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtResultatDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtResultatDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtResultatDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtResultatDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtResultatDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtResultatDatum.Properties.Appearance.Options.UseFont = true;
            this.edtResultatDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtResultatDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtResultatDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtResultatDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtResultatDatum.Properties.ShowToday = false;
            this.edtResultatDatum.Size = new System.Drawing.Size(94, 24);
            this.edtResultatDatum.TabIndex = 5;
            // 
            // edtSchnuppernBis
            // 
            this.edtSchnuppernBis.DataMember = "SchnuppernBis";
            this.edtSchnuppernBis.DataSource = this.qryInizioVorschlag;
            this.edtSchnuppernBis.EditValue = null;
            this.edtSchnuppernBis.Location = new System.Drawing.Point(249, 69);
            this.edtSchnuppernBis.Name = "edtSchnuppernBis";
            this.edtSchnuppernBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSchnuppernBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchnuppernBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchnuppernBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchnuppernBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchnuppernBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchnuppernBis.Properties.Appearance.Options.UseFont = true;
            this.edtSchnuppernBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSchnuppernBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchnuppernBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSchnuppernBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchnuppernBis.Properties.ShowToday = false;
            this.edtSchnuppernBis.Size = new System.Drawing.Size(94, 24);
            this.edtSchnuppernBis.TabIndex = 4;
            this.edtSchnuppernBis.Leave += new System.EventHandler(this.datLeaveSchnuppern);
            // 
            // edtSchnuppernVon
            // 
            this.edtSchnuppernVon.DataMember = "SchnuppernVon";
            this.edtSchnuppernVon.DataSource = this.qryInizioVorschlag;
            this.edtSchnuppernVon.EditValue = null;
            this.edtSchnuppernVon.Location = new System.Drawing.Point(119, 69);
            this.edtSchnuppernVon.Name = "edtSchnuppernVon";
            this.edtSchnuppernVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSchnuppernVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchnuppernVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchnuppernVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchnuppernVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchnuppernVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchnuppernVon.Properties.Appearance.Options.UseFont = true;
            this.edtSchnuppernVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSchnuppernVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchnuppernVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSchnuppernVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchnuppernVon.Properties.ShowToday = false;
            this.edtSchnuppernVon.Size = new System.Drawing.Size(94, 24);
            this.edtSchnuppernVon.TabIndex = 3;
            this.edtSchnuppernVon.Leave += new System.EventHandler(this.datLeaveSchnuppern);
            // 
            // edtVorstellungsgespraech
            // 
            this.edtVorstellungsgespraech.DataMember = "Vorstellungsgespraech";
            this.edtVorstellungsgespraech.DataSource = this.qryInizioVorschlag;
            this.edtVorstellungsgespraech.EditValue = null;
            this.edtVorstellungsgespraech.Location = new System.Drawing.Point(119, 39);
            this.edtVorstellungsgespraech.Name = "edtVorstellungsgespraech";
            this.edtVorstellungsgespraech.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVorstellungsgespraech.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorstellungsgespraech.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorstellungsgespraech.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorstellungsgespraech.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorstellungsgespraech.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorstellungsgespraech.Properties.Appearance.Options.UseFont = true;
            this.edtVorstellungsgespraech.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtVorstellungsgespraech.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVorstellungsgespraech.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtVorstellungsgespraech.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVorstellungsgespraech.Properties.ShowToday = false;
            this.edtVorstellungsgespraech.Size = new System.Drawing.Size(94, 24);
            this.edtVorstellungsgespraech.TabIndex = 2;
            // 
            // edtDossierGesendet
            // 
            this.edtDossierGesendet.DataMember = "DossierGesendet";
            this.edtDossierGesendet.DataSource = this.qryInizioVorschlag;
            this.edtDossierGesendet.EditValue = null;
            this.edtDossierGesendet.Location = new System.Drawing.Point(119, 9);
            this.edtDossierGesendet.Name = "edtDossierGesendet";
            this.edtDossierGesendet.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDossierGesendet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDossierGesendet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDossierGesendet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDossierGesendet.Properties.Appearance.Options.UseBackColor = true;
            this.edtDossierGesendet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDossierGesendet.Properties.Appearance.Options.UseFont = true;
            this.edtDossierGesendet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtDossierGesendet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDossierGesendet.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtDossierGesendet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDossierGesendet.Properties.ShowToday = false;
            this.edtDossierGesendet.Size = new System.Drawing.Size(94, 24);
            this.edtDossierGesendet.TabIndex = 1;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(750, 40);
            this.pnTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Ka_Inizio_Einsätze";
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
            // grdInizioEinsaetze
            // 
            this.grdInizioEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdInizioEinsaetze.DataSource = this.qryInizioVorschlag;
            // 
            // 
            // 
            this.grdInizioEinsaetze.EmbeddedNavigator.Name = "";
            this.grdInizioEinsaetze.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdInizioEinsaetze.Location = new System.Drawing.Point(0, 35);
            this.grdInizioEinsaetze.MainView = this.grvEinsaetze;
            this.grdInizioEinsaetze.Name = "grdInizioEinsaetze";
            this.grdInizioEinsaetze.Size = new System.Drawing.Size(732, 125);
            this.grdInizioEinsaetze.TabIndex = 2;
            this.grdInizioEinsaetze.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinsaetze,
            this.gridView});
            // 
            // grvEinsaetze
            // 
            this.grvEinsaetze.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEinsaetze.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.Empty.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.Empty.Options.UseFont = true;
            this.grvEinsaetze.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.EvenRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsaetze.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEinsaetze.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEinsaetze.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsaetze.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEinsaetze.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsaetze.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinsaetze.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvEinsaetze.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsaetze.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsaetze.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsaetze.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsaetze.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.GroupRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEinsaetze.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEinsaetze.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsaetze.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEinsaetze.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEinsaetze.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEinsaetze.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsaetze.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsaetze.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.OddRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinsaetze.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.Row.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.Row.Options.UseFont = true;
            this.grvEinsaetze.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsaetze.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEinsaetze.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEinsaetze.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBezeichnung,
            this.colBetrieb,
            this.colVorstellungsgespraech,
            this.colSchnuppernAb,
            this.colResultat,
            this.colAusbildungsbeginn,
            this.colAbbruchDurch});
            this.grvEinsaetze.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEinsaetze.GridControl = this.grdInizioEinsaetze;
            this.grvEinsaetze.Name = "grvEinsaetze";
            this.grvEinsaetze.OptionsBehavior.Editable = false;
            this.grvEinsaetze.OptionsCustomization.AllowFilter = false;
            this.grvEinsaetze.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEinsaetze.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEinsaetze.OptionsNavigation.UseTabKey = false;
            this.grvEinsaetze.OptionsView.ColumnAutoWidth = false;
            this.grvEinsaetze.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEinsaetze.OptionsView.ShowGroupPanel = false;
            this.grvEinsaetze.OptionsView.ShowIndicator = false;
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "Einsatzplatz";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 0;
            this.colBezeichnung.Width = 120;
            // 
            // colBetrieb
            // 
            this.colBetrieb.Caption = "Betrieb";
            this.colBetrieb.FieldName = "Betrieb";
            this.colBetrieb.Name = "colBetrieb";
            this.colBetrieb.Visible = true;
            this.colBetrieb.VisibleIndex = 1;
            this.colBetrieb.Width = 120;
            // 
            // colVorstellungsgespraech
            // 
            this.colVorstellungsgespraech.Caption = "Vorstellungsgespr.";
            this.colVorstellungsgespraech.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colVorstellungsgespraech.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVorstellungsgespraech.FieldName = "Vorstellungsgespraech";
            this.colVorstellungsgespraech.Name = "colVorstellungsgespraech";
            this.colVorstellungsgespraech.Visible = true;
            this.colVorstellungsgespraech.VisibleIndex = 2;
            // 
            // colSchnuppernAb
            // 
            this.colSchnuppernAb.Caption = "Schnuppern";
            this.colSchnuppernAb.FieldName = "Schnuppern";
            this.colSchnuppernAb.Name = "colSchnuppernAb";
            this.colSchnuppernAb.Visible = true;
            this.colSchnuppernAb.VisibleIndex = 3;
            this.colSchnuppernAb.Width = 120;
            // 
            // colResultat
            // 
            this.colResultat.Caption = "Resultat";
            this.colResultat.FieldName = "VorschlagResultat";
            this.colResultat.Name = "colResultat";
            this.colResultat.Visible = true;
            this.colResultat.VisibleIndex = 4;
            this.colResultat.Width = 86;
            // 
            // colAusbildungsbeginn
            // 
            this.colAusbildungsbeginn.Caption = "Ausb.beginn";
            this.colAusbildungsbeginn.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colAusbildungsbeginn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAusbildungsbeginn.FieldName = "EinsatzVon";
            this.colAusbildungsbeginn.Name = "colAusbildungsbeginn";
            this.colAusbildungsbeginn.Visible = true;
            this.colAusbildungsbeginn.VisibleIndex = 5;
            this.colAusbildungsbeginn.Width = 84;
            // 
            // colAbbruchDurch
            // 
            this.colAbbruchDurch.Caption = "Abbruch durch";
            this.colAbbruchDurch.FieldName = "InizioEinsatzAbbruchDurchCode";
            this.colAbbruchDurch.Name = "colAbbruchDurch";
            this.colAbbruchDurch.Visible = true;
            this.colAbbruchDurch.VisibleIndex = 6;
            this.colAbbruchDurch.Width = 100;
            // 
            // gridView
            // 
            this.gridView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.Empty.Options.UseBackColor = true;
            this.gridView.Appearance.Empty.Options.UseFont = true;
            this.gridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.EvenRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView.Appearance.GroupRow.Options.UseFont = true;
            this.gridView.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.OddRow.Options.UseFont = true;
            this.gridView.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.Row.Options.UseBackColor = true;
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.grdInizioEinsaetze;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsNavigation.UseTabKey = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // lblEinsatzplatzBezeichnung
            // 
            this.lblEinsatzplatzBezeichnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinsatzplatzBezeichnung.Location = new System.Drawing.Point(8, 166);
            this.lblEinsatzplatzBezeichnung.Name = "lblEinsatzplatzBezeichnung";
            this.lblEinsatzplatzBezeichnung.Size = new System.Drawing.Size(77, 24);
            this.lblEinsatzplatzBezeichnung.TabIndex = 31;
            this.lblEinsatzplatzBezeichnung.Text = "Bezeichnung";
            this.lblEinsatzplatzBezeichnung.UseCompatibleTextRendering = true;
            // 
            // lblBetrieb
            // 
            this.lblBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrieb.Location = new System.Drawing.Point(8, 216);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(77, 24);
            this.lblBetrieb.TabIndex = 32;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            // 
            // lblKontaktPerson
            // 
            this.lblKontaktPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKontaktPerson.Location = new System.Drawing.Point(8, 239);
            this.lblKontaktPerson.Name = "lblKontaktPerson";
            this.lblKontaktPerson.Size = new System.Drawing.Size(77, 24);
            this.lblKontaktPerson.TabIndex = 33;
            this.lblKontaktPerson.Text = "Kontaktperson";
            this.lblKontaktPerson.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzplatz
            // 
            this.edtEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinsatzplatz.DataMember = "Einsatzplatz";
            this.edtEinsatzplatz.DataSource = this.qryInizioVorschlag;
            this.edtEinsatzplatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatz.Location = new System.Drawing.Point(92, 166);
            this.edtEinsatzplatz.Name = "edtEinsatzplatz";
            this.edtEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatz.Properties.ReadOnly = true;
            this.edtEinsatzplatz.Size = new System.Drawing.Size(459, 24);
            this.edtEinsatzplatz.TabIndex = 34;
            // 
            // edtBetrieb
            // 
            this.edtBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrieb.DataMember = "Betrieb";
            this.edtBetrieb.DataSource = this.qryInizioVorschlag;
            this.edtBetrieb.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrieb.Location = new System.Drawing.Point(92, 216);
            this.edtBetrieb.Name = "edtBetrieb";
            this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrieb.Properties.ReadOnly = true;
            this.edtBetrieb.Size = new System.Drawing.Size(459, 24);
            this.edtBetrieb.TabIndex = 35;
            // 
            // edtKontaktperson
            // 
            this.edtKontaktperson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktperson.DataMember = "Kontaktperson";
            this.edtKontaktperson.DataSource = this.qryInizioVorschlag;
            this.edtKontaktperson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontaktperson.Location = new System.Drawing.Point(92, 241);
            this.edtKontaktperson.Name = "edtKontaktperson";
            this.edtKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktperson.Properties.ReadOnly = true;
            this.edtKontaktperson.Size = new System.Drawing.Size(459, 24);
            this.edtKontaktperson.TabIndex = 36;
            // 
            // lblLehrberuf
            // 
            this.lblLehrberuf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLehrberuf.Location = new System.Drawing.Point(8, 191);
            this.lblLehrberuf.Name = "lblLehrberuf";
            this.lblLehrberuf.Size = new System.Drawing.Size(77, 24);
            this.lblLehrberuf.TabIndex = 37;
            this.lblLehrberuf.Text = "Lehrberuf";
            this.lblLehrberuf.UseCompatibleTextRendering = true;
            // 
            // edtLehrberuf
            // 
            this.edtLehrberuf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLehrberuf.DataMember = "Lehrberuf";
            this.edtLehrberuf.DataSource = this.qryInizioVorschlag;
            this.edtLehrberuf.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLehrberuf.Location = new System.Drawing.Point(92, 191);
            this.edtLehrberuf.Name = "edtLehrberuf";
            this.edtLehrberuf.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLehrberuf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLehrberuf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehrberuf.Properties.Appearance.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLehrberuf.Properties.Appearance.Options.UseFont = true;
            this.edtLehrberuf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLehrberuf.Properties.ReadOnly = true;
            this.edtLehrberuf.Size = new System.Drawing.Size(459, 24);
            this.edtLehrberuf.TabIndex = 38;
            // 
            // CtlKaInizioEinsaetze
            // 
            this.ActiveSQLQuery = this.qryInizioVorschlag;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(732, 550);
            this.Controls.Add(this.edtLehrberuf);
            this.Controls.Add(this.lblLehrberuf);
            this.Controls.Add(this.edtKontaktperson);
            this.Controls.Add(this.edtBetrieb);
            this.Controls.Add(this.edtEinsatzplatz);
            this.Controls.Add(this.lblKontaktPerson);
            this.Controls.Add(this.lblBetrieb);
            this.Controls.Add(this.lblEinsatzplatzBezeichnung);
            this.Controls.Add(this.grdInizioEinsaetze);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.tabInizioEinsaetze);
            this.Controls.Add(this.btnDetailsEinsatzplatz);
            this.Name = "CtlKaInizioEinsaetze";
            this.Size = new System.Drawing.Size(750, 558);
            this.Load += new System.EventHandler(this.CtlKaInizioEinsaetze_Load);
            this.tabInizioEinsaetze.ResumeLayout(false);
            this.tpgLehre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrvertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussLehre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildungsende)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnschlussloesung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLoesung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbbruchDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildungsbeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrvertragDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschlussloesung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschlussloesung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioLehre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLoesung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbbruchDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbbruchDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehreBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehreVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrvertragDatum.Properties)).EndInit();
            this.tpgVorschlag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSchnuppernBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchnuppernVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorstellungsgespraech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDossierGesendet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioVorschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchnuppernBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchnuppernVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorstellungsgespraech.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDossierGesendet.Properties)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInizioEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).EndInit();
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

        private void CtlKaInizioEinsaetze_Load(object sender, EventArgs e)
        {
            btnDetailsEinsatzplatz.Enabled = (DBUtil.UserHasRight("CtlKaInizioEinsaetze", "UI") && (MayUpd || MayIns));

            if (KaUtil.GetSichtbarSDFlag(this.baPersonID) == 1)
            {
                btnDetailsEinsatzplatz.Enabled = false;
            }
        }

        private void btnDetailsEinsatzplatz_Click(object sender, System.EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", qryInizioVorschlag["KaEinsatzplatzID"]);
        }

        private void qryInizioLehre_BeforePost(object sender, System.EventArgs e)
        {
            qryInizioVorschlag["EinsatzVon"] = edtLehreVon.EditValue;

            qryInizioVorschlag["InizioEinsatzAbbruchDurchCode"] = edtAbbruchDurch.EditValue;
        }

        private void qryInizioLehre_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryInizioVorschlag.RowModified = true;
        }

        private void qryInizioVorschlag_AfterFill(object sender, System.EventArgs e)
        {
            qryInizioVorschlag_PositionChanged(sender, null);
        }

        private void qryInizioVorschlag_AfterPost(object sender, System.EventArgs e)
        {
            if (!qryInizioLehre.Post())
                throw new KissCancelException();
        }

        private void qryInizioVorschlag_BeforeDelete(object sender, System.EventArgs e)
        {
            DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz WHERE KaVermittlungVorschlagID = {0}", qryInizioVorschlag["KaVermittlungVorschlagID"]);
        }

        private void qryInizioVorschlag_BeforePost(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtSchnuppernVon.EditValue) && !DBUtil.IsEmpty(edtSchnuppernBis.EditValue))
                qryInizioVorschlag["Schnuppern"] = string.Format("{0:d}", edtSchnuppernVon.EditValue) + " - " + string.Format("{0:d}", edtSchnuppernBis.EditValue);

            if (!DBUtil.IsEmpty(edtSchnuppernBis.EditValue) && !DBUtil.IsEmpty(edtSchnuppernVon.EditValue))
                qryInizioVorschlag["Schnuppern"] = string.Format("{0:d}", edtSchnuppernVon.EditValue) + " - " + string.Format("{0:d}", edtSchnuppernBis.EditValue);
        }

        private void qryInizioVorschlag_PositionChanged(object sender, System.EventArgs e)
        {
            if (qryInizioVorschlag.Count == 0)
            {
                qryInizioLehre.Fill(DBNull.Value);
            }
            else
            {
                qryInizioLehre.Fill(qryInizioVorschlag["KaVermittlungVorschlagID"]);
            }

            btnDetailsEinsatzplatz.Enabled = qryInizioVorschlag.Count > 0;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            this.faLeistungID = FaLeistungID;
            this.baPersonID = BaPersonID;

            tabInizioEinsaetze.SelectedTabIndex = 0;
            qryInizioVorschlag.Fill(faLeistungID, KaUtil.GetSichtbarSDFlag(baPersonID));

            DBUtil.GetFallRights(this.faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);
            qryInizioLehre.CanUpdate = qryInizioVorschlag.CanUpdate && DBUtil.UserHasRight("CtlKaInizioEinsaetze", "U") && MayUpd;
            qryInizioLehre.CanInsert = qryInizioVorschlag.CanInsert && DBUtil.UserHasRight("CtlKaInizioEinsaetze", "I") && MayIns;
            qryInizioLehre.CanDelete = qryInizioVorschlag.CanDelete && DBUtil.UserHasRight("CtlKaInizioEinsaetze", "D") && MayDel;
            qryInizioLehre.EnableBoundFields();

            this.colAbbruchDurch.ColumnEdit = this.grdInizioEinsaetze.GetLOVLookUpEdit("KaInizioAbbruchDurch");
            this.colResultat.ColumnEdit = this.grdInizioEinsaetze.GetLOVLookUpEdit("KaVorschlagResultat");
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

                    tabInizioEinsaetze.SelectedTabIndex = 0;
                    qryInizioVorschlag.Find(string.Format("KaVermittlungVorschlagID = {0}", param["KaVermittlungVorschlagID"]));

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

        private void datLeaveEinsatz(object sender, System.EventArgs e)
        {
            if (!CheckDate(edtLehreVon, edtLehreBis))
            {
                KissMsg.ShowInfo("CtlKaInizioEinsaetze", "AusbildungVonVorBis", "'bis' darf nicht vor 'Ausbildung von' liegen!");
                ((KiSS4.Gui.KissDateEdit)sender).Focus();
            }
        }

        private void datLeaveSchnuppern(object sender, System.EventArgs e)
        {
            if (!CheckDate(edtSchnuppernVon, edtSchnuppernBis))
            {
                KissMsg.ShowInfo("CtlKaInizioEinsaetze", "SchnuppernVonVorBis", "'bis' darf nicht vor 'Schnuppern von' liegen!");
                ((KiSS4.Gui.KissDateEdit)sender).Focus();
            }
        }

        #endregion

        #endregion
    }
}