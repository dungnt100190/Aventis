namespace KiSS4.Common
{
    partial class KissModulTree
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kissTree = new KiSS4.Gui.KissTree();
            this.qryModulTree = new KiSS4.DB.SqlQuery();
            this.barManager_Tree = new DevExpress.XtraBars.BarManager();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.btnFallZugriff = new DevExpress.XtraBars.BarButtonItem();
            this.btnFallInfo = new DevExpress.XtraBars.BarButtonItem();
            this.popup_Tree = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            this.SuspendLayout();
            // 
            // kissTree
            // 
            this.kissTree.AllowSortTree = true;
            this.kissTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kissTree.Appearance.Empty.Options.UseBackColor = true;
            this.kissTree.Appearance.Empty.Options.UseForeColor = true;
            this.kissTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.kissTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
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
            this.kissTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.kissTree.Appearance.FooterPanel.Options.UseFont = true;
            this.kissTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupButton.Options.UseFont = true;
            this.kissTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.kissTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.kissTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.kissTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
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
            this.kissTree.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
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
            this.kissTree.Appearance.Row.ForeColor = System.Drawing.Color.Black;
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
            this.kissTree.DataSource = this.qryModulTree;
            this.kissTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissTree.ImageIndexFieldName = "IconID";
            this.kissTree.Location = new System.Drawing.Point(0, 0);
            this.kissTree.MenuManager = this.barManager_Tree;
            this.kissTree.Name = "kissTree";
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
            this.kissTree.Size = new System.Drawing.Size(320, 472);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
                    | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.kissTree.TabIndex = 0;
            // 
            // qryModulTree
            // 
            this.qryModulTree.HostControl = this;
            this.qryModulTree.AfterFill += new System.EventHandler(this.sqlQueryTree_AfterFill);
            // 
            // barManager_Tree
            // 
            this.barManager_Tree.AllowCustomization = false;
            this.barManager_Tree.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("FaLeistung", new System.Guid("0a8d08e9-ac7f-4ac4-8064-9b992c8ffbc2"))});
            this.barManager_Tree.DockControls.Add(this.barDockControl1);
            this.barManager_Tree.DockControls.Add(this.barDockControl2);
            this.barManager_Tree.DockControls.Add(this.barDockControl3);
            this.barManager_Tree.DockControls.Add(this.barDockControl4);
            this.barManager_Tree.Form = this;
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnFallZugriff,
            this.btnFallInfo});
            this.barManager_Tree.MaxItemId = 3;
            // 
            // btnFallZugriff
            // 
            this.btnFallZugriff.Caption = "Fallzugriff";
            this.btnFallZugriff.CategoryGuid = new System.Guid("0a8d08e9-ac7f-4ac4-8064-9b992c8ffbc2");
            this.btnFallZugriff.Id = 1;
            this.btnFallZugriff.ImageIndex = 5016;
            this.btnFallZugriff.Name = "btnFallZugriff";
            this.btnFallZugriff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallZugriff_ItemClick);
            // 
            // btnFallInfo
            // 
            this.btnFallInfo.Caption = "Fallinfo";
            this.btnFallInfo.CategoryGuid = new System.Guid("0a8d08e9-ac7f-4ac4-8064-9b992c8ffbc2");
            this.btnFallInfo.Id = 2;
            this.btnFallInfo.ImageIndex = 176;
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallInfo_ItemClick);
            // 
            // popup_Tree
            // 
            this.popup_Tree.Manager = this.barManager_Tree;
            this.popup_Tree.Name = "popup_Tree";
            // 
            // KissModulTree
            // 
            this.ActiveSQLQuery = this.qryModulTree;
            this.Controls.Add(this.kissTree);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "KissModulTree";
            this.Size = new System.Drawing.Size(320, 472);
            this.Load += new System.EventHandler(this.KissModulTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraBars.BarDockControl barDockControl1;
        protected DevExpress.XtraBars.BarDockControl barDockControl2;
        protected DevExpress.XtraBars.BarDockControl barDockControl3;
        protected DevExpress.XtraBars.BarDockControl barDockControl4;
        protected DevExpress.XtraBars.BarManager barManager_Tree;
        protected DevExpress.XtraBars.BarButtonItem btnFallInfo;
        protected DevExpress.XtraBars.BarButtonItem btnFallZugriff;
        protected DevExpress.XtraBars.PopupMenu popup_Tree;
        protected KiSS4.DB.SqlQuery qryModulTree;
        protected KiSS4.Gui.KissTree kissTree;
        private System.ComponentModel.IContainer components = null;
    }
}
