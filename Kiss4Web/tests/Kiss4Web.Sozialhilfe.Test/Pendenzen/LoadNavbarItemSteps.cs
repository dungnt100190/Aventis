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
    public class LoadNavbarItemSteps : IntegrationTest
    {
        private DynamicTestDataManager _testDataManager;
        private HttpClient _client;
        private ServiceResult<NavBarItemItem> _navBarItem;

        public LoadNavbarItemSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"LoadNavbarItem client has LogonName is (.*), PasswordHash is (.*)")]
        public async Task GivenLoadNavbarItemClientHasLogonNameIsPasswordHashIs(string p0, string p1)
        {
            _client = await IntegrationTestEnvironment.GetClient(p0, p1);
        }
        
        [When(@"call LoadNavBarItems")]
        public async Task WhenCallLoadNavBarItems()
        {
            _navBarItem = await _client.GetAsJsonAsync<NavBarItemItem>(Url.LoadNavBarItems, null);
        }
        
        [Then(@"the count of navbar items should be")]
        public void ThenTheCountOfNavbarItemsShouldBe(Table table)
        {
            var navbarItemReceived = new List<NavBarItemItem>();
            navbarItemReceived.Add(_navBarItem.Result);
            navbarItemReceived.ShouldNotBeNull();
            navbarItemReceived.ShouldNotBeEmpty();

            var expected = _testDataManager.CreateSetWithLookup<NavBarItemItem>(table).ToList();
            navbarItemReceived.ShouldBePartially(expected, table.Header);
        }

        [AfterScenario]
        public Task CleanupData()
        {
            return _testDataManager.Cleanup();
        }
    }
}
