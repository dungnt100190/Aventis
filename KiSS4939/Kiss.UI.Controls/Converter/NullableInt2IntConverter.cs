using System;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Converts int? to int.
    /// An int? of value (null) will be converted to 0.
    /// A int of value (0) will be converted back to null.
    /// The rest works as expected. It is not possible to produce a int? of value 0 with this converter.
    /// Usage: Used in Comboboxes for "no selection" entries.
    /// </summary>
    [ValueConversion(typeof(int?), typeof(int))]
    public class NullableInt2IntConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var nullableIntValue = (int?)value;
            if (nullableIntValue == null)
            {
                return 0;
            }
            return nullableIntValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var intValue = (int)value;
            if (intValue == 0)
            {
                return null;
            }
            return value;
        }

        #endregion

        #endregion
    }
}