using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.Basis.Test
{
    public class ModulTests : IntegrationTest
    {
        public ModulTests(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        public async Task GetModulen()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);
            var response = await client.GetAsJsonAsync<IEnumerable<ModulDisplayItem>>("api/modulen");
            response.ShouldBeOk();

            var modules = response.Result.ToList();
            modules.ShouldNotBeNull();
            modules.ShouldNotBeEmpty();
            modules.ShouldAllBe(module =>
                module.ShortName != null
                && module.IconId != 0
                && module.IconId % 100 == 0);
        }
    }
}