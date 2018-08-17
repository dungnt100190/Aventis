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
    [KnownType(typeof(XUser))]
    public partial class FaLeistungArchiv: EntityBase<FaLeistungArchiv>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int FaLeistungArchivID
        {
            get { return _faLeistungArchivID; }
            set
            {
                if (_faLeistungArchivID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FaLeistungArchivID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _faLeistungArchivID = value;
                    OnPropertyChanged("FaLeistungArchivID");
                }
            }
        }
        private int _faLeistungArchivID;
    
        [DataMember]
        public int ArchiveID
        {
            get { return _archiveID; }
            set
            {
                if (_archiveID != value)
                {
                    _archiveID = value;
                    OnPropertyChanged("ArchiveID");
                }
            }
        }
        private int _archiveID;
    
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
        public string ArchivNr
        {
            get { return _archivNr; }
            set
            {
                if (_archivNr != value)
                {
                    _archivNr = value;
                    OnPropertyChanged("ArchivNr");
                }
            }
        }
        private string _archivNr;
    
        [DataMember]
        public System.DateTime CheckIn
        {
            get { return _checkIn; }
            set
            {
                if (_checkIn != value)
                {
                    _checkIn = value;
                    OnPropertyChanged("CheckIn");
                }
            }
        }
        private System.DateTime _checkIn;
    
        [DataMember]
        public Nullable<System.DateTime> CheckOut
        {
            get { return _checkOut; }
            set
            {
                if (_checkOut != value)
                {
                    _checkOut = value;
                    OnPropertyChanged("CheckOut");
                }
            }
        }
        private Nullable<System.DateTime> _checkOut;
    
        [DataMember]
        public int CheckInUserID
        {
            get { return _checkInUserID; }
            set
            {
                if (_checkInUserID != value)
                {
                    ChangeTracker.RecordOriginalValue("CheckInUserID", _checkInUserID);
                    if (!IsDeserializing)
                    {
                        if (XUser != null && XUser.UserID != value)
                        {
                            XUser = null;
                        }
                    }
                    _checkInUserID = value;
                    OnPropertyChanged("CheckInUserID");
                }
            }
        }
        private int _checkInUserID;
    
        [DataMember]
        public Nullable<int> CheckOutUserID
        {
            get { return _checkOutUserID; }
            set
            {
                if (_checkOutUserID != value)
                {
                    ChangeTracker.RecordOriginalValue("CheckOutUserID", _checkOutUserID);
                    if (!IsDeserializing)
                    {
                        if (XUser1 != null && XUser1.UserID != value)
                        {
                            XUser1 = null;
                        }
                    }
                    _checkOutUserID = value;
                    OnPropertyChanged("CheckOutUserID");
                }
            }
        }
        private Nullable<int> _checkOutUserID;
    
        [DataMember]
        public byte[] FaLeistungArchivTS
        {
            get { return _faLeistungArchivTS; }
            set
            {
                if (_faLeistungArchivTS != value)
                {
                    _faLeistungArchivTS = value;
                    OnPropertyChanged("FaLeistungArchivTS");
                }
            }
        }
        private byte[] _faLeistungArchivTS;

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
    
        [DataMember]
        public XUser XUser1
        {
            get { return _xUser1; }
            set
            {
                if (!ReferenceEquals(_xUser1, value))
                {
                    var previousValue = _xUser1;
                    _xUser1 = value;
                    FixupXUser1(previousValue);
                    OnNavigationPropertyChanged("XUser1");
                }
            }
        }
        private XUser _xUser1;

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
            XUser = null;
            XUser1 = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupFaLeistung(FaLeistung previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaLeistungArchiv.Contains(this))
            {
                previousValue.FaLeistungArchiv.Remove(this);
            }
    
            if (FaLeistung != null)
            {
                if (!FaLeistung.FaLeistungArchiv.Contains(this))
                {
                    FaLeistung.FaLeistungArchiv.Add(this);
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
    
        private void FixupXUser(XUser previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaLeistungArchiv.Contains(this))
            {
                previousValue.FaLeistungArchiv.Remove(this);
            }
    
            if (XUser != null)
            {
                if (!XUser.FaLeistungArchiv.Contains(this))
                {
                    XUser.FaLeistungArchiv.Add(this);
                }
    
                CheckInUserID = XUser.UserID;
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
    
        private void FixupXUser1(XUser previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FaLeistungArchiv1.Contains(this))
            {
                previousValue.FaLeistungArchiv1.Remove(this);
            }
    
            if (XUser1 != null)
            {
                if (!XUser1.FaLeistungArchiv1.Contains(this))
                {
                    XUser1.FaLeistungArchiv1.Add(this);
                }
    
                CheckOutUserID = XUser1.UserID;
            }
            else if (!skipKeys)
            {
                CheckOutUserID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("XUser1")
                    && (ChangeTracker.OriginalValues["XUser1"] == XUser1))
                {
                    ChangeTracker.OriginalValues.Remove("XUser1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("XUser1", previousValue);
                }
                if (XUser1 != null && !XUser1.ChangeTracker.ChangeTrackingEnabled)
                {
                    XUser1.StartTracking();
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
    
    		var entity = (FaLeistungArchiv)obj;
    		if (!_faLeistungArchivID.Equals(entity.FaLeistungArchivID) || _faLeistungArchivID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _faLeistungArchivID.GetHashCode();
        }

        #endregion

    }
}
