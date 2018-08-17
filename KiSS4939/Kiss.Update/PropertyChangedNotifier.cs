using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Kiss.Update
{
    public class PropertyChangedNotifier : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        #region Protected Methods

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void SetValue<T>(ref T oldValue, T newValue, Expression<Func<T>> property)
        {
            if (Equals(oldValue, newValue))
            {
                return;
            }
            oldValue = newValue;
            var body = (MemberExpression)property.Body;
            OnPropertyChanged(body.Member.Name);
        }

        #endregion

        #endregion
    }
}