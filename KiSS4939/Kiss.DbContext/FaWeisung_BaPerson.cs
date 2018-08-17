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
    [KnownType(typeof(FaWeisung))]
    public partial class FaWeisung_BaPerson : PocoEntity, IAutoIdentityEntity<int>
    {
        public int AutoIdentityID 
        {
            get{ return FaWeisung_BaPersonID; } 
        }
    
        [DataMember]
        private int _faWeisung_BaPersonID;
        public int FaWeisung_BaPersonID
        {
            get { return _faWeisung_BaPersonID; }
            set
            {
                if (_faWeisung_BaPersonID != value)
                {
                    _faWeisung_BaPersonID = value;
                    RaisePropertyChanged("FaWeisung_BaPersonID");
                }
            }
        }
    
        [DataMember]
        private int _faWeisungID;
        public int FaWeisungID
        {
            get { return _faWeisungID; }
            set
            {
                if (_faWeisungID != value)
                {
                    _faWeisungID = value;
                    RaisePropertyChanged("FaWeisungID");
                    if (FaWeisung != null && FaWeisung.FaWeisungID != value)
                    {
                        FaWeisung = null;
                    }
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
        private byte[] _faWeisung_BaPersonTS;
        public byte[] FaWeisung_BaPersonTS
        {
            get { return _faWeisung_BaPersonTS; }
            set
            {
                if (_faWeisung_BaPersonTS != value)
                {
                    _faWeisung_BaPersonTS = value;
                    RaisePropertyChanged("FaWeisung_BaPersonTS");
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
        private FaWeisung _faWeisung;
        public virtual FaWeisung FaWeisung
        {
            get { return _faWeisung; }
            set
            {
                if (_faWeisung != value)
                {
                    _faWeisung = value;
                    RaisePropertyChanged("FaWeisung");
    
                    if (value != null)
                    {
                        FaWeisungID = value.FaWeisungID;
                    }
                }
            }
        }
    }
    
}