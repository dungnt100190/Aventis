using System;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmProzess.
    /// </summary>
    public class CtlVmProzess : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faLeistungID = 0;
        private bool _leistungIsActive;
        private KiSS4.Gui.KissButton btnReopen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrundCode;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtGemeindeCode;
        private KiSS4.Gui.KissTextEdit edtSAR;
        private KiSS4.Gui.KissLookUpEdit edtVmAuftragCode;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel lblAbschlussGrundCode;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblGemeindeCode;
        private KiSS4.Gui.KissLabel lblSAR;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblVmAuftragCode;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaLeistung;

        #endregion

        #endregion

        #region Constructors

        public CtlVmProzess()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmProzess));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbschlussGrundCode = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSAR = new KiSS4.Gui.KissTextEdit();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.lblVmAuftragCode = new KiSS4.Gui.KissLabel();
            this.edtVmAuftragCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtGemeindeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblGemeindeCode = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmAuftragCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmAuftragCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmAuftragCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeindeCode)).BeginInit();
            this.SuspendLayout();
            //
            // qryFaLeistung
            //
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.IsIdentityInsert = false;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(5, 80);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblDatumVon.TabIndex = 0;
            this.lblDatumVon.Text = "Datum";
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtDatumVon.Location = new System.Drawing.Point(90, 80);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(89, 24);
            this.edtDatumVon.TabIndex = 0;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtDatumBis.Location = new System.Drawing.Point(90, 200);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(89, 24);
            this.edtDatumBis.TabIndex = 3;
            //
            // edtAbschlussGrundCode
            //
            this.edtAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrundCode.DataSource = this.qryFaLeistung;
            this.edtAbschlussGrundCode.Location = new System.Drawing.Point(90, 230);
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrundCode.Properties.NullText = "";
            this.edtAbschlussGrundCode.Properties.ShowFooter = false;
            this.edtAbschlussGrundCode.Properties.ShowHeader = false;
            this.edtAbschlussGrundCode.Size = new System.Drawing.Size(432, 24);
            this.edtAbschlussGrundCode.TabIndex = 4;
            //
            // lblAbschlussGrundCode
            //
            this.lblAbschlussGrundCode.Location = new System.Drawing.Point(5, 230);
            this.lblAbschlussGrundCode.Name = "lblAbschlussGrundCode";
            this.lblAbschlussGrundCode.Size = new System.Drawing.Size(70, 24);
            this.lblAbschlussGrundCode.TabIndex = 7;
            this.lblAbschlussGrundCode.Text = "Grund";
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(5, 260);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(66, 24);
            this.lblBemerkung.TabIndex = 8;
            this.lblBemerkung.Text = "Bemerkung";
            //
            // kissLabel4
            //
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel4.Location = new System.Drawing.Point(90, 50);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(100, 16);
            this.kissLabel4.TabIndex = 9;
            this.kissLabel4.Text = "Eröffnung";
            //
            // kissLabel5
            //
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel5.Location = new System.Drawing.Point(90, 170);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(100, 16);
            this.kissLabel5.TabIndex = 10;
            this.kissLabel5.Text = "Abschluss";
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
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
            // lblDatumBis
            //
            this.lblDatumBis.Location = new System.Drawing.Point(5, 200);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(70, 24);
            this.lblDatumBis.TabIndex = 14;
            this.lblDatumBis.Text = "Datum";
            //
            // edtSAR
            //
            this.edtSAR.DataMember = "SAR";
            this.edtSAR.DataSource = this.qryFaLeistung;
            this.edtSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSAR.Location = new System.Drawing.Point(90, 110);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSAR.Properties.ReadOnly = true;
            this.edtSAR.Size = new System.Drawing.Size(432, 24);
            this.edtSAR.TabIndex = 2;
            //
            // edtBemerkung
            //
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaLeistung;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBemerkung.Location = new System.Drawing.Point(90, 260);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(432, 134);
            this.edtBemerkung.TabIndex = 5;
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(6, 110);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(70, 24);
            this.lblSAR.TabIndex = 17;
            this.lblSAR.Text = "SAR";
            //
            // btnReopen
            //
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(90, 400);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(90, 24);
            this.btnReopen.TabIndex = 6;
            this.btnReopen.Text = "wieder öffnen";
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            //
            // lblVmAuftragCode
            //
            this.lblVmAuftragCode.Location = new System.Drawing.Point(203, 80);
            this.lblVmAuftragCode.Name = "lblVmAuftragCode";
            this.lblVmAuftragCode.Size = new System.Drawing.Size(40, 24);
            this.lblVmAuftragCode.TabIndex = 21;
            this.lblVmAuftragCode.Text = "Auftrag";
            this.lblVmAuftragCode.Visible = false;
            //
            // edtVmAuftragCode
            //
            this.edtVmAuftragCode.DataMember = "VmAuftragCode";
            this.edtVmAuftragCode.DataSource = this.qryFaLeistung;
            this.edtVmAuftragCode.Location = new System.Drawing.Point(256, 80);
            this.edtVmAuftragCode.LOVName = "VmAuftrag";
            this.edtVmAuftragCode.Name = "edtVmAuftragCode";
            this.edtVmAuftragCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmAuftragCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmAuftragCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmAuftragCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmAuftragCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmAuftragCode.Properties.Appearance.Options.UseFont = true;
            this.edtVmAuftragCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVmAuftragCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmAuftragCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVmAuftragCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVmAuftragCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVmAuftragCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVmAuftragCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmAuftragCode.Properties.NullText = "";
            this.edtVmAuftragCode.Properties.ShowFooter = false;
            this.edtVmAuftragCode.Properties.ShowHeader = false;
            this.edtVmAuftragCode.Size = new System.Drawing.Size(256, 24);
            this.edtVmAuftragCode.TabIndex = 1;
            this.edtVmAuftragCode.Visible = false;
            //
            // edtGemeindeCode
            //
            this.edtGemeindeCode.DataMember = "GemeindeCode";
            this.edtGemeindeCode.DataSource = this.qryFaLeistung;
            this.edtGemeindeCode.Location = new System.Drawing.Point(90, 430);
            this.edtGemeindeCode.LOVFilter = "(Value3 IS NULL OR \',\' + Value3 + \',\' LIKE \'%,V,%\')";
            this.edtGemeindeCode.LOVFilterWhereAppend = true;
            this.edtGemeindeCode.LOVName = "GemeindeSozialdienst";
            this.edtGemeindeCode.Name = "edtGemeindeCode";
            this.edtGemeindeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGemeindeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGemeindeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseFont = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGemeindeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGemeindeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGemeindeCode.Properties.NullText = "";
            this.edtGemeindeCode.Properties.ShowFooter = false;
            this.edtGemeindeCode.Properties.ShowHeader = false;
            this.edtGemeindeCode.Size = new System.Drawing.Size(280, 24);
            this.edtGemeindeCode.TabIndex = 502;
            //
            // lblGemeindeCode
            //
            this.lblGemeindeCode.ForeColor = System.Drawing.Color.Black;
            this.lblGemeindeCode.Location = new System.Drawing.Point(5, 430);
            this.lblGemeindeCode.Name = "lblGemeindeCode";
            this.lblGemeindeCode.Size = new System.Drawing.Size(126, 24);
            this.lblGemeindeCode.TabIndex = 503;
            this.lblGemeindeCode.Text = "zust. Gemeinde";
            //
            // CtlVmProzess
            //
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.AutoRefresh = false;
            this.Controls.Add(this.edtGemeindeCode);
            this.Controls.Add(this.lblGemeindeCode);
            this.Controls.Add(this.lblVmAuftragCode);
            this.Controls.Add(this.edtVmAuftragCode);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.lblSAR);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.edtSAR);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblAbschlussGrundCode);
            this.Controls.Add(this.edtAbschlussGrundCode);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Name = "CtlVmProzess";
            this.Size = new System.Drawing.Size(679, 487);
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmAuftragCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmAuftragCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmAuftragCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeindeCode)).EndInit();
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
            if (KissMsg.ShowQuestion(this.Name, "FallWiederOeffnen", "Soll der geschlossene Fall wieder geöffnet werden ?"))
            {
                qryFaLeistung["DatumBis"] = DBNull.Value;
                qryFaLeistung.Post();
            }
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            if (_leistungIsActive && !DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                // nach dem Abschliessen eines Falles soll der Tree korrigiert werden
                _leistungIsActive = false;
                CloseAllBarauszahlungAuftrag(_faLeistungID, Convert.ToDateTime(qryFaLeistung["DatumBis"]));
                RefreshTree();
            }

            if (!_leistungIsActive && DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                // nach dem Neueröffnen eines Falles soll der Tree korrigiert werden
                _leistungIsActive = true;
                RefreshTree();
            }

            SetEditMode();
        }

        private void qryFaLeistung_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, KissMsg.GetMLMessage(this.Name, "Eroeffnungsdatum", "Eröffnungsdatum"));

            // falls DatumBis erfasst, muss es grösser sein als DatumVon
            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) &&
                (DateTime)qryFaLeistung["DatumVon"] > (DateTime)qryFaLeistung["DatumBis"])
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        this.Name,
                        "EroeffDatNachAbschlussDat",
                        "Das Eröffnungsdatum darf nicht nach dem Abschlussdatum sein!",
                        KissMsgCode.MsgInfo
                    )
                );
            }

            //Kontrolle offene Pendenzen
            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]))
            {
                int countPendenzen = Utils.GetAnzahlOffenePendenzen(_faLeistungID);
                if (countPendenzen > 0)
                {
                    string Msg =
                        string.Format(KissMsg.GetMLMessage("CtlVmProzess", "OffenePendenzenVorhanden",
                                                           string.Format(
                                                               "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                                                               countPendenzen)));
                    KissMsg.ShowInfo(Msg);
                }
            }

            //prüfen, ob DatumVon in eine andere Fallperiode fällt
            int Count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM FaLeistung A
                  INNER JOIN FaLeistung B ON B.BaPersonID = A.BaPersonID
                    AND B.ModulID = 5
                    AND B.FaProzessCode = A.FaProzessCode
                    AND B.FaLeistungID <> A.FaLeistungID
                    AND {0} BETWEEN B.DatumVon AND B.DatumBis
                WHERE A.FaLeistungID = {1}",
                qryFaLeistung["DatumVon"],
                _faLeistungID);

            if (Count > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        this.Name,
                        "UeberschneidungMitFall",
                        "Das Eröffnungsdatum darf nicht mit einem anderen Fall überschneiden!",
                        KissMsgCode.MsgInfo
                    )
                );
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string TitleName, Image TitleImage, int FaLeistungID)
        {
            lblTitel.Text = TitleName;
            picTitel.Image = TitleImage;
            _faLeistungID = FaLeistungID;

            qryFaLeistung.Fill(FaLeistungID);

            _leistungIsActive = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);

            string LOVName = null;

            if (!DBUtil.IsEmpty(qryFaLeistung["FaProzessCode"]))
            {
                lblVmAuftragCode.Visible = false;
                edtVmAuftragCode.Visible = false;

                switch ((int)qryFaLeistung["FaProzessCode"])
                {
                    case 501:
                        LOVName = "VmMassnahmeAbschlussgrund";
                        break;

                    case 502:
                        LOVName = "VmVaterschaftAbschlussgrund";
                        break;

                    case 503:
                        LOVName = "VmErbschaftAbschlussgrund";
                        break;

                    case 504:
                        LOVName = "VmPflegekindAbschlussgrund";
                        break;

                    case 505:
                        lblVmAuftragCode.Visible = true;
                        edtVmAuftragCode.Visible = true;
                        LOVName = "VmAuftragAbschlussgrund";
                        break;
                }

                if ((int)DBUtil.ExecuteScalarSQL("SELECT COUNT(*) FROM dbo.XLOV WHERE LOVName = {0}", LOVName) > 0)
                {
                    edtAbschlussGrundCode.LOVName = LOVName;
                }
                else
                {
                    edtAbschlussGrundCode.LOVName = "Abschlussgrund";
                }
            }

            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.GemeindeCode]) && DBUtil.IsEmpty(edtGemeindeCode.EditValue) && qryFaLeistung.CanUpdate)
            {
                //only 1 item in a mandatory field --> set value directly
                var queryGemeinde = ((SqlQuery)edtGemeindeCode.Properties.DataSource);

                if (edtGemeindeCode.AllowNull)
                {
                    if (queryGemeinde.Count == 2)
                    {
                        //Null-Eintrag ignorieren
                        queryGemeinde.RowModified = false;
                        queryGemeinde.Next();
                        qryFaLeistung[DBO.FaLeistung.GemeindeCode] = queryGemeinde["Code"];
                    }
                    else if (qryFaLeistung.CanUpdate)
                    {
                        qryFaLeistung.RowModified = true;
                    }
                }
                else
                {
                    if (queryGemeinde.Count == 1)
                    {
                        qryFaLeistung[DBO.FaLeistung.GemeindeCode] = queryGemeinde["Code"];
                    }
                    else if (qryFaLeistung.CanUpdate)
                    {
                        qryFaLeistung.RowModified = true;
                    }
                }
            }

            SetEditMode();
        }

        public override bool OnSaveData()
        {
            return qryFaLeistung.Post();
        }

        #endregion

        #region Private Methods

        private void CloseAllBarauszahlungAuftrag(int faLeistungID, DateTime datumBis)
        {
            int affectedRows = DBUtil.ExecSQLThrowingException(@"
                UPDATE dbo.FbBarauszahlungAuftrag
                SET DatumBis = CASE WHEN {1} >= DatumVon THEN {1} ELSE GETDATE() END
                WHERE FaLeistungID = {0}
                AND DatumBis IS NULL",
                faLeistungID,
                datumBis
            );
        }

        private void RefreshTree()
        {
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void SetEditMode()
        {
            if (qryFaLeistung.Count == 0)
            {
                return;
            }

            // nur owner oder admin darf abschliessen
            if (Session.User.IsUserAdmin || (int)qryFaLeistung["UserID"] == Session.User.UserID)
            {
                bool open = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);
                bool archived = !DBUtil.IsEmpty(qryFaLeistung["FaLeistungArchivID"]);

                qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate && open);
                btnReopen.Visible = !open && !archived;
            }
            else
            {
                qryFaLeistung.EnableBoundFields(false);
                btnReopen.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}