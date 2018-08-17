namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaLeistung
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaLeistung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtAbschlussgrund = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.editMA = new KiSS4.Gui.KissTextEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblAbschlussgrund = new KiSS4.Gui.KissLabel();
            this.lblFaLeistungID = new KiSS4.Gui.KissLabel();
            this.edtFaLeistungID = new KiSS4.Gui.KissTextEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.lblFunktionsprofil = new KiSS4.Gui.KissLabel();
            this.edtFunktionsprofil = new KiSS4.Gui.KissTextEdit();
            this.edtFaFallID = new KiSS4.Gui.KissTextEdit();
            this.qryKontrolle = new KiSS4.DB.SqlQuery(this.components);
            this.lblTeilleistungserbringer = new KiSS4.Gui.KissLabel();
            this.chlTeilleistungserbringer = new KiSS4.Gui.KissCheckedLookupEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistungID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFunktionsprofil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktionsprofil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontrolle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilleistungserbringer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlTeilleistungserbringer)).BeginInit();
            this.SuspendLayout();
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(105, 410);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "editDatumBis.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(89, 24);
            this.edtDatumBis.TabIndex = 0;
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterFill += new System.EventHandler(this.qryFaLeistung_AfterFill);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforeDeleteQuestion += new System.EventHandler(this.qryFaLeistung_BeforeDeleteQuestion);
            this.qryFaLeistung.AfterDelete += new System.EventHandler(this.qryFaLeistung_AfterDelete);
            // 
            // kissLabel5
            // 
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel5.Location = new System.Drawing.Point(105, 380);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(124, 16);
            this.kissLabel5.TabIndex = 0;
            this.kissLabel5.Text = "Abschluss";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // edtAbschlussgrund
            // 
            this.edtAbschlussgrund.DataMember = "AbschlussGrundCode";
            this.edtAbschlussgrund.DataSource = this.qryFaLeistung;
            this.edtAbschlussgrund.Location = new System.Drawing.Point(105, 440);
            this.edtAbschlussgrund.LOVFilter = "F";
            this.edtAbschlussgrund.LOVName = "AbschlussGrund";
            this.edtAbschlussgrund.Name = "edtAbschlussgrund";
            this.edtAbschlussgrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussgrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussgrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussgrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussgrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussgrund.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussgrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussgrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussgrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussgrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussgrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbschlussgrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbschlussgrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussgrund.Properties.NullText = "";
            this.edtAbschlussgrund.Properties.ShowFooter = false;
            this.edtAbschlussgrund.Properties.ShowHeader = false;
            this.edtAbschlussgrund.Size = new System.Drawing.Size(388, 24);
            this.edtAbschlussgrund.TabIndex = 1;
            // 
            // kissLabel4
            // 
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel4.Location = new System.Drawing.Point(105, 50);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(126, 16);
            this.kissLabel4.TabIndex = 1;
            this.kissLabel4.Text = "Eröffnung";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(5, 410);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(70, 24);
            this.lblDatumBis.TabIndex = 1;
            this.lblDatumBis.Text = "Datum";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaLeistung;
            this.edtBemerkung.Location = new System.Drawing.Point(105, 470);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(388, 36);
            this.edtBemerkung.TabIndex = 2;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 110);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblDatumVon.TabIndex = 2;
            this.lblDatumVon.Text = "Datum";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // btnReopen
            // 
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(105, 517);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(118, 24);
            this.btnReopen.TabIndex = 3;
            this.btnReopen.Text = "Fall wieder öffnen";
            this.btnReopen.UseCompatibleTextRendering = true;
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Visible = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(105, 110);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "editDatumVon.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(89, 24);
            this.edtDatumVon.TabIndex = 4;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(5, 140);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(94, 24);
            this.kissLabel7.TabIndex = 4;
            this.kissLabel7.Text = "zuständige/r MA";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // editMA
            // 
            this.editMA.DataMember = "MA";
            this.editMA.DataSource = this.qryFaLeistung;
            this.editMA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMA.Location = new System.Drawing.Point(105, 140);
            this.editMA.Name = "editMA";
            this.editMA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMA.Properties.Appearance.Options.UseBackColor = true;
            this.editMA.Properties.Appearance.Options.UseBorderColor = true;
            this.editMA.Properties.Appearance.Options.UseFont = true;
            this.editMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editMA.Properties.Name = "editSAR.Properties";
            this.editMA.Properties.ReadOnly = true;
            this.editMA.Size = new System.Drawing.Size(388, 24);
            this.editMA.TabIndex = 5;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(5, 470);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(66, 24);
            this.lblBemerkung.TabIndex = 5;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.DataMember = "SB";
            this.kissTextEdit1.DataSource = this.qryFaLeistung;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(105, 170);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.Name = "editSAR.Properties";
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(388, 24);
            this.kissTextEdit1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 24);
            this.panel1.TabIndex = 14;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Fallführung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblAbschlussgrund
            // 
            this.lblAbschlussgrund.Location = new System.Drawing.Point(5, 440);
            this.lblAbschlussgrund.Name = "lblAbschlussgrund";
            this.lblAbschlussgrund.Size = new System.Drawing.Size(94, 24);
            this.lblAbschlussgrund.TabIndex = 15;
            this.lblAbschlussgrund.Text = "Abschlussgrund";
            this.lblAbschlussgrund.UseCompatibleTextRendering = true;
            // 
            // lblFaLeistungID
            // 
            this.lblFaLeistungID.Location = new System.Drawing.Point(5, 80);
            this.lblFaLeistungID.Name = "lblFaLeistungID";
            this.lblFaLeistungID.Size = new System.Drawing.Size(70, 24);
            this.lblFaLeistungID.TabIndex = 17;
            this.lblFaLeistungID.Text = "Leistung / Fall";
            this.lblFaLeistungID.UseCompatibleTextRendering = true;
            // 
            // edtFaLeistungID
            // 
            this.edtFaLeistungID.DataMember = "FaLeistungID";
            this.edtFaLeistungID.DataSource = this.qryFaLeistung;
            this.edtFaLeistungID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaLeistungID.Location = new System.Drawing.Point(105, 80);
            this.edtFaLeistungID.Name = "edtFaLeistungID";
            this.edtFaLeistungID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaLeistungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaLeistungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseFont = true;
            this.edtFaLeistungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaLeistungID.Properties.ReadOnly = true;
            this.edtFaLeistungID.Size = new System.Drawing.Size(89, 24);
            this.edtFaLeistungID.TabIndex = 18;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(5, 170);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(94, 24);
            this.kissLabel9.TabIndex = 19;
            this.kissLabel9.Text = "Sachbearbeitung";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // lblFunktionsprofil
            // 
            this.lblFunktionsprofil.Location = new System.Drawing.Point(200, 110);
            this.lblFunktionsprofil.Name = "lblFunktionsprofil";
            this.lblFunktionsprofil.Size = new System.Drawing.Size(106, 24);
            this.lblFunktionsprofil.TabIndex = 20;
            this.lblFunktionsprofil.Text = "Funktionsprofil";
            this.lblFunktionsprofil.UseCompatibleTextRendering = true;
            // 
            // edtFunktionsprofil
            // 
            this.edtFunktionsprofil.DataMember = "Funktionsprofil";
            this.edtFunktionsprofil.DataSource = this.qryFaLeistung;
            this.edtFunktionsprofil.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFunktionsprofil.Location = new System.Drawing.Point(305, 110);
            this.edtFunktionsprofil.Name = "edtFunktionsprofil";
            this.edtFunktionsprofil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFunktionsprofil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFunktionsprofil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFunktionsprofil.Properties.Appearance.Options.UseBackColor = true;
            this.edtFunktionsprofil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFunktionsprofil.Properties.Appearance.Options.UseFont = true;
            this.edtFunktionsprofil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFunktionsprofil.Properties.ReadOnly = true;
            this.edtFunktionsprofil.Size = new System.Drawing.Size(188, 24);
            this.edtFunktionsprofil.TabIndex = 21;
            // 
            // edtFaFallID
            // 
            this.edtFaFallID.DataMember = "FaFallID";
            this.edtFaFallID.DataSource = this.qryFaLeistung;
            this.edtFaFallID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaFallID.Location = new System.Drawing.Point(200, 80);
            this.edtFaFallID.Name = "edtFaFallID";
            this.edtFaFallID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaFallID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaFallID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaFallID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaFallID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaFallID.Properties.Appearance.Options.UseFont = true;
            this.edtFaFallID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaFallID.Properties.ReadOnly = true;
            this.edtFaFallID.Size = new System.Drawing.Size(100, 24);
            this.edtFaFallID.TabIndex = 22;
            // 
            // qryKontrolle
            // 
            this.qryKontrolle.HostControl = this;
            this.qryKontrolle.SelectStatement = resources.GetString("qryKontrolle.SelectStatement");
            // 
            // lblTeilleistungserbringer
            // 
            this.lblTeilleistungserbringer.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTeilleistungserbringer.Location = new System.Drawing.Point(105, 227);
            this.lblTeilleistungserbringer.Name = "lblTeilleistungserbringer";
            this.lblTeilleistungserbringer.Size = new System.Drawing.Size(388, 16);
            this.lblTeilleistungserbringer.TabIndex = 23;
            this.lblTeilleistungserbringer.Text = "Nur Teilleistungserbringer aktiv";
            this.lblTeilleistungserbringer.UseCompatibleTextRendering = true;
            // 
            // chlTeilleistungserbringer
            // 
            this.chlTeilleistungserbringer.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.chlTeilleistungserbringer.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.chlTeilleistungserbringer.Appearance.Options.UseBackColor = true;
            this.chlTeilleistungserbringer.Appearance.Options.UseBorderColor = true;
            this.chlTeilleistungserbringer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chlTeilleistungserbringer.CheckOnClick = true;
            this.chlTeilleistungserbringer.DataMember = "FaTeilleistungserbringerCodes";
            this.chlTeilleistungserbringer.DataSource = this.qryFaLeistung;
            this.chlTeilleistungserbringer.Location = new System.Drawing.Point(105, 257);
            this.chlTeilleistungserbringer.LOVName = "FaTeilleistungserbringer";
            this.chlTeilleistungserbringer.Name = "chlTeilleistungserbringer";
            this.chlTeilleistungserbringer.Size = new System.Drawing.Size(388, 90);
            this.chlTeilleistungserbringer.TabIndex = 24;
            // 
            // CtlFaLeistung
            // 
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.chlTeilleistungserbringer);
            this.Controls.Add(this.lblTeilleistungserbringer);
            this.Controls.Add(this.edtFaFallID);
            this.Controls.Add(this.edtFunktionsprofil);
            this.Controls.Add(this.lblFunktionsprofil);
            this.Controls.Add(this.kissLabel9);
            this.Controls.Add(this.edtFaLeistungID);
            this.Controls.Add(this.lblFaLeistungID);
            this.Controls.Add(this.lblAbschlussgrund);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kissTextEdit1);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.editMA);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.edtAbschlussgrund);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.edtDatumBis);
            this.Location = new System.Drawing.Point(90, -108);
            this.Name = "CtlFaLeistung";
            this.Size = new System.Drawing.Size(600, 550);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistungID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFunktionsprofil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktionsprofil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontrolle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilleistungserbringer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlTeilleistungserbringer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnReopen;
        private KiSS4.Gui.KissTextEdit editMA;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussgrund;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtFaFallID;
        private KiSS4.Gui.KissTextEdit edtFaLeistungID;
        private KiSS4.Gui.KissTextEdit edtFunktionsprofil;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissLabel lblAbschlussgrund;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblFaLeistungID;
        private KiSS4.Gui.KissLabel lblFunktionsprofil;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.DB.SqlQuery qryKontrolle;
        private Gui.KissCheckedLookupEdit chlTeilleistungserbringer;
        private Gui.KissLabel lblTeilleistungserbringer;
    }
}
