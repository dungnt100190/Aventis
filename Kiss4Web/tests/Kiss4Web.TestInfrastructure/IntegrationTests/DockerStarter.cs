using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Docker.DotNet;

namespace Kiss4Web.TestInfrastructure.IntegrationTests
{
    public class DockerStarter
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

        public static void TryStartDbContainer(string connectionString)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "docker-compose",
                Arguments = $"-f {SolutionPath}/docker-compose.dbonly.yml -p {ServiceName}test up -d", //--force-recreate
                UseShellExecute = false,
                RedirectStandardError = true
            };
            processStartInfo.Environment["ConnectionString:DefaultConnection"] = connectionString;

            var process = Process.Start(processStartInfo);

            process.WaitForExit();
            //process.ExitCode.ShouldBe(0, await process.StandardError.ReadToEndAsync());
            //var standardError = await process.StandardError.ReadToEndAsync();
        }

        public static async Task StartDbServer()
        {
            //var hosts = new Hosts().Discover();
            //var docker = hosts.FirstOrDefault(x => x.IsNative) ?? hosts.FirstOrDefault(x => x.Name == "default");

            //var dbContainer = new Builder()
            //    .UseContainer()
            //    .WithName("kiss4-db-test")
            //    .UseImage("aventis.azurecr.io/kiss4web-db")
            //    .WithEnvironment("SA_PASSWORD=D0102A72-7838-4078-9829-DBD038018C18", "ACCEPT_EULA=Y")
            //    .ExposePort(1433, 1435)
            //    .Build();

            //dbContainer.Start();

            var dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            //await dockerClient.Containers.StartContainerExecAsync("aventis.azurecr.io/kiss4web-db");
            await dockerClient.Containers.StartContainerExecAsync("kiss4-db-test");

            //var dbServer = containers.First(c => c.Image == "aventis.azurecr.io/kiss4web-db" && c.Names.Any(n => n.Contains("kiss4-db-test")));
            //var ipDb = dbServer.NetworkSettings.Networks.First().Value.IPAddress;
            //return new DockerContainerInfos { IpAddressDbServer = ipDb };
        }
    }
}