namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkForderung")]
    public partial class IkForderung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IkForderung()
        {
            IkForderungPositions = new HashSet<IkForderungPosition>();
            IkRatenplanForderungs = new HashSet<IkRatenplanForderung>();
        }

        public int IkForderungID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? IkRechtstitelID { get; set; }

        public int? BaPersonID { get; set; }

        public int IkForderungPeriodischCode { get; set; }

        public DateTime DatumAnpassenAb { get; set; }

        public DateTime? DatumGueltigBis { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        public int? IkAnpassungsGrundCode { get; set; }

        public int? IkAnpassungsRegelCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? IndexStandBeiBerechnung { get; set; }

        public DateTime? IndexStandDatum { get; set; }

        public string Bemerkung { get; set; }

        public bool Sollgestellt { get; set; }

        public bool ALBVBerechtigt { get; set; }

        public bool Teuerungseinsprache { get; set; }

        public bool Unterstuetzungsfall { get; set; }

        public bool TeilALBV { get; set; }

        [Column(TypeName = "money")]
        public decimal? TeilALBVBetrag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkForderungTS { get; set; }

        [Column("_tmp_AiForderungID_Periodisch")]
        public int? C_tmp_AiForderungID_Periodisch { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual IkRechtstitel IkRechtstitel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderungPosition> IkForderungPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkRatenplanForderung> IkRatenplanForderungs { get; set; }
    }
}
