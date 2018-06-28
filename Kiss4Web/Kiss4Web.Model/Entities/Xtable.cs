using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xtable
    {
        public Xtable()
        {
            XtableColumn = new HashSet<XtableColumn>();
        }

        public string TableName { get; set; }
        public string Alias { get; set; }
        public bool? System { get; set; }
        public int? ModulId { get; set; }
        public bool? DataWareHouse { get; set; }
        public string Comment { get; set; }
        public byte[] XtableTs { get; set; }

        public XModul Modul { get; set; }
        public ICollection<XtableColumn> XtableColumn { get; set; }
    }
}
