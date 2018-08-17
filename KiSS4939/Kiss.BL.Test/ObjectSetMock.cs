using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Transactions;

using Kiss.Model;

namespace Kiss.BL.Test
{
    public class ObjectSetMock<T> : IObjectSet<T>, IList<T>, IEnlistmentNotification
        where T : class, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly TransactionalLock _lock;
        private readonly Dictionary<string, string> _primaryKeyMapping;

        #endregion

        #region Private Fields

        private Transaction _currentTransaction;
        private IList<T> _removedValues = new List<T>();
        private IList<T> _tempValues = new List<T>();
        private IList<T> _values = new List<T>();

        #endregion

        #endregion

        #region Constructors

        public ObjectSetMock()
        {
            _lock = new TransactionalLock();

            // Not all tables are using the default naming rule.
            // This mapping ensures the correct creation of new mock entities.
            _primaryKeyMapping = new Dictionary<string, string>
            {
                { "XUser", "UserID" }
            };
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///   The number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public int Count
        {
            get { return GetValues().Count; }
        }

        /// <summary>
        ///   Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref = "T:System.Linq.IQueryable" /> is executed.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.Type" /> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.
        /// </returns>
        public Type ElementType
        {
            get { return GetValues().AsQueryable().ElementType; }
        }

        /// <summary>
        ///   Gets the expression tree that is associated with the instance of <see cref = "T:System.Linq.IQueryable" />.
        /// </summary>
        /// <returns>
        ///   The <see cref = "T:System.Linq.Expressions.Expression" /> that is associated with this instance of <see cref = "T:System.Linq.IQueryable" />.
        /// </returns>
        public Expression Expression
        {
            get { return GetValues().AsQueryable().Expression; }
        }

        /// <summary>
        ///   Gets a value indicating whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <returns>
        ///   true if the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        ///   Gets the query provider that is associated with this data source.
        /// </summary>
        /// <returns>
        ///   The <see cref = "T:System.Linq.IQueryProvider" /> that is associated with this data source.
        /// </returns>
        public IQueryProvider Provider
        {
            get { return GetValues().AsQueryable().Provider; }
        }

        #endregion

        #region Indexers

        /// <summary>
        ///   Gets or sets the element at the specified index.
        /// </summary>
        /// <returns>
        ///   The element at the specified index.
        /// </returns>
        /// <param name = "index">The zero-based index of the element to get or set.</param>
        /// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see cref = "T:System.Collections.Generic.IList`1" />.</exception>
        /// <exception cref = "T:System.NotSupportedException">The property is set and the <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
        public T this[int index]
        {
            get
            {
                _lock.Lock();

                if (_currentTransaction == null && Transaction.Current == null)
                {
                    return _values[index];
                }

                T temp = GetValues()[index];
                if (_values.Contains(temp))
                {
                    _values.Remove(temp);
                    _tempValues.Add(temp);
                }

                return temp;
            }
            set
            {
                if (_currentTransaction == null && Transaction.Current == null)
                {
                    _values[index] = value;
                    return;
                }

                T temp = GetValues()[index];

                if (_values.Contains(temp))
                {
                    _values.Remove(temp);
                    _tempValues.Add(value);
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Add(T entity)
        {
            _lock.Lock();

            var iEntity = entity as IEntity;

            if (iEntity != null)
            {
                if (iEntity.Id < 1)
                {
                    iEntity.Id = Count == 0 ? 1 : GetValues().Max(c => ((IEntity)c).Id) + 1;
                }
            }
            else
            {
                var typeName = typeof(T).Name;

                PropertyInfo pi = typeof(T).GetProperty(string.Format("{0}ID", typeName));
                // Spezialfall Systemtabellen: bei den IDs fällt das X weg, z.B. XOrgUnit->OrgUnitID, XUser->UserID
                if (pi == null && typeName[0] == 'X')
                {
                    pi = typeof(T).GetProperty(string.Format("{0}ID", typeName.Substring(1)));
                }

                if (pi == null && _primaryKeyMapping.ContainsKey(typeName))
                {
                    pi = typeof(T).GetProperty(_primaryKeyMapping[typeName]);
                }

                if (pi != null && pi.CanWrite && pi.CanRead && pi.PropertyType == typeof(int))
                {
                    int id = (int)pi.GetGetMethod().Invoke(entity, null);
                    if (id < 1)
                    {
                        int newId = Count == 0 ? 1 : (int)GetValues().Max(c => pi.GetGetMethod().Invoke(c, null)) + 1;
                        pi.GetSetMethod().Invoke(entity, new object[] { newId });
                    }
                }
            }

            if (_currentTransaction == null)
            {
                if (Transaction.Current == null)
                {
                    _values.Add(entity);
                    return;
                }

                Enlist();
            }

            _tempValues.Add(entity);
        }

        public void AddObject(T entity)
        {
            // do nothing
        }

        public void ApplyChanges(T entity)
        {
            switch (entity.ChangeTracker.State)
            {
                case ObjectState.Added:
                    Add(entity);
                    break;

                case ObjectState.Deleted:
                    Delete(entity);
                    break;

                case ObjectState.Modified:
                    int i = IndexOf(entity);
                    this[i] = entity;
                    break;

                case ObjectState.Unchanged:
                    break;
            }
        }

        public void Attach(T entity)
        {
            // do nothing
        }

        public void AttachAsModified(T entity)
        {
            if (!Contains(entity))
            {
                throw new InvalidOperationException(entity + " is not in the repository. Attach failed.");
            }
        }

        /// <summary>
        ///   Removes all items from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only. </exception>
        public void Clear()
        {
            foreach (T v in _values)
            {
                Delete(v);
            }
        }

        /// <summary>
        ///   Notifies an enlisted object that a transaction is being committed.
        /// </summary>
        /// <param name = "enlistment">An <see cref = "T:System.Transactions.Enlistment" /> object used to send a response to the transaction manager.</param>
        public void Commit(Enlistment enlistment)
        {
            _values = _values.Union(_tempValues).ToList();
            _currentTransaction = null;
            _tempValues = new List<T>();
            _removedValues = new List<T>();
            _lock.Unlock();
            enlistment.Done();
        }

        /// <summary>
        ///   Determines whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <returns>
        ///   true if <paramref name = "item" /> is found in the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </returns>
        /// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
        public bool Contains(T item)
        {
            return GetValues().Contains(item);
        }

        /// <summary>
        ///   Copies the elements of the <see cref = "T:System.Collections.Generic.ICollection`1" /> to an <see cref = "T:System.Array" />, starting at a particular <see cref = "T:System.Array" /> index.
        /// </summary>
        /// <param name = "array">The one-dimensional <see cref = "T:System.Array" /> that is the destination of the elements copied from <see cref = "T:System.Collections.Generic.ICollection`1" />. The <see cref = "T:System.Array" /> must have zero-based indexing.</param>
        /// <param name = "arrayIndex">The zero-based index in <paramref name = "array" /> at which copying begins.</param>
        /// <exception cref = "T:System.ArgumentNullException"><paramref name = "array" /> is null.</exception>
        /// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "arrayIndex" /> is less than 0.</exception>
        /// <exception cref = "T:System.ArgumentException"><paramref name = "array" /> is multidimensional.-or-The number of elements in the source <see cref = "T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref name = "arrayIndex" /> to the end of the destination <paramref name = "array" />.-or-Type <paramref name = "{T}" /> cannot be cast automatically to the type of the destination <paramref name = "array" />.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            GetValues().CopyTo(array, arrayIndex);
        }

        public void Delete(T entity)
        {
            _lock.Lock();

            if (!Contains(entity))
            {
                throw new InvalidOperationException(entity + " is not an element of the collection");
            }

            if (_currentTransaction == null)
            {
                if (Transaction.Current == null)
                {
                    _values.Remove(entity);
                    return;
                }

                Enlist();
                return;
            }

            if (_values.Contains(entity))
            {
                _values.Remove(entity);
            }

            if (_tempValues.Contains(entity))
            {
                _tempValues.Remove(entity);
            }

            _removedValues.Add(entity);
        }

        public void DeleteObject(T entity)
        {
            // do nothing
        }

        public void Detach(T entity)
        {
            // do nothing
        }

        public void Enlist()
        {
            if (_currentTransaction != null)
            {
                throw new TransactionException("No local current transaction expected while enlisting.");
            }

            _currentTransaction = Transaction.Current;

            if (_currentTransaction.TransactionInformation.Status != TransactionStatus.Active)
            {
                throw new TransactionException(
                    "Active status expected for current transaction while enlisting. Status is: " + _currentTransaction.TransactionInformation.Status);
            }

            _currentTransaction.EnlistVolatile(this, EnlistmentOptions.None);
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
            return GetValues().GetEnumerator();
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

        /// <summary>
        ///   Notifies an enlisted object that the status of a transaction is in doubt.
        /// </summary>
        /// <param name = "enlistment">An <see cref = "T:System.Transactions.Enlistment" /> object used to send a response to the transaction manager.</param>
        public void InDoubt(Enlistment enlistment)
        {
            _lock.Unlock();
            enlistment.Done();
        }

        /// <summary>
        ///   Determines the index of a specific item in the <see cref = "T:System.Collections.Generic.IList`1" />.
        /// </summary>
        /// <returns>
        ///   The index of <paramref name = "item" /> if found in the list; otherwise, -1.
        /// </returns>
        /// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.IList`1" />.</param>
        public int IndexOf(T item)
        {
            return GetValues().IndexOf(item);
        }

        /// <summary>
        ///   Inserts an item to the <see cref = "T:System.Collections.Generic.IList`1" /> at the specified index.
        /// </summary>
        /// <param name = "index">The zero-based index at which <paramref name = "item" /> should be inserted.</param>
        /// <param name = "item">The object to insert into the <see cref = "T:System.Collections.Generic.IList`1" />.</param>
        /// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see cref = "T:System.Collections.Generic.IList`1" />.</exception>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
        public void Insert(int index, T item)
        {
            _tempValues.Insert(index, item);
        }

        public void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector)
        {
            //do nothing here
        }

        public IEnumerable<T> ModifiedEntities()
        {
            return _tempValues;
        }

        /// <summary>
        ///   Notifies an enlisted object that a transaction is being prepared for commitment.
        /// </summary>
        /// <param name = "preparingEnlistment">A <see cref = "T:System.Transactions.PreparingEnlistment" /> object used to send a response to the transaction manager.</param>
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            preparingEnlistment.Prepared();
        }

        /// <summary>
        ///   Removes the first occurrence of a specific object from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///   true if <paramref name = "item" /> was successfully removed from the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name = "item" /> is not found in the original <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        /// <param name = "item">The object to remove from the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            Delete(item);
            return true;
        }

        /// <summary>
        ///   Removes the <see cref = "T:System.Collections.Generic.IList`1" /> item at the specified index.
        /// </summary>
        /// <param name = "index">The zero-based index of the item to remove.</param>
        /// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see cref = "T:System.Collections.Generic.IList`1" />.</exception>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
        public void RemoveAt(int index)
        {
            Delete(GetValues()[index]);
        }

        /// <summary>
        ///   Notifies an enlisted object that a transaction is being rolled back (aborted).
        /// </summary>
        /// <param name = "enlistment">A <see cref = "T:System.Transactions.Enlistment" /> object used to send a response to the transaction manager.</param>
        public void Rollback(Enlistment enlistment)
        {
            _currentTransaction = null;
            _tempValues = new List<T>();
            _values = _values.Union(_removedValues).ToList();
            _lock.Unlock();
            enlistment.Done();
        }

        /// <summary>
        /// Starts the tracking of changes in all entities of the context. It actually only calls MarkAsUnchanged() on all entities. This also starts tracking the changes.
        /// </summary>
        public void StartTrackingAndMarkAsUnchangedAll()
        {
            _values.ToList().ForEach(x => x.MarkAsUnchanged()); // MarkAsUnchanged will also start tracking
        }

        #endregion

        #region Private Methods

        private IList<T> GetValues()
        {
            _lock.Lock();
            if (_currentTransaction == null)
            {
                if (Transaction.Current == null)
                {
                    return _values.ToList();
                }
                //else
                Enlist();
            }

            return _tempValues.Union(_values).ToList();
        }

        #endregion

        #endregion
    }
}