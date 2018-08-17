using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaQJExternVermittlungsprofil : KiSS4.Gui.KissUserControl
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
        private KiSS4.Gui.KissCheckedLookupEdit edtBranchen;
        private KiSS4.Gui.KissDateEdit edtInterview;
        private KiSS4.Gui.KissLookUpEdit edtLehrberuf;
        private int faLeistungID = -1;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit1;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit2;
        private KiSS4.Gui.KissMemoEdit kissMemoEdit1;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBranchen;
        private KiSS4.Gui.KissLabel lblInterview;
        private KiSS4.Gui.KissLabel lblLehrberuf1;
        private KiSS4.Gui.KissLabel lblLehrberuf2;
        private KiSS4.Gui.KissLabel lblLehrberuf3;
        private KiSS4.Gui.KissLabel lblTitle;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryQJVermittlung;

        #endregion

        #endregion

        #region Constructors

        public CtlKaQJExternVermittlungsprofil()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJExternVermittlungsprofil));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblBranchen = new KiSS4.Gui.KissLabel();
            this.edtBranchen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.qryQJVermittlung = new KiSS4.DB.SqlQuery(this.components);
            this.lblLehrberuf1 = new KiSS4.Gui.KissLabel();
            this.edtLehrberuf = new KiSS4.Gui.KissLookUpEdit();
            this.lblLehrberuf2 = new KiSS4.Gui.KissLabel();
            this.kissLookUpEdit1 = new KiSS4.Gui.KissLookUpEdit();
            this.lblLehrberuf3 = new KiSS4.Gui.KissLabel();
            this.kissLookUpEdit2 = new KiSS4.Gui.KissLookUpEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.kissMemoEdit1 = new KiSS4.Gui.KissMemoEdit();
            this.btnEinsatzplatzSuchen = new KiSS4.Gui.KissButton();
            this.lblInterview = new KiSS4.Gui.KissLabel();
            this.edtInterview = new KiSS4.Gui.KissDateEdit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQJVermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterview.Properties)).BeginInit();
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
            // lblBranchen
            // 
            this.lblBranchen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblBranchen.Location = new System.Drawing.Point(10, 54);
            this.lblBranchen.Name = "lblBranchen";
            this.lblBranchen.Size = new System.Drawing.Size(80, 16);
            this.lblBranchen.TabIndex = 1;
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
            this.edtBranchen.DataSource = this.qryQJVermittlung;
            this.edtBranchen.Location = new System.Drawing.Point(10, 79);
            this.edtBranchen.LOVName = "KaBranche";
            this.edtBranchen.MultiColumn = true;
            this.edtBranchen.Name = "edtBranchen";
            this.edtBranchen.Size = new System.Drawing.Size(540, 89);
            this.edtBranchen.TabIndex = 2;
            // 
            // qryQJVermittlung
            // 
            this.qryQJVermittlung.CanUpdate = true;
            this.qryQJVermittlung.HostControl = this;
            this.qryQJVermittlung.IsIdentityInsert = false;
            this.qryQJVermittlung.SelectStatement = resources.GetString("qryQJVermittlung.SelectStatement");
            this.qryQJVermittlung.TableName = "KaVermittlungProfil";
            // 
            // lblLehrberuf1
            // 
            this.lblLehrberuf1.Location = new System.Drawing.Point(10, 193);
            this.lblLehrberuf1.Name = "lblLehrberuf1";
            this.lblLehrberuf1.Size = new System.Drawing.Size(80, 24);
            this.lblLehrberuf1.TabIndex = 3;
            this.lblLehrberuf1.Text = "Lehrberuf 1";
            this.lblLehrberuf1.UseCompatibleTextRendering = true;
            // 
            // edtLehrberuf
            // 
            this.edtLehrberuf.DataMember = "LehrberufCode";
            this.edtLehrberuf.DataSource = this.qryQJVermittlung;
            this.edtLehrberuf.Location = new System.Drawing.Point(96, 193);
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtLehrberuf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtLehrberuf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLehrberuf.Properties.NullText = "";
            this.edtLehrberuf.Properties.ShowFooter = false;
            this.edtLehrberuf.Properties.ShowHeader = false;
            this.edtLehrberuf.Size = new System.Drawing.Size(369, 24);
            this.edtLehrberuf.TabIndex = 4;
            // 
            // lblLehrberuf2
            // 
            this.lblLehrberuf2.Location = new System.Drawing.Point(10, 231);
            this.lblLehrberuf2.Name = "lblLehrberuf2";
            this.lblLehrberuf2.Size = new System.Drawing.Size(80, 24);
            this.lblLehrberuf2.TabIndex = 5;
            this.lblLehrberuf2.Text = "Lehrberuf 2";
            this.lblLehrberuf2.UseCompatibleTextRendering = true;
            // 
            // kissLookUpEdit1
            // 
            this.kissLookUpEdit1.DataMember = "Lehrberuf2Code";
            this.kissLookUpEdit1.DataSource = this.qryQJVermittlung;
            this.kissLookUpEdit1.Location = new System.Drawing.Point(96, 230);
            this.kissLookUpEdit1.LOVName = "KaLehrberuf";
            this.kissLookUpEdit1.Name = "kissLookUpEdit1";
            this.kissLookUpEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissLookUpEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.kissLookUpEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit1.Properties.NullText = "";
            this.kissLookUpEdit1.Properties.ShowFooter = false;
            this.kissLookUpEdit1.Properties.ShowHeader = false;
            this.kissLookUpEdit1.Size = new System.Drawing.Size(369, 24);
            this.kissLookUpEdit1.TabIndex = 6;
            // 
            // lblLehrberuf3
            // 
            this.lblLehrberuf3.Location = new System.Drawing.Point(10, 268);
            this.lblLehrberuf3.Name = "lblLehrberuf3";
            this.lblLehrberuf3.Size = new System.Drawing.Size(80, 24);
            this.lblLehrberuf3.TabIndex = 7;
            this.lblLehrberuf3.Text = "Lehrberuf 3";
            this.lblLehrberuf3.UseCompatibleTextRendering = true;
            // 
            // kissLookUpEdit2
            // 
            this.kissLookUpEdit2.DataMember = "Lehrberuf3Code";
            this.kissLookUpEdit2.DataSource = this.qryQJVermittlung;
            this.kissLookUpEdit2.Location = new System.Drawing.Point(96, 267);
            this.kissLookUpEdit2.LOVName = "KaLehrberuf";
            this.kissLookUpEdit2.Name = "kissLookUpEdit2";
            this.kissLookUpEdit2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissLookUpEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.kissLookUpEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit2.Properties.NullText = "";
            this.kissLookUpEdit2.Properties.ShowFooter = false;
            this.kissLookUpEdit2.Properties.ShowHeader = false;
            this.kissLookUpEdit2.Size = new System.Drawing.Size(369, 24);
            this.kissLookUpEdit2.TabIndex = 8;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(10, 336);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(80, 24);
            this.lblBemerkungen.TabIndex = 9;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // kissMemoEdit1
            // 
            this.kissMemoEdit1.DataMember = "Bemerkungen";
            this.kissMemoEdit1.DataSource = this.qryQJVermittlung;
            this.kissMemoEdit1.Location = new System.Drawing.Point(96, 336);
            this.kissMemoEdit1.Name = "kissMemoEdit1";
            this.kissMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissMemoEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit1.Size = new System.Drawing.Size(576, 90);
            this.kissMemoEdit1.TabIndex = 10;
            // 
            // btnEinsatzplatzSuchen
            // 
            this.btnEinsatzplatzSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinsatzplatzSuchen.Location = new System.Drawing.Point(96, 442);
            this.btnEinsatzplatzSuchen.Name = "btnEinsatzplatzSuchen";
            this.btnEinsatzplatzSuchen.Size = new System.Drawing.Size(124, 24);
            this.btnEinsatzplatzSuchen.TabIndex = 11;
            this.btnEinsatzplatzSuchen.Text = "Einsatzplatz suchen";
            this.btnEinsatzplatzSuchen.UseCompatibleTextRendering = true;
            this.btnEinsatzplatzSuchen.UseVisualStyleBackColor = false;
            this.btnEinsatzplatzSuchen.Click += new System.EventHandler(this.btnEinsatzplatzSuchen_Click);
            // 
            // lblInterview
            // 
            this.lblInterview.Location = new System.Drawing.Point(10, 302);
            this.lblInterview.Name = "lblInterview";
            this.lblInterview.Size = new System.Drawing.Size(80, 24);
            this.lblInterview.TabIndex = 12;
            this.lblInterview.Text = "Interview";
            this.lblInterview.UseCompatibleTextRendering = true;
            // 
            // edtInterview
            // 
            this.edtInterview.DataMember = "Interview";
            this.edtInterview.DataSource = this.qryQJVermittlung;
            this.edtInterview.EditValue = null;
            this.edtInterview.Location = new System.Drawing.Point(97, 301);
            this.edtInterview.Name = "edtInterview";
            this.edtInterview.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtInterview.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInterview.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInterview.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInterview.Properties.Appearance.Options.UseBackColor = true;
            this.edtInterview.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInterview.Properties.Appearance.Options.UseFont = true;
            this.edtInterview.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtInterview.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtInterview.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtInterview.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInterview.Properties.ShowToday = false;
            this.edtInterview.Size = new System.Drawing.Size(100, 24);
            this.edtInterview.TabIndex = 13;
            // 
            // CtlKaQJExternVermittlungsprofil
            // 
            this.ActiveSQLQuery = this.qryQJVermittlung;
            this.AutoScroll = true;
            this.Controls.Add(this.edtInterview);
            this.Controls.Add(this.lblInterview);
            this.Controls.Add(this.btnEinsatzplatzSuchen);
            this.Controls.Add(this.kissMemoEdit1);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.kissLookUpEdit2);
            this.Controls.Add(this.lblLehrberuf3);
            this.Controls.Add(this.kissLookUpEdit1);
            this.Controls.Add(this.lblLehrberuf2);
            this.Controls.Add(this.edtLehrberuf);
            this.Controls.Add(this.lblLehrberuf1);
            this.Controls.Add(this.edtBranchen);
            this.Controls.Add(this.lblBranchen);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaQJExternVermittlungsprofil";
            this.Size = new System.Drawing.Size(675, 574);
            this.Load += new System.EventHandler(this.CtlKaQJExternVermittlungsprofil_Load);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQJVermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLehrberuf3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterview.Properties)).EndInit();
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

        private void CtlKaQJExternVermittlungsprofil_Load(object sender, EventArgs e)
        {
            btnEinsatzplatzSuchen.Enabled = DBUtil.UserHasRight("CtlKaQJExternVermittlungsprofil", "UI") && (MayUpd || MayIns);

            if (KaUtil.GetSichtbarSDFlag(this.baPersonID) == 1)
            {
                qryQJVermittlung.EnableBoundFields(false);
                btnEinsatzplatzSuchen.Enabled = false;
            }
        }

        private void btnEinsatzplatzSuchen_Click(object sender, System.EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            if (qryQJVermittlung.Count > 0)
                FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEPSuchen", "BrancheCodes", qryQJVermittlung["BrancheCodes"], "LehrberufCode", qryQJVermittlung["LehrberufCode"]);
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
                    return (int) DBUtil.ExecuteScalarSQL("select BaPersonID from FaLeistung where FaLeistungID = {0}", faLeistungID);
                case "KAVERMITTLUNGPROFILID":
                    return qryQJVermittlung["KaVermittlungProfilID"];
                case "OWNERUSERID":
                    return (int) DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", faLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        // ComponentName: qryQJVermittlung
        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            this.faLeistungID = FaLeistungID;
            this.baPersonID = BaPersonID;

            DBUtil.GetFallRights(this.faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);

            if (!VermittlungExists() && DBUtil.UserHasRight("CtlKaQJExternVermittlungsprofil", "UI") && (MayUpd || MayIns))
            {
                DBUtil.ExecSQL(@"
                  INSERT INTO dbo.KaVermittlungProfil (FaLeistungID, SichtbarSDFlag, Creator, Created, Modifier, Modified) 
                  VALUES ({0}, {1}, {2}, GETDATE(), {2}, GETDATE())",
                  faLeistungID, KaUtil.IsVisibleSD(baPersonID),
                  DBUtil.GetDBRowCreatorModifier());
            }

            qryQJVermittlung.Fill(faLeistungID, Session.User.IsUserKA ? 0 : 1);
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