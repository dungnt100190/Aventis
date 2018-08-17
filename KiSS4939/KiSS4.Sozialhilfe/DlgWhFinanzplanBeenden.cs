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

namespace KiSS4.Sozialhilfe
{
    public class DlgWhFinanzplanBeenden : KiSS4.Gui.KissDialog //DlgBewilligung
    {
        #region Fields

        #region Protected Fields

        protected KiSS4.Gui.KissButton btnAbbrechen;
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
        private const string FINANZPLAN = "Finanzplan";
        private const string UEBERBRUECKUNGSHILFE = "Überbrückungshilfe";
        private const string LOCK_IMMEDIATELY_FINANZPLAN = @"Achtung: Wenn Sie den Finanzplan per sofort sperren, dann:

         - können keine Zahlungen mehr durchgeführt werden
         - können keine neuen Monatsbudgets mehr erstellt werden

        Sind Sie sicher, dass Sie diesen Finanzplan per sofort sperren wollen?";

        private const string LOCK_IMMEDIATELY_UEBERBRUECKUNGSHILFE = @"Achtung: Wenn Sie die Überbrückungshilfe per sofort sperren, dann:

         - können keine Zahlungen mehr durchgeführt werden
         - können keine neuen Monatsbudgets mehr erstellt werden

        Sind Sie sicher, dass Sie diese Überbrückungshilfe per sofort sperren wollen?";

        #endregion

        #region Private Fields

        private DateTime _datum;
        private DateTime? _mindatum = null;
        private int _recordID;
        private BewilligungTyp _typ;
        private bool _use6AugenPrinzip;
        private System.ComponentModel.IContainer components = null;
        private SqlQuery qryUser;
        private SqlQuery qryUserFinanzplan;

        private DateTime _sofortDate;

        #endregion

        #endregion

        private KiSS4.Gui.KissCheckEdit edtNeuerFPinnerhalbLE;
		private KiSS4.Gui.KissLabel lblKopie;
        private KiSS4.Gui.KissLabel lblGrundBeendigung;
		private KiSS4.Gui.KissLookUpEdit ddlGrundBeendigung;

        public DlgWhFinanzplanBeenden()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public DlgWhFinanzplanBeenden(BewilligungTyp typ, int recordID)
            : this()
        {
            //this.ClientSize = new System.Drawing.Size(488, 270);

            // Add any initialization after the InitializeComponent call
            _use6AugenPrinzip = DBUtil.GetConfigBool(@"System\Sozialhilfe\Bewilligung\MehrAugenPrinzipBenutzen", false);
            if (!_use6AugenPrinzip)
            {
                this.qryUser.Fill(qryUser.SelectStatement, (int)Permission.Sh_User_ErhaeltAnfragen);

                cboXUserLoadQuery();
            }



            _typ = typ;
            _recordID = recordID;
            Aktion = BewilligungAktion.Sperren;

            this.Text = "{0} vorzeitig beenden";
            this.lblTitel.Text = "{0} vorzeitig beenden?";
            this.lblDatum.Text = "Beenden am";

            this.chkSofort.Visible = true;
            this.lblDatum.Visible = true;
            this.edtDatum.Visible = true;
            this.btnYes.Text = "{0} beenden";

            this.qryUser.Fill((int)Permission.Sh_User_ErhaeltAnfragen);
            cboXUserLoadQuery();

            switch (typ)
            {
                case BewilligungTyp.FinanzPlan:
                    this.Text = string.Format(this.Text, FINANZPLAN);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, FINANZPLAN, DIESEN);
                    this.btnYes.Text = string.Format(this.btnYes.Text, FINANZPLAN);
                    break;

                case BewilligungTyp.Ueberbrueckungshilfe:
                    this.Text = string.Format(this.Text, UEBERBRUECKUNGSHILFE);
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, UEBERBRUECKUNGSHILFE, DIESE);
                    this.btnYes.Text = string.Format(this.btnYes.Text, UEBERBRUECKUNGSHILFE);
                    break;
            }
        }

		public object GrundEnde
		{
			get { return ddlGrundBeendigung.EditValue; }
			set { this.ddlGrundBeendigung.EditValue = value; }
		}

		public object FinanzPlanNeu
		{
			get { return edtNeuerFPinnerhalbLE.EditValue; }
			set { this.edtNeuerFPinnerhalbLE.EditValue = value; }
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgWhFinanzplanBeenden));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.qryBgBewilligung = new KiSS4.DB.SqlQuery(this.components);
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            this.qryUserFinanzplan = new KiSS4.DB.SqlQuery(this.components);
            this.edtNeuerFPinnerhalbLE = new KiSS4.Gui.KissCheckEdit();
            this.lblKopie = new KiSS4.Gui.KissLabel();
            this.lblGrundBeendigung = new KiSS4.Gui.KissLabel();
            this.ddlGrundBeendigung = new KiSS4.Gui.KissLookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.qryUserFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeuerFPinnerhalbLE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKopie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundBeendigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrundBeendigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrundBeendigung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblXUser
            // 
            this.lblXUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblXUser.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblXUser.Location = new System.Drawing.Point(8, 26);
            this.lblXUser.Name = "lblXUser";
            this.lblXUser.Size = new System.Drawing.Size(304, 16);
            this.lblXUser.TabIndex = 1;
            this.lblXUser.Text = "Zu benachrichtigender Mitarbeiter";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.Location = new System.Drawing.Point(8, 217);
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
            this.btnYes.Location = new System.Drawing.Point(8, 329);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(183, 24);
            this.btnYes.TabIndex = 10;
            this.btnYes.Text = "Bewilligen";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYesNo_Click);
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(320, 185);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
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
            this.chkEMail.Location = new System.Drawing.Point(320, 42);
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
            this.cboXUser.Location = new System.Drawing.Point(8, 42);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.cboXUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
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
            this.chkSofort.Location = new System.Drawing.Point(320, 66);
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
            this.lblBemerkung.Location = new System.Drawing.Point(8, 201);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(144, 16);
            this.lblBemerkung.TabIndex = 8;
            this.lblBemerkung.Text = "Begründung";
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
            this.lblEMail.Location = new System.Drawing.Point(8, 74);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(464, 16);
            this.lblEMail.TabIndex = 4;
            this.lblEMail.Text = "";
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(192, 185);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(120, 24);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Tag = "";
            this.lblDatum.Text = "Beenden per";
            this.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDatum.Visible = false;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(360, 329);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(120, 24);
            this.btnAbbrechen.TabIndex = 12;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
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
            // qryUserFinanzplan
            // 
            this.qryUserFinanzplan.HostControl = this;
            // 
            // edtNeuerFPinnerhalbLE
            // 
            this.edtNeuerFPinnerhalbLE.EditValue = false;
            this.edtNeuerFPinnerhalbLE.Location = new System.Drawing.Point(320, 145);
            this.edtNeuerFPinnerhalbLE.Name = "edtNeuerFPinnerhalbLE";
            this.edtNeuerFPinnerhalbLE.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNeuerFPinnerhalbLE.Properties.Appearance.Options.UseBackColor = true;
            this.edtNeuerFPinnerhalbLE.Properties.Caption = "";
            this.edtNeuerFPinnerhalbLE.Size = new System.Drawing.Size(32, 19);
            this.edtNeuerFPinnerhalbLE.TabIndex = 21;
            // 
            // lblKopie
            // 
            this.lblKopie.Location = new System.Drawing.Point(6, 140);
            this.lblKopie.Name = "lblKopie";
            this.lblKopie.Size = new System.Drawing.Size(317, 24);
            this.lblKopie.TabIndex = 20;
            this.lblKopie.Text = "Soll ein neuer Finanzplan erstellt werden (Kopie des letzten)?";
            this.lblKopie.UseCompatibleTextRendering = true;
            // 
            // lblGrundBeendigung
            // 
            this.lblGrundBeendigung.Location = new System.Drawing.Point(6, 99);
            this.lblGrundBeendigung.Name = "lblGrundBeendigung";
            this.lblGrundBeendigung.Size = new System.Drawing.Size(156, 24);
            this.lblGrundBeendigung.TabIndex = 19;
            this.lblGrundBeendigung.Text = "Grund vorzeitige Beendigung";
            this.lblGrundBeendigung.UseCompatibleTextRendering = true;
            // 
            // ddlGrundBeendigung
            // 
            this.ddlGrundBeendigung.Location = new System.Drawing.Point(162, 99);
            this.ddlGrundBeendigung.LOVName = "BgFPGrundAbschluss";
            this.ddlGrundBeendigung.Name = "ddlGrundBeendigung";
            this.ddlGrundBeendigung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlGrundBeendigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlGrundBeendigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlGrundBeendigung.Properties.Appearance.Options.UseBackColor = true;
            this.ddlGrundBeendigung.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlGrundBeendigung.Properties.Appearance.Options.UseFont = true;
            this.ddlGrundBeendigung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlGrundBeendigung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlGrundBeendigung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlGrundBeendigung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlGrundBeendigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.ddlGrundBeendigung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.ddlGrundBeendigung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlGrundBeendigung.Properties.NullText = "";
            this.ddlGrundBeendigung.Properties.ShowFooter = false;
            this.ddlGrundBeendigung.Properties.ShowHeader = false;
            this.ddlGrundBeendigung.Size = new System.Drawing.Size(318, 24);
            this.ddlGrundBeendigung.TabIndex = 18;
            // 
            // DlgWhFinanzplanBeenden
            // 
            this.ActiveSQLQuery = this.qryBgBewilligung;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(488, 361);
            this.Controls.Add(this.edtNeuerFPinnerhalbLE);
            this.Controls.Add(this.lblKopie);
            this.Controls.Add(this.lblGrundBeendigung);
            this.Controls.Add(this.ddlGrundBeendigung);
            this.Controls.Add(this.chkSofort);
            this.Controls.Add(this.lblEMail);
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
            this.Name = "DlgWhFinanzplanBeenden";
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
            ((System.ComponentModel.ISupportInitialize)(this.qryUserFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeuerFPinnerhalbLE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKopie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundBeendigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrundBeendigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrundBeendigung)).EndInit();
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

        private void btnYesNo_Click(object sender, System.EventArgs e)
        {
            if (this.chkSofort.Checked)
            {
                string question = string.Empty;
                switch(_typ)
                {
                    case BewilligungTyp.FinanzPlan:
                        question = LOCK_IMMEDIATELY_FINANZPLAN;
                        break;
                    case BewilligungTyp.Ueberbrueckungshilfe:
                        question = LOCK_IMMEDIATELY_UEBERBRUECKUNGSHILFE;
                        break;
                }

                if(!KissMsg.ShowQuestion(null, null, question, 500, 0))
                {
                    return;
                }
            }

            qryBgBewilligung = ShUtil.GetBgBewilligung_Neu();
            ActiveSQLQuery = qryBgBewilligung;

            qryBgBewilligung[DBO.BgBewilligung.UserID_An] = this.cboXUser.EditValue;
            qryBgBewilligung[DBO.BgBewilligung.Bemerkung] = this.edtBemerkung.EditValue;

            qryBgBewilligung[DBO.BgBewilligung.BgFinanzplanID] = _recordID;

            if (!this.chkSofort.Checked)
            {
                if (!DBUtil.IsEmpty(this.edtDatum.EditValue) && _datum < (DateTime)this.edtDatum.EditValue)
                {
                    KissMsg.ShowInfo("DlgBewilligung", "DatumNachGeplantDatum", "Das gewünschte Abschlussdatum liegt nach dem geplanten Abschlussdatum");
                    return;
                }
                else if (_mindatum != null && edtDatum.DateTime < (DateTime)_mindatum)
                {
                    KissMsg.ShowInfo("DlgBewilligung", "FruehestensBeendungFinanzplan", "Der Finanzplan kann frühestens auf den {0:d} beendet werden", 0, 0, _mindatum);
                    return;
                }

                qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 5;
                qryBgBewilligung[DBO.BgBewilligung.PerDatum] = this.edtDatum.EditValue;
            }
            else
            {
                qryBgBewilligung[DBO.BgBewilligung.BgBewilligungCode] = 6;
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
                if (_typ == BewilligungTyp.FinanzPlan)
                {
                    KissMsg.ShowInfo(this.Name, "FinanzplanBeendungNichtMoeglich", "Der Finanzplan kann nicht per sofort beendet werden, da im Moment noch mindestens ein grünes/rotes Monatsbudget in der Zukunft liegt");
                }
                else
                {
                    KissMsg.ShowInfo(this.Name, "UeberbrueckungshilfeBeendungNichtMoeglich", "Die Überbrückungshilfe kann nicht per sofort beendet werden, da im Moment noch mindestens ein grünes/rotes Monatsbudget in der Zukunft liegt");
                }
                e.Cancel = true;
                return;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        #endregion

        #region Public Methods

        public override bool OnSaveData()
        {
            // kein automatisches Post beim schliessen
            return true;
        }

        #endregion

        #region Private Methods

        private void SendMail()
        {
            if (!this.chkEMail.Checked) return;
            if (this.lblEMail.Text == "") return;

            try
            {
                ShUtil.SendMail(_typ, this.Aktion, lblEMail.Text, (int)cboXUser.EditValue, _recordID, chkSofort.Checked, edtBemerkung.Text);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("DlgWhFinanzplanBeenden", "FehlerEmailSenden", "Fehler beim senden der E-Mail", ex);
            }
        }

        private void cboXUserLoadQuery()
        {
            cboXUser.LoadQuery(qryUser, DBO.vwUser.UserID, DBO.vwUser.NameVorname);
        }

        #endregion

        #endregion

	}
}

