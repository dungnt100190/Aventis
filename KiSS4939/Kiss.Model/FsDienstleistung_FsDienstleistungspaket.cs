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
    [KnownType(typeof(FsDienstleistung))]
    [KnownType(typeof(FsDienstleistungspaket))]
    public partial class FsDienstleistung_FsDienstleistungspaket: EntityBase<FsDienstleistung_FsDienstleistungspaket>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int FsDienstleistung_FsDienstleistungspaketID
        {
            get { return _fsDienstleistung_FsDienstleistungspaketID; }
            set
            {
                if (_fsDienstleistung_FsDienstleistungspaketID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FsDienstleistung_FsDienstleistungspaketID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _fsDienstleistung_FsDienstleistungspaketID = value;
                    OnPropertyChanged("FsDienstleistung_FsDienstleistungspaketID");
                }
            }
        }
        private int _fsDienstleistung_FsDienstleistungspaketID;
    
        [DataMember]
        public int FsDienstleistungID
        {
            get { return _fsDienstleistungID; }
            set
            {
                if (_fsDienstleistungID != value)
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistungID", _fsDienstleistungID);
                    if (!IsDeserializing)
                    {
                        if (FsDienstleistung != null && FsDienstleistung.FsDienstleistungID != value)
                        {
                            FsDienstleistung = null;
                        }
                    }
                    _fsDienstleistungID = value;
                    OnPropertyChanged("FsDienstleistungID");
                }
            }
        }
        private int _fsDienstleistungID;
    
        [DataMember]
        public int FsDienstleistungspaketID
        {
            get { return _fsDienstleistungspaketID; }
            set
            {
                if (_fsDienstleistungspaketID != value)
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistungspaketID", _fsDienstleistungspaketID);
                    if (!IsDeserializing)
                    {
                        if (FsDienstleistungspaket != null && FsDienstleistungspaket.FsDienstleistungspaketID != value)
                        {
                            FsDienstleistungspaket = null;
                        }
                    }
                    _fsDienstleistungspaketID = value;
                    OnPropertyChanged("FsDienstleistungspaketID");
                }
            }
        }
        private int _fsDienstleistungspaketID;
    
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
        public byte[] FsDienstleistung_FsDienstleistungspaketTS
        {
            get { return _fsDienstleistung_FsDienstleistungspaketTS; }
            set
            {
                if (_fsDienstleistung_FsDienstleistungspaketTS != value)
                {
                    _fsDienstleistung_FsDienstleistungspaketTS = value;
                    OnPropertyChanged("FsDienstleistung_FsDienstleistungspaketTS");
                }
            }
        }
        private byte[] _fsDienstleistung_FsDienstleistungspaketTS;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public FsDienstleistung FsDienstleistung
        {
            get { return _fsDienstleistung; }
            set
            {
                if (!ReferenceEquals(_fsDienstleistung, value))
                {
                    var previousValue = _fsDienstleistung;
                    _fsDienstleistung = value;
                    FixupFsDienstleistung(previousValue);
                    OnNavigationPropertyChanged("FsDienstleistung");
                }
            }
        }
        private FsDienstleistung _fsDienstleistung;
    
        [DataMember]
        public FsDienstleistungspaket FsDienstleistungspaket
        {
            get { return _fsDienstleistungspaket; }
            set
            {
                if (!ReferenceEquals(_fsDienstleistungspaket, value))
                {
                    var previousValue = _fsDienstleistungspaket;
                    _fsDienstleistungspaket = value;
                    FixupFsDienstleistungspaket(previousValue);
                    OnNavigationPropertyChanged("FsDienstleistungspaket");
                }
            }
        }
        private FsDienstleistungspaket _fsDienstleistungspaket;

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
            FsDienstleistung = null;
            FsDienstleistungspaket = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupFsDienstleistung(FsDienstleistung previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FsDienstleistung_FsDienstleistungspaket.Contains(this))
            {
                previousValue.FsDienstleistung_FsDienstleistungspaket.Remove(this);
            }
    
            if (FsDienstleistung != null)
            {
                if (!FsDienstleistung.FsDienstleistung_FsDienstleistungspaket.Contains(this))
                {
                    FsDienstleistung.FsDienstleistung_FsDienstleistungspaket.Add(this);
                }
    
                FsDienstleistungID = FsDienstleistung.FsDienstleistungID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("FsDienstleistung")
                    && (ChangeTracker.OriginalValues["FsDienstleistung"] == FsDienstleistung))
                {
                    ChangeTracker.OriginalValues.Remove("FsDienstleistung");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistung", previousValue);
                }
                if (FsDienstleistung != null && !FsDienstleistung.ChangeTracker.ChangeTrackingEnabled)
                {
                    FsDienstleistung.StartTracking();
                }
            }
        }
    
        private void FixupFsDienstleistungspaket(FsDienstleistungspaket previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FsDienstleistung_FsDienstleistungspaket.Contains(this))
            {
                previousValue.FsDienstleistung_FsDienstleistungspaket.Remove(this);
            }
    
            if (FsDienstleistungspaket != null)
            {
                if (!FsDienstleistungspaket.FsDienstleistung_FsDienstleistungspaket.Contains(this))
                {
                    FsDienstleistungspaket.FsDienstleistung_FsDienstleistungspaket.Add(this);
                }
    
                FsDienstleistungspaketID = FsDienstleistungspaket.FsDienstleistungspaketID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("FsDienstleistungspaket")
                    && (ChangeTracker.OriginalValues["FsDienstleistungspaket"] == FsDienstleistungspaket))
                {
                    ChangeTracker.OriginalValues.Remove("FsDienstleistungspaket");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistungspaket", previousValue);
                }
                if (FsDienstleistungspaket != null && !FsDienstleistungspaket.ChangeTracker.ChangeTrackingEnabled)
                {
                    FsDienstleistungspaket.StartTracking();
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
    
    		var entity = (FsDienstleistung_FsDienstleistungspaket)obj;
    		if (!_fsDienstleistung_FsDienstleistungspaketID.Equals(entity.FsDienstleistung_FsDienstleistungspaketID) || _fsDienstleistung_FsDienstleistungspaketID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _fsDienstleistung_FsDienstleistungspaketID.GetHashCode();
        }

        #endregion

    }
}
