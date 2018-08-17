using System;

using KiSS4.Common.PI;
using KiSS4.DB;

namespace KiSS4.Query.PI
{
    /// <summary>
    /// Control, used as base class for queries of Pro Infirmis such as "Aktvie Dossiers Sozialdaten"
    /// </summary>
    public class CtlQueryFaAktiveDossiersBase : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private bool _isChiefOrRepresentative = false; // store if sesssion user is chief or representative of current users' oe
        private string _queryResultTable = string.Empty;
        private string _rightNameKostenstelleHS = string.Empty; // store the name of the special right for KostenstelleHS
        private string _rightNameKostenstelleKGS = string.Empty; // store the name of the special right for KostenstelleKGS
        private bool _specialRightKostenstelleHS = false; // store if user has special rights to show all orgunits (Hauptsitz)
        private bool _specialRightKostenstelleKGS = false; // store if user has special rights to show all orgunits within its KGS
        private int _userOrgUnitID = -1; // store the user's orgunitid
        private int _validateYear = -1; // store config value for validation year
        private KiSS4.Gui.KissCheckEdit chkSucheNurSozialberatung;
        private KiSS4.Gui.KissLookUpEdit edtSucheBSVBehinderungsart;
        private KiSS4.Gui.KissDateEdit edtSucheGeburtBis;
        private KiSS4.Gui.KissDateEdit edtSucheGeburtVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheHauptbehinderungsart;
        private KiSS4.Gui.KissLookUpEdit edtSucheIVBerechtigung;
        private KiSS4.Gui.KissLookUpEdit edtSucheKostenstelle;
        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumVon;
        private KiSS4.Gui.KissLabel lblSucheBSVBehinderungsart;
        private KiSS4.Gui.KissLabel lblSucheGeburtBis;
        private KiSS4.Gui.KissLabel lblSucheGeburtVon;
        private KiSS4.Gui.KissLabel lblSucheHauptbehinderungsart;
        private KiSS4.Gui.KissLabel lblSucheIVBerechtigung;
        private KiSS4.Gui.KissLabel lblSucheKostenstelle;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheZeitraumBis;
        private KiSS4.Gui.KissLabel lblSucheZeitraumVon;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryFaAktiveDossiersBase"/> class.
        /// </summary>
        public CtlQueryFaAktiveDossiersBase()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaAktiveDossiersBase));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheZeitraumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheZeitraumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheHauptbehinderungsart = new KiSS4.Gui.KissLabel();
            this.edtSucheHauptbehinderungsart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBSVBehinderungsart = new KiSS4.Gui.KissLabel();
            this.edtSucheBSVBehinderungsart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheIVBerechtigung = new KiSS4.Gui.KissLabel();
            this.edtSucheIVBerechtigung = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheGeburtVon = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtBis = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.chkSucheNurSozialberatung = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHauptbehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBSVBehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheIVBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurSozialberatung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(183, 397);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Size = new System.Drawing.Size(17, 24);
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 397);
            this.ctlGotoFall.ShowToolTipsOnIcons = true;
            this.ctlGotoFall.Size = new System.Drawing.Size(173, 26);
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(757, 24);
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
            this.tpgSuchen.Controls.Add(this.chkSucheNurSozialberatung);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.edtSucheIVBerechtigung);
            this.tpgSuchen.Controls.Add(this.lblSucheIVBerechtigung);
            this.tpgSuchen.Controls.Add(this.edtSucheBSVBehinderungsart);
            this.tpgSuchen.Controls.Add(this.lblSucheBSVBehinderungsart);
            this.tpgSuchen.Controls.Add(this.edtSucheHauptbehinderungsart);
            this.tpgSuchen.Controls.Add(this.lblSucheHauptbehinderungsart);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenstelle);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheHauptbehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheHauptbehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBSVBehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBSVBehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheIVBerechtigung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheIVBerechtigung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurSozialberatung, 0);
            // 
            // lblSucheKostenstelle
            // 
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKostenstelle.TabIndex = 1;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            // 
            // edtSucheKostenstelle
            // 
            this.edtSucheKostenstelle.Location = new System.Drawing.Point(170, 40);
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
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheKostenstelle.Properties.DisplayMember = "Text";
            this.edtSucheKostenstelle.Properties.NullText = "";
            this.edtSucheKostenstelle.Properties.ShowFooter = false;
            this.edtSucheKostenstelle.Properties.ShowHeader = false;
            this.edtSucheKostenstelle.Properties.ValueMember = "Code";
            this.edtSucheKostenstelle.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKostenstelle.TabIndex = 2;
            // 
            // lblSucheZeitraumVon
            // 
            this.lblSucheZeitraumVon.Location = new System.Drawing.Point(31, 70);
            this.lblSucheZeitraumVon.Name = "lblSucheZeitraumVon";
            this.lblSucheZeitraumVon.Size = new System.Drawing.Size(133, 24);
            this.lblSucheZeitraumVon.TabIndex = 3;
            this.lblSucheZeitraumVon.Text = "Zeitraum von";
            this.lblSucheZeitraumVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheZeitraumVon
            // 
            this.edtSucheZeitraumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSucheZeitraumVon.EditValue = null;
            this.edtSucheZeitraumVon.Location = new System.Drawing.Point(170, 70);
            this.edtSucheZeitraumVon.Name = "edtSucheZeitraumVon";
            this.edtSucheZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumVon.Properties.EditFormat.FormatString = "yyyy";
            this.edtSucheZeitraumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheZeitraumVon.Properties.Mask.EditMask = "yyyy";
            this.edtSucheZeitraumVon.Properties.ReadOnly = true;
            this.edtSucheZeitraumVon.Properties.ShowToday = false;
            this.edtSucheZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumVon.TabIndex = 4;
            // 
            // lblSucheZeitraumBis
            // 
            this.lblSucheZeitraumBis.Location = new System.Drawing.Point(276, 70);
            this.lblSucheZeitraumBis.Name = "lblSucheZeitraumBis";
            this.lblSucheZeitraumBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheZeitraumBis.TabIndex = 5;
            this.lblSucheZeitraumBis.Text = "bis";
            this.lblSucheZeitraumBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheZeitraumBis
            // 
            this.edtSucheZeitraumBis.EditValue = null;
            this.edtSucheZeitraumBis.Location = new System.Drawing.Point(314, 70);
            this.edtSucheZeitraumBis.Name = "edtSucheZeitraumBis";
            this.edtSucheZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumBis.Properties.ShowToday = false;
            this.edtSucheZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumBis.TabIndex = 6;
            this.edtSucheZeitraumBis.EditValueChanged += new System.EventHandler(this.edtSucheZeitraumBis_EditValueChanged);
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 100);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(133, 24);
            this.lblSucheMitarbeiter.TabIndex = 7;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtSucheMitarbeiter
            // 
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(170, 100);
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(244, 24);
            this.edtSucheMitarbeiter.TabIndex = 8;
            // 
            // lblSucheHauptbehinderungsart
            // 
            this.lblSucheHauptbehinderungsart.Location = new System.Drawing.Point(31, 130);
            this.lblSucheHauptbehinderungsart.Name = "lblSucheHauptbehinderungsart";
            this.lblSucheHauptbehinderungsart.Size = new System.Drawing.Size(133, 24);
            this.lblSucheHauptbehinderungsart.TabIndex = 9;
            this.lblSucheHauptbehinderungsart.Text = "Hauptbehinderungsart";
            this.lblSucheHauptbehinderungsart.UseCompatibleTextRendering = true;
            // 
            // edtSucheHauptbehinderungsart
            // 
            this.edtSucheHauptbehinderungsart.Location = new System.Drawing.Point(170, 130);
            this.edtSucheHauptbehinderungsart.LOVName = "BaBehinderungsart";
            this.edtSucheHauptbehinderungsart.Name = "edtSucheHauptbehinderungsart";
            this.edtSucheHauptbehinderungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheHauptbehinderungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheHauptbehinderungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheHauptbehinderungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheHauptbehinderungsart.Properties.NullText = "";
            this.edtSucheHauptbehinderungsart.Properties.ShowFooter = false;
            this.edtSucheHauptbehinderungsart.Properties.ShowHeader = false;
            this.edtSucheHauptbehinderungsart.Size = new System.Drawing.Size(244, 24);
            this.edtSucheHauptbehinderungsart.TabIndex = 10;
            // 
            // lblSucheBSVBehinderungsart
            // 
            this.lblSucheBSVBehinderungsart.Location = new System.Drawing.Point(31, 160);
            this.lblSucheBSVBehinderungsart.Name = "lblSucheBSVBehinderungsart";
            this.lblSucheBSVBehinderungsart.Size = new System.Drawing.Size(133, 24);
            this.lblSucheBSVBehinderungsart.TabIndex = 11;
            this.lblSucheBSVBehinderungsart.Text = "BSV-Behinderungsart";
            this.lblSucheBSVBehinderungsart.UseCompatibleTextRendering = true;
            // 
            // edtSucheBSVBehinderungsart
            // 
            this.edtSucheBSVBehinderungsart.Location = new System.Drawing.Point(170, 160);
            this.edtSucheBSVBehinderungsart.LOVName = "BaBSVBehinderungsart";
            this.edtSucheBSVBehinderungsart.Name = "edtSucheBSVBehinderungsart";
            this.edtSucheBSVBehinderungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBSVBehinderungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheBSVBehinderungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheBSVBehinderungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBSVBehinderungsart.Properties.NullText = "";
            this.edtSucheBSVBehinderungsart.Properties.ShowFooter = false;
            this.edtSucheBSVBehinderungsart.Properties.ShowHeader = false;
            this.edtSucheBSVBehinderungsart.Size = new System.Drawing.Size(244, 24);
            this.edtSucheBSVBehinderungsart.TabIndex = 12;
            // 
            // lblSucheIVBerechtigung
            // 
            this.lblSucheIVBerechtigung.Location = new System.Drawing.Point(31, 190);
            this.lblSucheIVBerechtigung.Name = "lblSucheIVBerechtigung";
            this.lblSucheIVBerechtigung.Size = new System.Drawing.Size(133, 24);
            this.lblSucheIVBerechtigung.TabIndex = 13;
            this.lblSucheIVBerechtigung.Text = "IV-Berechtigung";
            this.lblSucheIVBerechtigung.UseCompatibleTextRendering = true;
            // 
            // edtSucheIVBerechtigung
            // 
            this.edtSucheIVBerechtigung.Location = new System.Drawing.Point(170, 190);
            this.edtSucheIVBerechtigung.LOVFilter = "CODE IN (1,3)";
            this.edtSucheIVBerechtigung.LOVFilterWhereAppend = true;
            this.edtSucheIVBerechtigung.LOVName = "BaIVBerechtigung";
            this.edtSucheIVBerechtigung.Name = "edtSucheIVBerechtigung";
            this.edtSucheIVBerechtigung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheIVBerechtigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheIVBerechtigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheIVBerechtigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheIVBerechtigung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheIVBerechtigung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheIVBerechtigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheIVBerechtigung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheIVBerechtigung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheIVBerechtigung.Properties.NullText = "";
            this.edtSucheIVBerechtigung.Properties.ShowFooter = false;
            this.edtSucheIVBerechtigung.Properties.ShowHeader = false;
            this.edtSucheIVBerechtigung.Size = new System.Drawing.Size(244, 24);
            this.edtSucheIVBerechtigung.TabIndex = 14;
            // 
            // lblSucheGeburtVon
            // 
            this.lblSucheGeburtVon.Location = new System.Drawing.Point(31, 220);
            this.lblSucheGeburtVon.Name = "lblSucheGeburtVon";
            this.lblSucheGeburtVon.Size = new System.Drawing.Size(133, 24);
            this.lblSucheGeburtVon.TabIndex = 15;
            this.lblSucheGeburtVon.Text = "Geburt von";
            this.lblSucheGeburtVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheGeburtVon
            // 
            this.edtSucheGeburtVon.EditValue = null;
            this.edtSucheGeburtVon.Location = new System.Drawing.Point(170, 220);
            this.edtSucheGeburtVon.Name = "edtSucheGeburtVon";
            this.edtSucheGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeburtVon.Properties.ShowToday = false;
            this.edtSucheGeburtVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGeburtVon.TabIndex = 16;
            // 
            // lblSucheGeburtBis
            // 
            this.lblSucheGeburtBis.Location = new System.Drawing.Point(276, 220);
            this.lblSucheGeburtBis.Name = "lblSucheGeburtBis";
            this.lblSucheGeburtBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheGeburtBis.TabIndex = 17;
            this.lblSucheGeburtBis.Text = "bis";
            this.lblSucheGeburtBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheGeburtBis
            // 
            this.edtSucheGeburtBis.EditValue = null;
            this.edtSucheGeburtBis.Location = new System.Drawing.Point(314, 220);
            this.edtSucheGeburtBis.Name = "edtSucheGeburtBis";
            this.edtSucheGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeburtBis.Properties.ShowToday = false;
            this.edtSucheGeburtBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGeburtBis.TabIndex = 18;
            // 
            // chkSucheNurSozialberatung
            // 
            this.chkSucheNurSozialberatung.EditValue = false;
            this.chkSucheNurSozialberatung.Location = new System.Drawing.Point(170, 253);
            this.chkSucheNurSozialberatung.Name = "chkSucheNurSozialberatung";
            this.chkSucheNurSozialberatung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurSozialberatung.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurSozialberatung.Properties.Caption = "Nur Sozialberatung";
            this.chkSucheNurSozialberatung.Size = new System.Drawing.Size(244, 19);
            this.chkSucheNurSozialberatung.TabIndex = 19;
            // 
            // CtlQueryFaAktiveDossiersBase
            // 
            this.Name = "CtlQueryFaAktiveDossiersBase";
            this.Load += new System.EventHandler(this.CtlQueryFaAktiveDossiersBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHauptbehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBSVBehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheIVBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurSozialberatung.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Properties

        /// <summary>
        /// Set and get the name of the result table used for Liste1 within the private query builder
        /// </summary>
        internal string QueryResultTable
        {
            get
            {
                // validate
                if (string.IsNullOrEmpty(_queryResultTable))
                {
                    throw new ArgumentNullException("The value was not set and cannot be returned therefore.");
                }

                // return value
                return _queryResultTable;
            }
            set
            {
                // set the given value as property
                _queryResultTable = value;
            }
        }

        /// <summary>
        /// Set and get the name of the special right for KostenstelleHS
        /// </summary>
        internal string RightNameKostenstelleHS
        {
            get
            {
                // validate
                if (string.IsNullOrEmpty(_rightNameKostenstelleHS))
                {
                    throw new ArgumentNullException("The value was not set and cannot be returned therefore.");
                }

                // return value
                return _rightNameKostenstelleHS;
            }
            set
            {
                // set the given value as property
                _rightNameKostenstelleHS = value;
            }
        }

        /// <summary>
        /// Get the name of the special right for KostenstelleKGS
        /// </summary>
        internal string RightNameKostenstelleKGS
        {
            get
            {
                // validate
                if (string.IsNullOrEmpty(_rightNameKostenstelleKGS))
                {
                    throw new ArgumentNullException("The value was not set and cannot be returned therefore.");
                }

                // return value
                return _rightNameKostenstelleKGS;
            }
            set
            {
                // set the given value as property
                _rightNameKostenstelleKGS = value;
            }
        }

        /// <summary>
        /// Set and get if the search filter checkbox 'only SB' is displayed and useable
        /// </summary>
        internal bool UseSearchFilterCheckboxOnlySB
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void CtlQueryFaAktiveDossiersBase_Load(object sender, System.EventArgs e)
        {
            // check if designer mode to prevent errors
            if (DesignerMode)
            {
                return;
            }

            // logging
            _logger.Debug("enter");

            // SETTINGS
            _validateYear = DBUtil.GetConfigInt(@"System\ZLE\StartJahr", -1);

            // validate
            if (_validateYear < 2000)
            {
                // invalid value, do not continue
                throw new ArgumentOutOfRangeException("Invalid configuration value for year-validation, cannot continue.");
            }

            // DEFAULT VALUES:
            // get users member orgunit
            _userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            // RIGHTS:
            // get if user has special right to select specified Kostenstelle/MA
            _specialRightKostenstelleHS = DBUtil.UserHasRight(RightNameKostenstelleHS);
            _specialRightKostenstelleKGS = DBUtil.UserHasRight(RightNameKostenstelleKGS);

            // get if user is zle chief or representative of ANY orgunit
            _isChiefOrRepresentative = QryUtils.IsChiefOrRepresentative(Session.User.UserID, -1);

            // FILLTIMEOUT:
            // setup FillTimeOut for qryQuery
            if (_specialRightKostenstelleHS)
            {
                // hauptsitz, huge amount of data expected
                qryQuery.FillTimeOut = 1200; // 20min
            }
            else if (_specialRightKostenstelleKGS)
            {
                // KGS, lower amount of data, still big amount
                qryQuery.FillTimeOut = 600; // 10min
            }
            else if (_isChiefOrRepresentative)
            {
                // Chief only, lower amount
                qryQuery.FillTimeOut = 360;
            }

            // logging
            _logger.DebugFormat("SpecialRightKostenstelleHS='{0}', SpecialRightKostenstelleKGS='{1}', IsChiefOrRepresentative='{2}', qryQuery.FillTimeOut='{3}'",
                                _specialRightKostenstelleHS,
                                _specialRightKostenstelleKGS,
                                _isChiefOrRepresentative,
                                qryQuery.FillTimeOut);

            // SEARCH:
            // fill dropdowns data, depending on rights
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID,
                                              _specialRightKostenstelleHS,
                                              _specialRightKostenstelleKGS,
                                              edtSucheKostenstelle);

            BDEUtils.InitMitarbeiterDropDown(Session.User.UserID,
                                             _specialRightKostenstelleHS,
                                             _specialRightKostenstelleKGS,
                                             _isChiefOrRepresentative,
                                             edtSucheMitarbeiter);

            // search controls
            chkSucheNurSozialberatung.Visible = UseSearchFilterCheckboxOnlySB;

            // QUERIES:
            SetupSqlQuery(qryQuery, QueryResultTable);

            // INIT
            // start with new search
            NewSearch();

            // logging
            _logger.Debug("done");
        }

        private void edtSucheZeitraumBis_EditValueChanged(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if there is a date-value to parse
            if (DBUtil.IsEmpty(edtSucheZeitraumBis.EditValue))
            {
                // no value, so reset first date
                edtSucheZeitraumVon.EditValue = null;
            }
            else
            {
                // we have a date
                edtSucheZeitraumVon.EditValue = new DateTime(Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year, 1, 1);
            }

            // logging
            _logger.Debug("done");
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // just for debugging!

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Translates this instance
        /// </summary>
        public override void Translate()
        {
            // logging
            _logger.Debug("enter");

            // apply translation
            base.Translate();

            // do sorting of LOVs
            edtSucheHauptbehinderungsart.SortByFirstColumn();
            edtSucheBSVBehinderungsart.SortByFirstColumn();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage(this.Name, "Liste1Titel", "Liste");

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Initialize control for a new search
        /// </summary>
        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply rights and default search parameters
            QryUtils.NewSearchMitarbeiter(_specialRightKostenstelleHS,
                                          _specialRightKostenstelleKGS,
                                          _isChiefOrRepresentative,
                                          edtSucheMitarbeiter);

            // default Kostenstelle (for all users the same way)
            edtSucheKostenstelle.EditValue = _userOrgUnitID;

            // date range
            edtSucheZeitraumBis.EditValue = new DateTime(DateTime.Now.Year, 12, 31); // DatumVon will be calculated automatically

            // only SB
            chkSucheNurSozialberatung.Checked = false;

            // set focus
            edtSucheKostenstelle.Focus();
        }

        /// <summary>
        /// Run a search and fill datasources
        /// </summary>
        protected override void RunSearch()
        {
            // logging
            _logger.Debug("enter");

            // validate Kostenstelle and Mitarbeiter
            QryUtils.RunSearchValidateKstMa(_specialRightKostenstelleHS,
                                            _specialRightKostenstelleKGS,
                                            edtSucheKostenstelle,
                                            edtSucheMitarbeiter);

            // check DatumVon
            edtSucheZeitraumBis_EditValueChanged(this, System.EventArgs.Empty);

            // validate dates
            if (DBUtil.IsEmpty(edtSucheZeitraumVon.EditValue))
            {
                // DatumVon is required
                KissMsg.ShowInfo(this.Name, "RequiredSearchZeitraumVon_v01", "Das Feld 'Zeitraum von' wird für die Suche benötigt!");
                edtSucheZeitraumVon.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheZeitraumBis.EditValue))
            {
                // DatumBis is required
                KissMsg.ShowInfo(this.Name, "RequiredSearchZeitraumBis", "Das Feld 'Zeitraum bis' wird für die Suche benötigt!");
                edtSucheZeitraumBis.Focus();

                throw new KissCancelException();
            }

            // validate dates
            if (Convert.ToDateTime(edtSucheZeitraumVon.EditValue).Year < _validateYear ||
                Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year < _validateYear)
            {
                // year cannot be smaller than config value
                KissMsg.ShowInfo(this.Name,
                                 "RequiredSearchDatesInvalid_v01",
                                 "Das Jahr von 'Zeitraum von' oder 'Zeitraum bis' darf nicht kleiner als '{0}' sein!",
                                 _validateYear);

                edtSucheZeitraumBis.Focus();

                throw new KissCancelException();
            }

            if (Convert.ToDateTime(edtSucheZeitraumVon.EditValue).Year != Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year)
            {
                // years cannot be different
                KissMsg.ShowInfo(this.Name,
                                 "SearchYearsInvalid_v01",
                                 "Die Werte aus 'Zeitraum von' und 'Zeitraum bis' müssen innerhalb desselben Jahres liegen!");

                edtSucheZeitraumVon.Focus();

                throw new KissCancelException();
            }

            // logging
            _logger.Debug("call base.RunSearch()");

            // let base do stuff
            base.RunSearch();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private void SetupSqlQuery(SqlQuery qry, string resultTable)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("resultTable='{0}'", resultTable);

            qry.SelectStatement = @"
                -- declare vars
                DECLARE @OrgUnitID INT
                DECLARE @ZeitraumBis DATETIME
                DECLARE @UserID INT
                DECLARE @HauptbehinderungsartCode INT
                DECLARE @BSVBehinderungsartCode INT
                DECLARE @IVBerechtigungsCode INT
                DECLARE @GeburtVon DATETIME
                DECLARE @GeburtBis DATETIME
                DECLARE @NurSozialberatung BIT

                -- fill vars with search parameters (if value is given)
                --- SET @OrgUnitID                = {edtSucheKostenstelle}
                --- SET @ZeitraumBis              = {edtSucheZeitraumBis}
                --- SET @UserID                   = {edtSucheMitarbeiter}
                --- SET @HauptbehinderungsartCode = {edtSucheHauptbehinderungsart}
                --- SET @BSVBehinderungsartCode   = {edtSucheBSVBehinderungsart}
                --- SET @IVBerechtigungsCode      = {edtSucheIVBerechtigung}
                --- SET @GeburtVon                = {edtSucheGeburtVon}
                --- SET @GeburtBis                = {edtSucheGeburtBis}
                --- SET @NurSozialberatung        = {chkSucheNurSozialberatung}

                EXEC dbo.spQRYAktiveNeueDossiers " + Convert.ToString(Session.User.LanguageCode) + @",
                                                 @OrgUnitID,
                                                 @ZeitraumBis,
                                                 @UserID,
                                                 @HauptbehinderungsartCode,
                                                 @BSVBehinderungsartCode,
                                                 @IVBerechtigungsCode,
                                                 @GeburtVon,
                                                 @GeburtBis,
                                                 @NurSozialberatung,
                                                 '" + resultTable + @"',
                                                 " + Convert.ToString(Session.User.UserID) + @",
                                                 " + (_specialRightKostenstelleHS ? "1" : "0") + @",
                                                 " + (_specialRightKostenstelleKGS ? "1" : "0") + @",
                                                 0";

            // logging
            _logger.Debug("done");
        }

        #endregion

        #endregion
    }
}