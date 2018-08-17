namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlQueryKbAbrechnungASVSFluechtling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbAbrechnungASVSFluechtling));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtBelegDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtBelegDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblBelegDatumVonX = new KiSS4.Gui.KissLabel();
            this.lblBelegDatumBisX = new KiSS4.Gui.KissLabel();
            this.colVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNachname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufenthaltsbewilligung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKrankenkasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUntVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUntBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlMonate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragKvg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatumVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatumBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
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
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVersichertennummer,
            this.colGeburtsdatum,
            this.colNachname,
            this.colVorname,
            this.colStrasse,
            this.colPLZ,
            this.colOrt,
            this.colAufenthaltsbewilligung,
            this.colKrankenkasse,
            this.colUntVon,
            this.colUntBis,
            this.colAnzahlMonate,
            this.colBetragKvg});
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowFooter = true;
            this.grvQuery1.OptionsView.ShowGroupedColumns = true;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Location = new System.Drawing.Point(0, 3);
            this.grdQuery1.Size = new System.Drawing.Size(782, 396);
            this.grdQuery1.XtraPrint += new KiSS4.Gui.XtraPrintEventHandler(this.grdQuery1_XtraPrint);
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(164, 426);
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
            this.ctlGotoFall.ActiveSQLQuery = this.qryQuery;
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 405);
            // 
            // searchTitle
            // 
            this.searchTitle.Location = new System.Drawing.Point(0, 3);
            this.searchTitle.Size = new System.Drawing.Size(773, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Location = new System.Drawing.Point(0, 28);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(797, 469);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(785, 431);
            this.tpgListe.TabIndex = 1;
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.lblBelegDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblBelegDatumVonX);
            this.tpgSuchen.Controls.Add(this.edtBelegDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtBelegDatumVonX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(785, 431);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBelegDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBelegDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBelegDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBelegDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            // 
            // edtBelegDatumVonX
            // 
            this.edtBelegDatumVonX.EditValue = null;
            this.edtBelegDatumVonX.Location = new System.Drawing.Point(107, 49);
            this.edtBelegDatumVonX.Name = "edtBelegDatumVonX";
            this.edtBelegDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBelegDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBelegDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatumVonX.Properties.Name = "editPerDatum.Properties";
            this.edtBelegDatumVonX.Properties.ShowToday = false;
            this.edtBelegDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtBelegDatumVonX.TabIndex = 383;
            // 
            // edtBelegDatumBisX
            // 
            this.edtBelegDatumBisX.EditValue = null;
            this.edtBelegDatumBisX.Location = new System.Drawing.Point(243, 49);
            this.edtBelegDatumBisX.Name = "edtBelegDatumBisX";
            this.edtBelegDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBelegDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBelegDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatumBisX.Properties.Name = "editPerDatum.Properties";
            this.edtBelegDatumBisX.Properties.ShowToday = false;
            this.edtBelegDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtBelegDatumBisX.TabIndex = 384;
            // 
            // lblBelegDatumVonX
            // 
            this.lblBelegDatumVonX.Location = new System.Drawing.Point(5, 49);
            this.lblBelegDatumVonX.Name = "lblBelegDatumVonX";
            this.lblBelegDatumVonX.Size = new System.Drawing.Size(96, 24);
            this.lblBelegDatumVonX.TabIndex = 385;
            this.lblBelegDatumVonX.Text = "Beleg-Datum von";
            this.lblBelegDatumVonX.UseCompatibleTextRendering = true;
            // 
            // lblBelegDatumBisX
            // 
            this.lblBelegDatumBisX.Location = new System.Drawing.Point(213, 49);
            this.lblBelegDatumBisX.Name = "lblBelegDatumBisX";
            this.lblBelegDatumBisX.Size = new System.Drawing.Size(24, 24);
            this.lblBelegDatumBisX.TabIndex = 386;
            this.lblBelegDatumBisX.Text = "bis";
            this.lblBelegDatumBisX.UseCompatibleTextRendering = true;
            // 
            // colVersichertennummer
            // 
            this.colVersichertennummer.Caption = "Versichertennummer";
            this.colVersichertennummer.FieldName = "Versichertennummer";
            this.colVersichertennummer.Name = "colVersichertennummer";
            this.colVersichertennummer.Visible = true;
            this.colVersichertennummer.VisibleIndex = 0;
            this.colVersichertennummer.Width = 141;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geburtsdatum";
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 1;
            // 
            // colNachname
            // 
            this.colNachname.Caption = "Name";
            this.colNachname.FieldName = "Nachname";
            this.colNachname.Name = "colNachname";
            this.colNachname.Visible = true;
            this.colNachname.VisibleIndex = 2;
            this.colNachname.Width = 80;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            this.colVorname.Width = 79;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 4;
            this.colStrasse.Width = 79;
            // 
            // colPLZ
            // 
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 5;
            this.colPLZ.Width = 79;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 6;
            this.colOrt.Width = 79;
            // 
            // colAufenthaltsbewilligung
            // 
            this.colAufenthaltsbewilligung.Caption = "Aufenthaltsbewilligung";
            this.colAufenthaltsbewilligung.FieldName = "Aufenthaltsbewilligung";
            this.colAufenthaltsbewilligung.Name = "colAufenthaltsbewilligung";
            this.colAufenthaltsbewilligung.Visible = true;
            this.colAufenthaltsbewilligung.VisibleIndex = 7;
            this.colAufenthaltsbewilligung.Width = 79;
            // 
            // colKrankenkasse
            // 
            this.colKrankenkasse.Caption = "Versicherer";
            this.colKrankenkasse.FieldName = "Krankenkasse";
            this.colKrankenkasse.Name = "colKrankenkasse";
            this.colKrankenkasse.Visible = true;
            this.colKrankenkasse.VisibleIndex = 8;
            this.colKrankenkasse.Width = 102;
            // 
            // colUntVon
            // 
            this.colUntVon.Caption = "Beginn der Unterstützung";
            this.colUntVon.FieldName = "UnterstuetztVon";
            this.colUntVon.Name = "colUntVon";
            this.colUntVon.Visible = true;
            this.colUntVon.VisibleIndex = 9;
            this.colUntVon.Width = 88;
            // 
            // colUntBis
            // 
            this.colUntBis.Caption = "Ende der Unterstützung";
            this.colUntBis.FieldName = "UnterstuetztBis";
            this.colUntBis.Name = "colUntBis";
            this.colUntBis.Visible = true;
            this.colUntBis.VisibleIndex = 10;
            this.colUntBis.Width = 88;
            // 
            // colAnzahlMonate
            // 
            this.colAnzahlMonate.Caption = "Anzahl Monate";
            this.colAnzahlMonate.FieldName = "Anzahlmonate";
            this.colAnzahlMonate.Name = "colAnzahlMonate";
            this.colAnzahlMonate.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAnzahlMonate.Visible = true;
            this.colAnzahlMonate.VisibleIndex = 11;
            this.colAnzahlMonate.Width = 102;
            // 
            // colBetragKvg
            // 
            this.colBetragKvg.Caption = "Betrag KVG";
            this.colBetragKvg.FieldName = "Betrag KVG";
            this.colBetragKvg.Name = "colBetragKvg";
            this.colBetragKvg.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragKvg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragKvg.Visible = true;
            this.colBetragKvg.VisibleIndex = 12;
            // 
            // edtOrgUnitID
            // 
            this.edtOrgUnitID.Location = new System.Drawing.Point(107, 79);
            this.edtOrgUnitID.Name = "edtOrgUnitID";
            this.edtOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(236, 24);
            this.edtOrgUnitID.TabIndex = 388;
            // 
            // lblSektion
            // 
            this.lblSektion.Location = new System.Drawing.Point(5, 79);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(96, 24);
            this.lblSektion.TabIndex = 387;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            // 
            // CtlQueryKbAbrechnungASVSFluechtling
            // 
            this.Name = "CtlQueryKbAbrechnungASVSFluechtling";
            this.Load += new System.EventHandler(this.CtlQueryKbAbrechnungASVS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatumVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatumBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlMonate;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthaltsbewilligung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragKvg;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKrankenkasse;
        private DevExpress.XtraGrid.Columns.GridColumn colNachname;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colUntBis;
        private DevExpress.XtraGrid.Columns.GridColumn colUntVon;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private KiSS4.Gui.KissDateEdit edtBelegDatumBisX;
        private KiSS4.Gui.KissDateEdit edtBelegDatumVonX;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissLabel lblBelegDatumBisX;
        private KiSS4.Gui.KissLabel lblBelegDatumVonX;
        private KiSS4.Gui.KissLabel lblSektion;
    }
}