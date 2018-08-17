namespace Kiss.Interfaces.BL
{
    public interface ISessionService
    {
        #region Properties

        IAuthenticatedUser AuthenticatedUser
        {
            get;
        }

        string DatabaseName
        {
            get;
        }

        bool IsKiss5Mode
        {
            get;
            set;
        }

        string ServerName
        {
            get;
        }

        #endregion

        #region Methods

        void Close();

        void EnsureConnection();

        void Open(string connectionString, IAuthenticatedUser authenticatedUser, bool openAsync = true, bool passwordIsScrambled = true);

        #endregion
    }
}