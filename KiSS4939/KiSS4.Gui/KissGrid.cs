using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissGrid.
    /// </summary>
    public class KissGrid : DevExpress.XtraGrid.GridControl
    {
        #region Enumerations

        /// <summary>
        /// Enumeration for export types.
        /// </summary>
        /// <remarks>equals the file extension</remarks>
        public enum ExportType
        {
            /// <summary>
            /// Export as HTML.
            /// </summary>
            html,

            /// <summary>
            /// Export as XML.
            /// </summary>
            xml,

            /// <summary>
            /// Export as text.
            /// </summary>
            txt,

            /// <summary>
            /// Export as excel file.
            /// </summary>
            xls
        }

        #endregion Enumerations

        #region Fields

        #region Private Fields

        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem btnCollapseAllGroups;
        private DevExpress.XtraBars.BarCheckItem btnColumnFilter;
        private DevExpress.XtraBars.BarButtonItem btnExcel;
        private DevExpress.XtraBars.BarButtonItem btnExpandAllGroups;
        private DevExpress.XtraBars.BarButtonItem btnPrint;

        /// <summary>
        /// Columnfilter activated state
        /// </summary>
        private bool columnFilterActivated;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        private DateTime dateFrom = DateTime.MinValue;
        private DateTime dateTo = DateTime.MinValue;
        private DevExpress.XtraBars.BarManager defPopBarMan;
        private DevExpress.XtraBars.PopupMenu defPopMenu;
        private GridStyleType gridStyle = GridStyleType.Default;
        private GridView gridView1;
        private string headerString = "";
        private System.Windows.Forms.ImageList imageList1;
        private bool IsOnCreateControl_IsDesignMode;
        private DevExpress.XtraGrid.Columns.GridColumn lastFocusedCol;
        private bool PendingEditorError;
        private bool showDefaultPopup = true;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor for KissGrid
        /// </summary>
        public KissGrid()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // setup popupmenu for multilanguage
            this.btnPrint.Caption = KissMsg.GetMLMessage("KissGrid", "PopupMenuPrint", this.btnPrint.Caption);
            this.btnExcel.Caption = KissMsg.GetMLMessage("KissGrid", "PopupMenuExcel", this.btnExcel.Caption);
            this.btnColumnFilter.Caption = KissMsg.GetMLMessage("KissGrid", "PopupMenuColumnFilter", this.btnColumnFilter.Caption);
            this.btnExpandAllGroups.Caption = KissMsg.GetMLMessage("KissGrid", "PopupMenuExpandAllGroups", this.btnExpandAllGroups.Caption);
            this.btnCollapseAllGroups.Caption = KissMsg.GetMLMessage("KissGrid", "PopupMenuCollapseAllGroups", this.btnCollapseAllGroups.Caption);

            // register load event --> we cannot use OnLoad event due to mouse-enter on grid!
            this.Load += new EventHandler(KissGrid_Load);

            //in case BestFitColumns() is called, perform it only for the first 1000 rows, otherwise this operation takes way too long
            this.View.BestFitMaxRowCount = 1000;
        }

        #endregion Constructors

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissGrid));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.defPopMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnColumnFilter = new DevExpress.XtraBars.BarCheckItem();
            this.btnExpandAllGroups = new DevExpress.XtraBars.BarButtonItem();
            this.btnCollapseAllGroups = new DevExpress.XtraBars.BarButtonItem();
            this.defPopBarMan = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.defPopMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defPopBarMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            //
            // imageList1
            //
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "Filter");
            this.imageList1.Images.SetKeyName(3, "Expand");
            this.imageList1.Images.SetKeyName(4, "Collapse");
            //
            // defPopMenu
            //
            this.defPopMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnColumnFilter, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExpandAllGroups, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCollapseAllGroups)});
            this.defPopMenu.Manager = this.defPopBarMan;
            this.defPopMenu.Name = "defPopMenu";
            //
            // btnPrint
            //
            this.btnPrint.Caption = "Drucken...";
            this.btnPrint.Id = 1;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            //
            // btnExcel
            //
            this.btnExcel.Caption = "Excel";
            this.btnExcel.Id = 2;
            this.btnExcel.ImageIndex = 1;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel_ItemClick);
            //
            // btnColumnFilter
            //
            this.btnColumnFilter.Caption = "Kolonnenfilter";
            this.btnColumnFilter.CategoryGuid = new System.Guid("a5a07ff2-2c35-4917-8b6b-f4c11b0e4fac");
            this.btnColumnFilter.Id = 2;
            this.btnColumnFilter.ImageIndex = 2;
            this.btnColumnFilter.Name = "btnColumnFilter";
            this.btnColumnFilter.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnColumnFilter_CheckedChanged);
            //
            // btnExpandAllGroups
            //
            this.btnExpandAllGroups.Caption = "Gruppen erweitern";
            this.btnExpandAllGroups.Id = 4;
            this.btnExpandAllGroups.ImageIndex = 3;
            this.btnExpandAllGroups.Name = "btnExpandAllGroups";
            this.btnExpandAllGroups.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpandAllGroups_ItemClick);
            //
            // btnCollapseAllGroups
            //
            this.btnCollapseAllGroups.Caption = "Gruppen reduzieren";
            this.btnCollapseAllGroups.Id = 3;
            this.btnCollapseAllGroups.ImageIndex = 4;
            this.btnCollapseAllGroups.Name = "btnCollapseAllGroups";
            this.btnCollapseAllGroups.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCollapseAllGroups_ItemClick);
            //
            // defPopBarMan
            //
            this.defPopBarMan.DockControls.Add(this.barDockControl1);
            this.defPopBarMan.DockControls.Add(this.barDockControl2);
            this.defPopBarMan.DockControls.Add(this.barDockControl3);
            this.defPopBarMan.DockControls.Add(this.barDockControl4);
            this.defPopBarMan.Form = this;
            this.defPopBarMan.Images = this.imageList1;
            this.defPopBarMan.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrint,
            this.btnExcel,
            this.btnColumnFilter,
            this.btnExpandAllGroups,
            this.btnCollapseAllGroups});
            this.defPopBarMan.MaxItemId = 6;
            //
            // gridView1
            //
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            //
            // KissGrid
            //
            //
            //
            //
            this.EmbeddedNavigator.Name = "";
            this.MainView = this.gridView1;
            this.MenuManager = this.defPopBarMan;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.defPopMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defPopBarMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code

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

                // remove all hooked events again
                this.Load -= new EventHandler(KissGrid_Load);
                if (this.MainView != null && this.View != null)
                {
                    this.View.BeforeLeaveRow -= new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.BeforeLeaveRow);
                    this.View.ValidatingEditor -= new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.ValidatingEditor);
                    this.View.InvalidValueException -= new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.InvalidValueException);
                    this.View.GotFocus -= new EventHandler(View_GotFocus);
                    this.View.LostFocus -= new EventHandler(View_LostFocus);
                    this.View.ShowGridMenu -= new GridMenuEventHandler(View_ShowGridMenu);
                }

                if (defPopBarMan != null)
                    defPopBarMan.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                // if we are in designer, forget the "index was out of range" exception...
                if (!this.DesignMode)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion Dispose

        #region Events

        /// <summary>
        /// Occurs before the print preview is displayed.
        /// </summary>
        [Description("Fired before showing print preview form. Can be used to set Page Settings, Headers, Footers etc.")]
        public event XtraPrintEventHandler XtraPrint
        {
            add { onXtraPrint += value; }
            remove { onXtraPrint -= value; }
        }

        private event XtraPrintEventHandler onXtraPrint;

        #endregion Events

        #region Properties

        /// <summary>
        /// Get and set column filter activated
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Set if column filter has to be activated by default")]
        public bool ColumnFilterActivated
        {
            get { return this.columnFilterActivated; }
            set
            {
                this.ActivateColumnFilter(value);
            }
        }

        /// <summary>
        /// Get and set datasource to use in grid
        /// </summary>
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Category("Data")]
        public new object DataSource
        {
            get { return base.DataSource; }
            set { base.DataSource = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines the two basic behaviours/layouts (editable, readonly)
        /// </summary>
        [Browsable(true)]
        [DefaultValue(GridStyleType.Default)]
        public GridStyleType GridStyle
        {
            get { return gridStyle; }
            set { gridStyle = value; if (!IsLoading) SetDefaultLayout(); }
        }

        /// <summary>
        /// Get and set headerstring
        /// </summary>
        [DefaultValue("")]
        public string HeaderString
        {
            get { return this.headerString; }
            set { this.headerString = value; }
        }

        /*
        /// <summary>
        /// Get and set the selection date from
        /// </summary>
        public DateTime DateFrom
        {
            get { return this.dateFrom; }
            set { this.dateFrom = value; }
        }

        /// <summary>
        /// Get and set the selection date to
        /// </summary>
        public DateTime DateTo
        {
            get { return this.dateTo; }
            set { this.dateTo = value; }
        }

         * */

        /// <summary>
        /// Gets or sets a value that specifies whether the last row should be selected after the grid loads for the first time.
        /// The default is <c>false</c>.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value that specifies whether the last row should be selected after the grid loads for the first time.")]
        public bool SelectLastPosition
        {
            get;
            set;
        }

        /// <summary>
        /// True to show a default popup menu
        /// </summary>
        [DefaultValue(true)]
        [Description("True to show a default poupup menu.")]
        public bool ShowDefaultPopup
        {
            get { return this.showDefaultPopup; }
            set { this.showDefaultPopup = value; }
        }

        /// <summary>
        /// Get gridview used in grid as mainview
        /// </summary>
        [Browsable(false)]
        public DevExpress.XtraGrid.Views.Grid.GridView View
        {
            get { return (DevExpress.XtraGrid.Views.Grid.GridView)MainView; }
        }

        #endregion Properties

        #region EventHandlers

        /// <summary>
        /// Handles the ItemClick event of the btnExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        public void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try { this.ExportToExcel(); }
            catch (Exception ex)
            {
                KissMsg.ShowError("KissGrid", "FehlerExcelExport", "Fehler beim Exportieren nach Excel.", ex);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// Handles the ItemClick event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        public void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try { this.Print(); }
            catch (Exception ex)
            {
                KissMsg.ShowError("KissGrid", "FehlerDrucken", "Fehler beim Drucken.", ex);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void btnCollapseAllGroups_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.View != null)
            {
                this.View.CollapseAllGroups();
            }
        }

        /// <summary>
        /// BtnColumnFilter was clicked and/or the checked property was changed
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void btnColumnFilter_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ActivateColumnFilter(this.btnColumnFilter.Checked);
        }

        private void btnExpandAllGroups_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.View != null)
            {
                this.View.ExpandAllGroups();
            }
        }

        private void KissGrid_Load(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (this.MainView != null && this.View != null)
                {
                    // do event hooking
                    this.View.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.BeforeLeaveRow);
                    this.View.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.ValidatingEditor);
                    this.View.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.InvalidValueException);
                    this.View.GotFocus += new EventHandler(View_GotFocus);
                    this.View.LostFocus += new EventHandler(View_LostFocus);
                    this.View.ShowGridMenu += new GridMenuEventHandler(View_ShowGridMenu);
                }
            }

            if (!DesignMode)
            {
                // setup appearance
                this.SetDefaultLayout();

                if (this.MainView != null && this.View != null)
                {
                    // remove selected row
                    this.View_LostFocus(null, null);
                }
            }

            // set columnfilter activated state (do it here because of created view and updated layout)
            this.ActivateColumnFilter(this.ColumnFilterActivated);

            //check if we should select the last row
            if (SelectLastPosition)
            {
                SqlQuery qry = DataSource as SqlQuery;
                if (qry != null)
                {
                    qry.Last();
                }
            }
        }

        /// <summary>
        /// Handles the GotFocus event of the View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void View_GotFocus(object sender, System.EventArgs e)
        {
            try
            {
                if (this.MainView != null && this.View != null)
                {
                    this.View.FocusedColumn = this.lastFocusedCol;
                }
            }
            catch { }
        }

        /// <summary>
        /// Handles the LostFocus event of the View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void View_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                if (this.MainView != null && this.View != null)
                {
                    // prevent marking last focused cell in different color when grid loses the focus
                    this.lastFocusedCol = this.View.FocusedColumn;
                    this.View.FocusedColumn = null;
                }
            }
            catch { }
        }

        /// <summary>
        /// Popupmenu handler for our own popupmenu on grid
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void View_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            // are we allowed to show menu?
            if (ShowDefaultPopup && e != null && e.HitInfo != null)
            {
                // do show menu only if not on grouppanel or on column or on filterpanel
                if (!e.HitInfo.InGroupPanel && !e.HitInfo.InColumnPanel && !e.HitInfo.InFilterPanel)
                {
                    // set flag
                    bool canShowGroupMenuPart = false;

                    // check if view is valid
                    if (View != null)
                    {
                        // get groupmode (can show expand/collapse menu only if grouping and having any data)
                        canShowGroupMenuPart = (View.GroupedColumns.Count > 0 && View.GroupCount > 0 && View.RowCount > 0);
                    }

                    // show/hide menu-buttons
                    ShowHideMenuItem(btnExpandAllGroups, canShowGroupMenuPart);
                    ShowHideMenuItem(btnCollapseAllGroups, canShowGroupMenuPart);

                    // show popup menu
                    this.defPopMenu.ShowPopup(this.PointToScreen(e.Point));
                }
            }
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a new context menu item (BarButtonItem) at the end of the context menu.
        /// </summary>
        /// <param name="caption">The caption of the item.</param>
        /// <param name="clickEvent">An event handler that is called when the item is clicked.</param>
        /// <param name="iconID">The ID of the icon on the DB. Specify -1 to not use any icon for the item.</param>
        public void AddContextMenuItem(string caption, ItemClickEventHandler clickEvent, int iconID)
        {
            var btn = new BarButtonItem(defPopBarMan, caption);
            btn.ItemClick += clickEvent;
            btn.Id = defPopBarMan.MaxItemId;
            defPopMenu.ItemLinks.Add(btn);
            defPopMenu.LinksPersistInfo.Add(new LinkPersistInfo(btn));
            defPopBarMan.MaxItemId++;
            defPopBarMan.Items.Add(btn);

            if (iconID >= 0)
            {
                var icon = KissImageList.GetSmallImage(iconID);
                var name = Convert.ToString(imageList1.Images.Count);
                imageList1.Images.Add(name, icon);
                int index = imageList1.Images.IndexOfKey(name);
                btn.ImageIndex = index;
            }
        }

        /// <summary>
        /// Unlocks the grid control after the <see cref="M:DevExpress.XtraGrid.GridControl.BeginUpdate"/> method call and causes an immediate update.
        /// </summary>
        public override void EndUpdate()
        {
            if (IsOnCreateControl_IsDesignMode)
            {
                SetDefaultLayout();
            }

            base.EndUpdate();
        }

        /// <summary>
        /// Export to an ExcelSheet using the <see cref="KissExportXlsProvider"/>.
        /// </summary>
        public void ExportToExcel()
        {
            GridView gv = DefaultView as GridView;

            if (gv == null)
            {
                throw new InvalidOperationException("Export only works for GridView.");
            }

            KissExportXlsProvider xlsExporter = new KissExportXlsProvider(gv, GetExportTitle());
            xlsExporter.Export();
        }

        /// <summary>
        /// Export to a temporary file using the specified standard provider, and open the file.
        /// </summary>
        public void ExportToFile(ExportType type)
        {
            if (!Enum.IsDefined(typeof(ExportType), type))
            {
                throw new ArgumentOutOfRangeException("type");
            }

            // create tmp file
            FileInfo file;
            int counter = 0;

            do
            {
                string fileName = Path.Combine(Path.GetTempPath(), "tmp" + counter++);
                fileName = Path.ChangeExtension(fileName, type.ToString());
                file = new FileInfo(fileName);
            }
            while (file.Exists);

            // create export provider
            IExportProvider exportProvider;

            switch (type)
            {
                case ExportType.html:
                    exportProvider = new ExportHtmlProvider(file.FullName);
                    break;

                case ExportType.xml:
                    exportProvider = new ExportXmlProvider(file.FullName);
                    break;

                case ExportType.txt:
                    exportProvider = new ExportTxtProvider(file.FullName);
                    break;

                case ExportType.xls:
                    exportProvider = new ExportXlsProvider(file.FullName);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("type");
            }

            // create export link
            BaseExportLink exportLink = MainView.CreateExportLink(exportProvider);

            if (type == ExportType.xls)
            {
                exportLink.ExportCellsAsDisplayText = false;
            }

            // export to file
            exportLink.ExportTo(true);

            // open the file
            Process.Start(file.FullName);

            // display a DlgFileDelete for the file
            DlgFileDelete dfd = new DlgFileDelete();
            dfd.FileInfo = file;
            dfd.ShowDialog(this);
        }

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="qry">The qry.</param>
        /// <param name="ValueMember">The value member.</param>
        /// <param name="DisplayMember">The display member.</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(SqlQuery qry, string ValueMember, string DisplayMember)
        {
            RepositoryItemLookUpEdit LOVLookUpEdit = UtilsGui.GetLOVLookUpEdit(qry, ValueMember, DisplayMember);
            RepositoryItems.Add(LOVLookUpEdit);

            return LOVLookUpEdit;
        }

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="qry">The qry.</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(SqlQuery qry)
        {
            return GetLOVLookUpEdit(qry, "Code", "Text");
        }

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="LOVName">Name of the LOV.</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(string LOVName)
        {
            return GetLOVLookUpEdit(LOVName, false);
        }

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="LOVName">Name of the LOV.</param>
        /// <param name="allowNull">if set to <c>true</c> [allow null].</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(string LOVName, bool allowNull)
        {
            return GetLOVLookUpEdit(DBUtil.GetLOVQuery(LOVName, allowNull));
        }

        /// <summary>
        /// Get content of visible grid view as tab separated lines that can be pasted into Excel.
        /// Lines are separated by Environment.NewLine
        /// </summary>
        /// <param name="withHeader">true: column captions as the first line, false: without header</param>
        /// <param name="replacementNL">If a cell contains a newline (Environment.NewLine) character
        /// it will be replaced by this string. Leave it "null" to disable replacement.</param>
        /// <returns>string with grid content</returns>
        public string getViewExcel(bool withHeader, string replacementNL)
        {
            string x = "";

            if (withHeader)
            {
                for (int c = 0; c < View.Columns.Count; ++c)
                {
                    if (View.Columns[c].VisibleIndex < 0)
                    {
                        continue;
                    }

                    string colCaption = View.Columns[c].Caption;

                    if (null != replacementNL)
                    {
                        colCaption = colCaption.Replace(Environment.NewLine, replacementNL);
                    }

                    x += colCaption + '\t';
                }
            }

            for (int r = 0; r < View.RowCount; ++r)
            {
                x += Environment.NewLine;

                for (int c = 0; c < View.Columns.Count; ++c)
                {
                    if (View.Columns[c].VisibleIndex < 0)
                    {
                        continue;
                    }

                    string cell = View.GetRowCellDisplayText(r, View.Columns[c]);

                    if (null != replacementNL)
                    {
                        cell = cell.Replace(Environment.NewLine, replacementNL);
                    }

                    x += cell + '\t';
                }
            }

            return x;
        }

        /// <summary>
        /// Force execute OnLoaded event on grid
        /// </summary>
        public void PerformLoad()
        {
            // perform loading again
            KissGrid_Load(null, null);
        }

        /// <summary>
        /// Show Preview of DevExpress.XtraPrinting.PrintHelper
        /// </summary>
        public new void Print()
        {
            View.OptionsPrint.AutoWidth = false;
            View.OptionsPrint.UsePrintStyles = true;
            View.OptionsPrint.ExpandAllGroups = false;

            View.PrintStyles["Row"].Font = new Font("Arial", 8f, FontStyle.Regular);

            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink plink = new PrintableComponentLink();

            if (ps == null || plink == null)
            {
                return;
            }

            plink.PrintingSystem = ps;
            plink.Component = this;
            plink.CreateDocument();

            PageHeaderFooter HeaderFooter = (PageHeaderFooter)plink.PageHeaderFooter;

            HeaderFooter.Header.Font = new Font("Arial", 10f, FontStyle.Bold);
            HeaderFooter.Footer.Font = new Font("Arial", 8f, FontStyle.Regular);

            HeaderFooter.Footer.Content.Clear();
            HeaderFooter.Footer.Content.Add(KissMsg.GetMLMessage("KissGrid", "PrintDateFooter", "Druckdatum: {0}", KissMsgCode.Text, DateTime.Today.ToString("dd.MM.yyyy")));
            HeaderFooter.Footer.Content.Add("KiSS4");
            HeaderFooter.Footer.Content.Add(KissMsg.GetMLMessage("KissGrid", "PageFooter", "Seite [Page #]"));

            HeaderFooter.Header.Content.Clear();
            HeaderFooter.Header.Content.Add(KissMsg.GetMLMessage("KissGrid", "PrintOfTableHeader", "Ausdruck der Tabelle {0}", KissMsgCode.Text, this.HeaderString));

            PrintPreviewFormEx previewForm = ps.PreviewFormEx;

            ps.PageSettings.Landscape = true;
            ps.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ps.PageSettings.LeftMargin = 40;
            ps.PageSettings.RightMargin = 40;
            ps.PageSettings.TopMargin = 40;
            ps.PageSettings.BottomMargin = 40;

            OnXtraPrint(this, new XtraPrintEventArgs(plink));

            plink.CreateDocument();

            previewForm.Show();
        }

        public void SetColumnEditable(DevExpress.XtraGrid.Columns.GridColumn column, bool editable)
        {
            SetColumnEditable(column, editable, editable);
        }

        public void SetColumnEditable(DevExpress.XtraGrid.Columns.GridColumn column, bool displayEditable, bool editable)
        {
            var cellBackgroundReadOnly = GuiConfig.Theme == GuiConfig.KissTheme.KissBlue
                ? GuiConfig.GridRowReadOnly
                : GuiConfig.GridReadOnly;

            if (displayEditable)
            {
                column.AppearanceCell.BackColor = GuiConfig.GridEditable;
                column.AppearanceCell.Options.UseBackColor = true;
                column.OptionsColumn.AllowEdit = editable;
            }
            else
            {
                column.AppearanceCell.BackColor = cellBackgroundReadOnly;
                column.AppearanceCell.Options.UseBackColor = true;
                column.OptionsColumn.AllowEdit = editable;
            }
        }

        /// <summary>
        /// Set header and footer for standard print out
        /// </summary>
        public void SetHeaderAndFooterText(XtraPrintEventArgs report, string title, string searchparams)
        {
            // Standard TopMargin
            report.PLink.PrintingSystem.PageSettings.TopMargin = 60;

            // Header and Footer
            var headerFooter = (PageHeaderFooter)report.PLink.PageHeaderFooter;

            // Header
            headerFooter.Header.Content.Clear();
            headerFooter.Header.Content.Add(DBUtil.GetConfigString("SozialDienst\\Allgemein\\Name", "[leer]"));
            headerFooter.Header.Content.Add("");
            headerFooter.Header.Content.Add(title);

            // Footer
            string sText = (searchparams != "") ? ", " : "";
            string sPrinted = KissMsg.GetMLMessage("KissGrid", "AusgedrucktAm", "Druckdatum");
            string sPage = KissMsg.GetMLMessage("KissGrid", "Seite", "Seite");
            headerFooter.Footer.Content.Clear();
            headerFooter.Footer.Content.Add(searchparams + sText + sPrinted + " " + DateTime.Today.ToString("dd.MM.yyyy"));
            headerFooter.Footer.Content.Add("");
            headerFooter.Footer.Content.Add(sPage + " [Page #]");
        }

        public void SetSelectionColor(bool editable)
        {
            if (editable)
            {
                this.View.Appearance.FocusedCell.BackColor = GuiConfig.colBack01; // System.Drawing.Color.AliceBlue;
                this.View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
                this.View.Appearance.FocusedCell.Options.UseBackColor = true;

                this.View.Appearance.FocusedRow.BackColor = GuiConfig.colBack01; // System.Drawing.Color.AliceBlue;
                this.View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
                this.View.Appearance.FocusedRow.Options.UseBackColor = true;
                this.View.Appearance.FocusedRow.Options.UseForeColor = true;

                this.View.Appearance.SelectedRow.BackColor = GuiConfig.colBack01; // System.Drawing.Color.AliceBlue;
                this.View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
                this.View.Appearance.SelectedRow.Options.UseBackColor = true;
                this.View.Appearance.SelectedRow.Options.UseForeColor = true;
            }
            else
            {
                this.View.Appearance.FocusedCell.BackColor = GuiConfig.GridFocusedSelectionBackColor;
                this.View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                this.View.Appearance.FocusedCell.Options.UseBackColor = true;
                this.View.Appearance.FocusedCell.Options.UseForeColor = true;

                this.View.Appearance.FocusedRow.BackColor = GuiConfig.GridFocusedSelectionBackColor;
                this.View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
                this.View.Appearance.FocusedRow.Options.UseBackColor = true;
                this.View.Appearance.FocusedRow.Options.UseForeColor = true;

                this.View.Appearance.HideSelectionRow.BackColor = GuiConfig.GridUnfocusedSelectionBackColor;
                this.View.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
                this.View.Appearance.HideSelectionRow.Options.UseBackColor = true;
                this.View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override AccessibleObject GetAccessibilityObjectById(int objectId)
        {
            // Methode überschreiben und Try-Catch einbauen da es in der DevExpress-Überschreibung zu einer NullReferenceException führt. (nur wenn JAWS Screen Reading Software am laufen ist)
            try
            {
                return base.GetAccessibilityObjectById(objectId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Called when [create control].
        /// </summary>
        protected override void OnCreateControl()
        {
            IsOnCreateControl_IsDesignMode = DesignMode;
            base.OnCreateControl();
        }

        protected override void OnResize(EventArgs e)
        {
            try
            {
                base.OnResize(e);
            }
            catch (Win32Exception ex)
            {
                // Ignore Win32Exception from Base-Class, just log it
                Trace.TraceError("Exception in KissGrid.OnResize(): " + ex.ToString());
            }
        }

        /// <summary>
        /// Called when [xtra print].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KiSS4.Gui.XtraPrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnXtraPrint(object sender, XtraPrintEventArgs e)
        {
            if (onXtraPrint != null)
            {
                onXtraPrint(sender, e);
            }
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Invalids the value exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs"/> instance containing the event data.</param>
        private void InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() == "")
            {
                View.SetRowCellValue(View.FocusedRowHandle, View.FocusedColumn, null);
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
            }
            else
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                if (PendingEditorError)
                {
                    PendingEditorError = false;
                }
                else
                {
                    if (e.Value != null)
                    {
                        KissMsg.ShowInfo("KissGrid", "UngueltigerWert", "Ungültiger Wert");
                        PendingEditorError = true;
                    }
                    else
                    {
                        PendingEditorError = true;
                    }
                }
            }
        }

        public void SetDefaultLayout()
        {
            if (gridStyle == GridStyleType.Default)
            {
                return;
            }

            Styles.Clear();

            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                this.LookAndFeel.UseDefaultLookAndFeel = false;
                this.LookAndFeel.Style = LookAndFeelStyle.Flat;
            }

            foreach (var baseView in ViewCollection)
            {
                var view = baseView as GridView;
                if (view == null)
                {
                    continue;
                }

                foreach (AppearanceObject appear in new AppearanceObject[] { view.Appearance.Empty, view.Appearance.EvenRow, view.Appearance.FocusedCell, view.Appearance.FocusedRow, view.Appearance.HideSelectionRow, view.Appearance.OddRow, view.Appearance.Row, view.Appearance.SelectedRow })
                {
                    appear.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
                    appear.Options.UseFont = true;
                }

                view.Appearance.Empty.BackColor = GuiConfig.PanelColor; // System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(239)), ((System.Byte)(231)));

                view.Appearance.Empty.Options.UseBackColor = true;

                view.Appearance.FocusedRow.BackColor = GuiConfig.GridFocusedSelectionBackColor;
                view.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
                view.Appearance.FocusedRow.Options.UseBackColor = true;
                view.Appearance.FocusedRow.Options.UseForeColor = true;

                view.Appearance.FocusedCell.BackColor = GuiConfig.GridFocusedSelectionBackColor;
                view.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                view.Appearance.FocusedCell.Options.UseBackColor = true;
                view.Appearance.FocusedCell.Options.UseForeColor = true;

                view.Appearance.GroupPanel.BackColor = GuiConfig.colBack05; // System.Drawing.Color.PeachPuff;
                view.Appearance.GroupPanel.Options.UseBackColor = true;

                view.Appearance.GroupRow.BackColor = GuiConfig.colBack05; // System.Drawing.Color.PeachPuff;
                view.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                view.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
                view.Appearance.GroupRow.Options.UseBackColor = true;
                view.Appearance.GroupRow.Options.UseFont = true;
                view.Appearance.GroupRow.Options.UseForeColor = true;

                view.Appearance.GroupFooter.BackColor = GuiConfig.colBack05;
                view.Appearance.GroupFooter.BorderColor = GuiConfig.colBack04;
                view.Appearance.GroupFooter.Options.UseBackColor = true;
                view.Appearance.GroupFooter.Options.UseBorderColor = true;

                view.Appearance.HeaderPanel.BackColor = GuiConfig.colBack06; // System.Drawing.Color.Tan;
                view.Appearance.HeaderPanel.BorderColor = GuiConfig.colBack06; // System.Drawing.Color.Tan;
                view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                view.Appearance.HeaderPanel.Options.UseBackColor = true;
                view.Appearance.HeaderPanel.Options.UseBorderColor = true;
                view.Appearance.HeaderPanel.Options.UseFont = true;

                view.Appearance.HideSelectionRow.BackColor = GuiConfig.GridUnfocusedSelectionBackColor;
                view.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
                view.Appearance.HideSelectionRow.Options.UseBackColor = true;
                view.Appearance.HideSelectionRow.Options.UseForeColor = true;

                view.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
                view.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;

                view.Appearance.Row.BackColor = GuiConfig.colBack04; // System.Drawing.Color.BlanchedAlmond;
                view.Appearance.Row.Options.UseBackColor = true;

                view.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

                view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
                view.OptionsBehavior.Editable = false;
                view.OptionsFilter.UseNewCustomFilterDialog = true;
                view.OptionsNavigation.AutoFocusNewRow = true;
                view.OptionsNavigation.UseTabKey = false;
                view.OptionsView.ShowGroupPanel = false;
                view.OptionsView.ShowIndicator = false;
                view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                // setup view to display only desired options (this cannot be done in multilanguage)
                view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never; // hide bottom filter panel (only english available)
            }

            // PopupCell-Style für alle LookUp's setzen
            foreach (RepositoryItem R in this.RepositoryItems)
            {
                if (R is RepositoryItemLookUpEdit)
                {
                    ((RepositoryItemLookUpEdit)R).AppearanceDropDown.BackColor = GuiConfig.GridReadOnly;
                    ((RepositoryItemLookUpEdit)R).AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    ((RepositoryItemLookUpEdit)R).AppearanceDropDown.Options.UseBackColor = true;
                    ((RepositoryItemLookUpEdit)R).AppearanceDropDown.Options.UseFont = true;

                    ((RepositoryItemLookUpEdit)R).NullText = "";
                    ((RepositoryItemLookUpEdit)R).ShowHeader = false;
                    ((RepositoryItemLookUpEdit)R).ShowFooter = false;
                }
            }

            switch (gridStyle)
            {
                case GridStyleType.Editable:

                    foreach (var baseView in ViewCollection)
                    {
                        var view = baseView as GridView;
                        if (view == null)
                        {
                            continue;
                        }

                        view.Appearance.EvenRow.BackColor = GuiConfig.colBack01; //System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
                        view.Appearance.EvenRow.Options.UseBackColor = true;

                        view.Appearance.FocusedCell.BackColor = GuiConfig.colBack01; // System.Drawing.Color.AliceBlue;
                        view.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
                        view.Appearance.FocusedCell.Options.UseBackColor = true;

                        view.Appearance.FocusedRow.BackColor = GuiConfig.colBack01; // System.Drawing.Color.AliceBlue;
                        view.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
                        view.Appearance.FocusedRow.Options.UseBackColor = true;
                        view.Appearance.FocusedRow.Options.UseForeColor = true;

                        view.Appearance.HeaderPanel.BackColor = GuiConfig.colBack06; // System.Drawing.Color.Tan;
                        view.Appearance.HeaderPanel.BorderColor = GuiConfig.colBack06; // System.Drawing.Color.Tan;
                        view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        view.Appearance.HeaderPanel.Options.UseBackColor = true;
                        view.Appearance.HeaderPanel.Options.UseBorderColor = true;
                        view.Appearance.HeaderPanel.Options.UseFont = true;

                        view.Appearance.HideSelectionRow.BackColor = GuiConfig.colBack01; //System.Drawing.Color.AliceBlue;

                        view.Appearance.Row.BackColor = GuiConfig.colBack01; // System.Drawing.Color.AliceBlue;
                        view.Appearance.Row.Options.UseBackColor = true;

                        view.Appearance.SelectedRow.BackColor = GuiConfig.colBack01; // System.Drawing.Color.AliceBlue;
                        view.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
                        view.Appearance.SelectedRow.Options.UseBackColor = true;
                        view.Appearance.SelectedRow.Options.UseForeColor = true;

                        view.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
                        view.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;

                        view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;

                        view.OptionsBehavior.Editable = true;
                        view.OptionsNavigation.AutoFocusNewRow = true;
                        view.OptionsNavigation.UseTabKey = true;
                        view.OptionsView.ShowIndicator = true;
                    }

                    break;
            }
        }

        /// <summary>
        /// Activate or deactivate column filter
        /// </summary>
        /// <param name="doActivate">True if columnfilter has to be activated, false if disable columnfilter</param>
        private void ActivateColumnFilter(bool doActivate)
        {
            // apply filter
            bool doApplyFilterOptions = true;

            // check if can activate filter
            if (MainView == null || View == null)
            {
                doActivate = false;
                doApplyFilterOptions = false;
            }

            // apply to field var
            columnFilterActivated = doActivate;

            // apply to popupmenu-button style
            btnColumnFilter.CheckedChanged -= new DevExpress.XtraBars.ItemClickEventHandler(btnColumnFilter_CheckedChanged);
            btnColumnFilter.Checked = doActivate;
            btnColumnFilter.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(btnColumnFilter_CheckedChanged);

            // check if need to continue
            if (!doApplyFilterOptions)
            {
                return;
            }

            // clear filter if any defined
            if (!doActivate && View.ActiveFilter != null)
            {
                View.ActiveFilter.Clear();
            }

            // enable or disable filter
            View.OptionsCustomization.AllowFilter = doActivate;
        }

        /// <summary>
        /// Handles beforeleaveRow events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.RowAllowEventArgs"/> instance containing the event data.</param>
        private void BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            SqlQuery qry = DataSource as SqlQuery;

            if (qry != null && e.Allow)
            {
                // do not allow selecting another row if post failes - otherwise an endlessloop occures

                // 10.04.2009 : qry.IsDeleting wird in OnPositionChanging abgefangen
                //if (!qry.IsDeleting) e.Allow = qry.OnPositionChanging(this, EventArgs.Empty);
                e.Allow = qry.OnPositionChanging(this, EventArgs.Empty);

                // 10.04.2009 : Umbau Transaktionen
                // Beim Löschen und Cancel ()neue datensätze) soll kein Post mehr ausgeführt werden:
                // "&& !qry.IsDeleting" hinzugefügt

                // 10.07.2009 : bei Batchupdate soll das BeforePost auch ausgeführt werden
                // Im Post wird am richtigen Ort ausgestiegen, wenn Batchupdate = true ist
                // deshalb "&& !qry.BatchUpdate" entfernt
                //if (e.Allow && !qry.BatchUpdate && !qry.IsDeleting)

                // TODO : can be removed, if refactoring in SqlQuery.OnPositionChanging is made
                if (e.Allow && !qry.IsDeleting && !qry.BatchUpdate)
                {
                    e.Allow = qry.Post(false);
                }
            }

            Debug.WriteLine(string.Format("BeforeLeaveRow, {0}, {1}", DateTime.Now.Millisecond, e.Allow));
        }

        private string GetExportTitle()
        {
            /* ----------------------------------------------------------------
             * Make sure that:
             * - The name that you type does not exceed 31 characters.
             * - The name does not contain any of the following characters:  :  \  /  ?  *
             * - You did not leave the name blank.
             * ---------------------------------------------------------------- */
            return string.Format("KiSS Export, {0:dd}.{0:MM}.{0:yy} {0:t}", DateTime.Now).Replace(":", ".");
        }

        private void ShowHideMenuItem(DevExpress.XtraBars.BarButtonItem item, bool visible)
        {
            if (visible)
            {
                item.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Validates the editor.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs"/> instance containing the event data.</param>
        private void ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Trim() == "")
            {
                //this.View.HideEditor(); Absturz ab DevExpress-Release 4. Juli 2004
                View.SetRowCellValue(View.FocusedRowHandle, View.FocusedColumn, null);
                e.Value = null;
            }

            e.Valid = true;
        }

        #endregion Private Methods

        #endregion Methods
    }
}