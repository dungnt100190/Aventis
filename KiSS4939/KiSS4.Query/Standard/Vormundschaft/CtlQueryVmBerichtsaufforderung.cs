using System;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryVmBerichtsaufforderung : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBerichtbis;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtvon;
        private DevExpress.XtraGrid.Columns.GridColumn colEingang;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatstrger;
        private DevExpress.XtraGrid.Columns.GridColumn colPrivat;
        private DevExpress.XtraGrid.Columns.GridColumn colTage;
        private DevExpress.XtraGrid.Columns.GridColumn colTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colTodestag;
        private DevExpress.XtraGrid.Columns.GridColumn colZGB;
        private KiSS4.Gui.KissDateEdit edtFaelligBis;
        private KiSS4.Gui.KissDateEdit edtFaelligVon;
        private KiSS4.Gui.KissLookUpEdit edtFbTeamID;
        private KiSS4.Gui.KissCheckEdit edtNurFaellige;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissLookUpEdit edtUserType;
        private KiSS4.Gui.KissButtonEdit edtVmPriMaID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblBerichtefaelligbis;
        private KiSS4.Gui.KissLabel lblBerichtefaelligvon;
        private KiSS4.Gui.KissLabel lblMandatstraegeramtlich;
        private KiSS4.Gui.KissLabel lblMandatstraegerprivat;
        private KiSS4.Gui.KissLabel lblMandatstraegertyp;
        private KiSS4.Gui.KissLabel lblTeam;

        #endregion

        #region Constructors

        public CtlQueryVmBerichtsaufforderung()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL( @"select Code = FbTeamID, Text = Name from FbTeam order by Name" );
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow,0);
            NewRow.AcceptChanges();
            edtFbTeamID.Properties.Columns.Clear();
            edtFbTeamID.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
            edtFbTeamID.Properties.ShowFooter = false;
            edtFbTeamID.Properties.ShowHeader = false;
            edtFbTeamID.Properties.DisplayMember = "Text";
            edtFbTeamID.Properties.ValueMember = "Code";
            edtFbTeamID.Properties.DropDownRows = Math.Min( qry.Count, 7 );
            edtFbTeamID.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL( @"SELECT Code=1, Text = 'amtlich' UNION SELECT Code = 2, Text = 'PriMa'" );
            NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow,0);
            NewRow.AcceptChanges();
            edtUserType.Properties.Columns.Clear();
            edtUserType.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
            edtUserType.Properties.ShowFooter = false;
            edtUserType.Properties.ShowHeader = false;
            edtUserType.Properties.DisplayMember = "Text";
            edtUserType.Properties.ValueMember = "Code";
            edtUserType.Properties.DropDownRows = Math.Min( qry.Count, 7 );
            edtUserType.Properties.DataSource = qry;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmBerichtsaufforderung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblMandatstraegeramtlich = new KiSS4.Gui.KissLabel();
            this.lblMandatstraegerprivat = new KiSS4.Gui.KissLabel();
            this.lblBerichtefaelligvon = new KiSS4.Gui.KissLabel();
            this.lblBerichtefaelligbis = new KiSS4.Gui.KissLabel();
            this.lblTeam = new KiSS4.Gui.KissLabel();
            this.lblMandatstraegertyp = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtVmPriMaID = new KiSS4.Gui.KissButtonEdit();
            this.edtFaelligVon = new KiSS4.Gui.KissDateEdit();
            this.edtFaelligBis = new KiSS4.Gui.KissDateEdit();
            this.edtFbTeamID = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserType = new KiSS4.Gui.KissLookUpEdit();
            this.edtNurFaellige = new KiSS4.Gui.KissCheckEdit();
            this.colBerichtbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichtvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatstrger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrivat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTodestag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZGB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegeramtlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerprivat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtefaelligvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtefaelligbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegertyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurFaellige.Properties)).BeginInit();
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
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtNurFaellige);
            this.tpgSuchen.Controls.Add(this.edtUserType);
            this.tpgSuchen.Controls.Add(this.edtFbTeamID);
            this.tpgSuchen.Controls.Add(this.edtFaelligBis);
            this.tpgSuchen.Controls.Add(this.edtFaelligVon);
            this.tpgSuchen.Controls.Add(this.edtVmPriMaID);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegertyp);
            this.tpgSuchen.Controls.Add(this.lblTeam);
            this.tpgSuchen.Controls.Add(this.lblBerichtefaelligbis);
            this.tpgSuchen.Controls.Add(this.lblBerichtefaelligvon);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegerprivat);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegeramtlich);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegeramtlich, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegerprivat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBerichtefaelligvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBerichtefaelligbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTeam, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegertyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVmPriMaID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaelligVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaelligBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFbTeamID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserType, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurFaellige, 0);
            //
            // lblMandatstraegeramtlich
            //
            this.lblMandatstraegeramtlich.Location = new System.Drawing.Point(10, 40);
            this.lblMandatstraegeramtlich.Name = "lblMandatstraegeramtlich";
            this.lblMandatstraegeramtlich.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegeramtlich.TabIndex = 1;
            this.lblMandatstraegeramtlich.Text = "Mandatstraeger amtlich";
            this.lblMandatstraegeramtlich.UseCompatibleTextRendering = true;
            //
            // lblMandatstraegerprivat
            //
            this.lblMandatstraegerprivat.Location = new System.Drawing.Point(10, 70);
            this.lblMandatstraegerprivat.Name = "lblMandatstraegerprivat";
            this.lblMandatstraegerprivat.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegerprivat.TabIndex = 2;
            this.lblMandatstraegerprivat.Text = "Mandatstraeger privat";
            this.lblMandatstraegerprivat.UseCompatibleTextRendering = true;
            //
            // lblBerichtefaelligvon
            //
            this.lblBerichtefaelligvon.Location = new System.Drawing.Point(10, 100);
            this.lblBerichtefaelligvon.Name = "lblBerichtefaelligvon";
            this.lblBerichtefaelligvon.Size = new System.Drawing.Size(130, 24);
            this.lblBerichtefaelligvon.TabIndex = 3;
            this.lblBerichtefaelligvon.Text = "Berichte faellig von";
            this.lblBerichtefaelligvon.UseCompatibleTextRendering = true;
            //
            // lblBerichtefaelligbis
            //
            this.lblBerichtefaelligbis.Location = new System.Drawing.Point(10, 130);
            this.lblBerichtefaelligbis.Name = "lblBerichtefaelligbis";
            this.lblBerichtefaelligbis.Size = new System.Drawing.Size(130, 24);
            this.lblBerichtefaelligbis.TabIndex = 4;
            this.lblBerichtefaelligbis.Text = "Berichte faellig bis";
            this.lblBerichtefaelligbis.UseCompatibleTextRendering = true;
            //
            // lblTeam
            //
            this.lblTeam.Location = new System.Drawing.Point(10, 160);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(130, 24);
            this.lblTeam.TabIndex = 5;
            this.lblTeam.Text = "Team";
            this.lblTeam.UseCompatibleTextRendering = true;
            //
            // lblMandatstraegertyp
            //
            this.lblMandatstraegertyp.Location = new System.Drawing.Point(10, 190);
            this.lblMandatstraegertyp.Name = "lblMandatstraegertyp";
            this.lblMandatstraegertyp.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegertyp.TabIndex = 6;
            this.lblMandatstraegertyp.Text = "Mandatstraegertyp";
            this.lblMandatstraegertyp.UseCompatibleTextRendering = true;
            //
            // edtUserID
            //
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
            // edtVmPriMaID
            //
            this.edtVmPriMaID.Location = new System.Drawing.Point(150, 70);
            this.edtVmPriMaID.Name = "edtVmPriMaID";
            this.edtVmPriMaID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmPriMaID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmPriMaID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmPriMaID.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmPriMaID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmPriMaID.Properties.Appearance.Options.UseFont = true;
            this.edtVmPriMaID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVmPriMaID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtVmPriMaID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmPriMaID.Size = new System.Drawing.Size(200, 24);
            this.edtVmPriMaID.TabIndex = 21;
            this.edtVmPriMaID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtVmPriMaID_UserModifiedFld);
            //
            // edtFaelligVon
            //
            this.edtFaelligVon.EditValue = null;
            this.edtFaelligVon.Location = new System.Drawing.Point(150, 100);
            this.edtFaelligVon.Name = "edtFaelligVon";
            this.edtFaelligVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtFaelligVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaelligVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaelligVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaelligVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaelligVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaelligVon.Properties.Appearance.Options.UseFont = true;
            this.edtFaelligVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaelligVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtFaelligVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaelligVon.Properties.ShowToday = false;
            this.edtFaelligVon.Size = new System.Drawing.Size(100, 24);
            this.edtFaelligVon.TabIndex = 22;
            //
            // edtFaelligBis
            //
            this.edtFaelligBis.EditValue = null;
            this.edtFaelligBis.Location = new System.Drawing.Point(150, 130);
            this.edtFaelligBis.Name = "edtFaelligBis";
            this.edtFaelligBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtFaelligBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaelligBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaelligBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaelligBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaelligBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaelligBis.Properties.Appearance.Options.UseFont = true;
            this.edtFaelligBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaelligBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtFaelligBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaelligBis.Properties.ShowToday = false;
            this.edtFaelligBis.Size = new System.Drawing.Size(100, 24);
            this.edtFaelligBis.TabIndex = 23;
            //
            // edtFbTeamID
            //
            this.edtFbTeamID.Location = new System.Drawing.Point(150, 160);
            this.edtFbTeamID.Name = "edtFbTeamID";
            this.edtFbTeamID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFbTeamID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFbTeamID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFbTeamID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFbTeamID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFbTeamID.Properties.Appearance.Options.UseFont = true;
            this.edtFbTeamID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFbTeamID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtFbTeamID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFbTeamID.Properties.NullText = "";
            this.edtFbTeamID.Properties.ShowFooter = false;
            this.edtFbTeamID.Properties.ShowHeader = false;
            this.edtFbTeamID.Size = new System.Drawing.Size(200, 24);
            this.edtFbTeamID.TabIndex = 24;
            //
            // edtUserType
            //
            this.edtUserType.Location = new System.Drawing.Point(150, 190);
            this.edtUserType.Name = "edtUserType";
            this.edtUserType.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserType.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserType.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserType.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserType.Properties.Appearance.Options.UseFont = true;
            this.edtUserType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtUserType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserType.Properties.NullText = "";
            this.edtUserType.Properties.ShowFooter = false;
            this.edtUserType.Properties.ShowHeader = false;
            this.edtUserType.Size = new System.Drawing.Size(200, 24);
            this.edtUserType.TabIndex = 25;
            //
            // edtNurFaellige
            //
            this.edtNurFaellige.EditValue = false;
            this.edtNurFaellige.Location = new System.Drawing.Point(150, 220);
            this.edtNurFaellige.Name = "edtNurFaellige";
            this.edtNurFaellige.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurFaellige.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurFaellige.Properties.Caption = "nur faellige Berichte";
            this.edtNurFaellige.Size = new System.Drawing.Size(200, 19);
            this.edtNurFaellige.TabIndex = 26;
            //
            // colBerichtbis
            //
            this.colBerichtbis.Name = "colBerichtbis";
            //
            // colBerichtvon
            //
            this.colBerichtvon.Name = "colBerichtvon";
            //
            // colEingang
            //
            this.colEingang.Name = "colEingang";
            //
            // colGeburtstag
            //
            this.colGeburtstag.Name = "colGeburtstag";
            //
            // colMandant
            //
            this.colMandant.Name = "colMandant";
            //
            // colMandatstrger
            //
            this.colMandatstrger.Name = "colMandatstrger";
            //
            // colPrivat
            //
            this.colPrivat.Name = "colPrivat";
            //
            // colTage
            //
            this.colTage.Name = "colTage";
            //
            // colTeam
            //
            this.colTeam.Name = "colTeam";
            //
            // colTodestag
            //
            this.colTodestag.Name = "colTodestag";
            //
            // colZGB
            //
            this.colZGB.Name = "colZGB";
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
            // CtlQueryVmBerichtsaufforderung
            //
            this.Name = "CtlQueryVmBerichtsaufforderung";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegeramtlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerprivat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtefaelligvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtefaelligbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegertyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurFaellige.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Private Methods

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

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select ID = UserID,
                    Mandatstraeger = LastName + isNull(', ' + FirstName,''),
                    [Kuerzel] = LogonName
                from   XUser
             	where LastName + isNull(', ' + FirstName,'') like {0} + '%'
                order by Mandatstraeger",
              SearchString,
              e.ButtonClicked,null,null,null);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg[1];
                edtUserID.LookupID = dlg[0];
            }
        }

        private void edtVmPriMaID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtVmPriMaID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                        edtVmPriMaID.EditValue = null;
                        edtVmPriMaID.LookupID = null;
              		return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select ID = VmPriMaID,
                    Mandatstraeger = Name + isNull(', ' + Vorname,'')
                from VmPriMa
                where Name + isNull(', ' + Vorname,'') like {0} + '%'
                order by Mandatstraeger",
              SearchString,
              e.ButtonClicked,null,null,null);

            if (!e.Cancel)
            {
                edtVmPriMaID.EditValue = dlg[1];
                edtVmPriMaID.LookupID = dlg[0];
            }
        }

        #endregion
    }
}