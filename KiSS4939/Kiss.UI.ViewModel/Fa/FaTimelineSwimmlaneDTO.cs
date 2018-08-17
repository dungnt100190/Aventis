using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media;

using Kiss.Infrastructure;
using Kiss.Model.DTO;

namespace Kiss.UI.ViewModel.Fa
{
    /// <summary>
    /// Model class for a swimm lane
    /// </summary>
    public class FaTimelineSwimmlaneDTO : Kiss.Model.DTO.DTO
    {
        #region Fields

        #region Private Fields

        private DateTime? _firstHiddenItemOnTheLeft;
        private DateTime? _lastHiddenItemOnTheRight;
        private ObservableCollection<FaTimelineItemDTO> _timelineItems;

        // Utility will be initialized by the Control on binding
        private FaTimelineUtility _timelineUtility;

        #endregion

        #endregion

        #region Constructors

        public FaTimelineSwimmlaneDTO()
        {
            TimelineItems = new ObservableCollection<FaTimelineItemDTO>();
            BatchList = new ObservableCollection<FaTimelineEventBatchDTO>();

            AddPropertyMapping(PropertyName.GetPropertyName(() => FirstHiddenItemOnTheLeft), PropertyName.GetPropertyName(() => HasInvisibleItemsOnTheLeft));
            AddPropertyMapping(PropertyName.GetPropertyName(() => LastHiddenItemOnTheRight), PropertyName.GetPropertyName(() => HasInvisibleItemsOnTheRight));
        }

        #endregion

        #region Properties

        public Brush BackgroundBrush
        {
            get;
            set;
        }

        public ObservableCollection<FaTimelineEventBatchDTO> BatchList
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime? FirstHiddenItemOnTheLeft
        {
            get { return _firstHiddenItemOnTheLeft; }
            set
            {
                if (_firstHiddenItemOnTheLeft == value)
                    return;

                _firstHiddenItemOnTheLeft = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => FirstHiddenItemOnTheLeft);
            }
        }

        public bool HasInvisibleItemsOnTheLeft
        {
            get { return FirstHiddenItemOnTheLeft.HasValue && FirstHiddenItemOnTheLeft.Value < TimelineUtility.VisibleRangeBegin; }
        }

        public bool HasInvisibleItemsOnTheRight
        {
            get { return LastHiddenItemOnTheRight.HasValue && LastHiddenItemOnTheRight.Value > TimelineUtility.VisibleRangeEnd; }
        }

        public DateTime? LastHiddenItemOnTheRight
        {
            get { return _lastHiddenItemOnTheRight; }
            set
            {
                if (_lastHiddenItemOnTheRight == value)
                    return;

                _lastHiddenItemOnTheRight = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => LastHiddenItemOnTheRight);
            }
        }

        public ObservableCollection<FaTimelineItemDTO> TimelineItems
        {
            get { return _timelineItems; }
            set
            {
                _timelineItems = value;
                _timelineItems.CollectionChanged += TimelineItemsOnCollectionChanged;
            }
        }

        public FaTimelineUtility TimelineUtility
        {
            get { return _timelineUtility; }
            set
            {
                _timelineUtility = value;
                _timelineUtility.PropertyChanged += (sender, args) =>
                {
                    CalculateFirstLastHiddenItems();

                    if (args.PropertyName == "VisibleRangeBegin")
                    {
                        NotifyPropertyChanged.RaisePropertyChanged(() => HasInvisibleItemsOnTheLeft);
                    }
                    if (args.PropertyName == "VisibleRangeEnd")
                    {
                        NotifyPropertyChanged.RaisePropertyChanged(() => HasInvisibleItemsOnTheRight);
                    }
                };
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void CalculateFirstLastHiddenItems()
        {
            //recalculate first and last date of visible events
            var visibleItems = TimelineItems.Where(i => !i.IsFilteredOut).ToList();

            var hiddenItemsOnTheLeft = visibleItems.OfType<FaTimelineEventDTO>().Select(i => i.StartDate)
                .Concat(visibleItems.OfType<FaTimelinePeriodDTO>().Select(i => i.EndDate ?? DateTime.Today)).ToList();

            FirstHiddenItemOnTheLeft = hiddenItemsOnTheLeft.Count > 0 ? hiddenItemsOnTheLeft.Min() : DateTime.MaxValue;
            LastHiddenItemOnTheRight = visibleItems.Count > 0 ? visibleItems.Max(i => i.StartDate) : DateTime.MinValue;
        }

        private void TimelineItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    notifyCollectionChangedEventArgs.NewItems.Cast<FaTimelineItemDTO>().ToList().ForEach(ev => ev.PropertyChanged += TimelineItemsPropertyChanged);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    notifyCollectionChangedEventArgs.NewItems.Cast<FaTimelineItemDTO>().ToList().ForEach(ev => ev.PropertyChanged -= TimelineItemsPropertyChanged);
                    break;
            }
            CalculateFirstLastHiddenItems();
        }

        void TimelineItemsPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsFilteredOut")
            {
                CalculateFirstLastHiddenItems();
            }
        }

        #endregion

        #endregion
    }
}