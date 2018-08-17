using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

using Kiss.Interfaces.BL;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(KissServiceResult), typeof(Brush))]
    public class ValidaionResult2ColorConverter : IValueConverter
    {
        #region Fields

        #region Public Static Fields

        private readonly static SolidColorBrush ORANGE = new SolidColorBrush(Colors.OrangeRed);
        private readonly static SolidColorBrush RED = new SolidColorBrush(Colors.Red);

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var serviceResult = value as IServiceResult;
            if(serviceResult != null && serviceResult.IsWarning && !serviceResult.IsError)
            {
                return ORANGE;
            }
            return RED;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}