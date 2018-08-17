using System;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Control, used as query for getting assigned deployments to clients/coworkers
    /// </summary>
    public class CtlQueryGeplanteEinsaetze : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private CtlEinsatz _ctlEinsatz = null; // the detailcontrol for EdEinsatz
        private string _mlRowCount; // store the multilanguage rowcount label text
        private BaUtils.ModulID _modulID; // store the modulid used for accessing this control
        private KissButton btnCollapse;
        private KissButton btnExpand;
        private DevExpress.XtraGrid.Columns.GridColumn colListeAnzahlEinsaetze;
        private DevExpress.XtraGrid.Columns.GridColumn colListeKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colListeMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colListeTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colListeZeitraum;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissButtonEdit edtSucheKlient;
        private KiSS4.Gui.KissButtonEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissRadioGroup edtSucheSucheNach;
        private KiSS4.Gui.KissLookUpEdit edtSucheTyp;
        private KiSS4.Gui.KissGrid grdSucheListe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSucheListe;
        private KiSS4.Gui.KissLabel lblRowCount;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheKlient;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheSucheNach;
        private KiSS4.Gui.KissLabel lblSucheTyp;
        private System.Windows.Forms.Panel panCtlEdEinsatz;
        private Panel panRight;
        private KiSS4.DB.SqlQuery qryEinsatz;
        private KiSS4.Gui.KissSplitterCollapsible splitter;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryGeplanteEinsaetze"/> class.
        /// </summary>
        public CtlQueryGeplanteEinsaetze(BaUtils.ModulID modulID)
        {
            // validate
            if (modulID != BaUtils.ModulID.BegleitetesWohnen && modulID != BaUtils.ModulID.EntlastungsDienst)
            {
                // logging
                _logger.Error("Accessing control with invalid modulID, cannot continue.");
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Accessing control with invalid modulID, cannot continue.");

                // cancel
                throw new ArgumentOutOfRangeException("modulID", "Accessing control with invalid modulID, cannot continue.");
            }

            // apply member
            _modulID = modulID;

            // logging
            _logger.DebugFormat("_modulID='{0}'", _modulID);

            // init control
            this.InitializeComponent();

            // init control depending on module
            SetModulDependingValues(false);

            // set ml-messages
            _mlRowCount = KissMsg.GetMLMessage(this.Name, "RowCountText", "Anzahl Datensätze");

            // create new CtlEdEinsatz and add it to the panel
            this._ctlEinsatz = new CtlEinsatz();
            this.panCtlEdEinsatz.Controls.Add(this._ctlEinsatz);
            this._ctlEinsatz.Dock = System.Windows.Forms.DockStyle.Fill;

            // init control with default settings to have proper display
            this._ctlEinsatz.Init(null,
                                  null,
                                  EinsatzHelper.AccessMode.Person,
                                  -1,
                                  false,
                                  _modulID,
                                  -1,
                                  -1,
                                  DateTime.MinValue,
                                  DateTime.MaxValue,
                                  -1);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryGeplanteEinsaetze));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdSucheListe = new KiSS4.Gui.KissGrid();
            this.qryEinsatz = new KiSS4.DB.SqlQuery(this.components);
            this.grvSucheListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colListeKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeAnzahlEinsaetze = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeZeitraum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheSucheNach = new KiSS4.Gui.KissLabel();
            this.edtSucheSucheNach = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblSucheKlient = new KiSS4.Gui.KissLabel();
            this.edtSucheKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheTyp = new KiSS4.Gui.KissLabel();
            this.edtSucheTyp = new KiSS4.Gui.KissLookUpEdit();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.panCtlEdEinsatz = new System.Windows.Forms.Panel();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            this.panRight = new System.Windows.Forms.Panel();
            this.btnCollapse = new KiSS4.Gui.KissButton();
            this.btnExpand = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSucheListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSucheListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSucheNach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSucheNach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            this.panRight.SuspendLayout();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(800, 259);
            this.tabControlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.tabControlSearch_Paint);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdSucheListe);
            this.tpgListe.Controls.Add(this.panRight);
            this.tpgListe.Size = new System.Drawing.Size(788, 221);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheTyp);
            this.tpgSuchen.Controls.Add(this.lblSucheTyp);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheKlient);
            this.tpgSuchen.Controls.Add(this.lblSucheKlient);
            this.tpgSuchen.Controls.Add(this.edtSucheSucheNach);
            this.tpgSuchen.Controls.Add(this.lblSucheSucheNach);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 221);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTyp, 0);
            //
            // grdSucheListe
            //
            this.grdSucheListe.DataSource = this.qryEinsatz;
            this.grdSucheListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSucheListe.EmbeddedNavigator.Name = "";
            this.grdSucheListe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdSucheListe.Location = new System.Drawing.Point(0, 0);
            this.grdSucheListe.MainView = this.grvSucheListe;
            this.grdSucheListe.Name = "grdSucheListe";
            this.grdSucheListe.Size = new System.Drawing.Size(758, 221);
            this.grdSucheListe.TabIndex = 0;
            this.grdSucheListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSucheListe});
            //
            // qryEinsatz
            //
            this.qryEinsatz.AutoApplyUserRights = false;
            this.qryEinsatz.FillTimeOut = 300;
            this.qryEinsatz.HostControl = this;
            this.qryEinsatz.SelectStatement = resources.GetString("qryEinsatz.SelectStatement");
            this.qryEinsatz.TableName = "EdEinsatz";
            this.qryEinsatz.PositionChanged += new System.EventHandler(this.qryEdEinsatz_PositionChanged);
            this.qryEinsatz.AfterFill += new System.EventHandler(this.qryEdEinsatz_AfterFill);
            //
            // grvSucheListe
            //
            this.grvSucheListe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSucheListe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.Empty.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.Empty.Options.UseFont = true;
            this.grvSucheListe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.EvenRow.Options.UseFont = true;
            this.grvSucheListe.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSucheListe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSucheListe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSucheListe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSucheListe.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSucheListe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSucheListe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSucheListe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSucheListe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSucheListe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSucheListe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSucheListe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSucheListe.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.GroupRow.Options.UseFont = true;
            this.grvSucheListe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSucheListe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSucheListe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSucheListe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSucheListe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSucheListe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSucheListe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSucheListe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSucheListe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSucheListe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSucheListe.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSucheListe.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.OddRow.Options.UseFont = true;
            this.grvSucheListe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSucheListe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.Row.Options.UseBackColor = true;
            this.grvSucheListe.Appearance.Row.Options.UseFont = true;
            this.grvSucheListe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSucheListe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSucheListe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSucheListe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSucheListe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSucheListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colListeKlient,
            this.colListeMitarbeiter,
            this.colListeTyp,
            this.colListeAnzahlEinsaetze,
            this.colListeZeitraum});
            this.grvSucheListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSucheListe.GridControl = this.grdSucheListe;
            this.grvSucheListe.Name = "grvSucheListe";
            this.grvSucheListe.OptionsBehavior.Editable = false;
            this.grvSucheListe.OptionsCustomization.AllowFilter = false;
            this.grvSucheListe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSucheListe.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSucheListe.OptionsNavigation.UseTabKey = false;
            this.grvSucheListe.OptionsView.ColumnAutoWidth = false;
            this.grvSucheListe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSucheListe.OptionsView.ShowGroupPanel = false;
            this.grvSucheListe.OptionsView.ShowIndicator = false;
            //
            // colListeKlient
            //
            this.colListeKlient.Caption = "Klient/in";
            this.colListeKlient.FieldName = "Klient";
            this.colListeKlient.Name = "colListeKlient";
            this.colListeKlient.Visible = true;
            this.colListeKlient.VisibleIndex = 0;
            this.colListeKlient.Width = 200;
            //
            // colListeMitarbeiter
            //
            this.colListeMitarbeiter.Caption = "Mitarbeiter/in";
            this.colListeMitarbeiter.FieldName = "Mitarbeiter";
            this.colListeMitarbeiter.Name = "colListeMitarbeiter";
            this.colListeMitarbeiter.Visible = true;
            this.colListeMitarbeiter.VisibleIndex = 1;
            this.colListeMitarbeiter.Width = 200;
            //
            // colListeTyp
            //
            this.colListeTyp.Caption = "Typ";
            this.colListeTyp.FieldName = "TypCode";
            this.colListeTyp.Name = "colListeTyp";
            this.colListeTyp.Visible = true;
            this.colListeTyp.VisibleIndex = 2;
            this.colListeTyp.Width = 160;
            //
            // colListeAnzahlEinsaetze
            //
            this.colListeAnzahlEinsaetze.Caption = "Anzahl Einsätze";
            this.colListeAnzahlEinsaetze.FieldName = "AnzahlEinsaetze";
            this.colListeAnzahlEinsaetze.Name = "colListeAnzahlEinsaetze";
            this.colListeAnzahlEinsaetze.Visible = true;
            this.colListeAnzahlEinsaetze.VisibleIndex = 3;
            this.colListeAnzahlEinsaetze.Width = 110;
            //
            // colListeZeitraum
            //
            this.colListeZeitraum.Caption = "Zeitraum";
            this.colListeZeitraum.FieldName = "Zeitraum";
            this.colListeZeitraum.Name = "colListeZeitraum";
            this.colListeZeitraum.Visible = true;
            this.colListeZeitraum.VisibleIndex = 4;
            this.colListeZeitraum.Width = 150;
            //
            // lblSucheSucheNach
            //
            this.lblSucheSucheNach.Location = new System.Drawing.Point(31, 40);
            this.lblSucheSucheNach.Name = "lblSucheSucheNach";
            this.lblSucheSucheNach.Size = new System.Drawing.Size(100, 24);
            this.lblSucheSucheNach.TabIndex = 1;
            this.lblSucheSucheNach.Text = "Suche nach";
            this.lblSucheSucheNach.UseCompatibleTextRendering = true;
            //
            // edtSucheSucheNach
            //
            this.edtSucheSucheNach.Location = new System.Drawing.Point(137, 40);
            this.edtSucheSucheNach.Name = "edtSucheSucheNach";
            this.edtSucheSucheNach.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSucheSucheNach.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSucheNach.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtSucheSucheNach.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtSucheSucheNach.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Klient/in"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Mitarbeiter/in")});
            this.edtSucheSucheNach.Size = new System.Drawing.Size(245, 26);
            this.edtSucheSucheNach.TabIndex = 2;
            this.edtSucheSucheNach.EditValueChanged += new System.EventHandler(this.edtSucheSucheNach_EditValueChanged);
            //
            // lblSucheKlient
            //
            this.lblSucheKlient.Location = new System.Drawing.Point(31, 72);
            this.lblSucheKlient.Name = "lblSucheKlient";
            this.lblSucheKlient.Size = new System.Drawing.Size(100, 23);
            this.lblSucheKlient.TabIndex = 3;
            this.lblSucheKlient.Text = "Klient/in";
            this.lblSucheKlient.UseCompatibleTextRendering = true;
            //
            // edtSucheKlient
            //
            this.edtSucheKlient.Location = new System.Drawing.Point(137, 72);
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKlient.Size = new System.Drawing.Size(245, 24);
            this.edtSucheKlient.TabIndex = 4;
            this.edtSucheKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheKlient_UserModifiedFld);
            //
            // lblSucheMitarbeiter
            //
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 102);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(100, 23);
            this.lblSucheMitarbeiter.TabIndex = 5;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            //
            // edtSucheMitarbeiter
            //
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(137, 102);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(245, 24);
            this.edtSucheMitarbeiter.TabIndex = 6;
            this.edtSucheMitarbeiter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMitarbeiter_UserModifiedFld);
            //
            // lblSucheDatumVon
            //
            this.lblSucheDatumVon.Location = new System.Drawing.Point(31, 132);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.lblSucheDatumVon.TabIndex = 7;
            this.lblSucheDatumVon.Text = "Datum";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumVon
            //
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(137, 132);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumVon.TabIndex = 8;
            //
            // lblSucheDatumBis
            //
            this.lblSucheDatumBis.Location = new System.Drawing.Point(243, 132);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(33, 24);
            this.lblSucheDatumBis.TabIndex = 9;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumBis
            //
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(282, 132);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 10;
            //
            // lblSucheTyp
            //
            this.lblSucheTyp.Location = new System.Drawing.Point(31, 162);
            this.lblSucheTyp.Name = "lblSucheTyp";
            this.lblSucheTyp.Size = new System.Drawing.Size(100, 23);
            this.lblSucheTyp.TabIndex = 11;
            this.lblSucheTyp.Text = "Typ";
            this.lblSucheTyp.UseCompatibleTextRendering = true;
            //
            // edtSucheTyp
            //
            this.edtSucheTyp.Location = new System.Drawing.Point(137, 162);
            this.edtSucheTyp.Name = "edtSucheTyp";
            this.edtSucheTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTyp.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTyp.Properties.NullText = "";
            this.edtSucheTyp.Properties.ShowFooter = false;
            this.edtSucheTyp.Properties.ShowHeader = false;
            this.edtSucheTyp.Size = new System.Drawing.Size(245, 24);
            this.edtSucheTyp.TabIndex = 12;
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panCtlEdEinsatz;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 259);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // panCtlEdEinsatz
            //
            this.panCtlEdEinsatz.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panCtlEdEinsatz.Location = new System.Drawing.Point(0, 267);
            this.panCtlEdEinsatz.Name = "panCtlEdEinsatz";
            this.panCtlEdEinsatz.Size = new System.Drawing.Size(800, 333);
            this.panCtlEdEinsatz.TabIndex = 3;
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRowCount.Location = new System.Drawing.Point(639, 234);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(152, 24);
            this.lblRowCount.TabIndex = 4;
            this.lblRowCount.Text = "Anzahl Datensätze: <xxxx>";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            //
            // panRight
            //
            this.panRight.Controls.Add(this.btnCollapse);
            this.panRight.Controls.Add(this.btnExpand);
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.Location = new System.Drawing.Point(758, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(30, 221);
            this.panRight.TabIndex = 1;
            //
            // btnCollapse
            //
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.IconID = 71;
            this.btnCollapse.Location = new System.Drawing.Point(3, 33);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnCollapse.TabIndex = 1;
            this.btnCollapse.UseCompatibleTextRendering = true;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            //
            // btnExpand
            //
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.IconID = 70;
            this.btnExpand.Location = new System.Drawing.Point(3, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 0;
            this.btnExpand.UseCompatibleTextRendering = true;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            //
            // CtlQueryGeplanteEinsaetze
            //
            this.ActiveSQLQuery = this.qryEinsatz;
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panCtlEdEinsatz);
            this.Name = "CtlQueryGeplanteEinsaetze";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.CtlQueryGeplanteEinsaetze_Load);
            this.Controls.SetChildIndex(this.panCtlEdEinsatz, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSucheListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSucheListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSucheNach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSucheNach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            this.panRight.ResumeLayout(false);
            this.ResumeLayout(false);
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

        #region EventHandlers

        private void btnCollapse_Click(object sender, System.EventArgs e)
        {
            // collapse view
            grdSucheListe.View.CollapseAllGroups();
        }

        private void btnExpand_Click(object sender, System.EventArgs e)
        {
            // show all data
            grdSucheListe.View.ExpandAllGroups();
        }

        private void CtlQueryGeplanteEinsaetze_Load(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // start with new search
            this.NewSearch();

            // logging
            _logger.Debug("done");
        }

        private void edtSucheKlient_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogKlient(sender, e, edtSucheKlient);
        }

        private void edtSucheMitarbeiter_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogMitarbeiter(sender, e, edtSucheMitarbeiter);
        }

        private void edtSucheSucheNach_EditValueChanged(object sender, System.EventArgs e)
        {
            // setup fields
            this.SetupSearchFields();
        }

        private void qryEdEinsatz_AfterFill(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // update detail control
            this.UpdateDetailControl();

            // show amount of entries
            this.UpdateRowCount(false);

            // do grouping
            this.SetupGridGrouping();

            // select last entry
            //not needed: grdSucheListe.View.MoveLastVisible();

            // logging
            _logger.Debug("done");
        }

        private void qryEdEinsatz_PositionChanged(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // update detail control
            this.UpdateDetailControl();

            // logging
            _logger.Debug("done");
        }

        private void tabControlSearch_Paint(object sender, PaintEventArgs e)
        {
            // move label to its proper position (due to splitter)
            if (lblRowCount.Top != (splitter.Top - lblRowCount.Height - 1))
            {
                lblRowCount.Top = (splitter.Top - lblRowCount.Height - 1);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Translate this control
        /// </summary>
        public override void Translate()
        {
            // apply translation
            base.Translate();

            // reset count label
            this.UpdateRowCount(true);

            // init control depending on module for translation
            SetModulDependingValues(true);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply default values
            edtSucheSucheNach.EditValue = 0; // Klient/in
            edtSucheDatumVon.EditValue = this.GetFirstDayOfNextMonth();
            edtSucheDatumBis.EditValue = this.GetLastDayOfNextMonth();

            // setup fields
            this.SetupSearchFields();

            // show amount of entries (reset)
            this.UpdateRowCount(true);

            // set focus
            edtSucheSucheNach.Focus();
        }

        protected override void RunSearch()
        {
            // validate mustfields
            if (DBUtil.IsEmpty(edtSucheSucheNach.EditValue))
            {
                // show info
                KissMsg.ShowInfo(this.Name, "NoSearchModeGiven", "Das Feld 'Suche nach' verlangt eine Eingabe.");

                // set focus
                edtSucheSucheNach.Focus();

                // cancel run
                throw new KissCancelException("Missing search value");
            }

            // replace search parameters
            object[] parameters = new object[] { BaUtils.ModulIDCode(_modulID), Session.User.LanguageCode, Session.User.UserID };
            this.kissSearch.SelectParameters = parameters;

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

                e.Cancel = !dlg.SearchData(string.Format(@"
                    SELECT PRS.*
                    FROM dbo.fnDlgPersonSuchenKGS({0}, 1, N'{1}') PRS
                    WHERE PRS.Name LIKE N'{1}%'", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // user
                    edt.EditValue = dlg["Name"];
                    edt.LookupID = dlg["BaPersonID$"];

                    // success
                    return true;
                }
                else
                {
                    // canceled or error
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorIKissUserModified_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private bool DialogMitarbeiter(object sender, UserModifiedFldEventArgs e, KissButtonEdit edt)
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
                if (edt != edtSucheMitarbeiter)
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
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
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

                e.Cancel = !dlg.SearchData(string.Format(@"
                    DECLARE @UserID INT
                    DECLARE @SearchString VARCHAR(1000)
                    DECLARE @ModulID INT

                    SET @UserID = {0}
                    SET @SearchString = {1}
                    SET @ModulID = {2}

                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS(@UserID) USR
                      INNER JOIN dbo.EdMitarbeiter          EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID$
                      INNER JOIN dbo.EdMitarbeiter_XModul   EXM WITH (READUNCOMMITTED) ON EXM.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                                                      AND EXM.XModulID = @ModulID
                                                                                      AND EXM.IstAktiv = 1
                    WHERE USR.Name LIKE (@SearchString + '%')", Session.User.UserID,
                                                                DBUtil.SqlLiteral(searchString),
                                                                BaUtils.ModulIDCode(_modulID)), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // user
                    edt.EditValue = dlg["Name"];
                    edt.LookupID = dlg["UserID$"];

                    // success
                    return true;
                }
                else
                {
                    // canceled or error
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorIKissUserModified_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private DateTime GetFirstDayOfNextMonth()
        {
            // get current date
            DateTime currentDate = DateTime.Now.Date;

            // add one month to current date
            currentDate = currentDate.AddMonths(1);

            // remove all of the days in the month
            // except the first day and set the
            // variable to hold that date
            currentDate = currentDate.AddDays(-(currentDate.Day - 1));

            // return the first day of the month
            return currentDate;
        }

        private DateTime GetLastDayOfNextMonth()
        {
            // get current date
            DateTime currentDate = DateTime.Now.Date;

            // add to month and then subtract days until last of next month
            currentDate = currentDate.AddMonths(2);
            currentDate = currentDate.AddDays(-(currentDate.Day - 1) - 1);

            // return the first day of the month
            return currentDate;
        }

        private void SetModulDependingValues(bool labelsOnly)
        {
            // setup control depending on current module
            switch (_modulID)
            {
                case BaUtils.ModulID.BegleitetesWohnen:
                    lblSucheTyp.Text = KissMsg.GetMLMessage(this.Name, "TypBWCaption", "Typ BW");
                    colListeTyp.Caption = lblSucheTyp.Text;

                    if (!labelsOnly)
                    {
                        edtSucheTyp.LOVName = "BWTyp";
                    }
                    break;

                case BaUtils.ModulID.EntlastungsDienst:
                    lblSucheTyp.Text = KissMsg.GetMLMessage(this.Name, "TypEDCaption", "Typ ED");
                    colListeTyp.Caption = lblSucheTyp.Text;

                    if (!labelsOnly)
                    {
                        edtSucheTyp.LOVName = "EDTyp";
                    }
                    break;

                default:
                    throw new InvalidOperationException("The given modulID is not supported and therefore cannot be used.");
            }
        }

        private void SetupGridGrouping()
        {
            // validate
            if (grdSucheListe.View == null)
            {
                return;
            }

            // clear grouping
            grdSucheListe.View.ClearGrouping();

            // show group panel on view
            grdSucheListe.View.OptionsView.ShowGroupPanel = true;

            // do grouping depending on searchmode
            if (Convert.ToInt32(edtSucheSucheNach.EditValue) == 0)
            {
                // searched for client, group by client
                colListeKlient.GroupIndex = 0;
            }
            else
            {
                // searched for user, group by user
                colListeMitarbeiter.GroupIndex = 0;
            }

            // collapse all by default
            grdSucheListe.View.CollapseAllGroups();
        }

        private void SetupSearchFields()
        {
            // get flag for searchmode (0=client, 1=user)
            bool isSearchClient = (Convert.ToInt32(edtSucheSucheNach.EditValue) == 0);

            // setup controls depending on searchmode
            edtSucheKlient.EditMode = isSearchClient ? EditModeType.Normal : EditModeType.ReadOnly;
            edtSucheMitarbeiter.EditMode = isSearchClient ? EditModeType.ReadOnly : EditModeType.Normal;

            // clear fields
            edtSucheKlient.EditValue = null;
            edtSucheKlient.LookupID = null;
            edtSucheMitarbeiter.EditValue = null;
            edtSucheMitarbeiter.LookupID = null;
        }

        private void UpdateDetailControl()
        {
            // logging
            _logger.Debug("enter");

            // setup ids
            int baPersonID = qryEinsatz.Count > 0 && !DBUtil.IsEmpty(qryEinsatz["BaPersonID$"]) ? Convert.ToInt32(qryEinsatz["BaPersonID$"]) : -1;
            int userID = qryEinsatz.Count > 0 && !DBUtil.IsEmpty(qryEinsatz["UserID$"]) ? Convert.ToInt32(qryEinsatz["UserID$"]) : -1;
            DateTime datumVon = qryEinsatz.Count > 0 && !DBUtil.IsEmpty(edtSucheDatumVon.EditValue) ? Convert.ToDateTime(edtSucheDatumVon.EditValue).Date : DateTime.MinValue;
            DateTime datumBis = qryEinsatz.Count > 0 && !DBUtil.IsEmpty(edtSucheDatumBis.EditValue) ? Convert.ToDateTime(edtSucheDatumBis.EditValue).Date : DateTime.MaxValue;
            int einsatzTyp = qryEinsatz.Count > 0 && !DBUtil.IsEmpty(edtSucheTyp.EditValue) ? Convert.ToInt32(edtSucheTyp.EditValue) : -1;

            // logging
            _logger.DebugFormat("SearchMode={0}, baPersonID={1}, userID={2}, datumVon={3}, datumBis={4}, einsatzTyp={5}", edtSucheSucheNach.EditValue, baPersonID, userID, datumVon, datumBis, einsatzTyp);

            // INFO ONLY:
            /* ctlEdEinsatz.Init(string titleName, Image titleImage, AccessMode accessMode, int faLeistungID, bool isLeistungClosed,
                                 int baPersonID, int userID, DateTime datumVon, DateTime datumBis, int einsatzTyp)
            */

            // depending on search-criteria, we call other init-method from detail control
            if (Convert.ToInt32(edtSucheSucheNach.EditValue) == 0)
            {
                // logging
                _logger.Debug("client search");

                // client search
                this._ctlEinsatz.Init(null,
                                      null,
                                      EinsatzHelper.AccessMode.Person,
                                      -1,
                                      true,
                                      _modulID,
                                      baPersonID,
                                      -1,
                                      datumVon,
                                      datumBis,
                                      einsatzTyp);
            }
            else
            {
                // logging
                _logger.Debug("user search");

                // user search
                this._ctlEinsatz.Init(null,
                                      null,
                                      EinsatzHelper.AccessMode.User,
                                      -1,
                                      true,
                                      _modulID,
                                      -1,
                                      userID,
                                      datumVon,
                                      datumBis,
                                      einsatzTyp);
            }

            // logging
            _logger.Debug("done");
        }

        private void UpdateRowCount(bool resetCounter)
        {
            // show amount of entries
            lblRowCount.Text = string.Format("{0}:  {1}", this._mlRowCount, resetCounter ? 0 : qryEinsatz.Count);
        }

        #endregion

        #endregion
    }
}