using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

using Kiss.Infrastructure;
using Kiss.Interfaces.BL;

namespace Kiss.Model
{
    /// <summary>
    /// A base class for all entities. This implements a set of interfaces.
    /// </summary>
    /// <typeparam name="T">The type of the inheriting class.</typeparam>
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class EntityBase<T> : IValidating<T>, IDataErrorInfo, INotifyPropertyChanged
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        [DataMember]
        private readonly OriginalValuesDictionary _originalValues = new OriginalValuesDictionary();
        [DataMember]
        private readonly List<string> _subscribedPropertyNames = new List<string>();

        #endregion

        #region Private Fields

        private ObjectChangeTracker _changeTracker;
        private NotifyPropertyChanged _notifyPropertyChanged;
        private List<PropertyInfo> _subscribedPropertiesCache;

        #endregion

        #endregion

        #region Constructors

        protected EntityBase()
        {
            ChangeTracker.ObjectStateChanging += ChangeTracker_ObjectStateChanging;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }

        /// <summary>
        /// Validates the entity and gets an error string that contains all messages.
        /// </summary>
        public string Error
        {
            get
            {
                var result = Validate();

                if (result)
                {
                    return null;
                }

                return string.Join(" - ", result.KissServiceResultEntries.Select(e => e.Message));
            }
        }

        /// <summary>
        /// Indicates whether the entity is valid.
        /// </summary>
        public bool IsValid
        {
            get { return Validate(); }
        }

        /// <summary>
        /// Die seit dem letzten Speichern geänderten Properties
        /// </summary>
        public List<PropertyInfo> ModifiedProperties
        {
            get
            {
                var modifiedProperties = new List<PropertyInfo>();
                if (ChangeTracker.State == ObjectState.Modified)
                {
                    foreach (PropertyInfo pi in SubscribedProperties)
                    {
                        object currentValue = pi.GetValue(this, null);
                        object originalValue = _originalValues[pi.Name];
                        if (!AreEqual(currentValue, originalValue))
                        {
                            modifiedProperties.Add(pi);
                        }
                    }
                }

                return modifiedProperties;
            }
        }

        public OriginalValuesDictionary OriginalValues
        {
            get { return _originalValues; }
        }

        /// <summary>
        /// Gets or sets a validator function.
        /// </summary>
        public Func<T, KissServiceResult> Validator
        {
            get;
            set;
        }

        protected NotifyPropertyChanged NotifyPropertyChanged
        {
            get
            {
                return _notifyPropertyChanged ?? (_notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged));
            }
        }

        private IEnumerable<PropertyInfo> SubscribedProperties
        {
            get
            {
                //nach dem deserialisieren ist diese Liste leer. Also muss sie neu geladen werden (aus der Liste _subscribedPropertyNames)
                if (_subscribedPropertiesCache == null)
                {
                    _subscribedPropertiesCache = new List<PropertyInfo>(_subscribedPropertyNames.Count);

                    _subscribedPropertyNames.ForEach(pn => _subscribedPropertiesCache.Add(GetType().GetProperty(pn)));
                }

                return _subscribedPropertiesCache;
            }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets an error string for a specific column/property name.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                var result = Validate();

                if (result)
                {
                    return null;
                }

                var resultEntry = result.KissServiceResultEntries.FirstOrDefault(x => x.PropertyName == columnName);

                return resultEntry != null ? resultEntry.Message : null;
            }
        }

        #endregion

        #region EventHandlers

        private void ChangeTracker_ObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState != ObjectState.Unchanged)
            {
                return;
            }

            _originalValues.Clear();
            foreach (PropertyInfo pi in SubscribedProperties)
            {
                _originalValues.Add(pi.Name, pi.GetValue(this, null));
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected void AddPropertyMapping(string sourceProperty, string derivedProperty)
        {
            NotifyPropertyChanged.AddPropertyMapping(sourceProperty, derivedProperty);
        }

        protected abstract void ClearNavigationProperties();

        protected virtual void OnNavigationPropertyChanged(string propertyName)
        {
            NotifyPropertyChanged.RaisePropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }

            NotifyPropertyChanged.RaisePropertyChanged(propertyName);
        }

        protected void SubscribePropertyName(string propertyName)
        {
            _subscribedPropertyNames.Add(propertyName);
        }

        #endregion

        #region Private Static Methods

        private static bool AreEqual(object currentValue, object originalValue)
        {
            return currentValue != null && currentValue.Equals(originalValue) ||
                   currentValue == null && originalValue == null;
        }

        #endregion

        #region Private Methods

        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }

        private KissServiceResult Validate()
        {
            if (Validator == null)
            {
                return KissServiceResult.Ok();
            }

            return Validator((T)(object)this);
        }

        #endregion

        #endregion
    }
}