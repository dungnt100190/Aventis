using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Query;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for FrmKaAMMBescheinigung.
    /// </summary>
    public class FrmKaAMMBescheinigung : KiSS4.Gui.KissChildForm
    {
        #region Fields

        #region Private Fields

        private bool abbruch = false;
        private KiSS4.Gui.KissButton btnAbbruch;
        private KiSS4.Gui.KissButton btnAbfragen;
        private KiSS4.Gui.KissButton btnDeselectAll;
        private KiSS4.Gui.KissButton btnMassendruck;
        private KiSS4.Gui.KissButton btnSelectAll;
        private KiSS4.Gui.KissCheckEdit chkInklusiveALV;
        private KiSS4.Gui.KissCheckEdit chkInklusiveArt59d;
        private KiSS4.Gui.KissCheckEdit chkPreview;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colPrinted;
        private DevExpress.XtraGrid.Columns.GridColumn colSelPrint;
        private DevExpress.XtraGrid.Columns.GridColumn colZustKA;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KissLookUpEdit ddlAPVNrX;
        private KiSS4.Gui.KissLookUpEdit ddlMonatX;
        private KiSS4.Gui.KissLookUpEdit ddlProfilX;
        private KiSS4.Gui.KissButtonEdit dlgCoachX;
        private KiSS4.Gui.KissButtonEdit dlgKlientX;
        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissGrid grdAMMBesch;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAMMBesch;
        private KiSS4.Gui.KissLabel lblAMMBesch;
        private KissLabel lblAPVNr;
        private KiSS4.Gui.KissLabel lblAktion;
        private System.Windows.Forms.Label lblAnzDatensaetze;
        private KiSS4.Gui.KissLabel lblCoach;
        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissLabel lblKlientIn;
        private KiSS4.Gui.KissLabel lblMonat;
        private KiSS4.Gui.KissLabel lblProfil;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Panel pnlGrid;
        private KiSS4.DB.SqlQuery qryAMMBesch;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private KiSS4.Gui.KissSearchTitel titSearch;
        private SharpLibrary.WinControls.TabPageEx tpgGrid;
        private SharpLibrary.WinControls.TabPageEx tpgSearch;
        private KiSS4.Gui.KissTabControlEx xTabControl1;

        #endregion

        #endregion

        #region Constructors

        public FrmKaAMMBescheinigung()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xTabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tpgGrid = new SharpLibrary.WinControls.TabPageEx();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblAMMBesch = new KiSS4.Gui.KissLabel();
            this.lblAnzDatensaetze = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.grdAMMBesch = new KiSS4.Gui.KissGrid();
            this.qryAMMBesch = new KiSS4.DB.SqlQuery(this.components);
            this.grvAMMBesch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZustKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tpgSearch = new SharpLibrary.WinControls.TabPageEx();
            this.ddlAPVNrX = new KiSS4.Gui.KissLookUpEdit();
            this.lblAPVNr = new KiSS4.Gui.KissLabel();
            this.chkInklusiveArt59d = new KiSS4.Gui.KissCheckEdit();
            this.chkInklusiveALV = new KiSS4.Gui.KissCheckEdit();
            this.ddlProfilX = new KiSS4.Gui.KissLookUpEdit();
            this.lblProfil = new KiSS4.Gui.KissLabel();
            this.lblKlientIn = new KiSS4.Gui.KissLabel();
            this.dlgCoachX = new KiSS4.Gui.KissButtonEdit();
            this.lblCoach = new KiSS4.Gui.KissLabel();
            this.dlgKlientX = new KiSS4.Gui.KissButtonEdit();
            this.ddlMonatX = new KiSS4.Gui.KissLookUpEdit();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.titSearch = new KiSS4.Gui.KissSearchTitel();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.lblMonat = new KiSS4.Gui.KissLabel();
            this.btnMassendruck = new KiSS4.Gui.KissButton();
            this.btnAbbruch = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.btnDeselectAll = new KiSS4.Gui.KissButton();
            this.btnAbfragen = new KiSS4.Gui.KissButton();
            this.lblAktion = new KiSS4.Gui.KissLabel();
            this.chkPreview = new KiSS4.Gui.KissCheckEdit();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.xTabControl1.SuspendLayout();
            this.tpgGrid.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAMMBesch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAMMBesch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAMMBesch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAMMBesch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tpgSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInklusiveArt59d.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInklusiveALV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProfilX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProfilX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgCoachX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKlientX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // xTabControl1
            //
            this.xTabControl1.Controls.Add(this.tpgGrid);
            this.xTabControl1.Controls.Add(this.tpgSearch);
            this.xTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xTabControl1.Name = "xTabControl1";
            this.xTabControl1.ShowFixedWidthTooltip = true;
            this.xTabControl1.Size = new System.Drawing.Size(967, 436);
            this.xTabControl1.TabIndex = 1;
            this.xTabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgGrid,
            this.tpgSearch});
            this.xTabControl1.TabsLineColor = System.Drawing.Color.Black;
            this.xTabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.xTabControl1.TabStop = false;
            this.xTabControl1.Text = "xTabControl1";
            //
            // tpgGrid
            //
            this.tpgGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgGrid.Controls.Add(this.pnlGrid);
            this.tpgGrid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tpgGrid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgGrid.Location = new System.Drawing.Point(6, 6);
            this.tpgGrid.Name = "tpgGrid";
            this.tpgGrid.Size = new System.Drawing.Size(955, 398);
            this.tpgGrid.TabIndex = 0;
            this.tpgGrid.Title = "Liste";
            //
            // pnlGrid
            //
            this.pnlGrid.Controls.Add(this.lblAMMBesch);
            this.pnlGrid.Controls.Add(this.lblAnzDatensaetze);
            this.pnlGrid.Controls.Add(this.lblRowCount);
            this.pnlGrid.Controls.Add(this.grdAMMBesch);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(955, 398);
            this.pnlGrid.TabIndex = 30;
            //
            // lblAMMBesch
            //
            this.lblAMMBesch.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblAMMBesch.Location = new System.Drawing.Point(12, 8);
            this.lblAMMBesch.Name = "lblAMMBesch";
            this.lblAMMBesch.Size = new System.Drawing.Size(404, 16);
            this.lblAMMBesch.TabIndex = 46;
            this.lblAMMBesch.Text = "AMM Bescheinigungen";
            //
            // lblAnzDatensaetze
            //
            this.lblAnzDatensaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzDatensaetze.AutoSize = true;
            this.lblAnzDatensaetze.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnzDatensaetze.Location = new System.Drawing.Point(803, 8);
            this.lblAnzDatensaetze.Name = "lblAnzDatensaetze";
            this.lblAnzDatensaetze.Size = new System.Drawing.Size(102, 14);
            this.lblAnzDatensaetze.TabIndex = 44;
            this.lblAnzDatensaetze.Text = "Anzahl Datensätze:";
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount.Location = new System.Drawing.Point(903, 8);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(44, 16);
            this.lblRowCount.TabIndex = 45;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // grdAMMBesch
            //
            this.grdAMMBesch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAMMBesch.DataSource = this.qryAMMBesch;
            this.grdAMMBesch.EmbeddedNavigator.Name = "";
            this.grdAMMBesch.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdAMMBesch.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdAMMBesch.Location = new System.Drawing.Point(8, 36);
            this.grdAMMBesch.MainView = this.grvAMMBesch;
            this.grdAMMBesch.Name = "grdAMMBesch";
            this.grdAMMBesch.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdAMMBesch.Size = new System.Drawing.Size(943, 355);
            this.grdAMMBesch.TabIndex = 0;
            this.grdAMMBesch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAMMBesch});
            //
            // qryAMMBesch
            //
            this.qryAMMBesch.CanUpdate = true;
            this.qryAMMBesch.HostControl = this;
            this.qryAMMBesch.TableName = "KaAMMBesch";
            this.qryAMMBesch.BeforePost += new System.EventHandler(this.qryAMMBesch_BeforePost);
            this.qryAMMBesch.PositionChanged += new System.EventHandler(this.qryAMMBesch_PositionChanged);
            //
            // grvAMMBesch
            //
            this.grvAMMBesch.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAMMBesch.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.Empty.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.Empty.Options.UseFont = true;
            this.grvAMMBesch.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvAMMBesch.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.EvenRow.Options.UseFont = true;
            this.grvAMMBesch.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAMMBesch.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvAMMBesch.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAMMBesch.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAMMBesch.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAMMBesch.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvAMMBesch.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAMMBesch.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAMMBesch.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAMMBesch.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAMMBesch.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAMMBesch.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAMMBesch.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.GroupRow.Options.UseFont = true;
            this.grvAMMBesch.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAMMBesch.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAMMBesch.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAMMBesch.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAMMBesch.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAMMBesch.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAMMBesch.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAMMBesch.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAMMBesch.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAMMBesch.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAMMBesch.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvAMMBesch.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvAMMBesch.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.OddRow.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.OddRow.Options.UseFont = true;
            this.grvAMMBesch.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAMMBesch.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.Row.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.Row.Options.UseFont = true;
            this.grvAMMBesch.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAMMBesch.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAMMBesch.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvAMMBesch.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAMMBesch.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAMMBesch.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvAMMBesch.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvAMMBesch.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAMMBesch.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAMMBesch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZustKA,
            this.colKlient,
            this.colInfo,
            this.colMonatJahr,
            this.colPrinted,
            this.colSelPrint});
            this.grvAMMBesch.GridControl = this.grdAMMBesch;
            this.grvAMMBesch.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvAMMBesch.Name = "grvAMMBesch";
            this.grvAMMBesch.OptionsCustomization.AllowFilter = false;
            this.grvAMMBesch.OptionsCustomization.AllowGroup = false;
            this.grvAMMBesch.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAMMBesch.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAMMBesch.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvAMMBesch.OptionsPrint.AutoWidth = false;
            this.grvAMMBesch.OptionsPrint.UsePrintStyles = true;
            this.grvAMMBesch.OptionsView.ColumnAutoWidth = false;
            this.grvAMMBesch.OptionsView.ShowDetailButtons = false;
            this.grvAMMBesch.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAMMBesch.OptionsView.ShowGroupPanel = false;
            this.grvAMMBesch.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvAMMBesch_RowCellStyle);
            //
            // colZustKA
            //
            this.colZustKA.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colZustKA.AppearanceCell.Options.UseBackColor = true;
            this.colZustKA.Caption = "zuständig KA";
            this.colZustKA.FieldName = "ZustKA";
            this.colZustKA.Name = "colZustKA";
            this.colZustKA.OptionsColumn.AllowEdit = false;
            this.colZustKA.OptionsColumn.ReadOnly = true;
            this.colZustKA.Visible = true;
            this.colZustKA.VisibleIndex = 0;
            this.colZustKA.Width = 150;
            //
            // colKlient
            //
            this.colKlient.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colKlient.AppearanceCell.Options.UseBackColor = true;
            this.colKlient.Caption = "Klient";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.ReadOnly = true;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 1;
            this.colKlient.Width = 150;
            //
            // colInfo
            //
            this.colInfo.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colInfo.AppearanceCell.Options.UseBackColor = true;
            this.colInfo.Caption = "Info";
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.OptionsColumn.AllowEdit = false;
            this.colInfo.OptionsColumn.ReadOnly = true;
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 2;
            this.colInfo.Width = 380;
            //
            // colMonatJahr
            //
            this.colMonatJahr.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colMonatJahr.AppearanceCell.Options.UseBackColor = true;
            this.colMonatJahr.Caption = "Monat / Jahr";
            this.colMonatJahr.FieldName = "MonatJahr";
            this.colMonatJahr.Name = "colMonatJahr";
            this.colMonatJahr.OptionsColumn.AllowEdit = false;
            this.colMonatJahr.OptionsColumn.ReadOnly = true;
            this.colMonatJahr.Visible = true;
            this.colMonatJahr.VisibleIndex = 3;
            this.colMonatJahr.Width = 100;
            //
            // colPrinted
            //
            this.colPrinted.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colPrinted.AppearanceCell.Options.UseBackColor = true;
            this.colPrinted.Caption = "gedruckt";
            this.colPrinted.DisplayFormat.FormatString = "N2";
            this.colPrinted.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrinted.FieldName = "printed";
            this.colPrinted.Name = "colPrinted";
            this.colPrinted.OptionsColumn.AllowEdit = false;
            this.colPrinted.OptionsColumn.ReadOnly = true;
            this.colPrinted.Visible = true;
            this.colPrinted.VisibleIndex = 4;
            this.colPrinted.Width = 63;
            //
            // colSelPrint
            //
            this.colSelPrint.Caption = "Ausdruck";
            this.colSelPrint.FieldName = "SelPrint";
            this.colSelPrint.Name = "colSelPrint";
            this.colSelPrint.Visible = true;
            this.colSelPrint.VisibleIndex = 5;
            this.colSelPrint.Width = 65;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // tpgSearch
            //
            this.tpgSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgSearch.Controls.Add(this.ddlAPVNrX);
            this.tpgSearch.Controls.Add(this.lblAPVNr);
            this.tpgSearch.Controls.Add(this.chkInklusiveArt59d);
            this.tpgSearch.Controls.Add(this.chkInklusiveALV);
            this.tpgSearch.Controls.Add(this.ddlProfilX);
            this.tpgSearch.Controls.Add(this.lblProfil);
            this.tpgSearch.Controls.Add(this.lblKlientIn);
            this.tpgSearch.Controls.Add(this.dlgCoachX);
            this.tpgSearch.Controls.Add(this.lblCoach);
            this.tpgSearch.Controls.Add(this.dlgKlientX);
            this.tpgSearch.Controls.Add(this.ddlMonatX);
            this.tpgSearch.Controls.Add(this.edtJahr);
            this.tpgSearch.Controls.Add(this.titSearch);
            this.tpgSearch.Controls.Add(this.lblJahr);
            this.tpgSearch.Controls.Add(this.lblMonat);
            this.tpgSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tpgSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgSearch.Location = new System.Drawing.Point(6, 6);
            this.tpgSearch.Name = "tpgSearch";
            this.tpgSearch.Size = new System.Drawing.Size(955, 398);
            this.tpgSearch.TabIndex = 1;
            this.tpgSearch.Title = "Suchen";
            this.tpgSearch.Visible = false;
            //
            // ddlAPVNrX
            //
            this.ddlAPVNrX.Location = new System.Drawing.Point(102, 198);
            this.ddlAPVNrX.LOVName = "KaAPV";
            this.ddlAPVNrX.Name = "ddlAPVNrX";
            this.ddlAPVNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAPVNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAPVNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAPVNrX.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAPVNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAPVNrX.Properties.Appearance.Options.UseFont = true;
            this.ddlAPVNrX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAPVNrX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAPVNrX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAPVNrX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAPVNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.ddlAPVNrX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.ddlAPVNrX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAPVNrX.Properties.NullText = "";
            this.ddlAPVNrX.Properties.ShowFooter = false;
            this.ddlAPVNrX.Properties.ShowHeader = false;
            this.ddlAPVNrX.Size = new System.Drawing.Size(260, 24);
            this.ddlAPVNrX.TabIndex = 6;
            //
            // lblAPVNr
            //
            this.lblAPVNr.Location = new System.Drawing.Point(12, 198);
            this.lblAPVNr.Name = "lblAPVNr";
            this.lblAPVNr.Size = new System.Drawing.Size(48, 24);
            this.lblAPVNr.TabIndex = 578;
            this.lblAPVNr.Text = "APV-Nr";
            //
            // chkInklusiveArt59d
            //
            this.chkInklusiveArt59d.EditValue = false;
            this.chkInklusiveArt59d.Location = new System.Drawing.Point(102, 257);
            this.chkInklusiveArt59d.Name = "chkInklusiveArt59d";
            this.chkInklusiveArt59d.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkInklusiveArt59d.Properties.Appearance.Options.UseBackColor = true;
            this.chkInklusiveArt59d.Properties.Caption = " inklusive Art 59d";
            this.chkInklusiveArt59d.Size = new System.Drawing.Size(144, 19);
            this.chkInklusiveArt59d.TabIndex = 8;
            //
            // chkInklusiveALV
            //
            this.chkInklusiveALV.EditValue = false;
            this.chkInklusiveALV.Location = new System.Drawing.Point(102, 234);
            this.chkInklusiveALV.Name = "chkInklusiveALV";
            this.chkInklusiveALV.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkInklusiveALV.Properties.Appearance.Options.UseBackColor = true;
            this.chkInklusiveALV.Properties.Caption = " inklusive ALV";
            this.chkInklusiveALV.Size = new System.Drawing.Size(144, 19);
            this.chkInklusiveALV.TabIndex = 7;
            //
            // ddlProfilX
            //
            this.ddlProfilX.Location = new System.Drawing.Point(102, 168);
            this.ddlProfilX.LOVName = "KaProfil";
            this.ddlProfilX.Name = "ddlProfilX";
            this.ddlProfilX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlProfilX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlProfilX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlProfilX.Properties.Appearance.Options.UseBackColor = true;
            this.ddlProfilX.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlProfilX.Properties.Appearance.Options.UseFont = true;
            this.ddlProfilX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlProfilX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlProfilX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlProfilX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlProfilX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.ddlProfilX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.ddlProfilX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlProfilX.Properties.NullText = "";
            this.ddlProfilX.Properties.ShowFooter = false;
            this.ddlProfilX.Properties.ShowHeader = false;
            this.ddlProfilX.Size = new System.Drawing.Size(144, 24);
            this.ddlProfilX.TabIndex = 5;
            //
            // lblProfil
            //
            this.lblProfil.Location = new System.Drawing.Point(12, 168);
            this.lblProfil.Name = "lblProfil";
            this.lblProfil.Size = new System.Drawing.Size(66, 24);
            this.lblProfil.TabIndex = 574;
            this.lblProfil.Text = "Profilnr.";
            //
            // lblKlientIn
            //
            this.lblKlientIn.Location = new System.Drawing.Point(12, 138);
            this.lblKlientIn.Name = "lblKlientIn";
            this.lblKlientIn.Size = new System.Drawing.Size(72, 24);
            this.lblKlientIn.TabIndex = 572;
            this.lblKlientIn.Text = "Klient/-in";
            //
            // dlgCoachX
            //
            this.dlgCoachX.Location = new System.Drawing.Point(102, 48);
            this.dlgCoachX.Name = "dlgCoachX";
            this.dlgCoachX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgCoachX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgCoachX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgCoachX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgCoachX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgCoachX.Properties.Appearance.Options.UseFont = true;
            this.dlgCoachX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.dlgCoachX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.dlgCoachX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgCoachX.Size = new System.Drawing.Size(260, 24);
            this.dlgCoachX.TabIndex = 1;
            this.dlgCoachX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgCoachX_UserModifiedFld);
            //
            // lblCoach
            //
            this.lblCoach.ForeColor = System.Drawing.Color.Black;
            this.lblCoach.Location = new System.Drawing.Point(12, 48);
            this.lblCoach.Name = "lblCoach";
            this.lblCoach.Size = new System.Drawing.Size(80, 24);
            this.lblCoach.TabIndex = 571;
            this.lblCoach.Text = "zuständig KA";
            //
            // dlgKlientX
            //
            this.dlgKlientX.Location = new System.Drawing.Point(102, 138);
            this.dlgKlientX.Name = "dlgKlientX";
            this.dlgKlientX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgKlientX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgKlientX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgKlientX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgKlientX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgKlientX.Properties.Appearance.Options.UseFont = true;
            this.dlgKlientX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.dlgKlientX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.dlgKlientX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgKlientX.Size = new System.Drawing.Size(260, 24);
            this.dlgKlientX.TabIndex = 4;
            this.dlgKlientX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgKlientX_UserModifiedFld);
            //
            // ddlMonatX
            //
            this.ddlMonatX.Location = new System.Drawing.Point(102, 76);
            this.ddlMonatX.Name = "ddlMonatX";
            this.ddlMonatX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlMonatX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlMonatX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlMonatX.Properties.Appearance.Options.UseBackColor = true;
            this.ddlMonatX.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlMonatX.Properties.Appearance.Options.UseFont = true;
            this.ddlMonatX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlMonatX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlMonatX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlMonatX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlMonatX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.ddlMonatX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.ddlMonatX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlMonatX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.ddlMonatX.Properties.DisplayMember = "Text";
            this.ddlMonatX.Properties.NullText = "";
            this.ddlMonatX.Properties.ShowFooter = false;
            this.ddlMonatX.Properties.ShowHeader = false;
            this.ddlMonatX.Properties.ValueMember = "Code";
            this.ddlMonatX.Size = new System.Drawing.Size(89, 24);
            this.ddlMonatX.TabIndex = 2;
            //
            // edtJahr
            //
            this.edtJahr.Location = new System.Drawing.Point(102, 105);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtJahr.Properties.Mask.EditMask = "####";
            this.edtJahr.Properties.Mask.IgnoreMaskBlank = false;
            this.edtJahr.Properties.MaxLength = 4;
            this.edtJahr.Size = new System.Drawing.Size(57, 24);
            this.edtJahr.TabIndex = 3;
            //
            // titSearch
            //
            this.titSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.titSearch.Location = new System.Drawing.Point(17, 4);
            this.titSearch.Name = "titSearch";
            this.titSearch.Size = new System.Drawing.Size(200, 24);
            this.titSearch.TabIndex = 15;
            //
            // lblJahr
            //
            this.lblJahr.Location = new System.Drawing.Point(12, 106);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(66, 24);
            this.lblJahr.TabIndex = 7;
            this.lblJahr.Text = "Jahr";
            //
            // lblMonat
            //
            this.lblMonat.Location = new System.Drawing.Point(12, 76);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(66, 24);
            this.lblMonat.TabIndex = 5;
            this.lblMonat.Text = "Monat";
            //
            // btnMassendruck
            //
            this.btnMassendruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMassendruck.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMassendruck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMassendruck.Location = new System.Drawing.Point(865, 460);
            this.btnMassendruck.Name = "btnMassendruck";
            this.btnMassendruck.Size = new System.Drawing.Size(94, 24);
            this.btnMassendruck.TabIndex = 13;
            this.btnMassendruck.Text = "Massendruck";
            this.btnMassendruck.UseVisualStyleBackColor = false;
            this.btnMassendruck.Click += new System.EventHandler(this.btnMassendruck_Click);
            //
            // btnAbbruch
            //
            this.btnAbbruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbbruch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAbbruch.Enabled = false;
            this.btnAbbruch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbruch.Location = new System.Drawing.Point(755, 460);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(104, 24);
            this.btnAbbruch.TabIndex = 41;
            this.btnAbbruch.Text = "Abbruch";
            this.btnAbbruch.UseVisualStyleBackColor = false;
            this.btnAbbruch.Click += new System.EventHandler(this.btnAbbruch_Click);
            //
            // btnSelectAll
            //
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Location = new System.Drawing.Point(605, 460);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(105, 24);
            this.btnSelectAll.TabIndex = 42;
            this.btnSelectAll.Text = "Alle auswählen";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            //
            // btnDeselectAll
            //
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeselectAll.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.Location = new System.Drawing.Point(485, 460);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(115, 24);
            this.btnDeselectAll.TabIndex = 43;
            this.btnDeselectAll.Text = "Keine auswählen";
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            //
            // btnAbfragen
            //
            this.btnAbfragen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbfragen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAbfragen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbfragen.Location = new System.Drawing.Point(335, 460);
            this.btnAbfragen.Name = "btnAbfragen";
            this.btnAbfragen.Size = new System.Drawing.Size(105, 24);
            this.btnAbfragen.TabIndex = 44;
            this.btnAbfragen.Text = "Abfragen";
            this.btnAbfragen.UseVisualStyleBackColor = false;
            this.btnAbfragen.Click += new System.EventHandler(this.btnAbfragen_Click);
            //
            // lblAktion
            //
            this.lblAktion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAktion.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAktion.Location = new System.Drawing.Point(10, 464);
            this.lblAktion.Name = "lblAktion";
            this.lblAktion.Size = new System.Drawing.Size(317, 16);
            this.lblAktion.TabIndex = 45;
            this.lblAktion.Text = "Aktion";
            //
            // chkPreview
            //
            this.chkPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPreview.EditValue = false;
            this.chkPreview.Location = new System.Drawing.Point(865, 430);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkPreview.Properties.Appearance.Options.UseBackColor = true;
            this.chkPreview.Properties.Caption = "Druckvorschau";
            this.chkPreview.Size = new System.Drawing.Size(105, 19);
            this.chkPreview.TabIndex = 46;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlGotoFall.Location = new System.Drawing.Point(365, 415);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(200, 24);
            this.ctlGotoFall.TabIndex = 47;
            //
            // FrmKaAMMBescheinigung
            //
            this.ActiveSQLQuery = this.qryAMMBesch;
            this.ClientSize = new System.Drawing.Size(977, 491);
            this.Controls.Add(this.ctlGotoFall);
            this.Controls.Add(this.chkPreview);
            this.Controls.Add(this.lblAktion);
            this.Controls.Add(this.btnAbfragen);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnMassendruck);
            this.Controls.Add(this.xTabControl1);
            this.MinimumSize = new System.Drawing.Size(585, 335);
            this.Name = "FrmKaAMMBescheinigung";
            this.Text = "AMM Bescheinigung";
            this.Search += new System.EventHandler(this.FrmKaAMMBescheinigung_Search);
            this.Load += new System.EventHandler(this.FrmKaAMMBescheinigung_Load);
            this.Print += new System.EventHandler(this.FrmKaAMMBescheinigung_Print);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmKaAMMBescheinigung_KeyDown);
            this.xTabControl1.ResumeLayout(false);
            this.tpgGrid.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAMMBesch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAMMBesch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAMMBesch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAMMBesch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tpgSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInklusiveArt59d.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInklusiveALV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProfilX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProfilX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgCoachX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKlientX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).EndInit();
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

        private void FrmKaAMMBescheinigung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            this.ctlGotoFall.CtlGotoFall_KeyDown(sender, e);
        }

        private void FrmKaAMMBescheinigung_Load(object sender, System.EventArgs e)
        {
            xTabControl1.SelectedTabIndex = 1;

            // Monate
            SqlQuery qry = DBUtil.OpenSQL(@"
                select  Code = 1, Text = 'Jan' union all
                select  2, 'Feb' union all
                select  3, 'März' union all
                select  4, 'Apr' union all
                select  5, 'Mai' union all
                select  6, 'Juni' union all
                select  7, 'Juli' union all
                select  8, 'Aug' union all
                select  9, 'Sep' union all
                select 10, 'Okt' union all
                select 11, 'Nov' union all
                select 12, 'Dez' ");

            ddlMonatX.Properties.DataSource = qry;

            ddlMonatX.EditValue = DateTime.Today.Month;
            edtJahr.EditValue = DateTime.Today.Year;
            chkInklusiveArt59d.Checked = true;
            chkInklusiveALV.Checked = true;

            lblAktion.Text = "";

            SqlQuery qry1 = DBUtil.OpenSQL(@"
                SELECT Code = null, Text = null
                UNION
                SELECT Code = KaEinsatzplatzID, Text = dbo.fnLOVText('KaAPV', APVCode)
                FROM KaEinsatzplatz2
                WHERE CONVERT(DateTime, DatumVon, 104) <= CONVERT(DateTime, {0}, 104)
                AND (DatumBis IS NULL OR CONVERT(DateTime, DatumBis, 104) >= DATEADD(DAY, -1, DATEADD(MONTH, 1, CONVERT(DateTime, {0}, 104))))
                ORDER BY Text", "01." + ddlMonatX.EditValue.ToString() + "." + edtJahr.EditValue.ToString());
            ddlAPVNrX.Properties.DataSource = qry1;
            ddlAPVNrX.Properties.DropDownRows = 7;

            //Suchen(false);
        }

        private void FrmKaAMMBescheinigung_Print(object sender, System.EventArgs e)
        {
            qryAMMBesch.EndCurrentEdit(true);

            abbruch = false;
            btnAbbruch.Enabled = true;
            btnAbbruch.Focus();

            int count = 0;
            foreach (DataRow row in qryAMMBesch.DataTable.Rows)
            {
                if ((bool)row["SelPrint"])
                {
                    count++;
                    lblAktion.Text = "AMM Bescheinigung " + count.ToString() + " wird gedruckt ...";
                    ApplicationFacade.DoEvents();

                    if (abbruch)
                    {
                        count--;
                        break;
                    }

                    NamedPrm[] prms = new NamedPrm[3];
                    prms[0] = new NamedPrm("BaPersonID", row["BaPersonID"]);
                    prms[1] = new NamedPrm("KaEinsatzID", row["KaEinsatzID"]);
                    prms[2] = new NamedPrm("KaAmmBeschID", row["KaAmmBeschID"]);

                    if (chkPreview.Checked)
                    {
                        RepUtil.ExecuteReport("KAAAMBescheinigung", KissReportDestination.Viewer, prms);
                    }
                    else
                    {
                        RepUtil.ExecuteReport("KAAAMBescheinigung", KissReportDestination.Printer, prms);
                    }

                    DBUtil.ExecSQL(@"UPDATE KaAMMBesch SET gedrucktFlag = convert(bit, 1) WHERE KaAmmBeschID = {0}", row["KaAmmBeschID"]);

                    ApplicationFacade.DoEvents();
                }
            }
            lblAktion.Text = "";
            abbruch = false;
            btnAbbruch.Enabled = false;

            if (count == 0)
            {
                KissMsg.ShowInfo("FrmKaAMMBescheinigung", "KeineAMMBeschSelektiert", "Es ist keine AMM Bescheinigung für den Ausdruck selektiert!");
                return;
            }

            if (count == 1)
                KissMsg.ShowInfo("FrmKaAMMBescheinigung", "EineAMMBeschGedruckt", "Es wurde 1 AMM Bescheinigung gedruckt.");
            else
                KissMsg.ShowInfo("FrmKaAMMBescheinigung", "nAMMBeschGedruckt", "Es wurden {0} AMM Bescheinigungen gedruckt.", 0, 0, count.ToString());

            this.Activate();

            Suchen(false);
        }

        private void FrmKaAMMBescheinigung_Search(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(edtJahr.EditValue))
            {
                KissMsg.ShowInfo("FrmKaAMMBescheinigung", "JahrLeer", "Jahr darf nicht leer sein!");
                xTabControl1.SelectedTabIndex = 1;
                edtJahr.Focus();
                return;
            }

            this.ctlGotoFall.ResetFallIcons();

            if (xTabControl1.SelectedTabIndex == 1)
                Suchen(false);
            else
            {
                xTabControl1.SelectedTabIndex = 1;
                NeueSuche();
            }
        }

        private void btnAbbruch_Click(object sender, System.EventArgs e)
        {
            abbruch = KissMsg.ShowQuestion("FrmKaAMMBescheinigung", "MassendruckAbbrechen", "Soll der Massendruck abgebrochen werden?");
        }

        private void btnAbfragen_Click(object sender, System.EventArgs e)
        {
            ((KissMainForm)Session.MainForm).OpenChildForm(typeof(Query.FrmDataExplorer));
            Query.FrmDataExplorer frmDataEx = (Query.FrmDataExplorer)((KissMainForm)Session.MainForm).GetChildForm(typeof(Query.FrmDataExplorer));
        }

        private void btnDeselectAll_Click(object sender, System.EventArgs e)
        {
            Suchen(false);
        }

        private void btnMassendruck_Click(object sender, System.EventArgs e)
        {
            this.OnPrint();
        }

        private void btnSelectAll_Click(object sender, System.EventArgs e)
        {
            Suchen(true);
        }

        private void dlgCoachX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.MitarbeiterSuchen(dlgCoachX.Text, e.ButtonClicked))
            {
                dlgCoachX.EditValue = dlg["Name"];
                dlgCoachX.LookupID = dlg["UserID"];
            }
            else
                e.Cancel = true;
        }

        private void dlgKlientX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.KAPersonSuchen(dlgKlientX.Text, e.ButtonClicked))
            {
                dlgKlientX.EditValue = dlg["Name"];
                dlgKlientX.LookupID = dlg["BaPersonID"];
            }
            else
                e.Cancel = true;
        }

        private void grvAMMBesch_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == this.colInfo || e.Column == this.colKlient || e.Column == this.colMonatJahr || e.Column == this.colPrinted || e.Column == this.colZustKA)
            {
                //e.CellStyle = this.grdAMMBesch.Styles["Style6"];
                e.Appearance.BackColor = KaUtil.ColReadOnly;
            }
        }

        private void qryAMMBesch_BeforePost(object sender, System.EventArgs e)
        {
            qryAMMBesch.Row.AcceptChanges();
            qryAMMBesch.RowModified = false;
        }

        private void qryAMMBesch_PositionChanged(object sender, System.EventArgs e)
        {
            this.ctlGotoFall.BaPersonID = qryAMMBesch["BaPersonID"];
        }

        #endregion

        #region Methods

        #region Private Methods

        private void NeueSuche()
        {
            foreach (Control ctl in tpgSearch.Controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit)
                    ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue = null;
            }

            ddlMonatX.EditValue = DateTime.Today.Month;
            edtJahr.EditValue = DateTime.Today.Year;
            chkInklusiveArt59d.Checked = true;
            chkInklusiveALV.Checked = true;

            dlgCoachX.Focus();
        }

        private void Suchen(bool selectAll)
        {
            if (!DBUtil.IsEmpty(ddlMonatX.EditValue) && !DBUtil.IsEmpty(edtJahr.EditValue))
            {
                DBUtil.ExecSQL(@"EXEC spKaFillAMMBesch {0},{1}", ddlMonatX.EditValue.ToString(), edtJahr.EditValue.ToString());
            }

            int iSelPrint = -1;

            if (selectAll)
                iSelPrint = 1;
            else
                iSelPrint = 0;

            //			Sql += @"					Info = dbo.fnLOVText('KaAnweisung', KAE.AnweisungCode)
            //										+ ' von ' + CONVERT(VARCHAR, Day(KAE.DatumVon)) + '.' + CONVERT(VARCHAR, Month(KAE.DatumVon)) + '.' + CONVERT(VARCHAR, Year(KAE.DatumVon))
            //										+ ' bis ' + CONVERT(VARCHAR, Day(KAE.DatumBis)) + '.' + CONVERT(VARCHAR, Month(KAE.DatumBis)) + '.' + CONVERT(VARCHAR, Year(KAE.DatumBis))
            //										+ '; Beschäftigungsgrad ' + CONVERT(VARCHAR, IsNull(KAE.BeschGrad, 0)) + '%'

            string Sql = @"	SELECT	AMM.*,
                                    Klient = PRS.Name + isNull(', ' + PRS.Vorname,''),
                                    ZustKA = USR.LastName + isNull(', ' + USR.FirstName,''),
                                    MonatJahr = dbo.fnXKurzMonat(Monat) + ' ' + Convert(varchar, Jahr),
                                    printed = Convert(bit, gedrucktFlag), ";
            Sql += @" SelPrint = Convert(bit, " + iSelPrint + "), ";
            Sql += @"					Info = CONVERT(VARCHAR, Day(AMM.DatumVon)) + '.' + CONVERT(VARCHAR, Month(AMM.DatumVon)) + '.' + CONVERT(VARCHAR, Year(AMM.DatumVon))
                                        + ' - ' + CONVERT(VARCHAR, Day(AMM.DatumBis)) + '.' + CONVERT(VARCHAR, Month(AMM.DatumBis)) + '.' + CONVERT(VARCHAR, Year(AMM.DatumBis))
                            FROM KaAMMBesch AMM
                                LEFT JOIN BaPerson PRS ON PRS.BaPersonID = AMM.BaPersonID
                                LEFT JOIN XUser USR ON USR.UserID = AMM.ZustaendigKAID
                                LEFT JOIN KaEinsatz KAE ON KAE.KaEinsatzID = AMM.KaEinsatzID
                            WHERE 1=1 ";

            if (!DBUtil.IsEmpty(ddlMonatX.EditValue))
            {
                Sql += " AND AMM.Monat = " + ddlMonatX.EditValue.ToString() + " ";
            }

            if (!DBUtil.IsEmpty(edtJahr.EditValue))
            {
                Sql += " AND AMM.Jahr = " + edtJahr.EditValue.ToString() + " ";
            }

            if (!DBUtil.IsEmpty(dlgKlientX.EditValue))
            {
                Sql += " AND AMM.BaPersonID = " + dlgKlientX.LookupID.ToString() + " ";
            }

            if (!DBUtil.IsEmpty(dlgCoachX.EditValue))
            {
                Sql += " AND AMM.ZustaendigKAID = " + dlgCoachX.LookupID.ToString() + " ";
            }

            if (!DBUtil.IsEmpty(ddlProfilX.EditValue))
            {
                Sql += " AND AMM.ProfilCode = " + ddlProfilX.EditValue.ToString() + " ";
            }

            // APV-Nr
            if (!DBUtil.IsEmpty(ddlAPVNrX.EditValue))
            {
                Sql += " AND KAE.KaEinsatzplatzID = " + ddlAPVNrX.EditValue.ToString();
            }

            // APV Zusatz Code
            Sql += " AND KAE.APVZusatzCode IN (";
            if (chkInklusiveArt59d.Checked)
            {
                Sql += "2,";
            }
            if (chkInklusiveALV.Checked)
            {
                Sql += "1,";
            }
            Sql += "-1) ";

            Sql += " ORDER BY PRS.Name, PRS.Vorname, Jahr, Monat ";

            qryAMMBesch.Fill(Sql);

            lblRowCount.Text = qryAMMBesch.Count.ToString();
            this.xTabControl1.SelectedTabIndex = 0;
        }

        #endregion

        #endregion
    }
}