using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Wsh
{
    public class WshAbzugDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private ObjectChangeTracker _changeTracker;
        private decimal? _gblAbzugProzent;
        private decimal? _gblAktuell;
        private bool _hatNurGrauePositionen;
        private decimal _saldo;
        private DateTime? _voraussichtlicheDauer;
        private WshAbzug _wshAbzug;
        private ObservableCollection<WshPositionAbzugDTO> _wshPosition;

        #endregion

        #endregion

        #region Constructors

        public WshAbzugDTO()
        {
        }

        public WshAbzugDTO(WshAbzug abzug)
        {
            WshAbzug = abzug;

            //initialize list of WshAbzugDetailDTOs
            WshAbzugDetailDto = new ObservableCollection<WshAbzugDetailDTO>();
            if (abzug.WshAbzugDetail != null)
            {
                abzug.WshAbzugDetail.ToList().ForEach(d => WshAbzugDetailDto.Add(new WshAbzugDetailDTO(d)));
            }

            WshAbzugDetailDto.CollectionChanged += WshAbzugDetailDto_CollectionChanged;
        }

        #endregion

        #region Properties

        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ChangeTrackingEnabled = true;
                    _changeTracker.State = WshAbzug.ChangeTracker.State;
                }

                //make sure, ChangeTrackingEnabled is set to true, as this may be reset to false after F6 (UndoChanges)
                _changeTracker.ChangeTrackingEnabled = true;

                return _changeTracker;
            }
            set { _changeTracker = value; }
        }

        public decimal? GblAbzugProzent
        {
            get { return _gblAbzugProzent; }
            set
            {
                if (_gblAbzugProzent == value)
                {
                    return;
                }

                _gblAbzugProzent = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => GblAbzugProzent);
            }
        }

        public decimal? GblAktuell
        {
            get { return _gblAktuell; }
            set
            {
                if (_gblAktuell == value)
                {
                    return;
                }

                _gblAktuell = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => GblAktuell);
            }
        }

        public bool HatNurGrauePositionen
        {
            get { return _hatNurGrauePositionen; }
            set
            {
                if (_hatNurGrauePositionen == value)
                {
                    return;
                }

                _hatNurGrauePositionen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => HatNurGrauePositionen);
            }
        }

        public decimal Saldo
        {
            get { return _saldo; }
            set
            {
                if (_saldo == value)
                {
                    return;
                }

                _saldo = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Saldo);
            }
        }

        public DateTime? VoraussichtlicheDauer
        {
            get { return _voraussichtlicheDauer; }
            set
            {
                if (_voraussichtlicheDauer == value)
                {
                    return;
                }

                _voraussichtlicheDauer = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VoraussichtlicheDauer);
                NotifyPropertyChanged.RaisePropertyChanged(() => VoraussichtlicheDauerText);
            }
        }

        /// <summary>
        /// StringFormat im Binding für KissLabel Content scheint nicht zu funktionieren. 
        /// Müsste wohl eine TextBox sein.        
        /// </summary>
        public string VoraussichtlicheDauerText
        {
            get
            {
                if (!_voraussichtlicheDauer.HasValue)
                {
                    return "";
                }
                string text = string.Format("{0:MMM yyyy}", VoraussichtlicheDauer);
                return text;
            }
        }

        public WshAbzug WshAbzug
        {
            get { return _wshAbzug; }
            set
            {
                if (_wshAbzug == value)
                {
                    return;
                }

                _wshAbzug = value;

                WshAbzug.PropertyChanged += WshAbzug_PropertyChanged;
                WshAbzug.WshGrundbudgetPosition.PropertyChanged += WshGrundbudgetPosition_PropertyChanged;

                NotifyPropertyChanged.RaisePropertyChanged(() => WshAbzug);
            }
        }

        public ObservableCollection<WshAbzugDetailDTO> WshAbzugDetailDto
        {
            get; private set;
        }

        public ObservableCollection<WshPositionAbzugDTO> WshPosition
        {
            get { return _wshPosition; }
            set
            {
                if (_wshPosition == value)
                {
                    return;
                }

                _wshPosition = value;

                foreach (var position in WshPosition)
                {
                    //ObjectCloner geht über Properties. Beim setzen ergibt das eine NullReference-Exception.
                    if (position.WshPosition != null)
                    {
                        position.WshPosition.PropertyChanged += WshPosition_PropertyChanged;
                    }
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => WshPosition);
            }
        }

        #endregion

        #region EventHandlers

        private void WshAbzugDetailDto_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (WshAbzugDetailDTO newItem in e.NewItems)
                    {
                        _wshAbzug.WshAbzugDetail.Add(newItem.WshAbzugDetail);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (WshAbzugDetailDTO oldItem in e.OldItems)
                    {
                        _wshAbzug.WshAbzugDetail.Remove(oldItem.WshAbzugDetail);
                    }
                    break;
            }
        }

        private void WshAbzug_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // TODO AddPropertyMapping from EntityBase to PropertyMapping
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WshAbzug) + "." + e.PropertyName);

            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = WshAbzug.ChangeTracker.State;
            }
        }

        private void WshGrundbudgetPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WshAbzug) + "." + PropertyName.GetPropertyName(() => WshAbzug.WshGrundbudgetPosition) + "." + e.PropertyName);

            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = WshAbzug.WshGrundbudgetPosition.ChangeTracker.State;
            }
        }

        private void WshPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WshPosition) + "." + e.PropertyName);
        }

        #endregion
    }
}