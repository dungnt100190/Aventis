using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Kiss.UserInterface.ViewModel.Fa.Timeline;

namespace Kiss.UserInterface.View.Converter
{
    public class ZeroToCollapsedConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var events = value as IEnumerable<FaTimelineEventDTO>;

            if (events == null)
            {
                return Visibility.Collapsed;
            }
            if (!events.Any())
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}