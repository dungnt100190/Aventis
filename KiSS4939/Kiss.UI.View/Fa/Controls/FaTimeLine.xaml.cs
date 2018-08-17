using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

using Kiss.UI.ViewModel.Fa;

namespace Kiss.UI.View.Fa.Controls
{
    /// <summary>
    /// Interaction logic for FaTimeLine.xaml
    /// </summary>
    public partial class FaTimeline : INotifyPropertyChanged
    {
        #region Fields

        #region Public Static Fields

        // Dependency Property for Model
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(
            "Model", typeof(FaTimelineDTO), typeof(FaTimeline), new PropertyMetadata(null, OnModelPropertyChanged));

        // Using a DependencyProperty as the backing store for VisibleRangeBegin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibleRangeBeginProperty =
            DependencyProperty.Register("VisibleRangeBegin", typeof(DateTime), typeof(FaTimeline), new UIPropertyMetadata(VisibleRangeBeginChanged));

        // Using a DependencyProperty as the backing store for VisibleRangeEnd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibleRangeEndProperty =
            DependencyProperty.Register("VisibleRangeEnd", typeof(DateTime), typeof(FaTimeline), new UIPropertyMetadata(VisibleRangeEndChanged));

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly List<ScrollViewer> _swimlaneScrollViewers = new List<ScrollViewer>();

        #endregion

        #region Private Fields

        private bool _needsResizing;

        // TimelineUtiliti for scale calculations
        private FaTimelineUtility _timelineUtility;

        #endregion

        #endregion

        #region Constructors

        public FaTimeline()
        {
            InitializeComponent();
            SizeChanged += FaTimeline_SizeChanged;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// .NET Property wrapper for Model.
        /// </summary>
        public FaTimelineDTO Model
        {
            get { return (FaTimelineDTO)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public FaTimelineUtility TimelineUtility
        {
            get { return _timelineUtility; }
            set { _timelineUtility = value; }
        }

        public DateTime VisibleRangeBegin
        {
            get { return (DateTime)GetValue(VisibleRangeBeginProperty); }
            set { SetValue(VisibleRangeBeginProperty, value); }
        }

        public DateTime VisibleRangeEnd
        {
            get { return (DateTime)GetValue(VisibleRangeEndProperty); }
            set { SetValue(VisibleRangeEndProperty, value); }
        }

        #endregion

        #region EventHandlers

        void FaTimeline_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (IsLoaded && ActualHeight > 0)
            {
                // Das Control hat die endgültige Grösse
                _needsResizing = true;
                SetZoom(VisibleRangeBegin, VisibleRangeEnd);

                // Es wird nicht mehr auf SizeChanged reagiert
                SizeChanged -= FaTimeline_SizeChanged;
            }
        }

        private void ScrollViewerScale_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            foreach (var swimlaneScrollViewer in _swimlaneScrollViewers)
            {
                swimlaneScrollViewer.ScrollToHorizontalOffset(e.HorizontalOffset);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ScrollTo(DateTime startDate)
        {
            var startX = TimelineUtility.DateToX(startDate);
            ScrollViewerScale.ScrollToHorizontalOffset(startX);
        }

        public void SetZoom(DateTime dateFrom, DateTime dateTo)
        {
            if (_needsResizing)
            {
                TimelineUtility.VisibleRangeBegin = dateFrom;
                TimelineUtility.VisibleRangeEnd = dateTo;

                var scaleWidth = TimelineUtility.CalculateScaleWidth(ScrollViewerScale.ActualWidth);

                Dispatcher.BeginInvoke(
                    (Action)(() =>
                             {
                                 //var totalSwimmlaneHeight = 0.0;
                                 Rescale(scaleWidth);
                                 foreach (var swimlane in Swimlanes.Items)
                                 {
                                     var contentPresenter = (ContentPresenter)Swimlanes.ItemContainerGenerator.ContainerFromItem(swimlane);
                                     var swimlaneControl =
                                         (FaTimelineSwimmlane)contentPresenter.ContentTemplate.FindName("Swimlane", contentPresenter);
                                     swimlaneControl.Width = scaleWidth;
                                     swimlaneControl.DrawEvents();
                                     //totalSwimmlaneHeight += swimlaneControl.CalculateCanvasHeight();
                                 }
                             }),
                    DispatcherPriority.DataBind);
            }
        }

        #endregion

        #region Protected Methods

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        ///  Called when the timeline model is bound to the control
        ///  Calls OnModelPropertyChanged on the actual object
        /// </summary>
        /// <param name="dependencyObject">Timeline Control that raised the event</param>
        /// <param name="e">Event parameters</param>
        private static void OnModelPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var timelineControl = dependencyObject as FaTimeline;

            if (timelineControl != null)
            {
                timelineControl.OnPropertyChanged("Model");
                timelineControl.OnModelPropertyChanged();
            }
        }

        private static void VisibleRangeBeginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FaTimeline timeline = (FaTimeline)d;
            timeline.TimelineUtility.VisibleRangeBegin = (DateTime)e.NewValue;
        }

        private static void VisibleRangeEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FaTimeline timeline = (FaTimeline)d;
            timeline.TimelineUtility.VisibleRangeEnd = (DateTime)e.NewValue;
        }

        #endregion

        #region Private Methods

        private void DrawDayScale(bool drawHalfMonthOnly)
        {
            var currentDate = TimelineUtility.TotalRangeBegin;
            while (currentDate <= TimelineUtility.TotalRangeEnd)
            {
                var dayName = currentDate.Day.ToString();
                var x = TimelineUtility.DateToX(currentDate);
                //1. und 15 schreiben und Linie zeichnen
                if (!drawHalfMonthOnly || dayName == "1" || dayName == "15")
                {
                    var label = new Label
                    {
                        Content = dayName,
                        Padding = new Thickness(0),
                        HorizontalContentAlignment = HorizontalAlignment.Left
                    };

                    DrawLabelOnScale(label, x, 32);
                    //x-6 ist offset, um das Label unter der Linie mittig zu platzieren
                    DrawLineOnScale(x, 25, 35, 1);
                }
                currentDate = currentDate.AddDays(1);
            }
        }

        private void DrawLabelOnScale(Label label, double x, double y)
        {
            CanvasScale.Children.Add(label);
            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, y);
        }

        private void DrawLineOnScale(double xSetLeft, double y1, double y2, double strokeThickness)
        {
            var line = new Line
            {
                X1 = 0,
                X2 = 0,
                Y1 = y1,
                Y2 = y2,
                StrokeThickness = strokeThickness,
                Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0))
            };

            Canvas.SetLeft(line, xSetLeft);
            CanvasScale.Children.Add(line);
        }

        /// <summary>
        /// Draws the scale with one tick per month
        /// </summary>
        private void DrawMonthScale()
        {
            var currentDate = TimelineUtility.TotalRangeBegin;
            var beginDate = TimelineUtility.TotalRangeBegin;

            while (currentDate <= TimelineUtility.TotalRangeEnd)
            {
                var isBeginningMonth = (beginDate.Year == currentDate.Year && beginDate.Month == currentDate.Month);
                var x = isBeginningMonth ? 0 : TimelineUtility.DateToX(currentDate);
                var monthName = currentDate.ToString("MMM");
                var label = new Label
                {
                    Content = monthName,
                    Padding = new Thickness(0),
                    HorizontalContentAlignment = HorizontalAlignment.Left
                };

                DrawLabelOnScale(label, x, 42);

                RemoveOverlappingLabels(label);

                if (!isBeginningMonth)
                {
                    DrawLineOnScale(x, 25, 35, 1);
                }

                var nextDate = currentDate.AddMonths(1);
                currentDate = new DateTime(nextDate.Year, nextDate.Month, 1);
            }
        }

        /// <summary>
        /// Draws the scale for the timeline.
        /// </summary>
        /// <param name="newWidth"></param>
        private void DrawScale(double newWidth)
        {
            CanvasScale.Children.Clear();

            // draw the line over the whole canvas (thus we must re-add the margin)
            var lineWidth = newWidth;

            // Bei grossem Zoom kann eine einzige Linie nicht mehr dargestellt werden (Länge über ca. 130000),
            // daher die Linie in mehrere Teile von Länge 100000 splitten.
            const double partLength = 100000d;
            var x = 0d;
            while (x < lineWidth)
            {
                var currentPartLength = Math.Min(partLength, lineWidth - x);
                var line = new Line
                {
                    Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                    X1 = x,
                    X2 = x + currentPartLength,
                    Y1 = 30,
                    Y2 = 30
                };
                CanvasScale.Children.Add(line);
                x += currentPartLength;
            }

            DrawYearScale();
            if (TimelineUtility.DayWidth > 1.40)
            {
                DrawMonthScale();
            }

            if (TimelineUtility.DayWidth > 20)
            {
                DrawDayScale(false);
            }
            else if (TimelineUtility.DayWidth > 8)
            {
                DrawDayScale(true);
            }
        }

        /// <summary>
        /// Draws the scale with one tick per year.
        /// </summary>
        private void DrawYearScale()
        {
            var currentDate = TimelineUtility.TotalRangeBegin;
            var beginDate = TimelineUtility.TotalRangeBegin;

            while (currentDate <= TimelineUtility.TotalRangeEnd)
            {
                // the year at the beginning of the visible range should always be visible
                var isBeginningYear = (beginDate.Year == currentDate.Year);
                var x = isBeginningYear ? 0 : TimelineUtility.DateToX(currentDate);
                var yearLabel = new Label
                {
                    Content = currentDate.Year.ToString(),
                    Padding = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                DrawLabelOnScale(yearLabel, x, 0);

                RemoveOverlappingLabels(yearLabel);

                if (!isBeginningYear)
                {
                    DrawLineOnScale(x, 20, 40, 2);
                }

                var nextDate = currentDate.AddYears(1);
                currentDate = new DateTime(nextDate.Year, 1, 1);
            }
        }

        /// <summary>
        /// Called when the model changes.
        /// </summary>
        private void OnModelPropertyChanged()
        {
            _timelineUtility = new FaTimelineUtility(Model, ScrollViewerScale.ViewportWidth);
            TimelineUtility.CalculateDayWidth(CanvasScale.ActualWidth);

            Dispatcher.BeginInvoke(
                (Action)(() =>
                         {
                             _swimlaneScrollViewers.Clear();

                             foreach (var swimlane in Swimlanes.Items)
                             {
                                 var contentPresenter = (ContentPresenter)Swimlanes.ItemContainerGenerator.ContainerFromItem(swimlane);

                                 var swimlaneScrollViewer = (ScrollViewer)contentPresenter.ContentTemplate.FindName("ScrollViewerSwimlane", contentPresenter);
                                 if (swimlaneScrollViewer != null)
                                 {
                                     _swimlaneScrollViewers.Add(swimlaneScrollViewer);
                                 }
                                 //var swimlaneControl = (FaTimelineSwimmlane)contentPresenter.ContentTemplate.FindName("Swimlane", contentPresenter);
                             }

                             SetZoom(Model.VisibleRangeBegin, Model.VisibleRangeEnd);

                         }),
                DispatcherPriority.Loaded);
        }

        private void RemoveOverlappingLabels(Label label)
        {
            CanvasScale.UpdateLayout();

            var labelLeft = Canvas.GetLeft(label);
            var labelTop = Canvas.GetTop(label);

            for (int i = 0; i < CanvasScale.Children.Count; i++)
            {
                var otherLabel = CanvasScale.Children[i] as Label;

                if (otherLabel != null)
                {
                    // skip if the label is on another lane
                    if (otherLabel == label || Canvas.GetTop(otherLabel) != labelTop)
                    {
                        continue;
                    }

                    if (Canvas.GetLeft(otherLabel) + otherLabel.ActualWidth > labelLeft)
                    {
                        CanvasScale.Children.Remove(otherLabel);
                        i--;
                    }
                }
            }
        }

        /// <summary>
        /// Rescales the control to the new width.
        /// </summary>
        /// <param name="newWidth">New width to use</param>
        private void Rescale(double newWidth)
        {
            // Recalculate the day width
            TimelineUtility.CalculateDayWidth(newWidth);

            // Scroll to the beginning of the visible range
            var startX = TimelineUtility.DateToX(TimelineUtility.VisibleRangeBegin);
            CanvasScale.Width = newWidth;
            ScrollViewerScale.ScrollToHorizontalOffset(startX);

            DrawScale(newWidth);
        }

        #endregion

        #endregion
    }
}