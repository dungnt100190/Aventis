using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kiss4Web.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IDbContext _dbContext;
        private IQueryable<TEntity> _queryable;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public Type ElementType => Queryable.ElementType;

        public Expression Expression => Queryable.Expression;

        public IQueryProvider Provider => Queryable.Provider;

        //protected IDbContext DbContext => _dbContext;

        protected DbSet<TEntity> DbSet { get; }

        protected IQueryable<TEntity> Queryable => _queryable ?? (_queryable = new Queryable<TEntity>(_dbContext));

        //public void BulkInsertOrUpdate(IEnumerable<TEntity> entities, bool skipValidation = false)
        //{
        //    if (entities == null)
        //    {
        //        return;
        //    }

        //    var validateOnSaveBefore = DbContext.ValidateOnSaveEnabled;
        //    var detectChangesBefore = DbContext.AutoDetectChangesEnabled;
        //    DbContext.AutoDetectChangesEnabled = false;
        //    DbContext.ValidateOnSaveEnabled = false;

        //    try
        //    {
        //        foreach (var entity in entities)
        //        {
        //            DbSet.Attach(entity);
        //            ChangeEntityState(entity, entity.ID == 0 ? EntityState.Added : EntityState.Modified);
        //        }
        //    }
        //    finally
        //    {
        //        DbContext.AutoDetectChangesEnabled = detectChangesBefore;
        //        DbContext.ValidateOnSaveEnabled = validateOnSaveBefore;
        //    }
        //}

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
        }

        public Task<TEntity> GetById(int id)
        {
            return DbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void InsertObjectTree(TEntity rootEntity)
        {
            DbSet.Add(rootEntity);
        }

        public async Task InsertOrUpdateEntity(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            // check if key is set before attach because attach might change the Id
            var isKeySet = entity.Id != 0;
            DbSet.Attach(entity);

            var entry = _dbContext.Entry(entity);
            var dbValues = await entry.GetDatabaseValuesAsync();
            if (dbValues == null)
            {
                if (isKeySet)
                {
                    // save an entity with autoidentity set means another user has deleted the entity in the meantime
                    throw new DbUpdateException(string.Format("{0} ({1}) wurde inzwischen gelöscht, möglicherweise von einem anderen User.", entity.GetType().Name, entity), (Exception)null);

                    // ToDo: globalization
                    // throw new DbUpdateException(string.Format(Resources.EntityHasBeenDeleted, entity.GetType().Name, entity), (Exception)null);
                }
                // new entity, INSERT
                entry.State = EntityState.Added;
            }
            else
            {
                // Original RowVersion must be the value sent by the client in order that optimistic locking works, see e.g. https://docs.microsoft.com/aspnet/core/data/ef-mvc/concurrency#update-the-edit-methods-in-the-departments-controller
                var rowversionPropertyName = ConstructRowversionPropertyNameByConvention(entity.GetType());
                dbValues[rowversionPropertyName] = entry.CurrentValues[rowversionPropertyName];

                // check with dbValues if modified or unchanged (DbContext sets state)
                entry.OriginalValues.SetValues(dbValues);
            }
        }

        public EntityEntry<TEntity> Remove(TEntity entityToDelete)
        {
            if (entityToDelete == null)
            {
                return null;
            }
            // make sure the entity is in the context
            entityToDelete = DbSet.Find(entityToDelete.Id);

            if (entityToDelete == null)
            {
                return null;
            }

            //CheckIfDbIsStillConsistentAfterDelete(entityToDelete);
            return DbSet.Remove(entityToDelete);
        }

        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = DbSet.Where(predicate);
            foreach (var entityToDelete in entitiesToDelete)
            {
                DbSet.Remove(entityToDelete);
            }
        }

        //public TEntity ShallowCloneEntity(int id, Func<TEntity, TEntity> adjustClonedEntity = null)
        //{
        //    var original = GetById(id);
        //    if (original == null)
        //    {
        //        throw new ArgumentException();
        //    }

        //    var clone = new TEntity();
        //    DbSet.Add(clone);

        //    //Copy values from source to clone
        //    var sourceValues = _dbContext.Entry(original).CurrentValues;
        //    //sourceValues["ID"] = 0;
        //    _dbContext.Entry(clone).CurrentValues.SetValues(sourceValues);
        //    _dbContext.Entry(clone).CurrentValues["ID"] = 0;
        //    //Change values of the copied entity
        //    TEntity clone2 = null;
        //    if (adjustClonedEntity != null)
        //    {
        //        clone2 = adjustClonedEntity(clone);

        //        if (clone2 == null)
        //        {
        //            DbSet.Remove(clone);
        //        }
        //    }

        //    //Insert clone with changes into database
        //    return clone2;
        //}

        //protected void CheckIfDbIsStillConsistentAfterDelete(TEntity entityToDelete)
        //{
        //}

        //private void ChangeEntityState<TChangedEntity>(TChangedEntity entity, EntityState entityState)
        //    where TChangedEntity : class, IAutoIdentityEntity<int>
        //{
        //    DbContext.Entry(entity).State = entityState;
        //}

        private string ConstructRowversionPropertyNameByConvention(Type type)
        {
            return $"{type.Name}Ts";
        }
    }
}