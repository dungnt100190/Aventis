namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbZahlungseingang")]
    public partial class KbZahlungseingang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbZahlungseingang()
        {
            KbBuchungs = new HashSet<KbBuchung>();
        }

        public int KbZahlungseingangID { get; set; }

        public DateTime Datum { get; set; }

        public int? BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }

        [StringLength(200)]
        public string Debitor { get; set; }

        [StringLength(10)]
        public string KontoNr { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        [StringLength(100)]
        public string Mitteilung1 { get; set; }

        [StringLength(100)]
        public string Mitteilung2 { get; set; }

        [StringLength(100)]
        public string Mitteilung3 { get; set; }

        [StringLength(100)]
        public string Mitteilung4 { get; set; }

        public string Bemerkung { get; set; }

        public bool Ausgeglichen { get; set; }

        public bool Freigegeben { get; set; }

        public int? ZugeteiltUserID { get; set; }

        public int? ErstelltUserID { get; set; }

        public DateTime? ErstelltDatum { get; set; }

        public int? MutiertUserID { get; set; }

        public DateTime? MutiertDatum { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbZahlungseingangTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        public virtual XUser XUser2 { get; set; }
    }
}
