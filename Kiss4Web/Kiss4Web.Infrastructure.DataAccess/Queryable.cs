using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Kiss4Web.Infrastructure.DataAccess
{
    public class Queryable<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity>//, IDbAsyncEnumerable<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Queryable(IDbSetContainer dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public Type ElementType => ((IQueryable)_dbSet).ElementType;

        Type IQueryable.ElementType => ElementType;

        public Expression Expression => ((IQueryable)_dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable)_dbSet).Provider;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _dbSet.AsEnumerable().GetEnumerator();
        }


        public IQueryable<TEntity> GetList()
        {
            return _dbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public virtual TEntity GetDetailByCondition(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).FirstOrDefault();
        }
        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }
        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetEnumerator()
        {
            //        return _dbSet.ToAsyncEnumerable().GetEnumerator();
            return ((IAsyncEnumerableAccessor<TEntity>)_dbSet).AsyncEnumerable.GetEnumerator();
        }
    }
}