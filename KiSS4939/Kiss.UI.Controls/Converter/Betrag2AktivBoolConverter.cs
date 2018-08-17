using System;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(decimal?), typeof(bool))]
    public class Betrag2AktivBoolConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var from = value as decimal?;

            if (!from.HasValue)
            {
                return null;
            }

            return from.Value != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}