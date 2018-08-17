using KiSS.KliBu.DA;

namespace KiSS.KliBu.BL.Test.Mock
{
    internal class MockUnitOfWork : IUnitOfWork
    {
        #region Methods

        #region Public Methods

        public void CloseDbConnection()
        {
            // ignore
        }

        public void OpenDbConnection()
        {
            // ignore
        }

        public void Save()
        {
            // ignore
        }

        #endregion

        #endregion
    }
}