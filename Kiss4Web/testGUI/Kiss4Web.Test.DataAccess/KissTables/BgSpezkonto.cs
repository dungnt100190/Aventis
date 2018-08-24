namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgSpezkonto")]
    public partial class BgSpezkonto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgSpezkonto()
        {
            BgPositions = new HashSet<BgPosition>();
            BgSpezkontoAbschlusses = new HashSet<BgSpezkontoAbschluss>();
            ShEinzelzahlungs = new HashSet<ShEinzelzahlung>();
        }

        public int BgSpezkontoID { get; set; }

        public int FaLeistungID { get; set; }

        public int BgSpezkontoTypCode { get; set; }

        [Required]
        [StringLength(100)]
        public string NameSpezkonto { get; set; }

        [Column(TypeName = "money")]
        public decimal StartSaldo { get; set; }

        public bool OhneEinzelzahlung { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragProMonat { get; set; }

        public int? BgPositionsartID { get; set; }

        public DateTime? ErsterMonat { get; set; }

        public int? BgKostenartID { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public string Bemerkung { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgSpezkontoTS { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? BaPersonID { get; set; }

        public bool Inaktiv { get; set; }

        public int? KuerzungLaufzeitMonate { get; set; }

        [Column(TypeName = "money")]
        public decimal? KuerzungAnteilGBL { get; set; }

        public string AbschlussBegruendung { get; set; }

        public int? AbzahlungskontoRueckerstattungCode { get; set; }

        public int? AbschlussgrundCode { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions { get; set; }

        public virtual BgPositionsart BgPositionsart { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgSpezkontoAbschluss> BgSpezkontoAbschlusses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShEinzelzahlung> ShEinzelzahlungs { get; set; }
    }
}
