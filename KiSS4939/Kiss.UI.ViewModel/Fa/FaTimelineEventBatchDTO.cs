using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Kiss.Infrastructure;
using Kiss.Model.DTO;

namespace Kiss.UI.ViewModel.Fa
{
    public class FaTimelineEventBatchDTO : Kiss.Model.DTO.DTO
    {
        #region Constructors

        public FaTimelineEventBatchDTO(IEnumerable<FaTimelineEventDTO> events)
        {
            AddPropertyMapping(PropertyName.GetPropertyName(() => Events), PropertyName.GetPropertyName(() => VisibleEvents));

            Events = new ObservableCollection<FaTimelineEventDTO>(events);
            Events.CollectionChanged += new NotifyCollectionChangedEventHandler(Events_CollectionChanged);
        }

        #endregion

        #region Properties

        public ObservableCollection<FaTimelineEventDTO> Events
        {
            get; set;
        }

        public ObservableCollection<FaTimelineEventDTO> VisibleEvents
        {
            get { return new ObservableCollection<FaTimelineEventDTO>(Events.Where(e => e.IsFilteredOut == false)); }
        }

        #endregion

        #region EventHandlers

        void Events_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(() => VisibleEvents);
            switch (e.Action)
            {
                    case NotifyCollectionChangedAction.Add:
                    e.NewItems.Cast<FaTimelineEventDTO>().ToList().ForEach(ev => ev.PropertyChanged += EventSourceOnPropertyChanged);
                    break;

                    case NotifyCollectionChangedAction.Remove:
                    e.NewItems.Cast<FaTimelineEventDTO>().ToList().ForEach(ev => ev.PropertyChanged -= EventSourceOnPropertyChanged);
                    break;
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void EventSourceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            NotifyPropertyChanged.RaisePropertyChanged(() => Events);
        }

        #endregion

        #endregion
    }
}