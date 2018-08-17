using System;
using System.Data;
using System.Net.Mail;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public enum BewilligungTyp
    {
        Finanzplan,
        Einzelzahlung
    }

    public enum BewilligungAktion
    {
        Anfrage,
        Antwort,
        Aufheben,
        Sperren,
        SerrungAufheben
    }

    public class DlgAyBewilligung : KiSS4.Gui.KissDialog
    {
        private KiSS4.Gui.KissLabel lblXUser;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissCheckEdit chkEMail;
        private KiSS4.Gui.KissLookUpEdit cboXUser;
        private KiSS4.Gui.KissCheckEdit chkSofort;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissButton cmdAbbrechen;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissButton cmdYes;
        private KiSS4.Gui.KissButton cmdNo;
        private KiSS4.Gui.KissLabel lblEMail;

        private SqlQuery qryUser = new SqlQuery();

        private bool userYes;

        private BewilligungTyp typ;
        private int RecordID;
        private BewilligungAktion aktion;
        private KiSS4.Gui.KissLookUpEdit editAbschlussgrund;
        private KiSS4.Gui.KissLabel lblAbschlussgrund;

        private const string LOCK_IMMEDIATELY = @"Achtung: Wenn Sie das Masterbudget per sofort sperren, dann:

 - können keine Zahlungen mehr durchgeführt werden
 - können keine neuen Monatsbudgets mehr erstellt werden

Sind Sie sicher, dass Sie dieses Masterbudget per sofort sperren wollen?";

        public DlgAyBewilligung()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent call
            this.qryUser.Fill(@"
                SELECT UserID, LastName + IsNull(', ' + FirstName, '') AS NameUser, EMail
                FROM dbo.XUser
                ORDER BY LastName, FirstName");

            this.cboXUser.Properties.DataSource = this.qryUser;
        }

        public DlgAyBewilligung(BewilligungTyp typ, int RecordID, BewilligungAktion aktion)
            : this()
        {
            this.typ = typ;
            this.RecordID = RecordID;
            this.aktion = aktion;

            //Die Spalte BgFinanzplanID könnte später durch BgBudgetId ersetzt werden.
            //Kein expliziter Name gewählt, damit das SQL vom SyntaxCheck erkennt wird.
            const string strUserAnfrage = @"
                SELECT TOP 1 UserID
                FROM dbo.BgBewilligung
                WHERE BgFinanzplanID = {0} AND BgBewilligungCode = {1}
                ORDER BY Datum DESC";

            switch (aktion)
            {
                case BewilligungAktion.Anfrage:
                    this.Text = "Bewilligung für {0} einholen";
                    this.lblTitel.Text = "Wen wollen Sie {1} {0} bewilligen lassen?";
                    this.lblXUser.Text = "Vorgesetzter";
                    this.cboXUser.EditValue = Session.User.ChiefID;

                    this.cmdYes.Text = "Bewilligung anfragen";
                    break;

                case BewilligungAktion.Antwort:
                    this.Text = "{0} bewilligen";
                    this.lblTitel.Text = "Wollen Sie {1} {0} bewilligen?";
                    this.lblBemerkung.Text = "Begründung";
                    this.lblDatum.Text = "Gültig ab";

                    this.lblDatum.Visible = true;
                    this.edtDatum.Visible = true;
                    this.cmdYes.Text = "Bewilligen";
                    this.cmdNo.Visible = true;

                    if (typ == BewilligungTyp.Finanzplan)
                    {
                        this.cboXUser.EditValue = DBUtil.ExecuteScalarSQL(
                            strUserAnfrage
                            , RecordID, 1);
                    }
                    else if (typ == BewilligungTyp.Einzelzahlung)
                    {
                        this.cboXUser.EditValue = DBUtil.ExecuteScalarSQL(
                            strUserAnfrage.Replace("BgFinanzplanID", "BgPositionID")
                            , RecordID, 1);
                    }
                    break;

                case BewilligungAktion.Aufheben:
                    this.Text = "Bestehende Bewilligung aufheben";
                    this.lblTitel.Text = "Bewilligung für {1} {0} aufheben?";

                    this.cmdYes.Text = "Bewilligung aufheben";
                    break;

                case BewilligungAktion.Sperren:
                    this.Text = "{0} beenden";
                    this.lblTitel.Text = "{0} beenden?";
                    this.lblDatum.Text = "Beenden am";

                    this.chkSofort.Visible = false;
                    this.lblDatum.Visible = true;
                    this.edtDatum.Visible = true;
                    this.cmdYes.Text = "beenden";
                    break;

                case BewilligungAktion.SerrungAufheben:
                    this.Text = "Sperrung aufheben";
                    this.lblTitel.Text = "Sperrung von {1} {0} aufheben?";

                    this.cmdYes.Text = "Sperrung aufheben";
                    break;
            }

            switch (typ)
            {
                case BewilligungTyp.Finanzplan:
                    this.Text = string.Format(this.Text, "Masterbudget");
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, "Masterbudget", "dieses");
                    break;

                case BewilligungTyp.Einzelzahlung:
                    this.Text = string.Format(this.Text, "Einzelzahlung");
                    this.lblTitel.Text = string.Format(this.lblTitel.Text, "Einzelzahlung", "diese");
                    this.lblDatum.Visible = false;
                    this.edtDatum.Visible = false;
                    break;
            }

            //Bemerkungsfeld / Abschlussgrund
            if (typ != BewilligungTyp.Finanzplan || aktion != BewilligungAktion.Sperren)
            {
                lblAbschlussgrund.Visible = false;
                editAbschlussgrund.Visible = false;
                lblBemerkung.Location = lblAbschlussgrund.Location;
                edtBemerkung.Height = edtBemerkung.Height + edtBemerkung.Top - editAbschlussgrund.Top;
                edtBemerkung.Top = editAbschlussgrund.Top;
            }
        }

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

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAyBewilligung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblXUser = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.cmdYes = new KiSS4.Gui.KissButton();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.chkEMail = new KiSS4.Gui.KissCheckEdit();
            this.cboXUser = new KiSS4.Gui.KissLookUpEdit();
            this.chkSofort = new KiSS4.Gui.KissCheckEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.cmdAbbrechen = new KiSS4.Gui.KissButton();
            this.cmdNo = new KiSS4.Gui.KissButton();
            this.editAbschlussgrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbschlussgrund = new KiSS4.Gui.KissLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.editAbschlussgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAbschlussgrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).BeginInit();
            this.SuspendLayout();
            // 
            // lblXUser
            // 
            this.lblXUser.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblXUser.Location = new System.Drawing.Point(8, 32);
            this.lblXUser.Name = "lblXUser";
            this.lblXUser.Size = new System.Drawing.Size(304, 16);
            this.lblXUser.TabIndex = 1;
            this.lblXUser.Text = "Zu benachrichtigender Sozialarbeiter";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Location = new System.Drawing.Point(8, 176);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(472, 56);
            this.edtBemerkung.TabIndex = 5;
            // 
            // cmdYes
            // 
            this.cmdYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.cmdYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdYes.Location = new System.Drawing.Point(8, 240);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(144, 24);
            this.cmdYes.TabIndex = 6;
            this.cmdYes.Text = "Bewilligen";
            this.cmdYes.UseVisualStyleBackColor = false;
            this.cmdYes.Click += new System.EventHandler(this.cmdYesNo_Click);
            // 
            // edtDatum
            // 
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(320, 96);
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
            this.edtDatum.TabIndex = 3;
            this.edtDatum.Visible = false;
            // 
            // chkEMail
            // 
            this.chkEMail.EditValue = true;
            this.chkEMail.Location = new System.Drawing.Point(320, 48);
            this.chkEMail.Name = "chkEMail";
            this.chkEMail.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkEMail.Properties.Appearance.Options.UseBackColor = true;
            this.chkEMail.Properties.Caption = "per e-Mail benachrichtigen";
            this.chkEMail.Size = new System.Drawing.Size(160, 19);
            this.chkEMail.TabIndex = 1;
            // 
            // cboXUser
            // 
            this.cboXUser.Location = new System.Drawing.Point(8, 48);
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameUser")});
            this.cboXUser.Properties.DisplayMember = "NameUser";
            this.cboXUser.Properties.NullText = "";
            this.cboXUser.Properties.ShowFooter = false;
            this.cboXUser.Properties.ShowHeader = false;
            this.cboXUser.Properties.ValueMember = "UserID";
            this.cboXUser.Size = new System.Drawing.Size(304, 24);
            this.cboXUser.TabIndex = 0;
            this.cboXUser.EditValueChanged += new System.EventHandler(this.cboXUser_EditValueChanged);
            // 
            // chkSofort
            // 
            this.chkSofort.EditValue = false;
            this.chkSofort.Location = new System.Drawing.Point(320, 72);
            this.chkSofort.Name = "chkSofort";
            this.chkSofort.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSofort.Properties.Appearance.Options.UseBackColor = true;
            this.chkSofort.Properties.Caption = "per sofort sperren!";
            this.chkSofort.Size = new System.Drawing.Size(160, 19);
            this.chkSofort.TabIndex = 2;
            this.chkSofort.Visible = false;
            this.chkSofort.EditValueChanged += new System.EventHandler(this.chkSofort_EditValueChanged);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 160);
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
            this.lblEMail.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblEMail.Location = new System.Drawing.Point(8, 80);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(464, 16);
            this.lblEMail.TabIndex = 4;
            this.lblEMail.Text = "";
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(192, 96);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDatum.Size = new System.Drawing.Size(120, 24);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Tag = "";
            this.lblDatum.Text = "Beenden am";
            this.lblDatum.Visible = false;
            // 
            // cmdAbbrechen
            // 
            this.cmdAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAbbrechen.Location = new System.Drawing.Point(360, 240);
            this.cmdAbbrechen.Name = "cmdAbbrechen";
            this.cmdAbbrechen.Size = new System.Drawing.Size(120, 24);
            this.cmdAbbrechen.TabIndex = 8;
            this.cmdAbbrechen.Text = "Abbrechen";
            this.cmdAbbrechen.UseVisualStyleBackColor = false;
            this.cmdAbbrechen.Click += new System.EventHandler(this.cmdAbbrechen_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cmdNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNo.Location = new System.Drawing.Point(160, 240);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(128, 24);
            this.cmdNo.TabIndex = 7;
            this.cmdNo.Text = "Zurückweisen";
            this.cmdNo.UseVisualStyleBackColor = false;
            this.cmdNo.Visible = false;
            this.cmdNo.Click += new System.EventHandler(this.cmdYesNo_Click);
            // 
            // editAbschlussgrund
            // 
            this.editAbschlussgrund.Location = new System.Drawing.Point(8, 133);
            this.editAbschlussgrund.LOVName = "AyGrundAbschluss";
            this.editAbschlussgrund.Name = "editAbschlussgrund";
            this.editAbschlussgrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAbschlussgrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAbschlussgrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAbschlussgrund.Properties.Appearance.Options.UseBackColor = true;
            this.editAbschlussgrund.Properties.Appearance.Options.UseBorderColor = true;
            this.editAbschlussgrund.Properties.Appearance.Options.UseFont = true;
            this.editAbschlussgrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editAbschlussgrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editAbschlussgrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editAbschlussgrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editAbschlussgrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editAbschlussgrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editAbschlussgrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editAbschlussgrund.Properties.DisplayMember = "Text";
            this.editAbschlussgrund.Properties.NullText = "";
            this.editAbschlussgrund.Properties.ShowFooter = false;
            this.editAbschlussgrund.Properties.ShowHeader = false;
            this.editAbschlussgrund.Properties.ValueMember = "Code";
            this.editAbschlussgrund.Size = new System.Drawing.Size(472, 24);
            this.editAbschlussgrund.TabIndex = 4;
            // 
            // lblAbschlussgrund
            // 
            this.lblAbschlussgrund.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAbschlussgrund.Location = new System.Drawing.Point(8, 115);
            this.lblAbschlussgrund.Name = "lblAbschlussgrund";
            this.lblAbschlussgrund.Size = new System.Drawing.Size(84, 16);
            this.lblAbschlussgrund.TabIndex = 14;
            this.lblAbschlussgrund.Text = "Abschlussgrund";
            // 
            // DlgAyBewilligung
            // 
            this.CancelButton = this.cmdAbbrechen;
            this.ClientSize = new System.Drawing.Size(488, 270);
            this.Controls.Add(this.lblAbschlussgrund);
            this.Controls.Add(this.editAbschlussgrund);
            this.Controls.Add(this.chkSofort);
            this.Controls.Add(this.lblEMail);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdAbbrechen);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.cboXUser);
            this.Controls.Add(this.chkEMail);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblXUser);
            this.Name = "DlgAyBewilligung";
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
            ((System.ComponentModel.ISupportInitialize)(this.editAbschlussgrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAbschlussgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public bool UserYes
        {
            get { return this.userYes; }
        }

        public object Datum
        {
            get
            {
                if (this.chkSofort.Checked)
                    return DateTime.Now.AddDays(-1);
                else
                    return this.edtDatum.EditValue;
            }
            set
            {
                this.edtDatum.EditValue = value;
            }
        }

        public object BgGrundAbschlussCode
        {
            get { return editAbschlussgrund.EditValue; }
        }

        private void cmdYesNo_Click(object sender, System.EventArgs e)
        {
            if (this.chkSofort.Checked && !KissMsg.ShowQuestion(null, null, LOCK_IMMEDIATELY, 550, 250))
                return;

            SqlQuery qryBgBewilligung = AyUtil.GetBgBewilligung_Neu();
            ActiveSQLQuery = qryBgBewilligung;

            qryBgBewilligung["UserID_An"] = this.cboXUser.EditValue;
            qryBgBewilligung["Bemerkung"] = this.edtBemerkung.EditValue;

            switch (this.typ)
            {
                case BewilligungTyp.Finanzplan:
                    qryBgBewilligung["BgFinanzplanID"] = this.RecordID;
                    break;

                case BewilligungTyp.Einzelzahlung:
                    qryBgBewilligung["BgPositionID"] = this.RecordID;
                    break;
            }

            switch (this.aktion)
            {
                case BewilligungAktion.Anfrage:
                    qryBgBewilligung["BgBewilligungCode"] = 1;
                    break;

                case BewilligungAktion.Antwort:
                    if (sender == this.cmdYes)
                    {
                        qryBgBewilligung["BgBewilligungCode"] = 2;
                        qryBgBewilligung["PerDatum"] = this.edtDatum.EditValue;
                    }
                    else
                    {
                        qryBgBewilligung["BgBewilligungCode"] = 3;
                    }
                    break;

                case BewilligungAktion.Aufheben:
                    qryBgBewilligung["BgBewilligungCode"] = 4;
                    break;

                case BewilligungAktion.Sperren:
                    if (!this.chkSofort.Checked)
                    {
                        qryBgBewilligung["BgBewilligungCode"] = 5;
                        qryBgBewilligung["PerDatum"] = this.edtDatum.EditValue;
                    }
                    else
                    {
                        qryBgBewilligung["BgBewilligungCode"] = 6;
                    }
                    break;

                case BewilligungAktion.SerrungAufheben:
                    qryBgBewilligung["BgBewilligungCode"] = 7;
                    break;
            }

            this.userYes = sender == this.cmdYes;
            this.userCancel = false;
            this.Close();
            this.SendMail();
        }

        public override bool OnSaveData()
        {
            // kein automatisches Post beim schliessen
            return true;
        }

        private void SendMail()
        {
            if (!this.chkEMail.Checked)
                return;
            if (this.lblEMail.Text == "")
                return;

            try
            {
                MailMessage msg = new MailMessage(Session.User.EMail, this.lblEMail.Text);
                msg.Subject = "";

                if (this.typ == BewilligungTyp.Finanzplan)
                {
                    switch (this.aktion)
                    {
                        case BewilligungAktion.Anfrage:
                            msg.Subject = string.Format(@"KiSS 4.0 - Masterbudget #{0}: Anfrage zur Bewilligung", this.RecordID);
                            msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthFpRequest", "") as string;
                            break;

                        case BewilligungAktion.Antwort:
                            msg.Subject = string.Format(@"KiSS 4.0 - Masterbudget #{0}: Antwort zur Bewilligung", this.RecordID);
                            if (this.userYes)
                                msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthFpAnswPos", "") as string;
                            else
                                msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthFpAnswNeg", "") as string;
                            break;

                        case BewilligungAktion.Aufheben:
                            msg.Subject = string.Format(@"KiSS 4.0 - Masterbudget #{0}: Aufhebung der Bewilligung", this.RecordID);
                            msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthFpRemove", "") as string;
                            break;

                        case BewilligungAktion.Sperren:
                            msg.Subject = string.Format(@"KiSS 4.0 - Masterbudget #{0}: Vorzeitige Beendigung des Masterbudgets", this.RecordID);
                            if (!this.chkSofort.Checked)
                                msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthFpRequest", "") as string;
                            else
                                msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthFpTerminate", "") as string;
                            break;

                        case BewilligungAktion.SerrungAufheben:
                            msg.Subject = string.Format(@"KiSS 4.0 - Masterbudget #{0}: Entsperrung des Masterbudgets", this.RecordID);
                            msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthFpUnlock", "") as string;
                            break;
                    }

                    msg.Body = msg.Body.Replace("{{FpKey}}", this.RecordID.ToString());
                }
                else if (this.typ == BewilligungTyp.Einzelzahlung)
                {
                    switch (this.aktion)
                    {
                        case BewilligungAktion.Anfrage:
                            msg.Subject = string.Format(@"KiSS 4.0 - Einzelzahlung #{0}: Anfrage zur Bewilligung", this.RecordID);
                            msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthEzRequest", "") as string;
                            break;

                        case BewilligungAktion.Antwort:
                            msg.Subject = string.Format(@"KiSS 4.0 - Einzelzahlung #{0}: Antwort zur Bewilligung", this.RecordID);

                            if (this.userYes)
                                msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthEzAnswPos", "") as string;
                            else
                                msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthEzAnswNeg", "") as string;
                            break;

                        case BewilligungAktion.Aufheben:
                            msg.Subject = string.Format(@"KiSS 4.0 - Einzelzahlung # {0}: Aufhebung der Bewilligung", this.RecordID);
                            msg.Body = DBUtil.GetConfigValue(@"System\Asyl\Mail\AuthEzRemove", "") as string;
                            break;
                    }

                    msg.Body = msg.Body.Replace("{{EzKey}}", RecordID.ToString());
                }

                // sender
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT *, 
                           Anrede    = CASE GenderCode 
                                         WHEN 1 THEN 'Herr' 
                                         ELSE 'Frau' 
                                       END,
                           Abteilung = dbo.fnOrgUnitOfUser(UserID, 0) 
                    FROM dbo.XUser
                    WHERE UserID = {0};", Session.User.UserID);

                msg.Body = msg.Body.Replace("{{SenderAccost}}", qry["Anrede"].ToString());
                msg.Body = msg.Body.Replace("{{SenderName}}", qry["LastName"].ToString());
                msg.Body = msg.Body.Replace("{{SenderFirstname}}", qry["FirstName"].ToString());
                msg.Body = msg.Body.Replace("{{SenderSite}}", qry["Abteilung"].ToString());
                msg.Body = msg.Body.Replace("{{SenderTel}}", qry["Phone"].ToString());
                msg.Body = msg.Body.Replace("{{SenderMail}}", qry["EMail"].ToString());

                //receiver
                qry.Fill(qry.SelectStatement, cboXUser.EditValue);

                msg.Body = msg.Body.Replace("{{ReceiverAccost}}", qry["Anrede"].ToString());
                msg.Body = msg.Body.Replace("{{ReceiverName}}", qry["LastName"].ToString());
                msg.Body = msg.Body.Replace("{{ReceiverFirstname}}", qry["FirstName"].ToString());
                msg.Body = msg.Body.Replace("{{ReceiverSite}}", qry["Abteilung"].ToString());
                msg.Body = msg.Body.Replace("{{ReceiverTel}}", qry["Phone"].ToString());
                msg.Body = msg.Body.Replace("{{ReceiverMail}}", qry["EMail"].ToString());

                //general
                msg.Body = msg.Body.Replace("{{Date}}", DateTime.Now.ToString("d.M.yyyy"));
                msg.Body = msg.Body.Replace("{{Time}}", DateTime.Now.ToString("HH:mm"));

                msg.Body = msg.Body.Replace("{{Remark}}", this.edtBemerkung.Text);


                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = (string)DBUtil.GetConfigValue(@"System\Mail\SMTP-Relay", "to.be.configured");
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("DlgAyBewilligung", "FehlerEmailSenden", "Fehler beim senden der E-Mail", ex);
            }

        }

        private void cmdAbbrechen_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #region Runtime Layout
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
            this.edtDatum.EditMode = this.chkSofort.Checked ? EditModeType.ReadOnly : EditModeType.Normal;
        }
        #endregion
    }
}

