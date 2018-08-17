using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.ZH
{
    public class CtlArchiveManagement : KissUserControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnArchivieren;
        private KiSS4.Gui.KissButton btnArchivWechsel;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnSearch;
        private KiSS4.Gui.KissButton btnZurueckholen;
        private KiSS4.Gui.KissButton button2;
        private KiSS4.Gui.KissButton button3;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiviert;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivNr;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivNr2;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckIn;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckInUser;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOut;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOutUser;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSortKey;
        private DevExpress.XtraGrid.Columns.GridColumn colStandort;
        private DevExpress.XtraGrid.Columns.GridColumn colStandort2;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserI1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID2;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit editAHVNr;
        private KiSS4.Gui.KissTextEdit editArchivNr;
        private KiSS4.Gui.KissTextEdit editArchivNrX;
        private KiSS4.Gui.KissLookUpEdit editArchivStandort;
        private KiSS4.Gui.KissLookUpEdit editModulX;
        private KiSS4.Gui.KissTextEdit editName;
        private KiSS4.Gui.KissTextEdit editNNummerX;
        private KiSS4.Gui.KissTextEdit editPersonX;
        private KiSS4.Gui.KissButtonEdit editSAR;
        private KiSS4.Gui.KissButtonEdit editSARX;
        private KiSS4.Gui.KissLookUpEdit editStandortX;
        private KiSS4.Gui.KissLookUpEdit editStatusX;
        private KiSS4.Gui.KissCalcEdit edtSortKey;
        private KiSS4.Gui.KissGrid Grid;
        private KiSS4.Gui.KissGrid gridControl1;
        private KiSS4.Gui.KissGrid gridHistory;
        private KiSS4.Gui.KissGrid gridVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private KiSS4.Gui.KissGrid gridZugeteilt;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissMemoEdit kissMemoEdit1;
        private KiSS4.Gui.KissMemoEdit kissMemoEdit2;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private KiSS4.Gui.KissLabel label25;
        private KiSS4.Gui.KissLabel lblName;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblSortKey;
        private System.Windows.Forms.Label lblTitle;
        private bool MayAdd = false;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.DB.SqlQuery qryArchive;
        private KiSS4.DB.SqlQuery qryFall;
        private KiSS4.DB.SqlQuery qryHistory;
        private KiSS4.DB.SqlQuery qryKandidaten;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissTabControlEx tabArchiv;
        private KiSS4.Gui.KissTabControlEx tabControl1;
        private SharpLibrary.WinControls.TabPageEx tabListe;
        private SharpLibrary.WinControls.TabPageEx tabPageListe;
        private SharpLibrary.WinControls.TabPageEx tabPageSuchen;
        private SharpLibrary.WinControls.TabPageEx tabSuchen;

        #endregion

        #region Constructors

        public CtlArchiveManagement()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabArchiv = new KiSS4.Gui.KissTabControlEx();
            this.tabSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSortKey = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.gridZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.gridVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryKandidaten = new KiSS4.DB.SqlQuery();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissMemoEdit1 = new KiSS4.Gui.KissMemoEdit();
            this.qryArchive = new KiSS4.DB.SqlQuery();
            this.kissMemoEdit2 = new KiSS4.Gui.KissMemoEdit();
            this.edtSortKey = new KiSS4.Gui.KissCalcEdit();
            this.editName = new KiSS4.Gui.KissTextEdit();
            this.Grid = new KiSS4.Gui.KissGrid();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabListe = new SharpLibrary.WinControls.TabPageEx();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.qryFall = new KiSS4.DB.SqlQuery();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.btnZurueckholen = new KiSS4.Gui.KissButton();
            this.editSAR = new KiSS4.Gui.KissButtonEdit();
            this.btnArchivWechsel = new KiSS4.Gui.KissButton();
            this.btnArchivieren = new KiSS4.Gui.KissButton();
            this.editArchivStandort = new KiSS4.Gui.KissLookUpEdit();
            this.editArchivNr = new KiSS4.Gui.KissTextEdit();
            this.gridHistory = new KiSS4.Gui.KissGrid();
            this.qryHistory = new KiSS4.DB.SqlQuery();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStandort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckInUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOutUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tabPageSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.label25 = new KiSS4.Gui.KissLabel();
            this.editArchivNrX = new KiSS4.Gui.KissTextEdit();
            this.editStatusX = new KiSS4.Gui.KissLookUpEdit();
            this.editStandortX = new KiSS4.Gui.KissLookUpEdit();
            this.editSARX = new KiSS4.Gui.KissButtonEdit();
            this.editModulX = new KiSS4.Gui.KissLookUpEdit();
            this.editNNummerX = new KiSS4.Gui.KissTextEdit();
            this.editAHVNr = new KiSS4.Gui.KissTextEdit();
            this.editPersonX = new KiSS4.Gui.KissTextEdit();
            this.button3 = new KiSS4.Gui.KissButton();
            this.btnSearch = new KiSS4.Gui.KissButton();
            this.tabPageListe = new SharpLibrary.WinControls.TabPageEx();
            this.button2 = new KiSS4.Gui.KissButton();
            this.gridControl1 = new KiSS4.Gui.KissGrid();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colArchiviert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandort2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivNr2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabArchiv.SuspendLayout();
            this.tabSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryArchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.tabListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageSuchen.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNNummerX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAHVNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPersonX.Properties)).BeginInit();
            this.tabPageListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            //
            // tabArchiv
            //
            this.tabArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabArchiv.Controls.Add(this.tabSuchen);
            this.tabArchiv.Controls.Add(this.tabListe);
            this.tabArchiv.Location = new System.Drawing.Point(5, 5);
            this.tabArchiv.Name = "tabArchiv";
            this.tabArchiv.SelectedTabIndex = 1;
            this.tabArchiv.ShowFixedWidthTooltip = true;
            this.tabArchiv.Size = new System.Drawing.Size(966, 574);
            this.tabArchiv.TabIndex = 64;
            this.tabArchiv.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabListe,
            this.tabSuchen});
            this.tabArchiv.TabsLineColor = System.Drawing.Color.Black;
            this.tabArchiv.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            //
            // tabSuchen
            //
            this.tabSuchen.Controls.Add(this.label1);
            this.tabSuchen.Controls.Add(this.lblSortKey);
            this.tabSuchen.Controls.Add(this.kissLabel10);
            this.tabSuchen.Controls.Add(this.gridZugeteilt);
            this.tabSuchen.Controls.Add(this.kissLabel11);
            this.tabSuchen.Controls.Add(this.btnRemoveAll);
            this.tabSuchen.Controls.Add(this.btnAddAll);
            this.tabSuchen.Controls.Add(this.lblName);
            this.tabSuchen.Controls.Add(this.btnRemove);
            this.tabSuchen.Controls.Add(this.btnAdd);
            this.tabSuchen.Controls.Add(this.gridVerfuegbar);
            this.tabSuchen.Controls.Add(this.kissMemoEdit1);
            this.tabSuchen.Controls.Add(this.kissMemoEdit2);
            this.tabSuchen.Controls.Add(this.edtSortKey);
            this.tabSuchen.Controls.Add(this.editName);
            this.tabSuchen.Controls.Add(this.Grid);
            this.tabSuchen.Location = new System.Drawing.Point(6, 6);
            this.tabSuchen.Name = "tabSuchen";
            this.tabSuchen.Size = new System.Drawing.Size(954, 536);
            this.tabSuchen.TabIndex = 1;
            this.tabSuchen.Title = "Archivstandorte";
            //
            // label1
            //
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Archivstandorte";
            this.label1.UseCompatibleTextRendering = true;
            //
            // lblSortKey
            //
            this.lblSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSortKey.Location = new System.Drawing.Point(540, 189);
            this.lblSortKey.Name = "lblSortKey";
            this.lblSortKey.Size = new System.Drawing.Size(65, 24);
            this.lblSortKey.TabIndex = 30;
            this.lblSortKey.Text = "Reihenfolge";
            this.lblSortKey.UseCompatibleTextRendering = true;
            //
            // kissLabel10
            //
            this.kissLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel10.Location = new System.Drawing.Point(43, 214);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(76, 24);
            this.kissLabel10.TabIndex = 29;
            this.kissLabel10.Text = "Adresse";
            this.kissLabel10.UseCompatibleTextRendering = true;
            //
            // gridZugeteilt
            //
            this.gridZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gridZugeteilt.DataSource = this.qryZugeteilt;
            //
            //
            //
            this.gridZugeteilt.EmbeddedNavigator.Name = "";
            this.gridZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridZugeteilt.Location = new System.Drawing.Point(355, 320);
            this.gridZugeteilt.MainView = this.gridView4;
            this.gridZugeteilt.Name = "gridZugeteilt";
            this.gridZugeteilt.Size = new System.Drawing.Size(288, 214);
            this.gridZugeteilt.TabIndex = 28;
            this.gridZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            this.gridZugeteilt.DoubleClick += new System.EventHandler(this.gridZugeteilt_DoubleClick);
            //
            // qryZugeteilt
            //
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "XUser_Archive";
            //
            // gridView4
            //
            this.gridView4.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView4.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Empty.Options.UseBackColor = true;
            this.gridView4.Appearance.Empty.Options.UseFont = true;
            this.gridView4.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.EvenRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView4.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView4.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.OddRow.Options.UseFont = true;
            this.gridView4.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Row.Options.UseBackColor = true;
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView4.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID1,
            this.colUserI1});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView4.GridControl = this.gridZugeteilt;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsNavigation.UseTabKey = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            //
            // colUserID1
            //
            this.colUserID1.Caption = "Zugeteilte Gruppen";
            this.colUserID1.FieldName = "UserID";
            this.colUserID1.Name = "colUserID1";
            this.colUserID1.Width = 243;
            //
            // colUserI1
            //
            this.colUserI1.Caption = "Archivaren";
            this.colUserI1.FieldName = "UserName";
            this.colUserI1.Name = "colUserI1";
            this.colUserI1.Visible = true;
            this.colUserI1.VisibleIndex = 0;
            this.colUserI1.Width = 264;
            //
            // kissLabel11
            //
            this.kissLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel11.Location = new System.Drawing.Point(301, 214);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(76, 24);
            this.kissLabel11.TabIndex = 27;
            this.kissLabel11.Text = "Beschreibung";
            this.kissLabel11.UseCompatibleTextRendering = true;
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.Location = new System.Drawing.Point(310, 458);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 26;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // btnAddAll
            //
            this.btnAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.Location = new System.Drawing.Point(310, 428);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 25;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            //
            // lblName
            //
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Location = new System.Drawing.Point(5, 189);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(33, 24);
            this.lblName.TabIndex = 24;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // btnRemove
            //
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(310, 398);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(310, 368);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // gridVerfuegbar
            //
            this.gridVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gridVerfuegbar.DataSource = this.qryKandidaten;
            //
            //
            //
            this.gridVerfuegbar.EmbeddedNavigator.Name = "";
            this.gridVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridVerfuegbar.Location = new System.Drawing.Point(5, 320);
            this.gridVerfuegbar.MainView = this.gridView2;
            this.gridVerfuegbar.Name = "gridVerfuegbar";
            this.gridVerfuegbar.Size = new System.Drawing.Size(288, 214);
            this.gridVerfuegbar.TabIndex = 5;
            this.gridVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            //
            // qryKandidaten
            //
            this.qryKandidaten.HostControl = this;
            //
            // gridView2
            //
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser2,
            this.colUserID2});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridVerfuegbar;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            //
            // colUser2
            //
            this.colUser2.Caption = "Kandidaten";
            this.colUser2.FieldName = "UserName";
            this.colUser2.Name = "colUser2";
            this.colUser2.Visible = true;
            this.colUser2.VisibleIndex = 0;
            this.colUser2.Width = 264;
            //
            // colUserID2
            //
            this.colUserID2.Caption = "-";
            this.colUserID2.FieldName = "UserID";
            this.colUserID2.Name = "colUserID2";
            //
            // kissMemoEdit1
            //
            this.kissMemoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissMemoEdit1.DataMember = "Remark";
            this.kissMemoEdit1.DataSource = this.qryArchive;
            this.kissMemoEdit1.Location = new System.Drawing.Point(301, 238);
            this.kissMemoEdit1.Name = "kissMemoEdit1";
            this.kissMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissMemoEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit1.Size = new System.Drawing.Size(342, 69);
            this.kissMemoEdit1.TabIndex = 4;
            //
            // qryArchive
            //
            this.qryArchive.HostControl = this;
            this.qryArchive.TableName = "XArchive";
            this.qryArchive.AfterInsert += new System.EventHandler(this.qryArchive_AfterInsert);
            this.qryArchive.BeforePost += new System.EventHandler(this.qryArchive_BeforePost);
            this.qryArchive.PositionChanged += new System.EventHandler(this.qryArchive_PositionChanged);
            //
            // kissMemoEdit2
            //
            this.kissMemoEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissMemoEdit2.DataMember = "Address";
            this.kissMemoEdit2.DataSource = this.qryArchive;
            this.kissMemoEdit2.Location = new System.Drawing.Point(44, 238);
            this.kissMemoEdit2.Name = "kissMemoEdit2";
            this.kissMemoEdit2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissMemoEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit2.Size = new System.Drawing.Size(244, 71);
            this.kissMemoEdit2.TabIndex = 3;
            //
            // edtSortKey
            //
            this.edtSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSortKey.DataMember = "SortKey";
            this.edtSortKey.DataSource = this.qryArchive;
            this.edtSortKey.Location = new System.Drawing.Point(607, 189);
            this.edtSortKey.Name = "edtSortKey";
            this.edtSortKey.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseFont = true;
            this.edtSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSortKey.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtSortKey.Size = new System.Drawing.Size(35, 24);
            this.edtSortKey.TabIndex = 2;
            //
            // editName
            //
            this.editName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editName.DataMember = "Name";
            this.editName.DataSource = this.qryArchive;
            this.editName.Location = new System.Drawing.Point(44, 189);
            this.editName.Name = "editName";
            this.editName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editName.Properties.Appearance.Options.UseBackColor = true;
            this.editName.Properties.Appearance.Options.UseBorderColor = true;
            this.editName.Properties.Appearance.Options.UseFont = true;
            this.editName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editName.Size = new System.Drawing.Size(479, 24);
            this.editName.TabIndex = 1;
            //
            // Grid
            //
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Grid.DataSource = this.qryArchive;
            //
            //
            //
            this.Grid.EmbeddedNavigator.Name = "";
            this.Grid.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.Grid.Location = new System.Drawing.Point(5, 32);
            this.Grid.MainView = this.gridView5;
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(637, 144);
            this.Grid.TabIndex = 0;
            this.Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            //
            // gridView5
            //
            this.gridView5.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView5.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.Empty.Options.UseBackColor = true;
            this.gridView5.Appearance.Empty.Options.UseFont = true;
            this.gridView5.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.EvenRow.Options.UseFont = true;
            this.gridView5.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView5.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView5.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView5.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView5.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView5.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView5.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView5.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView5.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView5.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView5.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupRow.Options.UseFont = true;
            this.gridView5.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView5.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView5.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView5.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView5.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView5.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView5.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView5.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView5.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView5.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView5.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView5.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView5.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.OddRow.Options.UseFont = true;
            this.gridView5.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView5.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.Row.Options.UseBackColor = true;
            this.gridView5.Appearance.Row.Options.UseFont = true;
            this.gridView5.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView5.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView5.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView5.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSortKey});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView5.GridControl = this.Grid;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsCustomization.AllowFilter = false;
            this.gridView5.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView5.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView5.OptionsNavigation.UseTabKey = false;
            this.gridView5.OptionsView.ColumnAutoWidth = false;
            this.gridView5.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 526;
            //
            // colSortKey
            //
            this.colSortKey.Caption = "Reihenfolge";
            this.colSortKey.FieldName = "SortKey";
            this.colSortKey.Name = "colSortKey";
            this.colSortKey.Visible = true;
            this.colSortKey.VisibleIndex = 1;
            this.colSortKey.Width = 88;
            //
            // tabListe
            //
            this.tabListe.Controls.Add(this.kissTextEdit2);
            this.tabListe.Controls.Add(this.kissTextEdit1);
            this.tabListe.Controls.Add(this.kissLabel17);
            this.tabListe.Controls.Add(this.kissLabel16);
            this.tabListe.Controls.Add(this.lblRowCount);
            this.tabListe.Controls.Add(this.label2);
            this.tabListe.Controls.Add(this.kissLabel5);
            this.tabListe.Controls.Add(this.kissLabel3);
            this.tabListe.Controls.Add(this.kissLabel2);
            this.tabListe.Controls.Add(this.kissLabel1);
            this.tabListe.Controls.Add(this.btnZurueckholen);
            this.tabListe.Controls.Add(this.editSAR);
            this.tabListe.Controls.Add(this.btnArchivWechsel);
            this.tabListe.Controls.Add(this.btnArchivieren);
            this.tabListe.Controls.Add(this.editArchivStandort);
            this.tabListe.Controls.Add(this.editArchivNr);
            this.tabListe.Controls.Add(this.gridHistory);
            this.tabListe.Controls.Add(this.lblTitle);
            this.tabListe.Controls.Add(this.tabControl1);
            this.tabListe.Location = new System.Drawing.Point(6, 6);
            this.tabListe.Name = "tabListe";
            this.tabListe.Size = new System.Drawing.Size(954, 536);
            this.tabListe.TabIndex = 0;
            this.tabListe.Title = "Archivieren";
            //
            // kissTextEdit2
            //
            this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit2.DataMember = "NNummer";
            this.kissTextEdit2.DataSource = this.qryFall;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(800, 328);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(137, 24);
            this.kissTextEdit2.TabIndex = 53;
            //
            // qryFall
            //
            this.qryFall.HostControl = this;
            this.qryFall.TableName = "FaFall";
            this.qryFall.PositionChanged += new System.EventHandler(this.qryFall_PositionChanged);
            //
            // kissTextEdit1
            //
            this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit1.DataMember = "AHVNummer";
            this.kissTextEdit1.DataSource = this.qryFall;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(800, 298);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(137, 24);
            this.kissTextEdit1.TabIndex = 52;
            //
            // kissLabel17
            //
            this.kissLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel17.Location = new System.Drawing.Point(742, 328);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(84, 24);
            this.kissLabel17.TabIndex = 49;
            this.kissLabel17.Text = "N-Nummer";
            this.kissLabel17.UseCompatibleTextRendering = true;
            //
            // kissLabel16
            //
            this.kissLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel16.Location = new System.Drawing.Point(742, 298);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(84, 24);
            this.kissLabel16.TabIndex = 48;
            this.kissLabel16.Text = "AHV-Nr.";
            this.kissLabel16.UseCompatibleTextRendering = true;
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Location = new System.Drawing.Point(907, 267);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(44, 16);
            this.lblRowCount.TabIndex = 47;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            //
            // label2
            //
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(804, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Anzahl Datensätze:";
            this.label2.UseCompatibleTextRendering = true;
            //
            // kissLabel5
            //
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.Location = new System.Drawing.Point(7, 298);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(84, 24);
            this.kissLabel5.TabIndex = 45;
            this.kissLabel5.Text = "Neue Archiv-Nr.";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // kissLabel3
            //
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel3.Location = new System.Drawing.Point(367, 298);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(60, 24);
            this.kissLabel3.TabIndex = 44;
            this.kissLabel3.Text = "Neuer SAR";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // kissLabel2
            //
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel2.Location = new System.Drawing.Point(5, 394);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(100, 16);
            this.kissLabel2.TabIndex = 43;
            this.kissLabel2.Text = "Archiv-History";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.Location = new System.Drawing.Point(7, 328);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(84, 24);
            this.kissLabel1.TabIndex = 42;
            this.kissLabel1.Text = "Neuer Standort";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // btnZurueckholen
            //
            this.btnZurueckholen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZurueckholen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZurueckholen.Location = new System.Drawing.Point(436, 362);
            this.btnZurueckholen.Name = "btnZurueckholen";
            this.btnZurueckholen.Size = new System.Drawing.Size(96, 24);
            this.btnZurueckholen.TabIndex = 41;
            this.btnZurueckholen.Text = "Zurückholen";
            this.btnZurueckholen.UseCompatibleTextRendering = true;
            this.btnZurueckholen.UseVisualStyleBackColor = false;
            this.btnZurueckholen.Click += new System.EventHandler(this.btnZurueckholen_Click);
            //
            // editSAR
            //
            this.editSAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editSAR.Location = new System.Drawing.Point(436, 298);
            this.editSAR.Name = "editSAR";
            this.editSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSAR.Properties.Appearance.Options.UseBackColor = true;
            this.editSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.editSAR.Properties.Appearance.Options.UseFont = true;
            this.editSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSAR.Properties.ReadOnly = true;
            this.editSAR.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editSAR.Size = new System.Drawing.Size(239, 24);
            this.editSAR.TabIndex = 40;
            this.editSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSAR_UserModifiedFld);
            //
            // btnArchivWechsel
            //
            this.btnArchivWechsel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArchivWechsel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivWechsel.Location = new System.Drawing.Point(201, 362);
            this.btnArchivWechsel.Name = "btnArchivWechsel";
            this.btnArchivWechsel.Size = new System.Drawing.Size(96, 24);
            this.btnArchivWechsel.TabIndex = 39;
            this.btnArchivWechsel.Text = "Archivwechsel";
            this.btnArchivWechsel.UseCompatibleTextRendering = true;
            this.btnArchivWechsel.UseVisualStyleBackColor = false;
            this.btnArchivWechsel.Click += new System.EventHandler(this.btnArchivWechsel_Click);
            //
            // btnArchivieren
            //
            this.btnArchivieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArchivieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivieren.Location = new System.Drawing.Point(95, 362);
            this.btnArchivieren.Name = "btnArchivieren";
            this.btnArchivieren.Size = new System.Drawing.Size(96, 24);
            this.btnArchivieren.TabIndex = 38;
            this.btnArchivieren.Text = "Archivieren";
            this.btnArchivieren.UseCompatibleTextRendering = true;
            this.btnArchivieren.UseVisualStyleBackColor = false;
            this.btnArchivieren.Click += new System.EventHandler(this.btnArchivieren_Click);
            //
            // editArchivStandort
            //
            this.editArchivStandort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editArchivStandort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editArchivStandort.Location = new System.Drawing.Point(95, 328);
            this.editArchivStandort.Name = "editArchivStandort";
            this.editArchivStandort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editArchivStandort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArchivStandort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivStandort.Properties.Appearance.Options.UseBackColor = true;
            this.editArchivStandort.Properties.Appearance.Options.UseBorderColor = true;
            this.editArchivStandort.Properties.Appearance.Options.UseFont = true;
            this.editArchivStandort.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editArchivStandort.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivStandort.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editArchivStandort.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editArchivStandort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editArchivStandort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editArchivStandort.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editArchivStandort.Properties.NullText = "";
            this.editArchivStandort.Properties.ReadOnly = true;
            this.editArchivStandort.Properties.ShowFooter = false;
            this.editArchivStandort.Properties.ShowHeader = false;
            this.editArchivStandort.Size = new System.Drawing.Size(239, 24);
            this.editArchivStandort.TabIndex = 37;
            //
            // editArchivNr
            //
            this.editArchivNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editArchivNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editArchivNr.Location = new System.Drawing.Point(95, 298);
            this.editArchivNr.Name = "editArchivNr";
            this.editArchivNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editArchivNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArchivNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivNr.Properties.Appearance.Options.UseBackColor = true;
            this.editArchivNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editArchivNr.Properties.Appearance.Options.UseFont = true;
            this.editArchivNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editArchivNr.Properties.ReadOnly = true;
            this.editArchivNr.Size = new System.Drawing.Size(239, 24);
            this.editArchivNr.TabIndex = 36;
            //
            // gridHistory
            //
            this.gridHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHistory.DataSource = this.qryHistory;
            //
            //
            //
            this.gridHistory.EmbeddedNavigator.Name = "";
            this.gridHistory.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridHistory.Location = new System.Drawing.Point(5, 418);
            this.gridHistory.MainView = this.gridView1;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.Size = new System.Drawing.Size(947, 114);
            this.gridHistory.TabIndex = 35;
            this.gridHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // qryHistory
            //
            this.qryHistory.HostControl = this;
            //
            // gridView1
            //
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
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
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStandort,
            this.colArchivNr,
            this.colCheckIn,
            this.colCheckInUser,
            this.colCheckOut,
            this.colCheckOutUser});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridHistory;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            //
            // colStandort
            //
            this.colStandort.Caption = "Standort";
            this.colStandort.FieldName = "Standort";
            this.colStandort.Name = "colStandort";
            this.colStandort.Visible = true;
            this.colStandort.VisibleIndex = 0;
            this.colStandort.Width = 259;
            //
            // colArchivNr
            //
            this.colArchivNr.Caption = "Archiv-Nr.";
            this.colArchivNr.FieldName = "ArchivNr";
            this.colArchivNr.Name = "colArchivNr";
            this.colArchivNr.Visible = true;
            this.colArchivNr.VisibleIndex = 1;
            this.colArchivNr.Width = 129;
            //
            // colCheckIn
            //
            this.colCheckIn.Caption = "archiviert";
            this.colCheckIn.FieldName = "CheckIn";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.Visible = true;
            this.colCheckIn.VisibleIndex = 2;
            //
            // colCheckInUser
            //
            this.colCheckInUser.Caption = "durch";
            this.colCheckInUser.FieldName = "CheckInUserName";
            this.colCheckInUser.Name = "colCheckInUser";
            this.colCheckInUser.Visible = true;
            this.colCheckInUser.VisibleIndex = 3;
            this.colCheckInUser.Width = 150;
            //
            // colCheckOut
            //
            this.colCheckOut.Caption = "zurück";
            this.colCheckOut.FieldName = "CheckOut";
            this.colCheckOut.Name = "colCheckOut";
            this.colCheckOut.Visible = true;
            this.colCheckOut.VisibleIndex = 4;
            //
            // colCheckOutUser
            //
            this.colCheckOutUser.Caption = "durch";
            this.colCheckOutUser.FieldName = "CheckOutUserName";
            this.colCheckOutUser.Name = "colCheckOutUser";
            this.colCheckOutUser.Visible = true;
            this.colCheckOutUser.VisibleIndex = 5;
            this.colCheckOutUser.Width = 150;
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Archivieren";
            this.lblTitle.UseCompatibleTextRendering = true;
            //
            // tabControl1
            //
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageSuchen);
            this.tabControl1.Controls.Add(this.tabPageListe);
            this.tabControl1.Location = new System.Drawing.Point(5, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.ShowFixedWidthTooltip = true;
            this.tabControl1.Size = new System.Drawing.Size(945, 258);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabPageListe,
            this.tabPageSuchen});
            this.tabControl1.TabsLineColor = System.Drawing.Color.Black;
            this.tabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            //
            // tabPageSuchen
            //
            this.tabPageSuchen.Controls.Add(this.panel1);
            this.tabPageSuchen.Controls.Add(this.button3);
            this.tabPageSuchen.Controls.Add(this.btnSearch);
            this.tabPageSuchen.Location = new System.Drawing.Point(6, 6);
            this.tabPageSuchen.Name = "tabPageSuchen";
            this.tabPageSuchen.Size = new System.Drawing.Size(933, 220);
            this.tabPageSuchen.TabIndex = 1;
            this.tabPageSuchen.Title = "Suchen";
            //
            // panel1
            //
            this.panel1.Controls.Add(this.kissLabel15);
            this.panel1.Controls.Add(this.kissLabel14);
            this.panel1.Controls.Add(this.kissLabel13);
            this.panel1.Controls.Add(this.kissLabel8);
            this.panel1.Controls.Add(this.kissLabel4);
            this.panel1.Controls.Add(this.kissSearchTitel1);
            this.panel1.Controls.Add(this.kissLabel7);
            this.panel1.Controls.Add(this.kissLabel6);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.editArchivNrX);
            this.panel1.Controls.Add(this.editStatusX);
            this.panel1.Controls.Add(this.editStandortX);
            this.panel1.Controls.Add(this.editSARX);
            this.panel1.Controls.Add(this.editModulX);
            this.panel1.Controls.Add(this.editNNummerX);
            this.panel1.Controls.Add(this.editAHVNr);
            this.panel1.Controls.Add(this.editPersonX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 220);
            this.panel1.TabIndex = 12;
            //
            // kissLabel15
            //
            this.kissLabel15.Location = new System.Drawing.Point(6, 100);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(74, 24);
            this.kissLabel15.TabIndex = 280;
            this.kissLabel15.Text = "N-Nummer";
            this.kissLabel15.UseCompatibleTextRendering = true;
            //
            // kissLabel14
            //
            this.kissLabel14.Location = new System.Drawing.Point(5, 70);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(74, 24);
            this.kissLabel14.TabIndex = 278;
            this.kissLabel14.Text = "AHV-Nr";
            this.kissLabel14.UseCompatibleTextRendering = true;
            //
            // kissLabel13
            //
            this.kissLabel13.Location = new System.Drawing.Point(380, 70);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(52, 24);
            this.kissLabel13.TabIndex = 276;
            this.kissLabel13.Text = "Status";
            this.kissLabel13.UseCompatibleTextRendering = true;
            //
            // kissLabel8
            //
            this.kissLabel8.Location = new System.Drawing.Point(380, 100);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(74, 24);
            this.kissLabel8.TabIndex = 274;
            this.kissLabel8.Text = "Archiv-Nr.";
            this.kissLabel8.UseCompatibleTextRendering = true;
            //
            // kissLabel4
            //
            this.kissLabel4.Location = new System.Drawing.Point(380, 40);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(52, 24);
            this.kissLabel4.TabIndex = 272;
            this.kissLabel4.Text = "Standort";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // kissSearchTitel1
            //
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(10, 7);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 270;
            //
            // kissLabel7
            //
            this.kissLabel7.Location = new System.Drawing.Point(5, 143);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(38, 24);
            this.kissLabel7.TabIndex = 269;
            this.kissLabel7.Text = "Modul";
            this.kissLabel7.UseCompatibleTextRendering = true;
            //
            // kissLabel6
            //
            this.kissLabel6.Location = new System.Drawing.Point(5, 173);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(38, 24);
            this.kissLabel6.TabIndex = 268;
            this.kissLabel6.Text = "SAR";
            this.kissLabel6.UseCompatibleTextRendering = true;
            //
            // label25
            //
            this.label25.Location = new System.Drawing.Point(5, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 24);
            this.label25.TabIndex = 262;
            this.label25.Text = "Fallträger/-in";
            this.label25.UseCompatibleTextRendering = true;
            //
            // editArchivNrX
            //
            this.editArchivNrX.Location = new System.Drawing.Point(454, 100);
            this.editArchivNrX.Name = "editArchivNrX";
            this.editArchivNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editArchivNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArchivNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivNrX.Properties.Appearance.Options.UseBackColor = true;
            this.editArchivNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.editArchivNrX.Properties.Appearance.Options.UseFont = true;
            this.editArchivNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editArchivNrX.Size = new System.Drawing.Size(239, 24);
            this.editArchivNrX.TabIndex = 7;
            //
            // editStatusX
            //
            this.editStatusX.Location = new System.Drawing.Point(454, 70);
            this.editStatusX.Name = "editStatusX";
            this.editStatusX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStatusX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStatusX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStatusX.Properties.Appearance.Options.UseBackColor = true;
            this.editStatusX.Properties.Appearance.Options.UseBorderColor = true;
            this.editStatusX.Properties.Appearance.Options.UseFont = true;
            this.editStatusX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editStatusX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editStatusX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editStatusX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editStatusX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editStatusX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editStatusX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editStatusX.Properties.NullText = "";
            this.editStatusX.Properties.ShowFooter = false;
            this.editStatusX.Properties.ShowHeader = false;
            this.editStatusX.Size = new System.Drawing.Size(239, 24);
            this.editStatusX.TabIndex = 6;
            //
            // editStandortX
            //
            this.editStandortX.Location = new System.Drawing.Point(454, 40);
            this.editStandortX.Name = "editStandortX";
            this.editStandortX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStandortX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStandortX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStandortX.Properties.Appearance.Options.UseBackColor = true;
            this.editStandortX.Properties.Appearance.Options.UseBorderColor = true;
            this.editStandortX.Properties.Appearance.Options.UseFont = true;
            this.editStandortX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editStandortX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editStandortX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editStandortX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editStandortX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.editStandortX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.editStandortX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editStandortX.Properties.NullText = "";
            this.editStandortX.Properties.ShowFooter = false;
            this.editStandortX.Properties.ShowHeader = false;
            this.editStandortX.Size = new System.Drawing.Size(239, 24);
            this.editStandortX.TabIndex = 5;
            //
            // editSARX
            //
            this.editSARX.Location = new System.Drawing.Point(90, 173);
            this.editSARX.Name = "editSARX";
            this.editSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSARX.Properties.Appearance.Options.UseBackColor = true;
            this.editSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.editSARX.Properties.Appearance.Options.UseFont = true;
            this.editSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.editSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.editSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSARX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editSARX.Size = new System.Drawing.Size(239, 24);
            this.editSARX.TabIndex = 4;
            this.editSARX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSARX_UserModifiedFld);
            //
            // editModulX
            //
            this.editModulX.Location = new System.Drawing.Point(90, 143);
            this.editModulX.LOVName = "Modul";
            this.editModulX.Name = "editModulX";
            this.editModulX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editModulX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editModulX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editModulX.Properties.Appearance.Options.UseBackColor = true;
            this.editModulX.Properties.Appearance.Options.UseBorderColor = true;
            this.editModulX.Properties.Appearance.Options.UseFont = true;
            this.editModulX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editModulX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editModulX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editModulX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editModulX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.editModulX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.editModulX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editModulX.Properties.NullText = "";
            this.editModulX.Properties.ShowFooter = false;
            this.editModulX.Properties.ShowHeader = false;
            this.editModulX.Size = new System.Drawing.Size(239, 24);
            this.editModulX.TabIndex = 3;
            //
            // editNNummerX
            //
            this.editNNummerX.Location = new System.Drawing.Point(90, 100);
            this.editNNummerX.Name = "editNNummerX";
            this.editNNummerX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editNNummerX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editNNummerX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editNNummerX.Properties.Appearance.Options.UseBackColor = true;
            this.editNNummerX.Properties.Appearance.Options.UseBorderColor = true;
            this.editNNummerX.Properties.Appearance.Options.UseFont = true;
            this.editNNummerX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editNNummerX.Size = new System.Drawing.Size(239, 24);
            this.editNNummerX.TabIndex = 2;
            //
            // editAHVNr
            //
            this.editAHVNr.Location = new System.Drawing.Point(90, 70);
            this.editAHVNr.Name = "editAHVNr";
            this.editAHVNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAHVNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAHVNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAHVNr.Properties.Appearance.Options.UseBackColor = true;
            this.editAHVNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editAHVNr.Properties.Appearance.Options.UseFont = true;
            this.editAHVNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAHVNr.Size = new System.Drawing.Size(239, 24);
            this.editAHVNr.TabIndex = 1;
            //
            // editPersonX
            //
            this.editPersonX.Location = new System.Drawing.Point(90, 40);
            this.editPersonX.Name = "editPersonX";
            this.editPersonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPersonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPersonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPersonX.Properties.Appearance.Options.UseBackColor = true;
            this.editPersonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editPersonX.Properties.Appearance.Options.UseFont = true;
            this.editPersonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPersonX.Size = new System.Drawing.Size(239, 24);
            this.editPersonX.TabIndex = 0;
            //
            // button3
            //
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(613, 544);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 24);
            this.button3.TabIndex = 11;
            this.button3.Text = "neue Suche";
            this.button3.UseCompatibleTextRendering = true;
            this.button3.UseVisualStyleBackColor = false;
            //
            // btnSearch
            //
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(507, 544);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 24);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseCompatibleTextRendering = true;
            this.btnSearch.UseVisualStyleBackColor = false;
            //
            // tabPageListe
            //
            this.tabPageListe.Controls.Add(this.button2);
            this.tabPageListe.Controls.Add(this.gridControl1);
            this.tabPageListe.Location = new System.Drawing.Point(6, 6);
            this.tabPageListe.Name = "tabPageListe";
            this.tabPageListe.Size = new System.Drawing.Size(933, 220);
            this.tabPageListe.TabIndex = 0;
            this.tabPageListe.Title = "Liste";
            //
            // button2
            //
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(26585, 15968);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 24);
            this.button2.TabIndex = 25;
            this.button2.Text = "> Person";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = false;
            //
            // gridControl1
            //
            this.gridControl1.DataSource = this.qryFall;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView3;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(933, 220);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            //
            // gridView3
            //
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colArchiviert,
            this.colStandort2,
            this.colArchivNr2,
            this.colPerson,
            this.colModul,
            this.colSAR,
            this.colDatumVon,
            this.colDatumBis});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            //
            // colArchiviert
            //
            this.colArchiviert.Caption = "A";
            this.colArchiviert.FieldName = "A";
            this.colArchiviert.Name = "colArchiviert";
            this.colArchiviert.Visible = true;
            this.colArchiviert.VisibleIndex = 0;
            this.colArchiviert.Width = 20;
            //
            // colStandort2
            //
            this.colStandort2.Caption = "Standort";
            this.colStandort2.FieldName = "Standort";
            this.colStandort2.Name = "colStandort2";
            this.colStandort2.Visible = true;
            this.colStandort2.VisibleIndex = 1;
            this.colStandort2.Width = 209;
            //
            // colArchivNr2
            //
            this.colArchivNr2.Caption = "ArchivNr";
            this.colArchivNr2.FieldName = "ArchivNr";
            this.colArchivNr2.Name = "colArchivNr2";
            this.colArchivNr2.Visible = true;
            this.colArchivNr2.VisibleIndex = 2;
            this.colArchivNr2.Width = 109;
            //
            // colPerson
            //
            this.colPerson.Caption = "Fallträger/-in";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 3;
            this.colPerson.Width = 161;
            //
            // colModul
            //
            this.colModul.Caption = "Modul";
            this.colModul.FieldName = "Modul";
            this.colModul.Name = "colModul";
            this.colModul.Visible = true;
            this.colModul.VisibleIndex = 4;
            this.colModul.Width = 119;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 5;
            this.colSAR.Width = 150;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 6;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 7;
            //
            // CtlArchiveManagement
            //
            this.ActiveSQLQuery = this.qryFall;
            this.Controls.Add(this.tabArchiv);
            this.Name = "CtlArchiveManagement";
            this.Size = new System.Drawing.Size(979, 580);
            this.Load += new System.EventHandler(this.CtlArchiveManagement_Load);
            this.tabArchiv.ResumeLayout(false);
            this.tabSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryArchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.tabListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSuchen.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNNummerX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAHVNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPersonX.Properties)).EndInit();
            this.tabPageListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
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

        #region Private Methods

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (qryArchive.Count == 0 || qryKandidaten.Count == 0) return;
            if (!qryArchive.Post()) return;

            int[] RowHandles = gridVerfuegbar.View.GetSelectedRows();

            if (RowHandles == null) return;

            foreach (int RowHandle in RowHandles)
            {
                qryZugeteilt.Insert();
                qryZugeteilt["ArchiveID"] = qryArchive["ArchiveID"];
                qryZugeteilt["UserID"] = gridVerfuegbar.View.GetRowCellValue(
                    RowHandle, gridVerfuegbar.View.Columns["UserID"]);
                qryZugeteilt.Post();
            }

            DisplayUsers(true, true);
        }

        private void btnAddAll_Click(object sender, System.EventArgs e)
        {
            if (qryArchive.Count == 0) return;
            if (!qryArchive.Post()) return;

            //add only not yet assigned XUsers
            DBUtil.ExecSQL(
                "insert XUser_Archive (ArchiveID,UserID) " +
                "select {0}, USR.UserID " +
                "from XUser USR " +
                "     left join XUser_Archive UAR on UAR.UserID = USR.UserID and " +
                "                                    UAR.ArchiveID = {0} " +
                "where UAR.UserID is null ",
                qryArchive["ArchiveID"]);

            DisplayUsers(true, true);
        }

        private void btnArchivieren_Click(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(editArchivStandort.EditValue))
            {
                KissMsg.ShowInfo("CtlArchiveManagement", "NeuerStandortLeer", "Das Feld 'neuer Standort' darf nicht leer bleiben!");
                return;
            }

            if (!KissMsg.ShowQuestion("CtlArchiveManagement", "FallArchivieren", "Soll dieser Fall archiviert werden ?"))
                return;

            DBUtil.ExecSQL(
                "insert FaFallArchiv (ArchiveID, ArchivNr, FaFallID, CheckIn, CheckInUserID) " +
                "values ({0},{1},{2},getdate(),{3})",
                editArchivStandort.EditValue,
                editArchivNr.EditValue,
                qryFall["FaFallID"],
                Session.User.UserID);

            qryFall["A"] = true;
            qryFall["Standort"] = editArchivStandort.Text;
            qryFall["ArchivNr"] = editArchivNr.Text;
            qryFall["MayRemove"] = true;
            qryFall.Row.AcceptChanges();

            DisplayHistory();
        }

        private void btnArchivWechsel_Click(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(editArchivStandort.EditValue))
            {
                KissMsg.ShowInfo("CtlArchiveManagement", "NeuerStandortLeer", "Das Feld 'neuer Standort' darf nicht leer bleiben!");
                return;
            }

            if (editArchivStandort.EditValue.Equals(qryFall["ArchiveID"]))
            {
                KissMsg.ShowInfo("CtlArchiveManagement", "StandortNeuBishIdentisch", "Im Feld 'neuer Standort' ist der bisherige Standort erfasst!");
                return;
            }

            if (!KissMsg.ShowQuestion("CtlArchiveManagement", "InAnderesArchivVerschieben", "Soll dieser Fall in ein anderes Archiv verschoben werden ?"))
                return;

            SqlQuery qry = DBUtil.OpenSQL(@"
                select	FaFallArchivID, ArchivNr
                from	FaFallArchiv
                where	FaFallID = {0} and
                        CheckOut is null",
                qryFall["FaFallID"]);

            if (qry.Count == 0) return;

            DBUtil.ExecSQL(@"
                update FaFallArchiv
                set    CheckOut = getdate(), CheckOutUserID = {0}
                where  FaFallArchivID = {1}",
                Session.User.UserID,
                qry["FaFallArchivID"]);

            DBUtil.ExecSQL(
                "insert FaFallArchiv (ArchiveID, ArchivNr, FaFallID, CheckIn, CheckInUserID) " +
                "values ({0},{1},{2},getdate(),{3})",
                editArchivStandort.EditValue,
                editArchivNr.EditValue,
                qryFall["FaFallID"],
                Session.User.UserID);

            qryFall["A"] = true;
            qryFall["Standort"] = editArchivStandort.Text;
            qryFall["ArchivNr"] = editArchivNr.Text;

            qryFall.RowModified = false;
            qryFall.Row.AcceptChanges();

            DisplayHistory();
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (qryZugeteilt.Count == 0) return;

            qryZugeteilt.Delete();
            DisplayUsers(true, false);
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            if (qryArchive.Count == 0) return;
            if (!qryArchive.Post()) return;

            DBUtil.ExecSQL("delete from XUser_Archive where ArchiveID = {0}", qryArchive["ArchiveID"]);

            DisplayUsers(true, true);
        }

        private void btnZurueckholen_Click(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(editSAR.LookupID))
            {
                KissMsg.ShowInfo("CtlArchiveManagement", "NeuerSARLeer", "Das Feld 'Neuer SAR' darf nicht leer bleiben");
                return;
            }

            if (!KissMsg.ShowQuestion("CtlArchiveManagement", "AusArchivHolen", "Soll dieser Fall aus dem Archiv zurckgeholt werden ?"))
                return;

            DBUtil.ExecSQL(@"
                update FaFallArchiv
                set CheckOut = getdate(), CheckOutUserID = {0}
                where FaFallArchivID =
                      (select FaFallArchivID from FaFallArchiv where FaFallID = {1} and CheckOut is null)",
                Session.User.UserID,
                qryFall["FaFallID"]);

            DBUtil.ExecSQL(@"
                update FaFall
                set UserID = {0}
                where FaFallID = {1}",
                editSAR.LookupID,
                qryFall["FaFallID"]);

            qryFall["A"] = false;
            qryFall["Standort"] = DBNull.Value;
            qryFall["SAR"] = editSAR.EditValue;
            qryFall.RowModified = false;
            qryFall.Row.AcceptChanges();

            DisplayHistory();
        }

        private void CtlArchiveManagement_Load(object sender, System.EventArgs e)
        {
            this.tabArchiv.SelectedTabChanged += this.tabArchiv_SelectedTabChanged;

            qryArchive.Fill("select * from XArchive order by SortKey");
            qryZugeteilt.DeleteQuestion = null;

            tabArchiv.SelectedTabIndex = 0;
            this.ActiveSQLQuery = qryFall;

            gridControl1.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            //			tabControl1.SelectedTabIndex = 1;

            editModulX.Properties.DataSource = DBUtil.OpenSQL(@"
                select Code,Text,SortKey
                from   XLOVCode
                where  LOVName = 'Modul' and
                       Code <> 5
                union all
                SELECT -Code, IsNull(CONVERT(varchar(100),ShortText), Text), 5
                FROM XLOVCode
                WHERE LOVName = 'VmProzess'
                  AND Code BETWEEN 1 AND 9
                union all
                select null,null,-1
                order by SortKey,Code");

            editStatusX.Properties.DataSource = DBUtil.OpenSQL(@"
                select Code = convert(int,null),Text = convert(varchar,null)
                union all
                select 1,'geschlossen'
                union all
                select 2,'archiviert'
                order by Code");

            SqlQuery qry = DBUtil.OpenSQL(@"
                select  distinct Code = ARC.ArchiveID, Text = ARC.Name
                from	XArchive ARC
                        inner join XUser_Archive UAR on UAR.UserID = {0} and
                                                        UAR.ArchiveID = ARC.ArchiveID
                union
                select null,null
                order by Text",
                Session.User.UserID);

            MayAdd = qry.Count > 1;
            editArchivStandort.Properties.DataSource = qry;

            editStandortX.Properties.DataSource = DBUtil.OpenSQL(@"
                select  Code = ArchiveID, Text = Name
                from	XArchive
                order by SortKey");

            //Archivstandorte verwalten nur fr Admins
            qryArchive.CanDelete = Session.User.IsUserAdmin;
            qryArchive.CanInsert = Session.User.IsUserAdmin;
            qryArchive.CanUpdate = Session.User.IsUserAdmin;
            btnAdd.Enabled = Session.User.IsUserAdmin;
            btnAddAll.Enabled = Session.User.IsUserAdmin;
            btnRemove.Enabled = Session.User.IsUserAdmin;
            btnRemoveAll.Enabled = Session.User.IsUserAdmin;
        }

        private void DisplayHistory()
        {
            qryHistory.Fill(@"
                        select FAA.*,
                               Standort = ARC.Name,
                               CheckInUserName = USR1.Lastname + isnull(', ' + USR1.Firstname,''),
                               CheckOutUserName = USR2.Lastname + isnull(', ' + USR2.Firstname,'')
                        from   FaFallArchiv FAA
                               inner join XUser    USR1 on USR1.UserID = FAA.CheckInUserID
                               left  join XUser    USR2 on USR2.UserID = FAA.CheckOutUserID
                               left  join XArchive ARC  on ARC.ArchiveID = FAA.ArchiveID
                        where  FAA.FaFallID = {0}
                        order by CheckIn",
                        qryFall["FaFallID"]);

            // reset Add/Remove Fields
            btnArchivieren.Enabled = false;
            btnArchivWechsel.Enabled = false;
            btnZurueckholen.Enabled = false;
            editArchivNr.EditMode = EditModeType.ReadOnly;
            editArchivStandort.EditMode = EditModeType.ReadOnly;
            editSAR.EditMode = EditModeType.ReadOnly;

            editArchivStandort.EditValue = null;
            editArchivNr.EditValue = null;
            editSAR.EditValue = null;
            editSAR.LookupID = null;

            if (DBUtil.IsEmpty(qryFall["DatumBis"])) return; //Fall noch aktiv

            // enable Archiv-Buttons
            if ((bool)qryFall["A"] && (bool)qryFall["MayRemove"])
            {
                btnArchivWechsel.Enabled = true;
                editArchivStandort.EditMode = EditModeType.Normal;

                editArchivNr.EditValue = qryFall["ArchivNr"];
                editArchivNr.EditMode = EditModeType.Normal;

                btnZurueckholen.Enabled = true;
                editSAR.EditMode = EditModeType.Normal;
            }

            if (!(bool)qryFall["A"] && MayAdd)
            {
                btnArchivieren.Enabled = true;
                editArchivNr.EditMode = EditModeType.Normal;
                editArchivStandort.EditMode = EditModeType.Normal;
            }
        }

        private void DisplayUsers(bool refreshKandidaten, bool refreshZugeteilt)
        {
            if (refreshZugeteilt)
                qryZugeteilt.Fill(@"
                        select UAR.*, USR.Lastname + isnull(', ' + Firstname,'') UserName
                        from   XUser_Archive UAR
                               inner join XUser USR on USR.UserID = UAR.UserID
                        where  UAR.ArchiveID = {0}
                        order by UserName",
                    qryArchive["ArchiveID"]);

            if (refreshKandidaten)
                qryKandidaten.Fill(@"
                        select USR.UserID, USR.Lastname + isnull(', ' + Firstname,'') UserName
                        from   XUser USR
                               left join XUser_Archive UAR on UAR.UserID = USR.UserID and
                                                              UAR.ArchiveID = {0}
                        where  UAR.ArchiveID is null
                        order by UserName",
                    qryArchive["ArchiveID"]);
        }

        private void editSAR_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editSAR.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                editSAR.EditValue = dlg["Name"];
                editSAR.LookupID = dlg["UserID"];
            }
        }

        private void editSARX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editSARX.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                editSARX.EditValue = dlg["Name"];
                editSARX.LookupID = dlg["UserID"];
            }
        }

        private void gridZugeteilt_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.btnAdd.Enabled) this.btnAdd.PerformClick();

            if (this.btnRemove.Enabled) this.btnRemove.PerformClick();
        }

        private void NeueSuche()
        {
            foreach (Control C in panel1.Controls)
            {
                if (C is DevExpress.XtraEditors.BaseEdit)
                {
                    ((DevExpress.XtraEditors.BaseEdit)C).EditValue = null;
                }
            }
            editSARX.EditValue = null;

            //			editNurArchiviert.Checked = false;
            editPersonX.Focus();
        }

        private void qryArchive_AfterInsert(object sender, System.EventArgs e)
        {
            editName.Focus();
        }

        private void qryArchive_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(editName, lblName.Text);
            DBUtil.CheckNotNullField(edtSortKey, lblSortKey.Text);
        }

        private void qryArchive_PositionChanged(object sender, System.EventArgs e)
        {
            DisplayUsers(true, true);
        }

        private void qryFall_PositionChanged(object sender, System.EventArgs e)
        {
            DisplayHistory();
        }

        private void Suchen()
        {
            if (DBUtil.IsEmpty(editPersonX.EditValue) &&
                        DBUtil.IsEmpty(editAHVNr.EditValue) &&
                        DBUtil.IsEmpty(editNNummerX.EditValue) &&
                        DBUtil.IsEmpty(editModulX.EditValue) &&
                        DBUtil.IsEmpty(editSARX.EditValue) &&
                        DBUtil.IsEmpty(editArchivNrX.EditValue) &&
                        DBUtil.IsEmpty(editStandortX.EditValue) &&
                        DBUtil.IsEmpty(editStatusX.EditValue))
            {
                KissMsg.ShowInfo("CtlArchiveManagement", "Min1Suchfeld", "Mindestens ein Suchfeld muss ausgefüllt sein");
                return;
            }

            string Sql = @"
                        select FAL.*,
                               Person     = PRS.Name + isNull(', ' + PRS.Vorname1,''),
                               AHVNummer  = PRS.AHVNummer,
                               NNummer    = PRS.NNummer,
                               Modul      = case when FAL.ModulCode <> 5
                                              then MOD.Text
                                              else COALESCE(PRZ.ShortText, PRZ.Text, MOD.Text)
                                            end,
                               SAR        = USR.LastName + isNull(', ' + USR.FirstName,''),
                               SARKuerzel = USR.LogonName,
                               A          = convert(bit, case when FAR.FaFallID is null then 0 else 1 end),
                               MayRemove  = convert(bit, case when UAR.ArchiveID is null then 0 else 1 end),
                               FAR.ArchivNr,
                               ARC.ArchiveID,
                               Standort   = ARC.Name
                        from   FaFall FAL
                               inner join DmgPerson     PRS on PRS.DmgPersonID = FAL.DmgPersonID
                               inner join XUser         USR on USR.UserID = FAL.UserID
                               inner join XLOVCode      MOD on MOD.LOVName = 'Modul'     AND MOD.Code = FAL.ModulCode
                               left  join XLOVCode      PRZ ON PRZ.LOVName = 'VmProzess' AND PRZ.Code = FAL.VmProzessCode
                               left join  FaFallArchiv  FAR on FAR.FaFallID = FAL.FaFallID and
                                                               FAR.CheckOut is null
                               left join  XArchive      ARC on ARC.ArchiveID = FAR.ArchiveID
                               left join  XUser_Archive UAR on UAR.ArchiveID = FAR.ArchiveID and
                                                               UAR.UserID = " + Session.User.UserID.ToString() + @"
                        where  1 = 1 ";

            if (!DBUtil.IsEmpty(editPersonX.Text))
            {
                string Suchbegriff = editPersonX.Text;
                Suchbegriff = Suchbegriff.Replace("*", "%");
                Suchbegriff = Suchbegriff.Replace(" ", "%");
                Sql += " and PRS.Name + isNull(', ' + Vorname1,'') like " + DBUtil.SqlLiteral(Suchbegriff + "%");
            }

            if (!DBUtil.IsEmpty(editAHVNr.Text))
            {
                string Suchbegriff = editAHVNr.Text.Replace("*", "%");
                Sql += " and PRS.AHVNummer like " + DBUtil.SqlLiteral(Suchbegriff + "%");
            }

            if (!DBUtil.IsEmpty(editNNummerX.Text))
            {
                string Suchbegriff = editNNummerX.Text.Replace("*", "%");
                Sql += " and PRS.NNummer like " + DBUtil.SqlLiteral(Suchbegriff + "%");
            }

            if (!DBUtil.IsEmpty(editModulX.EditValue))
                if ((int)editModulX.EditValue >= 0)
                    Sql += " and FAL.ModulCode = " + DBUtil.SqlLiteral(editModulX.EditValue);
                else
                    Sql += " and FAL.ModulCode = 5 and FAL.VmProzessCode = " + DBUtil.SqlLiteral(-(int)editModulX.EditValue);

            if (!DBUtil.IsEmpty(editSARX.LookupID))
                Sql += " and USR.UserID = " + DBUtil.SqlLiteral(editSARX.LookupID);

            if (!DBUtil.IsEmpty(editStandortX.EditValue))
                Sql += " and FAR.ArchiveID = " + DBUtil.SqlLiteral(editStandortX.EditValue);

            if (!DBUtil.IsEmpty(editArchivNrX.Text))
            {
                string Suchbegriff = editArchivNrX.Text.Replace("*", "%").Replace(" ", "%");
                Sql += " and FAL.FaFallID in (select FaFallID from FaFallArchiv where ArchivNr like " + DBUtil.SqlLiteral(Suchbegriff + "%") + ") ";
            }

            if (!DBUtil.IsEmpty(editStatusX.EditValue))
                if ((int)editStatusX.EditValue == 1)
                    Sql += " and FAL.DatumBis is not null and FAR.FaFallID is null ";  //geschlossen
                else
                    Sql += " and FAR.FaFallID is not null ";  //archiviert

            Sql += "\r\n order by Person ";

            Cursor.Current = Cursors.WaitCursor;
            qryFall.Fill(Sql);
            Cursor.Current = Cursors.Default;
            lblRowCount.Text = qryFall.Count.ToString();
            tabControl1.SelectedTabIndex = 0;
        }

        private void tabArchiv_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabArchiv.SelectedTabIndex == 0)
                this.ActiveSQLQuery = qryFall;
            else
                this.ActiveSQLQuery = qryArchive;
        }

        #endregion
    }
}