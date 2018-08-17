using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    /// <summary>
    /// Model class for a swimm lane
    /// </summary>
    public class FaTimelineSwimlaneVM : Bindable
    {
        #region Fields

        #region Private Fields

        private DateTime? _previousItem;
        private DateTime? _nextItem;
        private FaTimelineItemDTO[] _allTimelineItems = new FaTimelineItemDTO[] { };
        private const double EventWidth = 32;
        private const double PeriodHeightWithoutEvents = 24;
        private const double PeriodHeightWithEvents = 50;

        #endregion

        #endregion

        public event EventHandler<EventArgs<DateTime>> RequestMoveToCenter;

        private void OnRequestMoveToCenter(DateTime newCenter)
        {
            var handler = RequestMoveToCenter;
            if (handler != null)
            {
                handler(this, new EventArgs<DateTime>(newCenter));
            }
        }

        #region Constructors

        public FaTimelineSwimlaneVM()
        {
            VisibleItems = new ObservableCollection<CanvasItem<FaTimelineItemDTO>>();
            MoveToPreviousItemCommand = new BaseCommand(MoveToPreviousItem);
            MoveToNextItemCommand = new BaseCommand(MoveToNextItem);
        }

        private void MoveToNextItem(object obj)
        {
            if (!NextItem.HasValue)
            {
                return;
            }
            OnRequestMoveToCenter(NextItem.Value);
        }

        private void MoveToPreviousItem(object obj)
        {
            if (!PreviousItem.HasValue)
            {
                return;
            }
            OnRequestMoveToCenter(PreviousItem.Value);
        }

        #endregion

        #region Properties

        public ICommand MoveToPreviousItemCommand { get; private set; }
        public ICommand MoveToNextItemCommand { get; private set; }

        public IEnumerable<FaTimelineItemDTO> Items
        {
            get { return _allTimelineItems; }
            set
            {
                _allTimelineItems = value == null ?
                                      new FaTimelineItemDTO[] { } :
                                      value.OrderBy(itm => itm.StartDate)
                                           .ToArray();
                CalculateItemPositions();
            }
        }

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

        public ObservableCollection<CanvasItem<FaTimelineItemDTO>> VisibleItems { get; private set; }

        private TimelineDrawParameters _drawParameters;
        public TimelineDrawParameters DrawParameters
        {
            get { return _drawParameters; }
            set
            {
                var visibleRangeLengthChanged = Math.Abs(_drawParameters.VisibleRange.TimeSpan.Ticks - value.VisibleRange.TimeSpan.Ticks) > 1000;
                var visibleRangeStartChanged = _drawParameters.VisibleRange.From.Ticks != value.VisibleRange.From.Ticks;
                var totalRangeChanged = _drawParameters.TotalRange != value.TotalRange;
                var dayWidthChanged = Math.Abs(_drawParameters.DayWidth - value.DayWidth) > 0.000001;
                var typesChanged = HasSequenceChanged(_drawParameters.VisibleItemTypes, value.VisibleItemTypes);
                var themenChanged = HasSequenceChanged(_drawParameters.VisibleThemenCodes, value.VisibleThemenCodes);

                _drawParameters = value;

                if (typesChanged || themenChanged)
                {
                    foreach (var timelineItem in _allTimelineItems)
                    {
                        timelineItem.IsVisible = DetermineIsVisible(timelineItem,
                                                                    _drawParameters.VisibleItemTypes,
                                                                    _drawParameters.VisibleThemenCodes);
                    }
                }

                if (visibleRangeLengthChanged || totalRangeChanged || dayWidthChanged || typesChanged || themenChanged)
                {
                    CalculateItemPositions();
                }

                if (visibleRangeStartChanged || totalRangeChanged || dayWidthChanged)
                {
                    SetViewport();
                }
            }
        }

        private static bool HasSequenceChanged<T>(IEnumerable<T> before, IEnumerable<T> after)
        {
            return before == null ^ after == null || // XOR: one is null, the other not -> seuqence has changed
                   before != null && !before.SequenceEqual(after);
        }

        private void SetViewport()
        {
            var firstVisiblePosition = ScaleHelper.GetPixelOffset(_drawParameters.VisibleRange.From, _drawParameters.TotalRange.From, _drawParameters.DayWidth);
            var lastVisiblePosition = ScaleHelper.GetPixelOffset(_drawParameters.VisibleRange.To, _drawParameters.TotalRange.From, _drawParameters.DayWidth);
            Offset = new Point(firstVisiblePosition, Offset.Y);

            // set padding so the labels are still visible when the scale item is only partly visible
            foreach (var scaleItem in VisibleItems
                                      .Where(itm => itm.PositionLeft < firstVisiblePosition && itm.PositionLeft + itm.Width > firstVisiblePosition ||
                                                    itm.PositionLeft < lastVisiblePosition && itm.PositionLeft + itm.Width > lastVisiblePosition ||
                                                    itm.Padding.Left > 0 || itm.Padding.Right > 0)) // reset items that were partly hidden before, but are fully visible now
            {
                var hiddenWidthLeft = Math.Max(firstVisiblePosition - scaleItem.PositionLeft + 15, 0);
                var hiddenWidthRight = Math.Max(scaleItem.PositionLeft + scaleItem.Width - lastVisiblePosition, 0);
                //// avoid arrow

                //const double arrowWidth = 25.0;
                //var widthBelowLeftArrow = Math.Min(Math.Max(firstVisiblePosition + arrowWidth - scaleItem.PositionLeft, 0.0),arrowWidth);
                //if (widthBelowLeftArrow > 0.0)
                //{
                //    hiddenWidthLeft += Math.Min(widthBelowLeftArrow, Math.Max(scaleItem.Width - 30.0, 0.0));
                //}
                scaleItem.Padding = new Thickness(hiddenWidthLeft, 0, hiddenWidthRight, 0);
            }
            CalculateFirstLastHiddenItems();
        }


        private Point _offset;
        public Point Offset
        {
            get { return _offset; }
            set { SetProperty(ref _offset, value, () => Offset); }
        }


        private static bool DetermineIsVisible(FaTimelineItemDTO timelineItem, IEnumerable<FaZeitachseDTOType> visibleItemTypes, IEnumerable<XLOVCode> visibleThemenCodes)
        {
            return visibleThemenCodes != null && (timelineItem.ThemaCodes == null || timelineItem.ThemaCodes.Length == 0 ||
                                                  timelineItem.ThemaCodes.Any(visibleThemenCodes.Contains)) &&
                   visibleItemTypes != null && visibleItemTypes.Contains(timelineItem.Type);
        }


        private bool _hasVisibleItems;


        private void CalculateItemPositions()
        {
            VisibleItems.Clear(); // easier, but probably slower version. if too slow, don't clear but check if batch or not and exchange items in _timelineItems
            if (_drawParameters.DayWidth <= 0.0)
            {
                return;
            }

            AddCanvasItemsForEvents(_allTimelineItems.Where(itm => itm.IsVisible && itm is FaTimelineEventDTO), 0.0);

            // starting point for periods: move down if there are events
            var periodStartingTop = VisibleItems.Any() ? PeriodHeightWithoutEvents : 0.0;


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
                var positionLeft = ScaleHelper.GetPixelOffset(period.StartDate, _drawParameters.TotalRange.From, _drawParameters.DayWidth);
                var endDate = DateTime.Today;
                if (period.EndDate.HasValue)
                {
                    endDate = period.EndDate.Value.AddDays(1).AddMinutes(-1);
                }
                var periodCanvasItem = new CanvasItem<FaTimelineItemDTO>
                                           {
                                               PositionLeft = positionLeft,
                                               Width = ScaleHelper.GetPixelOffset(endDate, _drawParameters.TotalRange.From, _drawParameters.DayWidth)
                                                       - positionLeft
                                                       + (period.EndDate.HasValue ? 0.0 : 40.0),
                                               PositionTop = periodStartingTop + beamHeights
                                                                                 .Where(bem => bem.Key < beam)
                                                                                 .Sum(bem => bem.Value),
                                               Height = beamHeight,
                                               DataItem = period
                                           };
                VisibleItems.Add(periodCanvasItem);

                // save settings
                beamUsedUntil.SetValue(beam, period.EndDate ?? DateTime.Today);
                beamHeights.SetValue(beam, beamHeight);

                // add period events
                AddCanvasItemsForEvents(period.PeriodEvents, periodCanvasItem.PositionTop);
            }

            AddTodayLine(periodStartingTop + beamHeights.Sum(bmh => bmh.Value));
            HasVisibleItems = VisibleItems.Any();

            SetViewport();
        }

        public bool HasVisibleItems
        {
            get { return _hasVisibleItems; }
            set { SetProperty(ref _hasVisibleItems, value, () => HasVisibleItems); }
        }

        private void AddTodayLine(double height)
        {
            //_timelineItems.
            // ToDo
        }

        private void AddCanvasItemsForEvents(IEnumerable<FaTimelineItemDTO> timelineItems, double currentPositionTop)
        {
            // arrange events
            var previousPositionRight = 0.0;
            CanvasItem<FaTimelineItemDTO> previousItem = null;
            foreach (var item in timelineItems
                                 .Select(itm => new CanvasItem<FaTimelineItemDTO>
                                                    {
                                                        PositionLeft = ScaleHelper.GetPixelOffset(itm.StartDate, _drawParameters.TotalRange.From, _drawParameters.DayWidth),
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
                        VisibleItems.Add(previousItem);
                    }

                    // prepare new separate item
                    previousPositionRight = item.PositionLeft + item.Width;
                    previousItem = item;
                }
            }
            if (previousItem != null && !VisibleItems.Contains(previousItem))
            {
                VisibleItems.Add(previousItem);
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
                batchDataItem.Events.Add(newItem.DataItem as FaTimelineEventDTO);
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
            //var visibleItems = VisibleItems
            //                   .Where(itm => itm.DataItem.IsVisible)
            //                   .ToList();

            var hiddenItemsLeft = VisibleItems
                                  .Select(itm => itm.DataItem.StartDate)
                                  .Concat(VisibleItems.OfType<FaTimelinePeriodDTO>()
                                          .Select(i => i.EndDate ?? DateTime.Today))
                                  .Where(dat => dat < _drawParameters.VisibleRange.From)
                                  .OrderByDescending(dat => dat)
                                  .ToList();

            PreviousItem = hiddenItemsLeft.Any() ? hiddenItemsLeft.First() : (DateTime?)null;

            var dayMargin = _drawParameters.DayWidth < double.Epsilon ? 0.0 : EventWidth / _drawParameters.DayWidth;
            var hiddenItemsRight = VisibleItems
                                   .Select(itm => itm.DataItem.StartDate)
                                   .Where(dat => dat > _drawParameters.VisibleRange.To.AddDays(-dayMargin))
                                   .OrderBy(dat => dat);

            NextItem = hiddenItemsRight.Any() ? hiddenItemsRight.First() : (DateTime?)null;
        }

        #endregion

        #endregion
    }
}