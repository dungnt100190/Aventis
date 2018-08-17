namespace KiSS4.Administration
{
    partial class CtlAdInstitutionsTypen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdInstitutionsTypen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panEditFields = new System.Windows.Forms.Panel();
            this.grpMigration = new KiSS4.Gui.KissGroupBox();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            this.lblOrgUnit = new KiSS4.Gui.KissLabel();
            this.lblBezeichung = new KiSS4.Gui.KissLabel();
            this.edtBezeichung = new KiSS4.Gui.KissTextEditML();
            this.qryInstTypen = new KiSS4.DB.SqlQuery(this.components);
            this.edtOrgUnit = new KiSS4.Gui.KissLookUpEdit();
            this.grdInstTypen = new KiSS4.Gui.KissGrid();
            this.grvInstTypen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckAktiv = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.edtSuchenOrgUnit = new KiSS4.Gui.KissLookUpEdit();
            this.edtSuchenBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.lblSucheOrgUnit = new KiSS4.Gui.KissLabel();
            this.lblSucheBezeichung = new KiSS4.Gui.KissLabel();
            this.chkSucheAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtSuchenBemerkung = new KiSS4.Gui.KissTextEdit();
            this.lblSucheBemerkung = new KiSS4.Gui.KissLabel();
            this.lblMigrationID = new KiSS4.Gui.KissLabel();
            this.edtMigrationID = new KiSS4.Gui.KissIntEdit();
            this.btnMigration = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panEditFields.SuspendLayout();
            this.grpMigration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckAktiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenOrgUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMigrationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMigrationID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Size = new System.Drawing.Size(794, 387);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdInstTypen);
            this.tpgListe.Size = new System.Drawing.Size(782, 349);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSucheBemerkung);
            this.tpgSuchen.Controls.Add(this.edtSuchenBemerkung);
            this.tpgSuchen.Controls.Add(this.edtSuchenBezeichnung);
            this.tpgSuchen.Controls.Add(this.lblSucheBezeichung);
            this.tpgSuchen.Controls.Add(this.edtSuchenOrgUnit);
            this.tpgSuchen.Controls.Add(this.chkSucheAktiv);
            this.tpgSuchen.Controls.Add(this.lblSucheOrgUnit);
            this.tpgSuchen.Size = new System.Drawing.Size(782, 349);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOrgUnit, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheAktiv, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchenOrgUnit, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBezeichung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchenBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchenBemerkung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBemerkung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // panEditFields
            // 
            this.panEditFields.Controls.Add(this.grpMigration);
            this.panEditFields.Controls.Add(this.edtBemerkung);
            this.panEditFields.Controls.Add(this.lblBemerkung);
            this.panEditFields.Controls.Add(this.chkAktiv);
            this.panEditFields.Controls.Add(this.lblOrgUnit);
            this.panEditFields.Controls.Add(this.lblBezeichung);
            this.panEditFields.Controls.Add(this.edtBezeichung);
            this.panEditFields.Controls.Add(this.edtOrgUnit);
            this.panEditFields.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panEditFields.Location = new System.Drawing.Point(3, 390);
            this.panEditFields.Name = "panEditFields";
            this.panEditFields.Size = new System.Drawing.Size(794, 157);
            this.panEditFields.TabIndex = 1;
            // 
            // grpMigration
            // 
            this.grpMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMigration.Controls.Add(this.btnMigration);
            this.grpMigration.Controls.Add(this.edtMigrationID);
            this.grpMigration.Controls.Add(this.lblMigrationID);
            this.grpMigration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpMigration.Location = new System.Drawing.Point(569, 9);
            this.grpMigration.Name = "grpMigration";
            this.grpMigration.Size = new System.Drawing.Size(216, 80);
            this.grpMigration.TabIndex = 7;
            this.grpMigration.TabStop = false;
            this.grpMigration.Text = "Zusammenführen";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.Location = new System.Drawing.Point(116, 96);
            this.edtBemerkung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(669, 52);
            this.edtBemerkung.TabIndex = 6;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(9, 96);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(100, 23);
            this.lblBemerkung.TabIndex = 5;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // chkAktiv
            // 
            this.chkAktiv.EditValue = true;
            this.chkAktiv.Location = new System.Drawing.Point(115, 70);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = "Aktiv";
            this.chkAktiv.Size = new System.Drawing.Size(75, 19);
            this.chkAktiv.TabIndex = 4;
            // 
            // lblOrgUnit
            // 
            this.lblOrgUnit.Location = new System.Drawing.Point(9, 39);
            this.lblOrgUnit.Name = "lblOrgUnit";
            this.lblOrgUnit.Size = new System.Drawing.Size(100, 23);
            this.lblOrgUnit.TabIndex = 2;
            this.lblOrgUnit.Text = "Abteilung";
            // 
            // lblBezeichung
            // 
            this.lblBezeichung.Location = new System.Drawing.Point(9, 9);
            this.lblBezeichung.Name = "lblBezeichung";
            this.lblBezeichung.Size = new System.Drawing.Size(100, 23);
            this.lblBezeichung.TabIndex = 0;
            this.lblBezeichung.Text = "Bezeichnung";
            // 
            // edtBezeichung
            // 
            this.edtBezeichung.DataMemberDefaultText = "";
            this.edtBezeichung.DataMemberTID = "";
            this.edtBezeichung.DataSource = this.qryInstTypen;
            this.edtBezeichung.Location = new System.Drawing.Point(115, 9);
            this.edtBezeichung.Name = "edtBezeichung";
            this.edtBezeichung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBezeichung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBezeichung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBezeichung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezeichung.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtBezeichung.Size = new System.Drawing.Size(250, 24);
            this.edtBezeichung.TabIndex = 1;
            // 
            // qryInstTypen
            // 
            this.qryInstTypen.HostControl = this;
            this.qryInstTypen.SelectStatement = resources.GetString("qryInstTypen.SelectStatement");
            this.qryInstTypen.TableName = "BaInstitutionTyp";
            this.qryInstTypen.AfterInsert += new System.EventHandler(this.qryInstTypen_AfterInsert);
            this.qryInstTypen.BeforePost += new System.EventHandler(this.qryInstTypen_BeforePost);
            this.qryInstTypen.AfterPost += new System.EventHandler(this.qryInstTypen_AfterPost);
            this.qryInstTypen.BeforeDeleteQuestion += new System.EventHandler(this.qryInstTypen_BeforeDeleteQuestion);
            // 
            // edtOrgUnit
            // 
            this.edtOrgUnit.DataSource = this.qryInstTypen;
            this.edtOrgUnit.Location = new System.Drawing.Point(115, 39);
            this.edtOrgUnit.Name = "edtOrgUnit";
            this.edtOrgUnit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnit.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnit.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtOrgUnit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnit.Properties.NullText = "";
            this.edtOrgUnit.Properties.ShowFooter = false;
            this.edtOrgUnit.Properties.ShowHeader = false;
            this.edtOrgUnit.Size = new System.Drawing.Size(250, 24);
            this.edtOrgUnit.TabIndex = 3;
            // 
            // grdInstTypen
            // 
            this.grdInstTypen.DataSource = this.qryInstTypen;
            this.grdInstTypen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdInstTypen.EmbeddedNavigator.Name = "";
            this.grdInstTypen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdInstTypen.Location = new System.Drawing.Point(0, 0);
            this.grdInstTypen.MainView = this.grvInstTypen;
            this.grdInstTypen.Name = "grdInstTypen";
            this.grdInstTypen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckAktiv});
            this.grdInstTypen.Size = new System.Drawing.Size(782, 349);
            this.grdInstTypen.TabIndex = 0;
            this.grdInstTypen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInstTypen});
            // 
            // grvInstTypen
            // 
            this.grvInstTypen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvInstTypen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.Empty.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.Empty.Options.UseFont = true;
            this.grvInstTypen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.EvenRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstTypen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvInstTypen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvInstTypen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstTypen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvInstTypen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstTypen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstTypen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvInstTypen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstTypen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.GroupRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvInstTypen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvInstTypen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvInstTypen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvInstTypen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvInstTypen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvInstTypen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstTypen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstTypen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.OddRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvInstTypen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.Row.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.Row.Options.UseFont = true;
            this.grvInstTypen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstTypen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvInstTypen.BestFitMaxRowCount = 1000;
            this.grvInstTypen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvInstTypen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colBezeichnung,
            this.colOrgUnit,
            this.colAktiv});
            this.grvInstTypen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvInstTypen.GridControl = this.grdInstTypen;
            this.grvInstTypen.Name = "grvInstTypen";
            this.grvInstTypen.OptionsBehavior.Editable = false;
            this.grvInstTypen.OptionsCustomization.AllowFilter = false;
            this.grvInstTypen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvInstTypen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvInstTypen.OptionsNavigation.UseTabKey = false;
            this.grvInstTypen.OptionsView.ColumnAutoWidth = false;
            this.grvInstTypen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvInstTypen.OptionsView.ShowGroupPanel = false;
            this.grvInstTypen.OptionsView.ShowIndicator = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "BaInstitutionTypID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 60;
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 1;
            this.colBezeichnung.Width = 351;
            // 
            // colOrgUnit
            // 
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 2;
            this.colOrgUnit.Width = 193;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.ColumnEdit = this.repCheckAktiv;
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 3;
            // 
            // repCheckAktiv
            // 
            this.repCheckAktiv.AutoHeight = false;
            this.repCheckAktiv.Name = "repCheckAktiv";
            // 
            // edtSuchenOrgUnit
            // 
            this.edtSuchenOrgUnit.Location = new System.Drawing.Point(136, 70);
            this.edtSuchenOrgUnit.Name = "edtSuchenOrgUnit";
            this.edtSuchenOrgUnit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchenOrgUnit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchenOrgUnit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchenOrgUnit.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchenOrgUnit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchenOrgUnit.Properties.Appearance.Options.UseFont = true;
            this.edtSuchenOrgUnit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSuchenOrgUnit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchenOrgUnit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSuchenOrgUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSuchenOrgUnit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSuchenOrgUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSuchenOrgUnit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchenOrgUnit.Properties.NullText = "";
            this.edtSuchenOrgUnit.Properties.ShowFooter = false;
            this.edtSuchenOrgUnit.Properties.ShowHeader = false;
            this.edtSuchenOrgUnit.Size = new System.Drawing.Size(250, 24);
            this.edtSuchenOrgUnit.TabIndex = 4;
            // 
            // edtSuchenBezeichnung
            // 
            this.edtSuchenBezeichnung.Location = new System.Drawing.Point(136, 40);
            this.edtSuchenBezeichnung.Name = "edtSuchenBezeichnung";
            this.edtSuchenBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchenBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchenBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchenBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchenBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchenBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtSuchenBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchenBezeichnung.Size = new System.Drawing.Size(250, 24);
            this.edtSuchenBezeichnung.TabIndex = 2;
            // 
            // lblSucheOrgUnit
            // 
            this.lblSucheOrgUnit.Location = new System.Drawing.Point(30, 70);
            this.lblSucheOrgUnit.Name = "lblSucheOrgUnit";
            this.lblSucheOrgUnit.Size = new System.Drawing.Size(100, 23);
            this.lblSucheOrgUnit.TabIndex = 3;
            this.lblSucheOrgUnit.Text = "Abteilung";
            // 
            // lblSucheBezeichung
            // 
            this.lblSucheBezeichung.Location = new System.Drawing.Point(30, 40);
            this.lblSucheBezeichung.Name = "lblSucheBezeichung";
            this.lblSucheBezeichung.Size = new System.Drawing.Size(100, 23);
            this.lblSucheBezeichung.TabIndex = 1;
            this.lblSucheBezeichung.Text = "Bezeichnung";
            // 
            // chkSucheAktiv
            // 
            this.chkSucheAktiv.EditValue = true;
            this.chkSucheAktiv.Location = new System.Drawing.Point(136, 134);
            this.chkSucheAktiv.Name = "chkSucheAktiv";
            this.chkSucheAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheAktiv.Properties.Caption = "nur Aktive";
            this.chkSucheAktiv.Size = new System.Drawing.Size(75, 19);
            this.chkSucheAktiv.TabIndex = 7;
            // 
            // edtSuchenBemerkung
            // 
            this.edtSuchenBemerkung.Location = new System.Drawing.Point(136, 101);
            this.edtSuchenBemerkung.Name = "edtSuchenBemerkung";
            this.edtSuchenBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchenBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchenBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchenBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchenBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchenBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtSuchenBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchenBemerkung.Size = new System.Drawing.Size(250, 24);
            this.edtSuchenBemerkung.TabIndex = 6;
            // 
            // lblSucheBemerkung
            // 
            this.lblSucheBemerkung.Location = new System.Drawing.Point(33, 101);
            this.lblSucheBemerkung.Name = "lblSucheBemerkung";
            this.lblSucheBemerkung.Size = new System.Drawing.Size(100, 23);
            this.lblSucheBemerkung.TabIndex = 5;
            this.lblSucheBemerkung.Text = "Bemerkung";
            // 
            // lblMigrationID
            // 
            this.lblMigrationID.Location = new System.Drawing.Point(6, 17);
            this.lblMigrationID.Name = "lblMigrationID";
            this.lblMigrationID.Size = new System.Drawing.Size(67, 24);
            this.lblMigrationID.TabIndex = 1;
            this.lblMigrationID.Text = "Ziel-ID";
            // 
            // edtMigrationID
            // 
            this.edtMigrationID.Location = new System.Drawing.Point(94, 16);
            this.edtMigrationID.Name = "edtMigrationID";
            this.edtMigrationID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMigrationID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMigrationID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMigrationID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMigrationID.Properties.Appearance.Options.UseBackColor = true;
            this.edtMigrationID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMigrationID.Properties.Appearance.Options.UseFont = true;
            this.edtMigrationID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMigrationID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtMigrationID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMigrationID.Properties.DisplayFormat.FormatString = "################################";
            this.edtMigrationID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMigrationID.Properties.EditFormat.FormatString = "################################";
            this.edtMigrationID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMigrationID.Properties.Mask.EditMask = "################################";
            this.edtMigrationID.Size = new System.Drawing.Size(112, 24);
            this.edtMigrationID.TabIndex = 2;
            // 
            // btnMigration
            // 
            this.btnMigration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMigration.Location = new System.Drawing.Point(9, 46);
            this.btnMigration.Name = "btnMigration";
            this.btnMigration.Size = new System.Drawing.Size(197, 24);
            this.btnMigration.TabIndex = 3;
            this.btnMigration.Text = "Daten zusammenführen";
            this.btnMigration.UseVisualStyleBackColor = false;
            this.btnMigration.Click += new System.EventHandler(this.btnMigration_Click);
            // 
            // CtlAdInstitutionsTypen
            // 
            this.ActiveSQLQuery = this.qryInstTypen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panEditFields);
            this.Name = "CtlAdInstitutionsTypen";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(800, 550);
            this.Load += new System.EventHandler(this.CtlAdInstitutionsTypen_Load);
            this.Controls.SetChildIndex(this.panEditFields, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panEditFields.ResumeLayout(false);
            this.grpMigration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckAktiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenOrgUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMigrationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMigrationID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdInstTypen;
        private System.Windows.Forms.Panel panEditFields;
        private DevExpress.XtraGrid.Views.Grid.GridView grvInstTypen;
        private KiSS4.Gui.KissTextEditML edtBezeichung;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnit;
        private KiSS4.DB.SqlQuery qryInstTypen;
        private KiSS4.Gui.KissTextEdit edtSuchenBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtSuchenOrgUnit;
        private KiSS4.Gui.KissLabel lblOrgUnit;
        private KiSS4.Gui.KissLabel lblBezeichung;
        private KiSS4.Gui.KissLabel lblSucheBezeichung;
        private KiSS4.Gui.KissLabel lblSucheOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckAktiv;
        private KiSS4.Gui.KissCheckEdit chkSucheAktiv;
        private KiSS4.Gui.KissTextEdit edtSuchenBemerkung;
        private KiSS4.Gui.KissLabel lblSucheBemerkung;
        private Gui.KissGroupBox grpMigration;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private Gui.KissButton btnMigration;
        private Gui.KissIntEdit edtMigrationID;
        private Gui.KissLabel lblMigrationID;
    }
}
