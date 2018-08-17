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
    public partial class KesPraevention: EntityBase<KesPraevention>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int KesPraeventionID
        {
            get { return _kesPraeventionID; }
            set
            {
                if (_kesPraeventionID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'KesPraeventionID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _kesPraeventionID = value;
                    OnPropertyChanged("KesPraeventionID");
                }
            }
        }
        private int _kesPraeventionID;
    
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
        public Nullable<int> KesPraeventionsartCode
        {
            get { return _kesPraeventionsartCode; }
            set
            {
                if (_kesPraeventionsartCode != value)
                {
                    _kesPraeventionsartCode = value;
                    OnPropertyChanged("KesPraeventionsartCode");
                }
            }
        }
        private Nullable<int> _kesPraeventionsartCode;
    
        [DataMember]
        public Nullable<int> KesPraeventionsabschlussCode
        {
            get { return _kesPraeventionsabschlussCode; }
            set
            {
                if (_kesPraeventionsabschlussCode != value)
                {
                    _kesPraeventionsabschlussCode = value;
                    OnPropertyChanged("KesPraeventionsabschlussCode");
                }
            }
        }
        private Nullable<int> _kesPraeventionsabschlussCode;
    
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
        public byte[] KesPraeventionTS
        {
            get { return _kesPraeventionTS; }
            set
            {
                if (_kesPraeventionTS != value)
                {
                    _kesPraeventionTS = value;
                    OnPropertyChanged("KesPraeventionTS");
                }
            }
        }
        private byte[] _kesPraeventionTS;

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
        }

        #endregion

        #region Association Fixup
    
        private void FixupFaLeistung(FaLeistung previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.KesPraevention.Contains(this))
            {
                previousValue.KesPraevention.Remove(this);
            }
    
            if (FaLeistung != null)
            {
                if (!FaLeistung.KesPraevention.Contains(this))
                {
                    FaLeistung.KesPraevention.Add(this);
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
    
        private void FixupXUser(XUser previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.KesPraevention.Contains(this))
            {
                previousValue.KesPraevention.Remove(this);
            }
    
            if (XUser != null)
            {
                if (!XUser.KesPraevention.Contains(this))
                {
                    XUser.KesPraevention.Add(this);
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
    
    		var entity = (KesPraevention)obj;
    		if (!_kesPraeventionID.Equals(entity.KesPraeventionID) || _kesPraeventionID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _kesPraeventionID.GetHashCode();
        }

        #endregion

    }
}
