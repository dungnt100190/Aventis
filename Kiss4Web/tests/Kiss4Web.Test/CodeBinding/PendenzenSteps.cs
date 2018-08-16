using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Kiss4Web.Test.CodeBinding
{
    [Binding]
    public class PendenzenSteps
    {
        IWebDriver driver;

        [When(@"Call LoadNavBarItems")]
        public void WhenCallLoadNavBarItems()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:4300/pendenzen";
        }
        
        [Then(@"the NavBarItems should be")]
        public void ThenTheNavBarItemsShouldBe(Table table)
        {
            //driver.Quit();
        }
    }
}
