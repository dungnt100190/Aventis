using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XOrgUnit_User : IEntity
    {
        public int XorgUnitUserId { get; set; }
        public int OrgUnitId { get; set; }
        public int UserId { get; set; }
        public int OrgUnitMemberCode { get; set; }
        public bool MayInsert { get; set; }
        public bool MayUpdate { get; set; }
        public bool MayDelete { get; set; }
        public int? VerId { get; set; }
        public byte[] XorgUnitUserTs { get; set; }

        public XOrgUnit OrgUnit { get; set; }
        public XUser User { get; set; }
        public int Id => XorgUnitUserId;
        public byte[] RowVersion => XorgUnitUserTs;
    }
}