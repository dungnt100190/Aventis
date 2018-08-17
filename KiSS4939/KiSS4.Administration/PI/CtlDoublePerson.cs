using System;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.PI
{
    public class CtlDoublePerson : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static string PERSONANAMEML = KissMsg.GetMLMessage("CtlDoublePerson", "PersonA", "Person A");
        private static string PERSONBNAMEML = KissMsg.GetMLMessage("CtlDoublePerson", "PersonB", "Person B");

        #endregion

        #region Private Constant/Read-Only Fields

        private const string SQLFORQUERIES = @"
            DECLARE @BaPersonID INT;
            DECLARE @LanguageCode INT;

            SET @BaPersonID = {0};
            SET @LanguageCode = {1};

            SELECT PRS.*,
                   NrNameVorname  = CONVERT(VARCHAR, PRS.BaPersonID) + ' ' + dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                   NameVorname    = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                   Strasse        = ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, ''),
                   Postfach       = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, @LanguageCode),
                   Ort            = dbo.fnGetAdressText(PRS.BaPersonID, 0, 0),
                   WohnsitzBezirk = ADRW.Bezirk,
                   Land           = dbo.fnLandMLText(ADRW.BaLandID, @LanguageCode),
                   Geschlecht     = dbo.fnGetLOVMLText('Geschlecht', PRS.GeschlechtCode, @LanguageCode),
                   Nationalitaet  = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
                   Heimatort      = dbo.fnGetAdressText(PRS.BaPersonID, 0, 3),
                   Zivilstand     = dbo.fnGetLOVMLText('Zivilstand', PRS.ZivilstandCode, @LanguageCode),
                   HauptbehindArt = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
                   BehindArt2     = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.Behinderungsart2Code, @LanguageCode)
            FROM dbo.BaPerson         PRS WITH (READUNCOMMITTED)
              -- wohnsitz
              LEFT JOIN dbo.BaAdresse ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
            WHERE PRS.BaPersonID = @BaPersonID;";

        #endregion

        #region Private Fields

        private int _baPersonID_A = 0;
        private int _baPersonID_B = 0;
        private KiSS4.Gui.KissButton btnMigrateAToB;
        private KiSS4.Gui.KissButton btnMigrateBToA;
        private KiSS4.Gui.KissButton btnResetA;
        private KiSS4.Gui.KissButton btnResetB;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallA;
        private KiSS4.Common.CtlGotoFall ctlGotoFallB;
        private KiSS4.Gui.KissTextEdit edtBaPersonIDA;
        private KiSS4.Gui.KissTextEdit edtBaPersonIDB;
        private KiSS4.Gui.KissTextEdit edtBehinerungsartA;
        private KiSS4.Gui.KissTextEdit edtBehinerungsartB;
        private KiSS4.Gui.KissTextEdit edtBezirkA;
        private KiSS4.Gui.KissTextEdit edtBezirkB;
        private KiSS4.Gui.KissDateEdit edtGeburtstagA;
        private KiSS4.Gui.KissDateEdit edtGeburtstagB;
        private KiSS4.Gui.KissTextEdit edtGeschlechtA;
        private KiSS4.Gui.KissTextEdit edtGeschlechtB;
        private KiSS4.Gui.KissTextEdit edtHauptbehinderungsartA;
        private KiSS4.Gui.KissTextEdit edtHauptbehinderungsartB;
        private KiSS4.Gui.KissTextEdit edtHeimatortA;
        private KiSS4.Gui.KissTextEdit edtHeimatortB;
        private KiSS4.Gui.KissTextEdit edtLandA;
        private KiSS4.Gui.KissTextEdit edtLandB;
        private KiSS4.Gui.KissTextEdit edtNameVornameA;
        private KiSS4.Gui.KissTextEdit edtNameVornameB;
        private KiSS4.Gui.KissTextEdit edtNationalitaetA;
        private KiSS4.Gui.KissTextEdit edtNationalitaetB;
        private KiSS4.Gui.KissButtonEdit edtPersonA;
        private KiSS4.Gui.KissButtonEdit edtPersonB;
        private KiSS4.Gui.KissTextEdit edtPLZOrtA;
        private KiSS4.Gui.KissTextEdit edtPLZOrtB;
        private KiSS4.Gui.KissTextEdit edtPostfachA;
        private KiSS4.Gui.KissTextEdit edtPostfachB;
        private KiSS4.Gui.KissTextEdit edtStrasseNrA;
        private KiSS4.Gui.KissTextEdit edtStrasseNrB;
        private KiSS4.Gui.KissTextEdit edtVersichertenNrA;
        private KiSS4.Gui.KissTextEdit edtVersichertenNrB;
        private KiSS4.Gui.KissTextEdit edtZivilstandA;
        private KiSS4.Gui.KissTextEdit edtZivilstandB;
        private KiSS4.Gui.KissLabel lblAktion;
        private KiSS4.Gui.KissLabel lblBehinderungsart2;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBezirk;
        private KiSS4.Gui.KissLabel lblGeburt;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblHautpbehinderungsart;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblLand;
        private KiSS4.Gui.KissLabel lblNameVorname;
        private KiSS4.Gui.KissLabel lblNationalitaet;
        private KiSS4.Gui.KissLabel lblPersonA;
        private KiSS4.Gui.KissLabel lblPersonB;
        private KiSS4.Gui.KissLabel lblPersonenNr;
        private KiSS4.Gui.KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblPostfach;
        private KiSS4.Gui.KissLabel lblStrasseNr;
        private KiSS4.Gui.KissLabel lblSuchen;
        private KiSS4.Gui.KissLabel lblVersichertenNr;
        private KiSS4.Gui.KissLabel lblZivilstand;
        private KiSS4.Gui.KissRTFEdit memBemerkungenA;
        private KiSS4.Gui.KissRTFEdit memBemerkungenB;
        private KiSS4.DB.SqlQuery qryPersonA;
        private KiSS4.DB.SqlQuery qryPersonB;

        #endregion

        #endregion

        #region Constructors

        public CtlDoublePerson(int baPersonID_A, int baPersonID_B)
            : this()
        {
            _baPersonID_A = baPersonID_A;
            _baPersonID_B = baPersonID_B;
        }

        public CtlDoublePerson()
        {
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDoublePerson));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblPersonA = new KiSS4.Gui.KissLabel();
            this.lblPersonB = new KiSS4.Gui.KissLabel();
            this.lblSuchen = new KiSS4.Gui.KissLabel();
            this.edtPersonA = new KiSS4.Gui.KissButtonEdit();
            this.qryPersonA = new KiSS4.DB.SqlQuery();
            this.btnResetA = new KiSS4.Gui.KissButton();
            this.edtPersonB = new KiSS4.Gui.KissButtonEdit();
            this.qryPersonB = new KiSS4.DB.SqlQuery();
            this.btnResetB = new KiSS4.Gui.KissButton();
            this.lblPersonenNr = new KiSS4.Gui.KissLabel();
            this.edtBaPersonIDA = new KiSS4.Gui.KissTextEdit();
            this.ctlGotoFallA = new KiSS4.Common.CtlGotoFall();
            this.edtBaPersonIDB = new KiSS4.Gui.KissTextEdit();
            this.ctlGotoFallB = new KiSS4.Common.CtlGotoFall();
            this.lblNameVorname = new KiSS4.Gui.KissLabel();
            this.edtNameVornameA = new KiSS4.Gui.KissTextEdit();
            this.edtNameVornameB = new KiSS4.Gui.KissTextEdit();
            this.lblStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtStrasseNrA = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseNrB = new KiSS4.Gui.KissTextEdit();
            this.lblPostfach = new KiSS4.Gui.KissLabel();
            this.edtPostfachA = new KiSS4.Gui.KissTextEdit();
            this.edtPostfachB = new KiSS4.Gui.KissTextEdit();
            this.lblPLZOrt = new KiSS4.Gui.KissLabel();
            this.edtPLZOrtA = new KiSS4.Gui.KissTextEdit();
            this.edtPLZOrtB = new KiSS4.Gui.KissTextEdit();
            this.lblBezirk = new KiSS4.Gui.KissLabel();
            this.edtBezirkA = new KiSS4.Gui.KissTextEdit();
            this.edtBezirkB = new KiSS4.Gui.KissTextEdit();
            this.lblLand = new KiSS4.Gui.KissLabel();
            this.edtLandA = new KiSS4.Gui.KissTextEdit();
            this.edtLandB = new KiSS4.Gui.KissTextEdit();
            this.lblVersichertenNr = new KiSS4.Gui.KissLabel();
            this.edtVersichertenNrA = new KiSS4.Gui.KissTextEdit();
            this.edtVersichertenNrB = new KiSS4.Gui.KissTextEdit();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtGeschlechtA = new KiSS4.Gui.KissTextEdit();
            this.edtGeschlechtB = new KiSS4.Gui.KissTextEdit();
            this.lblGeburt = new KiSS4.Gui.KissLabel();
            this.edtGeburtstagA = new KiSS4.Gui.KissDateEdit();
            this.edtGeburtstagB = new KiSS4.Gui.KissDateEdit();
            this.lblNationalitaet = new KiSS4.Gui.KissLabel();
            this.edtNationalitaetA = new KiSS4.Gui.KissTextEdit();
            this.edtNationalitaetB = new KiSS4.Gui.KissTextEdit();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.edtHeimatortA = new KiSS4.Gui.KissTextEdit();
            this.edtHeimatortB = new KiSS4.Gui.KissTextEdit();
            this.lblZivilstand = new KiSS4.Gui.KissLabel();
            this.edtZivilstandA = new KiSS4.Gui.KissTextEdit();
            this.edtZivilstandB = new KiSS4.Gui.KissTextEdit();
            this.lblHautpbehinderungsart = new KiSS4.Gui.KissLabel();
            this.edtHauptbehinderungsartA = new KiSS4.Gui.KissTextEdit();
            this.edtHauptbehinderungsartB = new KiSS4.Gui.KissTextEdit();
            this.lblBehinderungsart2 = new KiSS4.Gui.KissLabel();
            this.edtBehinerungsartA = new KiSS4.Gui.KissTextEdit();
            this.edtBehinerungsartB = new KiSS4.Gui.KissTextEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.memBemerkungenA = new KiSS4.Gui.KissRTFEdit();
            this.memBemerkungenB = new KiSS4.Gui.KissRTFEdit();
            this.btnMigrateAToB = new KiSS4.Gui.KissButton();
            this.btnMigrateBToA = new KiSS4.Gui.KissButton();
            this.lblAktion = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNrA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNrB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZOrtA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZOrtB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezirkA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezirkB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertenNrA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertenNrB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstagA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstagB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHautpbehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptbehinderungsartA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptbehinderungsartB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBehinderungsart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinerungsartA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinerungsartB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).BeginInit();
            this.SuspendLayout();
            //
            // lblPersonA
            //
            this.lblPersonA.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPersonA.Location = new System.Drawing.Point(168, 10);
            this.lblPersonA.Name = "lblPersonA";
            this.lblPersonA.Size = new System.Drawing.Size(293, 16);
            this.lblPersonA.TabIndex = 0;
            this.lblPersonA.Text = "Person A";
            this.lblPersonA.UseCompatibleTextRendering = true;
            //
            // lblPersonB
            //
            this.lblPersonB.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPersonB.Location = new System.Drawing.Point(481, 10);
            this.lblPersonB.Name = "lblPersonB";
            this.lblPersonB.Size = new System.Drawing.Size(291, 16);
            this.lblPersonB.TabIndex = 1;
            this.lblPersonB.Text = "Person B";
            this.lblPersonB.UseCompatibleTextRendering = true;
            //
            // lblSuchen
            //
            this.lblSuchen.Location = new System.Drawing.Point(5, 36);
            this.lblSuchen.Name = "lblSuchen";
            this.lblSuchen.Size = new System.Drawing.Size(159, 24);
            this.lblSuchen.TabIndex = 2;
            this.lblSuchen.Text = "Nach Nr. od. Name suchen";
            this.lblSuchen.UseCompatibleTextRendering = true;
            //
            // edtPersonA
            //
            this.edtPersonA.DataMember = "NrNameVorname";
            this.edtPersonA.DataSource = this.qryPersonA;
            this.edtPersonA.Location = new System.Drawing.Point(170, 36);
            this.edtPersonA.Name = "edtPersonA";
            this.edtPersonA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonA.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonA.Properties.Appearance.Options.UseFont = true;
            this.edtPersonA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtPersonA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtPersonA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtPersonA.Size = new System.Drawing.Size(261, 24);
            this.edtPersonA.TabIndex = 3;
            this.edtPersonA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtPersonA_UserModifiedFld);
            //
            // qryPersonA
            //
            this.qryPersonA.HostControl = this;
            //
            // btnResetA
            //
            this.btnResetA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetA.IconID = 4;
            this.btnResetA.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResetA.Location = new System.Drawing.Point(437, 36);
            this.btnResetA.Name = "btnResetA";
            this.btnResetA.Size = new System.Drawing.Size(24, 24);
            this.btnResetA.TabIndex = 4;
            this.btnResetA.UseCompatibleTextRendering = true;
            this.btnResetA.UseVisualStyleBackColor = false;
            this.btnResetA.Click += new System.EventHandler(this.btnResetA_Click);
            //
            // edtPersonB
            //
            this.edtPersonB.DataMember = "NrNameVorname";
            this.edtPersonB.DataSource = this.qryPersonB;
            this.edtPersonB.Location = new System.Drawing.Point(481, 36);
            this.edtPersonB.Name = "edtPersonB";
            this.edtPersonB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonB.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonB.Properties.Appearance.Options.UseFont = true;
            this.edtPersonB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtPersonB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtPersonB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonB.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtPersonB.Size = new System.Drawing.Size(261, 24);
            this.edtPersonB.TabIndex = 5;
            this.edtPersonB.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtPersonB_UserModifiedFld);
            //
            // qryPersonB
            //
            this.qryPersonB.HostControl = this;
            //
            // btnResetB
            //
            this.btnResetB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetB.IconID = 4;
            this.btnResetB.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResetB.Location = new System.Drawing.Point(748, 36);
            this.btnResetB.Name = "btnResetB";
            this.btnResetB.Size = new System.Drawing.Size(24, 24);
            this.btnResetB.TabIndex = 6;
            this.btnResetB.UseCompatibleTextRendering = true;
            this.btnResetB.UseVisualStyleBackColor = false;
            this.btnResetB.Click += new System.EventHandler(this.btnResetB_Click);
            //
            // lblPersonenNr
            //
            this.lblPersonenNr.Location = new System.Drawing.Point(5, 70);
            this.lblPersonenNr.Name = "lblPersonenNr";
            this.lblPersonenNr.Size = new System.Drawing.Size(159, 24);
            this.lblPersonenNr.TabIndex = 7;
            this.lblPersonenNr.Text = "Personen-Nr.";
            this.lblPersonenNr.UseCompatibleTextRendering = true;
            //
            // edtBaPersonIDA
            //
            this.edtBaPersonIDA.DataMember = "BaPersonID";
            this.edtBaPersonIDA.DataSource = this.qryPersonA;
            this.edtBaPersonIDA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonIDA.Location = new System.Drawing.Point(170, 70);
            this.edtBaPersonIDA.Name = "edtBaPersonIDA";
            this.edtBaPersonIDA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonIDA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIDA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIDA.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIDA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIDA.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIDA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonIDA.Properties.ReadOnly = true;
            this.edtBaPersonIDA.Size = new System.Drawing.Size(77, 24);
            this.edtBaPersonIDA.TabIndex = 8;
            //
            // ctlGotoFallA
            //
            this.ctlGotoFallA.DataMember = "BaPersonID";
            this.ctlGotoFallA.DataSource = this.qryPersonA;
            this.ctlGotoFallA.Location = new System.Drawing.Point(253, 70);
            this.ctlGotoFallA.Name = "ctlGotoFallA";
            this.ctlGotoFallA.ShowToolTipsOnIcons = true;
            this.ctlGotoFallA.Size = new System.Drawing.Size(208, 24);
            this.ctlGotoFallA.TabIndex = 9;
            //
            // edtBaPersonIDB
            //
            this.edtBaPersonIDB.DataMember = "BaPersonID";
            this.edtBaPersonIDB.DataSource = this.qryPersonB;
            this.edtBaPersonIDB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonIDB.Location = new System.Drawing.Point(481, 70);
            this.edtBaPersonIDB.Name = "edtBaPersonIDB";
            this.edtBaPersonIDB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonIDB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIDB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIDB.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIDB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIDB.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIDB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonIDB.Properties.ReadOnly = true;
            this.edtBaPersonIDB.Size = new System.Drawing.Size(77, 24);
            this.edtBaPersonIDB.TabIndex = 10;
            //
            // ctlGotoFallB
            //
            this.ctlGotoFallB.DataMember = "BaPersonID";
            this.ctlGotoFallB.DataSource = this.qryPersonB;
            this.ctlGotoFallB.Location = new System.Drawing.Point(564, 70);
            this.ctlGotoFallB.Name = "ctlGotoFallB";
            this.ctlGotoFallB.ShowToolTipsOnIcons = true;
            this.ctlGotoFallB.Size = new System.Drawing.Size(208, 24);
            this.ctlGotoFallB.TabIndex = 11;
            //
            // lblNameVorname
            //
            this.lblNameVorname.Location = new System.Drawing.Point(5, 100);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Size = new System.Drawing.Size(159, 24);
            this.lblNameVorname.TabIndex = 12;
            this.lblNameVorname.Text = "Name / Vorname";
            this.lblNameVorname.UseCompatibleTextRendering = true;
            //
            // edtNameVornameA
            //
            this.edtNameVornameA.DataMember = "NameVorname";
            this.edtNameVornameA.DataSource = this.qryPersonA;
            this.edtNameVornameA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameVornameA.Location = new System.Drawing.Point(170, 100);
            this.edtNameVornameA.Name = "edtNameVornameA";
            this.edtNameVornameA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameVornameA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameVornameA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameVornameA.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameVornameA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameVornameA.Properties.Appearance.Options.UseFont = true;
            this.edtNameVornameA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameVornameA.Properties.ReadOnly = true;
            this.edtNameVornameA.Size = new System.Drawing.Size(291, 24);
            this.edtNameVornameA.TabIndex = 13;
            //
            // edtNameVornameB
            //
            this.edtNameVornameB.DataMember = "NameVorname";
            this.edtNameVornameB.DataSource = this.qryPersonB;
            this.edtNameVornameB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameVornameB.Location = new System.Drawing.Point(481, 100);
            this.edtNameVornameB.Name = "edtNameVornameB";
            this.edtNameVornameB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameVornameB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameVornameB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameVornameB.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameVornameB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameVornameB.Properties.Appearance.Options.UseFont = true;
            this.edtNameVornameB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameVornameB.Properties.ReadOnly = true;
            this.edtNameVornameB.Size = new System.Drawing.Size(291, 24);
            this.edtNameVornameB.TabIndex = 14;
            //
            // lblStrasseNr
            //
            this.lblStrasseNr.Location = new System.Drawing.Point(5, 130);
            this.lblStrasseNr.Name = "lblStrasseNr";
            this.lblStrasseNr.Size = new System.Drawing.Size(159, 24);
            this.lblStrasseNr.TabIndex = 15;
            this.lblStrasseNr.Text = "Strasse / Nr.";
            this.lblStrasseNr.UseCompatibleTextRendering = true;
            //
            // edtStrasseNrA
            //
            this.edtStrasseNrA.DataMember = "Strasse";
            this.edtStrasseNrA.DataSource = this.qryPersonA;
            this.edtStrasseNrA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseNrA.Location = new System.Drawing.Point(170, 130);
            this.edtStrasseNrA.Name = "edtStrasseNrA";
            this.edtStrasseNrA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseNrA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseNrA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseNrA.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseNrA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseNrA.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseNrA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseNrA.Properties.ReadOnly = true;
            this.edtStrasseNrA.Size = new System.Drawing.Size(291, 24);
            this.edtStrasseNrA.TabIndex = 16;
            //
            // edtStrasseNrB
            //
            this.edtStrasseNrB.DataMember = "Strasse";
            this.edtStrasseNrB.DataSource = this.qryPersonB;
            this.edtStrasseNrB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseNrB.Location = new System.Drawing.Point(481, 130);
            this.edtStrasseNrB.Name = "edtStrasseNrB";
            this.edtStrasseNrB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseNrB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseNrB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseNrB.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseNrB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseNrB.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseNrB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseNrB.Properties.ReadOnly = true;
            this.edtStrasseNrB.Size = new System.Drawing.Size(291, 24);
            this.edtStrasseNrB.TabIndex = 17;
            //
            // lblPostfach
            //
            this.lblPostfach.Location = new System.Drawing.Point(5, 153);
            this.lblPostfach.Name = "lblPostfach";
            this.lblPostfach.Size = new System.Drawing.Size(159, 24);
            this.lblPostfach.TabIndex = 18;
            this.lblPostfach.Text = "Postfach";
            this.lblPostfach.UseCompatibleTextRendering = true;
            //
            // edtPostfachA
            //
            this.edtPostfachA.DataMember = "Postfach";
            this.edtPostfachA.DataSource = this.qryPersonA;
            this.edtPostfachA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostfachA.Location = new System.Drawing.Point(170, 153);
            this.edtPostfachA.Name = "edtPostfachA";
            this.edtPostfachA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPostfachA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfachA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfachA.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfachA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfachA.Properties.Appearance.Options.UseFont = true;
            this.edtPostfachA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfachA.Properties.ReadOnly = true;
            this.edtPostfachA.Size = new System.Drawing.Size(291, 24);
            this.edtPostfachA.TabIndex = 19;
            //
            // edtPostfachB
            //
            this.edtPostfachB.DataMember = "Postfach";
            this.edtPostfachB.DataSource = this.qryPersonB;
            this.edtPostfachB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostfachB.Location = new System.Drawing.Point(481, 153);
            this.edtPostfachB.Name = "edtPostfachB";
            this.edtPostfachB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPostfachB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfachB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfachB.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfachB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfachB.Properties.Appearance.Options.UseFont = true;
            this.edtPostfachB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfachB.Properties.ReadOnly = true;
            this.edtPostfachB.Size = new System.Drawing.Size(291, 24);
            this.edtPostfachB.TabIndex = 20;
            //
            // lblPLZOrt
            //
            this.lblPLZOrt.Location = new System.Drawing.Point(5, 176);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(159, 24);
            this.lblPLZOrt.TabIndex = 21;
            this.lblPLZOrt.Text = "PLZ / Ort";
            this.lblPLZOrt.UseCompatibleTextRendering = true;
            //
            // edtPLZOrtA
            //
            this.edtPLZOrtA.DataMember = "Ort";
            this.edtPLZOrtA.DataSource = this.qryPersonA;
            this.edtPLZOrtA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZOrtA.Location = new System.Drawing.Point(170, 176);
            this.edtPLZOrtA.Name = "edtPLZOrtA";
            this.edtPLZOrtA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZOrtA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZOrtA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZOrtA.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZOrtA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZOrtA.Properties.Appearance.Options.UseFont = true;
            this.edtPLZOrtA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZOrtA.Properties.ReadOnly = true;
            this.edtPLZOrtA.Size = new System.Drawing.Size(291, 24);
            this.edtPLZOrtA.TabIndex = 22;
            //
            // edtPLZOrtB
            //
            this.edtPLZOrtB.DataMember = "Ort";
            this.edtPLZOrtB.DataSource = this.qryPersonB;
            this.edtPLZOrtB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZOrtB.Location = new System.Drawing.Point(481, 176);
            this.edtPLZOrtB.Name = "edtPLZOrtB";
            this.edtPLZOrtB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZOrtB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZOrtB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZOrtB.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZOrtB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZOrtB.Properties.Appearance.Options.UseFont = true;
            this.edtPLZOrtB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZOrtB.Properties.ReadOnly = true;
            this.edtPLZOrtB.Size = new System.Drawing.Size(291, 24);
            this.edtPLZOrtB.TabIndex = 23;
            //
            // lblBezirk
            //
            this.lblBezirk.Location = new System.Drawing.Point(6, 199);
            this.lblBezirk.Name = "lblBezirk";
            this.lblBezirk.Size = new System.Drawing.Size(159, 24);
            this.lblBezirk.TabIndex = 24;
            this.lblBezirk.Text = "Bezirk";
            this.lblBezirk.UseCompatibleTextRendering = true;
            //
            // edtBezirkA
            //
            this.edtBezirkA.DataMember = "WohnsitzBezirk";
            this.edtBezirkA.DataSource = this.qryPersonA;
            this.edtBezirkA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBezirkA.Location = new System.Drawing.Point(170, 199);
            this.edtBezirkA.Name = "edtBezirkA";
            this.edtBezirkA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBezirkA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezirkA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezirkA.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezirkA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezirkA.Properties.Appearance.Options.UseFont = true;
            this.edtBezirkA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezirkA.Properties.ReadOnly = true;
            this.edtBezirkA.Size = new System.Drawing.Size(291, 24);
            this.edtBezirkA.TabIndex = 25;
            //
            // edtBezirkB
            //
            this.edtBezirkB.DataMember = "WohnsitzBezirk";
            this.edtBezirkB.DataSource = this.qryPersonB;
            this.edtBezirkB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBezirkB.Location = new System.Drawing.Point(481, 199);
            this.edtBezirkB.Name = "edtBezirkB";
            this.edtBezirkB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBezirkB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezirkB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezirkB.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezirkB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezirkB.Properties.Appearance.Options.UseFont = true;
            this.edtBezirkB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezirkB.Properties.ReadOnly = true;
            this.edtBezirkB.Size = new System.Drawing.Size(291, 24);
            this.edtBezirkB.TabIndex = 26;
            //
            // lblLand
            //
            this.lblLand.Location = new System.Drawing.Point(5, 228);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(159, 24);
            this.lblLand.TabIndex = 27;
            this.lblLand.Text = "Land";
            this.lblLand.UseCompatibleTextRendering = true;
            //
            // edtLandA
            //
            this.edtLandA.DataMember = "Land";
            this.edtLandA.DataSource = this.qryPersonA;
            this.edtLandA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLandA.Location = new System.Drawing.Point(170, 228);
            this.edtLandA.Name = "edtLandA";
            this.edtLandA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLandA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLandA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLandA.Properties.Appearance.Options.UseBackColor = true;
            this.edtLandA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLandA.Properties.Appearance.Options.UseFont = true;
            this.edtLandA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLandA.Properties.ReadOnly = true;
            this.edtLandA.Size = new System.Drawing.Size(291, 24);
            this.edtLandA.TabIndex = 28;
            //
            // edtLandB
            //
            this.edtLandB.DataMember = "Land";
            this.edtLandB.DataSource = this.qryPersonB;
            this.edtLandB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLandB.Location = new System.Drawing.Point(481, 228);
            this.edtLandB.Name = "edtLandB";
            this.edtLandB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLandB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLandB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLandB.Properties.Appearance.Options.UseBackColor = true;
            this.edtLandB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLandB.Properties.Appearance.Options.UseFont = true;
            this.edtLandB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLandB.Properties.ReadOnly = true;
            this.edtLandB.Size = new System.Drawing.Size(291, 24);
            this.edtLandB.TabIndex = 29;
            //
            // lblVersichertenNr
            //
            this.lblVersichertenNr.Location = new System.Drawing.Point(6, 258);
            this.lblVersichertenNr.Name = "lblVersichertenNr";
            this.lblVersichertenNr.Size = new System.Drawing.Size(159, 24);
            this.lblVersichertenNr.TabIndex = 33;
            this.lblVersichertenNr.Text = "Versicherten-Nummer";
            this.lblVersichertenNr.UseCompatibleTextRendering = true;
            //
            // edtVersichertenNrA
            //
            this.edtVersichertenNrA.DataMember = "VersichertenNummer";
            this.edtVersichertenNrA.DataSource = this.qryPersonA;
            this.edtVersichertenNrA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersichertenNrA.Location = new System.Drawing.Point(170, 258);
            this.edtVersichertenNrA.Name = "edtVersichertenNrA";
            this.edtVersichertenNrA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersichertenNrA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertenNrA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertenNrA.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertenNrA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertenNrA.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertenNrA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertenNrA.Properties.ReadOnly = true;
            this.edtVersichertenNrA.Size = new System.Drawing.Size(291, 24);
            this.edtVersichertenNrA.TabIndex = 34;
            //
            // edtVersichertenNrB
            //
            this.edtVersichertenNrB.DataMember = "VersichertenNummer";
            this.edtVersichertenNrB.DataSource = this.qryPersonB;
            this.edtVersichertenNrB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersichertenNrB.Location = new System.Drawing.Point(481, 258);
            this.edtVersichertenNrB.Name = "edtVersichertenNrB";
            this.edtVersichertenNrB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersichertenNrB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertenNrB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertenNrB.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertenNrB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertenNrB.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertenNrB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertenNrB.Properties.ReadOnly = true;
            this.edtVersichertenNrB.Size = new System.Drawing.Size(291, 24);
            this.edtVersichertenNrB.TabIndex = 35;
            //
            // lblGeschlecht
            //
            this.lblGeschlecht.Location = new System.Drawing.Point(5, 288);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(159, 24);
            this.lblGeschlecht.TabIndex = 36;
            this.lblGeschlecht.Text = "Geschlecht";
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            //
            // edtGeschlechtA
            //
            this.edtGeschlechtA.DataMember = "Geschlecht";
            this.edtGeschlechtA.DataSource = this.qryPersonA;
            this.edtGeschlechtA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeschlechtA.Location = new System.Drawing.Point(170, 288);
            this.edtGeschlechtA.Name = "edtGeschlechtA";
            this.edtGeschlechtA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeschlechtA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtA.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtA.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeschlechtA.Properties.ReadOnly = true;
            this.edtGeschlechtA.Size = new System.Drawing.Size(291, 24);
            this.edtGeschlechtA.TabIndex = 37;
            //
            // edtGeschlechtB
            //
            this.edtGeschlechtB.DataMember = "Geschlecht";
            this.edtGeschlechtB.DataSource = this.qryPersonB;
            this.edtGeschlechtB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeschlechtB.Location = new System.Drawing.Point(481, 288);
            this.edtGeschlechtB.Name = "edtGeschlechtB";
            this.edtGeschlechtB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeschlechtB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtB.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtB.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeschlechtB.Properties.ReadOnly = true;
            this.edtGeschlechtB.Size = new System.Drawing.Size(291, 24);
            this.edtGeschlechtB.TabIndex = 38;
            //
            // lblGeburt
            //
            this.lblGeburt.Location = new System.Drawing.Point(5, 318);
            this.lblGeburt.Name = "lblGeburt";
            this.lblGeburt.Size = new System.Drawing.Size(159, 24);
            this.lblGeburt.TabIndex = 39;
            this.lblGeburt.Text = "Geburt";
            this.lblGeburt.UseCompatibleTextRendering = true;
            //
            // edtGeburtstagA
            //
            this.edtGeburtstagA.DataMember = "Geburtsdatum";
            this.edtGeburtstagA.DataSource = this.qryPersonA;
            this.edtGeburtstagA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtstagA.EditValue = null;
            this.edtGeburtstagA.Location = new System.Drawing.Point(170, 318);
            this.edtGeburtstagA.Name = "edtGeburtstagA";
            this.edtGeburtstagA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtstagA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtstagA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtstagA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtstagA.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtstagA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtstagA.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtstagA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtstagA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtstagA.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtstagA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtstagA.Properties.ReadOnly = true;
            this.edtGeburtstagA.Properties.ShowToday = false;
            this.edtGeburtstagA.Size = new System.Drawing.Size(119, 24);
            this.edtGeburtstagA.TabIndex = 40;
            //
            // edtGeburtstagB
            //
            this.edtGeburtstagB.DataMember = "Geburtsdatum";
            this.edtGeburtstagB.DataSource = this.qryPersonB;
            this.edtGeburtstagB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtstagB.EditValue = null;
            this.edtGeburtstagB.Location = new System.Drawing.Point(481, 318);
            this.edtGeburtstagB.Name = "edtGeburtstagB";
            this.edtGeburtstagB.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtstagB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtstagB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtstagB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtstagB.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtstagB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtstagB.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtstagB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtstagB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtstagB.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtstagB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtstagB.Properties.ReadOnly = true;
            this.edtGeburtstagB.Properties.ShowToday = false;
            this.edtGeburtstagB.Size = new System.Drawing.Size(119, 24);
            this.edtGeburtstagB.TabIndex = 41;
            //
            // lblNationalitaet
            //
            this.lblNationalitaet.Location = new System.Drawing.Point(5, 348);
            this.lblNationalitaet.Name = "lblNationalitaet";
            this.lblNationalitaet.Size = new System.Drawing.Size(159, 24);
            this.lblNationalitaet.TabIndex = 42;
            this.lblNationalitaet.Text = "Nationalität";
            this.lblNationalitaet.UseCompatibleTextRendering = true;
            //
            // edtNationalitaetA
            //
            this.edtNationalitaetA.DataMember = "Nationalitaet";
            this.edtNationalitaetA.DataSource = this.qryPersonA;
            this.edtNationalitaetA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNationalitaetA.Location = new System.Drawing.Point(170, 348);
            this.edtNationalitaetA.Name = "edtNationalitaetA";
            this.edtNationalitaetA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationalitaetA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaetA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetA.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaetA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaetA.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaetA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNationalitaetA.Properties.ReadOnly = true;
            this.edtNationalitaetA.Size = new System.Drawing.Size(291, 24);
            this.edtNationalitaetA.TabIndex = 43;
            //
            // edtNationalitaetB
            //
            this.edtNationalitaetB.DataMember = "Nationalitaet";
            this.edtNationalitaetB.DataSource = this.qryPersonB;
            this.edtNationalitaetB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNationalitaetB.Location = new System.Drawing.Point(481, 348);
            this.edtNationalitaetB.Name = "edtNationalitaetB";
            this.edtNationalitaetB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationalitaetB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaetB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetB.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaetB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaetB.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaetB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNationalitaetB.Properties.ReadOnly = true;
            this.edtNationalitaetB.Size = new System.Drawing.Size(291, 24);
            this.edtNationalitaetB.TabIndex = 44;
            //
            // lblHeimatort
            //
            this.lblHeimatort.Location = new System.Drawing.Point(5, 371);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(159, 24);
            this.lblHeimatort.TabIndex = 45;
            this.lblHeimatort.Text = "Heimatort";
            this.lblHeimatort.UseCompatibleTextRendering = true;
            //
            // edtHeimatortA
            //
            this.edtHeimatortA.DataMember = "Heimatort";
            this.edtHeimatortA.DataSource = this.qryPersonA;
            this.edtHeimatortA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHeimatortA.Location = new System.Drawing.Point(170, 371);
            this.edtHeimatortA.Name = "edtHeimatortA";
            this.edtHeimatortA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHeimatortA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatortA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatortA.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatortA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatortA.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatortA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatortA.Properties.ReadOnly = true;
            this.edtHeimatortA.Size = new System.Drawing.Size(291, 24);
            this.edtHeimatortA.TabIndex = 46;
            //
            // edtHeimatortB
            //
            this.edtHeimatortB.DataMember = "Heimatort";
            this.edtHeimatortB.DataSource = this.qryPersonB;
            this.edtHeimatortB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHeimatortB.Location = new System.Drawing.Point(481, 371);
            this.edtHeimatortB.Name = "edtHeimatortB";
            this.edtHeimatortB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHeimatortB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatortB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatortB.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatortB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatortB.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatortB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatortB.Properties.ReadOnly = true;
            this.edtHeimatortB.Size = new System.Drawing.Size(291, 24);
            this.edtHeimatortB.TabIndex = 47;
            //
            // lblZivilstand
            //
            this.lblZivilstand.Location = new System.Drawing.Point(5, 394);
            this.lblZivilstand.Name = "lblZivilstand";
            this.lblZivilstand.Size = new System.Drawing.Size(159, 24);
            this.lblZivilstand.TabIndex = 48;
            this.lblZivilstand.Text = "Zivilstand";
            this.lblZivilstand.UseCompatibleTextRendering = true;
            //
            // edtZivilstandA
            //
            this.edtZivilstandA.DataMember = "Zivilstand";
            this.edtZivilstandA.DataSource = this.qryPersonA;
            this.edtZivilstandA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZivilstandA.Location = new System.Drawing.Point(170, 394);
            this.edtZivilstandA.Name = "edtZivilstandA";
            this.edtZivilstandA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZivilstandA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandA.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZivilstandA.Properties.ReadOnly = true;
            this.edtZivilstandA.Size = new System.Drawing.Size(291, 24);
            this.edtZivilstandA.TabIndex = 49;
            //
            // edtZivilstandB
            //
            this.edtZivilstandB.DataMember = "Zivilstand";
            this.edtZivilstandB.DataSource = this.qryPersonB;
            this.edtZivilstandB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZivilstandB.Location = new System.Drawing.Point(481, 394);
            this.edtZivilstandB.Name = "edtZivilstandB";
            this.edtZivilstandB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZivilstandB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandB.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandB.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZivilstandB.Properties.ReadOnly = true;
            this.edtZivilstandB.Size = new System.Drawing.Size(291, 24);
            this.edtZivilstandB.TabIndex = 50;
            //
            // lblHautpbehinderungsart
            //
            this.lblHautpbehinderungsart.Location = new System.Drawing.Point(6, 424);
            this.lblHautpbehinderungsart.Name = "lblHautpbehinderungsart";
            this.lblHautpbehinderungsart.Size = new System.Drawing.Size(159, 24);
            this.lblHautpbehinderungsart.TabIndex = 51;
            this.lblHautpbehinderungsart.Text = "Hauptbehinderungsart";
            this.lblHautpbehinderungsart.UseCompatibleTextRendering = true;
            //
            // edtHauptbehinderungsartA
            //
            this.edtHauptbehinderungsartA.DataMember = "HauptbehindArt";
            this.edtHauptbehinderungsartA.DataSource = this.qryPersonA;
            this.edtHauptbehinderungsartA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHauptbehinderungsartA.Location = new System.Drawing.Point(170, 424);
            this.edtHauptbehinderungsartA.Name = "edtHauptbehinderungsartA";
            this.edtHauptbehinderungsartA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHauptbehinderungsartA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHauptbehinderungsartA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHauptbehinderungsartA.Properties.Appearance.Options.UseBackColor = true;
            this.edtHauptbehinderungsartA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHauptbehinderungsartA.Properties.Appearance.Options.UseFont = true;
            this.edtHauptbehinderungsartA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHauptbehinderungsartA.Properties.ReadOnly = true;
            this.edtHauptbehinderungsartA.Size = new System.Drawing.Size(291, 24);
            this.edtHauptbehinderungsartA.TabIndex = 52;
            //
            // edtHauptbehinderungsartB
            //
            this.edtHauptbehinderungsartB.DataMember = "HauptbehindArt";
            this.edtHauptbehinderungsartB.DataSource = this.qryPersonB;
            this.edtHauptbehinderungsartB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHauptbehinderungsartB.Location = new System.Drawing.Point(481, 424);
            this.edtHauptbehinderungsartB.Name = "edtHauptbehinderungsartB";
            this.edtHauptbehinderungsartB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHauptbehinderungsartB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHauptbehinderungsartB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHauptbehinderungsartB.Properties.Appearance.Options.UseBackColor = true;
            this.edtHauptbehinderungsartB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHauptbehinderungsartB.Properties.Appearance.Options.UseFont = true;
            this.edtHauptbehinderungsartB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHauptbehinderungsartB.Properties.ReadOnly = true;
            this.edtHauptbehinderungsartB.Size = new System.Drawing.Size(291, 24);
            this.edtHauptbehinderungsartB.TabIndex = 53;
            //
            // lblBehinderungsart2
            //
            this.lblBehinderungsart2.Location = new System.Drawing.Point(6, 447);
            this.lblBehinderungsart2.Name = "lblBehinderungsart2";
            this.lblBehinderungsart2.Size = new System.Drawing.Size(159, 24);
            this.lblBehinderungsart2.TabIndex = 54;
            this.lblBehinderungsart2.Text = "Behinderungsart 2";
            this.lblBehinderungsart2.UseCompatibleTextRendering = true;
            //
            // edtBehinerungsartA
            //
            this.edtBehinerungsartA.DataMember = "BehindArt2";
            this.edtBehinerungsartA.DataSource = this.qryPersonA;
            this.edtBehinerungsartA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBehinerungsartA.Location = new System.Drawing.Point(170, 447);
            this.edtBehinerungsartA.Name = "edtBehinerungsartA";
            this.edtBehinerungsartA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBehinerungsartA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBehinerungsartA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBehinerungsartA.Properties.Appearance.Options.UseBackColor = true;
            this.edtBehinerungsartA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBehinerungsartA.Properties.Appearance.Options.UseFont = true;
            this.edtBehinerungsartA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBehinerungsartA.Properties.ReadOnly = true;
            this.edtBehinerungsartA.Size = new System.Drawing.Size(291, 24);
            this.edtBehinerungsartA.TabIndex = 55;
            //
            // edtBehinerungsartB
            //
            this.edtBehinerungsartB.DataMember = "BehindArt2";
            this.edtBehinerungsartB.DataSource = this.qryPersonB;
            this.edtBehinerungsartB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBehinerungsartB.Location = new System.Drawing.Point(481, 447);
            this.edtBehinerungsartB.Name = "edtBehinerungsartB";
            this.edtBehinerungsartB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBehinerungsartB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBehinerungsartB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBehinerungsartB.Properties.Appearance.Options.UseBackColor = true;
            this.edtBehinerungsartB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBehinerungsartB.Properties.Appearance.Options.UseFont = true;
            this.edtBehinerungsartB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBehinerungsartB.Properties.ReadOnly = true;
            this.edtBehinerungsartB.Size = new System.Drawing.Size(291, 24);
            this.edtBehinerungsartB.TabIndex = 56;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Location = new System.Drawing.Point(6, 477);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(159, 24);
            this.lblBemerkungen.TabIndex = 57;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // memBemerkungenA
            //
            this.memBemerkungenA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkungenA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memBemerkungenA.DataMember = "Bemerkung";
            this.memBemerkungenA.DataSource = this.qryPersonA;
            this.memBemerkungenA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memBemerkungenA.Font = new System.Drawing.Font("Arial", 10F);
            this.memBemerkungenA.Location = new System.Drawing.Point(170, 477);
            this.memBemerkungenA.Name = "memBemerkungenA";
            this.memBemerkungenA.ReadOnly = true;
            this.memBemerkungenA.Size = new System.Drawing.Size(291, 49);
            this.memBemerkungenA.TabIndex = 58;
            //
            // memBemerkungenB
            //
            this.memBemerkungenB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkungenB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memBemerkungenB.DataMember = "Bemerkung";
            this.memBemerkungenB.DataSource = this.qryPersonB;
            this.memBemerkungenB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memBemerkungenB.Font = new System.Drawing.Font("Arial", 10F);
            this.memBemerkungenB.Location = new System.Drawing.Point(481, 477);
            this.memBemerkungenB.Name = "memBemerkungenB";
            this.memBemerkungenB.ReadOnly = true;
            this.memBemerkungenB.Size = new System.Drawing.Size(291, 49);
            this.memBemerkungenB.TabIndex = 59;
            //
            // btnMigrateAToB
            //
            this.btnMigrateAToB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMigrateAToB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMigrateAToB.IconID = 13;
            this.btnMigrateAToB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMigrateAToB.Location = new System.Drawing.Point(170, 535);
            this.btnMigrateAToB.Name = "btnMigrateAToB";
            this.btnMigrateAToB.Size = new System.Drawing.Size(291, 24);
            this.btnMigrateAToB.TabIndex = 60;
            this.btnMigrateAToB.Text = "Person A löschen und Daten zu B migrieren";
            this.btnMigrateAToB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMigrateAToB.UseCompatibleTextRendering = true;
            this.btnMigrateAToB.UseVisualStyleBackColor = false;
            this.btnMigrateAToB.Click += new System.EventHandler(this.btnMigrateAToB_Click);
            //
            // btnMigrateBToA
            //
            this.btnMigrateBToA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMigrateBToA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMigrateBToA.IconID = 11;
            this.btnMigrateBToA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMigrateBToA.Location = new System.Drawing.Point(481, 535);
            this.btnMigrateBToA.Name = "btnMigrateBToA";
            this.btnMigrateBToA.Size = new System.Drawing.Size(291, 24);
            this.btnMigrateBToA.TabIndex = 61;
            this.btnMigrateBToA.Text = "Person B löschen und Daten zu A migrieren";
            this.btnMigrateBToA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMigrateBToA.UseCompatibleTextRendering = true;
            this.btnMigrateBToA.UseVisualStyleBackColor = false;
            this.btnMigrateBToA.Click += new System.EventHandler(this.btnMigrateBToA_Click);
            //
            // lblAktion
            //
            this.lblAktion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAktion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAktion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAktion.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAktion.Location = new System.Drawing.Point(0, 562);
            this.lblAktion.Name = "lblAktion";
            this.lblAktion.Size = new System.Drawing.Size(787, 52);
            this.lblAktion.TabIndex = 62;
            this.lblAktion.Text = "";
            this.lblAktion.UseCompatibleTextRendering = true;
            //
            // CtlDoublePerson
            //
            this.Controls.Add(this.btnMigrateBToA);
            this.Controls.Add(this.btnMigrateAToB);
            this.Controls.Add(this.memBemerkungenB);
            this.Controls.Add(this.memBemerkungenA);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.edtBehinerungsartB);
            this.Controls.Add(this.edtBehinerungsartA);
            this.Controls.Add(this.lblBehinderungsart2);
            this.Controls.Add(this.edtHauptbehinderungsartB);
            this.Controls.Add(this.edtHauptbehinderungsartA);
            this.Controls.Add(this.lblHautpbehinderungsart);
            this.Controls.Add(this.edtZivilstandB);
            this.Controls.Add(this.edtZivilstandA);
            this.Controls.Add(this.lblZivilstand);
            this.Controls.Add(this.edtHeimatortB);
            this.Controls.Add(this.edtHeimatortA);
            this.Controls.Add(this.lblHeimatort);
            this.Controls.Add(this.edtNationalitaetB);
            this.Controls.Add(this.edtNationalitaetA);
            this.Controls.Add(this.lblNationalitaet);
            this.Controls.Add(this.edtGeburtstagB);
            this.Controls.Add(this.edtGeburtstagA);
            this.Controls.Add(this.lblGeburt);
            this.Controls.Add(this.edtGeschlechtB);
            this.Controls.Add(this.edtGeschlechtA);
            this.Controls.Add(this.lblGeschlecht);
            this.Controls.Add(this.edtVersichertenNrB);
            this.Controls.Add(this.edtVersichertenNrA);
            this.Controls.Add(this.lblVersichertenNr);
            this.Controls.Add(this.edtLandB);
            this.Controls.Add(this.edtLandA);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.edtBezirkB);
            this.Controls.Add(this.edtBezirkA);
            this.Controls.Add(this.lblBezirk);
            this.Controls.Add(this.edtPLZOrtB);
            this.Controls.Add(this.edtPLZOrtA);
            this.Controls.Add(this.lblPLZOrt);
            this.Controls.Add(this.edtPostfachB);
            this.Controls.Add(this.edtPostfachA);
            this.Controls.Add(this.lblPostfach);
            this.Controls.Add(this.edtStrasseNrB);
            this.Controls.Add(this.edtStrasseNrA);
            this.Controls.Add(this.lblStrasseNr);
            this.Controls.Add(this.edtNameVornameB);
            this.Controls.Add(this.edtNameVornameA);
            this.Controls.Add(this.lblNameVorname);
            this.Controls.Add(this.ctlGotoFallB);
            this.Controls.Add(this.edtBaPersonIDB);
            this.Controls.Add(this.ctlGotoFallA);
            this.Controls.Add(this.edtBaPersonIDA);
            this.Controls.Add(this.lblPersonenNr);
            this.Controls.Add(this.btnResetB);
            this.Controls.Add(this.edtPersonB);
            this.Controls.Add(this.btnResetA);
            this.Controls.Add(this.edtPersonA);
            this.Controls.Add(this.lblSuchen);
            this.Controls.Add(this.lblPersonB);
            this.Controls.Add(this.lblPersonA);
            this.Controls.Add(this.lblAktion);
            this.Name = "CtlDoublePerson";
            this.Size = new System.Drawing.Size(787, 614);
            this.Load += new System.EventHandler(this.CtlDoublePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNrA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNrB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZOrtA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZOrtB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezirkA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezirkB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertenNrA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertenNrB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstagA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstagB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHautpbehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptbehinderungsartA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptbehinderungsartB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBehinderungsart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinerungsartA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinerungsartB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).EndInit();
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

        private void btnMigrateAToB_Click(object sender, EventArgs e)
        {
            // migrate data
            Migrate(_baPersonID_B, _baPersonID_A, PERSONBNAMEML, PERSONANAMEML);

            // refresh view
            OnRefreshData();
        }

        private void btnMigrateBToA_Click(object sender, EventArgs e)
        {
            // migrate data
            Migrate(_baPersonID_A, _baPersonID_B, PERSONANAMEML, PERSONBNAMEML);

            // refresh view
            OnRefreshData();
        }

        private void btnResetA_Click(object sender, EventArgs e)
        {
            // reset value for A
            _baPersonID_A = 0;
            OnRefreshData();

            //  focus
            edtPersonA.Focus();
        }

        private void btnResetB_Click(object sender, EventArgs e)
        {
            // reset value for B
            _baPersonID_B = 0;
            OnRefreshData();

            //  focus
            edtPersonB.Focus();
        }

        private void CtlDoublePerson_Load(object sender, EventArgs e)
        {
            lblAktion.Text = "";

            OnRefreshData();
        }

        private void edtPersonA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            edtPersonID_UserModifiedFld(sender, e);
        }

        private void edtPersonB_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            edtPersonID_UserModifiedFld(sender, e);
        }

        private void edtPersonID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();

            try
            {
                e.Cancel = !dlg.PersonSuchenKGS(((KissButtonEdit)sender).Text, e.ButtonClicked);

                if (e.Cancel)
                {
                    return;
                }

                if (sender == edtPersonA)
                {
                    _baPersonID_A = 0;
                    _baPersonID_A = Convert.ToInt32(dlg["BaPersonID"]);
                }
                else if (sender == edtPersonB)
                {
                    _baPersonID_B = 0;
                    _baPersonID_B = Convert.ToInt32(dlg["BaPersonID"]);
                }
            }
            catch { }

            OnRefreshData();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            base.OnRefreshData();

            qryPersonA.Fill(SQLFORQUERIES, _baPersonID_A, Session.User.LanguageCode);
            qryPersonB.Fill(SQLFORQUERIES, _baPersonID_B, Session.User.LanguageCode);

            if (qryPersonA.Count == 0)
            {
                qryPersonA.Insert(null);
            }

            if (qryPersonB.Count == 0)
            {
                qryPersonB.Insert(null);
            }

            btnMigrateAToB.Enabled = !DBUtil.IsEmpty(qryPersonA["BaPersonID"]) && !DBUtil.IsEmpty(qryPersonB["BaPersonID"]);
            btnMigrateBToA.Enabled = btnMigrateAToB.Enabled;
        }

        #endregion

        #region Private Static Methods

        private static bool PreventMigrateDifferentOrgUnits(int baPersonId, int baPersonIdDelete)
        {
            var userHasSpecialRight = DBUtil.UserHasRight("ADMDatenbereinigungPersonenAlleAbteilungen");

            if (userHasSpecialRight || Session.User.IsUserAdmin)
            {
                // if orgunit is not required or user has specialright assigned or is admin, merging is always possible
                return false;
            }

            // get orgunits (KGS) of persons (if empty, the kgs is handled as different (-2) > usersKGS can be "-1")
            var qryBaPersonOrgUnits = DBUtil.OpenSQL(@"
                SELECT KGSOrgUnitID_A = ISNULL((SELECT CONVERT(INT, dbo.fnGetHistKGSOfUserOrOrgUnit(LEI.UserID, GETDATE(), NULL, 1, 1))
                                                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                WHERE LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID({0}, 2)), -2),
                       PersonHasLEI_A = CASE
                                          WHEN EXISTS (SELECT TOP 1 1
                                                       FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                       WHERE LEI.BaPersonID = {0}) THEN 1
                                          ELSE 0
                                        END,
                       --
                       KGSOrgUnitID_B = ISNULL((SELECT CONVERT(INT, dbo.fnGetHistKGSOfUserOrOrgUnit(LEI.UserID, GETDATE(), NULL, 1, 1))
                                                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                WHERE LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID({1}, 2)), -2),
                       PersonHasLEI_B = CASE
                                          WHEN EXISTS (SELECT TOP 1 1
                                                       FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                       WHERE LEI.BaPersonID = {1}) THEN 1
                                          ELSE 0
                                        END;", baPersonId, baPersonIdDelete);

            // get orgunit (KGS) of persons
            int personAOrgUnitID = Convert.ToInt32(qryBaPersonOrgUnits["KGSOrgUnitID_A"]);
            bool personAHasLEI = Convert.ToBoolean(qryBaPersonOrgUnits["PersonHasLEI_A"]);

            int personBOrgUnitID = Convert.ToInt32(qryBaPersonOrgUnits["KGSOrgUnitID_B"]);
            bool personBHasLEI = Convert.ToBoolean(qryBaPersonOrgUnits["PersonHasLEI_B"]);

            // get user's KGS-OrgUnitID
            int userKGSOrgUnitID = Common.PI.XUtils.GetUserKGSOrgUnitID();

            // check if one person does not have LEI --> person is a "Bezugsperson" and therefore merging is always possible (see #6932)
            // otherwise: compare orgunits to validate if migration can be performed
            if ((!personAHasLEI && !personBHasLEI) ||
                (!personAHasLEI && userKGSOrgUnitID == personBOrgUnitID) ||
                (!personBHasLEI && userKGSOrgUnitID == personAOrgUnitID) ||
                (userKGSOrgUnitID == personAOrgUnitID && userKGSOrgUnitID == personBOrgUnitID))
            {
                // merge can be executed because of "Bezugsperson" or because of matching orgunits
                return false;
            }

            // prevent merge because of different orgunits and no rights therefore
            return true;
        }

        #endregion

        #region Private Methods

        private void Migrate(int baPersonId, int baPersonIdDelete, string person, string personDelete)
        {
            // validate if defined
            if (baPersonId == 0 || baPersonIdDelete == 0)
            {
                KissMsg.ShowInfo(Name, "PersonABLeer", "Person A und Person B müssen ausgefüllt sein!");
                return;
            }

            // validate if same
            if (baPersonId == baPersonIdDelete)
            {
                KissMsg.ShowInfo(Name, "PersonABIdentisch_v01", "Person A und Person B sind identisch (gleiche Nr.)!");
                return;
            }

            // check if different orgunits can be merged (see: #6932)
            if (PreventMigrateDifferentOrgUnits(baPersonId, baPersonIdDelete))
            {
                KissMsg.ShowInfo(Name,
                                 "PersonABDifferentOrgUnit_v01",
                                 "Die Personen A und B dürfen von Ihnen aufgrund der aktuellen KGS-Zuordnung nicht zusammengeführt werden!");
                return;
            }

            // check if two active Fallverlauf items exist
            var bothPersonsOpenFV = Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                -- declare vars
                DECLARE @cntOpenFV INT;

                -- get open FV for persons
                SELECT @cntOpenFV = COUNT(1)
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE ModulID = 2 AND
                      DatumBis IS NULL AND
                      BaPersonID IN ({0}, {1});

                -- validate
                IF (ISNULL(@cntOpenFV, 0) > 1)
                BEGIN
                  -- more than one open FV exists
                  SELECT 1;
                END
                ELSE
                BEGIN
                  -- none or just one open FV
                  SELECT 0;
                END;", baPersonId, baPersonIdDelete));

            if (bothPersonsOpenFV)
            {
                KissMsg.ShowInfo(Name,
                                 "PersonABOpenFV_v01",
                                 "Person A und Person B haben beide einen offenen Fallverlauf. Es darf nur ein offener Fallverlauf vorhanden sein!");
                return;
            }

            // confirm before merge
            if (!KissMsg.ShowQuestion(Name,
                                      "StammdatenWerdenGeloescht",
                                      "Achtung: Die Stammdaten der {0} werden gelöscht und alle Falldaten der {1} zugeordnet.\r\n\r\nSoll diese Aktion durchgeführt werden?", 0, 0, false, personDelete, person))
            {
                return;
            }

            // get ready
            ApplicationFacade.DoEvents();
            Cursor currentCursor = Cursor.Current;

            // start
            Session.BeginTransaction();

            try
            {
                // show cursor
                Cursor.Current = Cursors.WaitCursor;

                // new history
                DBUtil.NewHistoryVersion();

                // Adresses
                lblAktion.Text = KissMsg.GetMLMessage(Name, "ActionAdressen", "Info: Adressen bereinigen...");
                ApplicationFacade.DoEvents();

                DBUtil.ExecSQLThrowingException(60, @"
                    -- delete all addresses of the person
                    DELETE ADR
                    FROM dbo.BaAdresse ADR
                    WHERE ADR.BaPersonID = {1} AND
                          EXISTS (SELECT TOP 1 1
                                  FROM dbo.BaAdresse WITH (READUNCOMMITTED)
                                  WHERE BaPersonID = {0});", baPersonId, baPersonIdDelete);

                // Relations
                lblAktion.Text = KissMsg.GetMLMessage(Name, "ActionBeziehungen", "Info: Beziehungen bereinigen...");
                ApplicationFacade.DoEvents();

                DBUtil.ExecSQLThrowingException(60, @"
                    -- delete all double relations
                    DELETE DRE
                    FROM dbo.BaPerson_Relation  DRE
                    WHERE (DRE.BaPersonID_1 = {1} AND
                           EXISTS (SELECT TOP 1 1
                                   FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                                   WHERE BaPersonID_1 = {0} AND
                                         BaPersonID_2 = DRE.BaPersonID_2))
                          OR
                          (DRE.BaPersonID_2 = {1} AND
                           EXISTS (SELECT TOP 1 1
                                   FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                                   WHERE BaPersonID_2 = {0} AND
                                         BaPersonID_1 = DRE.BaPersonID_1));", baPersonId, baPersonIdDelete);

                // alle abhängigen Daten auf neue Person umhängen
                lblAktion.Text = KissMsg.GetMLMessage(Name, "ActionBeziehungen", "Info: Abhängige Daten (Falldaten) umhängen...");
                ApplicationFacade.DoEvents();

                DBUtil.ExecSQLThrowingException(120, "EXECUTE dbo.spXRowMerge {0}, {1}, {2}", "BaPerson", baPersonId, baPersonIdDelete);

                // done
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(Name, "FehlerDatenbereinigung", "Bei Versuch, die Datenbereinigung durchzuführen, ist ein Fehler aufgetreten. Es wurden keine Änderungen durchgeführt.", ex);
            }
            finally
            {
                lblAktion.Text = "";
                Cursor.Current = currentCursor;
            }
        }

        #endregion

        #endregion
    }
}