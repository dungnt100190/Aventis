namespace KiSS4.Sozialhilfe
{
    partial class CtlWhASVSExport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhASVSExport));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colProblem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryASVS = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.grdASVSExport = new KiSS4.Gui.KissGrid();
            this.grvASVSExport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExportieren = new KiSS4.Gui.KissButton();
            this.edtBemerkung = new KiSS4.Gui.KissTextEdit();
            this.qryDokCorr = new KiSS4.DB.SqlQuery(this.components);
            this.grdASVSEintrag = new KiSS4.Gui.KissGrid();
            this.qryASVSEintrag = new KiSS4.DB.SqlQuery(this.components);
            this.grvASVSEintrag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWiderruf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblExportierteEintraege = new KiSS4.Gui.KissLabel();
            this.btnSpeichernUnter = new KiSS4.Gui.KissButton();
            this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.qrySektion = new KiSS4.DB.SqlQuery(this.components);
            this.lblSektion = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryASVS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdASVSExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvASVSExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDokCorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdASVSEintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryASVSEintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvASVSEintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportierteEintraege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            this.SuspendLayout();
            // 
            // colProblem
            // 
            this.colProblem.Caption = "Problem";
            this.colProblem.FieldName = "Problem";
            this.colProblem.Name = "colProblem";
            // 
            // qryASVS
            // 
            this.qryASVS.CanInsert = true;
            this.qryASVS.CanUpdate = true;
            this.qryASVS.HostControl = this;
            this.qryASVS.SelectStatement = resources.GetString("qryASVS.SelectStatement");
            this.qryASVS.TableName = "SstASVSExport";
            this.qryASVS.AfterInsert += new System.EventHandler(this.qryASVS_AfterInsert);
            this.qryASVS.BeforePost += new System.EventHandler(this.qryASVS_BeforePost);
            this.qryASVS.PositionChanged += new System.EventHandler(this.qryASVS_PositionChanged);
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(12, 11);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(183, 20);
            this.lblTitel.TabIndex = 477;
            this.lblTitel.Text = "ASV-Datenerfassung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(25, 611);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(70, 24);
            this.lblBemerkung.TabIndex = 479;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // grdASVSExport
            // 
            this.grdASVSExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdASVSExport.DataSource = this.qryASVS;
            // 
            // 
            // 
            this.grdASVSExport.EmbeddedNavigator.Name = "";
            this.grdASVSExport.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdASVSExport.Location = new System.Drawing.Point(12, 34);
            this.grdASVSExport.MainView = this.grvASVSExport;
            this.grdASVSExport.Name = "grdASVSExport";
            this.grdASVSExport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1});
            this.grdASVSExport.Size = new System.Drawing.Size(1040, 240);
            this.grdASVSExport.TabIndex = 476;
            this.grdASVSExport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvASVSExport});
            // 
            // grvASVSExport
            // 
            this.grvASVSExport.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvASVSExport.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.Empty.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.Empty.Options.UseFont = true;
            this.grvASVSExport.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.EvenRow.Options.UseFont = true;
            this.grvASVSExport.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvASVSExport.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvASVSExport.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.FocusedCell.Options.UseFont = true;
            this.grvASVSExport.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvASVSExport.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvASVSExport.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvASVSExport.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.FocusedRow.Options.UseFont = true;
            this.grvASVSExport.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvASVSExport.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvASVSExport.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvASVSExport.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvASVSExport.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvASVSExport.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.GroupRow.Options.UseFont = true;
            this.grvASVSExport.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvASVSExport.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvASVSExport.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvASVSExport.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvASVSExport.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvASVSExport.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvASVSExport.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvASVSExport.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvASVSExport.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvASVSExport.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvASVSExport.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvASVSExport.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.OddRow.Options.UseFont = true;
            this.grvASVSExport.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvASVSExport.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.Row.Options.UseBackColor = true;
            this.grvASVSExport.Appearance.Row.Options.UseFont = true;
            this.grvASVSExport.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSExport.Appearance.SelectedRow.Options.UseFont = true;
            this.grvASVSExport.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvASVSExport.Appearance.VertLine.Options.UseBackColor = true;
            this.grvASVSExport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvASVSExport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumExport,
            this.colUser,
            this.colBemerkung});
            this.grvASVSExport.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvASVSExport.GridControl = this.grdASVSExport;
            this.grvASVSExport.Name = "grvASVSExport";
            this.grvASVSExport.OptionsBehavior.Editable = false;
            this.grvASVSExport.OptionsCustomization.AllowFilter = false;
            this.grvASVSExport.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvASVSExport.OptionsNavigation.AutoFocusNewRow = true;
            this.grvASVSExport.OptionsNavigation.UseTabKey = false;
            this.grvASVSExport.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvASVSExport.OptionsView.ColumnAutoWidth = false;
            this.grvASVSExport.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvASVSExport.OptionsView.ShowGroupPanel = false;
            this.grvASVSExport.OptionsView.ShowIndicator = false;
            // 
            // colDatumExport
            // 
            this.colDatumExport.Caption = "Export-Datum";
            this.colDatumExport.FieldName = "DatumExport";
            this.colDatumExport.Name = "colDatumExport";
            this.colDatumExport.Visible = true;
            this.colDatumExport.VisibleIndex = 0;
            this.colDatumExport.Width = 167;
            // 
            // colUser
            // 
            this.colUser.Caption = "Benutzer";
            this.colUser.FieldName = "Creator";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 1;
            this.colUser.Width = 160;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 2;
            this.colBemerkung.Width = 557;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnExportieren
            // 
            this.btnExportieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportieren.Location = new System.Drawing.Point(892, 611);
            this.btnExportieren.Name = "btnExportieren";
            this.btnExportieren.Size = new System.Drawing.Size(160, 24);
            this.btnExportieren.TabIndex = 481;
            this.btnExportieren.Text = "Neue Einträge exportieren";
            this.btnExportieren.UseCompatibleTextRendering = true;
            this.btnExportieren.UseVisualStyleBackColor = false;
            this.btnExportieren.Click += new System.EventHandler(this.btnExportieren_Click);
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryASVS;
            this.edtBemerkung.Location = new System.Drawing.Point(101, 611);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(493, 24);
            this.edtBemerkung.TabIndex = 482;
            // 
            // qryDokCorr
            // 
            this.qryDokCorr.CanDelete = true;
            this.qryDokCorr.CanInsert = true;
            this.qryDokCorr.CanUpdate = true;
            this.qryDokCorr.HostControl = this;
            this.qryDokCorr.SelectStatement = resources.GetString("qryDokCorr.SelectStatement");
            this.qryDokCorr.TableName = "XDocument";
            // 
            // grdASVSEintrag
            // 
            this.grdASVSEintrag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdASVSEintrag.DataSource = this.qryASVSEintrag;
            // 
            // 
            // 
            this.grdASVSEintrag.EmbeddedNavigator.Name = "";
            this.grdASVSEintrag.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdASVSEintrag.Location = new System.Drawing.Point(12, 304);
            this.grdASVSEintrag.MainView = this.grvASVSEintrag;
            this.grdASVSEintrag.Name = "grdASVSEintrag";
            this.grdASVSEintrag.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit2,
            this.repositoryItemCheckEdit1});
            this.grdASVSEintrag.Size = new System.Drawing.Size(1040, 293);
            this.grdASVSEintrag.TabIndex = 483;
            this.grdASVSEintrag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvASVSEintrag});
            // 
            // qryASVSEintrag
            // 
            this.qryASVSEintrag.HostControl = this;
            this.qryASVSEintrag.SelectStatement = resources.GetString("qryASVSEintrag.SelectStatement");
            // 
            // grvASVSEintrag
            // 
            this.grvASVSEintrag.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvASVSEintrag.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.Empty.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.Empty.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.EvenRow.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvASVSEintrag.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvASVSEintrag.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.FocusedCell.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvASVSEintrag.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvASVSEintrag.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvASVSEintrag.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.FocusedRow.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvASVSEintrag.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvASVSEintrag.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvASVSEintrag.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvASVSEintrag.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvASVSEintrag.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.GroupRow.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvASVSEintrag.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvASVSEintrag.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvASVSEintrag.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvASVSEintrag.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvASVSEintrag.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvASVSEintrag.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvASVSEintrag.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvASVSEintrag.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvASVSEintrag.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.OddRow.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvASVSEintrag.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.Row.Options.UseBackColor = true;
            this.grvASVSEintrag.Appearance.Row.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEintrag.Appearance.SelectedRow.Options.UseFont = true;
            this.grvASVSEintrag.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvASVSEintrag.Appearance.VertLine.Options.UseBackColor = true;
            this.grvASVSEintrag.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvASVSEintrag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNameVorname,
            this.colBaPersonID,
            this.colAnmeldung,
            this.colAbmeldung,
            this.colWiderruf,
            this.colProblem});
            this.grvASVSEintrag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colProblem;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.NotEqual;
            styleFormatCondition1.Value1 = "";
            this.grvASVSEintrag.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grvASVSEintrag.GridControl = this.grdASVSEintrag;
            this.grvASVSEintrag.Name = "grvASVSEintrag";
            this.grvASVSEintrag.OptionsBehavior.Editable = false;
            this.grvASVSEintrag.OptionsCustomization.AllowFilter = false;
            this.grvASVSEintrag.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvASVSEintrag.OptionsNavigation.AutoFocusNewRow = true;
            this.grvASVSEintrag.OptionsNavigation.UseTabKey = false;
            this.grvASVSEintrag.OptionsSelection.MultiSelect = true;
            this.grvASVSEintrag.OptionsView.ColumnAutoWidth = false;
            this.grvASVSEintrag.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvASVSEintrag.OptionsView.ShowGroupPanel = false;
            this.grvASVSEintrag.OptionsView.ShowIndicator = false;
            // 
            // colNameVorname
            // 
            this.colNameVorname.Caption = "Name";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 0;
            this.colNameVorname.Width = 204;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Person-ID";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 1;
            // 
            // colAnmeldung
            // 
            this.colAnmeldung.Caption = "Anmeldung";
            this.colAnmeldung.FieldName = "DatumVon";
            this.colAnmeldung.Name = "colAnmeldung";
            this.colAnmeldung.Visible = true;
            this.colAnmeldung.VisibleIndex = 2;
            // 
            // colAbmeldung
            // 
            this.colAbmeldung.Caption = "Abmeldung";
            this.colAbmeldung.FieldName = "DatumBis";
            this.colAbmeldung.Name = "colAbmeldung";
            this.colAbmeldung.Visible = true;
            this.colAbmeldung.VisibleIndex = 3;
            // 
            // colWiderruf
            // 
            this.colWiderruf.Caption = "Widerruf";
            this.colWiderruf.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colWiderruf.FieldName = "Widerruf";
            this.colWiderruf.Name = "colWiderruf";
            this.colWiderruf.Visible = true;
            this.colWiderruf.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // lblExportierteEintraege
            // 
            this.lblExportierteEintraege.ForeColor = System.Drawing.Color.Black;
            this.lblExportierteEintraege.Location = new System.Drawing.Point(12, 277);
            this.lblExportierteEintraege.Name = "lblExportierteEintraege";
            this.lblExportierteEintraege.Size = new System.Drawing.Size(303, 24);
            this.lblExportierteEintraege.TabIndex = 485;
            this.lblExportierteEintraege.Text = "Exportierte Einträge:";
            // 
            // btnSpeichernUnter
            // 
            this.btnSpeichernUnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpeichernUnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeichernUnter.Location = new System.Drawing.Point(747, 611);
            this.btnSpeichernUnter.Name = "btnSpeichernUnter";
            this.btnSpeichernUnter.Size = new System.Drawing.Size(121, 24);
            this.btnSpeichernUnter.TabIndex = 486;
            this.btnSpeichernUnter.Text = "Speichern unter ...";
            this.btnSpeichernUnter.UseCompatibleTextRendering = true;
            this.btnSpeichernUnter.UseVisualStyleBackColor = false;
            this.btnSpeichernUnter.Click += new System.EventHandler(this.btnSpeichernUnter_Click);
            // 
            // dlgFileSave
            // 
            this.dlgFileSave.FileName = "KiSS4_Report";
            this.dlgFileSave.Filter = "XML Files|*.xml|All files|*.*";
            // 
            // edtOrgUnitID
            // 
            this.edtOrgUnitID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtOrgUnitID.Location = new System.Drawing.Point(101, 641);
            this.edtOrgUnitID.Name = "edtOrgUnitID";
            this.edtOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrgUnitID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.DataSource = this.qrySektion;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(314, 24);
            this.edtOrgUnitID.TabIndex = 488;
            this.edtOrgUnitID.Visible = false;
            this.edtOrgUnitID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtOrgUnitID_UserModifiedFld);
            this.edtOrgUnitID.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.edtOrgUnitID_Spin);
            this.edtOrgUnitID.EditValueChanged += new System.EventHandler(this.edtOrgUnitID_EditValueChanged);
            // 
            // qrySektion
            // 
            this.qrySektion.HostControl = this;
            this.qrySektion.SelectStatement = "select\r\nCode = OrgUnitID,\r\nText = ItemName\r\nfrom XOrgUnit\r\norder by ItemName";
            // 
            // lblSektion
            // 
            this.lblSektion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSektion.Location = new System.Drawing.Point(22, 641);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(73, 24);
            this.lblSektion.TabIndex = 487;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            this.lblSektion.Visible = false;
            // 
            // CtlWhASVSExport
            // 
            this.ActiveSQLQuery = this.qryASVS;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.edtOrgUnitID);
            this.Controls.Add(this.lblSektion);
            this.Controls.Add(this.btnSpeichernUnter);
            this.Controls.Add(this.lblExportierteEintraege);
            this.Controls.Add(this.grdASVSEintrag);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.btnExportieren);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.grdASVSExport);
            this.Name = "CtlWhASVSExport";
            this.Size = new System.Drawing.Size(1069, 692);
            ((System.ComponentModel.ISupportInitialize)(this.qryASVS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdASVSExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvASVSExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDokCorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdASVSEintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryASVSEintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvASVSEintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportierteEintraege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissGrid grdASVSExport;
        private DevExpress.XtraGrid.Views.Grid.GridView grvASVSExport;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumExport;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissButton btnExportieren;
        private KiSS4.DB.SqlQuery qryASVS;
        private KiSS4.Gui.KissTextEdit edtBemerkung;
        private KiSS4.DB.SqlQuery qryDokCorr;
        private KiSS4.Gui.KissGrid grdASVSEintrag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvASVSEintrag;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private KiSS4.DB.SqlQuery qryASVSEintrag;
        private KiSS4.Gui.KissLabel lblExportierteEintraege;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colAbmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colWiderruf;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProblem;
        private KiSS4.Gui.KissButton btnSpeichernUnter;
        private System.Windows.Forms.SaveFileDialog dlgFileSave;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissLabel lblSektion;
        private KiSS4.DB.SqlQuery qrySektion;

    }
}