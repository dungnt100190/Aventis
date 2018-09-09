using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Kiss4Web.Modules.Pendenzen.CreateOrUpdate;
using Kiss4Web.Modules.Pendenzen.SearchPendenzen;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.TestServer;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.API
{
    [Binding]
    public class PendenzenSteps : IntegrationTest
    {
        public PendenzenSteps(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            TestDataManager.Setup();
        }

        [When(@"call API LoadNavBarItems")]
        public void WhenCallAPILoadNavBarItems()
        {
            try
            {
                TestDataManager.CallApiGetReturnObject<NavBarItemItem>(Url.LoadNavBarItems);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the return data of API LoadNavBarItems should be")]
        public void ThenTheReturnDataOfAPILoadNavBarItemsShouldBe(Table table)
        {
            try
            {
                TestDataManager.CheckCallApiReturnData<NavBarItemItem>(table);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"call API GetPendenzenData with itemType is '(.*)'")]
        public void WhenCallAPIGetPendenzenDataWithItemTypeIs(string itemType)
        {
            try
            {
                TestDataManager.CallApiGetReturnList<PendenzenItem>(string.Format(Url.GetPendenzenData, itemType));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the return data of API GetPendenzenData should be")]
        public void ThenTheReturnDataOfAPIGetPendenzenDataShouldBe(Table table)
        {
            try
            {
                Dictionary<string, string> idFieldMapping = new Dictionary<string, string>();
                idFieldMapping.Add("FaFall", "BaPersonID");
                idFieldMapping.Add("Fallnummer", "BaPersonID");
                TestDataManager.CheckCallApiReturnData<PendenzenItem>(table, idFieldMapping: idFieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"call API SearchPendenzen with input data as below")]
        public void WhenCallAPISearchPendenzenWithInputDataAsBelow(Table table)
        {
            try
            {
                var searchCondition = TestDataManager.CreateSetWithLookup<SearchPendenzenQuery>(table).First();
                TestDataManager.CallApiPostReturnList<SearchPendenzenQuery, TablePendenzenItem>(Url.SearchPendenzen, searchCondition);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the return data of API SearchPendenzen should be")]
        public void ThenTheReturnDataOfAPISearchPendenzenShouldBe(Table table)
        {
            try
            {
                Dictionary<string, string> idFieldMapping = new Dictionary<string, string>();
                idFieldMapping.Add("FaFall", "BaPersonID");
                idFieldMapping.Add("Fallnummer", "BaPersonID");
                TestDataManager.CheckCallApiReturnData<TablePendenzenItem>(table, idFieldMapping: idFieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"call API GetPendenzenDetail with taskId is '(.*)'")]
        public void WhenCallAPIGetPendenzenDetailWithTaskIdIs(string idLogicalName)
        {
            try
            {
                var taskId = TestDataManager.Lookup<XTask>(idLogicalName);
                TestDataManager.CallApiGetReturnObject<PendenzenDetailItem>(string.Format(Url.GetPendenzenDetail, taskId));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the return data of API GetPendenzenDetail should be")]
        public void ThenTheReturnDataOfAPIGetPendenzenDetailShouldBe(Table table)
        {
            try
            {
                TestDataManager.CheckCallApiReturnData<PendenzenDetailItem>(table);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"call API CreateUpdateTask in EditPendenzen with input data as below")]
        public void WhenCallAPICreateUpdateTaskInEditPendenzenWithInputDataAsBelow(Table table)
        {
            try
            {
                Dictionary<string, string> idFieldMapping = new Dictionary<string, string>();
                idFieldMapping.Add("id", "XTaskID");
                idFieldMapping.Add("empfangerId", "UserID");
                idFieldMapping.Add("falltrager", "BaPersonID");
                idFieldMapping.Add("leistung", "FaLeistungID");
                idFieldMapping.Add("PersonId", "BaPersonID");
                var updateCondition = TestDataManager.CreateSetWithLookup<CreateUpdateQuery>(table, idFieldMapping: idFieldMapping).First();
                TestDataManager.CallApiPostReturnObject<CreateUpdateQuery, bool>(Url.CreateUpdateTask, updateCondition);

                Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
                fieldMapping.Add("id", "XTaskID");
                fieldMapping.Add("status", "TaskStatusCode");
                fieldMapping.Add("pendenzTyp", "TaskTypeCode");
                fieldMapping.Add("betreff", "Subject");
                fieldMapping.Add("beschreibung", "TaskDescription");
                fieldMapping.Add("empfangerId", "ReceiverID");
                fieldMapping.Add("falltrager", "FaFallID");
                fieldMapping.Add("leistung", "FaLeistungID");
                fieldMapping.Add("PersonId", "BaPersonID");
                fieldMapping.Add("antwort", "ResponseText");
                Dictionary<string, string> xtaskIdFieldMapping = new Dictionary<string, string>();
                xtaskIdFieldMapping.Add("SenderID", "UserID");
                xtaskIdFieldMapping.Add("ReceiverID", "UserID");
                xtaskIdFieldMapping.Add("FaFallID", "BaPersonID");
                TestDataManager.AddToTempEntities<XTask>(table, fieldMapping: fieldMapping, idFieldMapping: xtaskIdFieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"call API CreateUpdateTask in CreatePendenzen with input data as below")]
        public void WhenCallAPICreateUpdateTaskInCreatePendenzenWithInputDataAsBelow(Table table)
        {
            try
            {
                Dictionary<string, string> idFieldMapping = new Dictionary<string, string>();
                idFieldMapping.Add("empfangerId", "UserID");
                idFieldMapping.Add("falltrager", "BaPersonID");
                idFieldMapping.Add("leistung", "FaLeistungID");
                idFieldMapping.Add("PersonId", "BaPersonID");
                var insertCondition = TestDataManager.CreateSetWithLookup<CreateUpdateQuery>(table, idFieldMapping: idFieldMapping).First();
                TestDataManager.CallApiPostReturnObject<CreateUpdateQuery, bool>(Url.CreateUpdateTask, insertCondition);

                Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
                fieldMapping.Add("status", "TaskStatusCode");
                fieldMapping.Add("pendenzTyp", "TaskTypeCode");
                fieldMapping.Add("betreff", "Subject");
                fieldMapping.Add("beschreibung", "TaskDescription");
                fieldMapping.Add("empfangerId", "ReceiverID");
                fieldMapping.Add("falltrager", "FaFallID");
                fieldMapping.Add("leistung", "FaLeistungID");
                fieldMapping.Add("PersonId", "BaPersonID");
                fieldMapping.Add("antwort", "ResponseText");
                Dictionary<string, string> xtaskIdFieldMapping = new Dictionary<string, string>();
                xtaskIdFieldMapping.Add("SenderID", "UserID");
                xtaskIdFieldMapping.Add("ReceiverID", "UserID");
                xtaskIdFieldMapping.Add("FaFallID", "BaPersonID");
                TestDataManager.AddToTempEntities<XTask>(table, fieldMapping: fieldMapping, idFieldMapping: xtaskIdFieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the return value of API CreateUpdateTask should be true")]
        public void ThenTheReturnValueOfAPICreateUpdateTaskShouldBeTrue()
        {
            try
            {
                TestDataManager.CheckCallApiReturnValue(true);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [AfterScenario]
        public void Cleanup()
        {
            TestDataManager.Cleanup();
        }
    }
}
