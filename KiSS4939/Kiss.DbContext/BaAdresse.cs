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
    [KnownType(typeof(BaPerson))]
    [KnownType(typeof(BaInstitution))]
    [KnownType(typeof(BaLand))]
    [KnownType(typeof(XUser))]
    public partial class BaAdresse : PocoEntity, IAutoIdentityEntity<int>, IAuditableEntity
    {
        public int AutoIdentityID 
        {
            get{ return BaAdresseID; } 
        }
    
        [DataMember]
        private int _baAdresseID;
        public int BaAdresseID
        {
            get { return _baAdresseID; }
            set
            {
                if (_baAdresseID != value)
                {
                    _baAdresseID = value;
                    RaisePropertyChanged("BaAdresseID");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _baPersonID;
        public Nullable<int> BaPersonID
        {
            get { return _baPersonID; }
            set
            {
                if (_baPersonID != value)
                {
                    _baPersonID = value;
                    RaisePropertyChanged("BaPersonID");
                    if (BaPerson != null && BaPerson.BaPersonID != value)
                    {
                        BaPerson = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _baInstitutionID;
        public Nullable<int> BaInstitutionID
        {
            get { return _baInstitutionID; }
            set
            {
                if (_baInstitutionID != value)
                {
                    _baInstitutionID = value;
                    RaisePropertyChanged("BaInstitutionID");
                    if (BaInstitution != null && BaInstitution.BaInstitutionID != value)
                    {
                        BaInstitution = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _platzierungInstID;
        public Nullable<int> PlatzierungInstID
        {
            get { return _platzierungInstID; }
            set
            {
                if (_platzierungInstID != value)
                {
                    _platzierungInstID = value;
                    RaisePropertyChanged("PlatzierungInstID");
                    if (BaInstitution1 != null && BaInstitution1.BaInstitutionID != value)
                    {
                        BaInstitution1 = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _vmMandantID;
        public Nullable<int> VmMandantID
        {
            get { return _vmMandantID; }
            set
            {
                if (_vmMandantID != value)
                {
                    _vmMandantID = value;
                    RaisePropertyChanged("VmMandantID");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _vmPriMaID;
        public Nullable<int> VmPriMaID
        {
            get { return _vmPriMaID; }
            set
            {
                if (_vmPriMaID != value)
                {
                    _vmPriMaID = value;
                    RaisePropertyChanged("VmPriMaID");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _kaBetriebID;
        public Nullable<int> KaBetriebID
        {
            get { return _kaBetriebID; }
            set
            {
                if (_kaBetriebID != value)
                {
                    _kaBetriebID = value;
                    RaisePropertyChanged("KaBetriebID");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _kaBetriebKontaktID;
        public Nullable<int> KaBetriebKontaktID
        {
            get { return _kaBetriebKontaktID; }
            set
            {
                if (_kaBetriebKontaktID != value)
                {
                    _kaBetriebKontaktID = value;
                    RaisePropertyChanged("KaBetriebKontaktID");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _baLandID;
        public Nullable<int> BaLandID
        {
            get { return _baLandID; }
            set
            {
                if (_baLandID != value)
                {
                    _baLandID = value;
                    RaisePropertyChanged("BaLandID");
                    if (BaLand != null && BaLand.BaLandID != value)
                    {
                        BaLand = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _datumVon;
        public Nullable<System.DateTime> DatumVon
        {
            get { return _datumVon; }
            set
            {
                if (_datumVon != value)
                {
                    _datumVon = value;
                    RaisePropertyChanged("DatumVon");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _datumBis;
        public Nullable<System.DateTime> DatumBis
        {
            get { return _datumBis; }
            set
            {
                if (_datumBis != value)
                {
                    _datumBis = value;
                    RaisePropertyChanged("DatumBis");
                }
            }
        }
    
        [DataMember]
        private bool _gesperrt;
        public bool Gesperrt
        {
            get { return _gesperrt; }
            set
            {
                if (_gesperrt != value)
                {
                    _gesperrt = value;
                    RaisePropertyChanged("Gesperrt");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _adresseCode;
        public Nullable<int> AdresseCode
        {
            get { return _adresseCode; }
            set
            {
                if (_adresseCode != value)
                {
                    _adresseCode = value;
                    RaisePropertyChanged("AdresseCode");
                }
            }
        }
    
        [DataMember]
        private string _careOf;
        public string CareOf
        {
            get { return _careOf; }
            set
            {
                if (_careOf != value)
                {
                    _careOf = value;
                    RaisePropertyChanged("CareOf");
                }
            }
        }
    
        [DataMember]
        private string _zusatz;
        public string Zusatz
        {
            get { return _zusatz; }
            set
            {
                if (_zusatz != value)
                {
                    _zusatz = value;
                    RaisePropertyChanged("Zusatz");
                }
            }
        }
    
        [DataMember]
        private string _zuhandenVon;
        public string ZuhandenVon
        {
            get { return _zuhandenVon; }
            set
            {
                if (_zuhandenVon != value)
                {
                    _zuhandenVon = value;
                    RaisePropertyChanged("ZuhandenVon");
                }
            }
        }
    
        [DataMember]
        private string _strasse;
        public string Strasse
        {
            get { return _strasse; }
            set
            {
                if (_strasse != value)
                {
                    _strasse = value;
                    RaisePropertyChanged("Strasse");
                }
            }
        }
    
        [DataMember]
        private string _hausNr;
        public string HausNr
        {
            get { return _hausNr; }
            set
            {
                if (_hausNr != value)
                {
                    _hausNr = value;
                    RaisePropertyChanged("HausNr");
                }
            }
        }
    
        [DataMember]
        private string _postfach;
        public string Postfach
        {
            get { return _postfach; }
            set
            {
                if (_postfach != value)
                {
                    _postfach = value;
                    RaisePropertyChanged("Postfach");
                }
            }
        }
    
        [DataMember]
        private bool _postfachOhneNr;
        public bool PostfachOhneNr
        {
            get { return _postfachOhneNr; }
            set
            {
                if (_postfachOhneNr != value)
                {
                    _postfachOhneNr = value;
                    RaisePropertyChanged("PostfachOhneNr");
                }
            }
        }
    
        [DataMember]
        private string _pLZ;
        public string PLZ
        {
            get { return _pLZ; }
            set
            {
                if (_pLZ != value)
                {
                    _pLZ = value;
                    RaisePropertyChanged("PLZ");
                }
            }
        }
    
        [DataMember]
        private string _ort;
        public string Ort
        {
            get { return _ort; }
            set
            {
                if (_ort != value)
                {
                    _ort = value;
                    RaisePropertyChanged("Ort");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _ortschaftCode;
        public Nullable<int> OrtschaftCode
        {
            get { return _ortschaftCode; }
            set
            {
                if (_ortschaftCode != value)
                {
                    _ortschaftCode = value;
                    RaisePropertyChanged("OrtschaftCode");
                }
            }
        }
    
        [DataMember]
        private string _kanton;
        public string Kanton
        {
            get { return _kanton; }
            set
            {
                if (_kanton != value)
                {
                    _kanton = value;
                    RaisePropertyChanged("Kanton");
                }
            }
        }
    
        [DataMember]
        private string _bezirk;
        public string Bezirk
        {
            get { return _bezirk; }
            set
            {
                if (_bezirk != value)
                {
                    _bezirk = value;
                    RaisePropertyChanged("Bezirk");
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
        private Nullable<int> _platzierungsartCode;
        public Nullable<int> PlatzierungsartCode
        {
            get { return _platzierungsartCode; }
            set
            {
                if (_platzierungsartCode != value)
                {
                    _platzierungsartCode = value;
                    RaisePropertyChanged("PlatzierungsartCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _wohnStatusCode;
        public Nullable<int> WohnStatusCode
        {
            get { return _wohnStatusCode; }
            set
            {
                if (_wohnStatusCode != value)
                {
                    _wohnStatusCode = value;
                    RaisePropertyChanged("WohnStatusCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _wohnungsgroesseCode;
        public Nullable<int> WohnungsgroesseCode
        {
            get { return _wohnungsgroesseCode; }
            set
            {
                if (_wohnungsgroesseCode != value)
                {
                    _wohnungsgroesseCode = value;
                    RaisePropertyChanged("WohnungsgroesseCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _migrationKA;
        public Nullable<int> MigrationKA
        {
            get { return _migrationKA; }
            set
            {
                if (_migrationKA != value)
                {
                    _migrationKA = value;
                    RaisePropertyChanged("MigrationKA");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _verID;
        public Nullable<int> VerID
        {
            get { return _verID; }
            set
            {
                if (_verID != value)
                {
                    _verID = value;
                    RaisePropertyChanged("VerID");
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
        private byte[] _baAdresseTS;
        public byte[] BaAdresseTS
        {
            get { return _baAdresseTS; }
            set
            {
                if (_baAdresseTS != value)
                {
                    _baAdresseTS = value;
                    RaisePropertyChanged("BaAdresseTS");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _userID;
        public Nullable<int> UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    RaisePropertyChanged("UserID");
                    if (XUser != null && XUser.UserID != value)
                    {
                        XUser = null;
                    }
                }
            }
        }
    
        [DataMember]
        private bool _ausEinwohnerregister;
        public bool AusEinwohnerregister
        {
            get { return _ausEinwohnerregister; }
            set
            {
                if (_ausEinwohnerregister != value)
                {
                    _ausEinwohnerregister = value;
                    RaisePropertyChanged("AusEinwohnerregister");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _strasseCode;
        public Nullable<int> StrasseCode
        {
            get { return _strasseCode; }
            set
            {
                if (_strasseCode != value)
                {
                    _strasseCode = value;
                    RaisePropertyChanged("StrasseCode");
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
        private Nullable<int> _quartierCode;
        public Nullable<int> QuartierCode
        {
            get { return _quartierCode; }
            set
            {
                if (_quartierCode != value)
                {
                    _quartierCode = value;
                    RaisePropertyChanged("QuartierCode");
                }
            }
        }
    
    
        [DataMember]
        private BaPerson _baPerson;
        public virtual BaPerson BaPerson
        {
            get { return _baPerson; }
            set
            {
                if (_baPerson != value)
                {
                    _baPerson = value;
                    RaisePropertyChanged("BaPerson");
    
                    if (value != null)
                    {
                        BaPersonID = value.BaPersonID;
                    }
                }
            }
        }
        [DataMember]
        private BaInstitution _baInstitution;
        public virtual BaInstitution BaInstitution
        {
            get { return _baInstitution; }
            set
            {
                if (_baInstitution != value)
                {
                    _baInstitution = value;
                    RaisePropertyChanged("BaInstitution");
    
                    if (value != null)
                    {
                        BaInstitutionID = value.BaInstitutionID;
                    }
                }
            }
        }
        [DataMember]
        private BaInstitution _baInstitution1;
        public virtual BaInstitution BaInstitution1
        {
            get { return _baInstitution1; }
            set
            {
                if (_baInstitution1 != value)
                {
                    _baInstitution1 = value;
                    RaisePropertyChanged("BaInstitution1");
    
                    if (value != null)
                    {
                        PlatzierungInstID = value.BaInstitutionID;
                    }
                }
            }
        }
        [DataMember]
        private BaLand _baLand;
        public virtual BaLand BaLand
        {
            get { return _baLand; }
            set
            {
                if (_baLand != value)
                {
                    _baLand = value;
                    RaisePropertyChanged("BaLand");
    
                    if (value != null)
                    {
                        BaLandID = value.BaLandID;
                    }
                }
            }
        }
        [DataMember]
        private XUser _xUser;
        public virtual XUser XUser
        {
            get { return _xUser; }
            set
            {
                if (_xUser != value)
                {
                    _xUser = value;
                    RaisePropertyChanged("XUser");
    
                    if (value != null)
                    {
                        UserID = value.UserID;
                    }
                }
            }
        }
    }
    
}
