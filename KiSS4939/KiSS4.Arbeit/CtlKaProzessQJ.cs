using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaProzess.
    /// </summary>
    public class CtlKaProzessQJ : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int BaPersonID = 0;
        private KiSS4.Gui.KissButton btnReopen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit datAustritt;
        private KiSS4.Gui.KissDateEdit datDatumBis;
        private KiSS4.Gui.KissDateEdit datDatumVon;
        private KiSS4.Gui.KissDateEdit datEintritt;
        private KiSS4.Gui.KissTextEdit edtGrund;
        private KiSS4.Gui.KissTextEdit edtZustaendigKA;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissLabel lblAbschluss;
        private KiSS4.Gui.KissLabel lblAustritt;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEintritt;
        private KiSS4.Gui.KissLabel lblEroeffnung;
        private KiSS4.Gui.KissLabel lblGrund;
        private KiSS4.Gui.KissLabel lblGrundZusatz;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblZustaendigKA;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryFall;

        #endregion

        #endregion

        #region Constructors

        public CtlKaProzessQJ()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaProzessQJ));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFall = new KiSS4.DB.SqlQuery(this.components);
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
            this.edtZustaendigKA = new KiSS4.Gui.KissTextEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblEroeffnung = new KiSS4.Gui.KissLabel();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.datDatumBis = new KiSS4.Gui.KissDateEdit();
            this.datDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtGrund = new KiSS4.Gui.KissTextEdit();
            this.lblEintritt = new KiSS4.Gui.KissLabel();
            this.datEintritt = new KiSS4.Gui.KissDateEdit();
            this.lblAustritt = new KiSS4.Gui.KissLabel();
            this.datAustritt = new KiSS4.Gui.KissDateEdit();
            this.lblGrundZusatz = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEintritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEintritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundZusatz)).BeginInit();
            this.SuspendLayout();
            // 
            // qryFall
            // 
            this.qryFall.CanUpdate = true;
            this.qryFall.HostControl = this;
            this.qryFall.IsIdentityInsert = false;
            this.qryFall.TableName = "FaLeistung";
            this.qryFall.AfterPost += new System.EventHandler(this.qryFall_AfterPost);
            this.qryFall.BeforePost += new System.EventHandler(this.qryFall_BeforePost);
            // 
            // btnReopen
            // 
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(90, 325);
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
            this.lblZustaendigKA.Size = new System.Drawing.Size(80, 24);
            this.lblZustaendigKA.TabIndex = 519;
            this.lblZustaendigKA.Text = "Zuständig KA";
            // 
            // edtZustaendigKA
            // 
            this.edtZustaendigKA.DataMember = "ZustaendigKA";
            this.edtZustaendigKA.DataSource = this.qryFall;
            this.edtZustaendigKA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZustaendigKA.Location = new System.Drawing.Point(90, 110);
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
            this.lblDatumBis.Location = new System.Drawing.Point(5, 290);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(70, 24);
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
            this.lblAbschluss.Location = new System.Drawing.Point(90, 265);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(100, 16);
            this.lblAbschluss.TabIndex = 515;
            this.lblAbschluss.Text = "Abschluss";
            // 
            // lblEroeffnung
            // 
            this.lblEroeffnung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblEroeffnung.Location = new System.Drawing.Point(90, 55);
            this.lblEroeffnung.Name = "lblEroeffnung";
            this.lblEroeffnung.Size = new System.Drawing.Size(100, 16);
            this.lblEroeffnung.TabIndex = 514;
            this.lblEroeffnung.Text = "Eröffnung";
            // 
            // lblGrund
            // 
            this.lblGrund.Location = new System.Drawing.Point(5, 200);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(70, 24);
            this.lblGrund.TabIndex = 512;
            this.lblGrund.Text = "Grund";
            // 
            // datDatumBis
            // 
            this.datDatumBis.DataMember = "DatumBis";
            this.datDatumBis.DataSource = this.qryFall;
            this.datDatumBis.EditValue = null;
            this.datDatumBis.Location = new System.Drawing.Point(90, 290);
            this.datDatumBis.Name = "datDatumBis";
            this.datDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseFont = true;
            this.datDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.datDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
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
            this.datDatumVon.Location = new System.Drawing.Point(90, 80);
            this.datDatumVon.Name = "datDatumVon";
            this.datDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseFont = true;
            this.datDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.datDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.datDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datDatumVon.Properties.ShowToday = false;
            this.datDatumVon.Size = new System.Drawing.Size(89, 24);
            this.datDatumVon.TabIndex = 504;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 80);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblDatumVon.TabIndex = 505;
            this.lblDatumVon.Text = "Datum";
            // 
            // edtGrund
            // 
            this.edtGrund.DataMember = "Grund";
            this.edtGrund.DataSource = this.qryFall;
            this.edtGrund.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrund.Location = new System.Drawing.Point(90, 200);
            this.edtGrund.Name = "edtGrund";
            this.edtGrund.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrund.Properties.Appearance.Options.UseFont = true;
            this.edtGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrund.Properties.ReadOnly = true;
            this.edtGrund.Size = new System.Drawing.Size(432, 24);
            this.edtGrund.TabIndex = 521;
            // 
            // lblEintritt
            // 
            this.lblEintritt.Location = new System.Drawing.Point(5, 140);
            this.lblEintritt.Name = "lblEintritt";
            this.lblEintritt.Size = new System.Drawing.Size(80, 24);
            this.lblEintritt.TabIndex = 581;
            this.lblEintritt.Text = "Eintritt";
            // 
            // datEintritt
            // 
            this.datEintritt.DataMember = "Eintritt";
            this.datEintritt.DataSource = this.qryFall;
            this.datEintritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datEintritt.EditValue = null;
            this.datEintritt.Location = new System.Drawing.Point(90, 140);
            this.datEintritt.Name = "datEintritt";
            this.datEintritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEintritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datEintritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEintritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEintritt.Properties.Appearance.Options.UseBackColor = true;
            this.datEintritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datEintritt.Properties.Appearance.Options.UseFont = true;
            this.datEintritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.datEintritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEintritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.datEintritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEintritt.Properties.ReadOnly = true;
            this.datEintritt.Properties.ShowToday = false;
            this.datEintritt.Size = new System.Drawing.Size(89, 24);
            this.datEintritt.TabIndex = 580;
            // 
            // lblAustritt
            // 
            this.lblAustritt.Location = new System.Drawing.Point(5, 170);
            this.lblAustritt.Name = "lblAustritt";
            this.lblAustritt.Size = new System.Drawing.Size(80, 24);
            this.lblAustritt.TabIndex = 583;
            this.lblAustritt.Text = "Austritt";
            // 
            // datAustritt
            // 
            this.datAustritt.DataMember = "Austritt";
            this.datAustritt.DataSource = this.qryFall;
            this.datAustritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datAustritt.EditValue = null;
            this.datAustritt.Location = new System.Drawing.Point(90, 170);
            this.datAustritt.Name = "datAustritt";
            this.datAustritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datAustritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datAustritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datAustritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datAustritt.Properties.Appearance.Options.UseBackColor = true;
            this.datAustritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datAustritt.Properties.Appearance.Options.UseFont = true;
            this.datAustritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datAustritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datAustritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datAustritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datAustritt.Properties.ReadOnly = true;
            this.datAustritt.Properties.ShowToday = false;
            this.datAustritt.Size = new System.Drawing.Size(89, 24);
            this.datAustritt.TabIndex = 582;
            // 
            // lblGrundZusatz
            // 
            this.lblGrundZusatz.DataMember = "GrundZusatz";
            this.lblGrundZusatz.DataSource = this.qryFall;
            this.lblGrundZusatz.Location = new System.Drawing.Point(90, 225);
            this.lblGrundZusatz.Name = "lblGrundZusatz";
            this.lblGrundZusatz.Size = new System.Drawing.Size(425, 24);
            this.lblGrundZusatz.TabIndex = 584;
            // 
            // CtlKaProzessQJ
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.lblGrundZusatz);
            this.Controls.Add(this.lblAustritt);
            this.Controls.Add(this.datAustritt);
            this.Controls.Add(this.lblEintritt);
            this.Controls.Add(this.datEintritt);
            this.Controls.Add(this.edtGrund);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.lblZustaendigKA);
            this.Controls.Add(this.edtZustaendigKA);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblAbschluss);
            this.Controls.Add(this.lblEroeffnung);
            this.Controls.Add(this.lblGrund);
            this.Controls.Add(this.datDatumBis);
            this.Controls.Add(this.datDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Name = "CtlKaProzessQJ";
            this.Size = new System.Drawing.Size(680, 365);
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEintritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEintritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundZusatz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Dispose

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

        #endregion

        #region EventHandlers

        private void btnReopen_Click(object sender, System.EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaProzessQJ", "FallWiedereroeffnen", "Soll der geschlossene Fall wieder geöffnet werden ?"))
            {
                qryFall.CanUpdate = true;
                qryFall["DatumBis"] = DBNull.Value;
                qryFall.Post();
            }
        }

        private void qryFall_AfterPost(object sender, System.EventArgs e)
        {
            if (CloseAllgemein())
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = GetDate(), Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }
            else
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = null, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }

            //this.GetKissMainForm().TreeFallRefresh();
            //FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            SetEditMode();

            //this.GetKissMainForm().TreeFallRefresh();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFall_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(datDatumVon, "Eröffnungsdatum");

            //falls DatumBis erfasst, muss es grösser sein als DatumVon
            if (!DBUtil.IsEmpty(qryFall["DatumBis"]) && (DateTime)qryFall["DatumVon"] > (DateTime)qryFall["DatumBis"])
            {
                throw new KissInfoException("Das Eröffnungsdatum darf nicht nach dem Abschlussdatum sein!");
            }

            //prüfen, ob DatumVon in eine andere Fallperiode fällt
            int count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung         A WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung B WITH (READUNCOMMITTED) ON B.BaPersonID = A.BaPersonID
                                                                    AND B.ModulID = 7
                                                                    AND B.FaProzessCode = A.FaProzessCode
                                                                    AND B.FaLeistungID <> A.FaLeistungID
                                                                    AND {0} BETWEEN B.DatumVon AND B.DatumBis
                WHERE A.FaLeistungID = {1}",
                qryFall["DatumVon"],
                FaLeistungID);

            if (count > 0)
                throw new KissInfoException("Das Eröffnungsdatum darf nicht mit einem anderen Fall überschneiden!");

            if (!DBUtil.IsEmpty(qryFall["DatumBis"]))
            {
                SqlQuery qry = DBUtil.OpenSQL(@"SELECT WartelisteCode FROM dbo.KaQJIntake WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}", FaLeistungID);
                int warteliste = -1;

                if (!DBUtil.IsEmpty(qry["WartelisteCode"]))
                {
                    warteliste = Convert.ToInt32(qry["WartelisteCode"]);
                }
                else
                {
                    datDatumBis.EditValue = null;
                    qryFall["DatumBis"] = DBNull.Value;
                    throw new KissInfoException("Status Warteliste muss ausgefüllt werden!");
                }

                //"Eintritt erfolgt"
                if (warteliste == 3)
                {
                    SqlQuery qry1 = DBUtil.OpenSQL(@"SELECT ProgEnde, ProgEndeGrund FROM dbo.KaQJProzess WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}", FaLeistungID);

                    if (DBUtil.IsEmpty(qry1["ProgEnde"]) || DBUtil.IsEmpty(qry1["ProgEndeGrund"]))
                    {
                        datDatumBis.EditValue = null;
                        qryFall["DatumBis"] = DBNull.Value;
                        throw new KissInfoException("Programmende darf nicht leer sein!");
                    }
                }

                // Leistung kann nur mit Status Warteliste "Eintritt erfolgt" oder "kein Eintritt" abgeschlossen werden
                if (warteliste != 3 && warteliste != 4)
                {
                    datDatumBis.EditValue = null;
                    qryFall["DatumBis"] = DBNull.Value;
                    throw new KissInfoException("Abschluss nicht möglich! Status Warteliste (Maske Intake) mutieren.");
                }

                // 9890 'Status Warteliste' = 'kein Eintritt' dann Leistung kann ohne weitere Erfassungen abgeschlossen werden
                if (warteliste != 4)
                {
                    //Prüfung ob 'Zuteilung Bis' in Zuteilung Fachbereich MUSS-Feld
                    SqlQuery qry2 = DBUtil.OpenSQL(
                        @"
                    SELECT ZuteilungBis
                    FROM dbo.KaZuteilFachbereich WITH (READUNCOMMITTED)
                    WHERE BaPersonId = {0}
                    AND ZuteilungVon = (SELECT MAX(KZF.ZuteilungVon)
                                        FROM dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED)
                                        WHERE BaPersonID = {0})",
                        BaPersonID);

                    if (DBUtil.IsEmpty(qry2["ZuteilungBis"]))
                    {
                        datDatumBis.EditValue = null;
                        qryFall["DatumBis"] = DBNull.Value;
                        throw new KissInfoException("Zuteilung Bis in Zuteilung Fachbereich darf nicht leer sein!");
                    }

                    // Ticket 3232: Wenn Einsatz vorhanden und kein Abschluss => Fehlermeldung!
                    int cntEinsatz = (int)DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.KaVermittlungVorschlag VER WITH (READUNCOMMITTED)
                          INNER JOIN dbo.KaVermittlungEinsatz VEI WITH (READUNCOMMITTED) ON VER.KaVermittlungVorschlagID = VEI.KaVermittlungVorschlagID
                        WHERE VER.FaLeistungID = {0}
                          AND VEI.Abschluss IS NULL
                          AND VEI.EinsatzVon IS NOT NULL",
                        FaLeistungID);

                    if (cntEinsatz > 0)
                    {
                        datDatumBis.EditValue = null;
                        qryFall["DatumBis"] = DBNull.Value;
                        throw new KissInfoException("Es ist noch ein Einsatz ohne Abschluss vorhanden!");
                    }

                    //Kontrolle offene Pendenzen
                    int countPendenzen = Utils.GetAnzahlOffenePendenzen(FaLeistungID);
                    if (countPendenzen > 0)
                    {
                        KissMsg.ShowInfo(
                            "CtlFaBeratungsperiode",
                            "OffenePendenzenVorhanden",
                            "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                            countPendenzen);
                    }
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string TitleName, Image TitleImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitle.Image = TitleImage;
            this.FaLeistungID = FaLeistungID;
            this.BaPersonID = BaPersonID;

            qryFall.Fill(@"
                select	FAL.*,
                        ZustaendigKA = USR.LastName + isnull(', ' + USR.FirstName,''),
                        ARC.FaLeistungArchivID,
                        Eintritt = KAE.DatumVon,
                        Austritt = PRO.ProgEnde,
                        Grund = case PRO.ProgEndeGrund 	when 1 then dbo.fnLOVText('KaQjGrundProgEnde', PRO.ProgEndeCode)
                                                        when 2 then 'Arbeitgeber Abbruch'
                                                        when 3 then 'Arbeitnehmer Abbruch'
                                                        when 4 then 'Gegenseitiger Abbruch'
                                                        else ''	end,
                        GrundZusatz = CASE WHEN QJI.WartelisteCode = 4 THEN dbo.fnLOVText('KaQjIntakeStatusWarteliste', QJI.WartelisteCode) ELSE '' END
                from	dbo.FaLeistung FAL WITH (READUNCOMMITTED)
                        left join dbo.KaEinsatz	KAE	WITH (READUNCOMMITTED)	on	KAE.BaPersonID = FAL.BaPersonID
                                                        and KAE.DatumVon = (SELECT MIN(KAE1.DatumVon)
                                                                            FROM KaEinsatz KAE1
                                                                            WHERE KAE1.BaPersonID = FAL.BaPersonID
                                                                            AND DATEADD(DAY, 1, KAE1.DatumVon) BETWEEN FAL.DatumVon AND isNull(FAL.DatumBis, Convert(datetime,'31.12.2900', 104)))
                                                        and (KAE.SichtbarSDFlag = {2} or KAE.SichtbarSDFlag = 1)
                        left join dbo.XUser USR	WITH (READUNCOMMITTED)		on	USR.UserID = FAL.UserID
                        left join dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED)	on	ARC.FaLeistungID = FAL.FaLeistungID and
                                                        ARC.CheckOut is null
                        left join dbo.KaQJProzess	PRO  WITH (READUNCOMMITTED)on	PRO.FaLeistungID = FAL.FaLeistungID and
                                                        (PRO.SichtbarSDFlag = {2} or PRO.SichtbarSDFlag = 1)
                        left join dbo.KaQJIntake QJI WITH (READUNCOMMITTED) on QJI.FaLeistungID = FAL.FaLeistungID and
                                                    (QJI.SichtbarSDFlag = {2} or QJI.SichtbarSDFlag = 1)
                where	FAL.FaLeistungID = {0}",
                FaLeistungID, BaPersonID, KaUtil.GetSichtbarSDFlag(this.BaPersonID));

            SetEditMode();
        }

        public override bool OnSaveData()
        {
            bool ret = qryFall.Post();
            SetEditMode();
            return ret;
        }

        #endregion

        #region Private Methods

        private bool CloseAllgemein()
        {
            bool rslt = false;

            rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from dbo.FaLeistung WITH (READUNCOMMITTED)
                                          where BaPersonID = {0}
                                          and   ModulID = 7
                                          and   FaProzessCode BETWEEN 701 AND 720
                                          and   DatumBis is null",
                BaPersonID)
                ) == 0;

            return rslt;
        }

        private void SetEditMode()
        {
            if (qryFall.Count == 0) return;

            //nur owner oder admin darf abschliessen
            if (Session.User.IsUserAdmin || (int)qryFall["UserID"] == Session.User.UserID || DBUtil.UserHasRight("CtlKaProzessQJ"))
            {
                bool open = DBUtil.IsEmpty(qryFall["DatumBis"]);
                bool archived = !DBUtil.IsEmpty(qryFall["FaLeistungArchivID"]);

                qryFall.CanUpdate = DBUtil.UserHasRight("CtlKaProzessQJ", "UI");
                qryFall.EnableBoundFields(qryFall.CanUpdate && open);
                btnReopen.Visible = !open && !archived && qryFall.CanUpdate;
            }
            else
            {
                qryFall.EnableBoundFields(false);
                btnReopen.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}