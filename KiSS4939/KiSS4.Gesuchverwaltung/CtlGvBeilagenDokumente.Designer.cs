namespace KiSS4.Gesuchverwaltung
{
    partial class CtlGvBeilagenDokumente
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlGvBeilagenDokumente));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdGvDocument = new KiSS4.Gui.KissGrid();
            this.qryGvDocument = new KiSS4.DB.SqlQuery(this.components);
            this.grvGvDocument = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokVorhanden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cedColDokVorhanden = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.lblAutor = new KiSS4.Gui.KissLabel();
            this.lblStichworte = new KiSS4.Gui.KissLabel();
            this.lblAdressat = new KiSS4.Gui.KissLabel();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.edtAdressat = new KiSS4.Gui.KissButtonEdit();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.edtStichworte = new KiSS4.Gui.KissTextEdit();
            this.edtAutor = new KiSS4.Gui.KissTextEdit();
            this.edtDokument = new KiSS4.Dokument.XDokument();
            this.grpErfassung = new KiSS4.Gui.KissGroupBox();
            this.btnErfassungAbschlussAufheben = new KiSS4.Gui.KissButton();
            this.btnErfassungAbschliessen = new KiSS4.Gui.KissButton();
            this.grpBearbeitung = new KiSS4.Gui.KissGroupBox();
            this.btnBearbeitungAbschlussAufheben = new KiSS4.Gui.KissButton();
            this.btnBearbeitungGesuchZurueckweisen = new KiSS4.Gui.KissButton();
            this.btnBearbeitungAbschliessen = new KiSS4.Gui.KissButton();
            this.edtErfassungAbgeschlossen = new KiSS4.Gui.KissDateEdit();
            this.lblErfassungAbgeschlossenAm = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGvDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGvDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedColDokVorhanden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).BeginInit();
            this.grpErfassung.SuspendLayout();
            this.grpBearbeitung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungAbgeschlossen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungAbgeschlossenAm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(2, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(175, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Beilagen / Dokumente";
            // 
            // grdGvDocument
            // 
            this.grdGvDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGvDocument.DataSource = this.qryGvDocument;
            // 
            // 
            // 
            this.grdGvDocument.EmbeddedNavigator.Name = "";
            this.grdGvDocument.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGvDocument.Location = new System.Drawing.Point(3, 24);
            this.grdGvDocument.MainView = this.grvGvDocument;
            this.grdGvDocument.Name = "grdGvDocument";
            this.grdGvDocument.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cedColDokVorhanden});
            this.grdGvDocument.Size = new System.Drawing.Size(794, 220);
            this.grdGvDocument.TabIndex = 1;
            this.grdGvDocument.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGvDocument});
            // 
            // qryGvDocument
            // 
            this.qryGvDocument.CanDelete = true;
            this.qryGvDocument.CanInsert = true;
            this.qryGvDocument.CanUpdate = true;
            this.qryGvDocument.HostControl = this;
            this.qryGvDocument.SelectStatement = resources.GetString("qryGvDocument.SelectStatement");
            this.qryGvDocument.TableName = "GvDocument";
            this.qryGvDocument.AfterDelete += new System.EventHandler(this.qryGvDocument_AfterDelete);
            this.qryGvDocument.AfterInsert += new System.EventHandler(this.qryGvDocument_AfterInsert);
            this.qryGvDocument.BeforeDelete += new System.EventHandler(this.qryGvDocument_BeforeDelete);
            this.qryGvDocument.BeforePost += new System.EventHandler(this.qryGvDocument_BeforePost);
            this.qryGvDocument.PositionChanged += new System.EventHandler(this.qryGvDocument_PositionChanged);
            // 
            // grvGvDocument
            // 
            this.grvGvDocument.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGvDocument.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.Empty.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.Empty.Options.UseFont = true;
            this.grvGvDocument.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.EvenRow.Options.UseFont = true;
            this.grvGvDocument.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGvDocument.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGvDocument.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGvDocument.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGvDocument.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGvDocument.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGvDocument.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGvDocument.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGvDocument.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGvDocument.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGvDocument.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGvDocument.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGvDocument.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.GroupRow.Options.UseFont = true;
            this.grvGvDocument.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGvDocument.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGvDocument.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGvDocument.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGvDocument.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGvDocument.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGvDocument.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGvDocument.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGvDocument.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGvDocument.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGvDocument.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGvDocument.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.OddRow.Options.UseFont = true;
            this.grvGvDocument.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGvDocument.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.Row.Options.UseBackColor = true;
            this.grvGvDocument.Appearance.Row.Options.UseFont = true;
            this.grvGvDocument.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvDocument.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGvDocument.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGvDocument.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGvDocument.BestFitMaxRowCount = 1000;
            this.grvGvDocument.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGvDocument.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colAutor,
            this.colStichworte,
            this.colBemerkungen,
            this.colDokVorhanden});
            this.grvGvDocument.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGvDocument.GridControl = this.grdGvDocument;
            this.grvGvDocument.Name = "grvGvDocument";
            this.grvGvDocument.OptionsBehavior.Editable = false;
            this.grvGvDocument.OptionsCustomization.AllowFilter = false;
            this.grvGvDocument.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGvDocument.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGvDocument.OptionsNavigation.UseTabKey = false;
            this.grvGvDocument.OptionsView.ColumnAutoWidth = false;
            this.grvGvDocument.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGvDocument.OptionsView.ShowGroupPanel = false;
            this.grvGvDocument.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            // 
            // colAutor
            // 
            this.colAutor.Caption = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 1;
            this.colAutor.Width = 175;
            // 
            // colStichworte
            // 
            this.colStichworte.Caption = "Stichwort(e)";
            this.colStichworte.Name = "colStichworte";
            this.colStichworte.Visible = true;
            this.colStichworte.VisibleIndex = 2;
            this.colStichworte.Width = 175;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 3;
            this.colBemerkungen.Width = 200;
            // 
            // colDokVorhanden
            // 
            this.colDokVorhanden.Caption = "Dok. vorh.";
            this.colDokVorhanden.ColumnEdit = this.cedColDokVorhanden;
            this.colDokVorhanden.FieldName = "DokVorhanden";
            this.colDokVorhanden.Name = "colDokVorhanden";
            this.colDokVorhanden.ToolTip = "Dokument vorhanden";
            this.colDokVorhanden.Visible = true;
            this.colDokVorhanden.VisibleIndex = 4;
            // 
            // cedColDokVorhanden
            // 
            this.cedColDokVorhanden.AutoHeight = false;
            this.cedColDokVorhanden.Name = "cedColDokVorhanden";
            this.cedColDokVorhanden.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.cedColDokVorhanden.ReadOnly = true;
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(3, 250);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(100, 23);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum";
            // 
            // lblAutor
            // 
            this.lblAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutor.Location = new System.Drawing.Point(3, 280);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(100, 23);
            this.lblAutor.TabIndex = 4;
            this.lblAutor.Text = "Autor";
            // 
            // lblStichworte
            // 
            this.lblStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichworte.Location = new System.Drawing.Point(3, 314);
            this.lblStichworte.Name = "lblStichworte";
            this.lblStichworte.Size = new System.Drawing.Size(100, 23);
            this.lblStichworte.TabIndex = 6;
            this.lblStichworte.Text = "Stichwort(e)";
            // 
            // lblAdressat
            // 
            this.lblAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdressat.Location = new System.Drawing.Point(3, 344);
            this.lblAdressat.Name = "lblAdressat";
            this.lblAdressat.Size = new System.Drawing.Size(100, 23);
            this.lblAdressat.TabIndex = 8;
            this.lblAdressat.Text = "Adressat";
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokument.Location = new System.Drawing.Point(3, 374);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(100, 23);
            this.lblDokument.TabIndex = 10;
            this.lblDokument.Text = "Dokument";
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungen.Location = new System.Drawing.Point(3, 404);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(100, 23);
            this.lblBemerkungen.TabIndex = 12;
            this.lblBemerkungen.Text = "Bemerkungen";
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataSource = this.qryGvDocument;
            this.edtDatum.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(109, 250);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDatum.TabIndex = 3;
            // 
            // edtAdressat
            // 
            this.edtAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdressat.DataSource = this.qryGvDocument;
            this.edtAdressat.Location = new System.Drawing.Point(109, 344);
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
            this.edtAdressat.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAdressat.Size = new System.Drawing.Size(350, 24);
            this.edtAdressat.TabIndex = 9;
            this.edtAdressat.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAdressat_UserModifiedFld);
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkungen.DataSource = this.qryGvDocument;
            this.edtBemerkungen.EditValue = "";
            this.edtBemerkungen.Location = new System.Drawing.Point(109, 404);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(350, 93);
            this.edtBemerkungen.TabIndex = 13;
            // 
            // edtStichworte
            // 
            this.edtStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichworte.DataSource = this.qryGvDocument;
            this.edtStichworte.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtStichworte.Location = new System.Drawing.Point(109, 314);
            this.edtStichworte.Name = "edtStichworte";
            this.edtStichworte.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtStichworte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichworte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichworte.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseFont = true;
            this.edtStichworte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichworte.Size = new System.Drawing.Size(350, 24);
            this.edtStichworte.TabIndex = 7;
            // 
            // edtAutor
            // 
            this.edtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAutor.DataSource = this.qryGvDocument;
            this.edtAutor.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAutor.Location = new System.Drawing.Point(109, 280);
            this.edtAutor.Name = "edtAutor";
            this.edtAutor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAutor.Properties.Appearance.Options.UseFont = true;
            this.edtAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAutor.Properties.ReadOnly = true;
            this.edtAutor.Size = new System.Drawing.Size(350, 24);
            this.edtAutor.TabIndex = 5;
            // 
            // edtDokument
            // 
            this.edtDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokument.Context = "GV_Beilagen";
            this.edtDokument.DataSource = this.qryGvDocument;
            this.edtDokument.EditValue = "";
            this.edtDokument.Location = new System.Drawing.Point(109, 374);
            this.edtDokument.Name = "edtDokument";
            this.edtDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokument.Properties.Appearance.Options.UseFont = true;
            this.edtDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument importieren")});
            this.edtDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokument.Properties.ReadOnly = true;
            this.edtDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokument.Size = new System.Drawing.Size(125, 24);
            this.edtDokument.TabIndex = 11;
            // 
            // grpErfassung
            // 
            this.grpErfassung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpErfassung.Controls.Add(this.btnErfassungAbschlussAufheben);
            this.grpErfassung.Controls.Add(this.btnErfassungAbschliessen);
            this.grpErfassung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpErfassung.Location = new System.Drawing.Point(610, 299);
            this.grpErfassung.Name = "grpErfassung";
            this.grpErfassung.Size = new System.Drawing.Size(187, 81);
            this.grpErfassung.TabIndex = 14;
            this.grpErfassung.TabStop = false;
            this.grpErfassung.Text = "Erfassung";
            // 
            // btnErfassungAbschlussAufheben
            // 
            this.btnErfassungAbschlussAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErfassungAbschlussAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfassungAbschlussAufheben.Location = new System.Drawing.Point(6, 50);
            this.btnErfassungAbschlussAufheben.Name = "btnErfassungAbschlussAufheben";
            this.btnErfassungAbschlussAufheben.Size = new System.Drawing.Size(175, 24);
            this.btnErfassungAbschlussAufheben.TabIndex = 1;
            this.btnErfassungAbschlussAufheben.Text = "Abschluss aufheben";
            this.btnErfassungAbschlussAufheben.UseVisualStyleBackColor = false;
            this.btnErfassungAbschlussAufheben.Click += new System.EventHandler(this.btnErfassungAbschlussAufheben_Click);
            // 
            // btnErfassungAbschliessen
            // 
            this.btnErfassungAbschliessen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErfassungAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfassungAbschliessen.Location = new System.Drawing.Point(6, 20);
            this.btnErfassungAbschliessen.Name = "btnErfassungAbschliessen";
            this.btnErfassungAbschliessen.Size = new System.Drawing.Size(175, 24);
            this.btnErfassungAbschliessen.TabIndex = 0;
            this.btnErfassungAbschliessen.Text = "Erfassung abschliessen";
            this.btnErfassungAbschliessen.UseVisualStyleBackColor = false;
            this.btnErfassungAbschliessen.Click += new System.EventHandler(this.btnErfassungAbschliessen_Click);
            // 
            // grpBearbeitung
            // 
            this.grpBearbeitung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBearbeitung.Controls.Add(this.btnBearbeitungAbschlussAufheben);
            this.grpBearbeitung.Controls.Add(this.btnBearbeitungGesuchZurueckweisen);
            this.grpBearbeitung.Controls.Add(this.btnBearbeitungAbschliessen);
            this.grpBearbeitung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpBearbeitung.Location = new System.Drawing.Point(610, 386);
            this.grpBearbeitung.Name = "grpBearbeitung";
            this.grpBearbeitung.Size = new System.Drawing.Size(187, 111);
            this.grpBearbeitung.TabIndex = 15;
            this.grpBearbeitung.TabStop = false;
            this.grpBearbeitung.Text = "Bearbeitung";
            // 
            // btnBearbeitungAbschlussAufheben
            // 
            this.btnBearbeitungAbschlussAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBearbeitungAbschlussAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBearbeitungAbschlussAufheben.Location = new System.Drawing.Point(6, 80);
            this.btnBearbeitungAbschlussAufheben.Name = "btnBearbeitungAbschlussAufheben";
            this.btnBearbeitungAbschlussAufheben.Size = new System.Drawing.Size(175, 24);
            this.btnBearbeitungAbschlussAufheben.TabIndex = 2;
            this.btnBearbeitungAbschlussAufheben.Text = "Abschluss aufheben";
            this.btnBearbeitungAbschlussAufheben.UseVisualStyleBackColor = false;
            this.btnBearbeitungAbschlussAufheben.Click += new System.EventHandler(this.btnBearbeitungAbschlussAufheben_Click);
            // 
            // btnBearbeitungGesuchZurueckweisen
            // 
            this.btnBearbeitungGesuchZurueckweisen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBearbeitungGesuchZurueckweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBearbeitungGesuchZurueckweisen.Location = new System.Drawing.Point(6, 50);
            this.btnBearbeitungGesuchZurueckweisen.Name = "btnBearbeitungGesuchZurueckweisen";
            this.btnBearbeitungGesuchZurueckweisen.Size = new System.Drawing.Size(175, 24);
            this.btnBearbeitungGesuchZurueckweisen.TabIndex = 1;
            this.btnBearbeitungGesuchZurueckweisen.Text = "Gesuch zurückweisen";
            this.btnBearbeitungGesuchZurueckweisen.UseVisualStyleBackColor = false;
            this.btnBearbeitungGesuchZurueckweisen.Click += new System.EventHandler(this.btnBearbeitungGesuchZurueckweisen_Click);
            // 
            // btnBearbeitungAbschliessen
            // 
            this.btnBearbeitungAbschliessen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBearbeitungAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBearbeitungAbschliessen.Location = new System.Drawing.Point(6, 20);
            this.btnBearbeitungAbschliessen.Name = "btnBearbeitungAbschliessen";
            this.btnBearbeitungAbschliessen.Size = new System.Drawing.Size(175, 24);
            this.btnBearbeitungAbschliessen.TabIndex = 0;
            this.btnBearbeitungAbschliessen.Text = "Bearbeitung abschliessen";
            this.btnBearbeitungAbschliessen.UseVisualStyleBackColor = false;
            this.btnBearbeitungAbschliessen.Click += new System.EventHandler(this.btnBearbeitungAbschliessen_Click);
            // 
            // edtErfassungAbgeschlossen
            // 
            this.edtErfassungAbgeschlossen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErfassungAbgeschlossen.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErfassungAbgeschlossen.EditValue = null;
            this.edtErfassungAbgeschlossen.Location = new System.Drawing.Point(691, 250);
            this.edtErfassungAbgeschlossen.Name = "edtErfassungAbgeschlossen";
            this.edtErfassungAbgeschlossen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungAbgeschlossen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErfassungAbgeschlossen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungAbgeschlossen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungAbgeschlossen.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungAbgeschlossen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungAbgeschlossen.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungAbgeschlossen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtErfassungAbgeschlossen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErfassungAbgeschlossen.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtErfassungAbgeschlossen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungAbgeschlossen.Properties.ReadOnly = true;
            this.edtErfassungAbgeschlossen.Properties.ShowToday = false;
            this.edtErfassungAbgeschlossen.Size = new System.Drawing.Size(100, 24);
            this.edtErfassungAbgeschlossen.TabIndex = 17;
            // 
            // lblErfassungAbgeschlossenAm
            // 
            this.lblErfassungAbgeschlossenAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErfassungAbgeschlossenAm.Location = new System.Drawing.Point(503, 250);
            this.lblErfassungAbgeschlossenAm.Name = "lblErfassungAbgeschlossenAm";
            this.lblErfassungAbgeschlossenAm.Size = new System.Drawing.Size(182, 24);
            this.lblErfassungAbgeschlossenAm.TabIndex = 16;
            this.lblErfassungAbgeschlossenAm.Text = "Erfassung abgeschlossen am";
            this.lblErfassungAbgeschlossenAm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CtlGvBeilagenDokumente
            // 
            this.ActiveSQLQuery = this.qryGvDocument;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(656, 350);
            this.Controls.Add(this.edtErfassungAbgeschlossen);
            this.Controls.Add(this.lblErfassungAbgeschlossenAm);
            this.Controls.Add(this.grpBearbeitung);
            this.Controls.Add(this.grpErfassung);
            this.Controls.Add(this.edtDokument);
            this.Controls.Add(this.edtAutor);
            this.Controls.Add(this.edtStichworte);
            this.Controls.Add(this.edtBemerkungen);
            this.Controls.Add(this.edtAdressat);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.lblDokument);
            this.Controls.Add(this.lblAdressat);
            this.Controls.Add(this.lblStichworte);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.grdGvDocument);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlGvBeilagenDokumente";
            this.Size = new System.Drawing.Size(800, 500);
            this.Load += new System.EventHandler(this.CtlGvBeilagenDokumente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGvDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGvDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedColDokVorhanden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).EndInit();
            this.grpErfassung.ResumeLayout(false);
            this.grpBearbeitung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungAbgeschlossen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungAbgeschlossenAm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissLabel lblTitel;
        private Gui.KissGrid grdGvDocument;
        private Gui.KissLabel lblDatum;
        private Gui.KissLabel lblAutor;
        private Gui.KissLabel lblStichworte;
        private Gui.KissLabel lblAdressat;
        private Gui.KissLabel lblDokument;
        private Gui.KissLabel lblBemerkungen;
        private Gui.KissDateEdit edtDatum;
        private DB.SqlQuery qryGvDocument;
        private Gui.KissTextEdit edtAutor;
        private Gui.KissTextEdit edtStichworte;
        private Gui.KissMemoEdit edtBemerkungen;
        private Gui.KissButtonEdit edtAdressat;
        private Dokument.XDokument edtDokument;
        private Gui.KissGroupBox grpBearbeitung;
        private Gui.KissButton btnBearbeitungAbschlussAufheben;
        private Gui.KissButton btnBearbeitungGesuchZurueckweisen;
        private Gui.KissButton btnBearbeitungAbschliessen;
        private Gui.KissGroupBox grpErfassung;
        private Gui.KissButton btnErfassungAbschlussAufheben;
        private Gui.KissButton btnErfassungAbschliessen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGvDocument;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colDokVorhanden;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit cedColDokVorhanden;
        private Gui.KissDateEdit edtErfassungAbgeschlossen;
        private Gui.KissLabel lblErfassungAbgeschlossenAm;
    }
}
