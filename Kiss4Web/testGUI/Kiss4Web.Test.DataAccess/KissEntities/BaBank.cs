namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaBank")]
    public partial class BaBank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaBank()
        {
            BaZahlungswegs = new HashSet<BaZahlungsweg>();
            FbDTAZugangs = new HashSet<FbDTAZugang>();
            FbZahlungswegs = new HashSet<FbZahlungsweg>();
            KbBuchungs = new HashSet<KbBuchung>();
            KbZahlungskontoes = new HashSet<KbZahlungskonto>();
        }

        public int BaBankID { get; set; }

        public int? LandCode { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Zusatz { get; set; }

        [StringLength(50)]
        public string Strasse { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        [Required]
        [StringLength(15)]
        public string ClearingNr { get; set; }

        [StringLength(15)]
        public string ClearingNrNeu { get; set; }

        public int FilialeNr { get; set; }

        [StringLength(15)]
        public string HauptsitzBCL { get; set; }

        [StringLength(50)]
        public string PCKontoNr { get; set; }

        public DateTime GueltigAb { get; set; }

        public bool SicUpdated { get; set; }

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
        public byte[] BaBankTS { get; set; }

        public virtual BaLand BaLand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaZahlungsweg> BaZahlungswegs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbDTAZugang> FbDTAZugangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbZahlungsweg> FbZahlungswegs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungskonto> KbZahlungskontoes { get; set; }
    }
}
