using System;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Xunit;

namespace Kiss4Web.TestInfrastructure.TestServer
{
    [Collection(nameof(TestServerCollection))]
    public class IntegrationTest : IClassFixture<TestServerFixture>, IDisposable
    {
        public IntegrationTest(TestServerFixture integrationTestEnvironment)
        {
            IntegrationTestEnvironment = integrationTestEnvironment;
            TestDataManager = integrationTestEnvironment.CreateTestDataManager();
        }

        protected TestServerFixture IntegrationTestEnvironment { get; }

        protected DynamicTestDataManager TestDataManager { get; }

        public void Dispose()
        {
            TestDataManager?.Dispose();
        }
    }
}