using System;

using KiSS4.DB;

namespace KiSS4.Query
{
    public class CtlQueryFaFaelleProMitarbeiterInklIntake : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbgeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatortKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colIntakeAnmeldedatum;
        private DevExpress.XtraGrid.Columns.GridColumn colIntakeEingangsbesttigung;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colNNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtKlient;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KiSS4.Gui.KissCheckEdit edtNurAktive;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblKlientIn;
        private KiSS4.Gui.KissLabel lblModul;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblSektion;
        private KiSS4.Gui.KissLabel lblZeitraumvon;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryFaFaelleProMitarbeiterInklIntake()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"select Code = OrgUnitID, Text = ItemName from XOrgUnit
            order by ItemName");
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaFaelleProMitarbeiterInklIntake));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblZeitraumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblKlientIn = new KiSS4.Gui.KissLabel();
            this.lblModul = new KiSS4.Gui.KissLabel();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtKlient = new KiSS4.Gui.KissTextEdit();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.colAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatortKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntakeAnmeldedatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntakeEingangsbesttigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, KissMsg.GetMLMessage("CtlQueryFaFaelleProMitarbeiterInklIntake","dokumentOeffnen", "Dokument öffnen") )});
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            //
            // tabControlSearch
            //
            this.tabControlSearch.SelectedTabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtNurAktive);
            this.tpgSuchen.Controls.Add(this.edtModulID);
            this.tpgSuchen.Controls.Add(this.edtKlient);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Controls.Add(this.lblModul);
            this.tpgSuchen.Controls.Add(this.lblKlientIn);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumvon);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlientIn, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblModul, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktive, 0);
            //
            // lblSektion
            //
            this.lblSektion.Location = new System.Drawing.Point(10, 40);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(130, 24);
            this.lblSektion.TabIndex = 1;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 70);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 2;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // lblZeitraumvon
            //
            this.lblZeitraumvon.Location = new System.Drawing.Point(10, 100);
            this.lblZeitraumvon.Name = "lblZeitraumvon";
            this.lblZeitraumvon.Size = new System.Drawing.Size(130, 24);
            this.lblZeitraumvon.TabIndex = 3;
            this.lblZeitraumvon.Text = "Zeitraum von";
            this.lblZeitraumvon.UseCompatibleTextRendering = true;
            //
            // lblbis
            //
            this.lblbis.Location = new System.Drawing.Point(270, 100);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 4;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            //
            // lblKlientIn
            //
            this.lblKlientIn.Location = new System.Drawing.Point(10, 130);
            this.lblKlientIn.Name = "lblKlientIn";
            this.lblKlientIn.Size = new System.Drawing.Size(130, 24);
            this.lblKlientIn.TabIndex = 5;
            this.lblKlientIn.Text = "KlientIn";
            this.lblKlientIn.UseCompatibleTextRendering = true;
            //
            // lblModul
            //
            this.lblModul.Location = new System.Drawing.Point(10, 160);
            this.lblModul.Name = "lblModul";
            this.lblModul.Size = new System.Drawing.Size(130, 24);
            this.lblModul.TabIndex = 6;
            this.lblModul.Text = "Modul";
            this.lblModul.UseCompatibleTextRendering = true;
            //
            // edtOrgUnitID
            //
            this.edtOrgUnitID.Location = new System.Drawing.Point(150, 40);
            this.edtOrgUnitID.Name = "edtOrgUnitID";
            this.edtOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(250, 24);
            this.edtOrgUnitID.TabIndex = 20;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 70);
            this.edtUserID.LookupSQL = "select ID = UserID, SAR = LastName + isNull(\', \' + FirstName,\'\'), [Kuerzel] = Log" +
    "onName\r\nfrom   XUser \r\nwhere LastName + isNull(\', \' + FirstName,\'\') like {0} + \'" +
    "%\' \r\norder by SAR";
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(250, 24);
            this.edtUserID.TabIndex = 21;
            //
            // edtDatumVon
            //
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 100);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 22;
            //
            // edtDatumBis
            //
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(300, 100);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 23;
            //
            // edtKlient
            //
            this.edtKlient.Location = new System.Drawing.Point(150, 130);
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlient.Size = new System.Drawing.Size(250, 24);
            this.edtKlient.TabIndex = 24;
            //
            // edtModulID
            //
            this.edtModulID.Location = new System.Drawing.Point(150, 160);
            this.edtModulID.LOVFilter = "ModulTree = 1 AND Licensed = 1 AND ModulID > 1";
            this.edtModulID.LOVFilterWhereAppend = true;
            this.edtModulID.LOVName = "Modul";
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Size = new System.Drawing.Size(250, 24);
            this.edtModulID.TabIndex = 25;
            //
            // edtNurAktive
            //
            this.edtNurAktive.EditValue = false;
            this.edtNurAktive.Location = new System.Drawing.Point(150, 190);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = KissMsg.GetMLMessage("CtlQueryFaFaelleProMitarbeiterInklIntake", "edtNurAktiveCaption", "nur aktive");
            this.edtNurAktive.Size = new System.Drawing.Size(250, 19);
            this.edtNurAktive.TabIndex = 26;
            //
            // colAbgeschlossen
            //
            this.colAbgeschlossen.Name = "colAbgeschlossen";
            //
            // colAHVNummer
            //
            this.colAHVNummer.Name = "colAHVNummer";
            //
            // colErffnet
            //
            this.colErffnet.Name = "colErffnet";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colGeschlecht
            //
            this.colGeschlecht.Name = "colGeschlecht";
            //
            // colHeimatort
            //
            this.colHeimatort.Name = "colHeimatort";
            //
            // colHeimatortKanton
            //
            this.colHeimatortKanton.Name = "colHeimatortKanton";
            //
            // colIntakeAnmeldedatum
            //
            this.colIntakeAnmeldedatum.Name = "colIntakeAnmeldedatum";
            //
            // colIntakeEingangsbesttigung
            //
            this.colIntakeEingangsbesttigung.Name = "colIntakeEingangsbesttigung";
            //
            // colKanton
            //
            this.colKanton.Name = "colKanton";
            //
            // colModul
            //
            this.colModul.Name = "colModul";
            //
            // colNationalitt
            //
            this.colNationalitt.Name = "colNationalitt";
            //
            // colNNummer
            //
            this.colNNummer.Name = "colNNummer";
            //
            // colOrt
            //
            this.colOrt.Name = "colOrt";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colPLZ
            //
            this.colPLZ.Name = "colPLZ";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colSektion
            //
            this.colSektion.Name = "colSektion";
            //
            // colStrasse
            //
            this.colStrasse.Name = "colStrasse";
            //
            // colStrasseNr
            //
            this.colStrasseNr.Name = "colStrasseNr";
            //
            // colZivilstand
            //
            this.colZivilstand.Name = "colZivilstand";
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            // CtlQueryFaFaelleProMitarbeiterInklIntake
            //
            this.Name = "CtlQueryFaFaelleProMitarbeiterInklIntake";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { Session.User.LogonName, Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;
            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #endregion
    }
}