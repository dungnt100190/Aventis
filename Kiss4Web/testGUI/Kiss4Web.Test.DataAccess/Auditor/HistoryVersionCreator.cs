using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Kiss4Web.Test.DataAccess
{
    public class HistoryVersionCreator : IDbChangeAuditor
    {
        private readonly string _authenticatedUsername;

        private readonly HashSet<Type> _tablesWithTriggers = new HashSet<Type> { typeof(BaPerson),
                                                                                 typeof(BaAdresse),
                                                                                 typeof(XOrgUnit),
                                                                                 typeof(XOrgUnit_User),
                                                                                 typeof(XUser) };

        public HistoryVersionCreator(string authenticatedUsername)
        {
            _authenticatedUsername = authenticatedUsername;
        }

        public void AuditEntities(IEnumerable<DbEntityEntry> entities, DbContext context)
        {
            var historyVersionNecessary = entities.Any(ent => (ent.State == EntityState.Added
                                                            || ent.State == EntityState.Modified
                                                            || ent.State == EntityState.Deleted)
                                                           && _tablesWithTriggers.Contains(ent.Entity.GetType()));
            if (historyVersionNecessary)
            {
                // there is no good way to make sure that HistoryVersion is inserted first in DbContext.SaveChanges(), so insert it manually first
                // transaction is not important, unnecessary HistoryVersions do not harm
                var historyDbSet = context.Set<HistoryVersion>();
                var historyEntity = new HistoryVersion
                {
                    VersionDate = DateTime.Now,
                    HostName = Environment.MachineName,
                    SystemUser = Environment.UserDomainName + @"\" + Environment.UserName,
                    AppName = "Kiss4Web",
                    dbUser = "testKiss",
                    AppUser = _authenticatedUsername
                };
                historyDbSet.Add(historyEntity);
            }
        }
    }
}
