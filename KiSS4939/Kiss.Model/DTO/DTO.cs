using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO
{
    [DataContract(IsReference = true)]
    public abstract class DTO : INotifyPropertyChanged
    {
        #region Fields

        #region Private Fields

        private NotifyPropertyChanged _notifyPropertyChanged;

        #endregion

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        protected NotifyPropertyChanged NotifyPropertyChanged
        {
            get
            {
                return _notifyPropertyChanged ?? (_notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged));
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected void AddPropertyMapping(string sourceProperty, string derivedProperty)
        {
            NotifyPropertyChanged.AddPropertyMapping(sourceProperty, derivedProperty);
        }

        /// <summary>
        /// Sets the property and raises the <see cref="PropertyChanged"/> event if it has changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage">The field containing the old value.</param>
        /// <param name="value">The new value.</param>
        /// <param name="property">() => PROPERTY</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, Expression<Func<T>> property)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            NotifyPropertyChanged.RaisePropertyChanged(property);
            return true;
        }

        #endregion

        #endregion
    }
}