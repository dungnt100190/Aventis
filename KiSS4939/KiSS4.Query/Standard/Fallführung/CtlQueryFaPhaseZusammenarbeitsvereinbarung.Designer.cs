namespace KiSS4.Query
{
    partial class CtlQueryFaPhaseZusammenarbeitsvereinbarung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaPhaseZusammenarbeitsvereinbarung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.chkNurAktiveF = new KiSS4.Gui.KissCheckEdit();
            this.edtSAR = new KiSS4.Gui.KissButtonEdit();
            this.edtSektion = new KiSS4.Gui.KissLookUpEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.chkFMitOffenemS = new KiSS4.Gui.KissCheckEdit();
            this.chkAbgeschlosseneAusblenden = new KiSS4.Gui.KissCheckEdit();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVornameDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntscheidDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustaendigkeitBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulEroeffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSModulOffen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhaseEroeffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhaseAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVertragsdokument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeginnVertrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswertungGeplant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAktiveF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFMitOffenemS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgeschlosseneAusblenden.Properties)).BeginInit();
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
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSektion,
            this.colSAR,
            this.colNameDT,
            this.colVornameDT,
            this.colFallNr,
            this.colVersichertennummer,
            this.colZivilstand,
            this.colEntscheidDatum,
            this.colZustaendigkeitBis,
            this.colModul,
            this.colModulEroeffnet,
            this.colModulAbgeschlossen,
            this.colSModulOffen,
            this.colPhase,
            this.colPhaseEroeffnet,
            this.colPhaseAbgeschlossen,
            this.colVertragsdokument,
            this.colBeginnVertrag,
            this.colAuswertungGeplant});
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
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.chkAbgeschlosseneAusblenden);
            this.tpgSuchen.Controls.Add(this.chkFMitOffenemS);
            this.tpgSuchen.Controls.Add(this.chkNurAktiveF);
            this.tpgSuchen.Controls.Add(this.edtSAR);
            this.tpgSuchen.Controls.Add(this.edtSektion);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkNurAktiveF, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkFMitOffenemS, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkAbgeschlosseneAusblenden, 0);
            // 
            // chkNurAktiveF
            // 
            this.chkNurAktiveF.EditValue = true;
            this.chkNurAktiveF.Location = new System.Drawing.Point(149, 98);
            this.chkNurAktiveF.Name = "chkNurAktiveF";
            this.chkNurAktiveF.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkNurAktiveF.Properties.Appearance.Options.UseBackColor = true;
            this.chkNurAktiveF.Properties.Caption = "nur aktive F-Module";
            this.chkNurAktiveF.Size = new System.Drawing.Size(250, 19);
            this.chkNurAktiveF.TabIndex = 32;
            // 
            // edtSAR
            // 
            this.edtSAR.Location = new System.Drawing.Point(149, 68);
            this.edtSAR.LookupSQL = resources.GetString("edtSAR.LookupSQL");
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSAR.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSAR.Size = new System.Drawing.Size(250, 24);
            this.edtSAR.TabIndex = 30;
            // 
            // edtSektion
            // 
            this.edtSektion.Location = new System.Drawing.Point(149, 38);
            this.edtSektion.Name = "edtSektion";
            this.edtSektion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSektion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSektion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektion.Properties.Appearance.Options.UseBackColor = true;
            this.edtSektion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSektion.Properties.Appearance.Options.UseFont = true;
            this.edtSektion.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSektion.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektion.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSektion.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSektion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSektion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSektion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSektion.Properties.NullText = "";
            this.edtSektion.Properties.ShowFooter = false;
            this.edtSektion.Properties.ShowHeader = false;
            this.edtSektion.Size = new System.Drawing.Size(250, 24);
            this.edtSektion.TabIndex = 29;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(9, 68);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 27;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // lblSektion
            // 
            this.lblSektion.Location = new System.Drawing.Point(9, 38);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(130, 24);
            this.lblSektion.TabIndex = 26;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            // 
            // chkFMitOffenemS
            // 
            this.chkFMitOffenemS.EditValue = true;
            this.chkFMitOffenemS.Location = new System.Drawing.Point(149, 123);
            this.chkFMitOffenemS.Name = "chkFMitOffenemS";
            this.chkFMitOffenemS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFMitOffenemS.Properties.Appearance.Options.UseBackColor = true;
            this.chkFMitOffenemS.Properties.Caption = "nur F-Module mit offenem S-Modul";
            this.chkFMitOffenemS.Size = new System.Drawing.Size(250, 19);
            this.chkFMitOffenemS.TabIndex = 33;
            // 
            // chkAbgeschlosseneAusblenden
            // 
            this.chkAbgeschlosseneAusblenden.EditValue = true;
            this.chkAbgeschlosseneAusblenden.Location = new System.Drawing.Point(149, 148);
            this.chkAbgeschlosseneAusblenden.Name = "chkAbgeschlosseneAusblenden";
            this.chkAbgeschlosseneAusblenden.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAbgeschlosseneAusblenden.Properties.Appearance.Options.UseBackColor = true;
            this.chkAbgeschlosseneAusblenden.Properties.Caption = "abgeschlossene Phasen ausblenden";
            this.chkAbgeschlosseneAusblenden.Size = new System.Drawing.Size(250, 19);
            this.chkAbgeschlosseneAusblenden.TabIndex = 34;
            // 
            // colSektion
            // 
            this.colSektion.Caption = "Sektion";
            this.colSektion.FieldName = "Sektion";
            this.colSektion.Name = "colSektion";
            this.colSektion.Visible = true;
            this.colSektion.VisibleIndex = 0;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 1;
            // 
            // colNameDT
            // 
            this.colNameDT.Caption = "Name DT";
            this.colNameDT.FieldName = "NameDT";
            this.colNameDT.Name = "colNameDT";
            this.colNameDT.Visible = true;
            this.colNameDT.VisibleIndex = 2;
            // 
            // colVornameDT
            // 
            this.colVornameDT.Caption = "Vorname DT";
            this.colVornameDT.FieldName = "VornameDT";
            this.colVornameDT.Name = "colVornameDT";
            this.colVornameDT.Visible = true;
            this.colVornameDT.VisibleIndex = 3;
            // 
            // colFallNr
            // 
            this.colFallNr.Caption = "Fall-Nr.";
            this.colFallNr.FieldName = "FallNr";
            this.colFallNr.Name = "colFallNr";
            this.colFallNr.Visible = true;
            this.colFallNr.VisibleIndex = 4;
            // 
            // colVersichertennummer
            // 
            this.colVersichertennummer.Caption = "Versichertennummer";
            this.colVersichertennummer.FieldName = "Versichertennummer";
            this.colVersichertennummer.Name = "colVersichertennummer";
            this.colVersichertennummer.Visible = true;
            this.colVersichertennummer.VisibleIndex = 5;
            // 
            // colZivilstand
            // 
            this.colZivilstand.Caption = "Zivilstand";
            this.colZivilstand.FieldName = "Zivilstand";
            this.colZivilstand.Name = "colZivilstand";
            this.colZivilstand.Visible = true;
            this.colZivilstand.VisibleIndex = 6;
            // 
            // colEntscheidDatum
            // 
            this.colEntscheidDatum.Caption = "Entscheid-Datum";
            this.colEntscheidDatum.FieldName = "EntscheidDatum";
            this.colEntscheidDatum.Name = "colEntscheidDatum";
            this.colEntscheidDatum.Visible = true;
            this.colEntscheidDatum.VisibleIndex = 7;
            // 
            // colZustaendigkeitBis
            // 
            this.colZustaendigkeitBis.Caption = "Zuständigkeit bis";
            this.colZustaendigkeitBis.FieldName = "ZustaendigkeitBis";
            this.colZustaendigkeitBis.Name = "colZustaendigkeitBis";
            this.colZustaendigkeitBis.Visible = true;
            this.colZustaendigkeitBis.VisibleIndex = 8;
            // 
            // colModul
            // 
            this.colModul.Caption = "Modul";
            this.colModul.FieldName = "ModulID";
            this.colModul.Name = "colModul";
            this.colModul.Visible = true;
            this.colModul.VisibleIndex = 9;
            // 
            // colModulEroeffnet
            // 
            this.colModulEroeffnet.Caption = "Modul Eröffnet (F)";
            this.colModulEroeffnet.FieldName = "ModulEroeffnet";
            this.colModulEroeffnet.Name = "colModulEroeffnet";
            this.colModulEroeffnet.Visible = true;
            this.colModulEroeffnet.VisibleIndex = 10;
            // 
            // colModulAbgeschlossen
            // 
            this.colModulAbgeschlossen.Caption = "Modul Abgeschlossen (F)";
            this.colModulAbgeschlossen.FieldName = "ModulAbgeschlossen";
            this.colModulAbgeschlossen.Name = "colModulAbgeschlossen";
            this.colModulAbgeschlossen.Visible = true;
            this.colModulAbgeschlossen.VisibleIndex = 11;
            // 
            // colSModulOffen
            // 
            this.colSModulOffen.Caption = "Ist ein S-Modul offen?";
            this.colSModulOffen.FieldName = "SModulOffen";
            this.colSModulOffen.Name = "colSModulOffen";
            this.colSModulOffen.Visible = true;
            this.colSModulOffen.VisibleIndex = 12;
            // 
            // colPhase
            // 
            this.colPhase.Caption = "Phase";
            this.colPhase.FieldName = "Phase";
            this.colPhase.Name = "colPhase";
            this.colPhase.Visible = true;
            this.colPhase.VisibleIndex = 13;
            // 
            // colPhaseEroeffnet
            // 
            this.colPhaseEroeffnet.Caption = "Phase Eröffnet";
            this.colPhaseEroeffnet.FieldName = "PhaseEroeffnet";
            this.colPhaseEroeffnet.Name = "colPhaseEroeffnet";
            this.colPhaseEroeffnet.Visible = true;
            this.colPhaseEroeffnet.VisibleIndex = 14;
            // 
            // colPhaseAbgeschlossen
            // 
            this.colPhaseAbgeschlossen.Caption = "Phase Abgeschlossen";
            this.colPhaseAbgeschlossen.FieldName = "PhaseAbgeschlossen";
            this.colPhaseAbgeschlossen.Name = "colPhaseAbgeschlossen";
            this.colPhaseAbgeschlossen.Visible = true;
            this.colPhaseAbgeschlossen.VisibleIndex = 15;
            // 
            // colVertragsdokument
            // 
            this.colVertragsdokument.Caption = "Vertragsdokument";
            this.colVertragsdokument.FieldName = "Vertragsdokument";
            this.colVertragsdokument.Name = "colVertragsdokument";
            this.colVertragsdokument.Visible = true;
            this.colVertragsdokument.VisibleIndex = 16;
            // 
            // colBeginnVertrag
            // 
            this.colBeginnVertrag.Caption = "Beginn Vertrag";
            this.colBeginnVertrag.FieldName = "BeginnVertrag";
            this.colBeginnVertrag.Name = "colBeginnVertrag";
            this.colBeginnVertrag.Visible = true;
            this.colBeginnVertrag.VisibleIndex = 17;
            // 
            // colAuswertungGeplant
            // 
            this.colAuswertungGeplant.Caption = "Auswertung geplant";
            this.colAuswertungGeplant.FieldName = "AuswertungGeplant";
            this.colAuswertungGeplant.Name = "colAuswertungGeplant";
            this.colAuswertungGeplant.Visible = true;
            this.colAuswertungGeplant.VisibleIndex = 18;
            // 
            // CtlQueryFaPhaseZusammenarbeitsvereinbarung
            // 

            this.Name = "CtlQueryFaPhaseZusammenarbeitsvereinbarung";
            this.Load += new System.EventHandler(this.CtlQueryFaPhaseZusammenarbeitsvereinbarung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAktiveF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFMitOffenemS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgeschlosseneAusblenden.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissCheckEdit chkNurAktiveF;
        private Gui.KissButtonEdit edtSAR;
        private Gui.KissLookUpEdit edtSektion;
        private Gui.KissLabel lblSAR;
        private Gui.KissLabel lblSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colNameDT;
        private DevExpress.XtraGrid.Columns.GridColumn colVornameDT;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colEntscheidDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZustaendigkeitBis;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colModulEroeffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colModulAbgeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colSModulOffen;
        private DevExpress.XtraGrid.Columns.GridColumn colPhase;
        private Gui.KissCheckEdit chkAbgeschlosseneAusblenden;
        private Gui.KissCheckEdit chkFMitOffenemS;
        private DevExpress.XtraGrid.Columns.GridColumn colPhaseEroeffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colPhaseAbgeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colVertragsdokument;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginnVertrag;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswertungGeplant;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
    }
}
