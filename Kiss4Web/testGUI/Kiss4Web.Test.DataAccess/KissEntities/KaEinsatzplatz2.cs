namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KaEinsatzplatz2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaEinsatzplatz2()
        {
            KaAmmBesches = new HashSet<KaAmmBesch>();
            KaEinsatzs = new HashSet<KaEinsatz>();
        }

        [Key]
        public int KaEinsatzplatzID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int ProjektCode { get; set; }

        public int? ProfilCode { get; set; }

        public int? APVCode { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaEinsatzplatz2TS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAmmBesch> KaAmmBesches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaEinsatz> KaEinsatzs { get; set; }
    }
}
