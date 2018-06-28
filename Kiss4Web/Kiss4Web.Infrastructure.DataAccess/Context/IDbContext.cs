using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public interface IDbContext : ISaveableDbSetContainer
    {
        //bool AutoDetectChangesEnabled { get; set; }

        //DbSet Set(System.Type entityType);
        ChangeTracker ChangeTracker { get; }

        //bool ValidateOnSaveEnabled { get; set; }

        EntityEntry Entry(object entity);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        //IEnumerable<DbChange> SaveAndExtractChanges();
    }
}