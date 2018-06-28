using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class MigLookup
    {
        public string Lookup { get; set; }
        public int RowId { get; set; }
        public string Value { get; set; }
        public byte[] MigLookupTs { get; set; }
    }
}
