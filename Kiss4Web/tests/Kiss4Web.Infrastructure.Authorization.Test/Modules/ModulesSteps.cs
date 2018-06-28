using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Modularity;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Shouldly;
using TechTalk.SpecFlow;

namespace Kiss4Web.Infrastructure.Authorization.Test.Modules
{
    [Binding]
    public class ModulesSteps : IntegrationTest
    {
        private ServiceResult<IEnumerable<KissModul>> _result;

        public ModulesSteps(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Then(@"the received modules should be")]
        public void ThenTheReceivedModules(Table table)
        {
            _result.ShouldBeOk();
            var expectedModules = table.Rows.Select(row => Enum.Parse<KissModul>(row[0])).ToList();
            _result.Result.ShouldBe(expectedModules);
        }

        [When(@"I get the licensed modules")]
        public async Task WhenIGetTheLicensedModules()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            _result = await client.GetAsJsonAsync<IEnumerable<KissModul>>(Url.GetModules);
        }
    }
}