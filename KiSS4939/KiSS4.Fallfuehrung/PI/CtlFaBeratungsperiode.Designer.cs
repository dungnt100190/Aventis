using System;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Fallfuehrung.PI
{
    partial class CtlFaBeratungsperiode
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnReOpen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrund;
        private KiSS4.Gui.KissTextEdit edtAbteilung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissButtonEdit edtMitarbeiter;
        private KiSS4.Gui.KissLabel lblAbschluss;
        private KiSS4.Gui.KissLabel lblAbschlussGrund;
        private KiSS4.Gui.KissLabel lblAbteilung;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEroeffnung;
        private KiSS4.Gui.KissLabel lblMitarbeiter;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissRTFEdit memBemerkungen;
        private System.Windows.Forms.Panel panAbschlussGrund;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaLeistung;

        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaBeratungsperiode));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblEroeffnung = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.lblMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtMitarbeiter = new KiSS4.Gui.KissButtonEdit();
            this.lblAbteilung = new KiSS4.Gui.KissLabel();
            this.edtAbteilung = new KiSS4.Gui.KissTextEdit();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.panAbschlussGrund = new System.Windows.Forms.Panel();
            this.edtAbschlussGrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbschlussGrund = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.memBemerkungen = new KiSS4.Gui.KissRTFEdit();
            this.btnReOpen = new KiSS4.Gui.KissButton();
            this.edtDienstleistung = new KiSS4.Gui.KissLookUpEdit();
            this.lblDienstleistung = new KiSS4.Gui.KissLabel();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            this.panAbschlussGrund.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).BeginInit();
            this.SuspendLayout();
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 0;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(680, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Leistung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblEroeffnung
            // 
            this.lblEroeffnung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblEroeffnung.Location = new System.Drawing.Point(120, 38);
            this.lblEroeffnung.Name = "lblEroeffnung";
            this.lblEroeffnung.Size = new System.Drawing.Size(279, 16);
            this.lblEroeffnung.TabIndex = 1;
            this.lblEroeffnung.Text = "Eröffnung";
            this.lblEroeffnung.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(10, 59);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(104, 24);
            this.lblDatumVon.TabIndex = 2;
            this.lblDatumVon.Text = "Datum";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(120, 59);
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
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 3;
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            this.qryFaLeistung.PostCompleted += new System.EventHandler(this.qryFaLeistung_PostCompleted);
            // 
            // lblMitarbeiter
            // 
            this.lblMitarbeiter.Location = new System.Drawing.Point(10, 89);
            this.lblMitarbeiter.Name = "lblMitarbeiter";
            this.lblMitarbeiter.Size = new System.Drawing.Size(104, 24);
            this.lblMitarbeiter.TabIndex = 4;
            this.lblMitarbeiter.Text = "MA";
            this.lblMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtMitarbeiter
            // 
            this.edtMitarbeiter.DataMember = "Mitarbeiter";
            this.edtMitarbeiter.DataSource = this.qryFaLeistung;
            this.edtMitarbeiter.Location = new System.Drawing.Point(120, 89);
            this.edtMitarbeiter.Name = "edtMitarbeiter";
            this.edtMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMitarbeiter.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMitarbeiter.Size = new System.Drawing.Size(279, 24);
            this.edtMitarbeiter.TabIndex = 5;
            this.edtMitarbeiter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMitarbeiter_UserModifiedFld);
            this.edtMitarbeiter.EditValueChanged += new System.EventHandler(this.edtMitarbeiter_EditValueChanged);
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.Location = new System.Drawing.Point(10, 119);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(104, 24);
            this.lblAbteilung.TabIndex = 6;
            this.lblAbteilung.Text = "Abteilung";
            this.lblAbteilung.UseCompatibleTextRendering = true;
            // 
            // edtAbteilung
            // 
            this.edtAbteilung.DataMember = "Abteilung";
            this.edtAbteilung.DataSource = this.qryFaLeistung;
            this.edtAbteilung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbteilung.Location = new System.Drawing.Point(120, 119);
            this.edtAbteilung.Name = "edtAbteilung";
            this.edtAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbteilung.Properties.ReadOnly = true;
            this.edtAbteilung.Size = new System.Drawing.Size(279, 24);
            this.edtAbteilung.TabIndex = 7;
            this.edtAbteilung.TabStop = false;
            // 
            // lblAbschluss
            // 
            this.lblAbschluss.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAbschluss.Location = new System.Drawing.Point(120, 211);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(279, 16);
            this.lblAbschluss.TabIndex = 8;
            this.lblAbschluss.Text = "Abschluss";
            this.lblAbschluss.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(10, 230);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(104, 24);
            this.lblDatumBis.TabIndex = 9;
            this.lblDatumBis.Text = "Datum";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(120, 230);
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
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 10;
            this.edtDatumBis.EditValueChanged += new System.EventHandler(this.edtDatumBis_EditValueChanged);
            // 
            // panAbschlussGrund
            // 
            this.panAbschlussGrund.Controls.Add(this.edtAbschlussGrund);
            this.panAbschlussGrund.Controls.Add(this.lblAbschlussGrund);
            this.panAbschlussGrund.Location = new System.Drawing.Point(10, 260);
            this.panAbschlussGrund.Name = "panAbschlussGrund";
            this.panAbschlussGrund.Size = new System.Drawing.Size(651, 24);
            this.panAbschlussGrund.TabIndex = 11;
            // 
            // edtAbschlussGrund
            // 
            this.edtAbschlussGrund.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrund.DataSource = this.qryFaLeistung;
            this.edtAbschlussGrund.Location = new System.Drawing.Point(110, 0);
            this.edtAbschlussGrund.LOVName = "FaAbschlussGrund";
            this.edtAbschlussGrund.Name = "edtAbschlussGrund";
            this.edtAbschlussGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbschlussGrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrund.Properties.NullText = "";
            this.edtAbschlussGrund.Properties.ShowFooter = false;
            this.edtAbschlussGrund.Properties.ShowHeader = false;
            this.edtAbschlussGrund.Size = new System.Drawing.Size(380, 24);
            this.edtAbschlussGrund.TabIndex = 1;
            // 
            // lblAbschlussGrund
            // 
            this.lblAbschlussGrund.Location = new System.Drawing.Point(0, 0);
            this.lblAbschlussGrund.Name = "lblAbschlussGrund";
            this.lblAbschlussGrund.Size = new System.Drawing.Size(104, 24);
            this.lblAbschlussGrund.TabIndex = 0;
            this.lblAbschlussGrund.Text = "Abschlussgrund";
            this.lblAbschlussGrund.UseCompatibleTextRendering = true;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(10, 290);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(104, 24);
            this.lblBemerkungen.TabIndex = 12;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // memBemerkungen
            // 
            this.memBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkungen.BackColor = System.Drawing.Color.White;
            this.memBemerkungen.DataMember = "Bemerkung";
            this.memBemerkungen.DataSource = this.qryFaLeistung;
            this.memBemerkungen.Font = new System.Drawing.Font("Arial", 10F);
            this.memBemerkungen.Location = new System.Drawing.Point(120, 290);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Size = new System.Drawing.Size(541, 267);
            this.memBemerkungen.TabIndex = 13;
            // 
            // btnReOpen
            // 
            this.btnReOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReOpen.Location = new System.Drawing.Point(460, 563);
            this.btnReOpen.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.btnReOpen.Name = "btnReOpen";
            this.btnReOpen.Size = new System.Drawing.Size(201, 24);
            this.btnReOpen.TabIndex = 14;
            this.btnReOpen.Text = "Fallverlauf &wieder öffnen";
            this.btnReOpen.UseCompatibleTextRendering = true;
            this.btnReOpen.UseVisualStyleBackColor = false;
            this.btnReOpen.Click += new System.EventHandler(this.btnReOpen_Click);
            // 
            // edtDienstleistung
            // 
            this.edtDienstleistung.AllowNull = false;
            this.edtDienstleistung.DataMember = "FaModulDienstleistungenCode";
            this.edtDienstleistung.DataSource = this.qryFaLeistung;
            this.edtDienstleistung.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDienstleistung.Location = new System.Drawing.Point(120, 149);
            this.edtDienstleistung.LOVFilter = "WD";
            this.edtDienstleistung.LOVName = "FaModulDienstleistungen";
            this.edtDienstleistung.Name = "edtDienstleistung";
            this.edtDienstleistung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDienstleistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDienstleistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDienstleistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDienstleistung.Properties.Appearance.Options.UseFont = true;
            this.edtDienstleistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDienstleistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDienstleistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDienstleistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDienstleistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDienstleistung.Properties.NullText = "";
            this.edtDienstleistung.Properties.ShowFooter = false;
            this.edtDienstleistung.Properties.ShowHeader = false;
            this.edtDienstleistung.Size = new System.Drawing.Size(279, 24);
            this.edtDienstleistung.TabIndex = 2;
            // 
            // lblDienstleistung
            // 
            this.lblDienstleistung.Location = new System.Drawing.Point(10, 149);
            this.lblDienstleistung.Name = "lblDienstleistung";
            this.lblDienstleistung.Size = new System.Drawing.Size(104, 24);
            this.lblDienstleistung.TabIndex = 15;
            this.lblDienstleistung.Text = "Dienstleistung";
            this.lblDienstleistung.UseCompatibleTextRendering = true;
            // 
            // CtlFaBeratungsperiode
            // 
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.lblDienstleistung);
            this.Controls.Add(this.edtDienstleistung);
            this.Controls.Add(this.btnReOpen);
            this.Controls.Add(this.memBemerkungen);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.panAbschlussGrund);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblAbschluss);
            this.Controls.Add(this.edtAbteilung);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.edtMitarbeiter);
            this.Controls.Add(this.lblMitarbeiter);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblEroeffnung);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlFaBeratungsperiode";
            this.Size = new System.Drawing.Size(722, 596);
            this.Load += new System.EventHandler(this.CtlFaBeratungsperiode_Load);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            this.panAbschlussGrund.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).EndInit();
            this.ResumeLayout(false);

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
                if ((components != null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        private KissLabel lblDienstleistung;
        private KissLookUpEdit edtDienstleistung;
    }
}