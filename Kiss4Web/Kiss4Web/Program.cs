using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace Kiss4Web
{
    public class Program
    {
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .UseSerilog(ConfigureSerilog)
                .Build();

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static void ConfigureSerilog(WebHostBuilderContext context, LoggerConfiguration configuration)
        {
            configuration
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.ApplicationInsightsTraces(context.Configuration["ApplicationInsights:InstrumentationKey"]);
        }
    }
}