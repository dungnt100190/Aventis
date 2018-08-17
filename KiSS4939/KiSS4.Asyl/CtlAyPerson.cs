using System;
using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public class CtlAyPerson : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        bool IstUnterstuetzt_Changed = false;
        private KiSS4.Gui.KissCheckEdit chkUnterstuetzt;
        private KiSS4.Gui.KissButton cmdUebernehmen;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlZahlungsweg ctlZahlungsweg;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissMemoEdit edtBemerkungRTF;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
        private KiSS4.Gui.KissButtonEdit edtKostenstelle;
        private KiSS4.Gui.KissGroupBox groupBox1;
        private KiSS4.Gui.KissGroupBox groupBox2;
        private KiSS4.Gui.KissLabel lblAHV;
        private KiSS4.Gui.KissLabel lblAlter;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBeziehung;
        private KiSS4.Gui.KissLabel lblESR;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblKstKlient;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVorname;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgFinanzplan_BaPerson;
        private SharpLibrary.WinControls.TabPageEx tabBuchhaltung;
        private KiSS4.Gui.KissTextEdit txtAlter;
        private KiSS4.Gui.KissTextEdit txtBeziehung;
        private KiSS4.Common.KissReferenzNrEdit txtESR;
        private KiSS4.Gui.KissTextEdit txtHeimatort;
        private KiSS4.Gui.KissTextEdit txtName;
        private KiSS4.Gui.KissTextEdit txtVorname;
        private KiSS4.Gui.KissTabControlEx xTabControl1;

        #endregion

        #endregion

        #region Constructors

        public CtlAyPerson()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent call
            this.xTabControl1.SelectedTabIndex = xTabControl1.TabPages.IndexOf(this.tabBuchhaltung);
        }

        public CtlAyPerson(Image titelImage, int bgFinanzplanID, int baPersonID)
            : this()
        {
            this.picTitel.Image = titelImage;
            AyUtil.ApplyShStatusCodeToSqlQuery_SFP(this.ActiveSQLQuery, bgFinanzplanID);
            this.cmdUebernehmen.Enabled = this.ActiveSQLQuery.CanUpdate;

            this.qryBgFinanzplan_BaPerson.Fill(@"
                SELECT SPP.*,
                  PRS.Name, PRS.Vorname, PRS.Geburtsdatum, PRS.AHVNummer,PRS.NNummer,
                  dbo.fnGetAge(PRS.Geburtsdatum, IsNull(SFP.DatumVon, SFP.GeplantVon)) AS [Alter],
                  CASE WHEN PRS.BaPersonID = FAL.BaPersonID THEN 'Fallträger'
                    ELSE dbo.fnBaRelation(FAL.FaFallID, SPP.BaPersonID)
                  END                                                AS Beziehung,
                  HEI.Name + IsNull(' ' + HEI.Kanton, '')            AS Heimatort,
                  NAT.Text                                           AS Nationalitaet,
                  'Person im Masterbudget, vom ' + CONVERT(varchar, IsNull(SFP.DatumVon, SFP.GeplantVon), 104) + IsNull(' bis ' + CONVERT(varchar, IsNull(SFP.DatumBis, SFP.GeplantBis), 104), '') AS Titel,
                  'Alter am ' + CONVERT(varchar, IsNull(SFP.DatumVon, SFP.GeplantVon), 104) AS AlterAm,

                  KSP.Nr + ': ' + KSP.Name    AS Kostenstelle,
                  KSG.Nr + ': ' + KSG.Name    AS Kostenstelle_KVG

                FROM BgFinanzplan_BaPerson  SPP
                  INNER JOIN BaPerson       PRS ON PRS.BaPersonID = SPP.BaPersonID
                  INNER JOIN BgFinanzplan   SFP ON SFP.BgFinanzplanID = SPP.BgFinanzplanID
                  INNER JOIN FaLeistung     FAL ON FAL.FaLeistungID = SFP.FaLeistungID
                  LEFT  JOIN BaGemeinde     HEI ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
                  LEFT  JOIN BaLand         NAT ON NAT.BaLandID = PRS.NationalitaetCode
                  LEFT  JOIN KbKostenstelle KSP ON KSP.KbKostenstelleID = SPP.KbKostenstelleID
                  LEFT  JOIN KbKostenstelle KSG ON KSG.KbKostenstelleID = SPP.KbKostenstelleID_KVG
                WHERE SPP.BgFinanzplanID = {0} AND SPP.BaPersonID = {1}"
                , bgFinanzplanID, baPersonID);
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryBgFinanzplan_BaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.txtName = new KiSS4.Gui.KissTextEdit();
            this.txtVorname = new KiSS4.Gui.KissTextEdit();
            this.txtBeziehung = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.lblBeziehung = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.txtHeimatort = new KiSS4.Gui.KissTextEdit();
            this.txtAlter = new KiSS4.Gui.KissTextEdit();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblAlter = new KiSS4.Gui.KissLabel();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.edtBemerkungRTF = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.chkUnterstuetzt = new KiSS4.Gui.KissCheckEdit();
            this.xTabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tabBuchhaltung = new SharpLibrary.WinControls.TabPageEx();
            this.cmdUebernehmen = new KiSS4.Gui.KissButton();
            this.groupBox2 = new KiSS4.Gui.KissGroupBox();
            this.ctlZahlungsweg = new KiSS4.Common.CtlZahlungsweg();
            this.lblESR = new KiSS4.Gui.KissLabel();
            this.txtESR = new KiSS4.Common.KissReferenzNrEdit(this.components);
            this.groupBox1 = new KiSS4.Gui.KissGroupBox();
            this.edtKostenstelle = new KiSS4.Gui.KissButtonEdit();
            this.lblKstKlient = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.lblAHV = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan_BaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeziehung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeimatort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungRTF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnterstuetzt.Properties)).BeginInit();
            this.xTabControl1.SuspendLayout();
            this.tabBuchhaltung.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblESR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtESR.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKstKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitel
            //
            this.lblTitel.DataMember = "Titel";
            this.lblTitel.DataSource = this.qryBgFinanzplan_BaPerson;
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            //
            // qryBgFinanzplan_BaPerson
            //
            this.qryBgFinanzplan_BaPerson.CanUpdate = true;
            this.qryBgFinanzplan_BaPerson.HostControl = this;
            this.qryBgFinanzplan_BaPerson.TableName = "BgFinanzplan_BaPerson";
            this.qryBgFinanzplan_BaPerson.BeforePost += new System.EventHandler(this.qryBgFinanzplan_BaPerson_BeforePost);
            this.qryBgFinanzplan_BaPerson.AfterPost += new System.EventHandler(this.qryBgFinanzplan_BaPerson_AfterPost);
            //
            // txtName
            //
            this.txtName.DataMember = "Name";
            this.txtName.DataSource = this.qryBgFinanzplan_BaPerson;
            this.txtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtName.Location = new System.Drawing.Point(112, 30);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Properties.Appearance.Options.UseBackColor = true;
            this.txtName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(224, 24);
            this.txtName.TabIndex = 2;
            //
            // txtVorname
            //
            this.txtVorname.DataMember = "Vorname";
            this.txtVorname.DataSource = this.qryBgFinanzplan_BaPerson;
            this.txtVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtVorname.Location = new System.Drawing.Point(112, 60);
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.txtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.txtVorname.Properties.Appearance.Options.UseFont = true;
            this.txtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtVorname.Properties.ReadOnly = true;
            this.txtVorname.Size = new System.Drawing.Size(224, 24);
            this.txtVorname.TabIndex = 4;
            //
            // txtBeziehung
            //
            this.txtBeziehung.DataMember = "Beziehung";
            this.txtBeziehung.DataSource = this.qryBgFinanzplan_BaPerson;
            this.txtBeziehung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtBeziehung.Location = new System.Drawing.Point(112, 90);
            this.txtBeziehung.Name = "txtBeziehung";
            this.txtBeziehung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtBeziehung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtBeziehung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtBeziehung.Properties.Appearance.Options.UseBackColor = true;
            this.txtBeziehung.Properties.Appearance.Options.UseBorderColor = true;
            this.txtBeziehung.Properties.Appearance.Options.UseFont = true;
            this.txtBeziehung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBeziehung.Properties.ReadOnly = true;
            this.txtBeziehung.Size = new System.Drawing.Size(224, 24);
            this.txtBeziehung.TabIndex = 12;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(8, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(104, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            //
            // lblVorname
            //
            this.lblVorname.Location = new System.Drawing.Point(8, 60);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(104, 24);
            this.lblVorname.TabIndex = 3;
            this.lblVorname.Text = "Vorname";
            //
            // lblBeziehung
            //
            this.lblBeziehung.Location = new System.Drawing.Point(8, 90);
            this.lblBeziehung.Name = "lblBeziehung";
            this.lblBeziehung.Size = new System.Drawing.Size(104, 24);
            this.lblBeziehung.TabIndex = 11;
            this.lblBeziehung.Text = "Beziehung";
            //
            // edtGeburtsdatum
            //
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryBgFinanzplan_BaPerson;
            this.edtGeburtsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatum.EditValue = null;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(432, 30);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.ReadOnly = true;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(80, 24);
            this.edtGeburtsdatum.TabIndex = 6;
            //
            // txtHeimatort
            //
            this.txtHeimatort.DataMember = "Nationalitaet";
            this.txtHeimatort.DataSource = this.qryBgFinanzplan_BaPerson;
            this.txtHeimatort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtHeimatort.Location = new System.Drawing.Point(432, 90);
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtHeimatort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtHeimatort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtHeimatort.Properties.Appearance.Options.UseBackColor = true;
            this.txtHeimatort.Properties.Appearance.Options.UseBorderColor = true;
            this.txtHeimatort.Properties.Appearance.Options.UseFont = true;
            this.txtHeimatort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtHeimatort.Properties.ReadOnly = true;
            this.txtHeimatort.Size = new System.Drawing.Size(240, 24);
            this.txtHeimatort.TabIndex = 14;
            //
            // txtAlter
            //
            this.txtAlter.DataMember = "Alter";
            this.txtAlter.DataSource = this.qryBgFinanzplan_BaPerson;
            this.txtAlter.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtAlter.Location = new System.Drawing.Point(632, 30);
            this.txtAlter.Name = "txtAlter";
            this.txtAlter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtAlter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtAlter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtAlter.Properties.Appearance.Options.UseBackColor = true;
            this.txtAlter.Properties.Appearance.Options.UseBorderColor = true;
            this.txtAlter.Properties.Appearance.Options.UseFont = true;
            this.txtAlter.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAlter.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAlter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAlter.Properties.ReadOnly = true;
            this.txtAlter.Size = new System.Drawing.Size(40, 24);
            this.txtAlter.TabIndex = 8;
            //
            // lblGeburtsdatum
            //
            this.lblGeburtsdatum.Location = new System.Drawing.Point(344, 30);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(80, 24);
            this.lblGeburtsdatum.TabIndex = 5;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            //
            // lblAlter
            //
            this.lblAlter.DataMember = "AlterAm";
            this.lblAlter.DataSource = this.qryBgFinanzplan_BaPerson;
            this.lblAlter.Location = new System.Drawing.Point(520, 30);
            this.lblAlter.Name = "lblAlter";
            this.lblAlter.Size = new System.Drawing.Size(104, 24);
            this.lblAlter.TabIndex = 7;
            //
            // lblHeimatort
            //
            this.lblHeimatort.Location = new System.Drawing.Point(344, 90);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(72, 24);
            this.lblHeimatort.TabIndex = 13;
            this.lblHeimatort.Text = "Nationalität";
            //
            // edtBemerkungRTF
            //
            this.edtBemerkungRTF.DataMember = "Bemerkung";
            this.edtBemerkungRTF.DataSource = this.qryBgFinanzplan_BaPerson;
            this.edtBemerkungRTF.Location = new System.Drawing.Point(112, 120);
            this.edtBemerkungRTF.Name = "edtBemerkungRTF";
            this.edtBemerkungRTF.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungRTF.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungRTF.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungRTF.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungRTF.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungRTF.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungRTF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungRTF.Size = new System.Drawing.Size(560, 48);
            this.edtBemerkungRTF.TabIndex = 16;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Location = new System.Drawing.Point(8, 120);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(104, 24);
            this.lblBemerkungen.TabIndex = 15;
            this.lblBemerkungen.Text = "Bemerkungen";
            //
            // chkUnterstuetzt
            //
            this.chkUnterstuetzt.DataMember = "IstUnterstuetzt";
            this.chkUnterstuetzt.DataSource = this.qryBgFinanzplan_BaPerson;
            this.chkUnterstuetzt.Location = new System.Drawing.Point(256, 181);
            this.chkUnterstuetzt.Name = "chkUnterstuetzt";
            this.chkUnterstuetzt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkUnterstuetzt.Properties.Appearance.Options.UseBackColor = true;
            this.chkUnterstuetzt.Properties.Caption = "Diese Person wird unterstützt";
            this.chkUnterstuetzt.Size = new System.Drawing.Size(184, 21);
            this.chkUnterstuetzt.TabIndex = 17;
            //
            // xTabControl1
            //
            this.xTabControl1.Controls.Add(this.tabBuchhaltung);
            this.xTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xTabControl1.Location = new System.Drawing.Point(8, 200);
            this.xTabControl1.Name = "xTabControl1";
            this.xTabControl1.ShowFixedWidthTooltip = true;
            this.xTabControl1.Size = new System.Drawing.Size(664, 304);
            this.xTabControl1.TabIndex = 18;
            this.xTabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabBuchhaltung});
            this.xTabControl1.TabsLineColor = System.Drawing.Color.Black;
            this.xTabControl1.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.xTabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.xTabControl1.Text = "xTabControl1";
            //
            // tabBuchhaltung
            //
            this.tabBuchhaltung.Controls.Add(this.cmdUebernehmen);
            this.tabBuchhaltung.Controls.Add(this.groupBox2);
            this.tabBuchhaltung.Controls.Add(this.groupBox1);
            this.tabBuchhaltung.Location = new System.Drawing.Point(6, 32);
            this.tabBuchhaltung.Name = "tabBuchhaltung";
            this.tabBuchhaltung.Size = new System.Drawing.Size(652, 266);
            this.tabBuchhaltung.TabIndex = 0;
            this.tabBuchhaltung.Title = "Buchhaltung";
            //
            // cmdUebernehmen
            //
            this.cmdUebernehmen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdUebernehmen.Location = new System.Drawing.Point(16, 8);
            this.cmdUebernehmen.Name = "cmdUebernehmen";
            this.cmdUebernehmen.Size = new System.Drawing.Size(632, 24);
            this.cmdUebernehmen.TabIndex = 9;
            this.cmdUebernehmen.Text = "Kostenstellen und Bankverbindung bei allen anderen Personen in diesem Masterbudge" +
                "t aktualisieren";
            this.cmdUebernehmen.UseVisualStyleBackColor = false;
            this.cmdUebernehmen.Click += new System.EventHandler(this.cmdUebernehmen_Click);
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.ctlZahlungsweg);
            this.groupBox2.Controls.Add(this.lblESR);
            this.groupBox2.Controls.Add(this.txtESR);
            this.groupBox2.Location = new System.Drawing.Point(16, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bankverbindung";
            //
            // ctlZahlungsweg
            //
            this.ctlZahlungsweg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlZahlungsweg.DataMember = "BaZahlungswegID";
            this.ctlZahlungsweg.DataSource = this.qryBgFinanzplan_BaPerson;
            this.ctlZahlungsweg.Location = new System.Drawing.Point(8, 16);
            this.ctlZahlungsweg.Modul = KiSS4.Gui.ModulID.A;
            this.ctlZahlungsweg.Name = "ctlZahlungsweg";
            this.ctlZahlungsweg.Size = new System.Drawing.Size(616, 120);
            this.ctlZahlungsweg.TabIndex = 9;
            //
            // lblESR
            //
            this.lblESR.Location = new System.Drawing.Point(8, 144);
            this.lblESR.Name = "lblESR";
            this.lblESR.Size = new System.Drawing.Size(104, 24);
            this.lblESR.TabIndex = 7;
            this.lblESR.Text = "Referenznummer";
            //
            // txtESR
            //
            this.txtESR.DataMember = "ReferenzNummer";
            this.txtESR.DataSource = this.qryBgFinanzplan_BaPerson;
            this.txtESR.Location = new System.Drawing.Point(112, 144);
            this.txtESR.Name = "txtESR";
            this.txtESR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtESR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtESR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtESR.Properties.Appearance.Options.UseBackColor = true;
            this.txtESR.Properties.Appearance.Options.UseBorderColor = true;
            this.txtESR.Properties.Appearance.Options.UseFont = true;
            this.txtESR.Properties.Appearance.Options.UseTextOptions = true;
            this.txtESR.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtESR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtESR.Size = new System.Drawing.Size(512, 24);
            this.txtESR.TabIndex = 8;
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.edtKostenstelle);
            this.groupBox1.Controls.Add(this.lblKstKlient);
            this.groupBox1.Location = new System.Drawing.Point(16, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kostenstellen";
            //
            // edtKostenstelle
            //
            this.edtKostenstelle.DataMember = "Kostenstelle";
            this.edtKostenstelle.DataSource = this.qryBgFinanzplan_BaPerson;
            this.edtKostenstelle.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenstelle.Location = new System.Drawing.Point(77, 16);
            this.edtKostenstelle.Name = "edtKostenstelle";
            this.edtKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenstelle.Properties.ReadOnly = true;
            this.edtKostenstelle.Size = new System.Drawing.Size(547, 24);
            this.edtKostenstelle.TabIndex = 3;
            this.edtKostenstelle.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenstelle_UserModifiedFld);
            //
            // lblKstKlient
            //
            this.lblKstKlient.Location = new System.Drawing.Point(8, 16);
            this.lblKstKlient.Name = "lblKstKlient";
            this.lblKstKlient.Size = new System.Drawing.Size(56, 24);
            this.lblKstKlient.TabIndex = 0;
            this.lblKstKlient.Text = "Klient";
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            //
            // edtAHVNummer
            //
            this.edtAHVNummer.DataMember = "NNummer";
            this.edtAHVNummer.DataSource = this.qryBgFinanzplan_BaPerson;
            this.edtAHVNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummer.Location = new System.Drawing.Point(432, 60);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Properties.ReadOnly = true;
            this.edtAHVNummer.Size = new System.Drawing.Size(121, 24);
            this.edtAHVNummer.TabIndex = 10;
            //
            // lblAHV
            //
            this.lblAHV.Location = new System.Drawing.Point(344, 60);
            this.lblAHV.Name = "lblAHV";
            this.lblAHV.Size = new System.Drawing.Size(32, 24);
            this.lblAHV.TabIndex = 9;
            this.lblAHV.Text = "N-Nr.";
            //
            // CtlAyPerson
            //
            this.ActiveSQLQuery = this.qryBgFinanzplan_BaPerson;
            this.Controls.Add(this.edtAHVNummer);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.xTabControl1);
            this.Controls.Add(this.chkUnterstuetzt);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.edtBemerkungRTF);
            this.Controls.Add(this.lblHeimatort);
            this.Controls.Add(this.lblAlter);
            this.Controls.Add(this.lblGeburtsdatum);
            this.Controls.Add(this.txtAlter);
            this.Controls.Add(this.txtHeimatort);
            this.Controls.Add(this.edtGeburtsdatum);
            this.Controls.Add(this.lblBeziehung);
            this.Controls.Add(this.lblVorname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtBeziehung);
            this.Controls.Add(this.txtVorname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblAHV);
            this.Name = "CtlAyPerson";
            this.Size = new System.Drawing.Size(680, 520);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan_BaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeziehung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeimatort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungRTF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnterstuetzt.Properties)).EndInit();
            this.xTabControl1.ResumeLayout(false);
            this.tabBuchhaltung.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblESR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtESR.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKstKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).EndInit();
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

        private void cmdUebernehmen_Click(object sender, System.EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlAyPerson", "GleicheKostenstelle", "Sollen wirklich alle Personen dieser Unterstützungseinheit mit denselben Kostenstellen und Bankverbindungen versehen werden? \r\nDiese Aktion wird sofort durchgeführt und kann nicht ohne weiteres rückgängig gemacht werden."))
            {
                DBUtil.ExecSQL(@"
                    UPDATE BgFinanzplan_BaPerson
                      SET BaZahlungswegID  = {2}, ReferenzNummer = {3}
                    WHERE BgFinanzplanID = {0} AND BaPersonID <> {1} AND IstUnterstuetzt = 1"
                    , this.qryBgFinanzplan_BaPerson["BgFinanzplanID"], this.qryBgFinanzplan_BaPerson["BaPersonID"]
                    , this.qryBgFinanzplan_BaPerson["BaZahlungswegID"], this.qryBgFinanzplan_BaPerson["ReferenzNummer"]);
            }
        }

        private void edtKostenstelle_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtKostenstelle.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(SearchString))
            {
                if (DBUtil.IsEmpty(SearchString))
                    SearchString = "%";

                e.Cancel = !dlg.SearchData(@"
                    SELECT KbKostenstelleID$ = KbKostenstelleID,
                      Nr, Name
                    FROM KbKostenstelle
                    WHERE Nr + ': ' + Name LIKE '%' + {0} + '%'
                    ORDER BY Nr, Name
                    ", SearchString, e.ButtonClicked);

                if (e.Cancel) return;
            }

            qryBgFinanzplan_BaPerson["KbKostenstelleID"] = dlg["KbKostenstelleID$"];
            qryBgFinanzplan_BaPerson["Kostenstelle"] = string.Format("{0}: {1}", dlg["Nr"], dlg["Name"]);

            qryBgFinanzplan_BaPerson.RefreshDisplay();
        }

        private void qryBgFinanzplan_BaPerson_AfterPost(object sender, System.EventArgs e)
        {
            if (IstUnterstuetzt_Changed)
            {
                DBUtil.ExecSQLThrowingException("EXECUTE spAyFinanzplan_Update {0}", this.qryBgFinanzplan_BaPerson["BgFinanzplanID"]);

                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
        }

        private void qryBgFinanzplan_BaPerson_BeforePost(object sender, System.EventArgs e)
        {
            IstUnterstuetzt_Changed = this.qryBgFinanzplan_BaPerson.ColumnModified("IstUnterstuetzt");

            if (DBUtil.IsEmpty(this.qryBgFinanzplan_BaPerson["BaZahlungswegID"]))
                this.qryBgFinanzplan_BaPerson["ReferenzNummer"] = DBNull.Value;

            if (!DBUtil.IsEmpty(this.qryBgFinanzplan_BaPerson["ReferenzNummer"]) &&
                !this.txtESR.ValidateReferenzNummer(this.ctlZahlungsweg.EsrTeilnehmer))
            {
                this.txtESR.Focus();
                throw new KissCancelException();
            }
        }

        #endregion
    }
}