using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

using Kiss.Interfaces.BL;

namespace Kiss.UI.Controls.Converter
{

    [ValueConversion(typeof(bool), typeof(string))]
    public class True2XConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isTrue = value as bool?;

            if (isTrue.HasValue && isTrue.Value)
            {
                return "x";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}