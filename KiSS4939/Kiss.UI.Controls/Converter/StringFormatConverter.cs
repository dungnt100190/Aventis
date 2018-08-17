using System;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(string), typeof(string))]
    public class StringFormatConverter : IValueConverter
    {
        #region Properties

        public bool ToLower
        {
            get;
            set;
        }

        public bool ToUpper
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string paramString = parameter as string;
            string stringValue = value as string;

            string result = value.ToString();

            if (!string.IsNullOrEmpty(stringValue) && !string.IsNullOrEmpty(paramString))
            {
                result = string.Format(culture, paramString, value);
            }

            if (ToUpper)
            {
                return result.ToUpper(culture);
            }

            if (ToLower)
            {
                return result.ToLower(culture);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            /*
                ViewThing source  = (ViewThing) value;
                ModelThing target;
                return target;
             */
        }

        #endregion

        #endregion
    }
}