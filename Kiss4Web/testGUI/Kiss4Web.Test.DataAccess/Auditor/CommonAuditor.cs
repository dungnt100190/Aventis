using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Kiss4Web.Test.DataAccess
{
    public class CommonAuditor : IDbChangeAuditor
    {
        private string _authenticatedUsername;
        private DateTime _dateTimeProvider;

        public CommonAuditor(string authenticatedUsername, DateTime dateTimeProvider)
        {
            _authenticatedUsername = authenticatedUsername;
            _dateTimeProvider = dateTimeProvider;
        }

        public void AuditEntities(IEnumerable<DbEntityEntry> entities, DbContext context)
        {
            var addedEntities = entities.Where(ent => ent.State == EntityState.Added)
                                        .Select(ent => ent.Entity as IAuditableEntity)
                                        .Where(ent => ent != null);
            foreach (var addedEntity in addedEntities)
            {
                addedEntity.Created = _dateTimeProvider;
                addedEntity.Creator = _authenticatedUsername;
                addedEntity.Modified = _dateTimeProvider;
                addedEntity.Modifier = _authenticatedUsername;
            }

            var updatedEntities = entities.Where(ent => ent.State == EntityState.Modified)
                                          .Select(ent => ent.Entity as IAuditableEntity)
                                          .Where(ent => ent != null);
            foreach (var addedEntity in updatedEntities)
            {
                addedEntity.Modified = _dateTimeProvider;
                addedEntity.Modifier = _authenticatedUsername;
            }

            //return Task.CompletedTask;
        }
    }
}
