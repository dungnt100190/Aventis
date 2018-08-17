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
    [KnownType(typeof(BaPerson))]
    [KnownType(typeof(FaDokumentAblage))]
    public partial class FaDokumentAblage_BaPerson: EntityBase<FaDokumentAblage_BaPerson>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int FaDokumentAblage_BaPersonID
        {
            get { return _faDokumentAblage_BaPersonID; }
            set
            {
                if (_faDokumentAblage_BaPersonID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FaDokumentAblage_BaPersonID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _faDokumentAblage_BaPersonID = value;
                    OnPropertyChanged("FaDokumentAblage_BaPersonID");
                }
            }
        }
        private int _faDokumentAblage_BaPersonID;
    
        [DataMember]
        public int BaPersonID
        {
            get { return _baPersonID; }
            set
            {
                if (_baPersonID != value)
                {
                    ChangeTracker.RecordOriginalValue("BaPersonID", _baPersonID);
                    if (!IsDeserializing)
                    {
                        if (BaPerson != null && BaPerson.BaPersonID != value)
                        {
                            BaPerson = null;
                        }
                    }
                    _baPersonID = value;
                    OnPropertyChanged("BaPersonID");
                }
            }
        }
        private int _baPersonID;
    
        [DataMember]
        public int FaDokumentAblageID
        {
            get { return _faDokumentAblageID; }
            set
            {
                if (_faDokumentAblageID != value)
                {
                    ChangeTracker.RecordOriginalValue("FaDokumentAblageID", _faDokumentAblageID);
                    if (!IsDeserializing)
                    {
                        if (FaDokumentAblage != null && FaDokumentAblage.FaDokumentAblageID != value)
                        {
                            FaDokumentAblage = null;
                        }
                    }
                    _faDokumentAblageID = value;
                    OnPropertyChanged("FaDokumentAblageID");
                }
            }
        }
        private int _faDokumentAblageID;
    
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
    
        [DataMember]
        public byte[] FaDokumentAblage_BaPersonTS
        {
            get { return _faDokumentAblage_BaPersonTS; }
            set
            {
                if (_faDokumentAblage_BaPersonTS != value)
                {
                    _faDokumentAblage_BaPersonTS = value;
                    OnPropertyChanged("FaDokumentAblage_BaPersonTS");
                }
            }
        }
        private byte[] _faDokumentAblage_BaPersonTS;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public BaPerson BaPerson
        {
            get { return _baPerson; }
            set
            {
                if (!ReferenceEquals(_baPerson, value))
                {
                    var previousValue = _baPerson;
                    _baPerson = value;
                    FixupBaPerson(previousValue);
                    OnNavigationPropertyChanged("BaPerson");
                }
            }
        }
        private BaPerson _baPerson;
    
        [DataMember]
        public FaDokumentAblage FaDokumentAblage
        {
            get { return _faDokumentAblage; }
            set
            {
                if (!ReferenceEquals(_faDokumentAblage, value))
                {
                    var previousValue = _faDokumentAblage;
                    _faDokumentAblage = value;
                    FixupFaDokumentAblage(previousValue);
                    OnNavigationPropertyChanged("FaDokumentAblage");
                }
            }
        }
        private FaDokumentAblage _faDokumentAblage;

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
            BaPerson = null;
            FaDokumentAblage = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupBaPerson(BaPerson previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaDokumentAblage_BaPerson.Contains(this))
            {
                previousValue.FaDokumentAblage_BaPerson.Remove(this);
            }
    
            if (BaPerson != null)
            {
                if (!BaPerson.FaDokumentAblage_BaPerson.Contains(this))
                {
                    BaPerson.FaDokumentAblage_BaPerson.Add(this);
                }
    
                BaPersonID = BaPerson.BaPersonID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BaPerson")
                    && (ChangeTracker.OriginalValues["BaPerson"] == BaPerson))
                {
                    ChangeTracker.OriginalValues.Remove("BaPerson");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BaPerson", previousValue);
                }
                if (BaPerson != null && !BaPerson.ChangeTracker.ChangeTrackingEnabled)
                {
                    BaPerson.StartTracking();
                }
            }
        }
    
        private void FixupFaDokumentAblage(FaDokumentAblage previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaDokumentAblage_BaPerson.Contains(this))
            {
                previousValue.FaDokumentAblage_BaPerson.Remove(this);
            }
    
            if (FaDokumentAblage != null)
            {
                if (!FaDokumentAblage.FaDokumentAblage_BaPerson.Contains(this))
                {
                    FaDokumentAblage.FaDokumentAblage_BaPerson.Add(this);
                }
    
                FaDokumentAblageID = FaDokumentAblage.FaDokumentAblageID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("FaDokumentAblage")
                    && (ChangeTracker.OriginalValues["FaDokumentAblage"] == FaDokumentAblage))
                {
                    ChangeTracker.OriginalValues.Remove("FaDokumentAblage");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("FaDokumentAblage", previousValue);
                }
                if (FaDokumentAblage != null && !FaDokumentAblage.ChangeTracker.ChangeTrackingEnabled)
                {
                    FaDokumentAblage.StartTracking();
                }
            }
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
    
    		var entity = (FaDokumentAblage_BaPerson)obj;
    		if (!_faDokumentAblage_BaPersonID.Equals(entity.FaDokumentAblage_BaPersonID) || _faDokumentAblage_BaPersonID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _faDokumentAblage_BaPersonID.GetHashCode();
        }

        #endregion

    }
}