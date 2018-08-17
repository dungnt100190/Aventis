using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;
using Container = Kiss.Infrastructure.IoC.Container;
using Kiss.Interfaces.UI;

namespace Kiss.UI.ViewModel.Fa
{
    /// <summary>
    /// Utility class for timeline control
    /// Used by the timeline control to scale propperly
    /// </summary>
    public class FaTimelineUtility
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FaTimelineItemDTO> _allEvents;
        private readonly NotifyPropertyChanged _notifyPropertyChanged;

        #endregion

        #region Private Fields

        private double _dayWidth;
        private DateTime _visibleRangeBegin;
        private DateTime _visibleRangeEnd;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the Utility
        /// </summary>
        /// <param name="model">Represents data (axises and events) on the timeline</param>
        /// <param name="viewPortWidth">Current width of the time line used for scaling</param>
        public FaTimelineUtility(FaTimelineDTO model, double viewPortWidth)
        {
            // To calculate start end end of the timeline events on all axises are considered
            _allEvents = new List<FaTimelineItemDTO>();
            _notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged);

            if (model != null)
            {
                foreach (var axis in model.Swimmlanes)
                {
                    axis.TimelineUtility = this;
                    _allEvents.AddRange(axis.TimelineItems);
                }

                TotalRangeBegin = model.TotalRangeBegin;
                TotalRangeEnd = model.TotalRangeEnd;
                VisibleRangeBegin = model.VisibleRangeBegin;
                VisibleRangeEnd = model.VisibleRangeEnd;
            }
            else
            {
                TotalRangeBegin = DateTime.Today;
                TotalRangeEnd = DateTime.Today.AddDays(1);
                VisibleRangeBegin = DateTime.Today;
                VisibleRangeEnd = DateTime.Today.AddDays(1);
            }

            var canvasWidth = CalculateScaleWidth(viewPortWidth);
            CalculateDayWidth(canvasWidth);
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public static double EventWidth
        {
            get { return 25; }
        }

        /// <summary>
        /// The width of one day in the current scale
        /// </summary>
        public double DayWidth
        {
            get { return _dayWidth; }
        }

        /// <summary>
        /// First date on the timeline
        /// can be less than the start date of the first event
        /// </summary>
        private DateTime _totalRangeBegin;
        public DateTime TotalRangeBegin
        {
            get { return _totalRangeBegin.Date; } 
            set { _totalRangeBegin = value;}
        }

        /// <summary>
        /// Last date on the time line
        /// can be greater than the end date of the last event
        /// </summary>
        private DateTime _totalRangeEnd;
        public DateTime TotalRangeEnd
        {
            get { return _totalRangeEnd.Date; }
            set { _totalRangeEnd = value; }
        }

        public int VirtualaxisHeight
        {
            get { return 25; }
        }

        public DateTime VisibleRangeBegin
        {
            get { return _visibleRangeBegin; }
            set
            {
                if (_visibleRangeBegin == value.Date)
                    return;

                _visibleRangeBegin = value.Date;

                _notifyPropertyChanged.RaisePropertyChanged(() => VisibleRangeBegin);
            }
        }

        public DateTime VisibleRangeEnd
        {
            get { return _visibleRangeEnd; }
            set
            {
                if (_visibleRangeEnd == value.Date)
                    return;

                _visibleRangeEnd = value.Date;

                _notifyPropertyChanged.RaisePropertyChanged(() => VisibleRangeEnd);
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void ExecuteJumpToPath(string jumpToPath)
        {
            var formController = Container.Resolve<IKissFormController>();
            string className;
            var parameters = formController.ConvertToParameterArray(jumpToPath, out className);
            formController.OpenForm(className, parameters);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the widht for one day on the scale
        /// </summary>
        /// <param name="canvasWidth">Width of the whole scale</param>
        public void CalculateDayWidth(double canvasWidth)
        {
            _dayWidth = ScaleHelper.CalculateDayWidth(canvasWidth, TotalRangeBegin, TotalRangeEnd);
        }

        public double CalculateScaleWidth(double viewPortWidth)
        {
            var visibleDays = Math.Max((VisibleRangeEnd - VisibleRangeBegin).Days, 1);
            var totalDays = Math.Max((TotalRangeEnd - TotalRangeBegin).Days, 1);

            return viewPortWidth / visibleDays * totalDays;
        }

        public void CreateBatchList(IList<FaTimelineEventBatchDTO> batchList, IEnumerable<FaTimelineEventDTO> timelineEvents)
        {
            batchList.Clear();
            var currentStartDate = DateTime.MinValue;
            foreach (var timelineEvent in timelineEvents.OrderBy(e => e.StartDate))
            {
                var currentX = DateToX(currentStartDate) + EventWidth;
                // Create new batch if overlapping
                if (DateToX(timelineEvent.StartDate) > currentX)
                {
                    batchList.Add(new FaTimelineEventBatchDTO(new List<FaTimelineEventDTO>()));
                    currentStartDate = timelineEvent.StartDate;
                }

                if (batchList.Count == 0)
                {
                    batchList.Add(new FaTimelineEventBatchDTO(new List<FaTimelineEventDTO>()));
                }
                batchList.Last().Events.Add(timelineEvent);
            }
        }

        /// <summary>
        /// Calculates the widht in pixels on the scale
        /// </summary>
        /// <param name="startDate">Start of the span</param>
        /// <param name="endDate">En of the span</param>
        /// <returns>With of the span in pixels on the current scale</returns>
        public double DateToWidth(DateTime startDate, DateTime? endDate)
        {
            TimeSpan timeSpan;

            if (endDate != null)
            {
                timeSpan = endDate.Value - startDate;
            }
            else
            {
                timeSpan = new TimeSpan(1);
            }

            return timeSpan.TotalDays * _dayWidth;
        }

        /// <summary>
        /// Converts a date to the pixel offset to the beginning of the scale.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double DateToX(DateTime date)
        {
            return ScaleHelper.GetPixelOffset(date, TotalRangeBegin, _dayWidth);
        }

        /// <summary>
        /// Test a period DTO for overlapping items
        /// </summary>
        /// <param name="swimlane"> </param>
        /// <param name="timelinePeriod"> </param>
        /// <returns>
        /// true: space is occuppied 
        /// false: space is free
        /// </returns>
        public bool IsOverlapping(FaTimelineSwimmlaneDTO swimlane, FaTimelinePeriodDTO timelinePeriod)
        {
            var startDate = timelinePeriod.StartDate;
            var endDate = timelinePeriod.EndDate ?? DateTime.MaxValue;
            var virtualAxis = timelinePeriod.VirtualAxisFrom;

            // Only consider Periods on this axis
            var testPeriods = swimlane.TimelineItems.OfType<FaTimelinePeriodDTO>().Where(ti => ti.VirtualAxisFrom == virtualAxis || ti.VirtualAxisTo == virtualAxis);
            var testEvents = swimlane.TimelineItems.OfType<FaTimelineEventDTO>().Where(ti => ti.VirtualAxisFrom == virtualAxis);

            // To have one "overlapping" element is Ok, because its the period itself
            return (testPeriods.Count(tp => !(tp.EndDate < startDate || tp.StartDate > endDate)) > 1) || ((testEvents.Count(tp => !(XToDate(DateToX(tp.StartDate) + 20) <= startDate || tp.StartDate >= endDate))) > 1);
        }

        /// <summary>
        /// Converts a x value on the scale to a date
        /// </summary>
        /// <param name="x">x value</param>
        /// <returns></returns>
        public DateTime XToDate(double x)
        {
            var numberOfDays = x / _dayWidth;
            return TotalRangeBegin.AddDays(numberOfDays);
        }

        #endregion

        #endregion
    }
}