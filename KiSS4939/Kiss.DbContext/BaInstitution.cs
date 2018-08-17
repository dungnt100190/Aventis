//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kiss.DbContext
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(BaAdresse))]
    [KnownType(typeof(BaPerson))]
    [KnownType(typeof(BaZahlungsweg))]
    [KnownType(typeof(FaDokumente))]
    [KnownType(typeof(XOrgUnit))]
    [KnownType(typeof(BaGesundheit))]
    [KnownType(typeof(FaDokumentAblage))]
    [KnownType(typeof(BaPerson_BaInstitution))]
    [KnownType(typeof(KesDokument))]
    [KnownType(typeof(KesVerlauf))]
    [KnownType(typeof(KesPflegekinderaufsicht))]
    [KnownType(typeof(KesMandatsfuehrendePerson))]
    [KnownType(typeof(KesMassnahme))]
    public partial class BaInstitution : PocoEntity, IAutoIdentityEntity<int>
    {
        public BaInstitution()
        {
            this.BaAdresse = new HashSet<BaAdresse>();
            this.BaAdresse1 = new HashSet<BaAdresse>();
            this.BaPerson = new HashSet<BaPerson>();
            this.BaZahlungsweg = new HashSet<BaZahlungsweg>();
            this.FaDokumente = new HashSet<FaDokumente>();
            this.BaGesundheit_IsZahnarztOf = new HashSet<BaGesundheit>();
            this.BaGesundheit_IsKvgOf = new HashSet<BaGesundheit>();
            this.BaGesundheit_IsVvgOf = new HashSet<BaGesundheit>();
            this.FaDokumentAblage = new HashSet<FaDokumentAblage>();
            this.BaPerson_BaInstitution = new HashSet<BaPerson_BaInstitution>();
            this.KesDokument = new HashSet<KesDokument>();
            this.KesVerlauf = new HashSet<KesVerlauf>();
            this.KesPflegekinderaufsicht = new HashSet<KesPflegekinderaufsicht>();
            this.KesMandatsfuehrendePerson = new HashSet<KesMandatsfuehrendePerson>();
            this.KesMassnahme = new HashSet<KesMassnahme>();
        }
    
        public int AutoIdentityID 
        {
            get{ return BaInstitutionID; } 
        }
    
        [DataMember]
        private int _baInstitutionID;
        public int BaInstitutionID
        {
            get { return _baInstitutionID; }
            set
            {
                if (_baInstitutionID != value)
                {
                    _baInstitutionID = value;
                    RaisePropertyChanged("BaInstitutionID");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _orgUnitID;
        public Nullable<int> OrgUnitID
        {
            get { return _orgUnitID; }
            set
            {
                if (_orgUnitID != value)
                {
                    _orgUnitID = value;
                    RaisePropertyChanged("OrgUnitID");
                    if (XOrgUnit != null && XOrgUnit.OrgUnitID != value)
                    {
                        XOrgUnit = null;
                    }
                }
            }
        }
    
        [DataMember]
        private string _institutionNr;
        public string InstitutionNr
        {
            get { return _institutionNr; }
            set
            {
                if (_institutionNr != value)
                {
                    _institutionNr = value;
                    RaisePropertyChanged("InstitutionNr");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _baInstitutionArtCode;
        public Nullable<int> BaInstitutionArtCode
        {
            get { return _baInstitutionArtCode; }
            set
            {
                if (_baInstitutionArtCode != value)
                {
                    _baInstitutionArtCode = value;
                    RaisePropertyChanged("BaInstitutionArtCode");
                }
            }
        }
    
        [DataMember]
        private bool _aktiv;
        public bool Aktiv
        {
            get { return _aktiv; }
            set
            {
                if (_aktiv != value)
                {
                    _aktiv = value;
                    RaisePropertyChanged("Aktiv");
                }
            }
        }
    
        [DataMember]
        private bool _debitor;
        public bool Debitor
        {
            get { return _debitor; }
            set
            {
                if (_debitor != value)
                {
                    _debitor = value;
                    RaisePropertyChanged("Debitor");
                }
            }
        }
    
        [DataMember]
        private bool _kreditor;
        public bool Kreditor
        {
            get { return _kreditor; }
            set
            {
                if (_kreditor != value)
                {
                    _kreditor = value;
                    RaisePropertyChanged("Kreditor");
                }
            }
        }
    
        [DataMember]
        private bool _keinSerienbrief;
        public bool KeinSerienbrief
        {
            get { return _keinSerienbrief; }
            set
            {
                if (_keinSerienbrief != value)
                {
                    _keinSerienbrief = value;
                    RaisePropertyChanged("KeinSerienbrief");
                }
            }
        }
    
        [DataMember]
        private bool _manuelleAnrede;
        public bool ManuelleAnrede
        {
            get { return _manuelleAnrede; }
            set
            {
                if (_manuelleAnrede != value)
                {
                    _manuelleAnrede = value;
                    RaisePropertyChanged("ManuelleAnrede");
                }
            }
        }
    
        [DataMember]
        private string _anrede;
        public string Anrede
        {
            get { return _anrede; }
            set
            {
                if (_anrede != value)
                {
                    _anrede = value;
                    RaisePropertyChanged("Anrede");
                }
            }
        }
    
        [DataMember]
        private string _briefanrede;
        public string Briefanrede
        {
            get { return _briefanrede; }
            set
            {
                if (_briefanrede != value)
                {
                    _briefanrede = value;
                    RaisePropertyChanged("Briefanrede");
                }
            }
        }
    
        [DataMember]
        private string _titel;
        public string Titel
        {
            get { return _titel; }
            set
            {
                if (_titel != value)
                {
                    _titel = value;
                    RaisePropertyChanged("Titel");
                }
            }
        }
    
        [DataMember]
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
    
        [DataMember]
        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set
            {
                if (_vorname != value)
                {
                    _vorname = value;
                    RaisePropertyChanged("Vorname");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _geschlechtCode;
        public Nullable<int> GeschlechtCode
        {
            get { return _geschlechtCode; }
            set
            {
                if (_geschlechtCode != value)
                {
                    _geschlechtCode = value;
                    RaisePropertyChanged("GeschlechtCode");
                }
            }
        }
    
        [DataMember]
        private string _telefon;
        public string Telefon
        {
            get { return _telefon; }
            set
            {
                if (_telefon != value)
                {
                    _telefon = value;
                    RaisePropertyChanged("Telefon");
                }
            }
        }
    
        [DataMember]
        private string _telefon2;
        public string Telefon2
        {
            get { return _telefon2; }
            set
            {
                if (_telefon2 != value)
                {
                    _telefon2 = value;
                    RaisePropertyChanged("Telefon2");
                }
            }
        }
    
        [DataMember]
        private string _telefon3;
        public string Telefon3
        {
            get { return _telefon3; }
            set
            {
                if (_telefon3 != value)
                {
                    _telefon3 = value;
                    RaisePropertyChanged("Telefon3");
                }
            }
        }
    
        [DataMember]
        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set
            {
                if (_fax != value)
                {
                    _fax = value;
                    RaisePropertyChanged("Fax");
                }
            }
        }
    
        [DataMember]
        private string _eMail;
        public string EMail
        {
            get { return _eMail; }
            set
            {
                if (_eMail != value)
                {
                    _eMail = value;
                    RaisePropertyChanged("EMail");
                }
            }
        }
    
        [DataMember]
        private string _homepage;
        public string Homepage
        {
            get { return _homepage; }
            set
            {
                if (_homepage != value)
                {
                    _homepage = value;
                    RaisePropertyChanged("Homepage");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _sprachCode;
        public Nullable<int> SprachCode
        {
            get { return _sprachCode; }
            set
            {
                if (_sprachCode != value)
                {
                    _sprachCode = value;
                    RaisePropertyChanged("SprachCode");
                }
            }
        }
    
        [DataMember]
        private string _bemerkung;
        public string Bemerkung
        {
            get { return _bemerkung; }
            set
            {
                if (_bemerkung != value)
                {
                    _bemerkung = value;
                    RaisePropertyChanged("Bemerkung");
                }
            }
        }
    
        [DataMember]
        private string _creator;
        public string Creator
        {
            get { return _creator; }
            set
            {
                if (_creator != value)
                {
                    _creator = value;
                    RaisePropertyChanged("Creator");
                }
            }
        }
    
        [DataMember]
        private System.DateTime _created;
        public System.DateTime Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    RaisePropertyChanged("Created");
                }
            }
        }
    
        [DataMember]
        private string _modifier;
        public string Modifier
        {
            get { return _modifier; }
            set
            {
                if (_modifier != value)
                {
                    _modifier = value;
                    RaisePropertyChanged("Modifier");
                }
            }
        }
    
        [DataMember]
        private System.DateTime _modified;
        public System.DateTime Modified
        {
            get { return _modified; }
            set
            {
                if (_modified != value)
                {
                    _modified = value;
                    RaisePropertyChanged("Modified");
                }
            }
        }
    
        [DataMember]
        private byte[] _baInstitutionTS;
        public byte[] BaInstitutionTS
        {
            get { return _baInstitutionTS; }
            set
            {
                if (_baInstitutionTS != value)
                {
                    _baInstitutionTS = value;
                    RaisePropertyChanged("BaInstitutionTS");
                }
            }
        }
    
        [DataMember]
        private string _institutionName;
        public string InstitutionName
        {
            get { return _institutionName; }
            set
            {
                if (_institutionName != value)
                {
                    _institutionName = value;
                    RaisePropertyChanged("InstitutionName");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _institutionTypCode;
        public Nullable<int> InstitutionTypCode
        {
            get { return _institutionTypCode; }
            set
            {
                if (_institutionTypCode != value)
                {
                    _institutionTypCode = value;
                    RaisePropertyChanged("InstitutionTypCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _baFreigabeStatusCode;
        public Nullable<int> BaFreigabeStatusCode
        {
            get { return _baFreigabeStatusCode; }
            set
            {
                if (_baFreigabeStatusCode != value)
                {
                    _baFreigabeStatusCode = value;
                    RaisePropertyChanged("BaFreigabeStatusCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _definitivUserID;
        public Nullable<int> DefinitivUserID
        {
            get { return _definitivUserID; }
            set
            {
                if (_definitivUserID != value)
                {
                    _definitivUserID = value;
                    RaisePropertyChanged("DefinitivUserID");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _definitivDatum;
        public Nullable<System.DateTime> DefinitivDatum
        {
            get { return _definitivDatum; }
            set
            {
                if (_definitivDatum != value)
                {
                    _definitivDatum = value;
                    RaisePropertyChanged("DefinitivDatum");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _erstelltUserID;
        public Nullable<int> ErstelltUserID
        {
            get { return _erstelltUserID; }
            set
            {
                if (_erstelltUserID != value)
                {
                    _erstelltUserID = value;
                    RaisePropertyChanged("ErstelltUserID");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _erstelltDatum;
        public Nullable<System.DateTime> ErstelltDatum
        {
            get { return _erstelltDatum; }
            set
            {
                if (_erstelltDatum != value)
                {
                    _erstelltDatum = value;
                    RaisePropertyChanged("ErstelltDatum");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _mutiertUserID;
        public Nullable<int> MutiertUserID
        {
            get { return _mutiertUserID; }
            set
            {
                if (_mutiertUserID != value)
                {
                    _mutiertUserID = value;
                    RaisePropertyChanged("MutiertUserID");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _mutiertDatum;
        public Nullable<System.DateTime> MutiertDatum
        {
            get { return _mutiertDatum; }
            set
            {
                if (_mutiertDatum != value)
                {
                    _mutiertDatum = value;
                    RaisePropertyChanged("MutiertDatum");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _geburtsdatum;
        public Nullable<System.DateTime> Geburtsdatum
        {
            get { return _geburtsdatum; }
            set
            {
                if (_geburtsdatum != value)
                {
                    _geburtsdatum = value;
                    RaisePropertyChanged("Geburtsdatum");
                }
            }
        }
    
        [DataMember]
        private string _versichertennummer;
        public string Versichertennummer
        {
            get { return _versichertennummer; }
            set
            {
                if (_versichertennummer != value)
                {
                    _versichertennummer = value;
                    RaisePropertyChanged("Versichertennummer");
                }
            }
        }
    
    
        [DataMember]
        private ICollection<BaAdresse> _baAdresse;
        public virtual ICollection<BaAdresse> BaAdresse
        {
            get { return _baAdresse; }
            set
            {
                if (_baAdresse != value)
                {
                    _baAdresse = value;
                    RaisePropertyChanged("BaAdresse");
                }
            }
        }
        [DataMember]
        private ICollection<BaAdresse> _baAdresse1;
        public virtual ICollection<BaAdresse> BaAdresse1
        {
            get { return _baAdresse1; }
            set
            {
                if (_baAdresse1 != value)
                {
                    _baAdresse1 = value;
                    RaisePropertyChanged("BaAdresse1");
                }
            }
        }
        [DataMember]
        private ICollection<BaPerson> _baPerson;
        public virtual ICollection<BaPerson> BaPerson
        {
            get { return _baPerson; }
            set
            {
                if (_baPerson != value)
                {
                    _baPerson = value;
                    RaisePropertyChanged("BaPerson");
                }
            }
        }
        [DataMember]
        private ICollection<BaZahlungsweg> _baZahlungsweg;
        public virtual ICollection<BaZahlungsweg> BaZahlungsweg
        {
            get { return _baZahlungsweg; }
            set
            {
                if (_baZahlungsweg != value)
                {
                    _baZahlungsweg = value;
                    RaisePropertyChanged("BaZahlungsweg");
                }
            }
        }
        [DataMember]
        private ICollection<FaDokumente> _faDokumente;
        public virtual ICollection<FaDokumente> FaDokumente
        {
            get { return _faDokumente; }
            set
            {
                if (_faDokumente != value)
                {
                    _faDokumente = value;
                    RaisePropertyChanged("FaDokumente");
                }
            }
        }
        [DataMember]
        private XOrgUnit _xOrgUnit;
        public virtual XOrgUnit XOrgUnit
        {
            get { return _xOrgUnit; }
            set
            {
                if (_xOrgUnit != value)
                {
                    _xOrgUnit = value;
                    RaisePropertyChanged("XOrgUnit");
    
                    if (value != null)
                    {
                        OrgUnitID = value.OrgUnitID;
                    }
                }
            }
        }
        [DataMember]
        private ICollection<BaGesundheit> _baGesundheit_IsZahnarztOf;
        public virtual ICollection<BaGesundheit> BaGesundheit_IsZahnarztOf
        {
            get { return _baGesundheit_IsZahnarztOf; }
            set
            {
                if (_baGesundheit_IsZahnarztOf != value)
                {
                    _baGesundheit_IsZahnarztOf = value;
                    RaisePropertyChanged("BaGesundheit_IsZahnarztOf");
                }
            }
        }
        [DataMember]
        private ICollection<BaGesundheit> _baGesundheit_IsKvgOf;
        public virtual ICollection<BaGesundheit> BaGesundheit_IsKvgOf
        {
            get { return _baGesundheit_IsKvgOf; }
            set
            {
                if (_baGesundheit_IsKvgOf != value)
                {
                    _baGesundheit_IsKvgOf = value;
                    RaisePropertyChanged("BaGesundheit_IsKvgOf");
                }
            }
        }
        [DataMember]
        private ICollection<BaGesundheit> _baGesundheit_IsVvgOf;
        public virtual ICollection<BaGesundheit> BaGesundheit_IsVvgOf
        {
            get { return _baGesundheit_IsVvgOf; }
            set
            {
                if (_baGesundheit_IsVvgOf != value)
                {
                    _baGesundheit_IsVvgOf = value;
                    RaisePropertyChanged("BaGesundheit_IsVvgOf");
                }
            }
        }
        [DataMember]
        private ICollection<FaDokumentAblage> _faDokumentAblage;
        public virtual ICollection<FaDokumentAblage> FaDokumentAblage
        {
            get { return _faDokumentAblage; }
            set
            {
                if (_faDokumentAblage != value)
                {
                    _faDokumentAblage = value;
                    RaisePropertyChanged("FaDokumentAblage");
                }
            }
        }
        [DataMember]
        private ICollection<BaPerson_BaInstitution> _baPerson_BaInstitution;
        public virtual ICollection<BaPerson_BaInstitution> BaPerson_BaInstitution
        {
            get { return _baPerson_BaInstitution; }
            set
            {
                if (_baPerson_BaInstitution != value)
                {
                    _baPerson_BaInstitution = value;
                    RaisePropertyChanged("BaPerson_BaInstitution");
                }
            }
        }
        [DataMember]
        private ICollection<KesDokument> _kesDokument;
        public virtual ICollection<KesDokument> KesDokument
        {
            get { return _kesDokument; }
            set
            {
                if (_kesDokument != value)
                {
                    _kesDokument = value;
                    RaisePropertyChanged("KesDokument");
                }
            }
        }
        [DataMember]
        private ICollection<KesVerlauf> _kesVerlauf;
        public virtual ICollection<KesVerlauf> KesVerlauf
        {
            get { return _kesVerlauf; }
            set
            {
                if (_kesVerlauf != value)
                {
                    _kesVerlauf = value;
                    RaisePropertyChanged("KesVerlauf");
                }
            }
        }
        [DataMember]
        private ICollection<KesPflegekinderaufsicht> _kesPflegekinderaufsicht;
        public virtual ICollection<KesPflegekinderaufsicht> KesPflegekinderaufsicht
        {
            get { return _kesPflegekinderaufsicht; }
            set
            {
                if (_kesPflegekinderaufsicht != value)
                {
                    _kesPflegekinderaufsicht = value;
                    RaisePropertyChanged("KesPflegekinderaufsicht");
                }
            }
        }
        [DataMember]
        private ICollection<KesMandatsfuehrendePerson> _kesMandatsfuehrendePerson;
        public virtual ICollection<KesMandatsfuehrendePerson> KesMandatsfuehrendePerson
        {
            get { return _kesMandatsfuehrendePerson; }
            set
            {
                if (_kesMandatsfuehrendePerson != value)
                {
                    _kesMandatsfuehrendePerson = value;
                    RaisePropertyChanged("KesMandatsfuehrendePerson");
                }
            }
        }
        [DataMember]
        private ICollection<KesMassnahme> _kesMassnahme;
        public virtual ICollection<KesMassnahme> KesMassnahme
        {
            get { return _kesMassnahme; }
            set
            {
                if (_kesMassnahme != value)
                {
                    _kesMassnahme = value;
                    RaisePropertyChanged("KesMassnahme");
                }
            }
        }
    }
    
}
