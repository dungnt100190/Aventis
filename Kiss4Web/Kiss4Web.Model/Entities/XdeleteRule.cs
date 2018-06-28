using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XdeleteRule
    {
        public int XdeleteRuleId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int XdeleteRuleCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XdeleteRuleTs { get; set; }
    }
}
