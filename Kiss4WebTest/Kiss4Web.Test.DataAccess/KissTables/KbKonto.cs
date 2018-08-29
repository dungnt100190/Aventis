namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbKonto")]
    public partial class KbKonto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbKonto()
        {
            KbKonto1 = new HashSet<KbKonto>();
        }

        public int KbKontoID { get; set; }

        public int? KbPeriodeID { get; set; }

        public int? GruppeKontoID { get; set; }

        public bool Kontogruppe { get; set; }

        public int? KbKontoklasseCode { get; set; }

        [StringLength(20)]
        public string KbKontoartCodes { get; set; }

        [Required]
        [StringLength(10)]
        public string KontoNr { get; set; }

        [Required]
        [StringLength(100)]
        public string KontoName { get; set; }

        [Column(TypeName = "money")]
        public decimal Vorsaldo { get; set; }

        [StringLength(100)]
        public string SaldoGruppeName { get; set; }

        public bool? Saldovortrag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbKontoTS { get; set; }

        public int? SortKey { get; set; }

        public int? KbZahlungskontoID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbKonto> KbKonto1 { get; set; }

        public virtual KbKonto KbKonto2 { get; set; }

        public virtual KbPeriode KbPeriode { get; set; }

        public virtual KbZahlungskonto KbZahlungskonto { get; set; }
    }
}
