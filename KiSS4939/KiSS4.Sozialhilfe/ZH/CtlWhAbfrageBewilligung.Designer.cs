namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlWhAbfrageBewilligung
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhAbfrageBewilligung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnJumpTo = new KiSS4.Gui.KissButton();
            this.btnVisieren = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.lblFortschritt = new KiSS4.Gui.KissLabel();
            this.tabPositionDokumente = new KiSS4.Gui.KissTabControlEx();
            this.tpgDokument = new SharpLibrary.WinControls.TabPageEx();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.qryBgDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.grdDoc = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgPosition = new SharpLibrary.WinControls.TabPageEx();
            this.edtBetrifft = new KiSS4.Gui.KissTextEdit();
            this.lblBetrifft = new KiSS4.Gui.KissLabel();
            this.edtAbsender = new KiSS4.Gui.KissTextEdit();
            this.lblAbsender = new KiSS4.Gui.KissLabel();
            this.edtTyp = new KiSS4.Gui.KissTextEdit();
            this.lblTyp = new KiSS4.Gui.KissLabel();
            this.edtInfo = new KiSS4.Gui.KissTextEdit();
            this.lblInfo = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtBgFinanzplanID = new KiSS4.Gui.KissTextEdit();
            this.edtFaFallID = new KiSS4.Gui.KissTextEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblBgFinanzplanID = new KiSS4.Gui.KissLabel();
            this.lblFaFallID = new KiSS4.Gui.KissLabel();
            this.edtWhSucheSARX = new KiSS4.Gui.KissButtonEdit();
            this.edtWhSucheKlientX = new KiSS4.Gui.KissButtonEdit();
            this.edtWhSucheTypX = new KiSS4.Gui.KissLookUpEdit();
            this.edtWhSucheAbsenderX = new KiSS4.Gui.KissButtonEdit();
            this.edtWhSucheGrundbedarfX = new KiSS4.Gui.KissLookUpEdit();
            this.lblWhSucheSAR = new KiSS4.Gui.KissLabel();
            this.lblWhSucheKlientX = new KiSS4.Gui.KissLabel();
            this.lblWhSucheTypX = new KiSS4.Gui.KissLabel();
            this.lblWhSucheGrundbedarfX = new KiSS4.Gui.KissLabel();
            this.lblWhSucheAbsenderX = new KiSS4.Gui.KissLabel();
            this.lblWhSucheEmpfX = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissCalcEdit();
            this.lblUserId = new KiSS4.Gui.KissLabel();
            this.colAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragAlt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewilligungTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.edtWhSucheEmpfX = new KiSS4.Gui.KissButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFortschritt)).BeginInit();
            this.tabPositionDokumente.SuspendLayout();
            this.tpgDokument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpgPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgFinanzplanID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgFinanzplanID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaFallID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheKlientX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheTypX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheTypX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheAbsenderX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheGrundbedarfX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheGrundbedarfX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheKlientX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheTypX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheGrundbedarfX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheAbsenderX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheEmpfX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheEmpfX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "BgBewilligung";
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelektion,
            this.colDatum,
            this.colBewilligungTyp,
            this.colSA,
            this.colNameVorname,
            this.colLA,
            this.colBuchungstext,
            this.colBetrag,
            this.colBetragAlt,
            this.colDoc,
            this.colAbsender,
            this.colEmpfaenger});
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.GridStyle = KiSS4.Gui.GridStyleType.Default;
            this.grdQuery1.Location = new System.Drawing.Point(6, 0);
            this.grdQuery1.Size = new System.Drawing.Size(840, 213);
            // 
            // xDocument
            // 
            this.xDocument.DataMember = "DocumentID";
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(376, 1526);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "FAL_BaPersonID";
            this.ctlGotoFall.Location = new System.Drawing.Point(6, 403);
            this.ctlGotoFall.Size = new System.Drawing.Size(127, 26);
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(837, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(861, 470);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.tabPositionDokumente);
            this.tpgListe.Controls.Add(this.lblFortschritt);
            this.tpgListe.Controls.Add(this.btnAlle);
            this.tpgListe.Controls.Add(this.btnKeine);
            this.tpgListe.Controls.Add(this.btnVisieren);
            this.tpgListe.Controls.Add(this.btnJumpTo);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(849, 432);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnJumpTo, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnVisieren, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnKeine, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnAlle, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblFortschritt, 0);
            this.tpgListe.Controls.SetChildIndex(this.tabPositionDokumente, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtWhSucheEmpfX);
            this.tpgSuchen.Controls.Add(this.lblUserId);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblWhSucheEmpfX);
            this.tpgSuchen.Controls.Add(this.lblWhSucheAbsenderX);
            this.tpgSuchen.Controls.Add(this.lblWhSucheGrundbedarfX);
            this.tpgSuchen.Controls.Add(this.lblWhSucheTypX);
            this.tpgSuchen.Controls.Add(this.lblWhSucheKlientX);
            this.tpgSuchen.Controls.Add(this.lblWhSucheSAR);
            this.tpgSuchen.Controls.Add(this.edtWhSucheGrundbedarfX);
            this.tpgSuchen.Controls.Add(this.edtWhSucheAbsenderX);
            this.tpgSuchen.Controls.Add(this.edtWhSucheTypX);
            this.tpgSuchen.Controls.Add(this.edtWhSucheKlientX);
            this.tpgSuchen.Controls.Add(this.edtWhSucheSARX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(849, 432);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWhSucheSARX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWhSucheKlientX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWhSucheTypX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWhSucheAbsenderX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWhSucheGrundbedarfX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheKlientX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheTypX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheGrundbedarfX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheAbsenderX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheEmpfX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUserId, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWhSucheEmpfX, 0);
            // 
            // btnJumpTo
            // 
            this.btnJumpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJumpTo.Enabled = false;
            this.btnJumpTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpTo.Location = new System.Drawing.Point(139, 403);
            this.btnJumpTo.Name = "btnJumpTo";
            this.btnJumpTo.Size = new System.Drawing.Size(130, 24);
            this.btnJumpTo.TabIndex = 3;
            this.btnJumpTo.Text = "Gehe zu Finanzplan";
            this.btnJumpTo.UseCompatibleTextRendering = true;
            this.btnJumpTo.UseVisualStyleBackColor = false;
            this.btnJumpTo.Click += new System.EventHandler(this.btnJumpTo_Click);
            // 
            // btnVisieren
            // 
            this.btnVisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisieren.Enabled = false;
            this.btnVisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisieren.Location = new System.Drawing.Point(747, 403);
            this.btnVisieren.Name = "btnVisieren";
            this.btnVisieren.Size = new System.Drawing.Size(99, 24);
            this.btnVisieren.TabIndex = 4;
            this.btnVisieren.Text = "Visieren";
            this.btnVisieren.UseCompatibleTextRendering = true;
            this.btnVisieren.UseVisualStyleBackColor = false;
            this.btnVisieren.Click += new System.EventHandler(this.btnVisieren_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(692, 403);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(48, 24);
            this.btnKeine.TabIndex = 22;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseCompatibleTextRendering = true;
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(637, 403);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(48, 24);
            this.btnAlle.TabIndex = 23;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseCompatibleTextRendering = true;
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // lblFortschritt
            // 
            this.lblFortschritt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFortschritt.Location = new System.Drawing.Point(577, 403);
            this.lblFortschritt.Name = "lblFortschritt";
            this.lblFortschritt.Size = new System.Drawing.Size(54, 24);
            this.lblFortschritt.TabIndex = 24;
            this.lblFortschritt.Text = "Fortschritt";
            this.lblFortschritt.UseCompatibleTextRendering = true;
            this.lblFortschritt.Visible = false;
            // 
            // tabPositionDokumente
            // 
            this.tabPositionDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPositionDokumente.Controls.Add(this.tpgDokument);
            this.tabPositionDokumente.Controls.Add(this.tpgPosition);
            this.tabPositionDokumente.Location = new System.Drawing.Point(6, 213);
            this.tabPositionDokumente.Name = "tabPositionDokumente";
            this.tabPositionDokumente.ShowFixedWidthTooltip = true;
            this.tabPositionDokumente.Size = new System.Drawing.Size(840, 189);
            this.tabPositionDokumente.TabIndex = 25;
            this.tabPositionDokumente.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPosition,
            this.tpgDokument});
            this.tabPositionDokumente.TabsLineColor = System.Drawing.Color.Black;
            this.tabPositionDokumente.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabPositionDokumente.Text = "kissTabControlEx1";
            // 
            // tpgDokument
            // 
            this.tpgDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgDokument.Controls.Add(this.edtDocument);
            this.tpgDokument.Controls.Add(this.lblDokument);
            this.tpgDokument.Controls.Add(this.grdDoc);
            this.tpgDokument.Location = new System.Drawing.Point(6, 6);
            this.tpgDokument.Name = "tpgDokument";
            this.tpgDokument.Size = new System.Drawing.Size(828, 151);
            this.tpgDokument.TabIndex = 1;
            this.tpgDokument.Title = "Dokumente";
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDocument.CanCreateDocument = false;
            this.edtDocument.CanDeleteDocument = false;
            this.edtDocument.CanImportDocument = false;
            this.edtDocument.Context = "KgBudget";
            this.edtDocument.Cursor = System.Windows.Forms.Cursors.Default;
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryBgDokumente;
            this.edtDocument.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDocument.Location = new System.Drawing.Point(711, 123);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.Size = new System.Drawing.Size(117, 24);
            this.edtDocument.TabIndex = 9;
            // 
            // qryBgDokumente
            // 
            this.qryBgDokumente.DeleteQuestion = "Soll das Dokument gelöscht werden ?";
            this.qryBgDokumente.HostControl = this;
            this.qryBgDokumente.SelectStatement = resources.GetString("qryBgDokumente.SelectStatement");
            this.qryBgDokumente.TableName = "BgDokument";
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDokument.Location = new System.Drawing.Point(641, 123);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(59, 24);
            this.lblDokument.TabIndex = 8;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdDoc.EmbeddedNavigator.Name = "";
            this.grdDoc.Location = new System.Drawing.Point(0, 0);
            this.grdDoc.MainView = this.gridView1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.Size = new System.Drawing.Size(828, 117);
            this.grdDoc.TabIndex = 7;
            this.grdDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocTyp,
            this.colStichwort,
            this.colDateCreation,
            this.colDateLastSave});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdDoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colDocTyp
            // 
            this.colDocTyp.Caption = "Typ";
            this.colDocTyp.FieldName = "BgDokumentTypCode";
            this.colDocTyp.Name = "colDocTyp";
            this.colDocTyp.Visible = true;
            this.colDocTyp.VisibleIndex = 0;
            this.colDocTyp.Width = 123;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 1;
            this.colStichwort.Width = 382;
            // 
            // colDateCreation
            // 
            this.colDateCreation.Caption = "Erstellungsdatum";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 2;
            this.colDateCreation.Width = 110;
            // 
            // colDateLastSave
            // 
            this.colDateLastSave.Caption = "Letzte Speicherung";
            this.colDateLastSave.FieldName = "DateLastSave";
            this.colDateLastSave.Name = "colDateLastSave";
            this.colDateLastSave.Visible = true;
            this.colDateLastSave.VisibleIndex = 3;
            this.colDateLastSave.Width = 121;
            // 
            // tpgPosition
            // 
            this.tpgPosition.Controls.Add(this.edtBetrifft);
            this.tpgPosition.Controls.Add(this.lblBetrifft);
            this.tpgPosition.Controls.Add(this.edtAbsender);
            this.tpgPosition.Controls.Add(this.lblAbsender);
            this.tpgPosition.Controls.Add(this.edtTyp);
            this.tpgPosition.Controls.Add(this.lblTyp);
            this.tpgPosition.Controls.Add(this.edtInfo);
            this.tpgPosition.Controls.Add(this.lblInfo);
            this.tpgPosition.Controls.Add(this.edtBemerkung);
            this.tpgPosition.Controls.Add(this.edtBgFinanzplanID);
            this.tpgPosition.Controls.Add(this.edtFaFallID);
            this.tpgPosition.Controls.Add(this.lblBemerkung);
            this.tpgPosition.Controls.Add(this.lblBgFinanzplanID);
            this.tpgPosition.Controls.Add(this.lblFaFallID);
            this.tpgPosition.Location = new System.Drawing.Point(6, 6);
            this.tpgPosition.Name = "tpgPosition";
            this.tpgPosition.Size = new System.Drawing.Size(828, 151);
            this.tpgPosition.TabIndex = 0;
            this.tpgPosition.Title = "Position";
            // 
            // edtBetrifft
            // 
            this.edtBetrifft.DataMember = "Betrifft";
            this.edtBetrifft.DataSource = this.qryQuery;
            this.edtBetrifft.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrifft.Location = new System.Drawing.Point(535, 35);
            this.edtBetrifft.Name = "edtBetrifft";
            this.edtBetrifft.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrifft.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrifft.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrifft.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrifft.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrifft.Properties.Appearance.Options.UseFont = true;
            this.edtBetrifft.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrifft.Properties.ReadOnly = true;
            this.edtBetrifft.Size = new System.Drawing.Size(250, 24);
            this.edtBetrifft.TabIndex = 21;
            // 
            // lblBetrifft
            // 
            this.lblBetrifft.Location = new System.Drawing.Point(444, 35);
            this.lblBetrifft.Name = "lblBetrifft";
            this.lblBetrifft.Size = new System.Drawing.Size(85, 24);
            this.lblBetrifft.TabIndex = 20;
            this.lblBetrifft.Text = "betrifft";
            this.lblBetrifft.UseCompatibleTextRendering = true;
            // 
            // edtAbsender
            // 
            this.edtAbsender.DataMember = "Absender";
            this.edtAbsender.DataSource = this.qryQuery;
            this.edtAbsender.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbsender.Location = new System.Drawing.Point(79, 35);
            this.edtAbsender.Name = "edtAbsender";
            this.edtAbsender.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbsender.Properties.ReadOnly = true;
            this.edtAbsender.Size = new System.Drawing.Size(180, 24);
            this.edtAbsender.TabIndex = 19;
            // 
            // lblAbsender
            // 
            this.lblAbsender.Location = new System.Drawing.Point(5, 35);
            this.lblAbsender.Name = "lblAbsender";
            this.lblAbsender.Size = new System.Drawing.Size(68, 24);
            this.lblAbsender.TabIndex = 18;
            this.lblAbsender.Text = "Absender";
            this.lblAbsender.UseCompatibleTextRendering = true;
            // 
            // edtTyp
            // 
            this.edtTyp.DataMember = "Typ";
            this.edtTyp.DataSource = this.qryQuery;
            this.edtTyp.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTyp.Location = new System.Drawing.Point(535, 65);
            this.edtTyp.Name = "edtTyp";
            this.edtTyp.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTyp.Properties.Appearance.Options.UseFont = true;
            this.edtTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTyp.Properties.ReadOnly = true;
            this.edtTyp.Size = new System.Drawing.Size(250, 24);
            this.edtTyp.TabIndex = 17;
            // 
            // lblTyp
            // 
            this.lblTyp.Location = new System.Drawing.Point(444, 65);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(85, 24);
            this.lblTyp.TabIndex = 16;
            this.lblTyp.Text = "Finanzplan-Typ";
            this.lblTyp.UseCompatibleTextRendering = true;
            // 
            // edtInfo
            // 
            this.edtInfo.DataMember = "Info";
            this.edtInfo.DataSource = this.qryQuery;
            this.edtInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtInfo.Location = new System.Drawing.Point(79, 5);
            this.edtInfo.Name = "edtInfo";
            this.edtInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInfo.Properties.Appearance.Options.UseFont = true;
            this.edtInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInfo.Properties.ReadOnly = true;
            this.edtInfo.Size = new System.Drawing.Size(707, 24);
            this.edtInfo.TabIndex = 15;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(5, 11);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(68, 24);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.Text = "Info";
            this.lblInfo.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryQuery;
            this.edtBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBemerkung.Location = new System.Drawing.Point(79, 95);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Properties.ReadOnly = true;
            this.edtBemerkung.Size = new System.Drawing.Size(347, 54);
            this.edtBemerkung.TabIndex = 10;
            // 
            // edtBgFinanzplanID
            // 
            this.edtBgFinanzplanID.DataMember = "BgFinanzplanID";
            this.edtBgFinanzplanID.DataSource = this.qryQuery;
            this.edtBgFinanzplanID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgFinanzplanID.Location = new System.Drawing.Point(326, 65);
            this.edtBgFinanzplanID.Name = "edtBgFinanzplanID";
            this.edtBgFinanzplanID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgFinanzplanID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgFinanzplanID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgFinanzplanID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgFinanzplanID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgFinanzplanID.Properties.Appearance.Options.UseFont = true;
            this.edtBgFinanzplanID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgFinanzplanID.Properties.ReadOnly = true;
            this.edtBgFinanzplanID.Size = new System.Drawing.Size(100, 24);
            this.edtBgFinanzplanID.TabIndex = 9;
            // 
            // edtFaFallID
            // 
            this.edtFaFallID.DataMember = "FaFallID";
            this.edtFaFallID.DataSource = this.qryQuery;
            this.edtFaFallID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaFallID.Location = new System.Drawing.Point(79, 65);
            this.edtFaFallID.Name = "edtFaFallID";
            this.edtFaFallID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaFallID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaFallID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaFallID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaFallID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaFallID.Properties.Appearance.Options.UseFont = true;
            this.edtFaFallID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaFallID.Properties.ReadOnly = true;
            this.edtFaFallID.Size = new System.Drawing.Size(100, 24);
            this.edtFaFallID.TabIndex = 8;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(5, 95);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(68, 24);
            this.lblBemerkung.TabIndex = 7;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblBgFinanzplanID
            // 
            this.lblBgFinanzplanID.Location = new System.Drawing.Point(245, 65);
            this.lblBgFinanzplanID.Name = "lblBgFinanzplanID";
            this.lblBgFinanzplanID.Size = new System.Drawing.Size(75, 24);
            this.lblBgFinanzplanID.TabIndex = 6;
            this.lblBgFinanzplanID.Text = "Finanzplan-Nr.";
            this.lblBgFinanzplanID.UseCompatibleTextRendering = true;
            // 
            // lblFaFallID
            // 
            this.lblFaFallID.Location = new System.Drawing.Point(5, 65);
            this.lblFaFallID.Name = "lblFaFallID";
            this.lblFaFallID.Size = new System.Drawing.Size(68, 24);
            this.lblFaFallID.TabIndex = 5;
            this.lblFaFallID.Text = "Fall-Nr.";
            this.lblFaFallID.UseCompatibleTextRendering = true;
            // 
            // edtWhSucheSARX
            // 
            this.edtWhSucheSARX.Location = new System.Drawing.Point(142, 50);
            this.edtWhSucheSARX.LookupSQL = "select \r\n  ID$ = UserID, \r\n  MA = LastName + isNull(\', \' + FirstName,\'\'),\r\n [Kürz" +
    "el] = LogonName\r\nfrom   XUser \r\nwhere LastName + IsNull(\', \' + FirstName,\'\') LIK" +
    "E \'%\' + {0} + \'%\'\r\norder by MA\r\n----";
            this.edtWhSucheSARX.Name = "edtWhSucheSARX";
            this.edtWhSucheSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhSucheSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhSucheSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheSARX.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhSucheSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhSucheSARX.Properties.Appearance.Options.UseFont = true;
            this.edtWhSucheSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtWhSucheSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtWhSucheSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhSucheSARX.Properties.Name = "kissButtonEdit1.Properties";
            this.edtWhSucheSARX.Size = new System.Drawing.Size(257, 24);
            this.edtWhSucheSARX.TabIndex = 2;
            // 
            // edtWhSucheKlientX
            // 
            this.edtWhSucheKlientX.Location = new System.Drawing.Point(142, 80);
            this.edtWhSucheKlientX.LookupSQL = resources.GetString("edtWhSucheKlientX.LookupSQL");
            this.edtWhSucheKlientX.Name = "edtWhSucheKlientX";
            this.edtWhSucheKlientX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhSucheKlientX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhSucheKlientX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheKlientX.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhSucheKlientX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhSucheKlientX.Properties.Appearance.Options.UseFont = true;
            this.edtWhSucheKlientX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtWhSucheKlientX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtWhSucheKlientX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhSucheKlientX.Properties.Name = "kissButtonEdit1.Properties";
            this.edtWhSucheKlientX.Size = new System.Drawing.Size(257, 24);
            this.edtWhSucheKlientX.TabIndex = 4;
            // 
            // edtWhSucheTypX
            // 
            this.edtWhSucheTypX.Location = new System.Drawing.Point(142, 110);
            this.edtWhSucheTypX.LOVName = "WhHilfeTyp";
            this.edtWhSucheTypX.Name = "edtWhSucheTypX";
            this.edtWhSucheTypX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhSucheTypX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhSucheTypX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheTypX.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhSucheTypX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhSucheTypX.Properties.Appearance.Options.UseFont = true;
            this.edtWhSucheTypX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWhSucheTypX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheTypX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWhSucheTypX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWhSucheTypX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtWhSucheTypX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtWhSucheTypX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhSucheTypX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtWhSucheTypX.Properties.DisplayMember = "Text";
            this.edtWhSucheTypX.Properties.DropDownRows = 1;
            this.edtWhSucheTypX.Properties.NullText = "";
            this.edtWhSucheTypX.Properties.ShowFooter = false;
            this.edtWhSucheTypX.Properties.ShowHeader = false;
            this.edtWhSucheTypX.Properties.ValueMember = "Code";
            this.edtWhSucheTypX.Size = new System.Drawing.Size(257, 24);
            this.edtWhSucheTypX.TabIndex = 6;
            this.edtWhSucheTypX.TabStop = false;
            // 
            // edtWhSucheAbsenderX
            // 
            this.edtWhSucheAbsenderX.Location = new System.Drawing.Point(142, 140);
            this.edtWhSucheAbsenderX.LookupSQL = "select \r\n  ID$ = UserID, \r\n  MA = LastName + isNull(\', \' + FirstName,\'\'),\r\n [Kürz" +
    "el] = LogonName\r\nfrom   XUser \r\nwhere LastName + IsNull(\', \' + FirstName,\'\') LIK" +
    "E \'%\' + {0} + \'%\'\r\norder by MA\r\n----";
            this.edtWhSucheAbsenderX.Name = "edtWhSucheAbsenderX";
            this.edtWhSucheAbsenderX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhSucheAbsenderX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhSucheAbsenderX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheAbsenderX.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhSucheAbsenderX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhSucheAbsenderX.Properties.Appearance.Options.UseFont = true;
            this.edtWhSucheAbsenderX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtWhSucheAbsenderX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtWhSucheAbsenderX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhSucheAbsenderX.Properties.Name = "kissButtonEdit1.Properties";
            this.edtWhSucheAbsenderX.Size = new System.Drawing.Size(257, 24);
            this.edtWhSucheAbsenderX.TabIndex = 8;
            // 
            // edtWhSucheGrundbedarfX
            // 
            this.edtWhSucheGrundbedarfX.Location = new System.Drawing.Point(142, 200);
            this.edtWhSucheGrundbedarfX.LOVName = "WhGrundbedarfTyp";
            this.edtWhSucheGrundbedarfX.Name = "edtWhSucheGrundbedarfX";
            this.edtWhSucheGrundbedarfX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhSucheGrundbedarfX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhSucheGrundbedarfX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheGrundbedarfX.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhSucheGrundbedarfX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhSucheGrundbedarfX.Properties.Appearance.Options.UseFont = true;
            this.edtWhSucheGrundbedarfX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWhSucheGrundbedarfX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheGrundbedarfX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWhSucheGrundbedarfX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWhSucheGrundbedarfX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtWhSucheGrundbedarfX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtWhSucheGrundbedarfX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhSucheGrundbedarfX.Properties.NullText = "";
            this.edtWhSucheGrundbedarfX.Properties.ShowFooter = false;
            this.edtWhSucheGrundbedarfX.Properties.ShowHeader = false;
            this.edtWhSucheGrundbedarfX.Size = new System.Drawing.Size(257, 24);
            this.edtWhSucheGrundbedarfX.TabIndex = 12;
            // 
            // lblWhSucheSAR
            // 
            this.lblWhSucheSAR.Location = new System.Drawing.Point(8, 50);
            this.lblWhSucheSAR.Name = "lblWhSucheSAR";
            this.lblWhSucheSAR.Size = new System.Drawing.Size(91, 24);
            this.lblWhSucheSAR.TabIndex = 1;
            this.lblWhSucheSAR.Text = "zuständiger MA";
            this.lblWhSucheSAR.UseCompatibleTextRendering = true;
            // 
            // lblWhSucheKlientX
            // 
            this.lblWhSucheKlientX.Location = new System.Drawing.Point(8, 80);
            this.lblWhSucheKlientX.Name = "lblWhSucheKlientX";
            this.lblWhSucheKlientX.Size = new System.Drawing.Size(70, 24);
            this.lblWhSucheKlientX.TabIndex = 3;
            this.lblWhSucheKlientX.Text = "Klient";
            this.lblWhSucheKlientX.UseCompatibleTextRendering = true;
            // 
            // lblWhSucheTypX
            // 
            this.lblWhSucheTypX.Location = new System.Drawing.Point(8, 110);
            this.lblWhSucheTypX.Name = "lblWhSucheTypX";
            this.lblWhSucheTypX.Size = new System.Drawing.Size(91, 24);
            this.lblWhSucheTypX.TabIndex = 5;
            this.lblWhSucheTypX.Text = "Finanzplan-Typ";
            this.lblWhSucheTypX.UseCompatibleTextRendering = true;
            // 
            // lblWhSucheGrundbedarfX
            // 
            this.lblWhSucheGrundbedarfX.Location = new System.Drawing.Point(8, 200);
            this.lblWhSucheGrundbedarfX.Name = "lblWhSucheGrundbedarfX";
            this.lblWhSucheGrundbedarfX.Size = new System.Drawing.Size(128, 24);
            this.lblWhSucheGrundbedarfX.TabIndex = 11;
            this.lblWhSucheGrundbedarfX.Text = "Berechnungsgrundlage";
            this.lblWhSucheGrundbedarfX.UseCompatibleTextRendering = true;
            // 
            // lblWhSucheAbsenderX
            // 
            this.lblWhSucheAbsenderX.Location = new System.Drawing.Point(8, 140);
            this.lblWhSucheAbsenderX.Name = "lblWhSucheAbsenderX";
            this.lblWhSucheAbsenderX.Size = new System.Drawing.Size(70, 24);
            this.lblWhSucheAbsenderX.TabIndex = 7;
            this.lblWhSucheAbsenderX.Text = "Absender";
            this.lblWhSucheAbsenderX.UseCompatibleTextRendering = true;
            // 
            // lblWhSucheEmpfX
            // 
            this.lblWhSucheEmpfX.Location = new System.Drawing.Point(8, 170);
            this.lblWhSucheEmpfX.Name = "lblWhSucheEmpfX";
            this.lblWhSucheEmpfX.Size = new System.Drawing.Size(70, 24);
            this.lblWhSucheEmpfX.TabIndex = 9;
            this.lblWhSucheEmpfX.Text = "Empfänger";
            this.lblWhSucheEmpfX.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(586, 60);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(72, 24);
            this.edtUserID.TabIndex = 14;
            this.edtUserID.Visible = false;
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(489, 60);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(91, 24);
            this.lblUserId.TabIndex = 13;
            this.lblUserId.Text = "UserID (hidden)";
            this.lblUserId.UseCompatibleTextRendering = true;
            this.lblUserId.Visible = false;
            // 
            // colAbsender
            // 
            this.colAbsender.Caption = "Absender";
            this.colAbsender.FieldName = "Absender";
            this.colAbsender.Name = "colAbsender";
            this.colAbsender.OptionsColumn.AllowEdit = false;
            this.colAbsender.Width = 95;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "BetragBudget";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 7;
            this.colBetrag.Width = 77;
            // 
            // colBetragAlt
            // 
            this.colBetragAlt.Caption = "B. aktuell";
            this.colBetragAlt.DisplayFormat.FormatString = "n2";
            this.colBetragAlt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragAlt.FieldName = "BetragAlt";
            this.colBetragAlt.Name = "colBetragAlt";
            this.colBetragAlt.OptionsColumn.AllowEdit = false;
            this.colBetragAlt.Visible = true;
            this.colBetragAlt.VisibleIndex = 8;
            // 
            // colBewilligungTyp
            // 
            this.colBewilligungTyp.Caption = "Bew. Typ";
            this.colBewilligungTyp.FieldName = "BewilligungTyp";
            this.colBewilligungTyp.Name = "colBewilligungTyp";
            this.colBewilligungTyp.OptionsColumn.AllowEdit = false;
            this.colBewilligungTyp.Visible = true;
            this.colBewilligungTyp.VisibleIndex = 2;
            this.colBewilligungTyp.Width = 113;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 6;
            this.colBuchungstext.Width = 97;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowEdit = false;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 1;
            // 
            // colDoc
            // 
            this.colDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.AppearanceHeader.Options.UseTextOptions = true;
            this.colDoc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.Caption = "Dok";
            this.colDoc.FieldName = "Doc";
            this.colDoc.Name = "colDoc";
            this.colDoc.OptionsColumn.AllowEdit = false;
            this.colDoc.Visible = true;
            this.colDoc.VisibleIndex = 9;
            this.colDoc.Width = 50;
            // 
            // colEmpfaenger
            // 
            this.colEmpfaenger.Caption = "Empfänger";
            this.colEmpfaenger.FieldName = "Empfaenger";
            this.colEmpfaenger.Name = "colEmpfaenger";
            this.colEmpfaenger.OptionsColumn.AllowEdit = false;
            this.colEmpfaenger.Visible = true;
            this.colEmpfaenger.VisibleIndex = 10;
            this.colEmpfaenger.Width = 95;
            // 
            // colLA
            // 
            this.colLA.Caption = "LA";
            this.colLA.FieldName = "LA";
            this.colLA.Name = "colLA";
            this.colLA.OptionsColumn.AllowEdit = false;
            this.colLA.Visible = true;
            this.colLA.VisibleIndex = 5;
            this.colLA.Width = 41;
            // 
            // colNameVorname
            // 
            this.colNameVorname.Caption = "Klient";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.OptionsColumn.AllowEdit = false;
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 4;
            this.colNameVorname.Width = 120;
            // 
            // colSA
            // 
            this.colSA.Caption = "zust. MA";
            this.colSA.FieldName = "SA";
            this.colSA.Name = "colSA";
            this.colSA.OptionsColumn.AllowEdit = false;
            this.colSA.Visible = true;
            this.colSA.VisibleIndex = 3;
            this.colSA.Width = 102;
            // 
            // colSelektion
            // 
            this.colSelektion.Caption = "Sel.";
            this.colSelektion.FieldName = "Sel";
            this.colSelektion.Name = "colSelektion";
            this.colSelektion.Visible = true;
            this.colSelektion.VisibleIndex = 0;
            this.colSelektion.Width = 42;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // edtWhSucheEmpfX
            // 
            this.edtWhSucheEmpfX.Location = new System.Drawing.Point(142, 170);
            this.edtWhSucheEmpfX.Name = "edtWhSucheEmpfX";
            this.edtWhSucheEmpfX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhSucheEmpfX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhSucheEmpfX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheEmpfX.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhSucheEmpfX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhSucheEmpfX.Properties.Appearance.Options.UseFont = true;
            this.edtWhSucheEmpfX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtWhSucheEmpfX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtWhSucheEmpfX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhSucheEmpfX.Size = new System.Drawing.Size(257, 24);
            this.edtWhSucheEmpfX.TabIndex = 10;
            this.edtWhSucheEmpfX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtWhSucheEmpfX_UserModifiedFld);
            // 
            // CtlWhAbfrageBewilligung
            // 
            this.Name = "CtlWhAbfrageBewilligung";
            this.Size = new System.Drawing.Size(877, 505);
            this.Load += new System.EventHandler(this.CtlWhAbfrageBewilligung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFortschritt)).EndInit();
            this.tabPositionDokumente.ResumeLayout(false);
            this.tpgDokument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpgPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgFinanzplanID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgFinanzplanID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaFallID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheKlientX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheTypX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheTypX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheAbsenderX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheGrundbedarfX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheGrundbedarfX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheKlientX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheTypX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheGrundbedarfX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheAbsenderX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheEmpfX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheEmpfX.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnJumpTo;
        private KiSS4.Gui.KissButton btnKeine;
        private KiSS4.Gui.KissButton btnVisieren;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsender;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragAlt;
        private DevExpress.XtraGrid.Columns.GridColumn colBewilligungTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpfaenger;
        private DevExpress.XtraGrid.Columns.GridColumn colLA;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colSA;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissTextEdit edtAbsender;
        private KiSS4.Gui.KissTextEdit edtBetrifft;
        private KiSS4.Gui.KissTextEdit edtBgFinanzplanID;
        private KiSS4.Dokument.XDokument edtDocument;
        private KiSS4.Gui.KissTextEdit edtFaFallID;
        private KiSS4.Gui.KissTextEdit edtInfo;
        private KiSS4.Gui.KissTextEdit edtTyp;
        private KiSS4.Gui.KissCalcEdit edtUserID;
        private KiSS4.Gui.KissButtonEdit edtWhSucheAbsenderX;
        private KiSS4.Gui.KissButtonEdit edtWhSucheEmpfX;
        private KiSS4.Gui.KissLookUpEdit edtWhSucheGrundbedarfX;
        private KiSS4.Gui.KissButtonEdit edtWhSucheKlientX;
        private KiSS4.Gui.KissButtonEdit edtWhSucheSARX;
        private KiSS4.Gui.KissLookUpEdit edtWhSucheTypX;
        private KiSS4.Gui.KissGrid grdDoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblUserId;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissTabControlEx tabPositionDokumente;
        private KiSS4.Gui.KissLabel lblAbsender;
        private KiSS4.Gui.KissLabel lblBetrifft;
        private KiSS4.Gui.KissLabel lblBgFinanzplanID;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblFaFallID;
        private KiSS4.Gui.KissLabel lblFortschritt;
        private KiSS4.Gui.KissLabel lblInfo;
        private KiSS4.Gui.KissLabel lblTyp;
        private KiSS4.Gui.KissLabel lblWhSucheAbsenderX;
        private KiSS4.Gui.KissLabel lblWhSucheEmpfX;
        private KiSS4.Gui.KissLabel lblWhSucheGrundbedarfX;
        private KiSS4.Gui.KissLabel lblWhSucheKlientX;
        private KiSS4.Gui.KissLabel lblWhSucheSAR;
        private KiSS4.Gui.KissLabel lblWhSucheTypX;
        private KiSS4.DB.SqlQuery qryBgDokumente;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private SharpLibrary.WinControls.TabPageEx tpgDokument;
        private SharpLibrary.WinControls.TabPageEx tpgPosition;
    }
}
