using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.BDE
{
    public class CtlBDEGruppen : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colUsers;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegbar;
        private DevExpress.XtraGrid.Columns.GridColumn colZugeteilt;
        private System.ComponentModel.IContainer components;
        private bool dataHasChanged = false;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEditML edtUserGroupName;
        private KiSS4.Gui.KissGrid grdBDEUserGroup;
        private KiSS4.Gui.KissGrid grdUsers;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDEUserGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private bool isInRefresh = true;
        private KiSS4.Gui.KissLabel lblBeschreibung;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissMemoEdit memBeschreibung;
        private System.Windows.Forms.Panel panContent;
        private KiSS4.DB.SqlQuery qryBDEUserGroup;
        private KiSS4.DB.SqlQuery qryUser;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTabControlEx tabBottom;
        private SharpLibrary.WinControls.TabPageEx tpgRights;
        private SharpLibrary.WinControls.TabPageEx tpgUsers;

        #endregion

        #region Constructors

        public CtlBDEGruppen()
        {
            this.InitializeComponent();

            // set dock to panel (due to strange behaviour in business desinger, we do it here)
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;

            // setup rights
            SetupRights();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBDEGruppen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panContent = new System.Windows.Forms.Panel();
            this.grdBDEUserGroup = new KiSS4.Gui.KissGrid();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtUserGroupName = new KiSS4.Gui.KissTextEditML();
            this.lblBeschreibung = new KiSS4.Gui.KissLabel();
            this.memBeschreibung = new KiSS4.Gui.KissMemoEdit();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabBottom = new KiSS4.Gui.KissTabControlEx();
            this.tpgRights = new SharpLibrary.WinControls.TabPageEx();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.tpgUsers = new SharpLibrary.WinControls.TabPageEx();
            this.grdUsers = new KiSS4.Gui.KissGrid();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerfuegbar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugeteilt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBDEUserGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBDEUserGroup = new KiSS4.DB.SqlQuery(this.components);
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBeschreibung.Properties)).BeginInit();
            this.tabBottom.SuspendLayout();
            this.tpgRights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            this.tpgUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            this.SuspendLayout();
            //
            // panContent
            //
            this.panContent.Controls.Add(this.memBeschreibung);
            this.panContent.Controls.Add(this.lblBeschreibung);
            this.panContent.Controls.Add(this.edtUserGroupName);
            this.panContent.Controls.Add(this.lblName);
            this.panContent.Controls.Add(this.grdBDEUserGroup);
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(744, 248);
            this.panContent.TabIndex = 0;
            //
            // grdBDEUserGroup
            //
            this.grdBDEUserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBDEUserGroup.DataSource = this.qryBDEUserGroup;
            this.grdBDEUserGroup.EmbeddedNavigator.Name = "";
            this.grdBDEUserGroup.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDEUserGroup.Location = new System.Drawing.Point(3, 3);
            this.grdBDEUserGroup.MainView = this.grvBDEUserGroup;
            this.grdBDEUserGroup.Name = "grdBDEUserGroup";
            this.grdBDEUserGroup.Size = new System.Drawing.Size(738, 133);
            this.grdBDEUserGroup.TabIndex = 0;
            this.grdBDEUserGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvBDEUserGroup});
            //
            // lblName
            //
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Location = new System.Drawing.Point(6, 142);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // edtUserGroupName
            //
            this.edtUserGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserGroupName.ApplyChangesToDefaultText = false;
            this.edtUserGroupName.DataMember = null;
            this.edtUserGroupName.DataMemberDefaultText = "UserGroupName";
            this.edtUserGroupName.DataMemberTID = "UserGroupNameTID";
            this.edtUserGroupName.DataSource = this.qryBDEUserGroup;
            this.edtUserGroupName.Location = new System.Drawing.Point(99, 142);
            this.edtUserGroupName.Name = "edtUserGroupName";
            this.edtUserGroupName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserGroupName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserGroupName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserGroupName.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserGroupName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserGroupName.Properties.Appearance.Options.UseFont = true;
            this.edtUserGroupName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserGroupName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUserGroupName.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserGroupName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserGroupName.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtUserGroupName.ShowOnlyDefaultLanguage = true;
            this.edtUserGroupName.Size = new System.Drawing.Size(639, 24);
            this.edtUserGroupName.TabIndex = 2;
            this.edtUserGroupName.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserGroupName_UserModifiedFld);
            //
            // lblBeschreibung
            //
            this.lblBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBeschreibung.Location = new System.Drawing.Point(6, 172);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(87, 24);
            this.lblBeschreibung.TabIndex = 3;
            this.lblBeschreibung.Text = "Beschreibung";
            this.lblBeschreibung.UseCompatibleTextRendering = true;
            //
            // memBeschreibung
            //
            this.memBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBeschreibung.DataMember = "Beschreibung";
            this.memBeschreibung.DataSource = this.qryBDEUserGroup;
            this.memBeschreibung.Location = new System.Drawing.Point(99, 172);
            this.memBeschreibung.Margin = new System.Windows.Forms.Padding(4);
            this.memBeschreibung.Name = "memBeschreibung";
            this.memBeschreibung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBeschreibung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBeschreibung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBeschreibung.Properties.Appearance.Options.UseBackColor = true;
            this.memBeschreibung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBeschreibung.Properties.Appearance.Options.UseFont = true;
            this.memBeschreibung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBeschreibung.Size = new System.Drawing.Size(639, 70);
            this.memBeschreibung.TabIndex = 4;
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabBottom;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 269);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // tabBottom
            //
            this.tabBottom.Controls.Add(this.tpgUsers);
            this.tabBottom.Controls.Add(this.tpgRights);
            this.tabBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabBottom.Location = new System.Drawing.Point(0, 277);
            this.tabBottom.Name = "tabBottom";
            this.tabBottom.ShowFixedWidthTooltip = true;
            this.tabBottom.Size = new System.Drawing.Size(750, 273);
            this.tabBottom.TabIndex = 2;
            this.tabBottom.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgRights,
                        this.tpgUsers});
            this.tabBottom.TabsLineColor = System.Drawing.Color.Black;
            this.tabBottom.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            //
            // tpgRights
            //
            this.tpgRights.Controls.Add(this.grdZugeteilt);
            this.tpgRights.Controls.Add(this.btnRemoveAll);
            this.tpgRights.Controls.Add(this.btnAddAll);
            this.tpgRights.Controls.Add(this.btnRemove);
            this.tpgRights.Controls.Add(this.btnAdd);
            this.tpgRights.Controls.Add(this.grdVerfuegbar);
            this.tpgRights.Controls.Add(this.edtFilter);
            this.tpgRights.Controls.Add(this.lblFilter);
            this.tpgRights.Location = new System.Drawing.Point(6, 6);
            this.tpgRights.Name = "tpgRights";
            this.tpgRights.Size = new System.Drawing.Size(738, 235);
            this.tpgRights.TabIndex = 0;
            this.tpgRights.Title = "Rechte";
            //
            // lblFilter
            //
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilter.Location = new System.Drawing.Point(4, 206);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            //
            // edtFilter
            //
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilter.Location = new System.Drawing.Point(65, 206);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(264, 24);
            this.edtFilter.TabIndex = 1;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            //
            // grdVerfuegbar
            //
            this.grdVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(4, 4);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(325, 199);
            this.grdVerfuegbar.TabIndex = 2;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            //
            // btnAdd
            //
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(342, 27);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnRemove
            //
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(342, 57);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnAddAll
            //
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(342, 87);
            this.btnAddAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 5;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(342, 117);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // grdZugeteilt
            //
            this.grdZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(383, 4);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(325, 226);
            this.grdZugeteilt.TabIndex = 7;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            //
            // tpgUsers
            //
            this.tpgUsers.Controls.Add(this.grdUsers);
            this.tpgUsers.Location = new System.Drawing.Point(6, 6);
            this.tpgUsers.Name = "tpgUsers";
            this.tpgUsers.Size = new System.Drawing.Size(738, 235);
            this.tpgUsers.TabIndex = 1;
            this.tpgUsers.Title = "Benutzer";
            //
            // grdUsers
            //
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUsers.DataSource = this.qryUser;
            this.grdUsers.EmbeddedNavigator.Name = "";
            this.grdUsers.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUsers.Location = new System.Drawing.Point(4, 4);
            this.grdUsers.MainView = this.grvUsers;
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(731, 226);
            this.grdUsers.TabIndex = 0;
            this.grdUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvUsers});
            //
            // colDescription
            //
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Beschreibung";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 380;
            //
            // colOrgUnit
            //
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.FieldName = "OrgUnit";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 1;
            this.colOrgUnit.Width = 200;
            //
            // colUserGroupName
            //
            this.colUserGroupName.Caption = "Name";
            this.colUserGroupName.FieldName = "UserGroupName";
            this.colUserGroupName.Name = "colUserGroupName";
            this.colUserGroupName.Visible = true;
            this.colUserGroupName.VisibleIndex = 0;
            this.colUserGroupName.Width = 256;
            //
            // colUsers
            //
            this.colUsers.Caption = "Benutzer/in";
            this.colUsers.FieldName = "UserName";
            this.colUsers.Name = "colUsers";
            this.colUsers.Visible = true;
            this.colUsers.VisibleIndex = 0;
            this.colUsers.Width = 400;
            //
            // colVerfuegbar
            //
            this.colVerfuegbar.Caption = "Verfügbare Leistungsarten";
            this.colVerfuegbar.FieldName = "BezeichnungML";
            this.colVerfuegbar.Name = "colVerfuegbar";
            this.colVerfuegbar.Visible = true;
            this.colVerfuegbar.VisibleIndex = 0;
            this.colVerfuegbar.Width = 285;
            //
            // colZugeteilt
            //
            this.colZugeteilt.Caption = "Zugeteilte Leistungsarten";
            this.colZugeteilt.FieldName = "BezeichnungML";
            this.colZugeteilt.Name = "colZugeteilt";
            this.colZugeteilt.Visible = true;
            this.colZugeteilt.VisibleIndex = 0;
            this.colZugeteilt.Width = 286;
            //
            // grvBDEUserGroup
            //
            this.grvBDEUserGroup.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDEUserGroup.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.Empty.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEUserGroup.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDEUserGroup.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDEUserGroup.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEUserGroup.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDEUserGroup.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDEUserGroup.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEUserGroup.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEUserGroup.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDEUserGroup.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEUserGroup.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDEUserGroup.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDEUserGroup.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDEUserGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDEUserGroup.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDEUserGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDEUserGroup.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEUserGroup.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDEUserGroup.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEUserGroup.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.OddRow.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDEUserGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.Row.Options.UseBackColor = true;
            this.grvBDEUserGroup.Appearance.Row.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEUserGroup.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDEUserGroup.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEUserGroup.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDEUserGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDEUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colUserGroupName,
                        this.colDescription});
            this.grvBDEUserGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDEUserGroup.GridControl = this.grdBDEUserGroup;
            this.grvBDEUserGroup.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBDEUserGroup.Name = "grvBDEUserGroup";
            this.grvBDEUserGroup.OptionsBehavior.Editable = false;
            this.grvBDEUserGroup.OptionsCustomization.AllowFilter = false;
            this.grvBDEUserGroup.OptionsFilter.AllowFilterEditor = false;
            this.grvBDEUserGroup.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDEUserGroup.OptionsMenu.EnableColumnMenu = false;
            this.grvBDEUserGroup.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDEUserGroup.OptionsNavigation.UseTabKey = false;
            this.grvBDEUserGroup.OptionsView.ColumnAutoWidth = false;
            this.grvBDEUserGroup.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDEUserGroup.OptionsView.ShowGroupPanel = false;
            this.grvBDEUserGroup.OptionsView.ShowIndicator = false;
            //
            // grvUsers
            //
            this.grvUsers.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUsers.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.Empty.Options.UseBackColor = true;
            this.grvUsers.Appearance.Empty.Options.UseFont = true;
            this.grvUsers.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.EvenRow.Options.UseFont = true;
            this.grvUsers.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUsers.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvUsers.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUsers.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUsers.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUsers.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUsers.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvUsers.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUsers.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUsers.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUsers.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUsers.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUsers.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUsers.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.GroupRow.Options.UseFont = true;
            this.grvUsers.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUsers.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUsers.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUsers.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUsers.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUsers.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUsers.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvUsers.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUsers.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUsers.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUsers.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvUsers.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUsers.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.OddRow.Options.UseFont = true;
            this.grvUsers.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvUsers.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.Row.Options.UseBackColor = true;
            this.grvUsers.Appearance.Row.Options.UseFont = true;
            this.grvUsers.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUsers.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvUsers.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUsers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colUsers,
                        this.colOrgUnit});
            this.grvUsers.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUsers.GridControl = this.grdUsers;
            this.grvUsers.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvUsers.Name = "grvUsers";
            this.grvUsers.OptionsBehavior.Editable = false;
            this.grvUsers.OptionsCustomization.AllowFilter = false;
            this.grvUsers.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUsers.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUsers.OptionsNavigation.UseTabKey = false;
            this.grvUsers.OptionsView.ColumnAutoWidth = false;
            this.grvUsers.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUsers.OptionsView.ShowGroupPanel = false;
            this.grvUsers.OptionsView.ShowIndicator = false;
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
                        this.colVerfuegbar});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.AllowFilterEditor = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsMenu.EnableColumnMenu = false;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsSelection.MultiSelect = true;
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
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
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
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colZugeteilt});
            this.grvZugeteilt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsBehavior.Editable = false;
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.AllowFilterEditor = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsMenu.EnableColumnMenu = false;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsNavigation.UseTabKey = false;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            this.grvZugeteilt.OptionsView.ShowIndicator = false;
            //
            // qryBDEUserGroup
            //
            this.qryBDEUserGroup.AutoApplyUserRights = false;
            this.qryBDEUserGroup.HostControl = this;
            this.qryBDEUserGroup.SelectStatement = "select * from BDEUserGroup order by UserGroupName";
            this.qryBDEUserGroup.TableName = "BDEUserGroup";
            this.qryBDEUserGroup.BeforePost += new System.EventHandler(this.qryBDEUserGroup_BeforePost);
            this.qryBDEUserGroup.PositionChanged += new System.EventHandler(this.qryBDEUserGroup_PositionChanged);
            this.qryBDEUserGroup.AfterInsert += new System.EventHandler(this.qryBDEUserGroup_AfterInsert);
            this.qryBDEUserGroup.PositionChanging += new System.EventHandler(this.qryBDEUserGroup_PositionChanging);
            //
            // qryUser
            //
            this.qryUser.HostControl = this;
            //
            // qryVerfuegbar
            //
            this.qryVerfuegbar.HostControl = this;
            //
            // qryZugeteilt
            //
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "BDEUserGroup_BDELeistungsart";
            //
            // CtlBDEGruppen
            //
            this.ActiveSQLQuery = this.qryBDEUserGroup;
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.tabBottom);
            this.Name = "CtlBDEGruppen";
            this.Size = new System.Drawing.Size(750, 550);
            this.Load += new System.EventHandler(this.CtlBDEGruppen_Load);
            this.panContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBeschreibung.Properties)).EndInit();
            this.tabBottom.ResumeLayout(false);
            this.tpgRights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            this.tpgUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
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

        #region Private Methods

        private void CtlBDEGruppen_Load(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // select first tab
                tabBottom.SelectTab(this.tpgRights);

                // remove delete question
                qryZugeteilt.DeleteQuestion = null;

                // query data
                qryBDEUserGroup.Fill(@"
                    -- setup var and default value
                    DECLARE @langColumns nvarchar(1000)
                    DECLARE @sqlString nvarchar(1000)
                    SET @langColumns = ''
                    SET @sqlString = ''

                    -- get all languages as [Deutsch],[Englisch], ... including subquery for text
                    SELECT @langColumns = @langColumns+'['+CONVERT(VARCHAR(255), LOV.Text)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = BUG.UserGroupNameTID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),'
                    FROM XLOVCode LOV
                    WHERE LOV.LOVName = 'Sprache' AND LOV.Text NOT LIKE '%]%'
                    GROUP BY LOV.Text, LOV.Code, LOV.SortKey
                    ORDER BY LOV.SortKey ASC

                    -- validate for empty
                    IF (@langColumns IS NULL OR @langColumns = '')
                    BEGIN
                      SET @langColumns = 'NoLang = 1,'
                    END

                    -- remove last comma and prepare string
                    SELECT @langColumns = LEFT(@langColumns, LEN(@langColumns) - 1)

                    -- create query to execute with all language columns
                    SET @sqlString = 'SELECT DISTINCT
                                     BUG.*,
                                     ' + @langColumns + '
                              FROM BDEUserGroup BUG
                                LEFT JOIN XLangText TXT ON TXT.TID = BUG.UserGroupNameTID
                                LEFT JOIN XLOVCode LOV ON LOV.Code = TXT.LanguageCode AND LOVName = ''Sprache''
                              ORDER BY BUG.UserGroupName'

                    -- execute query and show data
                    EXEC(@sqlString)");

                // init validation counter
                int colsAdded = 0;

                // requerst all languages and append columns
                SqlQuery qryLanguages = DBUtil.OpenSQL(@"SELECT DefaultText = LOV.Text
                                     FROM XLOVCode LOV
                                     WHERE LOV.LOVName = 'Sprache'
                                     ORDER BY LOV.SortKey ASC");

                // loop through language items and add columns to grid
                foreach (System.Data.DataRow row in qryLanguages.DataTable.Rows)
                {
                    // setup vars
                    string defaultText = (string)row["DefaultText"];

                    // check if column for this language exists
                    if (qryBDEUserGroup.DataTable.Columns.Contains(defaultText))
                    {
                        // column found in messages, create new column
                        DevExpress.XtraGrid.Columns.GridColumn newCol = new DevExpress.XtraGrid.Columns.GridColumn();
                        newCol.FieldName = defaultText;
                        newCol.Caption = defaultText;
                        newCol.Width = 200;
                        newCol.VisibleIndex = grvBDEUserGroup.Columns.Count;

                        // add column to view
                        grvBDEUserGroup.Columns.Add(newCol);
                        colsAdded++;
                    }
                }

                // validate
                if (colsAdded != qryLanguages.Count && qryBDEUserGroup.Count > 0)
                {
                    throw new Exception(string.Format(@"Es konnten nicht alle Spalten in die Darstellung übernommen werden ('{0}' von '{1}' Spalten)", colsAdded, qryLanguages.Count));
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("CtlBDEGruppen", "ErrorLoadingData", "Fehler bei der Verarbeitung. Die Daten werden womöglich nicht korrekt dargestellt.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;

                // reset flags
                this.isInRefresh = false;
            }
        }

        private void DataHasChanged()
        {
            // set flag
            this.dataHasChanged = true;
        }

        private void DisplayLeistungsarten(bool refreshVerfuegbar, bool refreshZugeteilt)
        {
            if (refreshZugeteilt)
            {
                qryZugeteilt.Fill(@"
                    SELECT	GRL.*,
                        BezeichnungML = dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {1}, LEI.Bezeichnung)
                    FROM	BDEUserGroup_BDELeistungsart GRL
                      INNER JOIN BDELeistungsart LEI ON LEI.BDELeistungsartID = GRL.BDELeistungsartID
                    WHERE	GRL.BDEUserGroupID = {0}
                    ORDER BY LEI.SortKey, BezeichnungML", qryBDEUserGroup["BDEUserGroupID"], Session.User.LanguageCode);
            }

            if (refreshVerfuegbar)
            {
                qryVerfuegbar.Fill(@"
                    SELECT	LEI.BDELeistungsartID,
                        BezeichnungML = dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {1}, LEI.Bezeichnung)
                    FROM	BDELeistungsart LEI
                      LEFT JOIN BDEUserGroup_BDELeistungsart GRL ON GRL.BDELeistungsartID = LEI.BDELeistungsartID AND GRL.BDEUserGroupID = {0}
                    WHERE	GRL.BDEUserGroupID IS NULL
                    ORDER BY LEI.SortKey, BezeichnungML", qryBDEUserGroup["BDEUserGroupID"], Session.User.LanguageCode);
            }
        }

        private void DisplayUser()
        {
            qryUser.Fill(@"
                SELECT  UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, USR.Firstname) + ISNULL(' (' + LogonName + ')', ''),
                    OrgUnit  = dbo.fnOrgUnitOfUser(USR.UserID, 0)
                FROM   XUser_BDEUserGroup UUG
                  INNER JOIN XUser USR ON USR.UserID = UUG.UserID
                WHERE  UUG.BDEUserGroupID = {0}
                ORDER BY UserName", qryBDEUserGroup["BDEUserGroupID"]);
        }

        private void SetupRights()
        {
            // VARS
            bool isAdmin = Session.User.IsUserAdmin;
            bool canReadData = false;
            bool canBDEUserGroupInsert = false;
            bool canBDEUserGroupUpdate = false;
            bool canBDEUserGroupDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canBDEUserGroupInsert, out canBDEUserGroupUpdate, out canBDEUserGroupDelete);
            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // BDEGROUP
            qryBDEUserGroup.CanInsert = isAdmin || canBDEUserGroupInsert;
            qryBDEUserGroup.CanUpdate = isAdmin || canBDEUserGroupUpdate;
            qryBDEUserGroup.CanDelete = isAdmin || canBDEUserGroupDelete;

            // VERFUEGBAR:
            // qryVerfuegbar is always readonly
            qryVerfuegbar.CanInsert = false;
            qryVerfuegbar.CanUpdate = false;
            qryVerfuegbar.CanDelete = false;

            qryZugeteilt.CanInsert = qryBDEUserGroup.CanUpdate;
            qryZugeteilt.CanUpdate = qryBDEUserGroup.CanUpdate;
            qryZugeteilt.CanDelete = qryBDEUserGroup.CanUpdate;

            //  buttons and grid
            btnAdd.Enabled = qryZugeteilt.CanUpdate;
            btnAddAll.Enabled = qryZugeteilt.CanUpdate;
            btnRemove.Enabled = qryZugeteilt.CanUpdate;
            btnRemoveAll.Enabled = qryZugeteilt.CanUpdate;

            // FIELDS
            qryBDEUserGroup.EnableBoundFields();
            qryVerfuegbar.EnableBoundFields();
            qryZugeteilt.EnableBoundFields();
        }

        private void btnAddAll_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnAddAll.Enabled || qryVerfuegbar.Count == 0 || qryBDEUserGroup.Count == 0 || !qryBDEUserGroup.Post())
            {
                return;
            }

            // remove all entries and reinsert again
            DBUtil.ExecSQL("DELETE FROM BDEUserGroup_BDELeistungsart WHERE BDEUserGroupID = {0}", qryBDEUserGroup["BDEUserGroupID"]);
            DBUtil.ExecSQL("INSERT BDEUserGroup_BDELeistungsart (BDEUserGroupID, BDELeistungsartID) SELECT {0}, BDELeistungsartID FROM BDELeistungsart", qryBDEUserGroup["BDEUserGroupID"]);

            // refresh list
            DisplayLeistungsarten(true, true);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnAdd.Enabled || qryBDEUserGroup.Count == 0 || qryVerfuegbar.Count == 0 || !qryBDEUserGroup.Post())
            {
                return;
            }

            // get all selected rows
            int[] RowHandles = grdVerfuegbar.View.GetSelectedRows();
            if (RowHandles == null)
            {
                return;
            }

            // insert all rows the user selected
            foreach (int RowHandle in RowHandles)
            {
                DataRowView viewVerfuegbar = ((System.Data.DataRowView)grdVerfuegbar.View.GetRow(RowHandle));

                qryZugeteilt.Insert();
                qryZugeteilt["BDEUserGroupID"] = qryBDEUserGroup["BDEUserGroupID"];
                qryZugeteilt["BDELeistungsartID"] = viewVerfuegbar.Row["BDELeistungsartID"];
                qryZugeteilt.Post();
            }

            // refresh list
            DisplayLeistungsarten(true, true);

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnRemoveAll.Enabled || qryZugeteilt.Count == 0 || qryBDEUserGroup.Count == 0 || !qryBDEUserGroup.Post())
            {
                return;
            }

            // remove all items
            DBUtil.ExecSQL("DELETE FROM BDEUserGroup_BDELeistungsart WHERE BDEUserGroupID = {0}", qryBDEUserGroup["BDEUserGroupID"]);

            // refresh lists
            DisplayLeistungsarten(true, true);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnRemove.Enabled || qryZugeteilt.Count == 0)
            {
                return;
            }

            // delete current item
            qryZugeteilt.Delete();

            // refresh lists
            DisplayLeistungsarten(true, false);
        }

        private void edtFilter_EditValueChanged(object sender, System.EventArgs e)
        {
            qryVerfuegbar.DataTable.DefaultView.RowFilter = string.Format("BezeichnungML LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void edtUserGroupName_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            this.DataHasChanged();
        }

        private void grdVerfuegbar_DoubleClick(object sender, System.EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void grdZugeteilt_DoubleClick(object sender, System.EventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void qryBDEUserGroup_AfterInsert(object sender, System.EventArgs e)
        {
            // set focus
            edtUserGroupName.Focus();
        }

        private void qryBDEUserGroup_BeforePost(object sender, System.EventArgs e)
        {
            // check mustfields
            DBUtil.CheckNotNullField(edtUserGroupName, lblName.Text);

            // setup values
            qryBDEUserGroup["UserGroupName"] = edtUserGroupName.EditValue;
        }

        private void qryBDEUserGroup_PositionChanged(object sender, System.EventArgs e)
        {
            DisplayLeistungsarten(true, true);

            DisplayUser();
        }

        private void qryBDEUserGroup_PositionChanging(object sender, System.EventArgs e)
        {
            // check if need to refresh data
            if (this.dataHasChanged && !this.isInRefresh)
            {
                try
                {
                    this.isInRefresh = true;
                    qryBDEUserGroup.Refresh();
                }
                finally
                {
                    // reset flags
                    this.isInRefresh = false;
                    this.dataHasChanged = false;
                }
            }
        }

        #endregion
    }
}