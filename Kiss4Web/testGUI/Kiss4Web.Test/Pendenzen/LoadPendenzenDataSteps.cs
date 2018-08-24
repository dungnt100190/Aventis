using Kiss4Web.Test.Model.Pendenzen;
using Kiss4Web.Test.TestInfrastructure;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Pendenzen
{
    [Binding]
    public class LoadPendenzenDataSteps
    {
        private TestDataManager _testDataManager;
        private IWebDriver _driver;

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = new TestDataManager();
        }

        [Then(@"data of grid view Task should be")]
        public void ThenDataOfGridViewTaskShouldBe(Table table)
        {
            var expectedGridPendenzen = _testDataManager.CreateSetWithLookup<GridPendenzen>(table).ToList();
            string xpath = "//div[@class='dx-datagrid-content']//td[contains(@aria-label,'Column {0}')]";

            var entityProperties = typeof(GridPendenzen).GetProperties();
            foreach (var property in entityProperties)
            {
                var elements = _driver.FindElements(By.XPath(string.Format(xpath, property.Name)));
            }
                
        }

        [AfterScenario]
        public void CleanupData()
        {
            _driver.Quit();
        }
    }
}
