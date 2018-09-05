using Kiss4Web.Test.DataAccess;
using Kiss4Web.Test.TestInfrastructure;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Common
{
    [Binding]
    public class CommonSteps
    {
        [BeforeScenario()]
        private void Setup()
        {
            TestDataManager.Setup();
        }

        [Given(@"these XUser")]
        public void GivenTheseXUser(Table table)
        {
            TestDataManager.Insert<XUser>(table);
        }

        [Given(@"these BaPerson")]
        public void GivenTheseBaPerson(Table table)
        {
            try
            {
                TestDataManager.Insert<BaPerson>(table);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Given(@"these XModul")]
        public void GivenTheseXModul(Table table)
        {
            try
            {
                TestDataManager.Insert<XModul>(table);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Given(@"these FaLeistung")]
        public void GivenTheseFaLeistung(Table table)
        {
            Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
            fieldMapping.Add("FaFallID", "BaPersonID");
            try
            {
                TestDataManager.Insert<FaLeistung>(table, fieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Given(@"these XTask")]
        public void GivenTheseXTask(Table table)
        {
            Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
            fieldMapping.Add("SenderID", "UserID");
            fieldMapping.Add("ReceiverID", "UserID");
            fieldMapping.Add("FaFallID", "BaPersonID");
            try
            {
                TestDataManager.Insert<XTask>(table, fieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Given(@"logon with username is '(.*)', password is '(.*)'")]
        public void LogonWithUsernameIsPasswordIs(string p0, string p1)
        {
            try
            {
                TestDataManager.Login(p0, p1);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the record of the inputted info is inserted into table XTask in database")]
        public void RecordOfInputtedInfoIsInsertedIntoTableXTaskInDatabase()
        {
            try
            {
                TestDataManager.CheckEntityExistsInDB<XTask>(TestDataManager.TempAddedEntities[TestDataManager.TempAddedEntities.Count - 1]);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the record of the inputted info is not inserted into table XTask in database")]
        public void RecordOfInputtedInfoIsNotInsertedIntoTableXTaskInDatabase()
        {
            try
            {
                TestDataManager.CheckEntityExistsInDB<XTask>(TestDataManager.TempAddedEntities[TestDataManager.TempAddedEntities.Count - 1], false);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [AfterScenario()]
        private void Cleanup()
        {
            TestDataManager.Cleanup();
        }
    }
}
