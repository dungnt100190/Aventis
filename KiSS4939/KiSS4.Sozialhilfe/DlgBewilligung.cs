using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;
using KiSS4.Common;

namespace KiSS4.Sozialhilfe
{
    #region Enumerations

    public enum BewilligungAktion
    {
        KeineAktion = -1,
        Anfragen = 0,
        Zurueckweisen = 1,
        Bewilligen = 2,
        Weiterempfehlen = 3,
        Aufheben = 4,
        Sperren = 5,
        SperrungAufheben = 6,
    }

    public enum BewilligungTyp
    {
        FinanzPlan,
        Ueberbrueckungshilfe,
        Einzelzahlung,
        SIL
    }

    #endregion

    public class DlgBewilligung : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Protected Fields

        protected KiSS4.Gui.KissButton btnAbbrechen;
        protected KiSS4.Gui.KissButton btnNo;
        protected KissButton btnOk;
        protected KiSS4.Gui.KissButton btnYes;
        protected KiSS4.Gui.KissLookUpEdit cboXUser;
        protected KiSS4.Gui.KissCheckEdit chkEMail;
        protected KiSS4.Gui.KissCheckEdit chkSofort;
        protected KiSS4.Gui.KissMemoEdit edtBemerkung;
        protected KiSS4.Gui.KissDateEdit edtDatum;
        protected KiSS4.Gui.KissLabel lblBemerkung;
        protected KiSS4.Gui.KissLabel lblDatum;
        protected KiSS4.Gui.KissLabel lblEMail;
        protected KiSS4.Gui.KissLabel lblTitel;
        protected KiSS4.Gui.KissLabel lblXUser;
        protected SqlQuery qryBgBewilligung;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string DIESE = "diese";
        private const string DIESEM = "diesem";
        private const string DIESEN = "diesen";
        private const string DIESER = "dieser";
        private const string EINZELZAHLUNG = "Einzelzahlung";
        private const string FINANZPLAN = "Finanzplan";
        private const string UEBERBRUECKUNGSHILFE = "Überbrückungshilfe";
        private const string LOCK_IMMEDIATELY = @"Achtung: Wenn Sie den Finanzplan per sofort sperren, dann:

         - können keine Zahlungen mehr durchgeführt werden
         - können keine neuen Monatsbudgets mehr erstellt werden

        Sind Sie sicher, dass Sie diesen Finanzplan per sofort sperren wollen?";
        private const string SELECT_AUTOR = @"
            SELECT TOP 1
                BEW.UserID,
                BEW.UserID_An,
                BEW.OrgUnitID_ChefZustaendig,
                BEW.UserID_Zustaendig,
                BEW.Zurueckgewiesen,
                GRP.Kompetenzstufe
            FROM dbo.BgBewilligung BEW WITH(READUNCOMMITTED)
              INNER JOIN XUser USR WITH(READUNCOMMITTED) ON USR.UserID = BEW.UserID
              LEFT JOIN XPermissionGroup GRP WITH(READUNCOMMITTED) ON GRP.PermissionGroupID = USR.GrantPermGroupID
            WHERE {ID} = {0}
              AND BEW.BgBewilligungCode = 1
            ORDER BY BEW.Datum DESC";
        private const string SELECT_USER_ID_ANFRAGE = @"
            SELECT TOP 1 UserID
            FROM dbo.BgBewilligung WITH(READUNCOMMITTED)
            WHERE {ID} = {0} AND BgBewilligungCode = {1}
            ORDER BY Datum DESC";
        private const string SITUATIONSBEDINGTEN_LEISTUNG = "Situationsbedingten Leistung";
        private const string SITUATIONSBEDINGTE_LEISTUNG = "Situationsbedingte Leistung";
        private const string ZUSAETZLICHEN_LEISTUNG = "Zusätzlichen Leistung";
        private const string ZUSAETZLICHE_LEISTUNG = "Zusätzliche Leistung";

        #endregion

        #region Private Fields

        private Func<bool> _HasPermission;
        private Func<bool> _IsValid;
        private bool _amAutorZurueckgewiesen;
        private BgBewilligungStatus _bewilligungStatus;
        private DateTime _datum;
        private bool? _hasPermission;
        private bool? _isValid;
        private DateTime? _mindatum = null;
        private List<BewilligungAktion> _moeglicheAktionen;
        private Dictionary<BewilligungAktion, KissRadioGroup> _radioGroups;
        private int _recordID;
        private BewilligungTyp _typ;
        private bool _use6AugenPrinzip;
        private int? _userIDDefaultSelected = null;
        private int _userIDSAR;
        private int? _userID_Asked;
        private System.ComponentModel.IContainer components = null;
        private KissGroupBox grbAction;
        private SqlQuery qryUser;
        private SqlQuery qryUserUp;
        private SqlQuery qryUserDown;
        private SqlQuery qryUserFinanzplanDown;
        private SqlQuery qryUserOld;
        private SqlQuery qryUserOldAnfragen;
        private SqlQuery qryUserPositionDown;
        private KissRadioGroup rgrAnfragen;
        private KissRadioGroup rgrAufheben;
        private KissRadioGroup rgrBewilligen;
        private KissRadioGroup rgrWeiterempfehlen;
        private KissRadioGroup rgrZurueckweisen;
        private KissMemoEdit txtInfo;
        private SqlQuery qryUserFinanzplanUp;
        private SqlQuery qryUserPositionUp;

        private DateTime _sofortDate;

        #endregion

        #endregion

        #region Constructors

        public DlgBewilligung()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent call
            _use6AugenPrinzip = DBUtil.GetConfigBool(@"System\Sozialhilfe\Bewilligung\MehrAugenPrinzipBenutzen", false);
            if (!_use6AugenPrinzip)
            {
                this.qryUserOld.Fill(qryUser.SelectStatement, (int)Permission.Sh_User_ErhaeltAnfragen);
                this.qryUserOldAnfragen.Fill(qryUser.SelectStatement, (int)Permission.Sh_User_ErhaeltAnfragen);

                qryUserOldAnfragen.DataTable.DefaultView.RowFilter = "GrantPermGroupID IS NOT NULL AND Anfrage = 1";
                qryUserOldAnfragen.DataTable.Select(string.Format("UserID = 0{0} AND {1}", Session.User.ChiefID, qryUserOldAnfragen.DataTable.DefaultView.RowFilter));

                qryUser = qryUserOld;

                cboXUserLoadQuery();
            }

            SetupRadioGroups();
        }

        /// <summary>
        /// Konstruktor für das neue Bewilligungsverfahren (6-Augenprinzip). Aktionen sind im Dialog auswählbar.
        /// Die verfügbare Aktionen sind:
        ///     - Bewilligung Anfragen
        ///     - Zurückweisen
        ///     - Bewilligen
        ///     - Weiterempfehlen
        ///     - Aufheben
        /// </summary>
        /// <param name="typ">Typ der Bewilligung (FinanzPlan, Einzelzahlung, SIL). <see cref="BewilligungTyp"/></param>
        /// <param name="recordID">BgFinanzplanID oder BgPositionID je nach Typ</param>
        /// <param name="bewilligungStatus">Aktueller Status der Bewilligung. <see cref="BgBewilligungStatus"/></param>
        /// <param name="hasPermission">Funktion zum wissen ob der Benutzer genügend Kompetenz hat</param>
        public DlgBewilligung(BewilligungTyp typ, int recordID, BgBewilligungStatus bewilligungStatus, Func<bool> hasPermission)
            : this(typ, recordID, bewilligungStatus, IsValidDummy, hasPermission)
        {
        }

        /// <summary>
        /// Konstruktor für das neue Bewilligungsverfahren (6-Augenprinzip). Aktionen sind im Dialog auswählbar.
        /// Die verfügbare Aktionen sind:
        ///     - Bewilligung Anfragen
        ///     - Zurückweisen
        ///     - Bewilligen
        ///     - Weiterempfehlen
        ///     - Aufheben
        /// </summary>
        /// <param name="typ">Typ der Bewilligung (FinanzPlan, Einzelzahlung, SIL). <see cref="BewilligungTyp"/></param>
        /// <param name="recordID">BgFinanzplanID oder BgPositionID je nach Typ</param>
        /// <param name="bewilligungStatus">Aktueller Status der Bewilligung. <see cref="BgBewilligungStatus"/></param>
        /// <param name="isValid">Funktion zum wissen ob der Eintrag vollständig erfasst ist</param>
        /// <param name="hasPermission">Funktion zum wissen ob der Benutzer genügend Kompetenz hat</param>
        public DlgBewilligung(BewilligungTyp typ, int recordID, BgBewilligungStatus bewilligungStatus, Func<bool> isValid, Func<bool> hasPermission)
            : this()
        {
            btnYes.Visible = false;
            btnNo.Visible = false;

            _typ = typ;
            _recordID = recordID;
            _userIDSAR = GetUserIDSAR();
            _userID_Asked = GetUserIDAsked();
            _bewilligungStatus = bewilligungStatus;

            _IsValid = isValid;
            _HasPermission = hasPermission;

            if (_use6AugenPrinzip)
            {
                if (_typ == BewilligungTyp.FinanzPlan || _typ == BewilligungTyp.Ueberbrueckungshilfe)
                {
                    qryUserFinanzplanUp.Fill((int)_recordID, (int)Session.User.UserID);
                    qryUserFinanzplanDown.Fill((int)_recordID, (int)Session.User.UserID);

                    qryUserUp = qryUserFinanzplanUp;
                    qryUserDown = qryUserFinanzplanDown;

                    qryUser = qryUserUp;
                }
                else if (_typ == BewilligungTyp.Einzelzahlung || _typ == BewilligungTyp.SIL)
                {
                    qryUserPositionUp.Fill((int)_recordID, (int)Session.User.UserID);
                    qryUserPositionDown.Fill((int)_recordID, (int)Session.User.UserID);

                    qryUserUp = qryUserPositionUp;
                    qryUserDown = qryUserPositionDown;

                    qryUser = qryUserUp;
                }
                else
                {
                    //TODO: braucht es diesen Fall noch? Wenn ja, wann tritt er in Kraft?
                    this.qryUser.Fill((int)Permission.Sh_User_ErhaeltAnfragen);
                }

                cboXUserLoadQuery();
            }

            SetText();
            SelectRadioGroup();
            ChangeRadioGroupValue();
            SelectDefaultUser();

            if (Aktion == BewilligungAktion.KeineAktion)
            {
                btnOk.Enabled = false;
            }
        }

        public DlgBewilligung(BewilligungTyp typ, int recordID, BewilligungAktion aktion)
            : this()
        {
            grbAction.Visible = false;
            btnOk.Visible = false;
            this.ClientSize = new System.Drawing.Size(488, 270);

            _typ = typ;
            _recordID = recordID;
            Aktion = aktion;

            switch (Aktion)
            {
                case BewilligungAktion.Anfragen:
                    this.Text = "Bewilligung für {0} einholen";
                    this.lblTitel.Text = "Durch wen soll {1} {0} bewilligt werden?";
                    this.lblXUser.Text = "Mitarbeiter/-in";
                    qryUser.DataTable.DefaultView.RowFilter = "GrantPermGroupID IS NOT NULL AND Anfrage = 1";

                    if (qryUser.DataTable.Select(string.Format("UserID = 0{0} AND {1}", Session.User.ChiefID, qryUser.DataTable.DefaultView.RowFilter)).Length == 1)
                    {
                        this.cboXUser.EditValue = Session.User.ChiefID;
                    }

                    this.btnYes.Text = "Bewilligung anfragen";
                    break;

                case BewilligungAktion.Aufheben:
                    this.Text = "Bestehende Bewilligung aufheben";
                    this.lblTitel.Text = "Bewilligung für {1} {0} aufheben?";

                    this.cboXUser.EditValue = DBUtil.ExecuteScalarSQL(
                        ReplaceIDTag(SELECT_USER_ID_ANFRAGE)
                        , recordID, 2);
                    this.btnYes.Text = "Bewilligung aufheben";
                    break;

                case BewilligungAktion.Sperren:
                    this.Text = "{0} vorzeitig beenden";
                    this.lblTitel.Text = "{0} vorzeitig beenden?";
                    this.lblDatum.Text = "Beenden am";

                    this.chkSofort.Visible = true;
                    this.lblDatum.Visible = true;
                    this.edtDatum.Visible = true;
                    this.btnYes.Text = "Finanzplan beenden";

                    this.qryUser.Fill((int)Permission.Sh_User_ErhaeltAnfragen);
                    cboXUserLoadQuery();

                    break;

                case BewilligungAktion.SperrungAufheben:
                    this.Text = "Sperrung aufheben";
                    this.lblTitel.Text = "Sperrung von {1} {0} aufheben?";

                    this.btnYes.Text = "Sperrung aufheben";
                    break;
            }

            switch (typ)
            {
                case BewilligungTyp.FinanzPlan:
                    this.Text = string.Format(this.Text, FINANZPLAN);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, FINANZPLAN, DIESEN);
                    break;

                case BewilligungTyp.Ueberbrueckungshilfe:
                    this.Text = string.Format(this.Text, UEBERBRUECKUNGSHILFE);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, UEBERBRUECKUNGSHILFE, DIESER);
                    break;

                case BewilligungTyp.Einzelzahlung:
                    this.Text = string.Format(this.Text, EINZELZAHLUNG);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, EINZELZAHLUNG, DIESE);
                    this.lblDatum.Visible = false;
                    this.edtDatum.Visible = false;
                    break;

                case BewilligungTyp.SIL:
                    this.Text = string.Format(this.Text, "SIL");
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, "SIL", DIESE);
                    this.lblDatum.Visible = false;
                    this.edtDatum.Visible = false;
                    break;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgBewilligung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblXUser = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.btnYes = new KiSS4.Gui.KissButton();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.chkEMail = new KiSS4.Gui.KissCheckEdit();
            this.cboXUser = new KiSS4.Gui.KissLookUpEdit();
            this.chkSofort = new KiSS4.Gui.KissCheckEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.btnNo = new KiSS4.Gui.KissButton();
            this.qryBgBewilligung = new KiSS4.DB.SqlQuery(this.components);
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            this.btnOk = new KiSS4.Gui.KissButton();
            this.grbAction = new KiSS4.Gui.KissGroupBox();
            this.txtInfo = new KiSS4.Gui.KissMemoEdit();
            this.rgrAufheben = new KiSS4.Gui.KissRadioGroup(this.components);
            this.rgrWeiterempfehlen = new KiSS4.Gui.KissRadioGroup(this.components);
            this.rgrBewilligen = new KiSS4.Gui.KissRadioGroup(this.components);
            this.rgrZurueckweisen = new KiSS4.Gui.KissRadioGroup(this.components);
            this.rgrAnfragen = new KiSS4.Gui.KissRadioGroup(this.components);
            this.qryUserFinanzplanDown = new KiSS4.DB.SqlQuery(this.components);
            this.qryUserPositionDown = new KiSS4.DB.SqlQuery(this.components);
            this.qryUserOld = new KiSS4.DB.SqlQuery(this.components);
            this.qryUserOldAnfragen = new KiSS4.DB.SqlQuery(this.components);
            this.qryUserFinanzplanUp = new KiSS4.DB.SqlQuery(this.components);
            this.qryUserPositionUp = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblXUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboXUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboXUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSofort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            this.grbAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAufheben.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrWeiterempfehlen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrBewilligen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrZurueckweisen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAnfragen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserFinanzplanDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserPositionDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserOldAnfragen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserFinanzplanUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserPositionUp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblXUser
            // 
            this.lblXUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblXUser.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblXUser.Location = new System.Drawing.Point(8, 155);
            this.lblXUser.Name = "lblXUser";
            this.lblXUser.Size = new System.Drawing.Size(304, 16);
            this.lblXUser.TabIndex = 1;
            this.lblXUser.Text = "Zu benachrichtigender Mitarbeiter";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.Location = new System.Drawing.Point(8, 251);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(472, 104);
            this.edtBemerkung.TabIndex = 9;
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Location = new System.Drawing.Point(8, 363);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(144, 24);
            this.btnYes.TabIndex = 10;
            this.btnYes.Text = "Bewilligen";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYesNo_Click);
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(320, 219);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(96, 24);
            this.edtDatum.TabIndex = 7;
            this.edtDatum.Visible = false;
            // 
            // chkEMail
            // 
            this.chkEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEMail.EditValue = true;
            this.chkEMail.Location = new System.Drawing.Point(320, 171);
            this.chkEMail.Name = "chkEMail";
            this.chkEMail.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkEMail.Properties.Appearance.Options.UseBackColor = true;
            this.chkEMail.Properties.Caption = "per e-Mail benachrichtigen";
            this.chkEMail.Size = new System.Drawing.Size(160, 19);
            this.chkEMail.TabIndex = 3;
            // 
            // cboXUser
            // 
            this.cboXUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboXUser.Location = new System.Drawing.Point(8, 171);
            this.cboXUser.Name = "cboXUser";
            this.cboXUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboXUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboXUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboXUser.Properties.Appearance.Options.UseBackColor = true;
            this.cboXUser.Properties.Appearance.Options.UseBorderColor = true;
            this.cboXUser.Properties.Appearance.Options.UseFont = true;
            this.cboXUser.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboXUser.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboXUser.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboXUser.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboXUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.cboXUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.cboXUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboXUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname")});
            this.cboXUser.Properties.DisplayMember = "NameVorname";
            this.cboXUser.Properties.NullText = "";
            this.cboXUser.Properties.ShowFooter = false;
            this.cboXUser.Properties.ShowHeader = false;
            this.cboXUser.Properties.ValueMember = "UserID";
            this.cboXUser.Size = new System.Drawing.Size(304, 24);
            this.cboXUser.TabIndex = 2;
            this.cboXUser.EditValueChanged += new System.EventHandler(this.cboXUser_EditValueChanged);
            // 
            // chkSofort
            // 
            this.chkSofort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSofort.EditValue = false;
            this.chkSofort.Location = new System.Drawing.Point(320, 195);
            this.chkSofort.Name = "chkSofort";
            this.chkSofort.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSofort.Properties.Appearance.Options.UseBackColor = true;
            this.chkSofort.Properties.Caption = "per sofort sperren!";
            this.chkSofort.Size = new System.Drawing.Size(160, 19);
            this.chkSofort.TabIndex = 5;
            this.chkSofort.Visible = false;
            this.chkSofort.EditValueChanged += new System.EventHandler(this.chkSofort_EditValueChanged);
            this.chkSofort.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.chkSofort_EditValueChanging);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 235);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(144, 16);
            this.lblBemerkung.TabIndex = 8;
            this.lblBemerkung.Text = "Bemerkungen";
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(8, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(472, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "";
            // 
            // lblEMail
            // 
            this.lblEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEMail.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblEMail.Location = new System.Drawing.Point(8, 203);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(464, 16);
            this.lblEMail.TabIndex = 4;
            this.lblEMail.Text = "";
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(192, 219);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(120, 24);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Tag = "";
            this.lblDatum.Text = "Beenden am";
            this.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDatum.Visible = false;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(360, 363);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(120, 24);
            this.btnAbbrechen.TabIndex = 12;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Location = new System.Drawing.Point(160, 363);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(144, 24);
            this.btnNo.TabIndex = 11;
            this.btnNo.Text = "Zurückweisen";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnYesNo_Click);
            // 
            // qryBgBewilligung
            // 
            this.qryBgBewilligung.CanUpdate = true;
            this.qryBgBewilligung.HostControl = this;
            this.qryBgBewilligung.SelectStatement = "SELECT * \r\nFROM BgBewilligung \r\nWHERE 1 = 0";
            this.qryBgBewilligung.TableName = "BgBewilligung";
            // 
            // qryUser
            // 
            this.qryUser.HostControl = this;
            this.qryUser.SelectStatement = resources.GetString("qryUser.SelectStatement");
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(310, 363);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(44, 24);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grbAction
            // 
            this.grbAction.Controls.Add(this.txtInfo);
            this.grbAction.Controls.Add(this.rgrAufheben);
            this.grbAction.Controls.Add(this.rgrWeiterempfehlen);
            this.grbAction.Controls.Add(this.rgrBewilligen);
            this.grbAction.Controls.Add(this.rgrZurueckweisen);
            this.grbAction.Controls.Add(this.rgrAnfragen);
            this.grbAction.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grbAction.Location = new System.Drawing.Point(8, 27);
            this.grbAction.Name = "grbAction";
            this.grbAction.Size = new System.Drawing.Size(472, 121);
            this.grbAction.TabIndex = 519;
            this.grbAction.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtInfo.Location = new System.Drawing.Point(179, 12);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtInfo.Properties.Appearance.Options.UseBackColor = true;
            this.txtInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.txtInfo.Properties.Appearance.Options.UseFont = true;
            this.txtInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtInfo.Properties.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(287, 103);
            this.txtInfo.TabIndex = 5;
            // 
            // rgrAufheben
            // 
            this.rgrAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rgrAufheben.Enabled = false;
            this.rgrAufheben.Location = new System.Drawing.Point(7, 95);
            this.rgrAufheben.Name = "rgrAufheben";
            this.rgrAufheben.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrAufheben.Properties.Appearance.Options.UseBackColor = true;
            this.rgrAufheben.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrAufheben.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrAufheben.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrAufheben.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Aufheben")});
            this.rgrAufheben.Size = new System.Drawing.Size(166, 26);
            this.rgrAufheben.TabIndex = 4;
            this.rgrAufheben.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // rgrWeiterempfehlen
            // 
            this.rgrWeiterempfehlen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rgrWeiterempfehlen.Enabled = false;
            this.rgrWeiterempfehlen.Location = new System.Drawing.Point(7, 75);
            this.rgrWeiterempfehlen.Name = "rgrWeiterempfehlen";
            this.rgrWeiterempfehlen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrWeiterempfehlen.Properties.Appearance.Options.UseBackColor = true;
            this.rgrWeiterempfehlen.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrWeiterempfehlen.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrWeiterempfehlen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrWeiterempfehlen.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Weiterempfehlen")});
            this.rgrWeiterempfehlen.Size = new System.Drawing.Size(166, 26);
            this.rgrWeiterempfehlen.TabIndex = 3;
            this.rgrWeiterempfehlen.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // rgrBewilligen
            // 
            this.rgrBewilligen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rgrBewilligen.Enabled = false;
            this.rgrBewilligen.Location = new System.Drawing.Point(7, 55);
            this.rgrBewilligen.Name = "rgrBewilligen";
            this.rgrBewilligen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrBewilligen.Properties.Appearance.Options.UseBackColor = true;
            this.rgrBewilligen.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrBewilligen.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrBewilligen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrBewilligen.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Bewilligen")});
            this.rgrBewilligen.Size = new System.Drawing.Size(166, 26);
            this.rgrBewilligen.TabIndex = 2;
            this.rgrBewilligen.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // rgrZurueckweisen
            // 
            this.rgrZurueckweisen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rgrZurueckweisen.Enabled = false;
            this.rgrZurueckweisen.Location = new System.Drawing.Point(7, 35);
            this.rgrZurueckweisen.Name = "rgrZurueckweisen";
            this.rgrZurueckweisen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrZurueckweisen.Properties.Appearance.Options.UseBackColor = true;
            this.rgrZurueckweisen.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrZurueckweisen.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrZurueckweisen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrZurueckweisen.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Zurückweisen")});
            this.rgrZurueckweisen.Size = new System.Drawing.Size(166, 26);
            this.rgrZurueckweisen.TabIndex = 1;
            this.rgrZurueckweisen.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // rgrAnfragen
            // 
            this.rgrAnfragen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rgrAnfragen.Enabled = false;
            this.rgrAnfragen.Location = new System.Drawing.Point(7, 15);
            this.rgrAnfragen.Name = "rgrAnfragen";
            this.rgrAnfragen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrAnfragen.Properties.Appearance.Options.UseBackColor = true;
            this.rgrAnfragen.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrAnfragen.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrAnfragen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrAnfragen.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Bewilligung anfragen")});
            this.rgrAnfragen.Size = new System.Drawing.Size(166, 26);
            this.rgrAnfragen.TabIndex = 0;
            this.rgrAnfragen.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // qryUserFinanzplanDown
            // 
            this.qryUserFinanzplanDown.HostControl = this;
            this.qryUserFinanzplanDown.SelectStatement = resources.GetString("qryUserFinanzplanDown.SelectStatement");
            // 
            // qryUserPositionDown
            // 
            this.qryUserPositionDown.HostControl = this;
            this.qryUserPositionDown.SelectStatement = resources.GetString("qryUserPositionDown.SelectStatement");
            // 
            // qryUserOld
            // 
            this.qryUserOld.HostControl = this;
            // 
            // qryUserOldAnfragen
            // 
            this.qryUserOldAnfragen.HostControl = this;
            // 
            // qryUserFinanzplanUp
            // 
            this.qryUserFinanzplanUp.HostControl = this;
            this.qryUserFinanzplanUp.SelectStatement = resources.GetString("qryUserFinanzplanUp.SelectStatement");
            // 
            // qryUserPositionUp
            // 
            this.qryUserPositionUp.HostControl = this;
            this.qryUserPositionUp.SelectStatement = resources.GetString("qryUserPositionUp.SelectStatement");
            // 
            // DlgBewilligung
            // 
            this.ActiveSQLQuery = this.qryBgBewilligung;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(488, 399);
            this.Controls.Add(this.grbAction);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkSofort);
            this.Controls.Add(this.lblEMail);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.cboXUser);
            this.Controls.Add(this.chkEMail);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblXUser);
            this.Name = "DlgBewilligung";
            ((System.ComponentModel.ISupportInitialize)(this.lblXUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboXUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboXUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSofort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            this.grbAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAufheben.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrWeiterempfehlen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrBewilligen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrZurueckweisen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAnfragen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserFinanzplanDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserPositionDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserOldAnfragen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserFinanzplanUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserPositionUp)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        public BewilligungAktion Aktion
        {
            get;
            private set;
        }

        public DateTime? Datum
        {
            get { return edtDatum.EditValue as DateTime?; }
            set
            {
                this.edtDatum.EditValue = value;
                _datum = (DateTime)value;
            }
        }

        public DateTime? MinDatum
        {
            get { return _mindatum; }
            set
            {
                if (value is DateTime)
                {
                    _mindatum = value;
                }
                else
                {
                    _mindatum = null;
                }
            }
        }

        public BgBewilligungStatus? NextBewilligungStatus
        {
            get
            {
                return DlgBewilligung.GetNextBewilligungStatus(Aktion);
            }
        }

        public bool UserYes
        {
            get;
            private set;
        }

        #endregion

        #region EventHandlers

        private void btnAbbrechen_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.chkSofort.Checked && !KissMsg.ShowQuestion(null, null, LOCK_IMMEDIATELY, 500, 0))
            {
                return;
            }

            qryBgBewilligung = ShUtil.GetBgBewilligung_Neu();
            ActiveSQLQuery = qryBgBewilligung;

            qryBgBewilligung[DBO.BgBewilligung.UserID_An] = cboXUser.EditValue;
            qryBgBewilligung[DBO.BgBewilligung.Bemerkung] = edtBemerkung.EditValue;

            switch (_typ)
            {
                case BewilligungTyp.FinanzPlan:
                case BewilligungTyp.Ueberbrueckungshilfe:
                    qryBgBewilligung[DBO.BgBewilligung.BgFinanzplanID] = _recordID;
                    break;

                case BewilligungTyp.Einzelzahlung:
                    qryBgBewilligung[DBO.BgBewilligung.BgPositionID] = _recordID;
                    break;

                case BewilligungTyp.SIL:
                    qryBgBewilligung[DBO.BgBewilligung.BgPositionID] = _recordID;
                    qryBgBewilligung[DBO.BgBewilligung.BgFinanzplanID] = DBUtil.ExecuteScalarSQL(@"
                            SELECT BBG.BgFinanzplanID
                            FROM dbo.BgPosition        BPO WITH(READUNCOMMITTED)
                              INNER JOIN dbo.Bgbudget  BBG WITH(READUNCOMMITTED)ON BBG.BgBudgetID = BPO.BgbudgetID
                            WHERE BPO.BgPositionID = {0}"
                        , qryBgBewilligung[DBO.BgBewilligung.BgPositionID]);
                    break;
            }

            switch (Aktion)
            {
                case BewilligungAktion.Anfragen:
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 1;
                    qryBgBewilligung["OrgUnitID_ChefZustaendig"] = qryUser["OrgUnitID_Zustaendig"];
                    qryBgBewilligung[DBO.BgBewilligung.UserID_Zustaendig] = qryUser["UserID_Zustaendig"];
                    break;

                case BewilligungAktion.Zurueckweisen:
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 3;
                    SetZurueckgewiesenFlag();
                    break;

                case BewilligungAktion.Bewilligen:
                    if (!DBUtil.IsEmpty(this.edtDatum.EditValue) && _datum > (DateTime)this.edtDatum.EditValue)
                    {
                        KissMsg.ShowInfo("DlgBewilligung", "GueltigAbVorGeplantAb", "Das Datum 'Gültig ab' liegt vor dem Datum 'Geplant ab'");
                        return;
                    }
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 2;
                    qryBgBewilligung[DBO.BgBewilligung.PerDatum] = this.edtDatum.EditValue;
                    break;

                case BewilligungAktion.Weiterempfehlen:
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 11;
                    qryBgBewilligung["OrgUnitID_ChefZustaendig"] = qryUser["OrgUnitID_Zustaendig"];
                    qryBgBewilligung[DBO.BgBewilligung.UserID_Zustaendig] = qryUser["UserID_Zustaendig"];
                    break;

                case BewilligungAktion.Aufheben:
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 4;
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.UserYes = true;
            this.userCancel = false;
            this.Close();
            SendMail();
        }

        private void btnYesNo_Click(object sender, System.EventArgs e)
        {
            if (this.chkSofort.Checked && !KissMsg.ShowQuestion(null, null, LOCK_IMMEDIATELY, 500, 0))
            {
                return;
            }

            qryBgBewilligung = ShUtil.GetBgBewilligung_Neu();
            ActiveSQLQuery = qryBgBewilligung;

            qryBgBewilligung[DBO.BgBewilligung.UserID_An] = this.cboXUser.EditValue;
            qryBgBewilligung[DBO.BgBewilligung.Bemerkung] = this.edtBemerkung.EditValue;

            switch (_typ)
            {
                case BewilligungTyp.FinanzPlan:
                case BewilligungTyp.Ueberbrueckungshilfe:
                    qryBgBewilligung[DBO.BgBewilligung.BgFinanzplanID] = _recordID;
                    break;

                case BewilligungTyp.Einzelzahlung:
                    qryBgBewilligung[DBO.BgBewilligung.BgPositionID] = _recordID;
                    break;

                case BewilligungTyp.SIL:
                    qryBgBewilligung[DBO.BgBewilligung.BgPositionID] = _recordID;
                    qryBgBewilligung[DBO.BgBewilligung.BgFinanzplanID] = DBUtil.ExecuteScalarSQL(@"
                        SELECT BBG.BgFinanzplanID
                        FROM dbo.BgPosition        BPO WITH(READUNCOMMITTED)
                          INNER JOIN dbo.Bgbudget  BBG WITH(READUNCOMMITTED) ON BBG.BgBudgetID = BPO.BgbudgetID
                        WHERE BPO.BgPositionID = {0}", qryBgBewilligung[DBO.BgBewilligung.BgPositionID]);
                    break;
            }

            switch (Aktion)
            {
                case BewilligungAktion.Anfragen:
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 1;
                    break;

                case BewilligungAktion.Aufheben:
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 4;
                    break;

                case BewilligungAktion.Sperren:
                    if (!this.chkSofort.Checked)
                    {
                        if (!DBUtil.IsEmpty(this.edtDatum.EditValue) && _datum < (DateTime)this.edtDatum.EditValue)
                        {
                            KissMsg.ShowInfo("DlgBewilligung", "DatumNachGeplantDatum", "Das gewünschte Abschlussdatum liegt nach dem geplanten Abschlussdatum");
                            return;
                        }
                        else if (_mindatum != null && edtDatum.DateTime < (DateTime)_mindatum)
                        {
                            KissMsg.ShowInfo("DlgBewilligung", "FruehestensBeendungFinanzplan", "Der Finanzplan kann frühestens auf den {0:d} beendet werden (aufgrund grüner/roter Monatsbudgets)", 0, 0, _mindatum);
                            return;
                        }

                        qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 5;
                        qryBgBewilligung[DBO.BgBewilligung.PerDatum] = this.edtDatum.EditValue;
                    }
                    else
                    {
                        qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 6;
                    }
                    break;

                case BewilligungAktion.SperrungAufheben:
                    qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 7;
                    break;
            }

            this.UserYes = sender == this.btnYes;
            this.userCancel = false;
            this.DialogResult = DialogResult.Yes;
            this.Close();
            this.SendMail();
        }

        private void cboXUser_EditValueChanged(object sender, System.EventArgs e)
        {
            string eMail = null;

            try
            {
                DataRow[] rows = qryUser.DataTable.Select("UserID = " + DBUtil.SqlLiteral(this.cboXUser.EditValue));
                if (rows.Length > 0)
                {
                    eMail = rows[0]["EMail"].ToString();
                }
            }
            catch { }
            finally
            {
                this.lblEMail.Text = eMail;
            }
        }

        private void chkSofort_EditValueChanged(object sender, System.EventArgs e)
        {
            if (chkSofort.Checked)
            {
                edtDatum.EditMode = EditModeType.ReadOnly;
                edtDatum.EditValue = _sofortDate;
            }
            else
            {
                edtDatum.EditMode = EditModeType.Normal;
            }
        }

        private void chkSofort_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            _sofortDate = DateTime.Today.AddDays(-1) < _datum ? DateTime.Today.AddDays(-1) : _datum;
            if (_mindatum != null && (DateTime)_mindatum > _sofortDate)
            {
                KissMsg.ShowInfo(this.Name, "FinanzplanBeendungNichtMoeglich", "Der Finanzplan kann nicht per sofort beendet werden, da im Moment noch mindestens ein grünes/rotes Monatsbudget in der Zukunft liegt");
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// Changes the value for all radio button
        /// </summary>
        /// <param name="sender">must be a <see cref="KissRadioGroup"/> with a <see cref="BewilligungAktion"/> as value</param>
        /// <param name="e"></param>
        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is KissRadioGroup))
            {
                return;
            }

            Aktion = (BewilligungAktion)((KissRadioGroup)sender).EditValue;

            ResetInfo();
            SetText(Aktion);
            ChangeRadioGroupValue();
            SelectDefaultUser();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static BgBewilligungStatus? GetNextBewilligungStatus(BewilligungAktion aktion)
        {
            switch (aktion)
            {
                case BewilligungAktion.Anfragen:
                    return BgBewilligungStatus.Angefragt;

                case BewilligungAktion.Zurueckweisen:
                    return BgBewilligungStatus.Abgelehnt;

                case BewilligungAktion.Bewilligen:
                    return BgBewilligungStatus.Erteilt;

                case BewilligungAktion.Weiterempfehlen:
                    return BgBewilligungStatus.Angefragt;

                case BewilligungAktion.Aufheben:
                    return BgBewilligungStatus.InVorbereitung;

                default:
                    return null;
            }
        }

        #endregion

        #region Public Methods

        public override bool OnSaveData()
        {
            // kein automatisches Post beim schliessen
            return true;
        }

        #endregion

        #region Private Static Methods

        private static bool IsValidDummy()
        {
            return true;
        }

        #endregion

        #region Private Methods

        private void AddAktionAnfragen()
        {
            if (_bewilligungStatus == BgBewilligungStatus.InVorbereitung ||
                (_bewilligungStatus == BgBewilligungStatus.Abgelehnt && _amAutorZurueckgewiesen))
            {
                _moeglicheAktionen.Add(BewilligungAktion.Anfragen);

                if (!IsValid())
                {
                    ShowInfoIsNotValid();
                }
            }
        }

        private void AddAktionAufheben()
        {
            if (_typ == BewilligungTyp.FinanzPlan || _typ == BewilligungTyp.Ueberbrueckungshilfe)
            {
                if ((_bewilligungStatus == BgBewilligungStatus.Erteilt || _bewilligungStatus == BgBewilligungStatus.Gesperrt) &&
                    DBUtil.UserHasRight(Rights.CtlWhFinanzplan_Aufheben))
                {
                    if (HasGreenOrRedBudget())
                    {
                        ShowInfoHasGreenOrRedBudget();
                    }
                    else if (HasGrayBudgets())
                    {
                        ShowInfoHasGrayBudgets();
                    }
                    else
                    {
                        _moeglicheAktionen.Add(BewilligungAktion.Aufheben);
                    }
                }
            }
            else if (_typ == BewilligungTyp.Einzelzahlung && _bewilligungStatus == BgBewilligungStatus.Erteilt)
            {
                _moeglicheAktionen.Add(BewilligungAktion.Aufheben);
            }
        }

        private void AddAktionWeiterempfehlenBewilligen()
        {
            // Ist vollständig erfasst?
            if (ShowBewilligen() && IsValid())
            {
                if ((_bewilligungStatus == BgBewilligungStatus.Angefragt && Session.User.UserID != _userID_Asked)
                    || (_bewilligungStatus == BgBewilligungStatus.Abgelehnt && !_amAutorZurueckgewiesen))
                {
                    _moeglicheAktionen.Add(BewilligungAktion.Weiterempfehlen);
                }

                // Hat genügend Kompetenz?
                if (HasPermission())
                {
                    _moeglicheAktionen.Add(BewilligungAktion.Bewilligen);
                }
            }
        }

        private void AddAktionZurueckweisen()
        {
            if ((_bewilligungStatus == BgBewilligungStatus.Angefragt || _bewilligungStatus == BgBewilligungStatus.Abgelehnt) && !_amAutorZurueckgewiesen)
            {
                _moeglicheAktionen.Add(BewilligungAktion.Zurueckweisen);
            }
        }

        private void AddDefaultUserToList(int? userID)
        {
            if (_use6AugenPrinzip)
            {
                if (userID.HasValue)
                {
                    SqlQuery qry = DBUtil.OpenSQL(@"
                        SELECT
                          USR.UserID,
                          USR.NameVorname,
                          USR.EMail,
                          GRP.Kompetenzstufe
                        FROM dbo.vwUser USR WITH(READUNCOMMITTED)
                          INNER JOIN dbo.XPermissionGroup GRP WITH(READUNCOMMITTED) ON GRP.PermissionGroupID = USR.GrantPermGroupID
                        WHERE UserID = {0}"
                        , userID);

                    AddDefaultUserToQuery(qry[DBO.vwUser.UserID], qry[DBO.vwUser.NameVorname], qry[DBO.vwUser.EMail], qry["Kompetenzstufe"]);
                    lblEMail.Text = DBUtil.IsEmpty(qry[DBO.vwUser.EMail]) ? "" : qry[DBO.vwUser.EMail].ToString();
                }
                else
                {
                    AddDefaultUserToQuery(DBNull.Value, DBNull.Value, DBNull.Value, 0);
                    lblEMail.Text = "";
                }
            }
        }

        private void AddDefaultUserToQuery(object userID, object nameVorname, object eMail, object kompetenzstufe)
        {
            if (qryUser.Position != 1)
            {
                qryUser.Position = 1;
            }
            qryUser[DBO.vwUser.UserID] = userID;
            qryUser[DBO.vwUser.NameVorname] = nameVorname;
            qryUser[DBO.vwUser.EMail] = eMail;
            qryUser["Kompetenzstufe"] = kompetenzstufe;
        }

        /// <summary>
        /// Um zu wissen ob die Bewilligung am Autor zurückgewiesen wurde.
        /// </summary>
        /// <returns>true wenn die Bewilligung am Autor zurückgewiesen wurde</returns>
        private bool AmAutorZurueckgewiesen()
        {
            SqlQuery qryAutor = GetQueryAutor();

            if (qryAutor.IsEmpty)
            {
                return true;
            }

            return (bool)qryAutor[DBO.BgBewilligung.Zurueckgewiesen];
        }

        private void ChangeRadioGroupValue()
        {
            foreach (KissRadioGroup radiogroup in _radioGroups.Values)
            {
                radiogroup.SelectedIndexChanged -= new System.EventHandler(this.radioGroup_SelectedIndexChanged);
                radiogroup.EditValue = (int)Aktion;
                radiogroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            }
        }

        private SqlQuery GetQueryAutor()
        {
            return DBUtil.OpenSQL(ReplaceIDTag(SELECT_AUTOR), _recordID);
        }

        private int? GetUserIDAsked()
        {
            string select = @"
                SELECT TOP 1 UserID
                FROM dbo.BgBewilligung WITH(READUNCOMMITTED)
                WHERE {ID} = {0}
                ORDER BY Datum DESC";

            return DBUtil.ExecuteScalarSQLThrowingException(ReplaceIDTag(select), _recordID) as int?;
        }

        /// <summary>
        /// Gibt die Autor's UserID
        /// </summary>
        /// <param name="userID">Typ der Bewilligung</param>
        /// <param name="kompetenzstufe">BgFinanzplanID oder BgPositionID</param>
        /// <returns>UserID vom Autor der Bewilligung</returns>
        private void GetUserIDAutor(out int? userID, out int? kompetenzstufe)
        {
            SqlQuery qryAutor = GetQueryAutor();

            if (qryAutor.IsEmpty)
            {
                userID = null;
                kompetenzstufe = null;
                return;
            }

            userID = qryAutor[DBO.BgBewilligung.UserID] as int?;
            kompetenzstufe = qryAutor["Kompetenzstufe"] as int?;
        }

        private int GetUserIDSAR()
        {
            switch (_typ)
            {
                case BewilligungTyp.FinanzPlan:
                case BewilligungTyp.Ueberbrueckungshilfe:
                    return (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT TOP 1 UserID
                        FROM dbo.FaLeistung           LEI WITH(READUNCOMMITTED)
                          INNER JOIN dbo.BgFinanzplan FPL WITH(READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
                        WHERE BgFinanzplanID = {0}"
                        , _recordID);

                case BewilligungTyp.Einzelzahlung:
                case BewilligungTyp.SIL:
                    return (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT TOP 1 UserID
                        FROM dbo.BgPosition           POS WITH(READUNCOMMITTED)
                          INNER JOIN dbo.BgBudget     BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
                          INNER JOIN dbo.BgFinanzplan FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
                          INNER JOIN dbo.FaLeistung   LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
                        WHERE BgPositionID = {0}"
                        , _recordID);
            }

            return 0;
        }

        private bool HasGreenOrRedBudget()
        {
            return (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(*)
                FROM dbo.BgBudget WITH(READUNCOMMITTED)
                WHERE MasterBudget = 0
                  AND BgBewilligungStatusCode IN (5, 9)
                  AND BgFinanzplanID = {0}"
                , _recordID) > 0;
        }

        private bool HasGrayBudgets()
        {
            return (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(*)
                FROM dbo.BgBudget WITH(READUNCOMMITTED)
                WHERE MasterBudget = 0
                  AND BgBewilligungStatusCode = 1
                  AND BgFinanzplanID = {0}"
                , _recordID) > 0;
        }

        private bool HasPermission()
        {
            if (_hasPermission.HasValue)
            {
                return _hasPermission.Value;
            }

            _hasPermission = _HasPermission();
            return _hasPermission.Value;
        }

        private bool IsValid()
        {
            if (_isValid.HasValue)
            {
                return _isValid.Value;
            }

            _isValid = _IsValid();
            return _isValid.Value;
        }

        private string ReplaceIDTag(string selectUserID)
        {
            if (_typ == BewilligungTyp.FinanzPlan || _typ == BewilligungTyp.Ueberbrueckungshilfe)
            {
                return selectUserID.Replace("{ID}", DBO.BgBewilligung.BgFinanzplanID);
            }
            else
            {
                return selectUserID.Replace("{ID}", DBO.BgBewilligung.BgPositionID);
            }
        }

        private void ResetInfo()
        {
            txtInfo.Visible = false;
            txtInfo.Text = string.Empty;
        }

        private void SelectAutor()
        {
            if (_use6AugenPrinzip)
            {
                string userSql = @"
                    SELECT 
                      USR.UserID,
                      USR.NameVorname, 
                      USR.EMail,
                      GRP.Kompetenzstufe
                    FROM vwUser USR
                      LEFT JOIN XPermissionGroup GRP ON GRP.PermissionGroupID = USR.GrantPermGroupID
                    WHERE USR.UserID IN ({0}, {1})
                      AND USR.IsLocked = 0
                    UNION ALL
                    SELECT NULL, NULL, NULL, NULL
                    ORDER BY NameVorname
                ";

                int? kompetenzStufe;
                GetUserIDAutor(out _userIDDefaultSelected, out kompetenzStufe);

                //Mantis#6238: Sicherstellen, dass auch der SAR in der Liste zur Auswahl steht
                qryUser = DBUtil.OpenSQL(userSql, _userIDDefaultSelected, _userIDSAR);

                cboXUser.LoadQuery(qryUser, DBO.vwUser.UserID, DBO.vwUser.NameVorname);

                cboXUser.EditValue = _userIDDefaultSelected;
            }
            else
            {
                qryUser = qryUserOld;
                cboXUserLoadQuery();

                //#7713, Der Autor war nicht angewählt beim Bewilligen eines FP.
                int? kompetenzStufe; //brauchen wir nicht, nur den Autor.
                GetUserIDAutor(out _userIDDefaultSelected, out kompetenzStufe);
                cboXUser.EditValue = _userIDDefaultSelected;
            }
        }

        /// <summary>
        /// Richtige Person auswählen
        /// </summary>
        private void SelectDefaultUser()
        {
            switch (Aktion)
            {
                case BewilligungAktion.Anfragen:
                case BewilligungAktion.Weiterempfehlen:
                    SelectNextUser();
                    break;
                case BewilligungAktion.Zurueckweisen:
                    SelectPreviousUser();
                    break;
                case BewilligungAktion.Bewilligen:
                case BewilligungAktion.Aufheben:
                    SelectAutor();
                    break;
            }
        }

        /// <summary>
        /// Nächste Person in der Hierarchie
        /// </summary>
        private void SelectNextUser()
        {
            if (_use6AugenPrinzip)
            {
                qryUser = qryUserUp;
                cboXUser.LoadQuery(qryUser, DBO.vwUser.UserID, DBO.vwUser.NameVorname);

                //select default-user
                _userIDDefaultSelected = qryUser["UserID_Zustaendig"] as int?;
                cboXUser.EditValue = _userIDDefaultSelected;
                AddDefaultUserToList(_userIDDefaultSelected);

                //                string selectOrgUnitID_Asked = @"
                //                    SELECT TOP 1 OrgUnitID_An
                //                    FROM dbo.BgBewilligung WITH(READUNCOMMITTED)
                //                    WHERE {ID} = {0}
                //                      AND BgBewilligungCode IN (1, 11) -- Anfrage zur Bewilligung, Weiterempfohlen
                //                      AND OrgUnitID_An IS NOT NULL
                //                      AND Zurueckgewiesen = 0
                //                      AND BgBewilligungID > (SELECT TOP 1 BgBewilligungID
                //                                             FROM dbo.BgBewilligung WITH(READUNCOMMITTED)
                //                                             WHERE {ID} = {0}
                //                                               AND BgBewilligungCode = 1
                //                                             ORDER BY Datum DESC)
                //                    ORDER BY Datum DESC";

                //                int? orgUnitID_Asked = DBUtil.ExecuteScalarSQLThrowingException(ReplaceIDTag(selectOrgUnitID_Asked), _recordID) as int?;

                //                if (Aktion == BewilligungAktion.Anfragen)
                //                {
                //                    if (Session.User.UserID == _userIDSAR)
                //                    {
                //                        SelectNextUserWhenUserIsSAR();
                //                    }
                //                    else
                //                    {
                //                        _userIDDefaultSelected = _userIDSAR;
                //                        _orgUnitID_An = null;
                //                    }
                //                }
                //                else if (_userID_Asked == _userIDSAR && !orgUnitID_Asked.HasValue)
                //                {
                //                    if (Session.User.UserID == _userIDSAR)
                //                    {
                //                        SelectNextUserWhenUserIsSAR();
                //                    }
                //                    else
                //                    {
                //                        string selectUserID = @"
                //                            SELECT
                //                              ORG.ChiefID,
                //                              ORG.OrgUnitID
                //                            FROM dbo.XOrgUnit ORG WITH(READUNCOMMITTED)
                //                              INNER JOIN dbo.vwUser USR WITH(READUNCOMMITTED) ON USR.OrgUnitID = ORG.OrgUnitID
                //                            WHERE USR.UserID = {0}";

                //                        SqlQuery qryOrgUnit = DBUtil.OpenSQL(selectUserID, _userIDSAR);

                //                        _userIDDefaultSelected = qryOrgUnit[DBO.XOrgUnit.ChiefID] as int?;
                //                        _orgUnitID_An = qryOrgUnit[DBO.XOrgUnit.OrgUnitID] as int?;

                //                        if (_userIDDefaultSelected == _userID_Asked)
                //                        {
                //                            SelectNextUserByOrgUnitID(_orgUnitID_An);
                //                        }
                //                    }
                //                }
                //                else
                //                {
                //                    SelectNextUserByOrgUnitID(orgUnitID_Asked);
                //                }

                //                AddDefaultUserToList(_userIDDefaultSelected);
                //                cboXUser.EditValue = _userIDDefaultSelected;
            }
            else
            {
                qryUser = qryUserOldAnfragen;
                cboXUserLoadQuery();

                if (qryUserOldAnfragen.Count == 1)
                {
                    cboXUser.EditValue = Session.User.ChiefID;
                }
            }
        }

        /// <summary>
        /// Vorherige Person
        /// </summary>
        private void SelectPreviousUser()
        {
            if (_use6AugenPrinzip)
            {
                //Gemäss Anforderungsdokument (Kap. 3.1), der Absender wird als Default vorgeschlagen
                string selectUserID = @"
                    SELECT TOP 1 UserID
                    FROM dbo.BgBewilligung WITH(READUNCOMMITTED)
                    WHERE {ID} = {0}
                    AND UserID_Zustaendig IS NOT NULL
                    AND Zurueckgewiesen = 0
                    ORDER BY Datum DESC;";

                _userIDDefaultSelected = (int?)DBUtil.ExecuteScalarSQLThrowingException(ReplaceIDTag(selectUserID), _recordID);

                //if there is no bewilligung-record at all, we select the SAR
                if (!_userIDDefaultSelected.HasValue)
                {
                    _userIDDefaultSelected = _userIDSAR;
                }

                qryUser = qryUserDown;
                cboXUser.LoadQuery(qryUser, DBO.vwUser.UserID, DBO.vwUser.NameVorname);

                cboXUser.EditValue = _userIDDefaultSelected;
                AddDefaultUserToList(_userIDDefaultSelected);
            }
            else
            {
                qryUser = qryUserOld;
                cboXUserLoadQuery();
            }
        }

        private void SelectRadioGroup()
        {
            SetMoeglicheAktionen();

            var radioGroupToEnable = from radioGroup in _radioGroups
                                     where _moeglicheAktionen.Contains(radioGroup.Key)
                                     select radioGroup.Value;

            foreach (KissRadioGroup radioGroup in radioGroupToEnable)
            {
                radioGroup.Enabled = true;
            }

            if (_moeglicheAktionen.Count == 0)
            {
                Aktion = BewilligungAktion.KeineAktion;
            }
            else
            {
                Aktion = _moeglicheAktionen.Min();
            }

            if (_moeglicheAktionen.Contains(BewilligungAktion.Bewilligen))
            {
                rgrBewilligen.EditValue = (int)BewilligungAktion.Bewilligen;
                Aktion = BewilligungAktion.Bewilligen;
            }
            else if (_moeglicheAktionen.Contains(BewilligungAktion.Weiterempfehlen))
            {
                Aktion = BewilligungAktion.Weiterempfehlen;
            }

            if (_typ == BewilligungTyp.SIL)
            {
                rgrAufheben.Visible = false;
            }

            SetText(Aktion);
        }

        private void SendMail()
        {
            if (!this.chkEMail.Checked) return;
            if (this.lblEMail.Text == "") return;

            try
            {
                ShUtil.SendMail(_typ, this.Aktion, this.lblEMail.Text, Utils.ConvertToInt(cboXUser.EditValue), _recordID, this.chkSofort.Checked, this.edtBemerkung.Text);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("DlgBewilligung", "FehlerEmailSenden", "Fehler beim senden der E-Mail", ex);
            }
        }

        private void SetMoeglicheAktionen()
        {
            _moeglicheAktionen = new List<BewilligungAktion>();
            _amAutorZurueckgewiesen = AmAutorZurueckgewiesen();

            AddAktionAnfragen();
            AddAktionZurueckweisen();
            AddAktionWeiterempfehlenBewilligen();
            AddAktionAufheben();
        }

        private void SetText()
        {
            ResetInfo();

            this.Text = "{0} bewilligen";
            this.lblTitel.Text = "Was wollen Sie mit {1} {0}?";

            switch (_typ)
            {
                case BewilligungTyp.FinanzPlan:
                    this.Text = string.Format(this.Text, FINANZPLAN);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, FINANZPLAN, DIESEM);
                    break;

                case BewilligungTyp.Ueberbrueckungshilfe:
                    this.Text = string.Format(this.Text, UEBERBRUECKUNGSHILFE);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, UEBERBRUECKUNGSHILFE, DIESER);
                    break;
                case BewilligungTyp.Einzelzahlung:
                    this.Text = string.Format(this.Text, ZUSAETZLICHE_LEISTUNG);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, ZUSAETZLICHEN_LEISTUNG, DIESER);
                    break;

                case BewilligungTyp.SIL:
                    this.Text = string.Format(this.Text, SITUATIONSBEDINGTE_LEISTUNG);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, SITUATIONSBEDINGTEN_LEISTUNG, DIESER);
                    break;
            }
        }

        private void SetText(BewilligungAktion aktion)
        {
            if (aktion == BewilligungAktion.Bewilligen || aktion == BewilligungAktion.Zurueckweisen)
            {
                this.lblBemerkung.Text = "Begründung";
                this.lblDatum.Text = "Gültig ab";
            }
            else
            {
                this.lblBemerkung.Text = "Bemerkungen";
            }

            if (aktion == BewilligungAktion.Bewilligen && (_typ == BewilligungTyp.FinanzPlan || _typ == BewilligungTyp.Ueberbrueckungshilfe))
            {
                this.lblDatum.Visible = true;
                this.edtDatum.Visible = true;
            }
            else
            {
                this.lblDatum.Visible = false;
                this.edtDatum.Visible = false;
            }
        }

        private void SetZurueckgewiesenFlag()
        {
            string updateLetzteWeiterempfehlung = @"
                UPDATE dbo.BgBewilligung
                  SET Zurueckgewiesen = 1
                WHERE BgBewilligungID = (SELECT TOP 1 BgBewilligungID
                                         FROM dbo.BgBewilligung WITH (READUNCOMMITTED)
                                         WHERE {ID} = {0}
                                           AND Zurueckgewiesen = 0
                                           AND bgBewilligungCode IN (1, 11)
                                         ORDER BY Datum DESC)";

            DBUtil.ExecSQLThrowingException(ReplaceIDTag(updateLetzteWeiterempfehlung), _recordID);
        }

        private void SetupRadioGroups()
        {
            _radioGroups = new Dictionary<BewilligungAktion, KissRadioGroup>();
            _radioGroups.Add(BewilligungAktion.Anfragen, rgrAnfragen);
            _radioGroups.Add(BewilligungAktion.Zurueckweisen, rgrZurueckweisen);
            _radioGroups.Add(BewilligungAktion.Bewilligen, rgrBewilligen);
            _radioGroups.Add(BewilligungAktion.Weiterempfehlen, rgrWeiterempfehlen);
            _radioGroups.Add(BewilligungAktion.Aufheben, rgrAufheben);
        }

        private bool ShowBewilligen()
        {
            return _bewilligungStatus == BgBewilligungStatus.InVorbereitung ||
                   _bewilligungStatus == BgBewilligungStatus.Angefragt ||
                   _bewilligungStatus == BgBewilligungStatus.Abgelehnt;
        }

        private void ShowInfoHasGrayBudgets()
        {
            txtInfo.Visible = true;
            txtInfo.Text = KissMsg.GetMLMessage(this.Name, "FinanzplanAufhebenNichtMoeglichGrau", "Der Finanzplan kann nicht aufgehoben werden solange graue Monatsbudgets existieren.");
        }

        private void ShowInfoHasGreenOrRedBudget()
        {
            txtInfo.Visible = true;
            txtInfo.Text = KissMsg.GetMLMessage(this.Name, "FinanzplanAufhebenNichtMoeglich", "Der Finanzplan kann nicht aufgehoben werden (aufgrund grüner/roter Monatsbudgets)");
        }

        private void ShowInfoIsNotValid()
        {
            txtInfo.Visible = true;
            txtInfo.Text = KissMsg.GetMLMessage(this.Name, "FinanzplanUnvollstaendig", "Der Finanzplan ist unvollständig erfasst");

            KissMsg.ShowInfo(this.Name, "FinanzplanUnvollstaendig", "Der Finanzplan ist unvollständig erfasst");
        }

        private void cboXUserLoadQuery()
        {
            cboXUser.LoadQuery(qryUser, DBO.vwUser.UserID, DBO.vwUser.NameVorname);
        }

        #endregion

        #endregion
    }
}