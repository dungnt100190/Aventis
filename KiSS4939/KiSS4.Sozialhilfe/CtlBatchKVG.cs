using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    /// <summary>
    /// Form, used for managing KVG and VVG data of bills (Krankenkassenpraemie)
    /// </summary>
    public class CtlBatchKVG : KissSearchUserControl, IBelegleser
    {
        #region Enumerations

        private enum BgEinzahlungsschein
        {
            ESOrange = 1,
            ESRotPost = 2,
            BankzahlungCH = 3,
            BankzahlungAusland = 4,
            ESRotBank = 5,
            Postmandat = 6
        }

        #endregion

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const int KBBUCHUNGSTATUSCODEFREIGEGEBEN = 2;

        // used to compare state (2=freigegeben)
        private const int VALIDATIONGRADE = 0;

        private readonly int _ezStandardAuszahlungsart = DBUtil.GetConfigInt(@"System\Sozialhilfe\EZStandardAuszahlungsart",
                                                                             Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung)); // default auszahlungsart (101=El.Ausz.||Papierverf.; 106=SIL-Antrag)

        private readonly decimal _maxKVGPerPerson = DBUtil.GetConfigDecimal(@"System\Sozialhilfe\SKOS\KVG_MaxPerPerson", -1);
        private readonly decimal _maxVVGPerPerson = DBUtil.GetConfigDecimal(@"System\Sozialhilfe\SKOS\VVG_MaxPerPerson", -1);

        // 0=kk and kreditor does not matter; 1=kk and kreditor should be the same (warning); 2=kk and kreditor have to be the same (error)

        #endregion

        #region Private Fields

        private bool _canSaveChanges = false; // used to store if changes can be saved
        private int _editBelegID = -1; // used to store current belegid to edit (-1 = none, > 0 = valid)
        private bool _isEditingAuszahlwegData = false; // used to determine state if user is inserting or editing data for a Auszahlweg
        private bool _isOnFillingKK = false; // used to prevent removing last selected row in event
        private int _lastSelectedFaLeistungID = -1; // store last selected FaLeistungID from top-grid
        private int _lastSelectedRowHandle = 0; // store last selectedRowHandle to reselect after refresh/refill data
        private int _splittingArtCode = -1; // used to store system splittingartcode
        private KiSS4.Gui.KissButton btnElAuszahlungLoeschen;
        private KissButton btnFreigeben;
        private KissButton btnGotoFinanzPlan;
        private KiSS4.Gui.KissButton btnSILAntragBearbeiten;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKBemerkung;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKBgKVG;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKBgKVGMax;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKBgKVGMaxStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKBgKVGStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKBgVVG;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKBgVVGStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKKVGButton;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKKVGMaxButton;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKKrankenkasse;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKMonatsbudget;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKPerson;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKVVGButton;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKZahlungKVG;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKZahlungKVGMax;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKZahlungKVGMaxStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKZahlungKVGStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKZahlungVVG;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKKZahlungVVGStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation;
        private KiSS4.Gui.KissLookUpEdit edtAuszahlungsart;
        private KiSS4.Gui.KissDateEdit edtBelegDatum;
        private KiSS4.Gui.KissCalcEdit edtBelegID;
        private KiSS4.Gui.KissCalcEdit edtBelegNr;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissButtonEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile1;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile2;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile3;
        private KissTextEdit edtPerson;
        private KiSS4.Gui.KissDateEdit edtRechnungDatum;
        private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
        private KiSS4.Gui.KissCalcEdit edtRestbetrag;
        private KiSS4.Gui.KissLookUpEdit edtSplittingArtCode;
        private KiSS4.Gui.KissButtonEdit edtSucheFalltraeger;
        private KiSS4.Gui.KissCalcEdit edtSucheJahr;
        private KiSS4.Gui.KissCalcEdit edtSucheMonat;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissCalcEdit edtSuchePositionID;
        private KiSS4.Gui.KissButtonEdit edtSucheSAR;
        private KiSS4.Gui.KissCalcEdit edtTotalbetrag;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissMemoEdit edtZusatzInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbBudget;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbZahlung;
        private KiSS4.Gui.KissGrid grdFalltraeger;
        private KiSS4.Gui.KissGrid grdKrankenkasse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFalltraeger;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvKrankenkasse;
        private KiSS4.Gui.KissLabel lblAuszahlungsart;
        private KiSS4.Gui.KissLabel lblBelegDatum;
        private KiSS4.Gui.KissLabel lblBelegID;
        private KiSS4.Gui.KissLabel lblBelegNr;
        private KiSS4.Gui.KissLabel lblBgSplittingCode;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KissLabel lblFalltraeger;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblRechnungDatum;
        private KiSS4.Gui.KissLabel lblReferenzNummer;
        private KiSS4.Gui.KissLabel lblRestbetrag;
        private KiSS4.Gui.KissLabel lblRestbetragCHF;
        private KiSS4.Gui.KissLabel lblSucheFalltraeger;
        private KiSS4.Gui.KissLabel lblSucheJahr;
        private KiSS4.Gui.KissLabel lblSucheMonat;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSuchePositionID;
        private KiSS4.Gui.KissLabel lblSucheSAR;
        private KiSS4.Gui.KissLabel lblTotalbetrag;
        private KiSS4.Gui.KissLabel lblTotalbetragCHF;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblVerwPeriode;
        private KiSS4.Gui.KissLabel lblVerwPeriodeStrich;
        private KiSS4.Gui.KissLabel lblZahlungsgrund;
        private Panel panDetails;
        private Panel panDetailsDetails;
        private Panel panDetailsFT;
        private Panel panSetStatus;
        private Panel panSetStatusBorder;
        private KiSS4.DB.SqlQuery qryAuszahlweg;
        private KiSS4.DB.SqlQuery qryFall;
        private KiSS4.DB.SqlQuery qryKrankenkasse;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repItemBtnKVG;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repItemBtnKVGMax;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repItemBtnVVG;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repItemStatusImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repItemZahlung;
        private KissSplitterCollapsible splitter;
        private ToolTip ttpControls;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBatchKVG"/> class.
        /// </summary>
        public CtlBatchKVG()
        {
            this.InitializeComponent();

            // falls user recht zur auswahl kreditoren besitzt, kann El.Auszahlung gewählt werden, sonst nur SIL-Antrag
            // El.Auszahlung||Papierverfuegung and SIL-Antrag are possible to display
            edtAuszahlungsart.LOVFilterWhereAppend = true;
            edtAuszahlungsart.LOVFilter = string.Format("Code IN ({0}, {1})",
                                                        _ezStandardAuszahlungsart,
                                                        Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag));

            ////// fix default ausz.art
            ////if (_ezStandardAuszahlungsart == Convert.ToInt32(FrmWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung) ||
            ////    _ezStandardAuszahlungsart == Convert.ToInt32(FrmWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung))
            ////{
            ////    // setup depending on having klibu
            ////    _ezStandardAuszahlungsart = FrmWhAuszahlungen.GetAuszArtElAuszOrPaperInt();
            ////}

            // setup controls for multilanguage handling
            SetupControlsML();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBatchKVG));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.grdFalltraeger = new KiSS4.Gui.KissGrid();
            this.qryFall = new KiSS4.DB.SqlQuery();
            this.grvFalltraeger = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSuchePositionID = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheFalltraeger = new KiSS4.Gui.KissButtonEdit();
            this.lblSuchePositionID = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.edtSucheSAR = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheFalltraeger = new KiSS4.Gui.KissLabel();
            this.edtSucheMonat = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheSAR = new KiSS4.Gui.KissLabel();
            this.lblSucheMonat = new KiSS4.Gui.KissLabel();
            this.lblSucheJahr = new KiSS4.Gui.KissLabel();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.grdKrankenkasse = new KiSS4.Gui.KissGrid();
            this.qryKrankenkasse = new KiSS4.DB.SqlQuery();
            this.grvKrankenkasse = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.grbBudget = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKKMonatsbudget = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKKrankenkasse = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKPerson = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKBgKVG = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKBgKVGStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repItemStatusImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colKKKVGButton = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repItemBtnKVG = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colKKBgKVGMax = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKBgKVGMaxStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKKVGMaxButton = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repItemBtnKVGMax = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colKKBgVVG = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKBgVVGStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKVVGButton = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repItemBtnVVG = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grbZahlung = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKKZahlungKVG = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repItemZahlung = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colKKZahlungKVGStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKZahlungKVGMax = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKZahlungKVGMaxStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKZahlungVVG = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKZahlungVVGStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKKBemerkung = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnSILAntragBearbeiten = new KiSS4.Gui.KissButton();
            this.btnElAuszahlungLoeschen = new KiSS4.Gui.KissButton();
            this.lblAuszahlungsart = new KiSS4.Gui.KissLabel();
            this.edtAuszahlungsart = new KiSS4.Gui.KissLookUpEdit();
            this.qryAuszahlweg = new KiSS4.DB.SqlQuery();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblRechnungDatum = new KiSS4.Gui.KissLabel();
            this.edtRechnungDatum = new KiSS4.Gui.KissDateEdit();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.edtKreditor = new KiSS4.Gui.KissButtonEdit();
            this.edtZusatzInfo = new KiSS4.Gui.KissMemoEdit();
            this.lblReferenzNummer = new KiSS4.Gui.KissLabel();
            this.edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit();
            this.lblTotalbetrag = new KiSS4.Gui.KissLabel();
            this.edtTotalbetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblTotalbetragCHF = new KiSS4.Gui.KissLabel();
            this.lblRestbetrag = new KiSS4.Gui.KissLabel();
            this.edtRestbetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblRestbetragCHF = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblZahlungsgrund = new KiSS4.Gui.KissLabel();
            this.edtMitteilungZeile1 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilungZeile2 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilungZeile3 = new KiSS4.Gui.KissTextEdit();
            this.lblVerwPeriode = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriodeStrich = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.lblBgSplittingCode = new KiSS4.Gui.KissLabel();
            this.edtSplittingArtCode = new KiSS4.Gui.KissLookUpEdit();
            this.ctlErfassungMutation = new KiSS4.Common.CtlErfassungMutation();
            this.lblBelegID = new KiSS4.Gui.KissLabel();
            this.edtBelegID = new KiSS4.Gui.KissCalcEdit();
            this.lblBelegNr = new KiSS4.Gui.KissLabel();
            this.edtBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.lblBelegDatum = new KiSS4.Gui.KissLabel();
            this.edtBelegDatum = new KiSS4.Gui.KissDateEdit();
            this.panDetails = new System.Windows.Forms.Panel();
            this.panDetailsDetails = new System.Windows.Forms.Panel();
            this.panSetStatus = new System.Windows.Forms.Panel();
            this.panSetStatusBorder = new System.Windows.Forms.Panel();
            this.btnFreigeben = new KiSS4.Gui.KissButton();
            this.panDetailsFT = new System.Windows.Forms.Panel();
            this.edtPerson = new KiSS4.Gui.KissTextEdit();
            this.lblFalltraeger = new KiSS4.Gui.KissLabel();
            this.btnGotoFinanzPlan = new KiSS4.Gui.KissButton();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.ttpControls = new System.Windows.Forms.ToolTip();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePositionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFalltraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePositionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKrankenkasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKrankenkasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKrankenkasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemStatusImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnKVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnKVGMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnVVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemZahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAuszahlweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalbetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalbetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalbetragCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRestbetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRestbetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRestbetragCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplittingArtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplittingArtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).BeginInit();
            this.panDetails.SuspendLayout();
            this.panDetailsDetails.SuspendLayout();
            this.panSetStatus.SuspendLayout();
            this.panDetailsFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFalltraeger)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(968, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(992, 180);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdFalltraeger);
            this.tpgListe.Size = new System.Drawing.Size(980, 142);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheJahr);
            this.tpgSuchen.Controls.Add(this.lblSucheMonat);
            this.tpgSuchen.Controls.Add(this.lblSucheSAR);
            this.tpgSuchen.Controls.Add(this.edtSucheJahr);
            this.tpgSuchen.Controls.Add(this.edtSucheMonat);
            this.tpgSuchen.Controls.Add(this.lblSucheFalltraeger);
            this.tpgSuchen.Controls.Add(this.edtSucheSAR);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSuchePositionID);
            this.tpgSuchen.Controls.Add(this.edtSucheFalltraeger);
            this.tpgSuchen.Controls.Add(this.edtSuchePositionID);
            this.tpgSuchen.Size = new System.Drawing.Size(980, 142);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePositionID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFalltraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePositionID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFalltraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            //
            // grdFalltraeger
            //
            this.grdFalltraeger.DataSource = this.qryFall;
            this.grdFalltraeger.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdFalltraeger.EmbeddedNavigator.Name = "";
            this.grdFalltraeger.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFalltraeger.Location = new System.Drawing.Point(0, 0);
            this.grdFalltraeger.MainView = this.grvFalltraeger;
            this.grdFalltraeger.Name = "grdFalltraeger";
            this.grdFalltraeger.Size = new System.Drawing.Size(980, 142);
            this.grdFalltraeger.TabIndex = 0;
            this.grdFalltraeger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFalltraeger});
            //
            // qryFall
            //
            this.qryFall.FillTimeOut = 60;
            this.qryFall.HostControl = this;
            this.qryFall.SelectStatement = resources.GetString("qryFall.SelectStatement");
            this.qryFall.TableName = "FaLeistung";
            this.qryFall.PositionChanged += new System.EventHandler(this.qryFall_PositionChanged);
            //
            // grvFalltraeger
            //
            this.grvFalltraeger.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFalltraeger.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.Empty.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.Empty.Options.UseFont = true;
            this.grvFalltraeger.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.EvenRow.Options.UseFont = true;
            this.grvFalltraeger.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFalltraeger.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFalltraeger.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFalltraeger.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFalltraeger.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFalltraeger.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFalltraeger.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFalltraeger.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFalltraeger.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFalltraeger.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFalltraeger.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFalltraeger.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFalltraeger.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.GroupRow.Options.UseFont = true;
            this.grvFalltraeger.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFalltraeger.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFalltraeger.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFalltraeger.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFalltraeger.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFalltraeger.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFalltraeger.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFalltraeger.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFalltraeger.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFalltraeger.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFalltraeger.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFalltraeger.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.OddRow.Options.UseFont = true;
            this.grvFalltraeger.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFalltraeger.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.Row.Options.UseBackColor = true;
            this.grvFalltraeger.Appearance.Row.Options.UseFont = true;
            this.grvFalltraeger.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFalltraeger.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFalltraeger.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFalltraeger.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFalltraeger.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFalltraeger.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colSAR});
            this.grvFalltraeger.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFalltraeger.GridControl = this.grdFalltraeger;
            this.grvFalltraeger.Name = "grvFalltraeger";
            this.grvFalltraeger.OptionsBehavior.Editable = false;
            this.grvFalltraeger.OptionsCustomization.AllowFilter = false;
            this.grvFalltraeger.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFalltraeger.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFalltraeger.OptionsNavigation.UseTabKey = false;
            this.grvFalltraeger.OptionsView.ColumnAutoWidth = false;
            this.grvFalltraeger.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFalltraeger.OptionsView.ShowGroupPanel = false;
            this.grvFalltraeger.OptionsView.ShowIndicator = false;
            //
            // colPerson
            //
            this.colPerson.Caption = "Fallträger/-in";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 350;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 1;
            this.colSAR.Width = 250;
            //
            // edtSuchePositionID
            //
            this.edtSuchePositionID.Location = new System.Drawing.Point(498, 40);
            this.edtSuchePositionID.Name = "edtSuchePositionID";
            this.edtSuchePositionID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSuchePositionID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePositionID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePositionID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePositionID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePositionID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePositionID.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePositionID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePositionID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchePositionID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSuchePositionID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSuchePositionID.Size = new System.Drawing.Size(116, 24);
            this.edtSuchePositionID.TabIndex = 10;
            //
            // edtSucheFalltraeger
            //
            this.edtSucheFalltraeger.Location = new System.Drawing.Point(127, 40);
            this.edtSucheFalltraeger.Name = "edtSucheFalltraeger";
            this.edtSucheFalltraeger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFalltraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFalltraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFalltraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFalltraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFalltraeger.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFalltraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheFalltraeger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheFalltraeger.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFalltraeger.Size = new System.Drawing.Size(260, 24);
            this.edtSucheFalltraeger.TabIndex = 2;
            this.edtSucheFalltraeger.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheFalltraeger_UserModifiedFld);
            //
            // lblSuchePositionID
            //
            this.lblSuchePositionID.Location = new System.Drawing.Point(422, 40);
            this.lblSuchePositionID.Name = "lblSuchePositionID";
            this.lblSuchePositionID.Size = new System.Drawing.Size(70, 24);
            this.lblSuchePositionID.TabIndex = 9;
            this.lblSuchePositionID.Text = "Position-ID";
            this.lblSuchePositionID.UseCompatibleTextRendering = true;
            //
            // edtSucheName
            //
            this.edtSucheName.Location = new System.Drawing.Point(127, 100);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(260, 24);
            this.edtSucheName.TabIndex = 6;
            //
            // edtSucheSAR
            //
            this.edtSucheSAR.Location = new System.Drawing.Point(498, 70);
            this.edtSucheSAR.Name = "edtSucheSAR";
            this.edtSucheSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSAR.Size = new System.Drawing.Size(278, 24);
            this.edtSucheSAR.TabIndex = 12;
            this.edtSucheSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheSAR_UserModifiedFld);
            //
            // lblSucheFalltraeger
            //
            this.lblSucheFalltraeger.Location = new System.Drawing.Point(30, 40);
            this.lblSucheFalltraeger.Name = "lblSucheFalltraeger";
            this.lblSucheFalltraeger.Size = new System.Drawing.Size(91, 24);
            this.lblSucheFalltraeger.TabIndex = 1;
            this.lblSucheFalltraeger.Text = "Fallträger/-in";
            this.lblSucheFalltraeger.UseCompatibleTextRendering = true;
            //
            // edtSucheMonat
            //
            this.edtSucheMonat.Location = new System.Drawing.Point(127, 70);
            this.edtSucheMonat.Name = "edtSucheMonat";
            this.edtSucheMonat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMonat.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMonat.Properties.DisplayFormat.FormatString = "00";
            this.edtSucheMonat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheMonat.Properties.EditFormat.FormatString = "00";
            this.edtSucheMonat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheMonat.Properties.Mask.EditMask = "00";
            this.edtSucheMonat.Size = new System.Drawing.Size(72, 24);
            this.edtSucheMonat.TabIndex = 4;
            //
            // edtSucheJahr
            //
            this.edtSucheJahr.Location = new System.Drawing.Point(315, 70);
            this.edtSucheJahr.Name = "edtSucheJahr";
            this.edtSucheJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheJahr.Properties.DisplayFormat.FormatString = "0000";
            this.edtSucheJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheJahr.Properties.EditFormat.FormatString = "0000";
            this.edtSucheJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheJahr.Properties.Mask.EditMask = "0000";
            this.edtSucheJahr.Size = new System.Drawing.Size(72, 24);
            this.edtSucheJahr.TabIndex = 8;
            //
            // lblSucheSAR
            //
            this.lblSucheSAR.Location = new System.Drawing.Point(422, 70);
            this.lblSucheSAR.Name = "lblSucheSAR";
            this.lblSucheSAR.Size = new System.Drawing.Size(70, 24);
            this.lblSucheSAR.TabIndex = 11;
            this.lblSucheSAR.Text = "SAR";
            this.lblSucheSAR.UseCompatibleTextRendering = true;
            //
            // lblSucheMonat
            //
            this.lblSucheMonat.Location = new System.Drawing.Point(30, 70);
            this.lblSucheMonat.Name = "lblSucheMonat";
            this.lblSucheMonat.Size = new System.Drawing.Size(91, 24);
            this.lblSucheMonat.TabIndex = 3;
            this.lblSucheMonat.Text = "Budget-Monat";
            this.lblSucheMonat.UseCompatibleTextRendering = true;
            //
            // lblSucheJahr
            //
            this.lblSucheJahr.Location = new System.Drawing.Point(218, 70);
            this.lblSucheJahr.Name = "lblSucheJahr";
            this.lblSucheJahr.Size = new System.Drawing.Size(91, 24);
            this.lblSucheJahr.TabIndex = 7;
            this.lblSucheJahr.Text = "Budget-Jahr";
            this.lblSucheJahr.UseCompatibleTextRendering = true;
            //
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(30, 100);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(91, 24);
            this.lblSucheName.TabIndex = 5;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // grdKrankenkasse
            //
            this.grdKrankenkasse.DataSource = this.qryKrankenkasse;
            this.grdKrankenkasse.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdKrankenkasse.EmbeddedNavigator.Name = "";
            this.grdKrankenkasse.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKrankenkasse.Location = new System.Drawing.Point(0, 39);
            this.grdKrankenkasse.MainView = this.grvKrankenkasse;
            this.grdKrankenkasse.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.grdKrankenkasse.Name = "grdKrankenkasse";
            this.grdKrankenkasse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemBtnKVG,
            this.repItemBtnVVG,
            this.repItemZahlung,
            this.repItemStatusImage,
            this.repItemBtnKVGMax});
            this.grdKrankenkasse.Size = new System.Drawing.Size(992, 96);
            this.grdKrankenkasse.TabIndex = 1;
            this.grdKrankenkasse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKrankenkasse});
            //
            // qryKrankenkasse
            //
            this.qryKrankenkasse.BatchUpdate = true;
            this.qryKrankenkasse.FillTimeOut = 300;
            this.qryKrankenkasse.HostControl = this;
            this.qryKrankenkasse.SelectStatement = "EXEC dbo.spKbGetBatchKVGVVG {0}, {1}, {2}";
            this.qryKrankenkasse.PositionChanged += new System.EventHandler(this.qryKrankenkasse_PositionChanged);
            //
            // grvKrankenkasse
            //
            this.grvKrankenkasse.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKrankenkasse.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.Empty.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.Empty.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKrankenkasse.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.EvenRow.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKrankenkasse.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKrankenkasse.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKrankenkasse.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKrankenkasse.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKrankenkasse.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKrankenkasse.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKrankenkasse.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKrankenkasse.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKrankenkasse.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKrankenkasse.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.GroupRow.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKrankenkasse.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKrankenkasse.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKrankenkasse.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKrankenkasse.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKrankenkasse.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKrankenkasse.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKrankenkasse.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKrankenkasse.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKrankenkasse.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.OddRow.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKrankenkasse.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.Row.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.Row.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKrankenkasse.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKrankenkasse.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKrankenkasse.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKrankenkasse.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKrankenkasse.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKrankenkasse.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKrankenkasse.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKrankenkasse.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.grbBudget,
            this.grbZahlung});
            this.grvKrankenkasse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKrankenkasse.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colKKMonatsbudget,
            this.colKKKrankenkasse,
            this.colKKPerson,
            this.colKKBgKVG,
            this.colKKBgKVGStatus,
            this.colKKKVGButton,
            this.colKKBgKVGMax,
            this.colKKBgKVGMaxStatus,
            this.colKKKVGMaxButton,
            this.colKKBgVVG,
            this.colKKBgVVGStatus,
            this.colKKVVGButton,
            this.colKKZahlungKVG,
            this.colKKZahlungKVGStatus,
            this.colKKZahlungKVGMax,
            this.colKKZahlungKVGMaxStatus,
            this.colKKZahlungVVG,
            this.colKKZahlungVVGStatus,
            this.colKKBemerkung});
            this.grvKrankenkasse.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKrankenkasse.GridControl = this.grdKrankenkasse;
            this.grvKrankenkasse.GroupCount = 2;
            this.grvKrankenkasse.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragKVG", this.colKKBgKVG, "{0:F}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragVVG", this.colKKBgVVG, "{0:F}")});
            this.grvKrankenkasse.Name = "grvKrankenkasse";
            this.grvKrankenkasse.OptionsBehavior.Editable = false;
            this.grvKrankenkasse.OptionsCustomization.AllowColumnMoving = false;
            this.grvKrankenkasse.OptionsCustomization.AllowFilter = false;
            this.grvKrankenkasse.OptionsCustomization.AllowGroup = false;
            this.grvKrankenkasse.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKrankenkasse.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKrankenkasse.OptionsNavigation.UseTabKey = false;
            this.grvKrankenkasse.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvKrankenkasse.OptionsView.ColumnAutoWidth = false;
            this.grvKrankenkasse.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKrankenkasse.OptionsView.ShowGroupPanel = false;
            this.grvKrankenkasse.OptionsView.ShowIndicator = false;
            this.grvKrankenkasse.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKKMonatsbudget, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKKKrankenkasse, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvKrankenkasse.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvKrankenkasse_CustomDrawCell);
            this.grvKrankenkasse.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvKrankenkasse_ShowingEditor);
            this.grvKrankenkasse.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvKrankenkasse_FocusedRowChanged);
            this.grvKrankenkasse.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvKrankenkasse_CellValueChanged);
            //
            // grbBudget
            //
            this.grbBudget.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grbBudget.AppearanceHeader.Options.UseFont = true;
            this.grbBudget.Caption = "Budget";
            this.grbBudget.Columns.Add(this.colKKMonatsbudget);
            this.grbBudget.Columns.Add(this.colKKKrankenkasse);
            this.grbBudget.Columns.Add(this.colKKPerson);
            this.grbBudget.Columns.Add(this.colKKBgKVG);
            this.grbBudget.Columns.Add(this.colKKBgKVGStatus);
            this.grbBudget.Columns.Add(this.colKKKVGButton);
            this.grbBudget.Columns.Add(this.colKKBgKVGMax);
            this.grbBudget.Columns.Add(this.colKKBgKVGMaxStatus);
            this.grbBudget.Columns.Add(this.colKKKVGMaxButton);
            this.grbBudget.Columns.Add(this.colKKBgVVG);
            this.grbBudget.Columns.Add(this.colKKBgVVGStatus);
            this.grbBudget.Columns.Add(this.colKKVVGButton);
            this.grbBudget.Name = "grbBudget";
            this.grbBudget.OptionsBand.AllowMove = false;
            this.grbBudget.OptionsBand.AllowPress = false;
            this.grbBudget.Width = 762;
            //
            // colKKMonatsbudget
            //
            this.colKKMonatsbudget.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKMonatsbudget.AppearanceCell.Options.UseBackColor = true;
            this.colKKMonatsbudget.Caption = "Monatsbudget";
            this.colKKMonatsbudget.FieldName = "Monatsbudget";
            this.colKKMonatsbudget.GroupFormat.FormatString = "{0:Y}";
            this.colKKMonatsbudget.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colKKMonatsbudget.Name = "colKKMonatsbudget";
            this.colKKMonatsbudget.OptionsColumn.AllowEdit = false;
            this.colKKMonatsbudget.OptionsColumn.AllowFocus = false;
            this.colKKMonatsbudget.Width = 110;
            //
            // colKKKrankenkasse
            //
            this.colKKKrankenkasse.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKKrankenkasse.AppearanceCell.Options.UseBackColor = true;
            this.colKKKrankenkasse.Caption = "Krankenkasse";
            this.colKKKrankenkasse.FieldName = "Krankenkasse";
            this.colKKKrankenkasse.Name = "colKKKrankenkasse";
            this.colKKKrankenkasse.OptionsColumn.AllowEdit = false;
            this.colKKKrankenkasse.OptionsColumn.AllowFocus = false;
            this.colKKKrankenkasse.Visible = true;
            this.colKKKrankenkasse.Width = 110;
            //
            // colKKPerson
            //
            this.colKKPerson.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKPerson.AppearanceCell.Options.UseBackColor = true;
            this.colKKPerson.Caption = "Person";
            this.colKKPerson.FieldName = "Person";
            this.colKKPerson.Name = "colKKPerson";
            this.colKKPerson.OptionsColumn.AllowEdit = false;
            this.colKKPerson.OptionsColumn.AllowFocus = false;
            this.colKKPerson.Visible = true;
            this.colKKPerson.Width = 220;
            //
            // colKKBgKVG
            //
            this.colKKBgKVG.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKBgKVG.AppearanceCell.Options.UseBackColor = true;
            this.colKKBgKVG.Caption = "Bg KVG";
            this.colKKBgKVG.DisplayFormat.FormatString = "F";
            this.colKKBgKVG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKKBgKVG.FieldName = "BetragKVG";
            this.colKKBgKVG.Name = "colKKBgKVG";
            this.colKKBgKVG.OptionsColumn.AllowEdit = false;
            this.colKKBgKVG.OptionsColumn.AllowFocus = false;
            this.colKKBgKVG.Visible = true;
            this.colKKBgKVG.Width = 85;
            //
            // colKKBgKVGStatus
            //
            this.colKKBgKVGStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKBgKVGStatus.AppearanceCell.Options.UseBackColor = true;
            this.colKKBgKVGStatus.Caption = "Stat.";
            this.colKKBgKVGStatus.ColumnEdit = this.repItemStatusImage;
            this.colKKBgKVGStatus.FieldName = "StatusKVG";
            this.colKKBgKVGStatus.Name = "colKKBgKVGStatus";
            this.colKKBgKVGStatus.OptionsColumn.AllowEdit = false;
            this.colKKBgKVGStatus.OptionsColumn.AllowFocus = false;
            this.colKKBgKVGStatus.Visible = true;
            this.colKKBgKVGStatus.Width = 35;
            //
            // repItemStatusImage
            //
            this.repItemStatusImage.AutoHeight = false;
            this.repItemStatusImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.repItemStatusImage.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repItemStatusImage.Name = "repItemStatusImage";
            //
            // colKKKVGButton
            //
            this.colKKKVGButton.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKKVGButton.AppearanceCell.Options.UseBackColor = true;
            this.colKKKVGButton.AppearanceHeader.Options.UseTextOptions = true;
            this.colKKKVGButton.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKKKVGButton.Caption = ">";
            this.colKKKVGButton.ColumnEdit = this.repItemBtnKVG;
            this.colKKKVGButton.Name = "colKKKVGButton";
            this.colKKKVGButton.Visible = true;
            this.colKKKVGButton.Width = 24;
            //
            // repItemBtnKVG
            //
            this.repItemBtnKVG.AutoHeight = false;
            this.repItemBtnKVG.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repItemBtnKVG.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repItemBtnKVG.Name = "repItemBtnKVG";
            this.repItemBtnKVG.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            // colKKBgKVGMax
            //
            this.colKKBgKVGMax.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKBgKVGMax.AppearanceCell.Options.UseBackColor = true;
            this.colKKBgKVGMax.Caption = "Bg KVG Max";
            this.colKKBgKVGMax.DisplayFormat.FormatString = "F";
            this.colKKBgKVGMax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKKBgKVGMax.FieldName = "BetragKVGMax";
            this.colKKBgKVGMax.Name = "colKKBgKVGMax";
            this.colKKBgKVGMax.OptionsColumn.AllowEdit = false;
            this.colKKBgKVGMax.OptionsColumn.AllowFocus = false;
            this.colKKBgKVGMax.Visible = true;
            this.colKKBgKVGMax.Width = 85;
            //
            // colKKBgKVGMaxStatus
            //
            this.colKKBgKVGMaxStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKBgKVGMaxStatus.AppearanceCell.Options.UseBackColor = true;
            this.colKKBgKVGMaxStatus.Caption = "Stat.";
            this.colKKBgKVGMaxStatus.FieldName = "StatusKVGMax";
            this.colKKBgKVGMaxStatus.Name = "colKKBgKVGMaxStatus";
            this.colKKBgKVGMaxStatus.OptionsColumn.AllowEdit = false;
            this.colKKBgKVGMaxStatus.OptionsColumn.AllowFocus = false;
            this.colKKBgKVGMaxStatus.Visible = true;
            this.colKKBgKVGMaxStatus.Width = 35;
            //
            // colKKKVGMaxButton
            //
            this.colKKKVGMaxButton.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKKVGMaxButton.AppearanceCell.Options.UseBackColor = true;
            this.colKKKVGMaxButton.AppearanceHeader.Options.UseTextOptions = true;
            this.colKKKVGMaxButton.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKKKVGMaxButton.Caption = ">";
            this.colKKKVGMaxButton.ColumnEdit = this.repItemBtnKVGMax;
            this.colKKKVGMaxButton.Name = "colKKKVGMaxButton";
            this.colKKKVGMaxButton.Visible = true;
            this.colKKKVGMaxButton.Width = 24;
            //
            // repItemBtnKVGMax
            //
            this.repItemBtnKVGMax.AutoHeight = false;
            this.repItemBtnKVGMax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repItemBtnKVGMax.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repItemBtnKVGMax.Name = "repItemBtnKVGMax";
            this.repItemBtnKVGMax.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            // colKKBgVVG
            //
            this.colKKBgVVG.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKBgVVG.AppearanceCell.Options.UseBackColor = true;
            this.colKKBgVVG.Caption = "Bg VVG";
            this.colKKBgVVG.DisplayFormat.FormatString = "F";
            this.colKKBgVVG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKKBgVVG.FieldName = "BetragVVG";
            this.colKKBgVVG.Name = "colKKBgVVG";
            this.colKKBgVVG.OptionsColumn.AllowEdit = false;
            this.colKKBgVVG.OptionsColumn.AllowFocus = false;
            this.colKKBgVVG.Visible = true;
            this.colKKBgVVG.Width = 85;
            //
            // colKKBgVVGStatus
            //
            this.colKKBgVVGStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKBgVVGStatus.AppearanceCell.Options.UseBackColor = true;
            this.colKKBgVVGStatus.Caption = "Stat.";
            this.colKKBgVVGStatus.FieldName = "StatusVVG";
            this.colKKBgVVGStatus.Name = "colKKBgVVGStatus";
            this.colKKBgVVGStatus.OptionsColumn.AllowEdit = false;
            this.colKKBgVVGStatus.OptionsColumn.AllowFocus = false;
            this.colKKBgVVGStatus.Visible = true;
            this.colKKBgVVGStatus.Width = 35;
            //
            // colKKVVGButton
            //
            this.colKKVVGButton.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKVVGButton.AppearanceCell.Options.UseBackColor = true;
            this.colKKVVGButton.AppearanceHeader.Options.UseTextOptions = true;
            this.colKKVVGButton.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKKVVGButton.Caption = ">";
            this.colKKVVGButton.ColumnEdit = this.repItemBtnVVG;
            this.colKKVVGButton.Name = "colKKVVGButton";
            this.colKKVVGButton.Visible = true;
            this.colKKVVGButton.Width = 24;
            //
            // repItemBtnVVG
            //
            this.repItemBtnVVG.AutoHeight = false;
            this.repItemBtnVVG.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repItemBtnVVG.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repItemBtnVVG.Name = "repItemBtnVVG";
            this.repItemBtnVVG.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //
            // grbZahlung
            //
            this.grbZahlung.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grbZahlung.AppearanceHeader.Options.UseFont = true;
            this.grbZahlung.Caption = "Zahlung";
            this.grbZahlung.Columns.Add(this.colKKZahlungKVG);
            this.grbZahlung.Columns.Add(this.colKKZahlungKVGStatus);
            this.grbZahlung.Columns.Add(this.colKKZahlungKVGMax);
            this.grbZahlung.Columns.Add(this.colKKZahlungKVGMaxStatus);
            this.grbZahlung.Columns.Add(this.colKKZahlungVVG);
            this.grbZahlung.Columns.Add(this.colKKZahlungVVGStatus);
            this.grbZahlung.Columns.Add(this.colKKBemerkung);
            this.grbZahlung.Name = "grbZahlung";
            this.grbZahlung.OptionsBand.AllowMove = false;
            this.grbZahlung.OptionsBand.AllowPress = false;
            this.grbZahlung.Width = 482;
            //
            // colKKZahlungKVG
            //
            this.colKKZahlungKVG.Caption = "Zahlung KVG";
            this.colKKZahlungKVG.ColumnEdit = this.repItemZahlung;
            this.colKKZahlungKVG.DisplayFormat.FormatString = "F";
            this.colKKZahlungKVG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKKZahlungKVG.FieldName = "ZahlungKVG";
            this.colKKZahlungKVG.Name = "colKKZahlungKVG";
            this.colKKZahlungKVG.Visible = true;
            this.colKKZahlungKVG.Width = 85;
            //
            // repItemZahlung
            //
            this.repItemZahlung.AutoHeight = false;
            this.repItemZahlung.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.repItemZahlung.DisplayFormat.FormatString = "F";
            this.repItemZahlung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repItemZahlung.EditFormat.FormatString = "F";
            this.repItemZahlung.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repItemZahlung.Name = "repItemZahlung";
            this.repItemZahlung.Precision = 2;
            this.repItemZahlung.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            //
            // colKKZahlungKVGStatus
            //
            this.colKKZahlungKVGStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKZahlungKVGStatus.AppearanceCell.Options.UseBackColor = true;
            this.colKKZahlungKVGStatus.Caption = "Stat.";
            this.colKKZahlungKVGStatus.FieldName = "StatusZahlungKVG";
            this.colKKZahlungKVGStatus.Name = "colKKZahlungKVGStatus";
            this.colKKZahlungKVGStatus.OptionsColumn.AllowEdit = false;
            this.colKKZahlungKVGStatus.OptionsColumn.AllowFocus = false;
            this.colKKZahlungKVGStatus.Visible = true;
            this.colKKZahlungKVGStatus.Width = 35;
            //
            // colKKZahlungKVGMax
            //
            this.colKKZahlungKVGMax.Caption = "Zahlung KVG Max";
            this.colKKZahlungKVGMax.ColumnEdit = this.repItemZahlung;
            this.colKKZahlungKVGMax.DisplayFormat.FormatString = "F";
            this.colKKZahlungKVGMax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKKZahlungKVGMax.FieldName = "ZahlungKVGMax";
            this.colKKZahlungKVGMax.Name = "colKKZahlungKVGMax";
            this.colKKZahlungKVGMax.Visible = true;
            this.colKKZahlungKVGMax.Width = 107;
            //
            // colKKZahlungKVGMaxStatus
            //
            this.colKKZahlungKVGMaxStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKZahlungKVGMaxStatus.AppearanceCell.Options.UseBackColor = true;
            this.colKKZahlungKVGMaxStatus.Caption = "Stat.";
            this.colKKZahlungKVGMaxStatus.FieldName = "StatusZahlungKVGMax";
            this.colKKZahlungKVGMaxStatus.Name = "colKKZahlungKVGMaxStatus";
            this.colKKZahlungKVGMaxStatus.OptionsColumn.AllowEdit = false;
            this.colKKZahlungKVGMaxStatus.OptionsColumn.AllowFocus = false;
            this.colKKZahlungKVGMaxStatus.Visible = true;
            this.colKKZahlungKVGMaxStatus.Width = 35;
            //
            // colKKZahlungVVG
            //
            this.colKKZahlungVVG.Caption = "Zahlung VVG";
            this.colKKZahlungVVG.ColumnEdit = this.repItemZahlung;
            this.colKKZahlungVVG.DisplayFormat.FormatString = "F";
            this.colKKZahlungVVG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKKZahlungVVG.FieldName = "ZahlungVVG";
            this.colKKZahlungVVG.Name = "colKKZahlungVVG";
            this.colKKZahlungVVG.Visible = true;
            this.colKKZahlungVVG.Width = 85;
            //
            // colKKZahlungVVGStatus
            //
            this.colKKZahlungVVGStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKKZahlungVVGStatus.AppearanceCell.Options.UseBackColor = true;
            this.colKKZahlungVVGStatus.Caption = "Stat.";
            this.colKKZahlungVVGStatus.FieldName = "StatusZahlungVVG";
            this.colKKZahlungVVGStatus.Name = "colKKZahlungVVGStatus";
            this.colKKZahlungVVGStatus.OptionsColumn.AllowEdit = false;
            this.colKKZahlungVVGStatus.OptionsColumn.AllowFocus = false;
            this.colKKZahlungVVGStatus.Visible = true;
            this.colKKZahlungVVGStatus.Width = 35;
            //
            // colKKBemerkung
            //
            this.colKKBemerkung.Caption = "Bemerkung";
            this.colKKBemerkung.FieldName = "Bemerkung";
            this.colKKBemerkung.Name = "colKKBemerkung";
            this.colKKBemerkung.Visible = true;
            this.colKKBemerkung.Width = 100;
            //
            // btnSILAntragBearbeiten
            //
            this.btnSILAntragBearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSILAntragBearbeiten.Enabled = false;
            this.btnSILAntragBearbeiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSILAntragBearbeiten.IconID = 178;
            this.btnSILAntragBearbeiten.Location = new System.Drawing.Point(6, 182);
            this.btnSILAntragBearbeiten.Name = "btnSILAntragBearbeiten";
            this.btnSILAntragBearbeiten.Size = new System.Drawing.Size(24, 24);
            this.btnSILAntragBearbeiten.TabIndex = 2;
            this.btnSILAntragBearbeiten.UseCompatibleTextRendering = true;
            this.btnSILAntragBearbeiten.UseVisualStyleBackColor = false;
            this.btnSILAntragBearbeiten.Click += new System.EventHandler(this.btnSILAntragBearbeiten_Click);
            //
            // btnElAuszahlungLoeschen
            //
            this.btnElAuszahlungLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElAuszahlungLoeschen.Enabled = false;
            this.btnElAuszahlungLoeschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElAuszahlungLoeschen.IconID = 4;
            this.btnElAuszahlungLoeschen.Location = new System.Drawing.Point(6, 212);
            this.btnElAuszahlungLoeschen.Name = "btnElAuszahlungLoeschen";
            this.btnElAuszahlungLoeschen.Size = new System.Drawing.Size(24, 24);
            this.btnElAuszahlungLoeschen.TabIndex = 3;
            this.btnElAuszahlungLoeschen.UseCompatibleTextRendering = true;
            this.btnElAuszahlungLoeschen.UseVisualStyleBackColor = false;
            this.btnElAuszahlungLoeschen.Click += new System.EventHandler(this.btnElAuszahlungLoeschen_Click);
            //
            // lblAuszahlungsart
            //
            this.lblAuszahlungsart.Location = new System.Drawing.Point(9, 9);
            this.lblAuszahlungsart.Name = "lblAuszahlungsart";
            this.lblAuszahlungsart.Size = new System.Drawing.Size(93, 24);
            this.lblAuszahlungsart.TabIndex = 4;
            this.lblAuszahlungsart.Text = "Auszahlungsart";
            this.lblAuszahlungsart.UseCompatibleTextRendering = true;
            //
            // edtAuszahlungsart
            //
            this.edtAuszahlungsart.AllowNull = false;
            this.edtAuszahlungsart.DataMember = "KbAuszahlungsartCode";
            this.edtAuszahlungsart.DataSource = this.qryAuszahlweg;
            this.edtAuszahlungsart.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtAuszahlungsart.Location = new System.Drawing.Point(108, 9);
            this.edtAuszahlungsart.LOVName = "KbAuszahlungsArt";
            this.edtAuszahlungsart.Name = "edtAuszahlungsart";
            this.edtAuszahlungsart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtAuszahlungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszahlungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszahlungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszahlungsart.Properties.Appearance.Options.UseFont = true;
            this.edtAuszahlungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuszahlungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuszahlungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuszahlungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAuszahlungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAuszahlungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuszahlungsart.Properties.NullText = "";
            this.edtAuszahlungsart.Properties.ShowFooter = false;
            this.edtAuszahlungsart.Properties.ShowHeader = false;
            this.edtAuszahlungsart.Size = new System.Drawing.Size(256, 24);
            this.edtAuszahlungsart.TabIndex = 5;
            this.edtAuszahlungsart.EditValueChanged += new System.EventHandler(this.edtAuszahlungsart_EditValueChanged);
            //
            // qryAuszahlweg
            //
            this.qryAuszahlweg.FillTimeOut = 60;
            this.qryAuszahlweg.HostControl = this;
            this.qryAuszahlweg.SelectStatement = resources.GetString("qryAuszahlweg.SelectStatement");
            this.qryAuszahlweg.AfterFill += new System.EventHandler(this.qryAuszahlweg_AfterFill);
            this.qryAuszahlweg.AfterInsert += new System.EventHandler(this.qryAuszahlweg_AfterInsert);
            this.qryAuszahlweg.BeforePost += new System.EventHandler(this.qryAuszahlweg_BeforePost);
            //
            // lblValutaDatum
            //
            this.lblValutaDatum.Location = new System.Drawing.Point(9, 39);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(93, 24);
            this.lblValutaDatum.TabIndex = 0;
            this.lblValutaDatum.Text = "Valuta";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            //
            // edtValutaDatum
            //
            this.edtValutaDatum.DataMember = "Valuta";
            this.edtValutaDatum.DataSource = this.qryAuszahlweg;
            this.edtValutaDatum.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(108, 39);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(90, 24);
            this.edtValutaDatum.TabIndex = 1;
            //
            // lblRechnungDatum
            //
            this.lblRechnungDatum.Location = new System.Drawing.Point(215, 39);
            this.lblRechnungDatum.Name = "lblRechnungDatum";
            this.lblRechnungDatum.Size = new System.Drawing.Size(53, 24);
            this.lblRechnungDatum.TabIndex = 6;
            this.lblRechnungDatum.Text = "R-Datum";
            this.lblRechnungDatum.UseCompatibleTextRendering = true;
            //
            // edtRechnungDatum
            //
            this.edtRechnungDatum.DataMember = "Rechnungdatum";
            this.edtRechnungDatum.DataSource = this.qryAuszahlweg;
            this.edtRechnungDatum.EditValue = null;
            this.edtRechnungDatum.Location = new System.Drawing.Point(274, 39);
            this.edtRechnungDatum.Name = "edtRechnungDatum";
            this.edtRechnungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechnungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtRechnungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRechnungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtRechnungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechnungDatum.Properties.ShowToday = false;
            this.edtRechnungDatum.Size = new System.Drawing.Size(90, 24);
            this.edtRechnungDatum.TabIndex = 7;
            //
            // lblKreditor
            //
            this.lblKreditor.Location = new System.Drawing.Point(9, 69);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(93, 24);
            this.lblKreditor.TabIndex = 8;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            //
            // edtKreditor
            //
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryAuszahlweg;
            this.edtKreditor.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKreditor.Location = new System.Drawing.Point(108, 69);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKreditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKreditor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditor.SearchStringMinLength = 3;
            this.edtKreditor.Size = new System.Drawing.Size(256, 24);
            this.edtKreditor.TabIndex = 9;
            this.edtKreditor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKreditor_UserModifiedFld);
            this.edtKreditor.EditValueChanged += new System.EventHandler(this.edtKreditor_EditValueChanged);
            //
            // edtZusatzInfo
            //
            this.edtZusatzInfo.DataMember = "ZusatzInfo";
            this.edtZusatzInfo.DataSource = this.qryAuszahlweg;
            this.edtZusatzInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZusatzInfo.Location = new System.Drawing.Point(108, 92);
            this.edtZusatzInfo.Name = "edtZusatzInfo";
            this.edtZusatzInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZusatzInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzInfo.Properties.ReadOnly = true;
            this.edtZusatzInfo.Size = new System.Drawing.Size(256, 114);
            this.edtZusatzInfo.TabIndex = 10;
            this.edtZusatzInfo.TabStop = false;
            //
            // lblReferenzNummer
            //
            this.lblReferenzNummer.Location = new System.Drawing.Point(9, 212);
            this.lblReferenzNummer.Name = "lblReferenzNummer";
            this.lblReferenzNummer.Size = new System.Drawing.Size(93, 24);
            this.lblReferenzNummer.TabIndex = 11;
            this.lblReferenzNummer.Text = "Ref-Nr.:";
            this.lblReferenzNummer.UseCompatibleTextRendering = true;
            //
            // edtReferenzNummer
            //
            this.edtReferenzNummer.DataMember = "ReferenzNummer";
            this.edtReferenzNummer.DataSource = this.qryAuszahlweg;
            this.edtReferenzNummer.Location = new System.Drawing.Point(108, 212);
            this.edtReferenzNummer.Name = "edtReferenzNummer";
            this.edtReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReferenzNummer.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenzNummer.Properties.MaxLength = 50;
            this.edtReferenzNummer.Size = new System.Drawing.Size(256, 24);
            this.edtReferenzNummer.TabIndex = 12;
            //
            // lblTotalbetrag
            //
            this.lblTotalbetrag.Location = new System.Drawing.Point(382, 9);
            this.lblTotalbetrag.Name = "lblTotalbetrag";
            this.lblTotalbetrag.Size = new System.Drawing.Size(96, 24);
            this.lblTotalbetrag.TabIndex = 13;
            this.lblTotalbetrag.Text = "Totalbetrag";
            this.lblTotalbetrag.UseCompatibleTextRendering = true;
            //
            // edtTotalbetrag
            //
            this.edtTotalbetrag.DataMember = "Totalbetrag";
            this.edtTotalbetrag.DataSource = this.qryAuszahlweg;
            this.edtTotalbetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtTotalbetrag.Location = new System.Drawing.Point(484, 9);
            this.edtTotalbetrag.Name = "edtTotalbetrag";
            this.edtTotalbetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotalbetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtTotalbetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotalbetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotalbetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotalbetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotalbetrag.Properties.Appearance.Options.UseFont = true;
            this.edtTotalbetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotalbetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotalbetrag.Properties.DisplayFormat.FormatString = "F2";
            this.edtTotalbetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTotalbetrag.Properties.EditFormat.FormatString = "F2";
            this.edtTotalbetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTotalbetrag.Size = new System.Drawing.Size(92, 24);
            this.edtTotalbetrag.TabIndex = 14;
            this.edtTotalbetrag.EditValueChanged += new System.EventHandler(this.edtTotalbetrag_EditValueChanged);
            //
            // lblTotalbetragCHF
            //
            this.lblTotalbetragCHF.Location = new System.Drawing.Point(582, 9);
            this.lblTotalbetragCHF.Name = "lblTotalbetragCHF";
            this.lblTotalbetragCHF.Size = new System.Drawing.Size(34, 24);
            this.lblTotalbetragCHF.TabIndex = 15;
            this.lblTotalbetragCHF.Text = "CHF";
            this.lblTotalbetragCHF.UseCompatibleTextRendering = true;
            //
            // lblRestbetrag
            //
            this.lblRestbetrag.Location = new System.Drawing.Point(382, 33);
            this.lblRestbetrag.Name = "lblRestbetrag";
            this.lblRestbetrag.Size = new System.Drawing.Size(96, 24);
            this.lblRestbetrag.TabIndex = 16;
            this.lblRestbetrag.Text = "Restbetrag";
            this.lblRestbetrag.UseCompatibleTextRendering = true;
            //
            // edtRestbetrag
            //
            this.edtRestbetrag.DataMember = "Restbetrag";
            this.edtRestbetrag.DataSource = this.qryAuszahlweg;
            this.edtRestbetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtRestbetrag.Location = new System.Drawing.Point(484, 32);
            this.edtRestbetrag.Name = "edtRestbetrag";
            this.edtRestbetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRestbetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtRestbetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRestbetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRestbetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtRestbetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRestbetrag.Properties.Appearance.Options.UseFont = true;
            this.edtRestbetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRestbetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRestbetrag.Properties.DisplayFormat.FormatString = "F2";
            this.edtRestbetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtRestbetrag.Properties.EditFormat.FormatString = "F2";
            this.edtRestbetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtRestbetrag.Properties.ReadOnly = true;
            this.edtRestbetrag.Size = new System.Drawing.Size(92, 24);
            this.edtRestbetrag.TabIndex = 17;
            //
            // lblRestbetragCHF
            //
            this.lblRestbetragCHF.Location = new System.Drawing.Point(582, 32);
            this.lblRestbetragCHF.Name = "lblRestbetragCHF";
            this.lblRestbetragCHF.Size = new System.Drawing.Size(33, 24);
            this.lblRestbetragCHF.TabIndex = 18;
            this.lblRestbetragCHF.Text = "CHF";
            this.lblRestbetragCHF.UseCompatibleTextRendering = true;
            //
            // lblBuchungstext
            //
            this.lblBuchungstext.Location = new System.Drawing.Point(382, 62);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(96, 24);
            this.lblBuchungstext.TabIndex = 2;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            //
            // edtBuchungstext
            //
            this.edtBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryAuszahlweg;
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBuchungstext.Location = new System.Drawing.Point(484, 62);
            this.edtBuchungstext.MinimumSize = new System.Drawing.Size(92, 24);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(255, 24);
            this.edtBuchungstext.TabIndex = 3;
            //
            // lblZahlungsgrund
            //
            this.lblZahlungsgrund.Location = new System.Drawing.Point(382, 92);
            this.lblZahlungsgrund.Name = "lblZahlungsgrund";
            this.lblZahlungsgrund.Size = new System.Drawing.Size(96, 24);
            this.lblZahlungsgrund.TabIndex = 19;
            this.lblZahlungsgrund.Text = "Mitteilung";
            this.lblZahlungsgrund.UseCompatibleTextRendering = true;
            //
            // edtMitteilungZeile1
            //
            this.edtMitteilungZeile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMitteilungZeile1.DataMember = "MitteilungZeile1";
            this.edtMitteilungZeile1.DataSource = this.qryAuszahlweg;
            this.edtMitteilungZeile1.Location = new System.Drawing.Point(484, 92);
            this.edtMitteilungZeile1.MinimumSize = new System.Drawing.Size(256, 24);
            this.edtMitteilungZeile1.Name = "edtMitteilungZeile1";
            this.edtMitteilungZeile1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile1.Properties.MaxLength = 35;
            this.edtMitteilungZeile1.Size = new System.Drawing.Size(459, 24);
            this.edtMitteilungZeile1.TabIndex = 20;
            //
            // edtMitteilungZeile2
            //
            this.edtMitteilungZeile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMitteilungZeile2.DataMember = "MitteilungZeile2";
            this.edtMitteilungZeile2.DataSource = this.qryAuszahlweg;
            this.edtMitteilungZeile2.Location = new System.Drawing.Point(484, 115);
            this.edtMitteilungZeile2.MinimumSize = new System.Drawing.Size(256, 24);
            this.edtMitteilungZeile2.Name = "edtMitteilungZeile2";
            this.edtMitteilungZeile2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile2.Properties.MaxLength = 35;
            this.edtMitteilungZeile2.Size = new System.Drawing.Size(459, 24);
            this.edtMitteilungZeile2.TabIndex = 21;
            //
            // edtMitteilungZeile3
            //
            this.edtMitteilungZeile3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMitteilungZeile3.DataMember = "MitteilungZeile3";
            this.edtMitteilungZeile3.DataSource = this.qryAuszahlweg;
            this.edtMitteilungZeile3.Location = new System.Drawing.Point(484, 138);
            this.edtMitteilungZeile3.MinimumSize = new System.Drawing.Size(256, 24);
            this.edtMitteilungZeile3.Name = "edtMitteilungZeile3";
            this.edtMitteilungZeile3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile3.Properties.MaxLength = 35;
            this.edtMitteilungZeile3.Size = new System.Drawing.Size(459, 24);
            this.edtMitteilungZeile3.TabIndex = 22;
            //
            // lblVerwPeriode
            //
            this.lblVerwPeriode.Location = new System.Drawing.Point(382, 168);
            this.lblVerwPeriode.Name = "lblVerwPeriode";
            this.lblVerwPeriode.Size = new System.Drawing.Size(96, 24);
            this.lblVerwPeriode.TabIndex = 23;
            this.lblVerwPeriode.Text = "Verwendungsp.";
            this.lblVerwPeriode.UseCompatibleTextRendering = true;
            //
            // edtVerwPeriodeVon
            //
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryAuszahlweg;
            this.edtVerwPeriodeVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(484, 168);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeVon.TabIndex = 24;
            //
            // lblVerwPeriodeStrich
            //
            this.lblVerwPeriodeStrich.Location = new System.Drawing.Point(580, 168);
            this.lblVerwPeriodeStrich.Name = "lblVerwPeriodeStrich";
            this.lblVerwPeriodeStrich.Size = new System.Drawing.Size(7, 24);
            this.lblVerwPeriodeStrich.TabIndex = 25;
            this.lblVerwPeriodeStrich.Text = "-";
            this.lblVerwPeriodeStrich.UseCompatibleTextRendering = true;
            //
            // edtVerwPeriodeBis
            //
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryAuszahlweg;
            this.edtVerwPeriodeBis.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(593, 168);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeBis.TabIndex = 26;
            //
            // lblBgSplittingCode
            //
            this.lblBgSplittingCode.Location = new System.Drawing.Point(697, 168);
            this.lblBgSplittingCode.Name = "lblBgSplittingCode";
            this.lblBgSplittingCode.Size = new System.Drawing.Size(26, 24);
            this.lblBgSplittingCode.TabIndex = 27;
            this.lblBgSplittingCode.Text = "Spl.";
            this.lblBgSplittingCode.UseCompatibleTextRendering = true;
            //
            // edtSplittingArtCode
            //
            this.edtSplittingArtCode.AllowNull = false;
            this.edtSplittingArtCode.DataMember = "BgSplittingArtCode";
            this.edtSplittingArtCode.DataSource = this.qryAuszahlweg;
            this.edtSplittingArtCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSplittingArtCode.Location = new System.Drawing.Point(729, 168);
            this.edtSplittingArtCode.LOVName = "BgSplittingart";
            this.edtSplittingArtCode.Name = "edtSplittingArtCode";
            this.edtSplittingArtCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSplittingArtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSplittingArtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSplittingArtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSplittingArtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSplittingArtCode.Properties.Appearance.Options.UseFont = true;
            this.edtSplittingArtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSplittingArtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSplittingArtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSplittingArtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSplittingArtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSplittingArtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSplittingArtCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSplittingArtCode.Properties.DisplayMember = "Text";
            this.edtSplittingArtCode.Properties.NullText = "";
            this.edtSplittingArtCode.Properties.ReadOnly = true;
            this.edtSplittingArtCode.Properties.ShowFooter = false;
            this.edtSplittingArtCode.Properties.ShowHeader = false;
            this.edtSplittingArtCode.Properties.ValueMember = "Code";
            this.edtSplittingArtCode.Size = new System.Drawing.Size(115, 24);
            this.edtSplittingArtCode.TabIndex = 28;
            this.edtSplittingArtCode.TabStop = false;
            //
            // ctlErfassungMutation
            //
            this.ctlErfassungMutation.ActiveSQLQuery = this.qryAuszahlweg;
            this.ctlErfassungMutation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation.Location = new System.Drawing.Point(484, 198);
            this.ctlErfassungMutation.Name = "ctlErfassungMutation";
            this.ctlErfassungMutation.Size = new System.Drawing.Size(360, 38);
            this.ctlErfassungMutation.TabIndex = 29;
            //
            // lblBelegID
            //
            this.lblBelegID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBelegID.Location = new System.Drawing.Point(764, 9);
            this.lblBelegID.Name = "lblBelegID";
            this.lblBelegID.Size = new System.Drawing.Size(75, 24);
            this.lblBelegID.TabIndex = 30;
            this.lblBelegID.Text = "Position-ID";
            this.lblBelegID.UseCompatibleTextRendering = true;
            //
            // edtBelegID
            //
            this.edtBelegID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBelegID.DataMember = "BelegID";
            this.edtBelegID.DataSource = this.qryAuszahlweg;
            this.edtBelegID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegID.Location = new System.Drawing.Point(843, 9);
            this.edtBelegID.Name = "edtBelegID";
            this.edtBelegID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegID.Properties.Appearance.Options.UseFont = true;
            this.edtBelegID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegID.Properties.ReadOnly = true;
            this.edtBelegID.Size = new System.Drawing.Size(100, 24);
            this.edtBelegID.TabIndex = 31;
            //
            // lblBelegNr
            //
            this.lblBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBelegNr.Location = new System.Drawing.Point(764, 39);
            this.lblBelegNr.Name = "lblBelegNr";
            this.lblBelegNr.Size = new System.Drawing.Size(75, 24);
            this.lblBelegNr.TabIndex = 32;
            this.lblBelegNr.Text = "Beleg-Nr.";
            this.lblBelegNr.UseCompatibleTextRendering = true;
            //
            // edtBelegNr
            //
            this.edtBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBelegNr.DataMember = "BelegNr";
            this.edtBelegNr.DataSource = this.qryAuszahlweg;
            this.edtBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegNr.Location = new System.Drawing.Point(843, 39);
            this.edtBelegNr.Name = "edtBelegNr";
            this.edtBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegNr.Properties.ReadOnly = true;
            this.edtBelegNr.Size = new System.Drawing.Size(100, 24);
            this.edtBelegNr.TabIndex = 33;
            //
            // lblBelegDatum
            //
            this.lblBelegDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBelegDatum.Location = new System.Drawing.Point(764, 62);
            this.lblBelegDatum.Name = "lblBelegDatum";
            this.lblBelegDatum.Size = new System.Drawing.Size(75, 24);
            this.lblBelegDatum.TabIndex = 34;
            this.lblBelegDatum.Text = "Beleg Datum";
            this.lblBelegDatum.UseCompatibleTextRendering = true;
            //
            // edtBelegDatum
            //
            this.edtBelegDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBelegDatum.DataMember = "BelegDatum";
            this.edtBelegDatum.DataSource = this.qryAuszahlweg;
            this.edtBelegDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegDatum.EditValue = null;
            this.edtBelegDatum.Location = new System.Drawing.Point(843, 62);
            this.edtBelegDatum.Name = "edtBelegDatum";
            this.edtBelegDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBelegDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatum.Properties.ReadOnly = true;
            this.edtBelegDatum.Properties.ShowToday = false;
            this.edtBelegDatum.Size = new System.Drawing.Size(100, 24);
            this.edtBelegDatum.TabIndex = 35;
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.grdKrankenkasse);
            this.panDetails.Controls.Add(this.panDetailsDetails);
            this.panDetails.Controls.Add(this.panDetailsFT);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetails.Location = new System.Drawing.Point(0, 188);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(992, 381);
            this.panDetails.TabIndex = 2;
            //
            // panDetailsDetails
            //
            this.panDetailsDetails.Controls.Add(this.lblAuszahlungsart);
            this.panDetailsDetails.Controls.Add(this.edtRestbetrag);
            this.panDetailsDetails.Controls.Add(this.edtBelegDatum);
            this.panDetailsDetails.Controls.Add(this.lblRestbetrag);
            this.panDetailsDetails.Controls.Add(this.lblBelegDatum);
            this.panDetailsDetails.Controls.Add(this.lblRestbetragCHF);
            this.panDetailsDetails.Controls.Add(this.lblVerwPeriodeStrich);
            this.panDetailsDetails.Controls.Add(this.lblTotalbetragCHF);
            this.panDetailsDetails.Controls.Add(this.edtBelegNr);
            this.panDetailsDetails.Controls.Add(this.lblBuchungstext);
            this.panDetailsDetails.Controls.Add(this.edtTotalbetrag);
            this.panDetailsDetails.Controls.Add(this.lblBelegNr);
            this.panDetailsDetails.Controls.Add(this.edtBuchungstext);
            this.panDetailsDetails.Controls.Add(this.lblTotalbetrag);
            this.panDetailsDetails.Controls.Add(this.edtBelegID);
            this.panDetailsDetails.Controls.Add(this.lblZahlungsgrund);
            this.panDetailsDetails.Controls.Add(this.edtReferenzNummer);
            this.panDetailsDetails.Controls.Add(this.lblBelegID);
            this.panDetailsDetails.Controls.Add(this.edtMitteilungZeile1);
            this.panDetailsDetails.Controls.Add(this.lblReferenzNummer);
            this.panDetailsDetails.Controls.Add(this.ctlErfassungMutation);
            this.panDetailsDetails.Controls.Add(this.edtMitteilungZeile2);
            this.panDetailsDetails.Controls.Add(this.edtAuszahlungsart);
            this.panDetailsDetails.Controls.Add(this.edtZusatzInfo);
            this.panDetailsDetails.Controls.Add(this.edtSplittingArtCode);
            this.panDetailsDetails.Controls.Add(this.edtMitteilungZeile3);
            this.panDetailsDetails.Controls.Add(this.lblValutaDatum);
            this.panDetailsDetails.Controls.Add(this.edtKreditor);
            this.panDetailsDetails.Controls.Add(this.lblBgSplittingCode);
            this.panDetailsDetails.Controls.Add(this.lblVerwPeriode);
            this.panDetailsDetails.Controls.Add(this.edtValutaDatum);
            this.panDetailsDetails.Controls.Add(this.lblKreditor);
            this.panDetailsDetails.Controls.Add(this.edtVerwPeriodeBis);
            this.panDetailsDetails.Controls.Add(this.edtVerwPeriodeVon);
            this.panDetailsDetails.Controls.Add(this.lblRechnungDatum);
            this.panDetailsDetails.Controls.Add(this.edtRechnungDatum);
            this.panDetailsDetails.Controls.Add(this.panSetStatus);
            this.panDetailsDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetailsDetails.Location = new System.Drawing.Point(0, 135);
            this.panDetailsDetails.Name = "panDetailsDetails";
            this.panDetailsDetails.Size = new System.Drawing.Size(992, 246);
            this.panDetailsDetails.TabIndex = 2;
            //
            // panSetStatus
            //
            this.panSetStatus.Controls.Add(this.panSetStatusBorder);
            this.panSetStatus.Controls.Add(this.btnFreigeben);
            this.panSetStatus.Controls.Add(this.btnElAuszahlungLoeschen);
            this.panSetStatus.Controls.Add(this.btnSILAntragBearbeiten);
            this.panSetStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.panSetStatus.Location = new System.Drawing.Point(957, 0);
            this.panSetStatus.Name = "panSetStatus";
            this.panSetStatus.Size = new System.Drawing.Size(35, 246);
            this.panSetStatus.TabIndex = 36;
            //
            // panSetStatusBorder
            //
            this.panSetStatusBorder.BackColor = System.Drawing.Color.Black;
            this.panSetStatusBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panSetStatusBorder.Location = new System.Drawing.Point(0, 0);
            this.panSetStatusBorder.Name = "panSetStatusBorder";
            this.panSetStatusBorder.Size = new System.Drawing.Size(1, 246);
            this.panSetStatusBorder.TabIndex = 0;
            //
            // btnFreigeben
            //
            this.btnFreigeben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreigeben.Location = new System.Drawing.Point(6, 9);
            this.btnFreigeben.Name = "btnFreigeben";
            this.btnFreigeben.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
            this.btnFreigeben.Size = new System.Drawing.Size(24, 24);
            this.btnFreigeben.TabIndex = 1;
            this.btnFreigeben.Text = "F";
            this.btnFreigeben.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFreigeben.UseVisualStyleBackColor = false;
            this.btnFreigeben.Click += new System.EventHandler(this.btnFreigeben_Click);
            //
            // panDetailsFT
            //
            this.panDetailsFT.Controls.Add(this.edtPerson);
            this.panDetailsFT.Controls.Add(this.lblFalltraeger);
            this.panDetailsFT.Controls.Add(this.btnGotoFinanzPlan);
            this.panDetailsFT.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDetailsFT.Location = new System.Drawing.Point(0, 0);
            this.panDetailsFT.Name = "panDetailsFT";
            this.panDetailsFT.Size = new System.Drawing.Size(992, 39);
            this.panDetailsFT.TabIndex = 0;
            //
            // edtPerson
            //
            this.edtPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPerson.DataMember = "Person";
            this.edtPerson.DataSource = this.qryFall;
            this.edtPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPerson.Location = new System.Drawing.Point(108, 9);
            this.edtPerson.Name = "edtPerson";
            this.edtPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPerson.Properties.ReadOnly = true;
            this.edtPerson.Size = new System.Drawing.Size(756, 24);
            this.edtPerson.TabIndex = 1;
            this.edtPerson.TabStop = false;
            //
            // lblFalltraeger
            //
            this.lblFalltraeger.Location = new System.Drawing.Point(9, 9);
            this.lblFalltraeger.Name = "lblFalltraeger";
            this.lblFalltraeger.Size = new System.Drawing.Size(93, 24);
            this.lblFalltraeger.TabIndex = 0;
            this.lblFalltraeger.Text = "Fallträger/-in";
            this.lblFalltraeger.UseCompatibleTextRendering = true;
            //
            // btnGotoFinanzPlan
            //
            this.btnGotoFinanzPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoFinanzPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoFinanzPlan.Location = new System.Drawing.Point(870, 9);
            this.btnGotoFinanzPlan.Name = "btnGotoFinanzPlan";
            this.btnGotoFinanzPlan.Size = new System.Drawing.Size(113, 24);
            this.btnGotoFinanzPlan.TabIndex = 2;
            this.btnGotoFinanzPlan.Text = "> Finanzplan";
            this.btnGotoFinanzPlan.UseCompatibleTextRendering = true;
            this.btnGotoFinanzPlan.UseVisualStyleBackColor = false;
            this.btnGotoFinanzPlan.Click += new System.EventHandler(this.btnGotoFinanzPlan_Click);
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabControlSearch;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 180);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // CtlBatchKVG
            //
            this.ActiveSQLQuery = this.qryFall;
            this.ClientSize = new System.Drawing.Size(992, 569);
            this.Controls.Add(this.panDetails);
            this.Controls.Add(this.splitter);
            this.Name = "CtlBatchKVG";
            this.Load += new System.EventHandler(this.CtlBatchKVG_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.panDetails, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePositionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFalltraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePositionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKrankenkasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKrankenkasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKrankenkasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemStatusImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnKVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnKVGMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnVVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemZahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAuszahlweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalbetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalbetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalbetragCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRestbetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRestbetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRestbetragCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplittingArtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplittingArtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).EndInit();
            this.panDetails.ResumeLayout(false);
            this.panDetailsDetails.ResumeLayout(false);
            this.panSetStatus.ResumeLayout(false);
            this.panDetailsFT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFalltraeger)).EndInit();
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

        private void BtnGridKVGMax_Click(object sender, EventArgs e)
        {
            // do it
            HandleGridButtonClick(colKKBgKVGMax.FieldName, colKKZahlungKVGMax.FieldName);
        }

        private void BtnGridKVG_Click(object sender, EventArgs e)
        {
            // do it
            HandleGridButtonClick(colKKBgKVG.FieldName, colKKZahlungKVG.FieldName);
        }

        private void BtnGridVVG_Click(object sender, EventArgs e)
        {
            // do it
            HandleGridButtonClick(colKKBgVVG.FieldName, colKKZahlungVVG.FieldName);
        }

        private void CtlBatchKVG_Load(object sender, EventArgs e)
        {
            // attach events
            repItemBtnKVG.Click += BtnGridKVG_Click;
            repItemBtnKVGMax.Click += BtnGridKVGMax_Click;
            repItemBtnVVG.Click += BtnGridVVG_Click;

            // disable fields of fall
            qryFall.EnableBoundFields(false);

            // start with a new search
            NewSearch();

            // validate values
            if (_maxKVGPerPerson < 0m || _maxVVGPerPerson < 0m)
            {
                // show info
                KissMsg.ShowInfo(this.Name,
                                 "CouldNotGetMaxKVGVVG",
                                 "Die maximalen KVG- und VVG-Beiträge gemäss SKOS konnten nicht ermittelt werden. Bitte überprüfen Sie die Einstellungen.");
            }

            // load buchungsstatus
            repItemStatusImage.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStatus = DBUtil.OpenSQL(@"
                SELECT Text,
                       Code,
                       Value1
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'KbBuchungsStatus'
                ORDER BY SortKey;");

            // convert icons and add them to repository item
            foreach (DataRow row in qryStatus.DataTable.Rows)
            {
                repItemStatusImage.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(row["Text"].ToString(),
                                                                                                   Convert.ToInt32(row["Code"]),
                                                                                                   KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            // set repository items
            colKKBgKVGStatus.ColumnEdit = repItemStatusImage;
            colKKBgKVGMaxStatus.ColumnEdit = repItemStatusImage;
            colKKBgVVGStatus.ColumnEdit = repItemStatusImage;

            colKKZahlungKVGStatus.ColumnEdit = repItemStatusImage;
            colKKZahlungKVGMaxStatus.ColumnEdit = repItemStatusImage;
            colKKZahlungVVGStatus.ColumnEdit = repItemStatusImage;

            // init gui
            ResetAuszahlweg();
        }

        private void btnElAuszahlungLoeschen_Click(object sender, System.EventArgs e)
        {
            try
            {
                // VALIDATE:
                // get vars
                int bgBudgetID = DBUtil.IsEmpty(qryKrankenkasse["BgBudgetID"]) ? -1 : Convert.ToInt32(qryKrankenkasse["BgBudgetID"]);
                int belegID = DBUtil.IsEmpty(qryKrankenkasse["BelegID"]) ? -1 : Convert.ToInt32(qryKrankenkasse["BelegID"]);
                int kbAuszahlungsArtCode = ShUtil.GetCode(qryKrankenkasse["KbAuszahlungsArtCode"]);

                bool isElAuszahlungPapVerf = DBUtil.IsEmpty(qryKrankenkasse["KbAuszahlungsArtCode"]) ? false :
                    ((kbAuszahlungsArtCode == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung)) ||
                     (kbAuszahlungsArtCode == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung)));

                bool isElAuszPapVerfFreigegeben = isElAuszahlungPapVerf &&
                                               !DBUtil.IsEmpty(qryKrankenkasse["KbBuchungStatusCode"]) &&
                                               Convert.ToInt32(qryKrankenkasse["KbBuchungStatusCode"]) == KBBUCHUNGSTATUSCODEFREIGEGEBEN;

                // validate ids and flags
                if (bgBudgetID < 1 || belegID < 1 || !isElAuszahlungPapVerf)
                {
                    // cannot use button, show info and stop
                    KissMsg.ShowError(this.Name, "CannotDeleteEntry", "Diese Funktion ist für den gewählten Datensatz nicht zulässig.");
                    btnElAuszahlungLoeschen.Enabled = false;
                    return;
                }

                // check state, can only be done if freigegeben, not further on
                if (!isElAuszPapVerfFreigegeben)
                {
                    // cannot use button, show info and stop
                    KissMsg.ShowError(this.Name,
                                      "CannotDeleteEntryBelegNr_v01",
                                      "Diese Beleg-Nr. wurde bereits weiter verarbeitet und kann hier nicht mehr rückgängig gemacht werden.");
                    btnElAuszahlungLoeschen.Enabled = false;
                    return;
                }

                // validate if ALL entries in KbBuchung have proper state
                bool canDeleteEntries = Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                    -- vars
                    DECLARE @BgBudgetID INT;
                    DECLARE @BelegID INT;
                    DECLARE @KbBuchungStatusCode INT;
                    DECLARE @Count INT;

                    -- set vars
                    SET @BgBudgetID = {0};
                    SET @BelegID = {1};
                    SET @KbBuchungStatusCode = {2};

                    -- request data
                    SELECT @Count = COUNT(KBB.KbBuchungStatusCode)
                    FROM dbo.KbBuchungKostenart KBK
                      INNER JOIN dbo.KbBuchung  KBB ON KBB.KbBuchungID = KBK.KbBuchungID
                                                   AND KBB.BgBudgetID = @BgBudgetID
                    WHERE KBK.BgPositionID IN (SELECT POS.BgPositionID
                                               FROM dbo.BgPosition POS
                                               WHERE BgPositionID = @BelegID OR BgPositionID_Parent = @BelegID)
                      AND KBB.KbBuchungStatusCode <> @KbBuchungStatusCode;

                    -- required zero count for success
                    IF (ISNULL(@Count, -1) = 0)
                    BEGIN
                      -- success
                      SELECT [Valid] = 1;
                    END
                    ELSE
                    BEGIN
                      -- failure
                      SELECT [Valid] = 0;
                    END;", bgBudgetID, belegID, KBBUCHUNGSTATUSCODEFREIGEGEBEN));

                // check if delete can be done
                if (!canDeleteEntries)
                {
                    // cannot use button, show info and stop
                    KissMsg.ShowError(this.Name,
                                      "CannotDeleteNotAllFreigegeben",
                                      "Nicht alle Zahlungen haben den Status 'Freigegeben'. Dieser Beleg kann nicht gelöscht werden.");
                    btnElAuszahlungLoeschen.Enabled = false;
                    return;
                }

                // CONFIRM
                // confirm to remove data
                if (!KissMsg.ShowQuestion(this.Name,
                                          "ConfirmDelete",
                                          "Wollen Sie die erfassten Zahlungen zu diesem Beleg wirklich löschen?\r\n\r\nAchtung: Die Verarbeitung dauert einen Moment!"))
                {
                    // do not continue
                    return;
                }

                // remove depending data, use query to set filltimeout and getting error code
                SqlQuery qryDeleteBelegID = new SqlQuery();
                qryDeleteBelegID.FillTimeOut = 90; // 1.5min

                // do delete in a transaction
                Session.BeginTransaction();

                try
                {
                    // delete data and fill result in query
                    qryDeleteBelegID.Fill(@"
                        -- INIT:
                        -- init vars
                        DECLARE @BelegID INT;
                        SET @BelegID = {0};

                        DECLARE @ErrCode INT;
                        SET @ErrCode = NULL;

                        DECLARE @BgPositionIDs TABLE
                        (
                          BgPositionID INT NOT NULL
                        );

                        DECLARE @KbBuchungIDs TABLE
                        (
                          KbBuchungID INT NOT NULL
                        );

                        -- insert ids of BgPosition into temp table
                        INSERT INTO @BgPositionIDs
                          SELECT BgPositionID
                          FROM dbo.BgPosition
                          WHERE (BgPositionID = @BelegID OR BgPositionID_Parent = @BelegID);

                        SET @ErrCode = CASE
                                         WHEN ISNULL(@ErrCode, 0) = 0 THEN @@ERROR
                                         ELSE @ErrCode
                                       END;

                        -- insert ids of KbBuchung into temp table
                        INSERT INTO @KbBuchungIDs
                          SELECT KbBuchungID
                          FROM dbo.KbBuchungKostenart
                          WHERE BgPositionID IN (SELECT BgPositionID
                                                 FROM @BgPositionIDs);

                        SET @ErrCode = CASE
                                         WHEN ISNULL(@ErrCode, 0) = 0 THEN @@ERROR
                                         ELSE @ErrCode
                                       END;

                        -- KLIBU: delete entries in KliBu
                        DELETE FROM dbo.KbBuchungKostenart
                        WHERE BgPositionID IN (SELECT BgPositionID
                                               FROM @BgPositionIDs);

                        SET @ErrCode = CASE
                                         WHEN ISNULL(@ErrCode, 0) = 0 THEN @@ERROR
                                         ELSE @ErrCode
                                       END;

                        DELETE FROM dbo.KbBuchung
                        WHERE KbBuchungID IN (SELECT KbBuchungID
                                              FROM @KbBuchungIDs);

                        SET @ErrCode = CASE
                                         WHEN ISNULL(@ErrCode, 0) = 0 THEN @@ERROR
                                         ELSE @ErrCode
                                       END;

                        -- BUDGET: delete entries in Budget
                        DELETE FROM dbo.BgPosition
                        WHERE BgPositionID IN (SELECT BgPositionID
                                               FROM @BgPositionIDs);

                        SET @ErrCode = CASE
                                         WHEN ISNULL(@ErrCode, 0) = 0 THEN @@ERROR
                                         ELSE @ErrCode
                                       END;

                        -- FINISH:
                        -- show result (=0 -> success, do commit; <>0 -> failure, do rollback)
                        SELECT [ErrorCode] = ISNULL(@ErrCode, 0);", belegID);

                    // check state (expect errorcode column exists, otherwise something went wrong and we do a rollback in catch-block)
                    if (qryDeleteBelegID.Count == 1 && Convert.ToInt32(qryDeleteBelegID["ErrorCode"]) == 0)
                    {
                        // no error returned, success
                        Session.Commit();
                    }
                    else
                    {
                        // an error occured, do rollback
                        Session.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    // do rollback if transaction is still open
                    if (Session.Transaction != null)
                    {
                        Session.Transaction.Rollback();
                    }

                    // logging
                    _logger.ErrorFormat("Error occured while deleting entries.", ex);
                }

                // check if done
                if (qryDeleteBelegID.Count != 1 || DBUtil.IsEmpty(qryDeleteBelegID["ErrorCode"]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "ErrorDeleteGettingErrorState",
                                                                     "Das Löschen der Datensätze ist fehlgeschlagen:\r\nKein Datensatz oder der Fehler-Code ist unbekannt."));
                }

                if (Convert.ToInt32(qryDeleteBelegID["ErrorCode"]) != 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "ErrorDeleteHavingError",
                                                                     "Das Löschen der Datensätze ist fehlgeschlagen:\r\nDer Fehler-Code '{0}' ist aufgetreten.",
                                                                     qryDeleteBelegID["ErrorCode"]));
                }

                // refresh data in grids
                RefreshData();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorEditElAuszahlung", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
        }

        private void btnFreigeben_Click(object sender, EventArgs e)
        {
            // set cursor
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // do it
                ReleasePosition();
            }
            catch (KissInfoException ex)
            {
                // show info message
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(this.Name, "ErrorBtnFreigeben", "Es ist ein Fehler beim Freigeben der Position(en) aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnGotoFinanzPlan_Click(object sender, System.EventArgs e)
        {
            // jump to Finanzplan by id
            if (qryFall.Count > 0 && !DBUtil.IsEmpty(qryFall["BgFinanzplanID"]))
            {
                FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                                        "BaPersonID", qryFall["BaPersonID"],
                                        "ModulID", 3,
                                        "FieldValue", string.Format("CtlWhFinanzplan{0}", qryFall["BgFinanzplanID"]));
            }
        }

        private void btnSILAntragBearbeiten_Click(object sender, System.EventArgs e)
        {
            // setup button depending on current data
            if (!DBUtil.IsEmpty(qryKrankenkasse["BelegID"]) &&
                !DBUtil.IsEmpty(qryKrankenkasse["KbAuszahlungsArtCode"]) &&
                Convert.ToInt32(qryKrankenkasse["KbAuszahlungsArtCode"]) != Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag))
            {
                // cannot use button, show info and stop
                KissMsg.ShowError(this.Name, "SILAntragNotAllowed", "Diese Funktion ist für den gewählten Datensatz nicht zulässig.");
                btnSILAntragBearbeiten.Enabled = false;
                return;
            }

            // fill data and enable edit
            InitAuszahlweg(false, Convert.ToInt32(qryKrankenkasse["BelegID"]));
        }

        private void edtAuszahlungsart_EditValueChanged(object sender, System.EventArgs e)
        {
            // enable/disable fields
            SetEditModeAuszahlweg();
        }

        private void edtKreditor_EditValueChanged(object sender, System.EventArgs e)
        {
            // enable/disable fields
            SetEditModeAuszahlweg();
        }

        private void edtKreditor_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // show dialog to select Kreditor
            e.Cancel = AuswahlKreditor(edtKreditor.EditValue.ToString(), e.ButtonClicked);

            // setup controls
            SetEditModeAuszahlweg();
        }

        private void edtSucheFalltraeger_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // show dialog to select Falltraeger
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.ShFalltraegerSuchen(edtSucheFalltraeger.Text, true, e.ButtonClicked);

            if (!e.Cancel)
            {
                // apply values (1. EditValue, 2.ID!!)
                edtSucheFalltraeger.EditValue = dlg["Name"];
                edtSucheFalltraeger.LookupID = dlg["BaPersonID"];
            }
        }

        private void edtSucheSAR_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // show dialog to select SAR
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSucheSAR.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                // apply values (1. EditValue, 2.ID!!)
                edtSucheSAR.EditValue = dlg["Name"];
                edtSucheSAR.LookupID = dlg["UserID"];
            }
        }

        private void edtTotalbetrag_EditValueChanged(object sender, System.EventArgs e)
        {
            // update restbetrag if possible
            UpdateSum();
        }

        private void edtTotalbetrag_Leave(object sender, EventArgs e)
        {
            // update restbetrag if possible
            UpdateSum();
        }

        private void grvKrankenkasse_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // update restbetrag if possible
            UpdateSum();
        }

        private void grvKrankenkasse_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                // check mode
                if (!_isEditingAuszahlwegData)
                {
                    // do not handle drawing
                    return;
                }

                // check column
                if (e.Column != colKKKVGButton &&
                    e.Column != colKKKVGMaxButton &&
                    e.Column != colKKVVGButton &&
                    e.Column != colKKZahlungKVG &&
                    e.Column != colKKZahlungKVGMax &&
                    e.Column != colKKZahlungVVG &&
                    e.Column != colKKBemerkung)
                {
                    // do not handle this column
                    return;
                }

                // check if BelegID is given (no id = can change values; id set = cannot change row if not same id)
                int rowBelegID = DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(e.RowHandle, "BelegID")) ? -1 : Convert.ToInt32(grvKrankenkasse.GetRowCellValue(e.RowHandle, "BelegID"));
                bool canAlterValue = rowBelegID == _editBelegID;

                // logging
                ////_logger.Debug(string.Format("CustomDrawCell - rowBelegID='{0}', this.EditBelegID='{1}'", rowBelegID, this._editBelegID));

                // check column: if BetragKVG is null, we cannot modify ZahlungKVG and so on...
                if ((e.Column == colKKZahlungKVG && DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(e.RowHandle, "BetragKVG"))) ||
                    (e.Column == colKKZahlungKVGMax && DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(e.RowHandle, "BetragKVGMax"))) ||
                    (e.Column == colKKZahlungVVG && DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(e.RowHandle, "BetragVVG"))))
                {
                    // edit is not allowed
                    canAlterValue = false;
                }

                // change background for editable columns
                if (e.Column != colKKKVGButton &&
                    e.Column != colKKKVGMaxButton &&
                    e.Column != colKKVVGButton)
                {
                    // change background color of this column depending on rights
                    e.Appearance.BackColor = canAlterValue ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;
                }
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                _logger.ErrorFormat("Error in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                // do not handle these errors but stop if debugger is available
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        private void grvKrankenkasse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // set last selected row if not currently in qryFall_PositionChanged
            if (!_isOnFillingKK)
            {
                // apply selected row handle
                _lastSelectedRowHandle = e.FocusedRowHandle;
            }
        }

        private void grvKrankenkasse_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                // check mode
                if (!_isEditingAuszahlwegData)
                {
                    // do nothing, already handled
                    return;
                }

                // check if BelegID is given (no id = can use editor (do not cancel); id set = cannot change row if not same id (do cancel))
                int focusedRowHandle = grvKrankenkasse.FocusedRowHandle;
                DevExpress.XtraGrid.Columns.GridColumn focusedColumn = grvKrankenkasse.FocusedColumn;
                int rowBelegID = DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(focusedRowHandle, "BelegID")) ? -1 : Convert.ToInt32(grvKrankenkasse.GetRowCellValue(focusedRowHandle, "BelegID"));
                bool canAlterValue = rowBelegID == _editBelegID;

                // check column: if BetragKVG is null, we cannot modify ZahlungKVG and so on...
                if (((focusedColumn == colKKZahlungKVG || focusedColumn == colKKKVGButton) && DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(focusedRowHandle, "BetragKVG"))) ||
                    ((focusedColumn == colKKZahlungKVGMax || focusedColumn == colKKKVGMaxButton) && DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(focusedRowHandle, "BetragKVGMax"))) ||
                    ((focusedColumn == colKKZahlungVVG || focusedColumn == colKKVVGButton) && DBUtil.IsEmpty(grvKrankenkasse.GetRowCellValue(focusedRowHandle, "BetragVVG"))))
                {
                    // edit is not allowed
                    canAlterValue = false;
                }

                // set if possible to edit field
                e.Cancel = !canAlterValue;
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                _logger.ErrorFormat("Error in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                // do not handle these errors but stop if debugger is available
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        private void qryAuszahlweg_AfterFill(object sender, System.EventArgs e)
        {
            // show data on controls
            ctlErfassungMutation.ShowInfo();

            // update sum if possible
            UpdateSum();

            // handle controls
            SetEditModeAuszahlweg();

            // enable buttons
            EnableStatusButtons();
        }

        private void qryAuszahlweg_AfterInsert(object sender, System.EventArgs e)
        {
            // setup default values
            qryAuszahlweg["KbAuszahlungsArtCode"] = _ezStandardAuszahlungsart;
            qryAuszahlweg["BgSplittingArtCode"] = _splittingArtCode;

            // setup default values
            SetVerwendungsPeriode();
        }

        private void qryAuszahlweg_BeforePost(object sender, System.EventArgs e)
        {
            // save current cursor
            Cursor saveCursor = Cursor.Current;
            KissCancelException cancelEx = new KissCancelException();

            try
            {
                // POSSIBLE CHECK:
                // update restbetrag if possible (sometimes, value is not calculated)
                UpdateSum();

                // validate
                if (!_canSaveChanges)
                {
                    // cannot save data
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "ErrorSavingNotPossible",
                                                                     "Die Zahlungen können so nicht gespeichert werden, da ein Restbetrag besteht.\r\nBitte überprüfen Sie die eingetragenen Werte."));
                }

                // INIT:
                // cursor
                Cursor.Current = Cursors.WaitCursor;

                // setup mode full/partial update/insert
                bool isSILAntrag = Convert.ToInt32(qryAuszahlweg["KbAuszahlungsArtCode"]) == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag);
                bool updateData = !DBUtil.IsEmpty(qryAuszahlweg["BelegID"]) && Convert.ToInt32(qryAuszahlweg["BelegID"]) > 0;

                // VALIDATE
                // check BelegNr and BelegDatum
                if (!DBUtil.IsEmpty(qryAuszahlweg[edtBelegNr.DataMember]) || !DBUtil.IsEmpty(qryAuszahlweg[edtBelegDatum.DataMember]))
                {
                    // if we have a BelegNr or BelegDatum, we cannot alter this entry!
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "HavingBelegNrDatumCannotSave",
                                                                     "Es ist bereits eine Beleg-Nr. und/oder ein Beleg Datum vorhanden. Änderungen sind daher nicht mehr möglich."));
                }

                // update restbetrag if possible (do it again!)
                UpdateSum();

                // reset fields depending on Auszahlungsart and EinzahlungsscheinCode
                SetEditModeAuszahlweg();

                // check must-fields
                DBUtil.CheckNotNullField(edtAuszahlungsart, lblAuszahlungsart.Text);
                DBUtil.CheckNotNullField(edtValutaDatum, lblValutaDatum.Text);
                DBUtil.CheckNotNullField(edtTotalbetrag, lblTotalbetrag.Text);
                DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);

                // validate VerwPeriode
                CtlWhAuszahlungen.ValidateAndHandleVerwPeriode(ref qryAuszahlweg, ref edtVerwPeriodeVon, ref edtVerwPeriodeBis);

                // check if not precoverage, ensure valid zahlungsweg
                if (!isSILAntrag)
                {
                    // a valid kreditor and referenznummer must be given
                    DBUtil.CheckNotNullField(edtKreditor, lblKreditor.Text);

                    // set Einzahlungsschein
                    int esCode = DBUtil.IsEmpty(qryAuszahlweg["EinzahlungsscheinCode"]) ? -1 : Convert.ToInt32(qryAuszahlweg["EinzahlungsscheinCode"]);

                    // validate referenznummer if ESOrange
                    if (esCode == Convert.ToInt32(BgEinzahlungsschein.ESOrange))
                    {
                        DBUtil.CheckNotNullField(edtReferenzNummer, lblReferenzNummer.Text);

                        SqlQuery qry = DBUtil.OpenSQL(@"
                                SELECT PostKontoNummer
                                FROM dbo.BaZahlungsweg WITH (READUNCOMMITTED)
                                WHERE BaZahlungswegID = {0};", qryAuszahlweg["BaZahlungswegID"]);

                        if (qry.Count == 1 && !edtReferenzNummer.ValidateReferenzNummer(qry["PostKontoNummer"].ToString()))
                        {
                            edtReferenzNummer.Focus();
                            throw new KissCancelException();
                        }
                    }
                }

                // check totalbetrag, must be > 0m
                decimal? totalBetrag = edtTotalbetrag.EditValue as decimal?;

                if (!totalBetrag.HasValue || totalBetrag <= 0m)
                {
                    edtTotalbetrag.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "InvalidTotalBetragBiggerZero",
                                                                     "Der Totalbetrag muss grösser als Null sein."));
                }

                // check restbetrag, must be 0m!
                decimal? restBetrag = edtRestbetrag.EditValue as decimal?;

                if (!restBetrag.HasValue || restBetrag != 0m)
                {
                    edtTotalbetrag.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "InvalidRemainingNotZero",
                                                                     "Der Restbetrag muss genau auf Null sein."));
                }

                // SAVE DATA TO Budget (and KliBu)
                // begin new transaction
                Session.BeginTransaction();

                try
                {
                    // save changes (depending on Auszahlungsart and insert/update)
                    SaveAuszahlweg(isSILAntrag, updateData, true);

                    // done with saving
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    throw ex;
                }

                // FINISH
                // discard changes on query
                qryAuszahlweg.RowModified = false;
                qryAuszahlweg.Row.AcceptChanges();

                // done with manual processing, refresh display
                _isEditingAuszahlwegData = false;

                InitAuszahlweg(false);
                OnRefreshData();
            }
            catch (KissCancelException cex)
            {
                // canceling error, e.g. CheckNotNullField; apply and handle in finally
                cancelEx = cex;
                throw cancelEx;
            }
            catch (Exception ex)
            {
                // show error to the user
                KissMsg.ShowError(this.Name,
                                  "ErrorBeforePostQryAuszahlweg",
                                  "Es ist ein Fehler beim Speichern der Daten aufgetreten. Die Daten wurden nicht gespeichert.", ex);

                // cancel post
                throw new KissCancelException();
            }
            finally
            {
                // cursor
                Cursor.Current = saveCursor;

                // cancel execution (default: no message to prevent showing error, handled above if error)
                throw cancelEx;
            }
        }

        private void qryFall_PositionChanged(object sender, System.EventArgs e)
        {
            try
            {
                // set flag
                _isOnFillingKK = true;

                // check if need to reset fields
                if (qryFall.Count < 1 || DBUtil.IsEmpty(qryFall["FaLeistungID"]))
                {
                    // reset fields
                    _lastSelectedRowHandle = 0;
                    _lastSelectedFaLeistungID = -1;
                }
                else
                {
                    // check if need to reset last selected row
                    if (_lastSelectedFaLeistungID != Convert.ToInt32(qryFall["FaLeistungID"]))
                    {
                        // changed FaLeistungID, so do not reapply last selected row
                        _lastSelectedRowHandle = 0;
                    }

                    // apply new faLeistungID
                    _lastSelectedFaLeistungID = Convert.ToInt32(qryFall["FaLeistungID"]);
                }

                // apply id and show details
                qryKrankenkasse.Fill(qryFall["FaLeistungID"], edtSucheMonat.EditValue, edtSucheJahr.EditValue);

                // do grouping
                colKKMonatsbudget.GroupIndex = 0;
                colKKKrankenkasse.GroupIndex = 1;

                // init grid with summary items
                this.grvKrankenkasse.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragKVG", colKKBgKVG, "{0:F}"),
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragKVGMax", colKKBgKVGMax, "{0:F}"),
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragVVG", colKKBgVVG, "{0:F}"),
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZahlungKVG", colKKZahlungKVG, "{0:F}"),
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZahlungKVGMax", colKKZahlungKVGMax, "{0:F}"),
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZahlungVVG", colKKZahlungVVG, "{0:F}")});

                // show first entries (whole group)
                /*
                grdKrankenkasse.View.MoveFirst();
                grdKrankenkasse.View.ExpandGroupRow(grdKrankenkasse.View.FocusedRowHandle, true);
                */

                // set last selected row and index
                grdKrankenkasse.View.FocusedRowHandle = _lastSelectedRowHandle;
                _lastSelectedRowHandle = grdKrankenkasse.View.FocusedRowHandle;

                // reset auszahlweg
                ResetAuszahlweg();

                // update position
                qryKrankenkasse_PositionChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // show exception
                KissMsg.ShowError(this.Name, "ErrorFallPositionChanged", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // reset flags
                _isOnFillingKK = false;
            }
        }

        private void qryKrankenkasse_PositionChanged(object sender, System.EventArgs e)
        {
            // check if not in inserting data
            if (_isEditingAuszahlwegData)
            {
                // already editing data, cannot use buttons
                btnSILAntragBearbeiten.Enabled = false;
                btnElAuszahlungLoeschen.Enabled = false;

                // nothing else to do, stop here
                return;
            }

            //update SplittingArtCode

            if (!DBUtil.IsEmpty(qryKrankenkasse["BgBudgetID"]))
            {
                _splittingArtCode = GetSplittingArtCode(Utils.ConvertToInt(qryKrankenkasse["BgBudgetID"]));
            }

            // BUTTONS:
            // setup buttons depending on current data
            if (!DBUtil.IsEmpty(qryKrankenkasse["BelegID"]) && !DBUtil.IsEmpty(qryKrankenkasse["KbAuszahlungsArtCode"]))
            {
                int kbAuszahlungsArtCode = ShUtil.GetCode(qryKrankenkasse["KbAuszahlungsArtCode"]);

                // setup flags
                bool isSILAntrag = kbAuszahlungsArtCode == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag);

                bool isElAuszahlungPapVerf = ((kbAuszahlungsArtCode == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung)) ||
                                              (kbAuszahlungsArtCode == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung)));

                bool isElAuszPapVerfFreigegeben = isElAuszahlungPapVerf &&
                                                  !DBUtil.IsEmpty(qryKrankenkasse["KbBuchungStatusCode"]) &&
                                                  Convert.ToInt32(qryKrankenkasse["KbBuchungStatusCode"]) == KBBUCHUNGSTATUSCODEFREIGEGEBEN;

                // can modify data
                btnSILAntragBearbeiten.Enabled = isSILAntrag;
                btnElAuszahlungLoeschen.Enabled = isElAuszPapVerfFreigegeben;
            }
            else
            {
                // can not modify or delete data
                btnSILAntragBearbeiten.Enabled = false;
                btnElAuszahlungLoeschen.Enabled = false;
            }

            // SHOW DATA
            // show containing data depending on selected row, if not already showing this entry
            if (qryAuszahlweg.Count != 1 ||
                DBUtil.IsEmpty(qryKrankenkasse["BelegID"]) ||
                DBUtil.IsEmpty(qryAuszahlweg["BelegID"]) ||
                Convert.ToInt32(qryKrankenkasse["BelegID"]) != Convert.ToInt32(qryAuszahlweg["BelegID"]))
            {
                // not showing same entry, so reload query
                qryAuszahlweg.Fill(qryKrankenkasse["BelegID"], _splittingArtCode);
            }

            // validate
            if (qryAuszahlweg.Count > 1)
            {
                // should not be more than one referenced entry, show error
                KissMsg.ShowError(this.Name,
                                  "WarningMultipleMatchingEntriesFound",
                                  "Es wurden mehr als einen korrespondierenden Datensatz als Auszahlweg gefunden. Die Anzeige ist möglicherweise nicht korrekt.");
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            // check if user is allowed to use Belegleser
            if (!_isEditingAuszahlwegData || qryAuszahlweg.Count != 1)
            {
                KissMsg.ShowInfo(this.Name, "BelegLeserMissingAuszahlweg", "Es muss zuerst ein neuer Auszahlweg erstellt werden.");
                return;
            }

            // check if user can modify data
            if (!qryAuszahlweg.CanUpdate)
            {
                KissMsg.ShowInfo(this.Name,
                                 "BelegLeserNoChangesAllowed",
                                 "Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            // check if right mode is selected
            if (DBUtil.IsEmpty(edtAuszahlungsart.EditValue) ||
                Convert.ToInt32(edtAuszahlungsart.EditValue) == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag))
            {
                KissMsg.ShowInfo(this.Name,
                                 "BelegLeserWrongAuszahlartSwitchNow",
                                 "Die gewählte Auszahlungsart ist für den Belegleser ungültig und wird nun angepasst.");
            }

            // setup auszahlungsart
            qryAuszahlweg["KbAuszahlungsartCode"] = _ezStandardAuszahlungsart;

            // do belegleser
            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;

            dlg.SucheBaZahlungsweg(beleg);

            switch (dlg.Count)
            {
                case 0:
                    KissMsg.ShowInfo(this.Name,
                                     "BelegLeserNoMatchingKreditor",
                                     "Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");

                    qryAuszahlweg["BaZahlungswegID"] = DBNull.Value;
                    qryAuszahlweg["ZusatzInfo"] = DBNull.Value;

                    if (beleg.Betrag > 0)
                    {
                        qryAuszahlweg["Totalbetrag"] = beleg.Betrag;
                    }

                    qryAuszahlweg["ReferenzNummer"] = beleg.ReferenzNummer;
                    break;

                case 1:
                    transfer = true;
                    break;

                default:
                    transfer = dlg.ShowDialog(this) == DialogResult.OK;
                    break;
            }

            if (transfer)
            {
                qryAuszahlweg["BaZahlungswegID"] = dlg["BaZahlungswegID"];
                qryAuszahlweg["Kreditor"] = dlg["Kreditor"];
                qryAuszahlweg["ZusatzInfo"] = dlg["ZusatzInfo"];
                qryAuszahlweg["ReferenzNummer"] = beleg.ReferenzNummer;
                qryAuszahlweg["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode"];

                if (beleg.Betrag > 0)
                {
                    qryAuszahlweg["Totalbetrag"] = beleg.Betrag;
                }
            }

            // refresh
            qryAuszahlweg.RefreshDisplay();
            UpdateSum();

            // setup controls
            SetEditModeAuszahlweg();
        }

        public override bool OnAddData()
        {
            // check if user can add new data
            if (qryFall.Count < 1 || qryKrankenkasse.Count < 1)
            {
                KissMsg.ShowInfo(this.Name,
                                 "FirstSelectClientAndBudget",
                                 "Bitte wählen Sie zuerst einen Fallträger mit entsprechenden Budget-Daten.");
                return false;
            }

            // check if already a new entry exists
            if (_isEditingAuszahlwegData)
            {
                KissMsg.ShowInfo(this.Name, "SaveChangesFirst", "Bitte speichern Sie zuerst den aktuellen Eintrag.");
                return false;
            }

            // ok, insert new entry into Auszahlweg
            return InitAuszahlweg(true);
        }

        public override bool OnDeleteData()
        {
            // remove entry if any available
            if (_isEditingAuszahlwegData)
            {
                // check mode (insert/update)
                if (_editBelegID == -1)
                {
                    // NEW ROW: confirm deleting data
                    if (KissMsg.ShowQuestion(this.Name, "ConfirmTrashingChanges", "Wollen Sie die aktuell erfassten Daten wirklich verwerfen?"))
                    {
                        try
                        {
                            // undo new entry
                            qryAuszahlweg.DeleteQuestion = null;
                            qryAuszahlweg.CanDelete = true;
                            qryAuszahlweg.Delete();
                        }
                        catch (Exception ex)
                        {
                            KissMsg.ShowError(this.Name, "ErrorOnDeleteData", "Es ist ein Fehler beim Löschen des neuen Eintrags aufgetreten.", ex);
                        }
                        finally
                        {
                            // prevent deleting again
                            qryAuszahlweg.CanDelete = false;

                            // refresh display
                            InitAuszahlweg(false);

                            // refresh data
                            OnRefreshData();
                        }
                    }
                }
                else
                {
                    // EDIT ROW: do cancel (confirm in SqlQuery.Cancel())
                    try
                    {
                        // undo changes
                        qryAuszahlweg.Cancel();

                        // check if user did confirm undo
                        if (!qryAuszahlweg.RowModified)
                        {
                            // reset flag to prevent post in refresh
                            _isEditingAuszahlwegData = false;

                            // refresh display
                            InitAuszahlweg(false);

                            // refresh data
                            OnRefreshData();
                        }
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError(this.Name,
                                          "ErrorOnUndoData",
                                          "Es ist ein Fehler beim Zurücksetzen des geänderten Eintrags aufgetreten.", ex);
                    }
                }
            }

            // nothing to do anymore
            return true;
        }

        public override void OnRefreshData()
        {
            // do nothing if currently inserting data for a new Auszahlweg
            if (!_isEditingAuszahlwegData)
            {
                // nothing to change, refresh data (does it on both queries)
                qryFall.Refresh();
            }
        }

        public override bool OnSaveData()
        {
            // check if inserting data at the moment
            if (!_isEditingAuszahlwegData)
            {
                // nothing to save
                return true;
            }

            // save pending changes on Auszahlweg
            return InitAuszahlweg(false);
        }

        public override void OnUndoDataChanges()
        {
            // undo changes = delete inserted row on Auszahlweg
            OnDeleteData();
        }

        /// <summary>
        /// Translates the components of the instance
        /// </summary>
        public override void Translate()
        {
            // first, let base do stuff
            base.Translate();

            // setup controls for multilanguage handling
            SetupControlsML();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // disable Auszahlweg
            if (!InitAuszahlweg(false))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotSearchUnsavedData",
                                                                 "Es kann keine neue Suche begonnen werden, solange die vorhandenen Daten nicht korrekt gespeichert sind."));
            }

            // reset qryKrankenkasse
            qryKrankenkasse.Fill(-1, -1, -1);

            // let base do stuff
            base.NewSearch();

            // default search values
            edtSucheMonat.EditValue = DateTime.Today.Month;
            edtSucheJahr.EditValue = DateTime.Today.Year;

            // focus
            edtSucheFalltraeger.Focus();
        }

        protected override void RunSearch()
        {
            // check if search parameters are ok
            if (DBUtil.IsEmpty(edtSuchePositionID.EditValue) &&
                DBUtil.IsEmpty(edtSucheFalltraeger.EditValue) &&
                DBUtil.IsEmpty(edtSucheSAR.EditValue) &&
                DBUtil.IsEmpty(edtSucheName.EditValue))
            {
                // no month entered, cannot continue
                KissMsg.ShowInfo(this.Name, "EnterMissingSearchCriteria", "Es muss mindestens ein Suchkriterium angegeben werden.");

                // set tabpage
                tabControlSearch.SelectTab(tpgSuchen);

                // set focus
                edtSucheFalltraeger.Focus();

                // do not continue
                throw new KissCancelException();
            }

            // reset flags
            _lastSelectedRowHandle = 0;
            _lastSelectedFaLeistungID = -1;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Check if current data in Auszahlweg requires a ReferenzNummer
        /// </summary>
        /// <param name="esCode">The code number of the payin slip</param>
        /// <returns><c>True</c> if ReferenzNummer is required, otherwise <c>False</c></returns>
        private static bool RequiresReferenzNummer(int esCode)
        {
            return esCode == Convert.ToInt32(BgEinzahlungsschein.ESOrange);
        }

        #endregion

        #region Private Methods

        private bool AuswahlKreditor(string searchString, bool buttonClicked)
        {
            // check if data can be altered
            if (!qryAuszahlweg.CanUpdate || qryAuszahlweg.Count < 1 || edtKreditor.EditMode == EditModeType.ReadOnly)
            {
                // do nothing
                return false;
            }

            bool cancel = false;
            searchString = searchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryAuszahlweg["Kreditor"] = DBNull.Value;
                    qryAuszahlweg["ZusatzInfo"] = DBNull.Value;
                    qryAuszahlweg["BaZahlungswegID"] = DBNull.Value;
                    qryAuszahlweg["EinzahlungsscheinCode"] = DBNull.Value;
                    qryAuszahlweg["ReferenzNummer"] = DBNull.Value;
                    return false;
                }
            }

            if (searchString == ".")
            {
                // Auszahlung an
                // Klientensystem       	 - FaFallPerson
                // Involvierte Institutionen - FaFallPerson / BaPerson_BaInstitution
                KissLookupDialog dlg = new KissLookupDialog();

                var sql = string.Format(@"
                    -- Klientensystem
                    SELECT ID$         = KRE.BaZahlungswegID,
                           Typ         = '{0}',
                           Name        = KRE.InstitutionName,
                           Zahlungsweg = KRE.Zahlungsweg,
                           ESCode$     = KRE.EinzahlungsscheinCode,
                           Kreditor$   = KRE.Kreditor,
                           ZusatzInfo$ = KRE.ZusatzInfo,
                           SortKey$    = 1
                    FROM dbo.FaFallPerson       FAP WITH (READUNCOMMITTED)
                      INNER JOIN dbo.vwKreditor KRE WITH (READUNCOMMITTED) ON KRE.BaPersonID = FAP.BaPersonID
                    WHERE FAP.FaFallID = {{0}}

                    UNION

                    -- Involvierte Institutionen
                    SELECT ID$         = KRE.BaZahlungswegID,
                           Typ         = '{1}',
                           Name        = KRE.InstitutionName,
                           Zahlungsweg = KRE.Zahlungsweg,
                           ESCode$     = KRE.EinzahlungsscheinCode,
                           Kreditor$   = KRE.Kreditor,
                           ZusatzInfo$ = KRE.ZusatzInfo,
                           SortKey$    = 2
                    FROM dbo.FaFallPerson                   FFP WITH (READUNCOMMITTED)
                      INNER JOIN dbo.BaPerson_BaInstitution PIN WITH (READUNCOMMITTED) ON PIN.BaPersonID = FFP.BaPersonID
                      INNER JOIN dbo.vwKreditor             KRE WITH (READUNCOMMITTED) ON KRE.BaInstitutionID = PIN.BaInstitutionID
                    WHERE FaFallID = {{0}}
                    ORDER BY SortKey$, Name, Zahlungsweg;",
                    KissMsg.GetMLMessage(Name, "Klientensystem", "Klientensystem"),
                    KissMsg.GetMLMessage(Name, "Institutionen", "Institutionen"));

                cancel = !dlg.SearchData(sql, qryFall["FaFallID"].ToString(), buttonClicked, null, null, null);

                if (!cancel)
                {
                    qryAuszahlweg["Kreditor"] = dlg["Kreditor$"];
                    qryAuszahlweg["ZusatzInfo"] = dlg["ZusatzInfo$"];
                    qryAuszahlweg["BaZahlungswegID"] = dlg["ID$"];
                    qryAuszahlweg["EinzahlungsscheinCode"] = dlg["ESCode$"];

                    if (Convert.ToInt32(qryAuszahlweg["EinzahlungsscheinCode"]) != Convert.ToInt32(BgEinzahlungsschein.ESOrange))
                    {
                        qryAuszahlweg["ReferenzNummer"] = DBNull.Value;
                    }

                    return cancel;
                }
            }
            else
            {
                // Auszahlung Dritte
                DlgAuswahlBaZahlungsweg dlg2 = new DlgAuswahlBaZahlungsweg();
                ApplicationFacade.DoEvents();

                bool transfer = false;

                dlg2.SucheBaZahlungsweg(searchString);

                switch (dlg2.Count)
                {
                    case 0:
                        KissMsg.ShowInfo(this.Name,
                                         "NoMatchingCreditorEntryFound",
                                         "Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                        break;

                    case 1:
                        transfer = true;
                        break;

                    default:
                        transfer = dlg2.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (transfer)
                {
                    SqlQuery qry2 = DBUtil.OpenSQL(@"
                        SELECT VornameName, WohnsitzStrasseHausNr, WohnsitzPLZOrt
                        FROM dbo.vwPerson WITH (READUNCOMMITTED)
                        WHERE BaPersonID = {0}", qryFall["BaPersonID"]);

                    qryAuszahlweg["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                    qryAuszahlweg["Kreditor"] = dlg2["Kreditor"];
                    qryAuszahlweg["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryAuszahlweg["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];
                    qryAuszahlweg["MitteilungZeile1"] = Utils.TruncateString(qry2["VornameName"], 35);

                    if (Convert.ToInt32(qryAuszahlweg["EinzahlungsscheinCode"]) != Convert.ToInt32(BgEinzahlungsschein.ESOrange))
                    {
                        qryAuszahlweg["ReferenzNummer"] = DBNull.Value;
                    }
                }

                qryAuszahlweg.RefreshDisplay();
            }

            return cancel;
        }

        /// <summary>
        /// Check if position(s) can be released by button "Freigeben"
        /// </summary>
        /// <returns><c>True</c> if position(s) can be released, otherwise <c>False</c></returns>
        private bool CanReleasePosition()
        {
            // TODO: more!!??
            // -- rights (canupdate?)
            // ...

            // validate having data
            if (qryAuszahlweg.IsEmpty || qryKrankenkasse.IsEmpty)
            {
                // no data
                return false;
            }

            // check if currently editing data
            if (_isEditingAuszahlwegData || qryAuszahlweg.RowModified || qryKrankenkasse.RowModified)
            {
                // cannot release position if currently editing data
                return false;
            }

            // get some values
            int kategorie = ShUtil.GetCode(qryAuszahlweg["BgKategorieCode"]);
            int bgSplittingArtCode = ShUtil.GetCode(qryAuszahlweg["BgSplittingArtCode"]);
            //TODO: int status = ShUtil.GetCode(qryBgPosition["Status"]);

            // requires all required data to be given
            if (DBUtil.IsEmpty(qryAuszahlweg[edtAuszahlungsart.DataMember]) ||
                Convert.ToInt32(qryAuszahlweg[edtAuszahlungsart.DataMember]) == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag) ||

                DBUtil.IsEmpty(qryAuszahlweg[edtBuchungstext.DataMember]) ||
                DBUtil.IsEmpty(qryAuszahlweg[edtTotalbetrag.DataMember]) ||
                DBUtil.IsEmpty(qryAuszahlweg[edtValutaDatum.DataMember]) ||
                DBUtil.IsEmpty(qryAuszahlweg[edtKreditor.DataMember]) ||

                (RequiresReferenzNummer() && DBUtil.IsEmpty(qryAuszahlweg[edtReferenzNummer.DataMember])) ||
                (bgSplittingArtCode == 1 && (DBUtil.IsEmpty(qryAuszahlweg[edtVerwPeriodeVon.DataMember]) ||
                                             DBUtil.IsEmpty(qryAuszahlweg[edtVerwPeriodeBis.DataMember]))) ||
                (bgSplittingArtCode == 4 && DBUtil.IsEmpty(qryAuszahlweg[edtVerwPeriodeVon.DataMember])))
            {
                // we are missing some data
                return false;
            }

            // check current state (BelegID has to be given for security reason, Status == 14 (Bewilligt > LOV:KbBuchungStatus) and no BelegNr is set yet)
            if (DBUtil.IsEmpty(qryAuszahlweg[edtBelegID.DataMember]) ||
                //TODO:status != 14 ||
                !DBUtil.IsEmpty(qryAuszahlweg[edtBelegNr.DataMember]))
            {
                // wrong conditions
                return false;
            }

            // if we are here, everything is ok
            return true;
        }

        private DateTime? ConvertToDateTime(object dateTime)
        {
            if (DBUtil.IsEmpty(dateTime))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(dateTime);
            }
        }

        private void DeleteAuszahlwegData(int bgPositionID, int bgBudgetID, int baPersonID)
        {
            // validate first
            if (bgPositionID < 1 || bgBudgetID < 1 || baPersonID < 1)
            {
                // invalid values, do not delete
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "InvalidIDCannotDeleteEntry",
                                                                 "Ungültige IDs, Zahlung kann nicht gelöscht werden."));
            }

            // INFO: Do not handle BgPositionID_Parent changement. If root entry is deleted, others are still connected to
            //       each other with same id, the root id of BgPositionID_Parent is not needed for further processing.

            // BGPOSITION
            //   delete only this entry, others should be deleted by constraint
            //   use id, budget and person to ensure right entry is deleted
            int rowCount = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                -- delete entry
                DELETE FROM dbo.BgPosition
                WHERE BgPositionID = {0}
                  AND BgBudgetID = {1}
                  AND BaPersonID = {2};

                -- count affected rows to ensure correct behaviour
                SELECT ISNULL(@@ROWCOUNT, -1);", bgPositionID, bgBudgetID, baPersonID));

            // compare result with expected value
            if (rowCount != 1)
            {
                // more or less entries deleted, this should never happen
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "InvalidRowCountDelete",
                                                                 "Die Zahlung mit der ID '{0}' konnte nicht gelöscht werden. Die erwarteten Werte stimmen nicht mit den effektiven Werten überein.",
                                                                 bgPositionID));
            }
        }

        /// <summary>
        /// Enable or disable button freigeben depending on current states
        /// </summary>
        private void EnableBtnFreigeben()
        {
            // handle button Freigeben
            btnFreigeben.Enabled = CanReleasePosition();
        }

        private void EnableStatusButtons()
        {
            // handle buttons
            EnableBtnFreigeben();
        }

        private int GetSplittingArtCode(int bgBudgetID)
        {
            int splittingArtCode = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL((SELECT KOA.BgSplittingArtCode
                               FROM dbo.BgKostenart KOA WITH (READUNCOMMITTED)
                                INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = {0}
                                INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgKostenartID = KOA.BgKostenartID AND
                                   ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND
                                   ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
                                   AND BPA.BgPositionsartID = 32020), -1); -- KVG (32020)", bgBudgetID));

            if (splittingArtCode < 0)
            {
                // show info
                KissMsg.ShowInfo(this.Name,
                                 "CouldNotGetSplittingArt",
                                 "Die Splittingart konnten nicht ermittelt werden. Bitte überprüfen Sie die Einstellungen.");
            }

            return splittingArtCode;
        }

        private void HandleGridButtonClick(string betragFieldName, string zahlungFieldName)
        {
            // check if usage of button is possible
            if (!_isEditingAuszahlwegData)
            {
                // not allowed to edit, show info
                KissMsg.ShowInfo(this.Name,
                                 "CannotApplyAmountReadonlyRow",
                                 "Der gewünschte Betrag kann nicht übernommen werden, da die aktuelle Zeile nicht bearbeitet werden kann.");
                return;
            }

            // update restbetrag if possible
            UpdateSum();

            // get current values
            decimal? betrag = qryKrankenkasse[betragFieldName] as decimal?;
            decimal? zahlung = qryKrankenkasse[zahlungFieldName] as decimal?;
            decimal? restBetrag = edtRestbetrag.EditValue as decimal?;

            // validate values
            if (!betrag.HasValue || !restBetrag.HasValue)
            {
                KissMsg.ShowInfo(this.Name,
                                 "CannotApplyAmountNoValue",
                                 "Die benötigten Felder enthalten keine Werte, der gwünschte Betrag kann nicht übernommen werden.");
                return;
            }

            // apply maximal possible value
            if (restBetrag <= 0m)
            {
                // store 0
                qryKrankenkasse[zahlungFieldName] = 0m;
            }
            else if (betrag > restBetrag && (!zahlung.HasValue || zahlung.Value <= 0m))
            {
                // store restBetrag if not yet an entry
                qryKrankenkasse[zahlungFieldName] = restBetrag;
            }
            else
            {
                // store betrag
                qryKrankenkasse[zahlungFieldName] = betrag;
            }

            // update restbetrag if possible
            UpdateSum();
        }

        private bool InitAuszahlweg(bool createNewEntry)
        {
            return InitAuszahlweg(createNewEntry, -1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="createNewEntry"></param>
        /// <param name="loadBelegID"></param>
        /// <returns></returns>
        /// <remarks>If loadBelegID > 0, the id will be loaded and displayed to edit</remarks>
        private bool InitAuszahlweg(bool createNewEntry, int loadBelegID)
        {
            try
            {
                // end edit of last entry
                if (_isEditingAuszahlwegData)
                {
                    // ensure current data is properly saved
                    if (!qryAuszahlweg.Post())
                    {
                        return false;
                    }
                }

                // no more in Auszahlweg, do reset
                ResetAuszahlweg();

                // check mode
                if (!createNewEntry && loadBelegID > 0)
                {
                    // LOAD:
                    // load specified id and enable edit
                    qryAuszahlweg.Fill(loadBelegID, _splittingArtCode);

                    // validate
                    if (qryAuszahlweg.Count < 1)
                    {
                        // should not be more than one referenced entry, show error
                        throw new KissErrorException(KissMsg.GetMLMessage(this.Name,
                                                                          "NoMatchingCorrespondingEntryFound",
                                                                          "Es wurde kein korrespondierenden Datensatz als Auszahlweg gefunden. Die Anzeige ist möglicherweise nicht korrekt."));
                    }

                    if (qryAuszahlweg.Count > 1)
                    {
                        // should not be more than one referenced entry, show error
                        throw new KissErrorException(KissMsg.GetMLMessage(this.Name,
                                                                          "MultiMatchingCorrespondingEntryFound",
                                                                          "Es wurden mehr als einen korrespondierenden Datensatz als Auszahlweg gefunden. Die Anzeige ist möglicherweise nicht korrekt."));
                    }

                    // apply id to current edit
                    _editBelegID = loadBelegID;

                    // setup flag
                    _isEditingAuszahlwegData = true;

                    // update restbetrag if possible
                    UpdateSum();
                }
                else
                {
                    // NEW:
                    // insert new entry if possible
                    if (createNewEntry && qryAuszahlweg.Count < 1 && qryKrankenkasse.Count > 0)
                    {
                        // insert a new row to allow user insert content
                        qryAuszahlweg.Insert(null);

                        // setup flag
                        _isEditingAuszahlwegData = true;
                    }
                }

                // setup flags
                _isEditingAuszahlwegData = _isEditingAuszahlwegData && qryAuszahlweg.Count > 0;

                // init grid
                grdKrankenkasse.GridStyle = _isEditingAuszahlwegData ? GridStyleType.Editable : GridStyleType.ReadOnly;

                // setup query
                qryAuszahlweg.CanInsert = false;
                qryAuszahlweg.CanUpdate = _isEditingAuszahlwegData;
                qryAuszahlweg.CanDelete = false;

                // update fields to enable/disable depending on state
                qryAuszahlweg.EnableBoundFields(_isEditingAuszahlwegData);
                SetEditModeAuszahlweg();
                InitControlsSplittingArt();
                EnableStatusButtons();

                // set focus
                edtValutaDatum.Focus();

                // if we are here, everything is ok
                return true;
            }
            catch (Exception ex)
            {
                // show error to the user
                KissMsg.ShowError(this.Name,
                                  "ErrorInitAuszahlweg_v01",
                                  "Es ist ein Fehler in der Verarbeitung aufgetreten, die Ansicht wird zurückgesetzt.", ex);

                // do reset because of error
                ResetAuszahlweg();

                // failure
                return false;
            }
        }

        private void InitControlsSplittingArt()
        {
            // setup mode
            bool editable = _isEditingAuszahlwegData;

            // setup controls depending on SplittingArtCode
            switch (_splittingArtCode)
            {
                case 1: // Taggenau
                case 2: // Monat
                    edtVerwPeriodeVon.EditMode = editable ? EditModeType.Required : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = editable ? EditModeType.Required : EditModeType.ReadOnly;
                    break;

                case 4: // Entscheid
                    edtVerwPeriodeVon.EditMode = editable ? EditModeType.Required : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    edtVerwPeriodeVon.EditMode = EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;
            }
        }

        private int InsertAuszahlwegData(
            int bgBudgetID,
            int bgKategorieCode,
            int? bgPositionID_Parent,
            int baPersonID,
            int bgPositionsartID,
            string buchungstext,
            decimal? zahlungBetrag,
            int bgSpezkontoID,
            string bemerkung,
            DateTime? verwPeriodeVon,
            DateTime? verwPeriodeBis,
            DateTime? rechnungDatum,
            int bgBewilligungStatusCode,
            int? erstelltUserID,
            DateTime? erstelltDatum,
            int? mutiertUserID,
            DateTime? mutiertDatum,
            int kbAuszahlungsArtCode,
            int bgAuszahlungsTerminCode,
            int? baZahlungswegID,
            string referenzNummer,
            string mitteilungZeile1,
            string mitteilungZeile2,
            string mitteilungZeile3,
            DateTime? valutaDatum)
        {
            // parentID
            if (bgPositionID_Parent.HasValue && bgPositionID_Parent.Value < 1)
            {
                // do not save any value into database if negative
                bgPositionID_Parent = null;
            }

            // BGPOSITION
            int newBgPositionID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                -- insert values
                INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionID_Parent, BaPersonID, BgPositionsartID, Buchungstext,
                                            Betrag, BgSpezkontoID, Bemerkung, VerwPeriodeVon, VerwPeriodeBis, RechnungDatum, BgBewilligungStatusCode,
                                            ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5},
                        {6}, {7}, {8}, {9}, {10}, {11}, {12},
                        {13}, {14}, {15}, {16});

                -- get used id
                SELECT SCOPE_IDENTITY();", bgBudgetID,
                                           bgKategorieCode,
                                           bgPositionID_Parent,
                                           baPersonID,
                                           bgPositionsartID,
                                           buchungstext,
                                           zahlungBetrag,
                                           bgSpezkontoID,
                                           bemerkung,
                                           verwPeriodeVon,
                                           verwPeriodeBis,
                                           rechnungDatum,
                                           bgBewilligungStatusCode,
                                           erstelltUserID,
                                           erstelltDatum,
                                           mutiertUserID,
                                           mutiertDatum));

            // BGAUSZAHLUNGPERSON
            int newBgAuszahlungPersonID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                -- insert values
                INSERT INTO dbo.BgAuszahlungPerson (BgPositionID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BaZahlungswegID,
                                                    ReferenzNummer, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3)
                VALUES ({0}, {1}, {2}, {3},
                        {4}, {5}, {6}, {7});

                -- get used id
                SELECT SCOPE_IDENTITY();", newBgPositionID,
                                           kbAuszahlungsArtCode,
                                           bgAuszahlungsTerminCode,
                                           baZahlungswegID,
                                           referenzNummer,
                                           mitteilungZeile1,
                                           mitteilungZeile2,
                                           mitteilungZeile3));

            // BGAUSZAHLUNGPERSONTERMIN
            DBUtil.ExecuteScalarSQLThrowingException(@"
                -- insert values
                INSERT INTO dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
                VALUES ({0}, {1});", newBgAuszahlungPersonID, valutaDatum);

            // RETURN
            return newBgPositionID;
        }

        private void InsertIntoKlibuAsFreigegeben(bool isBudgetGreen, int bgBudgetID, int bgPositionID)
        {
            #region Validate

            // budget has to be green
            if (!isBudgetGreen)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotReleaseIfNotGreenBudget",
                                                                 "Es können nur Zahlungen von grünen Budgets freigegeben werden."));
            }

            // get auszahlungsart
            bool isSILAntrag = Convert.ToInt32(qryAuszahlweg["KbAuszahlungsArtCode"]) == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag);

            // "SIL-Antrag" is not supported
            if (isSILAntrag)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotReleaseIfSILAntrag",
                                                                 "Die Auszahlungsart 'SIL-Antrag' kann nicht freigegeben werden."));
            }

            // validate bgBudgetID
            if (bgBudgetID < 1)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "InvalidBgBudgetIDBooking_v01",
                                                                 "Ungültige BgBudgetID, die Freigabe in die Klientenbuchhaltung kann nicht fortgesetzt werden."));
            }

            // validate bgBelegID
            if (bgPositionID < 1)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "InvalidBgBBelegIDBooking_v01",
                                                                 "Ungültige BgBelegID, die Freigabe in die Klientenbuchhaltung kann nicht fortgesetzt werden."));
            }

            #endregion

            #region Insert data into Klibu

            DBUtil.ExecSQLThrowingException(@"
                EXECUTE dbo.spWhBudget_CreateKbBuchung {0}, {1}, 0, NULL, {2}, 0, 0;", bgBudgetID, Session.User.UserID, bgPositionID);

            #endregion

            #region Update status and BelegNr

            // get new belegNr only if default 'auszahlungsart' is not 'Papierverfügung'
            int? newBelegNr = null;
            int? kbBelegKreisId = null;

            if (_ezStandardAuszahlungsart != (int)CtlWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung)
            {
                newBelegNr = ShUtil.GetNewBelegNr(bgBudgetID, bgPositionID, out kbBelegKreisId);
            }

            // update data: budget
            int rowCountPos = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                UPDATE dbo.BgPosition
                SET BgBewilligungStatusCode = 5 -- Bewilligung erteilt
                WHERE BgPositionID = {0}
                   OR BgPositionID_Parent = {0};

                SELECT @@ROWCOUNT;", bgPositionID));

            // validate
            if (rowCountPos < 1)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "ReleaseNoEntryUpdatedPos",
                                                                 "Es wurde keine Position zum Bewilligen gefunden."));
            }

            // update data: klibu, set KbBuchung entries to "Freigegeben"
            int rowCountBuc = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                UPDATE dbo.KbBuchung
                SET BelegNr = {0},
                    KbBelegKreisID = {3},
                    KbBuchungStatusCode = 2,    -- Freigegeben
                    KbAuszahlungsArtCode = {2}  -- only El.Auszahlung||Papierverfuegung
                WHERE BelegNr IS NULL           -- security (do never overwrite an existing BelegNr)
                  AND KbBuchungID IN (SELECT KbBuchungID
                                      FROM dbo.KbBuchungKostenart
                                      WHERE BgPositionID IN (SELECT BgPositionID
                                                             FROM dbo.BgPosition
                                                             WHERE BgPositionID = {1}
                                                                OR BgPositionID_Parent = {1}));

                SELECT @@ROWCOUNT;", newBelegNr, bgPositionID, _ezStandardAuszahlungsart, kbBelegKreisId));

            // validate
            if (rowCountBuc < 1)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "ReleaseNoEntryUpdatedBuc",
                                                                 "Es wurde keine Buchung zum Freigeben gefunden."));
            }

            #endregion
        }

        private new void RefreshData()
        {
            qryFall_PositionChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Release current selected position (Auszahlung freigeben)
        /// </summary>
        private void ReleasePosition()
        {
            #region Validate

            // validate first
            if (!CanReleasePosition() || _editBelegID > 0)
            {
                // handle button
                EnableBtnFreigeben();

                // throw exception
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotReleasePreRequirementsFailure",
                                                                 "Die Zahlungen können nicht freigegeben werden, da nicht alle Daten und Vorbedingungen erfüllt sind."));
            }

            // get current beleg id
            int belegID = Convert.ToInt32(qryKrankenkasse["BelegID"]);

            // validate
            if (belegID < 1)
            {
                // throw exception
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotReleaseInvalidBelegID",
                                                                 "Die Zahlungen können nicht freigegeben werden, da die aktuelle BelegID nicht ermittelt werden konnte."));
            }

            #endregion

            #region Init and set vars

            // init container
            KlibuDataContainer kdc = null;

            try
            {
                // temporary set id to make method working
                _editBelegID = belegID;

                // validate current state and get klibu data container
                kdc = SaveAuszahlweg(false, true, false);
            }
            finally
            {
                // reset id again
                _editBelegID = -1;
            }

            #endregion

            #region ReValidate

            // check container and if valid to release into klibu
            if (kdc == null || !kdc.InsertIntoKlibu)
            {
                // invalid, cannot procceed with inserting
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "SaveAzwInvalidFlagInsertIntoKlibu_v01",
                                                                 "Die Daten können aufgrund eines Fehlers nicht freigegeben werden."));
            }

            // do insert into klibu, validate vars first
            if (kdc.BgBudgetID < 1 || kdc.BgBelegID < 1)
            {
                // invalid, cannot procceed with inserting
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "SaveAzwInvalidBudgetBelegID",
                                                                 "Ungültige BudgetID oder BelegID, die Positionen können nicht freigegeben werden."));
            }

            #endregion

            #region Release

            // init flag
            bool success = false;

            // do it in transaction
            Session.BeginTransaction();

            try
            {
                // Do it
                InsertIntoKlibuAsFreigegeben(kdc.IsBudgetGreen, kdc.BgBudgetID, kdc.BgBelegID);

                // do commit
                Session.Commit();

                // success
                success = true;
            }
            catch (Exception ex)
            {
                // rollback changes
                Session.Rollback();

                // create new message
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "ErrorInReleasePosition",
                                                                 "Es ist ein Fehler beim Grünstellen der Position(en) aufgetreten:\r\n\r\n{0}", ex.Message), ex);
            }
            finally
            {
                // do refresh data on success
                if (success)
                {
                    InitAuszahlweg(false);
                    OnRefreshData();
                }
            }

            #endregion
        }

        /// <summary>
        /// Check if current data in Auszahlweg requires a ReferenzNummer
        /// </summary>
        /// <returns><c>True</c> if ReferenzNummer is required, otherwise <c>False</c></returns>
        private bool RequiresReferenzNummer()
        {
            // get esCode
            int esCode = DBUtil.IsEmpty(qryAuszahlweg["EinzahlungsscheinCode"]) ? -1 : Convert.ToInt32(qryAuszahlweg["EinzahlungsscheinCode"]);

            return RequiresReferenzNummer(esCode);
        }

        private void ResetAuszahlweg()
        {
            // fill empty data to Auszahlweg
            qryAuszahlweg.Fill(-1, _splittingArtCode);

            // disable controls
            btnFreigeben.Enabled = false;
            btnSILAntragBearbeiten.Enabled = false;
            btnElAuszahlungLoeschen.Enabled = false;
            edtRestbetrag.BackColor = GuiConfig.EditColorReadOnly;
            edtRestbetrag.EditValue = null;

            // setup verwPeriode
            InitControlsSplittingArt();

            // reset flags
            _isEditingAuszahlwegData = false;
            _editBelegID = -1;
            _canSaveChanges = false;

            // handle buttons
            EnableStatusButtons();
        }

        /// <summary>
        /// Save changes on Auszahlweg or do preparations for release of positions
        /// </summary>
        /// <param name="silAntrag"><c>True</c> is SIL-Antrag, otherwise <c>False</c></param>
        /// <param name="updateData"><c>True</c> if existing data has to be updated, <c>False</c> if new data has to be inserted</param>
        /// <param name="doSaveChanges">
        ///     <c>True</c> if changes have to be saved to database,
        ///     <c>False</c> if only data validation has to be done (in this case <paramref name="updateData"/> has to be <c>True</c>
        ///     and <paramref name="silAntrag"/> has to be <c>False</c>)
        /// </param>
        /// <returns>if <paramref name="doSaveChanges"/> is <c>False</c>: New instance of klibu container class containing required klibu vars, otherwise <c>null</c></returns>
        private KlibuDataContainer SaveAuszahlweg(bool silAntrag, bool updateData, bool doSaveChanges)
        {
            #region Init

            // validate call
            if (!doSaveChanges && !updateData)
            {
                throw new ArgumentOutOfRangeException("Invalid call: Cannot insert new data if saving changes is deactivated.");
            }

            if (!doSaveChanges && silAntrag)
            {
                throw new ArgumentOutOfRangeException("Invalid call: Cannot have 'SIL-Antrag' if saving changes is deactivated.");
            }

            // init static vars
            int bgKategorieCode = Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen);
            int bgBewilligungStatusCode = Convert.ToInt32(BgBewilligungStatus.Erteilt);
            int bgAuszahlungsTerminCode = 4;    // Valuta

            // validate
            if (DBUtil.IsEmpty(qryAuszahlweg["KbAuszahlungsartCode"]))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "MissingAuszahlungart",
                                                                 "Die Auszahlungsart verlangt eine Eingabe."));
            }

            // init auszahlweg vars
            int kbAuszahlungsArtCode = Convert.ToInt32(qryAuszahlweg["KbAuszahlungsartCode"]);
            DateTime? valutaDatum = ConvertToDateTime(qryAuszahlweg["Valuta"]);
            DateTime? rechnungDatum = ConvertToDateTime(qryAuszahlweg["Rechnungdatum"]);
            int? baZahlungswegID = qryAuszahlweg["BaZahlungswegID"] as int?;
            string referenzNummer = qryAuszahlweg["ReferenzNummer"] as string;
            string mitteilungZeile1 = qryAuszahlweg["MitteilungZeile1"] as string;
            string mitteilungZeile2 = qryAuszahlweg["MitteilungZeile2"] as string;
            string mitteilungZeile3 = qryAuszahlweg["MitteilungZeile3"] as string;
            string buchungstext = qryAuszahlweg["Buchungstext"] as string;
            DateTime? verwPeriodeVon = ConvertToDateTime(qryAuszahlweg["VerwPeriodeVon"]);
            DateTime? verwPeriodeBis = ConvertToDateTime(qryAuszahlweg["VerwPeriodeBis"]);

            // set Einzahlungsschein
            int esCode = DBUtil.IsEmpty(qryAuszahlweg["EinzahlungsscheinCode"]) ? -1 : Convert.ToInt32(qryAuszahlweg["EinzahlungsscheinCode"]);

            // update creator/modifier
            if (doSaveChanges)
            {
                ctlErfassungMutation.SetFields();
            }

            int? erstelltUserID = DBUtil.IsEmpty(ctlErfassungMutation.ActiveSQLQuery["ErstelltUserID"]) ? null : ctlErfassungMutation.ActiveSQLQuery["ErstelltUserID"] as int?;
            DateTime? erstelltDatum = DBUtil.IsEmpty(ctlErfassungMutation.ActiveSQLQuery["ErstelltDatum"]) ? null : ctlErfassungMutation.ActiveSQLQuery["ErstelltDatum"] as DateTime?;
            int? mutiertUserID = DBUtil.IsEmpty(ctlErfassungMutation.ActiveSQLQuery["MutiertUserID"]) ? null : ctlErfassungMutation.ActiveSQLQuery["MutiertUserID"] as int?;
            DateTime? mutiertDatum = DBUtil.IsEmpty(ctlErfassungMutation.ActiveSQLQuery["MutiertDatum"]) ? null : ctlErfassungMutation.ActiveSQLQuery["MutiertDatum"] as DateTime?;

            // init runtime vars
            int firstBgBudgetID = -1;
            int bgBudgetID = -1;
            int baPersonID = -1;
            string bemerkung = null;
            int bgPositionsartID = -1;
            int bgSpezkontoID = -1;
            int? bgPositionID_Parent = null;
            int bgPositionIDKVG = -1;
            int bgPositionIDKVGMax = -1;
            int bgPositionIDVVG = -1;
            int rowBaInstitutionID = -1;

            #endregion

            #region Validate

            // validate must-vars
            if (kbAuszahlungsArtCode != Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung) &&
                kbAuszahlungsArtCode != Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung) &&
                kbAuszahlungsArtCode != Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.SILAntrag))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "SaveAzwInvalidAuszahlungsart", "Ungültiger AuszahlungsartCode."));
            }

            if (!valutaDatum.HasValue || DBUtil.IsEmpty(valutaDatum))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "SaveAzwInvalidValuta", "Ungültiges Valutadatum."));
            }

            if (!verwPeriodeVon.HasValue ||
                !verwPeriodeBis.HasValue ||
                DBUtil.IsEmpty(verwPeriodeVon) ||
                DBUtil.IsEmpty(verwPeriodeBis) ||
                verwPeriodeVon.Value > verwPeriodeBis.Value)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "SaveAzwInvalidVerwPeriode", "Ungültige Verwendungsperiode."));
            }

            // only not SIL-Antrag
            if (!silAntrag)
            {
                if (!baZahlungswegID.HasValue || baZahlungswegID.Value < 1)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "SaveAzwInvalidZahlweg", "Ungültige ZahlungswegID."));
                }

                if (esCode == Convert.ToInt32(BgEinzahlungsschein.ESOrange) && DBUtil.IsEmpty(referenzNummer))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "SaveAzwInvalidRefNr", "Ungültige Referenznummer."));
                }
            }

            #endregion

            #region Position Handling

            // SAVE PREPARATIONS
            int rowBelegID = -1;
            decimal? bgBetragKVG = decimal.Zero;
            decimal? bgBetragKVGMax = decimal.Zero;
            decimal? bgBetragVVG = decimal.Zero;
            decimal? zahlungKVGBetrag = decimal.Zero;
            decimal? zahlungKVGMaxBetrag = decimal.Zero;
            decimal? zahlungVVGBetrag = decimal.Zero;

            bool isBudgetGray = false;
            bool isBudgetGreen = false;

            // klibu vars for Freigabe
            bool klibuDoInsertIntoKlibu = false;
            int klibuBgBudgetID = -1;
            bool klibuIsBudgetGreen = false;
            int klibuBgBelegID = -1;

            // SAVE
            // loop rows
            foreach (DataRow row in qryKrankenkasse.DataTable.Rows)
            {
                #region Setup vars and validate

                // CHECK
                // check if need to process current row
                rowBelegID = DBUtil.IsEmpty(row["BelegID"]) ? -1 : Convert.ToInt32(row["BelegID"]);

                // must be the same id (or even -1 if current is null)
                if (rowBelegID != _editBelegID)
                {
                    // do not handle current row
                    continue;
                }

                // GET VALUES
                // get current values
                bgBudgetID = Convert.ToInt32(row["BgBudgetID"]);
                baPersonID = Convert.ToInt32(row["BaPersonID"]);
                rowBaInstitutionID = DBUtil.IsEmpty(row["BaInstitutionID"]) ? -1 : Convert.ToInt32(row["BaInstitutionID"]);
                bgBetragKVG = row["BetragKVG"] as decimal?;
                bgBetragKVGMax = row["BetragKVGMax"] as decimal?;
                bgBetragVVG = row["BetragVVG"] as decimal?;
                zahlungKVGBetrag = row["ZahlungKVG"] as decimal?;
                zahlungKVGMaxBetrag = row["ZahlungKVGMax"] as decimal?;
                zahlungVVGBetrag = row["ZahlungVVG"] as decimal?;
                bemerkung = row["Bemerkung"] as string;

                // get current budget state
                isBudgetGray = Convert.ToBoolean(row["IsBudgetGray"]);
                isBudgetGreen = Convert.ToBoolean(row["IsBudgetGreen"]);

                // apply first bgbudgetid and klibu vars if budgetid with zahlungen
                if (firstBgBudgetID < 1 &&
                    ((zahlungKVGBetrag.HasValue && zahlungKVGBetrag.Value > 0m) ||
                     (zahlungKVGMaxBetrag.HasValue && zahlungKVGMaxBetrag.Value > 0m) ||
                     (zahlungVVGBetrag.HasValue && zahlungVVGBetrag.Value > 0m)))
                {
                    // apply first bgbudgetid to ensure we handle only one budget for beleg
                    firstBgBudgetID = bgBudgetID;

                    // apply klibu vars
                    klibuBgBudgetID = bgBudgetID;
                    klibuIsBudgetGreen = isBudgetGreen;
                }

                // VALIDATE
                // validate ids
                if (bgBudgetID < 1 || baPersonID < 1)
                {
                    // invalid ids
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidReferenzID",
                                                                     "Ungültige Referenz-IDs, die Daten können nicht gespeichert werden."));
                }

                // can only handle one budget at once
                if (firstBgBudgetID > 0 &&
                    firstBgBudgetID != bgBudgetID &&
                    ((zahlungKVGBetrag.HasValue && zahlungKVGBetrag.Value > 0m) ||
                     (zahlungKVGMaxBetrag.HasValue && zahlungKVGMaxBetrag.Value > 0m) ||
                     (zahlungVVGBetrag.HasValue && zahlungVVGBetrag.Value > 0m)))
                {
                    // more than one budget handled, cannot proceed
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidDataForBudgets",
                                                                     "Die Daten können nicht verarbeitet werden. Zahlungen für einen Beleg können nur innerhalb eines Budgets erfasst werden (erstes Budget='{0}', aktuelles Budget='{1}').",
                                                                     firstBgBudgetID,
                                                                     bgBudgetID));
                }

                // check budget state (only gray and green budgets can be handled)
                if ((!isBudgetGray && !isBudgetGreen) || (isBudgetGray && isBudgetGreen))
                {
                    // invalid state, cannot continue
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidBudgetStatus",
                                                                     "Ungültige Budgetstatus, es können nur graue und grüne Budgets verarbeitet werden."));
                }

                // check budget state for entries with values (gray budget can only have SIL-Antrag, green budget can have both)
                if (isBudgetGray &&
                    !silAntrag &&
                    ((zahlungKVGBetrag.HasValue && zahlungKVGBetrag.Value > 0m) ||
                     (zahlungKVGMaxBetrag.HasValue && zahlungKVGMaxBetrag.Value > 0m) ||
                     (zahlungVVGBetrag.HasValue && zahlungVVGBetrag.Value > 0m)))
                {
                    // invalid state, cannot within gray budget create El.Auszahlung
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidAuszahlartGrauBudget",
                                                                     "Die gewählte Auszahlungsart kann nicht mit grauen Budgets verwendet werden."));
                }

                // check values betragkvg and zahlungkvg
                if (!bgBetragKVG.HasValue &&
                    zahlungKVGBetrag.HasValue &&
                    zahlungKVGBetrag.Value > 0m)
                {
                    // invalid state, cannot enter a value in zahlungkvg, if no kvg given
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidZahlungKVGNoBudget",
                                                                     "Es kann keine Zahlung für KVG gemacht werden, wenn kein Wert im Budget vorhanden ist."));
                }

                // check values betragkvgmax and zahlungkvgmax
                if (!bgBetragKVGMax.HasValue &&
                    zahlungKVGMaxBetrag.HasValue &&
                    zahlungKVGMaxBetrag.Value > 0m)
                {
                    // invalid state, cannot enter a value in zahlungkvg, if no kvg given
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidZahlungKVGMaxNoBudget",
                                                                     "Es kann keine Zahlung für KVG-Max gemacht werden, wenn kein Wert im Budget vorhanden ist."));
                }

                // check values betragvvg and zahlungvvg
                if (!bgBetragVVG.HasValue &&
                    zahlungVVGBetrag.HasValue &&
                    zahlungVVGBetrag.Value > 0m)
                {
                    // invalid state, cannot enter a value in zahlungkvg, if no vvg given
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidZahlungVVGNoBudget",
                                                                     "Es kann keine Zahlung für VVG gemacht werden, wenn kein Wert im Budget vorhanden ist."));
                }

                // get month-duration as decimal, used to compare max-values
                decimal month = Convert.ToDecimal((edtVerwPeriodeBis.DateTime.Month - edtVerwPeriodeVon.DateTime.Month) +
                                                  (12 * (edtVerwPeriodeBis.DateTime.Year - edtVerwPeriodeVon.DateTime.Year)) +
                                                  (edtVerwPeriodeBis.DateTime.Day > edtVerwPeriodeVon.DateTime.Day ? 1 : 0));

                // check values, zahlungvvg cannot > betragvvg
                if (bgBetragVVG.HasValue &&
                    zahlungVVGBetrag.HasValue &&
                    (bgBetragVVG.Value * month) < zahlungVVGBetrag.Value)
                {
                    // invalid state, cannot enter a value for zahlungvvg > betragvvg
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidZahlungVVGOverBudget",
                                                                     "Ungültige Zahlung für VVG, der vorhandene VVG-Betrag im Budget darf nicht überschritten werden."));
                }

                // krankenkasse has to be set
                if (rowBaInstitutionID < 1)
                {
                    // check if need to stop here
                    switch (CtlBatchKVG.VALIDATIONGRADE)
                    {
                        case 0:
                            // >> does not matter (silent)
                            break;
                    }
                }

                // skos (it is not really SKOS but defined in KiSS as if it would be)
                if (_maxKVGPerPerson < 0m || _maxVVGPerPerson < 0m ||
                    (zahlungKVGBetrag.HasValue && zahlungKVGMaxBetrag.HasValue && ((zahlungKVGBetrag.Value + zahlungKVGMaxBetrag.Value) > (_maxKVGPerPerson * month))) ||   // KVG+KVGMax
                    (zahlungKVGBetrag.HasValue && !zahlungKVGMaxBetrag.HasValue && (zahlungKVGBetrag.Value > (_maxKVGPerPerson * month))) ||                                // only KVG
                    (!zahlungKVGBetrag.HasValue && zahlungKVGMaxBetrag.HasValue && (zahlungKVGMaxBetrag.Value > (_maxKVGPerPerson * month))) ||                             // only KVGMax
                    (zahlungVVGBetrag.HasValue && zahlungVVGBetrag.Value > (_maxVVGPerPerson * month)))                                                                     // VVG
                {
                    // invalid value, cannot continue
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "SaveAzwInvalidZahlungRichtlinienProblem",
                                                                     "Die Zahlungen für KVG und/oder VVG erfüllen die definierten Richtlinien nicht.\r\nBitte überprüfen Sie die Beträge und Verwendungsperiode."));
                }

                // check if SIL-Antrag
                if (!silAntrag)
                {
                    // the ids of the zahlungsweg should be the same to prevent incorrect data
                    if (!baZahlungswegID.HasValue || baZahlungswegID.Value != rowBaInstitutionID)
                    {
                        // check if need to stop here
                        switch (CtlBatchKVG.VALIDATIONGRADE)
                        {
                            case 0:
                                // >> does not matter (silent)
                                break;
                        }
                    }
                }

                #endregion

                // MODE (INSERT/UPDATE)
                // --------------------------------------------------------------------
                // check mode
                if (!updateData)
                {
                    #region Validate

                    // validate
                    if (!doSaveChanges)
                    {
                        throw new ArgumentOutOfRangeException("Invalid call: Cannot insert new data if saving changes is deactivated.");
                    }

                    #endregion

                    #region KVG

                    // ----------------------------------------------------------------
                    // KVG:
                    // ----------------------------------------------------------------
                    // handle kvg value
                    if (zahlungKVGBetrag.HasValue)
                    {
                        // must be positive
                        if (zahlungKVGBetrag.Value < 0m)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                             "SaveAzwInvalidKVGValuePositive",
                                                                             "Ungültiger KVG-Wert, die Zahlungen müssen einen positiven Betrag aufweisen."));
                        }

                        // check if > 0m
                        if (zahlungKVGBetrag.Value != 0m)
                        {
                            // get bgpositionsartid and bgspezkontoid for kvg (if no value, error occures -> ok, we need a value)
                            bgPositionsartID = Convert.ToInt32(row["BgPositionsartIDKVG"]);
                            bgSpezkontoID = Convert.ToInt32(row["BgSpezkontoIDKVG"]);

                            // --------------------------------------------------------
                            // KVG: POSITIVE VALUE AND >0, SAVE TO DATABASE
                            // --------------------------------------------------------
                            int newBgPositionID = this.InsertAuszahlwegData(bgBudgetID, bgKategorieCode, bgPositionID_Parent, baPersonID, bgPositionsartID, buchungstext,
                                                                            zahlungKVGBetrag, bgSpezkontoID, bemerkung, verwPeriodeVon, verwPeriodeBis,
                                                                            rechnungDatum, bgBewilligungStatusCode, erstelltUserID, erstelltDatum,
                                                                            mutiertUserID, mutiertDatum, kbAuszahlungsArtCode, bgAuszahlungsTerminCode,
                                                                            baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3,
                                                                            valutaDatum);

                            // check if we alreday have a parentid
                            if (!bgPositionID_Parent.HasValue || bgPositionID_Parent.Value < 1)
                            {
                                // apply inserted value to connect BgPositionIDs with each other
                                bgPositionID_Parent = newBgPositionID;

                                // apply for klibu as belegID
                                klibuBgBelegID = newBgPositionID;
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                    } // [kvg]

                    #endregion

                    #region KVGMax

                    // ----------------------------------------------------------------
                    // KVG-MAX:
                    // ----------------------------------------------------------------
                    // handle kvg-max value
                    if (zahlungKVGMaxBetrag.HasValue)
                    {
                        // must be positive
                        if (zahlungKVGMaxBetrag.Value < 0m)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                             "SaveAzwInvalidKVGMaxValuePositive",
                                                                             "Ungültiger KVG-Max-Wert, die Zahlungen müssen einen positiven Betrag aufweisen."));
                        }

                        // check if > 0m
                        if (zahlungKVGMaxBetrag.Value != 0m)
                        {
                            // get bgpositionsartid and bgspezkontoid for kvg-max (if no value, error occures -> ok, we need a value)
                            bgPositionsartID = Convert.ToInt32(row["BgPositionsartIDKVGMax"]);
                            bgSpezkontoID = Convert.ToInt32(row["BgSpezkontoIDKVGMax"]);

                            // --------------------------------------------------------
                            // KVG-MAX: POSITIVE VALUE AND >0, SAVE TO DATABASE
                            // --------------------------------------------------------
                            int newBgPositionID = this.InsertAuszahlwegData(bgBudgetID, bgKategorieCode, bgPositionID_Parent, baPersonID, bgPositionsartID, buchungstext,
                                                                            zahlungKVGMaxBetrag, bgSpezkontoID, bemerkung, verwPeriodeVon, verwPeriodeBis,
                                                                            rechnungDatum, bgBewilligungStatusCode, erstelltUserID, erstelltDatum,
                                                                            mutiertUserID, mutiertDatum, kbAuszahlungsArtCode, bgAuszahlungsTerminCode,
                                                                            baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3,
                                                                            valutaDatum);

                            // check if we alreday have a parentid
                            if (!bgPositionID_Parent.HasValue || bgPositionID_Parent.Value < 1)
                            {
                                // apply inserted value to connect BgPositionIDs with each other
                                bgPositionID_Parent = newBgPositionID;

                                // apply for klibu as belegID
                                klibuBgBelegID = newBgPositionID;
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                    } // [kvg-max]

                    #endregion

                    #region VVG

                    // ----------------------------------------------------------------
                    // VVG:
                    // ----------------------------------------------------------------
                    // handle vvg value
                    if (zahlungVVGBetrag.HasValue)
                    {
                        // must be positive
                        if (zahlungVVGBetrag.Value < 0m)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                             "SaveAzwInvalidVVGValuePositive",
                                                                             "Ungültiger VVG-Wert, die Zahlungen müssen einen positiven Betrag aufweisen."));
                        }

                        // check if > 0m
                        if (zahlungVVGBetrag.Value != 0m)
                        {
                            // get bgpositionsartid and bgspezkontoid for kvg (if no value, error occures -> ok, we need a value)
                            bgPositionsartID = Convert.ToInt32(row["BgPositionsartIDVVG"]);
                            bgSpezkontoID = Convert.ToInt32(row["BgSpezkontoIDVVG"]);

                            // --------------------------------------------------------
                            // VVG: POSITIVE VALUE AND >0, SAVE TO DATABASE
                            // --------------------------------------------------------
                            int newBgPositionID = this.InsertAuszahlwegData(bgBudgetID, bgKategorieCode, bgPositionID_Parent, baPersonID, bgPositionsartID, buchungstext,
                                                                            zahlungVVGBetrag, bgSpezkontoID, bemerkung, verwPeriodeVon, verwPeriodeBis,
                                                                            rechnungDatum, bgBewilligungStatusCode, erstelltUserID, erstelltDatum,
                                                                            mutiertUserID, mutiertDatum, kbAuszahlungsArtCode, bgAuszahlungsTerminCode,
                                                                            baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3,
                                                                            valutaDatum);

                            // check if we alreday have a parentid
                            if (!bgPositionID_Parent.HasValue || bgPositionID_Parent.Value < 1)
                            {
                                // apply inserted value to connect BgPositionIDs with each other
                                bgPositionID_Parent = newBgPositionID;

                                // apply for klibu as belegID
                                klibuBgBelegID = newBgPositionID;
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                    } // [vvg]

                    #endregion
                }
                // --------------------------------------------------------------------
                else // UPDATE/DO NOT SAVE CHANGES
                // --------------------------------------------------------------------
                {
                    #region Validate and Vars

                    // update requires valid belegid
                    if (rowBelegID < 1)
                    {
                        // invalid id, cannot continue
                        throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                         "SaveAzwInvalidRowBelegID",
                                                                         "Ungültige BelegID, die Daten können nicht verändert werden."));
                    }

                    // apply belegid to klibu values
                    if (klibuBgBelegID < 0)
                    {
                        // apply for klibu as belegID
                        klibuBgBelegID = rowBelegID;
                    }

                    // get ids
                    bgPositionIDKVG = DBUtil.IsEmpty(row["BgPositionIDKVG"]) ? -1 : Convert.ToInt32(row["BgPositionIDKVG"]);
                    bgPositionIDKVGMax = DBUtil.IsEmpty(row["BgPositionIDKVGMax"]) ? -1 : Convert.ToInt32(row["BgPositionIDKVGMax"]);
                    bgPositionIDVVG = DBUtil.IsEmpty(row["BgPositionIDVVG"]) ? -1 : Convert.ToInt32(row["BgPositionIDVVG"]);

                    #endregion

                    #region KVG

                    // ----------------------------------------------------------------
                    // KVG:
                    // ----------------------------------------------------------------
                    // handle kvg value
                    if (!zahlungKVGBetrag.HasValue || zahlungKVGBetrag.Value == 0m)
                    {
                        // check if we have an id (no id = never was a value, has id = delete entry)
                        if (bgPositionIDKVG > -1)
                        {
                            if (doSaveChanges)
                            {
                                // DELETE KVG-ID
                                DeleteAuszahlwegData(bgPositionIDKVG, bgBudgetID, baPersonID);
                            }
                        }
                    }
                    else
                    {
                        // must be positive
                        if (zahlungKVGBetrag.Value < 0m)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                             "SaveAzwInvalidKVGValuePositive",
                                                                             "Ungültiger KVG-Wert, die Zahlungen müssen einen positiven Betrag aufweisen."));
                        }

                        // get bgpositionsartid and bgspezkontoid for kvg (if no value, error occures -> ok, we need a value)
                        bgPositionsartID = Convert.ToInt32(row["BgPositionsartIDKVG"]);
                        bgSpezkontoID = Convert.ToInt32(row["BgSpezkontoIDKVG"]);

                        // ------------------------------------------------------------------
                        // KVG: POSITIVE VALUE AND >0, UPDATE DATABASE
                        // ------------------------------------------------------------------
                        // check if we have an id or a new entry
                        if (bgPositionIDKVG < 1)
                        {
                            if (doSaveChanges)
                            {
                                // new entry, insert new value
                                InsertAuszahlwegData(bgBudgetID, bgKategorieCode, rowBelegID, baPersonID, bgPositionsartID, buchungstext,
                                                     zahlungKVGBetrag, bgSpezkontoID, bemerkung, verwPeriodeVon, verwPeriodeBis,
                                                     rechnungDatum, bgBewilligungStatusCode, erstelltUserID, erstelltDatum,
                                                     mutiertUserID, mutiertDatum, kbAuszahlungsArtCode, bgAuszahlungsTerminCode,
                                                     baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3,
                                                     valutaDatum);
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                        else
                        {
                            if (doSaveChanges)
                            {
                                // update existing value
                                UpdateAuszahlwegData(bgPositionIDKVG, bgKategorieCode, bgPositionsartID, buchungstext, zahlungKVGBetrag, bgSpezkontoID,
                                                     bemerkung, verwPeriodeVon, verwPeriodeBis, rechnungDatum, bgBewilligungStatusCode,
                                                     erstelltUserID, erstelltDatum, mutiertUserID, mutiertDatum, kbAuszahlungsArtCode,
                                                     bgAuszahlungsTerminCode, baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2,
                                                     mitteilungZeile3, valutaDatum);
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                    } // [kvg]

                    #endregion

                    #region KVGMax

                    // ----------------------------------------------------------------
                    // KVG-MAX:
                    // ----------------------------------------------------------------
                    // handle kvg-max value
                    if (!zahlungKVGMaxBetrag.HasValue || zahlungKVGMaxBetrag.Value == 0m)
                    {
                        // check if we have an id (no id = never was a value, has id = delete entry)
                        if (bgPositionIDKVGMax > -1)
                        {
                            if (doSaveChanges)
                            {
                                // DELETE KVG-MAX-ID
                                DeleteAuszahlwegData(bgPositionIDKVGMax, bgBudgetID, baPersonID);
                            }
                        }
                    }
                    else
                    {
                        // must be positive
                        if (zahlungKVGMaxBetrag.Value < 0m)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                             "SaveAzwInvalidKVGMaxValuePositive",
                                                                             "Ungültiger KVG-Max-Wert, die Zahlungen müssen einen positiven Betrag aufweisen."));
                        }

                        // get bgpositionsartid and bgspezkontoid for kvg-max (if no value, error occures -> ok, we need a value)
                        bgPositionsartID = Convert.ToInt32(row["BgPositionsartIDKVGMax"]);
                        bgSpezkontoID = Convert.ToInt32(row["BgSpezkontoIDKVGMax"]);

                        // ------------------------------------------------------------------
                        // KVG-MAX: POSITIVE VALUE AND >0, UPDATE DATABASE
                        // ------------------------------------------------------------------
                        // check if we have an id or a new entry
                        if (bgPositionIDKVGMax < 1)
                        {
                            if (doSaveChanges)
                            {
                                // new entry, insert new value
                                InsertAuszahlwegData(bgBudgetID, bgKategorieCode, rowBelegID, baPersonID, bgPositionsartID, buchungstext,
                                                     zahlungKVGMaxBetrag, bgSpezkontoID, bemerkung, verwPeriodeVon, verwPeriodeBis,
                                                     rechnungDatum, bgBewilligungStatusCode, erstelltUserID, erstelltDatum,
                                                     mutiertUserID, mutiertDatum, kbAuszahlungsArtCode, bgAuszahlungsTerminCode,
                                                     baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3,
                                                     valutaDatum);
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                        else
                        {
                            if (doSaveChanges)
                            {
                                // update existing value
                                UpdateAuszahlwegData(bgPositionIDKVGMax, bgKategorieCode, bgPositionsartID, buchungstext, zahlungKVGMaxBetrag, bgSpezkontoID,
                                                     bemerkung, verwPeriodeVon, verwPeriodeBis, rechnungDatum, bgBewilligungStatusCode,
                                                     erstelltUserID, erstelltDatum, mutiertUserID, mutiertDatum, kbAuszahlungsArtCode,
                                                     bgAuszahlungsTerminCode, baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2,
                                                     mitteilungZeile3, valutaDatum);
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                    } // [kvg-max]

                    #endregion

                    #region VVG

                    // ----------------------------------------------------------------
                    // VVG:
                    // ----------------------------------------------------------------
                    // handle vvg value
                    if (!zahlungVVGBetrag.HasValue || zahlungVVGBetrag.Value == 0m)
                    {
                        // check if we have an id (no id = never was a value, has id = delete entry)
                        if (bgPositionIDVVG > -1)
                        {
                            if (doSaveChanges)
                            {
                                // DELETE VVG-ID
                                DeleteAuszahlwegData(bgPositionIDVVG, bgBudgetID, baPersonID);
                            }
                        }
                    }
                    else
                    {
                        // must be positive
                        if (zahlungVVGBetrag.Value < 0m)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                             "SaveAzwInvalidVVGValuePositive",
                                                                             "Ungültiger VVG-Wert, die Zahlungen müssen einen positiven Betrag aufweisen."));
                        }

                        // get bgpositionsartid and bgspezkontoid for kvg (if no value, error occures -> ok, we need a value)
                        bgPositionsartID = Convert.ToInt32(row["BgPositionsartIDVVG"]);
                        bgSpezkontoID = Convert.ToInt32(row["BgSpezkontoIDVVG"]);

                        // ------------------------------------------------------------------
                        // VVG: POSITIVE VALUE AND >0, UPDATE DATABASE
                        // ------------------------------------------------------------------
                        // check if we have an id or a new entry
                        if (bgPositionIDVVG < 1)
                        {
                            if (doSaveChanges)
                            {
                                // new entry, insert new value
                                InsertAuszahlwegData(bgBudgetID, bgKategorieCode, rowBelegID, baPersonID, bgPositionsartID, buchungstext,
                                                     zahlungVVGBetrag, bgSpezkontoID, bemerkung, verwPeriodeVon, verwPeriodeBis,
                                                     rechnungDatum, bgBewilligungStatusCode, erstelltUserID, erstelltDatum,
                                                     mutiertUserID, mutiertDatum, kbAuszahlungsArtCode, bgAuszahlungsTerminCode,
                                                     baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3,
                                                     valutaDatum);
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                        else
                        {
                            if (doSaveChanges)
                            {
                                // update existing value
                                UpdateAuszahlwegData(bgPositionIDVVG, bgKategorieCode, bgPositionsartID, buchungstext, zahlungVVGBetrag, bgSpezkontoID,
                                                     bemerkung, verwPeriodeVon, verwPeriodeBis, rechnungDatum, bgBewilligungStatusCode,
                                                     erstelltUserID, erstelltDatum, mutiertUserID, mutiertDatum, kbAuszahlungsArtCode,
                                                     bgAuszahlungsTerminCode, baZahlungswegID, referenzNummer, mitteilungZeile1, mitteilungZeile2,
                                                     mitteilungZeile3, valutaDatum);
                            }

                            // VERBUCHT: into klibu if possible
                            klibuDoInsertIntoKlibu = true;
                        }
                    } // [vvg]

                    #endregion
                } // [if(!updatedata)]
                // ------------------------------------------------------------------
            } // [foreach]

            #endregion

            #region Return

            if (!doSaveChanges)
            {
                // create and return new container instance
                return new KlibuDataContainer(klibuDoInsertIntoKlibu, klibuIsBudgetGreen, klibuBgBelegID, klibuBgBudgetID);
            }

            return null;

            #endregion
        }

        private void SetEditModeAuszahlweg()
        {
            // depending on editvalue, fields can be modified or not
            if (!qryAuszahlweg.CanUpdate || DBUtil.IsEmpty(edtAuszahlungsart.EditValue))
            {
                // do nothing, exepect case is already handled
                return;
            }

            int kbAuszahlungsartCode = ShUtil.GetCode(edtAuszahlungsart.EditValue);

            // some fields can only be accessed if "El.Zahlung", get current selection
            bool isElAuszPapVerf = ((kbAuszahlungsartCode == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung)) ||
                                    (kbAuszahlungsartCode == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung)));

            // set type
            EditModeType modeElPapZahlung = isElAuszPapVerf ? EditModeType.Normal : EditModeType.ReadOnly;
            EditModeType modeElPapZahlungReq = isElAuszPapVerf ? EditModeType.Required : EditModeType.ReadOnly;

            // set Einzahlungsschein
            int esCode = DBUtil.IsEmpty(qryAuszahlweg["EinzahlungsscheinCode"]) ? -1 : Convert.ToInt32(qryAuszahlweg["EinzahlungsscheinCode"]);

            // setup fields depending on Einzahlungsschein and Auszahlungsart
            edtKreditor.EditMode = modeElPapZahlungReq;

            edtReferenzNummer.EditMode = RequiresReferenzNummer(esCode) ? modeElPapZahlung : EditModeType.ReadOnly;
            edtMitteilungZeile1.EditMode = esCode == Convert.ToInt32(BgEinzahlungsschein.ESRotPost) ||
                                           esCode == Convert.ToInt32(BgEinzahlungsschein.BankzahlungCH) ||
                                           esCode == Convert.ToInt32(BgEinzahlungsschein.ESRotBank) ? modeElPapZahlung : EditModeType.ReadOnly;
            edtMitteilungZeile2.EditMode = edtMitteilungZeile1.EditMode;
            edtMitteilungZeile3.EditMode = edtMitteilungZeile1.EditMode;

            // reset fields if not allowed to edit
            if (!isElAuszPapVerf)
            {
                // SIL-Antrag, reset all values
                edtKreditor.EditValue = null;
                edtZusatzInfo.EditValue = null;
                edtReferenzNummer.EditValue = null;
                edtMitteilungZeile1.EditValue = null;
                edtMitteilungZeile2.EditValue = null;
                edtMitteilungZeile3.EditValue = null;
            }
            else
            {
                // reset fields depending on enabled mode
                if (edtReferenzNummer.EditMode == EditModeType.ReadOnly)
                {
                    edtReferenzNummer.EditValue = null;
                }

                if (edtMitteilungZeile1.EditMode == EditModeType.ReadOnly)
                {
                    edtMitteilungZeile1.EditValue = null;
                    edtMitteilungZeile2.EditValue = null;
                    edtMitteilungZeile3.EditValue = null;
                }
            }
        }

        private void SetVerwendungsPeriode()
        {
            try
            {
                // check if valid
                if (qryKrankenkasse.Count < 1 || DBUtil.IsEmpty(qryKrankenkasse["Jahr"]) || DBUtil.IsEmpty(qryKrankenkasse["Monat"]))
                {
                    // invalid values, do nothing
                    return;
                }

                int bgBudgetID = Utils.ConvertToInt(qryKrankenkasse["BgBudgetID"]);

                // setup default VerwPeriode
                switch (_splittingArtCode)
                {
                    case 1: // Taggenau
                    case 2: // Monat
                        DateTime firstDate = new DateTime(Convert.ToInt32(qryKrankenkasse["Jahr"]), Convert.ToInt32(qryKrankenkasse["Monat"]), 1);

                        qryAuszahlweg["VerwPeriodeVon"] = firstDate;
                        qryAuszahlweg["VerwPeriodeBis"] = firstDate.AddMonths(1).AddDays(-1);
                        break;

                    case 3: // Valuta
                    case 4: // Entscheid
                        qryAuszahlweg["VerwPeriodeVon"] = DBNull.Value;
                        qryAuszahlweg["VerwPeriodeBis"] = DBNull.Value;
                        break;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorSetVerwPeriode", "Fehler in der Verarbeitung der Verwendungsperiode.", ex);
            }
        }

        /// <summary>
        /// Setup controls for multilanguage handling
        /// </summary>
        private void SetupControlsML()
        {
            // setup buttons texts (no text allowed)
            btnFreigeben.Text = "";
            btnSILAntragBearbeiten.Text = "";
            btnElAuszahlungLoeschen.Text = "";

            // setup button icons
            btnFreigeben.Image = KissImageList.GetSmallImage("BuchungStatus_2_freigegeben");

            // Tooltips setzen
            ttpControls = new System.Windows.Forms.ToolTip();
            ttpControls.SetToolTip(btnFreigeben, KissMsg.GetMLMessage(this.Name, "TtpBtnFreigeben", "Freigeben"));
            ttpControls.SetToolTip(btnSILAntragBearbeiten, KissMsg.GetMLMessage(this.Name, "TtpBtnSILAntragBearbeiten", "SIL-Antrag bearbeiten"));

            if (_ezStandardAuszahlungsart == (int)CtlWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung)
            {
                ttpControls.SetToolTip(btnElAuszahlungLoeschen, KissMsg.GetMLMessage(this.Name, "TtpBtnElAuszLoeschen", "El. Auszahlung löschen"));
            }
            else
            {
                ttpControls.SetToolTip(btnElAuszahlungLoeschen, KissMsg.GetMLMessage(this.Name, "TtpBtnPapVerfLoeschen", "Papierverfügung löschen"));
            }
        }

        private void UpdateAuszahlwegData(
            int bgPositionID,
            int bgKategorieCode,
            int bgPositionsartID,
            string buchungstext,
            decimal? zahlungBetrag,
            int bgSpezkontoID,
            string bemerkung,
            DateTime? verwPeriodeVon,
            DateTime? verwPeriodeBis,
            DateTime? rechnungDatum,
            int bgBewilligungStatusCode,
            int? erstelltUserID,
            DateTime? erstelltDatum,
            int? mutiertUserID,
            DateTime? mutiertDatum,
            int kbAuszahlungsArtCode,
            int bgAuszahlungsTerminCode,
            int? baZahlungswegID,
            string referenzNummer,
            string mitteilungZeile1,
            string mitteilungZeile2,
            string mitteilungZeile3,
            DateTime? valutaDatum)
        {
            // BGPOSITION
            DBUtil.ExecSQLThrowingException(@"
                -- update values
                UPDATE dbo.BgPosition
                SET BgKategorieCode         = {1},
                    BgPositionsartID        = {2},
                    Buchungstext            = {3},
                    Betrag                  = {4},
                    BgSpezkontoID           = {5},
                    Bemerkung               = {6},
                    VerwPeriodeVon          = {7},
                    VerwPeriodeBis          = {8},
                    RechnungDatum           = {9},
                    BgBewilligungStatusCode = {10},
                    ErstelltUserID          = {11},
                    ErstelltDatum           = {12},
                    MutiertUserID           = {13},
                    MutiertDatum            = {14}
                WHERE BgPositionID = {0};", bgPositionID,
                                            bgKategorieCode,
                                            bgPositionsartID,
                                            buchungstext,
                                            zahlungBetrag,
                                            bgSpezkontoID,
                                            bemerkung,
                                            verwPeriodeVon,
                                            verwPeriodeBis,
                                            rechnungDatum,
                                            bgBewilligungStatusCode,
                                            erstelltUserID,
                                            erstelltDatum,
                                            mutiertUserID,
                                            mutiertDatum);

            // BGAUSZAHLUNGPERSON
            DBUtil.ExecSQLThrowingException(@"
                -- update values
                UPDATE dbo.BgAuszahlungPerson
                SET KbAuszahlungsArtCode    = {1},
                    BgAuszahlungsTerminCode = {2},
                    BaZahlungswegID         = {3},
                    ReferenzNummer          = {4},
                    MitteilungZeile1        = {5},
                    MitteilungZeile2        = {6},
                    MitteilungZeile3        = {7}
                WHERE BgPositionID = {0};", bgPositionID,
                                            kbAuszahlungsArtCode,
                                            bgAuszahlungsTerminCode,
                                            baZahlungswegID,
                                            referenzNummer,
                                            mitteilungZeile1,
                                            mitteilungZeile2,
                                            mitteilungZeile3);

            // BGAUSZAHLUNGPERSONTERMIN
            DBUtil.ExecSQLThrowingException(@"
                -- update values
                UPDATE dbo.BgAuszahlungPersonTermin
                SET Datum = {1}
                WHERE BgAuszahlungPersonID IN (SELECT BgAuszahlungPersonID
                                               FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                                               WHERE BgPositionID = {0});", bgPositionID, valutaDatum);
        }

        private void UpdateSum()
        {
            // check if need to process
            if (!_isEditingAuszahlwegData)
            {
                // currently not processing anything, reset controls
                edtRestbetrag.BackColor = GuiConfig.EditColorReadOnly;
                edtRestbetrag.EditValue = DBUtil.IsEmpty(edtTotalbetrag.EditValue) ? null : (object)0.0;    // show nothing if no total, else 0.0 value

                // reset flags
                _canSaveChanges = false;

                // do not continue
                return;
            }

            // end current edits (both queries)
            qryKrankenkasse.EndCurrentEdit(true);
            qryAuszahlweg.EndCurrentEdit(true);

            // INIT:
            // init vars
            int rowBelegID = -1;
            decimal summe = decimal.Zero;
            decimal? zahlungKVGBetrag = decimal.Zero;
            decimal? zahlungKVGMaxBetrag = decimal.Zero;
            decimal? zahlungVVGBetrag = decimal.Zero;

            // SUM:
            // loop rows
            foreach (DataRow row in qryKrankenkasse.DataTable.Rows)
            {
                // check if need to process current row
                rowBelegID = DBUtil.IsEmpty(row["BelegID"]) ? -1 : Convert.ToInt32(row["BelegID"]);

                // must be the same id (or even -1 if current is null)
                if (rowBelegID != this._editBelegID)
                {
                    // do not handle current row
                    continue;
                }

                // get current values
                zahlungKVGBetrag = row["ZahlungKVG"] as decimal?;
                zahlungKVGMaxBetrag = row["ZahlungKVGMax"] as decimal?;
                zahlungVVGBetrag = row["ZahlungVVG"] as decimal?;

                // handle kvg value
                if (zahlungKVGBetrag.HasValue)
                {
                    // must be positive
                    if (zahlungKVGBetrag.Value < 0m)
                    {
                        row["ZahlungKVG"] = 0m;
                        zahlungKVGBetrag = 0m;
                    }

                    // sum up
                    summe += zahlungKVGBetrag.Value;
                }

                // handle kvg-max value
                if (zahlungKVGMaxBetrag.HasValue)
                {
                    // must be positive
                    if (zahlungKVGMaxBetrag.Value < 0m)
                    {
                        row["ZahlungKVGMax"] = 0m;
                        zahlungKVGMaxBetrag = 0m;
                    }

                    // sum up
                    summe += zahlungKVGMaxBetrag.Value;
                }

                // handle vvg value
                if (zahlungVVGBetrag.HasValue)
                {
                    // must be positive
                    if (zahlungVVGBetrag.Value < 0m)
                    {
                        row["ZahlungKVG"] = 0m;
                        zahlungVVGBetrag = 0m;
                    }

                    // sum up
                    summe += zahlungVVGBetrag.Value;
                }
            }

            // DIV
            // compare with total amount
            decimal? totalBetrag = qryAuszahlweg["Totalbetrag"] as decimal?;

            // validate
            if (!totalBetrag.HasValue)
            {
                totalBetrag = 0m;
            }

            // apply value
            edtRestbetrag.EditValue = totalBetrag - summe;

            // update controls depending on current sate
            if (totalBetrag == summe)
            {
                // green
                edtRestbetrag.BackColor = GuiConfig.AmountDifferenceCorrect;

                // set flag
                _canSaveChanges = true;
            }
            else
            {
                // red
                edtRestbetrag.BackColor = GuiConfig.AmountDifferenceIncorrect;

                // set flag
                _canSaveChanges = false;
            }
        }

        #endregion

        #endregion

        #region Nested Types

        /// <summary>
        /// Class, used as container for storing linked klibu data
        /// </summary>
        private class KlibuDataContainer
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="KlibuDataContainer"/> class.
            /// </summary>
            public KlibuDataContainer(bool insertIntoKlibu, bool isBudgetGreen, int bgBelegID, int bgBudgetID)
            {
                // apply properties
                InsertIntoKlibu = insertIntoKlibu;
                IsBudgetGreen = isBudgetGreen;
                BgBelegID = bgBelegID;
                BgBudgetID = bgBudgetID;
            }

            #endregion

            #region Properties

            public int BgBelegID
            {
                set;
                get;
            }

            public int BgBudgetID
            {
                set;
                get;
            }

            public bool InsertIntoKlibu
            {
                set;
                get;
            }

            public bool IsBudgetGreen
            {
                set;
                get;
            }

            #endregion
        }

        #endregion
    }
}