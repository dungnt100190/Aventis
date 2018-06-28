using System.Data.SqlClient;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace Kiss4Web.IdentityServer
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new SqlConnectionStringBuilder(Configuration["DockerConnectionString"] ?? Configuration.GetConnectionString("DefaultConnection"));
            // override for VSTS
            var overrideDbHost = Configuration.GetValue<string>("DbHost");
            if (overrideDbHost != null)
            {
                builder.DataSource = overrideDbHost;
            }
            var connectionString = new ConnectionString(builder.ConnectionString);

            _container.RegisterInstance(connectionString);
            _container.RegisterSingleton<IResourceOwnerPasswordValidator, Kiss4PasswordValidator>();
            _container.RegisterSingleton<IProfileService, Kiss4ProfileService>();
            _container.RegisterSingleton(() => new Scrambler("KiSS4"));

            // configure identity server with in-memory stores, keys, clients and resources
            services.AddIdentityServer(options => options.IssuerUri = Configuration["Authentication:Authority"])
                    .AddDeveloperSigningCredential()
                    .AddInMemoryApiResources(AuthenticationConfig.GetApiResources())
                    .AddInMemoryClients(AuthenticationConfig.GetClients())
                    .Services.AddTransient(sp => _container.GetInstance<IResourceOwnerPasswordValidator>())
                             .AddTransient(sp => _container.GetInstance<IProfileService>());

            _container.Verify();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
        }
    }
}