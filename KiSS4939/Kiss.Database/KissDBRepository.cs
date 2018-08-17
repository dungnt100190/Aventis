using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.Database
{
    /// <summary>
    ///   Repository for Kiss Entities
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    public class KissDBRepository<T> : IRepository<T>
        where T : class, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ObjectContext _objectContext;

        #endregion

        #region Private Fields

        private IObjectSet<T> _objectSet;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        ///   Der erste Parameter MUSS "arg0" heissen, sonst funktioniert die c'tor-Argumentübergabe des IoC-Containers nicht
        /// </summary>
        /// <param name="arg0"><see cref="IUnitOfWork"/> that contains the Context</param>
        public KissDBRepository(IUnitOfWork arg0)
        {
            _objectContext = ((EFUnitOfWork)arg0).Context;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref = "T:System.Linq.IQueryable" /> is executed.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.Type" /> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.
        /// </returns>
        public Type ElementType
        {
            get
            {
                return ObjectSet.ElementType;
            }
        }

        /// <summary>
        ///   Gets the expression tree that is associated with the instance of <see cref = "T:System.Linq.IQueryable" />.
        /// </summary>
        /// <returns>
        ///   The <see cref = "T:System.Linq.Expressions.Expression" /> that is associated with this instance of <see cref = "T:System.Linq.IQueryable" />.
        /// </returns>
        public Expression Expression
        {
            get
            {
                return ObjectSet.Expression;
            }
        }

        public IQueryable<T> GetQuery
        {
            get
            {
                return ObjectSet;
            }
        }

        public IObjectSet<T> ObjectSet
        {
            get { return _objectSet ?? (_objectSet = _objectContext.CreateObjectSet<T>()); }
        }

        /// <summary>
        ///   Gets the query provider that is associated with this data source.
        /// </summary>
        /// <returns>
        ///   The <see cref = "T:System.Linq.IQueryProvider" /> that is associated with this data source.
        /// </returns>
        public IQueryProvider Provider
        {
            get { return new KissQueryProvider(ObjectSet.Provider); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ApplyChanges(T entity)
        {
            // The entity MUST be detached to be removed from the DB.
            if (entity.ChangeTracker.State == ObjectState.Deleted)
            {
                if (!_objectContext.IsDetached(entity))
                {
                    ((ObjectSet<T>)ObjectSet).Detach(entity);
                }
            }

            (ObjectSet as ObjectSet<T>).ApplyChanges(entity);
        }

        /// <summary>
        ///   Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            return ObjectSet.GetEnumerator();
        }

        /// <summary>
        ///   Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///   An <see cref = "T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #endregion
    }
}