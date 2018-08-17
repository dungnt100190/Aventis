using System;
using System.Linq;

using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.KissSystem
{
    #region Enumerations

    public enum DboType
    {
        /// <summary>
        /// VIEW
        /// </summary>
        V,

        /// <summary>
        /// USER_TABLE
        /// </summary>
        U
    }

    #endregion

    public class SystemService
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// This is the key for the config-value that contains the dbname.
        /// </summary>
        private const string DB_NAME_CONFIG_KEY = @"System\Allgemein\DbName";

        private const string MESSAGE_DBNAME_DOES_NOT_MATCH =
            @"Der Konfigurationswert System\Allgemein\DbName stimmt nicht mit dem aktuellen Datenbanknamen überein.
          Melden Sie sich beim technischen Support Diartis AG.";

        private const string MESSAGE_DBNAMECONFIG_NOT_SET =
            @"Der Konfigurationswert System\Allgemein\DbName ist nicht gesetzt.
         Melden Sie sich beim technischen Support Diartis AG.";

        /// <summary>
        /// Sql statement to get the db name.
        /// </summary>
        private const string SQL_DBNAME = @"SELECT DB_NAME()";

        /// <summary>
        /// Sql statement to get the server name.
        /// </summary>
        private const string SQL_SERVERNAME = @"SELECT @@SERVERNAME";

        #endregion

        #endregion

        #region Constructors

        private SystemService()
        {
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Checks the actual DB Name against the value stored in XConfig.
        /// The key used: System\Allgemein\DbName
        /// If the names do not match, a KissConfigurationException is thrown.
        /// </summary>
        public static void CheckDbName(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Get the actual name from the db.
            string actualDbname = GetActualDbName(unitOfWork);

            //Get the name form XConfig.
            var xConfigService = Container.Resolve<XConfigService>();
            var configDbName = xConfigService.GetConfigValue<string>(DB_NAME_CONFIG_KEY);

            if (configDbName == null)
            {
                throw new KissConfigurationException(DB_NAME_CONFIG_KEY, MESSAGE_DBNAMECONFIG_NOT_SET);
            }

            //Throw an exception if they are not the same.
            if (actualDbname == null || actualDbname.ToUpper() != configDbName.ToUpper())
            {
                throw new KissConfigurationException(DB_NAME_CONFIG_KEY, MESSAGE_DBNAME_DOES_NOT_MATCH);
            }
        }

        public static bool CheckIfDboExists(IUnitOfWork unitOfWork, string dboName, DboType type)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var sqlService = Container.Resolve<SqlService>();
            string sqlStatement = string.Format(@"
                    SELECT TOP 1 1
                    FROM sys.objects
                    WHERE name = '{0}' AND type = '{1}';", dboName, type.ToString());

            var exists = sqlService.ExecuteScalar(unitOfWork, sqlStatement, new object[0]);

            if (exists != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the actual name from the DB
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static string GetActualDbName(IUnitOfWork unitOfWork)
        {
            var sqlService = Container.Resolve<SqlService>();
            return sqlService.ExecuteScalar(unitOfWork, SQL_DBNAME, new object[0]) as string;
        }

        /// <summary>
        /// Returns the actual ServerName from the DB
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static string GetActualServerName(IUnitOfWork unitOfWork)
        {
            var sqlService = Container.Resolve<SqlService>();
            return sqlService.ExecuteScalar(unitOfWork, SQL_SERVERNAME, new object[0]) as string;
        }

        public static XDBVersion GetDBVersion(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XDBVersion>(unitOfWork);

            // Read the latest DBVersion-Entry
            var returnValue = repository
                .OrderByDescending(version => version.VersionDate)
                .FirstOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no DBVersion found");
            }

            // No need to start tracking on this entity as it's read only

            return returnValue;
        }

        /// <summary>
        /// Create new entry in HistoryVerion Table.
        /// </summary>
        public static void NewHistoryVersion(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var sessionService = Container.Resolve<ISessionService>();
            var repository = UnitOfWork.GetRepository<HistoryVersion>(unitOfWork);
            var logonName = sessionService.AuthenticatedUser.LogonName;

            var historyVersion = new HistoryVersion
            {
                AppUser = logonName,
                VersionDate = DateTime.Now,
            };

            repository.ApplyChanges(historyVersion);
            unitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}