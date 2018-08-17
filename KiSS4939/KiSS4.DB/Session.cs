using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Kiss.BusinessLogic.Log;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using KiSS.DBScheme;
using KiSS4.DB.Cache;
using KiSS4.Messages;
using Microsoft.Win32;
using WPFLocalizeExtension.Engine;

namespace KiSS4.DB
{
    #region Enumerations

    /// <summary>
    /// Environment Type
    /// </summary>
    public enum EnvType
    {
        /// <summary>
        /// Productive.
        /// </summary>
        Prod,

        /// <summary>
        /// Training.
        /// </summary>
        Train,

        /// <summary>
        /// Test.
        /// </summary>
        Test,

        /// <summary>
        /// Development.
        /// </summary>
        Dev
    }

    #endregion Enumerations

    /// <summary>
    /// Static class session.
    /// </summary>
    public static class Session
    {
        #region Fields

        #region Public Static Fields

        public static readonly ArrayList PersistentObjects = new ArrayList();

        #endregion Public Static Fields

        #region Private Static Fields

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static SqlConnection _connection;
        private static SqlQuery _qryUserRight;
        private static StackTrace _stackTrace;
        private static DateTime _transactionStartTime;

        #endregion Private Static Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "Session";
        private const string TYPEFULLNAME = "KiSS4.DB.Session";

        #endregion Private Constant/Read-Only Fields

        #endregion Fields

        #region Constructors

        static Session()
        {
            SupportDynaMask = true;

            Envs = new List<Env>();
            _transactionStartTime = DateTime.MinValue;

            try
            {
                //read all defined environments from AppConfigFile
                Regex rgx = new Regex(@"password=(?<scrambled>[A-Za-z0-9\+/]+=*)"); // matches a password placeholder
                Scrambler scrambler = new Scrambler("KiSS4");
                AppSettingsReader asr = new AppSettingsReader();

                var envCount = 0;
                try
                {
                    envCount = Convert.ToInt32(asr.GetValue("EnvCount", typeof(int)));
                }
                catch
                {
                }

                for (int i = 0; i < envCount; i++)
                {
                    string prefix = "Env" + i;

                    try
                    {
                        string name = Convert.ToString(asr.GetValue(prefix + ".Name", typeof(string)));
                        string envTypeStr = Convert.ToString(asr.GetValue(prefix + ".EnvType", typeof(string)));
                        EnvType envType = (EnvType)Enum.Parse(typeof(EnvType), envTypeStr);
                        string connectionString = Convert.ToString(asr.GetValue(prefix + ".ConnectionString", typeof(string)));

                        Match m = rgx.Match(connectionString);

                        if (m.Success)
                        {
                            Capture cap = m.Groups["scrambled"].Captures[0];
                            string pwPlain = scrambler.DecryptString(cap.Value);

                            connectionString = connectionString.Substring(0, cap.Index) + pwPlain + connectionString.Substring(cap.Index + cap.Length);
                        }

                        Envs.Add(new Env(name, envType, connectionString));
                    }
                    catch (Exception ex)
                    {
                        _logger.Debug(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Occurs when the session is closing.
        /// </summary>
        public static event EventHandler SessionClosing;

        #endregion Events

        #region Properties

        /// <summary>
        /// True if session is open and active
        /// </summary>
        public static bool Active
        {
            get;
            private set;
        }

        public static string ApplicationStartupPath
        {
            get
            {
                if (IsKiss5Mode)
                {
                    return Path.Combine(Application.StartupPath, "KiSS4");
                }

                return Application.StartupPath;
            }
        }

        /// <summary>
        /// BaLandCode Schweiz
        /// </summary>
        public static int BaLandCodeSchweiz
        {
            get;
            private set;
        }

        /// <summary>
        /// Get <see cref="CacheManager"/> to access cached objects
        /// </summary>
        public static CacheManager CacheManager
        {
            get;
            private set;
        }

        /// <summary>
        /// Like <see cref="Application.CommonAppDataRegistry"/>, but without version.
        /// </summary>
        public static RegistryKey CommonAppDataRegistry
        {
            get { return AppDataRegistry(Registry.LocalMachine); }
        }

        /// <summary>
        /// <see cref="CommonAppDataRegistry"/> + Environment.
        /// </summary>
        public static RegistryKey CommonEnvDataRegistry
        {
            get { return EnvDataRegistry(CommonAppDataRegistry); }
        }

        /// <summary>
        /// Gets the default connection used within this session.
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open)
                {
                    // 06.04.2009: Umbau Transaktionen:
                    // transaction = null reicht nicht, es muss auch stacktrace = null ausgeführt werden:
                    //transaction = null;
                    if (Transaction != null)
                    {
                        Rollback();
                    }

                    _connection.Open();

                    ApplicationFacade.DoEvents();
                }

                return _connection;
            }
        }

        /// <summary>
        /// The connection string, decorated with user information.
        /// </summary>
        public static string ConnectionString
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="Env"/> of this session.
        /// </summary>
        public static Env Env
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets all  configured environments.
        /// </summary>
        public static List<Env> Envs
        {
            get;
            private set;
        }

        /// <summary>
        /// Set and get if KiSS is currently translated by user using the translation-dialog (see "KiSS4.Gui.DlgTranslateMask" and "KiSS4.Gui.CtlTranslateMask")
        /// </summary>
        public static bool IsInTranslationDialog
        {
            get;
            set;
        }

        /// <summary>
        /// True if the connection was opened from KiSS 5.
        /// This property can be used to enable custom behavior of a KiSS4 mask in case it is displayed inside KiSS 5.
        /// </summary>
        public static bool IsKiss5Mode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the last used Environment
        /// </summary>
        public static Env LastEnv
        {
            get
            {
                try
                {
                    string lastEnvName = Convert.ToString(UserAppDataRegistry.GetValue("LastEnvironment", null));
                    Env env = GetEnvironment(lastEnvName);

                    if (env != null)
                    {
                        return env;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Debug(ex);
                }

                if (Envs.Count > 0)
                {
                    return Envs[0];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the last used Logon
        /// </summary>
        public static string LastLogon
        {
            get
            {
                return Convert.ToString(UserAppDataRegistry.GetValue("LastLogon", Environment.UserName));
            }
        }

        /// <summary>
        /// Reference to the Kiss Main Form (MDI)
        /// </summary>
        public static Form MainForm
        {
            get;
            set;
        }

        /// <summary>
        /// Support for DynaMask is enabled
        /// </summary>
        public static bool SupportDynaMask
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the active Transaction
        /// </summary>
        public static SqlTransaction Transaction
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a readable representation of the stack trace.
        /// </summary>
        /// <value>The transaction_ stack trace.</value>
        public static string TransactionStackTrace
        {
            get
            {
                if (_stackTrace == null)
                {
                    return null;
                }

                return _stackTrace.ToString();
            }
        }

        /// <summary>
        /// Gets the <see cref="User"/> of this session.
        /// </summary>
        public static User User
        {
            get;
            private set;
        }

        /// <summary>
        /// Like <see cref="Application.UserAppDataRegistry"/>, but without version.
        /// </summary>
        public static RegistryKey UserAppDataRegistry
        {
            get { return AppDataRegistry(Registry.CurrentUser); }
        }

        /// <summary>
        /// <see cref="UserAppDataRegistry"/> + Environment.
        /// </summary>
        public static RegistryKey UserEnvDataRegistry
        {
            get { return EnvDataRegistry(UserAppDataRegistry); }
        }

        #endregion Properties

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Starts a transaction
        /// </summary>
        public static void BeginTransaction()
        {
            if (Transaction != null)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw new Exception("Programmierfehler: Es existiert schon eine laufende Transaktion.");
            }

            _transactionStartTime = DateTime.Now;
            // 06.04.2009: Umbau Transaktionen:
            // Fehler innerhalb BeginTransaction abhandeln
            try
            {
                Transaction = _connection.BeginTransaction();
                _stackTrace = new StackTrace(1);
            }
            catch (Exception ex)
            {
                try
                {
                    if (Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    KissMsg.ShowError(innerEx.Message, innerEx);
                }

                if (Convert.ToInt32(DBUtil.ExecuteScalarSQL("SELECT @@TRANCOUNT")) == 0)
                {
                    Transaction = null;
                    _stackTrace = null;
                }

                KissMsg.ShowError(ex.Message, ex);
                throw new KissCancelException();
            }
        }

        /// <summary>
        /// Close the session
        /// </summary>
        public static void Close()
        {
            // Save Logout in DB-Log
            if (User != null)
            {
                Container.Resolve<UserSessionService>().LogLogoutUser();
            }

            // Close the SessionService (only if session is active)
            if (Active)
            {
                try
                {
                    ISessionService sessionService = Container.Resolve<ISessionService>();
                    sessionService.Close();
                }
                catch (ConfigurationException ex)
                {
                    // Currently we ignore this exception and only log it
                    _logger.Debug(ex);
                    // TODO: Nach Rel 4.3.20 sollte diese Exception nicht mehr auftreten können
                }
            }

            OnSessionClosing();

            // session is no more active (class-members will be immediateliy cleared)
            Active = false;

            // clear class-members
            Env = null;
            User = null;

            if (CacheManager != null)
            {
                CacheManager.ClearCache();
            }

            CacheManager = null;

            // Clear cache -> neue Architektur
            Kiss.BL.Cache.CacheManager.Instance.ClearCache();

            ConnectionString = "";

            try
            {
                if (_connection != null)
                {
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                string sTrace = _stackTrace == null ? string.Empty : _stackTrace.ToString();

                _logger.Warn(string.Format("SessionID: {0}, letzter StackTrace: {1}", DBUtil.ExecuteScalarSQL("SELECT @@SPID"), sTrace), ex);

                KissMsg.ShowError(ex.Message, ex);
            }
            _connection = null;

            IsInTranslationDialog = false;
        }

        /// <summary>
        /// Commit and dispose transaction
        /// </summary>
        public static void Commit()
        {
            // 06.04.2009: Umbau Transaktionen:
            // Fehler auslösen, wenn keine Transaktion gestartet ist
            if (Transaction == null)
            {
                _stackTrace = null;

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw new Exception("Programmierfehler: Es existiert keine laufende Transaktion (Commit).");
            }

            // Commit ausführen
            try
            {
                Transaction.Commit();
                Transaction = null;
                XLog.CreateTransactionLog(TYPEFULLNAME, 2, _stackTrace, _transactionStartTime, DateTime.Now);
                _stackTrace = null;
            }
            catch
            {
                if (Convert.ToInt32(DBUtil.ExecuteScalarSQL("SELECT @@TRANCOUNT")) == 0)
                {
                    Transaction = null;
                    _stackTrace = null;
                }

                throw;
            }
        }

        /// <summary>
        /// Gets the environment for the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Env GetEnvironment(string name)
        {
            foreach (Env e in Envs)
            {
                if (e.Name == name)
                {
                    return e;
                }
            }

            return null;
        }

        /// <summary>
        /// Get the directory of user appdata for KiSS (e.g. "C:\Users\[LogonName]\AppData\Roaming\Diartis\KiSS").
        /// If the directory does not exist yet, the call will try to create it
        /// </summary>
        /// <returns>The directory to use for appdata files of KiSS</returns>
        public static DirectoryInfo GetKissAppDataFolder()
        {
            // combine path , this is the same as used for logging output
            string userAppDataBiagKissFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                            "Diartis",
                                                            "KiSS");

            // create directory if not existing yet
            _logger.Debug("GetKissAppDataFolder() Create directory if not existing yet" + userAppDataBiagKissFolder);
            Directory.CreateDirectory(userAppDataBiagKissFolder);

            // return path
            return new DirectoryInfo(userAppDataBiagKissFolder);
        }

        /// <summary>
        /// Gets the current SubRights of a named Right.
        /// </summary>
        /// <param name="className">ClassName</param>
        /// <param name="rightName">RightName</param>
        /// <param name="mayRead">Return Readright</param>
        /// <param name="mayInsert">Return Insertright</param>
        /// <param name="mayUpdate">Return Updateright</param>
        /// <param name="mayDelete">Return Deleteright</param>
        public static void GetUserRight(
            string className,
            string rightName,
            out bool mayRead,
            out bool mayInsert,
            out bool mayUpdate,
            out bool mayDelete)
        {
            mayRead = false;
            mayInsert = false;
            mayUpdate = false;
            mayDelete = false;

            if (!Active || (DBUtil.IsEmpty(className) && DBUtil.IsEmpty(rightName)) || _qryUserRight == null)
            {
                return;
            }

            if (User.IsUserAdmin)
            {
                mayRead = true;
                mayInsert = true;
                mayUpdate = true;
                mayDelete = true;
            }
            else if (DBUtil.IsEmpty(className) && _qryUserRight.Find(string.Format("RightName = '{0}'", rightName)) ||
                     _qryUserRight.Find(string.Format("ClassName = '{0}' AND RightName = '{1}'", className, rightName)))
            {
                mayRead = true;
                mayInsert = Convert.ToBoolean(_qryUserRight["Ins"]);
                mayUpdate = Convert.ToBoolean(_qryUserRight["Upd"]);
                mayDelete = Convert.ToBoolean(_qryUserRight["Del"]);
            }
        }

        /// <summary>
        /// Gets the current SubRights of a named Right.
        /// </summary>
        /// <param name="rightName">RightName or ClassName</param>
        /// <param name="mayRead">Return Readright</param>
        /// <param name="mayInsert">Return Insertright</param>
        /// <param name="mayUpdate">Return Updateright</param>
        /// <param name="mayDelete">Return Deleteright</param>
        public static void GetUserRight(
            string rightName,
            out bool mayRead,
            out bool mayInsert,
            out bool mayUpdate,
            out bool mayDelete)
        {
            GetUserRight(null, rightName, out mayRead, out mayInsert, out mayUpdate, out mayDelete);
        }

        /// <summary>
        /// Open the Session
        /// </summary>
        /// <remarks>
        /// If logonName is null, the current windows user is assumed.
        /// If logonName corresponds to the current windows user and the password is null, the password is ignored.
        /// </remarks>
        public static void Open(Env environment, string logonName, string password, bool singleSignOn = false, int? userID = null)
        {
            var isAuthorizedViaSso = false;
            const string ssoMessageName = "AnmeldungSSONichtErfolgreich";
            var ssoCultureText = Properties.Resources.Session_AnmeldungSsoNichtErfolgreich;
            const string login2MessageName = "AnmeldungLogin2NichtErfolgreich";
            var login2CultureText = Properties.Resources.Session_AnmeldungLogin2NichtErfolgreich;

            var connectionString = GetFirstStageConnectionString(environment, logonName);

            if (singleSignOn)
            {
                if (!CheckSingleSignOn(connectionString))
                {
                    KissMsg.ShowInfo(CLASSNAME, ssoMessageName, ssoCultureText);
                    return;
                }

                isAuthorizedViaSso = true;

                logonName = SystemInformation.UserName.ToLower();
            }

            // first close any active session
            Close();

            const string messageName = "AnmeldungNichtErfolgreich";
            var cultureText = Properties.Resources.Session_AnmeldungNichtErfolgreich;

            try
            {
                // check if we have any open MDIChildForms > in this case, prevent login again to prevent wrong session for opened data (see: #5909)
                if (MainForm != null && MainForm.MdiChildren.Length > 0)
                {
                    // logging
                    _logger.ErrorFormat("There are open child forms, due to data security any further login is denied. ChildFormsCount='{0}'", MainForm.MdiChildren.Length);

                    // cancel login
                    throw new InvalidOperationException("There are open child forms, due to data security any further login is denied. Please close the child forms first or restart the application.");
                }

                connectionString = GetSecondStageConnectionString(connectionString);

                // Falls das Hinzufügen des Connectionstrings für das zweistufige Loginverfahren nicht erfolgreich war (== null), wird eine Fehlermeldung ausgegeben.
                if (connectionString == null)
                {
                    KissMsg.ShowInfo(CLASSNAME, login2MessageName, login2CultureText);
                    return;
                }

                if (!OpenConnection(connectionString))
                {
                    return;
                }

                // locate user in db
                SqlQuery qryUser;

                try
                {
                    const string getUserSql = @"
                            SELECT USR.*,
                                   ORG.OrgUnitID,
                                   OrgUnitID_Parent = ORG.ParentID,
                                   ORG.RechtsdienstUserID,
                                   OrgChiefID = COALESCE(NULLIF(ORG.ChiefID, USR.UserID), USR.ChiefID, ORG.ChiefID),
                                   lang = ISNULL(LanguageCode, 1)
                            FROM dbo.XUser USR WITH (READUNCOMMITTED)
                              LEFT JOIN dbo.XOrgUnit_User ORU WITH (READUNCOMMITTED) ON ORU.UserID = USR.UserID AND
                                                                                        ORU.OrgUnitMemberCode = 2
                              LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = ORU.OrgUnitID
                            WHERE USR.LogonName = {0}";
                    qryUser = DBUtil.OpenSQL(getUserSql, logonName);
                    if (IsKiss5Mode && qryUser.Count == 0)
                    {
                        // von KiSS5 wird domain\user repliziert
                        qryUser = DBUtil.OpenSQL(getUserSql, SystemInformation.UserDomainName + @"\" + logonName);
                    }
                }
                finally
                {
                    // reset flag
                    Active = false;
                }

                if (qryUser.Count == 0)
                {
                    if (singleSignOn)
                    {
                        KissMsg.ShowInfo(CLASSNAME, ssoMessageName, ssoCultureText);
                        return;
                    }
                    else
                    {
                        KissMsg.ShowInfo(CLASSNAME, messageName, cultureText);
                        return;
                    }
                }

                // no password check if
                // - PasswordHash is null in db
                // - User has chosen SingleSignOn
                if (!DBUtil.IsEmpty(qryUser["passwordHash"]) && !isAuthorizedViaSso)
                {
                    // check if password empty
                    if (password == null)
                    {
                        KissMsg.ShowInfo(CLASSNAME, messageName, cultureText);
                        return;
                    }

                    // compare passwords
                    if (DBUtil.IsEmpty(qryUser["passwordHash"]) ||
                        ScramblePassword(password) != qryUser["passwordHash"].ToString())
                    {
                        KissMsg.ShowInfo(CLASSNAME, messageName, cultureText);
                        return;
                    }
                }

                // is user locked check
                if (DBUtil.IsEmpty(qryUser["IsLocked"]) || Convert.ToBoolean(qryUser["IsLocked"]))
                {
                    KissMsg.ShowInfo(CLASSNAME, messageName, cultureText);
                    return;
                }

                #region DB Version Check

                // check the db-version compatibility with this client-version
                bool isAdmin = Convert.ToBoolean(qryUser["IsUserAdmin"]) || Convert.ToBoolean(qryUser["IsUserBIAGAdmin"]);
                SqlQuery qryDBVersion;

                try
                {
                    // set active to ensure SqlQuery.Fill(...) will work
                    Active = true;
                    qryDBVersion = DBUtil.OpenSQL("EXECUTE dbo.spXDBVersionGetCurrentVersion");
                }
                catch
                {
                    // reset query to ensure handling later
                    qryDBVersion = null;
                }
                finally
                {
                    // reset flag
                    Active = false;
                }

                // validate result
                if (qryDBVersion == null || qryDBVersion.Count < 1)
                {
                    // no db-version entry found, show warning, but keep on going
                    KissMsg.ShowInfo(CLASSNAME,
                                     "DBVersionNichtGefunden",
                                     Properties.Resources.Session_DBVersionNichtGefunden,
                                     isAdmin ? Properties.Resources.Session_DBVersionAdmin : "");

                    if (!isAdmin)
                    {
                        // user has no adminrights, so we won't let him proceed with this unclear version
                        // TODO: Dieses Return muss wieder enabled werden, wenn alle DBs eine Version haben
                        //return;
                    }
                }
                else
                {
                    // we found the latest db-Version, so check it
                    Version dBVersion = new Version(Convert.ToInt32(qryDBVersion["MajorVersion"]), Convert.ToInt32(qryDBVersion["MinorVersion"]), Convert.ToInt32(qryDBVersion["Build"]), Convert.ToInt32(qryDBVersion["Revision"]));
                    Version dBToClientBackwardVersion = new Version(Convert.ToString(qryDBVersion["BackwardCompatibleDownToClientVersion"]));

                    Version clientVersion = new Version(BIAG.AssemblyInfo.GlobalAssemblyInfo.AssemblyVersion);
                    Version clientToDBBackwardVersion = new Version(BIAG.AssemblyInfo.GlobalAssemblyInfo.BackwardCompatibleDownToDBVersion);

                    if (dBVersion < clientToDBBackwardVersion)
                    {
                        // db version is too old, or client too new
                        KissMsg.ShowInfo(CLASSNAME,
                                         "ClientVersionZuNeu",
                                         Properties.Resources.Session_ClientVersionZuNeu,
                                         dBVersion.ToString(),
                                         clientVersion.ToString(),
                                         isAdmin ? Properties.Resources.Session_DBVersionAdmin : "");

                        if (!isAdmin)
                        {
                            // user has no adminrights, so we won't let him proceed with this old version
                            return;
                        }
                    }
                    else if (clientVersion < dBToClientBackwardVersion)
                    {
                        // client version is too old, or db too new
                        KissMsg.ShowInfo(CLASSNAME,
                                         "DBVersionZuNeu",
                                         Properties.Resources.Session_DBVersionZuNeu,
                                         dBVersion.ToString(),
                                         clientVersion.ToString(),
                                         isAdmin ? Properties.Resources.Session_DBVersionAdmin : "");

                        if (!isAdmin)
                        {
                            // user has no adminrights, so we won't let him proceed with this old version
                            return;
                        }
                    }
                }

                #endregion DB Version Check

                // init class-members
                Env = environment;
                User = new User(qryUser.Row);
                CacheManager = new CacheManager();

                // session is now active (class-members are initialized)
                Active = true;

                // save LastEnvironment and LastLogon in registry
                RegistryKey rk = UserAppDataRegistry;
                rk.SetValue("LastEnvironment", Env.Name);
                rk.SetValue("LastLogon", User.LogonName);

                SupportDynaMask = !DBUtil.IsEmpty(DBUtil.ExecuteScalarSQL("SELECT OBJECT_ID('DynaMask')"));
                SupportDynaMask = SupportDynaMask && ((int)DBUtil.ExecuteScalarSQL("SELECT COUNT(1) FROM DynaMask") > 0);

                BaLandCodeSchweiz = DBUtil.GetConfigInt(@"System\Basis\BaLandCode_Schweiz", 147);

                // Check if this user has multiple XUsers
                if (!DBUtil.IsEmpty(DBUtil.ExecuteScalarSQL("SELECT name FROM syscolumns WHERE id = OBJECT_ID('XUser') AND name = 'PrimaryUserID'")))
                {
                    var qryMultipleXUsers = DBUtil.OpenSQL(@"
                            SELECT USR.*,
                                   ORG.OrgUnitID,
                                   OrgUnitID_Parent = ORG.ParentID,
                                   ORG.RechtsdienstUserID,
                                   OrgChiefID = COALESCE(NULLIF(ORG.ChiefID, USR.UserID), USR.ChiefID, ORG.ChiefID),
                                   lang = isNull(LanguageCode, 1),
                                   DisplayName = USR.LogonName + ': ' + ISNULL(USR.FirstName, '') + ISNULL(' ' + USR.LastName, '') + ISNULL(', Team: ' + ORG.ItemName, '')
                            FROM dbo.XUser USR WITH (READUNCOMMITTED)
                              LEFT JOIN dbo.XOrgUnit_User ORU WITH (READUNCOMMITTED) ON ORU.UserID = USR.UserID AND
                                                                                        ORU.OrgUnitMemberCode = 2
                              LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = ORU.OrgUnitID
                            WHERE USR.IsLocked = 0 AND
                                  USR.UserID = {0} OR USR.PrimaryUserID = {0}", User.UserID);

                    if (qryMultipleXUsers.Count > 1)
                    {
                        // yes, this user has multiple XUsers. let him select one
                        userID = userID ?? DlgSelectXUser.GetUser(qryMultipleXUsers);

                        if (userID.HasValue && userID.Value != User.UserID && qryMultipleXUsers.Find(string.Format("UserID = {0}", userID.Value)))
                        {
                            // he has selected a secondary XUser. Overwrite the existing user
                            User = new User(qryMultipleXUsers.Row);
                        }
                    }
                }

                SetThreadCulture(User.LanguageCode);

                //get user rights
                _qryUserRight = DBUtil.OpenSQL(@"
                    --SQLCHECK_IGNORE--
                    SELECT UGR.ClassName,
                            RightName = MAX(COALESCE(" + (SupportDynaMask ? "MSK.MaskName, " : String.Empty) + @"RGT.RightName, UGR.ClassName)),
                            Ins = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayInsert))),
                            Upd = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayUpdate))),
                            Del = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayDelete)))
                    FROM dbo.XUser_UserGroup UUG WITH (READUNCOMMITTED)
                        INNER JOIN dbo.XUserGroup_Right UGR WITH (READUNCOMMITTED) ON UGR.UserGroupID = UUG.UserGroupID
                        LEFT  JOIN dbo.XRight           RGT WITH (READUNCOMMITTED) ON RGT.RightID = UGR.RightID" + (SupportDynaMask ? @"
                        LEFT  JOIN dbo.DynaMask         MSK WITH (READUNCOMMITTED) ON MSK.MaskName = UGR.MaskName" : String.Empty) + @"
                    WHERE UUG.UserID = {0} AND
                            (UGR.RightID IS NULL OR RGT.RightID IS NOT NULL)" + (SupportDynaMask ? @" AND
                            (UGR.MaskName IS NULL OR MSK.MaskName IS NOT NULL)" : String.Empty) + @"
                    GROUP BY UGR.ClassName, RGT.RightID" + (SupportDynaMask ? @", MSK.MaskName" : String.Empty) + @"
                    ORDER BY UGR.ClassName, 2", User.UserID);

                // Load Type Config and Initialize IoC-Container
                LoadTypeConfigAndInitContainer();

                // Open the SessionService
                ISessionService sessionService = Container.Resolve<ISessionService>();
                sessionService.IsKiss5Mode = IsKiss5Mode;
                sessionService.Open(ConnectionString, User, true, false);
            }
            catch (Exception ex)
            {
                // first close session again
                Close();

                // show message
                KissMsg.ShowError(CLASSNAME, messageName, cultureText, ex);
            }
            finally
            {
                if (!Active)
                {
                    Close();
                }
                else
                {
                    // Save Successfull Login in DB-Log
                    Container.Resolve<UserSessionService>().LogLoginUser(User.UserID, logonName);
                }
            }
        }

        /// <summary>
        /// Rollback and dispose transaction
        /// </summary>
        /// <remarks>
        /// Throws an exception if transaction is closed.
        /// </remarks>
        public static void Rollback()
        {
            // 06.04.2009: Umbau Transaktionen:
            // Fehler auslösen, wenn keine Transaktion gestartet ist
            if (Transaction == null)
            {
                _stackTrace = null;

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw new Exception("Programmierfehler: Es existiert keine laufende Transaktion (Rollback).");
            }

            // Rollback ausführen
            try
            {
                Transaction.Rollback();
                Transaction = null;
                XLog.CreateTransactionLog(TYPEFULLNAME, 3, _stackTrace, _transactionStartTime, DateTime.Now);
                _stackTrace = null;
            }
            catch
            {
                if ((int)DBUtil.ExecuteScalarSQL("SELECT @@TRANCOUNT") == 0)
                {
                    Transaction = null;
                    _stackTrace = null;
                }

                throw;
            }
        }

        /// <summary>
        /// Scramble a password for a connection string.
        /// </summary>
        public static string ScramblePassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            return new Scrambler("KiSS4").EncryptString(password);
        }

        /// <summary>
        /// Scramble a user for a connection string.
        /// </summary>
        public static string ScrambleUser(string user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return new Scrambler("KiSSUsr").EncryptString(user);
        }

        /// <summary>
        /// Setzt die Culture auf den ISO-Code in Value2 der 'Sprache'-LOV für den angegebenen Code.
        /// </summary>
        public static void SetThreadCulture(int languageCode)
        {
            // Set thread culture based on language
            CultureInfo culture = null;
            try
            {
                var isoCode = DBUtil.ExecuteScalarSQL(@"
                        SELECT TOP 1 Value2
                        FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                        WHERE LOVName = 'Sprache'
                            AND Code = {0}",
                    languageCode);

                if (!DBUtil.IsEmpty(isoCode))
                {
                    culture = new CultureInfo(isoCode.ToString());
                }
            }
            catch
            {
                // default
                culture = new CultureInfo("de-CH");
            }
            finally
            {
                if (culture != null)
                {
                    User.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                    LocalizeDictionary.Instance.Culture = culture;
                    CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentUICulture;
                    CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
                }
            }
        }

        #endregion Public Static Methods

        #region Private Static Methods

        private static RegistryKey AppDataRegistry(RegistryKey ret)
        {
            ret = ret.CreateSubKey("Software");
            ret = ret.CreateSubKey(Application.CompanyName == "" ? "Diartis AG" : Application.CompanyName);
            ret = ret.CreateSubKey(Application.ProductName == "" ? "KiSS4" : Application.ProductName);

            return ret;
        }

        /// <summary>
        /// Check if the user can do SingleSignOn on the environment.
        /// </summary>
        private static bool CheckSingleSignOn(string connectionString)
        {
            try
            {
                if (!OpenConnection(connectionString))
                {
                    _logger.Info("SSO: no connection possible");
                    return false;
                }

                // Do this to check if there are configvalues for SingleSignOn
                var useSingleSignOn = DBUtil.ExecuteScalarSQLThrowingException(
                    @"SELECT ValueBit
                      FROM dbo.vwXConfig_public
                      WHERE KeyPath = 'System\Allgemein\SingleSignOn';") as bool? ?? false;

                if (!useSingleSignOn)
                {
                    _logger.Info("SSO: user is not allowed to use single sign on");
                    return false;
                }

                // user is not part of a domain -> local user
                if (WindowsIdentity.GetCurrent().User.AccountDomainSid == null)
                {
                    _logger.Info("SSO: user is not part of a domain -> local user");
                    return false;
                }

                // user is logged into the domain
                var domainUsers = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, WindowsIdentity.GetCurrent().User.AccountDomainSid);
                var prin = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                if (!prin.IsInRole(domainUsers))
                {
                    _logger.Info("SSO: user is not part of a domain -> local user (check #2)");
                    return false;
                }

                // check domain if config is not empty
                var domainName = Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(
                    @"SELECT ValueVarchar
                      FROM dbo.vwXConfig_public
                      WHERE KeyPath = 'System\Allgemein\SingleSignOn\Domain';"));
                var domain = domainName.ToUpper().Trim().Replace(".", "-");

                if (!string.IsNullOrEmpty(domain))
                {
                    if (!SystemInformation.UserDomainName.Equals(domain))
                    {
                        _logger.Info("SSO: user is not part of the configured domain");
                        return false;
                    }

                    // Check groups
                    var groups = Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(
                        @"SELECT ValueVarchar
                          FROM dbo.vwXConfig_public
                          WHERE KeyPath = 'System\Allgemein\SingleSignOn\Gruppe';"));

                    if (!string.IsNullOrEmpty(groups))
                    {
                        var userIsInOneOrMoreGroup = false;
                        var listOfGroups = WindowsIdentity.GetCurrent().Groups.ToList();
                        var domainSid = WindowsIdentity.GetCurrent().User.AccountDomainSid;

                        foreach (var group in groups.Trim().Split(Convert.ToChar(";")))
                        {
                            foreach (var itemGroup in listOfGroups)
                            {
                                var groupSecurity = itemGroup.Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
                                var groupDomainSid = groupSecurity == null ? null : groupSecurity.AccountDomainSid;
                                if (groupDomainSid == domainSid && itemGroup.Translate(typeof(NTAccount)).Value.EndsWith(@"\" + group))
                                {
                                    userIsInOneOrMoreGroup = true;
                                    break;
                                }
                            }

                            if (userIsInOneOrMoreGroup)
                            {
                                break;
                            }
                        }

                        if (!userIsInOneOrMoreGroup)
                        {
                            _logger.Info("SSO: user is not part of the configured groups ");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.InfoFormat("SSO: {0}", ex.Message);
                return false;
            }
            finally
            {
                Active = false;
                Close();
            }

            return true;
        }

        private static RegistryKey EnvDataRegistry(RegistryKey ret)
        {
            return ret.CreateSubKey(Env.Name);
        }

        private static string GetFirstStageConnectionString(Env environment, string logonName)
        {
            //Login Environment
            var connectionStringBuilder = new SqlConnectionStringBuilder(environment.ConnectionString);

            // Escape "Connection-String-Injection", z.B. "fmeier;MultipleActiveResultSets=true;"
            logonName = logonName.Replace(";", string.Empty);

            // add Workstation ID to connection string
            connectionStringBuilder.WorkstationID = string.Format("{0}({1})", Environment.MachineName, logonName);

            return connectionStringBuilder.ConnectionString;
        }

        /// <summary>
        /// Holt einen Connection String für die Verbindung mit dem vollwertigen technischen DB-Benutzer.
        /// </summary>
        /// <param name="firstStageConnectionString">Der Connection-String aus dem KiSS-Config-File.</param>
        private static string GetSecondStageConnectionString(string firstStageConnectionString)
        {
            try
            {
                if (!OpenConnection(firstStageConnectionString))
                {
                    _logger.Info("Login 2nd stage: no connection possible");
                    return null;
                }

                var qryLogin = DBUtil.OpenSQL(@"
                    SELECT Username = (SELECT TOP 1 ValueVarchar
                                       FROM dbo.vwXConfig_public
                                       WHERE KeyPath = 'System\Allgemein\Benutzername_TechnischerBenutzer'),
                           Password = (SELECT TOP 1 ValueVarchar
                                       FROM dbo.vwXConfig_public
                                       WHERE KeyPath = 'System\Allgemein\Passwort_TechnischerBenutzer');");

                if (!qryLogin.IsEmpty)
                {
                    var username = qryLogin["Username"] as string;
                    var password = qryLogin["Password"] as string;

                    if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                    {
                        var scramblerPassword = new Scrambler("KiSS4");
                        password = scramblerPassword.DecryptString(password);

                        var scramblerUser = new Scrambler("KiSSUsr");
                        username = scramblerUser.DecryptString(username);

                        var connectionStringBuilder = new SqlConnectionStringBuilder(firstStageConnectionString)
                        {
                            UserID = username,
                            Password = password
                        };
                        return connectionStringBuilder.ConnectionString;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Login 2nd stage", ex);
                firstStageConnectionString = null;
            }
            finally
            {
                Active = false;
                Close();
            }

            // Zweistufiges Login ist entweder nicht konfiguriert oder die Verbindung ist fehlgeschlagen
            // -> Connection-String aus Config-File zurückgeben
            return firstStageConnectionString;
        }

        /// <summary>
        /// Throws ConfigurationErrorsException if configuration can not be loaded
        /// </summary>
        private static void LoadTypeConfigAndInitContainer()
        {
            try
            {
                // Load all Type Config Entries
                SqlQuery qry =
                    DBUtil.OpenSQL(string.Format("SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9} FROM dbo.XTypeConfig;",
                                DBO.XTypeConfig.LookupTypeNamespace,
                                DBO.XTypeConfig.LookupTypeName,
                                DBO.XTypeConfig.LookupTypeAssemblyName,
                                DBO.XTypeConfig.ConcreteCustomTypeNamespace,
                                DBO.XTypeConfig.ConcreteCustomTypeName,
                                DBO.XTypeConfig.ConcreteCustomTypeAssemblyName,
                                DBO.XTypeConfig.ConcreteStandardTypeNamespace,
                                DBO.XTypeConfig.ConcreteStandardTypeName,
                                DBO.XTypeConfig.ConcreteStandardTypeAssemblyName,
                                DBO.XTypeConfig.InstanceScopeCode));

                foreach (DataRow row in qry.DataTable.Rows)
                {
                    string concreteTypeName;
                    string concreteTypeNamespace;
                    string concreteTypeAssemblyName;

                    if (DBUtil.IsEmpty(row[DBO.XTypeConfig.ConcreteCustomTypeName]))
                    {
                        // The custom Type is empty, let's take the standard type
                        concreteTypeNamespace = (string)row[DBO.XTypeConfig.ConcreteStandardTypeNamespace];
                        concreteTypeName = (string)row[DBO.XTypeConfig.ConcreteStandardTypeName];
                        concreteTypeAssemblyName = (string)row[DBO.XTypeConfig.ConcreteStandardTypeAssemblyName];
                    }
                    else
                    {
                        concreteTypeNamespace = (string)row[DBO.XTypeConfig.ConcreteCustomTypeNamespace];
                        concreteTypeName = (string)row[DBO.XTypeConfig.ConcreteCustomTypeName];
                        concreteTypeAssemblyName = (string)row[DBO.XTypeConfig.ConcreteCustomTypeAssemblyName];
                    }

                    var entry = new IoCEntry
                    {
                        LookupTypeNamespace = (string)row[DBO.XTypeConfig.LookupTypeNamespace],
                        LookupTypeName = (string)row[DBO.XTypeConfig.LookupTypeName],
                        LookupTypeAssemblyName = (string)row[DBO.XTypeConfig.LookupTypeAssemblyName],
                        ConcreteTypeNamespace = concreteTypeNamespace,
                        ConcreteTypeName = concreteTypeName,
                        ConcreteTypeAssemblyName = concreteTypeAssemblyName,
                    };

                    var scope = row[DBO.XTypeConfig.InstanceScopeCode];
                    entry.InstanceScope = Enum.IsDefined(typeof(InstanceScope), scope) ? (InstanceScope)scope : Container.DEFAULT_SCOPE;

                    Container.RegisterEntry(entry);
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "LoadTypeConfigAndInitContainer",
                        "Type Configuration (Tabelle XTypeConfig) konnte nicht geladen werden, resp. IoC-Container konnte nicht initialisiert werden"),
                    ex);
            }
        }

        /// <summary>
        /// Executes the session closing event.
        /// </summary>
        private static void OnSessionClosing()
        {
            if (SessionClosing != null)
            {
                SessionClosing(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Opens the connection to the database
        /// </summary>
        /// <returns></returns>
        private static bool OpenConnection(string connectionString)
        {
            ConnectionString = connectionString;

            // establish connection to db
            _connection = new SqlConnection(ConnectionString);

            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                //cover password in connectionString
                int pos = ConnectionString.ToLower().IndexOf("password");

                if (pos >= 0)
                {
                    while (ConnectionString[pos] != ';')
                    {
                        ConnectionString = ConnectionString.Remove(pos, 1);
                    }

                    ConnectionString = ConnectionString.Insert(pos, "password = ???");
                }

                KissMsg.ShowError(CLASSNAME, "FehlerVerbindung", Properties.Resources.Session_FehlerVerbindung, "ConnectionString: " + ConnectionString, ex);
            }

            if (_connection.State != ConnectionState.Open)
            {
                return false;
            }

            // set active to ensure SqlQuery.Fill(...) will work
            Active = true;

            return true;
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}