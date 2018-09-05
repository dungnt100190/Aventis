using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Modules.Pendenzen.SearchPendenzen;
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
    public class SearchPendenzenSteps : IntegrationTest
    {
        private DynamicTestDataManager _testDataManager;
        private HttpClient _client;
        private string _menuId;
        private SearchPendenzenQuery _searchTaskCondition;
        private ServiceResult<IEnumerable<PendenzenItem>> _listPendenzen;

        public SearchPendenzenSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"these UserAdmin for SearchPendenzen feature")]
        public async Task GivenTheseUserAdmin(Table table)
        {
            await _testDataManager.Insert<XUser>(table);
        }

        [Given(@"these BaPerson for SearchPendenzen feature")]
        public async Task GivenTheseBaPerson(Table table)
        {
            await _testDataManager.Insert<BaPerson>(table);
        }

        [Given(@"these FaLeistung for SearchPendenzen feature")]
        public async Task GivenTheseFaLeistung(Table table)
        {
            await _testDataManager.Insert<FaLeistung>(table);
        }

        [Given(@"these Tasks for SearchPendenzen feature")]
        public async Task GivenTheseTasks(Table table)
        {
            await _testDataManager.Insert<XTask>(table);
        }

        [Given(@"SearchPendenzen client has LogonName is (.*), PasswordHash is (.*)")]
        public async Task GivenSearchPendenzenClientHasLogonNameIsPasswordHashIs(string p0, string p1)
        {
            _client = await IntegrationTestEnvironment.GetClient(p0, p1);
        }

        [Given(@"menu item id for SearchPendenzen is (.*)")]
        public void GivenMenuItemIdForSearchPendenzenIs(string p0)
        {
            _menuId = p0;
        }
        
        [Given(@"search condition")]
        public void GivenSearchCondition(Table table)
        {
            _searchTaskCondition = _testDataManager.CreateSetWithLookup<SearchPendenzenQuery>(table).First();
            _searchTaskCondition.IdMenu = _menuId;
        }

        [When(@"call SearchPendenzen")]
        public async Task WhenCallSearchPendenzen()
        {
            //var client = await IntegrationTestEnvironment.GetClient(_username, _password);
            _listPendenzen = await _client.PostAsJsonAsync<SearchPendenzenQuery, IEnumerable<PendenzenItem>>(Url.SearchPendenzen, _searchTaskCondition) as ServiceResult<IEnumerable<PendenzenItem>>;
        }

        [Then(@"the list of found Task should be")]
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
