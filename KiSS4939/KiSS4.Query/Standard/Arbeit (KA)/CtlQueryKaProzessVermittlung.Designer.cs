namespace KiSS4.Query
{
    partial class CtlQueryKaProzessVermittlung
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaProzessVermittlung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblZeitraumVon = new KiSS4.Gui.KissLabel();
            this.lblZeitraumBis = new KiSS4.Gui.KissLabel();
            this.lblStatusHeute = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtStatusHeuteCode = new KiSS4.Gui.KissLookUpEdit();
            this.colAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgRohdaten = new SharpLibrary.WinControls.TabPageEx();
            this.grdRohdaten = new KiSS4.Gui.KissGrid();
            this.grvRohdaten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblNameSTES = new KiSS4.Gui.KissLabel();
            this.edtNameSTES = new KiSS4.Gui.KissButtonEdit();
            this.edtZustKA = new KiSS4.Gui.KissButtonEdit();
            this.lblZustKA = new KiSS4.Gui.KissLabel();
            this.edtEinsatz = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinsatz = new KiSS4.Gui.KissLabel();
            this.lblLeistung = new KiSS4.Gui.KissLabel();
            this.edtLeistung = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeuteCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeuteCode.Properties)).BeginInit();
            this.tpgRohdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTES.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung.Properties)).BeginInit();
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
            this.tpgSuchen.Controls.Add(this.lblLeistung);
            this.tpgSuchen.Controls.Add(this.edtLeistung);
            this.tpgSuchen.Controls.Add(this.edtEinsatz);
            this.tpgSuchen.Controls.Add(this.lblEinsatz);
            this.tpgSuchen.Controls.Add(this.edtZustKA);
            this.tpgSuchen.Controls.Add(this.lblZustKA);
            this.tpgSuchen.Controls.Add(this.lblNameSTES);
            this.tpgSuchen.Controls.Add(this.edtNameSTES);
            this.tpgSuchen.Controls.Add(this.edtStatusHeuteCode);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblStatusHeute);
            this.tpgSuchen.Controls.Add(this.lblZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumVon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusHeuteCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameSTES, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameSTES, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLeistung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistung, 0);
            // 
            // lblZeitraumVon
            // 
            this.lblZeitraumVon.Location = new System.Drawing.Point(8, 205);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(134, 24);
            this.lblZeitraumVon.TabIndex = 9;
            this.lblZeitraumVon.Text = "Zeitraum von";
            this.lblZeitraumVon.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumBis
            // 
            this.lblZeitraumBis.Location = new System.Drawing.Point(254, 205);
            this.lblZeitraumBis.Name = "lblZeitraumBis";
            this.lblZeitraumBis.Size = new System.Drawing.Size(38, 24);
            this.lblZeitraumBis.TabIndex = 11;
            this.lblZeitraumBis.Text = "bis";
            this.lblZeitraumBis.UseCompatibleTextRendering = true;
            // 
            // lblStatusHeute
            // 
            this.lblStatusHeute.Location = new System.Drawing.Point(8, 145);
            this.lblStatusHeute.Name = "lblStatusHeute";
            this.lblStatusHeute.Size = new System.Drawing.Size(134, 24);
            this.lblStatusHeute.TabIndex = 5;
            this.lblStatusHeute.Text = "Status heute";
            this.lblStatusHeute.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(148, 205);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 10;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(298, 205);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 12;
            // 
            // edtStatusHeuteCode
            // 
            this.edtStatusHeuteCode.Location = new System.Drawing.Point(148, 145);
            this.edtStatusHeuteCode.LOVName = "FaLeistungStatusAbfrage";
            this.edtStatusHeuteCode.Name = "edtStatusHeuteCode";
            this.edtStatusHeuteCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusHeuteCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusHeuteCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusHeuteCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusHeuteCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusHeuteCode.Properties.Appearance.Options.UseFont = true;
            this.edtStatusHeuteCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatusHeuteCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusHeuteCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusHeuteCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusHeuteCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtStatusHeuteCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtStatusHeuteCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusHeuteCode.Properties.NullText = "";
            this.edtStatusHeuteCode.Properties.ShowFooter = false;
            this.edtStatusHeuteCode.Properties.ShowHeader = false;
            this.edtStatusHeuteCode.Size = new System.Drawing.Size(250, 24);
            this.edtStatusHeuteCode.TabIndex = 6;
            // 
            // colAnzahl
            // 
            this.colAnzahl.Name = "colAnzahl";
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Name = "colBezeichnung";
            // 
            // tpgRohdaten
            // 
            this.tpgRohdaten.Controls.Add(this.grdRohdaten);
            this.tpgRohdaten.Location = new System.Drawing.Point(6, 6);
            this.tpgRohdaten.Name = "tpgRohdaten";
            this.tpgRohdaten.Size = new System.Drawing.Size(772, 424);
            this.tpgRohdaten.TabIndex = 1;
            this.tpgRohdaten.Title = "Rohdaten";
            // 
            // grdRohdaten
            // 
            this.grdRohdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRohdaten.ColumnFilterActivated = true;
            // 
            // 
            // 
            this.grdRohdaten.EmbeddedNavigator.Name = "";
            this.grdRohdaten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRohdaten.Location = new System.Drawing.Point(3, 1);
            this.grdRohdaten.MainView = this.grvRohdaten;
            this.grdRohdaten.Name = "grdRohdaten";
            this.grdRohdaten.Size = new System.Drawing.Size(766, 420);
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
            this.grvRohdaten.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRohdaten.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            // lblNameSTES
            // 
            this.lblNameSTES.Location = new System.Drawing.Point(8, 85);
            this.lblNameSTES.Name = "lblNameSTES";
            this.lblNameSTES.Size = new System.Drawing.Size(134, 24);
            this.lblNameSTES.TabIndex = 3;
            this.lblNameSTES.Text = "STES";
            this.lblNameSTES.UseCompatibleTextRendering = true;
            // 
            // edtNameSTES
            // 
            this.edtNameSTES.Location = new System.Drawing.Point(148, 85);
            this.edtNameSTES.Name = "edtNameSTES";
            this.edtNameSTES.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSTES.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSTES.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSTES.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSTES.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSTES.Properties.Appearance.Options.UseFont = true;
            this.edtNameSTES.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtNameSTES.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtNameSTES.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameSTES.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtNameSTES.Size = new System.Drawing.Size(250, 24);
            this.edtNameSTES.TabIndex = 4;
            this.edtNameSTES.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameSTES_UserModifiedFld);
            // 
            // edtZustKA
            // 
            this.edtZustKA.Location = new System.Drawing.Point(148, 55);
            this.edtZustKA.Name = "edtZustKA";
            this.edtZustKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustKA.Properties.Appearance.Options.UseFont = true;
            this.edtZustKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZustKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZustKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustKA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZustKA.Size = new System.Drawing.Size(250, 24);
            this.edtZustKA.TabIndex = 2;
            this.edtZustKA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustKA_UserModifiedFld);
            // 
            // lblZustKA
            // 
            this.lblZustKA.Location = new System.Drawing.Point(8, 55);
            this.lblZustKA.Name = "lblZustKA";
            this.lblZustKA.Size = new System.Drawing.Size(134, 24);
            this.lblZustKA.TabIndex = 1;
            this.lblZustKA.Text = "Zuständig KA";
            this.lblZustKA.UseCompatibleTextRendering = true;
            // 
            // edtEinsatz
            // 
            this.edtEinsatz.Location = new System.Drawing.Point(148, 175);
            this.edtEinsatz.LOVName = "JaNein";
            this.edtEinsatz.Name = "edtEinsatz";
            this.edtEinsatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinsatz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinsatz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinsatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEinsatz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEinsatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatz.Properties.NullText = "";
            this.edtEinsatz.Properties.ShowFooter = false;
            this.edtEinsatz.Properties.ShowHeader = false;
            this.edtEinsatz.Size = new System.Drawing.Size(250, 24);
            this.edtEinsatz.TabIndex = 8;
            // 
            // lblEinsatz
            // 
            this.lblEinsatz.Location = new System.Drawing.Point(8, 175);
            this.lblEinsatz.Name = "lblEinsatz";
            this.lblEinsatz.Size = new System.Drawing.Size(134, 24);
            this.lblEinsatz.TabIndex = 7;
            this.lblEinsatz.Text = "Einsatz";
            // 
            // lblLeistung
            // 
            this.lblLeistung.Location = new System.Drawing.Point(8, 115);
            this.lblLeistung.Name = "lblLeistung";
            this.lblLeistung.Size = new System.Drawing.Size(134, 24);
            this.lblLeistung.TabIndex = 14;
            this.lblLeistung.Text = "Leistung";
            // 
            // edtLeistung
            // 
            this.edtLeistung.Location = new System.Drawing.Point(148, 115);
            this.edtLeistung.Name = "edtLeistung";
            this.edtLeistung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeistung.Properties.Appearance.Options.UseFont = true;
            this.edtLeistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLeistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLeistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLeistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtLeistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtLeistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeistung.Properties.NullText = "";
            this.edtLeistung.Properties.ShowFooter = false;
            this.edtLeistung.Properties.ShowHeader = false;
            this.edtLeistung.Size = new System.Drawing.Size(250, 24);
            this.edtLeistung.TabIndex = 13;
            // 
            // CtlQueryKaProzessVermittlung
            // 
            this.Name = "CtlQueryKaProzessVermittlung";
            this.Load += new System.EventHandler(this.CtlQueryKaProzessVermittlung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeuteCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeuteCode)).EndInit();
            this.tpgRohdaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTES.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtStatusHeuteCode;
        private KiSS4.Gui.KissLabel lblZeitraumVon;
        private KiSS4.Gui.KissLabel lblStatusHeute;
        private SharpLibrary.WinControls.TabPageEx tpgRohdaten;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdRohdaten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRohdaten;
        private KiSS4.Gui.KissLabel lblZeitraumBis;
        private Gui.KissLabel lblNameSTES;
        private Gui.KissButtonEdit edtNameSTES;
        private Gui.KissButtonEdit edtZustKA;
        private Gui.KissLabel lblZustKA;
        private Gui.KissLookUpEdit edtEinsatz;
        private Gui.KissLabel lblEinsatz;
        private Gui.KissLabel lblLeistung;
        private Gui.KissLookUpEdit edtLeistung;
    }
}
