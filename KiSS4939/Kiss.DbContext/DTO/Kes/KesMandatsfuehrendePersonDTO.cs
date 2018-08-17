using System.ComponentModel;
using System.Runtime.Serialization;

using Kiss.DbContext.Properties;
using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    [DataContract(IsReference = true)]
    public class KesMandatsfuehrendePersonDTO : Bindable, IAutoIdentityEntity<int>, IEntityWrapper<KesMandatsfuehrendePerson>, ILogischesLoeschenEntity
    {
        [DataMember]
        private FachpersonOrMandatstraeger _fachpersonOrMandatstraeger;

        [DataMember]
        private KesMandatsfuehrendePerson _wrappedEntity;

        public KesMandatsfuehrendePersonDTO(KesMandatsfuehrendePerson entity)
        {
            WrappedEntity = entity;
            WrappedEntity.PropertyChanged += WrappedEntity_PropertyChanged;
        }

        public int AutoIdentityID
        {
            get { return WrappedEntity.AutoIdentityID; }
        }

        public bool IsDeleted
        {
            get { return WrappedEntity.IsDeleted; }
            set { WrappedEntity.IsDeleted = value; }
        }

        public FachpersonOrMandatstraeger SelectedFachpersonOrUser
        {
            get
            {
                return _fachpersonOrMandatstraeger;
            }
            set
            {
                if (_fachpersonOrMandatstraeger == value)
                {
                    return;
                }

                _fachpersonOrMandatstraeger = value;

                if (WrappedEntity != null && value != null)
                {
                    if (value.Mandatstraeger != null)
                    {
                        WrappedEntity.XUser = value.Mandatstraeger;
                    }
                    else
                    {
                        WrappedEntity.UserID = null;
                    }

                    if (value.Fachperson != null)
                    {
                        WrappedEntity.BaInstitution = value.Fachperson;
                    }
                    else
                    {
                        WrappedEntity.BaInstitutionID = null;
                    }

                    NotifyPropertyChanged.RaisePropertyChanged(() => SelectedFachpersonOrUser);
                }
            }
        }

        public KesMandatsfuehrendePerson WrappedEntity
        {
            get { return _wrappedEntity; }
            private set { SetProperty(ref _wrappedEntity, value, () => WrappedEntity); }
        }

        private void WrappedEntity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WrappedEntity) + "." + e.PropertyName);
        }

        [DataContract(IsReference = true)]
        public class FachpersonOrMandatstraeger
        {
            [DataMember]
            private BaInstitution _fachperson;

            [DataMember]
            private XUser _mandatstraeger;

            public FachpersonOrMandatstraeger(XUser mandatstraeger)
                : this(mandatstraeger, null)
            { }

            public FachpersonOrMandatstraeger(BaInstitution fachperson)
                : this(null, fachperson)
            { }

            public FachpersonOrMandatstraeger(XUser mandatstraeger, BaInstitution fachperson)
            {
                Mandatstraeger = mandatstraeger;
                Fachperson = fachperson;
            }

            public BaInstitution Fachperson
            {
                get { return _fachperson; }
                set { _fachperson = value; }
            }

            public string LastNameFirstName
            {
                get
                {
                    if (Mandatstraeger != null)
                    {
                        return Mandatstraeger.LastNameFirstName;
                    }

                    if (Fachperson != null)
                    {
                        return Fachperson.NameVorname;
                    }

                    return null;
                }
            }

            public XUser Mandatstraeger
            {
                get { return _mandatstraeger; }
                set { _mandatstraeger = value; }
            }

            public string Typ
            {
                get
                {
                    if (Mandatstraeger != null)
                    {
                        return Resources.KesMandatstraeger;
                    }

                    if (Fachperson != null)
                    {
                        return Resources.KesFachperson;
                    }

                    return null;
                }
            }
        }
    }
}