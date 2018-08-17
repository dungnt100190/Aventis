using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Pendenzen
{
    [Binding]
    public class PendenzenSteps
    {
        private IWebDriver _driver;

        [Given(@"User is on Login page")]
        public void GivenUserIsOnLoginPage()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://localhost:4300";
        }
        
        [When(@"user login as administrator")]
        public void WhenUserLoginAsAdministrator()
        {
            _driver.FindElement(By.Id("username")).SendKeys("new_admin");
            _driver.FindElement(By.Id("password")).SendKeys("123456");
            _driver.FindElement(By.Id("btnLogin")).Click();
        }
        
        [Then(@"redirect to page Pendenzen")]
        public void ThenRedirectToPagePendenzen()
        {
            System.Threading.Thread.Sleep(5000);
            Assert.That(_driver.Url.Equals("http://localhost:4300/pendenzen"));
        }
    }
}
