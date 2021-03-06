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
    public partial class GetPendenzenDetailFeature : Xunit.IClassFixture<GetPendenzenDetailFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GetPendenzenDetail.feature"
#line hidden
        
        public GetPendenzenDetailFeature(GetPendenzenDetailFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetPendenzenDetail", "\tGet detail data of a Pendenzen ", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 3
 #line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
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
            table11.AddRow(new string[] {
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
            table11.AddRow(new string[] {
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
                        "258000"});
#line 4
 testRunner.Given("these XUser", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "BaPersonID",
                        "Name",
                        "Vorname"});
            table12.AddRow(new string[] {
                        "BPS1",
                        "Person-1",
                        "NT"});
            table12.AddRow(new string[] {
                        "BPS2",
                        "Person 2",
                        "NULL"});
#line 9
 testRunner.And("these BaPerson", ((string)(null)), table12, "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "FaLeistungID",
                        "BaPersonID",
                        "FaFallID",
                        "ModulID",
                        "UserID",
                        "IkHatUnterstuetzung",
                        "IkIstRentenbezueger",
                        "IkSchuldnerMahnen",
                        "WiederholteSpezifischeErmittlungEAF",
                        "DatumVon"});
            table13.AddRow(new string[] {
                        "LEI1",
                        "BPS1",
                        "BPS1",
                        "3",
                        "USR1",
                        "0",
                        "0",
                        "1",
                        "0",
                        "2018-01-10 00:00:00.000"});
            table13.AddRow(new string[] {
                        "LEI2",
                        "BPS1",
                        "BPS2",
                        "21",
                        "USR1",
                        "0",
                        "0",
                        "1",
                        "0",
                        "2018-02-10 00:00:00.000"});
            table13.AddRow(new string[] {
                        "LEI3",
                        "BPS2",
                        "BPS1",
                        "21",
                        "USR2",
                        "0",
                        "0",
                        "1",
                        "0",
                        "2018-03-10 00:00:00.000"});
            table13.AddRow(new string[] {
                        "LEI4",
                        "BPS2",
                        "BPS2",
                        "3",
                        "USR2",
                        "0",
                        "0",
                        "1",
                        "0",
                        "2018-04-10 00:00:00.000"});
#line 19
 testRunner.And("these FaLeistung", ((string)(null)), table13, "And ");
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
                        "StartDate",
                        "DoneDate",
                        "TaskDescription",
                        "ResponseText",
                        "TaskReceiverCode",
                        "TaskSenderCode"});
            table14.AddRow(new string[] {
                        "TSK1",
                        "BPS1",
                        "1",
                        "4",
                        "Task 20180817-01",
                        "USR2",
                        "USR1",
                        "BPS1",
                        "LEI1",
                        "2018-01-10 00:00:00.000",
                        "2020-01-10 00:00:00.000",
                        "",
                        "",
                        "Task 20180817-1 autotest",
                        "Task 20180817-1 text",
                        "1",
                        ""});
            table14.AddRow(new string[] {
                        "TSK2",
                        "BPS2",
                        "1",
                        "4",
                        "Task 20180817-02",
                        "USR2",
                        "USR1",
                        "BPS2",
                        "LEI2",
                        "2018-01-10 00:00:00.000",
                        "2018-05-10 00:00:00.000",
                        "",
                        "",
                        "Task 20180817-2 autotest",
                        "Task 20180817-2 text",
                        "1",
                        ""});
            table14.AddRow(new string[] {
                        "TSK3",
                        "BPS1",
                        "2",
                        "6",
                        "Task 20180817-03",
                        "USR2",
                        "USR1",
                        "BPS2",
                        "LEI4",
                        "2018-01-10 00:00:00.000",
                        "2018-10-10 00:00:00.000",
                        "2018-04-10 00:00:00.000",
                        "",
                        "Task 20180817-3 autotest",
                        "Task 20180817-3 text",
                        "1",
                        ""});
#line 26
 testRunner.And("these XTask", ((string)(null)), table14, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="01 Get Pendenzen detail")]
        [Xunit.TraitAttribute("FeatureTitle", "GetPendenzenDetail")]
        [Xunit.TraitAttribute("Description", "01 Get Pendenzen detail")]
        [Xunit.TraitAttribute("Category", "servicetest")]
        public virtual void _01GetPendenzenDetail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 Get Pendenzen detail", new string[] {
                        "servicetest"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 3
 this.FeatureBackground();
#line 34
 testRunner.Given("init client with username is \'test_admin_1\', password is \'123456\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.When("call API GetPendenzenDetail with taskId is \'TSK1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("the call is successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "status",
                        "pendenzTyp",
                        "TaskTypeName",
                        "betreff",
                        "beschreibung",
                        "Ersteller",
                        "empfangerName",
                        "LeistungModul",
                        "LeistungsverantName",
                        "BetrifftPersonName",
                        "antwort",
                        "erfasst",
                        "fallig",
                        "BearbeitungName",
                        "ErledigtName"});
            table15.AddRow(new string[] {
                        "1",
                        "4",
                        "Fristablauf",
                        "Task 20180817-01",
                        "Task 20180817-1 autotest",
                        "test_admin_2 - Soft, CMC",
                        "test_admin_1 - Global, CMC",
                        "S - Sozialhilfe (10.01.2018 -)",
                        "test_admin_1 - Global, CMC",
                        "Person-1, NT",
                        "Task 20180817-1 text",
                        "NULL",
                        "10.01.2020 00:00:00",
                        "NULL",
                        "NULL"});
#line 37
 testRunner.And("the return data of API GetPendenzenDetail should be", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetPendenzenDetailFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetPendenzenDetailFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
