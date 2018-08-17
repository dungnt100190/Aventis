using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe
{
    public class CtlWhFinanzplan : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_FPL_FALL_DATUM_BIS = "FallDatumBis";
        private const string QRY_FPL_FALL_DATUM_VON = "FallDatumVon";
        private const string QRY_FPL_FINANZPLAN_BIS = "FinanzplanBis";
        private const string QRY_FPL_FINANZPLAN_VON = "FinanzplanVon";

        #endregion

        #region Private Fields

        private int _bgBudgetID;
        private int _bgFinanzplanID;
        private LOV.WhHilfeTypCode _whHilfeTypCode;
        private BewilligungTyp _bewilligungTyp;
        private bool _updateFinanzplan = false;
        private KiSS4.Gui.KissButton btnBeenden;
        private KissButton btnBewilligung;
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
        private KissLookUpEdit edtWhGrundbedarfTypCode;
        private KiSS4.Gui.KissLookUpEdit edtWhHilfeTypCode;
        private KiSS4.Gui.KissGroupBox fraStatus;
        private KissLabel lblAbschlussGrund;
        private KiSS4.Gui.KissLabel lblBewilligen;
        private KissLabel lblBgBewilligungStatusCode;
        private KiSS4.Gui.KissLabel lblBgFinanzplanID;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KissLabel lblEroeffnungGrund;
        private KiSS4.Gui.KissLabel lblFinanzplan;
        private KiSS4.Gui.KissLabel lblGeplantBis;
        private KiSS4.Gui.KissLabel lblGeplantVon;
        private KiSS4.Gui.KissLabel lblTitel;
        private KissLabel lblWhGrundbedarfTypCode;
        private KiSS4.Gui.KissLabel lblWhHilfeTypCode;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgFinanzplan;
        private KiSS4.DB.SqlQuery qryCheck;
        private KiSS4.Gui.KissMemoEdit txtStatusInfo;

        #endregion

        #endregion

        #region Constructors

        public CtlWhFinanzplan()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlWhFinanzplan(Image titelImage, string titelText, int bgFinanzplanID, int bgBudgetID)
            : this()
        {
            this.picTitel.Image = titelImage;
            _bgFinanzplanID = bgFinanzplanID;
            _bgBudgetID = bgBudgetID;

            SetupDataMembers();

            this.qryBgFinanzplan.Fill(_bgFinanzplanID);

            _whHilfeTypCode = (LOV.WhHilfeTypCode)Utils.ConvertToInt(qryBgFinanzplan[DBO.BgFinanzplan.WhHilfeTypCode]);
            _bewilligungTyp = BewilligungTyp.FinanzPlan;
            if (_whHilfeTypCode == LOV.WhHilfeTypCode.Ueberbrueckungshilfe)
            {
                _bewilligungTyp = BewilligungTyp.Ueberbrueckungshilfe;
            }

            this.lblTitel.Text = string.Format(this.lblTitel.Text, qryBgFinanzplan[QRY_FPL_FINANZPLAN_VON], qryBgFinanzplan[QRY_FPL_FINANZPLAN_BIS], titelText);

            this.qryCheck.Fill(qryCheck.SelectStatement, _bgFinanzplanID, Session.User.UserID);
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhFinanzplan));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryBgFinanzplan = new KiSS4.DB.SqlQuery(this.components);
            this.edtWhHilfeTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblWhHilfeTypCode = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.fraStatus = new KiSS4.Gui.KissGroupBox();
            this.btnBewilligung = new KiSS4.Gui.KissButton();
            this.lblBgBewilligungStatusCode = new KiSS4.Gui.KissLabel();
            this.edtBgBewilligungStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblFinanzplan = new KiSS4.Gui.KissLabel();
            this.lblBewilligen = new KiSS4.Gui.KissLabel();
            this.lblBgFinanzplanID = new KiSS4.Gui.KissLabel();
            this.edtBgFinanzplanID = new KiSS4.Gui.KissTextEdit();
            this.btnStatusRefresh = new KiSS4.Gui.KissButton();
            this.btnVerlauf = new KiSS4.Gui.KissButton();
            this.btnBeenden = new KiSS4.Gui.KissButton();
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
            this.qryCheck = new KiSS4.DB.SqlQuery(this.components);
            this.edtWhGrundbedarfTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblWhGrundbedarfTypCode = new KiSS4.Gui.KissLabel();
            this.lblAbschlussGrund = new KiSS4.Gui.KissLabel();
            this.lblEroeffnungGrund = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhHilfeTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhHilfeTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhHilfeTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.fraStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBewilligungStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligen)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.edtWhGrundbedarfTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhGrundbedarfTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhGrundbedarfTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungGrund)).BeginInit();
            this.SuspendLayout();
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataSource = this.qryBgFinanzplan;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 184);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 96);
            this.edtBemerkung.TabIndex = 17;
            // 
            // qryBgFinanzplan
            // 
            this.qryBgFinanzplan.CanUpdate = true;
            this.qryBgFinanzplan.HostControl = this;
            this.qryBgFinanzplan.SelectStatement = resources.GetString("qryBgFinanzplan.SelectStatement");
            this.qryBgFinanzplan.TableName = "BgFinanzplan";
            this.qryBgFinanzplan.BeforePost += new System.EventHandler(this.qryBgFinanzplan_BeforePost);
            this.qryBgFinanzplan.PositionChanged += new System.EventHandler(this.qryBgFinanzplan_PositionChanged);
            this.qryBgFinanzplan.AfterPost += new System.EventHandler(this.qryBgFinanzplan_AfterPost);
            this.qryBgFinanzplan.PostError += new System.UnhandledExceptionEventHandler(this.qryBgFinanzplan_PostError);
            // 
            // edtWhHilfeTypCode
            // 
            this.edtWhHilfeTypCode.DataSource = this.qryBgFinanzplan;
            this.edtWhHilfeTypCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWhHilfeTypCode.Location = new System.Drawing.Point(8, 152);
            this.edtWhHilfeTypCode.LOVName = "WhHilfeTyp";
            this.edtWhHilfeTypCode.Name = "edtWhHilfeTypCode";
            this.edtWhHilfeTypCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWhHilfeTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhHilfeTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhHilfeTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhHilfeTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhHilfeTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtWhHilfeTypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWhHilfeTypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhHilfeTypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWhHilfeTypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWhHilfeTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtWhHilfeTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtWhHilfeTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhHilfeTypCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtWhHilfeTypCode.Properties.DisplayMember = "Text";
            this.edtWhHilfeTypCode.Properties.NullText = "";
            this.edtWhHilfeTypCode.Properties.ReadOnly = true;
            this.edtWhHilfeTypCode.Properties.ShowFooter = false;
            this.edtWhHilfeTypCode.Properties.ShowHeader = false;
            this.edtWhHilfeTypCode.Properties.ValueMember = "Code";
            this.edtWhHilfeTypCode.Size = new System.Drawing.Size(216, 24);
            this.edtWhHilfeTypCode.TabIndex = 14;
            // 
            // lblWhHilfeTypCode
            // 
            this.lblWhHilfeTypCode.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblWhHilfeTypCode.Location = new System.Drawing.Point(8, 136);
            this.lblWhHilfeTypCode.Name = "lblWhHilfeTypCode";
            this.lblWhHilfeTypCode.Size = new System.Drawing.Size(80, 16);
            this.lblWhHilfeTypCode.TabIndex = 13;
            this.lblWhHilfeTypCode.Text = "Typ";
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Finanzplan vom {0:d} bis {1:d}";
            // 
            // fraStatus
            // 
            this.fraStatus.Controls.Add(this.btnBewilligung);
            this.fraStatus.Controls.Add(this.lblBgBewilligungStatusCode);
            this.fraStatus.Controls.Add(this.edtBgBewilligungStatusCode);
            this.fraStatus.Controls.Add(this.lblFinanzplan);
            this.fraStatus.Controls.Add(this.lblBewilligen);
            this.fraStatus.Controls.Add(this.lblBgFinanzplanID);
            this.fraStatus.Controls.Add(this.edtBgFinanzplanID);
            this.fraStatus.Controls.Add(this.btnStatusRefresh);
            this.fraStatus.Controls.Add(this.btnVerlauf);
            this.fraStatus.Controls.Add(this.btnBeenden);
            this.fraStatus.Controls.Add(this.txtStatusInfo);
            this.fraStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraStatus.Location = new System.Drawing.Point(8, 288);
            this.fraStatus.Name = "fraStatus";
            this.fraStatus.Size = new System.Drawing.Size(664, 217);
            this.fraStatus.TabIndex = 18;
            this.fraStatus.TabStop = false;
            this.fraStatus.Text = "Statusinformationen";
            // 
            // btnBewilligung
            // 
            this.btnBewilligung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBewilligung.Image = ((System.Drawing.Image)(resources.GetObject("btnBewilligung.Image")));
            this.btnBewilligung.Location = new System.Drawing.Point(110, 186);
            this.btnBewilligung.Name = "btnBewilligung";
            this.btnBewilligung.Size = new System.Drawing.Size(24, 24);
            this.btnBewilligung.TabIndex = 14;
            this.btnBewilligung.UseCompatibleTextRendering = true;
            this.btnBewilligung.UseVisualStyleBackColor = false;
            this.btnBewilligung.Click += new System.EventHandler(this.btnBewilligung_Click);
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
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBgBewilligungStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
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
            // lblFinanzplan
            // 
            this.lblFinanzplan.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblFinanzplan.Location = new System.Drawing.Point(348, 189);
            this.lblFinanzplan.Name = "lblFinanzplan";
            this.lblFinanzplan.Size = new System.Drawing.Size(64, 16);
            this.lblFinanzplan.TabIndex = 10;
            this.lblFinanzplan.Text = "Finanzplan";
            // 
            // lblBewilligen
            // 
            this.lblBewilligen.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBewilligen.Location = new System.Drawing.Point(8, 189);
            this.lblBewilligen.Name = "lblBewilligen";
            this.lblBewilligen.Size = new System.Drawing.Size(64, 16);
            this.lblBewilligen.TabIndex = 6;
            this.lblBewilligen.Text = "Bewilligung";
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
            this.btnStatusRefresh.Click += new System.EventHandler(this.btnStatusRefresh_Click);
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
            this.btnVerlauf.Click += new System.EventHandler(this.btnVerlauf_Click);
            // 
            // btnBeenden
            // 
            this.btnBeenden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeenden.Location = new System.Drawing.Point(418, 186);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(88, 24);
            this.btnBeenden.TabIndex = 11;
            this.btnBeenden.Text = "Beenden...";
            this.btnBeenden.UseVisualStyleBackColor = false;
            this.btnBeenden.Click += new System.EventHandler(this.btnBeenden_Click);
            // 
            // txtStatusInfo
            // 
            this.txtStatusInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtStatusInfo.Location = new System.Drawing.Point(110, 16);
            this.txtStatusInfo.Name = "txtStatusInfo";
            this.txtStatusInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtStatusInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtStatusInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtStatusInfo.Properties.Appearance.Options.UseBackColor = true;
            this.txtStatusInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.txtStatusInfo.Properties.Appearance.Options.UseFont = true;
            this.txtStatusInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtStatusInfo.Properties.ReadOnly = true;
            this.txtStatusInfo.Size = new System.Drawing.Size(546, 112);
            this.txtStatusInfo.TabIndex = 3;
            // 
            // edtBgGrundEroeffnenCode
            // 
            this.edtBgGrundEroeffnenCode.AllowDrop = true;
            this.edtBgGrundEroeffnenCode.DataSource = this.qryBgFinanzplan;
            this.edtBgGrundEroeffnenCode.Location = new System.Drawing.Point(232, 56);
            this.edtBgGrundEroeffnenCode.LOVName = "BgFPGrundEroeffnung";
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
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgGrundEroeffnenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgGrundEroeffnenCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGrundEroeffnenCode.Properties.DisplayMember = "Text";
            this.edtBgGrundEroeffnenCode.Properties.NullText = "";
            this.edtBgGrundEroeffnenCode.Properties.ShowFooter = false;
            this.edtBgGrundEroeffnenCode.Properties.ShowHeader = false;
            this.edtBgGrundEroeffnenCode.Properties.ValueMember = "Code";
            this.edtBgGrundEroeffnenCode.Size = new System.Drawing.Size(440, 24);
            this.edtBgGrundEroeffnenCode.TabIndex = 6;
            // 
            // edtBgGrundAbschlussCode
            // 
            this.edtBgGrundAbschlussCode.DataSource = this.qryBgFinanzplan;
            this.edtBgGrundAbschlussCode.Location = new System.Drawing.Point(232, 104);
            this.edtBgGrundAbschlussCode.LOVName = "BgFPGrundAbschluss";
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBgGrundAbschlussCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBgGrundAbschlussCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGrundAbschlussCode.Properties.DisplayMember = "Text";
            this.edtBgGrundAbschlussCode.Properties.NullText = "";
            this.edtBgGrundAbschlussCode.Properties.ShowFooter = false;
            this.edtBgGrundAbschlussCode.Properties.ShowHeader = false;
            this.edtBgGrundAbschlussCode.Properties.ValueMember = "Code";
            this.edtBgGrundAbschlussCode.Size = new System.Drawing.Size(440, 24);
            this.edtBgGrundAbschlussCode.TabIndex = 12;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblDatumBis.Location = new System.Drawing.Point(120, 88);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(64, 16);
            this.lblDatumBis.TabIndex = 9;
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
            this.lblGeplantBis.TabIndex = 7;
            this.lblGeplantBis.Text = "Geplant bis";
            // 
            // edtGeplantBis
            // 
            this.edtGeplantBis.DataSource = this.qryBgFinanzplan;
            this.edtGeplantBis.EditValue = "";
            this.edtGeplantBis.Location = new System.Drawing.Point(8, 104);
            this.edtGeplantBis.Name = "edtGeplantBis";
            this.edtGeplantBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeplantBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeplantBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeplantBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeplantBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeplantBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeplantBis.Properties.Appearance.Options.UseFont = true;
            this.edtGeplantBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtGeplantBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeplantBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtGeplantBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeplantBis.Properties.ShowToday = false;
            this.edtGeplantBis.Size = new System.Drawing.Size(104, 24);
            this.edtGeplantBis.TabIndex = 8;
            // 
            // edtGeplantVon
            // 
            this.edtGeplantVon.DataSource = this.qryBgFinanzplan;
            this.edtGeplantVon.EditValue = "";
            this.edtGeplantVon.Location = new System.Drawing.Point(8, 56);
            this.edtGeplantVon.Name = "edtGeplantVon";
            this.edtGeplantVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeplantVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeplantVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeplantVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeplantVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeplantVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeplantVon.Properties.Appearance.Options.UseFont = true;
            this.edtGeplantVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtGeplantVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeplantVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtGeplantVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeplantVon.Properties.ShowToday = false;
            this.edtGeplantVon.Size = new System.Drawing.Size(104, 24);
            this.edtGeplantVon.TabIndex = 2;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataSource = this.qryBgFinanzplan;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumBis.EditValue = "";
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ReadOnly = true;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(104, 24);
            this.edtDatumBis.TabIndex = 10;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataSource = this.qryBgFinanzplan;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumVon.EditValue = "";
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
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
            this.qryCheck.SelectStatement = "EXECUTE spWhFinanzplan_Check {0}, {1}";
            this.qryCheck.AfterFill += new System.EventHandler(this.qryCheck_AfterFill);
            // 
            // edtWhGrundbedarfTypCode
            // 
            this.edtWhGrundbedarfTypCode.AllowNull = false;
            this.edtWhGrundbedarfTypCode.DataSource = this.qryBgFinanzplan;
            this.edtWhGrundbedarfTypCode.Location = new System.Drawing.Point(232, 152);
            this.edtWhGrundbedarfTypCode.LOVName = "WhGrundbedarfTyp";
            this.edtWhGrundbedarfTypCode.Name = "edtWhGrundbedarfTypCode";
            this.edtWhGrundbedarfTypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhGrundbedarfTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhGrundbedarfTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhGrundbedarfTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhGrundbedarfTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhGrundbedarfTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtWhGrundbedarfTypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWhGrundbedarfTypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhGrundbedarfTypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWhGrundbedarfTypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWhGrundbedarfTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtWhGrundbedarfTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtWhGrundbedarfTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhGrundbedarfTypCode.Properties.NullText = "";
            this.edtWhGrundbedarfTypCode.Properties.ShowFooter = false;
            this.edtWhGrundbedarfTypCode.Properties.ShowHeader = false;
            this.edtWhGrundbedarfTypCode.Size = new System.Drawing.Size(440, 24);
            this.edtWhGrundbedarfTypCode.TabIndex = 16;
            // 
            // lblWhGrundbedarfTypCode
            // 
            this.lblWhGrundbedarfTypCode.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblWhGrundbedarfTypCode.Location = new System.Drawing.Point(230, 136);
            this.lblWhGrundbedarfTypCode.Name = "lblWhGrundbedarfTypCode";
            this.lblWhGrundbedarfTypCode.Size = new System.Drawing.Size(143, 16);
            this.lblWhGrundbedarfTypCode.TabIndex = 15;
            this.lblWhGrundbedarfTypCode.Text = "Berechnungsgrundlage";
            this.lblWhGrundbedarfTypCode.UseCompatibleTextRendering = true;
            // 
            // lblAbschlussGrund
            // 
            this.lblAbschlussGrund.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAbschlussGrund.Location = new System.Drawing.Point(232, 88);
            this.lblAbschlussGrund.Name = "lblAbschlussGrund";
            this.lblAbschlussGrund.Size = new System.Drawing.Size(78, 16);
            this.lblAbschlussGrund.TabIndex = 11;
            this.lblAbschlussGrund.Text = "Grund";
            this.lblAbschlussGrund.UseCompatibleTextRendering = true;
            // 
            // lblEroeffnungGrund
            // 
            this.lblEroeffnungGrund.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblEroeffnungGrund.Location = new System.Drawing.Point(232, 40);
            this.lblEroeffnungGrund.Name = "lblEroeffnungGrund";
            this.lblEroeffnungGrund.Size = new System.Drawing.Size(78, 16);
            this.lblEroeffnungGrund.TabIndex = 5;
            this.lblEroeffnungGrund.Text = "Grund";
            this.lblEroeffnungGrund.UseCompatibleTextRendering = true;
            // 
            // CtlWhFinanzplan
            // 
            this.ActiveSQLQuery = this.qryBgFinanzplan;
            this.Controls.Add(this.lblEroeffnungGrund);
            this.Controls.Add(this.lblAbschlussGrund);
            this.Controls.Add(this.edtWhGrundbedarfTypCode);
            this.Controls.Add(this.lblWhGrundbedarfTypCode);
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
            this.Controls.Add(this.lblWhHilfeTypCode);
            this.Controls.Add(this.edtWhHilfeTypCode);
            this.Controls.Add(this.edtBemerkung);
            this.Name = "CtlWhFinanzplan";
            this.Size = new System.Drawing.Size(680, 520);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhHilfeTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhHilfeTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhHilfeTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.fraStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBewilligungStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligen)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.edtWhGrundbedarfTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhGrundbedarfTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhGrundbedarfTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungGrund)).EndInit();
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

        #region EventHandlers

        private void btnBeenden_Click(object sender, System.EventArgs e)
        {
            if (this.qryBgFinanzplan.Post())
            {
                DlgWhFinanzplanBeenden dlg = new DlgWhFinanzplanBeenden(_bewilligungTyp, _bgFinanzplanID);

                dlg.Datum = this.qryBgFinanzplan[DBO.BgFinanzplan.DatumBis] as DateTime?;
                dlg.MinDatum = DBUtil.ExecuteScalarSQL(@"
                    SELECT MAX(dbo.fnLastDayOf(dbo.fnDateSerial(Jahr, Monat, 1)))
                    FROM dbo.BgBudget WITH (READUNCOMMITTED)
                    WHERE BgFinanzplanID = {0}
                      AND MasterBudget = 0
                      AND BgBewilligungStatusCode >= 5 -- Bewilligung erteilt",
                    _bgFinanzplanID) as DateTime?;

                if (dlg.MinDatum == null)
                {
                    dlg.MinDatum = this.qryBgFinanzplan[DBO.BgFinanzplan.DatumVon] as DateTime?;
                }
                dlg.GrundEnde = this.qryBgFinanzplan[DBO.BgFinanzplan.BgGrundAbschlussCode];

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
                              FROM dbo.BgBudget BBG WITH (READUNCOMMITTED)
                              WHERE BBG.BgFinanzplanID = {0}
                                AND BBG.MasterBudget = 0
                                AND BBG.BgBewilligungStatusCode < 5 -- Bewilligung erteilt
                                AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) > {1}

                            OPEN cBudget
                            WHILE 1 = 1 BEGIN
                              FETCH NEXT FROM cBudget INTO @BgBudgetID
                              IF @@FETCH_STATUS != 0 BREAK

                              EXECUTE dbo.spWhBudget_Delete @BgBudgetID
                              DELETE FROM dbo.BgBudget WHERE BgBudgetID = @BgBudgetID
                            END
                            CLOSE cBudget
                            DEALLOCATE cBudget"
                            , _bgFinanzplanID
                            , dlg.Datum);
                        this.qryBgFinanzplan.Refresh();

                        if ((DateTime)dlg.Datum <= DateTime.Today)
                        {
                            this.qryBgFinanzplan[DBO.BgFinanzplan.BgBewilligungStatusCode] = (int)BgBewilligungStatus.Gesperrt;
                        }
                        
                        if ((bool)dlg.FinanzPlanNeu)
                        {
                            if((DateTime)qryBgFinanzplan[DBO.BgFinanzplan.DatumBis] > ((DateTime)dlg.Datum).AddDays(1))
                            {
                                //erstelle einen Finanzplan oder Überbrückungshilfe für die Rest-Zeit
                                DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Create {0}, {1}, {2}, {3}",
                                    qryBgFinanzplan[DBO.BgFinanzplan.FaLeistungID],
                                    ((DateTime)dlg.Datum).AddDays(1),
                                    qryBgFinanzplan[DBO.BgFinanzplan.DatumBis],
                                    qryBgFinanzplan[DBO.BgFinanzplan.WhHilfeTypCode]);
                            }
                            else
                            {
                                //erstelle einen neuen Finanzplan (muss zwingend Finanzplan sein, da Überbrückungshilfe nur, wenn noch kein anderer Finanzplan existiert)
                                ShUtil.BgFinanzplanNeu((int)qryBgFinanzplan[DBO.BgFinanzplan.FaLeistungID], 
                                    LOV.WhHilfeTypCode.Regulaerer_Finanzplan);
                            }
                        }

                        this.qryBgFinanzplan[DBO.BgFinanzplan.DatumBis] = dlg.Datum;
                        this.qryBgFinanzplan[DBO.BgFinanzplan.BgGrundAbschlussCode] = dlg.GrundEnde;

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

        private void btnBewilligung_Click(object sender, EventArgs e)
        {
            this.qryBgFinanzplan.RowModified = true;
            if (this.qryBgFinanzplan.Post())
            {
                BgBewilligungStatus bewilligungStatus = (BgBewilligungStatus)this.qryBgFinanzplan[DBO.BgFinanzplan.BgBewilligungStatusCode];

                DlgBewilligung dlg = new DlgBewilligung(_bewilligungTyp, _bgFinanzplanID, bewilligungStatus, IsValid, HasPermission);

                dlg.Datum = qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon] as DateTime?;
                dlg.ShowDialog(this);

                if (!dlg.UserCancel)
                {
                    ApplyAction(dlg);
                }
            }
        }

        private void btnStatusRefresh_Click(object sender, System.EventArgs e)
        {
            this.qryCheck.Refresh();
        }

        private void btnVerlauf_Click(object sender, System.EventArgs e)
        {
            DlgWhFinanzplanVerlauf dlg = new DlgWhFinanzplanVerlauf(_bgFinanzplanID);
            dlg.ShowDialog(this);
        }

        private void qryBgFinanzplan_AfterPost(object sender, EventArgs e)
        {
            if (_updateFinanzplan)
            {
                DBUtil.ExecSQLThrowingException("EXECUTE spWhFinanzplan_Update {0}", _bgFinanzplanID);
                Session.Commit();
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
        }

        private void qryBgFinanzplan_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtGeplantVon, lblGeplantVon.Text);

            DBUtil.CheckNotNullField(edtGeplantBis, lblGeplantBis.Text);

            DBUtil.CheckNotNullField(edtWhGrundbedarfTypCode, lblWhGrundbedarfTypCode.Text);

            if (Utils.firstDayOfMonth((DateTime)qryBgFinanzplan[QRY_FPL_FALL_DATUM_VON]) > ((DateTime)this.qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon]).Date)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlWhFinanzplan", "BeginnAusserhalbSozhilfe", "Der Beginn liegt ausserhalb der Sozialhilfe", KissMsgCode.MsgInfo), this.edtGeplantVon);

            if (!DBUtil.IsEmpty(qryBgFinanzplan[QRY_FPL_FALL_DATUM_BIS]) && Utils.lastDayOfMonth((DateTime)qryBgFinanzplan[QRY_FPL_FALL_DATUM_BIS]) < ((DateTime)this.qryBgFinanzplan[DBO.BgFinanzplan.GeplantBis]).Date)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlWhFinanzplan", "EndeAusserhalbSozhilfe", "Das Ende liegt ausserhalb der Sozialhilfe", KissMsgCode.MsgInfo), this.edtGeplantBis);

            if (((DateTime)this.qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon]).Date > ((DateTime)this.qryBgFinanzplan[DBO.BgFinanzplan.GeplantBis]).Date)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlWhFinanzplan", "BeginnNachEnde", "Der Beginn liegt nach dem Ende", KissMsgCode.MsgInfo));

            if (qryBgFinanzplan.ColumnModified(DBO.BgFinanzplan.WhGrundbedarfTypCode) && (int)edtWhGrundbedarfTypCode.EditValue == 32011)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlWhFinanzplan", "WhGrundbedarfTypCodeObsolete", "Dieser Grundbedarftyp darf nicht mehr verwendet werden!"));

            if ((int)this.qryBgFinanzplan[DBO.BgFinanzplan.BgBewilligungStatusCode] < (int)BgBewilligungStatus.Erteilt)
            {
                if (0 != (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT Count(*)
                    FROM BgFinanzplan
                    WHERE FaLeistungID = {0} AND BgFinanzplanID <> ISNULL({1}, 0)
                      AND dbo.fnDateOf({2})                     <= dbo.fnDateOf(COALESCE(DatumBis, GeplantBis, '99991231'))
                      AND dbo.fnDateOf(IsNull({3}, '99991231')) >= dbo.fnDateOf(COALESCE(DatumVon, GeplantVon))"
                    , this.qryBgFinanzplan[DBO.BgFinanzplan.FaLeistungID], this.qryBgFinanzplan[DBO.BgFinanzplan.BgFinanzplanID]
                    , this.qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon], this.qryBgFinanzplan[DBO.BgFinanzplan.GeplantBis]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlWhFinanzplan", "UeberschneidungDatum_v1", "Es gibt einen weiteren Finanzplan, welcher sich zeitlich mit diesem überschneidet", KissMsgCode.MsgInfo), this.edtDatumVon);
                }

                if ((int)this.qryBgFinanzplan[DBO.BgFinanzplan.WhHilfeTypCode] == 1 && 0 != (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT Count(*) 
                    FROM BgFinanzplan
                    WHERE FaLeistungID = {0} 
                      AND (WhHilfeTypCode <> 1 OR DatumBis = GeplantBis AND BgFinanzplanID <> ISNULL({1}, 0))    -- für Überbrückungshilfe
                      AND (WhHilfeTypCode = 1 OR dbo.fnDateOf(IsNull(DatumVon, GeplantVon)) < dbo.fnDateOf({2})) -- für regulärer Finanzplan", 
                    qryBgFinanzplan[DBO.BgFinanzplan.FaLeistungID], 
                    qryBgFinanzplan[DBO.BgFinanzplan.BgFinanzplanID],
                    qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlWhFinanzplan", "NurErsterFinanzplanUeberbrueckung", "Nur der erste Finanzplan kann eine Überbrückung sein", KissMsgCode.MsgInfo), this.edtDatumVon);
                }
            }
            bool whGrundbedarfTypCode_Changed = qryBgFinanzplan.ColumnModified("WhGrundbedarfTypCode");
            _updateFinanzplan = whGrundbedarfTypCode_Changed || qryBgFinanzplan.ColumnModified(DBO.BgFinanzplan.GeplantVon) || qryBgFinanzplan.ColumnModified(DBO.BgFinanzplan.GeplantBis);

            if (_updateFinanzplan)
            {
                Session.BeginTransaction();

                try
                {
                    if (whGrundbedarfTypCode_Changed)
                    {
                        DBUtil.ExecSQLThrowingException(@"
                            DELETE POS
                            FROM dbo.BgPosition             POS
                              INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                              INNER JOIN dbo.XLOVCode       XLC ON XLC.LOVName = CONVERT(varchar(100), {2}) AND XLC.Code = POA.BgPositionsartCode
                            WHERE POS.BgBudgetID = {0} 
                              AND POA.BgPositionsartCode <> {1};

                            IF NOT EXISTS (SELECT TOP 1 1 
                                           FROM dbo.BgPosition POS
                                             INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                                           WHERE POS.BgBudgetID = {0} 
                                             AND POA.BgPositionsartCode = {1}) 
                            BEGIN
                              INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
                                SELECT TOP 1 
                                  {0}, POA.BgKategorieCode, POA.BgPositionsartID
                                FROM dbo.BgPositionsart   POA WITH (READUNCOMMITTED)
                                WHERE BgPositionsartCode = {1} 
                                  AND ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateOf(ISNULL({3}, {4}))
                                  AND ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(ISNULL({3}, {4}));
                            END;",
                            _bgBudgetID, qryBgFinanzplan[DBO.BgFinanzplan.WhGrundbedarfTypCode], edtWhGrundbedarfTypCode.LOVName, 
                            qryBgFinanzplan[DBO.BgFinanzplan.DatumVon], qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon],
                            qryBgFinanzplan[DBO.BgFinanzplan.DatumBis], qryBgFinanzplan[DBO.BgFinanzplan.GeplantBis]);

                        switch ((int)qryBgFinanzplan[DBO.BgFinanzplan.WhGrundbedarfTypCode])
                        {
                            case 32011:
                                // Grundbedarf 1 Zuschlag
                                DBUtil.ExecSQLThrowingException(@"
                                    IF NOT EXISTS (SELECT TOP 1 1 
                                                   FROM dbo.BgPosition POS
                                                     INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                                                   WHERE POS.BgBudgetID = {0} 
                                                     AND POA.BgPositionsartCode = {1}) 
                                    BEGIN
                                      INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
                                        SELECT TOP 1 
                                          {0}, POA.BgKategorieCode, POA.BgPositionsartID
                                        FROM dbo.BgPositionsart   POA WITH (READUNCOMMITTED)
                                        WHERE BgPositionsartCode = {1} 
                                          AND ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateOf(ISNULL({2}, {3}))
                                          AND ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(ISNULL({2}, {3}));
                                    END;"
                                    , _bgBudgetID, 32012,
                                      qryBgFinanzplan[DBO.BgFinanzplan.DatumVon], qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon]);

                                // Grundbedarf 2
                                DBUtil.ExecSQLThrowingException(@"
                                    IF NOT EXISTS (SELECT TOP 1 1 
                                                   FROM dbo.BgPosition POS
                                                     INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                                                   WHERE POS.BgBudgetID = {0} 
                                                     AND POA.BgPositionsartCode = {1}) 
                                    BEGIN
                                      INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
                                        SELECT TOP 1 
                                          {0}, POA.BgKategorieCode, POA.BgPositionsartID
                                        FROM dbo.BgPositionsart   POA WITH (READUNCOMMITTED)
                                        WHERE BgPositionsartCode = {1} 
                                          AND ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateOf(ISNULL({2}, {3}))
                                          AND ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(ISNULL({2}, {3}));
                                    END;"
                                    , _bgBudgetID, 32013,
                                      qryBgFinanzplan[DBO.BgFinanzplan.DatumVon], qryBgFinanzplan[DBO.BgFinanzplan.GeplantVon]);
                                break;

                            default:
                                DBUtil.ExecSQLThrowingException(
                                    @"DELETE POS FROM dbo.BgPosition POS 
                                        INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                                      WHERE POS.BgBudgetID = {0} 
                                        AND POA.BgPositionsartCode IN (32012, 32013, 32014)"
                                    , _bgBudgetID);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                        Session.Rollback();
                    throw ex;
                }
            }
        }

        private void qryBgFinanzplan_PostError(object sender, UnhandledExceptionEventArgs e)
        {
            if (Session.Transaction != null)
                Session.Rollback();
        }

        private void qryBgFinanzplan_PositionChanged(object sender, System.EventArgs e)
        {
            switch ((BgBewilligungStatus)this.qryBgFinanzplan[DBO.BgFinanzplan.BgBewilligungStatusCode])
            {
                case BgBewilligungStatus.InVorbereitung:
                case BgBewilligungStatus.Angefragt:
                case BgBewilligungStatus.Abgelehnt:
                    this.edtGeplantVon.EditMode = EditModeType.Normal;
                    this.edtGeplantBis.EditMode = EditModeType.Normal;

                    this.edtBgGrundEroeffnenCode.EditMode = EditModeType.Normal;
                    this.edtBgGrundAbschlussCode.EditMode = EditModeType.Normal;

                    //this.edtWhHilfeTypCode.EditMode = EditModeType.Normal;
                    this.edtWhGrundbedarfTypCode.EditMode = EditModeType.Normal;
                    this.edtBemerkung.EditMode = EditModeType.Normal;

                    this.btnBeenden.Enabled = false;
                    break;

                case BgBewilligungStatus.Erteilt:
                case BgBewilligungStatus.Gesperrt:
                    this.edtGeplantVon.EditMode = EditModeType.ReadOnly;
                    this.edtGeplantBis.EditMode = EditModeType.ReadOnly;

                    this.edtBgGrundEroeffnenCode.EditMode = EditModeType.ReadOnly;
                    this.edtBgGrundAbschlussCode.EditMode = EditModeType.ReadOnly;

                    //this.edtWhHilfeTypCode.EditMode = EditModeType.ReadOnly;
                    this.edtWhGrundbedarfTypCode.EditMode = EditModeType.ReadOnly;
                    this.edtBemerkung.EditMode = EditModeType.ReadOnly;

                    this.btnBeenden.Enabled = true;
                    break;
            }
        }

        private void qryCheck_AfterFill(object sender, System.EventArgs e)
        {
            if (this.qryCheck.DataTable.Select("Typ = 0").Length == 0)
            {
                this.txtStatusInfo.Text = "Daten sind vollständig erfasst";
            }
            else
            {
                this.txtStatusInfo.Text = "Die folgenden Daten müssen noch ergänzt/korrigiert werden:";
            }

            foreach (DataRow row in this.qryCheck.DataTable.Select("Typ <= 1"))
            {
                this.txtStatusInfo.Text += "\r\n - " + (string)row[1];
            }

            if (this.qryCheck.DataTable.Select("Typ = 2").Length > 0)
            {
                this.txtStatusInfo.Text += "\r\nWarnung:";
                foreach (DataRow row in this.qryCheck.DataTable.Select("Typ = 2"))
                {
                    this.txtStatusInfo.Text += "\r\n - " + (string)row[1];
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            string WhGrundbedarfTyp = DBUtil.ExecuteScalarSQL(@"
                SELECT IsNull(',%' + XLC.ShortText, '')
                FROM BgFinanzplan      BFP
                  INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = BFP.WhGrundbedarfTypCode
                WHERE BFP.BgFinanzplanID = {0}"
                , this.qryBgFinanzplan[DBO.BgFinanzplan.BgFinanzplanID]) as string;

            return string.Format("WhFinanzplan{0}", WhGrundbedarfTyp);
        }

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BGFINANZPLANID":
                    return this.qryBgFinanzplan[DBO.BgFinanzplan.BgFinanzplanID];
            }

            return base.GetContextValue(FieldName);
        }

        public override void OnRefreshData()
        {
            base.OnRefreshData();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        #endregion

        #region Private Methods

        private void ApplyAction(DlgBewilligung dlg)
        {
            Session.BeginTransaction();
            try
            {
                if (!dlg.ActiveSQLQuery.Post())
                {
                    throw new KissCancelException();
                }

                this.qryBgFinanzplan.Refresh();

                switch (dlg.Aktion)
                {
                    case BewilligungAktion.Bewilligen:
                        DBUtil.ExecSQLThrowingException(600, "EXECUTE spWhFinanzplan_Bewilligen {0}, {1}"
                            , _bgFinanzplanID
                            , dlg.Datum);

                        this.qryBgFinanzplan.Refresh();
                        this.qryBgFinanzplan[DBO.BgFinanzplan.DatumVon] = dlg.Datum;
                        this.qryBgFinanzplan[DBO.BgFinanzplan.DatumBis] = this.qryBgFinanzplan[DBO.BgFinanzplan.GeplantBis];

                        DBUtil.ExecSQLThrowingException(@"
                            UPDATE dbo.BgBudget
                              SET BgBewilligungStatusCode = {1}, Monat = Month({2}), Jahr = Year({2})
                            WHERE BgFinanzplanID = {0}
                              AND MasterBudget = 1"
                            , _bgFinanzplanID, dlg.NextBewilligungStatus, dlg.Datum);
                        break;

                    case BewilligungAktion.Aufheben:
                        DBUtil.ExecSQL(@"
                            UPDATE dbo.BgBudget
                              SET BgBewilligungStatusCode = {1}
                            WHERE BgFinanzplanID = {0}
                              AND MasterBudget = 1"
                            , _bgFinanzplanID
                            , (int)BgBewilligungStatus.InVorbereitung);

                        DBUtil.ExecSQL(@"
                            UPDATE dbo.BgBudget
                              SET BgBewilligungStatusCode = {1} -- Gesperrt
                            WHERE BgFinanzplanID = {0}
                              AND MasterBudget = 0
                              AND BgBewilligungStatusCode = {2} -- Erteilt"
                            , _bgFinanzplanID
                            , (int)BgBewilligungStatus.Gesperrt
                            , (int)BgBewilligungStatus.Erteilt);

                        this.qryBgFinanzplan[DBO.BgFinanzplan.DatumVon] = null;
                        this.qryBgFinanzplan[DBO.BgFinanzplan.DatumBis] = null;
                        break;
                }

                this.qryBgFinanzplan[DBO.BgFinanzplan.BgBewilligungStatusCode] = dlg.NextBewilligungStatus;

                this.qryBgFinanzplan.Post();
                this.qryBgFinanzplan.Refresh();

                Session.Commit();
            }
            catch (Exception ex)
            {
                this.qryBgFinanzplan.DataSet.RejectChanges();
                Session.Rollback();

                if (ex is KissCancelException)
                {
                    ((KissCancelException)ex).ShowMessage();
                }
                else
                {
                    KissMsg.ShowError(ex.Message);
                }
            }
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private bool HasPermission()
        {
            return this.qryCheck.DataTable.Select("Typ = 1").Length == 0;
        }

        private bool IsValid()
        {
            this.qryCheck.Refresh();
            return this.qryCheck.DataTable.Select("Typ = 0").Length == 0;
        }

        private void SetupDataMembers()
        {
            this.edtGeplantVon.DataMember = DBO.BgFinanzplan.GeplantVon;
            this.edtDatumVon.DataMember = DBO.BgFinanzplan.DatumVon;
            this.edtBgGrundEroeffnenCode.DataMember = DBO.BgFinanzplan.BgGrundEroeffnenCode;
            this.edtGeplantBis.DataMember = DBO.BgFinanzplan.GeplantBis;
            this.edtDatumBis.DataMember = DBO.BgFinanzplan.DatumBis;
            this.edtBgGrundAbschlussCode.DataMember = DBO.BgFinanzplan.BgGrundAbschlussCode;
            this.edtWhHilfeTypCode.DataMember = DBO.BgFinanzplan.WhHilfeTypCode;
            this.edtWhGrundbedarfTypCode.DataMember = DBO.BgFinanzplan.WhGrundbedarfTypCode;
            this.edtBemerkung.DataMember = DBO.BgFinanzplan.Bemerkung;
            this.edtBgFinanzplanID.DataMember = DBO.BgFinanzplan.BgFinanzplanID;
            this.edtBgBewilligungStatusCode.DataMember = DBO.BgFinanzplan.BgBewilligungStatusCode;
        }

        #endregion
        
        #endregion
    }
}