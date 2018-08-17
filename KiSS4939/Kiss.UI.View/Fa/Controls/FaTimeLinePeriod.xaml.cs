using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

using Kiss.UI.ViewModel.Fa;

namespace Kiss.UI.View.Fa.Controls
{
    /// <summary>
    /// Represents an event on a timeline axis (swimm lane).
    /// </summary>
    public partial class FaTimelinePeriod
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaTimelinePeriodDTO _timelinePeriod;
        private readonly FaTimelineUtility _timelineUtility;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize the object
        /// </summary>
        /// <param name="timelinePeriod">Event data to draw</param>
        /// <param name="timelineUtility"></param>
        public FaTimelinePeriod(FaTimelinePeriodDTO timelinePeriod, FaTimelineUtility timelineUtility)
        {
            InitializeComponent();
            _timelineUtility = timelineUtility;
            _timelinePeriod = timelinePeriod;

            if (timelinePeriod.PeriodEvents != null && timelinePeriod.PeriodEvents.Count > 0)
            {
                DrawPeriodEvents(timelinePeriod);
            }
            DataContext = timelinePeriod;
        }

        #endregion

        #region EventHandlers

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_timelinePeriod.HasJumpToPath && e.ClickCount > 1)
            {
                FaTimelineUtility.ExecuteJumpToPath(_timelinePeriod.JumpToPath);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        // Draw the scale for the timeline
        private void DrawPeriodEvents(FaTimelinePeriodDTO timelinePeriod)
        {
            _timelineUtility.CreateBatchList(timelinePeriod.BatchList, timelinePeriod.PeriodEvents);

            foreach (var batch in timelinePeriod.BatchList)
            {
                var timelineItem = new FaTimelineEvent(batch);

                // Position the batch to the start date of the first element
                var startDateBatch = batch.Events.Min(te => te.StartDate);
                var x = (startDateBatch - _timelinePeriod.StartDate).Days * _timelineUtility.DayWidth;

                Canvas.SetLeft(timelineItem, x);

                // Events are always on top of periods
                Canvas.SetZIndex(timelineItem, 100);

                // Add element to canvas
                CanvasDocuments.Children.Add(timelineItem);
            }
        }

        #endregion

        #endregion
    }
}