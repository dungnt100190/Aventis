using System;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryVmVerlaufVaterschaften : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAnerkennung;
        private DevExpress.XtraGrid.Columns.GridColumn colAnfechtung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag1;
        private DevExpress.XtraGrid.Columns.GridColumn colErlassderGebhr;
        private DevExpress.XtraGrid.Columns.GridColumn colFallabschlussVM;
        private DevExpress.XtraGrid.Columns.GridColumn colFallerffnungVM;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGenehmigungEKSK;
        private DevExpress.XtraGrid.Columns.GridColumn colMandantin;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatstrger;
        private DevExpress.XtraGrid.Columns.GridColumn colMutter;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colSchlussberanEKSK;
        private DevExpress.XtraGrid.Columns.GridColumn colSorgerechtVereinb;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterhaltsurteil;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterhaltsvertrag;
        private DevExpress.XtraGrid.Columns.GridColumn colVater;
        private DevExpress.XtraGrid.Columns.GridColumn colVaterschaftsurteil;
        private DevExpress.XtraGrid.Columns.GridColumn colZGBArt;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungGebhr;
        private DevExpress.XtraGrid.Columns.GridColumn colarchiviert;
        private KiSS4.Gui.KissDateEdit edtAbschlussDatumBis;
        private KiSS4.Gui.KissDateEdit edtAbschlussDatumVon;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissDateEdit edtEroeffnungsDatumBis;
        private KiSS4.Gui.KissDateEdit edtEroeffnungsDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtStatusCode;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lbl;
        private KiSS4.Gui.KissLabel lbl1;
        private KiSS4.Gui.KissLabel lblAbschlussdatumvon;
        private KiSS4.Gui.KissLabel lblEroeffnungsdatumvon;
        private KiSS4.Gui.KissLabel lblFallstatus;
        private KiSS4.Gui.KissLabel lblMandantin;
        private KiSS4.Gui.KissLabel lblMandatstraegerin;

        #endregion

        #region Constructors

        public CtlQueryVmVerlaufVaterschaften()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL( @"select Code = 1, Text = 'aktiv'
            union all
            select Code = 2, Text = 'abgeschlossen'
            union all
            select Code = 3, Text = 'archiviert'" );
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow,0);
            NewRow.AcceptChanges();
            edtStatusCode.Properties.Columns.Clear();
            edtStatusCode.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
            edtStatusCode.Properties.ShowFooter = false;
            edtStatusCode.Properties.ShowHeader = false;
            edtStatusCode.Properties.DisplayMember = "Text";
            edtStatusCode.Properties.ValueMember = "Code";
            edtStatusCode.Properties.DropDownRows = Math.Min( qry.Count, 7 );
            edtStatusCode.Properties.DataSource = qry;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmVerlaufVaterschaften));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblMandatstraegerin = new KiSS4.Gui.KissLabel();
            this.lblMandantin = new KiSS4.Gui.KissLabel();
            this.lblEroeffnungsdatumvon = new KiSS4.Gui.KissLabel();
            this.lbl = new KiSS4.Gui.KissLabel();
            this.lblAbschlussdatumvon = new KiSS4.Gui.KissLabel();
            this.lbl1 = new KiSS4.Gui.KissLabel();
            this.lblFallstatus = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtEroeffnungsDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtEroeffnungsDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtAbschlussDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtAbschlussDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnerkennung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnfechtung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarchiviert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErlassderGebhr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallabschlussVM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallerffnungVM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenehmigungEKSK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandantin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatstrger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMutter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchlussberanEKSK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSorgerechtVereinb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterhaltsurteil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterhaltsvertrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVaterschaftsurteil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungGebhr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZGBArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsdatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussdatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode.Properties)).BeginInit();
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
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtStatusCode);
            this.tpgSuchen.Controls.Add(this.edtAbschlussDatumBis);
            this.tpgSuchen.Controls.Add(this.edtAbschlussDatumVon);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungsDatumBis);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungsDatumVon);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblFallstatus);
            this.tpgSuchen.Controls.Add(this.lbl1);
            this.tpgSuchen.Controls.Add(this.lblAbschlussdatumvon);
            this.tpgSuchen.Controls.Add(this.lbl);
            this.tpgSuchen.Controls.Add(this.lblEroeffnungsdatumvon);
            this.tpgSuchen.Controls.Add(this.lblMandantin);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegerin);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegerin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandantin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEroeffnungsdatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAbschlussdatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFallstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungsDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungsDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbschlussDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbschlussDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusCode, 0);
            //
            // lblMandatstraegerin
            //
            this.lblMandatstraegerin.Location = new System.Drawing.Point(10, 40);
            this.lblMandatstraegerin.Name = "lblMandatstraegerin";
            this.lblMandatstraegerin.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegerin.TabIndex = 1;
            this.lblMandatstraegerin.Text = "Mandatstraeger/-in";
            this.lblMandatstraegerin.UseCompatibleTextRendering = true;
            //
            // lblMandantin
            //
            this.lblMandantin.Location = new System.Drawing.Point(10, 70);
            this.lblMandantin.Name = "lblMandantin";
            this.lblMandantin.Size = new System.Drawing.Size(130, 24);
            this.lblMandantin.TabIndex = 2;
            this.lblMandantin.Text = "Mandant/-in";
            this.lblMandantin.UseCompatibleTextRendering = true;
            //
            // lblEroeffnungsdatumvon
            //
            this.lblEroeffnungsdatumvon.Location = new System.Drawing.Point(10, 100);
            this.lblEroeffnungsdatumvon.Name = "lblEroeffnungsdatumvon";
            this.lblEroeffnungsdatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblEroeffnungsdatumvon.TabIndex = 3;
            this.lblEroeffnungsdatumvon.Text = "Eroeffnungsdatum von";
            this.lblEroeffnungsdatumvon.UseCompatibleTextRendering = true;
            //
            // lbl
            //
            this.lbl.Location = new System.Drawing.Point(258, 100);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(130, 24);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "-";
            this.lbl.UseCompatibleTextRendering = true;
            //
            // lblAbschlussdatumvon
            //
            this.lblAbschlussdatumvon.Location = new System.Drawing.Point(10, 130);
            this.lblAbschlussdatumvon.Name = "lblAbschlussdatumvon";
            this.lblAbschlussdatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblAbschlussdatumvon.TabIndex = 5;
            this.lblAbschlussdatumvon.Text = "Abschlussdatum von";
            this.lblAbschlussdatumvon.UseCompatibleTextRendering = true;
            //
            // lbl1
            //
            this.lbl1.Location = new System.Drawing.Point(258, 130);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(130, 24);
            this.lbl1.TabIndex = 6;
            this.lbl1.Text = "-";
            this.lbl1.UseCompatibleTextRendering = true;
            //
            // lblFallstatus
            //
            this.lblFallstatus.Location = new System.Drawing.Point(10, 160);
            this.lblFallstatus.Name = "lblFallstatus";
            this.lblFallstatus.Size = new System.Drawing.Size(130, 24);
            this.lblFallstatus.TabIndex = 7;
            this.lblFallstatus.Text = "Fallstatus";
            this.lblFallstatus.UseCompatibleTextRendering = true;
            //
            // edtUserID
            //
            this.edtUserID.EditValue = "";
            this.edtUserID.Location = new System.Drawing.Point(150, 40);
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
            this.edtUserID.Size = new System.Drawing.Size(200, 24);
            this.edtUserID.TabIndex = 20;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.EditValue = "";
            this.edtBaPersonID.Location = new System.Drawing.Point(150, 70);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(200, 24);
            this.edtBaPersonID.TabIndex = 21;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            //
            // edtEroeffnungsDatumVon
            //
            this.edtEroeffnungsDatumVon.EditValue = "";
            this.edtEroeffnungsDatumVon.Location = new System.Drawing.Point(150, 100);
            this.edtEroeffnungsDatumVon.Name = "edtEroeffnungsDatumVon";
            this.edtEroeffnungsDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungsDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungsDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungsDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungsDatumVon.Properties.ShowToday = false;
            this.edtEroeffnungsDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungsDatumVon.TabIndex = 22;
            //
            // edtEroeffnungsDatumBis
            //
            this.edtEroeffnungsDatumBis.EditValue = "";
            this.edtEroeffnungsDatumBis.Location = new System.Drawing.Point(270, 100);
            this.edtEroeffnungsDatumBis.Name = "edtEroeffnungsDatumBis";
            this.edtEroeffnungsDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungsDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungsDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungsDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungsDatumBis.Properties.ShowToday = false;
            this.edtEroeffnungsDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungsDatumBis.TabIndex = 23;
            //
            // edtAbschlussDatumVon
            //
            this.edtAbschlussDatumVon.EditValue = "";
            this.edtAbschlussDatumVon.Location = new System.Drawing.Point(150, 130);
            this.edtAbschlussDatumVon.Name = "edtAbschlussDatumVon";
            this.edtAbschlussDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtAbschlussDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbschlussDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtAbschlussDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussDatumVon.Properties.ShowToday = false;
            this.edtAbschlussDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtAbschlussDatumVon.TabIndex = 24;
            //
            // edtAbschlussDatumBis
            //
            this.edtAbschlussDatumBis.EditValue = "";
            this.edtAbschlussDatumBis.Location = new System.Drawing.Point(270, 130);
            this.edtAbschlussDatumBis.Name = "edtAbschlussDatumBis";
            this.edtAbschlussDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtAbschlussDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbschlussDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtAbschlussDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussDatumBis.Properties.ShowToday = false;
            this.edtAbschlussDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtAbschlussDatumBis.TabIndex = 25;
            //
            // edtStatusCode
            //
            this.edtStatusCode.Location = new System.Drawing.Point(150, 160);
            this.edtStatusCode.Name = "edtStatusCode";
            this.edtStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusCode.Properties.NullText = "";
            this.edtStatusCode.Properties.ShowFooter = false;
            this.edtStatusCode.Properties.ShowHeader = false;
            this.edtStatusCode.Size = new System.Drawing.Size(150, 24);
            this.edtStatusCode.TabIndex = 26;
            //
            // colAbschlussgrund
            //
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            //
            // colAnerkennung
            //
            this.colAnerkennung.Name = "colAnerkennung";
            //
            // colAnfechtung
            //
            this.colAnfechtung.Name = "colAnfechtung";
            //
            // colarchiviert
            //
            this.colarchiviert.Name = "colarchiviert";
            //
            // colBetrag
            //
            this.colBetrag.Name = "colBetrag";
            //
            // colBetrag1
            //
            this.colBetrag1.Name = "colBetrag1";
            //
            // colErlassderGebhr
            //
            this.colErlassderGebhr.Name = "colErlassderGebhr";
            //
            // colFallabschlussVM
            //
            this.colFallabschlussVM.Name = "colFallabschlussVM";
            //
            // colFallerffnungVM
            //
            this.colFallerffnungVM.Name = "colFallerffnungVM";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colGenehmigungEKSK
            //
            this.colGenehmigungEKSK.Name = "colGenehmigungEKSK";
            //
            // colMandantin
            //
            this.colMandantin.Name = "colMandantin";
            //
            // colMandatstrger
            //
            this.colMandatstrger.Name = "colMandatstrger";
            //
            // colMutter
            //
            this.colMutter.Name = "colMutter";
            //
            // colOrt
            //
            this.colOrt.Name = "colOrt";
            //
            // colSchlussberanEKSK
            //
            this.colSchlussberanEKSK.Name = "colSchlussberanEKSK";
            //
            // colSorgerechtVereinb
            //
            this.colSorgerechtVereinb.Name = "colSorgerechtVereinb";
            //
            // colUnterhaltsurteil
            //
            this.colUnterhaltsurteil.Name = "colUnterhaltsurteil";
            //
            // colUnterhaltsvertrag
            //
            this.colUnterhaltsvertrag.Name = "colUnterhaltsvertrag";
            //
            // colVater
            //
            this.colVater.Name = "colVater";
            //
            // colVaterschaftsurteil
            //
            this.colVaterschaftsurteil.Name = "colVaterschaftsurteil";
            //
            // colZahlungGebhr
            //
            this.colZahlungGebhr.Name = "colZahlungGebhr";
            //
            // colZGBArt
            //
            this.colZGBArt.Name = "colZGBArt";
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
            // CtlQueryVmVerlaufVaterschaften
            //
            this.Name = "CtlQueryVmVerlaufVaterschaften";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsdatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussdatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Private Methods

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                        edtBaPersonID.EditValue = null;
                        edtBaPersonID.LookupID = null;
              		return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select distinct ID = PRS.BaPersonID,
                    MandantIn = PRS.NameVorname
                from   vwPerson PRS
                inner join FaLeistung FAL on FAL.BaPersonID = PRS.BaPersonID
                                      and FAL.ModulID = 5
                                      and FAL.FaProzessCode = 502
                where PRS.NameVorname like {0} + '%'
                order by PRS.NameVorname",
              SearchString,
              e.ButtonClicked,null,null,null);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                        edtUserID.EditValue = null;
                        edtUserID.LookupID = null;
              		return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}