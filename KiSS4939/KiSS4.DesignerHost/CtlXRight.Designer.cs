namespace KiSS4.DesignerHost
{
    partial class CtlXRight
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlXRight));
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.grdXUserGroup = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvXUserGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerfuegbarUserGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerfuegbarUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdXUserGroup_Right = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvXUserGroup_Right = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colMayUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdXRight = new KiSS4.Gui.KissGrid();
            this.qryXRight = new KiSS4.DB.SqlQuery(this.components);
            this.grvXRight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRightName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panAddRemove = new System.Windows.Forms.Panel();
            this.panXRight = new System.Windows.Forms.Panel();
            this.edtUserText = new KiSS4.Gui.KissTextEdit();
            this.edtDescription = new KiSS4.Gui.KissTextEdit();
            this.lblUserText = new KiSS4.Gui.KissLabel();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.edtRightName = new KiSS4.Gui.KissTextEdit();
            this.lblRightName = new KiSS4.Gui.KissLabel();
            this.panTableGroups = new System.Windows.Forms.TableLayoutPanel();
            this.panAvailable = new System.Windows.Forms.Panel();
            this.panAvailableFilter = new System.Windows.Forms.Panel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdXUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXUserGroup_Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUserGroup_Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXRight)).BeginInit();
            this.panAddRemove.SuspendLayout();
            this.panXRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRightName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRightName)).BeginInit();
            this.panTableGroups.SuspendLayout();
            this.panAvailable.SuspendLayout();
            this.panAvailableFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(16, 91);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 2;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(16, 121);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 3;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(16, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(16, 61);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // grdXUserGroup
            // 
            this.grdXUserGroup.DataSource = this.qryVerfuegbar;
            this.grdXUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdXUserGroup.EmbeddedNavigator.Name = "";
            this.grdXUserGroup.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXUserGroup.Location = new System.Drawing.Point(0, 0);
            this.grdXUserGroup.MainView = this.grvXUserGroup;
            this.grdXUserGroup.Name = "grdXUserGroup";
            this.grdXUserGroup.Size = new System.Drawing.Size(389, 236);
            this.grdXUserGroup.TabIndex = 0;
            this.grdXUserGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXUserGroup});
            this.grdXUserGroup.DoubleClick += new System.EventHandler(this.grdXUserGroup_DoubleClick);
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.SelectStatement = resources.GetString("qryVerfuegbar.SelectStatement");
            // 
            // grvXUserGroup
            // 
            this.grvXUserGroup.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXUserGroup.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.Empty.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.Empty.Options.UseFont = true;
            this.grvXUserGroup.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvXUserGroup.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.EvenRow.Options.UseFont = true;
            this.grvXUserGroup.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXUserGroup.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXUserGroup.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXUserGroup.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXUserGroup.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXUserGroup.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXUserGroup.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXUserGroup.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXUserGroup.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUserGroup.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUserGroup.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUserGroup.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUserGroup.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.GroupRow.Options.UseFont = true;
            this.grvXUserGroup.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXUserGroup.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXUserGroup.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXUserGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUserGroup.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXUserGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXUserGroup.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXUserGroup.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUserGroup.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXUserGroup.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXUserGroup.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXUserGroup.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvXUserGroup.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.OddRow.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.OddRow.Options.UseFont = true;
            this.grvXUserGroup.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXUserGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.Row.Options.UseBackColor = true;
            this.grvXUserGroup.Appearance.Row.Options.UseFont = true;
            this.grvXUserGroup.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXUserGroup.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXUserGroup.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXUserGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerfuegbarUserGroupName,
            this.colVerfuegbarUserGroupID});
            this.grvXUserGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXUserGroup.GridControl = this.grdXUserGroup;
            this.grvXUserGroup.Name = "grvXUserGroup";
            this.grvXUserGroup.OptionsBehavior.Editable = false;
            this.grvXUserGroup.OptionsCustomization.AllowFilter = false;
            this.grvXUserGroup.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXUserGroup.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXUserGroup.OptionsNavigation.UseTabKey = false;
            this.grvXUserGroup.OptionsSelection.MultiSelect = true;
            this.grvXUserGroup.OptionsView.ColumnAutoWidth = false;
            this.grvXUserGroup.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXUserGroup.OptionsView.ShowGroupPanel = false;
            this.grvXUserGroup.OptionsView.ShowIndicator = false;
            // 
            // colVerfuegbarUserGroupName
            // 
            this.colVerfuegbarUserGroupName.Caption = "Verfügbare Gruppen";
            this.colVerfuegbarUserGroupName.FieldName = "UserGroupName";
            this.colVerfuegbarUserGroupName.Name = "colVerfuegbarUserGroupName";
            this.colVerfuegbarUserGroupName.Visible = true;
            this.colVerfuegbarUserGroupName.VisibleIndex = 0;
            this.colVerfuegbarUserGroupName.Width = 330;
            // 
            // colVerfuegbarUserGroupID
            // 
            this.colVerfuegbarUserGroupID.Caption = "UserGroupID";
            this.colVerfuegbarUserGroupID.FieldName = "UserGroupID";
            this.colVerfuegbarUserGroupID.Name = "colVerfuegbarUserGroupID";
            // 
            // grdXUserGroup_Right
            // 
            this.grdXUserGroup_Right.DataSource = this.qryZugeteilt;
            this.grdXUserGroup_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdXUserGroup_Right.EmbeddedNavigator.Name = "";
            this.grdXUserGroup_Right.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdXUserGroup_Right.Location = new System.Drawing.Point(458, 3);
            this.grdXUserGroup_Right.MainView = this.grvXUserGroup_Right;
            this.grdXUserGroup_Right.Name = "grdXUserGroup_Right";
            this.grdXUserGroup_Right.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemCheckEdit});
            this.grdXUserGroup_Right.Size = new System.Drawing.Size(389, 270);
            this.grdXUserGroup_Right.TabIndex = 2;
            this.grdXUserGroup_Right.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXUserGroup_Right});
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            this.qryZugeteilt.TableName = "XUserGroup_Right";
            // 
            // grvXUserGroup_Right
            // 
            this.grvXUserGroup_Right.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXUserGroup_Right.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.Empty.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.Empty.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvXUserGroup_Right.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.EvenRow.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXUserGroup_Right.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvXUserGroup_Right.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXUserGroup_Right.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXUserGroup_Right.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvXUserGroup_Right.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXUserGroup_Right.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUserGroup_Right.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUserGroup_Right.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUserGroup_Right.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUserGroup_Right.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.GroupRow.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXUserGroup_Right.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXUserGroup_Right.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXUserGroup_Right.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUserGroup_Right.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXUserGroup_Right.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXUserGroup_Right.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUserGroup_Right.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXUserGroup_Right.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvXUserGroup_Right.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvXUserGroup_Right.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.OddRow.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.OddRow.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXUserGroup_Right.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.Row.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.Row.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXUserGroup_Right.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUserGroup_Right.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvXUserGroup_Right.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvXUserGroup_Right.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXUserGroup_Right.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvXUserGroup_Right.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvXUserGroup_Right.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXUserGroup_Right.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXUserGroup_Right.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser,
            this.colMayInsert,
            this.colMayUpdate,
            this.colMayDelete});
            this.grvXUserGroup_Right.GridControl = this.grdXUserGroup_Right;
            this.grvXUserGroup_Right.Name = "grvXUserGroup_Right";
            this.grvXUserGroup_Right.OptionsCustomization.AllowFilter = false;
            this.grvXUserGroup_Right.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXUserGroup_Right.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXUserGroup_Right.OptionsView.ColumnAutoWidth = false;
            this.grvXUserGroup_Right.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXUserGroup_Right.OptionsView.ShowGroupPanel = false;
            // 
            // colUser
            // 
            this.colUser.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colUser.AppearanceCell.Options.UseBackColor = true;
            this.colUser.Caption = "Zugeteilte Gruppen";
            this.colUser.FieldName = "UserGroupName";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 300;
            // 
            // colMayInsert
            // 
            this.colMayInsert.Caption = "E";
            this.colMayInsert.ColumnEdit = this.repItemCheckEdit;
            this.colMayInsert.FieldName = "MayInsert";
            this.colMayInsert.Name = "colMayInsert";
            this.colMayInsert.Visible = true;
            this.colMayInsert.VisibleIndex = 1;
            this.colMayInsert.Width = 21;
            // 
            // repItemCheckEdit
            // 
            this.repItemCheckEdit.AutoHeight = false;
            this.repItemCheckEdit.Name = "repItemCheckEdit";
            // 
            // colMayUpdate
            // 
            this.colMayUpdate.Caption = "M";
            this.colMayUpdate.ColumnEdit = this.repItemCheckEdit;
            this.colMayUpdate.FieldName = "MayUpdate";
            this.colMayUpdate.Name = "colMayUpdate";
            this.colMayUpdate.Visible = true;
            this.colMayUpdate.VisibleIndex = 2;
            this.colMayUpdate.Width = 20;
            // 
            // colMayDelete
            // 
            this.colMayDelete.Caption = "L";
            this.colMayDelete.ColumnEdit = this.repItemCheckEdit;
            this.colMayDelete.FieldName = "MayDelete";
            this.colMayDelete.Name = "colMayDelete";
            this.colMayDelete.Visible = true;
            this.colMayDelete.VisibleIndex = 3;
            this.colMayDelete.Width = 20;
            // 
            // grdXRight
            // 
            this.grdXRight.DataSource = this.qryXRight;
            this.grdXRight.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // 
            // 
            this.grdXRight.EmbeddedNavigator.Name = "";
            this.grdXRight.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXRight.Location = new System.Drawing.Point(0, 0);
            this.grdXRight.MainView = this.grvXRight;
            this.grdXRight.Name = "grdXRight";
            this.grdXRight.Size = new System.Drawing.Size(850, 170);
            this.grdXRight.TabIndex = 0;
            this.grdXRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXRight});
            // 
            // qryXRight
            // 
            this.qryXRight.HostControl = this;
            this.qryXRight.TableName = "XRight";
            this.qryXRight.BeforeInsert += new System.EventHandler(this.qryXRight_BeforeInsert);
            this.qryXRight.AfterInsert += new System.EventHandler(this.qryXRight_AfterInsert);
            this.qryXRight.BeforePost += new System.EventHandler(this.qryXRight_BeforePost);
            this.qryXRight.BeforeDeleteQuestion += new System.EventHandler(this.qryXRight_BeforeDeleteQuestion);
            this.qryXRight.PositionChanged += new System.EventHandler(this.qryXRight_PositionChanged);
            // 
            // grvXRight
            // 
            this.grvXRight.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXRight.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.Empty.Options.UseBackColor = true;
            this.grvXRight.Appearance.Empty.Options.UseFont = true;
            this.grvXRight.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.EvenRow.Options.UseFont = true;
            this.grvXRight.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXRight.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXRight.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXRight.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXRight.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXRight.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXRight.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXRight.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXRight.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXRight.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXRight.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXRight.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXRight.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXRight.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXRight.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXRight.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXRight.Appearance.GroupRow.Options.UseFont = true;
            this.grvXRight.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXRight.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXRight.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXRight.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXRight.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXRight.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXRight.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXRight.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXRight.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXRight.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXRight.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXRight.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXRight.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXRight.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXRight.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.OddRow.Options.UseFont = true;
            this.grvXRight.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXRight.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.Row.Options.UseBackColor = true;
            this.grvXRight.Appearance.Row.Options.UseFont = true;
            this.grvXRight.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXRight.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXRight.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXRight.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXRight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRightName,
            this.colUserText});
            this.grvXRight.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXRight.GridControl = this.grdXRight;
            this.grvXRight.Name = "grvXRight";
            this.grvXRight.OptionsBehavior.Editable = false;
            this.grvXRight.OptionsCustomization.AllowFilter = false;
            this.grvXRight.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXRight.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXRight.OptionsNavigation.UseTabKey = false;
            this.grvXRight.OptionsView.ColumnAutoWidth = false;
            this.grvXRight.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXRight.OptionsView.ShowGroupPanel = false;
            this.grvXRight.OptionsView.ShowIndicator = false;
            // 
            // colRightName
            // 
            this.colRightName.Caption = "Rechte Name";
            this.colRightName.FieldName = "RightName";
            this.colRightName.Name = "colRightName";
            this.colRightName.Visible = true;
            this.colRightName.VisibleIndex = 0;
            this.colRightName.Width = 300;
            // 
            // colUserText
            // 
            this.colUserText.Caption = "Berechtigung";
            this.colUserText.FieldName = "UserText";
            this.colUserText.Name = "colUserText";
            this.colUserText.Visible = true;
            this.colUserText.VisibleIndex = 1;
            this.colUserText.Width = 500;
            // 
            // panAddRemove
            // 
            this.panAddRemove.Controls.Add(this.btnAddAll);
            this.panAddRemove.Controls.Add(this.btnRemoveAll);
            this.panAddRemove.Controls.Add(this.btnRemove);
            this.panAddRemove.Controls.Add(this.btnAdd);
            this.panAddRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAddRemove.Location = new System.Drawing.Point(395, 0);
            this.panAddRemove.Margin = new System.Windows.Forms.Padding(0);
            this.panAddRemove.Name = "panAddRemove";
            this.panAddRemove.Size = new System.Drawing.Size(60, 276);
            this.panAddRemove.TabIndex = 1;
            // 
            // panXRight
            // 
            this.panXRight.Controls.Add(this.edtUserText);
            this.panXRight.Controls.Add(this.edtDescription);
            this.panXRight.Controls.Add(this.lblUserText);
            this.panXRight.Controls.Add(this.lblDescription);
            this.panXRight.Controls.Add(this.edtRightName);
            this.panXRight.Controls.Add(this.lblRightName);
            this.panXRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.panXRight.Location = new System.Drawing.Point(0, 170);
            this.panXRight.Name = "panXRight";
            this.panXRight.Size = new System.Drawing.Size(850, 104);
            this.panXRight.TabIndex = 1;
            // 
            // edtUserText
            // 
            this.edtUserText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserText.DataMember = "UserText";
            this.edtUserText.DataSource = this.qryXRight;
            this.edtUserText.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUserText.Location = new System.Drawing.Point(115, 39);
            this.edtUserText.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtUserText.Name = "edtUserText";
            this.edtUserText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUserText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserText.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserText.Properties.Appearance.Options.UseFont = true;
            this.edtUserText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserText.Properties.ReadOnly = true;
            this.edtUserText.Size = new System.Drawing.Size(726, 24);
            this.edtUserText.TabIndex = 3;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "DescriptionInView";
            this.edtDescription.DataSource = this.qryXRight;
            this.edtDescription.Location = new System.Drawing.Point(115, 69);
            this.edtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(726, 24);
            this.edtDescription.TabIndex = 5;
            // 
            // lblUserText
            // 
            this.lblUserText.Location = new System.Drawing.Point(9, 39);
            this.lblUserText.Name = "lblUserText";
            this.lblUserText.Size = new System.Drawing.Size(100, 23);
            this.lblUserText.TabIndex = 2;
            this.lblUserText.Text = "Berechtigung";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 69);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Beschreibung";
            // 
            // edtRightName
            // 
            this.edtRightName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRightName.DataMember = "RightName";
            this.edtRightName.DataSource = this.qryXRight;
            this.edtRightName.Location = new System.Drawing.Point(115, 9);
            this.edtRightName.Name = "edtRightName";
            this.edtRightName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRightName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRightName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRightName.Properties.Appearance.Options.UseBackColor = true;
            this.edtRightName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRightName.Properties.Appearance.Options.UseFont = true;
            this.edtRightName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRightName.Size = new System.Drawing.Size(726, 24);
            this.edtRightName.TabIndex = 1;
            // 
            // lblRightName
            // 
            this.lblRightName.Location = new System.Drawing.Point(9, 9);
            this.lblRightName.Name = "lblRightName";
            this.lblRightName.Size = new System.Drawing.Size(100, 23);
            this.lblRightName.TabIndex = 0;
            this.lblRightName.Text = "Rechte Name";
            // 
            // panTableGroups
            // 
            this.panTableGroups.ColumnCount = 3;
            this.panTableGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTableGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panTableGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTableGroups.Controls.Add(this.panAvailable, 0, 0);
            this.panTableGroups.Controls.Add(this.grdXUserGroup_Right, 2, 0);
            this.panTableGroups.Controls.Add(this.panAddRemove, 1, 0);
            this.panTableGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTableGroups.Location = new System.Drawing.Point(0, 274);
            this.panTableGroups.Name = "panTableGroups";
            this.panTableGroups.RowCount = 1;
            this.panTableGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panTableGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTableGroups.Size = new System.Drawing.Size(850, 276);
            this.panTableGroups.TabIndex = 2;
            // 
            // panAvailable
            // 
            this.panAvailable.Controls.Add(this.grdXUserGroup);
            this.panAvailable.Controls.Add(this.panAvailableFilter);
            this.panAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAvailable.Location = new System.Drawing.Point(3, 3);
            this.panAvailable.Name = "panAvailable";
            this.panAvailable.Size = new System.Drawing.Size(389, 270);
            this.panAvailable.TabIndex = 6;
            // 
            // panAvailableFilter
            // 
            this.panAvailableFilter.Controls.Add(this.edtFilter);
            this.panAvailableFilter.Controls.Add(this.lblFilter);
            this.panAvailableFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panAvailableFilter.Location = new System.Drawing.Point(0, 236);
            this.panAvailableFilter.Name = "panAvailableFilter";
            this.panAvailableFilter.Size = new System.Drawing.Size(389, 34);
            this.panAvailableFilter.TabIndex = 1;
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
            this.edtFilter.Size = new System.Drawing.Size(326, 24);
            this.edtFilter.TabIndex = 3;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(3, 5);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            // 
            // CtlXRight
            // 
            this.ActiveSQLQuery = this.qryXRight;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panTableGroups);
            this.Controls.Add(this.panXRight);
            this.Controls.Add(this.grdXRight);
            this.Name = "CtlXRight";
            this.Size = new System.Drawing.Size(850, 550);
            ((System.ComponentModel.ISupportInitialize)(this.grdXUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXUserGroup_Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUserGroup_Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXRight)).EndInit();
            this.panAddRemove.ResumeLayout(false);
            this.panXRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRightName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRightName)).EndInit();
            this.panTableGroups.ResumeLayout(false);
            this.panAvailable.ResumeLayout(false);
            this.panAvailableFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissGrid grdXUserGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXUserGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegbarUserGroupName;
        private KiSS4.Gui.KissGrid grdXUserGroup_Right;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXUserGroup_Right;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private KiSS4.Gui.KissGrid grdXRight;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXRight;
        private KiSS4.DB.SqlQuery qryXRight;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private DevExpress.XtraGrid.Columns.GridColumn colUserText;
        private DevExpress.XtraGrid.Columns.GridColumn colMayInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colMayUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colMayDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemCheckEdit;
        private System.Windows.Forms.Panel panAddRemove;
        private DevExpress.XtraGrid.Columns.GridColumn colRightName;
        private System.Windows.Forms.Panel panXRight;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissTextEdit edtRightName;
        private KiSS4.Gui.KissLabel lblRightName;
        private KiSS4.Gui.KissTextEdit edtDescription;
        private KiSS4.Gui.KissTextEdit edtUserText;
        private KiSS4.Gui.KissLabel lblUserText;
        private System.Windows.Forms.TableLayoutPanel panTableGroups;
        private System.Windows.Forms.Panel panAvailable;
        private System.Windows.Forms.Panel panAvailableFilter;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissLabel lblFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegbarUserGroupID;
    }
}
