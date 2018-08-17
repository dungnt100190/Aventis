using System.Data;
using System.Data.Objects;
using System.Linq;

namespace Kiss.Model
{
    public static class SelfTrackingEntitiesContextBIAGExtensions
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// BIAG-Extension for STE-Template:
        /// Checks if the given entity is detached from the context
        /// </summary>
        /// <param name="context">the <see cref="ObjectContext"/> to extend</param>
        /// <param name="entity">the entity to check</param>
        public static bool IsDetached<T>(this ObjectContext context, T entity)
        {
            ObjectStateEntry entry;
            return !context.ObjectStateManager.TryGetObjectStateEntry(entity, out entry);
        }

        /// <summary>
        /// BIAG-Extension for STE-Template:
        /// Starts the tracking of changes in all entities of the context. It actually only calls MarkAsUnchanged() on all entities. This also starts tracking the changes.
        /// </summary>
        /// <param name="context">the <see cref="ObjectContext"/> to extend</param>
        public static void StartTrackingAndMarkAsUnchangedAll(this ObjectContext context)
        {
            var allEntites = from e in context.ObjectStateManager
                                .GetObjectStateEntries(~EntityState.Detached)
                             where e.Entity != null && e.Entity is IObjectWithChangeTracker
                             select e.Entity as IObjectWithChangeTracker;

            allEntites.ToList().ForEach(x => x.MarkAsUnchanged());		// MarkAsUnchanged will also start tracking
        }

        #endregion

        #endregion
    }
}