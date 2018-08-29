namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvAuszahlungPosition")]
    public partial class GvAuszahlungPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GvAuszahlungPosition()
        {
            GvAuszahlungPositionValutas = new HashSet<GvAuszahlungPositionValuta>();
            KbBuchungKostenarts = new HashSet<KbBuchungKostenart>();
        }

        public int GvAuszahlungPositionID { get; set; }

        public int GvGesuchID { get; set; }

        public int GvPositionsartID { get; set; }

        public int BaZahlungswegID { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        public DateTime? ValutaDatum { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        public string Zahlungsinstruktion { get; set; }

        public int GvAuszahlungTerminArtCode { get; set; }

        public int GvAuszahlungArtCode { get; set; }

        public int GvAuszahlungPositionStatusCode { get; set; }

        [StringLength(35)]
        public string MitteilungZeile1 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile2 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile3 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile4 { get; set; }

        [StringLength(200)]
        public string BuchungsText { get; set; }

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
        public byte[] GvAuszahlungPositionTS { get; set; }

        public virtual BaZahlungsweg BaZahlungsweg { get; set; }

        public virtual GvGesuch GvGesuch { get; set; }

        public virtual GvPositionsart GvPositionsart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAuszahlungPositionValuta> GvAuszahlungPositionValutas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchungKostenart> KbBuchungKostenarts { get; set; }
    }
}
