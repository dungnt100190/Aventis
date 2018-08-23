namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XDocContext")]
    public partial class XDocContext
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XDocContext()
        {
            XDocContext_Template = new HashSet<XDocContext_Template>();
        }

        [Key]
        public int DocContextID { get; set; }

        [Required]
        [StringLength(50)]
        public string DocContextName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool System { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XDocContextTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XDocContext_Template> XDocContext_Template { get; set; }
    }
}
