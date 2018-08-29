using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Kiss4Web.Test.DataAccess
{
    public interface IDbChangeAuditor
    {
        void AuditEntities(IEnumerable<DbEntityEntry> entities, DbContext context);
    }
}
