using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// A slider that provides a range of type long.
    /// </summary>
    [DefaultEvent("SelectedRangeChanged"),
    TemplatePart(Name = PART_CONTAINER, Type = typeof(StackPanel)),
    TemplatePart(Name = PART_LEFT_PANEL, Type = typeof(FrameworkElement)),
    TemplatePart(Name = PART_RIGHT_PANEL, Type = typeof(FrameworkElement)),
    TemplatePart(Name = PART_LEFT_THUMB, Type = typeof(Thumb)),
    TemplatePart(Name = PART_MIDDLE_THUMB, Type = typeof(Thumb)),
    TemplatePart(Name = PART_CONTAINER, Type = typeof(Thumb))]
    public class KissRangeSlider : Control
    {
        #region Fields

        #region Public Static Fields

        /// <summary>
        /// The max value for the range of the range slider
        /// </summary>
        public static readonly DependencyProperty TotalRangeProperty =
            DependencyProperty.Register("TotalRange", typeof(Range<long>), typeof(KissRangeSlider),
            new UIPropertyMetadata(new Range<long>(0, 1), TotalRangePropertyChanged));

        /// <summary>
        /// The max value of the selected range of the range slider
        /// </summary>
        public static readonly DependencyProperty SelectedRangeProperty =
            DependencyProperty.Register("SelectedRange", typeof(Range<long>), typeof(KissRangeSlider),
            new UIPropertyMetadata(new Range<long>(0, 1), SelectedRangePropertyChanged));

        /// <summary>
        /// The min range value that you can have for the range slider
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when MinRange is set less than 0</exception>
        public static readonly DependencyProperty MinRangeSizeProperty =
            DependencyProperty.Register("MinRangeSize", typeof(long), typeof(KissRangeSlider),
            new UIPropertyMetadata((long)0, MinRangePropertyChanged));

        /// <summary>
        /// Event raised whenever a slider is dragged.
        /// </summary>
        public static readonly RoutedEvent PreviewSelectedRangeChangedEvent =
            EventManager.RegisterRoutedEvent("PreviewSelectedRangeChanged",
            RoutingStrategy.Bubble, typeof(SelectedRangeChangedEventHandler), typeof(KissRangeSlider));

        /// <summary>
        /// Event raised whenever the selected range is changed (after dragging).
        /// </summary>
        public static readonly RoutedEvent SelectedRangeChangedEvent =
            EventManager.RegisterRoutedEvent("SelectedRangeChanged",
            RoutingStrategy.Bubble, typeof(SelectedRangeChangedEventHandler), typeof(KissRangeSlider));

        /// <summary>
        /// Command to move all back the selection
        /// </summary>
        public static RoutedUICommand MoveAllBack =
            new RoutedUICommand("MoveAllBack", "MoveAllBack", typeof(KissRangeSlider),
                new InputGestureCollection(new InputGesture[] {
                    new KeyGesture(Key.B, ModifierKeys.Alt)
                }));

        /// <summary>
        /// Command to move all forward the selection
        /// </summary>
        public static RoutedUICommand MoveAllForward =
            new RoutedUICommand("MoveAllForward", "MoveAllForward", typeof(KissRangeSlider),
                new InputGestureCollection(new InputGesture[] {
                    new KeyGesture(Key.F, ModifierKeys.Alt)
                }));

        /// <summary>
        /// Command to move back the selection
        /// </summary>
        public static RoutedUICommand MoveBack =
            new RoutedUICommand("MoveBack", "MoveBack", typeof(KissRangeSlider),
                new InputGestureCollection(new InputGesture[] {
                    new KeyGesture(Key.B, ModifierKeys.Control)
                }));

        /// <summary>
        /// Command to move forward the selection
        /// </summary>
        public static RoutedUICommand MoveForward =
            new RoutedUICommand("MoveForward", "MoveForward", typeof(KissRangeSlider),
                new InputGestureCollection(new InputGesture[] {
                    new KeyGesture(Key.F, ModifierKeys.Control)
                }));

        #endregion

        #region Public Constant/Read-Only Fields

        public const string PART_CONTAINER = "PART_Container";
        public const string PART_LEFT_PANEL = "PART_LeftPanel";
        public const string PART_LEFT_THUMB = "PART_LeftThumb";
        public const string PART_MIDDLE_THUMB = "PART_MiddleThumb";
        public const string PART_RIGHT_PANEL = "PART_RightPanel";
        public const string PART_RIGHT_THUMB = "PART_RightThumb";

        #endregion

        #region Private Constant/Read-Only Fields

        const double DEFAULT_SPLITTERS_THUMB_WIDTH = 10;
        const double REPEAT_BUTTON_MOVE_RATIO = 0.1; //used to move the selection by x ratio when click the repeat buttons

        #endregion

        #region Private Fields

        private Thumb _centerThumb; //the center thumb to move the range around
        private StackPanel _container; //stackpanel to store the visual elements for this control
        private bool _disableEvents;
        private bool _isDragging;
        private bool _isScrolling;
        private bool _isUpdating;
        private FrameworkElement _leftPart; //the left side of the control (movable left part)
        private Thumb _leftThumb; //the left thumb that is used to expand the range selected
        private long _movableRange;
        private double _movableWidth;
        private FrameworkElement _rightPart; //the right side of the control (movable right part)
        private Thumb _rightThumb; //the right thumb that is used to expand the range selected

        #endregion

        #endregion

        #region Constructors

        static KissRangeSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(KissRangeSlider), new FrameworkPropertyMetadata(typeof(KissRangeSlider))
                );
        }

        public KissRangeSlider()
        {
            CommandBindings.Add(new CommandBinding(MoveBack, MoveBackHandler));
            CommandBindings.Add(new CommandBinding(MoveForward, MoveForwardHandler));
            CommandBindings.Add(new CommandBinding(MoveAllForward, MoveAllForwardHandler));
            CommandBindings.Add(new CommandBinding(MoveAllBack, MoveAllBackHandler));

            // Hook to the size change event of the range slider
            DependencyPropertyDescriptor.FromProperty(ActualWidthProperty, typeof(KissRangeSlider)).
                AddValueChanged(this, delegate { CalculateWidths(); });

            // Set default property values
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Top;
            MinHeight = 18;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event raised whenever a thumb is dragged.
        /// </summary>
        public event SelectedRangeChangedEventHandler PreviewSelectedRangeChanged
        {
            add { AddHandler(PreviewSelectedRangeChangedEvent, value); }
            remove { RemoveHandler(PreviewSelectedRangeChangedEvent, value); }
        }

        /// <summary>
        /// Event raised whenever the selected range is changed (after dragging).
        /// </summary>
        public event SelectedRangeChangedEventHandler SelectedRangeChanged
        {
            add { AddHandler(SelectedRangeChangedEvent, value); }
            remove { RemoveHandler(SelectedRangeChangedEvent, value); }
        }

        #endregion

        #region Properties


        /// <summary>
        /// The max value for the range of the range slider
        /// </summary>
        public Range<long> TotalRange
        {
            get { return (Range<long>)GetValue(TotalRangeProperty); }
            set { SetValue(TotalRangeProperty, value); }
        }

        /// <summary>
        /// The min range value that you can have for the range slider
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when MinRange is set less than 0</exception>
        public long MinRangeSize
        {
            get { return (long)GetValue(MinRangeSizeProperty); }
            set { SetValue(MinRangeSizeProperty, value); }
        }

        /// <summary>
        /// The max value for the range of the range slider
        /// </summary>
        public Range<long> SelectedRange
        {
            get { return (Range<long>)GetValue(SelectedRangeProperty); }
            set { SetValue(SelectedRangeProperty, value); }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// moves the current selection with x value
        /// </summary>
        /// <param name="isLeft">True if you want to move to the left</param>
        public void MoveSelection(bool isLeft)
        {
            var widthChange = REPEAT_BUTTON_MOVE_RATIO * (SelectedRange.GetRange()) * _movableWidth / _movableRange;

            widthChange = isLeft ? -widthChange : widthChange;
            MoveThumb(_leftPart, _rightPart, widthChange);
            CalculateSelectedRange(true, true, true);
        }

        ///<summary>
        /// Change the range selected 
        ///</summary>
        ///<param name="span">The steps</param>
        public void MoveSelection(long span)
        {
            if (span > 0)
            {
                if (SelectedRange.To + span > TotalRange.To)
                {
                    span = TotalRange.To - SelectedRange.To;
                }
            }
            else
            {
                if (SelectedRange.From + span < TotalRange.From)
                {
                    span = TotalRange.From - SelectedRange.From;
                }
            }

            if (span != 0)
            {
                _isUpdating = true;
                SelectedRange = new Range<long>(SelectedRange.From + span, SelectedRange.To + span);
                CalculateWidths();
                _isUpdating = false;

                OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(this, true));
            }
        }

        /// <summary>
        /// Overide to get the visuals from the control template
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _container = EnforceInstance<StackPanel>(PART_CONTAINER);
            _centerThumb = EnforceInstance<Thumb>(PART_MIDDLE_THUMB);
            _leftPart = EnforceInstance<FrameworkElement>(PART_LEFT_PANEL);
            _rightPart = EnforceInstance<FrameworkElement>(PART_RIGHT_PANEL);
            _leftThumb = EnforceInstance<Thumb>(PART_LEFT_THUMB);
            _rightThumb = EnforceInstance<Thumb>(PART_RIGHT_THUMB);

            InitializeVisualElementsContainer();
            CalculateWidths();
        }

        /// <summary>
        /// Reset the Slider to the Start/End
        /// </summary>
        /// <param name="isStart">Pass true to reset to start point</param>
        public void ResetSelection(bool isStart)
        {
            double widthChange = TotalRange.GetRange();
            widthChange = isStart ? -widthChange : widthChange;

            MoveThumb(_leftPart, _rightPart, widthChange);
            CalculateSelectedRange(true, true, false);
        }

        ///// <summary>
        ///// Sets the selected range in one go. If the selection is invalid, nothing happens.
        ///// </summary>
        ///// <param name="selectionStart">New selection start value</param>
        ///// <param name="selectionStop">New selection stop value</param>
        //public void SetSelectedRange(long selectionStart, long selectionStop)
        //{
        //    long start = Math.Max(Minimum, selectionStart);
        //    long stop = Math.Min(selectionStop, Maximum);
        //    start = Math.Min(start, Maximum - MinRangeSize);
        //    stop = Math.Max(Minimum + MinRangeSize, stop);

        //    if (stop >= start + MinRangeSize)
        //    {
        //        _isUpdating = true;
        //        SelectionStart = start;
        //        SelectionEnd = stop;
        //        CalculateWidths();
        //        _isUpdating = false;

        //        OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(this, false));
        //    }
        //}

        /// <summary>
        /// Changes the selected range to the supplied range
        /// </summary>
        /// <param name="span">The span to zoom</param>
        public void ZoomToSpan(long span)
        {
            _isUpdating = true;

            // Ensure new span is within the valid range
            span = Math.Min(span, TotalRange.GetRange());
            span = Math.Max(span, MinRangeSize);

            if (span == SelectedRange.GetRange())
            {
                return;
            }

            // First zoom half of it to the right
            var rightChange = (span - (SelectedRange.GetRange())) / 2;
            var leftChange = rightChange;

            // If we will hit the right edge, spill over the leftover change to the other side
            if (rightChange > 0 && SelectedRange.To + rightChange > TotalRange.To)
            {
                leftChange += rightChange - (TotalRange.To - SelectedRange.To);
            }
            var newSelectionTo = Math.Min(SelectedRange.To + rightChange, TotalRange.To);
            rightChange = 0;

            // If we will hit the left edge and there is space on the right, add the leftover change to the other side
            if (leftChange > 0 && SelectedRange.From - leftChange < TotalRange.From)
            {
                rightChange = TotalRange.From - (SelectedRange.From - leftChange);
            }
            var newSelectionFrom = Math.Max(SelectedRange.From - leftChange, TotalRange.From);
            if (rightChange > 0) // leftovers to the right
            {
                newSelectionTo = Math.Min(SelectedRange.To + rightChange, TotalRange.To);
            }

            CalculateWidths();
            _isUpdating = false;
            SelectedRange = new Range<long>(newSelectionFrom, newSelectionTo);

            OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(this, false));
        }

        #endregion

        #region Protected Methods

        protected T EnforceInstance<T>(string partName)
            where T : FrameworkElement
        {
            var element = GetTemplateChild(partName) as T;

            if (element == null)
            {
                throw new InvalidOperationException(
                    string.Format("Invalid template: the part {0} of type {1} could not be found.", partName, typeof(T)));
            }

            return element;
        }

        #endregion

        #region Private Static Methods

        private static double GetChangeKeepPositive(double width, double increment)
        {
            return Math.Max(width + increment, 0) - width;
        }

        private static void TotalRangePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var slider = (KissRangeSlider)sender;
            var newTotalRange = (Range<long>)e.NewValue;

            if (newTotalRange.To < slider.SelectedRange.To ||
                newTotalRange.From > slider.SelectedRange.From)
            {
                var newSelectedFrom = Math.Max(newTotalRange.From, slider.SelectedRange.From);
                newSelectedFrom = Math.Min(newSelectedFrom, newTotalRange.To);
                var newSelectedTo = Math.Min(newTotalRange.To, slider.SelectedRange.To);
                newSelectedTo = Math.Max(newSelectedTo, newTotalRange.From);

                slider.SelectedRange = new Range<long>(newSelectedFrom, newSelectedTo);

                slider.OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(slider, false));
            }

            if (!slider._isUpdating)
            {
                slider.CalculateRanges();
                slider.CalculateWidths();
            }
        }

        private static void MinRangePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((long)e.NewValue < 0)
            {
                throw new ArgumentOutOfRangeException("e", "NewValue for MinRange cannot be less than 0.");
            }

            var slider = (KissRangeSlider)sender;
            var newMinRange = (long)e.NewValue;

            if (!slider._isUpdating)
            {
                var minRangeTo = slider.SelectedRange.From + newMinRange;
                if (slider.SelectedRange.To < minRangeTo)
                {
                    slider._isUpdating = true;
                    slider.SelectedRange = new Range<long>(slider.SelectedRange.From, minRangeTo);
                    if (slider.TotalRange.To < minRangeTo)
                    {
                        slider.TotalRange = new Range<long>(slider.TotalRange.From, minRangeTo);
                    }
                    slider._isUpdating = false;
                }

                slider.CalculateRanges();
                slider.CalculateWidths();
            }
        }

        /// <summary>
        /// Resizes the left and right columns.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="horizonalChange"></param>
        private static void MoveThumb(FrameworkElement left, FrameworkElement right, double horizonalChange)
        {
            double change = 0;

            if (horizonalChange < 0)
            {
                var width = left.Width <= left.MinWidth ? 0 : left.Width;
                change = GetChangeKeepPositive(width, horizonalChange);
            }
            else if (horizonalChange > 0)
            {
                var width = right.Width <= right.MinWidth ? 0 : right.Width;
                change = -GetChangeKeepPositive(width, -horizonalChange);
            }

            left.Width += change;
            right.Width -= change;
        }

        private static void SelectedRangePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var slider = (KissRangeSlider)sender;

            if (!slider._isUpdating)
            {
                slider.CalculateWidths();
                slider.OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(slider, false));
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Recalculates the _movableRange. Called from the Maximum setter, Minimum setter and MinRange setter
        /// </summary>
        private void CalculateRanges()
        {
            _movableRange = TotalRange.GetRange() - MinRangeSize;
        }

        private void CalculateSelectedRange(bool reCalculateStart, bool reCalculateStop, bool isScrolling)
        {
            _isUpdating = true;
            var newSelectionFrom = SelectedRange.From;
            var newSelectionTo = SelectedRange.To;

            if (reCalculateStart)
            {
                // Make sure to get exactly the Minimum value if thumb is at the start
                if (_leftPart.Width == 0.0)
                {
                    newSelectionFrom = TotalRange.From;
                }
                else
                {
                    newSelectionFrom = Math.Max(TotalRange.From, (long)(TotalRange.From + _movableRange * _leftPart.Width / _movableWidth));
                }
            }

            if (reCalculateStop)
            {
                // Make sure to get exactly the Maximum value if thumb is at the end
                if (_rightPart.Width == 0.0)
                {
                    newSelectionTo = TotalRange.To;
                }
                else
                {
                    newSelectionTo = Math.Min(TotalRange.To, (long)(TotalRange.To - _movableRange * _rightPart.Width / _movableWidth));
                }
            }
            // make sure the end is bigger or equal to the start
            newSelectionTo = Math.Max(newSelectionTo, newSelectionFrom);
            SelectedRange = new Range<long>(newSelectionFrom, newSelectionTo);

            _isUpdating = false;

            if (reCalculateStart || reCalculateStop)
            {
                OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(this, isScrolling));
            }
        }

        /// <summary>
        /// Recalculates the _movableWidth. Called whenever the width of the control changes.
        /// </summary>
        private void CalculateWidths()
        {
            if (_leftPart != null && _rightPart != null && _centerThumb != null)
            {
                _movableWidth = Math.Max(ActualWidth - _rightThumb.ActualWidth - _leftThumb.ActualWidth - _centerThumb.MinWidth, 1);
                var leftWidth = Math.Max(_movableWidth * (SelectedRange.From - TotalRange.From) / _movableRange, 0);
                _leftPart.Width = double.IsInfinity(leftWidth) ? _leftPart.Width : leftWidth;

                var rightWidth = Math.Max(_movableWidth * (TotalRange.To - SelectedRange.To) / _movableRange, 0);
                _rightPart.Width = double.IsInfinity(rightWidth) ? _rightPart.Width : rightWidth;

                var centerWidth = Math.Max(ActualWidth - _leftPart.Width - _rightPart.Width - _rightThumb.ActualWidth - _leftThumb.ActualWidth, 0);
                _centerThumb.Width = double.IsInfinity(centerWidth) ? _centerThumb.Width : centerWidth;
            }
        }

        private void CenterThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            MoveThumb(_leftPart, _rightPart, e.HorizontalChange);
            CalculateSelectedRange(true, true, true);
        }

        private void InitializeVisualElementsContainer()
        {
            _container.Orientation = Orientation.Horizontal;

            _leftThumb.Width = DEFAULT_SPLITTERS_THUMB_WIDTH;
            _leftThumb.Tag = "left";
            _rightThumb.Width = DEFAULT_SPLITTERS_THUMB_WIDTH;
            _rightThumb.Tag = "right";
            _centerThumb.MinWidth = DEFAULT_SPLITTERS_THUMB_WIDTH;

            // handle the drag delta
            _centerThumb.DragDelta += CenterThumbDragDelta;
            _leftThumb.DragDelta += LeftThumbDragDelta;
            _rightThumb.DragDelta += RightThumbDragDelta;

            _leftThumb.DragStarted += ThumbDragStarted;
            _rightThumb.DragStarted += ThumbDragStarted;
            _centerThumb.DragStarted += ThumbDragStarted;

            _leftThumb.DragCompleted += ThumbDragCompleted;
            _rightThumb.DragCompleted += ThumbDragCompleted;
            _centerThumb.DragCompleted += ThumbDragCompleted;

            _leftThumb.MouseDoubleClick += ThumbDoubleClick;
            _rightThumb.MouseDoubleClick += ThumbDoubleClick;
            _centerThumb.MouseDoubleClick += ThumbDoubleClick;
        }

        private void LeftThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            MoveThumb(_leftPart, _centerThumb, e.HorizontalChange);
            CalculateSelectedRange(true, false, false);
        }

        private void MoveAllBackHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ResetSelection(true);
        }

        private void MoveAllForwardHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ResetSelection(false);
        }

        private void MoveBackHandler(object sender, ExecutedRoutedEventArgs e)
        {
            MoveSelection(true);
        }

        private void MoveForwardHandler(object sender, ExecutedRoutedEventArgs e)
        {
            MoveSelection(false);
        }

        private void OnSelectedRangeChanged(SelectedRangeChangedEventArgs e)
        {
            if (!_disableEvents)
            {
                e.RoutedEvent = _isDragging || _isScrolling ? PreviewSelectedRangeChangedEvent : SelectedRangeChangedEvent;
                RaiseEvent(e);
            }
        }

        private void RightThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            MoveThumb(_centerThumb, _rightPart, e.HorizontalChange);
            CalculateSelectedRange(false, true, false);
        }

        private void ThumbDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _disableEvents = true;

                var thumb = (Thumb)sender;

                if (thumb == _leftThumb || thumb == _centerThumb)
                {
                    SelectedRange = new Range<long>(TotalRange.From, SelectedRange.To);
                }

                if (thumb == _rightThumb || thumb == _centerThumb)
                {
                    SelectedRange = new Range<long>(SelectedRange.From, TotalRange.To);
                }

                _disableEvents = false;
                OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(this, false));
            }
            finally
            {
                _disableEvents = false;
            }
        }

        private void ThumbDragCompleted(object sender, DragCompletedEventArgs e)
        {
            var isScrolling = _isScrolling;

            _isScrolling = false;
            _isDragging = false;

            // fire the SelectedRangeChanged event
            OnSelectedRangeChanged(new SelectedRangeChangedEventArgs(this, isScrolling));
        }

        private void ThumbDragStarted(object sender, DragStartedEventArgs e)
        {
            if (sender == _centerThumb)
            {
                _isScrolling = true;
            }
            else
            {
                _isDragging = true;
            }
        }

        #endregion

        #endregion
    }
}