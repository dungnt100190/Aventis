namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public interface IDbContextFactory
    {
        IDbContext CreateDbContext();
    }
}