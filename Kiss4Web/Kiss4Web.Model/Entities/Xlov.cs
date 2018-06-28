using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xlov
    {
        public Xlov()
        {
            XlovcodeLovnameNavigation = new HashSet<XLovCode>();
            XlovcodeXlov = new HashSet<XLovCode>();
        }

        public int Xlovid { get; set; }
        public string Lovname { get; set; }
        public string Description { get; set; }
        public bool System { get; set; }
        public bool? Expandable { get; set; }
        public int? ModulId { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? Translatable { get; set; }
        public string NameValue1 { get; set; }
        public string NameValue2 { get; set; }
        public string NameValue3 { get; set; }
        public byte[] Xlovts { get; set; }

        public XModul Modul { get; set; }
        public ICollection<XLovCode> XlovcodeLovnameNavigation { get; set; }
        public ICollection<XLovCode> XlovcodeXlov { get; set; }
    }
}
