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
    [KnownType(typeof(KesMassnahme))]
    [KnownType(typeof(XUser))]
    [KnownType(typeof(BaInstitution))]
    public partial class KesMandatsfuehrendePerson: EntityBase<KesMandatsfuehrendePerson>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int KesMandatsfuehrendePersonID
        {
            get { return _kesMandatsfuehrendePersonID; }
            set
            {
                if (_kesMandatsfuehrendePersonID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'KesMandatsfuehrendePersonID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _kesMandatsfuehrendePersonID = value;
                    OnPropertyChanged("KesMandatsfuehrendePersonID");
                }
            }
        }
        private int _kesMandatsfuehrendePersonID;
    
        [DataMember]
        public int KesMassnahmeID
        {
            get { return _kesMassnahmeID; }
            set
            {
                if (_kesMassnahmeID != value)
                {
                    ChangeTracker.RecordOriginalValue("KesMassnahmeID", _kesMassnahmeID);
                    if (!IsDeserializing)
                    {
                        if (KesMassnahme != null && KesMassnahme.KesMassnahmeID != value)
                        {
                            KesMassnahme = null;
                        }
                    }
                    _kesMassnahmeID = value;
                    OnPropertyChanged("KesMassnahmeID");
                }
            }
        }
        private int _kesMassnahmeID;
    
        [DataMember]
        public Nullable<System.DateTime> DatumMandatVon
        {
            get { return _datumMandatVon; }
            set
            {
                if (_datumMandatVon != value)
                {
                    _datumMandatVon = value;
                    OnPropertyChanged("DatumMandatVon");
                }
            }
        }
        private Nullable<System.DateTime> _datumMandatVon;
    
        [DataMember]
        public Nullable<System.DateTime> DatumMandatBis
        {
            get { return _datumMandatBis; }
            set
            {
                if (_datumMandatBis != value)
                {
                    _datumMandatBis = value;
                    OnPropertyChanged("DatumMandatBis");
                }
            }
        }
        private Nullable<System.DateTime> _datumMandatBis;
    
        [DataMember]
        public Nullable<int> DocumentID_Ernennungsurkunde
        {
            get { return _documentID_Ernennungsurkunde; }
            set
            {
                if (_documentID_Ernennungsurkunde != value)
                {
                    _documentID_Ernennungsurkunde = value;
                    OnPropertyChanged("DocumentID_Ernennungsurkunde");
                }
            }
        }
        private Nullable<int> _documentID_Ernennungsurkunde;
    
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
        public Nullable<int> KesBeistandsartCode
        {
            get { return _kesBeistandsartCode; }
            set
            {
                if (_kesBeistandsartCode != value)
                {
                    _kesBeistandsartCode = value;
                    OnPropertyChanged("KesBeistandsartCode");
                }
            }
        }
        private Nullable<int> _kesBeistandsartCode;
    
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
        public byte[] KesMandatsfuehrendePersonTS
        {
            get { return _kesMandatsfuehrendePersonTS; }
            set
            {
                if (_kesMandatsfuehrendePersonTS != value)
                {
                    _kesMandatsfuehrendePersonTS = value;
                    OnPropertyChanged("KesMandatsfuehrendePersonTS");
                }
            }
        }
        private byte[] _kesMandatsfuehrendePersonTS;
    
        [DataMember]
        public Nullable<System.DateTime> DatumVorgeschlagenAm
        {
            get { return _datumVorgeschlagenAm; }
            set
            {
                if (_datumVorgeschlagenAm != value)
                {
                    _datumVorgeschlagenAm = value;
                    OnPropertyChanged("DatumVorgeschlagenAm");
                }
            }
        }
        private Nullable<System.DateTime> _datumVorgeschlagenAm;
    
        [DataMember]
        public Nullable<System.DateTime> DatumRechnungsfuehrungVon
        {
            get { return _datumRechnungsfuehrungVon; }
            set
            {
                if (_datumRechnungsfuehrungVon != value)
                {
                    _datumRechnungsfuehrungVon = value;
                    OnPropertyChanged("DatumRechnungsfuehrungVon");
                }
            }
        }
        private Nullable<System.DateTime> _datumRechnungsfuehrungVon;
    
        [DataMember]
        public Nullable<System.DateTime> DatumRechnungsfuehrungBis
        {
            get { return _datumRechnungsfuehrungBis; }
            set
            {
                if (_datumRechnungsfuehrungBis != value)
                {
                    _datumRechnungsfuehrungBis = value;
                    OnPropertyChanged("DatumRechnungsfuehrungBis");
                }
            }
        }
        private Nullable<System.DateTime> _datumRechnungsfuehrungBis;
    
        [DataMember]
        public Nullable<int> BaInstitutionID
        {
            get { return _baInstitutionID; }
            set
            {
                if (_baInstitutionID != value)
                {
                    ChangeTracker.RecordOriginalValue("BaInstitutionID", _baInstitutionID);
                    if (!IsDeserializing)
                    {
                        if (BaInstitution != null && BaInstitution.BaInstitutionID != value)
                        {
                            BaInstitution = null;
                        }
                    }
                    _baInstitutionID = value;
                    OnPropertyChanged("BaInstitutionID");
                }
            }
        }
        private Nullable<int> _baInstitutionID;
    
        [DataMember]
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    OnPropertyChanged("IsDeleted");
                }
            }
        }
        private bool _isDeleted;
    
        [DataMember]
        public Nullable<System.DateTime> DatumErnennungsurkunde
        {
            get { return _datumErnennungsurkunde; }
            set
            {
                if (_datumErnennungsurkunde != value)
                {
                    _datumErnennungsurkunde = value;
                    OnPropertyChanged("DatumErnennungsurkunde");
                }
            }
        }
        private Nullable<System.DateTime> _datumErnennungsurkunde;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public KesMassnahme KesMassnahme
        {
            get { return _kesMassnahme; }
            set
            {
                if (!ReferenceEquals(_kesMassnahme, value))
                {
                    var previousValue = _kesMassnahme;
                    _kesMassnahme = value;
                    FixupKesMassnahme(previousValue);
                    OnNavigationPropertyChanged("KesMassnahme");
                }
            }
        }
        private KesMassnahme _kesMassnahme;
    
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
        public BaInstitution BaInstitution
        {
            get { return _baInstitution; }
            set
            {
                if (!ReferenceEquals(_baInstitution, value))
                {
                    var previousValue = _baInstitution;
                    _baInstitution = value;
                    FixupBaInstitution(previousValue);
                    OnNavigationPropertyChanged("BaInstitution");
                }
            }
        }
        private BaInstitution _baInstitution;

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
            KesMassnahme = null;
            XUser = null;
            BaInstitution = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupKesMassnahme(KesMassnahme previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.KesMandatsfuehrendePerson.Contains(this))
            {
                previousValue.KesMandatsfuehrendePerson.Remove(this);
            }
    
            if (KesMassnahme != null)
            {
                if (!KesMassnahme.KesMandatsfuehrendePerson.Contains(this))
                {
                    KesMassnahme.KesMandatsfuehrendePerson.Add(this);
                }
    
                KesMassnahmeID = KesMassnahme.KesMassnahmeID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("KesMassnahme")
                    && (ChangeTracker.OriginalValues["KesMassnahme"] == KesMassnahme))
                {
                    ChangeTracker.OriginalValues.Remove("KesMassnahme");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("KesMassnahme", previousValue);
                }
                if (KesMassnahme != null && !KesMassnahme.ChangeTracker.ChangeTrackingEnabled)
                {
                    KesMassnahme.StartTracking();
                }
            }
        }
    
        private void FixupXUser(XUser previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.KesMandatsfuehrendePerson.Contains(this))
            {
                previousValue.KesMandatsfuehrendePerson.Remove(this);
            }
    
            if (XUser != null)
            {
                if (!XUser.KesMandatsfuehrendePerson.Contains(this))
                {
                    XUser.KesMandatsfuehrendePerson.Add(this);
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
    
        private void FixupBaInstitution(BaInstitution previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.KesMandatsfuehrendePerson.Contains(this))
            {
                previousValue.KesMandatsfuehrendePerson.Remove(this);
            }
    
            if (BaInstitution != null)
            {
                if (!BaInstitution.KesMandatsfuehrendePerson.Contains(this))
                {
                    BaInstitution.KesMandatsfuehrendePerson.Add(this);
                }
    
                BaInstitutionID = BaInstitution.BaInstitutionID;
            }
            else if (!skipKeys)
            {
                BaInstitutionID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BaInstitution")
                    && (ChangeTracker.OriginalValues["BaInstitution"] == BaInstitution))
                {
                    ChangeTracker.OriginalValues.Remove("BaInstitution");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BaInstitution", previousValue);
                }
                if (BaInstitution != null && !BaInstitution.ChangeTracker.ChangeTrackingEnabled)
                {
                    BaInstitution.StartTracking();
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
    
    		var entity = (KesMandatsfuehrendePerson)obj;
    		if (!_kesMandatsfuehrendePersonID.Equals(entity.KesMandatsfuehrendePersonID) || _kesMandatsfuehrendePersonID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _kesMandatsfuehrendePersonID.GetHashCode();
        }

        #endregion

    }
}
