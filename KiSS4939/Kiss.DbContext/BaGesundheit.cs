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
    [KnownType(typeof(BaInstitution))]
    [KnownType(typeof(BaPerson))]
    public partial class BaGesundheit : PocoEntity, IAutoIdentityEntity<int>
    {
        public int AutoIdentityID 
        {
            get{ return BaGesundheitID; } 
        }
    
        [DataMember]
        private int _baGesundheitID;
        public int BaGesundheitID
        {
            get { return _baGesundheitID; }
            set
            {
                if (_baGesundheitID != value)
                {
                    _baGesundheitID = value;
                    RaisePropertyChanged("BaGesundheitID");
                }
            }
        }
    
        [DataMember]
        private int _baPersonID;
        public int BaPersonID
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
        private int _jahr;
        public int Jahr
        {
            get { return _jahr; }
            set
            {
                if (_jahr != value)
                {
                    _jahr = value;
                    RaisePropertyChanged("Jahr");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _kVGOrganisationID;
        public Nullable<int> KVGOrganisationID
        {
            get { return _kVGOrganisationID; }
            set
            {
                if (_kVGOrganisationID != value)
                {
                    _kVGOrganisationID = value;
                    RaisePropertyChanged("KVGOrganisationID");
                    if (BaInstitution_Kvg != null && BaInstitution_Kvg.BaInstitutionID != value)
                    {
                        BaInstitution_Kvg = null;
                    }
                }
            }
        }
    
        [DataMember]
        private string _kVGKontaktPerson;
        public string KVGKontaktPerson
        {
            get { return _kVGKontaktPerson; }
            set
            {
                if (_kVGKontaktPerson != value)
                {
                    _kVGKontaktPerson = value;
                    RaisePropertyChanged("KVGKontaktPerson");
                }
            }
        }
    
        [DataMember]
        private string _kVGKontaktTelefon;
        public string KVGKontaktTelefon
        {
            get { return _kVGKontaktTelefon; }
            set
            {
                if (_kVGKontaktTelefon != value)
                {
                    _kVGKontaktTelefon = value;
                    RaisePropertyChanged("KVGKontaktTelefon");
                }
            }
        }
    
        [DataMember]
        private string _kVGMitgliedNr;
        public string KVGMitgliedNr
        {
            get { return _kVGMitgliedNr; }
            set
            {
                if (_kVGMitgliedNr != value)
                {
                    _kVGMitgliedNr = value;
                    RaisePropertyChanged("KVGMitgliedNr");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _kVGVersichertSeit;
        public Nullable<System.DateTime> KVGVersichertSeit
        {
            get { return _kVGVersichertSeit; }
            set
            {
                if (_kVGVersichertSeit != value)
                {
                    _kVGVersichertSeit = value;
                    RaisePropertyChanged("KVGVersichertSeit");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _kVGGrundPraemie;
        public Nullable<decimal> KVGGrundPraemie
        {
            get { return _kVGGrundPraemie; }
            set
            {
                if (_kVGGrundPraemie != value)
                {
                    _kVGGrundPraemie = value;
                    RaisePropertyChanged("KVGGrundPraemie");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _kVGUnfallPraemie;
        public Nullable<decimal> KVGUnfallPraemie
        {
            get { return _kVGUnfallPraemie; }
            set
            {
                if (_kVGUnfallPraemie != value)
                {
                    _kVGUnfallPraemie = value;
                    RaisePropertyChanged("KVGUnfallPraemie");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _kVGGesundFoerdPraemie;
        public Nullable<decimal> KVGGesundFoerdPraemie
        {
            get { return _kVGGesundFoerdPraemie; }
            set
            {
                if (_kVGGesundFoerdPraemie != value)
                {
                    _kVGGesundFoerdPraemie = value;
                    RaisePropertyChanged("KVGGesundFoerdPraemie");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _kVGZuschussBetrag;
        public Nullable<decimal> KVGZuschussBetrag
        {
            get { return _kVGZuschussBetrag; }
            set
            {
                if (_kVGZuschussBetrag != value)
                {
                    _kVGZuschussBetrag = value;
                    RaisePropertyChanged("KVGZuschussBetrag");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _kVGUmweltabgabeBetrag;
        public Nullable<decimal> KVGUmweltabgabeBetrag
        {
            get { return _kVGUmweltabgabeBetrag; }
            set
            {
                if (_kVGUmweltabgabeBetrag != value)
                {
                    _kVGUmweltabgabeBetrag = value;
                    RaisePropertyChanged("KVGUmweltabgabeBetrag");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _kVGPraemie;
        public Nullable<decimal> KVGPraemie
        {
            get { return _kVGPraemie; }
            set
            {
                if (_kVGPraemie != value)
                {
                    _kVGPraemie = value;
                    RaisePropertyChanged("KVGPraemie");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _kVGFranchise;
        public Nullable<decimal> KVGFranchise
        {
            get { return _kVGFranchise; }
            set
            {
                if (_kVGFranchise != value)
                {
                    _kVGFranchise = value;
                    RaisePropertyChanged("KVGFranchise");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _kVGZahlungsPeriodeCode;
        public Nullable<int> KVGZahlungsPeriodeCode
        {
            get { return _kVGZahlungsPeriodeCode; }
            set
            {
                if (_kVGZahlungsPeriodeCode != value)
                {
                    _kVGZahlungsPeriodeCode = value;
                    RaisePropertyChanged("KVGZahlungsPeriodeCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _vVGOrganisationID;
        public Nullable<int> VVGOrganisationID
        {
            get { return _vVGOrganisationID; }
            set
            {
                if (_vVGOrganisationID != value)
                {
                    _vVGOrganisationID = value;
                    RaisePropertyChanged("VVGOrganisationID");
                    if (BaInstitution_Vvg != null && BaInstitution_Vvg.BaInstitutionID != value)
                    {
                        BaInstitution_Vvg = null;
                    }
                }
            }
        }
    
        [DataMember]
        private string _vVGKontaktPerson;
        public string VVGKontaktPerson
        {
            get { return _vVGKontaktPerson; }
            set
            {
                if (_vVGKontaktPerson != value)
                {
                    _vVGKontaktPerson = value;
                    RaisePropertyChanged("VVGKontaktPerson");
                }
            }
        }
    
        [DataMember]
        private string _vVGKontaktTelefon;
        public string VVGKontaktTelefon
        {
            get { return _vVGKontaktTelefon; }
            set
            {
                if (_vVGKontaktTelefon != value)
                {
                    _vVGKontaktTelefon = value;
                    RaisePropertyChanged("VVGKontaktTelefon");
                }
            }
        }
    
        [DataMember]
        private string _vVGMitgliedNr;
        public string VVGMitgliedNr
        {
            get { return _vVGMitgliedNr; }
            set
            {
                if (_vVGMitgliedNr != value)
                {
                    _vVGMitgliedNr = value;
                    RaisePropertyChanged("VVGMitgliedNr");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _vVGVersichertSeit;
        public Nullable<System.DateTime> VVGVersichertSeit
        {
            get { return _vVGVersichertSeit; }
            set
            {
                if (_vVGVersichertSeit != value)
                {
                    _vVGVersichertSeit = value;
                    RaisePropertyChanged("VVGVersichertSeit");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _vVGPraemie;
        public Nullable<decimal> VVGPraemie
        {
            get { return _vVGPraemie; }
            set
            {
                if (_vVGPraemie != value)
                {
                    _vVGPraemie = value;
                    RaisePropertyChanged("VVGPraemie");
                }
            }
        }
    
        [DataMember]
        private Nullable<decimal> _vVGFranchise;
        public Nullable<decimal> VVGFranchise
        {
            get { return _vVGFranchise; }
            set
            {
                if (_vVGFranchise != value)
                {
                    _vVGFranchise = value;
                    RaisePropertyChanged("VVGFranchise");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _vVGZahlungsPeriodeCode;
        public Nullable<int> VVGZahlungsPeriodeCode
        {
            get { return _vVGZahlungsPeriodeCode; }
            set
            {
                if (_vVGZahlungsPeriodeCode != value)
                {
                    _vVGZahlungsPeriodeCode = value;
                    RaisePropertyChanged("VVGZahlungsPeriodeCode");
                }
            }
        }
    
        [DataMember]
        private string _vVGZusaetzeRTF;
        public string VVGZusaetzeRTF
        {
            get { return _vVGZusaetzeRTF; }
            set
            {
                if (_vVGZusaetzeRTF != value)
                {
                    _vVGZusaetzeRTF = value;
                    RaisePropertyChanged("VVGZusaetzeRTF");
                }
            }
        }
    
        [DataMember]
        private Nullable<bool> _zuschussInAbklaerungFlag;
        public Nullable<bool> ZuschussInAbklaerungFlag
        {
            get { return _zuschussInAbklaerungFlag; }
            set
            {
                if (_zuschussInAbklaerungFlag != value)
                {
                    _zuschussInAbklaerungFlag = value;
                    RaisePropertyChanged("ZuschussInAbklaerungFlag");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _iVEingliederungsmassnahmeCode;
        public Nullable<int> IVEingliederungsmassnahmeCode
        {
            get { return _iVEingliederungsmassnahmeCode; }
            set
            {
                if (_iVEingliederungsmassnahmeCode != value)
                {
                    _iVEingliederungsmassnahmeCode = value;
                    RaisePropertyChanged("IVEingliederungsmassnahmeCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _pflegeDurchCode;
        public Nullable<int> PflegeDurchCode
        {
            get { return _pflegeDurchCode; }
            set
            {
                if (_pflegeDurchCode != value)
                {
                    _pflegeDurchCode = value;
                    RaisePropertyChanged("PflegeDurchCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<bool> _pflegebeduerftigFlag;
        public Nullable<bool> PflegebeduerftigFlag
        {
            get { return _pflegebeduerftigFlag; }
            set
            {
                if (_pflegebeduerftigFlag != value)
                {
                    _pflegebeduerftigFlag = value;
                    RaisePropertyChanged("PflegebeduerftigFlag");
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
        private Nullable<System.DateTime> _aSVSAbmeldung;
        public Nullable<System.DateTime> ASVSAbmeldung
        {
            get { return _aSVSAbmeldung; }
            set
            {
                if (_aSVSAbmeldung != value)
                {
                    _aSVSAbmeldung = value;
                    RaisePropertyChanged("ASVSAbmeldung");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _aSVSAnmeldung;
        public Nullable<System.DateTime> ASVSAnmeldung
        {
            get { return _aSVSAnmeldung; }
            set
            {
                if (_aSVSAnmeldung != value)
                {
                    _aSVSAnmeldung = value;
                    RaisePropertyChanged("ASVSAnmeldung");
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
        private bool _abtretungKK;
        public bool AbtretungKK
        {
            get { return _abtretungKK; }
            set
            {
                if (_abtretungKK != value)
                {
                    _abtretungKK = value;
                    RaisePropertyChanged("AbtretungKK");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _eVAZDatum;
        public Nullable<System.DateTime> EVAZDatum
        {
            get { return _eVAZDatum; }
            set
            {
                if (_eVAZDatum != value)
                {
                    _eVAZDatum = value;
                    RaisePropertyChanged("EVAZDatum");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _zahnarztBaInstitutionID;
        public Nullable<int> ZahnarztBaInstitutionID
        {
            get { return _zahnarztBaInstitutionID; }
            set
            {
                if (_zahnarztBaInstitutionID != value)
                {
                    _zahnarztBaInstitutionID = value;
                    RaisePropertyChanged("ZahnarztBaInstitutionID");
                    if (BaInstitution_Zahnarzt != null && BaInstitution_Zahnarzt.BaInstitutionID != value)
                    {
                        BaInstitution_Zahnarzt = null;
                    }
                }
            }
        }
    
        [DataMember]
        private byte[] _baGesundheitTS;
        public byte[] BaGesundheitTS
        {
            get { return _baGesundheitTS; }
            set
            {
                if (_baGesundheitTS != value)
                {
                    _baGesundheitTS = value;
                    RaisePropertyChanged("BaGesundheitTS");
                }
            }
        }
    
    
        [DataMember]
        private BaInstitution _baInstitution_Zahnarzt;
        public virtual BaInstitution BaInstitution_Zahnarzt
        {
            get { return _baInstitution_Zahnarzt; }
            set
            {
                if (_baInstitution_Zahnarzt != value)
                {
                    _baInstitution_Zahnarzt = value;
                    RaisePropertyChanged("BaInstitution_Zahnarzt");
    
                    if (value != null)
                    {
                        ZahnarztBaInstitutionID = value.BaInstitutionID;
                    }
                }
            }
        }
        [DataMember]
        private BaInstitution _baInstitution_Kvg;
        public virtual BaInstitution BaInstitution_Kvg
        {
            get { return _baInstitution_Kvg; }
            set
            {
                if (_baInstitution_Kvg != value)
                {
                    _baInstitution_Kvg = value;
                    RaisePropertyChanged("BaInstitution_Kvg");
    
                    if (value != null)
                    {
                        KVGOrganisationID = value.BaInstitutionID;
                    }
                }
            }
        }
        [DataMember]
        private BaInstitution _baInstitution_Vvg;
        public virtual BaInstitution BaInstitution_Vvg
        {
            get { return _baInstitution_Vvg; }
            set
            {
                if (_baInstitution_Vvg != value)
                {
                    _baInstitution_Vvg = value;
                    RaisePropertyChanged("BaInstitution_Vvg");
    
                    if (value != null)
                    {
                        VVGOrganisationID = value.BaInstitutionID;
                    }
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
    }
    
}