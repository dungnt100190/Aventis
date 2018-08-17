namespace KiSS4.Administration
{
    partial class CtlDocTemplate
    {
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDocTemplate));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdDocTemplate = new KiSS4.Gui.KissGrid();
            this.qryDocTemplate = new KiSS4.DB.SqlQuery();
            this.grvDocTemplate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocFormatCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemDocumentFormatImg = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgList = new System.Windows.Forms.ImageList();
            this.colDocTemplateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfileTags = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPublicTemplate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDocTemplateName = new KiSS4.Gui.KissLabel();
            this.edtDocTemplateName = new KiSS4.Gui.KissTextEdit();
            this.edtDocTemplate = new KiSS4.Dokument.XDokument();
            this.lblDocTemplate = new KiSS4.Gui.KissLabel();
            this.tabDocumentTemplate = new KiSS4.Gui.KissTabControlEx();
            this.tpgDetail = new SharpLibrary.WinControls.TabPageEx();
            this.tpgAbteilungen = new SharpLibrary.WinControls.TabPageEx();
            this.edtAbteilungen = new KiSS4.Gui.KissDoubleListSelector();
            this.tpgBenutzer = new SharpLibrary.WinControls.TabPageEx();
            this.edtBenutzer = new KiSS4.Gui.KissDoubleListSelector();
            this.tpgProfile = new SharpLibrary.WinControls.TabPageEx();
            this.edtProfileTags = new KiSS4.Common.CtlProfileTagsControl();
            this.lblProfileTags = new KiSS4.Gui.KissLabel();
            this.tpgKontexte = new SharpLibrary.WinControls.TabPageEx();
            this.grdKontext = new KiSS4.Gui.KissGrid();
            this.qryKontexte = new KiSS4.DB.SqlQuery();
            this.grvKontext = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocContextName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.qryAssignedXOrgUnits = new KiSS4.DB.SqlQuery();
            this.edtNameSuche = new KiSS4.Gui.KissTextEdit();
            this.qryAssignedUsers = new KiSS4.DB.SqlQuery();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.panDetails = new System.Windows.Forms.Panel();
            this.edtSucheFormat = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheFormat = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemDocumentFormatImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplate)).BeginInit();
            this.tabDocumentTemplate.SuspendLayout();
            this.tpgDetail.SuspendLayout();
            this.tpgAbteilungen.SuspendLayout();
            this.tpgBenutzer.SuspendLayout();
            this.tpgProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTags)).BeginInit();
            this.tpgKontexte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontexte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAssignedXOrgUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSuche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAssignedUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFormat)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(685, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(709, 335);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdDocTemplate);
            this.tpgListe.Size = new System.Drawing.Size(697, 297);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheFormat);
            this.tpgSuchen.Controls.Add(this.lblSucheFormat);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.edtNameSuche);
            this.tpgSuchen.Size = new System.Drawing.Size(697, 297);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFormat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFormat, 0);
            // 
            // grdDocTemplate
            // 
            this.grdDocTemplate.DataSource = this.qryDocTemplate;
            this.grdDocTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdDocTemplate.EmbeddedNavigator.Name = "";
            this.grdDocTemplate.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDocTemplate.Location = new System.Drawing.Point(0, 0);
            this.grdDocTemplate.MainView = this.grvDocTemplate;
            this.grdDocTemplate.Name = "grdDocTemplate";
            this.grdDocTemplate.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemDocumentFormatImg});
            this.grdDocTemplate.Size = new System.Drawing.Size(697, 297);
            this.grdDocTemplate.TabIndex = 0;
            this.grdDocTemplate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDocTemplate});
            this.grdDocTemplate.DoubleClick += new System.EventHandler(this.gridVorlagen_DoubleClick);
            // 
            // qryDocTemplate
            // 
            this.qryDocTemplate.CanDelete = true;
            this.qryDocTemplate.CanInsert = true;
            this.qryDocTemplate.CanUpdate = true;
            this.qryDocTemplate.HostControl = this;
            this.qryDocTemplate.SelectStatement = resources.GetString("qryDocTemplate.SelectStatement");
            this.qryDocTemplate.TableName = "XDocTemplate";
            this.qryDocTemplate.AfterFill += new System.EventHandler(this.qryDocTemplate_AfterFill);
            this.qryDocTemplate.AfterInsert += new System.EventHandler(this.qryDocTemplate_AfterInsert);
            this.qryDocTemplate.BeforePost += new System.EventHandler(this.qryTemplate_BeforePost);
            this.qryDocTemplate.AfterPost += new System.EventHandler(this.qryDocTemplate_AfterPost);
            this.qryDocTemplate.BeforeDeleteQuestion += new System.EventHandler(this.qryDocTemplate_BeforeDeleteQuestion);
            this.qryDocTemplate.BeforeDelete += new System.EventHandler(this.qryDocTemplate_BeforeDelete);
            this.qryDocTemplate.AfterDelete += new System.EventHandler(this.qryDocTemplate_AfterDelete);
            this.qryDocTemplate.PositionChanged += new System.EventHandler(this.qryTemplate_PositionChanged);
            // 
            // grvDocTemplate
            // 
            this.grvDocTemplate.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDocTemplate.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.Empty.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.Empty.Options.UseFont = true;
            this.grvDocTemplate.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.EvenRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocTemplate.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDocTemplate.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDocTemplate.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocTemplate.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDocTemplate.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocTemplate.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocTemplate.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocTemplate.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocTemplate.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.GroupRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDocTemplate.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDocTemplate.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocTemplate.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDocTemplate.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDocTemplate.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDocTemplate.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocTemplate.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocTemplate.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.OddRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDocTemplate.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.Row.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.Row.Options.UseFont = true;
            this.grvDocTemplate.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocTemplate.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDocTemplate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDocTemplate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocFormatCode,
            this.colDocTemplateName,
            this.colDateCreation,
            this.colDateLastSave,
            this.colProfileTags,
            this.colPublicTemplate});
            this.grvDocTemplate.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDocTemplate.GridControl = this.grdDocTemplate;
            this.grvDocTemplate.Name = "grvDocTemplate";
            this.grvDocTemplate.OptionsBehavior.Editable = false;
            this.grvDocTemplate.OptionsCustomization.AllowFilter = false;
            this.grvDocTemplate.OptionsFilter.AllowFilterEditor = false;
            this.grvDocTemplate.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDocTemplate.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDocTemplate.OptionsNavigation.UseTabKey = false;
            this.grvDocTemplate.OptionsView.ColumnAutoWidth = false;
            this.grvDocTemplate.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDocTemplate.OptionsView.ShowGroupPanel = false;
            this.grvDocTemplate.OptionsView.ShowIndicator = false;
            // 
            // colDocFormatCode
            // 
            this.colDocFormatCode.AppearanceCell.Options.UseTextOptions = true;
            this.colDocFormatCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDocFormatCode.Caption = "Format";
            this.colDocFormatCode.ColumnEdit = this.repItemDocumentFormatImg;
            this.colDocFormatCode.FieldName = "DocFormat";
            this.colDocFormatCode.Name = "colDocFormatCode";
            this.colDocFormatCode.Visible = true;
            this.colDocFormatCode.VisibleIndex = 0;
            this.colDocFormatCode.Width = 65;
            // 
            // repItemDocumentFormatImg
            // 
            this.repItemDocumentFormatImg.AutoHeight = false;
            this.repItemDocumentFormatImg.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemDocumentFormatImg.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Word", "word", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Excel", "excel", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Other", "other", 3)});
            this.repItemDocumentFormatImg.Name = "repItemDocumentFormatImg";
            this.repItemDocumentFormatImg.SmallImages = this.imgList;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Magenta;
            this.imgList.Images.SetKeyName(0, "FolderImgList");
            this.imgList.Images.SetKeyName(1, "WordImgList");
            this.imgList.Images.SetKeyName(2, "ExcelImgList");
            this.imgList.Images.SetKeyName(3, "DocumentImgList");
            // 
            // colDocTemplateName
            // 
            this.colDocTemplateName.Caption = "Name der Vorlage";
            this.colDocTemplateName.FieldName = "DocTemplateName";
            this.colDocTemplateName.Name = "colDocTemplateName";
            this.colDocTemplateName.Visible = true;
            this.colDocTemplateName.VisibleIndex = 1;
            this.colDocTemplateName.Width = 342;
            // 
            // colDateCreation
            // 
            this.colDateCreation.Caption = "Erzeugt";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 2;
            this.colDateCreation.Width = 78;
            // 
            // colDateLastSave
            // 
            this.colDateLastSave.Caption = "Verändert";
            this.colDateLastSave.FieldName = "DateLastSave";
            this.colDateLastSave.Name = "colDateLastSave";
            this.colDateLastSave.Visible = true;
            this.colDateLastSave.VisibleIndex = 3;
            this.colDateLastSave.Width = 76;
            // 
            // colProfileTags
            // 
            this.colProfileTags.Caption = "Merkmale";
            this.colProfileTags.FieldName = "ProfileTags";
            this.colProfileTags.Name = "colProfileTags";
            this.colProfileTags.Visible = true;
            this.colProfileTags.VisibleIndex = 4;
            this.colProfileTags.Width = 150;
            // 
            // colPublicTemplate
            // 
            this.colPublicTemplate.Caption = "Öffentlich";
            this.colPublicTemplate.FieldName = "PublicTemplate";
            this.colPublicTemplate.Name = "colPublicTemplate";
            this.colPublicTemplate.Visible = true;
            this.colPublicTemplate.VisibleIndex = 5;
            // 
            // lblDocTemplateName
            // 
            this.lblDocTemplateName.Location = new System.Drawing.Point(9, 9);
            this.lblDocTemplateName.Name = "lblDocTemplateName";
            this.lblDocTemplateName.Size = new System.Drawing.Size(122, 24);
            this.lblDocTemplateName.TabIndex = 0;
            this.lblDocTemplateName.Text = "Name der Vorlage";
            // 
            // edtDocTemplateName
            // 
            this.edtDocTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDocTemplateName.DataMember = "DocTemplateName";
            this.edtDocTemplateName.DataSource = this.qryDocTemplate;
            this.edtDocTemplateName.Location = new System.Drawing.Point(137, 9);
            this.edtDocTemplateName.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtDocTemplateName.Name = "edtDocTemplateName";
            this.edtDocTemplateName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocTemplateName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocTemplateName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocTemplateName.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocTemplateName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocTemplateName.Properties.Appearance.Options.UseFont = true;
            this.edtDocTemplateName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDocTemplateName.Size = new System.Drawing.Size(551, 24);
            this.edtDocTemplateName.TabIndex = 1;
            // 
            // edtDocTemplate
            // 
            this.edtDocTemplate.Context = null;
            this.edtDocTemplate.DataSource = this.qryDocTemplate;
            this.edtDocTemplate.EditValue = "";
            this.edtDocTemplate.Location = new System.Drawing.Point(137, 39);
            this.edtDocTemplate.Name = "edtDocTemplate";
            this.edtDocTemplate.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocTemplate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocTemplate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocTemplate.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocTemplate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocTemplate.Properties.Appearance.Options.UseFont = true;
            this.edtDocTemplate.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocTemplate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.edtDocTemplate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDocTemplate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtDocTemplate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocTemplate.Properties.Name = "fProperties";
            this.edtDocTemplate.Properties.ReadOnly = true;
            this.edtDocTemplate.Size = new System.Drawing.Size(134, 24);
            this.edtDocTemplate.TabIndex = 3;
            this.edtDocTemplate.DocumentImporting += new System.ComponentModel.CancelEventHandler(this.edtDocTemplate_DocumentImporting);
            this.edtDocTemplate.DocumentOpening += new System.ComponentModel.CancelEventHandler(this.edtDocTemplate_DocumentOpening);
            // 
            // lblDocTemplate
            // 
            this.lblDocTemplate.Location = new System.Drawing.Point(9, 39);
            this.lblDocTemplate.Name = "lblDocTemplate";
            this.lblDocTemplate.Size = new System.Drawing.Size(122, 24);
            this.lblDocTemplate.TabIndex = 2;
            this.lblDocTemplate.Text = "Vorlage";
            // 
            // tabDocumentTemplate
            // 
            this.tabDocumentTemplate.Controls.Add(this.tpgDetail);
            this.tabDocumentTemplate.Controls.Add(this.tpgAbteilungen);
            this.tabDocumentTemplate.Controls.Add(this.tpgBenutzer);
            this.tabDocumentTemplate.Controls.Add(this.tpgProfile);
            this.tabDocumentTemplate.Controls.Add(this.tpgKontexte);
            this.tabDocumentTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDocumentTemplate.Location = new System.Drawing.Point(0, 0);
            this.tabDocumentTemplate.Name = "tabDocumentTemplate";
            this.tabDocumentTemplate.SelectedTabIndex = 4;
            this.tabDocumentTemplate.ShowFixedWidthTooltip = true;
            this.tabDocumentTemplate.Size = new System.Drawing.Size(709, 259);
            this.tabDocumentTemplate.TabIndex = 0;
            this.tabDocumentTemplate.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgDetail,
            this.tpgAbteilungen,
            this.tpgBenutzer,
            this.tpgProfile,
            this.tpgKontexte});
            this.tabDocumentTemplate.TabsLineColor = System.Drawing.Color.Black;
            this.tabDocumentTemplate.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabDocumentTemplate.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabDocumentTemplate.Text = "kissTabControlEx1";
            // 
            // tpgDetail
            // 
            this.tpgDetail.Controls.Add(this.lblDocTemplateName);
            this.tpgDetail.Controls.Add(this.edtDocTemplate);
            this.tpgDetail.Controls.Add(this.lblDocTemplate);
            this.tpgDetail.Controls.Add(this.edtDocTemplateName);
            this.tpgDetail.Location = new System.Drawing.Point(6, 32);
            this.tpgDetail.Name = "tpgDetail";
            this.tpgDetail.Size = new System.Drawing.Size(697, 221);
            this.tpgDetail.TabIndex = 0;
            this.tpgDetail.Title = "Details";
            // 
            // tpgAbteilungen
            // 
            this.tpgAbteilungen.Controls.Add(this.edtAbteilungen);
            this.tpgAbteilungen.Location = new System.Drawing.Point(6, 32);
            this.tpgAbteilungen.Name = "tpgAbteilungen";
            this.tpgAbteilungen.Size = new System.Drawing.Size(697, 221);
            this.tpgAbteilungen.TabIndex = 1;
            this.tpgAbteilungen.Title = "Zuweisungen Abteilungen";
            // 
            // edtAbteilungen
            // 
            this.edtAbteilungen.ButtonRemoveAllVisible = false;
            this.edtAbteilungen.Location = new System.Drawing.Point(9, 9);
            this.edtAbteilungen.MaximumSize = new System.Drawing.Size(580, 210);
            this.edtAbteilungen.MinimumSize = new System.Drawing.Size(580, 210);
            this.edtAbteilungen.Name = "edtAbteilungen";
            this.edtAbteilungen.Size = new System.Drawing.Size(580, 210);
            this.edtAbteilungen.TabIndex = 0;
            this.edtAbteilungen.AddItemClick += new KiSS4.Gui.KissDoubleListSelectorEventHandler(this.edtAbteilungen_AddItemClick);
            this.edtAbteilungen.RemoveAllItemsClick += new System.EventHandler(this.edtAbteilungen_RemoveAllItemsClick);
            this.edtAbteilungen.RemoveItemClick += new KiSS4.Gui.KissDoubleListSelectorEventHandler(this.edtAbteilungen_RemoveItemClick);
            this.edtAbteilungen.SelectionChanged += new System.EventHandler(this.edtAbteilungen_SelectionChanged);
            // 
            // tpgBenutzer
            // 
            this.tpgBenutzer.Controls.Add(this.edtBenutzer);
            this.tpgBenutzer.Location = new System.Drawing.Point(6, 32);
            this.tpgBenutzer.Name = "tpgBenutzer";
            this.tpgBenutzer.Size = new System.Drawing.Size(697, 221);
            this.tpgBenutzer.TabIndex = 2;
            this.tpgBenutzer.Title = "Zuweisungen Benutzer";
            // 
            // edtBenutzer
            // 
            this.edtBenutzer.ButtonRemoveAllVisible = false;
            this.edtBenutzer.Location = new System.Drawing.Point(9, 9);
            this.edtBenutzer.MaximumSize = new System.Drawing.Size(580, 210);
            this.edtBenutzer.MinimumSize = new System.Drawing.Size(580, 210);
            this.edtBenutzer.Name = "edtBenutzer";
            this.edtBenutzer.Size = new System.Drawing.Size(580, 210);
            this.edtBenutzer.TabIndex = 0;
            this.edtBenutzer.AddItemClick += new KiSS4.Gui.KissDoubleListSelectorEventHandler(this.edtBenutzer_AddItemClick);
            this.edtBenutzer.RemoveAllItemsClick += new System.EventHandler(this.edtBenutzer_RemoveAllItemsClick);
            this.edtBenutzer.RemoveItemClick += new KiSS4.Gui.KissDoubleListSelectorEventHandler(this.edtBenutzer_RemoveItemClick);
            this.edtBenutzer.SelectionChanged += new System.EventHandler(this.edtBenutzer_SelectionChanged);
            // 
            // tpgProfile
            // 
            this.tpgProfile.Controls.Add(this.edtProfileTags);
            this.tpgProfile.Controls.Add(this.lblProfileTags);
            this.tpgProfile.Location = new System.Drawing.Point(6, 32);
            this.tpgProfile.Name = "tpgProfile";
            this.tpgProfile.Size = new System.Drawing.Size(697, 221);
            this.tpgProfile.TabIndex = 3;
            this.tpgProfile.Title = "Vorlagenprofil";
            // 
            // edtProfileTags
            // 
            this.edtProfileTags.ActiveSQLQuery = this.qryDocTemplate;
            this.edtProfileTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtProfileTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(159)))), ((int)(((byte)(96)))));
            this.edtProfileTags.DisplayMember = "ProfileTags";
            this.edtProfileTags.IsOnCtlProfile = false;
            this.edtProfileTags.Location = new System.Drawing.Point(9, 36);
            this.edtProfileTags.Margin = new System.Windows.Forms.Padding(9, 3, 9, 9);
            this.edtProfileTags.Name = "edtProfileTags";
            this.edtProfileTags.Padding = new System.Windows.Forms.Padding(1);
            this.edtProfileTags.Size = new System.Drawing.Size(679, 176);
            this.edtProfileTags.TabIndex = 1;
            // 
            // lblProfileTags
            // 
            this.lblProfileTags.Location = new System.Drawing.Point(9, 9);
            this.lblProfileTags.Name = "lblProfileTags";
            this.lblProfileTags.Size = new System.Drawing.Size(211, 24);
            this.lblProfileTags.TabIndex = 0;
            this.lblProfileTags.Text = "Merkmale dieser Vorlage";
            // 
            // tpgKontexte
            // 
            this.tpgKontexte.Controls.Add(this.grdKontext);
            this.tpgKontexte.Location = new System.Drawing.Point(6, 32);
            this.tpgKontexte.Name = "tpgKontexte";
            this.tpgKontexte.Size = new System.Drawing.Size(697, 221);
            this.tpgKontexte.TabIndex = 4;
            this.tpgKontexte.Title = "Kontexte";
            // 
            // grdKontext
            // 
            this.grdKontext.DataSource = this.qryKontexte;
            this.grdKontext.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKontext.EmbeddedNavigator.Name = "";
            this.grdKontext.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKontext.Location = new System.Drawing.Point(0, 0);
            this.grdKontext.MainView = this.grvKontext;
            this.grdKontext.Name = "grdKontext";
            this.grdKontext.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdKontext.Size = new System.Drawing.Size(697, 221);
            this.grdKontext.TabIndex = 1;
            this.grdKontext.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKontext});
            this.grdKontext.Load += new System.EventHandler(this.grdKontext_Load);
            // 
            // qryKontexte
            // 
            this.qryKontexte.CanDelete = true;
            this.qryKontexte.CanInsert = true;
            this.qryKontexte.CanUpdate = true;
            this.qryKontexte.HostControl = this;
            this.qryKontexte.SelectStatement = "SELECT DocContextName, Description\r\nFROM  dbo.XDocContext_Template DCT \r\nINNER JO" +
                "IN dbo.XDocContext XDC ON DCT.DocContextID = XDC.DocContextID\r\nWHERE DocTemplate" +
                "ID = {0}\r\nORDER BY DocContextName";
            this.qryKontexte.TableName = "XDocContext";
            // 
            // grvKontext
            // 
            this.grvKontext.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKontext.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.Empty.Options.UseBackColor = true;
            this.grvKontext.Appearance.Empty.Options.UseFont = true;
            this.grvKontext.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.EvenRow.Options.UseFont = true;
            this.grvKontext.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontext.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKontext.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKontext.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKontext.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKontext.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontext.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKontext.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKontext.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKontext.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKontext.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontext.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKontext.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontext.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontext.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontext.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKontext.Appearance.GroupRow.Options.UseFont = true;
            this.grvKontext.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKontext.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKontext.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKontext.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontext.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKontext.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKontext.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKontext.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKontext.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontext.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKontext.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKontext.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKontext.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontext.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKontext.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.OddRow.Options.UseFont = true;
            this.grvKontext.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKontext.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.Row.Options.UseBackColor = true;
            this.grvKontext.Appearance.Row.Options.UseFont = true;
            this.grvKontext.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontext.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKontext.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontext.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKontext.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKontext.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocContextName,
            this.colDescription});
            this.grvKontext.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKontext.GridControl = this.grdKontext;
            this.grvKontext.Name = "grvKontext";
            this.grvKontext.OptionsBehavior.Editable = false;
            this.grvKontext.OptionsCustomization.AllowFilter = false;
            this.grvKontext.OptionsFilter.AllowFilterEditor = false;
            this.grvKontext.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKontext.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKontext.OptionsNavigation.UseTabKey = false;
            this.grvKontext.OptionsView.ColumnAutoWidth = false;
            this.grvKontext.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKontext.OptionsView.ShowGroupPanel = false;
            this.grvKontext.OptionsView.ShowIndicator = false;
            // 
            // colDocContextName
            // 
            this.colDocContextName.AppearanceCell.Options.UseTextOptions = true;
            this.colDocContextName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDocContextName.Caption = "Kontext";
            this.colDocContextName.FieldName = "DocContextName";
            this.colDocContextName.Name = "colDocContextName";
            this.colDocContextName.OptionsColumn.FixedWidth = true;
            this.colDocContextName.Visible = true;
            this.colDocContextName.VisibleIndex = 0;
            this.colDocContextName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 500;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Word", "word", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Excel", "excel", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Other", "other", 3)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imgList;
            // 
            // qryAssignedXOrgUnits
            // 
            this.qryAssignedXOrgUnits.CanDelete = true;
            this.qryAssignedXOrgUnits.CanInsert = true;
            this.qryAssignedXOrgUnits.CanUpdate = true;
            this.qryAssignedXOrgUnits.HostControl = this;
            this.qryAssignedXOrgUnits.SelectStatement = resources.GetString("qryAssignedXOrgUnits.SelectStatement");
            this.qryAssignedXOrgUnits.TableName = "XOrgUnit_XDocTemplate";
            // 
            // edtNameSuche
            // 
            this.edtNameSuche.DataSource = this.qryDocTemplate;
            this.edtNameSuche.Location = new System.Drawing.Point(154, 40);
            this.edtNameSuche.Name = "edtNameSuche";
            this.edtNameSuche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSuche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSuche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSuche.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSuche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSuche.Properties.Appearance.Options.UseFont = true;
            this.edtNameSuche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameSuche.Size = new System.Drawing.Size(280, 24);
            this.edtNameSuche.TabIndex = 2;
            // 
            // qryAssignedUsers
            // 
            this.qryAssignedUsers.CanDelete = true;
            this.qryAssignedUsers.CanInsert = true;
            this.qryAssignedUsers.CanUpdate = true;
            this.qryAssignedUsers.HostControl = this;
            this.qryAssignedUsers.SelectStatement = resources.GetString("qryAssignedUsers.SelectStatement");
            this.qryAssignedUsers.TableName = "XUser_XDocTemplate";
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(30, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(118, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name der Vorlage";
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panDetails;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 335);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panDetails
            // 
            this.panDetails.Controls.Add(this.tabDocumentTemplate);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 343);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(709, 259);
            this.panDetails.TabIndex = 2;
            // 
            // edtSucheFormat
            // 
            this.edtSucheFormat.Location = new System.Drawing.Point(154, 70);
            this.edtSucheFormat.Name = "edtSucheFormat";
            this.edtSucheFormat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFormat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFormat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFormat.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFormat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFormat.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFormat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFormat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFormat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFormat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFormat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheFormat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFormat.Properties.NullText = "";
            this.edtSucheFormat.Properties.ShowFooter = false;
            this.edtSucheFormat.Properties.ShowHeader = false;
            this.edtSucheFormat.Size = new System.Drawing.Size(128, 24);
            this.edtSucheFormat.TabIndex = 4;
            // 
            // lblSucheFormat
            // 
            this.lblSucheFormat.Location = new System.Drawing.Point(30, 70);
            this.lblSucheFormat.Name = "lblSucheFormat";
            this.lblSucheFormat.Size = new System.Drawing.Size(118, 24);
            this.lblSucheFormat.TabIndex = 3;
            this.lblSucheFormat.Text = "Format";
            // 
            // CtlDocTemplate
            // 
            this.ActiveSQLQuery = this.qryDocTemplate;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlDocTemplate";
            this.Size = new System.Drawing.Size(709, 602);
            this.Load += new System.EventHandler(this.CtlDocTemplate_Load);
            this.Controls.SetChildIndex(this.panDetails, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemDocumentFormatImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplate)).EndInit();
            this.tabDocumentTemplate.ResumeLayout(false);
            this.tpgDetail.ResumeLayout(false);
            this.tpgAbteilungen.ResumeLayout(false);
            this.tpgBenutzer.ResumeLayout(false);
            this.tpgProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTags)).EndInit();
            this.tpgKontexte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKontext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontexte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAssignedXOrgUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSuche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAssignedUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFormat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDocFormatCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTemplateName;
        private KiSS4.Dokument.XDokument edtDocTemplate;
        private KiSS4.Gui.KissTextEdit edtDocTemplateName;
        private KiSS4.Gui.KissGrid grdDocTemplate;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDocTemplate;
        private System.Windows.Forms.ImageList imgList;
        private KiSS4.Gui.KissLabel lblDocTemplate;
        private KiSS4.Gui.KissLabel lblDocTemplateName;
        private KiSS4.DB.SqlQuery qryDocTemplate;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repItemDocumentFormatImg;
        private Gui.KissTabControlEx tabDocumentTemplate;
        private SharpLibrary.WinControls.TabPageEx tpgDetail;
        private SharpLibrary.WinControls.TabPageEx tpgAbteilungen;
        private Gui.KissDoubleListSelector edtAbteilungen;
        private DB.SqlQuery qryAssignedXOrgUnits;
        private Gui.KissTextEdit edtNameSuche;
        private SharpLibrary.WinControls.TabPageEx tpgBenutzer;
        private Gui.KissDoubleListSelector edtBenutzer;
        private DB.SqlQuery qryAssignedUsers;
        private SharpLibrary.WinControls.TabPageEx tpgProfile;
        private Gui.KissLabel lblProfileTags;
        private Common.CtlProfileTagsControl edtProfileTags;
        private DevExpress.XtraGrid.Columns.GridColumn colProfileTags;
        private DevExpress.XtraGrid.Columns.GridColumn colPublicTemplate;
        private Gui.KissLabel lblSucheName;
        private Gui.KissSplitterCollapsible splitter;
        private System.Windows.Forms.Panel panDetails;
        private Gui.KissLookUpEdit edtSucheFormat;
        private Gui.KissLabel lblSucheFormat;
        private SharpLibrary.WinControls.TabPageEx tpgKontexte;
        private Gui.KissGrid grdKontext;
        private DB.SqlQuery qryKontexte;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKontext;
        private DevExpress.XtraGrid.Columns.GridColumn colDocContextName;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;

    }
}
