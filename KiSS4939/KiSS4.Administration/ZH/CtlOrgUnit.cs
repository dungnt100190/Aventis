using System;
using System.Data;

using KiSS4.Common;
using KiSS4.DB;

using DevExpress.XtraTreeList.Nodes;

namespace KiSS4.Administration.ZH
{
    public class CtlOrgUnit : Gui.KissUserControl
    {
        #region Fields

        #region Private Static Fields

        static bool firstLoop = true;

        #endregion

        #region Private Fields

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnUp;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKostenstelle;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLeitung;
        private DevExpress.XtraGrid.Columns.GridColumn colMayDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colMayInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colMayUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOrganisationseinheiten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStellvertretung;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAdAbteilung;
        private KiSS4.Gui.KissMemoEdit edtAdressblock;
        private KiSS4.Gui.KissTextEdit edtEmail;
        private KiSS4.Gui.KissTextEdit edtFax;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtKostenstelle;
        private KiSS4.Gui.KissTextEdit edtOrganisationseinheit;
        private KiSS4.Gui.KissTextEdit edtPhone;
        private KiSS4.Gui.KissButtonEdit edtSL;
        private KiSS4.Gui.KissButtonEdit edtSLstv;
        private KiSS4.Gui.KissLookUpEdit edtUserprofileCode;
        private KiSS4.Gui.KissTextEdit edtWeb;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel lblAdAbteilung;
        private KiSS4.Gui.KissLabel lblAdressblock;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblKostenstelle;
        private KiSS4.Gui.KissLabel lblLogo;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblSL;
        private KiSS4.Gui.KissLabel lblSLstv;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblText1;
        private KiSS4.Gui.KissLabel lblText2;
        private KiSS4.Gui.KissLabel lblText3;
        private KiSS4.Gui.KissLabel lblText4;
        private KiSS4.Gui.KissLabel lblUserprofile;
        private KiSS4.Gui.KissLabel lblWeb;
        private KiSS4.Gui.KissRTFEdit memLogo;
        private KiSS4.Gui.KissRTFEdit memText;
        private KiSS4.Gui.KissRTFEdit memText2;
        private KiSS4.Gui.KissRTFEdit memText3;
        private KiSS4.Gui.KissRTFEdit memText4;
        private KiSS4.DB.SqlQuery qryKandidaten;
        private KiSS4.DB.SqlQuery qryOrgUnit;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissTabControlEx tabOrgUnit;
        private SharpLibrary.WinControls.TabPageEx tpgMitglieder;
        private SharpLibrary.WinControls.TabPageEx tpgOrganisationseinheiten;
        private SharpLibrary.WinControls.TabPageEx tpgTexte;
        private KiSS4.Gui.KissTree treOrgUnit;

        #endregion

        #endregion

        #region Constructors

        public CtlOrgUnit()
        {
            this.InitializeComponent();

            // show first tab
            tabOrgUnit.SelectedTabIndex = 0;

            // add icons
            treOrgUnit.SelectImageList = Gui.KissImageList.SmallImageList;

            grdZugeteilt.View.Columns["OrgUnitMemberCode"].ColumnEdit = grdZugeteilt.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                select Code,Text
                from   XLovCode
                where  LOVName = 'OrgUnitMember' and
                       Code in (2,3)
                order by SortKey"));

            qryOrgUnit.Fill(@"
                select ORG.*,
                       Leitung        = USR1.LastName + isnull(', ' + USR1.FirstName,''),
                       Stellvertreter = USR2.LastName + isnull(', ' + USR2.FirstName,'')
                from   XOrgUnit ORG
                   left join XUser USR1 on USR1.UserID = ORG.ChiefID
                   left join XUser USR2 on USR2.UserID = ORG.StellvertreterID
                order by ParentID,ParentPosition");

            // no delete question on qry
            qryZugeteilt.DeleteQuestion = "";

            // show all nodes
            treOrgUnit.ExpandAll();
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
            this.tabOrgUnit = new KiSS4.Gui.KissTabControlEx();
            this.tpgMitglieder = new SharpLibrary.WinControls.TabPageEx();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.tpgOrganisationseinheiten = new SharpLibrary.WinControls.TabPageEx();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtOrganisationseinheit = new KiSS4.Gui.KissTextEdit();
            this.lblSL = new KiSS4.Gui.KissLabel();
            this.edtSL = new KiSS4.Gui.KissButtonEdit();
            this.lblSLstv = new KiSS4.Gui.KissLabel();
            this.lblUserprofile = new KiSS4.Gui.KissLabel();
            this.edtUserprofileCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtPhone = new KiSS4.Gui.KissTextEdit();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.edtEmail = new KiSS4.Gui.KissTextEdit();
            this.lblWeb = new KiSS4.Gui.KissLabel();
            this.edtWeb = new KiSS4.Gui.KissTextEdit();
            this.edtSLstv = new KiSS4.Gui.KissButtonEdit();
            this.lblAdressblock = new KiSS4.Gui.KissLabel();
            this.lblLogo = new KiSS4.Gui.KissLabel();
            this.memLogo = new KiSS4.Gui.KissRTFEdit();
            this.lblKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtKostenstelle = new KiSS4.Gui.KissTextEdit();
            this.edtAdressblock = new KiSS4.Gui.KissMemoEdit();
            this.edtAdAbteilung = new KiSS4.Gui.KissTextEdit();
            this.lblAdAbteilung = new KiSS4.Gui.KissLabel();
            this.tpgTexte = new SharpLibrary.WinControls.TabPageEx();
            this.lblText2 = new KiSS4.Gui.KissLabel();
            this.memText2 = new KiSS4.Gui.KissRTFEdit();
            this.lblText3 = new KiSS4.Gui.KissLabel();
            this.memText3 = new KiSS4.Gui.KissRTFEdit();
            this.lblText4 = new KiSS4.Gui.KissLabel();
            this.memText4 = new KiSS4.Gui.KissRTFEdit();
            this.lblText1 = new KiSS4.Gui.KissLabel();
            this.memText = new KiSS4.Gui.KissRTFEdit();
            this.treOrgUnit = new KiSS4.Gui.KissTree();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.colKostenstelle = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLeitung = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMayDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrganisationseinheiten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colStellvertretung = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryKandidaten = new KiSS4.DB.SqlQuery(this.components);
            this.qryOrgUnit = new KiSS4.DB.SqlQuery(this.components);
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.tabOrgUnit.SuspendLayout();
            this.tpgMitglieder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            this.tpgOrganisationseinheiten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrganisationseinheit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSLstv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserprofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserprofileCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserprofileCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSLstv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressblock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressblock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdAbteilung)).BeginInit();
            this.tpgTexte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            this.SuspendLayout();
            //
            // tabOrgUnit
            //
            this.tabOrgUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOrgUnit.Controls.Add(this.tpgTexte);
            this.tabOrgUnit.Controls.Add(this.tpgOrganisationseinheiten);
            this.tabOrgUnit.Controls.Add(this.tpgMitglieder);
            this.tabOrgUnit.Location = new System.Drawing.Point(4, 319);
            this.tabOrgUnit.Name = "tabOrgUnit";
            this.tabOrgUnit.ShowFixedWidthTooltip = true;
            this.tabOrgUnit.Size = new System.Drawing.Size(735, 293);
            this.tabOrgUnit.TabIndex = 0;
            this.tabOrgUnit.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgOrganisationseinheiten,
                        this.tpgMitglieder,
                        this.tpgTexte});
            this.tabOrgUnit.TabsLineColor = System.Drawing.Color.Black;
            this.tabOrgUnit.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            //
            // tpgMitglieder
            //
            this.tpgMitglieder.Controls.Add(this.kissLabel2);
            this.tpgMitglieder.Controls.Add(this.edtFilter);
            this.tpgMitglieder.Controls.Add(this.grdZugeteilt);
            this.tpgMitglieder.Controls.Add(this.btnRemoveAll);
            this.tpgMitglieder.Controls.Add(this.btnRemove);
            this.tpgMitglieder.Controls.Add(this.btnAdd);
            this.tpgMitglieder.Controls.Add(this.grdVerfuegbar);
            this.tpgMitglieder.Location = new System.Drawing.Point(6, 6);
            this.tpgMitglieder.Name = "tpgMitglieder";
            this.tpgMitglieder.Size = new System.Drawing.Size(723, 255);
            this.tpgMitglieder.TabIndex = 0;
            this.tpgMitglieder.Title = "Mitglieder";
            //
            // grdVerfuegbar
            //
            this.grdVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVerfuegbar.DataSource = this.qryKandidaten;
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(5, 8);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(303, 217);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(315, 76);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnRemove
            //
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(315, 106);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(315, 136);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 3;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // grdZugeteilt
            //
            this.grdZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdZugeteilt.Location = new System.Drawing.Point(351, 8);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(366, 217);
            this.grdZugeteilt.TabIndex = 4;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            //
            // edtFilter
            //
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(43, 231);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(194, 24);
            this.edtFilter.TabIndex = 316;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            //
            // kissLabel2
            //
            this.kissLabel2.Location = new System.Drawing.Point(3, 231);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(33, 24);
            this.kissLabel2.TabIndex = 317;
            this.kissLabel2.Text = "Filter";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // tpgOrganisationseinheiten
            //
            this.tpgOrganisationseinheiten.Controls.Add(this.lblAdAbteilung);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtAdAbteilung);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtAdressblock);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtKostenstelle);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblKostenstelle);
            this.tpgOrganisationseinheiten.Controls.Add(this.memLogo);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblLogo);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblAdressblock);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtSLstv);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtWeb);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblWeb);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtEmail);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblEmail);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtFax);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblFax);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtPhone);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblTelefon);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtUserprofileCode);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblUserprofile);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblSLstv);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtSL);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblSL);
            this.tpgOrganisationseinheiten.Controls.Add(this.edtOrganisationseinheit);
            this.tpgOrganisationseinheiten.Controls.Add(this.lblName);
            this.tpgOrganisationseinheiten.Location = new System.Drawing.Point(6, 6);
            this.tpgOrganisationseinheiten.Name = "tpgOrganisationseinheiten";
            this.tpgOrganisationseinheiten.Size = new System.Drawing.Size(723, 255);
            this.tpgOrganisationseinheiten.TabIndex = 0;
            this.tpgOrganisationseinheiten.Title = "Organisationseinheiten";
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(9, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(84, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Bezeichnung";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // edtOrganisationseinheit
            //
            this.edtOrganisationseinheit.DataMember = "ItemName";
            this.edtOrganisationseinheit.DataSource = this.qryOrgUnit;
            this.edtOrganisationseinheit.Location = new System.Drawing.Point(95, 10);
            this.edtOrganisationseinheit.Name = "edtOrganisationseinheit";
            this.edtOrganisationseinheit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrganisationseinheit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrganisationseinheit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrganisationseinheit.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrganisationseinheit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrganisationseinheit.Properties.Appearance.Options.UseFont = true;
            this.edtOrganisationseinheit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrganisationseinheit.Size = new System.Drawing.Size(239, 24);
            this.edtOrganisationseinheit.TabIndex = 1;
            //
            // lblSL
            //
            this.lblSL.Location = new System.Drawing.Point(9, 40);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(84, 24);
            this.lblSL.TabIndex = 2;
            this.lblSL.Text = "Leitung";
            this.lblSL.UseCompatibleTextRendering = true;
            //
            // edtSL
            //
            this.edtSL.DataMember = "Leitung";
            this.edtSL.DataSource = this.qryOrgUnit;
            this.edtSL.Location = new System.Drawing.Point(95, 40);
            this.edtSL.Name = "edtSL";
            this.edtSL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSL.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSL.Properties.Appearance.Options.UseBackColor = true;
            this.edtSL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSL.Properties.Appearance.Options.UseFont = true;
            this.edtSL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtSL.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSL.Size = new System.Drawing.Size(239, 24);
            this.edtSL.TabIndex = 3;
            this.edtSL.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSL_UserModifiedFld);
            //
            // lblSLstv
            //
            this.lblSLstv.Location = new System.Drawing.Point(9, 71);
            this.lblSLstv.Name = "lblSLstv";
            this.lblSLstv.Size = new System.Drawing.Size(84, 24);
            this.lblSLstv.TabIndex = 3;
            this.lblSLstv.Text = "Stellvertretung";
            this.lblSLstv.UseCompatibleTextRendering = true;
            //
            // lblUserprofile
            //
            this.lblUserprofile.Location = new System.Drawing.Point(9, 131);
            this.lblUserprofile.Name = "lblUserprofile";
            this.lblUserprofile.Size = new System.Drawing.Size(84, 24);
            this.lblUserprofile.TabIndex = 4;
            this.lblUserprofile.Text = "Userprofil";
            this.lblUserprofile.UseCompatibleTextRendering = true;
            //
            // edtUserprofileCode
            //
            this.edtUserprofileCode.DataMember = "UserProfileCode";
            this.edtUserprofileCode.DataSource = this.qryOrgUnit;
            this.edtUserprofileCode.Location = new System.Drawing.Point(95, 131);
            this.edtUserprofileCode.LOVName = "UserProfile";
            this.edtUserprofileCode.Name = "edtUserprofileCode";
            this.edtUserprofileCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserprofileCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserprofileCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserprofileCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserprofileCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserprofileCode.Properties.Appearance.Options.UseFont = true;
            this.edtUserprofileCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserprofileCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtUserprofileCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserprofileCode.Properties.NullText = "";
            this.edtUserprofileCode.Properties.ShowFooter = false;
            this.edtUserprofileCode.Properties.ShowHeader = false;
            this.edtUserprofileCode.Size = new System.Drawing.Size(239, 24);
            this.edtUserprofileCode.TabIndex = 5;
            //
            // lblTelefon
            //
            this.lblTelefon.Location = new System.Drawing.Point(354, 131);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(68, 24);
            this.lblTelefon.TabIndex = 6;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            //
            // edtPhone
            //
            this.edtPhone.DataMember = "Phone";
            this.edtPhone.DataSource = this.qryOrgUnit;
            this.edtPhone.Location = new System.Drawing.Point(427, 131);
            this.edtPhone.Name = "edtPhone";
            this.edtPhone.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPhone.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPhone.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPhone.Properties.Appearance.Options.UseBackColor = true;
            this.edtPhone.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPhone.Properties.Appearance.Options.UseFont = true;
            this.edtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPhone.Size = new System.Drawing.Size(239, 24);
            this.edtPhone.TabIndex = 7;
            //
            // lblFax
            //
            this.lblFax.Location = new System.Drawing.Point(354, 154);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(68, 24);
            this.lblFax.TabIndex = 8;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            //
            // edtFax
            //
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryOrgUnit;
            this.edtFax.Location = new System.Drawing.Point(427, 154);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Size = new System.Drawing.Size(239, 24);
            this.edtFax.TabIndex = 9;
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(354, 199);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(68, 24);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "EMail";
            this.lblEmail.UseCompatibleTextRendering = true;
            //
            // edtEmail
            //
            this.edtEmail.DataMember = "EMail";
            this.edtEmail.DataSource = this.qryOrgUnit;
            this.edtEmail.Location = new System.Drawing.Point(427, 199);
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmail.Properties.Appearance.Options.UseFont = true;
            this.edtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmail.Size = new System.Drawing.Size(239, 24);
            this.edtEmail.TabIndex = 11;
            //
            // lblWeb
            //
            this.lblWeb.Location = new System.Drawing.Point(354, 176);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(68, 24);
            this.lblWeb.TabIndex = 12;
            this.lblWeb.Text = "Web";
            this.lblWeb.UseCompatibleTextRendering = true;
            //
            // edtWeb
            //
            this.edtWeb.DataMember = "WWW";
            this.edtWeb.DataSource = this.qryOrgUnit;
            this.edtWeb.Location = new System.Drawing.Point(427, 176);
            this.edtWeb.Name = "edtWeb";
            this.edtWeb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeb.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeb.Properties.Appearance.Options.UseFont = true;
            this.edtWeb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWeb.Size = new System.Drawing.Size(239, 24);
            this.edtWeb.TabIndex = 13;
            //
            // edtSLstv
            //
            this.edtSLstv.DataMember = "Stellvertreter";
            this.edtSLstv.DataSource = this.qryOrgUnit;
            this.edtSLstv.Location = new System.Drawing.Point(95, 71);
            this.edtSLstv.Name = "edtSLstv";
            this.edtSLstv.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSLstv.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSLstv.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSLstv.Properties.Appearance.Options.UseBackColor = true;
            this.edtSLstv.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSLstv.Properties.Appearance.Options.UseFont = true;
            this.edtSLstv.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSLstv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSLstv.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSLstv.Size = new System.Drawing.Size(239, 24);
            this.edtSLstv.TabIndex = 14;
            this.edtSLstv.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSLstv_UserModifiedFld);
            //
            // lblAdressblock
            //
            this.lblAdressblock.Location = new System.Drawing.Point(354, 10);
            this.lblAdressblock.Name = "lblAdressblock";
            this.lblAdressblock.Size = new System.Drawing.Size(68, 24);
            this.lblAdressblock.TabIndex = 15;
            this.lblAdressblock.Text = "Adressblock";
            this.lblAdressblock.UseCompatibleTextRendering = true;
            //
            // lblLogo
            //
            this.lblLogo.Location = new System.Drawing.Point(9, 171);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(84, 24);
            this.lblLogo.TabIndex = 24;
            this.lblLogo.Text = "Logo";
            this.lblLogo.UseCompatibleTextRendering = true;
            //
            // memLogo
            //
            this.memLogo.BackColor = System.Drawing.Color.White;
            this.memLogo.DataMember = "Logo";
            this.memLogo.DataSource = this.qryOrgUnit;
            this.memLogo.Font = new System.Drawing.Font("Arial", 10F);
            this.memLogo.Location = new System.Drawing.Point(95, 177);
            this.memLogo.Name = "memLogo";
            this.memLogo.Size = new System.Drawing.Size(239, 46);
            this.memLogo.TabIndex = 25;
            //
            // lblKostenstelle
            //
            this.lblKostenstelle.Location = new System.Drawing.Point(9, 101);
            this.lblKostenstelle.Name = "lblKostenstelle";
            this.lblKostenstelle.Size = new System.Drawing.Size(84, 24);
            this.lblKostenstelle.TabIndex = 26;
            this.lblKostenstelle.Text = "Kostenstelle";
            this.lblKostenstelle.UseCompatibleTextRendering = true;
            //
            // edtKostenstelle
            //
            this.edtKostenstelle.DataMember = "Kostenstelle";
            this.edtKostenstelle.DataSource = this.qryOrgUnit;
            this.edtKostenstelle.Location = new System.Drawing.Point(95, 101);
            this.edtKostenstelle.Name = "edtKostenstelle";
            this.edtKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenstelle.Size = new System.Drawing.Size(239, 24);
            this.edtKostenstelle.TabIndex = 27;
            //
            // edtAdressblock
            //
            this.edtAdressblock.DataMember = "Adresse";
            this.edtAdressblock.DataSource = this.qryOrgUnit;
            this.edtAdressblock.Location = new System.Drawing.Point(427, 11);
            this.edtAdressblock.Name = "edtAdressblock";
            this.edtAdressblock.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressblock.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressblock.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressblock.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressblock.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressblock.Properties.Appearance.Options.UseFont = true;
            this.edtAdressblock.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressblock.Size = new System.Drawing.Size(239, 114);
            this.edtAdressblock.TabIndex = 28;
            //
            // edtAdAbteilung
            //
            this.edtAdAbteilung.DataMember = "AD_Abteilung";
            this.edtAdAbteilung.DataSource = this.qryOrgUnit;
            this.edtAdAbteilung.Location = new System.Drawing.Point(427, 230);
            this.edtAdAbteilung.Name = "edtAdAbteilung";
            this.edtAdAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtAdAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdAbteilung.Size = new System.Drawing.Size(239, 24);
            this.edtAdAbteilung.TabIndex = 29;
            this.edtAdAbteilung.Visible = false;
            //
            // lblAdAbteilung
            //
            this.lblAdAbteilung.Location = new System.Drawing.Point(354, 230);
            this.lblAdAbteilung.Name = "lblAdAbteilung";
            this.lblAdAbteilung.Size = new System.Drawing.Size(68, 24);
            this.lblAdAbteilung.TabIndex = 30;
            this.lblAdAbteilung.Text = "AD-Abteilung";
            this.lblAdAbteilung.UseCompatibleTextRendering = true;
            this.lblAdAbteilung.Visible = false;
            //
            // tpgTexte
            //
            this.tpgTexte.Controls.Add(this.memText);
            this.tpgTexte.Controls.Add(this.lblText1);
            this.tpgTexte.Controls.Add(this.memText4);
            this.tpgTexte.Controls.Add(this.lblText4);
            this.tpgTexte.Controls.Add(this.memText3);
            this.tpgTexte.Controls.Add(this.lblText3);
            this.tpgTexte.Controls.Add(this.memText2);
            this.tpgTexte.Controls.Add(this.lblText2);
            this.tpgTexte.Location = new System.Drawing.Point(6, 6);
            this.tpgTexte.Name = "tpgTexte";
            this.tpgTexte.Size = new System.Drawing.Size(723, 255);
            this.tpgTexte.TabIndex = 0;
            this.tpgTexte.Title = "Texte";
            //
            // lblText2
            //
            this.lblText2.Location = new System.Drawing.Point(5, 67);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(50, 24);
            this.lblText2.TabIndex = 0;
            this.lblText2.Text = "Text 2";
            this.lblText2.UseCompatibleTextRendering = true;
            //
            // memText2
            //
            this.memText2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memText2.BackColor = System.Drawing.Color.White;
            this.memText2.DataMember = "Text2";
            this.memText2.DataSource = this.qryOrgUnit;
            this.memText2.Font = new System.Drawing.Font("Arial", 10F);
            this.memText2.Location = new System.Drawing.Point(61, 67);
            this.memText2.Name = "memText2";
            this.memText2.Size = new System.Drawing.Size(655, 58);
            this.memText2.TabIndex = 1;
            //
            // lblText3
            //
            this.lblText3.Location = new System.Drawing.Point(5, 131);
            this.lblText3.Name = "lblText3";
            this.lblText3.Size = new System.Drawing.Size(50, 24);
            this.lblText3.TabIndex = 2;
            this.lblText3.Text = "Text 3";
            this.lblText3.UseCompatibleTextRendering = true;
            //
            // memText3
            //
            this.memText3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memText3.BackColor = System.Drawing.Color.White;
            this.memText3.DataMember = "Text3";
            this.memText3.DataSource = this.qryOrgUnit;
            this.memText3.Font = new System.Drawing.Font("Arial", 10F);
            this.memText3.Location = new System.Drawing.Point(61, 131);
            this.memText3.Name = "memText3";
            this.memText3.Size = new System.Drawing.Size(655, 58);
            this.memText3.TabIndex = 3;
            //
            // lblText4
            //
            this.lblText4.Location = new System.Drawing.Point(5, 194);
            this.lblText4.Name = "lblText4";
            this.lblText4.Size = new System.Drawing.Size(50, 24);
            this.lblText4.TabIndex = 4;
            this.lblText4.Text = "Text 4";
            this.lblText4.UseCompatibleTextRendering = true;
            //
            // memText4
            //
            this.memText4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memText4.BackColor = System.Drawing.Color.White;
            this.memText4.DataMember = "Text4";
            this.memText4.DataSource = this.qryOrgUnit;
            this.memText4.Font = new System.Drawing.Font("Arial", 10F);
            this.memText4.Location = new System.Drawing.Point(61, 194);
            this.memText4.Name = "memText4";
            this.memText4.Size = new System.Drawing.Size(655, 58);
            this.memText4.TabIndex = 5;
            //
            // lblText1
            //
            this.lblText1.Location = new System.Drawing.Point(5, 0);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(54, 24);
            this.lblText1.TabIndex = 14;
            this.lblText1.Text = "Text 1";
            this.lblText1.UseCompatibleTextRendering = true;
            //
            // memText
            //
            this.memText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memText.BackColor = System.Drawing.Color.White;
            this.memText.DataMember = "Text1";
            this.memText.DataSource = this.qryOrgUnit;
            this.memText.Font = new System.Drawing.Font("Arial", 10F);
            this.memText.Location = new System.Drawing.Point(61, 3);
            this.memText.Name = "memText";
            this.memText.Size = new System.Drawing.Size(651, 58);
            this.memText.TabIndex = 15;
            //
            // treOrgUnit
            //
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
                        this.colOrganisationseinheiten,
                        this.colLeitung,
                        this.colStellvertretung,
                        this.colKostenstelle});
            this.treOrgUnit.DataSource = this.qryOrgUnit;
            this.treOrgUnit.ImageIndexFieldName = "IconID";
            this.treOrgUnit.KeyFieldName = "OrgUnitID";
            this.treOrgUnit.Location = new System.Drawing.Point(5, 3);
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
            this.treOrgUnit.Size = new System.Drawing.Size(734, 310);
            this.treOrgUnit.TabIndex = 0;
            this.treOrgUnit.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treOrgUnit_GetSelectImage);
            this.treOrgUnit.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treOrgUnit_BeforeFocusNode);
            //
            // btnUp
            //
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(748, 74);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseCompatibleTextRendering = true;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.UpDown_Click);
            //
            // btnDown
            //
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(748, 104);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseCompatibleTextRendering = true;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.UpDown_Click);
            //
            // colKostenstelle
            //
            this.colKostenstelle.Caption = "KST";
            this.colKostenstelle.FieldName = "Kostenstelle";
            this.colKostenstelle.Name = "colKostenstelle";
            this.colKostenstelle.OptionsColumn.AllowSort = false;
            this.colKostenstelle.VisibleIndex = 3;
            this.colKostenstelle.Width = 63;
            //
            // colLeitung
            //
            this.colLeitung.Caption = "Leitung";
            this.colLeitung.FieldName = "Leitung";
            this.colLeitung.Name = "colLeitung";
            this.colLeitung.OptionsColumn.AllowSort = false;
            this.colLeitung.VisibleIndex = 1;
            this.colLeitung.Width = 130;
            //
            // colMayDelete
            //
            this.colMayDelete.Caption = "L";
            this.colMayDelete.FieldName = "MayDelete";
            this.colMayDelete.Name = "colMayDelete";
            this.colMayDelete.Visible = true;
            this.colMayDelete.VisibleIndex = 4;
            this.colMayDelete.Width = 20;
            //
            // colMayInsert
            //
            this.colMayInsert.Caption = "E";
            this.colMayInsert.FieldName = "MayInsert";
            this.colMayInsert.Name = "colMayInsert";
            this.colMayInsert.Visible = true;
            this.colMayInsert.VisibleIndex = 2;
            this.colMayInsert.Width = 20;
            //
            // colMayUpdate
            //
            this.colMayUpdate.Caption = "M";
            this.colMayUpdate.FieldName = "MayUpdate";
            this.colMayUpdate.Name = "colMayUpdate";
            this.colMayUpdate.Visible = true;
            this.colMayUpdate.VisibleIndex = 3;
            this.colMayUpdate.Width = 20;
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
            // colOrganisationseinheiten
            //
            this.colOrganisationseinheiten.Caption = "Organisationseinheiten";
            this.colOrganisationseinheiten.FieldName = "ItemName";
            this.colOrganisationseinheiten.Name = "colOrganisationseinheiten";
            this.colOrganisationseinheiten.OptionsColumn.AllowSort = false;
            this.colOrganisationseinheiten.VisibleIndex = 0;
            this.colOrganisationseinheiten.Width = 327;
            //
            // colStellvertretung
            //
            this.colStellvertretung.Caption = "Stellvertretung";
            this.colStellvertretung.FieldName = "Stellvertreter";
            this.colStellvertretung.Name = "colStellvertretung";
            this.colStellvertretung.OptionsColumn.AllowSort = false;
            this.colStellvertretung.VisibleIndex = 2;
            this.colStellvertretung.Width = 130;
            //
            // colUser
            //
            this.colUser.Caption = "OE-Mitglieder";
            this.colUser.FieldName = "UserName";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 198;
            //
            // colUser2
            //
            this.colUser2.Caption = "Kandidaten";
            this.colUser2.FieldName = "UserName";
            this.colUser2.Name = "colUser2";
            this.colUser2.Visible = true;
            this.colUser2.VisibleIndex = 0;
            this.colUser2.Width = 300;
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
            this.grvVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
                        this.colUser2});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
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
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
                        this.colUser,
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
            // qryKandidaten
            //
            this.qryKandidaten.HostControl = this;
            //
            // qryOrgUnit
            //
            this.qryOrgUnit.CanDelete = true;
            this.qryOrgUnit.CanInsert = true;
            this.qryOrgUnit.CanUpdate = true;
            this.qryOrgUnit.HostControl = this;
            this.qryOrgUnit.TableName = "XOrgUnit";
            this.qryOrgUnit.PositionChanged += new System.EventHandler(this.qryOrgUnit_PositionChanged);
            this.qryOrgUnit.BeforePost += new System.EventHandler(this.qryOrgUnit_BeforePost);
            this.qryOrgUnit.AfterPost += new System.EventHandler(this.qryOrgUnit_AfterPost);
            this.qryOrgUnit.BeforeDelete += new System.EventHandler(this.qryOrgUnit_BeforeDelete);
            //
            // qryZugeteilt
            //
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "XOrgUnit_User";
            this.qryZugeteilt.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryZugeteilt_ColumnChanged);
            this.qryZugeteilt.BeforePost += new System.EventHandler(this.qryZugeteilt_BeforePost);
            //
            // CtlOrgUnit
            //
            this.ActiveSQLQuery = this.qryOrgUnit;
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.treOrgUnit);
            this.Controls.Add(this.tabOrgUnit);
            this.Name = "CtlOrgUnit";
            this.Size = new System.Drawing.Size(788, 614);
            this.tabOrgUnit.ResumeLayout(false);
            this.tpgMitglieder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            this.tpgOrganisationseinheiten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrganisationseinheit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSLstv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserprofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserprofileCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserprofileCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSLstv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressblock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressblock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdAbteilung)).EndInit();
            this.tpgTexte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
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

        private void UpDown_Click(object sender, EventArgs e)
        {
            if (qryOrgUnit.Count == 0 || !qryOrgUnit.Post())
            {
                return;
            }

            SqlQuery qry;
            SqlQuery qryMax;
            Session.BeginTransaction();

            try
            {
                DBUtil.NewHistoryVersion();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryOrgUnit.Count == 0 || qryKandidaten.Count == 0 || !qryOrgUnit.Post(false))	// PerformEndEditControls
            {
                return;
            }

            qryZugeteilt.Insert();
            qryZugeteilt["OrgUnitID"] = qryOrgUnit["OrgUnitID"];
            qryZugeteilt["UserID"] = qryKandidaten["UserID"];

            //Default: als Mitglied eintragen, oder als Gast, wenn der Benutzer bereits Mitglied in einer anderen Abteilung
            var memberCount = (int)DBUtil.ExecuteScalarSQL("select count(*) from XOrgUnit_User where UserID = {0}", qryKandidaten["UserID"]);

            if (memberCount == 0)
            {
                qryZugeteilt["OrgUnitMemberCode"] = 2;  //Mitglied
            }
            else
            {
                qryZugeteilt["OrgUnitMemberCode"] = 3;  //Gast
            }

            qryZugeteilt.Post();
            qryOrgUnit.RowModified = false; //important!
            qryOrgUnit.Row.AcceptChanges();

            DisplayMembers();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (qryOrgUnit.Count == 0 || !qryOrgUnit.Post())
            {
                return;
            }

            DBUtil.NewHistoryVersion();
            DBUtil.ExecSQL(@"
                DELETE
                FROM dbo.XOrgUnit_User
                WHERE OrgUnitID = {0};", qryOrgUnit["OrgUnitID"]);

            DisplayMembers();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryZugeteilt.Count == 0)
            {
                return;
            }

            DBUtil.NewHistoryVersion();
            qryZugeteilt.Delete();
            DisplayMembers();
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            string Value = edtFilter.EditValue.ToString();
            qryKandidaten.DataTable.DefaultView.RowFilter = "UserName like '%" + Value + "%' ";
        }

        private void edtSL_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSL.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryOrgUnit["Leitung"] = dlg["Name"];
                qryOrgUnit["ChiefID"] = dlg["UserID"];
            }
        }

        private void edtSLstv_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSLstv.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryOrgUnit["Stellvertreter"] = dlg["Name"];
                qryOrgUnit["StellvertreterID"] = dlg["UserID"];
            }
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            if (this.btnAdd.Enabled)
                this.btnAdd.PerformClick();
        }

        private void grdZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            if (this.btnRemove.Enabled)
                this.btnRemove.PerformClick();
        }

        private void qryOrgUnit_AfterPost(object sender, EventArgs e)
        {
            DisplayMembers();
        }

        private void qryOrgUnit_BeforeDelete(object sender, EventArgs e)
        {
            if ((int)DBUtil.ExecuteScalarSQL("SELECT COUNT(*) FROM XOrgUnit WHERE ParentID = {0}", qryOrgUnit["OrgUnitID"]) > 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlOrgUnit", "UnterabteilungenBestehen", "Organisationseinheit kann nicht gelöscht werden, solange Unterorganisationen bestehen!", KissMsgCode.MsgInfo));
            }

            //Einträge in XOrgUnit_User löschen
            DBUtil.ExecSQL(@"
                DELETE
                FROM dbo.XOrgUnit_User
                WHERE OrgUnitID = {0};", qryOrgUnit["OrgUnitID"]);
        }

        private void qryOrgUnit_BeforePost(object sender, EventArgs e)
        {
            //DBUtil.CheckNotNullField(qryOrgUnit, "ItemName", KissMsg.GetMLMessage("CtlOrgUnit", "Organisationseinheit", "Organisationseinheit"), edtOrganisationseinheit);
            DBUtil.CheckNotNullField(edtOrganisationseinheit, "Organisationseinheit");

            //check duplicate ItemName
            var qry = DBUtil.OpenSQL(@"
                SELECT 1
                FROM XOrgUnit
                WHERE ItemName = {0}
                  AND OrgUnitID <> {1};", qryOrgUnit["ItemName"], qryOrgUnit["OrgUnitID"]);

            if (qry.Count > 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlOrgUnit", "AbteilungsnameBereitsVerwendet", "Dieser Organisationsname wird bereits verwendet!", KissMsgCode.MsgInfo));
            }

            //qryOrgUnit["Leitung"] = edtSL.Text;
            //qryOrgUnit["Stellvertreter"] = edtSLstv.Text;

            qryZugeteilt.Post(); //save pending changes

            DBUtil.NewHistoryVersion();
        }

        private void qryOrgUnit_PositionChanged(object sender, EventArgs e)
        {
            // reload lists of users and members
            DisplayMembers();
        }

        private void qryZugeteilt_BeforePost(object sender, EventArgs e)
        {
            // Neue Einträge werden unter btnAdd_Click automatisch erzeugt
            if (qryZugeteilt.Row.RowState == DataRowState.Added)
            {
                DBUtil.NewHistoryVersion();
                return;
            }

            // bei Änderung durch Benutzer: prüfen, ob keine Mehrfachmitgliedschaft ensteht
            if ((int)qryZugeteilt["OrgUnitMemberCode"] == 2)
            {
                var memberCount = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM XOrgUnit_User
                    WHERE UserID = {0}
                      AND OrgUnitMemberCode = 2
                      AND OrgUnitID <> {1};", qryZugeteilt["UserID"], qryOrgUnit["OrgUnitID"]);

                if (memberCount == 1)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "UnterabteilungenBestehen", "{0} ist bereits Mitglied in einer anderen Organisationseinheit!", KissMsgCode.MsgInfo, qryZugeteilt["UserName"]));
                }
            }

            DBUtil.NewHistoryVersion();
        }

        private void qryZugeteilt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryOrgUnit.RowModified = true;
        }

        private void treOrgUnit_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (firstLoop)
            {
                firstLoop = false;
                e.CanFocus = qryOrgUnit.Post();
                firstLoop = true;
            }
        }

        private void treOrgUnit_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            e.NodeImageIndex = Gui.KissImageList.GetImageIndex(215 + Math.Min(e.Node.Level, 3));
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            if (!qryOrgUnit.CanInsert || qryOrgUnit.Count > 0 && !qryOrgUnit.Post())
            {
                return false;
            }

            string newName = GetNewAbteilungName();
            int newPos = 1;

            if (qryOrgUnit.Count > 0)
            {
                newPos = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(max(ParentPosition) + 1, 1)
                    FROM dbo.XOrgUnit
                    WHERE ParentID = {0};", qryOrgUnit["OrgUnitID"]);
            }

            var creatorModifier = DBUtil.GetDBRowCreatorModifier();

            DBUtil.NewHistoryVersion();
            DBUtil.ExecSQL(@"
                INSERT INTO dbo.XOrgUnit (ParentID, ParentPosition, ItemName, Creator, Modifier)
                VALUES ({0}, {1}, {2}, {3}, {4});", qryOrgUnit.Count == 0 ? DBNull.Value : qryOrgUnit["OrgUnitID"], newPos, newName, creatorModifier, creatorModifier);

            RefreshTree(newName);

            return true;
        }

        #endregion

        #region Private Methods

        private void DisplayMembers()
        {
            qryZugeteilt.Fill(@"
                select OUU.*, USR.Lastname + isnull(', ' + Firstname,'') + ' (' + LogonName + ')' UserName
                from   XOrgUnit_User OUU
                       inner join XUser USR on USR.UserID = OUU.UserID
                where  OUU.OrgUnitID = {0} and
                       OUU.OrgUnitMemberCode in (2,3)
                order by OUU.OrgUnitMemberCode, UserName",
                qryOrgUnit["OrgUnitID"]);

            qryKandidaten.Fill(@"
                select USR.UserID, USR.Lastname + isnull(', ' + Firstname,'') + ' (' + LogonName + ')' UserName
                from   XUser USR
                       left join XOrgUnit_User OUU on OUU.UserID = USR.UserID and
                                                      OUU.OrgUnitID = {0}
                where  OUU.OrgUnitID is null
                order by UserName",
                qryOrgUnit["OrgUnitID"]);
        }

        private string GetNewAbteilungName()
        {
            int idx = 0;
            string name;
            SqlQuery qry = null;

            do
            {
                idx++;
                name = "Organisation" + idx.ToString();
                qry = DBUtil.OpenSQL("SELECT 1 FROM XOrgUnit WHERE ItemName = {0}", name);
            }
            while (qry.Count > 0);

            return name;
        }

        private void RefreshTree(string Name)
        {
            treOrgUnit.DataSource = null;
            qryOrgUnit.Refresh();
            treOrgUnit.DataSource = qryOrgUnit;

            treOrgUnit.ExpandAll();

            //locate new Abteilung
            TreeListNode node = DBUtil.FindNodeByValue(treOrgUnit.Nodes, Name, "ItemName");
            if (node != null)
            {
                treOrgUnit.FocusedNode = node;
            }
        }

        #endregion

        #endregion
    }
}