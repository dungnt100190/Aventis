using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kiss.Infrastructure.Selectable
{
    public class SelectableList<T> : IList<SelectableItem<T>>, IList
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        readonly IList<SelectableItem<T>> _list;
        readonly object _syncRoot = new object();

        #endregion

        #endregion

        #region Constructors

        public SelectableList()
        {
            _list = new List<SelectableItem<T>>();
        }

        public SelectableList(IEnumerable<T> collection)
            : this(collection.Select(itm => new SelectableItem<T>(itm)))
        {
        }

        public SelectableList(IEnumerable<SelectableItem<T>> collection)
        {
            _list = new List<SelectableItem<T>>(collection);
            foreach (var selectableItem in _list)
            {
                RegisterSelectedChanged(selectableItem);
            }
        }

        #endregion

        #region Events

        public event EventHandler SelectionChanged;

        #endregion

        #region Properties

        public IEnumerable<T> SelectedItems
        {
            get
            {
                return _list
                       .Where(itm => itm.IsSelected)
                       .Select(itm => itm.Item);
            }
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsSynchronized
        {
            get { return false; }//_list.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return _syncRoot; }
        }

        int ICollection.Count
        {
            get { return Count; }
        }

        bool IList.IsReadOnly
        {
            get { return IsReadOnly; }
        }

        object IList.this[int index]
        {
            get { return this[index]; }
            set { this[index] = value as SelectableItem<T>; }
        }

        #endregion

        #region Indexers

        public SelectableItem<T> this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Add(T item, bool selected = false, bool isEnabled = true)
        {
            Add(new SelectableItem<T>(item, selected, isEnabled));
        }

        public void Add(SelectableItem<T> item)
        {
            RegisterSelectedChanged(item);
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public void ClearSelection()
        {
            foreach (var item in _list)
            {
                item.IsSelected = false;
            }
        }

        public bool Contains(object value)
        {
            return _list.Select(itm => itm.Item as object).Contains(value);
        }

        public bool Contains(SelectableItem<T> item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(SelectableItem<T>[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            _list.ToArray().CopyTo(array, index);
        }

        public IEnumerator<SelectableItem<T>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        int IList.Add(object item)
        {
            if (item == null || item.GetType() != typeof(T))
            {
                return 0;
            }
            return ((IList)_list).Add(new SelectableItem<T>((T)item));
        }

        void IList.Clear()
        {
            Clear();
        }

        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        public int IndexOf(object value)
        {
            return IndexOf(value as SelectableItem<T>);
        }

        public int IndexOf(SelectableItem<T> item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, object value)
        {
            Insert(index, value as SelectableItem<T>);
        }

        public void Insert(int index, SelectableItem<T> item)
        {
            _list.Insert(index, item);
            RegisterSelectedChanged(item);
        }

        public bool Remove(SelectableItem<T> item)
        {
            var success = _list.Remove(item);
            if (success)
            {
                UnregisterSelectedChanged(item);
            }
            return success;
        }

        public void Remove(object value)
        {
            Remove(value as SelectableItem<T>);
        }

        public void RemoveAt(int index)
        {
            var removedItem = _list[index];
            _list.RemoveAt(index);
            UnregisterSelectedChanged(removedItem);
        }

        #endregion

        #region Private Methods

        private void ItemOnSelectedChanged(object sender, EventArgs eventArgs)
        {
            OnSelectionChanged();
        }

        private void OnSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void RegisterSelectedChanged(SelectableItem<T> item)
        {
            item.SelectedChanged += ItemOnSelectedChanged;
        }

        private void UnregisterSelectedChanged(SelectableItem<T> item)
        {
            item.SelectedChanged -= ItemOnSelectedChanged;
        }

        #endregion

        #endregion

    }
}