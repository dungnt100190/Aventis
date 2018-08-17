using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Kiss4Web.TestInfrastructure.TestServer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Kiss4Web.Sozialhilfe.Test.Pendenzen
{
    [Binding]
    public class PendenzenSteps : IntegrationTest
    {
        private ServiceResult<NavBarItemItem> _navBarItem;
        private DynamicTestDataManager _testDataManager;

        public PendenzenSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"these Tasks")]
        public async Task GivenTheseTasks(Table table)
        {
            await _testDataManager.Insert<Xtask>(table);
        }
        
        [Given(@"id of menu item")]
        public void GivenIdOfMenuItem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Task Id")]
        public void GivenTaskId()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"search condition")]
        public void GivenSearchCondition(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"call LoadNavBarItems")]
        public async Task WhenCallLoadNavBarItems()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.NewAdmin);
            _navBarItem = await client.GetAsJsonAsync<NavBarItemItem>(Url.LoadNavBarItems, null);
        }
        
        [When(@"call GetPendenzenData")]
        public void WhenCallGetPendenzenData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"call GetPendenzenDetail")]
        public void WhenCallGetPendenzenDetail()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"call SearchPendenzen")]
        public void WhenCallSearchPendenzen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the count of navbar items should be")]
        public void ThenTheCountOfNavbarItemsShouldBe(Table table)
        {
            var navbarItemReceived = new List<NavBarItemItem>();
            navbarItemReceived.Add(_navBarItem.Result);

            var expected = _testDataManager.CreateSetWithLookup<NavBarItemItem>(table).ToList();
            navbarItemReceived.ShouldBePartially(expected, table.Header);
        }
        
        [Then(@"the list of Task should be")]
        public void ThenTheListOfTaskShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the detail data of Task should be")]
        public void ThenTheDetailDataOfTaskShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [AfterScenario]
        public Task CleanupData()
        {
            return _testDataManager.Cleanup();
        }
    }
}
