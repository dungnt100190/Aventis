using System;

using Kiss.Interfaces.UI;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    public class CtlQueryBDEFakturaBWED : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        // default search settings
        private int _userOrgUnitID = -1; // store the user's orgunitid

        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBezirk;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGebdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colKTRLA;
        private DevExpress.XtraGrid.Columns.GridColumn colNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colRechnungsadresseBW;
        private DevExpress.XtraGrid.Columns.GridColumn colRechnungsadresseED1;
        private DevExpress.XtraGrid.Columns.GridColumn colRechnungsadresseED2;
        private DevExpress.XtraGrid.Columns.GridColumn colStunden;
        private DevExpress.XtraGrid.Columns.GridColumn colTag;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnort;
        private DevExpress.XtraGrid.Columns.GridColumn colZeitraum;
        private DevExpress.XtraGrid.Columns.GridColumn colZuschlag;
        private KiSS4.Gui.KissLookUpEdit edtSucheFakturaCode;
        private KiSS4.Gui.KissButtonEdit edtSucheKlient;
        private KiSS4.Gui.KissLookUpEdit edtSucheKostenstelle;
        private KiSS4.Gui.KissCalcEdit edtSucheLanguageCode;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumVon;
        private KiSS4.Gui.KissGroupBox grpHiddenSearch;
        private KiSS4.Gui.KissLabel lblSucheFakturaCode;
        private KiSS4.Gui.KissLabel lblSucheHiddenLanguageCode;
        private KiSS4.Gui.KissLabel lblSucheKlient;
        private KiSS4.Gui.KissLabel lblSucheKostenstelle;
        private KiSS4.Gui.KissLabel lblSucheZeitraumBis;
        private KiSS4.Gui.KissLabel lblSucheZeitraumVon;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryBDEFakturaBWED()
        {
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBDEFakturaBWED));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheFakturaCode = new KiSS4.Gui.KissLabel();
            this.edtSucheFakturaCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheZeitraumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheZeitraumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheKlient = new KiSS4.Gui.KissLabel();
            this.edtSucheKlient = new KiSS4.Gui.KissButtonEdit();
            this.grpHiddenSearch = new KiSS4.Gui.KissGroupBox();
            this.edtSucheLanguageCode = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheHiddenLanguageCode = new KiSS4.Gui.KissLabel();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezirk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGebdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKTRLA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechnungsadresseBW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechnungsadresseED1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechnungsadresseED2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStunden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZeitraum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuschlag = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFakturaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFakturaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFakturaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            this.grpHiddenSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLanguageCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenLanguageCode)).BeginInit();
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
            this.xDocument.Location = new System.Drawing.Point(188, 398);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument öffnen")});
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Size = new System.Drawing.Size(179, 24);
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
            this.tpgSuchen.Controls.Add(this.grpHiddenSearch);
            this.tpgSuchen.Controls.Add(this.edtSucheKlient);
            this.tpgSuchen.Controls.Add(this.lblSucheKlient);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.edtSucheFakturaCode);
            this.tpgSuchen.Controls.Add(this.lblSucheFakturaCode);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFakturaCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFakturaCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grpHiddenSearch, 0);
            //
            // lblSucheFakturaCode
            //
            this.lblSucheFakturaCode.Location = new System.Drawing.Point(31, 40);
            this.lblSucheFakturaCode.Name = "lblSucheFakturaCode";
            this.lblSucheFakturaCode.Size = new System.Drawing.Size(100, 23);
            this.lblSucheFakturaCode.TabIndex = 1;
            this.lblSucheFakturaCode.Text = "Faktura";
            this.lblSucheFakturaCode.UseCompatibleTextRendering = true;
            //
            // edtSucheFakturaCode
            //
            this.edtSucheFakturaCode.AllowNull = false;
            this.edtSucheFakturaCode.Location = new System.Drawing.Point(137, 39);
            this.edtSucheFakturaCode.LOVName = "BDELeistungsartAuswFaktura";
            this.edtSucheFakturaCode.Name = "edtSucheFakturaCode";
            this.edtSucheFakturaCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFakturaCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFakturaCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFakturaCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFakturaCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFakturaCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFakturaCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFakturaCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFakturaCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFakturaCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFakturaCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheFakturaCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheFakturaCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFakturaCode.Properties.NullText = "";
            this.edtSucheFakturaCode.Properties.ShowFooter = false;
            this.edtSucheFakturaCode.Properties.ShowHeader = false;
            this.edtSucheFakturaCode.Size = new System.Drawing.Size(244, 24);
            this.edtSucheFakturaCode.TabIndex = 2;
            //
            // lblSucheKostenstelle
            //
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(31, 69);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(100, 24);
            this.lblSucheKostenstelle.TabIndex = 3;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            //
            // edtSucheKostenstelle
            //
            this.edtSucheKostenstelle.Location = new System.Drawing.Point(137, 69);
            this.edtSucheKostenstelle.Name = "edtSucheKostenstelle";
            this.edtSucheKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheKostenstelle.Properties.DisplayMember = "Text";
            this.edtSucheKostenstelle.Properties.NullText = "";
            this.edtSucheKostenstelle.Properties.ShowFooter = false;
            this.edtSucheKostenstelle.Properties.ShowHeader = false;
            this.edtSucheKostenstelle.Properties.ValueMember = "Code";
            this.edtSucheKostenstelle.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKostenstelle.TabIndex = 4;
            //
            // lblSucheZeitraumVon
            //
            this.lblSucheZeitraumVon.Location = new System.Drawing.Point(31, 101);
            this.lblSucheZeitraumVon.Name = "lblSucheZeitraumVon";
            this.lblSucheZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.lblSucheZeitraumVon.TabIndex = 5;
            this.lblSucheZeitraumVon.Text = "Zeitraum von";
            this.lblSucheZeitraumVon.UseCompatibleTextRendering = true;
            //
            // edtSucheZeitraumVon
            //
            this.edtSucheZeitraumVon.EditValue = null;
            this.edtSucheZeitraumVon.Location = new System.Drawing.Point(137, 99);
            this.edtSucheZeitraumVon.Name = "edtSucheZeitraumVon";
            this.edtSucheZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumVon.Properties.ShowToday = false;
            this.edtSucheZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumVon.TabIndex = 6;
            //
            // lblSucheZeitraumBis
            //
            this.lblSucheZeitraumBis.Location = new System.Drawing.Point(243, 99);
            this.lblSucheZeitraumBis.Name = "lblSucheZeitraumBis";
            this.lblSucheZeitraumBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheZeitraumBis.TabIndex = 7;
            this.lblSucheZeitraumBis.Text = "bis";
            this.lblSucheZeitraumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheZeitraumBis
            //
            this.edtSucheZeitraumBis.EditValue = null;
            this.edtSucheZeitraumBis.Location = new System.Drawing.Point(281, 99);
            this.edtSucheZeitraumBis.Name = "edtSucheZeitraumBis";
            this.edtSucheZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumBis.Properties.ShowToday = false;
            this.edtSucheZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumBis.TabIndex = 8;
            //
            // lblSucheKlient
            //
            this.lblSucheKlient.Location = new System.Drawing.Point(31, 129);
            this.lblSucheKlient.Name = "lblSucheKlient";
            this.lblSucheKlient.Size = new System.Drawing.Size(100, 24);
            this.lblSucheKlient.TabIndex = 9;
            this.lblSucheKlient.Text = "Klient/in";
            this.lblSucheKlient.UseCompatibleTextRendering = true;
            //
            // edtSucheKlient
            //
            this.edtSucheKlient.Location = new System.Drawing.Point(137, 129);
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKlient.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKlient.TabIndex = 10;
            this.edtSucheKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheKlient_UserModifiedFld);
            //
            // grpHiddenSearch
            //
            this.grpHiddenSearch.Controls.Add(this.edtSucheLanguageCode);
            this.grpHiddenSearch.Controls.Add(this.lblSucheHiddenLanguageCode);
            this.grpHiddenSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpHiddenSearch.Location = new System.Drawing.Point(424, 39);
            this.grpHiddenSearch.Name = "grpHiddenSearch";
            this.grpHiddenSearch.Size = new System.Drawing.Size(161, 54);
            this.grpHiddenSearch.TabIndex = 11;
            this.grpHiddenSearch.TabStop = false;
            this.grpHiddenSearch.Text = "Hidden Fields";
            this.grpHiddenSearch.UseCompatibleTextRendering = true;
            this.grpHiddenSearch.Visible = false;
            //
            // edtSucheLanguageCode
            //
            this.edtSucheLanguageCode.Location = new System.Drawing.Point(107, 17);
            this.edtSucheLanguageCode.Name = "edtSucheLanguageCode";
            this.edtSucheLanguageCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheLanguageCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLanguageCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLanguageCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLanguageCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLanguageCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLanguageCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLanguageCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLanguageCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLanguageCode.Size = new System.Drawing.Size(43, 24);
            this.edtSucheLanguageCode.TabIndex = 1;
            //
            // lblSucheHiddenLanguageCode
            //
            this.lblSucheHiddenLanguageCode.Location = new System.Drawing.Point(6, 17);
            this.lblSucheHiddenLanguageCode.Name = "lblSucheHiddenLanguageCode";
            this.lblSucheHiddenLanguageCode.Size = new System.Drawing.Size(95, 24);
            this.lblSucheHiddenLanguageCode.TabIndex = 0;
            this.lblSucheHiddenLanguageCode.Text = "LanguageCode";
            this.lblSucheHiddenLanguageCode.UseCompatibleTextRendering = true;
            //
            // colBemerkung
            //
            this.colBemerkung.Name = "colBemerkung";
            //
            // colBezirk
            //
            this.colBezirk.Name = "colBezirk";
            //
            // colDatum
            //
            this.colDatum.Name = "colDatum";
            //
            // colGebdatum
            //
            this.colGebdatum.Name = "colGebdatum";
            //
            // colKostenstelle
            //
            this.colKostenstelle.Name = "colKostenstelle";
            //
            // colKTRLA
            //
            this.colKTRLA.Name = "colKTRLA";
            //
            // colNacht
            //
            this.colNacht.Name = "colNacht";
            //
            // colName
            //
            this.colName.Name = "colName";
            //
            // colPLZ
            //
            this.colPLZ.Name = "colPLZ";
            //
            // colRechnungsadresseBW
            //
            this.colRechnungsadresseBW.Name = "colRechnungsadresseBW";
            //
            // colRechnungsadresseED1
            //
            this.colRechnungsadresseED1.Name = "colRechnungsadresseED1";
            //
            // colRechnungsadresseED2
            //
            this.colRechnungsadresseED2.Name = "colRechnungsadresseED2";
            //
            // colStunden
            //
            this.colStunden.Name = "colStunden";
            //
            // colTag
            //
            this.colTag.Name = "colTag";
            //
            // colVorname
            //
            this.colVorname.Name = "colVorname";
            //
            // colWohnort
            //
            this.colWohnort.Name = "colWohnort";
            //
            // colZeitraum
            //
            this.colZeitraum.Name = "colZeitraum";
            //
            // colZuschlag
            //
            this.colZuschlag.Name = "colZuschlag";
            //
            // CtlQueryBDEFakturaBWED
            //
            this.Name = "CtlQueryBDEFakturaBWED";
            this.Load += new System.EventHandler(this.CtlQueryBDEFakturaBWED_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFakturaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFakturaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFakturaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            this.grpHiddenSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLanguageCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenLanguageCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryBDEFakturaBWED_Load(object sender, System.EventArgs e)
        {
            // DEFAULT VALUES:
            // get users member orgunit
            _userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            // SEARCH:
            // fill dropdowns data, depending on rights (no special rights, therefore use admin-state)
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID, Session.User.IsUserAdmin, Session.User.IsUserAdmin, edtSucheKostenstelle);

            // INIT
            // start with new search
            NewSearch();
        }

        private void edtSucheKlient_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogKlient(sender, e, edtSucheKlient);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply static search values
            edtSucheLanguageCode.EditValue = Session.User.LanguageCode;

            // default Kostenstelle
            edtSucheKostenstelle.EditValue = _userOrgUnitID;

            // default Faktura
            edtSucheFakturaCode.EditValue = 0; // BW

            // set focus
            edtSucheKostenstelle.Focus();
        }

        protected override void RunSearch()
        {
            // move focus to apply datetime
            edtSucheKostenstelle.Focus();

            // check required fields
            if (DBUtil.IsEmpty(edtSucheFakturaCode.EditValue))
            {
                // FakturaCode is required
                KissMsg.ShowInfo(Name, "RequiredSearchFaktura", "Das Feld 'Faktura' wird für die Suche benötigt!");
                edtSucheFakturaCode.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheKostenstelle.EditValue) && !Session.User.IsUserAdmin)
            {
                // Kostenstelle is required
                KissMsg.ShowInfo(Name, "RequiredSearchKostenstelle", "Das Feld 'Kostenstelle' wird für die Suche benötigt!");
                edtSucheKostenstelle.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheZeitraumVon.EditValue))
            {
                // Kostenstelle is required
                KissMsg.ShowInfo(Name, "RequiredSearchZeitraumVon", "Das Feld 'Zeitraum von' wird für die Suche benötigt!");
                edtSucheZeitraumVon.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheZeitraumBis.EditValue))
            {
                // Kostenstelle is required
                KissMsg.ShowInfo(Name, "RequiredSearchZeitraumBis", "Das Feld 'Zeitraum bis' wird für die Suche benötigt!");
                edtSucheZeitraumBis.Focus();

                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private bool DialogKlient(object sender, UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // validate edt
                if (edt != edtSucheKlient)
                {
                    // do nothing
                    return false;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // user
                        edt.EditValue = null;
                        edt.LookupID = null;

                        // done
                        return true;
                    }
                }

                // search user (only within KGS and those who are not yet in use within this Einsatzvereinbarung)
                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT PRS.*
                    FROM dbo.fnDlgPersonSuchenKGS({0}, 1, N'{1}') PRS
                    WHERE PRS.Name LIKE N'{1}%';", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // user
                    edt.EditValue = dlg["Name"];
                    edt.LookupID = dlg["BaPersonID$"];

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        #endregion

        #endregion
    }
}