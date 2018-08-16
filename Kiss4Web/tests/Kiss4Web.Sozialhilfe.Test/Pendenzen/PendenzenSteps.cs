using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Kiss4Web.TestInfrastructure.TestServer;
using System;
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
        private int _userId;

        public PendenzenSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        //[Given(@"these BaPerson")]
        //public async Task GivenTheseBaPersonAsync(Table table)
        //{
        //    await _testDataManager.Insert<BaPerson>(table);
        //}
        
        //[Given(@"these vwUser")]
        //public async Task GivenTheseVwUserAsync(Table table)
        //{
        //    await _testDataManager.Insert<XUser>(table);
        //}
        
        //[Given(@"these Xmodul")]
        //public async Task GivenTheseXmodulAsync(Table table)
        //{
        //    await _testDataManager.Insert<XModul>(table);
        //}
        
        //[Given(@"these FaFall")]
        //public void GivenTheseFaFallAsync(Table table)
        //{
        //    //await _testDataManager.Insert<FaFall>(table);
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"these FaLeistung")]
        //public void GivenTheseFaLeistung(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"these XOrgUnit")]
        //public void GivenTheseXOrgUnit(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"these XOrgUnit_User")]
        //public void GivenTheseXOrgUnit_User(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"these XLOVCode")]
        //public void GivenTheseXLOVCode(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"these vwPersonSimple")]
        //public void GivenTheseVwPersonSimple(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"these FaPendenzgruppe")]
        //public void GivenTheseFaPendenzgruppe(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"these Tasks")]
        //public void GivenTheseTasks(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"curent userId is (.*)")]
        //public void GivenCurentUserIdIs(int userId)
        //{
        //    _userId = userId;
        //}
        
        [When(@"Call LoadNavBarItems")]
        public async Task WhenCallLoadNavBarItems()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.NewAdmin);
            _navBarItem = await client.GetAsJsonAsync<NavBarItemItem>(Url.LoadNavBarItems, null);
        }

        [Then(@"the NavBarItems should be")]
        public void ThenTheNavBarItemsShouldBe(Table table)
        {
            var navbarItemReceived = new List<NavBarItemItem>();
            navbarItemReceived.Add(_navBarItem.Result);

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
