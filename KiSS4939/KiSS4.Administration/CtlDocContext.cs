using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public class CtlDocContext : KissUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddFolder;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnUp;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDocContextName;
        private DevExpress.XtraGrid.Columns.GridColumn colFormat;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegbar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colZugeteilteVorlage;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCheckEdit editInsertAtSameLevel;
        private KiSS4.Gui.KissMemoEdit edtDescription;
        private KiSS4.Gui.KissTextEdit edtDocContextName;
        private KissTextEdit edtFilterKandidaten;
        private KiSS4.Gui.KissTextEdit edtFolderName;
        private KiSS4.Gui.KissGrid grdDocContext;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDocContext;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private System.Windows.Forms.ImageList imgList;
        private KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblDocContextName;
        private KiSS4.Gui.KissLabel lblFolderName;
        private Panel panDetail;
        private KiSS4.DB.SqlQuery qryDocContext;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTree treZugeteilt;

        #endregion

        #endregion

        #region Constructors

        public CtlDocContext()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDocContext));
            this.grdDocContext = new KiSS4.Gui.KissGrid();
            this.qryDocContext = new KiSS4.DB.SqlQuery(this.components);
            this.grvDocContext = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocContextName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.lblDocContextName = new KiSS4.Gui.KissLabel();
            this.edtDocContextName = new KiSS4.Gui.KissTextEdit();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.colVerfuegbar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.treZugeteilt = new KiSS4.Gui.KissTree();
            this.colZugeteilteVorlage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.edtFolderName = new KiSS4.Gui.KissTextEdit();
            this.lblFolderName = new KiSS4.Gui.KissLabel();
            this.btnAddFolder = new KiSS4.Gui.KissButton();
            this.editInsertAtSameLevel = new KiSS4.Gui.KissCheckEdit();
            this.panDetail = new System.Windows.Forms.Panel();
            this.edtFilterKandidaten = new KiSS4.Gui.KissTextEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocContextName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocContextName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFolderName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFolderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInsertAtSameLevel.Properties)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterKandidaten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDocContext
            // 
            this.grdDocContext.DataSource = this.qryDocContext;
            this.grdDocContext.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdDocContext.EmbeddedNavigator.Name = "";
            this.grdDocContext.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDocContext.Location = new System.Drawing.Point(0, 0);
            this.grdDocContext.MainView = this.grvDocContext;
            this.grdDocContext.Name = "grdDocContext";
            this.grdDocContext.Size = new System.Drawing.Size(900, 116);
            this.grdDocContext.TabIndex = 2;
            this.grdDocContext.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDocContext});
            // 
            // qryDocContext
            // 
            this.qryDocContext.CanDelete = true;
            this.qryDocContext.CanInsert = true;
            this.qryDocContext.CanUpdate = true;
            this.qryDocContext.HostControl = this;
            this.qryDocContext.SelectStatement = "SELECT XDC.*\r\nFROM dbo.XDocContext XDC WITH (READUNCOMMITTED)\r\nORDER BY XDC.DocCo" +
    "ntextName";
            this.qryDocContext.TableName = "XDocContext";
            this.qryDocContext.AfterInsert += new System.EventHandler(this.qryDocContext_AfterInsert);
            this.qryDocContext.BeforeDeleteQuestion += new System.EventHandler(this.qryDocContext_BeforeDeleteQuestion);
            this.qryDocContext.BeforePost += new System.EventHandler(this.qryDocContext_BeforePost);
            this.qryDocContext.PositionChanged += new System.EventHandler(this.qryDocContext_PositionChanged);
            // 
            // grvDocContext
            // 
            this.grvDocContext.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDocContext.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.Empty.Options.UseBackColor = true;
            this.grvDocContext.Appearance.Empty.Options.UseFont = true;
            this.grvDocContext.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.EvenRow.Options.UseFont = true;
            this.grvDocContext.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocContext.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDocContext.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDocContext.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDocContext.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDocContext.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocContext.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDocContext.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDocContext.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDocContext.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDocContext.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocContext.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDocContext.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocContext.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocContext.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocContext.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDocContext.Appearance.GroupRow.Options.UseFont = true;
            this.grvDocContext.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDocContext.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDocContext.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDocContext.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocContext.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDocContext.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDocContext.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDocContext.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDocContext.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocContext.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDocContext.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDocContext.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDocContext.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocContext.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDocContext.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.OddRow.Options.UseFont = true;
            this.grvDocContext.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDocContext.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.Row.Options.UseBackColor = true;
            this.grvDocContext.Appearance.Row.Options.UseFont = true;
            this.grvDocContext.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocContext.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDocContext.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocContext.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDocContext.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDocContext.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocContextName,
            this.colDescription});
            this.grvDocContext.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDocContext.GridControl = this.grdDocContext;
            this.grvDocContext.Name = "grvDocContext";
            this.grvDocContext.OptionsBehavior.Editable = false;
            this.grvDocContext.OptionsCustomization.AllowFilter = false;
            this.grvDocContext.OptionsFilter.AllowFilterEditor = false;
            this.grvDocContext.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDocContext.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDocContext.OptionsNavigation.UseTabKey = false;
            this.grvDocContext.OptionsView.ColumnAutoWidth = false;
            this.grvDocContext.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDocContext.OptionsView.ShowGroupPanel = false;
            this.grvDocContext.OptionsView.ShowIndicator = false;
            // 
            // colDocContextName
            // 
            this.colDocContextName.AppearanceCell.Options.UseTextOptions = true;
            this.colDocContextName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDocContextName.Caption = "Kontextname";
            this.colDocContextName.FieldName = "DocContextName";
            this.colDocContextName.Name = "colDocContextName";
            this.colDocContextName.Visible = true;
            this.colDocContextName.VisibleIndex = 0;
            this.colDocContextName.Width = 230;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 520;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 39);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 24);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Beschreibung";
            // 
            // lblDocContextName
            // 
            this.lblDocContextName.Location = new System.Drawing.Point(9, 9);
            this.lblDocContextName.Name = "lblDocContextName";
            this.lblDocContextName.Size = new System.Drawing.Size(85, 24);
            this.lblDocContextName.TabIndex = 0;
            this.lblDocContextName.Text = "Kontextname";
            // 
            // edtDocContextName
            // 
            this.edtDocContextName.DataMember = "DocContextName";
            this.edtDocContextName.DataSource = this.qryDocContext;
            this.edtDocContextName.Location = new System.Drawing.Point(100, 9);
            this.edtDocContextName.Name = "edtDocContextName";
            this.edtDocContextName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocContextName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocContextName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocContextName.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocContextName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocContextName.Properties.Appearance.Options.UseFont = true;
            this.edtDocContextName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDocContextName.Size = new System.Drawing.Size(287, 24);
            this.edtDocContextName.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(359, 159);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(359, 129);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(15, 27, 15, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(359, 189);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 7;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
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
            this.grdVerfuegbar.Location = new System.Drawing.Point(12, 114);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdVerfuegbar.Size = new System.Drawing.Size(329, 292);
            this.grdVerfuegbar.TabIndex = 4;
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
            this.grvVerfuegbar.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.grvVerfuegbar.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.OddRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFormat,
            this.colVerfuegbar});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.AllowFilterEditor = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
            // 
            // colFormat
            // 
            this.colFormat.Caption = "F";
            this.colFormat.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colFormat.FieldName = "DocFormatCode";
            this.colFormat.Name = "colFormat";
            this.colFormat.OptionsColumn.AllowSize = false;
            this.colFormat.OptionsColumn.FixedWidth = true;
            this.colFormat.Visible = true;
            this.colFormat.VisibleIndex = 0;
            this.colFormat.Width = 24;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("1", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2", 2, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("3", 3, 3)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imgList;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Magenta;
            this.imgList.Images.SetKeyName(0, "FolderImgList");
            this.imgList.Images.SetKeyName(1, "WordImgList");
            this.imgList.Images.SetKeyName(2, "ExcelImgList");
            this.imgList.Images.SetKeyName(3, "DocumentImgList");
            // 
            // colVerfuegbar
            // 
            this.colVerfuegbar.Caption = "verfügbare Vorlagen";
            this.colVerfuegbar.FieldName = "DocTemplateName";
            this.colVerfuegbar.Name = "colVerfuegbar";
            this.colVerfuegbar.Visible = true;
            this.colVerfuegbar.VisibleIndex = 1;
            this.colVerfuegbar.Width = 269;
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            this.qryZugeteilt.TableName = "XDocContext_Template";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "Description";
            this.edtDescription.DataSource = this.qryDocContext;
            this.edtDescription.Location = new System.Drawing.Point(100, 39);
            this.edtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(757, 60);
            this.edtDescription.TabIndex = 3;
            // 
            // treZugeteilt
            // 
            this.treZugeteilt.AllowSortTree = true;
            this.treZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treZugeteilt.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.EvenRow.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treZugeteilt.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treZugeteilt.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.FooterPanel.Options.UseFont = true;
            this.treZugeteilt.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treZugeteilt.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treZugeteilt.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.GroupButton.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.GroupButton.Options.UseFont = true;
            this.treZugeteilt.Appearance.GroupButton.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treZugeteilt.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treZugeteilt.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.treZugeteilt.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treZugeteilt.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.HorzLine.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treZugeteilt.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.OddRow.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.treZugeteilt.Appearance.OddRow.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treZugeteilt.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treZugeteilt.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.Preview.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.Preview.Options.UseFont = true;
            this.treZugeteilt.Appearance.Preview.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treZugeteilt.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.Row.Options.UseFont = true;
            this.treZugeteilt.Appearance.Row.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treZugeteilt.Appearance.TreeLine.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treZugeteilt.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.treZugeteilt.Appearance.VertLine.Options.UseForeColor = true;
            this.treZugeteilt.Appearance.VertLine.Options.UseTextOptions = true;
            this.treZugeteilt.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.treZugeteilt.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colZugeteilteVorlage});
            this.treZugeteilt.DataSource = this.qryZugeteilt;
            this.treZugeteilt.ImageIndexFieldName = "IconID";
            this.treZugeteilt.KeyFieldName = "XDocContext_TemplateID";
            this.treZugeteilt.Location = new System.Drawing.Point(405, 119);
            this.treZugeteilt.Name = "treZugeteilt";
            this.treZugeteilt.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treZugeteilt.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treZugeteilt.OptionsBehavior.Editable = false;
            this.treZugeteilt.OptionsBehavior.KeepSelectedOnClick = false;
            this.treZugeteilt.OptionsBehavior.MoveOnEdit = false;
            this.treZugeteilt.OptionsBehavior.ShowToolTips = false;
            this.treZugeteilt.OptionsBehavior.SmartMouseHover = false;
            this.treZugeteilt.OptionsMenu.EnableColumnMenu = false;
            this.treZugeteilt.OptionsMenu.EnableFooterMenu = false;
            this.treZugeteilt.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treZugeteilt.OptionsView.AutoWidth = false;
            this.treZugeteilt.OptionsView.EnableAppearanceEvenRow = true;
            this.treZugeteilt.OptionsView.EnableAppearanceOddRow = true;
            this.treZugeteilt.OptionsView.ShowIndicator = false;
            this.treZugeteilt.OptionsView.ShowVertLines = false;
            this.treZugeteilt.SelectImageList = this.imgList;
            this.treZugeteilt.Size = new System.Drawing.Size(452, 317);
            this.treZugeteilt.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
                    | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treZugeteilt.TabIndex = 8;
            this.treZugeteilt.DoubleClick += new System.EventHandler(this.treZugeteilt_DoubleClick);
            // 
            // colZugeteilteVorlage
            // 
            this.colZugeteilteVorlage.Caption = "zugeteilte Vorlage";
            this.colZugeteilteVorlage.FieldName = "ItemName";
            this.colZugeteilteVorlage.MinWidth = 27;
            this.colZugeteilteVorlage.Name = "colZugeteilteVorlage";
            this.colZugeteilteVorlage.OptionsColumn.AllowEdit = false;
            this.colZugeteilteVorlage.OptionsColumn.AllowMove = false;
            this.colZugeteilteVorlage.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colZugeteilteVorlage.OptionsColumn.AllowSort = false;
            this.colZugeteilteVorlage.OptionsColumn.ReadOnly = true;
            this.colZugeteilteVorlage.VisibleIndex = 0;
            this.colZugeteilteVorlage.Width = 321;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(863, 129);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 9;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(863, 159);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 10;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // edtFolderName
            // 
            this.edtFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFolderName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFolderName.Location = new System.Drawing.Point(100, 442);
            this.edtFolderName.Name = "edtFolderName";
            this.edtFolderName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFolderName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFolderName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFolderName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFolderName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFolderName.Properties.Appearance.Options.UseFont = true;
            this.edtFolderName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFolderName.Properties.ReadOnly = true;
            this.edtFolderName.Size = new System.Drawing.Size(207, 24);
            this.edtFolderName.TabIndex = 12;
            // 
            // lblFolderName
            // 
            this.lblFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFolderName.Location = new System.Drawing.Point(9, 443);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(85, 24);
            this.lblFolderName.TabIndex = 11;
            this.lblFolderName.Text = "Ordnername";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.IconID = 13;
            this.btnAddFolder.Location = new System.Drawing.Point(313, 442);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(28, 24);
            this.btnAddFolder.TabIndex = 14;
            this.btnAddFolder.UseVisualStyleBackColor = false;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // editInsertAtSameLevel
            // 
            this.editInsertAtSameLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editInsertAtSameLevel.EditValue = false;
            this.editInsertAtSameLevel.Location = new System.Drawing.Point(405, 446);
            this.editInsertAtSameLevel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.editInsertAtSameLevel.Name = "editInsertAtSameLevel";
            this.editInsertAtSameLevel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editInsertAtSameLevel.Properties.Appearance.Options.UseBackColor = true;
            this.editInsertAtSameLevel.Properties.Caption = "Einfügen auf derselben Ebene";
            this.editInsertAtSameLevel.Size = new System.Drawing.Size(452, 19);
            this.editInsertAtSameLevel.TabIndex = 13;
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.edtFilterKandidaten);
            this.panDetail.Controls.Add(this.kissLabel1);
            this.panDetail.Controls.Add(this.lblDocContextName);
            this.panDetail.Controls.Add(this.editInsertAtSameLevel);
            this.panDetail.Controls.Add(this.lblDescription);
            this.panDetail.Controls.Add(this.btnAddFolder);
            this.panDetail.Controls.Add(this.edtDocContextName);
            this.panDetail.Controls.Add(this.edtFolderName);
            this.panDetail.Controls.Add(this.btnRemove);
            this.panDetail.Controls.Add(this.lblFolderName);
            this.panDetail.Controls.Add(this.btnAdd);
            this.panDetail.Controls.Add(this.btnUp);
            this.panDetail.Controls.Add(this.btnRemoveAll);
            this.panDetail.Controls.Add(this.btnDown);
            this.panDetail.Controls.Add(this.grdVerfuegbar);
            this.panDetail.Controls.Add(this.treZugeteilt);
            this.panDetail.Controls.Add(this.edtDescription);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetail.Location = new System.Drawing.Point(0, 124);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(900, 476);
            this.panDetail.TabIndex = 0;
            // 
            // edtFilterKandidaten
            // 
            this.edtFilterKandidaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilterKandidaten.Location = new System.Drawing.Point(100, 412);
            this.edtFilterKandidaten.Name = "edtFilterKandidaten";
            this.edtFilterKandidaten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterKandidaten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterKandidaten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterKandidaten.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterKandidaten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterKandidaten.Properties.Appearance.Options.UseFont = true;
            this.edtFilterKandidaten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterKandidaten.Size = new System.Drawing.Size(207, 24);
            this.edtFilterKandidaten.TabIndex = 16;
            this.edtFilterKandidaten.EditValueChanged += new System.EventHandler(this.edtFilterKandidaten_EditValueChanged);
            // 
            // kissLabel1
            // 
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.Location = new System.Drawing.Point(9, 413);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(85, 24);
            this.kissLabel1.TabIndex = 15;
            this.kissLabel1.Text = "Filter";
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panDetail;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 116);
            this.splitter.MinSize = 250;
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // CtlDocContext
            // 
            this.ActiveSQLQuery = this.qryDocContext;
            this.Controls.Add(this.grdDocContext);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panDetail);
            this.Name = "CtlDocContext";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.CtlUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocContextName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocContextName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFolderName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFolderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInsertAtSameLevel.Properties)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterKandidaten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (sender == btnAdd && (qryDocContext.Count == 0 || qryVerfuegbar.Count == 0))
            {
                return;
            }

            if (qryDocContext.Row.RowState == DataRowState.Added && !qryDocContext.Post())
            {
                return;
            }

            string newFolderName = null;

            if (sender == btnAddFolder)
            {
                if (DBUtil.IsEmpty(edtFolderName.Text))
                {
                    KissMsg.ShowInfo(Name, "NameNeuerOrdnerLeer", "Der Name des neuen Ordners muss zuerst im Feld 'Ordnername' eingeben werden!");
                    return;
                }

                newFolderName = edtFolderName.Text;
            }

            Object newParentID = DBNull.Value;
            Int32 newPosition = 1;
            Object newDocumentID = null;

            if (sender == btnAdd)
            {
                newDocumentID = qryVerfuegbar["DocTemplateID"];
            }

            if (qryZugeteilt.Count > 0)
            {
                if (editInsertAtSameLevel.Checked || DBUtil.IsEmpty(qryZugeteilt["Foldername"]))
                {
                    newParentID = qryZugeteilt["ParentID"];
                }
                else
                {
                    newParentID = (int)qryZugeteilt["XDocContext_TemplateID"];
                }

                newPosition = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MAX(ParentPosition) + 1, 1)
                    FROM dbo.XDocContext_Template WITH (READUNCOMMITTED)
                    WHERE DocContextID = {0}
                      AND ISNULL(ParentID, 0) = ISNULL({1}, 0);", qryDocContext["DocContextID"], newParentID));
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                INSERT dbo.XDocContext_Template (DocContextID, DocTemplateID, FolderName, ParentID, ParentPosition)
                VALUES ({0}, {1}, {2}, {3}, {4});

                SELECT XDocContext_TemplateID = SCOPE_IDENTITY();", qryDocContext["DocContextID"], newDocumentID, newFolderName, newParentID, newPosition);

            int newRowHandle = grdVerfuegbar.View.GetNextVisibleRow(grdVerfuegbar.View.FocusedRowHandle);

            if (newRowHandle == GridControl.InvalidRowHandle)
            {
                DisplayVerfuegbar(null);
            }
            else
            {
                DisplayVerfuegbar(qryVerfuegbar["DocTemplateID"]);
            }

            DisplayZugeteilt(qry.Count > 0 ? qry[DBO.XDocContext_Template.XDocContext_TemplateID] : null);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            btnUp.Enabled = false;
            btnDown.Enabled = false;

            if (qryZugeteilt.Count <= 1)
            {
                return;
            }
            if (!qryZugeteilt.Post())
            {
                return;
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 DCT.*
                FROM dbo.XDocContext_Template DCT WITH (READUNCOMMITTED)
                WHERE ISNULL(DCT.ParentID, 0) = ISNULL({0}, 0) AND
                      DCT.ParentPosition > {1} AND
                      DocContextID = {2}
                ORDER BY DCT.ParentPosition;", qryZugeteilt["ParentID"], qryZugeteilt["ParentPosition"], qryZugeteilt["DocContextID"]);

            if (qry.Count == 0)
            {
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                return;
            }

            // start new transaction
            Session.BeginTransaction();

            try
            {
                // Position tauschen
                DBUtil.ExecSQL(@"
                    UPDATE dbo.XDocContext_Template
                    SET ParentPosition = {0}
                    WHERE XDocContext_TemplateID = {1};", qry["ParentPosition"], qryZugeteilt["XDocContext_TemplateID"]);

                DBUtil.ExecSQL(@"
                    UPDATE dbo.XDocContext_Template
                    SET ParentPosition = {0}
                    WHERE XDocContext_TemplateID = {1};", qryZugeteilt["ParentPosition"], qry["XDocContext_TemplateID"]);

                // save changes
                Session.Commit();
            }
            catch (Exception ex)
            {
                // undo changes
                Session.Rollback();

                // show message
                KissMsg.ShowError(Name, "ErrorMoveItemDown", "Es ist ein Fehler beim Verschieben des Eintrages aufgetreten.", ex);
            }

            DisplayZugeteilt(qryZugeteilt["XDocContext_TemplateID"]);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryDocContext.Count == 0 || qryZugeteilt.Count == 0 || qryDocContext.Row.RowState == DataRowState.Added)
            {
                return;
            }

            if (!DBUtil.IsEmpty(qryZugeteilt["FolderName"]))
            {
                int count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.XDocContext_Template WITH (READUNCOMMITTED)
                    WHERE DocContextID = {0}
                      AND ParentID = {1};", qryDocContext["DocContextID"], qryZugeteilt["XDocContext_TemplateID"]));

                if (count > 0)
                {
                    KissMsg.ShowInfo(Name, "OrdnerEntfernenNichtMoeglich", "Dieser Ordner kann nicht entfernt werden, da er noch Vorlagen oder Ordner enthält.");
                    return;
                }
            }

            object docTemplateID = qryZugeteilt["DocTemplateID"];
            qryZugeteilt.Delete();

            if (!DBUtil.IsEmpty(docTemplateID))
            {
                DisplayVerfuegbar(docTemplateID);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (qryDocContext.Count == 0 || qryZugeteilt.Count == 0 || qryDocContext.Row.RowState == DataRowState.Added)
            {
                return;
            }

            if (!KissMsg.ShowQuestion(Name, "ZugeteilteVorlagenEntfernen_v01", "Dies entfernt alle zugeteilten Vorlagen und Ordner. Wollen Sie alle zugeteilten Vorlagen entfernen?"))
            {
                return;
            }

            DBUtil.ExecSQL(@"
                DELETE
                FROM dbo.XDocContext_Template
                WHERE DocContextID = {0};", qryDocContext["DocContextID"]);

            DisplayZugeteilt(null);
            DisplayVerfuegbar(null);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            btnUp.Enabled = false;
            btnDown.Enabled = false;

            if (qryZugeteilt.Count <= 1)
            {
                return;
            }
            if (!qryZugeteilt.Post())
            {
                return;
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       DCT.*
                FROM dbo.XDocContext_Template DCT WITH (READUNCOMMITTED)
                WHERE ISNULL(DCT.ParentID, 0) = ISNULL({0}, 0)
                  AND DCT.ParentPosition < {1}
                  AND DCT.DocContextID = {2}
                ORDER BY DCT.ParentPosition DESC;", qryZugeteilt["ParentID"], qryZugeteilt["ParentPosition"], qryZugeteilt["DocContextID"]);

            if (qry.Count == 0)
            {
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                return;
            }

            // start new transaction
            Session.BeginTransaction();

            try
            {
                //Position tauschen
                DBUtil.ExecSQL(@"
                    UPDATE dbo.XDocContext_Template
                    SET ParentPosition = {0}
                    WHERE XDocContext_TemplateID = {1};", qry["ParentPosition"], qryZugeteilt["XDocContext_TemplateID"]);

                DBUtil.ExecSQL(@"
                    UPDATE dbo.XDocContext_Template
                    SET ParentPosition = {0}
                    WHERE XDocContext_TemplateID = {1};", qryZugeteilt["ParentPosition"], qry["XDocContext_TemplateID"]);

                // save changes
                Session.Commit();
            }
            catch (Exception ex)
            {
                // undo changes
                Session.Rollback();

                // show message
                KissMsg.ShowError(Name, "ErrorMoveItemUp", "Es ist ein Fehler beim Verschieben des Eintrages aufgetreten.", ex);
            }

            DisplayZugeteilt(qryZugeteilt["XDocContext_TemplateID"]);
        }

        private void CtlUser_Load(object sender, EventArgs e)
        {
            treZugeteilt.OptionsBehavior.Editable = true;

            qryDocContext.Fill();

            qryZugeteilt.DeleteQuestion = null;
        }

        private void edtFilterKandidaten_EditValueChanged(object sender, EventArgs e)
        {
            var searchString = "";

            if (!DBUtil.IsEmpty(edtFilterKandidaten.EditValue))
            {
                searchString = edtFilterKandidaten.EditValue.ToString();
            }

            qryVerfuegbar.DataTable.DefaultView.RowFilter = "DocTemplateName LIKE '%" + (searchString).Replace("'", "''") + "%'";
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
        }

        private void qryDocContext_AfterInsert(object sender, EventArgs e)
        {
            edtDocContextName.Focus();
        }

        private void qryDocContext_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            //prüfen, ob noch zugeteilte Vorlagen/Ordner existieren
            int count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.XDocContext_Template WITH (READUNCOMMITTED)
                WHERE DocContextID = {0};", qryDocContext["DocContextID"]));

            if (count > 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name, "KontextNichtGeloeschtOrdnerVorhanden", "Der Kontext '{0}' kann nicht gelöscht werden, solange noch zugeteilte Vorlagen/Ordner existieren!", KissMsgCode.MsgInfo, qryDocContext["DocContextName"].ToString()));
            }
        }

        private void qryDocContext_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDocContextName, lblDocContextName.Text);
        }

        private void qryDocContext_PositionChanged(object sender, EventArgs e)
        {
            DisplayZugeteilt(null);
            DisplayVerfuegbar(null);

            edtFolderName.EditMode = EditModeType.Normal;

            // setup colors and gridviews
            SetupGridViews();
        }

        private void treZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            if (btnRemove.Enabled)
            {
                btnRemove.PerformClick();
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void DisplayVerfuegbar(object relocateID)
        {
            qryVerfuegbar.Fill(qryDocContext["DocContextID"]);

            if (relocateID != null)
            {
                int rowHandle = grdVerfuegbar.View.LocateByValue(0, grdVerfuegbar.View.Columns["DocTemplateID"], (int)relocateID);

                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    grdVerfuegbar.View.FocusedRowHandle = rowHandle;
                }
            }
        }

        private void DisplayZugeteilt(object relocateID)
        {
            qryZugeteilt.Fill(qryDocContext["DocContextID"]);

            treZugeteilt.ExpandAll();

            if (relocateID != null)
            {
                //relocate to ID
                TreeListNode node = DBUtil.FindNodeByValue(treZugeteilt.Nodes, relocateID.ToString(), "XDocContext_TemplateID");

                if (node != null)
                {
                    treZugeteilt.FocusedNode = node;
                }
            }

            btnUp.Enabled = true;
            btnDown.Enabled = true;
        }

        private void SetupGridViews()
        {
            grvDocContext.OptionsView.ColumnAutoWidth = true;
            grvVerfuegbar.OptionsView.ColumnAutoWidth = true;
            treZugeteilt.OptionsView.AutoWidth = true;
        }

        #endregion

        #endregion
    }
}