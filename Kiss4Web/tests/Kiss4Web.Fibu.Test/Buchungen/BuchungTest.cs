using System;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.ErrorHandling.Questions;
using Kiss4Web.Model;
using Kiss4Web.Modules.Fibu.Buchungen;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using Xunit;

namespace Kiss4Web.Fibu.Test.Buchungen
{
    public class BuchungTest : IntegrationTest
    {
        public BuchungTest(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task CreateBuchungRaiseQuestion()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);

            var buchung = new FbBuchung
            {
                FbPeriodeId = 6963,
                BuchungTypCode = 0,
                BuchungsDatum = new DateTime(2012, 5, 24),
                SollKtoNr = 3101,
                HabenKtoNr = 1010,
                Betrag = 500,
                Text = "Buchung aus Integrationstest",
                ValutaDatum = new DateTime(2012, 5, 30),
                FbZahlungswegId = null
            };
            var result = await client.PostAsJsonAsync("api/fibu/buchungen", buchung) as ServiceResult<QuestionDto>;
            result.ShouldNotBeNull();

            result.Result.QuestionIdentifier.ShouldBe(SaveBuchungCommandHandler.ZahlwegNichtErfasstQuestionIdentifier);
            result.Result.PossibleAnswers.Count().ShouldBe(2);
            result.Result.PossibleAnswers.Any(ans => ans.Id as bool? == true).ShouldBeTrue();
            result.Result.PossibleAnswers.Any(ans => ans.Id as bool? == false).ShouldBeTrue();
        }

        [Fact]
        [Trait("Category", "ExistingData")]
        public async Task CreateBuchungRaiseQuestionAndAnswer()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);

            var buchung = new FbBuchung
            {
                FbPeriodeId = 6963,
                BelegNr = "DA-153924",
                BuchungTypCode = 0,
                BuchungsDatum = new DateTime(2012, 5, 24),
                SollKtoNr = 3101,
                HabenKtoNr = 1010,
                Betrag = 500,
                Text = "Buchung aus Integrationstest",
                ValutaDatum = new DateTime(2012, 5, 30),
                FbZahlungswegId = null
            };
            var result = await client.PostAsJsonAsync("api/fibu/buchungen", buchung) as ServiceResult<QuestionDto>;
            result.ShouldNotBeNull();

            result.Result.QuestionIdentifier.ShouldBe(SaveBuchungCommandHandler.ZahlwegNichtErfasstQuestionIdentifier);
            result.Result.PossibleAnswers.Count().ShouldBe(2);
            result.Result.PossibleAnswers.Any(ans => ans.Id as bool? == true).ShouldBeTrue();
            result.Result.PossibleAnswers.Any(ans => ans.Id as bool? == false).ShouldBeTrue();

            var resultSecondCall = await client.PostAsJsonAsync<FbBuchung, FbBuchung>("api/fibu/buchungen", buchung, new { dtaQuestion = true }) as ServiceResult<FbBuchung>;
            resultSecondCall.ShouldNotBeNull();
            resultSecondCall.ShouldBeOk();

            var buchungFromServer = resultSecondCall.Result;
            buchungFromServer.FbBuchungId.ShouldBeGreaterThan(0);
            buchung.FbBuchungId = buchungFromServer.FbBuchungId;
            buchung.FbBuchungTs = buchungFromServer.FbBuchungTs;
            TestDataManager.TrackEntity(buchung);
        }
    }
}