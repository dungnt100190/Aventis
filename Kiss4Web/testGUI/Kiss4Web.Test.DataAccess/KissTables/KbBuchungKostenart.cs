namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbBuchungKostenart")]
    public partial class KbBuchungKostenart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbBuchungKostenart()
        {
            KbWVEinzelpostens = new HashSet<KbWVEinzelposten>();
            KbWVEinzelpostenFehlers = new HashSet<KbWVEinzelpostenFehler>();
        }

        public int KbBuchungKostenartID { get; set; }

        public int KbKostenstelleID { get; set; }

        public int? NrmKontoCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbBuchungKostenartTS { get; set; }

        public int KbBuchungID { get; set; }

        [StringLength(10)]
        public string KontoNr { get; set; }

        public int? BgKostenartID { get; set; }

        [StringLength(200)]
        public string Buchungstext { get; set; }

        public int? BgPositionID { get; set; }

        public int? BaPersonID { get; set; }

        public int? PositionImBeleg { get; set; }

        public int? KbForderungArtCode { get; set; }

        public DateTime? VerwPeriodeVon { get; set; }

        public DateTime? VerwPeriodeBis { get; set; }

        public int? BgSplittingArtCode { get; set; }

        public bool Weiterverrechenbar { get; set; }

        public bool Quoting { get; set; }

        public int? GvAuszahlungPositionID { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        public virtual BgPosition BgPosition { get; set; }

        public virtual GvAuszahlungPosition GvAuszahlungPosition { get; set; }

        public virtual KbBuchung KbBuchung { get; set; }

        public virtual KbKostenstelle KbKostenstelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelposten> KbWVEinzelpostens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelpostenFehler> KbWVEinzelpostenFehlers { get; set; }
    }
}
