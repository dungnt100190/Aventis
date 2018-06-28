using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.ErrorHandling;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.Infrastructure.DocumentCreation.Test
{
    public class CreateDocumentTests : IntegrationTest
    {
        private const int DocTemplateId_EinzelneBesprechung = 669164;

        public CreateDocumentTests(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task CreateDocumentFromExistingTemplate()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            const int templateId = DocTemplateId_EinzelneBesprechung;
            var contextValues = new[] { new ContextValue { Name = "FaAktennotizID", Value = "17" }, new ContextValue { Name = "BaPersonID", Value = "64820" } };
            var response = await client.PostAsJsonAsync<IEnumerable<ContextValue>, int>("api/documents/create", contextValues, new { templateId });
            //var response = await client.GetAsJsonAsync<int>("api/documents/create", new { templateId, contextValues });

            response.ShouldNotBeNull();
            var successResult = response as ServiceResult<int>;
            successResult.ShouldNotBeNull();
            successResult.ShouldBeOk();
            successResult.Result.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task CreateDocumentFromExistingTemplate_MissingParameter()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            const int templateId = DocTemplateId_EinzelneBesprechung;
            var contextValues = new[] { new ContextValue { Name = "FaAktennotizID", Value = "1" } };
            var response = await client.PostAsJsonAsync<IEnumerable<ContextValue>, int>("api/documents/create", contextValues, new { templateId });

            response.ShouldNotBeNull();
            var successResult = response as ServiceResult<ErrorDto[]>;
            successResult.ShouldNotBeNull();
            successResult.HttpResult.ShouldBe(HttpStatusCode.BadRequest);
            successResult.Result.Length.ShouldBe(1);
            successResult.Result[0].PropertyName.ShouldBe("BaPersonID");
        }
    }
}