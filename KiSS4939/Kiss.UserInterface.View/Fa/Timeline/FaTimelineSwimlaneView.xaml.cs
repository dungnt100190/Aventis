using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Kiss.UserInterface.ViewModel.Fa.Timeline;

namespace Kiss.UserInterface.View.Fa.Timeline
{
    /// <summary>
    /// Represents one timeline axis on the TimelineControl (swim lane)
    /// </summary>
    public partial class FaTimelineSwimlaneView
    {
        #region Fields

        #region Public Static Fields

        public IList<CanvasItem<FaTimelineItemDTO>> SwimlaneItems
        {
            get { return (IList<CanvasItem<FaTimelineItemDTO>>)GetValue(SwimlaneItemsProperty); }
            set { SetValue(SwimlaneItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SwimlaneItemsProperty =
            DependencyProperty.Register("SwimlaneItems", typeof(IList<CanvasItem<FaTimelineItemDTO>>), typeof(FaTimelineSwimlaneView), new UIPropertyMetadata(null, SwimlaneItemsPropertyChangedCallback));

        private static void SwimlaneItemsPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (FaTimelineSwimlaneView)dependencyObject;
            instance.SetSwimlaneItems(e.NewValue as IList<CanvasItem<FaTimelineItemDTO>>);
        }

        private void SetSwimlaneItems(IEnumerable<CanvasItem<FaTimelineItemDTO>> items)
        {
            CanvasEvents.Children.Clear();
            if (items != null)
            {
                foreach (var item in items)
                {
                    AddTimelineItem(item);
                }
                var notifyList = items as INotifyCollectionChanged;
                if (notifyList != null)
                {
                    notifyList.CollectionChanged += notifyList_CollectionChanged;
                }
            }
            SetCanvasHeight();
        }

        private void AddTimelineItem(CanvasItem<FaTimelineItemDTO> item)
        {
            // create vm-item for view-item
            FrameworkElement viewItem;
            if (item.DataItem is FaTimelineEventDTO)
            {
                viewItem = new FaTimelineEvent { DataContext = item };
            }
            else if (item.DataItem is FaTimelineEventBatchDTO)
            {
                viewItem = new FaTimelineEventBatch { DataContext = item };
            }
            else if (item.DataItem is FaTimelinePeriodDTO)
            {
                viewItem = new FaTimelinePeriod { DataContext = item };
                viewItem.SetBinding(FaTimelinePeriod.TextPaddingProperty, "Padding");
            }
            else
            {
                return;
            }

            // bind item properties on vm-item to view-item
            viewItem.SetBinding(Canvas.LeftProperty, "PositionLeft");
            viewItem.SetBinding(WidthProperty, "Width");
            viewItem.SetBinding(HeightProperty, "Height");
            viewItem.SetBinding(Canvas.TopProperty, "PositionTop");
            CanvasEvents.Children.Add(viewItem);
        }

        void notifyList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SyncTimelineItems(e);
        }

        private void SyncTimelineItems(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                CanvasEvents.Children.Clear();
            }
            else if (e.OldItems != null)
            {
                foreach (var oldItem in e.OldItems)
                {
                    RemoveTimelineItem(oldItem as CanvasItem<FaTimelineItemDTO>);
                }
            }

            if (e.NewItems != null)
            {
                foreach (var newItem in e.NewItems)
                {
                    AddTimelineItem(newItem as CanvasItem<FaTimelineItemDTO>);
                }
            }
            SetCanvasHeight();
        }

        private void SetCanvasHeight()
        {
            var bottom = (CanvasEvents
                          .Children
                          .Cast<FrameworkElement>()
                          .Select(child => child.Height + Canvas.GetTop(child)))
                         .Concat(new[] { 0.0 })
                         .Max();
            CanvasEvents.Height = bottom;
        }

        private void RemoveTimelineItem(CanvasItem<FaTimelineItemDTO> dataItem)
        {
            for (var i = CanvasEvents.Children.Count - 1; i >= 0; i--)
            {
                var viewItem = CanvasEvents.Children[i] as FrameworkElement;
                if (viewItem != null && viewItem.DataContext == dataItem)
                {
                    CanvasEvents.Children.Remove(viewItem);
                    break;
                }
            }
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the control and hooks up events
        /// </summary>
        public FaTimelineSwimlaneView()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        private void DrawTodayLine(double totalSwimmlaneHeight)
        {
            //// Place today line
            //var xToday = Swimlane.TimelineUtility.DateToX(DateTime.Today);
            //var lineToday = new Line { X1 = xToday, X2 = xToday, Y1 = -15, Y2 = totalSwimmlaneHeight, Stroke = Brushes.Red, Opacity = 0.2 };
            //Canvas.SetZIndex(lineToday, -500);
            //CanvasEvents.Children.Add(lineToday);
        }

        #endregion
    }
}