using System;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(decimal?), typeof(string))]
    public class Decimal2StringConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var from = value as decimal?;

            if (targetType != typeof(string) || !from.HasValue)
            {
                return null;
            }

            // http://msdn.microsoft.com/en-us/library/dwhawy9k.aspx#NFormatString
            string formatSpecifier = "N1";

            var digits = parameter as int?;

            if (digits.HasValue && digits.Value > 1 & digits.Value < 5)
            {
                formatSpecifier = string.Format("N{0}", digits.Value);
            }

            return from.Value.ToString(formatSpecifier);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var from = value as string;
            decimal to;

            var digits = parameter as int?;
            int point = from.IndexOf(".");
            if (point > -1 && digits.HasValue && from.Length > 0 && digits.Value < from.Substring(point + 1).Length)
            {
                // alle Nachkommastellen nach der Anzahl digits werden abgeschnitten
                from = from.Remove(from.Length - from.Substring(point + 1).Length + digits.Value);
            }

            if (targetType != typeof(decimal?) || string.IsNullOrEmpty(from) || !decimal.TryParse(from, out to))
            {
                return null;
            }

            return to;
        }

        #endregion

        #endregion
    }
}