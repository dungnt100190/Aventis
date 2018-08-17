using System.ComponentModel;
using System.Data;
using Kiss.DbContext;

namespace Kiss.UserInterface.ViewModel
{
    public class EntityStateObserver
    {
        public EntityStateObserver(INotifyPropertyChanged entity)
        {
            if (entity != null)
            {
                entity.PropertyChanged += EntityPropertyChanged;
            }

            var entityWrapper = entity as IEntityWrapper<INotifyPropertyChanged>;
            if (entityWrapper != null)
            {
                entityWrapper.WrappedEntity.PropertyChanged += EntityPropertyChanged;
            }

            var autoIdentityEntity = entity as IAutoIdentityEntity<int>;
            if (autoIdentityEntity != null)
            {
                EntityState = (autoIdentityEntity.AutoIdentityID == 0) ? EntityState.Added : EntityState.Unchanged;
            }
            else
            {
                EntityState = EntityState.Unchanged;
            }
        }

        public EntityState EntityState { get; private set; }

        public void SetAdded()
        {
            EntityState = EntityState.Added;
        }

        public void SetModified()
        {
            EntityState = EntityState.Modified;
        }

        internal void SetDeleted()
        {
            EntityState = EntityState.Deleted;
        }

        internal void SetUnchanged()
        {
            EntityState = EntityState.Unchanged;
        }

        internal void SetUnchangedIfModified()
        {
            if (EntityState == EntityState.Modified)
            {
                EntityState = EntityState.Unchanged;
            }
        }

        private void EntityPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (EntityState == EntityState.Unchanged)
            {
                EntityState = EntityState.Modified;
            }
        }
    }
}