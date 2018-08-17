namespace KiSS4.Gesuchverwaltung
{
    partial class CtlGvGesuch
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlGvGesuch));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblFondsHinweis = new KiSS4.Gui.KissLabel();
            this.lblGesuchTotal = new KiSS4.Gui.KissLabel();
            this.edtGesuchTotal = new KiSS4.Gui.KissCalcEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.lblFonds = new KiSS4.Gui.KissLabel();
            this.edtFonds = new KiSS4.Gui.KissLookUpEdit();
            this.btnDatenimport = new KiSS4.Gui.KissButton();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtDokument = new KiSS4.Dokument.XDokument();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.ofdExcelImport = new System.Windows.Forms.OpenFileDialog();
            this.edtGesuchsgrund = new KiSS4.Gui.KissTextEdit();
            this.lblGesuchsgrund = new KiSS4.Gui.KissLabel();
            this.btnGesuchDuplizieren = new KiSS4.Gui.KissButton();
            this.btnGesuchAbschliessen = new KiSS4.Gui.KissButton();
            this.chkExtern = new KiSS4.Gui.KissCheckEdit();
            this.lblAusbezahltFLBTotal = new KiSS4.Gui.KissLabel();
            this.edtAusbezahltFLBTotal = new KiSS4.Gui.KissCalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFondsHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesuchTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesuchTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFonds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesuchsgrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesuchsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExtern.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahltFLBTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahltFLBTotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtKlient
            // 
            this.edtKlient.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlient.Location = new System.Drawing.Point(114, 8);
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlient.Properties.ReadOnly = true;
            this.edtKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKlient.Size = new System.Drawing.Size(200, 24);
            this.edtKlient.TabIndex = 1;
            this.edtKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKlient_UserModifiedFld);
            // 
            // lblFondsHinweis
            // 
            this.lblFondsHinweis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFondsHinweis.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFondsHinweis.ForeColor = System.Drawing.Color.Red;
            this.lblFondsHinweis.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblFondsHinweis.Location = new System.Drawing.Point(506, 74);
            this.lblFondsHinweis.Name = "lblFondsHinweis";
            this.lblFondsHinweis.Size = new System.Drawing.Size(415, 79);
            this.lblFondsHinweis.TabIndex = 6;
            this.lblFondsHinweis.Text = "[FondHinweis]";
            // 
            // lblGesuchTotal
            // 
            this.lblGesuchTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGesuchTotal.Location = new System.Drawing.Point(353, 8);
            this.lblGesuchTotal.Name = "lblGesuchTotal";
            this.lblGesuchTotal.Size = new System.Drawing.Size(437, 24);
            this.lblGesuchTotal.TabIndex = 13;
            this.lblGesuchTotal.Text = "Diesem Klienten total bewilligt aus FLB-Fonds aktuelles Jahr";
            this.lblGesuchTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // edtGesuchTotal
            // 
            this.edtGesuchTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGesuchTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGesuchTotal.Location = new System.Drawing.Point(796, 8);
            this.edtGesuchTotal.Name = "edtGesuchTotal";
            this.edtGesuchTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGesuchTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGesuchTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGesuchTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesuchTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesuchTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGesuchTotal.Properties.Appearance.Options.UseFont = true;
            this.edtGesuchTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGesuchTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGesuchTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtGesuchTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGesuchTotal.Properties.EditFormat.FormatString = "n2";
            this.edtGesuchTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGesuchTotal.Properties.Mask.EditMask = "n2";
            this.edtGesuchTotal.Properties.ReadOnly = true;
            this.edtGesuchTotal.Size = new System.Drawing.Size(125, 24);
            this.edtGesuchTotal.TabIndex = 14;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(3, 8);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(105, 24);
            this.lblKlient.TabIndex = 0;
            this.lblKlient.Text = "Klient";
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(3, 38);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(105, 24);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum";
            // 
            // edtDatum
            // 
            this.edtDatum.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(114, 38);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDatum.TabIndex = 3;
            this.edtDatum.EditValueChanged += new System.EventHandler(this.edtDatum_EditValueChanged);
            // 
            // lblFonds
            // 
            this.lblFonds.Location = new System.Drawing.Point(3, 68);
            this.lblFonds.Name = "lblFonds";
            this.lblFonds.Size = new System.Drawing.Size(105, 24);
            this.lblFonds.TabIndex = 4;
            this.lblFonds.Text = "Fonds";
            // 
            // edtFonds
            // 
            this.edtFonds.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtFonds.Location = new System.Drawing.Point(114, 68);
            this.edtFonds.Name = "edtFonds";
            this.edtFonds.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtFonds.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFonds.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFonds.Properties.Appearance.Options.UseBackColor = true;
            this.edtFonds.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFonds.Properties.Appearance.Options.UseFont = true;
            this.edtFonds.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFonds.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFonds.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFonds.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFonds.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFonds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFonds.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFonds.Properties.NullText = "";
            this.edtFonds.Properties.ShowFooter = false;
            this.edtFonds.Properties.ShowHeader = false;
            this.edtFonds.Size = new System.Drawing.Size(386, 24);
            this.edtFonds.TabIndex = 5;
            this.edtFonds.EditValueChanged += new System.EventHandler(this.edtFonds_EditValueChanged);
            // 
            // btnDatenimport
            // 
            this.btnDatenimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatenimport.Enabled = false;
            this.btnDatenimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenimport.Location = new System.Drawing.Point(738, 257);
            this.btnDatenimport.Name = "btnDatenimport";
            this.btnDatenimport.Size = new System.Drawing.Size(194, 24);
            this.btnDatenimport.TabIndex = 15;
            this.btnDatenimport.Text = "Datenimport neues Gesuch";
            this.btnDatenimport.UseVisualStyleBackColor = false;
            this.btnDatenimport.Click += new System.EventHandler(this.btnDatenimport_Click);
            // 
            // lblDokument
            // 
            this.lblDokument.Location = new System.Drawing.Point(3, 99);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(105, 24);
            this.lblDokument.TabIndex = 7;
            this.lblDokument.Text = "Dokument";
            // 
            // edtDokument
            // 
            this.edtDokument.Context = null;
            this.edtDokument.EditValue = "";
            this.edtDokument.Location = new System.Drawing.Point(114, 99);
            this.edtDokument.Name = "edtDokument";
            this.edtDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokument.Properties.Appearance.Options.UseFont = true;
            this.edtDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument importieren")});
            this.edtDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokument.Properties.ReadOnly = true;
            this.edtDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokument.Size = new System.Drawing.Size(125, 24);
            this.edtDokument.TabIndex = 8;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(3, 159);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(105, 24);
            this.lblBemerkung.TabIndex = 11;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.Location = new System.Drawing.Point(114, 159);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(576, 122);
            this.edtBemerkung.TabIndex = 12;
            // 
            // ofdExcelImport
            // 
            this.ofdExcelImport.Filter = "Excel files|*.xlsx|All files|*.*";
            // 
            // edtGesuchsgrund
            // 
            this.edtGesuchsgrund.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtGesuchsgrund.Location = new System.Drawing.Point(114, 129);
            this.edtGesuchsgrund.Name = "edtGesuchsgrund";
            this.edtGesuchsgrund.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtGesuchsgrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGesuchsgrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesuchsgrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesuchsgrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGesuchsgrund.Properties.Appearance.Options.UseFont = true;
            this.edtGesuchsgrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGesuchsgrund.Size = new System.Drawing.Size(386, 24);
            this.edtGesuchsgrund.TabIndex = 10;
            // 
            // lblGesuchsgrund
            // 
            this.lblGesuchsgrund.Location = new System.Drawing.Point(3, 129);
            this.lblGesuchsgrund.Name = "lblGesuchsgrund";
            this.lblGesuchsgrund.Size = new System.Drawing.Size(105, 24);
            this.lblGesuchsgrund.TabIndex = 9;
            this.lblGesuchsgrund.Text = "Gesuchsgrund";
            // 
            // btnGesuchDuplizieren
            // 
            this.btnGesuchDuplizieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGesuchDuplizieren.Enabled = false;
            this.btnGesuchDuplizieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGesuchDuplizieren.Location = new System.Drawing.Point(738, 227);
            this.btnGesuchDuplizieren.Name = "btnGesuchDuplizieren";
            this.btnGesuchDuplizieren.Size = new System.Drawing.Size(194, 24);
            this.btnGesuchDuplizieren.TabIndex = 15;
            this.btnGesuchDuplizieren.Text = "Gesuch duplizieren";
            this.btnGesuchDuplizieren.UseVisualStyleBackColor = false;
            this.btnGesuchDuplizieren.Click += new System.EventHandler(this.btnGesuchDuplizieren_Click);
            // 
            // btnGesuchAbschliessen
            // 
            this.btnGesuchAbschliessen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGesuchAbschliessen.Enabled = false;
            this.btnGesuchAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGesuchAbschliessen.Location = new System.Drawing.Point(738, 197);
            this.btnGesuchAbschliessen.Name = "btnGesuchAbschliessen";
            this.btnGesuchAbschliessen.Size = new System.Drawing.Size(194, 24);
            this.btnGesuchAbschliessen.TabIndex = 15;
            this.btnGesuchAbschliessen.Text = "Gesuch abschliessen";
            this.btnGesuchAbschliessen.UseVisualStyleBackColor = false;
            this.btnGesuchAbschliessen.Click += new System.EventHandler(this.btnGesuchAbschliessen_Click);
            // 
            // chkExtern
            // 
            this.chkExtern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExtern.EditValue = false;
            this.chkExtern.Location = new System.Drawing.Point(738, 172);
            this.chkExtern.Name = "chkExtern";
            this.chkExtern.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkExtern.Properties.Appearance.Options.UseBackColor = true;
            this.chkExtern.Properties.Caption = "Extern";
            this.chkExtern.Size = new System.Drawing.Size(184, 19);
            this.chkExtern.TabIndex = 16;
            // 
            // lblAusbezahltFLBTotal
            // 
            this.lblAusbezahltFLBTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAusbezahltFLBTotal.Location = new System.Drawing.Point(356, 38);
            this.lblAusbezahltFLBTotal.Name = "lblAusbezahltFLBTotal";
            this.lblAusbezahltFLBTotal.Size = new System.Drawing.Size(434, 24);
            this.lblAusbezahltFLBTotal.TabIndex = 17;
            this.lblAusbezahltFLBTotal.Text = "Total an Klienten ausbezahlt aus FLB-Fonds aktuelles Jahr";
            this.lblAusbezahltFLBTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // edtAusbezahltFLBTotal
            // 
            this.edtAusbezahltFLBTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAusbezahltFLBTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAusbezahltFLBTotal.Location = new System.Drawing.Point(796, 38);
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
            this.edtAusbezahltFLBTotal.Properties.Mask.EditMask = "n2";
            this.edtAusbezahltFLBTotal.Properties.ReadOnly = true;
            this.edtAusbezahltFLBTotal.Size = new System.Drawing.Size(125, 24);
            this.edtAusbezahltFLBTotal.TabIndex = 18;
            // 
            // CtlGvGesuch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.edtAusbezahltFLBTotal);
            this.Controls.Add(this.lblAusbezahltFLBTotal);
            this.Controls.Add(this.chkExtern);
            this.Controls.Add(this.btnGesuchAbschliessen);
            this.Controls.Add(this.lblGesuchsgrund);
            this.Controls.Add(this.edtGesuchsgrund);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtDokument);
            this.Controls.Add(this.lblDokument);
            this.Controls.Add(this.btnGesuchDuplizieren);
            this.Controls.Add(this.btnDatenimport);
            this.Controls.Add(this.edtFonds);
            this.Controls.Add(this.lblFonds);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.edtKlient);
            this.Controls.Add(this.lblFondsHinweis);
            this.Controls.Add(this.lblGesuchTotal);
            this.Controls.Add(this.edtGesuchTotal);
            this.Controls.Add(this.lblKlient);
            this.Name = "CtlGvGesuch";
            this.Size = new System.Drawing.Size(935, 291);
            this.Load += new System.EventHandler(this.CtlGvGesuch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFondsHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesuchTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesuchTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFonds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesuchsgrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesuchsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExtern.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahltFLBTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahltFLBTotal.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissButtonEdit edtKlient;
        private Gui.KissLabel lblFondsHinweis;
        private Gui.KissLabel lblGesuchTotal;
        private Gui.KissCalcEdit edtGesuchTotal;
        private Gui.KissLabel lblKlient;
        private Gui.KissLabel lblDatum;
        private Gui.KissDateEdit edtDatum;
        private Gui.KissLabel lblFonds;
        private Gui.KissLookUpEdit edtFonds;
        private Gui.KissButton btnDatenimport;
        private Gui.KissLabel lblDokument;
        private Dokument.XDokument edtDokument;
        private Gui.KissLabel lblBemerkung;
        private Gui.KissMemoEdit edtBemerkung;
        private System.Windows.Forms.OpenFileDialog ofdExcelImport;
        private Gui.KissTextEdit edtGesuchsgrund;
        private Gui.KissLabel lblGesuchsgrund;
        private Gui.KissButton btnGesuchDuplizieren;
        private Gui.KissButton btnGesuchAbschliessen;
        private Gui.KissCheckEdit chkExtern;
        private Gui.KissLabel lblAusbezahltFLBTotal;
        private Gui.KissCalcEdit edtAusbezahltFLBTotal;
    }
}
