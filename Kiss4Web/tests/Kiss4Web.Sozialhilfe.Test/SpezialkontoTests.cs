using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.Sozialhilfe.Test
{
    public class SpezialkontoTests : IntegrationTest
    {
        public SpezialkontoTests(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task GetSpezialkonten()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);
            var result = await client.GetAsJsonAsync<IEnumerable<SpezialkontoDisplayItem>>("api/leistungen/98766/spezialkonten", new { typ = 1, nurAktive = true });
            result.ShouldBeOk();

            result.Result.Count().ShouldBe(4);
        }
    }
}