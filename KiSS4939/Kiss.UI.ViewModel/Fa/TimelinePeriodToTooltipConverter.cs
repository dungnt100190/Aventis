using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Kiss.UI.ViewModel.Fa
{
    public class TimelinePeriodToTooltipConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timelinePeriod = value as FaTimelinePeriodDTO;

            if (timelinePeriod != null)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(timelinePeriod.StartDate.ToShortDateString());
                stringBuilder.Append(" - ");
                if (timelinePeriod.EndDate.HasValue)
                {
                    stringBuilder.Append(timelinePeriod.EndDate.Value.ToShortDateString());
                }
                else
                {
                    stringBuilder.Append("?");

                }

                stringBuilder.Append(" ");
                stringBuilder.Append(timelinePeriod.Description);
                return stringBuilder.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}