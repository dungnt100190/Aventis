namespace KiSS4.Query
{
    public partial class CtlReportDefinition
    {
        private System.Windows.Forms.OpenFileDialog dlgFileOpen;
        private KiSS4.Gui.KissButton btnDesign;
        private KiSS4.DB.SqlQuery qryXQuery;
        private KiSS4.Gui.KissMemoEdit edtParameterXml;
        private KiSS4.Gui.KissMemoEdit edtSqlQuery;
        private KiSS4.Gui.KissCheckEdit edtReadOnly;
        private KiSS4.Gui.KissButton btnImport;
        private KiSS4.Gui.KissTree kissTree1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UserText;
        private KiSS4.Gui.KissButton btnExport;
        private System.Windows.Forms.SaveFileDialog dlgFileSave;
        private KiSS4.Gui.KissTextEdit edtQueryName;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissTextEdit edtUserText;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissTextEdit edtParentReportName;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private KiSS4.Gui.KissTabControlEx tabXQuery;
        private SharpLibrary.WinControls.TabPageEx tabPageVerwaltung;
        private SharpLibrary.WinControls.TabPageEx tabPageZugriffsrechte;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissTextEdit edtContext;
        private KiSS4.Gui.KissGrid gridVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private KiSS4.Gui.KissGrid gridZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private DevExpress.XtraGrid.Columns.GridColumn colGruppen;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private System.Windows.Forms.ImageList imageList1;
        private KiSS4.Gui.KissButton btnExportAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissTextEdit edtSortKey;
        private KiSS4.Gui.KissCheckEdit edtImportLayout;
        private KiSS4.Gui.KissSplitter splitter;

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

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlReportDefinition));
            this.qryXQuery = new KiSS4.DB.SqlQuery(this.components);
            this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnDesign = new KiSS4.Gui.KissButton();
            this.edtParameterXml = new KiSS4.Gui.KissMemoEdit();
            this.edtSqlQuery = new KiSS4.Gui.KissMemoEdit();
            this.edtReadOnly = new KiSS4.Gui.KissCheckEdit();
            this.btnImport = new KiSS4.Gui.KissButton();
            this.kissTree1 = new KiSS4.Gui.KissTree();
            this.UserText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnExport = new KiSS4.Gui.KissButton();
            this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
            this.edtQueryName = new KiSS4.Gui.KissTextEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtUserText = new KiSS4.Gui.KissTextEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtParentReportName = new KiSS4.Gui.KissTextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter = new KiSS4.Gui.KissSplitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabXQuery = new KiSS4.Gui.KissTabControlEx();
            this.tabPageVerwaltung = new SharpLibrary.WinControls.TabPageEx();
            this.edtSystem = new KiSS4.Gui.KissCheckEdit();
            this.edtImportLayout = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtSortKey = new KiSS4.Gui.KissTextEdit();
            this.btnExportAll = new KiSS4.Gui.KissButton();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtContext = new KiSS4.Gui.KissTextEdit();
            this.tabPageZugriffsrechte = new SharpLibrary.WinControls.TabPageEx();
            this.gridVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGruppen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.qryXQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParameterXml.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSqlQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReadOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQueryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParentReportName.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabXQuery.SuspendLayout();
            this.tabPageVerwaltung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtImportLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtContext.Properties)).BeginInit();
            this.tabPageZugriffsrechte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // qryXQuery
            // 
            this.qryXQuery.DeleteQuestion = "Soll der Report \'[Usertext]\' gel�scht werden?";
            this.qryXQuery.HostControl = this;
            this.qryXQuery.TableName = "XQuery";
            this.qryXQuery.AfterInsert += new System.EventHandler(this.qryXQuery_AfterInsert);
            this.qryXQuery.PositionChanged += new System.EventHandler(this.qryXQuery_PositionChanged);
            // 
            // dlgFileOpen
            // 
            this.dlgFileOpen.Multiselect = true;
            // 
            // btnDesign
            // 
            this.btnDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesign.Enabled = false;
            this.btnDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesign.Location = new System.Drawing.Point(272, 495);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(95, 24);
            this.btnDesign.TabIndex = 10;
            this.btnDesign.Text = "Layout";
            this.btnDesign.UseVisualStyleBackColor = false;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // edtParameterXml
            // 
            this.edtParameterXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtParameterXml.DataMember = "ParameterXML";
            this.edtParameterXml.DataSource = this.qryXQuery;
            this.edtParameterXml.Location = new System.Drawing.Point(8, 308);
            this.edtParameterXml.Name = "edtParameterXml";
            this.edtParameterXml.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtParameterXml.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtParameterXml.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtParameterXml.Properties.Appearance.Options.UseBackColor = true;
            this.edtParameterXml.Properties.Appearance.Options.UseBorderColor = true;
            this.edtParameterXml.Properties.Appearance.Options.UseFont = true;
            this.edtParameterXml.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtParameterXml.ProportionalFont = false;
            this.edtParameterXml.Size = new System.Drawing.Size(576, 177);
            this.edtParameterXml.TabIndex = 6;
            // 
            // edtSqlQuery
            // 
            this.edtSqlQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSqlQuery.DataMember = "SQLquery";
            this.edtSqlQuery.DataSource = this.qryXQuery;
            this.edtSqlQuery.Location = new System.Drawing.Point(8, 136);
            this.edtSqlQuery.Name = "edtSqlQuery";
            this.edtSqlQuery.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSqlQuery.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSqlQuery.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSqlQuery.Properties.Appearance.Options.UseBackColor = true;
            this.edtSqlQuery.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSqlQuery.Properties.Appearance.Options.UseFont = true;
            this.edtSqlQuery.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSqlQuery.ProportionalFont = false;
            this.edtSqlQuery.Size = new System.Drawing.Size(576, 164);
            this.edtSqlQuery.TabIndex = 5;
            // 
            // edtReadOnly
            // 
            this.edtReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtReadOnly.EditValue = true;
            this.edtReadOnly.Location = new System.Drawing.Point(8, 491);
            this.edtReadOnly.Name = "edtReadOnly";
            this.edtReadOnly.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtReadOnly.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtReadOnly.Properties.Appearance.Options.UseBackColor = true;
            this.edtReadOnly.Properties.Appearance.Options.UseFont = true;
            this.edtReadOnly.Properties.Caption = "Schreibschutz";
            this.edtReadOnly.Size = new System.Drawing.Size(125, 19);
            this.edtReadOnly.TabIndex = 7;
            this.edtReadOnly.CheckedChanged += new System.EventHandler(this.edtReadOnly_CheckedChanged);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(168, 495);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 24);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // kissTree1
            // 
            this.kissTree1.AllowSortTree = true;
            this.kissTree1.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.kissTree1.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kissTree1.Appearance.Empty.Options.UseBackColor = true;
            this.kissTree1.Appearance.Empty.Options.UseForeColor = true;
            this.kissTree1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.kissTree1.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.EvenRow.Options.UseBackColor = true;
            this.kissTree1.Appearance.EvenRow.Options.UseForeColor = true;
            this.kissTree1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.kissTree1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.kissTree1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.kissTree1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.kissTree1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.kissTree1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.kissTree1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree1.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.kissTree1.Appearance.FooterPanel.Options.UseFont = true;
            this.kissTree1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.kissTree1.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.kissTree1.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.kissTree1.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.GroupButton.Options.UseBackColor = true;
            this.kissTree1.Appearance.GroupButton.Options.UseFont = true;
            this.kissTree1.Appearance.GroupButton.Options.UseForeColor = true;
            this.kissTree1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.kissTree1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.kissTree1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.kissTree1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.kissTree1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.kissTree1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.kissTree1.Appearance.HeaderPanel.Options.UseFont = true;
            this.kissTree1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.kissTree1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.kissTree1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.kissTree1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.kissTree1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kissTree1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.kissTree1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree1.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.kissTree1.Appearance.HorzLine.Options.UseBackColor = true;
            this.kissTree1.Appearance.HorzLine.Options.UseForeColor = true;
            this.kissTree1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.kissTree1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree1.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.OddRow.Options.UseBackColor = true;
            this.kissTree1.Appearance.OddRow.Options.UseFont = true;
            this.kissTree1.Appearance.OddRow.Options.UseForeColor = true;
            this.kissTree1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kissTree1.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.Preview.Options.UseBackColor = true;
            this.kissTree1.Appearance.Preview.Options.UseFont = true;
            this.kissTree1.Appearance.Preview.Options.UseForeColor = true;
            this.kissTree1.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.kissTree1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree1.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree1.Appearance.Row.Options.UseBackColor = true;
            this.kissTree1.Appearance.Row.Options.UseFont = true;
            this.kissTree1.Appearance.Row.Options.UseForeColor = true;
            this.kissTree1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.kissTree1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.kissTree1.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.kissTree1.Appearance.TreeLine.Options.UseBackColor = true;
            this.kissTree1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree1.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.kissTree1.Appearance.VertLine.Options.UseBackColor = true;
            this.kissTree1.Appearance.VertLine.Options.UseForeColor = true;
            this.kissTree1.Appearance.VertLine.Options.UseTextOptions = true;
            this.kissTree1.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.kissTree1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.UserText});
            this.kissTree1.DataSource = this.qryXQuery;
            this.kissTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissTree1.ImageIndexFieldName = "IconID";
            this.kissTree1.KeyFieldName = "QueryName";
            this.kissTree1.Location = new System.Drawing.Point(0, 0);
            this.kissTree1.Name = "kissTree1";
            this.kissTree1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.kissTree1.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.kissTree1.OptionsBehavior.Editable = false;
            this.kissTree1.OptionsBehavior.KeepSelectedOnClick = false;
            this.kissTree1.OptionsBehavior.MoveOnEdit = false;
            this.kissTree1.OptionsBehavior.ShowToolTips = false;
            this.kissTree1.OptionsBehavior.SmartMouseHover = false;
            this.kissTree1.OptionsMenu.EnableColumnMenu = false;
            this.kissTree1.OptionsMenu.EnableFooterMenu = false;
            this.kissTree1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.kissTree1.OptionsView.AutoWidth = false;
            this.kissTree1.OptionsView.EnableAppearanceEvenRow = true;
            this.kissTree1.OptionsView.EnableAppearanceOddRow = true;
            this.kissTree1.OptionsView.ShowIndicator = false;
            this.kissTree1.OptionsView.ShowVertLines = false;
            this.kissTree1.ParentFieldName = "ParentReportName";
            this.kissTree1.SelectImageList = this.imageList1;
            this.kissTree1.Size = new System.Drawing.Size(272, 576);
            this.kissTree1.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.kissTree1.TabIndex = 0;
            this.kissTree1.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.kissTree1_BeforeFocusNode);
            this.kissTree1.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.kissTree1_AfterFocusNode);
            // 
            // UserText
            // 
            this.UserText.Caption = "Beschreibung";
            this.UserText.FieldName = "UserText";
            this.UserText.MinWidth = 27;
            this.UserText.Name = "UserText";
            this.UserText.VisibleIndex = 0;
            this.UserText.Width = 257;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(376, 495);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 24);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dlgFileSave
            // 
            this.dlgFileSave.FileName = "KiSS4_Report";
            // 
            // edtQueryName
            // 
            this.edtQueryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtQueryName.DataMember = "QueryName";
            this.edtQueryName.DataSource = this.qryXQuery;
            this.edtQueryName.Location = new System.Drawing.Point(108, 8);
            this.edtQueryName.Name = "edtQueryName";
            this.edtQueryName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtQueryName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtQueryName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtQueryName.Properties.Appearance.Options.UseBackColor = true;
            this.edtQueryName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtQueryName.Properties.Appearance.Options.UseFont = true;
            this.edtQueryName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtQueryName.Size = new System.Drawing.Size(477, 24);
            this.edtQueryName.TabIndex = 0;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(8, 8);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(32, 24);
            this.kissLabel1.TabIndex = 17;
            this.kissLabel1.Text = "Name";
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(8, 40);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(72, 24);
            this.kissLabel2.TabIndex = 19;
            this.kissLabel2.Text = "Beschreibung";
            // 
            // edtUserText
            // 
            this.edtUserText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserText.DataMember = "UserText";
            this.edtUserText.DataSource = this.qryXQuery;
            this.edtUserText.Location = new System.Drawing.Point(108, 40);
            this.edtUserText.Name = "edtUserText";
            this.edtUserText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserText.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserText.Properties.Appearance.Options.UseFont = true;
            this.edtUserText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserText.Size = new System.Drawing.Size(477, 24);
            this.edtUserText.TabIndex = 1;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(8, 72);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(96, 24);
            this.kissLabel3.TabIndex = 21;
            this.kissLabel3.Text = "Hauptreport Name";
            // 
            // edtParentReportName
            // 
            this.edtParentReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtParentReportName.DataMember = "ParentReportName";
            this.edtParentReportName.DataSource = this.qryXQuery;
            this.edtParentReportName.Location = new System.Drawing.Point(108, 72);
            this.edtParentReportName.Name = "edtParentReportName";
            this.edtParentReportName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtParentReportName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtParentReportName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtParentReportName.Properties.Appearance.Options.UseBackColor = true;
            this.edtParentReportName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtParentReportName.Properties.Appearance.Options.UseFont = true;
            this.edtParentReportName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtParentReportName.Size = new System.Drawing.Size(372, 24);
            this.edtParentReportName.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitter);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 576);
            this.panel1.TabIndex = 22;
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(272, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 576);
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panel3.Controls.Add(this.tabXQuery);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(272, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(608, 576);
            this.panel3.TabIndex = 1;
            // 
            // tabXQuery
            // 
            this.tabXQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabXQuery.Controls.Add(this.tabPageVerwaltung);
            this.tabXQuery.Controls.Add(this.tabPageZugriffsrechte);
            this.tabXQuery.Location = new System.Drawing.Point(3, -4);
            this.tabXQuery.Name = "tabXQuery";
            this.tabXQuery.ShowFixedWidthTooltip = true;
            this.tabXQuery.Size = new System.Drawing.Size(605, 580);
            this.tabXQuery.TabIndex = 22;
            this.tabXQuery.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabPageVerwaltung,
            this.tabPageZugriffsrechte});
            this.tabXQuery.TabsLineColor = System.Drawing.Color.Black;
            this.tabXQuery.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabXQuery.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabXQuery.Text = "kissTabControlEx1";
            // 
            // tabPageVerwaltung
            // 
            this.tabPageVerwaltung.Controls.Add(this.edtSystem);
            this.tabPageVerwaltung.Controls.Add(this.edtImportLayout);
            this.tabPageVerwaltung.Controls.Add(this.kissLabel5);
            this.tabPageVerwaltung.Controls.Add(this.edtSortKey);
            this.tabPageVerwaltung.Controls.Add(this.btnExportAll);
            this.tabPageVerwaltung.Controls.Add(this.kissLabel4);
            this.tabPageVerwaltung.Controls.Add(this.edtContext);
            this.tabPageVerwaltung.Controls.Add(this.edtQueryName);
            this.tabPageVerwaltung.Controls.Add(this.kissLabel1);
            this.tabPageVerwaltung.Controls.Add(this.kissLabel2);
            this.tabPageVerwaltung.Controls.Add(this.edtUserText);
            this.tabPageVerwaltung.Controls.Add(this.kissLabel3);
            this.tabPageVerwaltung.Controls.Add(this.edtParentReportName);
            this.tabPageVerwaltung.Controls.Add(this.edtSqlQuery);
            this.tabPageVerwaltung.Controls.Add(this.edtParameterXml);
            this.tabPageVerwaltung.Controls.Add(this.btnExport);
            this.tabPageVerwaltung.Controls.Add(this.btnDesign);
            this.tabPageVerwaltung.Controls.Add(this.edtReadOnly);
            this.tabPageVerwaltung.Controls.Add(this.btnImport);
            this.tabPageVerwaltung.Location = new System.Drawing.Point(6, 32);
            this.tabPageVerwaltung.Name = "tabPageVerwaltung";
            this.tabPageVerwaltung.Size = new System.Drawing.Size(593, 542);
            this.tabPageVerwaltung.TabIndex = 0;
            this.tabPageVerwaltung.Title = "Verwaltung";
            // 
            // edtSystem
            // 
            this.edtSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSystem.DataMember = "System";
            this.edtSystem.DataSource = this.qryXQuery;
            this.edtSystem.Location = new System.Drawing.Point(8, 523);
            this.edtSystem.Name = "edtSystem";
            this.edtSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSystem.Properties.Appearance.Options.UseBackColor = true;
            this.edtSystem.Properties.Caption = "System";
            this.edtSystem.Size = new System.Drawing.Size(128, 19);
            this.edtSystem.TabIndex = 26;
            // 
            // edtImportLayout
            // 
            this.edtImportLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtImportLayout.EditValue = false;
            this.edtImportLayout.Location = new System.Drawing.Point(8, 507);
            this.edtImportLayout.Name = "edtImportLayout";
            this.edtImportLayout.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtImportLayout.Properties.Appearance.Options.UseBackColor = true;
            this.edtImportLayout.Properties.Caption = "Import Layout";
            this.edtImportLayout.Size = new System.Drawing.Size(128, 19);
            this.edtImportLayout.TabIndex = 8;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel5.Location = new System.Drawing.Point(488, 72);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(60, 24);
            this.kissLabel5.TabIndex = 25;
            this.kissLabel5.Text = "Reihenfolge";
            // 
            // edtSortKey
            // 
            this.edtSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSortKey.DataMember = "ReportSortKey";
            this.edtSortKey.DataSource = this.qryXQuery;
            this.edtSortKey.Location = new System.Drawing.Point(553, 72);
            this.edtSortKey.Name = "edtSortKey";
            this.edtSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseFont = true;
            this.edtSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortKey.Size = new System.Drawing.Size(32, 24);
            this.edtSortKey.TabIndex = 3;
            // 
            // btnExportAll
            // 
            this.btnExportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAll.Location = new System.Drawing.Point(480, 495);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(104, 24);
            this.btnExportAll.TabIndex = 12;
            this.btnExportAll.Text = "alle exportieren";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(8, 104);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(96, 24);
            this.kissLabel4.TabIndex = 23;
            this.kissLabel4.Text = "Kontext";
            // 
            // edtContext
            // 
            this.edtContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtContext.DataMember = "ContextForms";
            this.edtContext.DataSource = this.qryXQuery;
            this.edtContext.Location = new System.Drawing.Point(108, 104);
            this.edtContext.Name = "edtContext";
            this.edtContext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtContext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtContext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtContext.Properties.Appearance.Options.UseBackColor = true;
            this.edtContext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtContext.Properties.Appearance.Options.UseFont = true;
            this.edtContext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtContext.Size = new System.Drawing.Size(477, 24);
            this.edtContext.TabIndex = 4;
            // 
            // tabPageZugriffsrechte
            // 
            this.tabPageZugriffsrechte.Controls.Add(this.gridVerfuegbar);
            this.tabPageZugriffsrechte.Controls.Add(this.gridZugeteilt);
            this.tabPageZugriffsrechte.Controls.Add(this.btnAddAll);
            this.tabPageZugriffsrechte.Controls.Add(this.btnRemoveAll);
            this.tabPageZugriffsrechte.Controls.Add(this.btnAdd);
            this.tabPageZugriffsrechte.Controls.Add(this.btnRemove);
            this.tabPageZugriffsrechte.Location = new System.Drawing.Point(6, 32);
            this.tabPageZugriffsrechte.Name = "tabPageZugriffsrechte";
            this.tabPageZugriffsrechte.Size = new System.Drawing.Size(593, 542);
            this.tabPageZugriffsrechte.TabIndex = 1;
            this.tabPageZugriffsrechte.Title = "Zugriffsrechte";
            // 
            // gridVerfuegbar
            // 
            this.gridVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridVerfuegbar.DataSource = this.qryVerfuegbar;
            // 
            // 
            // 
            this.gridVerfuegbar.EmbeddedNavigator.Name = "";
            this.gridVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridVerfuegbar.Location = new System.Drawing.Point(12, 16);
            this.gridVerfuegbar.MainView = this.gridView3;
            this.gridVerfuegbar.Name = "gridVerfuegbar";
            this.gridVerfuegbar.Size = new System.Drawing.Size(260, 516);
            this.gridVerfuegbar.TabIndex = 0;
            this.gridVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.HostControl = this;
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGruppen});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GridControl = this.gridVerfuegbar;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colGruppen
            // 
            this.colGruppen.Caption = "Verf�gbare Gruppen";
            this.colGruppen.FieldName = "UserGroupName";
            this.colGruppen.Name = "colGruppen";
            this.colGruppen.Visible = true;
            this.colGruppen.VisibleIndex = 0;
            this.colGruppen.Width = 240;
            // 
            // gridZugeteilt
            // 
            this.gridZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridZugeteilt.DataSource = this.qryZugeteilt;
            // 
            // 
            // 
            this.gridZugeteilt.EmbeddedNavigator.Name = "";
            this.gridZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridZugeteilt.Location = new System.Drawing.Point(348, 16);
            this.gridZugeteilt.MainView = this.gridView2;
            this.gridZugeteilt.Name = "gridZugeteilt";
            this.gridZugeteilt.Size = new System.Drawing.Size(260, 516);
            this.gridZugeteilt.TabIndex = 5;
            this.gridZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "XUserGroup_Right";
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridZugeteilt;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colUser
            // 
            this.colUser.Caption = "Zugeteilte Gruppen";
            this.colUser.FieldName = "UserGroupName";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 238;
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(292, 232);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(34, 24);
            this.btnAddAll.TabIndex = 3;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(292, 264);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(34, 24);
            this.btnRemoveAll.TabIndex = 4;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(292, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(292, 196);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(34, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panel2.Controls.Add(this.kissTree1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 576);
            this.panel2.TabIndex = 0;
            // 
            // CtlReportDefinition
            // 
            this.ActiveSQLQuery = this.qryXQuery;
            this.Controls.Add(this.panel1);
            this.Name = "CtlReportDefinition";
            this.Size = new System.Drawing.Size(896, 592);
            this.Load += new System.EventHandler(this.CtlReportDefinition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryXQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParameterXml.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSqlQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReadOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQueryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParentReportName.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabXQuery.ResumeLayout(false);
            this.tabPageVerwaltung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtImportLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtContext.Properties)).EndInit();
            this.tabPageZugriffsrechte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissCheckEdit edtSystem;
    }
}