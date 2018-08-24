namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XArchive")]
    public partial class XArchive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XArchive()
        {
            FaLeistungArchivs = new HashSet<FaLeistungArchiv>();
            XUser_Archive = new HashSet<XUser_Archive>();
        }

        [Key]
        public int ArchiveID { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public string Address { get; set; }

        public int SortKey { get; set; }

        public string Remark { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XArchiveTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungArchiv> FaLeistungArchivs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_Archive> XUser_Archive { get; set; }
    }
}
