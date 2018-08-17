//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace Kiss.Model
{
    [DataContract(IsReference = true)]
    public partial class BaPLZ: EntityBase<BaPLZ>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int BaPLZID
        {
            get { return _baPLZID; }
            set
            {
                if (_baPLZID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'BaPLZID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _baPLZID = value;
                    OnPropertyChanged("BaPLZID");
                }
            }
        }
        private int _baPLZID;
    
        [DataMember]
        public int PLZ
        {
            get { return _pLZ; }
            set
            {
                if (_pLZ != value)
                {
                    _pLZ = value;
                    OnPropertyChanged("PLZ");
                }
            }
        }
        private int _pLZ;
    
        [DataMember]
        public Nullable<int> PLZ6
        {
            get { return _pLZ6; }
            set
            {
                if (_pLZ6 != value)
                {
                    _pLZ6 = value;
                    OnPropertyChanged("PLZ6");
                }
            }
        }
        private Nullable<int> _pLZ6;
    
        [DataMember]
        public Nullable<int> PLZSuffix
        {
            get { return _pLZSuffix; }
            set
            {
                if (_pLZSuffix != value)
                {
                    _pLZSuffix = value;
                    OnPropertyChanged("PLZSuffix");
                }
            }
        }
        private Nullable<int> _pLZSuffix;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public Nullable<int> NameTID
        {
            get { return _nameTID; }
            set
            {
                if (_nameTID != value)
                {
                    _nameTID = value;
                    OnPropertyChanged("NameTID");
                }
            }
        }
        private Nullable<int> _nameTID;
    
        [DataMember]
        public string Kanton
        {
            get { return _kanton; }
            set
            {
                if (_kanton != value)
                {
                    _kanton = value;
                    OnPropertyChanged("Kanton");
                }
            }
        }
        private string _kanton;
    
        [DataMember]
        public int SortKey
        {
            get { return _sortKey; }
            set
            {
                if (_sortKey != value)
                {
                    _sortKey = value;
                    OnPropertyChanged("SortKey");
                }
            }
        }
        private int _sortKey;
    
        [DataMember]
        public int BFSCode
        {
            get { return _bFSCode; }
            set
            {
                if (_bFSCode != value)
                {
                    _bFSCode = value;
                    OnPropertyChanged("BFSCode");
                }
            }
        }
        private int _bFSCode;
    
        [DataMember]
        public bool System
        {
            get { return _system; }
            set
            {
                if (_system != value)
                {
                    _system = value;
                    OnPropertyChanged("System");
                }
            }
        }
        private bool _system;
    
        [DataMember]
        public byte[] BaPLZTS
        {
            get { return _baPLZTS; }
            set
            {
                if (_baPLZTS != value)
                {
                    _baPLZTS = value;
                    OnPropertyChanged("BaPLZTS");
                }
            }
        }
        private byte[] _baPLZTS;
    
        [DataMember]
        public Nullable<System.DateTime> DatumVon
        {
            get { return _datumVon; }
            set
            {
                if (_datumVon != value)
                {
                    _datumVon = value;
                    OnPropertyChanged("DatumVon");
                }
            }
        }
        private Nullable<System.DateTime> _datumVon;
    
        [DataMember]
        public Nullable<System.DateTime> DatumBis
        {
            get { return _datumBis; }
            set
            {
                if (_datumBis != value)
                {
                    _datumBis = value;
                    OnPropertyChanged("DatumBis");
                }
            }
        }
        private Nullable<System.DateTime> _datumBis;
    
        [DataMember]
        public Nullable<int> ONRP
        {
            get { return _oNRP; }
            set
            {
                if (_oNRP != value)
                {
                    _oNRP = value;
                    OnPropertyChanged("ONRP");
                }
            }
        }
        private Nullable<int> _oNRP;
    
        [DataMember]
        public string Creator
        {
            get { return _creator; }
            set
            {
                if (_creator != value)
                {
                    _creator = value;
                    OnPropertyChanged("Creator");
                }
            }
        }
        private string _creator;
    
        [DataMember]
        public System.DateTime Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    OnPropertyChanged("Created");
                }
            }
        }
        private System.DateTime _created;
    
        [DataMember]
        public string Modifier
        {
            get { return _modifier; }
            set
            {
                if (_modifier != value)
                {
                    _modifier = value;
                    OnPropertyChanged("Modifier");
                }
            }
        }
        private string _modifier;
    
        [DataMember]
        public System.DateTime Modified
        {
            get { return _modified; }
            set
            {
                if (_modified != value)
                {
                    _modified = value;
                    OnPropertyChanged("Modified");
                }
            }
        }
        private System.DateTime _modified;

        #endregion

        #region ChangeTracking
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected override void ClearNavigationProperties()
        {
        }

        #endregion

        #region Methods
    
    	public override bool Equals(object obj)
    	{
    		if (obj == null)
    		{
    			return false;
    		}
    		
    		if (ReferenceEquals(this, obj))
    		{
    			return true;
    		}
    
    		if (GetType() != obj.GetType())
    		{
    			return false;
    		}
    
    		var entity = (BaPLZ)obj;
    		if (!_baPLZID.Equals(entity.BaPLZID) || _baPLZID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _baPLZID.GetHashCode();
        }

        #endregion

    }
}
