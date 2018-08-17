using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(bool), typeof(Cursor))]
    public class Bool2CursorConverter : IValueConverter
    {
        #region Constructors

        public Bool2CursorConverter()
        {
            CursorWhenTrue = Cursors.Wait;
            CursorWhenFalse = null; // Default
        }

        #endregion

        #region Properties

        public Cursor CursorWhenFalse
        {
            get;
            set;
        }

        public Cursor CursorWhenTrue
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool) || targetType != typeof(Cursor))
            {
                throw new InvalidOperationException("Invalid binding");
            }

            return (bool)value ? CursorWhenTrue : CursorWhenFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}