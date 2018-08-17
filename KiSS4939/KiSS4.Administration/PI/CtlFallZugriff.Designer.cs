namespace KiSS4.Administration.PI
{
    partial class CtlFallZugriff
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFallZugriff));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTop = new System.Windows.Forms.Panel();
            this.lblGewaehlteZeilen = new KiSS4.Gui.KissLabel();
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.grdFaLeistung = new KiSS4.Gui.KissGrid();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.grvFaLeistung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAuswahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colProzess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKuerzel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheAbteilung = new KiSS4.Gui.KissLabel();
            this.edtSucheAbteilung = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheKlient = new KiSS4.Gui.KissLabel();
            this.edtSucheKlient = new KiSS4.Gui.KissTextEdit();
            this.lblSucheProzess = new KiSS4.Gui.KissLabel();
            this.edtSucheProzess = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMA = new KiSS4.Gui.KissLabel();
            this.edtSucheMA = new KiSS4.Gui.KissTextEdit();
            this.lblSucheMAKuerzel = new KiSS4.Gui.KissLabel();
            this.edtSucheMAKuerzel = new KiSS4.Gui.KissTextEdit();
            this.edtSucheNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMutieren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.edtOwnerMA = new KiSS4.Gui.KissTextEdit();
            this.btnSetOwner = new KiSS4.Gui.KissButton();
            this.lblMABesitzrecht = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ttpFallZugriff = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProzess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMAKuerzel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMAKuerzel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).BeginInit();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOwnerMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMABesitzrecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(726, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(750, 324);
            this.tabControlSearch.TabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdFaLeistung);
            this.tpgListe.Controls.Add(this.panTop);
            this.tpgListe.Size = new System.Drawing.Size(738, 286);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheNurAktive);
            this.tpgSuchen.Controls.Add(this.edtSucheMAKuerzel);
            this.tpgSuchen.Controls.Add(this.lblSucheMAKuerzel);
            this.tpgSuchen.Controls.Add(this.edtSucheMA);
            this.tpgSuchen.Controls.Add(this.lblSucheMA);
            this.tpgSuchen.Controls.Add(this.edtSucheProzess);
            this.tpgSuchen.Controls.Add(this.lblSucheProzess);
            this.tpgSuchen.Controls.Add(this.edtSucheKlient);
            this.tpgSuchen.Controls.Add(this.lblSucheKlient);
            this.tpgSuchen.Controls.Add(this.edtSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.lblSucheAbteilung);
            this.tpgSuchen.Size = new System.Drawing.Size(738, 286);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheProzess, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheProzess, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMAKuerzel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMAKuerzel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNurAktive, 0);
            //
            // panTop
            //
            this.panTop.Controls.Add(this.lblGewaehlteZeilen);
            this.panTop.Controls.Add(this.btnSelectNone);
            this.panTop.Controls.Add(this.btnSelectAll);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(738, 32);
            this.panTop.TabIndex = 0;
            //
            // lblGewaehlteZeilen
            //
            this.lblGewaehlteZeilen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGewaehlteZeilen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGewaehlteZeilen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGewaehlteZeilen.Location = new System.Drawing.Point(489, 4);
            this.lblGewaehlteZeilen.Name = "lblGewaehlteZeilen";
            this.lblGewaehlteZeilen.Size = new System.Drawing.Size(240, 24);
            this.lblGewaehlteZeilen.TabIndex = 2;
            this.lblGewaehlteZeilen.Text = "Ausgewählte Zeilen: <Anzahl>";
            this.lblGewaehlteZeilen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGewaehlteZeilen.UseCompatibleTextRendering = true;
            //
            // btnSelectNone
            //
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.Location = new System.Drawing.Point(37, 4);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 1;
            this.btnSelectNone.UseCompatibleTextRendering = true;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            //
            // btnSelectAll
            //
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(7, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            //
            // grdFaLeistung
            //
            this.grdFaLeistung.DataSource = this.qryFaLeistung;
            this.grdFaLeistung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFaLeistung.EmbeddedNavigator.Name = "";
            this.grdFaLeistung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdFaLeistung.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdFaLeistung.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFaLeistung.Location = new System.Drawing.Point(0, 32);
            this.grdFaLeistung.MainView = this.grvFaLeistung;
            this.grdFaLeistung.Name = "grdFaLeistung";
            this.grdFaLeistung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemIcon});
            this.grdFaLeistung.Size = new System.Drawing.Size(738, 254);
            this.grdFaLeistung.TabIndex = 1;
            this.grdFaLeistung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaLeistung});
            //
            // qryFaLeistung
            //
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            this.qryFaLeistung.PositionChanged += new System.EventHandler(this.qryFaLeistung_PositionChanged);
            this.qryFaLeistung.AfterFill += new System.EventHandler(this.qryFaLeistung_AfterFill);
            //
            // grvFaLeistung
            //
            this.grvFaLeistung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaLeistung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Empty.Options.UseFont = true;
            this.grvFaLeistung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFaLeistung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFaLeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.OddRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Row.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Row.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFaLeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaLeistung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaLeistung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuswahl,
            this.colKlient,
            this.colIcon,
            this.colProzess,
            this.colAbteilung,
            this.colMA,
            this.colMAKuerzel,
            this.colDatumVon,
            this.colDatumBis});
            this.grvFaLeistung.GridControl = this.grdFaLeistung;
            this.grvFaLeistung.Name = "grvFaLeistung";
            this.grvFaLeistung.OptionsCustomization.AllowFilter = false;
            this.grvFaLeistung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaLeistung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaLeistung.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvFaLeistung.OptionsView.ColumnAutoWidth = false;
            this.grvFaLeistung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaLeistung.OptionsView.ShowGroupPanel = false;
            this.grvFaLeistung.LostFocus += new System.EventHandler(this.grvFaLeistung_LostFocus);
            //
            // colAuswahl
            //
            this.colAuswahl.Caption = "Auswahl";
            this.colAuswahl.FieldName = "Auswahl";
            this.colAuswahl.Name = "colAuswahl";
            this.colAuswahl.Visible = true;
            this.colAuswahl.VisibleIndex = 0;
            this.colAuswahl.Width = 60;
            //
            // colKlient
            //
            this.colKlient.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKlient.AppearanceCell.Options.UseBackColor = true;
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.AllowFocus = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 1;
            this.colKlient.Width = 200;
            //
            // colIcon
            //
            this.colIcon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIcon.AppearanceCell.Options.UseBackColor = true;
            this.colIcon.ColumnEdit = this.repItemIcon;
            this.colIcon.FieldName = "Icon";
            this.colIcon.Name = "colIcon";
            this.colIcon.OptionsColumn.AllowEdit = false;
            this.colIcon.OptionsColumn.AllowFocus = false;
            this.colIcon.Visible = true;
            this.colIcon.VisibleIndex = 2;
            this.colIcon.Width = 22;
            //
            // repItemIcon
            //
            this.repItemIcon.CustomHeight = 16;
            this.repItemIcon.Name = "repItemIcon";
            this.repItemIcon.NullText = "No Image";
            this.repItemIcon.ReadOnly = true;
            //
            // colProzess
            //
            this.colProzess.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colProzess.AppearanceCell.Options.UseBackColor = true;
            this.colProzess.Caption = "Prozess";
            this.colProzess.FieldName = "Prozess";
            this.colProzess.Name = "colProzess";
            this.colProzess.OptionsColumn.AllowEdit = false;
            this.colProzess.OptionsColumn.AllowFocus = false;
            this.colProzess.Visible = true;
            this.colProzess.VisibleIndex = 3;
            this.colProzess.Width = 120;
            //
            // colAbteilung
            //
            this.colAbteilung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAbteilung.AppearanceCell.Options.UseBackColor = true;
            this.colAbteilung.Caption = "Abteilung";
            this.colAbteilung.FieldName = "Abteilung";
            this.colAbteilung.Name = "colAbteilung";
            this.colAbteilung.OptionsColumn.AllowEdit = false;
            this.colAbteilung.OptionsColumn.AllowFocus = false;
            this.colAbteilung.Visible = true;
            this.colAbteilung.VisibleIndex = 4;
            this.colAbteilung.Width = 120;
            //
            // colMA
            //
            this.colMA.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMA.AppearanceCell.Options.UseBackColor = true;
            this.colMA.Caption = "MA";
            this.colMA.FieldName = "MA";
            this.colMA.Name = "colMA";
            this.colMA.OptionsColumn.AllowEdit = false;
            this.colMA.OptionsColumn.AllowFocus = false;
            this.colMA.Visible = true;
            this.colMA.VisibleIndex = 5;
            this.colMA.Width = 150;
            //
            // colMAKuerzel
            //
            this.colMAKuerzel.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMAKuerzel.AppearanceCell.Options.UseBackColor = true;
            this.colMAKuerzel.Caption = "Kürzel";
            this.colMAKuerzel.FieldName = "MAKuerzel";
            this.colMAKuerzel.Name = "colMAKuerzel";
            this.colMAKuerzel.OptionsColumn.AllowEdit = false;
            this.colMAKuerzel.OptionsColumn.AllowFocus = false;
            this.colMAKuerzel.Visible = true;
            this.colMAKuerzel.VisibleIndex = 6;
            this.colMAKuerzel.Width = 65;
            //
            // colDatumVon
            //
            this.colDatumVon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatumVon.AppearanceCell.Options.UseBackColor = true;
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.OptionsColumn.AllowEdit = false;
            this.colDatumVon.OptionsColumn.AllowFocus = false;
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 7;
            this.colDatumVon.Width = 80;
            //
            // colDatumBis
            //
            this.colDatumBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatumBis.AppearanceCell.Options.UseBackColor = true;
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.OptionsColumn.AllowEdit = false;
            this.colDatumBis.OptionsColumn.AllowFocus = false;
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 8;
            this.colDatumBis.Width = 80;
            //
            // lblSucheAbteilung
            //
            this.lblSucheAbteilung.Location = new System.Drawing.Point(31, 40);
            this.lblSucheAbteilung.Name = "lblSucheAbteilung";
            this.lblSucheAbteilung.Size = new System.Drawing.Size(97, 24);
            this.lblSucheAbteilung.TabIndex = 1;
            this.lblSucheAbteilung.Text = "Abteilung";
            this.lblSucheAbteilung.UseCompatibleTextRendering = true;
            //
            // edtSucheAbteilung
            //
            this.edtSucheAbteilung.Location = new System.Drawing.Point(134, 40);
            this.edtSucheAbteilung.Name = "edtSucheAbteilung";
            this.edtSucheAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbteilung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAbteilung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbteilung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheAbteilung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAbteilung.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheAbteilung.Properties.DisplayMember = "Text";
            this.edtSucheAbteilung.Properties.NullText = "";
            this.edtSucheAbteilung.Properties.ShowFooter = false;
            this.edtSucheAbteilung.Properties.ShowHeader = false;
            this.edtSucheAbteilung.Properties.ValueMember = "Code";
            this.edtSucheAbteilung.Size = new System.Drawing.Size(239, 24);
            this.edtSucheAbteilung.TabIndex = 2;
            //
            // lblSucheKlient
            //
            this.lblSucheKlient.Location = new System.Drawing.Point(31, 70);
            this.lblSucheKlient.Name = "lblSucheKlient";
            this.lblSucheKlient.Size = new System.Drawing.Size(97, 24);
            this.lblSucheKlient.TabIndex = 3;
            this.lblSucheKlient.Text = "Klient/in";
            this.lblSucheKlient.UseCompatibleTextRendering = true;
            //
            // edtSucheKlient
            //
            this.edtSucheKlient.Location = new System.Drawing.Point(134, 70);
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheKlient.Size = new System.Drawing.Size(239, 24);
            this.edtSucheKlient.TabIndex = 4;
            //
            // lblSucheProzess
            //
            this.lblSucheProzess.Location = new System.Drawing.Point(31, 100);
            this.lblSucheProzess.Name = "lblSucheProzess";
            this.lblSucheProzess.Size = new System.Drawing.Size(97, 24);
            this.lblSucheProzess.TabIndex = 5;
            this.lblSucheProzess.Text = "Prozess";
            this.lblSucheProzess.UseCompatibleTextRendering = true;
            //
            // edtSucheProzess
            //
            this.edtSucheProzess.Location = new System.Drawing.Point(134, 100);
            this.edtSucheProzess.Name = "edtSucheProzess";
            this.edtSucheProzess.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheProzess.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheProzess.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheProzess.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheProzess.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheProzess.Properties.Appearance.Options.UseFont = true;
            this.edtSucheProzess.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheProzess.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheProzess.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheProzess.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheProzess.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheProzess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheProzess.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheProzess.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheProzess.Properties.DisplayMember = "Text";
            this.edtSucheProzess.Properties.NullText = "";
            this.edtSucheProzess.Properties.ShowFooter = false;
            this.edtSucheProzess.Properties.ShowHeader = false;
            this.edtSucheProzess.Properties.ValueMember = "Code";
            this.edtSucheProzess.Size = new System.Drawing.Size(239, 24);
            this.edtSucheProzess.TabIndex = 6;
            //
            // lblSucheMA
            //
            this.lblSucheMA.Location = new System.Drawing.Point(31, 130);
            this.lblSucheMA.Name = "lblSucheMA";
            this.lblSucheMA.Size = new System.Drawing.Size(97, 24);
            this.lblSucheMA.TabIndex = 7;
            this.lblSucheMA.Text = "MA";
            this.lblSucheMA.UseCompatibleTextRendering = true;
            //
            // edtSucheMA
            //
            this.edtSucheMA.Location = new System.Drawing.Point(134, 130);
            this.edtSucheMA.Name = "edtSucheMA";
            this.edtSucheMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMA.Size = new System.Drawing.Size(239, 24);
            this.edtSucheMA.TabIndex = 8;
            //
            // lblSucheMAKuerzel
            //
            this.lblSucheMAKuerzel.Location = new System.Drawing.Point(31, 160);
            this.lblSucheMAKuerzel.Name = "lblSucheMAKuerzel";
            this.lblSucheMAKuerzel.Size = new System.Drawing.Size(97, 24);
            this.lblSucheMAKuerzel.TabIndex = 9;
            this.lblSucheMAKuerzel.Text = "MA Kürzel";
            this.lblSucheMAKuerzel.UseCompatibleTextRendering = true;
            //
            // edtSucheMAKuerzel
            //
            this.edtSucheMAKuerzel.Location = new System.Drawing.Point(134, 160);
            this.edtSucheMAKuerzel.Name = "edtSucheMAKuerzel";
            this.edtSucheMAKuerzel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMAKuerzel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMAKuerzel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMAKuerzel.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMAKuerzel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMAKuerzel.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMAKuerzel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMAKuerzel.Size = new System.Drawing.Size(107, 24);
            this.edtSucheMAKuerzel.TabIndex = 10;
            //
            // edtSucheNurAktive
            //
            this.edtSucheNurAktive.EditValue = false;
            this.edtSucheNurAktive.Location = new System.Drawing.Point(134, 190);
            this.edtSucheNurAktive.Name = "edtSucheNurAktive";
            this.edtSucheNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSucheNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNurAktive.Properties.Caption = "nur aktive Prozesse";
            this.edtSucheNurAktive.Size = new System.Drawing.Size(239, 19);
            this.edtSucheNurAktive.TabIndex = 11;
            //
            // panBottom
            //
            this.panBottom.Controls.Add(this.btnRemoveAll);
            this.panBottom.Controls.Add(this.btnRemove);
            this.panBottom.Controls.Add(this.grdZugeteilt);
            this.panBottom.Controls.Add(this.btnAdd);
            this.panBottom.Controls.Add(this.edtOwnerMA);
            this.panBottom.Controls.Add(this.btnSetOwner);
            this.panBottom.Controls.Add(this.lblMABesitzrecht);
            this.panBottom.Controls.Add(this.edtFilter);
            this.panBottom.Controls.Add(this.lblFilter);
            this.panBottom.Controls.Add(this.grdVerfuegbar);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 324);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(750, 226);
            this.panBottom.TabIndex = 2;
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(403, 151);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 9;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // btnRemove
            //
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(403, 121);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // grdZugeteilt
            //
            this.grdZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdZugeteilt.Location = new System.Drawing.Point(444, 68);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(299, 152);
            this.grdZugeteilt.TabIndex = 7;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            //
            // qryZugeteilt
            //
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.DeleteQuestion = null;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "FaLeistungZugriff";
            this.qryZugeteilt.BeforePost += new System.EventHandler(this.qryZugeteilt_BeforePost);
            this.qryZugeteilt.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryZugeteilt_ColumnChanged);
            //
            // grvZugeteilt
            //
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser,
            this.colMutieren});
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            //
            // colUser
            //
            this.colUser.Caption = "MA mit Gastrecht";
            this.colUser.FieldName = "UserName";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 185;
            //
            // colMutieren
            //
            this.colMutieren.Caption = "Mutieren";
            this.colMutieren.FieldName = "DarfMutieren";
            this.colMutieren.Name = "colMutieren";
            this.colMutieren.Visible = true;
            this.colMutieren.VisibleIndex = 1;
            this.colMutieren.Width = 65;
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(403, 91);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // edtOwnerMA
            //
            this.edtOwnerMA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOwnerMA.DataMember = "MA";
            this.edtOwnerMA.DataSource = this.qryFaLeistung;
            this.edtOwnerMA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOwnerMA.Location = new System.Drawing.Point(444, 31);
            this.edtOwnerMA.Name = "edtOwnerMA";
            this.edtOwnerMA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOwnerMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOwnerMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOwnerMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtOwnerMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOwnerMA.Properties.Appearance.Options.UseFont = true;
            this.edtOwnerMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOwnerMA.Properties.ReadOnly = true;
            this.edtOwnerMA.Size = new System.Drawing.Size(299, 24);
            this.edtOwnerMA.TabIndex = 5;
            //
            // btnSetOwner
            //
            this.btnSetOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOwner.IconID = 13;
            this.btnSetOwner.Location = new System.Drawing.Point(403, 31);
            this.btnSetOwner.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnSetOwner.Name = "btnSetOwner";
            this.btnSetOwner.Size = new System.Drawing.Size(28, 24);
            this.btnSetOwner.TabIndex = 4;
            this.btnSetOwner.UseCompatibleTextRendering = true;
            this.btnSetOwner.UseVisualStyleBackColor = false;
            this.btnSetOwner.Click += new System.EventHandler(this.btnSetOwner_Click);
            //
            // lblMABesitzrecht
            //
            this.lblMABesitzrecht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMABesitzrecht.Location = new System.Drawing.Point(444, 4);
            this.lblMABesitzrecht.Name = "lblMABesitzrecht";
            this.lblMABesitzrecht.Size = new System.Drawing.Size(299, 24);
            this.lblMABesitzrecht.TabIndex = 3;
            this.lblMABesitzrecht.Text = "MA mit Besitzerrechten";
            this.lblMABesitzrecht.UseCompatibleTextRendering = true;
            //
            // edtFilter
            //
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(67, 196);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(323, 24);
            this.edtFilter.TabIndex = 2;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            //
            // lblFilter
            //
            this.lblFilter.Location = new System.Drawing.Point(7, 196);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            //
            // grdVerfuegbar
            //
            this.grdVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(7, 4);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Margin = new System.Windows.Forms.Padding(4);
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(383, 185);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            //
            // qryVerfuegbar
            //
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.TableName = "XUser";
            //
            // grvVerfuegbar
            //
            this.grvVerfuegbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfuegbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser2,
            this.colOrgUnit,
            this.colUserGroupID});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.AllowFilterEditor = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsMenu.EnableColumnMenu = false;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsSelection.MultiSelect = true;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
            this.grvVerfuegbar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVerfuegbar_KeyPress);
            //
            // colUser2
            //
            this.colUser2.Caption = "Mitarbeiter/in";
            this.colUser2.FieldName = "UserName";
            this.colUser2.Name = "colUser2";
            this.colUser2.Visible = true;
            this.colUser2.VisibleIndex = 0;
            this.colUser2.Width = 225;
            //
            // colOrgUnit
            //
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.FieldName = "Abteilung";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 1;
            this.colOrgUnit.Width = 120;
            //
            // colUserGroupID
            //
            this.colUserGroupID.Caption = "-";
            this.colUserGroupID.FieldName = "UserID";
            this.colUserGroupID.Name = "colUserGroupID";
            //
            // CtlFallZugriff
            //
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.panBottom);
            this.Name = "CtlFallZugriff";
            this.Size = new System.Drawing.Size(750, 550);
            this.Load += new System.EventHandler(this.CtlFallZugriff_Load);
            this.Controls.SetChildIndex(this.panBottom, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProzess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMAKuerzel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMAKuerzel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).EndInit();
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOwnerMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMABesitzrecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnSelectAll;
        private KiSS4.Gui.KissButton btnSelectNone;
        private KiSS4.Gui.KissButton btnSetOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colAbteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswahl;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKuerzel;
        private DevExpress.XtraGrid.Columns.GridColumn colMutieren;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colProzess;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupID;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtOwnerMA;
        private KiSS4.Gui.KissLookUpEdit edtSucheAbteilung;
        private KiSS4.Gui.KissTextEdit edtSucheKlient;
        private KiSS4.Gui.KissTextEdit edtSucheMA;
        private KiSS4.Gui.KissTextEdit edtSucheMAKuerzel;
        private KiSS4.Gui.KissCheckEdit edtSucheNurAktive;
        private KiSS4.Gui.KissLookUpEdit edtSucheProzess;
        private KiSS4.Gui.KissGrid grdFaLeistung;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaLeistung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblGewaehlteZeilen;
        private KiSS4.Gui.KissLabel lblMABesitzrecht;
        private KiSS4.Gui.KissLabel lblSucheAbteilung;
        private KiSS4.Gui.KissLabel lblSucheKlient;
        private KiSS4.Gui.KissLabel lblSucheMA;
        private KiSS4.Gui.KissLabel lblSucheMAKuerzel;
        private KiSS4.Gui.KissLabel lblSucheProzess;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Panel panTop;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repItemIcon;
        private System.Windows.Forms.ToolTip ttpFallZugriff;
    }
}
