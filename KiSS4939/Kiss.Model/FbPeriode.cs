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
    [KnownType(typeof(FbBuchung))]
    [KnownType(typeof(FbKonto))]
    public partial class FbPeriode: EntityBase<FbPeriode>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int FbPeriodeID
        {
            get { return _fbPeriodeID; }
            set
            {
                if (_fbPeriodeID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FbPeriodeID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _fbPeriodeID = value;
                    OnPropertyChanged("FbPeriodeID");
                }
            }
        }
        private int _fbPeriodeID;
    
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
        public System.DateTime PeriodeVon
        {
            get { return _periodeVon; }
            set
            {
                if (_periodeVon != value)
                {
                    _periodeVon = value;
                    OnPropertyChanged("PeriodeVon");
                }
            }
        }
        private System.DateTime _periodeVon;
    
        [DataMember]
        public System.DateTime PeriodeBis
        {
            get { return _periodeBis; }
            set
            {
                if (_periodeBis != value)
                {
                    _periodeBis = value;
                    OnPropertyChanged("PeriodeBis");
                }
            }
        }
        private System.DateTime _periodeBis;
    
        [DataMember]
        public int PeriodeStatusCode
        {
            get { return _periodeStatusCode; }
            set
            {
                if (_periodeStatusCode != value)
                {
                    _periodeStatusCode = value;
                    OnPropertyChanged("PeriodeStatusCode");
                }
            }
        }
        private int _periodeStatusCode;
    
        [DataMember]
        public Nullable<int> FbTeamID
        {
            get { return _fbTeamID; }
            set
            {
                if (_fbTeamID != value)
                {
                    _fbTeamID = value;
                    OnPropertyChanged("FbTeamID");
                }
            }
        }
        private Nullable<int> _fbTeamID;
    
        [DataMember]
        public Nullable<int> JournalablageortCode
        {
            get { return _journalablageortCode; }
            set
            {
                if (_journalablageortCode != value)
                {
                    _journalablageortCode = value;
                    OnPropertyChanged("JournalablageortCode");
                }
            }
        }
        private Nullable<int> _journalablageortCode;
    
        [DataMember]
        public byte[] FbPeriodeTS
        {
            get { return _fbPeriodeTS; }
            set
            {
                if (_fbPeriodeTS != value)
                {
                    _fbPeriodeTS = value;
                    OnPropertyChanged("FbPeriodeTS");
                }
            }
        }
        private byte[] _fbPeriodeTS;

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
        public TrackableCollection<FbBuchung> FbBuchung
        {
            get
            {
                if (_fbBuchung == null)
                {
                    _fbBuchung = new TrackableCollection<FbBuchung>();
                    _fbBuchung.CollectionChanged += FixupFbBuchung;
                }
                return _fbBuchung;
            }
            set
            {
                if (!ReferenceEquals(_fbBuchung, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_fbBuchung != null)
                    {
                        _fbBuchung.CollectionChanged -= FixupFbBuchung;
                    }
                    _fbBuchung = value;
                    if (_fbBuchung != null)
                    {
                        _fbBuchung.CollectionChanged += FixupFbBuchung;
                    }
                    OnNavigationPropertyChanged("FbBuchung");
                }
            }
        }
        private TrackableCollection<FbBuchung> _fbBuchung;
    
        [DataMember]
        public TrackableCollection<FbKonto> FbKonto
        {
            get
            {
                if (_fbKonto == null)
                {
                    _fbKonto = new TrackableCollection<FbKonto>();
                    _fbKonto.CollectionChanged += FixupFbKonto;
                }
                return _fbKonto;
            }
            set
            {
                if (!ReferenceEquals(_fbKonto, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_fbKonto != null)
                    {
                        _fbKonto.CollectionChanged -= FixupFbKonto;
                    }
                    _fbKonto = value;
                    if (_fbKonto != null)
                    {
                        _fbKonto.CollectionChanged += FixupFbKonto;
                    }
                    OnNavigationPropertyChanged("FbKonto");
                }
            }
        }
        private TrackableCollection<FbKonto> _fbKonto;

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
            FbBuchung.Clear();
            FbKonto.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupBaPerson(BaPerson previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FbPeriode.Contains(this))
            {
                previousValue.FbPeriode.Remove(this);
            }
    
            if (BaPerson != null)
            {
                if (!BaPerson.FbPeriode.Contains(this))
                {
                    BaPerson.FbPeriode.Add(this);
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
    
        private void FixupFbBuchung(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (FbBuchung item in e.NewItems)
                {
                    item.FbPeriode = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("FbBuchung", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FbBuchung item in e.OldItems)
                {
                    if (ReferenceEquals(item.FbPeriode, this))
                    {
                        item.FbPeriode = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("FbBuchung", item);
                    }
                }
            }
        }
    
        private void FixupFbKonto(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (FbKonto item in e.NewItems)
                {
                    item.FbPeriode = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("FbKonto", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FbKonto item in e.OldItems)
                {
                    if (ReferenceEquals(item.FbPeriode, this))
                    {
                        item.FbPeriode = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("FbKonto", item);
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
    
    		var entity = (FbPeriode)obj;
    		if (!_fbPeriodeID.Equals(entity.FbPeriodeID) || _fbPeriodeID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _fbPeriodeID.GetHashCode();
        }

        #endregion

    }
}