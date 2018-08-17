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
    public partial class XDBVersion: EntityBase<XDBVersion>, IObjectWithChangeTracker
    {
        #region Primitive Properties
    
        [DataMember]
        public int XDBVersionID
        {
            get { return _xDBVersionID; }
            set
            {
                if (_xDBVersionID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'XDBVersionID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _xDBVersionID = value;
                    OnPropertyChanged("XDBVersionID");
                }
            }
        }
        private int _xDBVersionID;
    
        [DataMember]
        public int MajorVersion
        {
            get { return _majorVersion; }
            set
            {
                if (_majorVersion != value)
                {
                    _majorVersion = value;
                    OnPropertyChanged("MajorVersion");
                }
            }
        }
        private int _majorVersion;
    
        [DataMember]
        public int MinorVersion
        {
            get { return _minorVersion; }
            set
            {
                if (_minorVersion != value)
                {
                    _minorVersion = value;
                    OnPropertyChanged("MinorVersion");
                }
            }
        }
        private int _minorVersion;
    
        [DataMember]
        public int Build
        {
            get { return _build; }
            set
            {
                if (_build != value)
                {
                    _build = value;
                    OnPropertyChanged("Build");
                }
            }
        }
        private int _build;
    
        [DataMember]
        public int Revision
        {
            get { return _revision; }
            set
            {
                if (_revision != value)
                {
                    _revision = value;
                    OnPropertyChanged("Revision");
                }
            }
        }
        private int _revision;
    
        [DataMember]
        public System.DateTime VersionDate
        {
            get { return _versionDate; }
            set
            {
                if (_versionDate != value)
                {
                    _versionDate = value;
                    OnPropertyChanged("VersionDate");
                }
            }
        }
        private System.DateTime _versionDate;
    
        [DataMember]
        public string SQLServerVersionInfo
        {
            get { return _sQLServerVersionInfo; }
            set
            {
                if (_sQLServerVersionInfo != value)
                {
                    _sQLServerVersionInfo = value;
                    OnPropertyChanged("SQLServerVersionInfo");
                }
            }
        }
        private string _sQLServerVersionInfo;
    
        [DataMember]
        public string ChangesSinceLastVersion
        {
            get { return _changesSinceLastVersion; }
            set
            {
                if (_changesSinceLastVersion != value)
                {
                    _changesSinceLastVersion = value;
                    OnPropertyChanged("ChangesSinceLastVersion");
                }
            }
        }
        private string _changesSinceLastVersion;
    
        [DataMember]
        public string BackwardCompatibleDownToClientVersion
        {
            get { return _backwardCompatibleDownToClientVersion; }
            set
            {
                if (_backwardCompatibleDownToClientVersion != value)
                {
                    _backwardCompatibleDownToClientVersion = value;
                    OnPropertyChanged("BackwardCompatibleDownToClientVersion");
                }
            }
        }
        private string _backwardCompatibleDownToClientVersion;
    
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
        public byte[] XDBVersionTS
        {
            get { return _xDBVersionTS; }
            set
            {
                if (_xDBVersionTS != value)
                {
                    _xDBVersionTS = value;
                    OnPropertyChanged("XDBVersionTS");
                }
            }
        }
        private byte[] _xDBVersionTS;

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
    
    		var entity = (XDBVersion)obj;
    		if (!_xDBVersionID.Equals(entity.XDBVersionID) || _xDBVersionID == 0)
    		{
    			return false;
    		}
    		
    		return true;
    	}
    	
    	public override int GetHashCode()
        {
            return _xDBVersionID.GetHashCode();
        }

        #endregion

    }
}
