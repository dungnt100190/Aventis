//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kiss.DbContext
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(XUser))]
    public partial class ServiceCall : PocoEntity, IAutoIdentityEntity<int>, IAuditableEntity
    {
        public int AutoIdentityID 
        {
            get{ return ServiceCallID; } 
        }
    
        [DataMember]
        private int _serviceCallID;
        public int ServiceCallID
        {
            get { return _serviceCallID; }
            set
            {
                if (_serviceCallID != value)
                {
                    _serviceCallID = value;
                    RaisePropertyChanged("ServiceCallID");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _userID;
        public Nullable<int> UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    RaisePropertyChanged("UserID");
                    if (XUser != null && XUser.UserID != value)
                    {
                        XUser = null;
                    }
                }
            }
        }
    
        [DataMember]
        private string _machineName;
        public string MachineName
        {
            get { return _machineName; }
            set
            {
                if (_machineName != value)
                {
                    _machineName = value;
                    RaisePropertyChanged("MachineName");
                }
            }
        }
    
        [DataMember]
        private string _serviceName;
        public string ServiceName
        {
            get { return _serviceName; }
            set
            {
                if (_serviceName != value)
                {
                    _serviceName = value;
                    RaisePropertyChanged("ServiceName");
                }
            }
        }
    
        [DataMember]
        private string _methodName;
        public string MethodName
        {
            get { return _methodName; }
            set
            {
                if (_methodName != value)
                {
                    _methodName = value;
                    RaisePropertyChanged("MethodName");
                }
            }
        }
    
        [DataMember]
        private string _serviceParam;
        public string ServiceParam
        {
            get { return _serviceParam; }
            set
            {
                if (_serviceParam != value)
                {
                    _serviceParam = value;
                    RaisePropertyChanged("ServiceParam");
                }
            }
        }
    
        [DataMember]
        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                if (_info != value)
                {
                    _info = value;
                    RaisePropertyChanged("Info");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _serviceStart;
        public Nullable<System.DateTime> ServiceStart
        {
            get { return _serviceStart; }
            set
            {
                if (_serviceStart != value)
                {
                    _serviceStart = value;
                    RaisePropertyChanged("ServiceStart");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _serviceEnd;
        public Nullable<System.DateTime> ServiceEnd
        {
            get { return _serviceEnd; }
            set
            {
                if (_serviceEnd != value)
                {
                    _serviceEnd = value;
                    RaisePropertyChanged("ServiceEnd");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _serviceResultTypeCode;
        public Nullable<int> ServiceResultTypeCode
        {
            get { return _serviceResultTypeCode; }
            set
            {
                if (_serviceResultTypeCode != value)
                {
                    _serviceResultTypeCode = value;
                    RaisePropertyChanged("ServiceResultTypeCode");
                }
            }
        }
    
        [DataMember]
        private string _creator;
        public string Creator
        {
            get { return _creator; }
            set
            {
                if (_creator != value)
                {
                    _creator = value;
                    RaisePropertyChanged("Creator");
                }
            }
        }
    
        [DataMember]
        private System.DateTime _created;
        public System.DateTime Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    RaisePropertyChanged("Created");
                }
            }
        }
    
        [DataMember]
        private string _modifier;
        public string Modifier
        {
            get { return _modifier; }
            set
            {
                if (_modifier != value)
                {
                    _modifier = value;
                    RaisePropertyChanged("Modifier");
                }
            }
        }
    
        [DataMember]
        private System.DateTime _modified;
        public System.DateTime Modified
        {
            get { return _modified; }
            set
            {
                if (_modified != value)
                {
                    _modified = value;
                    RaisePropertyChanged("Modified");
                }
            }
        }
    
        [DataMember]
        private byte[] _serviceCallTS;
        public byte[] ServiceCallTS
        {
            get { return _serviceCallTS; }
            set
            {
                if (_serviceCallTS != value)
                {
                    _serviceCallTS = value;
                    RaisePropertyChanged("ServiceCallTS");
                }
            }
        }
    
    
        [DataMember]
        private XUser _xUser;
        public virtual XUser XUser
        {
            get { return _xUser; }
            set
            {
                if (_xUser != value)
                {
                    _xUser = value;
                    RaisePropertyChanged("XUser");
    
                    if (value != null)
                    {
                        UserID = value.UserID;
                    }
                }
            }
        }
    }
    
}