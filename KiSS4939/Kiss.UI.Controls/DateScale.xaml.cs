using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for DateScale.xaml
    /// </summary>
    public partial class DateScale
    {
        #region Fields

        #region Public Static Fields

        // Using a DependencyProperty as the backing store for DayTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayTemplateProperty =
            DependencyProperty.Register("DayTemplate", typeof(DataTemplate), typeof(DateScale), new PropertyMetadata(DayTemplatePropertyPropertyChanged));

        // Using a DependencyProperty as the backing store for MonthTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthTemplateProperty =
            DependencyProperty.Register("MonthTemplate", typeof(DataTemplate), typeof(DateScale), new PropertyMetadata(MonthTemplatePropertyChanged));
        public static readonly DependencyProperty TotalDateRangeProperty =
            DependencyProperty.Register("TotalDateRange", typeof(TimePeriod), typeof(DateScale), new UIPropertyMetadata(new TimePeriod(MonthYear.CurrentMonth), TotalDateRangePropertyChanged));
        public static readonly DependencyProperty VisibleDateRangeProperty =
            DependencyProperty.Register("VisibleDateRange", typeof(TimePeriod), typeof(DateScale), new UIPropertyMetadata(new TimePeriod(MonthYear.CurrentMonth), VisibleDateRangePropertyChanged));

        // Using a DependencyProperty as the backing store for YearTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearTemplateProperty =
            DependencyProperty.Register("YearTemplate", typeof(DataTemplate), typeof(DateScale), new PropertyMetadata(YearTemplatePropertyChanged));

        #endregion

        #region Private Constant/Read-Only Fields

        readonly IDictionary<ScaleLevel, double> _scaleLevelHeights = new Dictionary<ScaleLevel, double>
                                                                          {
                                                                             {ScaleLevel.Year, 0.0},
                                                                             {ScaleLevel.Month, 0.0},
                                                                             {ScaleLevel.Day, 0.0}
                                                                          };

        #endregion

        #region Private Fields

        private List<DateScalePeriod> _fixScaleItems;
        private List<DateScalePeriod> _dayScaleItems;

        #endregion

        #endregion

        #region Constructors

        public DateScale()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Used to draw a day on the scale
        /// </summary>
        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }

        /// <summary>
        /// Used to draw a month on the scale
        /// </summary>
        public DataTemplate MonthTemplate
        {
            get { return (DataTemplate)GetValue(MonthTemplateProperty); }
            set { SetValue(MonthTemplateProperty, value); }
        }

        /// <summary>
        /// The total date range which this <see cref="DateScale" covers/>
        /// </summary>
        public TimePeriod TotalDateRange
        {
            get { return (TimePeriod)GetValue(TotalDateRangeProperty); }
            set { SetValue(TotalDateRangeProperty, value); }
        }

        /// <summary>
        /// The currently visible date range
        /// </summary>
        public TimePeriod VisibleDateRange
        {
            get { return (TimePeriod)GetValue(VisibleDateRangeProperty); }
            set { SetValue(VisibleDateRangeProperty, value); }
        }

        /// <summary>
        /// Used to draw a year on the scale
        /// </summary>
        public DataTemplate YearTemplate
        {
            get { return (DataTemplate)GetValue(YearTemplateProperty); }
            set { SetValue(YearTemplateProperty, value); }
        }

        private double DayWidth { get; set; }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void DayTemplatePropertyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DateScale)dependencyObject;
            instance.SetTemplateHeight(e.NewValue as DataTemplate, ScaleLevel.Day);
        }

        private static void MonthTemplatePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DateScale)dependencyObject;
            instance.SetTemplateHeight(e.NewValue as DataTemplate, ScaleLevel.Month);
        }

        private static void TotalDateRangePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DateScale)dependencyObject;
            instance.DrawScale();
        }

        private static void VisibleDateRangePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DateScale)dependencyObject;
            var valueBefore = (TimePeriod)e.OldValue;
            var valueAfter = (TimePeriod)e.NewValue;
            var deltaRange = Math.Abs(valueBefore.TimeSpan.Ticks - valueAfter.TimeSpan.Ticks);
            if (deltaRange > 1000)
            {
                instance.RecalculateDayWidth();
            }
            instance.SetViewport();
        }

        private static void YearTemplatePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DateScale)dependencyObject;
            instance.SetTemplateHeight(e.NewValue as DataTemplate, ScaleLevel.Year);
        }

        #endregion

        #region Private Methods

        private void CalculatePositionsAndVisibility()
        {
            var dayWidth = DayWidth;
            var monthScaleVisible = dayWidth > 1.4;
            var dayScaleVisible = dayWidth > 20;
            foreach (var scaleItem in _fixScaleItems)
            {
                scaleItem.IsVisible = scaleItem.Level == ScaleLevel.Year ||
                                      scaleItem.Level == ScaleLevel.Month && monthScaleVisible ||
                                      scaleItem.Level == ScaleLevel.Day && dayScaleVisible && scaleItem.Period.IsOverlapping(VisibleDateRange);
                // calculate positions only if necessary
                if (scaleItem.IsVisible)
                {
                    var fromPixel = ScaleHelper.GetPixelOffset(scaleItem.Period.From, TotalDateRange.From, DayWidth);
                    var toPixel = ScaleHelper.GetPixelOffset(scaleItem.Period.To, TotalDateRange.From, DayWidth);
                    scaleItem.PositionLeft = fromPixel;
                    scaleItem.Width = toPixel - fromPixel;
                }
            }
            CanvasScale.Height = _scaleLevelHeights[ScaleLevel.Year] +
                                 (monthScaleVisible ? _scaleLevelHeights[ScaleLevel.Month] : 0) +
                                 (dayScaleVisible ? _scaleLevelHeights[ScaleLevel.Day] : 0);
        }

        private IEnumerable<DateScalePeriod> CreateDayScaleItems()
        {
            var items = new List<DateScalePeriod>();
            var currentDate = TotalDateRange.From;
            while (currentDate <= TotalDateRange.To)
            {
                var nextDate = currentDate.AddDays(1);

                // the year at the beginning of the visible range should always be visible
                var period = new DateScalePeriod
                {
                    Period = new TimePeriod(currentDate, nextDate.AddMinutes(-1)),
                    Caption = currentDate.ToString("dd"),
                    Level = ScaleLevel.Day
                };
                items.Add(period);
                currentDate = nextDate;
            }
            return items;
        }

        /// <summary>
        /// Draws the scale with one tick per month
        /// </summary>
        private IEnumerable<DateScalePeriod> CreateMonthScaleItems()
        {
            var items = new List<DateScalePeriod>();
            var currentDate = TotalDateRange.From;
            while (currentDate <= TotalDateRange.To)
            {
                var nextDate = currentDate.AddMonths(1);
                nextDate = new DateTime(nextDate.Year, nextDate.Month, 1);

                // the year at the beginning of the visible range should always be visible
                var period = new DateScalePeriod
                {
                    Period = new TimePeriod(currentDate, nextDate.AddMinutes(-1)),
                    Caption = currentDate.ToString("MMM"),
                    Level = ScaleLevel.Month
                };
                items.Add(period);
                currentDate = nextDate;
            }
            return items;
        }

        /// <summary>
        /// Draws the scale with one tick per year.
        /// </summary>
        private List<DateScalePeriod> CreateYearScaleItems()
        {
            var yearItems = new List<DateScalePeriod>();
            var currentDate = TotalDateRange.From;
            while (currentDate <= TotalDateRange.To)
            {
                var nextDate = new DateTime(currentDate.Year + 1, 1, 1);

                // the year at the beginning of the visible range should always be visible
                var period = new DateScalePeriod
                                 {
                                     Period = new TimePeriod(currentDate, nextDate.AddMinutes(-1)),
                                     Caption = currentDate.ToString("yyyy"),
                                     Level = ScaleLevel.Year,
                                     IsVisible = true
                                 };
                yearItems.Add(period);
                currentDate = new DateTime(currentDate.Year + 1, 1, 1);
            }
            return yearItems;
        }

        /// <summary>
        /// Draws the scale for the timeline.
        /// </summary>
        private void DrawScale()
        {
            CanvasScale.Children.Clear();

            _fixScaleItems = CreateYearScaleItems();
            _fixScaleItems.AddRange(CreateMonthScaleItems());
            _fixScaleItems.AddRange(CreateDayScaleItems());

            CalculatePositionsAndVisibility();
            DrawScaleItems(_fixScaleItems);
        }

        /// <summary>
        /// Creates the items with the necessary bindings on the canvas
        /// </summary>
        /// <param name="scaleItems"></param>
        private void DrawScaleItems(IEnumerable<DateScalePeriod> scaleItems)
        {
            var visibilityConverter = new BooleanToVisibilityConverter();
            var visibilityBinding = new Binding("IsVisible")
                                        {
                                            Converter = visibilityConverter
                                        };

            foreach (var scaleItem in scaleItems)
            {
                var border = new Border
                                 {
                                     Child = InstantiateTemplate(scaleItem.Level),
                                     DataContext = scaleItem
                                 };
                border.SetBinding(Canvas.LeftProperty, "PositionLeft");
                border.SetBinding(WidthProperty, "Width");
                border.SetBinding(VisibilityProperty, visibilityBinding);
                border.SetBinding(Border.PaddingProperty, "Padding");
                Canvas.SetTop(border, GetScaleLevelHeight(scaleItem.Level));
                CanvasScale.Children.Add(border);
            }
        }

        /// <summary>
        /// Looks up the height of a lane
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private double GetScaleLevelHeight(ScaleLevel level)
        {
            switch (level)
            {
                case ScaleLevel.Year:
                    return 0.0;
                case ScaleLevel.Month:
                    return _scaleLevelHeights[ScaleLevel.Year];
                case ScaleLevel.Day:
                    return _scaleLevelHeights[ScaleLevel.Year] + _scaleLevelHeights[ScaleLevel.Month];
            }
            throw new Exception(string.Format("Unknown ScaleLevel {0}", level));
        }

        private FrameworkElement InstantiateTemplate(ScaleLevel level)
        {
            switch (level)
            {
                case ScaleLevel.Year:
                    return YearTemplate.LoadContent() as FrameworkElement;
                case ScaleLevel.Month:
                    return MonthTemplate.LoadContent() as FrameworkElement;
                case ScaleLevel.Day:
                    return DayTemplate.LoadContent() as FrameworkElement;
            }
            throw new Exception(string.Format("Unknown ScaleLevel {0}", level));
        }

        private void RecalculateDayWidth()
        {
            DayWidth = ScaleHelper.CalculateDayWidth(CanvasScale.ActualWidth, VisibleDateRange);
            CalculatePositionsAndVisibility();
        }

        private void SetTemplateHeight(FrameworkTemplate template, ScaleLevel level)
        {
            if (template == null || !template.HasContent)
            {
                _scaleLevelHeights[level] = 0.0;
            }
            else
            {
                var element = template.LoadContent() as FrameworkElement;
                if (element != null)
                {
                    _scaleLevelHeights[level] = element.Height;
                }
            }
        }

        private void SetViewport()
        {
            // set margin so the labels are still visible when the scale item is only partly visible
            var firstVisiblePosition = ScaleHelper.GetPixelOffset(VisibleDateRange.From, TotalDateRange.From, DayWidth);
            var lastVisiblePosition = ScaleHelper.GetPixelOffset(VisibleDateRange.To, TotalDateRange.From, DayWidth);
            CanvasScale.Offset = new Point(firstVisiblePosition, CanvasScale.Offset.Y);

            foreach (var scaleItem in _fixScaleItems
                                      .Where(itm => itm.Level == ScaleLevel.Year ||
                                                    itm.Level == ScaleLevel.Month)
                                      .Where(itm => itm.PositionLeft < firstVisiblePosition && itm.PositionLeft + itm.Width > firstVisiblePosition ||
                                                    itm.PositionLeft < lastVisiblePosition && itm.PositionLeft + itm.Width > lastVisiblePosition ||
                                                    itm.Padding.Left > 0 || itm.Padding.Right > 0)) // reset items that were partly hidden before, but are fully visible now
            {
                var hiddenWidthLeft = Math.Max(firstVisiblePosition - scaleItem.PositionLeft, 0);
                var hiddenWidthRight = Math.Max(scaleItem.PositionLeft + scaleItem.Width - lastVisiblePosition, 0);
                scaleItem.Padding = new Thickness(hiddenWidthLeft, 0, hiddenWidthRight, 0);
            }

            var dayScaleVisible = DayWidth > 20;
            if (dayScaleVisible)
            {
                foreach (var scaleItem in _fixScaleItems
                                          .Where(itm => itm.Level == ScaleLevel.Day && !itm.IsVisible))
                {
                    scaleItem.IsVisible = scaleItem.Period.IsOverlapping(VisibleDateRange);
                    if (scaleItem.IsVisible)
                    {
                        var fromPixel = ScaleHelper.GetPixelOffset(scaleItem.Period.From, TotalDateRange.From, DayWidth);
                        var toPixel = ScaleHelper.GetPixelOffset(scaleItem.Period.To, TotalDateRange.From, DayWidth);
                        scaleItem.PositionLeft = fromPixel;
                        scaleItem.Width = toPixel - fromPixel;
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}