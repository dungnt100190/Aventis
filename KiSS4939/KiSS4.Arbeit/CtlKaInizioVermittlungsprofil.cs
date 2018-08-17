using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaInizioVermittlungsprofil : KiSS4.Gui.KissUserControl
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
        private KiSS4.Gui.KissButton btnEinsatzplatzSuchen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAusbildungWunsch;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissLookUpEdit edtBerufswunsch;
        private KiSS4.Gui.KissCheckedLookupEdit edtBranchen;
        private KiSS4.Dokument.XDokument edtErstgespraech;
        private KiSS4.Gui.KissDateEdit edtGespraechDatum;
        private KiSS4.Gui.KissLookUpEdit edtLehrberuf;
        private KiSS4.Gui.KissLookUpEdit edtMotivation;
        private KiSS4.Gui.KissCheckedLookupEdit edtUnterstuetzung;
        private int faLeistungID = -1;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBerufswunsch;
        private KiSS4.Gui.KissLabel lblBranchen;
        private KiSS4.Gui.KissLabel lblDatumGespräch;
        private KiSS4.Gui.KissLabel lblErstgesprächVerlauf;
        private KiSS4.Gui.KissLabel lblInformationenMatching;
        private KiSS4.Gui.KissLabel lblLehrberuf;
        private KiSS4.Gui.KissLabel lblMotivation;
        private KiSS4.Gui.KissLabel lblPersoenlicheInformationen;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblUnterstützung;
        private KiSS4.Gui.KissLabel lblWunschKandidatIn;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryInizioVermittlung;

        #endregion

        #endregion

        #region Constructors

        public CtlKaInizioVermittlungsprofil()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaInizioVermittlungsprofil));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblPersoenlicheInformationen = new KiSS4.Gui.KissLabel();
            this.lblErstgesprächVerlauf = new KiSS4.Gui.KissLabel();
            this.edtErstgespraech = new KiSS4.Dokument.XDokument();
            this.qryInizioVermittlung = new KiSS4.DB.SqlQuery(this.components);
            this.lblMotivation = new KiSS4.Gui.KissLabel();
            this.edtMotivation = new KiSS4.Gui.KissLookUpEdit();
            this.lblUnterstützung = new KiSS4.Gui.KissLabel();
            this.edtUnterstuetzung = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblWunschKandidatIn = new KiSS4.Gui.KissLabel();
            this.edtAusbildungWunsch = new KiSS4.Gui.KissLookUpEdit();
            this.lblBerufswunsch = new KiSS4.Gui.KissLabel();
            this.edtBerufswunsch = new KiSS4.Gui.KissLookUpEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblDatumGespräch = new KiSS4.Gui.KissLabel();
            this.edtGespraechDatum = new KiSS4.Gui.KissDateEdit();
            this.lblInformationenMatching = new KiSS4.Gui.KissLabel();
            this.lblBranchen = new KiSS4.Gui.KissLabel();
            this.edtBranchen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblLehrberuf = new KiSS4.Gui.KissLabel();
            this.edtLehrberuf = new KiSS4.Gui.KissLookUpEdit();
            this.btnEinsatzplatzSuchen = new KiSS4.Gui.KissButton();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlicheInformationen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstgesprächVerlauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstgespraech.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioVermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstützung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWunschKandidatIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungWunsch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungWunsch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerufswunsch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufswunsch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufswunsch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGespräch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGespraechDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInformationenMatching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(675, 40);
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
            this.lblTitle.Text = "Vermittlungsprofil";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // lblPersoenlicheInformationen
            // 
            this.lblPersoenlicheInformationen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblPersoenlicheInformationen.Location = new System.Drawing.Point(10, 47);
            this.lblPersoenlicheInformationen.Name = "lblPersoenlicheInformationen";
            this.lblPersoenlicheInformationen.Size = new System.Drawing.Size(181, 16);
            this.lblPersoenlicheInformationen.TabIndex = 1;
            this.lblPersoenlicheInformationen.Text = "Persönliche Informationen";
            this.lblPersoenlicheInformationen.UseCompatibleTextRendering = true;
            // 
            // lblErstgesprächVerlauf
            // 
            this.lblErstgesprächVerlauf.Location = new System.Drawing.Point(10, 67);
            this.lblErstgesprächVerlauf.Name = "lblErstgesprächVerlauf";
            this.lblErstgesprächVerlauf.Size = new System.Drawing.Size(127, 24);
            this.lblErstgesprächVerlauf.TabIndex = 2;
            this.lblErstgesprächVerlauf.Text = "Erstgespräch/Verlauf";
            this.lblErstgesprächVerlauf.UseCompatibleTextRendering = true;
            // 
            // edtErstgespraech
            // 
            this.edtErstgespraech.Context = "KaVermProfilInizioVermErstgespraech";
            this.edtErstgespraech.DataMember = "InizioErstgesprVerlaufDokID";
            this.edtErstgespraech.DataSource = this.qryInizioVermittlung;
            this.edtErstgespraech.Location = new System.Drawing.Point(129, 67);
            this.edtErstgespraech.Name = "edtErstgespraech";
            this.edtErstgespraech.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErstgespraech.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstgespraech.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstgespraech.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstgespraech.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstgespraech.Properties.Appearance.Options.UseFont = true;
            this.edtErstgespraech.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtErstgespraech.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstgespraech.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstgespraech.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstgespraech.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstgespraech.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Dokument importieren")});
            this.edtErstgespraech.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstgespraech.Properties.ReadOnly = true;
            this.edtErstgespraech.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtErstgespraech.Size = new System.Drawing.Size(130, 24);
            this.edtErstgespraech.TabIndex = 3;
            // 
            // qryInizioVermittlung
            // 
            this.qryInizioVermittlung.CanUpdate = true;
            this.qryInizioVermittlung.HostControl = this;
            this.qryInizioVermittlung.IsIdentityInsert = false;
            this.qryInizioVermittlung.SelectStatement = "SELECT PRO.*\r\nFROM KaVermittlungProfil PRO   \r\nWHERE PRO.FaLeistungID = {0}";
            this.qryInizioVermittlung.TableName = "KaVermittlungProfil";
            // 
            // lblMotivation
            // 
            this.lblMotivation.Location = new System.Drawing.Point(10, 101);
            this.lblMotivation.Name = "lblMotivation";
            this.lblMotivation.Size = new System.Drawing.Size(55, 24);
            this.lblMotivation.TabIndex = 4;
            this.lblMotivation.Text = "Motivation";
            this.lblMotivation.UseCompatibleTextRendering = true;
            // 
            // edtMotivation
            // 
            this.edtMotivation.DataMember = "MotivationInizioCode";
            this.edtMotivation.DataSource = this.qryInizioVermittlung;
            this.edtMotivation.Location = new System.Drawing.Point(129, 101);
            this.edtMotivation.LOVName = "KaInizioMotivation";
            this.edtMotivation.Name = "edtMotivation";
            this.edtMotivation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMotivation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMotivation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMotivation.Properties.Appearance.Options.UseBackColor = true;
            this.edtMotivation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMotivation.Properties.Appearance.Options.UseFont = true;
            this.edtMotivation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtMotivation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtMotivation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtMotivation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtMotivation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtMotivation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtMotivation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMotivation.Properties.NullText = "";
            this.edtMotivation.Properties.ShowFooter = false;
            this.edtMotivation.Properties.ShowHeader = false;
            this.edtMotivation.Size = new System.Drawing.Size(189, 24);
            this.edtMotivation.TabIndex = 5;
            // 
            // lblUnterstützung
            // 
            this.lblUnterstützung.Location = new System.Drawing.Point(10, 131);
            this.lblUnterstützung.Name = "lblUnterstützung";
            this.lblUnterstützung.Size = new System.Drawing.Size(80, 24);
            this.lblUnterstützung.TabIndex = 6;
            this.lblUnterstützung.Text = "Unterstützung";
            this.lblUnterstützung.UseCompatibleTextRendering = true;
            // 
            // edtUnterstuetzung
            // 
            this.edtUnterstuetzung.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterstuetzung.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterstuetzung.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetzung.Appearance.Options.UseBorderColor = true;
            this.edtUnterstuetzung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtUnterstuetzung.CheckOnClick = true;
            this.edtUnterstuetzung.DataMember = "UnterstuetzungInizioCodes";
            this.edtUnterstuetzung.DataSource = this.qryInizioVermittlung;
            this.edtUnterstuetzung.Location = new System.Drawing.Point(129, 131);
            this.edtUnterstuetzung.LOVName = "KaInizioUnterstuetzung";
            this.edtUnterstuetzung.MultiColumn = true;
            this.edtUnterstuetzung.Name = "edtUnterstuetzung";
            this.edtUnterstuetzung.Size = new System.Drawing.Size(266, 55);
            this.edtUnterstuetzung.TabIndex = 7;
            // 
            // lblWunschKandidatIn
            // 
            this.lblWunschKandidatIn.Location = new System.Drawing.Point(10, 199);
            this.lblWunschKandidatIn.Name = "lblWunschKandidatIn";
            this.lblWunschKandidatIn.Size = new System.Drawing.Size(104, 24);
            this.lblWunschKandidatIn.TabIndex = 8;
            this.lblWunschKandidatIn.Text = "Ausbildungswunsch";
            this.lblWunschKandidatIn.UseCompatibleTextRendering = true;
            // 
            // edtAusbildungWunsch
            // 
            this.edtAusbildungWunsch.DataMember = "AusbildungstypWunschCode";
            this.edtAusbildungWunsch.DataSource = this.qryInizioVermittlung;
            this.edtAusbildungWunsch.Location = new System.Drawing.Point(129, 199);
            this.edtAusbildungWunsch.LOVName = "KaBerufsausbildungTyp";
            this.edtAusbildungWunsch.Name = "edtAusbildungWunsch";
            this.edtAusbildungWunsch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbildungWunsch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbildungWunsch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildungWunsch.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbildungWunsch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbildungWunsch.Properties.Appearance.Options.UseFont = true;
            this.edtAusbildungWunsch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAusbildungWunsch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildungWunsch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAusbildungWunsch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAusbildungWunsch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAusbildungWunsch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAusbildungWunsch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbildungWunsch.Properties.NullText = "";
            this.edtAusbildungWunsch.Properties.ShowFooter = false;
            this.edtAusbildungWunsch.Properties.ShowHeader = false;
            this.edtAusbildungWunsch.Size = new System.Drawing.Size(294, 24);
            this.edtAusbildungWunsch.TabIndex = 9;
            // 
            // lblBerufswunsch
            // 
            this.lblBerufswunsch.Location = new System.Drawing.Point(10, 228);
            this.lblBerufswunsch.Name = "lblBerufswunsch";
            this.lblBerufswunsch.Size = new System.Drawing.Size(80, 25);
            this.lblBerufswunsch.TabIndex = 10;
            this.lblBerufswunsch.Text = "Berufswunsch";
            this.lblBerufswunsch.UseCompatibleTextRendering = true;
            // 
            // edtBerufswunsch
            // 
            this.edtBerufswunsch.DataMember = "LehrberufWunschCode";
            this.edtBerufswunsch.DataSource = this.qryInizioVermittlung;
            this.edtBerufswunsch.Location = new System.Drawing.Point(129, 230);
            this.edtBerufswunsch.LOVName = "KaLehrberuf";
            this.edtBerufswunsch.Name = "edtBerufswunsch";
            this.edtBerufswunsch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBerufswunsch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerufswunsch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerufswunsch.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerufswunsch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerufswunsch.Properties.Appearance.Options.UseFont = true;
            this.edtBerufswunsch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBerufswunsch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerufswunsch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBerufswunsch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBerufswunsch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBerufswunsch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBerufswunsch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBerufswunsch.Properties.NullText = "";
            this.edtBerufswunsch.Properties.ShowFooter = false;
            this.edtBerufswunsch.Properties.ShowHeader = false;
            this.edtBerufswunsch.Size = new System.Drawing.Size(369, 24);
            this.edtBerufswunsch.TabIndex = 11;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(10, 259);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(80, 24);
            this.lblBemerkungen.TabIndex = 12;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryInizioVermittlung;
            this.edtBemerkungen.Location = new System.Drawing.Point(129, 259);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(540, 77);
            this.edtBemerkungen.TabIndex = 13;
            // 
            // lblDatumGespräch
            // 
            this.lblDatumGespräch.Location = new System.Drawing.Point(10, 353);
            this.lblDatumGespräch.Name = "lblDatumGespräch";
            this.lblDatumGespräch.Size = new System.Drawing.Size(89, 24);
            this.lblDatumGespräch.TabIndex = 14;
            this.lblDatumGespräch.Text = "Datum Gespräch";
            this.lblDatumGespräch.UseCompatibleTextRendering = true;
            // 
            // edtGespraechDatum
            // 
            this.edtGespraechDatum.DataMember = "GespraechDatum";
            this.edtGespraechDatum.DataSource = this.qryInizioVermittlung;
            this.edtGespraechDatum.EditValue = null;
            this.edtGespraechDatum.Location = new System.Drawing.Point(129, 353);
            this.edtGespraechDatum.Name = "edtGespraechDatum";
            this.edtGespraechDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGespraechDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGespraechDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGespraechDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGespraechDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGespraechDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGespraechDatum.Properties.Appearance.Options.UseFont = true;
            this.edtGespraechDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGespraechDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGespraechDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGespraechDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGespraechDatum.Properties.ShowToday = false;
            this.edtGespraechDatum.Size = new System.Drawing.Size(103, 24);
            this.edtGespraechDatum.TabIndex = 15;
            // 
            // lblInformationenMatching
            // 
            this.lblInformationenMatching.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblInformationenMatching.Location = new System.Drawing.Point(10, 395);
            this.lblInformationenMatching.Name = "lblInformationenMatching";
            this.lblInformationenMatching.Size = new System.Drawing.Size(199, 16);
            this.lblInformationenMatching.TabIndex = 16;
            this.lblInformationenMatching.Text = "Informationen fürs Matching";
            this.lblInformationenMatching.UseCompatibleTextRendering = true;
            // 
            // lblBranchen
            // 
            this.lblBranchen.Location = new System.Drawing.Point(10, 417);
            this.lblBranchen.Name = "lblBranchen";
            this.lblBranchen.Size = new System.Drawing.Size(80, 24);
            this.lblBranchen.TabIndex = 17;
            this.lblBranchen.Text = "Branchen";
            this.lblBranchen.UseCompatibleTextRendering = true;
            // 
            // edtBranchen
            // 
            this.edtBranchen.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBranchen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBranchen.Appearance.Options.UseBackColor = true;
            this.edtBranchen.Appearance.Options.UseBorderColor = true;
            this.edtBranchen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBranchen.CheckOnClick = true;
            this.edtBranchen.DataMember = "BrancheCodes";
            this.edtBranchen.DataSource = this.qryInizioVermittlung;
            this.edtBranchen.Location = new System.Drawing.Point(129, 417);
            this.edtBranchen.LOVName = "KaBranche";
            this.edtBranchen.MultiColumn = true;
            this.edtBranchen.Name = "edtBranchen";
            this.edtBranchen.Size = new System.Drawing.Size(540, 89);
            this.edtBranchen.TabIndex = 18;
            // 
            // lblLehrberuf
            // 
            this.lblLehrberuf.Location = new System.Drawing.Point(10, 512);
            this.lblLehrberuf.Name = "lblLehrberuf";
            this.lblLehrberuf.Size = new System.Drawing.Size(80, 24);
            this.lblLehrberuf.TabIndex = 19;
            this.lblLehrberuf.Text = "Lehrberuf";
            this.lblLehrberuf.UseCompatibleTextRendering = true;
            // 
            // edtLehrberuf
            // 
            this.edtLehrberuf.DataMember = "LehrberufCode";
            this.edtLehrberuf.DataSource = this.qryInizioVermittlung;
            this.edtLehrberuf.Location = new System.Drawing.Point(129, 512);
            this.edtLehrberuf.LOVName = "KaLehrberuf";
            this.edtLehrberuf.Name = "edtLehrberuf";
            this.edtLehrberuf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLehrberuf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLehrberuf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehrberuf.Properties.Appearance.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLehrberuf.Properties.Appearance.Options.UseFont = true;
            this.edtLehrberuf.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLehrberuf.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLehrberuf.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLehrberuf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtLehrberuf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLehrberuf.Properties.NullText = "";
            this.edtLehrberuf.Properties.ShowFooter = false;
            this.edtLehrberuf.Properties.ShowHeader = false;
            this.edtLehrberuf.Size = new System.Drawing.Size(369, 24);
            this.edtLehrberuf.TabIndex = 20;
            // 
            // btnEinsatzplatzSuchen
            // 
            this.btnEinsatzplatzSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinsatzplatzSuchen.Location = new System.Drawing.Point(545, 512);
            this.btnEinsatzplatzSuchen.Name = "btnEinsatzplatzSuchen";
            this.btnEinsatzplatzSuchen.Size = new System.Drawing.Size(124, 24);
            this.btnEinsatzplatzSuchen.TabIndex = 21;
            this.btnEinsatzplatzSuchen.Text = "Einsatzplatz suchen";
            this.btnEinsatzplatzSuchen.UseCompatibleTextRendering = true;
            this.btnEinsatzplatzSuchen.UseVisualStyleBackColor = false;
            this.btnEinsatzplatzSuchen.Click += new System.EventHandler(this.btnEinsatzplatzSuchen_Click);
            // 
            // CtlKaInizioVermittlungsprofil
            // 
            this.ActiveSQLQuery = this.qryInizioVermittlung;
            this.AutoScroll = true;
            this.Controls.Add(this.btnEinsatzplatzSuchen);
            this.Controls.Add(this.edtLehrberuf);
            this.Controls.Add(this.lblLehrberuf);
            this.Controls.Add(this.edtBranchen);
            this.Controls.Add(this.lblBranchen);
            this.Controls.Add(this.lblInformationenMatching);
            this.Controls.Add(this.edtGespraechDatum);
            this.Controls.Add(this.lblDatumGespräch);
            this.Controls.Add(this.edtBemerkungen);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.edtBerufswunsch);
            this.Controls.Add(this.lblBerufswunsch);
            this.Controls.Add(this.edtAusbildungWunsch);
            this.Controls.Add(this.lblWunschKandidatIn);
            this.Controls.Add(this.edtUnterstuetzung);
            this.Controls.Add(this.lblUnterstützung);
            this.Controls.Add(this.edtMotivation);
            this.Controls.Add(this.lblMotivation);
            this.Controls.Add(this.edtErstgespraech);
            this.Controls.Add(this.lblErstgesprächVerlauf);
            this.Controls.Add(this.lblPersoenlicheInformationen);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaInizioVermittlungsprofil";
            this.Size = new System.Drawing.Size(675, 574);
            this.Load += new System.EventHandler(this.CtlKaInizioVermittlungsprofil_Load);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlicheInformationen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstgesprächVerlauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstgespraech.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInizioVermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstützung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWunschKandidatIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungWunsch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungWunsch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerufswunsch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufswunsch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufswunsch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGespräch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGespraechDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInformationenMatching)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf)).EndInit();
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

        private void CtlKaInizioVermittlungsprofil_Load(object sender, EventArgs e)
        {
            btnEinsatzplatzSuchen.Enabled = DBUtil.UserHasRight("CtlKaInizioVermittlungsprofil", "UI") && (MayUpd || MayIns);

            if (KaUtil.GetSichtbarSDFlag(this.baPersonID) == 1)
            {
                qryInizioVermittlung.EnableBoundFields(false);
                btnEinsatzplatzSuchen.Enabled = false;
            }
        }

        private void btnEinsatzplatzSuchen_Click(object sender, System.EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            if (qryInizioVermittlung.Count > 0)
                FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEPSuchen", "BrancheCodes", qryInizioVermittlung["BrancheCodes"], "LehrberufCode", qryInizioVermittlung["LehrberufCode"]);
            else
                FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEPSuchen");
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
                    return (int) DBUtil.ExecuteScalarSQL("SELECT BaPersonID FROM dbo.FaLeistung WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}", faLeistungID);
                case "KAVERMITTLUNGPROFILID":
                    return qryInizioVermittlung["KaVermittlungProfilID"];
                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("SELECT UserID FROM dbo.FaLeistung WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}", faLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        // ComponentName: qryInizioVermittlung
        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            this.faLeistungID = FaLeistungID;
            this.baPersonID = BaPersonID;

            DBUtil.GetFallRights(this.faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);

            if (!VermittlungExists() && DBUtil.UserHasRight("CtlKaInizioVermittlungsprofil", "UI") && (MayUpd || MayIns))
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.KaVermittlungProfil (FaLeistungID, Creator, Created, Modifier, Modified) 
                    VALUES ({0}, {1}, GETDATE(), {1}, GETDATE())",
                    faLeistungID, 
                    DBUtil.GetDBRowCreatorModifier());
            }

            if (KaUtil.GetSichtbarSDFlag(this.baPersonID) == 1)
            {
                qryInizioVermittlung.Fill(-1);
            }
            else
            {
                qryInizioVermittlung.Fill(faLeistungID);
            }
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // do sorting of LOVs
            edtLehrberuf.SortByFirstColumn();
            edtBerufswunsch.SortByFirstColumn();
        }

        #endregion

        #region Private Methods

        private bool VermittlungExists()
        {
            bool rslt = false;

            rslt =	Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from KaVermittlungProfil where FaLeistungID = {0}",
                this.faLeistungID)
                ) > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}