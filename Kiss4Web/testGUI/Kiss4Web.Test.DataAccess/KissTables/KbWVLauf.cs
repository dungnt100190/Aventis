namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbWVLauf")]
    public partial class KbWVLauf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbWVLauf()
        {
            KbWVEinzelpostens = new HashSet<KbWVEinzelposten>();
            KbWVEinzelpostenFehlers = new HashSet<KbWVEinzelpostenFehler>();
        }

        public int KbWVLaufID { get; set; }

        public int UserID { get; set; }

        public int KbPeriodeID { get; set; }

        public DateTime DatumBisWVLauf { get; set; }

        public DateTime StartDatum { get; set; }

        public DateTime? EndDatum { get; set; }

        public bool Testlauf { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbWVLaufTS { get; set; }

        public virtual KbPeriode KbPeriode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelposten> KbWVEinzelpostens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelpostenFehler> KbWVEinzelpostenFehlers { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
