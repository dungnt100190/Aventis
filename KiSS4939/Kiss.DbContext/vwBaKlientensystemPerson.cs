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
    public partial class vwBaKlientensystemPerson : PocoEntity
    {
        [DataMember]
        private int _faFallID;
        public int FaFallID
        {
            get { return _faFallID; }
            set
            {
                if (_faFallID != value)
                {
                    _faFallID = value;
                    RaisePropertyChanged("FaFallID");
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
    
    }
    
}