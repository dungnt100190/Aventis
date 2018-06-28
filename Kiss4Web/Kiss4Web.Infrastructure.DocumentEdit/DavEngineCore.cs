using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;

using ITHit.WebDAV.Server;

using Kiss4Web.Infrastructure.DocumentEdit.Options;

namespace Kiss4Web.Infrastructure.DocumentEdit
{
    /// <summary>
    /// Represents WebDAV Engine. Processes WebDAV requests and generates responses. 
    /// Provides constructors specific for ASP.NET Core implementation, that can read configuration parameters.
    /// </summary>
    /// <remarks>
    /// A single instance of this class per application is created.
    /// </remarks>
    public class DavEngineCore : DavEngineAsync
    {
        /// <summary>
        /// Initializes new instance of this class based on the WebDAV Engine configuration options and logger instance.
        /// </summary>
        /// <param name="configOptions">WebDAV Engine configuration options.</param>
        /// <param name="logger">Logger instance.</param>
        /// <param name="env">IHostingEnvironment instance.</param>
        public DavEngineCore(IOptions<DavEngineOptions> configOptions, ILogger logger, IHostingEnvironment env) : base()
        {
            DavEngineOptions options = configOptions.Value;

            OutputXmlFormatting         = options.OutputXmlFormatting; 
            UseFullUris                 = options.UseFullUris;
            CorsAllowedFor              = options.CorsAllowedFor;
            License                     = options.License;

            Logger                      = logger;

            // Set custom handler to process GET and HEAD requests to folders and display 
            // info about how to connect to server. We are using the same custom handler 
            // class (but different instances) here to process both GET and HEAD because 
            // these requests are very similar. 
            // Note that some WebDAV clients may fail to connect if HEAD request is not processed.
            CustomGetHandler handlerGet = new CustomGetHandler(env.ContentRootPath);
            CustomGetHandler handlerHead = new CustomGetHandler(env.ContentRootPath);
            handlerGet.OriginalHandler = RegisterMethodHandler("GET", handlerGet);
            handlerHead.OriginalHandler = RegisterMethodHandler("HEAD", handlerHead);
        }
    }
}
