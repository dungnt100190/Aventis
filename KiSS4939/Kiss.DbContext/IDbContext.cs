using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Kiss.DbContext
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();                      // commit to db

        IDbSet<TEntity> Set<TEntity>()          // generic access to DbSet
            where TEntity : class;

        DbChangeTracker ChangeTracker { get; }
        DbEntityEntry Entry(object entity);     // get/set state
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)     // get/set state
            where TEntity : class;

        bool AutoDetectChangesEnabled { get; set; }

        void RegisterValidation(Type entityType,
                                Func<DbEntityEntry, 
                                     System.Data.Entity.DbContext, 
                                     System.Data.Entity.Validation.DbEntityValidationResult> validation);

        void ValidateUnchangedEntities();

        //System.Data.Objects.ObjectContext ObjectContext { get; } // wäre schön, wenn nicht nötig
    }
}
