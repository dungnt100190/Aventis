using System;
using System.Globalization;
using System.Windows.Data;

using DevExpress.Utils;

namespace Kiss.UI.Controls.Converter
{
    public class DefaultBooleanToBooleanConverter : IValueConverter
    {
        #region Properties

        public bool DefaultValue
        {
            get;
            set;
        }

        public bool Invert
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var def = (DefaultBoolean)value;
            bool result;

            switch (def)
            {
                case DefaultBoolean.True:
                    result = true;
                    break;
                case DefaultBoolean.False:
                    result = false;
                    break;
                default:
                    result = DefaultValue;
                    break;
            }

            if (Invert)
            {
                result = !result;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}