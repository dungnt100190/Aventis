using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Ink;
using System.Windows.Media;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Konvertiert true zu grün.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Stroke))]
    public class True2GreenConverter : IValueConverter
    {
        #region Fields

        #region Private Static Fields

        private static readonly SolidColorBrush DEFAULT = new SolidColorBrush(Colors.White);
        private static readonly SolidColorBrush GREEN = new SolidColorBrush(Colors.Green);

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool)value;
            if (boolValue)
            {
                return GREEN;
            }
            return DEFAULT;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}