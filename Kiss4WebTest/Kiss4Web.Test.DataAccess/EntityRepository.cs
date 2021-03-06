﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Kiss4Web.Test.DataAccess
{
    public interface IEntityRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T Get(object key);
        T Get(object[] keys);
        bool Insert(T entity, bool isView = false);
        bool Update(T entity, bool isView = false);
        bool Delete(object key);
        bool Delete(T entity);
    }

    public class EntityRepository<T> : IEntityRepository<T>, IDisposable
        where T : class
    {
        private KissContext _context;
        private DbSet<T> _dbSet;

        public EntityRepository(KissContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public T Get(object key)
        {
            return _dbSet.Find(key);
        }

        public T Get(object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public bool Insert(T entity, bool isView = false)
        {
            _dbSet.Add(entity);
            if (!isView) _context.Entry(entity).State = EntityState.Added;
            return _context.SaveChanges() >= 1;
        }

        public bool Update(T entity, bool isView = false)
        {
            _dbSet.Attach(entity);
            if (!isView) _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() >= 1;
        }

        public bool Delete(object key)
        {
            T entity = _dbSet.Find(key);
            if (entity != null) return Delete(entity);
            else return false;
        }

        public bool Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges() >= 1;
        }

        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
