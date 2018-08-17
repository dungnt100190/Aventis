

using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQueryWhFinanzplaeneAuszahlungen : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnJumpTo;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colBE;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colFPNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFPTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colFPbis;
        private DevExpress.XtraGrid.Columns.GridColumn colFPgeplantbis;
        private DevExpress.XtraGrid.Columns.GridColumn colFPgeplantvon;
        private DevExpress.XtraGrid.Columns.GridColumn colFPvon;
        private DevExpress.XtraGrid.Columns.GridColumn colFT;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colGBLTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colGebDat;
        private DevExpress.XtraGrid.Columns.GridColumn colLT;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colOE;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSZ;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusFP;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colUE;
        private DevExpress.XtraGrid.Columns.GridColumn colWHbis;
        private DevExpress.XtraGrid.Columns.GridColumn colWHvon;
        private DevExpress.XtraGrid.Columns.GridColumn colgrauerstes;
        private DevExpress.XtraGrid.Columns.GridColumn colgrnletztes;
        private DevExpress.XtraGrid.Columns.GridColumn colroterstes;
        private KiSS4.Gui.KissCheckEdit edtNurAktive;
        private KiSS4.Gui.KissCheckEdit edtNurLaufende;
        private KiSS4.Gui.KissLookUpEdit edtSucheGruppe;
        private KiSS4.Gui.KissLookUpEdit edtSucheTeam;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblSucheOE;
        private KiSS4.Gui.KissLabel lblSucheTeam;
        private KiSS4.Gui.KissLabel lblUserID;

        SqlQuery qryDat;

        #endregion

        #region Constructors

        public CtlQueryWhFinanzplaeneAuszahlungen()
        {
            this.InitializeComponent();

            qryDat = DBUtil.OpenSQL(@"
                DECLARE @OrgUnitID   int,
                        @TeamCode    int

                SET @OrgUnitID = {0}

                WHILE @OrgUnitID IS NOT NULL BEGIN
                  SELECT TOP 1 @TeamCode = GRP.Code
                  FROM   XLOVCode        TEM
                    INNER JOIN XLOVCode  GRP ON GRP.LOVName = 'QuOrgUnitGroup' AND ',' + TEM.Value3 + ',' LIKE '%,' + GRP.Value1 + ',%'
                  WHERE TEM.LOVName = 'QuOrgUnitTeam'
                    AND TEM.Code = @OrgUnitID
                  ORDER BY GRP.SortKey

                  IF @TeamCode IS NOT NULL BREAK

                  SELECT @OrgUnitID = ParentID FROM XOrgUnit WHERE OrgUnitID = @OrgUnitID
                  IF @@RowCount = 0 BREAK
                END

                SELECT TeamCode = IsNull(@TeamCode, -1), OrgUnitID = @OrgUnitID",
                Session.User["OrgUnitID"]);

                if (!DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlGruppe"))
                    edtSucheGruppe.EditMode = EditModeType.ReadOnly;

                if (!DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlTeam"))
                    edtSucheTeam.EditMode = EditModeType.ReadOnly;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryWhFinanzplaeneAuszahlungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnJumpTo = new KiSS4.Gui.KissButton();
            this.edtSucheGruppe = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheTeam = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheOE = new KiSS4.Gui.KissLabel();
            this.lblSucheTeam = new KiSS4.Gui.KissLabel();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.edtNurLaufende = new KiSS4.Gui.KissCheckEdit();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPgeplantbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPgeplantvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGBLTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGebDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrauerstes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrnletztes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colroterstes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusFP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurLaufende.Properties)).BeginInit();
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
                        this.gridView1,
                        this.grvQuery1});
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
            this.ctlGotoFall.DataMember = "FallBaPersonID$";
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnJumpTo);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnJumpTo, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtNurLaufende);
            this.tpgSuchen.Controls.Add(this.edtNurAktive);
            this.tpgSuchen.Controls.Add(this.lblUserID);
            this.tpgSuchen.Controls.Add(this.lblSucheTeam);
            this.tpgSuchen.Controls.Add(this.lblSucheOE);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtSucheTeam);
            this.tpgSuchen.Controls.Add(this.edtSucheGruppe);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTeam, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOE, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTeam, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktive, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurLaufende, 0);
            //
            // btnJumpTo
            //
            this.btnJumpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJumpTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpTo.Location = new System.Drawing.Point(303, 398);
            this.btnJumpTo.Name = "btnJumpTo";
            this.btnJumpTo.Size = new System.Drawing.Size(185, 24);
            this.btnJumpTo.TabIndex = 6;
            this.btnJumpTo.Text = "> letztes grünes Monatsbudget";
            this.btnJumpTo.UseCompatibleTextRendering = true;
            this.btnJumpTo.UseVisualStyleBackColor = false;
            this.btnJumpTo.Visible = false;
            this.btnJumpTo.Click += new System.EventHandler(this.btnJumpTo_Click);
            //
            // edtSucheGruppe
            //
            this.edtSucheGruppe.Location = new System.Drawing.Point(128, 48);
            this.edtSucheGruppe.LOVName = "QuOrgUnitGroup";
            this.edtSucheGruppe.Name = "edtSucheGruppe";
            this.edtSucheGruppe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGruppe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGruppe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheGruppe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheGruppe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGruppe.Properties.NullText = "";
            this.edtSucheGruppe.Properties.ShowFooter = false;
            this.edtSucheGruppe.Properties.ShowHeader = false;
            this.edtSucheGruppe.Size = new System.Drawing.Size(338, 24);
            this.edtSucheGruppe.TabIndex = 0;
            this.edtSucheGruppe.EditValueChanged += new System.EventHandler(this.edtSucheGruppe_EditValueChanged);
            //
            // edtSucheTeam
            //
            this.edtSucheTeam.Location = new System.Drawing.Point(128, 78);
            this.edtSucheTeam.LOVFilter = "FF";
            this.edtSucheTeam.LOVName = "QuOrgUnitTeam";
            this.edtSucheTeam.Name = "edtSucheTeam";
            this.edtSucheTeam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTeam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTeam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTeam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheTeam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTeam.Properties.NullText = "";
            this.edtSucheTeam.Properties.ShowFooter = false;
            this.edtSucheTeam.Properties.ShowHeader = false;
            this.edtSucheTeam.Size = new System.Drawing.Size(338, 24);
            this.edtSucheTeam.TabIndex = 1;
            this.edtSucheTeam.Tag = "";
            this.edtSucheTeam.EditValueChanged += new System.EventHandler(this.edtSucheTeam_EditValueChanged);
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(128, 108);
            this.edtUserID.LookupSQL = "select ID = UserID, SAR = LastName + isNull(\', \' + FirstName,\'\'), \r\n[Kuerzel] = L" +
                "ogonName\nfrom   XUser \nwhere LastName + isNull(\', \' + FirstName,\'\') \r\nlike {0} +" +
                " \'%\' order by SAR\r\n----";
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(338, 24);
            this.edtUserID.TabIndex = 2;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // lblSucheOE
            //
            this.lblSucheOE.Location = new System.Drawing.Point(11, 48);
            this.lblSucheOE.Name = "lblSucheOE";
            this.lblSucheOE.Size = new System.Drawing.Size(111, 24);
            this.lblSucheOE.TabIndex = 321;
            this.lblSucheOE.Text = "Organisationsgruppe";
            this.lblSucheOE.UseCompatibleTextRendering = true;
            //
            // lblSucheTeam
            //
            this.lblSucheTeam.Location = new System.Drawing.Point(11, 79);
            this.lblSucheTeam.Name = "lblSucheTeam";
            this.lblSucheTeam.Size = new System.Drawing.Size(111, 24);
            this.lblSucheTeam.TabIndex = 322;
            this.lblSucheTeam.Text = "Team";
            this.lblSucheTeam.UseCompatibleTextRendering = true;
            //
            // lblUserID
            //
            this.lblUserID.Location = new System.Drawing.Point(11, 108);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(111, 24);
            this.lblUserID.TabIndex = 323;
            this.lblUserID.Text = "Mitarbeiter/in";
            this.lblUserID.UseCompatibleTextRendering = true;
            //
            // edtNurAktive
            //
            this.edtNurAktive.EditValue = true;
            this.edtNurAktive.Location = new System.Drawing.Point(128, 150);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = "nur aktive W-Leistungen";
            this.edtNurAktive.Size = new System.Drawing.Size(156, 19);
            this.edtNurAktive.TabIndex = 324;
            //
            // edtNurLaufende
            //
            this.edtNurLaufende.EditValue = true;
            this.edtNurLaufende.Location = new System.Drawing.Point(128, 175);
            this.edtNurLaufende.Name = "edtNurLaufende";
            this.edtNurLaufende.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurLaufende.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurLaufende.Properties.Caption = "Bewilligte, aktuell laufende FP";
            this.edtNurLaufende.Size = new System.Drawing.Size(198, 19);
            this.edtNurLaufende.TabIndex = 324;
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
            //
            // colAnzahl
            //
            this.colAnzahl.Name = "colAnzahl";
            //
            // colBaPersonID
            //
            this.colBaPersonID.Name = "colBaPersonID";
            //
            // colBE
            //
            this.colBE.Name = "colBE";
            //
            // colColumn1
            //
            this.colColumn1.Name = "colColumn1";
            //
            // colFallNr
            //
            this.colFallNr.Name = "colFallNr";
            //
            // colFPbis
            //
            this.colFPbis.Name = "colFPbis";
            //
            // colFPgeplantbis
            //
            this.colFPgeplantbis.Name = "colFPgeplantbis";
            //
            // colFPgeplantvon
            //
            this.colFPgeplantvon.Name = "colFPgeplantvon";
            //
            // colFPNr
            //
            this.colFPNr.Name = "colFPNr";
            //
            // colFPTyp
            //
            this.colFPTyp.Name = "colFPTyp";
            //
            // colFPvon
            //
            this.colFPvon.Name = "colFPvon";
            //
            // colFT
            //
            this.colFT.Name = "colFT";
            //
            // colGBLTyp
            //
            this.colGBLTyp.Name = "colGBLTyp";
            //
            // colGebDat
            //
            this.colGebDat.Name = "colGebDat";
            //
            // colgrauerstes
            //
            this.colgrauerstes.Name = "colgrauerstes";
            //
            // colgrnletztes
            //
            this.colgrnletztes.Name = "colgrnletztes";
            //
            // colLT
            //
            this.colLT.Name = "colLT";
            //
            // colMA
            //
            this.colMA.Name = "colMA";
            //
            // colNameVorname
            //
            this.colNameVorname.Name = "colNameVorname";
            //
            // colOE
            //
            this.colOE.Name = "colOE";
            //
            // colPersNr
            //
            this.colPersNr.Name = "colPersNr";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colroterstes
            //
            this.colroterstes.Name = "colroterstes";
            //
            // colStatus
            //
            this.colStatus.Name = "colStatus";
            //
            // colStatusFP
            //
            this.colStatusFP.Name = "colStatusFP";
            //
            // colSZ
            //
            this.colSZ.Name = "colSZ";
            //
            // colTyp
            //
            this.colTyp.Name = "colTyp";
            //
            // colUE
            //
            this.colUE.Name = "colUE";
            //
            // colWHbis
            //
            this.colWHbis.Name = "colWHbis";
            //
            // colWHvon
            //
            this.colWHvon.Name = "colWHvon";
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
            // CtlQueryWhFinanzplaeneAuszahlungen
            //
            this.Name = "CtlQueryWhFinanzplaeneAuszahlungen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurLaufende.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Public Methods

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
                {
                    if (ctl is KissButtonEdit)
                    {
                        KissButtonEdit edt = (KissButtonEdit)ctl;
                        edt.CheckPendingSearchValue();
                    }
                }
            }
            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtNurAktive.Checked = true;

            try
            {
                if (!DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlGruppe"))
                    edtSucheGruppe.EditValue = qryDat["TeamCode"];

                if (!DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlTeam"))
                    edtSucheTeam.EditValue   = qryDat["OrgUnitID"];

                if (!DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlGruppe") &&
                    !DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlTeam"))
                {
                    edtUserID.EditValue      = DBUtil.ExecuteScalarSQL("select DisplayText from vwUser where UserID = {0}",Session.User.UserID);
                    edtUserID.LookupID       = Session.User.UserID;
                }
            }
            catch {}

            edtUserID.Focus();
        }

        #endregion

        #region Private Methods

        private void btnJumpTo_Click(object sender, System.EventArgs e)
        {
            if (qryQuery.Row == null) return;

            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=3;" +
                "TreeNodeID=CtlWhFinanzplan{1};",
                qryQuery["FallBaPersonID$"],
                qryQuery["BgFinanzplanID$"]);

            System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(jumpToPath);
            bool result = FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private void edtSucheGruppe_EditValueChanged(object sender, System.EventArgs e)
        {
            edtSucheTeam.LOVFilter = (string) DBUtil.ExecuteScalarSQL(@"
                     SELECT Filter = IsNull(Value1, '')
                     FROM XLOVCode
                     WHERE LOVName = 'QuOrgUnitGroup' AND Code = {0}
                     UNION ALL SELECT 'FF'", edtSucheGruppe.EditValue);
            edtSucheTeam.LOVName = "QuOrgUnitTeam";

            edtSucheTeam.EditValue = DBNull.Value;
            edtUserID.LookupID     = DBNull.Value;
            edtUserID.EditValue    = DBNull.Value;
        }

        private void edtSucheTeam_EditValueChanged(object sender, System.EventArgs e)
        {
            edtUserID.LookupID  = DBNull.Value;
            edtUserID.EditValue = DBNull.Value;
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
              if (e.ButtonClicked)
                SearchString = "%";
              else
              {
                edtUserID.LookupID   = DBNull.Value;
                edtUserID.EditValue  = DBNull.Value;
                return;
              }
            }

            string WhereAddOn = "";
            if (!DBUtil.IsEmpty(edtSucheGruppe.EditValue) ||!DBUtil.IsEmpty(edtSucheTeam.EditValue))
            {
                string GruppeText = DBUtil.IsEmpty(edtSucheGruppe.EditValue) ? "null" : edtSucheGruppe.EditValue.ToString();
                string TeamText   = DBUtil.IsEmpty(edtSucheTeam.EditValue) ? "null" : edtSucheTeam.EditValue.ToString();
                WhereAddOn = " and OrgUnitID in (select OrgUnitID from dbo.fnOrgUnitsOfTeam(" + GruppeText + "," + TeamText + ")) ";
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                [Kürzel] = LogonName,
                [Mitarbeiter/in] = NameVorname,
                [Org.Einheit] = OrgUnit,
                DisplayText$ = DisplayText
              FROM   vwUser
              WHERE  DisplayText LIKE '%' + {0} + '%' " + WhereAddOn + @"
              ORDER BY NameVorname",
              SearchString,
              e.ButtonClicked,null,null,null);

            if (!e.Cancel)
            {
            if (DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlGruppe"))
                edtSucheGruppe.EditValue     = null;

            if (DBUtil.UserHasRight("CtlQueryWhFinanzplaeneAuszahlungen_AuswahlTeam"))
                edtSucheTeam.EditValue   = null;

            edtUserID.LookupID   = dlg["ID$"];
            edtUserID.EditValue  = dlg["DisplayText$"].ToString();
            }
        }

        #endregion
    }
}