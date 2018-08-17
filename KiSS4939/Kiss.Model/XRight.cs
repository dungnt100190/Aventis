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
    [KnownType(typeof(XClass))]
    [KnownType(typeof(XUserGroup_Right))]
    public partial class XRight: EntityBase<XRight>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int RightID
        {
            get { return _rightID; }
            set
            {
                if (_rightID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'RightID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _rightID = value;
                    OnPropertyChanged("RightID");
                }
            }
        }
        private int _rightID;
    
        [DataMember]
        public int XClassID
        {
            get { return _xClassID; }
            set
            {
                if (_xClassID != value)
                {
                    ChangeTracker.RecordOriginalValue("XClassID", _xClassID);
                    if (!IsDeserializing)
                    {
                        if (XClass != null && XClass.XClassID != value)
                        {
                            XClass = null;
                        }
                    }
                    _xClassID = value;
                    OnPropertyChanged("XClassID");
                }
            }
        }
        private int _xClassID;
    
        [DataMember]
        public string ClassName
        {
            get { return _className; }
            set
            {
                if (_className != value)
                {
                    _className = value;
                    OnPropertyChanged("ClassName");
                }
            }
        }
        private string _className;
    
        [DataMember]
        public string RightName
        {
            get { return _rightName; }
            set
            {
                if (_rightName != value)
                {
                    _rightName = value;
                    OnPropertyChanged("RightName");
                }
            }
        }
        private string _rightName;
    
        [DataMember]
        public string UserText
        {
            get { return _userText; }
            set
            {
                if (_userText != value)
                {
                    _userText = value;
                    OnPropertyChanged("UserText");
                }
            }
        }
        private string _userText;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
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
        public byte[] XRightTS
        {
            get { return _xRightTS; }
            set
            {
                if (_xRightTS != value)
                {
                    _xRightTS = value;
                    OnPropertyChanged("XRightTS");
                }
            }
        }
        private byte[] _xRightTS;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public XClass XClass
        {
            get { return _xClass; }
            set
            {
                if (!ReferenceEquals(_xClass, value))
                {
                    var previousValue = _xClass;
                    _xClass = value;
                    FixupXClass(previousValue);
                    OnNavigationPropertyChanged("XClass");
                }
            }
        }
        private XClass _xClass;
    
        [DataMember]
        public TrackableCollection<XUserGroup_Right> XUserGroup_Right
        {
            get
            {
                if (_xUserGroup_Right == null)
                {
                    _xUserGroup_Right = new TrackableCollection<XUserGroup_Right>();
                    _xUserGroup_Right.CollectionChanged += FixupXUserGroup_Right;
                }
                return _xUserGroup_Right;
            }
            set
            {
                if (!ReferenceEquals(_xUserGroup_Right, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_xUserGroup_Right != null)
                    {
                        _xUserGroup_Right.CollectionChanged -= FixupXUserGroup_Right;
                    }
                    _xUserGroup_Right = value;
                    if (_xUserGroup_Right != null)
                    {
                        _xUserGroup_Right.CollectionChanged += FixupXUserGroup_Right;
                    }
                    OnNavigationPropertyChanged("XUserGroup_Right");
                }
            }
        }
        private TrackableCollection<XUserGroup_Right> _xUserGroup_Right;

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
            XClass = null;
            XUserGroup_Right.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupXClass(XClass previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.XRight.Contains(this))
            {
                previousValue.XRight.Remove(this);
            }
    
            if (XClass != null)
            {
                if (!XClass.XRight.Contains(this))
                {
                    XClass.XRight.Add(this);
                }
    
                XClassID = XClass.XClassID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("XClass")
                    && (ChangeTracker.OriginalValues["XClass"] == XClass))
                {
                    ChangeTracker.OriginalValues.Remove("XClass");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("XClass", previousValue);
                }
                if (XClass != null && !XClass.ChangeTracker.ChangeTrackingEnabled)
                {
                    XClass.StartTracking();
                }
            }
        }
    
        private void FixupXUserGroup_Right(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (XUserGroup_Right item in e.NewItems)
                {
                    item.XRight = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("XUserGroup_Right", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (XUserGroup_Right item in e.OldItems)
                {
                    if (ReferenceEquals(item.XRight, this))
                    {
                        item.XRight = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("XUserGroup_Right", item);
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
    
    		var entity = (XRight)obj;
    		if (!_rightID.Equals(entity.RightID) || _rightID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _rightID.GetHashCode();
        }

        #endregion

    }
}
