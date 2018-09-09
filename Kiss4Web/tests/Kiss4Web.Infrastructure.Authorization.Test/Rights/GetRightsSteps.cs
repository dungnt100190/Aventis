using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using TechTalk.SpecFlow;

namespace Kiss4Web.Infrastructure.Authorization.Test.Rights
{
    [Binding]
    public class GetRightsSteps : IntegrationTest
    {
        private TestDataManager _testDataManager;
        private ServiceResult<IEnumerable<Kiss4UserRight>> _result;

        public GetRightsSteps(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"these Benutzer")]
        public async Task GivenTheseBenutzer(Table table)
        {
            await _testDataManager.Insert<XUser>(table);
        }

        [Given(@"these Benutzergruppen")]
        public async Task GivenTheseBenutzergruppen(Table table)
        {
            await _testDataManager.Insert<XUserGroup>(table);
        }

        [Given(@"these BenutzerInBenutzergruppen")]
        public async Task GivenTheseBenutzerInBenutzergruppen(Table table)
        {
            await _testDataManager.Insert<XUserUserGroup>(table);
        }

        [Given(@"these Klassen")]
        public async Task GivenTheseKlassen(Table table)
        {
            await _testDataManager.Insert<XClass>(table);
        }

        [Given(@"these Rechte")]
        public async Task GivenTheseRechte(Table table)
        {
            await _testDataManager.Insert<XRight>(table);
        }

        [Given(@"these RechteInBenutzergruppen")]
        public async Task GivenTheseRechteVInBenutzergruppen(Table table)
        {
            await _testDataManager.Insert<XUserGroupRight>(table);
        }

        [When(@"I get my own rights")]
        public async Task WhenIGetMyOwnRights()
        {
            var client = await IntegrationTestEnvironment.GetClient("tst", "topsecretunittestpassword");
            _result = await client.GetAsJsonAsync<IEnumerable<Kiss4UserRight>>(Url.GetOwnRights);
        }

        [Then(@"the call should be successful")]
        public void ThenTheCallShouldBeSuccessful()
        {
            _result.ShouldBeOk();
        }

        [Then(@"the received rights should be")]
        public void ThenTheReceivedRightsShouldBe(Table table)
        {
            var rightsReceived = _result.Result.ToList();
            rightsReceived.ShouldNotBeNull();
            rightsReceived.ShouldNotBeEmpty();

            var expected = _testDataManager.CreateSetWithLookup<Kiss4UserRight>(table).ToList();
            rightsReceived.ShouldBePartially(expected, table.Header);
        }

        [AfterScenario]
        public Task CleanupData()
        {
            return _testDataManager.Cleanup();
        }
    }
}