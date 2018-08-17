namespace KiSS4.Gui
{
    partial class KissDoubleListSelector
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.edtFilter2 = new KiSS4.Gui.KissTextEdit();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.grdSelected = new KiSS4.Gui.KissGrid();
            this.qrySelected = new KiSS4.DB.SqlQuery();
            this.grvSelected = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitleSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdAvailable = new KiSS4.Gui.KissGrid();
            this.qryAvailable = new KiSS4.DB.SqlQuery();
            this.grvAvailable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitleAvailable = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // kissLabel8
            // 
            this.kissLabel8.Location = new System.Drawing.Point(317, 178);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(35, 24);
            this.kissLabel8.TabIndex = 40;
            this.kissLabel8.Text = "Filter";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(3, 177);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(35, 24);
            this.kissLabel1.TabIndex = 39;
            this.kissLabel1.Text = "Filter";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(272, 117);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 38;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(272, 87);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 37;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(272, 57);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 36;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(272, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // edtFilter2
            // 
            this.edtFilter2.Location = new System.Drawing.Point(358, 177);
            this.edtFilter2.Name = "edtFilter2";
            this.edtFilter2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter2.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter2.Properties.Appearance.Options.UseFont = true;
            this.edtFilter2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter2.Size = new System.Drawing.Size(216, 24);
            this.edtFilter2.TabIndex = 34;
            this.edtFilter2.EditValueChanged += new System.EventHandler(this.edtFilter2_EditValueChanged);
            // 
            // edtFilter
            // 
            this.edtFilter.Location = new System.Drawing.Point(44, 177);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(216, 24);
            this.edtFilter.TabIndex = 33;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // grdSelected
            // 
            this.grdSelected.DataSource = this.qrySelected;
            // 
            // 
            // 
            this.grdSelected.EmbeddedNavigator.Name = "";
            this.grdSelected.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdSelected.Location = new System.Drawing.Point(317, 3);
            this.grdSelected.MainView = this.grvSelected;
            this.grdSelected.Name = "grdSelected";
            this.grdSelected.Size = new System.Drawing.Size(257, 168);
            this.grdSelected.TabIndex = 32;
            this.grdSelected.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSelected});
            this.grdSelected.DoubleClick += new System.EventHandler(this.grdSelected_DoubleClick);
            // 
            // qrySelected
            // 
            this.qrySelected.AutoApplyUserRights = false;
            this.qrySelected.BatchUpdate = true;
            this.qrySelected.CanDelete = true;
            this.qrySelected.CanInsert = true;
            this.qrySelected.HostControl = this;
            // 
            // grvSelected
            // 
            this.grvSelected.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSelected.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.Empty.Options.UseBackColor = true;
            this.grvSelected.Appearance.Empty.Options.UseFont = true;
            this.grvSelected.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvSelected.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvSelected.Appearance.EvenRow.Options.UseFont = true;
            this.grvSelected.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSelected.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSelected.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSelected.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSelected.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSelected.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSelected.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSelected.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSelected.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSelected.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSelected.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSelected.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSelected.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSelected.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSelected.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSelected.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSelected.Appearance.GroupRow.Options.UseFont = true;
            this.grvSelected.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSelected.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSelected.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSelected.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSelected.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSelected.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSelected.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSelected.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSelected.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSelected.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSelected.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSelected.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSelected.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSelected.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSelected.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.OddRow.Options.UseFont = true;
            this.grvSelected.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSelected.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.Row.Options.UseBackColor = true;
            this.grvSelected.Appearance.Row.Options.UseFont = true;
            this.grvSelected.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvSelected.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSelected.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvSelected.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvSelected.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSelected.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvSelected.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSelected.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSelected.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSelected.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitleSelected});
            this.grvSelected.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSelected.GridControl = this.grdSelected;
            this.grvSelected.Name = "grvSelected";
            this.grvSelected.OptionsBehavior.Editable = false;
            this.grvSelected.OptionsCustomization.AllowFilter = false;
            this.grvSelected.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSelected.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSelected.OptionsNavigation.UseTabKey = false;
            this.grvSelected.OptionsView.ColumnAutoWidth = false;
            this.grvSelected.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSelected.OptionsView.ShowGroupPanel = false;
            this.grvSelected.OptionsView.ShowIndicator = false;
            // 
            // colTitleSelected
            // 
            this.colTitleSelected.Caption = "Selected";
            this.colTitleSelected.FieldName = "Name";
            this.colTitleSelected.Name = "colTitleSelected";
            this.colTitleSelected.Visible = true;
            this.colTitleSelected.VisibleIndex = 0;
            this.colTitleSelected.Width = 253;
            // 
            // grdAvailable
            // 
            this.grdAvailable.DataSource = this.qryAvailable;
            // 
            // 
            // 
            this.grdAvailable.EmbeddedNavigator.Name = "";
            this.grdAvailable.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            gridLevelNode1.RelationName = "Level1";
            this.grdAvailable.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdAvailable.Location = new System.Drawing.Point(3, 3);
            this.grdAvailable.MainView = this.grvAvailable;
            this.grdAvailable.Name = "grdAvailable";
            this.grdAvailable.Size = new System.Drawing.Size(257, 168);
            this.grdAvailable.TabIndex = 31;
            this.grdAvailable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAvailable});
            this.grdAvailable.DoubleClick += new System.EventHandler(this.grdAvailable_DoubleClick);
            // 
            // qryAvailable
            // 
            this.qryAvailable.AutoApplyUserRights = false;
            this.qryAvailable.BatchUpdate = true;
            this.qryAvailable.CanDelete = true;
            this.qryAvailable.CanInsert = true;
            this.qryAvailable.DeleteQuestion = null;
            this.qryAvailable.HostControl = this;
            // 
            // grvAvailable
            // 
            this.grvAvailable.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAvailable.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.Empty.Options.UseBackColor = true;
            this.grvAvailable.Appearance.Empty.Options.UseFont = true;
            this.grvAvailable.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.EvenRow.Options.UseFont = true;
            this.grvAvailable.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAvailable.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAvailable.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAvailable.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAvailable.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAvailable.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAvailable.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAvailable.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAvailable.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAvailable.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAvailable.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAvailable.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAvailable.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAvailable.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAvailable.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAvailable.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAvailable.Appearance.GroupRow.Options.UseFont = true;
            this.grvAvailable.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAvailable.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAvailable.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAvailable.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAvailable.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAvailable.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAvailable.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAvailable.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAvailable.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAvailable.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAvailable.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAvailable.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAvailable.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAvailable.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAvailable.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.OddRow.Options.UseFont = true;
            this.grvAvailable.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAvailable.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.Row.Options.UseBackColor = true;
            this.grvAvailable.Appearance.Row.Options.UseFont = true;
            this.grvAvailable.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailable.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAvailable.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAvailable.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAvailable.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAvailable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitleAvailable});
            this.grvAvailable.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAvailable.GridControl = this.grdAvailable;
            this.grvAvailable.Name = "grvAvailable";
            this.grvAvailable.OptionsBehavior.Editable = false;
            this.grvAvailable.OptionsCustomization.AllowFilter = false;
            this.grvAvailable.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAvailable.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAvailable.OptionsNavigation.UseTabKey = false;
            this.grvAvailable.OptionsView.ColumnAutoWidth = false;
            this.grvAvailable.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAvailable.OptionsView.ShowGroupPanel = false;
            this.grvAvailable.OptionsView.ShowIndicator = false;
            // 
            // colTitleAvailable
            // 
            this.colTitleAvailable.Caption = "Available";
            this.colTitleAvailable.FieldName = "Name";
            this.colTitleAvailable.Name = "colTitleAvailable";
            this.colTitleAvailable.Visible = true;
            this.colTitleAvailable.VisibleIndex = 0;
            this.colTitleAvailable.Width = 253;
            // 
            // CtlMultiSelectListboxes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.edtFilter2);
            this.Controls.Add(this.edtFilter);
            this.Controls.Add(this.grdSelected);
            this.Controls.Add(this.grdAvailable);
            this.MaximumSize = new System.Drawing.Size(580, 210);
            this.MinimumSize = new System.Drawing.Size(580, 210);
            this.Name = "CtlMultiSelectListboxes";
            this.Size = new System.Drawing.Size(580, 210);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAvailable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KissLabel kissLabel8;
        private KissLabel kissLabel1;
        private KissButton btnRemoveAll;
        private KissButton btnAddAll;
        private KissButton btnRemove;
        private KissButton btnAdd;
        private KissTextEdit edtFilter2;
        private KissTextEdit edtFilter;
        private KissGrid grdSelected;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colTitleSelected;
        private KissGrid grdAvailable;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAvailable;
        private DevExpress.XtraGrid.Columns.GridColumn colTitleAvailable;
        private DB.SqlQuery qryAvailable;
        private DB.SqlQuery qrySelected;
    }
}
