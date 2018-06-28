using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xlog
    {
        public int XlogId { get; set; }
        public string Source { get; set; }
        public int? SourceKey { get; set; }
        public int XlogLevelCode { get; set; }
        public string Message { get; set; }
        public string Comment { get; set; }
        public string ReferenceTable { get; set; }
        public int? ReferenceId { get; set; }
        public bool NonPurgeable { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XlogTs { get; set; }
    }
}
