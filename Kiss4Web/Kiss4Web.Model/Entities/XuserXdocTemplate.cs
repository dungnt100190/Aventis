using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XuserXdocTemplate
    {
        public int XuserXdocTemplateId { get; set; }
        public int? UserId { get; set; }
        public int? DocTemplateId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XuserXdocTemplateTs { get; set; }

        public XDocTemplate DocTemplate { get; set; }
        public XUser User { get; set; }
    }
}
