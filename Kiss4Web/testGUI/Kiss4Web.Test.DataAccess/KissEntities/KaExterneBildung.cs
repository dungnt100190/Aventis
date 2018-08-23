namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaExterneBildung")]
    public partial class KaExterneBildung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaExterneBildung()
        {
            KaExterneBildungZahlungs = new HashSet<KaExterneBildungZahlung>();
        }

        public int KaExterneBildungID { get; set; }

        public int BaPersonID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? Kurstyp { get; set; }

        [StringLength(200)]
        public string Bezeichnung { get; set; }

        [StringLength(200)]
        public string Kursort { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? AnzahlKurstage { get; set; }

        public bool Kursbestaetigung { get; set; }

        [Column(TypeName = "money")]
        public decimal? AnteilKA { get; set; }

        [Column(TypeName = "money")]
        public decimal? AnteilDritte { get; set; }

        public int? KaProgrammCode { get; set; }

        public bool SichtbarSDFlag { get; set; }

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
        public byte[] KaExterneBildungTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaExterneBildungZahlung> KaExterneBildungZahlungs { get; set; }
    }
}
