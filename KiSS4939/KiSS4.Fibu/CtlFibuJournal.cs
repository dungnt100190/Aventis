using System;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuJournal.
    /// </summary>
    public class CtlFibuJournal : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit editDatumBisX;
        private KiSS4.Gui.KissDateEdit editDatumVonX;
        private KiSS4.Gui.KissTextEdit editMandantNrX;
        private KiSS4.Gui.KissButtonEdit editMandantX;
        private KiSS4.Gui.KissTextEdit editMTX;
        private KiSS4.Gui.KissTextEdit editPlzOrtX;
        private KiSS4.Gui.KissLookUpEdit editTeamX;
        private KiSS4.Gui.KissGrid grdJournal;
        private KiSS4.Gui.KissGrid grdPeriodenX;
        private DevExpress.XtraGrid.Views.Grid.GridView grvJournal;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPeriodenX;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissLabel lblSearchDatumBis;
        private KiSS4.Gui.KissLabel lblSearchDatumVon;
        private KiSS4.Gui.KissLabel lblSearchMandant;
        private KiSS4.Gui.KissLabel lblSearchMandatstraeger;
        private KiSS4.Gui.KissLabel lblSearchOrt;
        private KiSS4.Gui.KissLabel lblSearchTeam;
        private KiSS4.Gui.KissLabel lblSearchTeamMandantEmpty;
        private KiSS4.DB.SqlQuery qryJournal;
        private KiSS4.DB.SqlQuery qryPeriodeX;
        private SharpLibrary.WinControls.TabPageEx tabListe;
        private KiSS4.Gui.KissTabControlEx tabSucheListe;
        private SharpLibrary.WinControls.TabPageEx tabSuchen;
        private KiSS4.Gui.KissSearchTitel ttlSearchTitle;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFibuJournal"/> class.
        /// </summary>
        public CtlFibuJournal()
        {
            // --- Required for Windows Form Designer support
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuJournal));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryJournal = new KiSS4.DB.SqlQuery(this.components);
            this.tabSucheListe = new KiSS4.Gui.KissTabControlEx();
            this.tabListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdJournal = new KiSS4.Gui.KissGrid();
            this.grvJournal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKtoSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.tabSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.lblSearchTeamMandantEmpty = new KiSS4.Gui.KissLabel();
            this.editTeamX = new KiSS4.Gui.KissLookUpEdit();
            this.lblSearchTeam = new KiSS4.Gui.KissLabel();
            this.ttlSearchTitle = new KiSS4.Gui.KissSearchTitel();
            this.lblSearchOrt = new KiSS4.Gui.KissLabel();
            this.lblSearchMandatstraeger = new KiSS4.Gui.KissLabel();
            this.editMTX = new KiSS4.Gui.KissTextEdit();
            this.editMandantX = new KiSS4.Gui.KissButtonEdit();
            this.editMandantNrX = new KiSS4.Gui.KissTextEdit();
            this.editPlzOrtX = new KiSS4.Gui.KissTextEdit();
            this.lblSearchMandant = new KiSS4.Gui.KissLabel();
            this.grdPeriodenX = new KiSS4.Gui.KissGrid();
            this.qryPeriodeX = new KiSS4.DB.SqlQuery(this.components);
            this.grvPeriodenX = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSearchDatumBis = new KiSS4.Gui.KissLabel();
            this.editDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.editDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblSearchDatumVon = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryJournal)).BeginInit();
            this.tabSucheListe.SuspendLayout();
            this.tabListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJournal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvJournal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            this.tabSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchTeamMandantEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeamX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeamX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchMandatstraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMTX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriodenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriodenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumVon)).BeginInit();
            this.SuspendLayout();
            // 
            // qryJournal
            // 
            this.qryJournal.HostControl = this;
            this.qryJournal.IsIdentityInsert = false;
            // 
            // tabSucheListe
            // 
            this.tabSucheListe.Controls.Add(this.tabListe);
            this.tabSucheListe.Controls.Add(this.tabSuchen);
            this.tabSucheListe.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabSucheListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSucheListe.Location = new System.Drawing.Point(0, 0);
            this.tabSucheListe.Name = "tabSucheListe";
            this.tabSucheListe.SelectedTabIndex = 1;
            this.tabSucheListe.ShowFixedWidthTooltip = true;
            this.tabSucheListe.Size = new System.Drawing.Size(840, 535);
            this.tabSucheListe.TabIndex = 286;
            this.tabSucheListe.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabListe,
            this.tabSuchen});
            this.tabSucheListe.TabsLineColor = System.Drawing.Color.Black;
            this.tabSucheListe.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabSucheListe.TabStop = false;
            this.tabSucheListe.Text = "KissTabControlEx1";
            // 
            // tabListe
            // 
            this.tabListe.Controls.Add(this.grdJournal);
            this.tabListe.Controls.Add(this.lblMandant);
            this.tabListe.Location = new System.Drawing.Point(6, 6);
            this.tabListe.Name = "tabListe";
            this.tabListe.Size = new System.Drawing.Size(828, 497);
            this.tabListe.TabIndex = 0;
            this.tabListe.Title = "Liste";
            // 
            // grdJournal
            // 
            this.grdJournal.DataSource = this.qryJournal;
            this.grdJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdJournal.EmbeddedNavigator.Name = "";
            this.grdJournal.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdJournal.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdJournal.Location = new System.Drawing.Point(0, 25);
            this.grdJournal.MainView = this.grvJournal;
            this.grdJournal.Name = "grdJournal";
            this.grdJournal.Size = new System.Drawing.Size(828, 472);
            this.grdJournal.TabIndex = 3;
            this.grdJournal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvJournal});
            // 
            // grvJournal
            // 
            this.grvJournal.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvJournal.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.Empty.Options.UseBackColor = true;
            this.grvJournal.Appearance.Empty.Options.UseFont = true;
            this.grvJournal.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvJournal.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvJournal.Appearance.EvenRow.Options.UseFont = true;
            this.grvJournal.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvJournal.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvJournal.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvJournal.Appearance.FocusedCell.Options.UseFont = true;
            this.grvJournal.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvJournal.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvJournal.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvJournal.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvJournal.Appearance.FocusedRow.Options.UseFont = true;
            this.grvJournal.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvJournal.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvJournal.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvJournal.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvJournal.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvJournal.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvJournal.Appearance.GroupFooter.Options.UseFont = true;
            this.grvJournal.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvJournal.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvJournal.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvJournal.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvJournal.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvJournal.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvJournal.Appearance.GroupRow.Options.UseFont = true;
            this.grvJournal.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvJournal.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvJournal.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvJournal.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvJournal.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvJournal.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvJournal.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvJournal.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvJournal.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvJournal.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvJournal.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvJournal.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvJournal.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvJournal.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvJournal.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvJournal.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.OddRow.Options.UseBackColor = true;
            this.grvJournal.Appearance.OddRow.Options.UseFont = true;
            this.grvJournal.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvJournal.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.Row.Options.UseBackColor = true;
            this.grvJournal.Appearance.Row.Options.UseFont = true;
            this.grvJournal.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvJournal.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvJournal.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvJournal.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvJournal.Appearance.SelectedRow.Options.UseFont = true;
            this.grvJournal.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvJournal.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvJournal.Appearance.VertLine.Options.UseBackColor = true;
            this.grvJournal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvJournal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colBelegNr,
            this.colText,
            this.colKtoSoll,
            this.colHaben,
            this.colBetrag,
            this.colMandant});
            this.grvJournal.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvJournal.GridControl = this.grdJournal;
            this.grvJournal.GroupFormat = "{1}";
            this.grvJournal.GroupRowHeight = 25;
            this.grvJournal.Name = "grvJournal";
            this.grvJournal.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvJournal.OptionsBehavior.Editable = false;
            this.grvJournal.OptionsCustomization.AllowFilter = false;
            this.grvJournal.OptionsCustomization.AllowGroup = false;
            this.grvJournal.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvJournal.OptionsNavigation.AutoFocusNewRow = true;
            this.grvJournal.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvJournal.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvJournal.OptionsNavigation.UseTabKey = false;
            this.grvJournal.OptionsPrint.AutoWidth = false;
            this.grvJournal.OptionsPrint.UsePrintStyles = true;
            this.grvJournal.OptionsView.ColumnAutoWidth = false;
            this.grvJournal.OptionsView.ShowDetailButtons = false;
            this.grvJournal.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvJournal.OptionsView.ShowGroupPanel = false;
            this.grvJournal.OptionsView.ShowIndicator = false;
            this.grvJournal.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMandant, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.DisplayFormat.FormatString = "d";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "BuchungsDatum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 106;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg";
            this.colBelegNr.DisplayFormat.FormatString = "BelegNr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            this.colBelegNr.Width = 69;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 4;
            this.colText.Width = 314;
            // 
            // colKtoSoll
            // 
            this.colKtoSoll.Caption = "Soll";
            this.colKtoSoll.FieldName = "SollKtoNr";
            this.colKtoSoll.Name = "colKtoSoll";
            this.colKtoSoll.Visible = true;
            this.colKtoSoll.VisibleIndex = 2;
            this.colKtoSoll.Width = 80;
            // 
            // colHaben
            // 
            this.colHaben.Caption = "Haben";
            this.colHaben.FieldName = "HabenKtoNr";
            this.colHaben.Name = "colHaben";
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 3;
            this.colHaben.Width = 80;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            this.colBetrag.Width = 120;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Mandant";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            // 
            // lblMandant
            // 
            this.lblMandant.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMandant.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblMandant.Location = new System.Drawing.Point(0, 0);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblMandant.Size = new System.Drawing.Size(828, 25);
            this.lblMandant.TabIndex = 3;
            this.lblMandant.Text = "Mandant";
            this.lblMandant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabSuchen
            // 
            this.tabSuchen.Controls.Add(this.lblSearchTeamMandantEmpty);
            this.tabSuchen.Controls.Add(this.editTeamX);
            this.tabSuchen.Controls.Add(this.lblSearchTeam);
            this.tabSuchen.Controls.Add(this.ttlSearchTitle);
            this.tabSuchen.Controls.Add(this.lblSearchOrt);
            this.tabSuchen.Controls.Add(this.lblSearchMandatstraeger);
            this.tabSuchen.Controls.Add(this.editMTX);
            this.tabSuchen.Controls.Add(this.editMandantX);
            this.tabSuchen.Controls.Add(this.editMandantNrX);
            this.tabSuchen.Controls.Add(this.editPlzOrtX);
            this.tabSuchen.Controls.Add(this.lblSearchMandant);
            this.tabSuchen.Controls.Add(this.grdPeriodenX);
            this.tabSuchen.Controls.Add(this.lblSearchDatumBis);
            this.tabSuchen.Controls.Add(this.editDatumVonX);
            this.tabSuchen.Controls.Add(this.editDatumBisX);
            this.tabSuchen.Controls.Add(this.lblSearchDatumVon);
            this.tabSuchen.Location = new System.Drawing.Point(6, 6);
            this.tabSuchen.Name = "tabSuchen";
            this.tabSuchen.Size = new System.Drawing.Size(828, 497);
            this.tabSuchen.TabIndex = 1;
            this.tabSuchen.Title = "Suchen";
            this.tabSuchen.Visible = false;
            // 
            // lblSearchTeamMandantEmpty
            // 
            this.lblSearchTeamMandantEmpty.ForeColor = System.Drawing.Color.Black;
            this.lblSearchTeamMandantEmpty.Location = new System.Drawing.Point(109, 200);
            this.lblSearchTeamMandantEmpty.Name = "lblSearchTeamMandantEmpty";
            this.lblSearchTeamMandantEmpty.Size = new System.Drawing.Size(250, 24);
            this.lblSearchTeamMandantEmpty.TabIndex = 14;
            this.lblSearchTeamMandantEmpty.Text = "(falls Mandant leer bleibt)";
            // 
            // editTeamX
            // 
            this.editTeamX.Location = new System.Drawing.Point(109, 173);
            this.editTeamX.Name = "editTeamX";
            this.editTeamX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTeamX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTeamX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTeamX.Properties.Appearance.Options.UseBackColor = true;
            this.editTeamX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTeamX.Properties.Appearance.Options.UseFont = true;
            this.editTeamX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editTeamX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editTeamX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editTeamX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editTeamX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editTeamX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editTeamX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTeamX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.editTeamX.Properties.DisplayMember = "Text";
            this.editTeamX.Properties.NullText = "";
            this.editTeamX.Properties.ShowFooter = false;
            this.editTeamX.Properties.ShowHeader = false;
            this.editTeamX.Properties.ValueMember = "Code";
            this.editTeamX.Size = new System.Drawing.Size(250, 24);
            this.editTeamX.TabIndex = 13;
            // 
            // lblSearchTeam
            // 
            this.lblSearchTeam.ForeColor = System.Drawing.Color.Black;
            this.lblSearchTeam.Location = new System.Drawing.Point(30, 173);
            this.lblSearchTeam.Name = "lblSearchTeam";
            this.lblSearchTeam.Size = new System.Drawing.Size(73, 24);
            this.lblSearchTeam.TabIndex = 12;
            this.lblSearchTeam.Text = "Team";
            // 
            // ttlSearchTitle
            // 
            this.ttlSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ttlSearchTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ttlSearchTitle.Location = new System.Drawing.Point(9, 6);
            this.ttlSearchTitle.Name = "ttlSearchTitle";
            this.ttlSearchTitle.Size = new System.Drawing.Size(803, 24);
            this.ttlSearchTitle.TabIndex = 0;
            // 
            // lblSearchOrt
            // 
            this.lblSearchOrt.ForeColor = System.Drawing.Color.Black;
            this.lblSearchOrt.Location = new System.Drawing.Point(30, 79);
            this.lblSearchOrt.Name = "lblSearchOrt";
            this.lblSearchOrt.Size = new System.Drawing.Size(73, 24);
            this.lblSearchOrt.TabIndex = 4;
            this.lblSearchOrt.Text = "Ort";
            // 
            // lblSearchMandatstraeger
            // 
            this.lblSearchMandatstraeger.ForeColor = System.Drawing.Color.Black;
            this.lblSearchMandatstraeger.Location = new System.Drawing.Point(30, 102);
            this.lblSearchMandatstraeger.Name = "lblSearchMandatstraeger";
            this.lblSearchMandatstraeger.Size = new System.Drawing.Size(73, 24);
            this.lblSearchMandatstraeger.TabIndex = 6;
            this.lblSearchMandatstraeger.Text = "M.Träger";
            // 
            // editMTX
            // 
            this.editMTX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMTX.Location = new System.Drawing.Point(109, 102);
            this.editMTX.Name = "editMTX";
            this.editMTX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editMTX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMTX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMTX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMTX.Properties.Appearance.Options.UseBackColor = true;
            this.editMTX.Properties.Appearance.Options.UseBorderColor = true;
            this.editMTX.Properties.Appearance.Options.UseFont = true;
            this.editMTX.Properties.Appearance.Options.UseForeColor = true;
            this.editMTX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editMTX.Properties.ReadOnly = true;
            this.editMTX.Size = new System.Drawing.Size(281, 24);
            this.editMTX.TabIndex = 7;
            this.editMTX.TabStop = false;
            // 
            // editMandantX
            // 
            this.editMandantX.Location = new System.Drawing.Point(109, 40);
            this.editMandantX.Name = "editMandantX";
            this.editMandantX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editMandantX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandantX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandantX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMandantX.Properties.Appearance.Options.UseBackColor = true;
            this.editMandantX.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandantX.Properties.Appearance.Options.UseFont = true;
            this.editMandantX.Properties.Appearance.Options.UseForeColor = true;
            this.editMandantX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editMandantX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editMandantX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editMandantX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editMandantX.Size = new System.Drawing.Size(205, 24);
            this.editMandantX.TabIndex = 2;
            this.editMandantX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editMandantX_UserModifiedFld);
            // 
            // editMandantNrX
            // 
            this.editMandantNrX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMandantNrX.Location = new System.Drawing.Point(320, 40);
            this.editMandantNrX.Name = "editMandantNrX";
            this.editMandantNrX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editMandantNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandantNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandantNrX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMandantNrX.Properties.Appearance.Options.UseBackColor = true;
            this.editMandantNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandantNrX.Properties.Appearance.Options.UseFont = true;
            this.editMandantNrX.Properties.Appearance.Options.UseForeColor = true;
            this.editMandantNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editMandantNrX.Properties.ReadOnly = true;
            this.editMandantNrX.Size = new System.Drawing.Size(70, 24);
            this.editMandantNrX.TabIndex = 3;
            this.editMandantNrX.TabStop = false;
            // 
            // editPlzOrtX
            // 
            this.editPlzOrtX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPlzOrtX.Location = new System.Drawing.Point(109, 79);
            this.editPlzOrtX.Name = "editPlzOrtX";
            this.editPlzOrtX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPlzOrtX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPlzOrtX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPlzOrtX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editPlzOrtX.Properties.Appearance.Options.UseBackColor = true;
            this.editPlzOrtX.Properties.Appearance.Options.UseBorderColor = true;
            this.editPlzOrtX.Properties.Appearance.Options.UseFont = true;
            this.editPlzOrtX.Properties.Appearance.Options.UseForeColor = true;
            this.editPlzOrtX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPlzOrtX.Properties.ReadOnly = true;
            this.editPlzOrtX.Size = new System.Drawing.Size(281, 24);
            this.editPlzOrtX.TabIndex = 5;
            this.editPlzOrtX.TabStop = false;
            // 
            // lblSearchMandant
            // 
            this.lblSearchMandant.ForeColor = System.Drawing.Color.Black;
            this.lblSearchMandant.Location = new System.Drawing.Point(30, 40);
            this.lblSearchMandant.Name = "lblSearchMandant";
            this.lblSearchMandant.Size = new System.Drawing.Size(73, 24);
            this.lblSearchMandant.TabIndex = 1;
            this.lblSearchMandant.Text = "Mandant";
            // 
            // grdPeriodenX
            // 
            this.grdPeriodenX.DataSource = this.qryPeriodeX;
            // 
            // 
            // 
            this.grdPeriodenX.EmbeddedNavigator.Name = "";
            this.grdPeriodenX.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPeriodenX.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdPeriodenX.Location = new System.Drawing.Point(411, 40);
            this.grdPeriodenX.MainView = this.grvPeriodenX;
            this.grdPeriodenX.Name = "grdPeriodenX";
            this.grdPeriodenX.Size = new System.Drawing.Size(401, 157);
            this.grdPeriodenX.TabIndex = 15;
            this.grdPeriodenX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPeriodenX});
            // 
            // qryPeriodeX
            // 
            this.qryPeriodeX.HostControl = this;
            this.qryPeriodeX.IsIdentityInsert = false;
            this.qryPeriodeX.TableName = "FbBuchungCode";
            this.qryPeriodeX.PositionChanged += new System.EventHandler(this.qryPeriodeX_PositionChanged);
            // 
            // grvPeriodenX
            // 
            this.grvPeriodenX.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPeriodenX.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.Empty.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.Empty.Options.UseFont = true;
            this.grvPeriodenX.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPeriodenX.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.EvenRow.Options.UseFont = true;
            this.grvPeriodenX.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriodenX.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPeriodenX.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPeriodenX.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPeriodenX.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriodenX.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPeriodenX.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPeriodenX.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPeriodenX.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriodenX.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPeriodenX.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvPeriodenX.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriodenX.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriodenX.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPeriodenX.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriodenX.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.GroupRow.Options.UseFont = true;
            this.grvPeriodenX.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPeriodenX.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPeriodenX.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPeriodenX.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPeriodenX.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPeriodenX.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPeriodenX.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPeriodenX.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriodenX.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPeriodenX.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPeriodenX.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriodenX.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvPeriodenX.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.OddRow.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.OddRow.Options.UseFont = true;
            this.grvPeriodenX.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPeriodenX.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.Row.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.Row.Options.UseFont = true;
            this.grvPeriodenX.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvPeriodenX.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodenX.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPeriodenX.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPeriodenX.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPeriodenX.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPeriodenX.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriodenX.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPeriodenX.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPeriodenX.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colBis,
            this.colStatus,
            this.colID});
            this.grvPeriodenX.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPeriodenX.GridControl = this.grdPeriodenX;
            this.grvPeriodenX.Name = "grvPeriodenX";
            this.grvPeriodenX.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvPeriodenX.OptionsBehavior.Editable = false;
            this.grvPeriodenX.OptionsCustomization.AllowFilter = false;
            this.grvPeriodenX.OptionsCustomization.AllowGroup = false;
            this.grvPeriodenX.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPeriodenX.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPeriodenX.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvPeriodenX.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvPeriodenX.OptionsNavigation.UseTabKey = false;
            this.grvPeriodenX.OptionsView.ColumnAutoWidth = false;
            this.grvPeriodenX.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPeriodenX.OptionsView.ShowGroupPanel = false;
            this.grvPeriodenX.OptionsView.ShowIndicator = false;
            // 
            // colVon
            // 
            this.colVon.Caption = "Periode Von";
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 90;
            // 
            // colBis
            // 
            this.colBis.Caption = "Periode Bis";
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            this.colBis.Width = 90;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 100;
            // 
            // colID
            // 
            this.colID.Caption = "PeriodeID";
            this.colID.FieldName = "FbPeriodeID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 3;
            // 
            // lblSearchDatumBis
            // 
            this.lblSearchDatumBis.ForeColor = System.Drawing.Color.Black;
            this.lblSearchDatumBis.Location = new System.Drawing.Point(229, 143);
            this.lblSearchDatumBis.Name = "lblSearchDatumBis";
            this.lblSearchDatumBis.Size = new System.Drawing.Size(18, 24);
            this.lblSearchDatumBis.TabIndex = 10;
            this.lblSearchDatumBis.Text = "-";
            // 
            // editDatumVonX
            // 
            this.editDatumVonX.EditValue = "";
            this.editDatumVonX.Location = new System.Drawing.Point(109, 143);
            this.editDatumVonX.Name = "editDatumVonX";
            this.editDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editDatumVonX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.editDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.editDatumVonX.Properties.Appearance.Options.UseForeColor = true;
            this.editDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editDatumVonX.Properties.ShowToday = false;
            this.editDatumVonX.Size = new System.Drawing.Size(106, 24);
            this.editDatumVonX.TabIndex = 9;
            // 
            // editDatumBisX
            // 
            this.editDatumBisX.EditValue = "";
            this.editDatumBisX.Location = new System.Drawing.Point(253, 143);
            this.editDatumBisX.Name = "editDatumBisX";
            this.editDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editDatumBisX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.editDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.editDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.editDatumBisX.Properties.Appearance.Options.UseForeColor = true;
            this.editDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.editDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.editDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editDatumBisX.Properties.ShowToday = false;
            this.editDatumBisX.Size = new System.Drawing.Size(106, 24);
            this.editDatumBisX.TabIndex = 11;
            // 
            // lblSearchDatumVon
            // 
            this.lblSearchDatumVon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchDatumVon.Location = new System.Drawing.Point(30, 143);
            this.lblSearchDatumVon.Name = "lblSearchDatumVon";
            this.lblSearchDatumVon.Size = new System.Drawing.Size(73, 24);
            this.lblSearchDatumVon.TabIndex = 8;
            this.lblSearchDatumVon.Text = "Datum";
            // 
            // CtlFibuJournal
            // 
            this.AutoRefresh = false;
            this.Controls.Add(this.tabSucheListe);
            this.Name = "CtlFibuJournal";
            this.Size = new System.Drawing.Size(840, 535);
            this.Print += new System.EventHandler(this.CtlFibuJournal_Print);
            this.Search += new System.EventHandler(this.CtlFibuJournal_Search);
            this.Load += new System.EventHandler(this.ctlFibuBuchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryJournal)).EndInit();
            this.tabSucheListe.ResumeLayout(false);
            this.tabListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJournal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvJournal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            this.tabSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchTeamMandantEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeamX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeamX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchMandatstraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMTX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriodenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriodenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumVon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the Load event of the ctlFibuBuchung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ctlFibuBuchung_Load(object sender, System.EventArgs e)
        {
            lblMandant.Text = "";

            SqlQuery qry = DBUtil.OpenSQL(
                "select FbTeamID Code, Name Text from FbTeam " +
                "union all " +
                "select null, null " +
                "order by 2");
            editTeamX.Properties.DataSource = qry;
            editTeamX.Properties.DropDownRows = Math.Min(qry.Count, 7);

            NeueSuche();
        }

        /// <summary>
        /// Handles the Print event of the CtlFibuJournal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFibuJournal_Print(
            object sender,
            System.EventArgs e)
        {
            if (!CheckPrms())
            {
                return;
            }

            GetKissMainForm().ContextPrint(this, null);
        }

        /// <summary>
        /// Handles the Search event of the CtlFibuJournal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFibuJournal_Search(object sender, System.EventArgs e)
        {
            if (this.tabSucheListe.SelectedTabIndex == 0)
            {
                NeueSuche();
            }
            else
            {
                Suchen();
            }
        }

        /// <summary>
        /// Handles the UserModifiedFld event of the editMandantX control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KiSS4.Gui.UserModifiedFldEventArgs"/> instance containing the event data.</param>
        private void editMandantX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(editMandantX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                if (DBUtil.IsEmpty(dlg["BaPersonID"]))
                    BaPersonID = 0;
                else
                    BaPersonID = (int)dlg["BaPersonID"];

                editMandantNrX.Text = dlg["BaPersonID"].ToString();
                editMandantX.Text = dlg["Mandant"].ToString();
                editPlzOrtX.Text = dlg["PLZOrt"].ToString();
                editMTX.Text = dlg["MTName"].ToString();
                ShowPerioden();
            }
        }

        /// <summary>
        /// Handles the PositionChanged event of the qryPeriodeX control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryPeriodeX_PositionChanged(object sender, System.EventArgs e)
        {
            SetDateRange();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public override object GetContextValue(
            string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "FBPERIODEID":
                    if (qryPeriodeX.Count > 0)
                        return qryPeriodeX["FbPeriodeID"];
                    else
                        return DBNull.Value;
                case "FBTEAMID":
                    return editTeamX.EditValue;
                case "DATUMVON":
                    return editDatumVonX.EditValue;
                case "DATUMBIS":
                    return editDatumBisX.EditValue;
            }

            return base.GetContextValue(FieldName);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Validate the serach fields.
        /// </summary>
        /// <returns></returns>
        private Boolean CheckPrms()
        {
            if (DBUtil.IsEmpty(editDatumVonX.EditValue))
            {
                KissMsg.ShowInfo(
                    "CtlFibuJournal",
                    "DatumVonLeer",
                    "Das Feld 'Datum von' darf nicht leer bleiben");
                return false;
            }

            if (DBUtil.IsEmpty(editDatumBisX.EditValue))
            {
                KissMsg.ShowInfo(
                    "CtlFibuJournal",
                    "DatumBisLeer",
                    "Das Feld 'Datum bis' darf nicht leer bleiben");
                return false;
            }

            if (DBUtil.IsEmpty(qryPeriodeX["FbPeriodeID"]))
            {
                if (DBUtil.IsEmpty(editTeamX.EditValue))
                {
                    KissMsg.ShowInfo(
                        "CtlFibuJournal",
                        "TeamLeer",
                        "Wenn Mandant leer bleibt, darf das Feld 'Team' nicht leer bleiben");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Starts a new search.
        /// </summary>
        private void NeueSuche()
        {
            tabSucheListe.SelectedTabIndex = 1;
            qryPeriodeX.DataTable.Rows.Clear();

            foreach (Control ctl in tabSuchen.Controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit)
                {
                    ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue = null;
                }
            }

            ApplicationFacade.DoEvents();
            editMandantX.Focus();
        }

        /// <summary>
        /// Sets the date range.
        /// </summary>
        private void SetDateRange()
        {
            if (qryPeriodeX.Count > 0)
            {
                editDatumVonX.DateTime = (DateTime)qryPeriodeX["PeriodeVon"];
                editDatumBisX.DateTime = (DateTime)qryPeriodeX["PeriodeBis"];
            }
        }

        /// <summary>
        /// Shows the time periods.
        /// </summary>
        private void ShowPerioden()
        {
            qryPeriodeX.Fill(
                " select PER.*, STA.Text StatusText " +
                " from   FbPeriode PER " +
                "        inner join XLOVCode STA on STA.Code = PER.PeriodeStatusCode and " +
                "                                   STA.LOVName = 'FbPeriodeStatus' " +
                " where BaPersonID = {0} " +
                " order by PeriodeVon",
                BaPersonID);

            if (qryPeriodeX.Count > 0)
            {
                qryPeriodeX.Last();
                SetDateRange();
            }
        }

        /// <summary>
        /// Search journal entries.
        /// </summary>
        private void Suchen()
        {
            if (!CheckPrms())
            {
                return;
            }

            if (DBUtil.IsEmpty(qryPeriodeX["FbPeriodeID"]))
            {
                qryJournal.Fill(
                    "  select BUC.*, " +
                    "         Mandant = PRS.Name + isNull(', ' + PRS.Vorname,'') + '  (' + convert(varchar,PRS.BaPersonID) + ')' " +
                    "  from   FbBuchung BUC " +
                    "         inner join FbPeriode PER on PER.FbPeriodeID = BUC.FbPeriodeID " +
                    "         inner join BaPerson PRS on PRS.BaPersonID = PER.BaPersonID " +
                    "  where  BUC.BuchungsDatum between {0} and {1} and " +
                    "         PER.FbTeamID = {2} " +
                    "  order by BuchungsDatum,BelegNr ",
                    editDatumVonX.DateTime,
                    editDatumBisX.DateTime,
                    editTeamX.EditValue);

                this.colMandant.GroupIndex = 0;

                lblMandant.Text = "Ablagejournal nach Mandant  (" + editDatumVonX.Text + " - " + editDatumBisX.Text + ")";
            }
            else
            {
                qryJournal.Fill(
                    "  select * " +
                    "  from   FBBuchung BUC " +
                    "  where  BUC.FbPeriodeID = {0} and " +
                    "         BUC.BuchungsDatum between {1} and {2} " +
                    "  order by BuchungsDatum,BelegNr ",
                    qryPeriodeX["FbPeriodeID"],
                    editDatumVonX.DateTime,
                    editDatumBisX.DateTime);

                this.colMandant.GroupIndex = -1;

                lblMandant.Text = editMandantX.Text + "  (" + editDatumVonX.Text + " - " + editDatumBisX.Text + ")";
            }

            grvJournal.ExpandAllGroups();

            tabSucheListe.SelectedTabIndex = 0;
        }

        #endregion

        #endregion
    }
}