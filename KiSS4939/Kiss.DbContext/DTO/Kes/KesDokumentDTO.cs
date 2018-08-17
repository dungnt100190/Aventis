using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    [DataContract(IsReference = true)]
    public class KesDokumentDTO : Bindable, IAutoIdentityEntity<int>, IEntityWrapper<KesDokument>, ILogischesLoeschenEntity
    {
        [DataMember]
        private string _adressatName;

        [DataMember]
        private DateTime? _datumDokument;

        [DataMember]
        private bool _selektion;

        [DataMember]
        private KesDokument _wrappedEntity;

        public KesDokumentDTO(KesDokument entity)
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

        public DateTime? DatumDokument
        {
            get { return _datumDokument; }
            set { SetProperty(ref _datumDokument, value, () => DatumDokument); }
        }

        public bool IsDeleted
        {
            get { return WrappedEntity.IsDeleted; }
            set { WrappedEntity.IsDeleted = value; }
        }

        public bool Selektion
        {
            get { return _selektion; }
            set { SetProperty(ref _selektion, value, () => Selektion); }
        }

        public KesDokument WrappedEntity
        {
            get { return _wrappedEntity; }
            private set { SetProperty(ref _wrappedEntity, value, () => WrappedEntity); }
        }

        private void WrappedEntity_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WrappedEntity) + "." + e.PropertyName);
        }
    }
}