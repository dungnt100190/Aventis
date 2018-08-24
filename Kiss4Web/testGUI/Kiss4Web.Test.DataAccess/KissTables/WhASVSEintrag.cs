namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WhASVSEintrag")]
    public partial class WhASVSEintrag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WhASVSEintrag()
        {
            SstASVSExport_Eintrag = new HashSet<SstASVSExport_Eintrag>();
        }

        public int WhASVSEintragID { get; set; }

        public int FaLeistungID { get; set; }

        public int BaPersonID { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int ASVSEintragStatusCode { get; set; }

        [StringLength(2000)]
        public string Bemerkung { get; set; }

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
        public byte[] WhASVSEintragTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SstASVSExport_Eintrag> SstASVSExport_Eintrag { get; set; }
    }
}
