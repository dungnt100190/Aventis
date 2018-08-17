using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.PI
{
    public class CtlPersonenStamm : Common.KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlPersonenStamm";
        private readonly string _mlRowCount = KissMsg.GetMLMessage(CLASSNAME, "RowCountText", "Anzahl Datensätze");

        #endregion

        #region Private Fields

        private CtlBaStammdaten _ctlBaStammdaten = null; // the detailcontrol for stammdaten of a person
        private KiSS4.Gui.KissButton btnFallInfo;
        private KissButton btnNewSearch;
        private KiSS4.Gui.KissButton btnVerlauf;
        private KiSS4.Gui.KissCheckEdit chkSucheKL;
        private KissCheckEdit chkSucheNurSerienbrief;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colFruehererName;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colKGS;
        private DevExpress.XtraGrid.Columns.GridColumn colKL;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoFuehrung;
        private DevExpress.XtraGrid.Columns.GridColumn colKST;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPersGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissCalcEdit edtSucheBaPersonID;
        private KiSS4.Gui.KissDateEdit edtSucheGeburtBis;
        private KiSS4.Gui.KissDateEdit edtSucheGeburtVon;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissLookUpEdit edtSucheNationalitaet;
        private KiSS4.Gui.KissTextEdit edtSucheOrt;
        private KiSS4.Gui.KissTextEdit edtSuchePLZ;
        private KiSS4.Gui.KissTextEdit edtSucheStrasse;
        private KissTextEdit edtSucheTelefon;
        private KiSS4.Gui.KissTextEdit edtSucheVersichertenNummer;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissGrid grdListe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblSucheBaPersonID;
        private KiSS4.Gui.KissLabel lblSucheGeburtBis;
        private KiSS4.Gui.KissLabel lblSucheGeburtsdatum;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheNationalitaet;
        private KiSS4.Gui.KissLabel lblSuchePLZOrt;
        private KiSS4.Gui.KissLabel lblSucheStrasse;
        private KissLabel lblSucheTelefon;
        private KiSS4.Gui.KissLabel lblSucheVersichertenNummer;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private System.Windows.Forms.Panel pnlCtlBaStammdaten;
        private System.Windows.Forms.Panel pnlTitel;
        private KiSS4.DB.SqlQuery qryEmpty;
        private KiSS4.Gui.KissTabControlEx tabListeControl;
        private SharpLibrary.WinControls.TabPageEx tpgDetails;
        private SharpLibrary.WinControls.TabPageEx tpgUebersicht;

        #endregion

        #endregion

        #region Constructors

        public CtlPersonenStamm()
        {
            // init control
            InitializeComponent();

            // apply lov-filter
            Common.PI.BaUtils.ApplyLOVBaLand(edtSucheNationalitaet);

            // create new CtlBaStammdaten and add it to the panel
            _ctlBaStammdaten = new CtlBaStammdaten();
            pnlCtlBaStammdaten.Controls.Add(_ctlBaStammdaten);
            _ctlBaStammdaten.Dock = System.Windows.Forms.DockStyle.Fill;

            // set fill-timeout higher due to huge amount of data
            _ctlBaStammdaten.GetQuery.FillTimeOut = 240; // 4min

            // set rights on query from ctlBaStammdaten
            _ctlBaStammdaten.GetQuery.ApplyUserRights("FrmPersonenStamm");

            // set active query
            ActiveSQLQuery = _ctlBaStammdaten.GetQuery;
            _ctlBaStammdaten.GetQuery.HostControl = this;

            // set datasources
            ctlGotoFall.DataSource = _ctlBaStammdaten.GetQuery;
            grdListe.DataSource = _ctlBaStammdaten.GetQuery;

            // apply icon
            picTitel.Image = KissImageList.GetSmallImage(133);

            // init ctlBaStammdaten
            _ctlBaStammdaten.Init(null, null, -1, -1, false);

            // if someone is not allowed to change anything, we do not save changes
            if (!ActiveSQLQuery.CanInsert && !ActiveSQLQuery.CanUpdate && !ActiveSQLQuery.CanDelete)
            {
                // set batchupdate = true to prevent try saving changes every time even if not allowed
                ActiveSQLQuery.BatchUpdate = true;
            }

            // set proper tabs
            tabListeControl.SelectedTabIndex = 0;
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlPersonenStamm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tabListeControl = new KiSS4.Gui.KissTabControlEx();
            this.tpgDetails = new SharpLibrary.WinControls.TabPageEx();
            this.pnlCtlBaStammdaten = new System.Windows.Forms.Panel();
            this.tpgUebersicht = new SharpLibrary.WinControls.TabPageEx();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.grdListe = new KiSS4.Gui.KissGrid();
            this.qryEmpty = new KiSS4.DB.SqlQuery(this.components);
            this.grvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFruehererName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKGS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoFuehrung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheStrasse = new KiSS4.Gui.KissLabel();
            this.edtSucheStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblSuchePLZOrt = new KiSS4.Gui.KissLabel();
            this.edtSuchePLZ = new KiSS4.Gui.KissTextEdit();
            this.edtSucheOrt = new KiSS4.Gui.KissTextEdit();
            this.lblSucheBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtSucheBaPersonID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtBis = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheNationalitaet = new KiSS4.Gui.KissLabel();
            this.edtSucheNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheVersichertenNummer = new KiSS4.Gui.KissLabel();
            this.edtSucheVersichertenNummer = new KiSS4.Gui.KissTextEdit();
            this.chkSucheKL = new KiSS4.Gui.KissCheckEdit();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.btnFallInfo = new KiSS4.Gui.KissButton();
            this.btnVerlauf = new KiSS4.Gui.KissButton();
            this.chkSucheNurSerienbrief = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblSucheTelefon = new KiSS4.Gui.KissLabel();
            this.btnNewSearch = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tabListeControl.SuspendLayout();
            this.tpgDetails.SuspendLayout();
            this.tpgUebersicht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurSerienbrief.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTelefon)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(900, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(959, 445);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdListe);
            this.tpgListe.Size = new System.Drawing.Size(947, 407);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.btnNewSearch);
            this.tpgSuchen.Controls.Add(this.edtSucheTelefon);
            this.tpgSuchen.Controls.Add(this.lblSucheTelefon);
            this.tpgSuchen.Controls.Add(this.chkSucheNurSerienbrief);
            this.tpgSuchen.Controls.Add(this.chkSucheKL);
            this.tpgSuchen.Controls.Add(this.edtSucheVersichertenNummer);
            this.tpgSuchen.Controls.Add(this.lblSucheVersichertenNummer);
            this.tpgSuchen.Controls.Add(this.edtSucheNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblSucheNationalitaet);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtsdatum);
            this.tpgSuchen.Controls.Add(this.edtSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.lblSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtSucheOrt);
            this.tpgSuchen.Controls.Add(this.edtSuchePLZ);
            this.tpgSuchen.Controls.Add(this.lblSuchePLZOrt);
            this.tpgSuchen.Controls.Add(this.edtSucheStrasse);
            this.tpgSuchen.Controls.Add(this.lblSucheStrasse);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(947, 407);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePLZOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtsdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVersichertenNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVersichertenNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheKL, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurSerienbrief, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTelefon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTelefon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnNewSearch, 0);
            //
            // pnlTitel
            //
            this.pnlTitel.Controls.Add(this.picTitel);
            this.pnlTitel.Controls.Add(this.lblTitel);
            this.pnlTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitel.Location = new System.Drawing.Point(0, 0);
            this.pnlTitel.Name = "pnlTitel";
            this.pnlTitel.Size = new System.Drawing.Size(971, 30);
            this.pnlTitel.TabIndex = 0;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(930, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Stammdaten";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // tabListeControl
            //
            this.tabListeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabListeControl.Controls.Add(this.tpgDetails);
            this.tabListeControl.Controls.Add(this.tpgUebersicht);
            this.tabListeControl.Location = new System.Drawing.Point(0, 29);
            this.tabListeControl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.tabListeControl.Name = "tabListeControl";
            this.tabListeControl.ShowFixedWidthTooltip = true;
            this.tabListeControl.Size = new System.Drawing.Size(971, 483);
            this.tabListeControl.TabIndex = 1;
            this.tabListeControl.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgUebersicht,
            this.tpgDetails});
            this.tabListeControl.TabsLineColor = System.Drawing.Color.Black;
            this.tabListeControl.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabListeControl.Text = "kissTabControlEx1";
            this.tabListeControl.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabListeControl_SelectedTabChanged);
            this.tabListeControl.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabListeControl_SelectedTabChanging);
            //
            // tpgDetails
            //
            this.tpgDetails.Controls.Add(this.pnlCtlBaStammdaten);
            this.tpgDetails.Location = new System.Drawing.Point(6, 6);
            this.tpgDetails.Name = "tpgDetails";
            this.tpgDetails.Size = new System.Drawing.Size(959, 445);
            this.tpgDetails.TabIndex = 1;
            this.tpgDetails.Title = "Details";
            //
            // pnlCtlBaStammdaten
            //
            this.pnlCtlBaStammdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCtlBaStammdaten.Location = new System.Drawing.Point(3, 3);
            this.pnlCtlBaStammdaten.Name = "pnlCtlBaStammdaten";
            this.pnlCtlBaStammdaten.Size = new System.Drawing.Size(953, 439);
            this.pnlCtlBaStammdaten.TabIndex = 0;
            //
            // tpgUebersicht
            //
            this.tpgUebersicht.Controls.Add(this.lblRowCount);
            this.tpgUebersicht.Controls.Add(this.tabControlSearch);
            this.tpgUebersicht.Location = new System.Drawing.Point(6, 6);
            this.tpgUebersicht.Name = "tpgUebersicht";
            this.tpgUebersicht.Size = new System.Drawing.Size(959, 445);
            this.tpgUebersicht.TabIndex = 0;
            this.tpgUebersicht.Title = "Übersicht";
            this.tpgUebersicht.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tpgUebersicht.Controls.SetChildIndex(this.lblRowCount, 0);
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Location = new System.Drawing.Point(717, 425);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(236, 15);
            this.lblRowCount.TabIndex = 2;
            this.lblRowCount.Text = "<RowCount>";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            //
            // grdListe
            //
            this.grdListe.DataSource = this.qryEmpty;
            this.grdListe.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdListe.EmbeddedNavigator.Name = "gridList.EmbeddedNavigator";
            this.grdListe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe.Location = new System.Drawing.Point(0, 0);
            this.grdListe.MainView = this.grvListe;
            this.grdListe.Name = "grdListe";
            this.grdListe.Size = new System.Drawing.Size(947, 407);
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
            this.grvListe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.grvListe.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvListe.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.grvListe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.OddRow.Options.UseFont = true;
            this.grvListe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.Row.Options.UseBackColor = true;
            this.grvListe.Appearance.Row.Options.UseFont = true;
            this.grvListe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKL,
            this.colBaPersonID,
            this.colSAR,
            this.colName,
            this.colFruehererName,
            this.colVorname,
            this.colKST,
            this.colKGS,
            this.colKontoFuehrung,
            this.colStrasse,
            this.colOrt,
            this.colGeschlecht,
            this.colAlter,
            this.colPersGeburtsdatum,
            this.colVersichertenNummer,
            this.colTelefon,
            this.colEmail});
            this.grvListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe.GridControl = this.grdListe;
            this.grvListe.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvListe.Name = "grvListe";
            this.grvListe.OptionsBehavior.Editable = false;
            this.grvListe.OptionsCustomization.AllowFilter = false;
            this.grvListe.OptionsFilter.UseNewCustomFilterDialog = true;
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
            // colBaPersonID
            //
            this.colBaPersonID.Caption = "ID";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 1;
            this.colBaPersonID.Width = 63;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 2;
            this.colSAR.Width = 100;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 100;
            //
            // colFruehererName
            //
            this.colFruehererName.Caption = "Früherer Name";
            this.colFruehererName.FieldName = "FruehererName";
            this.colFruehererName.Name = "colFruehererName";
            this.colFruehererName.Visible = true;
            this.colFruehererName.VisibleIndex = 4;
            this.colFruehererName.Width = 100;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 5;
            this.colVorname.Width = 100;
            //
            // colKST
            //
            this.colKST.Caption = "KST";
            this.colKST.FieldName = "KST";
            this.colKST.Name = "colKST";
            this.colKST.Visible = true;
            this.colKST.VisibleIndex = 6;
            this.colKST.Width = 100;
            //
            // colKGS
            //
            this.colKGS.Caption = "KGS";
            this.colKGS.FieldName = "KGS";
            this.colKGS.Name = "colKGS";
            this.colKGS.Visible = true;
            this.colKGS.VisibleIndex = 7;
            this.colKGS.Width = 100;
            //
            // colKontoFuehrung
            //
            this.colKontoFuehrung.Caption = "Kontoführung";
            this.colKontoFuehrung.FieldName = "KontoFuehrung";
            this.colKontoFuehrung.Name = "colKontoFuehrung";
            this.colKontoFuehrung.Visible = true;
            this.colKontoFuehrung.VisibleIndex = 8;
            this.colKontoFuehrung.Width = 100;
            //
            // colStrasse
            //
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 9;
            this.colStrasse.Width = 100;
            //
            // colOrt
            //
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "PLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 10;
            this.colOrt.Width = 100;
            //
            // colGeschlecht
            //
            this.colGeschlecht.Caption = "m/w";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 11;
            this.colGeschlecht.Width = 34;
            //
            // colAlter
            //
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 12;
            this.colAlter.Width = 38;
            //
            // colPersGeburtsdatum
            //
            this.colPersGeburtsdatum.Caption = "Geb.Dat.";
            this.colPersGeburtsdatum.FieldName = "Geburtsdatum";
            this.colPersGeburtsdatum.Name = "colPersGeburtsdatum";
            this.colPersGeburtsdatum.Visible = true;
            this.colPersGeburtsdatum.VisibleIndex = 13;
            this.colPersGeburtsdatum.Width = 80;
            //
            // colVersichertenNummer
            //
            this.colVersichertenNummer.Caption = "Vers.-Nr.";
            this.colVersichertenNummer.FieldName = "Versichertennummer";
            this.colVersichertenNummer.Name = "colVersichertenNummer";
            this.colVersichertenNummer.Visible = true;
            this.colVersichertenNummer.VisibleIndex = 14;
            this.colVersichertenNummer.Width = 90;
            //
            // colTelefon
            //
            this.colTelefon.Caption = "Telefon";
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 15;
            this.colTelefon.Width = 150;
            //
            // colEmail
            //
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "EMail";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 16;
            this.colEmail.Width = 100;
            //
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(30, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(80, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // edtSucheName
            //
            this.edtSucheName.Location = new System.Drawing.Point(116, 40);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Properties.Name = "editNameX.Properties";
            this.edtSucheName.Size = new System.Drawing.Size(224, 24);
            this.edtSucheName.TabIndex = 2;
            //
            // lblSucheVorname
            //
            this.lblSucheVorname.Location = new System.Drawing.Point(30, 70);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(80, 24);
            this.lblSucheVorname.TabIndex = 3;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            //
            // edtSucheVorname
            //
            this.edtSucheVorname.Location = new System.Drawing.Point(116, 70);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Properties.Name = "editVornameX.Properties";
            this.edtSucheVorname.Size = new System.Drawing.Size(224, 24);
            this.edtSucheVorname.TabIndex = 4;
            //
            // lblSucheStrasse
            //
            this.lblSucheStrasse.Location = new System.Drawing.Point(30, 100);
            this.lblSucheStrasse.Name = "lblSucheStrasse";
            this.lblSucheStrasse.Size = new System.Drawing.Size(80, 24);
            this.lblSucheStrasse.TabIndex = 5;
            this.lblSucheStrasse.Text = "Strasse";
            this.lblSucheStrasse.UseCompatibleTextRendering = true;
            //
            // edtSucheStrasse
            //
            this.edtSucheStrasse.Location = new System.Drawing.Point(116, 100);
            this.edtSucheStrasse.Name = "edtSucheStrasse";
            this.edtSucheStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStrasse.Properties.Name = "editStrasseX.Properties";
            this.edtSucheStrasse.Size = new System.Drawing.Size(224, 24);
            this.edtSucheStrasse.TabIndex = 6;
            //
            // lblSuchePLZOrt
            //
            this.lblSuchePLZOrt.Location = new System.Drawing.Point(30, 130);
            this.lblSuchePLZOrt.Name = "lblSuchePLZOrt";
            this.lblSuchePLZOrt.Size = new System.Drawing.Size(80, 24);
            this.lblSuchePLZOrt.TabIndex = 7;
            this.lblSuchePLZOrt.Text = "PLZ / Ort";
            this.lblSuchePLZOrt.UseCompatibleTextRendering = true;
            //
            // edtSuchePLZ
            //
            this.edtSuchePLZ.Location = new System.Drawing.Point(116, 129);
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
            //
            // edtSucheOrt
            //
            this.edtSucheOrt.Location = new System.Drawing.Point(171, 129);
            this.edtSucheOrt.Name = "edtSucheOrt";
            this.edtSucheOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheOrt.Properties.Name = "editOrtX.Properties";
            this.edtSucheOrt.Size = new System.Drawing.Size(169, 24);
            this.edtSucheOrt.TabIndex = 9;
            //
            // lblSucheBaPersonID
            //
            this.lblSucheBaPersonID.Location = new System.Drawing.Point(370, 40);
            this.lblSucheBaPersonID.Name = "lblSucheBaPersonID";
            this.lblSucheBaPersonID.Size = new System.Drawing.Size(80, 24);
            this.lblSucheBaPersonID.TabIndex = 16;
            this.lblSucheBaPersonID.Text = "Personen-ID";
            this.lblSucheBaPersonID.UseCompatibleTextRendering = true;
            //
            // edtSucheBaPersonID
            //
            this.edtSucheBaPersonID.Location = new System.Drawing.Point(456, 40);
            this.edtSucheBaPersonID.Name = "edtSucheBaPersonID";
            this.edtSucheBaPersonID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBaPersonID.Properties.Name = "editDmgPersonIDX.Properties";
            this.edtSucheBaPersonID.Size = new System.Drawing.Size(95, 24);
            this.edtSucheBaPersonID.TabIndex = 17;
            //
            // lblSucheGeburtsdatum
            //
            this.lblSucheGeburtsdatum.Location = new System.Drawing.Point(29, 189);
            this.lblSucheGeburtsdatum.Name = "lblSucheGeburtsdatum";
            this.lblSucheGeburtsdatum.Size = new System.Drawing.Size(80, 24);
            this.lblSucheGeburtsdatum.TabIndex = 12;
            this.lblSucheGeburtsdatum.Text = "Geburtsdatum";
            this.lblSucheGeburtsdatum.UseCompatibleTextRendering = true;
            //
            // edtSucheGeburtVon
            //
            this.edtSucheGeburtVon.EditValue = null;
            this.edtSucheGeburtVon.Location = new System.Drawing.Point(116, 189);
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
            this.edtSucheGeburtVon.TabIndex = 13;
            //
            // lblSucheGeburtBis
            //
            this.lblSucheGeburtBis.Location = new System.Drawing.Point(217, 189);
            this.lblSucheGeburtBis.Name = "lblSucheGeburtBis";
            this.lblSucheGeburtBis.Size = new System.Drawing.Size(22, 24);
            this.lblSucheGeburtBis.TabIndex = 14;
            this.lblSucheGeburtBis.Text = "bis";
            this.lblSucheGeburtBis.UseCompatibleTextRendering = true;
            //
            // edtSucheGeburtBis
            //
            this.edtSucheGeburtBis.EditValue = null;
            this.edtSucheGeburtBis.Location = new System.Drawing.Point(245, 189);
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
            this.edtSucheGeburtBis.TabIndex = 15;
            //
            // lblSucheNationalitaet
            //
            this.lblSucheNationalitaet.Location = new System.Drawing.Point(370, 70);
            this.lblSucheNationalitaet.Name = "lblSucheNationalitaet";
            this.lblSucheNationalitaet.Size = new System.Drawing.Size(80, 24);
            this.lblSucheNationalitaet.TabIndex = 18;
            this.lblSucheNationalitaet.Text = "Nationalität";
            this.lblSucheNationalitaet.UseCompatibleTextRendering = true;
            //
            // edtSucheNationalitaet
            //
            this.edtSucheNationalitaet.Location = new System.Drawing.Point(456, 70);
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
            this.edtSucheNationalitaet.Properties.Name = "editNationalitaetX.Properties";
            this.edtSucheNationalitaet.Properties.NullText = "";
            this.edtSucheNationalitaet.Properties.ShowFooter = false;
            this.edtSucheNationalitaet.Properties.ShowHeader = false;
            this.edtSucheNationalitaet.Size = new System.Drawing.Size(224, 24);
            this.edtSucheNationalitaet.TabIndex = 19;
            //
            // lblSucheVersichertenNummer
            //
            this.lblSucheVersichertenNummer.Location = new System.Drawing.Point(370, 99);
            this.lblSucheVersichertenNummer.Name = "lblSucheVersichertenNummer";
            this.lblSucheVersichertenNummer.Size = new System.Drawing.Size(80, 24);
            this.lblSucheVersichertenNummer.TabIndex = 22;
            this.lblSucheVersichertenNummer.Text = "Vers.-Nr.";
            this.lblSucheVersichertenNummer.UseCompatibleTextRendering = true;
            //
            // edtSucheVersichertenNummer
            //
            this.edtSucheVersichertenNummer.Location = new System.Drawing.Point(456, 100);
            this.edtSucheVersichertenNummer.Name = "edtSucheVersichertenNummer";
            this.edtSucheVersichertenNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVersichertenNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVersichertenNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVersichertenNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVersichertenNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVersichertenNummer.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVersichertenNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVersichertenNummer.Properties.Name = "edtSucheVersichertenNummer.Properties";
            this.edtSucheVersichertenNummer.Size = new System.Drawing.Size(224, 24);
            this.edtSucheVersichertenNummer.TabIndex = 23;
            //
            // chkSucheKL
            //
            this.chkSucheKL.EditValue = false;
            this.chkSucheKL.Location = new System.Drawing.Point(456, 134);
            this.chkSucheKL.Name = "chkSucheKL";
            this.chkSucheKL.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheKL.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheKL.Properties.Caption = "Nur Klienten/innen";
            this.chkSucheKL.Properties.Name = "editFTX.Properties";
            this.chkSucheKL.Size = new System.Drawing.Size(224, 19);
            this.chkSucheKL.TabIndex = 24;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFall.AutoSize = true;
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.DataSource = this.qryEmpty;
            this.ctlGotoFall.Location = new System.Drawing.Point(601, 493);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.ShowToolTipsOnIcons = true;
            this.ctlGotoFall.Size = new System.Drawing.Size(169, 27);
            this.ctlGotoFall.TabIndex = 2;
            //
            // btnFallInfo
            //
            this.btnFallInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFallInfo.Enabled = false;
            this.btnFallInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFallInfo.Location = new System.Drawing.Point(776, 493);
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.Size = new System.Drawing.Size(90, 24);
            this.btnFallInfo.TabIndex = 3;
            this.btnFallInfo.Text = "Fallinfo";
            this.btnFallInfo.UseCompatibleTextRendering = true;
            this.btnFallInfo.UseVisualStyleBackColor = false;
            this.btnFallInfo.Click += new System.EventHandler(this.btnFallInfo_Click);
            //
            // btnVerlauf
            //
            this.btnVerlauf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerlauf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerlauf.Location = new System.Drawing.Point(875, 493);
            this.btnVerlauf.Name = "btnVerlauf";
            this.btnVerlauf.Size = new System.Drawing.Size(90, 24);
            this.btnVerlauf.TabIndex = 4;
            this.btnVerlauf.Text = "Verlauf";
            this.btnVerlauf.UseCompatibleTextRendering = true;
            this.btnVerlauf.UseVisualStyleBackColor = false;
            this.btnVerlauf.Click += new System.EventHandler(this.btnVerlauf_Click);
            //
            // chkSucheNurSerienbrief
            //
            this.chkSucheNurSerienbrief.EditValue = false;
            this.chkSucheNurSerienbrief.Location = new System.Drawing.Point(456, 159);
            this.chkSucheNurSerienbrief.Name = "chkSucheNurSerienbrief";
            this.chkSucheNurSerienbrief.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurSerienbrief.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurSerienbrief.Properties.Caption = "Nur Personen mit Serienbrief";
            this.chkSucheNurSerienbrief.Properties.Name = "editFTX.Properties";
            this.chkSucheNurSerienbrief.Size = new System.Drawing.Size(224, 19);
            this.chkSucheNurSerienbrief.TabIndex = 25;
            //
            // edtSucheTelefon
            //
            this.edtSucheTelefon.Location = new System.Drawing.Point(116, 159);
            this.edtSucheTelefon.Name = "edtSucheTelefon";
            this.edtSucheTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheTelefon.Properties.Name = "editStrasseX.Properties";
            this.edtSucheTelefon.Size = new System.Drawing.Size(224, 24);
            this.edtSucheTelefon.TabIndex = 11;
            //
            // lblSucheTelefon
            //
            this.lblSucheTelefon.Location = new System.Drawing.Point(30, 159);
            this.lblSucheTelefon.Name = "lblSucheTelefon";
            this.lblSucheTelefon.Size = new System.Drawing.Size(80, 24);
            this.lblSucheTelefon.TabIndex = 10;
            this.lblSucheTelefon.Text = "Telefon";
            this.lblSucheTelefon.UseCompatibleTextRendering = true;
            //
            // btnNewSearch
            //
            this.btnNewSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSearch.IconID = 4;
            this.btnNewSearch.Location = new System.Drawing.Point(914, 8);
            this.btnNewSearch.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.btnNewSearch.Name = "btnNewSearch";
            this.btnNewSearch.Size = new System.Drawing.Size(24, 24);
            this.btnNewSearch.TabIndex = 26;
            this.btnNewSearch.UseVisualStyleBackColor = false;
            this.btnNewSearch.Click += new System.EventHandler(this.btnNewSearch_Click);
            //
            // CtlPersonenStamm
            //
            this.Controls.Add(this.btnVerlauf);
            this.Controls.Add(this.btnFallInfo);
            this.Controls.Add(this.ctlGotoFall);
            this.Controls.Add(this.tabListeControl);
            this.Controls.Add(this.pnlTitel);
            this.Name = "CtlPersonenStamm";
            this.Size = new System.Drawing.Size(971, 524);
            this.Load += new System.EventHandler(this.CtlPersonenStamm_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tabListeControl.ResumeLayout(false);
            this.tpgDetails.ResumeLayout(false);
            this.tpgUebersicht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurSerienbrief.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTelefon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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

        private void btnFallInfo_Click(object sender, EventArgs e)
        {
            // ensure valid data
            if (!CanUseButton())
            {
                KissMsg.ShowInfo(Name, "CannotShowFallInfo", "Zu den aktuellen Daten können keine Fallinformationen angezeigt werden.");
                return;
            }

            // get current BaPersonID
            int baPersonID = Convert.ToInt32(_ctlBaStammdaten.GetQuery["BaPersonID"]);

            // open dialog if possible
            FormController.ShowDialogOnMain("DlgFallInfo", baPersonID);
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            // reset controls (won't be handled in NewSearch as we are on tpgSuchen)
            foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
            {
                if (ctl is BaseEdit)
                {
                    ((BaseEdit)ctl).EditValue = null;
                }
            }

            // start new search
            NewSearch();
        }

        private void btnVerlauf_Click(object sender, EventArgs e)
        {
            // ensure valid data
            if (!CanUseButton())
            {
                KissMsg.ShowInfo(Name, "CannotShowHistory", "Zu den aktuellen Daten kann kein Verlauf angezeigt werden.");
                return;
            }

            // check if we have any possible history versions
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT Count(1)
                    FROM dbo.Hist_BaPerson WITH (READUNCOMMITTED)
                    WHERE BaPersonID = {0}", ActiveSQLQuery["BaPersonID"])) < 1)
            {
                KissMsg.ShowInfo(Name, "NoHistoryVersionFound", "Es wurden keine historisierten Einträge gefunden, der Verlauf kann nicht angezeigt werden.");
                return;
            }

            try
            {
                // show dialog with versions (Image icon, string caption, int baPersonID)
                DlgPersonenStammHist dlg = new DlgPersonenStammHist(picTitel.Image, lblTitel.Text, Convert.ToInt32(this.ActiveSQLQuery["BaPersonID"]));
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorShowingHistory", "Fehler beim Anzeigen des Verlaufs.", ex);
            }
        }

        private void CtlPersonenStamm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ctlGotoFall.CtlGotoFall_KeyDown(sender, e);
        }

        private void CtlPersonenStamm_Load(object sender, System.EventArgs e)
        {
            // setup btnFallInfo depending on rights
            btnFallInfo.Enabled = DBUtil.UserHasRight("DlgFallInfo");

            // init
            _ctlBaStammdaten.GetQuery.EnableBoundFields(false);
            ctlGotoFall.ResetFallIcons();

            // setup query
            _ctlBaStammdaten.GetQuery.SelectStatement = @"
                DECLARE @UserID INT;
                DECLARE @LanguageCode INT;

                SET @UserID = {0};
                SET @LanguageCode = {1};

                SELECT PRS.*,
                       --
                       BaPersonIDVISNumber  = CONVERT(VARCHAR, PRS.BaPersonID) + ' ' + dbo.fnBaGetVISDossierNr(PRS.BaPersonID),
                       HeimatgemeindeName   = GDE.Name + ISNULL(' ' + GDE.Kanton, ''),
                       IVBerechtigungAktuellerStatusCode = dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, NULL, 0),
                       GesetzlicherWohnsitz = ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
                       Strasse              = ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, ''),
                       PLZOrt               = ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
                       [Alter]              = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
                       Geschlecht           = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
                       KL                   = CONVERT(BIT, CASE
                                                             WHEN EXISTS(SELECT TOP 1 1
                                                                         FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                                         WHERE BaPersonID = PRS.BaPersonID) THEN 1
                                                             ELSE 0
                                                           END),
                       SAR                  = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
                       KST                  = CASE
                                                WHEN LEI.UserID IS NULL THEN NULL
                                                ELSE dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName)
                                              END,
                       KGS                  = CASE
                                                WHEN LEI.UserID IS NULL THEN NULL
                                                ELSE dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, GETDATE(), ORG.OrgUnitID, 0, 1)
                                              END,
                       Telefon              = STUFF((SELECT CONVERT(VARCHAR(MAX), PHN.Phone)
                                                     FROM (SELECT Phone = ', ' + PRS.Telefon_P + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonPrivat', @LanguageCode) + ')'
                                                           WHERE PRS.Telefon_P IS NOT NULL

                                                           UNION ALL

                                                           SELECT Phone = ', ' + PRS.Telefon_G + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonGeschaeft', @LanguageCode) + ')'
                                                           WHERE PRS.Telefon_G IS NOT NULL

                                                           UNION ALL

                                                           SELECT Phone = ', ' + PRS.MobilTel + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonMobil', @LanguageCode) + ')'
                                                           WHERE PRS.MobilTel IS NOT NULL
                                                          ) AS PHN FOR XML PATH('')), 1, 2, '')
                FROM dbo.BaPerson           PRS  WITH (READUNCOMMITTED)
                  -- heimatort
                  LEFT JOIN dbo.BaGemeinde  GDE  WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID

                  -- wohnsitz
                  LEFT  JOIN dbo.BaAdresse  ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)

                  -- Fallfuehrung
                  LEFT  JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2)
                  LEFT  JOIN dbo.XOrgUnit   ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(LEI.UserID, 1))
                WHERE 1 = 1
                --- AND (PRS.Name LIKE {edtSucheName} + '%' OR PRS.FruehererName LIKE {edtSucheName} + '%')
                --- AND PRS.Vorname LIKE {edtSucheVorname} + '%'
                --- AND ADRW.Strasse LIKE {edtSucheStrasse} + '%'
                --- AND ADRW.PLZ LIKE {edtSuchePLZ} + '%'
                --- AND ADRW.Ort LIKE {edtSucheOrt} + '%'
                --- AND (PRS.Telefon_P LIKE {edtSucheTelefon} + '%' OR PRS.Telefon_G LIKE {edtSucheTelefon} + '%' OR PRS.MobilTel LIKE {edtSucheTelefon} + '%')
                --- AND PRS.BaPersonID = {edtSucheBaPersonID}
                --- AND PRS.Geburtsdatum >= {edtSucheGeburtVon}
                --- AND PRS.Geburtsdatum <= {edtSucheGeburtBis}
                --- AND PRS.NationalitaetCode = {edtSucheNationalitaet}
                --- AND PRS.VersichertenNummer LIKE '%'+{edtSucheVersichertenNummer}+'%'
                --- AND ({chkSucheKL} = 0 OR EXISTS(SELECT TOP 1 1 FROM dbo.FaLeistung WITH (READUNCOMMITTED) WHERE BaPersonID = PRS.BaPersonID))
                --- AND ({chkSucheNurSerienbrief} = 0 OR PRS.KeinSerienbrief = 0)
                ORDER BY Name, Vorname;";

            // attach manual events
            _ctlBaStammdaten.GetQuery.AfterFill += new EventHandler(qryBaPerson_AfterFill);
            _ctlBaStammdaten.GetQuery.PositionChanging += new EventHandler(qryBaPerson_PositionChanging);
            _ctlBaStammdaten.GetQuery.PositionChanged += new EventHandler(qryBaPerson_PositionChanged);

            // start new search without searching
            NewSearch();
        }

        private void qryBaPerson_AfterFill(object sender, EventArgs e)
        {
            // show amount of entries
            UpdateRowCount(false);
            ApplyRowIDsToControlStammdaten();
        }

        private void qryBaPerson_PositionChanged(object sender, EventArgs e)
        {
            // show form (due to an unknown bug, sometimes the form gets hidden behind other form)
            ShowForm();
            ApplyRowIDsToControlStammdaten();
        }

        private void qryBaPerson_PositionChanging(object sender, EventArgs e)
        {
            // if update is allowed, we need to save pending changes first
            if (ActiveSQLQuery.CanUpdate && !OnSaveData())
            {
                // cancel switching rows due to save-failure
                throw new KissCancelException();
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // show form (due to an unknown bug, sometimes the form gets hidden behind other form)
            ShowForm();
        }

        private void tabListeControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // show form (due to an unknown bug, sometimes the form gets hidden behind other form)
            ShowForm();
        }

        private void tabListeControl_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // check which tab is selected (last selected)
            if (tabListeControl.IsTabSelected(tpgUebersicht))
            {
                // check if we can switch
                if (DBUtil.IsEmpty(ActiveSQLQuery["BaPersonID"]) ||
                    ActiveSQLQuery.Count < 1 ||
                    !tabControlSearch.IsTabSelected(tpgListe))
                {
                    // do nothing to prevent error
                    e.Cancel = true;
                }
                else
                {
                    // do init only when user does switching tab to save ressources
                    // setup new values (use same id due to hidden relation fields)
                    _ctlBaStammdaten.InitPerRow(Convert.ToInt32(ActiveSQLQuery["BaPersonID"]), Convert.ToInt32(ActiveSQLQuery["BaPersonID"]));

                    // setup foreigner mode and colorize required fields
                    _ctlBaStammdaten.SetupForeignerMode();
                }
            }
            else if (tabListeControl.IsTabSelected(tpgDetails))
            {
                if (_ctlBaStammdaten.GetQuery.CanUpdate && !_ctlBaStammdaten.OnSaveData())
                {
                    KissMsg.ShowInfo(Name, "CannotSaveChangesOnPersonDetails", "Die Änderungen konnten nicht gespeichert werden.\r\n\r\nUm zurück zur Liste zu gelangen, korrigieren Sie zuerst die fehlerhaften Daten oder machen die Änderungen rückgängig.");

                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                case "ADRESSATID":
                    if (_ctlBaStammdaten.GetQuery.Count > 0)
                    {
                        return _ctlBaStammdaten.GetQuery["BaPersonID"];
                    }
                    break;
            }

            return base.GetContextValue(fieldName);
        }

        public override bool OnSaveData()
        {
            // check if we need and want to save changes
            if (!NeedToSaveChangesHandleUndo())
            {
                // no need to save any changes
                return true;
            }

            // let control handling save
            return _ctlBaStammdaten.OnSaveData();
        }

        public void SetSearchFocus()
        {
            // set focus
            edtSucheName.Focus();
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // reset count label
            UpdateRowCount(true);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // change tab
            tabListeControl.SelectedTabIndex = 0;

            // show amount of entries (reset)
            UpdateRowCount(true);

            // do search
            base.NewSearch();
            edtSucheName.Focus();
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtSucheName.EditValue) &&
                DBUtil.IsEmpty(edtSucheVorname.EditValue) &&
                DBUtil.IsEmpty(edtSucheStrasse.EditValue) &&
                DBUtil.IsEmpty(edtSuchePLZ.EditValue) &&
                DBUtil.IsEmpty(edtSucheOrt.EditValue) &&
                DBUtil.IsEmpty(edtSucheTelefon.EditValue) &&
                DBUtil.IsEmpty(edtSucheGeburtVon.EditValue) &&
                DBUtil.IsEmpty(edtSucheGeburtBis.EditValue) &&
                DBUtil.IsEmpty(edtSucheBaPersonID.EditValue) &&
                DBUtil.IsEmpty(edtSucheNationalitaet.EditValue) &&
                DBUtil.IsEmpty(edtSucheVersichertenNummer.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "Min1Suchfeld", "Mindestens ein Suchfeld muss ausgefüllt sein");
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME, "MissingValueCannotContinueWithSearching", "Missing value(s), cannot continue with searching.", KissMsgCode.MsgError));
            }

            // replace search parameters
            Object[] parameters = new Object[] { Session.User.UserID, Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void ApplyRowIDsToControlStammdaten()
        {
            int baPersonID = -1;

            if (ActiveSQLQuery != null &&
                ActiveSQLQuery.Count > 0 &&
                !DBUtil.IsEmpty(ActiveSQLQuery[DBO.BaPerson.BaPersonID]))
            {
                baPersonID = Convert.ToInt32(ActiveSQLQuery[DBO.BaPerson.BaPersonID]);
            }

            _ctlBaStammdaten.InitPerRowSetIDs(baPersonID, baPersonID);
        }

        private bool CanUseButton()
        {
            // ensure valid data
            return (tabControlSearch.IsTabSelected(tpgListe) &&
                    this.ActiveSQLQuery.Count > 0 &&
                    (!this.ActiveSQLQuery.CanUpdate || this.ActiveSQLQuery.Post()) &&
                     this.ActiveSQLQuery.Row.RowState != DataRowState.Added);
        }

        private bool NeedToSaveChangesHandleUndo()
        {
            if (ActiveSQLQuery == null || ActiveSQLQuery.Row == null)
            {
                // cannot save any data
                return false;
            }

            // check tpg, we do only want to save data if we are on detail tpg
            if (!tabListeControl.IsTabSelected(tpgDetails))
            {
                // undo changes without any notify
                ActiveSQLQuery.RowModified = false;
                ActiveSQLQuery.Row.AcceptChanges();

                // do not save any changes
                return false;
            }

            return true;
        }

        private void ShowForm()
        {
            // show form (due to an unknown bug, sometimes the form gets hidden behind other form)
            if (this.Parent != null && this.Parent is FrmPersonenStamm)
            {
                FormController.OpenForm("FrmPersonenStamm");
            }
        }

        private void UpdateRowCount(Boolean resetCounter)
        {
            // show amount of entries
            lblRowCount.Text = string.Format("{0}:  {1}", _mlRowCount, resetCounter ? 0 : _ctlBaStammdaten.GetQuery.Count);
        }

        #endregion

        #endregion
    }
}