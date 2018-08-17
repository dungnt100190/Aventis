using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.BegleitetesWohnen
{
    public class CtlBwZielvereinbarung : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private int FaLeistungID = -1;
        private bool HasBegleiterChanged = false;
        private bool HasZustaendigBWChanged = false;
        private string UserFullName = "";
        private KiSS4.Gui.KissCheckEdit chkBSVBeitrag;
        private KiSS4.Gui.KissCheckEdit chkELEmpfaenger;
        private KiSS4.Gui.KissCheckEdit chkHELBVerfuegung;
        private KiSS4.Gui.KissCheckEdit chkSelbstzahler;
        private System.ComponentModel.IContainer components;
        private KiSS4.Dokument.XWordBericht docEinsatzvereinbarung;
        private KiSS4.Gui.KissDateEdit edtAuswertungGeplant;
        private KiSS4.Gui.KissButtonEdit edtBegleiter;
        private KiSS4.Gui.KissDateEdit edtErstellungZV;
        private KiSS4.Gui.KissDateEdit edtErsterEinsatzAm;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissTextEdit edtTelefon;
        private KiSS4.Gui.KissCheckedLookupEdit edtThemenCodes;
        private KiSS4.Gui.KissButtonEdit edtZustaendigBW;
        private System.Windows.Forms.GroupBox grpZiele;
        private KiSS4.Gui.KissLabel lblAuftragBegleitung;
        private KiSS4.Gui.KissLabel lblAuftragBenutzer;
        private KiSS4.Gui.KissLabel lblAuswertungGeplant;
        private KiSS4.Gui.KissLabel lblBegleiter;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblErstellungZV;
        private KiSS4.Gui.KissLabel lblErsterEinsatzAm;
        private KiSS4.Gui.KissLabel lblKostenschluessel;
        private KiSS4.Gui.KissLabel lblMoeglicheEinsatzzeiten;
        private KiSS4.Gui.KissLabel lblOrt;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblThemen;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVertretenDurch;
        private KiSS4.Gui.KissLabel lblZustaendigBW;
        private KiSS4.Gui.KissRTFEdit memAuftragBegleitung;
        private KiSS4.Gui.KissRTFEdit memAuftragBenutzer;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private KiSS4.Gui.KissMemoEdit memMoeglicheEinsatzzeiten;
        private KiSS4.Gui.KissRTFEdit memVertretenDurch;
        private KiSS4.Gui.KissRTFEdit memZiel;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaBegleitetesWohnen;

        #endregion

        #region Constructors

        public CtlBwZielvereinbarung()
        {
            this.InitializeComponent();

            // request userfullname
            this.UserFullName = DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnGetLastFirstName({0}, NULL, NULL)", Session.User.UserID) as string;

            // init with default values
            Init(null, null, -1, false);
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBwZielvereinbarung));
            this.panTitel = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblZustaendigBW = new KiSS4.Gui.KissLabel();
            this.edtZustaendigBW = new KiSS4.Gui.KissButtonEdit();
            this.lblErstellungZV = new KiSS4.Gui.KissLabel();
            this.edtErstellungZV = new KiSS4.Gui.KissDateEdit();
            this.lblErsterEinsatzAm = new KiSS4.Gui.KissLabel();
            this.edtErsterEinsatzAm = new KiSS4.Gui.KissDateEdit();
            this.lblAuswertungGeplant = new KiSS4.Gui.KissLabel();
            this.edtAuswertungGeplant = new KiSS4.Gui.KissDateEdit();
            this.grpZiele = new System.Windows.Forms.GroupBox();
            this.memZiel = new KiSS4.Gui.KissRTFEdit();
            this.lblAuftragBegleitung = new KiSS4.Gui.KissLabel();
            this.memAuftragBegleitung = new KiSS4.Gui.KissRTFEdit();
            this.lblAuftragBenutzer = new KiSS4.Gui.KissLabel();
            this.memAuftragBenutzer = new KiSS4.Gui.KissRTFEdit();
            this.lblKostenschluessel = new KiSS4.Gui.KissLabel();
            this.chkHELBVerfuegung = new KiSS4.Gui.KissCheckEdit();
            this.chkELEmpfaenger = new KiSS4.Gui.KissCheckEdit();
            this.chkBSVBeitrag = new KiSS4.Gui.KissCheckEdit();
            this.chkSelbstzahler = new KiSS4.Gui.KissCheckEdit();
            this.lblThemen = new KiSS4.Gui.KissLabel();
            this.edtThemenCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBegleiter = new KiSS4.Gui.KissLabel();
            this.edtBegleiter = new KiSS4.Gui.KissButtonEdit();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblOrt = new KiSS4.Gui.KissLabel();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblVertretenDurch = new KiSS4.Gui.KissLabel();
            this.memVertretenDurch = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblMoeglicheEinsatzzeiten = new KiSS4.Gui.KissLabel();
            this.memMoeglicheEinsatzzeiten = new KiSS4.Gui.KissMemoEdit();
            this.docEinsatzvereinbarung = new KiSS4.Dokument.XWordBericht();
            this.qryFaBegleitetesWohnen = new KiSS4.DB.SqlQuery(this.components);
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigBW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigBW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellungZV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellungZV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErsterEinsatzAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErsterEinsatzAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungGeplant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertungGeplant.Properties)).BeginInit();
            this.grpZiele.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragBegleitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenschluessel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHELBVerfuegung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELEmpfaenger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBSVBeitrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelbstzahler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThemenCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegleiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBegleiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVertretenDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMoeglicheEinsatzzeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMoeglicheEinsatzzeiten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaBegleitetesWohnen)).BeginInit();
            this.SuspendLayout();
            //
            // panTitel
            //
            this.panTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Location = new System.Drawing.Point(3, 3);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(716, 30);
            this.panTitel.TabIndex = 0;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(674, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Zielvereinbarung Begleitetes Wohnen";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            //
            // lblZustaendigBW
            //
            this.lblZustaendigBW.Location = new System.Drawing.Point(8, 41);
            this.lblZustaendigBW.Name = "lblZustaendigBW";
            this.lblZustaendigBW.Size = new System.Drawing.Size(99, 24);
            this.lblZustaendigBW.TabIndex = 1;
            this.lblZustaendigBW.Text = "Zuständig BW";
            this.lblZustaendigBW.UseCompatibleTextRendering = true;
            //
            // edtZustaendigBW
            //
            this.edtZustaendigBW.DataMember = "ZustaendigBW";
            this.edtZustaendigBW.DataSource = this.qryFaBegleitetesWohnen;
            this.edtZustaendigBW.Location = new System.Drawing.Point(113, 41);
            this.edtZustaendigBW.Name = "edtZustaendigBW";
            this.edtZustaendigBW.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigBW.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigBW.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigBW.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigBW.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigBW.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigBW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZustaendigBW.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtZustaendigBW.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigBW.Size = new System.Drawing.Size(128, 24);
            this.edtZustaendigBW.TabIndex = 2;
            this.edtZustaendigBW.EditValueChanged += new System.EventHandler(this.edtZustaendigBW_EditValueChanged);
            this.edtZustaendigBW.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustaendigBW_UserModifiedFld);
            //
            // lblErstellungZV
            //
            this.lblErstellungZV.Location = new System.Drawing.Point(8, 71);
            this.lblErstellungZV.Name = "lblErstellungZV";
            this.lblErstellungZV.Size = new System.Drawing.Size(99, 24);
            this.lblErstellungZV.TabIndex = 3;
            this.lblErstellungZV.Text = "Erstellung ZV";
            this.lblErstellungZV.UseCompatibleTextRendering = true;
            //
            // edtErstellungZV
            //
            this.edtErstellungZV.DataMember = "ErstellungZV";
            this.edtErstellungZV.DataSource = this.qryFaBegleitetesWohnen;
            this.edtErstellungZV.EditValue = null;
            this.edtErstellungZV.Location = new System.Drawing.Point(113, 71);
            this.edtErstellungZV.Name = "edtErstellungZV";
            this.edtErstellungZV.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstellungZV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErstellungZV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstellungZV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstellungZV.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstellungZV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstellungZV.Properties.Appearance.Options.UseFont = true;
            this.edtErstellungZV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtErstellungZV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstellungZV.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtErstellungZV.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstellungZV.Properties.ShowToday = false;
            this.edtErstellungZV.Size = new System.Drawing.Size(128, 24);
            this.edtErstellungZV.TabIndex = 4;
            //
            // lblErsterEinsatzAm
            //
            this.lblErsterEinsatzAm.Location = new System.Drawing.Point(269, 41);
            this.lblErsterEinsatzAm.Name = "lblErsterEinsatzAm";
            this.lblErsterEinsatzAm.Size = new System.Drawing.Size(125, 24);
            this.lblErsterEinsatzAm.TabIndex = 5;
            this.lblErsterEinsatzAm.Text = "Erster Einsatz am";
            this.lblErsterEinsatzAm.UseCompatibleTextRendering = true;
            //
            // edtErsterEinsatzAm
            //
            this.edtErsterEinsatzAm.DataMember = "ErsterEinsatzAm";
            this.edtErsterEinsatzAm.DataSource = this.qryFaBegleitetesWohnen;
            this.edtErsterEinsatzAm.EditValue = null;
            this.edtErsterEinsatzAm.Location = new System.Drawing.Point(400, 41);
            this.edtErsterEinsatzAm.Name = "edtErsterEinsatzAm";
            this.edtErsterEinsatzAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErsterEinsatzAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErsterEinsatzAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErsterEinsatzAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErsterEinsatzAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtErsterEinsatzAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErsterEinsatzAm.Properties.Appearance.Options.UseFont = true;
            this.edtErsterEinsatzAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtErsterEinsatzAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErsterEinsatzAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtErsterEinsatzAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErsterEinsatzAm.Properties.ShowToday = false;
            this.edtErsterEinsatzAm.Size = new System.Drawing.Size(128, 24);
            this.edtErsterEinsatzAm.TabIndex = 6;
            //
            // lblAuswertungGeplant
            //
            this.lblAuswertungGeplant.Location = new System.Drawing.Point(269, 71);
            this.lblAuswertungGeplant.Name = "lblAuswertungGeplant";
            this.lblAuswertungGeplant.Size = new System.Drawing.Size(125, 24);
            this.lblAuswertungGeplant.TabIndex = 7;
            this.lblAuswertungGeplant.Text = "Auswertung geplant";
            this.lblAuswertungGeplant.UseCompatibleTextRendering = true;
            //
            // edtAuswertungGeplant
            //
            this.edtAuswertungGeplant.DataMember = "AuswertungGeplant";
            this.edtAuswertungGeplant.DataSource = this.qryFaBegleitetesWohnen;
            this.edtAuswertungGeplant.EditValue = null;
            this.edtAuswertungGeplant.Location = new System.Drawing.Point(400, 71);
            this.edtAuswertungGeplant.Name = "edtAuswertungGeplant";
            this.edtAuswertungGeplant.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuswertungGeplant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswertungGeplant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswertungGeplant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswertungGeplant.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswertungGeplant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswertungGeplant.Properties.Appearance.Options.UseFont = true;
            this.edtAuswertungGeplant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAuswertungGeplant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAuswertungGeplant.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAuswertungGeplant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswertungGeplant.Properties.ShowToday = false;
            this.edtAuswertungGeplant.Size = new System.Drawing.Size(128, 24);
            this.edtAuswertungGeplant.TabIndex = 8;
            //
            // grpZiele
            //
            this.grpZiele.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpZiele.Controls.Add(this.memAuftragBenutzer);
            this.grpZiele.Controls.Add(this.lblAuftragBenutzer);
            this.grpZiele.Controls.Add(this.memAuftragBegleitung);
            this.grpZiele.Controls.Add(this.lblAuftragBegleitung);
            this.grpZiele.Controls.Add(this.memZiel);
            this.grpZiele.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpZiele.Location = new System.Drawing.Point(7, 101);
            this.grpZiele.Name = "grpZiele";
            this.grpZiele.Size = new System.Drawing.Size(705, 237);
            this.grpZiele.TabIndex = 9;
            this.grpZiele.TabStop = false;
            this.grpZiele.Text = "Ziele";
            this.grpZiele.UseCompatibleTextRendering = true;
            //
            // memZiel
            //
            this.memZiel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memZiel.BackColor = System.Drawing.Color.White;
            this.memZiel.DataMember = "Ziele";
            this.memZiel.DataSource = this.qryFaBegleitetesWohnen;
            this.memZiel.Font = new System.Drawing.Font("Arial", 10F);
            this.memZiel.Location = new System.Drawing.Point(6, 23);
            this.memZiel.Name = "memZiel";
            this.memZiel.Size = new System.Drawing.Size(693, 45);
            this.memZiel.TabIndex = 0;
            //
            // lblAuftragBegleitung
            //
            this.lblAuftragBegleitung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuftragBegleitung.Location = new System.Drawing.Point(6, 77);
            this.lblAuftragBegleitung.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblAuftragBegleitung.Name = "lblAuftragBegleitung";
            this.lblAuftragBegleitung.Size = new System.Drawing.Size(693, 24);
            this.lblAuftragBegleitung.TabIndex = 1;
            this.lblAuftragBegleitung.Text = "Auftrag an Begleitung (wie oft - was - bis wann)";
            this.lblAuftragBegleitung.UseCompatibleTextRendering = true;
            //
            // memAuftragBegleitung
            //
            this.memAuftragBegleitung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memAuftragBegleitung.BackColor = System.Drawing.Color.White;
            this.memAuftragBegleitung.DataMember = "AuftragAnBegleitung";
            this.memAuftragBegleitung.DataSource = this.qryFaBegleitetesWohnen;
            this.memAuftragBegleitung.Font = new System.Drawing.Font("Arial", 10F);
            this.memAuftragBegleitung.Location = new System.Drawing.Point(6, 104);
            this.memAuftragBegleitung.Name = "memAuftragBegleitung";
            this.memAuftragBegleitung.Size = new System.Drawing.Size(693, 45);
            this.memAuftragBegleitung.TabIndex = 2;
            //
            // lblAuftragBenutzer
            //
            this.lblAuftragBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuftragBenutzer.Location = new System.Drawing.Point(6, 158);
            this.lblAuftragBenutzer.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblAuftragBenutzer.Name = "lblAuftragBenutzer";
            this.lblAuftragBenutzer.Size = new System.Drawing.Size(693, 24);
            this.lblAuftragBenutzer.TabIndex = 3;
            this.lblAuftragBenutzer.Text = "Auftrag an Benutzer/in / Weitere Beteiligte (wer - was - bis wann)";
            this.lblAuftragBenutzer.UseCompatibleTextRendering = true;
            //
            // memAuftragBenutzer
            //
            this.memAuftragBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memAuftragBenutzer.BackColor = System.Drawing.Color.White;
            this.memAuftragBenutzer.DataMember = "AuftragAnBenutzer";
            this.memAuftragBenutzer.DataSource = this.qryFaBegleitetesWohnen;
            this.memAuftragBenutzer.Font = new System.Drawing.Font("Arial", 10F);
            this.memAuftragBenutzer.Location = new System.Drawing.Point(6, 185);
            this.memAuftragBenutzer.Name = "memAuftragBenutzer";
            this.memAuftragBenutzer.Size = new System.Drawing.Size(693, 45);
            this.memAuftragBenutzer.TabIndex = 4;
            //
            // lblKostenschluessel
            //
            this.lblKostenschluessel.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKostenschluessel.Location = new System.Drawing.Point(8, 344);
            this.lblKostenschluessel.Name = "lblKostenschluessel";
            this.lblKostenschluessel.Size = new System.Drawing.Size(456, 16);
            this.lblKostenschluessel.TabIndex = 10;
            this.lblKostenschluessel.Text = "Kostenschlüssel zum Zeitpunkt der Vereinbarung";
            this.lblKostenschluessel.UseCompatibleTextRendering = true;
            //
            // chkHELBVerfuegung
            //
            this.chkHELBVerfuegung.DataMember = "KostenHELBVerfuegung";
            this.chkHELBVerfuegung.DataSource = this.qryFaBegleitetesWohnen;
            this.chkHELBVerfuegung.Location = new System.Drawing.Point(13, 369);
            this.chkHELBVerfuegung.Name = "chkHELBVerfuegung";
            this.chkHELBVerfuegung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkHELBVerfuegung.Properties.Appearance.Options.UseBackColor = true;
            this.chkHELBVerfuegung.Properties.Caption = "Bei HELB-Verfügung";
            this.chkHELBVerfuegung.Size = new System.Drawing.Size(223, 19);
            this.chkHELBVerfuegung.TabIndex = 11;
            //
            // chkELEmpfaenger
            //
            this.chkELEmpfaenger.DataMember = "KostenELEmpaenger";
            this.chkELEmpfaenger.DataSource = this.qryFaBegleitetesWohnen;
            this.chkELEmpfaenger.Location = new System.Drawing.Point(13, 394);
            this.chkELEmpfaenger.Name = "chkELEmpfaenger";
            this.chkELEmpfaenger.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkELEmpfaenger.Properties.Appearance.Options.UseBackColor = true;
            this.chkELEmpfaenger.Properties.Caption = "EL-Empfänger/in";
            this.chkELEmpfaenger.Size = new System.Drawing.Size(223, 19);
            this.chkELEmpfaenger.TabIndex = 12;
            //
            // chkBSVBeitrag
            //
            this.chkBSVBeitrag.DataMember = "KostenBSVBeitrag";
            this.chkBSVBeitrag.DataSource = this.qryFaBegleitetesWohnen;
            this.chkBSVBeitrag.Location = new System.Drawing.Point(242, 369);
            this.chkBSVBeitrag.Name = "chkBSVBeitrag";
            this.chkBSVBeitrag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBSVBeitrag.Properties.Appearance.Options.UseBackColor = true;
            this.chkBSVBeitrag.Properties.Caption = "BSV Beitrag";
            this.chkBSVBeitrag.Size = new System.Drawing.Size(223, 19);
            this.chkBSVBeitrag.TabIndex = 13;
            //
            // chkSelbstzahler
            //
            this.chkSelbstzahler.DataMember = "KostenSelbstzahler";
            this.chkSelbstzahler.DataSource = this.qryFaBegleitetesWohnen;
            this.chkSelbstzahler.Location = new System.Drawing.Point(242, 394);
            this.chkSelbstzahler.Name = "chkSelbstzahler";
            this.chkSelbstzahler.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSelbstzahler.Properties.Appearance.Options.UseBackColor = true;
            this.chkSelbstzahler.Properties.Caption = "Selbstzahler";
            this.chkSelbstzahler.Size = new System.Drawing.Size(223, 19);
            this.chkSelbstzahler.TabIndex = 14;
            //
            // lblThemen
            //
            this.lblThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThemen.Location = new System.Drawing.Point(536, 342);
            this.lblThemen.Name = "lblThemen";
            this.lblThemen.Size = new System.Drawing.Size(176, 24);
            this.lblThemen.TabIndex = 15;
            this.lblThemen.Text = "Themen";
            this.lblThemen.UseCompatibleTextRendering = true;
            //
            // edtThemenCodes
            //
            this.edtThemenCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtThemenCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtThemenCodes.Appearance.Options.UseBackColor = true;
            this.edtThemenCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtThemenCodes.CheckOnClick = true;
            this.edtThemenCodes.DataMember = "ThemenCodes";
            this.edtThemenCodes.DataSource = this.qryFaBegleitetesWohnen;
            this.edtThemenCodes.Location = new System.Drawing.Point(536, 366);
            this.edtThemenCodes.LOVName = "BwThema";
            this.edtThemenCodes.Name = "edtThemenCodes";
            this.edtThemenCodes.Size = new System.Drawing.Size(176, 155);
            this.edtThemenCodes.TabIndex = 16;
            //
            // lblBegleiter
            //
            this.lblBegleiter.Location = new System.Drawing.Point(8, 426);
            this.lblBegleiter.Name = "lblBegleiter";
            this.lblBegleiter.Size = new System.Drawing.Size(99, 24);
            this.lblBegleiter.TabIndex = 17;
            this.lblBegleiter.Text = "Begleiter/in";
            this.lblBegleiter.UseCompatibleTextRendering = true;
            //
            // edtBegleiter
            //
            this.edtBegleiter.DataMember = "Begleiter";
            this.edtBegleiter.DataSource = this.qryFaBegleitetesWohnen;
            this.edtBegleiter.Location = new System.Drawing.Point(113, 426);
            this.edtBegleiter.Name = "edtBegleiter";
            this.edtBegleiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBegleiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBegleiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBegleiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtBegleiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBegleiter.Properties.Appearance.Options.UseFont = true;
            this.edtBegleiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBegleiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtBegleiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBegleiter.Size = new System.Drawing.Size(158, 24);
            this.edtBegleiter.TabIndex = 18;
            this.edtBegleiter.EditValueChanged += new System.EventHandler(this.edtBegleiter_EditValueChanged);
            this.edtBegleiter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBegleiter_UserModifiedFld);
            //
            // lblStrasse
            //
            this.lblStrasse.Location = new System.Drawing.Point(8, 449);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(99, 24);
            this.lblStrasse.TabIndex = 19;
            this.lblStrasse.Text = "Strasse, Nr.";
            this.lblStrasse.UseCompatibleTextRendering = true;
            //
            // edtStrasse
            //
            this.edtStrasse.DataMember = "StrasseNr";
            this.edtStrasse.DataSource = this.qryFaBegleitetesWohnen;
            this.edtStrasse.Location = new System.Drawing.Point(113, 449);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(158, 24);
            this.edtStrasse.TabIndex = 20;
            //
            // lblOrt
            //
            this.lblOrt.Location = new System.Drawing.Point(8, 472);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(99, 24);
            this.lblOrt.TabIndex = 21;
            this.lblOrt.Text = "Ort";
            this.lblOrt.UseCompatibleTextRendering = true;
            //
            // edtOrt
            //
            this.edtOrt.DataMember = "Ort";
            this.edtOrt.DataSource = this.qryFaBegleitetesWohnen;
            this.edtOrt.Location = new System.Drawing.Point(113, 472);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(158, 24);
            this.edtOrt.TabIndex = 22;
            //
            // lblTelefon
            //
            this.lblTelefon.Location = new System.Drawing.Point(8, 495);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(99, 24);
            this.lblTelefon.TabIndex = 23;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            //
            // edtTelefon
            //
            this.edtTelefon.DataMember = "Telefon";
            this.edtTelefon.DataSource = this.qryFaBegleitetesWohnen;
            this.edtTelefon.Location = new System.Drawing.Point(113, 495);
            this.edtTelefon.Name = "edtTelefon";
            this.edtTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon.Size = new System.Drawing.Size(158, 24);
            this.edtTelefon.TabIndex = 24;
            //
            // lblVertretenDurch
            //
            this.lblVertretenDurch.Location = new System.Drawing.Point(288, 426);
            this.lblVertretenDurch.Name = "lblVertretenDurch";
            this.lblVertretenDurch.Size = new System.Drawing.Size(99, 24);
            this.lblVertretenDurch.TabIndex = 25;
            this.lblVertretenDurch.Text = "Vertreten durch";
            this.lblVertretenDurch.UseCompatibleTextRendering = true;
            //
            // memVertretenDurch
            //
            this.memVertretenDurch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memVertretenDurch.BackColor = System.Drawing.Color.White;
            this.memVertretenDurch.DataMember = "VertretenDurch";
            this.memVertretenDurch.DataSource = this.qryFaBegleitetesWohnen;
            this.memVertretenDurch.Font = new System.Drawing.Font("Arial", 10F);
            this.memVertretenDurch.Location = new System.Drawing.Point(288, 449);
            this.memVertretenDurch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.memVertretenDurch.Name = "memVertretenDurch";
            this.memVertretenDurch.Size = new System.Drawing.Size(231, 69);
            this.memVertretenDurch.TabIndex = 26;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Location = new System.Drawing.Point(8, 522);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(99, 24);
            this.lblBemerkungen.TabIndex = 27;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // memBemerkungen
            //
            this.memBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkungen.DataMember = "Bemerkungen";
            this.memBemerkungen.DataSource = this.qryFaBegleitetesWohnen;
            this.memBemerkungen.Location = new System.Drawing.Point(8, 548);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Size = new System.Drawing.Size(511, 41);
            this.memBemerkungen.TabIndex = 28;
            //
            // lblMoeglicheEinsatzzeiten
            //
            this.lblMoeglicheEinsatzzeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoeglicheEinsatzzeiten.Location = new System.Drawing.Point(536, 523);
            this.lblMoeglicheEinsatzzeiten.Name = "lblMoeglicheEinsatzzeiten";
            this.lblMoeglicheEinsatzzeiten.Size = new System.Drawing.Size(176, 24);
            this.lblMoeglicheEinsatzzeiten.TabIndex = 29;
            this.lblMoeglicheEinsatzzeiten.Text = "Mögliche Einsatzzeiten";
            this.lblMoeglicheEinsatzzeiten.UseCompatibleTextRendering = true;
            //
            // memMoeglicheEinsatzzeiten
            //
            this.memMoeglicheEinsatzzeiten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memMoeglicheEinsatzzeiten.DataMember = "Einsatzzeiten";
            this.memMoeglicheEinsatzzeiten.DataSource = this.qryFaBegleitetesWohnen;
            this.memMoeglicheEinsatzzeiten.Location = new System.Drawing.Point(536, 549);
            this.memMoeglicheEinsatzzeiten.Name = "memMoeglicheEinsatzzeiten";
            this.memMoeglicheEinsatzzeiten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memMoeglicheEinsatzzeiten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memMoeglicheEinsatzzeiten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memMoeglicheEinsatzzeiten.Properties.Appearance.Options.UseBackColor = true;
            this.memMoeglicheEinsatzzeiten.Properties.Appearance.Options.UseBorderColor = true;
            this.memMoeglicheEinsatzzeiten.Properties.Appearance.Options.UseFont = true;
            this.memMoeglicheEinsatzzeiten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memMoeglicheEinsatzzeiten.Size = new System.Drawing.Size(176, 40);
            this.memMoeglicheEinsatzzeiten.TabIndex = 30;
            //
            // docEinsatzvereinbarung
            //
            this.docEinsatzvereinbarung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.docEinsatzvereinbarung.Context = "BW_Zielvereinbarung_Einsatzvereinbarung";
            this.docEinsatzvereinbarung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docEinsatzvereinbarung.Image = ((System.Drawing.Image)(resources.GetObject("docEinsatzvereinbarung.Image")));
            this.docEinsatzvereinbarung.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docEinsatzvereinbarung.Location = new System.Drawing.Point(552, 71);
            this.docEinsatzvereinbarung.Name = "docEinsatzvereinbarung";
            this.docEinsatzvereinbarung.Size = new System.Drawing.Size(160, 24);
            this.docEinsatzvereinbarung.TabIndex = 31;
            this.docEinsatzvereinbarung.Text = "Einsatzvereinbarung";
            this.docEinsatzvereinbarung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docEinsatzvereinbarung.UseCompatibleTextRendering = true;
            this.docEinsatzvereinbarung.UseVisualStyleBackColor = false;
            //
            // qryFaBegleitetesWohnen
            //
            this.qryFaBegleitetesWohnen.HostControl = this;
            this.qryFaBegleitetesWohnen.TableName = "FaBegleitetesWohnen";
            this.qryFaBegleitetesWohnen.BeforePost += new System.EventHandler(this.qryFaBegleitetesWohnen_BeforePost);
            this.qryFaBegleitetesWohnen.AfterInsert += new System.EventHandler(this.qryFaBegleitetesWohnen_AfterInsert);
            //
            // CtlBwZielvereinbarung
            //
            this.ActiveSQLQuery = this.qryFaBegleitetesWohnen;
            this.AutoRefresh = false;
            this.Controls.Add(this.docEinsatzvereinbarung);
            this.Controls.Add(this.memMoeglicheEinsatzzeiten);
            this.Controls.Add(this.lblMoeglicheEinsatzzeiten);
            this.Controls.Add(this.memBemerkungen);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.memVertretenDurch);
            this.Controls.Add(this.lblVertretenDurch);
            this.Controls.Add(this.edtTelefon);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.edtOrt);
            this.Controls.Add(this.lblOrt);
            this.Controls.Add(this.edtStrasse);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.edtBegleiter);
            this.Controls.Add(this.lblBegleiter);
            this.Controls.Add(this.edtThemenCodes);
            this.Controls.Add(this.lblThemen);
            this.Controls.Add(this.chkSelbstzahler);
            this.Controls.Add(this.chkBSVBeitrag);
            this.Controls.Add(this.chkELEmpfaenger);
            this.Controls.Add(this.chkHELBVerfuegung);
            this.Controls.Add(this.lblKostenschluessel);
            this.Controls.Add(this.grpZiele);
            this.Controls.Add(this.edtAuswertungGeplant);
            this.Controls.Add(this.lblAuswertungGeplant);
            this.Controls.Add(this.edtErsterEinsatzAm);
            this.Controls.Add(this.lblErsterEinsatzAm);
            this.Controls.Add(this.edtErstellungZV);
            this.Controls.Add(this.lblErstellungZV);
            this.Controls.Add(this.edtZustaendigBW);
            this.Controls.Add(this.lblZustaendigBW);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlBwZielvereinbarung";
            this.Size = new System.Drawing.Size(722, 596);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigBW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigBW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellungZV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellungZV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErsterEinsatzAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErsterEinsatzAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungGeplant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertungGeplant.Properties)).EndInit();
            this.grpZiele.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragBegleitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenschluessel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHELBVerfuegung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELEmpfaenger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBSVBeitrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelbstzahler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThemenCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegleiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBegleiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVertretenDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMoeglicheEinsatzzeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMoeglicheEinsatzzeiten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaBegleitetesWohnen)).EndInit();
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

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "FABEGLEITETESWOHNENID":
                    return qryFaBegleitetesWohnen["FaBegleitetesWohnenID"];

                case "FALEISTUNGID":
                    return this.FaLeistungID;

                case "BAPERSONID":
                    return qryFaBegleitetesWohnen["BaPersonID"];
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, bool isLeistungClosed)
        {
            // validate
            if (faLeistungID < 1)
            {
                // do not continue
                qryFaBegleitetesWohnen.CanUpdate = false;
                qryFaBegleitetesWohnen.EnableBoundFields(qryFaBegleitetesWohnen.CanUpdate);
                return;
            }

            // allow changes
            qryFaBegleitetesWohnen.CanUpdate = !isLeistungClosed;

            // apply values
            this.FaLeistungID = faLeistungID;
            this.picTitel.Image = titleImage;
            //this.lblTitel.Text 	= titleName;

            // fill data
            qryFaBegleitetesWohnen.Fill(@"
                    SELECT BW.*,
                           LEI.BaPersonID,
                           ZustaendigBW = dbo.fnGetLastFirstName(NULL, USRBw.LastName, USRBw.FirstName),
                           Begleiter 	= dbo.fnGetLastFirstName(NULL, USRBl.LastName, USRBl.FirstName)
                    FROM FaBegleitetesWohnen BW
                      LEFT JOIN FaLeistung LEI ON LEI.FaLeistungID = BW.FaLeistungID
                      LEFT JOIN XUser USRBw ON USRBw.UserID = BW.UserID
                      LEFT JOIN XUser USRBl ON USRBl.UserID = BW.BegleiterID
                    WHERE BW.FaLeistungID = {0}", faLeistungID);

            // insert new entry if not yet any entry found
            if (qryFaBegleitetesWohnen.CanUpdate && qryFaBegleitetesWohnen.Count < 1)
            {
                qryFaBegleitetesWohnen.Insert(null);
            }

            // reset flags
            this.HasZustaendigBWChanged = false;
            this.HasBegleiterChanged = false;
        }

        #endregion

        #region Private Methods

        private bool DialogMitarbeiter(object sender, UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly || !qryFaBegleitetesWohnen.CanUpdate)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // check db-fields
                        if (edt == edtBegleiter)
                        {
                            // Begleiter/in
                            qryFaBegleitetesWohnen["BegleiterID"] = DBNull.Value;
                            qryFaBegleitetesWohnen["Begleiter"] = DBNull.Value;
                        }
                        else
                        {
                            // Zuständig BW
                            qryFaBegleitetesWohnen["UserID"] = DBNull.Value;
                            qryFaBegleitetesWohnen["ZustaendigBW"] = DBNull.Value;
                        }
                        return true;
                    }
                }

                // Mitarbeiter_Suchen()
                KissLookupDialog dlg = new KissLookupDialog();
                e.Cancel = !dlg.SearchData(string.Format(@"
                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE '{1}%'", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    if (edt == edtBegleiter)
                    {
                        // Begleiter/in
                        qryFaBegleitetesWohnen["BegleiterID"] = dlg["UserID$"];
                        qryFaBegleitetesWohnen["Begleiter"] = dlg["Name"];

                        // reset flags
                        this.HasBegleiterChanged = false;
                    }
                    else
                    {
                        // Zuständig BW
                        qryFaBegleitetesWohnen["UserID"] = dlg["UserID$"];
                        qryFaBegleitetesWohnen["ZustaendigBW"] = dlg["Name"];

                        // reset flags
                        this.HasZustaendigBWChanged = false;
                    }

                    // success
                    return true;
                }
                else
                {
                    // canceled or error
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlBwZielvereinbarung", "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        private void edtBegleiter_EditValueChanged(object sender, System.EventArgs e)
        {
            // data has changed
            this.HasBegleiterChanged = true;
        }

        private void edtBegleiter_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogMitarbeiter(sender, e, edtBegleiter);
        }

        private void edtZustaendigBW_EditValueChanged(object sender, System.EventArgs e)
        {
            // data has changed
            this.HasZustaendigBWChanged = true;
        }

        private void edtZustaendigBW_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogMitarbeiter(sender, e, edtZustaendigBW);
        }

        private void qryFaBegleitetesWohnen_AfterInsert(object sender, System.EventArgs e)
        {
            // apply person id
            qryFaBegleitetesWohnen["FaLeistungID"] = this.FaLeistungID;

            // apply default values
            qryFaBegleitetesWohnen["ZustaendigBW"] = this.UserFullName;
            qryFaBegleitetesWohnen["UserID"] = Session.User.UserID;
            qryFaBegleitetesWohnen["ErstellungZV"] = DateTime.Today;
        }

        private void qryFaBegleitetesWohnen_BeforePost(object sender, System.EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtZustaendigBW, lblZustaendigBW.Text);
            DBUtil.CheckNotNullField(edtErstellungZV, lblErstellungZV.Text);

            // validate dates
            if (!DBUtil.IsEmpty(qryFaBegleitetesWohnen["AuswertungGeplant"]) && Convert.ToDateTime(qryFaBegleitetesWohnen["ErstellungZV"]) >= Convert.ToDateTime(qryFaBegleitetesWohnen["AuswertungGeplant"]))
            {
                // invalid range
                edtAuswertungGeplant.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBwZielvereinbarung", "InvalidDateOrder", "Das Datum 'Auswertung geplant' ist ungültig - es muss grösser als 'Erstellung ZV - {0}' sein.", KissMsgCode.MsgInfo, Convert.ToDateTime(qryFaBegleitetesWohnen["ErstellungZV"]).ToString("dd.MM.yyyy")), (Control)edtAuswertungGeplant);
            }

            // validate buttonedits
            if (this.HasZustaendigBWChanged && !this.DialogMitarbeiter(this, new UserModifiedFldEventArgs(false, false), edtZustaendigBW))
            {
                // invalid value
                edtZustaendigBW.Focus();
                throw new KissCancelException();
            }
            if (this.HasBegleiterChanged && !this.DialogMitarbeiter(this, new UserModifiedFldEventArgs(false, false), edtBegleiter))
            {
                // invalid value
                edtBegleiter.Focus();
                throw new KissCancelException();
            }

            // reset flags
            this.HasZustaendigBWChanged = false;
            this.HasBegleiterChanged = false;
        }

        #endregion
    }
}