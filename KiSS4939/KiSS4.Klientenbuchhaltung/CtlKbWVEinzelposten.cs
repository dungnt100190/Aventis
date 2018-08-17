using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Control used for doing "WV-Lauf"
    /// </summary>
    public class CtlKbWVEinzelposten : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private Boolean _isCurrentEntryTestlauf = true;

        // store if current entry within list-tabs is a Testlauf or not (by default true)
        private Boolean _isRowModifiedInChanging = false;

        private Boolean _isRowSelectedInChanging = false;
        private Int32 _kbPeriodeID = -1;

        // store current KbPeriodeID
        private Boolean _preventUpdateDetails = false;

        // do not update details (e.g. if selecting all rows)
        private KiSS4.Gui.KissButton btnEinzelpostenFakturieren;

        private KiSS4.Gui.KissButton btnGotoBudget;
        private KiSS4.Gui.KissButton btnJournalAnzeigen;
        private KiSS4.Gui.KissButton btnRunWVLauf;
        private KiSS4.Gui.KissButton btnSelectAll;
        private KiSS4.Gui.KissButton btnSelectNone;
        private KiSS4.Gui.KissCheckEdit chkRunWVTestlauf;
        private KiSS4.Gui.KissCheckEdit chkSucheFakturiert;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenAuslandschweizer;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenAuswahl;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenBgSplittingArt;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenFakturiert;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelpostenFehlerBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelpostenFehlerBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelpostenFehlerKbBuchungKostenartID;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelpostenFehlerKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelpostenFehlerPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelpostenFehlerWVFehlermeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelpostenFehlerWVLaufID;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenHeimatkantonNr;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenKantonKuerzel;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenKbWVEinzelpostenStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenKbWVEinzelpostenStatusCode_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenKbWVLaufID;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenSplittingDurchWVLaufDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenStornoEintrag;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenWohnKantonNr;
        private DevExpress.XtraGrid.Columns.GridColumn colEinzelPostenWVCodeDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufAnzahlEinzelposten;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufDatumBisWVLauf;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufFehler;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufKbWVLaufID;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufStartDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufTestlauf;
        private DevExpress.XtraGrid.Columns.GridColumn colWVLaufUserName;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissDateEdit edtDatumWVLauf;
        private KiSS4.Gui.KissMemoEdit edtEinzelPostenBemerkungen;
        private KiSS4.Gui.KissCalcEdit edtEinzelPostenBetrag;
        private KiSS4.Gui.KissLookUpEdit edtEinzelPostenBgKostenart;
        private KiSS4.Gui.KissTextEdit edtEinzelPostenBuchungstext;
        private KiSS4.Gui.KissLookUpEdit edtEinzelPostenKbWVEinzelpostenStatus;
        private KiSS4.Gui.KissCalcEdit edtHiddenKbWVEinzelpostenFehlerID;
        private KiSS4.Gui.KissCalcEdit edtHiddenKbWVEinzelpostenID;
        private KiSS4.Gui.KissButtonEdit edtSucheBaPerson;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkungen;
        private KiSS4.Gui.KissCalcEdit edtSucheBetragBis;
        private KiSS4.Gui.KissCalcEdit edtSucheBetragVon;
        private KiSS4.Gui.KissTextEdit edtSucheBuchungstext;
        private KiSS4.Gui.KissLookUpEdit edtSucheEinzelpostenStatus;
        private KiSS4.Gui.KissTextEdit edtSucheHeimatKantonNr;
        private KiSS4.Gui.KissTextEdit edtSucheKantonKuerzel;
        private KiSS4.Gui.KissLookUpEdit edtSucheSplittingArt;
        private KiSS4.Gui.KissTextEdit edtSucheWohnKantonNr;
        private KiSS4.Gui.KissGrid grdKbWVEinzelposten;
        private KiSS4.Gui.KissGrid grdKbWVEinzelpostenFehler;
        private KiSS4.Gui.KissGrid grdKbWVLauf;
        private KiSS4.Gui.KissGroupBox grpNeueWVEinzelposten;
        private KiSS4.Gui.KissGroupBox grpVorhandeneWVEinzelposten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbWVEinzelposten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbWVEinzelpostenFehler;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbWVLauf;
        private KissSearch KissSearchFehler = null; // own KissSearch for KbWVEinzelpostenFehler
        private KiSS4.Gui.KissLabel lblDatumWVLauf;
        private KiSS4.Gui.KissLabel lblEinzelPostenBemerkungen;
        private KiSS4.Gui.KissLabel lblEinzelPostenBetrag;
        private KiSS4.Gui.KissLabel lblEinzelPostenBgKostenart;
        private KiSS4.Gui.KissLabel lblEinzelPostenBuchungstext;
        private KiSS4.Gui.KissLabel lblEinzelPostenKbWVEinzelpostenStatus;
        private KiSS4.Gui.KissLabel lblGefundeneEPFCount;
        private KiSS4.Gui.KissLabel lblGewaehlteZeilen;
        private KiSS4.Gui.KissLabel lblKbPeriode;
        private KiSS4.Gui.KissLabel lblKbPeriodeTitel;
        private KiSS4.Gui.KissLabel lblSucheBaPerson;
        private KiSS4.Gui.KissLabel lblSucheBemerkungen;
        private KiSS4.Gui.KissLabel lblSucheBetragBis;
        private KiSS4.Gui.KissLabel lblSucheBetragVon;
        private KiSS4.Gui.KissLabel lblSucheBuchungstext;
        private KiSS4.Gui.KissLabel lblSucheEinzelpostenStatus;
        private KiSS4.Gui.KissLabel lblSucheHeimatKantonNr;
        private KiSS4.Gui.KissLabel lblSucheKantonKuerzel;
        private KiSS4.Gui.KissLabel lblSucheKbWVLaufID;
        private KiSS4.Gui.KissLabel lblSucheSplittingArt;
        private KiSS4.Gui.KissLabel lblSucheWohnKantonNr;
        private KiSS4.Gui.KissLabel lblWarningLauf;
        private System.Windows.Forms.Panel panListe2Top;
        private System.Windows.Forms.Panel panListeTop;
        private System.Windows.Forms.Panel panWarningLauf;
        private System.Windows.Forms.PictureBox picWarningLauf;
        private KiSS4.DB.SqlQuery qryKbWVEinzelposten;
        private KiSS4.DB.SqlQuery qryKbWVEinzelpostenFehler;
        private KiSS4.DB.SqlQuery qryKbWVLauf;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default contstructor to create new instance of class
        /// </summary>
        public CtlKbWVEinzelposten()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbWVEinzelposten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grpNeueWVEinzelposten = new KiSS4.Gui.KissGroupBox();
            this.btnRunWVLauf = new KiSS4.Gui.KissButton();
            this.chkRunWVTestlauf = new KiSS4.Gui.KissCheckEdit();
            this.edtDatumWVLauf = new KiSS4.Gui.KissDateEdit();
            this.lblDatumWVLauf = new KiSS4.Gui.KissLabel();
            this.lblKbPeriode = new KiSS4.Gui.KissLabel();
            this.lblKbPeriodeTitel = new KiSS4.Gui.KissLabel();
            this.grpVorhandeneWVEinzelposten = new KiSS4.Gui.KissGroupBox();
            this.btnGotoBudget = new KiSS4.Gui.KissButton();
            this.edtEinzelPostenBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.qryKbWVEinzelposten = new KiSS4.DB.SqlQuery();
            this.lblEinzelPostenBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtEinzelPostenBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblEinzelPostenBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtEinzelPostenBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblEinzelPostenBetrag = new KiSS4.Gui.KissLabel();
            this.edtEinzelPostenBgKostenart = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinzelPostenBgKostenart = new KiSS4.Gui.KissLabel();
            this.edtEinzelPostenKbWVEinzelpostenStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinzelPostenKbWVEinzelpostenStatus = new KiSS4.Gui.KissLabel();
            this.panWarningLauf = new System.Windows.Forms.Panel();
            this.lblWarningLauf = new KiSS4.Gui.KissLabel();
            this.picWarningLauf = new System.Windows.Forms.PictureBox();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.panListeTop = new System.Windows.Forms.Panel();
            this.btnJournalAnzeigen = new KiSS4.Gui.KissButton();
            this.btnEinzelpostenFakturieren = new KiSS4.Gui.KissButton();
            this.edtHiddenKbWVEinzelpostenID = new KiSS4.Gui.KissCalcEdit();
            this.lblGewaehlteZeilen = new KiSS4.Gui.KissLabel();
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.grdKbWVEinzelposten = new KiSS4.Gui.KissGrid();
            this.grvKbWVEinzelposten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEinzelPostenKbWVEinzelpostenStatusCode_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenAuswahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenKbWVLaufID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenKbWVEinzelpostenStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenFakturiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenStornoEintrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenSplittingDurchWVLaufDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenBgSplittingArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenWVCodeDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenHeimatkantonNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenWohnKantonNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenKantonKuerzel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenAuslandschweizer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelPostenBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.grdKbWVEinzelpostenFehler = new KiSS4.Gui.KissGrid();
            this.qryKbWVEinzelpostenFehler = new KiSS4.DB.SqlQuery();
            this.grvKbWVEinzelpostenFehler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEinzelpostenFehlerWVLaufID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelpostenFehlerKbBuchungKostenartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelpostenFehlerPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelpostenFehlerKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelpostenFehlerBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelpostenFehlerBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinzelpostenFehlerWVFehlermeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panListe2Top = new System.Windows.Forms.Panel();
            this.edtHiddenKbWVEinzelpostenFehlerID = new KiSS4.Gui.KissCalcEdit();
            this.lblGefundeneEPFCount = new KiSS4.Gui.KissLabel();
            this.lblSucheKbWVLaufID = new KiSS4.Gui.KissLabel();
            this.grdKbWVLauf = new KiSS4.Gui.KissGrid();
            this.qryKbWVLauf = new KiSS4.DB.SqlQuery();
            this.grvKbWVLauf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWVLaufKbWVLaufID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVLaufTestlauf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVLaufUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVLaufPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVLaufDatumBisWVLauf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVLaufStartDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVLaufAnzahlEinzelposten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVLaufFehler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheEinzelpostenStatus = new KiSS4.Gui.KissLabel();
            this.edtSucheEinzelpostenStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBaPerson = new KiSS4.Gui.KissLabel();
            this.edtSucheBaPerson = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheHeimatKantonNr = new KiSS4.Gui.KissLabel();
            this.edtSucheHeimatKantonNr = new KiSS4.Gui.KissTextEdit();
            this.lblSucheWohnKantonNr = new KiSS4.Gui.KissLabel();
            this.edtSucheWohnKantonNr = new KiSS4.Gui.KissTextEdit();
            this.lblSucheKantonKuerzel = new KiSS4.Gui.KissLabel();
            this.edtSucheKantonKuerzel = new KiSS4.Gui.KissTextEdit();
            this.lblSucheBetragVon = new KiSS4.Gui.KissLabel();
            this.edtSucheBetragVon = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheBetragBis = new KiSS4.Gui.KissLabel();
            this.edtSucheBetragBis = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheSplittingArt = new KiSS4.Gui.KissLabel();
            this.edtSucheSplittingArt = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtSucheBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblSucheBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtSucheBemerkungen = new KiSS4.Gui.KissTextEdit();
            this.chkSucheFakturiert = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.grpNeueWVEinzelposten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRunWVTestlauf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumWVLauf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumWVLauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbPeriodeTitel)).BeginInit();
            this.grpVorhandeneWVEinzelposten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbWVEinzelposten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBgKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBgKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBgKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenKbWVEinzelpostenStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenKbWVEinzelpostenStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenKbWVEinzelpostenStatus)).BeginInit();
            this.panWarningLauf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarningLauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarningLauf)).BeginInit();
            this.panListeTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHiddenKbWVEinzelpostenID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbWVEinzelposten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbWVEinzelposten)).BeginInit();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbWVEinzelpostenFehler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbWVEinzelpostenFehler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbWVEinzelpostenFehler)).BeginInit();
            this.panListe2Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHiddenKbWVEinzelpostenFehlerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGefundeneEPFCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKbWVLaufID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbWVLauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbWVLauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbWVLauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEinzelpostenStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinzelpostenStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinzelpostenStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHeimatKantonNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHeimatKantonNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheWohnKantonNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheWohnKantonNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKantonKuerzel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKantonKuerzel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSplittingArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSplittingArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSplittingArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheFakturiert.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(957, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.Location = new System.Drawing.Point(9, 126);
            this.tabControlSearch.ShowIconOnContainingData = true;
            this.tabControlSearch.Size = new System.Drawing.Size(981, 391);
            this.tabControlSearch.TabIndex = 2;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2});
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdKbWVEinzelposten);
            this.tpgListe.Controls.Add(this.panListeTop);
            this.tpgListe.Size = new System.Drawing.Size(969, 353);
            this.tpgListe.Title = "Gültige Einzelposten";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.chkSucheFakturiert);
            this.tpgSuchen.Controls.Add(this.edtSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.lblSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.edtSucheBuchungstext);
            this.tpgSuchen.Controls.Add(this.lblSucheBuchungstext);
            this.tpgSuchen.Controls.Add(this.edtSucheSplittingArt);
            this.tpgSuchen.Controls.Add(this.lblSucheSplittingArt);
            this.tpgSuchen.Controls.Add(this.edtSucheBetragBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBetragBis);
            this.tpgSuchen.Controls.Add(this.edtSucheBetragVon);
            this.tpgSuchen.Controls.Add(this.lblSucheBetragVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKantonKuerzel);
            this.tpgSuchen.Controls.Add(this.lblSucheKantonKuerzel);
            this.tpgSuchen.Controls.Add(this.edtSucheWohnKantonNr);
            this.tpgSuchen.Controls.Add(this.lblSucheWohnKantonNr);
            this.tpgSuchen.Controls.Add(this.edtSucheHeimatKantonNr);
            this.tpgSuchen.Controls.Add(this.lblSucheHeimatKantonNr);
            this.tpgSuchen.Controls.Add(this.edtSucheBaPerson);
            this.tpgSuchen.Controls.Add(this.lblSucheBaPerson);
            this.tpgSuchen.Controls.Add(this.edtSucheEinzelpostenStatus);
            this.tpgSuchen.Controls.Add(this.lblSucheEinzelpostenStatus);
            this.tpgSuchen.Controls.Add(this.grdKbWVLauf);
            this.tpgSuchen.Controls.Add(this.lblSucheKbWVLaufID);
            this.tpgSuchen.Size = new System.Drawing.Size(969, 353);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKbWVLaufID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdKbWVLauf, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheEinzelpostenStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheEinzelpostenStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBaPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBaPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheHeimatKantonNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheHeimatKantonNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheWohnKantonNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheWohnKantonNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKantonKuerzel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKantonKuerzel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetragVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetragVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetragBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetragBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSplittingArt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSplittingArt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBuchungstext, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBuchungstext, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheFakturiert, 0);
            //
            // grpNeueWVEinzelposten
            //
            this.grpNeueWVEinzelposten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNeueWVEinzelposten.Controls.Add(this.btnRunWVLauf);
            this.grpNeueWVEinzelposten.Controls.Add(this.chkRunWVTestlauf);
            this.grpNeueWVEinzelposten.Controls.Add(this.edtDatumWVLauf);
            this.grpNeueWVEinzelposten.Controls.Add(this.lblDatumWVLauf);
            this.grpNeueWVEinzelposten.Controls.Add(this.lblKbPeriode);
            this.grpNeueWVEinzelposten.Controls.Add(this.lblKbPeriodeTitel);
            this.grpNeueWVEinzelposten.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpNeueWVEinzelposten.Location = new System.Drawing.Point(3, 3);
            this.grpNeueWVEinzelposten.Name = "grpNeueWVEinzelposten";
            this.grpNeueWVEinzelposten.Size = new System.Drawing.Size(994, 81);
            this.grpNeueWVEinzelposten.TabIndex = 0;
            this.grpNeueWVEinzelposten.TabStop = false;
            this.grpNeueWVEinzelposten.Text = "Neue WV-Einzelposten generieren";
            this.grpNeueWVEinzelposten.UseCompatibleTextRendering = true;
            //
            // btnRunWVLauf
            //
            this.btnRunWVLauf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunWVLauf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunWVLauf.Location = new System.Drawing.Point(866, 47);
            this.btnRunWVLauf.Name = "btnRunWVLauf";
            this.btnRunWVLauf.Size = new System.Drawing.Size(119, 24);
            this.btnRunWVLauf.TabIndex = 5;
            this.btnRunWVLauf.Text = "&WV-Lauf starten";
            this.btnRunWVLauf.UseCompatibleTextRendering = true;
            this.btnRunWVLauf.UseVisualStyleBackColor = false;
            this.btnRunWVLauf.Click += new System.EventHandler(this.btnRunWVLauf_Click);
            //
            // chkRunWVTestlauf
            //
            this.chkRunWVTestlauf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunWVTestlauf.EditValue = true;
            this.chkRunWVTestlauf.Location = new System.Drawing.Point(866, 22);
            this.chkRunWVTestlauf.Name = "chkRunWVTestlauf";
            this.chkRunWVTestlauf.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkRunWVTestlauf.Properties.Appearance.Options.UseBackColor = true;
            this.chkRunWVTestlauf.Properties.Caption = "&Testlauf";
            this.chkRunWVTestlauf.Size = new System.Drawing.Size(119, 19);
            this.chkRunWVTestlauf.TabIndex = 4;
            //
            // edtDatumWVLauf
            //
            this.edtDatumWVLauf.EditValue = null;
            this.edtDatumWVLauf.Location = new System.Drawing.Point(126, 47);
            this.edtDatumWVLauf.Name = "edtDatumWVLauf";
            this.edtDatumWVLauf.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumWVLauf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumWVLauf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumWVLauf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumWVLauf.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumWVLauf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumWVLauf.Properties.Appearance.Options.UseFont = true;
            this.edtDatumWVLauf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumWVLauf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumWVLauf.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumWVLauf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumWVLauf.Properties.ShowToday = false;
            this.edtDatumWVLauf.Size = new System.Drawing.Size(100, 24);
            this.edtDatumWVLauf.TabIndex = 3;
            //
            // lblDatumWVLauf
            //
            this.lblDatumWVLauf.Location = new System.Drawing.Point(11, 47);
            this.lblDatumWVLauf.Name = "lblDatumWVLauf";
            this.lblDatumWVLauf.Size = new System.Drawing.Size(109, 24);
            this.lblDatumWVLauf.TabIndex = 2;
            this.lblDatumWVLauf.Text = "Datum WV-Lauf";
            this.lblDatumWVLauf.UseCompatibleTextRendering = true;
            //
            // lblKbPeriode
            //
            this.lblKbPeriode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKbPeriode.Location = new System.Drawing.Point(126, 17);
            this.lblKbPeriode.Name = "lblKbPeriode";
            this.lblKbPeriode.Size = new System.Drawing.Size(858, 24);
            this.lblKbPeriode.TabIndex = 1;
            this.lblKbPeriode.Text = "<aktuelle Periode>";
            this.lblKbPeriode.UseCompatibleTextRendering = true;
            //
            // lblKbPeriodeTitel
            //
            this.lblKbPeriodeTitel.Location = new System.Drawing.Point(11, 17);
            this.lblKbPeriodeTitel.Name = "lblKbPeriodeTitel";
            this.lblKbPeriodeTitel.Size = new System.Drawing.Size(109, 24);
            this.lblKbPeriodeTitel.TabIndex = 0;
            this.lblKbPeriodeTitel.Text = "Aktuelle Periode";
            this.lblKbPeriodeTitel.UseCompatibleTextRendering = true;
            //
            // grpVorhandeneWVEinzelposten
            //
            this.grpVorhandeneWVEinzelposten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.btnGotoBudget);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.edtEinzelPostenBemerkungen);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.lblEinzelPostenBemerkungen);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.edtEinzelPostenBuchungstext);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.lblEinzelPostenBuchungstext);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.edtEinzelPostenBetrag);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.lblEinzelPostenBetrag);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.edtEinzelPostenBgKostenart);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.lblEinzelPostenBgKostenart);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.edtEinzelPostenKbWVEinzelpostenStatus);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.lblEinzelPostenKbWVEinzelpostenStatus);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.panWarningLauf);
            this.grpVorhandeneWVEinzelposten.Controls.Add(this.ctlGotoFall);
            this.grpVorhandeneWVEinzelposten.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpVorhandeneWVEinzelposten.Location = new System.Drawing.Point(3, 90);
            this.grpVorhandeneWVEinzelposten.Name = "grpVorhandeneWVEinzelposten";
            this.grpVorhandeneWVEinzelposten.Size = new System.Drawing.Size(994, 557);
            this.grpVorhandeneWVEinzelposten.TabIndex = 1;
            this.grpVorhandeneWVEinzelposten.TabStop = false;
            this.grpVorhandeneWVEinzelposten.Text = "Vorhandene Einzelposten suchen und bearbeiten";
            this.grpVorhandeneWVEinzelposten.UseCompatibleTextRendering = true;
            //
            // btnGotoBudget
            //
            this.btnGotoBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoBudget.Location = new System.Drawing.Point(866, 493);
            this.btnGotoBudget.Name = "btnGotoBudget";
            this.btnGotoBudget.Size = new System.Drawing.Size(119, 24);
            this.btnGotoBudget.TabIndex = 12;
            this.btnGotoBudget.Text = "> &Monatsbudget";
            this.btnGotoBudget.UseCompatibleTextRendering = true;
            this.btnGotoBudget.UseVisualStyleBackColor = false;
            this.btnGotoBudget.Click += new System.EventHandler(this.btnGotoBudget_Click);
            //
            // edtEinzelPostenBemerkungen
            //
            this.edtEinzelPostenBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEinzelPostenBemerkungen.DataMember = "Bemerkungen";
            this.edtEinzelPostenBemerkungen.DataSource = this.qryKbWVEinzelposten;
            this.edtEinzelPostenBemerkungen.Location = new System.Drawing.Point(435, 493);
            this.edtEinzelPostenBemerkungen.Name = "edtEinzelPostenBemerkungen";
            this.edtEinzelPostenBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzelPostenBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzelPostenBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelPostenBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzelPostenBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzelPostenBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtEinzelPostenBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinzelPostenBemerkungen.Properties.MaxLength = 2000;
            this.edtEinzelPostenBemerkungen.Size = new System.Drawing.Size(336, 54);
            this.edtEinzelPostenBemerkungen.TabIndex = 11;
            //
            // qryKbWVEinzelposten
            //
            this.qryKbWVEinzelposten.CanDelete = true;
            this.qryKbWVEinzelposten.CanUpdate = true;
            this.qryKbWVEinzelposten.HostControl = this;
            this.qryKbWVEinzelposten.SelectStatement = resources.GetString("qryKbWVEinzelposten.SelectStatement");
            this.qryKbWVEinzelposten.TableName = "KbWVEinzelposten";
            this.qryKbWVEinzelposten.AfterDelete += new System.EventHandler(this.qryKbWVEinzelposten_AfterDelete);
            this.qryKbWVEinzelposten.AfterFill += new System.EventHandler(this.qryKbWVEinzelposten_AfterFill);
            this.qryKbWVEinzelposten.BeforeDeleteQuestion += new System.EventHandler(this.qryKbWVEinzelposten_BeforeDeleteQuestion);
            this.qryKbWVEinzelposten.BeforePost += new System.EventHandler(this.qryKbWVEinzelposten_BeforePost);
            this.qryKbWVEinzelposten.PositionChanged += new System.EventHandler(this.qryKbWVEinzelposten_PositionChanged);
            //
            // lblEinzelPostenBemerkungen
            //
            this.lblEinzelPostenBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzelPostenBemerkungen.Location = new System.Drawing.Point(435, 463);
            this.lblEinzelPostenBemerkungen.Name = "lblEinzelPostenBemerkungen";
            this.lblEinzelPostenBemerkungen.Size = new System.Drawing.Size(134, 24);
            this.lblEinzelPostenBemerkungen.TabIndex = 10;
            this.lblEinzelPostenBemerkungen.Text = "Bemerkungen";
            this.lblEinzelPostenBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtEinzelPostenBuchungstext
            //
            this.edtEinzelPostenBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinzelPostenBuchungstext.DataMember = "Buchungstext";
            this.edtEinzelPostenBuchungstext.DataSource = this.qryKbWVEinzelposten;
            this.edtEinzelPostenBuchungstext.Location = new System.Drawing.Point(146, 523);
            this.edtEinzelPostenBuchungstext.Name = "edtEinzelPostenBuchungstext";
            this.edtEinzelPostenBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzelPostenBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzelPostenBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelPostenBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzelPostenBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzelPostenBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtEinzelPostenBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinzelPostenBuchungstext.Properties.MaxLength = 200;
            this.edtEinzelPostenBuchungstext.Size = new System.Drawing.Size(245, 24);
            this.edtEinzelPostenBuchungstext.TabIndex = 9;
            //
            // lblEinzelPostenBuchungstext
            //
            this.lblEinzelPostenBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzelPostenBuchungstext.Location = new System.Drawing.Point(20, 523);
            this.lblEinzelPostenBuchungstext.Name = "lblEinzelPostenBuchungstext";
            this.lblEinzelPostenBuchungstext.Size = new System.Drawing.Size(120, 24);
            this.lblEinzelPostenBuchungstext.TabIndex = 8;
            this.lblEinzelPostenBuchungstext.Text = "Buchungstext";
            this.lblEinzelPostenBuchungstext.UseCompatibleTextRendering = true;
            //
            // edtEinzelPostenBetrag
            //
            this.edtEinzelPostenBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinzelPostenBetrag.DataMember = "Betrag";
            this.edtEinzelPostenBetrag.DataSource = this.qryKbWVEinzelposten;
            this.edtEinzelPostenBetrag.Location = new System.Drawing.Point(146, 493);
            this.edtEinzelPostenBetrag.Name = "edtEinzelPostenBetrag";
            this.edtEinzelPostenBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinzelPostenBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzelPostenBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzelPostenBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelPostenBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzelPostenBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzelPostenBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtEinzelPostenBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinzelPostenBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzelPostenBetrag.Properties.DisplayFormat.FormatString = "C";
            this.edtEinzelPostenBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtEinzelPostenBetrag.Properties.EditFormat.FormatString = "C";
            this.edtEinzelPostenBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtEinzelPostenBetrag.Properties.Mask.EditMask = "C";
            this.edtEinzelPostenBetrag.Properties.Precision = 2;
            this.edtEinzelPostenBetrag.Size = new System.Drawing.Size(121, 24);
            this.edtEinzelPostenBetrag.TabIndex = 7;
            //
            // lblEinzelPostenBetrag
            //
            this.lblEinzelPostenBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzelPostenBetrag.Location = new System.Drawing.Point(20, 493);
            this.lblEinzelPostenBetrag.Name = "lblEinzelPostenBetrag";
            this.lblEinzelPostenBetrag.Size = new System.Drawing.Size(120, 24);
            this.lblEinzelPostenBetrag.TabIndex = 6;
            this.lblEinzelPostenBetrag.Text = "Betrag";
            this.lblEinzelPostenBetrag.UseCompatibleTextRendering = true;
            //
            // edtEinzelPostenBgKostenart
            //
            this.edtEinzelPostenBgKostenart.AllowNull = false;
            this.edtEinzelPostenBgKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinzelPostenBgKostenart.DataMember = "BgKostenartID";
            this.edtEinzelPostenBgKostenart.DataSource = this.qryKbWVEinzelposten;
            this.edtEinzelPostenBgKostenart.Location = new System.Drawing.Point(146, 463);
            this.edtEinzelPostenBgKostenart.Name = "edtEinzelPostenBgKostenart";
            this.edtEinzelPostenBgKostenart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzelPostenBgKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzelPostenBgKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelPostenBgKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzelPostenBgKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzelPostenBgKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtEinzelPostenBgKostenart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinzelPostenBgKostenart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelPostenBgKostenart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinzelPostenBgKostenart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinzelPostenBgKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtEinzelPostenBgKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtEinzelPostenBgKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzelPostenBgKostenart.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtEinzelPostenBgKostenart.Properties.DisplayMember = "Text";
            this.edtEinzelPostenBgKostenart.Properties.NullText = "";
            this.edtEinzelPostenBgKostenart.Properties.ShowFooter = false;
            this.edtEinzelPostenBgKostenart.Properties.ShowHeader = false;
            this.edtEinzelPostenBgKostenart.Properties.ValueMember = "Code";
            this.edtEinzelPostenBgKostenart.Size = new System.Drawing.Size(245, 24);
            this.edtEinzelPostenBgKostenart.TabIndex = 5;
            //
            // lblEinzelPostenBgKostenart
            //
            this.lblEinzelPostenBgKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzelPostenBgKostenart.Location = new System.Drawing.Point(20, 463);
            this.lblEinzelPostenBgKostenart.Name = "lblEinzelPostenBgKostenart";
            this.lblEinzelPostenBgKostenart.Size = new System.Drawing.Size(120, 24);
            this.lblEinzelPostenBgKostenart.TabIndex = 4;
            this.lblEinzelPostenBgKostenart.Text = "Kostenart";
            this.lblEinzelPostenBgKostenart.UseCompatibleTextRendering = true;
            //
            // edtEinzelPostenKbWVEinzelpostenStatus
            //
            this.edtEinzelPostenKbWVEinzelpostenStatus.AllowNull = false;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinzelPostenKbWVEinzelpostenStatus.DataMember = "KbWVEinzelpostenStatusCode";
            this.edtEinzelPostenKbWVEinzelpostenStatus.DataSource = this.qryKbWVEinzelposten;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Location = new System.Drawing.Point(146, 433);
            this.edtEinzelPostenKbWVEinzelpostenStatus.LOVName = "KbWVEinzelpostenStatus";
            this.edtEinzelPostenKbWVEinzelpostenStatus.Name = "edtEinzelPostenKbWVEinzelpostenStatus";
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Appearance.Options.UseFont = true;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.DisplayMember = "Text";
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.NullText = "";
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.ShowFooter = false;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.ShowHeader = false;
            this.edtEinzelPostenKbWVEinzelpostenStatus.Properties.ValueMember = "Code";
            this.edtEinzelPostenKbWVEinzelpostenStatus.Size = new System.Drawing.Size(245, 24);
            this.edtEinzelPostenKbWVEinzelpostenStatus.TabIndex = 3;
            //
            // lblEinzelPostenKbWVEinzelpostenStatus
            //
            this.lblEinzelPostenKbWVEinzelpostenStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzelPostenKbWVEinzelpostenStatus.Location = new System.Drawing.Point(20, 433);
            this.lblEinzelPostenKbWVEinzelpostenStatus.Name = "lblEinzelPostenKbWVEinzelpostenStatus";
            this.lblEinzelPostenKbWVEinzelpostenStatus.Size = new System.Drawing.Size(120, 24);
            this.lblEinzelPostenKbWVEinzelpostenStatus.TabIndex = 2;
            this.lblEinzelPostenKbWVEinzelpostenStatus.Text = "Status";
            this.lblEinzelPostenKbWVEinzelpostenStatus.UseCompatibleTextRendering = true;
            //
            // panWarningLauf
            //
            this.panWarningLauf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWarningLauf.Controls.Add(this.lblWarningLauf);
            this.panWarningLauf.Controls.Add(this.picWarningLauf);
            this.panWarningLauf.Location = new System.Drawing.Point(6, 17);
            this.panWarningLauf.Name = "panWarningLauf";
            this.panWarningLauf.Size = new System.Drawing.Size(981, 16);
            this.panWarningLauf.TabIndex = 1;
            //
            // lblWarningLauf
            //
            this.lblWarningLauf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarningLauf.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblWarningLauf.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblWarningLauf.Location = new System.Drawing.Point(705, 0);
            this.lblWarningLauf.Name = "lblWarningLauf";
            this.lblWarningLauf.Size = new System.Drawing.Size(254, 16);
            this.lblWarningLauf.TabIndex = 0;
            this.lblWarningLauf.Text = "<Info-Text WV-Lauf>";
            this.lblWarningLauf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWarningLauf.UseCompatibleTextRendering = true;
            //
            // picWarningLauf
            //
            this.picWarningLauf.Dock = System.Windows.Forms.DockStyle.Right;
            this.picWarningLauf.Location = new System.Drawing.Point(965, 0);
            this.picWarningLauf.Name = "picWarningLauf";
            this.picWarningLauf.Size = new System.Drawing.Size(16, 16);
            this.picWarningLauf.TabIndex = 12;
            this.picWarningLauf.TabStop = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFall.Location = new System.Drawing.Point(775, 523);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(210, 24);
            this.ctlGotoFall.TabIndex = 0;
            //
            // panListeTop
            //
            this.panListeTop.Controls.Add(this.btnJournalAnzeigen);
            this.panListeTop.Controls.Add(this.btnEinzelpostenFakturieren);
            this.panListeTop.Controls.Add(this.edtHiddenKbWVEinzelpostenID);
            this.panListeTop.Controls.Add(this.lblGewaehlteZeilen);
            this.panListeTop.Controls.Add(this.btnSelectNone);
            this.panListeTop.Controls.Add(this.btnSelectAll);
            this.panListeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panListeTop.Location = new System.Drawing.Point(0, 0);
            this.panListeTop.Name = "panListeTop";
            this.panListeTop.Size = new System.Drawing.Size(969, 31);
            this.panListeTop.TabIndex = 0;
            //
            // btnJournalAnzeigen
            //
            this.btnJournalAnzeigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJournalAnzeigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJournalAnzeigen.Location = new System.Drawing.Point(854, 3);
            this.btnJournalAnzeigen.Name = "btnJournalAnzeigen";
            this.btnJournalAnzeigen.Size = new System.Drawing.Size(112, 24);
            this.btnJournalAnzeigen.TabIndex = 5;
            this.btnJournalAnzeigen.Text = "&Journal anzeigen";
            this.btnJournalAnzeigen.UseCompatibleTextRendering = true;
            this.btnJournalAnzeigen.UseVisualStyleBackColor = false;
            this.btnJournalAnzeigen.Click += new System.EventHandler(this.btnJournalAnzeigen_Click);
            //
            // btnEinzelpostenFakturieren
            //
            this.btnEinzelpostenFakturieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEinzelpostenFakturieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinzelpostenFakturieren.Location = new System.Drawing.Point(679, 3);
            this.btnEinzelpostenFakturieren.Name = "btnEinzelpostenFakturieren";
            this.btnEinzelpostenFakturieren.Size = new System.Drawing.Size(169, 24);
            this.btnEinzelpostenFakturieren.TabIndex = 4;
            this.btnEinzelpostenFakturieren.Text = "Einzelposten &fakturieren";
            this.btnEinzelpostenFakturieren.UseCompatibleTextRendering = true;
            this.btnEinzelpostenFakturieren.UseVisualStyleBackColor = false;
            this.btnEinzelpostenFakturieren.Click += new System.EventHandler(this.btnEinzelpostenFakturieren_Click);
            //
            // edtHiddenKbWVEinzelpostenID
            //
            this.edtHiddenKbWVEinzelpostenID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHiddenKbWVEinzelpostenID.DataMember = "KbWVEinzelpostenID";
            this.edtHiddenKbWVEinzelpostenID.DataSource = this.qryKbWVEinzelposten;
            this.edtHiddenKbWVEinzelpostenID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHiddenKbWVEinzelpostenID.Location = new System.Drawing.Point(573, 3);
            this.edtHiddenKbWVEinzelpostenID.Name = "edtHiddenKbWVEinzelpostenID";
            this.edtHiddenKbWVEinzelpostenID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHiddenKbWVEinzelpostenID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHiddenKbWVEinzelpostenID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHiddenKbWVEinzelpostenID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHiddenKbWVEinzelpostenID.Properties.Appearance.Options.UseBackColor = true;
            this.edtHiddenKbWVEinzelpostenID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHiddenKbWVEinzelpostenID.Properties.Appearance.Options.UseFont = true;
            this.edtHiddenKbWVEinzelpostenID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHiddenKbWVEinzelpostenID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHiddenKbWVEinzelpostenID.Properties.ReadOnly = true;
            this.edtHiddenKbWVEinzelpostenID.Size = new System.Drawing.Size(100, 24);
            this.edtHiddenKbWVEinzelpostenID.TabIndex = 3;
            this.edtHiddenKbWVEinzelpostenID.Visible = false;
            //
            // lblGewaehlteZeilen
            //
            this.lblGewaehlteZeilen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGewaehlteZeilen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGewaehlteZeilen.Location = new System.Drawing.Point(63, 3);
            this.lblGewaehlteZeilen.Name = "lblGewaehlteZeilen";
            this.lblGewaehlteZeilen.Size = new System.Drawing.Size(358, 24);
            this.lblGewaehlteZeilen.TabIndex = 2;
            this.lblGewaehlteZeilen.Text = "Ausgewählte Zeilen: <Anzahl>";
            this.lblGewaehlteZeilen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGewaehlteZeilen.UseCompatibleTextRendering = true;
            //
            // btnSelectNone
            //
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.IconID = 75;
            this.btnSelectNone.Location = new System.Drawing.Point(33, 3);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 1;
            this.btnSelectNone.UseCompatibleTextRendering = true;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            //
            // btnSelectAll
            //
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.IconID = 74;
            this.btnSelectAll.Location = new System.Drawing.Point(3, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            //
            // grdKbWVEinzelposten
            //
            this.grdKbWVEinzelposten.DataSource = this.qryKbWVEinzelposten;
            this.grdKbWVEinzelposten.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdKbWVEinzelposten.EmbeddedNavigator.Name = "";
            this.grdKbWVEinzelposten.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdKbWVEinzelposten.Location = new System.Drawing.Point(0, 31);
            this.grdKbWVEinzelposten.MainView = this.grvKbWVEinzelposten;
            this.grdKbWVEinzelposten.Name = "grdKbWVEinzelposten";
            this.grdKbWVEinzelposten.Size = new System.Drawing.Size(969, 322);
            this.grdKbWVEinzelposten.TabIndex = 1;
            this.grdKbWVEinzelposten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbWVEinzelposten});
            //
            // grvKbWVEinzelposten
            //
            this.grvKbWVEinzelposten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbWVEinzelposten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.Empty.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKbWVEinzelposten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbWVEinzelposten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvKbWVEinzelposten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbWVEinzelposten.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbWVEinzelposten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbWVEinzelposten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbWVEinzelposten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbWVEinzelposten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbWVEinzelposten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbWVEinzelposten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbWVEinzelposten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbWVEinzelposten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbWVEinzelposten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbWVEinzelposten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbWVEinzelposten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbWVEinzelposten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbWVEinzelposten.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKbWVEinzelposten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.OddRow.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbWVEinzelposten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.Row.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.Row.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbWVEinzelposten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelposten.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbWVEinzelposten.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbWVEinzelposten.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbWVEinzelposten.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKbWVEinzelposten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbWVEinzelposten.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEinzelPostenKbWVEinzelpostenStatusCode_Code,
            this.colEinzelPostenAuswahl,
            this.colEinzelPostenKbWVLaufID,
            this.colEinzelPostenKbWVEinzelpostenStatusCode,
            this.colEinzelPostenFakturiert,
            this.colEinzelPostenStornoEintrag,
            this.colEinzelPostenSplittingDurchWVLaufDatumBis,
            this.colEinzelPostenPerson,
            this.colEinzelPostenKostenart,
            this.colEinzelPostenBgSplittingArt,
            this.colEinzelPostenBetrag,
            this.colEinzelPostenDatumVon,
            this.colEinzelPostenDatumBis,
            this.colEinzelPostenWVCodeDatumBis,
            this.colEinzelPostenBuchungstext,
            this.colEinzelPostenHeimatkantonNr,
            this.colEinzelPostenWohnKantonNr,
            this.colEinzelPostenKantonKuerzel,
            this.colEinzelPostenAuslandschweizer,
            this.colEinzelPostenBemerkungen});
            this.grvKbWVEinzelposten.GridControl = this.grdKbWVEinzelposten;
            this.grvKbWVEinzelposten.Name = "grvKbWVEinzelposten";
            this.grvKbWVEinzelposten.OptionsCustomization.AllowFilter = false;
            this.grvKbWVEinzelposten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbWVEinzelposten.OptionsMenu.EnableColumnMenu = false;
            this.grvKbWVEinzelposten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbWVEinzelposten.OptionsView.ColumnAutoWidth = false;
            this.grvKbWVEinzelposten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbWVEinzelposten.OptionsView.ShowFooter = true;
            this.grvKbWVEinzelposten.OptionsView.ShowGroupPanel = false;
            this.grvKbWVEinzelposten.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvKbWVEinzelposten_CustomDrawCell);
            this.grvKbWVEinzelposten.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvKbWVEinzelposten_ShowingEditor);
            //
            // colEinzelPostenKbWVEinzelpostenStatusCode_Code
            //
            this.colEinzelPostenKbWVEinzelpostenStatusCode_Code.Caption = "KbWVEinzelpostenStatusCode";
            this.colEinzelPostenKbWVEinzelpostenStatusCode_Code.FieldName = "KbWVEinzelpostenStatusCode";
            this.colEinzelPostenKbWVEinzelpostenStatusCode_Code.Name = "colEinzelPostenKbWVEinzelpostenStatusCode_Code";
            //
            // colEinzelPostenAuswahl
            //
            this.colEinzelPostenAuswahl.Caption = "Ausw.";
            this.colEinzelPostenAuswahl.FieldName = "Auswahl";
            this.colEinzelPostenAuswahl.Name = "colEinzelPostenAuswahl";
            this.colEinzelPostenAuswahl.Visible = true;
            this.colEinzelPostenAuswahl.VisibleIndex = 0;
            this.colEinzelPostenAuswahl.Width = 47;
            //
            // colEinzelPostenKbWVLaufID
            //
            this.colEinzelPostenKbWVLaufID.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenKbWVLaufID.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenKbWVLaufID.Caption = "WV-Lauf ID";
            this.colEinzelPostenKbWVLaufID.FieldName = "KbWVLaufID";
            this.colEinzelPostenKbWVLaufID.Name = "colEinzelPostenKbWVLaufID";
            this.colEinzelPostenKbWVLaufID.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenKbWVLaufID.Visible = true;
            this.colEinzelPostenKbWVLaufID.VisibleIndex = 1;
            this.colEinzelPostenKbWVLaufID.Width = 71;
            //
            // colEinzelPostenKbWVEinzelpostenStatusCode
            //
            this.colEinzelPostenKbWVEinzelpostenStatusCode.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenKbWVEinzelpostenStatusCode.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenKbWVEinzelpostenStatusCode.Caption = "Status";
            this.colEinzelPostenKbWVEinzelpostenStatusCode.FieldName = "Status";
            this.colEinzelPostenKbWVEinzelpostenStatusCode.Name = "colEinzelPostenKbWVEinzelpostenStatusCode";
            this.colEinzelPostenKbWVEinzelpostenStatusCode.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenKbWVEinzelpostenStatusCode.Visible = true;
            this.colEinzelPostenKbWVEinzelpostenStatusCode.VisibleIndex = 2;
            this.colEinzelPostenKbWVEinzelpostenStatusCode.Width = 150;
            //
            // colEinzelPostenFakturiert
            //
            this.colEinzelPostenFakturiert.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenFakturiert.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenFakturiert.Caption = "Fakturiert";
            this.colEinzelPostenFakturiert.FieldName = "Fakturiert";
            this.colEinzelPostenFakturiert.Name = "colEinzelPostenFakturiert";
            this.colEinzelPostenFakturiert.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenFakturiert.Visible = true;
            this.colEinzelPostenFakturiert.VisibleIndex = 3;
            this.colEinzelPostenFakturiert.Width = 66;
            //
            // colEinzelPostenStornoEintrag
            //
            this.colEinzelPostenStornoEintrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenStornoEintrag.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenStornoEintrag.Caption = "Storno-Eintrag";
            this.colEinzelPostenStornoEintrag.FieldName = "StornoEintrag";
            this.colEinzelPostenStornoEintrag.Name = "colEinzelPostenStornoEintrag";
            this.colEinzelPostenStornoEintrag.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenStornoEintrag.Visible = true;
            this.colEinzelPostenStornoEintrag.VisibleIndex = 4;
            this.colEinzelPostenStornoEintrag.Width = 91;
            //
            // colEinzelPostenSplittingDurchWVLaufDatumBis
            //
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.Caption = "Split. d. Lauf";
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.FieldName = "SplittingDurchWVLaufDatumBis";
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.Name = "colEinzelPostenSplittingDurchWVLaufDatumBis";
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.Visible = true;
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.VisibleIndex = 5;
            this.colEinzelPostenSplittingDurchWVLaufDatumBis.Width = 79;
            //
            // colEinzelPostenPerson
            //
            this.colEinzelPostenPerson.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenPerson.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenPerson.Caption = "Person";
            this.colEinzelPostenPerson.FieldName = "Person";
            this.colEinzelPostenPerson.Name = "colEinzelPostenPerson";
            this.colEinzelPostenPerson.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenPerson.Visible = true;
            this.colEinzelPostenPerson.VisibleIndex = 6;
            this.colEinzelPostenPerson.Width = 190;
            //
            // colEinzelPostenKostenart
            //
            this.colEinzelPostenKostenart.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenKostenart.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenKostenart.Caption = "Kostenart";
            this.colEinzelPostenKostenart.FieldName = "Kostenart";
            this.colEinzelPostenKostenart.Name = "colEinzelPostenKostenart";
            this.colEinzelPostenKostenart.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenKostenart.Visible = true;
            this.colEinzelPostenKostenart.VisibleIndex = 7;
            this.colEinzelPostenKostenart.Width = 190;
            //
            // colEinzelPostenBgSplittingArt
            //
            this.colEinzelPostenBgSplittingArt.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenBgSplittingArt.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenBgSplittingArt.Caption = "Splittingart";
            this.colEinzelPostenBgSplittingArt.FieldName = "Splittingart";
            this.colEinzelPostenBgSplittingArt.Name = "colEinzelPostenBgSplittingArt";
            this.colEinzelPostenBgSplittingArt.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenBgSplittingArt.Visible = true;
            this.colEinzelPostenBgSplittingArt.VisibleIndex = 8;
            this.colEinzelPostenBgSplittingArt.Width = 120;
            //
            // colEinzelPostenBetrag
            //
            this.colEinzelPostenBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenBetrag.Caption = "Betrag";
            this.colEinzelPostenBetrag.DisplayFormat.FormatString = "n2";
            this.colEinzelPostenBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinzelPostenBetrag.FieldName = "Betrag";
            this.colEinzelPostenBetrag.Name = "colEinzelPostenBetrag";
            this.colEinzelPostenBetrag.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenBetrag.Visible = true;
            this.colEinzelPostenBetrag.VisibleIndex = 9;
            this.colEinzelPostenBetrag.Width = 90;
            //
            // colEinzelPostenDatumVon
            //
            this.colEinzelPostenDatumVon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenDatumVon.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenDatumVon.Caption = "Datum von";
            this.colEinzelPostenDatumVon.FieldName = "DatumVon";
            this.colEinzelPostenDatumVon.Name = "colEinzelPostenDatumVon";
            this.colEinzelPostenDatumVon.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenDatumVon.Visible = true;
            this.colEinzelPostenDatumVon.VisibleIndex = 10;
            //
            // colEinzelPostenDatumBis
            //
            this.colEinzelPostenDatumBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenDatumBis.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenDatumBis.Caption = "Datum bis";
            this.colEinzelPostenDatumBis.FieldName = "DatumBis";
            this.colEinzelPostenDatumBis.Name = "colEinzelPostenDatumBis";
            this.colEinzelPostenDatumBis.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenDatumBis.Visible = true;
            this.colEinzelPostenDatumBis.VisibleIndex = 11;
            //
            // colEinzelPostenWVCodeDatumBis
            //
            this.colEinzelPostenWVCodeDatumBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenWVCodeDatumBis.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenWVCodeDatumBis.Caption = "Ende WV-Code";
            this.colEinzelPostenWVCodeDatumBis.FieldName = "WVCodeDatumBis";
            this.colEinzelPostenWVCodeDatumBis.Name = "colEinzelPostenWVCodeDatumBis";
            this.colEinzelPostenWVCodeDatumBis.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenWVCodeDatumBis.Visible = true;
            this.colEinzelPostenWVCodeDatumBis.VisibleIndex = 12;
            this.colEinzelPostenWVCodeDatumBis.Width = 93;
            //
            // colEinzelPostenBuchungstext
            //
            this.colEinzelPostenBuchungstext.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenBuchungstext.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenBuchungstext.Caption = "Buchungstext";
            this.colEinzelPostenBuchungstext.FieldName = "Buchungstext";
            this.colEinzelPostenBuchungstext.Name = "colEinzelPostenBuchungstext";
            this.colEinzelPostenBuchungstext.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenBuchungstext.Visible = true;
            this.colEinzelPostenBuchungstext.VisibleIndex = 13;
            this.colEinzelPostenBuchungstext.Width = 190;
            //
            // colEinzelPostenHeimatkantonNr
            //
            this.colEinzelPostenHeimatkantonNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenHeimatkantonNr.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenHeimatkantonNr.Caption = "Heimatkanton Nr.";
            this.colEinzelPostenHeimatkantonNr.FieldName = "HeimatkantonNr";
            this.colEinzelPostenHeimatkantonNr.Name = "colEinzelPostenHeimatkantonNr";
            this.colEinzelPostenHeimatkantonNr.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenHeimatkantonNr.Visible = true;
            this.colEinzelPostenHeimatkantonNr.VisibleIndex = 14;
            this.colEinzelPostenHeimatkantonNr.Width = 106;
            //
            // colEinzelPostenWohnKantonNr
            //
            this.colEinzelPostenWohnKantonNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenWohnKantonNr.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenWohnKantonNr.Caption = "Wohnkanton Nr.";
            this.colEinzelPostenWohnKantonNr.FieldName = "WohnKantonNr";
            this.colEinzelPostenWohnKantonNr.Name = "colEinzelPostenWohnKantonNr";
            this.colEinzelPostenWohnKantonNr.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenWohnKantonNr.Visible = true;
            this.colEinzelPostenWohnKantonNr.VisibleIndex = 15;
            this.colEinzelPostenWohnKantonNr.Width = 99;
            //
            // colEinzelPostenKantonKuerzel
            //
            this.colEinzelPostenKantonKuerzel.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenKantonKuerzel.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenKantonKuerzel.Caption = "Kanton Kürzel";
            this.colEinzelPostenKantonKuerzel.FieldName = "KantonKuerzel";
            this.colEinzelPostenKantonKuerzel.Name = "colEinzelPostenKantonKuerzel";
            this.colEinzelPostenKantonKuerzel.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenKantonKuerzel.Visible = true;
            this.colEinzelPostenKantonKuerzel.VisibleIndex = 16;
            this.colEinzelPostenKantonKuerzel.Width = 88;
            //
            // colEinzelPostenAuslandschweizer
            //
            this.colEinzelPostenAuslandschweizer.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenAuslandschweizer.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenAuslandschweizer.Caption = "Auslandschweizer";
            this.colEinzelPostenAuslandschweizer.FieldName = "Auslandschweizer";
            this.colEinzelPostenAuslandschweizer.Name = "colEinzelPostenAuslandschweizer";
            this.colEinzelPostenAuslandschweizer.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenAuslandschweizer.Visible = true;
            this.colEinzelPostenAuslandschweizer.VisibleIndex = 17;
            this.colEinzelPostenAuslandschweizer.Width = 115;
            //
            // colEinzelPostenBemerkungen
            //
            this.colEinzelPostenBemerkungen.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinzelPostenBemerkungen.AppearanceCell.Options.UseBackColor = true;
            this.colEinzelPostenBemerkungen.Caption = "Bemerkungen";
            this.colEinzelPostenBemerkungen.FieldName = "Bemerkungen";
            this.colEinzelPostenBemerkungen.Name = "colEinzelPostenBemerkungen";
            this.colEinzelPostenBemerkungen.OptionsColumn.AllowEdit = false;
            this.colEinzelPostenBemerkungen.Visible = true;
            this.colEinzelPostenBemerkungen.VisibleIndex = 18;
            this.colEinzelPostenBemerkungen.Width = 200;
            //
            // tpgListe2
            //
            this.tpgListe2.Controls.Add(this.grdKbWVEinzelpostenFehler);
            this.tpgListe2.Controls.Add(this.panListe2Top);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(969, 353);
            this.tpgListe2.TabIndex = 1;
            this.tpgListe2.Title = "Fehlerhafte Einzelposten";
            //
            // grdKbWVEinzelpostenFehler
            //
            this.grdKbWVEinzelpostenFehler.DataSource = this.qryKbWVEinzelpostenFehler;
            this.grdKbWVEinzelpostenFehler.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdKbWVEinzelpostenFehler.EmbeddedNavigator.Name = "";
            this.grdKbWVEinzelpostenFehler.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbWVEinzelpostenFehler.Location = new System.Drawing.Point(0, 31);
            this.grdKbWVEinzelpostenFehler.MainView = this.grvKbWVEinzelpostenFehler;
            this.grdKbWVEinzelpostenFehler.Name = "grdKbWVEinzelpostenFehler";
            this.grdKbWVEinzelpostenFehler.Size = new System.Drawing.Size(969, 322);
            this.grdKbWVEinzelpostenFehler.TabIndex = 1;
            this.grdKbWVEinzelpostenFehler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbWVEinzelpostenFehler});
            //
            // qryKbWVEinzelpostenFehler
            //
            this.qryKbWVEinzelpostenFehler.HostControl = this;
            this.qryKbWVEinzelpostenFehler.SelectStatement = resources.GetString("qryKbWVEinzelpostenFehler.SelectStatement");
            this.qryKbWVEinzelpostenFehler.TableName = "KbWVEinzelpostenFehler";
            this.qryKbWVEinzelpostenFehler.AfterFill += new System.EventHandler(this.qryKbWVEinzelpostenFehler_AfterFill);
            this.qryKbWVEinzelpostenFehler.PositionChanged += new System.EventHandler(this.qryKbWVEinzelpostenFehler_PositionChanged);
            //
            // grvKbWVEinzelpostenFehler
            //
            this.grvKbWVEinzelpostenFehler.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbWVEinzelpostenFehler.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.Empty.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbWVEinzelpostenFehler.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbWVEinzelpostenFehler.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbWVEinzelpostenFehler.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbWVEinzelpostenFehler.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbWVEinzelpostenFehler.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbWVEinzelpostenFehler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbWVEinzelpostenFehler.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbWVEinzelpostenFehler.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbWVEinzelpostenFehler.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbWVEinzelpostenFehler.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.OddRow.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbWVEinzelpostenFehler.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.Row.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.Appearance.Row.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVEinzelpostenFehler.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbWVEinzelpostenFehler.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbWVEinzelpostenFehler.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbWVEinzelpostenFehler.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbWVEinzelpostenFehler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEinzelpostenFehlerWVLaufID,
            this.colEinzelpostenFehlerKbBuchungKostenartID,
            this.colEinzelpostenFehlerPerson,
            this.colEinzelpostenFehlerKostenart,
            this.colEinzelpostenFehlerBetrag,
            this.colEinzelpostenFehlerBuchungstext,
            this.colEinzelpostenFehlerWVFehlermeldung});
            this.grvKbWVEinzelpostenFehler.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbWVEinzelpostenFehler.GridControl = this.grdKbWVEinzelpostenFehler;
            this.grvKbWVEinzelpostenFehler.Name = "grvKbWVEinzelpostenFehler";
            this.grvKbWVEinzelpostenFehler.OptionsBehavior.Editable = false;
            this.grvKbWVEinzelpostenFehler.OptionsCustomization.AllowFilter = false;
            this.grvKbWVEinzelpostenFehler.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbWVEinzelpostenFehler.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbWVEinzelpostenFehler.OptionsNavigation.UseTabKey = false;
            this.grvKbWVEinzelpostenFehler.OptionsView.ColumnAutoWidth = false;
            this.grvKbWVEinzelpostenFehler.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbWVEinzelpostenFehler.OptionsView.ShowFooter = true;
            this.grvKbWVEinzelpostenFehler.OptionsView.ShowGroupPanel = false;
            this.grvKbWVEinzelpostenFehler.OptionsView.ShowIndicator = false;
            //
            // colEinzelpostenFehlerWVLaufID
            //
            this.colEinzelpostenFehlerWVLaufID.Caption = "WV-Lauf ID";
            this.colEinzelpostenFehlerWVLaufID.FieldName = "KbWVLaufID";
            this.colEinzelpostenFehlerWVLaufID.Name = "colEinzelpostenFehlerWVLaufID";
            this.colEinzelpostenFehlerWVLaufID.Visible = true;
            this.colEinzelpostenFehlerWVLaufID.VisibleIndex = 0;
            this.colEinzelpostenFehlerWVLaufID.Width = 71;
            //
            // colEinzelpostenFehlerKbBuchungKostenartID
            //
            this.colEinzelpostenFehlerKbBuchungKostenartID.Caption = "KbBuchungKostenartID";
            this.colEinzelpostenFehlerKbBuchungKostenartID.FieldName = "KbBuchungKostenartID";
            this.colEinzelpostenFehlerKbBuchungKostenartID.Name = "colEinzelpostenFehlerKbBuchungKostenartID";
            this.colEinzelpostenFehlerKbBuchungKostenartID.Visible = true;
            this.colEinzelpostenFehlerKbBuchungKostenartID.VisibleIndex = 1;
            this.colEinzelpostenFehlerKbBuchungKostenartID.Width = 138;
            //
            // colEinzelpostenFehlerPerson
            //
            this.colEinzelpostenFehlerPerson.Caption = "Person";
            this.colEinzelpostenFehlerPerson.FieldName = "Person";
            this.colEinzelpostenFehlerPerson.Name = "colEinzelpostenFehlerPerson";
            this.colEinzelpostenFehlerPerson.Visible = true;
            this.colEinzelpostenFehlerPerson.VisibleIndex = 2;
            this.colEinzelpostenFehlerPerson.Width = 190;
            //
            // colEinzelpostenFehlerKostenart
            //
            this.colEinzelpostenFehlerKostenart.Caption = "Kostenart";
            this.colEinzelpostenFehlerKostenart.FieldName = "Kostenart";
            this.colEinzelpostenFehlerKostenart.Name = "colEinzelpostenFehlerKostenart";
            this.colEinzelpostenFehlerKostenart.Visible = true;
            this.colEinzelpostenFehlerKostenart.VisibleIndex = 3;
            this.colEinzelpostenFehlerKostenart.Width = 190;
            //
            // colEinzelpostenFehlerBetrag
            //
            this.colEinzelpostenFehlerBetrag.Caption = "Betrag";
            this.colEinzelpostenFehlerBetrag.DisplayFormat.FormatString = "#.00";
            this.colEinzelpostenFehlerBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinzelpostenFehlerBetrag.FieldName = "Betrag";
            this.colEinzelpostenFehlerBetrag.Name = "colEinzelpostenFehlerBetrag";
            this.colEinzelpostenFehlerBetrag.Visible = true;
            this.colEinzelpostenFehlerBetrag.VisibleIndex = 4;
            this.colEinzelpostenFehlerBetrag.Width = 90;
            //
            // colEinzelpostenFehlerBuchungstext
            //
            this.colEinzelpostenFehlerBuchungstext.Caption = "Buchungstext";
            this.colEinzelpostenFehlerBuchungstext.FieldName = "Buchungstext";
            this.colEinzelpostenFehlerBuchungstext.Name = "colEinzelpostenFehlerBuchungstext";
            this.colEinzelpostenFehlerBuchungstext.Visible = true;
            this.colEinzelpostenFehlerBuchungstext.VisibleIndex = 5;
            this.colEinzelpostenFehlerBuchungstext.Width = 190;
            //
            // colEinzelpostenFehlerWVFehlermeldung
            //
            this.colEinzelpostenFehlerWVFehlermeldung.Caption = "Fehlermeldung";
            this.colEinzelpostenFehlerWVFehlermeldung.FieldName = "WVFehlermeldung";
            this.colEinzelpostenFehlerWVFehlermeldung.Name = "colEinzelpostenFehlerWVFehlermeldung";
            this.colEinzelpostenFehlerWVFehlermeldung.Visible = true;
            this.colEinzelpostenFehlerWVFehlermeldung.VisibleIndex = 6;
            this.colEinzelpostenFehlerWVFehlermeldung.Width = 400;
            //
            // panListe2Top
            //
            this.panListe2Top.Controls.Add(this.edtHiddenKbWVEinzelpostenFehlerID);
            this.panListe2Top.Controls.Add(this.lblGefundeneEPFCount);
            this.panListe2Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panListe2Top.Location = new System.Drawing.Point(0, 0);
            this.panListe2Top.Name = "panListe2Top";
            this.panListe2Top.Size = new System.Drawing.Size(969, 31);
            this.panListe2Top.TabIndex = 0;
            //
            // edtHiddenKbWVEinzelpostenFehlerID
            //
            this.edtHiddenKbWVEinzelpostenFehlerID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHiddenKbWVEinzelpostenFehlerID.DataMember = "KbWVEinzelpostenFehlerID";
            this.edtHiddenKbWVEinzelpostenFehlerID.DataSource = this.qryKbWVEinzelpostenFehler;
            this.edtHiddenKbWVEinzelpostenFehlerID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHiddenKbWVEinzelpostenFehlerID.Location = new System.Drawing.Point(866, 3);
            this.edtHiddenKbWVEinzelpostenFehlerID.Name = "edtHiddenKbWVEinzelpostenFehlerID";
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.Appearance.Options.UseBackColor = true;
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.Appearance.Options.UseFont = true;
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHiddenKbWVEinzelpostenFehlerID.Properties.ReadOnly = true;
            this.edtHiddenKbWVEinzelpostenFehlerID.Size = new System.Drawing.Size(100, 24);
            this.edtHiddenKbWVEinzelpostenFehlerID.TabIndex = 1;
            this.edtHiddenKbWVEinzelpostenFehlerID.Visible = false;
            //
            // lblGefundeneEPFCount
            //
            this.lblGefundeneEPFCount.Location = new System.Drawing.Point(3, 3);
            this.lblGefundeneEPFCount.Name = "lblGefundeneEPFCount";
            this.lblGefundeneEPFCount.Size = new System.Drawing.Size(231, 24);
            this.lblGefundeneEPFCount.TabIndex = 0;
            this.lblGefundeneEPFCount.Text = "Gefundene Einzelposten: <Count>";
            this.lblGefundeneEPFCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGefundeneEPFCount.UseCompatibleTextRendering = true;
            //
            // lblSucheKbWVLaufID
            //
            this.lblSucheKbWVLaufID.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKbWVLaufID.Name = "lblSucheKbWVLaufID";
            this.lblSucheKbWVLaufID.Size = new System.Drawing.Size(120, 24);
            this.lblSucheKbWVLaufID.TabIndex = 1;
            this.lblSucheKbWVLaufID.Text = "WV-Lauf";
            this.lblSucheKbWVLaufID.UseCompatibleTextRendering = true;
            //
            // grdKbWVLauf
            //
            this.grdKbWVLauf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKbWVLauf.DataSource = this.qryKbWVLauf;
            //
            //
            //
            this.grdKbWVLauf.EmbeddedNavigator.Name = "";
            this.grdKbWVLauf.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbWVLauf.Location = new System.Drawing.Point(157, 40);
            this.grdKbWVLauf.MainView = this.grvKbWVLauf;
            this.grdKbWVLauf.Name = "grdKbWVLauf";
            this.grdKbWVLauf.Size = new System.Drawing.Size(808, 139);
            this.grdKbWVLauf.TabIndex = 2;
            this.grdKbWVLauf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbWVLauf});
            //
            // qryKbWVLauf
            //
            this.qryKbWVLauf.HostControl = this;
            this.qryKbWVLauf.SelectStatement = resources.GetString("qryKbWVLauf.SelectStatement");
            this.qryKbWVLauf.TableName = "KbWVLauf";
            this.qryKbWVLauf.PositionChanged += new System.EventHandler(this.qryKbWVLauf_PositionChanged);
            //
            // grvKbWVLauf
            //
            this.grvKbWVLauf.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbWVLauf.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.Empty.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbWVLauf.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbWVLauf.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbWVLauf.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbWVLauf.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbWVLauf.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbWVLauf.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbWVLauf.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbWVLauf.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbWVLauf.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbWVLauf.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbWVLauf.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbWVLauf.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbWVLauf.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbWVLauf.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbWVLauf.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbWVLauf.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbWVLauf.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.OddRow.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbWVLauf.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.Row.Options.UseBackColor = true;
            this.grvKbWVLauf.Appearance.Row.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbWVLauf.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbWVLauf.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbWVLauf.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbWVLauf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbWVLauf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWVLaufKbWVLaufID,
            this.colWVLaufTestlauf,
            this.colWVLaufUserName,
            this.colWVLaufPeriode,
            this.colWVLaufDatumBisWVLauf,
            this.colWVLaufStartDatum,
            this.colWVLaufAnzahlEinzelposten,
            this.colWVLaufFehler});
            this.grvKbWVLauf.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbWVLauf.GridControl = this.grdKbWVLauf;
            this.grvKbWVLauf.Name = "grvKbWVLauf";
            this.grvKbWVLauf.OptionsBehavior.Editable = false;
            this.grvKbWVLauf.OptionsCustomization.AllowFilter = false;
            this.grvKbWVLauf.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbWVLauf.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbWVLauf.OptionsNavigation.UseTabKey = false;
            this.grvKbWVLauf.OptionsView.ColumnAutoWidth = false;
            this.grvKbWVLauf.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbWVLauf.OptionsView.ShowGroupPanel = false;
            this.grvKbWVLauf.OptionsView.ShowIndicator = false;
            //
            // colWVLaufKbWVLaufID
            //
            this.colWVLaufKbWVLaufID.Caption = "ID";
            this.colWVLaufKbWVLaufID.FieldName = "KbWVLaufID";
            this.colWVLaufKbWVLaufID.Name = "colWVLaufKbWVLaufID";
            this.colWVLaufKbWVLaufID.Visible = true;
            this.colWVLaufKbWVLaufID.VisibleIndex = 0;
            this.colWVLaufKbWVLaufID.Width = 50;
            //
            // colWVLaufTestlauf
            //
            this.colWVLaufTestlauf.Caption = "Testlauf";
            this.colWVLaufTestlauf.FieldName = "Testlauf";
            this.colWVLaufTestlauf.Name = "colWVLaufTestlauf";
            this.colWVLaufTestlauf.Visible = true;
            this.colWVLaufTestlauf.VisibleIndex = 1;
            this.colWVLaufTestlauf.Width = 57;
            //
            // colWVLaufUserName
            //
            this.colWVLaufUserName.Caption = "Benutzer";
            this.colWVLaufUserName.FieldName = "UserLastFirstName";
            this.colWVLaufUserName.Name = "colWVLaufUserName";
            this.colWVLaufUserName.Visible = true;
            this.colWVLaufUserName.VisibleIndex = 2;
            this.colWVLaufUserName.Width = 150;
            //
            // colWVLaufPeriode
            //
            this.colWVLaufPeriode.Caption = "Periode";
            this.colWVLaufPeriode.FieldName = "Periode";
            this.colWVLaufPeriode.Name = "colWVLaufPeriode";
            this.colWVLaufPeriode.Visible = true;
            this.colWVLaufPeriode.VisibleIndex = 3;
            this.colWVLaufPeriode.Width = 200;
            //
            // colWVLaufDatumBisWVLauf
            //
            this.colWVLaufDatumBisWVLauf.Caption = "Datum WV-Lauf";
            this.colWVLaufDatumBisWVLauf.FieldName = "DatumBisWVLauf";
            this.colWVLaufDatumBisWVLauf.Name = "colWVLaufDatumBisWVLauf";
            this.colWVLaufDatumBisWVLauf.Visible = true;
            this.colWVLaufDatumBisWVLauf.VisibleIndex = 4;
            this.colWVLaufDatumBisWVLauf.Width = 96;
            //
            // colWVLaufStartDatum
            //
            this.colWVLaufStartDatum.Caption = "Ausführdatum";
            this.colWVLaufStartDatum.FieldName = "StartDatum";
            this.colWVLaufStartDatum.Name = "colWVLaufStartDatum";
            this.colWVLaufStartDatum.Visible = true;
            this.colWVLaufStartDatum.VisibleIndex = 5;
            this.colWVLaufStartDatum.Width = 96;
            //
            // colWVLaufAnzahlEinzelposten
            //
            this.colWVLaufAnzahlEinzelposten.Caption = "Einzelposten";
            this.colWVLaufAnzahlEinzelposten.FieldName = "AnzahlEinzelposten";
            this.colWVLaufAnzahlEinzelposten.Name = "colWVLaufAnzahlEinzelposten";
            this.colWVLaufAnzahlEinzelposten.Visible = true;
            this.colWVLaufAnzahlEinzelposten.VisibleIndex = 6;
            this.colWVLaufAnzahlEinzelposten.Width = 83;
            //
            // colWVLaufFehler
            //
            this.colWVLaufFehler.Caption = "Fehler";
            this.colWVLaufFehler.FieldName = "AnzahlFehler";
            this.colWVLaufFehler.Name = "colWVLaufFehler";
            this.colWVLaufFehler.Visible = true;
            this.colWVLaufFehler.VisibleIndex = 7;
            this.colWVLaufFehler.Width = 47;
            //
            // lblSucheEinzelpostenStatus
            //
            this.lblSucheEinzelpostenStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheEinzelpostenStatus.Location = new System.Drawing.Point(31, 188);
            this.lblSucheEinzelpostenStatus.Name = "lblSucheEinzelpostenStatus";
            this.lblSucheEinzelpostenStatus.Size = new System.Drawing.Size(120, 24);
            this.lblSucheEinzelpostenStatus.TabIndex = 3;
            this.lblSucheEinzelpostenStatus.Text = "Status";
            this.lblSucheEinzelpostenStatus.UseCompatibleTextRendering = true;
            //
            // edtSucheEinzelpostenStatus
            //
            this.edtSucheEinzelpostenStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheEinzelpostenStatus.Location = new System.Drawing.Point(157, 188);
            this.edtSucheEinzelpostenStatus.LOVName = "KbWVEinzelpostenStatus";
            this.edtSucheEinzelpostenStatus.Name = "edtSucheEinzelpostenStatus";
            this.edtSucheEinzelpostenStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheEinzelpostenStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheEinzelpostenStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinzelpostenStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheEinzelpostenStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheEinzelpostenStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheEinzelpostenStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheEinzelpostenStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinzelpostenStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheEinzelpostenStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheEinzelpostenStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheEinzelpostenStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheEinzelpostenStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheEinzelpostenStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheEinzelpostenStatus.Properties.DisplayMember = "Text";
            this.edtSucheEinzelpostenStatus.Properties.NullText = "";
            this.edtSucheEinzelpostenStatus.Properties.ShowFooter = false;
            this.edtSucheEinzelpostenStatus.Properties.ShowHeader = false;
            this.edtSucheEinzelpostenStatus.Properties.ValueMember = "Code";
            this.edtSucheEinzelpostenStatus.Size = new System.Drawing.Size(222, 24);
            this.edtSucheEinzelpostenStatus.TabIndex = 4;
            //
            // lblSucheBaPerson
            //
            this.lblSucheBaPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheBaPerson.Location = new System.Drawing.Point(31, 218);
            this.lblSucheBaPerson.Name = "lblSucheBaPerson";
            this.lblSucheBaPerson.Size = new System.Drawing.Size(120, 24);
            this.lblSucheBaPerson.TabIndex = 5;
            this.lblSucheBaPerson.Text = "Person";
            this.lblSucheBaPerson.UseCompatibleTextRendering = true;
            //
            // edtSucheBaPerson
            //
            this.edtSucheBaPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheBaPerson.Location = new System.Drawing.Point(157, 218);
            this.edtSucheBaPerson.Name = "edtSucheBaPerson";
            this.edtSucheBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheBaPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBaPerson.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheBaPerson.Size = new System.Drawing.Size(222, 24);
            this.edtSucheBaPerson.TabIndex = 6;
            this.edtSucheBaPerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheBaPerson_UserModifiedFld);
            //
            // lblSucheHeimatKantonNr
            //
            this.lblSucheHeimatKantonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheHeimatKantonNr.Location = new System.Drawing.Point(31, 248);
            this.lblSucheHeimatKantonNr.Name = "lblSucheHeimatKantonNr";
            this.lblSucheHeimatKantonNr.Size = new System.Drawing.Size(120, 24);
            this.lblSucheHeimatKantonNr.TabIndex = 7;
            this.lblSucheHeimatKantonNr.Text = "Heimatkanton Nr.";
            this.lblSucheHeimatKantonNr.UseCompatibleTextRendering = true;
            //
            // edtSucheHeimatKantonNr
            //
            this.edtSucheHeimatKantonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheHeimatKantonNr.Location = new System.Drawing.Point(157, 248);
            this.edtSucheHeimatKantonNr.Name = "edtSucheHeimatKantonNr";
            this.edtSucheHeimatKantonNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheHeimatKantonNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheHeimatKantonNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheHeimatKantonNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheHeimatKantonNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheHeimatKantonNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheHeimatKantonNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheHeimatKantonNr.Properties.MaxLength = 50;
            this.edtSucheHeimatKantonNr.Size = new System.Drawing.Size(222, 24);
            this.edtSucheHeimatKantonNr.TabIndex = 8;
            //
            // lblSucheWohnKantonNr
            //
            this.lblSucheWohnKantonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheWohnKantonNr.Location = new System.Drawing.Point(31, 278);
            this.lblSucheWohnKantonNr.Name = "lblSucheWohnKantonNr";
            this.lblSucheWohnKantonNr.Size = new System.Drawing.Size(120, 24);
            this.lblSucheWohnKantonNr.TabIndex = 9;
            this.lblSucheWohnKantonNr.Text = "Wohnkanton Nr.";
            this.lblSucheWohnKantonNr.UseCompatibleTextRendering = true;
            //
            // edtSucheWohnKantonNr
            //
            this.edtSucheWohnKantonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheWohnKantonNr.Location = new System.Drawing.Point(157, 278);
            this.edtSucheWohnKantonNr.Name = "edtSucheWohnKantonNr";
            this.edtSucheWohnKantonNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheWohnKantonNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheWohnKantonNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheWohnKantonNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheWohnKantonNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheWohnKantonNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheWohnKantonNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheWohnKantonNr.Properties.MaxLength = 50;
            this.edtSucheWohnKantonNr.Size = new System.Drawing.Size(222, 24);
            this.edtSucheWohnKantonNr.TabIndex = 10;
            //
            // lblSucheKantonKuerzel
            //
            this.lblSucheKantonKuerzel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheKantonKuerzel.Location = new System.Drawing.Point(31, 308);
            this.lblSucheKantonKuerzel.Name = "lblSucheKantonKuerzel";
            this.lblSucheKantonKuerzel.Size = new System.Drawing.Size(120, 24);
            this.lblSucheKantonKuerzel.TabIndex = 11;
            this.lblSucheKantonKuerzel.Text = "Kanton Kürzel";
            this.lblSucheKantonKuerzel.UseCompatibleTextRendering = true;
            //
            // edtSucheKantonKuerzel
            //
            this.edtSucheKantonKuerzel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheKantonKuerzel.Location = new System.Drawing.Point(157, 308);
            this.edtSucheKantonKuerzel.Name = "edtSucheKantonKuerzel";
            this.edtSucheKantonKuerzel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKantonKuerzel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKantonKuerzel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKantonKuerzel.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKantonKuerzel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKantonKuerzel.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKantonKuerzel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheKantonKuerzel.Properties.MaxLength = 50;
            this.edtSucheKantonKuerzel.Size = new System.Drawing.Size(222, 24);
            this.edtSucheKantonKuerzel.TabIndex = 12;
            //
            // lblSucheBetragVon
            //
            this.lblSucheBetragVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheBetragVon.Location = new System.Drawing.Point(423, 188);
            this.lblSucheBetragVon.Name = "lblSucheBetragVon";
            this.lblSucheBetragVon.Size = new System.Drawing.Size(120, 24);
            this.lblSucheBetragVon.TabIndex = 13;
            this.lblSucheBetragVon.Text = "Betrag";
            this.lblSucheBetragVon.UseCompatibleTextRendering = true;
            //
            // edtSucheBetragVon
            //
            this.edtSucheBetragVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheBetragVon.Location = new System.Drawing.Point(549, 188);
            this.edtSucheBetragVon.Name = "edtSucheBetragVon";
            this.edtSucheBetragVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBetragVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetragVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetragVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetragVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetragVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetragVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetragVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBetragVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBetragVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBetragVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBetragVon.Properties.Precision = 2;
            this.edtSucheBetragVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBetragVon.TabIndex = 14;
            //
            // lblSucheBetragBis
            //
            this.lblSucheBetragBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheBetragBis.Location = new System.Drawing.Point(655, 188);
            this.lblSucheBetragBis.Name = "lblSucheBetragBis";
            this.lblSucheBetragBis.Size = new System.Drawing.Size(10, 24);
            this.lblSucheBetragBis.TabIndex = 15;
            this.lblSucheBetragBis.Text = "-";
            this.lblSucheBetragBis.UseCompatibleTextRendering = true;
            //
            // edtSucheBetragBis
            //
            this.edtSucheBetragBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheBetragBis.Location = new System.Drawing.Point(671, 188);
            this.edtSucheBetragBis.Name = "edtSucheBetragBis";
            this.edtSucheBetragBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBetragBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetragBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetragBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetragBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetragBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetragBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetragBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBetragBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBetragBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBetragBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBetragBis.Properties.Precision = 2;
            this.edtSucheBetragBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBetragBis.TabIndex = 16;
            //
            // lblSucheSplittingArt
            //
            this.lblSucheSplittingArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheSplittingArt.Location = new System.Drawing.Point(423, 218);
            this.lblSucheSplittingArt.Name = "lblSucheSplittingArt";
            this.lblSucheSplittingArt.Size = new System.Drawing.Size(120, 24);
            this.lblSucheSplittingArt.TabIndex = 17;
            this.lblSucheSplittingArt.Text = "Splittingart";
            this.lblSucheSplittingArt.UseCompatibleTextRendering = true;
            //
            // edtSucheSplittingArt
            //
            this.edtSucheSplittingArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheSplittingArt.Location = new System.Drawing.Point(549, 218);
            this.edtSucheSplittingArt.LOVName = "BgSplittingart";
            this.edtSucheSplittingArt.Name = "edtSucheSplittingArt";
            this.edtSucheSplittingArt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSplittingArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSplittingArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSplittingArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSplittingArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSplittingArt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSplittingArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheSplittingArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSplittingArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheSplittingArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheSplittingArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheSplittingArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheSplittingArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSplittingArt.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheSplittingArt.Properties.DisplayMember = "Text";
            this.edtSucheSplittingArt.Properties.NullText = "";
            this.edtSucheSplittingArt.Properties.ShowFooter = false;
            this.edtSucheSplittingArt.Properties.ShowHeader = false;
            this.edtSucheSplittingArt.Properties.ValueMember = "Code";
            this.edtSucheSplittingArt.Size = new System.Drawing.Size(222, 24);
            this.edtSucheSplittingArt.TabIndex = 18;
            //
            // lblSucheBuchungstext
            //
            this.lblSucheBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheBuchungstext.Location = new System.Drawing.Point(423, 248);
            this.lblSucheBuchungstext.Name = "lblSucheBuchungstext";
            this.lblSucheBuchungstext.Size = new System.Drawing.Size(120, 24);
            this.lblSucheBuchungstext.TabIndex = 19;
            this.lblSucheBuchungstext.Text = "Buchungstext";
            this.lblSucheBuchungstext.UseCompatibleTextRendering = true;
            //
            // edtSucheBuchungstext
            //
            this.edtSucheBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheBuchungstext.Location = new System.Drawing.Point(549, 248);
            this.edtSucheBuchungstext.Name = "edtSucheBuchungstext";
            this.edtSucheBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBuchungstext.Properties.MaxLength = 200;
            this.edtSucheBuchungstext.Size = new System.Drawing.Size(222, 24);
            this.edtSucheBuchungstext.TabIndex = 20;
            //
            // lblSucheBemerkungen
            //
            this.lblSucheBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSucheBemerkungen.Location = new System.Drawing.Point(423, 278);
            this.lblSucheBemerkungen.Name = "lblSucheBemerkungen";
            this.lblSucheBemerkungen.Size = new System.Drawing.Size(120, 24);
            this.lblSucheBemerkungen.TabIndex = 21;
            this.lblSucheBemerkungen.Text = "Bemerkungen";
            this.lblSucheBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtSucheBemerkungen
            //
            this.edtSucheBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheBemerkungen.Location = new System.Drawing.Point(549, 278);
            this.edtSucheBemerkungen.Name = "edtSucheBemerkungen";
            this.edtSucheBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkungen.Properties.MaxLength = 200;
            this.edtSucheBemerkungen.Size = new System.Drawing.Size(222, 24);
            this.edtSucheBemerkungen.TabIndex = 22;
            //
            // chkSucheFakturiert
            //
            this.chkSucheFakturiert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSucheFakturiert.EditValue = false;
            this.chkSucheFakturiert.Location = new System.Drawing.Point(549, 311);
            this.chkSucheFakturiert.Name = "chkSucheFakturiert";
            this.chkSucheFakturiert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheFakturiert.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheFakturiert.Properties.Caption = "Fakturiert";
            this.chkSucheFakturiert.Size = new System.Drawing.Size(222, 19);
            this.chkSucheFakturiert.TabIndex = 23;
            //
            // CtlKbWVEinzelposten
            //
            this.ActiveSQLQuery = this.qryKbWVEinzelposten;
            this.Controls.Add(this.grpVorhandeneWVEinzelposten);
            this.Controls.Add(this.grpNeueWVEinzelposten);
            this.Name = "CtlKbWVEinzelposten";
            this.Size = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.CtlKbWVEinzelposten_Load);
            this.Controls.SetChildIndex(this.grpNeueWVEinzelposten, 0);
            this.Controls.SetChildIndex(this.grpVorhandeneWVEinzelposten, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.grpNeueWVEinzelposten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkRunWVTestlauf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumWVLauf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumWVLauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbPeriodeTitel)).EndInit();
            this.grpVorhandeneWVEinzelposten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbWVEinzelposten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBgKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenBgKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenBgKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenKbWVEinzelpostenStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzelPostenKbWVEinzelpostenStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelPostenKbWVEinzelpostenStatus)).EndInit();
            this.panWarningLauf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblWarningLauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarningLauf)).EndInit();
            this.panListeTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHiddenKbWVEinzelpostenID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbWVEinzelposten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbWVEinzelposten)).EndInit();
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKbWVEinzelpostenFehler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbWVEinzelpostenFehler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbWVEinzelpostenFehler)).EndInit();
            this.panListe2Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHiddenKbWVEinzelpostenFehlerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGefundeneEPFCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKbWVLaufID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbWVLauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbWVLauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbWVLauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEinzelpostenStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinzelpostenStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinzelpostenStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHeimatKantonNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHeimatKantonNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheWohnKantonNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheWohnKantonNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKantonKuerzel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKantonKuerzel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSplittingArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSplittingArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSplittingArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheFakturiert.Properties)).EndInit();
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

        private void btnEinzelpostenFakturieren_Click(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // store last cursor
            Cursor lastCursor = Cursor.Current;

            // create list
            List<Int32> selectedIDs = UpdateCounter();
            List<Int32> successfullyUpdatedIDs = new List<Int32>();

            // set flag to refresh list
            bool refreshListAndFinish = false;

            try
            {
                // INIT:
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // VALIDATE:
                // check if any items are selected
                if (selectedIDs.Count < 1)
                {
                    // no item selected, do not continue
                    throw new KissInfoException("Es sind keine Einzelposten ausgewählt, bitte wählen Sie mindestens einen Einzelposten zum Fakturieren.");
                }

                // save pending changes
                if (!qryKbWVEinzelposten.Post())
                {
                    throw new KissInfoException("Die aktuellen Daten konnten nicht gespeichert werden, es kann nicht fortgefahren werden.");
                }

                // PROCESS:
                // set flag
                refreshListAndFinish = true;

                // confirm
                if (!KissMsg.ShowQuestion("CtlKbWVEinzelposten", "ConfirmEinzelpostenFakturieren", "Wollen Sie die gewählten Einzelposten nun für den Ausdruck als 'Fakturiert' markieren?", true))
                {
                    // do not continue
                    return;
                }

                // update each selected entry in database
                foreach (Int32 kbWVEinzelpostenID in selectedIDs)
                {
                    // update entry and set status
                    DBUtil.ExecuteScalarSQL(@"
                        UPDATE WEP
                        SET WEP.KbWVEinzelpostenStatusCode = 3, -- 3='fakturiert' in lov 'KbWVEinzelpostenStatus'
                            WEP.Fakturiert = 1                  -- set flag to prevent changes
                        FROM KbWVEinzelposten WEP
                        WHERE WEP.KbWVEinzelpostenID = {0} AND  -- only one item
                              ISNULL(WEP.Fakturiert, 0) = 0     -- only if not yet set", kbWVEinzelpostenID);

                    // add id to successfully updated items
                    successfullyUpdatedIDs.Add(kbWVEinzelpostenID);
                }
            }
            catch (KissInfoException exi)
            {
                // show info
                KissMsg.ShowInfo(Convert.ToString(exi.Message));
            }
            catch (KissCancelException exc)
            {
                // handle exception
                exc.ShowMessage();
            }
            catch (Exception ex)
            {
                // general exception occured
                KissMsg.ShowError("CtlKbWVEinzelposten", "ErrorBatchFakturieren", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // check if needed
                if (refreshListAndFinish)
                {
                    // refresh list
                    qryKbWVEinzelposten.Refresh();

                    // reselected process-failed-items
                    ReselectProcessFailedItems(selectedIDs, successfullyUpdatedIDs);
                }

                // set focus
                this.grdKbWVEinzelposten.Focus();
            }

            logger.Debug("done");
        }

        private void btnGotoBudget_Click(object sender, System.EventArgs e)
        {
            // check if we have an activesqlquery
            if (this.ActiveSQLQuery == null)
            {
                // no nothing
                return;
            }

            // check if we have any data to use
            if (this.ActiveSQLQuery.Count > 0 && !DBUtil.IsEmpty(this.ActiveSQLQuery["KbBuchungKostenartID"]))
            {
                // get required data
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT FAL.BaPersonID,
                           FLE.ModulID,
                           TreeNodeID = 'CtlWhFinanzplan' + CONVERT(VARCHAR, BFP.BgFinanzplanID) + '\BBG' + CONVERT(VARCHAR, BBG.BgBudgetID)
                    FROM dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED)
                      INNER JOIN dbo.KbBuchung    KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungID = KOA.KbBuchungID
                      INNER JOIN dbo.BgBudget     BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = KBB.BgBudgetID
                      INNER JOIN dbo.BgFinanzplan BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
                      INNER JOIN dbo.FaLeistung   FLE WITH (READUNCOMMITTED) ON FLE.FaLeistungID = BFP.FaLeistungID
                      INNER JOIN dbo.FaFall       FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = FLE.FaFallID
                    WHERE KOA.KbBuchungKostenartID = {0}", this.ActiveSQLQuery["KbBuchungKostenartID"]);

                // check if we found any data
                if (qry.Count == 1)
                {
                    // jump to budget
                    FormController.OpenForm("FrmFall", "Action", "JumpToPath",
                                            "BaPersonID", qry["BaPersonID"],
                                            "ModulID", qry["ModulID"],
                                            "TreeNodeID", qry["TreeNodeID"]);
                }
                else
                {
                    // jump not possible, show info
                    KissMsg.ShowInfo("CtlKbWVEinzelposten", "GotoBudgetNoRowFound", "Es kann nicht ins Monatsbudget gesprungen werden, da die Verknüpfung nicht hergestellt werden kann.");
                }
            }
        }

        private void btnJournalAnzeigen_Click(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // create new instance of dialog
            DlgKbWVJournal dlg = new DlgKbWVJournal(this.GetShownKbWVEinzelpostenIDs());

            // show dialog
            dlg.ShowDialog();

            logger.Debug("done");
        }

        private void btnRunWVLauf_Click(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // INIT:
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // disable checkbox/button
                chkRunWVTestlauf.Enabled = false;
                btnRunWVLauf.Enabled = false;

                // validate kbPeriodeID
                if (this._kbPeriodeID < 1)
                {
                    throw new KissInfoException("Es ist keine gültige Periode definiert, ein WV-Lauf kann nur mit einer gültigen Periode durchgeführt werden.");
                }

                // validate if date is given
                DBUtil.CheckNotNullField(edtDatumWVLauf, lblDatumWVLauf.Text);

                // save pending changes
                if (!qryKbWVEinzelposten.Post())
                {
                    throw new KissInfoException("Die aktuellen Daten konnten nicht gespeichert werden, es kann nicht fortgefahren werden.");
                }

                // confirm
                if (chkRunWVTestlauf.Checked)
                {
                    // info for Testlauf
                    KissMsg.ShowInfo("CtlKbWVEinzelposten", "ConfirmRunWVTestlaufWithTime_v01", "Achtung: Die Erzeugung der neuen Einzelposten für den Testlauf kann einen Moment dauern!");
                }
                else
                {
                    // confirm Echtlauf
                    if (!KissMsg.ShowQuestion("CtlKbWVEinzelposten", "ConfirmRunWVEchtlaufWithTime_v01", "Wollen Sie den nächsten WV-Echtlauf per '{0}' nun starten?\r\n\r\nAchtung: Die Erzeugung der neuen Einzelposten kann einen Moment dauern!", 0, 0, true, edtDatumWVLauf.DateTime.ToShortDateString()))
                    {
                        // do not continue
                        return;
                    }
                }

                // RUN
                // create new query to run statment
                SqlQuery qryNewKbWVEinzelposten = new SqlQuery();
                qryNewKbWVEinzelposten.FillTimeOut = 180; // 180sec = 3min

                // run sql statement and get amount of new einzelposten
                qryNewKbWVEinzelposten.Fill(@"
                    -------------------------------------------------------------------------------
                    -- init vars
                    -------------------------------------------------------------------------------
                    DECLARE @UserID INT
                    DECLARE @KbPeriodeID INT
                    DECLARE @Testlauf BIT
                    DECLARE @DatumBisWVLauf DATETIME

                    DECLARE @Out_KbWVLaufID INT
                    DECLARE @Out_CountNewKbWVEinzelposten INT

                    SET @UserID         = {0}
                    SET @KbPeriodeID    = {1}
                    SET @Testlauf       = {2}
                    SET @DatumBisWVLauf = {3}

                    -------------------------------------------------------------------------------
                    -- run wv-lauf
                    -------------------------------------------------------------------------------
                    EXEC dbo.spKbWVEinzelpostenGenerieren @UserID, @KbPeriodeID, @Testlauf, @DatumBisWVLauf, @Out_KbWVLaufID OUTPUT, @Out_CountNewKbWVEinzelposten OUTPUT

                    -------------------------------------------------------------------------------
                    -- show amount of new created items
                    -------------------------------------------------------------------------------
                    SELECT [KbWVLaufID]          = @Out_KbWVLaufID,
                           [NewKbWVEinzelposten] = @Out_CountNewKbWVEinzelposten", Session.User.UserID, this._kbPeriodeID, chkRunWVTestlauf.Checked, edtDatumWVLauf.EditValue);

                // check if any row was returned
                if (qryNewKbWVEinzelposten.Count != 1)
                {
                    // show error message, this case should not occure
                    KissMsg.ShowError("CtlKbWVEinzelposten", "NoResultAfterGeneratingEP", "Bei der Erstellung der Einzelposten ist ein Fehler aufgetreten. Es wurde kein erwartetes Resultat zurückgeliefert, möglicherweise wurden die Einzelposten nicht korrekt erstellt.");
                    return;
                }

                // everything ok, show message
                KissMsg.ShowInfo("CtlKbWVEinzelposten", "SuccessfullyGeneratedEP", "Die Einzelposten wurden erfolgreich erstellt (insgesamt '{0}' neue Einträge für den WV-Lauf Nr. '{1}').", 0, 0, qryNewKbWVEinzelposten["NewKbWVEinzelposten"], qryNewKbWVEinzelposten["KbWVLaufID"]);
            }
            catch (KissInfoException exi)
            {
                // show info
                KissMsg.ShowInfo(Convert.ToString(exi.Message));
            }
            catch (KissCancelException exc)
            {
                // handle exception
                exc.ShowMessage();
            }
            catch (Exception ex)
            {
                // general exception occured
                KissMsg.ShowError("CtlKbWVEinzelposten", "ErrorDoWVLauf", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // refresh search list and select last entry (only if on search-tab)
                qryKbWVLauf.Refresh();

                if (tabControlSearch.IsTabSelected(tpgSuchen))
                {
                    qryKbWVLauf.Last();
                }

                // set last cursor
                Cursor.Current = lastCursor;

                // reenable checkbox/button
                chkRunWVTestlauf.Enabled = true;
                btnRunWVLauf.Enabled = true;
            }

            logger.Debug("done");
        }

        private void btnSelectAll_Click(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            this.SelectItems(true);

            logger.Debug("done");
        }

        private void btnSelectNone_Click(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            this.SelectItems(false);

            logger.Debug("done");
        }

        private void CtlKbWVEinzelposten_Load(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // move tpgSearch always to the right side
            this.kissSearch.Disabled = true;
            this.tabControlSearch.TabPages.Remove(this.tpgSuchen);
            this.tabControlSearch.TabPages.Add(this.tpgSuchen);
            this.kissSearch.Disabled = false;

            // register query with kissSearch and fill it when kissSearch is filled
            KissSearchFehler = new KissSearch(this.kissSearch, qryKbWVEinzelpostenFehler);

            // init KbPeriodeID
            this._kbPeriodeID = Utils.ConvertToInt(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));

            // DEBUG ONLY
            //this.KbPeriodeID = 30;

            // setup default values
            lblKbPeriode.Text = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT dbo.fnKbGetPeriodeInfo({0}, 'wv', {1})", _kbPeriodeID, Session.User.LanguageCode));

            edtDatumWVLauf.EditValue = DateTime.Now.ToShortDateString();

            // fill dropdown data for kostenart
            SqlQuery qryKostenart = DBUtil.OpenSQL(@"
                SELECT [Code] = KOA.BgKostenartID,
                       [Text] = KOA.Name
                FROM BgKostenart KOA WITH(READUNCOMMITTED)
                WHERE KOA.BaWVZeileCode IS NOT NULL
                ORDER BY [Text], [Code]");

            // setup edtEinzelPostenBgKostenart
            this.edtEinzelPostenBgKostenart.Properties.DropDownRows = Math.Min(qryKostenart.Count, 14);
            this.edtEinzelPostenBgKostenart.Properties.DataSource = qryKostenart;

            // update counter label
            this.UpdateCounter();

            // update grid style
            this.UpdateGridStyle(false);

            // start with new search
            this.NewSearch();

            SetupGrid();

            logger.Debug("done");
        }

        private void edtSucheBaPerson_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(edtSucheBaPerson.Text, e.ButtonClicked);

            // if not canceled, apply values
            if (!e.Cancel)
            {
                edtSucheBaPerson.EditValue = dlg["Name"];
                edtSucheBaPerson.LookupID = dlg["BaPersonID"];
            }
        }

        private void grvKbWVEinzelposten_CustomDrawCell(Object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            // SELECTION: get value for status to determine if selection is possible
            if (e.Column == colEinzelPostenAuswahl)
            {
                // get value for state (cannot be null) >> other column!
                Int32 kbWVEinzelpostenStatusCode = Convert.ToInt32(grvKbWVEinzelposten.GetRowCellValue(e.RowHandle, colEinzelPostenKbWVEinzelpostenStatusCode_Code));
                Boolean fakturiert = Convert.ToBoolean(grvKbWVEinzelposten.GetRowCellValue(e.RowHandle, colEinzelPostenFakturiert));

                // setup edit flag
                Boolean canAlterValue = false;

                // check if user can select item
                if (this.CanSelectEinzelposten(kbWVEinzelpostenStatusCode, fakturiert))
                {
                    // setup flag for editable
                    canAlterValue = true;
                }

                // setup color
                e.Appearance.BackColor = canAlterValue ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;
            }

                // BaWVCode.DatumBis < KbWVEinzelposten.DatumBis: show column-font as red (warning, because change is neccessary)
            else if (e.Column == colEinzelPostenWVCodeDatumBis)
            {
                // check if we have a value
                if (!DBUtil.IsEmpty(grvKbWVEinzelposten.GetRowCellValue(e.RowHandle, colEinzelPostenWVCodeDatumBis)))
                {
                    // get end dates
                    DateTime epDatumBis = Convert.ToDateTime(grvKbWVEinzelposten.GetRowCellValue(e.RowHandle, colEinzelPostenDatumBis));
                    DateTime wvCodeDatumBis = Convert.ToDateTime(grvKbWVEinzelposten.GetRowCellValue(e.RowHandle, colEinzelPostenWVCodeDatumBis));

                    // compare
                    if (epDatumBis > wvCodeDatumBis)
                    {
                        // end of Einzelposten is later than end of BaWVCode, do warn user, setup color depending on warning state
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void grvKbWVEinzelposten_LostFocus(Object sender, EventArgs e)
        {
            // update counter label
            this.UpdateCounter();
        }

        private void grvKbWVEinzelposten_ShowingEditor(object sender, CancelEventArgs e)
        {
            // get cell information
            Int32 focusedRowHandle = grvKbWVEinzelposten.FocusedRowHandle;
            DevExpress.XtraGrid.Columns.GridColumn focusedColumn = grvKbWVEinzelposten.FocusedColumn;

            // get value for state (cannot be null)
            Int32 kbWVEinzelpostenStatusCode = Convert.ToInt32(grvKbWVEinzelposten.GetRowCellValue(focusedRowHandle, colEinzelPostenKbWVEinzelpostenStatusCode_Code.FieldName));
            Boolean fakturiert = Convert.ToBoolean(grvKbWVEinzelposten.GetRowCellValue(focusedRowHandle, colEinzelPostenFakturiert.FieldName));

            // setup edit flag
            Boolean canAlterValue = false;

            // check if user can select item
            if (this.CanSelectEinzelposten(kbWVEinzelpostenStatusCode, fakturiert))
            {
                // setup flag for editable
                canAlterValue = true;
            }

            // set if possible to edit field
            e.Cancel = !canAlterValue;
        }

        private void qryKbWVEinzelposten_AfterDelete(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // update counter of selected items
            UpdateCounter();

            logger.Debug("done");
        }

        private void qryKbWVEinzelposten_AfterFill(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // update edit-fields
            this.UpdateEditFieldsEditMode();

            // update counter label
            this.UpdateCounter();

            // update grid style (because of some buggy behaviour, we do this here with every fill)
            this.UpdateGridStyle(true);

            // update icons on tabpage
            tabControlSearch.ShowIconUpdate();

            logger.Debug("done");
        }

        private void qryKbWVEinzelposten_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // check if user is allowed to delete this item: only items with 'Fakturiert=0' are allowed to be deleted
            if (!DBUtil.IsEmpty(qryKbWVEinzelposten["Fakturiert"]) && Convert.ToBoolean(qryKbWVEinzelposten["Fakturiert"]))
            {
                // this item has flag 'Fakturiert=1' and cannot be deleted anymore
                KissMsg.ShowInfo("CtlKbWVEinzelposten", "CannotDeleteFakturiert", "Einzelposten, welche bereits fakturiert wurden, können nicht mehr gelöscht werden.");
                throw new KissCancelException();
            }

            logger.Debug("done");
        }

        private void qryKbWVEinzelposten_BeforePost(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // validate must-fields
            DBUtil.CheckNotNullField(edtEinzelPostenKbWVEinzelpostenStatus, lblEinzelPostenKbWVEinzelpostenStatus.Text);
            DBUtil.CheckNotNullField(edtEinzelPostenBgKostenart, lblEinzelPostenBgKostenart.Text);
            DBUtil.CheckNotNullField(edtEinzelPostenBetrag, lblEinzelPostenBetrag.Text);

            // apply changed values (non-db-bound)
            qryKbWVEinzelposten["Status"] = edtEinzelPostenKbWVEinzelpostenStatus.Text;
            qryKbWVEinzelposten["Kostenart"] = edtEinzelPostenBgKostenart.Text;

            // depending on state, selection is possible or not
            if (!this.CanSelectEinzelposten(Convert.ToInt32(qryKbWVEinzelposten["KbWVEinzelpostenStatusCode"]), Convert.ToBoolean(qryKbWVEinzelposten["Fakturiert"])))
            {
                // cannot select item
                qryKbWVEinzelposten["Auswahl"] = 0;
            }

            logger.Debug("done");
        }

        // changed
        private void qryKbWVEinzelposten_ColumnChanged(Object sender, DataColumnChangeEventArgs e)
        {
            // get new states
            Boolean isRowModifiedInChanged = qryKbWVEinzelposten.RowModified;
            Boolean isRowSelectedInChanged = !DBUtil.IsEmpty(qryKbWVEinzelposten["Auswahl"]) && Convert.ToBoolean(qryKbWVEinzelposten["Auswahl"]);

            // check if only selection changed, so we do not want to save changes in database
            if (!this._isRowModifiedInChanging && isRowModifiedInChanged &&
                ((this._isRowSelectedInChanging && !isRowSelectedInChanged) || (!this._isRowSelectedInChanging && isRowSelectedInChanged)))
            {
                // ATTENTION: prevent post, only selection has changed, so reset row modified and prevent Post on query
                qryKbWVEinzelposten.Row.AcceptChanges();
                qryKbWVEinzelposten.RowModified = false;
                qryKbWVEinzelposten.RefreshDisplay();
            }
        }

        // changing
        private void qryKbWVEinzelposten_ColumnChanging(Object sender, DataColumnChangeEventArgs e)
        {
            // get current states
            this._isRowModifiedInChanging = qryKbWVEinzelposten.RowModified;
            this._isRowSelectedInChanging = !DBUtil.IsEmpty(qryKbWVEinzelposten["Auswahl"]) && Convert.ToBoolean(qryKbWVEinzelposten["Auswahl"]);
        }

        private void qryKbWVEinzelposten_PositionChanged(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // load icons from current dataset
            ctlGotoFall.BaPersonID = qryKbWVEinzelposten["BaPersonID"];

            // update edit-fields
            UpdateEditFieldsEditMode();

            // update counter label
            this.UpdateCounter();

            logger.Debug("done");
        }

        private void qryKbWVEinzelpostenFehler_AfterFill(object sender, System.EventArgs e)
        {
            // update counter
            lblGefundeneEPFCount.Text = String.Format("Gefundene Einzelposten: {0}", qryKbWVEinzelpostenFehler.Count);
        }

        private void qryKbWVEinzelpostenFehler_PositionChanged(object sender, System.EventArgs e)
        {
            logger.Debug("enter");

            // load icons from current dataset
            ctlGotoFall.BaPersonID = qryKbWVEinzelpostenFehler["BaPersonID"];

            logger.Debug("done");
        }

        private void qryKbWVLauf_PositionChanged(object sender, System.EventArgs e)
        {
            // update state for testlauf/echtlauf
            this.SetupGUIDependingOnLauf();
        }

        private void SetupGrid()
        {
            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenKbWVEinzelpostenStatusCode_Code, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenAuswahl, true);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenKbWVLaufID, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenKbWVEinzelpostenStatusCode, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenFakturiert, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenStornoEintrag, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenSplittingDurchWVLaufDatumBis, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenPerson, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenKostenart, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenBgSplittingArt, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenBetrag, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenDatumVon, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenDatumBis, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenWVCodeDatumBis, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenBuchungstext, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenHeimatkantonNr, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenWohnKantonNr, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenKantonKuerzel, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenAuslandschweizer, false);
                grdKbWVEinzelposten.SetColumnEditable(colEinzelPostenBemerkungen, false);
                grdKbWVEinzelposten.SetSelectionColor(false);
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            logger.Debug("enter");

            // reset active sqlquery to prevent having wrong query
            this.ActiveSQLQuery = null;

            // tabpage depending modes
            if (tabControlSearch.IsTabSelected(tpgListe2))
            {
                // fehlerhafte einzelposten

                // set query as active
                this.ActiveSQLQuery = qryKbWVEinzelpostenFehler;
                qryKbWVEinzelpostenFehler.EnableBoundFields();
            }
            else
            {
                // gültige einzelposten (default)

                // set query as active and setup fields
                this.ActiveSQLQuery = qryKbWVEinzelposten;
                qryKbWVEinzelposten.EnableBoundFields();
            }

            // setup ctlgotofall
            ctlGotoFall.DataSource = null;
            ctlGotoFall.DataSource = this.ActiveSQLQuery;

            // if search is selected, reset icons
            if (tabControlSearch.IsTabSelected(tpgSuchen) || this.ActiveSQLQuery == null)
            {
                // no icons
                ctlGotoFall.ResetFallIcons();
            }
            else
            {
                // apply current bapersonid
                ctlGotoFall.BaPersonID = this.ActiveSQLQuery["BaPersonID"];
            }

            // update edit-fields
            UpdateEditFieldsEditMode();

            logger.Debug("done");
        }

        private void tabControlSearch_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            logger.Debug("enter");

            // save changes and allow to switch tab only if ok
            e.Cancel = !SavePendingChanges();

            logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Methods

        public override String GetContextName()
        {
            return String.Format("KbZUGAbrechnung");
        }

        public override Object GetContextValue(String FieldName)
        {
            // determine values
            Boolean isListe1Selected = tabControlSearch.IsTabSelected(tpgListe);
            Boolean hasDataEP = qryKbWVEinzelposten.Count > 0;

            // can only return value if data is ok
            if (!isListe1Selected || !hasDataEP)
            {
                // no data, show information and cancel
                KissMsg.ShowInfo("CtlKbWVEinzelposten", "NoDataForContextValue", "Es wurden keine gültigen Einzelposten gefunden, welche ausgedruckt werden können. Bitte führen Sie zuerst eine entsprechende Suche durch.");
                throw new KissCancelException();
            }

            // get requested FieldName
            switch (FieldName.ToUpper())
            {
                case "KBWVLAUFID":
                    return qryKbWVLauf["KbWVLaufID"];

                case "KBWVEINZELPOSTENIDS":
                    return this.GetShownKbWVEinzelpostenIDs();
            }

            // return value from base
            return base.GetContextValue(FieldName);
        }

        public override void OnRefreshData()
        {
            // let base do stuff first
            base.OnRefreshData();

            // refresh KbWVLauf-table, too
            qryKbWVLauf.Refresh();

            // refresh gui
            SetupGUIDependingOnLauf();
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage("CtlKbWVEinzelposten", "List1Caption", "Gültige Einzelposten");
            tpgListe2.Title = KissMsg.GetMLMessage("CtlKbWVEinzelposten", "List2Caption", "Fehlerhafte Einzelposten");
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            logger.Debug("enter");

            // let base do stuff
            base.NewSearch();

            // update edit-fields
            UpdateEditFieldsEditMode();

            // reload data of existing KbWVLauf entries and select last entry
            qryKbWVLauf.Fill(Session.User.LanguageCode);
            qryKbWVLauf.Last();

            // set default focus
            grdKbWVLauf.Focus();

            // refresh gui
            SetupGUIDependingOnLauf();

            logger.Debug("done");
        }

        protected override void RunSearch()
        {
            logger.Debug("enter");

            // validate if any wv-lauf is available
            if (qryKbWVLauf.Count < 1)
            {
                // no wv-lauf data found, cannot continue
                KissMsg.ShowInfo("CtlKbWVEinzelposten", "RunSearchNoWVLauf", "Es ist zurzeit kein WV-Lauf vorhanden, zu welchem Einzelposten angezeigt werden könnten. Bitte führen Sie zuerst einen WV-Lauf durch.");
                btnRunWVLauf.Focus();

                throw new KissCancelException();
            }

            // validate if any wv-lauf is selected
            if (DBUtil.IsEmpty(qryKbWVLauf["KbWVLaufID"]))
            {
                // no wv-lauf selected, cannot continue
                KissMsg.ShowInfo("CtlKbWVEinzelposten", "RunSearchNoWVLaufSelected", "Es ist zurzeit kein WV-Lauf ausgewählt, bitte wählen Sie zuerst einen WV-Lauf.");
                grdKbWVLauf.Focus();

                throw new KissCancelException();
            }

            // get id of selected wv-lauf
            Int32 kbWVLaufID = Convert.ToInt32(qryKbWVLauf["KbWVLaufID"]);

            // replace search parameters
            Object[] parameters = new Object[] { kbWVLaufID };
            this.kissSearch.SelectParameters = parameters;
            this.KissSearchFehler.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();

            // after search is done, we setup gui depending on testlauf (true/false)
            this.SetupGUIDependingOnLauf();

            logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private Boolean CanSelectEinzelposten(Int32 kbWVEinzelpostenStatusCode, Boolean fakturiert)
        {
            // for 'Testlauf', none of the items can be selected
            if (this._isCurrentEntryTestlauf)
            {
                // cannot select Einzelposten
                return false;
            }

            // only:
            //   state = 3 ('Fakturiert') and flag Fakturiert = false
            //   or
            //   state = 2 ('Vorbereitet')
            // can be selected by user!
            return (kbWVEinzelpostenStatusCode == 3 && !fakturiert) || kbWVEinzelpostenStatusCode == 2;
        }

        private String GetShownKbWVEinzelpostenIDs()
        {
            // init output var
            String shownIDsCSV = "";
            Int32 shownKbWVEinzelpostenID = -1;

            // loop through show datarows and combine KbWVEinzelpostenIDs as CSV
            // validate if any content
            if (qryKbWVEinzelposten.Count < 1)
            {
                // return inital state
                return shownIDsCSV;
            }

            // loop and collect ids
            foreach (DataRow row in qryKbWVEinzelposten.DataTable.Rows)
            {
                // get id
                shownKbWVEinzelpostenID = Convert.ToInt32(row["KbWVEinzelpostenID"]);

                // check append mode
                if (shownIDsCSV.Length < 1)
                {
                    // no value yet, set just the id
                    shownIDsCSV = Convert.ToString(shownKbWVEinzelpostenID);
                }
                else
                {
                    // we already have some values, append as CSV
                    shownIDsCSV = String.Format("{0},{1}", shownIDsCSV, shownKbWVEinzelpostenID);
                }
            }

            // return shown ids
            return shownIDsCSV;
        }

        private void ReselectProcessFailedItems(List<Int32> selectedIDs, List<Int32> successfullyUpdatedIDs)
        {
            logger.Debug("enter");

            // validate lists
            if (selectedIDs == null || selectedIDs.Count < 1 || successfullyUpdatedIDs == null)
            {
                // do nothing, invalid parameters
                return;
            }

            try
            {
                // check if any row is available
                if (qryKbWVEinzelposten.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                this._preventUpdateDetails = true;

                // save pending changes
                if (!qryKbWVEinzelposten.Post())
                {
                    throw new KissInfoException("Die Daten konnten nicht gespeichert werden, die Auswahl kann nicht verändert werden.");
                }

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // set selection
                foreach (DataRow row in qryKbWVEinzelposten.DataTable.Rows)
                {
                    // check if item was selected before processing
                    if (!DBUtil.IsEmpty(row["KbWVEinzelpostenID"]) && selectedIDs.Contains(Convert.ToInt32(row["KbWVEinzelpostenID"])))
                    {
                        // set flag depending on update success
                        row["Auswahl"] = successfullyUpdatedIDs.Contains(Convert.ToInt32(row["KbWVEinzelpostenID"])) ? 0 : 1;

                        // prevent row modified
                        row.AcceptChanges();
                    }
                }

                // prevent data changed (we did save data above)
                qryKbWVEinzelposten.Row.AcceptChanges();
                qryKbWVEinzelposten.RowModified = false;
                qryKbWVEinzelposten.RefreshDisplay();

                // check if row is selected
                if (this.grvKbWVEinzelposten.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    this.grvKbWVEinzelposten.RefreshRow(this.grvKbWVEinzelposten.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError("CtlKbWVEinzelposten", "ErrorReSelectingItems", "Es ist ein Fehler beim Wiederauswählen der Einzelposten aufgetreten.", ex);
            }
            finally
            {
                // allow update details
                this._preventUpdateDetails = false;

                // update counter label
                this.UpdateCounter();

                // update states
                qryKbWVEinzelposten_PositionChanged(this, EventArgs.Empty);

                // set focus
                this.grdKbWVEinzelposten.Focus();
            }

            logger.Debug("done");
        }

        private bool SavePendingChanges()
        {
            logger.Debug("enter");

            // check if we have an active sqlquery set
            if (this.ActiveSQLQuery != null)
            {
                // we have one, try to save data
                return this.ActiveSQLQuery.Post();
            }

            logger.Debug("done");

            // no problem if no query
            return true;
        }

        private void SelectItems(bool selected)
        {
            logger.Debug("enter");

            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // check if any row is available
                if (qryKbWVEinzelposten.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                this._preventUpdateDetails = true;

                // save pending changes
                if (!qryKbWVEinzelposten.Post())
                {
                    throw new KissInfoException("Die Daten konnten nicht gespeichert werden, die Auswahl kann nicht verändert werden.");
                }

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // set selection
                foreach (DataRow row in qryKbWVEinzelposten.DataTable.Rows)
                {
                    // depending on state, selection is possible or not
                    if (this.CanSelectEinzelposten(Convert.ToInt32(row["KbWVEinzelpostenStatusCode"]), Convert.ToBoolean(row["Fakturiert"])))
                    {
                        // set flag depending on call
                        row["Auswahl"] = selected ? 1 : 0;
                    }
                    else
                    {
                        // cannot select item
                        row["Auswahl"] = 0;
                    }

                    // prevent row modified
                    row.AcceptChanges();
                }

                // prevent data changed (we did save data above)
                qryKbWVEinzelposten.Row.AcceptChanges();
                qryKbWVEinzelposten.RowModified = false;
                qryKbWVEinzelposten.RefreshDisplay();

                // check if row is selected
                if (this.grvKbWVEinzelposten.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    this.grvKbWVEinzelposten.RefreshRow(this.grvKbWVEinzelposten.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                // show error message
                if (selected)
                {
                    // did select
                    KissMsg.ShowError("CtlKbWVEinzelposten", "ErrorSelectingItems", "Es ist ein Fehler beim Auswählen der Einzelposten aufgetreten.", ex);
                }
                else
                {
                    // did unselect
                    KissMsg.ShowError("CtlKbWVEinzelposten", "ErrorUnSelectingItems", "Es ist ein Fehler beim Abwählen der Einzelposten aufgetreten.", ex);
                }
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // allow update details
                this._preventUpdateDetails = false;

                // update counter label
                this.UpdateCounter();

                // update states
                qryKbWVEinzelposten_PositionChanged(this, EventArgs.Empty);

                // set focus
                this.grdKbWVEinzelposten.Focus();
            }

            logger.Debug("done");
        }

        private void SetupGUIDependingOnLauf()
        {
            // init flag
            this._isCurrentEntryTestlauf = true;

            // check if we have any data
            if (qryKbWVLauf.Count < 1)
            {
                // setup for 'no data yet'
                lblWarningLauf.Text = KissMsg.GetMLMessage("CtlKbWVEinzelposten", "InfoKeinLauf_v01", "Info: Kein WV-Lauf vorhanden");

                // set icon
                picWarningLauf.Image = KissImageList.GetSmallImage(81);	// info
            }
            else
            {
                // set depending on current values
                if (!DBUtil.IsEmpty(qryKbWVLauf["Testlauf"]))
                {
                    // set flag depending on db-value
                    this._isCurrentEntryTestlauf = Convert.ToBoolean(qryKbWVLauf["Testlauf"]);
                }

                // setup lists depending on this data
                if (this._isCurrentEntryTestlauf)
                {
                    // setup for 'Testlauf'
                    lblWarningLauf.Text = KissMsg.GetMLMessage("CtlKbWVEinzelposten", "InfoIsTestlauf_v01", "Info: Gewählter WV-Lauf ist ein Testlauf");

                    // set icon
                    picWarningLauf.Image = KissImageList.GetSmallImage(92);	// 'Test'
                }
                else
                {
                    // setup for 'Echtlauf'
                    lblWarningLauf.Text = KissMsg.GetMLMessage("CtlKbWVEinzelposten", "InfoIsEchtlauf_v01", "Info: Gewählter WV-Lauf ist ein Echtlauf");

                    // set icon
                    picWarningLauf.Image = KissImageList.GetSmallImage(90);	// 'Prod'
                }
            }
        }

        private List<int> UpdateCounter()
        {
            logger.Debug("enter");

            // init list
            List<Int32> selectedIDs = new List<Int32>();

            // check if need to do action
            if (this._preventUpdateDetails)
            {
                // do nothing
                return selectedIDs;
            }

            // loop through items and count selected items
            foreach (DataRow row in qryKbWVEinzelposten.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Auswahl"]) && Convert.ToBoolean(row["Auswahl"]))
                {
                    // validate XTaskID
                    if (!DBUtil.IsEmpty(row["KbWVEinzelpostenID"]))
                    {
                        // add id to list
                        selectedIDs.Add(Convert.ToInt32(row["KbWVEinzelpostenID"]));
                    }
                }
            }

            // update label
            this.lblGewaehlteZeilen.Text = String.Format("{0} von {1} Einzelposten ausgewählt", selectedIDs.Count, qryKbWVEinzelposten.Count);

            logger.Debug("done");

            // return selected items
            return selectedIDs;
        }

        private void UpdateEditFieldsEditMode()
        {
            logger.Debug("enter");

            // depending on selected list and rights, the fields can be used or are disabled
            Boolean isListe1Selected = tabControlSearch.IsTabSelected(tpgListe);
            Boolean isListe2Selected = tabControlSearch.IsTabSelected(tpgListe2);
            Boolean hasDataEP = qryKbWVEinzelposten.Count > 0;
            Boolean hasDataEPF = qryKbWVEinzelpostenFehler.Count > 0;
            Boolean canUpdateData = qryKbWVEinzelposten.CanUpdate;
            Boolean isCurrentEntryAlreadyFakturiert = hasDataEP ? Convert.ToBoolean(qryKbWVEinzelposten["Fakturiert"]) : true;

            // setup editmodes
            edtEinzelPostenKbWVEinzelpostenStatus.EditMode = isListe1Selected &&
                                                             hasDataEP &&
                                                             canUpdateData &&
                                                             !isCurrentEntryAlreadyFakturiert &&
                                                             !this._isCurrentEntryTestlauf ? EditModeType.Normal : EditModeType.ReadOnly;

            edtEinzelPostenBgKostenart.EditMode = isListe1Selected &&
                                                  hasDataEP &&
                                                  canUpdateData &&
                                                  !isCurrentEntryAlreadyFakturiert ? EditModeType.Normal : EditModeType.ReadOnly;

            edtEinzelPostenBetrag.EditMode = edtEinzelPostenBgKostenart.EditMode;
            edtEinzelPostenBuchungstext.EditMode = edtEinzelPostenBgKostenart.EditMode;
            edtEinzelPostenBemerkungen.EditMode = edtEinzelPostenBgKostenart.EditMode;

            // enable ctlGotoFall and btnGotoBudget depending on selected tabpage and containing data
            ctlGotoFall.Enabled = (isListe1Selected && hasDataEP) || (isListe2Selected && hasDataEPF);
            btnGotoBudget.Enabled = ctlGotoFall.Enabled;

            // selection buttons only if containing data
            btnSelectAll.Enabled = hasDataEP;
            btnSelectNone.Enabled = hasDataEP;

            // enable btnEinzelpostenFakturieren depending on containing data and testlauf/echtlauf
            btnEinzelpostenFakturieren.Enabled = hasDataEP && !this._isCurrentEntryTestlauf;

            // button is always enabled if data is contained
            btnJournalAnzeigen.Enabled = hasDataEP;

            logger.Debug("done");
        }

        private void UpdateGridStyle(Boolean setSummaryItems)
        {
            // apply colors, they are fix defined in contructor of view and we need readonly behaviour in editable grid
            this.grvKbWVEinzelposten.Appearance.FocusedCell.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            this.grvKbWVEinzelposten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbWVEinzelposten.Appearance.FocusedRow.BackColor = GuiConfig.GridFocusedSelectionBackColor;
            this.grvKbWVEinzelposten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.BackColor = GuiConfig.GridUnfocusedSelectionBackColor;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbWVEinzelposten.Appearance.HideSelectionRow.Options.UseForeColor = true;

            // check if required to set summary items
            if (!setSummaryItems)
            {
                // do not continue
                return;
            }

            // update summary-item because of designers unknown bug
            this.colEinzelpostenFehlerBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colEinzelpostenFehlerBetrag.FieldName = this.colEinzelpostenFehlerBetrag.FieldName;
            this.colEinzelpostenFehlerBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            // update summary-item because of designers unknown bug
            this.colEinzelPostenBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colEinzelPostenBetrag.FieldName = this.colEinzelPostenBetrag.FieldName;
            this.colEinzelPostenBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        }

        #endregion

        #endregion
    }
}