namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SstASVSExport")]
    public partial class SstASVSExport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SstASVSExport()
        {
            SstASVSExport_Eintrag = new HashSet<SstASVSExport_Eintrag>();
        }

        public int SstASVSExportID { get; set; }

        public DateTime? DatumExport { get; set; }

        [StringLength(400)]
        public string Bemerkung { get; set; }

        public int? DocumentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        [Required]
        [StringLength(50)]
        public string Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] SstASVSExportTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SstASVSExport_Eintrag> SstASVSExport_Eintrag { get; set; }
    }
}
