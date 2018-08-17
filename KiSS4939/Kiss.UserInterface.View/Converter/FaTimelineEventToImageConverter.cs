using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Kiss.DbContext.Enums.Sys;
using Kiss.UserInterface.ViewModel.Fa.Timeline;

namespace Kiss.UserInterface.View.Converter
{
    public class FaTimelineEventToImageConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timelineEvent = value as FaTimelineEventDTO;

            if (timelineEvent == null)
            {
                return null;
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
                    imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UserInterface.View;component/Images/DateLabel.png"));
                    break;
                case EventTypeEnum.Falluebergabe:
                    imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UserInterface.View;component/Images/Falluebergabe.bmp"));
                    break;
                default:
                    //it must be a document
                    switch (timelineEvent.DocFormat)
                    {
                        case DocumentFormat.Excel:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UserInterface.View;component/Images/ExcelDocument.png"));
                            break;
                        case DocumentFormat.Word:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UserInterface.View;component/Images/WordDocument.png"));
                            break;
                        case DocumentFormat.PDF:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UserInterface.View;component/Images/AcrobatDocument.png"));
                            break;
                        default:
                            imageSource = new BitmapImage(new Uri(@"pack://application:,,,/Kiss.UserInterface.View;component/Images/GenericDocument.png"));
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