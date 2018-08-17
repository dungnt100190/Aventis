using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Utils;

namespace Kiss.Model.DTO.Vm
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(VmKlientenbudget))]
    [KnownType(typeof(VmPosition))]
    public class VmKlientenbudgetDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private ObservableCollection<VmPositionDTO> _fixeKosten;
        private bool _bearbeiten;
        private decimal _betragVerfuegbar;
        private ObjectChangeTracker _changeTracker;
        private ObservableCollection<VmPositionDTO> _einnahmen;
        private decimal _restbetrag;
        private ObservableCollection<VmPositionDTO> _variableKosten;
        private ObservableCollection<VmPositionDTO> _vermoegen;
        private decimal _vermoegenElBerechnung;
        private VmKlientenbudget _vmKlientenbudget;
        private decimal _vermoegenTotal;

        #endregion

        #endregion

        #region Properties

        [DataMember]
        public ObservableCollection<VmPositionDTO> FixeKosten
        {
            get { return _fixeKosten; }
            set
            {
                if (_fixeKosten == value)
                {
                    return;
                }

                SetPropertyChanged(_fixeKosten, false);

                _fixeKosten = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => FixeKosten);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFixeKostenEmpty);

                SetPropertyChanged(_fixeKosten, true);
            }
        }

        /// <summary>
        /// Gibt an, ob sich das DTO gerade im Bearbeiten-Modus befindet.
        /// </summary>
        [DataMember]
        public bool Bearbeiten
        {
            get { return _bearbeiten; }
            set
            {
                if (_bearbeiten == value)
                {
                    return;
                }

                _bearbeiten = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Bearbeiten);
            }
        }

        [DataMember]
        public decimal BetragVerfuegbar
        {
            get { return _betragVerfuegbar; }
            set
            {
                if (_betragVerfuegbar == value)
                {
                    return;
                }

                _betragVerfuegbar = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragVerfuegbar);
            }
        }

        /// <summary>
        /// Gibt an, ob das DTO editiert werden darf.
        /// </summary>
        public bool CanEdit
        {
            get
            {
                if (VmKlientenbudget == null)
                {
                    return false;
                }

                if (VmKlientenbudget.ChangeTracker.State == ObjectState.Added)
                {
                    return true;
                }

                int originalStatusCode;
                var statusFound = VmKlientenbudget.OriginalValues.TryGetValue(
                    PropertyName.GetPropertyName(() => VmKlientenbudget.VmKlientenbudgetStatusCode),
                    out originalStatusCode);
                byte[] timestamp;
                var tsFound = VmKlientenbudget.OriginalValues.TryGetValue(PropertyName.GetPropertyName(() => VmKlientenbudget.VmKlientenbudgetTS), out timestamp);

                if (!tsFound)
                {
                    timestamp = VmKlientenbudget.VmKlientenbudgetTS;
                }

                if (statusFound && VmKlientenbudget.VmKlientenbudgetTS == timestamp)
                {
                    return originalStatusCode == (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung;
                }

                return VmKlientenbudget.VmKlientenbudgetStatusEnum == LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung;
            }
        }

        /// <summary>
        /// Gibt an, ob der DTO-Status editiert werden darf.
        /// </summary>
        public bool CanEditStatus
        {
            get
            {
                if (VmKlientenbudget == null)
                {
                    return false;
                }

                if (VmKlientenbudget.ChangeTracker.State == ObjectState.Added)
                {
                    return true;
                }

                int originalStatusCode;
                var statusFound = VmKlientenbudget.OriginalValues.TryGetValue(
                    PropertyName.GetPropertyName(() => VmKlientenbudget.VmKlientenbudgetStatusCode),
                    out originalStatusCode);
                byte[] timestamp;
                var tsFound = VmKlientenbudget.OriginalValues.TryGetValue(PropertyName.GetPropertyName(() => VmKlientenbudget.VmKlientenbudgetTS), out timestamp);

                if (!tsFound)
                {
                    timestamp = VmKlientenbudget.VmKlientenbudgetTS;
                }

                if (statusFound && VmKlientenbudget.VmKlientenbudgetTS == timestamp)
                {
                    return originalStatusCode != (int)LOVsGenerated.VmKlientenbudgetStatus.Archiviert;
                }

                return VmKlientenbudget.VmKlientenbudgetStatusEnum != LOVsGenerated.VmKlientenbudgetStatus.Archiviert;
            }
        }

        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker
                                     {
                                         ChangeTrackingEnabled = true,
                                         State = VmKlientenbudget.ChangeTracker.State
                                     };
                }

                //make sure, ChangeTrackingEnabled is set to true, as this may be reset to false after F6 (UndoChanges)
                _changeTracker.ChangeTrackingEnabled = true;

                return _changeTracker;
            }
            set { _changeTracker = value; }
        }

        [DataMember]
        public ObservableCollection<VmPositionDTO> Einnahmen
        {
            get { return _einnahmen; }
            set
            {
                if (_einnahmen == value)
                {
                    return;
                }

                SetPropertyChanged(_einnahmen, false);

                _einnahmen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Einnahmen);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsEinnahmenEmpty);

                SetPropertyChanged(_einnahmen, true);
            }
        }

        public bool IsFixeKostenEmpty
        {
            get { return FixeKosten == null || FixeKosten.Count == 0; }
        }

        public bool IsEinnahmenEmpty
        {
            get { return Einnahmen == null || Einnahmen.Count == 0; }
        }

        public bool IsVariableKostenEmpty
        {
            get { return VariableKosten == null || VariableKosten.Count == 0; }
        }

        public bool IsVermoegenEmpty
        {
            get { return Vermoegen == null || Vermoegen.Count == 0; }
        }

        [DataMember]
        public decimal Restbetrag
        {
            get { return _restbetrag; }
            set
            {
                if (_restbetrag == value)
                {
                    return;
                }

                _restbetrag = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Restbetrag);
            }
        }

        [DataMember]
        public ObservableCollection<VmPositionDTO> VariableKosten
        {
            get { return _variableKosten; }
            set
            {
                if (_variableKosten == value)
                {
                    return;
                }

                SetPropertyChanged(_variableKosten, false);

                _variableKosten = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VariableKosten);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsVariableKostenEmpty);

                SetPropertyChanged(_variableKosten, true);
            }
        }

        [DataMember]
        public ObservableCollection<VmPositionDTO> Vermoegen
        {
            get { return _vermoegen; }
            set
            {
                if (_vermoegen == value)
                {
                    return;
                }

                SetPropertyChanged(_vermoegen, false);

                _vermoegen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Vermoegen);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsVermoegenEmpty);

                SetPropertyChanged(_vermoegen, true);
            }
        }

        [DataMember]
        public decimal VermoegenElBerechnung
        {
            get { return _vermoegenElBerechnung; }
            set
            {
                if (_vermoegenElBerechnung == value)
                {
                    return;
                }

                _vermoegenElBerechnung = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VermoegenElBerechnung);
            }
        }

        [DataMember]
        public decimal VermoegenTotal
        {
            get { return _vermoegenTotal; }
            set
            {
                if (_vermoegenTotal == value)
                {
                    return;
                }

                _vermoegenTotal = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VermoegenTotal);
            }
        }

        [DataMember]
        public VmKlientenbudget VmKlientenbudget
        {
            get { return _vmKlientenbudget; }
            set
            {
                if (_vmKlientenbudget == value)
                {
                    return;
                }

                if (_vmKlientenbudget != null)
                {
                    _vmKlientenbudget.PropertyChanged -= VmKlientenbudget_PropertyChanged;
                }

                _vmKlientenbudget = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VmKlientenbudget);

                if (_vmKlientenbudget != null)
                {
                    _vmKlientenbudget.PropertyChanged += VmKlientenbudget_PropertyChanged;
                }
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Wird für Binding im Grid benötigt.
        /// </summary>
        private void VmKlientenbudget_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => VmKlientenbudget) + "." + e.PropertyName);

            if (e.PropertyName == PropertyName.GetPropertyName(() => VmKlientenbudget.VmKlientenbudgetStatusCode) ||
                e.PropertyName == PropertyName.GetPropertyName(() => VmKlientenbudget.VmKlientenbudgetTS))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => CanEdit);
                NotifyPropertyChanged.RaisePropertyChanged(() => CanEditStatus);
            }

            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = VmKlientenbudget.ChangeTracker.State;
            }
        }

        private void position_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ((VmPositionDTO)sender).ChangeTracker.State;
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// PropertyChanged-Event auf einer Liste von Position setzen oder löschen
        /// </summary>
        /// <param name="positionen">Liste von Positionen</param>
        /// <param name="add">wenn <c>true</c> Event setzen. Wenn <c>false</c> Event löschen</param>
        private void SetPropertyChanged(IEnumerable<VmPositionDTO> positionen, bool add)
        {
            if (positionen == null)
            {
                return;
            }

            foreach (var position in positionen)
            {
                if (add)
                {
                    position.PropertyChanged += position_PropertyChanged;
                }
                else
                {
                    position.PropertyChanged -= position_PropertyChanged;
                }
            }
        }

        #endregion

        #endregion
    }
}