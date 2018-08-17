namespace KiSS4.Fallfuehrung.IBE
{
    partial class CtlFaDokumente
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaDokumente));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.grdDokumente = new KiSS4.Gui.KissGrid();
            this.qryFaDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.gvwDokumente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThemen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdressat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.edtFaDokKorreSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.edtFaDokKorreSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtFaDokKorreSucheAbsender = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokKorreSucheAddressat = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokKorreSucheStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblSuchThema = new KiSS4.Gui.KissLabel();
            this.edtSuchThema = new KiSS4.Gui.KissLookUpEdit();
            this.colPendenzDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtDatumErstellung = new KiSS4.Gui.KissDateEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.edtAbsender = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.edtAdressat = new KiSS4.Common.KissAdressatButtonEdit(this.components);
            this.lblDatumErstellung = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokKorreDokument = new KiSS4.Dokument.XDokument();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.memBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtBericht = new KiSS4.Gui.KissCheckEdit();
            this.lblThema = new KiSS4.Gui.KissLabel();
            this.edtThema = new KiSS4.Gui.KissLookUpEdit();
            this.edtBetroffenePersonen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBetroffenePersonen = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAddressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffenePersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffenePersonen)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(731, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(0, 37);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(755, 245);
            this.tabControlSearch.TabIndex = 2;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdDokumente);
            this.tpgListe.Size = new System.Drawing.Size(743, 207);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSuchThema);
            this.tpgSuchen.Controls.Add(this.lblSuchThema);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheStichwort);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheAddressat);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheAbsender);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.kissLabel15);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.kissLabel14);
            this.tpgSuchen.Controls.Add(this.kissLabel12);
            this.tpgSuchen.Controls.Add(this.kissLabel11);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Size = new System.Drawing.Size(743, 207);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel11, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel12, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel14, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel15, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheAbsender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheAddressat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchThema, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchThema, 0);
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(755, 40);
            this.pnTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Korrespondenz";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // grdDokumente
            // 
            this.grdDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDokumente.DataSource = this.qryFaDokumente;
            // 
            // 
            // 
            this.grdDokumente.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Fa_Dok_Korrespondenz.EmbeddedNavigator";
            this.grdDokumente.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDokumente.Location = new System.Drawing.Point(0, 0);
            this.grdDokumente.MainView = this.gvwDokumente;
            this.grdDokumente.Name = "grdDokumente";
            this.grdDokumente.Size = new System.Drawing.Size(743, 204);
            this.grdDokumente.TabIndex = 3;
            this.grdDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwDokumente,
            this.gridView1});
            // 
            // qryFaDokumente
            // 
            this.qryFaDokumente.CanDelete = true;
            this.qryFaDokumente.CanInsert = true;
            this.qryFaDokumente.CanUpdate = true;
            this.qryFaDokumente.HostControl = this;
            this.qryFaDokumente.SelectStatement = resources.GetString("qryFaDokumente.SelectStatement");
            this.qryFaDokumente.TableName = "FaDokumente";
            this.qryFaDokumente.AfterInsert += new System.EventHandler(this.qryFaDokumente_AfterInsert);
            this.qryFaDokumente.BeforePost += new System.EventHandler(this.qryFaDokumente_BeforePost);
            // 
            // gvwDokumente
            // 
            this.gvwDokumente.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwDokumente.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.Empty.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.Empty.Options.UseFont = true;
            this.gvwDokumente.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.EvenRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwDokumente.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvwDokumente.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwDokumente.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwDokumente.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvwDokumente.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwDokumente.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwDokumente.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwDokumente.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwDokumente.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.GroupRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwDokumente.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwDokumente.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwDokumente.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwDokumente.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwDokumente.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvwDokumente.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwDokumente.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwDokumente.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.OddRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvwDokumente.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.Row.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.Row.Options.UseFont = true;
            this.gvwDokumente.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwDokumente.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwDokumente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwDokumente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colThemen,
            this.colStichworte,
            this.colAbsender,
            this.colAdressat});
            this.gvwDokumente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvwDokumente.GridControl = this.grdDokumente;
            this.gvwDokumente.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvwDokumente.Name = "gvwDokumente";
            this.gvwDokumente.OptionsBehavior.Editable = false;
            this.gvwDokumente.OptionsCustomization.AllowFilter = false;
            this.gvwDokumente.OptionsFilter.AllowFilterEditor = false;
            this.gvwDokumente.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwDokumente.OptionsMenu.EnableColumnMenu = false;
            this.gvwDokumente.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwDokumente.OptionsNavigation.UseTabKey = false;
            this.gvwDokumente.OptionsView.ColumnAutoWidth = false;
            this.gvwDokumente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwDokumente.OptionsView.ShowGroupPanel = false;
            this.gvwDokumente.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "DatumErstellung";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 72;
            // 
            // colThemen
            // 
            this.colThemen.Caption = "Themen";
            this.colThemen.FieldName = "ThemaCode";
            this.colThemen.Name = "colThemen";
            this.colThemen.Visible = true;
            this.colThemen.VisibleIndex = 1;
            this.colThemen.Width = 150;
            // 
            // colStichworte
            // 
            this.colStichworte.Caption = "Stichwort(e)";
            this.colStichworte.FieldName = "Stichwort";
            this.colStichworte.Name = "colStichworte";
            this.colStichworte.Visible = true;
            this.colStichworte.VisibleIndex = 2;
            this.colStichworte.Width = 184;
            // 
            // colAbsender
            // 
            this.colAbsender.Caption = "Absender";
            this.colAbsender.FieldName = "AbsenderName";
            this.colAbsender.Name = "colAbsender";
            this.colAbsender.Visible = true;
            this.colAbsender.VisibleIndex = 3;
            this.colAbsender.Width = 158;
            // 
            // colAdressat
            // 
            this.colAdressat.Caption = "Adressat";
            this.colAdressat.FieldName = "AdressatName";
            this.colAdressat.Name = "colAdressat";
            this.colAdressat.Visible = true;
            this.colAdressat.VisibleIndex = 4;
            this.colAdressat.Width = 164;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdDokumente;
            this.gridView1.Name = "gridView1";
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(1, 51);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(72, 24);
            this.kissLabel10.TabIndex = 1;
            this.kissLabel10.Text = "Datum von";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(1, 84);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(72, 24);
            this.kissLabel11.TabIndex = 5;
            this.kissLabel11.Text = "Absender/in";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(1, 113);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(72, 24);
            this.kissLabel12.TabIndex = 7;
            this.kissLabel12.Text = "Adressat/in";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Location = new System.Drawing.Point(1, 171);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(72, 24);
            this.kissLabel14.TabIndex = 11;
            this.kissLabel14.Text = "Stichwort(e)";
            this.kissLabel14.UseCompatibleTextRendering = true;
            // 
            // edtFaDokKorreSucheDatumVon
            // 
            this.edtFaDokKorreSucheDatumVon.EditValue = null;
            this.edtFaDokKorreSucheDatumVon.Location = new System.Drawing.Point(91, 51);
            this.edtFaDokKorreSucheDatumVon.Name = "edtFaDokKorreSucheDatumVon";
            this.edtFaDokKorreSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtFaDokKorreSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokKorreSucheDatumVon.Properties.ShowToday = false;
            this.edtFaDokKorreSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtFaDokKorreSucheDatumVon.TabIndex = 2;
            // 
            // kissLabel15
            // 
            this.kissLabel15.Location = new System.Drawing.Point(207, 51);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(32, 24);
            this.kissLabel15.TabIndex = 3;
            this.kissLabel15.Text = "bis";
            this.kissLabel15.UseCompatibleTextRendering = true;
            // 
            // edtFaDokKorreSucheDatumBis
            // 
            this.edtFaDokKorreSucheDatumBis.EditValue = null;
            this.edtFaDokKorreSucheDatumBis.Location = new System.Drawing.Point(235, 51);
            this.edtFaDokKorreSucheDatumBis.Name = "edtFaDokKorreSucheDatumBis";
            this.edtFaDokKorreSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtFaDokKorreSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokKorreSucheDatumBis.Properties.ShowToday = false;
            this.edtFaDokKorreSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtFaDokKorreSucheDatumBis.TabIndex = 4;
            // 
            // edtFaDokKorreSucheAbsender
            // 
            this.edtFaDokKorreSucheAbsender.Location = new System.Drawing.Point(91, 83);
            this.edtFaDokKorreSucheAbsender.Name = "edtFaDokKorreSucheAbsender";
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokKorreSucheAbsender.Size = new System.Drawing.Size(284, 24);
            this.edtFaDokKorreSucheAbsender.TabIndex = 6;
            // 
            // edtFaDokKorreSucheAddressat
            // 
            this.edtFaDokKorreSucheAddressat.Location = new System.Drawing.Point(91, 112);
            this.edtFaDokKorreSucheAddressat.Name = "edtFaDokKorreSucheAddressat";
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheAddressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokKorreSucheAddressat.Size = new System.Drawing.Size(284, 24);
            this.edtFaDokKorreSucheAddressat.TabIndex = 8;
            // 
            // edtFaDokKorreSucheStichwort
            // 
            this.edtFaDokKorreSucheStichwort.Location = new System.Drawing.Point(91, 170);
            this.edtFaDokKorreSucheStichwort.Name = "edtFaDokKorreSucheStichwort";
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokKorreSucheStichwort.Size = new System.Drawing.Size(284, 24);
            this.edtFaDokKorreSucheStichwort.TabIndex = 12;
            // 
            // lblSuchThema
            // 
            this.lblSuchThema.Location = new System.Drawing.Point(1, 143);
            this.lblSuchThema.Name = "lblSuchThema";
            this.lblSuchThema.Size = new System.Drawing.Size(80, 24);
            this.lblSuchThema.TabIndex = 9;
            this.lblSuchThema.Text = "Thema";
            this.lblSuchThema.UseCompatibleTextRendering = true;
            // 
            // edtSuchThema
            // 
            this.edtSuchThema.Location = new System.Drawing.Point(91, 140);
            this.edtSuchThema.LOVName = "FaThema";
            this.edtSuchThema.Name = "edtSuchThema";
            this.edtSuchThema.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchThema.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchThema.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchThema.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchThema.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchThema.Properties.Appearance.Options.UseFont = true;
            this.edtSuchThema.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSuchThema.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchThema.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSuchThema.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSuchThema.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSuchThema.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSuchThema.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchThema.Properties.NullText = "";
            this.edtSuchThema.Properties.ShowFooter = false;
            this.edtSuchThema.Properties.ShowHeader = false;
            this.edtSuchThema.Size = new System.Drawing.Size(284, 24);
            this.edtSuchThema.TabIndex = 10;
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
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // edtDatumErstellung
            // 
            this.edtDatumErstellung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumErstellung.DataMember = "DatumErstellung";
            this.edtDatumErstellung.DataSource = this.qryFaDokumente;
            this.edtDatumErstellung.EditValue = ((object)(resources.GetObject("edtDatumErstellung.EditValue")));
            this.edtDatumErstellung.Location = new System.Drawing.Point(97, 290);
            this.edtDatumErstellung.Name = "edtDatumErstellung";
            this.edtDatumErstellung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumErstellung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumErstellung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumErstellung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumErstellung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumErstellung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumErstellung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtDatumErstellung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumErstellung.Properties.Name = "edtFaDokKorreDatum.Properties";
            this.edtDatumErstellung.Properties.ShowToday = false;
            this.edtDatumErstellung.Size = new System.Drawing.Size(100, 24);
            this.edtDatumErstellung.TabIndex = 2;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel6.Location = new System.Drawing.Point(7, 440);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(80, 24);
            this.kissLabel6.TabIndex = 12;
            this.kissLabel6.Text = "Dokument";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // edtAbsender
            // 
            this.edtAbsender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAbsender.DataMember = "AbsenderName";
            this.edtAbsender.DataMemberUserId = "UserID_Absender";
            this.edtAbsender.DataSource = this.qryFaDokumente;
            this.edtAbsender.Location = new System.Drawing.Point(97, 320);
            this.edtAbsender.LookupID = ((object)(resources.GetObject("edtAbsender.LookupID")));
            this.edtAbsender.Name = "edtAbsender";
            this.edtAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAbsender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAbsender.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbsender.Properties.Name = "edtFaDokKorreAbsend.Properties";
            this.edtAbsender.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAbsender.Size = new System.Drawing.Size(250, 24);
            this.edtAbsender.TabIndex = 5;
            // 
            // edtAdressat
            // 
            this.edtAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdressat.DataMember = "AdressatName";
            this.edtAdressat.DataMemberBaInstitution = "BaInstitutionID_Adressat";
            this.edtAdressat.DataMemberBaPerson = "BaPersonID_Adressat";
            this.edtAdressat.DataMemberFaLeistung = "FaLeistungID";
            this.edtAdressat.DataMemberVmPriMa = null;
            this.edtAdressat.DataSource = this.qryFaDokumente;
            this.edtAdressat.Location = new System.Drawing.Point(97, 350);
            this.edtAdressat.LookupID = ((object)(resources.GetObject("edtAdressat.LookupID")));
            this.edtAdressat.Name = "edtAdressat";
            this.edtAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAdressat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAdressat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAdressat.Properties.Name = "edtFaDokKorreAddres.Properties";
            this.edtAdressat.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAdressat.Size = new System.Drawing.Size(250, 24);
            this.edtAdressat.TabIndex = 7;
            // 
            // lblDatumErstellung
            // 
            this.lblDatumErstellung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumErstellung.Location = new System.Drawing.Point(7, 290);
            this.lblDatumErstellung.Name = "lblDatumErstellung";
            this.lblDatumErstellung.Size = new System.Drawing.Size(36, 24);
            this.lblDatumErstellung.TabIndex = 1;
            this.lblDatumErstellung.Text = "Datum";
            this.lblDatumErstellung.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryFaDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(97, 410);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Properties.Name = "edtFaDokKorreStichwort.Properties";
            this.edtStichwort.Size = new System.Drawing.Size(454, 24);
            this.edtStichwort.TabIndex = 11;
            // 
            // edtFaDokKorreDokument
            // 
            this.edtFaDokKorreDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFaDokKorreDokument.Context = "FaKorrespondenz";
            this.edtFaDokKorreDokument.DataMember = "DocumentID";
            this.edtFaDokKorreDokument.DataSource = this.qryFaDokumente;
            this.edtFaDokKorreDokument.Location = new System.Drawing.Point(97, 440);
            this.edtFaDokKorreDokument.Name = "edtFaDokKorreDokument";
            this.edtFaDokKorreDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreDokument.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtFaDokKorreDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument importieren")});
            this.edtFaDokKorreDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokKorreDokument.Properties.Name = "edtFaDokKorreDokument.Properties";
            this.edtFaDokKorreDokument.Properties.ReadOnly = true;
            this.edtFaDokKorreDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFaDokKorreDokument.Size = new System.Drawing.Size(121, 24);
            this.edtFaDokKorreDokument.TabIndex = 13;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(7, 410);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(72, 24);
            this.lblStichwort.TabIndex = 10;
            this.lblStichwort.Text = "Stichwort(e)";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // kissLabel20
            // 
            this.kissLabel20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel20.Location = new System.Drawing.Point(7, 350);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(64, 24);
            this.kissLabel20.TabIndex = 6;
            this.kissLabel20.Text = "Adressat/in";
            this.kissLabel20.UseCompatibleTextRendering = true;
            // 
            // kissLabel21
            // 
            this.kissLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel21.Location = new System.Drawing.Point(7, 320);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(64, 24);
            this.kissLabel21.TabIndex = 4;
            this.kissLabel21.Text = "Absender/in";
            this.kissLabel21.UseCompatibleTextRendering = true;
            // 
            // memBemerkung
            // 
            this.memBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkung.DataMember = "Bemerkung";
            this.memBemerkung.DataSource = this.qryFaDokumente;
            this.memBemerkung.Location = new System.Drawing.Point(97, 470);
            this.memBemerkung.Name = "memBemerkung";
            this.memBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseFont = true;
            this.memBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkung.Size = new System.Drawing.Size(460, 53);
            this.memBemerkung.TabIndex = 15;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.Location = new System.Drawing.Point(7, 470);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(64, 24);
            this.kissLabel2.TabIndex = 14;
            this.kissLabel2.Text = "Handlung";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtBericht
            // 
            this.edtBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBericht.EditValue = false;
            this.edtBericht.Location = new System.Drawing.Point(221, 294);
            this.edtBericht.Name = "edtBericht";
            this.edtBericht.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtBericht.Properties.Appearance.Options.UseBackColor = true;
            this.edtBericht.Properties.Caption = "Bericht";
            this.edtBericht.Size = new System.Drawing.Size(75, 19);
            this.edtBericht.TabIndex = 3;
            this.edtBericht.Visible = false;
            // 
            // lblThema
            // 
            this.lblThema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThema.Location = new System.Drawing.Point(7, 381);
            this.lblThema.Name = "lblThema";
            this.lblThema.Size = new System.Drawing.Size(67, 24);
            this.lblThema.TabIndex = 8;
            this.lblThema.Text = "Thema";
            this.lblThema.UseCompatibleTextRendering = true;
            // 
            // edtThema
            // 
            this.edtThema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtThema.DataMember = "ThemaCode";
            this.edtThema.DataSource = this.qryFaDokumente;
            this.edtThema.Location = new System.Drawing.Point(97, 380);
            this.edtThema.LOVName = "FaThema";
            this.edtThema.Name = "edtThema";
            this.edtThema.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtThema.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtThema.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtThema.Properties.Appearance.Options.UseBackColor = true;
            this.edtThema.Properties.Appearance.Options.UseBorderColor = true;
            this.edtThema.Properties.Appearance.Options.UseFont = true;
            this.edtThema.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtThema.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtThema.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtThema.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtThema.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtThema.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtThema.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtThema.Properties.NullText = "";
            this.edtThema.Properties.ShowFooter = false;
            this.edtThema.Properties.ShowHeader = false;
            this.edtThema.Size = new System.Drawing.Size(250, 24);
            this.edtThema.TabIndex = 9;
            // 
            // edtBetroffenePersonen
            // 
            this.edtBetroffenePersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetroffenePersonen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtBetroffenePersonen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetroffenePersonen.Appearance.Options.UseBackColor = true;
            this.edtBetroffenePersonen.Appearance.Options.UseBorderColor = true;
            this.edtBetroffenePersonen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBetroffenePersonen.CheckOnClick = true;
            this.edtBetroffenePersonen.DataMember = "BaPersonIDs";
            this.edtBetroffenePersonen.DataSource = this.qryFaDokumente;
            this.edtBetroffenePersonen.Location = new System.Drawing.Point(575, 350);
            this.edtBetroffenePersonen.Name = "edtBetroffenePersonen";
            this.edtBetroffenePersonen.Size = new System.Drawing.Size(174, 173);
            this.edtBetroffenePersonen.TabIndex = 17;
            // 
            // lblBetroffenePersonen
            // 
            this.lblBetroffenePersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetroffenePersonen.Location = new System.Drawing.Point(575, 320);
            this.lblBetroffenePersonen.Name = "lblBetroffenePersonen";
            this.lblBetroffenePersonen.Size = new System.Drawing.Size(174, 24);
            this.lblBetroffenePersonen.TabIndex = 16;
            this.lblBetroffenePersonen.Text = "Betroffene Personen";
            this.lblBetroffenePersonen.UseCompatibleTextRendering = true;
            // 
            // CtlFaDokumente
            // 
            this.ActiveSQLQuery = this.qryFaDokumente;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(750, 530);
            this.Controls.Add(this.edtThema);
            this.Controls.Add(this.edtBetroffenePersonen);
            this.Controls.Add(this.lblBetroffenePersonen);
            this.Controls.Add(this.lblThema);
            this.Controls.Add(this.edtBericht);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.memBemerkung);
            this.Controls.Add(this.kissLabel21);
            this.Controls.Add(this.kissLabel20);
            this.Controls.Add(this.lblStichwort);
            this.Controls.Add(this.edtFaDokKorreDokument);
            this.Controls.Add(this.edtStichwort);
            this.Controls.Add(this.lblDatumErstellung);
            this.Controls.Add(this.edtAdressat);
            this.Controls.Add(this.edtAbsender);
            this.Controls.Add(this.kissLabel6);
            this.Controls.Add(this.edtDatumErstellung);
            this.Controls.Add(this.pnTitle);
            this.Location = new System.Drawing.Point(-370, 380);
            this.Name = "CtlFaDokumente";
            this.Size = new System.Drawing.Size(755, 536);
            this.Controls.SetChildIndex(this.pnTitle, 0);
            this.Controls.SetChildIndex(this.edtDatumErstellung, 0);
            this.Controls.SetChildIndex(this.kissLabel6, 0);
            this.Controls.SetChildIndex(this.edtAbsender, 0);
            this.Controls.SetChildIndex(this.edtAdressat, 0);
            this.Controls.SetChildIndex(this.lblDatumErstellung, 0);
            this.Controls.SetChildIndex(this.edtStichwort, 0);
            this.Controls.SetChildIndex(this.edtFaDokKorreDokument, 0);
            this.Controls.SetChildIndex(this.lblStichwort, 0);
            this.Controls.SetChildIndex(this.kissLabel20, 0);
            this.Controls.SetChildIndex(this.kissLabel21, 0);
            this.Controls.SetChildIndex(this.memBemerkung, 0);
            this.Controls.SetChildIndex(this.kissLabel2, 0);
            this.Controls.SetChildIndex(this.edtBericht, 0);
            this.Controls.SetChildIndex(this.lblThema, 0);
            this.Controls.SetChildIndex(this.lblBetroffenePersonen, 0);
            this.Controls.SetChildIndex(this.edtBetroffenePersonen, 0);
            this.Controls.SetChildIndex(this.edtThema, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAddressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffenePersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffenePersonen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAbsender;
        private DevExpress.XtraGrid.Columns.GridColumn colAdressat;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzText;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colThemen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtFaDokKorreSucheAbsender;
        private KiSS4.Gui.KissTextEdit edtFaDokKorreSucheAddressat;
        private KiSS4.Gui.KissDateEdit edtFaDokKorreSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtFaDokKorreSucheDatumVon;
        private KiSS4.Gui.KissTextEdit edtFaDokKorreSucheStichwort;
        private KiSS4.Gui.KissLookUpEdit edtSuchThema;
        private KiSS4.Gui.KissGrid grdDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwDokumente;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel lblSuchThema;
        private KiSS4.Gui.KissLabel lblTitle;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryFaDokumente;
        private Gui.KissCheckedLookupEdit edtBetroffenePersonen;
        private Gui.KissLabel lblBetroffenePersonen;
        private Gui.KissLookUpEdit edtThema;
        private Gui.KissLabel lblThema;
        private Gui.KissCheckEdit edtBericht;
        private Gui.KissLabel kissLabel2;
        private Gui.KissMemoEdit memBemerkung;
        private Gui.KissLabel kissLabel21;
        private Gui.KissLabel kissLabel20;
        private Gui.KissLabel lblStichwort;
        private Dokument.XDokument edtFaDokKorreDokument;
        private Gui.KissTextEdit edtStichwort;
        private Gui.KissLabel lblDatumErstellung;
        private Common.KissAdressatButtonEdit edtAdressat;
        private Common.KissMitarbeiterButtonEdit edtAbsender;
        private Gui.KissLabel kissLabel6;
        private Gui.KissDateEdit edtDatumErstellung;
    }
}
