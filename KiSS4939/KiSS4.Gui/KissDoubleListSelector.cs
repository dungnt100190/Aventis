using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// User Control which allows to multiselect values by moving them from one list of available items (on the left) to the list of selected items (on the right)
    /// </summary>
    public partial class KissDoubleListSelector : UserControl
    {
        #region Fields

        #region Private Fields

        private string _colNameToShowInList = "";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// c'tor. To initialize the control, you need to call the Initialize() method. 
        /// </summary>
        public KissDoubleListSelector()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// All items have been selected  by clicking on the appropriate button.
        ///  Change will not be reflected in GetSelectedItems yet.
        /// </summary>
        public event EventHandler AddAllItemsClick;

        /// <summary>
        ///  An item has been selected by clicking on the appropriate button. 
        ///  Change will not be reflected in GetSelectedItems yet.
        /// </summary>
        public event KissDoubleListSelectorEventHandler AddItemClick;

        /// <summary>
        /// All items have been unselected  by clicking on the appropriate button.
        /// Change will not be reflected in GetSelectedItems yet.
        /// </summary>
        public event EventHandler RemoveAllItemsClick;

        /// <summary>
        /// An item has been unselected  by clicking on the appropriate button.
        /// Change will not be reflected in GetSelectedItems yet.
        /// </summary>
        public event KissDoubleListSelectorEventHandler RemoveItemClick;

        /// <summary>
        /// Selection Changed event.
        /// Change will  be reflected in GetSelectedItems.
        /// Call to Select.. will fire this event too.
        /// </summary>
        public event EventHandler SelectionChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Hides or shows the AddAll button. 
        /// Useful especially if there is a huge list to select from.
        /// </summary>
        public bool ButtonRemoveAllVisible
        {
            get { return btnAddAll.Visible; }
            set { btnAddAll.Visible = value; }
        }

        #endregion

        #region EventHandlers

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            Clear(qryAvailable);
            Fill(qrySelected);

            //Call event handlers.
            if(AddAllItemsClick != null)
            {
                AddAllItemsClick(this, EventArgs.Empty);
            }
            FireSelectionChangedEvent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(AddItemClick != null)
            {
                KissDoubleListSelectorEventArgs args = new KissDoubleListSelectorEventArgs();
                args.ItemRow = qryAvailable.Row;
                AddItemClick(this, args);
            }
            SelectRow(qryAvailable.Row);
            FireSelectionChangedEvent();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            Fill(qryAvailable);
            Clear(qrySelected);

            //Call event handlers.
            if(RemoveAllItemsClick != null)
            {
                RemoveAllItemsClick(this, EventArgs.Empty);
            }
            FireSelectionChangedEvent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Call event handlers.
            if (RemoveItemClick != null && qrySelected.Row != null)
            {
                KissDoubleListSelectorEventArgs eventArgs = new KissDoubleListSelectorEventArgs();
                eventArgs.ItemRow = qrySelected.Row;
                RemoveItemClick(this, eventArgs);
            }
            UnselectRow(qrySelected.Row);
            FireSelectionChangedEvent();
        }

        private void edtFilter2_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";
            if (!DB.DBUtil.IsEmpty(edtFilter2.EditValue))
                value = edtFilter2.EditValue.ToString();

            qrySelected.DataTable.DefaultView.RowFilter = _colNameToShowInList + " like '%" + value + "%'";
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";
            if (!DB.DBUtil.IsEmpty(edtFilter.EditValue))
                value = edtFilter.EditValue.ToString();

            qryAvailable.DataTable.DefaultView.RowFilter = _colNameToShowInList + " like '%" + value + "%'";
        }

        private void grdAvailable_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled) btnAdd.PerformClick();
        }

        private void grdSelected_DoubleClick(object sender, EventArgs e)
        {
            if (btnRemove.Enabled) btnRemove.PerformClick();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Returns a list of all still available items 
        /// </summary>
        /// <returns></returns>
        public List<string> GetAvailable()
        {
            List<string> list = new List<string>();

            foreach (DataRow row in qryAvailable.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    list.Add(row[_colNameToShowInList].ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// Returns a list of all still available items, but from a hidden column from the SQL-Statement which was used to initialize the list
        /// </summary>
        /// <param name="hiddenColName"></param>
        /// <returns></returns>
        public List<string> GetAvailableHiddenCol(string hiddenColName)
        {
            List<string> list = new List<string>();

            foreach (DataRow row in qryAvailable.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    list.Add(row[hiddenColName].ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// Returns a list of all selected items
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelected()
        {
            List<string> list = new List<string>();

            foreach (DataRow row in qrySelected.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    list.Add(row[_colNameToShowInList].ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// Returns a list of all selected items, but from a hidden column from the SQL-Statement which was used to initialize the list
        /// </summary>
        /// <param name="hiddenColName"></param>
        /// <returns></returns>
        public List<string> GetSelectedHiddenCol(string hiddenColName)
        {
            List<string> list = new List<string>();

            foreach (DataRow row in qrySelected.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    list.Add(row[hiddenColName].ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// Initialises the control and fills the left box with the sql
        /// All already selected items are cleared, so the right hand list will be empty after this method
        /// </summary>
        /// <param name="sql">SQL-Statement to initially fill the available items list.</param>
        /// <param name="colNameToShowInList">Column Name from the SQL-Statement which will be used to fill the lists</param>
        /// <param name="captionAvailable">Caption for the list of available items</param>
        /// <param name="captionSelected">Capction for the list of selected items</param>
        public void Initialize(string sql, string colNameToShowInList, string captionAvailable, string captionSelected)
        {
            qryAvailable.SelectStatement = sql;
            qrySelected.SelectStatement = sql;
            _colNameToShowInList = colNameToShowInList;
            colTitleAvailable.Caption = captionAvailable;
            colTitleSelected.Caption = captionSelected;
            colTitleAvailable.FieldName = colNameToShowInList;
            colTitleSelected.FieldName = colNameToShowInList;

            edtFilter.EditValue = null;
            edtFilter2.EditValue = null;

            Fill(qryAvailable);
            Clear(qrySelected);
        }

        /// <summary>
        /// Moves all items in the ToSelect-List over to the right hand list of selected items.
        /// If an item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toSelect"></param>
        public void Select(List<string> toSelect)
        {
            Select(toSelect, _colNameToShowInList);
        }

        /// <summary>
        /// Moves all items in the ToSelect-List over to the right hand list of selected items.
        /// It uses the specified hiddenColNameToCompare to compare the items
        /// If an item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toSelect"></param>
        /// <param name="hiddenColNameToCompare"></param>
        public void Select(List<string> toSelect, string hiddenColNameToCompare)
        {
            foreach(DataRow row in qryAvailable.DataTable.Rows)
            {
                if (toSelect.Contains(row[hiddenColNameToCompare].ToString()))
                {
                    SelectRow(row);
                }
            }
            FireSelectionChangedEvent();
        }

        /// <summary>
        /// Moves the ToSelect-Item over to the right hand list of selected items.
        /// If the item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toSelect"></param>
        public void Select(string toSelect)
        {
            Select(toSelect, _colNameToShowInList);
        }

        /// <summary>
        /// Moves the ToSelect-Item over to the right hand list of selected items.
        /// It uses the specified hiddenColNameToCompare to compare the item
        /// If the item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toSelect"></param>
        /// <param name="hiddenColNameToCompare"></param>
        public void Select(string toSelect, string hiddenColNameToCompare)
        {
            foreach (DataRow row in qryAvailable.DataTable.Rows)
            {
                if (toSelect.Equals(row[hiddenColNameToCompare].ToString()))
                {
                    SelectRow(row);
                }
            }
            FireSelectionChangedEvent();
        }

        /// <summary>
        /// Moves all items from the available list to the selected list. 
        /// The list of available items will be empty afterwards
        /// This method is equivalent to the user pressing the "Add All"-button
        /// </summary>
        public void SelectAll()
        {
            btnAddAll.PerformClick();
        }

        /// <summary>
        /// Moves all items in the ToSelect-List back to the left hand list of availabe items and clears them from the list of selected items.
        /// If an item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toUnselect"></param>
        public void Unselect(List<string> toUnselect)
        {
            Unselect(toUnselect, _colNameToShowInList);
        }

        /// <summary>
        /// Moves all items in the ToSelect-List back to the left hand list of availabe items and clears them from the list of selected items.
        /// It uses the specified hiddenColNameToCompare to compare the items
        /// If an item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toUnselect"></param>
        /// <param name="hiddenColNameToCompare"></param>
        public void Unselect(List<string> toUnselect, string hiddenColNameToCompare)
        {
            foreach(DataRow row in qrySelected.DataTable.Rows)
            {
                if (toUnselect.Contains(row[hiddenColNameToCompare].ToString()))
                {
                    UnselectRow(row);
                }
            }
            FireSelectionChangedEvent();
        }

        /// <summary>
        /// Moves the toUnselect-Item back to the left hand list of availabe items and clears is from the list of selected items.
        /// If the item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toUnselect"></param>
        public void Unselect(string toUnselect)
        {
            Unselect(toUnselect, _colNameToShowInList);
        }

        /// <summary>
        /// Moves the toUnselect-Item back to the left hand list of availabe items and clears is from the list of selected items.
        /// It uses the specified hiddenColNameToCompare to compare the item
        /// If the item is not found in the list of available items, it will be ignored.
        /// </summary>
        /// <param name="toUnselect"></param>
        /// <param name="hiddenColNameToCompare"></param>
        public void Unselect(string toUnselect, string hiddenColNameToCompare)
        {
            foreach (DataRow row in qrySelected.DataTable.Rows)
            {
                if (toUnselect.Equals(row[hiddenColNameToCompare].ToString()))
                {
                    UnselectRow(row);
                }
            }
            FireSelectionChangedEvent();
        }

        /// <summary>
        /// Moves all items from the selected list to the available list. 
        /// The list of selected items will be empty afterwards. 
        ///
        /// </summary>
        public void UnselectAll()
        {
            //Claude: I replaced the btnRemoveAll.PerformClick() with Fill and Clear. What are the reasons to
            //do otherwise? Possibliy threading.
            Fill(qryAvailable);
            Clear(qrySelected);

            //This method is equivalent to the user pressing the "Remove All"-button
            //btnRemoveAll.PerformClick();
        }

        #endregion

        #region Private Methods

        private static void Clear(DB.SqlQuery qry)
        {
            if (qry.DataTable.Columns.Count == 0)
            {
                qry.Fill();
            }

            qry.DataTable.Rows.Clear();
        }

        private static void Fill(DB.SqlQuery qry)
        {
            qry.Fill();
        }

        /// <summary>
        /// Fires a selection changed event.
        /// </summary>
        private void FireSelectionChangedEvent()
        {
            if(SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }

        private void SelectRow(DataRow rowToSelect)
        {
            if (qryAvailable.Count < 1)
                return;

            qrySelected.DataTable.Rows.Add(rowToSelect.ItemArray);
            qryAvailable.DeleteQuestion = null;
            rowToSelect.Delete();
        }

        private void UnselectRow(DataRow rowToUnselect)
        {
            if (qrySelected.Count < 1)
                return;

            qryAvailable.DataTable.Rows.Add(rowToUnselect.ItemArray);
            qrySelected.DeleteQuestion = null;
            rowToUnselect.Delete();
        }

        #endregion

        #endregion
    }
}