using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;

namespace Kiss.UI.ViewModel
{
    public class EntityWrapper<TEntity> : DependencyObject
    {

        private bool _selected;
        public event PropertyChangedEventHandler PropertyChanged;

        public EntityWrapper(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity
        {
            get;
            private set;
        }

        public bool Selected 
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler _event = PropertyChanged;
            if (_event != null)
            {
                _event(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
