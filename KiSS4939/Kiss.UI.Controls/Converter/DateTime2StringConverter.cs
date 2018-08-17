using System;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(DateTime?), typeof(string))]
    public class DateTime2StringConverter : IValueConverter
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/az4se3k1.aspx
        /// </summary>
        private string _format = "d";

        #endregion

        #endregion

        #region Properties

        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var from = value as DateTime?;

            if (!targetType.IsAssignableFrom(typeof(string)) || !from.HasValue)
            {
                return null;
            }

            if(string.IsNullOrEmpty(Format))
            {
                return from.Value.ToString();
            }

            return from.Value.ToString(Format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var from = value as string;

            if (!string.IsNullOrEmpty(from))
            {
                DateTime to;
                if (DateTime.TryParse(from, out to))
                {
                    return to;
                }
            }

            return null;
        }

        #endregion

        #endregion
    }
}