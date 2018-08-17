using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Kiss.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(params object[] keys);
        T[] GetAllEntities();
        EntityState InsertOrUpdateEntity(T entity);
        void InsertOrUpdateEntitiesWithoutCheckIfChanged(IEnumerable<T> entities);
        //T Remove(params object[] keyValues);
        T Remove(T entity);
    }

    public interface IRepository
    {
        object GetById(params object[] keys);
        IEnumerable GetAllEntities();
        EntityState InsertOrUpdateEntity(object entity);
        //object Remove(params object[] keyValues);
        object Remove(object entity);
    }
}