using System;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public class CtlDoubleInstitution : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly string _institutionANameML = KissMsg.GetMLMessage("CtlDoubleInstitution", "InstitutionA", "Institution A");
        private static readonly string _institutionBNameML = KissMsg.GetMLMessage("CtlDoubleInstitution", "InstitutionB", "Institution B");

        #endregion

        #region Private Constant/Read-Only Fields

        private const string SQLFORQUERIES = @"
            DECLARE @BaInstitutionID INT;
            DECLARE @UserID INT;
            DECLARE @LanguageCode INT;

            SET @BaInstitutionID = {0};
            SET @UserID = {1};
            SET @LanguageCode = {2};

            SELECT INS.BaInstitutionID,
                   INS.OrgUnitID,
                   INS.InstitutionNr,
                   INS.BaInstitutionArtCode,
                   INS.Aktiv,
                   INS.Debitor,
                   INS.Kreditor,
                   INS.KeinSerienbrief,
                   INS.ManuelleAnrede,
                   INS.Anrede,
                   INS.Briefanrede,
                   INS.Titel,
                   INS.Name,
                   INS.Vorname,
                   INS.GeschlechtCode,
                   INS.Telefon,
                   INS.Telefon2,
                   INS.Telefon3,
                   INS.Fax,
                   INS.EMail,
                   INS.Homepage,
                   INS.SprachCode,
                   INS.Bemerkung,
                   INS.Creator,
                   INS.Created,
                   INS.Modifier,
                   INS.Modified,
                   INS.BaInstitutionTS,
                   INS.NameVorname,
                   INS.Adresse,
                   INS.AdresseMehrzeilig,
                   INS.OrtStrasse,
                   INS.Zusatz,
                   INS.AdressZusatz,
                   INS.HausNr,
                   INS.StrasseHausNr,
                   INS.PostfachOhneNr,
                   INS.PostfachTextD,
                   INS.PLZ,
                   INS.PLZOrt,
                   INS.Bezirk,
                   INS.Kanton,
                   INS.OrtschaftCode,
                   INS.BaLandID,
                   INS.BaFreigabeStatusCode,
                   Abteilung = ORG.ItemName,
                   NrName    = CONVERT(VARCHAR, INS.BaInstitutionID) + ' ' + ISNULL(INS.Name, ''),
                   Strasse   = INS.StrasseHausNr,
                   Postfach  = dbo.fnBaGetPostfachText(NULL, INS.Postfach, INS.PostfachOhneNr, @LanguageCode),
                   Ort       = INS.PLZOrt,
                   Land      = dbo.fnLandMLText(INS.BaLandID, @LanguageCode),
                   Typen     = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', @UserID, @LanguageCode)
            FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
              LEFT JOIN dbo.XOrgUnit  ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = INS.OrgUnitID
            WHERE INS.BaInstitutionID = @BaInstitutionID;";

        #endregion

        #region Private Fields

        private int _baInstitutionID_A = 0;
        private int _baInstitutionID_B = 0;
        private KiSS4.Gui.KissButton btnMigrateAToB;
        private KiSS4.Gui.KissButton btnMigrateBToA;
        private KiSS4.Gui.KissButton btnResetA;
        private KiSS4.Gui.KissButton btnResetB;
        private KiSS4.Gui.KissCheckEdit chkAktivA;
        private KiSS4.Gui.KissCheckEdit chkAktivB;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAbteilungA;
        private KiSS4.Gui.KissTextEdit edtAbteilungB;
        private KiSS4.Gui.KissTextEdit edtBaInstitutionIDA;
        private KiSS4.Gui.KissTextEdit edtBaInstitutionIDB;
        private KiSS4.Gui.KissTextEdit edtBezirkA;
        private KiSS4.Gui.KissTextEdit edtBezirkB;
        private KiSS4.Gui.KissTextEdit edtEmailA;
        private KiSS4.Gui.KissTextEdit edtEmailB;
        private KiSS4.Gui.KissTextEdit edtFaxA;
        private KiSS4.Gui.KissTextEdit edtFaxB;
        private KiSS4.Gui.KissButtonEdit edtInstitutionA;
        private KiSS4.Gui.KissButtonEdit edtInstitutionB;
        private KissTextEdit edtKantonA;
        private KissTextEdit edtKantonB;
        private KiSS4.Gui.KissTextEdit edtLandA;
        private KiSS4.Gui.KissTextEdit edtLandB;
        private KiSS4.Gui.KissTextEdit edtNameA;
        private KiSS4.Gui.KissTextEdit edtNameB;
        private KiSS4.Gui.KissTextEdit edtPLZOrtA;
        private KiSS4.Gui.KissTextEdit edtPLZOrtB;
        private KiSS4.Gui.KissTextEdit edtPostfachA;
        private KiSS4.Gui.KissTextEdit edtPostfachB;
        private KiSS4.Gui.KissTextEdit edtStrasseNrA;
        private KiSS4.Gui.KissTextEdit edtStrasseNrB;
        private KissTextEdit edtTelefon2A;
        private KissTextEdit edtTelefon2B;
        private KissTextEdit edtTelefon3A;
        private KissTextEdit edtTelefon3B;
        private KiSS4.Gui.KissTextEdit edtTelefonA;
        private KiSS4.Gui.KissTextEdit edtTelefonB;
        private KiSS4.Gui.KissTextEdit edtTypA;
        private KiSS4.Gui.KissTextEdit edtTypB;
        private KiSS4.Gui.KissLabel lblAbteilung;
        private KiSS4.Gui.KissLabel lblAktion;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBezirk;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblInstitutionA;
        private KiSS4.Gui.KissLabel lblInstitutionB;
        private KiSS4.Gui.KissLabel lblInstitutionNr;
        private KissLabel lblKanton;
        private KiSS4.Gui.KissLabel lblLand;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblPostfach;
        private KiSS4.Gui.KissLabel lblStrasseNr;
        private KiSS4.Gui.KissLabel lblSuchen;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KissLabel lblTelefon2;
        private KissLabel lblTelefon3;
        private KiSS4.Gui.KissLabel lblTyp;
        private KiSS4.Gui.KissRTFEdit memBemerkungenA;
        private KiSS4.Gui.KissRTFEdit memBemerkungenB;
        private KiSS4.DB.SqlQuery qryInstitutionA;
        private KiSS4.DB.SqlQuery qryInstitutionB;

        #endregion

        #endregion

        #region Constructors

        public CtlDoubleInstitution(int baInstitutionID_A, int baInstitutionID_B)
            : this()
        {
            _baInstitutionID_A = baInstitutionID_A;
            _baInstitutionID_B = baInstitutionID_B;
        }

        public CtlDoubleInstitution()
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblInstitutionA = new KiSS4.Gui.KissLabel();
            this.lblInstitutionB = new KiSS4.Gui.KissLabel();
            this.lblSuchen = new KiSS4.Gui.KissLabel();
            this.edtInstitutionA = new KiSS4.Gui.KissButtonEdit();
            this.qryInstitutionA = new KiSS4.DB.SqlQuery(this.components);
            this.btnResetA = new KiSS4.Gui.KissButton();
            this.edtInstitutionB = new KiSS4.Gui.KissButtonEdit();
            this.qryInstitutionB = new KiSS4.DB.SqlQuery(this.components);
            this.btnResetB = new KiSS4.Gui.KissButton();
            this.lblInstitutionNr = new KiSS4.Gui.KissLabel();
            this.edtBaInstitutionIDA = new KiSS4.Gui.KissTextEdit();
            this.chkAktivA = new KiSS4.Gui.KissCheckEdit();
            this.edtBaInstitutionIDB = new KiSS4.Gui.KissTextEdit();
            this.chkAktivB = new KiSS4.Gui.KissCheckEdit();
            this.lblAbteilung = new KiSS4.Gui.KissLabel();
            this.edtAbteilungA = new KiSS4.Gui.KissTextEdit();
            this.edtAbteilungB = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtNameA = new KiSS4.Gui.KissTextEdit();
            this.edtNameB = new KiSS4.Gui.KissTextEdit();
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
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtTelefonA = new KiSS4.Gui.KissTextEdit();
            this.edtTelefonB = new KiSS4.Gui.KissTextEdit();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.edtFaxA = new KiSS4.Gui.KissTextEdit();
            this.edtFaxB = new KiSS4.Gui.KissTextEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.edtEmailA = new KiSS4.Gui.KissTextEdit();
            this.edtEmailB = new KiSS4.Gui.KissTextEdit();
            this.lblTyp = new KiSS4.Gui.KissLabel();
            this.edtTypA = new KiSS4.Gui.KissTextEdit();
            this.edtTypB = new KiSS4.Gui.KissTextEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.memBemerkungenA = new KiSS4.Gui.KissRTFEdit();
            this.memBemerkungenB = new KiSS4.Gui.KissRTFEdit();
            this.btnMigrateAToB = new KiSS4.Gui.KissButton();
            this.btnMigrateBToA = new KiSS4.Gui.KissButton();
            this.lblAktion = new KiSS4.Gui.KissLabel();
            this.edtKantonA = new KiSS4.Gui.KissTextEdit();
            this.lblKanton = new KiSS4.Gui.KissLabel();
            this.edtKantonB = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon2A = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon3A = new KiSS4.Gui.KissTextEdit();
            this.lblTelefon2 = new KiSS4.Gui.KissLabel();
            this.lblTelefon3 = new KiSS4.Gui.KissLabel();
            this.edtTelefon2B = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon3B = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitutionA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitutionB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionIDA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktivA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionIDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktivB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilungA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilungB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameB.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaxA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaxB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmailA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmailB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantonA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantonB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon2A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon3A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon2B.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon3B.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // lblInstitutionA
            //
            this.lblInstitutionA.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblInstitutionA.Location = new System.Drawing.Point(168, 10);
            this.lblInstitutionA.Name = "lblInstitutionA";
            this.lblInstitutionA.Size = new System.Drawing.Size(293, 16);
            this.lblInstitutionA.TabIndex = 0;
            this.lblInstitutionA.Text = "Institution A";
            this.lblInstitutionA.UseCompatibleTextRendering = true;
            //
            // lblInstitutionB
            //
            this.lblInstitutionB.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblInstitutionB.Location = new System.Drawing.Point(481, 10);
            this.lblInstitutionB.Name = "lblInstitutionB";
            this.lblInstitutionB.Size = new System.Drawing.Size(291, 16);
            this.lblInstitutionB.TabIndex = 1;
            this.lblInstitutionB.Text = "Institution B";
            this.lblInstitutionB.UseCompatibleTextRendering = true;
            //
            // lblSuchen
            //
            this.lblSuchen.Location = new System.Drawing.Point(9, 36);
            this.lblSuchen.Name = "lblSuchen";
            this.lblSuchen.Size = new System.Drawing.Size(155, 24);
            this.lblSuchen.TabIndex = 2;
            this.lblSuchen.Text = "Nach Nr. od. Name suchen";
            this.lblSuchen.UseCompatibleTextRendering = true;
            //
            // edtInstitutionA
            //
            this.edtInstitutionA.DataMember = "NrName";
            this.edtInstitutionA.DataSource = this.qryInstitutionA;
            this.edtInstitutionA.Location = new System.Drawing.Point(170, 36);
            this.edtInstitutionA.Name = "edtInstitutionA";
            this.edtInstitutionA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitutionA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitutionA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitutionA.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitutionA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitutionA.Properties.Appearance.Options.UseFont = true;
            this.edtInstitutionA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtInstitutionA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtInstitutionA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitutionA.Size = new System.Drawing.Size(261, 24);
            this.edtInstitutionA.TabIndex = 3;
            this.edtInstitutionA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitutionA_UserModifiedFld);
            //
            // qryInstitutionA
            //
            this.qryInstitutionA.HostControl = this;
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
            // edtInstitutionB
            //
            this.edtInstitutionB.DataMember = "NrName";
            this.edtInstitutionB.DataSource = this.qryInstitutionB;
            this.edtInstitutionB.Location = new System.Drawing.Point(481, 36);
            this.edtInstitutionB.Name = "edtInstitutionB";
            this.edtInstitutionB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitutionB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitutionB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitutionB.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitutionB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitutionB.Properties.Appearance.Options.UseFont = true;
            this.edtInstitutionB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtInstitutionB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtInstitutionB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitutionB.Size = new System.Drawing.Size(261, 24);
            this.edtInstitutionB.TabIndex = 5;
            this.edtInstitutionB.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitutionB_UserModifiedFld);
            //
            // qryInstitutionB
            //
            this.qryInstitutionB.HostControl = this;
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
            // lblInstitutionNr
            //
            this.lblInstitutionNr.Location = new System.Drawing.Point(9, 70);
            this.lblInstitutionNr.Name = "lblInstitutionNr";
            this.lblInstitutionNr.Size = new System.Drawing.Size(155, 24);
            this.lblInstitutionNr.TabIndex = 7;
            this.lblInstitutionNr.Text = "Institution-Nr.";
            this.lblInstitutionNr.UseCompatibleTextRendering = true;
            //
            // edtBaInstitutionIDA
            //
            this.edtBaInstitutionIDA.DataMember = "BaInstitutionID";
            this.edtBaInstitutionIDA.DataSource = this.qryInstitutionA;
            this.edtBaInstitutionIDA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaInstitutionIDA.Location = new System.Drawing.Point(170, 70);
            this.edtBaInstitutionIDA.Name = "edtBaInstitutionIDA";
            this.edtBaInstitutionIDA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaInstitutionIDA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaInstitutionIDA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaInstitutionIDA.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaInstitutionIDA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaInstitutionIDA.Properties.Appearance.Options.UseFont = true;
            this.edtBaInstitutionIDA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaInstitutionIDA.Properties.ReadOnly = true;
            this.edtBaInstitutionIDA.Size = new System.Drawing.Size(119, 24);
            this.edtBaInstitutionIDA.TabIndex = 8;
            this.edtBaInstitutionIDA.TabStop = false;
            //
            // chkAktivA
            //
            this.chkAktivA.DataMember = "Aktiv";
            this.chkAktivA.DataSource = this.qryInstitutionA;
            this.chkAktivA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkAktivA.Location = new System.Drawing.Point(386, 72);
            this.chkAktivA.Name = "chkAktivA";
            this.chkAktivA.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktivA.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktivA.Properties.Caption = "Aktiv";
            this.chkAktivA.Properties.ReadOnly = true;
            this.chkAktivA.Size = new System.Drawing.Size(75, 19);
            this.chkAktivA.TabIndex = 9;
            this.chkAktivA.TabStop = false;
            //
            // edtBaInstitutionIDB
            //
            this.edtBaInstitutionIDB.DataMember = "BaInstitutionID";
            this.edtBaInstitutionIDB.DataSource = this.qryInstitutionB;
            this.edtBaInstitutionIDB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaInstitutionIDB.Location = new System.Drawing.Point(481, 70);
            this.edtBaInstitutionIDB.Name = "edtBaInstitutionIDB";
            this.edtBaInstitutionIDB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaInstitutionIDB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaInstitutionIDB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaInstitutionIDB.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaInstitutionIDB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaInstitutionIDB.Properties.Appearance.Options.UseFont = true;
            this.edtBaInstitutionIDB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaInstitutionIDB.Properties.ReadOnly = true;
            this.edtBaInstitutionIDB.Size = new System.Drawing.Size(119, 24);
            this.edtBaInstitutionIDB.TabIndex = 10;
            this.edtBaInstitutionIDB.TabStop = false;
            //
            // chkAktivB
            //
            this.chkAktivB.DataMember = "Aktiv";
            this.chkAktivB.DataSource = this.qryInstitutionB;
            this.chkAktivB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkAktivB.Location = new System.Drawing.Point(697, 72);
            this.chkAktivB.Name = "chkAktivB";
            this.chkAktivB.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktivB.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktivB.Properties.Caption = "Aktiv";
            this.chkAktivB.Properties.ReadOnly = true;
            this.chkAktivB.Size = new System.Drawing.Size(75, 19);
            this.chkAktivB.TabIndex = 11;
            this.chkAktivB.TabStop = false;
            //
            // lblAbteilung
            //
            this.lblAbteilung.Location = new System.Drawing.Point(9, 100);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(155, 24);
            this.lblAbteilung.TabIndex = 12;
            this.lblAbteilung.Text = "Abteilung";
            this.lblAbteilung.UseCompatibleTextRendering = true;
            //
            // edtAbteilungA
            //
            this.edtAbteilungA.DataMember = "Abteilung";
            this.edtAbteilungA.DataSource = this.qryInstitutionA;
            this.edtAbteilungA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbteilungA.Location = new System.Drawing.Point(170, 100);
            this.edtAbteilungA.Name = "edtAbteilungA";
            this.edtAbteilungA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbteilungA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbteilungA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbteilungA.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbteilungA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbteilungA.Properties.Appearance.Options.UseFont = true;
            this.edtAbteilungA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbteilungA.Properties.ReadOnly = true;
            this.edtAbteilungA.Size = new System.Drawing.Size(291, 24);
            this.edtAbteilungA.TabIndex = 13;
            this.edtAbteilungA.TabStop = false;
            //
            // edtAbteilungB
            //
            this.edtAbteilungB.DataMember = "Abteilung";
            this.edtAbteilungB.DataSource = this.qryInstitutionB;
            this.edtAbteilungB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbteilungB.Location = new System.Drawing.Point(481, 100);
            this.edtAbteilungB.Name = "edtAbteilungB";
            this.edtAbteilungB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbteilungB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbteilungB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbteilungB.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbteilungB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbteilungB.Properties.Appearance.Options.UseFont = true;
            this.edtAbteilungB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbteilungB.Properties.ReadOnly = true;
            this.edtAbteilungB.Size = new System.Drawing.Size(291, 24);
            this.edtAbteilungB.TabIndex = 14;
            this.edtAbteilungB.TabStop = false;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(9, 130);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(155, 24);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // edtNameA
            //
            this.edtNameA.DataMember = "Name";
            this.edtNameA.DataSource = this.qryInstitutionA;
            this.edtNameA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameA.Location = new System.Drawing.Point(170, 130);
            this.edtNameA.Name = "edtNameA";
            this.edtNameA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameA.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameA.Properties.Appearance.Options.UseFont = true;
            this.edtNameA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameA.Properties.ReadOnly = true;
            this.edtNameA.Size = new System.Drawing.Size(291, 24);
            this.edtNameA.TabIndex = 16;
            this.edtNameA.TabStop = false;
            //
            // edtNameB
            //
            this.edtNameB.DataMember = "Name";
            this.edtNameB.DataSource = this.qryInstitutionB;
            this.edtNameB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameB.Location = new System.Drawing.Point(481, 130);
            this.edtNameB.Name = "edtNameB";
            this.edtNameB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameB.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameB.Properties.Appearance.Options.UseFont = true;
            this.edtNameB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameB.Properties.ReadOnly = true;
            this.edtNameB.Size = new System.Drawing.Size(291, 24);
            this.edtNameB.TabIndex = 17;
            this.edtNameB.TabStop = false;
            //
            // lblStrasseNr
            //
            this.lblStrasseNr.Location = new System.Drawing.Point(9, 160);
            this.lblStrasseNr.Name = "lblStrasseNr";
            this.lblStrasseNr.Size = new System.Drawing.Size(155, 24);
            this.lblStrasseNr.TabIndex = 18;
            this.lblStrasseNr.Text = "Strasse / Nr.";
            this.lblStrasseNr.UseCompatibleTextRendering = true;
            //
            // edtStrasseNrA
            //
            this.edtStrasseNrA.DataMember = "Strasse";
            this.edtStrasseNrA.DataSource = this.qryInstitutionA;
            this.edtStrasseNrA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseNrA.Location = new System.Drawing.Point(170, 160);
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
            this.edtStrasseNrA.TabIndex = 19;
            this.edtStrasseNrA.TabStop = false;
            //
            // edtStrasseNrB
            //
            this.edtStrasseNrB.DataMember = "Strasse";
            this.edtStrasseNrB.DataSource = this.qryInstitutionB;
            this.edtStrasseNrB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseNrB.Location = new System.Drawing.Point(481, 160);
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
            this.edtStrasseNrB.TabIndex = 20;
            this.edtStrasseNrB.TabStop = false;
            //
            // lblPostfach
            //
            this.lblPostfach.Location = new System.Drawing.Point(9, 183);
            this.lblPostfach.Name = "lblPostfach";
            this.lblPostfach.Size = new System.Drawing.Size(155, 24);
            this.lblPostfach.TabIndex = 21;
            this.lblPostfach.Text = "Postfach";
            this.lblPostfach.UseCompatibleTextRendering = true;
            //
            // edtPostfachA
            //
            this.edtPostfachA.DataMember = "Postfach";
            this.edtPostfachA.DataSource = this.qryInstitutionA;
            this.edtPostfachA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostfachA.Location = new System.Drawing.Point(170, 183);
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
            this.edtPostfachA.TabIndex = 22;
            this.edtPostfachA.TabStop = false;
            //
            // edtPostfachB
            //
            this.edtPostfachB.DataMember = "Postfach";
            this.edtPostfachB.DataSource = this.qryInstitutionB;
            this.edtPostfachB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostfachB.Location = new System.Drawing.Point(481, 183);
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
            this.edtPostfachB.TabIndex = 23;
            this.edtPostfachB.TabStop = false;
            //
            // lblPLZOrt
            //
            this.lblPLZOrt.Location = new System.Drawing.Point(9, 206);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(155, 24);
            this.lblPLZOrt.TabIndex = 24;
            this.lblPLZOrt.Text = "PLZ / Ort";
            this.lblPLZOrt.UseCompatibleTextRendering = true;
            //
            // edtPLZOrtA
            //
            this.edtPLZOrtA.DataMember = "Ort";
            this.edtPLZOrtA.DataSource = this.qryInstitutionA;
            this.edtPLZOrtA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZOrtA.Location = new System.Drawing.Point(170, 206);
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
            this.edtPLZOrtA.TabIndex = 25;
            this.edtPLZOrtA.TabStop = false;
            //
            // edtPLZOrtB
            //
            this.edtPLZOrtB.DataMember = "Ort";
            this.edtPLZOrtB.DataSource = this.qryInstitutionB;
            this.edtPLZOrtB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZOrtB.Location = new System.Drawing.Point(481, 206);
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
            this.edtPLZOrtB.TabIndex = 26;
            this.edtPLZOrtB.TabStop = false;
            //
            // lblBezirk
            //
            this.lblBezirk.Location = new System.Drawing.Point(9, 229);
            this.lblBezirk.Name = "lblBezirk";
            this.lblBezirk.Size = new System.Drawing.Size(155, 24);
            this.lblBezirk.TabIndex = 27;
            this.lblBezirk.Text = "Bezirk";
            this.lblBezirk.UseCompatibleTextRendering = true;
            //
            // edtBezirkA
            //
            this.edtBezirkA.DataMember = "Bezirk";
            this.edtBezirkA.DataSource = this.qryInstitutionA;
            this.edtBezirkA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBezirkA.Location = new System.Drawing.Point(170, 229);
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
            this.edtBezirkA.TabIndex = 28;
            this.edtBezirkA.TabStop = false;
            //
            // edtBezirkB
            //
            this.edtBezirkB.DataMember = "Bezirk";
            this.edtBezirkB.DataSource = this.qryInstitutionB;
            this.edtBezirkB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBezirkB.Location = new System.Drawing.Point(481, 229);
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
            this.edtBezirkB.TabIndex = 29;
            this.edtBezirkB.TabStop = false;
            //
            // lblLand
            //
            this.lblLand.Location = new System.Drawing.Point(9, 282);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(155, 24);
            this.lblLand.TabIndex = 33;
            this.lblLand.Text = "Land";
            this.lblLand.UseCompatibleTextRendering = true;
            //
            // edtLandA
            //
            this.edtLandA.DataMember = "Land";
            this.edtLandA.DataSource = this.qryInstitutionA;
            this.edtLandA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLandA.Location = new System.Drawing.Point(170, 282);
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
            this.edtLandA.TabIndex = 34;
            this.edtLandA.TabStop = false;
            //
            // edtLandB
            //
            this.edtLandB.DataMember = "Land";
            this.edtLandB.DataSource = this.qryInstitutionB;
            this.edtLandB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLandB.Location = new System.Drawing.Point(481, 282);
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
            this.edtLandB.TabIndex = 35;
            this.edtLandB.TabStop = false;
            //
            // lblTelefon
            //
            this.lblTelefon.Location = new System.Drawing.Point(9, 312);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(155, 24);
            this.lblTelefon.TabIndex = 36;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            //
            // edtTelefonA
            //
            this.edtTelefonA.DataMember = "Telefon";
            this.edtTelefonA.DataSource = this.qryInstitutionA;
            this.edtTelefonA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefonA.Location = new System.Drawing.Point(170, 312);
            this.edtTelefonA.Name = "edtTelefonA";
            this.edtTelefonA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefonA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonA.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonA.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefonA.Properties.ReadOnly = true;
            this.edtTelefonA.Size = new System.Drawing.Size(291, 24);
            this.edtTelefonA.TabIndex = 37;
            this.edtTelefonA.TabStop = false;
            //
            // edtTelefonB
            //
            this.edtTelefonB.DataMember = "Telefon";
            this.edtTelefonB.DataSource = this.qryInstitutionB;
            this.edtTelefonB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefonB.Location = new System.Drawing.Point(481, 312);
            this.edtTelefonB.Name = "edtTelefonB";
            this.edtTelefonB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefonB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonB.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonB.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefonB.Properties.ReadOnly = true;
            this.edtTelefonB.Size = new System.Drawing.Size(291, 24);
            this.edtTelefonB.TabIndex = 38;
            this.edtTelefonB.TabStop = false;
            //
            // lblFax
            //
            this.lblFax.Location = new System.Drawing.Point(9, 381);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(155, 24);
            this.lblFax.TabIndex = 39;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            //
            // edtFaxA
            //
            this.edtFaxA.DataMember = "Fax";
            this.edtFaxA.DataSource = this.qryInstitutionA;
            this.edtFaxA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaxA.Location = new System.Drawing.Point(170, 381);
            this.edtFaxA.Name = "edtFaxA";
            this.edtFaxA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaxA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaxA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaxA.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaxA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaxA.Properties.Appearance.Options.UseFont = true;
            this.edtFaxA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaxA.Properties.ReadOnly = true;
            this.edtFaxA.Size = new System.Drawing.Size(291, 24);
            this.edtFaxA.TabIndex = 40;
            this.edtFaxA.TabStop = false;
            //
            // edtFaxB
            //
            this.edtFaxB.DataMember = "Fax";
            this.edtFaxB.DataSource = this.qryInstitutionB;
            this.edtFaxB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaxB.Location = new System.Drawing.Point(481, 381);
            this.edtFaxB.Name = "edtFaxB";
            this.edtFaxB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaxB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaxB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaxB.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaxB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaxB.Properties.Appearance.Options.UseFont = true;
            this.edtFaxB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaxB.Properties.ReadOnly = true;
            this.edtFaxB.Size = new System.Drawing.Size(291, 24);
            this.edtFaxB.TabIndex = 41;
            this.edtFaxB.TabStop = false;
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(9, 404);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(155, 24);
            this.lblEmail.TabIndex = 42;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.UseCompatibleTextRendering = true;
            //
            // edtEmailA
            //
            this.edtEmailA.DataMember = "Email";
            this.edtEmailA.DataSource = this.qryInstitutionA;
            this.edtEmailA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEmailA.Location = new System.Drawing.Point(170, 404);
            this.edtEmailA.Name = "edtEmailA";
            this.edtEmailA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEmailA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmailA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmailA.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmailA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmailA.Properties.Appearance.Options.UseFont = true;
            this.edtEmailA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmailA.Properties.ReadOnly = true;
            this.edtEmailA.Size = new System.Drawing.Size(291, 24);
            this.edtEmailA.TabIndex = 43;
            this.edtEmailA.TabStop = false;
            //
            // edtEmailB
            //
            this.edtEmailB.DataMember = "Email";
            this.edtEmailB.DataSource = this.qryInstitutionB;
            this.edtEmailB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEmailB.Location = new System.Drawing.Point(481, 404);
            this.edtEmailB.Name = "edtEmailB";
            this.edtEmailB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEmailB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmailB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmailB.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmailB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmailB.Properties.Appearance.Options.UseFont = true;
            this.edtEmailB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmailB.Properties.ReadOnly = true;
            this.edtEmailB.Size = new System.Drawing.Size(291, 24);
            this.edtEmailB.TabIndex = 44;
            this.edtEmailB.TabStop = false;
            //
            // lblTyp
            //
            this.lblTyp.Location = new System.Drawing.Point(9, 434);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(155, 24);
            this.lblTyp.TabIndex = 45;
            this.lblTyp.Text = "Typen";
            this.lblTyp.UseCompatibleTextRendering = true;
            //
            // edtTypA
            //
            this.edtTypA.DataMember = "Typen";
            this.edtTypA.DataSource = this.qryInstitutionA;
            this.edtTypA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTypA.Location = new System.Drawing.Point(170, 434);
            this.edtTypA.Name = "edtTypA";
            this.edtTypA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTypA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTypA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypA.Properties.Appearance.Options.UseBackColor = true;
            this.edtTypA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTypA.Properties.Appearance.Options.UseFont = true;
            this.edtTypA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTypA.Properties.ReadOnly = true;
            this.edtTypA.Size = new System.Drawing.Size(291, 24);
            this.edtTypA.TabIndex = 46;
            this.edtTypA.TabStop = false;
            //
            // edtTypB
            //
            this.edtTypB.DataMember = "Typen";
            this.edtTypB.DataSource = this.qryInstitutionB;
            this.edtTypB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTypB.Location = new System.Drawing.Point(481, 434);
            this.edtTypB.Name = "edtTypB";
            this.edtTypB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTypB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTypB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypB.Properties.Appearance.Options.UseBackColor = true;
            this.edtTypB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTypB.Properties.Appearance.Options.UseFont = true;
            this.edtTypB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTypB.Properties.ReadOnly = true;
            this.edtTypB.Size = new System.Drawing.Size(291, 24);
            this.edtTypB.TabIndex = 47;
            this.edtTypB.TabStop = false;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 464);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(155, 24);
            this.lblBemerkungen.TabIndex = 48;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // memBemerkungenA
            //
            this.memBemerkungenA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkungenA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memBemerkungenA.DataMember = "Bemerkung";
            this.memBemerkungenA.DataSource = this.qryInstitutionA;
            this.memBemerkungenA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memBemerkungenA.Font = new System.Drawing.Font("Arial", 10F);
            this.memBemerkungenA.Location = new System.Drawing.Point(170, 464);
            this.memBemerkungenA.Name = "memBemerkungenA";
            this.memBemerkungenA.ReadOnly = true;
            this.memBemerkungenA.Size = new System.Drawing.Size(291, 85);
            this.memBemerkungenA.TabIndex = 49;
            this.memBemerkungenA.TabStop = false;
            //
            // memBemerkungenB
            //
            this.memBemerkungenB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkungenB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memBemerkungenB.DataMember = "Bemerkung";
            this.memBemerkungenB.DataSource = this.qryInstitutionB;
            this.memBemerkungenB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memBemerkungenB.Font = new System.Drawing.Font("Arial", 10F);
            this.memBemerkungenB.Location = new System.Drawing.Point(481, 464);
            this.memBemerkungenB.Name = "memBemerkungenB";
            this.memBemerkungenB.ReadOnly = true;
            this.memBemerkungenB.Size = new System.Drawing.Size(291, 85);
            this.memBemerkungenB.TabIndex = 50;
            this.memBemerkungenB.TabStop = false;
            //
            // btnMigrateAToB
            //
            this.btnMigrateAToB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMigrateAToB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMigrateAToB.IconID = 13;
            this.btnMigrateAToB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMigrateAToB.Location = new System.Drawing.Point(170, 558);
            this.btnMigrateAToB.Name = "btnMigrateAToB";
            this.btnMigrateAToB.Size = new System.Drawing.Size(291, 24);
            this.btnMigrateAToB.TabIndex = 51;
            this.btnMigrateAToB.Text = "Institution A löschen und Daten zu B migrieren";
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
            this.btnMigrateBToA.Location = new System.Drawing.Point(481, 558);
            this.btnMigrateBToA.Name = "btnMigrateBToA";
            this.btnMigrateBToA.Size = new System.Drawing.Size(291, 24);
            this.btnMigrateBToA.TabIndex = 52;
            this.btnMigrateBToA.Text = "Institution B löschen und Daten zu A migrieren";
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
            this.lblAktion.Location = new System.Drawing.Point(0, 590);
            this.lblAktion.Name = "lblAktion";
            this.lblAktion.Size = new System.Drawing.Size(787, 24);
            this.lblAktion.TabIndex = 50;
            this.lblAktion.Text = "";
            this.lblAktion.UseCompatibleTextRendering = true;
            //
            // edtKantonA
            //
            this.edtKantonA.DataMember = "Kanton";
            this.edtKantonA.DataSource = this.qryInstitutionA;
            this.edtKantonA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKantonA.Location = new System.Drawing.Point(170, 252);
            this.edtKantonA.Name = "edtKantonA";
            this.edtKantonA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKantonA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKantonA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKantonA.Properties.Appearance.Options.UseBackColor = true;
            this.edtKantonA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKantonA.Properties.Appearance.Options.UseFont = true;
            this.edtKantonA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKantonA.Properties.ReadOnly = true;
            this.edtKantonA.Size = new System.Drawing.Size(291, 24);
            this.edtKantonA.TabIndex = 31;
            this.edtKantonA.TabStop = false;
            //
            // lblKanton
            //
            this.lblKanton.Location = new System.Drawing.Point(9, 252);
            this.lblKanton.Name = "lblKanton";
            this.lblKanton.Size = new System.Drawing.Size(155, 24);
            this.lblKanton.TabIndex = 30;
            this.lblKanton.Text = "Kanton";
            this.lblKanton.UseCompatibleTextRendering = true;
            //
            // edtKantonB
            //
            this.edtKantonB.DataMember = "Kanton";
            this.edtKantonB.DataSource = this.qryInstitutionB;
            this.edtKantonB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKantonB.Location = new System.Drawing.Point(481, 252);
            this.edtKantonB.Name = "edtKantonB";
            this.edtKantonB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKantonB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKantonB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKantonB.Properties.Appearance.Options.UseBackColor = true;
            this.edtKantonB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKantonB.Properties.Appearance.Options.UseFont = true;
            this.edtKantonB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKantonB.Properties.ReadOnly = true;
            this.edtKantonB.Size = new System.Drawing.Size(291, 24);
            this.edtKantonB.TabIndex = 32;
            this.edtKantonB.TabStop = false;
            //
            // edtTelefon2A
            //
            this.edtTelefon2A.DataMember = "Telefon2";
            this.edtTelefon2A.DataSource = this.qryInstitutionA;
            this.edtTelefon2A.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon2A.Location = new System.Drawing.Point(170, 335);
            this.edtTelefon2A.Name = "edtTelefon2A";
            this.edtTelefon2A.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon2A.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon2A.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon2A.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon2A.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon2A.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon2A.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon2A.Properties.ReadOnly = true;
            this.edtTelefon2A.Size = new System.Drawing.Size(291, 24);
            this.edtTelefon2A.TabIndex = 53;
            this.edtTelefon2A.TabStop = false;
            //
            // edtTelefon3A
            //
            this.edtTelefon3A.DataMember = "Telefon3";
            this.edtTelefon3A.DataSource = this.qryInstitutionA;
            this.edtTelefon3A.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon3A.Location = new System.Drawing.Point(170, 358);
            this.edtTelefon3A.Name = "edtTelefon3A";
            this.edtTelefon3A.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon3A.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon3A.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon3A.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon3A.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon3A.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon3A.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon3A.Properties.ReadOnly = true;
            this.edtTelefon3A.Size = new System.Drawing.Size(291, 24);
            this.edtTelefon3A.TabIndex = 54;
            this.edtTelefon3A.TabStop = false;
            //
            // lblTelefon2
            //
            this.lblTelefon2.Location = new System.Drawing.Point(9, 335);
            this.lblTelefon2.Name = "lblTelefon2";
            this.lblTelefon2.Size = new System.Drawing.Size(155, 24);
            this.lblTelefon2.TabIndex = 55;
            this.lblTelefon2.Text = "Telefon 2";
            this.lblTelefon2.UseCompatibleTextRendering = true;
            //
            // lblTelefon3
            //
            this.lblTelefon3.Location = new System.Drawing.Point(9, 358);
            this.lblTelefon3.Name = "lblTelefon3";
            this.lblTelefon3.Size = new System.Drawing.Size(155, 24);
            this.lblTelefon3.TabIndex = 56;
            this.lblTelefon3.Text = "Telefon 3";
            this.lblTelefon3.UseCompatibleTextRendering = true;
            //
            // edtTelefon2B
            //
            this.edtTelefon2B.DataMember = "Telefon2";
            this.edtTelefon2B.DataSource = this.qryInstitutionB;
            this.edtTelefon2B.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon2B.Location = new System.Drawing.Point(481, 335);
            this.edtTelefon2B.Name = "edtTelefon2B";
            this.edtTelefon2B.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon2B.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon2B.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon2B.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon2B.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon2B.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon2B.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon2B.Properties.ReadOnly = true;
            this.edtTelefon2B.Size = new System.Drawing.Size(291, 24);
            this.edtTelefon2B.TabIndex = 57;
            this.edtTelefon2B.TabStop = false;
            //
            // edtTelefon3B
            //
            this.edtTelefon3B.DataMember = "Telefon3";
            this.edtTelefon3B.DataSource = this.qryInstitutionB;
            this.edtTelefon3B.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon3B.Location = new System.Drawing.Point(481, 358);
            this.edtTelefon3B.Name = "edtTelefon3B";
            this.edtTelefon3B.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon3B.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon3B.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon3B.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon3B.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon3B.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon3B.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon3B.Properties.ReadOnly = true;
            this.edtTelefon3B.Size = new System.Drawing.Size(291, 24);
            this.edtTelefon3B.TabIndex = 58;
            this.edtTelefon3B.TabStop = false;
            //
            // CtlDoubleInstitution
            //
            this.Controls.Add(this.edtTelefon3B);
            this.Controls.Add(this.edtTelefon2B);
            this.Controls.Add(this.lblTelefon3);
            this.Controls.Add(this.lblTelefon2);
            this.Controls.Add(this.edtTelefon3A);
            this.Controls.Add(this.edtTelefon2A);
            this.Controls.Add(this.edtKantonB);
            this.Controls.Add(this.btnMigrateBToA);
            this.Controls.Add(this.btnMigrateAToB);
            this.Controls.Add(this.memBemerkungenB);
            this.Controls.Add(this.memBemerkungenA);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.edtTypB);
            this.Controls.Add(this.edtTypA);
            this.Controls.Add(this.lblTyp);
            this.Controls.Add(this.edtEmailB);
            this.Controls.Add(this.edtEmailA);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.edtFaxB);
            this.Controls.Add(this.edtFaxA);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.edtTelefonB);
            this.Controls.Add(this.edtTelefonA);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.edtLandB);
            this.Controls.Add(this.edtLandA);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.edtBezirkB);
            this.Controls.Add(this.edtKantonA);
            this.Controls.Add(this.edtBezirkA);
            this.Controls.Add(this.lblKanton);
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
            this.Controls.Add(this.edtNameB);
            this.Controls.Add(this.edtNameA);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.edtAbteilungB);
            this.Controls.Add(this.edtAbteilungA);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.chkAktivB);
            this.Controls.Add(this.edtBaInstitutionIDB);
            this.Controls.Add(this.chkAktivA);
            this.Controls.Add(this.edtBaInstitutionIDA);
            this.Controls.Add(this.lblInstitutionNr);
            this.Controls.Add(this.btnResetB);
            this.Controls.Add(this.edtInstitutionB);
            this.Controls.Add(this.btnResetA);
            this.Controls.Add(this.edtInstitutionA);
            this.Controls.Add(this.lblSuchen);
            this.Controls.Add(this.lblInstitutionB);
            this.Controls.Add(this.lblInstitutionA);
            this.Controls.Add(this.lblAktion);
            this.Name = "CtlDoubleInstitution";
            this.Size = new System.Drawing.Size(787, 614);
            this.Load += new System.EventHandler(this.CtlDoubleOrganisation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitutionA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitutionB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionIDA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktivA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionIDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktivB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilungA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilungB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameB.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaxA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaxB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmailA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmailB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantonA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantonB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon2A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon3A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon2B.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon3B.Properties)).EndInit();
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
            Migrate(_baInstitutionID_B, _baInstitutionID_A, _institutionBNameML, _institutionANameML);

            // refresh view
            OnRefreshData();
        }

        private void btnMigrateBToA_Click(object sender, EventArgs e)
        {
            // migrate data
            Migrate(_baInstitutionID_A, _baInstitutionID_B, _institutionANameML, _institutionBNameML);

            // refresh view
            OnRefreshData();
        }

        private void btnResetA_Click(object sender, EventArgs e)
        {
            // reset value for A
            _baInstitutionID_A = 0;
            OnRefreshData();

            //  focus
            edtInstitutionA.Focus();
        }

        private void btnResetB_Click(object sender, EventArgs e)
        {
            // reset value for B
            _baInstitutionID_B = 0;
            OnRefreshData();

            //  focus
            edtInstitutionB.Focus();
        }

        private void CtlDoubleOrganisation_Load(object sender, EventArgs e)
        {
            // reset text
            lblAktion.Text = "";

            // refresh data
            if (_baInstitutionID_A < 1 && _baInstitutionID_B < 1)
            {
                HandleQueriesInsertsAndButtonsEnabled();
            }
            else
            {
                OnRefreshData();
            }
        }

        private void edtInstitutionA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // get institution
            e.Cancel = !DialogInstitution(sender, e);

            // refresh display if neccessary
            if (!e.Cancel)
            {
                OnRefreshData();
            }
        }

        private void edtInstitutionB_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // get institution
            e.Cancel = !DialogInstitution(sender, e);

            // refresh display if neccessary
            if (!e.Cancel)
            {
                OnRefreshData();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            base.OnRefreshData();

            qryInstitutionA.Fill(SQLFORQUERIES, _baInstitutionID_A, Session.User.UserID, Session.User.LanguageCode);
            qryInstitutionB.Fill(SQLFORQUERIES, _baInstitutionID_B, Session.User.UserID, Session.User.LanguageCode);

            HandleQueriesInsertsAndButtonsEnabled();
        }

        public override void Translate()
        {
            base.Translate();

            string typeName = Utils.GetOrgUnitTypNameForInstitutionsTypen();

            if (!string.IsNullOrEmpty(typeName))
            {
                // apply name to label
                lblAbteilung.Text = typeName;
            }
        }

        #endregion

        #region Private Static Methods

        private static bool PreventMigrateDifferentOrgUnits(int baInstitutionId, int baInstitutionIdDelete)
        {
            var isOrgUnitRequired = DBUtil.GetConfigBool(@"System\Basis\AbteilungAufInstAlsMussfeld", false);
            var userHasSpecialRight = DBUtil.UserHasRight("ADMDatenbereinigungInstitutionenAlleAbteilungen");

            if (!isOrgUnitRequired || userHasSpecialRight || Session.User.IsUserAdmin)
            {
                // if orgunit is not required or user has specialright assigned or is admin, merging is always possible
                return false;
            }

            // get orgunits from institutions
            var qryBaInstitutionOrgUnits = DBUtil.OpenSQL(@"
                SELECT OrgUnitID_A = ISNULL((SELECT OrgUnitID
                                             FROM dbo.BaInstitution WITH (READUNCOMMITTED)
                                             WHERE BaInstitutionID = {0}), -2),
                       OrgUnitID_B = ISNULL((SELECT OrgUnitID
                                             FROM dbo.BaInstitution WITH (READUNCOMMITTED)
                                             WHERE BaInstitutionID = {1}), -2);", baInstitutionId, baInstitutionIdDelete);

            // get user's KGS-OrgUnitID
            int userKGSOrgUnitID = Common.PI.XUtils.GetUserKGSOrgUnitID();

            // compare orgunits with current users KGS to validate if migration can be performed
            if (userKGSOrgUnitID == Convert.ToInt32(qryBaInstitutionOrgUnits["OrgUnitID_A"]) &&
                userKGSOrgUnitID == Convert.ToInt32(qryBaInstitutionOrgUnits["OrgUnitID_B"]))
            {
                // merge can be executed because of matching orgunits
                return false;
            }

            // prevent merge because of different orgunits
            return true;
        }

        #endregion

        #region Private Methods

        private bool DialogInstitution(object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // convert control
                KissButtonEdit edit = (KissButtonEdit)sender;

                // check if data can be altered
                if (edit.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edit.EditValue))
                {
                    // prepare for database search
                    searchString = edit.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, do not show dialog as too much data would appear
                        return false;
                    }

                    // check control
                    if (edit == edtInstitutionA)
                    {
                        _baInstitutionID_A = 0;
                        return true;
                    }

                    if (edit == edtInstitutionB)
                    {
                        _baInstitutionID_B = 0;
                        return true;
                    }

                    // wrong field
                    throw new ArgumentOutOfRangeException("edit", "Wrong data field, cannot proceed.");
                }

                string orgUnitColName = lblAbteilung.Text.Replace("]", "");   // remove possible "]" to prevent error
                var dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(string.Format(@"
                        DECLARE @SearchValue VARCHAR(255);
                        DECLARE @SearchNumber VARCHAR(255);
                        DECLARE @UserID INT;
                        DECLARE @LanguageCode INT;

                        SET @SearchValue = {0};
                        SET @UserID = {1};
                        SET @LanguageCode = {2};

                        --Suche im ganzen Institutionenstamm
                        SET @SearchValue = REPLACE(@SearchValue, ' ', '%');
                        SET @SearchValue = REPLACE(@SearchValue, ',', '%');
                        SET @SearchValue = '%' + @SearchValue + '%';

                        SET @SearchNumber = REPLACE(@SearchValue, '%', '');

                        -- Institutions:
                        SELECT ID$     = INS.BaInstitutionID,
                               Text$   = ISNULL(INS.NameVorname, '') + ISNULL(', ' + INS.Ort, ''),
                               Name    = INS.NameVorname,
                               Strasse = INS.StrasseHausNr,
                               Ort     = INS.PLZOrt,
                               [" + orgUnitColName + @"] = ORG.ItemName,
                               Typen   = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', @UserID, @LanguageCode)
                        FROM dbo.vwInstitution   INS WITH (READUNCOMMITTED)
                          LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = INS.OrgUnitID
                        WHERE ((ISNULL(INS.NameVorname, '') + ISNULL(', ' + INS.Ort, '')) LIKE @SearchValue AND INS.NameVorname <> '')
                           OR CONVERT(VARCHAR, INS.BaInstitutionID) = @SearchNumber
                        ORDER BY Name ASC;", DBUtil.SqlLiteral(searchString),
                                             Session.User.UserID,
                                             Session.User.LanguageCode),
                                           searchString,
                                           e.ButtonClicked);

                if (!e.Cancel)
                {
                    // check control
                    if (edit == edtInstitutionA)
                    {
                        // apply new value
                        _baInstitutionID_A = 0;
                        _baInstitutionID_A = Convert.ToInt32(dlg["ID$"]);
                    }
                    else if (edit == edtInstitutionB)
                    {
                        // apply new value
                        _baInstitutionID_B = 0;
                        _baInstitutionID_B = Convert.ToInt32(dlg["ID$"]);
                    }
                    else
                    {
                        // wrong field
                        throw new Exception("Wrong data field, cannot proceed.");
                    }

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorIKissUserModified_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private void HandleQueriesInsertsAndButtonsEnabled()
        {
            if (qryInstitutionA.Count == 0)
            {
                qryInstitutionA.Insert(null);
            }

            if (qryInstitutionB.Count == 0)
            {
                qryInstitutionB.Insert(null);
            }

            bool buttonsEnabled = false;

            if (!qryInstitutionA.IsEmpty &&
                !qryInstitutionB.IsEmpty &&
                qryInstitutionA.DataTable.Columns.Contains(DBO.BaInstitution.BaInstitutionID) &&
                qryInstitutionB.DataTable.Columns.Contains(DBO.BaInstitution.BaInstitutionID) &&
                !DBUtil.IsEmpty(qryInstitutionA[DBO.BaInstitution.BaInstitutionID]) &&
                !DBUtil.IsEmpty(qryInstitutionB[DBO.BaInstitution.BaInstitutionID]))
            {
                buttonsEnabled = true;
            }

            btnMigrateAToB.Enabled = buttonsEnabled;
            btnMigrateBToA.Enabled = buttonsEnabled;
        }

        private void Migrate(int baInstitutionId, int baInstitutionIdDelete, string institution, string institutionDelete)
        {
            // validate first
            if (baInstitutionId == 0 || baInstitutionIdDelete == 0)
            {
                KissMsg.ShowInfo(Name, "InstitutionABLeer", "Es müssen 'Institution A' und 'Institution B' ausgefüllt sein!");
                return;
            }

            if (baInstitutionId == baInstitutionIdDelete)
            {
                KissMsg.ShowInfo(Name, "InstitutionABIdentisch", "Die IDs von 'Institution A' und 'Institution B' sind identisch!");
                return;
            }

            // check if different orgunits can be merged (see: #6853)
            if (PreventMigrateDifferentOrgUnits(baInstitutionId, baInstitutionIdDelete))
            {
                KissMsg.ShowInfo(Name,
                                 "InstitutionABDifferentOrgUnit_v02",
                                 "Die Institutionen A und B dürfen von Ihnen aufgrund der aktuellen {0}-Zuordnung nicht zusammengeführt werden!", lblAbteilung.Text);
                return;
            }

            // confirm before merge
            if (!KissMsg.ShowQuestion(Name, "StammdatenWerdenGeloescht", "Achtung: Die Stammdaten der Institution '{0}' werden gelöscht und alle Falldaten der Institution '{1}' zugeordnet.\r\n\r\nSoll diese Aktion durchgeführt werden?", 0, 0, false, institutionDelete, institution))
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

                // new history version
                DBUtil.NewHistoryVersion();

                // Adresses
                lblAktion.Text = KissMsg.GetMLMessage(Name, "ActionAdressen", "Info: Adressen bereinigen...");

                ApplicationFacade.DoEvents();

                DBUtil.ExecSQLThrowingException(60, @"
                    -- delete all addresses of the institution to delete where the other has an address (otherwise move address to new inst)
                    DELETE ADR
                    FROM dbo.BaAdresse ADR
                    WHERE ADR.BaInstitutionID = {1}
                          AND EXISTS (SELECT TOP 1 1
                                      FROM dbo.BaAdresse
                                      WHERE BaInstitutionID = {0});", baInstitutionId, baInstitutionIdDelete);

                // alle abhängigen Daten umhängen
                lblAktion.Text = KissMsg.GetMLMessage(Name, "ActionBeziehungen", "Info: Abhängige Daten umhängen...");

                ApplicationFacade.DoEvents();

                DBUtil.ExecSQLThrowingException(120, "EXECUTE dbo.spXRowMerge {0}, {1}, {2};", "BaInstitution", baInstitutionId, baInstitutionIdDelete);

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