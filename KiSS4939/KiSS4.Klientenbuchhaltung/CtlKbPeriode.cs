using System;
using System.Data;
using System.Windows.Forms;

using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public class CtlKbPeriode : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private const string CLASSNAME = "CtlKbPeriode";

        private KiSS4.Gui.KissButton btnAbschluss;
        private KiSS4.Gui.KissButton btnAktiv;
        private KiSS4.Gui.KissButton btnSaldiVortragen;
        private KiSS4.Gui.KissButton btnStandardSetzen;
        private KiSS4.Gui.KissButton btnVerbuchen;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colKbPeriodeID;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colMandantNr;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit editPeriodeBis;
        private KiSS4.Gui.KissDateEdit editPeriodeVon;
        private KiSS4.Gui.KissDateEdit edtDatumVerbuchen;
        private KiSS4.Gui.KissTextEdit edtMandant;
        private KiSS4.Gui.KissDateEdit edtPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtPeriodeVon;
        private KiSS4.Gui.KissGrid grdMandant;
        private KiSS4.Gui.KissGrid grdPeriode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMandant;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPeriode;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel labelDebug;
        private KiSS4.Gui.KissLabel labelDebugMandant;
        private KiSS4.Gui.KissLabel lblPeriodeBis;
        private KiSS4.Gui.KissLabel lblPerioden;
        private KiSS4.Gui.KissLabel lblPeriodeVon;
        private KiSS4.Gui.KissLabel lblVerbuchtBis;
        private KiSS4.DB.SqlQuery qryKbPeriode_User;
        private KiSS4.DB.SqlQuery qryMandant;
        private string qryMandant_SelectStatement = string.Empty;
        private KiSS4.DB.SqlQuery qryPeriode;
        private KiSS4.DB.SqlQuery qryRelevanteBuchungen;
        private DataRowState SaveRowState;

        #endregion

        #endregion

        #region Constructors

        public CtlKbPeriode()
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbPeriode));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdPeriode = new KiSS4.Gui.KissGrid();
            this.qryPeriode = new KiSS4.DB.SqlQuery(this.components);
            this.grvPeriode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKbPeriodeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdMandant = new KiSS4.Gui.KissGrid();
            this.qryMandant = new KiSS4.DB.SqlQuery(this.components);
            this.grvMandant = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMandantNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelDebugMandant = new KiSS4.Gui.KissLabel();
            this.edtMandant = new KiSS4.Gui.KissTextEdit();
            this.edtPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.edtPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.lblPeriodeVon = new KiSS4.Gui.KissLabel();
            this.lblPeriodeBis = new KiSS4.Gui.KissLabel();
            this.editPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.editPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.btnAktiv = new KiSS4.Gui.KissButton();
            this.btnAbschluss = new KiSS4.Gui.KissButton();
            this.btnSaldiVortragen = new KiSS4.Gui.KissButton();
            this.lblPerioden = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.btnVerbuchen = new KiSS4.Gui.KissButton();
            this.lblVerbuchtBis = new KiSS4.Gui.KissLabel();
            this.edtDatumVerbuchen = new KiSS4.Gui.KissDateEdit();
            this.labelDebug = new KiSS4.Gui.KissLabel();
            this.btnStandardSetzen = new KiSS4.Gui.KissButton();
            this.qryKbPeriode_User = new KiSS4.DB.SqlQuery(this.components);
            this.qryRelevanteBuchungen = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDebugMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerioden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerbuchtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVerbuchen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDebug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbPeriode_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelevanteBuchungen)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(812, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Size = new System.Drawing.Size(836, 223);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.labelDebugMandant);
            this.tpgListe.Controls.Add(this.grdMandant);
            this.tpgListe.Size = new System.Drawing.Size(824, 185);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblPeriodeBis);
            this.tpgSuchen.Controls.Add(this.lblPeriodeVon);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.edtPeriodeBis);
            this.tpgSuchen.Controls.Add(this.edtPeriodeVon);
            this.tpgSuchen.Controls.Add(this.edtMandant);
            this.tpgSuchen.Size = new System.Drawing.Size(824, 185);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtMandant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPeriodeVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPeriodeBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPeriodeVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPeriodeBis, 0);
            //
            // grdPeriode
            //
            this.grdPeriode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdPeriode.DataSource = this.qryPeriode;
            //
            //
            //
            this.grdPeriode.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdPeriode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPeriode.Location = new System.Drawing.Point(5, 248);
            this.grdPeriode.MainView = this.grvPeriode;
            this.grdPeriode.Name = "grdPeriode";
            this.grdPeriode.Size = new System.Drawing.Size(452, 287);
            this.grdPeriode.TabIndex = 0;
            this.grdPeriode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPeriode});
            this.grdPeriode.DoubleClick += new System.EventHandler(this.grdPeriode_DoubleClick);
            //
            // qryPeriode
            //
            this.qryPeriode.CanDelete = true;
            this.qryPeriode.CanInsert = true;
            this.qryPeriode.CanUpdate = true;
            this.qryPeriode.HostControl = this;
            this.qryPeriode.SelectStatement = "SELECT \r\n  KbPeriodeID, \r\n  KbMandantID, \r\n  PeriodeVon, \r\n  PeriodeBis, \r\n  Peri" +
    "odeStatusCode, \r\n  VerbuchtBis \r\nFROM dbo.KbPeriode\r\nWHERE KbMandantID = {0}\r\nOR" +
    "DER BY PeriodeVon";
            this.qryPeriode.TableName = "KbPeriode";
            this.qryPeriode.AfterInsert += new System.EventHandler(this.qryPeriode_AfterInsert);
            this.qryPeriode.AfterPost += new System.EventHandler(this.qryPeriode_AfterPost);
            this.qryPeriode.BeforeDelete += new System.EventHandler(this.qryPeriode_BeforeDelete);
            this.qryPeriode.BeforePost += new System.EventHandler(this.qryPeriode_BeforePost);
            this.qryPeriode.PositionChanged += new System.EventHandler(this.qryPeriode_PositionChanged);
            //
            // grvPeriode
            //
            this.grvPeriode.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPeriode.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.Empty.Options.UseBackColor = true;
            this.grvPeriode.Appearance.Empty.Options.UseFont = true;
            this.grvPeriode.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPeriode.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.EvenRow.Options.UseFont = true;
            this.grvPeriode.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriode.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPeriode.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPeriode.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPeriode.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPeriode.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriode.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPeriode.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPeriode.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPeriode.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriode.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPeriode.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriode.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPeriode.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriode.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.GroupRow.Options.UseFont = true;
            this.grvPeriode.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPeriode.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPeriode.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPeriode.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPeriode.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPeriode.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPeriode.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPeriode.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPeriode.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriode.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPeriode.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPeriode.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriode.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPeriode.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.OddRow.Options.UseFont = true;
            this.grvPeriode.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPeriode.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.Row.Options.UseBackColor = true;
            this.grvPeriode.Appearance.Row.Options.UseFont = true;
            this.grvPeriode.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPeriode.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPeriode.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPeriode.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPeriode.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriode.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPeriode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPeriode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKbPeriodeID,
            this.colVon,
            this.colBis,
            this.colStatus});
            this.grvPeriode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPeriode.GridControl = this.grdPeriode;
            this.grvPeriode.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvPeriode.Name = "grvPeriode";
            this.grvPeriode.OptionsBehavior.Editable = false;
            this.grvPeriode.OptionsCustomization.AllowFilter = false;
            this.grvPeriode.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPeriode.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPeriode.OptionsNavigation.UseTabKey = false;
            this.grvPeriode.OptionsView.ColumnAutoWidth = false;
            this.grvPeriode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPeriode.OptionsView.ShowGroupPanel = false;
            this.grvPeriode.OptionsView.ShowIndicator = false;
            this.grvPeriode.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView2_BeforeLeaveRow);
            //
            // colKbPeriodeID
            //
            this.colKbPeriodeID.Caption = "Periode-ID";
            this.colKbPeriodeID.FieldName = "KbPeriodeID";
            this.colKbPeriodeID.Name = "colKbPeriodeID";
            this.colKbPeriodeID.Visible = true;
            this.colKbPeriodeID.VisibleIndex = 0;
            this.colKbPeriodeID.Width = 70;
            //
            // colVon
            //
            this.colVon.Caption = "Periode Von";
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 1;
            this.colVon.Width = 94;
            //
            // colBis
            //
            this.colBis.Caption = "Periode Bis";
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 2;
            this.colBis.Width = 88;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "PeriodeStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            this.colStatus.Width = 101;
            //
            // grdMandant
            //
            this.grdMandant.DataSource = this.qryMandant;
            this.grdMandant.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdMandant.EmbeddedNavigator.Name = "gridMandant.EmbeddedNavigator";
            this.grdMandant.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMandant.Location = new System.Drawing.Point(0, 0);
            this.grdMandant.MainView = this.grvMandant;
            this.grdMandant.Name = "grdMandant";
            this.grdMandant.Size = new System.Drawing.Size(824, 185);
            this.grdMandant.TabIndex = 1;
            this.grdMandant.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMandant});
            //
            // qryMandant
            //
            this.qryMandant.HostControl = this;
            this.qryMandant.SelectStatement = resources.GetString("qryMandant.SelectStatement");
            this.qryMandant.TableName = "KbMandant";
            this.qryMandant.PositionChanged += new System.EventHandler(this.qryMandant_PositionChanged);
            //
            // grvMandant
            //
            this.grvMandant.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvMandant.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.Empty.Options.UseBackColor = true;
            this.grvMandant.Appearance.Empty.Options.UseFont = true;
            this.grvMandant.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvMandant.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvMandant.Appearance.EvenRow.Options.UseFont = true;
            this.grvMandant.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMandant.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvMandant.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMandant.Appearance.FocusedCell.Options.UseFont = true;
            this.grvMandant.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMandant.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMandant.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMandant.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMandant.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMandant.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMandant.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMandant.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMandant.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMandant.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMandant.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMandant.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMandant.Appearance.GroupRow.Options.UseFont = true;
            this.grvMandant.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMandant.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvMandant.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvMandant.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMandant.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMandant.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMandant.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMandant.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvMandant.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMandant.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMandant.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvMandant.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMandant.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvMandant.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMandant.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.OddRow.Options.UseFont = true;
            this.grvMandant.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvMandant.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.Row.Options.UseBackColor = true;
            this.grvMandant.Appearance.Row.Options.UseFont = true;
            this.grvMandant.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvMandant.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandant.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvMandant.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvMandant.Appearance.SelectedRow.Options.UseFont = true;
            this.grvMandant.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvMandant.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvMandant.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMandant.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvMandant.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMandantNr,
            this.colMandant});
            this.grvMandant.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMandant.GridControl = this.grdMandant;
            this.grvMandant.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvMandant.Name = "grvMandant";
            this.grvMandant.OptionsBehavior.Editable = false;
            this.grvMandant.OptionsCustomization.AllowFilter = false;
            this.grvMandant.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvMandant.OptionsNavigation.AutoFocusNewRow = true;
            this.grvMandant.OptionsNavigation.UseTabKey = false;
            this.grvMandant.OptionsView.ColumnAutoWidth = false;
            this.grvMandant.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMandant.OptionsView.ShowGroupPanel = false;
            this.grvMandant.OptionsView.ShowIndicator = false;
            //
            // colMandantNr
            //
            this.colMandantNr.Caption = "Mandant-ID";
            this.colMandantNr.FieldName = "KbMandantID";
            this.colMandantNr.Name = "colMandantNr";
            this.colMandantNr.Visible = true;
            this.colMandantNr.VisibleIndex = 0;
            //
            // colMandant
            //
            this.colMandant.Caption = "Mandant";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 1;
            this.colMandant.Width = 231;
            //
            // labelDebugMandant
            //
            this.labelDebugMandant.DataMember = "KbMandantID";
            this.labelDebugMandant.DataSource = this.qryMandant;
            this.labelDebugMandant.Location = new System.Drawing.Point(274, 120);
            this.labelDebugMandant.Name = "labelDebugMandant";
            this.labelDebugMandant.Size = new System.Drawing.Size(100, 23);
            this.labelDebugMandant.TabIndex = 2;
            this.labelDebugMandant.UseCompatibleTextRendering = true;
            this.labelDebugMandant.Visible = false;
            //
            // edtMandant
            //
            this.edtMandant.Location = new System.Drawing.Point(94, 55);
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandant.Properties.Name = "editMandantX.Properties";
            this.edtMandant.Size = new System.Drawing.Size(172, 24);
            this.edtMandant.TabIndex = 346;
            //
            // edtPeriodeVon
            //
            this.edtPeriodeVon.EditValue = null;
            this.edtPeriodeVon.Location = new System.Drawing.Point(94, 85);
            this.edtPeriodeVon.Name = "edtPeriodeVon";
            this.edtPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPeriodeVon.Properties.Name = "editPeriodeVonX.Properties";
            this.edtPeriodeVon.Properties.ShowToday = false;
            this.edtPeriodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtPeriodeVon.TabIndex = 349;
            //
            // edtPeriodeBis
            //
            this.edtPeriodeBis.EditValue = null;
            this.edtPeriodeBis.Location = new System.Drawing.Point(94, 115);
            this.edtPeriodeBis.Name = "edtPeriodeBis";
            this.edtPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPeriodeBis.Properties.Name = "editPeriodeBisX.Properties";
            this.edtPeriodeBis.Properties.ShowToday = false;
            this.edtPeriodeBis.Size = new System.Drawing.Size(100, 24);
            this.edtPeriodeBis.TabIndex = 350;
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(-1, 55);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(66, 24);
            this.kissLabel5.TabIndex = 352;
            this.kissLabel5.Text = "Mandant";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // lblPeriodeVon
            //
            this.lblPeriodeVon.Location = new System.Drawing.Point(0, 85);
            this.lblPeriodeVon.Name = "lblPeriodeVon";
            this.lblPeriodeVon.Size = new System.Drawing.Size(72, 24);
            this.lblPeriodeVon.TabIndex = 353;
            this.lblPeriodeVon.Text = "Periode von";
            this.lblPeriodeVon.UseCompatibleTextRendering = true;
            //
            // lblPeriodeBis
            //
            this.lblPeriodeBis.Location = new System.Drawing.Point(-1, 115);
            this.lblPeriodeBis.Name = "lblPeriodeBis";
            this.lblPeriodeBis.Size = new System.Drawing.Size(72, 24);
            this.lblPeriodeBis.TabIndex = 354;
            this.lblPeriodeBis.Text = "Periode bis";
            this.lblPeriodeBis.UseCompatibleTextRendering = true;
            //
            // editPeriodeVon
            //
            this.editPeriodeVon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.editPeriodeVon.DataMember = "PeriodeVon";
            this.editPeriodeVon.DataSource = this.qryPeriode;
            this.editPeriodeVon.EditValue = null;
            this.editPeriodeVon.Location = new System.Drawing.Point(548, 248);
            this.editPeriodeVon.Name = "editPeriodeVon";
            this.editPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.editPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.editPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.editPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editPeriodeVon.Properties.Name = "editPeriodeVon.Properties";
            this.editPeriodeVon.Properties.ShowToday = false;
            this.editPeriodeVon.Size = new System.Drawing.Size(95, 24);
            this.editPeriodeVon.TabIndex = 1;
            //
            // editPeriodeBis
            //
            this.editPeriodeBis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.editPeriodeBis.DataMember = "PeriodeBis";
            this.editPeriodeBis.DataSource = this.qryPeriode;
            this.editPeriodeBis.EditValue = null;
            this.editPeriodeBis.Location = new System.Drawing.Point(548, 278);
            this.editPeriodeBis.Name = "editPeriodeBis";
            this.editPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.editPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.editPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.editPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editPeriodeBis.Properties.Name = "editPeriodeBis.Properties";
            this.editPeriodeBis.Properties.ShowToday = false;
            this.editPeriodeBis.Size = new System.Drawing.Size(95, 24);
            this.editPeriodeBis.TabIndex = 2;
            //
            // btnAktiv
            //
            this.btnAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAktiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAktiv.Location = new System.Drawing.Point(463, 505);
            this.btnAktiv.Name = "btnAktiv";
            this.btnAktiv.Size = new System.Drawing.Size(110, 24);
            this.btnAktiv.TabIndex = 4;
            this.btnAktiv.Text = "Aktiv / Inaktiv";
            this.btnAktiv.UseCompatibleTextRendering = true;
            this.btnAktiv.UseVisualStyleBackColor = false;
            this.btnAktiv.Click += new System.EventHandler(this.btnAktiv_Click);
            //
            // btnAbschluss
            //
            this.btnAbschluss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbschluss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbschluss.Location = new System.Drawing.Point(592, 505);
            this.btnAbschluss.Name = "btnAbschluss";
            this.btnAbschluss.Size = new System.Drawing.Size(110, 24);
            this.btnAbschluss.TabIndex = 5;
            this.btnAbschluss.Text = "Abschluss";
            this.btnAbschluss.UseCompatibleTextRendering = true;
            this.btnAbschluss.UseVisualStyleBackColor = false;
            this.btnAbschluss.Click += new System.EventHandler(this.btnAbschluss_Click);
            //
            // btnSaldiVortragen
            //
            this.btnSaldiVortragen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaldiVortragen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaldiVortragen.Location = new System.Drawing.Point(717, 505);
            this.btnSaldiVortragen.Name = "btnSaldiVortragen";
            this.btnSaldiVortragen.Size = new System.Drawing.Size(110, 24);
            this.btnSaldiVortragen.TabIndex = 6;
            this.btnSaldiVortragen.Text = "Saldi vortragen";
            this.btnSaldiVortragen.UseCompatibleTextRendering = true;
            this.btnSaldiVortragen.UseVisualStyleBackColor = false;
            this.btnSaldiVortragen.Click += new System.EventHandler(this.btnSaldiVortragen_Click);
            //
            // lblPerioden
            //
            this.lblPerioden.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPerioden.Location = new System.Drawing.Point(5, 229);
            this.lblPerioden.Name = "lblPerioden";
            this.lblPerioden.Size = new System.Drawing.Size(80, 16);
            this.lblPerioden.TabIndex = 302;
            this.lblPerioden.Text = "Perioden";
            this.lblPerioden.UseCompatibleTextRendering = true;
            //
            // kissLabel4
            //
            this.kissLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel4.Location = new System.Drawing.Point(463, 248);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(75, 24);
            this.kissLabel4.TabIndex = 305;
            this.kissLabel4.Text = "Periode von";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // kissLabel6
            //
            this.kissLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel6.Location = new System.Drawing.Point(463, 278);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(65, 24);
            this.kissLabel6.TabIndex = 306;
            this.kissLabel6.Text = "Periode bis";
            this.kissLabel6.UseCompatibleTextRendering = true;
            //
            // kissLabel8
            //
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel8.DataMember = "KbPeriodeID";
            this.kissLabel8.DataSource = this.qryPeriode;
            this.kissLabel8.Location = new System.Drawing.Point(345, 278);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(100, 24);
            this.kissLabel8.TabIndex = 308;
            this.kissLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissLabel8.UseCompatibleTextRendering = true;
            this.kissLabel8.Visible = false;
            //
            // btnVerbuchen
            //
            this.btnVerbuchen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerbuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerbuchen.Location = new System.Drawing.Point(597, 433);
            this.btnVerbuchen.Name = "btnVerbuchen";
            this.btnVerbuchen.Size = new System.Drawing.Size(90, 24);
            this.btnVerbuchen.TabIndex = 309;
            this.btnVerbuchen.Text = "Verbuchen";
            this.btnVerbuchen.UseCompatibleTextRendering = true;
            this.btnVerbuchen.UseVisualStyleBackColor = true;
            this.btnVerbuchen.Click += new System.EventHandler(this.btnVerbuchen_Click);
            //
            // lblVerbuchtBis
            //
            this.lblVerbuchtBis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerbuchtBis.Location = new System.Drawing.Point(463, 406);
            this.lblVerbuchtBis.Name = "lblVerbuchtBis";
            this.lblVerbuchtBis.Size = new System.Drawing.Size(137, 24);
            this.lblVerbuchtBis.TabIndex = 310;
            this.lblVerbuchtBis.Text = "Definitiv verbuchen bis";
            this.lblVerbuchtBis.UseCompatibleTextRendering = true;
            //
            // edtDatumVerbuchen
            //
            this.edtDatumVerbuchen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVerbuchen.EditValue = null;
            this.edtDatumVerbuchen.Location = new System.Drawing.Point(463, 433);
            this.edtDatumVerbuchen.Name = "edtDatumVerbuchen";
            this.edtDatumVerbuchen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVerbuchen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVerbuchen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVerbuchen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVerbuchen.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVerbuchen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVerbuchen.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVerbuchen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumVerbuchen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVerbuchen.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumVerbuchen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVerbuchen.Properties.ShowToday = false;
            this.edtDatumVerbuchen.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVerbuchen.TabIndex = 311;
            //
            // labelDebug
            //
            this.labelDebug.Location = new System.Drawing.Point(463, 465);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(338, 24);
            this.labelDebug.TabIndex = 312;
            this.labelDebug.Text = "[labelDebug]";
            this.labelDebug.UseCompatibleTextRendering = true;
            this.labelDebug.Visible = false;
            //
            // btnStandardSetzen
            //
            this.btnStandardSetzen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStandardSetzen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStandardSetzen.Location = new System.Drawing.Point(463, 317);
            this.btnStandardSetzen.Name = "btnStandardSetzen";
            this.btnStandardSetzen.Size = new System.Drawing.Size(230, 24);
            this.btnStandardSetzen.TabIndex = 313;
            this.btnStandardSetzen.Text = "Periode als Standard setzen";
            this.btnStandardSetzen.UseCompatibleTextRendering = true;
            this.btnStandardSetzen.UseVisualStyleBackColor = false;
            this.btnStandardSetzen.Click += new System.EventHandler(this.btnStandardSetzen_Click);
            //
            // qryKbPeriode_User
            //
            this.qryKbPeriode_User.CanInsert = true;
            this.qryKbPeriode_User.CanUpdate = true;
            this.qryKbPeriode_User.HostControl = this;
            this.qryKbPeriode_User.SelectStatement = "SELECT KbPeriodeID,\r\n       UserID\r\nFROM KbPeriode_User\r\nWHERE UserID = {0}";
            this.qryKbPeriode_User.TableName = "KbPeriode_User";
            //
            // qryRelevanteBuchungen
            //
            this.qryRelevanteBuchungen.HostControl = this;
            //
            // CtlKbPeriode
            //
            this.ActiveSQLQuery = this.qryPeriode;
            this.Controls.Add(this.btnStandardSetzen);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.edtDatumVerbuchen);
            this.Controls.Add(this.lblVerbuchtBis);
            this.Controls.Add(this.btnVerbuchen);
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.kissLabel6);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.lblPerioden);
            this.Controls.Add(this.btnSaldiVortragen);
            this.Controls.Add(this.btnAbschluss);
            this.Controls.Add(this.btnAktiv);
            this.Controls.Add(this.editPeriodeBis);
            this.Controls.Add(this.editPeriodeVon);
            this.Controls.Add(this.grdPeriode);
            this.Name = "CtlKbPeriode";
            this.Size = new System.Drawing.Size(842, 550);
            this.Load += new System.EventHandler(this.CtlKbPeriode_Load);
            this.Controls.SetChildIndex(this.grdPeriode, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.editPeriodeVon, 0);
            this.Controls.SetChildIndex(this.editPeriodeBis, 0);
            this.Controls.SetChildIndex(this.btnAktiv, 0);
            this.Controls.SetChildIndex(this.btnAbschluss, 0);
            this.Controls.SetChildIndex(this.btnSaldiVortragen, 0);
            this.Controls.SetChildIndex(this.lblPerioden, 0);
            this.Controls.SetChildIndex(this.kissLabel4, 0);
            this.Controls.SetChildIndex(this.kissLabel6, 0);
            this.Controls.SetChildIndex(this.kissLabel8, 0);
            this.Controls.SetChildIndex(this.btnVerbuchen, 0);
            this.Controls.SetChildIndex(this.lblVerbuchtBis, 0);
            this.Controls.SetChildIndex(this.edtDatumVerbuchen, 0);
            this.Controls.SetChildIndex(this.labelDebug, 0);
            this.Controls.SetChildIndex(this.btnStandardSetzen, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDebugMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerioden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerbuchtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVerbuchen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDebug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbPeriode_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelevanteBuchungen)).EndInit();
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

        #region Properties

        private Int32 NumberOfBuchungen
        {
            get
            {
                return Utils.ConvertToInt((int)this.qryRelevanteBuchungen.Count);
            }
        }

        #endregion

        #region EventHandlers

        private void btnAbschluss_Click(object sender, System.EventArgs e)
        {
            // --- falls periode bereits abgeschlossen ist.
            if (((int)qryPeriode["PeriodeStatusCode"]) == 3)
            {
                //System.Diagnostics.Debug.WriteLine("Diese Periode ist bereits abgeschlossen");
                return;
            }

            SqlQuery qry;

            // --- gibt es überhaupt Buchungen in dieser Periode
            // 12.11.2008 nur relevante Buchungen berücksichtigen (solche die in der "Buchhaltung" sind --> dbo.fnGetRelevanteBuchungen(Periode)
            if (this.NumberOfBuchungen == 0)
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "PeriodeNichtAbgeschlossen",
                    "Periode kann nicht abgeschlossen werden, da noch keine Buchungen vorhanden sind");
                return;
            }

            // --- Ist BilanzSaldo ausgeglichen ?
            qry = DBUtil.OpenSQL(@"
            SELECT Saldo = SUM(Betrag)
            FROM (SELECT
                    Betrag = IsNull((SELECT SUM(Betrag)
                                     FROM dbo.fnKbGetRelevanteBuchungen({0}, NULL, NULL, 0, 0) REB1
                                     WHERE REB1.SollKtoNr = KTO.KontoNr), 0)
                            -IsNull((SELECT SUM(Betrag)
                                     FROM dbo.fnKbGetRelevanteBuchungen({0}, NULL, NULL, 0, 0) REB2
                                     WHERE REB2.HabenKtoNr = KTO.KontoNr), 0)
            FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
            WHERE KTO.KbPeriodeID = {0}) TMP",
                qryPeriode["KbPeriodeID"]);

            // --- falls die Bilanz ausgeglichen (d.h. Saldo = 0) ist, kann die Periode abgeschlossen
            //     werden. Anderenfalls wird der Saldo angezeigt und der Benutzer soll die notwendigen
            //     Buchungen vornehmen um die Bilanz auszugleichen.

            Decimal currentSaldo = Utils.ConvertToDecimal(qry["Saldo"]);

            if (currentSaldo != 0)
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "BilanzNichtAusgeglichen",
                    "Die Periode kann momentan nicht abgeschlossen werden, da die Bilanz nicht ausgeglichen ist. Der aktuelle Saldo beträgt: {0} Franken.",
                    0,
                    0,
                    currentSaldo.ToString("N2"));
                return;
            }

            Boolean closePeriode = KissMsg.ShowQuestion(
                "CtlKbPeriode",
                "PeriodeAbschliessen",
                "Soll diese Periode abgeschlossen werden? Dies kann nicht mehr rückgängig gemacht werden.");

            if (closePeriode && qryPeriode["KbPeriodeID"] is int)
            {
                // --- close period.
                qryPeriode["PeriodeStatusCode"] = 3;
                qryPeriode.Post();

                // --- Saldi automatisch vortragen
                this.SaldiVortragen((int)qryPeriode["KbPeriodeID"]);
            }
            else
            {
                // user aborted. Peride will not be closed.
            }
        }

        private void btnAktiv_Click(object sender, System.EventArgs e)
        {
            int currentStatus = ((int)qryPeriode["PeriodeStatusCode"]);

            switch (currentStatus)
            {
                case 1:
                    qryPeriode["PeriodeStatusCode"] = 2;
                    if (qryPeriode.Post() && qryPeriode["KbPeriodeID"] is int)
                    {
                        qryPeriode.EnableBoundFields(false);
                        // --- Saldi automatisch vortragen; NEIN! das soll nicht geschehen!
                        //this.SaldiVortragen((int)qryPeriode["KbPeriodeID"]);
                        EnableBtnVerbuchen(false);
                    }
                    else
                    {
                        RevertChanges(currentStatus);
                    }
                    break;

                case 2:
                    //System.Diagnostics.Debugger.Break();
                    qryPeriode["PeriodeStatusCode"] = 1;
                    if (qryPeriode.Post() && qryPeriode["KbPeriodeID"] is int)
                    {
                        qryPeriode.EnableBoundFields(true);
                        // --- Saldi automatisch vortragen; NEIN! das soll nicht geschehen!
                        //this.SaldiVortragen((int)qryPeriode["KbPeriodeID"]);

                        EnableBtnVerbuchen(true);
                    }
                    else
                    {
                        RevertChanges(currentStatus);
                    }
                    break;

                case 3:
                    EnableBtnVerbuchen(false);
                    KissMsg.ShowInfo("CtlKbPeriode", "PeriodeBereitsAbgeschlossen", "Periode ist bereits abgeschlossen");
                    break;
            }
        }

        private void btnSaldiVortragen_Click(object sender, System.EventArgs e)
        {
            // --- stop if there is no mandant
            if (qryMandant.Count == 0)
            {
                return;
            }

            // --- stop if there is only on period
            if (qryPeriode.Count <= 1)
            {
                return;
            }

            if (qryPeriode["KbPeriodeID"] is int && KissMsg.ShowQuestion(
                "CtlKbPeriode",
                "EroeffungssaldiNeuBerechnen",
                "Sollen die Eröffnungssaldi aller aktiven Perioden aufgrund der Vorperiode neu berechnet werden ?"))
            {
                this.SaldiVortragen((int)qryPeriode["KbPeriodeID"]);
            }
        }

        private void btnStandardSetzen_Click(object sender, System.EventArgs e)
        {
            this.StandardPeriodeSetzen();
        }

        private void btnVerbuchen_Click(object sender, System.EventArgs e)
        {
            DateTime periodeStart = (DateTime)qryPeriode["PeriodeVon"];
            DateTime periodeEnd = (DateTime)qryPeriode["PeriodeBis"];

            // --- Verbuchen Datum muss innerhalb der Periode liegen
            KiSS4.Common.Period period = new KiSS4.Common.Period(periodeStart, periodeEnd);
            if (!period.Contains(edtDatumVerbuchen.DateTime))
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "VerbuchenDatumInvalid",
                    "Periode kann nicht verbucht werden. Das Datum muss innerhalb der Periode liegen.");
                return;
            }

            // --- Verbuchen auf Perioden Ende ist nicht möglich!
            //     Sonst kann die Periode nicht mehr abgeschlossen werden, da keine 'letzte' SaldoBuchung
            //     gemacht werden kann.
            if (edtDatumVerbuchen.DateTime == periodeEnd)
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "VerbuchenDatumInvalid02",
                    "Periode kann nicht verbucht werden. Auf Periodenende kann nicht verbucht werden.");
                return;
            }

            // --- gibt es überhaupt Buchungen in dieser Periode
            // 12.11.2008 nur relevante Buchungen berücksichtigen (solche die in der "Buchhaltung" sind --> dbo.fnGetRelevanteBuchungen(Periode)
            if (this.NumberOfBuchungen == 0)
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "PeriodeNichtVerbucht",
                    "Periode kann nicht verbucht werden, da noch keine Buchungen vorhanden sind");
                return;
            }

            // --- das neue Verbuchen datum muss grösser als das letzte sein!
            object o = KiSS4.DB.DBUtil.ExecuteScalarSQL(@"
                SELECT
                   VerbuchtBis
                FROM dbo.KbPeriode
                WHERE KbPeriodeID = {0}",
                Utils.ConvertToInt(qryPeriode["KbPeriodeID"]));

            DateTime lastVerbuchenDate = Utils.ConvertToDateTime(o);

            if (edtDatumVerbuchen.DateTime <= lastVerbuchenDate)
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "VerbuchenDatumInvalid03",
                    "Periode kann nicht verbucht werden. Es wurde schon einmal verbucht.");

                edtDatumVerbuchen.DateTime = lastVerbuchenDate.AddDays(1);
                return;
            }

            // --- Wirklich verbuchen?
            Boolean closing = KissMsg.ShowQuestion(
                "CtlKbPeriode",
                "PeriodeVerbuchen01",
                @"Soll diese Teilperiode abgeschlossen werden? Im entsprechenden Zeitraum sind keine weiteren Buchungen möglich!");

            if (closing)
            {
                KiSS4.DB.DBUtil.ExecSQL(@"
                    UPDATE KbPeriode
                       SET VerbuchtBis = {0}
                    WHERE KbPeriodeID = {1}",
                    edtDatumVerbuchen.DateTime,
                    qryPeriode["KbPeriodeID"]);
            }
            else
            {
                // user aborted. Periode will not be closed.
            }
        }

        private void CtlKbPeriode_Load(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Class_Load");

            qryMandant.Fill(edtMandant.EditValue, edtPeriodeVon.EditValue, edtPeriodeBis.EditValue, Session.User.LanguageCode);
            this.colStatus.ColumnEdit = grdPeriode.GetLOVLookUpEdit("KbPeriodeStatus");

            // --- need special rights to access set standard button
            EnableBtnVerbuchen(false);
        }

        private void grdPeriode_DoubleClick(object sender, EventArgs e)
        {
            this.StandardPeriodeSetzen();
        }

        private void gridView2_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("gridView2_BeforeLeaveRow");
            e.Allow = qryPeriode.Post();
        }

        private void qryMandant_PositionChanged(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("qryMandant.SqlQuery_PositionChanged");

            if (!DBUtil.IsEmpty(qryMandant.Row["KbMandantID"]))
            {
                qryPeriode.Fill(qryMandant.Row["KbMandantID"]);
            }

            EnableButtons(Utils.ConvertToInt(qryPeriode["PeriodeStatusCode"]) != 3);
        }

        private void qryPeriode_AfterInsert(object sender, System.EventArgs e)
        {
            // --- create a new active period for the mandant
            qryPeriode["KbMandantID"] = qryMandant["KbMandantID"];
            qryPeriode["PeriodeStatusCode"] = 1;

            // --- get the last periods end date
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT MaxDate = max(PeriodeBis)
                FROM dbo.KbPeriode
                WHERE KbMandantID = {0}",
                qryMandant["KbMandantID"]);

            // --- propose next time period (1 year)
            if (!DBUtil.IsEmpty(qry["MaxDate"]))
            {
                DateTime D = (DateTime)qry["MaxDate"];
                qryPeriode["PeriodeVon"] = D.AddDays(1);
                qryPeriode["PeriodeBis"] = D.AddYears(1);
            }
            else
            {
                // --- no period available, propose 1 year starting from 01.01. of current year
                qryPeriode["PeriodeVon"] = new DateTime(DateTime.Now.Year, 1, 1);
                qryPeriode["PeriodeBis"] = new DateTime(DateTime.Now.Year, 12, 31);
            }

            qryPeriode.RowModified = true;
            qryPeriode.EnableBoundFields(true);
            editPeriodeVon.Focus();
        }

        private void qryPeriode_AfterPost(object sender, EventArgs e)
        {
            if (SaveRowState == DataRowState.Added)
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 KbPeriodeID
                    FROM   dbo.KbPeriode
                    WHERE KbMandantID = {0} AND KbPeriodeID <> {1}
                    ORDER BY PeriodeBis DESC",
                    qryPeriode["KbMandantID"],
                    qryPeriode["KbPeriodeID"]);

                DBUtil.ExecSQL(string.Format(@"
                    SELECT KbKontoID AS PK, NullIf(GruppeKontoID, 0) AS Parent, CONVERT(int, NULL) AS KeyNew
                    INTO #Kbkonto
                    FROM dbo.KbKonto
                    WHERE IsNull(KbPeriodeID, 0) = IsNull({{0}}, 0)

                    EXECUTE spXParentChildCopy '#Kbkonto',
                               'Kbkonto', 'KbKontoID', 'GruppeKontoID',
                               'KbPeriodeID', '{0}',
                               'Vorsaldo'

                    DROP TABLE #Kbkonto", DBUtil.SqlLiteral(qryPeriode["KbPeriodeID"])),
                    qry["KbPeriodeID"]);

                DBUtil.ExecSQL(@"
                    INSERT INTO KbBelegKreis(KbPeriodeID, KontoNr, KbBelegKreisCode, NaechsteBelegNr, BelegNrVon, BelegNrBis)
                      SELECT {0}, KontoNr, KbBelegKreisCode, BelegNrVon, BelegNrVon, BelegNrBis
                      FROM dbo.KbBelegKreis
                      WHERE KbPeriodeID = {1};",
                    qryPeriode["KbPeriodeID"],  // neu angelegte Periode
                    qry["KbPeriodeID"]);		 // letzte Periode
            }
        }

        private void qryPeriode_BeforeDelete(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("qryPeriode.Position : " + qryPeriode.Position.ToString());
            //System.Diagnostics.Debug.WriteLine("grdPeriode.Count    : " + grdPeriode.View.RowCount.ToString());

            if ((grdPeriode.View.RowCount > 0) &&
               (qryPeriode.Position != grdPeriode.View.RowCount - 1))
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "LoeschenNichtMoeglich",
                    "Die Periode kann nicht gelöscht werden, weil es schon nachfolgende Perioden gibt!");

                throw new Exception();
            }

            if (((int)qryPeriode["PeriodeStatusCode"]) == 3)
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "LoeschenNichtMoeglich",
                    "Abgeschlossene Perioden können nicht gelöscht werden !");

                throw new Exception();
            }

            FillRelevanteBuchungen();

            if (this.NumberOfBuchungen > 0)
            {
                KissMsg.ShowInfo(
                    "CtlKbPeriode",
                    "NochKeineBuchung",
                    "Periode kann nicht gelöscht werden, da noch Buchungen vorhanden sind");
                throw new Exception();
            }

            // --- lösche auch den KbBelegKreis
            System.Diagnostics.Debug.WriteLine("Lösche BelegKreis");
            DBUtil.ExecSQL(@"
                DELETE FROM KbBelegKreis
                WHERE KbPeriodeID = {0}",
                qryPeriode["KbPeriodeID"]);

            // --- lösche auch den Kontenplan
            System.Diagnostics.Debug.WriteLine("Lösche Kontenplan");
            DBUtil.ExecSQL(@"
                DELETE FROM KbKonto
                WHERE KbPeriodeID = {0}",
                qryPeriode["KbPeriodeID"]);
        }

        private void qryPeriode_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(editPeriodeVon, lblPeriodeVon.Text);
            DBUtil.CheckNotNullField(editPeriodeBis, lblPeriodeBis.Text);

            var periodeVon = Utils.ConvertToDateTime(qryPeriode[DBO.KbPeriode.PeriodeVon]);
            var periodeBis = Utils.ConvertToDateTime(qryPeriode[DBO.KbPeriode.PeriodeBis]);

            if (periodeVon > periodeBis)
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "SpeichernNichtMoeglichDaten",
                    "'Periode von' darf nicht grösser als 'Periode bis' sein.");
                throw new KissCancelException();
            }

            // check Periodenüberschneidung
            var qryUeberschneidung = DBUtil.OpenSQL(@"
                SELECT TOP 1 1
                FROM dbo.KbPeriode
                WHERE  KbMandantID = {0}
                AND    (KbPeriodeID <> {1} OR {1} IS NULL)
                AND    (   {2} BETWEEN PeriodeVon AND PeriodeBis
                        OR {3} BETWEEN PeriodeVon AND PeriodeBis);",
                qryPeriode[DBO.KbPeriode.KbMandantID],
                qryPeriode[DBO.KbPeriode.KbPeriodeID],
                qryPeriode[DBO.KbPeriode.PeriodeVon],
                qryPeriode[DBO.KbPeriode.PeriodeBis]);

            if (qryUeberschneidung.Count > 0)
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "SpeichernNichtMoeglichUeberschneidung",
                    "Der angegebene Zeitraum tangiert eine existierende Geschäftsperiode. Wählen Sie einen anderen Periodenzeitraum.");
                throw new KissCancelException();
            }

            // check bestehende Buchungen
            // ck: aber nur von den Relevanten!
            if (qryPeriode.Row.RowState == DataRowState.Modified)
            {
                DataRow[] rows = qryRelevanteBuchungen.DataTable.Select(string.Format("(BelegDatum < '{0}' OR BelegDatum > '{1}')", qryPeriode["PeriodeVon"], qryPeriode["PeriodeBis"]));

                if (rows.Length > 0)
                {
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "BuchungAusserhalbDatum",
                        "Periode kann nicht gespeichert werden, da bereits Buchungen ausserhalb des Datumbereichs existieren");

                    throw new KissCancelException(); // --> abort save.
                }
            }

            SaveRowState = qryPeriode.Row.RowState;
        }

        private void qryPeriode_PositionChanged(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("qryPeriode.SqlQuery_PositionChanged");

            // --- setze das Datum für das Verbuchen feld
            object o = KiSS4.DB.DBUtil.ExecuteScalarSQL(@"
                SELECT
                  VerbuchtBis
                FROM dbo.KbPeriode
                WHERE KbPeriodeID = {0}",
                Utils.ConvertToInt(qryPeriode["KbPeriodeID"]));
            DateTime lastVerbuchenDate = Utils.ConvertToDateTime(o);

            if (lastVerbuchenDate != DateTime.MinValue)
            {
                edtDatumVerbuchen.DateTime = lastVerbuchenDate.AddDays(1);
            }
            else
            {
                edtDatumVerbuchen.DateTime = ((DateTime)(qryPeriode["PeriodeVon"])).AddDays(1);
            }

            // --- disable verbuchen button if period is abgeschlossen
            EnableButtons(Utils.ConvertToInt(qryPeriode["PeriodeStatusCode"]) != 3);

            // ---
            Boolean allowEdit = (((int)qryPeriode["PeriodeStatusCode"]) != 3);

            // --- nur die letzte position darf verändert werden
            if (qryPeriode.Position != grdPeriode.View.RowCount - 1)
            {
                allowEdit = false;
            }

            qryPeriode.EnableBoundFields(allowEdit);

            this.FillRelevanteBuchungen();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            System.Diagnostics.Debug.WriteLine("qryMandant.NewSearch");
            base.NewSearch();
            grdMandant.Focus();
        }

        protected override void RunSearch()
        {
            System.Diagnostics.Debug.WriteLine("qryMandant.RunSearch");

            Cursor.Current = Cursors.WaitCursor;

            if (qryMandant_SelectStatement == string.Empty)
            {
                qryMandant_SelectStatement = qryMandant.SelectStatement;
            }
            else
            {
                qryMandant.SelectStatement = qryMandant_SelectStatement;
            }

            qryMandant.Fill(edtMandant.EditValue, edtPeriodeVon.EditValue, edtPeriodeBis.EditValue, Session.User.LanguageCode);
            this.tabControlSearch.SelectedTabIndex = tpgListe.TabIndex;

            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Private Methods

        private void EnableBtnAbschluss(Boolean value)
        {
            btnAbschluss.Enabled = value && DBUtil.UserHasRight("CtlKbPeriode_Abschliessen");
        }

        private void EnableBtnAktiv(Boolean value)
        {
            btnAktiv.Enabled = value && DBUtil.UserHasRight("CtlKbPeriode_AktivSetzen");
        }

        private void EnableBtnSaldiVortragen(Boolean value)
        {
            btnSaldiVortragen.Enabled = value && DBUtil.UserHasRight("CtlKbPeriode_SaldoVortragen");
        }

        private void EnableBtnStandardSetzen(Boolean value)
        {
            btnStandardSetzen.Enabled = value && DBUtil.UserHasRight("CtlKbPeriode_PeriodeSetzen");
        }

        private void EnableBtnVerbuchen(Boolean value)
        {
            btnVerbuchen.Enabled = false; //value && DBUtil.UserHasRight("CtlKbPeriode_Verbuchen");
        }

        private void EnableButtons(Boolean value)
        {
            System.Diagnostics.Debug.WriteLine("EnableButtons : " + value.ToString());
            if (value)
            {
                EnableBtnAbschluss(true);
                EnableBtnAktiv(true);
                EnableBtnSaldiVortragen(true);
                EnableBtnVerbuchen(true);
            }
            else
            {
                EnableBtnAbschluss(false);
                EnableBtnAktiv(false);
                EnableBtnSaldiVortragen(false);
                EnableBtnVerbuchen(false);
            }
        }

        private void FillRelevanteBuchungen()
        {
            qryRelevanteBuchungen.Fill(@"
            SELECT
              KbBuchungKostenartID,
              KbBuchungID,
              SollKtoNr,
              HabenKtoNr,
              Betrag,
              Ausgabe,
              BelegDatum
            FROM dbo.fnKbGetRelevanteBuchungen({0}, NULL, NULL, 1, 0)", qryPeriode["KbPeriodeID"]);
        }

        private void RevertChanges(int currentStatus)
        {
            qryPeriode["PeriodeStatusCode"] = currentStatus;
            qryPeriode.Row.AcceptChanges();
            qryPeriode.RowModified = false;
            qryPeriode.RefreshDisplay();
        }

        private void SaldiVortragen(int kbPeriodeID)
        {
            if (DBUtil.ExecSQL("EXEC dbo.spKbSaldiVortragen {0}", kbPeriodeID) != -1)
            {
                KissMsg.ShowInfo("CtlKbPeriode", "SaldiVorgetragen", "Alle Saldi wurden vorgetragen.");
            }
        }

        private void StandardPeriodeSetzen()
        {
            if (!KissMsg.ShowQuestion("CtlKbPeriode", "StandardPeriodeSetzen", "Soll die gewählte Periode als Standard verwendet werden?"))
            {
                return;
            }

            // --- ungesicherte periode speichern
            qryPeriode.Post();

            qryKbPeriode_User.Fill(Session.User.UserID);

            if (qryKbPeriode_User.Count <= 0)
            {
                qryKbPeriode_User.Insert("KbPeriode_User");
                qryKbPeriode_User["UserID"] = Session.User.UserID;
            }

            qryKbPeriode_User["KbPeriodeID"] = qryPeriode["KbPeriodeID"];

            qryKbPeriode_User.Post();

            FormController.SendMessage("FrmKbKlientenbuchhaltung", "Action", "MandantWechseln");
        }

        #endregion

        #endregion
    }
}