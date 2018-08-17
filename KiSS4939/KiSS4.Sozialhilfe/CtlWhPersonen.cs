using System;
using System.Data;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public class CtlWhPersonen : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int BaPersonID;
        private int BgFinanzplanID;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colIstUnterstuetzt;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname_Remove;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLabel edtGeburtsdatum;
        private KiSS4.Gui.KissLabel edtHeimatort;
        private KiSS4.Gui.KissLabel edtHgGrundbedarf;
        private KiSS4.Gui.KissLabel edtHgWohnkosten;
        private KiSS4.Gui.KissLabel edtHgZuschlagI;
        private KiSS4.Gui.KissLabel edtNameVorname;
        private KiSS4.Gui.KissLabel edtUeGrundbedarf;
        private KiSS4.Gui.KissLabel edtUeWohnkosten;
        private KiSS4.Gui.KissLabel edtUeZuschlagI;
        private KiSS4.Gui.KissLabel edtWohnsitzPLZOrt;
        private KiSS4.Gui.KissLabel edtWohnsitzStrasseHausNr;
        private KiSS4.Gui.KissGroupBox fraAnspechperson;
        private KiSS4.Gui.KissGroupBox fraKennzahlen;
        private KiSS4.Gui.KissGrid grdHaushalt;
        private KiSS4.Gui.KissGrid grdKlientensystem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHaushalt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKlientensystem;
        private KiSS4.Gui.KissLabel lblAdresse;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblHaushalt;
        private KiSS4.Gui.KissLabel lblHaushaltgroesse;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblHgGrundbedarf;
        private KiSS4.Gui.KissLabel lblHgWohnkosten;
        private KiSS4.Gui.KissLabel lblHgZuschlagI;
        private KiSS4.Gui.KissLabel lblInfo1;
        private KiSS4.Gui.KissLabel lblInfo2;
        private KiSS4.Gui.KissLabel lblKlientensystem;
        private KiSS4.Gui.KissLabel lblNameVorname;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblUeGrundbedarf;
        private KiSS4.Gui.KissLabel lblUeWohnkosten;
        private KiSS4.Gui.KissLabel lblUeZuschlagI;
        private KiSS4.Gui.KissLabel lblUnterstuetzungseinheit;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryHaushalt;
        private KiSS4.DB.SqlQuery qryHeader;
        private KiSS4.DB.SqlQuery qryKlientensystem;
        private KiSS4.DB.SqlQuery qryWhKennzahlen;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemIstUnterstuetzt;

        #endregion

        #endregion

        #region Constructors

        public CtlWhPersonen()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlWhPersonen(Image titelImage, string titelText, int bgFinanzplanID, int baPersonID)
            : this()
        {
            this.picTitel.Image = titelImage;
            this.BgFinanzplanID = bgFinanzplanID;
            this.BaPersonID = baPersonID;

            this.qryHeader.Fill(qryHeader.SelectStatement, BgFinanzplanID, BaPersonID);
            this.lblTitel.Text = string.Format(this.lblTitel.Text, qryHeader["FinanzplanVon"], qryHeader["FinanzplanBis"], titelText);

            object BgBewilligungStatusCode = qryHeader["BgBewilligungStatusCode"];
            bool enable = (BgBewilligungStatusCode == null || (int)BgBewilligungStatusCode < (int)BgBewilligungStatus.Erteilt);

            btnAdd.Enabled = enable;
            btnRemove.Enabled = enable;
            btnAddAll.Enabled = enable;
            btnRemoveAll.Enabled = enable;

            if (!enable)
            {
                this.grdHaushalt.GridStyle = GridStyleType.ReadOnly;
            }

            RefreshDisplay();
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
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryHeader = new KiSS4.DB.SqlQuery(this.components);
            this.fraAnspechperson = new KiSS4.Gui.KissGroupBox();
            this.edtHeimatort = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzPLZOrt = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzStrasseHausNr = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.lblNameVorname = new KiSS4.Gui.KissLabel();
            this.edtNameVorname = new KiSS4.Gui.KissLabel();
            this.fraKennzahlen = new KiSS4.Gui.KissGroupBox();
            this.edtHgZuschlagI = new KiSS4.Gui.KissLabel();
            this.qryWhKennzahlen = new KiSS4.DB.SqlQuery(this.components);
            this.lblHgZuschlagI = new KiSS4.Gui.KissLabel();
            this.lblUnterstuetzungseinheit = new KiSS4.Gui.KissLabel();
            this.lblHaushaltgroesse = new KiSS4.Gui.KissLabel();
            this.edtUeZuschlagI = new KiSS4.Gui.KissLabel();
            this.lblUeZuschlagI = new KiSS4.Gui.KissLabel();
            this.edtUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblHaushalt = new KiSS4.Gui.KissLabel();
            this.lblKlientensystem = new KiSS4.Gui.KissLabel();
            this.lblInfo2 = new KiSS4.Gui.KissLabel();
            this.lblInfo1 = new KiSS4.Gui.KissLabel();
            this.grdHaushalt = new KiSS4.Gui.KissGrid();
            this.qryHaushalt = new KiSS4.DB.SqlQuery(this.components);
            this.grvHaushalt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIstUnterstuetzt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemIstUnterstuetzt = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNameVorname_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKlientensystem = new KiSS4.Gui.KissGrid();
            this.qryKlientensystem = new KiSS4.DB.SqlQuery(this.components);
            this.grvKlientensystem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameVorname_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHeader)).BeginInit();
            this.fraAnspechperson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasseHausNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVorname)).BeginInit();
            this.fraKennzahlen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetzungseinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltgroesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIstUnterstuetzt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientensystem)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Personen im Haushalt, vom {0:d} bis {1:d}";
            //
            // qryHeader
            //
            this.qryHeader.HostControl = this;
            this.qryHeader.SelectStatement = resources.GetString("qryHeader.SelectStatement");
            //
            // fraAnspechperson
            //
            this.fraAnspechperson.Controls.Add(this.edtHeimatort);
            this.fraAnspechperson.Controls.Add(this.edtGeburtsdatum);
            this.fraAnspechperson.Controls.Add(this.edtWohnsitzPLZOrt);
            this.fraAnspechperson.Controls.Add(this.edtWohnsitzStrasseHausNr);
            this.fraAnspechperson.Controls.Add(this.lblGeburtsdatum);
            this.fraAnspechperson.Controls.Add(this.lblHeimatort);
            this.fraAnspechperson.Controls.Add(this.lblAdresse);
            this.fraAnspechperson.Controls.Add(this.lblNameVorname);
            this.fraAnspechperson.Controls.Add(this.edtNameVorname);
            this.fraAnspechperson.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraAnspechperson.Location = new System.Drawing.Point(7, 35);
            this.fraAnspechperson.Name = "fraAnspechperson";
            this.fraAnspechperson.Size = new System.Drawing.Size(359, 112);
            this.fraAnspechperson.TabIndex = 1;
            this.fraAnspechperson.TabStop = false;
            this.fraAnspechperson.Text = "Falltr�ger/-in f�r diesen Finanzplan";
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
            //
            // lblGeburtsdatum
            //
            this.lblGeburtsdatum.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblGeburtsdatum.Location = new System.Drawing.Point(8, 72);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(80, 16);
            this.lblGeburtsdatum.TabIndex = 5;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            //
            // lblHeimatort
            //
            this.lblHeimatort.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHeimatort.Location = new System.Drawing.Point(8, 88);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(80, 16);
            this.lblHeimatort.TabIndex = 7;
            this.lblHeimatort.Text = "Heimatort";
            //
            // lblAdresse
            //
            this.lblAdresse.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAdresse.Location = new System.Drawing.Point(8, 32);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(80, 16);
            this.lblAdresse.TabIndex = 2;
            this.lblAdresse.Text = "Adresse";
            //
            // lblNameVorname
            //
            this.lblNameVorname.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblNameVorname.Location = new System.Drawing.Point(8, 16);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Size = new System.Drawing.Size(80, 16);
            this.lblNameVorname.TabIndex = 0;
            this.lblNameVorname.Text = "Name";
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
            //
            // fraKennzahlen
            //
            this.fraKennzahlen.Controls.Add(this.edtHgZuschlagI);
            this.fraKennzahlen.Controls.Add(this.lblHgZuschlagI);
            this.fraKennzahlen.Controls.Add(this.lblUnterstuetzungseinheit);
            this.fraKennzahlen.Controls.Add(this.lblHaushaltgroesse);
            this.fraKennzahlen.Controls.Add(this.edtUeZuschlagI);
            this.fraKennzahlen.Controls.Add(this.lblUeZuschlagI);
            this.fraKennzahlen.Controls.Add(this.edtUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.edtUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.edtHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblHgGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.edtHgGrundbedarf);
            this.fraKennzahlen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraKennzahlen.Location = new System.Drawing.Point(363, 35);
            this.fraKennzahlen.Name = "fraKennzahlen";
            this.fraKennzahlen.Size = new System.Drawing.Size(352, 112);
            this.fraKennzahlen.TabIndex = 2;
            this.fraKennzahlen.TabStop = false;
            this.fraKennzahlen.Text = "Kennzahlen";
            //
            // edtHgZuschlagI
            //
            this.edtHgZuschlagI.DataMember = "HgZuschlagI";
            this.edtHgZuschlagI.DataSource = this.qryWhKennzahlen;
            this.edtHgZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgZuschlagI.Location = new System.Drawing.Point(80, 72);
            this.edtHgZuschlagI.Name = "edtHgZuschlagI";
            this.edtHgZuschlagI.Size = new System.Drawing.Size(24, 16);
            this.edtHgZuschlagI.TabIndex = 13;
            //
            // qryWhKennzahlen
            //
            this.qryWhKennzahlen.HostControl = this;
            this.qryWhKennzahlen.SelectStatement = "SELECT * FROM dbo.fnWhKennzahlen({0})";
            //
            // lblHgZuschlagI
            //
            this.lblHgZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgZuschlagI.Location = new System.Drawing.Point(8, 72);
            this.lblHgZuschlagI.Name = "lblHgZuschlagI";
            this.lblHgZuschlagI.Size = new System.Drawing.Size(72, 16);
            this.lblHgZuschlagI.TabIndex = 12;
            this.lblHgZuschlagI.Text = "Zuschlag I";
            //
            // lblUnterstuetzungseinheit
            //
            this.lblUnterstuetzungseinheit.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblUnterstuetzungseinheit.Location = new System.Drawing.Point(184, 24);
            this.lblUnterstuetzungseinheit.Name = "lblUnterstuetzungseinheit";
            this.lblUnterstuetzungseinheit.Size = new System.Drawing.Size(152, 16);
            this.lblUnterstuetzungseinheit.TabIndex = 5;
            this.lblUnterstuetzungseinheit.Text = "Unterst�tzungseinheit";
            //
            // lblHaushaltgroesse
            //
            this.lblHaushaltgroesse.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblHaushaltgroesse.Location = new System.Drawing.Point(8, 24);
            this.lblHaushaltgroesse.Name = "lblHaushaltgroesse";
            this.lblHaushaltgroesse.Size = new System.Drawing.Size(120, 16);
            this.lblHaushaltgroesse.TabIndex = 0;
            this.lblHaushaltgroesse.Text = "Haushaltsgr�sse";
            //
            // edtUeZuschlagI
            //
            this.edtUeZuschlagI.DataMember = "UeZuschlagI";
            this.edtUeZuschlagI.DataSource = this.qryWhKennzahlen;
            this.edtUeZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeZuschlagI.Location = new System.Drawing.Point(256, 72);
            this.edtUeZuschlagI.Name = "edtUeZuschlagI";
            this.edtUeZuschlagI.Size = new System.Drawing.Size(24, 16);
            this.edtUeZuschlagI.TabIndex = 11;
            //
            // lblUeZuschlagI
            //
            this.lblUeZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeZuschlagI.Location = new System.Drawing.Point(184, 72);
            this.lblUeZuschlagI.Name = "lblUeZuschlagI";
            this.lblUeZuschlagI.Size = new System.Drawing.Size(72, 16);
            this.lblUeZuschlagI.TabIndex = 10;
            this.lblUeZuschlagI.Text = "Zuschlag I";
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
            //
            // lblUeWohnkosten
            //
            this.lblUeWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeWohnkosten.Location = new System.Drawing.Point(184, 56);
            this.lblUeWohnkosten.Name = "lblUeWohnkosten";
            this.lblUeWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblUeWohnkosten.TabIndex = 8;
            this.lblUeWohnkosten.Text = "Wohnkosten";
            //
            // lblUeGrundbedarf
            //
            this.lblUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeGrundbedarf.Location = new System.Drawing.Point(184, 40);
            this.lblUeGrundbedarf.Name = "lblUeGrundbedarf";
            this.lblUeGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblUeGrundbedarf.TabIndex = 6;
            this.lblUeGrundbedarf.Text = "Grundbedarf";
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
            //
            // lblHgWohnkosten
            //
            this.lblHgWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgWohnkosten.Location = new System.Drawing.Point(8, 56);
            this.lblHgWohnkosten.Name = "lblHgWohnkosten";
            this.lblHgWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblHgWohnkosten.TabIndex = 3;
            this.lblHgWohnkosten.Text = "Wohnkosten";
            //
            // lblHgGrundbedarf
            //
            this.lblHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgGrundbedarf.Location = new System.Drawing.Point(8, 40);
            this.lblHgGrundbedarf.Name = "lblHgGrundbedarf";
            this.lblHgGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblHgGrundbedarf.TabIndex = 1;
            this.lblHgGrundbedarf.Text = "Grundbedarf";
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
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            //
            // lblHaushalt
            //
            this.lblHaushalt.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblHaushalt.Location = new System.Drawing.Point(380, 202);
            this.lblHaushalt.Name = "lblHaushalt";
            this.lblHaushalt.Size = new System.Drawing.Size(328, 16);
            this.lblHaushalt.TabIndex = 66;
            this.lblHaushalt.Text = "Personen im Unterst�tzungplan (Haushaltsgr�sse)";
            //
            // lblKlientensystem
            //
            this.lblKlientensystem.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKlientensystem.Location = new System.Drawing.Point(7, 202);
            this.lblKlientensystem.Name = "lblKlientensystem";
            this.lblKlientensystem.Size = new System.Drawing.Size(328, 16);
            this.lblKlientensystem.TabIndex = 65;
            this.lblKlientensystem.Text = "Personen im Klientensystem";
            //
            // lblInfo2
            //
            this.lblInfo2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInfo2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInfo2.Location = new System.Drawing.Point(8, 432);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(707, 16);
            this.lblInfo2.TabIndex = 64;
            this.lblInfo2.Text = "Tip: Die Altersangabe in der Liste bezieht sich auf den Beginn des Unterst�tzungs" +
                "- planes, nicht auf das aktuelle Datum.";
            //
            // lblInfo1
            //
            this.lblInfo1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInfo1.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInfo1.Location = new System.Drawing.Point(7, 165);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(720, 32);
            this.lblInfo1.TabIndex = 63;
            this.lblInfo1.Text = "Alle Personen aus dem Klientensystem, welche in diesem Unterst�tzungsplan im Haus" +
                "halt leben und/oder in der Unterst�tzungseinheit sind, m�ssen in das rechte Fens" +
                "ter gesetzt werden.";
            //
            // grdHaushalt
            //
            this.grdHaushalt.DataSource = this.qryHaushalt;
            this.grdHaushalt.EmbeddedNavigator.Name = "";
            this.grdHaushalt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdHaushalt.Location = new System.Drawing.Point(380, 223);
            this.grdHaushalt.MainView = this.grvHaushalt;
            this.grdHaushalt.Name = "grdHaushalt";
            this.grdHaushalt.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemIstUnterstuetzt});
            this.grdHaushalt.Size = new System.Drawing.Size(335, 193);
            this.grdHaushalt.TabIndex = 5;
            this.grdHaushalt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHaushalt});
            this.grdHaushalt.DoubleClick += new System.EventHandler(this.grdHaushalt_DoubleClick);
            //
            // qryHaushalt
            //
            this.qryHaushalt.CanUpdate = true;
            this.qryHaushalt.HostControl = this;
            this.qryHaushalt.SelectStatement = resources.GetString("qryHaushalt.SelectStatement");
            this.qryHaushalt.TableName = "BgFinanzplan_BaPerson";
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
            this.colIstUnterstuetzt,
            this.colNameVorname_Remove,
            this.colGeburtsdatum_Remove,
            this.colAlter_Remove,
            this.colBeziehung_Remove});
            this.grvHaushalt.GridControl = this.grdHaushalt;
            this.grvHaushalt.Name = "grvHaushalt";
            this.grvHaushalt.OptionsCustomization.AllowFilter = false;
            this.grvHaushalt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvHaushalt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvHaushalt.OptionsView.ColumnAutoWidth = false;
            this.grvHaushalt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvHaushalt.OptionsView.ShowGroupPanel = false;
            //
            // colIstUnterstuetzt
            //
            this.colIstUnterstuetzt.Caption = "U";
            this.colIstUnterstuetzt.ColumnEdit = this.repItemIstUnterstuetzt;
            this.colIstUnterstuetzt.FieldName = "IstUnterstuetzt";
            this.colIstUnterstuetzt.Name = "colIstUnterstuetzt";
            this.colIstUnterstuetzt.ToolTip = "ist unterst�tzt";
            this.colIstUnterstuetzt.Visible = true;
            this.colIstUnterstuetzt.VisibleIndex = 0;
            this.colIstUnterstuetzt.Width = 30;
            //
            // repItemIstUnterstuetzt
            //
            this.repItemIstUnterstuetzt.AutoHeight = false;
            this.repItemIstUnterstuetzt.Name = "repItemIstUnterstuetzt";
            this.repItemIstUnterstuetzt.CheckedChanged += new System.EventHandler(this.repItemIstUnterstuetzt_CheckedChanged);
            //
            // colNameVorname_Remove
            //
            this.colNameVorname_Remove.Caption = "Name";
            this.colNameVorname_Remove.FieldName = "NameVorname";
            this.colNameVorname_Remove.Name = "colNameVorname_Remove";
            this.colNameVorname_Remove.OptionsColumn.AllowEdit = false;
            this.colNameVorname_Remove.Visible = true;
            this.colNameVorname_Remove.VisibleIndex = 1;
            this.colNameVorname_Remove.Width = 135;
            //
            // colGeburtsdatum_Remove
            //
            this.colGeburtsdatum_Remove.Caption = "Geb. dat.";
            this.colGeburtsdatum_Remove.FieldName = "Geburtsdatum";
            this.colGeburtsdatum_Remove.Name = "colGeburtsdatum_Remove";
            this.colGeburtsdatum_Remove.OptionsColumn.AllowEdit = false;
            this.colGeburtsdatum_Remove.Visible = true;
            this.colGeburtsdatum_Remove.VisibleIndex = 2;
            this.colGeburtsdatum_Remove.Width = 70;
            //
            // colAlter_Remove
            //
            this.colAlter_Remove.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter_Remove.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAlter_Remove.Caption = "Alter";
            this.colAlter_Remove.FieldName = "Alter";
            this.colAlter_Remove.Name = "colAlter_Remove";
            this.colAlter_Remove.OptionsColumn.AllowEdit = false;
            this.colAlter_Remove.Visible = true;
            this.colAlter_Remove.VisibleIndex = 3;
            this.colAlter_Remove.Width = 40;
            //
            // colBeziehung_Remove
            //
            this.colBeziehung_Remove.Caption = "Beziehung";
            this.colBeziehung_Remove.FieldName = "Beziehung";
            this.colBeziehung_Remove.Name = "colBeziehung_Remove";
            this.colBeziehung_Remove.OptionsColumn.AllowEdit = false;
            this.colBeziehung_Remove.Visible = true;
            this.colBeziehung_Remove.VisibleIndex = 4;
            this.colBeziehung_Remove.Width = 80;
            //
            // grdKlientensystem
            //
            this.grdKlientensystem.DataSource = this.qryKlientensystem;
            this.grdKlientensystem.EmbeddedNavigator.Name = "";
            this.grdKlientensystem.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKlientensystem.Location = new System.Drawing.Point(7, 223);
            this.grdKlientensystem.MainView = this.grvKlientensystem;
            this.grdKlientensystem.Name = "grdKlientensystem";
            this.grdKlientensystem.Size = new System.Drawing.Size(335, 193);
            this.grdKlientensystem.TabIndex = 0;
            this.grdKlientensystem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKlientensystem});
            this.grdKlientensystem.DoubleClick += new System.EventHandler(this.grdKlientensystem_DoubleClick);
            //
            // qryKlientensystem
            //
            this.qryKlientensystem.HostControl = this;
            this.qryKlientensystem.SelectStatement = resources.GetString("qryKlientensystem.SelectStatement");
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
            this.colAlter_Add,
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
            // colNameVorname_Add
            //
            this.colNameVorname_Add.Caption = "Name";
            this.colNameVorname_Add.FieldName = "NameVorname";
            this.colNameVorname_Add.Name = "colNameVorname_Add";
            this.colNameVorname_Add.Visible = true;
            this.colNameVorname_Add.VisibleIndex = 0;
            this.colNameVorname_Add.Width = 135;
            //
            // colGeburtstag_Add
            //
            this.colGeburtstag_Add.Caption = "Geb. dat.";
            this.colGeburtstag_Add.FieldName = "Geburtsdatum";
            this.colGeburtstag_Add.Name = "colGeburtstag_Add";
            this.colGeburtstag_Add.Visible = true;
            this.colGeburtstag_Add.VisibleIndex = 1;
            this.colGeburtstag_Add.Width = 70;
            //
            // colAlter_Add
            //
            this.colAlter_Add.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter_Add.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAlter_Add.Caption = "Alter";
            this.colAlter_Add.FieldName = "Alter";
            this.colAlter_Add.Name = "colAlter_Add";
            this.colAlter_Add.Visible = true;
            this.colAlter_Add.VisibleIndex = 2;
            this.colAlter_Add.Width = 40;
            //
            // colBeziehung_Add
            //
            this.colBeziehung_Add.Caption = "Beziehung";
            this.colBeziehung_Add.FieldName = "Beziehung";
            this.colBeziehung_Add.Name = "colBeziehung_Add";
            this.colBeziehung_Add.Visible = true;
            this.colBeziehung_Add.VisibleIndex = 3;
            this.colBeziehung_Add.Width = 80;
            //
            // btnAddAll
            //
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(347, 317);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 3;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(347, 347);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 4;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // btnAdd
            //
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(347, 257);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnRemove
            //
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(347, 287);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // CtlWhPersonen
            //
            this.ActiveSQLQuery = this.qryHaushalt;
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblHaushalt);
            this.Controls.Add(this.lblKlientensystem);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.grdHaushalt);
            this.Controls.Add(this.grdKlientensystem);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.fraKennzahlen);
            this.Controls.Add(this.fraAnspechperson);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlWhPersonen";
            this.Size = new System.Drawing.Size(721, 456);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHeader)).EndInit();
            this.fraAnspechperson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasseHausNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVorname)).EndInit();
            this.fraKennzahlen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHgZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetzungseinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltgroesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIstUnterstuetzt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientensystem)).EndInit();
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

        private void btnAddAll_Click(object sender, System.EventArgs e)
        {
            string baPersonIdCsv = string.Empty;
            foreach (DataRow row in qryKlientensystem.DataTable.Rows)
            {
                DBUtil.ExecSQL("INSERT INTO BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt) VALUES ({0}, {1}, 1)"
                    , this.BgFinanzplanID, row["BaPersonID"]);
                baPersonIdCsv += "," + row["BaPersonID"].ToString();
            }

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", this.BgFinanzplanID);
            ShUtil.CreateTaskForDoubleSupport_NeueSozialhilfe(Session.User.UserID, baPersonIdCsv.Substring(1));
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            RefreshDisplay();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (qryKlientensystem.IsEmpty)
            {
                return;
            }

            DBUtil.ExecSQL("INSERT INTO BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt) VALUES ({0}, {1}, 1)"
                , this.BgFinanzplanID, qryKlientensystem["BaPersonID"]);

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", this.BgFinanzplanID);
            ShUtil.CreateTaskForDoubleSupport_NeueSozialhilfe(Session.User.UserID, qryKlientensystem["BaPersonID"].ToString());
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            RefreshDisplay();
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            if (qryHaushalt.IsEmpty)
            {
                return;
            }

            DBUtil.ExecSQL("DELETE BgFinanzplan_BaPerson WHERE BgFinanzplanID = {0}"
                , this.BgFinanzplanID);

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", this.BgFinanzplanID);

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            RefreshDisplay();
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (qryHaushalt.IsEmpty)
            {
                return;
            }

            DBUtil.ExecSQL("DELETE BgFinanzplan_BaPerson WHERE BgFinanzplanID = {0} AND BaPersonID = {1}"
                , this.BgFinanzplanID, qryHaushalt["BaPersonID"]);

            DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", this.BgFinanzplanID);

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            RefreshDisplay();
        }

        private void grdHaushalt_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.btnRemove.Enabled)
            {
                this.btnRemove.PerformClick();
            }
        }

        private void grdKlientensystem_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.btnAdd.Enabled)
            {
                this.btnAdd.PerformClick();
            }
        }

        private void repItemIstUnterstuetzt_CheckedChanged(object sender, EventArgs e)
        {
            if (qryHaushalt.CanUpdate && grvHaushalt.FocusedColumn.FieldName == "IstUnterstuetzt")
            {
                if (qryHaushalt.Post())
                {
                    DBUtil.ExecSQL("EXECUTE spWhFinanzplan_Update {0}", this.BgFinanzplanID);
                    qryWhKennzahlen.Refresh();
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            base.OnRefreshData();
            qryHeader.Refresh();
            qryKlientensystem.Refresh();
            qryWhKennzahlen.Refresh();
        }

        #endregion

        #region Private Methods

        private void RefreshDisplay()
        {
            qryWhKennzahlen.Fill(BgFinanzplanID);

            qryKlientensystem.Fill(qryKlientensystem.SelectStatement, BgFinanzplanID, BaPersonID);
            qryHaushalt.Fill(BgFinanzplanID);
        }

        #endregion

        #endregion
    }
}