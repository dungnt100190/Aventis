using System;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    public class FaTimelinePeriodDTO : FaTimelineItemDTO
    {
        #region Fields

        #region Private Fields

        private DateTime? _endDate;

        #endregion

        #endregion

        #region Properties

        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value == null ? (DateTime?)null : value.Value.Date; }
        }

        public string PendenzStatus { get; set; }

        public FaTimelineEventDTO[] PeriodEvents { get; set; }

        #endregion
    }
}