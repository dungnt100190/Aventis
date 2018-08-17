using System;
using System.Collections.ObjectModel;

namespace Kiss.UI.ViewModel.Fa
{
    public class FaTimelinePeriodDTO : FaTimelineItemDTO
    {
        #region Fields

        #region Private Fields

        private DateTime? _endDate;

        #endregion

        #endregion

        #region Constructors

        public FaTimelinePeriodDTO()
        {
            BatchList = new ObservableCollection<FaTimelineEventBatchDTO>();
        }

        #endregion

        #region Properties

        public ObservableCollection<FaTimelineEventBatchDTO> BatchList
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value == null ? (DateTime?)null : value.Value.Date; }
        }

        public string PendenzStatus
        {
            get;
            set;
        }

        public ObservableCollection<FaTimelineEventDTO> PeriodEvents
        {
            get;
            set;
        }

        public int VirtualAxisTo
        {
            get { return PeriodEvents == null ? VirtualAxisFrom : PeriodEvents.Count == 0 ? VirtualAxisFrom : VirtualAxisFrom + 1; }
        }

        #endregion
    }
}