using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.TestServer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.API
{
    [Binding]
    public class CommonSteps : IntegrationTest
    {
        public CommonSteps(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [BeforeScenario]
        public void Setup()
        {
            TestDataManager.Setup();
        }

        [Given(@"these XUser")]
        public void GivenTheseXUser(Table table)
        {
            try
            {
                TestDataManager.Insert<XUser>(table);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
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

        [Given(@"these FaLeistung")]
        public void GivenTheseFaLeistung(Table table)
        {
            try
            {
                TestDataManager.Insert<FaLeistung>(table);
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
            try
            {
                TestDataManager.Insert<XTask>(table);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Given(@"init client with username is '(.*)', password is '(.*)'")]
        public void GivenInitClientWithUsernameIsPasswordIsAsync(string username, string password)
        {
            try
            {
                TestDataManager.InitClient(username, password);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the record of the inputted info is inserted into table XTask in database")]
        public void ThenTheRecordOfTheInputtedInfoIsInsertedIntoTableXTaskInDatabase()
        {
            try
            {
                TestDataManager.CheckAddUpdateEntityExistsInDB<XTask>();
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the call is successful")]
        public void ThenTheCallIsSuccessful()
        {
            try
            {
                TestDataManager.CheckCallApiStatus();
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
