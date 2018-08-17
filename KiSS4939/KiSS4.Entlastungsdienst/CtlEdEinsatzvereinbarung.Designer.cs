using System.Windows.Forms;

namespace KiSS4.Entlastungsdienst
{
    partial class CtlEdEinsatzvereinbarung
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlEdEinsatzvereinbarung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.panTopData = new System.Windows.Forms.Panel();
            this.docEinsatzvereinbarung = new KiSS4.Dokument.KissDocumentButton();
            this.edtErsterEinsatzAm = new KiSS4.Gui.KissDateEdit();
            this.qryEdEinsatzvereinbarung = new KiSS4.DB.SqlQuery();
            this.lblErsterEinsatzAm = new KiSS4.Gui.KissLabel();
            this.edtErstellungEV = new KiSS4.Gui.KissDateEdit();
            this.lblErstellungEV = new KiSS4.Gui.KissLabel();
            this.edtZustaendigED = new KiSS4.Gui.KissTextEdit();
            this.lblZustaendigED = new KiSS4.Gui.KissLabel();
            this.edtAnlass = new KiSS4.Gui.KissLookUpEdit();
            this.lblAnlass = new KiSS4.Gui.KissLabel();
            this.edtTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblTyp = new KiSS4.Gui.KissLabel();
            this.tabEinsatzvereinbarung = new KiSS4.Gui.KissTabControlEx();
            this.tpgEntlaster = new SharpLibrary.WinControls.TabPageEx();
            this.tpgAuftrag = new SharpLibrary.WinControls.TabPageEx();
            this.grpAuftragBemerkungen = new KiSS4.Gui.KissGroupBox();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.panTarifReduktion = new System.Windows.Forms.Panel();
            this.grpReduktionen = new KiSS4.Gui.KissGroupBox();
            this.edtReduktionCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.panTarifReduktionSpacer = new System.Windows.Forms.Panel();
            this.grpTarife = new KiSS4.Gui.KissGroupBox();
            this.edtTarifZuschlag = new KiSS4.Gui.KissCalcEdit();
            this.lblTarifZuschlag = new KiSS4.Gui.KissLabel();
            this.edtTarifNacht = new KiSS4.Gui.KissCalcEdit();
            this.lblTarifNacht = new KiSS4.Gui.KissLabel();
            this.edtTarifTag = new KiSS4.Gui.KissCalcEdit();
            this.lblTarifTag = new KiSS4.Gui.KissLabel();
            this.grpAuftrag = new KiSS4.Gui.KissGroupBox();
            this.edtAuftrag = new KiSS4.Gui.KissRTFEdit();
            this.lblVereinbarteEinsatzzeiten = new KiSS4.Gui.KissLabel();
            this.edtVereinbarteEinsatzzeiten = new KiSS4.Gui.KissMemoEdit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.panTopData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtErsterEinsatzAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdEinsatzvereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErsterEinsatzAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellungEV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellungEV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnlass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnlass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnlass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).BeginInit();
            this.tabEinsatzvereinbarung.SuspendLayout();
            this.tpgAuftrag.SuspendLayout();
            this.grpAuftragBemerkungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            this.panTarifReduktion.SuspendLayout();
            this.grpReduktionen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtReduktionCodes)).BeginInit();
            this.grpTarife.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTarifZuschlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarifZuschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTarifNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarifNacht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTarifTag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarifTag)).BeginInit();
            this.grpAuftrag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarteEinsatzzeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbarteEinsatzzeiten.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // panTitel
            //
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 0;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(680, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Einsatzvereinbarung Entlastungsdienst";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // panTopData
            //
            this.panTopData.Controls.Add(this.docEinsatzvereinbarung);
            this.panTopData.Controls.Add(this.edtErsterEinsatzAm);
            this.panTopData.Controls.Add(this.lblErsterEinsatzAm);
            this.panTopData.Controls.Add(this.edtErstellungEV);
            this.panTopData.Controls.Add(this.lblErstellungEV);
            this.panTopData.Controls.Add(this.edtZustaendigED);
            this.panTopData.Controls.Add(this.lblZustaendigED);
            this.panTopData.Controls.Add(this.edtAnlass);
            this.panTopData.Controls.Add(this.lblAnlass);
            this.panTopData.Controls.Add(this.edtTyp);
            this.panTopData.Controls.Add(this.lblTyp);
            this.panTopData.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopData.Location = new System.Drawing.Point(0, 30);
            this.panTopData.Name = "panTopData";
            this.panTopData.Size = new System.Drawing.Size(722, 102);
            this.panTopData.TabIndex = 1;
            //
            // docEinsatzvereinbarung
            //
            this.docEinsatzvereinbarung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.docEinsatzvereinbarung.Context = "ED_Einsatzvereinbarung_Einsatzvereinbarung";
            this.docEinsatzvereinbarung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docEinsatzvereinbarung.Image = ((System.Drawing.Image)(resources.GetObject("docEinsatzvereinbarung.Image")));
            this.docEinsatzvereinbarung.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docEinsatzvereinbarung.Location = new System.Drawing.Point(553, 9);
            this.docEinsatzvereinbarung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.docEinsatzvereinbarung.Name = "docEinsatzvereinbarung";
            this.docEinsatzvereinbarung.Size = new System.Drawing.Size(160, 24);
            this.docEinsatzvereinbarung.TabIndex = 10;
            this.docEinsatzvereinbarung.Text = "Einsatzvereinbarung";
            this.docEinsatzvereinbarung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docEinsatzvereinbarung.UseCompatibleTextRendering = true;
            this.docEinsatzvereinbarung.UseVisualStyleBackColor = false;
            //
            // edtErsterEinsatzAm
            //
            this.edtErsterEinsatzAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErsterEinsatzAm.DataMember = "ErsterEinsatzAm";
            this.edtErsterEinsatzAm.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtErsterEinsatzAm.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtErsterEinsatzAm.EditValue = null;
            this.edtErsterEinsatzAm.Location = new System.Drawing.Point(603, 69);
            this.edtErsterEinsatzAm.Name = "edtErsterEinsatzAm";
            this.edtErsterEinsatzAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErsterEinsatzAm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
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
            this.edtErsterEinsatzAm.Properties.ShowToday = false;
            this.edtErsterEinsatzAm.Size = new System.Drawing.Size(110, 24);
            this.edtErsterEinsatzAm.TabIndex = 9;
            //
            // qryEdEinsatzvereinbarung
            //
            this.qryEdEinsatzvereinbarung.HostControl = this;
            this.qryEdEinsatzvereinbarung.TableName = "EdEinsatzvereinbarung";
            this.qryEdEinsatzvereinbarung.AfterInsert += new System.EventHandler(this.qryEdEinsatzvereinbarung_AfterInsert);
            this.qryEdEinsatzvereinbarung.BeforePost += new System.EventHandler(this.qryEdEinsatzvereinbarung_BeforePost);
            this.qryEdEinsatzvereinbarung.AfterPost += new System.EventHandler(this.qryEdEinsatzvereinbarung_AfterPost);
            //
            // lblErsterEinsatzAm
            //
            this.lblErsterEinsatzAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErsterEinsatzAm.Location = new System.Drawing.Point(481, 69);
            this.lblErsterEinsatzAm.Name = "lblErsterEinsatzAm";
            this.lblErsterEinsatzAm.Size = new System.Drawing.Size(116, 24);
            this.lblErsterEinsatzAm.TabIndex = 8;
            this.lblErsterEinsatzAm.Text = "Erster Einsatz am";
            this.lblErsterEinsatzAm.UseCompatibleTextRendering = true;
            //
            // edtErstellungEV
            //
            this.edtErstellungEV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErstellungEV.DataMember = "ErstellungEV";
            this.edtErstellungEV.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtErstellungEV.EditValue = null;
            this.edtErstellungEV.Location = new System.Drawing.Point(603, 39);
            this.edtErstellungEV.Name = "edtErstellungEV";
            this.edtErstellungEV.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstellungEV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErstellungEV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstellungEV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstellungEV.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstellungEV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstellungEV.Properties.Appearance.Options.UseFont = true;
            this.edtErstellungEV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtErstellungEV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstellungEV.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtErstellungEV.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstellungEV.Properties.ShowToday = false;
            this.edtErstellungEV.Size = new System.Drawing.Size(110, 24);
            this.edtErstellungEV.TabIndex = 7;
            //
            // lblErstellungEV
            //
            this.lblErstellungEV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErstellungEV.Location = new System.Drawing.Point(481, 39);
            this.lblErstellungEV.Name = "lblErstellungEV";
            this.lblErstellungEV.Size = new System.Drawing.Size(116, 24);
            this.lblErstellungEV.TabIndex = 6;
            this.lblErstellungEV.Text = "Erstellung EV";
            this.lblErstellungEV.UseCompatibleTextRendering = true;
            //
            // edtZustaendigED
            //
            this.edtZustaendigED.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtZustaendigED.DataMember = "ZustaendigED";
            this.edtZustaendigED.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtZustaendigED.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZustaendigED.Location = new System.Drawing.Point(110, 69);
            this.edtZustaendigED.Name = "edtZustaendigED";
            this.edtZustaendigED.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZustaendigED.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigED.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigED.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigED.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigED.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigED.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZustaendigED.Properties.ReadOnly = true;
            this.edtZustaendigED.Size = new System.Drawing.Size(350, 24);
            this.edtZustaendigED.TabIndex = 5;
            this.edtZustaendigED.TabStop = false;
            //
            // lblZustaendigED
            //
            this.lblZustaendigED.Location = new System.Drawing.Point(9, 69);
            this.lblZustaendigED.Name = "lblZustaendigED";
            this.lblZustaendigED.Size = new System.Drawing.Size(95, 24);
            this.lblZustaendigED.TabIndex = 4;
            this.lblZustaendigED.Text = "Zuständig ED";
            this.lblZustaendigED.UseCompatibleTextRendering = true;
            //
            // edtAnlass
            //
            this.edtAnlass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnlass.DataMember = "AnlassCode";
            this.edtAnlass.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtAnlass.Location = new System.Drawing.Point(110, 39);
            this.edtAnlass.LOVName = "EDAnlass";
            this.edtAnlass.Name = "edtAnlass";
            this.edtAnlass.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnlass.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnlass.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnlass.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnlass.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnlass.Properties.Appearance.Options.UseFont = true;
            this.edtAnlass.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAnlass.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnlass.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAnlass.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAnlass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAnlass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAnlass.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnlass.Properties.NullText = "";
            this.edtAnlass.Properties.ShowFooter = false;
            this.edtAnlass.Properties.ShowHeader = false;
            this.edtAnlass.Size = new System.Drawing.Size(350, 24);
            this.edtAnlass.TabIndex = 3;
            //
            // lblAnlass
            //
            this.lblAnlass.Location = new System.Drawing.Point(9, 39);
            this.lblAnlass.Margin = new System.Windows.Forms.Padding(9, 9, 3, 0);
            this.lblAnlass.Name = "lblAnlass";
            this.lblAnlass.Size = new System.Drawing.Size(95, 24);
            this.lblAnlass.TabIndex = 2;
            this.lblAnlass.Text = "Anlass";
            this.lblAnlass.UseCompatibleTextRendering = true;
            //
            // edtTyp
            //
            this.edtTyp.AllowNull = false;
            this.edtTyp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTyp.DataMember = "TypCode";
            this.edtTyp.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtTyp.Location = new System.Drawing.Point(110, 9);
            this.edtTyp.LOVName = "EDTyp";
            this.edtTyp.Name = "edtTyp";
            this.edtTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTyp.Properties.Appearance.Options.UseFont = true;
            this.edtTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTyp.Properties.NullText = "";
            this.edtTyp.Properties.ShowFooter = false;
            this.edtTyp.Properties.ShowHeader = false;
            this.edtTyp.Size = new System.Drawing.Size(350, 24);
            this.edtTyp.TabIndex = 1;
            //
            // lblTyp
            //
            this.lblTyp.Location = new System.Drawing.Point(9, 9);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(95, 24);
            this.lblTyp.TabIndex = 0;
            this.lblTyp.Text = "Typ ED";
            this.lblTyp.UseCompatibleTextRendering = true;
            //
            // tabEinsatzvereinbarung
            //
            this.tabEinsatzvereinbarung.Controls.Add(this.tpgEntlaster);
            this.tabEinsatzvereinbarung.Controls.Add(this.tpgAuftrag);
            this.tabEinsatzvereinbarung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEinsatzvereinbarung.Location = new System.Drawing.Point(0, 132);
            this.tabEinsatzvereinbarung.Name = "tabEinsatzvereinbarung";
            this.tabEinsatzvereinbarung.ShowFixedWidthTooltip = true;
            this.tabEinsatzvereinbarung.Size = new System.Drawing.Size(722, 464);
            this.tabEinsatzvereinbarung.TabIndex = 2;
            this.tabEinsatzvereinbarung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgAuftrag,
            this.tpgEntlaster});
            this.tabEinsatzvereinbarung.TabsLineColor = System.Drawing.Color.Black;
            this.tabEinsatzvereinbarung.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabEinsatzvereinbarung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabEinsatzvereinbarung.Text = "kissTabControlEx1";
            //
            // tpgEntlaster
            //
            this.tpgEntlaster.Location = new System.Drawing.Point(6, 32);
            this.tpgEntlaster.Name = "tpgEntlaster";
            this.tpgEntlaster.Padding = new System.Windows.Forms.Padding(6);
            this.tpgEntlaster.Size = new System.Drawing.Size(710, 426);
            this.tpgEntlaster.TabIndex = 1;
            this.tpgEntlaster.Title = "Mögliche Entlaster/innen";
            //
            // tpgAuftrag
            //
            this.tpgAuftrag.Controls.Add(this.grpAuftragBemerkungen);
            this.tpgAuftrag.Controls.Add(this.panTarifReduktion);
            this.tpgAuftrag.Controls.Add(this.grpAuftrag);
            this.tpgAuftrag.Location = new System.Drawing.Point(6, 32);
            this.tpgAuftrag.Name = "tpgAuftrag";
            this.tpgAuftrag.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAuftrag.Size = new System.Drawing.Size(710, 426);
            this.tpgAuftrag.TabIndex = 0;
            this.tpgAuftrag.Title = "Auftrag";
            //
            // grpAuftragBemerkungen
            //
            this.grpAuftragBemerkungen.Controls.Add(this.edtBemerkungen);
            this.grpAuftragBemerkungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAuftragBemerkungen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpAuftragBemerkungen.Location = new System.Drawing.Point(6, 340);
            this.grpAuftragBemerkungen.Name = "grpAuftragBemerkungen";
            this.grpAuftragBemerkungen.Padding = new System.Windows.Forms.Padding(6);
            this.grpAuftragBemerkungen.Size = new System.Drawing.Size(698, 80);
            this.grpAuftragBemerkungen.TabIndex = 2;
            this.grpAuftragBemerkungen.TabStop = false;
            this.grpAuftragBemerkungen.Text = "Bemerkungen";
            this.grpAuftragBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtBemerkungen
            //
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtBemerkungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtBemerkungen.Location = new System.Drawing.Point(6, 20);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(686, 54);
            this.edtBemerkungen.TabIndex = 0;
            //
            // panTarifReduktion
            //
            this.panTarifReduktion.Controls.Add(this.grpReduktionen);
            this.panTarifReduktion.Controls.Add(this.panTarifReduktionSpacer);
            this.panTarifReduktion.Controls.Add(this.grpTarife);
            this.panTarifReduktion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTarifReduktion.Location = new System.Drawing.Point(6, 256);
            this.panTarifReduktion.Name = "panTarifReduktion";
            this.panTarifReduktion.Size = new System.Drawing.Size(698, 84);
            this.panTarifReduktion.TabIndex = 1;
            //
            // grpReduktionen
            //
            this.grpReduktionen.Controls.Add(this.edtReduktionCodes);
            this.grpReduktionen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReduktionen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpReduktionen.Location = new System.Drawing.Point(404, 0);
            this.grpReduktionen.Name = "grpReduktionen";
            this.grpReduktionen.Padding = new System.Windows.Forms.Padding(6);
            this.grpReduktionen.Size = new System.Drawing.Size(294, 84);
            this.grpReduktionen.TabIndex = 2;
            this.grpReduktionen.TabStop = false;
            this.grpReduktionen.Text = "Reduktionen";
            //
            // edtReduktionCodes
            //
            this.edtReduktionCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtReduktionCodes.Appearance.Options.UseBackColor = true;
            this.edtReduktionCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtReduktionCodes.CheckOnClick = true;
            this.edtReduktionCodes.DataMember = "ReduktionenCodes";
            this.edtReduktionCodes.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtReduktionCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtReduktionCodes.Location = new System.Drawing.Point(6, 20);
            this.edtReduktionCodes.MultiColumn = true;
            this.edtReduktionCodes.Name = "edtReduktionCodes";
            this.edtReduktionCodes.Size = new System.Drawing.Size(282, 58);
            this.edtReduktionCodes.TabIndex = 0;
            //
            // panTarifReduktionSpacer
            //
            this.panTarifReduktionSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTarifReduktionSpacer.Location = new System.Drawing.Point(398, 0);
            this.panTarifReduktionSpacer.Name = "panTarifReduktionSpacer";
            this.panTarifReduktionSpacer.Size = new System.Drawing.Size(6, 84);
            this.panTarifReduktionSpacer.TabIndex = 1;
            //
            // grpTarife
            //
            this.grpTarife.Controls.Add(this.edtTarifZuschlag);
            this.grpTarife.Controls.Add(this.lblTarifZuschlag);
            this.grpTarife.Controls.Add(this.edtTarifNacht);
            this.grpTarife.Controls.Add(this.lblTarifNacht);
            this.grpTarife.Controls.Add(this.edtTarifTag);
            this.grpTarife.Controls.Add(this.lblTarifTag);
            this.grpTarife.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTarife.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpTarife.Location = new System.Drawing.Point(0, 0);
            this.grpTarife.Name = "grpTarife";
            this.grpTarife.Size = new System.Drawing.Size(398, 84);
            this.grpTarife.TabIndex = 0;
            this.grpTarife.TabStop = false;
            this.grpTarife.Text = "Tarife";
            this.grpTarife.UseCompatibleTextRendering = true;
            //
            // edtTarifZuschlag
            //
            this.edtTarifZuschlag.DataMember = "TarifZuschlag";
            this.edtTarifZuschlag.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtTarifZuschlag.Location = new System.Drawing.Point(293, 19);
            this.edtTarifZuschlag.Name = "edtTarifZuschlag";
            this.edtTarifZuschlag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTarifZuschlag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTarifZuschlag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTarifZuschlag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTarifZuschlag.Properties.Appearance.Options.UseBackColor = true;
            this.edtTarifZuschlag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTarifZuschlag.Properties.Appearance.Options.UseFont = true;
            this.edtTarifZuschlag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTarifZuschlag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTarifZuschlag.Properties.DisplayFormat.FormatString = "C";
            this.edtTarifZuschlag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTarifZuschlag.Properties.EditFormat.FormatString = "C";
            this.edtTarifZuschlag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTarifZuschlag.Properties.Mask.EditMask = "C";
            this.edtTarifZuschlag.Size = new System.Drawing.Size(90, 24);
            this.edtTarifZuschlag.TabIndex = 5;
            //
            // lblTarifZuschlag
            //
            this.lblTarifZuschlag.Location = new System.Drawing.Point(212, 19);
            this.lblTarifZuschlag.Name = "lblTarifZuschlag";
            this.lblTarifZuschlag.Size = new System.Drawing.Size(75, 24);
            this.lblTarifZuschlag.TabIndex = 4;
            this.lblTarifZuschlag.Text = "Zuschlag";
            this.lblTarifZuschlag.UseCompatibleTextRendering = true;
            //
            // edtTarifNacht
            //
            this.edtTarifNacht.DataMember = "TarifNacht";
            this.edtTarifNacht.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtTarifNacht.Location = new System.Drawing.Point(103, 49);
            this.edtTarifNacht.Name = "edtTarifNacht";
            this.edtTarifNacht.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTarifNacht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTarifNacht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTarifNacht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTarifNacht.Properties.Appearance.Options.UseBackColor = true;
            this.edtTarifNacht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTarifNacht.Properties.Appearance.Options.UseFont = true;
            this.edtTarifNacht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTarifNacht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTarifNacht.Properties.DisplayFormat.FormatString = "C";
            this.edtTarifNacht.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTarifNacht.Properties.EditFormat.FormatString = "C";
            this.edtTarifNacht.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTarifNacht.Properties.Mask.EditMask = "C";
            this.edtTarifNacht.Size = new System.Drawing.Size(90, 24);
            this.edtTarifNacht.TabIndex = 3;
            //
            // lblTarifNacht
            //
            this.lblTarifNacht.Location = new System.Drawing.Point(9, 49);
            this.lblTarifNacht.Name = "lblTarifNacht";
            this.lblTarifNacht.Size = new System.Drawing.Size(88, 24);
            this.lblTarifNacht.TabIndex = 2;
            this.lblTarifNacht.Text = "Nacht";
            this.lblTarifNacht.UseCompatibleTextRendering = true;
            //
            // edtTarifTag
            //
            this.edtTarifTag.DataMember = "TarifTag";
            this.edtTarifTag.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtTarifTag.Location = new System.Drawing.Point(103, 19);
            this.edtTarifTag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtTarifTag.Name = "edtTarifTag";
            this.edtTarifTag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTarifTag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTarifTag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTarifTag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTarifTag.Properties.Appearance.Options.UseBackColor = true;
            this.edtTarifTag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTarifTag.Properties.Appearance.Options.UseFont = true;
            this.edtTarifTag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTarifTag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTarifTag.Properties.DisplayFormat.FormatString = "C";
            this.edtTarifTag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTarifTag.Properties.EditFormat.FormatString = "C";
            this.edtTarifTag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtTarifTag.Properties.Mask.EditMask = "C";
            this.edtTarifTag.Size = new System.Drawing.Size(90, 24);
            this.edtTarifTag.TabIndex = 1;
            //
            // lblTarifTag
            //
            this.lblTarifTag.Location = new System.Drawing.Point(9, 19);
            this.lblTarifTag.Name = "lblTarifTag";
            this.lblTarifTag.Size = new System.Drawing.Size(88, 24);
            this.lblTarifTag.TabIndex = 0;
            this.lblTarifTag.Text = "Tag (pro Std.)";
            this.lblTarifTag.UseCompatibleTextRendering = true;
            //
            // grpAuftrag
            //
            this.grpAuftrag.Controls.Add(this.edtAuftrag);
            this.grpAuftrag.Controls.Add(this.lblVereinbarteEinsatzzeiten);
            this.grpAuftrag.Controls.Add(this.edtVereinbarteEinsatzzeiten);
            this.grpAuftrag.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAuftrag.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpAuftrag.Location = new System.Drawing.Point(6, 6);
            this.grpAuftrag.Name = "grpAuftrag";
            this.grpAuftrag.Padding = new System.Windows.Forms.Padding(6);
            this.grpAuftrag.Size = new System.Drawing.Size(698, 250);
            this.grpAuftrag.TabIndex = 0;
            this.grpAuftrag.TabStop = false;
            this.grpAuftrag.Text = "Auftrag (was, wo)";
            this.grpAuftrag.UseCompatibleTextRendering = true;
            //
            // edtAuftrag
            //
            this.edtAuftrag.BackColor = System.Drawing.Color.White;
            this.edtAuftrag.DataMember = "Auftrag";
            this.edtAuftrag.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtAuftrag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtAuftrag.Font = new System.Drawing.Font("Arial", 10F);
            this.edtAuftrag.Location = new System.Drawing.Point(6, 20);
            this.edtAuftrag.Name = "edtAuftrag";
            this.edtAuftrag.Size = new System.Drawing.Size(686, 102);
            this.edtAuftrag.TabIndex = 0;
            //
            // lblVereinbarteEinsatzzeiten
            //
            this.lblVereinbarteEinsatzzeiten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblVereinbarteEinsatzzeiten.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVereinbarteEinsatzzeiten.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblVereinbarteEinsatzzeiten.Location = new System.Drawing.Point(6, 122);
            this.lblVereinbarteEinsatzzeiten.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblVereinbarteEinsatzzeiten.Name = "lblVereinbarteEinsatzzeiten";
            this.lblVereinbarteEinsatzzeiten.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblVereinbarteEinsatzzeiten.Size = new System.Drawing.Size(686, 32);
            this.lblVereinbarteEinsatzzeiten.TabIndex = 1;
            this.lblVereinbarteEinsatzzeiten.Text = "Vereinbarte Einsatzzeiten";
            this.lblVereinbarteEinsatzzeiten.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblVereinbarteEinsatzzeiten.UseCompatibleTextRendering = true;
            //
            // edtVereinbarteEinsatzzeiten
            //
            this.edtVereinbarteEinsatzzeiten.DataMember = "VereinbarteEinsatzzeiten";
            this.edtVereinbarteEinsatzzeiten.DataSource = this.qryEdEinsatzvereinbarung;
            this.edtVereinbarteEinsatzzeiten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtVereinbarteEinsatzzeiten.Location = new System.Drawing.Point(6, 154);
            this.edtVereinbarteEinsatzzeiten.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtVereinbarteEinsatzzeiten.Name = "edtVereinbarteEinsatzzeiten";
            this.edtVereinbarteEinsatzzeiten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVereinbarteEinsatzzeiten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVereinbarteEinsatzzeiten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVereinbarteEinsatzzeiten.Properties.Appearance.Options.UseBackColor = true;
            this.edtVereinbarteEinsatzzeiten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVereinbarteEinsatzzeiten.Properties.Appearance.Options.UseFont = true;
            this.edtVereinbarteEinsatzzeiten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVereinbarteEinsatzzeiten.Size = new System.Drawing.Size(686, 90);
            this.edtVereinbarteEinsatzzeiten.TabIndex = 2;
            //
            // CtlEdEinsatzvereinbarung
            //
            this.ActiveSQLQuery = this.qryEdEinsatzvereinbarung;
            this.AutoRefresh = false;
            this.Controls.Add(this.tabEinsatzvereinbarung);
            this.Controls.Add(this.panTopData);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlEdEinsatzvereinbarung";
            this.Size = new System.Drawing.Size(722, 596);
            this.Load += new System.EventHandler(this.CtlEdEinsatzvereinbarung_Load);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.panTopData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtErsterEinsatzAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdEinsatzvereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErsterEinsatzAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellungEV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellungEV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnlass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnlass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnlass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).EndInit();
            this.tabEinsatzvereinbarung.ResumeLayout(false);
            this.tpgAuftrag.ResumeLayout(false);
            this.grpAuftragBemerkungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            this.panTarifReduktion.ResumeLayout(false);
            this.grpReduktionen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtReduktionCodes)).EndInit();
            this.grpTarife.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTarifZuschlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarifZuschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTarifNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarifNacht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTarifTag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarifTag)).EndInit();
            this.grpAuftrag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarteEinsatzzeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbarteEinsatzzeiten.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Dokument.KissDocumentButton docEinsatzvereinbarung;
        private KiSS4.Gui.KissLookUpEdit edtAnlass;
        private KiSS4.Gui.KissRTFEdit edtAuftrag;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissDateEdit edtErstellungEV;
        private KiSS4.Gui.KissDateEdit edtErsterEinsatzAm;
        private KiSS4.Gui.KissCheckedLookupEdit edtReduktionCodes;
        private KiSS4.Gui.KissCalcEdit edtTarifNacht;
        private KiSS4.Gui.KissCalcEdit edtTarifTag;
        private KiSS4.Gui.KissCalcEdit edtTarifZuschlag;
        private KiSS4.Gui.KissLookUpEdit edtTyp;
        private KiSS4.Gui.KissMemoEdit edtVereinbarteEinsatzzeiten;
        private KiSS4.Gui.KissTextEdit edtZustaendigED;
        private KiSS4.Gui.KissGroupBox grpAuftrag;
        private KiSS4.Gui.KissGroupBox grpAuftragBemerkungen;
        private KiSS4.Gui.KissGroupBox grpReduktionen;
        private KiSS4.Gui.KissGroupBox grpTarife;
        private KiSS4.Gui.KissLabel lblAnlass;
        private KiSS4.Gui.KissLabel lblErstellungEV;
        private KiSS4.Gui.KissLabel lblErsterEinsatzAm;
        private KiSS4.Gui.KissLabel lblTarifNacht;
        private KiSS4.Gui.KissLabel lblTarifTag;
        private KiSS4.Gui.KissLabel lblTarifZuschlag;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTyp;
        private KiSS4.Gui.KissLabel lblVereinbarteEinsatzzeiten;
        private KiSS4.Gui.KissLabel lblZustaendigED;
        private Panel panTarifReduktion;
        private Panel panTarifReduktionSpacer;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.Panel panTopData;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryEdEinsatzvereinbarung;
        private KiSS4.Gui.KissTabControlEx tabEinsatzvereinbarung;
        private SharpLibrary.WinControls.TabPageEx tpgAuftrag;
        private SharpLibrary.WinControls.TabPageEx tpgEntlaster;
    }
}
