using System;
using Xunit;

namespace Kiss4Web.TestInfrastructure.TestServer
{
    [Collection(nameof(TestServerCollection))]
    public class IntegrationTest : IClassFixture<TestServerFixture>, IDisposable
    {
        public IntegrationTest(TestServerFixture integrationTestEnvironment)
        {
            IntegrationTestEnvironment = integrationTestEnvironment;
            TestDataManager = integrationTestEnvironment.CreateTestDataManager(integrationTestEnvironment);
        }

        protected TestServerFixture IntegrationTestEnvironment { get; }

        protected TestDataManager TestDataManager { get; }

        public void Dispose()
        {
            TestDataManager?.Dispose();
        }
    }
}