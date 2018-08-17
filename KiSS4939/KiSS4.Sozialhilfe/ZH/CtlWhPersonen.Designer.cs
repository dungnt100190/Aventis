
namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlWhPersonen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhPersonen));
            this.grdKlientensystem = new KiSS4.Gui.KissGrid();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.fraAnspechperson = new KiSS4.Gui.KissGroupBox();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtNameVorname = new KiSS4.Gui.KissLabel();
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzStrasseHausNr = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzPLZOrt = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.edtHeimatort = new KiSS4.Gui.KissLabel();
            this.fraKennzahlen = new KiSS4.Gui.KissGroupBox();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.lblHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.lblHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.edtHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.lblUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.lblUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.edtUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.grdHaushalt = new KiSS4.Gui.KissGrid();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblInfo1 = new KiSS4.Gui.KissLabel();
            this.lblKlientensystem = new KiSS4.Gui.KissLabel();
            this.lblFinanzPlan = new KiSS4.Gui.KissLabel();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.colBaPersonID_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIstUnterstuetzt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvHaushalt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvKlientensystem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryHaushalt = new KiSS4.DB.SqlQuery(this.components);
            this.qryHeader = new KiSS4.DB.SqlQuery(this.components);
            this.qryKlientensystem = new KiSS4.DB.SqlQuery(this.components);
            this.qryWhKennzahlen = new KiSS4.DB.SqlQuery(this.components);
            this.repItemIstUnterstuetzt = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.fraAnspechperson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasseHausNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort)).BeginInit();
            this.fraKennzahlen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIstUnterstuetzt)).BeginInit();
            this.SuspendLayout();
            //
            // grdKlientensystem
            //
            this.grdKlientensystem.DataSource = this.qryKlientensystem;
            this.grdKlientensystem.EmbeddedNavigator.Name = "";
            this.grdKlientensystem.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKlientensystem.Location = new System.Drawing.Point(7, 223);
            this.grdKlientensystem.MainView = this.grvKlientensystem;
            this.grdKlientensystem.Name = "grdKlientensystem";
            this.grdKlientensystem.Size = new System.Drawing.Size(359, 193);
            this.grdKlientensystem.TabIndex = 0;
            this.grdKlientensystem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvKlientensystem});
            this.grdKlientensystem.DoubleClick += new System.EventHandler(this.grdKlientensystem_DoubleClick);
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Personen im Haushalt, vom {0:d} bis {1:d}";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // fraAnspechperson
            //
            this.fraAnspechperson.Controls.Add(this.edtHeimatort);
            this.fraAnspechperson.Controls.Add(this.lblHeimatort);
            this.fraAnspechperson.Controls.Add(this.edtGeburtsdatum);
            this.fraAnspechperson.Controls.Add(this.lblGeburtsdatum);
            this.fraAnspechperson.Controls.Add(this.edtWohnsitzPLZOrt);
            this.fraAnspechperson.Controls.Add(this.edtWohnsitzStrasseHausNr);
            this.fraAnspechperson.Controls.Add(this.lblAdresse);
            this.fraAnspechperson.Controls.Add(this.edtNameVorname);
            this.fraAnspechperson.Controls.Add(this.lblName);
            this.fraAnspechperson.Location = new System.Drawing.Point(7, 35);
            this.fraAnspechperson.Name = "fraAnspechperson";
            this.fraAnspechperson.Size = new System.Drawing.Size(359, 112);
            this.fraAnspechperson.TabIndex = 1;
            this.fraAnspechperson.TabStop = false;
            this.fraAnspechperson.Text = "Unterstützungsträger/in für diese Leistungseinheit";
            this.fraAnspechperson.UseCompatibleTextRendering = true;
            //
            // lblName
            //
            this.lblName.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblName.Location = new System.Drawing.Point(8, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // edtNameVorname
            //
            this.edtNameVorname.DataMember = "NameVorname";
            this.edtNameVorname.DataSource = this.qryHeader;
            this.edtNameVorname.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtNameVorname.Location = new System.Drawing.Point(88, 16);
            this.edtNameVorname.Name = "edtNameVorname";
            this.edtNameVorname.Size = new System.Drawing.Size(200, 16);
            this.edtNameVorname.TabIndex = 1;
            this.edtNameVorname.UseCompatibleTextRendering = true;
            //
            // lblAdresse
            //
            this.lblAdresse.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAdresse.Location = new System.Drawing.Point(8, 32);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(80, 16);
            this.lblAdresse.TabIndex = 2;
            this.lblAdresse.Text = "Adresse";
            this.lblAdresse.UseCompatibleTextRendering = true;
            //
            // edtWohnsitzStrasseHausNr
            //
            this.edtWohnsitzStrasseHausNr.DataMember = "WohnsitzStrasseHausNr";
            this.edtWohnsitzStrasseHausNr.DataSource = this.qryHeader;
            this.edtWohnsitzStrasseHausNr.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtWohnsitzStrasseHausNr.Location = new System.Drawing.Point(88, 32);
            this.edtWohnsitzStrasseHausNr.Name = "edtWohnsitzStrasseHausNr";
            this.edtWohnsitzStrasseHausNr.Size = new System.Drawing.Size(200, 16);
            this.edtWohnsitzStrasseHausNr.TabIndex = 3;
            this.edtWohnsitzStrasseHausNr.UseCompatibleTextRendering = true;
            //
            // edtWohnsitzPLZOrt
            //
            this.edtWohnsitzPLZOrt.DataMember = "WohnsitzPLZOrt";
            this.edtWohnsitzPLZOrt.DataSource = this.qryHeader;
            this.edtWohnsitzPLZOrt.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtWohnsitzPLZOrt.Location = new System.Drawing.Point(88, 48);
            this.edtWohnsitzPLZOrt.Name = "edtWohnsitzPLZOrt";
            this.edtWohnsitzPLZOrt.Size = new System.Drawing.Size(200, 16);
            this.edtWohnsitzPLZOrt.TabIndex = 4;
            this.edtWohnsitzPLZOrt.UseCompatibleTextRendering = true;
            //
            // lblGeburtsdatum
            //
            this.lblGeburtsdatum.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblGeburtsdatum.Location = new System.Drawing.Point(8, 72);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(80, 16);
            this.lblGeburtsdatum.TabIndex = 5;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            this.lblGeburtsdatum.UseCompatibleTextRendering = true;
            //
            // edtGeburtsdatum
            //
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryHeader;
            this.edtGeburtsdatum.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(88, 72);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Size = new System.Drawing.Size(200, 16);
            this.edtGeburtsdatum.TabIndex = 6;
            this.edtGeburtsdatum.UseCompatibleTextRendering = true;
            //
            // lblHeimatort
            //
            this.lblHeimatort.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHeimatort.Location = new System.Drawing.Point(8, 88);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(80, 16);
            this.lblHeimatort.TabIndex = 7;
            this.lblHeimatort.Text = "Heimatort";
            this.lblHeimatort.UseCompatibleTextRendering = true;
            //
            // edtHeimatort
            //
            this.edtHeimatort.DataMember = "Heimatort";
            this.edtHeimatort.DataSource = this.qryHeader;
            this.edtHeimatort.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHeimatort.Location = new System.Drawing.Point(88, 88);
            this.edtHeimatort.Name = "edtHeimatort";
            this.edtHeimatort.Size = new System.Drawing.Size(200, 16);
            this.edtHeimatort.TabIndex = 8;
            this.edtHeimatort.UseCompatibleTextRendering = true;
            //
            // fraKennzahlen
            //
            this.fraKennzahlen.Controls.Add(this.edtUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.edtUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.lblUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.kissLabel22);
            this.fraKennzahlen.Controls.Add(this.edtHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.edtHgGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.lblHgGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.kissLabel21);
            this.fraKennzahlen.Location = new System.Drawing.Point(363, 35);
            this.fraKennzahlen.Name = "fraKennzahlen";
            this.fraKennzahlen.Size = new System.Drawing.Size(392, 112);
            this.fraKennzahlen.TabIndex = 2;
            this.fraKennzahlen.TabStop = false;
            this.fraKennzahlen.Text = "Kennzahlen";
            this.fraKennzahlen.UseCompatibleTextRendering = true;
            //
            // kissLabel21
            //
            this.kissLabel21.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel21.Location = new System.Drawing.Point(8, 24);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(170, 16);
            this.kissLabel21.TabIndex = 0;
            this.kissLabel21.Text = "Berechnungseinheit BE";
            this.kissLabel21.UseCompatibleTextRendering = true;
            //
            // lblHgGrundbedarf
            //
            this.lblHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgGrundbedarf.Location = new System.Drawing.Point(8, 40);
            this.lblHgGrundbedarf.Name = "lblHgGrundbedarf";
            this.lblHgGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblHgGrundbedarf.TabIndex = 1;
            this.lblHgGrundbedarf.Text = "Grundbedarf";
            this.lblHgGrundbedarf.UseCompatibleTextRendering = true;
            //
            // edtHgGrundbedarf
            //
            this.edtHgGrundbedarf.DataMember = "HgGrundbedarf";
            this.edtHgGrundbedarf.DataSource = this.qryWhKennzahlen;
            this.edtHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgGrundbedarf.Location = new System.Drawing.Point(80, 40);
            this.edtHgGrundbedarf.Name = "edtHgGrundbedarf";
            this.edtHgGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtHgGrundbedarf.TabIndex = 2;
            this.edtHgGrundbedarf.UseCompatibleTextRendering = true;
            //
            // lblHgWohnkosten
            //
            this.lblHgWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgWohnkosten.Location = new System.Drawing.Point(8, 56);
            this.lblHgWohnkosten.Name = "lblHgWohnkosten";
            this.lblHgWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblHgWohnkosten.TabIndex = 3;
            this.lblHgWohnkosten.Text = "Miete ";
            this.lblHgWohnkosten.UseCompatibleTextRendering = true;
            //
            // edtHgWohnkosten
            //
            this.edtHgWohnkosten.DataMember = "HgWohnkosten";
            this.edtHgWohnkosten.DataSource = this.qryWhKennzahlen;
            this.edtHgWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgWohnkosten.Location = new System.Drawing.Point(80, 56);
            this.edtHgWohnkosten.Name = "edtHgWohnkosten";
            this.edtHgWohnkosten.Size = new System.Drawing.Size(24, 16);
            this.edtHgWohnkosten.TabIndex = 4;
            this.edtHgWohnkosten.UseCompatibleTextRendering = true;
            //
            // kissLabel22
            //
            this.kissLabel22.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel22.Location = new System.Drawing.Point(184, 24);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(180, 16);
            this.kissLabel22.TabIndex = 5;
            this.kissLabel22.Text = "Unterstützungseinheit UE";
            this.kissLabel22.UseCompatibleTextRendering = true;
            //
            // lblUeGrundbedarf
            //
            this.lblUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeGrundbedarf.Location = new System.Drawing.Point(184, 40);
            this.lblUeGrundbedarf.Name = "lblUeGrundbedarf";
            this.lblUeGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblUeGrundbedarf.TabIndex = 6;
            this.lblUeGrundbedarf.Text = "Grundbedarf";
            this.lblUeGrundbedarf.UseCompatibleTextRendering = true;
            //
            // edtUeGrundbedarf
            //
            this.edtUeGrundbedarf.DataMember = "UeGrundbedarf";
            this.edtUeGrundbedarf.DataSource = this.qryWhKennzahlen;
            this.edtUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeGrundbedarf.Location = new System.Drawing.Point(256, 40);
            this.edtUeGrundbedarf.Name = "edtUeGrundbedarf";
            this.edtUeGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtUeGrundbedarf.TabIndex = 7;
            this.edtUeGrundbedarf.UseCompatibleTextRendering = true;
            //
            // lblUeWohnkosten
            //
            this.lblUeWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeWohnkosten.Location = new System.Drawing.Point(184, 56);
            this.lblUeWohnkosten.Name = "lblUeWohnkosten";
            this.lblUeWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblUeWohnkosten.TabIndex = 8;
            this.lblUeWohnkosten.Text = "Miete (Anteil)";
            this.lblUeWohnkosten.UseCompatibleTextRendering = true;
            //
            // edtUeWohnkosten
            //
            this.edtUeWohnkosten.DataMember = "UeWohnkosten";
            this.edtUeWohnkosten.DataSource = this.qryWhKennzahlen;
            this.edtUeWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeWohnkosten.Location = new System.Drawing.Point(256, 56);
            this.edtUeWohnkosten.Name = "edtUeWohnkosten";
            this.edtUeWohnkosten.Size = new System.Drawing.Size(24, 16);
            this.edtUeWohnkosten.TabIndex = 9;
            this.edtUeWohnkosten.UseCompatibleTextRendering = true;
            //
            // grdHaushalt
            //
            this.grdHaushalt.DataSource = this.qryHaushalt;
            this.grdHaushalt.EmbeddedNavigator.Name = "";
            this.grdHaushalt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdHaushalt.Location = new System.Drawing.Point(408, 223);
            this.grdHaushalt.MainView = this.grvHaushalt;
            this.grdHaushalt.Name = "grdHaushalt";
            this.grdHaushalt.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                        this.repItemIstUnterstuetzt});
            this.grdHaushalt.Size = new System.Drawing.Size(347, 193);
            this.grdHaushalt.TabIndex = 5;
            this.grdHaushalt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvHaushalt});
            this.grdHaushalt.DoubleClick += new System.EventHandler(this.grdHaushalt_DoubleClick);
            //
            // picTitle
            //
            this.picTitle.Location = new System.Drawing.Point(8, 8);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 55;
            this.picTitle.TabStop = false;
            //
            // lblInfo1
            //
            this.lblInfo1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInfo1.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInfo1.Location = new System.Drawing.Point(7, 165);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(720, 32);
            this.lblInfo1.TabIndex = 63;
            this.lblInfo1.Text = "Alle Personen aus dem Klientensystem, welche in der Berechnungseinheit im Haushal" +
                "t leben und/oder in der Unterstützungseinheit sind, müssen in das rechte Fenster" +
                " gesetzt werden.";
            this.lblInfo1.UseCompatibleTextRendering = true;
            //
            // lblKlientensystem
            //
            this.lblKlientensystem.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKlientensystem.Location = new System.Drawing.Point(7, 202);
            this.lblKlientensystem.Name = "lblKlientensystem";
            this.lblKlientensystem.Size = new System.Drawing.Size(384, 16);
            this.lblKlientensystem.TabIndex = 65;
            this.lblKlientensystem.Text = "Klientensystem und Berechnungspersonen";
            this.lblKlientensystem.UseCompatibleTextRendering = true;
            //
            // lblFinanzPlan
            //
            this.lblFinanzPlan.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblFinanzPlan.Location = new System.Drawing.Point(408, 202);
            this.lblFinanzPlan.Name = "lblFinanzPlan";
            this.lblFinanzPlan.Size = new System.Drawing.Size(364, 16);
            this.lblFinanzPlan.TabIndex = 66;
            this.lblFinanzPlan.Text = "Personen in der Berechnungseinheit (Haushaltsgrösse)";
            this.lblFinanzPlan.UseCompatibleTextRendering = true;
            //
            // btnAdd
            //
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(376, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 24);
            this.btnAdd.TabIndex = 67;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnRemove
            //
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(376, 290);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 24);
            this.btnRemove.TabIndex = 68;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnAddAll
            //
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(376, 320);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(26, 24);
            this.btnAddAll.TabIndex = 69;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(376, 350);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(26, 24);
            this.btnRemoveAll.TabIndex = 70;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // colBaPersonID_Add
            //
            this.colBaPersonID_Add.Caption = "Pers-Nr";
            this.colBaPersonID_Add.FieldName = "BaPersonID";
            this.colBaPersonID_Add.Name = "colBaPersonID_Add";
            this.colBaPersonID_Add.Visible = true;
            this.colBaPersonID_Add.VisibleIndex = 1;
            this.colBaPersonID_Add.Width = 60;
            //
            // colBaPersonID_Remove
            //
            this.colBaPersonID_Remove.Caption = "Pers-Nr";
            this.colBaPersonID_Remove.FieldName = "BaPersonID";
            this.colBaPersonID_Remove.Name = "colBaPersonID_Remove";
            this.colBaPersonID_Remove.OptionsColumn.AllowEdit = false;
            this.colBaPersonID_Remove.Visible = true;
            this.colBaPersonID_Remove.VisibleIndex = 2;
            this.colBaPersonID_Remove.Width = 60;
            //
            // colBeziehung_Add
            //
            this.colBeziehung_Add.Caption = "Beziehung";
            this.colBeziehung_Add.FieldName = "Beziehung";
            this.colBeziehung_Add.Name = "colBeziehung_Add";
            this.colBeziehung_Add.Visible = true;
            this.colBeziehung_Add.VisibleIndex = 2;
            this.colBeziehung_Add.Width = 80;
            //
            // colBeziehung_Remove
            //
            this.colBeziehung_Remove.Caption = "Beziehung";
            this.colBeziehung_Remove.FieldName = "Beziehung";
            this.colBeziehung_Remove.Name = "colBeziehung_Remove";
            this.colBeziehung_Remove.OptionsColumn.AllowEdit = false;
            this.colBeziehung_Remove.Visible = true;
            this.colBeziehung_Remove.VisibleIndex = 3;
            this.colBeziehung_Remove.Width = 80;
            //
            // colGeburtsdatum_Remove
            //
            this.colGeburtsdatum_Remove.Caption = "Geb. dat.";
            this.colGeburtsdatum_Remove.FieldName = "Geburtsdatum";
            this.colGeburtsdatum_Remove.Name = "colGeburtsdatum_Remove";
            this.colGeburtsdatum_Remove.OptionsColumn.AllowEdit = false;
            this.colGeburtsdatum_Remove.Visible = true;
            this.colGeburtsdatum_Remove.VisibleIndex = 4;
            this.colGeburtsdatum_Remove.Width = 70;
            //
            // colGeburtstag_Add
            //
            this.colGeburtstag_Add.Caption = "Geb. dat.";
            this.colGeburtstag_Add.FieldName = "Geburtsdatum";
            this.colGeburtstag_Add.Name = "colGeburtstag_Add";
            this.colGeburtstag_Add.Visible = true;
            this.colGeburtstag_Add.VisibleIndex = 3;
            this.colGeburtstag_Add.Width = 70;
            //
            // colIstUnterstuetzt
            //
            this.colIstUnterstuetzt.Caption = "U";
            this.colIstUnterstuetzt.ColumnEdit = this.repItemIstUnterstuetzt;
            this.colIstUnterstuetzt.FieldName = "IstUnterstuetzt";
            this.colIstUnterstuetzt.Name = "colIstUnterstuetzt";
            this.colIstUnterstuetzt.ToolTip = "ist unterstützt";
            this.colIstUnterstuetzt.Visible = true;
            this.colIstUnterstuetzt.VisibleIndex = 0;
            this.colIstUnterstuetzt.Width = 30;
            //
            // colNameVorname_Add
            //
            this.colNameVorname_Add.Caption = "Name, Vorname";
            this.colNameVorname_Add.FieldName = "NamePerson";
            this.colNameVorname_Add.Name = "colNameVorname_Add";
            this.colNameVorname_Add.Visible = true;
            this.colNameVorname_Add.VisibleIndex = 0;
            this.colNameVorname_Add.Width = 135;
            //
            // colNameVorname_Remove
            //
            this.colNameVorname_Remove.Caption = "Name, Vorname";
            this.colNameVorname_Remove.FieldName = "NamePerson";
            this.colNameVorname_Remove.Name = "colNameVorname_Remove";
            this.colNameVorname_Remove.OptionsColumn.AllowEdit = false;
            this.colNameVorname_Remove.Visible = true;
            this.colNameVorname_Remove.VisibleIndex = 1;
            this.colNameVorname_Remove.Width = 117;
            //
            // grvHaushalt
            //
            this.grvHaushalt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvHaushalt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.Empty.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.Empty.Options.UseFont = true;
            this.grvHaushalt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvHaushalt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.EvenRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvHaushalt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvHaushalt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvHaushalt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvHaushalt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvHaushalt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHaushalt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHaushalt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHaushalt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHaushalt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.GroupRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvHaushalt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvHaushalt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHaushalt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvHaushalt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvHaushalt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvHaushalt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHaushalt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvHaushalt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.OddRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvHaushalt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.Row.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.Row.Options.UseFont = true;
            this.grvHaushalt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvHaushalt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvHaushalt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvHaushalt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvHaushalt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvHaushalt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colNameVorname_Remove,
                        this.colGeburtsdatum_Remove,
                        this.colBaPersonID_Remove,
                        this.colBeziehung_Remove,
                        this.colIstUnterstuetzt});
            this.grvHaushalt.GridControl = this.grdHaushalt;
            this.grvHaushalt.Name = "grvHaushalt";
            this.grvHaushalt.OptionsCustomization.AllowFilter = false;
            this.grvHaushalt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvHaushalt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvHaushalt.OptionsView.ColumnAutoWidth = false;
            this.grvHaushalt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvHaushalt.OptionsView.ShowGroupPanel = false;
            this.grvHaushalt.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvHaushalt_CellValueChanging);
            //
            // grvKlientensystem
            //
            this.grvKlientensystem.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKlientensystem.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.Empty.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.Empty.Options.UseFont = true;
            this.grvKlientensystem.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.EvenRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKlientensystem.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKlientensystem.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKlientensystem.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKlientensystem.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKlientensystem.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientensystem.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientensystem.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientensystem.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientensystem.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.GroupRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKlientensystem.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKlientensystem.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientensystem.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKlientensystem.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKlientensystem.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKlientensystem.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientensystem.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKlientensystem.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.OddRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKlientensystem.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.Row.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.Row.Options.UseFont = true;
            this.grvKlientensystem.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKlientensystem.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKlientensystem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKlientensystem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colNameVorname_Add,
                        this.colGeburtstag_Add,
                        this.colBaPersonID_Add,
                        this.colBeziehung_Add});
            this.grvKlientensystem.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKlientensystem.GridControl = this.grdKlientensystem;
            this.grvKlientensystem.Name = "grvKlientensystem";
            this.grvKlientensystem.OptionsBehavior.Editable = false;
            this.grvKlientensystem.OptionsCustomization.AllowFilter = false;
            this.grvKlientensystem.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKlientensystem.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKlientensystem.OptionsNavigation.UseTabKey = false;
            this.grvKlientensystem.OptionsView.ColumnAutoWidth = false;
            this.grvKlientensystem.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKlientensystem.OptionsView.ShowGroupPanel = false;
            this.grvKlientensystem.OptionsView.ShowIndicator = false;
            //
            // qryHaushalt
            //
            this.qryHaushalt.CanUpdate = true;
            this.qryHaushalt.HostControl = this;
            this.qryHaushalt.SelectStatement = resources.GetString("qryHaushalt.SelectStatement");
            this.qryHaushalt.TableName = "BgFinanzplan_BaPerson";
            //
            // qryHeader
            //
            this.qryHeader.HostControl = this;
            this.qryHeader.SelectStatement = resources.GetString("qryHeader.SelectStatement");
            //
            // qryKlientensystem
            //
            this.qryKlientensystem.HostControl = this;
            this.qryKlientensystem.SelectStatement = resources.GetString("qryKlientensystem.SelectStatement");
            //
            // qryWhKennzahlen
            //
            this.qryWhKennzahlen.HostControl = this;
            this.qryWhKennzahlen.SelectStatement = "SELECT * FROM dbo.fnWhKennzahlen({0})";
            //
            // repItemIstUnterstuetzt
            //
            this.repItemIstUnterstuetzt.AutoHeight = false;
            this.repItemIstUnterstuetzt.Name = "repItemIstUnterstuetzt";
            this.repItemIstUnterstuetzt.CheckedChanged += new System.EventHandler(this.repItemIstUnterstuetzt_CheckedChanged);
            //
            // CtlWhPersonen
            //
            this.ActiveSQLQuery = this.qryHaushalt;
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFinanzPlan);
            this.Controls.Add(this.lblKlientensystem);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.grdHaushalt);
            this.Controls.Add(this.fraKennzahlen);
            this.Controls.Add(this.fraAnspechperson);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdKlientensystem);
            this.Name = "CtlWhPersonen";
            this.Size = new System.Drawing.Size(797, 462);
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.fraAnspechperson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasseHausNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort)).EndInit();
            this.fraKennzahlen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIstUnterstuetzt)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colIstUnterstuetzt;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname_Remove;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLabel edtGeburtsdatum;
        private KiSS4.Gui.KissLabel edtHeimatort;
        private KiSS4.Gui.KissLabel edtHgGrundbedarf;
        private KiSS4.Gui.KissLabel edtHgWohnkosten;
        private KiSS4.Gui.KissLabel edtNameVorname;
        private KiSS4.Gui.KissLabel edtUeGrundbedarf;
        private KiSS4.Gui.KissLabel edtUeWohnkosten;
        private KiSS4.Gui.KissLabel edtWohnsitzPLZOrt;
        private KiSS4.Gui.KissLabel edtWohnsitzStrasseHausNr;
        private KiSS4.Gui.KissGroupBox fraAnspechperson;
        private KiSS4.Gui.KissGroupBox fraKennzahlen;
        private KiSS4.Gui.KissGrid grdKlientensystem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHaushalt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKlientensystem;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel lblAdresse;
        private KiSS4.Gui.KissLabel lblFinanzPlan;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblHgGrundbedarf;
        private KiSS4.Gui.KissLabel lblHgWohnkosten;
        private KiSS4.Gui.KissLabel lblInfo1;
        private KiSS4.Gui.KissLabel lblKlientensystem;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblUeGrundbedarf;
        private KiSS4.Gui.KissLabel lblUeWohnkosten;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryHaushalt;
        private KiSS4.DB.SqlQuery qryHeader;
        private KiSS4.DB.SqlQuery qryKlientensystem;
        private KiSS4.DB.SqlQuery qryWhKennzahlen;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemIstUnterstuetzt;

        internal KiSS4.Gui.KissGrid grdHaushalt;
    }
}