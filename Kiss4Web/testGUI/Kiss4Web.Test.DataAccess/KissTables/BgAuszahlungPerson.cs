namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgAuszahlungPerson")]
    public partial class BgAuszahlungPerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgAuszahlungPerson()
        {
            BgAuszahlungPersonTermins = new HashSet<BgAuszahlungPersonTermin>();
        }

        public int BgAuszahlungPersonID { get; set; }

        public int BgPositionID { get; set; }

        public int? BaPersonID { get; set; }

        public int? BgZahlungsmodusID { get; set; }

        public int? KbAuszahlungsArtCode { get; set; }

        public int? BgAuszahlungsTerminCode { get; set; }

        [StringLength(20)]
        public string BgWochentagCodes { get; set; }

        public int? BaZahlungswegID { get; set; }

        [StringLength(200)]
        public string Zahlungsgrund { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        [StringLength(35)]
        public string MitteilungZeile1 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile2 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile3 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile4 { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgAuszahlungPersonTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaZahlungsweg BaZahlungsweg { get; set; }

        public virtual BgPosition BgPosition { get; set; }

        public virtual BgZahlungsmodu BgZahlungsmodu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgAuszahlungPersonTermin> BgAuszahlungPersonTermins { get; set; }
    }
}
