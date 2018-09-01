using Kiss4Web.Resource;
using Kiss4Web.Test.TestInfrastructure;
using System;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.TesterDemo
{
    [Binding]
    public class FilterPendenzenSteps
    {
        [BeforeScenario("FilterPendenzen")]
        private void Setup()
        {
            TestDataManager.Setup();
        }

        [When(@"Click search icon in (.*) field, choose option (.*) and input (.*)")]
        public void WhenClickSearchIconInField(string field, string option, string text)
        {
            try
            {
                TestDataManager.InputDropdownGridFilter(string.Format(XPathPendenzen.GridTaskFieldsHeader, field), option);
                //TestDataManager.Click(string.Format(XPathPendenzen.GridTaskFieldsHeader + "//*[contains(@class,'dx-menu-horizontal')]", field));
                //TestDataManager.Click(string.Format("//*[contains(@class,'dx-overlay-wrapper')]//*[contains(text(),'{0}')]", option));
                TestDataManager.Input(string.Format(XPathPendenzen.GridTaskFieldsHeader + XPath0Common.Textbox, field), text);
                TestDataManager.Click(XPathPendenzen.GridTask, waitingTime: 2);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"Task grid does not have data")]
        public void TaskGridDoesNotHaveData()
        {
            try
            {
                TestDataManager.CheckControlExists(string.Format(XPathPendenzen.GridTaskFields, "Betreff"), isExists: false);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [AfterScenario("FilterPendenzen")]
        private void Cleanup()
        {
            TestDataManager.Cleanup();
        }
    }
}
