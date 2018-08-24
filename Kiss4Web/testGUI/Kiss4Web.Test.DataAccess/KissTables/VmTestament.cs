namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmTestament")]
    public partial class VmTestament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmTestament()
        {
            VmErbes = new HashSet<VmErbe>();
            VmTestamentBescheinigungs = new HashSet<VmTestamentBescheinigung>();
            VmTestamentVerfuegungs = new HashSet<VmTestamentVerfuegung>();
        }

        public int VmTestamentID { get; set; }

        public int FaLeistungID { get; set; }

        public int? LaufNr { get; set; }

        public int? UserID { get; set; }

        [StringLength(20)]
        public string KopieAnCodes { get; set; }

        [StringLength(20)]
        public string ZeugnisseCodes { get; set; }

        [Column(TypeName = "money")]
        public decimal? EroeffnungsRechnungBetrag { get; set; }

        [StringLength(10)]
        public string EroeffnungsRechnungSAPNr { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZusatzRechnungBetrag { get; set; }

        [StringLength(10)]
        public string ZusatzRechnungSAPNr { get; set; }

        public int? EroeffnungDokID { get; set; }

        public int? EroeffnungAuszugDokID { get; set; }

        public int? EroeffnungAdressenDokID { get; set; }

        public DateTime? EroeffnungAbgeschlossenDatum { get; set; }

        public DateTime? PublikationFrist { get; set; }

        public DateTime? PublikationDatum { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmTestamentTS { get; set; }

        public int? NotarID { get; set; }

        public int? Jahr { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErbe> VmErbes { get; set; }

        public virtual XUser XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmTestamentBescheinigung> VmTestamentBescheinigungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmTestamentVerfuegung> VmTestamentVerfuegungs { get; set; }
    }
}
