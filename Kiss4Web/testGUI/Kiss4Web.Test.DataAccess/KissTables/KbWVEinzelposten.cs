namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbWVEinzelposten")]
    public partial class KbWVEinzelposten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbWVEinzelposten()
        {
            KbWVEinzelposten1 = new HashSet<KbWVEinzelposten>();
        }

        public int KbWVEinzelpostenID { get; set; }

        public int? StorniertKbWVEinzelpostenID { get; set; }

        public int KbWVLaufID { get; set; }

        public int BaPersonID { get; set; }

        public int BaWVCodeID { get; set; }

        public int BaWVCode { get; set; }

        public int KbBuchungKostenartID { get; set; }

        public int KbKostenstelleID { get; set; }

        public int? BgKostenartID { get; set; }

        public int BgSplittingArtCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime DatumBis { get; set; }

        public bool SplittingDurchWVLaufDatumBis { get; set; }

        public int KbWVEinzelpostenStatusCode { get; set; }

        public bool Fakturiert { get; set; }

        public bool Ungueltig { get; set; }

        [StringLength(200)]
        public string Buchungstext { get; set; }

        [StringLength(50)]
        public string HeimatkantonNr { get; set; }

        [StringLength(50)]
        public string WohnKantonNr { get; set; }

        [StringLength(50)]
        public string KantonKuerzel { get; set; }

        public bool? Auslandschweizer { get; set; }

        [StringLength(2000)]
        public string Bemerkungen { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbWVEinzelpositionTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaWVCode BaWVCode1 { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        public virtual KbBuchungKostenart KbBuchungKostenart { get; set; }

        public virtual KbKostenstelle KbKostenstelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelposten> KbWVEinzelposten1 { get; set; }

        public virtual KbWVEinzelposten KbWVEinzelposten2 { get; set; }

        public virtual KbWVLauf KbWVLauf { get; set; }
    }
}
