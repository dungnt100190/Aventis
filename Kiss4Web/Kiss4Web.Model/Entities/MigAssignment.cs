using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class MigAssignment
    {
        public string Lookup { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public byte[] MigAssignmentTs { get; set; }
    }
}
