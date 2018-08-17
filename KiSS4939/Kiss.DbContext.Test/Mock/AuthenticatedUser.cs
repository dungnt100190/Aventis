using System.Globalization;

using Kiss.Interfaces.BL;

namespace Kiss.DbContext.Test.Mock
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        #region Properties

        public string CreatorModifier
        {
            get { return "LastName FirstName (1)"; }
        }

        public CultureInfo CurrentCulture
        {
            get { return new CultureInfo("de-CH"); }
        }

        public string FirstName
        {
            get { return "FirstName"; }
        }

        public bool IsUserAdmin
        {
            get { return true; }
        }

        public bool IsUserBIAGAdmin
        {
            get { return true; }
        }

        public int LanguageCode
        {
            get { return 1; }
        }

        public string LastName
        {
            get { return "LastName"; }
        }

        public string LogonName
        {
            get { return "LogonName"; }
        }

        public int UserID
        {
            get { return 1; }
        }

        #endregion
    }
}