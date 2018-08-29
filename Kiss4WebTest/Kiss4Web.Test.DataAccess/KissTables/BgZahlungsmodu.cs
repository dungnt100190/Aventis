namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BgZahlungsmodu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgZahlungsmodu()
        {
            BgAuszahlungPersons = new HashSet<BgAuszahlungPerson>();
            BgZahlungsmodusTermins = new HashSet<BgZahlungsmodusTermin>();
        }

        [Key]
        public int BgZahlungsmodusID { get; set; }

        public int FaLeistungID { get; set; }

        [Required]
        [StringLength(100)]
        public string NameZahlungsmodus { get; set; }

        public int KbAuszahlungsArtCode { get; set; }

        public bool KontoKlient { get; set; }

        public int? BaZahlungswegID { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgZahlungsmodusTS { get; set; }

        public virtual BaZahlungsweg BaZahlungsweg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgAuszahlungPerson> BgAuszahlungPersons { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgZahlungsmodusTermin> BgZahlungsmodusTermins { get; set; }
    }
}
