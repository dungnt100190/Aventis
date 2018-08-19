// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlow.GeneratedTests.Pendenzen
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class EditPendenzenFeature : Xunit.IClassFixture<EditPendenzenFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "EditPendenzen.feature"
#line hidden
        
        public EditPendenzenFeature(EditPendenzenFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EditPendenzen", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 2
 #line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserID",
                        "PermissionGroupID",
                        "GrantPermGroupID",
                        "LogonName",
                        "PasswordHash",
                        "FirstName",
                        "LastName",
                        "ShortName",
                        "IsLocked",
                        "IsUserAdmin",
                        "IsUserBIAGAdmin",
                        "IsMandatsTraeger",
                        "GenderCode",
                        "KeinBDEExport",
                        "MigUserFix",
                        "VerID"});
            table13.AddRow(new string[] {
                        "USR1",
                        "9",
                        "9",
                        "test_admin_1",
                        "kR9Y+JkxEwo=",
                        "CMC",
                        "Global",
                        "cg",
                        "0",
                        "1",
                        "1",
                        "0",
                        "1",
                        "0",
                        "0",
                        "257000"});
            table13.AddRow(new string[] {
                        "USR2",
                        "9",
                        "9",
                        "test_admin_2",
                        "kR9Y+JkxEwo=",
                        "CMC",
                        "Soft",
                        "cs",
                        "0",
                        "1",
                        "1",
                        "0",
                        "1",
                        "0",
                        "0",
                        "257000"});
#line 3
 testRunner.Given("these UserAdmin for EditPendenzen feature", ((string)(null)), table13, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "XTaskID",
                        "BaPersonID",
                        "TaskStatusCode",
                        "TaskTypeCode",
                        "Subject",
                        "SenderID",
                        "ReceiverID",
                        "FaFallID",
                        "FaLeistungID",
                        "CreateDate",
                        "ExpirationDate",
                        "TaskDescription",
                        "ResponseText",
                        "TaskReceiverCode"});
            table14.AddRow(new string[] {
                        "TSK1",
                        "64807",
                        "1",
                        "4",
                        "Task 20180817-01",
                        "USR2",
                        "USR1",
                        "64807",
                        "98766",
                        "2018-01-10 00:00:00.000",
                        "2020-01-10 00:00:00.000",
                        "Task 20180817-1 autotest",
                        "Task 20180817-1 text",
                        "1"});
#line 8
 testRunner.And("these Tasks for EditPendenzen feature", ((string)(null)), table14, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Update Pendenzen")]
        [Xunit.TraitAttribute("FeatureTitle", "EditPendenzen")]
        [Xunit.TraitAttribute("Description", "Update Pendenzen")]
        [Xunit.TraitAttribute("Category", "servicetest")]
        public virtual void UpdatePendenzen()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Pendenzen", new string[] {
                        "servicetest"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 2
 this.FeatureBackground();
#line 14
 testRunner.Given("EditPendenzen client has LogonName is test_admin_1, PasswordHash is 123456", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "status",
                        "pendenzTyp",
                        "betreff",
                        "beschreibung",
                        "empfangerId",
                        "falltrager",
                        "leistung",
                        "PersonId",
                        "antwort",
                        "fallig"});
            table15.AddRow(new string[] {
                        "1",
                        "4",
                        "Update 20180817-01",
                        "Update 20180817-1 autotest",
                        "1234",
                        "65134",
                        "98952",
                        "65088",
                        "Update 20180817-1 text",
                        "2019-01-10 00:00:00.000"});
#line 15
 testRunner.And("this new data for Pendenzen TSK1, [empfangerId] is USR2", ((string)(null)), table15, "And ");
#line 19
 testRunner.When("call CreateUpdateTask for EditPendenzen feature", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("the call UpdateTask should be return true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "status",
                        "pendenzTyp",
                        "TaskTypeName",
                        "betreff",
                        "beschreibung",
                        "Ersteller",
                        "empfangerName",
                        "falltrager",
                        "FalltragerName",
                        "leistung",
                        "LeistungModul",
                        "LeistungsverantName",
                        "PersonId",
                        "BetrifftPersonName",
                        "antwort",
                        "fallig"});
            table16.AddRow(new string[] {
                        "1",
                        "4",
                        "Fristablauf",
                        "Update 20180817-01",
                        "Update 20180817-1 autotest",
                        "test_admin_2 - Soft, CMC",
                        "test_admin_2 - Soft, CMC",
                        "65134",
                        "Meier, Hans (65134)",
                        "98952",
                        "F - Fallführung (21.04.2010 -)",
                        "afuchs - Fuchs, Andreas (Sozialdienst)",
                        "65088",
                        "Brunner, Renate",
                        "Update 20180817-1 text",
                        "10.01.2019 00:00:00"});
#line 21
 testRunner.And("the updated Pendenzen should be", ((string)(null)), table16, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                EditPendenzenFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                EditPendenzenFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
