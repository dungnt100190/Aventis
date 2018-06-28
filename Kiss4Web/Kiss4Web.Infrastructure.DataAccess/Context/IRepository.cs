using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kiss4Web.Model.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public interface IRepository<TEntity> : IQueryable<TEntity>
        where TEntity : class, IEntity
    {
        //void BulkInsertOrUpdate(IEnumerable<TEntity> entities, bool skipValidation = false);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetById(int id);

        void InsertObjectTree(TEntity entity);

        Task InsertOrUpdateEntity(TEntity entity);

        EntityEntry<TEntity> Remove(TEntity entity);

        void Remove(Expression<Func<TEntity, bool>> predicate);
    }
}