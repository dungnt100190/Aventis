using System;
using System.Globalization;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Converts an object to bool based on the fact whether the reference is set to null.
    /// A null-reference will be converted to either true or false. The default value for
    /// a null-reference is false, so it can be easily used for the binding of SelectedEntity
    /// and the IsEnabled property of the detail panel.
    /// </summary>
    [ValueConversion(typeof(object), typeof(bool))]
    public class Null2BoolConverter : IValueConverter
    {
        #region Methods

        public bool NullValue { get; set; }
        public bool NotNullValue { get; set; }

        public Null2BoolConverter()
        {
            NullValue = false;
            NotNullValue = true;
        }

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return NullValue;

            return NotNullValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("The ConvertBack function is not implemented");
        }

        #endregion

        #endregion
    }
}