namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XClassControl")]
    public partial class XClassControl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XClassControl()
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
        public string ControlName { get; set; }

        [StringLength(255)]
        public string ParentControl { get; set; }

        [Required]
        [StringLength(255)]
        public string TypeName { get; set; }

        public int? ControlTID { get; set; }

        [StringLength(255)]
        public string DataMember { get; set; }

        [StringLength(255)]
        public string DataSource { get; set; }

        [StringLength(255)]
        public string LOVName { get; set; }

        public int TabIndex { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string PropertiesXML { get; set; }

        public bool System { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XClassControlTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XClassRule> XClassRules { get; set; }
    }
}
