using Kiss4Web.Resource;
using Kiss4Web.Test.TestInfrastructure;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Pendenzen
{
    [Binding]
    public class EditPendenzenSteps
    {
        [BeforeScenario("EditPendenzen")]
        private void Setup()
        {
            TestDataManager.Setup();
        }

        [Given(@"User choose row (.*) on Grid Task")]
        public void GivenUserChooseRowOnGridTask(int p0)
        {
            try
            {
                TestDataManager.Click(string.Format(XPathPendenzen.GridTaskFields, "Fällig"), p0);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }
        
        [When(@"User click on button Bearbeiten")]
        [Given(@"User clicked on button Bearbeiten")]
        public void WhenUserClickOnButtonBearbeiten()
        {
            try
            {
                TestDataManager.Click(XPathPendenzen.ButtonEdit);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }
        
        [Then(@"These items are disabled: NavbarMenu, SearchArea, GridTask")]
        public void ThenTheseItemsAreDisabled()
        {
            try
            {
                TestDataManager.CheckControlContent("true", XPathPendenzen.NavbarMenu, "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", XPathPendenzen.SearchArea, "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", XPathPendenzen.GridTask, "ng-reflect-disabled");
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }
        
        [Then(@"The Detail area switches to edit mode of status in Bearbeitung")]
        public void ThenTheDetailAreaSwitchesToEditMode()
        {
            try
            {
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonCreate, "ng-reflect-visible");
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonEdit, "ng-reflect-visible");
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonSave, "ng-reflect-visible");
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonCancel, "ng-reflect-visible");
                TestDataManager.CheckControlStatus("//div[@id='app-content3-body']", isDisplayed: true);
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-status']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-pendenzTyp']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-betreff']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-beschreibung']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-Ersteller']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-empfanger']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-falltrager']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@ng-reflect-data-field='leistungsverantw']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-betrifftPerson']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-erfasst']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", "//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-fallig']//*[@_ngcontent-c10]", "ng-reflect-disabled");
                TestDataManager.CheckControlStatus("//div[@id='app-content3-body-lable']", isDisplayed: false);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"User choose (.*) in dropdown Leistung")]
        public void UserChooseOptionInDropdownLeistung(string p0)
        {
            try
            {
                TestDataManager.Click("//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-leistung']", sleepTime: 2);
                TestDataManager.Click(string.Format("//div[@class='dx-popup-content']//div[@role='option']//div[contains(text(),'{0}')]//parent::div", p0));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"User input (.*) into textbox Antwort")]
        public void UserInputIntoTextboxAntwort(string p0)
        {
            try
            {
                TestDataManager.Input("//div[@id='app-content3-body']//dxi-item[@id='app-content3-body-form-antwort']//textarea", p0);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"User click on button Speichern")]
        public void WhenUserClickOnButtonSpeichern()
        {
            try
            {
                TestDataManager.Click(XPathPendenzen.ButtonSave, sleepTime: 5);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"These items are enabled: NavbarMenu, SearchArea, GridTask")]
        public void ThenTheseItemsAreEnabledNavbarMenuSearchAreaGridTask()
        {
            try
            {
                TestDataManager.CheckControlContent("false", XPathPendenzen.NavbarMenu, "ng-reflect-disabled");
                TestDataManager.CheckControlContent("false", XPathPendenzen.SearchArea, "ng-reflect-disabled");
                TestDataManager.CheckControlContent("false", XPathPendenzen.GridTask, "ng-reflect-disabled");
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"The Detail area switches to view mode")]
        public void ThenTheDetailAreaSwitchesToViewMode()
        {
            try
            {
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonCreate, "ng-reflect-visible");
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonEdit, "ng-reflect-visible");
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonSave, "ng-reflect-visible");
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonCancel, "ng-reflect-visible");
                TestDataManager.CheckControlStatus("//div[@id='app-content3-body']", isDisplayed: false);
                TestDataManager.CheckControlStatus("//div[@id='app-content3-body-lable']", isDisplayed: true);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"content of Detail area should be")]
        public void ThenContentOfDetailAreaShouldBe(Table table)
        {
            Dictionary<string, string> xPaths = new Dictionary<string, string>();
            xPaths.Add(XPathPendenzen.TaskDetailLabelFields1, "value");
            xPaths.Add(XPathPendenzen.TaskDetailLabelFields2, null);
            xPaths.Add(XPathPendenzen.TaskDetailLabelFields3, null);

            Dictionary<string, string> screenMapping = new Dictionary<string, string>();
            screenMapping.Add("Status", "status");
            screenMapping.Add("Pendenz Typ", "pendenzTyp");
            screenMapping.Add("Betreff", "betreff");
            screenMapping.Add("Beschreibung", "beschreibung");
            screenMapping.Add("Empfänger", "empfanger");
            screenMapping.Add("Fallträger", "falltrager");
            screenMapping.Add("Leistung", "leistung");
            screenMapping.Add("Leistungsverantw.", "leistungsverantw");
            screenMapping.Add("betrifft Person", "betrifftPerson");
            screenMapping.Add("Antwort", "antwort");
            screenMapping.Add("Erfasst", "erfasst");
            screenMapping.Add("Fällig", "fallig");

            Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
            fieldMapping.Add("Fallträger", "BaPersonID");

            try
            {
                TestDataManager.CheckTableData(table, xPaths, screenMapping: screenMapping, refFieldMapping: fieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [AfterScenario("EditPendenzen")]
        private void Cleanup()
        {
            TestDataManager.Cleanup();
        }
    }
}
