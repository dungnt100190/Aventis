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
    public partial class FaAktennotizen: EntityBase<FaAktennotizen>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int FaAktennotizID
        {
            get { return _faAktennotizID; }
            set
            {
                if (_faAktennotizID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FaAktennotizID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _faAktennotizID = value;
                    OnPropertyChanged("FaAktennotizID");
                }
            }
        }
        private int _faAktennotizID;
    
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
        public Nullable<System.DateTime> Datum
        {
            get { return _datum; }
            set
            {
                if (_datum != value)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        private Nullable<System.DateTime> _datum;
    
        [DataMember]
        public Nullable<System.DateTime> Zeit
        {
            get { return _zeit; }
            set
            {
                if (_zeit != value)
                {
                    _zeit = value;
                    OnPropertyChanged("Zeit");
                }
            }
        }
        private Nullable<System.DateTime> _zeit;
    
        [DataMember]
        public Nullable<int> FaDauerCode
        {
            get { return _faDauerCode; }
            set
            {
                if (_faDauerCode != value)
                {
                    _faDauerCode = value;
                    OnPropertyChanged("FaDauerCode");
                }
            }
        }
        private Nullable<int> _faDauerCode;
    
        [DataMember]
        public Nullable<int> FaGespraechsStatusCode
        {
            get { return _faGespraechsStatusCode; }
            set
            {
                if (_faGespraechsStatusCode != value)
                {
                    _faGespraechsStatusCode = value;
                    OnPropertyChanged("FaGespraechsStatusCode");
                }
            }
        }
        private Nullable<int> _faGespraechsStatusCode;
    
        [DataMember]
        public string FaThemaCodes
        {
            get { return _faThemaCodes; }
            set
            {
                if (_faThemaCodes != value)
                {
                    _faThemaCodes = value;
                    OnPropertyChanged("FaThemaCodes");
                }
            }
        }
        private string _faThemaCodes;
    
        [DataMember]
        public Nullable<int> FaGespraechstypCode
        {
            get { return _faGespraechstypCode; }
            set
            {
                if (_faGespraechstypCode != value)
                {
                    _faGespraechstypCode = value;
                    OnPropertyChanged("FaGespraechstypCode");
                }
            }
        }
        private Nullable<int> _faGespraechstypCode;
    
        [DataMember]
        public string Kontaktpartner
        {
            get { return _kontaktpartner; }
            set
            {
                if (_kontaktpartner != value)
                {
                    _kontaktpartner = value;
                    OnPropertyChanged("Kontaktpartner");
                }
            }
        }
        private string _kontaktpartner;
    
        [DataMember]
        public Nullable<int> AlimentenstelleTypCode
        {
            get { return _alimentenstelleTypCode; }
            set
            {
                if (_alimentenstelleTypCode != value)
                {
                    _alimentenstelleTypCode = value;
                    OnPropertyChanged("AlimentenstelleTypCode");
                }
            }
        }
        private Nullable<int> _alimentenstelleTypCode;
    
        [DataMember]
        public string Stichwort
        {
            get { return _stichwort; }
            set
            {
                if (_stichwort != value)
                {
                    _stichwort = value;
                    OnPropertyChanged("Stichwort");
                }
            }
        }
        private string _stichwort;
    
        [DataMember]
        public string InhaltRTF
        {
            get { return _inhaltRTF; }
            set
            {
                if (_inhaltRTF != value)
                {
                    _inhaltRTF = value;
                    OnPropertyChanged("InhaltRTF");
                }
            }
        }
        private string _inhaltRTF;
    
        [DataMember]
        public bool Vertraulich
        {
            get { return _vertraulich; }
            set
            {
                if (_vertraulich != value)
                {
                    _vertraulich = value;
                    OnPropertyChanged("Vertraulich");
                }
            }
        }
        private bool _vertraulich;
    
        [DataMember]
        public Nullable<bool> BesprechungThema1
        {
            get { return _besprechungThema1; }
            set
            {
                if (_besprechungThema1 != value)
                {
                    _besprechungThema1 = value;
                    OnPropertyChanged("BesprechungThema1");
                }
            }
        }
        private Nullable<bool> _besprechungThema1;
    
        [DataMember]
        public Nullable<bool> BesprechungThema2
        {
            get { return _besprechungThema2; }
            set
            {
                if (_besprechungThema2 != value)
                {
                    _besprechungThema2 = value;
                    OnPropertyChanged("BesprechungThema2");
                }
            }
        }
        private Nullable<bool> _besprechungThema2;
    
        [DataMember]
        public Nullable<bool> BesprechungThema3
        {
            get { return _besprechungThema3; }
            set
            {
                if (_besprechungThema3 != value)
                {
                    _besprechungThema3 = value;
                    OnPropertyChanged("BesprechungThema3");
                }
            }
        }
        private Nullable<bool> _besprechungThema3;
    
        [DataMember]
        public Nullable<bool> BesprechungThema4
        {
            get { return _besprechungThema4; }
            set
            {
                if (_besprechungThema4 != value)
                {
                    _besprechungThema4 = value;
                    OnPropertyChanged("BesprechungThema4");
                }
            }
        }
        private Nullable<bool> _besprechungThema4;
    
        [DataMember]
        public string BesprechungThemaText1
        {
            get { return _besprechungThemaText1; }
            set
            {
                if (_besprechungThemaText1 != value)
                {
                    _besprechungThemaText1 = value;
                    OnPropertyChanged("BesprechungThemaText1");
                }
            }
        }
        private string _besprechungThemaText1;
    
        [DataMember]
        public string BesprechungThemaText2
        {
            get { return _besprechungThemaText2; }
            set
            {
                if (_besprechungThemaText2 != value)
                {
                    _besprechungThemaText2 = value;
                    OnPropertyChanged("BesprechungThemaText2");
                }
            }
        }
        private string _besprechungThemaText2;
    
        [DataMember]
        public string BesprechungThemaText3
        {
            get { return _besprechungThemaText3; }
            set
            {
                if (_besprechungThemaText3 != value)
                {
                    _besprechungThemaText3 = value;
                    OnPropertyChanged("BesprechungThemaText3");
                }
            }
        }
        private string _besprechungThemaText3;
    
        [DataMember]
        public string BesprechungThemaText4
        {
            get { return _besprechungThemaText4; }
            set
            {
                if (_besprechungThemaText4 != value)
                {
                    _besprechungThemaText4 = value;
                    OnPropertyChanged("BesprechungThemaText4");
                }
            }
        }
        private string _besprechungThemaText4;
    
        [DataMember]
        public string BesprechungZiel1
        {
            get { return _besprechungZiel1; }
            set
            {
                if (_besprechungZiel1 != value)
                {
                    _besprechungZiel1 = value;
                    OnPropertyChanged("BesprechungZiel1");
                }
            }
        }
        private string _besprechungZiel1;
    
        [DataMember]
        public string BesprechungZiel2
        {
            get { return _besprechungZiel2; }
            set
            {
                if (_besprechungZiel2 != value)
                {
                    _besprechungZiel2 = value;
                    OnPropertyChanged("BesprechungZiel2");
                }
            }
        }
        private string _besprechungZiel2;
    
        [DataMember]
        public string BesprechungZiel3
        {
            get { return _besprechungZiel3; }
            set
            {
                if (_besprechungZiel3 != value)
                {
                    _besprechungZiel3 = value;
                    OnPropertyChanged("BesprechungZiel3");
                }
            }
        }
        private string _besprechungZiel3;
    
        [DataMember]
        public string BesprechungZiel4
        {
            get { return _besprechungZiel4; }
            set
            {
                if (_besprechungZiel4 != value)
                {
                    _besprechungZiel4 = value;
                    OnPropertyChanged("BesprechungZiel4");
                }
            }
        }
        private string _besprechungZiel4;
    
        [DataMember]
        public Nullable<int> BesprechungZielGrad1
        {
            get { return _besprechungZielGrad1; }
            set
            {
                if (_besprechungZielGrad1 != value)
                {
                    _besprechungZielGrad1 = value;
                    OnPropertyChanged("BesprechungZielGrad1");
                }
            }
        }
        private Nullable<int> _besprechungZielGrad1;
    
        [DataMember]
        public Nullable<int> BesprechungZielGrad2
        {
            get { return _besprechungZielGrad2; }
            set
            {
                if (_besprechungZielGrad2 != value)
                {
                    _besprechungZielGrad2 = value;
                    OnPropertyChanged("BesprechungZielGrad2");
                }
            }
        }
        private Nullable<int> _besprechungZielGrad2;
    
        [DataMember]
        public Nullable<int> BesprechungZielGrad3
        {
            get { return _besprechungZielGrad3; }
            set
            {
                if (_besprechungZielGrad3 != value)
                {
                    _besprechungZielGrad3 = value;
                    OnPropertyChanged("BesprechungZielGrad3");
                }
            }
        }
        private Nullable<int> _besprechungZielGrad3;
    
        [DataMember]
        public Nullable<int> BesprechungZielGrad4
        {
            get { return _besprechungZielGrad4; }
            set
            {
                if (_besprechungZielGrad4 != value)
                {
                    _besprechungZielGrad4 = value;
                    OnPropertyChanged("BesprechungZielGrad4");
                }
            }
        }
        private Nullable<int> _besprechungZielGrad4;
    
        [DataMember]
        public Nullable<int> FaKontaktartCode
        {
            get { return _faKontaktartCode; }
            set
            {
                if (_faKontaktartCode != value)
                {
                    _faKontaktartCode = value;
                    OnPropertyChanged("FaKontaktartCode");
                }
            }
        }
        private Nullable<int> _faKontaktartCode;
    
        [DataMember]
        public string Pendenz1
        {
            get { return _pendenz1; }
            set
            {
                if (_pendenz1 != value)
                {
                    _pendenz1 = value;
                    OnPropertyChanged("Pendenz1");
                }
            }
        }
        private string _pendenz1;
    
        [DataMember]
        public string Pendenz2
        {
            get { return _pendenz2; }
            set
            {
                if (_pendenz2 != value)
                {
                    _pendenz2 = value;
                    OnPropertyChanged("Pendenz2");
                }
            }
        }
        private string _pendenz2;
    
        [DataMember]
        public string Pendenz3
        {
            get { return _pendenz3; }
            set
            {
                if (_pendenz3 != value)
                {
                    _pendenz3 = value;
                    OnPropertyChanged("Pendenz3");
                }
            }
        }
        private string _pendenz3;
    
        [DataMember]
        public string Pendenz4
        {
            get { return _pendenz4; }
            set
            {
                if (_pendenz4 != value)
                {
                    _pendenz4 = value;
                    OnPropertyChanged("Pendenz4");
                }
            }
        }
        private string _pendenz4;
    
        [DataMember]
        public Nullable<bool> PendenzErledigt1
        {
            get { return _pendenzErledigt1; }
            set
            {
                if (_pendenzErledigt1 != value)
                {
                    _pendenzErledigt1 = value;
                    OnPropertyChanged("PendenzErledigt1");
                }
            }
        }
        private Nullable<bool> _pendenzErledigt1;
    
        [DataMember]
        public Nullable<bool> PendenzErledigt2
        {
            get { return _pendenzErledigt2; }
            set
            {
                if (_pendenzErledigt2 != value)
                {
                    _pendenzErledigt2 = value;
                    OnPropertyChanged("PendenzErledigt2");
                }
            }
        }
        private Nullable<bool> _pendenzErledigt2;
    
        [DataMember]
        public Nullable<bool> PendenzErledigt3
        {
            get { return _pendenzErledigt3; }
            set
            {
                if (_pendenzErledigt3 != value)
                {
                    _pendenzErledigt3 = value;
                    OnPropertyChanged("PendenzErledigt3");
                }
            }
        }
        private Nullable<bool> _pendenzErledigt3;
    
        [DataMember]
        public Nullable<bool> PendenzErledigt4
        {
            get { return _pendenzErledigt4; }
            set
            {
                if (_pendenzErledigt4 != value)
                {
                    _pendenzErledigt4 = value;
                    OnPropertyChanged("PendenzErledigt4");
                }
            }
        }
        private Nullable<bool> _pendenzErledigt4;
    
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
        public byte[] FaAktennotizTS
        {
            get { return _faAktennotizTS; }
            set
            {
                if (_faAktennotizTS != value)
                {
                    _faAktennotizTS = value;
                    OnPropertyChanged("FaAktennotizTS");
                }
            }
        }
        private byte[] _faAktennotizTS;
    
        [DataMember]
        public string BaPersonIDs
        {
            get { return _baPersonIDs; }
            set
            {
                if (_baPersonIDs != value)
                {
                    _baPersonIDs = value;
                    OnPropertyChanged("BaPersonIDs");
                }
            }
        }
        private string _baPersonIDs;

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
    
            if (previousValue != null && previousValue.FaAktennotizen.Contains(this))
            {
                previousValue.FaAktennotizen.Remove(this);
            }
    
            if (FaLeistung != null)
            {
                if (!FaLeistung.FaAktennotizen.Contains(this))
                {
                    FaLeistung.FaAktennotizen.Add(this);
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
    
            if (previousValue != null && previousValue.FaAktennotizen.Contains(this))
            {
                previousValue.FaAktennotizen.Remove(this);
            }
    
            if (XUser != null)
            {
                if (!XUser.FaAktennotizen.Contains(this))
                {
                    XUser.FaAktennotizen.Add(this);
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
    
    		var entity = (FaAktennotizen)obj;
    		if (!_faAktennotizID.Equals(entity.FaAktennotizID) || _faAktennotizID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _faAktennotizID.GetHashCode();
        }

        #endregion

    }
}
