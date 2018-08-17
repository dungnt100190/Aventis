namespace KiSS4.Query
{
    partial class CtlQueryKaQJStatistik
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaQJStatistik));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblDatumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblNiveau = new KiSS4.Gui.KissLabel();
            this.lblZuweiser = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtNiveauCode = new KiSS4.Gui.KissLookUpEdit();
            this.colAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgRohdaten = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallRohdaten = new KiSS4.Common.CtlGotoFall();
            this.qryRohdaten = new KiSS4.DB.SqlQuery(this.components);
            this.grdRohdaten = new KiSS4.Gui.KissGrid();
            this.grvRohdaten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtAPVCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAPV = new KiSS4.Gui.KissLabel();
            this.edtAPVZusatz = new KiSS4.Gui.KissLookUpEdit();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.edtZuweiser = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpgRohdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuweiser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Visible = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgRohdaten);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgRohdaten});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgRohdaten, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtZuweiser);
            this.tpgSuchen.Controls.Add(this.edtAPVZusatz);
            this.tpgSuchen.Controls.Add(this.lblZusatz);
            this.tpgSuchen.Controls.Add(this.edtAPVCode);
            this.tpgSuchen.Controls.Add(this.lblAPV);
            this.tpgSuchen.Controls.Add(this.edtNiveauCode);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblZuweiser);
            this.tpgSuchen.Controls.Add(this.lblNiveau);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblDatumvon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNiveau, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZuweiser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNiveauCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAPV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAPVCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZusatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAPVZusatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZuweiser, 0);
            // 
            // lblDatumvon
            // 
            this.lblDatumvon.Location = new System.Drawing.Point(10, 40);
            this.lblDatumvon.Name = "lblDatumvon";
            this.lblDatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumvon.TabIndex = 1;
            this.lblDatumvon.Text = "Datum von";
            this.lblDatumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(256, 40);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(42, 24);
            this.lblbis.TabIndex = 3;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // lblNiveau
            // 
            this.lblNiveau.Location = new System.Drawing.Point(10, 100);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(130, 24);
            this.lblNiveau.TabIndex = 9;
            this.lblNiveau.Text = "Niveau";
            this.lblNiveau.UseCompatibleTextRendering = true;
            // 
            // lblZuweiser
            // 
            this.lblZuweiser.Location = new System.Drawing.Point(10, 130);
            this.lblZuweiser.Name = "lblZuweiser";
            this.lblZuweiser.Size = new System.Drawing.Size(130, 24);
            this.lblZuweiser.TabIndex = 11;
            this.lblZuweiser.Text = "Zuweiser";
            this.lblZuweiser.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 40);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(292, 40);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 4;
            // 
            // edtNiveauCode
            // 
            this.edtNiveauCode.Location = new System.Drawing.Point(150, 100);
            this.edtNiveauCode.LOVName = "KaQjNiveau";
            this.edtNiveauCode.Name = "edtNiveauCode";
            this.edtNiveauCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNiveauCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNiveauCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNiveauCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNiveauCode.Properties.Appearance.Options.UseFont = true;
            this.edtNiveauCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNiveauCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNiveauCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNiveauCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtNiveauCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNiveauCode.Properties.NullText = "";
            this.edtNiveauCode.Properties.ShowFooter = false;
            this.edtNiveauCode.Properties.ShowHeader = false;
            this.edtNiveauCode.Size = new System.Drawing.Size(242, 24);
            this.edtNiveauCode.TabIndex = 10;
            // 
            // colAnzahl
            // 
            this.colAnzahl.Name = "colAnzahl";
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Name = "colBezeichnung";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // tpgRohdaten
            // 
            this.tpgRohdaten.Controls.Add(this.ctlGotoFallRohdaten);
            this.tpgRohdaten.Controls.Add(this.grdRohdaten);
            this.tpgRohdaten.Location = new System.Drawing.Point(6, 6);
            this.tpgRohdaten.Name = "tpgRohdaten";
            this.tpgRohdaten.Size = new System.Drawing.Size(772, 424);
            this.tpgRohdaten.TabIndex = 1;
            this.tpgRohdaten.Title = "Rohdaten";
            // 
            // ctlGotoFallRohdaten
            // 
            this.ctlGotoFallRohdaten.ActiveSQLQuery = this.qryRohdaten;
            this.ctlGotoFallRohdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallRohdaten.DataMember = "BaPersonID$";
            this.ctlGotoFallRohdaten.DataSource = this.qryRohdaten;
            this.ctlGotoFallRohdaten.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFallRohdaten.Name = "ctlGotoFallRohdaten";
            this.ctlGotoFallRohdaten.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallRohdaten.TabIndex = 7;
            // 
            // qryRohdaten
            // 
            this.qryRohdaten.FillTimeOut = 300;
            this.qryRohdaten.HostControl = this;
            this.qryRohdaten.SelectStatement = resources.GetString("qryRohdaten.SelectStatement");
            // 
            // grdRohdaten
            // 
            this.grdRohdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRohdaten.ColumnFilterActivated = true;
            this.grdRohdaten.DataSource = this.qryRohdaten;
            // 
            // 
            // 
            this.grdRohdaten.EmbeddedNavigator.Name = "";
            this.grdRohdaten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRohdaten.Location = new System.Drawing.Point(3, 1);
            this.grdRohdaten.MainView = this.grvRohdaten;
            this.grdRohdaten.Name = "grdRohdaten";
            this.grdRohdaten.Size = new System.Drawing.Size(766, 392);
            this.grdRohdaten.TabIndex = 6;
            this.grdRohdaten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRohdaten});
            // 
            // grvRohdaten
            // 
            this.grvRohdaten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRohdaten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.Empty.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.Empty.Options.UseFont = true;
            this.grvRohdaten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.EvenRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.GroupRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRohdaten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRohdaten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRohdaten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRohdaten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.OddRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRohdaten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.Row.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.Row.Options.UseFont = true;
            this.grvRohdaten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRohdaten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRohdaten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRohdaten.GridControl = this.grdRohdaten;
            this.grvRohdaten.Name = "grvRohdaten";
            this.grvRohdaten.OptionsBehavior.Editable = false;
            this.grvRohdaten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRohdaten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRohdaten.OptionsNavigation.UseTabKey = false;
            this.grvRohdaten.OptionsView.ColumnAutoWidth = false;
            this.grvRohdaten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRohdaten.OptionsView.ShowGroupPanel = false;
            this.grvRohdaten.OptionsView.ShowIndicator = false;
            // 
            // edtAPVCode
            // 
            this.edtAPVCode.Location = new System.Drawing.Point(150, 70);
            this.edtAPVCode.LOVName = "KaAPV";
            this.edtAPVCode.Name = "edtAPVCode";
            this.edtAPVCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAPVCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAPVCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAPVCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAPVCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAPVCode.Properties.Appearance.Options.UseFont = true;
            this.edtAPVCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAPVCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAPVCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAPVCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAPVCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAPVCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAPVCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAPVCode.Properties.NullText = "";
            this.edtAPVCode.Properties.ShowFooter = false;
            this.edtAPVCode.Properties.ShowHeader = false;
            this.edtAPVCode.Size = new System.Drawing.Size(242, 24);
            this.edtAPVCode.TabIndex = 6;
            // 
            // lblAPV
            // 
            this.lblAPV.Location = new System.Drawing.Point(10, 70);
            this.lblAPV.Name = "lblAPV";
            this.lblAPV.Size = new System.Drawing.Size(130, 24);
            this.lblAPV.TabIndex = 5;
            this.lblAPV.Text = "APV-Nr";
            this.lblAPV.UseCompatibleTextRendering = true;
            // 
            // edtAPVZusatz
            // 
            this.edtAPVZusatz.Location = new System.Drawing.Point(452, 70);
            this.edtAPVZusatz.LOVName = "KaAPVZusatz";
            this.edtAPVZusatz.Name = "edtAPVZusatz";
            this.edtAPVZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAPVZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAPVZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAPVZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAPVZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAPVZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAPVZusatz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAPVZusatz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAPVZusatz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAPVZusatz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAPVZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAPVZusatz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAPVZusatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAPVZusatz.Properties.NullText = "";
            this.edtAPVZusatz.Properties.ShowFooter = false;
            this.edtAPVZusatz.Properties.ShowHeader = false;
            this.edtAPVZusatz.Size = new System.Drawing.Size(86, 24);
            this.edtAPVZusatz.TabIndex = 8;
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(404, 70);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(42, 24);
            this.lblZusatz.TabIndex = 7;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            // 
            // edtZuweiser
            // 
            this.edtZuweiser.Location = new System.Drawing.Point(150, 130);
            this.edtZuweiser.Name = "edtZuweiser";
            this.edtZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtZuweiser.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZuweiser.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZuweiser.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZuweiser.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtZuweiser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtZuweiser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZuweiser.Properties.NullText = "";
            this.edtZuweiser.Properties.ShowFooter = false;
            this.edtZuweiser.Properties.ShowHeader = false;
            this.edtZuweiser.Size = new System.Drawing.Size(242, 24);
            this.edtZuweiser.TabIndex = 13;
            // 
            // CtlQueryKaQJStatistik
            // 
            this.Name = "CtlQueryKaQJStatistik";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpgRohdaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAPVZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuweiser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtNiveauCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblDatumvon;
        private KiSS4.Gui.KissLabel lblNiveau;
        private KiSS4.Gui.KissLabel lblZuweiser;
        private SharpLibrary.WinControls.TabPageEx tpgRohdaten;
        private KiSS4.DB.SqlQuery qryRohdaten;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallRohdaten;
        private KiSS4.Gui.KissGrid grdRohdaten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRohdaten;
        private KiSS4.Gui.KissLabel lblbis;
        private Gui.KissLookUpEdit edtAPVZusatz;
        private Gui.KissLabel lblZusatz;
        private Gui.KissLookUpEdit edtAPVCode;
        private Gui.KissLabel lblAPV;
        private Gui.KissLookUpEdit edtZuweiser;
    }
}
