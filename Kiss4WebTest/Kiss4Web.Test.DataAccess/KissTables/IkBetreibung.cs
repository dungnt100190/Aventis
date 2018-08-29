namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkBetreibung")]
    public partial class IkBetreibung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IkBetreibung()
        {
            IkBetreibungAusgleiches = new HashSet<IkBetreibungAusgleich>();
        }

        public int IkBetreibungID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? IkRechtstitelID { get; set; }

        public int IkBetreibungStatusCode { get; set; }

        public int IkVerlustscheinStatusCode { get; set; }

        public int IkVerlustscheinTypCode { get; set; }

        public DateTime BetreibungAm { get; set; }

        [StringLength(20)]
        public string BetreibungNummer { get; set; }

        [StringLength(200)]
        public string BetreibungAmt { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetreibungBetrag { get; set; }

        public DateTime? BetreibungVon { get; set; }

        public DateTime? BetreibungBis { get; set; }

        public DateTime? BetreibungFortsetzungAm { get; set; }

        public DateTime? BetreibungVerwertungAm { get; set; }

        public DateTime? BetreibungRechtsoeffnungAm { get; set; }

        [StringLength(200)]
        public string Glaeubiger { get; set; }

        public DateTime VerlustscheinAm { get; set; }

        [StringLength(20)]
        public string VerlustscheinNummer { get; set; }

        [StringLength(200)]
        public string VerlustscheinAmt { get; set; }

        [Column(TypeName = "money")]
        public decimal? VerlustscheinBetrag { get; set; }

        [Column(TypeName = "money")]
        public decimal? VerlustscheinZins { get; set; }

        [Column(TypeName = "money")]
        public decimal? VerlustscheinKosten { get; set; }

        public DateTime? VerlustscheinVerjaehrungAm { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkBetreibungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual IkRechtstitel IkRechtstitel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkBetreibungAusgleich> IkBetreibungAusgleiches { get; set; }
    }
}
