using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sostat
{
    public class CtlBfsExport : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// The Log4Net logger.
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private KiSS4.Gui.KissButton btnStart;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlPlausiFehler;
        private DevExpress.XtraGrid.Columns.GridColumn colDossierID;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colLetztePlausibilisierung;
        private DevExpress.XtraGrid.Columns.GridColumn colStichtag;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissCalcEdit edtErhebungsjahrX;
        private KiSS4.Gui.KissTextEdit edtKlientX;
        private KiSS4.Gui.KissCheckedLookupEdit edtLeistungsartX;
        private System.Windows.Forms.CheckBox edtPlausi;
        private KiSS4.Gui.KissButtonEdit edtSARX;
        private KissLookUpEdit edtSektionX;
        private CheckBox edtVorbereiten;
        private KiSS4.Gui.KissGrid grdDossier;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDossier;
        private KiSS4.Gui.KissLabel lblCounter;
        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblLeistungsart;
        private KiSS4.Gui.KissLabel lblMitarbeiter;
        private KissLabel lblSektion;
        private System.Windows.Forms.Panel pnlBottom;
        private KiSS4.DB.SqlQuery qryDossier;
        private SqlQuery qrySektion;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsExport()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBfsExport));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdDossier = new KiSS4.Gui.KissGrid();
            this.qryDossier = new KiSS4.DB.SqlQuery();
            this.grvDossier = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDossierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichtag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetztePlausibilisierung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlPlausiFehler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.edtVorbereiten = new System.Windows.Forms.CheckBox();
            this.edtPlausi = new System.Windows.Forms.CheckBox();
            this.btnStart = new KiSS4.Gui.KissButton();
            this.lblCounter = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.edtErhebungsjahrX = new KiSS4.Gui.KissCalcEdit();
            this.edtSARX = new KiSS4.Gui.KissButtonEdit();
            this.edtKlientX = new KiSS4.Gui.KissTextEdit();
            this.edtLeistungsartX = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.lblMitarbeiter = new KiSS4.Gui.KissLabel();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtSektionX = new KiSS4.Gui.KissLookUpEdit();
            this.qrySektion = new KiSS4.DB.SqlQuery();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDossier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDossier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDossier)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
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
            this.tabControlSearch.Size = new System.Drawing.Size(800, 500);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdDossier);
            this.tpgListe.Controls.Add(this.pnlBottom);
            this.tpgListe.Size = new System.Drawing.Size(788, 462);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.edtSektionX);
            this.tpgSuchen.Controls.Add(this.lblLeistungsart);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.lblMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblJahr);
            this.tpgSuchen.Controls.Add(this.edtLeistungsartX);
            this.tpgSuchen.Controls.Add(this.edtKlientX);
            this.tpgSuchen.Controls.Add(this.edtSARX);
            this.tpgSuchen.Controls.Add(this.edtErhebungsjahrX);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 462);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtErhebungsjahrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSARX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKlientX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLeistungsartX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSektionX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            // 
            // grdDossier
            // 
            this.grdDossier.DataSource = this.qryDossier;
            this.grdDossier.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdDossier.EmbeddedNavigator.Name = "";
            this.grdDossier.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDossier.Location = new System.Drawing.Point(0, 0);
            this.grdDossier.MainView = this.grvDossier;
            this.grdDossier.Name = "grdDossier";
            this.grdDossier.Size = new System.Drawing.Size(788, 415);
            this.grdDossier.TabIndex = 0;
            this.grdDossier.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDossier});
            // 
            // qryDossier
            // 
            this.qryDossier.HostControl = this;
            this.qryDossier.SelectStatement = resources.GetString("qryDossier.SelectStatement");
            this.qryDossier.TableName = "BFSDossier";
            this.qryDossier.AfterFill += new System.EventHandler(this.qryDossier_AfterFill);
            // 
            // grvDossier
            // 
            this.grvDossier.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDossier.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.Empty.Options.UseBackColor = true;
            this.grvDossier.Appearance.Empty.Options.UseFont = true;
            this.grvDossier.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.EvenRow.Options.UseFont = true;
            this.grvDossier.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDossier.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDossier.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDossier.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDossier.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDossier.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDossier.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDossier.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDossier.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDossier.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDossier.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDossier.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDossier.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDossier.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDossier.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDossier.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDossier.Appearance.GroupRow.Options.UseFont = true;
            this.grvDossier.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDossier.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDossier.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDossier.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDossier.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDossier.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDossier.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDossier.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDossier.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDossier.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDossier.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDossier.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDossier.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDossier.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDossier.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.OddRow.Options.UseFont = true;
            this.grvDossier.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDossier.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.Row.Options.UseBackColor = true;
            this.grvDossier.Appearance.Row.Options.UseFont = true;
            this.grvDossier.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDossier.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDossier.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDossier.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDossier.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDossier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJahr,
            this.colDossierID,
            this.colKlient,
            this.colLeistungsart,
            this.colStichtag,
            this.colLetztePlausibilisierung,
            this.colAnzahlPlausiFehler});
            this.grvDossier.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDossier.GridControl = this.grdDossier;
            this.grvDossier.Name = "grvDossier";
            this.grvDossier.OptionsBehavior.Editable = false;
            this.grvDossier.OptionsCustomization.AllowFilter = false;
            this.grvDossier.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDossier.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDossier.OptionsNavigation.UseTabKey = false;
            this.grvDossier.OptionsView.ColumnAutoWidth = false;
            this.grvDossier.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDossier.OptionsView.ShowGroupPanel = false;
            this.grvDossier.OptionsView.ShowIndicator = false;
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 0;
            this.colJahr.Width = 51;
            // 
            // colDossierID
            // 
            this.colDossierID.Caption = "Dossier-Nr.";
            this.colDossierID.FieldName = "BFSDossierID";
            this.colDossierID.Name = "colDossierID";
            this.colDossierID.Visible = true;
            this.colDossierID.VisibleIndex = 1;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "PersonName";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 156;
            // 
            // colLeistungsart
            // 
            this.colLeistungsart.Caption = "Leistungsart";
            this.colLeistungsart.FieldName = "BFSLeistungsartCode";
            this.colLeistungsart.Name = "colLeistungsart";
            this.colLeistungsart.Visible = true;
            this.colLeistungsart.VisibleIndex = 3;
            this.colLeistungsart.Width = 166;
            // 
            // colStichtag
            // 
            this.colStichtag.Caption = "Stichtag";
            this.colStichtag.FieldName = "Stichtag";
            this.colStichtag.Name = "colStichtag";
            this.colStichtag.Visible = true;
            this.colStichtag.VisibleIndex = 4;
            this.colStichtag.Width = 58;
            // 
            // colLetztePlausibilisierung
            // 
            this.colLetztePlausibilisierung.Caption = "letzte Plaus.";
            this.colLetztePlausibilisierung.FieldName = "PlausibilisierungDatum";
            this.colLetztePlausibilisierung.Name = "colLetztePlausibilisierung";
            this.colLetztePlausibilisierung.Visible = true;
            this.colLetztePlausibilisierung.VisibleIndex = 5;
            this.colLetztePlausibilisierung.Width = 82;
            // 
            // colAnzahlPlausiFehler
            // 
            this.colAnzahlPlausiFehler.Caption = "Anz. Fehler";
            this.colAnzahlPlausiFehler.FieldName = "AnzahlFehler";
            this.colAnzahlPlausiFehler.Name = "colAnzahlPlausiFehler";
            this.colAnzahlPlausiFehler.Visible = true;
            this.colAnzahlPlausiFehler.VisibleIndex = 6;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.edtVorbereiten);
            this.pnlBottom.Controls.Add(this.edtPlausi);
            this.pnlBottom.Controls.Add(this.btnStart);
            this.pnlBottom.Controls.Add(this.lblCounter);
            this.pnlBottom.Controls.Add(this.ctlGotoFall);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 415);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(788, 47);
            this.pnlBottom.TabIndex = 1;
            // 
            // edtVorbereiten
            // 
            this.edtVorbereiten.Checked = true;
            this.edtVorbereiten.CheckState = System.Windows.Forms.CheckState.Checked;
            this.edtVorbereiten.Location = new System.Drawing.Point(420, 14);
            this.edtVorbereiten.Name = "edtVorbereiten";
            this.edtVorbereiten.Size = new System.Drawing.Size(113, 24);
            this.edtVorbereiten.TabIndex = 4;
            this.edtVorbereiten.Text = "Vorbereiten";
            this.edtVorbereiten.UseCompatibleTextRendering = true;
            // 
            // edtPlausi
            // 
            this.edtPlausi.Location = new System.Drawing.Point(539, 14);
            this.edtPlausi.Name = "edtPlausi";
            this.edtPlausi.Size = new System.Drawing.Size(135, 24);
            this.edtPlausi.TabIndex = 1;
            this.edtPlausi.Text = "Plausibilisierung";
            this.edtPlausi.UseCompatibleTextRendering = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(680, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 24);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "&Start";
            this.btnStart.UseCompatibleTextRendering = true;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.Location = new System.Drawing.Point(218, 14);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(196, 24);
            this.lblCounter.TabIndex = 1;
            this.lblCounter.Text = "Anzahl Einträge: <count>";
            this.lblCounter.UseCompatibleTextRendering = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.DataSource = this.qryDossier;
            this.ctlGotoFall.Location = new System.Drawing.Point(12, 14);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(200, 24);
            this.ctlGotoFall.TabIndex = 0;
            // 
            // edtErhebungsjahrX
            // 
            this.edtErhebungsjahrX.Location = new System.Drawing.Point(111, 52);
            this.edtErhebungsjahrX.Name = "edtErhebungsjahrX";
            this.edtErhebungsjahrX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErhebungsjahrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErhebungsjahrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErhebungsjahrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseFont = true;
            this.edtErhebungsjahrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErhebungsjahrX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErhebungsjahrX.Properties.Mask.EditMask = "####";
            this.edtErhebungsjahrX.Size = new System.Drawing.Size(100, 24);
            this.edtErhebungsjahrX.TabIndex = 0;
            // 
            // edtSARX
            // 
            this.edtSARX.Location = new System.Drawing.Point(111, 82);
            this.edtSARX.LookupSQL = resources.GetString("edtSARX.LookupSQL");
            this.edtSARX.Name = "edtSARX";
            this.edtSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSARX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSARX.Properties.Appearance.Options.UseFont = true;
            this.edtSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSARX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSARX.Size = new System.Drawing.Size(237, 24);
            this.edtSARX.TabIndex = 1;
            // 
            // edtKlientX
            // 
            this.edtKlientX.Location = new System.Drawing.Point(111, 113);
            this.edtKlientX.Name = "edtKlientX";
            this.edtKlientX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlientX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientX.Properties.Appearance.Options.UseFont = true;
            this.edtKlientX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientX.Size = new System.Drawing.Size(237, 24);
            this.edtKlientX.TabIndex = 3;
            // 
            // edtLeistungsartX
            // 
            this.edtLeistungsartX.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtLeistungsartX.Appearance.Options.UseBackColor = true;
            this.edtLeistungsartX.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtLeistungsartX.CheckOnClick = true;
            this.edtLeistungsartX.Location = new System.Drawing.Point(111, 175);
            this.edtLeistungsartX.LookupSQL = "SELECT Code, Text\r\nFROM BFSLOVCode\r\nWHERE LOVName = \'BFSLeistungsart\'";
            this.edtLeistungsartX.Name = "edtLeistungsartX";
            this.edtLeistungsartX.Size = new System.Drawing.Size(259, 267);
            this.edtLeistungsartX.TabIndex = 4;
            // 
            // lblJahr
            // 
            this.lblJahr.Location = new System.Drawing.Point(5, 52);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(100, 23);
            this.lblJahr.TabIndex = 11;
            this.lblJahr.Text = "Jahr";
            this.lblJahr.UseCompatibleTextRendering = true;
            // 
            // lblMitarbeiter
            // 
            this.lblMitarbeiter.Location = new System.Drawing.Point(5, 86);
            this.lblMitarbeiter.Name = "lblMitarbeiter";
            this.lblMitarbeiter.Size = new System.Drawing.Size(100, 23);
            this.lblMitarbeiter.TabIndex = 12;
            this.lblMitarbeiter.Text = "Mitarbeiter/-in";
            this.lblMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(5, 117);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(100, 23);
            this.lblKlient.TabIndex = 14;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Location = new System.Drawing.Point(5, 175);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(100, 23);
            this.lblLeistungsart.TabIndex = 15;
            this.lblLeistungsart.Text = "Leistungsart";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            // 
            // edtSektionX
            // 
            this.edtSektionX.Location = new System.Drawing.Point(111, 145);
            this.edtSektionX.Name = "edtSektionX";
            this.edtSektionX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSektionX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSektionX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektionX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSektionX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSektionX.Properties.Appearance.Options.UseFont = true;
            this.edtSektionX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSektionX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektionX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSektionX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSektionX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSektionX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSektionX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSektionX.Properties.NullText = "";
            this.edtSektionX.Properties.ShowFooter = false;
            this.edtSektionX.Properties.ShowHeader = false;
            this.edtSektionX.Size = new System.Drawing.Size(236, 24);
            this.edtSektionX.TabIndex = 145;
            // 
            // qrySektion
            // 
            this.qrySektion.SelectStatement = "SELECT \r\n   Text = ItemName,   \r\n   Code = OrgUnitID\r\nFROM XOrgUnit\r\nUNION\r\nSELEC" +
    "T\r\n   TEXT = \'\',\r\n   Code = null\r\nORDER BY Text";
            // 
            // lblSektion
            // 
            this.lblSektion.Location = new System.Drawing.Point(5, 145);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(69, 24);
            this.lblSektion.TabIndex = 146;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            // 
            // CtlBfsExport
            // 
            this.ActiveSQLQuery = this.qryDossier;
            this.Name = "CtlBfsExport";
            this.Load += new System.EventHandler(this.CtlBfsExport_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDossier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDossier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDossier)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
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

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // do nothing if no data is given
            if (this.qryDossier.Count == 0)
            {
                // logging
                logger.Debug("no data, cancel");

                // do not continue
                return;
            }

            // store current cursor
            Cursor oldCursor = Cursor.Current;

            Plausi plaus = null;

            try
            {
                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                // create new instance of class
                plaus = new Plausi(Convert.ToInt32(this.edtErhebungsjahrX.EditValue));

                Int32 i = 0;
                Int32[] bfsDossierIDArray = new Int32[this.qryDossier.Count];

                foreach (DataRow RowItem in this.qryDossier.DataTable.Rows)
                {
                    bfsDossierIDArray[i] = Convert.ToInt32(RowItem["BfsDossierID"]);
                    i++;
                }

                // logging
                logger.Debug(String.Format("items found: '{0}', start export now...", i));

                // export dossiers with given flags
                plaus.ExportDossier(bfsDossierIDArray, edtVorbereiten.Checked, edtPlausi.Checked);

                // logging
                logger.Debug("export done, do refresh");

                // refresh data
                qryDossier.Refresh();
            }
            catch (Exception ex)
            {
                // show error occured
                KissMsg.ShowError("CtlBfsExport", "ErrorOccuredOnStart", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                plaus.Dispose();

                // reset cursor
                Cursor.Current = oldCursor;

                // logging
                logger.Debug("done");
            }
        }

        private void CtlBfsExport_Load(object sender, System.EventArgs e)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"SELECT Code, Text FROM BFSLOVCode WHERE LOVName = 'BFSLeistungsart'");
            this.colLeistungsart.ColumnEdit = this.grdDossier.GetLOVLookUpEdit(qry, "Code", "Text");

            // ---
            qrySektion.Fill();
            edtSektionX.LoadQuery(qrySektion);
            edtSektionX.ItemIndex = 0;

            this.NewSearch();
        }
        private void qryDossier_AfterFill(object sender, System.EventArgs e)
        {
            // setup counter label
            lblCounter.Text = String.Format("Anzahl Einträge: {0}", qryDossier.Count);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // get config value and apply to year
            this.edtErhebungsjahrX.Text = DBUtil.GetConfigValue(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year).ToString();

            // set focus (year should not be changed by default)
            edtSARX.Focus();
        }

        #endregion

        #endregion
    }
}