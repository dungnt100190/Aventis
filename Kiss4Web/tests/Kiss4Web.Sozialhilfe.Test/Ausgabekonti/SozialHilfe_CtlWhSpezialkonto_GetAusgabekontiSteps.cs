//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Kiss4Web.Model;
//using Kiss4Web.Model.QueryTypes;
//using Kiss4Web.Model.Sozialhilfe;
//using Kiss4Web.TestInfrastructure;
//using Kiss4Web.TestInfrastructure.Client;
//using Kiss4Web.TestInfrastructure.TestData.Dynamic;
//using Kiss4Web.TestInfrastructure.TestServer;
//using Shouldly;
//using TechTalk.SpecFlow;

//namespace Kiss4Web.Sozialhilfe.Test.Ausgabekonti
//{
//    [Binding]
//    public class SozialHilfe_CtlWhSpezialkonto_GetAusgabekontiSteps : IntegrationTest
//    {
//        private ServiceResult<IEnumerable<SpezialkontoDisplayItem>> _result;
//        private TestDataHandler _testDataManager;

//        public SozialHilfe_CtlWhSpezialkonto_GetAusgabekontiSteps(TestServerFixture integrationTestEnvironment)
//            : base(integrationTestEnvironment)
//        {
//            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager(integrationTestEnvironment);
//        }

//        [BeforeScenario]
//        public void Setup()
//        {
//        }

//        [Given(@"these Personen")]
//        public async Task GivenAusg_InitializeBaPerson(Table table)
//        {
//            await _testDataManager.Insert<BaPerson>(table);
//        }

//        [Given(@"these Leistungen")]
//        public async Task GivenAusg_InitializeFaLeistung(Table table)
//        {
//            await _testDataManager.Insert<FaLeistung>(table);
//        }

//        [Given(@"these Finanzpläne")]
//        public async Task GivenAusg_InitializeBgFinanzplan(Table table)
//        {
//            await _testDataManager.Insert<BgFinanzplan>(table);
//        }

//        [Given(@"these Finanzplanmitglieder")]
//        public async Task GivenAusg_InitializeBgFinanzplan_BaPerson(Table table)
//        {
//            await _testDataManager.Insert<BgFinanzplanBaPerson>(table);
//        }

//        [Given(@"these Budgets")]
//        public async Task GivenAusg_InitializeBgBudget(Table table)
//        {
//            await _testDataManager.Insert<BgBudget>(table);
//        }

//        [Given(@"these Spezialkonti")]
//        public async Task GivenAusg_InitializeBgSpezkonto(Table table)
//        {
//            await _testDataManager.Insert<BgSpezkonto>(table);
//        }

//        [Given(@"current month is ([0-9]*).([0-9]*)")]
//        public void GivenCurrentTimeIs(int month, int year)
//        {
//            IntegrationTestEnvironment.DateTime.SetLocalTime(new DateTime(year, month, 1));
//        }

//        [When(@"getting Ausgabekonti of Leistung (\w+), \[nur aktive] is (\w+)")]
//        public async Task WhenGettingAusgabekonti(string leistungLogicalName, bool nurAktive)
//        {
//            var faLeistungId = _testDataManager.Lookup<FaLeistung>(leistungLogicalName);
//            var client = await IntegrationTestEnvironment.GetClient(TestUser.Administrator);
//            _result = await client.GetAsJsonAsync<IEnumerable<SpezialkontoDisplayItem>>(string.Format(Url.GetSpezialkonten, faLeistungId), new { typ = BgSpezkontoTyp.Ausgabekonti, nurAktive });
//        }

//        [Then(@"the call should be successful")]
//        public void ThenTheResponseShouldContainHttpCodeIs_MeaningTheRequestPerformSuccessfully()
//        {
//            _result.IsSuccess.ShouldBeTrue();
//        }

//        [Then(@"the received Spezialkonti should be")]
//        public void ThenDataIsShownInDatatableAsTheFollowing(Table table)
//        {
//            var spezialkontiReceived = _result.Result.ToList();
//            spezialkontiReceived.ShouldNotBeNull();
//            spezialkontiReceived.ShouldNotBeEmpty();

//            var expected = _testDataManager.CreateSetWithLookup<SpezialkontoDisplayItem>(table).ToList();
//            spezialkontiReceived.ShouldBePartially(expected, table.Header);
//        }

//        //[AfterScenario]
//        //public Task CleanupData()
//        //{
//        //    return _testDataManager.Cleanup();
//        //}
//    }
//}