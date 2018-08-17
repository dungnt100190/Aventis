using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuBilanzErfolg.
    /// </summary>
    public class CtlFibuBilanzErfolg : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colEroeffnungsSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colKlasse;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoName;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalZeile;
        private DevExpress.XtraGrid.Columns.GridColumn colUmsatz;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit editMandantNrX;
        private KiSS4.Gui.KissButtonEdit editMandantX;
        private KiSS4.Gui.KissTextEdit editMTX;
        private System.Windows.Forms.CheckBox editNurMitBuchungen;
        private KiSS4.Gui.KissDateEdit editPerDatum;
        private KiSS4.Gui.KissTextEdit editPlzOrtX;
        private KiSS4.Gui.KissGrid grid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private KiSS4.Gui.KissGrid gridPeriodenX;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel label30;
        private KiSS4.Gui.KissLabel label32;
        private KiSS4.Gui.KissLabel label37;
        private KiSS4.Gui.KissLabel lblMandant;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.DB.SqlQuery qryBilanz;
        private KiSS4.DB.SqlQuery qryPeriodeX;
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;

        #endregion

        #endregion

        #region Constructors

        public CtlFibuBilanzErfolg()
        {
            //
            // Required for Windows Form Designer support
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuBilanzErfolg));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBilanz = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grid = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKlasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEroeffnungsSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUmsatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalZeile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.editPerDatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.editNurMitBuchungen = new System.Windows.Forms.CheckBox();
            this.label30 = new KiSS4.Gui.KissLabel();
            this.label32 = new KiSS4.Gui.KissLabel();
            this.editMTX = new KiSS4.Gui.KissTextEdit();
            this.editMandantX = new KiSS4.Gui.KissButtonEdit();
            this.editMandantNrX = new KiSS4.Gui.KissTextEdit();
            this.editPlzOrtX = new KiSS4.Gui.KissTextEdit();
            this.label37 = new KiSS4.Gui.KissLabel();
            this.gridPeriodenX = new KiSS4.Gui.KissGrid();
            this.qryPeriodeX = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryBilanz)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPerDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMTX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriodenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // qryBilanz
            // 
            this.qryBilanz.HostControl = this;
            this.qryBilanz.IsIdentityInsert = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Location = new System.Drawing.Point(7, 10);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(805, 515);
            this.tabControlSearch.TabIndex = 287;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.TabStop = false;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.panel1);
            this.tpgListe.Controls.Add(this.lblMandant);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(793, 477);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 452);
            this.panel1.TabIndex = 4;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.DataSource = this.qryBilanz;
            // 
            // 
            // 
            this.grid.EmbeddedNavigator.Name = "";
            this.grid.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.gridView1;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(793, 452);
            this.grid.Styles.AddReplace("StyleCenter", new DevExpress.Utils.ViewStyleEx("StyleCenter", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("StyleBold", new DevExpress.Utils.ViewStyle("StyleBold", null, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "GroupRow", DevExpress.Utils.StyleOptions.UseFont, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText));
            this.grid.Styles.AddReplace("StyleFar", new DevExpress.Utils.ViewStyleEx("StyleFar", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("StyleNear", new DevExpress.Utils.ViewStyleEx("StyleNear", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.TabIndex = 3;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
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
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKlasse,
            this.colKtoNr,
            this.colKontoName,
            this.colEroeffnungsSaldo,
            this.colUmsatz,
            this.colSaldo,
            this.colTotalZeile});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grid;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupFormat = "{1}";
            this.gridView1.GroupRowHeight = 25;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKlasse, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // colKlasse
            // 
            this.colKlasse.Caption = "Klasse";
            this.colKlasse.FieldName = "Klasse";
            this.colKlasse.Name = "colKlasse";
            this.colKlasse.Width = 59;
            // 
            // colKtoNr
            // 
            this.colKtoNr.Caption = "Kto-Nr.";
            this.colKtoNr.FieldName = "KontoNr";
            this.colKtoNr.Name = "colKtoNr";
            this.colKtoNr.Visible = true;
            this.colKtoNr.VisibleIndex = 0;
            this.colKtoNr.Width = 80;
            // 
            // colKontoName
            // 
            this.colKontoName.Caption = "Kontoname";
            this.colKontoName.FieldName = "KontoName";
            this.colKontoName.Name = "colKontoName";
            this.colKontoName.Visible = true;
            this.colKontoName.VisibleIndex = 1;
            this.colKontoName.Width = 320;
            // 
            // colEroeffnungsSaldo
            // 
            this.colEroeffnungsSaldo.Caption = "Eröffnung";
            this.colEroeffnungsSaldo.DisplayFormat.FormatString = "N2";
            this.colEroeffnungsSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEroeffnungsSaldo.FieldName = "EroeffnungsSaldo";
            this.colEroeffnungsSaldo.Name = "colEroeffnungsSaldo";
            this.colEroeffnungsSaldo.Visible = true;
            this.colEroeffnungsSaldo.VisibleIndex = 2;
            this.colEroeffnungsSaldo.Width = 120;
            // 
            // colUmsatz
            // 
            this.colUmsatz.Caption = "Umsatz";
            this.colUmsatz.DisplayFormat.FormatString = "N2";
            this.colUmsatz.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUmsatz.FieldName = "Umsatz";
            this.colUmsatz.Name = "colUmsatz";
            this.colUmsatz.Visible = true;
            this.colUmsatz.VisibleIndex = 3;
            this.colUmsatz.Width = 120;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "N2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 4;
            this.colSaldo.Width = 120;
            // 
            // colTotalZeile
            // 
            this.colTotalZeile.Caption = "TotalZeile";
            this.colTotalZeile.FieldName = "TotalZeile";
            this.colTotalZeile.Name = "colTotalZeile";
            // 
            // lblMandant
            // 
            this.lblMandant.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMandant.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblMandant.Location = new System.Drawing.Point(0, 0);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(793, 25);
            this.lblMandant.TabIndex = 3;
            this.lblMandant.Text = "Mandant";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.editPerDatum);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.editNurMitBuchungen);
            this.tpgSuchen.Controls.Add(this.label30);
            this.tpgSuchen.Controls.Add(this.label32);
            this.tpgSuchen.Controls.Add(this.editMTX);
            this.tpgSuchen.Controls.Add(this.editMandantX);
            this.tpgSuchen.Controls.Add(this.editMandantNrX);
            this.tpgSuchen.Controls.Add(this.editPlzOrtX);
            this.tpgSuchen.Controls.Add(this.label37);
            this.tpgSuchen.Controls.Add(this.gridPeriodenX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(793, 477);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Visible = false;
            // 
            // editPerDatum
            // 
            this.editPerDatum.EditValue = null;
            this.editPerDatum.Location = new System.Drawing.Point(84, 120);
            this.editPerDatum.Name = "editPerDatum";
            this.editPerDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editPerDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPerDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPerDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPerDatum.Properties.Appearance.Options.UseBackColor = true;
            this.editPerDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.editPerDatum.Properties.Appearance.Options.UseFont = true;
            this.editPerDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editPerDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editPerDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editPerDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editPerDatum.Properties.ShowToday = false;
            this.editPerDatum.Size = new System.Drawing.Size(100, 24);
            this.editPerDatum.TabIndex = 1;
            // 
            // kissLabel1
            // 
            this.kissLabel1.ForeColor = System.Drawing.Color.Black;
            this.kissLabel1.Location = new System.Drawing.Point(5, 120);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(61, 24);
            this.kissLabel1.TabIndex = 371;
            this.kissLabel1.Text = "per Datum";
            // 
            // editNurMitBuchungen
            // 
            this.editNurMitBuchungen.Location = new System.Drawing.Point(84, 154);
            this.editNurMitBuchungen.Name = "editNurMitBuchungen";
            this.editNurMitBuchungen.Size = new System.Drawing.Size(210, 24);
            this.editNurMitBuchungen.TabIndex = 2;
            this.editNurMitBuchungen.Text = "nur Konti mit Buchungen";
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(5, 57);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 24);
            this.label30.TabIndex = 370;
            this.label30.Text = "Ort";
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(5, 80);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(61, 24);
            this.label32.TabIndex = 369;
            this.label32.Text = "M.Träger";
            // 
            // editMTX
            // 
            this.editMTX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMTX.Location = new System.Drawing.Point(84, 80);
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
            this.editMTX.Size = new System.Drawing.Size(285, 24);
            this.editMTX.TabIndex = 368;
            this.editMTX.TabStop = false;
            // 
            // editMandantX
            // 
            this.editMandantX.Location = new System.Drawing.Point(84, 18);
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
            this.editMandantX.TabIndex = 0;
            this.editMandantX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editMandantX_UserModifiedFld);
            // 
            // editMandantNrX
            // 
            this.editMandantNrX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMandantNrX.Location = new System.Drawing.Point(300, 18);
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
            this.editMandantNrX.TabIndex = 367;
            this.editMandantNrX.TabStop = false;
            // 
            // editPlzOrtX
            // 
            this.editPlzOrtX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPlzOrtX.Location = new System.Drawing.Point(84, 57);
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
            this.editPlzOrtX.Size = new System.Drawing.Size(285, 24);
            this.editPlzOrtX.TabIndex = 366;
            this.editPlzOrtX.TabStop = false;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(5, 18);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 24);
            this.label37.TabIndex = 365;
            this.label37.Text = "Mandant";
            // 
            // gridPeriodenX
            // 
            this.gridPeriodenX.DataSource = this.qryPeriodeX;
            // 
            // 
            // 
            this.gridPeriodenX.EmbeddedNavigator.Name = "";
            this.gridPeriodenX.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridPeriodenX.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridPeriodenX.Location = new System.Drawing.Point(408, 18);
            this.gridPeriodenX.MainView = this.gridView2;
            this.gridPeriodenX.Name = "gridPeriodenX";
            this.gridPeriodenX.Size = new System.Drawing.Size(384, 89);
            this.gridPeriodenX.TabIndex = 3;
            this.gridPeriodenX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryPeriodeX
            // 
            this.qryPeriodeX.HostControl = this;
            this.qryPeriodeX.IsIdentityInsert = false;
            this.qryPeriodeX.TableName = "FbBuchungCode";
            this.qryPeriodeX.PositionChanged += new System.EventHandler(this.qryPeriodeX_PositionChanged);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridPeriodenX;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Periode Von";
            this.gridColumn1.FieldName = "PeriodeVon";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Periode Bis";
            this.gridColumn2.FieldName = "PeriodeBis";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 90;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Status";
            this.gridColumn3.FieldName = "StatusText";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "PeriodeID";
            this.gridColumn4.FieldName = "FbPeriodeID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridView4
            // 
            this.gridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colBis,
            this.colStatus});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsCustomization.AllowGroup = false;
            this.gridView4.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView4.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView4.OptionsNavigation.UseTabKey = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // colVon
            // 
            this.colVon.Caption = "Periode Von";
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 115;
            // 
            // colBis
            // 
            this.colBis.Caption = "Periode Bis";
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            this.colBis.Width = 102;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 120;
            // 
            // CtlFibuBilanzErfolg
            // 
            this.ActiveSQLQuery = this.qryBilanz;
            this.AutoRefresh = false;
            this.Controls.Add(this.tabControlSearch);
            this.Name = "CtlFibuBilanzErfolg";
            this.Size = new System.Drawing.Size(820, 535);
            this.Search += new System.EventHandler(this.CtlFibuBilanzErfolg_Search);
            this.Load += new System.EventHandler(this.CtlFibuBilanzErfolg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryBilanz)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editPerDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMTX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriodenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void CtlFibuBilanzErfolg_Load(object sender, System.EventArgs e)
        {
            lblMandant.Text = "";
            NeueSuche();
        }

        private void CtlFibuBilanzErfolg_Search(object sender, System.EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 0)
            {
                NeueSuche();
            }
            else
                Suchen();
        }

        private void CtlFibuKontoblatt_Print(object sender, System.EventArgs e)
        {
            if (!CheckPrms(true)) return;
            GetKissMainForm().ContextPrint(this, null);
        }

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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (((e.Column.FieldName == "Saldo") || (e.Column.FieldName == "KontoName")) &&
                (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["KontoNr"]) == DBNull.Value))
            {
                e.Appearance.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            }
            else
            {
                e.Appearance.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            }
        }

        private void qryPeriodeX_PositionChanged(object sender, System.EventArgs e)
        {
            editPerDatum.EditValue = qryPeriodeX["PeriodeBis"];
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper(CultureInfo.InvariantCulture))
            {
                case "FBPERIODEID":
                    if (qryPeriodeX.Count > 0)
                        return qryPeriodeX["FbPeriodeID"];
                    else
                        return DBNull.Value;
                case "NURMITBUCHUNGEN":
                    return editNurMitBuchungen.Checked;
                case "PERDATUM":
                    return editPerDatum.EditValue;
            }

            return base.GetContextValue(FieldName);
        }

        public void RefreshBilanzErfolg()
        {
            if (DBUtil.IsEmpty(qryBilanz.SelectStatement)) return;

            if (CheckPrms(false))
                Suchen();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Validiert die Suchfelder.
        /// </summary>
        /// <returns></returns>
        private bool CheckPrms(bool withMsg)
        {
            // Suchfelder validieren
            if (BaPersonID == 0)
            {
                if (withMsg)
                    KissMsg.ShowInfo("CtlFibuBilanzErfolg", "KeinMandant", "Es ist noch kein Mandant ausgewählt !");
                return false;
            }

            if (qryPeriodeX.Count == 0)
            {
                if (withMsg)
                    KissMsg.ShowInfo("CtlFibuBilanzErfolg", "KeineGueltigePeriode", "Es ist noch keine gültige Periode ausgewählt !");
                return false;
            }

            if (DBUtil.IsEmpty(editPerDatum.EditValue))
            {
                if (withMsg)
                    KissMsg.ShowInfo("CtlFibuBilanzErfolg", "PerDatumLeer", "Das Feld 'Per Datum' darf nicht leer bleiben");
                return false;
            }

            return true;
        }

        private void NeueSuche()
        {
            tabControlSearch.SelectedTabIndex = 1;
            qryPeriodeX.DataTable.Rows.Clear();

            foreach (Control ctl in tpgSuchen.Controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit)
                    ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue = null;
            }
            editNurMitBuchungen.Checked = true;

            editMandantX.Focus();
        }

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
            }
        }

        /// <summary>
        /// Startet die Suche.
        /// </summary>
        private void Suchen()
        {
            if (!CheckPrms(true))
                return;

            qryBilanz.Fill(
                "exec spFbGetBilanzErfolg {0},{1},{2}",
                qryPeriodeX["FbPeriodeID"],
                DateTime.Parse(editPerDatum.EditValue.ToString()),
                editNurMitBuchungen.Checked);

            gridView1.ExpandAllGroups();

            lblMandant.Text = editMandantX.Text + "  (" +
                              ((DateTime)qryPeriodeX["PeriodeVon"]).ToString("dd.MM.yyyy") + " - " +
                              ((DateTime)qryPeriodeX["PeriodeBis"]).ToString("dd.MM.yyyy") + ")";

            tabControlSearch.SelectedTabIndex = 0;
            gridView1.ExpandAllGroups();
            grid.Focus();
        }

        #endregion

        #endregion
    }
}