namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaWVCode")]
    public partial class BaWVCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaWVCode()
        {
            KbWVEinzelpostens = new HashSet<KbWVEinzelposten>();
        }

        public int BaWVCodeID { get; set; }

        public int BaPersonID { get; set; }

        [Column("BaWVCode")]
        public int? BaWVCode1 { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? StatusCode { get; set; }

        public string Bemerkung { get; set; }

        [StringLength(50)]
        public string HeimatKantonNr { get; set; }

        [StringLength(50)]
        public string WohnKantonNr { get; set; }

        [StringLength(50)]
        public string KantonKuerzel { get; set; }

        public bool? Auslandschweizer { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaWVCodeTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelposten> KbWVEinzelpostens { get; set; }
    }
}
