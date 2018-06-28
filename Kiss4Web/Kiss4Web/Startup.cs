using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using Kiss4Web.DataAccess;
using Kiss4Web.ErrorHandling;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.Authorization;
using Kiss4Web.Infrastructure.DataAccess;
using Kiss4Web.Infrastructure.DocumentEdit;
using Kiss4Web.Infrastructure.ErrorHandling;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Infrastructure.Modularity;
using Kiss4Web.Infrastructure.Modularity.Licensing;
using Kiss4Web.Infrastructure.Reporting;
using Kiss4Web.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace Kiss4Web
{
    public class Startup
    {
        private readonly Container _container = new Container();
        private LicensedAssemblies _licensedAssemblies;
        private LicensedTypes _licensedTypes;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; private set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var supportedCultures = new[] { new CultureInfo(Languages.Deutsch), new CultureInfo(Languages.Français), new CultureInfo(Languages.Italiano) };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("de"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseMiddleware<WriteWarningsToResponseMiddleware>(_container);

            //app.UseHsts(o =>
            //{
            //    o.IncludeSubdomains();
            //    o.MaxAge(365);
            //    o.Preload();
            //});

            app.UseXXssProtection(o => o.Enabled());
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(o => o.NoReferrer());
            app.UseXfo(o => o.Deny());
            app.UseRedirectValidation(o => o.AllowSameHostRedirectsToHttps());

            app.UseAuthentication();
            app.UseMvc();

            //app.UseDigestAuth();
            //app.UseBasicAuth();
            //app.UseWebSockets();
            //app.UseWebSocketsMiddleware();
            //app.UseWebDav(HostingEnvironment);
            //DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new ReportStorageWebExtension1());
            //DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
            app.UseDevExpressControls();

            _container.CrossWire<IHttpContextAccessor>(app);
            _container.CrossWire<IMemoryCache>(app);
            _container.CrossWire<ILoggerFactory>(app);

            _container.RegisterConditional(
                typeof(ILogger),
                c => typeof(Logger<>).MakeGenericType(c.Consumer.ImplementationType),
                Lifestyle.Singleton,
                c => true);

            // hooks for injection from integration tests
            TryCrosswire<HttpMessageHandler>(app);
            TryCrosswire<IDateTimeProvider, DateTimeProvider>(app);

            // setup query pipeline (execution order is bottom up)
            _container.RegisterDecorator(typeof(TypedMessageHandler<,>), typeof(SaveDbContextMessageDecorator<,>));
            _container.RegisterDecorator(typeof(TypedMessageHandler<,>), typeof(AuthorizationQueryDecorator<,>));
            _container.RegisterDecorator(typeof(TypedMessageHandler<,>), typeof(RootQueryDecorator<,>));

            // setup command pipeline
            _container.RegisterDecorator(typeof(TypedMessageHandler<>), typeof(SaveDbContextDecorator<>));
            _container.RegisterDecorator(typeof(TypedMessageHandler<>), typeof(AuthorizationCommandDecorator<>));
            _container.RegisterDecorator(typeof(TypedMessageHandler<>), typeof(RootCommandDecorator<>));

            _container.Verify();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new SqlConnectionStringBuilder(Configuration["DockerConnectionString"] ?? Configuration.GetConnectionString("DefaultConnection"));
            var overrideDbHost = Configuration.GetValue<string>("DbHost");
            if (overrideDbHost != null)
            {
                builder.DataSource = overrideDbHost;
            }
            builder.MultipleActiveResultSets = true;
            var connectionString = new ConnectionString(builder.ConnectionString);

            var licenseReader = new LicenseReader(new SqlConnection(connectionString));

            _licensedTypes = new LicensedTypes(licenseReader, new Kiss4WebAssemblies());
            _licensedAssemblies = new LicensedAssemblies(_licensedTypes);

            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.Options.DefaultLifestyle = new AsyncScopedLifestyle();
            _container.RegisterInstance(_licensedTypes);
            _container.RegisterInstance(connectionString);
            _container.RegisterInstance(HostingEnvironment);
            _container.RegisterInstance<ILicenseReader>(licenseReader);
            _licensedAssemblies.Get<ITypeRegistrator>().DoForEach(reg => reg.RegisterTypes(_container, _licensedAssemblies));

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));
            services.UseSimpleInjectorAspNetRequestScoping(_container);

            services.AddSingleton(_container);
            services.EnableSimpleInjectorCrossWiring(_container);
            services.AddSingleton(x => _container.GetInstance<IExceptionTranslator>());
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var httpsCertificate = new X509Certificate2("localhost.pfx", "TFHbiWtjzrraFBwAWvTWLjyfNhtdTogTJzPQQWcnBqGyBXUbANniJUQswwpnJzWe");
            //services.Configure<KestrelServerOptions>(o =>
            //{
            //    o.AddServerHeader = false;
            //    o.Listen(IPAddress.Any, 80);
            //    //o.Listen(IPAddress.Any, 443, listenOptions => listenOptions.UseHttps(httpsCertificate));
            //});
            services.AddMemoryCache();
            services.AddDevExpressControls();
            var mvcBuilder = services
                .AddMvc(options =>
                {
                    //options.SslPort = 443;
                    //options.Filters.Add(new RequireHttpsAttribute());
                    options.Filters.Add(typeof(RootExceptionFilterAttribute));
                    //options.Filters.Add(new AuthorizeFilter(defaultPolicy));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
                });//.AddDefaultReportingControllers();

            //services.ConfigureReportingServices(configurator =>
            //{
            //    configurator.ConfigureReportDesigner(designerConfigurator =>
            //    {
            //        designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
            //    });
            //});
            _licensedTypes.Assemblies.DoForEach(ass => mvcBuilder.AddApplicationPart(ass));

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["Authentication:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.JwtBackChannelHandler = TryGetJwtBackChannelHandler(_container);

                    options.ApiName = "api";
                });
            //services.AddWebDav(Configuration, HostingEnvironment);
            //services.AddSingleton<WebSocketsService>();
            //services.Configure<DavUsersOptions>(options => Configuration.GetSection("DavUsers").Bind(options));
        }

        private static HttpMessageHandler TryGetJwtBackChannelHandler(Container container)
        {
            try
            {
                return container.GetInstance<HttpMessageHandler>();
            }
            catch
            {
                return null;
            }
        }

        private void TryCrosswire<T>(IApplicationBuilder app)
            where T : class
        {
            var instance = app.ApplicationServices.GetService<T>();
            if (instance != null)
            {
                _container.CrossWire<T>(app);
            }
        }

        private void TryCrosswire<T, TFallbackImplementiation>(IApplicationBuilder app)
            where T : class
            where TFallbackImplementiation : class, T
        {
            var instance = app.ApplicationServices.GetService<T>();
            if (instance != null)
            {
                _container.CrossWire<T>(app);
            }
            else
            {
                _container.RegisterSingleton<T, TFallbackImplementiation>();
            }
        }
    }
}