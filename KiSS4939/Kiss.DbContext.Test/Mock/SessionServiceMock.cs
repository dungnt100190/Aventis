using Kiss.Interfaces.BL;

namespace Kiss.DbContext.Test.Mock
{
    public class SessionServiceMock : ISessionService
    {
        private IAuthenticatedUser _authenticatedUser;

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

        public void Close()
        {
        }

        public void EnsureConnection()
        {
        }

        public void Open(string connectionString, IAuthenticatedUser authenticatedUser, bool openAsync = true, bool passwordIsScrambled = true)
        {
            _authenticatedUser = authenticatedUser;
        }
    }
}