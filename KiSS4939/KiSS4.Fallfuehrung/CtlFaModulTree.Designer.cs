namespace KiSS4.Fallfuehrung
{
    partial class CtlFaModulTree
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colName2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAufnahme = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSAR = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFaFallID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colModulID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFaPhaseID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaskName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnNewIntake = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewBeratungsphase = new DevExpress.XtraBars.BarButtonItem();
            this.panelThemenFilter = new System.Windows.Forms.Panel();
            this.editThemenfilter = new KiSS4.Gui.KissCheckEdit();
            this.panelThemen = new System.Windows.Forms.Panel();
            this.btnKeineThemen = new KiSS4.Gui.KissButton();
            this.btnAlleThemen = new KiSS4.Gui.KissButton();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.editThemen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.colAppCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            this.panelThemenFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editThemenfilter.Properties)).BeginInit();
            this.panelThemen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editThemen)).BeginInit();
            this.SuspendLayout();
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNewIntake,
            this.btnNewBeratungsphase,
            this.btnDelete});
            this.barManager_Tree.MaxItemId = 9;
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            //
            // btnFallInfo
            //
            this.btnFallInfo.CategoryGuid = new System.Guid("0a686651-24ab-43de-9233-cd9a623b13cc");
            this.btnFallInfo.Id = 7;
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.CategoryGuid = new System.Guid("0a686651-24ab-43de-9233-cd9a623b13cc");
            this.btnFallZugriff.Id = 6;
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewIntake),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewBeratungsphase),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo)});
            //
            // kissTree
            //
            this.kissTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kissTree.Appearance.Empty.Options.UseBackColor = true;
            this.kissTree.Appearance.Empty.Options.UseForeColor = true;
            this.kissTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.kissTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.EvenRow.Options.UseBackColor = true;
            this.kissTree.Appearance.EvenRow.Options.UseForeColor = true;
            this.kissTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.kissTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.kissTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.kissTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.kissTree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.kissTree.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.kissTree.Appearance.FooterPanel.Options.UseFont = true;
            this.kissTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupButton.Options.UseFont = true;
            this.kissTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.kissTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.kissTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.kissTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.kissTree.Appearance.HeaderPanel.Options.UseFont = true;
            this.kissTree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.kissTree.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.kissTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.kissTree.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kissTree.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.kissTree.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.kissTree.Appearance.HorzLine.Options.UseBackColor = true;
            this.kissTree.Appearance.HorzLine.Options.UseForeColor = true;
            this.kissTree.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.kissTree.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.OddRow.Options.UseBackColor = true;
            this.kissTree.Appearance.OddRow.Options.UseFont = true;
            this.kissTree.Appearance.OddRow.Options.UseForeColor = true;
            this.kissTree.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kissTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.Preview.Options.UseBackColor = true;
            this.kissTree.Appearance.Preview.Options.UseFont = true;
            this.kissTree.Appearance.Preview.Options.UseForeColor = true;
            this.kissTree.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.Row.Options.UseBackColor = true;
            this.kissTree.Appearance.Row.Options.UseFont = true;
            this.kissTree.Appearance.Row.Options.UseForeColor = true;
            this.kissTree.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.kissTree.Appearance.SelectedRow.Options.UseForeColor = true;
            this.kissTree.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.kissTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.kissTree.Appearance.VertLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.Options.UseForeColor = true;
            this.kissTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.kissTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.kissTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName2,
            this.colAufnahme,
            this.colSAR,
            this.colFaFallID,
            this.colModulID,
            this.colFaPhaseID,
            this.colMaskName,
            this.colAppCode});
            this.kissTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.kissTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.kissTree.OptionsBehavior.Editable = false;
            this.kissTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.kissTree.OptionsBehavior.MoveOnEdit = false;
            this.kissTree.OptionsBehavior.ShowToolTips = false;
            this.kissTree.OptionsBehavior.SmartMouseHover = false;
            this.kissTree.OptionsMenu.EnableColumnMenu = false;
            this.kissTree.OptionsMenu.EnableFooterMenu = false;
            this.kissTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.kissTree.OptionsView.AutoWidth = false;
            this.kissTree.OptionsView.EnableAppearanceEvenRow = true;
            this.kissTree.OptionsView.EnableAppearanceOddRow = true;
            this.kissTree.OptionsView.ShowIndicator = false;
            this.kissTree.OptionsView.ShowVertLines = false;
            this.kissTree.Size = new System.Drawing.Size(320, 272);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.kissTree.DoubleClick += new System.EventHandler(this.kissTree_DoubleClick);
            //
            // colName2
            //
            this.colName2.Caption = "Fallführung";
            this.colName2.FieldName = "Name";
            this.colName2.MinWidth = 27;
            this.colName2.Name = "colName2";
            this.colName2.OptionsColumn.AllowMove = false;
            this.colName2.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colName2.OptionsColumn.AllowSort = false;
            this.colName2.OptionsColumn.ShowInCustomizationForm = false;
            this.colName2.VisibleIndex = 0;
            this.colName2.Width = 200;
            //
            // colAufnahme
            //
            this.colAufnahme.Caption = "ab";
            this.colAufnahme.FieldName = "Aufnahme";
            this.colAufnahme.Name = "colAufnahme";
            this.colAufnahme.OptionsColumn.AllowFocus = false;
            this.colAufnahme.OptionsColumn.AllowMove = false;
            this.colAufnahme.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colAufnahme.OptionsColumn.AllowSort = false;
            this.colAufnahme.OptionsColumn.ShowInCustomizationForm = false;
            this.colAufnahme.VisibleIndex = 1;
            this.colAufnahme.Width = 85;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SARName";
            this.colSAR.Name = "colSAR";
            this.colSAR.OptionsColumn.AllowFocus = false;
            this.colSAR.OptionsColumn.AllowMove = false;
            this.colSAR.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colSAR.OptionsColumn.AllowSize = false;
            this.colSAR.OptionsColumn.AllowSort = false;
            this.colSAR.OptionsColumn.ShowInCustomizationForm = false;
            this.colSAR.VisibleIndex = 2;
            this.colSAR.Width = 200;
            //
            // colFaFallID
            //
            this.colFaFallID.Caption = "FaFallID";
            this.colFaFallID.FieldName = "FaFallID";
            this.colFaFallID.Name = "colFaFallID";
            //
            // colModulID
            //
            this.colModulID.Caption = "Modul";
            this.colModulID.FieldName = "ModulID";
            this.colModulID.Name = "colModulID";
            //
            // colFaPhaseID
            //
            this.colFaPhaseID.Caption = "treeListColumn1";
            this.colFaPhaseID.FieldName = "FaPhaseID";
            this.colFaPhaseID.Name = "colFaPhaseID";
            //
            // colMaskName
            //
            this.colMaskName.Caption = "treeListColumn1";
            this.colMaskName.FieldName = "MaskName";
            this.colMaskName.Name = "colMaskName";
            //
            // btnNewIntake
            //
            this.btnNewIntake.Caption = "Neues Intake";
            this.btnNewIntake.CategoryGuid = new System.Guid("0a686651-24ab-43de-9233-cd9a623b13cc");
            this.btnNewIntake.Id = 0;
            this.btnNewIntake.ImageIndex = 192;
            this.btnNewIntake.Name = "btnNewIntake";
            this.btnNewIntake.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewIntake_ItemClick);
            //
            // btnNewBeratungsphase
            //
            this.btnNewBeratungsphase.Caption = "Neue Beratungsphase";
            this.btnNewBeratungsphase.CategoryGuid = new System.Guid("0a686651-24ab-43de-9233-cd9a623b13cc");
            this.btnNewBeratungsphase.Id = 1;
            this.btnNewBeratungsphase.ImageIndex = 190;
            this.btnNewBeratungsphase.Name = "btnNewBeratungsphase";
            this.btnNewBeratungsphase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewBeratungsphase_ItemClick);
            //
            // panelThemenFilter
            //
            this.panelThemenFilter.Controls.Add(this.editThemenfilter);
            this.panelThemenFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThemenFilter.Location = new System.Drawing.Point(0, 440);
            this.panelThemenFilter.Name = "panelThemenFilter";
            this.panelThemenFilter.Size = new System.Drawing.Size(320, 32);
            this.panelThemenFilter.TabIndex = 5;
            //
            // editThemenfilter
            //
            this.editThemenfilter.EditValue = false;
            this.editThemenfilter.Location = new System.Drawing.Point(5, 6);
            this.editThemenfilter.Name = "editThemenfilter";
            this.editThemenfilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.editThemenfilter.Properties.Appearance.Options.UseBackColor = true;
            this.editThemenfilter.Properties.Caption = "Themenfilter aktiv";
            this.editThemenfilter.Size = new System.Drawing.Size(176, 19);
            this.editThemenfilter.TabIndex = 2;
            this.editThemenfilter.CheckedChanged += new System.EventHandler(this.editThemenfilter_CheckedChanged);
            this.editThemenfilter.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.editThemenfilter_EditValueChanging);
            //
            // panelThemen
            //
            this.panelThemen.AutoScroll = true;
            this.panelThemen.BackColor = System.Drawing.Color.LemonChiffon;
            this.panelThemen.Controls.Add(this.btnKeineThemen);
            this.panelThemen.Controls.Add(this.btnAlleThemen);
            this.panelThemen.Controls.Add(this.kissLabel1);
            this.panelThemen.Controls.Add(this.editThemen);
            this.panelThemen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThemen.Location = new System.Drawing.Point(0, 272);
            this.panelThemen.Name = "panelThemen";
            this.panelThemen.Size = new System.Drawing.Size(320, 168);
            this.panelThemen.TabIndex = 6;
            //
            // btnKeineThemen
            //
            this.btnKeineThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeineThemen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeineThemen.Location = new System.Drawing.Point(224, 5);
            this.btnKeineThemen.Name = "btnKeineThemen";
            this.btnKeineThemen.Size = new System.Drawing.Size(88, 24);
            this.btnKeineThemen.TabIndex = 5;
            this.btnKeineThemen.Text = "ohne Thema";
            this.btnKeineThemen.UseVisualStyleBackColor = false;
            this.btnKeineThemen.Click += new System.EventHandler(this.btnThemen_Click);
            //
            // btnAlleThemen
            //
            this.btnAlleThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleThemen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleThemen.Location = new System.Drawing.Point(168, 5);
            this.btnAlleThemen.Name = "btnAlleThemen";
            this.btnAlleThemen.Size = new System.Drawing.Size(48, 24);
            this.btnAlleThemen.TabIndex = 4;
            this.btnAlleThemen.Text = "alle";
            this.btnAlleThemen.UseVisualStyleBackColor = false;
            this.btnAlleThemen.Click += new System.EventHandler(this.btnThemen_Click);
            //
            // kissLabel1
            //
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel1.Location = new System.Drawing.Point(7, 8);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 16);
            this.kissLabel1.TabIndex = 3;
            this.kissLabel1.Text = "Themenfilter";
            //
            // editThemen
            //
            this.editThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editThemen.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.editThemen.Appearance.Options.UseBackColor = true;
            this.editThemen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.editThemen.CheckOnClick = true;
            this.editThemen.Location = new System.Drawing.Point(5, 35);
            this.editThemen.LOVName = "FaThema";
            this.editThemen.Name = "editThemen";
            this.editThemen.Size = new System.Drawing.Size(310, 130);
            this.editThemen.TabIndex = 2;
            this.editThemen.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.editThemen_ItemCheck);
            //
            // btnDelete
            //
            this.btnDelete.Caption = "Löschen";
            this.btnDelete.Id = 8;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            //
            // colAppCode
            //
            this.colAppCode.Caption = "treeListColumn1";
            this.colAppCode.FieldName = "AppCode";
            this.colAppCode.Name = "colAppCode";
            //
            // CtlFaModulTree
            //
            this.Controls.Add(this.panelThemen);
            this.Controls.Add(this.panelThemenFilter);
            this.Name = "CtlFaModulTree";
            this.Load += new System.EventHandler(this.CtlFaModulTree_Load);
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.panelThemenFilter, 0);
            this.Controls.SetChildIndex(this.panelThemen, 0);
            this.Controls.SetChildIndex(this.kissTree, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            this.panelThemenFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editThemenfilter.Properties)).EndInit();
            this.panelThemen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editThemen)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnAlleThemen;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private KiSS4.Gui.KissButton btnKeineThemen;
        private DevExpress.XtraBars.BarButtonItem btnNewBeratungsphase;
        private DevExpress.XtraBars.BarButtonItem btnNewIntake;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAppCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAufnahme;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFaFallID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFaPhaseID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaskName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModulID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSAR;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCheckedLookupEdit editThemen;
        private KiSS4.Gui.KissCheckEdit editThemenfilter;
        private KiSS4.Gui.KissLabel kissLabel1;
        private System.Windows.Forms.Panel panelThemen;
        private System.Windows.Forms.Panel panelThemenFilter;
    }
}
