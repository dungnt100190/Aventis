using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Kiss.UI.Controls.Helper
{
    public class MultiLookUpItemsProvider
    {
        #region Fields

        #region Private Fields

        private string _displayMember;
        private PropertyInfo _displayProperty;
        private IEnumerable _items;
        private string _valueMember;
        private PropertyInfo _valueProperty;

        #endregion

        #endregion

        #region Properties

        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; UpdatePropertyInfos(); }
        }

        public string DisplaySeparator
        {
            get;
            set;
        }

        public IEnumerable Items
        {
            get { return _items; }
            set
            {
                _items = value;
                UpdatePropertyInfos();
            }
        }

        public string ValueMember
        {
            get { return _valueMember; }
            set
            {
                _valueMember = value;
                UpdatePropertyInfos();
            }
        }

        public string ValueSeparator
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public string GetValue(IEnumerable<int> input)
        {
            if (_displayProperty != null && _valueProperty != null)
            {
                string result = null;

                foreach (var val in input)
                {
                    foreach (var item in Items)
                    {
                        var itemId = _valueProperty.GetValue(item, null) as int? ?? 0;

                        if (itemId == val)
                        {
                            var displayValue = (_displayProperty.GetValue(item, null) ?? "").ToString();
                            result += result == null ? displayValue : DisplaySeparator + displayValue;
                        }
                    }
                }

                return result ?? " "; //HACK: mit null wird "System.Collections.Generics.List'1[System.Int32]" angezeigt
            }

            return null;
        }

        public string GetValue(string input)
        {
            if (_displayProperty != null && _valueProperty != null)
            {
                var values = input.Split(new[] { ValueSeparator }, StringSplitOptions.RemoveEmptyEntries);

                string result = null;

                foreach (var val in values)
                {
                    foreach (var item in Items)
                    {
                        var itemId = (_valueProperty.GetValue(item, null) ?? "").ToString();

                        if (itemId == val)
                        {
                            var displayValue = (_displayProperty.GetValue(item, null) ?? "").ToString();
                            result += result == null ? displayValue : DisplaySeparator + displayValue;
                        }
                    }
                }

                return result;
            }

            return null;
        }

        #endregion

        #region Private Methods

        private void UpdatePropertyInfos()
        {
            _displayProperty = null;
            _valueProperty = null;

            if (Items != null)
            {
                var enumerator = Items.GetEnumerator();

                if (enumerator.MoveNext())
                {
                    var itemType = enumerator.Current.GetType();
                    _valueProperty = itemType.GetProperty(ValueMember);
                    _displayProperty = itemType.GetProperty(DisplayMember);
                }
            }
        }

        #endregion

        #endregion
    }
}