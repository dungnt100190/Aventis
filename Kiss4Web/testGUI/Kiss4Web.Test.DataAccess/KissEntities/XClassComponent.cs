namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XClassComponent")]
    public partial class XClassComponent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XClassComponent()
        {
            XClassRules = new HashSet<XClassRule>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ClassName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string ComponentName { get; set; }

        [Required]
        [StringLength(500)]
        public string TypeName { get; set; }

        public int? ComponentTID { get; set; }

        public string SelectStatement { get; set; }

        [StringLength(255)]
        public string TableName { get; set; }

        public string PropertiesXML { get; set; }

        public bool System { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XClassComponentTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XClassRule> XClassRules { get; set; }
    }
}
