namespace KiSS4.Arbeit
{
    public partial class CtlKaProzessAK
    {
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaProzessAK));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFall = new KiSS4.DB.SqlQuery(this.components);
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
            this.edtZustaendigKA = new KiSS4.Gui.KissTextEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblEroeffnung = new KiSS4.Gui.KissLabel();
            this.lblBeurteilung = new KiSS4.Gui.KissLabel();
            this.datDatumBis = new KiSS4.Gui.KissDateEdit();
            this.datDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtIntegration = new KiSS4.Gui.KissTextEdit();
            this.lblLetztesModul = new KiSS4.Gui.KissLabel();
            this.edtPhasenCode = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeurteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetztesModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhasenCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryFall
            // 
            this.qryFall.CanUpdate = true;
            this.qryFall.HostControl = this;
            this.qryFall.IsIdentityInsert = false;
            this.qryFall.SelectStatement = resources.GetString("qryFall.SelectStatement");
            this.qryFall.TableName = "FaLeistung";
            this.qryFall.AfterPost += new System.EventHandler(this.qryFall_AfterPost);
            this.qryFall.BeforePost += new System.EventHandler(this.qryFall_BeforePost);
            // 
            // btnReopen
            // 
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(135, 285);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(90, 24);
            this.btnReopen.TabIndex = 511;
            this.btnReopen.Text = "wieder öffnen";
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            // 
            // lblZustaendigKA
            // 
            this.lblZustaendigKA.Location = new System.Drawing.Point(5, 110);
            this.lblZustaendigKA.Name = "lblZustaendigKA";
            this.lblZustaendigKA.Size = new System.Drawing.Size(124, 24);
            this.lblZustaendigKA.TabIndex = 519;
            this.lblZustaendigKA.Text = "Zuständig KA";
            // 
            // edtZustaendigKA
            // 
            this.edtZustaendigKA.DataMember = "ZustaendigKA";
            this.edtZustaendigKA.DataSource = this.qryFall;
            this.edtZustaendigKA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZustaendigKA.Location = new System.Drawing.Point(135, 110);
            this.edtZustaendigKA.Name = "edtZustaendigKA";
            this.edtZustaendigKA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZustaendigKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZustaendigKA.Properties.ReadOnly = true;
            this.edtZustaendigKA.Size = new System.Drawing.Size(432, 24);
            this.edtZustaendigKA.TabIndex = 507;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(5, 250);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(124, 24);
            this.lblDatumBis.TabIndex = 518;
            this.lblDatumBis.Text = "Datum";
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 15);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 516;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 15);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 517;
            this.lblTitel.Text = "Titel";
            // 
            // lblAbschluss
            // 
            this.lblAbschluss.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAbschluss.Location = new System.Drawing.Point(135, 195);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(100, 16);
            this.lblAbschluss.TabIndex = 515;
            this.lblAbschluss.Text = "Abschluss";
            // 
            // lblEroeffnung
            // 
            this.lblEroeffnung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblEroeffnung.Location = new System.Drawing.Point(135, 55);
            this.lblEroeffnung.Name = "lblEroeffnung";
            this.lblEroeffnung.Size = new System.Drawing.Size(100, 16);
            this.lblEroeffnung.TabIndex = 514;
            this.lblEroeffnung.Text = "Eröffnung";
            // 
            // lblBeurteilung
            // 
            this.lblBeurteilung.Location = new System.Drawing.Point(5, 220);
            this.lblBeurteilung.Name = "lblBeurteilung";
            this.lblBeurteilung.Size = new System.Drawing.Size(125, 24);
            this.lblBeurteilung.TabIndex = 512;
            this.lblBeurteilung.Text = "Integrationsbeurteilung";
            // 
            // datDatumBis
            // 
            this.datDatumBis.DataMember = "DatumBis";
            this.datDatumBis.DataSource = this.qryFall;
            this.datDatumBis.EditValue = null;
            this.datDatumBis.Location = new System.Drawing.Point(135, 250);
            this.datDatumBis.Name = "datDatumBis";
            this.datDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseFont = true;
            this.datDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datDatumBis.Properties.ShowToday = false;
            this.datDatumBis.Size = new System.Drawing.Size(89, 24);
            this.datDatumBis.TabIndex = 508;
            // 
            // datDatumVon
            // 
            this.datDatumVon.DataMember = "DatumVon";
            this.datDatumVon.DataSource = this.qryFall;
            this.datDatumVon.EditValue = null;
            this.datDatumVon.Location = new System.Drawing.Point(135, 80);
            this.datDatumVon.Name = "datDatumVon";
            this.datDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseFont = true;
            this.datDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.datDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.datDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datDatumVon.Properties.ShowToday = false;
            this.datDatumVon.Size = new System.Drawing.Size(89, 24);
            this.datDatumVon.TabIndex = 504;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 80);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(124, 24);
            this.lblDatumVon.TabIndex = 505;
            this.lblDatumVon.Text = "Datum";
            // 
            // edtIntegration
            // 
            this.edtIntegration.DataMember = "Integration";
            this.edtIntegration.DataSource = this.qryFall;
            this.edtIntegration.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIntegration.Location = new System.Drawing.Point(135, 220);
            this.edtIntegration.Name = "edtIntegration";
            this.edtIntegration.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIntegration.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIntegration.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntegration.Properties.Appearance.Options.UseBackColor = true;
            this.edtIntegration.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIntegration.Properties.Appearance.Options.UseFont = true;
            this.edtIntegration.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIntegration.Properties.ReadOnly = true;
            this.edtIntegration.Size = new System.Drawing.Size(432, 24);
            this.edtIntegration.TabIndex = 521;
            // 
            // lblLetztesModul
            // 
            this.lblLetztesModul.Location = new System.Drawing.Point(5, 140);
            this.lblLetztesModul.Name = "lblLetztesModul";
            this.lblLetztesModul.Size = new System.Drawing.Size(124, 24);
            this.lblLetztesModul.TabIndex = 581;
            this.lblLetztesModul.Text = "letztes Modul";
            // 
            // edtPhasenCode
            // 
            this.edtPhasenCode.DataMember = "Modul";
            this.edtPhasenCode.DataSource = this.qryFall;
            this.edtPhasenCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPhasenCode.Location = new System.Drawing.Point(135, 140);
            this.edtPhasenCode.Name = "edtPhasenCode";
            this.edtPhasenCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPhasenCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPhasenCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPhasenCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtPhasenCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPhasenCode.Properties.Appearance.Options.UseFont = true;
            this.edtPhasenCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPhasenCode.Properties.ReadOnly = true;
            this.edtPhasenCode.Size = new System.Drawing.Size(432, 24);
            this.edtPhasenCode.TabIndex = 582;
            // 
            // CtlKaProzessAK
            // 
            this.ActiveSQLQuery = this.qryFall;
            this.AutoScroll = true;
            this.Controls.Add(this.edtPhasenCode);
            this.Controls.Add(this.lblLetztesModul);
            this.Controls.Add(this.edtIntegration);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.lblZustaendigKA);
            this.Controls.Add(this.edtZustaendigKA);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblAbschluss);
            this.Controls.Add(this.lblEroeffnung);
            this.Controls.Add(this.lblBeurteilung);
            this.Controls.Add(this.datDatumBis);
            this.Controls.Add(this.datDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Name = "CtlKaProzessAK";
            this.Size = new System.Drawing.Size(620, 325);
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeurteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetztesModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhasenCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnReopen;
        private KiSS4.Gui.KissDateEdit datDatumBis;
        private KiSS4.Gui.KissDateEdit datDatumVon;
        private KiSS4.Gui.KissTextEdit edtIntegration;
        private KiSS4.Gui.KissTextEdit edtPhasenCode;
        private KiSS4.Gui.KissTextEdit edtZustaendigKA;
        private KiSS4.Gui.KissLabel lblAbschluss;
        private KiSS4.Gui.KissLabel lblBeurteilung;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEroeffnung;
        private KiSS4.Gui.KissLabel lblLetztesModul;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblZustaendigKA;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryFall;
    }
}
