using System;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryShEroeffnungsgruende : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAltertyp;
        private DevExpress.XtraGrid.Columns.GridColumn colEingangsbesttigung;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnungsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHchsteAusb;
        private DevExpress.XtraGrid.Columns.GridColumn colIVAbklrung;
        private DevExpress.XtraGrid.Columns.GridColumn colLetzteTtigkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSektion;
        private KiSS4.Gui.KissLookUpEdit edtAlter;
        private KiSS4.Gui.KissLookUpEdit edtEroeffGrund;
        private KiSS4.Gui.KissDateEdit edtEroeffnungBis;
        private KiSS4.Gui.KissDateEdit edtEroeffnungVon;
        private KiSS4.Gui.KissLookUpEdit edtGeschlecht;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaet;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblAlter;
        private KiSS4.Gui.KissLabel lblEroeffGrund;
        private KiSS4.Gui.KissLabel lblEroeffnungBis;
        private KiSS4.Gui.KissLabel lblEroeffnungVon;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblNationalitaet;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblSektion;

        #endregion

        #region Constructors

        public CtlQueryShEroeffnungsgruende()
        {
            this.InitializeComponent();

            SqlQuery qry1 = DBUtil.OpenSQL( @"select Code = 1, Text = '0-17'
                union select 2, '18-25'
                union select 3, '26-35'
                union select 4, '36-50'
                union select 5, '51-65'
                union select 6, 'ab 66'" );
            System.Data.DataRow NewRow1 = qry1.DataTable.NewRow();
            NewRow1["Text"] = "";
            qry1.DataTable.Rows.InsertAt(NewRow1,0);
            NewRow1.AcceptChanges();
            edtAlter.Properties.Columns.Clear();
            edtAlter.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
            edtAlter.Properties.ShowFooter = false;
            edtAlter.Properties.ShowHeader = false;
            edtAlter.Properties.DisplayMember = "Text";
            edtAlter.Properties.ValueMember = "Code";
            edtAlter.Properties.DropDownRows = Math.Min( qry1.Count, 7 );
            edtAlter.Properties.DataSource = qry1;

            SqlQuery qry = DBUtil.OpenSQL( @"select Code = OrgUnitID, Text = ItemName from XOrgUnit order by ItemName" );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryShEroeffnungsgruende));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtAlter = new KiSS4.Gui.KissLookUpEdit();
            this.edtGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.edtNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.edtEroeffnungVon = new KiSS4.Gui.KissDateEdit();
            this.edtEroeffnungBis = new KiSS4.Gui.KissDateEdit();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblAlter = new KiSS4.Gui.KissLabel();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.lblNationalitaet = new KiSS4.Gui.KissLabel();
            this.lblEroeffnungVon = new KiSS4.Gui.KissLabel();
            this.lblEroeffnungBis = new KiSS4.Gui.KissLabel();
            this.edtEroeffGrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblEroeffGrund = new KiSS4.Gui.KissLabel();
            this.colAbschlussdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltertyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingangsbesttigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnungsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHchsteAusb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVAbklrung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetzteTtigkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffGrund)).BeginInit();
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
            this.tpgSuchen.Controls.Add(this.lblEroeffGrund);
            this.tpgSuchen.Controls.Add(this.edtEroeffGrund);
            this.tpgSuchen.Controls.Add(this.lblEroeffnungBis);
            this.tpgSuchen.Controls.Add(this.lblEroeffnungVon);
            this.tpgSuchen.Controls.Add(this.lblNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblGeschlecht);
            this.tpgSuchen.Controls.Add(this.lblAlter);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungBis);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungVon);
            this.tpgSuchen.Controls.Add(this.edtNationalitaet);
            this.tpgSuchen.Controls.Add(this.edtGeschlecht);
            this.tpgSuchen.Controls.Add(this.edtAlter);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAlter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeschlecht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAlter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGeschlecht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEroeffnungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEroeffnungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffGrund, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEroeffGrund, 0);
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
            this.edtOrgUnitID.Size = new System.Drawing.Size(220, 24);
            this.edtOrgUnitID.TabIndex = 1;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 70);
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
            this.edtUserID.Size = new System.Drawing.Size(220, 24);
            this.edtUserID.TabIndex = 2;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // edtAlter
            //
            this.edtAlter.Location = new System.Drawing.Point(150, 101);
            this.edtAlter.Name = "edtAlter";
            this.edtAlter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAlter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAlter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAlter.Properties.Appearance.Options.UseBackColor = true;
            this.edtAlter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAlter.Properties.Appearance.Options.UseFont = true;
            this.edtAlter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAlter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtAlter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAlter.Properties.NullText = "";
            this.edtAlter.Properties.ShowFooter = false;
            this.edtAlter.Properties.ShowHeader = false;
            this.edtAlter.Size = new System.Drawing.Size(220, 24);
            this.edtAlter.TabIndex = 3;
            //
            // edtGeschlecht
            //
            this.edtGeschlecht.Location = new System.Drawing.Point(150, 132);
            this.edtGeschlecht.LOVName = "Geschlecht";
            this.edtGeschlecht.Name = "edtGeschlecht";
            this.edtGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlecht.Properties.NullText = "";
            this.edtGeschlecht.Properties.ShowFooter = false;
            this.edtGeschlecht.Properties.ShowHeader = false;
            this.edtGeschlecht.Size = new System.Drawing.Size(220, 24);
            this.edtGeschlecht.TabIndex = 4;
            //
            // edtNationalitaet
            //
            this.edtNationalitaet.Location = new System.Drawing.Point(150, 163);
            this.edtNationalitaet.LOVName = "BaLand";
            this.edtNationalitaet.Name = "edtNationalitaet";
            this.edtNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaet.Properties.NullText = "";
            this.edtNationalitaet.Properties.ShowFooter = false;
            this.edtNationalitaet.Properties.ShowHeader = false;
            this.edtNationalitaet.Size = new System.Drawing.Size(220, 24);
            this.edtNationalitaet.TabIndex = 5;
            //
            // edtEroeffnungVon
            //
            this.edtEroeffnungVon.EditValue = null;
            this.edtEroeffnungVon.Location = new System.Drawing.Point(150, 197);
            this.edtEroeffnungVon.Name = "edtEroeffnungVon";
            this.edtEroeffnungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungVon.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungVon.Properties.ShowToday = false;
            this.edtEroeffnungVon.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungVon.TabIndex = 6;
            //
            // edtEroeffnungBis
            //
            this.edtEroeffnungBis.EditValue = null;
            this.edtEroeffnungBis.Location = new System.Drawing.Point(270, 197);
            this.edtEroeffnungBis.Name = "edtEroeffnungBis";
            this.edtEroeffnungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtEroeffnungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungBis.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtEroeffnungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungBis.Properties.ShowToday = false;
            this.edtEroeffnungBis.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungBis.TabIndex = 7;
            //
            // lblSektion
            //
            this.lblSektion.Location = new System.Drawing.Point(10, 40);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(130, 24);
            this.lblSektion.TabIndex = 8;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 70);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 9;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // lblAlter
            //
            this.lblAlter.Location = new System.Drawing.Point(10, 101);
            this.lblAlter.Name = "lblAlter";
            this.lblAlter.Size = new System.Drawing.Size(130, 24);
            this.lblAlter.TabIndex = 10;
            this.lblAlter.Text = "Alter";
            this.lblAlter.UseCompatibleTextRendering = true;
            //
            // lblGeschlecht
            //
            this.lblGeschlecht.Location = new System.Drawing.Point(10, 132);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(130, 24);
            this.lblGeschlecht.TabIndex = 11;
            this.lblGeschlecht.Text = "Geschlecht";
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            //
            // lblNationalitaet
            //
            this.lblNationalitaet.Location = new System.Drawing.Point(10, 163);
            this.lblNationalitaet.Name = "lblNationalitaet";
            this.lblNationalitaet.Size = new System.Drawing.Size(130, 24);
            this.lblNationalitaet.TabIndex = 12;
            this.lblNationalitaet.Text = "Nationalität";
            this.lblNationalitaet.UseCompatibleTextRendering = true;
            //
            // lblEroeffnungVon
            //
            this.lblEroeffnungVon.Location = new System.Drawing.Point(10, 197);
            this.lblEroeffnungVon.Name = "lblEroeffnungVon";
            this.lblEroeffnungVon.Size = new System.Drawing.Size(130, 24);
            this.lblEroeffnungVon.TabIndex = 13;
            this.lblEroeffnungVon.Text = "Eröffnung von";
            this.lblEroeffnungVon.UseCompatibleTextRendering = true;
            //
            // lblEroeffnungBis
            //
            this.lblEroeffnungBis.Location = new System.Drawing.Point(258, 197);
            this.lblEroeffnungBis.Name = "lblEroeffnungBis";
            this.lblEroeffnungBis.Size = new System.Drawing.Size(10, 24);
            this.lblEroeffnungBis.TabIndex = 14;
            this.lblEroeffnungBis.Text = "-";
            this.lblEroeffnungBis.UseCompatibleTextRendering = true;
            //
            // edtEroeffGrund
            //
            this.edtEroeffGrund.Location = new System.Drawing.Point(150, 227);
            this.edtEroeffGrund.LOVName = "Eroeffnungsgrund";
            this.edtEroeffGrund.Name = "edtEroeffGrund";
            this.edtEroeffGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffGrund.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffGrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEroeffGrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffGrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEroeffGrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEroeffGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEroeffGrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEroeffGrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffGrund.Properties.NullText = "";
            this.edtEroeffGrund.Properties.ShowFooter = false;
            this.edtEroeffGrund.Properties.ShowHeader = false;
            this.edtEroeffGrund.Size = new System.Drawing.Size(220, 24);
            this.edtEroeffGrund.TabIndex = 15;
            //
            // lblEroeffGrund
            //
            this.lblEroeffGrund.Location = new System.Drawing.Point(10, 227);
            this.lblEroeffGrund.Name = "lblEroeffGrund";
            this.lblEroeffGrund.Size = new System.Drawing.Size(130, 24);
            this.lblEroeffGrund.TabIndex = 16;
            this.lblEroeffGrund.Text = "Eröffnungsgrund";
            this.lblEroeffGrund.UseCompatibleTextRendering = true;
            //
            // colAbschlussdatum
            //
            this.colAbschlussdatum.Name = "colAbschlussdatum";
            //
            // colAbschlussgrund
            //
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            //
            // colAHVNummer
            //
            this.colAHVNummer.Name = "colAHVNummer";
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
            //
            // colAltertyp
            //
            this.colAltertyp.Name = "colAltertyp";
            //
            // colEingangsbesttigung
            //
            this.colEingangsbesttigung.Name = "colEingangsbesttigung";
            //
            // colErffnet
            //
            this.colErffnet.Name = "colErffnet";
            //
            // colErffnungsdatum
            //
            this.colErffnungsdatum.Name = "colErffnungsdatum";
            //
            // colErffnungsgrund
            //
            this.colErffnungsgrund.Name = "colErffnungsgrund";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colGeschlecht
            //
            this.colGeschlecht.Name = "colGeschlecht";
            //
            // colHchsteAusb
            //
            this.colHchsteAusb.Name = "colHchsteAusb";
            //
            // colIVAbklrung
            //
            this.colIVAbklrung.Name = "colIVAbklrung";
            //
            // colLetzteTtigkeit
            //
            this.colLetzteTtigkeit.Name = "colLetzteTtigkeit";
            //
            // colNationalitt
            //
            this.colNationalitt.Name = "colNationalitt";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colSektion
            //
            this.colSektion.Name = "colSektion";
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
            // CtlQueryShEroeffnungsgruende
            //
            this.Name = "CtlQueryShEroeffnungsgruende";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            // replace search parameters
             object[] parameters = new object[]{Session.User.LogonName};
             this.kissSearch.SelectParameters = parameters;
             // let base do stuff
             base.RunSearch();
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