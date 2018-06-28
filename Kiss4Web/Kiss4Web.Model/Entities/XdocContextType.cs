using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XdocContextType
    {
        public int DocContextTypeId { get; set; }
        public string NameDocContextType { get; set; }
        public string TemplateFolder { get; set; }
        public string DocumentFolder { get; set; }
        public string Description { get; set; }
        public byte[] XdocContextTypeTs { get; set; }
    }
}
