using System.Collections.Generic;
using System.Linq;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    public class FaTimelineEventBatchDTO : FaTimelineItemDTO
    {
        #region Constructors

        public FaTimelineEventBatchDTO(IEnumerable<FaTimelineEventDTO> events)
        {
            //AddPropertyMapping(PropertyName.GetPropertyName(() => Events), PropertyName.GetPropertyName(() => VisibleEvents));

            Events = events.ToList();
            StartDate = Events.Min(itm => itm.StartDate);
            //Events.CollectionChanged += new NotifyCollectionChangedEventHandler(Events_CollectionChanged);
        }

        #endregion

        #region Properties

        public IList<FaTimelineEventDTO> Events { get; private set; }

        //public ObservableCollection<FaTimelineEventDTO> VisibleEvents
        //{
        //    get { return new ObservableCollection<FaTimelineEventDTO>(Events.Where(e => e.IsVisible == false)); }
        //}

        #endregion

        #region EventHandlers

        //void Events_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    //NotifyPropertyChanged.RaisePropertyChanged(() => VisibleEvents);
        //    switch (e.Action)
        //    {
        //        case NotifyCollectionChangedAction.Add:
        //            e.NewItems.Cast<FaTimelineEventDTO>().ToList().ForEach(ev => ev.PropertyChanged += EventSourceOnPropertyChanged);
        //            break;

        //        case NotifyCollectionChangedAction.Remove:
        //            e.NewItems.Cast<FaTimelineEventDTO>().ToList().ForEach(ev => ev.PropertyChanged -= EventSourceOnPropertyChanged);
        //            break;
        //    }
        //}

        #endregion

        #region Methods

        #region Private Methods

        //private void EventSourceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        //{
        //    NotifyPropertyChanged.RaisePropertyChanged(() => Events);
        //}

        #endregion

        #endregion
    }
}