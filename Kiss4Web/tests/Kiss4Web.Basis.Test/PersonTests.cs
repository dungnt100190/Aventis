using System.Net;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.ErrorHandling;
using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.Basis.Test
{
    public class PersonTests : IntegrationTest
    {
        public PersonTests(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task GetPersonById()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);
            var result = await client.GetAsJsonAsync<BaPerson>("api/personen/64805");
            result.IsSuccess.ShouldBeTrue();

            var person = result.Result;

            person.Id.ShouldBe(64805);
            person.Name.ShouldBe("*Velori");
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task SavePersonInvalid()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);
            var result = await client.GetAsJsonAsync<BaPerson>("api/personen/64810");
            result.IsSuccess.ShouldBeTrue();
            var person = result.Result;

            person.Id.ShouldBe(64810);
            person.Name.ShouldNotBeNull();

            person.Name = null;

            var postResult = await client.PostAsJsonAsync("api/personen/64810", person);
            postResult.HttpResult.ShouldBe(HttpStatusCode.BadRequest);

            var errorResult = postResult as ServiceResult<ErrorDto[]>;
            errorResult.ShouldNotBeNull();
            errorResult.Result.Length.ShouldBe(1);
            var errorDto = errorResult.Result[0];
            errorDto.PropertyName.ShouldBe(nameof(BaPerson.Name));
        }
    }
}