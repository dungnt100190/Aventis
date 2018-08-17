namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbKostenstelleErfassung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbKostenstelleErfassung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryKbKostenstelle = new KiSS4.DB.SqlQuery(this.components);
            this.lblNameX = new KiSS4.Gui.KissLabel();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.lblNr = new KiSS4.Gui.KissLabel();
            this.edtNrX = new KiSS4.Gui.KissTextEdit();
            this.grdKostenstelle = new KiSS4.Gui.KissGrid();
            this.grvKostenstelle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtKostenstelleModul = new KiSS4.Gui.KissLookUpEdit();
            this.lblKostenstelleModul = new KiSS4.Gui.KissLabel();
            this.chkKostenstelleAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtKostenstelleName = new KiSS4.Gui.KissTextEdit();
            this.lblKostenstelleName = new KiSS4.Gui.KissLabel();
            this.edtKostenstelleNr = new KiSS4.Gui.KissTextEdit();
            this.lblKostenstelleNr = new KiSS4.Gui.KissLabel();
            this.lblKostenstelleAktiv = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKostenstelleAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleAktiv)).BeginInit();
            this.SuspendLayout();
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKostenstelle);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblNr);
            this.tpgSuchen.Controls.Add(this.edtNrX);
            this.tpgSuchen.Controls.Add(this.lblNameX);
            this.tpgSuchen.Controls.Add(this.edtNameX);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNr, 0);
            // 
            // qryKbKostenstelle
            // 
            this.qryKbKostenstelle.CanDelete = true;
            this.qryKbKostenstelle.CanInsert = true;
            this.qryKbKostenstelle.CanUpdate = true;
            this.qryKbKostenstelle.HostControl = this;
            this.qryKbKostenstelle.SelectStatement = resources.GetString("qryKbKostenstelle.SelectStatement");
            this.qryKbKostenstelle.TableName = "KbKostenstelle";
            this.qryKbKostenstelle.BeforePost += new System.EventHandler(this.qryKbKostenstelle_BeforePost);
            this.qryKbKostenstelle.AfterInsert += new System.EventHandler(this.qryKbKostenstelle_AfterInsert);
            // 
            // lblNameX
            // 
            this.lblNameX.Location = new System.Drawing.Point(6, 50);
            this.lblNameX.Name = "lblNameX";
            this.lblNameX.Size = new System.Drawing.Size(90, 24);
            this.lblNameX.TabIndex = 1;
            this.lblNameX.Text = "Name";
            this.lblNameX.UseCompatibleTextRendering = true;
            // 
            // edtNameX
            // 
            this.edtNameX.Location = new System.Drawing.Point(102, 51);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Size = new System.Drawing.Size(249, 24);
            this.edtNameX.TabIndex = 2;
            // 
            // lblNr
            // 
            this.lblNr.Location = new System.Drawing.Point(6, 80);
            this.lblNr.Name = "lblNr";
            this.lblNr.Size = new System.Drawing.Size(90, 24);
            this.lblNr.TabIndex = 3;
            this.lblNr.Text = "Nr";
            this.lblNr.UseCompatibleTextRendering = true;
            // 
            // edtNrX
            // 
            this.edtNrX.Location = new System.Drawing.Point(102, 81);
            this.edtNrX.Name = "edtNrX";
            this.edtNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNrX.Properties.Appearance.Options.UseFont = true;
            this.edtNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNrX.Size = new System.Drawing.Size(249, 24);
            this.edtNrX.TabIndex = 4;
            // 
            // grdKostenstelle
            // 
            this.grdKostenstelle.DataSource = this.qryKbKostenstelle;
            this.grdKostenstelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKostenstelle.EmbeddedNavigator.Name = "";
            this.grdKostenstelle.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKostenstelle.Location = new System.Drawing.Point(0, 0);
            this.grdKostenstelle.MainView = this.grvKostenstelle;
            this.grdKostenstelle.Name = "grdKostenstelle";
            this.grdKostenstelle.Size = new System.Drawing.Size(782, 223);
            this.grdKostenstelle.TabIndex = 0;
            this.grdKostenstelle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKostenstelle});
            // 
            // grvKostenstelle
            // 
            this.grvKostenstelle.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKostenstelle.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.Empty.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.Empty.Options.UseFont = true;
            this.grvKostenstelle.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKostenstelle.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.EvenRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenstelle.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKostenstelle.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKostenstelle.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenstelle.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKostenstelle.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenstelle.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenstelle.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenstelle.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenstelle.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.GroupRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKostenstelle.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKostenstelle.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenstelle.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKostenstelle.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKostenstelle.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKostenstelle.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenstelle.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenstelle.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.OddRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKostenstelle.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.Row.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.Row.Options.UseFont = true;
            this.grvKostenstelle.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKostenstelle.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKostenstelle.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenstelle.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKostenstelle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKostenstelle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNr,
            this.colName,
            this.colAktiv,
            this.colModul});
            this.grvKostenstelle.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKostenstelle.GridControl = this.grdKostenstelle;
            this.grvKostenstelle.Name = "grvKostenstelle";
            this.grvKostenstelle.OptionsBehavior.Editable = false;
            this.grvKostenstelle.OptionsCustomization.AllowFilter = false;
            this.grvKostenstelle.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKostenstelle.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKostenstelle.OptionsNavigation.UseTabKey = false;
            this.grvKostenstelle.OptionsView.ColumnAutoWidth = false;
            this.grvKostenstelle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKostenstelle.OptionsView.ShowGroupPanel = false;
            this.grvKostenstelle.OptionsView.ShowIndicator = false;
            // 
            // colNr
            // 
            this.colNr.Caption = "Nr.";
            this.colNr.FieldName = "Nr";
            this.colNr.Name = "colNr";
            this.colNr.OptionsColumn.AllowEdit = false;
            this.colNr.OptionsColumn.AllowFocus = false;
            this.colNr.OptionsColumn.ReadOnly = true;
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 0;
            this.colNr.Width = 100;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 170;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.OptionsColumn.AllowEdit = false;
            this.colAktiv.OptionsColumn.AllowFocus = false;
            this.colAktiv.OptionsColumn.ReadOnly = true;
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 2;
            this.colAktiv.Width = 40;
            // 
            // colModul
            // 
            this.colModul.Caption = "Modul";
            this.colModul.FieldName = "ModulID";
            this.colModul.Name = "colModul";
            this.colModul.OptionsColumn.AllowEdit = false;
            this.colModul.OptionsColumn.AllowFocus = false;
            this.colModul.OptionsColumn.ReadOnly = true;
            this.colModul.Visible = true;
            this.colModul.VisibleIndex = 3;
            this.colModul.Width = 120;
            // 
            // edtKostenstelleModul
            // 
            this.edtKostenstelleModul.DataMember = "ModulID";
            this.edtKostenstelleModul.DataSource = this.qryKbKostenstelle;
            this.edtKostenstelleModul.Location = new System.Drawing.Point(96, 364);
            this.edtKostenstelleModul.LOVFilter = "ModulTree = 1";
            this.edtKostenstelleModul.LOVFilterWhereAppend = true;
            this.edtKostenstelleModul.LOVName = "Modul";
            this.edtKostenstelleModul.Name = "edtKostenstelleModul";
            this.edtKostenstelleModul.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelleModul.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelleModul.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelleModul.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelleModul.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelleModul.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelleModul.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKostenstelleModul.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelleModul.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKostenstelleModul.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKostenstelleModul.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKostenstelleModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKostenstelleModul.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenstelleModul.Properties.NullText = "";
            this.edtKostenstelleModul.Properties.ShowFooter = false;
            this.edtKostenstelleModul.Properties.ShowHeader = false;
            this.edtKostenstelleModul.Size = new System.Drawing.Size(264, 24);
            this.edtKostenstelleModul.TabIndex = 7;
            // 
            // lblKostenstelleModul
            // 
            this.lblKostenstelleModul.Location = new System.Drawing.Point(18, 364);
            this.lblKostenstelleModul.Name = "lblKostenstelleModul";
            this.lblKostenstelleModul.Size = new System.Drawing.Size(72, 24);
            this.lblKostenstelleModul.TabIndex = 6;
            this.lblKostenstelleModul.Text = "Modul";
            // 
            // chkKostenstelleAktiv
            // 
            this.chkKostenstelleAktiv.DataMember = "Aktiv";
            this.chkKostenstelleAktiv.DataSource = this.qryKbKostenstelle;
            this.chkKostenstelleAktiv.Location = new System.Drawing.Point(96, 339);
            this.chkKostenstelleAktiv.Name = "chkKostenstelleAktiv";
            this.chkKostenstelleAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkKostenstelleAktiv.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkKostenstelleAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkKostenstelleAktiv.Properties.Appearance.Options.UseForeColor = true;
            this.chkKostenstelleAktiv.Properties.Caption = "";
            this.chkKostenstelleAktiv.Size = new System.Drawing.Size(22, 19);
            this.chkKostenstelleAktiv.TabIndex = 5;
            // 
            // edtKostenstelleName
            // 
            this.edtKostenstelleName.DataMember = "Name";
            this.edtKostenstelleName.DataSource = this.qryKbKostenstelle;
            this.edtKostenstelleName.Location = new System.Drawing.Point(96, 309);
            this.edtKostenstelleName.Name = "edtKostenstelleName";
            this.edtKostenstelleName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelleName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelleName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelleName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelleName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelleName.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelleName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenstelleName.Size = new System.Drawing.Size(264, 24);
            this.edtKostenstelleName.TabIndex = 3;
            // 
            // lblKostenstelleName
            // 
            this.lblKostenstelleName.Location = new System.Drawing.Point(18, 309);
            this.lblKostenstelleName.Name = "lblKostenstelleName";
            this.lblKostenstelleName.Size = new System.Drawing.Size(72, 24);
            this.lblKostenstelleName.TabIndex = 2;
            this.lblKostenstelleName.Text = "Name";
            this.lblKostenstelleName.UseCompatibleTextRendering = true;
            // 
            // edtKostenstelleNr
            // 
            this.edtKostenstelleNr.DataMember = "Nr";
            this.edtKostenstelleNr.DataSource = this.qryKbKostenstelle;
            this.edtKostenstelleNr.Location = new System.Drawing.Point(96, 279);
            this.edtKostenstelleNr.Name = "edtKostenstelleNr";
            this.edtKostenstelleNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelleNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelleNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelleNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelleNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelleNr.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelleNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenstelleNr.Size = new System.Drawing.Size(264, 24);
            this.edtKostenstelleNr.TabIndex = 1;
            // 
            // lblKostenstelleNr
            // 
            this.lblKostenstelleNr.Location = new System.Drawing.Point(18, 279);
            this.lblKostenstelleNr.Name = "lblKostenstelleNr";
            this.lblKostenstelleNr.Size = new System.Drawing.Size(72, 24);
            this.lblKostenstelleNr.TabIndex = 0;
            this.lblKostenstelleNr.Text = "Nr";
            this.lblKostenstelleNr.UseCompatibleTextRendering = true;
            // 
            // lblKostenstelleAktiv
            // 
            this.lblKostenstelleAktiv.Location = new System.Drawing.Point(18, 334);
            this.lblKostenstelleAktiv.Name = "lblKostenstelleAktiv";
            this.lblKostenstelleAktiv.Size = new System.Drawing.Size(71, 24);
            this.lblKostenstelleAktiv.TabIndex = 4;
            this.lblKostenstelleAktiv.Text = "Aktiv";
            // 
            // CtlKbKostenstelleErfassung
            // 
            this.ActiveSQLQuery = this.qryKbKostenstelle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblKostenstelleAktiv);
            this.Controls.Add(this.edtKostenstelleNr);
            this.Controls.Add(this.lblKostenstelleNr);
            this.Controls.Add(this.edtKostenstelleName);
            this.Controls.Add(this.lblKostenstelleName);
            this.Controls.Add(this.edtKostenstelleModul);
            this.Controls.Add(this.lblKostenstelleModul);
            this.Controls.Add(this.chkKostenstelleAktiv);
            this.Name = "CtlKbKostenstelleErfassung";
            this.Load += new System.EventHandler(this.CtlKbKostenstelleErfassung_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.chkKostenstelleAktiv, 0);
            this.Controls.SetChildIndex(this.lblKostenstelleModul, 0);
            this.Controls.SetChildIndex(this.edtKostenstelleModul, 0);
            this.Controls.SetChildIndex(this.lblKostenstelleName, 0);
            this.Controls.SetChildIndex(this.edtKostenstelleName, 0);
            this.Controls.SetChildIndex(this.lblKostenstelleNr, 0);
            this.Controls.SetChildIndex(this.edtKostenstelleNr, 0);
            this.Controls.SetChildIndex(this.lblKostenstelleAktiv, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryKbKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKostenstelleAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleAktiv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.DB.SqlQuery qryKbKostenstelle;
        private KiSS4.Gui.KissLabel lblNr;
        private KiSS4.Gui.KissTextEdit edtNrX;
        private KiSS4.Gui.KissLabel lblNameX;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KiSS4.Gui.KissGrid grdKostenstelle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private KiSS4.Gui.KissLookUpEdit edtKostenstelleModul;
        private KiSS4.Gui.KissLabel lblKostenstelleModul;
        private KiSS4.Gui.KissCheckEdit chkKostenstelleAktiv;
        private KiSS4.Gui.KissTextEdit edtKostenstelleNr;
        private KiSS4.Gui.KissLabel lblKostenstelleNr;
        private KiSS4.Gui.KissTextEdit edtKostenstelleName;
        private KiSS4.Gui.KissLabel lblKostenstelleName;
        private KiSS4.Gui.KissLabel lblKostenstelleAktiv;
    }
}
