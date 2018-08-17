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
    [KnownType(typeof(BaLand))]
    [KnownType(typeof(BaZahlungsweg))]
    public partial class BaBank: EntityBase<BaBank>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int BaBankID
        {
            get { return _baBankID; }
            set
            {
                if (_baBankID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'BaBankID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _baBankID = value;
                    OnPropertyChanged("BaBankID");
                }
            }
        }
        private int _baBankID;
    
        [DataMember]
        public Nullable<int> LandCode
        {
            get { return _landCode; }
            set
            {
                if (_landCode != value)
                {
                    ChangeTracker.RecordOriginalValue("LandCode", _landCode);
                    if (!IsDeserializing)
                    {
                        if (BaLand != null && BaLand.BaLandID != value)
                        {
                            BaLand = null;
                        }
                    }
                    _landCode = value;
                    OnPropertyChanged("LandCode");
                }
            }
        }
        private Nullable<int> _landCode;
    
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
        public string Zusatz
        {
            get { return _zusatz; }
            set
            {
                if (_zusatz != value)
                {
                    _zusatz = value;
                    OnPropertyChanged("Zusatz");
                }
            }
        }
        private string _zusatz;
    
        [DataMember]
        public string Strasse
        {
            get { return _strasse; }
            set
            {
                if (_strasse != value)
                {
                    _strasse = value;
                    OnPropertyChanged("Strasse");
                }
            }
        }
        private string _strasse;
    
        [DataMember]
        public string PLZ
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
        private string _pLZ;
    
        [DataMember]
        public string Ort
        {
            get { return _ort; }
            set
            {
                if (_ort != value)
                {
                    _ort = value;
                    OnPropertyChanged("Ort");
                }
            }
        }
        private string _ort;
    
        [DataMember]
        public string ClearingNr
        {
            get { return _clearingNr; }
            set
            {
                if (_clearingNr != value)
                {
                    _clearingNr = value;
                    OnPropertyChanged("ClearingNr");
                }
            }
        }
        private string _clearingNr;
    
        [DataMember]
        public string ClearingNrNeu
        {
            get { return _clearingNrNeu; }
            set
            {
                if (_clearingNrNeu != value)
                {
                    _clearingNrNeu = value;
                    OnPropertyChanged("ClearingNrNeu");
                }
            }
        }
        private string _clearingNrNeu;
    
        [DataMember]
        public int FilialeNr
        {
            get { return _filialeNr; }
            set
            {
                if (_filialeNr != value)
                {
                    _filialeNr = value;
                    OnPropertyChanged("FilialeNr");
                }
            }
        }
        private int _filialeNr;
    
        [DataMember]
        public string HauptsitzBCL
        {
            get { return _hauptsitzBCL; }
            set
            {
                if (_hauptsitzBCL != value)
                {
                    _hauptsitzBCL = value;
                    OnPropertyChanged("HauptsitzBCL");
                }
            }
        }
        private string _hauptsitzBCL;
    
        [DataMember]
        public string PCKontoNr
        {
            get { return _pCKontoNr; }
            set
            {
                if (_pCKontoNr != value)
                {
                    _pCKontoNr = value;
                    OnPropertyChanged("PCKontoNr");
                }
            }
        }
        private string _pCKontoNr;
    
        [DataMember]
        public System.DateTime GueltigAb
        {
            get { return _gueltigAb; }
            set
            {
                if (_gueltigAb != value)
                {
                    _gueltigAb = value;
                    OnPropertyChanged("GueltigAb");
                }
            }
        }
        private System.DateTime _gueltigAb;
    
        [DataMember]
        public bool SicUpdated
        {
            get { return _sicUpdated; }
            set
            {
                if (_sicUpdated != value)
                {
                    _sicUpdated = value;
                    OnPropertyChanged("SicUpdated");
                }
            }
        }
        private bool _sicUpdated;
    
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
        public byte[] BaBankTS
        {
            get { return _baBankTS; }
            set
            {
                if (_baBankTS != value)
                {
                    _baBankTS = value;
                    OnPropertyChanged("BaBankTS");
                }
            }
        }
        private byte[] _baBankTS;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public BaLand BaLand
        {
            get { return _baLand; }
            set
            {
                if (!ReferenceEquals(_baLand, value))
                {
                    var previousValue = _baLand;
                    _baLand = value;
                    FixupBaLand(previousValue);
                    OnNavigationPropertyChanged("BaLand");
                }
            }
        }
        private BaLand _baLand;
    
        [DataMember]
        public TrackableCollection<BaZahlungsweg> BaZahlungsweg
        {
            get
            {
                if (_baZahlungsweg == null)
                {
                    _baZahlungsweg = new TrackableCollection<BaZahlungsweg>();
                    _baZahlungsweg.CollectionChanged += FixupBaZahlungsweg;
                }
                return _baZahlungsweg;
            }
            set
            {
                if (!ReferenceEquals(_baZahlungsweg, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_baZahlungsweg != null)
                    {
                        _baZahlungsweg.CollectionChanged -= FixupBaZahlungsweg;
                    }
                    _baZahlungsweg = value;
                    if (_baZahlungsweg != null)
                    {
                        _baZahlungsweg.CollectionChanged += FixupBaZahlungsweg;
                    }
                    OnNavigationPropertyChanged("BaZahlungsweg");
                }
            }
        }
        private TrackableCollection<BaZahlungsweg> _baZahlungsweg;

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
            BaLand = null;
            BaZahlungsweg.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupBaLand(BaLand previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BaBank.Contains(this))
            {
                previousValue.BaBank.Remove(this);
            }
    
            if (BaLand != null)
            {
                if (!BaLand.BaBank.Contains(this))
                {
                    BaLand.BaBank.Add(this);
                }
    
                LandCode = BaLand.BaLandID;
            }
            else if (!skipKeys)
            {
                LandCode = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BaLand")
                    && (ChangeTracker.OriginalValues["BaLand"] == BaLand))
                {
                    ChangeTracker.OriginalValues.Remove("BaLand");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BaLand", previousValue);
                }
                if (BaLand != null && !BaLand.ChangeTracker.ChangeTrackingEnabled)
                {
                    BaLand.StartTracking();
                }
            }
        }
    
        private void FixupBaZahlungsweg(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (BaZahlungsweg item in e.NewItems)
                {
                    item.BaBank = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("BaZahlungsweg", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (BaZahlungsweg item in e.OldItems)
                {
                    if (ReferenceEquals(item.BaBank, this))
                    {
                        item.BaBank = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("BaZahlungsweg", item);
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
    
    		var entity = (BaBank)obj;
    		if (!_baBankID.Equals(entity.BaBankID) || _baBankID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _baBankID.GetHashCode();
        }

        #endregion

    }
}
