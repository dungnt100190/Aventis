using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Kiss.UI.ViewModel.Fa
{
    public class TimelineEventToTooltipConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timelineEvents = value as IEnumerable<FaTimelineEventDTO>;

            if (timelineEvents == null || !timelineEvents.Any())
            {
                return null;
            }

            if (timelineEvents.Count() == 1)
            {
                var timelineEvent = timelineEvents.First();
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(timelineEvent.StartDate.ToShortDateString());
                stringBuilder.Append(" ");
                stringBuilder.Append(timelineEvent.Description);
                return stringBuilder.ToString();
            }
            else
            {
                var stringBuilder = new StringBuilder();
                var startDate = timelineEvents.Min(t => t.StartDate).ToShortDateString();
                var endDate = timelineEvents.Max(t => t.StartDate).ToShortDateString();
                stringBuilder.Append(startDate);

                if (startDate != endDate)
                {
                    stringBuilder.Append(" - ");
                    stringBuilder.Append(endDate);
                }

                stringBuilder.Append(String.Format(" {0} Dokumente", timelineEvents.Count()));
                return stringBuilder.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}