using System.ComponentModel;
using System.Runtime.Serialization;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Vm
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(VmKlientenbudget))]
    [KnownType(typeof(VmPosition))]
    public class VmPositionDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private bool _canDelete;
        private bool _canEdit;
        private bool _canEditBemerkung;
        private bool _canImport;
        private ObjectChangeTracker _changeTracker;
        private VmPosition _vmPosition;

        #endregion

        #endregion

        #region Properties

        [DataMember]
        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                if (_canDelete == value)
                {
                    return;
                }

                _canDelete = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => CanDelete);
            }
        }

        [DataMember]
        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                if (_canEdit == value)
                {
                    return;
                }

                _canEdit = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => CanEdit);
            }
        }

        [DataMember]
        public bool CanEditBemerkung
        {
            get { return _canEditBemerkung; }
            set
            {
                if (_canEditBemerkung == value)
                {
                    return;
                }

                _canEditBemerkung = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => CanEditBemerkung);
            }
        }

        [DataMember]
        public bool CanImport
        {
            get { return _canImport; }
            set
            {
                if (_canImport == value)
                {
                    return;
                }

                _canImport = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => CanImport);
            }
        }

        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = VmPosition.ChangeTracker;
                }

                //make sure, ChangeTrackingEnabled is set to true, as this may be reset to false after F6 (UndoChanges)
                _changeTracker.ChangeTrackingEnabled = true;

                return _changeTracker;
            }
            set { _changeTracker = value; }
        }

        [DataMember]
        public VmPosition VmPosition
        {
            get { return _vmPosition; }
            set
            {
                if (_vmPosition == value)
                {
                    return;
                }

                if (_vmPosition != null)
                {
                    _vmPosition.PropertyChanged -= VmPosition_PropertyChanged;
                }

                _vmPosition = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VmPosition);

                if (_vmPosition != null)
                {
                    _vmPosition.PropertyChanged += VmPosition_PropertyChanged;
                }
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Wird für Binding im Grid benötigt.
        /// </summary>
        private void VmPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => VmPosition) + "." + e.PropertyName);
        }

        #endregion
    }
}