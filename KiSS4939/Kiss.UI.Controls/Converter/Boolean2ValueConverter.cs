using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using DevExpress.Utils;
using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls.Converter
{
    public class Boolean2DefaultBooleanConverter : Boolean2ValueConverter<DefaultBoolean>
    {
    }

    [ValueConversion(typeof(bool), typeof(GridViewNavigationStyle))]
    public class Boolean2NavigationStyleConverter : Boolean2ValueConverter<GridViewNavigationStyle>
    {
    }

    public class Boolean2ValueConverter<T> : IMultiValueConverter, IValueConverter
    {
        #region Properties

        /// <summary>
        /// Boolean Flag, defining the default value in case the value to be converted is null.
        /// This Property only makes sense when using as an IValueConverter.
        /// </summary>
        public bool DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// If the result of the boolean combination results in false, the specified value is returned;
        /// </summary>
        public T FalseValue
        {
            get;
            set;
        }

        /// <summary>
        /// If the result of the boolean combination results in true, the specified value is returned;
        /// </summary>
        public T TrueValue
        {
            get;
            set;
        }

        /// <summary>
        /// Boolean Flag, telling whether the converter should use the AND operator.
        /// If set to true, the values are combined with the AND operator; else,
        /// the OR operator is used. This Property only makes sense when using as an IMultiValueConverter.
        /// </summary>
        public bool UseAndOperator
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = UseAndOperator; //for AND, we need true as initial value, for OR, we need false

            foreach (object o in values)
            {
                bool b;
                bool parsed = bool.TryParse(o.ToString(), out b);
                if (parsed)
                {
                    if (UseAndOperator)
                    {
                        result &= b;
                    }
                    else
                    {
                        result |= b;
                    }
                }
            }

            return result ? TrueValue : FalseValue;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = DefaultValue;

            if (value != null)
            {
                bool.TryParse(value.ToString(), out b);
            }

            return b ? TrueValue : FalseValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value.Equals(TrueValue))
                {
                    return true;
                }

                if (value.Equals(FalseValue))
                {
                    return false;
                }
            }

            return DefaultValue;
        }

        #endregion

        #endregion
    }

    [ValueConversion(typeof(bool), typeof(bool))]
    public class Boolean2VisibilityConverter : Boolean2ValueConverter<Visibility>
    {
        public Boolean2VisibilityConverter()
        {
            TrueValue = Visibility.Visible;
            FalseValue = Visibility.Collapsed;
        }
    }

    public class MultiBoolean2BooleanConverter : Boolean2ValueConverter<bool>
    {
        public MultiBoolean2BooleanConverter()
        {
            TrueValue = true;
            FalseValue = false;
            UseAndOperator = true;
        }
    }
}