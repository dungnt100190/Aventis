namespace KiSS4.Vormundschaft
{
    partial class CtlVmModulTree
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colZusatz = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnNewMassnahme = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewVaterschaftsabklaerung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewErbschaft = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewPflegekind = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueSiegelung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuesTestament = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuerErbschaftsdienst = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewAuftrag = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            this.SuspendLayout();
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
            this.colName,
            this.colZusatz});
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
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewMassnahme),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewVaterschaftsabklaerung),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewErbschaft),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewPflegekind),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewAuftrag),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNeueSiegelung, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuerErbschaftsdienst),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuesTestament),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo)});
            //
            // barManager_Tree
            //
            this.barManager_Tree.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Popup", new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51"))});
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNewMassnahme,
            this.btnNewVaterschaftsabklaerung,
            this.btnNewErbschaft,
            this.btnNewPflegekind,
            this.btnNeueSiegelung,
            this.btnNeuesTestament,
            this.btnNeuerErbschaftsdienst,
            this.btnDelete,
            this.btnNewAuftrag});
            this.barManager_Tree.MaxItemId = 14;
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnFallZugriff.Id = 4;
            //
            // btnFallInfo
            //
            this.btnFallInfo.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnFallInfo.Id = 5;
            //
            // colName
            //
            this.colName.Caption = "Vormundschaft";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 27;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.OptionsColumn.ShowInCustomizationForm = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 200;
            //
            // colZusatz
            //
            this.colZusatz.FieldName = "Zusatz";
            this.colZusatz.Name = "colZusatz";
            this.colZusatz.OptionsColumn.AllowFocus = false;
            this.colZusatz.OptionsColumn.AllowMove = false;
            this.colZusatz.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colZusatz.OptionsColumn.AllowSort = false;
            this.colZusatz.OptionsColumn.ShowInCustomizationForm = false;
            this.colZusatz.VisibleIndex = 1;
            this.colZusatz.Width = 200;
            //
            // btnNewMassnahme
            //
            this.btnNewMassnahme.Caption = "neue vormundschaftliche Massnahme";
            this.btnNewMassnahme.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnNewMassnahme.Id = 0;
            this.btnNewMassnahme.ImageIndex = 1501;
            this.btnNewMassnahme.Name = "btnNewMassnahme";
            this.btnNewMassnahme.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewVaterschaftsabklaerung
            //
            this.btnNewVaterschaftsabklaerung.Caption = "neue Vaterschaftsabklärung";
            this.btnNewVaterschaftsabklaerung.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnNewVaterschaftsabklaerung.Id = 1;
            this.btnNewVaterschaftsabklaerung.ImageIndex = 1501;
            this.btnNewVaterschaftsabklaerung.Name = "btnNewVaterschaftsabklaerung";
            this.btnNewVaterschaftsabklaerung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewErbschaft
            //
            this.btnNewErbschaft.Caption = "neue Erbschaft";
            this.btnNewErbschaft.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnNewErbschaft.Id = 2;
            this.btnNewErbschaft.ImageIndex = 1501;
            this.btnNewErbschaft.Name = "btnNewErbschaft";
            this.btnNewErbschaft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewPflegekind
            //
            this.btnNewPflegekind.Caption = "neue Pflegekinderaufsicht";
            this.btnNewPflegekind.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnNewPflegekind.Id = 3;
            this.btnNewPflegekind.ImageIndex = 1501;
            this.btnNewPflegekind.Name = "btnNewPflegekind";
            this.btnNewPflegekind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNeueSiegelung
            //
            this.btnNeueSiegelung.Caption = "Neuer Siegelungsdienst";
            this.btnNeueSiegelung.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnNeueSiegelung.Id = 7;
            this.btnNeueSiegelung.ImageIndex = 193;
            this.btnNeueSiegelung.Name = "btnNeueSiegelung";
            this.btnNeueSiegelung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew2_ItemClick);
            //
            // btnNeuesTestament
            //
            this.btnNeuesTestament.Caption = "Neuer Testamentsdienst";
            this.btnNeuesTestament.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnNeuesTestament.Id = 8;
            this.btnNeuesTestament.ImageIndex = 19;
            this.btnNeuesTestament.Name = "btnNeuesTestament";
            this.btnNeuesTestament.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew2_ItemClick);
            //
            // btnNeuerErbschaftsdienst
            //
            this.btnNeuerErbschaftsdienst.Caption = "Neuer Erbschaftsdienst";
            this.btnNeuerErbschaftsdienst.CategoryGuid = new System.Guid("d86d14a6-20dc-414e-9e06-6020bcc9ff51");
            this.btnNeuerErbschaftsdienst.Id = 11;
            this.btnNeuerErbschaftsdienst.ImageIndex = 172;
            this.btnNeuerErbschaftsdienst.Name = "btnNeuerErbschaftsdienst";
            this.btnNeuerErbschaftsdienst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew2_ItemClick);
            //
            // btnDelete
            //
            this.btnDelete.Caption = "Löschen";
            this.btnDelete.Id = 12;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            //
            // btnNewAuftrag
            //
            this.btnNewAuftrag.Caption = "neuer vormundschaftlicher Auftrag";
            this.btnNewAuftrag.Id = 13;
            this.btnNewAuftrag.ImageIndex = 1501;
            this.btnNewAuftrag.Name = "btnNewAuftrag";
            this.btnNewAuftrag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // CtlVmModulTree
            //
            this.Name = "CtlVmModulTree";
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnNeueSiegelung;
        private DevExpress.XtraBars.BarButtonItem btnNeuerErbschaftsdienst;
        private DevExpress.XtraBars.BarButtonItem btnNeuesTestament;
        private DevExpress.XtraBars.BarButtonItem btnNewAuftrag;
        private DevExpress.XtraBars.BarButtonItem btnNewErbschaft;
        private DevExpress.XtraBars.BarButtonItem btnNewMassnahme;
        private DevExpress.XtraBars.BarButtonItem btnNewPflegekind;
        private DevExpress.XtraBars.BarButtonItem btnNewVaterschaftsabklaerung;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colZusatz;
    }
}
