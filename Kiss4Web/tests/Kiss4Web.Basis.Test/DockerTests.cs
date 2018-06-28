using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure.Client;
using Shouldly;

namespace Kiss4Web.Basis.Test
{
    /// <summary>
    /// This is experimental. idea: run not only db but also application server in a docker container and test against it
    /// goal: test environment is more similar to production environment
    /// </summary>
    public class DockerTests
    {
        private const string ServiceName = "Kiss4Web";

        // Relative path to the root folder of the service project.
        // The path is relative to the target folder for the test DLL,
        // i.e. /test/MyTests/bin/Debug
        private const string SolutionPath = "../../../../..";

        private const string ServicePath = "../../../../../Kiss4Web";

        // Tag used for ${TAG} in docker-compose.yml
        private const string Tag = "test";

        private const string Configuration = "Debug";

        //[Fact]
        public async Task Authenticate()
        {
            //var buildProcess = Process.Start(new ProcessStartInfo
            //{
            //    FileName = "dotnet",
            //    Arguments = $"publish {ServicePath} --configuration {Configuration}"
            //});
            //buildProcess.WaitForExit();
            //buildProcess.ExitCode.ShouldBe(0);

            /*
            var processStartInfoBuild = new ProcessStartInfo
            {
                FileName = "docker-compose",
                Arguments = $"-f {SolutionPath}/docker-compose.test.yml build"
            };
            AddEnvironmentVariables(processStartInfoBuild);

            var processBuild = Process.Start(processStartInfoBuild);
            processBuild.WaitForExit();
            processBuild.ExitCode.ShouldBe(0);
            */

            // Now start the docker containers
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "docker-compose",
                Arguments =
                $"-f {SolutionPath}/docker-compose.test.yml -p {ServiceName}-test up -d", //--force-recreate
                UseShellExecute = false,
                RedirectStandardError = true
            };
            AddEnvironmentVariables(processStartInfo);

            var process = Process.Start(processStartInfo);
            var error = new StringBuilder();
            process.ErrorDataReceived += (sender, args) => error.AppendLine(args.Data);

            process.WaitForExit();
            process.ExitCode.ShouldBe(0, await process.StandardError.ReadToEndAsync());
            var standardError = await process.StandardError.ReadToEndAsync();

            //var builder = new WebHostBuilder().UseStartup(typeof(Startup));

            //var testServer = new Microsoft.AspNetCore.TestHost.TestServer(builder);

            // discover endpoints from metadata
            var discoveryClient = new DiscoveryClient("http://localhost:5002");
            discoveryClient.Policy.ValidateIssuerName = false;
            var disco = await discoveryClient.GetAsync();
            var retries = 5;
            while (disco.IsError && retries-- > 0)
            {
                await Task.Delay(500);
                disco = await discoveryClient.GetAsync();
            }
            disco.IsError.ShouldBe(false, disco.Error);
            await Task.Delay(500);

            var tokenClient = new TokenClient(disco.TokenEndpoint, "webclient.ro", "EA59A39A-B03D-4985-A4FA-9297663A1858");
            //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api");
            //var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("jburgmeier", "topsecretunittestpassword");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("ckaeser", "Ki$$2013", "api");

            tokenResponse.IsError.ShouldNotBe(true, $"{tokenResponse.Error}{Environment.NewLine}{tokenResponse.ErrorDescription}");

            var client = new HttpClient();
            //client.SetBearerToken(tokenResponse.AccessToken);

            var result = await client.GetAsJsonAsync<BaPerson>("http://localhost:8002/api/personen/64805");
            result.IsSuccess.ShouldBeTrue();

            var person = result.Result;

            person.Id.ShouldBe(64805);
            person.Name.ShouldBe("*Velori");
        }

        private void AddEnvironmentVariables(ProcessStartInfo processStartInfo)
        {
            processStartInfo.Environment["TAG"] = Tag;
            processStartInfo.Environment["CONFIGURATION"] = Configuration;
            processStartInfo.Environment["COMPUTERNAME"] = Environment.MachineName;
        }
    }
}