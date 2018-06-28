using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XdocContext
    {
        public XdocContext()
        {
            XdocContextTemplate = new HashSet<XdocContextTemplate>();
        }

        public int DocContextId { get; set; }
        public string DocContextName { get; set; }
        public string Description { get; set; }
        public bool? System { get; set; }
        public byte[] XdocContextTs { get; set; }

        public ICollection<XdocContextTemplate> XdocContextTemplate { get; set; }
    }
}
