using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// This converter does nothing except breaking the
    /// debugger into the convert method
    /// </summary>
    [ValueConversion(typeof(object), typeof(object))]
    public class DatabindingDebuggerConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            return value;
        }
    }
}