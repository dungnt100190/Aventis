using System;
using System.Data;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public class CtlAyPeriode : KiSS4.Gui.KissUserControl
    {
        private int BgFinanzplanID;
        private KiSS4.Gui.KissButton btnAnfragen;
        private KiSS4.Gui.KissButton btnAntworten;
        private KiSS4.Gui.KissButton btnAufheben;
        private KiSS4.Gui.KissButton btnBeenden;
        private KiSS4.Gui.KissButton btnEntsperren;
        private KiSS4.Gui.KissButton btnStatusRefresh;
        private KiSS4.Gui.KissButton btnVerlauf;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KissLookUpEdit edtBgBewilligungStatusCode;
        private KiSS4.Gui.KissTextEdit edtBgFinanzplanID;
        private KiSS4.Gui.KissLookUpEdit edtBgGrundAbschlussCode;
        private KiSS4.Gui.KissLookUpEdit edtBgGrundEroeffnenCode;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissDateEdit edtGeplantBis;
        private KiSS4.Gui.KissDateEdit edtGeplantVon;
        private KiSS4.Gui.KissGroupBox fraStatus;
        private KiSS4.Gui.KissLabel lblBewilligung;
        private KissLabel lblBgBewilligungStatusCode;
        private KiSS4.Gui.KissLabel lblBgFinanzplanID;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblGeplantBis;
        private KiSS4.Gui.KissLabel lblGeplantVon;
        private KiSS4.Gui.KissLabel lblMasterbudget;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgFinanzplan;
        private KiSS4.DB.SqlQuery qryCheck;
        private KiSS4.Gui.KissMemoEdit txtStatusInfo;

        public CtlAyPeriode()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlAyPeriode(Image titelImage, int bgFinanzplanID)
            : this()
        {
            this.picTitel.Image = titelImage;
            this.BgFinanzplanID = bgFinanzplanID;

            this.qryBgFinanzplan.Fill(bgFinanzplanID);
            this.qryCheck.Fill(bgFinanzplanID, Session.User.UserID);
        }

        public override string GetContextName()
        {
            return "AyFinanzplan";
        }

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BGFINANZPLANID":
                    return this.qryBgFinanzplan["BgFinanzplanID"];
            }

            return base.GetContextValue(FieldName);
        }

        public override void OnRefreshData()
        {
            base.OnRefreshData();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAyPeriode));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryBgFinanzplan = new KiSS4.DB.SqlQuery();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.fraStatus = new KiSS4.Gui.KissGroupBox();
            this.lblBgBewilligungStatusCode = new KiSS4.Gui.KissLabel();
            this.edtBgBewilligungStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblMasterbudget = new KiSS4.Gui.KissLabel();
            this.lblBewilligung = new KiSS4.Gui.KissLabel();
            this.lblBgFinanzplanID = new KiSS4.Gui.KissLabel();
            this.edtBgFinanzplanID = new KiSS4.Gui.KissTextEdit();
            this.btnStatusRefresh = new KiSS4.Gui.KissButton();
            this.btnVerlauf = new KiSS4.Gui.KissButton();
            this.btnEntsperren = new KiSS4.Gui.KissButton();
            this.btnBeenden = new KiSS4.Gui.KissButton();
            this.btnAufheben = new KiSS4.Gui.KissButton();
            this.btnAntworten = new KiSS4.Gui.KissButton();
            this.btnAnfragen = new KiSS4.Gui.KissButton();
            this.txtStatusInfo = new KiSS4.Gui.KissMemoEdit();
            this.edtBgGrundEroeffnenCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgGrundAbschlussCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblGeplantVon = new KiSS4.Gui.KissLabel();
            this.lblGeplantBis = new KiSS4.Gui.KissLabel();
            this.edtGeplantBis = new KiSS4.Gui.KissDateEdit();
            this.edtGeplantVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.qryCheck = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.fraStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBewilligungStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMasterbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgFinanzplanID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgFinanzplanID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundEroeffnenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundEroeffnenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundAbschlussCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundAbschlussCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeplantVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeplantBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeplantBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeplantVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryCheck)).BeginInit();
            this.SuspendLayout();
            //
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgFinanzplan;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 143);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 96);
            this.edtBemerkung.TabIndex = 15;
            //
            // qryBgFinanzplan
            //
            this.qryBgFinanzplan.CanUpdate = true;
            this.qryBgFinanzplan.HostControl = this;
            this.qryBgFinanzplan.SelectStatement = resources.GetString("qryBgFinanzplan.SelectStatement");
            this.qryBgFinanzplan.TableName = "BgFinanzplan";
            this.qryBgFinanzplan.BeforePost += new System.EventHandler(this.qryBgFinanzplan_BeforePost);
            this.qryBgFinanzplan.PositionChanged += new System.EventHandler(this.qryBgFinanzplan_PositionChanged);
            //
            // lblTitel
            //
            this.lblTitel.DataMember = "Titel";
            this.lblTitel.DataSource = this.qryBgFinanzplan;
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            //
            // fraStatus
            //
            this.fraStatus.Controls.Add(this.lblBgBewilligungStatusCode);
            this.fraStatus.Controls.Add(this.edtBgBewilligungStatusCode);
            this.fraStatus.Controls.Add(this.lblMasterbudget);
            this.fraStatus.Controls.Add(this.lblBewilligung);
            this.fraStatus.Controls.Add(this.lblBgFinanzplanID);
            this.fraStatus.Controls.Add(this.edtBgFinanzplanID);
            this.fraStatus.Controls.Add(this.btnStatusRefresh);
            this.fraStatus.Controls.Add(this.btnVerlauf);
            this.fraStatus.Controls.Add(this.btnEntsperren);
            this.fraStatus.Controls.Add(this.btnBeenden);
            this.fraStatus.Controls.Add(this.btnAufheben);
            this.fraStatus.Controls.Add(this.btnAntworten);
            this.fraStatus.Controls.Add(this.btnAnfragen);
            this.fraStatus.Controls.Add(this.txtStatusInfo);
            this.fraStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraStatus.Location = new System.Drawing.Point(8, 245);
            this.fraStatus.Name = "fraStatus";
            this.fraStatus.Size = new System.Drawing.Size(664, 217);
            this.fraStatus.TabIndex = 16;
            this.fraStatus.TabStop = false;
            this.fraStatus.Text = "Statusinformationen";
            //
            // lblBgBewilligungStatusCode
            //
            this.lblBgBewilligungStatusCode.Location = new System.Drawing.Point(8, 136);
            this.lblBgBewilligungStatusCode.Name = "lblBgBewilligungStatusCode";
            this.lblBgBewilligungStatusCode.Size = new System.Drawing.Size(96, 24);
            this.lblBgBewilligungStatusCode.TabIndex = 4;
            this.lblBgBewilligungStatusCode.Text = "Status";
            this.lblBgBewilligungStatusCode.UseCompatibleTextRendering = true;
            //
            // edtBgBewilligungStatusCode
            //
            this.edtBgBewilligungStatusCode.DataMember = "BgBewilligungStatusCode";
            this.edtBgBewilligungStatusCode.DataSource = this.qryBgFinanzplan;
            this.edtBgBewilligungStatusCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgBewilligungStatusCode.Location = new System.Drawing.Point(110, 136);
            this.edtBgBewilligungStatusCode.LOVName = "BgBewilligungStatus";
            this.edtBgBewilligungStatusCode.Name = "edtBgBewilligungStatusCode";
            this.edtBgBewilligungStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgBewilligungStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgBewilligungStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgBewilligungStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgBewilligungStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgBewilligungStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgBewilligungStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgBewilligungStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgBewilligungStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgBewilligungStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgBewilligungStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBgBewilligungStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBgBewilligungStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgBewilligungStatusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtBgBewilligungStatusCode.Properties.DisplayMember = "Text";
            this.edtBgBewilligungStatusCode.Properties.DropDownRows = 1;
            this.edtBgBewilligungStatusCode.Properties.NullText = "";
            this.edtBgBewilligungStatusCode.Properties.ReadOnly = true;
            this.edtBgBewilligungStatusCode.Properties.ShowFooter = false;
            this.edtBgBewilligungStatusCode.Properties.ShowHeader = false;
            this.edtBgBewilligungStatusCode.Properties.ValueMember = "Code";
            this.edtBgBewilligungStatusCode.Size = new System.Drawing.Size(546, 24);
            this.edtBgBewilligungStatusCode.TabIndex = 5;
            //
            // lblMasterbudget
            //
            this.lblMasterbudget.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblMasterbudget.Location = new System.Drawing.Point(424, 170);
            this.lblMasterbudget.Name = "lblMasterbudget";
            this.lblMasterbudget.Size = new System.Drawing.Size(72, 16);
            this.lblMasterbudget.TabIndex = 10;
            this.lblMasterbudget.Text = "Masterbudget";
            //
            // lblBewilligung
            //
            this.lblBewilligung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBewilligung.Location = new System.Drawing.Point(112, 170);
            this.lblBewilligung.Name = "lblBewilligung";
            this.lblBewilligung.Size = new System.Drawing.Size(64, 16);
            this.lblBewilligung.TabIndex = 6;
            this.lblBewilligung.Text = "Bewilligung";
            //
            // lblBgFinanzplanID
            //
            this.lblBgFinanzplanID.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBgFinanzplanID.Location = new System.Drawing.Point(8, 24);
            this.lblBgFinanzplanID.Name = "lblBgFinanzplanID";
            this.lblBgFinanzplanID.Size = new System.Drawing.Size(80, 16);
            this.lblBgFinanzplanID.TabIndex = 0;
            this.lblBgFinanzplanID.Text = "Schlüssel";
            //
            // edtBgFinanzplanID
            //
            this.edtBgFinanzplanID.DataMember = "BgFinanzplanID";
            this.edtBgFinanzplanID.DataSource = this.qryBgFinanzplan;
            this.edtBgFinanzplanID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgFinanzplanID.Location = new System.Drawing.Point(8, 40);
            this.edtBgFinanzplanID.Name = "edtBgFinanzplanID";
            this.edtBgFinanzplanID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgFinanzplanID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgFinanzplanID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgFinanzplanID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgFinanzplanID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgFinanzplanID.Properties.Appearance.Options.UseFont = true;
            this.edtBgFinanzplanID.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBgFinanzplanID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.edtBgFinanzplanID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgFinanzplanID.Properties.ReadOnly = true;
            this.edtBgFinanzplanID.Size = new System.Drawing.Size(88, 24);
            this.edtBgFinanzplanID.TabIndex = 1;
            //
            // btnStatusRefresh
            //
            this.btnStatusRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusRefresh.Location = new System.Drawing.Point(8, 72);
            this.btnStatusRefresh.Name = "btnStatusRefresh";
            this.btnStatusRefresh.Size = new System.Drawing.Size(88, 24);
            this.btnStatusRefresh.TabIndex = 2;
            this.btnStatusRefresh.Text = "Aktualisieren";
            this.btnStatusRefresh.UseVisualStyleBackColor = false;
            this.btnStatusRefresh.Click += new System.EventHandler(this.cmdStatusRefresh_Click);
            //
            // btnVerlauf
            //
            this.btnVerlauf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerlauf.Location = new System.Drawing.Point(512, 186);
            this.btnVerlauf.Name = "btnVerlauf";
            this.btnVerlauf.Size = new System.Drawing.Size(88, 24);
            this.btnVerlauf.TabIndex = 13;
            this.btnVerlauf.Text = "Verlauf...";
            this.btnVerlauf.UseVisualStyleBackColor = false;
            this.btnVerlauf.Click += new System.EventHandler(this.cmdVerlauf_Click);
            //
            // btnEntsperren
            //
            this.btnEntsperren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntsperren.Location = new System.Drawing.Point(416, 186);
            this.btnEntsperren.Name = "btnEntsperren";
            this.btnEntsperren.Size = new System.Drawing.Size(88, 24);
            this.btnEntsperren.TabIndex = 12;
            this.btnEntsperren.Text = "Entsperren...";
            this.btnEntsperren.UseVisualStyleBackColor = false;
            this.btnEntsperren.Click += new System.EventHandler(this.cmdEntsperren_Click);
            //
            // btnBeenden
            //
            this.btnBeenden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeenden.Location = new System.Drawing.Point(320, 186);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(88, 24);
            this.btnBeenden.TabIndex = 11;
            this.btnBeenden.Text = "Beenden...";
            this.btnBeenden.UseVisualStyleBackColor = false;
            this.btnBeenden.Click += new System.EventHandler(this.cmdBeenden_Click);
            //
            // btnAufheben
            //
            this.btnAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAufheben.Location = new System.Drawing.Point(200, 186);
            this.btnAufheben.Name = "btnAufheben";
            this.btnAufheben.Size = new System.Drawing.Size(88, 24);
            this.btnAufheben.TabIndex = 9;
            this.btnAufheben.Text = "Aufheben...";
            this.btnAufheben.UseVisualStyleBackColor = false;
            this.btnAufheben.Click += new System.EventHandler(this.cmdAufheben_Click);
            //
            // btnAntworten
            //
            this.btnAntworten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAntworten.Location = new System.Drawing.Point(104, 186);
            this.btnAntworten.Name = "btnAntworten";
            this.btnAntworten.Size = new System.Drawing.Size(88, 24);
            this.btnAntworten.TabIndex = 8;
            this.btnAntworten.Text = "Erteilen...";
            this.btnAntworten.UseVisualStyleBackColor = false;
            this.btnAntworten.Click += new System.EventHandler(this.cmdAntworten_Click);
            //
            // btnAnfragen
            //
            this.btnAnfragen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnfragen.Location = new System.Drawing.Point(8, 186);
            this.btnAnfragen.Name = "btnAnfragen";
            this.btnAnfragen.Size = new System.Drawing.Size(88, 24);
            this.btnAnfragen.TabIndex = 7;
            this.btnAnfragen.Text = "Anfragen...";
            this.btnAnfragen.UseVisualStyleBackColor = false;
            this.btnAnfragen.Visible = false;
            this.btnAnfragen.Click += new System.EventHandler(this.cmdAnfragen_Click);
            //
            // txtStatusInfo
            //
            this.txtStatusInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtStatusInfo.Location = new System.Drawing.Point(112, 16);
            this.txtStatusInfo.Name = "txtStatusInfo";
            this.txtStatusInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtStatusInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtStatusInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtStatusInfo.Properties.Appearance.Options.UseBackColor = true;
            this.txtStatusInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.txtStatusInfo.Properties.Appearance.Options.UseFont = true;
            this.txtStatusInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtStatusInfo.Properties.ReadOnly = true;
            this.txtStatusInfo.Size = new System.Drawing.Size(544, 112);
            this.txtStatusInfo.TabIndex = 3;
            //
            // edtBgGrundEroeffnenCode
            //
            this.edtBgGrundEroeffnenCode.DataMember = "BgGrundEroeffnenCode";
            this.edtBgGrundEroeffnenCode.DataSource = this.qryBgFinanzplan;
            this.edtBgGrundEroeffnenCode.Location = new System.Drawing.Point(232, 56);
            this.edtBgGrundEroeffnenCode.LOVName = "AyGrundEroeffnung";
            this.edtBgGrundEroeffnenCode.Name = "edtBgGrundEroeffnenCode";
            this.edtBgGrundEroeffnenCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGrundEroeffnenCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGrundEroeffnenCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGrundEroeffnenCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGrundEroeffnenCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGrundEroeffnenCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgGrundEroeffnenCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGrundEroeffnenCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGrundEroeffnenCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGrundEroeffnenCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGrundEroeffnenCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBgGrundEroeffnenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBgGrundEroeffnenCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGrundEroeffnenCode.Properties.DisplayMember = "Text";
            this.edtBgGrundEroeffnenCode.Properties.NullText = "";
            this.edtBgGrundEroeffnenCode.Properties.ShowFooter = false;
            this.edtBgGrundEroeffnenCode.Properties.ShowHeader = false;
            this.edtBgGrundEroeffnenCode.Properties.ValueMember = "Code";
            this.edtBgGrundEroeffnenCode.Size = new System.Drawing.Size(440, 24);
            this.edtBgGrundEroeffnenCode.TabIndex = 5;
            this.edtBgGrundEroeffnenCode.Visible = false;
            //
            // edtBgGrundAbschlussCode
            //
            this.edtBgGrundAbschlussCode.DataMember = "BgGrundAbschlussCode";
            this.edtBgGrundAbschlussCode.DataSource = this.qryBgFinanzplan;
            this.edtBgGrundAbschlussCode.Location = new System.Drawing.Point(232, 104);
            this.edtBgGrundAbschlussCode.LOVName = "AyGrundAbschluss";
            this.edtBgGrundAbschlussCode.Name = "edtBgGrundAbschlussCode";
            this.edtBgGrundAbschlussCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGrundAbschlussCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGrundAbschlussCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGrundAbschlussCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGrundAbschlussCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGrundAbschlussCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgGrundAbschlussCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGrundAbschlussCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGrundAbschlussCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGrundAbschlussCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGrundAbschlussCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgGrundAbschlussCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgGrundAbschlussCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGrundAbschlussCode.Properties.DisplayMember = "Text";
            this.edtBgGrundAbschlussCode.Properties.NullText = "";
            this.edtBgGrundAbschlussCode.Properties.ShowFooter = false;
            this.edtBgGrundAbschlussCode.Properties.ShowHeader = false;
            this.edtBgGrundAbschlussCode.Properties.ValueMember = "Code";
            this.edtBgGrundAbschlussCode.Size = new System.Drawing.Size(440, 24);
            this.edtBgGrundAbschlussCode.TabIndex = 10;
            this.edtBgGrundAbschlussCode.Visible = false;
            //
            // lblDatumBis
            //
            this.lblDatumBis.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblDatumBis.Location = new System.Drawing.Point(120, 88);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(64, 16);
            this.lblDatumBis.TabIndex = 8;
            this.lblDatumBis.Text = "Gültig bis";
            //
            // lblDatumVon
            //
            this.lblDatumVon.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblDatumVon.Location = new System.Drawing.Point(120, 40);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(64, 16);
            this.lblDatumVon.TabIndex = 3;
            this.lblDatumVon.Text = "Gültig ab";
            //
            // lblGeplantVon
            //
            this.lblGeplantVon.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblGeplantVon.Location = new System.Drawing.Point(8, 40);
            this.lblGeplantVon.Name = "lblGeplantVon";
            this.lblGeplantVon.Size = new System.Drawing.Size(104, 16);
            this.lblGeplantVon.TabIndex = 1;
            this.lblGeplantVon.Text = "Geplant ab";
            //
            // lblGeplantBis
            //
            this.lblGeplantBis.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblGeplantBis.Location = new System.Drawing.Point(8, 88);
            this.lblGeplantBis.Name = "lblGeplantBis";
            this.lblGeplantBis.Size = new System.Drawing.Size(104, 16);
            this.lblGeplantBis.TabIndex = 6;
            this.lblGeplantBis.Text = "Geplant bis";
            //
            // edtGeplantBis
            //
            this.edtGeplantBis.DataMember = "GeplantBis";
            this.edtGeplantBis.DataSource = this.qryBgFinanzplan;
            this.edtGeplantBis.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtGeplantBis.EditValue = null;
            this.edtGeplantBis.Location = new System.Drawing.Point(8, 104);
            this.edtGeplantBis.Name = "edtGeplantBis";
            this.edtGeplantBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeplantBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtGeplantBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeplantBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeplantBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeplantBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeplantBis.Properties.Appearance.Options.UseFont = true;
            this.edtGeplantBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtGeplantBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeplantBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtGeplantBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeplantBis.Properties.ShowToday = false;
            this.edtGeplantBis.Size = new System.Drawing.Size(104, 24);
            this.edtGeplantBis.TabIndex = 7;
            //
            // edtGeplantVon
            //
            this.edtGeplantVon.DataMember = "GeplantVon";
            this.edtGeplantVon.DataSource = this.qryBgFinanzplan;
            this.edtGeplantVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtGeplantVon.EditValue = null;
            this.edtGeplantVon.Location = new System.Drawing.Point(8, 56);
            this.edtGeplantVon.Name = "edtGeplantVon";
            this.edtGeplantVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeplantVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtGeplantVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeplantVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeplantVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeplantVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeplantVon.Properties.Appearance.Options.UseFont = true;
            this.edtGeplantVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtGeplantVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeplantVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtGeplantVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeplantVon.Properties.ShowToday = false;
            this.edtGeplantVon.Size = new System.Drawing.Size(104, 24);
            this.edtGeplantVon.TabIndex = 2;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBgFinanzplan;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(120, 104);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ReadOnly = true;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(104, 24);
            this.edtDatumBis.TabIndex = 9;
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBgFinanzplan;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(120, 56);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ReadOnly = true;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(104, 24);
            this.edtDatumVon.TabIndex = 4;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            //
            // qryCheck
            //
            this.qryCheck.HostControl = this;
            this.qryCheck.SelectStatement = "EXECUTE dbo.spAyFinanzplan_Check {0}, {1}";
            this.qryCheck.AfterFill += new System.EventHandler(this.qryCheck_AfterFill);
            //
            // CtlAyPeriode
            //
            this.ActiveSQLQuery = this.qryBgFinanzplan;
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.edtBgGrundEroeffnenCode);
            this.Controls.Add(this.edtBgGrundAbschlussCode);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblGeplantVon);
            this.Controls.Add(this.lblGeplantBis);
            this.Controls.Add(this.edtGeplantBis);
            this.Controls.Add(this.edtGeplantVon);
            this.Controls.Add(this.fraStatus);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.edtBemerkung);
            this.Name = "CtlAyPeriode";
            this.Size = new System.Drawing.Size(680, 520);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.fraStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBewilligungStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMasterbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgFinanzplanID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgFinanzplanID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundEroeffnenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundEroeffnenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundAbschlussCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGrundAbschlussCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeplantVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeplantBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeplantBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeplantVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryCheck)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Runtime Layout

        private void qryBgFinanzplan_PositionChanged(object sender, System.EventArgs e)
        {
            switch ((BgBewilligungStatus)this.qryBgFinanzplan["BgBewilligungStatusCode"])
            {
                case BgBewilligungStatus.InVorbereitung:
                case BgBewilligungStatus.Angefragt:
                case BgBewilligungStatus.Abgelehnt:
                    this.edtGeplantVon.EditMode = EditModeType.Required;
                    this.edtGeplantBis.EditMode = EditModeType.Required;

                    this.edtBgGrundEroeffnenCode.EditMode = EditModeType.Normal;
                    this.edtBgGrundAbschlussCode.EditMode = EditModeType.Normal;

                    this.edtBemerkung.EditMode = EditModeType.Normal;

                    this.btnAnfragen.Enabled = true;
                    this.btnAntworten.Enabled = true;
                    this.btnAufheben.Enabled = false;

                    this.btnBeenden.Enabled = false;
                    this.btnEntsperren.Enabled = false;
                    break;

                case BgBewilligungStatus.Erteilt:
                    this.edtGeplantVon.EditMode = EditModeType.ReadOnly;
                    this.edtGeplantBis.EditMode = EditModeType.ReadOnly;

                    this.edtBgGrundEroeffnenCode.EditMode = EditModeType.ReadOnly;
                    this.edtBgGrundAbschlussCode.EditMode = EditModeType.ReadOnly;

                    this.edtBemerkung.EditMode = EditModeType.ReadOnly;

                    this.btnAnfragen.Enabled = false;
                    this.btnAntworten.Enabled = false;
                    this.btnAufheben.Enabled = true;

                    this.btnBeenden.Enabled = true;
                    this.btnEntsperren.Enabled = false;
                    break;

                case BgBewilligungStatus.Gesperrt:
                    this.edtGeplantVon.EditMode = EditModeType.ReadOnly;
                    this.edtGeplantBis.EditMode = EditModeType.ReadOnly;

                    this.edtBgGrundEroeffnenCode.EditMode = EditModeType.ReadOnly;
                    this.edtBgGrundAbschlussCode.EditMode = EditModeType.ReadOnly;

                    this.edtBemerkung.EditMode = EditModeType.ReadOnly;

                    this.btnAnfragen.Enabled = false;
                    this.btnAntworten.Enabled = false;
                    this.btnAufheben.Enabled = false;

                    this.btnBeenden.Enabled = false;
                    this.btnEntsperren.Enabled = true;
                    break;
            }
        }

        #endregion

        #region qryBgFinanzplan_Post

        private void qryBgFinanzplan_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtGeplantVon, lblGeplantVon.Text);
            if (edtGeplantBis.EditMode != EditModeType.ReadOnly)
            {
                DBUtil.CheckNotNullField(edtGeplantBis, lblGeplantBis.Text);
            }

            if (Utils.firstDayOfMonth((DateTime)qryBgFinanzplan["FallDatumVon"]) > ((DateTime)this.qryBgFinanzplan["GeplantVon"]).Date)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlAyPeriode", "BeginnAusserhalbFall", "Der Beginn liegt ausserhalb des Falles", KissMsgCode.MsgInfo), this.edtGeplantVon);

            if (!DBUtil.IsEmpty(qryBgFinanzplan["FallDatumBis"]) && Utils.lastDayOfMonth((DateTime)qryBgFinanzplan["FallDatumBis"]) < ((DateTime)this.qryBgFinanzplan["GeplantBis"]).Date)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlAyPeriode", "EndeAusserhalbFall", "Das Ende liegt ausserhalb des Falles", KissMsgCode.MsgInfo), this.edtGeplantBis);

            if (!DBUtil.IsEmpty(qryBgFinanzplan["GeplantBis"]) && ((DateTime)this.qryBgFinanzplan["GeplantVon"]).Date > ((DateTime)this.qryBgFinanzplan["GeplantBis"]).Date)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlAyPeriode", "BeginnNachEnde", "Der Beginn liegt nach dem Ende", KissMsgCode.MsgInfo));

            if ((int)this.qryBgFinanzplan["BgBewilligungStatusCode"] < (int)BgBewilligungStatus.Erteilt)
            {
                if (0 != (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT Count(*) FROM BgFinanzplan
                    WHERE FaLeistungID = {0} AND BgFinanzplanID <> IsNull({1}, 0)
                      AND dbo.fnDateOf({2})                     <= dbo.fnDateOf(COALESCE(DatumBis, GeplantBis, '99991231'))
                      AND dbo.fnDateOf(IsNull({3}, '99991231')) >= dbo.fnDateOf(COALESCE(DatumVon, GeplantVon))"
                    , this.qryBgFinanzplan["FaLeistungID"], this.qryBgFinanzplan["BgFinanzplanID"]
                    , this.qryBgFinanzplan["GeplantVon"], this.qryBgFinanzplan["GeplantBis"]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlAyPeriode", "UeberschneidungDatum", "Überschneidung der Datumsbereiche", KissMsgCode.MsgInfo), this.edtDatumVon);
                }
            }
        }

        #endregion

        #region Command Buttons

        private void cmdAnfragen_Click(object sender, System.EventArgs e)
        {
            this.qryBgFinanzplan.RowModified = true;
            if (this.qryBgFinanzplan.Post())
            {
                this.qryCheck.Refresh();

                if (this.qryCheck.DataTable.Select("Typ = 0").Length > 0)
                {
                    KissMsg.ShowInfo("CtlAyPeriode", "MasterbudgetUnvollstaendig", "Das Masterbudget ist unvollständig erfasst");
                }

                DlgAyBewilligung dlg = new DlgAyBewilligung(BewilligungTyp.Finanzplan, this.BgFinanzplanID, BewilligungAktion.Anfrage);
                dlg.ShowDialog(this);

                if (!dlg.UserCancel)
                {
                    Session.BeginTransaction();
                    try
                    {
                        if (!dlg.ActiveSQLQuery.Post())
                            throw new KissCancelException();

                        this.qryBgFinanzplan.Refresh();
                        this.qryBgFinanzplan["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Angefragt;
                        this.qryBgFinanzplan.Post();
                        this.qryBgFinanzplan.Refresh();

                        Session.Commit();
                    }
                    catch (Exception ex)
                    {
                        this.qryBgFinanzplan.DataSet.RejectChanges();
                        Session.Rollback();

                        if (ex is KissCancelException)
                            ((KissCancelException)ex).ShowMessage();
                        else
                            KissMsg.ShowError(ex.Message);
                    }
                    FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                }
            }
        }

        private void cmdAntworten_Click(object sender, System.EventArgs e)
        {
            this.qryBgFinanzplan.RowModified = true;
            if (this.qryBgFinanzplan.Post())
            {
                this.qryCheck.Refresh();

                if (this.qryCheck.DataTable.Select("Typ = 0").Length > 0)
                {
                    KissMsg.ShowInfo("CtlAyPeriode", "MasterbudgetUnvollstaendig", "Das Masterbudget ist unvollständig erfasst");
                    return;
                }
                if (this.qryCheck.Count > 0)
                {
                    KissMsg.ShowInfo("CtlAyPeriode", "MasterbudgetKeineKompetenz", "Sie haben nicht die Kompetenz dieses Masterbudget zu bewilligen");
                    return;
                }

                DlgAyBewilligung dlg = new DlgAyBewilligung(BewilligungTyp.Finanzplan, this.BgFinanzplanID, BewilligungAktion.Antwort);
                dlg.Datum = this.qryBgFinanzplan["GeplantVon"];
                dlg.ShowDialog(this);

                if (!dlg.UserCancel)
                {
                    Session.BeginTransaction();
                    try
                    {
                        if (!dlg.ActiveSQLQuery.Post())
                            throw new KissCancelException();

                        if (dlg.UserYes)
                        {
                            DBUtil.ExecSQLThrowingException("EXECUTE spAyFinanzplan_Bewilligen {0}, {1}"
                                , this.BgFinanzplanID
                                , dlg.Datum);

                            this.qryBgFinanzplan.Refresh();
                            this.qryBgFinanzplan["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Erteilt;

                            this.qryBgFinanzplan["DatumVon"] = dlg.Datum;
                            this.qryBgFinanzplan["DatumBis"] = this.qryBgFinanzplan["GeplantBis"];

                            DBUtil.ExecSQLThrowingException(@"
                                UPDATE dbo.BgBudget
                                  SET BgBewilligungStatusCode = {1}
                                WHERE BgFinanzplanID = {0} AND MasterBudget = 1"
                                , this.BgFinanzplanID, qryBgFinanzplan["BgBewilligungStatusCode"]);
                        }
                        else
                        {
                            this.qryBgFinanzplan.Refresh();
                            this.qryBgFinanzplan["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Abgelehnt;
                        }
                        this.qryBgFinanzplan.Post();
                        this.qryBgFinanzplan.Refresh();

                        Session.Commit();
                    }
                    catch (Exception ex)
                    {
                        this.qryBgFinanzplan.DataSet.RejectChanges();
                        Session.Rollback();

                        if (ex is KissCancelException)
                            ((KissCancelException)ex).ShowMessage();
                        else
                            KissMsg.ShowError(ex.Message);
                    }
                    FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                }
            }
        }

        private void cmdAufheben_Click(object sender, System.EventArgs e)
        {
            if (this.qryBgFinanzplan.Post())
            {
                DlgAyBewilligung dlg = new DlgAyBewilligung(BewilligungTyp.Finanzplan, this.BgFinanzplanID, BewilligungAktion.Aufheben);
                dlg.ShowDialog(this);

                if (!dlg.UserCancel)
                {
                    Session.BeginTransaction();
                    try
                    {
                        if (!dlg.ActiveSQLQuery.Post())
                            throw new KissCancelException();

                        DBUtil.ExecSQL(@"
                            UPDATE dbo.BgBudget
                              SET BgBewilligungStatusCode = 1
                            WHERE BgFinanzplanID = {0} AND MasterBudget = 1"
                            , this.BgFinanzplanID);

                        DBUtil.ExecSQL(@"
                            UPDATE dbo.BgBudget
                              SET BgBewilligungStatusCode = 9
                            WHERE BgFinanzplanID = {0} AND MasterBudget = 0 AND BgBewilligungStatusCode = 5"
                            , this.BgFinanzplanID);

                        this.qryBgFinanzplan.Refresh();
                        this.qryBgFinanzplan["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.InVorbereitung;
                        this.qryBgFinanzplan["DatumVon"] = null;
                        this.qryBgFinanzplan["DatumBis"] = null;
                        this.qryBgFinanzplan.Post();
                        this.qryBgFinanzplan.Refresh();

                        Session.Commit();
                    }
                    catch (Exception ex)
                    {
                        this.qryBgFinanzplan.DataSet.RejectChanges();
                        Session.Rollback();

                        if (ex is KissCancelException)
                            ((KissCancelException)ex).ShowMessage();
                        else
                            KissMsg.ShowError(ex.Message);
                    }
                    FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                }
            }
        }

        private void cmdBeenden_Click(object sender, System.EventArgs e)
        {
            if (this.qryBgFinanzplan.Post())
            {
                DlgAyBewilligung dlg = new DlgAyBewilligung(BewilligungTyp.Finanzplan, this.BgFinanzplanID, BewilligungAktion.Sperren);
                dlg.Datum = this.qryBgFinanzplan["DatumBis"];
                dlg.ShowDialog(this);

                if (!dlg.UserCancel)
                {
                    Session.BeginTransaction();
                    try
                    {
                        if (!dlg.ActiveSQLQuery.Post())
                            throw new KissCancelException();

                        DBUtil.ExecSQL(@"
                            DECLARE @BgBudgetID  int

                            DECLARE cBudget CURSOR FOR
                              SELECT BgBudgetID
                              FROM dbo.BgBudget   BBG
                              WHERE BBG.BgFinanzplanID = {0} AND BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode < 5
                                AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) > {1}

                            OPEN cBudget
                            WHILE 1 = 1 BEGIN
                              FETCH NEXT FROM cBudget INTO @BgBudgetID
                              IF @@FETCH_STATUS != 0 BREAK

                              EXECUTE dbo.spAyBudget_Delete @BgBudgetID
                              DELETE FROM dbo.BgBudget WHERE BgBudgetID = @BgBudgetID
                            END
                            CLOSE cBudget
                            DEALLOCATE cBudget"
                            , this.BgFinanzplanID
                            , dlg.Datum);
                        this.qryBgFinanzplan.Refresh();

                        this.qryBgFinanzplan["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Gesperrt;
                        this.qryBgFinanzplan["DatumBis"] = dlg.Datum;
                        this.qryBgFinanzplan["BgGrundAbschlussCode"] = dlg.BgGrundAbschlussCode;

                        this.qryBgFinanzplan.Post();
                        this.qryBgFinanzplan.Refresh();

                        Session.Commit();
                    }
                    catch (Exception ex)
                    {
                        this.qryBgFinanzplan.DataSet.RejectChanges();
                        Session.Rollback();

                        if (ex is KissCancelException)
                            ((KissCancelException)ex).ShowMessage();
                        else
                            KissMsg.ShowError(ex.Message);
                    }
                    FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                }
            }
        }

        private void cmdEntsperren_Click(object sender, System.EventArgs e)
        {
            if (this.qryBgFinanzplan.Post())
            {
                DlgAyBewilligung dlg = new DlgAyBewilligung(BewilligungTyp.Finanzplan, this.BgFinanzplanID, BewilligungAktion.SerrungAufheben);
                dlg.ShowDialog(this);

                if (!dlg.UserCancel)
                {
                    Session.BeginTransaction();
                    try
                    {
                        if (!dlg.ActiveSQLQuery.Post())
                            throw new KissCancelException();

                        this.qryBgFinanzplan.Refresh();

                        this.qryBgFinanzplan["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.InVorbereitung;
                        this.qryBgFinanzplan["BgGrundAbschlussCode"] = DBNull.Value;
                        this.qryBgFinanzplan["DatumBis"] = this.qryBgFinanzplan["GeplantBis"];

                        this.qryBgFinanzplan.Post();
                        this.qryBgFinanzplan.Refresh();

                        Session.Commit();
                    }
                    catch (Exception ex)
                    {
                        this.qryBgFinanzplan.DataSet.RejectChanges();
                        Session.Rollback();

                        if (ex is KissCancelException)
                            ((KissCancelException)ex).ShowMessage();
                        else
                            KissMsg.ShowError(ex.Message);
                    }
                    FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                }
            }
        }

        #endregion

        private void cmdStatusRefresh_Click(object sender, System.EventArgs e)
        {
            this.qryCheck.Refresh();
        }

        private void cmdVerlauf_Click(object sender, System.EventArgs e)
        {
            DlgAyVerlaufFinanzplan dlg = new DlgAyVerlaufFinanzplan(BgFinanzplanID);
            dlg.ShowDialog(this);
        }

        private void qryCheck_AfterFill(object sender, System.EventArgs e)
        {
            if (this.qryCheck.Count == 0 || this.qryCheck.DataTable.Rows[0]["Typ"].Equals(1))
            {
                this.txtStatusInfo.Text = "Daten sind vollständig erfasst";
            }
            else
            {
                this.txtStatusInfo.Text = "Die folgenden Daten müssen noch ergänzt werden:";
            }

            foreach (DataRow row in this.qryCheck.DataTable.Rows)
            {
                this.txtStatusInfo.Text += "\r\n - " + (string)row[1];
            }
        }
    }
}