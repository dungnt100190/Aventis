using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public class CtlKbKonto : KiSS4.Gui.KissUserControl
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        private KiSS4.Gui.KissButton btnCollapse;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnExpand;
        private KiSS4.Gui.KissButton btnLeft;
        private KiSS4.Gui.KissButton btnRight;
        private KiSS4.Gui.KissButton btnUp;
        private bool buchungExists = false;
        private KiSS4.Gui.KissCheckedLookupEdit chkKontoArtCodes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBilanzErfolg;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKonto;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKontoart;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVorsaldo;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtKbKontoklasseCode;
        private KiSS4.Gui.KissButtonEdit edtKbZahlungsKonto;
        private KiSS4.Gui.KissCheckEdit edtKontogruppe;
        private KiSS4.Gui.KissTextEdit edtKontoName;
        private KiSS4.Gui.KissTextEdit edtKontoNr;
        private KiSS4.Gui.KissTextEdit edtMandantNrX;
        private KiSS4.Gui.KissButtonEdit edtMandantX;
        private KiSS4.Gui.KissCheckEdit edtSaldovortrag;
        private KiSS4.Gui.KissCalcEdit edtVorsaldo;
        private KiSS4.Gui.KissTextEdit edtZahlungsKontoDetails;
        private KiSS4.Gui.KissGrid grdPeriode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private int gruppeKontoID = 0;
        private System.Windows.Forms.ImageList imageList1;

        /// <summary>
        /// Refresh tree after changes made to data
        /// </summary>
        private bool isRefreshingTree = false;

        // wenn 0: anzeigen des StandardKontoplans
        private int kbMandantID = 0;

        private DevExpress.XtraTreeList.Columns.TreeListColumn KbZahlungskonto;
        private int lastSelectedPosition = -1;

        private KiSS4.Gui.KissLabel lblKbKontoklasseCode;

        private KiSS4.Gui.KissLabel lblKbZahlungsKonto;

        private KiSS4.Gui.KissLabel lblKontoNrName;

        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissLabel lblStandardKontenplan;
        private KiSS4.Gui.KissLabel lblVorsaldo;
        private KiSS4.DB.SqlQuery qryKbKonto;
        private KiSS4.DB.SqlQuery qryPeriodeX;
        private KiSS4.DB.SqlQuery qryTreeItems;
        private int sortKey = 0; //-1;
        private KiSS4.Gui.KissTree treKbKonto;

        #endregion

        #region Constructors

        public CtlKbKonto()
        {
            this.InitializeComponent();

            // set no datasource due to init
            this.treKbKonto.DataSource = null;

            this.KbMandantID = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbMandantID");
            ShowPerioden();

            this.FillDataSource(this.qryKbKonto);
            this.FillDataSource(this.qryTreeItems);
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbKonto));
            this.edtMandantX = new KiSS4.Gui.KissButtonEdit();
            this.grdPeriode = new KiSS4.Gui.KissGrid();
            this.qryPeriodeX = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.treKbKonto = new KiSS4.Gui.KissTree();
            this.colKonto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBilanzErfolg = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colVorsaldo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKontoart = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.KbZahlungskonto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryTreeItems = new KiSS4.DB.SqlQuery(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.edtKontoNr = new KiSS4.Gui.KissTextEdit();
            this.qryKbKonto = new KiSS4.DB.SqlQuery(this.components);
            this.edtKontoName = new KiSS4.Gui.KissTextEdit();
            this.edtKbKontoklasseCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtVorsaldo = new KiSS4.Gui.KissCalcEdit();
            this.edtKbZahlungsKonto = new KiSS4.Gui.KissButtonEdit();
            this.chkKontoArtCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtSaldovortrag = new KiSS4.Gui.KissCheckEdit();
            this.edtKontogruppe = new KiSS4.Gui.KissCheckEdit();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.edtMandantNrX = new KiSS4.Gui.KissTextEdit();
            this.lblStandardKontenplan = new KiSS4.Gui.KissLabel();
            this.lblKontoNrName = new KiSS4.Gui.KissLabel();
            this.lblKbZahlungsKonto = new KiSS4.Gui.KissLabel();
            this.lblVorsaldo = new KiSS4.Gui.KissLabel();
            this.lblKbKontoklasseCode = new KiSS4.Gui.KissLabel();
            this.btnRight = new KiSS4.Gui.KissButton();
            this.btnLeft = new KiSS4.Gui.KissButton();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.btnExpand = new KiSS4.Gui.KissButton();
            this.btnCollapse = new KiSS4.Gui.KissButton();
            this.edtZahlungsKontoDetails = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treKbKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTreeItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbKontoklasseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbKontoklasseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorsaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungsKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontoArtCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontogruppe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandardKontenplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbZahlungsKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorsaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbKontoklasseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsKontoDetails.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // edtMandantX
            //
            this.edtMandantX.Location = new System.Drawing.Point(100, 10);
            this.edtMandantX.Name = "edtMandantX";
            this.edtMandantX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandantX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantX.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantX.Properties.Appearance.Options.UseFont = true;
            this.edtMandantX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMandantX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMandantX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandantX.Properties.Name = "editMandant.Properties";
            this.edtMandantX.Size = new System.Drawing.Size(205, 24);
            this.edtMandantX.TabIndex = 0;
            this.edtMandantX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editMandantX_UserModifiedFld);
            //
            // grdPeriode
            //
            this.grdPeriode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPeriode.DataSource = this.qryPeriodeX;
            this.grdPeriode.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdPeriode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPeriode.Location = new System.Drawing.Point(10, 46);
            this.grdPeriode.MainView = this.gridView2;
            this.grdPeriode.MaximumSize = new System.Drawing.Size(790, 120);
            this.grdPeriode.Name = "grdPeriode";
            this.grdPeriode.Size = new System.Drawing.Size(790, 120);
            this.grdPeriode.TabIndex = 1;
            this.grdPeriode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.grdPeriode.Visible = false;
            //
            // qryPeriodeX
            //
            this.qryPeriodeX.HostControl = this;
            this.qryPeriodeX.SelectStatement = "SELECT * \r\nFROM KbPeriode";
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
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colBis,
            this.colStatus});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdPeriode;
            this.gridView2.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            //
            // colVon
            //
            this.colVon.Caption = "Periode Von";
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 160;
            //
            // colBis
            //
            this.colBis.Caption = "Periode Bis";
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            this.colBis.Width = 135;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "PeriodeStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 164;
            //
            // treKbKonto
            //
            this.treKbKonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treKbKonto.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treKbKonto.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treKbKonto.Appearance.Empty.Options.UseBackColor = true;
            this.treKbKonto.Appearance.Empty.Options.UseForeColor = true;
            this.treKbKonto.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treKbKonto.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.EvenRow.Options.UseBackColor = true;
            this.treKbKonto.Appearance.EvenRow.Options.UseForeColor = true;
            this.treKbKonto.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treKbKonto.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treKbKonto.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treKbKonto.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treKbKonto.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treKbKonto.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treKbKonto.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treKbKonto.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treKbKonto.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treKbKonto.Appearance.FooterPanel.Options.UseFont = true;
            this.treKbKonto.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treKbKonto.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treKbKonto.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treKbKonto.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.GroupButton.Options.UseBackColor = true;
            this.treKbKonto.Appearance.GroupButton.Options.UseFont = true;
            this.treKbKonto.Appearance.GroupButton.Options.UseForeColor = true;
            this.treKbKonto.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treKbKonto.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treKbKonto.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treKbKonto.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treKbKonto.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treKbKonto.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treKbKonto.Appearance.HeaderPanel.Options.UseFont = true;
            this.treKbKonto.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treKbKonto.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treKbKonto.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treKbKonto.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treKbKonto.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treKbKonto.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treKbKonto.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treKbKonto.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treKbKonto.Appearance.HorzLine.Options.UseBackColor = true;
            this.treKbKonto.Appearance.HorzLine.Options.UseForeColor = true;
            this.treKbKonto.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treKbKonto.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treKbKonto.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.OddRow.Options.UseBackColor = true;
            this.treKbKonto.Appearance.OddRow.Options.UseFont = true;
            this.treKbKonto.Appearance.OddRow.Options.UseForeColor = true;
            this.treKbKonto.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treKbKonto.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treKbKonto.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treKbKonto.Appearance.Preview.Options.UseBackColor = true;
            this.treKbKonto.Appearance.Preview.Options.UseFont = true;
            this.treKbKonto.Appearance.Preview.Options.UseForeColor = true;
            this.treKbKonto.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treKbKonto.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treKbKonto.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treKbKonto.Appearance.Row.Options.UseBackColor = true;
            this.treKbKonto.Appearance.Row.Options.UseFont = true;
            this.treKbKonto.Appearance.Row.Options.UseForeColor = true;
            this.treKbKonto.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treKbKonto.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treKbKonto.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treKbKonto.Appearance.TreeLine.Options.UseBackColor = true;
            this.treKbKonto.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treKbKonto.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treKbKonto.Appearance.VertLine.Options.UseBackColor = true;
            this.treKbKonto.Appearance.VertLine.Options.UseForeColor = true;
            this.treKbKonto.Appearance.VertLine.Options.UseTextOptions = true;
            this.treKbKonto.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treKbKonto.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colKonto,
            this.colBilanzErfolg,
            this.colVorsaldo,
            this.colKontoart,
            this.KbZahlungskonto});
            this.treKbKonto.DataSource = this.qryTreeItems;
            this.treKbKonto.ImageIndexFieldName = "IconIndex";
            this.treKbKonto.KeyFieldName = "KbKontoID";
            this.treKbKonto.Location = new System.Drawing.Point(10, 180);
            this.treKbKonto.Name = "treKbKonto";
            this.treKbKonto.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treKbKonto.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treKbKonto.OptionsBehavior.Editable = false;
            this.treKbKonto.OptionsBehavior.KeepSelectedOnClick = false;
            this.treKbKonto.OptionsBehavior.MoveOnEdit = false;
            this.treKbKonto.OptionsMenu.EnableColumnMenu = false;
            this.treKbKonto.OptionsMenu.EnableFooterMenu = false;
            this.treKbKonto.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treKbKonto.OptionsView.AutoWidth = false;
            this.treKbKonto.OptionsView.EnableAppearanceEvenRow = true;
            this.treKbKonto.OptionsView.EnableAppearanceOddRow = true;
            this.treKbKonto.OptionsView.ShowIndicator = false;
            this.treKbKonto.ParentFieldName = "GruppeKontoID";
            this.treKbKonto.SelectImageList = this.imageList1;
            this.treKbKonto.Size = new System.Drawing.Size(790, 320);
            this.treKbKonto.TabIndex = 2;
            this.treKbKonto.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treKbKonto_FocusedNodeChanged);
            //
            // colKonto
            //
            this.colKonto.Caption = "Konto";
            this.colKonto.FieldName = "Konto";
            this.colKonto.MinWidth = 43;
            this.colKonto.Name = "colKonto";
            this.colKonto.OptionsColumn.AllowSort = false;
            this.colKonto.VisibleIndex = 0;
            this.colKonto.Width = 255;
            //
            // colBilanzErfolg
            //
            this.colBilanzErfolg.AppearanceCell.Options.UseTextOptions = true;
            this.colBilanzErfolg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBilanzErfolg.Caption = "B/E";
            this.colBilanzErfolg.FieldName = "BE";
            this.colBilanzErfolg.Name = "colBilanzErfolg";
            this.colBilanzErfolg.OptionsColumn.AllowSort = false;
            this.colBilanzErfolg.VisibleIndex = 1;
            this.colBilanzErfolg.Width = 44;
            //
            // colVorsaldo
            //
            this.colVorsaldo.AppearanceCell.Options.UseTextOptions = true;
            this.colVorsaldo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVorsaldo.Caption = "Vorsaldo";
            this.colVorsaldo.FieldName = "Vorsaldo";
            this.colVorsaldo.Format.FormatString = "n2";
            this.colVorsaldo.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVorsaldo.Name = "colVorsaldo";
            this.colVorsaldo.OptionsColumn.AllowSort = false;
            this.colVorsaldo.VisibleIndex = 2;
            this.colVorsaldo.Width = 74;
            //
            // colKontoart
            //
            this.colKontoart.Caption = "Kontoart";
            this.colKontoart.FieldName = "KontoArt";
            this.colKontoart.Name = "colKontoart";
            this.colKontoart.OptionsColumn.AllowSort = false;
            this.colKontoart.VisibleIndex = 3;
            this.colKontoart.Width = 184;
            //
            // KbZahlungskonto
            //
            this.KbZahlungskonto.Caption = "Zahlungskonto";
            this.KbZahlungskonto.FieldName = "Zahlungskonto";
            this.KbZahlungskonto.Name = "KbZahlungskonto";
            this.KbZahlungskonto.OptionsColumn.AllowSort = false;
            this.KbZahlungskonto.VisibleIndex = 4;
            this.KbZahlungskonto.Width = 216;
            //
            // qryTreeItems
            //
            this.qryTreeItems.HostControl = this;
            this.qryTreeItems.TableName = "KbKonto";
            this.qryTreeItems.AfterFill += new System.EventHandler(this.qryTreeItems_AfterFill);
            //
            // imageList1
            //
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            //
            // edtKontoNr
            //
            this.edtKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontoNr.DataMember = "KontoNr";
            this.edtKontoNr.DataSource = this.qryKbKonto;
            this.edtKontoNr.Location = new System.Drawing.Point(100, 510);
            this.edtKontoNr.Name = "edtKontoNr";
            this.edtKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontoNr.Size = new System.Drawing.Size(119, 24);
            this.edtKontoNr.TabIndex = 3;
            //
            // qryKbKonto
            //
            this.qryKbKonto.CanDelete = true;
            this.qryKbKonto.CanInsert = true;
            this.qryKbKonto.CanUpdate = true;
            this.qryKbKonto.HostControl = this;
            this.qryKbKonto.TableName = "KbKonto";
            this.qryKbKonto.PostCompleted += new System.EventHandler(this.qryKbKonto_PostCompleted);
            this.qryKbKonto.BeforePost += new System.EventHandler(this.qryKbKonto_BeforePost);
            this.qryKbKonto.PositionChanged += new System.EventHandler(this.qryKbKonto_PositionChanged);
            this.qryKbKonto.AfterInsert += new System.EventHandler(this.qryKbKonto_AfterInsert);
            this.qryKbKonto.BeforeInsert += new System.EventHandler(this.qryKbKonto_BeforeInsert);
            //
            // edtKontoName
            //
            this.edtKontoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontoName.DataMember = "KontoName";
            this.edtKontoName.DataSource = this.qryKbKonto;
            this.edtKontoName.Location = new System.Drawing.Point(229, 510);
            this.edtKontoName.Name = "edtKontoName";
            this.edtKontoName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoName.Properties.Appearance.Options.UseFont = true;
            this.edtKontoName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontoName.Size = new System.Drawing.Size(571, 24);
            this.edtKontoName.TabIndex = 4;
            //
            // edtKbKontoklasseCode
            //
            this.edtKbKontoklasseCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKbKontoklasseCode.DataMember = "KbKontoKlasseCode";
            this.edtKbKontoklasseCode.DataSource = this.qryKbKonto;
            this.edtKbKontoklasseCode.Location = new System.Drawing.Point(100, 540);
            this.edtKbKontoklasseCode.LOVName = "KbKontoKlasse";
            this.edtKbKontoklasseCode.Name = "edtKbKontoklasseCode";
            this.edtKbKontoklasseCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKbKontoklasseCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKbKontoklasseCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbKontoklasseCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKbKontoklasseCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKbKontoklasseCode.Properties.Appearance.Options.UseFont = true;
            this.edtKbKontoklasseCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKbKontoklasseCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbKontoklasseCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKbKontoklasseCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKbKontoklasseCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKbKontoklasseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKbKontoklasseCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKbKontoklasseCode.Properties.NullText = "";
            this.edtKbKontoklasseCode.Properties.ShowFooter = false;
            this.edtKbKontoklasseCode.Properties.ShowHeader = false;
            this.edtKbKontoklasseCode.Size = new System.Drawing.Size(119, 24);
            this.edtKbKontoklasseCode.TabIndex = 5;
            //
            // edtVorsaldo
            //
            this.edtVorsaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVorsaldo.DataMember = "Vorsaldo";
            this.edtVorsaldo.DataSource = this.qryKbKonto;
            this.edtVorsaldo.Location = new System.Drawing.Point(100, 570);
            this.edtVorsaldo.Name = "edtVorsaldo";
            this.edtVorsaldo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVorsaldo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorsaldo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorsaldo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorsaldo.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorsaldo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorsaldo.Properties.Appearance.Options.UseFont = true;
            this.edtVorsaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorsaldo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVorsaldo.Properties.DisplayFormat.FormatString = "N2";
            this.edtVorsaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVorsaldo.Properties.EditFormat.FormatString = "N2";
            this.edtVorsaldo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVorsaldo.Properties.Mask.EditMask = "N2";
            this.edtVorsaldo.Size = new System.Drawing.Size(119, 24);
            this.edtVorsaldo.TabIndex = 6;
            //
            // edtKbZahlungsKonto
            //
            this.edtKbZahlungsKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKbZahlungsKonto.DataMember = "KbZahlungsKonto";
            this.edtKbZahlungsKonto.DataSource = this.qryKbKonto;
            this.edtKbZahlungsKonto.Location = new System.Drawing.Point(100, 600);
            this.edtKbZahlungsKonto.Name = "edtKbZahlungsKonto";
            this.edtKbZahlungsKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKbZahlungsKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKbZahlungsKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbZahlungsKonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtKbZahlungsKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKbZahlungsKonto.Properties.Appearance.Options.UseFont = true;
            this.edtKbZahlungsKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKbZahlungsKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKbZahlungsKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKbZahlungsKonto.Properties.Name = "editMandant.Properties";
            this.edtKbZahlungsKonto.Size = new System.Drawing.Size(120, 24);
            this.edtKbZahlungsKonto.TabIndex = 7;
            this.edtKbZahlungsKonto.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZahlungsKonto_UserModifiedFld);
            //
            // chkKontoArtCodes
            //
            this.chkKontoArtCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKontoArtCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.chkKontoArtCodes.Appearance.Options.UseBackColor = true;
            this.chkKontoArtCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkKontoArtCodes.CheckOnClick = true;
            this.chkKontoArtCodes.DataMember = "KbKontoArtCodes";
            this.chkKontoArtCodes.DataSource = this.qryKbKonto;
            this.chkKontoArtCodes.Location = new System.Drawing.Point(454, 540);
            this.chkKontoArtCodes.LOVName = "KbKontoArt";
            this.chkKontoArtCodes.Name = "chkKontoArtCodes";
            this.chkKontoArtCodes.Size = new System.Drawing.Size(198, 129);
            this.chkKontoArtCodes.TabIndex = 8;
            //
            // edtSaldovortrag
            //
            this.edtSaldovortrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSaldovortrag.DataMember = "Saldovortrag";
            this.edtSaldovortrag.DataSource = this.qryKbKonto;
            this.edtSaldovortrag.Location = new System.Drawing.Point(658, 538);
            this.edtSaldovortrag.Name = "edtSaldovortrag";
            this.edtSaldovortrag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSaldovortrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtSaldovortrag.Properties.Caption = "Saldovortrag";
            this.edtSaldovortrag.Size = new System.Drawing.Size(103, 19);
            this.edtSaldovortrag.TabIndex = 9;
            //
            // edtKontogruppe
            //
            this.edtKontogruppe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontogruppe.DataMember = "KontoGruppe";
            this.edtKontogruppe.DataSource = this.qryKbKonto;
            this.edtKontogruppe.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontogruppe.Location = new System.Drawing.Point(658, 563);
            this.edtKontogruppe.Name = "edtKontogruppe";
            this.edtKontogruppe.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKontogruppe.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontogruppe.Properties.Caption = "Kontogruppe";
            this.edtKontogruppe.Properties.ReadOnly = true;
            this.edtKontogruppe.Size = new System.Drawing.Size(94, 19);
            this.edtKontogruppe.TabIndex = 10;
            //
            // lblMandant
            //
            this.lblMandant.Location = new System.Drawing.Point(10, 10);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(63, 24);
            this.lblMandant.TabIndex = 262;
            this.lblMandant.Text = "Mandant";
            this.lblMandant.UseCompatibleTextRendering = true;
            //
            // edtMandantNrX
            //
            this.edtMandantNrX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMandantNrX.Location = new System.Drawing.Point(312, 10);
            this.edtMandantNrX.Name = "edtMandantNrX";
            this.edtMandantNrX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMandantNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantNrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantNrX.Properties.Appearance.Options.UseFont = true;
            this.edtMandantNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandantNrX.Properties.Name = "editMandantNr.Properties";
            this.edtMandantNrX.Properties.ReadOnly = true;
            this.edtMandantNrX.Size = new System.Drawing.Size(70, 24);
            this.edtMandantNrX.TabIndex = 283;
            //
            // lblStandardKontenplan
            //
            this.lblStandardKontenplan.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblStandardKontenplan.Location = new System.Drawing.Point(10, 150);
            this.lblStandardKontenplan.Name = "lblStandardKontenplan";
            this.lblStandardKontenplan.Size = new System.Drawing.Size(159, 16);
            this.lblStandardKontenplan.TabIndex = 288;
            this.lblStandardKontenplan.Text = "Standard-Kontenplan";
            this.lblStandardKontenplan.UseCompatibleTextRendering = true;
            //
            // lblKontoNrName
            //
            this.lblKontoNrName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKontoNrName.Location = new System.Drawing.Point(10, 510);
            this.lblKontoNrName.Name = "lblKontoNrName";
            this.lblKontoNrName.Size = new System.Drawing.Size(86, 24);
            this.lblKontoNrName.TabIndex = 290;
            this.lblKontoNrName.Text = "Konto-Nr/Name";
            this.lblKontoNrName.UseCompatibleTextRendering = true;
            //
            // lblKbZahlungsKonto
            //
            this.lblKbZahlungsKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKbZahlungsKonto.Location = new System.Drawing.Point(10, 600);
            this.lblKbZahlungsKonto.Name = "lblKbZahlungsKonto";
            this.lblKbZahlungsKonto.Size = new System.Drawing.Size(80, 24);
            this.lblKbZahlungsKonto.TabIndex = 292;
            this.lblKbZahlungsKonto.Text = "Zahlungskonto";
            this.lblKbZahlungsKonto.UseCompatibleTextRendering = true;
            //
            // lblVorsaldo
            //
            this.lblVorsaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVorsaldo.Location = new System.Drawing.Point(10, 570);
            this.lblVorsaldo.Name = "lblVorsaldo";
            this.lblVorsaldo.Size = new System.Drawing.Size(69, 24);
            this.lblVorsaldo.TabIndex = 292;
            this.lblVorsaldo.Text = "Vorsaldo";
            this.lblVorsaldo.UseCompatibleTextRendering = true;
            //
            // lblKbKontoklasseCode
            //
            this.lblKbKontoklasseCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKbKontoklasseCode.Location = new System.Drawing.Point(10, 540);
            this.lblKbKontoklasseCode.Name = "lblKbKontoklasseCode";
            this.lblKbKontoklasseCode.Size = new System.Drawing.Size(80, 24);
            this.lblKbKontoklasseCode.TabIndex = 294;
            this.lblKbKontoklasseCode.Text = "Bilanz/Erfolg";
            this.lblKbKontoklasseCode.UseCompatibleTextRendering = true;
            //
            // btnRight
            //
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.IconID = 13;
            this.btnRight.Location = new System.Drawing.Point(806, 239);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(28, 24);
            this.btnRight.TabIndex = 307;
            this.btnRight.UseCompatibleTextRendering = true;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnLeftRight_Click);
            //
            // btnLeft
            //
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.IconID = 11;
            this.btnLeft.Location = new System.Drawing.Point(806, 269);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(28, 24);
            this.btnLeft.TabIndex = 308;
            this.btnLeft.UseCompatibleTextRendering = true;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeftRight_Click);
            //
            // btnUp
            //
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(806, 179);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 309;
            this.btnUp.UseCompatibleTextRendering = true;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUpDown_Click);
            //
            // btnDown
            //
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(806, 209);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 310;
            this.btnDown.UseCompatibleTextRendering = true;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnUpDown_Click);
            //
            // btnExpand
            //
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(806, 317);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(28, 24);
            this.btnExpand.TabIndex = 311;
            this.btnExpand.UseCompatibleTextRendering = true;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            //
            // btnCollapse
            //
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(806, 347);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(28, 24);
            this.btnCollapse.TabIndex = 312;
            this.btnCollapse.UseCompatibleTextRendering = true;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            //
            // edtZahlungsKontoDetails
            //
            this.edtZahlungsKontoDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZahlungsKontoDetails.DataMember = "Zahlungskonto";
            this.edtZahlungsKontoDetails.DataSource = this.qryKbKonto;
            this.edtZahlungsKontoDetails.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZahlungsKontoDetails.Location = new System.Drawing.Point(229, 600);
            this.edtZahlungsKontoDetails.Name = "edtZahlungsKontoDetails";
            this.edtZahlungsKontoDetails.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZahlungsKontoDetails.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsKontoDetails.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsKontoDetails.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsKontoDetails.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsKontoDetails.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsKontoDetails.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZahlungsKontoDetails.Properties.ReadOnly = true;
            this.edtZahlungsKontoDetails.Size = new System.Drawing.Size(219, 24);
            this.edtZahlungsKontoDetails.TabIndex = 314;
            //
            // CtlKbKonto
            //
            this.ActiveSQLQuery = this.qryKbKonto;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(830, 610);
            this.Controls.Add(this.edtZahlungsKontoDetails);
            this.Controls.Add(this.btnCollapse);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.lblKbKontoklasseCode);
            this.Controls.Add(this.lblVorsaldo);
            this.Controls.Add(this.lblKbZahlungsKonto);
            this.Controls.Add(this.lblKontoNrName);
            this.Controls.Add(this.lblStandardKontenplan);
            this.Controls.Add(this.edtMandantNrX);
            this.Controls.Add(this.lblMandant);
            this.Controls.Add(this.edtKontogruppe);
            this.Controls.Add(this.edtSaldovortrag);
            this.Controls.Add(this.chkKontoArtCodes);
            this.Controls.Add(this.edtKbZahlungsKonto);
            this.Controls.Add(this.edtVorsaldo);
            this.Controls.Add(this.edtKbKontoklasseCode);
            this.Controls.Add(this.edtKontoName);
            this.Controls.Add(this.edtKontoNr);
            this.Controls.Add(this.treKbKonto);
            this.Controls.Add(this.grdPeriode);
            this.Controls.Add(this.edtMandantX);
            this.Name = "CtlKbKonto";
            this.Size = new System.Drawing.Size(842, 728);
            this.Load += new System.EventHandler(this.CtlKbKonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treKbKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTreeItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbKontoklasseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbKontoklasseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorsaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungsKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontoArtCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontogruppe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandardKontenplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbZahlungsKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorsaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbKontoklasseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsKontoDetails.Properties)).EndInit();
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

        #region Private Properties

        private Int32 KbMandantID
        {
            get { return kbMandantID; }
            set
            {
                System.Diagnostics.Debug.WriteLine("kbMandantID = " + value.ToString());
                kbMandantID = value;
            }
        }

        #endregion

        #region Public Methods

        public override bool OnAddData()
        {
            // avoid crash in case of too fast user
            if (this.treKbKonto.DataSource == null)
            {
                throw new KissCancelException();
            }

            // create a new row and imediately save it to database because of problems with tree
            bool result = base.OnAddData() && this.qryKbKonto.Post(true);

            // refresh controls and select last inserted row in tree
            if (result)
            {
                this.qryKbKonto_PositionChanged(null, null);
                this.RefreshTree();
                this.treKbKonto.FocusedNode = this.treKbKonto.FindNodeByKeyID((int)DB.DBUtil.ExecuteScalarSQL("SELECT MAX(KbKontoID) FROM KbKonto"));
            }

            this.RefreshEnabledStates();

            return result;
        }

        public override bool OnDeleteData()
        {
            bool result = false;
            if (this.HasChildren((int)qryKbKonto["KbKontoID"]))
            {
                if (KissMsg.ShowQuestion("CtlKbKonto", "DeleteSubTreeItems", "Soll die Kontogruppe samt Unterkonten gelöscht werden?"))
                {
                    Session.BeginTransaction();
                    try
                    {
                        // Recursively delete the whole Konto-Tree below the selected item
                        DeleteKbKonto((int)qryKbKonto["KbKontoID"], (string)qryKbKonto["KontoNr"]);
                        Session.Commit();
                        result = true;
                    }
                    catch (KissCancelException ex)
                    {
                        Session.Rollback();
                        KissMsg.ShowInfo(ex.Message);
                        result = false;
                    }
                    catch (Exception ex)
                    {
                        Session.Rollback();
                        throw ex;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // First check if the selected Konto is not used already in a KbBuchung (Soll or Haben)
                string message = "";
                if (!CheckIfKontoCanBeDeleted((int)qryKbKonto["KbKontoID"], (string)qryKbKonto["KontoNr"], out message))
                {
                    // The Konto is already in use
                    KissMsg.ShowInfo(message);
                    return false;
                }

                result = base.OnDeleteData();
            }

            this.treKbKonto.SaveState();
            this.RefreshTree();
            if (this.treKbKonto.Nodes.Count > 0)
            {
                this.treKbKonto.FocusedNode = this.treKbKonto.Nodes[0];
            }

            return result;
        }

        public override void OnMoveFirst()
        {
            return;
        }

        public override void OnMoveLast()
        {
            return;
        }

        public override void OnMoveNext()
        {
            return;
        }

        public override void OnMovePrevious()
        {
            return;
        }

        private bool CheckIfKontoCanBeDeleted(int kbKontoID, string kontoNr, out string message)
        {
            // Check if there are any Buchungen already existing for this Konto
            SqlQuery sql = DBUtil.OpenSQL(@"
                        -- Alle Buchungen der Periode mit dieser Kontonummer durchsuchen
                        SELECT KON.KbKontoID FROM KbKonto KON
                            INNER JOIN KbBuchung BUC ON (BUC.SollKtoNr = KON.KontoNr OR BUC.HabenKtoNr = KON.KontoNr) AND BUC.KbPeriodeID = KON.KbPeriodeID
                        WHERE KON.KbKontoID = {0}

                        UNION

                        -- Alle Kostenarten der Periode mit dieser Kontonummer durchsuchen
                        SELECT KON.KbKontoID FROM KbKonto KON
                            INNER JOIN KbBuchung BUC ON BUC.KbPeriodeID = KON.KbPeriodeID
                            INNER JOIN KbBuchungKostenart KOA ON KOA.KbBuchungID = BUC.KbBuchungID AND KOA.KontoNr = KON.KontoNr
                        WHERE KON.KbKontoID = {0}", kbKontoID);

            if (sql.Count != 0)
            {
                message = string.Format("Das Konto {0} kann nicht gelöscht werden, da bereits Buchungen für dieses Konto existieren.", kontoNr);
                return false;
            }

            // Check if there are any BelegKreise defined for this Konto
            sql = DBUtil.OpenSQL(@"
                        SELECT KbBelegKreisID FROM KbBelegKreis BKR
                         INNER JOIN KbKonto KON ON KON.KontoNr = BKR.KontoNr AND KON.KbPeriodeID = BKR.KbPeriodeID
                        WHERE KON.KbKontoID = {0}", kbKontoID);

            if (sql.Count != 0)
            {
                message = string.Format("Das Konto {0} kann nicht gelöscht werden, da noch ein Belegkreis für dieses Konto existiert.", kontoNr);
                return false;
            }

            message = "";
            return true;
        }

        #endregion

        #region Private Methods

        private void btnCollapse_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("btnCollapse.Click");
            treKbKonto.CollapseAll();
        }

        private void btnExpand_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("btn.Expand.Click");
            treKbKonto.ExpandAll();
        }

        private void btnLeftRight_Click(object sender, System.EventArgs e)
        {
            if (qryKbKonto.Count <= 1) return;
            if (!qryKbKonto.Post()) return;

            int newgruppeKontoID = -1;

            if (sender == this.btnLeft)
            {
                object res = DBUtil.ExecuteScalarSQL(@"SELECT GruppeKontoID
                                                        FROM dbo.KbKonto KTO
                                                        WHERE KTO.KbKontoID = {0}", this.qryKbKonto.Row["GruppeKontoID"]);

                // check if parent is root, we cannot move higher than one level below root
                if (DBUtil.IsEmpty(res))
                {
                    return;
                }
                newgruppeKontoID = Convert.ToInt32(res);
            }
            else if (sender == this.btnRight)
            {
                int previousKbKontoID = this.GetKbKontoIDOfPreviousNode((int)this.qryKbKonto.Row["KbKontoID"], this.qryKbKonto.Row["GruppeKontoID"]);

                // check if item can be child of previous node (above current node)
                if (!(previousKbKontoID > 0 && this.qryKbKonto.Row["GruppeKontoID"] != System.DBNull.Value && previousKbKontoID != (int)this.qryKbKonto.Row["GruppeKontoID"]))
                {
                    return;
                }
                newgruppeKontoID = previousKbKontoID;
            }
            else
            {
                return;
            }

            /*
            //validate
            if( newgruppeKontoID < 1 )
            {
                return;
            }
            */

            //request max SortKey for new parent
            SqlQuery qry = DBUtil.OpenSQL(@"SELECT (ISNULL( MAX(SortKey), -1) + 1) AS NextSortKey
                                             FROM dbo.KbKonto
                                             WHERE GruppeKontoID={0}", newgruppeKontoID);

            // update current dataset
            DBUtil.ExecSQL("UPDATE KbKonto SET GruppeKontoID={0}, SortKey={1} WHERE KbKontoID={2}",
                newgruppeKontoID, qry.Row["NextSortKey"], this.qryKbKonto.Row["KbKontoID"]);

            this.FillDataSource(this.qryKbKonto);
            this.RefreshTree();
        }

        private void btnUpDown_Click(object sender, System.EventArgs e)
        {
            if (sender != this.btnUp && sender != this.btnDown)
            {
                return;
            }

            this.treKbKonto.SaveState();
            btnUp.Enabled = false;
            btnDown.Enabled = false;

            if (qryKbKonto.Count <= 1) return;
            if (!qryKbKonto.Post()) return;

            SqlQuery qry;
            if (sender == btnUp)
            {
                // Vorgänger bestimmen
                qry = DBUtil.OpenSQL(@"SELECT TOP 1 *
                                        FROM dbo.KbKonto
                                        WHERE IsNull(GruppeKontoID, 0) = IsNull({0}, 0) AND SortKey < {1}
                                        ORDER BY SortKey DESC", qryKbKonto["GruppeKontoID"], qryKbKonto["SortKey"]);
            }
            else
            {
                // Nachfolger bestimmen
                qry = DBUtil.OpenSQL(@"SELECT TOP 1 *
                                        FROM dbo.KbKonto
                                        WHERE IsNull(GruppeKontoID, 0) = IsNull({0}, 0) AND SortKey > {1}
                                        ORDER BY SortKey ASC", qryKbKonto["GruppeKontoID"], qryKbKonto["SortKey"]);
            }

            if (qry.Count == 0)
            {
                this.RefreshEnabledStates();
                return;
            }

            // Position tauschen
            DBUtil.ExecSQL("UPDATE KbKonto SET SortKey = {0} WHERE KbKontoID = {1}", qry["SortKey"], qryKbKonto["KbKontoID"]);
            DBUtil.ExecSQL("UPDATE KbKonto SET SortKey = {0} WHERE KbKontoID = {1}", qryKbKonto["SortKey"], qry["KbKontoID"]);

            this.FillDataSource(this.qryKbKonto);
            this.RefreshTree();
        }

        private void CtlKbKonto_Load(object sender, System.EventArgs e)
        {
            treKbKonto.ExpandAll();
        }

        /// <summary>
        /// Delete KbKonto recursively
        /// </summary>
        /// <param name="KbKontoID">ID of KbKonto to delete (root)</param>
        private void DeleteKbKonto(int kbKontoID, string kontoNr)
        {
            string message = "";

            // Before we delete the Konto, check if there are dependend elements
            if (!CheckIfKontoCanBeDeleted(kbKontoID, kontoNr, out message))
            {
                // Konto is already in use
                throw new KissCancelException(message);
            }

            // check if this konto item has any children
            int countChildren = (int)DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*) FROM dbo.KbKonto WHERE GruppeKontoID={0}", kbKontoID);

            if (countChildren > 0)
            {
                // has children, get all children
                SqlQuery qry = DBUtil.OpenSQL(@"SELECT KbKontoID, KontoNr
                                                FROM dbo.KbKonto
                                                WHERE GruppeKontoID={0}", kbKontoID);

                // loop through rows and do recursion
                foreach (System.Data.DataRow row in qry.DataTable.Rows)
                {
                    DeleteKbKonto((int)row["KbKontoID"], (string)row["KontoNr"]);
                }
            }

            // delete current KbKonto
            DBUtil.ExecSQL(@"DELETE FROM dbo.KbKonto WHERE KbKontoID = {0}", kbKontoID);
        }

        private void editMandantX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("editMandantX.userModified");

            KissLookupDialog dlg = new KissLookupDialog();

            if (!DBUtil.IsEmpty(edtMandantX.EditValue) && dlg.SearchData(@"
                SELECT DISTINCT
                  Mandant = dbo.fnGetMLTextByDefault(MAN.MandantTID, {1}, MAN.Mandant),
                  KbMandantID
                FROM dbo.KbMandant MAN
                WHERE Mandant LIKE {0} + '%'",
                edtMandantX.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%"),
                e.ButtonClicked,
                Session.User.LanguageCode))
            {
                if (DBUtil.IsEmpty(dlg["KbMandantID"]))
                    KbMandantID = 0;
                else
                    KbMandantID = (int)dlg["KbMandantID"];

                edtMandantNrX.Text = dlg["KbMandantID"].ToString();
                edtMandantX.EditValue = dlg["Mandant"].ToString();
            }
            else if (dlg.DialogResult != DialogResult.OK)
            {
                return;
            }
            else
            {
                edtMandantNrX.EditValue = DBNull.Value;
                edtMandantX.EditValue = DBNull.Value;
                KbMandantID = 0;
            }

            ShowPerioden();
            this.FillDataSource(this.qryKbKonto);
            this.FillDataSource(this.qryTreeItems);
        }

        private void edtZahlungsKonto_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("qryKbKonto.userModified");

            String SearchString = edtKbZahlungsKonto.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    System.Diagnostics.Debug.WriteLine("e.ButtonClicked == true");
                    SearchString = "%";
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("e.ButtonClicked == false");
                    //edtZahlungsKonto.Text = String.Empty;
                    //edtZahlungsKonto.EditValue = null;
                    //edtZahlungsKonto.LookupID = null;
                    qryKbKonto["KbZahlungsKontoID"] = null;
                    qryKbKonto["KbZahlungsKonto"] = null;
                    qryKbKonto["Zahlungskonto"] = String.Empty;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"Select KbZahlungsKontoID, Name, KontoNr from KbZahlungsKonto where KontoNr like '%' + {0} + '%' ",
            SearchString,
            e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKbKonto["KbZahlungsKontoID"] = dlg["KbZahlungsKontoID"];
                qryKbKonto["KbZahlungsKonto"] = dlg["KontoNr"];
                qryKbKonto["Zahlungskonto"] = dlg["Name"] + ", " + dlg["KontoNr"];

                //edtZahlungsKonto.EditValue = dlg["KontoNr"];
                //edtZahlungsKonto.LookupID =  dlg["KbZahlungsKontoID"];
                //edtZahlungsKontoDetails.Text = dlg["Name"] + ", " + dlg["KontoNr"];
            }
        }

        /// <summary>
        /// Fill datasource with values from database
        /// </summary>
        private void FillDataSource(SqlQuery qry)
        {
            if (qry == null)
            {
                return;
            }

            qry.Fill(@"SELECT
                         KontoGruppe		= CONVERT(bit, CASE WHEN EXISTS(SELECT 1 FROM dbo.KbKonto WHERE GruppeKontoID = KTO.KbKontoID) THEN 1 ELSE 0 END),
                         KbKontoID          = KTO.KbKontoID,
                         KbPeriodeID        = KTO.KbPeriodeID,
                         GruppeKontoID      = KTO.GruppeKontoID,
                         Kontogruppe        = KTO.Kontogruppe,
                         KbKontoklasseCode  = KTO.KbKontoklasseCode,
                         KbKontoartCodes    = KTO.KbKontoartCodes,
                         KontoNr            = KTO.KontoNr,
                         KontoName          = KTO.KontoName,
                         Vorsaldo           = KTO.Vorsaldo,
                         SaldoGruppeName    = KTO.SaldoGruppeName,
                         Saldovortrag       = KTO.Saldovortrag,
                         SortKey            = KTO.SortKey,
                         KbZahlungskontoID  = KTO.KbZahlungskontoID,
                         Konto			    = KTO.KontoNr + ' ' + KTO.Kontoname,
                         KbZahlungskonto    = KBZ.KontoNr,
                         Zahlungskonto	    = KBZ.Name+ ' ' + KBZ.KontoNr,
                         VorsaldoText	    = CASE WHEN KTO.KontoGruppe = 0 AND KTO.KbKontoKlasseCode = 1
                                                   THEN convert(varchar,Vorsaldo,1)
                                              END,
                         IconIndex		    = CASE WHEN Kontogruppe = 1 THEN 1 ELSE 0 END,
                         BE				    = BE.Shorttext,
                         --EV 			    = 'TODO E/V',--EV.Shorttext,
                         KontoArt 		    = dbo.fnLOVTextListe('KbKontoart', KTO.KbKontoArtCodes)
                       FROM dbo.KbKonto                 KTO
                         LEFT  JOIN dbo.XLOVCode        BE  ON BE.LOVName = 'KbKontoKlasse'
                                                           AND BE.Code = KTO.KbKontoKlasseCode
                         LEFT  JOIN dbo.KbZahlungskonto KBZ ON KBZ.KbZahlungskontoID = KTO.KbZahlungskontoID
                       WHERE (isNull({0}, 0) = 0 and KTO.KbPeriodeID is null) OR KTO.KbPeriodeID = {0}
                       ORDER BY KTO.GruppeKontoID, KTO.SortKey, KTO.KbKontoID", qryPeriodeX["KbPeriodeID"]);

            if (qry == qryKbKonto || qry == qryTreeItems)
            {
                treKbKonto.ExpandAll();
            }
        }

        private int GetAnzahlKontenByKontoArtCode(int kbPeriodeID, int? kbKontoID, string kontoArtCode)
        {
            int rowcount = (int)DBUtil.ExecuteScalarSQL(
                        @"SELECT COUNT(*)
                          FROM dbo.KbKonto KTO
                          WHERE KTO.KbPeriodeID = {0}
                            AND ',' + KTO.KbKontoartCodes + ',' LIKE '%,' + {2} + ',%'
                            AND KTO.KbKontoID <> isNull({1}, -1)",
                        kbPeriodeID,
                        kbKontoID,
                        kontoArtCode);
            return rowcount;
        }

        /// <summary>
        /// Get id of previous node (the one above current node)
        /// </summary>
        /// <param name="KbKontoID">KbKontoID of current node</param>
        /// <param name="parentItemID">GruppeKontoID of current node</param>
        /// <returns>KbKontoID of previous node if we have any; GruppeKontoID if we are the first node of parent; -1 if node has no previous node</returns>
        private int GetKbKontoIDOfPreviousNode(int kbKontoID, object parentItemID)
        {
            if (kbKontoID < 1 || DBUtil.IsEmpty(parentItemID))
            {
                // invalid or no previous node
                return -1;
            }

            SqlQuery qry = new SqlQuery();
            this.FillDataSource(qry);
            if (!qry.Find(string.Format("KbKontoID = {0}", kbKontoID)))
            {
                // node not found
                return -1;
            }

            // goto previous node
            qry.Previous();

            // validate
            if ((int)qry.Row["KbKontoID"] == kbKontoID)
            {
                // current node is the first --> root or is system KbKonto item (cannot have children due to its functionality)
                return -1;
            }
            if (qry.Row["GruppeKontoID"] == System.DBNull.Value || (int)qry.Row["GruppeKontoID"] != (int)parentItemID || (int)qry.Row["KbKontoID"] == (int)parentItemID)
            {
                // current node is the first of its parent node
                return (int)parentItemID;
            }

            //parent of current node is on same level
            return (int)qry.Row["KbKontoID"];
        }

        /// <summary>
        /// Check if KbKonto item has children
        /// </summary>
        /// <param name="KbKontoID">KbKontoID in KbKonto</param>
        /// <returns>True if item has children, false if no sub items</returns>
        private new bool HasChildren(int kbKontoID)
        {
            return !DBUtil.IsEmpty(DBUtil.ExecuteScalarSQL(@"SELECT KbKontoID
                                                             FROM dbo.KbKonto KTO
                                                             WHERE KTO.GruppeKontoID = {0}", kbKontoID));
        }

        /// <summary>
        /// Check if actually changing position in query
        /// </summary>
        /// <returns>True if is currently changing position in query, false if not changing position</returns>
        private Boolean IsChangingPosition()
        {
            // check if query is changing row
            return (this.lastSelectedPosition != this.qryKbKonto.Position || this.treKbKonto.FocusedNode == null);
        }

        /// <summary>
        /// Check if KbKonto has max or min sortkey
        /// </summary>
        /// <param name="compareMinimum">True if comparing for minimum, false if compareing for maximum</param>
        /// <param name="parentItemID">Current gruppeKontoID of KbKonto</param>
        /// <param name="currentSortKey">Current SortKey of KbKonto</param>
        /// <returns>True if KbKonto is min/max, false if KbKontoitem is not min/max</returns>
        private bool IsMinMaxSortKey(bool compareMinimum, int parentItemID, object currentSortKey)
        {
            // validate
            if (parentItemID < 1 || DBUtil.IsEmpty(currentSortKey) || !Utils.IsNatural(currentSortKey.ToString()))
            {
                return false;
            }

            int minMaxSortKey;

            // get min/max id
            if (compareMinimum)
            {
                minMaxSortKey = (int)DBUtil.ExecuteScalarSQL(@"SELECT ISNULL(MIN(SortKey), -1)
                                                               FROM dbo.KbKonto WITH (READUNCOMMITTED)
                                                               WHERE IsNull(GruppeKontoID, 0) = ISNULL({0}, 0)",
                                                             parentItemID);
            }
            else
            {
                minMaxSortKey = (int)DBUtil.ExecuteScalarSQL(@"SELECT ISNULL(MAX(SortKey), -1)
                                                               FROM dbo.KbKonto WITH (READUNCOMMITTED)
                                                               WHERE IsNull(GruppeKontoID, 0) = ISNULL({0}, 0)",
                                                             parentItemID);
            }

            // compare
            return Convert.ToInt32(currentSortKey) == minMaxSortKey;
        }

        private bool IstPeriodeAktiv()
        {
            if (DBUtil.IsEmpty(qryPeriodeX["KbPeriodeID"])) return false;

            //Periodenstatus könnte geändert haben: Deshalb nochmals prüfen ob Periode aktiv
            int status = 0;
            try
            {
                status = (int)DBUtil.ExecuteScalarSQLThrowingException(
                        @"SELECT PeriodeStatusCode FROM dbo.KbPeriode WHERE KbPeriodeID = {0}",
                        qryPeriodeX["KbPeriodeID"]);
            }
            catch
            {
                status = 0;
            }

            return status == 1;
        }

        private void qryKbKonto_AfterInsert(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("qryKbKonto.AfterInsert");

            // apply values to new row
            this.qryKbKonto.Row["GruppeKontoID"] = this.gruppeKontoID;
            this.qryKbKonto.Row["Kontogruppe"] = 0;
            if (qryPeriodeX.Row != null && !DBUtil.IsEmpty(qryPeriodeX.Row["KbPeriodeID"]))
                this.qryKbKonto.Row["KbPeriodeID"] = qryPeriodeX.Row["KbPeriodeID"];
            this.qryKbKonto.Row["SortKey"] = this.sortKey;
            this.qryKbKonto.Row["KontoName"] = KissMsg.GetMLMessage("CtlKbKonto", "NewKontoItem", "Neues Konto");
            this.qryKbKonto.Row["KontoNr"] = KissMsg.GetMLMessage("CtlKbKonto", "NewKontoNrItem", "0");
            this.qryKbKonto.Row["Vorsaldo"] = KissMsg.GetMLMessage("CtlKbKonto", "NewKontoVorsaldoItem", "0");
            this.qryKbKonto.RowModified = true;
            // reset properties
            this.gruppeKontoID = -1;
            this.sortKey = -1;

            // handle controls
            this.RefreshEnabledStates();
        }

        private void qryKbKonto_BeforeInsert(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("qryKbKonto.BeforeInsert");

            // get parent id from tree and calc next sortkey
            if (this.treKbKonto.FocusedNode != null)
            {
                //	this.treKbKonto.SaveState();
                this.gruppeKontoID = (int)this.treKbKonto.FocusedNode.GetValue("KbKontoID");
            }
            else
            {
                this.gruppeKontoID = 0;
            }
            this.sortKey = (int)DBUtil.ExecuteScalarSQL(@"SELECT isNull(MAX(SortKey)+1,0)
                                                           FROM KbKonto
                                                           WHERE GruppeKontoID = {0}", this.gruppeKontoID);

            if (this.gruppeKontoID < 0 || this.sortKey < 0)
            {
                throw new KissErrorException(KissMsg.GetMLMessage("CtlKbKonto", "InvalidParentIDOrSortKeyInsert", "Ungültiger Wert für gruppeKontoID='{0}' oder SortKey='{1}', Datensatz kann nicht erstellt werden.", KissMsgCode.MsgError, this.gruppeKontoID, this.sortKey));
            }
        }

        private void qryKbKonto_BeforePost(object sender, System.EventArgs e)
        {
            this.ValidateInputControls();
        }

        private void qryKbKonto_PositionChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.qryKbKonto.EnableBoundFields(this.IstPeriodeAktiv());
                this.RefreshEnabledStates();
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
            }
            finally
            {
                // store new last selected position in order to check if currently position changing
                this.lastSelectedPosition = this.qryKbKonto.Position;
            }

            chkKontoArtCodes.EditMode = EditModeType.Normal;
            String KontoArtCodes = qryKbKonto["KbKontoArtCodes"].ToString();

            if (buchungExists && (KontoArtCodes.Contains("20") || KontoArtCodes.Contains("30")))
            {
                chkKontoArtCodes.EditMode = EditModeType.ReadOnly;
            }
        }

        private void qryKbKonto_PostCompleted(object sender, System.EventArgs e)
        {
            this.RefreshEnabledStates();
            this.RefreshTree();
        }

        private void qryPeriodeX_PositionChanged(object sender, System.EventArgs e)
        {
            this.FillDataSource(this.qryKbKonto);
            this.FillDataSource(this.qryTreeItems);

            if (this.qryKbKonto.Count == 0)
            {
                this.SetStandardKontenplan(qryPeriodeX.Row["KbPeriodeID"]);
            }

            //Check ob bereits Buchungen existieren
            int buchungen;

            buchungen = (int)DBUtil.ExecuteScalarSQL(
                            " SELECT COUNT(KbBuchungID) FROM dbo.KbBuchung WHERE KbPeriodeID = {0}",
                            qryPeriodeX.Row["KbPeriodeID"]);

            if (!DBUtil.IsEmpty(buchungen) && buchungen > 0)
            {
                this.buchungExists = true;
            }

            bool pAktiv = this.IstPeriodeAktiv();
            this.qryKbKonto.EnableBoundFields(pAktiv);
            this.qryKbKonto.CanDelete = pAktiv;
            this.qryKbKonto.CanUpdate = pAktiv;
            this.qryKbKonto.CanInsert = pAktiv;
        }

        private void qryTreeItems_AfterFill(object sender, System.EventArgs e)
        {
            this.treKbKonto.DataSource = sender;
        }

        /// <summary>
        /// Handle editmode property for controls depending on data-state
        /// Handle CanDelete on query to ensure system and root items cannot be removed
        /// </summary>
        private void RefreshEnabledStates()
        {
            if (this.qryKbKonto.Row.RowState == DataRowState.Added)
            {
                this.btnUp.Enabled = false;
                this.btnDown.Enabled = false;
                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
            }
            else
            {
                // get current active row
                DataRow row = this.qryKbKonto.Row;

                // check if we have an id
                if (DBUtil.IsEmpty(row["KbKontoID"]))
                {
                    return;
                }

                // get values
                int kbKontoID = (int)row["KbKontoID"];
                int parentItemID = row["GruppeKontoID"] == System.DBNull.Value ? -1 : (int)row["GruppeKontoID"];

                // handle root-items, static-items, system-flag and navbar flags
                bool isRoot = row["GruppeKontoID"] == System.DBNull.Value;
                bool isTopLevelKbKonto = !isRoot && parentItemID == 1;

                // edit modes
                this.btnUp.Enabled = true;
                this.btnDown.Enabled = true;
                this.btnLeft.Enabled = true;
                this.btnRight.Enabled = true;

                this.btnLeft.Enabled = !(isRoot);
                this.btnRight.Enabled = !(isRoot);
                this.btnUp.Enabled = !(isRoot || qryKbKonto.Count <= 1 || IsMinMaxSortKey(true, parentItemID, row["SortKey"]));
                this.btnDown.Enabled = !(isRoot || qryKbKonto.Count <= 1 || IsMinMaxSortKey(false, parentItemID, row["SortKey"]));
            }
        }

        private void RefreshTree()
        {
            try
            {
                if (isRefreshingTree)
                {
                    return;
                }
                isRefreshingTree = true;
                this.treKbKonto.SaveState();
                this.treKbKonto.DataSource = null;
                this.FillDataSource(this.qryTreeItems);
                this.treKbKonto.RefreshDataSource();
                isRefreshingTree = false;
                this.treKbKonto.LoadState();
            }
            catch { }
            finally
            {
                isRefreshingTree = false;
            }
        }

        private void SetStandardKontenplan(object kbPeriodeID)
        {
            DBUtil.OpenSQL(@"
            SELECT PK = KbKontoID, Parent = GruppeKontoID, KeyNew = CONVERT(int, NULl)
            INTO #KbKonto
            FROM KbKonto
            WHERE KbPeriodeID IS NULL

            EXECUTE spXParentChildCopy '#KbKonto', 'KbKonto', 'KbKontoID', 'GruppeKontoID',
              'KbPeriodeID', {0}

            DROP TABLE #KbKonto", kbPeriodeID);
        }

        private void ShowPerioden()
        {
            grdPeriode.Visible = (KbMandantID != 0);
            lblStandardKontenplan.Visible = (KbMandantID == 0);

            qryPeriodeX.Fill(@"
                SELECT
                  PER.KbPeriodeID,
                  PER.PeriodeVon,
                  PER.PeriodeBis,
                  PER.PeriodeStatusCode,
                  MAN.KbMandantID,
                  Mandant = dbo.fnGetMLTextByDefault(MAN.MandantTID, {1}, MAN.Mandant)
                FROM dbo.KbPeriode         PER
                  INNER JOIN dbo.KbMandant MAN ON MAN.KbMandantID = PER.KbMandantID
                WHERE PER.KbMandantID = {0}
                ORDER BY PER.PeriodeVon",
                KbMandantID,
                Session.User.LanguageCode);

            edtMandantNrX.EditValue = qryPeriodeX["KbMandantID"];
            edtMandantX.EditValue = qryPeriodeX["Mandant"];

            if (qryPeriodeX.Count > 0)
                qryPeriodeX.Last();

            //grid lovLookup
            colStatus.ColumnEdit = grdPeriode.GetLOVLookUpEdit("KbPeriodeStatus");
            //	ShowKonten();
        }

        private void treKbKonto_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && !isRefreshingTree)
            {
                if (this.qryKbKonto.Post())
                {
                    // apply new selected node in query
                    this.qryKbKonto.Find(string.Format("KbKontoID = {0}", e.Node.GetValue("KbKontoID")));
                }
                else
                {
                    if (e.OldNode != null)
                    {
                        // post failed, go back to old selected node
                        isRefreshingTree = true;
                        this.treKbKonto.FocusedNode = e.OldNode;
                        isRefreshingTree = false;
                    }
                }
            }
        }

        /// <summary>
        /// Validate input controls and apply current (changed) value
        /// </summary>
        private void ValidateInputControls()
        {
            string kontoArtCodes = qryKbKonto["KbKontoArtCodes"].ToString();

            // Check noch kein Debitor-Konto
            if (kontoArtCodes != string.Empty && kontoArtCodes.Contains("20"))  //@@TODO Vorsicht!!! Contains!?!? --> 200?
            {
                int rowcount = GetAnzahlKontenByKontoArtCode(Utils.ConvertToInt(qryPeriodeX["KbPeriodeID"]), (int?)qryKbKonto["KbKontoID"], "20");
                if (!DBUtil.IsEmpty(rowcount) && rowcount > 0)
                {
                    KissMsg.ShowInfo("Speichern fehlgeschlagen, es existiert bereits ein Debitor Konto");
                    throw new KissCancelException();
                }
            }
            // Check noch kein Kreditor-Konto
            if (kontoArtCodes != string.Empty && kontoArtCodes.Contains("30")) //@@TODO Vorsicht!!! Contains!?!? --> 3000?
            {
                int rowcount = this.GetAnzahlKontenByKontoArtCode(Utils.ConvertToInt(qryPeriodeX["KbPeriodeID"]), (int?)qryKbKonto["KbKontoID"], "30");

                if (!DBUtil.IsEmpty(rowcount) && rowcount > 0)
                {
                    KissMsg.ShowInfo("Speichern fehlgeschlagen, es existiert bereits ein Kreditor Konto");
                    throw new KissCancelException();
                }
            }
            // Check noch kein Kassen-Konto #3913
            if (kontoArtCodes != string.Empty && kontoArtCodes.Contains("60")) //@@TODO Vorsicht!!! Contains!?!? --> 6000000?
            {
                int rowcount = this.GetAnzahlKontenByKontoArtCode(Utils.ConvertToInt(qryPeriodeX["KbPeriodeID"]), (int?)qryKbKonto["KbKontoID"], "60");

                if (!DBUtil.IsEmpty(rowcount) && rowcount > 0)
                {
                    KissMsg.ShowInfo("Speichern fehlgeschlagen, es existiert bereits ein Kasse Konto");
                    throw new KissCancelException();
                }
            }
        }

        #endregion
    }
}