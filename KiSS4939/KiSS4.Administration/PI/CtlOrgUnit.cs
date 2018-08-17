using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.XtraTreeList.Nodes;

namespace KiSS4.Administration.PI
{
    /// <summary>
    /// Control, used for CRUD orgunits
    /// </summary>
    public class CtlOrgUnit : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private bool _canUpdatePostfach = false;
        private bool _firstLoop = true;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAufklappen;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnUp;
        private KiSS4.Gui.KissButton btnZuklappen;
        private KissCheckEdit chkAdressePostfachOhneNr;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAbteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colMayDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colMayInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colMayUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOEItemTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUsers;
        private DevExpress.XtraGrid.Columns.GridColumn colUsersOE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVISArea;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colZLEStellvertreter;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colZLEVorgesetzter;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAbteilungBezeichnung;
        private KiSS4.Gui.KissTextEdit edtAdresseAbteilung;
        private KiSS4.Gui.KissTextEdit edtAdresseHausNr;
        private KiSS4.Gui.KissTextEdit edtAdresseKGS;
        private KiSS4.Gui.KissTextEdit edtAdresseOrt;
        private KiSS4.Gui.KissTextEdit edtAdressePLZ;
        private KissTextEdit edtAdressePostfach;
        private KiSS4.Gui.KissTextEdit edtAdresseStrasse;
        private KiSS4.Gui.KissTextEdit edtEmail;
        private KiSS4.Gui.KissTextEdit edtFax;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtInternet;
        private KiSS4.Gui.KissTextEdit edtKontoNr;
        private KiSS4.Gui.KissCalcEdit edtKostenstelle;
        private KiSS4.Gui.KissCalcEdit edtLeistungLohnlaufNr;
        private KiSS4.Gui.KissCalcEdit edtMandantennummer;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnit;
        private KiSS4.Gui.KissCalcEdit edtSammelkonto;
        private KiSS4.Gui.KissCalcEdit edtStundenLohnlaufNr;
        private KiSS4.Gui.KissTextEdit edtTelefon;
        private KiSS4.Gui.KissLookUpEdit edtUserProfil;
        private KiSS4.Gui.KissButtonEdit edtZLELeitung;
        private KiSS4.Gui.KissButtonEdit edtZLEStellvertreter;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblAbteilungBezeichnung;
        private KiSS4.Gui.KissLabel lblAdresseAbteilung;
        private KiSS4.Gui.KissLabel lblAdresseKGS;
        private KiSS4.Gui.KissLabel lblAdressePLZOrt;
        private KissLabel lblAdressePostfach;
        private KiSS4.Gui.KissLabel lblAdresseStrasseNr;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblInternet;
        private KiSS4.Gui.KissLabel lblKostenstelle;
        private KiSS4.Gui.KissLabel lblLeistungLohnlaufNr;
        private KiSS4.Gui.KissLabel lblMandantennummer;
        private KiSS4.Gui.KissLabel lblOEItemTyp;
        private KiSS4.Gui.KissLabel lblPCKonto;
        private KiSS4.Gui.KissLabel lblSammelkonto;
        private KiSS4.Gui.KissLabel lblStundenLohnlaufNr;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblText1;
        private KiSS4.Gui.KissLabel lblText2;
        private KiSS4.Gui.KissLabel lblUserProfile;
        private KiSS4.Gui.KissLabel lblZLELeitung;
        private KiSS4.Gui.KissLabel lblZLEStellvertreter;
        private KiSS4.Gui.KissRTFEdit memText1;
        private KiSS4.Gui.KissRTFEdit memText2;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.Panel panMitgliederAvailable;
        private System.Windows.Forms.Panel panMitgliederAvailableAddRemove;
        private System.Windows.Forms.Panel panMitgliederAvailableFilter;
        private System.Windows.Forms.TableLayoutPanel panMitgliederTable;
        private KiSS4.DB.SqlQuery qryKandidaten;
        private KiSS4.DB.SqlQuery qryOrgUnit;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTabControlEx tabOrgUnit;
        private SharpLibrary.WinControls.TabPageEx tpgAbteilung;
        private SharpLibrary.WinControls.TabPageEx tpgMitglieder;
        private SharpLibrary.WinControls.TabPageEx tpgTexte;
        private KiSS4.Gui.KissTree treOrgUnit;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlOrgUnit"/> class.
        /// </summary>
        public CtlOrgUnit()
        {
            this.InitializeComponent();

            // set dock to panel (due to strange behaviour in business desinger, we do it here)
            panContent.Dock = System.Windows.Forms.DockStyle.Fill;

            // show first tab
            tabOrgUnit.SelectedTabIndex = 0;

            // add icons to be displayed for org units
            treOrgUnit.SelectImageList = Gui.KissImageList.SmallImageList;

            // setup databinding
            SetupDataMember();
            SetupDataSource();

            // setup rights
            SetupRights();

            // load column edit for MemberCode in grdZugeteilt (Member, Guest, Representative)
            grdZugeteilt.View.Columns["OrgUnitMemberCode"].ColumnEdit = grdZugeteilt.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                SELECT LOV.Code,
                       Text = dbo.fnGetLOVMLText(LOV.LOVName, LOV.Code, {0})
                FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                WHERE LOV.LOVName = 'OrgUnitMember'
                  AND LOV.Code IN (2,3)
                ORDER BY LOV.SortKey", Session.User.LanguageCode));

            // load data
            qryOrgUnit.Fill(@"
                SELECT ORG.*,
                       OrgUnitTyp     = dbo.fnGetLOVMLText('OrganisationsEinheitTyp', ORG.OEItemTypCode, {0}),
                       Leitung        = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
                       Stellvertreter = dbo.fnGetLastFirstName(NULL, USR2.LastName, USR2.FirstName)
                FROM dbo.XOrgUnit     ORG  WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XUser USR  WITH (READUNCOMMITTED) ON USR.UserID = ORG.ChiefID
                  LEFT JOIN dbo.XUser USR2 WITH (READUNCOMMITTED) ON USR2.UserID = ORG.RepresentativeID
                ORDER BY ORG.ParentID, ORG.ParentPosition", Session.User.LanguageCode);

            // hide Texte-tpg
            tpgTexte.HideTab = true;

            // Laden der DropDown Box mit den Profilen.
            SqlQuery qry = Dokument.Utilities.GuiUtilities.GetSqlQueryXProfilesUserOrOrgUnit();

            edtUserProfil.LoadQuery(qry);
            edtUserProfil.Properties.DropDownRows = Math.Min(qry.Count, 14);
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
            this.panContent = new System.Windows.Forms.Panel();
            this.btnZuklappen = new KiSS4.Gui.KissButton();
            this.btnAufklappen = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.treOrgUnit = new KiSS4.Gui.KissTree();
            this.colAbteilung = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOEItemTyp = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colZLEVorgesetzter = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colZLEStellvertreter = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colVISArea = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryOrgUnit = new KiSS4.DB.SqlQuery(this.components);
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabOrgUnit = new KiSS4.Gui.KissTabControlEx();
            this.tpgAbteilung = new SharpLibrary.WinControls.TabPageEx();
            this.chkAdressePostfachOhneNr = new KiSS4.Gui.KissCheckEdit();
            this.edtAdressePostfach = new KiSS4.Gui.KissTextEdit();
            this.edtUserProfil = new KiSS4.Gui.KissLookUpEdit();
            this.lblUserProfile = new KiSS4.Gui.KissLabel();
            this.edtInternet = new KiSS4.Gui.KissTextEdit();
            this.lblInternet = new KiSS4.Gui.KissLabel();
            this.edtEmail = new KiSS4.Gui.KissTextEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.edtTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtAdresseOrt = new KiSS4.Gui.KissTextEdit();
            this.edtAdressePLZ = new KiSS4.Gui.KissTextEdit();
            this.lblAdressePLZOrt = new KiSS4.Gui.KissLabel();
            this.edtAdresseHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtAdresseStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtAdresseAbteilung = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseAbteilung = new KiSS4.Gui.KissLabel();
            this.edtAdresseKGS = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseKGS = new KiSS4.Gui.KissLabel();
            this.edtZLEStellvertreter = new KiSS4.Gui.KissButtonEdit();
            this.lblZLEStellvertreter = new KiSS4.Gui.KissLabel();
            this.edtZLELeitung = new KiSS4.Gui.KissButtonEdit();
            this.lblZLELeitung = new KiSS4.Gui.KissLabel();
            this.edtKontoNr = new KiSS4.Gui.KissTextEdit();
            this.lblPCKonto = new KiSS4.Gui.KissLabel();
            this.edtSammelkonto = new KiSS4.Gui.KissCalcEdit();
            this.lblSammelkonto = new KiSS4.Gui.KissLabel();
            this.edtLeistungLohnlaufNr = new KiSS4.Gui.KissCalcEdit();
            this.lblLeistungLohnlaufNr = new KiSS4.Gui.KissLabel();
            this.edtStundenLohnlaufNr = new KiSS4.Gui.KissCalcEdit();
            this.lblStundenLohnlaufNr = new KiSS4.Gui.KissLabel();
            this.edtMandantennummer = new KiSS4.Gui.KissCalcEdit();
            this.lblMandantennummer = new KiSS4.Gui.KissLabel();
            this.edtKostenstelle = new KiSS4.Gui.KissCalcEdit();
            this.lblKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtOrgUnit = new KiSS4.Gui.KissLookUpEdit();
            this.lblOEItemTyp = new KiSS4.Gui.KissLabel();
            this.edtAbteilungBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.lblAbteilungBezeichnung = new KiSS4.Gui.KissLabel();
            this.lblAdressePostfach = new KiSS4.Gui.KissLabel();
            this.tpgMitglieder = new SharpLibrary.WinControls.TabPageEx();
            this.panMitgliederTable = new System.Windows.Forms.TableLayoutPanel();
            this.panMitgliederAvailable = new System.Windows.Forms.Panel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryKandidaten = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panMitgliederAvailableFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsersOE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panMitgliederAvailableAddRemove = new System.Windows.Forms.Panel();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.tpgTexte = new SharpLibrary.WinControls.TabPageEx();
            this.memText2 = new KiSS4.Gui.KissRTFEdit();
            this.lblText2 = new KiSS4.Gui.KissLabel();
            this.memText1 = new KiSS4.Gui.KissRTFEdit();
            this.lblText1 = new KiSS4.Gui.KissLabel();
            this.panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).BeginInit();
            this.tabOrgUnit.SuspendLayout();
            this.tpgAbteilung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdressePostfachOhneNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInternet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInternet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseKGS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseKGS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZLEStellvertreter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZLEStellvertreter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZLELeitung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZLELeitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSammelkonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSammelkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungLohnlaufNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungLohnlaufNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenLohnlaufNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenLohnlaufNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantennummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOEItemTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilungBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilungBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePostfach)).BeginInit();
            this.tpgMitglieder.SuspendLayout();
            this.panMitgliederTable.SuspendLayout();
            this.panMitgliederAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            this.panMitgliederAvailableFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            this.panMitgliederAvailableAddRemove.SuspendLayout();
            this.tpgTexte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).BeginInit();
            this.SuspendLayout();
            //
            // panContent
            //
            this.panContent.Controls.Add(this.btnZuklappen);
            this.panContent.Controls.Add(this.btnAufklappen);
            this.panContent.Controls.Add(this.btnDown);
            this.panContent.Controls.Add(this.btnUp);
            this.panContent.Controls.Add(this.treOrgUnit);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(750, 222);
            this.panContent.TabIndex = 0;
            //
            // btnZuklappen
            //
            this.btnZuklappen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZuklappen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZuklappen.IconID = 71;
            this.btnZuklappen.Location = new System.Drawing.Point(716, 35);
            this.btnZuklappen.Name = "btnZuklappen";
            this.btnZuklappen.Size = new System.Drawing.Size(28, 24);
            this.btnZuklappen.TabIndex = 4;
            this.btnZuklappen.UseCompatibleTextRendering = true;
            this.btnZuklappen.UseVisualStyleBackColor = false;
            this.btnZuklappen.Click += new System.EventHandler(this.btnZuklappen_Click);
            //
            // btnAufklappen
            //
            this.btnAufklappen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAufklappen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAufklappen.IconID = 70;
            this.btnAufklappen.Location = new System.Drawing.Point(716, 5);
            this.btnAufklappen.Name = "btnAufklappen";
            this.btnAufklappen.Size = new System.Drawing.Size(28, 24);
            this.btnAufklappen.TabIndex = 3;
            this.btnAufklappen.UseCompatibleTextRendering = true;
            this.btnAufklappen.UseVisualStyleBackColor = false;
            this.btnAufklappen.Click += new System.EventHandler(this.btnAufklappen_Click);
            //
            // btnDown
            //
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(716, 192);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseCompatibleTextRendering = true;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.UpDown_Click);
            //
            // btnUp
            //
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(716, 162);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseCompatibleTextRendering = true;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.UpDown_Click);
            //
            // treOrgUnit
            //
            this.treOrgUnit.AllowSortTree = true;
            this.treOrgUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treOrgUnit.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.Empty.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.Empty.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treOrgUnit.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.EvenRow.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.EvenRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treOrgUnit.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.FooterPanel.Options.UseFont = true;
            this.treOrgUnit.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treOrgUnit.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.GroupButton.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.GroupButton.Options.UseFont = true;
            this.treOrgUnit.Appearance.GroupButton.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treOrgUnit.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treOrgUnit.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treOrgUnit.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.HeaderPanel.Options.UseFont = true;
            this.treOrgUnit.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treOrgUnit.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treOrgUnit.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treOrgUnit.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treOrgUnit.Appearance.HorzLine.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.HorzLine.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treOrgUnit.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.OddRow.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.OddRow.Options.UseFont = true;
            this.treOrgUnit.Appearance.OddRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treOrgUnit.Appearance.Preview.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.Preview.Options.UseFont = true;
            this.treOrgUnit.Appearance.Preview.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.Row.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.Row.Options.UseFont = true;
            this.treOrgUnit.Appearance.Row.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treOrgUnit.Appearance.TreeLine.ForeColor = System.Drawing.Color.Gray;
            this.treOrgUnit.Appearance.TreeLine.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.TreeLine.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treOrgUnit.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treOrgUnit.Appearance.VertLine.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.VertLine.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.VertLine.Options.UseTextOptions = true;
            this.treOrgUnit.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treOrgUnit.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colAbteilung,
            this.colOEItemTyp,
            this.colZLEVorgesetzter,
            this.colZLEStellvertreter,
            this.colVISArea});
            this.treOrgUnit.DataSource = this.qryOrgUnit;
            this.treOrgUnit.ImageIndexFieldName = "IconID";
            this.treOrgUnit.KeyFieldName = "OrgUnitID";
            this.treOrgUnit.Location = new System.Drawing.Point(3, 3);
            this.treOrgUnit.Name = "treOrgUnit";
            this.treOrgUnit.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treOrgUnit.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treOrgUnit.OptionsBehavior.Editable = false;
            this.treOrgUnit.OptionsBehavior.KeepSelectedOnClick = false;
            this.treOrgUnit.OptionsBehavior.MoveOnEdit = false;
            this.treOrgUnit.OptionsMenu.EnableColumnMenu = false;
            this.treOrgUnit.OptionsMenu.EnableFooterMenu = false;
            this.treOrgUnit.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treOrgUnit.OptionsView.AutoWidth = false;
            this.treOrgUnit.OptionsView.EnableAppearanceEvenRow = true;
            this.treOrgUnit.OptionsView.EnableAppearanceOddRow = true;
            this.treOrgUnit.OptionsView.ShowIndicator = false;
            this.treOrgUnit.Size = new System.Drawing.Size(707, 213);
            this.treOrgUnit.TabIndex = 0;
            this.treOrgUnit.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treOrgUnit_GetSelectImage);
            this.treOrgUnit.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treOrgUnit_BeforeFocusNode);
            //
            // colAbteilung
            //
            this.colAbteilung.Caption = "Abteilung";
            this.colAbteilung.FieldName = "ItemName";
            this.colAbteilung.Name = "colAbteilung";
            this.colAbteilung.OptionsColumn.AllowSort = false;
            this.colAbteilung.VisibleIndex = 0;
            this.colAbteilung.Width = 280;
            //
            // colOEItemTyp
            //
            this.colOEItemTyp.Caption = "Abteilungstyp";
            this.colOEItemTyp.FieldName = "OrgUnitTyp";
            this.colOEItemTyp.Name = "colOEItemTyp";
            this.colOEItemTyp.OptionsColumn.AllowSort = false;
            this.colOEItemTyp.VisibleIndex = 1;
            this.colOEItemTyp.Width = 120;
            //
            // colZLEVorgesetzter
            //
            this.colZLEVorgesetzter.Caption = "ZLE Vorgesetzte/r ";
            this.colZLEVorgesetzter.FieldName = "Leitung";
            this.colZLEVorgesetzter.Name = "colZLEVorgesetzter";
            this.colZLEVorgesetzter.OptionsColumn.AllowSort = false;
            this.colZLEVorgesetzter.VisibleIndex = 2;
            this.colZLEVorgesetzter.Width = 150;
            //
            // colZLEStellvertreter
            //
            this.colZLEStellvertreter.Caption = "ZLE Stellvertreter/in";
            this.colZLEStellvertreter.FieldName = "Stellvertreter";
            this.colZLEStellvertreter.Name = "colZLEStellvertreter";
            this.colZLEStellvertreter.OptionsColumn.AllowSort = false;
            this.colZLEStellvertreter.VisibleIndex = 3;
            this.colZLEStellvertreter.Width = 150;
            //
            // colVISArea
            //
            this.colVISArea.Caption = "VIS-Area";
            this.colVISArea.FieldName = "visdat36Area";
            this.colVISArea.Name = "colVISArea";
            this.colVISArea.OptionsColumn.AllowSort = false;
            this.colVISArea.Width = 100;
            //
            // qryOrgUnit
            //
            this.qryOrgUnit.AutoApplyUserRights = false;
            this.qryOrgUnit.HostControl = this;
            this.qryOrgUnit.TableName = "XOrgUnit";
            this.qryOrgUnit.BeforePost += new System.EventHandler(this.qryOrgUnit_BeforePost);
            this.qryOrgUnit.AfterPost += new System.EventHandler(this.qryOrgUnit_AfterPost);
            this.qryOrgUnit.BeforeDeleteQuestion += new System.EventHandler(this.qryOrgUnit_BeforeDeleteQuestion);
            this.qryOrgUnit.PositionChanged += new System.EventHandler(this.qryOrgUnit_PositionChanged);
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabOrgUnit;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 222);
            this.splitter.Name = "kissSplitterCollapsible1";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // tabOrgUnit
            //
            this.tabOrgUnit.Controls.Add(this.tpgAbteilung);
            this.tabOrgUnit.Controls.Add(this.tpgMitglieder);
            this.tabOrgUnit.Controls.Add(this.tpgTexte);
            this.tabOrgUnit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabOrgUnit.Location = new System.Drawing.Point(0, 230);
            this.tabOrgUnit.Name = "tabOrgUnit";
            this.tabOrgUnit.ShowFixedWidthTooltip = true;
            this.tabOrgUnit.Size = new System.Drawing.Size(750, 320);
            this.tabOrgUnit.TabIndex = 2;
            this.tabOrgUnit.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgAbteilung,
            this.tpgMitglieder,
            this.tpgTexte});
            this.tabOrgUnit.TabsLineColor = System.Drawing.Color.Black;
            this.tabOrgUnit.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabOrgUnit.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabOrgUnit_SelectedTabChanged);
            //
            // tpgAbteilung
            //
            this.tpgAbteilung.Controls.Add(this.chkAdressePostfachOhneNr);
            this.tpgAbteilung.Controls.Add(this.edtAdressePostfach);
            this.tpgAbteilung.Controls.Add(this.edtUserProfil);
            this.tpgAbteilung.Controls.Add(this.lblUserProfile);
            this.tpgAbteilung.Controls.Add(this.edtInternet);
            this.tpgAbteilung.Controls.Add(this.lblInternet);
            this.tpgAbteilung.Controls.Add(this.edtEmail);
            this.tpgAbteilung.Controls.Add(this.lblEmail);
            this.tpgAbteilung.Controls.Add(this.edtFax);
            this.tpgAbteilung.Controls.Add(this.lblFax);
            this.tpgAbteilung.Controls.Add(this.edtTelefon);
            this.tpgAbteilung.Controls.Add(this.lblTelefon);
            this.tpgAbteilung.Controls.Add(this.edtAdresseOrt);
            this.tpgAbteilung.Controls.Add(this.edtAdressePLZ);
            this.tpgAbteilung.Controls.Add(this.lblAdressePLZOrt);
            this.tpgAbteilung.Controls.Add(this.edtAdresseHausNr);
            this.tpgAbteilung.Controls.Add(this.edtAdresseStrasse);
            this.tpgAbteilung.Controls.Add(this.lblAdresseStrasseNr);
            this.tpgAbteilung.Controls.Add(this.edtAdresseAbteilung);
            this.tpgAbteilung.Controls.Add(this.lblAdresseAbteilung);
            this.tpgAbteilung.Controls.Add(this.edtAdresseKGS);
            this.tpgAbteilung.Controls.Add(this.lblAdresseKGS);
            this.tpgAbteilung.Controls.Add(this.edtZLEStellvertreter);
            this.tpgAbteilung.Controls.Add(this.lblZLEStellvertreter);
            this.tpgAbteilung.Controls.Add(this.edtZLELeitung);
            this.tpgAbteilung.Controls.Add(this.lblZLELeitung);
            this.tpgAbteilung.Controls.Add(this.edtKontoNr);
            this.tpgAbteilung.Controls.Add(this.lblPCKonto);
            this.tpgAbteilung.Controls.Add(this.edtSammelkonto);
            this.tpgAbteilung.Controls.Add(this.lblSammelkonto);
            this.tpgAbteilung.Controls.Add(this.edtLeistungLohnlaufNr);
            this.tpgAbteilung.Controls.Add(this.lblLeistungLohnlaufNr);
            this.tpgAbteilung.Controls.Add(this.edtStundenLohnlaufNr);
            this.tpgAbteilung.Controls.Add(this.lblStundenLohnlaufNr);
            this.tpgAbteilung.Controls.Add(this.edtMandantennummer);
            this.tpgAbteilung.Controls.Add(this.lblMandantennummer);
            this.tpgAbteilung.Controls.Add(this.edtKostenstelle);
            this.tpgAbteilung.Controls.Add(this.lblKostenstelle);
            this.tpgAbteilung.Controls.Add(this.edtOrgUnit);
            this.tpgAbteilung.Controls.Add(this.lblOEItemTyp);
            this.tpgAbteilung.Controls.Add(this.edtAbteilungBezeichnung);
            this.tpgAbteilung.Controls.Add(this.lblAbteilungBezeichnung);
            this.tpgAbteilung.Controls.Add(this.lblAdressePostfach);
            this.tpgAbteilung.Location = new System.Drawing.Point(6, 6);
            this.tpgAbteilung.Name = "tpgAbteilung";
            this.tpgAbteilung.Size = new System.Drawing.Size(738, 282);
            this.tpgAbteilung.TabIndex = 0;
            this.tpgAbteilung.Title = "Abteilung";
            //
            // chkAdressePostfachOhneNr
            //
            this.chkAdressePostfachOhneNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAdressePostfachOhneNr.EditValue = false;
            this.chkAdressePostfachOhneNr.Location = new System.Drawing.Point(663, 81);
            this.chkAdressePostfachOhneNr.Name = "chkAdressePostfachOhneNr";
            this.chkAdressePostfachOhneNr.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAdressePostfachOhneNr.Properties.Appearance.Options.UseBackColor = true;
            this.chkAdressePostfachOhneNr.Properties.Caption = "ohne Nr.";
            this.chkAdressePostfachOhneNr.Size = new System.Drawing.Size(72, 19);
            this.chkAdressePostfachOhneNr.TabIndex = 49;
            this.chkAdressePostfachOhneNr.CheckedChanged += new System.EventHandler(this.chkAufenthaltPostfachOhneNr_CheckedChanged);
            //
            // edtAdressePostfach
            //
            this.edtAdressePostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdressePostfach.DataMember = "Postfach";
            this.edtAdressePostfach.Location = new System.Drawing.Point(486, 78);
            this.edtAdressePostfach.Name = "edtAdressePostfach";
            this.edtAdressePostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressePostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressePostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressePostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressePostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressePostfach.Properties.Appearance.Options.UseFont = true;
            this.edtAdressePostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressePostfach.Properties.MaxLength = 100;
            this.edtAdressePostfach.Properties.Name = "editAufenthaltsOrtPosfach.Properties";
            this.edtAdressePostfach.Size = new System.Drawing.Size(171, 24);
            this.edtAdressePostfach.TabIndex = 48;
            //
            // edtUserProfil
            //
            this.edtUserProfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUserProfil.DataMember = "XProfileID";
            this.edtUserProfil.DataSource = this.qryOrgUnit;
            this.edtUserProfil.Location = new System.Drawing.Point(486, 230);
            this.edtUserProfil.Name = "edtUserProfil";
            this.edtUserProfil.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserProfil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserProfil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfil.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserProfil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserProfil.Properties.Appearance.Options.UseFont = true;
            this.edtUserProfil.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserProfil.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfil.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserProfil.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserProfil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserProfil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserProfil.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserProfil.Properties.NullText = "";
            this.edtUserProfil.Properties.ShowFooter = false;
            this.edtUserProfil.Properties.ShowHeader = false;
            this.edtUserProfil.Size = new System.Drawing.Size(249, 24);
            this.edtUserProfil.TabIndex = 39;
            //
            // lblUserProfile
            //
            this.lblUserProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUserProfile.Location = new System.Drawing.Point(404, 230);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(76, 24);
            this.lblUserProfile.TabIndex = 38;
            this.lblUserProfile.Text = "Userprofil";
            this.lblUserProfile.UseCompatibleTextRendering = true;
            //
            // edtInternet
            //
            this.edtInternet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtInternet.DataMember = "Internet";
            this.edtInternet.DataSource = this.qryOrgUnit;
            this.edtInternet.Location = new System.Drawing.Point(486, 200);
            this.edtInternet.Name = "edtInternet";
            this.edtInternet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInternet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInternet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInternet.Properties.Appearance.Options.UseBackColor = true;
            this.edtInternet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInternet.Properties.Appearance.Options.UseFont = true;
            this.edtInternet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInternet.Size = new System.Drawing.Size(249, 24);
            this.edtInternet.TabIndex = 37;
            //
            // lblInternet
            //
            this.lblInternet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInternet.Location = new System.Drawing.Point(404, 200);
            this.lblInternet.Name = "lblInternet";
            this.lblInternet.Size = new System.Drawing.Size(76, 24);
            this.lblInternet.TabIndex = 36;
            this.lblInternet.Text = "Internet";
            this.lblInternet.UseCompatibleTextRendering = true;
            //
            // edtEmail
            //
            this.edtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEmail.DataMember = "EMail";
            this.edtEmail.DataSource = this.qryOrgUnit;
            this.edtEmail.Location = new System.Drawing.Point(486, 177);
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmail.Properties.Appearance.Options.UseFont = true;
            this.edtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmail.Size = new System.Drawing.Size(249, 24);
            this.edtEmail.TabIndex = 35;
            //
            // lblEmail
            //
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmail.Location = new System.Drawing.Point(404, 176);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(76, 24);
            this.lblEmail.TabIndex = 34;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.UseCompatibleTextRendering = true;
            //
            // edtFax
            //
            this.edtFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryOrgUnit;
            this.edtFax.Location = new System.Drawing.Point(486, 154);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Size = new System.Drawing.Size(249, 24);
            this.edtFax.TabIndex = 33;
            //
            // lblFax
            //
            this.lblFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFax.Location = new System.Drawing.Point(404, 154);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(76, 24);
            this.lblFax.TabIndex = 32;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            //
            // edtTelefon
            //
            this.edtTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTelefon.DataMember = "Telefon";
            this.edtTelefon.DataSource = this.qryOrgUnit;
            this.edtTelefon.Location = new System.Drawing.Point(486, 131);
            this.edtTelefon.Name = "edtTelefon";
            this.edtTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon.Size = new System.Drawing.Size(249, 24);
            this.edtTelefon.TabIndex = 31;
            //
            // lblTelefon
            //
            this.lblTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTelefon.Location = new System.Drawing.Point(404, 131);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(76, 24);
            this.lblTelefon.TabIndex = 30;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            //
            // edtAdresseOrt
            //
            this.edtAdresseOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdresseOrt.DataMember = "AdresseOrt";
            this.edtAdresseOrt.DataSource = this.qryOrgUnit;
            this.edtAdresseOrt.Location = new System.Drawing.Point(530, 101);
            this.edtAdresseOrt.Name = "edtAdresseOrt";
            this.edtAdresseOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseOrt.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseOrt.Size = new System.Drawing.Size(205, 24);
            this.edtAdresseOrt.TabIndex = 29;
            //
            // edtAdressePLZ
            //
            this.edtAdressePLZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdressePLZ.DataMember = "AdressePLZ";
            this.edtAdressePLZ.DataSource = this.qryOrgUnit;
            this.edtAdressePLZ.Location = new System.Drawing.Point(486, 101);
            this.edtAdressePLZ.Name = "edtAdressePLZ";
            this.edtAdressePLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressePLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressePLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressePLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressePLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressePLZ.Properties.Appearance.Options.UseFont = true;
            this.edtAdressePLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressePLZ.Size = new System.Drawing.Size(45, 24);
            this.edtAdressePLZ.TabIndex = 28;
            //
            // lblAdressePLZOrt
            //
            this.lblAdressePLZOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdressePLZOrt.Location = new System.Drawing.Point(404, 100);
            this.lblAdressePLZOrt.Name = "lblAdressePLZOrt";
            this.lblAdressePLZOrt.Size = new System.Drawing.Size(76, 24);
            this.lblAdressePLZOrt.TabIndex = 27;
            this.lblAdressePLZOrt.Text = "PLZ / Ort";
            this.lblAdressePLZOrt.UseCompatibleTextRendering = true;
            //
            // edtAdresseHausNr
            //
            this.edtAdresseHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdresseHausNr.DataMember = "AdresseHausNr";
            this.edtAdresseHausNr.DataSource = this.qryOrgUnit;
            this.edtAdresseHausNr.Location = new System.Drawing.Point(686, 55);
            this.edtAdresseHausNr.Name = "edtAdresseHausNr";
            this.edtAdresseHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtAdresseHausNr.TabIndex = 26;
            //
            // edtAdresseStrasse
            //
            this.edtAdresseStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdresseStrasse.DataMember = "AdresseStrasse";
            this.edtAdresseStrasse.DataSource = this.qryOrgUnit;
            this.edtAdresseStrasse.Location = new System.Drawing.Point(486, 55);
            this.edtAdresseStrasse.Name = "edtAdresseStrasse";
            this.edtAdresseStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseStrasse.Size = new System.Drawing.Size(201, 24);
            this.edtAdresseStrasse.TabIndex = 25;
            //
            // lblAdresseStrasseNr
            //
            this.lblAdresseStrasseNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdresseStrasseNr.Location = new System.Drawing.Point(404, 55);
            this.lblAdresseStrasseNr.Name = "lblAdresseStrasseNr";
            this.lblAdresseStrasseNr.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseStrasseNr.TabIndex = 24;
            this.lblAdresseStrasseNr.Text = "Strasse / Nr.";
            this.lblAdresseStrasseNr.UseCompatibleTextRendering = true;
            //
            // edtAdresseAbteilung
            //
            this.edtAdresseAbteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdresseAbteilung.DataMember = "AdresseAbteilung";
            this.edtAdresseAbteilung.DataSource = this.qryOrgUnit;
            this.edtAdresseAbteilung.Location = new System.Drawing.Point(486, 32);
            this.edtAdresseAbteilung.Name = "edtAdresseAbteilung";
            this.edtAdresseAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseAbteilung.Size = new System.Drawing.Size(249, 24);
            this.edtAdresseAbteilung.TabIndex = 23;
            //
            // lblAdresseAbteilung
            //
            this.lblAdresseAbteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdresseAbteilung.Location = new System.Drawing.Point(404, 32);
            this.lblAdresseAbteilung.Name = "lblAdresseAbteilung";
            this.lblAdresseAbteilung.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseAbteilung.TabIndex = 22;
            this.lblAdresseAbteilung.Text = "Abteilung";
            this.lblAdresseAbteilung.UseCompatibleTextRendering = true;
            //
            // edtAdresseKGS
            //
            this.edtAdresseKGS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdresseKGS.DataMember = "AdresseKGS";
            this.edtAdresseKGS.DataSource = this.qryOrgUnit;
            this.edtAdresseKGS.Location = new System.Drawing.Point(486, 9);
            this.edtAdresseKGS.Name = "edtAdresseKGS";
            this.edtAdresseKGS.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseKGS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseKGS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseKGS.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseKGS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseKGS.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseKGS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseKGS.Size = new System.Drawing.Size(249, 24);
            this.edtAdresseKGS.TabIndex = 21;
            //
            // lblAdresseKGS
            //
            this.lblAdresseKGS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdresseKGS.Location = new System.Drawing.Point(404, 9);
            this.lblAdresseKGS.Name = "lblAdresseKGS";
            this.lblAdresseKGS.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseKGS.TabIndex = 20;
            this.lblAdresseKGS.Text = "KGS";
            this.lblAdresseKGS.UseCompatibleTextRendering = true;
            //
            // edtZLEStellvertreter
            //
            this.edtZLEStellvertreter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZLEStellvertreter.DataMember = "Stellvertreter";
            this.edtZLEStellvertreter.DataSource = this.qryOrgUnit;
            this.edtZLEStellvertreter.Location = new System.Drawing.Point(129, 237);
            this.edtZLEStellvertreter.Name = "edtZLEStellvertreter";
            this.edtZLEStellvertreter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZLEStellvertreter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZLEStellvertreter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZLEStellvertreter.Properties.Appearance.Options.UseBackColor = true;
            this.edtZLEStellvertreter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZLEStellvertreter.Properties.Appearance.Options.UseFont = true;
            this.edtZLEStellvertreter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZLEStellvertreter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZLEStellvertreter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZLEStellvertreter.Size = new System.Drawing.Size(243, 24);
            this.edtZLEStellvertreter.TabIndex = 19;
            this.edtZLEStellvertreter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZLEStellvertreter_UserModifiedFld);
            //
            // lblZLEStellvertreter
            //
            this.lblZLEStellvertreter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZLEStellvertreter.Location = new System.Drawing.Point(9, 237);
            this.lblZLEStellvertreter.Name = "lblZLEStellvertreter";
            this.lblZLEStellvertreter.Size = new System.Drawing.Size(114, 24);
            this.lblZLEStellvertreter.TabIndex = 18;
            this.lblZLEStellvertreter.Text = "ZLE Stellvertreter/in";
            this.lblZLEStellvertreter.UseCompatibleTextRendering = true;
            //
            // edtZLELeitung
            //
            this.edtZLELeitung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZLELeitung.DataMember = "Leitung";
            this.edtZLELeitung.DataSource = this.qryOrgUnit;
            this.edtZLELeitung.Location = new System.Drawing.Point(129, 214);
            this.edtZLELeitung.Margin = new System.Windows.Forms.Padding(3, 3, 4, 3);
            this.edtZLELeitung.Name = "edtZLELeitung";
            this.edtZLELeitung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZLELeitung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZLELeitung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZLELeitung.Properties.Appearance.Options.UseBackColor = true;
            this.edtZLELeitung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZLELeitung.Properties.Appearance.Options.UseFont = true;
            this.edtZLELeitung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZLELeitung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZLELeitung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZLELeitung.Size = new System.Drawing.Size(243, 24);
            this.edtZLELeitung.TabIndex = 17;
            this.edtZLELeitung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZLELeitung_UserModifiedFld);
            //
            // lblZLELeitung
            //
            this.lblZLELeitung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZLELeitung.Location = new System.Drawing.Point(9, 213);
            this.lblZLELeitung.Name = "lblZLELeitung";
            this.lblZLELeitung.Size = new System.Drawing.Size(114, 24);
            this.lblZLELeitung.TabIndex = 16;
            this.lblZLELeitung.Text = "ZLE Vorgesetzte/r ";
            this.lblZLELeitung.UseCompatibleTextRendering = true;
            //
            // edtKontoNr
            //
            this.edtKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontoNr.DataMember = "PCKonto";
            this.edtKontoNr.DataSource = this.qryOrgUnit;
            this.edtKontoNr.Location = new System.Drawing.Point(129, 184);
            this.edtKontoNr.Name = "edtKontoNr";
            this.edtKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontoNr.Properties.MaxLength = 100;
            this.edtKontoNr.Size = new System.Drawing.Size(243, 24);
            this.edtKontoNr.TabIndex = 15;
            //
            // lblPCKonto
            //
            this.lblPCKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPCKonto.Location = new System.Drawing.Point(9, 184);
            this.lblPCKonto.Name = "lblPCKonto";
            this.lblPCKonto.Size = new System.Drawing.Size(114, 24);
            this.lblPCKonto.TabIndex = 14;
            this.lblPCKonto.Text = "PC-Konto";
            this.lblPCKonto.UseCompatibleTextRendering = true;
            //
            // edtSammelkonto
            //
            this.edtSammelkonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSammelkonto.DataMember = "Sammelkonto";
            this.edtSammelkonto.DataSource = this.qryOrgUnit;
            this.edtSammelkonto.Location = new System.Drawing.Point(129, 161);
            this.edtSammelkonto.Name = "edtSammelkonto";
            this.edtSammelkonto.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSammelkonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSammelkonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSammelkonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSammelkonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtSammelkonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSammelkonto.Properties.Appearance.Options.UseFont = true;
            this.edtSammelkonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSammelkonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSammelkonto.Properties.Precision = 0;
            this.edtSammelkonto.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtSammelkonto.Size = new System.Drawing.Size(243, 24);
            this.edtSammelkonto.TabIndex = 13;
            //
            // lblSammelkonto
            //
            this.lblSammelkonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSammelkonto.Location = new System.Drawing.Point(9, 161);
            this.lblSammelkonto.Name = "lblSammelkonto";
            this.lblSammelkonto.Size = new System.Drawing.Size(114, 24);
            this.lblSammelkonto.TabIndex = 12;
            this.lblSammelkonto.Text = "Sammelkonto";
            this.lblSammelkonto.UseCompatibleTextRendering = true;
            //
            // edtLeistungLohnlaufNr
            //
            this.edtLeistungLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLeistungLohnlaufNr.DataMember = "LeistungLohnlaufNr";
            this.edtLeistungLohnlaufNr.DataSource = this.qryOrgUnit;
            this.edtLeistungLohnlaufNr.Location = new System.Drawing.Point(129, 131);
            this.edtLeistungLohnlaufNr.Name = "edtLeistungLohnlaufNr";
            this.edtLeistungLohnlaufNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLeistungLohnlaufNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeistungLohnlaufNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistungLohnlaufNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistungLohnlaufNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeistungLohnlaufNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeistungLohnlaufNr.Properties.Appearance.Options.UseFont = true;
            this.edtLeistungLohnlaufNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLeistungLohnlaufNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeistungLohnlaufNr.Properties.Precision = 0;
            this.edtLeistungLohnlaufNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtLeistungLohnlaufNr.Size = new System.Drawing.Size(243, 24);
            this.edtLeistungLohnlaufNr.TabIndex = 11;
            //
            // lblLeistungLohnlaufNr
            //
            this.lblLeistungLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLeistungLohnlaufNr.Location = new System.Drawing.Point(9, 131);
            this.lblLeistungLohnlaufNr.Name = "lblLeistungLohnlaufNr";
            this.lblLeistungLohnlaufNr.Size = new System.Drawing.Size(114, 24);
            this.lblLeistungLohnlaufNr.TabIndex = 10;
            this.lblLeistungLohnlaufNr.Text = "Lohnlauf-Nr. (Leist.)";
            this.lblLeistungLohnlaufNr.UseCompatibleTextRendering = true;
            //
            // edtStundenLohnlaufNr
            //
            this.edtStundenLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStundenLohnlaufNr.DataMember = "StundenLohnlaufNr";
            this.edtStundenLohnlaufNr.DataSource = this.qryOrgUnit;
            this.edtStundenLohnlaufNr.Location = new System.Drawing.Point(129, 108);
            this.edtStundenLohnlaufNr.Name = "edtStundenLohnlaufNr";
            this.edtStundenLohnlaufNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenLohnlaufNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenLohnlaufNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenLohnlaufNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenLohnlaufNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenLohnlaufNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenLohnlaufNr.Properties.Appearance.Options.UseFont = true;
            this.edtStundenLohnlaufNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenLohnlaufNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenLohnlaufNr.Properties.Precision = 0;
            this.edtStundenLohnlaufNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtStundenLohnlaufNr.Size = new System.Drawing.Size(243, 24);
            this.edtStundenLohnlaufNr.TabIndex = 9;
            //
            // lblStundenLohnlaufNr
            //
            this.lblStundenLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStundenLohnlaufNr.Location = new System.Drawing.Point(9, 108);
            this.lblStundenLohnlaufNr.Name = "lblStundenLohnlaufNr";
            this.lblStundenLohnlaufNr.Size = new System.Drawing.Size(114, 24);
            this.lblStundenLohnlaufNr.TabIndex = 8;
            this.lblStundenLohnlaufNr.Text = "Lohnlauf-Nr. (Std.)";
            this.lblStundenLohnlaufNr.UseCompatibleTextRendering = true;
            //
            // edtMandantennummer
            //
            this.edtMandantennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMandantennummer.DataMember = "Mandantennummer";
            this.edtMandantennummer.DataSource = this.qryOrgUnit;
            this.edtMandantennummer.Location = new System.Drawing.Point(129, 85);
            this.edtMandantennummer.Name = "edtMandantennummer";
            this.edtMandantennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMandantennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandantennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantennummer.Properties.Appearance.Options.UseFont = true;
            this.edtMandantennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandantennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandantennummer.Properties.Precision = 0;
            this.edtMandantennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtMandantennummer.Size = new System.Drawing.Size(243, 24);
            this.edtMandantennummer.TabIndex = 7;
            //
            // lblMandantennummer
            //
            this.lblMandantennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMandantennummer.Location = new System.Drawing.Point(9, 85);
            this.lblMandantennummer.Name = "lblMandantennummer";
            this.lblMandantennummer.Size = new System.Drawing.Size(114, 24);
            this.lblMandantennummer.TabIndex = 6;
            this.lblMandantennummer.Text = "Mandantennummer";
            this.lblMandantennummer.UseCompatibleTextRendering = true;
            //
            // edtKostenstelle
            //
            this.edtKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKostenstelle.DataMember = "Kostenstelle";
            this.edtKostenstelle.DataSource = this.qryOrgUnit;
            this.edtKostenstelle.Location = new System.Drawing.Point(129, 62);
            this.edtKostenstelle.Name = "edtKostenstelle";
            this.edtKostenstelle.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenstelle.Properties.Precision = 0;
            this.edtKostenstelle.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtKostenstelle.Size = new System.Drawing.Size(243, 24);
            this.edtKostenstelle.TabIndex = 5;
            //
            // lblKostenstelle
            //
            this.lblKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKostenstelle.Location = new System.Drawing.Point(9, 62);
            this.lblKostenstelle.Name = "lblKostenstelle";
            this.lblKostenstelle.Size = new System.Drawing.Size(114, 24);
            this.lblKostenstelle.TabIndex = 4;
            this.lblKostenstelle.Text = "Kostenstelle";
            this.lblKostenstelle.UseCompatibleTextRendering = true;
            //
            // edtOrgUnit
            //
            this.edtOrgUnit.AllowNull = false;
            this.edtOrgUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtOrgUnit.DataMember = "OEItemTypCode";
            this.edtOrgUnit.DataSource = this.qryOrgUnit;
            this.edtOrgUnit.Location = new System.Drawing.Point(129, 32);
            this.edtOrgUnit.LOVName = "OrganisationsEinheitTyp";
            this.edtOrgUnit.Name = "edtOrgUnit";
            this.edtOrgUnit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnit.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnit.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtOrgUnit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnit.Properties.NullText = "";
            this.edtOrgUnit.Properties.ShowFooter = false;
            this.edtOrgUnit.Properties.ShowHeader = false;
            this.edtOrgUnit.Size = new System.Drawing.Size(243, 24);
            this.edtOrgUnit.TabIndex = 3;
            //
            // lblOEItemTyp
            //
            this.lblOEItemTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOEItemTyp.Location = new System.Drawing.Point(9, 31);
            this.lblOEItemTyp.Name = "lblOEItemTyp";
            this.lblOEItemTyp.Size = new System.Drawing.Size(114, 24);
            this.lblOEItemTyp.TabIndex = 2;
            this.lblOEItemTyp.Text = "Abteilungstyp";
            this.lblOEItemTyp.UseCompatibleTextRendering = true;
            //
            // edtAbteilungBezeichnung
            //
            this.edtAbteilungBezeichnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAbteilungBezeichnung.DataMember = "ItemName";
            this.edtAbteilungBezeichnung.DataSource = this.qryOrgUnit;
            this.edtAbteilungBezeichnung.Location = new System.Drawing.Point(129, 9);
            this.edtAbteilungBezeichnung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.edtAbteilungBezeichnung.Name = "edtAbteilungBezeichnung";
            this.edtAbteilungBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbteilungBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbteilungBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbteilungBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbteilungBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbteilungBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtAbteilungBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbteilungBezeichnung.Size = new System.Drawing.Size(243, 24);
            this.edtAbteilungBezeichnung.TabIndex = 1;
            //
            // lblAbteilungBezeichnung
            //
            this.lblAbteilungBezeichnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbteilungBezeichnung.Location = new System.Drawing.Point(9, 9);
            this.lblAbteilungBezeichnung.Name = "lblAbteilungBezeichnung";
            this.lblAbteilungBezeichnung.Size = new System.Drawing.Size(114, 24);
            this.lblAbteilungBezeichnung.TabIndex = 0;
            this.lblAbteilungBezeichnung.Text = "Bezeichnung";
            this.lblAbteilungBezeichnung.UseCompatibleTextRendering = true;
            //
            // lblAdressePostfach
            //
            this.lblAdressePostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdressePostfach.Location = new System.Drawing.Point(404, 78);
            this.lblAdressePostfach.Name = "lblAdressePostfach";
            this.lblAdressePostfach.Size = new System.Drawing.Size(76, 24);
            this.lblAdressePostfach.TabIndex = 47;
            this.lblAdressePostfach.Text = "Postfach";
            this.lblAdressePostfach.UseCompatibleTextRendering = true;
            //
            // tpgMitglieder
            //
            this.tpgMitglieder.Controls.Add(this.panMitgliederTable);
            this.tpgMitglieder.Location = new System.Drawing.Point(6, 6);
            this.tpgMitglieder.Name = "tpgMitglieder";
            this.tpgMitglieder.Padding = new System.Windows.Forms.Padding(1);
            this.tpgMitglieder.Size = new System.Drawing.Size(738, 282);
            this.tpgMitglieder.TabIndex = 0;
            this.tpgMitglieder.Title = "Mitglieder";
            //
            // panMitgliederTable
            //
            this.panMitgliederTable.ColumnCount = 3;
            this.panMitgliederTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panMitgliederTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panMitgliederTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panMitgliederTable.Controls.Add(this.panMitgliederAvailable, 0, 0);
            this.panMitgliederTable.Controls.Add(this.grdZugeteilt, 2, 0);
            this.panMitgliederTable.Controls.Add(this.panMitgliederAvailableAddRemove, 1, 0);
            this.panMitgliederTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMitgliederTable.Location = new System.Drawing.Point(1, 1);
            this.panMitgliederTable.Name = "panMitgliederTable";
            this.panMitgliederTable.RowCount = 1;
            this.panMitgliederTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panMitgliederTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panMitgliederTable.Size = new System.Drawing.Size(736, 280);
            this.panMitgliederTable.TabIndex = 0;
            this.panMitgliederTable.TabStop = true;
            //
            // panMitgliederAvailable
            //
            this.panMitgliederAvailable.Controls.Add(this.grdVerfuegbar);
            this.panMitgliederAvailable.Controls.Add(this.panMitgliederAvailableFilter);
            this.panMitgliederAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMitgliederAvailable.Location = new System.Drawing.Point(3, 3);
            this.panMitgliederAvailable.Name = "panMitgliederAvailable";
            this.panMitgliederAvailable.Size = new System.Drawing.Size(332, 274);
            this.panMitgliederAvailable.TabIndex = 1;
            this.panMitgliederAvailable.TabStop = true;
            //
            // grdVerfuegbar
            //
            this.grdVerfuegbar.DataSource = this.qryKandidaten;
            this.grdVerfuegbar.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(0, 0);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Margin = new System.Windows.Forms.Padding(4);
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(332, 240);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            //
            // qryKandidaten
            //
            this.qryKandidaten.AutoApplyUserRights = false;
            this.qryKandidaten.HostControl = this;
            //
            // grvVerfuegbar
            //
            this.grvVerfuegbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfuegbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsers,
            this.colUserID});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsSelection.MultiSelect = true;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
            //
            // colUsers
            //
            this.colUsers.Caption = "Benutzer/in";
            this.colUsers.FieldName = "UserName";
            this.colUsers.Name = "colUsers";
            this.colUsers.Visible = true;
            this.colUsers.VisibleIndex = 0;
            this.colUsers.Width = 275;
            //
            // colUserID
            //
            this.colUserID.Caption = "-";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            //
            // panMitgliederAvailableFilter
            //
            this.panMitgliederAvailableFilter.Controls.Add(this.lblFilter);
            this.panMitgliederAvailableFilter.Controls.Add(this.edtFilter);
            this.panMitgliederAvailableFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panMitgliederAvailableFilter.Location = new System.Drawing.Point(0, 240);
            this.panMitgliederAvailableFilter.Name = "panMitgliederAvailableFilter";
            this.panMitgliederAvailableFilter.Size = new System.Drawing.Size(332, 34);
            this.panMitgliederAvailableFilter.TabIndex = 1;
            //
            // lblFilter
            //
            this.lblFilter.Location = new System.Drawing.Point(3, 5);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            //
            // edtFilter
            //
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(63, 5);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(269, 24);
            this.edtFilter.TabIndex = 1;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            //
            // grdZugeteilt
            //
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            this.grdZugeteilt.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdZugeteilt.Location = new System.Drawing.Point(402, 4);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Margin = new System.Windows.Forms.Padding(4);
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(330, 272);
            this.grdZugeteilt.TabIndex = 3;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            //
            // qryZugeteilt
            //
            this.qryZugeteilt.AutoApplyUserRights = false;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "XOrgUnit_User";
            this.qryZugeteilt.BeforePost += new System.EventHandler(this.qryZugeteilt_BeforePost);
            this.qryZugeteilt.BeforeDeleteQuestion += new System.EventHandler(this.qryZugeteilt_BeforeDeleteQuestion);
            this.qryZugeteilt.BeforeDelete += new System.EventHandler(this.qryZugeteilt_BeforeDelete);
            this.qryZugeteilt.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryZugeteilt_ColumnChanged);
            //
            // grvZugeteilt
            //
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsersOE,
            this.colMemberCode,
            this.colMayInsert,
            this.colMayUpdate,
            this.colMayDelete});
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            //
            // colUsersOE
            //
            this.colUsersOE.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colUsersOE.AppearanceCell.Options.UseBackColor = true;
            this.colUsersOE.Caption = "Abteilungs-Mitglieder";
            this.colUsersOE.FieldName = "UserName";
            this.colUsersOE.Name = "colUsersOE";
            this.colUsersOE.OptionsColumn.AllowEdit = false;
            this.colUsersOE.Visible = true;
            this.colUsersOE.VisibleIndex = 0;
            this.colUsersOE.Width = 188;
            //
            // colMemberCode
            //
            this.colMemberCode.Caption = "Funktion";
            this.colMemberCode.FieldName = "OrgUnitMemberCode";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.Visible = true;
            this.colMemberCode.VisibleIndex = 1;
            this.colMemberCode.Width = 76;
            //
            // colMayInsert
            //
            this.colMayInsert.Caption = "E";
            this.colMayInsert.FieldName = "MayInsert";
            this.colMayInsert.Name = "colMayInsert";
            this.colMayInsert.OptionsColumn.AllowSize = false;
            this.colMayInsert.OptionsColumn.FixedWidth = true;
            this.colMayInsert.Visible = true;
            this.colMayInsert.VisibleIndex = 2;
            this.colMayInsert.Width = 20;
            //
            // colMayUpdate
            //
            this.colMayUpdate.Caption = "M";
            this.colMayUpdate.FieldName = "MayUpdate";
            this.colMayUpdate.Name = "colMayUpdate";
            this.colMayUpdate.OptionsColumn.AllowSize = false;
            this.colMayUpdate.OptionsColumn.FixedWidth = true;
            this.colMayUpdate.Visible = true;
            this.colMayUpdate.VisibleIndex = 3;
            this.colMayUpdate.Width = 20;
            //
            // colMayDelete
            //
            this.colMayDelete.Caption = "L";
            this.colMayDelete.FieldName = "MayDelete";
            this.colMayDelete.Name = "colMayDelete";
            this.colMayDelete.OptionsColumn.AllowSize = false;
            this.colMayDelete.OptionsColumn.FixedWidth = true;
            this.colMayDelete.Visible = true;
            this.colMayDelete.VisibleIndex = 4;
            this.colMayDelete.Width = 20;
            //
            // panMitgliederAvailableAddRemove
            //
            this.panMitgliederAvailableAddRemove.Controls.Add(this.btnAdd);
            this.panMitgliederAvailableAddRemove.Controls.Add(this.btnRemove);
            this.panMitgliederAvailableAddRemove.Controls.Add(this.btnRemoveAll);
            this.panMitgliederAvailableAddRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMitgliederAvailableAddRemove.Location = new System.Drawing.Point(338, 0);
            this.panMitgliederAvailableAddRemove.Margin = new System.Windows.Forms.Padding(0);
            this.panMitgliederAvailableAddRemove.Name = "panMitgliederAvailableAddRemove";
            this.panMitgliederAvailableAddRemove.Size = new System.Drawing.Size(60, 280);
            this.panMitgliederAvailableAddRemove.TabIndex = 2;
            this.panMitgliederAvailableAddRemove.TabStop = true;
            //
            // btnAdd
            //
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(16, 30);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnRemove
            //
            this.btnRemove.Enabled = false;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(16, 60);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.Enabled = false;
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(16, 90);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // tpgTexte
            //
            this.tpgTexte.Controls.Add(this.memText2);
            this.tpgTexte.Controls.Add(this.lblText2);
            this.tpgTexte.Controls.Add(this.memText1);
            this.tpgTexte.Controls.Add(this.lblText1);
            this.tpgTexte.Location = new System.Drawing.Point(6, 6);
            this.tpgTexte.Name = "tpgTexte";
            this.tpgTexte.Size = new System.Drawing.Size(738, 282);
            this.tpgTexte.TabIndex = 0;
            this.tpgTexte.Title = "Texte";
            //
            // memText2
            //
            this.memText2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memText2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memText2.DataMember = "Text2";
            this.memText2.DataSource = this.qryOrgUnit;
            this.memText2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memText2.Font = new System.Drawing.Font("Arial", 10F);
            this.memText2.Location = new System.Drawing.Point(64, 116);
            this.memText2.Name = "memText2";
            this.memText2.ReadOnly = true;
            this.memText2.Size = new System.Drawing.Size(670, 163);
            this.memText2.TabIndex = 3;
            //
            // lblText2
            //
            this.lblText2.Location = new System.Drawing.Point(5, 116);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(53, 24);
            this.lblText2.TabIndex = 2;
            this.lblText2.Text = "Text 2";
            this.lblText2.UseCompatibleTextRendering = true;
            //
            // memText1
            //
            this.memText1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memText1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memText1.DataMember = "Text1";
            this.memText1.DataSource = this.qryOrgUnit;
            this.memText1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memText1.Font = new System.Drawing.Font("Arial", 10F);
            this.memText1.Location = new System.Drawing.Point(64, 8);
            this.memText1.Margin = new System.Windows.Forms.Padding(3, 8, 4, 3);
            this.memText1.Name = "memText1";
            this.memText1.ReadOnly = true;
            this.memText1.Size = new System.Drawing.Size(670, 102);
            this.memText1.TabIndex = 1;
            //
            // lblText1
            //
            this.lblText1.Location = new System.Drawing.Point(5, 8);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(53, 24);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "Text 1";
            this.lblText1.UseCompatibleTextRendering = true;
            //
            // CtlOrgUnit
            //
            this.ActiveSQLQuery = this.qryOrgUnit;
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.tabOrgUnit);
            this.Name = "CtlOrgUnit";
            this.Size = new System.Drawing.Size(750, 550);
            this.Load += new System.EventHandler(this.CtlOrgUnit_Load);
            this.panContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).EndInit();
            this.tabOrgUnit.ResumeLayout(false);
            this.tpgAbteilung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAdressePostfachOhneNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInternet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInternet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseKGS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseKGS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZLEStellvertreter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZLEStellvertreter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZLELeitung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZLELeitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSammelkonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSammelkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungLohnlaufNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungLohnlaufNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenLohnlaufNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenLohnlaufNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantennummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOEItemTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilungBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilungBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePostfach)).EndInit();
            this.tpgMitglieder.ResumeLayout(false);
            this.panMitgliederTable.ResumeLayout(false);
            this.panMitgliederAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            this.panMitgliederAvailableFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            this.panMitgliederAvailableAddRemove.ResumeLayout(false);
            this.tpgTexte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).EndInit();
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

        private void CtlOrgUnit_Load(object sender, System.EventArgs e)
        {
            // expand only first node
            ExpandOnlyFirstNode();

            // select first tab
            tabOrgUnit.SelectTab(tpgAbteilung);
        }

        private void UpDown_Click(object sender, System.EventArgs e)
        {
            try
            {
                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                // validate
                if (qryOrgUnit.Count == 0 || !OnSaveData())
                {
                    return;
                }

                SqlQuery qry;
                SqlQuery qryMax;
                Session.BeginTransaction();
                try
                {
                    if (sender == btnUp)
                    {
                        // Vorgänger bestimmen
                        // Muss innerhalb einer Transkation sein,
                        // da sonst in der Zwischeinzeit ein anderer User etwas verschieben kann
                        qry = DBUtil.OpenSQL(@"
                        select top 1 OrgUnitID, ParentPosition from dbo.XOrgUnit
                        where IsNull(ParentID, -1) = IsNull({0}, -1) and ParentPosition < {1}
                        order by ParentPosition desc",
                            qryOrgUnit["ParentID"],
                            qryOrgUnit["ParentPosition"]
                        );
                    }
                    else
                    {
                        // Nachfolger bestimmen
                        // Muss innerhalb einer Transkation sein,
                        // da sonst in der Zwischeinzeit ein anderer User etwas verschieben kann
                        qry = DBUtil.OpenSQL(@"
                        select top 1 OrgUnitID, ParentPosition from dbo.XOrgUnit
                        where IsNull(ParentID, -1) = IsNull({0}, -1) and ParentPosition > {1}
                        order by ParentPosition asc ",
                            qryOrgUnit["ParentID"],
                            qryOrgUnit["ParentPosition"]
                        );
                    }

                    // es muss zuerst eine Position bestimmt werden, welche noch nicht existiert.
                    // Ansonsten wird "UK_XOrgUnit_ParentID_ParentPosition" verletzt.
                    // Dazu nehmen wir einfach das MAX und erhöhen um 1.
                    // Transkaktion ist deshalb zwingend erforderlich.
                    qryMax = DBUtil.OpenSQL(@"select maxPos = MAX(ParentPosition) from XOrgUnit");
                    int maxPos = Utils.ConvertToInt(qryMax["maxPos"]);
                    maxPos = maxPos + 1;

                    if (qry.Count > 0)
                    {
                        DBUtil.NewHistoryVersion();

                        // Positionen tauschen
                        // zuerst auf eine temporäre Position setzen (maxPos)
                        DBUtil.ExecSQLThrowingException(
                            "update dbo.XOrgUnit set ParentPosition = {0} where OrgUnitID = {1}",
                            maxPos,
                            qryOrgUnit["OrgUnitID"]
                        );
                        // dann den ersten Eintrag ändern
                        DBUtil.ExecSQLThrowingException(
                            "update dbo.XOrgUnit set ParentPosition = {0} where OrgUnitID = {1}",
                            qryOrgUnit["ParentPosition"],
                            qry["OrgUnitID"]
                        );
                        // dann zweiten Eintrag ändern, welcher momentan auf der temporären Position ist (maxPos)
                        DBUtil.ExecSQLThrowingException(
                            "update dbo.XOrgUnit set ParentPosition = {0} where OrgUnitID = {1}",
                            qry["ParentPosition"],
                            qryOrgUnit["OrgUnitID"]
                        );
                        Session.Commit();
                    }
                    else
                    {
                        // Eintrag ist bereits zuoberst oder zuunterst,
                        // also muss nichts gemacht werden
                        Session.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    KissMsg.ShowError(
                        Name,
                        "ErrorMoveOrgUnit",
                        "Beim Verschieben der Abteilung ist ein unbekannter Fehler aufgetreten.",
                        ex
                    );
                }

                // Neue Position im Tree anzeigen
                RefreshTree(qryOrgUnit["ItemName"].ToString());
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                // validate first
                // HINT: if qryOrgUnit has changed, the rowHandles will be lost because of refresh in AfterPost().
                //       this is ok and cannot be changed (getting the rowhandles before Post() is called would possibly result
                //       in different data and therefore changed handles > danger of assigning other user than desired!)
                if (!btnAdd.Enabled || qryOrgUnit.Count == 0 || qryKandidaten.Count == 0 || !OnSaveData())
                {
                    return;
                }

                // get all rows the user selected
                int[] rowHandles = grdVerfuegbar.View.GetSelectedRows();

                if (rowHandles == null || rowHandles.Length < 1)
                {
                    return;
                }

                // insert all rows the user selected
                foreach (int RowHandle in rowHandles)
                {
                    // create new history version
                    DBUtil.NewHistoryVersion();

                    qryZugeteilt.Insert();
                    qryZugeteilt["OrgUnitID"] = qryOrgUnit["OrgUnitID"];
                    qryZugeteilt["UserID"] = grvVerfuegbar.GetRowCellValue(RowHandle, grvVerfuegbar.Columns["UserID"]);

                    // Default: als Mitglied eintragen, oder als Gast, wenn der Benutzer bereits Mitglied in einer anderen Abteilung
                    if (HasUserMembership(Convert.ToInt32(qryZugeteilt["UserID"])))
                    {
                        qryZugeteilt["OrgUnitMemberCode"] = 3;  // guest
                    }
                    else
                    {
                        qryZugeteilt["OrgUnitMemberCode"] = 2;  // member
                    }

                    // save pending changes
                    qryZugeteilt.Post();
                }

                // done saving OrgUnit (on validate first)
                qryOrgUnit.RowModified = false; //important!
                qryOrgUnit.Row.AcceptChanges();

                // update lists
                DisplayMembers();

                // clear filter and set focus
                edtFilter.EditValue = null;
                edtFilter.Focus();
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnAufklappen_Click(object sender, System.EventArgs e)
        {
            treOrgUnit.ExpandAll();
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            try
            {
                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                // validate first
                if (!btnRemoveAll.Enabled || qryOrgUnit.Count == 0 || !OnSaveData())
                {
                    return;
                }

                // create new history version
                DBUtil.NewHistoryVersion();

                // remove all entries (only users with no assigned entries in FaLeistung with membership = 2)
                DBUtil.ExecSQL(@"
                    DELETE OUU
                    FROM dbo.XOrgUnit_User OUU
                    WHERE OUU.OrgUnitID = {0}                                                                   -- for given orgunit
                      AND 1 = CASE
                                WHEN OUU.OrgUnitMemberCode = 2 AND EXISTS(SELECT TOP 1 1
                                                                          FROM dbo.FaLeistung LEI
                                                                          WHERE LEI.UserID = OUU.UserID) THEN 0 -- cannot remove entries of users who have membership and assigned entries in FaLeistung
                                ELSE 1                                                                          -- the other cases do not matter
                              END;", qryOrgUnit["OrgUnitID"]);

                // refresh lists
                DisplayMembers();

                // check if still users are assigned
                if (qryZugeteilt.Count == 1)
                {
                    // one user could not be removed
                    ShowMsgCannotRemoveMembership(false);
                }
                else if (qryZugeteilt.Count > 1)
                {
                    // more than one user could not be removed
                    ShowMsgCannotRemoveMembership(true);
                }
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            try
            {
                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                // validate first
                if (!btnRemove.Enabled || qryZugeteilt.Count == 0)
                {
                    return;
                }

                // create new history version
                DBUtil.NewHistoryVersion();

                // delete current entry
                if (qryZugeteilt.Delete())
                {
                    // refresh lists if delete was successfully completed
                    DisplayMembers();
                }
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnZuklappen_Click(object sender, System.EventArgs e)
        {
            this.ExpandOnlyFirstNode();
        }

        private void chkAufenthaltPostfachOhneNr_CheckedChanged(object sender, EventArgs e)
        {
            UtilsGui.TogglePostfachOhneNrEdit(chkAdressePostfachOhneNr, edtAdressePostfach, (qryOrgUnit.CanUpdate && _canUpdatePostfach));
        }

        private void edtFilter_EditValueChanged(object sender, System.EventArgs e)
        {
            qryKandidaten.DataTable.DefaultView.RowFilter = String.Format("UserName LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void edtZLELeitung_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtZLELeitung.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryOrgUnit["Leitung"] = dlg["Name"];
                qryOrgUnit["ChiefID"] = dlg["UserID"];
            }
        }

        private void edtZLEStellvertreter_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtZLEStellvertreter.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryOrgUnit["Stellvertreter"] = dlg["Name"];
                qryOrgUnit["RepresentativeID"] = dlg["UserID"];
            }
        }

        private void qryOrgUnit_AfterPost(object sender, System.EventArgs e)
        {
            // set values to non dbdata fields
            qryOrgUnit["OrgUnitTyp"] = edtOrgUnit.Text;

            // update lists
            DisplayMembers();
        }

        private void qryOrgUnit_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            try
            {
                // count sub-orgunits
                int countSubOrgUnits = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                    WHERE ParentID = {0}", qryOrgUnit["OrgUnitID"]));

                // validate
                if (countSubOrgUnits > 0)
                {
                    // show message
                    KissMsg.ShowInfo(this.Name, "UnterabteilungenBestehen_v01", "Die Abteilung kann nicht gelöscht werden, solange noch Unterabteilungen bestehen!");

                    // cancel
                    throw new KissCancelException();
                }

                // count assigned users
                int countAssignedUsers = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM dbo.XOrgUnit_User WITH (READUNCOMMITTED)
                    WHERE OrgUnitID = {0}", qryOrgUnit["OrgUnitID"]));

                // validate
                if (countAssignedUsers > 0)
                {
                    // show message
                    KissMsg.ShowInfo(this.Name, "CannotDeleteOrgUnitAssignedUsers_v01", "Die Abteilung kann nicht gelöscht werden, solange noch Mitarbeiter/innen zugewiesen sind!");

                    // cancel
                    throw new KissCancelException();
                }
            }
            catch (KissCancelException)
            {
                // throw exception further on
                throw;
            }
            catch (Exception ex)
            {
                // show message
                KissMsg.ShowError(this.Name, "ErrorDeletingOrgUnit", "Es ist ein Fehler beim Löschen der Abteilung aufgetreten.", ex);

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryOrgUnit_BeforePost(object sender, System.EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtAbteilungBezeichnung, lblAbteilungBezeichnung.Text);
            DBUtil.CheckNotNullField(edtOrgUnit, lblOEItemTyp.Text);
            DBUtil.CheckNotNullField(edtKostenstelle, lblKostenstelle.Text);

            // Hauptsitz/Kantonalegeschäftsstelle must have Mandantennummer, LohnlaufNr and (Sammelkonto)
            if (Convert.ToInt32(edtOrgUnit.EditValue) == 1 || Convert.ToInt32(edtOrgUnit.EditValue) == 4)   // 1=Hauptsitz, 4=KGS
            {
                // MandantenNr, LohnlaufNr
                DBUtil.CheckNotNullField(edtMandantennummer, lblMandantennummer.Text);
                DBUtil.CheckNotNullField(edtStundenLohnlaufNr, lblStundenLohnlaufNr.Text);
                DBUtil.CheckNotNullField(edtLeistungLohnlaufNr, lblLeistungLohnlaufNr.Text);

                // KGS must have Sammelkonto
                if (Convert.ToInt32(edtOrgUnit.EditValue) == 4)
                {
                    // SammelkontoNr
                    DBUtil.CheckNotNullField(edtSammelkonto, lblSammelkonto.Text);
                }
            }

            // check duplicate ItemName
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT 1
                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                WHERE ItemName = {0}
                  AND OrgUnitID <> ISNULL({1}, -1)", qryOrgUnit["ItemName"], qryOrgUnit["OrgUnitID"]);

            if (qry.Count > 0)
            {
                edtAbteilungBezeichnung.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "AbteilungsnameBereitsVerwendet", "Dieser Abteilungsname wird bereits verwendet!", KissMsgCode.MsgInfo));
            }

            // check duplicate KST
            qry = DBUtil.OpenSQL(@"
                SELECT 1
                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                WHERE Kostenstelle= {0}
                  AND OrgUnitID <> ISNULL({1}, -1)", qryOrgUnit["Kostenstelle"], qryOrgUnit["OrgUnitID"]);

            if (qry.Count > 0)
            {
                edtKostenstelle.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "KostenstelleBereitsVerwendet", "Diese Kostenstelle wird bereits verwendet!", KissMsgCode.MsgInfo));
            }

            // save pending changes
            qryZugeteilt.Post();

            //Wenn in der DropDown keine Auswahl getroffen worden ist, dann ist der Code -1.
            //In diesem Falle speichern wir null.
            if (Utils.ConvertToInt(qryOrgUnit["XProfileID"]) == -1)
            {
                qryOrgUnit["XProfileID"] = null;
            }

            // HISTORY
            // new history entry
            if (qryOrgUnit.RowModified)
            {
                // Modifier/Modified
                qryOrgUnit.SetModifierModified();

                // History
                DBUtil.NewHistoryVersion();
            }
        }

        private void qryOrgUnit_PositionChanged(object sender, System.EventArgs e)
        {
            // reload lists of users and members
            DisplayMembers();

            // setup gridviews
            SetupGridViews();
        }

        private void qryZugeteilt_BeforeDelete(object sender, EventArgs e)
        {
            // reapply any delete question to enable event BeforeDeleteQuestion
            qryZugeteilt.DeleteQuestion = "Any DeleteQuestion";
        }

        private void qryZugeteilt_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check if user can be removed (check in every case as user could have unsafed changed on membership)
            if (!CanRemoveMembership(Convert.ToInt32(qryZugeteilt["OrgUnitID"]), Convert.ToInt32(qryZugeteilt["UserID"])))
            {
                // user cannot be removed due to assigned entries in FaLeistung
                ShowMsgCannotRemoveMembership(false);

                // cancel
                throw new KissCancelException();
            }

            // no delete question on qry to prevent message
            qryZugeteilt.DeleteQuestion = "";
        }

        private void qryZugeteilt_BeforePost(object sender, System.EventArgs e)
        {
            // Neue Einträge werden unter btnAdd_Click automatisch erzeugt
            if (qryZugeteilt.Row.RowState == DataRowState.Added)
            {
                return;
            }

            // bei Änderung durch Benutzer: prüfen, ob keine Mehrfachmitgliedschaft ensteht
            if (Convert.ToInt32(qryZugeteilt["OrgUnitMemberCode"]) == 2)
            {
                // check membership
                if (HasUserMembership(Convert.ToInt32(qryZugeteilt["UserID"]), Convert.ToInt32(qryZugeteilt["OrgUnitID"])))
                {
                    // get membership-orgunit
                    string memberOrgUnit = Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT ISNULL(dbo.fnOrgUnitOfUser({0}, 0), '??');", qryZugeteilt["UserID"]));

                    // user is already member, do not continue
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "UserIsAlreadyMemberElsewhere_v01", "Der Benutzer '{0}' ist bereits Mitglied in der Abteilung '{1}'!", KissMsgCode.MsgInfo, qryZugeteilt["UserName"], memberOrgUnit));
                }
            }
            else
            {
                // validate if user can have guestright (user possibly had membership before, so we check anyway)
                if (!CanRemoveMembership(Convert.ToInt32(qryZugeteilt["OrgUnitID"]), Convert.ToInt32(qryZugeteilt["UserID"])))
                {
                    // user cannot be removed due to assigned entries in FaLeistung
                    ShowMsgCannotRemoveMembership(false);

                    // cancel
                    throw new KissCancelException();
                }
            }

            // HISTORY
            // new history entry
            if (qryZugeteilt.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }
        }

        private void qryZugeteilt_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryOrgUnit.RowModified = true;
        }

        private void tabOrgUnit_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // HACK: due to an unknown bug, the gridview will only change if visible...
            SetupGridViews();
        }

        private void treOrgUnit_BeforeFocusNode(Object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (_firstLoop)
            {
                _firstLoop = false;
                e.CanFocus = OnSaveData();
                _firstLoop = true;
            }
        }

        private void treOrgUnit_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            e.NodeImageIndex = Gui.KissImageList.GetImageIndex(215 + Math.Min(e.Node.Level, 3));
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Handle adding a new orgunit
        /// </summary>
        /// <returns><c>True</c> if orgunit could be created, otherwise <c>False</c></returns>
        public override bool OnAddData()
        {
            // save pending changes
            if (!qryOrgUnit.CanInsert || qryOrgUnit.Count > 0 && !OnSaveData())
            {
                return false;
            }

            // init vars
            string newName = GetNewAbteilungName();
            int newPos = 1;

            // get new position
            if (qryOrgUnit.Count > 0)
            {
                newPos = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MAX(ORG.ParentPosition) + 1, 1)
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ORG.ParentID = {0}", qryOrgUnit["OrgUnitID"]));
            }

            // make new history version
            DBUtil.NewHistoryVersion();

            // create new entry
            DBUtil.ExecSQL(@"
                INSERT INTO dbo.XOrgUnit (ParentID, ParentPosition, ItemName, Creator, Modifier)
                VALUES ({0}, {1}, {2}, {3}, {4})", qryOrgUnit.Count == 0 ? DBNull.Value : qryOrgUnit["OrgUnitID"],
                                                   newPos,
                                                   newName,
                                                   DBUtil.GetDBRowCreatorModifier(),
                                                   DBUtil.GetDBRowCreatorModifier());

            // refresh view
            RefreshTree(newName);

            // done
            return true;
        }

        public override bool OnDeleteData()
        {
            // delete only on main-query (really strange behaviour: select any assigned user-entry, then press F8, then click btnRemove(one) -> all entries will be removed!)
            return qryOrgUnit.Delete();
        }

        /// <summary>
        /// Refresh all queries
        /// </summary>
        public override void OnRefreshData()
        {
            // refresh only if save was successfully
            if (!OnSaveData())
            {
                return;
            }

            // refresh all queries
            qryOrgUnit.Refresh();
            qryKandidaten.Refresh();
            qryZugeteilt.Refresh();
        }

        /// <summary>
        /// Save changes to orgunit and membership
        /// </summary>
        /// <returns><c>True</c> if changed could be saved, otherwise <c>False</c></returns>
        public override bool OnSaveData()
        {
            // save both: assigned users and orgunit (first users as orgunit.AfterPost will reload users)
            return qryZugeteilt.Post() && qryOrgUnit.Post();
        }

        #endregion

        #region Private Methods

        private bool CanRemoveMembership(int orgUnitID, int userID)
        {
            // check if user is member on this entry and has assigned entries in FaLeistung
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                -- init vars
                DECLARE @OrgUnitID INT;
                DECLARE @UserID INT;
                DECLARE @MemberShip INT;
                DECLARE @Possible BIT;

                -- set vars
                SET @OrgUnitID = ISNULL({0}, -1);
                SET @UserID    = ISNULL({1}, -1);
                --
                SET @MemberShip = -1;

                -- get membership
                SELECT @MemberShip = OUU.OrgUnitMemberCode
                FROM dbo.XOrgUnit_User OUU
                WHERE OUU.OrgUnitID = @OrgUnitID
                  AND OUU.UserID = @UserID;

                -- check if delete is possible
                SELECT CASE
                         WHEN ISNULL(@MemberShip, -1) < 1 THEN 0                             -- invalid values, cannot delete invalid values (valid are only 1, 2, 3)
                         WHEN @MemberShip = 2 AND EXISTS(SELECT TOP 1 1
                                                         FROM dbo.FaLeistung LEI
                                                         WHERE LEI.UserID = @UserID) THEN 0  -- cannot delete values if entries in FaLeistung are assigned to user
                         ELSE 1                                                              -- membership can be removed
                       END;", orgUnitID, userID));
        }

        private void DisplayMembers()
        {
            // unassigned users
            qryKandidaten.Fill(@"
                SELECT USR.UserID,
                       UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, Firstname) + ' (' + LogonName + ')'
                FROM dbo.XUser USR WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND OUU.OrgUnitID = {0}
                WHERE OUU.OrgUnitID IS NULL
                ORDER BY UserName", qryOrgUnit["OrgUnitID"]);

            // assigend users
            qryZugeteilt.Fill(@"
                SELECT OUU.*,
                       UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, Firstname) + ' (' + LogonName + ')'
                FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = OUU.UserID
                WHERE OUU.OrgUnitID = {0}
                  AND OUU.OrgUnitMemberCode IN (2, 3)
                ORDER BY OUU.OrgUnitMemberCode, UserName", qryOrgUnit["OrgUnitID"]);
        }

        private void ExpandOnlyFirstNode()
        {
            // get root node
            treOrgUnit.CollapseAll();

            if (treOrgUnit.FocusedNode != null)
            {
                // expand it
                treOrgUnit.FocusedNode.Expanded = true;
            }
        }

        private string GetNewAbteilungName()
        {
            // init and setup vars
            int idx = 0;
            string name;
            string newOrgUnit = KissMsg.GetMLMessage(this.Name, "NewOrgUnit", "Abteilung");
            SqlQuery qry = null;

            // find unique name
            do
            {
                idx++;
                name = newOrgUnit + idx.ToString();
                qry = DBUtil.OpenSQL(@"
                    SELECT 1
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ORG.ItemName = {0}", name);
            }
            while (qry.Count > 0);

            // ok
            return name;
        }

        /// <summary>
        /// Check if user already has a membership
        /// </summary>
        /// <param name="userID">The id of the user to check</param>
        /// <returns><c>True</c> if user has an membership, otherwise <c>False</c></returns>
        private bool HasUserMembership(int userID)
        {
            // check for any membership
            return HasUserMembership(userID, -1);
        }

        /// <summary>
        /// Check if user already has a membership
        /// </summary>
        /// <param name="userID">The id of the user to check</param>
        /// <param name="orgUnitID">The id of the orgunit to check (if id is bigger than 0, the given id will not be checked)</param>
        /// <returns><c>True</c> if user has an membership, otherwise <c>False</c></returns>
        private bool HasUserMembership(int userID, int orgUnitID)
        {
            // count membership amount of user
            int memberCount = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    DECLARE @UserID INT;
                    DECLARE @OrgUnitID INT;

                    SET @UserID = {0};
                    SET @OrgUnitID = ISNULL({1}, -1);

                    SELECT COUNT(1)
                    FROM dbo.XOrgUnit_User WITH (READUNCOMMITTED)
                    WHERE UserID = @UserID
                      AND OrgUnitMemberCode = 2 -- member
                      AND OrgUnitID <> @OrgUnitID", qryZugeteilt["UserID"], qryOrgUnit["OrgUnitID"]));

            // if user has any entry, he or she has already a membership
            return memberCount > 0;
        }

        private void RefreshTree(string Name)
        {
            // reapply datasource
            treOrgUnit.DataSource = null;
            qryOrgUnit.Refresh();
            treOrgUnit.DataSource = qryOrgUnit;

            // locate new Abteilung
            TreeListNode node = DBUtil.FindNodeByValue(treOrgUnit.Nodes, Name, "ItemName");

            // focus last node
            if (node != null)
            {
                treOrgUnit.FocusedNode = node;
            }
        }

        private void SetupDataMember()
        {
            chkAdressePostfachOhneNr.DataMember = "PostfachOhneNr";
            edtAdressePostfach.DataMember = "Postfach";
        }

        private void SetupDataSource()
        {
            chkAdressePostfachOhneNr.DataSource = this.qryOrgUnit;
            edtAdressePostfach.DataSource = this.qryOrgUnit;
        }

        private void SetupGridViews()
        {
            grvVerfuegbar.OptionsView.ColumnAutoWidth = true;
            grvZugeteilt.OptionsView.ColumnAutoWidth = true;
        }

        private void SetupRights()
        {
            // rights are defined as following
            //  - RW:       listens on EML for maskrights, setup qryOrgUnit, deny set members or change flags
            //  - ITKoord:  listens on special right, can change PC-Konto, ZLE*, UserProfile, all fields on right side of tabpage, allow EML members
            //  - HR:       listens on EML for maskrights, only readonly flags
            //  - admin:    can do everything

            // VARS
            bool isAdmin = Session.User.IsUserAdmin;
            bool canReadData = false;
            bool canOrgUnitInsert = false;
            bool canOrgUnitUpdate = false;
            bool canOrgUnitDelete = false;
            bool isITKoordinator = DBUtil.UserHasRight("AdAbteilungLokaleDaten");

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canOrgUnitInsert, out canOrgUnitUpdate, out canOrgUnitDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // set edit modes
            EditModeType modeRW = isAdmin || canOrgUnitInsert || canOrgUnitUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
            EditModeType modeITKoord = isAdmin || isITKoordinator ? EditModeType.Normal : EditModeType.ReadOnly;

            // ORGUNIT
            // query
            qryOrgUnit.CanInsert = isAdmin || canOrgUnitInsert;
            qryOrgUnit.CanUpdate = isAdmin || canOrgUnitUpdate || isITKoordinator;
            qryOrgUnit.CanDelete = isAdmin || canOrgUnitDelete;

            // buttons
            btnUp.Enabled = isAdmin || canOrgUnitInsert;
            btnDown.Enabled = isAdmin || canOrgUnitInsert;

            // fields
            edtAbteilungBezeichnung.EditMode = modeRW;
            edtOrgUnit.EditMode = modeRW;
            edtKostenstelle.EditMode = modeRW;
            edtMandantennummer.EditMode = modeRW;
            edtStundenLohnlaufNr.EditMode = modeRW;
            edtLeistungLohnlaufNr.EditMode = modeRW;
            edtSammelkonto.EditMode = modeRW;
            edtKontoNr.EditMode = modeITKoord;
            edtZLELeitung.EditMode = modeITKoord;
            edtZLEStellvertreter.EditMode = modeITKoord;
            edtAdresseKGS.EditMode = modeITKoord;
            edtAdresseAbteilung.EditMode = modeITKoord;
            edtAdresseStrasse.EditMode = modeITKoord;
            edtAdresseHausNr.EditMode = modeITKoord;
            edtAdressePostfach.EditMode = modeITKoord;
            chkAdressePostfachOhneNr.EditMode = modeITKoord;
            edtAdressePLZ.EditMode = modeITKoord;
            edtAdresseOrt.EditMode = modeITKoord;
            edtTelefon.EditMode = modeITKoord;
            edtFax.EditMode = modeITKoord;
            edtEmail.EditMode = modeITKoord;
            edtInternet.EditMode = modeITKoord;
            edtUserProfil.EditMode = modeITKoord;

            // set flags
            _canUpdatePostfach = (modeITKoord == EditModeType.Normal);

            // MEMBERS:
            // qryKandidaten is always readonly
            qryKandidaten.CanInsert = false;
            qryKandidaten.CanUpdate = false;
            qryKandidaten.CanDelete = false;

            qryZugeteilt.CanInsert = isAdmin || isITKoordinator;
            qryZugeteilt.CanUpdate = isAdmin || isITKoordinator;
            qryZugeteilt.CanDelete = isAdmin || isITKoordinator;

            //  buttons and grid
            btnAdd.Enabled = isAdmin || isITKoordinator;
            btnRemove.Enabled = isAdmin || isITKoordinator;
            btnRemoveAll.Enabled = isAdmin || isITKoordinator;
            grdZugeteilt.GridStyle = qryZugeteilt.CanUpdate ? GridStyleType.Editable : GridStyleType.ReadOnly;

            // FIELDS
            qryOrgUnit.EnableBoundFields();
            qryKandidaten.EnableBoundFields();
            qryZugeteilt.EnableBoundFields();
        }

        private void ShowMsgCannotRemoveMembership(bool multipleUsers)
        {
            if (multipleUsers)
            {
                // multiple users
                KissMsg.ShowInfo(this.Name, "CannotRemoveMembershipMultiple", "Die Mitarbeiter/innen können nicht als Mitglied aus der gewählten Abteilung entfernt werden, da ihnen noch Prozesse zugeteilt sind!\r\n\r\nBitte verteilen Sie zuerst die Prozesse an andere Mitabeiter/innen.");

            }
            else
            {
                // single user
                KissMsg.ShowInfo(this.Name, "CannotRemoveMembershipSingle", "Der/die Mitarbeiter/in kann nicht als Mitglied aus der gewählten Abteilung entfernt werden, da ihm/ihr noch Prozesse zugeteilt sind!\r\n\r\nBitte verteilen Sie zuerst die Prozesse an andere Mitabeiter/innen.");
            }
        }

        #endregion

        #endregion
    }
}