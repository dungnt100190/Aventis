using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Kiss.Infrastructure
{
    public class NotifyPropertyChanged
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Func<PropertyChangedEventHandler> _getRaiseEvent;
        private readonly Dictionary<string, List<string>> _propertyMap;
        private readonly object _sender;

        #endregion

        #endregion

        #region Constructors

        public NotifyPropertyChanged(object sender, Func<PropertyChangedEventHandler> getRaiseEvent)
        {
            _getRaiseEvent = getRaiseEvent;
            _sender = sender;
            _propertyMap = new Dictionary<string, List<string>>();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void AddPropertyMapping(string sourceProperty, string derivedProperty)
        {
            //make sure, we don't have any endless recursions:
            if (sourceProperty == derivedProperty)
            {
                //do nothing, simply return
                return;
            }

            List<string> derivedProperties;
            if (!_propertyMap.TryGetValue(sourceProperty, out derivedProperties))
            {
                derivedProperties = new List<string>();
                _propertyMap.Add(sourceProperty, derivedProperties);
            }

            if (!derivedProperties.Contains(derivedProperty))
            {
                derivedProperties.Add(derivedProperty);
            }
        }

        public void RaisePropertyChanged(string propName)
        {
            var propertyChanged = _getRaiseEvent();

            if (propertyChanged != null)
            {
                propertyChanged(_sender, new PropertyChangedEventArgs(propName));
            }

            List<string> derivedProperties;
            if (_propertyMap != null && _propertyMap.TryGetValue(propName, out derivedProperties))
            {
                derivedProperties.ForEach(RaisePropertyChanged);
            }
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> exp)
        {
            var propertyName = PropertyName.GetPropertyName(exp);

            if (propertyName != null)
            {
                RaisePropertyChanged(propertyName);
            }
        }

        #endregion

        #endregion
    }
}