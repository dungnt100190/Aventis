using System;

using Kiss.Interfaces.ViewModel;

namespace Kiss.Infrastructure.Selectable
{
    public class SelectableItem<T> : Bindable, ISelectableItem
    {
        public SelectableItem()
        {
            // nop
        }

        public SelectableItem(T item, bool isSelected = false, bool isEnabled = true)
        {
            Item = item;
            IsSelected = isSelected;
            IsEnabled = isEnabled;
        }

        public event EventHandler SelectedChanged;

        private void OnSelectedChanged()
        {
            var handler = SelectedChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public T Item { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (SetProperty(ref _isSelected, value, () => IsSelected))
                {
                    OnSelectedChanged();
                }
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value, () => IsEnabled);
            }
        }
    }
}
