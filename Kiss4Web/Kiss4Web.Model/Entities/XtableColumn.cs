using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XtableColumn
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int? FieldCode { get; set; }
        public string DisplayText { get; set; }
        public int? DisplayTextTid { get; set; }
        public string Lovname { get; set; }
        public bool System { get; set; }
        public string Comment { get; set; }
        public int? SortKey { get; set; }
        public byte[] XtableColumnTs { get; set; }

        public Xtable TableNameNavigation { get; set; }
    }
}
