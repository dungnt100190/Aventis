using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace KiSS4.Fallfuehrung.ZH
{
    public partial class CtlFaUnterlagenliste
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn ColFaUnterlagenKategorieID;
        private KiSS4.Gui.KissButton btnCollapse;
        private KiSS4.Gui.KissButton btnDrucken;
        private KiSS4.Gui.KissButton btnExpand;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzErhalten;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzNotwendig;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErhalten;
        private DevExpress.XtraGrid.Columns.GridColumn colErstelltDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErstelltOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colErstelltUser;
        private DevExpress.XtraGrid.Columns.GridColumn colGruppe;
        private DevExpress.XtraGrid.Columns.GridColumn colHatZusatzFeld;
        private DevExpress.XtraGrid.Columns.GridColumn colKurzname;
        private DevExpress.XtraGrid.Columns.GridColumn colMutiertDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colMutiertOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colMutiertUser;
        private DevExpress.XtraGrid.Columns.GridColumn colNotwendig;
        private DevExpress.XtraGrid.Columns.GridColumn colSortierung;
        private DevExpress.XtraGrid.Columns.GridColumn colTabSeite;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdMain;
        private KiSS4.Gui.KissGrid grdUnterlagen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwAll;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryUnterlagen;
        private KiSS4.DB.SqlQuery qryUnterlagenKategorie;
        private KiSS4.DB.SqlQuery qryUnterlagenliste;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repedtCheckBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private KiSS4.Gui.KissTabControlEx tabMain;
        private SharpLibrary.WinControls.TabPageEx tbpReiter0;
        private SharpLibrary.WinControls.TabPageEx tbpReiter1;
        private SharpLibrary.WinControls.TabPageEx tbpReiter2;
        private SharpLibrary.WinControls.TabPageEx tbpReiter3;
        private SharpLibrary.WinControls.TabPageEx tbpReiter4;
        private SharpLibrary.WinControls.TabPageEx tbpReiter5;
        private SharpLibrary.WinControls.TabPageEx tbpReiter6;
        private SharpLibrary.WinControls.TabPageEx tbpReiter7;
        private SharpLibrary.WinControls.TabPageEx tbpReiter8;
        private SharpLibrary.WinControls.TabPageEx tbpReiter9;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaUnterlagenliste));
            this.tabMain = new KiSS4.Gui.KissTabControlEx();
            this.tbpReiter9 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter8 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter7 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter4 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter6 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter5 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter3 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter2 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter1 = new SharpLibrary.WinControls.TabPageEx();
            this.tbpReiter0 = new SharpLibrary.WinControls.TabPageEx();
            this.grdMain = new KiSS4.Gui.KissGrid();
            this.qryUnterlagenliste = new KiSS4.DB.SqlQuery(this.components);
            this.gvwAll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNotwendig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repedtCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colErhalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKurzname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzErhalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzNotwendig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHatZusatzFeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTabSeite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortierung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColFaUnterlagenKategorieID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdUnterlagen = new KiSS4.Gui.KissGrid();
            this.qryUnterlagen = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErstelltDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstelltUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstelltOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMutiertDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMutiertUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMutiertOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.btnExpand = new KiSS4.Gui.KissButton();
            this.btnCollapse = new KiSS4.Gui.KissButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.btnDrucken = new KiSS4.Gui.KissButton();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryUnterlagenKategorie = new KiSS4.DB.SqlQuery(this.components);
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tabMain.SuspendLayout();
            this.tbpReiter0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnterlagenliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repedtCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnterlagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnterlagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnterlagenKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabMain.Controls.Add(this.tbpReiter9);
            this.tabMain.Controls.Add(this.tbpReiter8);
            this.tabMain.Controls.Add(this.tbpReiter7);
            this.tabMain.Controls.Add(this.tbpReiter4);
            this.tabMain.Controls.Add(this.tbpReiter6);
            this.tabMain.Controls.Add(this.tbpReiter5);
            this.tabMain.Controls.Add(this.tbpReiter3);
            this.tabMain.Controls.Add(this.tbpReiter2);
            this.tabMain.Controls.Add(this.tbpReiter1);
            this.tabMain.Controls.Add(this.tbpReiter0);
            this.tabMain.Location = new System.Drawing.Point(3, 129);
            this.tabMain.Name = "tabMain";
            this.tabMain.ShowFixedWidthTooltip = true;
            this.tabMain.Size = new System.Drawing.Size(866, 512);
            this.tabMain.TabIndex = 3;
            this.tabMain.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpReiter0,
            this.tbpReiter1,
            this.tbpReiter2,
            this.tbpReiter3,
            this.tbpReiter4,
            this.tbpReiter5,
            this.tbpReiter6,
            this.tbpReiter7,
            this.tbpReiter8,
            this.tbpReiter9});
            this.tabMain.TabsLineColor = System.Drawing.Color.Black;
            this.tabMain.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabMain.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabMain.Text = "kissTabControlEx1";
            this.tabMain.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabMain_SelectedTabChanged);
            // 
            // tbpReiter9
            // 
            this.tbpReiter9.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter9.Name = "tbpReiter9";
            this.tbpReiter9.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter9.TabIndex = 12;
            this.tbpReiter9.Title = "Reiter 9";
            // 
            // tbpReiter8
            // 
            this.tbpReiter8.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter8.Name = "tbpReiter8";
            this.tbpReiter8.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter8.TabIndex = 11;
            this.tbpReiter8.Title = "Reiter 8";
            // 
            // tbpReiter7
            // 
            this.tbpReiter7.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter7.Name = "tbpReiter7";
            this.tbpReiter7.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter7.TabIndex = 10;
            this.tbpReiter7.Title = "Reiter 7";
            // 
            // tbpReiter4
            // 
            this.tbpReiter4.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter4.Name = "tbpReiter4";
            this.tbpReiter4.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter4.TabIndex = 9;
            this.tbpReiter4.Title = "Reiter 4";
            // 
            // tbpReiter6
            // 
            this.tbpReiter6.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter6.Name = "tbpReiter6";
            this.tbpReiter6.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter6.TabIndex = 8;
            this.tbpReiter6.Title = "Reiter 6";
            // 
            // tbpReiter5
            // 
            this.tbpReiter5.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter5.Name = "tbpReiter5";
            this.tbpReiter5.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter5.TabIndex = 7;
            this.tbpReiter5.Title = "Reiter 5";
            // 
            // tbpReiter3
            // 
            this.tbpReiter3.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter3.Name = "tbpReiter3";
            this.tbpReiter3.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter3.TabIndex = 6;
            this.tbpReiter3.Title = "Reiter 3";
            // 
            // tbpReiter2
            // 
            this.tbpReiter2.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter2.Name = "tbpReiter2";
            this.tbpReiter2.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter2.TabIndex = 5;
            this.tbpReiter2.Title = "Reiter 2";
            // 
            // tbpReiter1
            // 
            this.tbpReiter1.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter1.Name = "tbpReiter1";
            this.tbpReiter1.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter1.TabIndex = 4;
            this.tbpReiter1.Title = "Reiter 1";
            // 
            // tbpReiter0
            // 
            this.tbpReiter0.Controls.Add(this.grdMain);
            this.tbpReiter0.Location = new System.Drawing.Point(6, 32);
            this.tbpReiter0.Name = "tbpReiter0";
            this.tbpReiter0.Size = new System.Drawing.Size(854, 474);
            this.tbpReiter0.TabIndex = 1;
            this.tbpReiter0.Title = "Reiter 0";
            // 
            // grdMain
            // 
            this.grdMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMain.DataSource = this.qryUnterlagenliste;
            this.grdMain.EmbeddedNavigator.Name = "";
            this.grdMain.Location = new System.Drawing.Point(3, 3);
            this.grdMain.MainView = this.gvwAll;
            this.grdMain.Name = "grdMain";
            this.grdMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repedtCheckBox});
            this.grdMain.Size = new System.Drawing.Size(848, 471);
            this.grdMain.TabIndex = 1;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwAll});
            // 
            // qryUnterlagenliste
            // 
            this.qryUnterlagenliste.BatchUpdate = true;
            this.qryUnterlagenliste.CanUpdate = true;
            this.qryUnterlagenliste.HostControl = this;
            this.qryUnterlagenliste.SelectStatement = resources.GetString("qryUnterlagenliste.SelectStatement");
            this.qryUnterlagenliste.TableName = "FaUnterlagenliste";
            this.qryUnterlagenliste.AfterFill += new System.EventHandler(this.qryUnterlagenliste_AfterFill);
            this.qryUnterlagenliste.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryUnterlagenliste_ColumnChanged);
            // 
            // gvwAll
            // 
            this.gvwAll.Appearance.GroupRow.BackColor = System.Drawing.Color.LightSalmon;
            this.gvwAll.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvwAll.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwAll.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwAll.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwAll.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwAll.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwAll.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwAll.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNotwendig,
            this.colErhalten,
            this.colDatum,
            this.colKurzname,
            this.colZusatz,
            this.colAnzErhalten,
            this.colAnzNotwendig,
            this.colHatZusatzFeld,
            this.colTabSeite,
            this.colSortierung,
            this.colGruppe,
            this.ColFaUnterlagenKategorieID});
            this.gvwAll.GridControl = this.grdMain;
            this.gvwAll.GroupCount = 1;
            this.gvwAll.GroupFormat = "[#image]{1} {2}";
            this.gvwAll.Name = "gvwAll";
            this.gvwAll.OptionsCustomization.AllowFilter = false;
            this.gvwAll.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvwAll.OptionsFilter.AllowFilterEditor = false;
            this.gvwAll.OptionsFilter.AllowMRUFilterList = false;
            this.gvwAll.OptionsPrint.PrintFooter = false;
            this.gvwAll.OptionsPrint.PrintGroupFooter = false;
            this.gvwAll.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvwAll.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwAll.OptionsView.ShowGroupPanel = false;
            this.gvwAll.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSortierung, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvwAll.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvwAll_CustomDrawCell);
            this.gvwAll.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvwAll_CustomDrawGroupRow);
            this.gvwAll.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvwAll_ShowingEditor);
            this.gvwAll.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwAll_FocusedRowChanged);
            this.gvwAll.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvwAll_CellValueChanged);
            this.gvwAll.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvwAll_CellValueChanging);
            // 
            // colNotwendig
            // 
            this.colNotwendig.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colNotwendig.AppearanceCell.Options.UseBackColor = true;
            this.colNotwendig.Caption = "Notwendig";
            this.colNotwendig.ColumnEdit = this.repedtCheckBox;
            this.colNotwendig.FieldName = "Notwendig";
            this.colNotwendig.Name = "colNotwendig";
            this.colNotwendig.Visible = true;
            this.colNotwendig.VisibleIndex = 0;
            this.colNotwendig.Width = 63;
            // 
            // repedtCheckBox
            // 
            this.repedtCheckBox.Appearance.BackColor = System.Drawing.Color.Bisque;
            this.repedtCheckBox.Appearance.Options.UseBackColor = true;
            this.repedtCheckBox.AutoHeight = false;
            this.repedtCheckBox.Name = "repedtCheckBox";
            this.repedtCheckBox.CheckedChanged += new System.EventHandler(this.repedtCheckBox_CheckedChanged);
            // 
            // colErhalten
            // 
            this.colErhalten.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colErhalten.AppearanceCell.Options.UseBackColor = true;
            this.colErhalten.Caption = "Erh.";
            this.colErhalten.ColumnEdit = this.repedtCheckBox;
            this.colErhalten.FieldName = "Erhalten";
            this.colErhalten.Name = "colErhalten";
            this.colErhalten.Visible = true;
            this.colErhalten.VisibleIndex = 1;
            this.colErhalten.Width = 32;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Erhalten";
            this.colDatum.FieldName = "ErhaltenDatum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 2;
            this.colDatum.Width = 66;
            // 
            // colKurzname
            // 
            this.colKurzname.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.colKurzname.AppearanceCell.Options.UseBackColor = true;
            this.colKurzname.Caption = "Kurzname";
            this.colKurzname.FieldName = "Kurzname";
            this.colKurzname.Name = "colKurzname";
            this.colKurzname.OptionsColumn.AllowEdit = false;
            this.colKurzname.OptionsColumn.AllowFocus = false;
            this.colKurzname.OptionsColumn.ReadOnly = true;
            this.colKurzname.Visible = true;
            this.colKurzname.VisibleIndex = 3;
            this.colKurzname.Width = 166;
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.FieldName = "Zusatz";
            this.colZusatz.Name = "colZusatz";
            this.colZusatz.Visible = true;
            this.colZusatz.VisibleIndex = 4;
            this.colZusatz.Width = 468;
            // 
            // colAnzErhalten
            // 
            this.colAnzErhalten.Caption = "colAnzErhalten";
            this.colAnzErhalten.FieldName = "AnzErhalten";
            this.colAnzErhalten.Name = "colAnzErhalten";
            this.colAnzErhalten.OptionsColumn.AllowEdit = false;
            // 
            // colAnzNotwendig
            // 
            this.colAnzNotwendig.Caption = "colAnzNotwendig";
            this.colAnzNotwendig.FieldName = "AnzNotwendig";
            this.colAnzNotwendig.Name = "colAnzNotwendig";
            this.colAnzNotwendig.OptionsColumn.AllowEdit = false;
            // 
            // colHatZusatzFeld
            // 
            this.colHatZusatzFeld.Caption = "colHatZusatzFeld";
            this.colHatZusatzFeld.FieldName = "HatZusatzFeld";
            this.colHatZusatzFeld.Name = "colHatZusatzFeld";
            // 
            // colTabSeite
            // 
            this.colTabSeite.Caption = "TabSeite";
            this.colTabSeite.FieldName = "TabSeite";
            this.colTabSeite.Name = "colTabSeite";
            // 
            // colSortierung
            // 
            this.colSortierung.Caption = "Gruppe";
            this.colSortierung.FieldName = "GruppeID";
            this.colSortierung.Name = "colSortierung";
            this.colSortierung.OptionsColumn.AllowEdit = false;
            // 
            // colGruppe
            // 
            this.colGruppe.Caption = "Gruppe";
            this.colGruppe.FieldName = "Gruppe";
            this.colGruppe.Name = "colGruppe";
            // 
            // ColFaUnterlagenKategorieID
            // 
            this.ColFaUnterlagenKategorieID.Caption = "FaUnterlagenKategorieID";
            this.ColFaUnterlagenKategorieID.FieldName = "FaUnterlagenKategorieID";
            this.ColFaUnterlagenKategorieID.Name = "ColFaUnterlagenKategorieID";
            // 
            // grdUnterlagen
            // 
            this.grdUnterlagen.DataSource = this.qryUnterlagen;
            this.grdUnterlagen.EmbeddedNavigator.Name = "";
            this.grdUnterlagen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUnterlagen.Location = new System.Drawing.Point(3, 33);
            this.grdUnterlagen.MainView = this.gridView1;
            this.grdUnterlagen.Name = "grdUnterlagen";
            this.grdUnterlagen.Size = new System.Drawing.Size(770, 90);
            this.grdUnterlagen.TabIndex = 4;
            this.grdUnterlagen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryUnterlagen
            // 
            this.qryUnterlagen.CanDelete = true;
            this.qryUnterlagen.CanInsert = true;
            this.qryUnterlagen.CanUpdate = true;
            this.qryUnterlagen.HostControl = this;
            this.qryUnterlagen.SelectStatement = resources.GetString("qryUnterlagen.SelectStatement");
            this.qryUnterlagen.TableName = "FaUnterlagen";
            this.qryUnterlagen.AfterFill += new System.EventHandler(this.qryUnterlagen_AfterFill);
            this.qryUnterlagen.BeforePost += new System.EventHandler(this.qryUnterlagen_BeforePost);
            this.qryUnterlagen.AfterPost += new System.EventHandler(this.qryUnterlagen_AfterPost);
            this.qryUnterlagen.BeforeDelete += new System.EventHandler(this.qryUnterlagen_BeforeDelete);
            this.qryUnterlagen.AfterDelete += new System.EventHandler(this.qryUnterlagen_AfterDelete);
            this.qryUnterlagen.PostError += new System.UnhandledExceptionEventHandler(this.qryUnterlagen_PostError);
            this.qryUnterlagen.DeleteError += new System.UnhandledExceptionEventHandler(this.qryUnterlagen_DeleteError);
            this.qryUnterlagen.PositionChanged += new System.EventHandler(this.qryUnterlagen_PositionChanged);
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
            this.colErstelltDatum,
            this.colErstelltUser,
            this.colErstelltOrgUnit,
            this.colMutiertDatum,
            this.colMutiertUser,
            this.colMutiertOrgUnit});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdUnterlagen;
            this.gridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colErstelltDatum
            // 
            this.colErstelltDatum.Caption = "Erstellt am";
            this.colErstelltDatum.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colErstelltDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colErstelltDatum.FieldName = "ErstelltDatum";
            this.colErstelltDatum.Name = "colErstelltDatum";
            this.colErstelltDatum.Visible = true;
            this.colErstelltDatum.VisibleIndex = 0;
            this.colErstelltDatum.Width = 100;
            // 
            // colErstelltUser
            // 
            this.colErstelltUser.Caption = "Mitarbeiter/in";
            this.colErstelltUser.FieldName = "ErstelltUser";
            this.colErstelltUser.Name = "colErstelltUser";
            this.colErstelltUser.Visible = true;
            this.colErstelltUser.VisibleIndex = 1;
            this.colErstelltUser.Width = 90;
            // 
            // colErstelltOrgUnit
            // 
            this.colErstelltOrgUnit.Caption = "Org. Einheit";
            this.colErstelltOrgUnit.FieldName = "ErstelltOrgUnit";
            this.colErstelltOrgUnit.Name = "colErstelltOrgUnit";
            this.colErstelltOrgUnit.Visible = true;
            this.colErstelltOrgUnit.VisibleIndex = 2;
            // 
            // colMutiertDatum
            // 
            this.colMutiertDatum.Caption = "letzte Mutation";
            this.colMutiertDatum.FieldName = "MutiertDatum";
            this.colMutiertDatum.Name = "colMutiertDatum";
            this.colMutiertDatum.Visible = true;
            this.colMutiertDatum.VisibleIndex = 3;
            this.colMutiertDatum.Width = 100;
            // 
            // colMutiertUser
            // 
            this.colMutiertUser.Caption = "Mitarbeiter/in";
            this.colMutiertUser.FieldName = "MutiertUser";
            this.colMutiertUser.Name = "colMutiertUser";
            this.colMutiertUser.Visible = true;
            this.colMutiertUser.VisibleIndex = 4;
            this.colMutiertUser.Width = 90;
            // 
            // colMutiertOrgUnit
            // 
            this.colMutiertOrgUnit.Caption = "Org. Einheit";
            this.colMutiertOrgUnit.FieldName = "MutiertOrgUnit";
            this.colMutiertOrgUnit.Name = "colMutiertOrgUnit";
            this.colMutiertOrgUnit.Visible = true;
            this.colMutiertOrgUnit.VisibleIndex = 5;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.DataMember = null;
            this.lblName.DataSource = this.qryUnterlagenliste;
            this.lblName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblName.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblName.Location = new System.Drawing.Point(9, 647);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(696, 30);
            this.lblName.TabIndex = 316;
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(807, 647);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(28, 24);
            this.btnExpand.TabIndex = 317;
            this.btnExpand.UseCompatibleTextRendering = true;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(841, 647);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(28, 24);
            this.btnCollapse.TabIndex = 318;
            this.btnCollapse.UseCompatibleTextRendering = true;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 24);
            this.panel1.TabIndex = 319;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Unterlagenliste";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // btnDrucken
            // 
            this.btnDrucken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDrucken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrucken.Location = new System.Drawing.Point(711, 647);
            this.btnDrucken.Name = "btnDrucken";
            this.btnDrucken.Size = new System.Drawing.Size(90, 24);
            this.btnDrucken.TabIndex = 320;
            this.btnDrucken.Text = "Drucken";
            this.btnDrucken.UseCompatibleTextRendering = true;
            this.btnDrucken.UseVisualStyleBackColor = true;
            this.btnDrucken.Visible = false;
            this.btnDrucken.Click += new System.EventHandler(this.btnDrucken_Click);
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // qryUnterlagenKategorie
            // 
            this.qryUnterlagenKategorie.HostControl = this;
            this.qryUnterlagenKategorie.SelectStatement = "select ReiterNr = ROW_NUMBER() OVER ( ORDER BY Sortierung ) -1, * from FaUnterlag" +
                "enKategorie\r\nwhere FaUnterlagenID = {0}\r\nand \',\'+Filter+\',\' like \'%,\'+{1}+\',%\'\r\n" +
                "order by ReiterNr asc";
            this.qryUnterlagenKategorie.AfterFill += new System.EventHandler(this.qryUnterlagenKategorie_AfterFill);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Appearance.BackColor = System.Drawing.Color.Bisque;
            this.repositoryItemCheckEdit1.Appearance.Options.UseBackColor = true;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CtlFaUnterlagenliste
            // 
            this.ActiveSQLQuery = this.qryUnterlagen;
            this.Controls.Add(this.btnDrucken);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCollapse);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.grdUnterlagen);
            this.Controls.Add(this.tabMain);
            this.Name = "CtlFaUnterlagenliste";
            this.Size = new System.Drawing.Size(891, 680);
            this.Load += new System.EventHandler(this.CtlFaUnterlagenliste_Load);
            this.tabMain.ResumeLayout(false);
            this.tbpReiter0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnterlagenliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repedtCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnterlagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnterlagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUnterlagenKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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
    }
}