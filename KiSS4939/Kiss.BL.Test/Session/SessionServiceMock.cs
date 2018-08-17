using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;

namespace Kiss.BL.Test.Session
{
    public class SessionServiceMock : ISessionService
    {
        #region Fields

        #region Private Fields

        private IAuthenticatedUser _authenticatedUser;

        #endregion

        #endregion

        #region Properties

        public IAuthenticatedUser AuthenticatedUser
        {
            get { return _authenticatedUser; }
        }

        public string DatabaseName
        {
            get { return null; }
        }

        public bool IsKiss5Mode { get; set; }

        public string ServerName
        {
            get { return null; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Close()
        {
        }

        public void EnsureConnection()
        {
        }

        public void Open(string connectionString, IAuthenticatedUser authenticatedUser, bool openAsync = true, bool passwordIsScrambled = true)
        {
            _authenticatedUser = authenticatedUser;

            Container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactoryMock>(InstanceScope.PerResolve);
            Container.RegisterType(typeof(IRepository<>), typeof(RepositoryMock<>), InstanceScope.PerResolve);

            // We tell the concrete factory what EF model we want to use
            UnitOfWorkFactoryMock.SetObjectContext(() => new ObjectContextMock());
        }

        #endregion

        #endregion
    }
}