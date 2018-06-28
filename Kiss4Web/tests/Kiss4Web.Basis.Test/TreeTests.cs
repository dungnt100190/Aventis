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
    public class TreeTests : IntegrationTest
    {
        public TreeTests(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        public async Task GetTrees()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);
            var response = await client.GetAsJsonAsync<IEnumerable<TreeDisplayItem>>("api/trees", new
            {
                active = true,
                closed = false,
                archived = false,
                includeGroup = false,
                includeGuest = false,
                includeTasks = true
            });
            response.ShouldBeOk();

            var trees = response.Result.ToList();
            trees.ShouldNotBeNull();
            trees.ShouldNotBeEmpty();
        }
    }
}