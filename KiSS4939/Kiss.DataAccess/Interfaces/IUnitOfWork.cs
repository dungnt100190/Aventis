using System;

namespace Kiss.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        void ValidateUnChangedEntities();
        
        IRepository Repository(Type entityType);

        IRepository<T> Repository<T>()
            where T : class;
    }
}