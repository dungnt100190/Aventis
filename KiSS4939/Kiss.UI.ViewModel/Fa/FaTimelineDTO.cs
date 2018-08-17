using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kiss.UI.ViewModel.Fa
{
    /// <summary>
    /// Model clas for the timeline control
    /// </summary>
    public class FaTimelineDTO
    {
        #region Constructors

        public FaTimelineDTO()
        {
            Swimmlanes = new ObservableCollection<FaTimelineSwimmlaneDTO>();
        }

        #endregion

        #region Properties

        public IEnumerable<DateTime> EventDates
        {
            get;
            set;
        }

        public ObservableCollection<FaTimelineSwimmlaneDTO> Swimmlanes
        {
            get;
            set;
        }

        public DateTime TotalRangeBegin
        {
            get;
            set;
        }

        public DateTime TotalRangeEnd
        {
            get;
            set;
        }

        public DateTime VisibleRangeBegin
        {
            get;
            set;
        }

        public DateTime VisibleRangeEnd
        {
            get;
            set;
        }

        #endregion
    }
}