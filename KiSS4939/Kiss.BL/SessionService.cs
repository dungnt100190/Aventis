using System;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;

using Kiss.BL.KissSystem;
using Kiss.DataAccess;
using Kiss.Database;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;
using IUnitOfWorkFactory = Kiss.Interfaces.BL.IUnitOfWorkFactory;

namespace Kiss.BL
{
    public class SessionService : ServiceBase, ISessionService
    {
        private static IAuthenticatedUser _authenticatedUser;
        private static Thread _initDBConnectionAsyncThread;
        private static bool _isKiss5Mode;

        private EntityConnection _entityConnection;

        public IAuthenticatedUser AuthenticatedUser
        {
            get { return _authenticatedUser; }
        }

        public string DatabaseName
        {
            get { return SystemService.GetActualDbName(null); }
        }

        public bool IsKiss5Mode
        {
            get { return _isKiss5Mode; }
            set { _isKiss5Mode = value; }
        }

        public string ServerName
        {
            get { return SystemService.GetActualServerName(null); }
        }

        /// <summary>
        /// Closes the DB connection
        /// </summary>
        public void Close()
        {
            _authenticatedUser = null;
            if (_entityConnection != null)
            {
                _entityConnection.Close();
                _entityConnection = null;
            }
        }

        public void EnsureConnection()
        {
            // Zuerst prüfen, ob Connection offen ist.
            // Wenn nicht, dann versuchen wir die Connection wieder zu öffnen.
            // Das kann vorkommen, dass die Connection wegen Netzwerkfehler geschlossen ist
            // Wenn der Netzwerkfehler vorbei ist, dann wollen wir ja nicht KiSS neu starten müssen.
            if (_entityConnection.State != ConnectionState.Open)
            {
                _entityConnection.Close();
                _entityConnection.Open();
                Debug.WriteLine("Connection reopened.");
            }
        }

        /// <summary>
        /// Opens the DB connection, sets the authentificated user and tells that <see cref="EFUnitOfWorkFactory"/> has to be used
        /// </summary>
        /// <param name="connectionString">the DB connection string</param>
        /// <param name="authenticatedUser">the autenticated user</param>
        /// <param name="openAsync">Freiwilliger parameter, ob die Connection asynchron geöffnet werden soll. default ist true</param>
        /// <param name="passwordIsScrambled">Bestimmt, ob das im connectionString übergebene Passwort noch verschlüsselt ist oder von einer legacy-Funktion bereits entschlüsselt wurde. default ist true</param>
        public void Open(string connectionString, IAuthenticatedUser authenticatedUser, bool openAsync = true, bool passwordIsScrambled = true)
        {
            try
            {
                // Register interfaces
                Container.RegisterType<IUnitOfWorkFactory, EFUnitOfWorkFactory>();
                Container.RegisterType(typeof(Interfaces.Database.IRepository<>), typeof(KissDBRepository<>), InstanceScope.PerResolve);

                // Set the property "MultipleActiveResultSets" on true because of the InitDBConnection() that is asynchronous
                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                if (!sqlConnectionStringBuilder.ContainsKey("MultipleActiveResultSets"))
                {
                    sqlConnectionStringBuilder.Add("MultipleActiveResultSets", true);
                }

                sqlConnectionStringBuilder["MultipleActiveResultSets"] = true;

                if (passwordIsScrambled)
                {
                    var passwordScrambler = new Scrambler("KiSS4");
                    var password = sqlConnectionStringBuilder.Password;

                    password = passwordScrambler.DecryptString(password);

                    sqlConnectionStringBuilder.Password = password;
                }

                // Add Metadata for EntityConnectionString
                string cnxString = "metadata=res://Kiss.Edmx/KiSS.csdl|" +
                                   "res://Kiss.Edmx/KiSS.ssdl|" +
                                   "res://Kiss.Edmx/KiSS.msl;" +
                                   "provider=System.Data.SqlClient;provider connection string=\""
                                   + sqlConnectionStringBuilder.ConnectionString.Replace("server=", "Data Source=") + "\"";

                Close();

                _entityConnection = new EntityConnection(cnxString);
                _entityConnection.Open();

                // We tell the concrete factory what EF model we want to use
                // KiSS_Entities erbt von ObjectContext.
                // Hinweis: Wegen Memory-Leak wird nicht zuerst eine EFConnection erstellt und im Konstruktor mitgegeben.
                //          Jedes UnitOfWork braucht eine eigene EFConnection, sonst werden Entitäten nie durch GC abgeräumt.
                EFUnitOfWorkFactory.SetObjectContext(() =>
                                                         {
                                                             EnsureConnection();

                                                             var context = new KiSS_Entities(_entityConnection);

                                                             /*
                                                              * Problem mit SQL Server 2005: Wenn EF in der gleichen Transaktion
                                                              * Connections schliesst und wieder öffnet, dann wird die Transaktion
                                                              * zu einer Distributed Transaction promoted.
                                                              * Siehe: http://www.ef-faq.org/connections-and-transactions.html (siehe Abschnitt 4.7)
                                                              * Abhilfe: Wenn die Connection manuell geöffnet wird, dann lässt EF die Connection offen
                                                              * und diese wird dann im Dispose des Kontextes geschlossen.
                                                              * Siehe auch: http://msdn.microsoft.com/en-us/library/bb738698.aspx
                                                              */

                                                             //context.Connection.Open();
                                                             return context;
                                                         });

                // Register POCO UnitOfWork
                Container.RegisterInstance<DataAccess.Interfaces.IUnitOfWorkFactory>(new KissUnitOfWorkFactory(cnxString));
                //var test = Container.Resolve<Kiss.DataAccess.Interfaces.IUnitOfWorkFactory>();
                //var inst = test.Create();

                //Container.RegisterType<Kiss.DataAccess.Interfaces.IUnitOfWork, Kiss.DataAccess.KissUnitOfWork>(InstanceScope.PerResolve);
                //ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings("KissContext", cnxString, "System.Data.EntityClient"));

                // We are checking the DbName against the DbName stored in XConfig.
                SystemService.CheckDbName(null);

                _authenticatedUser = authenticatedUser;
                if (_authenticatedUser == null)
                {
                    var userService = Container.Resolve<XUserService>();
                    _authenticatedUser = userService.GetAuthenticatedSystemUser();
                }

                if (openAsync)
                {
                    InitDBConnectionAsync();
                }
                else
                {
                    InitDBConnection();
                }
            }
            catch (Exception ex)
            {
                //cover password in connectionString
                var pos = connectionString.ToLower().IndexOf("password", StringComparison.Ordinal);

                if (pos >= 0)
                {
                    while (pos < connectionString.Length && connectionString[pos] != ';')
                    {
                        connectionString = connectionString.Remove(pos, 1);
                    }

                    connectionString = connectionString.Insert(pos, "password = ???");
                }

                throw new Exception(string.Format("Could not connect to the database. Connection string: {0}", connectionString), ex);
            }
        }

        private void InitDBConnection()
        {
            XDBVersion version = SystemService.GetDBVersion(null);
            Trace.Write(string.Format("DBVersion: {0}.{1}.{2}.{3}", version.MajorVersion, version.MinorVersion, version.Build, version.Revision));
        }

        private void InitDBConnectionAsync()
        {
            // Initialise the DB-Connection. We do this asynchronously as this can take a while (because of the metadata-check)
            _initDBConnectionAsyncThread = new Thread(InitDBConnection);
            _initDBConnectionAsyncThread.Start();
        }
    }
}