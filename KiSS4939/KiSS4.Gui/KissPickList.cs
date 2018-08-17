using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using KiSS4.DB;

namespace KiSS4.Gui
{
    public partial class KissPickList : KissComplexControl
    {
        #region Constructors

        public KissPickList()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        public KissButton ButtonRemove
        {
            get { return btnUnselect; }
        }

        [Browsable(false)]
        public KissButton ButtonRemoveAll
        {
            get { return btnUnselectAll; }
        }

        [Browsable(false)]
        public KissButton ButtonSelect
        {
            get { return btnSelect; }
        }

        [Browsable(false)]
        public KissButton ButtonSelectAll
        {
            get { return btnSelectAll; }
        }

        public string ColumnIDName
        {
            get;
            set;
        }

        public Dictionary<string, string> ColumnsByFieldNameAndCaptionForSourceGrid
        {
            set
            {
                AddColumnsFromDictionaryToGridView(value, grvSource);
            }
        }

        public Dictionary<string, string> ColumnsByFieldNameAndCaptionForTargetGrid
        {
            set
            {
                AddColumnsFromDictionaryToGridView(value, grvTarget);
            }
        }

        public string ColumnValueName
        {
            get;
            set;
        }

        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Category("Data")]
        public SqlQuery DataSourceOfSourceGrid
        {
            get { return (SqlQuery)grdSource.DataSource; }
            set
            {
                if (grdSource.DataSource != null && grdSource.DataSource is SqlQuery)
                {
                    ((SqlQuery)grdSource.DataSource).AfterFill -= new EventHandler(KissPickList_AfterFill);
                }
                grdSource.DataSource = value;
                if (value != null)
                {
                    value.AfterFill += new EventHandler(KissPickList_AfterFill);
                    value.DeleteQuestion = null;
                    value.HostControl = this;
                    updateButtonsAndColumnWith();
                }
            }
        }

        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Category("Data")]
        public SqlQuery DataSourceOfTargetGrid
        {
            get { return (SqlQuery)grdTarget.DataSource; }
            set
            {
                if (grdTarget.DataSource != null && grdTarget.DataSource is SqlQuery)
                {
                    ((SqlQuery)grdTarget.DataSource).AfterFill -= new EventHandler(KissPickList_AfterFill);
                }
                grdTarget.DataSource = value;
                if (value != null)
                {
                    value.AfterFill += new EventHandler(KissPickList_AfterFill);
                    value.DeleteQuestion = null;
                    value.HostControl = this;
                    updateButtonsAndColumnWith();
                }
            }
        }

        public string FilterColumnName
        {
            get;
            set;
        }

        [Browsable(false)]
        public string NotSelectedIds
        {
            get
            {
                string columnIDName;
                if (!DBUtil.IsEmpty(this.ColumnIDName))
                {
                    columnIDName = this.ColumnIDName;
                }
                else
                {
                    columnIDName = GetDefaultIdColumn(DataSourceOfSourceGrid);
                }

                return GetIdsAsCsvString(DataSourceOfSourceGrid, columnIDName);
            }
        }

        [Browsable(false)]
        public string SelectedIds
        {
            get
            {
                string columnIDName;
                if (!DBUtil.IsEmpty(this.ColumnIDName))
                {
                    columnIDName = this.ColumnIDName;
                }
                else
                {
                    columnIDName = GetDefaultIdColumn(DataSourceOfTargetGrid);
                }
                return GetIdsAsCsvString(DataSourceOfTargetGrid, columnIDName);
            }
        }

        [Browsable(false)]
        public string SelectedValues
        {
            get
            {
                if (!DBUtil.IsEmpty(this.ColumnValueName))
                {
                    return GetIdsAsCsvString(DataSourceOfTargetGrid, this.ColumnValueName);
                }

                return null;
            }
        }

        [Category("Behavior")]
        public bool TargetFilterVisible
        {
            get
            {
                return this.panFilterTarget.Visible;
            }
            set
            {
                this.panFilterTarget.Visible = value;
            }
        }

        public bool UseDefaultButtonEvents
        {
            set
            {
                if (value == true)
                {
                    SetDefaultButtonEvents();
                }
                else
                {
                    UnhookButtonEvents();
                }
            }
        }

        #endregion Properties

        #region EventHandlers

        private void btnSelect_Click(object sender, EventArgs e)
        {
            MoveRowToTarget();
            this.updateButtonsAndColumnWith();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            while (DataSourceOfSourceGrid.Count > 0)
            {
                MoveRowToTarget();
            }
            this.updateButtonsAndColumnWith();
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            RemoveRowFromTarget();
            this.updateButtonsAndColumnWith();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            while (DataSourceOfTargetGrid.Count > 0)
            {
                RemoveRowFromTarget();
            }
            this.updateButtonsAndColumnWith();
        }

        private void edtFilterSource_EditValueChanged(object sender, EventArgs e)
        {
            grvSource.Columns[FilterColumnName].FilterInfo = new ColumnFilterInfo(string.Format("{0} LIKE '%{1}%'", FilterColumnName, edtFilterSource.EditValue));
        }

        private void edtFilterTarget_EditValueChanged(object sender, EventArgs e)
        {
            grvTarget.Columns[FilterColumnName].FilterInfo = new ColumnFilterInfo(string.Format("{0} LIKE '%{1}%'", FilterColumnName, edtFilterTarget.EditValue));
        }

        private void KissPickList_AfterFill(object sender, EventArgs e)
        {
            this.updateButtonsAndColumnWith();
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        public void Init(SqlQuery sourceGridDataSource,
            SqlQuery targetGridDataSource,
            Dictionary<string, string> columnsByFieldNameAndCaptionForSourceGrid,
            Dictionary<string, string> columnsByFieldNameAndCaptionForTargetGrid,
            string idColumnName,
            string filterColumnName,
            bool useDefaultButtonEvents)
        {
            DataSourceOfSourceGrid = sourceGridDataSource;
            DataSourceOfTargetGrid = targetGridDataSource;

            ColumnIDName = idColumnName;
            FilterColumnName = filterColumnName;

            ColumnsByFieldNameAndCaptionForSourceGrid = columnsByFieldNameAndCaptionForSourceGrid;
            ColumnsByFieldNameAndCaptionForTargetGrid = columnsByFieldNameAndCaptionForTargetGrid;

            UseDefaultButtonEvents = useDefaultButtonEvents;
        }

        public override void Refresh()
        {
            grdSource.RefreshDataSource();
            grdTarget.RefreshDataSource();
            UpdateRowFilterForSource();
            base.Refresh();
        }

        public void SelectAll()
        {
            this.btnSelectAll_Click(null, null);
        }

        public void UnselectAll()
        {
            this.btnUnselectAll_Click(null, null);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #endregion Protected Methods

        #region Private Static Methods

        public static string GetIdsAsCsvString(SqlQuery dataQuery, string idColumn)
        {
            StringBuilder instTypIds = new StringBuilder();

            var table = dataQuery.DataTable.DefaultView.ToTable();

            if (table.Columns.Contains(idColumn))
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (instTypIds.Length > 0)
                        {
                            instTypIds.Append(",");
                        }
                        instTypIds.Append(row[idColumn]);
                    }
                }
            }

            return instTypIds.ToString();
        }

        #endregion Private Static Methods

        #region Private Methods

        public void UpdateRowFilterForSource()
        {
            string selectedIds = SelectedIds;
            if (selectedIds.Length > 0)
            {
                DataSourceOfSourceGrid.DataTable.DefaultView.RowFilter = string.Format("{0} NOT IN ({1})", ColumnIDName, selectedIds);
            }
            else
            {
                DataSourceOfSourceGrid.DataTable.DefaultView.RowFilter = string.Empty;
            }
        }

        private void AddColumnsFromDictionaryToGridView(Dictionary<string, string> value, GridView gridView)
        {
            gridView.Columns.Clear();

            foreach (var fieldNameAndName in value)
            {
                GridColumn col = gridView.Columns.AddField(fieldNameAndName.Key);
                col.Caption = fieldNameAndName.Value;
                col.Visible = true;
            }
        }

        private string GetDefaultIdColumn(SqlQuery qry)
        {
            foreach (DataColumn column in qry.DataSet.Tables[0].Columns)
            {
                if (column.ColumnName.Length >= 2 && column.ColumnName.Substring(column.ColumnName.Length - 2, 2).ToUpper() == "ID")
                {
                    return column.ColumnName;
                }
            }

            return string.Empty;
        }

        private void MoveRowToTarget()
        {
            try
            {
                if (DataSourceOfSourceGrid.Count > 0)
                {
                    DataRow insertedRow = DataSourceOfTargetGrid.Insert();
                    if (insertedRow != null)
                    {
                        foreach (DataColumn column in DataSourceOfSourceGrid.DataTable.Columns)
                        {
                            insertedRow[column.ColumnName] = DataSourceOfSourceGrid[column.ColumnName];
                        }
                        if (DataSourceOfTargetGrid.BatchUpdate)
                        {
                            insertedRow.AcceptChanges();
                        }

                        UpdateRowFilterForSource();
                    }
                }
            }
            catch (KissErrorException ex)
            {
                ex.ShowMessage();
            }
        }

        private void RemoveRowFromTarget()
        {
            if (DataSourceOfTargetGrid.Count > 0)
            {
                if (DataSourceOfTargetGrid.Row.RowState == DataRowState.Added)
                {
                    DataSourceOfTargetGrid.RowModified = false;
                    DataSourceOfTargetGrid.Cancel();
                }
                else
                {
                    DataSourceOfTargetGrid.Delete();
                }

                UpdateRowFilterForSource();
            }
        }

        private void SetDefaultButtonEvents()
        {
            UnhookButtonEvents();
            btnSelect.Click += new EventHandler(btnSelect_Click);
            btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            btnUnselect.Click += new EventHandler(btnUnselect_Click);
            btnUnselectAll.Click += new EventHandler(btnUnselectAll_Click);
        }

        private void UnhookButtonEvents()
        {
            btnSelect.Click -= new EventHandler(btnSelect_Click);
            btnSelectAll.Click -= new EventHandler(btnSelectAll_Click);
            btnUnselect.Click -= new EventHandler(btnUnselect_Click);
            btnUnselectAll.Click -= new EventHandler(btnUnselectAll_Click);
        }

        private void updateButtonsAndColumnWith()
        {
            bool enableSelect = DataSourceOfSourceGrid != null && DataSourceOfSourceGrid.Count > 0;
            this.btnSelect.Enabled = enableSelect;
            this.btnSelectAll.Enabled = enableSelect;
            bool enableUnselect = DataSourceOfTargetGrid != null && DataSourceOfTargetGrid.Count > 0;
            this.btnUnselect.Enabled = enableUnselect;
            this.btnUnselectAll.Enabled = enableUnselect;
            this.grvSource.OptionsView.ColumnAutoWidth = true;
            this.grvTarget.OptionsView.ColumnAutoWidth = true;
        }

        #endregion Private Methods

        #endregion Methods

        private void grdSource_Load(object sender, EventArgs e)
        {
            updateButtonsAndColumnWith();
        }

        private void grdTarget_Load(object sender, EventArgs e)
        {
            updateButtonsAndColumnWith();
        }
    }
}