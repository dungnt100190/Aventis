using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.Modularity;
using Microsoft.Extensions.DependencyModel;
using SimpleInjector;

namespace Kiss4Web.TestInfrastructure.TestData
{
    public class TestDataInserter
    {
        private readonly Container _container;
        private readonly List<ITestData> _testDataInserters;

        public TestDataInserter(Container container)
        {
            _container = container;
            var testAssemblies = DependencyContext.Default
                                                  .RuntimeLibraries
                                                  .Where(lib => lib.Name.StartsWith("Kiss4Web.")
                                                                && lib.Name.EndsWith(".Test")
                                                                || lib.Name == "Kiss4Web.TestInfrastructure")
                                                  .Select(lib => Assembly.Load(new AssemblyName(lib.Name)))
                                                  .ToList();

            _testDataInserters = testAssemblies.GetInstances<ITestData>().ToList();
        }

        internal async Task<IEnumerable<ITestData>> Insert()
        {
            using (new EnsureExecutionScope(_container))
            {
                var dbContext = _container.GetInstance<IDbContext>();
                foreach (var testDataInserter in _testDataInserters)
                {
                    await testDataInserter.InsertTestData(dbContext);
                }

                await dbContext.SaveChangesAsync();
            }

            return _testDataInserters;
        }

        internal async Task Remove()
        {
            using (new EnsureExecutionScope(_container))
            {
                var dbContext = _container.GetInstance<IDbContext>();
                _testDataInserters.DoForEach(tdi => tdi.RemoveTestData(dbContext));

                await dbContext.SaveChangesAsync();
            }
        }

        public T GetData<T>(bool ensureDataIsInDatabase = true)
           where T : ITestData
        {
            var testData = _testDataInserters.OfType<T>().FirstOrDefault();
            if (ensureDataIsInDatabase && testData != null)
            {
                using (new EnsureExecutionScope(_container))
                {
                    var dbContext = _container.GetInstance<IDbContext>();
                    testData.InsertTestData(dbContext).Wait();
                    dbContext.SaveChangesAsync().Wait();
                }
            }

            return testData;
        }
    }
}