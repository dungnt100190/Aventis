using System;
using System.Globalization;
using System.Windows.Data;

using DevExpress.Data.Filtering;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Converts null to the default id as specified by the converter parameter. (If nothing is set, -1 is assumed).
    /// Also, it converts an id to null if it corresponds to the default id as specified by the converter parameter. (If nothing is set, -1 is assumed).
    /// </summary>
    [ValueConversion(typeof(int?), typeof(int), ParameterType=typeof(int))]
    public class NullIdConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int defaultValue;
            if (!int.TryParse(parameter as string, out defaultValue))
                defaultValue = -1;

            if (value == null)
                return defaultValue;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int defaultValue;
            if (!int.TryParse(parameter as string, out defaultValue))
                defaultValue = -1;

            int? valueInt = value as int?;

            if (valueInt == defaultValue)
                return null;

            return value;
        }

        #endregion

        #endregion
    }
}