using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.Infrastructure.Authentication.Test
{
    public class TokenTests : IntegrationTest
    {
        public TokenTests(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [Fact]
        public async Task Authenticate_Success()
        {
            var testServerHandler = IntegrationTestEnvironment.TestIdentityServer.CreateHandler();
            var discoveryClient = new DiscoveryClient(TestServerFixture.Authority, testServerHandler);
            discoveryClient.Policy.ValidateIssuerName = false;
            var disco = await discoveryClient.GetAsync();
            disco.Error.ShouldBeNull();

            var userTestData = IntegrationTestEnvironment.TestData<XUserTestData>();
            var admin = userTestData.Administrator;
            var tokenClient = new TokenClient(disco.TokenEndpoint, "webclient.ro", "EA59A39A-B03D-4985-A4FA-9297663A1858", testServerHandler);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(admin.LogonName, XUserTestData.AdminPassword, "api");
            tokenResponse.Error.ShouldBeNull();

            var token = new JwtSecurityTokenHandler().ReadToken(tokenResponse.AccessToken) as JwtSecurityToken;
            token.ShouldNotBeNull();
            token.Subject.ShouldBe(admin.Id.ToString());
        }

        [Fact]
        public async Task Authenticate_Failure()
        {
            var testServerHandler = IntegrationTestEnvironment.TestIdentityServer.CreateHandler();
            var discoveryClient = new DiscoveryClient(TestServerFixture.Authority, testServerHandler);
            discoveryClient.Policy.ValidateIssuerName = false;
            var disco = await discoveryClient.GetAsync();
            disco.Error.ShouldBeNull();

            var userTestData = IntegrationTestEnvironment.TestData<XUserTestData>();
            var admin = userTestData.Administrator;
            var tokenClient = new TokenClient(disco.TokenEndpoint, "webclient.ro", "EA59A39A-B03D-4985-A4FA-9297663A1858", testServerHandler);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(admin.LogonName, XUserTestData.AdminPassword + "Wrong", "api");
            tokenResponse.IsError.ShouldBeTrue();
        }

        [Fact]
        public async Task Authenticate_HasClaims()
        {
            var testServerHandler = IntegrationTestEnvironment.TestIdentityServer.CreateHandler();
            var discoveryClient = new DiscoveryClient(TestServerFixture.Authority, testServerHandler);
            discoveryClient.Policy.ValidateIssuerName = false;
            var disco = await discoveryClient.GetAsync();
            disco.Error.ShouldBeNull();

            var userTestData = IntegrationTestEnvironment.TestData<XUserTestData>();
            var admin = userTestData.Administrator;
            var tokenClient = new TokenClient(disco.TokenEndpoint, "webclient.ro", "EA59A39A-B03D-4985-A4FA-9297663A1858", testServerHandler);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(admin.LogonName, XUserTestData.AdminPassword, "api");
            tokenResponse.Error.ShouldBeNull();

            var token = new JwtSecurityTokenHandler().ReadToken(tokenResponse.AccessToken) as JwtSecurityToken;
            token.ShouldNotBeNull();
            token.Claims.ShouldContain(clm => clm.Type == Kiss4WebClaims.LogonName);
            token.Claims.ShouldContain(clm => clm.Type == Kiss4WebClaims.ShortName);
            token.Claims.First(clm => clm.Type == Kiss4WebClaims.LogonName).Value.ShouldBe(admin.LogonName);
            token.Claims.First(clm => clm.Type == Kiss4WebClaims.ShortName).Value.ShouldBe(admin.ShortName);
        }
    }
}