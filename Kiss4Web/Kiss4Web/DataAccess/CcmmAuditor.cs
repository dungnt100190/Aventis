using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiss4Web.DataAccess
{
    /// <summary>
    /// Führt die Felder Creator/Created und Modifier/Modified nach
    /// </summary>
    public class CcmmAuditor : IDbChangeAuditor
    {
        private readonly AuthenticatedUsername _authenticatedUsername;
        private readonly IDateTimeProvider _dateTimeProvider;
        private const string TextForAnonymousUser = "unknown";

        /// <summary>
        /// Erstellt eine neue Instanz von <see cref="CcmmAuditor"/>
        /// </summary>
        public CcmmAuditor(AuthenticatedUsername authenticatedUsername, IDateTimeProvider dateTimeProvider)
        {
            _authenticatedUsername = authenticatedUsername;
            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Führt die Felder Creator/Created und Modifier/Modified nach
        /// </summary>
        /// <param name="entities">Anstehende DB-Änderungen</param>
        /// <param name="dbContext"></param>
        public void AuditEntities(IEnumerable<EntityEntry> entities, IDbContext dbContext)
        {
            var now = _dateTimeProvider.Now;
            var addedEntities = entities.Where(ent => ent.State == EntityState.Added)
                                        .Select(ent => ent.Entity as IAuditableEntity)
                                        .Where(ent => ent != null);
            foreach (var addedEntity in addedEntities)
            {
                addedEntity.Created = now;
                addedEntity.Creator = _authenticatedUsername;
                addedEntity.Modified = now;
                addedEntity.Modifier = _authenticatedUsername;
            }

            var updatedEntities = entities.Where(ent => ent.State == EntityState.Modified)
                                          .Select(ent => ent.Entity as IAuditableEntity)
                                          .Where(ent => ent != null);
            foreach (var addedEntity in updatedEntities)
            {
                addedEntity.Modified = now;
                addedEntity.Modifier = _authenticatedUsername;
            }
        }
    }
}