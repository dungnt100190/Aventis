using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XhyperlinkContext
    {
        public XhyperlinkContext()
        {
            XhyperlinkContextHyperlink = new HashSet<XhyperlinkContextHyperlink>();
        }

        public int XhyperlinkContextId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? System { get; set; }
        public byte[] XhyperlinkContextTs { get; set; }

        public ICollection<XhyperlinkContextHyperlink> XhyperlinkContextHyperlink { get; set; }
    }
}
