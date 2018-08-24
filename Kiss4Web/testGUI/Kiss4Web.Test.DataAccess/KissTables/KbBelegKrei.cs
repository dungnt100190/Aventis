namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KbBelegKrei
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbBelegKrei()
        {
            KbBuchungs = new HashSet<KbBuchung>();
            KbFreieBelegNummers = new HashSet<KbFreieBelegNummer>();
        }

        [Key]
        public int KbBelegKreisID { get; set; }

        public int KbPeriodeID { get; set; }

        public int KbBelegKreisCode { get; set; }

        [StringLength(10)]
        public string KontoNr { get; set; }

        public int? NaechsteBelegNr { get; set; }

        public int? BelegNrVon { get; set; }

        public int? BelegNrBis { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbBelegKreisTS { get; set; }

        public virtual KbPeriode KbPeriode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbFreieBelegNummer> KbFreieBelegNummers { get; set; }
    }
}
