using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Base dialog used for creating a new person/case or search for existing persons
    /// </summary>
    public class DlgPersonSucheNeu : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// Store the id of a new created person
        /// </summary>
        public int NewBaPersonID;

        /// <summary>
        /// Store the id of the responsible user for the created case
        /// </summary>
        public int UserID;

        #endregion

        #region Protected Fields

        protected KiSS4.Gui.KissButton btnAbbrechen;
        protected KiSS4.Gui.KissButton btnNeu;
        protected KiSS4.Gui.KissGrid grdListe;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvListe;
        protected KiSS4.Gui.KissLabel lblRowCount;
        protected KiSS4.DB.SqlQuery qryBaPerson;
        protected KiSS4.Gui.KissTabControlEx tabListeSuchen;
        protected KiSS4.Gui.KissTabControlEx tabPerson;
        protected SharpLibrary.WinControls.TabPageEx tpgPersonErfassen;
        protected SharpLibrary.WinControls.TabPageEx tpgPersonSuchen;

        #endregion

        #region Private Fields

        private bool _doManuallyNewSearch = false; // flag to set if needed to init a new search on Load or done later in code
        private bool _doRunSearch = false; // store if on tabChanged to Liste a new search has to be executed
        private bool _firstTime = true;
        private bool _isInPLZOrtMethod = false; // store if currently in method to show dialog
        private string _rowCountMLText = ""; // store text to count rows
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private KiSS4.Gui.KissButton btnResetSearch;
        private KiSS4.Gui.KissCheckEdit chkSucheAehnlichePers;
        private KiSS4.Gui.KissCheckEdit chkSucheNurKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colKL;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertenNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edBaPersonID;
        private KiSS4.Gui.KissTextEdit edtAdressZusatz;
        private KiSS4.Gui.KissVersichertenNrEdit edtErfassenNeueVersNr;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatumNeu;
        private KiSS4.Gui.KissLookUpEdit edtGeschlechtNeu;
        private KiSS4.Gui.KissTextEdit edtGeschlechtText;
        private KiSS4.Common.CtlGotoFall edtGotoFall;
        private KiSS4.Gui.KissTextEdit edtHausNr;
        private KiSS4.Gui.KissTextEdit edtKanton;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNameNeu;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaetNeu;
        private KiSS4.Gui.KissTextEdit edtNationalitaetText;
        private KiSS4.Gui.KissVersichertenNrEdit edtNeueVersNr;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtPstfach;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissDateEdit edtSucheGeburtBis;
        private KiSS4.Gui.KissDateEdit edtSucheGeburtVon;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissLookUpEdit edtSucheNationalitaet;
        private KiSS4.Gui.KissTextEdit edtSucheOrt;
        private KiSS4.Gui.KissTextEdit edtSuchePLZ;
        private KiSS4.Gui.KissTextEdit edtSucheStrasse;
        private KiSS4.Gui.KissTextEdit edtSucheVersichertenNr;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissTextEdit edtVornameNeu;
        private KiSS4.Gui.KissTextEdit edtWohnsitzBezirk;
        private KiSS4.Gui.KissTextEdit edtWohnsitzLandText;
        private KiSS4.Gui.KissLabel lblAdresseBezirk;
        private KiSS4.Gui.KissLabel lblErfassenGeburt;
        private KiSS4.Gui.KissLabel lblErfassenGeschlecht;
        private KiSS4.Gui.KissLabel lblErfassenInfo1;
        private KiSS4.Gui.KissLabel lblErfassenInfo2;
        private KiSS4.Gui.KissLabel lblErfassenName;
        private KiSS4.Gui.KissLabel lblErfassenNationalitaet;
        private KiSS4.Gui.KissLabel lblErfassenTitel;
        private KiSS4.Gui.KissLabel lblErfassenVersichertenNr;
        private KiSS4.Gui.KissLabel lblErfassenVorname;
        private KiSS4.Gui.KissLabel lblKeineBerechtigung;
        private KiSS4.Gui.KissLabel lblSucheGeburtBis;
        private KiSS4.Gui.KissLabel lblSucheGeburtVon;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheNation;
        private KiSS4.Gui.KissLabel lblSuchenGeburtstag;
        private KiSS4.Gui.KissLabel lblSuchenGeschlecht;
        private KiSS4.Gui.KissLabel lblSuchenGesetzlWohnsitzTitel;
        private KiSS4.Gui.KissLabel lblSuchenLand;
        private KiSS4.Gui.KissLabel lblSuchenName;
        private KiSS4.Gui.KissLabel lblSuchenNationalitaet;
        private KiSS4.Gui.KissLabel lblSuchenPersonNr;
        private KiSS4.Gui.KissLabel lblSuchenPersTitel;
        private KiSS4.Gui.KissLabel lblSuchenPLZOrtKt;
        private KiSS4.Gui.KissLabel lblSuchenPostfach;
        private KiSS4.Gui.KissLabel lblSuchenStrasseNr;
        private KiSS4.Gui.KissLabel lblSuchenTitel;
        private KiSS4.Gui.KissLabel lblSuchenVorname;
        private KiSS4.Gui.KissLabel lblSuchenZusatz;
        private KiSS4.Gui.KissLabel lblSuchePLZOrt;
        private KiSS4.Gui.KissLabel lblSucheStrasse;
        private KiSS4.Gui.KissLabel lblSucheVersichertenNr;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissLabel lblVersichertenNr;
        private System.Windows.Forms.Panel panBerechtigung;
        private KiSS4.DB.SqlQuery qryNeuePerson;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;
        private KiSS4.Gui.KissSearchTitel ttlSuche;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor to create new instance of class
        /// </summary>
        public DlgPersonSucheNeu()
        {
            // init dialog
            this.InitializeComponent();

            // apply lov-filter
            BaUtils.ApplyLOVBaLand(edtSucheNationalitaet);

            // setup labels
            _rowCountMLText = KissMsg.GetMLMessage(this.Name, "RowCountLabel", "Anzahl Datensätze");
            lblRowCount.Text = "";
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgPersonSucheNeu));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnNeu = new KiSS4.Gui.KissButton();
            this.tabPerson = new KiSS4.Gui.KissTabControlEx();
            this.tpgPersonSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.edtGotoFall = new KiSS4.Common.CtlGotoFall();
            this.qryBaPerson = new KiSS4.DB.SqlQuery();
            this.edBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenPersonNr = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzLandText = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenLand = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzBezirk = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseBezirk = new KiSS4.Gui.KissLabel();
            this.edtKanton = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenPLZOrtKt = new KiSS4.Gui.KissLabel();
            this.edtPstfach = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenPostfach = new KiSS4.Gui.KissLabel();
            this.edtHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtAdressZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenZusatz = new KiSS4.Gui.KissLabel();
            this.lblSuchenGesetzlWohnsitzTitel = new KiSS4.Gui.KissLabel();
            this.edtNationalitaetText = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenNationalitaet = new KiSS4.Gui.KissLabel();
            this.edtGeschlechtText = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblSuchenGeburtstag = new KiSS4.Gui.KissLabel();
            this.edtNeueVersNr = new KiSS4.Gui.KissVersichertenNrEdit();
            this.lblVersichertenNr = new KiSS4.Gui.KissLabel();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenVorname = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblSuchenName = new KiSS4.Gui.KissLabel();
            this.lblSuchenPersTitel = new KiSS4.Gui.KissLabel();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            this.tabListeSuchen = new KiSS4.Gui.KissTabControlEx();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.btnResetSearch = new KiSS4.Gui.KissButton();
            this.chkSucheAehnlichePers = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNurKlient = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheVersichertenNr = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVersichertenNr = new KiSS4.Gui.KissLabel();
            this.edtSucheNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheNation = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtBis = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtVon = new KiSS4.Gui.KissLabel();
            this.edtSucheOrt = new KiSS4.Gui.KissTextEdit();
            this.edtSuchePLZ = new KiSS4.Gui.KissTextEdit();
            this.lblSuchePLZOrt = new KiSS4.Gui.KissLabel();
            this.edtSucheStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblSucheStrasse = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.ttlSuche = new KiSS4.Gui.KissSearchTitel();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe = new KiSS4.Gui.KissGrid();
            this.grvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertenNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSuchenTitel = new KiSS4.Gui.KissLabel();
            this.tpgPersonErfassen = new SharpLibrary.WinControls.TabPageEx();
            this.panBerechtigung = new System.Windows.Forms.Panel();
            this.lblKeineBerechtigung = new KiSS4.Gui.KissLabel();
            this.lblErfassenInfo2 = new KiSS4.Gui.KissLabel();
            this.lblErfassenInfo1 = new KiSS4.Gui.KissLabel();
            this.edtNationalitaetNeu = new KiSS4.Gui.KissLookUpEdit();
            this.qryNeuePerson = new KiSS4.DB.SqlQuery();
            this.lblErfassenNationalitaet = new KiSS4.Gui.KissLabel();
            this.edtGeschlechtNeu = new KiSS4.Gui.KissLookUpEdit();
            this.lblErfassenGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatumNeu = new KiSS4.Gui.KissDateEdit();
            this.lblErfassenGeburt = new KiSS4.Gui.KissLabel();
            this.edtErfassenNeueVersNr = new KiSS4.Gui.KissVersichertenNrEdit();
            this.lblErfassenVersichertenNr = new KiSS4.Gui.KissLabel();
            this.edtVornameNeu = new KiSS4.Gui.KissTextEdit();
            this.lblErfassenVorname = new KiSS4.Gui.KissLabel();
            this.edtNameNeu = new KiSS4.Gui.KissTextEdit();
            this.lblErfassenName = new KiSS4.Gui.KissLabel();
            this.lblErfassenTitel = new KiSS4.Gui.KissLabel();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.tabPerson.SuspendLayout();
            this.tpgPersonSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPersonNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzLandText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzBezirk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPstfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenGesetzlWohnsitzTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenGeburtstag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeueVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPersTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            this.tabListeSuchen.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAehnlichePers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenTitel)).BeginInit();
            this.tpgPersonErfassen.SuspendLayout();
            this.panBerechtigung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKeineBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNeuePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenNeueVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenVersichertenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            //
            // btnNeu
            //
            this.btnNeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeu.Location = new System.Drawing.Point(533, 528);
            this.btnNeu.Name = "btnNeu";
            this.btnNeu.Size = new System.Drawing.Size(96, 24);
            this.btnNeu.TabIndex = 0;
            this.btnNeu.Text = "Neu";
            this.btnNeu.UseCompatibleTextRendering = true;
            this.btnNeu.UseVisualStyleBackColor = false;
            this.btnNeu.Click += new System.EventHandler(this.btnNeu_Click);
            //
            // tabPerson
            //
            this.tabPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPerson.Controls.Add(this.tpgPersonSuchen);
            this.tabPerson.Controls.Add(this.tpgPersonErfassen);
            this.tabPerson.Location = new System.Drawing.Point(8, 10);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.ShowFixedWidthTooltip = true;
            this.tabPerson.Size = new System.Drawing.Size(728, 512);
            this.tabPerson.TabIndex = 0;
            this.tabPerson.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPersonSuchen,
            this.tpgPersonErfassen});
            this.tabPerson.TabsLineColor = System.Drawing.Color.Black;
            this.tabPerson.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabPerson.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabPerson_SelectedTabChanged);
            //
            // tpgPersonSuchen
            //
            this.tpgPersonSuchen.Controls.Add(this.edtGotoFall);
            this.tpgPersonSuchen.Controls.Add(this.edBaPersonID);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenPersonNr);
            this.tpgPersonSuchen.Controls.Add(this.edtWohnsitzLandText);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenLand);
            this.tpgPersonSuchen.Controls.Add(this.edtWohnsitzBezirk);
            this.tpgPersonSuchen.Controls.Add(this.lblAdresseBezirk);
            this.tpgPersonSuchen.Controls.Add(this.edtKanton);
            this.tpgPersonSuchen.Controls.Add(this.edtOrt);
            this.tpgPersonSuchen.Controls.Add(this.edtPLZ);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenPLZOrtKt);
            this.tpgPersonSuchen.Controls.Add(this.edtPstfach);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenPostfach);
            this.tpgPersonSuchen.Controls.Add(this.edtHausNr);
            this.tpgPersonSuchen.Controls.Add(this.edtStrasse);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenStrasseNr);
            this.tpgPersonSuchen.Controls.Add(this.edtAdressZusatz);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenZusatz);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenGesetzlWohnsitzTitel);
            this.tpgPersonSuchen.Controls.Add(this.edtNationalitaetText);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenNationalitaet);
            this.tpgPersonSuchen.Controls.Add(this.edtGeschlechtText);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenGeschlecht);
            this.tpgPersonSuchen.Controls.Add(this.edtGeburtsdatum);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenGeburtstag);
            this.tpgPersonSuchen.Controls.Add(this.edtNeueVersNr);
            this.tpgPersonSuchen.Controls.Add(this.lblVersichertenNr);
            this.tpgPersonSuchen.Controls.Add(this.edtVorname);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenVorname);
            this.tpgPersonSuchen.Controls.Add(this.edtName);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenName);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenPersTitel);
            this.tpgPersonSuchen.Controls.Add(this.lblRowCount);
            this.tpgPersonSuchen.Controls.Add(this.tabListeSuchen);
            this.tpgPersonSuchen.Controls.Add(this.lblSuchenTitel);
            this.tpgPersonSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgPersonSuchen.Name = "tpgPersonSuchen";
            this.tpgPersonSuchen.Size = new System.Drawing.Size(716, 474);
            this.tpgPersonSuchen.TabIndex = 0;
            this.tpgPersonSuchen.Title = "Person suchen";
            //
            // edtGotoFall
            //
            this.edtGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGotoFall.AutoSize = true;
            this.edtGotoFall.DataMember = "BaPersonID";
            this.edtGotoFall.DataSource = this.qryBaPerson;
            this.edtGotoFall.Location = new System.Drawing.Point(495, 444);
            this.edtGotoFall.Name = "edtGotoFall";
            this.edtGotoFall.ShowToolTipsOnIcons = true;
            this.edtGotoFall.Size = new System.Drawing.Size(218, 27);
            this.edtGotoFall.TabIndex = 35;
            //
            // qryBaPerson
            //
            this.qryBaPerson.AutoApplyUserRights = false;
            this.qryBaPerson.FillTimeOut = 60;
            this.qryBaPerson.HostControl = this;
            //
            // edBaPersonID
            //
            this.edBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edBaPersonID.DataMember = "BaPersonID";
            this.edBaPersonID.DataSource = this.qryBaPerson;
            this.edBaPersonID.Location = new System.Drawing.Point(391, 444);
            this.edBaPersonID.Name = "edBaPersonID";
            this.edBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edBaPersonID.Properties.Name = "editDmgPersonID.Properties";
            this.edBaPersonID.Size = new System.Drawing.Size(98, 24);
            this.edBaPersonID.TabIndex = 34;
            //
            // lblSuchenPersonNr
            //
            this.lblSuchenPersonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenPersonNr.Location = new System.Drawing.Point(301, 444);
            this.lblSuchenPersonNr.Name = "lblSuchenPersonNr";
            this.lblSuchenPersonNr.Size = new System.Drawing.Size(84, 24);
            this.lblSuchenPersonNr.TabIndex = 33;
            this.lblSuchenPersonNr.Text = "Personen-Nr.";
            this.lblSuchenPersonNr.UseCompatibleTextRendering = true;
            //
            // edtWohnsitzLandText
            //
            this.edtWohnsitzLandText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzLandText.DataMember = "WohnsitzLandText";
            this.edtWohnsitzLandText.DataSource = this.qryBaPerson;
            this.edtWohnsitzLandText.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzLandText.Location = new System.Drawing.Point(391, 414);
            this.edtWohnsitzLandText.Name = "edtWohnsitzLandText";
            this.edtWohnsitzLandText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzLandText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzLandText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzLandText.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzLandText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzLandText.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzLandText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzLandText.Properties.ReadOnly = true;
            this.edtWohnsitzLandText.Size = new System.Drawing.Size(313, 24);
            this.edtWohnsitzLandText.TabIndex = 32;
            //
            // lblSuchenLand
            //
            this.lblSuchenLand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenLand.Location = new System.Drawing.Point(301, 414);
            this.lblSuchenLand.Name = "lblSuchenLand";
            this.lblSuchenLand.Size = new System.Drawing.Size(84, 24);
            this.lblSuchenLand.TabIndex = 31;
            this.lblSuchenLand.Text = "Land";
            this.lblSuchenLand.UseCompatibleTextRendering = true;
            //
            // edtWohnsitzBezirk
            //
            this.edtWohnsitzBezirk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzBezirk.DataMember = "WohnsitzBezirk";
            this.edtWohnsitzBezirk.DataSource = this.qryBaPerson;
            this.edtWohnsitzBezirk.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzBezirk.Location = new System.Drawing.Point(391, 391);
            this.edtWohnsitzBezirk.Name = "edtWohnsitzBezirk";
            this.edtWohnsitzBezirk.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzBezirk.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzBezirk.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzBezirk.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzBezirk.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzBezirk.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzBezirk.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzBezirk.Properties.ReadOnly = true;
            this.edtWohnsitzBezirk.Size = new System.Drawing.Size(313, 24);
            this.edtWohnsitzBezirk.TabIndex = 30;
            //
            // lblAdresseBezirk
            //
            this.lblAdresseBezirk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdresseBezirk.Location = new System.Drawing.Point(301, 391);
            this.lblAdresseBezirk.Name = "lblAdresseBezirk";
            this.lblAdresseBezirk.Size = new System.Drawing.Size(84, 24);
            this.lblAdresseBezirk.TabIndex = 29;
            this.lblAdresseBezirk.Text = "Bezirk";
            this.lblAdresseBezirk.UseCompatibleTextRendering = true;
            //
            // edtKanton
            //
            this.edtKanton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKanton.DataMember = "WohnsitzKanton";
            this.edtKanton.DataSource = this.qryBaPerson;
            this.edtKanton.Location = new System.Drawing.Point(673, 368);
            this.edtKanton.Name = "edtKanton";
            this.edtKanton.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKanton.Properties.Appearance.Options.UseFont = true;
            this.edtKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKanton.Properties.Name = "editKanton.Properties";
            this.edtKanton.Size = new System.Drawing.Size(31, 24);
            this.edtKanton.TabIndex = 28;
            //
            // edtOrt
            //
            this.edtOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOrt.DataMember = "WohnsitzOrt";
            this.edtOrt.DataSource = this.qryBaPerson;
            this.edtOrt.Location = new System.Drawing.Point(435, 368);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Properties.Name = "editOrt.Properties";
            this.edtOrt.Size = new System.Drawing.Size(239, 24);
            this.edtOrt.TabIndex = 27;
            //
            // edtPLZ
            //
            this.edtPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPLZ.DataMember = "WohnsitzPLZ";
            this.edtPLZ.DataSource = this.qryBaPerson;
            this.edtPLZ.Location = new System.Drawing.Point(391, 368);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Properties.Name = "editPLZ.Properties";
            this.edtPLZ.Size = new System.Drawing.Size(45, 24);
            this.edtPLZ.TabIndex = 26;
            //
            // lblSuchenPLZOrtKt
            //
            this.lblSuchenPLZOrtKt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenPLZOrtKt.Location = new System.Drawing.Point(301, 368);
            this.lblSuchenPLZOrtKt.Name = "lblSuchenPLZOrtKt";
            this.lblSuchenPLZOrtKt.Size = new System.Drawing.Size(84, 24);
            this.lblSuchenPLZOrtKt.TabIndex = 25;
            this.lblSuchenPLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblSuchenPLZOrtKt.UseCompatibleTextRendering = true;
            //
            // edtPstfach
            //
            this.edtPstfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPstfach.DataMember = "WohnsitzPostfach";
            this.edtPstfach.DataSource = this.qryBaPerson;
            this.edtPstfach.Location = new System.Drawing.Point(391, 345);
            this.edtPstfach.Name = "edtPstfach";
            this.edtPstfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPstfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPstfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPstfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtPstfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPstfach.Properties.Appearance.Options.UseFont = true;
            this.edtPstfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPstfach.Properties.Name = "editPstfach.Properties";
            this.edtPstfach.Size = new System.Drawing.Size(313, 24);
            this.edtPstfach.TabIndex = 24;
            //
            // lblSuchenPostfach
            //
            this.lblSuchenPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenPostfach.Location = new System.Drawing.Point(301, 345);
            this.lblSuchenPostfach.Name = "lblSuchenPostfach";
            this.lblSuchenPostfach.Size = new System.Drawing.Size(84, 24);
            this.lblSuchenPostfach.TabIndex = 23;
            this.lblSuchenPostfach.Text = "Postfach";
            this.lblSuchenPostfach.UseCompatibleTextRendering = true;
            //
            // edtHausNr
            //
            this.edtHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHausNr.DataMember = "WohnsitzHausNr";
            this.edtHausNr.DataSource = this.qryBaPerson;
            this.edtHausNr.Location = new System.Drawing.Point(655, 322);
            this.edtHausNr.Name = "edtHausNr";
            this.edtHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNr.Properties.Name = "editNummer.Properties";
            this.edtHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtHausNr.TabIndex = 22;
            //
            // edtStrasse
            //
            this.edtStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStrasse.DataMember = "WohnsitzStrasse";
            this.edtStrasse.DataSource = this.qryBaPerson;
            this.edtStrasse.Location = new System.Drawing.Point(391, 322);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Properties.Name = "editStrasse.Properties";
            this.edtStrasse.Size = new System.Drawing.Size(265, 24);
            this.edtStrasse.TabIndex = 21;
            //
            // lblSuchenStrasseNr
            //
            this.lblSuchenStrasseNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenStrasseNr.Location = new System.Drawing.Point(301, 322);
            this.lblSuchenStrasseNr.Name = "lblSuchenStrasseNr";
            this.lblSuchenStrasseNr.Size = new System.Drawing.Size(84, 24);
            this.lblSuchenStrasseNr.TabIndex = 20;
            this.lblSuchenStrasseNr.Text = "Strasse / Nr.";
            this.lblSuchenStrasseNr.UseCompatibleTextRendering = true;
            //
            // edtAdressZusatz
            //
            this.edtAdressZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdressZusatz.DataMember = "WohnsitzZusatz";
            this.edtAdressZusatz.DataSource = this.qryBaPerson;
            this.edtAdressZusatz.Location = new System.Drawing.Point(391, 299);
            this.edtAdressZusatz.Name = "edtAdressZusatz";
            this.edtAdressZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdressZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressZusatz.Properties.Name = "editAdressZusatz.Properties";
            this.edtAdressZusatz.Size = new System.Drawing.Size(313, 24);
            this.edtAdressZusatz.TabIndex = 19;
            //
            // lblSuchenZusatz
            //
            this.lblSuchenZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenZusatz.Location = new System.Drawing.Point(301, 299);
            this.lblSuchenZusatz.Name = "lblSuchenZusatz";
            this.lblSuchenZusatz.Size = new System.Drawing.Size(84, 24);
            this.lblSuchenZusatz.TabIndex = 18;
            this.lblSuchenZusatz.Text = "Zusatz";
            this.lblSuchenZusatz.UseCompatibleTextRendering = true;
            //
            // lblSuchenGesetzlWohnsitzTitel
            //
            this.lblSuchenGesetzlWohnsitzTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenGesetzlWohnsitzTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSuchenGesetzlWohnsitzTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSuchenGesetzlWohnsitzTitel.Location = new System.Drawing.Point(391, 280);
            this.lblSuchenGesetzlWohnsitzTitel.Name = "lblSuchenGesetzlWohnsitzTitel";
            this.lblSuchenGesetzlWohnsitzTitel.Size = new System.Drawing.Size(270, 16);
            this.lblSuchenGesetzlWohnsitzTitel.TabIndex = 17;
            this.lblSuchenGesetzlWohnsitzTitel.Text = "Gesetzlicher Wohnsitz";
            this.lblSuchenGesetzlWohnsitzTitel.UseCompatibleTextRendering = true;
            //
            // edtNationalitaetText
            //
            this.edtNationalitaetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNationalitaetText.DataMember = "NationalitaetText";
            this.edtNationalitaetText.DataSource = this.qryBaPerson;
            this.edtNationalitaetText.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNationalitaetText.Location = new System.Drawing.Point(93, 414);
            this.edtNationalitaetText.Name = "edtNationalitaetText";
            this.edtNationalitaetText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationalitaetText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaetText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetText.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaetText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaetText.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaetText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNationalitaetText.Properties.ReadOnly = true;
            this.edtNationalitaetText.Size = new System.Drawing.Size(181, 24);
            this.edtNationalitaetText.TabIndex = 16;
            //
            // lblSuchenNationalitaet
            //
            this.lblSuchenNationalitaet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSuchenNationalitaet.Location = new System.Drawing.Point(8, 414);
            this.lblSuchenNationalitaet.Name = "lblSuchenNationalitaet";
            this.lblSuchenNationalitaet.Size = new System.Drawing.Size(78, 24);
            this.lblSuchenNationalitaet.TabIndex = 15;
            this.lblSuchenNationalitaet.Text = "Nationalität";
            this.lblSuchenNationalitaet.UseCompatibleTextRendering = true;
            //
            // edtGeschlechtText
            //
            this.edtGeschlechtText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGeschlechtText.DataMember = "GeschlechtText";
            this.edtGeschlechtText.DataSource = this.qryBaPerson;
            this.edtGeschlechtText.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeschlechtText.Location = new System.Drawing.Point(93, 391);
            this.edtGeschlechtText.Name = "edtGeschlechtText";
            this.edtGeschlechtText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeschlechtText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtText.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtText.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeschlechtText.Properties.ReadOnly = true;
            this.edtGeschlechtText.Size = new System.Drawing.Size(181, 24);
            this.edtGeschlechtText.TabIndex = 14;
            //
            // lblSuchenGeschlecht
            //
            this.lblSuchenGeschlecht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSuchenGeschlecht.Location = new System.Drawing.Point(8, 391);
            this.lblSuchenGeschlecht.Name = "lblSuchenGeschlecht";
            this.lblSuchenGeschlecht.Size = new System.Drawing.Size(78, 24);
            this.lblSuchenGeschlecht.TabIndex = 13;
            this.lblSuchenGeschlecht.Text = "Geschlecht";
            this.lblSuchenGeschlecht.UseCompatibleTextRendering = true;
            //
            // edtGeburtsdatum
            //
            this.edtGeburtsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryBaPerson;
            this.edtGeburtsdatum.EditValue = ((object)(resources.GetObject("edtGeburtsdatum.EditValue")));
            this.edtGeburtsdatum.Location = new System.Drawing.Point(93, 368);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.Name = "editGeburtsdatum.Properties";
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtsdatum.TabIndex = 12;
            //
            // lblSuchenGeburtstag
            //
            this.lblSuchenGeburtstag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSuchenGeburtstag.Location = new System.Drawing.Point(8, 368);
            this.lblSuchenGeburtstag.Name = "lblSuchenGeburtstag";
            this.lblSuchenGeburtstag.Size = new System.Drawing.Size(78, 24);
            this.lblSuchenGeburtstag.TabIndex = 11;
            this.lblSuchenGeburtstag.Text = "Geburt";
            this.lblSuchenGeburtstag.UseCompatibleTextRendering = true;
            //
            // edtNeueVersNr
            //
            this.edtNeueVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNeueVersNr.DataMember = "VersichertenNummer";
            this.edtNeueVersNr.DataSource = this.qryBaPerson;
            this.edtNeueVersNr.Location = new System.Drawing.Point(93, 345);
            this.edtNeueVersNr.Name = "edtNeueVersNr";
            this.edtNeueVersNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNeueVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNeueVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNeueVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNeueVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNeueVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNeueVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtNeueVersNr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtNeueVersNr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtNeueVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNeueVersNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNeueVersNr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtNeueVersNr.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtNeueVersNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtNeueVersNr.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtNeueVersNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtNeueVersNr.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtNeueVersNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtNeueVersNr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtNeueVersNr.Properties.MaxLength = 13;
            this.edtNeueVersNr.Properties.Name = "edtNeueVersNr.Properties";
            this.edtNeueVersNr.Properties.Precision = 0;
            this.edtNeueVersNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtNeueVersNr.Size = new System.Drawing.Size(181, 24);
            this.edtNeueVersNr.TabIndex = 10;
            //
            // lblVersichertenNr
            //
            this.lblVersichertenNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersichertenNr.Location = new System.Drawing.Point(9, 345);
            this.lblVersichertenNr.Name = "lblVersichertenNr";
            this.lblVersichertenNr.Size = new System.Drawing.Size(78, 24);
            this.lblVersichertenNr.TabIndex = 9;
            this.lblVersichertenNr.Text = "Vers.-Nr.";
            this.lblVersichertenNr.UseCompatibleTextRendering = true;
            //
            // edtVorname
            //
            this.edtVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryBaPerson;
            this.edtVorname.Location = new System.Drawing.Point(93, 322);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Properties.Name = "editVorname1.Properties";
            this.edtVorname.Size = new System.Drawing.Size(181, 24);
            this.edtVorname.TabIndex = 6;
            //
            // lblSuchenVorname
            //
            this.lblSuchenVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSuchenVorname.Location = new System.Drawing.Point(8, 322);
            this.lblSuchenVorname.Name = "lblSuchenVorname";
            this.lblSuchenVorname.Size = new System.Drawing.Size(78, 24);
            this.lblSuchenVorname.TabIndex = 5;
            this.lblSuchenVorname.Text = "Vorname";
            this.lblSuchenVorname.UseCompatibleTextRendering = true;
            //
            // edtName
            //
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBaPerson;
            this.edtName.Location = new System.Drawing.Point(93, 299);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.Name = "editName.Properties";
            this.edtName.Size = new System.Drawing.Size(181, 24);
            this.edtName.TabIndex = 4;
            //
            // lblSuchenName
            //
            this.lblSuchenName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSuchenName.Location = new System.Drawing.Point(8, 298);
            this.lblSuchenName.Name = "lblSuchenName";
            this.lblSuchenName.Size = new System.Drawing.Size(78, 24);
            this.lblSuchenName.TabIndex = 3;
            this.lblSuchenName.Text = "Name";
            this.lblSuchenName.UseCompatibleTextRendering = true;
            //
            // lblSuchenPersTitel
            //
            this.lblSuchenPersTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSuchenPersTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSuchenPersTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSuchenPersTitel.Location = new System.Drawing.Point(93, 280);
            this.lblSuchenPersTitel.Name = "lblSuchenPersTitel";
            this.lblSuchenPersTitel.Size = new System.Drawing.Size(181, 16);
            this.lblSuchenPersTitel.TabIndex = 2;
            this.lblSuchenPersTitel.Text = "Person";
            this.lblSuchenPersTitel.UseCompatibleTextRendering = true;
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRowCount.Location = new System.Drawing.Point(555, 256);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(155, 16);
            this.lblRowCount.TabIndex = 1;
            this.lblRowCount.Text = "";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            //
            // tabListeSuchen
            //
            this.tabListeSuchen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabListeSuchen.Controls.Add(this.tpgSuchen);
            this.tabListeSuchen.Controls.Add(this.tpgListe);
            this.tabListeSuchen.Location = new System.Drawing.Point(3, 32);
            this.tabListeSuchen.Name = "tabListeSuchen";
            this.tabListeSuchen.SelectedTabIndex = 1;
            this.tabListeSuchen.ShowFixedWidthTooltip = true;
            this.tabListeSuchen.Size = new System.Drawing.Size(710, 245);
            this.tabListeSuchen.TabIndex = 0;
            this.tabListeSuchen.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabListeSuchen.TabsLineColor = System.Drawing.Color.Black;
            this.tabListeSuchen.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabListeSuchen.Text = "kissTabControlEx1";
            this.tabListeSuchen.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabListeSuchen_SelectedTabChanged);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.btnResetSearch);
            this.tpgSuchen.Controls.Add(this.chkSucheAehnlichePers);
            this.tpgSuchen.Controls.Add(this.chkSucheNurKlient);
            this.tpgSuchen.Controls.Add(this.edtSucheVersichertenNr);
            this.tpgSuchen.Controls.Add(this.lblSucheVersichertenNr);
            this.tpgSuchen.Controls.Add(this.edtSucheNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblSucheNation);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.edtSucheOrt);
            this.tpgSuchen.Controls.Add(this.edtSuchePLZ);
            this.tpgSuchen.Controls.Add(this.lblSuchePLZOrt);
            this.tpgSuchen.Controls.Add(this.edtSucheStrasse);
            this.tpgSuchen.Controls.Add(this.lblSucheStrasse);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.ttlSuche);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(698, 207);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            //
            // btnResetSearch
            //
            this.btnResetSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSearch.IconID = 4;
            this.btnResetSearch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResetSearch.Location = new System.Drawing.Point(671, 5);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(24, 24);
            this.btnResetSearch.TabIndex = 22;
            this.btnResetSearch.UseCompatibleTextRendering = true;
            this.btnResetSearch.UseVisualStyleBackColor = false;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);
            //
            // chkSucheAehnlichePers
            //
            this.chkSucheAehnlichePers.EditValue = "False";
            this.chkSucheAehnlichePers.Location = new System.Drawing.Point(390, 150);
            this.chkSucheAehnlichePers.Name = "chkSucheAehnlichePers";
            this.chkSucheAehnlichePers.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheAehnlichePers.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheAehnlichePers.Properties.Caption = "Auch ähnliche Personen anzeigen";
            this.chkSucheAehnlichePers.Properties.Name = "editSoundexX.Properties";
            this.chkSucheAehnlichePers.Size = new System.Drawing.Size(229, 19);
            this.chkSucheAehnlichePers.TabIndex = 21;
            //
            // chkSucheNurKlient
            //
            this.chkSucheNurKlient.EditValue = "False";
            this.chkSucheNurKlient.Location = new System.Drawing.Point(390, 125);
            this.chkSucheNurKlient.Name = "chkSucheNurKlient";
            this.chkSucheNurKlient.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurKlient.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurKlient.Properties.Caption = "Nur Klient/in";
            this.chkSucheNurKlient.Properties.Name = "editFTX.Properties";
            this.chkSucheNurKlient.Size = new System.Drawing.Size(229, 19);
            this.chkSucheNurKlient.TabIndex = 20;
            //
            // edtSucheVersichertenNr
            //
            this.edtSucheVersichertenNr.Location = new System.Drawing.Point(390, 95);
            this.edtSucheVersichertenNr.Name = "edtSucheVersichertenNr";
            this.edtSucheVersichertenNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVersichertenNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVersichertenNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVersichertenNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVersichertenNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVersichertenNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVersichertenNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVersichertenNr.Properties.Name = "edtSucheVersichertenNr.Properties";
            this.edtSucheVersichertenNr.Size = new System.Drawing.Size(229, 24);
            this.edtSucheVersichertenNr.TabIndex = 19;
            //
            // lblSucheVersichertenNr
            //
            this.lblSucheVersichertenNr.Location = new System.Drawing.Point(306, 95);
            this.lblSucheVersichertenNr.Name = "lblSucheVersichertenNr";
            this.lblSucheVersichertenNr.Size = new System.Drawing.Size(79, 24);
            this.lblSucheVersichertenNr.TabIndex = 18;
            this.lblSucheVersichertenNr.Text = "Vers.-Nr.";
            this.lblSucheVersichertenNr.UseCompatibleTextRendering = true;
            //
            // edtSucheNationalitaet
            //
            this.edtSucheNationalitaet.Location = new System.Drawing.Point(390, 65);
            this.edtSucheNationalitaet.Name = "edtSucheNationalitaet";
            this.edtSucheNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheNationalitaet.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtSucheNationalitaet.Properties.Name = "editNationalitaetX.Properties";
            this.edtSucheNationalitaet.Properties.NullText = "";
            this.edtSucheNationalitaet.Properties.ShowFooter = false;
            this.edtSucheNationalitaet.Properties.ShowHeader = false;
            this.edtSucheNationalitaet.Size = new System.Drawing.Size(229, 24);
            this.edtSucheNationalitaet.TabIndex = 15;
            //
            // lblSucheNation
            //
            this.lblSucheNation.Location = new System.Drawing.Point(306, 65);
            this.lblSucheNation.Name = "lblSucheNation";
            this.lblSucheNation.Size = new System.Drawing.Size(79, 24);
            this.lblSucheNation.TabIndex = 14;
            this.lblSucheNation.Text = "Nationalität";
            this.lblSucheNation.UseCompatibleTextRendering = true;
            //
            // edtSucheGeburtBis
            //
            this.edtSucheGeburtBis.EditValue = null;
            this.edtSucheGeburtBis.Location = new System.Drawing.Point(524, 35);
            this.edtSucheGeburtBis.Name = "edtSucheGeburtBis";
            this.edtSucheGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeburtBis.Properties.Name = "editGeburtBisX.Properties";
            this.edtSucheGeburtBis.Properties.ShowToday = false;
            this.edtSucheGeburtBis.Size = new System.Drawing.Size(95, 24);
            this.edtSucheGeburtBis.TabIndex = 13;
            //
            // lblSucheGeburtBis
            //
            this.lblSucheGeburtBis.Location = new System.Drawing.Point(490, 35);
            this.lblSucheGeburtBis.Name = "lblSucheGeburtBis";
            this.lblSucheGeburtBis.Size = new System.Drawing.Size(28, 24);
            this.lblSucheGeburtBis.TabIndex = 12;
            this.lblSucheGeburtBis.Text = "bis";
            this.lblSucheGeburtBis.UseCompatibleTextRendering = true;
            //
            // edtSucheGeburtVon
            //
            this.edtSucheGeburtVon.EditValue = null;
            this.edtSucheGeburtVon.Location = new System.Drawing.Point(390, 35);
            this.edtSucheGeburtVon.Name = "edtSucheGeburtVon";
            this.edtSucheGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeburtVon.Properties.Name = "editGeburtVonX.Properties";
            this.edtSucheGeburtVon.Properties.ShowToday = false;
            this.edtSucheGeburtVon.Size = new System.Drawing.Size(95, 24);
            this.edtSucheGeburtVon.TabIndex = 11;
            //
            // lblSucheGeburtVon
            //
            this.lblSucheGeburtVon.Location = new System.Drawing.Point(306, 35);
            this.lblSucheGeburtVon.Name = "lblSucheGeburtVon";
            this.lblSucheGeburtVon.Size = new System.Drawing.Size(79, 24);
            this.lblSucheGeburtVon.TabIndex = 10;
            this.lblSucheGeburtVon.Text = "Geburt";
            this.lblSucheGeburtVon.UseCompatibleTextRendering = true;
            //
            // edtSucheOrt
            //
            this.edtSucheOrt.Location = new System.Drawing.Point(132, 125);
            this.edtSucheOrt.Name = "edtSucheOrt";
            this.edtSucheOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheOrt.Properties.Name = "editOrtX.Properties";
            this.edtSucheOrt.Size = new System.Drawing.Size(151, 24);
            this.edtSucheOrt.TabIndex = 9;
            this.edtSucheOrt.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheOrt_UserModifiedFld);
            //
            // edtSuchePLZ
            //
            this.edtSuchePLZ.Location = new System.Drawing.Point(77, 125);
            this.edtSuchePLZ.Name = "edtSuchePLZ";
            this.edtSuchePLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePLZ.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePLZ.Properties.Name = "editPLZX.Properties";
            this.edtSuchePLZ.Size = new System.Drawing.Size(56, 24);
            this.edtSuchePLZ.TabIndex = 8;
            this.edtSuchePLZ.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSuchePLZ_UserModifiedFld);
            //
            // lblSuchePLZOrt
            //
            this.lblSuchePLZOrt.Location = new System.Drawing.Point(9, 125);
            this.lblSuchePLZOrt.Name = "lblSuchePLZOrt";
            this.lblSuchePLZOrt.Size = new System.Drawing.Size(62, 24);
            this.lblSuchePLZOrt.TabIndex = 7;
            this.lblSuchePLZOrt.Text = "PLZ / Ort";
            this.lblSuchePLZOrt.UseCompatibleTextRendering = true;
            //
            // edtSucheStrasse
            //
            this.edtSucheStrasse.Location = new System.Drawing.Point(77, 95);
            this.edtSucheStrasse.Name = "edtSucheStrasse";
            this.edtSucheStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStrasse.Properties.Name = "editStrasseX.Properties";
            this.edtSucheStrasse.Size = new System.Drawing.Size(206, 24);
            this.edtSucheStrasse.TabIndex = 6;
            //
            // lblSucheStrasse
            //
            this.lblSucheStrasse.Location = new System.Drawing.Point(9, 95);
            this.lblSucheStrasse.Name = "lblSucheStrasse";
            this.lblSucheStrasse.Size = new System.Drawing.Size(62, 24);
            this.lblSucheStrasse.TabIndex = 5;
            this.lblSucheStrasse.Text = "Strasse";
            this.lblSucheStrasse.UseCompatibleTextRendering = true;
            //
            // edtSucheVorname
            //
            this.edtSucheVorname.Location = new System.Drawing.Point(77, 65);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Properties.Name = "editVornameX.Properties";
            this.edtSucheVorname.Size = new System.Drawing.Size(206, 24);
            this.edtSucheVorname.TabIndex = 4;
            //
            // lblSucheVorname
            //
            this.lblSucheVorname.Location = new System.Drawing.Point(9, 65);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(62, 24);
            this.lblSucheVorname.TabIndex = 3;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            //
            // edtSucheName
            //
            this.edtSucheName.Location = new System.Drawing.Point(77, 35);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Properties.Name = "editNameX.Properties";
            this.edtSucheName.Size = new System.Drawing.Size(206, 24);
            this.edtSucheName.TabIndex = 2;
            //
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(9, 35);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(62, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // ttlSuche
            //
            this.ttlSuche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ttlSuche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ttlSuche.Location = new System.Drawing.Point(8, 5);
            this.ttlSuche.Name = "ttlSuche";
            this.ttlSuche.Size = new System.Drawing.Size(657, 24);
            this.ttlSuche.TabIndex = 0;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdListe);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(698, 207);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            //
            // grdListe
            //
            this.grdListe.DataSource = this.qryBaPerson;
            this.grdListe.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdListe.EmbeddedNavigator.Name = "gridList.EmbeddedNavigator";
            this.grdListe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe.Location = new System.Drawing.Point(0, 0);
            this.grdListe.MainView = this.grvListe;
            this.grdListe.Name = "grdListe";
            this.grdListe.Size = new System.Drawing.Size(698, 207);
            this.grdListe.TabIndex = 0;
            this.grdListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe});
            //
            // grvListe
            //
            this.grvListe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe.Appearance.Empty.Options.UseFont = true;
            this.grvListe.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvListe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvListe.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvListe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.OddRow.Options.UseBackColor = true;
            this.grvListe.Appearance.OddRow.Options.UseFont = true;
            this.grvListe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.Row.Options.UseBackColor = true;
            this.grvListe.Appearance.Row.Options.UseFont = true;
            this.grvListe.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvListe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvListe.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvListe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvListe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKL,
            this.colSAR,
            this.colName,
            this.colVorname,
            this.colOrt,
            this.colGeschlecht,
            this.colAlter,
            this.colGeburtsdatum,
            this.colVersichertenNr});
            this.grvListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe.GridControl = this.grdListe;
            this.grvListe.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvListe.Name = "grvListe";
            this.grvListe.OptionsBehavior.Editable = false;
            this.grvListe.OptionsCustomization.AllowFilter = false;
            this.grvListe.OptionsFilter.AllowFilterEditor = false;
            this.grvListe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe.OptionsMenu.EnableColumnMenu = false;
            this.grvListe.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe.OptionsNavigation.UseTabKey = false;
            this.grvListe.OptionsView.ColumnAutoWidth = false;
            this.grvListe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe.OptionsView.ShowGroupPanel = false;
            this.grvListe.OptionsView.ShowIndicator = false;
            //
            // colKL
            //
            this.colKL.Caption = "KL";
            this.colKL.FieldName = "KL";
            this.colKL.Name = "colKL";
            this.colKL.Visible = true;
            this.colKL.VisibleIndex = 0;
            this.colKL.Width = 27;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 1;
            this.colSAR.Width = 100;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 131;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            this.colVorname.Width = 90;
            //
            // colOrt
            //
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "PLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 4;
            this.colOrt.Width = 132;
            //
            // colGeschlecht
            //
            this.colGeschlecht.Caption = "m/w";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 5;
            this.colGeschlecht.Width = 34;
            //
            // colAlter
            //
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 6;
            this.colAlter.Width = 38;
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Caption = "Geburt";
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 7;
            //
            // colVersichertenNr
            //
            this.colVersichertenNr.Caption = "Vers.-Nr.";
            this.colVersichertenNr.FieldName = "VersichertenNummer";
            this.colVersichertenNr.Name = "colVersichertenNr";
            this.colVersichertenNr.Visible = true;
            this.colVersichertenNr.VisibleIndex = 8;
            this.colVersichertenNr.Width = 95;
            //
            // lblSuchenTitel
            //
            this.lblSuchenTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchenTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblSuchenTitel.Location = new System.Drawing.Point(8, 7);
            this.lblSuchenTitel.Name = "lblSuchenTitel";
            this.lblSuchenTitel.Size = new System.Drawing.Size(705, 16);
            this.lblSuchenTitel.TabIndex = 0;
            this.lblSuchenTitel.Text = "1. Person suchen (prüfen, ob Person bereits im Personenstamm erfasst ist)";
            this.lblSuchenTitel.UseCompatibleTextRendering = true;
            //
            // tpgPersonErfassen
            //
            this.tpgPersonErfassen.Controls.Add(this.panBerechtigung);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenInfo2);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenInfo1);
            this.tpgPersonErfassen.Controls.Add(this.edtNationalitaetNeu);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenNationalitaet);
            this.tpgPersonErfassen.Controls.Add(this.edtGeschlechtNeu);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenGeschlecht);
            this.tpgPersonErfassen.Controls.Add(this.edtGeburtsdatumNeu);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenGeburt);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenNeueVersNr);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenVersichertenNr);
            this.tpgPersonErfassen.Controls.Add(this.edtVornameNeu);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenVorname);
            this.tpgPersonErfassen.Controls.Add(this.edtNameNeu);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenName);
            this.tpgPersonErfassen.Controls.Add(this.lblErfassenTitel);
            this.tpgPersonErfassen.Location = new System.Drawing.Point(6, 6);
            this.tpgPersonErfassen.Name = "tpgPersonErfassen";
            this.tpgPersonErfassen.Size = new System.Drawing.Size(716, 474);
            this.tpgPersonErfassen.TabIndex = 0;
            this.tpgPersonErfassen.Title = "Person erfassen";
            //
            // panBerechtigung
            //
            this.panBerechtigung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBerechtigung.Controls.Add(this.lblKeineBerechtigung);
            this.panBerechtigung.Location = new System.Drawing.Point(8, 268);
            this.panBerechtigung.Name = "panBerechtigung";
            this.panBerechtigung.Size = new System.Drawing.Size(702, 21);
            this.panBerechtigung.TabIndex = 642;
            //
            // lblKeineBerechtigung
            //
            this.lblKeineBerechtigung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeineBerechtigung.ForeColor = System.Drawing.Color.Firebrick;
            this.lblKeineBerechtigung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKeineBerechtigung.Location = new System.Drawing.Point(0, 0);
            this.lblKeineBerechtigung.Name = "lblKeineBerechtigung";
            this.lblKeineBerechtigung.Size = new System.Drawing.Size(702, 21);
            this.lblKeineBerechtigung.TabIndex = 0;
            this.lblKeineBerechtigung.Text = "Sie haben nicht die Berechtigung, eine neue Person zu erfassen!";
            this.lblKeineBerechtigung.UseCompatibleTextRendering = true;
            //
            // lblErfassenInfo2
            //
            this.lblErfassenInfo2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblErfassenInfo2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassenInfo2.Location = new System.Drawing.Point(316, 137);
            this.lblErfassenInfo2.Name = "lblErfassenInfo2";
            this.lblErfassenInfo2.Size = new System.Drawing.Size(194, 77);
            this.lblErfassenInfo2.TabIndex = 16;
            this.lblErfassenInfo2.Text = "Geburtsdatum und Geschlecht sind wichtig für die korrekte Darstellung im Sozialsy" +
    "stem.";
            this.lblErfassenInfo2.UseCompatibleTextRendering = true;
            //
            // lblErfassenInfo1
            //
            this.lblErfassenInfo1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblErfassenInfo1.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassenInfo1.Location = new System.Drawing.Point(316, 53);
            this.lblErfassenInfo1.Name = "lblErfassenInfo1";
            this.lblErfassenInfo1.Size = new System.Drawing.Size(194, 85);
            this.lblErfassenInfo1.TabIndex = 15;
            this.lblErfassenInfo1.Text = "Die restlichen demographischen Daten (Adresse, Heimatort etc.) können in der Basi" +
    "s erfasst werden, nachdem der neue Fall erzeugt wurde.";
            this.lblErfassenInfo1.UseCompatibleTextRendering = true;
            //
            // edtNationalitaetNeu
            //
            this.edtNationalitaetNeu.DataMember = "NationalitaetCode";
            this.edtNationalitaetNeu.DataSource = this.qryNeuePerson;
            this.edtNationalitaetNeu.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtNationalitaetNeu.Location = new System.Drawing.Point(92, 201);
            this.edtNationalitaetNeu.Name = "edtNationalitaetNeu";
            this.edtNationalitaetNeu.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtNationalitaetNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaetNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaetNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaetNeu.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaetNeu.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNationalitaetNeu.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetNeu.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaetNeu.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaetNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtNationalitaetNeu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtNationalitaetNeu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaetNeu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtNationalitaetNeu.Properties.Name = "editNationalitaetNeu.Properties";
            this.edtNationalitaetNeu.Properties.NullText = "";
            this.edtNationalitaetNeu.Properties.ShowFooter = false;
            this.edtNationalitaetNeu.Properties.ShowHeader = false;
            this.edtNationalitaetNeu.Size = new System.Drawing.Size(181, 24);
            this.edtNationalitaetNeu.TabIndex = 14;
            //
            // qryNeuePerson
            //
            this.qryNeuePerson.AutoApplyUserRights = false;
            this.qryNeuePerson.CanDelete = true;
            this.qryNeuePerson.CanInsert = true;
            this.qryNeuePerson.CanUpdate = true;
            this.qryNeuePerson.HostControl = this;
            //
            // lblErfassenNationalitaet
            //
            this.lblErfassenNationalitaet.Location = new System.Drawing.Point(8, 201);
            this.lblErfassenNationalitaet.Name = "lblErfassenNationalitaet";
            this.lblErfassenNationalitaet.Size = new System.Drawing.Size(78, 24);
            this.lblErfassenNationalitaet.TabIndex = 13;
            this.lblErfassenNationalitaet.Text = "Nationalität";
            this.lblErfassenNationalitaet.UseCompatibleTextRendering = true;
            //
            // edtGeschlechtNeu
            //
            this.edtGeschlechtNeu.DataMember = "GeschlechtCode";
            this.edtGeschlechtNeu.DataSource = this.qryNeuePerson;
            this.edtGeschlechtNeu.Location = new System.Drawing.Point(92, 178);
            this.edtGeschlechtNeu.LOVName = "Geschlecht";
            this.edtGeschlechtNeu.Name = "edtGeschlechtNeu";
            this.edtGeschlechtNeu.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschlechtNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtNeu.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtNeu.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschlechtNeu.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtNeu.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschlechtNeu.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschlechtNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtGeschlechtNeu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtGeschlechtNeu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlechtNeu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtGeschlechtNeu.Properties.Name = "editGeschlechtNeu.Properties";
            this.edtGeschlechtNeu.Properties.NullText = "";
            this.edtGeschlechtNeu.Properties.ShowFooter = false;
            this.edtGeschlechtNeu.Properties.ShowHeader = false;
            this.edtGeschlechtNeu.Size = new System.Drawing.Size(181, 24);
            this.edtGeschlechtNeu.TabIndex = 12;
            //
            // lblErfassenGeschlecht
            //
            this.lblErfassenGeschlecht.Location = new System.Drawing.Point(8, 178);
            this.lblErfassenGeschlecht.Name = "lblErfassenGeschlecht";
            this.lblErfassenGeschlecht.Size = new System.Drawing.Size(78, 24);
            this.lblErfassenGeschlecht.TabIndex = 11;
            this.lblErfassenGeschlecht.Text = "Geschlecht";
            this.lblErfassenGeschlecht.UseCompatibleTextRendering = true;
            //
            // edtGeburtsdatumNeu
            //
            this.edtGeburtsdatumNeu.DataMember = "Geburtsdatum";
            this.edtGeburtsdatumNeu.DataSource = this.qryNeuePerson;
            this.edtGeburtsdatumNeu.EditValue = ((object)(resources.GetObject("edtGeburtsdatumNeu.EditValue")));
            this.edtGeburtsdatumNeu.Location = new System.Drawing.Point(92, 137);
            this.edtGeburtsdatumNeu.Name = "edtGeburtsdatumNeu";
            this.edtGeburtsdatumNeu.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatumNeu.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatumNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatumNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatumNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatumNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatumNeu.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatumNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtGeburtsdatumNeu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatumNeu.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtGeburtsdatumNeu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatumNeu.Properties.Name = "editGeburtsdatumNeu.Properties";
            this.edtGeburtsdatumNeu.Properties.ShowToday = false;
            this.edtGeburtsdatumNeu.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtsdatumNeu.TabIndex = 10;
            //
            // lblErfassenGeburt
            //
            this.lblErfassenGeburt.Location = new System.Drawing.Point(8, 137);
            this.lblErfassenGeburt.Name = "lblErfassenGeburt";
            this.lblErfassenGeburt.Size = new System.Drawing.Size(78, 24);
            this.lblErfassenGeburt.TabIndex = 9;
            this.lblErfassenGeburt.Text = "Geburt";
            this.lblErfassenGeburt.UseCompatibleTextRendering = true;
            //
            // edtErfassenNeueVersNr
            //
            this.edtErfassenNeueVersNr.DataMember = "VersichertenNummer";
            this.edtErfassenNeueVersNr.DataSource = this.qryNeuePerson;
            this.edtErfassenNeueVersNr.Location = new System.Drawing.Point(92, 114);
            this.edtErfassenNeueVersNr.Name = "edtErfassenNeueVersNr";
            this.edtErfassenNeueVersNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassenNeueVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenNeueVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenNeueVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenNeueVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenNeueVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenNeueVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenNeueVersNr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtErfassenNeueVersNr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtErfassenNeueVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassenNeueVersNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassenNeueVersNr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtErfassenNeueVersNr.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtErfassenNeueVersNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtErfassenNeueVersNr.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtErfassenNeueVersNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtErfassenNeueVersNr.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtErfassenNeueVersNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtErfassenNeueVersNr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtErfassenNeueVersNr.Properties.MaxLength = 13;
            this.edtErfassenNeueVersNr.Properties.Name = "edtErfassenNeueVersNr.Properties";
            this.edtErfassenNeueVersNr.Properties.Precision = 0;
            this.edtErfassenNeueVersNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtErfassenNeueVersNr.Size = new System.Drawing.Size(181, 24);
            this.edtErfassenNeueVersNr.TabIndex = 8;
            //
            // lblErfassenVersichertenNr
            //
            this.lblErfassenVersichertenNr.Location = new System.Drawing.Point(8, 114);
            this.lblErfassenVersichertenNr.Name = "lblErfassenVersichertenNr";
            this.lblErfassenVersichertenNr.Size = new System.Drawing.Size(78, 24);
            this.lblErfassenVersichertenNr.TabIndex = 7;
            this.lblErfassenVersichertenNr.Text = "Vers.-Nr.";
            this.lblErfassenVersichertenNr.UseCompatibleTextRendering = true;
            //
            // edtVornameNeu
            //
            this.edtVornameNeu.DataMember = "Vorname";
            this.edtVornameNeu.DataSource = this.qryNeuePerson;
            this.edtVornameNeu.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtVornameNeu.Location = new System.Drawing.Point(92, 72);
            this.edtVornameNeu.Name = "edtVornameNeu";
            this.edtVornameNeu.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtVornameNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVornameNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornameNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtVornameNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVornameNeu.Properties.Appearance.Options.UseFont = true;
            this.edtVornameNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVornameNeu.Properties.Name = "editVornameNeu.Properties";
            this.edtVornameNeu.Size = new System.Drawing.Size(181, 24);
            this.edtVornameNeu.TabIndex = 4;
            //
            // lblErfassenVorname
            //
            this.lblErfassenVorname.Location = new System.Drawing.Point(8, 72);
            this.lblErfassenVorname.Name = "lblErfassenVorname";
            this.lblErfassenVorname.Size = new System.Drawing.Size(78, 24);
            this.lblErfassenVorname.TabIndex = 3;
            this.lblErfassenVorname.Text = "Vorname";
            this.lblErfassenVorname.UseCompatibleTextRendering = true;
            //
            // edtNameNeu
            //
            this.edtNameNeu.DataMember = "Name";
            this.edtNameNeu.DataSource = this.qryNeuePerson;
            this.edtNameNeu.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtNameNeu.Location = new System.Drawing.Point(92, 49);
            this.edtNameNeu.Name = "edtNameNeu";
            this.edtNameNeu.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtNameNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameNeu.Properties.Appearance.Options.UseFont = true;
            this.edtNameNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameNeu.Properties.Name = "editNameNeu.Properties";
            this.edtNameNeu.Size = new System.Drawing.Size(181, 24);
            this.edtNameNeu.TabIndex = 2;
            //
            // lblErfassenName
            //
            this.lblErfassenName.Location = new System.Drawing.Point(8, 49);
            this.lblErfassenName.Name = "lblErfassenName";
            this.lblErfassenName.Size = new System.Drawing.Size(78, 24);
            this.lblErfassenName.TabIndex = 1;
            this.lblErfassenName.Text = "Name";
            this.lblErfassenName.UseCompatibleTextRendering = true;
            //
            // lblErfassenTitel
            //
            this.lblErfassenTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErfassenTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblErfassenTitel.Location = new System.Drawing.Point(8, 7);
            this.lblErfassenTitel.Name = "lblErfassenTitel";
            this.lblErfassenTitel.Size = new System.Drawing.Size(705, 16);
            this.lblErfassenTitel.TabIndex = 0;
            this.lblErfassenTitel.Text = "2. Person erfassen  (nur falls im Personenstamm nicht gefunden)";
            this.lblErfassenTitel.UseCompatibleTextRendering = true;
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(635, 528);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(96, 24);
            this.btnAbbrechen.TabIndex = 1;
            this.btnAbbrechen.Text = "Abbruch";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            //
            // barManager1
            //
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 0;
            this.barManager1.StatusBar = this.bar3;
            //
            // bar1
            //
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            this.bar1.Visible = false;
            //
            // bar2
            //
            this.bar2.BarName = "Custom 3";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            this.bar2.Visible = false;
            //
            // bar3
            //
            this.bar3.BarName = "Custom 4";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Custom 4";
            this.bar3.Visible = false;
            //
            // DlgPersonSucheNeu
            //
            this.ClientSize = new System.Drawing.Size(745, 560);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.tabPerson);
            this.Controls.Add(this.btnNeu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DlgPersonSucheNeu";
            this.Text = "Neue Person";
            this.Activated += new System.EventHandler(this.DlgPersonSucheNeu_Activated);
            this.Load += new System.EventHandler(this.DlgPersonSucheNeu_Load);
            this.tabPerson.ResumeLayout(false);
            this.tpgPersonSuchen.ResumeLayout(false);
            this.tpgPersonSuchen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPersonNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzLandText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzBezirk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPstfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenGesetzlWohnsitzTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenGeburtstag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeueVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPersTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            this.tabListeSuchen.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAehnlichePers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenTitel)).EndInit();
            this.tpgPersonErfassen.ResumeLayout(false);
            this.panBerechtigung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKeineBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNeuePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenNeueVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenVersichertenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassenTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
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

        /// <summary>
        /// Perform additional checks before creating new data entries
        /// </summary>
        protected virtual void Additional_Check()
        {
        }

        /// <summary>
        /// Jump To New Fall
        /// </summary>
        protected virtual void JumpToNewFall()
        {           
        }

        /// <summary>
        /// Perform additional work after creating new data entries
        /// </summary>
        protected virtual void Additional_Save()
        {
        }

        private void btnNeu_Click(object sender, System.EventArgs e)
        {
            try
            {
                // check if user entered a new person
                if (tabPerson.IsTabSelected(tpgPersonErfassen))
                {
                    // check rights
                    if (!qryNeuePerson.CanInsert)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage(Name, "KeineBerechtigung", "Sie haben nicht die Berechtigung, eine neue Person zu erfassen!", KissMsgCode.MsgInfo));
                    }

                    // validate must fields
                    DBUtil.CheckNotNullField(edtNameNeu, lblErfassenName.Text);
                    DBUtil.CheckNotNullField(edtVornameNeu, lblErfassenVorname.Text);
                    DBUtil.CheckNotNullField(edtNationalitaetNeu, lblErfassenNationalitaet.Text);

                    // validate versNr
                    if (!edtErfassenNeueVersNr.ValidateVersNr(true, false))
                    {
                        // set focus
                        edtErfassenNeueVersNr.Focus();

                        // cancel, message already shown
                        throw new KissCancelException(String.Empty);
                    }

                    // Geburtsdatum
                    if (!DBUtil.IsEmpty(qryNeuePerson["Geburtsdatum"]) && Convert.ToDateTime(qryNeuePerson["Geburtsdatum"]) > DateTime.Today)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage(Name, "GeburtsdatumInvalidValue", "Das Geburtsdatum liegt in der Zukunft!"), edtGeburtsdatum);
                    }

                    // Geburtsdatum within range
                    if (!DBUtil.IsEmpty(qryNeuePerson["Geburtsdatum"]) && !BaUtils.IsBirthdayDateValid(Convert.ToDateTime(qryNeuePerson["Geburtsdatum"])))
                    {
                        // invalid birthday-date, do cancel, message already shown
                        edtGeburtsdatumNeu.Focus();

                        // cancel but do not show any message
                        throw new KissCancelException(String.Empty);
                    }

                    // confirm
                    if (!KissMsg.ShowQuestion(Name, "IstInPersonenstamm", "Sind Sie sicher, dass '{0} {1}' nicht bereits im Personenstamm erfasst ist?", 0, 0, true, qryNeuePerson["Vorname"], qryNeuePerson["Name"]))
                    {
                        // cancel but do not show any message
                        throw new KissCancelException(String.Empty);
                    }

                    NewBaPersonID = 0;
                }
                else if (qryBaPerson.Count == 0)
                {
                    // no person selected
                    throw new KissCancelException(KissMsg.GetMLMessage(Name, "NoPersonSelectedForNewCase", "Es wurde keine Person ausgewählt für einen neuen Eintrag."));
                }
                else
                {
                    // apply selected person (not adding a new person)
                    NewBaPersonID = Convert.ToInt32(qryBaPerson["BaPersonID"]);
                }

                // call any additional-check methods
                Additional_Check();

                // start new transaction
                Session.BeginTransaction();

                try
                {
                    // create new history version either way
                    DBUtil.NewHistoryVersion();

                    if (tabPerson.IsTabSelected(tpgPersonErfassen))
                    {
                        // setup default values if not yet entered
                        // language
                        if (DBUtil.IsEmpty(qryNeuePerson["SprachCode"]))
                        {
                            // apply language from current user
                            qryNeuePerson["SprachCode"] = Session.User.LanguageCode;
                        }

                        // set modifier/modified
                        qryNeuePerson.SetModifierModified();

                        // insert new person
                        if (!qryNeuePerson.Post())
                        {
                            // error saving changes
                            throw new KissCancelException(KissMsg.GetMLMessage(Name, "ErrorSavingNewPersonData", "Es ist ein Fehler beim Speichern der Daten aufgetreten."));
                        }

                        NewBaPersonID = Convert.ToInt32(qryNeuePerson["BaPersonID"]);
                        DBUtil.ExecSQL(@"EXEC dbo.spKbKostenstelleAnlegen {0}, {1}", NewBaPersonID, Session.User.UserID);
                    }

                    // call any additional-save methods
                    // TODO: Overriding this method can cause some dialogs and other problems here with the open transaction!
                    Additional_Save();

                    // set dialog result
                    DialogResult = DialogResult.OK;

                    // success, do commit changes
                    Session.Commit();

                    //jump to new fall gemäss Implementation
                    JumpToNewFall();
                }
                catch (Exception ex)
                {
                    // undo changes if we still have a transaction (could be closed in Additional_Save() call)
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }

                    // throw exception further on
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                // check type of exception (errorexception is cancelexception, too... :/)
                if ((ex is KissCancelException || ex is KissInfoException) &&
                    ex.Message != null &&
                    !(ex is KissErrorException))
                {
                    // show message from info/cancel (messages with no text as string.Empty will not be shown!)
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        // focus the control if it's set
                        var ctlFocus = ((KissCancelException)ex).ctlFocus;
                        if (ctlFocus != null)
                        {
                            ctlFocus.Focus();
                        }

                        // show message if defined
                        KissMsg.ShowInfo(ex.Message);
                    }
                }
                else
                {
                    // show message
                    KissMsg.ShowError(Name,
                                      "ErrorCreateNewPerson",
                                      "Es ist ein Fehler beim Erstellen der neuen Person aufgetreten.",
                                      ex.Message,
                                      ex.InnerException);
                }
            }
        }

        

        private void btnResetSearch_Click(object sender, System.EventArgs e)
        {
            NeueSuche();
        }

        private void DlgPersonSucheNeu_Activated(Object sender, System.EventArgs e)
        {
            edtSucheName.Focus();
        }

        private void DlgPersonSucheNeu_Load(object sender, System.EventArgs e)
        {
            // check if designer
            if (DesignMode)
            {
                // do nothing
                return;
            }

            // select first tab
            tabPerson.SelectTab(tpgPersonSuchen);

            // setup tabs
            tpgPersonSuchen.Title = KissMsg.GetMLMessage(this.Name, "TabPersonSuchen", "Person suchen");
            tpgPersonErfassen.Title = KissMsg.GetMLMessage(this.Name, "TabPersonErfassen", "Person erfassen");

            // apply table name (only if not designer due to gridViews)
            if (!this.DesignMode)
            {
                qryBaPerson.TableName = "BaPerson";
                qryNeuePerson.TableName = "BaPerson";
            }

            // right management
            qryNeuePerson.ApplyUserRights(this.Name);
            qryBaPerson.ApplyUserRights(this.Name);
            lblKeineBerechtigung.Visible = !qryNeuePerson.CanInsert;

            // Neue Person vorbereiten
            qryNeuePerson.Fill(@"
                SELECT *
                FROM dbo.BaPerson WITH (READUNCOMMITTED)
                WHERE 1=2;");

            if (DBUtil.UserHasRight(this.Name, "I"))
            {
                qryNeuePerson.Insert();
                qryNeuePerson.SetCreator();
                qryNeuePerson.RowModified = true;
            }
            else
            {
                qryNeuePerson.CanInsert = false;
                panBerechtigung.Visible = true;
            }

            // fill data without any row
            FillPersonen(true);
            qryBaPerson.EnableBoundFields(false);

            // start with search mode
            if (!_doManuallyNewSearch)
            {
                // init a new search if necessary
                tabListeSuchen.SelectedTabIndex = 1;
                NeueSuche();

                // reset flag
                _doManuallyNewSearch = false;
            }

            // setup fields
            _doRunSearch = true;
        }

        private void Edit_UserModifiedFld(Object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // check if need to progress command
            if (_isInPLZOrtMethod)
            {
                return;
            }

            try
            {
                // setup flag
                _isInPLZOrtMethod = true;

                BaseEdit edit = (BaseEdit)sender;

                if (!Utils.isSchweiz(edtSucheNationalitaet.EditValue))
                {
                    return;
                }

                if (DBUtil.IsEmpty(edit.Text))
                {
                    edtSuchePLZ.EditValue = "";
                    edtSucheOrt.EditValue = "";
                    edtSucheNationalitaet.EditValue = DBNull.Value;
                    return;
                }

                DlgAuswahl dlg = new DlgAuswahl();

                if (edit.Name.IndexOf("PLZ") != -1)
                {
                    e.Cancel = !dlg.PLZSearch(edit.Text);
                }
                else
                {
                    e.Cancel = !dlg.OrtSearch(edit.Text);
                }

                if (!e.Cancel)
                {
                    edtSuchePLZ.EditValue = dlg["Value1"].ToString();
                    edtSucheOrt.EditValue = dlg["Text"].ToString();
                    edtSucheNationalitaet.EditValue = 147; // Schweiz
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorPLZOrtFields", "Fehler in der Verarbeitung.", "Error in Edit_UserModifiedFld:", ex);
            }
            finally
            {
                // reset flag
                _isInPLZOrtMethod = false;
            }
        }

        private void edtSucheOrt_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            Edit_UserModifiedFld(sender, e);
        }

        private void edtSuchePLZ_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            Edit_UserModifiedFld(sender, e);
        }

        private void tabListeSuchen_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // do search if from tabSuche
            if (_doRunSearch && tabListeSuchen.IsTabSelected(tpgListe))
            {
                // load searched data
                FillPersonen(false);
            }
        }

        private void tabPerson_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabPerson.SelectedTabIndex == 1)
            {
                if (_firstTime)
                {
                    qryNeuePerson["Name"] = edtSucheName.EditValue;
                    qryNeuePerson["Vorname"] = edtSucheVorname.EditValue;
                    qryNeuePerson["VersichertenNummer"] = edtSucheVersichertenNr.EditValue;
                    qryNeuePerson["NationalitaetCode"] = edtSucheNationalitaet.EditValue;
                    qryNeuePerson["Geburtsdatum"] = edtSucheGeburtVon.EditValue;

                    _firstTime = false;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            if (tabPerson.IsTabSelected(tpgPersonSuchen) && tabListeSuchen.IsTabSelected(tpgSuchen))
            {
                // run search
                FillPersonen(false);
            }
            else
            {
                // do new search
                tabPerson.SelectTab(tpgPersonSuchen);
                tabListeSuchen.SelectTab(tpgSuchen);
                NeueSuche();
            }
        }

        public void SetupSearch(string nachName, string vorName, string plzWohnsitz, string ortWohnsitz)
        {
            // setup flag to prevent overwriting settings
            _doManuallyNewSearch = true;

            // init new search
            tabListeSuchen.SelectedTabIndex = 1;
            NeueSuche();

            // fill data into search
            edtSucheName.Text = nachName;
            edtSucheVorname.Text = vorName;
            edtSuchePLZ.Text = plzWohnsitz;
            edtSucheOrt.Text = ortWohnsitz;
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // check if designer
            if (DesignMode)
            {
                // do not continue
                return;
            }

            // load bigger LOVs only once
            edtNationalitaetNeu.LoadQuery((SqlQuery)edtSucheNationalitaet.Properties.DataSource);
        }

        #endregion

        #region Private Methods

        private void FillPersonen(bool noRows)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Person
                string sqlStatement = string.Format(@"
                    DECLARE @UserID INT;
                    DECLARE @LanguageCode INT;

                    SET @UserID = {0};
                    SET @LanguageCode = {1};

                    SELECT DISTINCT
                           PRS.*,
                           PLZOrt            = PRS.WohnsitzPLZOrt,
                           [Alter]           = PRS.[Alter],
                           Geschlecht        = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
                           GeschlechtText    = dbo.fnGetLOVMLText('Geschlecht', PRS.GeschlechtCode, @LanguageCode),
                           NationalitaetText = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
                           WohnsitzPostfach  = dbo.fnBaGetPostfachText(NULL, PRS.WohnsitzPostfach, PRS.WohnsitzPostfachOhneNr, @LanguageCode),
                           WohnsitzLandText  = dbo.fnLandMLText(PRS.WohnsitzBaLandID, @LanguageCode),
                           KL                = CONVERT(BIT, CASE
                                                              WHEN ISNULL(LEI_FV.FaLeistungID, -1) > 0 THEN 1
                                                              ELSE 0
                                                            END),
                           SAR               = dbo.fnGetLastFirstName(LEI_FV.UserID, NULL, NULL)
                    FROM dbo.vwPerson          PRS    WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.FaLeistung LEI_FV WITH (READUNCOMMITTED) ON LEI_FV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2)
                    WHERE 1 = 1", Session.User.UserID, Session.User.LanguageCode);

                if (noRows)
                {
                    sqlStatement += " AND 1=2 ";
                    qryBaPerson.Fill(sqlStatement);
                    return;
                }

                // Name
                if (edtSucheName.Text != "")
                {
                    if (chkSucheAehnlichePers.Checked)
                    {
                        sqlStatement += string.Format(" AND (SOUNDEX(PRS.Name) = SOUNDEX({0}) OR PRS.Name LIKE {0} + '%')", DBUtil.SqlLiteral(edtSucheName.Text));
                    }
                    else
                    {
                        sqlStatement += string.Format(" AND PRS.Name LIKE {0} + '%'", DBUtil.SqlLiteralLike(edtSucheName.Text));
                    }
                }

                // Vorname
                if (edtSucheVorname.Text != "")
                {
                    if (chkSucheAehnlichePers.Checked)
                    {
                        sqlStatement += string.Format(" AND (SOUNDEX(PRS.Vorname) = SOUNDEX({0}) OR PRS.Vorname LIKE {0} + '%')", DBUtil.SqlLiteral(edtSucheVorname.Text));
                    }
                    else
                    {
                        sqlStatement += string.Format(" AND PRS.Vorname LIKE {0} + '%'", DBUtil.SqlLiteralLike(edtSucheVorname.Text));
                    }
                }

                // Strasse
                if (edtSucheStrasse.Text != "")
                {
                    sqlStatement += string.Format(" AND PRS.WohnsitzStrasse LIKE {0} + '%'", DBUtil.SqlLiteralLike(edtSucheStrasse.Text));
                }

                // PLZ
                if (edtSuchePLZ.Text != "")
                {
                    sqlStatement += string.Format(" AND PRS.WohnsitzPLZ LIKE {0} + '%'", DBUtil.SqlLiteralLike(edtSuchePLZ.Text));
                }

                // Ort
                if (edtSucheOrt.Text != "")
                {
                    sqlStatement += string.Format(" AND PRS.WohnsitzOrt LIKE {0} + '%'", DBUtil.SqlLiteralLike(edtSucheOrt.Text));
                }

                // Geburt von
                if (!DBUtil.IsEmpty(edtSucheGeburtVon.EditValue))
                {
                    sqlStatement += string.Format(" AND PRS.Geburtsdatum >= {0}", DBUtil.SqlLiteral(edtSucheGeburtVon.DateTime));
                }

                // Geburt bis
                if (!DBUtil.IsEmpty(edtSucheGeburtBis.EditValue))
                {
                    sqlStatement += string.Format(" AND PRS.Geburtsdatum <= {0}", DBUtil.SqlLiteral(edtSucheGeburtBis.DateTime));
                }

                // Nationalitaet
                if (!DBUtil.IsEmpty(edtSucheNationalitaet.EditValue))
                {
                    sqlStatement += string.Format(" AND PRS.NationalitaetCode = {0}", DBUtil.SqlLiteral(edtSucheNationalitaet.EditValue));
                }

                // VersicherungsNr
                if (edtSucheVersichertenNr.Text != "")
                {
                    sqlStatement += string.Format(" AND PRS.VersichertenNummer LIKE {0} + '%'", DBUtil.SqlLiteralLike(edtSucheVersichertenNr.Text));
                }

                // nur Klient (Fallträger)
                if (chkSucheNurKlient.Checked)
                {
                    sqlStatement += @" AND ISNULL(LEI_FV.FaLeistungID, -1) > 0 ";
                }

                sqlStatement += " ORDER BY Name, Vorname, Geburtsdatum";

                // run search
                qryBaPerson.Fill(sqlStatement);

                // setup fields
                _doRunSearch = false;

                tabListeSuchen.SelectTab(tpgListe);
                grdListe.Focus();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorFillPersons", "Fehler beim Suchen der Daten.", ex);
            }
            finally
            {
                // setup labels
                lblRowCount.Text = string.Format("{0}: {1}", _rowCountMLText, qryBaPerson.Count);

                // setup fields
                _doRunSearch = true;

                // setup cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void NeueSuche()
        {
            foreach (Control c in KiSS4.Gui.UtilsGui.AllControls(tabListeSuchen))
            {
                if (c is BaseEdit)
                {
                    ((BaseEdit)c).EditValue = null;
                }
            }

            chkSucheAehnlichePers.Checked = true;

            edtSucheName.Focus();
        }

        #endregion

        #endregion
    }
}