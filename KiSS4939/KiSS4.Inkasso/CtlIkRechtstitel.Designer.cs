namespace KiSS4.Inkasso
{
    public partial class CtlIkRechtstitel
    {
        #region Fields

        #region Private Fields

        private System.ComponentModel.IContainer components;
        private KiSS4.Inkasso.CtlIkGlaeubiger ctlIkGlaeubiger;
        private KiSS4.Inkasso.CtlIkRechtstitelForderung ctlIkRechtstitelForderung;
        private KiSS4.Inkasso.CtlIkEinkommen ctlIkEinkommen;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtBezugKinderzulagenCode;
        private KiSS4.Gui.KissMemoEdit edtElterlicheSorgeBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtElterlicheVertretung;
        private KiSS4.Gui.KissLookUpEdit edtIkElterlicheSorgeCode;
        private KiSS4.Gui.KissLookUpEdit edtIkIndexRundenCode;
        private KiSS4.Gui.KissLookUpEdit edtIkIndexTypCode;
        private KiSS4.Gui.KissDateEdit edtIkRechtstitelGueltigBis;
        private KiSS4.Gui.KissDateEdit edtIkRechtstitelGueltigVon;
        private KiSS4.Gui.KissLookUpEdit edtIkRechtstitelTypCode;
        private KiSS4.Gui.KissTextEdit edtIndexStandPunkte;
        private KiSS4.Gui.KissDateEdit edtIndexStandVom;
        private KiSS4.Gui.KissMemoEdit edtInfodesRechtstitel;
        private KiSS4.Gui.KissDateEdit edtRechtstitelDatumVon;
        private KiSS4.Gui.KissDateEdit edtRechtstitelRechtskraeftig;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblBezugKinderzulagenCode;
        private KiSS4.Gui.KissLabel lblElterlicheSorgeBemerkung;
        private KiSS4.Gui.KissLabel lblElterlicheSorgeCode;
        private KiSS4.Gui.KissLabel lblElterlicheVertretung;
        private KiSS4.Gui.KissLabel lblIkIndexTypCode;
        private KiSS4.Gui.KissLabel lblIkRechtstitelCode;
        private KiSS4.Gui.KissLabel lblIkRechtstitelGueltigBis;
        private KiSS4.Gui.KissLabel lblIkRechtstitelGueltigVon;
        private KiSS4.Gui.KissLabel lblIndexRundenCode;
        private KiSS4.Gui.KissLabel lblIndexStandPunkte;
        private KiSS4.Gui.KissLabel lblIndexStandVom;
        private KiSS4.Gui.KissLabel lblInfodesRechtstitel;
        private KiSS4.Gui.KissLabel lblRechtstitelDatumVon;
        private KiSS4.Gui.KissLabel lblRechtstitelRechtskraeftig;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblWeiteres;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryIkRechtstitel;
        private KiSS4.DB.SqlQuery qryPerson;
        private KiSS4.Gui.KissTabControlEx tabRechtstitel;
        private SharpLibrary.WinControls.TabPageEx tbpForderung;
        private SharpLibrary.WinControls.TabPageEx tbpGlaeubiger;
        private SharpLibrary.WinControls.TabPageEx tbpRechtstitel;
        private SharpLibrary.WinControls.TabPageEx tbpEinkommen;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkRechtstitel));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tabRechtstitel = new KiSS4.Gui.KissTabControlEx();
            this.tbpRechtstitel = new SharpLibrary.WinControls.TabPageEx();
            this.edtIkElterlicheSorgeCode = new KiSS4.Gui.KissLookUpEdit();
            this.qryIkRechtstitel = new KiSS4.DB.SqlQuery();
            this.lblElterlicheSorgeCode = new KiSS4.Gui.KissLabel();
            this.edtElterlicheVertretung = new KiSS4.Gui.KissLookUpEdit();
            this.lblWeiteres = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblIkRechtstitelGueltigBis = new KiSS4.Gui.KissLabel();
            this.lblIkRechtstitelGueltigVon = new KiSS4.Gui.KissLabel();
            this.lblElterlicheVertretung = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblInfodesRechtstitel = new KiSS4.Gui.KissLabel();
            this.lblElterlicheSorgeBemerkung = new KiSS4.Gui.KissLabel();
            this.lblBezugKinderzulagenCode = new KiSS4.Gui.KissLabel();
            this.lblIndexRundenCode = new KiSS4.Gui.KissLabel();
            this.lblIndexStandVom = new KiSS4.Gui.KissLabel();
            this.edtElterlicheSorgeBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblIndexStandPunkte = new KiSS4.Gui.KissLabel();
            this.edtBezugKinderzulagenCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblIkIndexTypCode = new KiSS4.Gui.KissLabel();
            this.edtIkIndexRundenCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblRechtstitelRechtskraeftig = new KiSS4.Gui.KissLabel();
            this.edtIndexStandPunkte = new KiSS4.Gui.KissTextEdit();
            this.edtIndexStandVom = new KiSS4.Gui.KissDateEdit();
            this.lblRechtstitelDatumVon = new KiSS4.Gui.KissLabel();
            this.edtIkIndexTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtInfodesRechtstitel = new KiSS4.Gui.KissMemoEdit();
            this.lblIkRechtstitelCode = new KiSS4.Gui.KissLabel();
            this.edtRechtstitelRechtskraeftig = new KiSS4.Gui.KissDateEdit();
            this.edtRechtstitelDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtIkRechtstitelTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkRechtstitelGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.edtIkRechtstitelGueltigVon = new KiSS4.Gui.KissDateEdit();
            this.tbpGlaeubiger = new SharpLibrary.WinControls.TabPageEx();
            this.ctlIkGlaeubiger = new KiSS4.Inkasso.CtlIkGlaeubiger();
            this.ctlIkRechtstitelForderung = new KiSS4.Inkasso.CtlIkRechtstitelForderung();
            this.tbpForderung = new SharpLibrary.WinControls.TabPageEx();
            this.qryPerson = new KiSS4.DB.SqlQuery();
            this.tbpEinkommen = new SharpLibrary.WinControls.TabPageEx();
            this.ctlIkEinkommen = new KiSS4.Inkasso.CtlIkEinkommen();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tabRechtstitel.SuspendLayout();
            this.tbpRechtstitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkElterlicheSorgeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkElterlicheSorgeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkRechtstitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiteres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheVertretung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfodesRechtstitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezugKinderzulagenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexRundenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandVom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandPunkte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugKinderzulagenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugKinderzulagenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkIndexTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexRundenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexRundenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelRechtskraeftig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandPunkte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandVom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfodesRechtstitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelRechtskraeftig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigVon.Properties)).BeginInit();
            this.tbpGlaeubiger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitle);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 24);
            this.panel1.TabIndex = 30;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(5, 5);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 293;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Rechtstitel Unterhaltspflicht";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // tabRechtstitel
            // 
            this.tabRechtstitel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRechtstitel.Controls.Add(this.tbpRechtstitel);
            this.tabRechtstitel.Controls.Add(this.tbpGlaeubiger);
            this.tabRechtstitel.Controls.Add(this.tbpForderung);
            this.tabRechtstitel.Controls.Add(this.tbpEinkommen);
            this.tabRechtstitel.Location = new System.Drawing.Point(0, 45);
            this.tabRechtstitel.Name = "tabRechtstitel";
            this.tabRechtstitel.ShowFixedWidthTooltip = true;
            this.tabRechtstitel.Size = new System.Drawing.Size(696, 525);
            this.tabRechtstitel.TabIndex = 33;
            this.tabRechtstitel.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpRechtstitel,
            this.tbpGlaeubiger,
            this.tbpForderung,
            this.tbpEinkommen});
            this.tabRechtstitel.TabsLineColor = System.Drawing.Color.Black;
            this.tabRechtstitel.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabRechtstitel.Text = "kissTabControlEx1";
            this.tabRechtstitel.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabRechtstitel_SelectedTabChanged);
            this.tabRechtstitel.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabRechtstitel_SelectedTabChanging);
            // 
            // tbpRechtstitel
            // 
            this.tbpRechtstitel.Controls.Add(this.edtIkElterlicheSorgeCode);
            this.tbpRechtstitel.Controls.Add(this.lblElterlicheSorgeCode);
            this.tbpRechtstitel.Controls.Add(this.edtElterlicheVertretung);
            this.tbpRechtstitel.Controls.Add(this.lblWeiteres);
            this.tbpRechtstitel.Controls.Add(this.edtBemerkung);
            this.tbpRechtstitel.Controls.Add(this.lblIkRechtstitelGueltigBis);
            this.tbpRechtstitel.Controls.Add(this.lblIkRechtstitelGueltigVon);
            this.tbpRechtstitel.Controls.Add(this.lblElterlicheVertretung);
            this.tbpRechtstitel.Controls.Add(this.kissLabel4);
            this.tbpRechtstitel.Controls.Add(this.lblInfodesRechtstitel);
            this.tbpRechtstitel.Controls.Add(this.lblElterlicheSorgeBemerkung);
            this.tbpRechtstitel.Controls.Add(this.lblBezugKinderzulagenCode);
            this.tbpRechtstitel.Controls.Add(this.lblIndexRundenCode);
            this.tbpRechtstitel.Controls.Add(this.lblIndexStandVom);
            this.tbpRechtstitel.Controls.Add(this.edtElterlicheSorgeBemerkung);
            this.tbpRechtstitel.Controls.Add(this.lblIndexStandPunkte);
            this.tbpRechtstitel.Controls.Add(this.edtBezugKinderzulagenCode);
            this.tbpRechtstitel.Controls.Add(this.lblIkIndexTypCode);
            this.tbpRechtstitel.Controls.Add(this.edtIkIndexRundenCode);
            this.tbpRechtstitel.Controls.Add(this.lblRechtstitelRechtskraeftig);
            this.tbpRechtstitel.Controls.Add(this.edtIndexStandPunkte);
            this.tbpRechtstitel.Controls.Add(this.edtIndexStandVom);
            this.tbpRechtstitel.Controls.Add(this.lblRechtstitelDatumVon);
            this.tbpRechtstitel.Controls.Add(this.edtIkIndexTypCode);
            this.tbpRechtstitel.Controls.Add(this.edtInfodesRechtstitel);
            this.tbpRechtstitel.Controls.Add(this.lblIkRechtstitelCode);
            this.tbpRechtstitel.Controls.Add(this.edtRechtstitelRechtskraeftig);
            this.tbpRechtstitel.Controls.Add(this.edtRechtstitelDatumVon);
            this.tbpRechtstitel.Controls.Add(this.edtIkRechtstitelTypCode);
            this.tbpRechtstitel.Controls.Add(this.edtIkRechtstitelGueltigBis);
            this.tbpRechtstitel.Controls.Add(this.edtIkRechtstitelGueltigVon);
            this.tbpRechtstitel.Location = new System.Drawing.Point(6, 6);
            this.tbpRechtstitel.Name = "tbpRechtstitel";
            this.tbpRechtstitel.Size = new System.Drawing.Size(684, 487);
            this.tbpRechtstitel.TabIndex = 0;
            this.tbpRechtstitel.Title = "Rechtstitel";
            // 
            // edtIkElterlicheSorgeCode
            // 
            this.edtIkElterlicheSorgeCode.DataMember = "IkElterlicheSorgeCode";
            this.edtIkElterlicheSorgeCode.DataSource = this.qryIkRechtstitel;
            this.edtIkElterlicheSorgeCode.Location = new System.Drawing.Point(123, 375);
            this.edtIkElterlicheSorgeCode.LOVName = "IkElterlicheSorge";
            this.edtIkElterlicheSorgeCode.Name = "edtIkElterlicheSorgeCode";
            this.edtIkElterlicheSorgeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkElterlicheSorgeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkElterlicheSorgeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkElterlicheSorgeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkElterlicheSorgeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkElterlicheSorgeCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkElterlicheSorgeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkElterlicheSorgeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkElterlicheSorgeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkElterlicheSorgeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkElterlicheSorgeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtIkElterlicheSorgeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtIkElterlicheSorgeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkElterlicheSorgeCode.Properties.ShowFooter = false;
            this.edtIkElterlicheSorgeCode.Properties.ShowHeader = false;
            this.edtIkElterlicheSorgeCode.Size = new System.Drawing.Size(267, 24);
            this.edtIkElterlicheSorgeCode.TabIndex = 49;
            // 
            // qryIkRechtstitel
            // 
            this.qryIkRechtstitel.CanUpdate = true;
            this.qryIkRechtstitel.HostControl = this;
            this.qryIkRechtstitel.SelectStatement = resources.GetString("qryIkRechtstitel.SelectStatement");
            this.qryIkRechtstitel.TableName = "IkRechtstitel";
            this.qryIkRechtstitel.AfterFill += new System.EventHandler(this.qryIkRechtstitel_AfterFill);
            this.qryIkRechtstitel.AfterInsert += new System.EventHandler(this.qryIkRechtstitel_AfterInsert);
            this.qryIkRechtstitel.AfterPost += new System.EventHandler(this.qryIkRechtstitel_AfterPost);
            this.qryIkRechtstitel.BeforePost += new System.EventHandler(this.qryIkRechtstitel_BeforePost);
            this.qryIkRechtstitel.PositionChanged += new System.EventHandler(this.qryIkRechtstitel_PositionChanged);
            // 
            // lblElterlicheSorgeCode
            // 
            this.lblElterlicheSorgeCode.Location = new System.Drawing.Point(8, 375);
            this.lblElterlicheSorgeCode.Name = "lblElterlicheSorgeCode";
            this.lblElterlicheSorgeCode.Size = new System.Drawing.Size(105, 24);
            this.lblElterlicheSorgeCode.TabIndex = 48;
            this.lblElterlicheSorgeCode.Text = "Elterliche Sorge";
            this.lblElterlicheSorgeCode.UseCompatibleTextRendering = true;
            // 
            // edtElterlicheVertretung
            // 
            this.edtElterlicheVertretung.DataMember = "BaPersonID";
            this.edtElterlicheVertretung.DataSource = this.qryIkRechtstitel;
            this.edtElterlicheVertretung.Location = new System.Drawing.Point(123, 435);
            this.edtElterlicheVertretung.Name = "edtElterlicheVertretung";
            this.edtElterlicheVertretung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtElterlicheVertretung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtElterlicheVertretung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheVertretung.Properties.Appearance.Options.UseBackColor = true;
            this.edtElterlicheVertretung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtElterlicheVertretung.Properties.Appearance.Options.UseFont = true;
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtElterlicheVertretung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtElterlicheVertretung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtElterlicheVertretung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtElterlicheVertretung.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtElterlicheVertretung.Properties.DisplayMember = "Text";
            this.edtElterlicheVertretung.Properties.ShowFooter = false;
            this.edtElterlicheVertretung.Properties.ShowHeader = false;
            this.edtElterlicheVertretung.Properties.ValueMember = "BaPersonID";
            this.edtElterlicheVertretung.Size = new System.Drawing.Size(267, 24);
            this.edtElterlicheVertretung.TabIndex = 16;
            // 
            // lblWeiteres
            // 
            this.lblWeiteres.Location = new System.Drawing.Point(427, 170);
            this.lblWeiteres.Name = "lblWeiteres";
            this.lblWeiteres.Size = new System.Drawing.Size(254, 24);
            this.lblWeiteres.TabIndex = 47;
            this.lblWeiteres.Text = "Details zu den Forderungen";
            this.lblWeiteres.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryIkRechtstitel;
            this.edtBemerkung.Location = new System.Drawing.Point(427, 200);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(254, 120);
            this.edtBemerkung.TabIndex = 46;
            // 
            // lblIkRechtstitelGueltigBis
            // 
            this.lblIkRechtstitelGueltigBis.Location = new System.Drawing.Point(239, 15);
            this.lblIkRechtstitelGueltigBis.Name = "lblIkRechtstitelGueltigBis";
            this.lblIkRechtstitelGueltigBis.Size = new System.Drawing.Size(53, 24);
            this.lblIkRechtstitelGueltigBis.TabIndex = 45;
            this.lblIkRechtstitelGueltigBis.Text = "Gültig bis";
            this.lblIkRechtstitelGueltigBis.UseCompatibleTextRendering = true;
            // 
            // lblIkRechtstitelGueltigVon
            // 
            this.lblIkRechtstitelGueltigVon.Location = new System.Drawing.Point(8, 15);
            this.lblIkRechtstitelGueltigVon.Name = "lblIkRechtstitelGueltigVon";
            this.lblIkRechtstitelGueltigVon.Size = new System.Drawing.Size(91, 24);
            this.lblIkRechtstitelGueltigVon.TabIndex = 43;
            this.lblIkRechtstitelGueltigVon.Text = "Erfasst am";
            this.lblIkRechtstitelGueltigVon.UseCompatibleTextRendering = true;
            // 
            // lblElterlicheVertretung
            // 
            this.lblElterlicheVertretung.Location = new System.Drawing.Point(8, 435);
            this.lblElterlicheVertretung.Name = "lblElterlicheVertretung";
            this.lblElterlicheVertretung.Size = new System.Drawing.Size(125, 24);
            this.lblElterlicheVertretung.TabIndex = 39;
            this.lblElterlicheVertretung.Text = "Gesetzlicher Vertreter";
            this.lblElterlicheVertretung.UseCompatibleTextRendering = true;
            // 
            // kissLabel4
            // 
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel4.Location = new System.Drawing.Point(123, 168);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(100, 16);
            this.kissLabel4.TabIndex = 37;
            this.kissLabel4.Text = "Indexierung";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // lblInfodesRechtstitel
            // 
            this.lblInfodesRechtstitel.Location = new System.Drawing.Point(427, 12);
            this.lblInfodesRechtstitel.Name = "lblInfodesRechtstitel";
            this.lblInfodesRechtstitel.Size = new System.Drawing.Size(254, 24);
            this.lblInfodesRechtstitel.TabIndex = 36;
            this.lblInfodesRechtstitel.Text = "Info / Gericht, Rechtstitel";
            this.lblInfodesRechtstitel.UseCompatibleTextRendering = true;
            // 
            // lblElterlicheSorgeBemerkung
            // 
            this.lblElterlicheSorgeBemerkung.Location = new System.Drawing.Point(427, 329);
            this.lblElterlicheSorgeBemerkung.Name = "lblElterlicheSorgeBemerkung";
            this.lblElterlicheSorgeBemerkung.Size = new System.Drawing.Size(254, 24);
            this.lblElterlicheSorgeBemerkung.TabIndex = 35;
            this.lblElterlicheSorgeBemerkung.Text = "Elterliche Sorge, Elterliche Vertretung";
            this.lblElterlicheSorgeBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblBezugKinderzulagenCode
            // 
            this.lblBezugKinderzulagenCode.Location = new System.Drawing.Point(8, 405);
            this.lblBezugKinderzulagenCode.Name = "lblBezugKinderzulagenCode";
            this.lblBezugKinderzulagenCode.Size = new System.Drawing.Size(107, 24);
            this.lblBezugKinderzulagenCode.TabIndex = 26;
            this.lblBezugKinderzulagenCode.Text = "Bezug Kinderzulagen";
            this.lblBezugKinderzulagenCode.UseCompatibleTextRendering = true;
            // 
            // lblIndexRundenCode
            // 
            this.lblIndexRundenCode.Location = new System.Drawing.Point(8, 296);
            this.lblIndexRundenCode.Name = "lblIndexRundenCode";
            this.lblIndexRundenCode.Size = new System.Drawing.Size(105, 24);
            this.lblIndexRundenCode.TabIndex = 23;
            this.lblIndexRundenCode.Text = "Rundungsformel";
            this.lblIndexRundenCode.UseCompatibleTextRendering = true;
            // 
            // lblIndexStandVom
            // 
            this.lblIndexStandVom.Location = new System.Drawing.Point(8, 223);
            this.lblIndexStandVom.Name = "lblIndexStandVom";
            this.lblIndexStandVom.Size = new System.Drawing.Size(88, 24);
            this.lblIndexStandVom.TabIndex = 17;
            this.lblIndexStandVom.Text = "Indexstand vom";
            this.lblIndexStandVom.UseCompatibleTextRendering = true;
            // 
            // edtElterlicheSorgeBemerkung
            // 
            this.edtElterlicheSorgeBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtElterlicheSorgeBemerkung.DataMember = "ElterlicheSorgeBemerkung";
            this.edtElterlicheSorgeBemerkung.DataSource = this.qryIkRechtstitel;
            this.edtElterlicheSorgeBemerkung.Location = new System.Drawing.Point(427, 356);
            this.edtElterlicheSorgeBemerkung.Name = "edtElterlicheSorgeBemerkung";
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtElterlicheSorgeBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtElterlicheSorgeBemerkung.Size = new System.Drawing.Size(254, 120);
            this.edtElterlicheSorgeBemerkung.TabIndex = 17;
            // 
            // lblIndexStandPunkte
            // 
            this.lblIndexStandPunkte.Location = new System.Drawing.Point(248, 221);
            this.lblIndexStandPunkte.Name = "lblIndexStandPunkte";
            this.lblIndexStandPunkte.Size = new System.Drawing.Size(46, 24);
            this.lblIndexStandPunkte.TabIndex = 15;
            this.lblIndexStandPunkte.Text = " Punkte";
            this.lblIndexStandPunkte.UseCompatibleTextRendering = true;
            // 
            // edtBezugKinderzulagenCode
            // 
            this.edtBezugKinderzulagenCode.DataMember = "IkBezugKinderzulagenCode";
            this.edtBezugKinderzulagenCode.DataSource = this.qryIkRechtstitel;
            this.edtBezugKinderzulagenCode.Location = new System.Drawing.Point(123, 405);
            this.edtBezugKinderzulagenCode.LOVName = "IkBezugKinderzulagen";
            this.edtBezugKinderzulagenCode.Name = "edtBezugKinderzulagenCode";
            this.edtBezugKinderzulagenCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezugKinderzulagenCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezugKinderzulagenCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezugKinderzulagenCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezugKinderzulagenCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezugKinderzulagenCode.Properties.Appearance.Options.UseFont = true;
            this.edtBezugKinderzulagenCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBezugKinderzulagenCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezugKinderzulagenCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBezugKinderzulagenCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBezugKinderzulagenCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtBezugKinderzulagenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtBezugKinderzulagenCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezugKinderzulagenCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBezugKinderzulagenCode.Properties.DisplayMember = "Text";
            this.edtBezugKinderzulagenCode.Properties.DropDownRows = 1;
            this.edtBezugKinderzulagenCode.Properties.ShowFooter = false;
            this.edtBezugKinderzulagenCode.Properties.ShowHeader = false;
            this.edtBezugKinderzulagenCode.Properties.ValueMember = "Code";
            this.edtBezugKinderzulagenCode.Size = new System.Drawing.Size(267, 24);
            this.edtBezugKinderzulagenCode.TabIndex = 15;
            // 
            // lblIkIndexTypCode
            // 
            this.lblIkIndexTypCode.Location = new System.Drawing.Point(8, 191);
            this.lblIkIndexTypCode.Name = "lblIkIndexTypCode";
            this.lblIkIndexTypCode.Size = new System.Drawing.Size(81, 24);
            this.lblIkIndexTypCode.TabIndex = 14;
            this.lblIkIndexTypCode.Text = "Basierend auf ";
            this.lblIkIndexTypCode.UseCompatibleTextRendering = true;
            // 
            // edtIkIndexRundenCode
            // 
            this.edtIkIndexRundenCode.DataMember = "IkIndexRundenCode";
            this.edtIkIndexRundenCode.DataSource = this.qryIkRechtstitel;
            this.edtIkIndexRundenCode.Location = new System.Drawing.Point(123, 294);
            this.edtIkIndexRundenCode.LOVName = "IkIndexRunden";
            this.edtIkIndexRundenCode.Name = "edtIkIndexRundenCode";
            this.edtIkIndexRundenCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkIndexRundenCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkIndexRundenCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkIndexRundenCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkIndexRundenCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkIndexRundenCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkIndexRundenCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkIndexRundenCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkIndexRundenCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkIndexRundenCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkIndexRundenCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtIkIndexRundenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtIkIndexRundenCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkIndexRundenCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtIkIndexRundenCode.Properties.DisplayMember = "Text";
            this.edtIkIndexRundenCode.Properties.DropDownRows = 1;
            this.edtIkIndexRundenCode.Properties.ShowFooter = false;
            this.edtIkIndexRundenCode.Properties.ShowHeader = false;
            this.edtIkIndexRundenCode.Properties.ValueMember = "Code";
            this.edtIkIndexRundenCode.Size = new System.Drawing.Size(267, 24);
            this.edtIkIndexRundenCode.TabIndex = 13;
            // 
            // lblRechtstitelRechtskraeftig
            // 
            this.lblRechtstitelRechtskraeftig.Location = new System.Drawing.Point(8, 119);
            this.lblRechtstitelRechtskraeftig.Name = "lblRechtstitelRechtskraeftig";
            this.lblRechtstitelRechtskraeftig.Size = new System.Drawing.Size(88, 24);
            this.lblRechtstitelRechtskraeftig.TabIndex = 11;
            this.lblRechtstitelRechtskraeftig.Text = "Rechtskräftig ab";
            this.lblRechtstitelRechtskraeftig.UseCompatibleTextRendering = true;
            // 
            // edtIndexStandPunkte
            // 
            this.edtIndexStandPunkte.DataMember = "IndexStandPunkte";
            this.edtIndexStandPunkte.DataSource = this.qryIkRechtstitel;
            this.edtIndexStandPunkte.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIndexStandPunkte.Location = new System.Drawing.Point(300, 221);
            this.edtIndexStandPunkte.Name = "edtIndexStandPunkte";
            this.edtIndexStandPunkte.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIndexStandPunkte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexStandPunkte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexStandPunkte.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexStandPunkte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexStandPunkte.Properties.Appearance.Options.UseFont = true;
            this.edtIndexStandPunkte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIndexStandPunkte.Properties.ReadOnly = true;
            this.edtIndexStandPunkte.Size = new System.Drawing.Size(90, 24);
            this.edtIndexStandPunkte.TabIndex = 10;
            this.edtIndexStandPunkte.TabStop = false;
            // 
            // edtIndexStandVom
            // 
            this.edtIndexStandVom.DataMember = "IndexStandVom";
            this.edtIndexStandVom.DataSource = this.qryIkRechtstitel;
            this.edtIndexStandVom.EditValue = null;
            this.edtIndexStandVom.Location = new System.Drawing.Point(123, 223);
            this.edtIndexStandVom.Name = "edtIndexStandVom";
            this.edtIndexStandVom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIndexStandVom.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIndexStandVom.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexStandVom.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexStandVom.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexStandVom.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexStandVom.Properties.Appearance.Options.UseFont = true;
            this.edtIndexStandVom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtIndexStandVom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIndexStandVom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtIndexStandVom.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIndexStandVom.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtIndexStandVom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtIndexStandVom.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtIndexStandVom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtIndexStandVom.Properties.Mask.EditMask = "MM.yyyy";
            this.edtIndexStandVom.Properties.ShowToday = false;
            this.edtIndexStandVom.Size = new System.Drawing.Size(97, 24);
            this.edtIndexStandVom.TabIndex = 9;
            this.edtIndexStandVom.EditValueChanged += new System.EventHandler(this.edtIndexStandVom_EditValueChanged);
            // 
            // lblRechtstitelDatumVon
            // 
            this.lblRechtstitelDatumVon.Location = new System.Drawing.Point(8, 90);
            this.lblRechtstitelDatumVon.Name = "lblRechtstitelDatumVon";
            this.lblRechtstitelDatumVon.Size = new System.Drawing.Size(100, 23);
            this.lblRechtstitelDatumVon.TabIndex = 8;
            this.lblRechtstitelDatumVon.Text = "Rechtstitel von";
            this.lblRechtstitelDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtIkIndexTypCode
            // 
            this.edtIkIndexTypCode.DataMember = "IkIndexTypCode";
            this.edtIkIndexTypCode.DataSource = this.qryIkRechtstitel;
            this.edtIkIndexTypCode.Location = new System.Drawing.Point(123, 191);
            this.edtIkIndexTypCode.LOVName = "IkIndexTyp";
            this.edtIkIndexTypCode.Name = "edtIkIndexTypCode";
            this.edtIkIndexTypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkIndexTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkIndexTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkIndexTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkIndexTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkIndexTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkIndexTypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkIndexTypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkIndexTypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkIndexTypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkIndexTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtIkIndexTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtIkIndexTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkIndexTypCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtIkIndexTypCode.Properties.DisplayMember = "Text";
            this.edtIkIndexTypCode.Properties.ShowFooter = false;
            this.edtIkIndexTypCode.Properties.ShowHeader = false;
            this.edtIkIndexTypCode.Properties.ValueMember = "Code";
            this.edtIkIndexTypCode.Size = new System.Drawing.Size(267, 24);
            this.edtIkIndexTypCode.TabIndex = 8;
            this.edtIkIndexTypCode.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtIkIndexTypCode_CloseUp);
            // 
            // edtInfodesRechtstitel
            // 
            this.edtInfodesRechtstitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInfodesRechtstitel.DataMember = "RechtstitelInfo";
            this.edtInfodesRechtstitel.DataSource = this.qryIkRechtstitel;
            this.edtInfodesRechtstitel.Location = new System.Drawing.Point(427, 39);
            this.edtInfodesRechtstitel.Name = "edtInfodesRechtstitel";
            this.edtInfodesRechtstitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInfodesRechtstitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInfodesRechtstitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInfodesRechtstitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtInfodesRechtstitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInfodesRechtstitel.Properties.Appearance.Options.UseFont = true;
            this.edtInfodesRechtstitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInfodesRechtstitel.Size = new System.Drawing.Size(254, 120);
            this.edtInfodesRechtstitel.TabIndex = 7;
            // 
            // lblIkRechtstitelCode
            // 
            this.lblIkRechtstitelCode.Location = new System.Drawing.Point(8, 59);
            this.lblIkRechtstitelCode.Name = "lblIkRechtstitelCode";
            this.lblIkRechtstitelCode.Size = new System.Drawing.Size(108, 24);
            this.lblIkRechtstitelCode.TabIndex = 5;
            this.lblIkRechtstitelCode.Text = "Rechtstitel Bez";
            this.lblIkRechtstitelCode.UseCompatibleTextRendering = true;
            // 
            // edtRechtstitelRechtskraeftig
            // 
            this.edtRechtstitelRechtskraeftig.DataMember = "RechtstitelRechtskraeftig";
            this.edtRechtstitelRechtskraeftig.DataSource = this.qryIkRechtstitel;
            this.edtRechtstitelRechtskraeftig.EditValue = null;
            this.edtRechtstitelRechtskraeftig.Location = new System.Drawing.Point(123, 119);
            this.edtRechtstitelRechtskraeftig.Name = "edtRechtstitelRechtskraeftig";
            this.edtRechtstitelRechtskraeftig.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Options.UseFont = true;
            this.edtRechtstitelRechtskraeftig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtRechtstitelRechtskraeftig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRechtstitelRechtskraeftig.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtRechtstitelRechtskraeftig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechtstitelRechtskraeftig.Properties.ShowToday = false;
            this.edtRechtstitelRechtskraeftig.Size = new System.Drawing.Size(97, 24);
            this.edtRechtstitelRechtskraeftig.TabIndex = 5;
            // 
            // edtRechtstitelDatumVon
            // 
            this.edtRechtstitelDatumVon.DataMember = "RechtstitelDatumVon";
            this.edtRechtstitelDatumVon.DataSource = this.qryIkRechtstitel;
            this.edtRechtstitelDatumVon.EditValue = null;
            this.edtRechtstitelDatumVon.Location = new System.Drawing.Point(123, 89);
            this.edtRechtstitelDatumVon.Name = "edtRechtstitelDatumVon";
            this.edtRechtstitelDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechtstitelDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechtstitelDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechtstitelDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechtstitelDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechtstitelDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechtstitelDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtRechtstitelDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtRechtstitelDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRechtstitelDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtRechtstitelDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechtstitelDatumVon.Properties.ShowToday = false;
            this.edtRechtstitelDatumVon.Size = new System.Drawing.Size(97, 24);
            this.edtRechtstitelDatumVon.TabIndex = 4;
            // 
            // edtIkRechtstitelTypCode
            // 
            this.edtIkRechtstitelTypCode.DataMember = "IkRechtstitelTypCode";
            this.edtIkRechtstitelTypCode.DataSource = this.qryIkRechtstitel;
            this.edtIkRechtstitelTypCode.Location = new System.Drawing.Point(123, 59);
            this.edtIkRechtstitelTypCode.LOVName = "IkRechtstitelTyp";
            this.edtIkRechtstitelTypCode.Name = "edtIkRechtstitelTypCode";
            this.edtIkRechtstitelTypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRechtstitelTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRechtstitelTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRechtstitelTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRechtstitelTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkRechtstitelTypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkRechtstitelTypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelTypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkRechtstitelTypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkRechtstitelTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtIkRechtstitelTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtIkRechtstitelTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRechtstitelTypCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtIkRechtstitelTypCode.Properties.DisplayMember = "Text";
            this.edtIkRechtstitelTypCode.Properties.DropDownRows = 1;
            this.edtIkRechtstitelTypCode.Properties.ShowFooter = false;
            this.edtIkRechtstitelTypCode.Properties.ShowHeader = false;
            this.edtIkRechtstitelTypCode.Properties.ValueMember = "Code";
            this.edtIkRechtstitelTypCode.Size = new System.Drawing.Size(267, 24);
            this.edtIkRechtstitelTypCode.TabIndex = 3;
            // 
            // edtIkRechtstitelGueltigBis
            // 
            this.edtIkRechtstitelGueltigBis.DataMember = "IkRechtstitelGueltigBis";
            this.edtIkRechtstitelGueltigBis.DataSource = this.qryIkRechtstitel;
            this.edtIkRechtstitelGueltigBis.EditValue = null;
            this.edtIkRechtstitelGueltigBis.Location = new System.Drawing.Point(296, 15);
            this.edtIkRechtstitelGueltigBis.Name = "edtIkRechtstitelGueltigBis";
            this.edtIkRechtstitelGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtIkRechtstitelGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIkRechtstitelGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtIkRechtstitelGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRechtstitelGueltigBis.Properties.ShowToday = false;
            this.edtIkRechtstitelGueltigBis.Size = new System.Drawing.Size(94, 24);
            this.edtIkRechtstitelGueltigBis.TabIndex = 2;
            // 
            // edtIkRechtstitelGueltigVon
            // 
            this.edtIkRechtstitelGueltigVon.DataMember = "IkRechtstitelGueltigVon";
            this.edtIkRechtstitelGueltigVon.DataSource = this.qryIkRechtstitel;
            this.edtIkRechtstitelGueltigVon.EditValue = null;
            this.edtIkRechtstitelGueltigVon.Location = new System.Drawing.Point(123, 15);
            this.edtIkRechtstitelGueltigVon.Name = "edtIkRechtstitelGueltigVon";
            this.edtIkRechtstitelGueltigVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Options.UseFont = true;
            this.edtIkRechtstitelGueltigVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIkRechtstitelGueltigVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtIkRechtstitelGueltigVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRechtstitelGueltigVon.Properties.ShowToday = false;
            this.edtIkRechtstitelGueltigVon.Size = new System.Drawing.Size(95, 24);
            this.edtIkRechtstitelGueltigVon.TabIndex = 1;
            // 
            // tbpGlaeubiger
            // 
            this.tbpGlaeubiger.Controls.Add(this.ctlIkGlaeubiger);
            this.tbpGlaeubiger.Location = new System.Drawing.Point(6, 6);
            this.tbpGlaeubiger.Name = "tbpGlaeubiger";
            this.tbpGlaeubiger.Size = new System.Drawing.Size(684, 487);
            this.tbpGlaeubiger.TabIndex = 1;
            this.tbpGlaeubiger.Title = "Gläubiger";
            // 
            // ctlIkGlaeubiger
            // 
            this.ctlIkGlaeubiger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkGlaeubiger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlIkGlaeubiger.Location = new System.Drawing.Point(0, 0);
            this.ctlIkGlaeubiger.Name = "ctlIkGlaeubiger";
            this.ctlIkGlaeubiger.Size = new System.Drawing.Size(684, 487);
            this.ctlIkGlaeubiger.TabIndex = 0;
            // 
            // tbpForderung
            // 
            this.tbpForderung.Controls.Add(this.ctlIkRechtstitelForderung);
            this.tbpForderung.Location = new System.Drawing.Point(6, 6);
            this.tbpForderung.Name = "tbpForderung";
            this.tbpForderung.Size = new System.Drawing.Size(684, 487);
            this.tbpForderung.TabIndex = 2;
            this.tbpForderung.Title = "Periodische Forderungen";
            // 
            // ctlIkRechtstitelForderung
            // 
            this.ctlIkRechtstitelForderung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkRechtstitelForderung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlIkRechtstitelForderung.Location = new System.Drawing.Point(0, 0);
            this.ctlIkRechtstitelForderung.Name = "ctlIkRechtstitelForderung";
            this.ctlIkRechtstitelForderung.Size = new System.Drawing.Size(684, 487);
            this.ctlIkRechtstitelForderung.TabIndex = 0;
            // 
            // qryPerson
            // 
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            // 
            // 
            // tbpEinkommen
            // 
            this.tbpEinkommen.Controls.Add(this.ctlIkEinkommen);
            this.tbpEinkommen.Location = new System.Drawing.Point(6, 6);
            this.tbpEinkommen.Name = "tbpEinkommen";
            this.tbpEinkommen.Size = new System.Drawing.Size(684, 487);
            this.tbpEinkommen.TabIndex = 3;
            this.tbpEinkommen.Title = "Einkommen";
            // 
            // ctlIkEinkommen
            // 
            this.ctlIkEinkommen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkEinkommen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlIkEinkommen.Location = new System.Drawing.Point(0, 0);
            this.ctlIkEinkommen.Name = "ctlIkEinkommen";
            this.ctlIkEinkommen.Size = new System.Drawing.Size(684, 487);
            this.ctlIkEinkommen.TabIndex = 0;
            // 
            // CtlIkRechtstitel
            // 
            this.ActiveSQLQuery = this.qryIkRechtstitel;
            this.Controls.Add(this.tabRechtstitel);
            this.Controls.Add(this.panel1);
            this.Name = "CtlIkRechtstitel";
            this.Size = new System.Drawing.Size(710, 580);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tabRechtstitel.ResumeLayout(false);
            this.tbpRechtstitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIkElterlicheSorgeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkElterlicheSorgeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkRechtstitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiteres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheVertretung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfodesRechtstitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezugKinderzulagenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexRundenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandVom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandPunkte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugKinderzulagenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugKinderzulagenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkIndexTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexRundenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexRundenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelRechtskraeftig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandPunkte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandVom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkIndexTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfodesRechtstitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelRechtskraeftig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigVon.Properties)).EndInit();
            this.tbpGlaeubiger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
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
    }
}