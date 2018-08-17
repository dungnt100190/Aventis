namespace KiSS4.Fallfuehrung
{
    partial class CtlFaBeratungsphase
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaBeratungsphase));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryPhase = new KiSS4.DB.SqlQuery(this.components);
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.lblAbschlussGrundCode = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtSAR = new KiSS4.Gui.KissButtonEdit();
            this.edtDLPzugewiesen = new KiSS4.Gui.KissLookUpEdit();
            this.qryDLP = new KiSS4.DB.SqlQuery(this.components);
            this.lblDLPZugewiesen = new KiSS4.Gui.KissLabel();
            this.lblDLPBedarf = new KiSS4.Gui.KissLabel();
            this.edtDLPBedarf = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPhase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPzugewiesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPzugewiesen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDLP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDLPZugewiesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDLPBedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPBedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPBedarf.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryPhase
            // 
            this.qryPhase.CanUpdate = true;
            this.qryPhase.HostControl = this;
            this.qryPhase.SelectStatement = resources.GetString("qryPhase.SelectStatement");
            this.qryPhase.TableName = "FaPhase";
            this.qryPhase.AfterPost += new System.EventHandler(this.qryPhase_AfterPost);
            this.qryPhase.BeforePost += new System.EventHandler(this.qryPhase_BeforePost);
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 80);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblDatumVon.TabIndex = 2;
            this.lblDatumVon.Text = "Datum";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryPhase;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(108, 80);
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
            this.edtDatumVon.Size = new System.Drawing.Size(89, 24);
            this.edtDatumVon.TabIndex = 3;
            // 
            // kissLabel4
            // 
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel4.Location = new System.Drawing.Point(108, 50);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(137, 16);
            this.kissLabel4.TabIndex = 1;
            this.kissLabel4.Text = "Phase-Eröffnung";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(101, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Beratungsphase";
            // 
            // picTitel
            // 
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(6, 110);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(70, 24);
            this.lblSAR.TabIndex = 4;
            this.lblSAR.Text = "SAR";
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(5, 260);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(70, 24);
            this.lblDatumBis.TabIndex = 9;
            this.lblDatumBis.Text = "Datum";
            // 
            // kissLabel5
            // 
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel5.Location = new System.Drawing.Point(108, 230);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(140, 16);
            this.kissLabel5.TabIndex = 8;
            this.kissLabel5.Text = "Phase-Abschluss";
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryPhase;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(108, 260);
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
            this.edtDatumBis.Size = new System.Drawing.Size(89, 24);
            this.edtDatumBis.TabIndex = 10;
            // 
            // btnReopen
            // 
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(108, 467);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(135, 24);
            this.btnReopen.TabIndex = 15;
            this.btnReopen.Text = "Phase wieder öffnen";
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            // 
            // lblAbschlussGrundCode
            // 
            this.lblAbschlussGrundCode.Location = new System.Drawing.Point(5, 290);
            this.lblAbschlussGrundCode.Name = "lblAbschlussGrundCode";
            this.lblAbschlussGrundCode.Size = new System.Drawing.Size(70, 24);
            this.lblAbschlussGrundCode.TabIndex = 11;
            this.lblAbschlussGrundCode.Text = "Grund";
            // 
            // edtAbschlussGrundCode
            // 
            this.edtAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrundCode.DataSource = this.qryPhase;
            this.edtAbschlussGrundCode.Location = new System.Drawing.Point(108, 290);
            this.edtAbschlussGrundCode.Name = "edtAbschlussGrundCode";
            this.edtAbschlussGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrundCode.Properties.NullText = "";
            this.edtAbschlussGrundCode.Properties.ShowFooter = false;
            this.edtAbschlussGrundCode.Properties.ShowHeader = false;
            this.edtAbschlussGrundCode.Size = new System.Drawing.Size(432, 24);
            this.edtAbschlussGrundCode.TabIndex = 12;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryPhase;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBemerkung.Location = new System.Drawing.Point(108, 320);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(432, 134);
            this.edtBemerkung.TabIndex = 14;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(5, 320);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(66, 24);
            this.lblBemerkung.TabIndex = 13;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // edtSAR
            // 
            this.edtSAR.DataMember = "SAR";
            this.edtSAR.DataSource = this.qryPhase;
            this.edtSAR.Location = new System.Drawing.Point(108, 110);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.Appearance.Options.UseForeColor = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSAR.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSAR.Size = new System.Drawing.Size(256, 24);
            this.edtSAR.TabIndex = 5;
            this.edtSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSAR_UserModifiedFld);
            // 
            // edtDLPzugewiesen
            // 
            this.edtDLPzugewiesen.DataMember = "FsDienstleistungspaketID_Zugewiesen";
            this.edtDLPzugewiesen.DataSource = this.qryPhase;
            this.edtDLPzugewiesen.Location = new System.Drawing.Point(108, 140);
            this.edtDLPzugewiesen.Name = "edtDLPzugewiesen";
            this.edtDLPzugewiesen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDLPzugewiesen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDLPzugewiesen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDLPzugewiesen.Properties.Appearance.Options.UseBackColor = true;
            this.edtDLPzugewiesen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDLPzugewiesen.Properties.Appearance.Options.UseFont = true;
            this.edtDLPzugewiesen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDLPzugewiesen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDLPzugewiesen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDLPzugewiesen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDLPzugewiesen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDLPzugewiesen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDLPzugewiesen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDLPzugewiesen.Properties.NullText = "";
            this.edtDLPzugewiesen.Properties.ShowFooter = false;
            this.edtDLPzugewiesen.Properties.ShowHeader = false;
            this.edtDLPzugewiesen.Size = new System.Drawing.Size(432, 24);
            this.edtDLPzugewiesen.TabIndex = 7;
            // 
            // qryDLP
            // 
            this.qryDLP.CanUpdate = true;
            this.qryDLP.HostControl = this;
            this.qryDLP.SelectStatement = "SELECT \r\n  Code   = DLP.FsDienstleistungspaketID,\r\n  [Text] = DLP.Name\r\nFROM dbo." +
    "FsDienstleistungspaket DLP WITH(READUNCOMMITTED)\r\nORDER BY DLP.Name";
            this.qryDLP.TableName = "FaPhase";
            // 
            // lblDLPZugewiesen
            // 
            this.lblDLPZugewiesen.Location = new System.Drawing.Point(7, 140);
            this.lblDLPZugewiesen.Name = "lblDLPZugewiesen";
            this.lblDLPZugewiesen.Size = new System.Drawing.Size(95, 24);
            this.lblDLPZugewiesen.TabIndex = 6;
            this.lblDLPZugewiesen.Text = "DLP zugewiesen";
            // 
            // lblDLPBedarf
            // 
            this.lblDLPBedarf.Location = new System.Drawing.Point(7, 170);
            this.lblDLPBedarf.Name = "lblDLPBedarf";
            this.lblDLPBedarf.Size = new System.Drawing.Size(70, 24);
            this.lblDLPBedarf.TabIndex = 16;
            this.lblDLPBedarf.Text = "DLP Bedarf";
            // 
            // edtDLPBedarf
            // 
            this.edtDLPBedarf.DataMember = "FsDienstleistungspaketID_Bedarf";
            this.edtDLPBedarf.DataSource = this.qryPhase;
            this.edtDLPBedarf.Location = new System.Drawing.Point(108, 170);
            this.edtDLPBedarf.Name = "edtDLPBedarf";
            this.edtDLPBedarf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDLPBedarf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDLPBedarf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDLPBedarf.Properties.Appearance.Options.UseBackColor = true;
            this.edtDLPBedarf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDLPBedarf.Properties.Appearance.Options.UseFont = true;
            this.edtDLPBedarf.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDLPBedarf.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDLPBedarf.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDLPBedarf.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDLPBedarf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDLPBedarf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDLPBedarf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDLPBedarf.Properties.NullText = "";
            this.edtDLPBedarf.Properties.ShowFooter = false;
            this.edtDLPBedarf.Properties.ShowHeader = false;
            this.edtDLPBedarf.Size = new System.Drawing.Size(432, 24);
            this.edtDLPBedarf.TabIndex = 17;
            // 
            // CtlFaBeratungsphase
            // 
            this.ActiveSQLQuery = this.qryPhase;
            this.Controls.Add(this.lblDLPBedarf);
            this.Controls.Add(this.edtDLPBedarf);
            this.Controls.Add(this.lblDLPZugewiesen);
            this.Controls.Add(this.edtDLPzugewiesen);
            this.Controls.Add(this.edtSAR);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblAbschlussGrundCode);
            this.Controls.Add(this.edtAbschlussGrundCode);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.lblSAR);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Name = "CtlFaBeratungsphase";
            this.Size = new System.Drawing.Size(560, 502);
            this.RefreshData += new System.EventHandler(this.CtlFaBeratungsphase_RefreshData);
            ((System.ComponentModel.ISupportInitialize)(this.qryPhase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPzugewiesen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPzugewiesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDLP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDLPZugewiesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDLPBedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPBedarf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDLPBedarf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnReopen;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrundCode;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissButtonEdit edtSAR;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel lblAbschlussGrundCode;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblSAR;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.Gui.KissLabel lblDLPZugewiesen;
        private KiSS4.Gui.KissLookUpEdit edtDLPzugewiesen;
        private KiSS4.DB.SqlQuery qryDLP;
        private KiSS4.DB.SqlQuery qryPhase;
        private Gui.KissLabel lblDLPBedarf;
        private Gui.KissLookUpEdit edtDLPBedarf;
    }
}
