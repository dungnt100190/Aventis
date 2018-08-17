using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using Kiss.UI.Controls.Bindings;

namespace Kiss.UI.Controls.Converter
{
    internal class SwitchConverter : IValueConverter
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly SwitchBindingExtension _switch;

        #endregion

        #endregion

        #region Constructors

        public SwitchConverter(SwitchBindingExtension switchExtension)
        {
            _switch = switchExtension;
        }

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool b = System.Convert.ToBoolean(value);
                return b ? _switch.ValueIfTrue : _switch.ValueIfFalse;
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion

        #endregion
    }
}