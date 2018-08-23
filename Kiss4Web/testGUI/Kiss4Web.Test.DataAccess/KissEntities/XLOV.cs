namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XLOV")]
    public partial class XLOV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XLOV()
        {
            XLOVCodes = new HashSet<XLOVCode>();
        }

        public int XLOVID { get; set; }

        [Required]
        [StringLength(100)]
        public string LOVName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool System { get; set; }

        public bool Expandable { get; set; }

        public int? ModulID { get; set; }

        public DateTime? LastUpdated { get; set; }

        public bool Translatable { get; set; }

        [StringLength(100)]
        public string NameValue1 { get; set; }

        [StringLength(100)]
        public string NameValue2 { get; set; }

        [StringLength(100)]
        public string NameValue3 { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XLOVTS { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XLOVCode> XLOVCodes { get; set; }
    }
}
