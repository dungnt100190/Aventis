using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.TestServer;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Kiss4Web.Infrastructure.Reporting.Test
{
    public class GenerateXtraReportTest : IntegrationTest
    {
        private const string queryName = "ShKontoauszug";

        public GenerateXtraReportTest(TestServerFixture integrationTestEnvironment) : base(integrationTestEnvironment)
        {
        }

        [Fact]
        public async Task GenerateXtraReportShKontoauszug()
        {
            var client = await IntegrationTestEnvironment.GetClient(TestUser.Sozialarbeiter);
            var contextValues = new[] { new ContextValue { Name = "BaPersonID", Value = "64820" }
                , new ContextValue{Name="Person", Value = "2323"}
                , new ContextValue{Name="Zeitraum", Value = 1}
                , new ContextValue{Name="LaList", Value = "Testing"}
                , new ContextValue{Name="DatumVon", Value = DateTime.UtcNow.AddDays(-100)}
                , new ContextValue{Name="DatumBis", Value = DateTime.UtcNow}
                , new ContextValue{Name="Verdichtet", Value = true}
                , new ContextValue{Name="BetraegeAnpassen", Value = true}
                , new ContextValue{Name="FaLeistungID", Value = 54654}
            };
            var response = await client.PostAsJsonAsync<IEnumerable<ContextValue>, IActionResult>("api/reports/print", contextValues, new { queryName });
            response.ShouldBeNull();
            //var successResult = response as ServiceResult<IActionResult>;
            //successResult.ShouldBeOk();
        }
    }
}
