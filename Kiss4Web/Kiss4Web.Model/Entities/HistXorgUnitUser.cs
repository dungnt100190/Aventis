using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class HistXorgUnitUser
    {
        public int XorgUnitUserId { get; set; }
        public int OrgUnitId { get; set; }
        public int UserId { get; set; }
        public int OrgUnitMemberCode { get; set; }
        public bool MayInsert { get; set; }
        public bool MayUpdate { get; set; }
        public bool MayDelete { get; set; }
        public int VerId { get; set; }
        public int? VerIdDeleted { get; set; }
    }
}
