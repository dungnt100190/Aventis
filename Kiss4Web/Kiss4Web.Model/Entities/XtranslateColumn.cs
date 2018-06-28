using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XtranslateColumn
    {
        public int XtranslateColumnId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string TidcolumnName { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XtranslateColumnTs { get; set; }
    }
}
