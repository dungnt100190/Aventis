using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Kiss4Web.Sozialhilfe.Test.Pendenzen
{
    [Binding]
    public class GetPendenzenDetailSteps : IntegrationTest
    {
        private DynamicTestDataManager _testDataManager;
        private HttpClient _client;
        private ServiceResult<PendenzenDetailItem> _detailPendenzen;

        public GetPendenzenDetailSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"these UserAdmin for GetPendenzenDetail feature")]
        public async Task GivenTheseUserAdmin(Table table)
        {
            await _testDataManager.Insert<XUser>(table);
        }

        [Given(@"these BaPerson for GetPendenzenDetail feature")]
        public async Task GivenTheseBaPerson(Table table)
        {
            await _testDataManager.Insert<BaPerson>(table);
        }

        [Given(@"these FaLeistung for GetPendenzenDetail feature")]
        public async Task GivenTheseFaLeistung(Table table)
        {
            await _testDataManager.Insert<FaLeistung>(table);
        }

        [Given(@"these Tasks for GetPendenzenDetail feature")]
        public async Task GivenTheseTasks(Table table)
        {
            await _testDataManager.Insert<Xtask>(table);
        }

        [Given(@"GetPendenzenDetail client has LogonName is (.*), PasswordHash is (.*)")]
        public async Task GivenGetPendenzenDetailClientHasLogonNameIsPasswordHashIs(string p0, string p1)
        {
            _client = await IntegrationTestEnvironment.GetClient(p0, p1);
        }
        
        [When(@"call GetPendenzenDetail of Task (\w+)")]
        public async Task WhenCallGetPendenzenDetailOfTask(string taskLogicalName)
        {
            var taskId = _testDataManager.Lookup<Xtask>(taskLogicalName);
            _detailPendenzen = await _client.GetAsJsonAsync<PendenzenDetailItem>(string.Format(Url.GetPendenzenDetail, taskId), null);
        }
        
        [Then(@"the detail data of Task should be")]
        public void ThenTheDetailDataOfTaskShouldBe(Table table)
        {
            var detailPendenzenReceived = new List<PendenzenDetailItem>();
            detailPendenzenReceived.Add(_detailPendenzen.Result);
            detailPendenzenReceived.ShouldNotBeNull();
            detailPendenzenReceived.ShouldNotBeEmpty();

            var expected = _testDataManager.CreateSetWithLookup<PendenzenDetailItem>(table).ToList();
            detailPendenzenReceived.ShouldBePartially(expected, table.Header);
        }

        [AfterScenario]
        public Task CleanupData()
        {
            return _testDataManager.Cleanup();
        }
    }
}
