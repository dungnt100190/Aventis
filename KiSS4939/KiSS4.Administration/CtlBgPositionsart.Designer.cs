namespace KiSS4.Administration
{
    partial class CtlBgPositionsart
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgPositionsart));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBgPositionsart = new KiSS4.Gui.KissGrid();
            this.qryBgPositionsart = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgPositionsart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBgPositionsartCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgKategorieCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgGruppeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgKostenartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpezkonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblSucheKategorie = new KiSS4.Gui.KissLabel();
            this.edtBgKategorieCodeX = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheGruppe = new KiSS4.Gui.KissLabel();
            this.edtBgGruppeCodeX = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.lblSucheKostenart = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartIDX = new KiSS4.Gui.KissLookUpEdit();
            this.editReadOnly = new KiSS4.Gui.KissCheckEdit();
            this.lblBgPositionsartID = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissCalcEdit();
            this.lblBgKategorieCode = new KiSS4.Gui.KissLabel();
            this.edtBgKategorieCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgGruppeCode = new KiSS4.Gui.KissLabel();
            this.edtBgGruppeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblSortKey = new KiSS4.Gui.KissLabel();
            this.edtSortKey = new KiSS4.Gui.KissCalcEdit();
            this.lblBgKostenartID = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartID = new KiSS4.Gui.KissLookUpEdit();
            this.edtProPerson = new KiSS4.Gui.KissCheckEdit();
            this.edtProUE = new KiSS4.Gui.KissCheckEdit();
            this.edtVerwaltungSD_Default = new KiSS4.Gui.KissCheckEdit();
            this.edtSpezkonto = new KiSS4.Gui.KissCheckEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBudgetMaster = new KiSS4.Gui.KissLabel();
            this.chkEditMaskMasterLow = new KiSS4.Gui.KissCheckedLookupEdit();
            this.chkEditMaskMasterHigh = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBudgetMonat = new KiSS4.Gui.KissLabel();
            this.chkEditMaskMonatLow = new KiSS4.Gui.KissCheckedLookupEdit();
            this.chkEditMaskMonatHigh = new KiSS4.Gui.KissCheckedLookupEdit();
            this.qryBgKostenart = new KiSS4.DB.SqlQuery(this.components);
            this.edtBgPositionsartCode = new KiSS4.Gui.KissCalcEdit();
            this.lblBgPositionsartCode = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.edtBFSVariable = new KiSS4.Gui.KissButtonEdit();
            this.lblBFSVariable = new KiSS4.Gui.KissLabel();
            this.chkNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.edtSystem = new KiSS4.Gui.KissCheckEdit();
            this.edtVerrechenbar = new KiSS4.Gui.KissCheckEdit();
            this.edtKreditorEingeschraenkt = new KiSS4.Gui.KissCheckEdit();
            this.edtErzeugtBfsDossier = new KiSS4.Gui.KissCheckEdit();
            this.colVarName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKategorieCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProUE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD_Default.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSpezkonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudgetMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudgetMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSVariable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSVariable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerrechenbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorEingeschraenkt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErzeugtBfsDossier.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.InvalidateOnPropertyChanged = false;
            this.tabControlSearch.Size = new System.Drawing.Size(794, 289);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBgPositionsart);
            this.tpgListe.Size = new System.Drawing.Size(782, 251);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.chkNurAktive);
            this.tpgSuchen.Controls.Add(this.edtBgKostenartIDX);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenart);
            this.tpgSuchen.Controls.Add(this.edtNameX);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.edtBgGruppeCodeX);
            this.tpgSuchen.Controls.Add(this.lblSucheGruppe);
            this.tpgSuchen.Controls.Add(this.edtBgKategorieCodeX);
            this.tpgSuchen.Controls.Add(this.lblSucheKategorie);
            this.tpgSuchen.Size = new System.Drawing.Size(782, 251);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKategorie, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgKategorieCodeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgGruppeCodeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgKostenartIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkNurAktive, 0);
            // 
            // grdBgPositionsart
            // 
            this.grdBgPositionsart.DataSource = this.qryBgPositionsart;
            this.grdBgPositionsart.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBgPositionsart.EmbeddedNavigator.Name = "";
            this.grdBgPositionsart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPositionsart.Location = new System.Drawing.Point(0, 0);
            this.grdBgPositionsart.MainView = this.grvBgPositionsart;
            this.grdBgPositionsart.Name = "grdBgPositionsart";
            this.grdBgPositionsart.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.grdBgPositionsart.Size = new System.Drawing.Size(782, 251);
            this.grdBgPositionsart.TabIndex = 0;
            this.grdBgPositionsart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPositionsart});
            // 
            // qryBgPositionsart
            // 
            this.qryBgPositionsart.HostControl = this;
            this.qryBgPositionsart.SelectStatement = resources.GetString("qryBgPositionsart.SelectStatement");
            this.qryBgPositionsart.TableName = "BgPositionsart";
            this.qryBgPositionsart.AfterDelete += new System.EventHandler(this.qryBgPositionsart_AfterDelete);
            this.qryBgPositionsart.AfterInsert += new System.EventHandler(this.qryBgPositionsart_AfterInsert);
            this.qryBgPositionsart.AfterPost += new System.EventHandler(this.qryBgPositionsart_AfterPost);
            this.qryBgPositionsart.BeforeDelete += new System.EventHandler(this.qryBgPositionsart_BeforeDelete);
            this.qryBgPositionsart.BeforeInsert += new System.EventHandler(this.qryBgPositionsart_BeforeInsert);
            this.qryBgPositionsart.BeforePost += new System.EventHandler(this.qryBgPositionsart_BeforePost);
            this.qryBgPositionsart.PositionChanged += new System.EventHandler(this.qryBgPositionsart_PositionChanged);
            // 
            // grvBgPositionsart
            // 
            this.grvBgPositionsart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPositionsart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.Empty.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPositionsart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPositionsart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPositionsart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPositionsart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPositionsart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPositionsart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPositionsart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPositionsart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPositionsart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.Row.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPositionsart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPositionsart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPositionsart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBgPositionsartCode,
            this.colBgKategorieCode,
            this.colBgGruppeCode,
            this.colName,
            this.colBgKostenartID,
            this.colPerson,
            this.colUE,
            this.colSD,
            this.colSpezkonto,
            this.colDatumVon,
            this.colDatumBis,
            this.colVarName});
            this.grvBgPositionsart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPositionsart.GridControl = this.grdBgPositionsart;
            this.grvBgPositionsart.Name = "grvBgPositionsart";
            this.grvBgPositionsart.OptionsBehavior.Editable = false;
            this.grvBgPositionsart.OptionsCustomization.AllowFilter = false;
            this.grvBgPositionsart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPositionsart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPositionsart.OptionsNavigation.UseTabKey = false;
            this.grvBgPositionsart.OptionsView.ColumnAutoWidth = false;
            this.grvBgPositionsart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPositionsart.OptionsView.ShowGroupPanel = false;
            this.grvBgPositionsart.OptionsView.ShowIndicator = false;
            // 
            // colBgPositionsartCode
            // 
            this.colBgPositionsartCode.Caption = "Code";
            this.colBgPositionsartCode.FieldName = "BgPositionsartCode";
            this.colBgPositionsartCode.Name = "colBgPositionsartCode";
            this.colBgPositionsartCode.Visible = true;
            this.colBgPositionsartCode.VisibleIndex = 0;
            // 
            // colBgKategorieCode
            // 
            this.colBgKategorieCode.Caption = "Kategorie";
            this.colBgKategorieCode.FieldName = "BgKategorieCode";
            this.colBgKategorieCode.Name = "colBgKategorieCode";
            this.colBgKategorieCode.Visible = true;
            this.colBgKategorieCode.VisibleIndex = 1;
            this.colBgKategorieCode.Width = 150;
            // 
            // colBgGruppeCode
            // 
            this.colBgGruppeCode.Caption = "Gruppe";
            this.colBgGruppeCode.FieldName = "BgGruppeCode";
            this.colBgGruppeCode.Name = "colBgGruppeCode";
            this.colBgGruppeCode.Visible = true;
            this.colBgGruppeCode.VisibleIndex = 2;
            this.colBgGruppeCode.Width = 220;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 260;
            // 
            // colBgKostenartID
            // 
            this.colBgKostenartID.Caption = "KA";
            this.colBgKostenartID.FieldName = "BgKostenartID";
            this.colBgKostenartID.Name = "colBgKostenartID";
            this.colBgKostenartID.Visible = true;
            this.colBgKostenartID.VisibleIndex = 4;
            this.colBgKostenartID.Width = 160;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Pro Pers.";
            this.colPerson.FieldName = "ProPerson";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 5;
            this.colPerson.Width = 65;
            // 
            // colUE
            // 
            this.colUE.Caption = "Pro UE";
            this.colUE.FieldName = "ProUE";
            this.colUE.Name = "colUE";
            this.colUE.Visible = true;
            this.colUE.VisibleIndex = 6;
            this.colUE.Width = 65;
            // 
            // colSD
            // 
            this.colSD.Caption = "Verw. SD";
            this.colSD.FieldName = "VerwaltungSD_Default";
            this.colSD.Name = "colSD";
            this.colSD.Visible = true;
            this.colSD.VisibleIndex = 7;
            this.colSD.Width = 65;
            // 
            // colSpezkonto
            // 
            this.colSpezkonto.Caption = "Spezialk.";
            this.colSpezkonto.FieldName = "Spezkonto";
            this.colSpezkonto.Name = "colSpezkonto";
            this.colSpezkonto.Visible = true;
            this.colSpezkonto.VisibleIndex = 8;
            this.colSpezkonto.Width = 65;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum Von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 9;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Datum Bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 10;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // lblSucheKategorie
            // 
            this.lblSucheKategorie.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKategorie.Name = "lblSucheKategorie";
            this.lblSucheKategorie.Size = new System.Drawing.Size(80, 24);
            this.lblSucheKategorie.TabIndex = 1;
            this.lblSucheKategorie.Text = "Kategorie";
            this.lblSucheKategorie.UseCompatibleTextRendering = true;
            // 
            // edtBgKategorieCodeX
            // 
            this.edtBgKategorieCodeX.Location = new System.Drawing.Point(117, 40);
            this.edtBgKategorieCodeX.LOVName = "BgKategorie";
            this.edtBgKategorieCodeX.Name = "edtBgKategorieCodeX";
            this.edtBgKategorieCodeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKategorieCodeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKategorieCodeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseFont = true;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKategorieCodeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtBgKategorieCodeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKategorieCodeX.Properties.NullText = "";
            this.edtBgKategorieCodeX.Properties.ShowFooter = false;
            this.edtBgKategorieCodeX.Properties.ShowHeader = false;
            this.edtBgKategorieCodeX.Size = new System.Drawing.Size(303, 24);
            this.edtBgKategorieCodeX.TabIndex = 2;
            // 
            // lblSucheGruppe
            // 
            this.lblSucheGruppe.Location = new System.Drawing.Point(31, 70);
            this.lblSucheGruppe.Name = "lblSucheGruppe";
            this.lblSucheGruppe.Size = new System.Drawing.Size(80, 24);
            this.lblSucheGruppe.TabIndex = 3;
            this.lblSucheGruppe.Text = "Gruppe";
            this.lblSucheGruppe.UseCompatibleTextRendering = true;
            // 
            // edtBgGruppeCodeX
            // 
            this.edtBgGruppeCodeX.Location = new System.Drawing.Point(117, 70);
            this.edtBgGruppeCodeX.LOVName = "BgGruppe";
            this.edtBgGruppeCodeX.Name = "edtBgGruppeCodeX";
            this.edtBgGruppeCodeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGruppeCodeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGruppeCodeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseFont = true;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGruppeCodeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBgGruppeCodeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCodeX.Properties.NullText = "";
            this.edtBgGruppeCodeX.Properties.ShowFooter = false;
            this.edtBgGruppeCodeX.Properties.ShowHeader = false;
            this.edtBgGruppeCodeX.Size = new System.Drawing.Size(303, 24);
            this.edtBgGruppeCodeX.TabIndex = 4;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(31, 100);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(80, 24);
            this.lblSucheName.TabIndex = 5;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtNameX
            // 
            this.edtNameX.Location = new System.Drawing.Point(117, 100);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Size = new System.Drawing.Size(303, 24);
            this.edtNameX.TabIndex = 6;
            // 
            // lblSucheKostenart
            // 
            this.lblSucheKostenart.Location = new System.Drawing.Point(31, 130);
            this.lblSucheKostenart.Name = "lblSucheKostenart";
            this.lblSucheKostenart.Size = new System.Drawing.Size(80, 24);
            this.lblSucheKostenart.TabIndex = 7;
            this.lblSucheKostenart.Text = "Kostenart";
            this.lblSucheKostenart.UseCompatibleTextRendering = true;
            // 
            // edtBgKostenartIDX
            // 
            this.edtBgKostenartIDX.Location = new System.Drawing.Point(117, 130);
            this.edtBgKostenartIDX.Name = "edtBgKostenartIDX";
            this.edtBgKostenartIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKostenartIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKostenartIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBgKostenartIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartIDX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgKostenartIDX.Properties.DisplayMember = "Name";
            this.edtBgKostenartIDX.Properties.NullText = "";
            this.edtBgKostenartIDX.Properties.ShowFooter = false;
            this.edtBgKostenartIDX.Properties.ShowHeader = false;
            this.edtBgKostenartIDX.Properties.ValueMember = "BgKostenartID";
            this.edtBgKostenartIDX.Size = new System.Drawing.Size(391, 24);
            this.edtBgKostenartIDX.TabIndex = 8;
            // 
            // editReadOnly
            // 
            this.editReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editReadOnly.EditValue = true;
            this.editReadOnly.Location = new System.Drawing.Point(687, 274);
            this.editReadOnly.Name = "editReadOnly";
            this.editReadOnly.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editReadOnly.Properties.Appearance.Options.UseBackColor = true;
            this.editReadOnly.Properties.Caption = "Schreibschutz";
            this.editReadOnly.Size = new System.Drawing.Size(104, 19);
            this.editReadOnly.TabIndex = 1;
            this.editReadOnly.CheckedChanged += new System.EventHandler(this.editReadOnly_CheckedChanged);
            // 
            // lblBgPositionsartID
            // 
            this.lblBgPositionsartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgPositionsartID.Location = new System.Drawing.Point(9, 298);
            this.lblBgPositionsartID.Name = "lblBgPositionsartID";
            this.lblBgPositionsartID.Size = new System.Drawing.Size(76, 24);
            this.lblBgPositionsartID.TabIndex = 2;
            this.lblBgPositionsartID.Text = "ID";
            this.lblBgPositionsartID.UseCompatibleTextRendering = true;
            // 
            // edtBgPositionsartID
            // 
            this.edtBgPositionsartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgPositionsart;
            this.edtBgPositionsartID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(91, 298);
            this.edtBgPositionsartID.Name = "edtBgPositionsartID";
            this.edtBgPositionsartID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBgPositionsartID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgPositionsartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.ReadOnly = true;
            this.edtBgPositionsartID.Size = new System.Drawing.Size(68, 24);
            this.edtBgPositionsartID.TabIndex = 3;
            // 
            // lblBgKategorieCode
            // 
            this.lblBgKategorieCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgKategorieCode.Location = new System.Drawing.Point(9, 328);
            this.lblBgKategorieCode.Name = "lblBgKategorieCode";
            this.lblBgKategorieCode.Size = new System.Drawing.Size(76, 24);
            this.lblBgKategorieCode.TabIndex = 10;
            this.lblBgKategorieCode.Text = "Kategorie";
            this.lblBgKategorieCode.UseCompatibleTextRendering = true;
            // 
            // edtBgKategorieCode
            // 
            this.edtBgKategorieCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgKategorieCode.DataMember = "BgKategorieCode";
            this.edtBgKategorieCode.DataSource = this.qryBgPositionsart;
            this.edtBgKategorieCode.Location = new System.Drawing.Point(91, 328);
            this.edtBgKategorieCode.LOVName = "BgKategorie";
            this.edtBgKategorieCode.Name = "edtBgKategorieCode";
            this.edtBgKategorieCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKategorieCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKategorieCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKategorieCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKategorieCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgKategorieCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKategorieCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKategorieCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKategorieCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBgKategorieCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBgKategorieCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKategorieCode.Properties.NullText = "";
            this.edtBgKategorieCode.Properties.ShowFooter = false;
            this.edtBgKategorieCode.Properties.ShowHeader = false;
            this.edtBgKategorieCode.Size = new System.Drawing.Size(461, 24);
            this.edtBgKategorieCode.TabIndex = 11;
            // 
            // lblBgGruppeCode
            // 
            this.lblBgGruppeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgGruppeCode.Location = new System.Drawing.Point(9, 358);
            this.lblBgGruppeCode.Name = "lblBgGruppeCode";
            this.lblBgGruppeCode.Size = new System.Drawing.Size(76, 24);
            this.lblBgGruppeCode.TabIndex = 12;
            this.lblBgGruppeCode.Text = "Gruppe";
            this.lblBgGruppeCode.UseCompatibleTextRendering = true;
            // 
            // edtBgGruppeCode
            // 
            this.edtBgGruppeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgGruppeCode.DataMember = "BgGruppeCode";
            this.edtBgGruppeCode.DataSource = this.qryBgPositionsart;
            this.edtBgGruppeCode.Location = new System.Drawing.Point(91, 358);
            this.edtBgGruppeCode.LOVName = "BgGruppe";
            this.edtBgGruppeCode.Name = "edtBgGruppeCode";
            this.edtBgGruppeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGruppeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGruppeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBgGruppeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCode.Properties.NullText = "";
            this.edtBgGruppeCode.Properties.ShowFooter = false;
            this.edtBgGruppeCode.Properties.ShowHeader = false;
            this.edtBgGruppeCode.Size = new System.Drawing.Size(461, 24);
            this.edtBgGruppeCode.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Location = new System.Drawing.Point(9, 388);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 24);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBgPositionsart;
            this.edtName.Location = new System.Drawing.Point(91, 388);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(461, 24);
            this.edtName.TabIndex = 15;
            // 
            // lblSortKey
            // 
            this.lblSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSortKey.Location = new System.Drawing.Point(9, 418);
            this.lblSortKey.Name = "lblSortKey";
            this.lblSortKey.Size = new System.Drawing.Size(76, 24);
            this.lblSortKey.TabIndex = 16;
            this.lblSortKey.Text = "Abfolge";
            this.lblSortKey.UseCompatibleTextRendering = true;
            // 
            // edtSortKey
            // 
            this.edtSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSortKey.DataMember = "SortKey";
            this.edtSortKey.DataSource = this.qryBgPositionsart;
            this.edtSortKey.Location = new System.Drawing.Point(91, 418);
            this.edtSortKey.Name = "edtSortKey";
            this.edtSortKey.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseFont = true;
            this.edtSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSortKey.Size = new System.Drawing.Size(52, 24);
            this.edtSortKey.TabIndex = 17;
            // 
            // lblBgKostenartID
            // 
            this.lblBgKostenartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgKostenartID.Location = new System.Drawing.Point(9, 448);
            this.lblBgKostenartID.Name = "lblBgKostenartID";
            this.lblBgKostenartID.Size = new System.Drawing.Size(76, 24);
            this.lblBgKostenartID.TabIndex = 20;
            this.lblBgKostenartID.Text = "Kostenart";
            this.lblBgKostenartID.UseCompatibleTextRendering = true;
            // 
            // edtBgKostenartID
            // 
            this.edtBgKostenartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgKostenartID.DataMember = "BgKostenartID";
            this.edtBgKostenartID.DataSource = this.qryBgPositionsart;
            this.edtBgKostenartID.Location = new System.Drawing.Point(91, 448);
            this.edtBgKostenartID.Name = "edtBgKostenartID";
            this.edtBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKostenartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 200)});
            this.edtBgKostenartID.Properties.DisplayMember = "Name";
            this.edtBgKostenartID.Properties.NullText = "";
            this.edtBgKostenartID.Properties.ShowFooter = false;
            this.edtBgKostenartID.Properties.ShowHeader = false;
            this.edtBgKostenartID.Properties.ValueMember = "BgKostenartID";
            this.edtBgKostenartID.Size = new System.Drawing.Size(461, 24);
            this.edtBgKostenartID.TabIndex = 21;
            // 
            // edtProPerson
            // 
            this.edtProPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtProPerson.DataMember = "ProPerson";
            this.edtProPerson.DataSource = this.qryBgPositionsart;
            this.edtProPerson.Location = new System.Drawing.Point(91, 478);
            this.edtProPerson.Name = "edtProPerson";
            this.edtProPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtProPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtProPerson.Properties.Caption = "Pro Person";
            this.edtProPerson.Size = new System.Drawing.Size(82, 19);
            this.edtProPerson.TabIndex = 22;
            // 
            // edtProUE
            // 
            this.edtProUE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtProUE.DataMember = "ProUE";
            this.edtProUE.DataSource = this.qryBgPositionsart;
            this.edtProUE.Location = new System.Drawing.Point(179, 478);
            this.edtProUE.Name = "edtProUE";
            this.edtProUE.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtProUE.Properties.Appearance.Options.UseBackColor = true;
            this.edtProUE.Properties.Caption = "Pro UE";
            this.edtProUE.Size = new System.Drawing.Size(60, 19);
            this.edtProUE.TabIndex = 23;
            // 
            // edtVerwaltungSD_Default
            // 
            this.edtVerwaltungSD_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerwaltungSD_Default.DataMember = "VerwaltungSD_Default";
            this.edtVerwaltungSD_Default.DataSource = this.qryBgPositionsart;
            this.edtVerwaltungSD_Default.Location = new System.Drawing.Point(245, 478);
            this.edtVerwaltungSD_Default.Name = "edtVerwaltungSD_Default";
            this.edtVerwaltungSD_Default.Properties.AllowGrayed = true;
            this.edtVerwaltungSD_Default.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerwaltungSD_Default.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwaltungSD_Default.Properties.Caption = "Verwaltung SD";
            this.edtVerwaltungSD_Default.Size = new System.Drawing.Size(101, 19);
            this.edtVerwaltungSD_Default.TabIndex = 24;
            // 
            // edtSpezkonto
            // 
            this.edtSpezkonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSpezkonto.DataMember = "Spezkonto";
            this.edtSpezkonto.DataSource = this.qryBgPositionsart;
            this.edtSpezkonto.Location = new System.Drawing.Point(91, 501);
            this.edtSpezkonto.Name = "edtSpezkonto";
            this.edtSpezkonto.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSpezkonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtSpezkonto.Properties.Caption = "Spezialkonto";
            this.edtSpezkonto.Size = new System.Drawing.Size(85, 19);
            this.edtSpezkonto.TabIndex = 25;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(9, 525);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(76, 24);
            this.lblBemerkung.TabIndex = 27;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPositionsart;
            this.edtBemerkung.Location = new System.Drawing.Point(90, 525);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(461, 70);
            this.edtBemerkung.TabIndex = 28;
            // 
            // lblBudgetMaster
            // 
            this.lblBudgetMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBudgetMaster.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblBudgetMaster.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBudgetMaster.Location = new System.Drawing.Point(568, 303);
            this.lblBudgetMaster.Name = "lblBudgetMaster";
            this.lblBudgetMaster.Size = new System.Drawing.Size(84, 15);
            this.lblBudgetMaster.TabIndex = 30;
            this.lblBudgetMaster.Text = "Masterbudget";
            this.lblBudgetMaster.UseCompatibleTextRendering = true;
            // 
            // chkEditMaskMasterLow
            // 
            this.chkEditMaskMasterLow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMasterLow.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMasterLow.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.chkEditMaskMasterLow.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMasterLow.Appearance.Options.UseBorderColor = true;
            this.chkEditMaskMasterLow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMasterLow.CheckOnClick = true;
            this.chkEditMaskMasterLow.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMasterLow.Location = new System.Drawing.Point(569, 342);
            this.chkEditMaskMasterLow.Name = "chkEditMaskMasterLow";
            this.chkEditMaskMasterLow.Size = new System.Drawing.Size(24, 209);
            this.chkEditMaskMasterLow.TabIndex = 31;
            this.chkEditMaskMasterLow.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // chkEditMaskMasterHigh
            // 
            this.chkEditMaskMasterHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMasterHigh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMasterHigh.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.chkEditMaskMasterHigh.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMasterHigh.Appearance.Options.UseBorderColor = true;
            this.chkEditMaskMasterHigh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMasterHigh.CheckOnClick = true;
            this.chkEditMaskMasterHigh.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMasterHigh.Location = new System.Drawing.Point(588, 342);
            this.chkEditMaskMasterHigh.Name = "chkEditMaskMasterHigh";
            this.chkEditMaskMasterHigh.Size = new System.Drawing.Size(22, 209);
            this.chkEditMaskMasterHigh.TabIndex = 32;
            this.chkEditMaskMasterHigh.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // lblBudgetMonat
            // 
            this.lblBudgetMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBudgetMonat.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblBudgetMonat.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBudgetMonat.Location = new System.Drawing.Point(654, 303);
            this.lblBudgetMonat.Name = "lblBudgetMonat";
            this.lblBudgetMonat.Size = new System.Drawing.Size(141, 16);
            this.lblBudgetMonat.TabIndex = 33;
            this.lblBudgetMonat.Text = "Monatsbudget";
            this.lblBudgetMonat.UseCompatibleTextRendering = true;
            // 
            // chkEditMaskMonatLow
            // 
            this.chkEditMaskMonatLow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMonatLow.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMonatLow.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.chkEditMaskMonatLow.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMonatLow.Appearance.Options.UseBorderColor = true;
            this.chkEditMaskMonatLow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMonatLow.CheckOnClick = true;
            this.chkEditMaskMonatLow.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMonatLow.Location = new System.Drawing.Point(655, 342);
            this.chkEditMaskMonatLow.Name = "chkEditMaskMonatLow";
            this.chkEditMaskMonatLow.Size = new System.Drawing.Size(24, 231);
            this.chkEditMaskMonatLow.TabIndex = 34;
            this.chkEditMaskMonatLow.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // chkEditMaskMonatHigh
            // 
            this.chkEditMaskMonatHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMonatHigh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMonatHigh.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.chkEditMaskMonatHigh.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMonatHigh.Appearance.Options.UseBorderColor = true;
            this.chkEditMaskMonatHigh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMonatHigh.CheckOnClick = true;
            this.chkEditMaskMonatHigh.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMonatHigh.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Löschen"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrag -"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrag +"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Neu"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Gruppe"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Art"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Text"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrifft Person"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Bemerkung"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrag Rechnung"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Gruppe (Filter)")});
            this.chkEditMaskMonatHigh.Location = new System.Drawing.Point(674, 342);
            this.chkEditMaskMonatHigh.Name = "chkEditMaskMonatHigh";
            this.chkEditMaskMonatHigh.Size = new System.Drawing.Size(122, 209);
            this.chkEditMaskMonatHigh.TabIndex = 35;
            this.chkEditMaskMonatHigh.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // qryBgKostenart
            // 
            this.qryBgKostenart.HostControl = this;
            this.qryBgKostenart.SelectStatement = resources.GetString("qryBgKostenart.SelectStatement");
            // 
            // edtBgPositionsartCode
            // 
            this.edtBgPositionsartCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgPositionsartCode.DataMember = "BgPositionsartCode";
            this.edtBgPositionsartCode.DataSource = this.qryBgPositionsart;
            this.edtBgPositionsartCode.Location = new System.Drawing.Point(202, 298);
            this.edtBgPositionsartCode.Name = "edtBgPositionsartCode";
            this.edtBgPositionsartCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBgPositionsartCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsartCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgPositionsartCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartCode.Size = new System.Drawing.Size(68, 24);
            this.edtBgPositionsartCode.TabIndex = 5;
            // 
            // lblBgPositionsartCode
            // 
            this.lblBgPositionsartCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgPositionsartCode.Location = new System.Drawing.Point(165, 298);
            this.lblBgPositionsartCode.Name = "lblBgPositionsartCode";
            this.lblBgPositionsartCode.Size = new System.Drawing.Size(31, 24);
            this.lblBgPositionsartCode.TabIndex = 4;
            this.lblBgPositionsartCode.Text = "Nr";
            this.lblBgPositionsartCode.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBgPositionsart;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(313, 298);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 7;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumVon.Location = new System.Drawing.Point(276, 298);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(31, 24);
            this.lblDatumVon.TabIndex = 6;
            this.lblDatumVon.Text = "Von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumBis.Location = new System.Drawing.Point(419, 298);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(31, 24);
            this.lblDatumBis.TabIndex = 8;
            this.lblDatumBis.Text = "Bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBgPositionsart;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(452, 298);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(590, 323);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(570, 323);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(676, 323);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(656, 323);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // edtBFSVariable
            // 
            this.edtBFSVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBFSVariable.DataMember = "VarName";
            this.edtBFSVariable.DataSource = this.qryBgPositionsart;
            this.edtBFSVariable.Location = new System.Drawing.Point(232, 419);
            this.edtBFSVariable.Name = "edtBFSVariable";
            this.edtBFSVariable.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSVariable.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSVariable.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSVariable.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSVariable.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSVariable.Properties.Appearance.Options.UseFont = true;
            this.edtBFSVariable.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBFSVariable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBFSVariable.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSVariable.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBFSVariable.Size = new System.Drawing.Size(181, 24);
            this.edtBFSVariable.TabIndex = 19;
            this.edtBFSVariable.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBFSVariable_UserModifiedFld);
            // 
            // lblBFSVariable
            // 
            this.lblBFSVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBFSVariable.Location = new System.Drawing.Point(155, 418);
            this.lblBFSVariable.Name = "lblBFSVariable";
            this.lblBFSVariable.Size = new System.Drawing.Size(71, 24);
            this.lblBFSVariable.TabIndex = 18;
            this.lblBFSVariable.Text = "BFS Variable";
            this.lblBFSVariable.UseCompatibleTextRendering = true;
            // 
            // chkNurAktive
            // 
            this.chkNurAktive.EditValue = true;
            this.chkNurAktive.Location = new System.Drawing.Point(117, 160);
            this.chkNurAktive.Name = "chkNurAktive";
            this.chkNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.chkNurAktive.Properties.Caption = "Nur Aktive";
            this.chkNurAktive.Size = new System.Drawing.Size(144, 19);
            this.chkNurAktive.TabIndex = 9;
            // 
            // edtSystem
            // 
            this.edtSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSystem.DataMember = "System";
            this.edtSystem.DataSource = this.qryBgPositionsart;
            this.edtSystem.Location = new System.Drawing.Point(477, 501);
            this.edtSystem.Name = "edtSystem";
            this.edtSystem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSystem.Properties.Appearance.Options.UseBackColor = true;
            this.edtSystem.Properties.Caption = "System";
            this.edtSystem.Size = new System.Drawing.Size(74, 19);
            this.edtSystem.TabIndex = 29;
            // 
            // edtVerrechenbar
            // 
            this.edtVerrechenbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerrechenbar.DataMember = "Verrechenbar";
            this.edtVerrechenbar.DataSource = this.qryBgPositionsart;
            this.edtVerrechenbar.Location = new System.Drawing.Point(179, 501);
            this.edtVerrechenbar.Name = "edtVerrechenbar";
            this.edtVerrechenbar.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerrechenbar.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerrechenbar.Properties.Caption = "WV";
            this.edtVerrechenbar.Size = new System.Drawing.Size(39, 19);
            this.edtVerrechenbar.TabIndex = 26;
            // 
            // edtKreditorEingeschraenkt
            // 
            this.edtKreditorEingeschraenkt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKreditorEingeschraenkt.DataMember = "KreditorEingeschraenkt";
            this.edtKreditorEingeschraenkt.DataSource = this.qryBgPositionsart;
            this.edtKreditorEingeschraenkt.Location = new System.Drawing.Point(245, 501);
            this.edtKreditorEingeschraenkt.Name = "edtKreditorEingeschraenkt";
            this.edtKreditorEingeschraenkt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorEingeschraenkt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorEingeschraenkt.Properties.Caption = "Kreditor eingeschränkt";
            this.edtKreditorEingeschraenkt.Size = new System.Drawing.Size(135, 19);
            this.edtKreditorEingeschraenkt.TabIndex = 37;
            // 
            // edtErzeugtBfsDossier
            // 
            this.edtErzeugtBfsDossier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErzeugtBfsDossier.DataMember = "ErzeugtBfsDossier";
            this.edtErzeugtBfsDossier.DataSource = this.qryBgPositionsart;
            this.edtErzeugtBfsDossier.Location = new System.Drawing.Point(430, 421);
            this.edtErzeugtBfsDossier.Name = "edtErzeugtBfsDossier";
            this.edtErzeugtBfsDossier.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErzeugtBfsDossier.Properties.Appearance.Options.UseBackColor = true;
            this.edtErzeugtBfsDossier.Properties.Caption = "Erzeugt BFS-Dossier";
            this.edtErzeugtBfsDossier.Size = new System.Drawing.Size(122, 19);
            this.edtErzeugtBfsDossier.TabIndex = 38;
            // 
            // colVarName
            // 
            this.colVarName.Caption = "BFS Variable";
            this.colVarName.FieldName = "VarName";
            this.colVarName.Name = "colVarName";
            this.colVarName.Visible = true;
            this.colVarName.VisibleIndex = 11;
            // 
            // CtlBgPositionsart
            // 
            this.ActiveSQLQuery = this.qryBgPositionsart;
            this.Controls.Add(this.edtErzeugtBfsDossier);
            this.Controls.Add(this.edtKreditorEingeschraenkt);
            this.Controls.Add(this.edtVerrechenbar);
            this.Controls.Add(this.edtBFSVariable);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.edtBgPositionsartCode);
            this.Controls.Add(this.lblBFSVariable);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblBgPositionsartCode);
            this.Controls.Add(this.chkEditMaskMonatHigh);
            this.Controls.Add(this.chkEditMaskMonatLow);
            this.Controls.Add(this.lblBudgetMonat);
            this.Controls.Add(this.chkEditMaskMasterHigh);
            this.Controls.Add(this.chkEditMaskMasterLow);
            this.Controls.Add(this.lblBudgetMaster);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtSystem);
            this.Controls.Add(this.edtSpezkonto);
            this.Controls.Add(this.edtVerwaltungSD_Default);
            this.Controls.Add(this.edtProUE);
            this.Controls.Add(this.edtProPerson);
            this.Controls.Add(this.edtBgKostenartID);
            this.Controls.Add(this.lblBgKostenartID);
            this.Controls.Add(this.edtSortKey);
            this.Controls.Add(this.lblSortKey);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.edtBgGruppeCode);
            this.Controls.Add(this.lblBgGruppeCode);
            this.Controls.Add(this.edtBgKategorieCode);
            this.Controls.Add(this.lblBgKategorieCode);
            this.Controls.Add(this.edtBgPositionsartID);
            this.Controls.Add(this.lblBgPositionsartID);
            this.Controls.Add(this.editReadOnly);
            this.Name = "CtlBgPositionsart";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.CtlBgPositionsart_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.editReadOnly, 0);
            this.Controls.SetChildIndex(this.lblBgPositionsartID, 0);
            this.Controls.SetChildIndex(this.edtBgPositionsartID, 0);
            this.Controls.SetChildIndex(this.lblBgKategorieCode, 0);
            this.Controls.SetChildIndex(this.edtBgKategorieCode, 0);
            this.Controls.SetChildIndex(this.lblBgGruppeCode, 0);
            this.Controls.SetChildIndex(this.edtBgGruppeCode, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.lblSortKey, 0);
            this.Controls.SetChildIndex(this.edtSortKey, 0);
            this.Controls.SetChildIndex(this.lblBgKostenartID, 0);
            this.Controls.SetChildIndex(this.edtBgKostenartID, 0);
            this.Controls.SetChildIndex(this.edtProPerson, 0);
            this.Controls.SetChildIndex(this.edtProUE, 0);
            this.Controls.SetChildIndex(this.edtVerwaltungSD_Default, 0);
            this.Controls.SetChildIndex(this.edtSpezkonto, 0);
            this.Controls.SetChildIndex(this.edtSystem, 0);
            this.Controls.SetChildIndex(this.lblBemerkung, 0);
            this.Controls.SetChildIndex(this.edtBemerkung, 0);
            this.Controls.SetChildIndex(this.lblBudgetMaster, 0);
            this.Controls.SetChildIndex(this.chkEditMaskMasterLow, 0);
            this.Controls.SetChildIndex(this.chkEditMaskMasterHigh, 0);
            this.Controls.SetChildIndex(this.lblBudgetMonat, 0);
            this.Controls.SetChildIndex(this.chkEditMaskMonatLow, 0);
            this.Controls.SetChildIndex(this.chkEditMaskMonatHigh, 0);
            this.Controls.SetChildIndex(this.lblBgPositionsartCode, 0);
            this.Controls.SetChildIndex(this.lblDatumVon, 0);
            this.Controls.SetChildIndex(this.lblDatumBis, 0);
            this.Controls.SetChildIndex(this.lblBFSVariable, 0);
            this.Controls.SetChildIndex(this.edtBgPositionsartCode, 0);
            this.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.edtBFSVariable, 0);
            this.Controls.SetChildIndex(this.edtVerrechenbar, 0);
            this.Controls.SetChildIndex(this.edtKreditorEingeschraenkt, 0);
            this.Controls.SetChildIndex(this.edtErzeugtBfsDossier, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKategorieCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProUE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD_Default.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSpezkonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudgetMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudgetMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSVariable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSVariable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerrechenbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorEingeschraenkt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErzeugtBfsDossier.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMasterHigh;
        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMasterLow;
        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMonatHigh;
        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMonatLow;
        private KiSS4.Gui.KissCheckEdit chkNurAktive;
        private DevExpress.XtraGrid.Columns.GridColumn colBgGruppeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKategorieCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKostenartID;
        private DevExpress.XtraGrid.Columns.GridColumn colBgPositionsartCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSD;
        private DevExpress.XtraGrid.Columns.GridColumn colSpezkonto;
        private DevExpress.XtraGrid.Columns.GridColumn colUE;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCheckEdit editReadOnly;
        private KiSS4.Gui.KissButtonEdit edtBFSVariable;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtBgGruppeCode;
        private KiSS4.Gui.KissLookUpEdit edtBgGruppeCodeX;
        private KiSS4.Gui.KissLookUpEdit edtBgKategorieCode;
        private KiSS4.Gui.KissLookUpEdit edtBgKategorieCodeX;
        private KiSS4.Gui.KissLookUpEdit edtBgKostenartID;
        private KiSS4.Gui.KissLookUpEdit edtBgKostenartIDX;
        private KiSS4.Gui.KissCalcEdit edtBgPositionsartCode;
        private KiSS4.Gui.KissCalcEdit edtBgPositionsartID;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KiSS4.Gui.KissCheckEdit edtProPerson;
        private KiSS4.Gui.KissCheckEdit edtProUE;
        private KiSS4.Gui.KissCalcEdit edtSortKey;
        private KiSS4.Gui.KissCheckEdit edtSpezkonto;
        private KiSS4.Gui.KissCheckEdit edtSystem;
        private KiSS4.Gui.KissCheckEdit edtVerrechenbar;
        private KiSS4.Gui.KissCheckEdit edtVerwaltungSD_Default;
        private KiSS4.Gui.KissGrid grdBgPositionsart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPositionsart;
        private KiSS4.Gui.KissLabel lblBFSVariable;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBgGruppeCode;
        private KiSS4.Gui.KissLabel lblBgKategorieCode;
        private KiSS4.Gui.KissLabel lblBgKostenartID;
        private KiSS4.Gui.KissLabel lblBgPositionsartCode;
        private KiSS4.Gui.KissLabel lblBgPositionsartID;
        private KiSS4.Gui.KissLabel lblBudgetMaster;
        private KiSS4.Gui.KissLabel lblBudgetMonat;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblSortKey;
        private KiSS4.Gui.KissLabel lblSucheGruppe;
        private KiSS4.Gui.KissLabel lblSucheKategorie;
        private KiSS4.Gui.KissLabel lblSucheKostenart;
        private KiSS4.Gui.KissLabel lblSucheName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private KiSS4.DB.SqlQuery qryBgKostenart;
        private KiSS4.DB.SqlQuery qryBgPositionsart;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private KiSS4.Gui.KissCheckEdit edtKreditorEingeschraenkt;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private Gui.KissCheckEdit edtErzeugtBfsDossier;
        private DevExpress.XtraGrid.Columns.GridColumn colVarName;
    }
}
