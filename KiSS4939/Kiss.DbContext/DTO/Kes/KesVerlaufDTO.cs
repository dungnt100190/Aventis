using System.ComponentModel;
using System.Runtime.Serialization;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    [DataContract(IsReference = true)]
    public class KesVerlaufDTO : Bindable, IAutoIdentityEntity<int>, IEntityWrapper<KesVerlauf>
    {
        [DataMember]
        private string _adressatName;

        [DataMember]
        private KesVerlauf _wrappedEntity;

        public KesVerlaufDTO(KesVerlauf entity)
        {
            WrappedEntity = entity;
            WrappedEntity.PropertyChanged += WrappedEntity_PropertyChanged;
        }

        public string AdressatName
        {
            get { return _adressatName; }
            set { SetProperty(ref _adressatName, value, () => AdressatName); }
        }

        public int AutoIdentityID
        {
            get { return WrappedEntity.AutoIdentityID; }
        }

        public KesVerlauf WrappedEntity
        {
            get { return _wrappedEntity; }
            private set { SetProperty(ref _wrappedEntity, value, () => WrappedEntity); }
        }

        private void WrappedEntity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WrappedEntity) + "." + e.PropertyName);
        }
    }
}