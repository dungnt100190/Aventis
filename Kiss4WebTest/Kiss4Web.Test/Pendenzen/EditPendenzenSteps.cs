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
        [When(@"User choose row (.*) on Grid Task")]
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
        
        [Then(@"Pendenzen Detail area switches to edit mode of status in Bearbeitung")]
        public void ThenTheDetailAreaSwitchesToEditMode()
        {
            try
            {
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonCreate, "ng-reflect-visible");
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonEdit, "ng-reflect-visible");
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonSave, "ng-reflect-visible");
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonCancel, "ng-reflect-visible");
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaEdit, isDisplayed: true);
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "status"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "pendenzTyp"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "betreff"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "beschreibung"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "Ersteller"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "empfanger"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "falltrager"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields2, "leistungsverantw"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "betrifftPerson"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "erfasst"), "ng-reflect-disabled");
                TestDataManager.CheckControlContent("true", string.Format(XPathPendenzen.TaskDetailFields1, "fallig"), "ng-reflect-disabled");
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaView, isDisplayed: false);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"User choose (.*) in dropdown Leistung")]
        public void UserChooseOptionInDropdownLeistung(string option)
        {
            try
            {
                TestDataManager.InputDropdown(string.Format(XPathPendenzen.TaskDetailFields1, "leistung"), option);
                //TestDataManager.Click(string.Format(XPathPendenzen.TaskDetailFields1, "leistung"), waitingTime: 5);
                //TestDataManager.Click(string.Format("//div[@class='dx-popup-content']//div[@role='option']//div[contains(text(),'{0}')]", option));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"User input (.*) into textarea Antwort")]
        public void UserInputIntoTextareaAntwort(string text)
        {
            try
            {
                TestDataManager.Input(string.Format(XPathPendenzen.TaskDetailFields1 + XPath0Common.Textarea, "antwort"), text);
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
                TestDataManager.Click(XPathPendenzen.ButtonSave, waitingTime: 5);
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

        [Then(@"Pendenzen Detail area switches to view mode")]
        public void ThenTheDetailAreaSwitchesToViewMode()
        {
            try
            {
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonCreate, "ng-reflect-visible");
                TestDataManager.CheckControlContent("true", XPathPendenzen.ButtonEdit, "ng-reflect-visible");
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonSave, "ng-reflect-visible");
                TestDataManager.CheckControlContent("false", XPathPendenzen.ButtonCancel, "ng-reflect-visible");
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaEdit, isDisplayed: false);
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaView, isDisplayed: true);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"Content of Pendenzen Detail area should be")]
        public void ThenContentOfDetailAreaShouldBe(Table table)
        {
            Dictionary<string, string> xPaths = new Dictionary<string, string>();
            xPaths.Add(XPathPendenzen.TaskDetailLabelFields3, "value");
            xPaths.Add(XPathPendenzen.TaskDetailLabelFields2, null);
            xPaths.Add(XPathPendenzen.TaskDetailLabelFields1, null);

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
                TestDataManager.CheckTableData(table, xPaths, screenMapping: screenMapping, idFieldMapping: fieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"User clear data in textbox Betreff of Pendenzen Detail area")]
        public void WhenUserClearDataInTextboxBetreff()
        {
            try
            {
                TestDataManager.Clear(string.Format(XPathPendenzen.TaskDetailFields1 + XPath0Common.Textbox, "betreff"));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"Display error message (.*) at below of textbox Betreff")]
        public void ThenDisplayErrorMessageBetreff(string message)
        {
            try
            {
                TestDataManager.Click(string.Format(XPathPendenzen.TaskDetailFields1, "betreff"), waitingTime: 2);
                TestDataManager.CheckControlContent(message, string.Format(XPathPendenzen.TaskDetailFields1 + XPath0DevExtreme.AutogenElement, "betreff"), valueAttribute: "textContent");
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
