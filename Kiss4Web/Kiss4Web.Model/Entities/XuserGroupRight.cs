using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XUserGroupRight : IEntity
    {
        public int UserGroupRightId { get; set; }
        public int UserGroupId { get; set; }
        public int? RightId { get; set; }
        public int? XclassId { get; set; }
        public string ClassName { get; set; }
        public string QueryName { get; set; }
        public string MaskName { get; set; }
        public bool MayInsert { get; set; }
        public bool MayUpdate { get; set; }
        public bool MayDelete { get; set; }
        public byte[] XuserGroupRightTs { get; set; }

        public DynaMask MaskNameNavigation { get; set; }
        public Xquery QueryNameNavigation { get; set; }
        public XRight Right { get; set; }
        public XUserGroup UserGroup { get; set; }
        public XClass XClass { get; set; }
        public int Id => UserGroupRightId;
        public byte[] RowVersion => XuserGroupRightTs;
    }
}