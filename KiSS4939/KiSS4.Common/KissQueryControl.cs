using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI.BarCode;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Specialized class for using in FrmDataExplorer as a Query
    /// </summary>
    public partial class KissQueryControl : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The regular expression to remove all non alphanummeric chars from columnname
        /// </summary>
        private static readonly Regex _rxColumnName = new Regex(@"[^a-z0-9]?", RegexOptions.IgnoreCase);

        #endregion Private Static Fields

        #region Private Fields

        /// <summary>
        /// Store active grid to setup controls depending on it
        /// </summary>
        private KissGrid _activeGrid;

        /// <summary>
        /// Set to allow grouping rows in grid. Checkbox will be hidden if not allowed
        /// </summary>
        private bool _allowGrouping;

        /// <summary>
        /// Set to allow selecting multiple rows in grid. Checkbox will be hidden if not allowed
        /// </summary>
        private bool _allowMultiselecting;

        /// <summary>
        /// Set to start a new search after control was loaded or user defined behaviour
        /// </summary>
        private bool _startNewSearchOnLoad = true;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor of class
        /// </summary>
        public KissQueryControl()
        {
            InitializeComponent();

            lblSuchkriterienInfo.Text = "";
            ttpSuchkriterienInfo.SetToolTip(lblSuchkriterienInfo, string.Empty);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Liste der Controls die im Suchkriterium labels während der Suche gefüllt werden
        /// </summary>
        protected List<KeyValuePair<string, BaseEdit>> _suchKriteriumCtrItems = new List<KeyValuePair<string, BaseEdit>>();

        /// <summary>
        /// Set to allow selecting multiple rows in grid. Checkbox will be hidden if not allowed
        /// </summary>
        // Sollte nicht durch den Designer gesetzt werden. Kann zur Folge haben dass RunSearch ausgeführt wird, bevor IntializeComponent
        // beendet wurde. Siehe #6074.
        //[Browsable(true)]
        //[DefaultValue(false)]
        //[Description("Set to allow selecting multiple rows in grid. Checkbox will be hidden if not allowed.")]
        public bool AllowGrouping
        {
            get { return _allowGrouping; }
            set
            {
                _allowGrouping = value;

                // stop here if designmode
                if (DesignMode)
                {
                    return;
                }

                // hide control if not allowed to change
                chkShowGroupPanel.Visible = value;

                // if not allowed to select multiple rows
                if (!value)
                {
                    chkShowGroupPanel.Checked = false;
                    chkShowGroupPanel.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        /// <summary>
        /// Set to allow selecting multiple rows in grid. Checkbox will be hidden if not allowed
        /// </summary>
        // Sollte nicht durch den Designer gesetzt werden. Kann zur Folge haben dass RunSearch ausgeführt wird, bevor IntializeComponent
        // beendet wurde. Siehe #6074.
        //[Browsable(true)]
        //[DefaultValue(false)]
        //[Description("Set to allow selecting multiple rows in grid. Checkbox will be hidden if not allowed.")]
        public bool AllowMultiselecting
        {
            get { return _allowMultiselecting; }
            set
            {
                _allowMultiselecting = value;

                // stop here if designmode
                if (DesignMode)
                {
                    return;
                }

                // hide control if not allowed to change
                chkMultilineSelect.Visible = value;

                // if not allowed to select multiple rows
                if (!value)
                {
                    chkMultilineSelect.Checked = false;
                    chkMultilineSelect.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        /// <summary>
        /// Set to start a new search after control was loaded or user defined behaviour
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Set to start a new search after control was loaded or user defined behaviour")]
        public bool StartNewSearchOnLoad
        {
            get { return _startNewSearchOnLoad; }
            set { _startNewSearchOnLoad = value; }
        }

        #endregion Properties

        #region EventHandlers

        /// <summary>
        /// The RowCountChanged event on gridview to update label for counting rows
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        protected virtual void gridView_RowCountChanged(object sender, EventArgs e)
        {
            // update count label for active grid
            UpdateCountLabel(_activeGrid);
        }

        /// <summary>
        /// The CheckedChanged event on checkbox to allow or deny multiselection in grid
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void chkMultilineSelect_CheckedChanged(object sender, EventArgs e)
        {
            // validate
            if (_activeGrid == null || _activeGrid.View == null || !AllowMultiselecting)
            {
                return;
            }

            // get current selected row
            int selectedRow = _activeGrid.View.FocusedRowHandle;

            // set gridstyle depending on checkbox state
            _activeGrid.View.OptionsSelection.MultiSelect = chkMultilineSelect.Checked;

            // reset previous selected row
            _activeGrid.View.SelectRow(selectedRow);
        }

        /// <summary>
        /// The CheckedChanged event on checkbox to group data in grid
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void chkShowGroupPanel_CheckedChanged(object sender, EventArgs e)
        {
            // validate
            if (_activeGrid == null || _activeGrid.View == null)
            {
                return;
            }

            // show group panel on view
            _activeGrid.View.OptionsView.ShowGroupPanel = chkShowGroupPanel.Checked;

            // reset grouping on unchecking checkbox
            if (!chkShowGroupPanel.Checked)
            {
                _activeGrid.View.ClearGrouping();
            }
        }

        /// <summary>
        /// The SelectionChanged event on gridview to update label for counting rows on multiselection
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            // update count label for active grid
            UpdateCountLabel(_activeGrid);
        }

        /// <summary>
        /// Loading event for control, used to initialize controls, etc.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void KissQueryControl_Load(object sender, EventArgs e)
        {
            // do nothing in designmode
            if (DesignMode)
            {
                return;
            }

            // move tpgSearch always to the right side
            // Um das Flackern beim Öffnen der Abfrage zu verhindern,
            // verwenden wir BeginUpdate/EndUpdate
            tabControlSearch.BeginUpdate();
            try
            {
                kissSearch.Disabled = true;
                try
                {
                    // Hier wird sichergestellt, dass tpgSuchen als letzter Tab erscheint.
                    // Dies kann nicht im Design gemacht werden,
                    // da je nach Abfrage weitere Ritter automatisch erstellt werden.
                    tabControlSearch.TabPages.Remove(tpgSuchen);
                    tabControlSearch.TabPages.Add(tpgSuchen);
                }
                finally
                {
                    kissSearch.Disabled = false;
                }
            }
            finally
            {
                tabControlSearch.EndUpdate();
            }

            // add all queries found on each grid to components of this class
            foreach (Control ctl in UtilsGui.AllControls(this, false))
            {
                // check if current control is a grid and grid has a datasource
                if (ctl != null && typeof(KissGrid).IsAssignableFrom(ctl.GetType()) && ((KissGrid)ctl).DataSource != null
                    && typeof(SqlQuery).IsAssignableFrom(((KissGrid)ctl).DataSource.GetType()))
                {
                    // get query from new grid
                    SqlQuery qry = (SqlQuery)((KissGrid)ctl).DataSource;

                    // ensure qry is not qryQuery
                    if (qry == qryQuery)
                    {
                        // do nothing with this query
                        continue;
                    }

                    // add query of grid to componenents to know it later on
                    components.Add(qry);

                    // register query with kissSearch and fill it when kissSearch is filled
                    new KissSearch(kissSearch, qry);
                }
            }

            // need to start a new search?
            if (StartNewSearchOnLoad)
            {
                // start a new search (default behaviour)
                NewSearch();
            }

            // udpate tab
            tabControlSearch_SelectedTabChanged(tabControlSearch.SelectedTab);
        }

        /// <summary>
        /// After fill event from sqlQuery, used to setup the grid with new data
        /// </summary>
        /// <param name="sender">The sender of the event (mostly the sqlQuery)</param>
        /// <param name="e">The event arguments</param>
        private void sqlQuery_AfterFill(object sender, EventArgs e)
        {
            // check if sender is an sqlquery
            if (sender == null || !typeof(SqlQuery).IsAssignableFrom(sender.GetType()))
            {
                // invalid or no sqlquery
                return;
            }

            // loop all controls
            foreach (Control ctl in UtilsGui.AllControls(this, false))
            {
                // check if current control is a grid and grid has the sqlquery (sender) as it's datasource
                if (ctl != null && typeof(KissGrid).IsAssignableFrom(ctl.GetType()) && ((KissGrid)ctl).DataSource == sender)
                {
                    SetupDataSourceAndGridColumns((KissGrid)ctl, (SqlQuery)sender);
                }
            }
        }

        /// <summary>
        /// The SelectedTabChanged event on tabControlSearch, used to setup controls depending on current tabPage
        /// </summary>
        /// <param name="page">The tabpage that was selected from user</param>
        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            try
            {
                // do nothing in designmode
                if (DesignMode)
                {
                    return;
                }

                // reset states
                UpdateCountLabel(null);
                UpdateGroupCheckBoxState(null);
                UpdateMultiselectCheckBoxState(null);
                UpdateRowCountEventHandler(_activeGrid, null);

                // reset active grid (after resetting controls!)
                _activeGrid = null;

                // reset to default checkbox states (after resetting grid due to CheckedChanged event!)
                chkShowGroupPanel.Checked = false;
                chkMultilineSelect.Checked = false;

                // loop controls of current tab
                foreach (Control ctl in UtilsGui.AllControls(page, false))
                {
                    // check if current control is a grid
                    if (ctl != null && typeof(KissGrid).IsAssignableFrom(ctl.GetType()))
                    {
                        // page contains a grid, store it and use it for updating other controls
                        _activeGrid = (KissGrid)ctl;

                        // update label and checkbox
                        UpdateCountLabel(_activeGrid);
                        UpdateGroupCheckBoxState(_activeGrid);
                        UpdateMultiselectCheckBoxState(_activeGrid);
                        UpdateRowCountEventHandler(null, _activeGrid);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                // reset states
                UpdateCountLabel(null);
                UpdateGroupCheckBoxState(null);
                UpdateMultiselectCheckBoxState(null);
                UpdateRowCountEventHandler(_activeGrid, null);

                // reset active grid (after resetting!!)
                _activeGrid = null;

                // do nothing unless is debugger
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        #endregion EventHandlers

        #region Methods

        protected virtual void grdQuery1_DoubleClick(object sender, EventArgs e)
        {
        }

        protected override void RunSearch()
        {
            ShowSearchedParams();
            base.RunSearch();
        }

        protected virtual string SetSearchedParams()
        {
            var suchkriterienInfoText = string.Empty;
            var isFirst = true;

            foreach (var item in _suchKriteriumCtrItems.Where(item => !DBUtil.IsEmpty(item.Value.EditValue)))
            {
                var infoText = string.Empty;

                if (item.Value.GetType() == typeof(KissCheckEdit))
                {
                    if (item.Value.EditValue as bool? ?? false)
                    {
                        infoText += item.Key;
                    }
                }
                else if (item.Value.GetType() == typeof(KissDateEdit))
                {
                    infoText += item.Key + ": ";
                    infoText += string.Format("{0:dd.MM.yyyy}", item.Value.EditValue);
                }
                else
                {
                    infoText += item.Key + ": ";
                    infoText += item.Value.EditValue;
                }

                if (!string.IsNullOrEmpty(infoText))
                {
                    suchkriterienInfoText += isFirst ? "" : ", ";
                    suchkriterienInfoText += infoText;
                    isFirst = false;
                }
            }

            return suchkriterienInfoText;
        }

        private void ShowSearchedParams()
        {
            string suchkriterienInfoText = SetSearchedParams();
            if (!string.IsNullOrEmpty(suchkriterienInfoText))
            {
                lblSuchkriterienInfo.Visible = true;

                lblSuchkriterienInfo.Text = suchkriterienInfoText;
                ttpSuchkriterienInfo.SetToolTip(lblSuchkriterienInfo, suchkriterienInfoText);
            }
            else
            {
                lblSuchkriterienInfo.Visible = false;
            }
        }

        #region Protected Methods

        /// <summary>
        /// Initialize control for a new search
        /// </summary>
        protected override void NewSearch()
        {
            // do nothing in designmode
            if (DesignMode)
            {
                return;
            }

            // init new search from baseclass
            base.NewSearch();

            // loop through components and setup queries
            foreach (Component comp in components.Components)
            {
                // check if current control is a query
                if (comp != null && typeof(SqlQuery).IsAssignableFrom(comp.GetType()))
                {
                    // clear query
                    ((SqlQuery)comp).DataSet.Clear();

                    // attach event (if not yet done)
                    ((SqlQuery)comp).AfterFill -= sqlQuery_AfterFill;
                    ((SqlQuery)comp).AfterFill += sqlQuery_AfterFill;
                }
            }
        }

        /// <summary>
        /// Resets the cached columns if another select statement has to be called.
        /// Call this from RunSearch() before the call to base.RunSearch().
        /// </summary>
        protected void ResetSelectColumns()
        {
            grdQuery1.DataSource = null;
            grvQuery1.Columns.Clear();
            qryQuery.DataSet.Relations.Clear();

            foreach (DataTable table in qryQuery.DataSet.Tables)
            {
                table.Constraints.Clear();
            }

            qryQuery.DataTable.Columns.Clear();

            grdQuery1.DataSource = qryQuery;
        }

        protected void SetupDataSourceAndGridColumns(KissGrid grid, SqlQuery dataSource)
        {
            // remove and reset datasource for grid (due to update problems...)
            grid.DataSource = null;
            grid.DataSource = dataSource;

            SetupGridColumns(grid);
        }

        protected void SetupDataSourceAndGridColumns(KissGrid grid, DataView dataSource)
        {
            // remove and reset datasource for grid (due to update problems...)
            grid.DataSource = null;
            grid.DataSource = dataSource;

            SetupGridColumns(grid);
        }

        protected void SetupDataSourceAndGridColumns(KissGrid grid, DataTable dataSource)
        {
            // remove and reset datasource for grid (due to update problems...)
            grid.DataSource = null;
            grid.DataSource = dataSource;

            SetupGridColumns(grid);
        }

        /// <summary>
        /// Setup columns in grid
        /// </summary>
        /// <param name="grid">The grid to process</param>
        protected void SetupGridColumns(KissGrid grid)
        {
            var tbl = grid.DataSource as DataTable;

            if (tbl == null && grid.DataSource is SqlQuery)
            {
                tbl = ((SqlQuery)grid.DataSource).DataTable;
            }
            else if (tbl == null && grid.DataSource is DataView)
            {
                tbl = ((DataView)grid.DataSource).Table;
            }

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grid.View.Columns)
            {
                //set grid columns with fieldnames ending with $ to invisible
                if (col.FieldName.EndsWith("$"))
                {
                    col.VisibleIndex = -1;
                    //before removing the $, we have to make sure if the caption still contains it. (If the Search is performed a second time, it is already removed)
                    if (col.Caption.EndsWith("$"))
                    {
                        col.Caption = col.Caption.Remove(col.Caption.Length - 1);
                    }
                }

                //set numeric format for money and datetime columns (only if no format is specified)
                try
                {
                    if (tbl != null && string.IsNullOrEmpty(col.DisplayFormat.FormatString) && tbl.Columns.Contains(col.FieldName))
                    {
                        if (tbl.Columns[col.FieldName].DataType == typeof(Decimal))
                        {
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.DisplayFormat.FormatString = "n2";
                        }
                        else if (tbl.Columns[col.FieldName].DataType == typeof(DateTime))
                        {
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            col.DisplayFormat.FormatString = "d";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in SetupGridColumns(KissGrid): {0}", ex.Message);
                }

                // Multilanguage handling
                try
                {
                    // prepare columnname for objectname
                    string colName = col.Name;
                    colName = _rxColumnName.Replace(colName, "").Trim();

                    // insert column into database (if column is not yet in database) to have it translateable
                    // apply new caption to column
                    col.Caption = Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(@"
                        -- init vars
                        DECLARE @ClassName VARCHAR(255)
                        DECLARE @ColumnName VARCHAR(255)
                        DECLARE @Caption VARCHAR(2000)
                        DECLARE @LanguageCode INT
                        DECLARE @TID INT

                        -- set vars
                        SET @ClassName    = {0}
                        SET @ColumnName   = {1}
                        SET @Caption      = {2}
                        SET @LanguageCode = {3}

                        -- check if column already exists
                        IF (NOT EXISTS(SELECT TOP 1 1
                                        FROM dbo.XClassComponent WITH (READUNCOMMITTED)
                                        WHERE ClassName = @ClassName
                                            AND ComponentName = @ColumnName))
                        BEGIN
                            -- insert column as component of class
                            INSERT INTO dbo.XClassComponent (ClassName, ComponentName, TypeName)
                            VALUES (@ClassName, @ColumnName, 'DevExpress.XtraGrid.Columns.GridColumn')

                            -- insert new tid for column-component (german as default text)
                            EXEC dbo.spXSetXLangText NULL, 1, @Caption, @ClassName, @ColumnName, 1, NULL, NULL
                        END
                        ELSE IF (EXISTS(SELECT TOP 1 1
                                        FROM dbo.XClassComponent WITH (READUNCOMMITTED)
                                        WHERE ClassName = @ClassName
                                            AND ComponentName = @ColumnName
                                            AND ComponentTID IS NULL))
                        BEGIN
                            -- no tid applied, entry will not have a title in translation dialog!
                            -- insert new tid for column-component (german as default text)
                            EXEC dbo.spXSetXLangText NULL, 1, @Caption, @ClassName, @ColumnName, 1, NULL, NULL
                        END

                        -- get current tid
                        SELECT @TID = ISNULL(ComponentTID , -1)
                        FROM dbo.XClassComponent WITH (READUNCOMMITTED)
                        WHERE ClassName = @ClassName AND ComponentName = @ColumnName

                        -- select caption (possibly translated) of column
                        SELECT ISNULL(dbo.fnGetMLText(@TID, @LanguageCode), @Caption)", Name,
                                                                                        colName,
                                                                                        col.Caption,
                                                                                        Session.User.LanguageCode));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }

            // autosize column's width
            grid.View.BestFitMaxRowCount = 100; //make sure, we only consider the first 100 rows
            grid.View.BestFitColumns();
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Update label to count rows for desired (active) grid
        /// </summary>
        /// <param name="grid">The grid to process</param>
        protected virtual void UpdateCountLabel(KissGrid grid)
        {
            // validate
            if (grid == null || grid.View == null)
            {
                lblRowCount1.Text = "-";
                return;
            }

            // check if multiselection
            if (AllowMultiselecting)
            {
                if (chkMultilineSelect.Checked && grid.View.SelectedRowsCount > 1)
                {
                    // multilines, show amount of selected lines as well
                    lblRowCount1.Text = string.Format("{0}/{1}", grid.View.SelectedRowsCount, grid.View.RowCount);
                }
                else
                {
                    // show amount of rows in label
                    lblRowCount1.Text = grid.View.RowCount.ToString();
                }
            }
            else
            {
                // show amount of rows in label (rather use DataRowCount than RowCount, since RowCount contains the additional rows for grouping)
                lblRowCount1.Text = grid.View.DataRowCount.ToString();
            }
        }

        /// <summary>
        /// Update state of checkbox for grouping depending on grid and handle enabled mode
        /// </summary>
        /// <param name="grid">The grid to process</param>
        private void UpdateGroupCheckBoxState(KissGrid grid)
        {
            // validate
            if (grid == null || grid.View == null)
            {
                chkShowGroupPanel.EditMode = EditModeType.ReadOnly;
                return;
            }

            // set checked state depeding on grouping
            chkShowGroupPanel.Checked = grid.View.OptionsView.ShowGroupPanel;
            chkShowGroupPanel.EditMode = EditModeType.Normal;
        }

        /// <summary>
        /// Update state of checkbox for setting of multiple row selection allowed and handle enabled mode
        /// </summary>
        /// <param name="grid">The grid to process</param>
        private void UpdateMultiselectCheckBoxState(KissGrid grid)
        {
            // validate
            if (grid == null || _activeGrid.View == null || !AllowMultiselecting)
            {
                chkMultilineSelect.EditMode = EditModeType.ReadOnly;
                return;
            }

            // set checked state depeding on current mode
            chkMultilineSelect.Checked = _activeGrid.View.OptionsSelection.MultiSelect;
            chkMultilineSelect.EditMode = EditModeType.Normal;
        }

        /// <summary>
        /// Update event handler for RowCountChanged on gridview
        /// </summary>
        /// <param name="previousActiveGrid">The previous active grid</param>
        /// <param name="newActiveGrid">The new active grid</param>
        private void UpdateRowCountEventHandler(KissGrid previousActiveGrid, KissGrid newActiveGrid)
        {
            try
            {
                // validate previousActiveGrid
                if (previousActiveGrid != null && previousActiveGrid.View != null)
                {
                    // remove event handlers on old active gridview
                    previousActiveGrid.View.RowCountChanged -= gridView_RowCountChanged;
                    previousActiveGrid.View.SelectionChanged -= gridView_SelectionChanged;
                }

                // validate newActiveGrid
                if (newActiveGrid != null && newActiveGrid.View != null)
                {
                    // add event handlers on new active gridview
                    newActiveGrid.View.RowCountChanged += gridView_RowCountChanged;
                    newActiveGrid.View.SelectionChanged += gridView_SelectionChanged;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                // do nothing unless is debugger
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
            }
        }

        #endregion Private Methods

        #endregion Methods
    }
}