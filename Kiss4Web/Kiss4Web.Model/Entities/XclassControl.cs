using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XclassControl
    {
        public XclassControl()
        {
            XclassRule = new HashSet<XclassRule>();
        }

        public string ClassName { get; set; }
        public string ControlName { get; set; }
        public string ParentControl { get; set; }
        public string TypeName { get; set; }
        public int? ControlTid { get; set; }
        public string DataMember { get; set; }
        public string DataSource { get; set; }
        public string Lovname { get; set; }
        public int TabIndex { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string PropertiesXml { get; set; }
        public bool System { get; set; }
        public byte[] XclassControlTs { get; set; }

        public ICollection<XclassRule> XclassRule { get; set; }
    }
}
