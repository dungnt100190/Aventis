using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.BegleitetesWohnen
{
    public class CtlBwEvaluation : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private int FaLeistungID = -1;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtAuswertungGeplant;
        private KiSS4.Gui.KissDateEdit edtAuswertungZV;
        private KiSS4.Gui.KissDateEdit edtErsterEinsatzAm;
        private KiSS4.Gui.KissTextEdit edtZustaendigBW;
        private System.Windows.Forms.GroupBox gbErreichtZiel1;
        private KiSS4.Gui.KissLabel lblAuswertungGeplant;
        private KiSS4.Gui.KissLabel lblAuswertungZV;
        private KiSS4.Gui.KissLabel lblBegruendungZiele;
        private KiSS4.Gui.KissLabel lblErreichtZiel1;
        private KiSS4.Gui.KissLabel lblErsterEinsatzWar;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTitelZiele;
        private KiSS4.Gui.KissLabel lblZustaendigBW;
        private KiSS4.Gui.KissRTFEdit memBegruendungZiel;
        private KiSS4.Gui.KissRTFEdit memZiel;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaBegleitetesWohnen;
        private KiSS4.Gui.KissRadioGroup rgrEvaluationZiele;

        #endregion

        #region Constructors

        public CtlBwEvaluation()
        {
            this.InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBwEvaluation));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblZustaendigBW = new KiSS4.Gui.KissLabel();
            this.panTitel = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtZustaendigBW = new KiSS4.Gui.KissTextEdit();
            this.lblAuswertungZV = new KiSS4.Gui.KissLabel();
            this.edtAuswertungZV = new KiSS4.Gui.KissDateEdit();
            this.lblErsterEinsatzWar = new KiSS4.Gui.KissLabel();
            this.edtErsterEinsatzAm = new KiSS4.Gui.KissDateEdit();
            this.lblAuswertungGeplant = new KiSS4.Gui.KissLabel();
            this.edtAuswertungGeplant = new KiSS4.Gui.KissDateEdit();
            this.lblTitelZiele = new KiSS4.Gui.KissLabel();
            this.memZiel = new KiSS4.Gui.KissRTFEdit();
            this.gbErreichtZiel1 = new System.Windows.Forms.GroupBox();
            this.lblErreichtZiel1 = new KiSS4.Gui.KissLabel();
            this.rgrEvaluationZiele = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblBegruendungZiele = new KiSS4.Gui.KissLabel();
            this.memBegruendungZiel = new KiSS4.Gui.KissRTFEdit();
            this.qryFaBegleitetesWohnen = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigBW)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigBW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungZV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertungZV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErsterEinsatzWar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErsterEinsatzAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungGeplant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertungGeplant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelZiele)).BeginInit();
            this.gbErreichtZiel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichtZiel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrEvaluationZiele.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendungZiele)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaBegleitetesWohnen)).BeginInit();
            this.SuspendLayout();
            //
            // lblZustaendigBW
            //
            this.lblZustaendigBW.Location = new System.Drawing.Point(8, 41);
            this.lblZustaendigBW.Name = "lblZustaendigBW";
            this.lblZustaendigBW.Size = new System.Drawing.Size(99, 24);
            this.lblZustaendigBW.TabIndex = 0;
            this.lblZustaendigBW.Text = "Zuständig BW";
            this.lblZustaendigBW.UseCompatibleTextRendering = true;
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
            this.lblTitel.Text = "Evaluation Begleitetes Wohnen";
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
            // edtZustaendigBW
            //
            this.edtZustaendigBW.DataMember = "ZustaendigBW";
            this.edtZustaendigBW.DataSource = this.qryFaBegleitetesWohnen;
            this.edtZustaendigBW.EditMode = KiSS4.Gui.EditModeType.ReadOnly;
            this.edtZustaendigBW.Location = new System.Drawing.Point(113, 41);
            this.edtZustaendigBW.Name = "edtZustaendigBW";
            this.edtZustaendigBW.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZustaendigBW.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigBW.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigBW.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigBW.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigBW.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigBW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZustaendigBW.Properties.ReadOnly = true;
            this.edtZustaendigBW.Size = new System.Drawing.Size(128, 24);
            this.edtZustaendigBW.TabIndex = 1;
            //
            // lblAuswertungZV
            //
            this.lblAuswertungZV.Location = new System.Drawing.Point(8, 71);
            this.lblAuswertungZV.Name = "lblAuswertungZV";
            this.lblAuswertungZV.Size = new System.Drawing.Size(99, 24);
            this.lblAuswertungZV.TabIndex = 2;
            this.lblAuswertungZV.Text = "Auswertung ZV";
            this.lblAuswertungZV.UseCompatibleTextRendering = true;
            //
            // edtAuswertungZV
            //
            this.edtAuswertungZV.DataMember = "AuswertungZV";
            this.edtAuswertungZV.DataSource = this.qryFaBegleitetesWohnen;
            this.edtAuswertungZV.EditValue = null;
            this.edtAuswertungZV.Location = new System.Drawing.Point(113, 71);
            this.edtAuswertungZV.Name = "edtAuswertungZV";
            this.edtAuswertungZV.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuswertungZV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswertungZV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswertungZV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswertungZV.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswertungZV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswertungZV.Properties.Appearance.Options.UseFont = true;
            this.edtAuswertungZV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAuswertungZV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAuswertungZV.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAuswertungZV.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswertungZV.Properties.ShowToday = false;
            this.edtAuswertungZV.Size = new System.Drawing.Size(128, 24);
            this.edtAuswertungZV.TabIndex = 3;
            //
            // lblErsterEinsatzWar
            //
            this.lblErsterEinsatzWar.Location = new System.Drawing.Point(269, 41);
            this.lblErsterEinsatzWar.Name = "lblErsterEinsatzWar";
            this.lblErsterEinsatzWar.Size = new System.Drawing.Size(125, 24);
            this.lblErsterEinsatzWar.TabIndex = 4;
            this.lblErsterEinsatzWar.Text = "Erster Einsatz war";
            this.lblErsterEinsatzWar.UseCompatibleTextRendering = true;
            //
            // edtErsterEinsatzAm
            //
            this.edtErsterEinsatzAm.DataMember = "ErsterEinsatzAm";
            this.edtErsterEinsatzAm.DataSource = this.qryFaBegleitetesWohnen;
            this.edtErsterEinsatzAm.EditMode = KiSS4.Gui.EditModeType.ReadOnly;
            this.edtErsterEinsatzAm.EditValue = null;
            this.edtErsterEinsatzAm.Location = new System.Drawing.Point(400, 41);
            this.edtErsterEinsatzAm.Name = "edtErsterEinsatzAm";
            this.edtErsterEinsatzAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErsterEinsatzAm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
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
            this.edtErsterEinsatzAm.Properties.ReadOnly = true;
            this.edtErsterEinsatzAm.Properties.ShowToday = false;
            this.edtErsterEinsatzAm.Size = new System.Drawing.Size(128, 24);
            this.edtErsterEinsatzAm.TabIndex = 5;
            //
            // lblAuswertungGeplant
            //
            this.lblAuswertungGeplant.Location = new System.Drawing.Point(269, 71);
            this.lblAuswertungGeplant.Name = "lblAuswertungGeplant";
            this.lblAuswertungGeplant.Size = new System.Drawing.Size(125, 24);
            this.lblAuswertungGeplant.TabIndex = 6;
            this.lblAuswertungGeplant.Text = "Auswertung geplant";
            this.lblAuswertungGeplant.UseCompatibleTextRendering = true;
            //
            // edtAuswertungGeplant
            //
            this.edtAuswertungGeplant.DataMember = "AuswertungGeplant";
            this.edtAuswertungGeplant.DataSource = this.qryFaBegleitetesWohnen;
            this.edtAuswertungGeplant.EditMode = KiSS4.Gui.EditModeType.ReadOnly;
            this.edtAuswertungGeplant.EditValue = null;
            this.edtAuswertungGeplant.Location = new System.Drawing.Point(400, 71);
            this.edtAuswertungGeplant.Name = "edtAuswertungGeplant";
            this.edtAuswertungGeplant.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuswertungGeplant.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
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
            this.edtAuswertungGeplant.Properties.ReadOnly = true;
            this.edtAuswertungGeplant.Properties.ShowToday = false;
            this.edtAuswertungGeplant.Size = new System.Drawing.Size(128, 24);
            this.edtAuswertungGeplant.TabIndex = 7;
            //
            // lblTitelZiele
            //
            this.lblTitelZiele.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelZiele.Location = new System.Drawing.Point(8, 111);
            this.lblTitelZiele.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.lblTitelZiele.Name = "lblTitelZiele";
            this.lblTitelZiele.Size = new System.Drawing.Size(93, 45);
            this.lblTitelZiele.TabIndex = 8;
            this.lblTitelZiele.Text = "Ziele";
            this.lblTitelZiele.UseCompatibleTextRendering = true;
            //
            // memZiel
            //
            this.memZiel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memZiel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memZiel.DataMember = "Ziele";
            this.memZiel.DataSource = this.qryFaBegleitetesWohnen;
            this.memZiel.EditMode = KiSS4.Gui.EditModeType.ReadOnly;
            this.memZiel.Font = new System.Drawing.Font("Arial", 10F);
            this.memZiel.Location = new System.Drawing.Point(107, 111);
            this.memZiel.Name = "memZiel";
            this.memZiel.ReadOnly = true;
            this.memZiel.Size = new System.Drawing.Size(452, 186);
            this.memZiel.TabIndex = 9;
            //
            // gbErreichtZiel1
            //
            this.gbErreichtZiel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbErreichtZiel1.Controls.Add(this.rgrEvaluationZiele);
            this.gbErreichtZiel1.Controls.Add(this.lblErreichtZiel1);
            this.gbErreichtZiel1.Location = new System.Drawing.Point(565, 105);
            this.gbErreichtZiel1.Name = "gbErreichtZiel1";
            this.gbErreichtZiel1.Size = new System.Drawing.Size(151, 80);
            this.gbErreichtZiel1.TabIndex = 10;
            this.gbErreichtZiel1.TabStop = false;
            this.gbErreichtZiel1.UseCompatibleTextRendering = true;
            //
            // lblErreichtZiel1
            //
            this.lblErreichtZiel1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblErreichtZiel1.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErreichtZiel1.Location = new System.Drawing.Point(3, 15);
            this.lblErreichtZiel1.Name = "lblErreichtZiel1";
            this.lblErreichtZiel1.Size = new System.Drawing.Size(145, 16);
            this.lblErreichtZiel1.TabIndex = 0;
            this.lblErreichtZiel1.Text = "erreicht";
            this.lblErreichtZiel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErreichtZiel1.UseCompatibleTextRendering = true;
            //
            // rgrEvaluationZiele
            //
            this.rgrEvaluationZiele.DataMember = "ZieleEvaluation";
            this.rgrEvaluationZiele.DataSource = this.qryFaBegleitetesWohnen;
            this.rgrEvaluationZiele.Location = new System.Drawing.Point(3, 38);
            this.rgrEvaluationZiele.Name = "rgrEvaluationZiele";
            this.rgrEvaluationZiele.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrEvaluationZiele.Properties.Appearance.Options.UseBackColor = true;
            this.rgrEvaluationZiele.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrEvaluationZiele.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrEvaluationZiele.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrEvaluationZiele.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rgrEvaluationZiele.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
                        new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Ja"),
                        new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Nein"),
                        new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Teilw.")});
            this.rgrEvaluationZiele.Size = new System.Drawing.Size(145, 24);
            this.rgrEvaluationZiele.TabIndex = 1;
            //
            // lblBegruendungZiele
            //
            this.lblBegruendungZiele.Location = new System.Drawing.Point(8, 303);
            this.lblBegruendungZiele.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.lblBegruendungZiele.Name = "lblBegruendungZiele";
            this.lblBegruendungZiele.Size = new System.Drawing.Size(93, 24);
            this.lblBegruendungZiele.TabIndex = 11;
            this.lblBegruendungZiele.Text = "Begründung";
            this.lblBegruendungZiele.UseCompatibleTextRendering = true;
            //
            // memBegruendungZiel
            //
            this.memBegruendungZiel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBegruendungZiel.BackColor = System.Drawing.Color.White;
            this.memBegruendungZiel.DataMember = "ZieleBegruendung";
            this.memBegruendungZiel.DataSource = this.qryFaBegleitetesWohnen;
            this.memBegruendungZiel.Font = new System.Drawing.Font("Arial", 10F);
            this.memBegruendungZiel.Location = new System.Drawing.Point(107, 303);
            this.memBegruendungZiel.Name = "memBegruendungZiel";
            this.memBegruendungZiel.Size = new System.Drawing.Size(452, 285);
            this.memBegruendungZiel.TabIndex = 12;
            //
            // qryFaBegleitetesWohnen
            //
            this.qryFaBegleitetesWohnen.HostControl = this;
            this.qryFaBegleitetesWohnen.TableName = "FaBegleitetesWohnen";
            this.qryFaBegleitetesWohnen.BeforePost += new System.EventHandler(this.qryFaBegleitetesWohnen_BeforePost);
            //
            // CtlBwEvaluation
            //
            this.ActiveSQLQuery = this.qryFaBegleitetesWohnen;
            this.AutoRefresh = false;
            this.Controls.Add(this.memBegruendungZiel);
            this.Controls.Add(this.lblBegruendungZiele);
            this.Controls.Add(this.gbErreichtZiel1);
            this.Controls.Add(this.memZiel);
            this.Controls.Add(this.lblTitelZiele);
            this.Controls.Add(this.edtAuswertungGeplant);
            this.Controls.Add(this.lblAuswertungGeplant);
            this.Controls.Add(this.edtErsterEinsatzAm);
            this.Controls.Add(this.lblErsterEinsatzWar);
            this.Controls.Add(this.edtAuswertungZV);
            this.Controls.Add(this.lblAuswertungZV);
            this.Controls.Add(this.edtZustaendigBW);
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.lblZustaendigBW);
            this.Name = "CtlBwEvaluation";
            this.Size = new System.Drawing.Size(722, 596);
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigBW)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigBW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungZV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertungZV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErsterEinsatzWar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErsterEinsatzAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungGeplant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertungGeplant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelZiele)).EndInit();
            this.gbErreichtZiel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichtZiel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrEvaluationZiele.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendungZiele)).EndInit();
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
            qryFaBegleitetesWohnen.Fill(@"SELECT BW.*,
                              ZustaendigBW 	= dbo.fnGetLastFirstName(NULL, USRBw.LastName, USRBw.FirstName)
                           FROM FaBegleitetesWohnen BW
                         LEFT JOIN XUser USRBw ON USRBw.UserID = BW.UserID
                           WHERE BW.FaLeistungID = {0}", faLeistungID);

            // check if any data found
            if (qryFaBegleitetesWohnen.Count < 1 || DBUtil.IsEmpty(qryFaBegleitetesWohnen["ErstellungZV"]))
            {
                // no data yet, cannot continue
                qryFaBegleitetesWohnen.CanUpdate = false;
            }

            // update states of fields
            qryFaBegleitetesWohnen.EnableBoundFields(qryFaBegleitetesWohnen.CanUpdate);
        }

        #endregion

        #region Private Methods

        private void qryFaBegleitetesWohnen_BeforePost(object sender, System.EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtAuswertungZV, lblAuswertungZV.Text);

            // validate dates
            if (Convert.ToDateTime(qryFaBegleitetesWohnen["ErstellungZV"]) >= Convert.ToDateTime(qryFaBegleitetesWohnen["AuswertungZV"]))
            {
                // invalid range
                edtAuswertungZV.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBwEvaluation", "InvalidDateOrder", "Das Datum 'Auswertung ZV' ist ungültig - es muss grösser als 'Erstellung ZV - {0}' sein.", KissMsgCode.MsgInfo, Convert.ToDateTime(qryFaBegleitetesWohnen["ErstellungZV"]).ToString("dd.MM.yyyy")), (Control)edtAuswertungZV);
            }
        }

        #endregion
    }
}