using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Fa
{
    [DataContract(IsReference = true)]
    public class FaDokumentAblageDTO : Bindable, IAutoIdentityEntity<int>, IEntityWrapper<FaDokumentAblage>
    {
        [DataMember]
        private string _adressatName;

        [DataMember]
        private string _autorNameVorname;

        [DataMember]
        private int _baPersonIDFall;

        [DataMember]
        private string _betroffenePersonenNameVorname;

        [DataMember]
        private DateTime? _datumDokument;

        [DataMember]
        private string _falltraegerNameVorname;

        [DataMember]
        private IList<int> _faThemaCodeListe;

        [DataMember]
        private bool _istAktiverFall;

        [DataMember]
        private FaDokumentAblage _wrappedEntity;

        public FaDokumentAblageDTO(FaDokumentAblage entity)
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

        public string AutorNameVorname
        {
            get { return _autorNameVorname; }
            set { SetProperty(ref _autorNameVorname, value, () => AutorNameVorname); }
        }

        public int BaPersonIDFall
        {
            get { return _baPersonIDFall; }
            set { SetProperty(ref _baPersonIDFall, value, () => BaPersonIDFall); }
        }

        public string BetroffenePersonenNameVorname
        {
            get { return _betroffenePersonenNameVorname; }
            set { SetProperty(ref _betroffenePersonenNameVorname, value, () => BetroffenePersonenNameVorname); }
        }

        public DateTime? DatumDokument
        {
            get { return _datumDokument; }
            set { SetProperty(ref _datumDokument, value, () => DatumDokument); }
        }

        public string FalltraegerNameVorname
        {
            get { return _falltraegerNameVorname; }
            set { SetProperty(ref _falltraegerNameVorname, value, () => FalltraegerNameVorname); }
        }

        public IList<int> FaThemaCodeListe
        {
            get { return _faThemaCodeListe; }
            set
            {
                SetProperty(ref _faThemaCodeListe, value, () => FaThemaCodeListe);
                _wrappedEntity.FaThemaDokAblageCodes = _faThemaCodeListe.Count == 0 ? null : string.Join(",", _faThemaCodeListe);
            }
        }

        public bool IstAktiverFall
        {
            get { return _istAktiverFall; }
            set { SetProperty(ref _istAktiverFall, value, () => IstAktiverFall); }
        }

        public FaDokumentAblage WrappedEntity
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