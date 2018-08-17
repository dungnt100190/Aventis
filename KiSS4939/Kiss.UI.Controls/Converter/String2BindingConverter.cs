using System;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(string), typeof(Binding))]
    public class String2BindingConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string from = (string)value;
            if (targetType != typeof(Binding) || string.IsNullOrWhiteSpace(from))
            {
                return null;
            }
            return new Binding(from);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}