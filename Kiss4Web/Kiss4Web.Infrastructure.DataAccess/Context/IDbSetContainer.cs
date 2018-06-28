using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public interface IDbSetContainer
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        //DbSet<> Set(Type entityType);
    }
}