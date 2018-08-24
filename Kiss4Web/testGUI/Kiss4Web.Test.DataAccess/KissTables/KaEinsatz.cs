namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaEinsatz")]
    public partial class KaEinsatz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaEinsatz()
        {
            KaAmmBesches = new HashSet<KaAmmBesch>();
        }

        public int KaEinsatzID { get; set; }

        public int BaPersonID { get; set; }

        public int KaEinsatzplatzID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? AnweisungCode { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime DatumBis { get; set; }

        public bool SamstagAktiv { get; set; }

        public bool SonntagAktiv { get; set; }

        public int? BeschGrad { get; set; }

        public int? APVZusatzCode { get; set; }

        public int? PersonenNr { get; set; }

        public DateTime? RahmenfristBis { get; set; }

        public int? ALKasseID { get; set; }

        public int? ZuweiserID { get; set; }

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
        public byte[] KaEinsatzTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAmmBesch> KaAmmBesches { get; set; }

        public virtual KaEinsatzplatz2 KaEinsatzplatz2 { get; set; }
    }
}
