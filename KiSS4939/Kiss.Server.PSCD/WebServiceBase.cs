using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

using log4net;
using log4net.Config;

using Kiss.BL;
using Kiss.Interfaces.BL;
using Container = Kiss.Interfaces.IoC.Container;

using KiSS4.DB;

namespace Kiss.Server.PSCD
{
    public abstract class WebServiceBase
    {
        #region Fields

        #region Protected Static Fields

        protected static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #endregion

        #region Constructors

        static WebServiceBase()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        #region Properties

        public string ServerVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        #endregion

        #region Methods

        #region Protected Static Methods

        protected static void InitDBConnection(IAuthenticatedUser authenticatedUser)
        {
            var session = new SessionService();
            var connectionString = ConfigurationManager.ConnectionStrings["KissDB"];
            var scrambler = new Scrambler("KiSS4");
            var csb = new SqlConnectionStringBuilder(connectionString.ConnectionString);
            csb.Password = scrambler.DecryptString(csb.Password);
            session.Open(csb.ConnectionString, authenticatedUser, false);
            Container.RegisterInstance<ISessionService>(session);
        }

        #endregion

        #endregion
    }
}