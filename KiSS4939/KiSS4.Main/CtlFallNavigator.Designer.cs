namespace KiSS4.Main
{
    partial class CtlFallNavigator
    {
        #region Dispose

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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.treeFallNavigator = new KiSS4.Gui.KissTree();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAHVNummer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNNummer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colZusatz = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colGemeinde = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colVersNr = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKategorie = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colFarbe = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPendenzen = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.barManager_Tree = new DevExpress.XtraBars.BarManager(this.components);
            this.btnFallInfo = new DevExpress.XtraBars.BarButtonItem();
            this.repItemModulIcon = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.fraStatus = new KiSS4.Gui.KissGroupBox();
            this.edtArchivierte = new System.Windows.Forms.CheckBox();
            this.edtAbgeschlossene = new System.Windows.Forms.CheckBox();
            this.edtAktive = new System.Windows.Forms.CheckBox();
            this.fraRechte = new KiSS4.Gui.KissGroupBox();
            this.edtGastrecht = new System.Windows.Forms.CheckBox();
            this.edtGruppe = new System.Windows.Forms.CheckBox();
            this.edtAHVNummer = new System.Windows.Forms.CheckBox();
            this.edtNNummer = new System.Windows.Forms.CheckBox();
            this.edtZusatz = new System.Windows.Forms.CheckBox();
            this.edtGemeinde = new System.Windows.Forms.CheckBox();
            this.lblAnzahlPersonen = new KiSS4.Gui.KissLabel();
            this.btnFall = new KiSS4.Gui.KissButton();
            this.btnNeuerFall = new KiSS4.Gui.KissButton();
            this.popup_Tree = new DevExpress.XtraBars.PopupMenu(this.components);
            this.qryModul = new KiSS4.DB.SqlQuery(this.components);
            this.edtVersNr = new System.Windows.Forms.CheckBox();
            this.edtKategorie = new System.Windows.Forms.CheckBox();
            this.edtPendenzen = new System.Windows.Forms.CheckBox();
            this.lblAnzahlPendenzen = new KiSS4.Gui.KissLabel();
            this.btnGotoPendenzen = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.treeFallNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemModulIcon)).BeginInit();
            this.fraStatus.SuspendLayout();
            this.fraRechte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPendenzen)).BeginInit();
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
            this.treeFallNavigator.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
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
            this.treeFallNavigator.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
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
            this.treeFallNavigator.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treeFallNavigator.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treeFallNavigator.Appearance.VertLine.Options.UseBackColor = true;
            this.treeFallNavigator.Appearance.VertLine.Options.UseForeColor = true;
            this.treeFallNavigator.Appearance.VertLine.Options.UseTextOptions = true;
            this.treeFallNavigator.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treeFallNavigator.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colAHVNummer,
            this.colNNummer,
            this.colZusatz,
            this.colGemeinde,
            this.colVersNr,
            this.colKategorie,
            this.colFarbe,
            this.colPendenzen});
            this.treeFallNavigator.ImageIndexFieldName = "IconID";
            this.treeFallNavigator.Location = new System.Drawing.Point(8, 7);
            this.treeFallNavigator.MenuManager = this.barManager_Tree;
            this.treeFallNavigator.Name = "treeFallNavigator";
            this.treeFallNavigator.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeFallNavigator.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeFallNavigator.OptionsBehavior.Editable = false;
            this.treeFallNavigator.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeFallNavigator.OptionsBehavior.MoveOnEdit = false;
            this.treeFallNavigator.OptionsBehavior.ShowToolTips = false;
            this.treeFallNavigator.OptionsBehavior.SmartMouseHover = false;
            this.treeFallNavigator.OptionsMenu.EnableColumnMenu = false;
            this.treeFallNavigator.OptionsMenu.EnableFooterMenu = false;
            this.treeFallNavigator.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeFallNavigator.OptionsView.AutoWidth = false;
            this.treeFallNavigator.OptionsView.EnableAppearanceEvenRow = true;
            this.treeFallNavigator.OptionsView.EnableAppearanceOddRow = true;
            this.treeFallNavigator.OptionsView.ShowIndicator = false;
            this.treeFallNavigator.OptionsView.ShowVertLines = false;
            this.treeFallNavigator.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemModulIcon,
            this.repositoryItemTextEdit1});
            this.treeFallNavigator.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor;
            this.treeFallNavigator.Size = new System.Drawing.Size(793, 348);
            this.treeFallNavigator.TabIndex = 0;
            this.treeFallNavigator.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeFallNavigator_CustomDrawNodeCell);
            this.treeFallNavigator.DoubleClick += new System.EventHandler(this.treeFallNavigator_DoubleClick);
            this.treeFallNavigator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeFallNavigator_KeyDown);
            this.treeFallNavigator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeFallNavigator_MouseMove);
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
            this.colName.Width = 240;
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Caption = "AHV-Nr.";
            this.colAHVNummer.FieldName = "AHVNummer";
            this.colAHVNummer.Name = "colAHVNummer";
            this.colAHVNummer.Width = 100;
            // 
            // colNNummer
            // 
            this.colNNummer.Caption = "N-Nr.";
            this.colNNummer.FieldName = "NNummer";
            this.colNNummer.Name = "colNNummer";
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.FieldName = "NavigatorZusatz";
            this.colZusatz.Name = "colZusatz";
            // 
            // colGemeinde
            // 
            this.colGemeinde.Caption = "Gemeinde";
            this.colGemeinde.FieldName = "Gemeinde";
            this.colGemeinde.Name = "colGemeinde";
            // 
            // colVersNr
            // 
            this.colVersNr.Caption = "Vers.-Nr.";
            this.colVersNr.FieldName = "Versichertennummer";
            this.colVersNr.Name = "colVersNr";
            this.colVersNr.Width = 100;
            // 
            // colKategorie
            // 
            this.colKategorie.AppearanceCell.Options.UseTextOptions = true;
            this.colKategorie.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKategorie.Caption = "Kategorie";
            this.colKategorie.ColumnEdit = this.repositoryItemTextEdit1;
            this.colKategorie.FieldName = "Kategorie";
            this.colKategorie.Name = "colKategorie";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // colFarbe
            // 
            this.colFarbe.FieldName = "Farbe";
            this.colFarbe.Name = "colFarbe";
            // 
            // colPendenzen
            // 
            this.colPendenzen.AppearanceCell.Options.UseTextOptions = true;
            this.colPendenzen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPendenzen.Caption = "fäll. Pendenzen";
            this.colPendenzen.FieldName = "FallTaskCount";
            this.colPendenzen.Name = "colPendenzen";
            this.colPendenzen.VisibleIndex = 1;
            this.colPendenzen.Width = 100;
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
            this.btnFallInfo.Caption = "Fallinfo";
            this.btnFallInfo.Id = 1;
            this.btnFallInfo.ImageIndex = 77;
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallInfo_ItemClick);
            // 
            // repItemModulIcon
            // 
            this.repItemModulIcon.AutoComplete = false;
            this.repItemModulIcon.AutoHeight = false;
            this.repItemModulIcon.Name = "repItemModulIcon";
            // 
            // fraStatus
            // 
            this.fraStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fraStatus.Controls.Add(this.edtArchivierte);
            this.fraStatus.Controls.Add(this.edtAbgeschlossene);
            this.fraStatus.Controls.Add(this.edtAktive);
            this.fraStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraStatus.Location = new System.Drawing.Point(8, 355);
            this.fraStatus.Name = "fraStatus";
            this.fraStatus.Size = new System.Drawing.Size(247, 40);
            this.fraStatus.TabIndex = 1;
            this.fraStatus.TabStop = false;
            // 
            // edtArchivierte
            // 
            this.edtArchivierte.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtArchivierte.Location = new System.Drawing.Point(172, 12);
            this.edtArchivierte.Name = "edtArchivierte";
            this.edtArchivierte.Size = new System.Drawing.Size(72, 24);
            this.edtArchivierte.TabIndex = 2;
            this.edtArchivierte.Text = "archiviert";
            this.edtArchivierte.Click += new System.EventHandler(this.edtCheckbox_Click);
            // 
            // edtAbgeschlossene
            // 
            this.edtAbgeschlossene.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbgeschlossene.Location = new System.Drawing.Point(65, 12);
            this.edtAbgeschlossene.Name = "edtAbgeschlossene";
            this.edtAbgeschlossene.Size = new System.Drawing.Size(100, 24);
            this.edtAbgeschlossene.TabIndex = 1;
            this.edtAbgeschlossene.Text = "abgeschlossen";
            this.edtAbgeschlossene.Click += new System.EventHandler(this.edtCheckbox_Click);
            // 
            // edtAktive
            // 
            this.edtAktive.Checked = true;
            this.edtAktive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.edtAktive.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAktive.Location = new System.Drawing.Point(10, 12);
            this.edtAktive.Name = "edtAktive";
            this.edtAktive.Size = new System.Drawing.Size(52, 24);
            this.edtAktive.TabIndex = 0;
            this.edtAktive.Text = "aktiv";
            this.edtAktive.Click += new System.EventHandler(this.edtCheckbox_Click);
            // 
            // fraRechte
            // 
            this.fraRechte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fraRechte.Controls.Add(this.edtGastrecht);
            this.fraRechte.Controls.Add(this.edtGruppe);
            this.fraRechte.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraRechte.Location = new System.Drawing.Point(260, 355);
            this.fraRechte.Name = "fraRechte";
            this.fraRechte.Size = new System.Drawing.Size(152, 40);
            this.fraRechte.TabIndex = 2;
            this.fraRechte.TabStop = false;
            // 
            // edtGastrecht
            // 
            this.edtGastrecht.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.edtGastrecht.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGastrecht.Location = new System.Drawing.Point(77, 12);
            this.edtGastrecht.Name = "edtGastrecht";
            this.edtGastrecht.Size = new System.Drawing.Size(72, 24);
            this.edtGastrecht.TabIndex = 1;
            this.edtGastrecht.Text = "Gastrecht";
            this.edtGastrecht.Click += new System.EventHandler(this.edtCheckbox_Click);
            // 
            // edtGruppe
            // 
            this.edtGruppe.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGruppe.Location = new System.Drawing.Point(10, 12);
            this.edtGruppe.Name = "edtGruppe";
            this.edtGruppe.Size = new System.Drawing.Size(66, 24);
            this.edtGruppe.TabIndex = 0;
            this.edtGruppe.Text = "Gruppe";
            this.edtGruppe.Click += new System.EventHandler(this.edtCheckbox_Click);
            // 
            // edtAHVNummer
            // 
            this.edtAHVNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAHVNummer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Location = new System.Drawing.Point(424, 356);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Size = new System.Drawing.Size(85, 24);
            this.edtAHVNummer.TabIndex = 3;
            this.edtAHVNummer.Text = "AHV-Nr.";
            this.edtAHVNummer.CheckedChanged += new System.EventHandler(this.edtAHVNummer_CheckedChanged);
            // 
            // edtNNummer
            // 
            this.edtNNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNNummer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNummer.Location = new System.Drawing.Point(424, 376);
            this.edtNNummer.Name = "edtNNummer";
            this.edtNNummer.Size = new System.Drawing.Size(85, 24);
            this.edtNNummer.TabIndex = 4;
            this.edtNNummer.Text = "N-Nr.";
            this.edtNNummer.CheckedChanged += new System.EventHandler(this.edtNNummer_CheckedChanged);
            // 
            // edtZusatz
            // 
            this.edtZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZusatz.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatz.Location = new System.Drawing.Point(512, 356);
            this.edtZusatz.Name = "edtZusatz";
            this.edtZusatz.Size = new System.Drawing.Size(89, 24);
            this.edtZusatz.TabIndex = 6;
            this.edtZusatz.Text = "Zusatz";
            this.edtZusatz.CheckedChanged += new System.EventHandler(this.edtZusatz_CheckedChanged);
            // 
            // edtGemeinde
            // 
            this.edtGemeinde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGemeinde.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeinde.Location = new System.Drawing.Point(512, 376);
            this.edtGemeinde.Name = "edtGemeinde";
            this.edtGemeinde.Size = new System.Drawing.Size(89, 24);
            this.edtGemeinde.TabIndex = 7;
            this.edtGemeinde.Text = "Gemeinde";
            this.edtGemeinde.CheckedChanged += new System.EventHandler(this.edtGemeinde_CheckedChanged);
            // 
            // lblAnzahlPersonen
            // 
            this.lblAnzahlPersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlPersonen.Location = new System.Drawing.Point(8, 400);
            this.lblAnzahlPersonen.Name = "lblAnzahlPersonen";
            this.lblAnzahlPersonen.Size = new System.Drawing.Size(163, 24);
            this.lblAnzahlPersonen.TabIndex = 11;
            this.lblAnzahlPersonen.Text = "[Anzahl Personen]";
            this.lblAnzahlPersonen.UseCompatibleTextRendering = true;
            // 
            // btnFall
            // 
            this.btnFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFall.Location = new System.Drawing.Point(617, 424);
            this.btnFall.Name = "btnFall";
            this.btnFall.Size = new System.Drawing.Size(88, 24);
            this.btnFall.TabIndex = 9;
            this.btnFall.Text = ">&Fall";
            this.btnFall.UseVisualStyleBackColor = false;
            this.btnFall.Click += new System.EventHandler(this.btnFall_Click);
            // 
            // btnNeuerFall
            // 
            this.btnNeuerFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuerFall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuerFall.Location = new System.Drawing.Point(713, 424);
            this.btnNeuerFall.Name = "btnNeuerFall";
            this.btnNeuerFall.Size = new System.Drawing.Size(88, 24);
            this.btnNeuerFall.TabIndex = 10;
            this.btnNeuerFall.Text = "&neuer Fall ...";
            this.btnNeuerFall.UseVisualStyleBackColor = false;
            this.btnNeuerFall.Click += new System.EventHandler(this.btnNeuerFall_Click);
            // 
            // popup_Tree
            // 
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo)});
            this.popup_Tree.Manager = this.barManager_Tree;
            this.popup_Tree.Name = "popup_Tree";
            // 
            // qryModul
            // 
            this.qryModul.HostControl = this;
            this.qryModul.SelectStatement = "SELECT \r\n  IconID = 100 * ModulID + 1000, \r\n  ShortName\r\nFROM XModul\r\nWHERE Modul" +
    "Tree = 1 \r\n  AND ShortName IS NOT NULL\r\nORDER BY SortKey;";
            // 
            // edtVersNr
            // 
            this.edtVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVersNr.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Location = new System.Drawing.Point(424, 396);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Size = new System.Drawing.Size(85, 24);
            this.edtVersNr.TabIndex = 5;
            this.edtVersNr.Text = "Vers.-Nr.";
            this.edtVersNr.CheckedChanged += new System.EventHandler(this.edtVersNr_CheckedChanged);
            // 
            // edtKategorie
            // 
            this.edtKategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKategorie.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Location = new System.Drawing.Point(512, 397);
            this.edtKategorie.Name = "edtKategorie";
            this.edtKategorie.Size = new System.Drawing.Size(89, 24);
            this.edtKategorie.TabIndex = 8;
            this.edtKategorie.Text = "Kategorie";
            this.edtKategorie.CheckedChanged += new System.EventHandler(this.edtKategorie_CheckedChanged);
            // 
            // edtPendenzen
            // 
            this.edtPendenzen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPendenzen.Checked = true;
            this.edtPendenzen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.edtPendenzen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPendenzen.Location = new System.Drawing.Point(600, 356);
            this.edtPendenzen.Name = "edtPendenzen";
            this.edtPendenzen.Size = new System.Drawing.Size(130, 24);
            this.edtPendenzen.TabIndex = 12;
            this.edtPendenzen.Text = "fäll. Pendenzen";
            this.edtPendenzen.CheckedChanged += new System.EventHandler(this.edtPendenzen_CheckedChanged);
            // 
            // lblAnzahlPendenzen
            // 
            this.lblAnzahlPendenzen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlPendenzen.Location = new System.Drawing.Point(8, 424);
            this.lblAnzahlPendenzen.Name = "lblAnzahlPendenzen";
            this.lblAnzahlPendenzen.Size = new System.Drawing.Size(183, 24);
            this.lblAnzahlPendenzen.TabIndex = 13;
            this.lblAnzahlPendenzen.Text = "[Anzahl Pendenzen]";
            this.lblAnzahlPendenzen.UseCompatibleTextRendering = true;
            // 
            // btnGotoPendenzen
            // 
            this.btnGotoPendenzen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGotoPendenzen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoPendenzen.Location = new System.Drawing.Point(197, 424);
            this.btnGotoPendenzen.Name = "btnGotoPendenzen";
            this.btnGotoPendenzen.Size = new System.Drawing.Size(115, 24);
            this.btnGotoPendenzen.TabIndex = 14;
            this.btnGotoPendenzen.Text = "> Pendenzen";
            this.btnGotoPendenzen.UseVisualStyleBackColor = false;
            this.btnGotoPendenzen.Click += new System.EventHandler(this.btnGotoPendenzen_Click);
            // 
            // CtlFallNavigator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(587, 199);
            this.Controls.Add(this.btnGotoPendenzen);
            this.Controls.Add(this.lblAnzahlPendenzen);
            this.Controls.Add(this.edtPendenzen);
            this.Controls.Add(this.edtKategorie);
            this.Controls.Add(this.edtVersNr);
            this.Controls.Add(this.btnNeuerFall);
            this.Controls.Add(this.btnFall);
            this.Controls.Add(this.lblAnzahlPersonen);
            this.Controls.Add(this.edtGemeinde);
            this.Controls.Add(this.edtZusatz);
            this.Controls.Add(this.edtNNummer);
            this.Controls.Add(this.edtAHVNummer);
            this.Controls.Add(this.fraRechte);
            this.Controls.Add(this.fraStatus);
            this.Controls.Add(this.treeFallNavigator);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CtlFallNavigator";
            this.Size = new System.Drawing.Size(810, 456);
            this.RefreshData += new System.EventHandler(this.FrmFallNavigator_RefreshData);
            this.Load += new System.EventHandler(this.CtlFallNavigator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeFallNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemModulIcon)).EndInit();
            this.fraStatus.ResumeLayout(false);
            this.fraRechte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPendenzen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager_Tree;
        private KiSS4.Gui.KissButton btnFall;
        private DevExpress.XtraBars.BarButtonItem btnFallInfo;
        private KiSS4.Gui.KissButton btnNeuerFall;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAHVNummer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFarbe;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGemeinde;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKategorie;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNNummer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVersNr;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colZusatz;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox edtAHVNummer;
        private System.Windows.Forms.CheckBox edtAbgeschlossene;
        private System.Windows.Forms.CheckBox edtAktive;
        private System.Windows.Forms.CheckBox edtArchivierte;
        private System.Windows.Forms.CheckBox edtGastrecht;
        private System.Windows.Forms.CheckBox edtGemeinde;
        private System.Windows.Forms.CheckBox edtGruppe;
        private System.Windows.Forms.CheckBox edtKategorie;
        private System.Windows.Forms.CheckBox edtNNummer;
        private System.Windows.Forms.CheckBox edtVersNr;
        private System.Windows.Forms.CheckBox edtZusatz;
        private KiSS4.Gui.KissGroupBox fraRechte;
        private KiSS4.Gui.KissGroupBox fraStatus;
        private KiSS4.Gui.KissLabel lblAnzahlPersonen;
        private DevExpress.XtraBars.PopupMenu popup_Tree;
        private KiSS4.DB.SqlQuery qryModul;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repItemModulIcon;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private KiSS4.Gui.KissTree treeFallNavigator;
        private System.Windows.Forms.CheckBox edtPendenzen;
        private Gui.KissLabel lblAnzahlPendenzen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPendenzen;
        private Gui.KissButton btnGotoPendenzen;
    }
}
