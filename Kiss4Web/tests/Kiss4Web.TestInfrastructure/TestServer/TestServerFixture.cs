using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.DataAccess;
using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure.IntegrationTests;
using Kiss4Web.TestInfrastructure.TestData;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using SimpleInjector;

namespace Kiss4Web.TestInfrastructure.TestServer
{
    /// <summary>
    /// In-memory Identity Server, DB as docker image
    /// </summary>
    public class TestServerFixture : IDisposable
    {
        public const string Authority = "https://kiss4web-identityserver";
        private readonly TestDataInserter _testData;

        public TestServerFixture()
        {
            const string connectionString = "Server=127.0.0.1,1435;Database=KiSS_Standard_R4939;user=sa;password=D0102A72-7838-4078-9829-DBD038018C18;";
            DockerStarter.TryStartDbContainer(connectionString);
            DateTime = new TestDateTimeProvider();

            var builderIdentityServer = WebHost.CreateDefaultBuilder()
                                               .ConfigureAppConfiguration(o => o.AddInMemoryCollection(new[]
                                               {
                                                   new KeyValuePair<string, string>("ConnectionStrings:DefaultConnection", connectionString),
                                                   new KeyValuePair<string, string>("Authentication:Authority", Authority),
                                               }))
                                               .UseStartup<IdentityServer.Startup>();

            TestIdentityServer = new Microsoft.AspNetCore.TestHost.TestServer(builderIdentityServer);

            var builderKiss4Web = WebHost.CreateDefaultBuilder()
                                         .ConfigureAppConfiguration(o => o.AddInMemoryCollection(new[]
                                                                           {
                                                                               new KeyValuePair<string, string>("ConnectionStrings:DefaultConnection", connectionString),
                                                                               new KeyValuePair<string, string>("Authentication:Authority", Authority),
                                                                           }))
                                         .ConfigureServices(c =>
                                                                 {
                                                                     c.AddSingleton<IDateTimeProvider>(DateTime);
                                                                     c.AddSingleton(TestIdentityServer.CreateHandler());
                                                                 })
                                         .UseStartup<Startup>();

            TestServer = new Microsoft.AspNetCore.TestHost.TestServer(builderKiss4Web);

            Container = TestServer.Host.Services.GetService<Container>();

            _testData = new TestDataInserter(Container);

            // connection string might have been modified (different IP in VSTS), so update it
            ConnectionString = Container.GetInstance<ConnectionString>();
        }

        public ConnectionString ConnectionString { get; }
        public Container Container { get; }
        public TestDateTimeProvider DateTime { get; }
        public Microsoft.AspNetCore.TestHost.TestServer TestIdentityServer { get; set; }

        public Microsoft.AspNetCore.TestHost.TestServer TestServer { get; }

        public DynamicTestDataManager CreateTestDataManager()
        {
            return new DynamicTestDataManager(ConnectionString, DateTime);
        }

        public void Dispose()
        {
            _testData.Remove().Wait();
            TestServer.Dispose();
        }

        public Task<HttpClient> GetClient(TestUser testUser)
        {
            var userTestData = TestData<XUserTestData>();
            XUser user;
            string password;
            if (testUser == TestUser.Administrator)
            {
                user = userTestData.Administrator;
                password = XUserTestData.AdminPassword;
            }
            else if (testUser == TestUser.Sozialarbeiter)
            {
                user = userTestData.Sozialarbeiter;
                password = XUserTestData.SozialarbeiterPassword;
            }
            else
            {
                throw new Exception("unknown TestUser");
            }

            return GetClient(user.LogonName, password);
        }

        public async Task<HttpClient> GetClient(string username, string password)
        {
            var client = TestServer.CreateClient();
            var handler = TestIdentityServer.CreateHandler();
            var discoveryUri = Authority;
            var discoveryClient = new DiscoveryClient(discoveryUri, handler);
            discoveryClient.Policy.ValidateIssuerName = false;
            var disco = await discoveryClient.GetAsync();
            disco.Error.ShouldBeNullOrEmpty();

            var tokenClient = new TokenClient(disco.TokenEndpoint, "webclient.ro", "EA59A39A-B03D-4985-A4FA-9297663A1858", handler);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(username, password, "api");
            tokenResponse.Error.ShouldBeNullOrEmpty();

            client.SetBearerToken(tokenResponse.AccessToken);
            var httpsBaseAddress = new Uri($"https://{client.BaseAddress.Host}/");
            client.BaseAddress = httpsBaseAddress;
            return client;
        }

        public T TestData<T>(bool ensureDataIsInDatabase = true)
                                    where T : ITestData
        {
            return _testData.GetData<T>(ensureDataIsInDatabase);
        }
    }
}