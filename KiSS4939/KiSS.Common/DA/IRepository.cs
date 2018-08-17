using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.Common.DA
{
    /// <summary>
    /// Generic queryable repository interface
    /// </summary>
    /// <typeparam name="T">Type of the Entity</typeparam>
    public interface IRepository<T> : IQueryable<T>
    {
        #region Methods

        /// <summary>
        /// Add an item to the <see cref="IRepository<T>"/> object
        /// </summary>
        /// <param name="item">item to add to the repository</param>
        void Add(T item);

        /// <summary>
        /// Delete an item from the <see cref="IRepository<T>"/> object
        /// </summary>
        /// <param name="item">item to delete from the <see cref="IRepository<T>"/></param>
        void Delete(T item);

        #endregion
    }
}