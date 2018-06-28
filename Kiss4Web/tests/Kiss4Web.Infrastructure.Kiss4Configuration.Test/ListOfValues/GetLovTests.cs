using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Model;
using Kiss4Web.Model.Klientenbuchhaltung;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.Infrastructure.Kiss4Configuration.Test.ListOfValues
{
    public class GetLovTests : IntegrationTest
    {
        public GetLovTests(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task GetExistingKiss4Lov()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            var periodeStatusLovResult = await client.GetAsJsonAsync<IEnumerable<XLovCode>>($"api/lookups/{nameof(KbPeriodeStatus)}");
            periodeStatusLovResult.ShouldBeOk();

            var periodeStatusLov = periodeStatusLovResult.Result.ToList();
            periodeStatusLov.Count.ShouldBe(3);
            periodeStatusLov.ShouldContain(xlc => string.Equals(xlc.Text, nameof(KbPeriodeStatus.Aktiv), StringComparison.InvariantCultureIgnoreCase)
                                               && xlc.Code == 1);
            periodeStatusLov.ShouldContain(xlc => string.Equals(xlc.Text, nameof(KbPeriodeStatus.Inaktiv), StringComparison.InvariantCultureIgnoreCase)
                                               && xlc.Code == 2);
            periodeStatusLov.ShouldContain(xlc => string.Equals(xlc.Text, nameof(KbPeriodeStatus.Abgeschlossen), StringComparison.InvariantCultureIgnoreCase)
                                               && xlc.Code == 3);
        }
    }
}