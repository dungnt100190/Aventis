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
    [KnownType(typeof(FaLeistung))]
    [KnownType(typeof(FsDienstleistungspaket))]
    [KnownType(typeof(XUser))]
    public partial class FaPhase: EntityBase<FaPhase>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int FaPhaseID
        {
            get { return _faPhaseID; }
            set
            {
                if (_faPhaseID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FaPhaseID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _faPhaseID = value;
                    OnPropertyChanged("FaPhaseID");
                }
            }
        }
        private int _faPhaseID;
    
        [DataMember]
        public int FaLeistungID
        {
            get { return _faLeistungID; }
            set
            {
                if (_faLeistungID != value)
                {
                    ChangeTracker.RecordOriginalValue("FaLeistungID", _faLeistungID);
                    if (!IsDeserializing)
                    {
                        if (FaLeistung != null && FaLeistung.FaLeistungID != value)
                        {
                            FaLeistung = null;
                        }
                    }
                    _faLeistungID = value;
                    OnPropertyChanged("FaLeistungID");
                }
            }
        }
        private int _faLeistungID;
    
        [DataMember]
        public Nullable<int> UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    ChangeTracker.RecordOriginalValue("UserID", _userID);
                    if (!IsDeserializing)
                    {
                        if (XUser != null && XUser.UserID != value)
                        {
                            XUser = null;
                        }
                    }
                    _userID = value;
                    OnPropertyChanged("UserID");
                }
            }
        }
        private Nullable<int> _userID;
    
        [DataMember]
        public Nullable<int> FsDienstleistungspaketID_Zugewiesen
        {
            get { return _fsDienstleistungspaketID_Zugewiesen; }
            set
            {
                if (_fsDienstleistungspaketID_Zugewiesen != value)
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistungspaketID_Zugewiesen", _fsDienstleistungspaketID_Zugewiesen);
                    if (!IsDeserializing)
                    {
                        if (FsDienstleistungspaket_Zugewiesen != null && FsDienstleistungspaket_Zugewiesen.FsDienstleistungspaketID != value)
                        {
                            FsDienstleistungspaket_Zugewiesen = null;
                        }
                    }
                    _fsDienstleistungspaketID_Zugewiesen = value;
                    OnPropertyChanged("FsDienstleistungspaketID_Zugewiesen");
                }
            }
        }
        private Nullable<int> _fsDienstleistungspaketID_Zugewiesen;
    
        [DataMember]
        public Nullable<int> FsDienstleistungspaketID_Bedarf
        {
            get { return _fsDienstleistungspaketID_Bedarf; }
            set
            {
                if (_fsDienstleistungspaketID_Bedarf != value)
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistungspaketID_Bedarf", _fsDienstleistungspaketID_Bedarf);
                    if (!IsDeserializing)
                    {
                        if (FsDienstleistungspaket_Bedarf != null && FsDienstleistungspaket_Bedarf.FsDienstleistungspaketID != value)
                        {
                            FsDienstleistungspaket_Bedarf = null;
                        }
                    }
                    _fsDienstleistungspaketID_Bedarf = value;
                    OnPropertyChanged("FsDienstleistungspaketID_Bedarf");
                }
            }
        }
        private Nullable<int> _fsDienstleistungspaketID_Bedarf;
    
        [DataMember]
        public int FaPhaseCode
        {
            get { return _faPhaseCode; }
            set
            {
                if (_faPhaseCode != value)
                {
                    _faPhaseCode = value;
                    OnPropertyChanged("FaPhaseCode");
                }
            }
        }
        private int _faPhaseCode;
    
        [DataMember]
        public System.DateTime DatumVon
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
        private System.DateTime _datumVon;
    
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
        public Nullable<int> AbschlussGrundCode
        {
            get { return _abschlussGrundCode; }
            set
            {
                if (_abschlussGrundCode != value)
                {
                    _abschlussGrundCode = value;
                    OnPropertyChanged("AbschlussGrundCode");
                }
            }
        }
        private Nullable<int> _abschlussGrundCode;
    
        [DataMember]
        public string Bemerkung
        {
            get { return _bemerkung; }
            set
            {
                if (_bemerkung != value)
                {
                    _bemerkung = value;
                    OnPropertyChanged("Bemerkung");
                }
            }
        }
        private string _bemerkung;
    
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
        public byte[] FaPhaseTS
        {
            get { return _faPhaseTS; }
            set
            {
                if (_faPhaseTS != value)
                {
                    _faPhaseTS = value;
                    OnPropertyChanged("FaPhaseTS");
                }
            }
        }
        private byte[] _faPhaseTS;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public FaLeistung FaLeistung
        {
            get { return _faLeistung; }
            set
            {
                if (!ReferenceEquals(_faLeistung, value))
                {
                    var previousValue = _faLeistung;
                    _faLeistung = value;
                    FixupFaLeistung(previousValue);
                    OnNavigationPropertyChanged("FaLeistung");
                }
            }
        }
        private FaLeistung _faLeistung;
    
        [DataMember]
        public FsDienstleistungspaket FsDienstleistungspaket_Bedarf
        {
            get { return _fsDienstleistungspaket_Bedarf; }
            set
            {
                if (!ReferenceEquals(_fsDienstleistungspaket_Bedarf, value))
                {
                    var previousValue = _fsDienstleistungspaket_Bedarf;
                    _fsDienstleistungspaket_Bedarf = value;
                    FixupFsDienstleistungspaket_Bedarf(previousValue);
                    OnNavigationPropertyChanged("FsDienstleistungspaket_Bedarf");
                }
            }
        }
        private FsDienstleistungspaket _fsDienstleistungspaket_Bedarf;
    
        [DataMember]
        public FsDienstleistungspaket FsDienstleistungspaket_Zugewiesen
        {
            get { return _fsDienstleistungspaket_Zugewiesen; }
            set
            {
                if (!ReferenceEquals(_fsDienstleistungspaket_Zugewiesen, value))
                {
                    var previousValue = _fsDienstleistungspaket_Zugewiesen;
                    _fsDienstleistungspaket_Zugewiesen = value;
                    FixupFsDienstleistungspaket_Zugewiesen(previousValue);
                    OnNavigationPropertyChanged("FsDienstleistungspaket_Zugewiesen");
                }
            }
        }
        private FsDienstleistungspaket _fsDienstleistungspaket_Zugewiesen;
    
        [DataMember]
        public XUser XUser
        {
            get { return _xUser; }
            set
            {
                if (!ReferenceEquals(_xUser, value))
                {
                    var previousValue = _xUser;
                    _xUser = value;
                    FixupXUser(previousValue);
                    OnNavigationPropertyChanged("XUser");
                }
            }
        }
        private XUser _xUser;

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
            FaLeistung = null;
            FsDienstleistungspaket_Bedarf = null;
            FsDienstleistungspaket_Zugewiesen = null;
            XUser = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupFaLeistung(FaLeistung previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaPhase.Contains(this))
            {
                previousValue.FaPhase.Remove(this);
            }
    
            if (FaLeistung != null)
            {
                if (!FaLeistung.FaPhase.Contains(this))
                {
                    FaLeistung.FaPhase.Add(this);
                }
    
                FaLeistungID = FaLeistung.FaLeistungID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("FaLeistung")
                    && (ChangeTracker.OriginalValues["FaLeistung"] == FaLeistung))
                {
                    ChangeTracker.OriginalValues.Remove("FaLeistung");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("FaLeistung", previousValue);
                }
                if (FaLeistung != null && !FaLeistung.ChangeTracker.ChangeTrackingEnabled)
                {
                    FaLeistung.StartTracking();
                }
            }
        }
    
        private void FixupFsDienstleistungspaket_Bedarf(FsDienstleistungspaket previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaPhase_Bedarf.Contains(this))
            {
                previousValue.FaPhase_Bedarf.Remove(this);
            }
    
            if (FsDienstleistungspaket_Bedarf != null)
            {
                if (!FsDienstleistungspaket_Bedarf.FaPhase_Bedarf.Contains(this))
                {
                    FsDienstleistungspaket_Bedarf.FaPhase_Bedarf.Add(this);
                }
    
                FsDienstleistungspaketID_Bedarf = FsDienstleistungspaket_Bedarf.FsDienstleistungspaketID;
            }
            else if (!skipKeys)
            {
                FsDienstleistungspaketID_Bedarf = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("FsDienstleistungspaket_Bedarf")
                    && (ChangeTracker.OriginalValues["FsDienstleistungspaket_Bedarf"] == FsDienstleistungspaket_Bedarf))
                {
                    ChangeTracker.OriginalValues.Remove("FsDienstleistungspaket_Bedarf");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistungspaket_Bedarf", previousValue);
                }
                if (FsDienstleistungspaket_Bedarf != null && !FsDienstleistungspaket_Bedarf.ChangeTracker.ChangeTrackingEnabled)
                {
                    FsDienstleistungspaket_Bedarf.StartTracking();
                }
            }
        }
    
        private void FixupFsDienstleistungspaket_Zugewiesen(FsDienstleistungspaket previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaPhase_Zugewiesen.Contains(this))
            {
                previousValue.FaPhase_Zugewiesen.Remove(this);
            }
    
            if (FsDienstleistungspaket_Zugewiesen != null)
            {
                if (!FsDienstleistungspaket_Zugewiesen.FaPhase_Zugewiesen.Contains(this))
                {
                    FsDienstleistungspaket_Zugewiesen.FaPhase_Zugewiesen.Add(this);
                }
    
                FsDienstleistungspaketID_Zugewiesen = FsDienstleistungspaket_Zugewiesen.FsDienstleistungspaketID;
            }
            else if (!skipKeys)
            {
                FsDienstleistungspaketID_Zugewiesen = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("FsDienstleistungspaket_Zugewiesen")
                    && (ChangeTracker.OriginalValues["FsDienstleistungspaket_Zugewiesen"] == FsDienstleistungspaket_Zugewiesen))
                {
                    ChangeTracker.OriginalValues.Remove("FsDienstleistungspaket_Zugewiesen");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("FsDienstleistungspaket_Zugewiesen", previousValue);
                }
                if (FsDienstleistungspaket_Zugewiesen != null && !FsDienstleistungspaket_Zugewiesen.ChangeTracker.ChangeTrackingEnabled)
                {
                    FsDienstleistungspaket_Zugewiesen.StartTracking();
                }
            }
        }
    
        private void FixupXUser(XUser previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaPhase.Contains(this))
            {
                previousValue.FaPhase.Remove(this);
            }
    
            if (XUser != null)
            {
                if (!XUser.FaPhase.Contains(this))
                {
                    XUser.FaPhase.Add(this);
                }
    
                UserID = XUser.UserID;
            }
            else if (!skipKeys)
            {
                UserID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("XUser")
                    && (ChangeTracker.OriginalValues["XUser"] == XUser))
                {
                    ChangeTracker.OriginalValues.Remove("XUser");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("XUser", previousValue);
                }
                if (XUser != null && !XUser.ChangeTracker.ChangeTrackingEnabled)
                {
                    XUser.StartTracking();
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
    
    		var entity = (FaPhase)obj;
    		if (!_faPhaseID.Equals(entity.FaPhaseID) || _faPhaseID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _faPhaseID.GetHashCode();
        }

        #endregion

    }
}
