using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiss4Web.DataAccess
{
    public class HistoryVersionCreator : IDbChangeAuditor
    {
        private readonly AuthenticatedUsername _authenticatedUsername;

        private readonly HashSet<Type> _tablesWithTriggers = new HashSet<Type> { typeof(BaPerson),
                                                                                 typeof(BaAdresse),
                                                                                 typeof(XOrgUnit),
                                                                                 typeof(XOrgUnit_User),
                                                                                 typeof(XUser) };

        public HistoryVersionCreator(AuthenticatedUsername authenticatedUsername)
        {
            _authenticatedUsername = authenticatedUsername;
        }

        public void AuditEntities(IEnumerable<EntityEntry> entities, IDbContext dbContext)
        {
            var historyVersionNecessary = entities.Any(ent => (ent.State == EntityState.Added
                                                            || ent.State == EntityState.Modified
                                                            || ent.State == EntityState.Deleted)
                                                           && (_tablesWithTriggers.Contains(ent.Entity.GetType())));
            if (historyVersionNecessary)
            {
                // there is no good way to make sure that HistoryVersion is inserted first in DbContext.SaveChanges(), so insert it manually first
                // transaction is not important, unnecessary HistoryVersions do not harm
                var insertHistoryVersion = GetConnection(dbContext).CreateCommand();
                var commandSql = "INSERT INTO dbo.HistoryVersion (VersionDate, HostName, SystemUser, AppName, dbUser, AppUser)" + Environment.NewLine +
                                 "VALUES (GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}')";
                insertHistoryVersion.CommandText = string.Format(commandSql, Environment.MachineName,
                                                                             Environment.UserDomainName + @"\" + Environment.UserName,
                                                                             "Kiss4Web",
                                                                             "kiss3", // HACK: hardcoded
                                                                             _authenticatedUsername);
                insertHistoryVersion.ExecuteNonQuery();
            }
        }

        private static DbConnection GetConnection(IDbContext dbContext)
        {
            var connection = ((DbContext)dbContext).Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}