using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Modules.Pendenzen.CreateOrUpdate;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Kiss4Web.TestInfrastructure.TestServer;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Kiss4Web.Sozialhilfe.Test.Pendenzen
{
    [Binding]
    public class EditPendenzenSteps : IntegrationTest
    {
        private DynamicTestDataManager _testDataManager;
        private List<XUser> _listUser;
        private HttpClient _client;
        private CreateUpdateQuery _inputPendenzen;
        private ServiceResult<bool> _result;
        private ServiceResult<PendenzenDetailItem> _outputPendenzen;

        public EditPendenzenSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"these UserAdmin for EditPendenzen feature")]
        public async Task GivenTheseUserAdminForEditPendenzenFeature(Table table)
        {
            await _testDataManager.Insert<XUser>(table);
            _listUser = _testDataManager.CreateSetWithLookupForEntity<XUser>(table).ToList();
        }

        [Given(@"these Tasks for EditPendenzen feature")]
        public async Task GivenTheseTasksForEditPendenzenFeature(Table table)
        {
            await _testDataManager.Insert<XTask>(table);
        }

        [Given(@"EditPendenzen client has LogonName is (.*), PasswordHash is (.*)")]
        public async Task GivenEditPendenzenClientHasLogonNameIsPasswordHashIs(string p0, string p1)
        {
            _client = await IntegrationTestEnvironment.GetClient(p0, p1);
        }

        [Given(@"this new data for Pendenzen (\w+), \[empfangerId] is (\w+)")]
        public void GivenThisNewDataForPendenzen(string taskLogicalName, string receiverLogicalName, Table table)
        {
            _inputPendenzen = _testDataManager.CreateSetWithLookup<CreateUpdateQuery>(table).First();
            _inputPendenzen.id = _testDataManager.Lookup<XTask>(taskLogicalName);
            _inputPendenzen.empfangerId = _testDataManager.Lookup<XUser>(receiverLogicalName);
        }

        [When(@"call CreateUpdateTask for EditPendenzen feature")]
        public async Task WhenCallCreateUpdateTask()
        {
            _result = await _client.PostAsJsonAsync<CreateUpdateQuery, bool>(Url.CreateUpdateTask, _inputPendenzen) as ServiceResult<bool>;
            _outputPendenzen = await _client.GetAsJsonAsync<PendenzenDetailItem>(string.Format(Url.GetPendenzenDetail, _inputPendenzen.id), null);
        }

        [Then(@"the call UpdateTask should be return true")]
        public void ThenTheCallShouldBeReturnTrue()
        {
            Assert.That(_result.Result == true);
        }

        [Then(@"the updated Pendenzen should be")]
        public void ThenTheUpdatedPendenzenShouldBe(Table table)
        {
            var detailPendenzenReceived = new List<PendenzenDetailItem>();
            detailPendenzenReceived.Add(_outputPendenzen.Result);
            detailPendenzenReceived.ShouldNotBeNull();
            detailPendenzenReceived.ShouldNotBeEmpty();

            var expected = _testDataManager.CreateSetWithLookup<PendenzenDetailItem>(table).ToList();
            detailPendenzenReceived.ShouldBePartially(expected, table.Header);

            _testDataManager.Delete<XTask>(_inputPendenzen.id);
            for (int i = 0; i < _listUser.Count; ++i)
            {
                _testDataManager.Delete<XUser>(_listUser[i].UserId);
            }
        }

        //[AfterScenario]
        //public void CleanupData()
        //{

        //}
    }
}
