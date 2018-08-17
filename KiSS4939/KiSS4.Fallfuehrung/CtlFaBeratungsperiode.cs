using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung
{
    /// <summary>
    /// Summary description for ctlFFAnmeldung.
    /// </summary>
    public class CtlFaBeratungsperiode : KissUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnReopen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit editGemeinde;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrundCode;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtFaAufnahmeartCode;
        private KiSS4.Gui.KissLookUpEdit edtFaKontaktveranlasserCode;
        private KiSS4.Gui.KissTextEdit edtSAR;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel lblAbschlussGrundCode;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblFaAufnahmeartCode;
        private KiSS4.Gui.KissLabel lblFaKontaktveranlasserCode;
        private KiSS4.Gui.KissLabel lblSAR;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Panel panelAbschluss;
        private System.Windows.Forms.Panel panelAnmeldeart;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaLeistung;

        #endregion

        #endregion

        #region Constructors

        public CtlFaBeratungsperiode()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaBeratungsperiode));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtSAR = new KiSS4.Gui.KissTextEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.panelAbschluss = new System.Windows.Forms.Panel();
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblAbschlussGrundCode = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.panelAnmeldeart = new System.Windows.Forms.Panel();
            this.lblFaAufnahmeartCode = new KiSS4.Gui.KissLabel();
            this.lblFaKontaktveranlasserCode = new KiSS4.Gui.KissLabel();
            this.edtFaKontaktveranlasserCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtFaAufnahmeartCode = new KiSS4.Gui.KissLookUpEdit();
            this.editGemeinde = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            this.panelAbschluss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            this.panelAnmeldeart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaAufnahmeartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaKontaktveranlasserCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaKontaktveranlasserCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaKontaktveranlasserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaAufnahmeartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaAufnahmeartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            this.SuspendLayout();
            //
            // qryFaLeistung
            //
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(5, 80);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(102, 24);
            this.lblDatumVon.TabIndex = 0;
            this.lblDatumVon.Text = "Datum";
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(113, 80);
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
            this.edtDatumVon.TabIndex = 0;
            //
            // kissLabel4
            //
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel4.Location = new System.Drawing.Point(110, 50);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(283, 16);
            this.kissLabel4.TabIndex = 9;
            this.kissLabel4.Text = "Fall-Eröffnung";
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(109, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Beratungsperiode";
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
            // edtSAR
            //
            this.edtSAR.DataMember = "SAR";
            this.edtSAR.DataSource = this.qryFaLeistung;
            this.edtSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSAR.Location = new System.Drawing.Point(113, 110);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSAR.Properties.ReadOnly = true;
            this.edtSAR.Size = new System.Drawing.Size(280, 24);
            this.edtSAR.TabIndex = 1;
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(5, 110);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(102, 24);
            this.lblSAR.TabIndex = 17;
            this.lblSAR.Text = "SAR";
            //
            // panelAbschluss
            //
            this.panelAbschluss.Controls.Add(this.btnReopen);
            this.panelAbschluss.Controls.Add(this.edtBemerkung);
            this.panelAbschluss.Controls.Add(this.lblDatumBis);
            this.panelAbschluss.Controls.Add(this.kissLabel5);
            this.panelAbschluss.Controls.Add(this.lblBemerkung);
            this.panelAbschluss.Controls.Add(this.lblAbschlussGrundCode);
            this.panelAbschluss.Controls.Add(this.edtAbschlussGrundCode);
            this.panelAbschluss.Controls.Add(this.edtDatumBis);
            this.panelAbschluss.Location = new System.Drawing.Point(0, 200);
            this.panelAbschluss.Name = "panelAbschluss";
            this.panelAbschluss.Size = new System.Drawing.Size(537, 278);
            this.panelAbschluss.TabIndex = 3;
            //
            // btnReopen
            //
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(113, 241);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(118, 24);
            this.btnReopen.TabIndex = 3;
            this.btnReopen.Text = "Fall wieder öffnen";
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            //
            // edtBemerkung
            //
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaLeistung;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBemerkung.Location = new System.Drawing.Point(113, 101);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(409, 134);
            this.edtBemerkung.TabIndex = 2;
            //
            // lblDatumBis
            //
            this.lblDatumBis.Location = new System.Drawing.Point(5, 41);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(102, 24);
            this.lblDatumBis.TabIndex = 25;
            this.lblDatumBis.Text = "Datum";
            //
            // kissLabel5
            //
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel5.Location = new System.Drawing.Point(113, 11);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(124, 16);
            this.kissLabel5.TabIndex = 24;
            this.kissLabel5.Text = "Fall-Abschluss";
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(5, 101);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(102, 24);
            this.lblBemerkung.TabIndex = 23;
            this.lblBemerkung.Text = "Bemerkung";
            //
            // lblAbschlussGrundCode
            //
            this.lblAbschlussGrundCode.Location = new System.Drawing.Point(5, 71);
            this.lblAbschlussGrundCode.Name = "lblAbschlussGrundCode";
            this.lblAbschlussGrundCode.Size = new System.Drawing.Size(102, 24);
            this.lblAbschlussGrundCode.TabIndex = 22;
            this.lblAbschlussGrundCode.Text = "Grund";
            //
            // edtAbschlussGrundCode
            //
            this.edtAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrundCode.DataSource = this.qryFaLeistung;
            this.edtAbschlussGrundCode.Location = new System.Drawing.Point(113, 71);
            this.edtAbschlussGrundCode.LOVName = "Abschlussgrund";
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
            this.edtAbschlussGrundCode.Size = new System.Drawing.Size(409, 24);
            this.edtAbschlussGrundCode.TabIndex = 1;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(113, 41);
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
            this.edtDatumBis.TabIndex = 0;
            //
            // panelAnmeldeart
            //
            this.panelAnmeldeart.Controls.Add(this.lblFaAufnahmeartCode);
            this.panelAnmeldeart.Controls.Add(this.lblFaKontaktveranlasserCode);
            this.panelAnmeldeart.Controls.Add(this.edtFaKontaktveranlasserCode);
            this.panelAnmeldeart.Controls.Add(this.edtFaAufnahmeartCode);
            this.panelAnmeldeart.Location = new System.Drawing.Point(0, 140);
            this.panelAnmeldeart.Name = "panelAnmeldeart";
            this.panelAnmeldeart.Size = new System.Drawing.Size(537, 57);
            this.panelAnmeldeart.TabIndex = 2;
            //
            // lblFaAufnahmeartCode
            //
            this.lblFaAufnahmeartCode.Location = new System.Drawing.Point(5, 0);
            this.lblFaAufnahmeartCode.Name = "lblFaAufnahmeartCode";
            this.lblFaAufnahmeartCode.Size = new System.Drawing.Size(102, 24);
            this.lblFaAufnahmeartCode.TabIndex = 26;
            this.lblFaAufnahmeartCode.Text = "Anmeldeart";
            //
            // lblFaKontaktveranlasserCode
            //
            this.lblFaKontaktveranlasserCode.Location = new System.Drawing.Point(5, 30);
            this.lblFaKontaktveranlasserCode.Name = "lblFaKontaktveranlasserCode";
            this.lblFaKontaktveranlasserCode.Size = new System.Drawing.Size(102, 24);
            this.lblFaKontaktveranlasserCode.TabIndex = 25;
            this.lblFaKontaktveranlasserCode.Text = "Kontaktveranl.";
            //
            // edtFaKontaktveranlasserCode
            //
            this.edtFaKontaktveranlasserCode.DataMember = "FaKontaktveranlasserCode";
            this.edtFaKontaktveranlasserCode.DataSource = this.qryFaLeistung;
            this.edtFaKontaktveranlasserCode.Location = new System.Drawing.Point(113, 30);
            this.edtFaKontaktveranlasserCode.LOVName = "FaKontaktveranlasser";
            this.edtFaKontaktveranlasserCode.Name = "edtFaKontaktveranlasserCode";
            this.edtFaKontaktveranlasserCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaKontaktveranlasserCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaKontaktveranlasserCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaKontaktveranlasserCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaKontaktveranlasserCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaKontaktveranlasserCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaKontaktveranlasserCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaKontaktveranlasserCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaKontaktveranlasserCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaKontaktveranlasserCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaKontaktveranlasserCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFaKontaktveranlasserCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFaKontaktveranlasserCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaKontaktveranlasserCode.Properties.NullText = "";
            this.edtFaKontaktveranlasserCode.Properties.ShowFooter = false;
            this.edtFaKontaktveranlasserCode.Properties.ShowHeader = false;
            this.edtFaKontaktveranlasserCode.Size = new System.Drawing.Size(280, 24);
            this.edtFaKontaktveranlasserCode.TabIndex = 1;
            //
            // edtFaAufnahmeartCode
            //
            this.edtFaAufnahmeartCode.DataMember = "FaAufnahmeartCode";
            this.edtFaAufnahmeartCode.DataSource = this.qryFaLeistung;
            this.edtFaAufnahmeartCode.Location = new System.Drawing.Point(113, 0);
            this.edtFaAufnahmeartCode.LOVName = "FaAnmeldeart";
            this.edtFaAufnahmeartCode.Name = "edtFaAufnahmeartCode";
            this.edtFaAufnahmeartCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaAufnahmeartCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaAufnahmeartCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaAufnahmeartCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaAufnahmeartCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaAufnahmeartCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaAufnahmeartCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaAufnahmeartCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaAufnahmeartCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaAufnahmeartCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaAufnahmeartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFaAufnahmeartCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFaAufnahmeartCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaAufnahmeartCode.Properties.NullText = "";
            this.edtFaAufnahmeartCode.Properties.ShowFooter = false;
            this.edtFaAufnahmeartCode.Properties.ShowHeader = false;
            this.edtFaAufnahmeartCode.Size = new System.Drawing.Size(280, 24);
            this.edtFaAufnahmeartCode.TabIndex = 0;
            //
            // editGemeinde
            //
            this.editGemeinde.DataMember = "GemeindeCode";
            this.editGemeinde.DataSource = this.qryFaLeistung;
            this.editGemeinde.Location = new System.Drawing.Point(113, 480);
            this.editGemeinde.LOVName = "GemeindeSozialdienst";
            this.editGemeinde.Name = "editGemeinde";
            this.editGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.editGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.editGemeinde.Properties.Appearance.Options.UseFont = true;
            this.editGemeinde.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editGemeinde.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editGemeinde.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editGemeinde.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editGemeinde.Properties.NullText = "";
            this.editGemeinde.Properties.ShowFooter = false;
            this.editGemeinde.Properties.ShowHeader = false;
            this.editGemeinde.Size = new System.Drawing.Size(280, 24);
            this.editGemeinde.TabIndex = 500;
            //
            // kissLabel10
            //
            this.kissLabel10.ForeColor = System.Drawing.Color.Black;
            this.kissLabel10.Location = new System.Drawing.Point(5, 480);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(102, 24);
            this.kissLabel10.TabIndex = 501;
            this.kissLabel10.Text = "zust. Gemeinde";
            //
            // CtlFaBeratungsperiode
            //
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.editGemeinde);
            this.Controls.Add(this.kissLabel10);
            this.Controls.Add(this.panelAnmeldeart);
            this.Controls.Add(this.panelAbschluss);
            this.Controls.Add(this.lblSAR);
            this.Controls.Add(this.edtSAR);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Name = "CtlFaBeratungsperiode";
            this.Size = new System.Drawing.Size(692, 541);
            this.Load += new System.EventHandler(this.CtlFaBeratungsperiode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            this.panelAbschluss.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            this.panelAnmeldeart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFaAufnahmeartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaKontaktveranlasserCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaKontaktveranlasserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaKontaktveranlasserCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaAufnahmeartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaAufnahmeartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
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
            if (KissMsg.ShowQuestion("CtlFaBeratungsperiode", "FallverlaufWiederOeffnen", "Soll der geschlossene Fallverlauf wieder geöffnet werden ?"))
            {
                qryFaLeistung.CanUpdate = true;
                qryFaLeistung["DatumBis"] = DBNull.Value;
                qryFaLeistung.Post();
            }
        }

        private void CtlFaBeratungsperiode_Load(object sender, System.EventArgs e)
        {
            qryFaLeistung.Fill(FaLeistungID);

            SetEditMode();
        }

        private void qryFaLeistung_AfterPost(object sender, System.EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "FehlerBeimSpeichern", "Die Daten konnten nicht gespeichert werden.", KissMsgCode.MsgInfo));
            }

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            SetEditMode();
        }

        private void qryFaLeistung_BeforePost(object sender, System.EventArgs e)
        {
            Session.BeginTransaction();
            DBUtil.CheckNotNullField(edtDatumVon, KissMsg.GetMLMessage("CtlFaBeratungsperiode", "Eroeffnungsdatum", "Eröffnungsdatum"));

            if (qryFaLeistung.ColumnModified("DatumVon"))
            {
                int Count = (int)DBUtil.ExecuteScalarSQL(@"
                    select	count(*)
                    from	FaLeistung
                    where	BaPersonID = {0} and
                            ModulID = 2 and
                            {1} between DatumVon and DatumBis and
                            FaLeistungID <> {2}",
                    qryFaLeistung["BaPersonID"],
                    qryFaLeistung["DatumVon"],
                    FaLeistungID);

                if (Count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "UeberschneidungEroeffnungsdatum", "Das Eröffnungsdatum darf sich nicht mit einer anderen Fallführung überschneiden!", KissMsgCode.MsgInfo));
                }
            }

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                int Count = (int)DBUtil.ExecuteScalarSQL(@"
                    select	count(*)
                    from	FaPhase PHA
                    where	FaLeistungID = {0} and
                            DatumBis is null",
                    FaLeistungID);

                if (Count > 0)
                {
                    qryFaLeistung["DatumBis"] = DBNull.Value;
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "NichtAbeschlPhasen", "Fallabschluss nicht möglich. Es gibt noch nicht abgeschlossene Phasen!", KissMsgCode.MsgInfo));
                }

                //Kontrolle offene Pendenzen
                int countPendenzen = Utils.GetAnzahlOffenePendenzen(FaLeistungID);
                if (countPendenzen > 0)
                {
                    string Msg =
                        string.Format(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "OffenePendenzenVorhanden",
                                                           string.Format(
                                                               "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                                                               countPendenzen)));
                    KissMsg.ShowInfo(Msg);
                }

                Count = (int)DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(*)
                        FROM FaLeistung  FAL
                        LEFT JOIN FaPhase PHS ON PHS.FaLeistungID = FAL.FaLeistungID
                        WHERE FAL.FaLeistungID = {0}
                                AND {1} < PHS.DatumBis
                        ", FaLeistungID, qryFaLeistung["DatumBis"]);
                if (Count > 0)
                {
                    qryFaLeistung["DatumBis"] = DBNull.Value;
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "PhasenAbschlVorFallAbschl", "Fallabschluss nicht möglich. Das Fallabschluss liegt vor einem Phasenabschluss!", KissMsgCode.MsgInfo));
                }

                if ((int)qryFaLeistung["ModulID"] == 2)
                {
                    Count = (int)DBUtil.ExecuteScalarSQL(@"
                            SELECT COUNT(*)
                            FROM FaLeistung FAL
                            WHERE FAL.BaPersonID = {0}
                              AND FAL.ModulID <> 2
                              AND FAL.DatumBis is null",
                        qryFaLeistung["BaPersonID"]);
                    if (Count > 0)
                    {
                        qryFaLeistung["DatumBis"] = DBNull.Value;
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "AndereModuleOffen", "Die Fallführung kann nicht abgeschlossen werden, solange andere Module noch offen sind!", KissMsgCode.MsgInfo));
                    }
                }

                object[] parms = { qryFaLeistung["DatumBis"], qryFaLeistung["BaPersonID"] };
                //Gibt es Kategorien, die über den Fallabschluss hinaus gehen?
                Count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM FaKategorisierung WITH(READUNCOMMITTED)
                    WHERE BaPersonID = {1}
                    AND AbschlussDatum > {0}", parms);

                if (Count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "KategorieEnddatumUeberFallabschluss", "Es gibt Kategorien mit einem Enddatum nach dem Fallabschluss.", KissMsgCode.MsgInfo));
                }

                //Kategorien herausnehmen, welche das Anfangsdatum nach dem Fallabschlussdatum haben
                Count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM FaKategorisierung WITH(READUNCOMMITTED)
                    WHERE BaPersonID = {1}
                    AND Datum > {0}", parms);

                if (Count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "KategorieAnfangsdatumUeberFallabschluss", "Es gibt Kategorien mit einem Anfangsdatum nach dem Fallabschluss.", KissMsgCode.MsgInfo));
                }

                // Offene Kategorien schliessen
                var rc = DBUtil.ExecSQL(@"
                    UPDATE FaKategorisierung
                    SET Abschlussdatum = {0}
                    WHERE BaPersonID = {1}
                    AND Abschlussdatum IS NULL", parms);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungID)
        {
            this.lblTitel.Text = titleName;
            this.picTitel.Image = titleImage;
            this.FaLeistungID = faLeistungID;

            if (DBUtil.GetConfigBool(@"System\Fallfuehrung\ErweitereFallverlaufMaske", false))
            {
                panelAnmeldeart.Visible = true;
            }
            else
            {
                panelAnmeldeart.Visible = false;
                panelAbschluss.Top -= panelAnmeldeart.Height;
            }
        }

        #endregion

        #region Private Methods

        private void SetEditMode()
        {
            if (qryFaLeistung.Count == 0) return;

            bool MayRead = false;
            bool MayIns = false;
            bool MayUpd = false;
            bool MayDel = false;
            bool MayClose = false;
            bool MayReopen = false;

            DBUtil.GetFallRights((int)qryFaLeistung["FaLeistungID"], out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);

            if (MayClose)
            {
                bool open = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);
                bool archived = !DBUtil.IsEmpty(qryFaLeistung["FaLeistungArchivID"]);

                qryFaLeistung.CanUpdate = open;
                btnReopen.Visible = !open && !archived && MayReopen && DBUtil.UserHasRight("CtlFaPeriodeReopen");

                if (open)
                    edtDatumVon.EditMode = EditModeType.Normal;
                else
                    edtDatumVon.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                qryFaLeistung.CanUpdate = false; ;
                btnReopen.Visible = false;
                edtDatumVon.EditMode = EditModeType.ReadOnly;
            }
            qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate);
        }

        #endregion

        #endregion
    }
}