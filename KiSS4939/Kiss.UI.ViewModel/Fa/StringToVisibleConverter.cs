using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kiss.UI.ViewModel.Fa
{
    public class StringToVisibleConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var givenString = ((FaTimelineEventDTO)value).JumpToPath; ;
            if(string.IsNullOrEmpty(givenString))
            {
                return Visibility.Hidden;
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