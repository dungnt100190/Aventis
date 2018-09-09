using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiss4Web.Infrastructure.DataAccess.Audit
{
    /// <summary>
    /// Wird vom DbContext vor dem Speichern aufgerufen
    /// Kann auf Änderungen (Insert, Update, Delete) an DB-Entitäten reagieren, z.B. zum Nachführen von Schattentabellen
    /// </summary>
    public interface IDbChangeAuditor
    {
        /// <summary>
        /// Verarbeitet die anstehenden DB-Änderungen
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="dbContext"></param>
        void AuditEntities(IEnumerable<EntityEntry> entities, IDbContext dbContext);
    }
}