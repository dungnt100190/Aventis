using System;
using System.Transactions;

namespace Kiss.BL.Test
{
    public abstract class TransactionTestBase : TestServiceBase
    {
        #region Fields

        #region Protected Fields

        protected TransactionScope _transaction;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Closes the transaction if it exists.
        /// </summary>
        public virtual void TestCleanup()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            ClearObjectContext();
        }

        /// <summary>
        /// Opens a transaction.
        /// </summary>
        public virtual void TestInitialize()
        {
            _transaction = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(1, 0, 0)); // we don't want this timeout to interfere with the unit test
        }

        #endregion

        #endregion
    }
}