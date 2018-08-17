
namespace KiSS4.Query
{
    public class CtlQueryBaPersonenadressen2 : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissTextEdit edtAufKanton;
        private KiSS4.Gui.KissTextEdit edtAufOrt;
        private KiSS4.Gui.KissTextEdit edtAufPLZ;
        private KiSS4.Gui.KissTextEdit edtAufStrasse;
        private KiSS4.Gui.KissLookUpEdit edtGeschlechtCode;
        private KiSS4.Gui.KissTextEdit edtGetLogonName;
        private KiSS4.Gui.KissTextEdit edtHeimatort;
        private KiSS4.Gui.KissTextEdit edtKanton;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaetCode;
        private KiSS4.Gui.KissCheckEdit edtNurAktive;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblAufenthaltsort;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblNationalitaet;
        private KiSS4.Gui.KissLabel lblPLZOrtKt;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissLabel lblWohnsitz;

        #endregion

        #region Constructors

        public CtlQueryBaPersonenadressen2()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaPersonenadressen2));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.lblWohnsitz = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltsort = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblPLZOrtKt = new KiSS4.Gui.KissLabel();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.lblNationalitaet = new KiSS4.Gui.KissLabel();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtKanton = new KiSS4.Gui.KissTextEdit();
            this.edtAufStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtAufPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtAufOrt = new KiSS4.Gui.KissTextEdit();
            this.edtAufKanton = new KiSS4.Gui.KissTextEdit();
            this.edtHeimatort = new KiSS4.Gui.KissTextEdit();
            this.edtNationalitaetCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtGeschlechtCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.edtGetLogonName = new KiSS4.Gui.KissTextEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltsort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGetLogonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.gridView1});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "ID";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtGetLogonName);
            this.tpgSuchen.Controls.Add(this.edtNurAktive);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtGeschlechtCode);
            this.tpgSuchen.Controls.Add(this.edtNationalitaetCode);
            this.tpgSuchen.Controls.Add(this.edtHeimatort);
            this.tpgSuchen.Controls.Add(this.edtAufKanton);
            this.tpgSuchen.Controls.Add(this.edtAufOrt);
            this.tpgSuchen.Controls.Add(this.edtAufPLZ);
            this.tpgSuchen.Controls.Add(this.edtAufStrasse);
            this.tpgSuchen.Controls.Add(this.edtKanton);
            this.tpgSuchen.Controls.Add(this.edtOrt);
            this.tpgSuchen.Controls.Add(this.edtPLZ);
            this.tpgSuchen.Controls.Add(this.edtStrasse);
            this.tpgSuchen.Controls.Add(this.edtVorname);
            this.tpgSuchen.Controls.Add(this.edtName);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblGeschlecht);
            this.tpgSuchen.Controls.Add(this.lblNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblHeimatort);
            this.tpgSuchen.Controls.Add(this.lblPLZOrtKt);
            this.tpgSuchen.Controls.Add(this.lblStrasse);
            this.tpgSuchen.Controls.Add(this.lblAufenthaltsort);
            this.tpgSuchen.Controls.Add(this.lblWohnsitz);
            this.tpgSuchen.Controls.Add(this.lblVorname);
            this.tpgSuchen.Controls.Add(this.lblName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWohnsitz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAufenthaltsort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPLZOrtKt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblHeimatort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGeschlecht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKanton, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAufStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAufPLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAufOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAufKanton, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtHeimatort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNationalitaetCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeschlechtCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktive, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGetLogonName, 0);
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(10, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // lblVorname
            //
            this.lblVorname.Location = new System.Drawing.Point(10, 70);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(130, 24);
            this.lblVorname.TabIndex = 1;
            this.lblVorname.Text = "Vorname";
            this.lblVorname.UseCompatibleTextRendering = true;
            //
            // lblWohnsitz
            //
            this.lblWohnsitz.Location = new System.Drawing.Point(150, 100);
            this.lblWohnsitz.Name = "lblWohnsitz";
            this.lblWohnsitz.Size = new System.Drawing.Size(130, 24);
            this.lblWohnsitz.TabIndex = 2;
            this.lblWohnsitz.Text = "Wohnsitz";
            this.lblWohnsitz.UseCompatibleTextRendering = true;
            //
            // lblAufenthaltsort
            //
            this.lblAufenthaltsort.Location = new System.Drawing.Point(450, 100);
            this.lblAufenthaltsort.Name = "lblAufenthaltsort";
            this.lblAufenthaltsort.Size = new System.Drawing.Size(130, 24);
            this.lblAufenthaltsort.TabIndex = 3;
            this.lblAufenthaltsort.Text = "Aufenthaltsort";
            this.lblAufenthaltsort.UseCompatibleTextRendering = true;
            //
            // lblStrasse
            //
            this.lblStrasse.Location = new System.Drawing.Point(10, 130);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(130, 24);
            this.lblStrasse.TabIndex = 4;
            this.lblStrasse.Text = "Strasse";
            this.lblStrasse.UseCompatibleTextRendering = true;
            //
            // lblPLZOrtKt
            //
            this.lblPLZOrtKt.Location = new System.Drawing.Point(10, 160);
            this.lblPLZOrtKt.Name = "lblPLZOrtKt";
            this.lblPLZOrtKt.Size = new System.Drawing.Size(130, 24);
            this.lblPLZOrtKt.TabIndex = 5;
            this.lblPLZOrtKt.Text = "PLZ / Ort / Kt";
            this.lblPLZOrtKt.UseCompatibleTextRendering = true;
            //
            // lblHeimatort
            //
            this.lblHeimatort.Location = new System.Drawing.Point(10, 220);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(130, 24);
            this.lblHeimatort.TabIndex = 8;
            this.lblHeimatort.Text = "Heimatort";
            this.lblHeimatort.UseCompatibleTextRendering = true;
            //
            // lblNationalitaet
            //
            this.lblNationalitaet.Location = new System.Drawing.Point(10, 250);
            this.lblNationalitaet.Name = "lblNationalitaet";
            this.lblNationalitaet.Size = new System.Drawing.Size(130, 24);
            this.lblNationalitaet.TabIndex = 9;
            this.lblNationalitaet.Text = "Nationalitaet";
            this.lblNationalitaet.UseCompatibleTextRendering = true;
            //
            // lblGeschlecht
            //
            this.lblGeschlecht.Location = new System.Drawing.Point(10, 280);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(130, 24);
            this.lblGeschlecht.TabIndex = 10;
            this.lblGeschlecht.Text = "Geschlecht";
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 340);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 11;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // edtName
            //
            this.edtName.Location = new System.Drawing.Point(150, 40);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(250, 24);
            this.edtName.TabIndex = 20;
            //
            // edtVorname
            //
            this.edtVorname.Location = new System.Drawing.Point(150, 70);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(250, 24);
            this.edtVorname.TabIndex = 21;
            //
            // edtStrasse
            //
            this.edtStrasse.Location = new System.Drawing.Point(150, 130);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(250, 24);
            this.edtStrasse.TabIndex = 22;
            //
            // edtPLZ
            //
            this.edtPLZ.Location = new System.Drawing.Point(150, 160);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Size = new System.Drawing.Size(60, 24);
            this.edtPLZ.TabIndex = 23;
            //
            // edtOrt
            //
            this.edtOrt.Location = new System.Drawing.Point(215, 160);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(150, 24);
            this.edtOrt.TabIndex = 24;
            //
            // edtKanton
            //
            this.edtKanton.Location = new System.Drawing.Point(370, 160);
            this.edtKanton.Name = "edtKanton";
            this.edtKanton.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKanton.Properties.Appearance.Options.UseFont = true;
            this.edtKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKanton.Size = new System.Drawing.Size(30, 24);
            this.edtKanton.TabIndex = 25;
            //
            // edtAufStrasse
            //
            this.edtAufStrasse.Location = new System.Drawing.Point(450, 130);
            this.edtAufStrasse.Name = "edtAufStrasse";
            this.edtAufStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtAufStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufStrasse.Size = new System.Drawing.Size(250, 24);
            this.edtAufStrasse.TabIndex = 26;
            //
            // edtAufPLZ
            //
            this.edtAufPLZ.Location = new System.Drawing.Point(450, 160);
            this.edtAufPLZ.Name = "edtAufPLZ";
            this.edtAufPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtAufPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufPLZ.Size = new System.Drawing.Size(60, 24);
            this.edtAufPLZ.TabIndex = 27;
            //
            // edtAufOrt
            //
            this.edtAufOrt.Location = new System.Drawing.Point(515, 160);
            this.edtAufOrt.Name = "edtAufOrt";
            this.edtAufOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufOrt.Properties.Appearance.Options.UseFont = true;
            this.edtAufOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufOrt.Size = new System.Drawing.Size(150, 24);
            this.edtAufOrt.TabIndex = 28;
            //
            // edtAufKanton
            //
            this.edtAufKanton.Location = new System.Drawing.Point(670, 160);
            this.edtAufKanton.Name = "edtAufKanton";
            this.edtAufKanton.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufKanton.Properties.Appearance.Options.UseFont = true;
            this.edtAufKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufKanton.Size = new System.Drawing.Size(30, 24);
            this.edtAufKanton.TabIndex = 29;
            //
            // edtHeimatort
            //
            this.edtHeimatort.Location = new System.Drawing.Point(150, 220);
            this.edtHeimatort.Name = "edtHeimatort";
            this.edtHeimatort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeimatort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatort.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatort.Size = new System.Drawing.Size(250, 24);
            this.edtHeimatort.TabIndex = 30;
            //
            // edtNationalitaetCode
            //
            this.edtNationalitaetCode.Location = new System.Drawing.Point(150, 250);
            this.edtNationalitaetCode.LOVName = "BaLand";
            this.edtNationalitaetCode.Name = "edtNationalitaetCode";
            this.edtNationalitaetCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNationalitaetCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaetCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaetCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaetCode.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaetCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNationalitaetCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtNationalitaetCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaetCode.Properties.NullText = "";
            this.edtNationalitaetCode.Properties.ShowFooter = false;
            this.edtNationalitaetCode.Properties.ShowHeader = false;
            this.edtNationalitaetCode.Size = new System.Drawing.Size(250, 24);
            this.edtNationalitaetCode.TabIndex = 31;
            //
            // edtGeschlechtCode
            //
            this.edtGeschlechtCode.Location = new System.Drawing.Point(150, 280);
            this.edtGeschlechtCode.LOVName = "BaGeschlecht";
            this.edtGeschlechtCode.Name = "edtGeschlechtCode";
            this.edtGeschlechtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschlechtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtCode.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeschlechtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtGeschlechtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlechtCode.Properties.NullText = "";
            this.edtGeschlechtCode.Properties.ShowFooter = false;
            this.edtGeschlechtCode.Properties.ShowHeader = false;
            this.edtGeschlechtCode.Size = new System.Drawing.Size(250, 24);
            this.edtGeschlechtCode.TabIndex = 32;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 340);
            this.edtUserID.LookupSQL = "select ID = UserID, SAR = LastName + isNull(\', \' + FirstName,\'\'), [Kuerzel] = Log" +
                "onName\r\n\nfrom   XUser\r\nwhere LastName + isNull(\', \' + FirstName,\'\') like isNull(" +
                "{0}, \'\') + \'%\'\r\norder by SAR\r\n----\r\n";
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(250, 24);
            this.edtUserID.TabIndex = 33;
            //
            // edtNurAktive
            //
            this.edtNurAktive.EditValue = false;
            this.edtNurAktive.Location = new System.Drawing.Point(150, 370);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = "nur aktive Faelle";
            this.edtNurAktive.Size = new System.Drawing.Size(250, 19);
            this.edtNurAktive.TabIndex = 34;
            //
            // edtGetLogonName
            //
            this.edtGetLogonName.Location = new System.Drawing.Point(150, 32767);
            this.edtGetLogonName.Name = "edtGetLogonName";
            this.edtGetLogonName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGetLogonName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGetLogonName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGetLogonName.Properties.Appearance.Options.UseBackColor = true;
            this.edtGetLogonName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGetLogonName.Properties.Appearance.Options.UseFont = true;
            this.edtGetLogonName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGetLogonName.Size = new System.Drawing.Size(0, 24);
            this.edtGetLogonName.TabIndex = 200;
            //
            // gridView1
            //
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            //
            // grvQuery1
            //
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.Name = "grvQuery1";
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            //
            // CtlQueryBaPersonenadressen2
            //
            this.Name = "CtlQueryBaPersonenadressen2";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltsort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGetLogonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}