using System;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Converter that removes line breaks in a string.
    /// </summary>
    public class MultilineRowTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;

            if (str != null)
            {
                return str.Replace('\r', ' ').Replace('\n', ' ');
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}