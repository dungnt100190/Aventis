using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.BDE
{
    /// <summary>
    /// Control, used for managing BDE Leistungsarten
    /// </summary>
    public class CtlBDELeistungsart : Common.KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _statusText = "Status";

        #endregion

        #region Private Fields

        private bool _dataHasChanged = false;
        private bool _isInRefresh = true;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colArtikelNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswFaktura;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswPIAuftrag;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswProdukt;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswZLE;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colKTRAHV;
        private DevExpress.XtraGrid.Columns.GridColumn colKTRIV;
        private DevExpress.XtraGrid.Columns.GridColumn colKTRNichtberechtigte;
        private DevExpress.XtraGrid.Columns.GridColumn colKTRStandard;
        private DevExpress.XtraGrid.Columns.GridColumn colKlienterfassung;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colLeitungsartTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colSortKey;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtAnzahlCode;
        private KiSS4.Gui.KissTextEdit edtArtikelNr;
        private KiSS4.Gui.KissLookUpEdit edtAuswFaktura;
        private KiSS4.Gui.KissLookUpEdit edtAuswPIAuftrag;
        private KiSS4.Gui.KissLookUpEdit edtAuswProdukt;
        private KiSS4.Gui.KissLookUpEdit edtAuswZLE;
        private KiSS4.Gui.KissTextEditML edtBezeichnung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtKlientErfassungCode;
        private KiSS4.Gui.KissLookUpEdit edtKostenart;
        private KiSS4.Gui.KissTextEdit edtKostentraeger;
        private KiSS4.Gui.KissTextEdit edtKostentraegerAHV;
        private KiSS4.Gui.KissTextEdit edtKostentraegerIV;
        private KiSS4.Gui.KissTextEdit edtKostentraegerNichtberechtigte;
        private KiSS4.Gui.KissLookUpEdit edtLeistungsartTyp;
        private KiSS4.Gui.KissCalcEdit edtSortKey;
        private KiSS4.Gui.KissLookUpEdit edtSucheAnzahl;
        private KiSS4.Gui.KissTextEdit edtSucheBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtSucheKlienterfassung;
        private KiSS4.Gui.KissLookUpEdit edtSucheTyp;
        private KiSS4.Gui.KissGrid grdBDELeistungsart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDELeistungsart;
        private KiSS4.Gui.KissLabel lblAHV;
        private KiSS4.Gui.KissLabel lblAnzahl;
        private KiSS4.Gui.KissLabel lblArtikelNr;
        private KiSS4.Gui.KissLabel lblAuswFaktura;
        private KiSS4.Gui.KissLabel lblAuswPIAuftrag;
        private KiSS4.Gui.KissLabel lblAuswProdukt;
        private KiSS4.Gui.KissLabel lblAuswZLE;
        private KiSS4.Gui.KissLabel lblBeschreibung;
        private KiSS4.Gui.KissLabel lblBezeichnung;
        private KiSS4.Gui.KissLabel lblGueltigBis;
        private KiSS4.Gui.KissLabel lblGueltigVon;
        private KiSS4.Gui.KissLabel lblIV;
        private KiSS4.Gui.KissLabel lblKlienterfassung;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissLabel lblKostentraeger;
        private KiSS4.Gui.KissLabel lblLeistungsartTyp;
        private KiSS4.Gui.KissLabel lblNichtberechtigte;
        private KiSS4.Gui.KissLabel lblReihenfolge;
        private KiSS4.Gui.KissLabel lblStandard;
        private KissLabel lblStatusBar;
        private KiSS4.Gui.KissLabel lblSucheAnzahl;
        private KiSS4.Gui.KissLabel lblSucheBezeichnung;
        private KiSS4.Gui.KissLabel lblSucheKlienterfassung;
        private KiSS4.Gui.KissLabel lblSucheTyp;
        private KiSS4.Gui.KissMemoEdit memBeschreibung;
        private Panel panBottom;
        private KiSS4.DB.SqlQuery qryData;
        private KiSS4.Gui.KissTabControlEx tabDetails;
        private SharpLibrary.WinControls.TabPageEx tpgGeneral;
        private SharpLibrary.WinControls.TabPageEx tpgQueryGroups;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBDELeistungsart"/> class.
        /// </summary>
        public CtlBDELeistungsart()
        {
            InitializeComponent();

            _statusText = KissMsg.GetMLMessage(Name, "StatusText", "Status");
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBDELeistungsart));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.tabDetails = new KiSS4.Gui.KissTabControlEx();
            this.tpgQueryGroups = new SharpLibrary.WinControls.TabPageEx();
            this.edtAuswPIAuftrag = new KiSS4.Gui.KissLookUpEdit();
            this.qryData = new KiSS4.DB.SqlQuery();
            this.lblAuswPIAuftrag = new KiSS4.Gui.KissLabel();
            this.edtAuswProdukt = new KiSS4.Gui.KissLookUpEdit();
            this.lblAuswProdukt = new KiSS4.Gui.KissLabel();
            this.edtAuswFaktura = new KiSS4.Gui.KissLookUpEdit();
            this.lblAuswFaktura = new KiSS4.Gui.KissLabel();
            this.edtAuswZLE = new KiSS4.Gui.KissLookUpEdit();
            this.lblAuswZLE = new KiSS4.Gui.KissLabel();
            this.tpgGeneral = new SharpLibrary.WinControls.TabPageEx();
            this.memBeschreibung = new KiSS4.Gui.KissMemoEdit();
            this.lblBeschreibung = new KiSS4.Gui.KissLabel();
            this.edtKostentraegerNichtberechtigte = new KiSS4.Gui.KissTextEdit();
            this.lblNichtberechtigte = new KiSS4.Gui.KissLabel();
            this.edtKostentraegerAHV = new KiSS4.Gui.KissTextEdit();
            this.lblAHV = new KiSS4.Gui.KissLabel();
            this.edtKostentraegerIV = new KiSS4.Gui.KissTextEdit();
            this.lblIV = new KiSS4.Gui.KissLabel();
            this.edtKostentraeger = new KiSS4.Gui.KissTextEdit();
            this.lblStandard = new KiSS4.Gui.KissLabel();
            this.lblKostentraeger = new KiSS4.Gui.KissLabel();
            this.edtKostenart = new KiSS4.Gui.KissLookUpEdit();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.edtLeistungsartTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblLeistungsartTyp = new KiSS4.Gui.KissLabel();
            this.edtArtikelNr = new KiSS4.Gui.KissTextEdit();
            this.lblArtikelNr = new KiSS4.Gui.KissLabel();
            this.edtAnzahlCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAnzahl = new KiSS4.Gui.KissLabel();
            this.edtKlientErfassungCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKlienterfassung = new KiSS4.Gui.KissLabel();
            this.edtSortKey = new KiSS4.Gui.KissCalcEdit();
            this.lblReihenfolge = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblGueltigVon = new KiSS4.Gui.KissLabel();
            this.edtBezeichnung = new KiSS4.Gui.KissTextEditML();
            this.lblBezeichnung = new KiSS4.Gui.KissLabel();
            this.grdBDELeistungsart = new KiSS4.Gui.KissGrid();
            this.grvBDELeistungsart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlienterfassung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArtikelNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeitungsartTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKTRStandard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKTRIV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKTRAHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKTRNichtberechtigte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswZLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswFaktura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswProdukt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswPIAuftrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheBezeichnung = new KiSS4.Gui.KissLabel();
            this.edtSucheBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.lblSucheKlienterfassung = new KiSS4.Gui.KissLabel();
            this.edtSucheKlienterfassung = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheAnzahl = new KiSS4.Gui.KissLabel();
            this.edtSucheAnzahl = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheTyp = new KiSS4.Gui.KissLabel();
            this.edtSucheTyp = new KiSS4.Gui.KissLookUpEdit();
            this.panBottom = new System.Windows.Forms.Panel();
            this.lblStatusBar = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tpgQueryGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswPIAuftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswPIAuftrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswPIAuftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswProdukt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswProdukt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswProdukt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswFaktura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswFaktura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswFaktura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZLE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswZLE)).BeginInit();
            this.tpgGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memBeschreibung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraegerNichtberechtigte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNichtberechtigte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraegerAHV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraegerIV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostentraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsartTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArtikelNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArtikelNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientErfassungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientErfassungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlienterfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReihenfolge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDELeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDELeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlienterfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlienterfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlienterfassung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAnzahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAnzahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAnzahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp.Properties)).BeginInit();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(876, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(900, 289);
            this.tabControlSearch.TabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBDELeistungsart);
            this.tpgListe.Size = new System.Drawing.Size(888, 251);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheTyp);
            this.tpgSuchen.Controls.Add(this.lblSucheTyp);
            this.tpgSuchen.Controls.Add(this.edtSucheAnzahl);
            this.tpgSuchen.Controls.Add(this.lblSucheAnzahl);
            this.tpgSuchen.Controls.Add(this.edtSucheKlienterfassung);
            this.tpgSuchen.Controls.Add(this.lblSucheKlienterfassung);
            this.tpgSuchen.Controls.Add(this.edtSucheBezeichnung);
            this.tpgSuchen.Controls.Add(this.lblSucheBezeichnung);
            this.tpgSuchen.Size = new System.Drawing.Size(888, 251);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKlienterfassung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlienterfassung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAnzahl, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAnzahl, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTyp, 0);
            //
            // tabDetails
            //
            this.tabDetails.Controls.Add(this.tpgQueryGroups);
            this.tabDetails.Controls.Add(this.tpgGeneral);
            this.tabDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabDetails.Location = new System.Drawing.Point(0, 289);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.ShowFixedWidthTooltip = true;
            this.tabDetails.Size = new System.Drawing.Size(900, 293);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgGeneral,
            this.tpgQueryGroups});
            this.tabDetails.TabsLineColor = System.Drawing.Color.Black;
            this.tabDetails.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            //
            // tpgQueryGroups
            //
            this.tpgQueryGroups.Controls.Add(this.edtAuswPIAuftrag);
            this.tpgQueryGroups.Controls.Add(this.lblAuswPIAuftrag);
            this.tpgQueryGroups.Controls.Add(this.edtAuswProdukt);
            this.tpgQueryGroups.Controls.Add(this.lblAuswProdukt);
            this.tpgQueryGroups.Controls.Add(this.edtAuswFaktura);
            this.tpgQueryGroups.Controls.Add(this.lblAuswFaktura);
            this.tpgQueryGroups.Controls.Add(this.edtAuswZLE);
            this.tpgQueryGroups.Controls.Add(this.lblAuswZLE);
            this.tpgQueryGroups.Location = new System.Drawing.Point(6, 6);
            this.tpgQueryGroups.Name = "tpgQueryGroups";
            this.tpgQueryGroups.Padding = new System.Windows.Forms.Padding(6);
            this.tpgQueryGroups.Size = new System.Drawing.Size(888, 255);
            this.tpgQueryGroups.TabIndex = 1;
            this.tpgQueryGroups.Title = "Auswertungen";
            //
            // edtAuswPIAuftrag
            //
            this.edtAuswPIAuftrag.DataMember = "AuswPIAuftragCode";
            this.edtAuswPIAuftrag.DataSource = this.qryData;
            this.edtAuswPIAuftrag.Location = new System.Drawing.Point(98, 99);
            this.edtAuswPIAuftrag.LOVName = "BDELeistungsartAuswPIAuftrag";
            this.edtAuswPIAuftrag.Name = "edtAuswPIAuftrag";
            this.edtAuswPIAuftrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswPIAuftrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswPIAuftrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswPIAuftrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswPIAuftrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswPIAuftrag.Properties.Appearance.Options.UseFont = true;
            this.edtAuswPIAuftrag.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswPIAuftrag.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswPIAuftrag.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswPIAuftrag.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswPIAuftrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtAuswPIAuftrag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtAuswPIAuftrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswPIAuftrag.Properties.NullText = "";
            this.edtAuswPIAuftrag.Properties.ShowFooter = false;
            this.edtAuswPIAuftrag.Properties.ShowHeader = false;
            this.edtAuswPIAuftrag.Size = new System.Drawing.Size(232, 24);
            this.edtAuswPIAuftrag.TabIndex = 7;
            //
            // qryData
            //
            this.qryData.CanDelete = true;
            this.qryData.CanInsert = true;
            this.qryData.CanUpdate = true;
            this.qryData.HostControl = this;
            this.qryData.RowModified = true;
            this.qryData.TableName = "BDELeistungsart";
            this.qryData.AfterInsert += new System.EventHandler(this.qryData_AfterInsert);
            this.qryData.BeforePost += new System.EventHandler(this.qryData_BeforePost);
            this.qryData.AfterPost += new System.EventHandler(this.qryData_AfterPost);
            this.qryData.PositionChanging += new System.EventHandler(this.qryData_PositionChanging);
            this.qryData.PositionChanged += new System.EventHandler(this.qryData_PositionChanged);
            //
            // lblAuswPIAuftrag
            //
            this.lblAuswPIAuftrag.Location = new System.Drawing.Point(9, 99);
            this.lblAuswPIAuftrag.Name = "lblAuswPIAuftrag";
            this.lblAuswPIAuftrag.Size = new System.Drawing.Size(83, 24);
            this.lblAuswPIAuftrag.TabIndex = 6;
            this.lblAuswPIAuftrag.Text = "PI-Auftrag";
            this.lblAuswPIAuftrag.UseCompatibleTextRendering = true;
            //
            // edtAuswProdukt
            //
            this.edtAuswProdukt.DataMember = "AuswProduktCode";
            this.edtAuswProdukt.DataSource = this.qryData;
            this.edtAuswProdukt.Location = new System.Drawing.Point(98, 69);
            this.edtAuswProdukt.LOVName = "BDELeistungsartAuswProdukt";
            this.edtAuswProdukt.Name = "edtAuswProdukt";
            this.edtAuswProdukt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswProdukt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswProdukt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswProdukt.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswProdukt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswProdukt.Properties.Appearance.Options.UseFont = true;
            this.edtAuswProdukt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswProdukt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswProdukt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswProdukt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswProdukt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAuswProdukt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAuswProdukt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswProdukt.Properties.NullText = "";
            this.edtAuswProdukt.Properties.ShowFooter = false;
            this.edtAuswProdukt.Properties.ShowHeader = false;
            this.edtAuswProdukt.Size = new System.Drawing.Size(232, 24);
            this.edtAuswProdukt.TabIndex = 5;
            //
            // lblAuswProdukt
            //
            this.lblAuswProdukt.Location = new System.Drawing.Point(9, 69);
            this.lblAuswProdukt.Name = "lblAuswProdukt";
            this.lblAuswProdukt.Size = new System.Drawing.Size(83, 24);
            this.lblAuswProdukt.TabIndex = 4;
            this.lblAuswProdukt.Text = "Produkt";
            this.lblAuswProdukt.UseCompatibleTextRendering = true;
            //
            // edtAuswFaktura
            //
            this.edtAuswFaktura.DataMember = "AuswFakturaCode";
            this.edtAuswFaktura.DataSource = this.qryData;
            this.edtAuswFaktura.Location = new System.Drawing.Point(98, 39);
            this.edtAuswFaktura.LOVName = "BDELeistungsartAuswFaktura";
            this.edtAuswFaktura.Name = "edtAuswFaktura";
            this.edtAuswFaktura.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswFaktura.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswFaktura.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswFaktura.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswFaktura.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswFaktura.Properties.Appearance.Options.UseFont = true;
            this.edtAuswFaktura.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswFaktura.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswFaktura.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswFaktura.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswFaktura.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAuswFaktura.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAuswFaktura.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswFaktura.Properties.NullText = "";
            this.edtAuswFaktura.Properties.ShowFooter = false;
            this.edtAuswFaktura.Properties.ShowHeader = false;
            this.edtAuswFaktura.Size = new System.Drawing.Size(232, 24);
            this.edtAuswFaktura.TabIndex = 3;
            //
            // lblAuswFaktura
            //
            this.lblAuswFaktura.Location = new System.Drawing.Point(9, 39);
            this.lblAuswFaktura.Name = "lblAuswFaktura";
            this.lblAuswFaktura.Size = new System.Drawing.Size(83, 24);
            this.lblAuswFaktura.TabIndex = 2;
            this.lblAuswFaktura.Text = "Faktura";
            this.lblAuswFaktura.UseCompatibleTextRendering = true;
            //
            // edtAuswZLE
            //
            this.edtAuswZLE.DataMember = "AuswDienstleistungCode";
            this.edtAuswZLE.DataSource = this.qryData;
            this.edtAuswZLE.Location = new System.Drawing.Point(98, 9);
            this.edtAuswZLE.LOVName = "BDELeistungsartAuswDienstleistung";
            this.edtAuswZLE.Name = "edtAuswZLE";
            this.edtAuswZLE.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswZLE.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswZLE.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswZLE.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswZLE.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswZLE.Properties.Appearance.Options.UseFont = true;
            this.edtAuswZLE.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswZLE.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswZLE.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswZLE.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswZLE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAuswZLE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAuswZLE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswZLE.Properties.NullText = "";
            this.edtAuswZLE.Properties.ShowFooter = false;
            this.edtAuswZLE.Properties.ShowHeader = false;
            this.edtAuswZLE.Size = new System.Drawing.Size(232, 24);
            this.edtAuswZLE.TabIndex = 1;
            //
            // lblAuswZLE
            //
            this.lblAuswZLE.Location = new System.Drawing.Point(9, 9);
            this.lblAuswZLE.Name = "lblAuswZLE";
            this.lblAuswZLE.Size = new System.Drawing.Size(83, 24);
            this.lblAuswZLE.TabIndex = 0;
            this.lblAuswZLE.Text = "ZLE";
            this.lblAuswZLE.UseCompatibleTextRendering = true;
            //
            // tpgGeneral
            //
            this.tpgGeneral.Controls.Add(this.memBeschreibung);
            this.tpgGeneral.Controls.Add(this.lblBeschreibung);
            this.tpgGeneral.Controls.Add(this.edtKostentraegerNichtberechtigte);
            this.tpgGeneral.Controls.Add(this.lblNichtberechtigte);
            this.tpgGeneral.Controls.Add(this.edtKostentraegerAHV);
            this.tpgGeneral.Controls.Add(this.lblAHV);
            this.tpgGeneral.Controls.Add(this.edtKostentraegerIV);
            this.tpgGeneral.Controls.Add(this.lblIV);
            this.tpgGeneral.Controls.Add(this.edtKostentraeger);
            this.tpgGeneral.Controls.Add(this.lblStandard);
            this.tpgGeneral.Controls.Add(this.lblKostentraeger);
            this.tpgGeneral.Controls.Add(this.edtKostenart);
            this.tpgGeneral.Controls.Add(this.lblKostenart);
            this.tpgGeneral.Controls.Add(this.edtLeistungsartTyp);
            this.tpgGeneral.Controls.Add(this.lblLeistungsartTyp);
            this.tpgGeneral.Controls.Add(this.edtArtikelNr);
            this.tpgGeneral.Controls.Add(this.lblArtikelNr);
            this.tpgGeneral.Controls.Add(this.edtAnzahlCode);
            this.tpgGeneral.Controls.Add(this.lblAnzahl);
            this.tpgGeneral.Controls.Add(this.edtKlientErfassungCode);
            this.tpgGeneral.Controls.Add(this.lblKlienterfassung);
            this.tpgGeneral.Controls.Add(this.edtSortKey);
            this.tpgGeneral.Controls.Add(this.lblReihenfolge);
            this.tpgGeneral.Controls.Add(this.edtDatumBis);
            this.tpgGeneral.Controls.Add(this.lblGueltigBis);
            this.tpgGeneral.Controls.Add(this.edtDatumVon);
            this.tpgGeneral.Controls.Add(this.lblGueltigVon);
            this.tpgGeneral.Controls.Add(this.edtBezeichnung);
            this.tpgGeneral.Controls.Add(this.lblBezeichnung);
            this.tpgGeneral.Location = new System.Drawing.Point(6, 6);
            this.tpgGeneral.Name = "tpgGeneral";
            this.tpgGeneral.Padding = new System.Windows.Forms.Padding(6);
            this.tpgGeneral.Size = new System.Drawing.Size(888, 255);
            this.tpgGeneral.TabIndex = 0;
            this.tpgGeneral.Title = "Allgemein";
            //
            // memBeschreibung
            //
            this.memBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBeschreibung.DataMember = "Beschreibung";
            this.memBeschreibung.DataSource = this.qryData;
            this.memBeschreibung.Location = new System.Drawing.Point(103, 219);
            this.memBeschreibung.Name = "memBeschreibung";
            this.memBeschreibung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBeschreibung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBeschreibung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBeschreibung.Properties.Appearance.Options.UseBackColor = true;
            this.memBeschreibung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBeschreibung.Properties.Appearance.Options.UseFont = true;
            this.memBeschreibung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBeschreibung.Properties.MaxLength = 1000;
            this.memBeschreibung.Size = new System.Drawing.Size(776, 36);
            this.memBeschreibung.TabIndex = 28;
            //
            // lblBeschreibung
            //
            this.lblBeschreibung.Location = new System.Drawing.Point(9, 219);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(88, 24);
            this.lblBeschreibung.TabIndex = 27;
            this.lblBeschreibung.Text = "Beschreibung";
            this.lblBeschreibung.UseCompatibleTextRendering = true;
            //
            // edtKostentraegerNichtberechtigte
            //
            this.edtKostentraegerNichtberechtigte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKostentraegerNichtberechtigte.DataMember = "KTRNichtberechtigte";
            this.edtKostentraegerNichtberechtigte.DataSource = this.qryData;
            this.edtKostentraegerNichtberechtigte.Location = new System.Drawing.Point(729, 159);
            this.edtKostentraegerNichtberechtigte.Name = "edtKostentraegerNichtberechtigte";
            this.edtKostentraegerNichtberechtigte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostentraegerNichtberechtigte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostentraegerNichtberechtigte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostentraegerNichtberechtigte.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostentraegerNichtberechtigte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostentraegerNichtberechtigte.Properties.Appearance.Options.UseFont = true;
            this.edtKostentraegerNichtberechtigte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostentraegerNichtberechtigte.Size = new System.Drawing.Size(150, 24);
            this.edtKostentraegerNichtberechtigte.TabIndex = 26;
            //
            // lblNichtberechtigte
            //
            this.lblNichtberechtigte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNichtberechtigte.Location = new System.Drawing.Point(622, 159);
            this.lblNichtberechtigte.Name = "lblNichtberechtigte";
            this.lblNichtberechtigte.Size = new System.Drawing.Size(101, 24);
            this.lblNichtberechtigte.TabIndex = 25;
            this.lblNichtberechtigte.Text = "Nichtberechtigte";
            this.lblNichtberechtigte.UseCompatibleTextRendering = true;
            //
            // edtKostentraegerAHV
            //
            this.edtKostentraegerAHV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKostentraegerAHV.DataMember = "KTRAHV";
            this.edtKostentraegerAHV.DataSource = this.qryData;
            this.edtKostentraegerAHV.Location = new System.Drawing.Point(729, 129);
            this.edtKostentraegerAHV.Name = "edtKostentraegerAHV";
            this.edtKostentraegerAHV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostentraegerAHV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostentraegerAHV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostentraegerAHV.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostentraegerAHV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostentraegerAHV.Properties.Appearance.Options.UseFont = true;
            this.edtKostentraegerAHV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostentraegerAHV.Size = new System.Drawing.Size(150, 24);
            this.edtKostentraegerAHV.TabIndex = 24;
            //
            // lblAHV
            //
            this.lblAHV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAHV.Location = new System.Drawing.Point(622, 129);
            this.lblAHV.Name = "lblAHV";
            this.lblAHV.Size = new System.Drawing.Size(101, 24);
            this.lblAHV.TabIndex = 23;
            this.lblAHV.Text = "AHV";
            this.lblAHV.UseCompatibleTextRendering = true;
            //
            // edtKostentraegerIV
            //
            this.edtKostentraegerIV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKostentraegerIV.DataMember = "KTRIV";
            this.edtKostentraegerIV.DataSource = this.qryData;
            this.edtKostentraegerIV.Location = new System.Drawing.Point(729, 99);
            this.edtKostentraegerIV.Name = "edtKostentraegerIV";
            this.edtKostentraegerIV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostentraegerIV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostentraegerIV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostentraegerIV.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostentraegerIV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostentraegerIV.Properties.Appearance.Options.UseFont = true;
            this.edtKostentraegerIV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostentraegerIV.Size = new System.Drawing.Size(150, 24);
            this.edtKostentraegerIV.TabIndex = 22;
            //
            // lblIV
            //
            this.lblIV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIV.Location = new System.Drawing.Point(622, 99);
            this.lblIV.Name = "lblIV";
            this.lblIV.Size = new System.Drawing.Size(101, 24);
            this.lblIV.TabIndex = 21;
            this.lblIV.Text = "IV";
            this.lblIV.UseCompatibleTextRendering = true;
            //
            // edtKostentraeger
            //
            this.edtKostentraeger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKostentraeger.DataMember = "KTRStandard";
            this.edtKostentraeger.DataSource = this.qryData;
            this.edtKostentraeger.Location = new System.Drawing.Point(729, 69);
            this.edtKostentraeger.Name = "edtKostentraeger";
            this.edtKostentraeger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostentraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostentraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostentraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostentraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostentraeger.Properties.Appearance.Options.UseFont = true;
            this.edtKostentraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostentraeger.Size = new System.Drawing.Size(150, 24);
            this.edtKostentraeger.TabIndex = 20;
            //
            // lblStandard
            //
            this.lblStandard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStandard.Location = new System.Drawing.Point(622, 69);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(101, 24);
            this.lblStandard.TabIndex = 19;
            this.lblStandard.Text = "Standard";
            this.lblStandard.UseCompatibleTextRendering = true;
            //
            // lblKostentraeger
            //
            this.lblKostentraeger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKostentraeger.Location = new System.Drawing.Point(528, 69);
            this.lblKostentraeger.Name = "lblKostentraeger";
            this.lblKostentraeger.Size = new System.Drawing.Size(88, 24);
            this.lblKostentraeger.TabIndex = 18;
            this.lblKostentraeger.Text = "Kostenträger";
            this.lblKostentraeger.UseCompatibleTextRendering = true;
            //
            // edtKostenart
            //
            this.edtKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKostenart.DataMember = "KostenartCode";
            this.edtKostenart.DataSource = this.qryData;
            this.edtKostenart.Location = new System.Drawing.Point(622, 39);
            this.edtKostenart.LOVName = "BDEKostenart";
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKostenart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKostenart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.Properties.NullText = "";
            this.edtKostenart.Properties.ShowFooter = false;
            this.edtKostenart.Properties.ShowHeader = false;
            this.edtKostenart.Size = new System.Drawing.Size(257, 24);
            this.edtKostenart.TabIndex = 17;
            //
            // lblKostenart
            //
            this.lblKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKostenart.Location = new System.Drawing.Point(528, 39);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(88, 24);
            this.lblKostenart.TabIndex = 16;
            this.lblKostenart.Text = "Kostenart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            //
            // edtLeistungsartTyp
            //
            this.edtLeistungsartTyp.AllowNull = false;
            this.edtLeistungsartTyp.DataMember = "LeistungsartTypCode";
            this.edtLeistungsartTyp.DataSource = this.qryData;
            this.edtLeistungsartTyp.Location = new System.Drawing.Point(103, 189);
            this.edtLeistungsartTyp.LOVName = "BDELeistungsartTyp";
            this.edtLeistungsartTyp.Name = "edtLeistungsartTyp";
            this.edtLeistungsartTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeistungsartTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistungsartTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistungsartTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeistungsartTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeistungsartTyp.Properties.Appearance.Options.UseFont = true;
            this.edtLeistungsartTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLeistungsartTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistungsartTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLeistungsartTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLeistungsartTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtLeistungsartTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtLeistungsartTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeistungsartTyp.Properties.NullText = "";
            this.edtLeistungsartTyp.Properties.ShowFooter = false;
            this.edtLeistungsartTyp.Properties.ShowHeader = false;
            this.edtLeistungsartTyp.Size = new System.Drawing.Size(225, 24);
            this.edtLeistungsartTyp.TabIndex = 15;
            //
            // lblLeistungsartTyp
            //
            this.lblLeistungsartTyp.Location = new System.Drawing.Point(9, 189);
            this.lblLeistungsartTyp.Name = "lblLeistungsartTyp";
            this.lblLeistungsartTyp.Size = new System.Drawing.Size(88, 24);
            this.lblLeistungsartTyp.TabIndex = 14;
            this.lblLeistungsartTyp.Text = "Typ";
            this.lblLeistungsartTyp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeistungsartTyp.UseCompatibleTextRendering = true;
            //
            // edtArtikelNr
            //
            this.edtArtikelNr.DataMember = "ArtikelNr";
            this.edtArtikelNr.DataSource = this.qryData;
            this.edtArtikelNr.Location = new System.Drawing.Point(103, 159);
            this.edtArtikelNr.Name = "edtArtikelNr";
            this.edtArtikelNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArtikelNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArtikelNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArtikelNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtArtikelNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArtikelNr.Properties.Appearance.Options.UseFont = true;
            this.edtArtikelNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArtikelNr.Size = new System.Drawing.Size(225, 24);
            this.edtArtikelNr.TabIndex = 13;
            //
            // lblArtikelNr
            //
            this.lblArtikelNr.Location = new System.Drawing.Point(9, 159);
            this.lblArtikelNr.Name = "lblArtikelNr";
            this.lblArtikelNr.Size = new System.Drawing.Size(88, 24);
            this.lblArtikelNr.TabIndex = 12;
            this.lblArtikelNr.Text = "Artikel-Nr.";
            this.lblArtikelNr.UseCompatibleTextRendering = true;
            //
            // edtAnzahlCode
            //
            this.edtAnzahlCode.AllowNull = false;
            this.edtAnzahlCode.DataMember = "AnzahlCode";
            this.edtAnzahlCode.DataSource = this.qryData;
            this.edtAnzahlCode.Location = new System.Drawing.Point(103, 129);
            this.edtAnzahlCode.LOVName = "BDEKlientErfassung";
            this.edtAnzahlCode.Name = "edtAnzahlCode";
            this.edtAnzahlCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnzahlCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlCode.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAnzahlCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAnzahlCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAnzahlCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAnzahlCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAnzahlCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlCode.Properties.NullText = "";
            this.edtAnzahlCode.Properties.ShowFooter = false;
            this.edtAnzahlCode.Properties.ShowHeader = false;
            this.edtAnzahlCode.Size = new System.Drawing.Size(225, 24);
            this.edtAnzahlCode.TabIndex = 11;
            //
            // lblAnzahl
            //
            this.lblAnzahl.Location = new System.Drawing.Point(9, 129);
            this.lblAnzahl.Name = "lblAnzahl";
            this.lblAnzahl.Size = new System.Drawing.Size(88, 24);
            this.lblAnzahl.TabIndex = 10;
            this.lblAnzahl.Text = "Anzahl";
            this.lblAnzahl.UseCompatibleTextRendering = true;
            //
            // edtKlientErfassungCode
            //
            this.edtKlientErfassungCode.AllowNull = false;
            this.edtKlientErfassungCode.DataMember = "KlientErfassungCode";
            this.edtKlientErfassungCode.DataSource = this.qryData;
            this.edtKlientErfassungCode.Location = new System.Drawing.Point(103, 99);
            this.edtKlientErfassungCode.LOVName = "BDEKlientErfassung";
            this.edtKlientErfassungCode.Name = "edtKlientErfassungCode";
            this.edtKlientErfassungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlientErfassungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientErfassungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientErfassungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientErfassungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientErfassungCode.Properties.Appearance.Options.UseFont = true;
            this.edtKlientErfassungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKlientErfassungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientErfassungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKlientErfassungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKlientErfassungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtKlientErfassungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtKlientErfassungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlientErfassungCode.Properties.NullText = "";
            this.edtKlientErfassungCode.Properties.ShowFooter = false;
            this.edtKlientErfassungCode.Properties.ShowHeader = false;
            this.edtKlientErfassungCode.Size = new System.Drawing.Size(225, 24);
            this.edtKlientErfassungCode.TabIndex = 9;
            //
            // lblKlienterfassung
            //
            this.lblKlienterfassung.Location = new System.Drawing.Point(9, 99);
            this.lblKlienterfassung.Name = "lblKlienterfassung";
            this.lblKlienterfassung.Size = new System.Drawing.Size(88, 24);
            this.lblKlienterfassung.TabIndex = 8;
            this.lblKlienterfassung.Text = "Klienterfassung";
            this.lblKlienterfassung.UseCompatibleTextRendering = true;
            //
            // edtSortKey
            //
            this.edtSortKey.DataMember = "SortKey";
            this.edtSortKey.DataSource = this.qryData;
            this.edtSortKey.Location = new System.Drawing.Point(103, 69);
            this.edtSortKey.Name = "edtSortKey";
            this.edtSortKey.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseFont = true;
            this.edtSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSortKey.Size = new System.Drawing.Size(95, 24);
            this.edtSortKey.TabIndex = 7;
            //
            // lblReihenfolge
            //
            this.lblReihenfolge.Location = new System.Drawing.Point(9, 69);
            this.lblReihenfolge.Name = "lblReihenfolge";
            this.lblReihenfolge.Size = new System.Drawing.Size(88, 24);
            this.lblReihenfolge.TabIndex = 6;
            this.lblReihenfolge.Text = "Reihenfolge";
            this.lblReihenfolge.UseCompatibleTextRendering = true;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryData;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(233, 39);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(95, 24);
            this.edtDatumBis.TabIndex = 5;
            //
            // lblGueltigBis
            //
            this.lblGueltigBis.Location = new System.Drawing.Point(204, 39);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(23, 24);
            this.lblGueltigBis.TabIndex = 4;
            this.lblGueltigBis.Text = "bis";
            this.lblGueltigBis.UseCompatibleTextRendering = true;
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryData;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(103, 39);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(95, 24);
            this.edtDatumVon.TabIndex = 3;
            //
            // lblGueltigVon
            //
            this.lblGueltigVon.Location = new System.Drawing.Point(9, 39);
            this.lblGueltigVon.Name = "lblGueltigVon";
            this.lblGueltigVon.Size = new System.Drawing.Size(88, 24);
            this.lblGueltigVon.TabIndex = 2;
            this.lblGueltigVon.Text = "Gültig von";
            this.lblGueltigVon.UseCompatibleTextRendering = true;
            //
            // edtBezeichnung
            //
            this.edtBezeichnung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBezeichnung.ApplyChangesToDefaultText = false;
            this.edtBezeichnung.DataMember = null;
            this.edtBezeichnung.DataMemberDefaultText = "Bezeichnung";
            this.edtBezeichnung.DataMemberTID = "BezeichnungTID";
            this.edtBezeichnung.DataSource = this.qryData;
            this.edtBezeichnung.Location = new System.Drawing.Point(103, 9);
            this.edtBezeichnung.Name = "edtBezeichnung";
            this.edtBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBezeichnung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtBezeichnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezeichnung.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtBezeichnung.ShowOnlyDefaultLanguage = true;
            this.edtBezeichnung.Size = new System.Drawing.Size(776, 24);
            this.edtBezeichnung.TabIndex = 1;
            this.edtBezeichnung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBezeichnung_UserModifiedFld);
            //
            // lblBezeichnung
            //
            this.lblBezeichnung.Location = new System.Drawing.Point(9, 9);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(88, 24);
            this.lblBezeichnung.TabIndex = 0;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.UseCompatibleTextRendering = true;
            //
            // grdBDELeistungsart
            //
            this.grdBDELeistungsart.DataSource = this.qryData;
            this.grdBDELeistungsart.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdBDELeistungsart.EmbeddedNavigator.Name = "";
            this.grdBDELeistungsart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDELeistungsart.Location = new System.Drawing.Point(0, 0);
            this.grdBDELeistungsart.MainView = this.grvBDELeistungsart;
            this.grdBDELeistungsart.Name = "grdBDELeistungsart";
            this.grdBDELeistungsart.Size = new System.Drawing.Size(888, 251);
            this.grdBDELeistungsart.TabIndex = 0;
            this.grdBDELeistungsart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDELeistungsart});
            //
            // grvBDELeistungsart
            //
            this.grvBDELeistungsart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDELeistungsart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.Empty.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDELeistungsart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDELeistungsart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDELeistungsart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDELeistungsart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDELeistungsart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDELeistungsart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDELeistungsart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDELeistungsart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDELeistungsart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDELeistungsart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDELeistungsart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDELeistungsart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDELeistungsart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDELeistungsart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDELeistungsart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDELeistungsart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDELeistungsart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDELeistungsart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDELeistungsart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.OddRow.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDELeistungsart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.Row.Options.UseBackColor = true;
            this.grvBDELeistungsart.Appearance.Row.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDELeistungsart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDELeistungsart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDELeistungsart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDELeistungsart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDELeistungsart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBezeichnung,
            this.colSortKey,
            this.colKlienterfassung,
            this.colAnzahl,
            this.colArtikelNr,
            this.colLeitungsartTyp,
            this.colKostenart,
            this.colKTRStandard,
            this.colKTRIV,
            this.colKTRAHV,
            this.colKTRNichtberechtigte,
            this.colDatumVon,
            this.colDatumBis,
            this.colAuswZLE,
            this.colAuswFaktura,
            this.colAuswProdukt,
            this.colAuswPIAuftrag});
            this.grvBDELeistungsart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDELeistungsart.GridControl = this.grdBDELeistungsart;
            this.grvBDELeistungsart.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBDELeistungsart.Name = "grvBDELeistungsart";
            this.grvBDELeistungsart.OptionsBehavior.Editable = false;
            this.grvBDELeistungsart.OptionsCustomization.AllowFilter = false;
            this.grvBDELeistungsart.OptionsFilter.AllowFilterEditor = false;
            this.grvBDELeistungsart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDELeistungsart.OptionsMenu.EnableColumnMenu = false;
            this.grvBDELeistungsart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDELeistungsart.OptionsNavigation.UseTabKey = false;
            this.grvBDELeistungsart.OptionsView.ColumnAutoWidth = false;
            this.grvBDELeistungsart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDELeistungsart.OptionsView.ShowGroupPanel = false;
            this.grvBDELeistungsart.OptionsView.ShowIndicator = false;
            //
            // colBezeichnung
            //
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "Bezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 0;
            this.colBezeichnung.Width = 225;
            //
            // colSortKey
            //
            this.colSortKey.Caption = "Reihenf.";
            this.colSortKey.FieldName = "SortKey";
            this.colSortKey.Name = "colSortKey";
            this.colSortKey.Visible = true;
            this.colSortKey.VisibleIndex = 1;
            this.colSortKey.Width = 60;
            //
            // colKlienterfassung
            //
            this.colKlienterfassung.Caption = "Klienterf.";
            this.colKlienterfassung.FieldName = "KlientErfassungCode";
            this.colKlienterfassung.Name = "colKlienterfassung";
            this.colKlienterfassung.Visible = true;
            this.colKlienterfassung.VisibleIndex = 2;
            //
            // colAnzahl
            //
            this.colAnzahl.Caption = "Anzahl";
            this.colAnzahl.FieldName = "AnzahlCode";
            this.colAnzahl.Name = "colAnzahl";
            this.colAnzahl.Visible = true;
            this.colAnzahl.VisibleIndex = 3;
            //
            // colArtikelNr
            //
            this.colArtikelNr.Caption = "Artikel-Nr.";
            this.colArtikelNr.FieldName = "ArtikelNr";
            this.colArtikelNr.Name = "colArtikelNr";
            this.colArtikelNr.Visible = true;
            this.colArtikelNr.VisibleIndex = 4;
            //
            // colLeitungsartTyp
            //
            this.colLeitungsartTyp.Caption = "Typ";
            this.colLeitungsartTyp.FieldName = "LeistungsartTyp";
            this.colLeitungsartTyp.Name = "colLeitungsartTyp";
            this.colLeitungsartTyp.Visible = true;
            this.colLeitungsartTyp.VisibleIndex = 5;
            this.colLeitungsartTyp.Width = 100;
            //
            // colKostenart
            //
            this.colKostenart.Caption = "Kostenart";
            this.colKostenart.FieldName = "Kostenart";
            this.colKostenart.Name = "colKostenart";
            this.colKostenart.Visible = true;
            this.colKostenart.VisibleIndex = 6;
            this.colKostenart.Width = 80;
            //
            // colKTRStandard
            //
            this.colKTRStandard.Caption = "KTR St.";
            this.colKTRStandard.FieldName = "KTRStandard";
            this.colKTRStandard.Name = "colKTRStandard";
            this.colKTRStandard.Visible = true;
            this.colKTRStandard.VisibleIndex = 7;
            this.colKTRStandard.Width = 60;
            //
            // colKTRIV
            //
            this.colKTRIV.Caption = "KTR IV";
            this.colKTRIV.FieldName = "KTRIV";
            this.colKTRIV.Name = "colKTRIV";
            this.colKTRIV.Visible = true;
            this.colKTRIV.VisibleIndex = 8;
            this.colKTRIV.Width = 60;
            //
            // colKTRAHV
            //
            this.colKTRAHV.Caption = "KTR AHV";
            this.colKTRAHV.FieldName = "KTRAHV";
            this.colKTRAHV.Name = "colKTRAHV";
            this.colKTRAHV.Visible = true;
            this.colKTRAHV.VisibleIndex = 9;
            this.colKTRAHV.Width = 60;
            //
            // colKTRNichtberechtigte
            //
            this.colKTRNichtberechtigte.Caption = "KTR Nb.";
            this.colKTRNichtberechtigte.FieldName = "KTRNichtberechtigte";
            this.colKTRNichtberechtigte.Name = "colKTRNichtberechtigte";
            this.colKTRNichtberechtigte.Visible = true;
            this.colKTRNichtberechtigte.VisibleIndex = 10;
            this.colKTRNichtberechtigte.Width = 60;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "gültig von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 11;
            this.colDatumVon.Width = 80;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "gültig bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 12;
            this.colDatumBis.Width = 80;
            //
            // colAuswZLE
            //
            this.colAuswZLE.Caption = "Ausw. ZLE";
            this.colAuswZLE.FieldName = "AuswZLE";
            this.colAuswZLE.Name = "colAuswZLE";
            this.colAuswZLE.Visible = true;
            this.colAuswZLE.VisibleIndex = 13;
            this.colAuswZLE.Width = 120;
            //
            // colAuswFaktura
            //
            this.colAuswFaktura.Caption = "Ausw. Faktura";
            this.colAuswFaktura.FieldName = "AuswFaktura";
            this.colAuswFaktura.Name = "colAuswFaktura";
            this.colAuswFaktura.Visible = true;
            this.colAuswFaktura.VisibleIndex = 14;
            this.colAuswFaktura.Width = 120;
            //
            // colAuswProdukt
            //
            this.colAuswProdukt.Caption = "Ausw. Produkt";
            this.colAuswProdukt.FieldName = "AuswProdukt";
            this.colAuswProdukt.Name = "colAuswProdukt";
            this.colAuswProdukt.Visible = true;
            this.colAuswProdukt.VisibleIndex = 15;
            this.colAuswProdukt.Width = 120;
            //
            // colAuswPIAuftrag
            //
            this.colAuswPIAuftrag.Caption = "Ausw. PI-Auftrag";
            this.colAuswPIAuftrag.FieldName = "AuswPIAuftrag";
            this.colAuswPIAuftrag.Name = "colAuswPIAuftrag";
            this.colAuswPIAuftrag.Visible = true;
            this.colAuswPIAuftrag.VisibleIndex = 16;
            this.colAuswPIAuftrag.Width = 120;
            //
            // lblSucheBezeichnung
            //
            this.lblSucheBezeichnung.Location = new System.Drawing.Point(31, 40);
            this.lblSucheBezeichnung.Name = "lblSucheBezeichnung";
            this.lblSucheBezeichnung.Size = new System.Drawing.Size(88, 24);
            this.lblSucheBezeichnung.TabIndex = 1;
            this.lblSucheBezeichnung.Text = "Bezeichnung";
            this.lblSucheBezeichnung.UseCompatibleTextRendering = true;
            //
            // edtSucheBezeichnung
            //
            this.edtSucheBezeichnung.Location = new System.Drawing.Point(126, 39);
            this.edtSucheBezeichnung.Name = "edtSucheBezeichnung";
            this.edtSucheBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBezeichnung.Size = new System.Drawing.Size(262, 24);
            this.edtSucheBezeichnung.TabIndex = 2;
            //
            // lblSucheKlienterfassung
            //
            this.lblSucheKlienterfassung.Location = new System.Drawing.Point(32, 69);
            this.lblSucheKlienterfassung.Name = "lblSucheKlienterfassung";
            this.lblSucheKlienterfassung.Size = new System.Drawing.Size(88, 24);
            this.lblSucheKlienterfassung.TabIndex = 3;
            this.lblSucheKlienterfassung.Text = "Klienterfassung";
            this.lblSucheKlienterfassung.UseCompatibleTextRendering = true;
            //
            // edtSucheKlienterfassung
            //
            this.edtSucheKlienterfassung.Location = new System.Drawing.Point(126, 69);
            this.edtSucheKlienterfassung.LOVName = "BDEKlientErfassung";
            this.edtSucheKlienterfassung.Name = "edtSucheKlienterfassung";
            this.edtSucheKlienterfassung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlienterfassung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlienterfassung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlienterfassung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlienterfassung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlienterfassung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlienterfassung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKlienterfassung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlienterfassung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKlienterfassung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKlienterfassung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSucheKlienterfassung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSucheKlienterfassung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKlienterfassung.Properties.NullText = "";
            this.edtSucheKlienterfassung.Properties.ShowFooter = false;
            this.edtSucheKlienterfassung.Properties.ShowHeader = false;
            this.edtSucheKlienterfassung.Size = new System.Drawing.Size(262, 24);
            this.edtSucheKlienterfassung.TabIndex = 4;
            //
            // lblSucheAnzahl
            //
            this.lblSucheAnzahl.Location = new System.Drawing.Point(32, 99);
            this.lblSucheAnzahl.Name = "lblSucheAnzahl";
            this.lblSucheAnzahl.Size = new System.Drawing.Size(88, 24);
            this.lblSucheAnzahl.TabIndex = 5;
            this.lblSucheAnzahl.Text = "Anzahl";
            this.lblSucheAnzahl.UseCompatibleTextRendering = true;
            //
            // edtSucheAnzahl
            //
            this.edtSucheAnzahl.Location = new System.Drawing.Point(126, 99);
            this.edtSucheAnzahl.LOVName = "BDEKlientErfassung";
            this.edtSucheAnzahl.Name = "edtSucheAnzahl";
            this.edtSucheAnzahl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAnzahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAnzahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAnzahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAnzahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAnzahl.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAnzahl.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAnzahl.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAnzahl.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAnzahl.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAnzahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheAnzahl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheAnzahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAnzahl.Properties.NullText = "";
            this.edtSucheAnzahl.Properties.ShowFooter = false;
            this.edtSucheAnzahl.Properties.ShowHeader = false;
            this.edtSucheAnzahl.Size = new System.Drawing.Size(262, 24);
            this.edtSucheAnzahl.TabIndex = 6;
            //
            // lblSucheTyp
            //
            this.lblSucheTyp.Location = new System.Drawing.Point(32, 129);
            this.lblSucheTyp.Name = "lblSucheTyp";
            this.lblSucheTyp.Size = new System.Drawing.Size(88, 24);
            this.lblSucheTyp.TabIndex = 7;
            this.lblSucheTyp.Text = "Typ";
            this.lblSucheTyp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSucheTyp.UseCompatibleTextRendering = true;
            //
            // edtSucheTyp
            //
            this.edtSucheTyp.Location = new System.Drawing.Point(126, 129);
            this.edtSucheTyp.LOVName = "BDELeistungsartTyp";
            this.edtSucheTyp.Name = "edtSucheTyp";
            this.edtSucheTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTyp.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSucheTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTyp.Properties.NullText = "";
            this.edtSucheTyp.Properties.ShowFooter = false;
            this.edtSucheTyp.Properties.ShowHeader = false;
            this.edtSucheTyp.Size = new System.Drawing.Size(262, 24);
            this.edtSucheTyp.TabIndex = 8;
            //
            // panBottom
            //
            this.panBottom.Controls.Add(this.lblStatusBar);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 582);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(900, 18);
            this.panBottom.TabIndex = 2;
            //
            // lblStatusBar
            //
            this.lblStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusBar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatusBar.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblStatusBar.Location = new System.Drawing.Point(0, 0);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(900, 18);
            this.lblStatusBar.TabIndex = 0;
            this.lblStatusBar.Text = "Status: -";
            this.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusBar.UseCompatibleTextRendering = true;
            //
            // CtlBDELeistungsart
            //
            this.ActiveSQLQuery = this.qryData;
            this.Controls.Add(this.tabDetails);
            this.Controls.Add(this.panBottom);
            this.Name = "CtlBDELeistungsart";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.CtlBDELeistungsart_Load);
            this.Controls.SetChildIndex(this.panBottom, 0);
            this.Controls.SetChildIndex(this.tabDetails, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tpgQueryGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswPIAuftrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswPIAuftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswPIAuftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswProdukt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswProdukt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswProdukt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswFaktura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswFaktura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswFaktura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZLE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswZLE)).EndInit();
            this.tpgGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memBeschreibung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraegerNichtberechtigte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNichtberechtigte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraegerAHV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraegerIV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostentraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostentraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsartTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArtikelNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArtikelNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientErfassungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientErfassungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlienterfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReihenfolge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDELeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDELeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlienterfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlienterfassung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlienterfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAnzahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAnzahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAnzahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp)).EndInit();
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).EndInit();
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

        private void CtlBDELeistungsart_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // set status
                SetStatusLabel("LoadingControl", "Initialisierung...");

                // connect lovs
                colKlienterfassung.ColumnEdit = grdBDELeistungsart.GetLOVLookUpEdit("BDEKlientErfassung");
                colAnzahl.ColumnEdit = grdBDELeistungsart.GetLOVLookUpEdit("BDEKlientErfassung");

                // setup update timeout (see #7249)
                qryData.UpdateTimeOut = 600;    // 10min

                // query data
                qryData.SelectStatement = @"
                    -- setup var and default value
                    DECLARE @langColumns NVARCHAR(1000);
                    DECLARE @sqlString NVARCHAR(4000);
                    DECLARE @languageCode VARCHAR(2);
                    DECLARE @searchBezeichnung VARCHAR(200);

                    SET @langColumns = '';
                    SET @sqlString = '';
                    SET @languageCode = '" + Session.User.LanguageCode + @"';
                    --- SET @searchBezeichnung = {edtSucheBezeichnung};

                    -- get all languages as [Deutsch],[Englisch], ... including subquery for text
                    SELECT @langColumns = @langColumns+'['+CONVERT(VARCHAR(255), LOV.Text)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = BLA.BezeichnungTID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),'
                    FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                    WHERE LOV.LOVName = 'Sprache' AND LOV.Text NOT LIKE '%]%'
                    GROUP BY LOV.Text, LOV.Code, LOV.SortKey
                    ORDER BY LOV.SortKey ASC;

                    -- validate for empty
                    IF (@langColumns IS NULL OR @langColumns = '')
                    BEGIN
                        SET @langColumns = 'NoLang = 1,';
                    END;

                    -- remove last comma and prepare string
                    SELECT @langColumns = LEFT(@langColumns, LEN(@langColumns) - 1);

                    -- create query to execute with all language columns
                    SET @sqlString = 'SELECT DISTINCT
                                        BLA.*,
                                        Kostenart       = dbo.fnGetLOVMLText(''BDEKostenart'', BLA.KostenartCode, ' + @languageCode + '),
                                        LeistungsartTyp = dbo.fnGetLOVMLText(''BDELeistungsartTyp'', BLA.LeistungsartTypCode, ' + @languageCode + '),
                                        AuswZLE         = dbo.fnGetLOVMLText(''BDELeistungsartAuswDienstleistung'', BLA.AuswDienstleistungCode, ' + @languageCode + '),
                                        AuswFaktura     = dbo.fnGetLOVMLText(''BDELeistungsartAuswFaktura'', BLA.AuswFakturaCode, ' + @languageCode + '),
                                        AuswProdukt     = dbo.fnGetLOVMLText(''BDELeistungsartAuswProdukt'', BLA.AuswProduktCode, ' + @languageCode + '),
                                        AuswPIAuftrag   = dbo.fnGetLOVMLText(''BDELeistungsartAuswPIAuftrag'', BLA.AuswPIAuftragCode, ' + @languageCode + '),
                                        SortSortKey     = CASE
                                                            WHEN BLA.SortKey IS NOT NULL THEN 0
                                                            ELSE 1
                                                            END,
                                        SortingDate     = CASE
                                                            WHEN BLA.DatumBis IS NULL THEN 0
                                                            ELSE 1
                                                            END,
                                        ' + @langColumns + '
                                        FROM dbo.BDELeistungsart BLA WITH (READUNCOMMITTED)
                                        LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = BLA.BezeichnungTID
                                        LEFT JOIN dbo.XLOVCode  LOV WITH (READUNCOMMITTED) ON LOV.Code = TXT.LanguageCode AND
                                                                                                LOVName = ''Sprache''
                                        WHERE 1=1
                                        AND (''' + ISNULL(@searchBezeichnung, '') + ''' = '''' OR BLA.Bezeichnung LIKE ''' + ISNULL(@searchBezeichnung, '') + ''' + ''%'')
                                        --- AND BLA.KlientErfassungCode = {edtSucheKlienterfassung}
                                        --- AND BLA.AnzahlCode = {edtSucheAnzahl}
                                        --- AND BLA.LeistungsartTypCode = {edtSucheTyp}
                                        ORDER BY SortSortKey ASC, BLA.SortKey ASC, BLA.Bezeichnung ASC, SortingDate ASC';

                    -- execute query and show data
                    EXEC (@sqlString);";

                // fill data to enable ml-columns
                qryData.Fill();

                // init validation counter
                int colsAdded = 0;

                // requerst all languages and append columns
                SqlQuery qryLanguages = DBUtil.OpenSQL(@"
                    SELECT DefaultText = LOV.Text
                    FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                    WHERE LOV.LOVName = 'Sprache'
                    ORDER BY LOV.SortKey ASC");

                // loop through language items and add columns to grid
                foreach (DataRow row in qryLanguages.DataTable.Rows)
                {
                    // setup vars
                    string defaultText = Convert.ToString(row["DefaultText"]);

                    // check if column for this language exists
                    if (qryData.DataTable.Columns.Contains(defaultText))
                    {
                        // column found in messages, create new column
                        DevExpress.XtraGrid.Columns.GridColumn newCol = new DevExpress.XtraGrid.Columns.GridColumn();
                        newCol.FieldName = defaultText;
                        newCol.Caption = defaultText;
                        newCol.Width = 200;
                        newCol.VisibleIndex = grvBDELeistungsart.Columns.Count;

                        // add column to view
                        grvBDELeistungsart.Columns.Add(newCol);
                        colsAdded++;
                    }
                }

                // validate
                if (colsAdded != qryLanguages.Count && qryData.Count > 0)
                {
                    throw new Exception(string.Format(@"Es konnten nicht alle Spalten in die Darstellung übernommen werden ('{0}' von '{1}' Spalten)", colsAdded, qryLanguages.Count));
                }

                // tabs
                tabDetails.SelectTab(tpgGeneral);

                // run new search
                NewSearch();
                tabControlSearch.SelectTab(tpgListe);
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorLoadingData", "Fehler bei der Verarbeitung. Die Daten werden womöglich nicht korrekt dargestellt.", ex);
            }
            finally
            {
                // reset status
                SetStatusLabel(null, null);

                // enable/disable type
                EnableLeistungsartTypControl();

                // reset cursor
                Cursor.Current = Cursors.Default;

                // reset flags
                _isInRefresh = false;
            }
        }

        private void edtBezeichnung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            DataHasChanged();
        }

        private void qryData_AfterInsert(object sender, EventArgs e)
        {
            // default values
            qryData["DatumVon"] = DateTime.Now;

            // enable/disable type
            EnableLeistungsartTypControl();

            // focus
            edtBezeichnung.Focus();
        }

        private void qryData_AfterPost(object sender, EventArgs e)
        {
            // set modified data
            qryData["Kostenart"] = edtKostenart.Text;
            qryData["LeistungsartTyp"] = edtLeistungsartTyp.Text;

            qryData["AuswZLE"] = edtAuswZLE.Text;
            qryData["AuswFaktura"] = edtAuswFaktura.Text;
            qryData["AuswProdukt"] = edtAuswProdukt.Text;
            qryData["AuswPIAuftrag"] = edtAuswPIAuftrag.Text;

            // enable/disable type
            this.EnableLeistungsartTypControl();

            // reset status
            SetStatusLabel(null, null);
        }

        private void qryData_BeforePost(object sender, EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtBezeichnung, lblBezeichnung.Text);
            DBUtil.CheckNotNullField(edtDatumVon, lblGueltigVon.Text);
            DBUtil.CheckNotNullField(edtKlientErfassungCode, lblKlienterfassung.Text);
            DBUtil.CheckNotNullField(edtAnzahlCode, lblAnzahl.Text);
            //DBUtil.CheckNotNullField(edtKostentraeger, lblStandard.Text);
            DBUtil.CheckNotNullField(edtLeistungsartTyp, lblLeistungsartTyp.Text);

            // setup values
            qryData["Bezeichnung"] = edtBezeichnung.EditValue;

            // set status
            SetStatusLabel("SavingData", "Daten werden gespeichert...");

            // new history entry
            if (qryData.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }
        }

        private void qryData_PositionChanged(object sender, EventArgs e)
        {
            // enable/disable type
            EnableLeistungsartTypControl();
        }

        private void qryData_PositionChanging(object sender, EventArgs e)
        {
            // check if need to refresh data
            if (_dataHasChanged && !_isInRefresh)
            {
                try
                {
                    _isInRefresh = true;
                    qryData.Refresh();
                }
                finally
                {
                    // reset flags
                    _isInRefresh = false;
                    _dataHasChanged = false;
                }
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtSucheBezeichnung.Focus();
        }

        #endregion

        #region Private Methods

        private void DataHasChanged()
        {
            // set flag
            _dataHasChanged = true;
        }

        private void EnableLeistungsartTypControl()
        {
            // get current state
            bool newEntry = qryData.Row != null && qryData.Row.RowState == DataRowState.Added;

            // if new entry and qry.CanInsert: everyone can modify field
            // else if qry.CanUpdate: only admin can modify field
            // else: field is writelocked
            if (newEntry && qryData.CanInsert)
            {
                // insert: allowed
                edtLeistungsartTyp.EditMode = EditModeType.Normal;
            }
            else if (!newEntry && qryData.CanUpdate && Session.User.IsUserAdmin)
            {
                // update: only admin
                edtLeistungsartTyp.EditMode = EditModeType.Normal;
            }
            else
            {
                // disabled
                edtLeistungsartTyp.EditMode = EditModeType.ReadOnly;
            }
        }

        /// <summary>
        /// Apply new status text to status label
        /// </summary>
        /// <param name="messageName">The message name to use for multilanguage message (MessageName)</param>
        /// <param name="defaultMessageText">The default message if none defined yet by translation (DefaultMessage)</param>
        private void SetStatusLabel(string messageName, string defaultMessageText)
        {
            // check if we have a valid name and text (only if not already translated)
            if (DBUtil.IsEmpty(messageName) || DBUtil.IsEmpty(defaultMessageText))
            {
                // no valid name or text, use default
                defaultMessageText = "-";
            }
            else
            {
                // get text from database
                defaultMessageText = KissMsg.GetMLMessage(Name, messageName, defaultMessageText, KissMsgCode.Text);
            }

            // setup text
            lblStatusBar.Text = string.Format(" {0}: {1}", _statusText, defaultMessageText);

            // do it
            ApplicationFacade.DoEvents();
        }

        #endregion

        #endregion
    }
}