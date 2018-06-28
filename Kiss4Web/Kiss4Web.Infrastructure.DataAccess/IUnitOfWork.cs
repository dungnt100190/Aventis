using System;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChanges();
    }
}