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
    [KnownType(typeof(FsDienstleistung_FsDienstleistungspaket))]
    public partial class FsDienstleistung: EntityBase<FsDienstleistung>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int FsDienstleistungID
        {
            get { return _fsDienstleistungID; }
            set
            {
                if (_fsDienstleistungID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FsDienstleistungID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _fsDienstleistungID = value;
                    OnPropertyChanged("FsDienstleistungID");
                }
            }
        }
        private int _fsDienstleistungID;
    
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
        public decimal StandardAufwand
        {
            get { return _standardAufwand; }
            set
            {
                if (_standardAufwand != value)
                {
                    _standardAufwand = value;
                    OnPropertyChanged("StandardAufwand");
                }
            }
        }
        private decimal _standardAufwand;
    
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
        public byte[] FsDienstleistungTS
        {
            get { return _fsDienstleistungTS; }
            set
            {
                if (_fsDienstleistungTS != value)
                {
                    _fsDienstleistungTS = value;
                    OnPropertyChanged("FsDienstleistungTS");
                }
            }
        }
        private byte[] _fsDienstleistungTS;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<FsDienstleistung_FsDienstleistungspaket> FsDienstleistung_FsDienstleistungspaket
        {
            get
            {
                if (_fsDienstleistung_FsDienstleistungspaket == null)
                {
                    _fsDienstleistung_FsDienstleistungspaket = new TrackableCollection<FsDienstleistung_FsDienstleistungspaket>();
                    _fsDienstleistung_FsDienstleistungspaket.CollectionChanged += FixupFsDienstleistung_FsDienstleistungspaket;
                }
                return _fsDienstleistung_FsDienstleistungspaket;
            }
            set
            {
                if (!ReferenceEquals(_fsDienstleistung_FsDienstleistungspaket, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_fsDienstleistung_FsDienstleistungspaket != null)
                    {
                        _fsDienstleistung_FsDienstleistungspaket.CollectionChanged -= FixupFsDienstleistung_FsDienstleistungspaket;
                    }
                    _fsDienstleistung_FsDienstleistungspaket = value;
                    if (_fsDienstleistung_FsDienstleistungspaket != null)
                    {
                        _fsDienstleistung_FsDienstleistungspaket.CollectionChanged += FixupFsDienstleistung_FsDienstleistungspaket;
                    }
                    OnNavigationPropertyChanged("FsDienstleistung_FsDienstleistungspaket");
                }
            }
        }
        private TrackableCollection<FsDienstleistung_FsDienstleistungspaket> _fsDienstleistung_FsDienstleistungspaket;

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
            FsDienstleistung_FsDienstleistungspaket.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupFsDienstleistung_FsDienstleistungspaket(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (FsDienstleistung_FsDienstleistungspaket item in e.NewItems)
                {
                    item.FsDienstleistung = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("FsDienstleistung_FsDienstleistungspaket", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FsDienstleistung_FsDienstleistungspaket item in e.OldItems)
                {
                    if (ReferenceEquals(item.FsDienstleistung, this))
                    {
                        item.FsDienstleistung = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("FsDienstleistung_FsDienstleistungspaket", item);
                    }
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
    
    		var entity = (FsDienstleistung)obj;
    		if (!_fsDienstleistungID.Equals(entity.FsDienstleistungID) || _fsDienstleistungID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _fsDienstleistungID.GetHashCode();
        }

        #endregion

    }
}