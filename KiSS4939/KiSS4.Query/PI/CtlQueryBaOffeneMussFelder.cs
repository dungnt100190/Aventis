using System;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    public class CtlQueryBaOffeneMussFelder : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private Boolean _isChiefOrRepresentative = false; // store if sesssion user is chief or representative of current users' oe
        private Boolean _specialRightKostenstelleHS = false; // store if user has special rights to show all orgunits (Hauptsitz)
        private Boolean _specialRightKostenstelleKGS = false; // store if user has special rights to show all orgunits within its KGS
        private Int32 _userOrgUnitID = -1; // store the user's orgunitid
        private Int32 _validateYear = -1; // store config value for validation year
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colHauptbehinderungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colIVBerechtigung;
        private DevExpress.XtraGrid.Columns.GridColumn colLand;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrganisationseinheit;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlicherFV;
        private DevExpress.XtraGrid.Columns.GridColumn colVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colmw;
        private KiSS4.Gui.KissCalcEdit edtSucheJahr;
        private KissLookUpEdit edtSucheKostenstelle;
        private KissLookUpEdit edtSucheMitarbeiter;
        private KissLabel lblNameVornameID;
        private KiSS4.Gui.KissLabel lblSucheJahr;
        private KissLabel lblSucheKostenstelle;
        private KissLabel lblSucheMitarbeiter;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryBaOffeneMussFelder()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaOffeneMussFelder));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheJahr = new KiSS4.Gui.KissLabel();
            this.edtSucheJahr = new KiSS4.Gui.KissCalcEdit();
            this.colAHVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHauptbehinderungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVBerechtigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrganisationseinheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlicherFV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.lblNameVornameID = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVornameID)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            //
            // xDocument
            //
            this.xDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(633, 398);
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
            this.ctlGotoFall.Size = new System.Drawing.Size(171, 24);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.lblNameVornameID);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.lblNameVornameID, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.edtSucheJahr);
            this.tpgSuchen.Controls.Add(this.lblSucheJahr);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            //
            // lblSucheJahr
            //
            this.lblSucheJahr.Location = new System.Drawing.Point(31, 70);
            this.lblSucheJahr.Name = "lblSucheJahr";
            this.lblSucheJahr.Size = new System.Drawing.Size(133, 24);
            this.lblSucheJahr.TabIndex = 3;
            this.lblSucheJahr.Text = "Jahr";
            this.lblSucheJahr.UseCompatibleTextRendering = true;
            //
            // edtSucheJahr
            //
            this.edtSucheJahr.Location = new System.Drawing.Point(170, 70);
            this.edtSucheJahr.Name = "edtSucheJahr";
            this.edtSucheJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheJahr.Properties.DisplayFormat.FormatString = "0000";
            this.edtSucheJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheJahr.Properties.EditFormat.FormatString = "0000";
            this.edtSucheJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheJahr.Properties.Mask.EditMask = "0000";
            this.edtSucheJahr.Properties.MaxLength = 4;
            this.edtSucheJahr.Size = new System.Drawing.Size(60, 24);
            this.edtSucheJahr.TabIndex = 4;
            //
            // colAHVNr
            //
            this.colAHVNr.Name = "colAHVNr";
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
            // colLand
            //
            this.colLand.Name = "colLand";
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
            // colVerantwortlicherFV
            //
            this.colVerantwortlicherFV.Name = "colVerantwortlicherFV";
            //
            // colVersNr
            //
            this.colVersNr.Name = "colVersNr";
            //
            // colVorname
            //
            this.colVorname.Name = "colVorname";
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(244, 24);
            this.edtSucheMitarbeiter.TabIndex = 6;
            //
            // lblSucheMitarbeiter
            //
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 100);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(133, 24);
            this.lblSucheMitarbeiter.TabIndex = 5;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
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
            // lblSucheKostenstelle
            //
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKostenstelle.TabIndex = 1;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            //
            // lblNameVornameID
            //
            this.lblNameVornameID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameVornameID.DataMember = "NameVornameID$";
            this.lblNameVornameID.DataSource = this.qryQuery;
            this.lblNameVornameID.Location = new System.Drawing.Point(180, 398);
            this.lblNameVornameID.Name = "lblNameVornameID";
            this.lblNameVornameID.Size = new System.Drawing.Size(447, 24);
            this.lblNameVornameID.TabIndex = 3;
            //
            // CtlQueryBaOffeneMussFelder
            //
            this.Name = "CtlQueryBaOffeneMussFelder";
            this.Load += new System.EventHandler(this.CtlQueryBaOffeneMussFelder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVornameID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryBaOffeneMussFelder_Load(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // SETTINGS
            this._validateYear = DBUtil.GetConfigInt(@"System\ZLE\StartJahr", -1);

            // validate
            if (this._validateYear < 2000)
            {
                // invalid value, do not continue
                throw new ArgumentOutOfRangeException("Invalid configuration value for year-validation, cannot continue.");
            }

            // DEFAULT VALUES:
            // get users member orgunit
            this._userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            // RIGHTS:
            // get if user has special right to select specified Kostenstelle/MA
            this._specialRightKostenstelleHS = DBUtil.UserHasRight("QRYOffeneMussfelderKostenstelleHS");
            this._specialRightKostenstelleKGS = DBUtil.UserHasRight("QRYOffeneMussfelderKostenstelleKGS");

            // get if user is zle chief or representative of ANY orgunit
            this._isChiefOrRepresentative = QryUtils.IsChiefOrRepresentative(Session.User.UserID, -1);

            // logging
            logger.Debug(String.Format("SpecialRightKostenstelleHS={0}, SpecialRightKostenstelleKGS={1}, IsChiefOrRepresentative={2}", this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative));

            // SEARCH:
            // fill dropdowns data, depending on rights
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID, this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, edtSucheKostenstelle);
            BDEUtils.InitMitarbeiterDropDown(Session.User.UserID, this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative, edtSucheMitarbeiter);

            // FILLTIMEOUT:
            // setup FillTimeOut for qryQuery
            if (this._specialRightKostenstelleHS)
            {
                // hauptsitz, huge amount of data expected
                qryQuery.FillTimeOut = 1200; // 20min
            }
            else if (this._specialRightKostenstelleKGS)
            {
                // KGS, lower amount of data, still big amount
                qryQuery.FillTimeOut = 600; // 10min
            }
            else if (this._isChiefOrRepresentative)
            {
                // Chief only, lower amount
                qryQuery.FillTimeOut = 360;
            }

            // QUERIES:
            this.SetupSqlQuery(qryQuery);

            // INIT
            // start with new search
            this.NewSearch();

            // logging
            logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply rights and default search parameters
            QryUtils.NewSearchMitarbeiter(this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative, edtSucheMitarbeiter);

            // default Kostenstelle (for all users the same way)
            edtSucheKostenstelle.EditValue = this._userOrgUnitID;

            // default year = current
            edtSucheJahr.EditValue = System.DateTime.Now.Year;

            // set focus
            edtSucheKostenstelle.Focus();
        }

        protected override void RunSearch()
        {
            // validate Kostenstelle and Mitarbeiter
            QryUtils.RunSearchValidateKstMa(this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, edtSucheKostenstelle, edtSucheMitarbeiter);

            // validate year
            if (DBUtil.IsEmpty(edtSucheJahr.EditValue))
            {
                // Jahr is required
                KissMsg.ShowInfo("CtlQueryBaOffeneMussFelder", "RequiredSearchYear", "Das Feld 'Jahr' wird für die Suche benötigt!");
                edtSucheJahr.Focus();

                throw new KissCancelException();
            }

            if (Convert.ToInt32(edtSucheJahr.EditValue) < this._validateYear)
            {
                // year cannot be smaller than config value
                KissMsg.ShowInfo("CtlQueryBaOffeneMussFelder", "RequiredSearchYearInvalid", "Das Feld 'Jahr' darf nicht kleiner als '{0}' sein!", 0, 0, this._validateYear);
                edtSucheJahr.Focus();

                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void SetupSqlQuery(SqlQuery qry)
        {
            qry.SelectStatement = @"
                    -- declare vars
                    DECLARE @OrgUnitID INT
                    DECLARE @Jahr INT
                    DECLARE @UserID INT

                    -- fill vars with search parameters (if value is given)
                    --- SET @OrgUnitID             = {edtSucheKostenstelle}
                    --- SET @Jahr                  = {edtSucheJahr}
                    --- SET @UserID                = {edtSucheMitarbeiter}

                    -- run statement
                    EXEC dbo.spQRYOffeneMussfelder " + Convert.ToString(Session.User.LanguageCode) + @",
                                                   @OrgUnitID,
                                                   @Jahr,
                                                   @UserID,
                                                   " + Convert.ToString(Session.User.UserID) + @",
                                                   " + (this._specialRightKostenstelleHS ? "1" : "0") + @",
                                                   " + (this._specialRightKostenstelleKGS ? "1" : "0");
        }

        #endregion

        #endregion
    }
}