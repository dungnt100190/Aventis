using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using DevExpress.Utils;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using Kiss.Infrastructure;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    public class GridColumnMultiLookUp : GridColumn
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<GridColumnMultiLookUp>(x => x.DisplayMember),
                typeof(string),
                typeof(GridColumnMultiLookUp),
                new PropertyMetadata(DEFAULT_DISPLAYMEMBER, PropertyChangedCallback));

        public static readonly DependencyProperty DisplaySeparatorProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<GridColumnMultiLookUp>(x => x.DisplaySeparator),
                typeof(string),
                typeof(GridColumnMultiLookUp),
                new PropertyMetadata(DEFAULT_DISPLAYSEPARATOR, PropertyChangedCallback));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<GridColumnMultiLookUp>(x => x.ItemsSource),
                typeof(IEnumerable),
                typeof(GridColumnMultiLookUp),
                new PropertyMetadata(null, PropertyChangedCallback));

        public static readonly DependencyProperty ValueMemberProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<GridColumnMultiLookUp>(x => x.ValueMember),
                typeof(string),
                typeof(GridColumnMultiLookUp),
                new PropertyMetadata(DEFAULT_VALUEMEMBER, PropertyChangedCallback));

        public static readonly DependencyProperty ValueSeparatorProperty =
            DependencyProperty.Register(
                PropertyName.GetPropertyName<GridColumnMultiLookUp>(x => x.ValueSeparator),
                typeof(string),
                typeof(GridColumnMultiLookUp),
                new PropertyMetadata(DEFAULT_VALUESEPARATOR, PropertyChangedCallback));

        #endregion

        #region Private Constant/Read-Only Fields

        private const string DEFAULT_DISPLAYMEMBER = "Text";
        private const string DEFAULT_DISPLAYSEPARATOR = ", ";
        private const string DEFAULT_VALUEMEMBER = "Code";
        private const string DEFAULT_VALUESEPARATOR = ",";

        #endregion

        #region Private Fields

        private MultiLookUpItemsProvider _itemsProvider;

        #endregion

        #endregion

        #region Constructors

        public GridColumnMultiLookUp()
        {
            AllowEditing = DefaultBoolean.False;
            EditSettings = new MultiLookUpEditSettings(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the display member. The default value is "Text".
        /// </summary>
        [DefaultValue(DEFAULT_DISPLAYMEMBER)]
        public string DisplayMember
        {
            get { return (string)GetValue(DisplayMemberProperty); }
            set { SetValue(DisplayMemberProperty, value); }
        }

        /// <summary>
        /// Gets or sets the display separator. The default value is ", ".
        /// </summary>
        [DefaultValue(DEFAULT_DISPLAYSEPARATOR)]
        public string DisplaySeparator
        {
            get { return (string)GetValue(DisplaySeparatorProperty); }
            set { SetValue(DisplaySeparatorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the value member. The default value is "Code".
        /// </summary>
        [DefaultValue(DEFAULT_VALUEMEMBER)]
        public string ValueMember
        {
            get { return (string)GetValue(ValueMemberProperty); }
            set { SetValue(ValueMemberProperty, value); }
        }

        /// <summary>
        /// Gets or sets the value separator. The default value is ",".
        /// </summary>
        [DefaultValue(DEFAULT_VALUESEPARATOR)]
        public string ValueSeparator
        {
            get { return (string)GetValue(ValueSeparatorProperty); }
            set { SetValue(ValueSeparatorProperty, value); }
        }

        private MultiLookUpItemsProvider ItemsProvider
        {
            get
            {
                if (_itemsProvider == null)
                {
                    _itemsProvider = new MultiLookUpItemsProvider();
                    UpdateItemsProvider();
                }

                return _itemsProvider;
            }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = (GridColumnMultiLookUp)d;
            column.UpdateItemsProvider();
        }

        #endregion

        #region Private Methods

        private void UpdateItemsProvider()
        {
            ItemsProvider.DisplayMember = DisplayMember;
            ItemsProvider.DisplaySeparator = DisplaySeparator;
            ItemsProvider.Items = ItemsSource;
            ItemsProvider.ValueMember = ValueMember;
            ItemsProvider.ValueSeparator = ValueSeparator;
        }

        #endregion

        #endregion

        #region Nested Types

        private class MultiLookUpEditSettings : PopupBaseEditSettings
        {
            #region Constructors

            public MultiLookUpEditSettings(GridColumnMultiLookUp gridColumn)
            {
                DisplayTextConverter = new DisplayConverter(gridColumn);
            }

            #endregion

            #region Nested Types

            private class DisplayConverter : IValueConverter
            {
                #region Fields

                #region Private Constant/Read-Only Fields

                private readonly GridColumnMultiLookUp _gridColumn;

                #endregion

                #endregion

                #region Constructors

                public DisplayConverter(GridColumnMultiLookUp gridColumn)
                {
                    if (gridColumn == null)
                    {
                        throw new ArgumentNullException("gridColumn");
                    }

                    _gridColumn = gridColumn;
                }

                #endregion

                #region Methods

                #region Public Methods

                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    if (value == null)
                    {
                        return null;
                    }

                    if (value is string && _gridColumn.ItemsSource != null)
                    {
                        var str = (string)value;
                        return _gridColumn.ItemsProvider.GetValue(str);
                    }

                    if (value is IEnumerable<int> && _gridColumn.ItemsSource != null)
                    {
                        return _gridColumn.ItemsProvider.GetValue((IEnumerable<int>)value);
                    }

                    return null;
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    return value;
                }

                #endregion

                #endregion
            }

            #endregion
        }

        #endregion
    }
}