using System;
using System.Windows;

using DevExpress.Utils;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls
{
    public class GridColumnSelection : GridColumn
    {
        public static readonly DependencyProperty IsAllRowsSelectedProperty;

        private bool _isUpdating;

        static GridColumnSelection()
        {
            IsAllRowsSelectedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<GridColumnSelection>(x => x.IsAllRowsSelected),
                    typeof(bool?),
                    typeof(GridColumnSelection),
                    new PropertyMetadata(false, OnIsAllRowsSelectedPropertyChanged));
        }

        public GridColumnSelection()
        {
            Width = 23d;
            FixedWidth = true;
            AllowAutoFilter = false;
            AllowBestFit = DefaultBoolean.False;
            AllowColumnFiltering = DefaultBoolean.False;
            AllowColumnFiltering = DefaultBoolean.False;
            AllowGrouping = DefaultBoolean.False;
            AllowSorting = DefaultBoolean.False;
        }

        public event EventHandler SelectionChanged;

        public GridControl Grid { get { return GridView.Grid; } }

        public TableView GridView { get { return (TableView)View; } }

        public bool? IsAllRowsSelected
        {
            get { return (bool?)GetValue(IsAllRowsSelectedProperty); }
            set { SetValue(IsAllRowsSelectedProperty, value); }
        }

        protected override void OnOwnerChanged()
        {
            base.OnOwnerChanged();
            GridView.CellValueChanged += GridView_CellValueChanged;

            //Damit nicht zuerst die Zeile selektiert werden muss, damit anschliessend die Checkbox selektiert werden kann.
            GridView.EditorShowMode = EditorShowMode.MouseDown;
        }

        private static void OnIsAllRowsSelectedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = (GridColumnSelection)d;

            if (column.Grid != null)
            {
                var value = e.NewValue as bool?;

                if (value.HasValue)
                {
                    column.SetIsSelectedForAllRows(value == true);
                    column.OnSelectionChanged();
                }
            }
        }

        private void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == this)
            {
                UpdateIsAllRowsSelected();
                OnSelectionChanged();
            }
        }

        private void OnSelectionChanged()
        {
            if (SelectionChanged != null && !_isUpdating)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }

        private void SetIsSelectedForAllRows(bool value)
        {
            _isUpdating = true;

            for (var i = 0; i < Grid.VisibleRowCount; i++)
            {
                var handle = Grid.GetRowHandleByVisibleIndex(i);

                if (Grid.IsGroupRowHandle(handle))
                {
                    continue;
                }

                Grid.SetCellValue(handle, FieldName, value);
            }

            _isUpdating = false;
        }

        private void UpdateIsAllRowsSelected()
        {
            if (_isUpdating)
            {
                return;
            }

            var allSelected = true;
            var allUnselected = true;

            //In case there are no rows visible, nothing can be selected -> allSelected = false
            if (Grid.VisibleRowCount == 0)
            {
                allSelected = false;
            }

            for (int i = 0; i < Grid.VisibleRowCount; i++)
            {
                var handle = Grid.GetRowHandleByVisibleIndex(i);

                if (Grid.IsGroupRowHandle(handle))
                {
                    continue;
                }

                var selected = Grid.GetCellValue(handle, FieldName) as bool?;

                if (selected.HasValue)
                {
                    if (selected.Value)
                    {
                        allUnselected = false;
                    }
                    else
                    {
                        allSelected = false;
                    }
                }
            }

            if (!allSelected && !allUnselected)
            {
                IsAllRowsSelected = null;
            }
            else if (allSelected)
            {
                IsAllRowsSelected = true;
            }
            else
            {
                IsAllRowsSelected = false;
            }
        }
    }
}