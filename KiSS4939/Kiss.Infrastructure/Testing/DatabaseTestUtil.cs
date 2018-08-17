using System;
using System.Configuration;

namespace Kiss.Infrastructure.Testing
{
    public static class DatabaseTestUtil
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// The name of the connection string in the app-config.
        /// </summary>
        public const string CONNECTION_STRING_NAME = "TestDB";

        /// <summary>
        /// The name of the connection string in the app-config for KiSS 5 UnitTests.
        /// </summary>
        public const string CONNECTION_STRING_NAME_KISS5 = "TestDBKiss5";

        /// <summary>
        /// The name of the environment variable that may contain a connection string.
        /// </summary>
        public const string CONNECTION_STRING_VARIABLE = "TEST_DB_CONNECT_STRING";

        /// <summary>
        /// The name of the app-config that contains database settings.
        /// </summary>
        public const string DATABASE_CONFIG_FILENAME = "Database.config";

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Returns a DB connection string either from an env. variable, an external DB app-config or from the current app-settings.
        /// </summary>
        public static string GetConnectionString(string connectionStringName)
        {
            // get connection string from environment variable "TEST_DB_CONNECT_STRING"
            var connectionString = Environment.GetEnvironmentVariable(CONNECTION_STRING_VARIABLE);

            if (!string.IsNullOrEmpty(connectionString))
            {
                return connectionString;
            }

            // get connection string from Database.config settings file
            // the file is only deployed by the Database.testsettings configuration
            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = DATABASE_CONFIG_FILENAME
            };

            try
            {
                Configuration dbConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                if (dbConfig != null)
                {
                    var cs = dbConfig.ConnectionStrings.ConnectionStrings[connectionStringName];

                    if (cs != null && !string.IsNullOrEmpty(cs.ConnectionString))
                    {
                        return cs.ConnectionString;
                    }
                }
            }
            catch
            {
                connectionString = null;
            }

            // get connection string from appConfig if it's not set yet
            if (string.IsNullOrEmpty(connectionString))
            {
                var connectionStringSection = ConfigurationManager.ConnectionStrings[connectionStringName];

                if (connectionStringSection != null)
                {
                    connectionString = connectionStringSection.ConnectionString;
                }
            }

            return connectionString;
        }

        #endregion

        #endregion
    }
}