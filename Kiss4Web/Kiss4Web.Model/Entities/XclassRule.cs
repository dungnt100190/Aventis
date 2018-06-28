using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XclassRule
    {
        public int XclassRuleId { get; set; }
        public string ClassName { get; set; }
        public string ControlName { get; set; }
        public string ComponentName { get; set; }
        public int XruleId { get; set; }
        public int SortKey { get; set; }
        public bool? Active { get; set; }
        public byte[] XclassRuleTs { get; set; }

        public XclassComponent C { get; set; }
        public XclassControl CNavigation { get; set; }
        public Xrule Xrule { get; set; }
    }
}
