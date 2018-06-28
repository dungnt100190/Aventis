using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XorgUnitXdocTemplate
    {
        public int XorgUnitXdocTemplateId { get; set; }
        public int OrgUnitId { get; set; }
        public int DocTemplateId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XorgUnitXdocTemplateTs { get; set; }

        public XDocTemplate DocTemplate { get; set; }
        public XOrgUnit OrgUnit { get; set; }
    }
}
