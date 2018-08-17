using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using KiSS.Common.DA;
using KiSS.Common.IoC;
using KiSS.KliBu.BL;
using KiSS.Lookup.BL;

using Autofac;
using Autofac.Builder;

namespace KiSS.Context
{
    /// <summary>
    /// The global application context.
    /// </summary>
    public class AppContext
    {
        #region Fields

        #region Private Static Fields

        private static SqlConnection _cnn;
        private static ConnectionMgr _cnnMgr;
        private static string _connectionString;
        private static IContainer _container;
        private static bool _initNoDB;

        #endregion

        #endregion

        #region Properties

        public static SqlConnection Connection
        {
            get
            {
                LazyConnectDatabase();
                return _cnn;
            }
            set { _cnn = value; }
        }

        /// <summary>
        /// Get the IoC-Container
        /// </summary>
        public static IContainer Container
        {
            get
            {
                LazyConnectDatabase();
                return _container;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void CloseConnection()
        {
            if (_cnnMgr != null && _container != null && _cnn != null)
            {
                // close database connection
                _cnnMgr.CloseConnection(_container);

                // clear objects
                if (_cnn != null)
                {
                    _cnn.Close();
                    _cnn = null;
                }

                _cnnMgr = null;
                _container.Dispose();
                _container = null;

                _connectionString = null;
            }
        }

        /// <summary>
        /// Initialization as preparation for database connection
        /// </summary>
        public static void Init(string connectionString)
        {
            _connectionString = connectionString;
            _initNoDB = false;
        }

        /// <summary>
        /// Initialization. Build the IoC-Container. This method is provided for tests.
        /// </summary>
        public static void InitNoDB(Action<ContainerBuilder> registerMock)
        {
            _initNoDB = true;

            List<IModule> modules = GetModules();

            foreach (IModule module in modules)
            {
                IDBModule dbmodule = module as IDBModule;

                if (dbmodule != null)
                {
                    dbmodule.DontUseExternalConnection = true;
                }
            }

            ContainerBuilder builder = RegisterModules(modules);

            if (registerMock != null)
            {
                registerMock(builder);
            }

            _container = builder.Build();
        }

        #endregion

        #region Private Static Methods

        private static List<IModule> GetModules()
        {
            List<IModule> lst = new List<IModule>();

            lst.Add(new LookupModule());
            lst.Add(new KliBuModule());

            return lst;
        }

        /// <summary>
        /// Initialization. Build the IoC-Container and intialize the DB-Connection.
        /// </summary>
        private static void InitDBConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new NullReferenceException("Missing connection string, cannot create database connection.");
            }

            List<IModule> modules = GetModules();
            ContainerBuilder builder = RegisterModules(modules);

            _cnnMgr = new ConnectionMgr();
            _cnnMgr.CreateConnection(_connectionString);
            _cnn = _cnnMgr.Connection;

            // TODO: validate connection (on error it can be null > prevent showing error)
            //       > can we do this (see ConnectionMgr.cs:CreateConnection(...))?
            if (_cnn == null)
            {
                return;
            }

            builder.Register(_cnn);

            // add adhoc builder configuration from configfile
            // builder.RegisterModule(new ConfigurationSettingsReader("mycomponents"));

            _container = builder.Build();
            _cnnMgr.OpenConnection(_container);
        }

        private static void LazyConnectDatabase()
        {
            if (_container == null && !_initNoDB)
            {
                InitDBConnection();
            }
        }

        private static ContainerBuilder RegisterModules(List<IModule> modules)
        {
            ContainerBuilder builder = new ContainerBuilder();

            foreach (IModule module in modules)
            {
                builder.RegisterModule(module);
            }

            return builder;
        }

        #endregion

        #endregion
    }
}