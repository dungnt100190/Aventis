namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvPositionsart")]
    public partial class GvPositionsart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GvPositionsart()
        {
            GvAuszahlungPositions = new HashSet<GvAuszahlungPosition>();
            GvPositionsart11 = new HashSet<GvPositionsart>();
        }

        public int GvPositionsartID { get; set; }

        public int? GvPositionsartID_CopyOf { get; set; }

        public int BgKostenartID { get; set; }

        public string Bezeichnung { get; set; }

        public int? BezeichnungTID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public bool HSOnly { get; set; }

        public bool IsFLB { get; set; }

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
        public byte[] GvPositionsartTS { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAuszahlungPosition> GvAuszahlungPositions { get; set; }

        public virtual GvPositionsart GvPositionsart1 { get; set; }

        public virtual GvPositionsart GvPositionsart2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvPositionsart> GvPositionsart11 { get; set; }

        public virtual GvPositionsart GvPositionsart3 { get; set; }
    }
}
