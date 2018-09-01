using Kiss4Web.Resource;
using Kiss4Web.Test.DataAccess;
using Kiss4Web.Test.TestInfrastructure;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Kiss4Web.Test.Pendenzen
{
    [Binding]
    public class CreatePendenzenSteps
    {
        [BeforeScenario("CreatePendenzen")]
        private void Setup()
        {
            TestDataManager.Setup();
        }

        [Given(@"Click on button Neus Pendenz")]
        public void GivenClickOnButtonNeusPendenz()
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
        
        [When(@"Input as below")]
        public void WhenInputAsBelow(Table table)
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
        
        [When(@"click on button Abbrechen")]
        public void WhenClickOnButtonAbbrechen()
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
        public void WhenClickOnButtonJa()
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

        [Then(@"the record of the above inputted info is inserted into table XTask in database")]
        public void ThenTheRecordOfTheAboveInputtedInfoIsInsertedIntoTableXTaskInDatabase()
        {
            try
            {
                TestDataManager.CheckEntityExistsInDB<XTask>(TestDataManager.TempAddedEntities[TestDataManager.TempAddedEntities.Count - 1]);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"the record of the above inputted info is not inserted into table XTask in database")]
        public void ThenTheRecordOfTheAboveInputtedInfoIsNotInsertedIntoTableXTaskInDatabase()
        {
            try
            {
                TestDataManager.CheckEntityExistsInDB<XTask>(TestDataManager.TempAddedEntities[TestDataManager.TempAddedEntities.Count - 1], false);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [Then(@"count task in Meine Pendenzen/offene is (.*)")]
        public void ThenCountTaskInMeinePendenzenOffeneIs(string p0)
        {
            try
            {
                TestDataManager.CheckControlContent(p0, string.Format(XPathPendenzen.NavbarItems, "1_2"));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }
        
        [Then(@"count task in Erstellte Pendenzen/offene is (.*)")]
        public void ThenCountTaskInErstelltePendenzenOffeneIs(string p0)
        {
            try
            {
                TestDataManager.CheckControlContent(p0, string.Format(XPathPendenzen.NavbarItems, "2_2"));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }
        
        [Then(@"Display error message at top of page content with content is: (.*)")]
        public void ThenDisplayErrorMessageAtTopOfPageContentWithContentIs(string message)
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

        [AfterScenario("CreatePendenzen")]
        private void Cleanup()
        {
            TestDataManager.Cleanup();
        }
    }
}
