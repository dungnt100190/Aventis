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
    public class LoadPendenzenSteps : IntegrationTest
    {
        private DynamicTestDataManager _testDataManager;
        private HttpClient _client;
        private string _menuId;
        private ServiceResult<IEnumerable<PendenzenItem>> _listPendenzen;

        public LoadPendenzenSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"LoadPendenzen client has LogonName is (.*), PasswordHash is (.*)")]
        public async Task GivenLoadPendenzenClientHasLogonNameIsPasswordHashIs(string p0, string p1)
        {
            _client = await IntegrationTestEnvironment.GetClient(p0, p1);
        }
        
        [Given(@"menu item id is (.*)")]
        public void GivenMenuItemIdIs(string p0)
        {
            _menuId = p0;
        }
        
        [When(@"call GetPendenzenData")]
        public async Task WhenCallGetPendenzenData()
        {
            _listPendenzen = await _client.GetAsJsonAsync<IEnumerable<PendenzenItem>>(string.Format(Url.GetPendenzenData, _menuId), null);
        }
        
        [Then(@"the list of Task should be")]
        public void ThenTheListOfTaskShouldBe(Table table)
        {
            var listPendenzenReceived = _listPendenzen.Result.ToList();
            listPendenzenReceived.ShouldNotBeNull();
            listPendenzenReceived.ShouldNotBeEmpty();

            var expected = _testDataManager.CreateSetWithLookup<PendenzenItem>(table).ToList();
            listPendenzenReceived.ShouldBePartially(expected, table.Header);
        }

        [AfterScenario]
        public Task CleanupData()
        {
            return _testDataManager.Cleanup();
        }
    }
}
