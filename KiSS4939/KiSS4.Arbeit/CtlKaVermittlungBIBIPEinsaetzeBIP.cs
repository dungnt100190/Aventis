using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaVermittlungBIBIPEinsaetzeBIP : KiSS4.Gui.KissUserControl
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
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzBis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzende;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colResultat;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlag;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtAblehnungsgrund;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussDurch;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrund;
        private KiSS4.Gui.KissCheckEdit edtBericht1Erhalten;
        private KiSS4.Gui.KissCheckEdit edtBericht2Erhalten;
        private KiSS4.Gui.KissTextEdit edtBetrieb;
        private KiSS4.Gui.KissDateEdit edtEinsatzBis;
        private KiSS4.Gui.KissDateEdit edtEinsatzVon;
        private KiSS4.Gui.KissDateEdit edtEinsatzende;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatz;
        private KissTextEdit edtEinsatzplatzNr;
        private KiSS4.Gui.KissTextEdit edtKontaktperson;
        private KiSS4.Gui.KissCalcEdit edtPensum;
        private KiSS4.Gui.KissLookUpEdit edtResultat;
        private KiSS4.Gui.KissDateEdit edtResultatDatum;
        private KiSS4.Gui.KissCheckEdit edtUnterschrieben;
        private KiSS4.Gui.KissTextEdit edtVerantwortlicherEinsatzplatz;
        private KiSS4.Dokument.XDokument edtVereinbarung;
        private KiSS4.Gui.KissCheckEdit edtVerlaengert;
        private KiSS4.Gui.KissMemoEdit edtVorschlagBemerkungen;
        private KiSS4.Gui.KissDateEdit edtVorschlagDatum;
        private KiSS4.Gui.KissDateEdit edtZwischenbericht1Dok;
        private KiSS4.Gui.KissDateEdit edtZwischenbericht2Dok;
        private int faLeistungID = -1;
        private KiSS4.Gui.KissGrid grdVermittlungSiEinsaetze;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVermittlungSiEinsaetze;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lbKontaktperson;
        private KiSS4.Gui.KissLabel lblAblehnungsgrund;
        private KiSS4.Gui.KissLabel lblAbschlussDurch;
        private KiSS4.Gui.KissLabel lblArbeitspensum;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBericht1Per;
        private KiSS4.Gui.KissLabel lblBericht2Per;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissMemoEdit lblEinsatzBemerkungen;
        private KiSS4.Gui.KissLabel lblEinsatzVon;
        private KiSS4.Gui.KissLabel lblEinsatzende;
        private KiSS4.Gui.KissLabel lblEinsatzendeDatum;
        private KiSS4.Gui.KissLabel lblEinsatzplatz;
        private KissLabel lblEinsatzplatzNr;
        private KiSS4.Gui.KissLabel lblGrund;
        private KiSS4.Gui.KissLabel lblPraktikumsvereinbarung;
        private KiSS4.Gui.KissLabel lblProzent;
        private KiSS4.Gui.KissLabel lblResultat;
        private KiSS4.Gui.KissLabel lblResultatDatum;
        private KiSS4.Gui.KissLabel lblStelleBis;
        private KiSS4.Gui.KissLabel lblTitelResultat;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblVerantwortlicherEinsatzplatz;
        private KiSS4.Gui.KissLabel lblVorschlagBemerkungen;
        private KiSS4.Gui.KissLabel lblVorschlagDatum;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryBIPEinsatz;
        private KiSS4.DB.SqlQuery qryBIPVorschlag;
        private KiSS4.Gui.KissTabControlEx tabEinsaetze;
        private SharpLibrary.WinControls.TabPageEx tpgEinsatz;
        private SharpLibrary.WinControls.TabPageEx tpgVorschlag;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungBIBIPEinsaetzeBIP()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaVermittlungBIBIPEinsaetzeBIP));
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
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.grdVermittlungSiEinsaetze = new KiSS4.Gui.KissGrid();
            this.qryBIPVorschlag = new KiSS4.DB.SqlQuery(this.components);
            this.grvVermittlungSiEinsaetze = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVorschlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.edtEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.btnDetailsEinsatzplatz = new KiSS4.Gui.KissButton();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.edtBetrieb = new KiSS4.Gui.KissTextEdit();
            this.lbKontaktperson = new KiSS4.Gui.KissLabel();
            this.edtKontaktperson = new KiSS4.Gui.KissTextEdit();
            this.lblVerantwortlicherEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.edtVerantwortlicherEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.tabEinsaetze = new KiSS4.Gui.KissTabControlEx();
            this.tpgVorschlag = new SharpLibrary.WinControls.TabPageEx();
            this.edtVorschlagBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblVorschlagBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtAblehnungsgrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblAblehnungsgrund = new KiSS4.Gui.KissLabel();
            this.edtResultat = new KiSS4.Gui.KissLookUpEdit();
            this.lblResultat = new KiSS4.Gui.KissLabel();
            this.edtResultatDatum = new KiSS4.Gui.KissDateEdit();
            this.lblResultatDatum = new KiSS4.Gui.KissLabel();
            this.lblTitelResultat = new KiSS4.Gui.KissLabel();
            this.edtVorschlagDatum = new KiSS4.Gui.KissDateEdit();
            this.lblVorschlagDatum = new KiSS4.Gui.KissLabel();
            this.tpgEinsatz = new SharpLibrary.WinControls.TabPageEx();
            this.lblEinsatzBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.qryBIPEinsatz = new KiSS4.DB.SqlQuery(this.components);
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.edtAbschlussDurch = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbschlussDurch = new KiSS4.Gui.KissLabel();
            this.edtEinsatzende = new KiSS4.Gui.KissDateEdit();
            this.lblEinsatzendeDatum = new KiSS4.Gui.KissLabel();
            this.lblEinsatzende = new KiSS4.Gui.KissLabel();
            this.edtBericht2Erhalten = new KiSS4.Gui.KissCheckEdit();
            this.edtZwischenbericht2Dok = new KiSS4.Gui.KissDateEdit();
            this.lblBericht2Per = new KiSS4.Gui.KissLabel();
            this.edtBericht1Erhalten = new KiSS4.Gui.KissCheckEdit();
            this.edtZwischenbericht1Dok = new KiSS4.Gui.KissDateEdit();
            this.lblBericht1Per = new KiSS4.Gui.KissLabel();
            this.edtUnterschrieben = new KiSS4.Gui.KissCheckEdit();
            this.edtVereinbarung = new KiSS4.Dokument.XDokument();
            this.lblPraktikumsvereinbarung = new KiSS4.Gui.KissLabel();
            this.lblProzent = new KiSS4.Gui.KissLabel();
            this.edtPensum = new KiSS4.Gui.KissCalcEdit();
            this.lblArbeitspensum = new KiSS4.Gui.KissLabel();
            this.edtVerlaengert = new KiSS4.Gui.KissCheckEdit();
            this.edtEinsatzBis = new KiSS4.Gui.KissDateEdit();
            this.lblStelleBis = new KiSS4.Gui.KissLabel();
            this.edtEinsatzVon = new KiSS4.Gui.KissDateEdit();
            this.lblEinsatzVon = new KiSS4.Gui.KissLabel();
            this.edtEinsatzplatzNr = new KiSS4.Gui.KissTextEdit();
            this.lblEinsatzplatzNr = new KiSS4.Gui.KissLabel();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVermittlungSiEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIPVorschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlungSiEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerantwortlicherEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlicherEinsatzplatz.Properties)).BeginInit();
            this.tabEinsaetze.SuspendLayout();
            this.tpgVorschlag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAblehnungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultatDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelResultat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagDatum)).BeginInit();
            this.tpgEinsatz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIPEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzende.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzendeDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzende)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht2Erhalten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZwischenbericht2Dok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBericht2Per)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht1Erhalten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZwischenbericht1Dok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBericht1Per)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterschrieben.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbarung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraktikumsvereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitspensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerlaengert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStelleBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNr)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(726, 40);
            this.pnTitle.TabIndex = 0;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Einsätze BIP";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // grdVermittlungSiEinsaetze
            // 
            this.grdVermittlungSiEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVermittlungSiEinsaetze.DataSource = this.qryBIPVorschlag;
            // 
            // 
            // 
            this.grdVermittlungSiEinsaetze.EmbeddedNavigator.Name = "";
            this.grdVermittlungSiEinsaetze.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVermittlungSiEinsaetze.Location = new System.Drawing.Point(0, 35);
            this.grdVermittlungSiEinsaetze.MainView = this.grvVermittlungSiEinsaetze;
            this.grdVermittlungSiEinsaetze.Name = "grdVermittlungSiEinsaetze";
            this.grdVermittlungSiEinsaetze.Size = new System.Drawing.Size(722, 159);
            this.grdVermittlungSiEinsaetze.TabIndex = 1;
            this.grdVermittlungSiEinsaetze.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVermittlungSiEinsaetze});
            // 
            // qryBIPVorschlag
            // 
            this.qryBIPVorschlag.CanDelete = true;
            this.qryBIPVorschlag.CanUpdate = true;
            this.qryBIPVorschlag.HostControl = this;
            this.qryBIPVorschlag.IsIdentityInsert = false;
            this.qryBIPVorschlag.SelectStatement = resources.GetString("qryBIPVorschlag.SelectStatement");
            this.qryBIPVorschlag.TableName = "KaVermittlungVorschlag";
            this.qryBIPVorschlag.AfterFill += new System.EventHandler(this.qryBIPVorschlag_AfterFill);
            this.qryBIPVorschlag.AfterPost += new System.EventHandler(this.qryBIPVorschlag_AfterPost);
            this.qryBIPVorschlag.BeforeDelete += new System.EventHandler(this.qryBIPVorschlag_BeforeDelete);
            this.qryBIPVorschlag.PositionChanged += new System.EventHandler(this.qryBIPVorschlag_PositionChanged);
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
            this.colEinsatzende});
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
            this.colEinsatzVon.Caption = "Einsatz von";
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
            this.colPensum.Caption = "Pensum %";
            this.colPensum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPensum.FieldName = "Arbeitspensum";
            this.colPensum.Name = "colPensum";
            this.colPensum.Visible = true;
            this.colPensum.VisibleIndex = 6;
            this.colPensum.Width = 72;
            // 
            // colEinsatzende
            // 
            this.colEinsatzende.Caption = "Einsatzende";
            this.colEinsatzende.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colEinsatzende.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEinsatzende.FieldName = "Abschluss";
            this.colEinsatzende.Name = "colEinsatzende";
            this.colEinsatzende.Visible = true;
            this.colEinsatzende.VisibleIndex = 7;
            this.colEinsatzende.Width = 104;
            // 
            // lblEinsatzplatz
            // 
            this.lblEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinsatzplatz.Location = new System.Drawing.Point(8, 200);
            this.lblEinsatzplatz.Name = "lblEinsatzplatz";
            this.lblEinsatzplatz.Size = new System.Drawing.Size(75, 24);
            this.lblEinsatzplatz.TabIndex = 2;
            this.lblEinsatzplatz.Text = "Bezeichnung";
            this.lblEinsatzplatz.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzplatz
            // 
            this.edtEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinsatzplatz.DataMember = "Einsatzplatz";
            this.edtEinsatzplatz.DataSource = this.qryBIPVorschlag;
            this.edtEinsatzplatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatz.Location = new System.Drawing.Point(112, 200);
            this.edtEinsatzplatz.Name = "edtEinsatzplatz";
            this.edtEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatz.Properties.ReadOnly = true;
            this.edtEinsatzplatz.Size = new System.Drawing.Size(364, 24);
            this.edtEinsatzplatz.TabIndex = 3;
            // 
            // btnDetailsEinsatzplatz
            // 
            this.btnDetailsEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetailsEinsatzplatz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailsEinsatzplatz.Location = new System.Drawing.Point(595, 200);
            this.btnDetailsEinsatzplatz.Name = "btnDetailsEinsatzplatz";
            this.btnDetailsEinsatzplatz.Size = new System.Drawing.Size(124, 24);
            this.btnDetailsEinsatzplatz.TabIndex = 4;
            this.btnDetailsEinsatzplatz.Text = "Info Einsatzplatz";
            this.btnDetailsEinsatzplatz.UseCompatibleTextRendering = true;
            this.btnDetailsEinsatzplatz.UseVisualStyleBackColor = false;
            this.btnDetailsEinsatzplatz.Click += new System.EventHandler(this.btnDetailsEinsatzplatz_Click);
            // 
            // lblBetrieb
            // 
            this.lblBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrieb.Location = new System.Drawing.Point(8, 225);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(75, 24);
            this.lblBetrieb.TabIndex = 5;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            // 
            // edtBetrieb
            // 
            this.edtBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrieb.DataMember = "Betrieb";
            this.edtBetrieb.DataSource = this.qryBIPVorschlag;
            this.edtBetrieb.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrieb.Location = new System.Drawing.Point(112, 225);
            this.edtBetrieb.Name = "edtBetrieb";
            this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrieb.Properties.ReadOnly = true;
            this.edtBetrieb.Size = new System.Drawing.Size(472, 24);
            this.edtBetrieb.TabIndex = 6;
            // 
            // lbKontaktperson
            // 
            this.lbKontaktperson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbKontaktperson.Location = new System.Drawing.Point(8, 250);
            this.lbKontaktperson.Name = "lbKontaktperson";
            this.lbKontaktperson.Size = new System.Drawing.Size(98, 24);
            this.lbKontaktperson.TabIndex = 7;
            this.lbKontaktperson.Text = "Kontaktperson";
            this.lbKontaktperson.UseCompatibleTextRendering = true;
            // 
            // edtKontaktperson
            // 
            this.edtKontaktperson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktperson.DataMember = "Kontaktperson";
            this.edtKontaktperson.DataSource = this.qryBIPVorschlag;
            this.edtKontaktperson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontaktperson.Location = new System.Drawing.Point(112, 250);
            this.edtKontaktperson.Name = "edtKontaktperson";
            this.edtKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktperson.Properties.ReadOnly = true;
            this.edtKontaktperson.Size = new System.Drawing.Size(472, 24);
            this.edtKontaktperson.TabIndex = 8;
            // 
            // lblVerantwortlicherEinsatzplatz
            // 
            this.lblVerantwortlicherEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerantwortlicherEinsatzplatz.Location = new System.Drawing.Point(8, 275);
            this.lblVerantwortlicherEinsatzplatz.Name = "lblVerantwortlicherEinsatzplatz";
            this.lblVerantwortlicherEinsatzplatz.Size = new System.Drawing.Size(103, 24);
            this.lblVerantwortlicherEinsatzplatz.TabIndex = 9;
            this.lblVerantwortlicherEinsatzplatz.Text = "Verantw. Einsatzpl.";
            this.lblVerantwortlicherEinsatzplatz.UseCompatibleTextRendering = true;
            // 
            // edtVerantwortlicherEinsatzplatz
            // 
            this.edtVerantwortlicherEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerantwortlicherEinsatzplatz.DataMember = "VerantwEP";
            this.edtVerantwortlicherEinsatzplatz.DataSource = this.qryBIPVorschlag;
            this.edtVerantwortlicherEinsatzplatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerantwortlicherEinsatzplatz.Location = new System.Drawing.Point(112, 275);
            this.edtVerantwortlicherEinsatzplatz.Name = "edtVerantwortlicherEinsatzplatz";
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerantwortlicherEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtVerantwortlicherEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerantwortlicherEinsatzplatz.Properties.ReadOnly = true;
            this.edtVerantwortlicherEinsatzplatz.Size = new System.Drawing.Size(472, 24);
            this.edtVerantwortlicherEinsatzplatz.TabIndex = 10;
            // 
            // tabEinsaetze
            // 
            this.tabEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabEinsaetze.Controls.Add(this.tpgVorschlag);
            this.tabEinsaetze.Controls.Add(this.tpgEinsatz);
            this.tabEinsaetze.Location = new System.Drawing.Point(0, 305);
            this.tabEinsaetze.Name = "tabEinsaetze";
            this.tabEinsaetze.ShowFixedWidthTooltip = true;
            this.tabEinsaetze.Size = new System.Drawing.Size(719, 253);
            this.tabEinsaetze.TabIndex = 11;
            this.tabEinsaetze.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgVorschlag,
            this.tpgEinsatz});
            this.tabEinsaetze.TabsLineColor = System.Drawing.Color.Black;
            this.tabEinsaetze.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabEinsaetze.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgVorschlag
            // 
            this.tpgVorschlag.Controls.Add(this.edtVorschlagBemerkungen);
            this.tpgVorschlag.Controls.Add(this.lblVorschlagBemerkungen);
            this.tpgVorschlag.Controls.Add(this.edtAblehnungsgrund);
            this.tpgVorschlag.Controls.Add(this.lblAblehnungsgrund);
            this.tpgVorschlag.Controls.Add(this.edtResultat);
            this.tpgVorschlag.Controls.Add(this.lblResultat);
            this.tpgVorschlag.Controls.Add(this.edtResultatDatum);
            this.tpgVorschlag.Controls.Add(this.lblResultatDatum);
            this.tpgVorschlag.Controls.Add(this.lblTitelResultat);
            this.tpgVorschlag.Controls.Add(this.edtVorschlagDatum);
            this.tpgVorschlag.Controls.Add(this.lblVorschlagDatum);
            this.tpgVorschlag.Location = new System.Drawing.Point(6, 32);
            this.tpgVorschlag.Name = "tpgVorschlag";
            this.tpgVorschlag.Size = new System.Drawing.Size(707, 215);
            this.tpgVorschlag.TabIndex = 0;
            this.tpgVorschlag.Title = "Vorschlag";
            // 
            // edtVorschlagBemerkungen
            // 
            this.edtVorschlagBemerkungen.DataMember = "VorschlagBemerkungen";
            this.edtVorschlagBemerkungen.DataSource = this.qryBIPVorschlag;
            this.edtVorschlagBemerkungen.Location = new System.Drawing.Point(110, 163);
            this.edtVorschlagBemerkungen.Name = "edtVorschlagBemerkungen";
            this.edtVorschlagBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorschlagBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorschlagBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorschlagBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorschlagBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorschlagBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtVorschlagBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorschlagBemerkungen.Size = new System.Drawing.Size(597, 49);
            this.edtVorschlagBemerkungen.TabIndex = 10;
            // 
            // lblVorschlagBemerkungen
            // 
            this.lblVorschlagBemerkungen.Location = new System.Drawing.Point(4, 156);
            this.lblVorschlagBemerkungen.Name = "lblVorschlagBemerkungen";
            this.lblVorschlagBemerkungen.Size = new System.Drawing.Size(90, 24);
            this.lblVorschlagBemerkungen.TabIndex = 9;
            this.lblVorschlagBemerkungen.Text = "Bemerkungen";
            this.lblVorschlagBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtAblehnungsgrund
            // 
            this.edtAblehnungsgrund.DataMember = "VorschlagAblehnungsgrundBIPCode";
            this.edtAblehnungsgrund.DataSource = this.qryBIPVorschlag;
            this.edtAblehnungsgrund.Location = new System.Drawing.Point(111, 121);
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAblehnungsgrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAblehnungsgrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAblehnungsgrund.Properties.NullText = "";
            this.edtAblehnungsgrund.Properties.ShowFooter = false;
            this.edtAblehnungsgrund.Properties.ShowHeader = false;
            this.edtAblehnungsgrund.Size = new System.Drawing.Size(351, 24);
            this.edtAblehnungsgrund.TabIndex = 8;
            // 
            // lblAblehnungsgrund
            // 
            this.lblAblehnungsgrund.Location = new System.Drawing.Point(4, 121);
            this.lblAblehnungsgrund.Name = "lblAblehnungsgrund";
            this.lblAblehnungsgrund.Size = new System.Drawing.Size(101, 24);
            this.lblAblehnungsgrund.TabIndex = 7;
            this.lblAblehnungsgrund.Text = "Ablehnungsgrund";
            this.lblAblehnungsgrund.UseCompatibleTextRendering = true;
            // 
            // edtResultat
            // 
            this.edtResultat.DataMember = "VorschlagResultat";
            this.edtResultat.DataSource = this.qryBIPVorschlag;
            this.edtResultat.Location = new System.Drawing.Point(111, 91);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtResultat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtResultat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtResultat.Properties.NullText = "";
            this.edtResultat.Properties.ShowFooter = false;
            this.edtResultat.Properties.ShowHeader = false;
            this.edtResultat.Size = new System.Drawing.Size(351, 24);
            this.edtResultat.TabIndex = 6;
            // 
            // lblResultat
            // 
            this.lblResultat.Location = new System.Drawing.Point(4, 91);
            this.lblResultat.Name = "lblResultat";
            this.lblResultat.Size = new System.Drawing.Size(90, 24);
            this.lblResultat.TabIndex = 5;
            this.lblResultat.Text = "Resultat";
            this.lblResultat.UseCompatibleTextRendering = true;
            // 
            // edtResultatDatum
            // 
            this.edtResultatDatum.DataMember = "VorschlagResultatDatum";
            this.edtResultatDatum.DataSource = this.qryBIPVorschlag;
            this.edtResultatDatum.EditValue = null;
            this.edtResultatDatum.Location = new System.Drawing.Point(111, 61);
            this.edtResultatDatum.Name = "edtResultatDatum";
            this.edtResultatDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtResultatDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtResultatDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtResultatDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtResultatDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtResultatDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtResultatDatum.Properties.Appearance.Options.UseFont = true;
            this.edtResultatDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtResultatDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtResultatDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtResultatDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtResultatDatum.Properties.ShowToday = false;
            this.edtResultatDatum.Size = new System.Drawing.Size(100, 24);
            this.edtResultatDatum.TabIndex = 4;
            // 
            // lblResultatDatum
            // 
            this.lblResultatDatum.Location = new System.Drawing.Point(4, 61);
            this.lblResultatDatum.Name = "lblResultatDatum";
            this.lblResultatDatum.Size = new System.Drawing.Size(90, 24);
            this.lblResultatDatum.TabIndex = 3;
            this.lblResultatDatum.Text = "Datum";
            this.lblResultatDatum.UseCompatibleTextRendering = true;
            // 
            // lblTitelResultat
            // 
            this.lblTitelResultat.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelResultat.Location = new System.Drawing.Point(2, 44);
            this.lblTitelResultat.Name = "lblTitelResultat";
            this.lblTitelResultat.Size = new System.Drawing.Size(90, 16);
            this.lblTitelResultat.TabIndex = 2;
            this.lblTitelResultat.Text = "Resultat";
            this.lblTitelResultat.UseCompatibleTextRendering = true;
            // 
            // edtVorschlagDatum
            // 
            this.edtVorschlagDatum.DataMember = "Vorschlag";
            this.edtVorschlagDatum.DataSource = this.qryBIPVorschlag;
            this.edtVorschlagDatum.EditValue = null;
            this.edtVorschlagDatum.Location = new System.Drawing.Point(111, 9);
            this.edtVorschlagDatum.Name = "edtVorschlagDatum";
            this.edtVorschlagDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVorschlagDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorschlagDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorschlagDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorschlagDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorschlagDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorschlagDatum.Properties.Appearance.Options.UseFont = true;
            this.edtVorschlagDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVorschlagDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVorschlagDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVorschlagDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVorschlagDatum.Properties.ShowToday = false;
            this.edtVorschlagDatum.Size = new System.Drawing.Size(100, 24);
            this.edtVorschlagDatum.TabIndex = 1;
            // 
            // lblVorschlagDatum
            // 
            this.lblVorschlagDatum.Location = new System.Drawing.Point(4, 9);
            this.lblVorschlagDatum.Name = "lblVorschlagDatum";
            this.lblVorschlagDatum.Size = new System.Drawing.Size(90, 24);
            this.lblVorschlagDatum.TabIndex = 0;
            this.lblVorschlagDatum.Text = "Vorschlag";
            this.lblVorschlagDatum.UseCompatibleTextRendering = true;
            // 
            // tpgEinsatz
            // 
            this.tpgEinsatz.Controls.Add(this.lblEinsatzBemerkungen);
            this.tpgEinsatz.Controls.Add(this.lblBemerkungen);
            this.tpgEinsatz.Controls.Add(this.edtAbschlussGrund);
            this.tpgEinsatz.Controls.Add(this.lblGrund);
            this.tpgEinsatz.Controls.Add(this.edtAbschlussDurch);
            this.tpgEinsatz.Controls.Add(this.lblAbschlussDurch);
            this.tpgEinsatz.Controls.Add(this.edtEinsatzende);
            this.tpgEinsatz.Controls.Add(this.lblEinsatzendeDatum);
            this.tpgEinsatz.Controls.Add(this.lblEinsatzende);
            this.tpgEinsatz.Controls.Add(this.edtBericht2Erhalten);
            this.tpgEinsatz.Controls.Add(this.edtZwischenbericht2Dok);
            this.tpgEinsatz.Controls.Add(this.lblBericht2Per);
            this.tpgEinsatz.Controls.Add(this.edtBericht1Erhalten);
            this.tpgEinsatz.Controls.Add(this.edtZwischenbericht1Dok);
            this.tpgEinsatz.Controls.Add(this.lblBericht1Per);
            this.tpgEinsatz.Controls.Add(this.edtUnterschrieben);
            this.tpgEinsatz.Controls.Add(this.edtVereinbarung);
            this.tpgEinsatz.Controls.Add(this.lblPraktikumsvereinbarung);
            this.tpgEinsatz.Controls.Add(this.lblProzent);
            this.tpgEinsatz.Controls.Add(this.edtPensum);
            this.tpgEinsatz.Controls.Add(this.lblArbeitspensum);
            this.tpgEinsatz.Controls.Add(this.edtVerlaengert);
            this.tpgEinsatz.Controls.Add(this.edtEinsatzBis);
            this.tpgEinsatz.Controls.Add(this.lblStelleBis);
            this.tpgEinsatz.Controls.Add(this.edtEinsatzVon);
            this.tpgEinsatz.Controls.Add(this.lblEinsatzVon);
            this.tpgEinsatz.Location = new System.Drawing.Point(6, 32);
            this.tpgEinsatz.Name = "tpgEinsatz";
            this.tpgEinsatz.Size = new System.Drawing.Size(707, 215);
            this.tpgEinsatz.TabIndex = 0;
            this.tpgEinsatz.Title = "Einsatz";
            // 
            // lblEinsatzBemerkungen
            // 
            this.lblEinsatzBemerkungen.DataMember = "EinsatzBemerkungen";
            this.lblEinsatzBemerkungen.DataSource = this.qryBIPEinsatz;
            this.lblEinsatzBemerkungen.Location = new System.Drawing.Point(126, 173);
            this.lblEinsatzBemerkungen.Name = "lblEinsatzBemerkungen";
            this.lblEinsatzBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.lblEinsatzBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.lblEinsatzBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblEinsatzBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.lblEinsatzBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.lblEinsatzBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.lblEinsatzBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblEinsatzBemerkungen.Size = new System.Drawing.Size(578, 42);
            this.lblEinsatzBemerkungen.TabIndex = 25;
            // 
            // qryBIPEinsatz
            // 
            this.qryBIPEinsatz.CanDelete = true;
            this.qryBIPEinsatz.CanUpdate = true;
            this.qryBIPEinsatz.HostControl = this;
            this.qryBIPEinsatz.IsIdentityInsert = false;
            this.qryBIPEinsatz.SelectStatement = "SELECT\tVEI.*\r\nFROM KaVermittlungEinsatz VEI\r\nWHERE VEI.KaVermittlungVorschlagID =" +
    " {0}";
            this.qryBIPEinsatz.TableName = "KaVermittlungEinsatz";
            this.qryBIPEinsatz.BeforePost += new System.EventHandler(this.qryBIPEinsatz_BeforePost);
            this.qryBIPEinsatz.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryBIPEinsatz_ColumnChanging);
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(5, 173);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(76, 24);
            this.lblBemerkungen.TabIndex = 24;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtAbschlussGrund
            // 
            this.edtAbschlussGrund.DataMember = "BIPAbschlussGrundCode";
            this.edtAbschlussGrund.DataSource = this.qryBIPEinsatz;
            this.edtAbschlussGrund.Location = new System.Drawing.Point(126, 144);
            this.edtAbschlussGrund.LOVName = "KaVermittlungBIPEinsatzendeGrund";
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAbschlussGrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrund.Properties.NullText = "";
            this.edtAbschlussGrund.Properties.ShowFooter = false;
            this.edtAbschlussGrund.Properties.ShowHeader = false;
            this.edtAbschlussGrund.Size = new System.Drawing.Size(303, 24);
            this.edtAbschlussGrund.TabIndex = 23;
            // 
            // lblGrund
            // 
            this.lblGrund.Location = new System.Drawing.Point(5, 145);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(74, 24);
            this.lblGrund.TabIndex = 22;
            this.lblGrund.Text = "Grund";
            this.lblGrund.UseCompatibleTextRendering = true;
            // 
            // edtAbschlussDurch
            // 
            this.edtAbschlussDurch.DataMember = "BIBIPSIAbschlussDurchCode";
            this.edtAbschlussDurch.DataSource = this.qryBIPEinsatz;
            this.edtAbschlussDurch.Location = new System.Drawing.Point(279, 114);
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAbschlussDurch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAbschlussDurch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussDurch.Properties.NullText = "";
            this.edtAbschlussDurch.Properties.ShowFooter = false;
            this.edtAbschlussDurch.Properties.ShowHeader = false;
            this.edtAbschlussDurch.Size = new System.Drawing.Size(150, 24);
            this.edtAbschlussDurch.TabIndex = 21;
            // 
            // lblAbschlussDurch
            // 
            this.lblAbschlussDurch.Location = new System.Drawing.Point(238, 114);
            this.lblAbschlussDurch.Name = "lblAbschlussDurch";
            this.lblAbschlussDurch.Size = new System.Drawing.Size(35, 24);
            this.lblAbschlussDurch.TabIndex = 20;
            this.lblAbschlussDurch.Text = "durch";
            this.lblAbschlussDurch.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzende
            // 
            this.edtEinsatzende.DataMember = "Abschluss";
            this.edtEinsatzende.DataSource = this.qryBIPEinsatz;
            this.edtEinsatzende.EditValue = null;
            this.edtEinsatzende.Location = new System.Drawing.Point(126, 114);
            this.edtEinsatzende.Name = "edtEinsatzende";
            this.edtEinsatzende.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzende.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzende.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzende.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzende.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzende.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzende.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzende.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtEinsatzende.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzende.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtEinsatzende.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzende.Properties.ShowToday = false;
            this.edtEinsatzende.Size = new System.Drawing.Size(96, 24);
            this.edtEinsatzende.TabIndex = 19;
            // 
            // lblEinsatzendeDatum
            // 
            this.lblEinsatzendeDatum.Location = new System.Drawing.Point(5, 114);
            this.lblEinsatzendeDatum.Name = "lblEinsatzendeDatum";
            this.lblEinsatzendeDatum.Size = new System.Drawing.Size(66, 24);
            this.lblEinsatzendeDatum.TabIndex = 18;
            this.lblEinsatzendeDatum.Text = "Datum";
            this.lblEinsatzendeDatum.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzende
            // 
            this.lblEinsatzende.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblEinsatzende.Location = new System.Drawing.Point(5, 95);
            this.lblEinsatzende.Name = "lblEinsatzende";
            this.lblEinsatzende.Size = new System.Drawing.Size(89, 16);
            this.lblEinsatzende.TabIndex = 17;
            this.lblEinsatzende.Text = "Stellenende";
            this.lblEinsatzende.UseCompatibleTextRendering = true;
            // 
            // edtBericht2Erhalten
            // 
            this.edtBericht2Erhalten.DataMember = "BIPZwischenbericht2Erhalten";
            this.edtBericht2Erhalten.DataSource = this.qryBIPEinsatz;
            this.edtBericht2Erhalten.Location = new System.Drawing.Point(583, 70);
            this.edtBericht2Erhalten.Name = "edtBericht2Erhalten";
            this.edtBericht2Erhalten.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBericht2Erhalten.Properties.Appearance.Options.UseBackColor = true;
            this.edtBericht2Erhalten.Properties.Caption = "Bericht erhalten";
            this.edtBericht2Erhalten.Size = new System.Drawing.Size(102, 19);
            this.edtBericht2Erhalten.TabIndex = 16;
            // 
            // edtZwischenbericht2Dok
            // 
            this.edtZwischenbericht2Dok.DataMember = "BIPZwischenbericht2Datum";
            this.edtZwischenbericht2Dok.DataSource = this.qryBIPEinsatz;
            this.edtZwischenbericht2Dok.EditValue = null;
            this.edtZwischenbericht2Dok.Location = new System.Drawing.Point(476, 65);
            this.edtZwischenbericht2Dok.Name = "edtZwischenbericht2Dok";
            this.edtZwischenbericht2Dok.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZwischenbericht2Dok.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZwischenbericht2Dok.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZwischenbericht2Dok.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZwischenbericht2Dok.Properties.Appearance.Options.UseBackColor = true;
            this.edtZwischenbericht2Dok.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZwischenbericht2Dok.Properties.Appearance.Options.UseFont = true;
            this.edtZwischenbericht2Dok.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtZwischenbericht2Dok.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZwischenbericht2Dok.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtZwischenbericht2Dok.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZwischenbericht2Dok.Properties.ShowToday = false;
            this.edtZwischenbericht2Dok.Size = new System.Drawing.Size(100, 24);
            this.edtZwischenbericht2Dok.TabIndex = 15;
            // 
            // lblBericht2Per
            // 
            this.lblBericht2Per.Location = new System.Drawing.Point(355, 67);
            this.lblBericht2Per.Name = "lblBericht2Per";
            this.lblBericht2Per.Size = new System.Drawing.Size(116, 24);
            this.lblBericht2Per.TabIndex = 14;
            this.lblBericht2Per.Text = "2. Zwischenbericht per";
            this.lblBericht2Per.UseCompatibleTextRendering = true;
            // 
            // edtBericht1Erhalten
            // 
            this.edtBericht1Erhalten.DataMember = "BIPZwischenbericht1Erhalten";
            this.edtBericht1Erhalten.DataSource = this.qryBIPEinsatz;
            this.edtBericht1Erhalten.Location = new System.Drawing.Point(233, 70);
            this.edtBericht1Erhalten.Name = "edtBericht1Erhalten";
            this.edtBericht1Erhalten.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBericht1Erhalten.Properties.Appearance.Options.UseBackColor = true;
            this.edtBericht1Erhalten.Properties.Caption = "Bericht erhalten";
            this.edtBericht1Erhalten.Size = new System.Drawing.Size(102, 19);
            this.edtBericht1Erhalten.TabIndex = 13;
            // 
            // edtZwischenbericht1Dok
            // 
            this.edtZwischenbericht1Dok.DataMember = "BIPZwischenbericht1Datum";
            this.edtZwischenbericht1Dok.DataSource = this.qryBIPEinsatz;
            this.edtZwischenbericht1Dok.EditValue = null;
            this.edtZwischenbericht1Dok.Location = new System.Drawing.Point(126, 66);
            this.edtZwischenbericht1Dok.Name = "edtZwischenbericht1Dok";
            this.edtZwischenbericht1Dok.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZwischenbericht1Dok.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZwischenbericht1Dok.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZwischenbericht1Dok.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZwischenbericht1Dok.Properties.Appearance.Options.UseBackColor = true;
            this.edtZwischenbericht1Dok.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZwischenbericht1Dok.Properties.Appearance.Options.UseFont = true;
            this.edtZwischenbericht1Dok.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtZwischenbericht1Dok.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZwischenbericht1Dok.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtZwischenbericht1Dok.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZwischenbericht1Dok.Properties.ShowToday = false;
            this.edtZwischenbericht1Dok.Size = new System.Drawing.Size(100, 24);
            this.edtZwischenbericht1Dok.TabIndex = 12;
            // 
            // lblBericht1Per
            // 
            this.lblBericht1Per.Location = new System.Drawing.Point(5, 67);
            this.lblBericht1Per.Name = "lblBericht1Per";
            this.lblBericht1Per.Size = new System.Drawing.Size(117, 24);
            this.lblBericht1Per.TabIndex = 11;
            this.lblBericht1Per.Text = "1. Zwischenbericht per";
            this.lblBericht1Per.UseCompatibleTextRendering = true;
            // 
            // edtUnterschrieben
            // 
            this.edtUnterschrieben.DataMember = "EinsatzVereinbarungUnterschrieben";
            this.edtUnterschrieben.DataSource = this.qryBIPEinsatz;
            this.edtUnterschrieben.Location = new System.Drawing.Point(461, 38);
            this.edtUnterschrieben.Name = "edtUnterschrieben";
            this.edtUnterschrieben.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUnterschrieben.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterschrieben.Properties.Caption = "unterschrieben";
            this.edtUnterschrieben.Size = new System.Drawing.Size(115, 19);
            this.edtUnterschrieben.TabIndex = 10;
            // 
            // edtVereinbarung
            // 
            this.edtVereinbarung.Context = "KaVermBIPEinsatzVereinbarung";
            this.edtVereinbarung.DataMember = "EinsatzVereinbarungDokID";
            this.edtVereinbarung.DataSource = this.qryBIPEinsatz;
            this.edtVereinbarung.Location = new System.Drawing.Point(335, 35);
            this.edtVereinbarung.Name = "edtVereinbarung";
            this.edtVereinbarung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVereinbarung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVereinbarung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVereinbarung.Properties.Appearance.Options.UseBackColor = true;
            this.edtVereinbarung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVereinbarung.Properties.Appearance.Options.UseFont = true;
            this.edtVereinbarung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtVereinbarung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVereinbarung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVereinbarung.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVereinbarung.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVereinbarung.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, "Dokument importieren")});
            this.edtVereinbarung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVereinbarung.Properties.ReadOnly = true;
            this.edtVereinbarung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtVereinbarung.Size = new System.Drawing.Size(120, 24);
            this.edtVereinbarung.TabIndex = 9;
            // 
            // lblPraktikumsvereinbarung
            // 
            this.lblPraktikumsvereinbarung.Location = new System.Drawing.Point(200, 34);
            this.lblPraktikumsvereinbarung.Name = "lblPraktikumsvereinbarung";
            this.lblPraktikumsvereinbarung.Size = new System.Drawing.Size(135, 24);
            this.lblPraktikumsvereinbarung.TabIndex = 8;
            this.lblPraktikumsvereinbarung.Text = "Praktikumsvereinbarung";
            this.lblPraktikumsvereinbarung.UseCompatibleTextRendering = true;
            // 
            // lblProzent
            // 
            this.lblProzent.Location = new System.Drawing.Point(169, 34);
            this.lblProzent.Name = "lblProzent";
            this.lblProzent.Size = new System.Drawing.Size(19, 24);
            this.lblProzent.TabIndex = 7;
            this.lblProzent.Text = "%";
            this.lblProzent.UseCompatibleTextRendering = true;
            // 
            // edtPensum
            // 
            this.edtPensum.DataMember = "Arbeitspensum";
            this.edtPensum.DataSource = this.qryBIPEinsatz;
            this.edtPensum.Location = new System.Drawing.Point(126, 34);
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
            this.edtPensum.TabIndex = 6;
            this.edtPensum.Leave += new System.EventHandler(this.checkPensum);
            // 
            // lblArbeitspensum
            // 
            this.lblArbeitspensum.Location = new System.Drawing.Point(5, 33);
            this.lblArbeitspensum.Name = "lblArbeitspensum";
            this.lblArbeitspensum.Size = new System.Drawing.Size(80, 24);
            this.lblArbeitspensum.TabIndex = 5;
            this.lblArbeitspensum.Text = "Arbeitspensum";
            this.lblArbeitspensum.UseCompatibleTextRendering = true;
            // 
            // edtVerlaengert
            // 
            this.edtVerlaengert.DataMember = "Verlaengerung";
            this.edtVerlaengert.DataSource = this.qryBIPEinsatz;
            this.edtVerlaengert.Location = new System.Drawing.Point(376, 10);
            this.edtVerlaengert.Name = "edtVerlaengert";
            this.edtVerlaengert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerlaengert.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerlaengert.Properties.Caption = " Verlängerung";
            this.edtVerlaengert.Size = new System.Drawing.Size(122, 19);
            this.edtVerlaengert.TabIndex = 4;
            // 
            // edtEinsatzBis
            // 
            this.edtEinsatzBis.DataMember = "EinsatzBis";
            this.edtEinsatzBis.DataSource = this.qryBIPEinsatz;
            this.edtEinsatzBis.EditValue = null;
            this.edtEinsatzBis.Location = new System.Drawing.Point(261, 6);
            this.edtEinsatzBis.Name = "edtEinsatzBis";
            this.edtEinsatzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtEinsatzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzBis.Properties.ShowToday = false;
            this.edtEinsatzBis.Size = new System.Drawing.Size(100, 24);
            this.edtEinsatzBis.TabIndex = 3;
            this.edtEinsatzBis.Leave += new System.EventHandler(this.datLeaveEinsatz);
            // 
            // lblStelleBis
            // 
            this.lblStelleBis.Location = new System.Drawing.Point(229, 6);
            this.lblStelleBis.Name = "lblStelleBis";
            this.lblStelleBis.Size = new System.Drawing.Size(25, 24);
            this.lblStelleBis.TabIndex = 2;
            this.lblStelleBis.Text = "bis";
            this.lblStelleBis.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzVon
            // 
            this.edtEinsatzVon.DataMember = "EinsatzVon";
            this.edtEinsatzVon.DataSource = this.qryBIPEinsatz;
            this.edtEinsatzVon.EditValue = null;
            this.edtEinsatzVon.Location = new System.Drawing.Point(126, 6);
            this.edtEinsatzVon.Name = "edtEinsatzVon";
            this.edtEinsatzVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzVon.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtEinsatzVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtEinsatzVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzVon.Properties.ShowToday = false;
            this.edtEinsatzVon.Size = new System.Drawing.Size(96, 24);
            this.edtEinsatzVon.TabIndex = 1;
            this.edtEinsatzVon.Leave += new System.EventHandler(this.datLeaveEinsatz);
            // 
            // lblEinsatzVon
            // 
            this.lblEinsatzVon.Location = new System.Drawing.Point(5, 6);
            this.lblEinsatzVon.Name = "lblEinsatzVon";
            this.lblEinsatzVon.Size = new System.Drawing.Size(80, 24);
            this.lblEinsatzVon.TabIndex = 0;
            this.lblEinsatzVon.Text = "Einsatz von";
            this.lblEinsatzVon.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzplatzNr
            // 
            this.edtEinsatzplatzNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinsatzplatzNr.DataMember = "KaEinsatzplatzID";
            this.edtEinsatzplatzNr.DataSource = this.qryBIPVorschlag;
            this.edtEinsatzplatzNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatzNr.Location = new System.Drawing.Point(510, 200);
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
            this.edtEinsatzplatzNr.TabIndex = 12;
            // 
            // lblEinsatzplatzNr
            // 
            this.lblEinsatzplatzNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinsatzplatzNr.Location = new System.Drawing.Point(482, 200);
            this.lblEinsatzplatzNr.Name = "lblEinsatzplatzNr";
            this.lblEinsatzplatzNr.Size = new System.Drawing.Size(22, 24);
            this.lblEinsatzplatzNr.TabIndex = 13;
            this.lblEinsatzplatzNr.Text = "Nr.";
            this.lblEinsatzplatzNr.UseCompatibleTextRendering = true;
            // 
            // CtlKaVermittlungBIBIPEinsaetzeBIP
            // 
            this.ActiveSQLQuery = this.qryBIPVorschlag;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(722, 550);
            this.Controls.Add(this.lblEinsatzplatzNr);
            this.Controls.Add(this.edtEinsatzplatzNr);
            this.Controls.Add(this.tabEinsaetze);
            this.Controls.Add(this.edtVerantwortlicherEinsatzplatz);
            this.Controls.Add(this.lblVerantwortlicherEinsatzplatz);
            this.Controls.Add(this.edtKontaktperson);
            this.Controls.Add(this.lbKontaktperson);
            this.Controls.Add(this.edtBetrieb);
            this.Controls.Add(this.lblBetrieb);
            this.Controls.Add(this.btnDetailsEinsatzplatz);
            this.Controls.Add(this.edtEinsatzplatz);
            this.Controls.Add(this.lblEinsatzplatz);
            this.Controls.Add(this.grdVermittlungSiEinsaetze);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaVermittlungBIBIPEinsaetzeBIP";
            this.Size = new System.Drawing.Size(726, 558);
            this.Load += new System.EventHandler(this.CtlKaVermittlungBIBIPEinsaetzeBIP_Load);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVermittlungSiEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIPVorschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlungSiEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerantwortlicherEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlicherEinsatzplatz.Properties)).EndInit();
            this.tabEinsaetze.ResumeLayout(false);
            this.tpgVorschlag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAblehnungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAblehnungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultatDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelResultat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorschlagDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorschlagDatum)).EndInit();
            this.tpgEinsatz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIPEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzende.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzendeDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzende)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht2Erhalten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZwischenbericht2Dok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBericht2Per)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht1Erhalten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZwischenbericht1Dok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBericht1Per)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterschrieben.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbarung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraktikumsvereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitspensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerlaengert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStelleBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNr)).EndInit();
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

        private void CtlKaVermittlungBIBIPEinsaetzeBIP_Load(object sender, EventArgs e)
        {
            btnDetailsEinsatzplatz.Enabled = (DBUtil.UserHasRight("CtlKaVermittlungBIBIPEinsaetzeBIP", "UI") && (MayUpd || MayIns));
        }

        private void btnDetailsEinsatzplatz_Click(object sender, System.EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", qryBIPVorschlag["KaEinsatzplatzID"]);
        }

        private void qryBIPEinsatz_BeforePost(object sender, System.EventArgs e)
        {
            qryBIPVorschlag["Abschluss"] = edtEinsatzende.EditValue;
            qryBIPVorschlag["Arbeitspensum"] = edtPensum.EditValue;
            qryBIPVorschlag["EinsatzBis"] = edtEinsatzBis.EditValue;
            qryBIPVorschlag["EinsatzVon"] = edtEinsatzVon.EditValue;
        }

        private void qryBIPEinsatz_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryBIPVorschlag.RowModified = true;
        }

        private void qryBIPVorschlag_AfterFill(object sender, System.EventArgs e)
        {
            qryBIPVorschlag_PositionChanged(sender, null);
        }

        private void qryBIPVorschlag_AfterPost(object sender, System.EventArgs e)
        {
            if (!qryBIPEinsatz.Post())
                throw new KissCancelException();
        }

        private void qryBIPVorschlag_BeforeDelete(object sender, System.EventArgs e)
        {
            DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz WHERE KaVermittlungVorschlagID = {0}", qryBIPVorschlag["KaVermittlungVorschlagID"]);
        }

        private void qryBIPVorschlag_PositionChanged(object sender, System.EventArgs e)
        {
            if (qryBIPVorschlag.IsEmpty)
            {
                qryBIPEinsatz.Fill(DBNull.Value);
            }
            else
            {
                qryBIPEinsatz.Fill(qryBIPVorschlag["KaVermittlungVorschlagID"]);
            }

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
                    return qryBIPVorschlag["KaVermittlungVorschlagID"];
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
            qryBIPVorschlag.Fill(faLeistungID, Session.User.IsUserKA ? 0 : 1);

            DBUtil.GetFallRights(this.faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);
            qryBIPEinsatz.CanUpdate = qryBIPVorschlag.CanUpdate && DBUtil.UserHasRight("CtlKaVermittlungBIBIPEinsaetzeBIP", "U") && MayUpd;
            qryBIPEinsatz.CanInsert = qryBIPVorschlag.CanInsert && DBUtil.UserHasRight("CtlKaVermittlungBIBIPEinsaetzeBIP", "I") && MayIns;
            qryBIPEinsatz.CanDelete = qryBIPVorschlag.CanDelete && DBUtil.UserHasRight("CtlKaVermittlungBIBIPEinsaetzeBIP", "D") && MayDel;
            qryBIPEinsatz.EnableBoundFields();

            btnDetailsEinsatzplatz.Enabled = !qryBIPVorschlag.IsEmpty &&
                                             ((DBUtil.UserHasRight("CtlKaVermittlungBIBIPEinsaetzeBIP", "U") && MayUpd) ||
                                              (DBUtil.UserHasRight("CtlKaVermittlungBIBIPEinsaetzeBIP", "I") && MayIns) ||
                                              (DBUtil.UserHasRight("CtlKaVermittlungBIBIPEinsaetzeBIP", "D") && MayDel));

            this.colResultat.ColumnEdit = this.grdVermittlungSiEinsaetze.GetLOVLookUpEdit("KaVorschlagResultat");
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
                    qryBIPVorschlag.Find(string.Format("KaVermittlungVorschlagID = {0}", param["KaVermittlungVorschlagID"]));

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
                    KissMsg.ShowInfo("CtlKaVermittlungBIBIPEinsaetzeBIP", "PensumZuGross", "Pensum darf nicht höher sein als 100%!");
                    ((KiSS4.Gui.KissCalcEdit)sender).Focus();
                }
            }
        }

        private void datLeaveEinsatz(object sender, System.EventArgs e)
        {
            if (!CheckDate(edtEinsatzVon, edtEinsatzBis))
            {
                KissMsg.ShowInfo("CtlKaVermittlungBIBIPEinsaetzeBIP", "EinsatzVonVorBis", "'bis' darf nicht vor 'Einsatz von' liegen!");
                ((KiSS4.Gui.KissDateEdit)sender).Focus();
            }
        }

        #endregion

        #endregion
    }
}