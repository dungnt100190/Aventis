using System;
using System.Data;
using KiSS4.DB;

namespace KiSS4.BDE
{
    public class CtlBDEGruppenzuteilung : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissCheckEdit chkSucheNurAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsArt;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungserbringerVerfuegbar;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungserbringerZugeteilt;
        private DevExpress.XtraGrid.Columns.GridColumn colLogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtSucheAbteilung;
        private KiSS4.Gui.KissTextEdit edtSucheLogon;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissCalcEdit edtSucheUserID;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissGrid grdLeistungsart;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdXUser;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLeistungsart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblSucheAbteilung;
        private KiSS4.Gui.KissLabel lblSucheLogon;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheUserID;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.DB.SqlQuery qryLeistungsart;
        private KiSS4.DB.SqlQuery qryUser;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTabControlEx tabBottom;
        private SharpLibrary.WinControls.TabPageEx tpgLeistungsarten;
        private SharpLibrary.WinControls.TabPageEx tpgLeistungsgruppen;

        #endregion

        #region Constructors

        public CtlBDEGruppenzuteilung()
        {
            this.InitializeComponent();

            // setup rights
            this.SetupRights();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBDEGruppenzuteilung));
            this.grdXUser = new KiSS4.Gui.KissGrid();
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            this.grvXUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheLogon = new KiSS4.Gui.KissLabel();
            this.edtSucheLogon = new KiSS4.Gui.KissTextEdit();
            this.lblSucheUserID = new KiSS4.Gui.KissLabel();
            this.edtSucheUserID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheAbteilung = new KiSS4.Gui.KissLabel();
            this.edtSucheAbteilung = new KiSS4.Gui.KissTextEdit();
            this.chkSucheNurAdmin = new KiSS4.Gui.KissCheckEdit();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabBottom = new KiSS4.Gui.KissTabControlEx();
            this.tpgLeistungsarten = new SharpLibrary.WinControls.TabPageEx();
            this.grdLeistungsart = new KiSS4.Gui.KissGrid();
            this.qryLeistungsart = new KiSS4.DB.SqlQuery(this.components);
            this.grvLeistungsart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLeistungsArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgLeistungsgruppen = new SharpLibrary.WinControls.TabPageEx();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLeistungserbringerZugeteilt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLeistungserbringerVerfuegbar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdXUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLogon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLogon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAdmin.Properties)).BeginInit();
            this.tabBottom.SuspendLayout();
            this.tpgLeistungsarten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLeistungsart)).BeginInit();
            this.tpgLeistungsgruppen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(726, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(750, 265);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdXUser);
            this.tpgListe.Size = new System.Drawing.Size(738, 227);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.chkSucheNurAdmin);
            this.tpgSuchen.Controls.Add(this.edtSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.lblSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.edtSucheUserID);
            this.tpgSuchen.Controls.Add(this.lblSucheUserID);
            this.tpgSuchen.Controls.Add(this.edtSucheLogon);
            this.tpgSuchen.Controls.Add(this.lblSucheLogon);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(738, 227);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLogon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLogon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurAdmin, 0);
            //
            // grdXUser
            //
            this.grdXUser.DataSource = this.qryUser;
            this.grdXUser.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdXUser.EmbeddedNavigator.Name = "";
            this.grdXUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXUser.Location = new System.Drawing.Point(0, 0);
            this.grdXUser.MainView = this.grvXUser;
            this.grdXUser.Name = "grdXUser";
            this.grdXUser.Size = new System.Drawing.Size(738, 227);
            this.grdXUser.TabIndex = 0;
            this.grdXUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXUser});
            //
            // qryUser
            //
            this.qryUser.HostControl = this;
            this.qryUser.SelectStatement = resources.GetString("qryUser.SelectStatement");
            this.qryUser.TableName = "XUser";
            this.qryUser.PositionChanged += new System.EventHandler(this.qryUser_PositionChanged);
            //
            // grvXUser
            //
            this.grvXUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvXUser.Appearance.Empty.Options.UseFont = true;
            this.grvXUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvXUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvXUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.OddRow.Options.UseFont = true;
            this.grvXUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.Row.Options.UseBackColor = true;
            this.grvXUser.Appearance.Row.Options.UseFont = true;
            this.grvXUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colLogonName,
            this.colLastName,
            this.colFirstName,
            this.colOrgUnit});
            this.grvXUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXUser.GridControl = this.grdXUser;
            this.grvXUser.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvXUser.Name = "grvXUser";
            this.grvXUser.OptionsBehavior.Editable = false;
            this.grvXUser.OptionsCustomization.AllowFilter = false;
            this.grvXUser.OptionsFilter.AllowFilterEditor = false;
            this.grvXUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXUser.OptionsMenu.EnableColumnMenu = false;
            this.grvXUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXUser.OptionsNavigation.UseTabKey = false;
            this.grvXUser.OptionsView.ColumnAutoWidth = false;
            this.grvXUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXUser.OptionsView.ShowGroupPanel = false;
            this.grvXUser.OptionsView.ShowIndicator = false;
            //
            // colUserID
            //
            this.colUserID.Caption = "Nr.";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            this.colUserID.Width = 50;
            //
            // colLogonName
            //
            this.colLogonName.Caption = "Logon";
            this.colLogonName.FieldName = "LogonName";
            this.colLogonName.Name = "colLogonName";
            this.colLogonName.Visible = true;
            this.colLogonName.VisibleIndex = 1;
            this.colLogonName.Width = 100;
            //
            // colLastName
            //
            this.colLastName.Caption = "Name";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            this.colLastName.Width = 150;
            //
            // colFirstName
            //
            this.colFirstName.Caption = "Vorname";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 3;
            this.colFirstName.Width = 150;
            //
            // colOrgUnit
            //
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.FieldName = "Abteilung";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 4;
            this.colOrgUnit.Width = 200;
            //
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(9, 39);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(64, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // edtSucheName
            //
            this.edtSucheName.Location = new System.Drawing.Point(79, 39);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(172, 24);
            this.edtSucheName.TabIndex = 2;
            //
            // lblSucheVorname
            //
            this.lblSucheVorname.Location = new System.Drawing.Point(9, 69);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(64, 24);
            this.lblSucheVorname.TabIndex = 3;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            //
            // edtSucheVorname
            //
            this.edtSucheVorname.Location = new System.Drawing.Point(79, 69);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(172, 24);
            this.edtSucheVorname.TabIndex = 4;
            //
            // lblSucheLogon
            //
            this.lblSucheLogon.Location = new System.Drawing.Point(8, 99);
            this.lblSucheLogon.Name = "lblSucheLogon";
            this.lblSucheLogon.Size = new System.Drawing.Size(64, 24);
            this.lblSucheLogon.TabIndex = 5;
            this.lblSucheLogon.Text = "Logon";
            this.lblSucheLogon.UseCompatibleTextRendering = true;
            //
            // edtSucheLogon
            //
            this.edtSucheLogon.Location = new System.Drawing.Point(79, 99);
            this.edtSucheLogon.Name = "edtSucheLogon";
            this.edtSucheLogon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLogon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLogon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLogon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLogon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLogon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLogon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLogon.Size = new System.Drawing.Size(72, 24);
            this.edtSucheLogon.TabIndex = 6;
            //
            // lblSucheUserID
            //
            this.lblSucheUserID.Location = new System.Drawing.Point(8, 129);
            this.lblSucheUserID.Name = "lblSucheUserID";
            this.lblSucheUserID.Size = new System.Drawing.Size(64, 24);
            this.lblSucheUserID.TabIndex = 7;
            this.lblSucheUserID.Text = "Nr.";
            this.lblSucheUserID.UseCompatibleTextRendering = true;
            //
            // edtSucheUserID
            //
            this.edtSucheUserID.Location = new System.Drawing.Point(79, 129);
            this.edtSucheUserID.Name = "edtSucheUserID";
            this.edtSucheUserID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheUserID.Size = new System.Drawing.Size(71, 24);
            this.edtSucheUserID.TabIndex = 8;
            //
            // lblSucheAbteilung
            //
            this.lblSucheAbteilung.Location = new System.Drawing.Point(9, 159);
            this.lblSucheAbteilung.Name = "lblSucheAbteilung";
            this.lblSucheAbteilung.Size = new System.Drawing.Size(64, 24);
            this.lblSucheAbteilung.TabIndex = 9;
            this.lblSucheAbteilung.Text = "Abteilung";
            this.lblSucheAbteilung.UseCompatibleTextRendering = true;
            //
            // edtSucheAbteilung
            //
            this.edtSucheAbteilung.Location = new System.Drawing.Point(79, 159);
            this.edtSucheAbteilung.Name = "edtSucheAbteilung";
            this.edtSucheAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAbteilung.Size = new System.Drawing.Size(172, 24);
            this.edtSucheAbteilung.TabIndex = 10;
            //
            // chkSucheNurAdmin
            //
            this.chkSucheNurAdmin.EditValue = false;
            this.chkSucheNurAdmin.Location = new System.Drawing.Point(79, 189);
            this.chkSucheNurAdmin.Name = "chkSucheNurAdmin";
            this.chkSucheNurAdmin.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurAdmin.Properties.Caption = "nur Administratoren";
            this.chkSucheNurAdmin.Size = new System.Drawing.Size(172, 19);
            this.chkSucheNurAdmin.TabIndex = 11;
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabBottom;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 265);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // tabBottom
            //
            this.tabBottom.Controls.Add(this.tpgLeistungsarten);
            this.tabBottom.Controls.Add(this.tpgLeistungsgruppen);
            this.tabBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabBottom.Location = new System.Drawing.Point(0, 273);
            this.tabBottom.Name = "tabBottom";
            this.tabBottom.SelectedTabIndex = 1;
            this.tabBottom.ShowFixedWidthTooltip = true;
            this.tabBottom.Size = new System.Drawing.Size(750, 277);
            this.tabBottom.TabIndex = 2;
            this.tabBottom.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgLeistungsgruppen,
            this.tpgLeistungsarten});
            this.tabBottom.TabsLineColor = System.Drawing.Color.Black;
            this.tabBottom.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            //
            // tpgLeistungsarten
            //
            this.tpgLeistungsarten.Controls.Add(this.grdLeistungsart);
            this.tpgLeistungsarten.Location = new System.Drawing.Point(6, 6);
            this.tpgLeistungsarten.Name = "tpgLeistungsarten";
            this.tpgLeistungsarten.Size = new System.Drawing.Size(738, 239);
            this.tpgLeistungsarten.TabIndex = 3;
            this.tpgLeistungsarten.Title = "Leistungsarten";
            //
            // grdLeistungsart
            //
            this.grdLeistungsart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLeistungsart.DataSource = this.qryLeistungsart;
            //
            //
            //
            this.grdLeistungsart.EmbeddedNavigator.Name = "";
            this.grdLeistungsart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdLeistungsart.Location = new System.Drawing.Point(4, 4);
            this.grdLeistungsart.MainView = this.grvLeistungsart;
            this.grdLeistungsart.Margin = new System.Windows.Forms.Padding(4);
            this.grdLeistungsart.Name = "grdLeistungsart";
            this.grdLeistungsart.Size = new System.Drawing.Size(730, 231);
            this.grdLeistungsart.TabIndex = 0;
            this.grdLeistungsart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLeistungsart});
            //
            // qryLeistungsart
            //
            this.qryLeistungsart.SelectStatement = resources.GetString("qryLeistungsart.SelectStatement");
            //
            // grvLeistungsart
            //
            this.grvLeistungsart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvLeistungsart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.Empty.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.Empty.Options.UseFont = true;
            this.grvLeistungsart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.EvenRow.Options.UseFont = true;
            this.grvLeistungsart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvLeistungsart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvLeistungsart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvLeistungsart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvLeistungsart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvLeistungsart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvLeistungsart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvLeistungsart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvLeistungsart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLeistungsart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLeistungsart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLeistungsart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLeistungsart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.GroupRow.Options.UseFont = true;
            this.grvLeistungsart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvLeistungsart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvLeistungsart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvLeistungsart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLeistungsart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvLeistungsart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLeistungsart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvLeistungsart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLeistungsart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvLeistungsart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvLeistungsart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvLeistungsart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.OddRow.Options.UseFont = true;
            this.grvLeistungsart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvLeistungsart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.Row.Options.UseBackColor = true;
            this.grvLeistungsart.Appearance.Row.Options.UseFont = true;
            this.grvLeistungsart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistungsart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvLeistungsart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvLeistungsart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvLeistungsart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvLeistungsart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLeistungsArt});
            this.grvLeistungsart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvLeistungsart.GridControl = this.grdLeistungsart;
            this.grvLeistungsart.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvLeistungsart.Name = "grvLeistungsart";
            this.grvLeistungsart.OptionsBehavior.Editable = false;
            this.grvLeistungsart.OptionsCustomization.AllowFilter = false;
            this.grvLeistungsart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvLeistungsart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvLeistungsart.OptionsNavigation.UseTabKey = false;
            this.grvLeistungsart.OptionsView.ColumnAutoWidth = false;
            this.grvLeistungsart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvLeistungsart.OptionsView.ShowGroupPanel = false;
            this.grvLeistungsart.OptionsView.ShowIndicator = false;
            //
            // colLeistungsArt
            //
            this.colLeistungsArt.Caption = "Leistungsart";
            this.colLeistungsArt.FieldName = "BezeichnungML";
            this.colLeistungsArt.Name = "colLeistungsArt";
            this.colLeistungsArt.Visible = true;
            this.colLeistungsArt.VisibleIndex = 0;
            this.colLeistungsArt.Width = 702;
            //
            // tpgLeistungsgruppen
            //
            this.tpgLeistungsgruppen.Controls.Add(this.grdZugeteilt);
            this.tpgLeistungsgruppen.Controls.Add(this.btnRemoveAll);
            this.tpgLeistungsgruppen.Controls.Add(this.btnAddAll);
            this.tpgLeistungsgruppen.Controls.Add(this.btnRemove);
            this.tpgLeistungsgruppen.Controls.Add(this.btnAdd);
            this.tpgLeistungsgruppen.Controls.Add(this.grdVerfuegbar);
            this.tpgLeistungsgruppen.Controls.Add(this.edtFilter);
            this.tpgLeistungsgruppen.Controls.Add(this.lblFilter);
            this.tpgLeistungsgruppen.Location = new System.Drawing.Point(6, 6);
            this.tpgLeistungsgruppen.Name = "tpgLeistungsgruppen";
            this.tpgLeistungsgruppen.Size = new System.Drawing.Size(738, 239);
            this.tpgLeistungsgruppen.TabIndex = 0;
            this.tpgLeistungsgruppen.Title = "Leistungsgruppen";
            //
            // grdZugeteilt
            //
            this.grdZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            //
            //
            //
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(385, 4);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Margin = new System.Windows.Forms.Padding(4);
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(325, 231);
            this.grdZugeteilt.TabIndex = 7;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            //
            // qryZugeteilt
            //
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            this.qryZugeteilt.TableName = "XUser_BDEUserGroup";
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
            this.colLeistungserbringerZugeteilt});
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
            // colLeistungserbringerZugeteilt
            //
            this.colLeistungserbringerZugeteilt.Caption = "Zugeteilte Gruppen";
            this.colLeistungserbringerZugeteilt.FieldName = "BezeichnungML";
            this.colLeistungserbringerZugeteilt.Name = "colLeistungserbringerZugeteilt";
            this.colLeistungserbringerZugeteilt.Visible = true;
            this.colLeistungserbringerZugeteilt.VisibleIndex = 0;
            this.colLeistungserbringerZugeteilt.Width = 285;
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(343, 114);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // btnAddAll
            //
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(343, 84);
            this.btnAddAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 5;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            //
            // btnRemove
            //
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(343, 54);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnAdd
            //
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(343, 24);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // grdVerfuegbar
            //
            this.grdVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            //
            //
            //
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(4, 4);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Margin = new System.Windows.Forms.Padding(4);
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(325, 203);
            this.grdVerfuegbar.TabIndex = 2;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            //
            // qryVerfuegbar
            //
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.SelectStatement = resources.GetString("qryVerfuegbar.SelectStatement");
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
            this.colLeistungserbringerVerfuegbar,
            this.colUserGroupID});
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
            // colLeistungserbringerVerfuegbar
            //
            this.colLeistungserbringerVerfuegbar.Caption = "Verfügbare Gruppen";
            this.colLeistungserbringerVerfuegbar.FieldName = "BezeichnungML";
            this.colLeistungserbringerVerfuegbar.Name = "colLeistungserbringerVerfuegbar";
            this.colLeistungserbringerVerfuegbar.Visible = true;
            this.colLeistungserbringerVerfuegbar.VisibleIndex = 0;
            this.colLeistungserbringerVerfuegbar.Width = 285;
            //
            // colUserGroupID
            //
            this.colUserGroupID.Caption = "-";
            this.colUserGroupID.FieldName = "BDEUserGroupID";
            this.colUserGroupID.Name = "colUserGroupID";
            //
            // edtFilter
            //
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilter.Location = new System.Drawing.Point(65, 211);
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
            // lblFilter
            //
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilter.Location = new System.Drawing.Point(4, 211);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            //
            // CtlBDEGruppenzuteilung
            //
            this.ActiveSQLQuery = this.qryUser;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.tabBottom);
            this.Name = "CtlBDEGruppenzuteilung";
            this.Size = new System.Drawing.Size(750, 550);
            this.Load += new System.EventHandler(this.CtlBDEGruppenzuteilung_Load);
            this.Controls.SetChildIndex(this.tabBottom, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdXUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLogon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLogon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAdmin.Properties)).EndInit();
            this.tabBottom.ResumeLayout(false);
            this.tpgLeistungsarten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLeistungsart)).EndInit();
            this.tpgLeistungsgruppen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
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

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtSucheName.Focus();
        }

        #endregion

        #region Private Methods

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnAdd.Enabled || qryUser.Count == 0 || qryVerfuegbar.Count == 0 || !qryUser.Post())
            {
                return;
            }

            // get all rows the user selected
            int[] RowHandles = grdVerfuegbar.View.GetSelectedRows();
            if (RowHandles == null)
            {
                return;
            }

            // add all rows the user selected
            foreach (int RowHandle in RowHandles)
            {
                qryZugeteilt.Insert();
                qryZugeteilt["UserID"] = qryUser["UserID"];
                qryZugeteilt["BDEUserGroupID"] = grdVerfuegbar.View.GetRowCellValue(RowHandle, grdVerfuegbar.View.Columns["BDEUserGroupID"]);
                qryZugeteilt.Post();
            }

            // refresh lists
            DisplayGroups(true, true);

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnAddAll_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnAddAll.Enabled || qryUser.Count == 0 || qryVerfuegbar.Count == 0)
            {
                return;
            }
            if (qryUser.Row.RowState == DataRowState.Added && !qryUser.Post())
            {
                return;
            }

            // remove and reinsert all entries
            DBUtil.ExecSQL("DELETE FROM XUser_BDEUserGroup WHERE UserID = {0}", qryUser["UserID"]);
            DBUtil.ExecSQL(@"INSERT XUser_BDEUserGroup (UserID, BDEUserGroupID)
                               SELECT {0}, BDEUserGroupID from BDEUserGroup", qryUser["UserID"]);

            // refresh lists
            DisplayGroups(true, true);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnRemove.Enabled || qryUser.Count == 0 || qryZugeteilt.Count == 0 || qryUser.Row.RowState == DataRowState.Added)
            {
                return;
            }

            // remove current entry
            qryZugeteilt.Delete();

            // refresh lists
            DisplayGroups(true, false);
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnRemoveAll.Enabled || qryUser.Count == 0 || qryZugeteilt.Count == 0 || qryUser.Row.RowState == DataRowState.Added)
            {
                return;
            }

            // remove all entries
            DBUtil.ExecSQL("DELETE FROM XUser_BDEUserGroup WHERE UserID = {0}", qryUser["UserID"]);

            // refresh lists
            DisplayGroups(true, true);
        }

        private void CtlBDEGruppenzuteilung_Load(object sender, System.EventArgs e)
        {
            // remove delete question
            qryZugeteilt.DeleteQuestion = null;

            // init control with a new search and run it
            NewSearch();
            tabControlSearch.SelectedTabIndex = 0;
            tabBottom.SelectedTabIndex = 0;
        }

        private void DisplayGroups(bool refreshVerfuegbar, bool refreshZugeteilt)
        {
            if (refreshZugeteilt)
            {
                qryZugeteilt.Fill(@"
                    SELECT 	UUG.*,
                        BezeichnungML = dbo.fnGetMLTextByDefault(UGR.UserGroupNameTID, {1}, UGR.UserGroupName)
                    FROM   XUser_BDEUserGroup UUG
                      INNER JOIN BDEUserGroup UGR ON UGR.BDEUserGroupID = UUG.BDEUserGroupID
                    WHERE  UUG.UserID = {0}
                    ORDER BY BezeichnungML", qryUser["UserID"], Session.User.LanguageCode);
            }

            if (refreshVerfuegbar)
            {
                qryVerfuegbar.Fill(@"
                    SELECT 	UGR.BDEUserGroupID,
                        BezeichnungML = dbo.fnGetMLTextByDefault(UGR.UserGroupNameTID, {1}, UGR.UserGroupName)
                    FROM   BDEUserGroup UGR
                      LEFT JOIN XUser_BDEUserGroup UUG ON UUG.BDEUserGroupID = UGR.BDEUserGroupID AND UUG.UserID = {0}
                    WHERE  UUG.BDEUserGroupID IS NULL
                    ORDER BY BezeichnungML", qryUser["UserID"], Session.User.LanguageCode);
            }

            DisplayLeistungsarten();
        }

        private void DisplayLeistungsarten()
        {
            qryLeistungsart.Fill(@"
                SELECT	LEI.Bezeichnung,
                    BezeichnungML = dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {1}, LEI.Bezeichnung),
                    LEI.SortKey
                FROM	BDEUserGroup_BDELeistungsart UGR
                  INNER JOIN BDELeistungsart LEI ON LEI.BDELeistungsartID = UGR.BDELeistungsartID
                WHERE	BDEUserGroupID IN (SELECT BDEUserGroupID FROM XUser_BDEUserGroup WHERE UserID = {0})
                GROUP BY LEI.Bezeichnung, LEI.SortKey, LEI.BezeichnungTID
                ORDER BY LEI.SortKey, BezeichnungML", qryUser["UserID"], Session.User.LanguageCode);

            grdLeistungsart.DataSource = null;
            grdLeistungsart.DataSource = qryLeistungsart;
        }

        private void edtFilter_EditValueChanged(object sender, System.EventArgs e)
        {
            qryVerfuegbar.DataTable.DefaultView.RowFilter = string.Format("BezeichnungML LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void grdVerfuegbar_DoubleClick(object sender, System.EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void grdZugeteilt_DoubleClick(object sender, System.EventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void qryUser_PositionChanged(object sender, System.EventArgs e)
        {
            // refresh lists
            DisplayGroups(true, true);
        }

        private void SetupRights()
        {
            // VARS
            bool isAdmin = Session.User.IsUserAdmin;
            bool canReadData = false;
            bool canBDEGroupAssignInsert = false;
            bool canBDEGroupAssignUpdate = false;
            bool canBDEGroupAssignDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canBDEGroupAssignInsert, out canBDEGroupAssignUpdate, out canBDEGroupAssignDelete);
            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception(KissMsg.GetMLMessage(Name, "NoRightViewControl", "No rights to view details of this control.", KissMsgCode.MsgError));
            }

            // LEISTUNGSART
            // qryLeistungsart is always readonly
            qryLeistungsart.CanInsert = false;
            qryLeistungsart.CanUpdate = false;
            qryLeistungsart.CanDelete = false;

            // USER
            // qryUser is always readonly
            qryUser.CanInsert = false;
            qryUser.CanUpdate = false;
            qryUser.CanDelete = false;

            // VERFUEGBAR:
            // qryVerfuegbar is always readonly
            qryVerfuegbar.CanInsert = false;
            qryVerfuegbar.CanUpdate = false;
            qryVerfuegbar.CanDelete = false;

            // ZUGETEILT
            qryZugeteilt.CanInsert = isAdmin || canBDEGroupAssignUpdate;
            qryZugeteilt.CanUpdate = isAdmin || canBDEGroupAssignUpdate;
            qryZugeteilt.CanDelete = isAdmin || canBDEGroupAssignUpdate;

            //  buttons and grid
            btnAdd.Enabled = qryZugeteilt.CanUpdate;
            btnAddAll.Enabled = qryZugeteilt.CanUpdate;
            btnRemove.Enabled = qryZugeteilt.CanUpdate;
            btnRemoveAll.Enabled = qryZugeteilt.CanUpdate;

            // FIELDS
            qryLeistungsart.EnableBoundFields();
            qryUser.EnableBoundFields();
            qryVerfuegbar.EnableBoundFields();
            qryZugeteilt.EnableBoundFields();
        }

        #endregion
    }
}