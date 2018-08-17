namespace KiSS4.Gesuchverwaltung
{
    partial class CtlGvBewilligung
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlGvBewilligung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdGvAuflagen = new KiSS4.Gui.KissGrid();
            this.qryGvAuflage = new KiSS4.DB.SqlQuery(this.components);
            this.grvGvAuflagen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErfasst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFonds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGegenstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchriftlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBereitsZurueckBezahlt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErledigt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpPruefung = new KiSS4.Gui.KissGroupBox();
            this.btnPruefungGesuchAblehnen = new KiSS4.Gui.KissButton();
            this.btnPruefungAbschlussAufheben = new KiSS4.Gui.KissButton();
            this.btnPruefungGesuchZurueckweisen = new KiSS4.Gui.KissButton();
            this.btnPruefungGesuchWeiterleitenCH = new KiSS4.Gui.KissButton();
            this.btnPruefungPruefungAbschliessen = new KiSS4.Gui.KissButton();
            this.grpPruefungCH = new KiSS4.Gui.KissGroupBox();
            this.btnPruefungCHGesuchAblehnen = new KiSS4.Gui.KissButton();
            this.btnPruefungCHAbschlussAufheben = new KiSS4.Gui.KissButton();
            this.btnPruefungCHGesuchZurueckweisen = new KiSS4.Gui.KissButton();
            this.btnPruefungCHAbschliessen = new KiSS4.Gui.KissButton();
            this.grpBewilligungVorschlagKGS = new KiSS4.Gui.KissGroupBox();
            this.btnBewilligungDokument = new KiSS4.Dokument.KissDocumentButton();
            this.edtBewilligungBetragBeantragt = new KiSS4.Gui.KissCalcEdit();
            this.edtBewilligungBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBewilligungBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBewilligungAm = new KiSS4.Gui.KissDateEdit();
            this.lblBewilligungAm = new KiSS4.Gui.KissLabel();
            this.lblBewilligungKuerzung = new KiSS4.Gui.KissLabel();
            this.edtBewilligungKuerzung = new KiSS4.Gui.KissCalcEdit();
            this.lblBewilligungBetragBewilligt = new KiSS4.Gui.KissLabel();
            this.edtBewilligungBetragBewilligt = new KiSS4.Gui.KissCalcEdit();
            this.lblBewilligungBetragBeantragt = new KiSS4.Gui.KissLabel();
            this.grpBewilligungCH = new KiSS4.Gui.KissGroupBox();
            this.btnBewilligungCHDokument = new KiSS4.Dokument.KissDocumentButton();
            this.edtBewilligungCHBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBewilligungCHBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBewilligungCHAm = new KiSS4.Gui.KissDateEdit();
            this.lblBewilligungCHAm = new KiSS4.Gui.KissLabel();
            this.lblBewilligungCHKuerzung = new KiSS4.Gui.KissLabel();
            this.edtBewilligungCHKuerzung = new KiSS4.Gui.KissCalcEdit();
            this.lblBewilligungCHBetragBewilligt = new KiSS4.Gui.KissLabel();
            this.edtBewilligungCHBetragBewilligt = new KiSS4.Gui.KissCalcEdit();
            this.lblBewilligungCHBetragBeantragt = new KiSS4.Gui.KissLabel();
            this.edtBewilligungCHBetragBeantragt = new KiSS4.Gui.KissCalcEdit();
            this.edtTotalBewilligt = new KiSS4.Gui.KissCalcEdit();
            this.lblTotalBewilligt = new KiSS4.Gui.KissLabel();
            this.chkKompetenzKanton = new KiSS4.Gui.KissCheckEdit();
            this.edtAusbezahltFLBTotal = new KiSS4.Gui.KissCalcEdit();
            this.lblAusbezahltFLBTotal = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGvAuflagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvAuflage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGvAuflagen)).BeginInit();
            this.grpPruefung.SuspendLayout();
            this.grpPruefungCH.SuspendLayout();
            this.grpBewilligungVorschlagKGS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBetragBeantragt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungKuerzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungKuerzung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBetragBewilligt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBetragBewilligt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBetragBeantragt)).BeginInit();
            this.grpBewilligungCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHKuerzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHKuerzung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHBetragBewilligt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHBetragBewilligt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHBetragBeantragt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHBetragBeantragt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalBewilligt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalBewilligt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKompetenzKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahltFLBTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahltFLBTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(2, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(175, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Unerledigte Auflagen";
            // 
            // grdGvAuflagen
            // 
            this.grdGvAuflagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGvAuflagen.DataSource = this.qryGvAuflage;
            // 
            // 
            // 
            this.grdGvAuflagen.EmbeddedNavigator.Name = "";
            this.grdGvAuflagen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGvAuflagen.Location = new System.Drawing.Point(3, 24);
            this.grdGvAuflagen.MainView = this.grvGvAuflagen;
            this.grdGvAuflagen.Name = "grdGvAuflagen";
            this.grdGvAuflagen.Size = new System.Drawing.Size(744, 183);
            this.grdGvAuflagen.TabIndex = 1;
            this.grdGvAuflagen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGvAuflagen});
            // 
            // qryGvAuflage
            // 
            this.qryGvAuflage.HostControl = this;
            this.qryGvAuflage.SelectStatement = resources.GetString("qryGvAuflage.SelectStatement");
            this.qryGvAuflage.TableName = "GvAuflage";
            // 
            // grvGvAuflagen
            // 
            this.grvGvAuflagen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGvAuflagen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.Empty.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.Empty.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.EvenRow.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGvAuflagen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGvAuflagen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGvAuflagen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGvAuflagen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGvAuflagen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGvAuflagen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGvAuflagen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGvAuflagen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGvAuflagen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGvAuflagen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.GroupRow.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGvAuflagen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGvAuflagen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGvAuflagen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGvAuflagen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGvAuflagen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGvAuflagen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGvAuflagen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGvAuflagen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGvAuflagen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.OddRow.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGvAuflagen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.Row.Options.UseBackColor = true;
            this.grvGvAuflagen.Appearance.Row.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvAuflagen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGvAuflagen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGvAuflagen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGvAuflagen.BestFitMaxRowCount = 1000;
            this.grvGvAuflagen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGvAuflagen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErfasst,
            this.colFonds,
            this.colTyp,
            this.colGegenstand,
            this.colSchriftlich,
            this.colBetrag,
            this.colBereitsZurueckBezahlt,
            this.colFrist,
            this.colErledigt,
            this.colBemerkung});
            this.grvGvAuflagen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGvAuflagen.GridControl = this.grdGvAuflagen;
            this.grvGvAuflagen.Name = "grvGvAuflagen";
            this.grvGvAuflagen.OptionsBehavior.Editable = false;
            this.grvGvAuflagen.OptionsCustomization.AllowFilter = false;
            this.grvGvAuflagen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGvAuflagen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGvAuflagen.OptionsNavigation.UseTabKey = false;
            this.grvGvAuflagen.OptionsView.ColumnAutoWidth = false;
            this.grvGvAuflagen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGvAuflagen.OptionsView.ShowGroupPanel = false;
            this.grvGvAuflagen.OptionsView.ShowIndicator = false;
            // 
            // colErfasst
            // 
            this.colErfasst.Caption = "Erfasst";
            this.colErfasst.Name = "colErfasst";
            this.colErfasst.Visible = true;
            this.colErfasst.VisibleIndex = 0;
            // 
            // colFonds
            // 
            this.colFonds.Caption = "Fonds";
            this.colFonds.Name = "colFonds";
            this.colFonds.Visible = true;
            this.colFonds.VisibleIndex = 1;
            this.colFonds.Width = 90;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 2;
            this.colTyp.Width = 50;
            // 
            // colGegenstand
            // 
            this.colGegenstand.Caption = "Gegenstand";
            this.colGegenstand.FieldName = "Bemerkungen";
            this.colGegenstand.Name = "colGegenstand";
            this.colGegenstand.Visible = true;
            this.colGegenstand.VisibleIndex = 3;
            this.colGegenstand.Width = 150;
            // 
            // colSchriftlich
            // 
            this.colSchriftlich.Caption = "Schriftl.";
            this.colSchriftlich.Name = "colSchriftlich";
            this.colSchriftlich.Visible = true;
            this.colSchriftlich.VisibleIndex = 4;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            // 
            // colBereitsZurueckBezahlt
            // 
            this.colBereitsZurueckBezahlt.Caption = "Bereits zurückbez.";
            this.colBereitsZurueckBezahlt.DisplayFormat.FormatString = "n2";
            this.colBereitsZurueckBezahlt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBereitsZurueckBezahlt.Name = "colBereitsZurueckBezahlt";
            this.colBereitsZurueckBezahlt.Visible = true;
            this.colBereitsZurueckBezahlt.VisibleIndex = 6;
            this.colBereitsZurueckBezahlt.Width = 120;
            // 
            // colFrist
            // 
            this.colFrist.Caption = "Frist bis";
            this.colFrist.Name = "colFrist";
            this.colFrist.Visible = true;
            this.colFrist.VisibleIndex = 7;
            // 
            // colErledigt
            // 
            this.colErledigt.Caption = "erledigt";
            this.colErledigt.Name = "colErledigt";
            this.colErledigt.Visible = true;
            this.colErledigt.VisibleIndex = 8;
            this.colErledigt.Width = 70;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 9;
            this.colBemerkung.Width = 150;
            // 
            // grpPruefung
            // 
            this.grpPruefung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPruefung.Controls.Add(this.btnPruefungGesuchAblehnen);
            this.grpPruefung.Controls.Add(this.btnPruefungAbschlussAufheben);
            this.grpPruefung.Controls.Add(this.btnPruefungGesuchZurueckweisen);
            this.grpPruefung.Controls.Add(this.btnPruefungGesuchWeiterleitenCH);
            this.grpPruefung.Controls.Add(this.btnPruefungPruefungAbschliessen);
            this.grpPruefung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpPruefung.Location = new System.Drawing.Point(548, 20);
            this.grpPruefung.Name = "grpPruefung";
            this.grpPruefung.Size = new System.Drawing.Size(190, 171);
            this.grpPruefung.TabIndex = 11;
            this.grpPruefung.TabStop = false;
            this.grpPruefung.Text = "Prüfung";
            // 
            // btnPruefungGesuchAblehnen
            // 
            this.btnPruefungGesuchAblehnen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungGesuchAblehnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungGesuchAblehnen.Location = new System.Drawing.Point(6, 50);
            this.btnPruefungGesuchAblehnen.Name = "btnPruefungGesuchAblehnen";
            this.btnPruefungGesuchAblehnen.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungGesuchAblehnen.TabIndex = 4;
            this.btnPruefungGesuchAblehnen.Text = "Gesuch ablehnen";
            this.btnPruefungGesuchAblehnen.UseVisualStyleBackColor = false;
            this.btnPruefungGesuchAblehnen.Click += new System.EventHandler(this.btnPruefungGesuchAblehnen_Click);
            // 
            // btnPruefungAbschlussAufheben
            // 
            this.btnPruefungAbschlussAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungAbschlussAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungAbschlussAufheben.Location = new System.Drawing.Point(6, 110);
            this.btnPruefungAbschlussAufheben.Name = "btnPruefungAbschlussAufheben";
            this.btnPruefungAbschlussAufheben.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungAbschlussAufheben.TabIndex = 2;
            this.btnPruefungAbschlussAufheben.Text = "Abschluss aufheben";
            this.btnPruefungAbschlussAufheben.UseVisualStyleBackColor = false;
            this.btnPruefungAbschlussAufheben.Click += new System.EventHandler(this.AbschlussAufheben_Click);
            // 
            // btnPruefungGesuchZurueckweisen
            // 
            this.btnPruefungGesuchZurueckweisen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungGesuchZurueckweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungGesuchZurueckweisen.Location = new System.Drawing.Point(6, 80);
            this.btnPruefungGesuchZurueckweisen.Name = "btnPruefungGesuchZurueckweisen";
            this.btnPruefungGesuchZurueckweisen.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungGesuchZurueckweisen.TabIndex = 1;
            this.btnPruefungGesuchZurueckweisen.Text = "Gesuch zurückweisen";
            this.btnPruefungGesuchZurueckweisen.UseVisualStyleBackColor = false;
            this.btnPruefungGesuchZurueckweisen.Click += new System.EventHandler(this.btnPruefungGesuchZurueckweisen_Click);
            // 
            // btnPruefungGesuchWeiterleitenCH
            // 
            this.btnPruefungGesuchWeiterleitenCH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungGesuchWeiterleitenCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungGesuchWeiterleitenCH.Location = new System.Drawing.Point(6, 140);
            this.btnPruefungGesuchWeiterleitenCH.Name = "btnPruefungGesuchWeiterleitenCH";
            this.btnPruefungGesuchWeiterleitenCH.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungGesuchWeiterleitenCH.TabIndex = 3;
            this.btnPruefungGesuchWeiterleitenCH.Text = "Gesuch weiterleiten CH";
            this.btnPruefungGesuchWeiterleitenCH.UseVisualStyleBackColor = false;
            this.btnPruefungGesuchWeiterleitenCH.Click += new System.EventHandler(this.btnPruefungGesuchWeiterleitenCH_Click);
            // 
            // btnPruefungPruefungAbschliessen
            // 
            this.btnPruefungPruefungAbschliessen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungPruefungAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungPruefungAbschliessen.Location = new System.Drawing.Point(6, 20);
            this.btnPruefungPruefungAbschliessen.Name = "btnPruefungPruefungAbschliessen";
            this.btnPruefungPruefungAbschliessen.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungPruefungAbschliessen.TabIndex = 0;
            this.btnPruefungPruefungAbschliessen.Text = "Prüfung abschliessen";
            this.btnPruefungPruefungAbschliessen.UseVisualStyleBackColor = false;
            this.btnPruefungPruefungAbschliessen.Click += new System.EventHandler(this.btnPruefungPruefungAbschliessen_Click);
            // 
            // grpPruefungCH
            // 
            this.grpPruefungCH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPruefungCH.Controls.Add(this.btnPruefungCHGesuchAblehnen);
            this.grpPruefungCH.Controls.Add(this.btnPruefungCHAbschlussAufheben);
            this.grpPruefungCH.Controls.Add(this.btnPruefungCHGesuchZurueckweisen);
            this.grpPruefungCH.Controls.Add(this.btnPruefungCHAbschliessen);
            this.grpPruefungCH.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpPruefungCH.Location = new System.Drawing.Point(548, 20);
            this.grpPruefungCH.Name = "grpPruefungCH";
            this.grpPruefungCH.Size = new System.Drawing.Size(190, 141);
            this.grpPruefungCH.TabIndex = 11;
            this.grpPruefungCH.TabStop = false;
            this.grpPruefungCH.Text = "Prüfung CH";
            // 
            // btnPruefungCHGesuchAblehnen
            // 
            this.btnPruefungCHGesuchAblehnen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungCHGesuchAblehnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungCHGesuchAblehnen.Location = new System.Drawing.Point(6, 50);
            this.btnPruefungCHGesuchAblehnen.Name = "btnPruefungCHGesuchAblehnen";
            this.btnPruefungCHGesuchAblehnen.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungCHGesuchAblehnen.TabIndex = 5;
            this.btnPruefungCHGesuchAblehnen.Text = "Gesuch ablehnen";
            this.btnPruefungCHGesuchAblehnen.UseVisualStyleBackColor = false;
            this.btnPruefungCHGesuchAblehnen.Click += new System.EventHandler(this.btnPruefungCHGesuchAblehnen_Click);
            // 
            // btnPruefungCHAbschlussAufheben
            // 
            this.btnPruefungCHAbschlussAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungCHAbschlussAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungCHAbschlussAufheben.Location = new System.Drawing.Point(6, 110);
            this.btnPruefungCHAbschlussAufheben.Name = "btnPruefungCHAbschlussAufheben";
            this.btnPruefungCHAbschlussAufheben.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungCHAbschlussAufheben.TabIndex = 2;
            this.btnPruefungCHAbschlussAufheben.Text = "Abschluss aufheben";
            this.btnPruefungCHAbschlussAufheben.UseVisualStyleBackColor = false;
            this.btnPruefungCHAbschlussAufheben.Click += new System.EventHandler(this.AbschlussAufheben_Click);
            // 
            // btnPruefungCHGesuchZurueckweisen
            // 
            this.btnPruefungCHGesuchZurueckweisen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungCHGesuchZurueckweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungCHGesuchZurueckweisen.Location = new System.Drawing.Point(6, 80);
            this.btnPruefungCHGesuchZurueckweisen.Name = "btnPruefungCHGesuchZurueckweisen";
            this.btnPruefungCHGesuchZurueckweisen.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungCHGesuchZurueckweisen.TabIndex = 1;
            this.btnPruefungCHGesuchZurueckweisen.Text = "Gesuch zurückweisen";
            this.btnPruefungCHGesuchZurueckweisen.UseVisualStyleBackColor = false;
            this.btnPruefungCHGesuchZurueckweisen.Click += new System.EventHandler(this.btnPruefungCHGesuchZurueckweisen_Click);
            // 
            // btnPruefungCHAbschliessen
            // 
            this.btnPruefungCHAbschliessen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruefungCHAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruefungCHAbschliessen.Location = new System.Drawing.Point(6, 20);
            this.btnPruefungCHAbschliessen.Name = "btnPruefungCHAbschliessen";
            this.btnPruefungCHAbschliessen.Size = new System.Drawing.Size(178, 24);
            this.btnPruefungCHAbschliessen.TabIndex = 0;
            this.btnPruefungCHAbschliessen.Text = "Prüfung CH abschliessen";
            this.btnPruefungCHAbschliessen.UseVisualStyleBackColor = false;
            this.btnPruefungCHAbschliessen.Click += new System.EventHandler(this.btnPruefungCHAbschliessen_Click);
            // 
            // grpBewilligungVorschlagKGS
            // 
            this.grpBewilligungVorschlagKGS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBewilligungVorschlagKGS.Controls.Add(this.btnBewilligungDokument);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.edtBewilligungBetragBeantragt);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.edtBewilligungBemerkung);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.lblBewilligungBemerkung);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.edtBewilligungAm);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.lblBewilligungAm);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.lblBewilligungKuerzung);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.edtBewilligungKuerzung);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.grpPruefung);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.lblBewilligungBetragBewilligt);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.edtBewilligungBetragBewilligt);
            this.grpBewilligungVorschlagKGS.Controls.Add(this.lblBewilligungBetragBeantragt);
            this.grpBewilligungVorschlagKGS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpBewilligungVorschlagKGS.Location = new System.Drawing.Point(3, 275);
            this.grpBewilligungVorschlagKGS.Name = "grpBewilligungVorschlagKGS";
            this.grpBewilligungVorschlagKGS.Size = new System.Drawing.Size(744, 208);
            this.grpBewilligungVorschlagKGS.TabIndex = 4;
            this.grpBewilligungVorschlagKGS.TabStop = false;
            this.grpBewilligungVorschlagKGS.Text = "Bewilligung / Vorschlag KGS";
            // 
            // btnBewilligungDokument
            // 
            this.btnBewilligungDokument.Context = "GV_Bewilligung_Kompetenzstufe1";
            this.btnBewilligungDokument.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnBewilligungDokument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBewilligungDokument.Image = ((System.Drawing.Image)(resources.GetObject("btnBewilligungDokument.Image")));
            this.btnBewilligungDokument.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBewilligungDokument.Location = new System.Drawing.Point(261, 80);
            this.btnBewilligungDokument.Name = "btnBewilligungDokument";
            this.btnBewilligungDokument.Size = new System.Drawing.Size(100, 24);
            this.btnBewilligungDokument.TabIndex = 8;
            this.btnBewilligungDokument.Text = "Dokument";
            this.btnBewilligungDokument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBewilligungDokument.UseVisualStyleBackColor = false;
            // 
            // edtBewilligungBetragBeantragt
            // 
            this.edtBewilligungBetragBeantragt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligungBetragBeantragt.Location = new System.Drawing.Point(131, 20);
            this.edtBewilligungBetragBeantragt.Name = "edtBewilligungBetragBeantragt";
            this.edtBewilligungBetragBeantragt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungBetragBeantragt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligungBetragBeantragt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungBetragBeantragt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungBetragBeantragt.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungBetragBeantragt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungBetragBeantragt.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungBetragBeantragt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungBetragBeantragt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungBetragBeantragt.Properties.DisplayFormat.FormatString = "n2";
            this.edtBewilligungBetragBeantragt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungBetragBeantragt.Properties.EditFormat.FormatString = "n2";
            this.edtBewilligungBetragBeantragt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungBetragBeantragt.Properties.Mask.EditMask = "n2";
            this.edtBewilligungBetragBeantragt.Properties.ReadOnly = true;
            this.edtBewilligungBetragBeantragt.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungBetragBeantragt.TabIndex = 1;
            // 
            // edtBewilligungBemerkung
            // 
            this.edtBewilligungBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBewilligungBemerkung.EditValue = "";
            this.edtBewilligungBemerkung.Location = new System.Drawing.Point(131, 110);
            this.edtBewilligungBemerkung.Name = "edtBewilligungBemerkung";
            this.edtBewilligungBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBewilligungBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungBemerkung.Size = new System.Drawing.Size(396, 90);
            this.edtBewilligungBemerkung.TabIndex = 10;
            // 
            // lblBewilligungBemerkung
            // 
            this.lblBewilligungBemerkung.Location = new System.Drawing.Point(6, 109);
            this.lblBewilligungBemerkung.Name = "lblBewilligungBemerkung";
            this.lblBewilligungBemerkung.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungBemerkung.TabIndex = 9;
            this.lblBewilligungBemerkung.Text = "Bemerkung";
            // 
            // edtBewilligungAm
            // 
            this.edtBewilligungAm.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBewilligungAm.EditValue = null;
            this.edtBewilligungAm.Location = new System.Drawing.Point(261, 50);
            this.edtBewilligungAm.Name = "edtBewilligungAm";
            this.edtBewilligungAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungAm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBewilligungAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungAm.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBewilligungAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBewilligungAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBewilligungAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungAm.Properties.ShowToday = false;
            this.edtBewilligungAm.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungAm.TabIndex = 5;
            // 
            // lblBewilligungAm
            // 
            this.lblBewilligungAm.Location = new System.Drawing.Point(237, 50);
            this.lblBewilligungAm.Name = "lblBewilligungAm";
            this.lblBewilligungAm.Size = new System.Drawing.Size(43, 24);
            this.lblBewilligungAm.TabIndex = 4;
            this.lblBewilligungAm.Text = "am";
            // 
            // lblBewilligungKuerzung
            // 
            this.lblBewilligungKuerzung.Location = new System.Drawing.Point(6, 80);
            this.lblBewilligungKuerzung.Name = "lblBewilligungKuerzung";
            this.lblBewilligungKuerzung.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungKuerzung.TabIndex = 6;
            this.lblBewilligungKuerzung.Text = "Kürzung";
            // 
            // edtBewilligungKuerzung
            // 
            this.edtBewilligungKuerzung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligungKuerzung.Location = new System.Drawing.Point(131, 80);
            this.edtBewilligungKuerzung.Name = "edtBewilligungKuerzung";
            this.edtBewilligungKuerzung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungKuerzung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligungKuerzung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungKuerzung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungKuerzung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungKuerzung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungKuerzung.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungKuerzung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungKuerzung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungKuerzung.Properties.DisplayFormat.FormatString = "n2";
            this.edtBewilligungKuerzung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungKuerzung.Properties.EditFormat.FormatString = "n2";
            this.edtBewilligungKuerzung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungKuerzung.Properties.Mask.EditMask = "n2";
            this.edtBewilligungKuerzung.Properties.ReadOnly = true;
            this.edtBewilligungKuerzung.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungKuerzung.TabIndex = 7;
            // 
            // lblBewilligungBetragBewilligt
            // 
            this.lblBewilligungBetragBewilligt.Location = new System.Drawing.Point(6, 50);
            this.lblBewilligungBetragBewilligt.Name = "lblBewilligungBetragBewilligt";
            this.lblBewilligungBetragBewilligt.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungBetragBewilligt.TabIndex = 2;
            this.lblBewilligungBetragBewilligt.Text = "Betrag bewilligt";
            // 
            // edtBewilligungBetragBewilligt
            // 
            this.edtBewilligungBetragBewilligt.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBewilligungBetragBewilligt.Location = new System.Drawing.Point(131, 50);
            this.edtBewilligungBetragBewilligt.Name = "edtBewilligungBetragBewilligt";
            this.edtBewilligungBetragBewilligt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungBetragBewilligt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBewilligungBetragBewilligt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungBetragBewilligt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungBetragBewilligt.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungBetragBewilligt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungBetragBewilligt.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungBetragBewilligt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungBetragBewilligt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungBetragBewilligt.Properties.DisplayFormat.FormatString = "n2";
            this.edtBewilligungBetragBewilligt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungBetragBewilligt.Properties.EditFormat.FormatString = "n2";
            this.edtBewilligungBetragBewilligt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungBetragBewilligt.Properties.Mask.EditMask = "n2";
            this.edtBewilligungBetragBewilligt.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungBetragBewilligt.TabIndex = 3;
            this.edtBewilligungBetragBewilligt.EditValueChanged += new System.EventHandler(this.edtBewilligungBetragBewilligt_EditValueChanged);
            // 
            // lblBewilligungBetragBeantragt
            // 
            this.lblBewilligungBetragBeantragt.Location = new System.Drawing.Point(6, 20);
            this.lblBewilligungBetragBeantragt.Name = "lblBewilligungBetragBeantragt";
            this.lblBewilligungBetragBeantragt.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungBetragBeantragt.TabIndex = 0;
            this.lblBewilligungBetragBeantragt.Text = "Betrag beantragt";
            // 
            // grpBewilligungCH
            // 
            this.grpBewilligungCH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBewilligungCH.Controls.Add(this.btnBewilligungCHDokument);
            this.grpBewilligungCH.Controls.Add(this.edtBewilligungCHBemerkung);
            this.grpBewilligungCH.Controls.Add(this.lblBewilligungCHBemerkung);
            this.grpBewilligungCH.Controls.Add(this.grpPruefungCH);
            this.grpBewilligungCH.Controls.Add(this.edtBewilligungCHAm);
            this.grpBewilligungCH.Controls.Add(this.lblBewilligungCHAm);
            this.grpBewilligungCH.Controls.Add(this.lblBewilligungCHKuerzung);
            this.grpBewilligungCH.Controls.Add(this.edtBewilligungCHKuerzung);
            this.grpBewilligungCH.Controls.Add(this.lblBewilligungCHBetragBewilligt);
            this.grpBewilligungCH.Controls.Add(this.edtBewilligungCHBetragBewilligt);
            this.grpBewilligungCH.Controls.Add(this.lblBewilligungCHBetragBeantragt);
            this.grpBewilligungCH.Controls.Add(this.edtBewilligungCHBetragBeantragt);
            this.grpBewilligungCH.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpBewilligungCH.Location = new System.Drawing.Point(3, 489);
            this.grpBewilligungCH.Name = "grpBewilligungCH";
            this.grpBewilligungCH.Size = new System.Drawing.Size(744, 208);
            this.grpBewilligungCH.TabIndex = 5;
            this.grpBewilligungCH.TabStop = false;
            this.grpBewilligungCH.Text = "Bewilligung CH";
            // 
            // btnBewilligungCHDokument
            // 
            this.btnBewilligungCHDokument.Context = "GV_Bewilligung_Kompetenzstufe2";
            this.btnBewilligungCHDokument.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnBewilligungCHDokument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBewilligungCHDokument.Image = ((System.Drawing.Image)(resources.GetObject("btnBewilligungCHDokument.Image")));
            this.btnBewilligungCHDokument.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBewilligungCHDokument.Location = new System.Drawing.Point(261, 80);
            this.btnBewilligungCHDokument.Name = "btnBewilligungCHDokument";
            this.btnBewilligungCHDokument.Size = new System.Drawing.Size(100, 24);
            this.btnBewilligungCHDokument.TabIndex = 8;
            this.btnBewilligungCHDokument.Text = "Dokument";
            this.btnBewilligungCHDokument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBewilligungCHDokument.UseVisualStyleBackColor = false;
            // 
            // edtBewilligungCHBemerkung
            // 
            this.edtBewilligungCHBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBewilligungCHBemerkung.EditValue = "";
            this.edtBewilligungCHBemerkung.Location = new System.Drawing.Point(131, 110);
            this.edtBewilligungCHBemerkung.Name = "edtBewilligungCHBemerkung";
            this.edtBewilligungCHBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBewilligungCHBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungCHBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungCHBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungCHBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungCHBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungCHBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungCHBemerkung.Size = new System.Drawing.Size(396, 90);
            this.edtBewilligungCHBemerkung.TabIndex = 10;
            // 
            // lblBewilligungCHBemerkung
            // 
            this.lblBewilligungCHBemerkung.Location = new System.Drawing.Point(6, 110);
            this.lblBewilligungCHBemerkung.Name = "lblBewilligungCHBemerkung";
            this.lblBewilligungCHBemerkung.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungCHBemerkung.TabIndex = 9;
            this.lblBewilligungCHBemerkung.Text = "Bemerkung";
            // 
            // edtBewilligungCHAm
            // 
            this.edtBewilligungCHAm.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBewilligungCHAm.EditValue = null;
            this.edtBewilligungCHAm.Location = new System.Drawing.Point(261, 50);
            this.edtBewilligungCHAm.Name = "edtBewilligungCHAm";
            this.edtBewilligungCHAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungCHAm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBewilligungCHAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungCHAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungCHAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungCHAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungCHAm.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungCHAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBewilligungCHAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBewilligungCHAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBewilligungCHAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungCHAm.Properties.ShowToday = false;
            this.edtBewilligungCHAm.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungCHAm.TabIndex = 5;
            // 
            // lblBewilligungCHAm
            // 
            this.lblBewilligungCHAm.Location = new System.Drawing.Point(237, 51);
            this.lblBewilligungCHAm.Name = "lblBewilligungCHAm";
            this.lblBewilligungCHAm.Size = new System.Drawing.Size(43, 24);
            this.lblBewilligungCHAm.TabIndex = 4;
            this.lblBewilligungCHAm.Text = "am";
            // 
            // lblBewilligungCHKuerzung
            // 
            this.lblBewilligungCHKuerzung.Location = new System.Drawing.Point(6, 81);
            this.lblBewilligungCHKuerzung.Name = "lblBewilligungCHKuerzung";
            this.lblBewilligungCHKuerzung.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungCHKuerzung.TabIndex = 6;
            this.lblBewilligungCHKuerzung.Text = "Kürzung";
            // 
            // edtBewilligungCHKuerzung
            // 
            this.edtBewilligungCHKuerzung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligungCHKuerzung.Location = new System.Drawing.Point(131, 80);
            this.edtBewilligungCHKuerzung.Name = "edtBewilligungCHKuerzung";
            this.edtBewilligungCHKuerzung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungCHKuerzung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligungCHKuerzung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungCHKuerzung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungCHKuerzung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungCHKuerzung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungCHKuerzung.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungCHKuerzung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungCHKuerzung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungCHKuerzung.Properties.DisplayFormat.FormatString = "n2";
            this.edtBewilligungCHKuerzung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungCHKuerzung.Properties.EditFormat.FormatString = "n2";
            this.edtBewilligungCHKuerzung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungCHKuerzung.Properties.Mask.EditMask = "n2";
            this.edtBewilligungCHKuerzung.Properties.ReadOnly = true;
            this.edtBewilligungCHKuerzung.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungCHKuerzung.TabIndex = 7;
            // 
            // lblBewilligungCHBetragBewilligt
            // 
            this.lblBewilligungCHBetragBewilligt.Location = new System.Drawing.Point(6, 51);
            this.lblBewilligungCHBetragBewilligt.Name = "lblBewilligungCHBetragBewilligt";
            this.lblBewilligungCHBetragBewilligt.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungCHBetragBewilligt.TabIndex = 2;
            this.lblBewilligungCHBetragBewilligt.Text = "Betrag bewilligt";
            // 
            // edtBewilligungCHBetragBewilligt
            // 
            this.edtBewilligungCHBetragBewilligt.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBewilligungCHBetragBewilligt.Location = new System.Drawing.Point(131, 50);
            this.edtBewilligungCHBetragBewilligt.Name = "edtBewilligungCHBetragBewilligt";
            this.edtBewilligungCHBetragBewilligt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungCHBetragBewilligt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBewilligungCHBetragBewilligt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungCHBetragBewilligt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungCHBetragBewilligt.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungCHBetragBewilligt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungCHBetragBewilligt.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungCHBetragBewilligt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungCHBetragBewilligt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungCHBetragBewilligt.Properties.DisplayFormat.FormatString = "n2";
            this.edtBewilligungCHBetragBewilligt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungCHBetragBewilligt.Properties.EditFormat.FormatString = "n2";
            this.edtBewilligungCHBetragBewilligt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungCHBetragBewilligt.Properties.Mask.EditMask = "n2";
            this.edtBewilligungCHBetragBewilligt.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungCHBetragBewilligt.TabIndex = 3;
            this.edtBewilligungCHBetragBewilligt.EditValueChanged += new System.EventHandler(this.edtBewilligungCHBetragBewilligt_EditValueChanged);
            // 
            // lblBewilligungCHBetragBeantragt
            // 
            this.lblBewilligungCHBetragBeantragt.Location = new System.Drawing.Point(6, 21);
            this.lblBewilligungCHBetragBeantragt.Name = "lblBewilligungCHBetragBeantragt";
            this.lblBewilligungCHBetragBeantragt.Size = new System.Drawing.Size(100, 23);
            this.lblBewilligungCHBetragBeantragt.TabIndex = 0;
            this.lblBewilligungCHBetragBeantragt.Text = "Betrag beantragt";
            // 
            // edtBewilligungCHBetragBeantragt
            // 
            this.edtBewilligungCHBetragBeantragt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligungCHBetragBeantragt.Location = new System.Drawing.Point(131, 20);
            this.edtBewilligungCHBetragBeantragt.Name = "edtBewilligungCHBetragBeantragt";
            this.edtBewilligungCHBetragBeantragt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligungCHBetragBeantragt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligungCHBetragBeantragt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungCHBetragBeantragt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungCHBetragBeantragt.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungCHBetragBeantragt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungCHBetragBeantragt.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungCHBetragBeantragt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungCHBetragBeantragt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligungCHBetragBeantragt.Properties.DisplayFormat.FormatString = "n2";
            this.edtBewilligungCHBetragBeantragt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungCHBetragBeantragt.Properties.EditFormat.FormatString = "n2";
            this.edtBewilligungCHBetragBeantragt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBewilligungCHBetragBeantragt.Properties.Mask.EditMask = "n2";
            this.edtBewilligungCHBetragBeantragt.Properties.ReadOnly = true;
            this.edtBewilligungCHBetragBeantragt.Size = new System.Drawing.Size(100, 24);
            this.edtBewilligungCHBetragBeantragt.TabIndex = 1;
            // 
            // edtTotalBewilligt
            // 
            this.edtTotalBewilligt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTotalBewilligt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotalBewilligt.Location = new System.Drawing.Point(647, 213);
            this.edtTotalBewilligt.Name = "edtTotalBewilligt";
            this.edtTotalBewilligt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotalBewilligt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotalBewilligt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotalBewilligt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotalBewilligt.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotalBewilligt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotalBewilligt.Properties.Appearance.Options.UseFont = true;
            this.edtTotalBewilligt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotalBewilligt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotalBewilligt.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotalBewilligt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalBewilligt.Properties.EditFormat.FormatString = "n2";
            this.edtTotalBewilligt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalBewilligt.Properties.ReadOnly = true;
            this.edtTotalBewilligt.Size = new System.Drawing.Size(100, 24);
            this.edtTotalBewilligt.TabIndex = 3;
            // 
            // lblTotalBewilligt
            // 
            this.lblTotalBewilligt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalBewilligt.Location = new System.Drawing.Point(266, 213);
            this.lblTotalBewilligt.Name = "lblTotalBewilligt";
            this.lblTotalBewilligt.Size = new System.Drawing.Size(375, 24);
            this.lblTotalBewilligt.TabIndex = 2;
            this.lblTotalBewilligt.Text = "Diesem Klienten total bewilligt aus FLB-Fonds aktuelles Jahr";
            this.lblTotalBewilligt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkKompetenzKanton
            // 
            this.chkKompetenzKanton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKompetenzKanton.EditValue = false;
            this.chkKompetenzKanton.Location = new System.Drawing.Point(12, 217);
            this.chkKompetenzKanton.Name = "chkKompetenzKanton";
            this.chkKompetenzKanton.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkKompetenzKanton.Properties.Appearance.Options.UseBackColor = true;
            this.chkKompetenzKanton.Properties.Caption = "Kompetenz Kant. FLB-Ko/KK";
            this.chkKompetenzKanton.Size = new System.Drawing.Size(165, 19);
            this.chkKompetenzKanton.TabIndex = 6;
            // 
            // edtAusbezahltFLBTotal
            // 
            this.edtAusbezahltFLBTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAusbezahltFLBTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAusbezahltFLBTotal.Location = new System.Drawing.Point(647, 243);
            this.edtAusbezahltFLBTotal.Name = "edtAusbezahltFLBTotal";
            this.edtAusbezahltFLBTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAusbezahltFLBTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAusbezahltFLBTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbezahltFLBTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbezahltFLBTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbezahltFLBTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbezahltFLBTotal.Properties.Appearance.Options.UseFont = true;
            this.edtAusbezahltFLBTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusbezahltFLBTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbezahltFLBTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtAusbezahltFLBTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAusbezahltFLBTotal.Properties.EditFormat.FormatString = "n2";
            this.edtAusbezahltFLBTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAusbezahltFLBTotal.Properties.ReadOnly = true;
            this.edtAusbezahltFLBTotal.Size = new System.Drawing.Size(100, 24);
            this.edtAusbezahltFLBTotal.TabIndex = 7;
            // 
            // lblAusbezahltFLBTotal
            // 
            this.lblAusbezahltFLBTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAusbezahltFLBTotal.Location = new System.Drawing.Point(266, 243);
            this.lblAusbezahltFLBTotal.Name = "lblAusbezahltFLBTotal";
            this.lblAusbezahltFLBTotal.Size = new System.Drawing.Size(375, 24);
            this.lblAusbezahltFLBTotal.TabIndex = 8;
            this.lblAusbezahltFLBTotal.Text = "Total an Klienten ausbezahlt aus FLB-Fonds aktuelles Jahr";
            this.lblAusbezahltFLBTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CtlGvBewilligung
            // 
            this.ActiveSQLQuery = this.qryGvAuflage;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(584, 600);
            this.Controls.Add(this.lblAusbezahltFLBTotal);
            this.Controls.Add(this.edtAusbezahltFLBTotal);
            this.Controls.Add(this.chkKompetenzKanton);
            this.Controls.Add(this.edtTotalBewilligt);
            this.Controls.Add(this.lblTotalBewilligt);
            this.Controls.Add(this.grpBewilligungCH);
            this.Controls.Add(this.grpBewilligungVorschlagKGS);
            this.Controls.Add(this.grdGvAuflagen);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlGvBewilligung";
            this.Size = new System.Drawing.Size(750, 700);
            this.Load += new System.EventHandler(this.CtlGvBewilligung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGvAuflagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvAuflage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGvAuflagen)).EndInit();
            this.grpPruefung.ResumeLayout(false);
            this.grpPruefungCH.ResumeLayout(false);
            this.grpBewilligungVorschlagKGS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBetragBeantragt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungKuerzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungKuerzung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBetragBewilligt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBetragBewilligt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBetragBeantragt)).EndInit();
            this.grpBewilligungCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHKuerzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHKuerzung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHBetragBewilligt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHBetragBewilligt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungCHBetragBeantragt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungCHBetragBeantragt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalBewilligt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalBewilligt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKompetenzKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahltFLBTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahltFLBTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissLabel lblTitel;
        private Gui.KissGrid grdGvAuflagen;
        private DB.SqlQuery qryGvAuflage;
        private Gui.KissGroupBox grpPruefungCH;
        private Gui.KissButton btnPruefungCHAbschlussAufheben;
        private Gui.KissButton btnPruefungCHGesuchZurueckweisen;
        private Gui.KissButton btnPruefungCHAbschliessen;
        private Gui.KissGroupBox grpPruefung;
        private Gui.KissButton btnPruefungGesuchWeiterleitenCH;
        private Gui.KissButton btnPruefungPruefungAbschliessen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGvAuflagen;
        private DevExpress.XtraGrid.Columns.GridColumn colErfasst;
        private DevExpress.XtraGrid.Columns.GridColumn colFonds;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colGegenstand;
        private DevExpress.XtraGrid.Columns.GridColumn colSchriftlich;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBereitsZurueckBezahlt;
        private DevExpress.XtraGrid.Columns.GridColumn colFrist;
        private DevExpress.XtraGrid.Columns.GridColumn colErledigt;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private Gui.KissButton btnPruefungAbschlussAufheben;
        private Gui.KissButton btnPruefungGesuchZurueckweisen;
        private Gui.KissGroupBox grpBewilligungVorschlagKGS;
        private Gui.KissLabel lblBewilligungBetragBewilligt;
        private Gui.KissCalcEdit edtBewilligungBetragBewilligt;
        private Gui.KissLabel lblBewilligungBetragBeantragt;
        private Gui.KissMemoEdit edtBewilligungBemerkung;
        private Gui.KissLabel lblBewilligungBemerkung;
        private Gui.KissDateEdit edtBewilligungAm;
        private Gui.KissLabel lblBewilligungAm;
        private Gui.KissLabel lblBewilligungKuerzung;
        private Gui.KissCalcEdit edtBewilligungKuerzung;
        private Gui.KissGroupBox grpBewilligungCH;
        private Gui.KissMemoEdit edtBewilligungCHBemerkung;
        private Gui.KissLabel lblBewilligungCHBemerkung;
        private Gui.KissDateEdit edtBewilligungCHAm;
        private Gui.KissLabel lblBewilligungCHAm;
        private Gui.KissLabel lblBewilligungCHKuerzung;
        private Gui.KissCalcEdit edtBewilligungCHKuerzung;
        private Gui.KissLabel lblBewilligungCHBetragBewilligt;
        private Gui.KissCalcEdit edtBewilligungCHBetragBewilligt;
        private Gui.KissLabel lblBewilligungCHBetragBeantragt;
        private Gui.KissCalcEdit edtBewilligungCHBetragBeantragt;
        private Gui.KissCalcEdit edtBewilligungBetragBeantragt;
        private Gui.KissCalcEdit edtTotalBewilligt;
        private Gui.KissLabel lblTotalBewilligt;
        private Dokument.KissDocumentButton btnBewilligungDokument;
        private Dokument.KissDocumentButton btnBewilligungCHDokument;
        private Gui.KissCheckEdit chkKompetenzKanton;
        private Gui.KissButton btnPruefungGesuchAblehnen;
        private Gui.KissButton btnPruefungCHGesuchAblehnen;
        private Gui.KissLabel lblAusbezahltFLBTotal;
        private Gui.KissCalcEdit edtAusbezahltFLBTotal;
    }
}
