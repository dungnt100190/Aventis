namespace KiSS4.Basis.ZH
{
    partial class CtlBaModulTree
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaModulTree));
            this.pnlTreeOptions = new System.Windows.Forms.Panel();
            this.edtShowInactivePersons = new KiSS4.Gui.KissCheckEdit();
            this.btnFallZuteilung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuePerson = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueBerechnungsperson = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonEntfernen = new DevExpress.XtraBars.BarButtonItem();
            this.colAge = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHinweis = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            this.pnlTreeOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowInactivePersons.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // kissTree
            //
            this.kissTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Empty.ForeColor = System.Drawing.Color.White;
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
            this.kissTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.kissTree.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.kissTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
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
            this.kissTree.Appearance.TreeLine.ForeColor = System.Drawing.Color.Gray;
            this.kissTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.kissTree.Appearance.TreeLine.Options.UseForeColor = true;
            this.kissTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.kissTree.Appearance.VertLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.Options.UseForeColor = true;
            this.kissTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.kissTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.kissTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
                        this.colName,
                        this.colHinweis,
                        this.colAge});
            this.kissTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.kissTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.kissTree.OptionsBehavior.Editable = false;
            this.kissTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.kissTree.OptionsBehavior.MoveOnEdit = false;
            this.kissTree.OptionsBehavior.PopulateServiceColumns = true;
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
            this.kissTree.Size = new System.Drawing.Size(265, 422);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.kissTree.TabIndex = 1;
            //
            // qryModulTree
            //
            this.qryModulTree.SelectStatement = "EXECUTE dbo.spXGetModulTree {0}, {1}, {2}, {3}";
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                        this.btnNeuePerson,
                        this.btnNeueBerechnungsperson,
                        this.btnPersonEntfernen,
                        this.btnFallZuteilung});
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // btnFallInfo
            //
            this.btnFallInfo.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // pnlTreeOptions
            //
            this.pnlTreeOptions.Controls.Add(this.edtShowInactivePersons);
            this.pnlTreeOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTreeOptions.Location = new System.Drawing.Point(0, 422);
            this.pnlTreeOptions.Name = "pnlTreeOptions";
            this.pnlTreeOptions.Size = new System.Drawing.Size(265, 30);
            this.pnlTreeOptions.TabIndex = 0;
            //
            // edtShowInactivePersons
            //
            this.edtShowInactivePersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtShowInactivePersons.EditValue = false;
            this.edtShowInactivePersons.Location = new System.Drawing.Point(3, 6);
            this.edtShowInactivePersons.Name = "edtShowInactivePersons";
            this.edtShowInactivePersons.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtShowInactivePersons.Properties.Appearance.Options.UseBackColor = true;
            this.edtShowInactivePersons.Properties.Caption = "Inaktive Personen anzeigen";
            this.edtShowInactivePersons.Size = new System.Drawing.Size(259, 19);
            this.edtShowInactivePersons.TabIndex = 0;
            this.edtShowInactivePersons.EditValueChanged += new System.EventHandler(this.edtShowInactivePersons_EditValueChanged);
            //
            // btnFallZuteilung
            //
            this.btnFallZuteilung.Caption = "Fallzuteilung";
            this.btnFallZuteilung.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFallZuteilung.Glyph")));
            this.btnFallZuteilung.Id = 3;
            this.btnFallZuteilung.ImageIndex = 212;
            this.btnFallZuteilung.Name = "btnFallZuteilung";
            this.btnFallZuteilung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallZuteilung_ItemClick);
            //
            // btnNeuePerson
            //
            this.btnNeuePerson.Caption = "Neue Person ...";
            this.btnNeuePerson.Id = 3;
            this.btnNeuePerson.ImageIndex = 1;
            this.btnNeuePerson.Name = "btnNeuePerson";
            this.btnNeuePerson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuePerson_ItemClick);
            //
            // btnNeueBerechnungsperson
            //
            this.btnNeueBerechnungsperson.Caption = "Neue Berechnungsperson ...";
            this.btnNeueBerechnungsperson.Id = 4;
            this.btnNeueBerechnungsperson.ImageIndex = 1;
            this.btnNeueBerechnungsperson.Name = "btnNeueBerechnungsperson";
            this.btnNeueBerechnungsperson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueBerechnungsperson_ItemClick);
            //
            // btnPersonEntfernen
            //
            this.btnPersonEntfernen.Caption = "Person entfernen";
            this.btnPersonEntfernen.Id = 5;
            this.btnPersonEntfernen.ImageIndex = 4;
            this.btnPersonEntfernen.Name = "btnPersonEntfernen";
            this.btnPersonEntfernen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonEntfernen_ItemClick);
            //
            // colAge
            //
            this.colAge.AppearanceCell.Options.UseTextOptions = true;
            this.colAge.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAge.Caption = "Alter";
            this.colAge.FieldName = "AgeDisplay";
            this.colAge.Name = "colAge";
            this.colAge.OptionsColumn.AllowSort = false;
            this.colAge.VisibleIndex = 2;
            this.colAge.Width = 38;
            //
            // colHinweis
            //
            this.colHinweis.AppearanceCell.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.colHinweis.AppearanceCell.Options.UseFont = true;
            this.colHinweis.FieldName = "Hinweis";
            this.colHinweis.Name = "colHinweis";
            this.colHinweis.OptionsColumn.AllowSort = false;
            this.colHinweis.VisibleIndex = 1;
            this.colHinweis.Width = 20;
            //
            // colName
            //
            this.colName.Caption = "Basis";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 180;
            //
            // CtlBaModulTree
            //
            this.Controls.Add(this.pnlTreeOptions);
            this.Name = "CtlBaModulTree";
            this.Size = new System.Drawing.Size(265, 452);
            this.Load += new System.EventHandler(this.CtlBaModulTree_Load);
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.pnlTreeOptions, 0);
            this.Controls.SetChildIndex(this.kissTree, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            this.pnlTreeOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtShowInactivePersons.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnFallZuteilung;
        private DevExpress.XtraBars.BarButtonItem btnNeuePerson;
        private DevExpress.XtraBars.BarButtonItem btnNeueBerechnungsperson;
        private DevExpress.XtraBars.BarButtonItem btnPersonEntfernen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAge;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHinweis;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private KiSS4.Gui.KissCheckEdit edtShowInactivePersons;
        private System.Windows.Forms.Panel pnlTreeOptions;
    }
}