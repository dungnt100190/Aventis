using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;

namespace Kiss.UI.Controls
{
    [TemplatePart(Name = PART_MAIN_CANVAS, Type = typeof(Canvas))]
    public class KissDateRangeSlider : KissRangeSlider
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty DateLinesProperty =
            DependencyProperty.Register("DateLines", typeof(IEnumerable<DateTime>), typeof(KissDateRangeSlider), new PropertyMetadata(null, DateLinesPropertyChanged));
        public static readonly DependencyProperty TotalDateRangeProperty =
            DependencyProperty.Register("TotalDateRange", typeof(TimePeriod), typeof(KissDateRangeSlider), new UIPropertyMetadata(new TimePeriod(MonthYear.CurrentMonth), TotalDateRangePropertyChanged));
        public static readonly DependencyProperty SelectedDateRangeProperty =
            DependencyProperty.Register("SelectedDateRange", typeof(TimePeriod), typeof(KissDateRangeSlider), new UIPropertyMetadata(new TimePeriod(MonthYear.CurrentMonth), SelectedDateRangePropertyChanged));
        public static readonly DependencyProperty MinDateRangeSizeProperty =
            DependencyProperty.Register("MinDateRangeSize", typeof(TimeSpan), typeof(KissDateRangeSlider), new UIPropertyMetadata(TimeSpan.FromDays(1), MinDateRangeSizePropertyChanged));
        public static readonly DependencyProperty SelectedDateRangeAnimationTargetProperty =
            DependencyProperty.Register("SelectedDateRangeAnimationTarget", typeof(DateTime?), typeof(KissDateRangeSlider), new UIPropertyMetadata(null, SelectedDateRangeAnimationTargetPropertyChanged));

        #endregion

        private enum DrawnItemType
        {
            Year = 1,
            DateLine = 2
        }

        #region Private Constant/Read-Only Fields

        private const string PART_MAIN_CANVAS = "PART_ScaleCanvas";

        #endregion

        #region Private Fields

        private double _dayWidth;
        private Canvas _scaleCanvas;
        private readonly TimePeriodAnimation _rangeAnimation;

        #endregion

        #endregion

        #region Constructors

        public KissDateRangeSlider()
        {
            DependencyPropertyDescriptor.FromProperty(TotalRangeProperty, typeof(KissRangeSlider))
                .AddValueChanged(this, (sender, args) => SetTotalRangeIfNotBinded());
            DependencyPropertyDescriptor.FromProperty(SelectedRangeProperty, typeof(KissRangeSlider))
                .AddValueChanged(this, (sender, args) => SelectedDateRange = new TimePeriod(new DateTime(SelectedRange.From), new DateTime(SelectedRange.To)));
            DependencyPropertyDescriptor.FromProperty(MinRangeSizeProperty, typeof(KissRangeSlider))
                .AddValueChanged(this, (sender, args) => MinDateRangeSize = TimeSpan.FromTicks(MinRangeSize));

            SizeChanged += OnSizeChanged;

            _rangeAnimation = new TimePeriodAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                DecelerationRatio = 0.3,
                FillBehavior = FillBehavior.HoldEnd
            };
            _rangeAnimation.Completed += _rangeAnimation_Completed;
        }


        private void SetTotalRangeIfNotBinded()
        {
            var newTotalDateRange = new TimePeriod(new DateTime(TotalRange.From), new DateTime(TotalRange.To));
            if (newTotalDateRange != TotalDateRange)
            {
                var binding = GetBindingExpression(TotalDateRangeProperty);
                if (binding == null || binding.ParentBinding.Mode == BindingMode.TwoWay || binding.ParentBinding.Mode == BindingMode.OneWayToSource)
                {
                    TotalDateRange = newTotalDateRange;
                }
            }
        }

        #endregion

        #region Properties

        public IEnumerable<DateTime> DateLines
        {
            get { return (IEnumerable<DateTime>)GetValue(DateLinesProperty); }
            set { SetValue(DateLinesProperty, value); }
        }

        public TimePeriod SelectedDateRange
        {
            get { return (TimePeriod)GetValue(SelectedDateRangeProperty); }
            set { SetValue(SelectedDateRangeProperty, value); }
        }

        public TimePeriod TotalDateRange
        {
            get { return (TimePeriod)GetValue(TotalDateRangeProperty); }
            set { SetValue(TotalDateRangeProperty, value); }
        }

        public TimeSpan MinDateRangeSize
        {
            get { return (TimeSpan)GetValue(MinDateRangeSizeProperty); }
            set { SetValue(MinDateRangeSizeProperty, value); }
        }

        public DateTime? SelectedDateRangeAnimationTarget
        {
            get { return (DateTime?)GetValue(SelectedDateRangeAnimationTargetProperty); }
            set { SetValue(SelectedDateRangeAnimationTargetProperty, value); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _scaleCanvas = EnforceInstance<Canvas>(PART_MAIN_CANVAS);
        }

        #endregion

        #region Private Static Methods

        private static void DateLinesPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissDateRangeSlider)dependencyObject;
            instance.RedrawLines();
        }

        private static void TotalDateRangePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var slider = (KissDateRangeSlider)dependencyObject;
            var newTotalRange = (TimePeriod)e.NewValue;
            slider.TotalRange = new Range<long>(newTotalRange.From.Ticks, newTotalRange.To.Ticks);
            slider.DrawScale();
        }

        private static void MinDateRangeSizePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var slider = (KissDateRangeSlider)dependencyObject;
            slider.MinRangeSize = ((TimeSpan)e.NewValue).Ticks;
        }

        private static void SelectedDateRangePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var slider = (KissDateRangeSlider)dependencyObject;
            var newSelectedRange = (TimePeriod)e.NewValue;
            slider.SelectedRange = new Range<long>(newSelectedRange.From.Ticks, newSelectedRange.To.Ticks);
        }

        private static void SelectedDateRangeAnimationTargetPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var slider = (KissDateRangeSlider)dependencyObject;
            var newValue = (DateTime?)e.NewValue;
            if (newValue.HasValue)
            {
                slider.MoveVisibleRangeToCenter(newValue.Value);
            }
        }

        #endregion

        #region Private Methods

        private void DrawLabelOnScale(UIElement label, double x, double y)
        {
            _scaleCanvas.Children.Add(label);
            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, y);
        }

        private void DrawLine(DateTime date, Brush color, bool fat = false)
        {
            var left = ScaleHelper.GetPixelOffset(date, TotalDateRange.From, _dayWidth);
            var height = _scaleCanvas.ActualHeight;
            var line = new Line
                           {
                               X1 = 0,
                               Y1 = 3,
                               X2 = 0,
                               Y2 = 15,
                               Stroke = color,
                               Opacity = 0.5,
                               StrokeThickness = fat ? 4 : 2.5,
                               DataContext = date,
                               Cursor = Cursors.Hand,
                               Tag = DrawnItemType.DateLine
                           };
            line.MouseLeftButtonDown += line_MouseLeftButtonDown;

            _scaleCanvas.Children.Add(line);
            Canvas.SetZIndex(line, 10);
            Canvas.SetLeft(line, left);
        }

        private void RedrawLines()
        {
            // clear existing lines first
            for (var i = _scaleCanvas.Children.Count - 1; i >= 0; i--)
            {
                var child = _scaleCanvas.Children[i] as FrameworkElement;
                if (child != null && child.Tag is DrawnItemType && (DrawnItemType)child.Tag == DrawnItemType.DateLine)
                {
                    _scaleCanvas.Children.RemoveAt(i);
                }
            }

            // draw today
            DrawLine(DateTime.Today, Brushes.Red, true);

            // draw date lines
            var lineBrush = Brushes.Black;
            if (DateLines != null)
            {
                foreach (var date in DateLines)
                {
                    DrawLine(date, lineBrush);
                }
            }
        }

        private void DrawScale()
        {
            _dayWidth = ScaleHelper.CalculateDayWidth(ActualWidth, TotalDateRange.From, TotalDateRange.To);

            if (_scaleCanvas != null)
            {
                _scaleCanvas.Children.Clear();

                if (TotalDateRange.From == DateTime.MinValue || TotalDateRange.To == DateTime.MaxValue)
                {
                    return;
                }

                RedrawLines();

                DrawYearScale();
            }
        }

        private void DrawYearScale()
        {
            var currentDate = TotalDateRange.From;

            while (currentDate < TotalDateRange.To)
            {
                var nextDate = new DateTime(currentDate.Year + 1, 1, 1);
                if (nextDate > TotalDateRange.To)
                {
                    nextDate = TotalDateRange.To;
                }
                var x1 = ScaleHelper.GetPixelOffset(currentDate, TotalDateRange.From, _dayWidth);
                var x2 = ScaleHelper.GetPixelOffset(nextDate.AddMinutes(-1), TotalDateRange.From, _dayWidth);
                var labelText = currentDate.ToString("yyyy");
                var label = GetLabel(labelText);
                label.Height = _scaleCanvas.ActualHeight;
                label.Width = x2 - x1;
                DrawLabelOnScale(label, x1, 0);

                currentDate = new DateTime(currentDate.Year + 1, 1, 1);
            }
        }

        void line_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var line = sender as Line;
            if (line == null)
            {
                return;
            }
            var date = line.DataContext as DateTime?;
            if (!date.HasValue)
            {
                return;
            }
            MoveVisibleRangeToCenter(date.Value);
        }

        public void MoveVisibleRangeToCenter(DateTime newCenter)
        {
            var currentCenter = SelectedDateRange.From.AddDays(SelectedDateRange.TimeSpan.TotalDays * 0.5);
            var deltaDays = (newCenter - currentCenter).TotalDays;

            // upper border barrier
            deltaDays = Math.Min((TotalDateRange.To - SelectedDateRange.To).TotalDays, deltaDays);
            // lower border barrier
            deltaDays = Math.Max((TotalDateRange.From - SelectedDateRange.From).TotalDays, deltaDays);
            var targetPeriod = SelectedDateRange.MoveByDays(deltaDays);

            const double millisecondsPerPixel = 0.6;
            var durationMs = Math.Abs(deltaDays) * _dayWidth * millisecondsPerPixel;
            _rangeAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, (int)durationMs));
            _rangeAnimation.To = targetPeriod;

            BeginAnimation(SelectedDateRangeProperty, _rangeAnimation, HandoffBehavior.Compose);
        }

        void _rangeAnimation_Completed(object sender, EventArgs e)
        {
            // release "hold" on the property so that binding works again
            BeginAnimation(SelectedDateRangeProperty, null);
        }

        /// <summary>
        /// ToDo: hardcoded template...
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static FrameworkElement GetLabel(string text)
        {
            return new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1, 0, 1, 0),
                Background = Brushes.Transparent,
                Child = new Label
                            {
                                Content = text,
                                FontSize = 11,
                                Padding = new Thickness(0),
                                HorizontalContentAlignment = HorizontalAlignment.Center
                            }
            };
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!e.WidthChanged || SelectedDateRange.From == DateTime.MinValue || TotalDateRange.From == DateTime.MinValue)
            {
                return;
            }
            DrawScale();
            var currentSelectedDayWidth = ScaleHelper.CalculateDayWidth(e.PreviousSize.Width, SelectedDateRange);

            var deltaWidth = e.NewSize.Width - e.PreviousSize.Width;
            var deltaDays = Math.Abs(currentSelectedDayWidth) < double.Epsilon ? 0 : deltaWidth / currentSelectedDayWidth;
            // try to add days to the right side - if there is space left
            var newSelectedFrom = SelectedDateRange.From;
            var newSelectedTo = SelectedDateRange.To;
            if (SelectedDateRange.To < TotalDateRange.To || deltaDays < 0.0)
            {
                var deltaDaysRight = Math.Min((TotalDateRange.To - SelectedDateRange.To).TotalDays, deltaDays);
                newSelectedTo = SelectedDateRange.To.AddDays(deltaDaysRight);
                deltaDays -= deltaDaysRight;
            }
            // still some days left? add them to the left side
            if (Math.Abs(deltaDays) > double.Epsilon)
            {
                newSelectedFrom = SelectedDateRange.From.AddDays(-deltaDays);
                if (newSelectedFrom < TotalDateRange.From)
                {
                    newSelectedFrom = TotalDateRange.From;
                }
            }

            SelectedDateRange = new TimePeriod(newSelectedFrom, newSelectedTo);
        }

        #endregion

        #endregion
    }
}