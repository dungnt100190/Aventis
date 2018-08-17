using System;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class AbacusConnection
    {
        #region Fields

        private String loginToken;
        private Int32 mandantenNummer;
        private String userLogInName;
        private String userPassword;
        private Uri webServiceUri;

        #endregion

        #region Constructors

        public AbacusConnection(Uri serverUri, string logIn, string passWord, int mandant)
        {
            this.webServiceUri = serverUri;
            this.userLogInName = logIn;
            this.userPassword = passWord;
            this.mandantenNummer = mandant;
        }

        public AbacusConnection(AbacusConnection originalConnection)
        {
            this.userLogInName = originalConnection.userLogInName;
            this.mandantenNummer = originalConnection.mandantenNummer;
            this.userPassword = originalConnection.userPassword;
            this.loginToken = originalConnection.loginToken;
            this.webServiceUri = originalConnection.webServiceUri;
        }

        #endregion

        #region Public Properties

        public String LoginToken
        {
            set { loginToken = value; }
            get { return loginToken; }
        }

        public Int32 MandantenNummer
        {
            get { return mandantenNummer; }
        }

        public Int32 Port
        {
            get { return webServiceUri.Port; }
        }

        public String Url
        {
            get { return webServiceUri.OriginalString; }
        }

        public String UserLogInName
        {
            get { return userLogInName; }
        }

        public String UserPassword
        {
            get { return userPassword; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines whether the given login-token is valid
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is token valid]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsTokenValid()
        {
            // token cannot be null if valid
            if (this.loginToken != null)
            {
                // token has to have some content if valid
                if (this.loginToken.Length > 0)
                {
                    return true;
                }
            }

            // invalid token
            return false;
        }

        /// <summary>
        /// Sets the webservice uri depending on given servicename
        /// </summary>
        /// <param name="serviceName">The service-name to use to connect to Abacus</param>
        public void SetWebServiceUri(String serviceName)
        {
            // set uri to webservice with service
            this.webServiceUri = new Uri(this.webServiceUri.AbsoluteUri + serviceName);
        }

        #endregion
    }
}