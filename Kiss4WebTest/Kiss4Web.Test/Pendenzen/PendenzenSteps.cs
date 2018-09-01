using Kiss4Web.Resource;
using Kiss4Web.Test.DataAccess;
using Kiss4Web.Test.TestInfrastructure;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Pendenzen
{
    [Binding]
    public class PendenzenSteps
    {
        [BeforeScenario()]
        private void Setup()
        {
            TestDataManager.Setup();
        }

        [Given(@"go to page Pendenzen")]
        public void GoToPagePendenzen()
        {
            try
            {
                TestDataManager.CheckUrl(Urls.UrlPendenzen);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"on grid Pendenzen: click button search in (.*) field, choose option (.*) and input (.*)")]
        public void FilterOnGridTask(string field, string filterOption, string filterValue)
        {
            try
            {
                TestDataManager.InputDropdownGridFilter(string.Format(XPathPendenzen.GridTaskFieldsHeader, field), filterOption);
                TestDataManager.Input(string.Format(XPathPendenzen.GridTaskFieldsHeader + XPath0Common.Textbox, field), filterValue);
                TestDataManager.Click(XPathPendenzen.GridTask, waitingTime: 2);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Given(@"choose row (.*) on grid Pendenzen")]
        [When(@"choose row (.*) on grid Pendenzen")]
        public void ChooseRowOnGridTask(int p0)
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

        [Given(@"click on button Neus Pendenz")]
        public void ClickOnButtonNeusPendenz()
        {
            try
            {
                TestDataManager.Click(XPathPendenzen.ButtonCreate);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Given(@"click on button Bearbeiten")]
        [When(@"click on button Bearbeiten")]
        public void ClickOnButtonBearbeiten()
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

        [When(@"click on button Speichern")]
        public void ClickOnButtonSpeichern()
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

        [When(@"click on button Abbrechen")]
        public void ClickOnButtonAbbrechen()
        {
            try
            {
                TestDataManager.Click(XPathPendenzen.ButtonCancel);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"click on button Ja")]
        public void ClickOnButtonJa()
        {
            try
            {
                TestDataManager.Click(XPath0DevExtreme.AutogenElement + XPathPendenzen.ButtonYes);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"choose (.*) in dropdown Leistung")]
        public void ChooseOptionInDropdownLeistung(string option)
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

        [When(@"input (.*) into textarea Antwort")]
        public void InputIntoTextareaAntwort(string text)
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

        [When(@"clear data in textbox Betreff")]
        public void ClearDataInTextboxBetreff()
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

        [When(@"input into Pendenzen detail area as below")]
        public void InputIntoDetailAreaAsBelow(Table table)
        {
            try
            {
                Dictionary<string, InputElementType> elementType = new Dictionary<string, InputElementType>();
                elementType.Add("Pendenz Typ", InputElementType.Dropdown);
                //elementType.Add("Betreff", InputElementType.Textbox);
                elementType.Add("Beschreibung", InputElementType.Textarea);
                elementType.Add("Empfänger", InputElementType.GridDropdown);
                elementType.Add("Fällig", InputElementType.Datebox);

                Dictionary<string, string> screenMapping = new Dictionary<string, string>();
                screenMapping.Add("Pendenz Typ", "pendenzTyp");
                screenMapping.Add("Betreff", "betreff");
                screenMapping.Add("Beschreibung", "beschreibung");
                screenMapping.Add("Empfänger", "empfanger");
                screenMapping.Add("Fällig", "fallig");

                TestDataManager.InputTableData(new string[] { XPathPendenzen.TaskDetailFields1 }, table, elementType, screenMapping);

                Dictionary<string, string> fieldMapping = new Dictionary<string, string>();
                fieldMapping.Add("Betreff", "Subject");
                fieldMapping.Add("Beschreibung", "TaskDescription");
                fieldMapping.Add("Fällig", "ExpirationDate");
                TestDataManager.TempAddedEntities.AddRange(TestDataManager.CreateSetWithLookup<XTask>(table, fieldMapping: fieldMapping));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"these items are disabled: LeftNavMenu, SearchArea, GridTask")]
        public void TheseItemsAreDisabled()
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

        [Then(@"these items are enabled: LeftNavMenu, SearchArea, GridTask")]
        public void TheseItemsAreEnabled()
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

        [Then(@"Pendenzen detail area switches to edit mode of status in Bearbeitung")]
        public void DetailAreaSwitchesToEditModeOfStatusInBearbeitung()
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

        [Then(@"Pendenzen detail area switches to view mode")]
        public void DetailAreaSwitchesToViewMode()
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

        [Then(@"on tree LeftNavMenu: value of Meine Pendenzen/offene is (.*)")]
        public void OnTreeLeftNavMenuValueOfMeinePendenzenOffeneIs(string value)
        {
            try
            {
                TestDataManager.CheckControlContent(value, string.Format(XPathPendenzen.NavbarItems, "1_2"));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"on tree LeftNavMenu: value of Erstellte Pendenzen/offene is (.*)")]
        public void OnTreeLeftNavMenuValueOfErstelltePendenzenOffeneIs(string value)
        {
            try
            {
                TestDataManager.CheckControlContent(value, string.Format(XPathPendenzen.NavbarItems, "2_2"));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"data of tree LeftNavMenu should be")]
        public void DataOfTreeLeftNavMenuShouldBe(Table table)
        {
            Dictionary<string, string> xPaths = new Dictionary<string, string>();
            xPaths.Add(XPathPendenzen.NavbarItems, null);

            Dictionary<string, string> screenMapping = new Dictionary<string, string>();
            screenMapping.Add("Meine fällige", "1_1");
            screenMapping.Add("Meine offene", "1_2");
            screenMapping.Add("Meine in Bearbeitung", "1_3");
            screenMapping.Add("Meine selber erstellte", "1_4");
            screenMapping.Add("Meine erhaltene", "1_5");
            screenMapping.Add("Meine zu visierende", "1_6");
            screenMapping.Add("Erstellte fällige", "2_1");
            screenMapping.Add("Erstellte offene", "2_2");
            screenMapping.Add("Erstellte allgemeine", "2_3");
            screenMapping.Add("Erstellte zu visierende", "2_4");
            try
            {
                TestDataManager.CheckTableData(table, xPaths, screenMapping: screenMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"data of grid Pendenzen should be")]
        public void DataOfGridTaskShouldBe(Table table)
        {
            Dictionary<string, string> xPaths = new Dictionary<string, string>();
            xPaths.Add(XPathPendenzen.GridTaskFields, null);

            Dictionary<string, string> idFieldMapping = new Dictionary<string, string>();
            idFieldMapping.Add("Fallträger", "BaPersonID");
            idFieldMapping.Add("Fallnummer", "BaPersonID");

            try
            {
                TestDataManager.CheckTableData(table, xPaths, idFieldMapping: idFieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"grid Pendenzen does not have data")]
        public void GridTaskDoesNotHaveData()
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

        [Then(@"content of Pendenzen detail area should be")]
        public void ContentOfDetailAreaShouldBe(Table table)
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

        [Then(@"display error message at below of textbox Betreff with content is: (.*)")]
        public void DisplayErrorMessageAtElementBetreff(string message)
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

        [Then(@"display error message at top of page content with content is: (.*)")]
        public void DisplayErrorMessageAtTopOfPageContentWithContentIs(string message)
        {
            try
            {
                TestDataManager.CheckControlContent(message, XPathPendenzen.TopContentValidateMessage, index: 1);
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
