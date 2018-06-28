using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xhyperlink
    {
        public Xhyperlink()
        {
            XhyperlinkContextHyperlink = new HashSet<XhyperlinkContextHyperlink>();
        }

        public int XhyperlinkId { get; set; }
        public string Hyperlink { get; set; }
        public string Name { get; set; }
        public byte[] XhyperlinkTs { get; set; }

        public ICollection<XhyperlinkContextHyperlink> XhyperlinkContextHyperlink { get; set; }
    }
}
