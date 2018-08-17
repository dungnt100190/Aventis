namespace KiSS4.Arbeit
{
    partial class CtlKaModulTree
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlThemen = new System.Windows.Forms.Panel();
            this.chlThemen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.btnKeineThemen = new KiSS4.Gui.KissButton();
            this.btnAlleThemen = new KiSS4.Gui.KissButton();
            this.lblThemenfilter = new KiSS4.Gui.KissLabel();
            this.pnlThemenfilter = new System.Windows.Forms.Panel();
            this.chkThemenfilter = new KiSS4.Gui.KissCheckEdit();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewAbklaerung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewAssistenz = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewJobtimal = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewQualifizierungE = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewQualifizierungJ = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewTransfer = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewVermittlungBI = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewVermittlungInizio = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewVermittlungSI = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewEaf = new DevExpress.XtraBars.BarButtonItem();
            this.colBaPersonID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFaLeistungID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            this.pnlThemen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chlThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemenfilter)).BeginInit();
            this.pnlThemenfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkThemenfilter.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNewAbklaerung,
            this.btnNewVermittlungInizio,
            this.btnNewQualifizierungJ,
            this.btnNewQualifizierungE,
            this.btnNewAssistenz,
            this.btnNewVermittlungBI,
            this.btnNewVermittlungSI,
            this.btnNewJobtimal,
            this.btnNewEaf,
            this.btnNewTransfer,
            this.btnDelete});
            this.barManager_Tree.MaxItemId = 11;
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            //
            // btnFallInfo
            //
            this.btnFallInfo.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete)});
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
            this.kissTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.kissTree.Appearance.VertLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.Options.UseForeColor = true;
            this.kissTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.kissTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.kissTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colDate,
            this.colFaLeistungID,
            this.colBaPersonID});
            this.kissTree.DataSource = this.qryModulTree;
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
            this.kissTree.Size = new System.Drawing.Size(320, 298);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            //
            // pnlThemen
            //
            this.pnlThemen.AutoScroll = true;
            this.pnlThemen.BackColor = System.Drawing.Color.LemonChiffon;
            this.pnlThemen.Controls.Add(this.chlThemen);
            this.pnlThemen.Controls.Add(this.btnKeineThemen);
            this.pnlThemen.Controls.Add(this.btnAlleThemen);
            this.pnlThemen.Controls.Add(this.lblThemenfilter);
            this.pnlThemen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThemen.Location = new System.Drawing.Point(0, 298);
            this.pnlThemen.Name = "pnlThemen";
            this.pnlThemen.Size = new System.Drawing.Size(320, 150);
            this.pnlThemen.TabIndex = 6;
            //
            // chlThemen
            //
            this.chlThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chlThemen.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.chlThemen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.chlThemen.Appearance.Options.UseBackColor = true;
            this.chlThemen.Appearance.Options.UseBorderColor = true;
            this.chlThemen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chlThemen.CheckOnClick = true;
            this.chlThemen.Location = new System.Drawing.Point(13, 49);
            this.chlThemen.LOVName = "KaAllgemThema";
            this.chlThemen.Name = "chlThemen";
            this.chlThemen.Size = new System.Drawing.Size(295, 95);
            this.chlThemen.TabIndex = 3;
            this.chlThemen.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chlThemen_ItemCheck);
            //
            // btnKeineThemen
            //
            this.btnKeineThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeineThemen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeineThemen.Location = new System.Drawing.Point(218, 6);
            this.btnKeineThemen.Name = "btnKeineThemen";
            this.btnKeineThemen.Size = new System.Drawing.Size(90, 24);
            this.btnKeineThemen.TabIndex = 2;
            this.btnKeineThemen.Text = "ohne Thema";
            this.btnKeineThemen.UseCompatibleTextRendering = true;
            this.btnKeineThemen.UseVisualStyleBackColor = true;
            this.btnKeineThemen.Click += new System.EventHandler(this.btnThemen_Click);
            //
            // btnAlleThemen
            //
            this.btnAlleThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleThemen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleThemen.Location = new System.Drawing.Point(167, 6);
            this.btnAlleThemen.Name = "btnAlleThemen";
            this.btnAlleThemen.Size = new System.Drawing.Size(45, 24);
            this.btnAlleThemen.TabIndex = 1;
            this.btnAlleThemen.Text = "alle";
            this.btnAlleThemen.UseCompatibleTextRendering = true;
            this.btnAlleThemen.UseVisualStyleBackColor = false;
            this.btnAlleThemen.Click += new System.EventHandler(this.btnThemen_Click);
            //
            // lblThemenfilter
            //
            this.lblThemenfilter.Location = new System.Drawing.Point(13, 3);
            this.lblThemenfilter.Name = "lblThemenfilter";
            this.lblThemenfilter.Size = new System.Drawing.Size(100, 23);
            this.lblThemenfilter.TabIndex = 0;
            this.lblThemenfilter.Text = "Themenfilter";
            this.lblThemenfilter.UseCompatibleTextRendering = true;
            //
            // pnlThemenfilter
            //
            this.pnlThemenfilter.Controls.Add(this.chkThemenfilter);
            this.pnlThemenfilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThemenfilter.Location = new System.Drawing.Point(0, 448);
            this.pnlThemenfilter.Name = "pnlThemenfilter";
            this.pnlThemenfilter.Size = new System.Drawing.Size(320, 24);
            this.pnlThemenfilter.TabIndex = 7;
            //
            // chkThemenfilter
            //
            this.chkThemenfilter.EditValue = false;
            this.chkThemenfilter.Location = new System.Drawing.Point(3, 3);
            this.chkThemenfilter.Name = "chkThemenfilter";
            this.chkThemenfilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkThemenfilter.Properties.Appearance.Options.UseBackColor = true;
            this.chkThemenfilter.Properties.Caption = "Themenfilter aktiv";
            this.chkThemenfilter.Size = new System.Drawing.Size(189, 19);
            this.chkThemenfilter.TabIndex = 0;
            this.chkThemenfilter.CheckedChanged += new System.EventHandler(this.chkThemenfilter_CheckedChanged);
            this.chkThemenfilter.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.chkThemenfilter_EditValueChanging);
            //
            // btnDelete
            //
            this.btnDelete.Caption = "Löschen";
            this.btnDelete.Id = 10;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            //
            // btnNewAbklaerung
            //
            this.btnNewAbklaerung.Caption = "neue Abklärung";
            this.btnNewAbklaerung.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewAbklaerung.Id = 3;
            this.btnNewAbklaerung.ImageIndex = 1701;
            this.btnNewAbklaerung.Name = "btnNewAbklaerung";
            this.btnNewAbklaerung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewAssistenz
            //
            this.btnNewAssistenz.Caption = "neue Assistenz";
            this.btnNewAssistenz.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewAssistenz.Id = 7;
            this.btnNewAssistenz.ImageIndex = 1701;
            this.btnNewAssistenz.Name = "btnNewAssistenz";
            this.btnNewAssistenz.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewQualifizierungE
            //
            this.btnNewQualifizierungE.Caption = "neue Qualifizierung Erwachsene";
            this.btnNewQualifizierungE.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewQualifizierungE.Id = 6;
            this.btnNewQualifizierungE.ImageIndex = 1701;
            this.btnNewQualifizierungE.Name = "btnNewQualifizierungE";
            this.btnNewQualifizierungE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewQualifizierungJ
            //
            this.btnNewQualifizierungJ.Caption = "neue Qualifizierung Jugend";
            this.btnNewQualifizierungJ.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewQualifizierungJ.Id = 5;
            this.btnNewQualifizierungJ.ImageIndex = 1701;
            this.btnNewQualifizierungJ.Name = "btnNewQualifizierungJ";
            this.btnNewQualifizierungJ.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewTransfer
            //
            this.btnNewTransfer.Caption = "neuer Transfer";
            this.btnNewTransfer.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewTransfer.Id = 11;
            this.btnNewTransfer.ImageIndex = 1701;
            this.btnNewTransfer.Name = "btnNewTransfer";
            this.btnNewTransfer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewVermittlungBI
            //
            this.btnNewVermittlungBI.Caption = "neue Vermittlung BI / BIP";
            this.btnNewVermittlungBI.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewVermittlungBI.Id = 8;
            this.btnNewVermittlungBI.ImageIndex = 1701;
            this.btnNewVermittlungBI.Name = "btnNewVermittlungBI";
            this.btnNewVermittlungBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewVermittlungInizio
            //
            this.btnNewVermittlungInizio.Caption = "neue Phase Inizio";
            this.btnNewVermittlungInizio.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewVermittlungInizio.Id = 4;
            this.btnNewVermittlungInizio.ImageIndex = 1701;
            this.btnNewVermittlungInizio.Name = "btnNewVermittlungInizio";
            this.btnNewVermittlungInizio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewVermittlungSI
            //
            this.btnNewVermittlungSI.Caption = "neue Vermittlung SI";
            this.btnNewVermittlungSI.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewVermittlungSI.Id = 9;
            this.btnNewVermittlungSI.ImageIndex = 1701;
            this.btnNewVermittlungSI.Name = "btnNewVermittlungSI";
            this.btnNewVermittlungSI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewEaf
            //
            this.btnNewEaf.Caption = "neue EAF";
            this.btnNewEaf.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewEaf.Id = 10;
            this.btnNewEaf.ImageIndex = 1701;
            this.btnNewEaf.Name = "btnNewEaf";
            this.btnNewEaf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // btnNewJobtimal
            //
            this.btnNewJobtimal.Caption = "neues Jobtimal";
            this.btnNewJobtimal.CategoryGuid = new System.Guid("404513b6-619a-4ae4-89c6-3eda6988f679");
            this.btnNewJobtimal.Id = 11;
            this.btnNewJobtimal.ImageIndex = 1701;
            this.btnNewJobtimal.Name = "btnNewJobtimal";
            this.btnNewJobtimal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            //
            // colBaPersonID
            //
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.OptionsColumn.AllowSort = false;
            //
            // colDate
            //
            this.colDate.FieldName = "DatVon";
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowSort = false;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 100;
            //
            // colFaLeistungID
            //
            this.colFaLeistungID.FieldName = "FaLeistungID";
            this.colFaLeistungID.Name = "colFaLeistungID";
            this.colFaLeistungID.OptionsColumn.AllowSort = false;
            //
            // colName
            //
            this.colName.Caption = "Arbeit";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 190;
            //
            // CtlKaModulTree
            //
            this.Controls.Add(this.pnlThemen);
            this.Controls.Add(this.pnlThemenfilter);
            this.Name = "CtlKaModulTree";
            this.DetailChanged += new System.EventHandler(this.CtlKaModulTree_DetailChanged);
            this.Load += new System.EventHandler(this.CtlKaModulTree_Load);
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.pnlThemenfilter, 0);
            this.Controls.SetChildIndex(this.pnlThemen, 0);
            this.Controls.SetChildIndex(this.kissTree, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            this.pnlThemen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chlThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemenfilter)).EndInit();
            this.pnlThemenfilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkThemenfilter.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnAlleThemen;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private KiSS4.Gui.KissButton btnKeineThemen;
        private DevExpress.XtraBars.BarButtonItem btnNewAbklaerung;
        private DevExpress.XtraBars.BarButtonItem btnNewAssistenz;
        private DevExpress.XtraBars.BarButtonItem btnNewJobtimal;
        private DevExpress.XtraBars.BarButtonItem btnNewQualifizierungE;
        private DevExpress.XtraBars.BarButtonItem btnNewQualifizierungJ;
        private DevExpress.XtraBars.BarButtonItem btnNewTransfer;
        private DevExpress.XtraBars.BarButtonItem btnNewVermittlungBI;
        private DevExpress.XtraBars.BarButtonItem btnNewVermittlungInizio;
        private DevExpress.XtraBars.BarButtonItem btnNewVermittlungSI;
        private DevExpress.XtraBars.BarButtonItem btnNewEaf;
        private KiSS4.Gui.KissCheckEdit chkThemenfilter;
        private KiSS4.Gui.KissCheckedLookupEdit chlThemen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBaPersonID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFaLeistungID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private KiSS4.Gui.KissLabel lblThemenfilter;
        private System.Windows.Forms.Panel pnlThemen;
        private System.Windows.Forms.Panel pnlThemenfilter;
    }
}