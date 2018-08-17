using System;
using System.Globalization;
using System.Windows.Data;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Converts a MonthYear instance to a DateTime or to separate month/year integers (The first bound item must be the month, the second must be the year).
    /// The converter parameter is a bool defining whether the last day of the month should be returned.
    /// </summary>
    public class MonthYearConverter : IMultiValueConverter, IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new InvalidOperationException("Wrong binding information! You must provide a binding information for both month and year.");
            }

            var month = values[0] as int?;
            var year = values[1] as int?;

            if (month == null || year == null)
            {
                return null;
            }

            month = month == 0 ? DateTime.Now.Month : month;
            year = year == 0 ? DateTime.Now.Year : year;

            return new MonthYear((int)year, (int)month);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new object[2];
            }

            var my = (MonthYear?)value;

            return new object[] { my.Value.Month, my.Value.Year };
        }

        #endregion

        #endregion

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dt = value as DateTime?;

            if (!dt.HasValue)
            {
                return null;
            }

            return new MonthYear(dt.Value.Year, dt.Value.Month);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var my = value as MonthYear?;

            if (!my.HasValue)
            {
                return null;
            }

            bool lastDayOfMonth;
            if(!bool.TryParse((string)parameter, out lastDayOfMonth))
            {
                lastDayOfMonth = false;
            }

            DateTime dateTime = new DateTime(my.Value.Year, my.Value.Month, 1);
            if (lastDayOfMonth)
            {
                dateTime = dateTime.AddMonths(1).AddDays(-1);
            }

            return dateTime;
        }
    }
}