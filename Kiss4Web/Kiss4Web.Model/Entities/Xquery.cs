using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xquery
    {
        public Xquery()
        {
            InverseXqueryNavigation = new HashSet<Xquery>();
            XuserGroupRight = new HashSet<XUserGroupRight>();
        }

        public string QueryName { get; set; }
        public string ParentReportName { get; set; }
        public int QueryCode { get; set; }
        public string UserText { get; set; }
        public string LayoutXml { get; set; }
        public string ParameterXml { get; set; }
        public string Sqlquery { get; set; }
        public string ContextForms { get; set; }
        public int? ReportSortKey { get; set; }
        public string RelationColumnName { get; set; }
        public bool? System { get; set; }
        public byte[] XqueryTs { get; set; }

        public Xquery XqueryNavigation { get; set; }
        public ICollection<Xquery> InverseXqueryNavigation { get; set; }
        public ICollection<XUserGroupRight> XuserGroupRight { get; set; }
    }
}
