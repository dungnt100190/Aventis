using DevExpress.XtraReports.UI;
using Kiss4Web.Infrastructure.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Infrastructure.Reporting
{
    public class GenerateXtraReportCommand : Message<XtraReport>
    {        
        public string QueryName { get; set; }
        public string XtraReportFullPath { get; set; }
        public Kiss4ReportDestination KissReportDestination { get; set; }
        public IEnumerable<ContextValue> ContextValues { get; set; }
    }
}
