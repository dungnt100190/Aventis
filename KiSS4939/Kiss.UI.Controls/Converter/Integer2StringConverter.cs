using System;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class Integer2StringConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var from = value as int?;

            if (targetType != typeof(string) || !from.HasValue)
            {
                return null;
            }

            return from.Value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var from = value as string;
            int to;

            if (targetType != typeof(int?) || string.IsNullOrEmpty(from) || !int.TryParse(from, out to))
            {
                return null;
            }

            return to;
        }

        #endregion

        #endregion
    }
}