namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkRatenplan")]
    public partial class IkRatenplan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IkRatenplan()
        {
            IkRatenplanForderungs = new HashSet<IkRatenplanForderung>();
        }

        public int IkRatenplanID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? IkRatenplanVereinbarungCode { get; set; }

        [StringLength(200)]
        public string Bezeichnung { get; set; }

        public DateTime? VereinbarungVom { get; set; }

        [Column(TypeName = "money")]
        public decimal GesamtBetrag { get; set; }

        [Column(TypeName = "money")]
        public decimal BetragProMonat { get; set; }

        [Column(TypeName = "money")]
        public decimal LetzterProMonat { get; set; }

        [StringLength(500)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkRatenplanTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkRatenplanForderung> IkRatenplanForderungs { get; set; }
    }
}
