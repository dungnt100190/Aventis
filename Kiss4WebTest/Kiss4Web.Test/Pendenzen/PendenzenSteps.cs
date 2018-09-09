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

        [When(@"on grid Pendenzen: click button search in field '(.*)', choose option '(.*)' and input '(.*)'")]
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

        [When(@"choose '(.*)' in dropdown Leistung")]
        public void ChooseOptionInDropdownLeistung(string option)
        {
            try
            {
                TestDataManager.InputDropdown(string.Format(XPathPendenzen.TaskDetailFields1, "leistung"), option);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"input '(.*)' into textarea Antwort")]
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

        [When(@"choose '(.*)' in datebox Bearbeitung from")]
        public void WhenChooseInDateboxBearbeitungFrom(string option)
        {
            try
            {
                TestDataManager.InputDatebox(string.Format(XPathPendenzen.SearchFields2, "processing-box-item1"), option);
                TestDataManager.Click(XPathPendenzen.PageHeaderLeft, waitingTime: 2);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"choose '(.*)' in datebox Bearbeitung to")]
        public void WhenChooseInDateboxBearbeitungTo(string option)
        {
            try
            {
                TestDataManager.InputDatebox(string.Format(XPathPendenzen.SearchFields2, "processing-box-item3"), option);
                TestDataManager.Click(XPathPendenzen.PageHeaderLeft, waitingTime: 2);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"choose '(.*)' in dropdown Ersteller")]
        public void WhenChooseInDropdownErsteller(string option)
        {
            try
            {
                TestDataManager.InputGridDropdown(string.Format(XPathPendenzen.SearchFields1, "creator"), option);
                TestDataManager.Click(XPathPendenzen.PageHeaderLeft, waitingTime: 2);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [When(@"input into Pendenzen search area as below")]
        public void InputIntoSearchAreaAsBelow(Table table)
        {
            try
            {
                string[] xPaths = new string[]
                {
                    XPathPendenzen.SearchFields3,
                    XPathPendenzen.SearchFields2,
                    XPathPendenzen.SearchFields1
                };

                Dictionary<string, InputElementType> elementType = new Dictionary<string, InputElementType>();
                elementType.Add("Status", InputElementType.Dropdown);
                //elementType.Add("Betreff", InputElementType.Textbox);
                elementType.Add("Bearbeitung from", InputElementType.Datebox);
                elementType.Add("Bearbeitung to", InputElementType.Datebox);
                elementType.Add("Ersteller", InputElementType.GridDropdown);

                Dictionary<string, string> screenMapping = new Dictionary<string, string>();
                screenMapping.Add("Status", "status");
                screenMapping.Add("Betreff", "betreff");
                screenMapping.Add("Bearbeitung from", "processing-box-item1");
                screenMapping.Add("Bearbeitung to", "processing-box-item3");
                screenMapping.Add("Ersteller", "creator");

                TestDataManager.InputTableData(xPaths, table, elementType, screenMapping);
                TestDataManager.Click(XPathPendenzen.PageHeaderLeft, waitingTime: 2);
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

                TestDataManager.AddToTempEntities<XTask>(table, fieldMapping: fieldMapping);
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
                TestDataManager.CheckControlContent(XPathPendenzen.NavbarMenu, "true", "ng-reflect-disabled");
                TestDataManager.CheckControlContent(XPathPendenzen.SearchArea, "true", "ng-reflect-disabled");
                TestDataManager.CheckControlContent(XPathPendenzen.GridTask, "true", "ng-reflect-disabled");
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
                TestDataManager.CheckControlContent(XPathPendenzen.NavbarMenu, "false", "ng-reflect-disabled");
                TestDataManager.CheckControlContent(XPathPendenzen.SearchArea, "false", "ng-reflect-disabled");
                TestDataManager.CheckControlContent(XPathPendenzen.GridTask, "false", "ng-reflect-disabled");
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"Pendenzen detail area switches to edit mode of status in Bearbeitung")]
        public void DetailAreaSwitchesToEditModeOfStatusInBearbeitung(Table statusTable)
        {
            try
            {
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonCreate, "false", "ng-reflect-visible");
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonEdit, "false", "ng-reflect-visible");
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonSave, "true", "ng-reflect-visible");
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonCancel, "true", "ng-reflect-visible");
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaEdit, isDisplayed: true);
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaView, isDisplayed: false);

                Dictionary<string, string> xPaths = new Dictionary<string, string>();
                xPaths.Add(XPathPendenzen.TaskDetailFields2, "ng-reflect-disabled");
                xPaths.Add(XPathPendenzen.TaskDetailFields1, "ng-reflect-disabled");

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

                TestDataManager.CheckTableData(xPaths, statusTable, screenMapping: screenMapping);
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
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonCreate, "true", "ng-reflect-visible");
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonEdit, "true", "ng-reflect-visible");
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonSave, "false", "ng-reflect-visible");
                TestDataManager.CheckControlContent(XPathPendenzen.ButtonCancel, "false", "ng-reflect-visible");
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaEdit, isDisplayed: false);
                TestDataManager.CheckControlStatus(XPathPendenzen.TaskDetailAreaView, isDisplayed: true);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"on tree LeftNavMenu: value of Meine Pendenzen/offene is '(.*)'")]
        public void OnTreeLeftNavMenuValueOfMeinePendenzenOffeneIs(string value)
        {
            try
            {
                TestDataManager.CheckControlContent(string.Format(XPathPendenzen.NavbarItems, "1_2"), value);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"on tree LeftNavMenu: value of Erstellte Pendenzen/offene is '(.*)'")]
        public void OnTreeLeftNavMenuValueOfErstelltePendenzenOffeneIs(string value)
        {
            try
            {
                TestDataManager.CheckControlContent(string.Format(XPathPendenzen.NavbarItems, "2_2"), value);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"content of tree LeftNavMenu should be")]
        public void ContentOfTreeLeftNavMenuShouldBe(Table table)
        {
            Dictionary<string, string> xPaths = new Dictionary<string, string>();
            xPaths.Add(XPathPendenzen.NavbarItems, null);

            Dictionary<string, string> screenMapping = new Dictionary<string, string>();
            screenMapping.Add("Meine Pendenzen/fällige", "1_1");
            screenMapping.Add("Meine Pendenzen/offene", "1_2");
            screenMapping.Add("Meine Pendenzen/in Bearbeitung", "1_3");
            screenMapping.Add("Meine Pendenzen/selber erstellte", "1_4");
            screenMapping.Add("Meine Pendenzen/erhaltene", "1_5");
            screenMapping.Add("Meine Pendenzen/zu visierende", "1_6");
            screenMapping.Add("Erstellte Pendenzen/fällige", "2_1");
            screenMapping.Add("Erstellte Pendenzen/offene", "2_2");
            screenMapping.Add("Erstellte Pendenzen/allgemeine", "2_3");
            screenMapping.Add("Erstellte Pendenzen/zu visierende", "2_4");
            try
            {
                TestDataManager.CheckTableData(xPaths, table, screenMapping: screenMapping);
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
                TestDataManager.CheckTableData(xPaths, table, idFieldMapping: idFieldMapping);
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
                TestDataManager.CheckTableData(xPaths, table, screenMapping: screenMapping, idFieldMapping: fieldMapping);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"display error message at below of textbox Betreff with content is: '(.*)'")]
        public void DisplayErrorMessageAtElementBetreff(string message)
        {
            try
            {
                TestDataManager.Click(string.Format(XPathPendenzen.TaskDetailFields1, "betreff"), waitingTime: 2);
                TestDataManager.CheckControlContent(string.Format(XPathPendenzen.TaskDetailFields1 + XPath0DevExtreme.AutogenElement, "betreff"), message, valueAttribute: "textContent");
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"display error message at top of page content with content is: '(.*)'")]
        public void DisplayErrorMessageAtTopOfPageContentWithContentIs(string message)
        {
            try
            {
                TestDataManager.CheckControlContent(XPathPendenzen.TopContentValidateMessage, message, index: 1);
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
