namespace KiSS4.Main.ZH
{
    partial class CtlFallNavigator
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
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
            this.treeFallNavigator = new KiSS4.Gui.KissTree();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colZusatz = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTeilleistungserbringer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repItemModulIcon = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.fraStatus = new KiSS4.Gui.KissGroupBox();
            this.editArchivierte = new System.Windows.Forms.CheckBox();
            this.editAbgeschlossene = new System.Windows.Forms.CheckBox();
            this.editAktive = new System.Windows.Forms.CheckBox();
            this.fraRechte = new KiSS4.Gui.KissGroupBox();
            this.editGastrecht = new System.Windows.Forms.CheckBox();
            this.editGruppe = new System.Windows.Forms.CheckBox();
            this.lblAnzahlPersonen = new KiSS4.Gui.KissLabel();
            this.btnFall = new KiSS4.Gui.KissButton();
            this.btnNeuerFall = new KiSS4.Gui.KissButton();
            this.colN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryModul = new KiSS4.DB.SqlQuery(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager_Tree = new DevExpress.XtraBars.BarManager(this.components);
            this.btnFallInfo = new DevExpress.XtraBars.BarButtonItem();
            this.popup_Tree = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeFallNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemModulIcon)).BeginInit();
            this.fraStatus.SuspendLayout();
            this.fraRechte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            this.SuspendLayout();
            // 
            // treeFallNavigator
            // 
            this.treeFallNavigator.AllowSortTree = true;
            this.treeFallNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFallNavigator.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treeFallNavigator.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treeFallNavigator.Appearance.Empty.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.Empty.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treeFallNavigator.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treeFallNavigator.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treeFallNavigator.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treeFallNavigator.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treeFallNavigator.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeFallNavigator.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.FooterPanel.Options.UseFont = true;
            this.treeFallNavigator.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treeFallNavigator.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treeFallNavigator.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.GroupButton.Options.UseFont = true;
            this.treeFallNavigator.Appearance.GroupButton.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treeFallNavigator.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treeFallNavigator.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treeFallNavigator.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeFallNavigator.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treeFallNavigator.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeFallNavigator.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeFallNavigator.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treeFallNavigator.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treeFallNavigator.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.HorzLine.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treeFallNavigator.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeFallNavigator.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.OddRow.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.OddRow.Options.UseFont = true;
            this.treeFallNavigator.Appearance.OddRow.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treeFallNavigator.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeFallNavigator.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treeFallNavigator.Appearance.Preview.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.Preview.Options.UseFont = true;
            this.treeFallNavigator.Appearance.Preview.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treeFallNavigator.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeFallNavigator.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treeFallNavigator.Appearance.Row.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.Row.Options.UseFont = true;
            this.treeFallNavigator.Appearance.Row.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treeFallNavigator.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treeFallNavigator.Appearance.TreeLine.ForeColor = System.Drawing.Color.Gray;
            this.treeFallNavigator.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.TreeLine.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treeFallNavigator.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treeFallNavigator.Appearance.VertLine.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.VertLine.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.VertLine.Options.UseTextOptions = true;
            this.treeFallNavigator.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treeFallNavigator.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colZusatz,
            this.colTeilleistungserbringer});
            this.treeFallNavigator.ImageIndexFieldName = "IconID";
            this.treeFallNavigator.Location = new System.Drawing.Point(8, 8);
            this.treeFallNavigator.Name = "treeFallNavigator";
            this.treeFallNavigator.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeFallNavigator.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeFallNavigator.OptionsBehavior.Editable = false;
            this.treeFallNavigator.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeFallNavigator.OptionsBehavior.MoveOnEdit = false;
            this.treeFallNavigator.OptionsMenu.EnableColumnMenu = false;
            this.treeFallNavigator.OptionsMenu.EnableFooterMenu = false;
            this.treeFallNavigator.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeFallNavigator.OptionsView.AutoWidth = false;
            this.treeFallNavigator.OptionsView.EnableAppearanceEvenRow = true;
            this.treeFallNavigator.OptionsView.EnableAppearanceOddRow = true;
            this.treeFallNavigator.OptionsView.ShowIndicator = false;
            this.treeFallNavigator.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemModulIcon});
            this.treeFallNavigator.Size = new System.Drawing.Size(581, 452);
            this.treeFallNavigator.TabIndex = 0;
            this.treeFallNavigator.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeFallNavigator_CustomDrawNodeCell);
            this.treeFallNavigator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeFallNavigator_KeyDown);
            this.treeFallNavigator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeFallNavigator_MouseUp);
            // 
            // colName
            // 
            this.colName.Caption = "Person";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 27;
            this.colName.Name = "colName";
            this.colName.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 223;
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.FieldName = "Zusatz";
            this.colZusatz.Name = "colZusatz";
            // 
            // colTeilleistungserbringer
            // 
            this.colTeilleistungserbringer.Caption = "nur aktive Teilleistungserbringer";
            this.colTeilleistungserbringer.FieldName = "Teilleistungserbringer";
            this.colTeilleistungserbringer.Name = "colTeilleistungserbringer";
            this.colTeilleistungserbringer.Width = 250;
            // 
            // repItemModulIcon
            // 
            this.repItemModulIcon.AutoComplete = false;
            this.repItemModulIcon.AutoHeight = false;
            this.repItemModulIcon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemModulIcon.Name = "repItemModulIcon";
            this.repItemModulIcon.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // fraStatus
            // 
            this.fraStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fraStatus.Controls.Add(this.editArchivierte);
            this.fraStatus.Controls.Add(this.editAbgeschlossene);
            this.fraStatus.Controls.Add(this.editAktive);
            this.fraStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraStatus.Location = new System.Drawing.Point(8, 468);
            this.fraStatus.Name = "fraStatus";
            this.fraStatus.Size = new System.Drawing.Size(247, 40);
            this.fraStatus.TabIndex = 1;
            this.fraStatus.TabStop = false;
            this.fraStatus.UseCompatibleTextRendering = true;
            // 
            // editArchivierte
            // 
            this.editArchivierte.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivierte.Location = new System.Drawing.Point(172, 12);
            this.editArchivierte.Name = "editArchivierte";
            this.editArchivierte.Size = new System.Drawing.Size(72, 24);
            this.editArchivierte.TabIndex = 2;
            this.editArchivierte.Text = "archiviert";
            this.editArchivierte.UseCompatibleTextRendering = true;
            this.editArchivierte.Click += new System.EventHandler(this.editCheckbox_Click);
            // 
            // editAbgeschlossene
            // 
            this.editAbgeschlossene.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editAbgeschlossene.Location = new System.Drawing.Point(65, 12);
            this.editAbgeschlossene.Name = "editAbgeschlossene";
            this.editAbgeschlossene.Size = new System.Drawing.Size(100, 24);
            this.editAbgeschlossene.TabIndex = 1;
            this.editAbgeschlossene.Text = "abgeschlossen";
            this.editAbgeschlossene.UseCompatibleTextRendering = true;
            this.editAbgeschlossene.Click += new System.EventHandler(this.editCheckbox_Click);
            // 
            // editAktive
            // 
            this.editAktive.Checked = true;
            this.editAktive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.editAktive.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editAktive.Location = new System.Drawing.Point(10, 12);
            this.editAktive.Name = "editAktive";
            this.editAktive.Size = new System.Drawing.Size(52, 24);
            this.editAktive.TabIndex = 0;
            this.editAktive.Text = "aktiv";
            this.editAktive.UseCompatibleTextRendering = true;
            this.editAktive.Click += new System.EventHandler(this.editCheckbox_Click);
            // 
            // fraRechte
            // 
            this.fraRechte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fraRechte.Controls.Add(this.editGastrecht);
            this.fraRechte.Controls.Add(this.editGruppe);
            this.fraRechte.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraRechte.Location = new System.Drawing.Point(260, 468);
            this.fraRechte.Name = "fraRechte";
            this.fraRechte.Size = new System.Drawing.Size(181, 40);
            this.fraRechte.TabIndex = 2;
            this.fraRechte.TabStop = false;
            this.fraRechte.UseCompatibleTextRendering = true;
            // 
            // editGastrecht
            // 
            this.editGastrecht.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editGastrecht.Location = new System.Drawing.Point(97, 12);
            this.editGastrecht.Name = "editGastrecht";
            this.editGastrecht.Size = new System.Drawing.Size(72, 24);
            this.editGastrecht.TabIndex = 1;
            this.editGastrecht.Text = "Gastrecht";
            this.editGastrecht.UseCompatibleTextRendering = true;
            this.editGastrecht.Click += new System.EventHandler(this.editCheckbox_Click);
            // 
            // editGruppe
            // 
            this.editGruppe.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editGruppe.Location = new System.Drawing.Point(10, 12);
            this.editGruppe.Name = "editGruppe";
            this.editGruppe.Size = new System.Drawing.Size(83, 24);
            this.editGruppe.TabIndex = 0;
            this.editGruppe.Text = "Org. Einheit";
            this.editGruppe.UseCompatibleTextRendering = true;
            this.editGruppe.Click += new System.EventHandler(this.editCheckbox_Click);
            // 
            // lblAnzahlPersonen
            // 
            this.lblAnzahlPersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlPersonen.Location = new System.Drawing.Point(10, 514);
            this.lblAnzahlPersonen.Name = "lblAnzahlPersonen";
            this.lblAnzahlPersonen.Size = new System.Drawing.Size(246, 24);
            this.lblAnzahlPersonen.TabIndex = 7;
            this.lblAnzahlPersonen.Text = "";
            this.lblAnzahlPersonen.UseCompatibleTextRendering = true;
            // 
            // btnFall
            // 
            this.btnFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFall.Location = new System.Drawing.Point(387, 514);
            this.btnFall.Name = "btnFall";
            this.btnFall.Size = new System.Drawing.Size(98, 24);
            this.btnFall.TabIndex = 8;
            this.btnFall.Text = ">Fall";
            this.btnFall.UseCompatibleTextRendering = true;
            this.btnFall.UseVisualStyleBackColor = false;
            this.btnFall.Click += new System.EventHandler(this.btnFall_Click);
            // 
            // btnNeuerFall
            // 
            this.btnNeuerFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuerFall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuerFall.Location = new System.Drawing.Point(491, 514);
            this.btnNeuerFall.Name = "btnNeuerFall";
            this.btnNeuerFall.Size = new System.Drawing.Size(98, 24);
            this.btnNeuerFall.TabIndex = 9;
            this.btnNeuerFall.Text = "neuer Fall...";
            this.btnNeuerFall.UseCompatibleTextRendering = true;
            this.btnNeuerFall.UseVisualStyleBackColor = false;
            this.btnNeuerFall.Click += new System.EventHandler(this.btnNeuerFall_Click);
            // 
            // colN
            // 
            this.colN.Caption = "N";
            this.colN.FieldName = "N";
            this.colN.Name = "colN";
            this.colN.VisibleIndex = 7;
            this.colN.Width = 24;
            // 
            // qryModul
            // 
            this.qryModul.HostControl = this;
            // 
            // barManager_Tree
            // 
            this.barManager_Tree.DockControls.Add(this.barDockControlTop);
            this.barManager_Tree.DockControls.Add(this.barDockControlBottom);
            this.barManager_Tree.DockControls.Add(this.barDockControlLeft);
            this.barManager_Tree.DockControls.Add(this.barDockControlRight);
            this.barManager_Tree.Form = this;
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnFallInfo});
            this.barManager_Tree.MaxItemId = 2;
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            // 
            // btnFallInfo
            // 
            this.btnFallInfo.Caption = "Fallzuteilung";
            this.btnFallInfo.Id = 1;
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallInfo_ItemClick);
            // 
            // popup_Tree
            // 
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo)});
            this.popup_Tree.Manager = this.barManager_Tree;
            this.popup_Tree.Name = "popup_Tree";
            // 
            // CtlFallNavigator
            // 
            this.Controls.Add(this.btnNeuerFall);
            this.Controls.Add(this.btnFall);
            this.Controls.Add(this.lblAnzahlPersonen);
            this.Controls.Add(this.fraRechte);
            this.Controls.Add(this.fraStatus);
            this.Controls.Add(this.treeFallNavigator);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CtlFallNavigator";
            this.Size = new System.Drawing.Size(599, 547);
            this.RefreshData += new System.EventHandler(this.CtlFallNavigator_RefreshData);
            this.Load += new System.EventHandler(this.CtlFallNavigator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeFallNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemModulIcon)).EndInit();
            this.fraStatus.ResumeLayout(false);
            this.fraRechte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraBars.BarManager barManager_Tree;
        protected DevExpress.XtraBars.PopupMenu popup_Tree;
        private KiSS4.Gui.KissButton btnFall;
        private DevExpress.XtraBars.BarButtonItem btnFallInfo;
        private KiSS4.Gui.KissButton btnNeuerFall;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colZusatz;
        private System.Windows.Forms.CheckBox editAbgeschlossene;
        private System.Windows.Forms.CheckBox editAktive;
        private System.Windows.Forms.CheckBox editArchivierte;
        private System.Windows.Forms.CheckBox editGastrecht;
        private System.Windows.Forms.CheckBox editGruppe;
        private KiSS4.Gui.KissGroupBox fraRechte;
        private KiSS4.Gui.KissGroupBox fraStatus;
        private KiSS4.Gui.KissLabel lblAnzahlPersonen;
        private KiSS4.DB.SqlQuery qryModul;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repItemModulIcon;
        private KiSS4.Gui.KissTree treeFallNavigator;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTeilleistungserbringer;
    }
}
