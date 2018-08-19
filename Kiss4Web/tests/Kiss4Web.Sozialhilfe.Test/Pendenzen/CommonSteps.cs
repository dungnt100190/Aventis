using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Kiss4Web.TestInfrastructure.TestServer;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Kiss4Web.Sozialhilfe.Test.Pendenzen
{
    [Binding]
    public class CommonSteps : IntegrationTest
    {
        private DynamicTestDataManager _testDataManager;

        public CommonSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"these UserAdmin")]
        public async Task GivenTheseUserAdmin(Table table)
        {
            await _testDataManager.Insert<XUser>(table);
        }
        
        [Given(@"these BaPerson")]
        public async Task GivenTheseBaPerson(Table table)
        {
            await _testDataManager.Insert<BaPerson>(table);
        }
        
        //[Given(@"these Xmodul")]
        //public async Task GivenTheseXmodul(Table table)
        //{
        //    await _testDataManager.Insert<XModul>(table);
        //}
        
        [Given(@"these FaLeistung")]
        public async Task GivenTheseFaLeistung(Table table)
        {
            await _testDataManager.Insert<FaLeistung>(table);
        }
        
        [Given(@"these Tasks")]
        public async Task GivenTheseTasks(Table table)
        {
            await _testDataManager.Insert<Xtask>(table);
        }

        [AfterScenario]
        public Task CleanupData()
        {
            return _testDataManager.Cleanup();
        }
    }
}
