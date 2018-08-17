using Kiss.Interfaces.BL;

namespace Kiss.BL.Test
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        #region Constructors

        public UnitOfWorkMock(ObjectContextMock context)
        {
            Context = context;
        }

        #endregion

        #region Dispose

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            //do nothing
        }

        #endregion

        #region Properties

        public ObjectContextMock Context
        {
            get;
            private set;
        }

        public bool IsDisposed
        {
            get { return false; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void IncrementScopeLevel()
        {
            // do nothing
        }

        public void OpenConnection()
        {
            //do nothing
        }

        public void SaveChanges()
        {
        }

        /// <summary>
        /// SaveChanges and detect changes before
        /// </summary>
        public void SaveChangesDetectChangesBefore()
        {
            // do nothing
        }

        public void StartTrackingAndMarkAsUnchangedAll()
        {
            // do nothing
        }

        #endregion

        #endregion
    }
}