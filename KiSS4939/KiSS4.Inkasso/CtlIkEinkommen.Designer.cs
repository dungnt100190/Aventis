namespace KiSS4.Inkasso
{
    partial class CtlIkEinkommen
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkEinkommen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdEinkommen = new KiSS4.Gui.KissGrid();
            this.qryIkEinkommen = new KiSS4.DB.SqlQuery(this.components);
            this.grvEinkommen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLeistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrifft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryBetrifftPerson = new KiSS4.DB.SqlQuery(this.components);
            this.lblSucheGueltigAb = new KiSS4.Gui.KissLabel();
            this.edtSucheGueltigAb = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGueltigBis = new KiSS4.Gui.KissLabel();
            this.edtSucheGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBetrifft = new KiSS4.Gui.KissLabel();
            this.edtSucheBetrifft = new KiSS4.Gui.KissLookUpEdit();
            this.edtGueltigAb = new KiSS4.Gui.KissDateEdit();
            this.lblGueltigAb = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblBetrifft = new KiSS4.Gui.KissLabel();
            this.edtBetrifft = new KiSS4.Gui.KissLookUpEdit();
            this.colPendenzDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblZusatzeinnahmen = new KiSS4.Gui.KissLabel();
            this.edtZusatzeinnahmen = new KiSS4.Gui.KissLookUpEdit();
            this.lblBedarfsabhaengigeSozialleistungen = new KiSS4.Gui.KissLabel();
            this.edtBedarfsabhaengigeSozialleistungen = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinkommenTaggelderVersicherungen = new KiSS4.Gui.KissLabel();
            this.edtEinkommenTaggelderVersicherungen = new KiSS4.Gui.KissLookUpEdit();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.edtGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtSucheZusatzeinnahmen = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtSucheBedarfsabhaengigeSozialleistungen = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtSucheEinkommenTaggelderVersicherungen = new KiSS4.Gui.KissLookUpEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkEinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBetrifftPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGueltigAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGueltigAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrifft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrifft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrifft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifft.Properties)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzeinnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzeinnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzeinnahmen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBedarfsabhaengigeSozialleistungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBedarfsabhaengigeSozialleistungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBedarfsabhaengigeSozialleistungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinkommenTaggelderVersicherungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinkommenTaggelderVersicherungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinkommenTaggelderVersicherungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZusatzeinnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZusatzeinnahmen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBedarfsabhaengigeSozialleistungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBedarfsabhaengigeSozialleistungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinkommenTaggelderVersicherungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinkommenTaggelderVersicherungen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(612, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Size = new System.Drawing.Size(636, 243);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdEinkommen);
            this.tpgListe.Size = new System.Drawing.Size(624, 205);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.AutoScroll = true;
            this.tpgSuchen.AutoScrollMinSize = new System.Drawing.Size(600, 200);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtSucheZusatzeinnahmen);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.edtSucheBedarfsabhaengigeSozialleistungen);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.edtSucheEinkommenTaggelderVersicherungen);
            this.tpgSuchen.Controls.Add(this.edtSucheBetrifft);
            this.tpgSuchen.Controls.Add(this.lblSucheBetrifft);
            this.tpgSuchen.Controls.Add(this.edtSucheGueltigBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGueltigBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGueltigAb);
            this.tpgSuchen.Controls.Add(this.lblSucheGueltigAb);
            this.tpgSuchen.Size = new System.Drawing.Size(624, 205);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGueltigAb, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGueltigAb, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGueltigBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGueltigBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetrifft, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetrifft, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheEinkommenTaggelderVersicherungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBedarfsabhaengigeSozialleistungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZusatzeinnahmen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            // 
            // grdEinkommen
            // 
            this.grdEinkommen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEinkommen.DataSource = this.qryIkEinkommen;
            // 
            // 
            // 
            this.grdEinkommen.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Fa_Dok_Korrespondenz.EmbeddedNavigator";
            this.grdEinkommen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEinkommen.Location = new System.Drawing.Point(0, 0);
            this.grdEinkommen.MainView = this.grvEinkommen;
            this.grdEinkommen.Name = "grdEinkommen";
            this.grdEinkommen.Size = new System.Drawing.Size(624, 202);
            this.grdEinkommen.TabIndex = 0;
            this.grdEinkommen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinkommen});
            // 
            // qryIkEinkommen
            // 
            this.qryIkEinkommen.CanDelete = true;
            this.qryIkEinkommen.CanInsert = true;
            this.qryIkEinkommen.CanUpdate = true;
            this.qryIkEinkommen.HostControl = this;
            this.qryIkEinkommen.SelectStatement = resources.GetString("qryIkEinkommen.SelectStatement");
            this.qryIkEinkommen.TableName = "IkEinkommen";
            this.qryIkEinkommen.AfterInsert += new System.EventHandler(this.qryIkEinkommen_AfterInsert);
            this.qryIkEinkommen.BeforePost += new System.EventHandler(this.qryIkEinkommen_BeforePost);
            // 
            // grvEinkommen
            // 
            this.grvEinkommen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEinkommen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.Empty.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.Empty.Options.UseFont = true;
            this.grvEinkommen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.EvenRow.Options.UseFont = true;
            this.grvEinkommen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinkommen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEinkommen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEinkommen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEinkommen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinkommen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEinkommen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEinkommen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEinkommen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinkommen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinkommen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinkommen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinkommen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.GroupRow.Options.UseFont = true;
            this.grvEinkommen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEinkommen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEinkommen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEinkommen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinkommen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEinkommen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEinkommen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEinkommen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinkommen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEinkommen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEinkommen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinkommen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.OddRow.Options.UseFont = true;
            this.grvEinkommen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinkommen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.Row.Options.UseBackColor = true;
            this.grvEinkommen.Appearance.Row.Options.UseFont = true;
            this.grvEinkommen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinkommen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEinkommen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinkommen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEinkommen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEinkommen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLeistung,
            this.colGueltigAb,
            this.colGueltigBis,
            this.colBetrag,
            this.colBetrifft});
            this.grvEinkommen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEinkommen.GridControl = this.grdEinkommen;
            this.grvEinkommen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvEinkommen.Name = "grvEinkommen";
            this.grvEinkommen.OptionsBehavior.Editable = false;
            this.grvEinkommen.OptionsCustomization.AllowFilter = false;
            this.grvEinkommen.OptionsFilter.AllowFilterEditor = false;
            this.grvEinkommen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEinkommen.OptionsMenu.EnableColumnMenu = false;
            this.grvEinkommen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEinkommen.OptionsNavigation.UseTabKey = false;
            this.grvEinkommen.OptionsView.ColumnAutoWidth = false;
            this.grvEinkommen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEinkommen.OptionsView.ShowGroupPanel = false;
            this.grvEinkommen.OptionsView.ShowIndicator = false;
            // 
            // colLeistung
            // 
            this.colLeistung.Caption = "Leistung";
            this.colLeistung.Name = "colLeistung";
            this.colLeistung.Visible = true;
            this.colLeistung.VisibleIndex = 0;
            // 
            // colGueltigAb
            // 
            this.colGueltigAb.Caption = "Gültig ab";
            this.colGueltigAb.Name = "colGueltigAb";
            this.colGueltigAb.Visible = true;
            this.colGueltigAb.VisibleIndex = 1;
            // 
            // colGueltigBis
            // 
            this.colGueltigBis.Caption = "Gültig bis";
            this.colGueltigBis.Name = "colGueltigBis";
            this.colGueltigBis.Visible = true;
            this.colGueltigBis.VisibleIndex = 2;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            // 
            // colBetrifft
            // 
            this.colBetrifft.Caption = "Betrifft";
            this.colBetrifft.Name = "colBetrifft";
            this.colBetrifft.Visible = true;
            this.colBetrifft.VisibleIndex = 4;
            // 
            // qryBetrifftPerson
            // 
            this.qryBetrifftPerson.SelectStatement = resources.GetString("qryBetrifftPerson.SelectStatement");
            // 
            // lblSucheGueltigAb
            // 
            this.lblSucheGueltigAb.Location = new System.Drawing.Point(30, 40);
            this.lblSucheGueltigAb.Name = "lblSucheGueltigAb";
            this.lblSucheGueltigAb.Size = new System.Drawing.Size(84, 24);
            this.lblSucheGueltigAb.TabIndex = 0;
            this.lblSucheGueltigAb.Text = "Gültig ab";
            this.lblSucheGueltigAb.UseCompatibleTextRendering = true;
            // 
            // edtSucheGueltigAb
            // 
            this.edtSucheGueltigAb.EditValue = null;
            this.edtSucheGueltigAb.Location = new System.Drawing.Point(253, 40);
            this.edtSucheGueltigAb.Name = "edtSucheGueltigAb";
            this.edtSucheGueltigAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGueltigAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGueltigAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGueltigAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGueltigAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGueltigAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGueltigAb.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGueltigAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheGueltigAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGueltigAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheGueltigAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGueltigAb.Properties.ShowToday = false;
            this.edtSucheGueltigAb.Size = new System.Drawing.Size(90, 24);
            this.edtSucheGueltigAb.TabIndex = 0;
            // 
            // lblSucheGueltigBis
            // 
            this.lblSucheGueltigBis.Location = new System.Drawing.Point(349, 40);
            this.lblSucheGueltigBis.Name = "lblSucheGueltigBis";
            this.lblSucheGueltigBis.Size = new System.Drawing.Size(35, 24);
            this.lblSucheGueltigBis.TabIndex = 1;
            this.lblSucheGueltigBis.Text = "bis";
            this.lblSucheGueltigBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheGueltigBis
            // 
            this.edtSucheGueltigBis.EditValue = null;
            this.edtSucheGueltigBis.Location = new System.Drawing.Point(390, 40);
            this.edtSucheGueltigBis.Name = "edtSucheGueltigBis";
            this.edtSucheGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGueltigBis.Properties.ShowToday = false;
            this.edtSucheGueltigBis.Size = new System.Drawing.Size(90, 24);
            this.edtSucheGueltigBis.TabIndex = 1;
            // 
            // lblSucheBetrifft
            // 
            this.lblSucheBetrifft.Location = new System.Drawing.Point(30, 70);
            this.lblSucheBetrifft.Name = "lblSucheBetrifft";
            this.lblSucheBetrifft.Size = new System.Drawing.Size(84, 24);
            this.lblSucheBetrifft.TabIndex = 2;
            this.lblSucheBetrifft.Text = "Betrifft";
            this.lblSucheBetrifft.UseCompatibleTextRendering = true;
            // 
            // edtSucheBetrifft
            // 
            this.edtSucheBetrifft.Location = new System.Drawing.Point(253, 70);
            this.edtSucheBetrifft.Name = "edtSucheBetrifft";
            this.edtSucheBetrifft.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetrifft.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetrifft.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetrifft.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetrifft.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetrifft.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetrifft.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBetrifft.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetrifft.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBetrifft.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBetrifft.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheBetrifft.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheBetrifft.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBetrifft.Properties.NullText = "";
            this.edtSucheBetrifft.Properties.ShowFooter = false;
            this.edtSucheBetrifft.Properties.ShowHeader = false;
            this.edtSucheBetrifft.Size = new System.Drawing.Size(227, 24);
            this.edtSucheBetrifft.TabIndex = 2;
            // 
            // edtGueltigAb
            // 
            this.edtGueltigAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGueltigAb.DataSource = this.qryIkEinkommen;
            this.edtGueltigAb.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtGueltigAb.EditValue = null;
            this.edtGueltigAb.Location = new System.Drawing.Point(232, 5);
            this.edtGueltigAb.Name = "edtGueltigAb";
            this.edtGueltigAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGueltigAb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtGueltigAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGueltigAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGueltigAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtGueltigAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGueltigAb.Properties.Appearance.Options.UseFont = true;
            this.edtGueltigAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtGueltigAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGueltigAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtGueltigAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGueltigAb.Properties.Name = "edtFaDokKorreDatum.Properties";
            this.edtGueltigAb.Properties.ShowToday = false;
            this.edtGueltigAb.Size = new System.Drawing.Size(90, 24);
            this.edtGueltigAb.TabIndex = 4;
            // 
            // lblGueltigAb
            // 
            this.lblGueltigAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigAb.Location = new System.Drawing.Point(10, 5);
            this.lblGueltigAb.Name = "lblGueltigAb";
            this.lblGueltigAb.Size = new System.Drawing.Size(216, 24);
            this.lblGueltigAb.TabIndex = 4;
            this.lblGueltigAb.Text = "Gültig ab";
            this.lblGueltigAb.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataSource = this.qryIkEinkommen;
            this.edtBemerkung.Location = new System.Drawing.Point(232, 185);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(392, 128);
            this.edtBemerkung.TabIndex = 7;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(10, 185);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(216, 24);
            this.lblBemerkung.TabIndex = 7;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblBetrifft
            // 
            this.lblBetrifft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrifft.Location = new System.Drawing.Point(9, 35);
            this.lblBetrifft.Name = "lblBetrifft";
            this.lblBetrifft.Size = new System.Drawing.Size(216, 24);
            this.lblBetrifft.TabIndex = 5;
            this.lblBetrifft.Text = "Betrifft";
            this.lblBetrifft.UseCompatibleTextRendering = true;
            // 
            // edtBetrifft
            // 
            this.edtBetrifft.AllowNull = false;
            this.edtBetrifft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrifft.DataSource = this.qryIkEinkommen;
            this.edtBetrifft.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBetrifft.Location = new System.Drawing.Point(232, 35);
            this.edtBetrifft.Name = "edtBetrifft";
            this.edtBetrifft.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBetrifft.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrifft.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrifft.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrifft.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrifft.Properties.Appearance.Options.UseFont = true;
            this.edtBetrifft.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBetrifft.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrifft.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBetrifft.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBetrifft.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBetrifft.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBetrifft.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrifft.Properties.NullText = "";
            this.edtBetrifft.Properties.ShowFooter = false;
            this.edtBetrifft.Properties.ShowHeader = false;
            this.edtBetrifft.Size = new System.Drawing.Size(227, 24);
            this.edtBetrifft.TabIndex = 5;
            // 
            // colPendenzDatum
            // 
            this.colPendenzDatum.Caption = "Datum";
            this.colPendenzDatum.Name = "colPendenzDatum";
            this.colPendenzDatum.Visible = true;
            this.colPendenzDatum.VisibleIndex = 0;
            this.colPendenzDatum.Width = 76;
            // 
            // colPendenzMitarbeiter
            // 
            this.colPendenzMitarbeiter.Caption = "Mitarbeiter";
            this.colPendenzMitarbeiter.Name = "colPendenzMitarbeiter";
            this.colPendenzMitarbeiter.Visible = true;
            this.colPendenzMitarbeiter.VisibleIndex = 2;
            this.colPendenzMitarbeiter.Width = 181;
            // 
            // colPendenzStatus
            // 
            this.colPendenzStatus.Caption = "Status";
            this.colPendenzStatus.Name = "colPendenzStatus";
            this.colPendenzStatus.Visible = true;
            this.colPendenzStatus.VisibleIndex = 1;
            this.colPendenzStatus.Width = 105;
            // 
            // colPendenzText
            // 
            this.colPendenzText.Caption = "Text";
            this.colPendenzText.FieldName = "Text";
            this.colPendenzText.Name = "colPendenzText";
            this.colPendenzText.Visible = true;
            this.colPendenzText.VisibleIndex = 3;
            // 
            // panelDetail
            // 
            this.panelDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetail.Controls.Add(this.edtBetrag);
            this.panelDetail.Controls.Add(this.lblBetrag);
            this.panelDetail.Controls.Add(this.lblZusatzeinnahmen);
            this.panelDetail.Controls.Add(this.edtZusatzeinnahmen);
            this.panelDetail.Controls.Add(this.lblBedarfsabhaengigeSozialleistungen);
            this.panelDetail.Controls.Add(this.edtBedarfsabhaengigeSozialleistungen);
            this.panelDetail.Controls.Add(this.lblEinkommenTaggelderVersicherungen);
            this.panelDetail.Controls.Add(this.edtEinkommenTaggelderVersicherungen);
            this.panelDetail.Controls.Add(this.lblGueltigBis);
            this.panelDetail.Controls.Add(this.edtGueltigBis);
            this.panelDetail.Controls.Add(this.lblGueltigAb);
            this.panelDetail.Controls.Add(this.lblBemerkung);
            this.panelDetail.Controls.Add(this.lblBetrifft);
            this.panelDetail.Controls.Add(this.edtBemerkung);
            this.panelDetail.Controls.Add(this.edtBetrifft);
            this.panelDetail.Controls.Add(this.edtGueltigAb);
            this.panelDetail.Location = new System.Drawing.Point(0, 244);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(639, 316);
            this.panelDetail.TabIndex = 1;
            // 
            // edtBetrag
            // 
            this.edtBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrag.DataSource = this.qryIkEinkommen;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBetrag.Location = new System.Drawing.Point(232, 155);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.Mask.EditMask = "n2";
            this.edtBetrag.Size = new System.Drawing.Size(105, 24);
            this.edtBetrag.TabIndex = 17;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrag.Location = new System.Drawing.Point(10, 155);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(217, 24);
            this.lblBetrag.TabIndex = 16;
            this.lblBetrag.Text = "Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // lblZusatzeinnahmen
            // 
            this.lblZusatzeinnahmen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZusatzeinnahmen.Location = new System.Drawing.Point(9, 125);
            this.lblZusatzeinnahmen.Name = "lblZusatzeinnahmen";
            this.lblZusatzeinnahmen.Size = new System.Drawing.Size(217, 24);
            this.lblZusatzeinnahmen.TabIndex = 15;
            this.lblZusatzeinnahmen.Text = "Zusatzeinnahmen";
            this.lblZusatzeinnahmen.UseCompatibleTextRendering = true;
            // 
            // edtZusatzeinnahmen
            // 
            this.edtZusatzeinnahmen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZusatzeinnahmen.DataSource = this.qryIkEinkommen;
            this.edtZusatzeinnahmen.Location = new System.Drawing.Point(232, 125);
            this.edtZusatzeinnahmen.LOVFilter = "3";
            this.edtZusatzeinnahmen.LOVName = "IkEinkommenTyp";
            this.edtZusatzeinnahmen.Name = "edtZusatzeinnahmen";
            this.edtZusatzeinnahmen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzeinnahmen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzeinnahmen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzeinnahmen.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzeinnahmen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzeinnahmen.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzeinnahmen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatzeinnahmen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzeinnahmen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatzeinnahmen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatzeinnahmen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtZusatzeinnahmen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtZusatzeinnahmen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzeinnahmen.Properties.NullText = "";
            this.edtZusatzeinnahmen.Properties.ShowFooter = false;
            this.edtZusatzeinnahmen.Properties.ShowHeader = false;
            this.edtZusatzeinnahmen.Size = new System.Drawing.Size(227, 24);
            this.edtZusatzeinnahmen.TabIndex = 14;
            this.edtZusatzeinnahmen.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtIkEinkommenTyp_UserModifiedFld);
            // 
            // lblBedarfsabhaengigeSozialleistungen
            // 
            this.lblBedarfsabhaengigeSozialleistungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBedarfsabhaengigeSozialleistungen.Location = new System.Drawing.Point(9, 95);
            this.lblBedarfsabhaengigeSozialleistungen.Name = "lblBedarfsabhaengigeSozialleistungen";
            this.lblBedarfsabhaengigeSozialleistungen.Size = new System.Drawing.Size(217, 24);
            this.lblBedarfsabhaengigeSozialleistungen.TabIndex = 13;
            this.lblBedarfsabhaengigeSozialleistungen.Text = "Bedarfsabhängige Sozialleistungen";
            this.lblBedarfsabhaengigeSozialleistungen.UseCompatibleTextRendering = true;
            // 
            // edtBedarfsabhaengigeSozialleistungen
            // 
            this.edtBedarfsabhaengigeSozialleistungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBedarfsabhaengigeSozialleistungen.DataSource = this.qryIkEinkommen;
            this.edtBedarfsabhaengigeSozialleistungen.Location = new System.Drawing.Point(232, 95);
            this.edtBedarfsabhaengigeSozialleistungen.LOVFilter = "2";
            this.edtBedarfsabhaengigeSozialleistungen.LOVName = "IkEinkommenTyp";
            this.edtBedarfsabhaengigeSozialleistungen.Name = "edtBedarfsabhaengigeSozialleistungen";
            this.edtBedarfsabhaengigeSozialleistungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBedarfsabhaengigeSozialleistungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.Appearance.Options.UseFont = true;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBedarfsabhaengigeSozialleistungen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.NullText = "";
            this.edtBedarfsabhaengigeSozialleistungen.Properties.ShowFooter = false;
            this.edtBedarfsabhaengigeSozialleistungen.Properties.ShowHeader = false;
            this.edtBedarfsabhaengigeSozialleistungen.Size = new System.Drawing.Size(227, 24);
            this.edtBedarfsabhaengigeSozialleistungen.TabIndex = 12;
            this.edtBedarfsabhaengigeSozialleistungen.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtIkEinkommenTyp_UserModifiedFld);
            // 
            // lblEinkommenTaggelderVersicherungen
            // 
            this.lblEinkommenTaggelderVersicherungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinkommenTaggelderVersicherungen.Location = new System.Drawing.Point(9, 65);
            this.lblEinkommenTaggelderVersicherungen.Name = "lblEinkommenTaggelderVersicherungen";
            this.lblEinkommenTaggelderVersicherungen.Size = new System.Drawing.Size(217, 24);
            this.lblEinkommenTaggelderVersicherungen.TabIndex = 11;
            this.lblEinkommenTaggelderVersicherungen.Text = "Einkommen, Taggelder, Versicherungen";
            this.lblEinkommenTaggelderVersicherungen.UseCompatibleTextRendering = true;
            // 
            // edtEinkommenTaggelderVersicherungen
            // 
            this.edtEinkommenTaggelderVersicherungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinkommenTaggelderVersicherungen.DataSource = this.qryIkEinkommen;
            this.edtEinkommenTaggelderVersicherungen.Location = new System.Drawing.Point(232, 65);
            this.edtEinkommenTaggelderVersicherungen.LOVFilter = "1";
            this.edtEinkommenTaggelderVersicherungen.LOVName = "IkEinkommenTyp";
            this.edtEinkommenTaggelderVersicherungen.Name = "edtEinkommenTaggelderVersicherungen";
            this.edtEinkommenTaggelderVersicherungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinkommenTaggelderVersicherungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinkommenTaggelderVersicherungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinkommenTaggelderVersicherungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinkommenTaggelderVersicherungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinkommenTaggelderVersicherungen.Properties.Appearance.Options.UseFont = true;
            this.edtEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinkommenTaggelderVersicherungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEinkommenTaggelderVersicherungen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEinkommenTaggelderVersicherungen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinkommenTaggelderVersicherungen.Properties.NullText = "";
            this.edtEinkommenTaggelderVersicherungen.Properties.ShowFooter = false;
            this.edtEinkommenTaggelderVersicherungen.Properties.ShowHeader = false;
            this.edtEinkommenTaggelderVersicherungen.Size = new System.Drawing.Size(227, 24);
            this.edtEinkommenTaggelderVersicherungen.TabIndex = 10;
            this.edtEinkommenTaggelderVersicherungen.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtIkEinkommenTyp_UserModifiedFld);
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigBis.Location = new System.Drawing.Point(328, 5);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(35, 24);
            this.lblGueltigBis.TabIndex = 9;
            this.lblGueltigBis.Text = "bis";
            this.lblGueltigBis.UseCompatibleTextRendering = true;
            // 
            // edtGueltigBis
            // 
            this.edtGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGueltigBis.DataSource = this.qryIkEinkommen;
            this.edtGueltigBis.EditValue = null;
            this.edtGueltigBis.Location = new System.Drawing.Point(369, 5);
            this.edtGueltigBis.Name = "edtGueltigBis";
            this.edtGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGueltigBis.Properties.Name = "edtFaDokKorreDatum.Properties";
            this.edtGueltigBis.Properties.ShowToday = false;
            this.edtGueltigBis.Size = new System.Drawing.Size(90, 24);
            this.edtGueltigBis.TabIndex = 8;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(30, 160);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(217, 24);
            this.kissLabel1.TabIndex = 21;
            this.kissLabel1.Text = "Zusatzeinnahmen";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtSucheZusatzeinnahmen
            // 
            this.edtSucheZusatzeinnahmen.Location = new System.Drawing.Point(253, 160);
            this.edtSucheZusatzeinnahmen.LOVFilter = "3";
            this.edtSucheZusatzeinnahmen.LOVName = "IkEinkommenTyp";
            this.edtSucheZusatzeinnahmen.Name = "edtSucheZusatzeinnahmen";
            this.edtSucheZusatzeinnahmen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZusatzeinnahmen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZusatzeinnahmen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZusatzeinnahmen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZusatzeinnahmen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZusatzeinnahmen.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZusatzeinnahmen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheZusatzeinnahmen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZusatzeinnahmen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheZusatzeinnahmen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheZusatzeinnahmen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheZusatzeinnahmen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheZusatzeinnahmen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZusatzeinnahmen.Properties.NullText = "";
            this.edtSucheZusatzeinnahmen.Properties.ShowFooter = false;
            this.edtSucheZusatzeinnahmen.Properties.ShowHeader = false;
            this.edtSucheZusatzeinnahmen.Size = new System.Drawing.Size(227, 24);
            this.edtSucheZusatzeinnahmen.TabIndex = 20;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(30, 130);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(217, 24);
            this.kissLabel2.TabIndex = 19;
            this.kissLabel2.Text = "Bedarfsabhängige Sozialleistungen";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtSucheBedarfsabhaengigeSozialleistungen
            // 
            this.edtSucheBedarfsabhaengigeSozialleistungen.Location = new System.Drawing.Point(253, 130);
            this.edtSucheBedarfsabhaengigeSozialleistungen.LOVFilter = "2";
            this.edtSucheBedarfsabhaengigeSozialleistungen.LOVName = "IkEinkommenTyp";
            this.edtSucheBedarfsabhaengigeSozialleistungen.Name = "edtSucheBedarfsabhaengigeSozialleistungen";
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.NullText = "";
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.ShowFooter = false;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Properties.ShowHeader = false;
            this.edtSucheBedarfsabhaengigeSozialleistungen.Size = new System.Drawing.Size(227, 24);
            this.edtSucheBedarfsabhaengigeSozialleistungen.TabIndex = 18;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(30, 100);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(217, 24);
            this.kissLabel3.TabIndex = 17;
            this.kissLabel3.Text = "Einkommen, Taggelder, Versicherungen";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // edtSucheEinkommenTaggelderVersicherungen
            // 
            this.edtSucheEinkommenTaggelderVersicherungen.Location = new System.Drawing.Point(253, 100);
            this.edtSucheEinkommenTaggelderVersicherungen.LOVFilter = "1";
            this.edtSucheEinkommenTaggelderVersicherungen.LOVName = "IkEinkommenTyp";
            this.edtSucheEinkommenTaggelderVersicherungen.Name = "edtSucheEinkommenTaggelderVersicherungen";
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.Appearance.Options.UseFont = true;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.NullText = "";
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.ShowFooter = false;
            this.edtSucheEinkommenTaggelderVersicherungen.Properties.ShowHeader = false;
            this.edtSucheEinkommenTaggelderVersicherungen.Size = new System.Drawing.Size(227, 24);
            this.edtSucheEinkommenTaggelderVersicherungen.TabIndex = 16;
            // 
            // CtlIkEinkommen
            // 
            this.ActiveSQLQuery = this.qryIkEinkommen;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(568, 402);
            this.Controls.Add(this.panelDetail);
            this.Location = new System.Drawing.Point(-370, 380);
            this.MinimumSize = new System.Drawing.Size(568, 402);
            this.Name = "CtlIkEinkommen";
            this.Size = new System.Drawing.Size(642, 563);
            this.Load += new System.EventHandler(this.CtlIkEinkommen_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panelDetail, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkEinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBetrifftPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGueltigAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGueltigAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrifft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrifft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrifft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifft)).EndInit();
            this.panelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzeinnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzeinnahmen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzeinnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBedarfsabhaengigeSozialleistungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBedarfsabhaengigeSozialleistungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBedarfsabhaengigeSozialleistungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinkommenTaggelderVersicherungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinkommenTaggelderVersicherungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinkommenTaggelderVersicherungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZusatzeinnahmen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZusatzeinnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBedarfsabhaengigeSozialleistungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBedarfsabhaengigeSozialleistungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinkommenTaggelderVersicherungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinkommenTaggelderVersicherungen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colPendenzDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzText;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtSucheGueltigBis;
        private KiSS4.Gui.KissDateEdit edtSucheGueltigAb;
        private KiSS4.Gui.KissLookUpEdit edtSucheBetrifft;
        private KiSS4.Gui.KissGrid grdEinkommen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinkommen;
        private KiSS4.Gui.KissLabel lblSucheGueltigAb;
        private KiSS4.Gui.KissLabel lblSucheGueltigBis;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblGueltigAb;
        private KiSS4.Gui.KissLabel lblSucheBetrifft;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private System.Windows.Forms.Panel panelDetail;
        private DB.SqlQuery qryIkEinkommen;
        private Gui.KissLabel lblEinkommenTaggelderVersicherungen;
        private Gui.KissLookUpEdit edtEinkommenTaggelderVersicherungen;
        private Gui.KissLabel lblGueltigBis;
        private Gui.KissDateEdit edtGueltigBis;
        private Gui.KissLabel lblBetrifft;
        private Gui.KissLookUpEdit edtBetrifft;
        private Gui.KissDateEdit edtGueltigAb;
        private Gui.KissLabel lblZusatzeinnahmen;
        private Gui.KissLookUpEdit edtZusatzeinnahmen;
        private Gui.KissLabel lblBedarfsabhaengigeSozialleistungen;
        private Gui.KissLookUpEdit edtBedarfsabhaengigeSozialleistungen;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigAb;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrifft;
        private Gui.KissLabel lblBetrag;
        private DB.SqlQuery qryBetrifftPerson;
        private Gui.KissLabel kissLabel1;
        private Gui.KissLookUpEdit edtSucheZusatzeinnahmen;
        private Gui.KissLabel kissLabel2;
        private Gui.KissLookUpEdit edtSucheBedarfsabhaengigeSozialleistungen;
        private Gui.KissLabel kissLabel3;
        private Gui.KissLookUpEdit edtSucheEinkommenTaggelderVersicherungen;
        private Gui.KissCalcEdit edtBetrag;
    }
}
