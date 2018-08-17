using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Kiss.Infrastructure.Constant;

namespace Kiss.UI.ViewModel.Fa
{
    public class FaTimelineEventToImageConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var faTimelineEventDtos = value as ObservableCollection<FaTimelineEventDTO>;
            var timelineEvent = value as FaTimelineEventDTO;

            if (faTimelineEventDtos == null && timelineEvent == null)
            {
                return null;
            }

            if (faTimelineEventDtos != null)
            {
                int count = faTimelineEventDtos.Count;

                if(count == 0)
                {
                    return null;
                }

                if (count > 1)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UI.View;component/Images/Stapel.bmp"));
                }

                timelineEvent = faTimelineEventDtos.First();
            }

            return GetImageSource(timelineEvent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Static Methods

        private static ImageSource GetImageSource(FaTimelineEventDTO timelineEvent)
        {
            ImageSource imageSource;

            switch (timelineEvent.EventType)
            {
                case EventTypeEnum.DateLabel:
                    imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UI.View;component/Images/DateLabel.bmp"));
                    break;
                case EventTypeEnum.Falluebergabe:
                    imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UI.View;component/Images/Falluebergabe.bmp"));
                    break;
                default:
                    //it must be a document
                    switch (timelineEvent.DocFormat)
                    {
                        case LOVsGenerated.DocFormat.Excel:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UI.View;component/Images/ExcelDoc.bmp"));
                            break;
                        case LOVsGenerated.DocFormat.Word:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UI.View;component/Images/WordDoc.bmp"));
                            break;
                        case LOVsGenerated.DocFormat.Pdf:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UI.View;component/Images/AcrobatDoc.bmp"));
                            break;
                        default:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UI.View;component/Images/OpenDoc.bmp"));
                            break;
                    }

                    break;
            }

            return imageSource;
        }

        #endregion

        #endregion
    }
}