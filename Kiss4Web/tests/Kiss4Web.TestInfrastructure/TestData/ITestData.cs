using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;

namespace Kiss4Web.TestInfrastructure.TestData
{
    public interface ITestData
    {
        Task InsertTestData(IDbContext context);

        void RemoveTestData(IDbContext context);
    }
}