namespace KiSS4.Administration
{
    partial class CtlHyperlinkContext
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlHyperlinkContext));
            this.grdHyperlinkContext = new KiSS4.Gui.KissGrid();
            this.qryHyperlinkContext = new KiSS4.DB.SqlQuery();
            this.grvHyperlinkContext = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHyperlinkContextName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery();
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerfuegbar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery();
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.treZugeteilt = new KiSS4.Gui.KissTree();
            this.colZugeteilteVorlage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUserProfileCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.edtFolderName = new KiSS4.Gui.KissTextEdit();
            this.lblFolderName = new KiSS4.Gui.KissLabel();
            this.btnAddFolder = new KiSS4.Gui.KissButton();
            this.edtInsertAtSameLevel = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHyperlinkContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHyperlinkContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHyperlinkContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFolderName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFolderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInsertAtSameLevel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdHyperlinkContext
            // 
            this.grdHyperlinkContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdHyperlinkContext.DataSource = this.qryHyperlinkContext;
            // 
            // 
            // 
            this.grdHyperlinkContext.EmbeddedNavigator.Name = "";
            this.grdHyperlinkContext.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdHyperlinkContext.Location = new System.Drawing.Point(10, 10);
            this.grdHyperlinkContext.MainView = this.grvHyperlinkContext;
            this.grdHyperlinkContext.Name = "grdHyperlinkContext";
            this.grdHyperlinkContext.Size = new System.Drawing.Size(794, 166);
            this.grdHyperlinkContext.TabIndex = 0;
            this.grdHyperlinkContext.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHyperlinkContext});
            // 
            // qryHyperlinkContext
            // 
            this.qryHyperlinkContext.CanDelete = true;
            this.qryHyperlinkContext.CanInsert = true;
            this.qryHyperlinkContext.CanUpdate = true;
            this.qryHyperlinkContext.HostControl = this;
            this.qryHyperlinkContext.TableName = "XHyperlinkContext";
            this.qryHyperlinkContext.AfterInsert += new System.EventHandler(this.qryHyperlinkContext_AfterInsert);
            this.qryHyperlinkContext.BeforePost += new System.EventHandler(this.qryHyperlinkContext_BeforePost);
            this.qryHyperlinkContext.BeforeDeleteQuestion += new System.EventHandler(this.qryHyperlinkContext_BeforeDeleteQuestion);
            this.qryHyperlinkContext.PositionChanged += new System.EventHandler(this.qryHyperlinkContext_PositionChanged);
            // 
            // grvHyperlinkContext
            // 
            this.grvHyperlinkContext.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvHyperlinkContext.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.Empty.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.Empty.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.EvenRow.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHyperlinkContext.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvHyperlinkContext.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.FocusedCell.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvHyperlinkContext.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHyperlinkContext.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvHyperlinkContext.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.FocusedRow.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvHyperlinkContext.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHyperlinkContext.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHyperlinkContext.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHyperlinkContext.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHyperlinkContext.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.GroupRow.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvHyperlinkContext.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvHyperlinkContext.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvHyperlinkContext.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHyperlinkContext.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvHyperlinkContext.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvHyperlinkContext.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHyperlinkContext.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvHyperlinkContext.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvHyperlinkContext.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.OddRow.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvHyperlinkContext.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.Row.Options.UseBackColor = true;
            this.grvHyperlinkContext.Appearance.Row.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHyperlinkContext.Appearance.SelectedRow.Options.UseFont = true;
            this.grvHyperlinkContext.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvHyperlinkContext.Appearance.VertLine.Options.UseBackColor = true;
            this.grvHyperlinkContext.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvHyperlinkContext.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHyperlinkContextName,
            this.colDescription});
            this.grvHyperlinkContext.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvHyperlinkContext.GridControl = this.grdHyperlinkContext;
            this.grvHyperlinkContext.Name = "grvHyperlinkContext";
            this.grvHyperlinkContext.OptionsBehavior.Editable = false;
            this.grvHyperlinkContext.OptionsCustomization.AllowFilter = false;
            this.grvHyperlinkContext.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvHyperlinkContext.OptionsNavigation.AutoFocusNewRow = true;
            this.grvHyperlinkContext.OptionsNavigation.UseTabKey = false;
            this.grvHyperlinkContext.OptionsView.ColumnAutoWidth = false;
            this.grvHyperlinkContext.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvHyperlinkContext.OptionsView.ShowGroupPanel = false;
            this.grvHyperlinkContext.OptionsView.ShowIndicator = false;
            // 
            // colHyperlinkContextName
            // 
            this.colHyperlinkContextName.AppearanceCell.Options.UseTextOptions = true;
            this.colHyperlinkContextName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colHyperlinkContextName.Caption = "Kontextname";
            this.colHyperlinkContextName.FieldName = "Name";
            this.colHyperlinkContextName.Name = "colHyperlinkContextName";
            this.colHyperlinkContextName.Visible = true;
            this.colHyperlinkContextName.VisibleIndex = 0;
            this.colHyperlinkContextName.Width = 226;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 519;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(10, 218);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 24);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Beschreibung";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 188);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Kontextname";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryHyperlinkContext;
            this.edtName.Location = new System.Drawing.Point(90, 188);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(714, 24);
            this.edtName.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(340, 362);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(340, 332);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(340, 391);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 8;
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
            this.grdVerfuegbar.Location = new System.Drawing.Point(10, 292);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(319, 195);
            this.grdVerfuegbar.TabIndex = 5;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
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
            this.colFormat.Caption = "Linkname";
            this.colFormat.FieldName = "Name";
            this.colFormat.Name = "colFormat";
            this.colFormat.Visible = true;
            this.colFormat.VisibleIndex = 0;
            this.colFormat.Width = 133;
            // 
            // colVerfuegbar
            // 
            this.colVerfuegbar.Caption = "Link";
            this.colVerfuegbar.FieldName = "Hyperlink";
            this.colVerfuegbar.Name = "colVerfuegbar";
            this.colVerfuegbar.Visible = true;
            this.colVerfuegbar.VisibleIndex = 1;
            this.colVerfuegbar.Width = 269;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "0026_TeilPhase.ICO");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            this.qryZugeteilt.TableName = "XHyperlinkContext_Hyperlink";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "Description";
            this.edtDescription.DataSource = this.qryHyperlinkContext;
            this.edtDescription.Location = new System.Drawing.Point(90, 218);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(714, 60);
            this.edtDescription.TabIndex = 4;
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
            this.colZugeteilteVorlage,
            this.colUserProfileCode});
            this.treZugeteilt.DataSource = this.qryZugeteilt;
            this.treZugeteilt.ImageIndexFieldName = "IconID";
            this.treZugeteilt.KeyFieldName = "XHyperlinkContext_HyperlinkID";
            this.treZugeteilt.Location = new System.Drawing.Point(382, 291);
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
            this.treZugeteilt.SelectImageList = this.imageList1;
            this.treZugeteilt.Size = new System.Drawing.Size(422, 238);
            this.treZugeteilt.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treZugeteilt.TabIndex = 12;
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
            this.colZugeteilteVorlage.Width = 280;
            // 
            // colUserProfileCode
            // 
            this.colUserProfileCode.Caption = "Profil";
            this.colUserProfileCode.FieldName = "UserProfileCode";
            this.colUserProfileCode.Name = "colUserProfileCode";
            this.colUserProfileCode.OptionsColumn.AllowMove = false;
            this.colUserProfileCode.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colUserProfileCode.OptionsColumn.AllowSort = false;
            this.colUserProfileCode.VisibleIndex = 1;
            this.colUserProfileCode.Width = 95;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(812, 328);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 13;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(812, 358);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 14;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // edtFolderName
            // 
            this.edtFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFolderName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFolderName.Location = new System.Drawing.Point(90, 505);
            this.edtFolderName.Name = "edtFolderName";
            this.edtFolderName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFolderName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFolderName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFolderName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFolderName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFolderName.Properties.Appearance.Options.UseFont = true;
            this.edtFolderName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFolderName.Properties.ReadOnly = true;
            this.edtFolderName.Size = new System.Drawing.Size(239, 24);
            this.edtFolderName.TabIndex = 10;
            // 
            // lblFolderName
            // 
            this.lblFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFolderName.Location = new System.Drawing.Point(12, 505);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(72, 24);
            this.lblFolderName.TabIndex = 9;
            this.lblFolderName.Text = "Ordnername";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.IconID = 13;
            this.btnAddFolder.Location = new System.Drawing.Point(340, 505);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(28, 24);
            this.btnAddFolder.TabIndex = 11;
            this.btnAddFolder.UseVisualStyleBackColor = false;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // edtInsertAtSameLevel
            // 
            this.edtInsertAtSameLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtInsertAtSameLevel.EditValue = false;
            this.edtInsertAtSameLevel.Location = new System.Drawing.Point(382, 534);
            this.edtInsertAtSameLevel.Name = "edtInsertAtSameLevel";
            this.edtInsertAtSameLevel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInsertAtSameLevel.Properties.Appearance.Options.UseBackColor = true;
            this.edtInsertAtSameLevel.Properties.Caption = "Einfügen auf derselben Ebene";
            this.edtInsertAtSameLevel.Size = new System.Drawing.Size(396, 19);
            this.edtInsertAtSameLevel.TabIndex = 15;
            // 
            // CtlHyperlinkContext
            // 
            this.ActiveSQLQuery = this.qryHyperlinkContext;
            this.Controls.Add(this.edtInsertAtSameLevel);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.edtFolderName);
            this.Controls.Add(this.lblFolderName);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.treZugeteilt);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.grdVerfuegbar);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.grdHyperlinkContext);
            this.Name = "CtlHyperlinkContext";
            this.Size = new System.Drawing.Size(846, 561);
            this.Load += new System.EventHandler(this.CtlUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdHyperlinkContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHyperlinkContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHyperlinkContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFolderName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFolderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInsertAtSameLevel.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHyperlinkContext;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissGrid grdHyperlinkContext;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private DevExpress.XtraGrid.Columns.GridColumn colHyperlinkContextName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private KiSS4.DB.SqlQuery qryHyperlinkContext;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissMemoEdit edtDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colZugeteilteVorlage;
        private DevExpress.XtraGrid.Columns.GridColumn colFormat;
        private KiSS4.Gui.KissTree treZugeteilt;
        private KiSS4.Gui.KissButton btnUp;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissLabel lblFolderName;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegbar;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserProfileCode;
        private KiSS4.Gui.KissTextEdit edtFolderName;
        private KiSS4.Gui.KissButton btnAddFolder;
        private KiSS4.Gui.KissCheckEdit edtInsertAtSameLevel;
    }
}
