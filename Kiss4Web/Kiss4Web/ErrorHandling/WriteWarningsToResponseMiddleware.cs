using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.ErrorHandling;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Kiss4Web.ErrorHandling
{
    public class WriteWarningsToResponseMiddleware : IMiddleware
    {
        private readonly IWarningsCollector _warningsCollector;

        public WriteWarningsToResponseMiddleware(IWarningsCollector warningsCollector)
        {
            _warningsCollector = warningsCollector;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.OnStarting(() => AddWarnings(context.Response.Headers));
            await next.Invoke(context);
        }

        private Task AddWarnings(IHeaderDictionary responseHeaders)
        {
            var warnings = _warningsCollector.Warnings.ToList();
            if (warnings.Any())
            {
                var warningsJson = JsonConvert.SerializeObject(warnings);
                var warningsJsonBase64 = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(warningsJson));
                responseHeaders.Add("X-Warnings", warningsJsonBase64);
            }

            return Task.CompletedTask;
        }
    }
}