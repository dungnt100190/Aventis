using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Kiss.UserInterface.View.Converter
{
    public class ItemToEnumerableConverter<T> : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (T)value;
            return new[] {item};
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumerable = (IEnumerable<T>)value;
            return enumerable.FirstOrDefault();
        }

        #endregion

        #endregion
    }
}