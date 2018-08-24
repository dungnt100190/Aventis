namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XRight")]
    public partial class XRight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XRight()
        {
            XUserGroup_Right = new HashSet<XUserGroup_Right>();
        }

        [Key]
        public int RightID { get; set; }

        public int XClassID { get; set; }

        [Required]
        [StringLength(255)]
        public string ClassName { get; set; }

        [Required]
        [StringLength(100)]
        public string RightName { get; set; }

        [Required]
        [StringLength(255)]
        public string UserText { get; set; }

        [Required]
        public string Description { get; set; }

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
        public byte[] XRightTS { get; set; }

        public virtual XClass XClass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUserGroup_Right> XUserGroup_Right { get; set; }
    }
}
