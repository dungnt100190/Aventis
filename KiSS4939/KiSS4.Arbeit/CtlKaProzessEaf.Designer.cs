using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaProzess.
    /// </summary>
    partial class CtlKaProzessEaf
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaProzessEaf));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryQuery = new KiSS4.DB.SqlQuery(this.components);
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
            this.edtZustaendigKA = new KiSS4.Gui.KissTextEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblEroeffnung = new KiSS4.Gui.KissLabel();
            this.lblSBGrund = new KiSS4.Gui.KissLabel();
            this.datDatumBis = new KiSS4.Gui.KissDateEdit();
            this.datDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSBGrund = new KiSS4.Gui.KissTextEdit();
            this.lblSBEintritt = new KiSS4.Gui.KissLabel();
            this.datSBEintritt = new KiSS4.Gui.KissDateEdit();
            this.lblSBAustritt = new KiSS4.Gui.KissLabel();
            this.datSBAustritt = new KiSS4.Gui.KissDateEdit();
            this.lblSozioBilanz = new KiSS4.Gui.KissLabel();
            this.lblSpezErmittlung = new KiSS4.Gui.KissLabel();
            this.lblSEAustritt = new KiSS4.Gui.KissLabel();
            this.datSEAustritt = new KiSS4.Gui.KissDateEdit();
            this.lblSEEintritt = new KiSS4.Gui.KissLabel();
            this.datSEEintritt = new KiSS4.Gui.KissDateEdit();
            this.edtSEGrund = new KiSS4.Gui.KissTextEdit();
            this.lblSEGrund = new KiSS4.Gui.KissLabel();
            this.edtWiederholteSpezifischeErmittlungEAF = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSBGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSBGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSBEintritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSBEintritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSBAustritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSBAustritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozioBilanz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSpezErmittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSEAustritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSEAustritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSEEintritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSEEintritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSEGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSEGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWiederholteSpezifischeErmittlungEAF.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.CanUpdate = true;
            this.qryQuery.HostControl = this;
            this.qryQuery.IsIdentityInsert = false;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "FaLeistung";
            this.qryQuery.AfterPost += new System.EventHandler(this.qryQuery_AfterPost);
            this.qryQuery.BeforePost += new System.EventHandler(this.qryQuery_BeforePost);
            // 
            // btnReopen
            // 
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(101, 518);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(125, 24);
            this.btnReopen.TabIndex = 23;
            this.btnReopen.Text = "wieder öffnen";
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            // 
            // lblZustaendigKA
            // 
            this.lblZustaendigKA.Location = new System.Drawing.Point(6, 110);
            this.lblZustaendigKA.Name = "lblZustaendigKA";
            this.lblZustaendigKA.Size = new System.Drawing.Size(80, 24);
            this.lblZustaendigKA.TabIndex = 4;
            this.lblZustaendigKA.Text = "Zuständig KA";
            // 
            // edtZustaendigKA
            // 
            this.edtZustaendigKA.DataMember = "ZustaendigKA";
            this.edtZustaendigKA.DataSource = this.qryQuery;
            this.edtZustaendigKA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZustaendigKA.Location = new System.Drawing.Point(101, 110);
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
            this.edtZustaendigKA.TabIndex = 5;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(6, 488);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(70, 24);
            this.lblDatumBis.TabIndex = 21;
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
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Titel";
            // 
            // lblAbschluss
            // 
            this.lblAbschluss.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAbschluss.Location = new System.Drawing.Point(101, 463);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(100, 16);
            this.lblAbschluss.TabIndex = 20;
            this.lblAbschluss.Text = "Abschluss";
            // 
            // lblEroeffnung
            // 
            this.lblEroeffnung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblEroeffnung.Location = new System.Drawing.Point(101, 55);
            this.lblEroeffnung.Name = "lblEroeffnung";
            this.lblEroeffnung.Size = new System.Drawing.Size(100, 16);
            this.lblEroeffnung.TabIndex = 1;
            this.lblEroeffnung.Text = "Eröffnung";
            // 
            // lblSBGrund
            // 
            this.lblSBGrund.Location = new System.Drawing.Point(17, 248);
            this.lblSBGrund.Name = "lblSBGrund";
            this.lblSBGrund.Size = new System.Drawing.Size(70, 24);
            this.lblSBGrund.TabIndex = 11;
            this.lblSBGrund.Text = "Grund";
            // 
            // datDatumBis
            // 
            this.datDatumBis.DataMember = "DatumBis";
            this.datDatumBis.DataSource = this.qryQuery;
            this.datDatumBis.EditValue = null;
            this.datDatumBis.Location = new System.Drawing.Point(101, 488);
            this.datDatumBis.Name = "datDatumBis";
            this.datDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseFont = true;
            this.datDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.datDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.datDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datDatumBis.Properties.ShowToday = false;
            this.datDatumBis.Size = new System.Drawing.Size(89, 24);
            this.datDatumBis.TabIndex = 22;
            // 
            // datDatumVon
            // 
            this.datDatumVon.DataMember = "DatumVon";
            this.datDatumVon.DataSource = this.qryQuery;
            this.datDatumVon.EditValue = null;
            this.datDatumVon.Location = new System.Drawing.Point(101, 80);
            this.datDatumVon.Name = "datDatumVon";
            this.datDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseFont = true;
            this.datDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.datDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.datDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datDatumVon.Properties.ShowToday = false;
            this.datDatumVon.Size = new System.Drawing.Size(89, 24);
            this.datDatumVon.TabIndex = 3;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(6, 80);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblDatumVon.TabIndex = 2;
            this.lblDatumVon.Text = "Datum";
            // 
            // edtSBGrund
            // 
            this.edtSBGrund.DataMember = "SozGrund";
            this.edtSBGrund.DataSource = this.qryQuery;
            this.edtSBGrund.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSBGrund.Location = new System.Drawing.Point(101, 248);
            this.edtSBGrund.Name = "edtSBGrund";
            this.edtSBGrund.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSBGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSBGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSBGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtSBGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSBGrund.Properties.Appearance.Options.UseFont = true;
            this.edtSBGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSBGrund.Properties.ReadOnly = true;
            this.edtSBGrund.Size = new System.Drawing.Size(432, 24);
            this.edtSBGrund.TabIndex = 12;
            // 
            // lblSBEintritt
            // 
            this.lblSBEintritt.Location = new System.Drawing.Point(17, 188);
            this.lblSBEintritt.Name = "lblSBEintritt";
            this.lblSBEintritt.Size = new System.Drawing.Size(80, 24);
            this.lblSBEintritt.TabIndex = 7;
            this.lblSBEintritt.Text = "Eintritt";
            // 
            // datSBEintritt
            // 
            this.datSBEintritt.DataMember = "SozEintritt";
            this.datSBEintritt.DataSource = this.qryQuery;
            this.datSBEintritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datSBEintritt.EditValue = null;
            this.datSBEintritt.Location = new System.Drawing.Point(101, 188);
            this.datSBEintritt.Name = "datSBEintritt";
            this.datSBEintritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datSBEintritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datSBEintritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datSBEintritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datSBEintritt.Properties.Appearance.Options.UseBackColor = true;
            this.datSBEintritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datSBEintritt.Properties.Appearance.Options.UseFont = true;
            this.datSBEintritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.datSBEintritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datSBEintritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.datSBEintritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datSBEintritt.Properties.ReadOnly = true;
            this.datSBEintritt.Properties.ShowToday = false;
            this.datSBEintritt.Size = new System.Drawing.Size(89, 24);
            this.datSBEintritt.TabIndex = 8;
            // 
            // lblSBAustritt
            // 
            this.lblSBAustritt.Location = new System.Drawing.Point(17, 218);
            this.lblSBAustritt.Name = "lblSBAustritt";
            this.lblSBAustritt.Size = new System.Drawing.Size(80, 24);
            this.lblSBAustritt.TabIndex = 9;
            this.lblSBAustritt.Text = "Austritt";
            // 
            // datSBAustritt
            // 
            this.datSBAustritt.DataMember = "SozAustritt";
            this.datSBAustritt.DataSource = this.qryQuery;
            this.datSBAustritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datSBAustritt.EditValue = null;
            this.datSBAustritt.Location = new System.Drawing.Point(101, 218);
            this.datSBAustritt.Name = "datSBAustritt";
            this.datSBAustritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datSBAustritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datSBAustritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datSBAustritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datSBAustritt.Properties.Appearance.Options.UseBackColor = true;
            this.datSBAustritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datSBAustritt.Properties.Appearance.Options.UseFont = true;
            this.datSBAustritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.datSBAustritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datSBAustritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.datSBAustritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datSBAustritt.Properties.ReadOnly = true;
            this.datSBAustritt.Properties.ShowToday = false;
            this.datSBAustritt.Size = new System.Drawing.Size(89, 24);
            this.datSBAustritt.TabIndex = 10;
            // 
            // lblSozioBilanz
            // 
            this.lblSozioBilanz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSozioBilanz.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSozioBilanz.Location = new System.Drawing.Point(6, 161);
            this.lblSozioBilanz.Name = "lblSozioBilanz";
            this.lblSozioBilanz.Size = new System.Drawing.Size(174, 24);
            this.lblSozioBilanz.TabIndex = 6;
            this.lblSozioBilanz.Text = "sozioberufliche Bilanz";
            this.lblSozioBilanz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpezErmittlung
            // 
            this.lblSpezErmittlung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSpezErmittlung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSpezErmittlung.Location = new System.Drawing.Point(4, 322);
            this.lblSpezErmittlung.Name = "lblSpezErmittlung";
            this.lblSpezErmittlung.Size = new System.Drawing.Size(174, 24);
            this.lblSpezErmittlung.TabIndex = 13;
            this.lblSpezErmittlung.Text = "spezifische Ermittlung";
            this.lblSpezErmittlung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSEAustritt
            // 
            this.lblSEAustritt.Location = new System.Drawing.Point(17, 379);
            this.lblSEAustritt.Name = "lblSEAustritt";
            this.lblSEAustritt.Size = new System.Drawing.Size(80, 24);
            this.lblSEAustritt.TabIndex = 16;
            this.lblSEAustritt.Text = "Austritt";
            // 
            // datSEAustritt
            // 
            this.datSEAustritt.DataMember = "SpezAustritt";
            this.datSEAustritt.DataSource = this.qryQuery;
            this.datSEAustritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datSEAustritt.EditValue = null;
            this.datSEAustritt.Location = new System.Drawing.Point(101, 379);
            this.datSEAustritt.Name = "datSEAustritt";
            this.datSEAustritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datSEAustritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datSEAustritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datSEAustritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datSEAustritt.Properties.Appearance.Options.UseBackColor = true;
            this.datSEAustritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datSEAustritt.Properties.Appearance.Options.UseFont = true;
            this.datSEAustritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datSEAustritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datSEAustritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datSEAustritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datSEAustritt.Properties.ReadOnly = true;
            this.datSEAustritt.Properties.ShowToday = false;
            this.datSEAustritt.Size = new System.Drawing.Size(89, 24);
            this.datSEAustritt.TabIndex = 17;
            // 
            // lblSEEintritt
            // 
            this.lblSEEintritt.Location = new System.Drawing.Point(17, 349);
            this.lblSEEintritt.Name = "lblSEEintritt";
            this.lblSEEintritt.Size = new System.Drawing.Size(80, 24);
            this.lblSEEintritt.TabIndex = 14;
            this.lblSEEintritt.Text = "Eintritt";
            // 
            // datSEEintritt
            // 
            this.datSEEintritt.DataMember = "SpezEintritt";
            this.datSEEintritt.DataSource = this.qryQuery;
            this.datSEEintritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datSEEintritt.EditValue = null;
            this.datSEEintritt.Location = new System.Drawing.Point(101, 349);
            this.datSEEintritt.Name = "datSEEintritt";
            this.datSEEintritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datSEEintritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datSEEintritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datSEEintritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datSEEintritt.Properties.Appearance.Options.UseBackColor = true;
            this.datSEEintritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datSEEintritt.Properties.Appearance.Options.UseFont = true;
            this.datSEEintritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.datSEEintritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datSEEintritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.datSEEintritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datSEEintritt.Properties.ReadOnly = true;
            this.datSEEintritt.Properties.ShowToday = false;
            this.datSEEintritt.Size = new System.Drawing.Size(89, 24);
            this.datSEEintritt.TabIndex = 15;
            // 
            // edtSEGrund
            // 
            this.edtSEGrund.DataMember = "SpezGrund";
            this.edtSEGrund.DataSource = this.qryQuery;
            this.edtSEGrund.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSEGrund.Location = new System.Drawing.Point(101, 409);
            this.edtSEGrund.Name = "edtSEGrund";
            this.edtSEGrund.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSEGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSEGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSEGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtSEGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSEGrund.Properties.Appearance.Options.UseFont = true;
            this.edtSEGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSEGrund.Properties.ReadOnly = true;
            this.edtSEGrund.Size = new System.Drawing.Size(432, 24);
            this.edtSEGrund.TabIndex = 19;
            // 
            // lblSEGrund
            // 
            this.lblSEGrund.Location = new System.Drawing.Point(17, 409);
            this.lblSEGrund.Name = "lblSEGrund";
            this.lblSEGrund.Size = new System.Drawing.Size(70, 24);
            this.lblSEGrund.TabIndex = 18;
            this.lblSEGrund.Text = "Grund";
            // 
            // edtWiederholteSpezifischeErmittlungEAF
            // 
            this.edtWiederholteSpezifischeErmittlungEAF.DataMember = "WiederholteSpezifischeErmittlungEAF";
            this.edtWiederholteSpezifischeErmittlungEAF.DataSource = this.qryQuery;
            this.edtWiederholteSpezifischeErmittlungEAF.Location = new System.Drawing.Point(101, 281);
            this.edtWiederholteSpezifischeErmittlungEAF.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.edtWiederholteSpezifischeErmittlungEAF.Name = "edtWiederholteSpezifischeErmittlungEAF";
            this.edtWiederholteSpezifischeErmittlungEAF.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWiederholteSpezifischeErmittlungEAF.Properties.Appearance.Options.UseBackColor = true;
            this.edtWiederholteSpezifischeErmittlungEAF.Properties.Caption = "wiederholte spezifische Ermittlung (SB siehe vorangegangene Leistung EAF)";
            this.edtWiederholteSpezifischeErmittlungEAF.Size = new System.Drawing.Size(432, 19);
            this.edtWiederholteSpezifischeErmittlungEAF.TabIndex = 517;
            // 
            // CtlKaProzessEaf
            // 
            this.ActiveSQLQuery = this.qryQuery;
            this.AutoScroll = true;
            this.Controls.Add(this.edtWiederholteSpezifischeErmittlungEAF);
            this.Controls.Add(this.lblSpezErmittlung);
            this.Controls.Add(this.lblSEAustritt);
            this.Controls.Add(this.datSEAustritt);
            this.Controls.Add(this.lblSEEintritt);
            this.Controls.Add(this.datSEEintritt);
            this.Controls.Add(this.edtSEGrund);
            this.Controls.Add(this.lblSEGrund);
            this.Controls.Add(this.lblSozioBilanz);
            this.Controls.Add(this.lblSBAustritt);
            this.Controls.Add(this.datSBAustritt);
            this.Controls.Add(this.lblSBEintritt);
            this.Controls.Add(this.datSBEintritt);
            this.Controls.Add(this.edtSBGrund);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.lblZustaendigKA);
            this.Controls.Add(this.edtZustaendigKA);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblAbschluss);
            this.Controls.Add(this.lblEroeffnung);
            this.Controls.Add(this.lblSBGrund);
            this.Controls.Add(this.datDatumBis);
            this.Controls.Add(this.datDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Name = "CtlKaProzessEaf";
            this.Size = new System.Drawing.Size(680, 557);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSBGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSBGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSBEintritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSBEintritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSBAustritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSBAustritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozioBilanz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSpezErmittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSEAustritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSEAustritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSEEintritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSEEintritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSEGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSEGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWiederholteSpezifischeErmittlungEAF.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnReopen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit datSBAustritt;
        private KiSS4.Gui.KissDateEdit datDatumBis;
        private KiSS4.Gui.KissDateEdit datDatumVon;
        private KiSS4.Gui.KissDateEdit datSBEintritt;
        private KiSS4.Gui.KissTextEdit edtSBGrund;
        private KiSS4.Gui.KissTextEdit edtZustaendigKA;
        private KiSS4.Gui.KissLabel lblAbschluss;
        private KiSS4.Gui.KissLabel lblSBAustritt;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblSBEintritt;
        private KiSS4.Gui.KissLabel lblEroeffnung;
        private KiSS4.Gui.KissLabel lblSBGrund;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblZustaendigKA;
        private System.Windows.Forms.PictureBox picTitle;
        private KissLabel lblSozioBilanz;
        private KissLabel lblSpezErmittlung;
        private KissLabel lblSEAustritt;
        private KissDateEdit datSEAustritt;
        private KissLabel lblSEEintritt;
        private KissDateEdit datSEEintritt;
        private KissTextEdit edtSEGrund;
        private KissLabel lblSEGrund;
        private KiSS4.DB.SqlQuery qryQuery;
        private KissCheckEdit edtWiederholteSpezifischeErmittlungEAF;
    }
}
