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
    [KnownType(typeof(XUser))]
    public partial class BDEPensum_XUser : PocoEntity, IAutoIdentityEntity<int>
    {
        public int AutoIdentityID 
        {
            get{ return BDEPensum_XUserID; } 
        }
    
        [DataMember]
        private int _bDEPensum_XUserID;
        public int BDEPensum_XUserID
        {
            get { return _bDEPensum_XUserID; }
            set
            {
                if (_bDEPensum_XUserID != value)
                {
                    _bDEPensum_XUserID = value;
                    RaisePropertyChanged("BDEPensum_XUserID");
                }
            }
        }
    
        [DataMember]
        private int _userID;
        public int UserID
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
        private System.DateTime _datumVon;
        public System.DateTime DatumVon
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
        private int _pensumProzent;
        public int PensumProzent
        {
            get { return _pensumProzent; }
            set
            {
                if (_pensumProzent != value)
                {
                    _pensumProzent = value;
                    RaisePropertyChanged("PensumProzent");
                }
            }
        }
    
        [DataMember]
        private bool _manualEdit;
        public bool ManualEdit
        {
            get { return _manualEdit; }
            set
            {
                if (_manualEdit != value)
                {
                    _manualEdit = value;
                    RaisePropertyChanged("ManualEdit");
                }
            }
        }
    
        [DataMember]
        private byte[] _bDEPensum_XUserTS;
        public byte[] BDEPensum_XUserTS
        {
            get { return _bDEPensum_XUserTS; }
            set
            {
                if (_bDEPensum_XUserTS != value)
                {
                    _bDEPensum_XUserTS = value;
                    RaisePropertyChanged("BDEPensum_XUserTS");
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