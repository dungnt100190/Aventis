namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BDEUserGroup")]
    public partial class BDEUserGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BDEUserGroup()
        {
            BDEUserGroup_BDELeistungsart = new HashSet<BDEUserGroup_BDELeistungsart>();
            XUser_BDEUserGroup = new HashSet<XUser_BDEUserGroup>();
        }

        public int BDEUserGroupID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserGroupName { get; set; }

        public int? UserGroupNameTID { get; set; }

        [StringLength(1000)]
        public string Beschreibung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDEUserGroupTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDEUserGroup_BDELeistungsart> BDEUserGroup_BDELeistungsart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_BDEUserGroup> XUser_BDEUserGroup { get; set; }
    }
}
