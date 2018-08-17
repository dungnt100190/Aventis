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
    [KnownType(typeof(FaKategorisierung))]
    [KnownType(typeof(XOrgUnit))]
    public partial class FaKategorisierungEksProdukt : PocoEntity, IAutoIdentityEntity<int>, IAuditableEntity
    {
        public FaKategorisierungEksProdukt()
        {
            this.FaKategorisierung = new HashSet<FaKategorisierung>();
        }
    
        public int AutoIdentityID 
        {
            get{ return FaKategorisierungEksProduktID; } 
        }
    
        [DataMember]
        private int _faKategorisierungEksProduktID;
        public int FaKategorisierungEksProduktID
        {
            get { return _faKategorisierungEksProduktID; }
            set
            {
                if (_faKategorisierungEksProduktID != value)
                {
                    _faKategorisierungEksProduktID = value;
                    RaisePropertyChanged("FaKategorisierungEksProduktID");
                }
            }
        }
    
        [DataMember]
        private int _orgUnitID;
        public int OrgUnitID
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
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    RaisePropertyChanged("Text");
                }
            }
        }
    
        [DataMember]
        private string _shortText;
        public string ShortText
        {
            get { return _shortText; }
            set
            {
                if (_shortText != value)
                {
                    _shortText = value;
                    RaisePropertyChanged("ShortText");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _frist;
        public Nullable<int> Frist
        {
            get { return _frist; }
            set
            {
                if (_frist != value)
                {
                    _frist = value;
                    RaisePropertyChanged("Frist");
                }
            }
        }
    
        [DataMember]
        private int _faKategorisierungEksProduktFristTypCode;
        public int FaKategorisierungEksProduktFristTypCode
        {
            get { return _faKategorisierungEksProduktFristTypCode; }
            set
            {
                if (_faKategorisierungEksProduktFristTypCode != value)
                {
                    _faKategorisierungEksProduktFristTypCode = value;
                    RaisePropertyChanged("FaKategorisierungEksProduktFristTypCode");
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
        private byte[] _faKategorisierungEksProduktTS;
        public byte[] FaKategorisierungEksProduktTS
        {
            get { return _faKategorisierungEksProduktTS; }
            set
            {
                if (_faKategorisierungEksProduktTS != value)
                {
                    _faKategorisierungEksProduktTS = value;
                    RaisePropertyChanged("FaKategorisierungEksProduktTS");
                }
            }
        }
    
        [DataMember]
        private int _faKategorieCode;
        public int FaKategorieCode
        {
            get { return _faKategorieCode; }
            set
            {
                if (_faKategorieCode != value)
                {
                    _faKategorieCode = value;
                    RaisePropertyChanged("FaKategorieCode");
                }
            }
        }
    
    
        [DataMember]
        private ICollection<FaKategorisierung> _faKategorisierung;
        public virtual ICollection<FaKategorisierung> FaKategorisierung
        {
            get { return _faKategorisierung; }
            set
            {
                if (_faKategorisierung != value)
                {
                    _faKategorisierung = value;
                    RaisePropertyChanged("FaKategorisierung");
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
    }
    
}