namespace KiSS4.Fallfuehrung.PI
{
    partial class CtlMyKiSS
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panUserID = new System.Windows.Forms.Panel();
            this.edtUserID = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.btnApplyUserID = new KiSS4.Gui.KissButton();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.panLine = new System.Windows.Forms.Panel();
            this.grpAbmachungen = new KiSS4.Gui.KissGroupBox();
            this.grdAbmachungen = new KiSS4.Gui.KissGrid();
            this.qryAbmachungen = new KiSS4.DB.SqlQuery(this.components);
            this.grvAbmachungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAbmachungenTermin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbmachungenKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbmachungenStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panAbmachungen = new System.Windows.Forms.Panel();
            this.ctlGotoFallAbmachungen = new KiSS4.Common.CtlGotoFall();
            this.grpZielvereinbarungen = new KiSS4.Gui.KissGroupBox();
            this.grdZielvereinbarungen = new KiSS4.Gui.KissGrid();
            this.qryZielvereinbarungen = new KiSS4.DB.SqlQuery(this.components);
            this.grvZielvereinbarungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZielvereinbarungenKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenRahmenziele = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenFaelligeRZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenSplit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenHandlungsziele = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenFaelligeHZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenSplit2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenMassnahmen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZielvereinbarungenFaelligeMN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panZielvereinbarungen = new System.Windows.Forms.Panel();
            this.ctlGotoFallZielvereinbarungenCM = new KiSS4.Common.CtlGotoFall();
            this.ctlGotoFallZielvereinbarungenSB = new KiSS4.Common.CtlGotoFall();
            this.grpVollmachten = new KiSS4.Gui.KissGroupBox();
            this.grdVollmachten = new KiSS4.Gui.KissGrid();
            this.qryVollmachten = new KiSS4.DB.SqlQuery(this.components);
            this.grvVollmachten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVollmachtenKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVollmachtenFallverlauf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panVollmachten = new System.Windows.Forms.Panel();
            this.ctlGotoFallVollmachtenFV = new KiSS4.Common.CtlGotoFall();
            this.ctlGotoFallVollmachtenP = new KiSS4.Common.CtlGotoFall();
            this.grpGesuchverwaltung = new KiSS4.Gui.KissGroupBox();
            this.grdGesuchverwaltung = new KiSS4.Gui.KissGrid();
            this.qryGesuchverwaltung = new KiSS4.DB.SqlQuery(this.components);
            this.grvGesuchverwaltung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGesuchverwaltungKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungErstellDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungGesuchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungFonds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStatusImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colGesuchverwaltungBetragBewilligt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungBetragBeantragt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungDatumEntscheid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungDatumAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchverwaltungAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panGesuchverwaltung = new System.Windows.Forms.Panel();
            this.ctlGotoFallGesuchverwaltung = new KiSS4.Common.CtlGotoFall();
            this.grpUnerledigteAuflagen = new KiSS4.Gui.KissGroupBox();
            this.grdUnerledigteAuflagen = new KiSS4.Gui.KissGrid();
            this.qryUnerledigteAuflagen = new KiSS4.DB.SqlQuery(this.components);
            this.grvUnerledigteAuflagen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUnerledigteAuflagenKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnerledigteAuflagenGesuchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnerledigteAuflagenFonds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnerledigteAuflagenGegenstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnerledigteAuflagenVerpflichtung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnerledigteAuflagenBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnerledigteAuflagenFrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panUnerledigteAuflagen = new System.Windows.Forms.Panel();
            this.ctlGotoFallUnerledigteAuflagen = new KiSS4.Common.CtlGotoFall();
            this.panUserID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
            this.grpAbmachungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbmachungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbmachungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbmachungen)).BeginInit();
            this.panAbmachungen.SuspendLayout();
            this.grpZielvereinbarungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinbarungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinbarungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZielvereinbarungen)).BeginInit();
            this.panZielvereinbarungen.SuspendLayout();
            this.grpVollmachten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVollmachten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVollmachten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVollmachten)).BeginInit();
            this.panVollmachten.SuspendLayout();
            this.grpGesuchverwaltung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGesuchverwaltung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGesuchverwaltung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGesuchverwaltung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImage)).BeginInit();
            this.panGesuchverwaltung.SuspendLayout();
            this.grpUnerledigteAuflagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnerledigteAuflagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnerledigteAuflagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUnerledigteAuflagen)).BeginInit();
            this.panUnerledigteAuflagen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panUserID
            // 
            this.panUserID.Controls.Add(this.edtUserID);
            this.panUserID.Controls.Add(this.btnApplyUserID);
            this.panUserID.Controls.Add(this.lblUserID);
            this.panUserID.Controls.Add(this.panLine);
            this.panUserID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panUserID.Location = new System.Drawing.Point(0, 746);
            this.panUserID.Name = "panUserID";
            this.panUserID.Size = new System.Drawing.Size(794, 36);
            this.panUserID.TabIndex = 0;
            // 
            // edtUserID
            // 
            this.edtUserID.DataMember = "Mitarbeiter";
            this.edtUserID.DataMemberUserId = "UserID";
            this.edtUserID.IsSearchField = true;
            this.edtUserID.Location = new System.Drawing.Point(62, 6);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.PiMode = true;
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(272, 24);
            this.edtUserID.TabIndex = 2;
            // 
            // btnApplyUserID
            // 
            this.btnApplyUserID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyUserID.IconID = 5014;
            this.btnApplyUserID.Location = new System.Drawing.Point(340, 6);
            this.btnApplyUserID.Name = "btnApplyUserID";
            this.btnApplyUserID.Size = new System.Drawing.Size(24, 24);
            this.btnApplyUserID.TabIndex = 3;
            this.btnApplyUserID.UseCompatibleTextRendering = true;
            this.btnApplyUserID.UseVisualStyleBackColor = false;
            this.btnApplyUserID.Click += new System.EventHandler(this.btnApplyUserID_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(9, 6);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(69, 24);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "Benutzer";
            this.lblUserID.UseCompatibleTextRendering = true;
            // 
            // panLine
            // 
            this.panLine.BackColor = System.Drawing.Color.Black;
            this.panLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLine.Location = new System.Drawing.Point(0, 0);
            this.panLine.Name = "panLine";
            this.panLine.Size = new System.Drawing.Size(794, 1);
            this.panLine.TabIndex = 0;
            // 
            // grpAbmachungen
            // 
            this.grpAbmachungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAbmachungen.Controls.Add(this.grdAbmachungen);
            this.grpAbmachungen.Controls.Add(this.panAbmachungen);
            this.grpAbmachungen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpAbmachungen.Location = new System.Drawing.Point(9, 9);
            this.grpAbmachungen.Name = "grpAbmachungen";
            this.grpAbmachungen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.grpAbmachungen.Size = new System.Drawing.Size(776, 140);
            this.grpAbmachungen.TabIndex = 1;
            this.grpAbmachungen.TabStop = false;
            this.grpAbmachungen.Text = "Nicht erledigte Abmachungen";
            this.grpAbmachungen.UseCompatibleTextRendering = true;
            // 
            // grdAbmachungen
            // 
            this.grdAbmachungen.DataSource = this.qryAbmachungen;
            this.grdAbmachungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdAbmachungen.EmbeddedNavigator.Name = "";
            this.grdAbmachungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAbmachungen.Location = new System.Drawing.Point(3, 17);
            this.grdAbmachungen.MainView = this.grvAbmachungen;
            this.grdAbmachungen.Name = "grdAbmachungen";
            this.grdAbmachungen.Size = new System.Drawing.Size(736, 119);
            this.grdAbmachungen.TabIndex = 0;
            this.grdAbmachungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAbmachungen});
            // 
            // qryAbmachungen
            // 
            this.qryAbmachungen.HostControl = this;
            this.qryAbmachungen.TableName = "FaAbmachungen";
            // 
            // grvAbmachungen
            // 
            this.grvAbmachungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAbmachungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.Empty.Options.UseFont = true;
            this.grvAbmachungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbmachungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAbmachungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAbmachungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbmachungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAbmachungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbmachungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbmachungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAbmachungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbmachungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAbmachungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAbmachungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAbmachungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAbmachungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAbmachungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAbmachungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbmachungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbmachungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.OddRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAbmachungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.Row.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.Row.Options.UseFont = true;
            this.grvAbmachungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbmachungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAbmachungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAbmachungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAbmachungenTermin,
            this.colAbmachungenKlient,
            this.colAbmachungenStichworte});
            this.grvAbmachungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAbmachungen.GridControl = this.grdAbmachungen;
            this.grvAbmachungen.Name = "grvAbmachungen";
            this.grvAbmachungen.OptionsBehavior.Editable = false;
            this.grvAbmachungen.OptionsCustomization.AllowFilter = false;
            this.grvAbmachungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAbmachungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAbmachungen.OptionsNavigation.UseTabKey = false;
            this.grvAbmachungen.OptionsView.ColumnAutoWidth = false;
            this.grvAbmachungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAbmachungen.OptionsView.ShowGroupPanel = false;
            this.grvAbmachungen.OptionsView.ShowIndicator = false;
            this.grvAbmachungen.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvAbmachungen_CustomDrawCell);
            // 
            // colAbmachungenTermin
            // 
            this.colAbmachungenTermin.Caption = "Termin";
            this.colAbmachungenTermin.FieldName = "Termin";
            this.colAbmachungenTermin.Name = "colAbmachungenTermin";
            this.colAbmachungenTermin.Visible = true;
            this.colAbmachungenTermin.VisibleIndex = 0;
            // 
            // colAbmachungenKlient
            // 
            this.colAbmachungenKlient.Caption = "Klient/in";
            this.colAbmachungenKlient.FieldName = "Klient";
            this.colAbmachungenKlient.Name = "colAbmachungenKlient";
            this.colAbmachungenKlient.Visible = true;
            this.colAbmachungenKlient.VisibleIndex = 1;
            this.colAbmachungenKlient.Width = 250;
            // 
            // colAbmachungenStichworte
            // 
            this.colAbmachungenStichworte.Caption = "Stichwort(e)";
            this.colAbmachungenStichworte.FieldName = "Stichworte";
            this.colAbmachungenStichworte.Name = "colAbmachungenStichworte";
            this.colAbmachungenStichworte.Visible = true;
            this.colAbmachungenStichworte.VisibleIndex = 2;
            this.colAbmachungenStichworte.Width = 380;
            // 
            // panAbmachungen
            // 
            this.panAbmachungen.Controls.Add(this.ctlGotoFallAbmachungen);
            this.panAbmachungen.Dock = System.Windows.Forms.DockStyle.Right;
            this.panAbmachungen.Location = new System.Drawing.Point(739, 17);
            this.panAbmachungen.Name = "panAbmachungen";
            this.panAbmachungen.Size = new System.Drawing.Size(34, 119);
            this.panAbmachungen.TabIndex = 1;
            // 
            // ctlGotoFallAbmachungen
            // 
            this.ctlGotoFallAbmachungen.DataMember = "BaPersonID";
            this.ctlGotoFallAbmachungen.DataSource = this.qryAbmachungen;
            this.ctlGotoFallAbmachungen.DisplayModules = "2";
            this.ctlGotoFallAbmachungen.Location = new System.Drawing.Point(4, 0);
            this.ctlGotoFallAbmachungen.Name = "ctlGotoFallAbmachungen";
            this.ctlGotoFallAbmachungen.ShowToolTipsOnIcons = true;
            this.ctlGotoFallAbmachungen.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallAbmachungen.TabIndex = 0;
            // 
            // grpZielvereinbarungen
            // 
            this.grpZielvereinbarungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpZielvereinbarungen.Controls.Add(this.grdZielvereinbarungen);
            this.grpZielvereinbarungen.Controls.Add(this.panZielvereinbarungen);
            this.grpZielvereinbarungen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpZielvereinbarungen.Location = new System.Drawing.Point(9, 155);
            this.grpZielvereinbarungen.Name = "grpZielvereinbarungen";
            this.grpZielvereinbarungen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.grpZielvereinbarungen.Size = new System.Drawing.Size(776, 140);
            this.grpZielvereinbarungen.TabIndex = 2;
            this.grpZielvereinbarungen.TabStop = false;
            this.grpZielvereinbarungen.Text = "Nicht evaluierte Zielvereinbarungen";
            this.grpZielvereinbarungen.UseCompatibleTextRendering = true;
            // 
            // grdZielvereinbarungen
            // 
            this.grdZielvereinbarungen.DataSource = this.qryZielvereinbarungen;
            this.grdZielvereinbarungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdZielvereinbarungen.EmbeddedNavigator.Name = "";
            this.grdZielvereinbarungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZielvereinbarungen.Location = new System.Drawing.Point(3, 17);
            this.grdZielvereinbarungen.MainView = this.grvZielvereinbarungen;
            this.grdZielvereinbarungen.Name = "grdZielvereinbarungen";
            this.grdZielvereinbarungen.Size = new System.Drawing.Size(736, 119);
            this.grdZielvereinbarungen.TabIndex = 0;
            this.grdZielvereinbarungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZielvereinbarungen});
            // 
            // qryZielvereinbarungen
            // 
            this.qryZielvereinbarungen.FillTimeOut = 120;
            this.qryZielvereinbarungen.HostControl = this;
            this.qryZielvereinbarungen.TableName = "BaPerson";
            // 
            // grvZielvereinbarungen
            // 
            this.grvZielvereinbarungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZielvereinbarungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.Empty.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZielvereinbarungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZielvereinbarungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZielvereinbarungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZielvereinbarungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZielvereinbarungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZielvereinbarungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZielvereinbarungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZielvereinbarungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZielvereinbarungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZielvereinbarungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZielvereinbarungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZielvereinbarungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZielvereinbarungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZielvereinbarungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZielvereinbarungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZielvereinbarungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZielvereinbarungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZielvereinbarungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZielvereinbarungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.OddRow.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZielvereinbarungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.Row.Options.UseBackColor = true;
            this.grvZielvereinbarungen.Appearance.Row.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZielvereinbarungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZielvereinbarungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZielvereinbarungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZielvereinbarungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZielvereinbarungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZielvereinbarungenKlient,
            this.colZielvereinbarungenRahmenziele,
            this.colZielvereinbarungenFaelligeRZ,
            this.colZielvereinbarungenSplit1,
            this.colZielvereinbarungenHandlungsziele,
            this.colZielvereinbarungenFaelligeHZ,
            this.colZielvereinbarungenSplit2,
            this.colZielvereinbarungenMassnahmen,
            this.colZielvereinbarungenFaelligeMN});
            this.grvZielvereinbarungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZielvereinbarungen.GridControl = this.grdZielvereinbarungen;
            this.grvZielvereinbarungen.Name = "grvZielvereinbarungen";
            this.grvZielvereinbarungen.OptionsBehavior.Editable = false;
            this.grvZielvereinbarungen.OptionsCustomization.AllowFilter = false;
            this.grvZielvereinbarungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZielvereinbarungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZielvereinbarungen.OptionsNavigation.UseTabKey = false;
            this.grvZielvereinbarungen.OptionsView.ColumnAutoWidth = false;
            this.grvZielvereinbarungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZielvereinbarungen.OptionsView.ShowGroupPanel = false;
            this.grvZielvereinbarungen.OptionsView.ShowIndicator = false;
            // 
            // colZielvereinbarungenKlient
            // 
            this.colZielvereinbarungenKlient.Caption = "Klient/in";
            this.colZielvereinbarungenKlient.FieldName = "Klient";
            this.colZielvereinbarungenKlient.Name = "colZielvereinbarungenKlient";
            this.colZielvereinbarungenKlient.Visible = true;
            this.colZielvereinbarungenKlient.VisibleIndex = 0;
            this.colZielvereinbarungenKlient.Width = 180;
            // 
            // colZielvereinbarungenRahmenziele
            // 
            this.colZielvereinbarungenRahmenziele.Caption = "Rahmenziele";
            this.colZielvereinbarungenRahmenziele.FieldName = "AnzRZ";
            this.colZielvereinbarungenRahmenziele.Name = "colZielvereinbarungenRahmenziele";
            this.colZielvereinbarungenRahmenziele.Visible = true;
            this.colZielvereinbarungenRahmenziele.VisibleIndex = 1;
            this.colZielvereinbarungenRahmenziele.Width = 95;
            // 
            // colZielvereinbarungenFaelligeRZ
            // 
            this.colZielvereinbarungenFaelligeRZ.Caption = "Fällige RZ";
            this.colZielvereinbarungenFaelligeRZ.FieldName = "AnzRZFaellig";
            this.colZielvereinbarungenFaelligeRZ.Name = "colZielvereinbarungenFaelligeRZ";
            this.colZielvereinbarungenFaelligeRZ.Visible = true;
            this.colZielvereinbarungenFaelligeRZ.VisibleIndex = 2;
            this.colZielvereinbarungenFaelligeRZ.Width = 80;
            // 
            // colZielvereinbarungenSplit1
            // 
            this.colZielvereinbarungenSplit1.MinWidth = 10;
            this.colZielvereinbarungenSplit1.Name = "colZielvereinbarungenSplit1";
            this.colZielvereinbarungenSplit1.Visible = true;
            this.colZielvereinbarungenSplit1.VisibleIndex = 3;
            this.colZielvereinbarungenSplit1.Width = 10;
            // 
            // colZielvereinbarungenHandlungsziele
            // 
            this.colZielvereinbarungenHandlungsziele.Caption = "Handlungsziele";
            this.colZielvereinbarungenHandlungsziele.FieldName = "AnzHZ";
            this.colZielvereinbarungenHandlungsziele.Name = "colZielvereinbarungenHandlungsziele";
            this.colZielvereinbarungenHandlungsziele.Visible = true;
            this.colZielvereinbarungenHandlungsziele.VisibleIndex = 4;
            this.colZielvereinbarungenHandlungsziele.Width = 95;
            // 
            // colZielvereinbarungenFaelligeHZ
            // 
            this.colZielvereinbarungenFaelligeHZ.Caption = "Fällige HZ";
            this.colZielvereinbarungenFaelligeHZ.FieldName = "AnzHZFaellig";
            this.colZielvereinbarungenFaelligeHZ.Name = "colZielvereinbarungenFaelligeHZ";
            this.colZielvereinbarungenFaelligeHZ.Visible = true;
            this.colZielvereinbarungenFaelligeHZ.VisibleIndex = 5;
            this.colZielvereinbarungenFaelligeHZ.Width = 80;
            // 
            // colZielvereinbarungenSplit2
            // 
            this.colZielvereinbarungenSplit2.MinWidth = 10;
            this.colZielvereinbarungenSplit2.Name = "colZielvereinbarungenSplit2";
            this.colZielvereinbarungenSplit2.Visible = true;
            this.colZielvereinbarungenSplit2.VisibleIndex = 6;
            this.colZielvereinbarungenSplit2.Width = 10;
            // 
            // colZielvereinbarungenMassnahmen
            // 
            this.colZielvereinbarungenMassnahmen.Caption = "Massnahmen";
            this.colZielvereinbarungenMassnahmen.FieldName = "AnzMN";
            this.colZielvereinbarungenMassnahmen.Name = "colZielvereinbarungenMassnahmen";
            this.colZielvereinbarungenMassnahmen.Visible = true;
            this.colZielvereinbarungenMassnahmen.VisibleIndex = 7;
            this.colZielvereinbarungenMassnahmen.Width = 95;
            // 
            // colZielvereinbarungenFaelligeMN
            // 
            this.colZielvereinbarungenFaelligeMN.Caption = "Fällige MN";
            this.colZielvereinbarungenFaelligeMN.FieldName = "AnzMNFaellig";
            this.colZielvereinbarungenFaelligeMN.Name = "colZielvereinbarungenFaelligeMN";
            this.colZielvereinbarungenFaelligeMN.Visible = true;
            this.colZielvereinbarungenFaelligeMN.VisibleIndex = 8;
            this.colZielvereinbarungenFaelligeMN.Width = 80;
            // 
            // panZielvereinbarungen
            // 
            this.panZielvereinbarungen.Controls.Add(this.ctlGotoFallZielvereinbarungenCM);
            this.panZielvereinbarungen.Controls.Add(this.ctlGotoFallZielvereinbarungenSB);
            this.panZielvereinbarungen.Dock = System.Windows.Forms.DockStyle.Right;
            this.panZielvereinbarungen.Location = new System.Drawing.Point(739, 17);
            this.panZielvereinbarungen.Name = "panZielvereinbarungen";
            this.panZielvereinbarungen.Size = new System.Drawing.Size(34, 119);
            this.panZielvereinbarungen.TabIndex = 1;
            // 
            // ctlGotoFallZielvereinbarungenCM
            // 
            this.ctlGotoFallZielvereinbarungenCM.DataMember = "BaPersonID";
            this.ctlGotoFallZielvereinbarungenCM.DataSource = this.qryZielvereinbarungen;
            this.ctlGotoFallZielvereinbarungenCM.DisplayModules = "4";
            this.ctlGotoFallZielvereinbarungenCM.Location = new System.Drawing.Point(4, 30);
            this.ctlGotoFallZielvereinbarungenCM.Name = "ctlGotoFallZielvereinbarungenCM";
            this.ctlGotoFallZielvereinbarungenCM.ShowToolTipsOnIcons = true;
            this.ctlGotoFallZielvereinbarungenCM.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallZielvereinbarungenCM.TabIndex = 1;
            // 
            // ctlGotoFallZielvereinbarungenSB
            // 
            this.ctlGotoFallZielvereinbarungenSB.DataMember = "BaPersonID";
            this.ctlGotoFallZielvereinbarungenSB.DataSource = this.qryZielvereinbarungen;
            this.ctlGotoFallZielvereinbarungenSB.DisplayModules = "3";
            this.ctlGotoFallZielvereinbarungenSB.Location = new System.Drawing.Point(4, 0);
            this.ctlGotoFallZielvereinbarungenSB.Name = "ctlGotoFallZielvereinbarungenSB";
            this.ctlGotoFallZielvereinbarungenSB.ShowToolTipsOnIcons = true;
            this.ctlGotoFallZielvereinbarungenSB.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallZielvereinbarungenSB.TabIndex = 0;
            // 
            // grpVollmachten
            // 
            this.grpVollmachten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVollmachten.Controls.Add(this.grdVollmachten);
            this.grpVollmachten.Controls.Add(this.panVollmachten);
            this.grpVollmachten.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpVollmachten.Location = new System.Drawing.Point(9, 301);
            this.grpVollmachten.Name = "grpVollmachten";
            this.grpVollmachten.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.grpVollmachten.Size = new System.Drawing.Size(776, 140);
            this.grpVollmachten.TabIndex = 3;
            this.grpVollmachten.TabStop = false;
            this.grpVollmachten.Text = "Laufende Vollmachten";
            this.grpVollmachten.UseCompatibleTextRendering = true;
            // 
            // grdVollmachten
            // 
            this.grdVollmachten.DataSource = this.qryVollmachten;
            this.grdVollmachten.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVollmachten.EmbeddedNavigator.Name = "";
            this.grdVollmachten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVollmachten.Location = new System.Drawing.Point(3, 17);
            this.grdVollmachten.MainView = this.grvVollmachten;
            this.grdVollmachten.Name = "grdVollmachten";
            this.grdVollmachten.Size = new System.Drawing.Size(736, 119);
            this.grdVollmachten.TabIndex = 0;
            this.grdVollmachten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVollmachten});
            // 
            // qryVollmachten
            // 
            this.qryVollmachten.HostControl = this;
            this.qryVollmachten.TableName = "BaPerson";
            // 
            // grvVollmachten
            // 
            this.grvVollmachten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVollmachten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.Empty.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.Empty.Options.UseFont = true;
            this.grvVollmachten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.EvenRow.Options.UseFont = true;
            this.grvVollmachten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVollmachten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVollmachten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVollmachten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVollmachten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVollmachten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVollmachten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVollmachten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVollmachten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVollmachten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVollmachten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVollmachten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVollmachten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.GroupRow.Options.UseFont = true;
            this.grvVollmachten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVollmachten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVollmachten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVollmachten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVollmachten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVollmachten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVollmachten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVollmachten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVollmachten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVollmachten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVollmachten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVollmachten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.OddRow.Options.UseFont = true;
            this.grvVollmachten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVollmachten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.Row.Options.UseBackColor = true;
            this.grvVollmachten.Appearance.Row.Options.UseFont = true;
            this.grvVollmachten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVollmachten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVollmachten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVollmachten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVollmachten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVollmachten.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVollmachtenKlient,
            this.colVollmachtenFallverlauf});
            this.grvVollmachten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVollmachten.GridControl = this.grdVollmachten;
            this.grvVollmachten.Name = "grvVollmachten";
            this.grvVollmachten.OptionsBehavior.Editable = false;
            this.grvVollmachten.OptionsCustomization.AllowFilter = false;
            this.grvVollmachten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVollmachten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVollmachten.OptionsNavigation.UseTabKey = false;
            this.grvVollmachten.OptionsView.ColumnAutoWidth = false;
            this.grvVollmachten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVollmachten.OptionsView.ShowGroupPanel = false;
            this.grvVollmachten.OptionsView.ShowIndicator = false;
            // 
            // colVollmachtenKlient
            // 
            this.colVollmachtenKlient.Caption = "Klient/in";
            this.colVollmachtenKlient.FieldName = "Klient";
            this.colVollmachtenKlient.Name = "colVollmachtenKlient";
            this.colVollmachtenKlient.Visible = true;
            this.colVollmachtenKlient.VisibleIndex = 0;
            this.colVollmachtenKlient.Width = 300;
            // 
            // colVollmachtenFallverlauf
            // 
            this.colVollmachtenFallverlauf.Caption = "Fallverlauf";
            this.colVollmachtenFallverlauf.FieldName = "Fallverlauf";
            this.colVollmachtenFallverlauf.Name = "colVollmachtenFallverlauf";
            this.colVollmachtenFallverlauf.Visible = true;
            this.colVollmachtenFallverlauf.VisibleIndex = 1;
            // 
            // panVollmachten
            // 
            this.panVollmachten.Controls.Add(this.ctlGotoFallVollmachtenFV);
            this.panVollmachten.Controls.Add(this.ctlGotoFallVollmachtenP);
            this.panVollmachten.Dock = System.Windows.Forms.DockStyle.Right;
            this.panVollmachten.Location = new System.Drawing.Point(739, 17);
            this.panVollmachten.Name = "panVollmachten";
            this.panVollmachten.Size = new System.Drawing.Size(34, 119);
            this.panVollmachten.TabIndex = 1;
            // 
            // ctlGotoFallVollmachtenFV
            // 
            this.ctlGotoFallVollmachtenFV.DataMember = "BaPersonID";
            this.ctlGotoFallVollmachtenFV.DataSource = this.qryVollmachten;
            this.ctlGotoFallVollmachtenFV.DisplayModules = "2";
            this.ctlGotoFallVollmachtenFV.Location = new System.Drawing.Point(4, 30);
            this.ctlGotoFallVollmachtenFV.Name = "ctlGotoFallVollmachtenFV";
            this.ctlGotoFallVollmachtenFV.ShowToolTipsOnIcons = true;
            this.ctlGotoFallVollmachtenFV.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallVollmachtenFV.TabIndex = 1;
            // 
            // ctlGotoFallVollmachtenP
            // 
            this.ctlGotoFallVollmachtenP.DataMember = "BaPersonID";
            this.ctlGotoFallVollmachtenP.DataSource = this.qryVollmachten;
            this.ctlGotoFallVollmachtenP.DisplayModules = "1";
            this.ctlGotoFallVollmachtenP.Location = new System.Drawing.Point(4, 0);
            this.ctlGotoFallVollmachtenP.Name = "ctlGotoFallVollmachtenP";
            this.ctlGotoFallVollmachtenP.ShowToolTipsOnIcons = true;
            this.ctlGotoFallVollmachtenP.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallVollmachtenP.TabIndex = 0;
            // 
            // grpGesuchverwaltung
            // 
            this.grpGesuchverwaltung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGesuchverwaltung.Controls.Add(this.grdGesuchverwaltung);
            this.grpGesuchverwaltung.Controls.Add(this.panGesuchverwaltung);
            this.grpGesuchverwaltung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpGesuchverwaltung.Location = new System.Drawing.Point(9, 447);
            this.grpGesuchverwaltung.Name = "grpGesuchverwaltung";
            this.grpGesuchverwaltung.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.grpGesuchverwaltung.Size = new System.Drawing.Size(776, 140);
            this.grpGesuchverwaltung.TabIndex = 4;
            this.grpGesuchverwaltung.TabStop = false;
            this.grpGesuchverwaltung.Text = "Gesuchverwaltung";
            this.grpGesuchverwaltung.UseCompatibleTextRendering = true;
            // 
            // grdGesuchverwaltung
            // 
            this.grdGesuchverwaltung.DataSource = this.qryGesuchverwaltung;
            this.grdGesuchverwaltung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdGesuchverwaltung.EmbeddedNavigator.Name = "";
            this.grdGesuchverwaltung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGesuchverwaltung.Location = new System.Drawing.Point(3, 17);
            this.grdGesuchverwaltung.MainView = this.grvGesuchverwaltung;
            this.grdGesuchverwaltung.Name = "grdGesuchverwaltung";
            this.grdGesuchverwaltung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repStatusImage});
            this.grdGesuchverwaltung.Size = new System.Drawing.Size(736, 119);
            this.grdGesuchverwaltung.TabIndex = 0;
            this.grdGesuchverwaltung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGesuchverwaltung});
            // 
            // qryGesuchverwaltung
            // 
            this.qryGesuchverwaltung.HostControl = this;
            this.qryGesuchverwaltung.TableName = "GvGesuchverwaltung";
            // 
            // grvGesuchverwaltung
            // 
            this.grvGesuchverwaltung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGesuchverwaltung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.Empty.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.Empty.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.EvenRow.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGesuchverwaltung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGesuchverwaltung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGesuchverwaltung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGesuchverwaltung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGesuchverwaltung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGesuchverwaltung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuchverwaltung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuchverwaltung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGesuchverwaltung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGesuchverwaltung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.GroupRow.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGesuchverwaltung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGesuchverwaltung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGesuchverwaltung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGesuchverwaltung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGesuchverwaltung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGesuchverwaltung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGesuchverwaltung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGesuchverwaltung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGesuchverwaltung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.OddRow.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGesuchverwaltung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.Row.Options.UseBackColor = true;
            this.grvGesuchverwaltung.Appearance.Row.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchverwaltung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGesuchverwaltung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGesuchverwaltung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGesuchverwaltung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGesuchverwaltung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGesuchverwaltungKlient,
            this.colGesuchverwaltungErstellDatum,
            this.colGesuchverwaltungGesuchID,
            this.colGesuchverwaltungFonds,
            this.colGesuchverwaltungStatus,
            this.colGesuchverwaltungBetragBewilligt,
            this.colGesuchverwaltungBetragBeantragt,
            this.colGesuchverwaltungDatumEntscheid,
            this.colGesuchverwaltungDatumAuszahlung,
            this.colGesuchverwaltungAutor});
            this.grvGesuchverwaltung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGesuchverwaltung.GridControl = this.grdGesuchverwaltung;
            this.grvGesuchverwaltung.Name = "grvGesuchverwaltung";
            this.grvGesuchverwaltung.OptionsBehavior.Editable = false;
            this.grvGesuchverwaltung.OptionsCustomization.AllowFilter = false;
            this.grvGesuchverwaltung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGesuchverwaltung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGesuchverwaltung.OptionsNavigation.UseTabKey = false;
            this.grvGesuchverwaltung.OptionsView.ColumnAutoWidth = false;
            this.grvGesuchverwaltung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGesuchverwaltung.OptionsView.ShowGroupPanel = false;
            this.grvGesuchverwaltung.OptionsView.ShowIndicator = false;
            // 
            // colGesuchverwaltungKlient
            // 
            this.colGesuchverwaltungKlient.Caption = "Klient/in";
            this.colGesuchverwaltungKlient.FieldName = "Klient";
            this.colGesuchverwaltungKlient.Name = "colGesuchverwaltungKlient";
            this.colGesuchverwaltungKlient.Visible = true;
            this.colGesuchverwaltungKlient.VisibleIndex = 0;
            this.colGesuchverwaltungKlient.Width = 180;
            // 
            // colGesuchverwaltungErstellDatum
            // 
            this.colGesuchverwaltungErstellDatum.Caption = "Erstell-Dat.";
            this.colGesuchverwaltungErstellDatum.FieldName = "GesuchsDatum";
            this.colGesuchverwaltungErstellDatum.Name = "colGesuchverwaltungErstellDatum";
            this.colGesuchverwaltungErstellDatum.Visible = true;
            this.colGesuchverwaltungErstellDatum.VisibleIndex = 1;
            this.colGesuchverwaltungErstellDatum.Width = 95;
            // 
            // colGesuchverwaltungGesuchID
            // 
            this.colGesuchverwaltungGesuchID.Caption = "Gesuchs-ID";
            this.colGesuchverwaltungGesuchID.FieldName = "GvGesuchID";
            this.colGesuchverwaltungGesuchID.Name = "colGesuchverwaltungGesuchID";
            this.colGesuchverwaltungGesuchID.Visible = true;
            this.colGesuchverwaltungGesuchID.VisibleIndex = 2;
            this.colGesuchverwaltungGesuchID.Width = 80;
            // 
            // colGesuchverwaltungFonds
            // 
            this.colGesuchverwaltungFonds.Caption = "Fonds";
            this.colGesuchverwaltungFonds.FieldName = "Fonds";
            this.colGesuchverwaltungFonds.Name = "colGesuchverwaltungFonds";
            this.colGesuchverwaltungFonds.Visible = true;
            this.colGesuchverwaltungFonds.VisibleIndex = 3;
            this.colGesuchverwaltungFonds.Width = 100;
            // 
            // colGesuchverwaltungStatus
            // 
            this.colGesuchverwaltungStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colGesuchverwaltungStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGesuchverwaltungStatus.Caption = "Status";
            this.colGesuchverwaltungStatus.ColumnEdit = this.repStatusImage;
            this.colGesuchverwaltungStatus.FieldName = "GvStatusCode";
            this.colGesuchverwaltungStatus.MinWidth = 10;
            this.colGesuchverwaltungStatus.Name = "colGesuchverwaltungStatus";
            this.colGesuchverwaltungStatus.Visible = true;
            this.colGesuchverwaltungStatus.VisibleIndex = 4;
            this.colGesuchverwaltungStatus.Width = 60;
            // 
            // repStatusImage
            // 
            this.repStatusImage.AutoHeight = false;
            this.repStatusImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatusImage.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repStatusImage.Name = "repStatusImage";
            // 
            // colGesuchverwaltungBetragBewilligt
            // 
            this.colGesuchverwaltungBetragBewilligt.Caption = "Bewill. Betrag";
            this.colGesuchverwaltungBetragBewilligt.DisplayFormat.FormatString = "n2";
            this.colGesuchverwaltungBetragBewilligt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGesuchverwaltungBetragBewilligt.FieldName = "BetragBewilligt";
            this.colGesuchverwaltungBetragBewilligt.Name = "colGesuchverwaltungBetragBewilligt";
            this.colGesuchverwaltungBetragBewilligt.Visible = true;
            this.colGesuchverwaltungBetragBewilligt.VisibleIndex = 5;
            this.colGesuchverwaltungBetragBewilligt.Width = 100;
            // 
            // colGesuchverwaltungBetragBeantragt
            // 
            this.colGesuchverwaltungBetragBeantragt.Caption = "Beantr. Betrag";
            this.colGesuchverwaltungBetragBeantragt.DisplayFormat.FormatString = "n2";
            this.colGesuchverwaltungBetragBeantragt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGesuchverwaltungBetragBeantragt.FieldName = "BetragBeantragt";
            this.colGesuchverwaltungBetragBeantragt.Name = "colGesuchverwaltungBetragBeantragt";
            this.colGesuchverwaltungBetragBeantragt.Visible = true;
            this.colGesuchverwaltungBetragBeantragt.VisibleIndex = 6;
            this.colGesuchverwaltungBetragBeantragt.Width = 100;
            // 
            // colGesuchverwaltungDatumEntscheid
            // 
            this.colGesuchverwaltungDatumEntscheid.Caption = "Entsch.-Dat.";
            this.colGesuchverwaltungDatumEntscheid.FieldName = "DatumEntscheid";
            this.colGesuchverwaltungDatumEntscheid.Name = "colGesuchverwaltungDatumEntscheid";
            this.colGesuchverwaltungDatumEntscheid.Visible = true;
            this.colGesuchverwaltungDatumEntscheid.VisibleIndex = 7;
            this.colGesuchverwaltungDatumEntscheid.Width = 95;
            // 
            // colGesuchverwaltungDatumAuszahlung
            // 
            this.colGesuchverwaltungDatumAuszahlung.Caption = "Ausz.-Dat.";
            this.colGesuchverwaltungDatumAuszahlung.FieldName = "DatumAuszahlung";
            this.colGesuchverwaltungDatumAuszahlung.Name = "colGesuchverwaltungDatumAuszahlung";
            this.colGesuchverwaltungDatumAuszahlung.Visible = true;
            this.colGesuchverwaltungDatumAuszahlung.VisibleIndex = 8;
            this.colGesuchverwaltungDatumAuszahlung.Width = 95;
            // 
            // colGesuchverwaltungAutor
            // 
            this.colGesuchverwaltungAutor.Caption = "Autor";
            this.colGesuchverwaltungAutor.FieldName = "Autor";
            this.colGesuchverwaltungAutor.Name = "colGesuchverwaltungAutor";
            this.colGesuchverwaltungAutor.Visible = true;
            this.colGesuchverwaltungAutor.VisibleIndex = 9;
            this.colGesuchverwaltungAutor.Width = 175;
            // 
            // panGesuchverwaltung
            // 
            this.panGesuchverwaltung.Controls.Add(this.ctlGotoFallGesuchverwaltung);
            this.panGesuchverwaltung.Dock = System.Windows.Forms.DockStyle.Right;
            this.panGesuchverwaltung.Location = new System.Drawing.Point(739, 17);
            this.panGesuchverwaltung.Name = "panGesuchverwaltung";
            this.panGesuchverwaltung.Size = new System.Drawing.Size(34, 119);
            this.panGesuchverwaltung.TabIndex = 1;
            // 
            // ctlGotoFallGesuchverwaltung
            // 
            this.ctlGotoFallGesuchverwaltung.DataMember = "BaPersonID";
            this.ctlGotoFallGesuchverwaltung.DataSource = this.qryGesuchverwaltung;
            this.ctlGotoFallGesuchverwaltung.DisplayModules = "2";
            this.ctlGotoFallGesuchverwaltung.Location = new System.Drawing.Point(4, 0);
            this.ctlGotoFallGesuchverwaltung.Name = "ctlGotoFallGesuchverwaltung";
            this.ctlGotoFallGesuchverwaltung.ShowToolTipsOnIcons = true;
            this.ctlGotoFallGesuchverwaltung.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallGesuchverwaltung.TabIndex = 0;
            // 
            // grpUnerledigteAuflagen
            // 
            this.grpUnerledigteAuflagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUnerledigteAuflagen.Controls.Add(this.grdUnerledigteAuflagen);
            this.grpUnerledigteAuflagen.Controls.Add(this.panUnerledigteAuflagen);
            this.grpUnerledigteAuflagen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpUnerledigteAuflagen.Location = new System.Drawing.Point(6, 593);
            this.grpUnerledigteAuflagen.Name = "grpUnerledigteAuflagen";
            this.grpUnerledigteAuflagen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.grpUnerledigteAuflagen.Size = new System.Drawing.Size(776, 147);
            this.grpUnerledigteAuflagen.TabIndex = 5;
            this.grpUnerledigteAuflagen.TabStop = false;
            this.grpUnerledigteAuflagen.Text = "Unerledigte Auflagen";
            this.grpUnerledigteAuflagen.UseCompatibleTextRendering = true;
            // 
            // grdUnerledigteAuflagen
            // 
            this.grdUnerledigteAuflagen.DataSource = this.qryUnerledigteAuflagen;
            this.grdUnerledigteAuflagen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdUnerledigteAuflagen.EmbeddedNavigator.Name = "";
            this.grdUnerledigteAuflagen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUnerledigteAuflagen.Location = new System.Drawing.Point(3, 17);
            this.grdUnerledigteAuflagen.MainView = this.grvUnerledigteAuflagen;
            this.grdUnerledigteAuflagen.Name = "grdUnerledigteAuflagen";
            this.grdUnerledigteAuflagen.Size = new System.Drawing.Size(736, 126);
            this.grdUnerledigteAuflagen.TabIndex = 0;
            this.grdUnerledigteAuflagen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUnerledigteAuflagen});
            // 
            // qryUnerledigteAuflagen
            // 
            this.qryUnerledigteAuflagen.HostControl = this;
            this.qryUnerledigteAuflagen.TableName = "GvGesuchverwaltung";
            // 
            // grvUnerledigteAuflagen
            // 
            this.grvUnerledigteAuflagen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUnerledigteAuflagen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.Empty.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.Empty.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.EvenRow.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUnerledigteAuflagen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvUnerledigteAuflagen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUnerledigteAuflagen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUnerledigteAuflagen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvUnerledigteAuflagen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUnerledigteAuflagen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUnerledigteAuflagen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUnerledigteAuflagen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUnerledigteAuflagen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUnerledigteAuflagen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.GroupRow.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUnerledigteAuflagen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUnerledigteAuflagen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUnerledigteAuflagen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUnerledigteAuflagen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUnerledigteAuflagen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvUnerledigteAuflagen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUnerledigteAuflagen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUnerledigteAuflagen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvUnerledigteAuflagen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.OddRow.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvUnerledigteAuflagen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.Row.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.Appearance.Row.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUnerledigteAuflagen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUnerledigteAuflagen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvUnerledigteAuflagen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUnerledigteAuflagen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUnerledigteAuflagen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUnerledigteAuflagenKlient,
            this.colUnerledigteAuflagenGesuchID,
            this.colUnerledigteAuflagenFonds,
            this.colUnerledigteAuflagenGegenstand,
            this.colUnerledigteAuflagenVerpflichtung,
            this.colUnerledigteAuflagenBetrag,
            this.colUnerledigteAuflagenFrist});
            this.grvUnerledigteAuflagen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUnerledigteAuflagen.GridControl = this.grdUnerledigteAuflagen;
            this.grvUnerledigteAuflagen.Name = "grvUnerledigteAuflagen";
            this.grvUnerledigteAuflagen.OptionsBehavior.Editable = false;
            this.grvUnerledigteAuflagen.OptionsCustomization.AllowFilter = false;
            this.grvUnerledigteAuflagen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUnerledigteAuflagen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUnerledigteAuflagen.OptionsNavigation.UseTabKey = false;
            this.grvUnerledigteAuflagen.OptionsView.ColumnAutoWidth = false;
            this.grvUnerledigteAuflagen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUnerledigteAuflagen.OptionsView.ShowGroupPanel = false;
            this.grvUnerledigteAuflagen.OptionsView.ShowIndicator = false;
            this.grvUnerledigteAuflagen.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvUnerledigteAuflagen_CustomDrawCell);
            // 
            // colUnerledigteAuflagenKlient
            // 
            this.colUnerledigteAuflagenKlient.Caption = "Klient/in";
            this.colUnerledigteAuflagenKlient.FieldName = "Klient";
            this.colUnerledigteAuflagenKlient.Name = "colUnerledigteAuflagenKlient";
            this.colUnerledigteAuflagenKlient.Visible = true;
            this.colUnerledigteAuflagenKlient.VisibleIndex = 0;
            this.colUnerledigteAuflagenKlient.Width = 180;
            // 
            // colUnerledigteAuflagenGesuchID
            // 
            this.colUnerledigteAuflagenGesuchID.Caption = "Gesuchs-ID";
            this.colUnerledigteAuflagenGesuchID.FieldName = "GvGesuchID";
            this.colUnerledigteAuflagenGesuchID.Name = "colUnerledigteAuflagenGesuchID";
            this.colUnerledigteAuflagenGesuchID.Visible = true;
            this.colUnerledigteAuflagenGesuchID.VisibleIndex = 1;
            this.colUnerledigteAuflagenGesuchID.Width = 80;
            // 
            // colUnerledigteAuflagenFonds
            // 
            this.colUnerledigteAuflagenFonds.Caption = "Fonds";
            this.colUnerledigteAuflagenFonds.FieldName = "Fonds";
            this.colUnerledigteAuflagenFonds.Name = "colUnerledigteAuflagenFonds";
            this.colUnerledigteAuflagenFonds.Visible = true;
            this.colUnerledigteAuflagenFonds.VisibleIndex = 2;
            this.colUnerledigteAuflagenFonds.Width = 100;
            // 
            // colUnerledigteAuflagenGegenstand
            // 
            this.colUnerledigteAuflagenGegenstand.Caption = "Gegenstand / Abmachung";
            this.colUnerledigteAuflagenGegenstand.FieldName = "Gegenstand";
            this.colUnerledigteAuflagenGegenstand.Name = "colUnerledigteAuflagenGegenstand";
            this.colUnerledigteAuflagenGegenstand.Visible = true;
            this.colUnerledigteAuflagenGegenstand.VisibleIndex = 3;
            this.colUnerledigteAuflagenGegenstand.Width = 100;
            // 
            // colUnerledigteAuflagenVerpflichtung
            // 
            this.colUnerledigteAuflagenVerpflichtung.Caption = "Schriftl. Verpfl.";
            this.colUnerledigteAuflagenVerpflichtung.DisplayFormat.FormatString = "n2";
            this.colUnerledigteAuflagenVerpflichtung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnerledigteAuflagenVerpflichtung.FieldName = "Verpflichtung";
            this.colUnerledigteAuflagenVerpflichtung.Name = "colUnerledigteAuflagenVerpflichtung";
            this.colUnerledigteAuflagenVerpflichtung.Visible = true;
            this.colUnerledigteAuflagenVerpflichtung.VisibleIndex = 4;
            this.colUnerledigteAuflagenVerpflichtung.Width = 100;
            // 
            // colUnerledigteAuflagenBetrag
            // 
            this.colUnerledigteAuflagenBetrag.Caption = "Betrag";
            this.colUnerledigteAuflagenBetrag.DisplayFormat.FormatString = "n2";
            this.colUnerledigteAuflagenBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnerledigteAuflagenBetrag.FieldName = "Betrag";
            this.colUnerledigteAuflagenBetrag.Name = "colUnerledigteAuflagenBetrag";
            this.colUnerledigteAuflagenBetrag.Visible = true;
            this.colUnerledigteAuflagenBetrag.VisibleIndex = 5;
            this.colUnerledigteAuflagenBetrag.Width = 100;
            // 
            // colUnerledigteAuflagenFrist
            // 
            this.colUnerledigteAuflagenFrist.Caption = "Frist bis";
            this.colUnerledigteAuflagenFrist.FieldName = "Frist";
            this.colUnerledigteAuflagenFrist.Name = "colUnerledigteAuflagenFrist";
            this.colUnerledigteAuflagenFrist.Visible = true;
            this.colUnerledigteAuflagenFrist.VisibleIndex = 6;
            this.colUnerledigteAuflagenFrist.Width = 95;
            // 
            // panUnerledigteAuflagen
            // 
            this.panUnerledigteAuflagen.Controls.Add(this.ctlGotoFallUnerledigteAuflagen);
            this.panUnerledigteAuflagen.Dock = System.Windows.Forms.DockStyle.Right;
            this.panUnerledigteAuflagen.Location = new System.Drawing.Point(739, 17);
            this.panUnerledigteAuflagen.Name = "panUnerledigteAuflagen";
            this.panUnerledigteAuflagen.Size = new System.Drawing.Size(34, 126);
            this.panUnerledigteAuflagen.TabIndex = 1;
            // 
            // ctlGotoFallUnerledigteAuflagen
            // 
            this.ctlGotoFallUnerledigteAuflagen.DataMember = "BaPersonID";
            this.ctlGotoFallUnerledigteAuflagen.DataSource = this.qryUnerledigteAuflagen;
            this.ctlGotoFallUnerledigteAuflagen.DisplayModules = "2";
            this.ctlGotoFallUnerledigteAuflagen.Location = new System.Drawing.Point(4, 0);
            this.ctlGotoFallUnerledigteAuflagen.Name = "ctlGotoFallUnerledigteAuflagen";
            this.ctlGotoFallUnerledigteAuflagen.ShowToolTipsOnIcons = true;
            this.ctlGotoFallUnerledigteAuflagen.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallUnerledigteAuflagen.TabIndex = 0;
            // 
            // CtlMyKiSS
            // 
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(400, 740);
            this.ClientSize = new System.Drawing.Size(794, 782);
            this.Controls.Add(this.grpUnerledigteAuflagen);
            this.Controls.Add(this.grpGesuchverwaltung);
            this.Controls.Add(this.grpVollmachten);
            this.Controls.Add(this.grpZielvereinbarungen);
            this.Controls.Add(this.grpAbmachungen);
            this.Controls.Add(this.panUserID);
            this.Name = "CtlMyKiSS";
            this.Text = "My KiSS";
            this.panUserID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            this.grpAbmachungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAbmachungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbmachungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbmachungen)).EndInit();
            this.panAbmachungen.ResumeLayout(false);
            this.grpZielvereinbarungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinbarungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinbarungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZielvereinbarungen)).EndInit();
            this.panZielvereinbarungen.ResumeLayout(false);
            this.grpVollmachten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVollmachten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVollmachten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVollmachten)).EndInit();
            this.panVollmachten.ResumeLayout(false);
            this.grpGesuchverwaltung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGesuchverwaltung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGesuchverwaltung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGesuchverwaltung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImage)).EndInit();
            this.panGesuchverwaltung.ResumeLayout(false);
            this.grpUnerledigteAuflagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnerledigteAuflagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnerledigteAuflagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUnerledigteAuflagen)).EndInit();
            this.panUnerledigteAuflagen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissButton btnApplyUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colAbmachungenKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colAbmachungenStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colAbmachungenTermin;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungErstellDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungBetragBewilligt;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungFonds;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungGesuchID;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungBetragBeantragt;
        private DevExpress.XtraGrid.Columns.GridColumn colVollmachtenFallverlauf;
        private DevExpress.XtraGrid.Columns.GridColumn colVollmachtenKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenFaelligeHZ;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenFaelligeMN;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenFaelligeRZ;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenHandlungsziele;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenMassnahmen;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenRahmenziele;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenSplit1;
        private DevExpress.XtraGrid.Columns.GridColumn colZielvereinbarungenSplit2;
        private KiSS4.Common.CtlGotoFall ctlGotoFallAbmachungen;
        private KiSS4.Common.CtlGotoFall ctlGotoFallGesuchverwaltung;
        private KiSS4.Common.CtlGotoFall ctlGotoFallVollmachtenFV;
        private KiSS4.Common.CtlGotoFall ctlGotoFallVollmachtenP;
        private KiSS4.Common.CtlGotoFall ctlGotoFallZielvereinbarungenCM;
        private KiSS4.Common.CtlGotoFall ctlGotoFallZielvereinbarungenSB;
        private KiSS4.Gui.KissGrid grdAbmachungen;
        private KiSS4.Gui.KissGrid grdGesuchverwaltung;
        private KiSS4.Gui.KissGrid grdVollmachten;
        private KiSS4.Gui.KissGrid grdZielvereinbarungen;
        private KiSS4.Gui.KissGroupBox grpAbmachungen;
        private KiSS4.Gui.KissGroupBox grpGesuchverwaltung;
        private KiSS4.Gui.KissGroupBox grpVollmachten;
        private KiSS4.Gui.KissGroupBox grpZielvereinbarungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbmachungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGesuchverwaltung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVollmachten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZielvereinbarungen;
        private KiSS4.Gui.KissLabel lblUserID;
        private System.Windows.Forms.Panel panAbmachungen;
        private System.Windows.Forms.Panel panGesuchverwaltung;
        private System.Windows.Forms.Panel panLine;
        private System.Windows.Forms.Panel panUserID;
        private System.Windows.Forms.Panel panVollmachten;
        private System.Windows.Forms.Panel panZielvereinbarungen;
        private KiSS4.DB.SqlQuery qryAbmachungen;
        private KiSS4.DB.SqlQuery qryGesuchverwaltung;
        private KiSS4.DB.SqlQuery qryVollmachten;
        private Common.KissMitarbeiterButtonEdit edtUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungDatumEntscheid;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungDatumAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchverwaltungAutor;
        private KiSS4.Gui.KissGroupBox grpUnerledigteAuflagen;
        private KiSS4.Gui.KissGrid grdUnerledigteAuflagen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUnerledigteAuflagen;
        private DevExpress.XtraGrid.Columns.GridColumn colUnerledigteAuflagenKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colUnerledigteAuflagenGesuchID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnerledigteAuflagenFonds;
        private DevExpress.XtraGrid.Columns.GridColumn colUnerledigteAuflagenGegenstand;
        private DevExpress.XtraGrid.Columns.GridColumn colUnerledigteAuflagenVerpflichtung;
        private DevExpress.XtraGrid.Columns.GridColumn colUnerledigteAuflagenBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colUnerledigteAuflagenFrist;
        private System.Windows.Forms.Panel panUnerledigteAuflagen;
        private Common.CtlGotoFall ctlGotoFallUnerledigteAuflagen;
        private KiSS4.DB.SqlQuery qryUnerledigteAuflagen;
        private KiSS4.DB.SqlQuery qryZielvereinbarungen;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repStatusImage;
    }
}
