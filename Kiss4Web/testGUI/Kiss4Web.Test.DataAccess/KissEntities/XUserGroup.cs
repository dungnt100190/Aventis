namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XUserGroup")]
    public partial class XUserGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XUserGroup()
        {
            XUser_UserGroup = new HashSet<XUser_UserGroup>();
            XUserGroup_Right = new HashSet<XUserGroup_Right>();
        }

        [Key]
        public int UserGroupID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserGroupName { get; set; }

        public int? UserGroupNameTID { get; set; }

        public bool OnlyAdminVisible { get; set; }

        public string Description { get; set; }

        public int? DescriptionTID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XUserGroupTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_UserGroup> XUser_UserGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUserGroup_Right> XUserGroup_Right { get; set; }
    }
}
