using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevExpress.XtraReports.Web.ClientControls;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Infrastructure.Reporting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.Reports
{    
    [Authorize]
    [Route("api/reports")]
    public class ReportController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHostingEnvironment _env;

        public ReportController(IMediator mediator, IHostingEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }

        [HttpPost("print")]
        public async Task<IActionResult> GenerateXtraReport(string queryName, [FromBody]IEnumerable<ContextValue> contextValues)
        {
            var report = await _mediator.Process(new GenerateXtraReportCommand { QueryName = queryName,
                ContextValues = contextValues,
                KissReportDestination = Kiss4ReportDestination.Printer,
                XtraReportFullPath = System.IO.Path.Combine(_env.ContentRootPath,string.Format("Reports\\XtraReports\\{0}.repx", queryName)) });
            var clientSideModelGenerator = new WebDocumentViewerClientSideModelGenerator();
            var clientSideModelSettings = new ClientSideModelSettings { IncludeLocalization = false };
            var clientXtraReport = clientSideModelGenerator.GetJsonModelScript(report, "/DXXRDV", clientSideModelSettings);
            return View(new { ClientXtraReport = clientXtraReport });
        }
    }
}