using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(bool), typeof(FontWeight))]
    public class Bool2FontWeightConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var from = value != null ? (bool)value : false;
            if (targetType != typeof(FontWeight) || !from)
            {
                return FontWeights.Normal;
            }
            // from = true, check if we got a parameter
            var fontWeight = FontWeights.Bold;
            if( parameter is FontWeight)
            {
                fontWeight = (FontWeight)parameter;
            }
            return fontWeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}