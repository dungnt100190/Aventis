using System;
using KiSS4.DB;

namespace KiSS4.Query
{
    public class CtlQueryShFinanzplaene : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzBewAnfragen;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzBewAntworten;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnungsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colFinanzplanNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKlientIn;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn coleffektivbis;
        private DevExpress.XtraGrid.Columns.GridColumn coleffektivvon;
        private DevExpress.XtraGrid.Columns.GridColumn colgeplantbis;
        private DevExpress.XtraGrid.Columns.GridColumn colgeplantvon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtAbschlussDatumBis;
        private KiSS4.Gui.KissDateEdit edtAbschlussDatumVon;
        private KiSS4.Gui.KissDateEdit edtAbschlussGeplantBis;
        private KiSS4.Gui.KissDateEdit edtAbschlussGeplantVon;
        private KiSS4.Gui.KissLookUpEdit edtBgBewilligungStatusCode;
        private KiSS4.Gui.KissDateEdit edtEroeffnungDatumBis;
        private KiSS4.Gui.KissDateEdit edtEroeffnungDatumVon;
        private KiSS4.Gui.KissDateEdit edtEroeffnungGeplantBis;
        private KiSS4.Gui.KissDateEdit edtEroeffnungGeplantVon;
        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissCheckEdit edtLastFinanzPlan;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissLookUpEdit edtShGrundbedarfTypCode;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblAbschlussgeplantvon;
        private KiSS4.Gui.KissLabel lblAbschlussvon;
        private KiSS4.Gui.KissLabel lblAktivinJahr;
        private KiSS4.Gui.KissLabel lblBerechnungsgrundlage;
        private KiSS4.Gui.KissLabel lblEroeffnunggeplantvon;
        private KiSS4.Gui.KissLabel lblEroeffnungvon;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblSektion;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblbis1;
        private KiSS4.Gui.KissLabel lblbis2;
        private KiSS4.Gui.KissLabel lblbis3;
        private KiSS4.DB.SqlQuery sqlQuery1;

        #endregion

        #region Constructors

        public CtlQueryShFinanzplaene()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL( @"select Code = OrgUnitID, Text = ItemName from XOrgUnit
                         where ModulID = 3
                         order by ItemName" );
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow,0);
            NewRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min( qry.Count, 7 );
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryShFinanzplaene));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblBerechnungsgrundlage = new KiSS4.Gui.KissLabel();
            this.edtShGrundbedarfTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.edtBgBewilligungStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblEroeffnungvon = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblAbschlussvon = new KiSS4.Gui.KissLabel();
            this.edtAbschlussDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis1 = new KiSS4.Gui.KissLabel();
            this.edtAbschlussDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblAktivinJahr = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblEroeffnunggeplantvon = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungGeplantVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis2 = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungGeplantBis = new KiSS4.Gui.KissDateEdit();
            this.lblAbschlussgeplantvon = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGeplantVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis3 = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGeplantBis = new KiSS4.Gui.KissDateEdit();
            this.edtLastFinanzPlan = new KiSS4.Gui.KissCheckEdit();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzBewAnfragen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzBewAntworten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleffektivbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleffektivvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnungsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinanzplanNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgeplantbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgeplantvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlientIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerechnungsgrundlage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShGrundbedarfTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShGrundbedarfTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktivinJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnunggeplantvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungGeplantVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungGeplantBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgeplantvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGeplantVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGeplantBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLastFinanzPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
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
            this.ctlGotoFall.DataMember = "BaPersonID$";
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtLastFinanzPlan);
            this.tpgSuchen.Controls.Add(this.edtAbschlussGeplantBis);
            this.tpgSuchen.Controls.Add(this.lblbis3);
            this.tpgSuchen.Controls.Add(this.edtAbschlussGeplantVon);
            this.tpgSuchen.Controls.Add(this.lblAbschlussgeplantvon);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungGeplantBis);
            this.tpgSuchen.Controls.Add(this.lblbis2);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungGeplantVon);
            this.tpgSuchen.Controls.Add(this.lblEroeffnunggeplantvon);
            this.tpgSuchen.Controls.Add(this.edtJahr);
            this.tpgSuchen.Controls.Add(this.lblAktivinJahr);
            this.tpgSuchen.Controls.Add(this.edtAbschlussDatumBis);
            this.tpgSuchen.Controls.Add(this.lblbis1);
            this.tpgSuchen.Controls.Add(this.edtAbschlussDatumVon);
            this.tpgSuchen.Controls.Add(this.lblAbschlussvon);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungDatumBis);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungDatumVon);
            this.tpgSuchen.Controls.Add(this.lblEroeffnungvon);
            this.tpgSuchen.Controls.Add(this.edtBgBewilligungStatusCode);
            this.tpgSuchen.Controls.Add(this.lblStatus);
            this.tpgSuchen.Controls.Add(this.edtShGrundbedarfTypCode);
            this.tpgSuchen.Controls.Add(this.lblBerechnungsgrundlage);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBerechnungsgrundlage, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtShGrundbedarfTypCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgBewilligungStatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEroeffnungvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAbschlussvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbschlussDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbschlussDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAktivinJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEroeffnunggeplantvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungGeplantVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungGeplantBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAbschlussgeplantvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbschlussGeplantVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbschlussGeplantBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLastFinanzPlan, 0);
            //
            // lblSektion
            //
            this.lblSektion.Location = new System.Drawing.Point(10, 40);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(130, 24);
            this.lblSektion.TabIndex = 0;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
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
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(250, 24);
            this.edtOrgUnitID.TabIndex = 1;
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
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 70);
            this.edtUserID.LookupSQL = "select ID = UserID, \r\nSAR = LastName + isNull(\', \' + FirstName,\'\'), \r\n[Kuerzel] =" +
                " LogonName\nfrom   XUser where LastName + isNull(\', \' + FirstName,\'\') like isNull" +
                "({0},\'\') + \'%\' \norder by SAR";
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
            this.edtUserID.TabIndex = 3;
            //
            // lblBerechnungsgrundlage
            //
            this.lblBerechnungsgrundlage.Location = new System.Drawing.Point(10, 100);
            this.lblBerechnungsgrundlage.Name = "lblBerechnungsgrundlage";
            this.lblBerechnungsgrundlage.Size = new System.Drawing.Size(130, 24);
            this.lblBerechnungsgrundlage.TabIndex = 4;
            this.lblBerechnungsgrundlage.Text = "Berechnungsgrundlage";
            this.lblBerechnungsgrundlage.UseCompatibleTextRendering = true;
            //
            // edtShGrundbedarfTypCode
            //
            this.edtShGrundbedarfTypCode.Location = new System.Drawing.Point(150, 100);
            this.edtShGrundbedarfTypCode.LOVName = "WhGrundbedarfTyp";
            this.edtShGrundbedarfTypCode.Name = "edtShGrundbedarfTypCode";
            this.edtShGrundbedarfTypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtShGrundbedarfTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtShGrundbedarfTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtShGrundbedarfTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtShGrundbedarfTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtShGrundbedarfTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtShGrundbedarfTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtShGrundbedarfTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtShGrundbedarfTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtShGrundbedarfTypCode.Properties.NullText = "";
            this.edtShGrundbedarfTypCode.Properties.ShowFooter = false;
            this.edtShGrundbedarfTypCode.Properties.ShowHeader = false;
            this.edtShGrundbedarfTypCode.Size = new System.Drawing.Size(250, 24);
            this.edtShGrundbedarfTypCode.TabIndex = 5;
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(10, 130);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(130, 24);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            //
            // edtBgBewilligungStatusCode
            //
            this.edtBgBewilligungStatusCode.Location = new System.Drawing.Point(150, 130);
            this.edtBgBewilligungStatusCode.LOVName = "BgBewilligungStatus";
            this.edtBgBewilligungStatusCode.Name = "edtBgBewilligungStatusCode";
            this.edtBgBewilligungStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgBewilligungStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgBewilligungStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgBewilligungStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgBewilligungStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgBewilligungStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgBewilligungStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgBewilligungStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtBgBewilligungStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgBewilligungStatusCode.Properties.NullText = "";
            this.edtBgBewilligungStatusCode.Properties.ShowFooter = false;
            this.edtBgBewilligungStatusCode.Properties.ShowHeader = false;
            this.edtBgBewilligungStatusCode.Size = new System.Drawing.Size(250, 24);
            this.edtBgBewilligungStatusCode.TabIndex = 7;
            //
            // lblEroeffnungvon
            //
            this.lblEroeffnungvon.Location = new System.Drawing.Point(10, 160);
            this.lblEroeffnungvon.Name = "lblEroeffnungvon";
            this.lblEroeffnungvon.Size = new System.Drawing.Size(130, 24);
            this.lblEroeffnungvon.TabIndex = 8;
            this.lblEroeffnungvon.Text = "Eroeffnung von";
            this.lblEroeffnungvon.UseCompatibleTextRendering = true;
            //
            // edtEroeffnungDatumVon
            //
            this.edtEroeffnungDatumVon.EditValue = "";
            this.edtEroeffnungDatumVon.Location = new System.Drawing.Point(150, 160);
            this.edtEroeffnungDatumVon.Name = "edtEroeffnungDatumVon";
            this.edtEroeffnungDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungDatumVon.Properties.ShowToday = false;
            this.edtEroeffnungDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungDatumVon.TabIndex = 9;
            //
            // lblbis
            //
            this.lblbis.Location = new System.Drawing.Point(270, 160);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 10;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            //
            // edtEroeffnungDatumBis
            //
            this.edtEroeffnungDatumBis.EditValue = "";
            this.edtEroeffnungDatumBis.Location = new System.Drawing.Point(300, 160);
            this.edtEroeffnungDatumBis.Name = "edtEroeffnungDatumBis";
            this.edtEroeffnungDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungDatumBis.Properties.ShowToday = false;
            this.edtEroeffnungDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungDatumBis.TabIndex = 11;
            //
            // lblAbschlussvon
            //
            this.lblAbschlussvon.Location = new System.Drawing.Point(10, 190);
            this.lblAbschlussvon.Name = "lblAbschlussvon";
            this.lblAbschlussvon.Size = new System.Drawing.Size(130, 24);
            this.lblAbschlussvon.TabIndex = 12;
            this.lblAbschlussvon.Text = "Abschluss von";
            this.lblAbschlussvon.UseCompatibleTextRendering = true;
            //
            // edtAbschlussDatumVon
            //
            this.edtAbschlussDatumVon.EditValue = "";
            this.edtAbschlussDatumVon.Location = new System.Drawing.Point(150, 190);
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
            this.edtAbschlussDatumVon.TabIndex = 13;
            //
            // lblbis1
            //
            this.lblbis1.Location = new System.Drawing.Point(270, 190);
            this.lblbis1.Name = "lblbis1";
            this.lblbis1.Size = new System.Drawing.Size(130, 24);
            this.lblbis1.TabIndex = 14;
            this.lblbis1.Text = "bis";
            this.lblbis1.UseCompatibleTextRendering = true;
            //
            // edtAbschlussDatumBis
            //
            this.edtAbschlussDatumBis.EditValue = "";
            this.edtAbschlussDatumBis.Location = new System.Drawing.Point(300, 190);
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
            this.edtAbschlussDatumBis.TabIndex = 15;
            //
            // lblAktivinJahr
            //
            this.lblAktivinJahr.Location = new System.Drawing.Point(10, 220);
            this.lblAktivinJahr.Name = "lblAktivinJahr";
            this.lblAktivinJahr.Size = new System.Drawing.Size(130, 24);
            this.lblAktivinJahr.TabIndex = 16;
            this.lblAktivinJahr.Text = "Aktiv in Jahr";
            this.lblAktivinJahr.UseCompatibleTextRendering = true;
            //
            // edtJahr
            //
            this.edtJahr.Location = new System.Drawing.Point(150, 220);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJahr.Size = new System.Drawing.Size(60, 24);
            this.edtJahr.TabIndex = 17;
            //
            // lblEroeffnunggeplantvon
            //
            this.lblEroeffnunggeplantvon.Location = new System.Drawing.Point(10, 250);
            this.lblEroeffnunggeplantvon.Name = "lblEroeffnunggeplantvon";
            this.lblEroeffnunggeplantvon.Size = new System.Drawing.Size(130, 24);
            this.lblEroeffnunggeplantvon.TabIndex = 18;
            this.lblEroeffnunggeplantvon.Text = "Eroeffnung geplant von";
            this.lblEroeffnunggeplantvon.UseCompatibleTextRendering = true;
            //
            // edtEroeffnungGeplantVon
            //
            this.edtEroeffnungGeplantVon.EditValue = "";
            this.edtEroeffnungGeplantVon.Location = new System.Drawing.Point(150, 250);
            this.edtEroeffnungGeplantVon.Name = "edtEroeffnungGeplantVon";
            this.edtEroeffnungGeplantVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungGeplantVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungGeplantVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungGeplantVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungGeplantVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungGeplantVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungGeplantVon.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungGeplantVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungGeplantVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungGeplantVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungGeplantVon.Properties.ShowToday = false;
            this.edtEroeffnungGeplantVon.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungGeplantVon.TabIndex = 19;
            //
            // lblbis2
            //
            this.lblbis2.Location = new System.Drawing.Point(270, 250);
            this.lblbis2.Name = "lblbis2";
            this.lblbis2.Size = new System.Drawing.Size(130, 24);
            this.lblbis2.TabIndex = 20;
            this.lblbis2.Text = "bis";
            this.lblbis2.UseCompatibleTextRendering = true;
            //
            // edtEroeffnungGeplantBis
            //
            this.edtEroeffnungGeplantBis.EditValue = "";
            this.edtEroeffnungGeplantBis.Location = new System.Drawing.Point(300, 250);
            this.edtEroeffnungGeplantBis.Name = "edtEroeffnungGeplantBis";
            this.edtEroeffnungGeplantBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungGeplantBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungGeplantBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungGeplantBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungGeplantBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungGeplantBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungGeplantBis.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungGeplantBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungGeplantBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungGeplantBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungGeplantBis.Properties.ShowToday = false;
            this.edtEroeffnungGeplantBis.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungGeplantBis.TabIndex = 21;
            //
            // lblAbschlussgeplantvon
            //
            this.lblAbschlussgeplantvon.Location = new System.Drawing.Point(10, 280);
            this.lblAbschlussgeplantvon.Name = "lblAbschlussgeplantvon";
            this.lblAbschlussgeplantvon.Size = new System.Drawing.Size(130, 24);
            this.lblAbschlussgeplantvon.TabIndex = 22;
            this.lblAbschlussgeplantvon.Text = "Abschluss geplant von";
            this.lblAbschlussgeplantvon.UseCompatibleTextRendering = true;
            //
            // edtAbschlussGeplantVon
            //
            this.edtAbschlussGeplantVon.EditValue = "";
            this.edtAbschlussGeplantVon.Location = new System.Drawing.Point(150, 280);
            this.edtAbschlussGeplantVon.Name = "edtAbschlussGeplantVon";
            this.edtAbschlussGeplantVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtAbschlussGeplantVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGeplantVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGeplantVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGeplantVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGeplantVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGeplantVon.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGeplantVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbschlussGeplantVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtAbschlussGeplantVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGeplantVon.Properties.ShowToday = false;
            this.edtAbschlussGeplantVon.Size = new System.Drawing.Size(100, 24);
            this.edtAbschlussGeplantVon.TabIndex = 23;
            //
            // lblbis3
            //
            this.lblbis3.Location = new System.Drawing.Point(270, 280);
            this.lblbis3.Name = "lblbis3";
            this.lblbis3.Size = new System.Drawing.Size(130, 24);
            this.lblbis3.TabIndex = 24;
            this.lblbis3.Text = "bis";
            this.lblbis3.UseCompatibleTextRendering = true;
            //
            // edtAbschlussGeplantBis
            //
            this.edtAbschlussGeplantBis.EditValue = "";
            this.edtAbschlussGeplantBis.Location = new System.Drawing.Point(300, 280);
            this.edtAbschlussGeplantBis.Name = "edtAbschlussGeplantBis";
            this.edtAbschlussGeplantBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtAbschlussGeplantBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGeplantBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGeplantBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGeplantBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGeplantBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGeplantBis.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGeplantBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbschlussGeplantBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtAbschlussGeplantBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGeplantBis.Properties.ShowToday = false;
            this.edtAbschlussGeplantBis.Size = new System.Drawing.Size(100, 24);
            this.edtAbschlussGeplantBis.TabIndex = 25;
            //
            // edtLastFinanzPlan
            //
            this.edtLastFinanzPlan.EditValue = false;
            this.edtLastFinanzPlan.Location = new System.Drawing.Point(150, 310);
            this.edtLastFinanzPlan.Name = "edtLastFinanzPlan";
            this.edtLastFinanzPlan.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtLastFinanzPlan.Properties.Appearance.Options.UseBackColor = true;
            this.edtLastFinanzPlan.Properties.Caption = "nur letzten Finanzplan";
            this.edtLastFinanzPlan.Size = new System.Drawing.Size(250, 19);
            this.edtLastFinanzPlan.TabIndex = 26;
            //
            // colAbschlussgrund
            //
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            //
            // colAnzBewAnfragen
            //
            this.colAnzBewAnfragen.Name = "colAnzBewAnfragen";
            //
            // colAnzBewAntworten
            //
            this.colAnzBewAntworten.Name = "colAnzBewAntworten";
            //
            // coleffektivbis
            //
            this.coleffektivbis.Name = "coleffektivbis";
            //
            // coleffektivvon
            //
            this.coleffektivvon.Name = "coleffektivvon";
            //
            // colErffnungsgrund
            //
            this.colErffnungsgrund.Name = "colErffnungsgrund";
            //
            // colFinanzplanNr
            //
            this.colFinanzplanNr.Name = "colFinanzplanNr";
            //
            // colgeplantbis
            //
            this.colgeplantbis.Name = "colgeplantbis";
            //
            // colgeplantvon
            //
            this.colgeplantvon.Name = "colgeplantvon";
            //
            // colKlientIn
            //
            this.colKlientIn.Name = "colKlientIn";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colSektion
            //
            this.colSektion.Name = "colSektion";
            //
            // colStatus
            //
            this.colStatus.Name = "colStatus";
            //
            // colTyp
            //
            this.colTyp.Name = "colTyp";
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
            // sqlQuery1
            //
            this.sqlQuery1.HostControl = this;
            //
            // CtlQueryShFinanzplaene
            //
            this.Name = "CtlQueryShFinanzplaene";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerechnungsgrundlage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShGrundbedarfTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShGrundbedarfTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBewilligungStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktivinJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnunggeplantvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungGeplantVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungGeplantBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgeplantvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGeplantVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGeplantBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLastFinanzPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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