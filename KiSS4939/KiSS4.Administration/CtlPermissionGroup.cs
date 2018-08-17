using KiSS4.DB;

namespace KiSS4.Administration
{
    public class CtlPermissionGroup : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colKompetenzstufe;
        private DevExpress.XtraGrid.Columns.GridColumn colLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPermission;
        private DevExpress.XtraGrid.Columns.GridColumn colPermissionGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissMemoEdit edtDescription;
        private KiSS4.Gui.KissTextEdit edtPermissionGroupName;
        private KiSS4.Gui.KissGrid grdPermissionGroup;
        private KiSS4.Gui.KissGrid grdPermissionSIL;
        private KiSS4.Gui.KissGrid grdPermissionValue;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermissionGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermissionSIL;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermissionValue;
        private Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissLabel lblDescription;
        private Gui.KissLabel lblKompetenzstufe;
        private KiSS4.Gui.KissLabel lblPermissionGroupName;
        private KiSS4.DB.SqlQuery qryPermissionGroup;
        private KiSS4.DB.SqlQuery qryPermissionSIL;
        private KiSS4.DB.SqlQuery qryPermissionValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repItmCalcEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repItmCalcEditESIL;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItmCheckEdit;
        private KiSS4.Gui.KissTabControlEx tabPermissionGroup;
        private SharpLibrary.WinControls.TabPageEx tpgPermissionSIL;
        private SharpLibrary.WinControls.TabPageEx tpgPermivvionValue;

        #endregion

        #endregion

        #region Constructors

        public CtlPermissionGroup()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlPermissionGroup));
            this.grdPermissionGroup = new KiSS4.Gui.KissGrid();
            this.qryPermissionGroup = new KiSS4.DB.SqlQuery();
            this.grvPermissionGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPermissionGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblPermissionGroupName = new KiSS4.Gui.KissLabel();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.edtPermissionGroupName = new KiSS4.Gui.KissTextEdit();
            this.qryPermissionValue = new KiSS4.DB.SqlQuery();
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.qryPermissionSIL = new KiSS4.DB.SqlQuery();
            this.tabPermissionGroup = new KiSS4.Gui.KissTabControlEx();
            this.tpgPermivvionValue = new SharpLibrary.WinControls.TabPageEx();
            this.grdPermissionValue = new KiSS4.Gui.KissGrid();
            this.grvPermissionValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPermission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItmCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repItmCalcEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.tpgPermissionSIL = new SharpLibrary.WinControls.TabPageEx();
            this.grdPermissionSIL = new KiSS4.Gui.KissGrid();
            this.grvPermissionSIL = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItmCalcEditESIL = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.lblKompetenzstufe = new KiSS4.Gui.KissLabel();
            this.colKompetenzstufe = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPermissionGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPermissionGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPermissionValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPermissionSIL)).BeginInit();
            this.tabPermissionGroup.SuspendLayout();
            this.tpgPermivvionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItmCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItmCalcEdit)).BeginInit();
            this.tpgPermissionSIL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionSIL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionSIL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItmCalcEditESIL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKompetenzstufe)).BeginInit();
            this.SuspendLayout();
            //
            // grdPermissionGroup
            //
            this.grdPermissionGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPermissionGroup.DataSource = this.qryPermissionGroup;
            //
            //
            //
            this.grdPermissionGroup.EmbeddedNavigator.Name = "";
            this.grdPermissionGroup.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPermissionGroup.Location = new System.Drawing.Point(5, 10);
            this.grdPermissionGroup.MainView = this.grvPermissionGroup;
            this.grdPermissionGroup.Name = "grdPermissionGroup";
            this.grdPermissionGroup.Size = new System.Drawing.Size(634, 124);
            this.grdPermissionGroup.TabIndex = 0;
            this.grdPermissionGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermissionGroup});
            //
            // qryPermissionGroup
            //
            this.qryPermissionGroup.CanDelete = true;
            this.qryPermissionGroup.CanInsert = true;
            this.qryPermissionGroup.CanUpdate = true;
            this.qryPermissionGroup.HostControl = this;
            this.qryPermissionGroup.SelectStatement = "SELECT *\r\nFROM XPermissionGroup\r\nORDER BY PermissionGroupName";
            this.qryPermissionGroup.TableName = "XPermissionGroup";
            this.qryPermissionGroup.AfterInsert += new System.EventHandler(this.qryPermissionGroup_AfterInsert);
            this.qryPermissionGroup.BeforePost += new System.EventHandler(this.qryPermissionGroup_BeforePost);
            this.qryPermissionGroup.AfterPost += new System.EventHandler(this.qryPermissionGroup_AfterPost);
            this.qryPermissionGroup.PositionChanged += new System.EventHandler(this.qryPermissionGroup_PositionChanged);
            //
            // grvPermissionGroup
            //
            this.grvPermissionGroup.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPermissionGroup.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.Empty.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.Empty.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.EvenRow.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPermissionGroup.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPermissionGroup.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPermissionGroup.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPermissionGroup.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPermissionGroup.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPermissionGroup.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPermissionGroup.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPermissionGroup.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPermissionGroup.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPermissionGroup.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.GroupRow.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPermissionGroup.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPermissionGroup.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPermissionGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPermissionGroup.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPermissionGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPermissionGroup.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPermissionGroup.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPermissionGroup.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPermissionGroup.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.OddRow.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPermissionGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.Row.Options.UseBackColor = true;
            this.grvPermissionGroup.Appearance.Row.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionGroup.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPermissionGroup.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPermissionGroup.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPermissionGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPermissionGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPermissionGroupName,
            this.colDescription,
            this.colKompetenzstufe});
            this.grvPermissionGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPermissionGroup.GridControl = this.grdPermissionGroup;
            this.grvPermissionGroup.Name = "grvPermissionGroup";
            this.grvPermissionGroup.OptionsBehavior.Editable = false;
            this.grvPermissionGroup.OptionsCustomization.AllowFilter = false;
            this.grvPermissionGroup.OptionsFilter.AllowFilterEditor = false;
            this.grvPermissionGroup.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPermissionGroup.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPermissionGroup.OptionsNavigation.UseTabKey = false;
            this.grvPermissionGroup.OptionsView.ColumnAutoWidth = false;
            this.grvPermissionGroup.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPermissionGroup.OptionsView.ShowGroupPanel = false;
            this.grvPermissionGroup.OptionsView.ShowIndicator = false;
            //
            // colPermissionGroupName
            //
            this.colPermissionGroupName.Caption = "Name";
            this.colPermissionGroupName.FieldName = "PermissionGroupName";
            this.colPermissionGroupName.Name = "colPermissionGroupName";
            this.colPermissionGroupName.Visible = true;
            this.colPermissionGroupName.VisibleIndex = 0;
            this.colPermissionGroupName.Width = 197;
            //
            // colDescription
            //
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 322;
            //
            // lblPermissionGroupName
            //
            this.lblPermissionGroupName.Location = new System.Drawing.Point(5, 145);
            this.lblPermissionGroupName.Name = "lblPermissionGroupName";
            this.lblPermissionGroupName.Size = new System.Drawing.Size(74, 24);
            this.lblPermissionGroupName.TabIndex = 7;
            this.lblPermissionGroupName.Text = "Name";
            //
            // lblDescription
            //
            this.lblDescription.Location = new System.Drawing.Point(5, 175);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(76, 24);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Beschreibung";
            //
            // edtPermissionGroupName
            //
            this.edtPermissionGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPermissionGroupName.DataMember = "PermissionGroupName";
            this.edtPermissionGroupName.DataSource = this.qryPermissionGroup;
            this.edtPermissionGroupName.Location = new System.Drawing.Point(103, 145);
            this.edtPermissionGroupName.Name = "edtPermissionGroupName";
            this.edtPermissionGroupName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPermissionGroupName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPermissionGroupName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPermissionGroupName.Properties.Appearance.Options.UseBackColor = true;
            this.edtPermissionGroupName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPermissionGroupName.Properties.Appearance.Options.UseFont = true;
            this.edtPermissionGroupName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPermissionGroupName.Size = new System.Drawing.Size(536, 24);
            this.edtPermissionGroupName.TabIndex = 1;
            //
            // qryPermissionValue
            //
            this.qryPermissionValue.CanUpdate = true;
            this.qryPermissionValue.HostControl = this;
            this.qryPermissionValue.SelectStatement = resources.GetString("qryPermissionValue.SelectStatement");
            this.qryPermissionValue.TableName = "XPermissionValue";
            this.qryPermissionValue.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryPermissionValue_ColumnChanged);
            //
            // edtDescription
            //
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "Description";
            this.edtDescription.DataSource = this.qryPermissionGroup;
            this.edtDescription.Location = new System.Drawing.Point(103, 175);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(536, 60);
            this.edtDescription.TabIndex = 2;
            //
            // qryPermissionSIL
            //
            this.qryPermissionSIL.CanUpdate = true;
            this.qryPermissionSIL.HostControl = this;
            this.qryPermissionSIL.SelectStatement = resources.GetString("qryPermissionSIL.SelectStatement");
            this.qryPermissionSIL.TableName = "XPermissionValue";
            this.qryPermissionSIL.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryPermissionSIL_ColumnChanged);
            //
            // tabPermissionGroup
            //
            this.tabPermissionGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPermissionGroup.Controls.Add(this.tpgPermivvionValue);
            this.tabPermissionGroup.Controls.Add(this.tpgPermissionSIL);
            this.tabPermissionGroup.Location = new System.Drawing.Point(5, 271);
            this.tabPermissionGroup.Name = "tabPermissionGroup";
            this.tabPermissionGroup.SelectedTabIndex = 1;
            this.tabPermissionGroup.ShowFixedWidthTooltip = true;
            this.tabPermissionGroup.Size = new System.Drawing.Size(634, 301);
            this.tabPermissionGroup.TabIndex = 16;
            this.tabPermissionGroup.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPermivvionValue,
            this.tpgPermissionSIL});
            this.tabPermissionGroup.TabsLineColor = System.Drawing.Color.Black;
            this.tabPermissionGroup.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabPermissionGroup.Text = "tabControlEx1";
            //
            // tpgPermivvionValue
            //
            this.tpgPermivvionValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgPermivvionValue.Controls.Add(this.grdPermissionValue);
            this.tpgPermivvionValue.Location = new System.Drawing.Point(6, 6);
            this.tpgPermivvionValue.Name = "tpgPermivvionValue";
            this.tpgPermivvionValue.Size = new System.Drawing.Size(622, 263);
            this.tpgPermivvionValue.TabIndex = 0;
            this.tpgPermivvionValue.Title = "&1 Kompetenzen";
            //
            // grdPermissionValue
            //
            this.grdPermissionValue.DataSource = this.qryPermissionValue;
            this.grdPermissionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdPermissionValue.EmbeddedNavigator.Name = "";
            this.grdPermissionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPermissionValue.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdPermissionValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdPermissionValue.Location = new System.Drawing.Point(0, 0);
            this.grdPermissionValue.MainView = this.grvPermissionValue;
            this.grdPermissionValue.Name = "grdPermissionValue";
            this.grdPermissionValue.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItmCheckEdit,
            this.repItmCalcEdit});
            this.grdPermissionValue.Size = new System.Drawing.Size(622, 263);
            this.grdPermissionValue.TabIndex = 1;
            this.grdPermissionValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermissionValue});
            //
            // grvPermissionValue
            //
            this.grvPermissionValue.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPermissionValue.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.Empty.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.Empty.Options.UseFont = true;
            this.grvPermissionValue.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPermissionValue.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.EvenRow.Options.UseFont = true;
            this.grvPermissionValue.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionValue.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvPermissionValue.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPermissionValue.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPermissionValue.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionValue.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPermissionValue.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPermissionValue.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPermissionValue.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPermissionValue.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPermissionValue.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPermissionValue.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPermissionValue.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.GroupRow.Options.UseFont = true;
            this.grvPermissionValue.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPermissionValue.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPermissionValue.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPermissionValue.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPermissionValue.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPermissionValue.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPermissionValue.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionValue.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPermissionValue.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPermissionValue.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPermissionValue.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvPermissionValue.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvPermissionValue.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.OddRow.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.OddRow.Options.UseFont = true;
            this.grvPermissionValue.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionValue.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.Row.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.Row.Options.UseFont = true;
            this.grvPermissionValue.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionValue.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionValue.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPermissionValue.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPermissionValue.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPermissionValue.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPermissionValue.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvPermissionValue.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPermissionValue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPermissionValue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPermission,
            this.colValue,
            this.colUnit,
            this.colDataType});
            this.grvPermissionValue.GridControl = this.grdPermissionValue;
            this.grvPermissionValue.Name = "grvPermissionValue";
            this.grvPermissionValue.OptionsCustomization.AllowFilter = false;
            this.grvPermissionValue.OptionsFilter.AllowFilterEditor = false;
            this.grvPermissionValue.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPermissionValue.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPermissionValue.OptionsView.ColumnAutoWidth = false;
            this.grvPermissionValue.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPermissionValue.OptionsView.ShowGroupPanel = false;
            this.grvPermissionValue.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvPermissionValue_CustomRowCellEdit);
            //
            // colPermission
            //
            this.colPermission.Caption = "Kompetenz";
            this.colPermission.FieldName = "PermissionText";
            this.colPermission.Name = "colPermission";
            this.colPermission.OptionsColumn.AllowEdit = false;
            this.colPermission.OptionsColumn.ReadOnly = true;
            this.colPermission.Visible = true;
            this.colPermission.VisibleIndex = 0;
            this.colPermission.Width = 440;
            //
            // colValue
            //
            this.colValue.AppearanceCell.Options.UseTextOptions = true;
            this.colValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValue.Caption = "Wert";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            //
            // colUnit
            //
            this.colUnit.Caption = "Einheit";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.OptionsColumn.ReadOnly = true;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 2;
            //
            // colDataType
            //
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            //
            // repItmCheckEdit
            //
            this.repItmCheckEdit.AutoHeight = false;
            this.repItmCheckEdit.Name = "repItmCheckEdit";
            //
            // repItmCalcEdit
            //
            this.repItmCalcEdit.AutoHeight = false;
            this.repItmCalcEdit.DisplayFormat.FormatString = "N0";
            this.repItmCalcEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repItmCalcEdit.EditFormat.FormatString = "N0";
            this.repItmCalcEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repItmCalcEdit.Name = "repItmCalcEdit";
            //
            // tpgPermissionSIL
            //
            this.tpgPermissionSIL.Controls.Add(this.grdPermissionSIL);
            this.tpgPermissionSIL.Location = new System.Drawing.Point(6, 6);
            this.tpgPermissionSIL.Name = "tpgPermissionSIL";
            this.tpgPermissionSIL.Size = new System.Drawing.Size(622, 263);
            this.tpgPermissionSIL.TabIndex = 1;
            this.tpgPermissionSIL.Title = "&2 Zusätzliche Leistungen";
            //
            // grdPermissionSIL
            //
            this.grdPermissionSIL.DataSource = this.qryPermissionSIL;
            this.grdPermissionSIL.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdPermissionSIL.EmbeddedNavigator.Name = "";
            this.grdPermissionSIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPermissionSIL.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdPermissionSIL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdPermissionSIL.Location = new System.Drawing.Point(0, 0);
            this.grdPermissionSIL.MainView = this.grvPermissionSIL;
            this.grdPermissionSIL.Name = "grdPermissionSIL";
            this.grdPermissionSIL.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItmCalcEditESIL});
            this.grdPermissionSIL.Size = new System.Drawing.Size(622, 263);
            this.grdPermissionSIL.TabIndex = 13;
            this.grdPermissionSIL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermissionSIL});
            //
            // grvPermissionSIL
            //
            this.grvPermissionSIL.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPermissionSIL.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.Empty.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.Empty.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPermissionSIL.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.EvenRow.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionSIL.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvPermissionSIL.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPermissionSIL.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionSIL.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPermissionSIL.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPermissionSIL.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPermissionSIL.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPermissionSIL.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPermissionSIL.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPermissionSIL.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.GroupRow.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPermissionSIL.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPermissionSIL.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPermissionSIL.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPermissionSIL.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPermissionSIL.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionSIL.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPermissionSIL.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPermissionSIL.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvPermissionSIL.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvPermissionSIL.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.OddRow.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.OddRow.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionSIL.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.Row.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.Row.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPermissionSIL.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPermissionSIL.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPermissionSIL.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPermissionSIL.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPermissionSIL.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPermissionSIL.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvPermissionSIL.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPermissionSIL.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPermissionSIL.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colLimit});
            this.grvPermissionSIL.GridControl = this.grdPermissionSIL;
            this.grvPermissionSIL.Name = "grvPermissionSIL";
            this.grvPermissionSIL.OptionsCustomization.AllowFilter = false;
            this.grvPermissionSIL.OptionsFilter.AllowFilterEditor = false;
            this.grvPermissionSIL.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPermissionSIL.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPermissionSIL.OptionsView.ColumnAutoWidth = false;
            this.grvPermissionSIL.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPermissionSIL.OptionsView.ShowGroupPanel = false;
            //
            // colName
            //
            this.colName.Caption = "Zusätzliche Leistungen";
            this.colName.FieldName = "NameGueltigkeit";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 473;
            //
            // colLimit
            //
            this.colLimit.AppearanceCell.Options.UseTextOptions = true;
            this.colLimit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLimit.Caption = "Wert in CHF";
            this.colLimit.ColumnEdit = this.repItmCalcEditESIL;
            this.colLimit.FieldName = "Value";
            this.colLimit.Name = "colLimit";
            this.colLimit.Visible = true;
            this.colLimit.VisibleIndex = 1;
            this.colLimit.Width = 86;
            //
            // repItmCalcEditESIL
            //
            this.repItmCalcEditESIL.Appearance.Options.UseTextOptions = true;
            this.repItmCalcEditESIL.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repItmCalcEditESIL.AutoHeight = false;
            this.repItmCalcEditESIL.DisplayFormat.FormatString = "n0";
            this.repItmCalcEditESIL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repItmCalcEditESIL.EditFormat.FormatString = "n0";
            this.repItmCalcEditESIL.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repItmCalcEditESIL.Name = "repItmCalcEditESIL";
            //
            // kissTextEdit1
            //
            this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissTextEdit1.DataMember = "Kompetenzstufe";
            this.kissTextEdit1.DataSource = this.qryPermissionGroup;
            this.kissTextEdit1.Location = new System.Drawing.Point(103, 241);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Size = new System.Drawing.Size(536, 24);
            this.kissTextEdit1.TabIndex = 17;
            //
            // lblKompetenzstufe
            //
            this.lblKompetenzstufe.Location = new System.Drawing.Point(5, 241);
            this.lblKompetenzstufe.Name = "lblKompetenzstufe";
            this.lblKompetenzstufe.Size = new System.Drawing.Size(92, 24);
            this.lblKompetenzstufe.TabIndex = 18;
            this.lblKompetenzstufe.Text = "Kompetenzstufe";
            //
            // colKompetenzstufe
            //
            this.colKompetenzstufe.Caption = "Kompetenzstufe";
            this.colKompetenzstufe.FieldName = "Kompetenzstufe";
            this.colKompetenzstufe.Name = "colKompetenzstufe";
            this.colKompetenzstufe.Visible = true;
            this.colKompetenzstufe.VisibleIndex = 2;
            this.colKompetenzstufe.Width = 109;
            //
            // CtlPermissionGroup
            //
            this.ActiveSQLQuery = this.qryPermissionGroup;
            this.Controls.Add(this.kissTextEdit1);
            this.Controls.Add(this.lblKompetenzstufe);
            this.Controls.Add(this.tabPermissionGroup);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.edtPermissionGroupName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPermissionGroupName);
            this.Controls.Add(this.grdPermissionGroup);
            this.Name = "CtlPermissionGroup";
            this.Size = new System.Drawing.Size(650, 568);
            this.Load += new System.EventHandler(this.CtlPermissionGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPermissionGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPermissionGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPermissionValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPermissionSIL)).EndInit();
            this.tabPermissionGroup.ResumeLayout(false);
            this.tpgPermivvionValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItmCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItmCalcEdit)).EndInit();
            this.tpgPermissionSIL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionSIL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionSIL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItmCalcEditESIL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKompetenzstufe)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void CtlPermissionGroup_Load(object sender, System.EventArgs e)
        {
            qryPermissionGroup.Fill();

            grdPermissionValue.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            grdPermissionSIL.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        private void grvPermissionValue_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Value")
            {
                var dataType = grvPermissionValue.GetRowCellValue(e.RowHandle, grvPermissionValue.Columns["DataType"]).ToString().ToLower();

                switch (dataType)
                {
                    case "money":
                    case "int":
                        e.RepositoryItem = repItmCalcEdit;
                        break;

                    case "bit":
                        e.RepositoryItem = repItmCheckEdit;
                        break;
                }
            }
        }

        private void qryPermissionGroup_AfterInsert(object sender, System.EventArgs e)
        {
            edtPermissionGroupName.Focus();
        }

        private void qryPermissionGroup_AfterPost(object sender, System.EventArgs e)
        {
            DisplayPermissions();
        }

        private void qryPermissionGroup_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtPermissionGroupName, lblPermissionGroupName.Text);

            qryPermissionSIL.Post(); // save pending changes
            qryPermissionValue.Post(); // save pending changes
        }

        private void qryPermissionGroup_PositionChanged(object sender, System.EventArgs e)
        {
            DisplayPermissions();
        }

        private void qryPermissionSIL_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryPermissionGroup.RowModified = true;
        }

        private void qryPermissionValue_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryPermissionGroup.RowModified = true;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void DisplayPermissions()
        {
            if (!DBUtil.IsEmpty(qryPermissionGroup["PermissionGroupID"]))
            {
                // generate missing default entries
                foreach (var dataType in new[] { "int", "bit" })
                {
                    DBUtil.ExecSQL(string.Format(@"
                        --SQLCHECK_IGNORE--
                        INSERT INTO dbo.XPermissionValue (PermissionGroupID, PermissionCode, Value)
                          SELECT {0}, XLC.Code, CONVERT({2}, 0)
                          FROM dbo.XLOVCode XLC
                          WHERE LOVName = 'Permission'
                            AND XLC.Value2 = {1}
                            AND NOT EXISTS (SELECT TOP 1 1
                                            FROM dbo.XPermissionValue
                                            WHERE PermissionGroupID = {0}
                                              AND PermissionCode = XLC.Code)", "{0}", "{1}", dataType), qryPermissionGroup["PermissionGroupID"], dataType);
                }

                // int values ESIL
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.XPermissionValue (PermissionGroupID, BgPositionsartID, Value)
                      SELECT {0}, BPA.BgPositionsartID, CONVERT(INT, 0)
                      FROM dbo.WhPositionsart BPA
                      WHERE BPA.BgKategorieCode = 100
                        AND NOT EXISTS (SELECT TOP 1 1
                                        FROM dbo.XPermissionValue
                                        WHERE PermissionGroupID = {0}
                                          AND BgPositionsartID = BPA.BgPositionsartID)", qryPermissionGroup["PermissionGroupID"]);
            }

            qryPermissionValue.Fill(qryPermissionGroup["PermissionGroupID"]);
            qryPermissionSIL.Fill(qryPermissionGroup["PermissionGroupID"]);
        }

        #endregion

        #endregion
    }
}