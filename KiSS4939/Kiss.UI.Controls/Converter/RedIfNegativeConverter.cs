using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

using Kiss.Interfaces.BL;

namespace Kiss.UI.Controls.Converter
{

    [ValueConversion(typeof(decimal), typeof(Brush))]
    public class RedIfNegativeConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
       
            decimal intValue = (decimal) value;
            if(intValue >= 0)
            {
                return Brushes.Black;
            }
            return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();            
        }

        #endregion

        #endregion
    }
}