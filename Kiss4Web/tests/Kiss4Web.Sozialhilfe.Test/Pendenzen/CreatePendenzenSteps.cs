using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Modules.Pendenzen.CreateOrUpdate;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestData.Dynamic;
using Kiss4Web.TestInfrastructure.TestServer;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Kiss4Web.Sozialhilfe.Test.Pendenzen
{
    [Binding]
    public class CreatePendenzenSteps : IntegrationTest
    {
        private DynamicTestDataManager _testDataManager;
        private HttpClient _client;
        private CreateUpdateQuery _inputPendenzen;
        private ServiceResult<bool> _result;

        public CreatePendenzenSteps(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = IntegrationTestEnvironment.CreateTestDataManager();
        }

        [Given(@"these UserAdmin for CreatePendenzen feature")]
        public async Task GivenTheseUserAdminForCreatePendenzenFeature(Table table)
        {
            await _testDataManager.Insert<XUser>(table);
        }
        
        [Given(@"these Tasks for CreatePendenzen feature")]
        public async Task GivenTheseTasksForCreatePendenzenFeature(Table table)
        {
            await _testDataManager.Insert<Xtask>(table);
        }
        
        [Given(@"CreatePendenzen client has LogonName is (.*), PasswordHash is (.*)")]
        public async Task GivenCreatePendenzenClientHasLogonNameIsPasswordHashIs(string p0, string p1)
        {
            _client = await IntegrationTestEnvironment.GetClient(p0, p1);
        }
        
        [Given(@"this new Pendenzen, \[empfangerId] is (\w+), \[SenderId] is (\w+)")]
        public void GivenThisNewPendenzenEmpfangerIdIsUSRSenderIdIsUSR(string receiverLogicalName, string senderLogicalName, Table table)
        {
            _inputPendenzen = _testDataManager.CreateSetWithLookup<CreateUpdateQuery>(table).First();
            _inputPendenzen.empfangerId = _testDataManager.Lookup<XUser>(receiverLogicalName);
            _inputPendenzen.SenderId = _testDataManager.Lookup<XUser>(senderLogicalName).ToString();
        }

        [When(@"call CreateUpdateTask for CreatePendenzen feature")]
        public async Task WhenCallCreateUpdateTask()
        {
            _result = await _client.PostAsJsonAsync<CreateUpdateQuery, bool>(Url.CreateUpdateTask, _inputPendenzen) as ServiceResult<bool>;
        }

        [Then(@"the call CreateTask should be return true")]
        public void ThenTheCallCreateTaskShouldBeReturnTrue()
        {
            Assert.That(_result.Result == true);
        }

        [Then(@"the created Pendenzen is after (\w+) and should be")]
        public async Task ThenTheCreatedPendenzenShouldBe(string taskLogicalName, Table table)
        {
            var taskId = _testDataManager.Lookup<Xtask>(taskLogicalName);
            var outputPendenzen = await _client.GetAsJsonAsync<PendenzenDetailItem>(string.Format(Url.GetPendenzenDetail, taskId + 1), null);

            var detailPendenzenReceived = new List<PendenzenDetailItem>();
            detailPendenzenReceived.Add(outputPendenzen.Result);
            detailPendenzenReceived.ShouldNotBeNull();
            detailPendenzenReceived.ShouldNotBeEmpty();

            var expected = _testDataManager.CreateSetWithLookup<PendenzenDetailItem>(table).ToList();
            detailPendenzenReceived.ShouldBePartially(expected, table.Header);
        }

        //[AfterScenario]
        //public Task CleanupData()
        //{
        //    return _testDataManager.Cleanup();
        //}
    }
}
