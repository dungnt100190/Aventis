using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NullToCollapsedConverter : BaseConverter, IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}