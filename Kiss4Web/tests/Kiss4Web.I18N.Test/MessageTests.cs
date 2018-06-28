using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.I18N;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.I18N.Test
{
    public class MessageTests : IntegrationTest
    {
        public MessageTests(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task GetExistingMaskText()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            var response = await client.GetAsJsonAsync<IEnumerable<ControlTranslation>>("api/translations/mask", new { maskName = "ctlbaperson", languagecode = "1" });
            response.ShouldBeOk();

            var dict = response.Result.ToDictionary(ctr => ctr.ControlName, ctr => ctr.Text);
            dict.Count.ShouldBe(55);
            dict["edtTestperson"].ShouldBe("Testperson");
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task GetExistingText()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("de"));
            var response = await client.GetAsJsonAsync<string>("api/translations", new { maskName = "KissDocumentButton", messageName = "NeuesDokErstellen" });
            response.ShouldBeOk();

            response.Result.ShouldBe("Fortschritt: Neues Word-Dokument erstellen");
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task GetExistingTextChangeLanguage()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            // get it in german
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("de"));
            var response = await client.GetAsJsonAsync<string>("api/translations", new { maskName = "KissDocumentButton", messageName = "OpenFileName" });
            response.ShouldBeOk();

            response.Result.ShouldBe("Datei: {0}");

            // get it in french
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fr"));
            var responseFr = await client.GetAsJsonAsync<string>("api/translations", new { maskName = "KissDocumentButton", messageName = "OpenFileName" });
            responseFr.ShouldBeOk();

            responseFr.Result.ShouldBe("Fichier: {0}");
        }
    }
}