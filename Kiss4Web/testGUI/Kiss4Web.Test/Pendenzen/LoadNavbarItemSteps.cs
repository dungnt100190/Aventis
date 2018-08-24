using Kiss4Web.Test.DataAccess;
using Kiss4Web.Test.Model.Pendenzen;
using Kiss4Web.Test.TestInfrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Pendenzen
{
    [Binding]
    public class LoadNavbarItemSteps
    {
        private TestDataManager _testDataManager;
        private IWebDriver _driver;
        private string _urlLogin;
        private string _urlPendenzen;

        [BeforeScenario]
        public void Setup()
        {
            _testDataManager = new TestDataManager();
        }

        [Given(@"Url of Login page is (.*)")]
        public void GivenUrlOfLoginPageIs(string p0)
        {
            _urlLogin = p0;
        }

        [Given(@"Url of Pendenzen page is (.*)")]
        public void GivenUrlOfPendenzenPageIs(string p0)
        {
            _urlPendenzen = p0;
        }

        [Given(@"these UserAdmin")]
        public void GivenTheseUserAdmin(Table table)
        {
            _testDataManager.Insert<XUser>(table);
        }

        [Given(@"these BaPerson")]
        public void GivenTheseBaPerson(Table table)
        {
            try
            {
                _testDataManager.Insert<BaPerson>(table);
            }
            catch (Exception)
            {
                CleanupData();
                throw;
            }
        }

        //[Given(@"these XModul")]
        //public void GivenTheseXModul(Table table)
        //{
        //    try
        //    {
        //        _testDataManager.Insert<XModul>(table);
        //    }
        //    catch (Exception)
        //    {
        //        CleanupData();
        //        throw;
        //    }
        //}

        //[Given(@"these FaFall")]
        //public void GivenTheseFaFall(Table table)
        //{
        //    Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
        //    fieldMapping.Add("FaFallID", "BaPersonID");
        //    try
        //    {
        //        _testDataManager.Insert<FaFall>(table, fieldMapping, true);
        //    }
        //    catch (Exception)
        //    {
        //        CleanupData();
        //        throw;
        //    }
        //}

        [Given(@"these FaLeistung")]
        public void GivenTheseFaLeistung(Table table)
        {
            Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
            fieldMapping.Add("FaFallID", "BaPersonID");
            try
            {
                _testDataManager.Insert<FaLeistung>(table, fieldMapping);
            }
            catch (Exception)
            {
                CleanupData();
                throw;
            }
        }

        [Given(@"these Tasks")]
        public void GivenTheseTasks(Table table)
        {
            Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
            fieldMapping.Add("SenderID", "UserID");
            fieldMapping.Add("ReceiverID", "UserID");
            fieldMapping.Add("FaFallID", "BaPersonID");
            try
            {
                _testDataManager.Insert<XTask>(table, fieldMapping);
            }
            catch (Exception)
            {
                CleanupData();
                throw;
            }
        }

        [When(@"User login with username is (.*), password is (.*)")]
        public void WhenUserLoginWithUsernameIsPasswordIs(string p0, string p1)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            _driver = new ChromeDriver(options);
            _driver.Url = _urlLogin;
            try
            {
                _driver.FindElement(By.XPath("//*[@class='input-container']//input[@name='username']")).SendKeys(p0);
                _driver.FindElement(By.XPath("//*[@class='input-container']//input[@name='password']")).SendKeys(p1);
                _driver.FindElement(By.XPath("//*[@class='button-container']//button[@type='submit']")).Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception)
            {
                CleanupData();
                throw;
            }
        }

        [Then(@"Page Pendenzen is redirected to")]
        public void ThenPagePendenzenIsRedirectedTo()
        {
            Assert.That(_driver.Url.Equals(_urlPendenzen));
        }

        [Then(@"the count of navbar items should be")]
        public void ThenTheCountOfNavbarItemsShouldBe(Table table)
        {
            try
            {
                string xpath = "//li[@data-item-id='{0}']//span";
                var navbarItemResult = _testDataManager.CreateSetWithLookup<NavbarItem>(table).First();
                var entityProperties = typeof(NavbarItem).GetProperties();
                foreach (var property in entityProperties)
                {
                    object[] attrs = property.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        DisplayAttribute displayAttr = attr as DisplayAttribute;
                        if (displayAttr != null)
                        {
                            string elementText = _driver.FindElement(By.XPath(string.Format(xpath, displayAttr.Name))).Text;
                            string itemValue = elementText.Remove(0, elementText.IndexOf('(') + 1).Remove(1);
                            string expectedValue = property.GetValue(navbarItemResult).ToString();
                            Assert.That(itemValue.Equals(expectedValue));
                        }
                    }
                }
            }
            catch (Exception)
            {
                CleanupData();
                throw;
            }
        }

        [AfterScenario]
        public void CleanupData()
        {
            _driver.Quit();
            _testDataManager.Cleanup<XTask>();
            _testDataManager.Cleanup<FaLeistung>();
            //_testDataManager.Cleanup<FaFall>();
            //_testDataManager.Cleanup<XModul>();
            _testDataManager.Cleanup<BaPerson>();
            _testDataManager.Cleanup<XUser>();
        }
    }
}
