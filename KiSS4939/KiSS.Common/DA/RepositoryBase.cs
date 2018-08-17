using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.Common.DA
{
    /// <summary>
    /// Abstract Base class of a queryable repository. The goal is to hide the DAL implementation.
    /// </summary>
    /// <typeparam name="T">Type of the Entity</typeparam>
    /// <see cref="http://www.codeinsanity.com/2008/08/implementing-repository-and.html"/>
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        #region Properties

        /// <summary>
        /// Gets the type of element form the repository query (<see cref="IQueryable<T>"/>)
        /// </summary>
        public Type ElementType
        {
            get { return RepositoryQuery.ElementType; }
        }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of the repository query (<see cref="IQueryable<T>"/>)
        /// </summary>
        public System.Linq.Expressions.Expression Expression
        {
            get { return RepositoryQuery.Expression; }
        }

        /// <summary>
        /// Gets the query provider (<see cref="IQueryProvider"/>) that is associated with this data source
        /// </summary>
        public IQueryProvider Provider
        {
            get { return RepositoryQuery.Provider; }
        }

        protected abstract IQueryable<T> RepositoryQuery
        {
            get;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds an item to the repository
        /// </summary>
        /// <param name="item">item to add</param>
        public abstract void Add(T item);

        /// <summary>
        /// Deletes an item from the repository
        /// </summary>
        /// <param name="item">item to delete</param>
        public abstract void Delete(T item);

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator<T>"/> that can be used to iterate through the collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return RepositoryQuery.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> that can be used to iterate through the collection</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return RepositoryQuery.GetEnumerator();
        }

        #endregion

        #endregion
    }
}