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
    [KnownType(typeof(XUser))]
    [KnownType(typeof(XUserGroup))]
    public partial class XUser_UserGroup: EntityBase<XUser_UserGroup>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int XUser_UserGroupID
        {
            get { return _xUser_UserGroupID; }
            set
            {
                if (_xUser_UserGroupID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'XUser_UserGroupID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _xUser_UserGroupID = value;
                    OnPropertyChanged("XUser_UserGroupID");
                }
            }
        }
        private int _xUser_UserGroupID;
    
        [DataMember]
        public int UserID
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
        private int _userID;
    
        [DataMember]
        public int UserGroupID
        {
            get { return _userGroupID; }
            set
            {
                if (_userGroupID != value)
                {
                    ChangeTracker.RecordOriginalValue("UserGroupID", _userGroupID);
                    if (!IsDeserializing)
                    {
                        if (XUserGroup != null && XUserGroup.UserGroupID != value)
                        {
                            XUserGroup = null;
                        }
                    }
                    _userGroupID = value;
                    OnPropertyChanged("UserGroupID");
                }
            }
        }
        private int _userGroupID;
    
        [DataMember]
        public byte[] XUser_UserGroupTS
        {
            get { return _xUser_UserGroupTS; }
            set
            {
                if (_xUser_UserGroupTS != value)
                {
                    _xUser_UserGroupTS = value;
                    OnPropertyChanged("XUser_UserGroupTS");
                }
            }
        }
        private byte[] _xUser_UserGroupTS;

        #endregion

        #region Navigation Properties
    
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
        public XUserGroup XUserGroup
        {
            get { return _xUserGroup; }
            set
            {
                if (!ReferenceEquals(_xUserGroup, value))
                {
                    var previousValue = _xUserGroup;
                    _xUserGroup = value;
                    FixupXUserGroup(previousValue);
                    OnNavigationPropertyChanged("XUserGroup");
                }
            }
        }
        private XUserGroup _xUserGroup;

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
            XUser = null;
            XUserGroup = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupXUser(XUser previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.XUser_UserGroup.Contains(this))
            {
                previousValue.XUser_UserGroup.Remove(this);
            }
    
            if (XUser != null)
            {
                if (!XUser.XUser_UserGroup.Contains(this))
                {
                    XUser.XUser_UserGroup.Add(this);
                }
    
                UserID = XUser.UserID;
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
    
        private void FixupXUserGroup(XUserGroup previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.XUser_UserGroup.Contains(this))
            {
                previousValue.XUser_UserGroup.Remove(this);
            }
    
            if (XUserGroup != null)
            {
                if (!XUserGroup.XUser_UserGroup.Contains(this))
                {
                    XUserGroup.XUser_UserGroup.Add(this);
                }
    
                UserGroupID = XUserGroup.UserGroupID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("XUserGroup")
                    && (ChangeTracker.OriginalValues["XUserGroup"] == XUserGroup))
                {
                    ChangeTracker.OriginalValues.Remove("XUserGroup");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("XUserGroup", previousValue);
                }
                if (XUserGroup != null && !XUserGroup.ChangeTracker.ChangeTrackingEnabled)
                {
                    XUserGroup.StartTracking();
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
    
    		var entity = (XUser_UserGroup)obj;
    		if (!_xUser_UserGroupID.Equals(entity.XUser_UserGroupID) || _xUser_UserGroupID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _xUser_UserGroupID.GetHashCode();
        }

        #endregion

    }
}