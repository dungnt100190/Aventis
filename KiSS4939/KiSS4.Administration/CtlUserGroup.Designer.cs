using System.Windows.Forms;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    partial class CtlUserGroup
    {
        #region Private Fields

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KissButton btnRemoveAllUsers;
        private KiSS4.Gui.KissCheckEdit chkNurFuerAdminSichtbar;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colMayDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colMayInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colMayUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colOnlyAdminVisible;
        private DevExpress.XtraGrid.Columns.GridColumn colRightID;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2OrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserText;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissGrid grdUserGroup;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdXUser;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblUserGroupName;
        private Panel panContent;
        private Panel panRightsAvailable;
        private Panel panRightsAvailableAddRemove;
        private Panel panRightsAvailableFilter;
        private TableLayoutPanel panRightsTable;
        private Panel panUserRight;
        private KiSS4.DB.SqlQuery qryUser;
        private KiSS4.DB.SqlQuery qryUserGroup;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTabControlEx tabControl;
        private SharpLibrary.WinControls.TabPageEx tpgBenutzer;
        private SharpLibrary.WinControls.TabPageEx tpgRechte;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlUserGroup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panContent = new System.Windows.Forms.Panel();
            this.edtDescription = new KiSS4.Gui.KissMemoEditML();
            this.qryUserGroup = new KiSS4.DB.SqlQuery(this.components);
            this.edtUserGroupName = new KiSS4.Gui.KissTextEditML();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.chkNurFuerAdminSichtbar = new KiSS4.Gui.KissCheckEdit();
            this.lblUserGroupName = new KiSS4.Gui.KissLabel();
            this.grdUserGroup = new KiSS4.Gui.KissGrid();
            this.grvUserGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnlyAdminVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabControl = new KiSS4.Gui.KissTabControlEx();
            this.tpgBenutzer = new SharpLibrary.WinControls.TabPageEx();
            this.grdXUser = new KiSS4.Gui.KissGrid();
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            this.grvXUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser2OrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserIsLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panUserRight = new System.Windows.Forms.Panel();
            this.btnRemoveAllUsers = new KiSS4.Gui.KissButton();
            this.tpgRechte = new SharpLibrary.WinControls.TabPageEx();
            this.panRightsTable = new System.Windows.Forms.TableLayoutPanel();
            this.panRightsAvailable = new System.Windows.Forms.Panel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRightID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaskName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panRightsAvailableFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panRightsAvailableAddRemove = new System.Windows.Forms.Panel();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.colXClassID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurFuerAdminSichtbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserGroup)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpgBenutzer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdXUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUser)).BeginInit();
            this.panUserRight.SuspendLayout();
            this.tpgRechte.SuspendLayout();
            this.panRightsTable.SuspendLayout();
            this.panRightsAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            this.panRightsAvailableFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            this.panRightsAvailableAddRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // panContent
            // 
            this.panContent.Controls.Add(this.edtDescription);
            this.panContent.Controls.Add(this.edtUserGroupName);
            this.panContent.Controls.Add(this.lblDescription);
            this.panContent.Controls.Add(this.chkNurFuerAdminSichtbar);
            this.panContent.Controls.Add(this.lblUserGroupName);
            this.panContent.Controls.Add(this.grdUserGroup);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(750, 269);
            this.panContent.TabIndex = 0;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDescription.DataMemberDefaultText = "Description";
            this.edtDescription.DataMemberTID = "DescriptionTID";
            this.edtDescription.DataSource = this.qryUserGroup;
            this.edtDescription.Location = new System.Drawing.Point(103, 205);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(641, 56);
            this.edtDescription.TabIndex = 5;
            this.edtDescription.WriteLocked = false;
            // 
            // qryUserGroup
            // 
            this.qryUserGroup.CanDelete = true;
            this.qryUserGroup.CanInsert = true;
            this.qryUserGroup.CanUpdate = true;
            this.qryUserGroup.HostControl = this;
            this.qryUserGroup.SelectStatement = "SELECT *\r\nFROM XUserGroup\r\nORDER BY UserGroupName";
            this.qryUserGroup.TableName = "XUserGroup";
            this.qryUserGroup.AfterInsert += new System.EventHandler(this.qryUserGroup_AfterInsert);
            this.qryUserGroup.BeforePost += new System.EventHandler(this.qryUserGroup_BeforePost);
            this.qryUserGroup.PostCompleted += new System.EventHandler(this.qryUserGroup_PostCompleted);
            this.qryUserGroup.PositionChanging += new System.EventHandler(this.qryUserGroup_PositionChanging);
            this.qryUserGroup.PositionChanged += new System.EventHandler(this.qryUserGroup_PositionChanged);
            // 
            // edtUserGroupName
            // 
            this.edtUserGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserGroupName.DataMember = null;
            this.edtUserGroupName.DataMemberDefaultText = "UserGroupName";
            this.edtUserGroupName.DataMemberTID = "UserGroupNameTID";
            this.edtUserGroupName.DataSource = this.qryUserGroup;
            this.edtUserGroupName.Location = new System.Drawing.Point(103, 149);
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
            this.edtUserGroupName.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserGroupName.Size = new System.Drawing.Size(641, 24);
            this.edtUserGroupName.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.Location = new System.Drawing.Point(9, 205);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(88, 24);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Beschreibung";
            this.lblDescription.UseCompatibleTextRendering = true;
            // 
            // chkNurFuerAdminSichtbar
            // 
            this.chkNurFuerAdminSichtbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNurFuerAdminSichtbar.DataMember = "OnlyAdminVisible";
            this.chkNurFuerAdminSichtbar.DataSource = this.qryUserGroup;
            this.chkNurFuerAdminSichtbar.Location = new System.Drawing.Point(103, 180);
            this.chkNurFuerAdminSichtbar.Name = "chkNurFuerAdminSichtbar";
            this.chkNurFuerAdminSichtbar.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkNurFuerAdminSichtbar.Properties.Appearance.Options.UseBackColor = true;
            this.chkNurFuerAdminSichtbar.Properties.Caption = "Rolle nur für Administrator sichtbar";
            this.chkNurFuerAdminSichtbar.Size = new System.Drawing.Size(285, 19);
            this.chkNurFuerAdminSichtbar.TabIndex = 3;
            // 
            // lblUserGroupName
            // 
            this.lblUserGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUserGroupName.Location = new System.Drawing.Point(9, 146);
            this.lblUserGroupName.Name = "lblUserGroupName";
            this.lblUserGroupName.Size = new System.Drawing.Size(88, 24);
            this.lblUserGroupName.TabIndex = 1;
            this.lblUserGroupName.Text = "Name";
            this.lblUserGroupName.UseCompatibleTextRendering = true;
            // 
            // grdUserGroup
            // 
            this.grdUserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUserGroup.DataSource = this.qryUserGroup;
            // 
            // 
            // 
            this.grdUserGroup.EmbeddedNavigator.Name = "";
            this.grdUserGroup.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUserGroup.Location = new System.Drawing.Point(3, 3);
            this.grdUserGroup.MainView = this.grvUserGroup;
            this.grdUserGroup.Name = "grdUserGroup";
            this.grdUserGroup.Size = new System.Drawing.Size(744, 140);
            this.grdUserGroup.TabIndex = 0;
            this.grdUserGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserGroup});
            // 
            // grvUserGroup
            // 
            this.grvUserGroup.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUserGroup.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.Empty.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.Empty.Options.UseFont = true;
            this.grvUserGroup.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.EvenRow.Options.UseFont = true;
            this.grvUserGroup.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUserGroup.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvUserGroup.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUserGroup.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUserGroup.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUserGroup.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvUserGroup.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUserGroup.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUserGroup.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUserGroup.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUserGroup.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUserGroup.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUserGroup.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.GroupRow.Options.UseFont = true;
            this.grvUserGroup.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUserGroup.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUserGroup.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUserGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUserGroup.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUserGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUserGroup.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvUserGroup.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUserGroup.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUserGroup.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUserGroup.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvUserGroup.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.OddRow.Options.UseFont = true;
            this.grvUserGroup.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvUserGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.Row.Options.UseBackColor = true;
            this.grvUserGroup.Appearance.Row.Options.UseFont = true;
            this.grvUserGroup.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserGroup.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUserGroup.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvUserGroup.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUserGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserGroupName,
            this.colOnlyAdminVisible,
            this.colDescription});
            this.grvUserGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUserGroup.GridControl = this.grdUserGroup;
            this.grvUserGroup.Name = "grvUserGroup";
            this.grvUserGroup.OptionsBehavior.Editable = false;
            this.grvUserGroup.OptionsCustomization.AllowFilter = false;
            this.grvUserGroup.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUserGroup.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUserGroup.OptionsNavigation.UseTabKey = false;
            this.grvUserGroup.OptionsView.ColumnAutoWidth = false;
            this.grvUserGroup.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUserGroup.OptionsView.ShowGroupPanel = false;
            this.grvUserGroup.OptionsView.ShowIndicator = false;
            // 
            // colUserGroupName
            // 
            this.colUserGroupName.Caption = "Name";
            this.colUserGroupName.Name = "colUserGroupName";
            this.colUserGroupName.Visible = true;
            this.colUserGroupName.VisibleIndex = 0;
            this.colUserGroupName.Width = 300;
            // 
            // colOnlyAdminVisible
            // 
            this.colOnlyAdminVisible.Caption = "Admin";
            this.colOnlyAdminVisible.Name = "colOnlyAdminVisible";
            this.colOnlyAdminVisible.Visible = true;
            this.colOnlyAdminVisible.VisibleIndex = 1;
            this.colOnlyAdminVisible.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 350;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabControl;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 269);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpgBenutzer);
            this.tabControl.Controls.Add(this.tpgRechte);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 277);
            this.tabControl.Name = "tabControl";
            this.tabControl.ShowFixedWidthTooltip = true;
            this.tabControl.Size = new System.Drawing.Size(750, 273);
            this.tabControl.TabIndex = 2;
            this.tabControl.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgRechte,
            this.tpgBenutzer});
            this.tabControl.TabsLineColor = System.Drawing.Color.Black;
            this.tabControl.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControl.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControl_SelectedTabChanged);
            // 
            // tpgBenutzer
            // 
            this.tpgBenutzer.Controls.Add(this.grdXUser);
            this.tpgBenutzer.Controls.Add(this.panUserRight);
            this.tpgBenutzer.Location = new System.Drawing.Point(6, 6);
            this.tpgBenutzer.Name = "tpgBenutzer";
            this.tpgBenutzer.Size = new System.Drawing.Size(738, 235);
            this.tpgBenutzer.TabIndex = 1;
            this.tpgBenutzer.Title = "Benutzer";
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
            this.grdXUser.Margin = new System.Windows.Forms.Padding(4);
            this.grdXUser.Name = "grdXUser";
            this.grdXUser.Size = new System.Drawing.Size(708, 235);
            this.grdXUser.TabIndex = 0;
            this.grdXUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXUser});
            // 
            // qryUser
            // 
            this.qryUser.HostControl = this;
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
            this.colUser2,
            this.colUser2OrgUnit,
            this.colUserIsLocked,
            this.colUserEmail});
            this.grvXUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXUser.GridControl = this.grdXUser;
            this.grvXUser.Name = "grvXUser";
            this.grvXUser.OptionsBehavior.Editable = false;
            this.grvXUser.OptionsCustomization.AllowFilter = false;
            this.grvXUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXUser.OptionsNavigation.UseTabKey = false;
            this.grvXUser.OptionsView.ColumnAutoWidth = false;
            this.grvXUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXUser.OptionsView.ShowGroupPanel = false;
            this.grvXUser.OptionsView.ShowIndicator = false;
            // 
            // colUser2
            // 
            this.colUser2.Caption = "Benutzer/-in";
            this.colUser2.FieldName = "UserName";
            this.colUser2.Name = "colUser2";
            this.colUser2.Visible = true;
            this.colUser2.VisibleIndex = 0;
            this.colUser2.Width = 300;
            // 
            // colUser2OrgUnit
            // 
            this.colUser2OrgUnit.Caption = "Abteilung";
            this.colUser2OrgUnit.FieldName = "OrgUnit";
            this.colUser2OrgUnit.Name = "colUser2OrgUnit";
            this.colUser2OrgUnit.Visible = true;
            this.colUser2OrgUnit.VisibleIndex = 1;
            this.colUser2OrgUnit.Width = 200;
            // 
            // colUserIsLocked
            // 
            this.colUserIsLocked.Caption = "Gesperrt";
            this.colUserIsLocked.Name = "colUserIsLocked";
            this.colUserIsLocked.Visible = true;
            this.colUserIsLocked.VisibleIndex = 2;
            this.colUserIsLocked.Width = 65;
            // 
            // colUserEmail
            // 
            this.colUserEmail.Caption = "Email";
            this.colUserEmail.Name = "colUserEmail";
            this.colUserEmail.Visible = true;
            this.colUserEmail.VisibleIndex = 3;
            this.colUserEmail.Width = 200;
            // 
            // panUserRight
            // 
            this.panUserRight.Controls.Add(this.btnRemoveAllUsers);
            this.panUserRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panUserRight.Location = new System.Drawing.Point(708, 0);
            this.panUserRight.Name = "panUserRight";
            this.panUserRight.Size = new System.Drawing.Size(30, 235);
            this.panUserRight.TabIndex = 1;
            this.panUserRight.TabStop = true;
            // 
            // btnRemoveAllUsers
            // 
            this.btnRemoveAllUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAllUsers.Enabled = false;
            this.btnRemoveAllUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAllUsers.IconID = 4;
            this.btnRemoveAllUsers.Location = new System.Drawing.Point(3, 3);
            this.btnRemoveAllUsers.Name = "btnRemoveAllUsers";
            this.btnRemoveAllUsers.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveAllUsers.TabIndex = 0;
            this.btnRemoveAllUsers.UseVisualStyleBackColor = false;
            this.btnRemoveAllUsers.Click += new System.EventHandler(this.btnRemoveAllUsers_Click);
            // 
            // tpgRechte
            // 
            this.tpgRechte.Controls.Add(this.panRightsTable);
            this.tpgRechte.Location = new System.Drawing.Point(6, 6);
            this.tpgRechte.Name = "tpgRechte";
            this.tpgRechte.Size = new System.Drawing.Size(738, 235);
            this.tpgRechte.TabIndex = 0;
            this.tpgRechte.Title = "Rechte";
            // 
            // panRightsTable
            // 
            this.panRightsTable.ColumnCount = 3;
            this.panRightsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panRightsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panRightsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panRightsTable.Controls.Add(this.panRightsAvailable, 0, 0);
            this.panRightsTable.Controls.Add(this.grdZugeteilt, 2, 0);
            this.panRightsTable.Controls.Add(this.panRightsAvailableAddRemove, 1, 0);
            this.panRightsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightsTable.Location = new System.Drawing.Point(0, 0);
            this.panRightsTable.Name = "panRightsTable";
            this.panRightsTable.RowCount = 1;
            this.panRightsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panRightsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panRightsTable.Size = new System.Drawing.Size(738, 235);
            this.panRightsTable.TabIndex = 0;
            // 
            // panRightsAvailable
            // 
            this.panRightsAvailable.Controls.Add(this.grdVerfuegbar);
            this.panRightsAvailable.Controls.Add(this.panRightsAvailableFilter);
            this.panRightsAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightsAvailable.Location = new System.Drawing.Point(3, 3);
            this.panRightsAvailable.Name = "panRightsAvailable";
            this.panRightsAvailable.Size = new System.Drawing.Size(333, 229);
            this.panRightsAvailable.TabIndex = 1;
            // 
            // grdVerfuegbar
            // 
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
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
            this.grdVerfuegbar.Size = new System.Drawing.Size(333, 195);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.HostControl = this;
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
            this.colUserText,
            this.colUserGroupID,
            this.colClassName,
            this.colRightID,
            this.colMaskName,
            this.colXClassID});
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
            // colUserText
            // 
            this.colUserText.Caption = "Verfügbare Rechte";
            this.colUserText.FieldName = "UserText";
            this.colUserText.Name = "colUserText";
            this.colUserText.Visible = true;
            this.colUserText.VisibleIndex = 0;
            this.colUserText.Width = 270;
            // 
            // colUserGroupID
            // 
            this.colUserGroupID.Caption = "-";
            this.colUserGroupID.FieldName = "UserGroupID";
            this.colUserGroupID.Name = "colUserGroupID";
            // 
            // colClassName
            // 
            this.colClassName.Caption = "-";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.Name = "colClassName";
            // 
            // colRightID
            // 
            this.colRightID.Caption = "-";
            this.colRightID.FieldName = "RightID";
            this.colRightID.Name = "colRightID";
            // 
            // colMaskName
            // 
            this.colMaskName.Caption = "-";
            this.colMaskName.FieldName = "MaskName";
            this.colMaskName.Name = "colMaskName";
            // 
            // panRightsAvailableFilter
            // 
            this.panRightsAvailableFilter.Controls.Add(this.lblFilter);
            this.panRightsAvailableFilter.Controls.Add(this.edtFilter);
            this.panRightsAvailableFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panRightsAvailableFilter.Location = new System.Drawing.Point(0, 195);
            this.panRightsAvailableFilter.Name = "panRightsAvailableFilter";
            this.panRightsAvailableFilter.Size = new System.Drawing.Size(333, 34);
            this.panRightsAvailableFilter.TabIndex = 1;
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
            this.edtFilter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(270, 24);
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
            this.grdZugeteilt.Location = new System.Drawing.Point(403, 4);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Margin = new System.Windows.Forms.Padding(4);
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(331, 227);
            this.grdZugeteilt.TabIndex = 3;
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
            this.qryZugeteilt.TableName = "XUserGroup_Right";
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
            this.colUser,
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
            // colUser
            // 
            this.colUser.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colUser.AppearanceCell.Options.UseBackColor = true;
            this.colUser.Caption = "Zugeteilte Rechte";
            this.colUser.FieldName = "UserText";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 265;
            // 
            // colMayInsert
            // 
            this.colMayInsert.Caption = "E";
            this.colMayInsert.FieldName = "MayInsert";
            this.colMayInsert.Name = "colMayInsert";
            this.colMayInsert.OptionsColumn.AllowSize = false;
            this.colMayInsert.OptionsColumn.FixedWidth = true;
            this.colMayInsert.Visible = true;
            this.colMayInsert.VisibleIndex = 1;
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
            this.colMayUpdate.VisibleIndex = 2;
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
            this.colMayDelete.VisibleIndex = 3;
            this.colMayDelete.Width = 20;
            // 
            // panRightsAvailableAddRemove
            // 
            this.panRightsAvailableAddRemove.Controls.Add(this.btnAdd);
            this.panRightsAvailableAddRemove.Controls.Add(this.btnRemoveAll);
            this.panRightsAvailableAddRemove.Controls.Add(this.btnRemove);
            this.panRightsAvailableAddRemove.Controls.Add(this.btnAddAll);
            this.panRightsAvailableAddRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightsAvailableAddRemove.Location = new System.Drawing.Point(339, 0);
            this.panRightsAvailableAddRemove.Margin = new System.Windows.Forms.Padding(0);
            this.panRightsAvailableAddRemove.Name = "panRightsAvailableAddRemove";
            this.panRightsAvailableAddRemove.Size = new System.Drawing.Size(60, 235);
            this.panRightsAvailableAddRemove.TabIndex = 2;
            // 
            // btnAdd
            // 
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
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(16, 120);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 3;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemove
            // 
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
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(16, 90);
            this.btnAddAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 2;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // colXClassID
            // 
            this.colXClassID.Caption = "-";
            this.colXClassID.FieldName = "XClassID";
            this.colXClassID.Name = "colXClassID";
            // 
            // CtlUserGroup
            // 
            this.ActiveSQLQuery = this.qryUserGroup;
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.tabControl);
            this.Name = "CtlUserGroup";
            this.Size = new System.Drawing.Size(750, 550);
            this.Load += new System.EventHandler(this.CtlUserGroup_Load);
            this.panContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurFuerAdminSichtbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserGroup)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpgBenutzer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdXUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUser)).EndInit();
            this.panUserRight.ResumeLayout(false);
            this.tpgRechte.ResumeLayout(false);
            this.panRightsTable.ResumeLayout(false);
            this.panRightsAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            this.panRightsAvailableFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            this.panRightsAvailableAddRemove.ResumeLayout(false);
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

        private DevExpress.XtraGrid.Columns.GridColumn colUserIsLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colUserEmail;
        private KissTextEditML edtUserGroupName;
        private KissMemoEditML edtDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colMaskName;
        private DevExpress.XtraGrid.Columns.GridColumn colXClassID;
    }
}
