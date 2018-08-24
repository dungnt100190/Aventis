namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkPosition")]
    public partial class IkPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IkPosition()
        {
            IkForderungPositions = new HashSet<IkForderungPosition>();
            IkRatenplanForderungs = new HashSet<IkRatenplanForderung>();
            KbBuchungs = new HashSet<KbBuchung>();
        }

        public int IkPositionID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? IkRechtstitelID { get; set; }

        public bool Einmalig { get; set; }

        public DateTime? Datum { get; set; }

        public int Monat { get; set; }

        public int Jahr { get; set; }

        public int? BaPersonID { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAliment { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAlimentSoll { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragALBV { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragALBVSoll { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragKiZulage { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragKiZulageSoll { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragALBVverrechnung { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragEinmalig { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragAuszahlung { get; set; }

        public int? IkForderungCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? IndexStandBeiBerechnung { get; set; }

        public DateTime? IndexStandDatum { get; set; }

        public bool ErledigterMonat { get; set; }

        public bool Unterstuetzungsfall { get; set; }

        public bool ALBVBerechtigt { get; set; }

        public bool BetragIstNegativ { get; set; }

        [StringLength(500)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkPositionTS { get; set; }

        [Column("_tmp_AiForderungID_Einmalig")]
        public int? C_tmp_AiForderungID_Einmalig { get; set; }

        [Column("_tmp_AiForderungID")]
        public int? C_tmp_AiForderungID { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderungPosition> IkForderungPositions { get; set; }

        public virtual IkRechtstitel IkRechtstitel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkRatenplanForderung> IkRatenplanForderungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }
    }
}
