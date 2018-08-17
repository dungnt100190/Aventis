using System;
using System.Drawing;

using KiSS4.DB;

namespace KiSS4.Arbeit
{
    public class CtlKaInizioUebersicht : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        bool MayClose = false;
        bool MayDel = false;
        bool MayIns = false;
        bool MayRead = false;
        bool MayReopen = false;
        bool MayUpd = false;
        private int baPersonID = -1;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrund;
        private KiSS4.Gui.KissLookUpEdit edtAnmeldungDurch;
        private KiSS4.Gui.KissDateEdit edtAnmeldungEingegangen;
        private KiSS4.Gui.KissLookUpEdit edtEmpfehlungInizio;
        private KiSS4.Gui.KissDateEdit edtMappeVerschickt;
        private KiSS4.Gui.KissLookUpEdit edtSchulabschluss;
        private int faLeistungID = -1;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lblAbschlussPhase1;
        private KiSS4.Gui.KissLabel lblAbschlussgrund;
        private KiSS4.Gui.KissLabel lblAnmeldungDurch;
        private KiSS4.Gui.KissLabel lblAnmeldungEingegangen;
        private KiSS4.Dokument.KissDocumentButton lblBegleitbrief;
        private KiSS4.Dokument.KissDocumentButton lblEinladungErstgespraech;
        private KiSS4.Gui.KissLabel lblEmpfehlungInizio;
        private KiSS4.Gui.KissLabel lblMappeVerschickt;
        private KiSS4.Gui.KissLabel lblSchulabschluss;
        private KiSS4.Gui.KissLabel lblTitle;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryInizioUebersicht;

        #endregion

        #endregion

        #region Constructors

        public CtlKaInizioUebersicht()
        {
            this.InitializeComponent();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaInizioUebersicht));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblMappeVerschickt = new KiSS4.Gui.KissLabel();
            this.edtMappeVerschickt = new KiSS4.Gui.KissDateEdit();
            this.qryInizioUebersicht = new KiSS4.DB.SqlQuery(this.components);
            this.lblAnmeldungEingegangen = new KiSS4.Gui.KissLabel();
            this.edtAnmeldungEingegangen = new KiSS4.Gui.KissDateEdit();
            this.lblAnmeldungDurch = new KiSS4.Gui.KissLabel();
            this.edtAnmeldungDurch = new KiSS4.Gui.KissLookUpEdit();
            this.lblSchulabschluss = new KiSS4.Gui.KissLabel();
            this.edtSchulabschluss = new KiSS4.Gui.KissLookUpEdit();
            this.lblEmpfehlungInizio = new KiSS4.Gui.KissLabel();
            this.edtEmpfehlungInizio = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbschlussPhase1 = new KiSS4.Gui.KissLabel();
            this.lblAbschlussgrund = new KiSS4.Gui.KissLabel();
            this.lblBegleitbrief = new KiSS4.Dokument.KissDocumentButton();
            this.lblEinladungErstgespraech = new KiSS4.Dokument.KissDocumentButton();
            this.edtAbschlussGrund = new KiSS4.Gui.KissLookUpEdit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMappeVerschickt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMappeVerschickt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioUebersicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnmeldungEingegangen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnmeldungEingegangen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnmeldungDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnmeldungDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnmeldungDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchulabschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchulabschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchulabschluss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfehlungInizio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfehlungInizio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfehlungInizio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussPhase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(618, 40);
            this.pnTitle.TabIndex = 0;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ka_Inizio_Übersicht";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // lblMappeVerschickt
            // 
            this.lblMappeVerschickt.Location = new System.Drawing.Point(10, 50);
            this.lblMappeVerschickt.Name = "lblMappeVerschickt";
            this.lblMappeVerschickt.Size = new System.Drawing.Size(124, 24);
            this.lblMappeVerschickt.TabIndex = 1;
            this.lblMappeVerschickt.Text = "Mappe verschickt";
            this.lblMappeVerschickt.UseCompatibleTextRendering = true;
            // 
            // edtMappeVerschickt
            // 
            this.edtMappeVerschickt.DataMember = "MappeVerschickt";
            this.edtMappeVerschickt.DataSource = this.qryInizioUebersicht;
            this.edtMappeVerschickt.EditValue = null;
            this.edtMappeVerschickt.Location = new System.Drawing.Point(150, 50);
            this.edtMappeVerschickt.Name = "edtMappeVerschickt";
            this.edtMappeVerschickt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMappeVerschickt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMappeVerschickt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMappeVerschickt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMappeVerschickt.Properties.Appearance.Options.UseBackColor = true;
            this.edtMappeVerschickt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMappeVerschickt.Properties.Appearance.Options.UseFont = true;
            this.edtMappeVerschickt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtMappeVerschickt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtMappeVerschickt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtMappeVerschickt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMappeVerschickt.Properties.ShowToday = false;
            this.edtMappeVerschickt.Size = new System.Drawing.Size(120, 24);
            this.edtMappeVerschickt.TabIndex = 2;
            // 
            // qryInizioUebersicht
            // 
            this.qryInizioUebersicht.CanUpdate = true;
            this.qryInizioUebersicht.HostControl = this;
            this.qryInizioUebersicht.IsIdentityInsert = false;
            this.qryInizioUebersicht.SelectStatement = "SELECT INI.*\r\nFROM KaInizio INI\r\nWHERE INI.FaLeistungID = {0}";
            this.qryInizioUebersicht.TableName = "KaInizio";
            // 
            // lblAnmeldungEingegangen
            // 
            this.lblAnmeldungEingegangen.Location = new System.Drawing.Point(10, 80);
            this.lblAnmeldungEingegangen.Name = "lblAnmeldungEingegangen";
            this.lblAnmeldungEingegangen.Size = new System.Drawing.Size(134, 24);
            this.lblAnmeldungEingegangen.TabIndex = 3;
            this.lblAnmeldungEingegangen.Text = "Anmeldung eingegangen";
            this.lblAnmeldungEingegangen.UseCompatibleTextRendering = true;
            // 
            // edtAnmeldungEingegangen
            // 
            this.edtAnmeldungEingegangen.DataMember = "AnmeldungEingegangen";
            this.edtAnmeldungEingegangen.DataSource = this.qryInizioUebersicht;
            this.edtAnmeldungEingegangen.EditValue = null;
            this.edtAnmeldungEingegangen.Location = new System.Drawing.Point(150, 80);
            this.edtAnmeldungEingegangen.Name = "edtAnmeldungEingegangen";
            this.edtAnmeldungEingegangen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnmeldungEingegangen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnmeldungEingegangen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnmeldungEingegangen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnmeldungEingegangen.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnmeldungEingegangen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnmeldungEingegangen.Properties.Appearance.Options.UseFont = true;
            this.edtAnmeldungEingegangen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAnmeldungEingegangen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnmeldungEingegangen.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAnmeldungEingegangen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnmeldungEingegangen.Properties.ShowToday = false;
            this.edtAnmeldungEingegangen.Size = new System.Drawing.Size(120, 24);
            this.edtAnmeldungEingegangen.TabIndex = 4;
            // 
            // lblAnmeldungDurch
            // 
            this.lblAnmeldungDurch.Location = new System.Drawing.Point(10, 110);
            this.lblAnmeldungDurch.Name = "lblAnmeldungDurch";
            this.lblAnmeldungDurch.Size = new System.Drawing.Size(124, 24);
            this.lblAnmeldungDurch.TabIndex = 5;
            this.lblAnmeldungDurch.Text = "Anmeldung durch";
            this.lblAnmeldungDurch.UseCompatibleTextRendering = true;
            // 
            // edtAnmeldungDurch
            // 
            this.edtAnmeldungDurch.DataMember = "AnmeldungDurchCode";
            this.edtAnmeldungDurch.DataSource = this.qryInizioUebersicht;
            this.edtAnmeldungDurch.Location = new System.Drawing.Point(150, 110);
            this.edtAnmeldungDurch.LOVName = "KaInizioAnmeldungDurch";
            this.edtAnmeldungDurch.Name = "edtAnmeldungDurch";
            this.edtAnmeldungDurch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnmeldungDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnmeldungDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnmeldungDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnmeldungDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnmeldungDurch.Properties.Appearance.Options.UseFont = true;
            this.edtAnmeldungDurch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAnmeldungDurch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnmeldungDurch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAnmeldungDurch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAnmeldungDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAnmeldungDurch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAnmeldungDurch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnmeldungDurch.Properties.NullText = "";
            this.edtAnmeldungDurch.Properties.ShowFooter = false;
            this.edtAnmeldungDurch.Properties.ShowHeader = false;
            this.edtAnmeldungDurch.Size = new System.Drawing.Size(315, 24);
            this.edtAnmeldungDurch.TabIndex = 6;
            // 
            // lblSchulabschluss
            // 
            this.lblSchulabschluss.Location = new System.Drawing.Point(10, 140);
            this.lblSchulabschluss.Name = "lblSchulabschluss";
            this.lblSchulabschluss.Size = new System.Drawing.Size(124, 24);
            this.lblSchulabschluss.TabIndex = 7;
            this.lblSchulabschluss.Text = "Schulabschluss";
            this.lblSchulabschluss.UseCompatibleTextRendering = true;
            // 
            // edtSchulabschluss
            // 
            this.edtSchulabschluss.DataMember = "SchulabschlussCode";
            this.edtSchulabschluss.DataSource = this.qryInizioUebersicht;
            this.edtSchulabschluss.Location = new System.Drawing.Point(150, 140);
            this.edtSchulabschluss.LOVName = "KaInizioSchulabschluss";
            this.edtSchulabschluss.Name = "edtSchulabschluss";
            this.edtSchulabschluss.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchulabschluss.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchulabschluss.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchulabschluss.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchulabschluss.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchulabschluss.Properties.Appearance.Options.UseFont = true;
            this.edtSchulabschluss.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSchulabschluss.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchulabschluss.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSchulabschluss.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSchulabschluss.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSchulabschluss.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSchulabschluss.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchulabschluss.Properties.NullText = "";
            this.edtSchulabschluss.Properties.ShowFooter = false;
            this.edtSchulabschluss.Properties.ShowHeader = false;
            this.edtSchulabschluss.Size = new System.Drawing.Size(315, 24);
            this.edtSchulabschluss.TabIndex = 8;
            // 
            // lblEmpfehlungInizio
            // 
            this.lblEmpfehlungInizio.Location = new System.Drawing.Point(10, 170);
            this.lblEmpfehlungInizio.Name = "lblEmpfehlungInizio";
            this.lblEmpfehlungInizio.Size = new System.Drawing.Size(124, 24);
            this.lblEmpfehlungInizio.TabIndex = 9;
            this.lblEmpfehlungInizio.Text = "Empfehlung Inizio";
            this.lblEmpfehlungInizio.UseCompatibleTextRendering = true;
            // 
            // edtEmpfehlungInizio
            // 
            this.edtEmpfehlungInizio.DataMember = "EmpfehlungInizioCode";
            this.edtEmpfehlungInizio.DataSource = this.qryInizioUebersicht;
            this.edtEmpfehlungInizio.Location = new System.Drawing.Point(150, 170);
            this.edtEmpfehlungInizio.LOVName = "KaBerufsausbildungTyp";
            this.edtEmpfehlungInizio.Name = "edtEmpfehlungInizio";
            this.edtEmpfehlungInizio.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEmpfehlungInizio.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmpfehlungInizio.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmpfehlungInizio.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmpfehlungInizio.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmpfehlungInizio.Properties.Appearance.Options.UseFont = true;
            this.edtEmpfehlungInizio.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEmpfehlungInizio.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmpfehlungInizio.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEmpfehlungInizio.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEmpfehlungInizio.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEmpfehlungInizio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEmpfehlungInizio.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEmpfehlungInizio.Properties.NullText = "";
            this.edtEmpfehlungInizio.Properties.ShowFooter = false;
            this.edtEmpfehlungInizio.Properties.ShowHeader = false;
            this.edtEmpfehlungInizio.Size = new System.Drawing.Size(315, 24);
            this.edtEmpfehlungInizio.TabIndex = 10;
            // 
            // lblAbschlussPhase1
            // 
            this.lblAbschlussPhase1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblAbschlussPhase1.Location = new System.Drawing.Point(10, 233);
            this.lblAbschlussPhase1.Name = "lblAbschlussPhase1";
            this.lblAbschlussPhase1.Size = new System.Drawing.Size(133, 16);
            this.lblAbschlussPhase1.TabIndex = 11;
            this.lblAbschlussPhase1.Text = "Abschluss Phase 1";
            this.lblAbschlussPhase1.UseCompatibleTextRendering = true;
            // 
            // lblAbschlussgrund
            // 
            this.lblAbschlussgrund.Location = new System.Drawing.Point(10, 257);
            this.lblAbschlussgrund.Name = "lblAbschlussgrund";
            this.lblAbschlussgrund.Size = new System.Drawing.Size(124, 24);
            this.lblAbschlussgrund.TabIndex = 12;
            this.lblAbschlussgrund.Text = "Abschluss Phase 1, weil";
            this.lblAbschlussgrund.UseCompatibleTextRendering = true;
            // 
            // lblBegleitbrief
            // 
            this.lblBegleitbrief.Context = "KaInizioUebersichtBegleitbrief";
            this.lblBegleitbrief.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.lblBegleitbrief.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBegleitbrief.Image = ((System.Drawing.Image)(resources.GetObject("lblBegleitbrief.Image")));
            this.lblBegleitbrief.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBegleitbrief.Location = new System.Drawing.Point(331, 50);
            this.lblBegleitbrief.Name = "lblBegleitbrief";
            this.lblBegleitbrief.Size = new System.Drawing.Size(100, 24);
            this.lblBegleitbrief.TabIndex = 14;
            this.lblBegleitbrief.Text = "Begleitbrief";
            this.lblBegleitbrief.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBegleitbrief.UseCompatibleTextRendering = true;
            this.lblBegleitbrief.UseVisualStyleBackColor = false;
            // 
            // lblEinladungErstgespraech
            // 
            this.lblEinladungErstgespraech.Context = "KaInizioUebersichtErstgespraech";
            this.lblEinladungErstgespraech.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.lblEinladungErstgespraech.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEinladungErstgespraech.Image = ((System.Drawing.Image)(resources.GetObject("lblEinladungErstgespraech.Image")));
            this.lblEinladungErstgespraech.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEinladungErstgespraech.Location = new System.Drawing.Point(442, 50);
            this.lblEinladungErstgespraech.Name = "lblEinladungErstgespraech";
            this.lblEinladungErstgespraech.Size = new System.Drawing.Size(173, 24);
            this.lblEinladungErstgespraech.TabIndex = 15;
            this.lblEinladungErstgespraech.Text = "Einladung Erstgespräch";
            this.lblEinladungErstgespraech.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEinladungErstgespraech.UseCompatibleTextRendering = true;
            this.lblEinladungErstgespraech.UseVisualStyleBackColor = false;
            // 
            // edtAbschlussGrund
            // 
            this.edtAbschlussGrund.DataMember = "AbschlussPhaseCode";
            this.edtAbschlussGrund.DataSource = this.qryInizioUebersicht;
            this.edtAbschlussGrund.Location = new System.Drawing.Point(150, 256);
            this.edtAbschlussGrund.LOVName = "KaInizioAbschlussPhase1";
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAbschlussGrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrund.Properties.NullText = "";
            this.edtAbschlussGrund.Properties.ShowFooter = false;
            this.edtAbschlussGrund.Properties.ShowHeader = false;
            this.edtAbschlussGrund.Size = new System.Drawing.Size(315, 24);
            this.edtAbschlussGrund.TabIndex = 16;
            // 
            // CtlKaInizioUebersicht
            // 
            this.ActiveSQLQuery = this.qryInizioUebersicht;
            this.AutoScroll = true;
            this.Controls.Add(this.edtAbschlussGrund);
            this.Controls.Add(this.lblEinladungErstgespraech);
            this.Controls.Add(this.lblBegleitbrief);
            this.Controls.Add(this.lblAbschlussgrund);
            this.Controls.Add(this.lblAbschlussPhase1);
            this.Controls.Add(this.edtEmpfehlungInizio);
            this.Controls.Add(this.lblEmpfehlungInizio);
            this.Controls.Add(this.edtSchulabschluss);
            this.Controls.Add(this.lblSchulabschluss);
            this.Controls.Add(this.edtAnmeldungDurch);
            this.Controls.Add(this.lblAnmeldungDurch);
            this.Controls.Add(this.edtAnmeldungEingegangen);
            this.Controls.Add(this.lblAnmeldungEingegangen);
            this.Controls.Add(this.edtMappeVerschickt);
            this.Controls.Add(this.lblMappeVerschickt);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaInizioUebersicht";
            this.Size = new System.Drawing.Size(618, 481);
            this.Load += new System.EventHandler(this.CtlKaInizioUebersicht_Load);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMappeVerschickt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMappeVerschickt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioUebersicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnmeldungEingegangen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnmeldungEingegangen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnmeldungDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnmeldungDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnmeldungDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchulabschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchulabschluss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchulabschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfehlungInizio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfehlungInizio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfehlungInizio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussPhase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).EndInit();
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

        #region EventHandlers

        private void CtlKaInizioUebersicht_Load(object sender, EventArgs e)
        {
            if (KaUtil.GetSichtbarSDFlag(this.baPersonID) == 1)
            {
                qryInizioUebersicht.EnableBoundFields(false);
                lblBegleitbrief.Enabled = false;
                lblEinladungErstgespraech.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return faLeistungID;
                case "BAPERSONID":
                    return (int)DBUtil.ExecuteScalarSQL("SELECT BaPersonID FROM dbo.FaLeistung WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}", faLeistungID);
                case "KAINIZIOID":
                    return qryInizioUebersicht["KaInizioID"];
                case "OWNERUSERID":
                    return (int) DBUtil.ExecuteScalarSQL("SELECT UserID FROM dbo.FaLeistung WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}", faLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        // ComponentName: qryInizioUebersicht
        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            this.faLeistungID = FaLeistungID;
            this.baPersonID = BaPersonID;

            DBUtil.GetFallRights(this.faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);

            if (!InizioExists() && DBUtil.UserHasRight("CtlKaInizioUebersicht", "UI") && (MayUpd || MayIns))
            {
                DBUtil.ExecSQL(@"INSERT INTO KaInizio (FaLeistungID) VALUES ({0})", this.faLeistungID);
            }

            if (KaUtil.GetSichtbarSDFlag(this.baPersonID) == 1)
            {
                qryInizioUebersicht.Fill(-1);
            }
            else
            {
                qryInizioUebersicht.Fill(faLeistungID);
            }
        }

        #endregion

        #region Private Methods

        private bool InizioExists()
        {
            bool rslt = false;

            rslt =	Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*) FROM dbo.KaInizio WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}",
                this.faLeistungID)
                ) > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}