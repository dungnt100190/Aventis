using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XUserUserGroup : IEntity
    {
        public int XuserUserGroupId { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public byte[] XuserUserGroupTs { get; set; }

        public XUser User { get; set; }
        public XUserGroup UserGroup { get; set; }
        public int Id => XuserUserGroupId;
        public byte[] RowVersion => XuserUserGroupTs;
    }
}