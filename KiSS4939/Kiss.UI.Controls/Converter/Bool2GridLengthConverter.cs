using System;
using System.Windows;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(bool?), typeof(GridLength))]
    public class Bool2GridLengthConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? from = (bool?)value;
            if (targetType != typeof(GridLength) || !from.HasValue)
            {
                return GridLength.Auto;
            }
            if (!from.Value)
            {
                return new GridLength(0);
            }
            // from = true, check if we got a parameter
            var par = (double?)parameter;
            if (par.HasValue)
            {
                return new GridLength(par.Value);
            }
            return GridLength.Auto;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}