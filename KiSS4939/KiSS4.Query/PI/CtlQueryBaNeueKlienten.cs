using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query.PI
{
    public class CtlQueryBaNeueKlienten : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnrede;
        private DevExpress.XtraGrid.Columns.GridColumn colAnschrift;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlKlientinnen;
        private DevExpress.XtraGrid.Columns.GridColumn colBSVBehinderungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colBezirk;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colHauptbehinderungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colIVBerechtigung;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrganisationseinheit;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlicherFV;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colmw;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissLookUpEdit edtSucheOrganisationseinheit;
        private KiSS4.Gui.KissGrid grdListe2Mitarbeiter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe2Mitarbeiter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery1;
        private Boolean isChiefOrRepresentative = false; // store if sesssion user is chief or representative of current users' oe
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheOrganisationseinheit;
        private KiSS4.DB.SqlQuery qryListe2Mitarbeiter;

        // rights
        private Boolean specialRightOEKGS = false; // store if user has special rights to show all orgunits within its KGS
        private SharpLibrary.WinControls.TabPageEx tpgListe2;

        // default search settings
        private Int32 userOrgUnitID = -1; // store the user's orgunitid

        // others
        private Int32 validateYear = -1; // store config value for validation year

        #endregion

        #region Constructors

        public CtlQueryBaNeueKlienten()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaNeueKlienten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheOrganisationseinheit = new KiSS4.Gui.KissLabel();
            this.edtSucheOrganisationseinheit = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe2Mitarbeiter = new KiSS4.Gui.KissGrid();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnrede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnschrift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlKlientinnen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezirk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBSVBehinderungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHauptbehinderungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVBerechtigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrganisationseinheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlicherFV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvListe2Mitarbeiter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvQuery1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryListe2Mitarbeiter = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrganisationseinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrganisationseinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrganisationseinheit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2Mitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2Mitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2Mitarbeiter)).BeginInit();
            this.SuspendLayout();
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Location = new System.Drawing.Point(3, 3);
            this.grdQuery1.MainView = this.grvQuery1;
            this.grdQuery1.Size = new System.Drawing.Size(766, 389);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvQuery1});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(180, 397);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument öffnen")});
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Size = new System.Drawing.Size(171, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.SelectedTabIndex = 2;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgListe2});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Klient/innen";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheOrganisationseinheit);
            this.tpgSuchen.Controls.Add(this.lblSucheOrganisationseinheit);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOrganisationseinheit, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrganisationseinheit, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            //
            // lblSucheOrganisationseinheit
            //
            this.lblSucheOrganisationseinheit.Location = new System.Drawing.Point(31, 40);
            this.lblSucheOrganisationseinheit.Name = "lblSucheOrganisationseinheit";
            this.lblSucheOrganisationseinheit.Size = new System.Drawing.Size(129, 24);
            this.lblSucheOrganisationseinheit.TabIndex = 1;
            this.lblSucheOrganisationseinheit.Text = "Organisationseinheit";
            this.lblSucheOrganisationseinheit.UseCompatibleTextRendering = true;
            //
            // edtSucheOrganisationseinheit
            //
            this.edtSucheOrganisationseinheit.Location = new System.Drawing.Point(166, 40);
            this.edtSucheOrganisationseinheit.Name = "edtSucheOrganisationseinheit";
            this.edtSucheOrganisationseinheit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrganisationseinheit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrganisationseinheit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrganisationseinheit.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrganisationseinheit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrganisationseinheit.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrganisationseinheit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheOrganisationseinheit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrganisationseinheit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheOrganisationseinheit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheOrganisationseinheit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheOrganisationseinheit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheOrganisationseinheit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheOrganisationseinheit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheOrganisationseinheit.Properties.DisplayMember = "Text";
            this.edtSucheOrganisationseinheit.Properties.NullText = "";
            this.edtSucheOrganisationseinheit.Properties.ShowFooter = false;
            this.edtSucheOrganisationseinheit.Properties.ShowHeader = false;
            this.edtSucheOrganisationseinheit.Properties.ValueMember = "Code";
            this.edtSucheOrganisationseinheit.Size = new System.Drawing.Size(224, 24);
            this.edtSucheOrganisationseinheit.TabIndex = 2;
            //
            // lblSucheMitarbeiter
            //
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 70);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(129, 24);
            this.lblSucheMitarbeiter.TabIndex = 3;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            //
            // edtSucheMitarbeiter
            //
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(166, 70);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(224, 24);
            this.edtSucheMitarbeiter.TabIndex = 4;
            //
            // lblSucheDatumVon
            //
            this.lblSucheDatumVon.Location = new System.Drawing.Point(31, 100);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(129, 24);
            this.lblSucheDatumVon.TabIndex = 5;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumVon
            //
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(166, 100);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumVon.TabIndex = 6;
            //
            // lblSucheDatumBis
            //
            this.lblSucheDatumBis.Location = new System.Drawing.Point(272, 100);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(12, 24);
            this.lblSucheDatumBis.TabIndex = 7;
            this.lblSucheDatumBis.Text = "-";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumBis
            //
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(290, 100);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 8;
            //
            // tpgListe2
            //
            this.tpgListe2.Controls.Add(this.grdListe2Mitarbeiter);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 1;
            this.tpgListe2.Title = "Mitarbeiter/innen";
            //
            // grdListe2Mitarbeiter
            //
            this.grdListe2Mitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe2Mitarbeiter.DataSource = this.qryListe2Mitarbeiter;
            this.grdListe2Mitarbeiter.EmbeddedNavigator.Name = "";
            this.grdListe2Mitarbeiter.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe2Mitarbeiter.Location = new System.Drawing.Point(3, 3);
            this.grdListe2Mitarbeiter.MainView = this.grvListe2Mitarbeiter;
            this.grdListe2Mitarbeiter.Name = "grdListe2Mitarbeiter";
            this.grdListe2Mitarbeiter.Size = new System.Drawing.Size(766, 418);
            this.grdListe2Mitarbeiter.TabIndex = 1;
            this.grdListe2Mitarbeiter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvListe2Mitarbeiter});
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
            //
            // colAnrede
            //
            this.colAnrede.Name = "colAnrede";
            //
            // colAnschrift
            //
            this.colAnschrift.Name = "colAnschrift";
            //
            // colAnzahlKlientinnen
            //
            this.colAnzahlKlientinnen.Name = "colAnzahlKlientinnen";
            //
            // colBezirk
            //
            this.colBezirk.Name = "colBezirk";
            //
            // colBSVBehinderungsart
            //
            this.colBSVBehinderungsart.Name = "colBSVBehinderungsart";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colHauptbehinderungsart
            //
            this.colHauptbehinderungsart.Name = "colHauptbehinderungsart";
            //
            // colIVBerechtigung
            //
            this.colIVBerechtigung.Name = "colIVBerechtigung";
            //
            // colKanton
            //
            this.colKanton.Name = "colKanton";
            //
            // colmw
            //
            this.colmw.Name = "colmw";
            //
            // colName
            //
            this.colName.Name = "colName";
            //
            // colNationalitt
            //
            this.colNationalitt.Name = "colNationalitt";
            //
            // colNr
            //
            this.colNr.Name = "colNr";
            //
            // colOrganisationseinheit
            //
            this.colOrganisationseinheit.Name = "colOrganisationseinheit";
            //
            // colOrt
            //
            this.colOrt.Name = "colOrt";
            //
            // colPeriode
            //
            this.colPeriode.Name = "colPeriode";
            //
            // colPLZ
            //
            this.colPLZ.Name = "colPLZ";
            //
            // colVerantwortlicherFV
            //
            this.colVerantwortlicherFV.Name = "colVerantwortlicherFV";
            //
            // colVorname
            //
            this.colVorname.Name = "colVorname";
            //
            // grvListe2Mitarbeiter
            //
            this.grvListe2Mitarbeiter.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe2Mitarbeiter.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.Empty.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2Mitarbeiter.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe2Mitarbeiter.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe2Mitarbeiter.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2Mitarbeiter.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe2Mitarbeiter.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe2Mitarbeiter.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2Mitarbeiter.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2Mitarbeiter.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2Mitarbeiter.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2Mitarbeiter.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe2Mitarbeiter.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe2Mitarbeiter.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe2Mitarbeiter.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2Mitarbeiter.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe2Mitarbeiter.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe2Mitarbeiter.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2Mitarbeiter.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe2Mitarbeiter.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2Mitarbeiter.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.OddRow.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe2Mitarbeiter.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.Row.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.Appearance.Row.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Mitarbeiter.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe2Mitarbeiter.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2Mitarbeiter.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe2Mitarbeiter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe2Mitarbeiter.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe2Mitarbeiter.GridControl = this.grdListe2Mitarbeiter;
            this.grvListe2Mitarbeiter.Name = "grvListe2Mitarbeiter";
            this.grvListe2Mitarbeiter.OptionsBehavior.Editable = false;
            this.grvListe2Mitarbeiter.OptionsCustomization.AllowFilter = false;
            this.grvListe2Mitarbeiter.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe2Mitarbeiter.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe2Mitarbeiter.OptionsNavigation.UseTabKey = false;
            this.grvListe2Mitarbeiter.OptionsView.ColumnAutoWidth = false;
            this.grvListe2Mitarbeiter.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe2Mitarbeiter.OptionsView.ShowGroupPanel = false;
            this.grvListe2Mitarbeiter.OptionsView.ShowIndicator = false;
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            this.grvQuery1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
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
            // qryListe2Mitarbeiter
            //
            this.qryListe2Mitarbeiter.HostControl = this;
            //
            // CtlQueryBaNeueKlienten
            //
            this.Name = "CtlQueryBaNeueKlienten";
            this.Load += new System.EventHandler(this.CtlQueryBaNeueKlienten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrganisationseinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrganisationseinheit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrganisationseinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2Mitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2Mitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2Mitarbeiter)).EndInit();
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

        #region Public Methods

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage("CtlQueryBaNeueKlienten", "Liste1TitelKlient", "Klient/innen");
            tpgListe2.Title = KissMsg.GetMLMessage("CtlQueryBaNeueKlienten", "Liste2TitelMitarbeiter", "Mitarbeiter/innen");
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // default OrgUnit (for all users equal)
            edtSucheOrganisationseinheit.EditValue = this.userOrgUnitID;

            // apply rights and default search parameters
            if (!this.specialRightOEKGS)
            {
                // user has no special rights, setup depending on representative-state
                edtSucheMitarbeiter.EditMode = this.isChiefOrRepresentative ? EditModeType.Normal : EditModeType.ReadOnly;
                edtSucheMitarbeiter.EditValue = this.isChiefOrRepresentative ? null : (Object)Session.User.UserId;
            }
            else
            {
                // kgs-user, no restrictions to user-field
                edtSucheMitarbeiter.EditMode = EditModeType.Normal;
                edtSucheMitarbeiter.EditValue = null;
            }

            // date range
            edtSucheDatumVon.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            edtSucheDatumBis.EditValue = new DateTime(DateTime.Now.Year, 12, 31);

            // set focus
            edtSucheOrganisationseinheit.Focus();
        }

        protected override void RunSearch()
        {
            // move focus to apply datetime
            edtSucheOrganisationseinheit.Focus();

            // check required fields
            if (DBUtil.IsEmpty(edtSucheOrganisationseinheit.EditValue))
            {
                // Organisationseinheit is required
                KissMsg.ShowInfo("CtlQueryBaNeueKlienten", "RequiredSearchOrgUnit", "Das Feld 'Organisationseiheit' wird für die Suche benötigt!");
                edtSucheOrganisationseinheit.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheDatumVon.EditValue))
            {
                // DatumVon is required
                KissMsg.ShowInfo("CtlQueryBaNeueKlienten", "RequiredSearchDatumVon", "Das Feld 'Datum von' wird für die Suche benötigt!");
                edtSucheDatumVon.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheDatumBis.EditValue))
            {
                // DatumBis is required
                KissMsg.ShowInfo("CtlQueryBaNeueKlienten", "RequiredSearchDatumVon", "Das Feld 'Datum bis' wird für die Suche benötigt!");
                edtSucheDatumBis.Focus();

                throw new KissCancelException();
            }

            // validate dates
            if (Convert.ToDateTime(edtSucheDatumVon.EditValue).Year < this.validateYear || Convert.ToDateTime(edtSucheDatumBis.EditValue).Year < this.validateYear)
            {
                // year cannot be smaller than config value
                KissMsg.ShowInfo("CtlQueryBaNeueKlienten", "RequiredSearchDatesInvalid", "Das Jahr von 'Datum von' oder 'Datum bis' darf nicht kleiner als '{0}' sein!", 0, 0, this.validateYear);
                edtSucheDatumVon.Focus();

                throw new KissCancelException();
            }

            if (Convert.ToDateTime(edtSucheDatumVon.EditValue).Year != Convert.ToDateTime(edtSucheDatumBis.EditValue).Year)
            {
                // years cannot be different
                KissMsg.ShowInfo("CtlQueryBaNeueKlienten", "SearchYearsInvalid", "Die Werte aus 'Datum von' und 'Datum bis' müssen innerhalb desselben Jahres liegen!");
                edtSucheDatumVon.Focus();

                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryBaNeueKlienten_Load(object sender, System.EventArgs e)
        {
            // SETTINGS
            this.validateYear = DBUtil.GetConfigInt(@"System\ZLE\StartJahr", -1);

            // validate
            if (this.validateYear < 2000)
            {
                // invalid value, do not continue
                throw new ArgumentOutOfRangeException("Invalid configuration value for year-validation, cannot continue.");
            }

            // DEFAULT VALUES:
            // get users member orgunit
            this.userOrgUnitID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT CONVERT(INT, ISNULL(dbo.fnOrgUnitOfUser({0}, 1), -1))", Session.User.UserId));

            // RIGHTS:
            // get if user has special right to select all orgunits and users within KGS
            this.specialRightOEKGS = DBUtil.UserHasRight("QRYNeueKlientenOrganisationseinheit");

            // get if user is zle chief or representative of ANY orgunit
            this.isChiefOrRepresentative = IsChiefOrRepresentative(-1);

            // SEARCH:
            // fill dropdowns data, depending on rights
            SqlQuery qryOE = null;

            if (this.specialRightOEKGS)
            {
                // kgs-user, get all orgunits within KGS
                qryOE = DBUtil.OpenSQL(@"
                            -- orgunits
                            SELECT [Code] = ORG.OrgUnitID,
                                   [Text] = ORG.ItemName + ISNULL(' ('+CONVERT(VARCHAR(50), ORG.Kostenstelle)+')',  ''),
                                   [Kostenstelle$] = ORG.Kostenstelle
                            FROM dbo.fnGetCantonsOrgUnits({0}) COU
                              INNER JOIN XOrgUnit ORG ON ORG.OrgUnitID = COU.OrgUnitID
                            ORDER BY [Kostenstelle$], [Text], [Code]", Session.User.UserId);
            }
            else
            {
                // normal user
                qryOE = DBUtil.OpenSQL(@"
                            SELECT *
                            FROM dbo.fnBDEGetOEOrgUnitListZLE({0}, 0, 'OrgUnitKS', 'Kostenstelle')", Session.User.UserId);
            }

            // setup edtSucheOrganisationseinheit
            this.edtSucheOrganisationseinheit.Properties.DropDownRows = Math.Min(qryOE.Count, 14);
            this.edtSucheOrganisationseinheit.Properties.DataSource = qryOE;

            // fill dropdown of users, depending on rights
            SqlQuery qryUsers = null;

            if (this.specialRightOEKGS)
            {
                // kgs-user, get all users within KGS
                qryUsers = DBUtil.OpenSQL(@"
                            -- empty entry for admins
                            SELECT Code = NULL,
                                   Text = ''

                            UNION ALL

                            -- other users
                            SELECT Code = UserID,
                                   Text = Name + ISNULL(' (' + LogonName + ')', '')
                            FROM dbo.fnGetCantonsOrgUnitsUsers({0})
                            ORDER BY Text", Session.User.UserId);
            }
            else
            {
                // zle-user or normal user
                qryUsers = DBUtil.OpenSQL(@"SELECT * FROM dbo.fnBDEGetOEUserList({0}, {1})", Session.User.UserId, this.isChiefOrRepresentative);
            }

            // setup edtSucheMitarbeiter
            this.edtSucheMitarbeiter.Properties.DropDownRows = Math.Min(qryUsers.Count, 14);
            this.edtSucheMitarbeiter.Properties.DataSource = qryUsers;

            // QUERIES:
            SetupSqlQuery(qryQuery, "klient/innen");
            SetupSqlQuery(qryListe2Mitarbeiter, "mitarbeiter/innen");

            // INIT
            // start with new search
            NewSearch();
        }

        // check if user is chief or representative on any (orgunitid < 1) or on given orgunit (orgunitid >= 1)
        private Boolean IsChiefOrRepresentative(Int32 orgUnitID)
        {
            return Session.User.IsUserAdmin || Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                    DECLARE @isChief INT

                    SELECT @isChief = OrgUnitID
                    FROM XOrgUnit
                    WHERE (ChiefID = {0} OR RepresentativeID = {0}) AND
                          ({1} < 1 OR OrgUnitID = {1})

                    SET @isChief = ISNULL(@isChief, 0)
                    IF(@isChief > 1) SET @isChief = 1

                    SELECT @isChief", Session.User.UserId, orgUnitID));
        }

        private void SetupSqlQuery(SqlQuery qry, String resultTable)
        {
            qry.SelectStatement = @"
                    -- declare vars
                    DECLARE @OrgUnitID INT
                    DECLARE @SearchUserID INT
                    DECLARE @DatumVon DATETIME
                    DECLARE @DatumBis DATETIME

                    -- fill vars with search parameters (if value is given)
                    --- SET @OrgUnitID    = {edtSucheOrganisationseinheit}
                    --- SET @SearchUserID = {edtSucheMitarbeiter}
                    --- SET @DatumVon     = {edtSucheDatumVon}
                    --- SET @DatumBis     = {edtSucheDatumBis}

                    EXEC spQRYNeueKlienten " + Convert.ToString(Session.User.LanguageCode) + @",
                                             @OrgUnitID,
                                             @SearchUserID,
                                             @DatumVon,
                                             @DatumBis,
                                             '" + resultTable + @"'";
        }

        #endregion
    }
}