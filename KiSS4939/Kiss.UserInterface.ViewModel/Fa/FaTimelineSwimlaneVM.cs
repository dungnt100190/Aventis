using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Fa.Timeline;

namespace Kiss.UserInterface.ViewModel.Fa
{
    /// <summary>
    /// Model class for a swimm lane
    /// </summary>
    public class FaTimelineSwimlaneVM : DTO
    {
        #region Fields

        #region Private Fields

        private DateTime? _previousItem;
        private DateTime? _nextItem;
        private readonly FaTimelineItemDTO[] _allTimelineItems;
        private readonly ObservableCollection<CanvasItem<FaTimelineItemDTO>> _timelineItems = new ObservableCollection<CanvasItem<FaTimelineItemDTO>>();
        private const double EventWidth = 24;
        private const double PeriodHeightWithoutEvents = 24;
        private const double PeriodHeightWithEvents = 40;

        #endregion

        #endregion

        public event EventHandler<EventArgs<TimePeriod>> RequestVisibleRangeMove;

        private void OnRequestVisibleRangeMove(TimePeriod newVisibleRange)
        {
            var handler = RequestVisibleRangeMove;
            if (handler != null)
            {
                handler(this, new EventArgs<TimePeriod>(newVisibleRange));
            }
        }

        #region Constructors

        public FaTimelineSwimlaneVM()
            : this(null)
        {
        }

        public FaTimelineSwimlaneVM(IEnumerable<FaTimelineItemDTO> allItems)
        {
            _allTimelineItems = allItems == null ?
                                  new FaTimelineItemDTO[] { } :
                                  allItems
                                  .OrderBy(itm => itm.StartDate)
                                  .ToArray();

            CalculateItemPositions();
            MoveToPreviousItemCommand = new BaseCommand(MoveToPreviousItem);
            MoveToNextItemCommand = new BaseCommand(MoveToNextItem);
        }

        private void MoveToNextItem(object obj)
        {
            if (!NextItem.HasValue)
            {
                return;
            }

            MoveVisibleRangeToCenter(NextItem.Value);
        }

        private void MoveToPreviousItem(object obj)
        {
            if (!PreviousItem.HasValue)
            {
                return;
            }

            MoveVisibleRangeToCenter(PreviousItem.Value);
        }

        private void MoveVisibleRangeToCenter(DateTime newCenter)
        {
            var currentCenter = VisibleRange.From.AddDays(VisibleRange.TimeSpan.TotalDays * 0.5);
            var deltaDays = (newCenter - currentCenter).TotalDays;

            // upper border barrier
            deltaDays = Math.Min((TotalRange.To - VisibleRange.To).TotalDays, deltaDays);
            // lower border barrier
            deltaDays = Math.Max((TotalRange.From - VisibleRange.From).TotalDays, deltaDays);

            OnRequestVisibleRangeMove(VisibleRange.MoveByDays(deltaDays).CropBy(TotalRange));
        }

        #endregion

        #region Properties

        public ICommand MoveToPreviousItemCommand { get; private set; }
        public ICommand MoveToNextItemCommand { get; private set; }

        private Brush _backgroundBrush;
        public Brush BackgroundBrush
        {
            get { return _backgroundBrush; }
            set { SetProperty(ref _backgroundBrush, value, () => BackgroundBrush); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value, () => Description); }
        }

        private string _shortDescription;
        public string ShortDescription
        {
            get { return _shortDescription; }
            set { SetProperty(ref _shortDescription, value, () => ShortDescription); }
        }

        public DateTime? PreviousItem
        {
            get { return _previousItem; }
            private set
            {
                SetProperty(ref _previousItem, value, () => PreviousItem);
                HasPreviousItem = value.HasValue;
            }
        }

        private bool _hasPreviousItem;
        public bool HasPreviousItem
        {
            get { return _hasPreviousItem; }
            private set { SetProperty(ref _hasPreviousItem, value, () => HasPreviousItem); }
        }


        private bool _hasNextItem;
        public bool HasNextItem
        {
            get { return _hasNextItem; }
            private set { SetProperty(ref _hasNextItem, value, () => HasNextItem); }
        }

        public DateTime? NextItem
        {
            get { return _nextItem; }
            private set
            {
                SetProperty(ref _nextItem, value, () => NextItem);
                HasNextItem = value.HasValue;
            }
        }

        public ObservableCollection<CanvasItem<FaTimelineItemDTO>> TimelineItems
        {
            get { return _timelineItems; }
        }

        private TimePeriod _totalRange;
        public TimePeriod TotalRange
        {
            get { return _totalRange; }
            set
            {
                if (SetProperty(ref _totalRange, value, () => TotalRange))
                {
                    CalculateItemPositions();
                }
            }
        }

        private TimePeriod _visibleRange;
        public TimePeriod VisibleRange
        {
            get { return _visibleRange; }
            set
            {
                var deltaRange = Math.Abs(_visibleRange.TimeSpan.Ticks - value.TimeSpan.Ticks);
                if (SetProperty(ref _visibleRange, value, () => VisibleRange))
                {
                    CalculateFirstLastHiddenItems();
                    if (deltaRange > 1000)
                    {
                        CalculateItemPositions();
                    }
                    SetViewport();
                }
            }
        }

        private void SetViewport()
        {
            var dayWidth = ScaleHelper.CalculateDayWidth(_canvasSize.Width, VisibleRange);
            var firstVisiblePosition = ScaleHelper.GetPixelOffset(VisibleRange.From, TotalRange.From, dayWidth);
            Offset = new Point(firstVisiblePosition, Offset.Y);

        }

        private Size _canvasSize;
        public Size CanvasSize
        {
            get { return _canvasSize; }
            set
            {
                if (_canvasSize.Width == value.Width)
                {
                    return;
                }
                _canvasSize = value;
                CalculateItemPositions();
                SetViewport();
            }
        }

        private Point _offset;
        public Point Offset
        {
            get { return _offset; }
            set { SetProperty(ref _offset, value, () => Offset); }
        }

        private IEnumerable<int> _visibleThemen;
        public IEnumerable<int> VisibleThemen
        {
            set
            {
                _visibleThemen = value;
                foreach (var timelineItem in _allTimelineItems)
                {
                    timelineItem.IsVisible = DetermineIsVisible(timelineItem);
                }
                CalculateItemPositions();
            }
        }

        private bool DetermineIsVisible(FaTimelineItemDTO timelineItem)
        {
            return _visibleThemen != null && (timelineItem.ThemaCodes == null ||
                                              timelineItem.ThemaCodes.Any(_visibleThemen.Contains)) &&
                   _visibleItemTypes != null && _visibleItemTypes.Contains(timelineItem.Type);
        }

        private IEnumerable<FaZeitachseDTOType> _visibleItemTypes;
        public IEnumerable<FaZeitachseDTOType> VisibleItemTypes
        {
            set
            {
                _visibleItemTypes = value;
                foreach (var timelineItem in _allTimelineItems)
                {
                    timelineItem.IsVisible = DetermineIsVisible(timelineItem);
                }
                CalculateItemPositions();
            }
        }

        private void CalculateItemPositions()
        {
            _timelineItems.Clear(); // easier, but probably slower version. if too slow, don't clear but check if batch or not and exchange items in _timelineItems
            var dayWidth = ScaleHelper.CalculateDayWidth(_canvasSize.Width, VisibleRange);
            if (dayWidth <= 0.0)
            {
                return;
            }

            AddCanvasItemsForEvents(_allTimelineItems.Where(itm => itm.IsVisible && itm is FaTimelineEventDTO),
                                    0.0,
                                    dayWidth);

            // starting point for periods: move down if there are events
            var periodStartingTop = _timelineItems.Any() ? PeriodHeightWithoutEvents : 0.0;


            // arrange periods
            var beamUsedUntil = new Dictionary<int, DateTime>();
            var beamHeights = new Dictionary<int, double>();
            foreach (var item in _allTimelineItems
                                   .Where(itm => itm.IsVisible && itm is FaTimelinePeriodDTO)
                                   .OrderBy(per => per.StartDate))
            {

                // which beam?
                var period = (FaTimelinePeriodDTO)item;
                var beamList = beamUsedUntil
                               .OrderBy(bem => bem.Key)
                               .Where(bem => bem.Value < period.StartDate)
                               .Select(bem => bem.Key)
                               .ToList();

                var beam = beamList.Any() ? beamList.First() : beamUsedUntil.Count;

                // determine height
                var beamHeight = period.PeriodEvents.Any() ?
                                   PeriodHeightWithEvents :
                                   PeriodHeightWithoutEvents;
                beamHeight = Math.Max(beamHeight, beamHeights.GetValue(beam));

                // create item
                var positionLeft = ScaleHelper.GetPixelOffset(period.StartDate, TotalRange.From, dayWidth);
                var periodCanvasItem = new CanvasItem<FaTimelineItemDTO>
                                           {
                                               PositionLeft = positionLeft,
                                               Width = ScaleHelper.GetPixelOffset(period.EndDate ?? DateTime.Today, TotalRange.From, dayWidth)
                                                       - positionLeft
                                                       + (period.EndDate.HasValue ? 0.0 : 20.0),
                                               PositionTop = periodStartingTop + beamHeights
                                                                                 .Where(bem => bem.Key < beam)
                                                                                 .Sum(bem => bem.Value),
                                               Height = beamHeight,
                                               DataItem = period
                                           };
                _timelineItems.Add(periodCanvasItem);

                // save settings
                beamUsedUntil.SetValue(beam, period.EndDate ?? DateTime.Today);
                beamHeights.SetValue(beam, beamHeight);

                // add period events
                AddCanvasItemsForEvents(period.PeriodEvents, periodCanvasItem.PositionTop, dayWidth);
            }

            AddTodayLine(periodStartingTop+beamHeights.Sum(bmh => bmh.Value), dayWidth);

            CalculateFirstLastHiddenItems();
        }

        private void AddTodayLine(double height, double dayWidth)
        {
            //_timelineItems.
            // ToDo
        }

        private void AddCanvasItemsForEvents(IEnumerable<FaTimelineItemDTO> timelineItems, double currentPositionTop, double dayWidth)
        {
            // arrange events
            var previousPositionRight = 0.0;
            CanvasItem<FaTimelineItemDTO> previousItem = null;
            foreach (var item in timelineItems
                                 .Select(itm => new CanvasItem<FaTimelineItemDTO>
                                                    {
                                                        PositionLeft = ScaleHelper.GetPixelOffset(itm.StartDate, TotalRange.From, dayWidth),
                                                        PositionTop = currentPositionTop,
                                                        Width = EventWidth,
                                                        Height = EventWidth,
                                                        DataItem = itm
                                                    }))
            {
                if (item.PositionLeft < previousPositionRight)
                {
                    // create batch
                    previousItem = CreateBatchWithPreviousItem(previousItem, item);
                }
                else
                {
                    // as we know now that the previous item does not overlap, we can insert it now
                    if (previousItem != null)
                    {
                        _timelineItems.Add(previousItem);
                    }

                    // prepare new separate item
                    previousPositionRight = item.PositionLeft + item.Width;
                    previousItem = item;
                }
            }
            if (previousItem != null && !_timelineItems.Contains(previousItem))
            {
                _timelineItems.Add(previousItem);
            }
        }

        private static CanvasItem<FaTimelineItemDTO> CreateBatchWithPreviousItem(CanvasItem<FaTimelineItemDTO> previousItem,
                                                                                 CanvasItem<FaTimelineItemDTO> newItem)
        {
            if (previousItem == null)
            {
                // no previous item, transform newItem into batch
                return new CanvasItem<FaTimelineItemDTO>
                           {
                               PositionLeft = newItem.PositionLeft,
                               PositionTop = newItem.PositionTop,
                               Width = newItem.Width,
                               Height = newItem.Height,
                               DataItem = new FaTimelineEventBatchDTO(new[] { newItem.DataItem as FaTimelineEventDTO })
                           };
            }
            if (previousItem.DataItem is FaTimelineEventBatchDTO)
            {
                // previous item is already batch, just insert new item
                var batchDataItem = previousItem.DataItem as FaTimelineEventBatchDTO;
                batchDataItem.Events.Add(newItem.DataItem as FaTimelineEventDTO); // ToDo: periods
                return previousItem;
            }
            // previous item is not batch, transform previous into batch and add new item
            return new CanvasItem<FaTimelineItemDTO>
                       {
                           PositionLeft = previousItem.PositionLeft,
                           PositionTop = previousItem.PositionTop,
                           Width = previousItem.Width,
                           Height = previousItem.Height,
                           DataItem = new FaTimelineEventBatchDTO(new[] { previousItem.DataItem as FaTimelineEventDTO,
                                                                          newItem.DataItem as FaTimelineEventDTO })
                       };
        }

        #endregion

        #region Methods

        #region Private Methods

        private void CalculateFirstLastHiddenItems()
        {
            //recalculate first and last date of visible events
            var visibleItems = _timelineItems
                               .Where(itm => itm.DataItem.IsVisible)
                               .ToList();

            var hiddenItemsLeft = visibleItems
                                  .Select(itm => itm.DataItem.StartDate)
                                  .Concat(visibleItems.OfType<FaTimelinePeriodDTO>()
                                          .Select(i => i.EndDate ?? DateTime.Today))
                                  .Where(dat => dat < VisibleRange.From)
                                  .OrderByDescending(dat => dat)
                                  .ToList();

            PreviousItem = hiddenItemsLeft.Any() ? hiddenItemsLeft.First() : (DateTime?)null;

            var dayWidth = ScaleHelper.CalculateDayWidth(_canvasSize.Width, VisibleRange);
            var dayMargin = dayWidth < double.Epsilon ? 0.0 : EventWidth / dayWidth;
            var hiddenItemsRight = visibleItems
                                   .Select(itm => itm.DataItem.StartDate)
                                   .Where(dat => dat > VisibleRange.To.AddDays(-dayMargin))
                                   .OrderBy(dat => dat);

            NextItem = hiddenItemsRight.Any() ? hiddenItemsRight.First() : (DateTime?)null;
        }

        #endregion

        #endregion
    }
}