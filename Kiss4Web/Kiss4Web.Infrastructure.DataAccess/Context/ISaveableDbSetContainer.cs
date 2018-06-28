using System;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public interface ISaveableDbSetContainer : IDbSetContainer, IDisposable
    {
        Task SaveChangesAsync();
    }
}