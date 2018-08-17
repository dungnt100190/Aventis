using System;
using System.Collections.Generic;

using Kiss.Model;

namespace Kiss.BL.Test
{
    public class ObjectContextMock
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Dictionary<Type, object> _objectSets = new Dictionary<Type, object>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public ObjectSetMock<T> GetOrCreateObjectSet<T>()
            where T : class, IObjectWithChangeTracker
        {
            if (_objectSets.ContainsKey(typeof(T)))
            {
                return (ObjectSetMock<T>)_objectSets[typeof(T)];
            }

            var objectSet = new ObjectSetMock<T>();
            _objectSets.Add(typeof(T), objectSet);

            return objectSet;
        }

        public void ClearObjectSets()
        {
            _objectSets.Clear();
        }

        /// <summary>
        /// Starts the tracking of changes in all entities of the context. It actually only calls MarkAsUnchanged() on all entities. This also starts tracking the changes.
        /// </summary>
        public void StartTrackingAndMarkAsUnchangedAll()
        {
        }

        #endregion

        #endregion
    }
}