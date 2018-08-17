using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.View.Fa.Timeline
{
    /// <summary>
    /// Interaction logic for FaZeitachseView.xaml
    /// </summary>
    public partial class FaTimelineView
    {
        #region Fields

        #region Public Static Fields

        // Using a DependencyProperty as the backing store for ActualSizeReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawAreaWidthProperty =
            DependencyProperty.Register("DrawAreaWidth", typeof(double), typeof(FaTimelineView));
        public static readonly DependencyProperty VisibleDateRangeProperty =
            DependencyProperty.Register("VisibleDateRange", typeof(TimePeriod), typeof(FaTimelineView), new UIPropertyMetadata(new TimePeriod(MonthYear.CurrentMonth)));

        #endregion

        #region Private Fields

        private Point _lastMousePosition;

        #endregion

        #endregion

        #region Constructors

        public FaTimelineView()
        {
            InitializeComponent();

            Swimlanes.MouseWheel += panel_MouseWheel;
            Swimlanes.MouseLeftButtonDown += panel_MouseLeftButtonDown;
            Swimlanes.MouseMove += panel_MouseMove;
            Swimlanes.MouseLeftButtonUp += panel_MouseLeftButtonUp;

            dateScale.MouseWheel += panel_MouseWheel;
            dateScale.MouseLeftButtonDown += panel_MouseLeftButtonDown;
            dateScale.MouseMove += panel_MouseMove;
            dateScale.MouseLeftButtonUp += panel_MouseLeftButtonUp;
        }

        #endregion

        #region Properties

        public double DrawAreaWidth
        {
            get { return (double)GetValue(DrawAreaWidthProperty); }
            set { SetValue(DrawAreaWidthProperty, value); }
        }

        public TimePeriod VisibleDateRange
        {
            get { return (TimePeriod)GetValue(VisibleDateRangeProperty); }
            set { SetValue(VisibleDateRangeProperty, value); }
        }

        #endregion

        #region EventHandlers

        private void DateScale_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawAreaWidth = e.NewSize.Width;
        }

        void panel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lastMousePosition = e.GetPosition(this);
            Swimlanes.CaptureMouse();
            //Cursor = Cursors.Hand;
        }

        void panel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Swimlanes.IsMouseCaptured)
            {
                Swimlanes.ReleaseMouseCapture();
                //Cursor = Cursors.Arrow;
            }
        }

        void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Swimlanes.IsMouseCaptured || e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }
            var position = e.GetPosition(this);
            var deltaX = position.X - _lastMousePosition.X;
            var dayWidth = ScaleHelper.CalculateDayWidth(DrawAreaWidth, VisibleDateRange);
            var newVisibleRange = VisibleDateRange.MoveByDays(-deltaX / dayWidth);//, TotalDateRange);
            VisibleDateRange = newVisibleRange;
            _lastMousePosition = position;
        }

        private void panel_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                return;
            }
            var newTimeSpanDays = Math.Max(Math.Floor(VisibleDateRange.TimeSpan.TotalDays * (1 - 0.003 * e.Delta)), 5); // +/- 3%
            var mousePositionX = e.GetPosition(dateScale).X;
            var mouseAtDay = ScaleHelper.GetDateByOffset(mousePositionX, VisibleDateRange, DrawAreaWidth);

            var mouseRelativePositionInViewbox = DrawAreaWidth < double.Epsilon ? 0.5 : mousePositionX / DrawAreaWidth;

            VisibleDateRange = new TimePeriod(mouseAtDay.AddDays(-newTimeSpanDays * mouseRelativePositionInViewbox),
                                              mouseAtDay.AddDays(newTimeSpanDays * (1 - mouseRelativePositionInViewbox)));
        }

        #endregion
    }
}