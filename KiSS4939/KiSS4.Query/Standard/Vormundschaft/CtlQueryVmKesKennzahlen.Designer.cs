namespace KiSS4.Query
{
    partial class CtlQueryVmKesKennzahlen
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmKesKennzahlen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblNameBeistand1 = new KiSS4.Gui.KissLabel();
            this.lblNameBeistand2 = new KiSS4.Gui.KissLabel();
            this.edtInklAbgeschlosseneArchivierteFaelle = new KiSS4.Gui.KissCheckEdit();
            this.colAbmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdressat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKrzel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKundennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtNameBeistand1 = new KiSS4.Gui.KissButtonEdit();
            this.edtNameBeistand3 = new KiSS4.Gui.KissButtonEdit();
            this.lblNameBeistand3 = new KiSS4.Gui.KissLabel();
            this.edtNameBeistand2 = new KiSS4.Gui.KissButtonEdit();
            this.lblZeitraumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameBeistand1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameBeistand2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlosseneArchivierteFaelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBeistand1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBeistand3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameBeistand3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBeistand2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
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
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
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
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtNameBeistand1);
            this.tpgSuchen.Controls.Add(this.edtNameBeistand2);
            this.tpgSuchen.Controls.Add(this.edtNameBeistand3);
            this.tpgSuchen.Controls.Add(this.edtInklAbgeschlosseneArchivierteFaelle);
            this.tpgSuchen.Controls.Add(this.lblNameBeistand3);
            this.tpgSuchen.Controls.Add(this.lblNameBeistand2);
            this.tpgSuchen.Controls.Add(this.lblNameBeistand1);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameBeistand1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameBeistand2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameBeistand3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklAbgeschlosseneArchivierteFaelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameBeistand3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameBeistand2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameBeistand1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            // 
            // lblNameBeistand1
            // 
            this.lblNameBeistand1.Location = new System.Drawing.Point(10, 40);
            this.lblNameBeistand1.Name = "lblNameBeistand1";
            this.lblNameBeistand1.Size = new System.Drawing.Size(130, 24);
            this.lblNameBeistand1.TabIndex = 0;
            this.lblNameBeistand1.Text = "Name Beistand 1";
            this.lblNameBeistand1.UseCompatibleTextRendering = true;
            // 
            // lblNameBeistand2
            // 
            this.lblNameBeistand2.Location = new System.Drawing.Point(10, 70);
            this.lblNameBeistand2.Name = "lblNameBeistand2";
            this.lblNameBeistand2.Size = new System.Drawing.Size(130, 24);
            this.lblNameBeistand2.TabIndex = 2;
            this.lblNameBeistand2.Text = "Name Beistand 2";
            this.lblNameBeistand2.UseCompatibleTextRendering = true;
            // 
            // edtInklAbgeschlosseneArchivierteFaelle
            // 
            this.edtInklAbgeschlosseneArchivierteFaelle.EditValue = false;
            this.edtInklAbgeschlosseneArchivierteFaelle.Location = new System.Drawing.Point(150, 160);
            this.edtInklAbgeschlosseneArchivierteFaelle.Name = "edtInklAbgeschlosseneArchivierteFaelle";
            this.edtInklAbgeschlosseneArchivierteFaelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklAbgeschlosseneArchivierteFaelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklAbgeschlosseneArchivierteFaelle.Properties.Caption = "inkl. abgeschlossene/archivierte Massnahmen";
            this.edtInklAbgeschlosseneArchivierteFaelle.Size = new System.Drawing.Size(243, 19);
            this.edtInklAbgeschlosseneArchivierteFaelle.TabIndex = 9;
            // 
            // colAbmeldung
            // 
            this.colAbmeldung.Name = "colAbmeldung";
            // 
            // colAdressat
            // 
            this.colAdressat.Name = "colAdressat";
            // 
            // colAnmeldung
            // 
            this.colAnmeldung.Name = "colAnmeldung";
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Name = "colBemerkungen";
            // 
            // colKrzel
            // 
            this.colKrzel.Name = "colKrzel";
            // 
            // colKundennummer
            // 
            this.colKundennummer.Name = "colKundennummer";
            // 
            // colPerson
            // 
            this.colPerson.Name = "colPerson";
            // 
            // colSAR
            // 
            this.colSAR.Name = "colSAR";
            // 
            // edtNameBeistand1
            // 
            this.edtNameBeistand1.Location = new System.Drawing.Point(150, 40);
            this.edtNameBeistand1.Name = "edtNameBeistand1";
            this.edtNameBeistand1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameBeistand1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameBeistand1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameBeistand1.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameBeistand1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameBeistand1.Properties.Appearance.Options.UseFont = true;
            this.edtNameBeistand1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtNameBeistand1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtNameBeistand1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameBeistand1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtNameBeistand1.Size = new System.Drawing.Size(236, 24);
            this.edtNameBeistand1.TabIndex = 1;
            this.edtNameBeistand1.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameBeistand_UserModifiedFld);
            // 
            // edtNameBeistand3
            // 
            this.edtNameBeistand3.Location = new System.Drawing.Point(150, 100);
            this.edtNameBeistand3.Name = "edtNameBeistand3";
            this.edtNameBeistand3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameBeistand3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameBeistand3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameBeistand3.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameBeistand3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameBeistand3.Properties.Appearance.Options.UseFont = true;
            this.edtNameBeistand3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtNameBeistand3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtNameBeistand3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameBeistand3.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtNameBeistand3.Size = new System.Drawing.Size(236, 24);
            this.edtNameBeistand3.TabIndex = 5;
            this.edtNameBeistand3.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameBeistand_UserModifiedFld);
            // 
            // lblNameBeistand3
            // 
            this.lblNameBeistand3.Location = new System.Drawing.Point(10, 100);
            this.lblNameBeistand3.Name = "lblNameBeistand3";
            this.lblNameBeistand3.Size = new System.Drawing.Size(130, 24);
            this.lblNameBeistand3.TabIndex = 4;
            this.lblNameBeistand3.Text = "Name Beistand 3";
            this.lblNameBeistand3.UseCompatibleTextRendering = true;
            // 
            // edtNameBeistand2
            // 
            this.edtNameBeistand2.Location = new System.Drawing.Point(150, 70);
            this.edtNameBeistand2.Name = "edtNameBeistand2";
            this.edtNameBeistand2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameBeistand2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameBeistand2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameBeistand2.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameBeistand2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameBeistand2.Properties.Appearance.Options.UseFont = true;
            this.edtNameBeistand2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtNameBeistand2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtNameBeistand2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameBeistand2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtNameBeistand2.Size = new System.Drawing.Size(236, 24);
            this.edtNameBeistand2.TabIndex = 3;
            this.edtNameBeistand2.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameBeistand_UserModifiedFld);
            // 
            // lblZeitraumVon
            // 
            this.lblZeitraumVon.Location = new System.Drawing.Point(10, 130);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(130, 24);
            this.lblZeitraumVon.TabIndex = 6;
            this.lblZeitraumVon.Text = "Zeitraum von";
            this.lblZeitraumVon.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 130);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 7;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(256, 130);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(39, 24);
            this.lblbis.TabIndex = 26;
            this.lblbis.Text = "bis";
            this.lblbis.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(286, 130);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 8;
            // 
            // CtlQueryVmKesKennzahlen
            // 
            this.Name = "CtlQueryVmKesKennzahlen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblNameBeistand1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameBeistand2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlosseneArchivierteFaelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBeistand1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBeistand3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameBeistand3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBeistand2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAbmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colAdressat;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colKrzel;
        private DevExpress.XtraGrid.Columns.GridColumn colKundennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private KiSS4.Gui.KissCheckEdit edtInklAbgeschlosseneArchivierteFaelle;
        private KiSS4.Gui.KissLabel lblNameBeistand2;
        private KiSS4.Gui.KissLabel lblNameBeistand1;
        private Gui.KissButtonEdit edtNameBeistand1;
        private Gui.KissLabel lblZeitraumVon;
        private Gui.KissButtonEdit edtNameBeistand2;
        private Gui.KissButtonEdit edtNameBeistand3;
        private Gui.KissLabel lblNameBeistand3;
        private Gui.KissDateEdit edtDatumVon;
        private Gui.KissLabel lblbis;
        private Gui.KissDateEdit edtDatumBis;
    }
}
