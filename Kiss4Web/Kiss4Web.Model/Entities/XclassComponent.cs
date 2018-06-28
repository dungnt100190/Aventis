using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XclassComponent
    {
        public XclassComponent()
        {
            XclassRule = new HashSet<XclassRule>();
        }

        public string ClassName { get; set; }
        public string ComponentName { get; set; }
        public string TypeName { get; set; }
        public int? ComponentTid { get; set; }
        public string SelectStatement { get; set; }
        public string TableName { get; set; }
        public string PropertiesXml { get; set; }
        public bool System { get; set; }
        public byte[] XclassComponentTs { get; set; }

        public ICollection<XclassRule> XclassRule { get; set; }
    }
}
