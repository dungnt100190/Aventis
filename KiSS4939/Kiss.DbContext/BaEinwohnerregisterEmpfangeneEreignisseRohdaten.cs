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
    [KnownType(typeof(BaEinwohnerregisterEmpfangeneEreignisse))]
    public partial class BaEinwohnerregisterEmpfangeneEreignisseRohdaten : PocoEntity, IAutoIdentityEntity<int>, IAuditableEntity
    {
        public BaEinwohnerregisterEmpfangeneEreignisseRohdaten()
        {
            this.BaEinwohnerregisterEmpfangeneEreignisse = new HashSet<BaEinwohnerregisterEmpfangeneEreignisse>();
        }
    
        public int AutoIdentityID 
        {
            get{ return BaEinwohnerregisterEmpfangeneEreignisseRohdatenID; } 
        }
    
        [DataMember]
        private int _baEinwohnerregisterEmpfangeneEreignisseRohdatenID;
        public int BaEinwohnerregisterEmpfangeneEreignisseRohdatenID
        {
            get { return _baEinwohnerregisterEmpfangeneEreignisseRohdatenID; }
            set
            {
                if (_baEinwohnerregisterEmpfangeneEreignisseRohdatenID != value)
                {
                    _baEinwohnerregisterEmpfangeneEreignisseRohdatenID = value;
                    RaisePropertyChanged("BaEinwohnerregisterEmpfangeneEreignisseRohdatenID");
                }
            }
        }
    
        [DataMember]
        private string _xml;
        public string Xml
        {
            get { return _xml; }
            set
            {
                if (_xml != value)
                {
                    _xml = value;
                    RaisePropertyChanged("Xml");
                }
            }
        }
    
        [DataMember]
        private int _baEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode;
        public int BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode
        {
            get { return _baEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode; }
            set
            {
                if (_baEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode != value)
                {
                    _baEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode = value;
                    RaisePropertyChanged("BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode");
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
        private byte[] _baEinwohnerregisterEmpfangeneEreignisseRohdatenTS;
        public byte[] BaEinwohnerregisterEmpfangeneEreignisseRohdatenTS
        {
            get { return _baEinwohnerregisterEmpfangeneEreignisseRohdatenTS; }
            set
            {
                if (_baEinwohnerregisterEmpfangeneEreignisseRohdatenTS != value)
                {
                    _baEinwohnerregisterEmpfangeneEreignisseRohdatenTS = value;
                    RaisePropertyChanged("BaEinwohnerregisterEmpfangeneEreignisseRohdatenTS");
                }
            }
        }
    
    
        [DataMember]
        private ICollection<BaEinwohnerregisterEmpfangeneEreignisse> _baEinwohnerregisterEmpfangeneEreignisse;
        public virtual ICollection<BaEinwohnerregisterEmpfangeneEreignisse> BaEinwohnerregisterEmpfangeneEreignisse
        {
            get { return _baEinwohnerregisterEmpfangeneEreignisse; }
            set
            {
                if (_baEinwohnerregisterEmpfangeneEreignisse != value)
                {
                    _baEinwohnerregisterEmpfangeneEreignisse = value;
                    RaisePropertyChanged("BaEinwohnerregisterEmpfangeneEreignisse");
                }
            }
        }
    }
    
}
