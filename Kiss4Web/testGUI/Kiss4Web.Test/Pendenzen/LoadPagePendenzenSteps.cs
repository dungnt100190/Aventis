﻿using Kiss4Web.Resource;
using Kiss4Web.Test.DataAccess;
using Kiss4Web.Test.TestInfrastructure;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Pendenzen
{
    [Binding]
    public class LoadPagePendenzenSteps
    {
        [BeforeScenario("LoadPendenzen")]
        private void Setup()
        {
            TestDataManager.Setup();
        }

        [Given(@"these XUsers")]
        public void GivenTheseXUsers(Table table)
        {
            TestDataManager.Insert<XUser>(table);
        }
        
        [Given(@"these BaPersons")]
        public void GivenTheseBaPersons(Table table)
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
        
        [Given(@"these FaLeistungs")]
        public void GivenTheseFaLeistungs(Table table)
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
        
        [Given(@"these XTasks")]
        public void GivenTheseXTasks(Table table)
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
        
        [Given(@"User has logon with username is (.*), password is (.*)")]
        public void WhenUserLoginWithUsernameIsPasswordIs(string p0, string p1)
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
        
        [Given(@"Page Pendenzen is redirected to")]
        public void ThenPagePendenzenIsRedirectedTo()
        {
            try
            {
                TestDataManager.CompareUrl(Urls.UrlPendenzen);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }
        
        [Then(@"the count of navbar items should be")]
        public void ThenTheCountOfNavbarItemsShouldBe(Table table)
        {
            Dictionary<string, string> xPaths = new Dictionary<string, string>();
            xPaths.Add(XPathPendenzen.NavbarItems, null);
            try
            {
                TestDataManager.CheckTableData(table, xPaths);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }
        
        [Then(@"data of grid view Task should be")]
        public void ThenDataOfGridViewTaskShouldBe(Table table)
        {
            Dictionary<string, string> xPaths = new Dictionary<string, string>();
            xPaths.Add(XPathPendenzen.GridTaskFields, null);

            Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
            fieldMapping.Add("Falltrager", "BaPersonID");
            fieldMapping.Add("Fallnummer", "BaPersonID");

            try
            {
                TestDataManager.CheckTableData(table, xPaths, refFieldMapping: fieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [AfterScenario("LoadPendenzen")]
        private void Cleanup()
        {
            TestDataManager.Cleanup();
        }
    }
}