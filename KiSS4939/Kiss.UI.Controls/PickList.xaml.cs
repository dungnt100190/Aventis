using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for PickList.xaml
    /// </summary>
    public partial class PickList : IAuthorizable
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<PickList>(x => x.DisplayMemberPath),
                typeof(string),
                typeof(PickList),
                new PropertyMetadata(DisplayMemberPathChanged));
        public static readonly DependencyProperty IsAuthorizedProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<PickList>(x => x.IsAuthorized),
                typeof(bool),
                typeof(PickList),
                new UIPropertyMetadata(true, IsAuthorizedChanged));
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<PickList>(x => x.ItemsSource),
                typeof(IEnumerable),
                typeof(PickList),
                new PropertyMetadata(ItemsSourceChanged));
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<PickList>(x => x.SelectedItems),
                typeof(IList),
                typeof(PickList),
                new PropertyMetadata(SelectedItemsChanged));

        public static new readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<PickList>(x => x.IsEnabled),
                typeof(bool),
                typeof(PickList),
                new UIPropertyMetadata(true, IsEnabledChanged));

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly ObservableCollection<object> _assignedEntities;
        private readonly ObservableCollection<object> _availableEntities;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PickList"/>
        /// </summary>
        public PickList()
        {
            InitializeComponent();

            _availableEntities = new ObservableCollection<object>();
            _availableEntities.CollectionChanged += availableEntities_CollectionChanged;
            grdAvailable.ItemsSource = _availableEntities;

            _assignedEntities = new ObservableCollection<object>();
            _assignedEntities.CollectionChanged += assignedEntities_CollectionChanged;
            grdSelected.ItemsSource = _assignedEntities;

            SelectedItems = new ObservableCollection<object>();

            panRoot.DataContext = this;

            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the visual representation of the object
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public bool IsAuthorized
        {
            get { return (bool)GetValue(IsAuthorizedProperty); }
            set { SetValue(IsAuthorizedProperty, value); }
        }

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        /// <summary>
        /// Gets or sets a collection used to generate the content of the PickList
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the items that are selected in the control
        /// </summary>
        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        private TableView AvailableView
        {
            get { return (TableView)grdAvailable.View; }
        }

        private TableView SelectedView
        {
            get { return (TableView)grdSelected.View; }
        }

        #endregion

        #region EventHandlers

        private void assignedEntities_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CheckCommandAvailability();

            if (SelectedItems == null)
            {
                return;
            }

            // update the external list so the VM gets notified
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                SelectedItems.Clear();
            }
            else
            {
                if (e.NewItems != null)
                {
                    // add new items
                    foreach (var newlySelectedItem in
                        e.NewItems.Cast<object>().Where(newlySelectedItem => !SelectedItems.Contains(newlySelectedItem)))
                    {
                        SelectedItems.Add(newlySelectedItem);
                    }
                }

                if (e.OldItems != null)
                {
                    // remove not selected items
                    foreach (var newlyUnselectedItem in
                        e.OldItems.Cast<object>().Where(newlyUnselectedItem => SelectedItems.Contains(newlyUnselectedItem)))
                    {
                        SelectedItems.Remove(newlyUnselectedItem);
                    }
                }
            }
        }

        private void availableEntities_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CheckCommandAvailability();
        }

        private void btnAssignAll_Click(object sender, RoutedEventArgs e)
        {
            AssignAllItems();
        }

        private void btnAssignSingle_Click(object sender, RoutedEventArgs e)
        {
            AssignSelectedItems();
        }

        private void btnUnassignAll_Click(object sender, RoutedEventArgs e)
        {
            UnassignAllItems();
        }

        private void btnUnassignSingle_Click(object sender, RoutedEventArgs e)
        {
            UnassignSelectedItems();
        }

        private void externalSelectedEntities_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                UnassignAllItems();
            }
            else
            {
                if (e.NewItems != null)
                {
                    // add new items
                    foreach (var itemToSelect in from object itemToSelect in e.NewItems
                                                 where !_assignedEntities.Contains(itemToSelect)
                                                 where _availableEntities.Contains(itemToSelect)
                                                 select itemToSelect)
                    {
                        AssignItem(itemToSelect);
                    }
                }

                if (e.OldItems != null)
                {
                    // remove not selected items
                    foreach (var assignedItem in e.OldItems.Cast<object>().Where(assignedItem => _assignedEntities.Contains(assignedItem)))
                    {
                        UnassignItem(assignedItem);
                    }
                }
            }

            // remove any focused/selected rows by default
            AvailableGridUnselectAll();
            SelectedGridUnselectAll();
        }

        private void grdAvailableView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AssignSelectedItems();
        }

        private void grdAvailableView_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            CheckCommandAvailability();
        }

        private void grdAvailable_GotFocus(object sender, RoutedEventArgs e)
        {
            SelectedGridUnselectAll();
        }

        private void grdSelectedView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UnassignSelectedItems();
        }

        private void grdSelectedView_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            CheckCommandAvailability();
        }

        private void grdSelected_GotFocus(object sender, RoutedEventArgs e)
        {
            AvailableGridUnselectAll();
        }

        private void itemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // ToDo: handle changed original items
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (PickList)d;
            instance.EnforceAuthorize();
        }

        public static new void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (PickList)d;
            instance.EnforceAuthorize();
        }

        #endregion

        #region Private Static Methods

        private static IEnumerable Clone(IEnumerable items)
        {
            var copy = new ArrayList();

            foreach (var item in items)
            {
                copy.Add(item);
            }

            return copy;
        }

        private static void DisplayMemberPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (PickList)d;
            var propertyName = Convert.ToString(e.NewValue);

            // HACK: das ist nicht die eleganteste Variante. Leider klappts weder per Binding (auf ein Binding) noch dürfen die Spalten einen Namen erhalten
            (instance.grdAvailable.Columns[0]).SetBinding(e.Property, new Binding(propertyName));
            (instance.grdAvailable.Columns[0]).FieldName = propertyName;

            (instance.grdSelected.Columns[0]).SetBinding(e.Property, new Binding(propertyName));
            (instance.grdSelected.Columns[0]).FieldName = propertyName;
        }

        private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (PickList)d;
            instance._availableEntities.Clear();
            instance._assignedEntities.Clear();

            var newValue = e.NewValue as INotifyCollectionChanged;
            var oldValue = e.OldValue as INotifyCollectionChanged;

            if (oldValue != null)
            {
                oldValue.CollectionChanged -= instance.itemsSource_CollectionChanged;
            }

            if (newValue != null)
            {
                newValue.CollectionChanged += instance.itemsSource_CollectionChanged;
            }

            foreach (var item in (IEnumerable)e.NewValue)
            {
                instance._availableEntities.Add(item);
            }
        }

        private static void SelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (PickList)d;
            var selectedItemsOld = e.NewValue as IList;
            var selectedItemsNew = e.NewValue as IList;

            instance.SetSelectedItems(selectedItemsOld, selectedItemsNew);
        }

        #endregion

        #region Private Methods

        private void AssignAllItems()
        {
            if (!(grdAvailable.ItemsSource is ICollection))
            {
                // TODO: what else?
                return;
            }

            AssignItems(grdAvailable.ItemsSource as ICollection);
        }

        private void AssignItem(object item)
        {
            _availableEntities.Remove(item);
            _assignedEntities.Add(item);
        }

        private void AssignItems(IEnumerable items)
        {
            foreach (var item in Clone(items))
            {
                AssignItem(item);
            }
        }

        private void AssignSelectedItems()
        {
            AssignItems(AvailableView.SelectedRows);
        }

        private void AvailableGridUnselectAll()
        {
            grdAvailable.SelectedItem = null;
            AvailableView.ClearSelection();
        }

        private void CheckCommandAvailability()
        {
            if (btnAssignAll == null || btnAssignSingle == null || btnUnassignAll == null || btnUnassignSingle == null)
            {
                return;
            }

            var availableEntitiesLeft = _availableEntities != null && _availableEntities.Count > 0;
            btnAssignAll.IsEnabled = availableEntitiesLeft;
            btnAssignSingle.IsEnabled = availableEntitiesLeft && AvailableView.SelectedRows.Count > 0;

            var assignedEntitiesLeft = _assignedEntities != null && _assignedEntities.Count > 0;
            btnUnassignAll.IsEnabled = assignedEntitiesLeft;
            btnUnassignSingle.IsEnabled = assignedEntitiesLeft && SelectedView.SelectedRows.Count > 0;
        }

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsEnabled
            base.IsEnabled = IsAuthorized && IsEnabled;
        }

        private void SelectedGridUnselectAll()
        {
            grdSelected.SelectedItem = null;
            SelectedView.ClearSelection();
        }

        private void SetSelectedItems(IList selectedItemsOld, IList selectedItemsNew)
        {
            // add new items
            if (selectedItemsNew != null)
            {
                foreach (var itemToSelect in
                    selectedItemsNew.Cast<object>().Where(itemToSelect => !_assignedEntities.Contains(itemToSelect) && _availableEntities.Contains(itemToSelect)))
                {
                    AssignItem(itemToSelect);
                }
            }

            // remove not selected items
            foreach (var assignedItem in _assignedEntities.Where(assignedItem => selectedItemsNew == null || !selectedItemsNew.Contains(assignedItem)))
            {
                UnassignItem(assignedItem);
            }

            // unregister old list
            var selectedItemsOldNotify = selectedItemsOld as INotifyCollectionChanged;

            if (selectedItemsOldNotify != null)
            {
                selectedItemsOldNotify.CollectionChanged -= externalSelectedEntities_CollectionChanged;
            }

            // now register for upcoming changes - if possible
            var selectedItemsNewNotify = selectedItemsNew as INotifyCollectionChanged;

            if (selectedItemsNewNotify != null)
            {
                selectedItemsNewNotify.CollectionChanged += externalSelectedEntities_CollectionChanged;
            }
        }

        private void UnassignAllItems()
        {
            if (!(grdSelected.ItemsSource is ICollection))
            {
                // TODO: what else?
                return;
            }

            UnassignItems(grdSelected.ItemsSource as ICollection);
        }

        private void UnassignItem(object item)
        {
            _assignedEntities.Remove(item);
            _availableEntities.Add(item);
        }

        private void UnassignItems(IEnumerable items)
        {
            foreach (var item in Clone(items))
            {
                UnassignItem(item);
            }
        }

        private void UnassignSelectedItems()
        {
            UnassignItems(SelectedView.SelectedRows);
        }

        #endregion

        #endregion
    }
}