using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;

namespace Kiss.BL
{
    /// <summary>
    /// The UnitOfWork is a static class to get <see cref="IRepository{T}"/> or <see cref="IUnitOfWork"/>.
    /// The UnitOfWork defines a context for one or more repositories.
    /// </summary>
    public static class UnitOfWork
    {
        #region Properties

        /// <summary>
        /// Creates always a new UnitOfWork
        /// </summary>
        public static IUnitOfWork GetNew
        {
            get
            {
                var unitOfWorkFactory = Container.Resolve<IUnitOfWorkFactory>();
                return unitOfWorkFactory.Create();
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// If the specified parentUnitOfWork is null, it will create a new UnitOfWork, otherwise it simply returns parentUnitOfWork
        /// </summary>
        public static IUnitOfWork GetNewOrParent(IUnitOfWork parentUnitOfWork)
        {
            if (parentUnitOfWork == null)
            {
                var unitOfWorkFactory = Container.Resolve<IUnitOfWorkFactory>();
                return unitOfWorkFactory.Create();
            }

            return parentUnitOfWork;
        }

        /// <summary>
        /// Returns a Repository using the specified UnitOfWork
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static IRepository<T> GetRepository<T>(IUnitOfWork unitOfWork)
            where T : class
        {
            return Container.Resolve<IRepository<T>>(unitOfWork);
        }

        #endregion

        #endregion
    }
}