namespace KiSS4.Sostat
{
    partial class CtlBfsQueryKennzahlen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBfsQueryKennzahlen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblErhebungsjahr = new KiSS4.Gui.KissLabel();
            this.edtErhebungsjahr = new KiSS4.Gui.KissTextEdit();
            this.lblAuszahlung = new KiSS4.Gui.KissLabel();
            this.edtAuszahlungVon = new KiSS4.Gui.KissDateEdit();
            this.edtAuszahlungBis = new KiSS4.Gui.KissDateEdit();
            this.lblAuszahlungBis = new KiSS4.Gui.KissLabel();
            this.edtNettobedarf = new KiSS4.Gui.KissCheckEdit();
            this.edtProDossier = new KiSS4.Gui.KissCheckEdit();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWertBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvGeneric = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErhebungsjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNettobedarf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProDossier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGeneric)).BeginInit();
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
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBezeichnung,
            this.colWertBetrag});
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
            this.grvGeneric});
            // 
            // xDocument
            // 
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblErhebungsjahr);
            this.tpgSuchen.Controls.Add(this.edtProDossier);
            this.tpgSuchen.Controls.Add(this.edtNettobedarf);
            this.tpgSuchen.Controls.Add(this.edtAuszahlungVon);
            this.tpgSuchen.Controls.Add(this.lblAuszahlung);
            this.tpgSuchen.Controls.Add(this.lblAuszahlungBis);
            this.tpgSuchen.Controls.Add(this.edtErhebungsjahr);
            this.tpgSuchen.Controls.Add(this.edtAuszahlungBis);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuszahlungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErhebungsjahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuszahlungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuszahlung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuszahlungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNettobedarf, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtProDossier, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblErhebungsjahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // lblErhebungsjahr
            // 
            this.lblErhebungsjahr.Location = new System.Drawing.Point(8, 39);
            this.lblErhebungsjahr.Name = "lblErhebungsjahr";
            this.lblErhebungsjahr.Size = new System.Drawing.Size(82, 24);
            this.lblErhebungsjahr.TabIndex = 1;
            this.lblErhebungsjahr.Text = "Jahr";
            // 
            // edtErhebungsjahr
            // 
            this.edtErhebungsjahr.Location = new System.Drawing.Point(119, 38);
            this.edtErhebungsjahr.Name = "edtErhebungsjahr";
            this.edtErhebungsjahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErhebungsjahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErhebungsjahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErhebungsjahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtErhebungsjahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErhebungsjahr.Properties.Appearance.Options.UseFont = true;
            this.edtErhebungsjahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErhebungsjahr.Size = new System.Drawing.Size(100, 24);
            this.edtErhebungsjahr.TabIndex = 2;
            // 
            // lblAuszahlung
            // 
            this.lblAuszahlung.Location = new System.Drawing.Point(8, 69);
            this.lblAuszahlung.Name = "lblAuszahlung";
            this.lblAuszahlung.Size = new System.Drawing.Size(100, 23);
            this.lblAuszahlung.TabIndex = 3;
            this.lblAuszahlung.Text = "Letzte Auszahlung";
            // 
            // edtAuszahlungVon
            // 
            this.edtAuszahlungVon.EditValue = null;
            this.edtAuszahlungVon.Location = new System.Drawing.Point(119, 68);
            this.edtAuszahlungVon.Name = "edtAuszahlungVon";
            this.edtAuszahlungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuszahlungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuszahlungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszahlungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszahlungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszahlungVon.Properties.Appearance.Options.UseFont = true;
            this.edtAuszahlungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAuszahlungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAuszahlungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAuszahlungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuszahlungVon.Properties.ShowToday = false;
            this.edtAuszahlungVon.Size = new System.Drawing.Size(100, 24);
            this.edtAuszahlungVon.TabIndex = 4;
            // 
            // edtAuszahlungBis
            // 
            this.edtAuszahlungBis.EditValue = null;
            this.edtAuszahlungBis.Location = new System.Drawing.Point(270, 68);
            this.edtAuszahlungBis.Name = "edtAuszahlungBis";
            this.edtAuszahlungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuszahlungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuszahlungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszahlungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszahlungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszahlungBis.Properties.Appearance.Options.UseFont = true;
            this.edtAuszahlungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAuszahlungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAuszahlungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAuszahlungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuszahlungBis.Properties.ShowToday = false;
            this.edtAuszahlungBis.Size = new System.Drawing.Size(100, 24);
            this.edtAuszahlungBis.TabIndex = 5;
            // 
            // lblAuszahlungBis
            // 
            this.lblAuszahlungBis.Location = new System.Drawing.Point(234, 69);
            this.lblAuszahlungBis.Name = "lblAuszahlungBis";
            this.lblAuszahlungBis.Size = new System.Drawing.Size(30, 24);
            this.lblAuszahlungBis.TabIndex = 6;
            this.lblAuszahlungBis.Text = "bis";
            // 
            // edtNettobedarf
            // 
            this.edtNettobedarf.EditValue = true;
            this.edtNettobedarf.Location = new System.Drawing.Point(119, 108);
            this.edtNettobedarf.Name = "edtNettobedarf";
            this.edtNettobedarf.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNettobedarf.Properties.Appearance.Options.UseBackColor = true;
            this.edtNettobedarf.Properties.Caption = "Nettobedarf >= 0";
            this.edtNettobedarf.Size = new System.Drawing.Size(115, 19);
            this.edtNettobedarf.TabIndex = 7;
            // 
            // edtProDossier
            // 
            this.edtProDossier.EditValue = false;
            this.edtProDossier.Location = new System.Drawing.Point(119, 133);
            this.edtProDossier.Name = "edtProDossier";
            this.edtProDossier.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtProDossier.Properties.Appearance.Options.UseBackColor = true;
            this.edtProDossier.Properties.Caption = "Pro Dossier";
            this.edtProDossier.Size = new System.Drawing.Size(115, 19);
            this.edtProDossier.TabIndex = 8;
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "Bezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 0;
            this.colBezeichnung.Width = 411;
            // 
            // colWertBetrag
            // 
            this.colWertBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colWertBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colWertBetrag.Caption = "Wert / Betrag";
            this.colWertBetrag.DisplayFormat.FormatString = "N2";
            this.colWertBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWertBetrag.FieldName = "WertBetrag";
            this.colWertBetrag.Name = "colWertBetrag";
            this.colWertBetrag.Visible = true;
            this.colWertBetrag.VisibleIndex = 1;
            this.colWertBetrag.Width = 208;
            // 
            // grvGeneric
            // 
            this.grvGeneric.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGeneric.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.Empty.Options.UseBackColor = true;
            this.grvGeneric.Appearance.Empty.Options.UseFont = true;
            this.grvGeneric.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvGeneric.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvGeneric.Appearance.EvenRow.Options.UseFont = true;
            this.grvGeneric.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGeneric.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGeneric.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGeneric.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGeneric.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGeneric.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGeneric.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGeneric.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGeneric.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGeneric.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGeneric.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGeneric.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGeneric.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGeneric.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGeneric.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGeneric.Appearance.GroupRow.Options.UseFont = true;
            this.grvGeneric.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGeneric.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGeneric.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGeneric.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGeneric.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGeneric.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGeneric.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGeneric.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGeneric.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGeneric.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGeneric.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGeneric.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGeneric.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGeneric.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvGeneric.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.OddRow.Options.UseBackColor = true;
            this.grvGeneric.Appearance.OddRow.Options.UseFont = true;
            this.grvGeneric.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGeneric.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.Row.Options.UseBackColor = true;
            this.grvGeneric.Appearance.Row.Options.UseFont = true;
            this.grvGeneric.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvGeneric.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeneric.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvGeneric.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvGeneric.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGeneric.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvGeneric.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGeneric.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGeneric.BestFitMaxRowCount = 50;
            this.grvGeneric.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGeneric.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGeneric.GridControl = this.grdQuery1;
            this.grvGeneric.Name = "grvGeneric";
            this.grvGeneric.OptionsBehavior.Editable = false;
            this.grvGeneric.OptionsCustomization.AllowFilter = false;
            this.grvGeneric.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGeneric.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGeneric.OptionsNavigation.UseTabKey = false;
            this.grvGeneric.OptionsPrint.AutoWidth = false;
            this.grvGeneric.OptionsPrint.ExpandAllDetails = true;
            this.grvGeneric.OptionsPrint.UsePrintStyles = true;
            this.grvGeneric.OptionsView.ColumnAutoWidth = false;
            this.grvGeneric.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGeneric.OptionsView.ShowGroupPanel = false;
            this.grvGeneric.OptionsView.ShowIndicator = false;
            // 
            // CtlBfsQueryKennzahlen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtlBfsQueryKennzahlen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErhebungsjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNettobedarf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProDossier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGeneric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLabel lblErhebungsjahr;
        private Gui.KissTextEdit edtErhebungsjahr;
        private Gui.KissLabel lblAuszahlungBis;
        private Gui.KissDateEdit edtAuszahlungBis;
        private Gui.KissDateEdit edtAuszahlungVon;
        private Gui.KissLabel lblAuszahlung;
        private Gui.KissCheckEdit edtProDossier;
        private Gui.KissCheckEdit edtNettobedarf;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colWertBetrag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGeneric;
    }
}
