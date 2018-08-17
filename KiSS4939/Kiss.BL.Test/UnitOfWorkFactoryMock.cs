using System;

using Kiss.Interfaces.BL;

namespace Kiss.BL.Test
{
    public class UnitOfWorkFactoryMock : IUnitOfWorkFactory
    {
        #region Fields

        #region Private Static Fields

        private static ObjectContextMock _objectContext;
        private static Func<ObjectContextMock> _objectContextDelegate;

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        public static void SetObjectContext(Func<ObjectContextMock> objectContextDelegate)
        {
            _objectContextDelegate = objectContextDelegate;
        }

        #endregion

        #region Public Methods

        public void ClearContext()
        {
            if (_objectContext != null)
            {
                _objectContext.ClearObjectSets();
                _objectContext = null;
            }
        }

        /// <summary>
        /// Create a new unitOfWork with a static context. We have to keep the the context in case of mocking.
        /// If a new new context is created the objectSet with the test entries are lost.
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork Create()
        {
            if (_objectContext == null)
            {
                _objectContext = _objectContextDelegate();
            }

            return new UnitOfWorkMock(_objectContext);
        }

        #endregion

        #endregion
    }
}